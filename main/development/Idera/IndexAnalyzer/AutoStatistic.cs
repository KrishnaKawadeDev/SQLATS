using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;
using System.Data.SqlClient;
using System.Data;

namespace Idera.SqlAdminToolset.IndexAnalyzer
{
    public class AutoStatistic : DTIRecord
    {
        private bool _isSystem;
        private bool _isClustered;
        private long _countPages;
        private double _avgFragPercent;         // Fragmentation 
        private double _avgDensity;             // 1/selectivity
        private string _fillFactor;
        private int _seeks;
        private int _scans;
        private int _lookups;

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
        public int Seeks
        {
            get { return _seeks; }
            set { _seeks = value; }
        }
        public int Scans
        {
            get { return _scans; }
            set { _scans = value; }
        }
        public int Lookups
        {
            get { return _lookups; }
            set { _lookups = value; }
        }
        public int TotalAccess
        {
            get { return (_seeks + _scans + _lookups); }           
        }

        private const string AnalyzeFast2000 = "use {0} DBCC SHOWCONTIG ( {1}, {2} ) WITH FAST,TABLERESULTS";

        private const string AnalyzePrefix2005 = "use {0}  " +
                                                 "declare @indexId int  " +
                                                 "declare @dbId int  " +
                                                 "declare @tblId int  " +
                                                 "select @dbId = ISNULL(DB_ID(),-1) " +
                                                 "if @dbId=-1 " +
                                                 "   RAISERROR( N'Database does not exist: %s', 16, 1, '{0}' ) " +
                                                 "else " +
                                                 "begin " +
                                                 "   select @tblId = ISNULL(OBJECT_ID({1}) ,-1) " +
                                                 "   if @tblId=-1 " +
                                                 "      RAISERROR( N'Table does not exist: %s', 16, 1, {1} ) " +
                                                 "   else " +
                                                 "   begin " +
                                                 "      select @indexId=indid from sysindexes where id=@tblId and name={2}  " +
                                                 "      if @tblId=-1 " +
                                                 "      RAISERROR( N'Index does not exist: %s', 16, 1, {2} ) " +
                                                 "   else " +
                                                 "   begin ";

        private const string AnalyzeSuffix2005 = " END END END";
        private const string AnalyzeFast2005 = AnalyzePrefix2005 +
                                                        "select avg_record_size_in_bytes," +
                                                        "        avg_page_space_used_in_percent," +
                                                        "        page_count, " +
                                                        "        avg_fragmentation_in_percent " +
                                                        "from sys.dm_db_index_physical_stats(@dbId, @tblId, @indexId,NULL,'LIMITED') " +
                                                        AnalyzeSuffix2005;


        private const int AverageRecordSize2000 = 9;
        private const int AveragePageDensity2000 = 14;
        private const int Pages2000 = 5;
        private const int AverageFragmentation2000 = 18;
        private const int AverageRecordSize2005 = 0;
        private const int AveragePageDensity2005 = 1;
        private const int Pages2005 = 2;
        private const int AverageFragmentation2005 = 3;

        public AutoStatistic()
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
        public bool IsClustered
        {
            get { return _isClustered; }
            set { _isClustered = value; }
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
 

        public void Analyze(bool afterDefrag, SqlConnection conn)
        {
            long cPage = 0;
            double frag = 0;
            int colPages = 0; 
            int colFragmentation = 0;
            try
            {
//                if (CountPages > 1)
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
                    }
                    else if (ServerVersion == ServerVersionType.SQL2005)
                    {
                        query = String.Format(AnalyzeFast2005,
                                              SQLHelpers.CreateSafeDatabaseName(DatabaseName),
                                              SQLHelpers.CreateSafeString(String.Format("{0}.{1}.{2}",
                                                                                        SQLHelpers.
                                                                                            CreateSafeDatabaseName(
                                                                                            DatabaseName),
                                                                                        SQLHelpers.
                                                                                            CreateSafeDatabaseName(
                                                                                            SchemaName),
                                                                                        SQLHelpers.
                                                                                            CreateSafeDatabaseName(
                                                                                            TableName))),
                                              SQLHelpers.CreateSafeString(Name));
                        colPages = Pages2005;
                        colFragmentation = AverageFragmentation2005;
                    }

                    if (!string.IsNullOrEmpty(query))
                    {
                        //using (
                        //    SqlConnection conn =
                        //        new SqlConnection(Connection.CreateConnectionString(ServerName, DatabaseName, ProductConstants.globalSqlCredentials)))
                        //{
                        //    conn.Open();
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandTimeout = ToolsetOptions.commandTimeout;
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        if (!reader.IsDBNull(colPages))
                                            cPage = Convert.ToInt64(reader.GetValue(colPages));
                                        if (!reader.IsDBNull(colFragmentation))
                                            frag = reader.GetDouble(colFragmentation);
                                    }
                                }
                            }
                        ///}
                    }
                }
               
                _countPages = cPage;
                _avgFragPercent = frag;
                }
            catch(Exception ex)
            {
                ProductConstants.globalErrorReports.Add(string.Format("Error analyzing index {0}.{1}.{2}.{3}",
                                                                       DatabaseName, SchemaName, TableName, Name),
                                                        Helpers.GetCombinedExceptionText(ex));                
            }
        }

    }
}
