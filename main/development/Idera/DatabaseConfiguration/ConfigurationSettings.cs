using System;
using Idera.SqlAdminToolset.Core;
using System.Xml.Serialization;
using System.Reflection;

namespace Idera.SqlAdminToolset.DatabaseConfiguration
{
    public class ConfigurationSettings
    {
        #region variables

        #region Database Information (read-only data)

        private ServerInformation _Server;
        private string _DatabaseName;
        private string _DatabaseOwner;
        private DateTime _DateCreated;
        private string _Collation;
        private double _Size;
        private int _NumberOfUsers;
        private bool _IsSystemDatabase;
        private string _State;
        private string _CompatibilityLevel;
        private DataSource _Source = DataSource.LiveData;
        private DateTime _DateCaptured;
        private string _ServerName = string.Empty;
        private Exception _DataException;
        private string _ServerVersion;

        public string ServerVersion
        {
            get { return _ServerVersion; }
            set { _ServerVersion = value; }
        }

        #endregion

        #region ConfigurationData

        //Auto
        private ConfigurationData _AutoClose = new ConfigurationData("Auto Close", "AUTO_CLOSE", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.Auto);
        private ConfigurationData _AutoCreateStatistics = new ConfigurationData("Auto Create Statistics", "AUTO_CREATE_STATISTICS", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.Auto);
        private ConfigurationData _AutoUpdateStatistics = new ConfigurationData("Auto Update Statistics", "AUTO_UPDATE_STATISTICS", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.Auto);
        private ConfigurationData _AutoUpdateStatisticsAsync = new ConfigurationData("Auto Update Statistics Asynchronously", "AUTO_UPDATE_STATISTICS_ASYNC", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.Auto);
        private ConfigurationData _AutoShrink = new ConfigurationData("Auto Shrink", "AUTO_SHRINK", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.Auto);

        //Cursor
        private ConfigurationData _CursorCloseOnCommit = new ConfigurationData("Close Cursor on Commit Enabled", "CURSOR_CLOSE_ON_COMMIT", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.Cursor);
        private ConfigurationData _CursorDefaultScope = new ConfigurationData("Default Cursor", "CURSOR_DEFAULT", DatabaseConfigurationHelper.ValidCursorDefaultValues, OptionGroup.Cursor);
        //Availability
        private ConfigurationData _DataAccess = new ConfigurationData("Database Mode", DatabaseConfigurationHelper.ValidDatabaseIsReadOnlyModeValues, OptionGroup.Availability);
        private ConfigurationData _RestrictAccess = new ConfigurationData("Restrict Access", DatabaseConfigurationHelper.ValidDatabaseAccessModeValues, OptionGroup.Availability);
        //Date Correlation
        private ConfigurationData _DateCorrelationOptimizationEnabled = new ConfigurationData("Date Correlation Optimization Enabled", "DATE_CORRELATION_OPTIMIZATION", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.DateCorrelationOptimization);
        //External Access
        private ConfigurationData _DatabaseChaining = new ConfigurationData("Cross-database Ownership Chaining Enabled", "DB_CHAINING", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.ExternalAccess);
        private ConfigurationData _IsTrustWorthy = new ConfigurationData("Trustworthy", "TRUSTWORTHY", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.ExternalAccess);
        //Parameterization
        private ConfigurationData _Parameterization = new ConfigurationData("Parameterization", "PARAMETERIZATION", DatabaseConfigurationHelper.ValidParameterizationValues, OptionGroup.Parameterization);
        //Recovery
        private ConfigurationData _Recovery = new ConfigurationData("Recovery Model", "RECOVERY", DatabaseConfigurationHelper.ValidRecoveryMode, OptionGroup.Recovery);
        private ConfigurationData _PageVerifyMode = new ConfigurationData("Page Verify", "PAGE_VERIFY", DatabaseConfigurationHelper.ValidPageVerifyOptions, OptionGroup.Recovery);
        private ConfigurationData _TornPageDetection = new ConfigurationData("Torn Page Detection", "TORN_PAGE_DETECTION", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.Recovery);
        //Service Broker
        private ConfigurationData _EnableBroker = new ConfigurationData("Service Broker", DatabaseConfigurationHelper.ValidEnableBrokerOptions, OptionGroup.ServiceBroker);
        //Isolation
        private ConfigurationData _AllowSnapshotIsolation = new ConfigurationData("Allow Snapshot Isolation", "ALLOW_SNAPSHOT_ISOLATION", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.SnapshotIsolation);

