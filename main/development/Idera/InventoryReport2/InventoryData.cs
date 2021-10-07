using System;
using System.Text;
using System.Data.SqlClient;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.InventoryReport
{
    public class InventoryData
    {
        #region Ctors

        public InventoryData(InventoryType type)
        {
            DataType = type;
        }

        #endregion

        #region variables

        public InventoryType DataType;

        public bool HasValues = false;
        public string SnapshotFile;

        private string ErrorLogPath;
        public string errorLogPath
        {
            get { return ErrorLogPath; }
            set { ErrorLogPath = value; }
        }

        private bool C2AuditMode;
        public bool c2AuditMode
        {
            get { return C2AuditMode; }
            set { C2AuditMode = value; }
        }

        private bool AweEnabled;
        public bool aweEnabled
        {
            get { return AweEnabled; }
            set { AweEnabled = value; }
        }

        private string MasterLogPath;
        public string masterLogPath
        {
            get { return MasterLogPath; }
            set { MasterLogPath = value; }
        }

        private string MasterDBPath;
        public string masterDBPath
        {
            get { return MasterDBPath; }
            set { MasterDBPath = value; }
        }

        private bool IsFullTextInstalled;
        public bool isFullTextInstalled
        {
            get { return IsFullTextInstalled; }
            set { IsFullTextInstalled = value; }
        }

        private bool IsCaseSensitive;
        public bool isCaseSensitive
        {
            get { return IsCaseSensitive; }
            set { IsCaseSensitive = value; }
        }

        private string Collation;
        public string collation
        {
            get { return Collation; }
            set { Collation = value; }
        }

        private string Language;
        public string language
        {
            get { return Language; }
            set { Language = value; }
        }

        private bool IsSingleUser;
        public bool isSingleUser
        {
            get { return IsSingleUser; }
            set { IsSingleUser = value; }
        }

        private bool IsXpCommandShellEnabled;
        public bool isXpCommandShellEnabled
        {
            get { return IsXpCommandShellEnabled; }
            set { IsXpCommandShellEnabled = value; }
        }

        private bool IsRemoteAccessAllowed;
        public bool isRemoteAccessAllowed
        {
            get { return IsRemoteAccessAllowed; }
            set { IsRemoteAccessAllowed = value; }
        }

                private bool IsSqlClrEnabled;
        public bool isSqlClrEnabled
        {
            get { return IsSqlClrEnabled; }
            set { IsSqlClrEnabled = value; }
        }

        private bool IsDatabaseMailEnabled;
        public bool isDatabaseMailEnabled
        {
            get { return IsDatabaseMailEnabled; }
            set { IsDatabaseMailEnabled = value; }
        }

        private bool IsAgentXpEnabled;
        public bool isAgentXpEnabled
        {
            get { return IsAgentXpEnabled; }
            set { IsAgentXpEnabled = value; }
        }

        private bool IsClusteredServer;
        public bool isClusteredServer
        {
            get { return IsClusteredServer; }
            set { IsClusteredServer = value; }
        }

        private int DatabaseCount;
        public int databaseCount
        {
            get { return DatabaseCount; }
            set { DatabaseCount = value; }
        }

        private int MaximumNumberofConnections;
        public int maximumNumberofConnections
        {
            get { return MaximumNumberofConnections; }
            set { MaximumNumberofConnections = value; }
        }

        private int MaximumSqlServerMemory;
        public int maximumSqlServerMemory
        {
            get { return MaximumSqlServerMemory; }
            set { MaximumSqlServerMemory = value; }
        }

        private string SqlServerEdition;
        public string sqlServerEdition
        {
            get { return SqlServerEdition; }
            set { SqlServerEdition = value; }
        }

        private string SqlServerVersion;
        public string sqlServerVersion
        {
            get { return SqlServerVersion; }
            set { SqlServerVersion = value; }
        }

        private string SqlServerRelease;
        public string sqlServerRelease
        {
            get { return SqlServerRelease; }
            set { SqlServerRelease = value; }
        }

        private int FreeHardDriveSpace;
        public int freeHardDriveSpace
        {
            get { return FreeHardDriveSpace; }
            set { FreeHardDriveSpace = value; }
        }

        private int NumberOfHardDrives;
        public int numberOfHardDrives
        {
            get { return NumberOfHardDrives; }
            set { NumberOfHardDrives = value; }
        }

        private string Platform;
        public string platform
        {
            get { return Platform; }
            set { Platform = value; }
        }

        private int NumberOfPhysicalProcessors;
        public int numberOfPhysicalProcessors
        {
            get { return NumberOfPhysicalProcessors; }
            set { NumberOfPhysicalProcessors = value; }
        }

        private int NumberOfLogicalProcessors;
        public int numberOfLogicalProcessors
        {
            get { return NumberOfLogicalProcessors; }
            set { NumberOfLogicalProcessors = value; }
        }

        private ulong AvailableVirtualMemory;
        public ulong availableVirtualMemory
        {
            get { return AvailableVirtualMemory; }
            set { AvailableVirtualMemory = value; }
        }

        private ulong TotalVirtualMemory;
        public ulong totalVirtualMemory
        {
            get { return TotalVirtualMemory; }
            set { TotalVirtualMemory = value; }
        }

        private ulong AvailablePhysicalMemory;
        public ulong availablePhysicalMemory
        {
            get { return AvailablePhysicalMemory; }
            set { AvailablePhysicalMemory = value; }
        }

        private ulong TotalPhysicalMemory;
        public ulong totalPhysicalMemory
        {
            get { return TotalPhysicalMemory; }
            set { TotalPhysicalMemory = value; }
        }

        private string OsVersion;
        public string osVersion
        {
            get { return OsVersion; }
            set { OsVersion = value; }
        }

        private string OperatingSystem;
        public string operatingSystem
        {
            get { return OperatingSystem; }
            set { OperatingSystem = value; }
        }

        private string Manufacturer;
        public string manufacturer
        {
            get { return Manufacturer; }
            set { Manufacturer = value; }
        }

        private string DomainOrWorkgroup;
        public string domainOrWorkgroup
        {
            get { return DomainOrWorkgroup; }
            set { DomainOrWorkgroup = value; }
        }

        private string DomainWorkgroup;
        public string domainWorkgroup
        {
            get { return DomainWorkgroup; }
            set { DomainWorkgroup = value; }
        }

        private string HostComputer;
        public string hostComputer
        {
            get { return HostComputer; }
            set { HostComputer = value; }
        }

        private DateTime ReportDate;
        public DateTime reportDate
        {
            get { return ReportDate; }
            set { ReportDate = value; }
        }

        private string ServerName;
        public string serverName
        {
            get { return ServerName; }
            set { ServerName = value; }
        }

        private Exception WmiException = null;
        public Exception wmiException
        {
            get { return WmiException; }
            set { WmiException = value; }
        }

        private DateTime LastStartDate = DateTime.MinValue;
        public DateTime lastStartDate
        {
            get { return LastStartDate; }
            set { LastStartDate = value; }
        }

        private int TcpPort = int.MinValue;
        public int tcpPort
        {
            get { return TcpPort; }
            set { TcpPort = value; }
        }

        private string MemoryAllocationType = string.Empty;
        public string memoryAllocationType
        {
            get { return MemoryAllocationType; }
            set { MemoryAllocationType = value; }
        }

        private int MinimumSqlServerMemory = int.MinValue;
        public int minimumSqlServerMemory
        {
            get { return MinimumSqlServerMemory; }
            set { MinimumSqlServerMemory = value; }
        }

        private int AllocatedCpuCount = int.MinValue;
        public int allocatedCpuCount
        {
            get { return AllocatedCpuCount; }
            set { AllocatedCpuCount = value; }
        }

        private int AllocatedCpuCountIO = int.MinValue;
        public int allocatedCpuCountIO
        {
            get { return AllocatedCpuCountIO; }
            set { AllocatedCpuCountIO = value; }
        }

        private Nullable<bool> NetworkNamedPipesEnabled;
        public Nullable<bool> networkNamedPipesEnabled
        {
            get { return NetworkNamedPipesEnabled; }
            set { NetworkNamedPipesEnabled = value; }
        }

        private Nullable<bool> NetworkTcpIpEnabled;
        public Nullable<bool> networkTcpIpEnabled
        {
            get { return NetworkTcpIpEnabled; }
            set { NetworkTcpIpEnabled = value; }
        }

        private Nullable<bool> NetworkAppleTalkEnabled;
        public Nullable<bool> networkAppleTalkEnabled
        {
            get { return NetworkAppleTalkEnabled; }
            set { NetworkAppleTalkEnabled = value; }
        }

        private Nullable<bool> NetworkMultiprotocolEnabled;
        public Nullable<bool> networkMultiprotocolEnabled
        {
            get { return NetworkMultiprotocolEnabled; }
            set { NetworkMultiprotocolEnabled = value; }
        }

        private Nullable<bool> NetworkNwLinkEnabled;
        public Nullable<bool> networkNwLinkEnabled
        {
            get { return NetworkNwLinkEnabled; }
            set { NetworkNwLinkEnabled = value; }
        }

        private Nullable<bool> NetworkBanyanVinesEnabled;
        public Nullable<bool> networkBanyanVinesEnabled
        {
            get { return NetworkBanyanVinesEnabled; }
            set { NetworkBanyanVinesEnabled = value; }
        }

        private Nullable<bool> NetworkViaEnabled;
        public Nullable<bool> networkViaEnabled
        {
            get { return NetworkViaEnabled; }
            set { NetworkViaEnabled = value; }
        }

        private Nullable<bool> NetworkSharedMemoryEnabled;
        public Nullable<bool> networkSharedMemoryEnabled
        {
            get { return NetworkSharedMemoryEnabled; }
            set { NetworkSharedMemoryEnabled = value; }
        }

        #endregion

        public string Source
        {
            get
            {
                if (DataType == InventoryType.LiveData)
                    return "Live Data";
                else if (DataType == InventoryType.Snapshot)
                    return SnapshotFile;
                else
                    return "Unknown";
            }
        }

        #region enum
        /// <summary>
        /// Type of inventory data.
        /// </summary>
        public enum InventoryType
        {
            /// <summary>
            /// Data captured directly from the server.
            /// </summary>
            LiveData,
            /// <summary>
            /// Data captured from a snapshot file.
            /// </summary>
            Snapshot
        }
        #endregion

        #region Export Support

        public static void CreateTable(SqlConnection conn, string tableName) //include owner name
        {
            string sql = "CREATE TABLE {0}( " +
                          "  [Instance] [nvarchar](256)   NULL, " +
                          "	[DateCaptured] [datetime] NULL, " +
                          " [LastStartDate] [datetime] NULL, " +
                          "	[SqlServerRelease] [nvarchar](128)   NULL, " +
                          "	[SqlServerEdition] [nvarchar](128)   NULL, " +
                          "	[SqlServerVersion] [nvarchar](16)   NULL, " +
                          "	[MaximumSqlServerMemoryInKb] [float] NULL, " +
                          "	[MaxNumberUserConnections] [int] NULL, " +
                          "	[DatabaseCount] [int] NULL, " +
                          "	[IsServerClustered] [tinyint] NULL, " +
                          "	[IsAgentXPsEnabled] [tinyint] NULL, " +
                          "	[IsDatabaseMailEnabled] [tinyint] NULL, " +
                          "	[IsSqlClrEnabled] [tinyint] NULL, " +
                          "	[IsRemoteAccessAllowed] [tinyint] NULL, " +
                          "	[IsXPCommandShellEnabled] [tinyint] NULL, " +
                          "	[IsSingleUser] [tinyint] NULL, " +
                          "	[IsFullTextInstalled] [tinyint] NULL, " +
                          "	[IsC2AuditingEnabled] [tinyint] NULL, " +
                          "	[IsAweEnabled] [tinyint] NULL, " +
                          "	[Language] [nvarchar](64)   NULL, " +
                          "	[Collation] [nvarchar](64)   NULL, " +
                          "	[HostComputer] [varchar](256)   NULL, " +
                          "	[Domain] [nvarchar](128)   NULL, " +
                          "	[PartOfDomain] [tinyint] NULL, " +
                          "	[Workgroup] [nvarchar](128)   NULL, " +
                          "	[Manufacturer] [nvarchar](256)   NULL, " +
                          "	[OperatingSystem] [nvarchar](64)   NULL, " +
                          "	[OperatingSystemVersion] [nvarchar](64)   NULL, " +
                          "	[TotalPhysicalMemoryInKb] [float] NULL, " +
                          "	[AvailablePhysicalMemoryInKb] [float] NULL, " +
                          "	[TotalVirtualMemoryInKb] [float] NULL, " +
                          "	[AvailableVirtuaMemoryInKb] [float] NULL, " +
                          "	[Platform] [nvarchar](64)   NULL, " +
                          "	[NumberOfHardDrives] [int] NULL, " +
                          "	[NumberOfPhysicalProcessors] [int] NULL, " +
                          "	[NumberOfLogicalProcessors] [int] NULL, " +
                          "	[FreeSpaceInKb] [float] NULL, " +
                          "	[ListeningPort] [int] NULL, " +
                          "	[MemoryAllocationType] [nvarchar](50) NULL, " +
                          "	[MinimumServerMemoryInKb] [int] NULL, " +
                          "	[AllocatedCpuCount] [int] NULL, " +
                          "	[AllocatedCpuCountIO] [int] NULL, " +
                          "	[NamedPipesEnabled] [tinyint] NULL, " +
                          "	[TcpIpEnabled] [tinyint] NULL, " +
                          "	[MultiprotocolEnabled] [tinyint] NULL, " +
                          "	[NwLinkEnabled] [tinyint] NULL, " +
                          "	[AppleTalkEnabled] [tinyint] NULL, " +
                          "	[BanyanVinesEnabled] [tinyint] NULL, " +
                          "	[ViaEnabled] [tinyint] NULL, " +
                          "	[SharedMemoryEnabled] [tinyint] NULL " +
                          ")";

            string cmd = String.Format(sql, tableName);

            using (SqlCommand command = new SqlCommand(cmd, conn))
            {
                command.CommandTimeout = ToolsetOptions.commandTimeout;
                command.ExecuteNonQuery();
            }
        }

        static readonly StringBuilder props = new StringBuilder(2048);
        static readonly StringBuilder values = new StringBuilder(2048);

        public static void PopulateTable(SqlConnection conn, string tableName) //include owner name
        {
            foreach (InventoryData data in Form_Main.m_InventoryData)
            {
                props.Length = 0;
                values.Length = 0;

                PopulateTable_AddProperty("Instance", SQLHelpers.CreateSafeString(data.ServerName));
                PopulateTable_AddProperty("DateCaptured", SQLHelpers.CreateSafeDateTimeString(data.ReportDate));
                PopulateTable_AddProperty("LastStartDate", SQLHelpers.CreateSafeDateTimeString(data.LastStartDate));
                PopulateTable_AddProperty("SqlServerRelease", SQLHelpers.CreateSafeString(data.SqlServerRelease));
                PopulateTable_AddProperty("SqlServerEdition", SQLHelpers.CreateSafeString(data.SqlServerEdition));
                PopulateTable_AddProperty("SqlServerVersion", SQLHelpers.CreateSafeString(data.SqlServerVersion));
                PopulateTable_AddProperty("MaximumSqlServerMemoryInKb", data.MaximumSqlServerMemory.ToString());
                PopulateTable_AddProperty("MaxNumberUserConnections", data.MaximumNumberofConnections.ToString());
                PopulateTable_AddProperty("DatabaseCount", data.DatabaseCount.ToString());
                PopulateTable_AddProperty("IsServerClustered", SQLHelpers.CreateTinyIntString(data.IsClusteredServer));
                PopulateTable_AddProperty("IsAgentXPsEnabled", SQLHelpers.CreateTinyIntString(data.IsAgentXpEnabled));
                PopulateTable_AddProperty("IsDatabaseMailEnabled", SQLHelpers.CreateTinyIntString(data.IsDatabaseMailEnabled));
                PopulateTable_AddProperty("IsSqlClrEnabled", SQLHelpers.CreateTinyIntString(data.IsSqlClrEnabled));
                PopulateTable_AddProperty("IsRemoteAccessAllowed", SQLHelpers.CreateTinyIntString(data.IsRemoteAccessAllowed));
                PopulateTable_AddProperty("IsXPCommandShellEnabled", SQLHelpers.CreateTinyIntString(data.IsXpCommandShellEnabled));
                PopulateTable_AddProperty("IsSingleUser", SQLHelpers.CreateTinyIntString(data.IsSingleUser));
                PopulateTable_AddProperty("IsFullTextInstalled", SQLHelpers.CreateTinyIntString(data.IsFullTextInstalled));
                PopulateTable_AddProperty("IsC2AuditingEnabled", SQLHelpers.CreateTinyIntString(data.C2AuditMode));
                PopulateTable_AddProperty("IsAweEnabled", SQLHelpers.CreateTinyIntString(data.AweEnabled));
                PopulateTable_AddProperty("Language", SQLHelpers.CreateSafeString(data.Language));
                PopulateTable_AddProperty("Collation", SQLHelpers.CreateSafeString(data.Collation));
                PopulateTable_AddProperty("HostComputer", SQLHelpers.CreateSafeString(data.HostComputer));

                if (data.DomainOrWorkgroup == "Domain")
                {
                    PopulateTable_AddProperty("Domain", SQLHelpers.CreateSafeString(data.DomainWorkgroup));
                    PopulateTable_AddProperty("PartOfDomain", "1");
                    PopulateTable_AddProperty("Workgroup", "''");
                }
                else
                {
                    PopulateTable_AddProperty("Domain", "''");
                    PopulateTable_AddProperty("PartOfDomain", "0");
                    PopulateTable_AddProperty("Workgroup", SQLHelpers.CreateSafeString(data.DomainWorkgroup));
                }

                PopulateTable_AddProperty("Manufacturer", SQLHelpers.CreateSafeString(data.Manufacturer));
                PopulateTable_AddProperty("OperatingSystem", SQLHelpers.CreateSafeString(data.OperatingSystem));
                PopulateTable_AddProperty("OperatingSystemVersion", SQLHelpers.CreateSafeString(data.OsVersion));
                PopulateTable_AddProperty("TotalPhysicalMemoryInKb", data.TotalPhysicalMemory.ToString());
                PopulateTable_AddProperty("AvailablePhysicalMemoryInKb", data.AvailablePhysicalMemory.ToString());
                PopulateTable_AddProperty("TotalVirtualMemoryInKb", data.TotalVirtualMemory.ToString());
                PopulateTable_AddProperty("AvailableVirtuaMemoryInKb", data.AvailableVirtualMemory.ToString());
                PopulateTable_AddProperty("Platform", SQLHelpers.CreateSafeString(data.Platform));
                PopulateTable_AddProperty("NumberOfHardDrives", data.NumberOfHardDrives.ToString());
                PopulateTable_AddProperty("NumberOfPhysicalProcessors", data.NumberOfPhysicalProcessors.ToString());
                PopulateTable_AddProperty("NumberOfLogicalProcessors", data.NumberOfLogicalProcessors.ToString());
                PopulateTable_AddProperty("FreeSpaceInKb", data.FreeHardDriveSpace.ToString());
                PopulateTable_AddProperty("ListeningPort", data.TcpPort.ToString());
                PopulateTable_AddProperty("MemoryAllocationType", SQLHelpers.CreateSafeString(data.MemoryAllocationType));
                PopulateTable_AddProperty("MinimumServerMemoryInKb", data.MinimumSqlServerMemory.ToString());
                PopulateTable_AddProperty("AllocatedCpuCount", data.AllocatedCpuCount.ToString());
                PopulateTable_AddProperty("AllocatedCpuCountIO", data.AllocatedCpuCountIO.ToString());


                PopulateTable_AddProperty("NamedPipesEnabled", SQLHelpers.CreateTinyIntString(data.NetworkNamedPipesEnabled.GetValueOrDefault()));
                PopulateTable_AddProperty("TcpIpEnabled", SQLHelpers.CreateTinyIntString(data.NetworkTcpIpEnabled.GetValueOrDefault()));
                PopulateTable_AddProperty("MultiprotocolEnabled", SQLHelpers.CreateTinyIntString(data.NetworkMultiprotocolEnabled.GetValueOrDefault()));
                PopulateTable_AddProperty("NwLinkEnabled", SQLHelpers.CreateTinyIntString(data.NetworkNwLinkEnabled.GetValueOrDefault()));
                PopulateTable_AddProperty("AppleTalkEnabled", SQLHelpers.CreateTinyIntString(data.NetworkAppleTalkEnabled.GetValueOrDefault()));
                PopulateTable_AddProperty("BanyanVinesEnabled", SQLHelpers.CreateTinyIntString(data.NetworkBanyanVinesEnabled.GetValueOrDefault()));
                PopulateTable_AddProperty("ViaEnabled", SQLHelpers.CreateTinyIntString(data.NetworkViaEnabled.GetValueOrDefault()));
                PopulateTable_AddProperty("SharedMemoryEnabled", SQLHelpers.CreateTinyIntString(data.NetworkSharedMemoryEnabled.GetValueOrDefault()));

                string sql = String.Format("INSERT INTO {0} ({1}) VALUES ({2})",
                                             tableName,
                                             props,
                                             values);

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.CommandTimeout = ToolsetOptions.commandTimeout;
                    command.ExecuteNonQuery();
                }
            }

        }

        static private void PopulateTable_AddProperty(string propertyName, string propertyValue)
        {
            if (props.Length != 0)
                props.AppendFormat(",{0}", propertyName);
            else
                props.AppendFormat("{0}", propertyName);

            if (values.Length != 0)
                values.AppendFormat(",{0}", propertyValue);
            else
                values.AppendFormat("{0}", propertyValue);
        }

        #endregion

        public static int GetServerVersionAsInt(string version)
        {
            //SQLADMI-328 and 370
            string[] serverVersionDetails = version.Split(new string[] { "." }, StringSplitOptions.None);

            version = serverVersionDetails[0];
            //version = version.Substring(0, 2);
            return int.Parse(version);
        }
    }
}
