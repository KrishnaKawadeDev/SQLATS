using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core.Security;
using System.Threading;

namespace Idera.SqlAdminToolset.Core
{
    public class Connection
    {
        private const string patchAnalyzerApp = "Patch Analyzer";
        static Impersonation _Impersonation;
        //-------------------------------------------------------------------
        // CreateConnectionString
        //-------------------------------------------------------------------
        public static string
           CreateConnectionString(
              string server,
              string database
           )
        {
            return CreateConnectionString(server, database, new SQLCredentials(), CoreGlobals.productName);
        }

        public static string
           CreateConnectionString(
              string server,
              string database,
              string applicationName
           )
        {
            return CreateConnectionString(server, database, new SQLCredentials());
        }

        public static string
           CreateConnectionString(
              string server,
              string database,
              SQLCredentials sqlCredentials
           )
        {
            return CreateConnectionString(server, database, sqlCredentials, CoreGlobals.productName);
        }

        public static string
           CreateConnectionString(
              string server,
              string database,
              SQLCredentials sqlCredentials,
              string applicationName
           )
        {
            string dbName = SQLHelpers.CreateSafeDatabaseNameForConnectionString(database);

            string credentialsString = SQLCredentials.GetCredentialsString(sqlCredentials);

            return String.Format("server={0}" +
                                "{1}{2};" +                // database
                                "{3};" +                   // credentials
                                "Connect Timeout={4};" +
                                "Packet Size=8000;" +
                                "Application Name='{5}';",
                                server,
                                String.IsNullOrEmpty(dbName) ? "" : ";database=",
                                String.IsNullOrEmpty(dbName) ? "" : dbName,
                                credentialsString,
                                ToolsetOptions.connectionTimeout,
                                applicationName);
        }

        //---------------------------------------------------------------------
        // OpenConnection - Open a connection to a server/database combination
        //---------------------------------------------------------------------
        public static SqlConnection
           OpenConnection(
              string server
           )
        {

            return OpenConnection(server, null, new SQLCredentials(), CoreGlobals.productName);

        }

        public static SqlConnection
           OpenConnection(
              string server,
              SQLCredentials sqlCredentials
           )
        {
            if (CoreGlobals.productName !=patchAnalyzerApp)
            {
                lock (threadLock)
                {
                    SqlConnection conn = OpenConnection(server, null, sqlCredentials, CoreGlobals.productName);
                    return conn;
                }
            }
            else
            {
                SqlConnection conn = OpenConnection(server, null, sqlCredentials, CoreGlobals.productName);
                return conn;
            }

        }

        public static SqlConnection
           OpenConnection(
              string server,
              SQLCredentials sqlCredentials,
              string applicationName
           )
        {
            return OpenConnection(server, null, sqlCredentials, applicationName);
        }

        public static SqlConnection
           OpenConnection(
              string server,
              string database
           )
        {
            return OpenConnection(server, database, new SQLCredentials(), CoreGlobals.productName);
        }

        public static SqlConnection
           OpenConnection(
              string server,
              string database,
              string applicationName
           )
        {
            return OpenConnection(server, database, new SQLCredentials(), applicationName);
        }

        public static SqlConnection
           OpenConnection(
              string server,
              string database,
              SQLCredentials sqlCredentials
           )
        {
            return OpenConnection(server, database, sqlCredentials, CoreGlobals.productName);
        }
        private static readonly object threadLock = new object();

        private static Mutex mutex = new Mutex();
        public static SqlConnection
           OpenConnection(
              string server,
              string database,
              SQLCredentials sqlCredentials,
              string applicationName
           )
        {
            SqlConnection conn = null;
            try
            {
                if (applicationName != patchAnalyzerApp)
                {
                    lock (threadLock)
                    {

                        string connStr = CreateConnectionString(server,
                                                            database,
                                                            sqlCredentials,
                                                            applicationName);
                        if (sqlCredentials != null && !string.IsNullOrEmpty(sqlCredentials.loginName) && sqlCredentials.loginName.ToLower() != System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToLower())
                            Impersonate(sqlCredentials);


                        conn = new SqlConnection(connStr);

                        conn.Open();
                        return conn;
                    }

                }

                else
                {

                    string connStr = CreateConnectionString(server,
                                                        database,
                                                        sqlCredentials,
                                                        applicationName);
                    if (sqlCredentials != null && !string.IsNullOrEmpty(sqlCredentials.loginName) && sqlCredentials.loginName.ToLower() != System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToLower())
                        Impersonate(sqlCredentials);


                    conn = new SqlConnection(connStr);

                    conn.Open();
                    return conn;
                }
            }

            catch
            {
                if (_Impersonation != null)
                {
                    _Impersonation.Undo();

                    _Impersonation = null;
                }
                throw;
            }
        }

    


        public static void Impersonate(SQLCredentials sqlCredentials)
        {
                lock (threadLock)
                {
                    if (_Impersonation != null)
                    {
                        _Impersonation.Undo();

                        _Impersonation = null;
                    }
                    if (sqlCredentials != null && sqlCredentials.useWindowsAuthentication && !string.IsNullOrEmpty(sqlCredentials.loginName))
                    {

                        _Impersonation = new Impersonation(sqlCredentials.loginName, sqlCredentials.password);
                        _Impersonation.Start();
                    }
                }
            }
     
        

