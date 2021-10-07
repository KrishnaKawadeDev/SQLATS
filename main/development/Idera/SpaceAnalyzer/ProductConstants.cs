using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SpaceAnalyzer
{
    class ProductConstants
    {
        // Product Name
        public const string shortProductName = "SpaceAnalyzer";
        public const string productName = "Space Analyzer";
        public const string productDescription = "Analyze the space usage of your SQL Server by drive or database";

        // CommandLine Support
        public static bool supportsCommandLine = false;

        public const string usage = "Syntax:\r\n" +
                                     "    SpaceAnalyzer /arg1:value /arg2:value\r\n" +
                                     "Parameters:\r\n" +
                                     "    /arg1:value" +
                                     "    /arg2:value";
        // Resource Strings


        // Globals
        public static SQLCredentials globalSqlCredentials = null;
        public static bool globalCancelRequested = false;
        public static bool globalOperationCancelled = false;
        public static Dictionary<string, string> globalErrors = new Dictionary<string, string>();
        public static string globalWMIUser = string.Empty;
        public static string globalWMIPassword = string.Empty;
        public static bool globalHideLogFiles = false;
        public static bool globalHideDataFiles = false;
        public static bool globalWMIEnable = true;

        // Constants
        public const int NullID = -1;
        public const long FilePageSize = 8;
        public const int ByteConversionValue = 1024;

        public const string LoadingFiles = "Loading Database Files...";

        public static string msgServerNeeded = "Specify at least one SQL Server.";
        public static string msgServerGroupEmpty = "The selected Server Group contains no SQL Servers.";

        public static string WMIDialogTitle = "WMI Credentials - {0}";
        public static string WmiErrorInstructions = productName +
                                                    " was unable to successfully connect to WMI on the computer {0}. WMI is used to gather disk space data. Please verify that WMI access is enabled on {0} and that you have administrative rights. If you are behind a firewall, you might need to configure it to allow WMI calls to go through. Alternately, you can specify credentials that have administrative rights.";

        public const double CriticalPercentUsed = 0.85;
        public const double AcceptablePercentUsed = 0.60;

        public const double CriticalPercentFree = 0.15;
        public const double AcceptablePercentFree = 0.40;

        public const string FilterText = "{0} files hidden ({1} total)";

        public const string Cimv2Root = @"\root\cimv2";

        // View Mode constants
        // -------------------
        // Disk Summary 
        public const string View_DiskSummary = "Show Disk Space Summary";
        public const string GroupText_DiskSummary = "Disk Space Summary for {0}";
        public const string CriticalText_DiskSummary = "{0} Disk{1} 85% or more Full";
        public const string CautionText_DiskSummary = "{0} Disk{1} 60% to 85% Full";
        public const string AcceptableText_DiskSummary = "{0} Disk{1} 60% or less Full";
        public const string HelpTitle_DiskSummary = "<b><u>Disk Space Summary View</u></b>";
        public const string HelpText_DiskSummary =
            "shows disk space usage for all drives containing database files used by the specified SQL Servers. If disk space is low, consider using Database Mover to move some databases to different drives.";

        // Database Summary
        public const string View_DatabaseSummary = "Show Database File Space Summary";
        public const string GroupText_DatabaseSummary = "Database File Space Summary for {0}";
        public const string CriticalText_DatabaseSummary = "{0} File{1} stored on disk 85% or more Full";
        public const string CautionText_DatabaseSummary = "{0} File{1} stored on disk 60% to 85% Full";
        public const string AcceptableText_DatabaseSummary = "{0} File{1} stored on disk 60% or less Full";
        public const string HelpTitle_DatabaseSummary = "<b><u>Database File Space Summary View</u></b>";
        public const string HelpText_DatabaseSummary =
            "shows database space usage for all database files used by the specified SQL Servers.";

        // Units of measurement Summary
        public const string View_KB = "KiloByte";
        public const string View_MB = "MegaByte";
        public const string View_GB = "GigaByte";
        public const string view_default = "Auto Unit";

        // All Columns 
        public const string View_AllColumns = "Show All Data";
        public const string GroupText_AllColumns = "Database space summary for {0}";
        public const string CriticalText_AllColumns = "{0} Disk{1} 85% or more Full";
        public const string CautionText_AllColumns = "{0} Disk{1} 60% to 85% Full";
        public const string AcceptableText_AllColumns = "{0} Disk{1} 60% or less Full";
        public const string HelpTitle_AllColumns = "<b><u>All Statistics View</u></b>";
        public const string HelpText_AllColumns =
            "shows the detailed data collected for all files.";

        
    }
}
