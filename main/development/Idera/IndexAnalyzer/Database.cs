using System;
using System.Collections.Generic;
using System.Text;

using Idera.SqlAdminToolset.Core;
using System.Data.SqlClient;

namespace Idera.SqlAdminToolset.IndexAnalyzer
{
    public class Database : DTIRecord
    {
        #region fields

        private List<Table> tables;
        private List<Table> _statTables;
        private static SqlCommand cmd = null;

        #endregion

        #region queries

        private const string GetFullIndexStats2000 = "USE {0} "
                                                  + "Create Table #SaveResults(ObjectName nvarchar(255), ObjectId Int, IndexName nvarchar(255), IndexId Int, "
                                                  + "[Level] Int, page_count bigint, [Rows] Int, MinimumRecordSize Int, MaximumRecordSize Int, AverageRecordSize Int, "
                                                  + "ForwardedRecords Int, Extents Int, ExtentSwitches Int, AverageFreeBytes Int, AveragePageDensity Int, "
                                                  + "ScanDensity Int, BestCount int, ActualCount Int, avg_fragmentation_in_percent float, ExtentFragmentation Int) "
                                                  + "INSERT INTO #SaveResults EXEC ('DBCC SHOWCONTIG WITH FAST,TABLERESULTS') "
                                                  + "SELECT tbl.name as [Table], tbl.id as [object_id], su.name as [Schema], "
                                                  + "i.name AS [Name], "
                                                  + "CAST(i.indid AS int) AS [ID], "
                                                  + "c.name as [ColName], "
                                                  +"CAST(CASE i.indid WHEN 1 THEN 1 ELSE 0 END AS tinyint) AS [IsClustered], "
                                                  + "CAST(0 as tinyint) as [IsDisabled], "
                                                  + "avg_fragmentation_in_percent, "
                                                  + "i.dpages, "
                                                  + "i.rowcnt, i.rowmodctr,"
                                                  + "CAST(INDEXPROPERTY(tbl.id,i.name,'IndexFillFactor') as varchar) as [FillFactor], "
                                                  + "CAST(0 as bigint), CAST(0 as bigint), CAST(0 as bigint), CAST(0 as bigint) "
                                                  + "FROM dbo.sysobjects AS tbl "
                                                  + "JOIN dbo.sysusers su on tbl.uid=su.uid "
                                                  + "INNER JOIN dbo.sysindexes as i ON (i.indid > 0 and i.indid < 255 "
                                                  + "and 1 != INDEXPROPERTY(i.id,i.name,N'IsStatistics') "
                                                  + "and 1 != INDEXPROPERTY(i.id,i.name,N'IsHypothetical')) "
                                                  + "AND (i.id=tbl.id) "
                                                  + "INNER JOIN dbo.sysindexkeys k on (k.id = i.id and k.indid = i.indid) "
                                                  + "INNER JOIN dbo.syscolumns c on (k.id = c.id and k.colid = c.colid) "
                                                  + "LEFT JOIN #SaveResults as d ON (d.ObjectId = tbl.id and d.IndexId = i.indid) "
                                                  + "WHERE tbl.type='U' ORDER BY [Table],[Name] ASC "
                                                  + "DROP Table #SaveResults ";

