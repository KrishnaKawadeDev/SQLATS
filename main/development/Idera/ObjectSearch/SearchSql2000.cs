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

namespace Idera.SqlAdminToolset.ObjectSearch
{
public class SearchSql2000
{  
   // search input parameters
   public  string           m_server;
   public  SQLCredentials   m_credentials;
   public  string []        m_databaseList;
   public  string           m_searchString;
   public  bool             m_caseSensitiveSearch;
   public  bool             m_excludeSystemObjects;
   public  bool             m_allowWildcards;

   // used during queries
   private string           m_database;
   
   delegate string GetSQLDelegate();
   delegate void   ProcessReaderDelegate( SqlDataReader reader );



    private SearchHelper.ShowInformationDelegate m_ShowInfomationDelegate = null;
    private SearchHelper.ShowConfirmationDelegate m_ShowConfirmationDelegate = null;
   
   public SearchSql2000(
         string         inServer,
         SQLCredentials inCredentials,
         string[]       inDatabaseList,
         string         inSearchString,
         bool           inCaseSensitiveSearch,
         bool           inExcludeSystemObjects,
         bool           inAllowWildcards,
         SearchHelper.ShowInformationDelegate showInfoDelegate,
         SearchHelper.ShowConfirmationDelegate showConfDelegate
      )
   {
      m_server               = inServer;
      m_credentials          = inCredentials;
      m_databaseList         = inDatabaseList;
      m_searchString         = inSearchString;
      m_caseSensitiveSearch  = inCaseSensitiveSearch;
      m_excludeSystemObjects = inExcludeSystemObjects;
      m_allowWildcards       = inAllowWildcards;
      m_ShowInfomationDelegate = showInfoDelegate;
      m_ShowConfirmationDelegate = showConfDelegate;
   }

    
   
   #region Worker Routines

   //----------------------------------------------------------------------------   
   // PerformSearch - main entry point of searcher class
   //----------------------------------------------------------------------------   
   public void PerformSearch()
   {
      ICollection databases;
      
      //-----------------------
      // Server Object Queries
      //-----------------------
      if ( m_databaseList ==null || m_databaseList.Length==0 )
      {
         DoQuery( "Databases", GetSQL_sysdatabases,          ProcessReader_sysdatabases );
         if ( ProductConstants.operationCancelled || ProductConstants.searchLimitReached) return;
         
         DoQuery( "Jobs", GetSQL_sysjobs,               ProcessReader_sysjobs );
         if ( ProductConstants.operationCancelled || ProductConstants.searchLimitReached) return;
         
         // do syslogins if we are not including system objects so that we can pick up server logins
         if ( m_excludeSystemObjects ) // in this case we dont search master down in
                                       // database section so search it here
         {
            m_database = "master";
            DoQuery( "Server Logins", GetSQL_syslogins,             ProcessReader_syslogins );
            if ( ProductConstants.operationCancelled || ProductConstants.searchLimitReached) return;
         }
      }
      
      //-------------------------
      // Database Object Queries
      //-------------------------
      
      // Get list of databases to query
      SqlConnection conn = null;
      
      try
      {
         conn = Connection.OpenConnection( m_server, m_credentials );
      
         if ( ! m_excludeSystemObjects )
         {
            databases = SQLObjects.GetDatabases(conn, false );
         }
         else
         {
            databases = SQLObjects.GetUserDatabases(conn);
         }
      }
      finally
      {
         Connection.CloseConnection(conn);
      }
      
      if ( ProductConstants.operationCancelled || ProductConstants.searchLimitReached) return;
      
      bool saveCaseSensitiveSearch  = m_caseSensitiveSearch;

      // walk the databases               
      foreach ( DatabaseObject db in databases )
      {
         // should we process this database?
         if ( ! SearchHelper.IsDatabaseInDatabaseList( db.name, m_databaseList ) ) continue;
         
         if ( db.compatabilityLevel == 70 )
         {
            // turn off case sensitive to avoid COLLATE keyword - turn back on after query on this databases
            m_caseSensitiveSearch = false;
         }
        
         if ( db.compatabilityLevel < 70 )
         {
             m_ShowInfomationDelegate(String.Format("Skipping database '{0}' on server '{1}'. Object Search does not support databases whose compatability level is set to a version prior to SQL Server 7.0.",
                                                       db.name,
                                                       m_server));
           Application.DoEvents();
           continue;
        }
        
         // do the database query
         m_database = db.name;
                  
         DoQuery( String.Format( "Objects in Database {0}", db.name ),
                  GetSQL_sysobjects, ProcessReader_sysobjects );
         if ( ProductConstants.operationCancelled || ProductConstants.searchLimitReached) return;
         
         DoQuery( String.Format( "Columns in Database {0}", db.name ),
                  GetSQL_syscolumns, ProcessReader_syscolumns );
         if ( ProductConstants.operationCancelled || ProductConstants.searchLimitReached) return;
         
         DoQuery( String.Format( "Logins in Database {0}", db.name ),
                  GetSQL_syslogins,  ProcessReader_syslogins );
         if ( ProductConstants.operationCancelled || ProductConstants.searchLimitReached) return;
         
         DoQuery( String.Format( "Indexes in Database {0}", db.name ),
                  GetSQL_sysindexes, ProcessReader_sysindexes );
         if ( ProductConstants.operationCancelled || ProductConstants.searchLimitReached) return;
         
         // turn off case sensitive to avoid COLLATE keyword - turn back on after query on this databases
         m_caseSensitiveSearch = saveCaseSensitiveSearch;
      }
   }
   
