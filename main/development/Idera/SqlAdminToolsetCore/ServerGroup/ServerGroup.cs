using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using System.Security;
using System.Xml;
using System.IO;
using Microsoft.SqlServer.Management.RegisteredServers;

namespace Idera.SqlAdminToolset.Core
{
    #region Class ToolServer

    public class ToolServer
    {
        public string Name;
        public SQLCredentials Credentials;

        public ToolServer(ToolServer server)
        {
            Name = server.Name;
            Credentials = server.Credentials;
        }

        public ToolServer() : this("") { }

        public ToolServer(string name)
        {
            Name = name;
            Credentials = null;
        }

        public ToolServer(string name, SQLCredentials credentials)
        {
            Name = name;
            Credentials = credentials;
        }

        public ToolServer(string name, bool secureLogin, string login, string password)
        {
            Name = name;
            Credentials = new SQLCredentials(secureLogin, login, password);
        }
    }

    #endregion

    #region Class ToolServerGroup

    public class ToolServerGroup
    {
        public string Name;
        public List<ToolServerGroup> Groups;
        public List<ToolServer> Servers;

        public ToolServerGroup Parent;

        public ToolServerGroup()
            : this("")
        {
            Name = "";
            Parent = null;
        }

        public ToolServerGroup(string groupName)
        {
            Name = groupName;
            Parent = null;
            Groups = new List<ToolServerGroup>();
            Servers = new List<ToolServer>();
        }

        public ToolServerGroup(string groupName, ToolServerGroup parent)
        {
            Name = groupName;

            Parent = parent;

            Groups = new List<ToolServerGroup>();
            Servers = new List<ToolServer>();
        }

        public ToolServerGroup Clone()
        {
            ToolServerGroup newGroup = new ToolServerGroup(Name, null);

            newGroup.Parent = Parent;

            foreach (ToolServerGroup group in Groups)
            {
                newGroup.Groups.Add(group);
            }
            foreach (ToolServer server in Servers)
            {
                newGroup.Servers.Add(server);
            }
            return newGroup;
        }

        public string FullPath
        {
            get
            {
                if (Parent == null)
                {
                    return "";
                }
                else
                {
                    return Path.Combine(Parent.FullPath, Name);
                }
            }
        }

        public List<ToolServer> GetServers(bool recursive)
        {
            List<ToolServer> children = new List<ToolServer>();
            foreach (ToolServer s in Servers)
            {
                children.Add(s);
            }

            if (recursive)
            {
                foreach (ToolServerGroup sg in Groups)
                {
                    foreach (ToolServer s2 in sg.Servers)
                    {
                        if (!ContainsServer(children, s2)) children.Add(s2);
                    }

                    foreach (ToolServerGroup g2 in sg.Groups)
                    {
                        List<ToolServer> childServers = g2.GetServers(true);
                        foreach (ToolServer ts in childServers)
                        {
                            if (!ContainsServer(children, ts)) children.Add(ts);
                        }
                    }
                }
            }
            return children;
        }

        private bool ContainsServer(List<ToolServer> listServers, ToolServer server)
        {
            bool contains = false;

            foreach (ToolServer ts in listServers)
            {
                if (ts.Name.ToUpper() == server.Name.ToUpper())
                {
                    contains = true;
                    break;
                }
            }

            return contains;
        }

        public List<ToolServerGroup> GetSubgroups(bool recursive)
        {
            List<ToolServerGroup> groupList = new List<ToolServerGroup>();

            foreach (ToolServerGroup g in Groups)
            {
                groupList.Add(g);

                if (recursive)
                {
                    List<ToolServerGroup> subgroups = g.GetSubgroups(true);
                    foreach (ToolServerGroup g2 in subgroups)
                    {
                        groupList.Add(g2);
                    }
                }
            }
            return groupList;
        }

        public void DisposeGroup()
        {
            Servers.Clear();
            foreach (ToolServerGroup subGroup in Groups)
            {
                subGroup.DisposeGroup();
            }
            Groups.Clear();
        }

        #region Find Server Group

        //-----------------------------------------------------------------------
        //  FindServerGroup - return ToolServerGroup represented in path format
        //                    group/group/group
        //-----------------------------------------------------------------------
        public static ToolServerGroup FindServerGroup(string groupPath)
        {
            string[] tokens = groupPath.Split('\\');

            ToolServerGroup group = CoreGlobals.ServerGroupList;
            for (int i = 0; i < tokens.Length; i++)
            {
                group = FindChildGroup(group, tokens[i]);
                if (group == null) break; // cant find! bad path
            }

            return group;
        }

        private static ToolServerGroup FindChildGroup(ToolServerGroup parentGroup, string childName)
        {
            ToolServerGroup childGroup = null;

            foreach (ToolServerGroup g in parentGroup.Groups)
            {
                if (g.Name == childName)
                {
                    childGroup = g;
                    break;
                }
            }

            return childGroup;
        }

        #endregion

        #region Find Server

        private static ToolServer FindChildServer(ToolServerGroup parentGroup, string childName)
        {
            ToolServer childServer = null;

            foreach (ToolServer s in parentGroup.Servers)
            {
                if (s.Name == childName)
                {
                    childServer = s;
                    break;
                }
            }

            return childServer;
        }

        #endregion

        #region Add/Remove Server

        public void AddSubgroup(string groupName)
        {
            ToolServerGroup group = new ToolServerGroup(groupName, this);
            Groups.Add(group);
        }

        public bool AddServer(string serverName)
        {
            return AddServer(serverName, null);
        }

        public bool AddServer(string serverName, SQLCredentials credentials)
        {
            ToolServer toolServer = new ToolServer(serverName, credentials);
            return AddServer(toolServer);
        }

        public bool AddServer(ToolServer server)
        {
            if (Servers.Contains(server)) return false;
            Servers.Add(server);
            return true;
        }

        #endregion

        #region static - enumeration

