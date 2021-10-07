using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.BackupStatus
{
   #region BackupResult

   public class BackupResult
   {
      public BackupResult() {}
      
      public string   server;
      public string   database;
      public DateTime dateCreated;
      //public int      size;
      public bool     systemDatabase;

      public int      backupStatus; /* 0=Good;1=Backed up but not recently;2=Never Backed up */
      public DateTime lastBackup;
      public DateTime lastFullBackup;
      public string   backupType;
      public long     backupSize;
      public string   backupPath;
      public string   backupUser;
      public int      mirroringRole = 0;
      public string   dbstatus;
        public string RecoveryMode;
        public string   nodetype="";
      public string DisplayMember { get { return database; } }
      override public string ToString() { return database; }

      public int age
      {
         get
         {
            if ( dateCreated == null || dateCreated == DateTime.MinValue )
               return 0;
            else
            {
               TimeSpan ts = new TimeSpan( DateTime.Now.Ticks - dateCreated.Ticks );
               int nDays = ts.Days; //(int)Math.Ceiling(ts.TotalDays);
               return nDays;
            }
         }
      }

      public string databaseAge
      {
         get
         {
            if ( dateCreated == null || dateCreated == DateTime.MinValue )
               return "Unknown";
            else
            {
               TimeSpan ts = new TimeSpan( DateTime.Now.Ticks - dateCreated.Ticks );
               int daysOld = (int)Math.Ceiling(ts.TotalDays);
               
               if ( daysOld < 1 )
                  return "< 1 day";
               else if ( daysOld == 1 )
                  return "1 day";
               else
                  return daysOld + " days";
            }
         }
      }
   }
   
   public class BackupResultTable
   {
      public DataTable dataTable;
      
      public BackupResultTable( DataTable inDataTable )
      {
         dataTable = inDataTable;
      }
      
      public BackupResultTable()
      {
         dataTable = new DataTable("BackupResultTable");

            dataTable.Columns.Add(new DataColumn("Server", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Database", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Node", typeof(string)));
            dataTable.Columns.Add(new DataColumn("DateCreated", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("SystemDatabase", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("BackupStatus", typeof(int)));
            dataTable.Columns.Add(new DataColumn("LastBackup", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("LastFullBackup", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("BackupType", typeof(string)));
            dataTable.Columns.Add(new DataColumn("BackupSize", typeof(long)));
            dataTable.Columns.Add(new DataColumn("BackupPath", typeof(string)));
            dataTable.Columns.Add(new DataColumn("BackupUser", typeof(string)));
            dataTable.Columns.Add(new DataColumn("MirroringRole", typeof(int)));
            dataTable.Columns.Add(new DataColumn("RecoveryMode", typeof(string)));
        }
      
      public void
         AddRow(
            BackupResult br
         )   
      {
         DataRow _DataRow = dataTable.NewRow();

         _DataRow[ "Server" ]        = br.server;
         _DataRow[ "Database" ]      = br.database;
         _DataRow[ "Node" ]          = br.nodetype;
         _DataRow[ "DateCreated" ]   = br.dateCreated;
         _DataRow[ "SystemDatabase"] = br.systemDatabase;
         _DataRow[ "BackupStatus"]   = br.backupStatus;
         _DataRow[ "LastBackup" ]    = br.lastBackup;
         _DataRow[ "LastFullBackup"] = br.lastFullBackup;
         _DataRow[ "BackupType"]     = br.backupType;
         _DataRow[ "BackupSize" ]    = br.backupSize;
         _DataRow[ "BackupPath"]     = br.backupPath;
         _DataRow[ "BackupUser"]     = br.backupUser;
         _DataRow[ "MirroringRole"]  = br.mirroringRole;
         _DataRow["RecoveryMode"] = br.RecoveryMode.Substring(0, 1).ToUpper() + br.RecoveryMode.Substring(1).ToLower(); //br.RecoveryMode;

            dataTable.Rows.Add(_DataRow);
     }
     
     public BackupResult
        GetRow(
           int index
        )
     {
         BackupResult backupResult = null;
         
         try
         {
             backupResult = new BackupResult();
             
             backupResult.server          = SQLHelpers.GetRowString(dataTable.Rows[index],"Server");
             backupResult.database        = SQLHelpers.GetRowString(dataTable.Rows[index],"Database");
             backupResult.nodetype        = SQLHelpers.GetRowString(dataTable.Rows[index],"Node");
             backupResult.dateCreated     = SQLHelpers.GetRowDateTime(dataTable.Rows[index],"DateCreated");
             backupResult.systemDatabase  = SQLHelpers.GetRowBool(dataTable.Rows[index],"SystemDatabase");
             backupResult.backupStatus    = SQLHelpers.GetRowInt32(dataTable.Rows[index],"BackupStatus");
             backupResult.lastBackup      = SQLHelpers.GetRowDateTime(dataTable.Rows[index],"LastBackup");
             backupResult.lastFullBackup  = SQLHelpers.GetRowDateTime(dataTable.Rows[index],"LastFullBackup");
             backupResult.backupType      = SQLHelpers.GetRowString(dataTable.Rows[index],"BackupType");
             backupResult.backupSize      = SQLHelpers.GetRowLong(dataTable.Rows[index],"BackupSize");
             backupResult.backupPath      = SQLHelpers.GetRowString(dataTable.Rows[index],"BackupPath");
             backupResult.backupUser      = SQLHelpers.GetRowString(dataTable.Rows[index],"BackupUser");
             backupResult.mirroringRole   = SQLHelpers.GetRowInt32(dataTable.Rows[index],"MirroringRole");
             backupResult.RecoveryMode= SQLHelpers.GetRowString(dataTable.Rows[index], "RecoveryMode"); 
            }
          catch ( Exception ex )
          {
             throw new ArgumentException("The Data Table was not valid.", "LoadFromDataTable", ex);
          }
          
          return backupResult;
     }
     
     public void 
        SetLastFullBackup(
           int      index,
           DateTime lastFullBackup
        )
     {
        dataTable.Rows[index]["LastFullBackup"] = lastFullBackup;
     }
   }

   public static class BackupCounts
   {
      static public int userDatabases = 0;
      static public int totalDatabases = 0;
      static public int systemDatabases = 0;
      static public int databasesWithNoBackup = 0;
      static public int databasesWithNoRecentBackup = 0;
      static public int backupRecords = 0;
      static public int newDatabases = 0;
      static public int matchingDatabases = 0;
      static public int serversScanned = 0;
      static public int serversNeedingBackups = 0;

      public static void ResetCounts()
      {
         userDatabases = 0;
         totalDatabases = 0;
         systemDatabases = 0;
         databasesWithNoBackup = 0;
         databasesWithNoRecentBackup = 0;
         backupRecords = 0;
         newDatabases = 0;
         matchingDatabases = 0;
         serversScanned = 0;
         serversNeedingBackups = 0;
      }
   }

   #endregion

   #region Backup Routines

   class BackupRoutines
   {
      #region LoadBackupStatus
      
      static public bool   IncludeOnlyFullBackups      = false;
      static public bool   ExcludeDatabasesWithABackup = false;
      static public bool   ExcludeOldDatabases         = false;
      static public bool   ExcludeSystemDatabases      = false;
      static public bool   ExcludeOfflineDatabases     = false;
      static public int    NumberOfDaysForRecent       = 7;
      static public int    NumberOfDaysForOld          = 90;
        private static object threadLock = new object();

        public static DataTable
         LoadBackupStatus(
            ServerInformation serverInformation,
            int               commandTimeout,
            JobPoolOptions    options
          )
      {
            BackupResultTable backupResultTable = new BackupResultTable();
            lock (threadLock)
            {
                SqlConnection conn = null;
                bool is2005orGreater = true;

                try
                {
                    List<string> AgDbs = new List<string>();
                    conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials);

                    is2005orGreater = SQLHelpers.Is2005orGreater(conn);
                    string group_id = "";
                    string cmdst = "SELECT distinct group_id FROM master.sys.availability_replicas";
                    if (SQLHelpers.Is2012orGreater(conn))
                    {
                        using (SqlCommand cmd = new SqlCommand(cmdst, conn))
                        {

                            using (var r = cmd.ExecuteReader())
                            {
                                while (r.Read())
                                {
                                    group_id += "'" + r.GetValue(0) + "',";
                                }
                            }
                            if (group_id.Length > 0)
                                group_id = group_id.Remove(group_id.Length - 1);
                            //  group_id = Convert.ToString(cmd.ExecuteScalar());

                        }
                    }
                    if (group_id != "")
                    {
                        cmdst = string.Format("select distinct agrcs.database_name from  master.sys.availability_replicas agr  " +
                                 "LEFT OUTER JOIN master.sys.dm_hadr_availability_replica_states agrs ON agr.replica_id = agrs.replica_id" +
                            " INNER JOIN master.sys.dm_hadr_database_replica_cluster_states agrcs ON agrs.replica_id = agrcs.replica_id where agr.group_id in ({0})", group_id);
                        using (SqlCommand cmd = new SqlCommand(cmdst, conn))
                        {
                            using (var r = cmd.ExecuteReader())
                            {
                                while (r.Read())
                                {
                                    AgDbs.Add(r.GetString(0));
                                }
                            }
                        }
                    }
                    string cmdstr;

                    cmdstr = "SELECT db.name AS [Database], crdate AS [CreateDate],backup_finish_date, type, backup_size, (DATABASEPROPERTYEX(db.name, 'status')) AS [Status], db.sid{0}{2},d.recovery_model_desc as Recovery_Mode " +
                            "FROM [master].[dbo].[sysdatabases] db  " +
                            "{3}" +
                            "{1} " +
                            "LEFT OUTER JOIN [msdb].[dbo].[backupset] bs   " +
                            "ON bs.database_name = db.name  "
                            ;
                    string role = string.Empty;
                    string join = string.Empty;
                    string condition = " WHERE ";
                    string orderby = string.Empty;
                    if (group_id != "" && ProductConstants.optionIncludeAllNodes)
                    {
                        orderby = " role ASC,";
                        role = ",role,agr.replica_server_name";
                        join = string.Format("INNER JOIN   master.sys.availability_replicas agr ON agr.group_id in ({0})" +
           " LEFT OUTER JOIN master.sys.dm_hadr_availability_replica_states agrs ON agr.replica_id = agrs.replica_id" +
            " INNER JOIN master.sys.dm_hadr_database_replica_cluster_states agrcs ON agrs.replica_id = agrcs.replica_id " +
            " INNER JOIN master.sys.availability_group_listeners agl ON agl.group_id = agr.group_id ", group_id);
                        //condition = " WHERE agrs.is_local = 1  and agrcs.database_name =d.name and ";
                    }
                    if (IncludeOnlyFullBackups)
                    {
                        cmdstr += "{4} COALESCE( type, 'D' ) = 'D' ";

                    }

                    cmdstr += " GROUP BY [Status],db.name,db.crdate,d.recovery_model_desc, backup_finish_date, type, backup_size, db.sid{0}{2} " +
                              "ORDER BY" + orderby + " db.name ASC, backup_finish_date DESC";

                    // if 2005 - check for mirrors
                    if (is2005orGreater)
                    {
                        cmdstr = String.Format(cmdstr,
                                                ",m.mirroring_role",
                                                "INNER JOIN sys.databases d on db.dbid=d.database_id INNER JOIN sys.database_mirroring m on db.dbid=m.database_id", role, join, condition);

                    }
                    else
                    {
                        cmdstr = String.Format(cmdstr, "", "", role, join, condition); // no mirroring
                    }

                    //--------------------
                    // result set columns
                    //--------------------
                    // 0 - database
                    // 1 - creation date
                    // 2 - backup finish date
                    // 3 - backup type
                    // 4 - backup_size
                    // 5 - Status
                    // 6 - sid
                    // 7 - mirroring_role (2005 or greater)
                    string lastDatabase = "";
                    bool firstBackupRecord = true;
                    bool firstFullBackupRecord = true;
                    int databaseIndex = -1;
                    bool isSystemDatabase = false;
                    string lastserver = "";
                    var serverdb = new List<string[]>();
                    using (SqlCommand cmd = new SqlCommand(cmdstr, conn))
                    {
                        cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            bool firstRecordWithBackupNeeded = true;
                            if (group_id == "" || !ProductConstants.optionIncludeAllNodes)
                            {
                                BackupCounts.serversScanned++;
                            }
                            string server_name = string.Empty;
                            List<string> serversneedbackup = new List<string>();
                            List<string> serverscanned = new List<string>();
                            int recoverymodeindex = reader.GetOrdinal("Recovery_Mode");
                            while (reader.Read())
                            {
                                BackupCounts.backupRecords++;

                                BackupResult br = new BackupResult();
                                br.server = serverInformation.Name;
                                br.database = reader.GetString(0);
                                br.RecoveryMode= reader.GetString(recoverymodeindex);
                                br.dbstatus = reader.GetString(5);
                                // get database sid - used to determine if system database                           
                                byte[] sid = null;
                                int len = (int)reader.GetBytes(6, 0, null, 0, 0);
                                if (len > 0)
                                {
                                    sid = new byte[len];
                                    reader.GetBytes(6, 0, sid, 0, len);
                                }
                                isSystemDatabase = SQLHelpers.IsSystemDatabase(br.database);
                                int node = 0;
                                if (group_id != "" && ProductConstants.optionIncludeAllNodes)
                                {
                                    node = SQLHelpers.ByteToInt(reader, 8);
                                    server_name = reader.GetString(9);

                                    if (AgDbs.Contains(br.database))
                                        br.nodetype = node == 1 ? "Primary" : "Secondary";
                                    else
                                        br.server = server_name;
                                    if (!serverscanned.Contains(server_name))
                                    {
                                        serverscanned.Add(server_name);
                                        BackupCounts.serversScanned++;
                                    }
                                }
                                bool Exist = false;
                                if (AgDbs.Contains(br.database))
                                    Exist = serverdb.Exists(s => s[0] == server_name && s[1] == br.database);
                                else
                                    Exist = serverdb.Exists(s => s[1] == br.database);
                                if ((group_id != "" && ProductConstants.optionIncludeAllNodes && !Exist) || (!Exist && br.database != lastDatabase))
                                {
                                    BackupCounts.totalDatabases++;

                                    firstBackupRecord = true;
                                    firstFullBackupRecord = true;
                                    databaseIndex = -1;
                                    lastDatabase = br.database;
                                    serverdb.Add(new string[] { server_name, br.database });
                                    br.systemDatabase = isSystemDatabase;
                                    br.dateCreated = SQLHelpers.GetDateTime(reader, 1);
                                }

                                // check if this database is a mirror - if yes then backupstatus is OK
                                if (is2005orGreater)
                                {
                                    br.mirroringRole = SQLHelpers.ByteToInt(reader, 7);
                                }

                                if (reader.IsDBNull(2))
                                {
                                    // lastBackup==NULL means no backups for this database
                                    br.lastBackup = DateTime.MinValue;
                                    br.lastFullBackup = DateTime.MinValue;
                                    br.backupType = "";
                                    br.backupSize = -1;

                                    if (br.mirroringRole != 2)
                                        br.backupStatus = 2;
                                    else
                                        br.backupStatus = 0; // backup status always OK for mirrors
                                }
                                else
                                {
                                    // processing database record
                                    //    ony care about first database record and first full backup
                                    string backupType = reader.GetString(3);

                                    if (firstBackupRecord)
                                    {
                                        br.lastBackup = reader.GetDateTime(2);

                                        if (br.mirroringRole != 2)
                                            br.backupStatus = GetBackupStatus(br, NumberOfDaysForRecent);
                                        else
                                            br.backupStatus = 0; // backup status always OK for mirrors

                                        br.backupSize = (long)reader.GetDecimal(4);
                                        br.backupType = GetBackupType(backupType);
                                    }

                                    if (firstFullBackupRecord && backupType == "D")
                                    {
                                        firstFullBackupRecord = false;
                                        if (databaseIndex != -1)
                                        {
                                            backupResultTable.SetLastFullBackup(databaseIndex, reader.GetDateTime(2));
                                        }
                                        else
                                        {
                                            br.lastFullBackup = reader.GetDateTime(2);
                                        }
                                    }
                                }

                                bool exclude = (ExcludeDatabasesWithABackup && (br.backupStatus == 0)) ||
                                               (ExcludeOldDatabases && br.age > NumberOfDaysForOld) ||
                                               (ExcludeSystemDatabases && br.systemDatabase) ||
                                               //(br.systemDatabase && br.database.ToLower() == "tempdb") ||
                                               (ExcludeOfflineDatabases && br.dbstatus.ToLower() == "offline");
                                if (firstBackupRecord && !exclude)
                                {
                                    BackupCounts.matchingDatabases++;

                                    databaseIndex = backupResultTable.dataTable.Rows.Count;
									if (br.database != "tempdb")   //CGVAK - Skip the tempdb while backup
									{
										backupResultTable.AddRow(br);
									}

                                    // update counts
                                    if (br.backupStatus == 1) BackupCounts.databasesWithNoRecentBackup++;
                                    if (br.backupStatus == 2) BackupCounts.databasesWithNoBackup++;
                                    if (ProductConstants.optionIncludeAllNodes && group_id != "")
                                    {
                                        if (!serversneedbackup.Contains(server_name) && (br.backupStatus == 1 || br.backupStatus == 2))
                                        {
                                            serversneedbackup.Add(server_name);
                                            BackupCounts.serversNeedingBackups++;
                                        }

                                    }
                                    else
                                    {
                                        if (firstRecordWithBackupNeeded && (br.backupStatus == 1 || br.backupStatus == 2))
                                        {
                                            firstRecordWithBackupNeeded = false;
                                            BackupCounts.serversNeedingBackups++;
                                        }
                                    }
                                    if (br.systemDatabase)
                                        BackupCounts.systemDatabases++;
                                    else
                                        BackupCounts.userDatabases++;

                                    if (br.age < 30) BackupCounts.newDatabases++;
                                }

                                if (firstBackupRecord) firstBackupRecord = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string msg = String.Format("Unable to load backup history. Error: {0}", Helpers.GetCombinedExceptionText(ex));
                    throw new Exception(msg);
                }
                finally
                {
                    Connection.CloseConnection(conn);
                }
            }
            return backupResultTable.dataTable;
      }

    #endregion

      #region LoadBackupHistory

      public static IList
         LoadBackupHistory(
            string         server,
            SQLCredentials sqlCredentials,
            string         database,
            bool           limitResults
          )
      {
            IList       resultList   = null;
            SqlConnection conn = null;

            try
            {
               conn = Connection.OpenConnection(server, sqlCredentials);

               string cmdstr = "SELECT {0} bs.backup_finish_date, bs.type, bs.backup_size, bs.user_name, f.physical_device_name " +
                               "FROM [msdb].[dbo].[backupset] bs, [msdb].[dbo].[backupmediafamily] as f " +
                               "WHERE f.media_set_id = bs.media_set_id and bs.database_name={1} " +
                               "ORDER BY bs.backup_finish_date DESC";

               resultList = new ArrayList();


               cmdstr = String.Format( cmdstr,
                                       (limitResults) ? "TOP 500" : "",
                                       SQLHelpers.CreateSafeString( database.Split('(')[0].Trim() ) );

               using ( SqlCommand cmd = new SqlCommand( cmdstr, conn ) )
               {
                  cmd.CommandTimeout = ToolsetOptions.commandTimeout;
 
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           BackupResult br  = new BackupResult();
                           br.lastBackup    = reader.GetDateTime( 0 );
                           br.backupType    = GetBackupType(reader.GetString( 1 ));
                           br.backupSize    = (long)reader.GetDecimal(2);
                           br.backupUser    = reader.GetString( 3 );
                           br.backupPath    = reader.GetString( 4 );
                           resultList.Add( br );
                        }
                    }
                }
            }
            catch (Exception ex )
            {
               Messaging.ShowException( String.Format( "An error occurred loading the backup history for {0}.",
                                                       database ),
                                        ex,
                                        "Backup Status" );
               throw ex;
            }
            finally
            {
               Connection.CloseConnection(conn);
            }
            
            return resultList;
      }

      #endregion

      #region Miscellaneous Routines

      static public string
         GetBackupType(
            string shortType
         )
      {
         if ( shortType == "D" ) return "Full";
         else if ( shortType == "I" ) return "Differential";
         else if ( shortType == "L" ) return "Log";
         else if ( shortType == "F" ) return "File";
         else if ( shortType == "G" ) return "Differential";
         else if ( shortType == "P" ) return "Partial";
         else if ( shortType == "Q" ) return "Diff Partial";
         else                    return "Unknown";
      }

      static public int
         GetBackupStatus(
            BackupResult br,
            int          daysForRecent
         )
      {
         int backupAge = Int32.MaxValue;
         if ( br.lastBackup != null && br.lastBackup != DateTime.MinValue )
         {
            TimeSpan ts = new TimeSpan( DateTime.Now.Ticks - br.lastBackup.Ticks );
            backupAge = ts.Days; //(int)Math.Ceiling(ts.TotalDays);
         }

         if ( backupAge < daysForRecent )
            return 0;   // backed up recently
         else if ( backupAge < Int32.MaxValue )
            return 1;   // backed up but not recently
         else
            return 2;   // never been backed up
      }

      #endregion

   }

   #endregion
}
