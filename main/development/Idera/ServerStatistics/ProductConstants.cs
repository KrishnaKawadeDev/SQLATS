using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.ServerStatistics
{
   class ProductConstants
   {
      // Product Name
      public static string shortProductName = "ServerStatistics";
      public static string productName = "Server Statistics";
      public static string productDescription = "View loads of statistics about your SQL Server";

      // CommandLine Support
      public static bool supportsCommandLine = false;

      public static string usage = "Syntax:\r\n" +
                                   "    ServerStatistics /arg1:value /arg2:value\r\n" +
                                   "Parameters:\r\n" +
                                   "    /arg1:value" +
                                   "    /arg2:value";
      // Resource Strings

       public static string SqlAgentError = "SQL Servere Agent data is not available.  Please enable Agent XPs on the server and verify that you have access";
       public static string ErrorExpandCollapseSelectNode = "You must select an item from the tree";
       public static string VersionNotSupported = "Your version of SQL Server is not supported";
       public static string ExportNoServersSelected = "You must select at least one server";
       public static string ExportNoOptionSelected = "You must select at least one option";
       public static string ExportCommand = "Export";
       public static string PringCommand = "Print";
       public static string RefreshDataWarning = "You have selected to load all server data.  This operation can take a long time, are you sure that you want to proceed?";
       public static string RefreshDataHelp = "To improve performance, Server Statistics does not load all statistics at once.  All data must be fetched from the server in order to do a full export, which could cause some delays.";
   }
}
