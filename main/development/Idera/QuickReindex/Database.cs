using System;
using System.Collections.Generic;
using System.Text;

using Idera.SqlAdminToolset.Core;
using System.Data.SqlClient;

namespace Idera.SqlAdminToolset.QuickReindex
{
    public class Database : DTIRecord
    {
        private static SqlCommand command = null;

        private const string GetIndexFrag2000 = "USE {0}"
                            + "Create Table #SaveResults(ObjectName nvarchar(255), ObjectId Int, IndexName nvarchar(255), IndexId Int, "
                                     + "[Level] Int, page_count bigint, [Rows] Int, MinimumRecordSize Int, MaximumRecordSize Int, AverageRecordSize Int, "
                                     + "ForwardedRecords Int, Extents Int, ExtentSwitches Int, AverageFreeBytes Int, AveragePageDensity Int, "
                                     + "ScanDensity Int, BestCount int, ActualCount Int, avg_fragmentation_in_percent float, ExtentFragmentation Int) "
                                     + "INSERT INTO #SaveResults EXEC ('DBCC SHOWCONTIG WITH FAST,TABLERESULTS,ALL_INDEXES') "
                                         + "SELECT tbl.name as [Table], tbl.id as [object_id], su.name as [Schema], "
                                                + "i.name AS [Name], "
                                                + "CAST(i.indid AS int) AS [ID], "
                                                + "CAST(CASE i.indid WHEN 1 THEN 1 ELSE 0 END AS tinyint) AS [IsClustered], CAST(i.OrigFillFactor AS varchar) AS [FillFactor], "
                                                + "CAST(0 as tinyint) as [IsDisabled], "
                                                 + "avg_fragmentation_in_percent, "
                                                 + "i.dpages "
                                          + "FROM dbo.sysobjects AS tbl "
                                             + "JOIN dbo.sysusers su on tbl.uid=su.uid "
                                             + "INNER JOIN dbo.sysindexes as i ON (i.indid > 0 and i.indid < 255 "
                                                    + "and 1 != INDEXPROPERTY(i.id,i.name,N'IsStatistics') "
                                                    + "and 1 != INDEXPROPERTY(i.id,i.name,N'IsHypothetical')) "
                                                    + "AND (i.id=tbl.id) "
                                             + "LEFT JOIN #SaveResults as d ON (d.ObjectId = tbl.id and d.IndexId = i.indid) "
                                           + "WHERE tbl.type='U' ORDER BY [Table] ASC "
                             + "DROP Table #SaveResults ";

        private const string GetIndexes2000 = "USE {0}"
                                         + "SELECT tbl.name as [Table], tbl.id as [object_id], su.name as [Schema], "
                                                + "i.name AS [Name], "
                                                + "CAST(i.indid AS int) AS [ID], "
                                                + "CAST(CASE i.indid WHEN 1 THEN 1 ELSE 0 END AS tinyint) AS [IsClustered], CAST(i.OrigFillFactor AS varchar) AS [FillFactor], "
                                                + "CAST(0 as tinyint) as [IsDisabled], "
                                                 + "CAST(-10.0 as float) as [avg_fragmentation_in_percent], "
                                                 + "i.dpages "
                                          + "FROM dbo.sysobjects AS tbl "
                                             + "JOIN dbo.sysusers su on tbl.uid=su.uid "
                                             + "INNER JOIN dbo.sysindexes as i ON (i.indid > 0 and i.indid < 255 "
                                                    + "and 1 != INDEXPROPERTY(i.id,i.name,N'IsStatistics') "
                                                    + "and 1 != INDEXPROPERTY(i.id,i.name,N'IsHypothetical')) "
                                                    + "AND (i.id=tbl.id) "
                                           + "WHERE tbl.type='U' ORDER BY [Table] ASC "
                             + "DROP Table #SaveResults ";


        private const string GetIndexFrag2005 = "USE {0} SELECT tbl.name as [Table], tbl.object_id, SCHEMA_NAME(tbl.schema_id) as [Schema], i.Name AS [Name], "
                                                                              + "CAST(i.index_id AS int) AS [ID], "
                                                                              + "CAST(CASE i.index_id WHEN 1 THEN 1 ELSE 0 END AS tinyint) AS [IsClustered], CAST(i.fill_factor AS varchar) AS [FillFactor], "
                                                                              + "CAST(i.is_disabled as tinyint) as [IsDisabled], "
                                                                              + "avg_fragmentation_in_percent, "
                                                                              + "x.dpages "
                                                                              + "FROM sys.tables AS tbl "
                                                                              + "INNER JOIN sys.indexes AS i ON (i.index_id > 0 and i.is_hypothetical = 0) AND (i.object_id=tbl.object_id) "
                                                                              + "INNER JOIN dbo.sysindexes as x on (i.index_id = x.indid and i.object_id = x.id) " 
                                                                              + "LEFT JOIN sys.dm_db_index_physical_stats({1}, NULL, NULL, NULL, 'LIMITED') as d ON (tbl.object_id = d.object_id and i.index_id = d.index_id) where alloc_unit_type_desc = 'IN_ROW_DATA' "
                                                                              + "ORDER BY [Table] ASC";

