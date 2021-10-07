using System;
using Idera.SqlAdminToolset.Core;
using System.Xml.Serialization;
using System.Reflection;

namespace Idera.SqlAdminToolset.ServerConfiguration
{
    public class ConfigurationSettings
    {
        #region variables

        private ConfigurationData _AdHocDistributedQueries;
        private ConfigurationData _AffinityIOMask;
        private ConfigurationData _AffinityMask;
        private ConfigurationData _AgentXPs;
        private ConfigurationData _AllowUpdates;
        private ConfigurationData _AweEnabled;
        private ConfigurationData _BlockedProcessThreshold;
        private ConfigurationData _C2AuditMode;
        private ConfigurationData _ClrEnabled;
        private ConfigurationData _CommonCriteriaComplianceEnabled;
        private ConfigurationData _CostThresholdForParallelism;
        private ConfigurationData _CrossDbOwnershipChaining;
        private ConfigurationData _CursorThreshold;
        private ConfigurationData _DatabaseMailXPs;
        private ConfigurationData _DefaultFullTextLanguage;
        private ConfigurationData _DefaultLanguage;
        private ConfigurationData _DefaultTraceEnabled;
        private ConfigurationData _DisallowResultsFromTriggers;
        private ConfigurationData _FillFactorPercentage;
        private ConfigurationData _FullTextCrawlBandwidthMaximum;
        private ConfigurationData _FullTextCrawlBandwidthReserved;
        private ConfigurationData _FullTextNotificationsBandwidthMaximum;
        private ConfigurationData _FullTextNotificationsBandwidthReserved;
        private ConfigurationData _MemoryForIndexCreate;
        private ConfigurationData _InDoubtTransactionResolution;
        private ConfigurationData _LightweightPooling;
        private ConfigurationData _Locks;
        private ConfigurationData _MaximumDegreeOfParallelism;
        private ConfigurationData _MaximumFullTextCrawlRange;
        private ConfigurationData _MaximumServerMemory;
        private ConfigurationData _MaximumTextFieldSizeInReplication;
        private ConfigurationData _MaximumWorkerThreads;
        private ConfigurationData _MediaRetentionPeriod;
        private ConfigurationData _MinimumMemoryPerQuery;
        private ConfigurationData _MinimumServerMemory;
        private ConfigurationData _NestedTriggers;
        private ConfigurationData _NetworkPacketSize;
        private ConfigurationData _OleAutomationProcedures;
        private ConfigurationData _OpenDatabaseObjects;
        private ConfigurationData _ProtocolHandlerTimeout;
        private ConfigurationData _PrecomputedRank;
        private ConfigurationData _PriorityBoost;
        private ConfigurationData _QueryGovernorCostLimit;
        private ConfigurationData _QueryMemoryWaitTimeMaximum;
        private ConfigurationData _RecoveryIntervalMaximum;
        private ConfigurationData _RemoteAccessAllowed;
        private ConfigurationData _DedicatedRemoteAdminConnectionsAllowed;
        private ConfigurationData _RemoteLoginTimeout;
        private ConfigurationData _CreateDtcTransactionForRemoteProcedures;
        private ConfigurationData _RemoteQueryTimeout;
        private ConfigurationData _EnableReplicationXPs;
        private ConfigurationData _ScanForStartupProcs;
        private ConfigurationData _AllowServerTriggerRecursion;
        private ConfigurationData _SetWorkingSetSize;
        private ConfigurationData _ShowAdvancedOptions;
        private ConfigurationData _EnableSmoAndDmoXPs;
        private ConfigurationData _EnableSqlMailXPs;
        private ConfigurationData _TransformNoiseWordsForFullTextQuery;
        private ConfigurationData _TwoDigitYearCutoff;
        private ConfigurationData _UserConnectionsCountAllowed;
        private ConfigurationData _UserOptions;
        private ConfigurationData _EnableWebAssistantProcedures;
        private ConfigurationData _EnableXpCmdshell;
        private ConfigurationData _AuditLevel;
        private bool _InconsistentValuesFound = false;
        private string _ServerName;
        private bool _IsDirty;
        private ServerInformation _Server;
        private DateTime _DateCaptured;
        private DataSource _Source = DataSource.LiveData;
        private string _Version;
        private DateTime _LastStartDate;
        private string _ServerCollation;