   private bool
      DoQuery(
         string                 queryType,
         GetSQLDelegate        getSqlHandler,
         ProcessReaderDelegate rowHandler
      )
   {
      bool success = false;
      SqlConnection conn = null;
      
      try
      {
         conn = Connection.OpenConnection( m_server, m_credentials );
         
         string cmdStr = getSqlHandler();
         
         using (SqlCommand cmd = new SqlCommand(cmdStr, conn))
         {
            cmd.CommandTimeout = ToolsetOptions.commandTimeout;

            using ( SqlDataReader reader = cmd.ExecuteReader() )
            {
               rowHandler( reader );
            }
         }
         success = true;
      }
      catch ( SqlException sqlEx )
      {
         CoreGlobals.traceLog.ErrorFormat( "2000: Error in {0} - {1}", getSqlHandler.ToString(), sqlEx.Message );                                   
         
         string msg = String.Format( "The following error occurred searching {0}.\r\n\r\nError: {1}\r\n\r\n" + 
                                     "Do you want to continue searching other object types?",
                                     queryType,
                                     sqlEx.Message );
                                     
         DialogResult choice = m_ShowConfirmationDelegate( msg );
         if ( choice == DialogResult.No )
         {
            throw sqlEx;
         }
      }
      catch (Exception ex )
      {
         string msg = String.Format( "Unable to perform search query. Error: {0}", 
                                     Helpers.GetCombinedExceptionText(ex) ) ;

         CoreGlobals.traceLog.ErrorFormat( "2000: Error in {0} - {1}", getSqlHandler.ToString(), ex.Message );
         
         throw new Exception( msg );
      }
      finally
      {
         Connection.CloseConnection(conn);
      }

      return success;
   }
   
   //--------------------------------------------------------------------------   
   // GetTypeDesc
   //--------------------------------------------------------------------------   
   private int
      GetTypeDesc(
         SearchTypeDesc[] typedesc,
         string           type
      )
   {
      string matchType = type.Trim().ToUpper();
      
      try
      {         
         for (int i=0; i<typedesc.GetLength(0);i++)
         {
            if ( matchType.ToUpper() == typedesc[i].type )
            {
               return i;
            }
         }
      }
      catch{}
      
      return (int)SearchHelper.IconType.Unknown;
   }
   
   #endregion
  
   #region System Level Queries
   
   #region sysdatabases