        public static List<ToolServerGroup> GetAllServerGroups()
        {
            // check if on disk list is newer
            if ( ToolServerGroup.IsOnDiskFileGroupListNewer() )
            {
               // reload list and fire event to tell tool that the list has changed
               ToolServerGroup.ReadGlobalGroupList();
               CoreGlobals.ServerGroupList.RaiseServerGroupsChangedEvent();
            }
        
            List<ToolServerGroup> groupList = CoreGlobals.ServerGroupList.GetSubgroups(true);

            return groupList;
        }

        #endregion

        #region static - XML Persistence

        #region Write

        static public void WriteGlobalGroupList()
        {
            try
            {
                string xmlFolder = Helpers.GetSuiteDirectory(true);
                string xmlFileName = Path.Combine(xmlFolder, CoreGlobals.serverGroupFile);

                using (XmlTextWriter textWriter = new XmlTextWriter(xmlFileName, Encoding.UTF8))
                {
                    textWriter.WriteStartDocument();
                    textWriter.WriteWhitespace("\r\n");
                    textWriter.WriteStartElement("Groups");
                    textWriter.WriteAttributeString("Timestamp", DateTime.Now.ToString());
                    textWriter.WriteWhitespace("\r\n");

                    foreach (ToolServerGroup group in CoreGlobals.ServerGroupList.Groups)
                    {
                        WriteGroupXML(textWriter, group);
                        textWriter.WriteWhitespace("\r\n");
                    }

                    textWriter.WriteEndElement(); // Groups
                    textWriter.WriteEndDocument();

                    textWriter.Close();
                }
            }
            catch (Exception ex)
            {
                Messaging.ShowException("Error writing Server Group List", ex);

                CoreGlobals.traceLog.ErrorFormat("Error writing server groups list: {0}", Helpers.GetCombinedExceptionText(ex));
            }
        }

        static private void WriteGroupXML(XmlTextWriter textWriter, ToolServerGroup group)
        {
            textWriter.WriteStartElement("Group");

            textWriter.WriteElementString("Name", group.Name);

            // Servers
            foreach (ToolServer server in group.Servers)
            {
                textWriter.WriteStartElement("Server");
                textWriter.WriteElementString("Name", server.Name);
                if ((server.Credentials != null) )//&& (server.Credentials.useSqlAuthentication))
                {
                    textWriter.WriteElementString("useSqlAuthentication", server.Credentials.useSqlAuthentication.ToString());
                    textWriter.WriteElementString("Login", EncryptionHelper.QuickEncrypt(server.Credentials.loginName));
                    textWriter.WriteElementString("Password", EncryptionHelper.QuickEncrypt(server.Credentials.password));
                }
                textWriter.WriteEndElement();
            }

            // Subgroups
            foreach (ToolServerGroup subGroup in group.Groups)
            {
                WriteGroupXML(textWriter, subGroup);
            }

            textWriter.WriteEndElement(); // Group
        }

        #endregion

        #region Read

        public static void InitializeServerGroupList()
        {
            string xmlFolder = Helpers.GetSuiteDirectory(true);
            string xmlFileName = Path.Combine(xmlFolder, CoreGlobals.serverGroupFile);

            if (File.Exists(xmlFileName))
            {
                ReadGlobalGroupList();
            }
            else
            {
                //bool haveSomeGroups = false;

                try
                {
                    ImportSMOGroups();
                }
                catch (Exception ex1)
                {
                    CoreGlobals.traceLog.ErrorFormat("Error reading SMO Groups: {0}", Helpers.GetCombinedExceptionText(ex1));
                }

                try
                {
                    ImportDMOGroups();
                }
                catch (Exception ex2)
                {
                    CoreGlobals.traceLog.ErrorFormat("Error reading DMO Groups: {0}", Helpers.GetCombinedExceptionText(ex2));
                }

                WriteGlobalGroupList();
            }
        }

        public static bool IsOnDiskFileGroupListNewer()
        {
            bool onDiskFileGroupListNewer = false;
            DateTime onDiskTimestamp = GetOnDiskGroupListTimestamp();

            if (onDiskTimestamp.CompareTo(CoreGlobals.ServerGroupTimestamp) == 1)
            {
                onDiskFileGroupListNewer = true;
            }

            return onDiskFileGroupListNewer;
        }

        public static DateTime GetOnDiskGroupListTimestamp()
        {
            DateTime onDiskTimestamp = DateTime.MinValue;
            bool gotTimestamp = false;
            string xmlFolder = Helpers.GetSuiteDirectory(true);
            string xmlFileName = Path.Combine(xmlFolder, CoreGlobals.serverGroupFile);

            if (File.Exists(xmlFileName))
            {
                try
                {
                    using (XmlTextReader textReader = new XmlTextReader(xmlFileName))
                    {
                        while (!gotTimestamp && textReader.Read())
                        {
                            switch (textReader.NodeType)
                            {
                                case XmlNodeType.Element:
                                    {
                                        if (textReader.Name == "Groups")
                                        {
                                            // old versions of file will not have this attribute
                                            // just catch exception and
                                            //DateTime fileDate = DateTime.MinValue;
                                            try
                                            {
                                                string s = textReader.GetAttribute("Timestamp");
                                                onDiskTimestamp = Convert.ToDateTime(s);
                                            }
                                            catch (Exception ex) { CoreGlobals.traceLog.ErrorFormat("get timestamp {0}", ex); }
                                            gotTimestamp = true;
                                        }
                                    }
                                    break;
                            }
                        }
                        textReader.Close();
                    }
                }
                catch (Exception ex)
                {
                    CoreGlobals.traceLog.ErrorFormat("Error reading Server Group List. Error: {0}", ex);
                }
            }

            return onDiskTimestamp;
        }

