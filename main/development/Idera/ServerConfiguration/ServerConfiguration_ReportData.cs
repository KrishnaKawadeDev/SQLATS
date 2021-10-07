namespace Idera.SqlAdminToolset.ServerConfiguration
{
    /// <summary>
    /// Fake class to provide column name linkage for report.
    /// </summary>
    public class ServerConfiguration_ReportData
    {
        public ServerConfiguration_ReportData() { }

        public ServerConfiguration_ReportData(string sqlServer, string propertyName, string propertyValue, string grouping)
        {
            _SqlServer = sqlServer;
            _Name = propertyName;
            _Value = propertyValue;
            _Grouping = grouping;
        }

        private string _SqlServer = string.Empty;
        public string SQLServer
        {
            get { return _SqlServer; }
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

        public string Description
        {
            get { return string.Empty; }
        }

        private string _Grouping = string.Empty;
        public string Grouping
        {
            get { return _Grouping; }
        }
    }
}