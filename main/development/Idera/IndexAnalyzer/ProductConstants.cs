using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;
using Microsoft.Win32;


namespace Idera.SqlAdminToolset.IndexAnalyzer
{
    class ProductConstants
    {
        // Product Name
        public const string shortProductName = "Index Analyzer";
        public const string productName = "Index Analyzer";
        public const string productDescription = "Quickly analyze all indexes on your SQL Server to find performance bottlenecks";

        // CommandLine Support
        public static bool supportsCommandLine = false;

        public const string usage = "Syntax:\r\n" +
                                     "    IndexAnalyzer /arg1:value /arg2:value\r\n" +
                                     "Parameters:\r\n" +
                                     "    /arg1:value" +
                                     "    /arg2:value";
        // Resource Strings


        // Globals
        public static SQLCredentials globalSqlCredentials = null;
        public static bool globalCancelRequested = false;
        public static bool globalOperationCancelled = false;
        public static Dictionary<string, string> globalErrorReports = new Dictionary<string, string>();
        public static bool globalIncludeFrag = false;
        public static bool globalIncludeSelectivity = false;
        public static bool globalIncludeColumnStats = true;


        public static long globalRowThreshold = 10;
        public static bool globalHideDisabled = true;
        public static bool globalHideNonClustered = true;
        public static bool globalHideBasedOnRowThreshold = true;


        // Constants
        public const int NullID = -1;
        public const int IndexPageSize = 8192;

        public const string LoadingIndexes = "Loading Statistics...";
        public const string UpdatingStatistics = "Updating Statistics...";
        public const string UpdatingStatisticsFullScan = "Updating Statistics (FullScan)...";
        public const string AnalyzingIndexFragmentation = "Analyzing Index Fragmentation...";
        public const string LoadingIndexSelectivity = "Loading Index Selectivity...";


        public const string IndexUsefulnessSummaryLow = "Low";
        public const string IndexUsefulnessSummaryMedium = "Medium";
        public const string IndexUsefulnessSummaryHigh = "High";
        public const string IndexUsefulnessSummaryNA = "N/A";

        public const string StatisticCriticalText_Selectivity = "{0} Statistic{1} 60% or less Selective";
        public const string StatisticCautionText_Selectivity = "{0} Statistic{1} 60% to 90% Selective";
        public const string StatisticAcceptableText_Selectivity = "{0} Statistic{1} 90% or more Selective";

        public const string FilterText = "{0} indexes hidden ({1} total)";

        public const string AnalyzeAllDatabasesText = "< Analyze All Databases >";


        // View Mode constants
        // -------------------
        // Summary Columns
        public const string ViewMode_Summary = "Show Summary of Statistics";
        public const string GroupText_Summary = "Usefulness Summary for {0}";
        public const string CriticalText_Summary = "{0} Index{1} with Low Usefulness";
        public const string CautionText_Summary = "{0} Index{1} with Medium Usefulness";
        public const string AcceptableText_Summary = "{0} Index{1} with High Usefulness";
        public const string HelpTitle_Summary = "<b><u>Index Usefulness Summary View</u></b>";
        public const string HelpText_Summary =
            "shows an estimate of how likely SQL Server will use the index based on the columns % rows modified, selectivity, and % updates to total index accesses.";

        // All Columns 
        public const string ViewMode_AllColumns = "Show All Statistics";
        public const string GroupText_AllColumns = "Statistics Summary for {0}";
        public const string CriticalText_AllColumns = "{0} Index{1} with Low Usefulness";
        public const string CautionText_AllColumns = "{0} Index{1} with Medium Usefulness";
        public const string AcceptableText_AllColumns = "{0} Index{1} with High Usefulness";
        public const double CriticalPercent_AllColumns = 0.75;
        public const double AccpetablePercent_AllColumns = 0.25;
        public const string HelpTitle_AllColumns = "<b><u>All Statistics View</u></b>";
        public const string HelpText_AllColumns =
            "shows the detailed data collected for each index.";

        // Usage Columns
        public const string ViewMode_Usage = "Show Usage Statistics";
        public const string GroupText_Usage = "Usage Summary for {0}";
        public const string CriticalText_Usage =    "{0} Index{1} with 50% or more Updates to Total Accessess";
        public const string CautionText_Usage =     "{0} Index{1} with 20% to 50% Updates to Total Accessess";
        public const string AcceptableText_Usage =  "{0} Index{1} with 20% or less Updates to Total Accessess";
        public const double CriticalPercent_Usage = 0.50;
        public const double AccpetablePercent_Usage = 0.20;
        public const string HelpTitle_Usage = "<b><u>Usage Summary View</u></b>";
        public const string HelpText_Usage =
            "shows usage statistics for each index. The more often an index is used the more critical it is to system performance. However, indexes with a high update to access ratio may negativity impact system performance.";