        public static bool ReadGlobalGroupList()
        {
            bool readSucceeded = false;
            string xmlFolder = Helpers.GetSuiteDirectory(true);
            string xmlFileName = Path.Combine(xmlFolder, CoreGlobals.serverGroupFile);

            if (!File.Exists(xmlFileName))
                return false;

            try
            {
                CoreGlobals.ServerGroupList.Groups.Clear();
                CoreGlobals.ServerGroupList.Servers.Clear();

                bool inGroup = true;
                bool inGroupName = true;

                using (XmlTextReader textReader = new XmlTextReader(xmlFileName))
                {
                    while (textReader.Read())
                    {
                        switch (textReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                {
                                    if (textReader.Name == "Groups")
                                    {
                                        // old versions of file will not have this attribute
                                        // just catch exception and
                                        //DateTime fileDate = DateTime.MinValue;
                                        try
                                        {
                                            string s = textReader.GetAttribute("Timestamp");
                                            CoreGlobals.ServerGroupTimestamp = Convert.ToDateTime(s);
                                        }
                                        catch (Exception ex)
                                        {
                                           CoreGlobals.traceLog.ErrorFormat("get timestamp {0}", ex);
                                        }
                                    }

                                    if (textReader.Name == "Group")
                                        inGroup = true;
                                    if (inGroup && textReader.Name == "Name")
                                        inGroupName = true;
                                }
                                break;

                            case XmlNodeType.Text:
                                if (inGroupName)  //TODO: inGroupName is always true- should it be?
                                {
                                    inGroup = false;
                                    ToolServerGroup group = ProcessXmlGroup(textReader, CoreGlobals.ServerGroupList);
                                    CoreGlobals.ServerGroupList.Groups.Add(group);
                                }

                                break;
                        }
                    }
                    textReader.Close();
                }
            }
            catch (Exception ex)
            {
                CoreGlobals.traceLog.ErrorFormat("Error reading Server Group List. Error: {0}", ex);
            }

            return readSucceeded;
        }

        private static ToolServerGroup ProcessXmlGroup(XmlTextReader textReader, ToolServerGroup parentGroup)
        {
            bool stillReadingGroup = true;
            bool inServer = false;
            bool inServerName = false;
            bool inGroupName = false;
            bool inGroup = false;
            bool inLogin = false;
            bool inPassword = false;
            bool inAuthType = false;
            ToolServerGroup group = new ToolServerGroup(textReader.Value, parentGroup);
            ToolServer newServer = null;

            while (stillReadingGroup && textReader.Read())
            {
                switch (textReader.NodeType)
                {
                    case XmlNodeType.Element:
                        {
                            if (textReader.Name == "Group")
                                inGroup = true;
                            else if (textReader.Name == "Server")
                                inServer = true;
                            else if (textReader.Name == "Login")
                                inLogin = inServer;
                            else if (textReader.Name == "Password")
                                inPassword = inServer;
                            else if (textReader.Name == "Name")
                            {
                                if (inServer) inServerName = true;
                                if (inGroup) inGroupName = true;
                            }
                            else if (textReader.Name == "useSqlAuthentication")
                                inAuthType = inServer;
                        }
                        break;

                    case XmlNodeType.Text:
                        if (inGroupName)
                        {
                            inGroup = false;
                            ToolServerGroup newGroup = ProcessXmlGroup(textReader, group);
                            group.Groups.Add(newGroup);
                        }
                        else if (inServerName)
                        {
                            newServer = new ToolServer(textReader.Value);
                            inServerName = false;
                        }
                        else if (inLogin)
                        {
                            if (newServer != null)
                            {
                                string login = textReader.Value;
                                if (login != "")
                                {
                                    if (newServer.Credentials == null)
                                        newServer.Credentials = new SQLCredentials(true);
                                    newServer.Credentials.loginName = EncryptionHelper.QuickDecrypt(login);
                                }
                                else
                                {
                                    newServer.Credentials.useSqlAuthentication = false;
                                }
                            }
                            inLogin = false;
                        }
                        else if (inPassword)
                        {
                            if ((newServer != null) && (newServer.Credentials != null))
                            {
                                string password = textReader.Value;
                                if (password != "")
                                {
                                    newServer.Credentials.password = EncryptionHelper.QuickDecrypt(password);
                                }
                            }
                            inPassword = false;
                        }
                        else if (inAuthType)
                        {
                            if (newServer != null)
                            {
                                if (textReader.Value != "")
                                {
                                    bool useSqlAuthentication = Convert.ToBoolean(textReader.Value);
                                    newServer.Credentials = new SQLCredentials(useSqlAuthentication);
                                }
                            }
                            inAuthType = false;
                        }
                        break;

                    case XmlNodeType.EndElement:
                        {
                            if (textReader.Name == "Group")
                            {
                                stillReadingGroup = false;
                            }
                            else if (textReader.Name == "Server")
                            {
                                inServer = false;
                                if (newServer != null)
                                {
                                    group.Servers.Add(newServer);
                                    newServer = null;
                                }
                            }
                        }
                        break;

                }
            }
            return group;
        }
        #endregion

        #endregion

        #region Static - Import Server Groups from SMO