        //SQLADMI-350
        private ConfigurationData _ReadCommittedSnapshot = new ConfigurationData("Read Committed Snapshot", "READ_COMMITTED_SNAPSHOT", DatabaseConfigurationHelper.ValidReadIsolationOptions, OptionGroup.SnapshotIsolation);

        //SQL
        private ConfigurationData _AnsiNullDefault = new ConfigurationData("ANSI NULL Default", "ANSI_NULL_DEFAULT", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.Sql);
        private ConfigurationData _AnsiNullsEnabled = new ConfigurationData("ANSI NULLS Enabled", "ANSI_NULLS", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.Sql);
        private ConfigurationData _AnsiPaddingEnabled = new ConfigurationData("ANSI Padding Enabled", "ANSI_PADDING", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.Sql);
        private ConfigurationData _AnsiWarningsEnabled = new ConfigurationData("ANSI Warnings Enabled", "ANSI_WARNINGS", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.Sql);
        private ConfigurationData _ArithmeticAbortEnabled = new ConfigurationData("Arithmentic Abort Enabled", "ARITHABORT", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.Sql);
        private ConfigurationData _ConcatenatedNullYieldsNull = new ConfigurationData("Concatenate Null Yields Null", "CONCAT_NULL_YIELDS_NULL", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.Sql);
        private ConfigurationData _QuotedIdentifiersEnabled = new ConfigurationData("Quoted Identifiers Enabled", "QUOTED_IDENTIFIER", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.Sql);
        private ConfigurationData _NumericRoundAbort = new ConfigurationData("Numeric Round-Abort", "NUMERIC_ROUNDABORT", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.Sql);
        private ConfigurationData _RecursiveTriggersEnabled = new ConfigurationData("Recursive Triggers Enabled", "RECURSIVE_TRIGGERS", DatabaseConfigurationHelper.ValidBooleanValues, OptionGroup.Sql);
        
        #endregion

        #endregion

        #region Accessors

        #region Database Information

        [XmlIgnore]
        public ServerInformation Server
        {
            get { return _Server; }
            set
            {
                _Server = value;
                if (_Server != null)
                {
                    _ServerName = _Server.Name;
                }
            }
        }

        public string DatabaseName
        {
            get { return _DatabaseName; }
            set { _DatabaseName = value; }
        }

        public string DatabaseOwner
        {
            get { return _DatabaseOwner; }
            set { _DatabaseOwner = value; }
        }

        public DateTime DateCreated
        {
            get { return _DateCreated; }
            set { _DateCreated = value; }
        }

        public string Collation
        {
            get { return _Collation; }
            set { _Collation = value; }
        }

        /// <summary>
        /// Database size (in megabytes)
        /// </summary>
        public double Size
        {
            get { return _Size; }
            set { _Size = value; }
        }

        public int NumberOfUsers
        {
            get { return _NumberOfUsers; }
            set { _NumberOfUsers = value; }
        }

        public bool IsSystemDatabase
        {
            get { return _IsSystemDatabase; }
            set { _IsSystemDatabase = value; }
        }

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        public string CompatibilityLevel
        {
            get { return _CompatibilityLevel; }
            set { _CompatibilityLevel = value; }
        }

        public DataSource Source
        {
            get { return _Source; }
            set { _Source = value; }
        }

        public DateTime DateCaptured
        {
            get { return _DateCaptured; }
            set { _DateCaptured = value; }
        }

