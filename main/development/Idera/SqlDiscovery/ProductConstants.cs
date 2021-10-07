using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SqlDiscovery
{
   class ProductConstants
   {
      // Product Name
      public static string shortProductName = "SQLDiscovery";
      public static string productName = "SQL Discovery";
      public static string productDescription = "Find the SQL Servers lurking on your network";
      
      public static Form_Main mainform;
      
      public static int    optionMaxThreads = 50;

      // CommandLine Support
      public static bool supportsCommandLine = false;

      public static string usage = "Syntax:\r\n" +
                                   "    SqlDiscovery /arg1:value /arg2:value\r\n" +
                                   "Parameters:\r\n" +
                                   "    /arg1:value" +
                                   "    /arg2:value";

        // Option Persistence
        public static void WriteOptions()
        {
            RegistryKey toolsetKey = null;
            RegistryKey key = null;

            try
            {
                toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
                key = toolsetKey.CreateSubKey(ProductConstants.shortProductName);

                key.SetValue("MaxThreads", optionMaxThreads);
            }
            catch ( Exception ex )
            {
                CoreGlobals.traceLog.ErrorFormat( "WriteOptions error: {0}", ex.Message );
            }
            finally
            {
                if (toolsetKey != null) toolsetKey.Close();
                if (key != null) key.Close();
            }
        }

        public static void ReadOptions()
        {
            RegistryKey toolsetKey = null;
            RegistryKey key = null;

            try
            {
                toolsetKey = ToolsetOptions.optionsRootKey.OpenSubKey( ToolsetOptions.optionsRegistryKey);
                key = toolsetKey.OpenSubKey(ProductConstants.shortProductName);
                if ( key != null )
                {
                   // connection timeout
                   int threads = (int)key.GetValue("MaxThreads", 50);
                   if (threads < 0 || threads > 100) threads = 50;
                   optionMaxThreads = threads;
                }
                else
                {
                   optionMaxThreads = 50;
                }
            }
            catch
            {
            }
            finally
            {
                if (toolsetKey != null) toolsetKey.Close();
                if (key != null) key.Close();
            }
        }

      
   }
}