        static public void ImportSMOGroups()
        {
            bool allServersGroupFound = false;
            const string _GroupDelimiter = "ServerGroup/";
            ToolServerGroup AllServersGroup = new ToolServerGroup(CoreGlobals.AllSMOServersGroup, CoreGlobals.ServerGroupList);

            //SQLADMI 1587
            CoreGlobals.traceLog.Debug(string.Format("Searching for " + CoreGlobals.ServerGroupXmlFile, "110"));//SQL2012
            if (File.Exists(string.Format(CoreGlobals.ServerGroupXmlFile, "110"))) //11.0 Registered Server
            {
                CoreGlobals.traceLog.Debug(string.Format("Found " + CoreGlobals.ServerGroupXmlFile, "110"));
                XmlDocument doc = new XmlDocument();
                doc.Load(string.Format(CoreGlobals.ServerGroupXmlFile, "110"));

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("ab", "http://schemas.serviceml.org/smlif/2007/02");
                nsmgr.AddNamespace("RegisteredServers", "http://schemas.microsoft.com/sqlserver/RegisteredServers/2007/08");

                XmlNodeList nodes = doc.DocumentElement.SelectNodes("//ab:instances/ab:document/ab:data/RegisteredServers:RegisteredServer[RegisteredServers:ServerType=\"DatabaseEngine\"]", nsmgr);
                foreach (XmlNode node in nodes)
                {

                    string _GroupName = string.Empty;
                    string _ServerName = string.Empty;
                    string _Connection = string.Empty;

                    foreach (XmlNode child in node.ChildNodes)
                    {
                        switch (child.Name.Substring(child.Name.IndexOf(':') + 1))
                        {
                            case "Parent":
                                _GroupName = child.InnerText.Substring(child.InnerText.IndexOf("DatabaseEngineServerGroup") + "DatabaseEngineServerGroup".Length);
                                if (_GroupName.StartsWith("/"))
                                {
                                    _GroupName = _GroupName.Substring(1);
                                }
                                _GroupName = _GroupName.Replace("_/", "/");  //Replace escape character
                                break;
                            case "ServerName":
                                _ServerName = child.InnerText;
                                break;
                            case "ConnectionStringWithEncryptedPassword":
                                _Connection = child.InnerText;
                                break;
                        }
                    }

                    if (_GroupName == CoreGlobals.AllSMOServersGroup) allServersGroupFound = true;

                    ToolServer _NewServer = new ToolServer(_ServerName, new SQLCredentials(_Connection));
                    ToolServerGroup _ParentGroup = AllServersGroup;

                    if (_GroupName.Length > 0)
                    {
                        ToolServerGroup _Group = new ToolServerGroup(_GroupName, _ParentGroup);

                        if (!_GroupName.Contains(_GroupDelimiter))
                        {
                            ToolServerGroup _GroupInList = _ParentGroup.Groups.Find(delegate(ToolServerGroup group) { return group.Name == _GroupName; });
                            if (_GroupInList == null)
                            {
                                _ParentGroup.Groups.Add(_Group);
                            }
                            else
                            {
                                _Group = _GroupInList;
                            }
                        }

                        while (_GroupName.Contains(_GroupDelimiter))
                        {
                            if (_GroupName.StartsWith(_GroupDelimiter))
                            {
                                _GroupName = _GroupName.Substring(_GroupDelimiter.Length);
                            }
                            if (_GroupName.StartsWith("/" + _GroupDelimiter))
                            {
                                _GroupName = _GroupName.Substring(_GroupDelimiter.Length + 1);
                            }
                            string _SubGroup = "";
                            if (_GroupName.Contains(_GroupDelimiter))
                            {
                                _SubGroup = _GroupName.Substring(0, _GroupName.IndexOf(_GroupDelimiter));
                                if (_SubGroup.StartsWith("/"))
                                {
                                    _SubGroup = _SubGroup.Substring(1);
                                }
                                if (_SubGroup.EndsWith("/") && !_SubGroup.EndsWith("_/"))
                                {
                                    _SubGroup = _SubGroup.Substring(0, _SubGroup.Length - 1);
                                }
                            }
                            else
                            {
                                _SubGroup = _GroupName;
                            }

                            _Group = _ParentGroup.Groups.Find(delegate(ToolServerGroup group) { return group.Name == _SubGroup; });
                            if (_Group == null)
                            {
                                _Group = new ToolServerGroup(_SubGroup, _ParentGroup);
                                _ParentGroup.Groups.Add(_Group);
                                _ParentGroup = _Group;
                            }
                            else
                            {
                                _ParentGroup = _Group;
                            }
                            _GroupName = _GroupName.Substring(_SubGroup.Length);
                        }
                        _Group.Servers.Add(_NewServer);
                    }
                    else
                    {
                        _ParentGroup.Servers.Add(_NewServer);
                    }
                }
                if (!allServersGroupFound && (AllServersGroup.Groups.Count > 0 || AllServersGroup.Servers.Count > 0) && !CoreGlobals.ServerGroupList.Groups.Contains(AllServersGroup))
                {
                    CoreGlobals.ServerGroupList.Groups.Insert(0, AllServersGroup);
                }
            }




            CoreGlobals.traceLog.Debug(string.Format("Searching for " + CoreGlobals.ServerGroupXmlFile, "120"));//SQL2014
            if (File.Exists(string.Format(CoreGlobals.ServerGroupXmlFile, "120"))) //12.0 Registered Server
            {
                CoreGlobals.traceLog.Debug(string.Format("Found " + CoreGlobals.ServerGroupXmlFile, "120"));
                XmlDocument doc = new XmlDocument();
                doc.Load(string.Format(CoreGlobals.ServerGroupXmlFile, "120"));

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("ab", "http://schemas.serviceml.org/smlif/2007/02");
                nsmgr.AddNamespace("RegisteredServers", "http://schemas.microsoft.com/sqlserver/RegisteredServers/2007/08");

                XmlNodeList nodes = doc.DocumentElement.SelectNodes("//ab:instances/ab:document/ab:data/RegisteredServers:RegisteredServer[RegisteredServers:ServerType=\"DatabaseEngine\"]", nsmgr);
                foreach (XmlNode node in nodes)
                {

                    string _GroupName = string.Empty;
                    string _ServerName = string.Empty;
                    string _Connection = string.Empty;

                    foreach (XmlNode child in node.ChildNodes)
                    {
                        switch (child.Name.Substring(child.Name.IndexOf(':') + 1))
                        {
                            case "Parent":
                                _GroupName = child.InnerText.Substring(child.InnerText.IndexOf("DatabaseEngineServerGroup") + "DatabaseEngineServerGroup".Length);
                                if (_GroupName.StartsWith("/"))
                                {
                                    _GroupName = _GroupName.Substring(1);
                                }
                                _GroupName = _GroupName.Replace("_/", "/");  //Replace escape character
                                break;
                            case "ServerName":
                                _ServerName = child.InnerText;
                                break;
                            case "ConnectionStringWithEncryptedPassword":
                                _Connection = child.InnerText;
                                break;
                        }
                    }

                    if (_GroupName == CoreGlobals.AllSMOServersGroup) allServersGroupFound = true;

                    ToolServer _NewServer = new ToolServer(_ServerName, new SQLCredentials(_Connection));
                    ToolServerGroup _ParentGroup = AllServersGroup;

                    if (_GroupName.Length > 0)
                    {
                        ToolServerGroup _Group = new ToolServerGroup(_GroupName, _ParentGroup);

                        if (!_GroupName.Contains(_GroupDelimiter))
                        {
                            ToolServerGroup _GroupInList = _ParentGroup.Groups.Find(delegate(ToolServerGroup group) { return group.Name == _GroupName; });
                            if (_GroupInList == null)
                            {
                                _ParentGroup.Groups.Add(_Group);
                            }
                            else
                            {
                                _Group = _GroupInList;
                            }
                        }

                        while (_GroupName.Contains(_GroupDelimiter))
                        {
                            if (_GroupName.StartsWith(_GroupDelimiter))
                            {
                                _GroupName = _GroupName.Substring(_GroupDelimiter.Length);
                            }
                            if (_GroupName.StartsWith("/" + _GroupDelimiter))
                            {
                                _GroupName = _GroupName.Substring(_GroupDelimiter.Length + 1);
                            }
                            string _SubGroup = "";
                            if (_GroupName.Contains(_GroupDelimiter))
                            {
                                _SubGroup = _GroupName.Substring(0, _GroupName.IndexOf(_GroupDelimiter));
                                if (_SubGroup.StartsWith("/"))
                                {
                                    _SubGroup = _SubGroup.Substring(1);
                                }
                                if (_SubGroup.EndsWith("/") && !_SubGroup.EndsWith("_/"))
                                {
                                    _SubGroup = _SubGroup.Substring(0, _SubGroup.Length - 1);
                                }
                            }
                            else
                            {
                                _SubGroup = _GroupName;
                            }

                            _Group = _ParentGroup.Groups.Find(delegate(ToolServerGroup group) { return group.Name == _SubGroup; });
                            if (_Group == null)
                            {
                                _Group = new ToolServerGroup(_SubGroup, _ParentGroup);
                                _ParentGroup.Groups.Add(_Group);
                                _ParentGroup = _Group;
                            }
                            else
                            {
                                _ParentGroup = _Group;
                            }
                            _GroupName = _GroupName.Substring(_SubGroup.Length);
                        }
                        _Group.Servers.Add(_NewServer);
                    }
                    else
                    {
                        _ParentGroup.Servers.Add(_NewServer);
                    }
                }
                bool r = CoreGlobals.ServerGroupList.Groups.Contains(AllServersGroup);
                if (!allServersGroupFound && (AllServersGroup.Groups.Count > 0 || AllServersGroup.Servers.Count > 0) && !CoreGlobals.ServerGroupList.Groups.Contains(AllServersGroup))
                {
                    CoreGlobals.ServerGroupList.Groups.Insert(0, AllServersGroup);
                }
            }

            CoreGlobals.traceLog.Debug(string.Format("Searching for " + CoreGlobals.ServerGroupXmlFile, "130"));//SQL2016
            if (File.Exists(string.Format(CoreGlobals.ServerGroupXmlFile, "130"))) //11.0 Registered Server
            {
                CoreGlobals.traceLog.Debug(string.Format("Found " + CoreGlobals.ServerGroupXmlFile, "130"));
                XmlDocument doc = new XmlDocument();
                doc.Load(string.Format(CoreGlobals.ServerGroupXmlFile, "130"));

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("ab", "http://schemas.serviceml.org/smlif/2007/02");
                nsmgr.AddNamespace("RegisteredServers", "http://schemas.microsoft.com/sqlserver/RegisteredServers/2007/08");

                XmlNodeList nodes = doc.DocumentElement.SelectNodes("//ab:instances/ab:document/ab:data/RegisteredServers:RegisteredServer[RegisteredServers:ServerType=\"DatabaseEngine\"]", nsmgr);
                foreach (XmlNode node in nodes)
                {

                    string _GroupName = string.Empty;
                    string _ServerName = string.Empty;
                    string _Connection = string.Empty;

                    foreach (XmlNode child in node.ChildNodes)
                    {
                        switch (child.Name.Substring(child.Name.IndexOf(':') + 1))
                        {
                            case "Parent":
                                _GroupName = child.InnerText.Substring(child.InnerText.IndexOf("DatabaseEngineServerGroup") + "DatabaseEngineServerGroup".Length);
                                if (_GroupName.StartsWith("/"))
                                {
                                    _GroupName = _GroupName.Substring(1);
                                }
                                _GroupName = _GroupName.Replace("_/", "/");  //Replace escape character
                                break;
                            case "ServerName":
                                _ServerName = child.InnerText;
                                break;
                            case "ConnectionStringWithEncryptedPassword":
                                _Connection = child.InnerText;
                                break;
                        }
                    }

                    if (_GroupName == CoreGlobals.AllSMOServersGroup) allServersGroupFound = true;

                    ToolServer _NewServer = new ToolServer(_ServerName, new SQLCredentials(_Connection));
                    ToolServerGroup _ParentGroup = AllServersGroup;

                    if (_GroupName.Length > 0)
                    {
                        ToolServerGroup _Group = new ToolServerGroup(_GroupName, _ParentGroup);

                        if (!_GroupName.Contains(_GroupDelimiter))
                        {
                            ToolServerGroup _GroupInList = _ParentGroup.Groups.Find(delegate (ToolServerGroup group) { return group.Name == _GroupName; });
                            if (_GroupInList == null)
                            {
                                _ParentGroup.Groups.Add(_Group);
                            }
                            else
                            {
                                _Group = _GroupInList;
                            }
                        }

                        while (_GroupName.Contains(_GroupDelimiter))
                        {
                            if (_GroupName.StartsWith(_GroupDelimiter))
                            {
                                _GroupName = _GroupName.Substring(_GroupDelimiter.Length);
                            }
                            if (_GroupName.StartsWith("/" + _GroupDelimiter))
                            {
                                _GroupName = _GroupName.Substring(_GroupDelimiter.Length + 1);
                            }
                            string _SubGroup = "";
                            if (_GroupName.Contains(_GroupDelimiter))
                            {
                                _SubGroup = _GroupName.Substring(0, _GroupName.IndexOf(_GroupDelimiter));
                                if (_SubGroup.StartsWith("/"))
                                {
                                    _SubGroup = _SubGroup.Substring(1);
                                }
                                if (_SubGroup.EndsWith("/") && !_SubGroup.EndsWith("_/"))
                                {
                                    _SubGroup = _SubGroup.Substring(0, _SubGroup.Length - 1);
                                }
                            }
                            else
                            {
                                _SubGroup = _GroupName;
                            }

                            _Group = _ParentGroup.Groups.Find(delegate (ToolServerGroup group) { return group.Name == _SubGroup; });
                            if (_Group == null)
                            {
                                _Group = new ToolServerGroup(_SubGroup, _ParentGroup);
                                _ParentGroup.Groups.Add(_Group);
                                _ParentGroup = _Group;
                            }
                            else
                            {
                                _ParentGroup = _Group;
                            }
                            _GroupName = _GroupName.Substring(_SubGroup.Length);
                        }
                        _Group.Servers.Add(_NewServer);
                    }
                    else
                    {
                        _ParentGroup.Servers.Add(_NewServer);
                    }
                }
                if (!allServersGroupFound && (AllServersGroup.Groups.Count > 0 || AllServersGroup.Servers.Count > 0) && !CoreGlobals.ServerGroupList.Groups.Contains(AllServersGroup))
                {
                    CoreGlobals.ServerGroupList.Groups.Insert(0, AllServersGroup);
                }
            }

            CoreGlobals.traceLog.Debug(string.Format("Searching for " + CoreGlobals.ServerGroupXmlFile, "100"));//SQL2008

            if (File.Exists(string.Format(CoreGlobals.ServerGroupXmlFile, "100")))     //10.0 Registered Server
            {
                CoreGlobals.traceLog.Debug(string.Format("Found " + CoreGlobals.ServerGroupXmlFile, "100"));
                XmlDocument doc = new XmlDocument();
                doc.Load(string.Format(CoreGlobals.ServerGroupXmlFile, "100"));

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("ab", "http://schemas.serviceml.org/smlif/2007/02");
                nsmgr.AddNamespace("RegisteredServers", "http://schemas.microsoft.com/sqlserver/RegisteredServers/2007/08");

                XmlNodeList nodes = doc.DocumentElement.SelectNodes("//ab:instances/ab:document/ab:data/RegisteredServers:RegisteredServer[RegisteredServers:ServerType=\"DatabaseEngine\"]", nsmgr);
                foreach (XmlNode node in nodes)
                {

                    string _GroupName = string.Empty;
                    string _ServerName = string.Empty;
                    string _Connection = string.Empty;

                    foreach (XmlNode child in node.ChildNodes)
                    {
                        switch (child.Name.Substring(child.Name.IndexOf(':') + 1))
                        {
                            case "Parent":
                                _GroupName = child.InnerText.Substring(child.InnerText.IndexOf("DatabaseEngineServerGroup") + "DatabaseEngineServerGroup".Length);
                                if (_GroupName.StartsWith("/"))
                                {
                                    _GroupName = _GroupName.Substring(1);
                                }
                                _GroupName = _GroupName.Replace("_/", "/");  //Replace escape character
                                break;
                            case "ServerName":
                                _ServerName = child.InnerText;
                                break;
                            case "ConnectionStringWithEncryptedPassword":
                                _Connection = child.InnerText;
                                break;
                        }
                    }

                    if (_GroupName == CoreGlobals.AllSMOServersGroup) allServersGroupFound = true;

                    ToolServer _NewServer = new ToolServer(_ServerName, new SQLCredentials(_Connection));
                    ToolServerGroup _ParentGroup = AllServersGroup;

                    if (_GroupName.Length > 0)
                    {
                        ToolServerGroup _Group = new ToolServerGroup(_GroupName, _ParentGroup);

                        if (!_GroupName.Contains(_GroupDelimiter))
                        {
                            ToolServerGroup _GroupInList = _ParentGroup.Groups.Find(delegate(ToolServerGroup group) { return group.Name == _GroupName; });
                            if (_GroupInList == null)
                            {
                                _ParentGroup.Groups.Add(_Group);
                            }
                            else
                            {
                                _Group = _GroupInList;
                            }
                        }

                        while (_GroupName.Contains(_GroupDelimiter))
                        {
                            if (_GroupName.StartsWith(_GroupDelimiter))
                            {
                                _GroupName = _GroupName.Substring(_GroupDelimiter.Length);
                            }
                            if (_GroupName.StartsWith("/" + _GroupDelimiter))
                            {
                                _GroupName = _GroupName.Substring(_GroupDelimiter.Length + 1);
                            }
                            string _SubGroup = "";
                            if (_GroupName.Contains(_GroupDelimiter))
                            {
                                _SubGroup = _GroupName.Substring(0, _GroupName.IndexOf(_GroupDelimiter));
                                if (_SubGroup.StartsWith("/"))
                                {
                                    _SubGroup = _SubGroup.Substring(1);
                                }
                                if (_SubGroup.EndsWith("/") && !_SubGroup.EndsWith("_/"))
                                {
                                    _SubGroup = _SubGroup.Substring(0, _SubGroup.Length - 1);
                                }
                            }
                            else
                            {
                                _SubGroup = _GroupName;
                            }

                            _Group = _ParentGroup.Groups.Find(delegate(ToolServerGroup group) { return group.Name == _SubGroup; });
                            if (_Group == null)
                            {
                                _Group = new ToolServerGroup(_SubGroup, _ParentGroup);
                                _ParentGroup.Groups.Add(_Group);
                                _ParentGroup = _Group;
                            }
                            else
                            {
                                _ParentGroup = _Group;
                            }
                            _GroupName = _GroupName.Substring(_SubGroup.Length);
                        }
                        _Group.Servers.Add(_NewServer);
                    }
                    else
                    {
                        _ParentGroup.Servers.Add(_NewServer);
                    }
                }
                if (!allServersGroupFound && (AllServersGroup.Groups.Count > 0 || AllServersGroup.Servers.Count > 0) && !CoreGlobals.ServerGroupList.Groups.Contains(AllServersGroup))
                {
                    CoreGlobals.ServerGroupList.Groups.Insert(0, AllServersGroup);
                }
            }

            CoreGlobals.traceLog.Debug(string.Format("Searching for " + CoreGlobals.ServerGroupXmlFile, "90"));//SQL2005

            if (AllServersGroup.Groups.Count == 0 && AllServersGroup.Servers.Count == 0 && File.Exists(string.Format(CoreGlobals.ServerGroupXmlFile, "90"))) //9.0 Registered Servers
            {
                CoreGlobals.traceLog.Debug(string.Format("Found " + CoreGlobals.ServerGroupXmlFile, "90"));

                CoreGlobals.traceLog.Debug("90 Servers");
                XmlDocument doc = new XmlDocument();
                doc.Load(string.Format(CoreGlobals.ServerGroupXmlFile, "90"));

                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/RegisteredServers/ServerType[@name = \"Database Engine\"]/*");
                
                foreach (XmlNode node in nodes)
                {
                    Parse90DataFromXml(AllServersGroup, node);
                }
                if (AllServersGroup.Groups.Count > 0 || AllServersGroup.Servers.Count > 0)
                {
                    CoreGlobals.ServerGroupList.Groups.Insert(0, AllServersGroup);
                }
            }
        }

