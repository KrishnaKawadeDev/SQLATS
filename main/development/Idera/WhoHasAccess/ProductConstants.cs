using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.WhoHasAccess
{
   class ProductConstants
   {
      // Product Name
      public static string shortProductName = "WhoHasAccess";
      public static string productName = "WhoHasAccess";
      public static string productDescription = "tagline for new tool - a one sentence description";

      // CommandLine Support
      public static bool supportsCommandLine = false;

      public static string usage = "Syntax:\r\n" +
                                   "    WhoHasAccess /arg1:value /arg2:value\r\n" +
                                   "Parameters:\r\n" +
                                   "    /arg1:value" +
                                   "    /arg2:value";
      // Resource Strings
   }
}
