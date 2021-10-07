using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.TablePin
{
   #region PinResult

   class PinResult
   {
      public PinResult() { }

      public string database;
      public string owner;
      public string table;
      public bool   isPinned;
      public long   numRows;
      public long   estimatedSize;

      public int    databaseId;
      public int    tableId;
      
      public string DisplayMember { get { return database; } }
      override public string ToString() { return database; }
   }

   public static class PinCounts
   {
      static public int databases = 0;
      static public int tables    = 0;
      static public int pinnedDatabase = 0;
      static public int pinnedTables = 0;
      static public long totalRows = 0;
      static public long totalSize = 0;

      public static void ResetCounts()
      {
         databases = 0;
         tables = 0;
         pinnedDatabase = 0;
         pinnedTables = 0;
         totalRows = 0;
         totalSize = 0;
      }
   }

   #endregion


   #region SQLRoutines

   class SqlRoutines
   {
      public static IList
         GetPinnedTables(
            string         server,
            SQLCredentials sqlCredentials,
            bool           hideUnpinnedTables,
            out bool       not2000orLower
          )
      {
         IList resultList = null;
         ICollection databases = null;
         SqlConnection conn = null;

         PinCounts.ResetCounts();

         try
         {
            conn = Connection.OpenConnection( server, sqlCredentials );

            if ( SQLHelpers.Is2005orGreater(conn))
            {
               not2000orLower = true;
               return resultList;
            }
            not2000orLower = false;

            databases = SQLObjects.GetUserDatabases(conn);

            string cmdstr;

            cmdstr = "USE {0}; " +
                     "SELECT Objects.[name] as [Table Name], " +
                            "Objects.[id] as [Table Id], " +
                            "Users.[name] as [Owner], " +
                          "OBJECTPROPERTY(Objects.[id], 'TableIsPinned') as Pinned,  " +
                          "SUM (CASE WHEN Indexes.indid = 0 or Indexes.indid = 1 " +
                               "THEN Indexes.[rows] ELSE 0 END) as [Rows], " +
                          "CAST((SUM (CASE WHEN  Indexes.indid = 0 or Indexes.indid = 1 " +
                               "THEN convert(dec(20,0),Indexes.[dpages])  " +
                               "ELSE 0 END)) as Numeric (18,0)) as [Size] " +
                       "FROM (SELECT [name], [id], uid, refdate, schema_ver " +
                                 "FROM sysobjects  " +
                                 "WHERE xtype = 'U' " +
                            ") Objects " +
                           "INNER JOIN sysusers Users " +
                                "ON Objects.uid = Users.uid " +
                           "LEFT OUTER JOIN sysindexes Indexes " +
                                "on Objects.id = Indexes.id " +
                       "GROUP BY Objects.[id], " +
                                "Objects.[uid], " +
                                "Objects.[name], " +
                                "Users.[name] " +
                       "ORDER BY Objects.[name]," +
                                "Users.[name]";

            //--------------------
            // result set columns
            //--------------------
            // 0 - table
            // 1 - tableId
            // 2 - owner
            // 3 - isPinned
            // 4 - rows
            // 5 - size

            resultList = new ArrayList();
            foreach ( DatabaseObject db in databases )
            {
               // skip dbs with compatability level < SQL Server 70 )
               if ( db.compatabilityLevel < 70 )
               {
                  Messaging.ShowInformation( String.Format( "Skipping database '{0}'. Table Pin does not support databases whose compatability level is set to a version prior to SQL Server 7.0.",
                                                            db.name ) );
                  Application.DoEvents();                                                                        
                  continue;
               }
            
               bool firstPinnedTable = true;
               PinCounts.databases++;

               string sql = String.Format( cmdstr, SQLHelpers.CreateSafeDatabaseName(db.name) );

               using ( SqlCommand cmd = new SqlCommand( sql, conn ) )
               {
                  cmd.CommandTimeout = ToolsetOptions.commandTimeout;
                  
                  try
                  {
                     using ( SqlDataReader reader = cmd.ExecuteReader() )
                     {
                        while ( reader.Read() )
                        {
                           PinCounts.tables++;

                           PinResult r = new PinResult();
                           r.isPinned = (reader.GetInt32( 3 ) == 0) ? false : true;

                           if (  r.isPinned || ! hideUnpinnedTables )
                           {

                              r.database      = db.name;
                              r.databaseId    = db.dbid;
                              r.table         = reader.GetString(0);
                              r.tableId       = reader.GetInt32(1);
                              r.owner         = reader.GetString(2);
                              // isPinned set earlier in code 
                              r.numRows       = reader.GetInt32(4);
                              r.estimatedSize = 8192 * (long)reader.GetDecimal(5);
                              resultList.Add( r );

                              // update counts
                              if ( r.isPinned )
                              {
                                 if ( firstPinnedTable )
                                 {
                                    PinCounts.pinnedDatabase++;
                                    firstPinnedTable = false;
                                 }
                                 PinCounts.pinnedTables++;

                                 PinCounts.totalRows += r.numRows;
                                 PinCounts.totalSize += r.estimatedSize;
                              }
                           }
                        }
                     }
                  }
                  catch( Exception ex )
                  {
                     Messaging.ShowException( "Unable to load information about pinned tables for database: " + db.name, ex, "Pin Table" );
                  }
               }
            }
         }
         catch ( Exception ex )
         {
            Messaging.ShowException( "Unable to load information about pinned tables.", ex, "Pin Table" );
            throw ex;
         }
         finally
         {
            Connection.CloseConnection(conn);
         }
         

         return resultList;
      }

      public static bool
         UnpinTable(
            string         server,
            PinResult      result,
            SQLCredentials sqlCredentials
        )
     {
        bool succeeded = false;
        SqlConnection conn = null;

        try
        {
            conn = Connection.OpenConnection( server, sqlCredentials );

            string sql = String.Format( "DBCC UNPINTABLE ({0},{1})",
                                        result.databaseId,
                                        result.tableId );

            using ( SqlCommand cmd = new SqlCommand( sql, conn ) )
            {
               cmd.CommandTimeout = ToolsetOptions.commandTimeout;
               cmd.ExecuteNonQuery();
               succeeded = true;
            }
         }
         catch ( Exception ex )
         {
            Messaging.ShowException( String.Format( "An error occurred trying to unpin the {0}.{1} table.",
                                                    result.owner,result.table ),
                                     ex,
                                     "Unpin Table" );
            succeeded = false;
         }
         finally
         {
            Connection.CloseConnection(conn);
         }
         
         return succeeded;
     }

      public static bool
         PinTable(
            string         server,
            PinResult      result,
            SQLCredentials sqlCredentials
        )
     {
        bool succeeded = false;
        SqlConnection conn = null;

        try
        {
           conn = Connection.OpenConnection( server, sqlCredentials );
           

            string sql = String.Format( "DBCC PINTABLE ({0},{1})",
                                        result.databaseId,
                                        result.tableId );

            using ( SqlCommand cmd = new SqlCommand( sql, conn ) )
            {
               cmd.CommandTimeout = ToolsetOptions.commandTimeout;
               cmd.ExecuteNonQuery();
               succeeded = true;
            }
         }
         catch ( Exception ex )
         {
            Messaging.ShowException( String.Format( "An error occurred trying to Pin the {0}.{1} table.",
                                                    result.owner,result.table ),
                                     ex,
                                     "Pin Table" );
            succeeded = false;
         }
         finally
         {
            Connection.CloseConnection(conn);
         }
         
         return succeeded;
     }
  }
  #endregion
}