        /// <summary>
        /// Parses Servers and groups from 9.0 XML file.
        /// </summary>
        private static void Parse90DataFromXml(ToolServerGroup parentGroup, XmlNode node)
        {
            if (node.Name == "Group")
            {
                string _GroupName = node.Attributes["name"].Value;
                ToolServerGroup _Group = parentGroup.Groups.Find(delegate(ToolServerGroup group) { return parentGroup.Name == _GroupName; });
                if (_Group == null)
                {
                    _Group = new ToolServerGroup(_GroupName, parentGroup);
                    parentGroup.Groups.Add(_Group);
                }

                foreach (XmlNode _Child in node.ChildNodes)
                {
                    Parse90DataFromXml(_Group, _Child);
                }
            }
            else
            {
                string _ServerName = string.Empty;
                string _UserName = string.Empty;
                string _Password = string.Empty;
                bool _UseSqlAuthentication = false;

                foreach (XmlNode child in node.SelectNodes("ConnectionInformation/*"))
                {
                    switch (child.Name)
                    {
                        case "ServerName":
                            _ServerName = child.InnerText;
                            break;
                        case "AuthenticationType":
                            _UseSqlAuthentication = (child.InnerText == "1");
                            break;
                        case "UserName":
                            _UserName = child.InnerText;
                            break;
                        case "Password":
                            _Password = child.InnerText;
                            break;
                    }
                }
                ToolServer _NewServer;
                if(_UseSqlAuthentication)
                {
                    _NewServer = new ToolServer(_ServerName, true, _UserName, _Password);
                }
                else
                {
                    _NewServer = new ToolServer(_ServerName);
                }

                parentGroup.Servers.Add(_NewServer);
            }
        }

