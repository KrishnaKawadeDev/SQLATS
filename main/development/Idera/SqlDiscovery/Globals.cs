using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Idera.SqlAdminToolset.SqlDiscovery
{
   class Globals
   {
		public static bool pushAllow = true;  //Throttle Pushes to prevent data collisions
		public static bool datasetUpdated = false;
   
      public static string alternateUsername = "";
      public static string alternatePassword = "";
      public static string alternateDomain   = "";      
      
      public static string localIP = "";
      
      public static int browserServersCurrent  = 0;
      public static int    browserServersCount = 0;
      
      public static bool          disableSSNetlibVersionCheck = false;
      public static bool          enableICMPCheck = true;
      public static int           localSourcePort  = 0;
      public static int           ICMPTimeout      = 750;
      
       public static Dictionary<string, Result> serversFound = new Dictionary<string, Result>();
		
		//public static ProbeData probeData;
		public static object probeDataLock = new Object();
   }
}
