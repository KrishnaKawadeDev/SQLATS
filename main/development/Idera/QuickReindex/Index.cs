using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;
using System.Data.SqlClient;
using System.Data;

namespace Idera.SqlAdminToolset.QuickReindex
{
    public class Index : DTIRecord
    {
        private static SqlCommand Command = null;
        private bool _isSystem;
        private bool _isColumnStore;
        private bool _isClustered;
        private string _fillFactor;
        private bool _isDisabled;
        private long _countPages;
        private double _avgFragPercent;

        private const string AnalyzeFast2000 = "use {0} DBCC SHOWCONTIG ( {1}, {2} ) WITH FAST,TABLERESULTS";
        private const string FillFactorForIndex = "use {0} select fill_factor from sys.indexes where object_id={1} and index_id={2}";
        private const string FillFactorForIndex2000 = "use {0} select OrigFillFactor as fill_factor from sysindexes where id={1} and indid={2}";
        private const string AnalyzeFast2005 =   "use {0} select avg_record_size_in_bytes," +
                                                        "        avg_page_space_used_in_percent," +
                                                        "        page_count, " +
                                                        "        avg_fragmentation_in_percent, " +
                                                        "        CAST(i.is_disabled as tinyint) " +
                                                        "from sys.dm_db_index_physical_stats({1}, {2}, {3}, NULL,'LIMITED') " +
                                                        "left join sys.indexes i on (i.index_id = {3} and i.object_id = {2})";

        private const string Reorganize2000 = "DBCC INDEXDEFRAG ({0}, {1}, {2})";
        private const string Reorganize2005 = "ALTER INDEX {0} ON {1}.{2}.{3} REORGANIZE";
        private const string Rebuild2000 = "DBCC DBREINDEX ({0}, {1}{2}";
        //RG: Added two addition parameters to support ONLINE and SORT_IN_TEMP
        private const string Rebuild2005 = "ALTER INDEX {0} ON {1}.{2}.{3} REBUILD WITH ({4} {5} MAXDOP = {6} {7})";
        //RG: Added constants for ONLINE ON|OFF and SORT_IN_TEMP ON|OFF
        private const string OnlineOff = ", ONLINE = OFF";
        private const string OnlineOn = ", ONLINE = ON";
        private const string SortInTempdbOff = "SORT_IN_TEMPDB = OFF,";
        private const string SortInTempdbOn = "SORT_IN_TEMPDB = ON,";

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

        public static void Cancel()
        {
            if(Command != null)
            {
                Command.Cancel();
            }
        }

        public Index()
        {
            _avgFragPercent = -1.0;
        }

        public override string ToString()
        {
            return Name;
        }

        public bool IsSystem
        {
            get { return _isSystem; }
            set { _isSystem = value; }
        }

        public string FillFactor
        {
            get { return _fillFactor; }
            set { _fillFactor = value; }
        }

        public bool IsColumnStore
        {
            get { return _isColumnStore; }
            set { _isColumnStore = value; }
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
            get { return _avgFragPercent; }
            set { _avgFragPercent = value; }
        }

        public bool IsFiltered
        {
            get
            {
                bool filtered = false;
                if (ProductConstants.globalHideBasedOnPageThreshold && CountPages < ProductConstants.globalPageThreshold)
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

        public int IsFillFactorChangable(SqlConnection conn)
        {
            string current_fill_factor = string.Empty;
            string query =string.Empty;
            if (ServerVersion == ServerVersionType.SQL2000)
            {
                query = String.Format(FillFactorForIndex2000,
                                          SQLHelpers.CreateSafeDatabaseName(DatabaseName),
                                          TableId.ToString(), Id.ToString());
            }
            else
            {
                query = String.Format(FillFactorForIndex,
                                          SQLHelpers.CreateSafeDatabaseName(DatabaseName),
                                          TableId.ToString(), Id.ToString());
            }
            using ( SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandTimeout = 0;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        current_fill_factor = reader["fill_factor"].ToString();
                    }
                }
            }
            if(_fillFactor == "Not Set")
                return string.Compare(current_fill_factor, "0");
            else
                return string.Compare(current_fill_factor, _fillFactor);
        }

        public void Analyze(SqlConnection conn)
        {
            int colPages = 0; 
            int colFragmentation = 0;
            int colIsDisabled = 0;
            _avgFragPercent = -1.0;
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
                else
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
                                    _avgFragPercent = reader.GetDouble(colFragmentation);
                                if(colIsDisabled >= 0)
                                {
                                    if (!reader.IsDBNull(colIsDisabled))
                                        _isDisabled = SQLHelpers.ByteToBool(reader, colIsDisabled);                                            
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ProductConstants.globalErrorReports.Add(string.Format("Error analyzing index {0}.{1}.{2}.{3}",
                                                                       DatabaseName, SchemaName, TableName, Name),
                                                        Helpers.GetCombinedExceptionText(ex));                
            }
        }

