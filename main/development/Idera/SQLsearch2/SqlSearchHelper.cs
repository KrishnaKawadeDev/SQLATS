using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SqlSearch
{
    class SqlSearchResult
    {
        public SqlSearchResult() { }
        public string database;
        public string schema;
        public string name;
        public string objectType;
        public string sqlExcerpt;
        public string fullSql;
        public int    id;
        public bool   isJob   = false;
        public string jobInfo = "";
        
        public string DisplayMember { get { return name; } }
        override public string ToString() { return name; }

        public string GetFullName()
        {
           string nm = name;
           if ( schema != null && schema != "" && schema != "dbo" )
           {
              nm = schema + "." + nm;
           }
           return nm;
        }

        public string GetObjectType()
        {
           string strType;

           switch ( objectType )
           {
              case "V ":
                 strType = "View";
                 break;
              case "FN":
                 strType = "Function";
                 break;
              case "TR":
                 strType = "DML Trigger";
                 break;
              case "P ":
                 strType = "Stored Procedure";
                 break;
              case "IF":
                 strType = "Inline Function";
                 break;
              case "TF":
                 strType = "Table Function";
                 break;
              case "J":
                 strType = "Job";
                 break;
              case "DDL":
                 strType = "DDL Trigger";
                 break;
              case "SRV_TRIGGER":
                 strType = "Server Trigger";
                 break;
              default:
                 strType = "Unknown";
                 break;
           }
           return strType;
        }
    }

    class SqlSearchHelper
    {
       public static string  databaseList;
       public static string  searchText;
       public static bool    matchStoredProc;
       public static bool    matchTrigger;
       public static bool    matchJobSteps;
       public static bool    matchView;
       public static bool    matchFunction;
       public static bool    matchCase;
       public static bool    allowWildcards;
       public static bool    limitResults;
       public static string  strLimit;
       public static bool    includeSystemDatabases;
        private static object threadLock = new object();

        public static IList
           PerformSearch(
            ServerInformation serverInformation,
            int               commandTimeout,
            JobPoolOptions    options
          )
        {
            IList       resultList   = null;
            ICollection databases = null;
            int         found = 0;
            int         limit = 0;
            SqlConnection conn = null;
            lock (threadLock)
            {
                SetDatabaseList(databaseList);

                if (limitResults)
                    limit = Convert.ToInt32(strLimit);

                try
                {
                    conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials);

                    //-----------------------------------------
                    // Search for all SQL other then job steps
                    //-----------------------------------------
                    string caseSensitive = "";
                    string caseInsensitive = "";
                    string dbTriggerCaseSensitive = "";
                    string dbTriggerCaseInsensitive = "";
                    string srvTriggerCaseSensitive = "";
                    string srvTriggerCaseInsensitive = "";

                    if (SQLHelpers.GetSqlVersion(conn) < 8)
                    {
                        throw new Exception("SQL Search only supports SQL Server 2000 and higher.");
                    }
                    else if (SQLHelpers.GetSqlVersion(conn) == 8)
                    {
                        // SQL Server 2000
                        string cmdstr = "USE {0}; " +
                                 "SELECT o.name,c.text,o.xtype, u.name, o.id " +
                                 "FROM {0}..sysobjects o  " +
                                 "INNER JOIN {0}..syscomments c ON o.id=c.id " +
                                 "INNER JOIN {0}..sysusers u ON o.uid=u.uid ";

                        caseSensitive = cmdstr + "WHERE [text] collate SQL_Latin1_General_CP1_CS_AS " +
                                                 "LIKE '%{1}%' collate SQL_Latin1_General_CP1_CS_AS ";
                        caseInsensitive = cmdstr + "WHERE lower([text]) LIKE lower('%{1}%')";
                    }
                    else
                    {
                        // SQL Server 2005 and up
                        string cmdstr = "USE {0}; " +
                                 "SELECT o.name,m.definition,o.xtype, s.name, m.object_id " +
                                 "FROM {0}.sys.sql_modules m " +
                                 "INNER JOIN {0}..sysobjects o ON m.object_id=o.id " +
                                 "INNER JOIN sys.schemas s ON o.uid = s.schema_id ";
                        caseSensitive = cmdstr + "WHERE [definition] collate SQL_Latin1_General_CP1_CS_AS " +
                                                 "LIKE '%{1}%' collate SQL_Latin1_General_CP1_CS_AS";
                        caseInsensitive = cmdstr + "WHERE lower([definition]) LIKE lower('%{1}%')";


                        // database and server level trigger SQL
                        cmdstr = "USE {0}; " +
                                 "SELECT t.name,m.definition,m.object_id " +
                                 "FROM sys.triggers t " +
                                 "INNER JOIN sys.sql_modules m ON m.object_id=t.object_id " +
                                 "WHERE parent_class=0 ";
                        dbTriggerCaseSensitive = cmdstr + "AND [definition] collate SQL_Latin1_General_CP1_CS_AS " +
                                                 "LIKE '%{1}%' collate SQL_Latin1_General_CP1_CS_AS";
                        dbTriggerCaseInsensitive = cmdstr + "AND lower([definition]) LIKE lower('%{1}%')";

                        cmdstr = "SELECT t.name,m.definition,m.object_id " +
                                 "FROM sys.server_triggers t " +
                                 "INNER JOIN sys.server_sql_modules m ON m.object_id=t.object_id ";
                        srvTriggerCaseSensitive = cmdstr + "WHERE [definition] collate SQL_Latin1_General_CP1_CS_AS " +
                                                 "LIKE '%{0}%' collate SQL_Latin1_General_CP1_CS_AS";
                        srvTriggerCaseInsensitive = cmdstr + "WHERE lower([definition]) LIKE lower('%{0}%')";
                    }

                    // if allow wildcards and user put in %'s we should strip off since we add them back in
                    if (allowWildcards
                          && searchText.Length >= 2
                          && searchText[0] == '%'
                          && searchText[searchText.Length - 1] == '%')
                    {
                        searchText = searchText.Substring(1, searchText.Length - 2);
                    }


                    string matchString = SQLHelpers.CreateSafeString(searchText);
                    // strip off leading and trailing quotes since we are going to insert string in '%{0}%'
                    matchString = matchString.Substring(1, matchString.Length - 2);


                    if (!allowWildcards)
                    {
                        matchString = SQLHelpers.EscapeWildcards(matchString);
                    }

                    resultList = new ArrayList();

                    if (!String.IsNullOrEmpty(databaseList) || includeSystemDatabases)
                    {
                        databases = SQLObjects.GetDatabases(conn, false);
                    }
                    else
                    {
                        databases = SQLObjects.GetUserDatabases(conn);
                    }

                    foreach (DatabaseObject db in databases)
                    {
                        // should we process this database?
                        if (!IsDatabaseInDatabaseList(db.name)) continue;

                        if (db.compatabilityLevel < 70)
                        {
                            Messaging.ShowInformation(String.Format("Skipping database '{0}'. SQL Search does not support databases whose compatability level is set to a version prior to SQL Server 7.0.",
                                                                      db.name));
                            Application.DoEvents();
                            continue;
                        }

                        // SQL in regular places
                        string sqlTemplate;
                        if (!matchCase || db.compatabilityLevel <= 70)   // collate not supported in 70 or prior versions
                            sqlTemplate = caseInsensitive;
                        else
                            sqlTemplate = caseSensitive;

                        string sql = String.Format(sqlTemplate,
                                                    SQLHelpers.CreateSafeDatabaseName(db.name),
                                                    matchString);
                        int version_id = SQLHelpers.GetSqlVersion(conn);
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                int objectId = 0;
                                while (reader.Read())
                                {
                                    string objType = reader.GetString(2);

                                    if (WantType(objType,
                                                   matchStoredProc,
                                                   matchTrigger,
                                                   matchView,
                                                   matchFunction))
                                    {
                                        if (objectId != reader.GetInt32(4))
                                        {
                                            SqlSearchResult r = new SqlSearchResult();

                                            r.database = db.name;
                                            r.schema = reader.GetString(3);
                                            r.id = reader.GetInt32(4);
                                            objectId = r.id;
                                            r.name = reader.GetString(0);
                                            r.objectType = objType;

                                            string fullSql = reader.GetString(1);

                                            // show from 10 characters before string and up to 64 after
                                            r.sqlExcerpt = GetSqlLineWithFirstMatch(fullSql, searchText, matchCase, allowWildcards);

                                            // only store full SQL for first 50 matches
                                            //    - after that we read dynamically from SQL Server if they try to load source
                                            //Changes added to merge the objects displayed for SQL2000
                                            if (found < 51 && version_id != 8)
                                                r.fullSql = fullSql;
                                            else
                                                r.fullSql = null;

                                            resultList.Add(r);

                                            found++;
                                            if (limitResults && (found == limit)) break;
                                        }
                                    }
                                }
                            }
                        }

                        // database level trigger - sql 2005 and up
                        if (matchTrigger && (SQLHelpers.GetSqlVersion(conn) > 8))
                        {
                            // Database Level Triggers
                            if (!matchCase || db.compatabilityLevel <= 70)   // collate not supported in 70 or prior versions
                                sqlTemplate = dbTriggerCaseInsensitive;
                            else
                                sqlTemplate = dbTriggerCaseSensitive;

                            sql = String.Format(sqlTemplate,
                                                  SQLHelpers.CreateSafeDatabaseName(db.name),
                                                  matchString);

                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        SqlSearchResult r = new SqlSearchResult();

                                        r.database = db.name;
                                        r.schema = "";
                                        r.id = reader.GetInt32(2);
                                        r.name = reader.GetString(0);
                                        r.objectType = "DDL";

                                        string fullSql = reader.GetString(1);

                                        // show from 10 characters before string and up to 64 after
                                        r.sqlExcerpt = GetSqlLineWithFirstMatch(fullSql, searchText, matchCase, allowWildcards);

                                        // only store full SQL for first 50 matches
                                        //    - after that we read dynamically from SQL Server if they try to load source
                                        if (found < 51)
                                            r.fullSql = fullSql;
                                        else
                                            r.fullSql = null;

                                        resultList.Add(r);

                                        found++;
                                        if (limitResults && (found == limit)) break;
                                    }
                                }
                            }
                        }

                        if (limitResults && (found == limit)) break;
                    }

                    //-----------------------------------------
                    // Server Level Triggers - 2005 and up only
                    //-----------------------------------------
                    if (matchTrigger && (SQLHelpers.GetSqlVersion(conn) > 8) && (!(limitResults && (found == limit))))
                    {
                        string sqlTemplate;
                        if (!matchCase)
                            sqlTemplate = srvTriggerCaseInsensitive;
                        else
                            sqlTemplate = srvTriggerCaseSensitive;

                        string sql = String.Format(sqlTemplate, matchString);

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    SqlSearchResult r = new SqlSearchResult();

                                    r.database = "Server Level";
                                    r.schema = "";
                                    r.id = reader.GetInt32(2);
                                    r.name = reader.GetString(0);
                                    r.objectType = "SRV_TRIGGER";

                                    string fullSql = reader.GetString(1);

                                    // show from 10 characters before string and up to 64 after
                                    r.sqlExcerpt = GetSqlLineWithFirstMatch(fullSql, searchText, matchCase, allowWildcards);

                                    // only store full SQL for first 50 matches
                                    //    - after that we read dynamically from SQL Server if they try to load source
                                    if (found < 51)
                                        r.fullSql = fullSql;
                                    else
                                        r.fullSql = null;

                                    resultList.Add(r);

                                    found++;
                                    if (limitResults && (found == limit)) break;
                                }
                            }
                        }
                    }

                    //-----------------------------------------
                    // Search Job Steps
                    //-----------------------------------------
                    // if user specified databases, make sure msdb is in list
                    /*bool msdbSpecified = false;
                    if ( String.IsNullOrEmpty(databaseList) || databases == null || databases.Count == 0 )
                    {
                       msdbSpecified = true;
                    }
                    else
                    {
                       foreach ( DatabaseObject db in databases )
                       {
                          if ( IsDatabaseInDatabaseList( db.name ) && db.name.ToUpper() == "MSDB" )
                          {
                             msdbSpecified = true;
                             break;
                          }
                       }
                    }*/

                    if (matchJobSteps && (!(limitResults && (found == limit)))) // havent reached search limit
                    {
                        string cmdstr2;

                        cmdstr2 = "SELECT j.name, js.step_name, js.step_id, js.subsystem, js.command from msdb..sysjobsteps js " +
                                 "INNER JOIN msdb..sysjobs j ON j.job_id = js.job_id ";
                        if (matchCase)
                            cmdstr2 += "WHERE [command] collate SQL_Latin1_General_CP1_CS_AS " +
                                      "LIKE '%{0}%' collate SQL_Latin1_General_CP1_CS_AS";
                        else
                            cmdstr2 += "WHERE lower([command]) LIKE lower('%{0}%')";

                        matchString = SQLHelpers.CreateSafeString(searchText);
                        // strip off leading and traling since we are going to insert string in '%{0}%'
                        matchString = matchString.Substring(1, matchString.Length - 2);
                        if (!allowWildcards)
                        {
                            matchString = SQLHelpers.EscapeWildcards(matchString);
                        }

                        string sql = String.Format(cmdstr2,
                                                    matchString);

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    SqlSearchResult r = new SqlSearchResult();

                                    r.database = "msdb";
                                    r.schema = "";
                                    r.name = reader.GetString(0);
                                    r.objectType = "J";

                                    string fullSql = reader.GetString(4);

                                    r.sqlExcerpt = GetSqlLineWithFirstMatch(fullSql, searchText, matchCase, allowWildcards);
                                    r.fullSql = fullSql;

                                    r.isJob = true;
                                    r.jobInfo = String.Format("Step: {0} - {1}", reader.GetInt32(2), reader.GetString(1));

                                    resultList.Add(r);

                                    found++;
                                    if (limitResults && (found == limit)) break;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Messaging.ShowException( "An error occurred trying to perform the requested search.", ex, "SQL Search" );
                    throw ex;
                }
                finally
                {
                    if (conn != null) conn.Close();
                }
            }
            return resultList;
        }

        #region Database Matching
        
        private static string[] m_databaseList;
        
        private static void
           SetDatabaseList(
              string  databaseListString
           )
        {
           if ( String.IsNullOrEmpty(databaseListString) )
              m_databaseList = null;
           else
           {
              m_databaseList = databaseListString.Split(';');
              for ( int i=0;i<m_databaseList.Length;i++) m_databaseList[i] = m_databaseList[i].Trim();
           }
        }
        
        private static bool 
           IsDatabaseInDatabaseList(
              string    database
           )
        {
           if ( m_databaseList == null ) return true;
           
           bool found = false;
           for (int i=0; i<m_databaseList.Length; i++ )
           {
              if ( database.ToUpper() == m_databaseList[i].ToUpper() )
              {
                 found = true;
                 break;
              }
           }
           return found;
        }
        
        #endregion

        private static bool
           WantType(
              string objType, 
              bool matchStoredProc,
              bool matchTrigger,
              bool matchView,
              bool matchFunction
           )
        {
           if ( matchStoredProc && (objType == "P ")  ) return true;
           if ( matchTrigger    && (objType == "TR") ) return true;
           if ( matchView       && (objType == "V ")  ) return true;
           if ( matchFunction   && (objType == "FN") ) return true; // Function
           if ( matchFunction   && (objType == "IF") ) return true; // Inline Function
           if ( matchFunction   && (objType == "TF") ) return true; // Table Function
           return false;
        }

        private static string
           GetSqlLineWithFirstMatch(
              string sql,
              string searchText,
              bool   matchCase,
              bool   allowWildcards
           )
        {
           string lineWithMatch = "";
           int    pos = -1;
           int    startPos = -1;
           int    endPos   = -1;
           
           
           if ( allowWildcards )
           {           
              string regexString = SQLHelpers.ConvertSqlWildcardToRegEx( searchText );
              
              try
              {
                 Regex pattern = new Regex( regexString, (matchCase) ? RegexOptions.None : RegexOptions.IgnoreCase);
                 Match matchObj = pattern.Match(sql);           
                 pos = matchObj.Index;
              }
              catch
              {
                 pos = -1;
              }
           }
           else
           {
              string uSql    = (! matchCase) ? sql.ToLower()        : sql;
              string uSearch = (! matchCase) ? searchText.ToLower() : searchText;
              pos = uSql.IndexOf(uSearch);
           }

           if ( pos == -1 ) return lineWithMatch;

           // find beginning of line
           while ( pos > 0 && sql[pos] != '\r' && sql[pos] != '\n' )
           {
              pos--;
              if ( sql[pos] == '\r' || sql[pos] == '\n' )
              {
                 startPos = pos+1;               
              }
           }
           if (startPos == -1) startPos = 0;

           // find end of line
           endPos = pos + searchText.Length;           
           while ( endPos < sql.Length )
           {
               if (sql[endPos] == '\r' || sql[endPos] == '\n')
                 break;
               endPos++;
           }

           // extract line now that we have start and end
           lineWithMatch = sql.Substring(startPos, endPos-startPos);

           return lineWithMatch;
        }

        public static string
           GetSqlForObject( 
              string         server,
              SQLCredentials sqlCredentials,
              string         database,
              int            id
           )
        {
            string fullSql = "";
            SqlConnection conn = null;

            try
            {
                conn = Connection.OpenConnection(server, database, sqlCredentials);

                string cmdstr;

                if (SQLHelpers.Is2000(conn))
                {
                    // SQL Server 2000
                    cmdstr = "USE {0}; " +
                             "SELECT text " +
                             "FROM {0}..syscomments " +
                             "WHERE id={1} ";
                }
                else
                {
                    // SQL Server 2005 and up
                    cmdstr = "USE {0}; " +
                             "SELECT definition " +
                             "FROM {0}.sys.sql_modules " +
                             "WHERE object_id={1} ";
                }

                string sql = String.Format(cmdstr,
                                           database,
                                           id );

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                   cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                   using ( SqlDataReader reader = cmd.ExecuteReader() )
                    {
                        while (reader.Read())
                        {
                           fullSql += reader.GetString(0);
                        }
                    }
                }
            }
            catch ( Exception ex )
            {
               Messaging.ShowException( "Unable to load SQL ", ex, "SQL Search" );
            }
            finally
            {
               if ( conn!=null ) conn.Close();
            }

            return fullSql;
        }
    }
}
