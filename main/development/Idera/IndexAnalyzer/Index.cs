using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;
using System.Data.SqlClient;
using System.Data;

namespace Idera.SqlAdminToolset.IndexAnalyzer
{
    public enum IndexUsefulness
    {
        Low,
        Medium,
        High,
        NA
    };

    public class Index : DTIRecord
    {
        private IndexUsefulness _usefulnessSummary;
        private bool _isSystem;
        private bool _isClustered;
        private bool _isDisabled;
        private long _countPages;
        private double _avgFragPercent;         // Fragmentation 
        private double _avgDensity;             // 1/selectivity
        private string _fillFactor;
        private long _seeks;
        private long _scans;
        private long _lookups;
        private long _updates;
        private long _rows;
        private long _modifiedrows;
        private string _columns;
        private DateTime _lastStatisticsUpdate;

        public string Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }
        public double AverageDensity
        {
            get { return _avgDensity; }
            set { _avgDensity = value; }
        }
        public string FillFactor
        {
            get { return _fillFactor; }
            set { _fillFactor = value; }
        }
        public long Seeks
        {
            get { return _seeks; }
            set { _seeks = value; }
        }
        public long Scans
        {
            get { return _scans; }
            set { _scans = value; }
        }
        public long Lookups
        {
            get { return _lookups; }
            set { _lookups = value; }
        }
        public long Updates
        {
            get { return _updates; }
            set { _updates = value; }
        }
        public long TotalAccess
        {
            get { return (_seeks + _scans + _lookups + _updates); }           
        }
        public long Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }
        public long ModifiedRows
        {
            get { return _modifiedrows; }
            set { _modifiedrows = value; }
        }
        public bool IsStatistic
        {
            get { return Name.Contains("_WA_Sys"); }
        }
        private const string RefreshRows =
            "use {0} select rowcnt, rowmodctr from dbo.sysindexes where indid = {1} and id = {2}";

        private const string UpdateStatistics = "use {0} UPDATE STATISTICS {1} {2} {3}";
        private const string UseFullScan = " with FULLSCAN";
        private string NoFullScan = string.Empty;

        private const string GetColumnsForIndex2005 =
            "use {0} select name from sys.index_columns i INNER JOIN sys.columns c on i.object_id = c.object_id and i.column_id = c.column_id where i.object_id = {1} and i.index_id = {2}";
        private const string GetColumnsForStatistic2005 =
            "use {0} select c.name from sys.stats_columns s INNER JOIN sys.columns c on s.object_id = c.object_id and c.column_id = s.column_id where s.object_id = {1} and s.stats_id = {2}";

        private const string GetColumnsForIndex2000 =
            "use {0} select name from dbo.sysindexkeys i INNER JOIN dbo.syscolumns c on i.id = c.id and i.colid = c.colid where i.id = {1} and i.indid = {2}";
        private const string GetColumnsForStatistic2000 =
            "use {0} select name from dbo.sysindexkeys i INNER JOIN dbo.syscolumns c on i.id = c.id and i.colid = c.colid where i.id = {1} and i.indid = {2}";

        private const string Statistics = "use {0} DBCC SHOW_STATISTICS ({1}, {2}) with DENSITY_VECTOR";
        private const string StatisticsLastUpdated = "use {0} select STATS_DATE ({1}, {2})";

        private const string AnalyzeFast2000 = "use {0} DBCC SHOWCONTIG ( {1}, {2} ) WITH FAST,TABLERESULTS";

        private const string AnalyzeFast2005 = "use {0} select avg_record_size_in_bytes," +
                                                        "        avg_page_space_used_in_percent," +
                                                        "        page_count, " +
                                                        "        avg_fragmentation_in_percent, " +
                                                        "        CAST(i.is_disabled as tinyint) " +
                                                        "from sys.dm_db_index_physical_stats({1}, {2}, {3}, NULL,'LIMITED') " +
                                                        "left join sys.indexes i on (i.index_id = {3} and i.object_id = {2})";

        private const int AverageRecordSize2000 = 9;
        private const int AveragePageDensity2000 = 14;
        private const int Pages2000 = 5;
        private const int AverageFragmentation2000 = 18;
        private const int IsDisabled2000 = -1;
        private const int AverageRecordSize2005 = 0;
        private const int AveragePageDensity2005 = 1;
        private const int Pages2005 = 2;
        private const int AverageFragmentation2005 = 3;
        private const int IsDisabled2005 = 4;



        private static SqlCommand cmd = null;

        public static void Cancel()
        {
            if (cmd != null)
            {
                cmd.Cancel();
            }
        }

        public Index()
        {
            _avgFragPercent = -2.0;
            _avgDensity = 0.0;
            _rows = -1;
            _lastStatisticsUpdate = DateTime.MinValue;
        }

        public override string ToString()
        {
            return Name;
        }
        public IndexUsefulness UsefulnessSummary
        {
            get { return _usefulnessSummary; }
            set { _usefulnessSummary = value; }
        }

        public bool IsSystem
        {
            get { return _isSystem; }
            set { _isSystem = value; }
        }
        public bool IsClustered
        {
            get { return _isClustered; }
            set { _isClustered = value; }
        }
        public bool IsDisabled
        {
            get { return _isDisabled; }
            set { _isDisabled = value; }
        }
        public long CountPages
        {
            get { return _countPages; }
            set { _countPages = value; }
        }
        public double AverageFragLevel
        {
            get { return (_rows == 0) ? -1.0 : _avgFragPercent; }
            set { _avgFragPercent = value; }
        }

        public DateTime LastStatisticsUpdate
        {
            get { return _lastStatisticsUpdate; }
            set { _lastStatisticsUpdate = value; }
        }

        public bool IsFiltered
        {
            get
            {
                bool filtered = false;
                if (ProductConstants.globalHideBasedOnRowThreshold && Rows < ProductConstants.globalRowThreshold)
                {
                    filtered = true;
                }
                else if (ProductConstants.globalHideDisabled && IsDisabled)
                {
                    filtered = true;
                }
                else if (ProductConstants.globalHideNonClustered && !IsClustered)
                {
                    filtered = true;
                }
                return filtered;
            }
        }

        public void GetStatistics(SqlConnection conn, double defaultDensity)
        {
            int colDensity = 0;
            _avgDensity = defaultDensity;
            string query = string.Empty;
            try
            {
                query = String.Format(Statistics,
                                      SQLHelpers.CreateSafeDatabaseName(DatabaseName),
                                      SQLHelpers.CreateSafeString(String.Format("{0}.{1}",
                                                                                SQLHelpers.
                                                                                    CreateSafeDatabaseName(
                                                                                    SchemaName),
                                                                                SQLHelpers.
                                                                                    CreateSafeDatabaseName(
                                                                                    TableName))),
                                      SQLHelpers.CreateSafeString(Name));


                if (!string.IsNullOrEmpty(query))
                {
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = ToolsetOptions.commandTimeout;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (!reader.IsDBNull(colDensity))
                                {
                                    _avgDensity = Convert.ToDouble(reader.GetValue(colDensity));
                                }
                            }
                        }
                    }
                }
                query = String.Format(StatisticsLastUpdated,
                                    SQLHelpers.CreateSafeDatabaseName(DatabaseName),
                                    TableId, Id);

                using (cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                _lastStatisticsUpdate = (Convert.ToDateTime(reader.GetValue(0)));
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                ProductConstants.globalErrorReports.Add(string.Format("Error getting index statistics for {0}.{1}.{2}.{3}",
                                                                       DatabaseName, SchemaName, TableName, Name),
                                                        Helpers.GetCombinedExceptionText(ex));
            }
        }

        public void Update(bool useFullScan, SqlConnection conn)
        {
            try
            {
                string query = string.Empty;
                query = String.Format(UpdateStatistics,
                                      SQLHelpers.CreateSafeDatabaseName(DatabaseName),
                                      String.Format("{0}.{1}",
                                                              SQLHelpers.CreateSafeDatabaseName(SchemaName),
                                                              SQLHelpers.CreateSafeDatabaseName(TableName)),
                                      SQLHelpers.CreateSafeDatabaseName(Name),
                                      useFullScan ? UseFullScan : NoFullScan);

                if (!string.IsNullOrEmpty(query))
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        using (cmd = new SqlCommand(query, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandTimeout = 0;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                RefreshStatistics(conn);
            }
            catch (Exception ex)
            {
                ProductConstants.globalErrorReports.Add(string.Format("Error updating statistics for index {0}.{1}.{2}.{3}",
                                                                       DatabaseName, SchemaName, TableName, Name),
                                                        Helpers.GetCombinedExceptionText(ex));
            }            
        }

        public void RefreshStatistics(SqlConnection conn)
        {
            int colRows = 0;
            int colModifiedRows = 1;
            try
            {
                string query = string.Empty;
                query = String.Format(RefreshRows,
                                      SQLHelpers.CreateSafeDatabaseName(DatabaseName),
                                      Id,
                                      TableId);

                if (!string.IsNullOrEmpty(query))
                {
                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 0;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (!reader.IsDBNull(colRows))
                                {
                                    _rows = Convert.ToInt64(reader.GetValue(colRows));
                                }
                                if (!reader.IsDBNull(colModifiedRows))
                                {
                                    _modifiedrows = Convert.ToInt64(reader.GetValue(colModifiedRows));
                                }
                            }
                        }
                    }
                }
                GetStatistics(conn, _avgDensity);
            }
            catch (Exception ex)
            {
                ProductConstants.globalErrorReports.Add(string.Format("Error refreshing index statistics for {0}.{1}.{2}.{3}",
                                                                       DatabaseName, SchemaName, TableName, Name),
                                                        Helpers.GetCombinedExceptionText(ex));
            }
            
        }

        public void Analyze(SqlConnection conn)
        {
            int colPages = 0;
            int colFragmentation = 0;
            int colIsDisabled = 0;
            try
            {
                string query = string.Empty;
                if (ServerVersion == ServerVersionType.SQL2000)
                {
                    query = String.Format(AnalyzeFast2000,
                                          SQLHelpers.CreateSafeDatabaseName(DatabaseName),
                                          SQLHelpers.CreateSafeString(String.Format("{0}.{1}",
                                                                                    SQLHelpers.
                                                                                        CreateSafeDatabaseName(
                                                                                        SchemaName),
                                                                                    SQLHelpers.
                                                                                        CreateSafeDatabaseName(
                                                                                        TableName))),
                                          SQLHelpers.CreateSafeString(Name));
                    colPages = Pages2000;
                    colFragmentation = AverageFragmentation2000;
                    colIsDisabled = IsDisabled2000;
                }
                else if (ServerVersion == ServerVersionType.SQL2005)
                {
                    query = String.Format(AnalyzeFast2005,
                                          SQLHelpers.CreateSafeDatabaseName(DatabaseName),
                                          DatabaseId,
                                          TableId,
                                          Id);
                    colPages = Pages2005;
                    colFragmentation = AverageFragmentation2005;
                    colIsDisabled = IsDisabled2005;
                }

                if (!string.IsNullOrEmpty(query))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 0;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (!reader.IsDBNull(colPages))
                                    _countPages = Convert.ToInt64(reader.GetValue(colPages));
                                if (!reader.IsDBNull(colFragmentation))
                                    _avgFragPercent = reader.GetDouble(colFragmentation)/100;
                                if (colIsDisabled >= 0)
                                {
                                    if (!reader.IsDBNull(colIsDisabled))
                                        _isDisabled = SQLHelpers.ByteToBool(reader, colIsDisabled);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProductConstants.globalErrorReports.Add(string.Format("Error analyzing index {0}.{1}.{2}.{3}",
                                                                       DatabaseName, SchemaName, TableName, Name),
                                                        Helpers.GetCombinedExceptionText(ex));
            }
        }

    }
}