        private const string GetQuickIndexes2000 = "USE {0} "
                                                  + "SELECT tbl.name as [Table], tbl.id as [object_id], su.name as [Schema], "
                                                  + "i.name AS [Name], "
                                                  + "CAST(i.indid AS int) AS [ID], "
                                                  + "c.name as [ColName], "
                                                  + "CAST(CASE i.indid WHEN 1 THEN 1 ELSE 0 END AS tinyint) AS [IsClustered], "
                                                  + "CAST(0 as tinyint) as [IsDisabled], "
                                                  + "CAST(-1000.0 as float) as [avg_fragmentation_in_percent], "
                                                  + "i.dpages, "
                                                  + "i.rowcnt, i.rowmodctr,"
                                                  + "CAST(INDEXPROPERTY(tbl.id,i.name,'IndexFillFactor') as varchar) as [FillFactor], "
                                                  + "CAST(0 as bigint), CAST(0 as bigint), CAST(0 as bigint), CAST(0 as bigint) "
                                                  + "FROM dbo.sysobjects AS tbl "
                                                  + "JOIN dbo.sysusers su on tbl.uid=su.uid "
                                                  + "INNER JOIN dbo.sysindexes as i ON (i.indid > 0 and i.indid < 255 "
                                                  + "and 1 != INDEXPROPERTY(i.id,i.name,N'IsStatistics') "
                                                  + "and 1 != INDEXPROPERTY(i.id,i.name,N'IsHypothetical')) "
                                                  + "AND (i.id=tbl.id) "
                                                  + "INNER JOIN dbo.sysindexkeys k on (k.id = i.id and k.indid = i.indid) "
                                                  + "INNER JOIN dbo.syscolumns c on (k.id = c.id and k.colid = c.colid) "
                                                  + "WHERE tbl.type='U' ORDER BY [Table],[Name] ASC ";


        private const string GetFullIndexStats2005 = "USE {0} "
                                          + "SELECT tbl.name as [Table], tbl.object_id, SCHEMA_NAME(tbl.schema_id) as [Schema], i.Name AS [Name], "
                                          +     "CAST(i.index_id AS int) AS [ID], "
                                          +     "c.name as [ColName], "
                                          +     "CAST(CASE i.index_id WHEN 1 THEN 1 ELSE 0 END AS tinyint) AS [IsClustered], "
                                          +     "CAST(i.is_disabled as tinyint) as [IsDisabled], "
                                          +     "avg_fragmentation_in_percent, "
                                          +     "x.dpages, "
                                          +     "x.rowcnt, x.rowmodctr,"
                                          +     "CAST(INDEXPROPERTY(tbl.object_id,i.Name,'IndexFillFactor') as varchar) as [FillFactor], "
	                                      +     "iv.seeks, "
	                                      +     "iv.scans, "
	                                      +     "iv.lookups, "
                                          +     "iv.updates "
                                          + "FROM sys.tables AS tbl "
                                          +     "INNER JOIN sys.indexes AS i ON (i.index_id > 0 and i.is_hypothetical = 0) AND (i.object_id=tbl.object_id) "
                                          +     "INNER JOIN dbo.sysindexes as x on (i.index_id = x.indid and i.object_id = x.id) "
                                          +     "LEFT JOIN 	(select iu.database_id, iu.object_id, iu.index_id, "
			                              +                      "sum(iu.user_seeks) + sum(iu.system_seeks) as seeks, " 
                                          +                      "sum(iu.user_scans) + sum(iu.system_scans) as scans, "
                                          +                      "sum(iu.user_lookups) + sum(iu.system_lookups) as lookups, "
                                          +                      "sum(iu.user_updates) + sum(iu.system_updates) as updates "
			                              +                      "from sys.dm_db_index_usage_stats as iu "
			                              +                      "group by iu.database_id, iu.object_id,iu.index_id) as iv "
	                                      +                      "on ({1} = iv.database_id and tbl.object_id = iv.object_id and i.index_id = iv.index_id) "
                                          +     "INNER JOIN sys.index_columns ic on ic.object_id = i.object_id and ic.index_id = i.index_id "
                                          +     "INNER JOIN sys.columns c on ic.object_id = c.object_id and ic.column_id = c.column_id "
                                          + "LEFT JOIN sys.dm_db_index_physical_stats({1}, NULL, NULL, NULL, 'LIMITED') as d ON (tbl.object_id = d.object_id and i.index_id = d.index_id) where alloc_unit_type_desc = 'IN_ROW_DATA' "
                                          + "ORDER BY [Table],[Name],ic.index_column_id ASC";

