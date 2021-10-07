using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.ServerPing
{
   class ProductConstants
   {
      // Product Name
      public static string shortProductName = "ServerPing";
      public static string productName = "Server Ping";
      public static string productDescription = "tagline for new tool - a one sentence description";

      // CommandLine Support
      public static bool supportsCommandLine = false;

      public static string usage = "Syntax:\r\n" +
                                   "    ServerPing /arg1:value /arg2:value\r\n" +
                                   "Parameters:\r\n" +
                                   "    /arg1:value" +
                                   "    /arg2:value";
      
      // Properties
      public static bool                   StartInSystemTray = false;
      public static bool                   Uninstall         = false;
      public static DateTime               lastCheckTime     = DateTime.MinValue;
      public static List <MonitoredServer> monitoredServers  = new List<MonitoredServer>();
      
      // Options
      public static bool   warnOnMinimize = true;
      public static bool   warnOnExit     = true;

      public static bool   UseWMI   = true;
      public static bool   RunQuery = false;
      public static string Query    = "SELECT @@VERSION";
      
      public static bool   RunInSystemTray      = true;
      public static bool   AutoRefresh          = true;
      public static int    AutoRefreshInterval  = 10;
      public static bool   AlertOnline          = false;
      public static bool   AlertOffline         = false;
      public static bool   MinimizeToSystemTray = true;
      public static bool   LaunchAtStartup      = false;
      
   }
}
