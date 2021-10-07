using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SqlDiscovery
{
	/// <summary>
	/// TcpCheck
    /// This turned out to be one of the easiest scans.  Seriously - maybe 6 lines of code total.  KISS.  Sometimes the .NET Framework is a beautiful thing.
	/// </summary>
	public class TcpCheck
	{
		private string remoteIP;
		private int remotePort;
		private int localPort;

		public TcpCheck(string txtRemoteIP,int txtRemotePort, int txtLocalPort)
		{
			remoteIP=txtRemoteIP;
			remotePort=txtRemotePort;
			localPort=txtLocalPort;
		}

		public void Scan() 
		{
         using ( CoreGlobals.traceLog.DebugCall() )
         {
			string step = "start";
			
			TcpClient tcp = new TcpClient();
			try 
			{
			   step = "GetHostEntry";
			   string hostEntry = Utility.GetHostFromIP(remoteIP); //Dns.GetHostByAddress(remoteIP).HostName;
			   
			   step = "Connect";
				tcp.Connect(remoteIP, remotePort);
				
				Utility.PushResults(
                    /* txtServerIP        */  remoteIP,
                    /* txtServerName      */  hostEntry,
                    /* txtInstanceName    */  "MSSQLSERVER",
                    /* txtIsClustered     */  "",
                    /* txtVersion         */  "",
                    /* txtTCPPort         */  remotePort.ToString(),
                    /* txtProtocols       */  "No details for TCP probe",
                    /* txtTrueVersion,    */  "",
                    /* txtServiceAccount  */  "",
                    /* txtDetectionMethod */  "TCP",
                    /* txtSSNetlibVersion */  (Globals.disableSSNetlibVersionCheck) ? "" : Idera.SqlAdminToolset.SqlDiscovery.UdpCheck.SSNetlibVersion(remoteIP, remotePort.ToString()) );
			} 
			catch (Exception ex )
			{
			   Utility.WriteDebug( String.Format( "TcpCheck::Scan IP:{0} Port: {1} Step:{2} Exception: {3}", remoteIP, remotePort, step, ex.Message) );
			}
			}
		}
	}
}
