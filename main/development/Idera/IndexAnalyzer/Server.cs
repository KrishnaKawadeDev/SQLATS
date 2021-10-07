using System;
using System.Collections.Generic;
using System.Text;

using Idera.SqlAdminToolset.Core;
using System.Data.SqlClient;

namespace Idera.SqlAdminToolset.IndexAnalyzer
{
    class Server
    {
        private List<Database> databases;
        private string _serverName;
        private ServerVersionType serverVersion;
        private EngineEdition engineEdition;
        private static SqlCommand cmd = null;

        public static void Cancel()
        {
            if (cmd != null)
            {
                cmd.Cancel();
            }
            Database.Cancel();
        }
        public string ServerName
        {
            get { return _serverName; }
        }
        public ServerVersionType ServerVersion
        {
            get { return serverVersion; }
        }
        public EngineEdition EngineEdition
        {
            get { return engineEdition; }
        }

        public bool Is2000
        {
            get { return serverVersion == ServerVersionType.SQL2000; }
        }

        public bool Is2005
        {
            get { return serverVersion == ServerVersionType.SQL2005; }
        }

        public List<Database> Databases
        {
            get { return databases; }
        }
        public List<Index> Indexes
        {
            get
            {
                List<Index> idxs = new List<Index>();
                foreach (Database d in databases)
                {
                    idxs.AddRange(d.Indexes);
                }
                return idxs;
            }
        }
        public List<Index> Stats
        {
            get
            {
                List<Index> stats = new List<Index>();
                foreach (Database d in databases)
                {
                    stats.AddRange(d.Stats);
                }
                return stats;
            }
        }
        public int NumberIndexes
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.Indexes.Count;
                }
                return count;
            }
        }
        public int NumberStats
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.Stats.Count;
                }
                return count;
            }
        }

        public int NumberCriticalIndexes
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberCriticalIndexes;
                }
                return count;
            }
        }
        public int NumberCautionIndexes
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberCautionIndexes;
                }
                return count;
            }
        }
        public int NumberAcceptableIndexes
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberAcceptableIndexes;
                }
                return count;
            }
        }
        public int NumberCriticalSummaryIndexes
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberCriticalSummaryIndexes;
                }
                return count;
            }
        }
        public int NumberCautionSummaryIndexes
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberCautionSummaryIndexes;
                }
                return count;
            }
        }
        public int NumberAcceptableSummaryIndexes
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberAcceptableSummaryIndexes;
                }
                return count;
            }
        }
        public int NumberCriticalIndexes_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberCriticalIndexes_Selectivity;
                }
                return count;
            }
        }
        public int NumberCautionIndexes_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberCautionIndexes_Selectivity;
                }
                return count;
            }
        }
        public int NumberAcceptableIndexes_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberAcceptableIndexes_Selectivity;
                }
                return count;
            }
        }
        public int NumberCriticalIndexes_Modified
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberCriticalIndexes_Modified;
                }
                return count;
            }
        }
        public int NumberCautionIndexes_Modified
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberCautionIndexes_Modified;
                }
                return count;
            }
        }
        public int NumberAcceptableIndexes_Modified
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberAcceptableIndexes_Modified;
                }
                return count;
            }
        }
        public int NumberCriticalIndexes_Usage
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberCriticalIndexes_Usage;
                }
                return count;
            }
        }
        public int NumberCautionIndexes_Usage
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberCautionIndexes_Usage;
                }
                return count;
            }
        }
        public int NumberAcceptableIndexes_Usage
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberAcceptableIndexes_Usage;
                }
                return count;
            }
        }



        public int NumberCriticalStats_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberCriticalStats_Selectivity;
                }
                return count;
            }
        }
        public int NumberCautionStats_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberCautionStats_Selectivity;
                }
                return count;
            }
        }
        public int NumberAcceptableStats_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Database d in databases)
                {
                    count += d.NumberAcceptableStats_Selectivity;
                }
                return count;
            }
        }

        public Server(string serverName)
        {
            _serverName = serverName;    
            databases = new List<Database>();
        }



        public bool LoadDTIs(Form_Main.DelegateUpdateProgressBar updateTextDelegate, 
                            bool includeColumnStats, bool includeFrag, bool includeStats,
                            List<string> databaseList)
        {
            bool retVal = true;
            try
            {
                retVal = GetDatabases(databaseList);

                if (retVal)
                {
                    foreach (Database database in databases)
                    {
                        if (ProductConstants.globalCancelRequested)
                        {
                            ProductConstants.globalOperationCancelled = true;
                            break;
                        }
                        updateTextDelegate("Loading indexes for database...", string.Format("'{0}'", database.Name));
                        database.GetTablesAndIndexesFast(updateTextDelegate, includeFrag, includeStats);
                        if (includeColumnStats)
                        {
                            updateTextDelegate("Loading column statistics for database...",
                                               string.Format("'{0}'", database.Name));
                            database.GetTablesAndColumnStats(updateTextDelegate, includeStats);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ProductConstants.globalErrorReports.Add("Error loading index statistics", Helpers.GetCombinedExceptionText(ex));
            }

            return retVal;
        }

        public bool GetDatabases(List<string> databaseList)
        {
            bool retVal = true;
            engineEdition = EngineEdition.Unknown;
            serverVersion = ServerVersionType.Unknown;
            databases.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(Connection.CreateConnectionString(_serverName, string.Empty, ProductConstants.globalSqlCredentials)))
                {
                    Connection.Impersonate(ProductConstants.globalSqlCredentials);

                    conn.Open();

                    string query = "SELECT SERVERPROPERTY('EngineEdition')";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = ToolsetOptions.commandTimeout;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                engineEdition = (IndexAnalyzer.EngineEdition)reader[0];
                            }
                        }
                    }

                    if (SQLHelpers.Is2000(conn))
                    {
                        serverVersion = ServerVersionType.SQL2000;
                    }
                    else if (SQLHelpers.Is2005(conn))
                    {
                        serverVersion = ServerVersionType.SQL2005;
                    }
                    else if (SQLHelpers.Is2008(conn))
                    {
                        serverVersion = ServerVersionType.SQL2008;
                    }
                    if (SQLHelpers.Is2012(conn))
                    {
                        serverVersion = ServerVersionType.SQL2012;
                    }
                    else if (SQLHelpers.Is2014(conn))
                    {
                        serverVersion = ServerVersionType.SQL2014;
                    }
                    else if (SQLHelpers.Is2016(conn))
                    {
                        serverVersion = ServerVersionType.SQL2016;
                    }
                    else if (SQLHelpers.Is2017(conn))
                    {
                        serverVersion = ServerVersionType.SQL2017;
                    }

                    string _DatabaseCriteria = string.Empty;
                    foreach (string _Database in databaseList)
                    {
                        if (_Database.Trim().Length > 0)
                        {
                            if (_DatabaseCriteria.Length > 0)
                            {
                                _DatabaseCriteria += ",";
                            }
                            _DatabaseCriteria += SQLHelpers.CreateSafeString(_Database.Trim());
                        }
                    }

                    if (_DatabaseCriteria.Length == 0)
                    {
                        query = "select name,dbid,cmptlevel from master..sysdatabases WHERE has_dbaccess(name) = 1 ORDER BY name ASC";
                    }
                    else
                    {
                        query = string.Format("select name,dbid,cmptlevel from master..sysdatabases WHERE has_dbaccess(name) = 1 AND name IN ({0}) ORDER BY name ASC", _DatabaseCriteria);
                    }
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = ToolsetOptions.commandTimeout;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Database db = new Database();
                                int count = 0;
                                db.Name = SQLHelpers.GetString(reader, count++);
                                db.Id = SQLHelpers.GetInt16(reader, count++);
                                if (db.Id >= 1 && db.Id <= 4)
                                {
                                    // model, msdb, temp, master use 1 - 4
                                    continue;
                                }
                                int compat = SQLHelpers.ByteToInt(reader, count++);
                                if (compat < 80)
                                {
                                    //                                    logX.WarnFormat("Database {0} has an unsupported compatability level: {1}\nSkipping this database.", db.Name, compat);
                                    continue;
                                }
                                db.ServerName = _serverName;
                                db.ServerVersion = serverVersion;
                                db.EngineEdition = engineEdition;
                                databases.Add(db);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProductConstants.globalErrorReports.Add("Error loading databases", Helpers.GetCombinedExceptionText(ex));
            }
            return retVal;
        }
        
    }
}