        #endregion
        
        #region Import List of Servers from SMO
        
        public static List<string> GetSmoRegisteredServers()
        {
            List<string> smoServers = new List<string>();
                     
            try
            {
                if (File.Exists(string.Format(CoreGlobals.ServerGroupXmlFile, "100")))     //10.0 Registered Server
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(string.Format(CoreGlobals.ServerGroupXmlFile, "100"));

                    XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                    nsmgr.AddNamespace("ab", "http://schemas.serviceml.org/smlif/2007/02");
                    nsmgr.AddNamespace("RegisteredServers", "http://schemas.microsoft.com/sqlserver/RegisteredServers/2007/08");

                    XmlNodeList nodes = doc.DocumentElement.SelectNodes("//ab:instances/ab:document/ab:data/RegisteredServers:RegisteredServer[RegisteredServers:ServerType=\"DatabaseEngine\"]", nsmgr);
                    foreach (XmlNode node in nodes)
                    {

                        foreach (XmlNode child in node.ChildNodes)
                        {
                            if (child.Name.Substring(child.Name.IndexOf(':') + 1) == "ServerName")
                            {
                                string _NormalizedName = SQLHelpers.NormalizeInstanceName(child.InnerText.ToUpper());
                                if (!smoServers.Contains(_NormalizedName)) smoServers.Add(_NormalizedName);
                            }
                        }
                    }
                }
                else if (File.Exists(string.Format(CoreGlobals.ServerGroupXmlFile, "90"))) //9.0 Registered Servers
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(string.Format(CoreGlobals.ServerGroupXmlFile, "90"));

                    XmlNodeList nodes = doc.DocumentElement.SelectNodes("/RegisteredServers/ServerType[@name = \"Database Engine\"]//ConnectionInformation/*");
                    foreach (XmlNode node in nodes)
                    {
                        if (node.Name == "ServerName")
                        {
                            string _NormalizedName = SQLHelpers.NormalizeInstanceName(node.InnerText.ToUpper());
                            if (!smoServers.Contains(_NormalizedName)) smoServers.Add(_NormalizedName);
                        }

                    }
                }
            }
            catch ( Exception ex )
            {
                CoreGlobals.traceLog.VerboseFormat( "GetSmoRegisteredServers - Exception: {0}", ex.Message );
            }

