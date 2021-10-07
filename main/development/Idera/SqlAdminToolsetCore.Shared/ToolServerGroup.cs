using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Idera.SqlAdminToolset.Core
{
    public class ToolServerGroup
    {
        public string Name;
        public List<ToolServerGroup> Groups;
        public List<ToolServer> Servers;
        public static ToolServerGroup GlobalServerGroupList = new ToolServerGroup();

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

            ToolServerGroup group = GlobalServerGroupList;
            for (int i = 0; i < tokens.Length; i++)
            {
                group = FindChildGroup(group, tokens[i]);
                if (group == null) break; // cant find! bad path
            }

            return group;
        }

        public static ToolServerGroup FindChildGroup(ToolServerGroup parentGroup, string childName)
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

            char[] invalidChars = new char[] { '&', '<', '>', ';', '"', '\'', '\r', '\n' };

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
                                                      "    &  <  >  ;  \"  '   \\    ";

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
}