		private const string GetQuickIndexes2005 = "USE {0} "
											   + "SELECT tbl.name as [Table], tbl.object_id, SCHEMA_NAME(tbl.schema_id) as [Schema], i.Name AS [Name], "
											   + "CAST(i.index_id AS int) AS [ID], "
											   + "c.name as [ColName], "
											   + "CAST(CASE i.index_id WHEN 1 THEN 1 ELSE 0 END AS tinyint) AS [IsClustered], "
											   + "CAST(i.is_disabled as tinyint) as [IsDisabled], "
											   + "CAST(-1000.0 as float) as [avg_fragmentation_in_percent], "
											   + "x.dpages, "
											   + "x.rowcnt, x.rowmodctr,"
											   + "CAST(INDEXPROPERTY(tbl.object_id,i.Name,'IndexFillFactor') as varchar) as [FillFactor], "
											   + "iv.seeks, "
											   + "iv.scans, "
											   + "iv.lookups, "
											   + "iv.updates "
											   + "FROM sys.tables AS tbl "
											   + "INNER JOIN sys.indexes AS i ON (i.index_id > 0 and i.is_hypothetical = 0) AND (i.object_id=tbl.object_id) "
											   + "LEFT JOIN dbo.sysindexes as x on (i.index_id = x.indid and i.object_id = x.id) " //CGVAK -To display the spatial index
											   + "LEFT JOIN 	(select iu.database_id, iu.object_id, iu.index_id, "
											   + "sum(iu.user_seeks) + sum(iu.system_seeks) as seeks, "
											   + "sum(iu.user_scans) + sum(iu.system_scans) as scans, "
											   + "sum(iu.user_lookups) + sum(iu.system_lookups) as lookups, "
											   + "sum(iu.user_updates) + sum(iu.system_updates) as updates "
											   + "from sys.dm_db_index_usage_stats as iu "
											   + "group by iu.database_id, iu.object_id,iu.index_id) as iv "
											   + "on ({1} = iv.database_id and tbl.object_id = iv.object_id and i.index_id = iv.index_id) "
											   + "INNER JOIN sys.index_columns ic on ic.object_id = i.object_id and ic.index_id = i.index_id "
											   + "INNER JOIN sys.columns c on ic.object_id = c.object_id and ic.column_id = c.column_id "
											   + "ORDER BY [Table],[Name],ic.index_column_id ASC";



        #endregion     

        #region Properties

        public List<Table> Tables
        {
            get { return tables; }
        }

        public List<Table> StatTables
        {
            get { return _statTables; }
        }

        public List<Index> Indexes
        {
            get
            {
                List<Index> idxs = new List<Index>();
                foreach (Table t in tables)
                {
                    idxs.AddRange(t.Indexes);
                }
                return idxs;
            }
        }

        public List<Index> Stats
        {
            get
            {
                List<Index> stats = new List<Index>();
                foreach (Table t in _statTables)
                {
                    stats.AddRange(t.Stats);
                }
                return stats;
            }
        }

        public int NumberTables
        {
            get { return tables.Count; }
        }

        public int NumberIndexes
        {
            get
            {
                int count = 0;
                foreach (Table t in tables)
                {
                    count += t.Indexes.Count;
                }
                return count;
            }
        }
        
        public int NumberStats
        {
            get
            {
                int count = 0;
                foreach (Table t in _statTables)
                {
                    count += t.Stats.Count;
                }
                return count;
            }
        }
        
        public int NumberCriticalIndexes
        {
            get
            {
                int count = 0;
                foreach (Table t in tables)
                {
                    count += t.NumberCriticalIndexes;
                }
                return count;
            }
        }
        public int NumberCautionIndexes
        {
            get
            {
                int count = 0;
                foreach (Table t in tables)
                {
                    count += t.NumberCautionIndexes;
                }
                return count;
            }
        }
        public int NumberAcceptableIndexes
        {
            get
            {
                int count = 0;
                foreach (Table t in tables)
                {
                    count += t.NumberAcceptableIndexes;
                }
                return count;
            }
        }
        
