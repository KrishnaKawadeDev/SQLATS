using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.PatchEditor
{
   class ProductConstants
   {
      // Product Name
      public static string shortProductName = "PatchEditor";
      public static string productName = "Patch Editor";
      public static string productDescription = "Report and analyze your SQL Server build levels";

      // Version Files
      public static string SQLServerDefaultVersionFile = "SQLServerVersionList_Default.xml";
      public static string SQLServerVersionFile        = "SQLServerVersionList.xml";
      public static string SQLServerVersionFullPath;
      public static string TempSQLServerVersionFile = "Temp_SQLServerVersionList.xml";
      public static bool   usingOverrideFile = false;
      
      // Download URL
      public static string BuildListURL = @"http://www.idera.com/files/SQLServerVersionList.xml";

      // CommandLine Support
      public static bool supportsCommandLine = false;

      public static string usage = "Syntax:\r\n" +
                                   "    PatchEditor /arg1:value /arg2:value\r\n" +
                                   "Parameters:\r\n" +
                                   "    /arg1:value" +
                                   "    /arg2:value";
      // Resource Strings
   }
}
