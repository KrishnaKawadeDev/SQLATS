using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.EmptyTool
{
    class ProductConstants
    {
        // Product Name
        public static string shortProductName   = "$safeprojectname$";
        public static string productName        = "$safeprojectname$";
        public static string productDescription = "One sentence tagline for this tool for here and launchpad";

        // CommandLine Support
        public static bool supportsCommandLine = false;

        public static string usage = "Syntax:\r\n" +
                                     "    $safeprojectname$ /arg1:value /arg2:value\r\n" +
                                     "Parameters:\r\n" +
                                     "    /arg1:value" +
                                     "    /arg2:value";

        // Resource Strings
    }
}