   //--------------------------------------------------------------------------   
   // GetSQL_sysdatabases
   //--------------------------------------------------------------------------   
   private string GetSQL_sysdatabases()
   {
      string sqlTemplate = "SELECT name,sid from master..sysdatabases "; 

      // case sensitive vs. case insensitive
      if ( m_caseSensitiveSearch ) 
      {
         sqlTemplate += "WHERE name collate SQL_Latin1_General_CP1_CS_AS " + 
                        "LIKE '{0}' collate SQL_Latin1_General_CP1_CS_AS ";
      }                       
      else
      {
         sqlTemplate += "WHERE lower(name) LIKE lower('{0}') ";
      }

      // search system objects
      if ( m_excludeSystemObjects )
      {
         sqlTemplate += " AND sid<>1";
      }
      
      string searchString;
      if ( m_allowWildcards )
      {
         searchString = m_searchString;
      }
      else
      {
         searchString = String.Format( "%{0}%", SQLHelpers.EscapeWildcards(m_searchString) );
      }
      
      string sql = String.Format( sqlTemplate, searchString );  
      
      return sql;
   }
   
   //--------------------------------------------------------------------------   
   // ProcessReader_sysdatabases
   //--------------------------------------------------------------------------   
   private void
      ProcessReader_sysdatabases(
         SqlDataReader reader
      )
   {
      byte[] sid = null;

      while ( reader.Read() )
      {
         SearchResult result = new SearchResult( m_server);
         
         result.name = SQLHelpers.GetString( reader, 0 );
         
         sid = SQLHelpers.GetBinary( reader, 1 );
         
         if ( SQLHelpers.IsSystemDatabase(result.name) )
         {
            result.objectType = "System Database";
         }
         else
         {
            result.objectType = "Database";
         }
         result.iconIndex = SearchHelper.IconType.Database;
         
         Form_Main.AddSearchResult( result );
      }
   }
   
   #endregion // sysdatabases
   
   
   #region sysjobs
   
   //--------------------------------------------------------------------------   
   // GetSQL_sysjobs
   //--------------------------------------------------------------------------   
   private string GetSQL_sysjobs()
   {
      string sqlTemplate = "SELECT name, enabled, description  from msdb..sysjobs ";

      // case sensitive vs. case insensitive
      if ( m_caseSensitiveSearch ) 
         sqlTemplate += "WHERE name collate SQL_Latin1_General_CP1_CS_AS " + 
                        "LIKE '{0}' collate SQL_Latin1_General_CP1_CS_AS ";
      else
         sqlTemplate += "WHERE lower(name) LIKE lower('{0}') ";
         

      string searchString;
      if ( m_allowWildcards )
      {
         searchString = m_searchString;
      }
      else
      {
         searchString = String.Format( "%{0}%", SQLHelpers.EscapeWildcards(m_searchString) );
      }

      string sql = String.Format( sqlTemplate, searchString );   
      
      return sql;
   }
   
   
   //--------------------------------------------------------------------------   
   // ProcessReader_sysjobs
   //--------------------------------------------------------------------------   
   private void
      ProcessReader_sysjobs(
         SqlDataReader reader
      )
   {
      while ( reader.Read() )
      {
         SearchResult result = new SearchResult( m_server);
         
         result.name        = SQLHelpers.GetString( reader, 0 );
         result.showEnabled = true;
         result.enabled     = SQLHelpers.ByteToBool( reader, 1 );
         result.details     = "Description: " + SQLHelpers.GetString( reader, 2 );
         result.objectType  = "Job";
         result.iconIndex   = SearchHelper.IconType.Job;
         
         Form_Main.AddSearchResult( result );
      }
   }
   
   #endregion // sysjobs
   
   #endregion  // server level queries
   
   #region Database Level Queries
   
   #region sysallobjects
   
