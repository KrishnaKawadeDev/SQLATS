using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.Core
{
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
}
