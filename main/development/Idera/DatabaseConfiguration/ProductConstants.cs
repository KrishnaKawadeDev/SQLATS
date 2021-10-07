using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.DatabaseConfiguration
{
   class ProductConstants
   {
      // Product Name
      public static string shortProductName = "DatabaseConfiguration";
      public static string productName = "Database Configuration";
      public static string productDescription = "tagline for new tool - a one sentence description";

      // CommandLine Support
      public static bool supportsCommandLine = false;

      public static string usage = "Syntax:\r\n" +
                                   "    DatabaseConfiguration /arg1:value /arg2:value\r\n" +
                                   "Parameters:\r\n" +
                                   "    /arg1:value" +
                                   "    /arg2:value";
      // Resource Strings

      public const string QuerySql2005ConfigurationValues = "SELECT " +
               "name, create_date, compatibility_level, collation_name,  " +
               "   user_access, user_access_desc,  --these work together " +
               "is_read_only, is_auto_close_on, is_auto_shrink_on, " +
               "   state, state_desc,  --these work together " +
               "is_in_standby, is_cleanly_shutdown, is_supplemental_logging_enabled,  " +
               "   snapshot_isolation_state, snapshot_isolation_state_desc,  --these work together " +
               "is_read_committed_snapshot_on,  " +
               "   recovery_model, recovery_model_desc, --these work together " +
               "   page_verify_option, page_verify_option_desc,  --these work together " +
               "is_auto_create_stats_on, is_auto_update_stats_on, is_auto_update_stats_async_on, is_ansi_null_default_on, is_ansi_nulls_on, " +
               "is_ansi_padding_on, is_ansi_warnings_on, is_arithabort_on, is_concat_null_yields_null_on, is_numeric_roundabort_on, " +
               "is_quoted_identifier_on, is_recursive_triggers_on, is_cursor_close_on_commit_on, is_local_cursor_default, is_fulltext_enabled, " +
               "is_trustworthy_on, is_db_chaining_on, is_parameterization_forced, is_master_key_encrypted_by_server, is_published, " +
               "is_subscribed, is_merge_published, is_distributor, is_sync_with_backup, service_broker_guid, is_broker_enabled, " +
               "   log_reuse_wait, log_reuse_wait_desc,  --these work together " +
               "is_date_correlation_on " +
               "FROM sys.databases";



      public const string QuerySql2000ConfigurationValues = "select * from sys.databases";
      public static string ComparisonColumnBaseline = "BASELINE";
      public static string BaselineXmlFileName = "BaselineConfiguration.xml";
      public static string ProgressGatherData = "Gathering Configuration Data";
      public static string InformationAllComparedRowsAreEqual = "All values on the selected row are equal";
      public static string InformationAllSettingsAreEqual = "All values on the list are equal";
      public static string InformationNoBaselineFound = "No baseline settings found to fix differences";
      public static string OptionNotAvailableString = "N/A";
      public static string CopyComparisonToXmlDataSetName = "ConfigurationComparison";
      public static string BaselineDirectory = "";
      public static string SnapshotDirectory = "";

      public static string TooltipDatabaseError = "Error retrieving database configuration";
      public static string TooltipServer = "SQL Server";
      public static string TooltipDatabase = "Database configuration values";

      public static string PromptConfirmBaselineUpdate = "Are you sure that you want to set all options on the compared databases equal to the baseline?\nThe following settings will be affected:\n\n{0}";

      public const int ComparisonColumnWidth = 180;
      public static string ClipboardHeader = "Database Comparison";

      public static string WarningTooManyDatabases = "You are about to load more than {0} databases to the comparison report.  This may cause performance issues on your system.  Do you want to continue?";
      public const int TooManyComparedDatabasesCount = 25;
      public static string ErrorCaptionCannotRetrieveDbOwner = "Unable to Retrieve Owner";

      public const string HighlightButtonShowDifferences = "Show Differences";
      public const string HighlightButtonHideDifferences = "Hide Differences";

      public const string BulkEditGroupBySetting = "Group by Settings";
      public const string BulkEditGroupByServer = "Group by Servers";

      public const string ConfigurationValueCollation = "Collation";
      public const string ConfigurationValueCompatibility = "Compatibility Level";

      public static string InformationReadOnlyConflictsFound = string.Format("{0} cannot update Read-Only values", ProductConstants.productName); 

   }
}