        public void Reorganize(SqlConnection conn)
        {
            string query = string.Empty;
            try
            {
                if (ServerVersion == ServerVersionType.SQL2000)
                {
                    query = String.Format(Reorganize2000,
                                          SQLHelpers.CreateSafeDatabaseName(DatabaseName),
                                          SQLHelpers.CreateSafeString(String.Format("{0}.{1}",
                                                                                    SQLHelpers.CreateSafeDatabaseName(
                                                                                        SchemaName),
                                                                                    SQLHelpers.CreateSafeDatabaseName(
                                                                                        TableName))),
                                          SQLHelpers.CreateSafeString(Name));
                }
                else
                {
                    query = String.Format(Reorganize2005,
                                          SQLHelpers.CreateSafeDatabaseName(Name),
                                          SQLHelpers.CreateSafeDatabaseName(DatabaseName),
                                          SQLHelpers.CreateSafeDatabaseName(SchemaName),
                                          SQLHelpers.CreateSafeDatabaseName(TableName));
                }

                if (!string.IsNullOrEmpty(query))
                {
                    using (Command = new SqlCommand(query, conn))
                    {
                        Command.CommandType = CommandType.Text;
                        Command.CommandTimeout = 0;
                        Command.ExecuteNonQuery();
                    }
                    Command = null;
                    Analyze(conn);
                 
                }
            }
            catch (Exception ex)
            {
                ProductConstants.globalErrorReports.Add(string.Format("Error Reorganizing index {0}.{1}.{2}.{3}", 
                                                                       DatabaseName, SchemaName, TableName, Name),
                                                        Helpers.GetCombinedExceptionText(ex));
            }
        }

        public void Rebuild(bool OnLine, bool IsSortInTemp, bool IsColumnStore, SqlConnection conn)
        {
            string query;
            try
            {
                string fill_factor_option="";
                if (ServerVersion == ServerVersionType.SQL2000)
                {
                    if (ProductConstants.fillFactor != -1)
                        fill_factor_option = ", " + ProductConstants.fillFactor + ")";
                    else
                        fill_factor_option = ")";
                    query = String.Format(Rebuild2000,
                                          SQLHelpers.CreateSafeString(String.Format("{0}.{1}.{2}",
                                                                                    SQLHelpers.CreateSafeDatabaseName(
                                                                                        DatabaseName),
                                                                                    SQLHelpers.CreateSafeDatabaseName(
                                                                                        SchemaName),
                                                                                    SQLHelpers.CreateSafeDatabaseName(
                                                                                        TableName))),
                                          SQLHelpers.CreateSafeString(Name),
                                          fill_factor_option);
                }
                else
                {
                    string sortInTempdbCmd = SortInTempdbOff;
                    string onLineCmd = OnlineOff;
                    if (IsSortInTemp)
                    {
                        sortInTempdbCmd = SortInTempdbOn;
                    }
                    if (IsColumnStore)
                    {
                        sortInTempdbCmd = "";
                    }
                    if (OnLine)
                    {
                        onLineCmd = OnlineOn;
                    }
                    
                    if (ProductConstants.fillFactor != -1)
                        fill_factor_option = "FILLFACTOR = " + ProductConstants.fillFactor + " ,";
                    if (EngineEdition == EngineEdition.Enterprise)
                    {
                       query = String.Format(Rebuild2005,
                                             SQLHelpers.CreateSafeDatabaseName(Name),
                                             SQLHelpers.CreateSafeDatabaseName(DatabaseName),
                                             SQLHelpers.CreateSafeDatabaseName(SchemaName),
                                             SQLHelpers.CreateSafeDatabaseName(TableName),
                                             sortInTempdbCmd,
                                             fill_factor_option,
                                             ProductConstants.maxDOP,
                                             onLineCmd);
                    }
                    else
                    {
                       query = String.Format(Rebuild2005,
                                             SQLHelpers.CreateSafeDatabaseName(Name),
                                             SQLHelpers.CreateSafeDatabaseName(DatabaseName),
                                             SQLHelpers.CreateSafeDatabaseName(SchemaName),
                                             SQLHelpers.CreateSafeDatabaseName(TableName),
                                             sortInTempdbCmd,
                                             fill_factor_option,
                                             ProductConstants.maxDOP,
                                             "");
                    }
                }

                if (!string.IsNullOrEmpty(query))
                {
                    using (Command = new SqlCommand(query, conn))
                    {
                        Command.CommandType = CommandType.Text;
                        Command.CommandTimeout = 0;
                        Command.ExecuteNonQuery();
                    }
                    Command = null;
                    Analyze(conn);
                }
            }
            catch(Exception ex)
            {
                ProductConstants.globalErrorReports.Add(string.Format("Error Rebuilding index {0}.{1}.{2}.{3}",
                                                                      DatabaseName, SchemaName, TableName, Name),
                                                       Helpers.GetCombinedExceptionText(ex));
            }
        }
    }
}