        // Fragmentation Columns
        public const string ViewMode_Fragmentation = "Show Fragmentation Statistics";
        public const string GroupText_Fragmentation = "Fragmentation Summary for {0}";
        public const string CriticalText_Fragmentation = "{0} Index{1} 75% or more Fragmented";
        public const string CautionText_Fragmentation = "{0} Index{1} 25% to 75% Fragmented";
        public const string AcceptableText_Fragmentation = "{0} Index{1} 25% or less Fragmented";
        public const double CriticalPercent_Fragmentation = 0.75;
        public const double AccpetablePercent_Fragmentation = 0.25;
        public const string HelpTitle_Fragmentation = "<b><u>Fragmentation Summary View</u></b>";
        public const string HelpText_Fragmentation =
            "shows the average fragmentation for each page of the index.  Highly fragmented indexes may negativity impact system performance.";

        // Selectivity Columns
        public const string ViewMode_Selectivity = "Show Selectivity Statistics";
        public const string GroupText_Selectivity = "Selectivity Summary for {0}";
        public const string CriticalText_Selectivity = "{0} Index{1} 60% or less Selective";
        public const string CautionText_Selectivity = "{0} Index{1} 60% to 90% Selective";
        public const string AcceptableText_Selectivity = "{0} Index{1} 90% or more Selective";
        public const double CriticalPercent_Selectivity = 0.60;
        public const double AccpetablePercent_Selectivity = 0.90;
        public const string HelpTitle_Selectivity = "<b><u>Selectivity Summary View</u></b>";
        public const string HelpText_Selectivity =
            "shows the statistical uniqueness of each row in the index. Indexes with low selectivity may negatively impact system performance.";

        // Out Dated Statistics Columns
        public const string ViewMode_Modified = "Show Modified Rows Statistics";
        public const string GroupText_Modified = "Modified Rows Summary for {0}";
        public const string CriticalText_Modified = "{0} Index{1} with 50% or more rows modified since last update";
        public const string CautionText_Modified = "{0} Index{1} with 20% to 75% rows modified since last update";
        public const string AcceptableText_Modified = "{0} Index{1} with 20% or rows modified since last update";
        public const double CriticalPercent_Modified = 0.50;
        public const double AccpetablePercent_Modified = 0.20;
        public const string HelpTitle_Modified = "<b><u>Modified Rows Summary View</u></b>";
        public const string HelpText_Modified =
            "shows how many rows have been modified since the last statistics update. Outdated statistics may negatively impact system performance. Index Analyzer allows you to update statistics for any index.";

        // Persisted Options
        public static string         lastServer      = "";
        public static SQLCredentials lastCredentials = null;
        
        // Option Persistence
        public static void WriteOptions()
        {
            RegistryKey toolsetKey = null;
            RegistryKey optionsKey = null;

            try
            {
                toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
                optionsKey = toolsetKey.CreateSubKey(ProductConstants.shortProductName);
                
                string last = MRU.EncryptItem( lastServer, lastCredentials );

                optionsKey.SetValue("LastServer", last);
            }
            catch ( Exception ex )
            {
                CoreGlobals.traceLog.ErrorFormat( "WriteOptions error: {0}", ex.Message );
            }
            finally
            {
                if (toolsetKey != null) toolsetKey.Close();
                if (optionsKey != null) optionsKey.Close();
            }
        }

        public static void ReadOptions()
        {
            RegistryKey toolsetKey = null;
            RegistryKey optionsKey = null;

            try
            {
                toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
                optionsKey = toolsetKey.CreateSubKey(ProductConstants.shortProductName);

                string last = (string)optionsKey.GetValue("LastServer", "");
                
                if ( last != "" )
                {
                  try
                  {
                     MRU.DecryptServer( last,
                                        out lastServer,
                                        out lastCredentials );
                  }
                  catch
                  {
                  }
                }
                
                if ( lastServer == "" )
                {
                   lastServer = "(local)";
                }
                
            }
            catch ( Exception ex )
            {
                CoreGlobals.traceLog.ErrorFormat( "ReadOptions error: {0}", ex.Message );
            }
            finally
            {
                if (toolsetKey != null) toolsetKey.Close();
                if (optionsKey != null) optionsKey.Close();
            }
        }
    }
}