            return smoServers;
        }
        
        #endregion

        #region static - Import Groups from DMO

        static public void ImportDMOGroups()
        {
            SQLDMO.Application app = null;

            try
            {
                app = new SQLDMO.ApplicationClass();

                // Top level groups
                foreach (SQLDMO.ServerGroup group in app.ServerGroups)
                {
                    ProcessDmoGroup(group, CoreGlobals.ServerGroupList);
                }
            }
            catch ( Exception ex )
            {
                CoreGlobals.traceLog.VerboseFormat( "ImportDMOGroups - Exception: {0}", ex.Message );
            }
            finally
            {
                if (app != null)
                {
                    app.Quit();
                }
            }
        }

        static private void ProcessDmoGroup(SQLDMO.ServerGroup group, ToolServerGroup parent)
        {
            bool addedGroup = false;

            // Only add a new group, if it doesn' exist as a child of the parent
            // otherwise we are refreshing list by adding any new servers we find
            ToolServerGroup newGroup = ToolServerGroup.FindChildGroup(parent, group.Name);
            if (newGroup == null)
            {
                addedGroup = true;
                newGroup = new ToolServerGroup(group.Name, parent);
            }

            foreach (SQLDMO.RegisteredServer server in group.RegisteredServers)
            {
                // Only add a server if it is not already part of group
                bool addedServer = false;
                ToolServer newServer = FindChildServer(newGroup, server.Name);
                if (newServer == null)
                {
                    addedServer = true;
                    newServer = new ToolServer(server.Name);
                }

                if (server.UseTrustedConnection != 0)
                {
                    newServer.Credentials = new SQLCredentials(false);
                }
                else
                {
                    newServer.Credentials = new SQLCredentials(true, server.Login, server.Password);
                }

                if (addedServer)
                {
                    newGroup.Servers.Add(newServer);
                }
            }

            foreach (SQLDMO.ServerGroup subGroup in group.ServerGroups)
            {
                ProcessDmoGroup(subGroup, newGroup);
            }

            if (addedGroup)
            {
                parent.Groups.Add(newGroup);
            }
        }

        #endregion
        
        #region Import list of Servers from DMO

        public static List<string> GetDmoRegisteredServers()
        {
            List<string> dmoServers = new List<string>();
            
            SQLDMO.Application app = null;

            try
            {
                app = new SQLDMO.ApplicationClass();

                // Top level groups
                foreach (SQLDMO.ServerGroup group in app.ServerGroups)
                {
                    List<string> groupServers = GetDmoGroupServers(group);
                    foreach ( string s in groupServers )
                    {
                       if ( ! dmoServers.Contains(s) ) dmoServers.Add(s);
                    }
                }
            }
            catch ( Exception ex )
            {
                CoreGlobals.traceLog.VerboseFormat( "GetDmoRegisteredServers - Exception: {0}", ex.Message );
            }
            finally
            {
                if (app != null)
                {
                    app.Quit();
                }
            }
            
            return dmoServers;
        }
        
        static private List<string>
           GetDmoGroupServers(
              SQLDMO.ServerGroup group
           )
        {
           List<string> groupServers = new List<string>();
           
            foreach (SQLDMO.RegisteredServer server in group.RegisteredServers)
            {
                string s = SQLHelpers.NormalizeInstanceName(server.Name);
                if ( ! groupServers.Contains(s) ) groupServers.Add(s);
            }

            foreach (SQLDMO.ServerGroup subGroup in group.ServerGroups)
            {
                List<string> subgroupServers = GetDmoGroupServers(subGroup);
                foreach ( string s in subgroupServers )
                {
                   if ( ! groupServers.Contains(s) ) groupServers.Add(s);
                }
            }
            
            return groupServers;
        }
        
        
        #endregion

        #region static Group Change Event

        #region Events

        //-----------------------------------------------------------------------
        // ServerGroupsChangedEventHandler
        //-----------------------------------------------------------------------
        public EventHandler _ServerGroupsChanged;

        public EventHandler ServerGroupsChangedHandler
        {
            get { return _ServerGroupsChanged; }
            set { _ServerGroupsChanged = value; }
        }

        public event EventHandler ServerGroupsChanged
        {
            add { _ServerGroupsChanged += value; }
            remove { _ServerGroupsChanged -= value; }
        }

        public void RaiseServerGroupsChangedEvent()
        {
            EventHandler _Handler = ServerGroupsChangedHandler;
            if (_Handler != null)
            {
                _Handler(this, null);
            }
        }

        #endregion

        #endregion

        static public bool IsGroupNameValid(string groupName)
        {
            if (String.IsNullOrEmpty(groupName)) return false;

            char[] invalidChars = new char[] { '&', '<', '>', ';', '"', '\'', '\\', '|', '/', ':', '*', '?', '\r', '\n' };

            if (-1 != groupName.IndexOfAny(invalidChars))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static public string InvalidGroupNameString = "Server group names may not include any of the following characters:\r\n" +
                                                      "  <  >  ;  \"  '  &  \\  /  :  *  ?  |  ";

        public static SQLCredentials
           GetServerCredentials(
              ToolServerGroup serverGroup,
              string serverName
           )
        {
            SQLCredentials credentials = null;

            // walk servers
            foreach (ToolServer server in serverGroup.Servers)
            {
                if (server.Name == serverName)
                {
                    return server.Credentials;
                }
            }

            // recurse on subgroups
            foreach (ToolServerGroup subGroup in serverGroup.Groups)
            {
                credentials = GetServerCredentials(subGroup, serverName);
                if (credentials != null) return credentials;
            }

            return credentials;
        }
    }
    #endregion
}