        private const string GetIndexes2005 = "USE {0} SELECT tbl.name as [Table], tbl.object_id, SCHEMA_NAME(tbl.schema_id) as [Schema], i.Name AS [Name], "
                                                                             + "CAST(i.index_id AS int) AS [ID], "
                                                                             + "CAST(CASE i.index_id WHEN 1 THEN 1 ELSE 0 END AS tinyint) AS [IsClustered],  CAST(i.fill_factor AS varchar) AS [FillFactor], "
                                                                             + "CAST(i.is_disabled as tinyint) as [IsDisabled], "
                                                                             + "CAST(-10.0 as float) as [avg_fragmentation_in_percent], "
                                                                             + "x.dpages "
                                                                             + "FROM sys.tables AS tbl "    
                                                                             + "INNER JOIN sys.indexes AS i ON (i.index_id > 0 and i.is_hypothetical = 0) AND (i.object_id=tbl.object_id) "
                                                                             + "LEFT JOIN dbo.sysindexes as x on (i.index_id = x.indid and i.object_id = x.id) " //CGVAK -To display the spatial index
																			 + "ORDER BY [Table] ASC";



		public static void Cancel()
        {
            if (command != null)
            {
                command.Cancel();
            }
            Index.Cancel();
        }

        private List<Table> tables;

        public List<Table> Tables
        {
            get { return tables; }
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

        

        public Database()
        {
            tables = new List<Table>();
        }

        public bool GetTablesAndIndexesFast(Form_Main.DelegateUpdateProgressBar updateTextDelegate, bool includeFrag)
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
                        if (includeFrag)
                        {
                            query = String.Format(GetIndexFrag2000,
                                                  SQLHelpers.CreateSafeDatabaseName(Name));
                        }
                        else
                        {
                            query = String.Format(GetIndexes2000,
                                                  SQLHelpers.CreateSafeDatabaseName(Name));                            
                        }
                    }
                    else
                    {
                       if (includeFrag)
                        {
                            query = String.Format(GetIndexFrag2005,
                                                  SQLHelpers.CreateSafeDatabaseName(Name), Id);
                        }
                        else
                        {
                            query = String.Format(GetIndexes2005,
                                                  SQLHelpers.CreateSafeDatabaseName(Name), Id);                            
                        }
                    }

                    using (command = new SqlCommand(query, conn))
                    {
                        command.CommandTimeout = 0;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Table workingTable = null;
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

                                Index idx = new Index();
                                idx.Name = SQLHelpers.GetString(reader, count++);
                                updateTextDelegate("Adding indexes...",
                                                    string.Format("'{0}.{1}.{2}.{3}'", workingTable.DatabaseName,
                                                  workingTable.SchemaName, workingTable.Name, idx.Name));
                                idx.Id = SQLHelpers.GetInt32(reader, count++);
                                idx.IsClustered = SQLHelpers.ByteToBool(reader, count++);
                                idx.FillFactor = SQLHelpers.GetString(reader, count++);
                                if (idx.FillFactor == "0")
                                {
                                    idx.FillFactor = "Not Set";
                                }
                                idx.IsDisabled = SQLHelpers.ByteToBool(reader, count++);
                                idx.AverageFragLevel = SQLHelpers.GetDouble(reader, count++);
                                idx.CountPages = SQLHelpers.GetInt32(reader, count++);
                                idx.ServerVersion = workingTable.ServerVersion;
                                idx.EngineEdition = workingTable.EngineEdition;
                                idx.ServerName = workingTable.ServerName;
                                idx.DatabaseId = workingTable.DatabaseId;
                                idx.DatabaseName = workingTable.DatabaseName;
                                idx.SchemaName = workingTable.SchemaName;
                                idx.TableId = workingTable.Id;
                                idx.TableName = workingTable.Name;
                                

                                workingTable.Indexes.Add(idx);
                            }
                            if (workingTable != null)
                            {
                                tables.Add(workingTable);
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



        


    }
}