   //--------------------------------------------------------------------------   
   // GetSQL_sysobjects
   //--------------------------------------------------------------------------   
   private string GetSQL_sysobjects()
   {
      string sqlTemplate = "USE {0}; " +
                           "select ps.name,p.name,p.type," + 
                                  "s.name,o.name,o.type from sysobjects o " +
                           "INNER JOIN sysobjects p ON p.id = o.parent_obj " +
                           "INNER JOIN sysusers s  ON s.uid = o.uid " +
                           "INNER JOIN sysusers ps ON ps.uid = p.uid " +
                           "WHERE o.parent_obj <> 0 AND {1} " +
                           "UNION " +
                           "select null,null,null,s.name,o.name,o.type from sysobjects o " +
                           "INNER JOIN sysusers s ON o.uid = s.uid " +
                           "WHERE o.parent_obj = 0 AND {2}";
                           
      // case sensitive vs. case insensitive
      string nameMatch1 = "";
      string nameMatch2 = "";
      
      if ( m_caseSensitiveSearch ) 
         nameMatch1 = "o.name collate SQL_Latin1_General_CP1_CS_AS " + 
                      "LIKE '{0}' collate SQL_Latin1_General_CP1_CS_AS ";
      else
         nameMatch1 = "lower(o.name) LIKE lower('{0}') ";
         
      nameMatch2 = nameMatch1;   
  
      // search system objects
      if ( m_excludeSystemObjects )
      {
         nameMatch1 += " AND o.name<>'sys' AND o.xtype <> 'S' AND p.xtype <> 'S'"; 
         nameMatch2 += " AND o.name<>'sys' AND o.xtype <> 'S'"; 
      }
      
      string searchString;
      if ( m_allowWildcards )
      {
         searchString = String.Format( "{0}", m_searchString );
      }
      else
      {
         searchString = String.Format( "%{0}%", SQLHelpers.EscapeWildcards(m_searchString) );
      }

      string sql = String.Format( sqlTemplate,
                                  SQLHelpers.CreateSafeDatabaseName(m_database),
                                  String.Format( nameMatch1, searchString ),
                                  String.Format( nameMatch2, searchString ) );
      
      return sql;
   }
   
   //--------------------------------------------------------------------------   
   // ProcessReader_sysobjects
   //--------------------------------------------------------------------------   
   private void
      ProcessReader_sysobjects(
         SqlDataReader reader
      )
   {
      while ( reader.Read() )
      {
         SearchResult result = new SearchResult( m_server);
         
         result.database = m_database;

         result.parentName       = SQLHelpers.GetString( reader, 1 );
         if ( ! String.IsNullOrEmpty(result.parentName ) )
         {
            result.parentSchema     = SQLHelpers.GetString( reader, 0 );

            int ndx = GetTypeDesc( typedesc_sysobjects,
                                   SQLHelpers.GetString( reader, 2 ));
            result.parentObjectType = typedesc_sysobjects[ndx].displayString;
         }

         result.schema           = SQLHelpers.GetString( reader, 3 );
         result.name             = SQLHelpers.GetString( reader, 4 );

         int ndx2 = GetTypeDesc( typedesc_sysobjects,
                                 SQLHelpers.GetString( reader, 5 ));
         result.objectType = typedesc_sysobjects[ndx2].displayString;
         result.iconIndex  = typedesc_sysobjects[ndx2].icon;

         Form_Main.AddSearchResult( result );
      }
   }
   
   static SearchTypeDesc[] typedesc_sysobjects = new SearchTypeDesc []
   {  
      new SearchTypeDesc("C",  "CHECK constraint",                    SearchHelper.IconType.Constraint),
      new SearchTypeDesc("D",  "DEFAULT (constraint or stand-alone)", SearchHelper.IconType.Constraint),
      new SearchTypeDesc("F",  "FOREIGN KEY constraint",              SearchHelper.IconType.Constraint),
      new SearchTypeDesc("L",  "Log",                                 SearchHelper.IconType.Log),
      new SearchTypeDesc("FN", "Scalar function",                     SearchHelper.IconType.Function),
      new SearchTypeDesc("IF", "SQL inlined table-valued function",   SearchHelper.IconType.Function),
      new SearchTypeDesc("P",  "Stored procedure",                    SearchHelper.IconType.StoredProcedure),
      new SearchTypeDesc("PK", "PRIMARY KEY constraint",              SearchHelper.IconType.Constraint),
      new SearchTypeDesc("RF", "Replication filter procedure",        SearchHelper.IconType.StoredProcedure),
      new SearchTypeDesc("S",  "System table",                        SearchHelper.IconType.Table),
      new SearchTypeDesc("TF", "Table function",                      SearchHelper.IconType.Function),
      new SearchTypeDesc("TR", "Trigger ",                            SearchHelper.IconType.Trigger),
      new SearchTypeDesc("U",  "Table",                               SearchHelper.IconType.Table),
      new SearchTypeDesc("UQ", "UNIQUE constraint",                   SearchHelper.IconType.Constraint),
      new SearchTypeDesc("V",  "View",                                SearchHelper.IconType.View),
      new SearchTypeDesc("X", "Extended stored procedure",            SearchHelper.IconType.StoredProcedure),
   };
      
