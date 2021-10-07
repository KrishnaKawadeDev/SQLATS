using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.ServerConfiguration
{
   class ProductConstants
   {
      // Product Name
      public static string shortProductName = "ServerConfiguration";
      public static string productName = "Server Configuration";
      public static string productDescription = "tagline for new tool - a one sentence description";

      // CommandLine Support
      public static bool supportsCommandLine = false;

      public static string usage = "Syntax:\r\n" +
                                   "    ServerConfiguration /arg1:value /arg2:value\r\n" +
                                   "Parameters:\r\n" +
                                   "    /arg1:value" +
                                   "    /arg2:value";
      // Resource Strings

      public static string WarningInconsistentSettings = "Configuration value differs from running value.  Server must be restarted for settings to take effect.";
      public static string LabelChangesWillBeImmediate = "Changes to this configuration value will take effect immediately";
      public static string LabelChangesRequireRestart = "Changes to this configuration value will not take effect until the SQL Server instance is restarted";

      public static string TooltipServerInconsistentSettings = "Server must be restarted for configuration settings to take effect.";
      public static string TooltipServerOnline = "Online Server values";
      public static string TooltipServerSnapshot = "Snapshot Server values";
      public static string TooltipServerBaseline = "Baseline Server";


      public static string InformationConfigurationChangeSuccessful = "Configuration change completed successfully";
      public static string CaptionConfigurationChange = "Change Configuration";
      public static string InformationAllComparedRowsAreEqual = "All Live values on the selected row are equal";
      public static string InformationAllComparedServersEqual = "All Live values on the compared servers are equal.";
      public static string InformationCollationConflictsFound = string.Format("{0} cannot update the value for {1}.", ProductConstants.productName, ProductConstants.ServerCollationCaption); 

      public static string WarningInvalidRange = "The entered value must be between {0} and {1}";
      public static string WarningNotRecommendedValue = "The requested value falls outside of a reasonable range or may cause conflict among other options.  An inappropriate option value can adversely affect the configuration of the server instance.  Are you sure you want to proceed with the change?";
      public static string WarningNotRecommendedValueCaption = "Value not recommended";
      public static string WarningNoSelectedServersToEdit = "You must select at least one server for the bulk-edit operation";

      public static string ErrorServerNameNeeded = "Please specify a SQL Server instance name";

      public static string ComparisonColumnBaseline = "BASELINE";
      public static string ProgressGatherData = "Gathering Configuration Data";

      public static string PromptConfirmBaselineUpdate = "Are you sure that you want to set all options on the compared server equal to the baseline?\nThe following settings will be affected:\n\n{0}";

      // SQL configuration strings
      public const string QuerySql2005ConfigurationValues = "SELECT name, description, minimum, maximum, config_value = value, run_value = value_in_use, "
                                                            + "restart_required = case when is_dynamic = 1 then 0 else 1 end, is_advanced "
                                                            + "from sys.configurations "
                                                            + "order by name";

      public const string QuerySql2000ConfigurationValues = "SELECT name, c.comment, minimum = low, maximum = high,  config_value = c.value, run_value = master.dbo.syscurconfigs.value, "
                                                            + "restart_required = case when (c.status = 0) or (c.status = 2) then 1 else 0 end, "
                                                            + "is_advanced = case when (c.status & 2 <> 0) then 1 else 0 end "
                                                            + "from "
                                                            + "master.dbo.spt_values, master.dbo.sysconfigures c, master.dbo.syscurconfigs "
                                                            + "where type = 'C' "
                                                            + "and number = c.config "
                                                            + "and number = master.dbo.syscurconfigs.config";

      //Baseline file path
      public static string BaselineXmlFileName = "BaselineConfiguration.xml";
      public static string CopyComparisonToXmlDataSetName = "ConfigurationComparison";
      public static string BaselineDirectory = "";
      public static string SnapshotDirectory = "";

      public const string SelfConfiguringIndexCreateMemory = "index create memory (KB)";
      public const string SelfConfiguringLocks = "locks";
      public const string SelfConfiguringMaxServerMemory = "max server memory (MB)";
      public const string SelfConfiguringMinServerMemory = "min server memory (MB)";
      public const string SelfConfiguringRecoveryInterval = "recovery interval (min)";
      public const string SelfConfiguringScanForStartupProcs = "scan for startup procs";
      public const string SelfConfiguringUserConnections = "user connections";
      
      public const int ComparisonColumnWidth = 165;
      public static string ClipboardHeader = "Server Comparison";

      public const string MenuAddServerKeyPrePend = "Add";
      public const string MenuRemoveServerKeyPrePend = "Remove";
      public const string MenuAddBaselineKeyPrePend = "Baseline";

      public const string HighlightButtonShowDifferences = "Show Differences";
      public const string HighlightButtonHideDifferences = "Hide Differences";

      public const string BulkEditGroupBySetting = "Group by Settings";
      public const string BulkEditGroupByServer = "Group by Servers";
      public const string RestartDateCaption = "Last Server Restart";
      public const string ServerCollationCaption = "Server Collation";

   }
}
