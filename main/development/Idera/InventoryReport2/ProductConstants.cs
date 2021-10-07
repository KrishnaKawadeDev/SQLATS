namespace Idera.SqlAdminToolset.InventoryReport
{
    class ProductConstants
    {
        // Product Name
        public static string shortProductName = "InventoryReporter";
        public static string productName = "Inventory Reporter";
        public static string productDescription = "Shows details about SQL Servers and their host computers";

        // CommandLine Support
        public static bool supportsCommandLine = false;

        public static string usage = "Syntax:\r\n" +
                                        "    InventoryReporter /arg1:value /arg2:value\r\n" +
                                        "Parameters:\r\n" +
                                        "    /arg1:value" +
                                        "    /arg2:value";
        // Resource Strings
        public static string ReportDateCaption = "Date Captured";
        public static string ReportTypeCaption = "Data Source";
        public static string LastServerRestart = "Last Restart Date";

        public static string HostComputerCaption = "Host Computer";
        public static string PartOfDomainCaption = "Domain Member";
        public static string DomainWorkgroupCaption = "Domain/Workgroup Name";
        public static string DomainOrWorkgroupCaption = "Domain/Workgroup";
        public static string ManufacturerCaption = "Manufacturer";
        public static string OperatingSystemCaption = "Operating System";
        public static string OperatingSystemVersionCaption = "Operating System Version";
        public static string TotalPhysicalMemoryCaption = "Total Physical Memory";
        public static string AvailablePhysicalMemoryCaption = "Available Physical Memory";
        public static string TotalVirtualMemoryCaption = "Total Virtual Memory";
        public static string AvailableVirtualMemoryCaption = "Available Virtual Memory";
        public static string NumberOfLogicalProcessorsLegacyCaption = "Number of Processors";
        public static string NumberOfLogicalProcessorsCaption = "Number of Logical Processors";
        public static string NumberOfPhysicalProcessorsCaption = "Number of Physical Processors";
        public static string PlatformCaption = "Platform";
        public static string NumberOfHardDrivesCaption = "Number of Hard Drives";
        public static string FreeSpaceCaption = "Free Space";
        public static string TimeZone = "TimeZone";
        public static string DaylightSavings = "Daylight Savings";

        public static string SqlServerReleaseCaption = "SQL Server Release";
        public static string SqlServerVersionCaption = "SQL Server Version";
        public static string SqlServerEditionCaption = "SQL Server Edition";
        public static string MaximumServerMemoryCaption = "Maximum SQL Server Memory";
        public static string MaximumNumberOfUserConnectionsCaption = "Max. Number of User Connections";
        public static string DatabaseCountCaption = "Database count";
        public static string ClusteredServerCaption = "Clustered Server";
        public static string ClusteredServerAppendToHost = " (Physical Node)";
        public static string AgentXpsEnabledCaption = "Agent XPs Enabled";
        public static string DatabaseMailEnabledCaption = "Database Mail Enabled";
        public static string SqlClrEnabledCaption = "SQL CLR Enabled";
        public static string RemoteAccessAllowedCaption = "Remote Access Allowed";
        public static string XpCommandShellEnabledCaption = "XP command-shell Enabled";

        public static string IsSingleUserCaption = "Single User Enabled";
        public static string LanguageCaption = "Language";
        public static string CollationCaption = "Collation";
        public static string IsCaseSensitiveCaption = "Case Sensitive";
        public static string IsFullTextInstalledCaption = "Full Text Installed";
        public static string MasterDBPathCaption = "Master Database Path";
        public static string MasterLogPathCaption = "Master Log Path";
        public static string ErrorLogPathCaption = "Error Log Path";
        public static string C2AuditModeCaption = "C2 Auditing Enabled";
        public static string AweEnabledCaption = "AWE Enabled";
        public static string MemoryAllocationTypeCaption = "Memory Allocation Type";
        public static string MinimumServerMemoryCaption = "Minimum SQL Server Memory";
        public static string ListeningPort = "Listening Port";
        public static string AllocatedCpuCountCaption = "Allocated CPU Count";
        public static string AllocatedCpuCountIOCaption = "Allocated CPU Count - I/O";

        public static string NetworkProtocolNamedPipes = "Named Pipes";
        public static string NetworkProtocolTcpIp = "TCP/IP";
        public static string NetworkProtocolApplteTalk = "AppleTalk";
        public static string NetworkProtocolMultiprotocol = "Multiprotocol";
        public static string NetworkProtocolNwLink = "NWLink IPX/SPX";
        public static string NetworkProtocolBanyanVines = "Banyan Vines";
        public static string NetworkProtocolVia = "Via";
        public static string NetworkProtocolSharedMemory = "Shared Memory";
        
        public static string UnknownValue = "UNKNOWN";

        // Snapshot folder
        public static string SnapshotFolder = "";

        public const string HighlightButtonShowDifferences = "Show Differences";
        public const string HighlightButtonHideDifferences = "Hide Differences";

        public static string ErrorServerGroupIsEmpty = "The selected Server Group does not contain any servers";
        public const string ClearReportsCheckedRegistryValue = "ClearReportsChecked";

        public static string WmiErrorInstructions = productName + 
            " uses WMI to gather some of the inventory data. It was unable to successfully gather this data " + 
            "for one or more servers. Please verify that WMI access is enabled on all target servers and that " + 
            "you have administrative rights on them. If you are behind a firewall, you might need to configure " + 
            "it to allow WMI calls to go through. Click <a href=\"\">View WMI Errors</a> to view the servers for " + 
            "which Inventory Reporter had problems gathering data via WMI.";
        public static string WmiErrorTitle = "Unable to retrieve all computer configuration values";

        public static string AweEnabledMessage = "This property has been deprecated since SQL server 2012";
    }
}