   #endregion // sysobjects

   #region syslogins
  
   //--------------------------------------------------------------------------   
   // GetSQL_syslogins
   //--------------------------------------------------------------------------   
   private string GetSQL_syslogins()
   {
      string sqlTemplate = "USE {0}; " +
                           "SELECT name,isntname,isntgroup FROM {1} ";

      if ( m_caseSensitiveSearch ) 
         sqlTemplate += "WHERE name collate SQL_Latin1_General_CP1_CS_AS " + 
                        "LIKE '{2}' collate SQL_Latin1_General_CP1_CS_AS ";
      else
         sqlTemplate += "WHERE lower(name) LIKE lower('{2}') ";
         
      string searchString;
      if ( m_allowWildcards )
      {
         searchString = m_searchString;
      }
      else
      {
         searchString = String.Format( "%{0}%", SQLHelpers.EscapeWildcards(m_searchString) );
      }

      string sql = String.Format( sqlTemplate,
                                  SQLHelpers.CreateSafeDatabaseName(m_database),
                                  (m_database == "master") ? "syslogins" : "sysusers",
                                  searchString );   
      
      return sql;
   }           
   
   //--------------------------------------------------------------------------   
   // ProcessReader_syslogins
   //--------------------------------------------------------------------------   
   private void
      ProcessReader_syslogins(
         SqlDataReader reader
      )
   {
      while ( reader.Read() )
      {
         SearchResult result = new SearchResult( m_server);
         
         result.name        = SQLHelpers.GetString( reader, 0 );
         
         bool isntname  = (SQLHelpers.GetInt32(reader, 1) != 0);
         bool isntgroup = (SQLHelpers.GetInt32(reader, 2) != 0);
         
         if ( isntname )
         {
            if ( isntgroup )
            {
               result.objectType = "Windows Group";
               result.iconIndex  = SearchHelper.IconType.WindowsGroup;
            }
            else
            {
               result.objectType = "Windows User";
               result.iconIndex  = SearchHelper.IconType.WindowsUser;
            }
         }
         else
         {
            result.objectType = "SQL Login";
            result.iconIndex  = SearchHelper.IconType.SqlUser;
         }
         
         if ( m_database != "master" )
         {
            result.database = m_database;
         }
         
         Form_Main.AddSearchResult( result );
      }
   }
   
   #endregion // syslogins

   #region syscolumns
  
   //--------------------------------------------------------------------------   
   // GetSQL_syscolumns
   //--------------------------------------------------------------------------   
   private string GetSQL_syscolumns()
   {
      string sqlTemplate = "USE {0}; " +
                           "SELECT p.name as 'parent', p.xtype as 'parenttype', s.name as 'schema', c.name from syscolumns c " +
                           "INNER JOIN sysobjects p ON c.id = p.id " +
                           "INNER JOIN sysusers s ON p.uid = s.uid ";

      // case sensitive vs. case insensitive
      if ( m_caseSensitiveSearch ) 
         sqlTemplate += "WHERE c.name collate SQL_Latin1_General_CP1_CS_AS " + 
                        "LIKE '{1}' collate SQL_Latin1_General_CP1_CS_AS ";
      else
         sqlTemplate += "WHERE lower(c.name) LIKE lower('{1}') ";

      // search system objects
      if ( m_excludeSystemObjects )
      {
         sqlTemplate += " AND s.name<>'sys'";
      }
      
      string searchString;
      if ( m_allowWildcards )
      {
         searchString = m_searchString;
      }
      else
      {
         searchString = String.Format( "%{0}%", SQLHelpers.EscapeWildcards(m_searchString) );
      }
      
      string sql = String.Format( sqlTemplate,
                                  SQLHelpers.CreateSafeDatabaseName(m_database),
                                  searchString );
      
      return sql;
   }
   
