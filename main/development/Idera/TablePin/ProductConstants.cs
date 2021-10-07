using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.TablePin
{
   class ProductConstants
   {
      // Product Name
      public static string shortProductName   = "TablePin";
      public static string productName        = "Table Pin";
      public static string productDescription = "View and manage the pinned status of your tables (SQL Server 2000 only)";

      // CommandLine Support
      public static bool supportsCommandLine = false;
      public static string usage = "Syntax:\r\n" +
                                      "    TablePin /arg1:value /arg2:value\r\n" +
                                      "Parameters:\r\n" +
                                      "    /arg1:value" +
                                      "    /arg2:value";


      // Resource Strings
      public static string strTotalDatabases = "{0} total databases";
      public static string strDatabaseWithPinnedTables= "{0} databases with pinned tables";
      public static string strTotalTables = "{0} total tables";
      public static string strPinnedTables = "{0} pinned tables";
      public static string strRows = "{0} rows in the pinned tables";
      public static string strEstimatedSize = "{0} (estimated size of all pinned tables)";
      public static string strEstimatedSizeBlank = "estimated size of all pinned tables";
      public static string strUnknown = "???";
   }
}