        /// <summary>
        /// Server name.
        /// </summary>
        public string ServerName
        {
            get { return _ServerName; }
            set
            {
                if (_Server != null && value != _Server.Name)
                {
                    throw new ArgumentException("Server name cannot be different than contained Server object");
                }
                _ServerName = value;

            }
        }

        /// <summary>
        /// Exception generated while gathering data.  Null if no exception found.
        /// </summary>
        [XmlIgnore]
        public Exception DataException
        {
            get { return _DataException; }
            set { _DataException = value; }
        }

        #endregion

        #region Auto

        public ConfigurationData AutoClose
        {
            get { return _AutoClose; }
            set { _AutoClose = value; }
        }

        public ConfigurationData AutoCreateStatistics
        {
            get { return _AutoCreateStatistics; }
            set { _AutoCreateStatistics = value; }
        }

        public ConfigurationData AutoShrink
        {
            get { return _AutoShrink; }
            set { _AutoShrink = value; }
        }

        public ConfigurationData AutoUpdateStatistics
        {
            get { return _AutoUpdateStatistics; }
            set { _AutoUpdateStatistics = value; }
        }

        public ConfigurationData AutoUpdateStatisticsAsync
        {
            get { return _AutoUpdateStatisticsAsync; }
            set { _AutoUpdateStatisticsAsync = value; }
        }

        #endregion

        #region Cursor

        public ConfigurationData CursorCloseOnCommit
        {
            get { return _CursorCloseOnCommit; }
            set { _CursorCloseOnCommit = value; }
        }

        public ConfigurationData CursorDefaultScope
        {
            get { return _CursorDefaultScope; }
            set { _CursorDefaultScope = value; }
        }

        #endregion

        #region Availability

        public ConfigurationData DataAccess
        {
            get { return _DataAccess; }
            set { _DataAccess = value; }
        }

        public ConfigurationData RestrictAccess
        {
            get { return _RestrictAccess; }
            set { _RestrictAccess = value; }
        }

        #endregion

        #region Date Correlation

        public ConfigurationData DateCorrelationOptimizationEnabled
        {
            get { return _DateCorrelationOptimizationEnabled; }
            set { _DateCorrelationOptimizationEnabled = value; }
        }

        #endregion

        #region External Access

        public ConfigurationData DatabaseChaining
        {
            get { return _DatabaseChaining; }
            set { _DatabaseChaining = value; }
        }

        public ConfigurationData IsTrustWorthy
        {
            get { return _IsTrustWorthy; }
            set { _IsTrustWorthy = value; }
        }

        #endregion

        #region Parameterization

        public ConfigurationData Parameterization
        {
            get { return _Parameterization; }
            set { _Parameterization = value; }
        }

        #endregion

        #region Recovery

        public ConfigurationData PageVerifyMode
        {
            get { return _PageVerifyMode; }
            set { _PageVerifyMode = value; }
        }

        public ConfigurationData Recovery
        {
            get { return _Recovery; }
            set { _Recovery = value; }
        }

        /// <summary>
        /// If ON is specified, incomplete pages can be detected. The default is ON. 
        /// </summary>
        /// <remarks>
        /// SQL Server 2000-only setting. 
        /// </remarks>
        public ConfigurationData TornPageDetection
        {
            get { return _TornPageDetection; }
            set { _TornPageDetection = value; }
        }

        #endregion

        #region Service Broker

        public ConfigurationData EnableBroker
        {
            get { return _EnableBroker; }
            set { _EnableBroker = value; }
        }

        #endregion

        #region Isolation

        public ConfigurationData AllowSnapshotIsolation
        {
            get { return _AllowSnapshotIsolation; }
            set { _AllowSnapshotIsolation = value; }
        }

        //SQLADMI-350
        public ConfigurationData ReadCommittedSnapshot
        {
            get { return _ReadCommittedSnapshot; }
            set { _ReadCommittedSnapshot = value; }
        }

        #endregion

        #region SQL

        public ConfigurationData AnsiNullDefault
        {
            get { return _AnsiNullDefault; }
            set { _AnsiNullDefault = value; }
        }

