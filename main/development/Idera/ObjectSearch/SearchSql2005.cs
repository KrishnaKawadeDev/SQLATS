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

public class SearchSql2005
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
   
   public SearchSql2005(
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
            
         DoQuery( "Server Principals", GetSQL_sysserverprincipals,   ProcessReader_sysserverprincipals );
         if ( ProductConstants.operationCancelled || ProductConstants.searchLimitReached) return;
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
      
      bool saveCaseSensitiveSearch = m_caseSensitiveSearch;

      // walk the databases               
      foreach ( DatabaseObject db in databases )
      {
      if ( ProductConstants.operationCancelled || ProductConstants.searchLimitReached) return;
         
         // should we process this database?
         if ( ! SearchHelper.IsDatabaseInDatabaseList( db.name, m_databaseList ) ) continue;
        
         if ( db.compatabilityLevel < 70 )
         {
           m_ShowInfomationDelegate( String.Format( "Skipping database '{0}' on server '{1}'. Object Search does not support databases whose compatability level is set to a version prior to SQL Server 7.0.",
                                                     db.name,
                                                     m_server ) );
           Application.DoEvents();
           continue;
        }
        
         if ( db.compatabilityLevel == 70 )
         {
            // turn off case sensitive to avoid COLLATE keyword - turn back on after query on this databases
            m_caseSensitiveSearch = false;
         }
        
         // do the database query
         m_database = db.name;
                  
         DoQuery( String.Format( "Objects in Database {0}", db.name ),
                  GetSQL_sysallobjects,         ProcessReader_sysallobjects );
         if ( ProductConstants.operationCancelled || ProductConstants.searchLimitReached) return;
         
         DoQuery( String.Format( "Columns in Database {0}", db.name ),
                  GetSQL_syscolumns,            ProcessReader_syscolumns );
         if ( ProductConstants.operationCancelled || ProductConstants.searchLimitReached) return;
          
         DoQuery( String.Format( "Database Principals in Database {0}", db.name ),
                  GetSQL_sysdatabaseprincipals, ProcessReader_sysdatabaseprincipals );
         if ( ProductConstants.operationCancelled || ProductConstants.searchLimitReached) return;
         
         DoQuery( String.Format( "Indexes in Database {0}", db.name ),
                  GetSQL_sysindexes,            ProcessReader_sysindexes );
         if ( ProductConstants.operationCancelled || ProductConstants.searchLimitReached) return;
         
         DoQuery( String.Format( "Triggers in Database {0}", db.name ),
                                 GetSQL_systriggers,           ProcessReader_systriggers );
         if ( ProductConstants.operationCancelled || ProductConstants.searchLimitReached) return;
         
         // turn off case sensitive to avoid COLLATE keyword - turn back on after query on this databases
         m_caseSensitiveSearch = saveCaseSensitiveSearch;
      }
   }
   
   private void
      DoQuery(
         string                queryType,
         GetSQLDelegate        getSqlHandler,
         ProcessReaderDelegate rowHandler
      )
   {
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
      }
      catch ( SqlException sqlEx )
      {
         CoreGlobals.traceLog.ErrorFormat( "2005: Error in {0} - {1}", getSqlHandler.ToString(), sqlEx.Message );                                   
         
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

         CoreGlobals.traceLog.ErrorFormat( "2005: Error in {0} - {1}", getSqlHandler.ToString(), ex.Message );                                   
         
         throw new Exception( msg );
      }
      finally
      {
         Connection.CloseConnection(conn);
      }
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
      string sqlTemplate = "SELECT name,owner_sid from sys.databases "; 

      // case sensitive vs. case insensitive
      if ( m_caseSensitiveSearch ) 
      {
         sqlTemplate += "WHERE name collate SQL_Latin1_General_CP1_CS_AS " + 
                        "LIKE '{1}' collate SQL_Latin1_General_CP1_CS_AS ";
      }                       
      else
      {
         sqlTemplate += "WHERE lower(name) LIKE lower('{1}') ";
      }

      // search system objects
      if ( m_excludeSystemObjects )
      {
         sqlTemplate += " AND owner_sid<>1";
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
      
      string sql = String.Format( sqlTemplate, m_database, searchString );  
      
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
         
         sid = SQLHelpers.GetBinary(reader, 1);
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
   
   #region sysserverprincipals
  
   //--------------------------------------------------------------------------   
   // GetSQL_sysserverprincipals
   //--------------------------------------------------------------------------   
   private string GetSQL_sysserverprincipals()
   {
      string sqlTemplate = "SELECT name, type, is_disabled  from sys.server_principals ";

      if ( m_caseSensitiveSearch ) 
         sqlTemplate += "WHERE name collate SQL_Latin1_General_CP1_CS_AS " + 
                        "LIKE '{0}' collate SQL_Latin1_General_CP1_CS_AS ";
      else
         sqlTemplate += "WHERE lower(name) LIKE lower('{0}') ";
         
      // search system objects
      if ( m_excludeSystemObjects )
      {
         sqlTemplate += " AND type <> 'R'";
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
   // ProcessReader_sysserverprincipals
   //--------------------------------------------------------------------------   
   private void
      ProcessReader_sysserverprincipals(
         SqlDataReader reader
      )
   {
      while ( reader.Read() )
      {
         SearchResult result = new SearchResult( m_server);
         
         result.name        = SQLHelpers.GetString( reader, 0 );
         
         int ndx = GetTypeDesc( typedesc_sysserverprincipals,
                                SQLHelpers.GetString( reader, 1 ));
         result.objectType = typedesc_sysserverprincipals[ndx].displayString;
         result.iconIndex  = typedesc_sysserverprincipals[ndx].icon;
                                          
         result.showEnabled = true;
         result.enabled     = ! SQLHelpers.GetBool( reader, 2 );
      
         Form_Main.AddSearchResult( result );
      }
   }
   
   static SearchTypeDesc[] typedesc_sysserverprincipals = new SearchTypeDesc []
   {  
      new SearchTypeDesc("S","SQL login",                         SearchHelper.IconType.SqlUser),
      new SearchTypeDesc("U","Windows login",                     SearchHelper.IconType.WindowsUser),
      new SearchTypeDesc("G","Windows group",                     SearchHelper.IconType.WindowsGroup),
      new SearchTypeDesc("R","Server role",                       SearchHelper.IconType.Role),
      new SearchTypeDesc("C","Login mapped to a certificate",     SearchHelper.IconType.SqlUser),
      new SearchTypeDesc("K","Login mapped to an asymmetric key", SearchHelper.IconType.SqlUser)
   };
   
   #endregion // sysserverprincipals
   
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
         result.iconIndex = SearchHelper.IconType.Job;
         
         Form_Main.AddSearchResult( result );
      }
   }
   
   #endregion // sysjobs
   
   #endregion  // server level queries
   
   #region Database Level Queries
   
   #region sysallobjects
   
   //--------------------------------------------------------------------------   
   // GetSQL_sysallobjects
   //--------------------------------------------------------------------------   
   private string GetSQL_sysallobjects()
   {
      // query includes objects with and without parents
      string sqlTemplate = "USE {0}; " +
                           "select ps.name,p.name,p.type," + 
                                  "s.name,o.name,o.type from sys.all_objects o " +
                           "INNER JOIN sys.all_objects p ON p.object_id = o.parent_object_id " +
                           "INNER JOIN sys.schemas s  ON s.schema_id = o.schema_id " +
                           "INNER JOIN sys.schemas ps ON ps.schema_id = p.schema_id " +
                           "WHERE {1} " +
                           "UNION " +
                           "select null,null,null,s.name,o.name,o.type from sys.all_objects o " +
                           "INNER JOIN sys.schemas s ON o.schema_id = s.schema_id " +
                           "WHERE o.parent_object_id = 0 AND s.name<>'INFORMATION_SCHEMA' AND {2}";
   
      // name match
      // case sensitive vs. case insensitive
      string nameMatch1;
      string nameMatch2;
      if ( m_caseSensitiveSearch ) 
      {
         nameMatch1 = "o.name collate SQL_Latin1_General_CP1_CS_AS " + 
                      "LIKE '{0}' collate SQL_Latin1_General_CP1_CS_AS ";
         nameMatch2 = nameMatch1;
      }
      else
      {
         nameMatch1 = "lower(o.name) LIKE lower('{0}') ";
         nameMatch2 = nameMatch1;
      }
  
      // search system objects
      if ( m_excludeSystemObjects )
      {
         nameMatch1 += " AND s.name<>'sys' AND o.type <> 'S' AND p.type <> 'S'";
         nameMatch2 += " AND s.name<>'sys' AND o.type <> 'S'";
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
                                  String.Format( nameMatch1, searchString),
                                  String.Format( nameMatch2, searchString) );  
      
      return sql;
   }
   
   //--------------------------------------------------------------------------   
   // ProcessReader_sysallobjects
   //--------------------------------------------------------------------------   
   private void
      ProcessReader_sysallobjects(
         SqlDataReader reader
      )
   {
      while ( reader.Read() )
      {
         SearchResult result = new SearchResult( m_server);
         
         result.database = m_database;

         // parent object (if there is one)  
         result.parentName       = SQLHelpers.GetString( reader, 1 );
         if ( ! String.IsNullOrEmpty(result.parentName ) )
         {
            result.parentSchema     = SQLHelpers.GetString( reader, 0 );

            int ndx = GetTypeDesc( typedesc_sysallobjects,
                                  SQLHelpers.GetString( reader, 2 ));
            result.parentObjectType = typedesc_sysallobjects[ndx].displayString;
         }                                                   
         
         // main object
         result.schema = SQLHelpers.GetString( reader, 3 );
         result.name   = SQLHelpers.GetString( reader, 4 );
         int ndx2      = GetTypeDesc( typedesc_sysallobjects,
                                      SQLHelpers.GetString( reader, 5 ));
         result.objectType = typedesc_sysallobjects[ndx2].displayString;
         result.iconIndex  = typedesc_sysallobjects[ndx2].icon;
         
         Form_Main.AddSearchResult( result );
      }
   }
   
   static SearchTypeDesc[] typedesc_sysallobjects = new SearchTypeDesc[]
   {  
      new SearchTypeDesc("AF","Aggregate function (CLR)",             SearchHelper.IconType.Function),
      new SearchTypeDesc("C","CHECK constraint",                      SearchHelper.IconType.Constraint),
      new SearchTypeDesc("D","DEFAULT (constraint or stand-alone)",   SearchHelper.IconType.Constraint),
      new SearchTypeDesc("F","FOREIGN KEY constraint",                SearchHelper.IconType.Constraint),
      new SearchTypeDesc("PK","PRIMARY KEY constraint",               SearchHelper.IconType.Constraint),
      new SearchTypeDesc("P","SQL stored procedure",                  SearchHelper.IconType.StoredProcedure),
      new SearchTypeDesc("PC","Assembly (CLR) stored procedure",      SearchHelper.IconType.StoredProcedure),
      new SearchTypeDesc("FN","SQL scalar-function",                  SearchHelper.IconType.Function),
      new SearchTypeDesc("FS","Assembly (CLR) scalar function",       SearchHelper.IconType.Function),
      new SearchTypeDesc("FT","Assembly (CLR) table-valued function", SearchHelper.IconType.Function),
      new SearchTypeDesc("R","Rule",                                  SearchHelper.IconType.Unknown),
      new SearchTypeDesc("RF","Replication filter procedure",         SearchHelper.IconType.StoredProcedure),
      new SearchTypeDesc("S","System table",                          SearchHelper.IconType.Table),
      new SearchTypeDesc("SN","Synonym",                              SearchHelper.IconType.Unknown),
      new SearchTypeDesc("SQ","Service queue",                        SearchHelper.IconType.Unknown),
      new SearchTypeDesc("TA","Assembly (CLR) trigger",               SearchHelper.IconType.Trigger),
      new SearchTypeDesc("TR","DML trigger ",                         SearchHelper.IconType.Trigger),
      new SearchTypeDesc("IF","SQL inlined table-valued function",    SearchHelper.IconType.Function),
      new SearchTypeDesc("TF","SQL table-valued function",            SearchHelper.IconType.Function),
      new SearchTypeDesc("U","Table",                                 SearchHelper.IconType.Table),
      new SearchTypeDesc("UQ","UNIQUE constraint",                    SearchHelper.IconType.Constraint),
      new SearchTypeDesc("V","View",                                  SearchHelper.IconType.View),
      new SearchTypeDesc("X","Extended stored procedure",             SearchHelper.IconType.StoredProcedure),
      new SearchTypeDesc("IT","Internal table",                       SearchHelper.IconType.Table)
   };
   
   
   #endregion // sysallobjects

   #region syscolumns
  
   //--------------------------------------------------------------------------   
   // GetSQL_syscolumns
   //--------------------------------------------------------------------------   
   private string GetSQL_syscolumns()
   {
      string sqlTemplate = "USE {0}; " +
                           "SELECT p.name as 'parent', p.type as 'parenttype', s.name as 'schema', c.name  from sys.columns c " +
                           "INNER JOIN sys.all_objects p ON c.object_id = p.object_id " +
                           "INNER JOIN sys.schemas s ON p.schema_id = s.schema_id ";

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
         
         result.parentName = SQLHelpers.GetString( reader, 0 );
         int ndx           = GetTypeDesc( typedesc_sysallobjects, SQLHelpers.GetString( reader, 1 ) );
         result.parentObjectType = typedesc_sysallobjects[ndx].displayString;
         
         result.schema           = SQLHelpers.GetString( reader, 2 );
         result.name             = SQLHelpers.GetString( reader, 3 );
         
         result.objectType       = "Column";
         result.iconIndex        = SearchHelper.IconType.Column;
         
         Form_Main.AddSearchResult( result );
      }
   }
  
   #endregion // syscolumns
   
   #region sysdatabaseprincipals
   
   //--------------------------------------------------------------------------   
   // GetSQL_sysdatabaseprincipals
   //--------------------------------------------------------------------------   
   private string GetSQL_sysdatabaseprincipals()
   {
      string sqlTemplate = "USE {0}; " +
                           "SELECT default_schema_name, name, type  from sys.database_principals ";

      // case sensitive vs. case insensitive
      if ( m_caseSensitiveSearch ) 
         sqlTemplate += "WHERE name collate SQL_Latin1_General_CP1_CS_AS " + 
                        "LIKE '{1}' collate SQL_Latin1_General_CP1_CS_AS ";
      else
         sqlTemplate += "WHERE lower(name) LIKE lower('{1}') ";
         
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
   // ProcessReader_sysdatabaseprincipals
   //--------------------------------------------------------------------------   
   private void
      ProcessReader_sysdatabaseprincipals(
         SqlDataReader reader
      )
   {
      while ( reader.Read() )
      {
         SearchResult result = new SearchResult( m_server);

         result.database = m_database;
         
         result.schema     = SQLHelpers.GetString( reader, 0 );
         result.name       = SQLHelpers.GetString( reader, 1 );
         int ndx           = GetTypeDesc( typedesc_databaseprincipals,
                                          SQLHelpers.GetString( reader, 2 ));
         result.objectType = typedesc_databaseprincipals[ndx].displayString;
         result.iconIndex  = typedesc_databaseprincipals[ndx].icon;
                                           
         Form_Main.AddSearchResult( result );
      }
   }
   
   static SearchTypeDesc[] typedesc_databaseprincipals = new SearchTypeDesc []
   {  
      new SearchTypeDesc("S","SQL user",                          SearchHelper.IconType.SqlUser),
      new SearchTypeDesc("U","Windows user",                      SearchHelper.IconType.WindowsUser),
      new SearchTypeDesc("G","Windows group",                     SearchHelper.IconType.WindowsGroup),
      new SearchTypeDesc("A","Application role",                  SearchHelper.IconType.Role),
      new SearchTypeDesc("R","Database role",                     SearchHelper.IconType.Role),
      new SearchTypeDesc("C","User mapped to a certificate",     SearchHelper.IconType.SqlUser),
      new SearchTypeDesc("K","User mapped to an asymmetric key", SearchHelper.IconType.SqlUser)
   };
   
   #endregion // sysdatabaseprincipals

   #region sysindexes
  
   //--------------------------------------------------------------------------   
   // GetSQL_sysindexes
   //--------------------------------------------------------------------------   
   private string GetSQL_sysindexes()
   {
      string sqlTemplate = "USE {0}; " +
                           "SELECT p.name as 'parent', p.type as 'parentType', s.name as 'schema', " +
                               " i.name, i.type, i.is_disabled  from sys.indexes i " +
                           "INNER JOIN sys.all_objects p ON i.object_id = p.object_id " +
                           "INNER JOIN sys.schemas s ON p.schema_id = s.schema_id ";

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
         int ndx                 = GetTypeDesc( typedesc_sysallobjects, SQLHelpers.GetString( reader, 1 ) );
         result.parentObjectType = typedesc_sysallobjects[ndx].displayString;
         
         result.schema           = SQLHelpers.GetString( reader, 2 );
         result.name             = SQLHelpers.GetString( reader, 3 );
         
         int indexType           = SQLHelpers.ByteToInt(reader,4);
         result.objectType       = ( indexType == 0 ) ? "Heap Index" : 
                                   ( indexType == 1 ) ? "Clustered Index" : 
                                                        "Non-Clustered Index";
         result.iconIndex        = SearchHelper.IconType.Index;                                                        
                                                
         result.showEnabled      = true;
         result.enabled          = SQLHelpers.GetBool( reader, 5 );
         
         Form_Main.AddSearchResult( result );
      }
   }
  
   #endregion // sysindexes

   #region systriggers
  
   //--------------------------------------------------------------------------   
   // GetSQL_systriggers - only used for DLL triggers; DML triggers
   //                      come back in sys.allobjects
   //--------------------------------------------------------------------------   
   private string GetSQL_systriggers()
   {
      string sqlTemplate = "USE {0}; " + 
                           "SELECT name, type, is_disabled from sys.triggers " +
                           "WHERE parent_class=0 "; 

      // case sensitive vs. case insensitive
      if ( m_caseSensitiveSearch ) 
         sqlTemplate += "AND name collate SQL_Latin1_General_CP1_CS_AS " + 
                        "LIKE '{1}' collate SQL_Latin1_General_CP1_CS_AS ";
      else
         sqlTemplate += "AND lower(name) LIKE lower('{1}') ";
      
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
   // ProcessReader_systriggers
   //--------------------------------------------------------------------------   
   private void
      ProcessReader_systriggers(
         SqlDataReader reader
      )
   {
      while ( reader.Read() )
      {
         SearchResult result = new SearchResult( m_server);

         result.database = m_database;

         result.name             = SQLHelpers.GetString( reader, 0 );
         result.objectType       = "DDL Trigger";
         result.iconIndex        = SearchHelper.IconType.Trigger;
         result.showEnabled      = true;
         result.enabled          = SQLHelpers.GetBool( reader, 2 );
         
         Form_Main.AddSearchResult( result );
      }
   }
   
   #endregion // systriggers
   
   #endregion   
   }
}
