using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.MultiQuery
{
   class ProductConstants
   {
      // Product Name
      public static string shortProductName = "MultiQuery";
      public static string productName = "Multi Query";
        public static string productHelpTopic = @"http://wiki.idera.com/display/SQLAdminToolset/Multi+Query";
        public static string productDescription = "tagline for new tool - a one sentence description";

      // CommandLine Support
      public static bool supportsCommandLine = false;

      public static string usage = "Syntax:\r\n" +
                                   "    MultiQuery /arg1:value /arg2:value\r\n" +
                                   "Parameters:\r\n" +
                                   "    /arg1:value" +
                                   "    /arg2:value";
      // Resource Strings
      
      // Progress Bar
      public static bool globalCancelRequested    = false;
      public static bool globalOperationCancelled = false;
      
      // Values
      public static Form_Main           mainform;
      public static string              QueryText = "";
      public static List<StringBuilder> QueryBatches = null;
      
      public static bool                QueryTargetIsFile = false;
      public static string              QueryTargetFile   = "<Untitled>";
      public static bool                QueryTargetDirty  = false;
      
      public static int                 MaxQueryFileSize = 2147483647;
      public static bool                QueryIsFile = false;
      public static string              QueryFile   = "<Untitled>";
      public static bool                QueryDirty  = false;
      
      // Query Options
      public enum OutputType
      {
         Grid        = 0,
         Text        = 1,
         CSV         = 2
      }
      
      public static long       optionsRowCount   = 1000;
      public static long       optionsTextSize   = 8192;
      public static int        optionsMaxThreads = 10;
      public static int        optionsCommandTimeout = 30;
      public static OutputType optionsResultType = OutputType.Grid;
      public static bool       optionsShowSummary           = true;
      public static bool       optionsShowCombinedResults   = true;
      public static bool       optionsShowIndividualResults = true;
      
      public static bool       optionsShowLineNumbers   = true;
      public static bool       optionsShowModifiedLines = true;
      public static bool       optionsShowSyntaxErrors  = false;
      public static bool       optionsShowSyntaxColor   = true;
      public static bool       optionsShowWordWrap      = false;
      
      public static string     optionsQueryDirectory    = "";
      
      public static string     defaultQueryTargetFile   = "DefaultQueryTarget.sqt";
      public static string     lastQueryTargetFile      = "";
      
      public static string RegistryValue_RecentFiles = "RecentQuery";
      
      // not persisted
      public static string     optionsBatchSeparator    = "GO";
      
     // Option Persistence
     public static void WriteOptions()
     {
         RegistryKey toolsetKey = null;
         RegistryKey backupKey = null;

         try
         {
             toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
             backupKey = toolsetKey.CreateSubKey("MultiQuery");

             backupKey.SetValue("Rowcount",       optionsRowCount);
             backupKey.SetValue("TextSize",       optionsTextSize);
             backupKey.SetValue("ResultType",     (int)optionsResultType);
             backupKey.SetValue("MaxThreads",     (int)optionsMaxThreads);
             backupKey.SetValue("CommandTimeout", (int)optionsCommandTimeout);
             
             backupKey.SetValue("ShowSummary",           (int)(optionsShowSummary           ? 1 : 0));
             backupKey.SetValue("ShowCombinedResults",   (int)(optionsShowCombinedResults   ? 1 : 0));
             backupKey.SetValue("ShowIndividualResults", (int)(optionsShowIndividualResults ? 1 : 0));
             
             backupKey.SetValue("ShowLineNumbers",       (int)(optionsShowLineNumbers       ? 1 : 0));
             backupKey.SetValue("ShowModifedLines",      (int)(optionsShowModifiedLines     ? 1 : 0));
             backupKey.SetValue("ShowSyntaxErrors",      (int)(optionsShowSyntaxErrors      ? 1 : 0));
             backupKey.SetValue("ShowSyntaxColor",       (int)(optionsShowSyntaxColor       ? 1 : 0));
             backupKey.SetValue("ShowWordWrap",          (int)(optionsShowWordWrap          ? 1 : 0));
             
             backupKey.SetValue("LastQueryTarget",       lastQueryTargetFile);
             backupKey.SetValue("QueryDirectory",        optionsQueryDirectory);
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
         RegistryKey queryKey   = null;

         try
         {
             toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
             queryKey   = toolsetKey.CreateSubKey("MultiQuery");

             // rowcount
             long rowcount = System.Convert.ToInt64((string)queryKey.GetValue("Rowcount", "1000"));
             if (rowcount < 0 || rowcount > 999999) rowcount = 1000;
             optionsRowCount = rowcount;

             // textsize
             long textsize = System.Convert.ToInt64((string)queryKey.GetValue("TextSize", "8192"));
             if (textsize < 0 || textsize > 99999999) textsize = 8192;
             optionsTextSize = textsize;

             // Result Type
             int resultType = (int)queryKey.GetValue("ResultType", 0);
             if (resultType < 0 || resultType > 3) resultType = 0;
             optionsResultType = (OutputType)resultType;
             
             // Max Threads
             int maxThreads = (int)queryKey.GetValue("MaxThreads", 10);
             if (maxThreads <= 0 || maxThreads > 25) maxThreads = 10;
             optionsMaxThreads = maxThreads;

             // CommandTimeout
             int commandTimeout = (int)queryKey.GetValue("CommandTimeout", 30);
             if (commandTimeout < 0 || commandTimeout > 9999) commandTimeout = 30;
             optionsCommandTimeout = commandTimeout;
             

             int showValue = (int)queryKey.GetValue("ShowSummary", 1);
             optionsShowSummary = (showValue != 0);
             
             showValue = (int)queryKey.GetValue("ShowCombinedResults", 1);
             optionsShowCombinedResults = (showValue != 0);

             showValue = (int)queryKey.GetValue("ShowIndividualResults", 1);
             optionsShowIndividualResults = (showValue != 0);
             
             showValue = (int)queryKey.GetValue("ShowLineNumbers", 1);
             optionsShowLineNumbers = (showValue != 0);
             showValue = (int)queryKey.GetValue("ShowModifedLines", 1);
             optionsShowModifiedLines = (showValue != 0);
             showValue = (int)queryKey.GetValue("ShowSyntaxErrors", 0);
             optionsShowSyntaxErrors = (showValue != 0);
             showValue = (int)queryKey.GetValue("ShowSyntaxColor", 1);
             optionsShowSyntaxColor = (showValue != 0);
             showValue = (int)queryKey.GetValue("ShowWordWrap", 1);
             optionsShowWordWrap = (showValue != 0);
             
             // keyword - in case a customer needs an override!
             optionsBatchSeparator = (string)queryKey.GetValue( "BatchSeparator", "GO" );
             
             lastQueryTargetFile = (string)queryKey.GetValue( "LastQueryTarget", "" );
             optionsQueryDirectory = (string)queryKey.GetValue("QueryDirectory", "");
             
             if ( !optionsShowSummary && !optionsShowCombinedResults && !optionsShowCombinedResults )
             {
                optionsShowSummary = true;
             }
         }
         catch ( Exception ex )
         {
             CoreGlobals.traceLog.ErrorFormat( "ReadOptions error: {0}", ex.Message );
         }
         finally
         {
             if (toolsetKey != null) toolsetKey.Close();
             if (queryKey != null) queryKey.Close();
         }
     }
      
   }
}
