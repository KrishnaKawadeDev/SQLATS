using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;
using Microsoft.Win32;

namespace Idera.SqlAdminToolset.QuickReindex
{
    class ProductConstants
    {
        // Product Name
        public const string shortProductName = "Quick Reindex";
        public const string productName = "Quick Reindex";
        public static string productHelpTopic = @"http://wiki.idera.com/display/SQLAdminToolset/Quick+Reindex";
        public const string productDescription = "Quickly review and rebuild the indexes on your SQL Servers"; 
        

        // CommandLine Support
        public static bool supportsCommandLine = false;

        public const string usage = "Syntax:\r\n" +
                                     "    QuickReIndex /arg1:value /arg2:value\r\n" +
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

        public static int fillFactor = 100;
        public static int maxDOP = 0;
        public static long globalPageThreshold = 2;
        public static bool globalHideDisabled = true;
        public static bool globalHideBasedOnPageThreshold = true;
        public static bool globalHideNonClustered = false;


        // Constants
        public const int NullID = -1;
        public const int IndexPageSize = 8192;

        public const string LoadingIndexes = "Loading Index Statistics...";
        public const string RebuildingIndexes = "Rebuilding Selected Indexes...";
        public const string ReorganizingIndexes = "Reorganizing Selected Indexes...";
        public const string AnalyzingIndexFragmentation = "Analyzing Index Fragmentation...";

        public const string FilterText = "{0} indexes hidden ({1} total)";

        public const string AnalyzeAllDatabasesText = "< Analyze All Databases >";

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