        public int NumberCriticalSummaryIndexes
        {
            get
            {
                int count = 0;
                foreach (Table t in tables)
                {
                    count += t.NumberCriticalSummaryIndexes;
                }
                return count;
            }
        }
        public int NumberCautionSummaryIndexes
        {
            get
            {
                int count = 0;
                foreach (Table t in tables)
                {
                    count += t.NumberCautionSummaryIndexes;
                }
                return count;
            }
        }
        public int NumberAcceptableSummaryIndexes
        {
            get
            {
                int count = 0;
                foreach (Table t in tables)
                {
                    count += t.NumberAcceptableSummaryIndexes;
                }
                return count;
            }
        }
        
        public int NumberCriticalIndexes_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Table t in tables)
                {
                    count += t.NumberCriticalIndexes_Selectivity;
                }
                return count;
            }
        }
        public int NumberCautionIndexes_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Table t in tables)
                {
                    count += t.NumberCautionIndexes_Selectivity;
                }
                return count;
            }
        }
        public int NumberAcceptableIndexes_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Table t in tables)
                {
                    count += t.NumberAcceptableIndexes_Selectivity;
                }
                return count;
            }
        }
        
        public int NumberCriticalIndexes_Modified
        {
            get
            {
                int count = 0;
                foreach (Table t in tables)
                {
                    count += t.NumberCriticalIndexes_Modified;
                }
                return count;
            }
        }
        public int NumberCautionIndexes_Modified
        {
            get
            {
                int count = 0;
                foreach (Table t in tables)
                {
                    count += t.NumberCautionIndexes_Modified;
                }
                return count;
            }
        }
        public int NumberAcceptableIndexes_Modified
        {
            get
            {
                int count = 0;
                foreach (Table t in tables)
                {
                    count += t.NumberAcceptableIndexes_Modified;
                }
                return count;
            }
        }
        
        public int NumberCriticalIndexes_Usage
        {
            get
            {
                int count = 0;
                foreach (Table t in tables)
                {
                    count += t.NumberCriticalIndexes_Usage;
                }
                return count;
            }
        }
        public int NumberCautionIndexes_Usage
        {
            get
            {
                int count = 0;
                foreach (Table t in tables)
                {
                    count += t.NumberCautionIndexes_Usage;
                }
                return count;
            }
        }
        public int NumberAcceptableIndexes_Usage
        {
            get
            {
                int count = 0;
                foreach (Table t in tables)
                {
                    count += t.NumberAcceptableIndexes_Usage;
                }
                return count;
            }
        }
        
        public int NumberCriticalStats_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Table t in _statTables)
                {
                    count += t.NumberCriticalStats_Selectivity;
                }
                return count;
            }
        }
        public int NumberCautionStats_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Table t in _statTables)
                {
                    count += t.NumberCautionStats_Selectivity;
                }
                return count;
            }
        }
        public int NumberAcceptableStats_Selectivity
        {
            get
            {
                int count = 0;
                foreach (Table t in _statTables)
                {
                    count += t.NumberAcceptableStats_Selectivity;
                }
                return count;
            }
        }

        #endregion

        public Database()
        {
            tables = new List<Table>();
            _statTables = new List<Table>();
        }

        public bool GetTablesAndIndexesFast(Form_Main.DelegateUpdateProgressBar updateTextDelegate, 
                                            bool includeFrag, bool includeStats)
        {
            bool RetVal = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Connection.CreateConnectionString(ServerName, string.Empty, ProductConstants.globalSqlCredentials)))
                {
                    Connection.Impersonate(ProductConstants.globalSqlCredentials);

                    conn.Open();
                    string queryColumns = string.Empty;
                    string query = string.Empty;

                    if (ServerVersion == ServerVersionType.SQL2000)
                    {
                        if (includeFrag)
                        {
                            query = String.Format(GetFullIndexStats2000, SQLHelpers.CreateSafeDatabaseName(Name));
                        }
                        else
                        {
                            query = String.Format(GetQuickIndexes2000, SQLHelpers.CreateSafeDatabaseName(Name));
                        }
                    }
                    else
                    {
                        if (includeFrag)
                        {
                            query = String.Format(GetFullIndexStats2005, SQLHelpers.CreateSafeDatabaseName(Name),Id);
                        }
                        else
                        {
                            query = String.Format(GetQuickIndexes2005, SQLHelpers.CreateSafeDatabaseName(Name), Id);
                        }
                    }

                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = 0;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Table workingTable = null;
                            Index idx = null;
                            StringBuilder cols = null;
                            string colName = string.Empty;
                            while (reader.Read())
                            {
                                
                                int count = 0;
                                string tblName = SQLHelpers.GetString(reader, count++);
                                int tblId = SQLHelpers.GetInt32(reader, count++);
                                string tblSchemaName = SQLHelpers.GetString(reader, count++);
                                if (workingTable == null || tblId != workingTable.Id)
                                {
                                    if(workingTable != null)
                                    {
                                        if (idx != null)
                                        {
                                            if (cols != null && cols.Length > 0)
                                            {
                                                idx.Columns = cols.ToString();
                                            }
                                            workingTable.Indexes.Add(idx);
                                            idx = null;
                                        }
                                        tables.Add(workingTable);
                                    }
                                    workingTable = new Table();
                                    workingTable.Id = tblId;
                                    workingTable.Name = tblName;
                                    workingTable.SchemaName = tblSchemaName;
                                    workingTable.ServerVersion = ServerVersion;
                                    workingTable.EngineEdition = EngineEdition;
                                    workingTable.DatabaseId = Id;
                                    workingTable.DatabaseName = Name;
                                    workingTable.ServerName = ServerName;
                                }
                                string indexName = SQLHelpers.GetString(reader, count++);
                                int indexId = SQLHelpers.GetInt32(reader, count++);
                                colName = SQLHelpers.GetString(reader, count++);
                                if (idx == null || (indexId != idx.Id))
                                {
                                    if(idx != null)
                                    {
                                        if(cols != null && cols.Length > 0)
                                        {
                                            idx.Columns = cols.ToString();                                            
                                        }
                                        workingTable.Indexes.Add(idx);
                                        idx = null;
                                    }
                                    idx = new Index();
                                    cols = new StringBuilder();
                                    idx.Name = indexName;
                                    updateTextDelegate("Adding indexes...",
                                                        string.Format("'{0}.{1}.{2}.{3}'", workingTable.DatabaseName,
                                                      workingTable.SchemaName, workingTable.Name, idx.Name));
                                    idx.Id = indexId;
                                    idx.IsClustered = SQLHelpers.ByteToBool(reader, count++);
                                    idx.IsDisabled = SQLHelpers.ByteToBool(reader, count++);
                                    if (!reader.IsDBNull(count))
                                    {
                                        idx.AverageFragLevel = Convert.ToDouble(reader.GetValue(count))/100;
                                    }
                                    count++;
                                    //idx.AverageFragLevel = SQLHelpers.GetDouble(reader, count++);
                                    idx.CountPages = SQLHelpers.GetInt32(reader, count++);
                                    idx.Rows = SQLHelpers.GetInt64(reader, count++);
                                    idx.ModifiedRows = (long) SQLHelpers.GetInt32(reader, count++);
                                    if (idx.ModifiedRows < 0)
                                    {
                                        idx.ModifiedRows = idx.ModifiedRows * -1;
                                    }
                                    idx.FillFactor = SQLHelpers.GetString(reader, count++);
                                    if (idx.FillFactor == "0")
                                    {
                                        idx.FillFactor = "Not Set";
                                    }
                                    idx.Seeks = SQLHelpers.GetInt64(reader, count++);
                                    idx.Scans = SQLHelpers.GetInt64(reader, count++);
                                    idx.Lookups = SQLHelpers.GetInt64(reader, count++);
                                    idx.Updates = SQLHelpers.GetInt64(reader, count++);
                                    idx.ServerVersion = workingTable.ServerVersion;
                                    idx.EngineEdition = workingTable.EngineEdition;
                                    idx.ServerName = workingTable.ServerName;
                                    idx.DatabaseId = workingTable.DatabaseId;
                                    idx.DatabaseName = workingTable.DatabaseName;
                                    idx.SchemaName = workingTable.SchemaName;
                                    idx.TableId = workingTable.Id;
                                    idx.TableName = workingTable.Name;
                                    cols.Append(colName);
                                }
                                else
                                {
                                    if(cols != null)
                                    {
                                        cols.Append(", ");
                                        cols.Append(colName);
                                    }
                                }
                            }                           
                            if (workingTable != null)
                            {
                                if (idx != null)
                                {
                                    if (cols != null && cols.Length > 0)
                                    {
                                        idx.Columns = cols.ToString();
                                    }
                                    workingTable.Indexes.Add(idx);
                                }
                                tables.Add(workingTable);
                            }
                        }
                        if (includeStats)
                        {
                            foreach (Table t in tables)
                            {
                                foreach (Index i in t.Indexes)
                                {
                                    updateTextDelegate("Gathering index statistics...",
                                                       string.Format("'{0}.{1}.{2}.{3}'", i.DatabaseName,
                                                                     i.SchemaName, i.TableName, i.Name));

                                    i.GetStatistics(conn, -2);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProductConstants.globalErrorReports.Add(string.Format("Error loading indexes for database {0}", Name), 
                        Helpers.GetCombinedExceptionText(ex));
            }

            return RetVal;
        }

        public bool GetTablesAndColumnStats(Form_Main.DelegateUpdateProgressBar updateTextDelegate, bool includeStats)
        {
            bool RetVal = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Connection.CreateConnectionString(ServerName, string.Empty, ProductConstants.globalSqlCredentials)))
                {
                    Connection.Impersonate(ProductConstants.globalSqlCredentials);

                    conn.Open();
                    string query;

                    if (ServerVersion == ServerVersionType.SQL2000)
                    {
                        query = String.Format(
                                            "USE {0} "
                                            + "SELECT tbl.name as [Table], "
	                                                + "tbl.id as [_object_id], "
	                                                + "su.name as [Schema], "
	                                                + "i.name AS [_Name], "
	                                                + "CAST(i.indid AS int) AS [ID], "
                                                    + "c.name as [ColName], "
	                                                + "i.rowcnt, i.rowmodctr "
                                            +  "FROM dbo.sysobjects AS tbl "
                                            +  "JOIN dbo.sysusers su on tbl.uid=su.uid "
                                            +  "INNER JOIN dbo.sysindexes as i "
                                            +  "INNER JOIN dbo.sysindexkeys k on (k.id = i.id and k.indid = i.indid) "
                                            +  "INNER JOIN dbo.syscolumns c on (k.id = c.id and k.colid = c.colid) "
	                                        +  "ON (i.name LIKE '%_WA_Sys%' AND i.id = tbl.id) ",
                                       SQLHelpers.CreateSafeDatabaseName(Name), Id);                            
                    }
                    else
                    {          
                        query = String.Format(
                                            "USE {0} "
                                            + "SELECT tbl.name as [Table], "
                                            + "tbl.object_id, "
                                            + "SCHEMA_NAME(tbl.schema_id) as [Schema], "
                                            + "i.Name AS [Name], "
                                            + "CAST(i.stats_id AS int) AS [ID], "
                                            + "c.name as [ColName], "
                                            + "x.rowcnt, x.rowmodctr "
                                            + "FROM sys.tables AS tbl "
                                            + "INNER JOIN sys.stats AS i ON (i.name LIKE '%_WA_Sys%' AND i.object_id=tbl.object_id) "
                                            + "INNER JOIN dbo.sysindexes as x on (i.stats_id = x.indid and i.object_id = x.id) "
                                            + "INNER JOIN sys.stats_columns ic on ic.object_id = i.object_id and ic.stats_id = i.stats_id "
                                            + "INNER JOIN sys.columns c on ic.object_id = c.object_id and ic.column_id = c.column_id ",
                                       SQLHelpers.CreateSafeDatabaseName(Name), Id);                            

                    }

                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = 0;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Table workingTable = null;
                            Index idx = null;
                            StringBuilder cols = null;
                            string colName = string.Empty;
                            while (reader.Read())
                            {

                                int count = 0;
                                string tblName = SQLHelpers.GetString(reader, count++);
                                int tblId = SQLHelpers.GetInt32(reader, count++);
                                string tblSchemaName = SQLHelpers.GetString(reader, count++);
                                if (workingTable == null || tblId != workingTable.Id)
                                {
                                    if (workingTable != null)
                                    {
                                        if (idx != null)
                                        {
                                            if (cols != null && cols.Length > 0)
                                            {
                                                idx.Columns = cols.ToString();
                                            }
                                            workingTable.Stats.Add(idx);
                                            idx = null;
                                        }
                                        _statTables.Add(workingTable);
                                    }
                                    workingTable = new Table();
                                    workingTable.Id = tblId;
                                    workingTable.Name = tblName;
                                    workingTable.SchemaName = tblSchemaName;
                                    workingTable.ServerVersion = ServerVersion;
                                    workingTable.EngineEdition = EngineEdition;
                                    workingTable.DatabaseId = Id;
                                    workingTable.DatabaseName = Name;
                                    workingTable.ServerName = ServerName;
                                }
                                string indexName = SQLHelpers.GetString(reader, count++);
                                int indexId = SQLHelpers.GetInt32(reader, count++);
                                colName = SQLHelpers.GetString(reader, count++);
                                if (idx == null || (indexId != idx.Id))
                                {
                                    if (idx != null)
                                    {
                                        if (cols != null && cols.Length > 0)
                                        {
                                            idx.Columns = cols.ToString();
                                        }
                                        workingTable.Stats.Add(idx);
                                        idx = null;
                                    }
                                    idx = new Index();
                                    cols = new StringBuilder();
                                    idx.Name = indexName;
                                    updateTextDelegate("Adding column statistics...",
                                                        string.Format("'{0}.{1}.{2}.{3}'", workingTable.DatabaseName,
                                                      workingTable.SchemaName, workingTable.Name, idx.Name));
                                    idx.Id = indexId;
                                    idx.Rows = SQLHelpers.GetInt64(reader, count++);
                                    idx.ModifiedRows = (long)SQLHelpers.GetInt32(reader, count++);
                                    if(idx.ModifiedRows < 0)
                                    {
                                        idx.ModifiedRows = idx.ModifiedRows * -1;
                                    }
                                    idx.ServerVersion = workingTable.ServerVersion;
                                    idx.EngineEdition = workingTable.EngineEdition;
                                    idx.ServerName = workingTable.ServerName;
                                    idx.DatabaseId = workingTable.DatabaseId;
                                    idx.DatabaseName = workingTable.DatabaseName;
                                    idx.SchemaName = workingTable.SchemaName;
                                    idx.TableId = workingTable.Id;
                                    idx.TableName = workingTable.Name;
                                    cols.Append(colName);
                                }
                                else
                                {
                                    if (cols != null)
                                    {
                                        cols.Append(", ");
                                        cols.Append(colName);
                                    }
                                }
                            }
                            if (workingTable != null)
                            {
                                if (idx != null)
                                {
                                    if (cols != null && cols.Length > 0)
                                    {
                                        idx.Columns = cols.ToString();
                                    }
                                    workingTable.Stats.Add(idx);
                                }
                                _statTables.Add(workingTable);
                            }
                        }
                        if (includeStats)
                        {
                            foreach (Table t in _statTables)
                            {
                                foreach (Index i in t.Stats)
                                {
                                    updateTextDelegate("Gathering column statistics...",
                                                       string.Format("'{0}.{1}.{2}.{3}'", i.DatabaseName,
                                                                     i.SchemaName, i.TableName, i.Name));
                                    i.GetStatistics(conn, 10);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProductConstants.globalErrorReports.Add(string.Format("Error loading stats for database {0}", Name),
                        Helpers.GetCombinedExceptionText(ex));
            }

            return RetVal;
        }

        public static void Cancel()
        {
            if (cmd != null)
            {
                cmd.Cancel();
            }
            Index.Cancel();
        }


    }
}