   //--------------------------------------------------------------------------   
   // ProcessReader_syscolumns
   //--------------------------------------------------------------------------   
   private void
      ProcessReader_syscolumns(
         SqlDataReader reader
      )
   {
      while ( reader.Read() )
      {
         SearchResult result = new SearchResult( m_server);
         
         result.database = m_database;

         result.parentName       = SQLHelpers.GetString( reader, 0 );

         int ndx = GetTypeDesc( typedesc_sysobjects,
                                SQLHelpers.GetString( reader, 1 ));
         result.parentObjectType = typedesc_sysobjects[ndx].displayString;

         result.schema           = SQLHelpers.GetString( reader, 2 );
         result.name             = SQLHelpers.GetString( reader, 3 );
         result.objectType       = "Column";
         result.iconIndex        = SearchHelper.IconType.Column;
         
         Form_Main.AddSearchResult( result );
      }
   }
  
   #endregion // syscolumns
   

   #region sysindexes
  
   //--------------------------------------------------------------------------   
   // GetSQL_sysindexes
   //--------------------------------------------------------------------------   
   private string GetSQL_sysindexes()
   {
      string sqlTemplate = "USE {0}; " +
                           "SELECT p.name as 'parent', p.type as 'parentType', s.name as 'schema', " +
                               " i.name  from sysindexes i " +
                           "INNER JOIN sysobjects p ON i.id = p.id " +
                           "INNER JOIN sysusers s ON p.uid = s.uid ";

      // case sensitive vs. case insensitive
      if ( m_caseSensitiveSearch ) 
         sqlTemplate += "WHERE i.name collate SQL_Latin1_General_CP1_CS_AS " + 
                        "LIKE '{1}' collate SQL_Latin1_General_CP1_CS_AS ";
      else
         sqlTemplate += "WHERE lower(i.name) LIKE lower('{1}') ";

      // search system objects
      if ( m_excludeSystemObjects )
      {
          sqlTemplate += " AND s.name<>'sys'";
      }
      
      string searchString;
      if ( m_allowWildcards )
      {
         searchString = m_searchString;
      }
      else
      {
         searchString = String.Format( "%{0}%", SQLHelpers.EscapeWildcards(m_searchString) );
      }
      
      string sql = String.Format( sqlTemplate,
                                  SQLHelpers.CreateSafeDatabaseName(m_database),
                                  searchString );
      
      return sql;
   }
   
   //--------------------------------------------------------------------------   
   // ProcessReader_sysindexes
   //--------------------------------------------------------------------------   
   private void
      ProcessReader_sysindexes(
         SqlDataReader reader
      )
   {
      while ( reader.Read() )
      {
         SearchResult result = new SearchResult( m_server);
         
         result.database = m_database;

         result.parentName       = SQLHelpers.GetString( reader, 0 );

         int ndx = GetTypeDesc( typedesc_sysobjects,
                                SQLHelpers.GetString( reader, 1 ));
         result.parentObjectType = typedesc_sysobjects[ndx].displayString;

         result.schema           = SQLHelpers.GetString( reader, 2 );
         result.name             = SQLHelpers.GetString( reader, 3 );
         result.objectType       = "Index";
         result.iconIndex        = SearchHelper.IconType.Index;
         
         Form_Main.AddSearchResult( result );
      }
   }
  
   #endregion // sysindexes

   
   #endregion   
   }
}