        //SQLADMI 331.
        private ConfigurationData _AccessCheckCacheBucketCount;
        private ConfigurationData _AccessCheckCacheQuota;
        private ConfigurationData _Affinity64IOMask;
        private ConfigurationData _Affinity64Mask;

        #endregion

        #region .ctor

        public ConfigurationSettings() { }

        public ConfigurationSettings(ServerInformation server)
        {
            _Server = server;
            _ServerName = server.Name;
        }

        #endregion

        #region Accessors


        /// <summary>
        /// affinity64 I/O mask
        /// </summary>
        public ConfigurationData Affinity64IOMask
        {
            get { return _Affinity64IOMask; }
            set
            {
                _Affinity64IOMask = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// affinity64 mask
        /// </summary>
        public ConfigurationData Affinity64Mask
        {
            get { return _Affinity64Mask; }
            set
            {
                _Affinity64Mask = value;
                CheckConsitency(value);
            }
        }


        /// <summary>
        /// Enable or disable Access Check Cache Bucket Count
        /// </summary>
        public ConfigurationData AccessCheckCacheBucketCount
        {
            get { return _AccessCheckCacheBucketCount; }
            set
            {
                _AccessCheckCacheBucketCount = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Enable or disable Access Check Cache Quota
        /// </summary>
        public ConfigurationData AccessCheckCacheQuota
        {
            get { return _AccessCheckCacheQuota; }
            set
            {
                _AccessCheckCacheQuota = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Enable or disable Ad Hoc Distributed Queries
        /// </summary>
        public ConfigurationData AdHocDistributedQueries
        {
            get { return _AdHocDistributedQueries; }
            set
            {
                _AdHocDistributedQueries = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// affinity I/O mask
        /// </summary>
        public ConfigurationData AffinityIOMask
        {
            get { return _AffinityIOMask; }
            set
            {
                _AffinityIOMask = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// affinity mask
        /// </summary>
        public ConfigurationData AffinityMask
        {
            get { return _AffinityMask; }
            set
            {
                _AffinityMask = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Enable or disable Agent XPs
        /// </summary>
        public ConfigurationData AgentXPs
        {
            get { return _AgentXPs; }
            set
            {
                _AgentXPs = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Allow updates to system tables
        /// </summary>
        public ConfigurationData AllowUpdates
        {
            get { return _AllowUpdates; }
            set
            {
                _AllowUpdates = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// AWE enabled in the server
        /// </summary>
        public ConfigurationData AweEnabled
        {
            get { return _AweEnabled; }
            set
            {
                _AweEnabled = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Blocked process reporting threshold
        /// </summary>
        public ConfigurationData BlockedProcessThreshold
        {
            get { return _BlockedProcessThreshold; }
            set
            {
                _BlockedProcessThreshold = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// c2 audit mode
        /// </summary>
        public ConfigurationData C2AuditMode
        {
            get { return _C2AuditMode; }
            set
            {
                _C2AuditMode = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// CLR user code execution enabled in the server
        /// </summary>
        public ConfigurationData ClrEnabled
        {
            get { return _ClrEnabled; }
            set
            {
                _ClrEnabled = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Common Criteria compliance mode enabled
        /// </summary>
        public ConfigurationData CommonCriteriaComplianceEnabled
        {
            get { return _CommonCriteriaComplianceEnabled; }
            set
            {
                _CommonCriteriaComplianceEnabled = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Common Criteria compliance mode enabled
        /// </summary>
        public ConfigurationData CostThresholdForParallelism
        {
            get { return _CostThresholdForParallelism; }
            set
            {
                _CostThresholdForParallelism = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Allow cross db ownership chaining
        /// </summary>
        public ConfigurationData CrossDbOwnershipChaining
        {
            get { return _CrossDbOwnershipChaining; }
            set
            {
                _CrossDbOwnershipChaining = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// cursor threshold
        /// </summary>
        public ConfigurationData CursorThreshold
        {
            get { return _CursorThreshold; }
            set
            {
                _CursorThreshold = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Enable or disable Database Mail XPs
        /// </summary>
        public ConfigurationData DatabaseMailXPs
        {
            get { return _DatabaseMailXPs; }
            set
            {
                _DatabaseMailXPs = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// default full-text language
        /// </summary>
        public ConfigurationData DefaultFullTextLanguage
        {
            get { return _DefaultFullTextLanguage; }
            set
            {
                _DefaultFullTextLanguage = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// default language
        /// </summary>
        public ConfigurationData DefaultLanguage
        {
            get { return _DefaultLanguage; }
            set
            {
                _DefaultLanguage = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Enable or disable the default trace
        /// </summary>
        public ConfigurationData DefaultTraceEnabled
        {
            get { return _DefaultTraceEnabled; }
            set
            {
                _DefaultTraceEnabled = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Disallow returning results from triggers
        /// </summary>
        public ConfigurationData DisallowResultsFromTriggers
        {
            get { return _DisallowResultsFromTriggers; }
            set
            {
                _DisallowResultsFromTriggers = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Default fill factor percentage
        /// </summary>
        public ConfigurationData FillFactorPercentage
        {
            get { return _FillFactorPercentage; }
            set
            {
                _FillFactorPercentage = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Max number of full-text crawl buffers
        /// </summary>
        public ConfigurationData FullTextCrawlBandwidthMaximum
        {
            get { return _FullTextCrawlBandwidthMaximum; }
            set
            {
                _FullTextCrawlBandwidthMaximum = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Number of reserved full-text crawl buffers
        /// </summary>
        public ConfigurationData FullTextCrawlBandwidthReserved
        {
            get { return _FullTextCrawlBandwidthReserved; }
            set
            {
                _FullTextCrawlBandwidthReserved = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Max number of full-text notifications buffers
        /// </summary>
        public ConfigurationData FullTextNotificationsBandwidthMaximum
        {
            get { return _FullTextNotificationsBandwidthMaximum; }
            set
            {
                _FullTextNotificationsBandwidthMaximum = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Number of reserved full-text notifications buffers
        /// </summary>
        public ConfigurationData FullTextNotificationsBandwidthReserved
        {
            get { return _FullTextNotificationsBandwidthReserved; }
            set
            {
                _FullTextNotificationsBandwidthReserved = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Memory for index create sorts (kBytes)
        /// </summary>
        public ConfigurationData MemoryForIndexCreate
        {
            get { return _MemoryForIndexCreate; }
            set
            {
                _MemoryForIndexCreate = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Recovery policy for DTC transactions with unknown outcome
        /// </summary>
        public ConfigurationData InDoubtTransactionResolution
        {
            get { return _InDoubtTransactionResolution; }
            set
            {
                _InDoubtTransactionResolution = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// User mode scheduler uses lightweight pooling
        /// </summary>
        public ConfigurationData LightweightPooling
        {
            get { return _LightweightPooling; }
            set
            {
                _LightweightPooling = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Number of locks for all users
        /// </summary>
        public ConfigurationData Locks
        {
            get { return _Locks; }
            set
            {
                _Locks = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// maximum degree of parallelism
        /// </summary>
        public ConfigurationData MaximumDegreeOfParallelism
        {
            get { return _MaximumDegreeOfParallelism; }
            set
            {
                _MaximumDegreeOfParallelism = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Maximum  crawl ranges allowed in full-text indexing
        /// </summary>
        public ConfigurationData MaximumFullTextCrawlRange
        {
            get { return _MaximumFullTextCrawlRange; }
            set
            {
                _MaximumFullTextCrawlRange = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Maximum size of server memory (MB)
        /// </summary>
        public ConfigurationData MaximumServerMemory
        {
            get { return _MaximumServerMemory; }
            set
            {
                _MaximumServerMemory = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Maximum size of a text field in replication.
        /// </summary>
        public ConfigurationData MaximumTextFieldSizeInReplication
        {
            get { return _MaximumTextFieldSizeInReplication; }
            set
            {
                _MaximumTextFieldSizeInReplication = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Maximum worker threads
        /// </summary>
        public ConfigurationData MaximumWorkerThreads
        {
            get { return _MaximumWorkerThreads; }
            set
            {
                _MaximumWorkerThreads = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Tape retention period in days
        /// </summary>
        public ConfigurationData MediaRetentionPeriod
        {
            get { return _MediaRetentionPeriod; }
            set
            {
                _MediaRetentionPeriod = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// minimum memory per query (kBytes)
        /// </summary>
        public ConfigurationData MinimumMemoryPerQuery
        {
            get { return _MinimumMemoryPerQuery; }
            set
            {
                _MinimumMemoryPerQuery = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Minimum size of server memory (MB)
        /// </summary>
        public ConfigurationData MinimumServerMemory
        {
            get { return _MinimumServerMemory; }
            set
            {
                _MinimumServerMemory = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Allow triggers to be invoked within triggers
        /// </summary>
        public ConfigurationData NestedTriggers
        {
            get { return _NestedTriggers; }
            set
            {
                _NestedTriggers = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Network packet size
        /// </summary>
        public ConfigurationData NetworkPacketSize
        {
            get { return _NetworkPacketSize; }
            set
            {
                _NetworkPacketSize = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Enable or disable Ole Automation Procedures
        /// </summary>
        public ConfigurationData OleAutomationProcedures
        {
            get { return _OleAutomationProcedures; }
            set
            {
                _OleAutomationProcedures = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Number of open database objects
        /// </summary>
        public ConfigurationData OpenDatabaseObjects
        {
            get { return _OpenDatabaseObjects; }
            set
            {
                _OpenDatabaseObjects = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// DB connection timeout for full-text protocol handler (s)
        /// </summary>
        public ConfigurationData ProtocolHandlerTimeout
        {
            get { return _ProtocolHandlerTimeout; }
            set
            {
                _ProtocolHandlerTimeout = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Use precomputed rank for full-text query
        /// </summary>
        public ConfigurationData PrecomputedRank
        {
            get { return _PrecomputedRank; }
            set
            {
                _PrecomputedRank = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Priority boost
        /// </summary>
        public ConfigurationData PriorityBoost
        {
            get { return _PriorityBoost; }
            set
            {
                _PriorityBoost = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Maximum estimated cost allowed by query governor
        /// </summary>
        public ConfigurationData QueryGovernorCostLimit
        {
            get { return _QueryGovernorCostLimit; }
            set
            {
                _QueryGovernorCostLimit = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// maximum time to wait for query memory (s)
        /// </summary>
        public ConfigurationData QueryMemoryWaitTimeMaximum
        {
            get { return _QueryMemoryWaitTimeMaximum; }
            set
            {
                _QueryMemoryWaitTimeMaximum = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Maximum recovery interval in minutes
        /// </summary>
        public ConfigurationData RecoveryIntervalMaximum
        {
            get { return _RecoveryIntervalMaximum; }
            set
            {
                _RecoveryIntervalMaximum = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Allow remote access
        /// </summary>
        public ConfigurationData RemoteAccessAllowed
        {
            get { return _RemoteAccessAllowed; }
            set
            {
                _RemoteAccessAllowed = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Dedicated Admin Connections are allowed from remote clients
        /// </summary>
        public ConfigurationData DedicatedRemoteAdminConnectionsAllowed
        {
            get { return _DedicatedRemoteAdminConnectionsAllowed; }
            set
            {
                _DedicatedRemoteAdminConnectionsAllowed = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// remote login timeout
        /// </summary>
        public ConfigurationData RemoteLoginTimeout
        {
            get { return _RemoteLoginTimeout; }
            set
            {
                _RemoteLoginTimeout = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Create DTC transaction for remote procedures
        /// </summary>
        public ConfigurationData CreateDtcTransactionForRemoteProcedures
        {
            get { return _CreateDtcTransactionForRemoteProcedures; }
            set
            {
                _CreateDtcTransactionForRemoteProcedures = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// remote query timeout
        /// </summary>
        public ConfigurationData RemoteQueryTimeout
        {
            get { return _RemoteQueryTimeout; }
            set
            {
                _RemoteQueryTimeout = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Enable or disable Replication XPs
        /// </summary>
        public ConfigurationData EnableReplicationXPs
        {
            get { return _EnableReplicationXPs; }
            set
            {
                _EnableReplicationXPs = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// scan for startup stored procedures
        /// </summary>
        public ConfigurationData ScanForStartupProcs
        {
            get { return _ScanForStartupProcs; }
            set
            {
                _ScanForStartupProcs = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Allow recursion for server level triggers
        /// </summary>
        public ConfigurationData AllowServerTriggerRecursion
        {
            get { return _AllowServerTriggerRecursion; }
            set
            {
                _AllowServerTriggerRecursion = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// set working set size
        /// </summary>
        public ConfigurationData SetWorkingSetSize
        {
            get { return _SetWorkingSetSize; }
            set
            {
                _SetWorkingSetSize = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// show advanced options
        /// </summary>
        public ConfigurationData ShowAdvancedOptions
        {
            get { return _ShowAdvancedOptions; }
            set
            {
                _ShowAdvancedOptions = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Enable or disable SMO and DMO XPs
        /// </summary>
        public ConfigurationData EnableSmoAndDmoXPs
        {
            get { return _EnableSmoAndDmoXPs; }
            set
            {
                _EnableSmoAndDmoXPs = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Enable or disable SQL Mail XPs
        /// </summary>
        public ConfigurationData EnableSqlMailXPs
        {
            get { return _EnableSqlMailXPs; }
            set
            {
                _EnableSqlMailXPs = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Transform noise words for full-text query
        /// </summary>
        public ConfigurationData TransformNoiseWordsForFullTextQuery
        {
            get { return _TransformNoiseWordsForFullTextQuery; }
            set
            {
                _TransformNoiseWordsForFullTextQuery = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// two digit year cutoff
        /// </summary>
        public ConfigurationData TwoDigitYearCutoff
        {
            get { return _TwoDigitYearCutoff; }
            set
            {
                _TwoDigitYearCutoff = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Number of user connections allowed
        /// </summary>
        public ConfigurationData UserConnectionsCountAllowed
        {
            get { return _UserConnectionsCountAllowed; }
            set
            {
                _UserConnectionsCountAllowed = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// user options
        /// </summary>
        public ConfigurationData UserOptions
        {
            get { return _UserOptions; }
            set
            {
                _UserOptions = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Enable or disable Web Assistant Procedures
        /// </summary>
        public ConfigurationData EnableWebAssistantProcedures
        {
            get { return _EnableWebAssistantProcedures; }
            set
            {
                _EnableWebAssistantProcedures = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Enable or disable command shell
        /// </summary>
        public ConfigurationData EnableXpCmdshell
        {
            get { return _EnableXpCmdshell; }
            set
            {
                _EnableXpCmdshell = value;
                CheckConsitency(value);
            }
        }

        /// <summary>
        /// Audit level
        /// </summary>
        public ConfigurationData AuditLevel
        {
            get { return _AuditLevel; }
            set
            {
                _AuditLevel = value;
            }
        }

        /// <summary>
        /// True if one of the containted ConfigurationData values is inconsistent, else false.
        /// </summary>
        public bool InconsistentValuesFound
        {
            get { return _InconsistentValuesFound; }
        }

        /// <summary>
        /// SQL Server instance name.
        /// </summary>
        public string ServerName
        {
            get { return _ServerName; }
            set { _ServerName = value; }
        }

        /// <summary>
        /// True if one of the contained values has changed, else false.
        /// </summary>
        [XmlIgnore]
        public bool IsDirty
        {
            get { return _IsDirty; }
        }

        /// <summary>
        /// Server information and credentials.
        /// </summary>
        public ServerInformation Server
        {
            get { return _Server; }
        }

        /// <summary>
        /// Date when the data was captured from the server.
        /// </summary>
        public DateTime DateCaptured
        {
            get { return _DateCaptured; }
            set { _DateCaptured = value; }
        }

        /// <summary>
        /// Data source: Live, Snapshot, baseline
        /// </summary>
        public DataSource Source
        {
            get { return _Source; }
            set { _Source = value; }
        }

        /// <summary>
        /// SQL Server version.
        /// </summary>
        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        /// <summary>
        /// Last time that the server started.
        /// </summary>
        public DateTime LastStartDate
        {
            get { return _LastStartDate; }
            set { _LastStartDate = value; }
        }

        /// <summary>
        /// Server Collation
        /// </summary>
        public string ServerCollation
        {
            get 
            {
                if (string.IsNullOrEmpty(_ServerCollation))
                {
                    return "UNKNOWN";
                }
                return _ServerCollation; 
            }
            set { _ServerCollation = value; }
        }

        /// <summary>
        /// Unique key used to distinguish it from other server settings.
        /// </summary>
        public string Key
        {
            get
            {
                if (_Source == DataSource.LiveData)
                {
                    return _ServerName;
                }
                else
                {
                    return string.Format("Snapshot {0} ({1})", _ServerName, _DateCaptured);
                }
            }
        }

        #endregion

        #region Private methods

        private void CheckConsitency(ConfigurationData value)
        {
            if (value.NeedsAttention)
            {
                _InconsistentValuesFound = true;
            }
        }

        #endregion

        internal void SetDirty()
        {
            _IsDirty = true;
        }

        public override string ToString()
        {
            return _ServerName;
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
                    if (_Data.Name.ToUpperInvariant() == name.ToUpperInvariant())
                    {
                        return _Data;
                    }
                }
            }
            return null;
        }

        public enum DataSource
        {
            LiveData,
            Snapshot
        }
    }

    public delegate void SetDirtyDelegate();
}
