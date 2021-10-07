namespace Idera.SqlAdminToolset.DatabaseConfiguration
{
    /// <summary>
    /// Fake class to provide column name linkage for report.
    /// </summary>
    public class DatabaseConfiguration_ReportData
    {
        public DatabaseConfiguration_ReportData() { }

        public DatabaseConfiguration_ReportData(string key, string database, string propertyName, string propertyValue, string grouping)
        {
            _Key = key;
            _Database = database;
            _Name = propertyName;
            _Value = propertyValue;
            _Grouping = grouping;
        }

        public string SQLServer
        {
            get { return string.Empty; }
        }

        private string _Key = string.Empty;
        public string Key
        {
            get { return _Key; }
        }

        private string _Database = string.Empty;
        public string Database
        {
            get { return _Database; }
        }

        private string _Name = string.Empty;
        public string Name
        {
            get { return _Name; }
        }

        private string _Value = string.Empty;
        public string Value
        {
            get { return _Value; }
        }

        private string _Grouping = string.Empty;
        public string Grouping
        {
            get { return _Grouping; }
        }
    }
}