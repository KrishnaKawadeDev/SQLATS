using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.Launchpad
{
   class ProductConstants
   {
      // Product Name
      public static string shortProductName   = "Launchpad";
      public static string productName        = "Launchpad";
      public static string productDescription = "The tools necessary to exercise your super powers";

      // CommandLine Support
      public static bool supportsCommandLine = false;
      public static string usage = "Syntax:\r\n" +
                                      "    Launchpad /arg1:value /arg2:value\r\n" +
                                      "Parameters:\r\n" +
                                      "    /arg1:value" +
                                      "    /arg2:value";


      // Resource Strings
   }
}
