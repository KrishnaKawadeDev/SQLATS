using System;
using Microsoft.Win32;
using System.Diagnostics;
using System.Security.Principal;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SqlDiscovery
{
	/// <summary>
	/// Summary description for RegistryCheck.
	/// </summary>
	public class RegistryCheck
	{
		private string remoteIP;
		private string alternateUsername;
		private string alternatePassword;
		private string alternateDomain;
		private WindowsImpersonationContext impContext = null;

		
		public RegistryCheck(string txtRemoteIP, string txtAlternateUsername, string txtAlternatePassword, string txtAlternateDomain)
		{
			remoteIP = txtRemoteIP;
			alternateUsername = txtAlternateUsername;
			alternatePassword = txtAlternatePassword;
			alternateDomain = txtAlternateDomain;
		}

		public void Scan()
		{
         using ( CoreGlobals.traceLog.DebugCall() )
         {

			RegistryKey rk;
			RegistryKey sk;
			string resultInstanceName="";
			string resultTCPPort="";
			string resultVersion="";
			string resultServiceAccount="";
			string resultMachineName="";
			string resultDetails="";

			try
			{
				if (alternateUsername!="") impContext = LogonUtility.ImpersonateUser(alternateUsername,alternatePassword,alternateDomain);
				string currentSubKey="SYSTEM\\CurrentControlSet\\Services\\MSSQLSERVER";
				string currentValueName="DisplayName";
				rk = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, remoteIP);

				try
				{
					sk = rk.OpenSubKey(currentSubKey);
					try
					{
						resultInstanceName = sk.GetValue(currentValueName).ToString();
						
						// pull instance name out of display name
						// two forms
						// SQL Server (instancename)
						// MSSQL$isntancename
						resultInstanceName = resultInstanceName.Trim();
						if ( resultInstanceName.ToUpper().StartsWith( "SQL SERVER (" ) )
						{
						   resultInstanceName = resultInstanceName.Substring(12);
						   if ( resultInstanceName.EndsWith(")") )
						      resultInstanceName = resultInstanceName.Substring( 0, resultInstanceName.Length-1);
						}
						else if ( resultInstanceName.ToUpper().StartsWith( "MSSQL$" ) )
						{
						   resultInstanceName = resultInstanceName.Substring(6);
						}
					
						try
						{
							currentSubKey="SOFTWARE\\Microsoft\\MSSQLServer\\MSSQLServer\\SuperSocketNetLib\\Tcp";
							currentValueName="TcpPort";
							rk = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, remoteIP);
							sk = rk.OpenSubKey(currentSubKey);
							resultTCPPort = sk.GetValue(currentValueName).ToString();
						}
						catch
						{}

						try
						{
							currentSubKey="SYSTEM\\CurrentControlSet\\Services\\MSSQLSERVER";
							currentValueName="ObjectName";
							rk = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, remoteIP);
							sk = rk.OpenSubKey(currentSubKey);
							resultServiceAccount = sk.GetValue(currentValueName).ToString();
						}
						catch
						{}

						try
						{
							currentSubKey="SOFTWARE\\Microsoft\\MSSQLServer\\MSSQLServer\\CurrentVersion";
							currentValueName="CurrentVersion";
							rk = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, remoteIP);
							sk = rk.OpenSubKey(currentSubKey);
							resultVersion = sk.GetValue(currentValueName).ToString();
						}
						catch
						{}

						try
						{
							currentSubKey="SYSTEM\\ControlSet001\\Control\\ComputerName\\ActiveComputerName";
							currentValueName="ComputerName";
							rk = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, remoteIP);
							sk = rk.OpenSubKey(currentSubKey);
							resultMachineName = sk.GetValue(currentValueName).ToString();
						}
						catch
						{}
				
						try
						{
							currentSubKey="SOFTWARE\\Microsoft\\MSSQLServer\\Setup";
							currentValueName="SQLPath";
							rk = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, remoteIP);
							sk = rk.OpenSubKey(currentSubKey);
							resultDetails = "Path: " + sk.GetValue(currentValueName).ToString();
						}
						catch
						{
						   resultDetails = "SQL Server Install path not found";
						}
						
						Utility.PushResults(
                            /* txtServerIP        */    remoteIP,
                            /* txtServerName      */    resultMachineName,
                            /* txtInstanceName    */    resultInstanceName,
                            /* txtIsClustered     */    "",
                            /* txtVersion         */    resultVersion,
                            /* txtTCPPort         */    resultTCPPort,
                            /* txtProtocols       */    resultDetails,
                            /* txtTrueVersion,    */    "",
                            /* txtServiceAccount  */    resultServiceAccount,
                            /* txtDetectionMethod */    "REG",
                            /* txtSSNetlibVersion */    "");

					}
					catch (Exception e)
					{	
						Utility.WriteDebug(remoteIP + " REG : " + e.Source + " ->" + e.Message);
					}

				}
				catch (Exception e)
				{	
					Utility.WriteDebug(remoteIP + " REG : " + e.Source + " ->" + e.Message);
				}

			}
			catch (Exception e)
			{	
				Utility.WriteDebug(remoteIP + " REG : " + e.Source + " ->" + e.Message);
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
