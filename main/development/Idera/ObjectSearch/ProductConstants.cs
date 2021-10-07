using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.ObjectSearch
{
    class ProductConstants
    {
        // Product Name
        public static string shortProductName   = "ObjectSearch";
        public static string productName        = "Object Search";
        public static string productDescription = "Search the SQL Server namespace for matching strings";
        
        // progress
        public static bool operationInProgress = false;
        public static bool operationCancelled  = false;
        public static bool searchLimitReached  = false;

        // CommandLine Support
        public static bool supportsCommandLine = false;

       public static string usage = "Syntax:\r\n" +
                                       "    ObjectSearch /text:<searchtext> /server:<name> [/database:<name>]\r\n" +
                                       "             [/matchcase] [/user:<login>] [/password:<password>]\r\n" +
                                       "Parameters:\r\n" +
                                       "    /text <text>      - Required: Search text\r\n" +
                                       "    /server <name>    - Required: SQL Server to search\r\n" +
                                       "    /database <name>  - Optional: Database to search. Omit this parameter\r\n" +
                                       "                                  to search all databases.\r\n" +
                                       "    /matchcase        - Optional: Does case sensitive search\r\n" +
                                       "    /user <name>      - Optional: Use to connect with SQL authentication\r\n" +
                                       "    /password <pwd>   - Optional: Use to connect with SQL authentication\r\n" +
                                       "                                  Leave /password off for blank password";


        // Strings
        public static string strAllDatabases = "<search all databases>";
    }
}