        //-----------------------------------------------------------------------------
        // CloseConnection - close the connection to the SQLsecure configuration database
        //-----------------------------------------------------------------------------
        public static void CloseConnection(SqlConnection conn)
        {
            if (conn != null)
            {
                if (_Impersonation != null)
                {
                    _Impersonation.Undo();
                    _Impersonation = null;
                }
                conn.Close();
                conn.Dispose();
            }
        }

        //-------------------------------------------------------------------
        // CheckState - Make sure a connection is open
        //-------------------------------------------------------------------
        public static void
           CheckState(
              SqlConnection conn
           )
        {
            if (conn.State == ConnectionState.Open) return;

            if (conn.State == ConnectionState.Broken)
            {
                CloseConnection(conn);
            }

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        //-------------------------------------------------------------------
        // TestConnection - Does a test connection of specified server(s);
        //                  use semi-colon delimited server list
        //-------------------------------------------------------------------
        public static bool
           TestConnectionToSingleServer(
              string server,
              bool sqlAuthentication,
              string loginName,
              string password
           )
        {
            return TestConnectionToSingleServer(null, server, sqlAuthentication, loginName, password);
        }

        public static bool
           TestConnectionToSingleServer(
              IWin32Window win,
              string server,
              bool sqlAuthentication,
              string loginName,
              string password
           )
        {
            if (server.Contains(";"))
            {
                Messaging.ShowError(win, "Test Failed: The specified SQL Server contains a semi-colon (;) which is an illegal character in a SQL Server name. The field in which you are entering SQL Servers only supports single SQL Server names.", "Test Connection");
                return false;
            }
            else
            {
                string[] servers = new string[1]; ;
                servers[0] = server;
                return InternalTestConnection(win, servers, sqlAuthentication, loginName, password);
            }
        }

        public static bool
           TestConnection(
              string serverList,
              bool sqlAuthentication,
              string loginName,
              string password
           )
        {
            return TestConnection(null, serverList, sqlAuthentication, loginName, password);
        }


        public static bool
           TestConnection(
              IWin32Window win,
              string serverList,
              bool sqlAuthentication,
              string loginName,
              string password
           )
        {
            string[] servers = serverList.Trim().Split(';');
            for (int i = 0; i < servers.Length; i++) servers[i] = servers[i].Trim();

            return InternalTestConnection(win, servers, sqlAuthentication, loginName, password);
        }

        private static bool
           InternalTestConnection(
              IWin32Window win,
              string[] servers,
              bool sqlAuthentication,
              string loginName,
              string password
           )
        {
            bool success = false;

            string connectionStatus = "";

            bool lastOneFailed = false;
            bool continueAfterFailure = false;
            int testedCount = 0;

            foreach (string server in servers)
            {
                testedCount++;

                if (server.Trim() == "") continue;

                try
                {
                    using (SqlConnection conn = Connection.OpenConnection(server.Trim(),
                                                                            new SQLCredentials(sqlAuthentication,
                                                                                                loginName,
                                                                                                password)))
                    {
                        if (_Impersonation != null)
                        {
                            _Impersonation.Undo();
                            _Impersonation = null;
                        }
                        lastOneFailed = false;
                        connectionStatus = "";
                        conn.Close();
                    }
                }
                catch (SqlException sqlEx)
                {
                    lastOneFailed = true; ;
                    connectionStatus = sqlEx.Message;
                    if (sqlEx.Message.Contains("A connection was successfully established with the server, but then an error occurred during the pre-login handshake."))
                    {
                        connectionStatus += "\n\nIf you are using Sql Server 7, it is not supported by SQL Admin Tool Set.";
                    }
                    else if (sqlEx.Message.Contains("The target principal name is incorrect.  Cannot generate SSPI context."))
                    {
                        connectionStatus = "Unable to connect instance '" + server.Trim() + "'.\n Please try after sometime.";
                    }
                }
                catch (Exception ex)
                {
                    lastOneFailed = true; ;
                    connectionStatus = ex.Message;
                }

                // Message on failure
                if (connectionStatus != "")
                {
                    connectionStatus = Helpers.CreateWrappedString(connectionStatus, 60);

                    string msg = String.Format("Failed to connect to '{0}' using the specified credentials.\r\n\r\n" +
                                                   "Error: {1}",
                                                server,
                                                connectionStatus);

                    if (testedCount == servers.Length)
                    {
                        Messaging.ShowError(win, msg, "Test Connection");
                    }
                    else
                    {
                        DialogResult choice = Messaging.ShowError(win,
                                                                   msg,
                                                                   "Test Connection",
                                                                   "Do you want to continue testing other specified SQL Servers?");
                        if (choice == DialogResult.No)
                        {
                            continueAfterFailure = false;
                            break;
                        }
                        else
                        {
                            Application.DoEvents();  // AllowDrop UI ToolBar redraw before trying next connection
                            continueAfterFailure = true;
                        }
                    }
                }
            }

            if (!lastOneFailed)
            {
                string sMsg = "";
                if (continueAfterFailure)
                    sMsg = "Connection tests to all other specified SQL Servers passed successfully.";
                else
                {
                    if (servers.Length == 1)
                        sMsg = "Connection test passed successfully.";
                    else
                        sMsg = "Connection tests to all specified SQL Servers passed successfully.";
                    success = true;
                }

                Messaging.ShowInformation(sMsg, "Test Connection");
            }

            return success;
        }
    }
}
