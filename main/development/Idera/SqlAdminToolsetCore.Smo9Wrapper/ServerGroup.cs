using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;
using System.Security;
using Microsoft.SqlServer.Management.Smo;
using System.Net;

namespace SqlAdminToolsetCore.Smo9Wrapper
{
    public class ServerGroup
    {
        #region Static - Import Server Groups from SMO

        private static readonly ToolServerGroup AllServersGroup = new ToolServerGroup();
        
        static public ToolServerGroup ImportSMOGroups(string allServerGroupName)
        {
            bool allServersGroupFound = false;

            // Load SMO Groups			   
            foreach (Microsoft.SqlServer.Management.Smo.RegisteredServers.ServerGroup group
               in SmoApplication.SqlServerRegistrations.ServerGroups)
            {
                if (group.Name == allServerGroupName) allServersGroupFound = true;

                ToolServerGroup serverGroup = ProcessSMOGroup(group, AllServersGroup);
                ToolServerGroup.GlobalServerGroupList.Groups.Add(serverGroup);
            }

            // Create a Group of all Servers registered with SMO
            foreach (Microsoft.SqlServer.Management.Smo.RegisteredServers.RegisteredServer srv in SmoApplication.SqlServerRegistrations.RegisteredServers)
            {
                ToolServer newServer;
                if (srv.LoginSecure)
                    newServer = new ToolServer(srv.ServerInstance.ToUpper());
                else
                {
                    string plainPassword = ConvertSecureStringToPlainText(srv.SecurePassword);

                    newServer = new ToolServer(srv.ServerInstance.ToUpper(),
                                                true,
                                                srv.Login,
                                                plainPassword);
                }

                AllServersGroup.Servers.Add(newServer);
            }

            if (!allServersGroupFound && AllServersGroup.Groups.Count != 0)
            {
                ToolServerGroup.GlobalServerGroupList.Groups.Insert(0, AllServersGroup);
            }
            return AllServersGroup;
        }

        static public ToolServerGroup ProcessSMOGroup(
            Microsoft.SqlServer.Management.Smo.RegisteredServers.ServerGroup group,
            ToolServerGroup parent)
        {
            ToolServerGroup newGroup = new ToolServerGroup(group.Name, parent);

            foreach (Microsoft.SqlServer.Management.Smo.RegisteredServers.RegisteredServer server in group.RegisteredServers)
            {
                ToolServer newServer;
                if (server.LoginSecure)
                    newServer = new ToolServer(server.ServerInstance.ToUpper());
                else
                {
                    string plainPassword = ConvertSecureStringToPlainText(server.SecurePassword);

                    newServer = new ToolServer(server.ServerInstance.ToUpper(),
                                                true,
                                                server.Login,
                                                plainPassword);
                }

                newGroup.Servers.Add(newServer);

                if (!AllServersGroup.Servers.Contains(newServer))
                {
                    AllServersGroup.Servers.Add(newServer);
                }
            }

            // recurse through the subgroups
            foreach (Microsoft.SqlServer.Management.Smo.RegisteredServers.ServerGroup subGroup
                in group.ServerGroups)
            {
                ToolServerGroup childServerGroup = ProcessSMOGroup(subGroup, newGroup);
                newGroup.Groups.Add(childServerGroup);
            }

            return newGroup;
        }

        private static string ConvertSecureStringToPlainText(SecureString secureString)
        {
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(secureString);
            return System.Runtime.InteropServices.Marshal.PtrToStringUni(ptr);
        }

        #endregion

        #region Import List of Servers from SMO

        public static List<string> GetSmoRegisteredServers()
        {
            List<string> smoServers = new List<string>();

            try
            {
                // Load SMO Groups			   
                foreach (Microsoft.SqlServer.Management.Smo.RegisteredServers.ServerGroup group
                   in SmoApplication.SqlServerRegistrations.ServerGroups)
                {
                    List<string> serversInGroup = GetSMOGroupServers(group);
                    foreach (string s in serversInGroup)
                    {
                        if (!smoServers.Contains(s)) smoServers.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {
                //CoreGlobals.traceLog.VerboseFormat("GetSmoRegisteredServers - Exception: {0}", ex.Message);
            }
            return smoServers;
        }

        private static List<string>
           GetSMOGroupServers(
               Microsoft.SqlServer.Management.Smo.RegisteredServers.ServerGroup group
            )
        {
            List<string> servers = new List<string>();

            foreach (Microsoft.SqlServer.Management.Smo.RegisteredServers.RegisteredServer server in group.RegisteredServers)
            {
                servers.Add(NormalizeInstanceName(server.ServerInstance));
            }

            // recurse through the subgroups
            foreach (Microsoft.SqlServer.Management.Smo.RegisteredServers.ServerGroup subGroup
                in group.ServerGroups)
            {
                List<string> subGroupServers = GetSMOGroupServers(subGroup);
                foreach (string s in subGroupServers)
                {
                    if (!servers.Contains(s)) servers.Add(s);
                }
            }

            return servers;
        }

        #endregion

        //--------------------------------------------------------------------
        // NormalizeInstanceName - Converts local aliases to actual instance
        //                         name; capitalizes others
        //--------------------------------------------------------------------
        static public string
           NormalizeInstanceName(
              string instanceName
           )
        {
            string host = "";
            string instance = "";
            string port = "";
            string normalizedName = "";

            if (String.IsNullOrEmpty(instanceName)) return instanceName;

            instance = instanceName.Trim().ToUpper();

            // strip off port
            int pos = instance.IndexOf(",");
            if (pos == 0)
            {
                port = instance.Substring(1);
                instance = "";
            }
            else if (pos > 0)
            {
                port = instance.Substring(pos + 1);
                instance = instance.Substring(0, pos);
            }

            // separate at backslash
            pos = instance.IndexOf('\\');
            if (pos == -1)
            {
                host = instance;
                instance = "";
            }
            else
            {
                host = instance.Substring(0, pos);
                instance = instance.Substring(pos);
            }

            if (host == "" ||
                 host == "." ||
                 host == "(LOCAL)" ||
                 host == "LOCALHOST")
            {
                host = Dns.GetHostName().ToUpper();
            }

            normalizedName = host + instance;
            if (port != "") normalizedName += "," + port;

            return (normalizedName);
        }
    }
}
