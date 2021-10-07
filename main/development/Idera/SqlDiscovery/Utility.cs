using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Management;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices; 
using System.Security.Principal; 
using System.Text;
using System.IO;
using System.Security.Permissions;
using System.Net;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SqlDiscovery
{
    public class Result
    {
        public string ServerIP;
		public string TCPPort;
		public string ServerName;
		public string InstanceName;
		public string BaseVersion;
		public string SSNetlibVersion;
		public string TrueVersion;
		public string ServiceAccount;
		public string IsClustered;
		public string Details;
		public string DetectionMethod;

        public Result()
        {
        }
    }

	/// <summary>
	/// Summary description for Utility.
	/// </summary>
	///
	public class Utility
	{
	   static Object utilityLock = new Object();
	
		public Utility()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void
           PushResults(
               string txtServerIP,
               string txtServerName,
               string txtInstanceName,
               string txtIsClustered,
               string txtVersion,
               string txtTCPPort,
               string txtProtocols, 
               string txtTrueVersion, 
               string txtServiceAccount, 
               string txtDetectionMethod, 
               string txtSSNetlibVersion )
		{
			try
			{
			   lock( utilityLock )
			   {
				   Globals.pushAllow = false;
				   string strExpr;
       
				   strExpr = String.Format("{0}{1}", txtServerIP.Trim(), txtInstanceName.Trim());
                   Result result = null;

                   if (Globals.serversFound.TryGetValue(strExpr, out result))
				   {
                       CoreGlobals.traceLog.VerboseFormat("Pushresults ServerIP = '{0}' and InstanceName = '{1}' Method: {2} Prot: {3}", txtServerIP.Trim(),
                                                                                                                                         txtInstanceName.Trim(),
                                                                                                                                         txtDetectionMethod,
                                                                                                                                         txtProtocols);

                       //Update Duplicate with any missing data
                       //This allows us to aggregate the responses and get the MOST info we can
                       if (String.IsNullOrEmpty(result.ServerIP)) result.ServerIP = txtServerIP;
                       if (String.IsNullOrEmpty(result.TCPPort)) result.TCPPort = txtTCPPort;
                       if (String.IsNullOrEmpty(result.ServerName)) result.ServerName = txtServerName.ToUpper();
                       if (String.IsNullOrEmpty(result.InstanceName)) result.InstanceName = txtInstanceName.ToUpper();
                       if (String.IsNullOrEmpty(result.BaseVersion)) result.BaseVersion = txtVersion;
                       if (String.IsNullOrEmpty(result.SSNetlibVersion)) result.SSNetlibVersion = txtSSNetlibVersion;
                       if (String.IsNullOrEmpty(result.TrueVersion)) result.TrueVersion = txtTrueVersion;
                       if (String.IsNullOrEmpty(result.ServiceAccount)) result.ServiceAccount = txtServiceAccount;
                       if (String.IsNullOrEmpty(result.IsClustered)) result.IsClustered = txtIsClustered;

                       if (!String.IsNullOrEmpty(txtProtocols))
                           if (String.IsNullOrEmpty(result.Details))
                               result.Details = String.Format("({0});{1}", txtDetectionMethod, txtProtocols); // txtDetectionMethod + ";" + txtProtocols; 
                           else
                               result.Details = String.Format("{0}\t({1});{2}", result.Details, txtDetectionMethod, txtProtocols);
                      
                       if (String.IsNullOrEmpty(result.ServerIP)) result.ServerIP = txtServerIP;

                       if (String.IsNullOrEmpty(result.DetectionMethod))
                           result.DetectionMethod = txtDetectionMethod;
                       else
                           result.DetectionMethod = String.Format("{0} {1}", result.DetectionMethod, txtDetectionMethod);
				   }
				   else
				   {
                       CoreGlobals.traceLog.VerboseFormat("Pushresults ServerIP = '{0}' and InstanceName = '{1}' Method: {2} Prot: {3}",    txtServerIP.Trim(), 
                                                                                                                                            txtInstanceName.Trim(), 
                                                                                                                                            txtDetectionMethod, 
                                                                                                                                            txtProtocols);

                       result = new Result();
                       result.ServerIP = txtServerIP;
                       result.TCPPort = txtTCPPort;
                       result.ServerName = txtServerName.ToUpper();
                       result.InstanceName = txtInstanceName.ToUpper();
                       result.BaseVersion = txtVersion;
                       result.SSNetlibVersion = txtSSNetlibVersion;
                       result.TrueVersion = txtTrueVersion;
                       result.ServiceAccount = txtServiceAccount;
                       result.IsClustered = txtIsClustered;
                       if (!String.IsNullOrEmpty(txtProtocols)) result.Details = String.Format("({0});{1}", txtDetectionMethod, txtProtocols);
                       result.DetectionMethod = txtDetectionMethod;
                       Globals.serversFound.Add(strExpr, result);

                       ProductConstants.mainform.PaintNewRow(result);
				   }
				   Globals.datasetUpdated = true;
				   Globals.pushAllow = true;
				}
			}
			catch (Exception ex )
			{
			    CoreGlobals.traceLog.ErrorFormat( "Pushresults Exception: Source: {0} Message: {1} Server: {2} Instance: {3} Method: {4}",  ex.Source, 
                                                                                                                                            ex.Message, 
                                                                                                                                            txtServerName, 
                                                                                                                                            txtInstanceName, 
                                                                                                                                            txtDetectionMethod );
				Globals.datasetUpdated = true;
				Globals.pushAllow = true;
			}

		}

		public static int GetOctet(long lIP, int nOctet)
		{
			if (nOctet < 0 || nOctet > 3)
				throw new ArgumentException("Octet out of range, only valid from 1-4");

			return (int) ((lIP & (0xFF << ((3 - nOctet) * 8))) >> ((3 - nOctet) * 8));
		}

		public static string LongToIP(long lIP)
		{
			return GetOctet(lIP,0).ToString()
				+ "."
				+ GetOctet(lIP,1).ToString()
				+ "."
				+ GetOctet(lIP,2).ToString()
				+ "."
				+ GetOctet(lIP,3).ToString();
		}

		public static long IPToLong(string sIPAddress)
		{
			Match oMatch = Regex.Match(sIPAddress,@"^(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})$");
            
			long lFirst = 0;
			long lSecond = 0;
			long lThird = 0;
			long lFourth = 0;

			if (oMatch.Success)
			{
				try
				{
					lFirst = Convert.ToInt64(oMatch.Groups[1].ToString());
					lSecond = Convert.ToInt64(oMatch.Groups[2].ToString());
					lThird = Convert.ToInt64(oMatch.Groups[3].ToString());
					lFourth = Convert.ToInt64(oMatch.Groups[4].ToString());
				}
				catch (FormatException e)
				{
					throw e;
				}
				catch (OverflowException eOver)
				{
					throw eOver;
				}
				catch
				{}

				// Check range of values
				if ((lFirst < 0 || lFirst > 255)
					||
					(lSecond < 0 || lSecond > 255)
					||
					(lThird < 0 || lThird > 255)
					||
					(lFourth < 0 || lFourth > 255))
				{
					throw new OverflowException("Invalid Octet range for " + sIPAddress);
				}
				return (lFirst << 24) + (lSecond << 16) + (lThird << 8) + lFourth;
			}
			else
				throw new FormatException("Invalid IPAddress: " + sIPAddress);
		}


		public static long Parse(string sIPAddress)
		{
			Match oMatch = Regex.Match(sIPAddress,@"^(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})$");
            
			long lFirst = 0;
			long lSecond = 0;
			long lThird = 0;
			long lFourth = 0;

			if (oMatch.Success)
			{
				try
				{
					lFirst = Convert.ToInt64(oMatch.Groups[1].ToString());
					lSecond = Convert.ToInt64(oMatch.Groups[2].ToString());
					lThird = Convert.ToInt64(oMatch.Groups[3].ToString());
					lFourth = Convert.ToInt64(oMatch.Groups[4].ToString());
				}
				catch (FormatException e)
				{
					throw e;
				}
				catch (OverflowException eOver)
				{
					throw eOver;
				}
				catch
				{}

				// Check range of values
				if ((lFirst < 0 || lFirst > 255)
					||
					(lSecond < 0 || lSecond > 255)
					||
					(lThird < 0 || lThird > 255)
					||
					(lFourth < 0 || lFourth > 255))
				{
					throw new OverflowException("Invalid Octet range for " + sIPAddress);
				}
				return (lFirst << 24) + (lSecond << 16) + (lThird << 8) + lFourth;
			}
			else
				throw new FormatException("Invalid IPAddress: " + sIPAddress);
		}

		public static bool IsValid(string sIP)
		{
			try
			{
				long lIP = Parse(sIP);
				return true;
			}
			catch (FormatException)
			{
				return false;
			}
			catch (OverflowException)
			{
				return false;
			}
		}

		public static string[] GetIPAddresses() 
		{
			string[] addresses = null;
			try 
			{
				ArrayList Temp = new ArrayList();
				ManagementObjectSearcher query = new ManagementObjectSearcher(
					"SELECT * FROM Win32_NetworkAdapterConfiguration ") ;
				ManagementObjectCollection queryCollection = query.Get();
				foreach( ManagementObject mo in queryCollection ) 
				{
					if ((bool)mo["IpEnabled"]) 
					{
						string[] ips = (string[])mo["IPAddress"];
						foreach (string s in ips) 
						{
							Temp.Add (s);
						}
					}
				}
				if (Temp.Count > 0) 
				{
					addresses = new string[Temp.Count];
					Temp.CopyTo (addresses);
				} 
				else 
				{
					addresses = new string[0];
				}
			} 
			catch (Exception) {}
			return addresses;
		}

		public static void OpenBrowser(string URL)
		{
			Process process = new Process();
			process.StartInfo.FileName = URL;
			process.StartInfo.CreateNoWindow = false;
			process.StartInfo.UseShellExecute = true;
			process.Start();
		}

		public static void WriteDebug(string ip, string debugInfo)
		{
		   WriteDebug( String.Format( "IP: {0}  Details: {1}", ip, debugInfo ) );
		}

		public static void WriteDebug(string debugInfo)
		{
		   CoreGlobals.traceLog.Verbose( debugInfo );
/*
		   if ( Globals.enableDebug )
		   {
			   try
			   {
  			      debugInfo = DateTime.Now.ToString() + " " + debugInfo;
				   byte[] info = new UTF8Encoding(true).GetBytes(debugInfo.ToString());
				   System.IO.FileStream fs = File.Open(Globals.debugFile, FileMode.Append);
				   fs.Write(info,0,info.Length);
				   fs.WriteByte(13);
				   fs.WriteByte(10);
				   fs.Close();
            }
			   catch
			   {}
			}
*/
		}
		
		public static string GetHostFromIP( string ipAddress )
		{
	      string host = "";
	      try
	      {
	         host = Dns.GetHostEntry(ipAddress).HostName;
	      }
	      catch
	      {
	          host = "";
	      }

         // if GetHostEntry failed, we try the deprecated function - GetHostEntry seems particularly buggy
         if ( host == "" )
         {
   	      host = Dns.GetHostByAddress( ipAddress ).HostName;
	      }
	      
	      return host;
		}
		
      public static bool ValidateIPAddress( string ipAddress )
      {
         string [] start = ipAddress.Split('.');
         for ( int i=0;i<start.Length;i++) start[i] = start[i].Trim();
         
         bool valid = ( start.Length == 4 );
         for ( int i=0; valid && i<4; i++ )
         {
            try
            {
               if ( start[i].Length == 0 )
               {
                  valid = false;
               }
               else
               {
                  int val = System.Convert.ToInt32(start[i]);
                  if ( val<0 || val > 255 ) valid = false;
               }
            }
            catch
            {
               valid = false;
            }
         }
         
         return valid;
      }
      
      public static bool ValidateSameSubnet( string startingIp, string endingIp )
      {
         string [] start = startingIp.Split('.');
         string [] end   = endingIp.Split('.');
         for ( int i=0;i<start.Length;i++) start[i] = start[i].Trim();
         for ( int i=0;i<end.Length;i++)   end[i] = end[i].Trim();
         
         if ( start.Length != 4 || end.Length != 4 ) return false;
         
         bool match = true;
         for ( int i=0; i<3; i++ )  // check first 3 parts of subnet
         {
            if ( start[i] != end[i] )
            {
               match = false;
               break;
            }
         }
         
         return match;
      }
	}

	public class LogonUtility
	{

		//import LSA functions

		[DllImport("advapi32.dll")]
		private static extern bool LogonUser(
			String lpszUsername,
			String lpszDomain,
			String lpszPassword,
			int dwLogonType,
			int dwLogonProvider,
			ref IntPtr phToken
			);

		[DllImport("advapi32.dll")]
		private static extern bool DuplicateToken(
			IntPtr ExistingTokenHandle,
			int ImpersonationLevel,
			ref IntPtr DuplicateTokenHandle
			);

		[DllImport("kernel32.dll")]
		private static extern bool CloseHandle(IntPtr hObject);

		[DllImport("advapi32.dll")]
		private static extern bool ImpersonateLoggedOnUser( IntPtr hToken );

		[DllImport("kernel32.dll")]
		private static extern int GetLastError();

		//enum impersonation levels an logon types

		private enum SecurityImpersonationLevel
		{ 
			SecurityAnonymous, 
			SecurityIdentification, 
			SecurityImpersonation, 
			SecurityDelegation 
		}

		private enum LogonTypes
		{
			LOGON32_PROVIDER_DEFAULT = 0,
			LOGON32_LOGON_INTERACTIVE = 2,
			LOGON32_LOGON_NETWORK = 3,
			LOGON32_LOGON_BATCH = 4,
			LOGON32_LOGON_SERVICE = 5,
			LOGON32_LOGON_UNLOCK = 7,
			LOGON32_LOGON_NETWORK_CLEARTEXT = 8,
			LOGON32_LOGON_NEW_CREDENTIALS = 9
		}

		/// <summary>impersonates a user</summary>
		/// <param name="sUsername">domain\name of the user account</param>
		/// <param name="sPassword">the user's password</param>
		/// <returns>the new WindowsImpersonationContext</returns>
		public static WindowsImpersonationContext ImpersonateUser(String username, String password, String domain) 
		{
			//define the handles
			IntPtr existingTokenHandle = IntPtr.Zero;
			IntPtr duplicateTokenHandle = IntPtr.Zero;
			

			bool isOkay = true;

			try 
			{
				//get a security token
				
				isOkay = LogonUser(username, domain, password, 
					(int)LogonTypes.LOGON32_LOGON_INTERACTIVE, (int)LogonTypes.LOGON32_PROVIDER_DEFAULT, 
					ref existingTokenHandle);

				if ( ! isOkay ) 
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					int lastError = GetLastError();
										
					throw new Exception("LogonUser Failed: "+lastWin32Error+" - "+lastError);
				}

				// copy the token
				
				isOkay = DuplicateToken(existingTokenHandle, 
					(int)SecurityImpersonationLevel.SecurityImpersonation, 
					ref duplicateTokenHandle);

				if (! isOkay ) 
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					int lastError = GetLastError();
					CloseHandle(existingTokenHandle); 
					throw new Exception("DuplicateToken Failed: "+lastWin32Error+" - "+lastError);
				}
				else 
				{

					// create an identity from the token
					
					WindowsIdentity newId = new WindowsIdentity(duplicateTokenHandle);
					WindowsImpersonationContext impersonatedUser = newId.Impersonate();

					return impersonatedUser;
				}
			}
			catch (Exception ex) 
			{
				throw ex;
			}
			finally 
			{
				//free all handles
				if (existingTokenHandle != IntPtr.Zero)
				{
					CloseHandle(existingTokenHandle);
				}
				if (duplicateTokenHandle != IntPtr.Zero)
				{
					CloseHandle(duplicateTokenHandle);
				}
			}
		}
		
	}
}
