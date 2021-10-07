using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.PartitionGenerator
{
   class ProductConstants
   {
      // Product Name
      public static string shortProductName = "PartitionGenerator";
      public static string productName = "Partition Generator";
      public static string productDescription = "A tool to help you in generating partitions for your data";

      // CommandLine Support
      public static bool supportsCommandLine = false;

      public static string usage = "Syntax:\r\n" +
                                   "    PartitionGenerator /arg1:value /arg2:value\r\n" +
                                   "Parameters:\r\n" +
                                   "    /arg1:value" +
                                   "    /arg2:value";
      // Resource Strings
      public static string ErrorMissingFunctionName = "You must specify a Partition Function name.";
      public static string ErrorMissingSchemeName = "You must specify a Partition Scheme name.";
      public static string ErrorMissingBoundaryValues = "You must specify a Boundary Values for all partitions.";
      public static string ErrorPartitionSchemeNotProided = "Partition Scheme was not provided.";
      public static string ErrorTypeNotSupported = "The specified Data Type is not supported.";
      public static string ErrorSchemeInformationNotFound = "No information was found related to the specified Scheme.";
      public static string ErrorSchemeRangeInformationNotFound = "No Range information was found related to the specified Scheme.";
      public static string ErrorBoundaryInvalidCast = "All boundary values must be convertible to {0}.";
      public static string ErrorBoundaryInvalidOrder = "Boundary values must be entered in ascending order.";
      public static string ErrorBoundaryTooManyValues = "The number of boundaries exceeds the number allowed by the data type.";

      public static string ErrorOnlySql2005OrAboveSupported = "SQL Server must be version 2005 or above";
      public static string ErrorOnlyEnterpriseEditionSupported = "Partitioning is only supported by SQL Server Enterprise and Data Center Edition.";
      public static string ErrorUnableToGetVersionInformation = "Unable to retrieve SQL Server version information";
      public static string ErrorNoDatabasesFound = "No databases found on the server";

      public static string PromptCancelEdit = "Are you sure that you want to discard your changes?";
      public static string PromptCancelCreate = "Are you sure that you want to discard the new partition?";
      public static string PromptCreate = "Are you sure that you want to proceed with partitioning this table?";
      public static string PromptEdit = "Are you sure that you want to apply your changes?";

      public static string InformationNoTablesFound = "No tables found in the selected database.  Please select a different database in order to proceed with partitioning.";
      public static string InformationDatabasesExcluded = "Databases with a compatibility level lower than 80 are not supported and are not included on the list";
      
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
