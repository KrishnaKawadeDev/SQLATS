using System;
using System.Data.OleDb;
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading;
using System.Security.Principal;
using System.Net;
using System.Management;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SqlDiscovery
{
	/// <summary>
	/// Summary description for ActiveDirectoryCheck.
	/// </summary>
	public class ActiveDirectoryCheck
	{

		private string alternateUsername;
		private string alternatePassword;
		private string alternateDomain;

		public ActiveDirectoryCheck(string txtAlternateUsername, string txtAlternatePassword, string txtAlternateDomain)
		{
			alternateUsername = txtAlternateUsername;
			alternatePassword = txtAlternatePassword;
			alternateDomain = txtAlternateDomain;
		}

		public void Scan()
		{
			try
			{
				//int ADS_SCOPE_SUBTREE = 2;
				OleDbConnection objConnection = new OleDbConnection();
                if (alternateUsername == "")
                {
                    objConnection.ConnectionString = "Provider=ADsDSOObject;searchscope=2";
                }
                else
                {
                    if (alternateDomain == "")
                    {
                        objConnection.ConnectionString = "Provider=ADsDSOObject;searchscope=2;User Id=" + alternateUsername + ";Password=" + alternatePassword;
                    }
                    else
                    {
                        string _UserDomain = alternateDomain;
                        if (_UserDomain.Contains("."))
                        {
                            _UserDomain = _UserDomain.Substring(0, _UserDomain.IndexOf("."));
                        }

                        objConnection.ConnectionString = "Provider=ADsDSOObject;searchscope=2;User Id=" + _UserDomain + "\\" + alternateUsername + ";Password=" + alternatePassword;
                    }
                }
				OleDbCommand objCommand = new OleDbCommand();
				//"Active Directory Provider";
				objConnection.Open(); 
				objCommand.Connection = objConnection;
				string domain = "";
                if (alternateDomain == "")
                {
                    SelectQuery query = new SelectQuery("Win32_ComputerSystem");
                    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
                    {
                        foreach (ManagementObject mo in searcher.Get())
                        {
                            if ((bool)mo["partofdomain"])
                            {
                                domain = mo["domain"].ToString();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    domain = alternateDomain;
                }

                CoreGlobals.traceLog.Debug(domain);
                
                string _LdapPath = string.Empty;
                foreach (string _Segment in domain.Split('.'))
                {
                    if (_LdapPath.Length > 0)
                    {
                        _LdapPath += ",";
                    }
                    _LdapPath += string.Format("DC={0}", _Segment);
                }
                CoreGlobals.traceLog.Debug(_LdapPath);

                objCommand.CommandText = "Select displayName, mS-SQL-Build, mS-SQL-TCPIP, name, mS-SQL-ServiceAccount, mS-SQL-Clustered, mS-SQL-RegisteredOwner from 'LDAP://" + _LdapPath + "' where objectClass='mS-SQL-SQLServer'"; 
				//objCommand.Properties("Page Size") = 1000;
				//objCommand.Properties("Timeout") = 30 ;
				//objCommand.Properties("Searchscope") = ADS_SCOPE_SUBTREE ;
				//objCommand.Properties("Cache Results") = False ;
				OleDbDataReader rdr = objCommand.ExecuteReader();
				if (rdr.HasRows)
				{
				   while (rdr.Read())
				   {
                       string _ServerName = rdr.GetValue(6).ToString();
                       if (_ServerName.Contains("\\"))
                       {
                           _ServerName = _ServerName.Substring(0, _ServerName.IndexOf('\\'));
                       }

                       IPHostEntry _Ip = null;
                       try
                       {
                           _Ip = Dns.GetHostEntry(_ServerName);
                       }
                       catch { }
                       
					   Utility.PushResults(
                           /* txtServerIP        */   (_Ip == null) ? "" : _Ip.AddressList[0].ToString(),
                            /* txtServerName      */   _ServerName,
                            /* txtInstanceName    */   rdr.GetValue(3).ToString(),
                            /* txtIsClustered     */   rdr.GetValue(1).ToString(),
                            /* txtVersion         */   rdr.GetValue(5).ToString(),
                            /* txtTCPPort         */   rdr.GetValue(4).ToString(),
                            /* txtProtocols       */   "RegisteredOwner: " + rdr.GetValue(0).ToString(),
                            /* txtTrueVersion,    */   "",
                            /* txtServiceAccount  */   rdr.GetValue(2).ToString(),
                            /* txtDetectionMethod */   "AD",
                            /* txtSSNetlibVersion */   "");
				   }
				}
				
				objConnection.Close();
			}
			catch (Exception e)
			{	
				Utility.WriteDebug("AD : " + e.Source + " ->" + e.Message);
			}
		}

	}
}
