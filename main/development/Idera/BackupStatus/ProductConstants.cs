using Microsoft.Win32;
using System;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.BackupStatus
{
    class ProductConstants
    {
        // Product Name
        public static string shortProductName = "BackupStatus";
        public static string productName = "Backup Status";
        public static string productDescription = "Check whether your databases are backed up";

        // CommandLine Support
        public static bool supportsCommandLine = false;
        public static string usage = "Syntax:\r\n" +
                                        "    BackupStatus /arg1:value /arg2:value\r\n" +
                                        "Parameters:\r\n" +
                                        "    /arg1:value" +
                                        "    /arg2:value";

        public static string lblNeedingBackup = "{0} SQL Server{1} needing backup{1}";
        public static string lblNever = "{0} database{1} never backed up";
        public static string lblNotRecent = "{0} database{1} backed up but not in {2}";
        public static string lblUser = "{0} user databases";
        public static string lblSystem = "{0} system databases";
        public static string lblNew = "{0} database{1} created in last 30 days";
        public static string lblTotal = "{0} database{1} checked";
        public static string lblServersScanned = "{0} SQL Server{1} scanned";
        public static string lblUnknown = "???";

        public static string lblLoading = "Loading backup history ...";
        public static string lblStatus = "{0} of {1} databases have not been backed up during the last {2}.";

        public static string initialStatus = "Databases with no backup in {0} days";

        // Configurable Options
        public static int NumberOfDaysForRecent = 17;
        
        public static bool optionsHideSystem               = true;  
        public static bool optionsHideDbsWithRecentBackups = false;  
        public static bool optionsShowOnlyFull             = true;
        public static bool optionsHideOfflineDatabases     = false;
        public static bool optionIncludeAllNodes           = true;
        // Option Persistence
        public static void WriteOptions()
        {
            RegistryKey toolsetKey = null;
            RegistryKey backupKey = null;

            try
            {
                toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
                backupKey = toolsetKey.CreateSubKey("BackupStatus");

                backupKey.SetValue("NumberOfDaysForRecent", NumberOfDaysForRecent);
                
                backupKey.SetValue("HideSystem",               optionsHideSystem               ? 1 : 0);
                backupKey.SetValue("HideDbsWithRecentBackups", optionsHideDbsWithRecentBackups ? 1 : 0);
                backupKey.SetValue("ShowOnlyFull",             optionsShowOnlyFull             ? 1 : 0);
            }
            catch ( Exception ex )
            {
                CoreGlobals.traceLog.ErrorFormat( "WriteOptions error: {0}", ex.Message );
            }
            finally
            {
                if (toolsetKey != null) toolsetKey.Close();
                if (backupKey != null) backupKey.Close();
            }
        }

        public static void ReadOptions()
        {
            RegistryKey toolsetKey = null;
            RegistryKey backupKey = null;

            try
            {
                toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
                backupKey = toolsetKey.CreateSubKey("BackupStatus");

                // connection timeout
                int days = (int)backupKey.GetValue("NumberOfDaysForRecent", 7);
                if (days < 0 || days > 9999) days = 7;
                NumberOfDaysForRecent = days;
                
                optionsHideSystem               = ((int)backupKey.GetValue("HideSystem", 1)               == 0 ) ? false : true;
                optionsHideDbsWithRecentBackups = ((int)backupKey.GetValue("HideDbsWithRecentBackups", 0) == 0 ) ? false : true;
                optionsShowOnlyFull             = ((int)backupKey.GetValue("ShowOnlyFull", 0)             == 0 ) ? false : true;
            }
            catch ( Exception ex )
            {
                CoreGlobals.traceLog.ErrorFormat( "ReadOptions error: {0}", ex.Message );
            }
            finally
            {
                if (toolsetKey != null) toolsetKey.Close();
                if (backupKey != null) backupKey.Close();
            }
        }
    }
}