        public ConfigurationData AnsiNullsEnabled
        {
            get { return _AnsiNullsEnabled; }
            set { _AnsiNullsEnabled = value; }
        }

        public ConfigurationData AnsiPaddingEnabled
        {
            get { return _AnsiPaddingEnabled; }
            set { _AnsiPaddingEnabled = value; }
        }

        public ConfigurationData AnsiWarningsEnabled
        {
            get { return _AnsiWarningsEnabled; }
            set { _AnsiWarningsEnabled = value; }
        }

        public ConfigurationData ArithmeticAbortEnabled
        {
            get { return _ArithmeticAbortEnabled; }
            set { _ArithmeticAbortEnabled = value; }
        }

        public ConfigurationData ConcatenatedNullYieldsNull
        {
            get { return _ConcatenatedNullYieldsNull; }
            set { _ConcatenatedNullYieldsNull = value; }
        }

        public ConfigurationData NumericRoundAbort
        {
            get { return _NumericRoundAbort; }
            set { _NumericRoundAbort = value; }
        }

        public ConfigurationData QuotedIdentifiersEnabled
        {
            get { return _QuotedIdentifiersEnabled; }
            set { _QuotedIdentifiersEnabled = value; }
        }

        public ConfigurationData RecursiveTriggersEnabled
        {
            get { return _RecursiveTriggersEnabled; }
            set { _RecursiveTriggersEnabled = value; }
        }

        /// <summary>
        /// Key used to identify server/database combination.
        /// </summary>
        public string Key
        {
            get
            {
                if (_Source == DataSource.LiveData)
                {
                    return string.Format("{0}.{1}", _Server.Name, _DatabaseName);
                }
                else
                {
                    return string.Format("Snapshot {0}.{1} ({2})", _ServerName, _DatabaseName, _DateCaptured);
                }
            }
        }

        #endregion

        #endregion

        public override string ToString()
        {
            return string.Format("{0} - {1}", _ServerName, _DatabaseName);
        }

        /// <summary>
        /// Returns a contained ConfigurationData object based on its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ConfigurationData GetValueByName(string name)
        {

            foreach (PropertyInfo _Property in this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                ConfigurationData _Data = _Property.GetValue(this, null) as ConfigurationData;
                if (_Data != null)
                {
                    if (_Data.Name == name)
                    {
                        return _Data;
                    }
                }
            }
            return null;
        }
    }

    /// <summary>
    /// Grouping that the options fall under.
    /// </summary>
    public enum OptionGroup
    {
        /// <summary>
        /// No group specified
        /// </summary>
        DatabaseInformation = 0,
        /// <summary>
        /// Control certain automatic behaviors
        /// </summary>
        Auto = 1,
        /// <summary>
        /// Control cursor behavior and scope. 
        /// </summary>
        Cursor = 2,
        /// <summary>
        /// Control whether the database is online or offline, who can connect to the database, and whether the database is in read-only mode.
        /// </summary>
        Availability = 3,
        /// <summary>
        /// Control the date_correlation_optimization option.
        /// </summary>
        DateCorrelationOptimization = 4,
        /// <summary>
        /// Control whether the database can be accessed by external resources such as objects from another database.
        /// </summary>
        ExternalAccess = 5,
        /// <summary>
        /// Controls the parameterization option
        /// </summary>
        Parameterization = 6,
        /// <summary>
        /// Control the recovery model for the database.
        /// </summary>
        Recovery = 7,
        /// <summary>
        /// Control Service Broker options.
        /// </summary>
        ServiceBroker = 8,
        /// <summary>
        /// Determine the transaction isolation level.
        /// </summary>
        SnapshotIsolation = 9,
        /// <summary>
        /// Control ANSI-compliance options
        /// </summary>
        Sql = 10
    }

    /// <summary>
    /// Data source
    /// </summary>
    public enum DataSource
    {
        /// <summary>
        /// Loaded directly from the server.
        /// </summary>
        LiveData,
        /// <summary>
        /// Snapshot data.
        /// </summary>
        Snapshot,
    }
}