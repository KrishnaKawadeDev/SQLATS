using System;
using System.Diagnostics;
using System.Management;

using Idera.SqlAdminToolset.Core;


namespace Idera.SqlAdminToolset.SqlDiscovery
{
	/// <summary>
	/// WMICheck uses the WMI to extract SQL Server instances.  Works only on XP, 2003 and later.
	/// </summary>
	public class WMICheck
	{
		private string remoteIP;
		private string alternateUsername;
		private string alternatePassword;
		private string alternateDomain;

		public WMICheck(string txtRemoteIP, string txtAlternateUsername, string txtAlternatePassword, string txtAlternateDomain)
		{
			remoteIP = txtRemoteIP;
			alternateUsername = txtAlternateUsername;
			alternatePassword = txtAlternatePassword;
			alternateDomain = txtAlternateDomain;
		}

		public void Scan()
		{
			try
			{
            using ( CoreGlobals.traceLog.DebugCall() )
            {

				ManagementObjectSearcher query;
				ManagementObjectCollection queryCollection = null;
				System.Management.ObjectQuery oq;

				ConnectionOptions co = new ConnectionOptions();
				if (alternateUsername!="")
				{
					if (alternateDomain=="")
						co.Username = alternateUsername;
					else
						co.Username = alternateDomain + "\\" + alternateUsername;
					co.Password = alternatePassword; 
				}
				System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\" + remoteIP + "\\root\\cimv2", co);      

				//Query remote computer across the connection
				oq = new System.Management.ObjectQuery("SELECT * FROM Win32_Service WHERE Name LIKE \"MSSQL%\"");
				query = new ManagementObjectSearcher(ms,oq);

				queryCollection = query.Get();
				
				// opnly valid service names are  MSSQLSERVER or MSSQL$<instance>

				foreach ( ManagementObject mo in queryCollection)
				{
				   string nm = mo["Name"].ToString().Trim().ToUpper();
					if ( nm=="MSSQLSERVER" || nm.StartsWith("MSSQL$"))	
					{
						Utility.PushResults(
                            /* txtServerIP        */     remoteIP,
                            /* txtServerName      */     mo["SystemName"].ToString(),
                            /* txtInstanceName    */     ((mo["Name"].ToString().Substring(0, 6) == "MSSQL$") ? mo["Name"].ToString().Substring(6) : mo["Name"].ToString()),
                            /* txtIsClustered     */     "",
                            /* txtVersion         */     "",
                            /* txtTCPPort         */     "",
                            /* txtProtocols       */     "StartMode:" + mo["StartMode"].ToString() + " State:" + mo["State"].ToString() + " Path:" + mo["PathName"].ToString(),
                            /* txtTrueVersion,    */     "",
                            /* txtServiceAccount  */     mo["StartName"].ToString(),
                            /* txtDetectionMethod */     "WMI",
                            /* txtSSNetlibVersion */     "");
    				}
				}
				}
			}
			catch (Exception e)
			{	
				Utility.WriteDebug(remoteIP + " WMI : " + e.Source + " ->" + e.Message);
			}



		}

	}
}