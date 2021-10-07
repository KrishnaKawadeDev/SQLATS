using System;
using System.Diagnostics;
using System.Net;
using System.Security.Principal;

using Idera.SqlAdminToolset.Core;


namespace Idera.SqlAdminToolset.SqlDiscovery
{
	/// <summary>
	/// Summary description for SCMCheck.
	/// 
	/// SCMCheck uses the service control manager to find SQL Server instances.  
	/// Advantage: No admin rights required and works by default
	/// Drawbacks: Minimal information returned - no ports - no version info 
	///		 
	/// Requires use of sc.exe via process shell.  I hate that but the framework offers no alternatives.
	/// 
	/// </summary>
	public class SCMCheck
	{
		private string remoteIP;
		private string alternateUsername;
		private string alternatePassword;
		private string alternateDomain;
		private WindowsImpersonationContext impContext = null;

		public SCMCheck(string txtRemoteIP, string txtAlternateUsername, string txtAlternatePassword, string txtAlternateDomain)
		{
			remoteIP=txtRemoteIP;
			alternateUsername = txtAlternateUsername;
			alternatePassword = txtAlternatePassword;
			alternateDomain = txtAlternateDomain;
		}

		public void Scan() 
		{
         using ( CoreGlobals.traceLog.DebugCall() )
         {

			string instance = "";
			string serviceaccount = "";
			string servicestartup = "";
			string serviceexe = "";

			try 
			{
				if (alternateUsername!="") impContext = LogonUtility.ImpersonateUser(alternateUsername,alternatePassword,alternateDomain);


				ProcessStartInfo proc = new ProcessStartInfo();
				proc.UseShellExecute = false;
				proc.CreateNoWindow = true;
				proc.RedirectStandardOutput = true; 
				proc.WindowStyle = ProcessWindowStyle.Hidden;
				proc.FileName="sc.exe";
				proc.Arguments="\\\\"+remoteIP+" query state= all bufsize= 50000";

				Utility.WriteDebug(remoteIP, " SCM : SC Process Start" );

				Process p = Process.Start(proc);
				string[] ans = p.StandardOutput.ReadToEnd().Split("\n".ToCharArray());
				p.WaitForExit();
				p.Close();
				
				Utility.WriteDebug(remoteIP, " SCM : SC Process Complete" );
				
				foreach (string line in ans)
				{
				   if ( line.StartsWith( "SERVICE_NAME:" ) )
				   {
				      string nm = line.Substring( 13 ).Trim().ToUpper();
				      if ( nm == "MSSQLSERVER" || nm.StartsWith( "MSSQL$" ) )
					   {
       				   Utility.WriteDebug(remoteIP, " SCM : SERVICE_NAME: " + line);

						   instance = line.Substring(line.IndexOf(":")+1).Trim();
						   
						   proc.Arguments="\\\\"+remoteIP+" qc "+instance;
						   p = Process.Start(proc);
						   string[] ans2 = p.StandardOutput.ReadToEnd().Split("\n".ToCharArray());
						   p.WaitForExit();
						   p.Close();

						   foreach (string line2 in ans2)
						   {
          				   Utility.WriteDebug(remoteIP, " SCM : QA Answer: " + line2);
						   
							   if (line2.IndexOf("START_TYPE")!=-1)         servicestartup = line2.Substring(line2.IndexOf(":")+1).Trim();
							   if (line2.IndexOf("BINARY_PATH_NAME")!=-1)   serviceexe = line2.Substring(line2.IndexOf(":")+1).Trim();
							   if (line2.IndexOf("SERVICE_START_NAME")!=-1) serviceaccount = line2.Substring(line2.IndexOf(":")+1).Trim();
						   }
						   
						   string host = Utility.GetHostFromIP(remoteIP);
						   
						   Utility.PushResults(
                               /* txtServerIP        */  remoteIP,
                               /* txtServerName      */  host,
                               /* txtInstanceName    */  ((instance.ToUpper().Substring(0, 6) == "MSSQL$") ? instance.Substring(6) : instance),
                               /* txtIsClustered     */  "",
                               /* txtVersion         */  "",
                               /* txtTCPPort         */  "",
                               /* txtProtocols       */  "Start_Mode: " + servicestartup + "  Path:" + serviceexe,
                               /* txtTrueVersion,    */  "",
                               /* txtServiceAccount  */  serviceaccount,
                               /* txtDetectionMethod */  "SCM",
                               /* txtSSNetlibVersion */  "");
					   }
					}
				} 
		  }
			catch (Exception e)
			{	
				Utility.WriteDebug(remoteIP, " SCM : " + e.Source + " ->" + e.Message);
			}
			finally
			{
				try
				{
					if (impContext!=null) impContext.Undo();
				}
				catch
				{}
			}
		}
      }
	}
}
