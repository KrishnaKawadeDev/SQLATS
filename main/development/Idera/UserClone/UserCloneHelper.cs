using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Idera.SqlAdminToolset.Core;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using Idera.SqlAdminToolset.DatabaseMoverLibrary;
using System.ComponentModel;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.UserClone
{
    internal static class UserCloneHelper
    {
        private static readonly object threadLock = new object();

        /// <summary>
        /// Returns a Server object using the parameters specified by ServerInformation.
        /// </summary>
        /// <param name="server"></param>
        /// <returns></returns>
        public static Server GetServerConnection(ServerInformation server)
        {
            lock (threadLock)
            {
                Server _Server = new Server(new ServerConnection(Connection.OpenConnection(server.Name, server.SqlCredentials)));

                return _Server;
            }
        }

        /// <summary>
        /// Gets the script version that should be generated based on the server's version.
        /// </summary>
        public static ScriptVersion GetScriptVersion(SqlConnection connection)
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            if (SQLHelpers.Is2000(connection))
            {
                return ScriptVersion.Sql2000;
            }
            else if (SQLHelpers.Is2005(connection))
            {
                return ScriptVersion.Sql2005;
            }
            else if (SQLHelpers.Is2008(connection))
            {
                return ScriptVersion.Sql2008;
            }
            else if (SQLHelpers.Is2012(connection))
            {
                return ScriptVersion.Sql2012;
            }
            else if (SQLHelpers.Is2014(connection))
            {
                return ScriptVersion.Sql2014;
            }
            else if (SQLHelpers.Is2016(connection))
            {
                return ScriptVersion.Sql2016;
            }
            else if (SQLHelpers.Is2017(connection))
            {
                return ScriptVersion.Sql2017;
            }
            //else if (SQLHelpers.Is2016orGreater(connection))
            //{
            //    return ScriptVersion.Sql2016;
            //}
            //else if (SQLHelpers.Is2017orGreater(connection))
            //{
            //    return ScriptVersion.Sql2017;
            //}
            else if (SQLHelpers.Is2019orGreater(connection))
            {
                return ScriptVersion.Sql2019;
            }
            else
            {
                return ScriptVersion.NotSupported;
            }
        }

        /// <summary>
        /// Clones a user and returns the SQL script used to clone it.
        /// </summary>
        public static CloneResults CloneUser(ServerInformation sourceServerInfo, ServerInformation destinationServerInfo, string sourceLoginName, CloneOptions options, BackgroundWorker worker)
        {
            lock (threadLock)
            {
                //destinationServerInfo.SqlCredentials = null;
                //sourceServerInfo.SqlCredentials = null;

                CloneResults _Results = new CloneResults();
                try
                {
                    string[] logins = options.UserName.Split(';');
                    for (int i = 0; i < logins.Length; i++)
                    {
                        Server destinationServer = GetServerConnection(destinationServerInfo);
                        destinationServer.ConnectionContext.Connect();
                        options.Version = GetScriptVersion(destinationServer.ConnectionContext.SqlConnectionObject);
                        if (destinationServer.Logins.Contains(logins[i].ToString()))
                        {
                            _Results.UserCloneList.Add(new UserCloneStatus()
                            {
                                userName = logins[i].ToString(),
                                cloneStatus = true
                            });
                        }
                        else
                        {
                            if (options.Version == ScriptVersion.NotSupported)
                            {
                                _Results.CloningException = new NotSupportedException(ProductConstants.ErrorVersionNotSupported);
                                _Results.IsRequestSuccessful = false;
                                return _Results;
                            }
                            worker.ReportProgress((int)CloneProgress.GenerateScript);
                            options.UserName = logins[i].ToString();
                            _Results = GetCloneScript(sourceServerInfo, sourceLoginName, options, worker);
                            if (_Results.Script.Trim().Length > 0 && _Results.IsRequestSuccessful)
                            {
                                //if (destinationServer.Logins.Contains(options.UserName))
                                //{
                                //_Results.CloningException = new InvalidOperationException(ProductConstants.ErrorUserAlreadyExistsAtDestination);
                                //return _Results;


                                //}

                                worker.ReportProgress((int)CloneProgress.ExecutingScript);
                                CloneUser(destinationServer, _Results.Script);
                                _Results.UserCloneList.Add(new UserCloneStatus()
                                {
                                    userName = logins[i].ToString(),
                                    cloneStatus = false
                                });
                                _Results.IsRequestSuccessful = true;

                            }
                        }
                    }
                }
                catch (SqlException exc)
                {
                    if (exc.Number == 911)
                    {
                        _Results.CloningException = new InvalidOperationException(ProductConstants.ErrorDatabaseNotFoundAtDestination + Environment.NewLine + Environment.NewLine, exc);
                    }
                    else
                    {
                        _Results.CloningException = exc;
                    }
                    _Results.IsRequestSuccessful = false;
                }
                finally
                {
                    //     Connection.Impersonate(null);
                }
                return _Results;
            }
        }

        /// <summary>
        /// Clones a user and applies all its settings to the destination.
        /// </summary>
        private static void CloneUser(Server destinationServer, string script)
        {
            using (SqlConnection _Connection = destinationServer.ConnectionContext.SqlConnectionObject)
            {
                if (_Connection.State != System.Data.ConnectionState.Open)
                {
                    _Connection.Open();
                }
                using (SqlCommand _Command = new SqlCommand(script, _Connection))
                {
                    _Command.CommandTimeout = ToolsetOptions.commandTimeout;
                    _Command.ExecuteNonQuery();
                }
                // _Connection.Close();
            }
        }

        public static CloneResults GetCloneScript(ServerInformation serverInfo, string sourceLoginName, CloneOptions options, BackgroundWorker worker)
        {
            SQLVersion _Version;
            Server sourceServer = GetServerConnection(serverInfo);
            CloneResults _Results = new CloneResults();
            if (options.Password != null && options.Password.Trim().Length == 0)
            {
                options.Password = null;
            }

            StringBuilder _Script = new StringBuilder();
            string _DefaultDatabaseScript = string.Empty;
            Utility.TransferVersionInfo _VersionInfo = Utility.TransferVersionInfo.NotSupported;

            using (SqlConnection _Connection = sourceServer.ConnectionContext.SqlConnectionObject)
            {
                if (_Connection.State != System.Data.ConnectionState.Open)
                {
                    _Connection.Open();
                }
                Connection.Impersonate(null);
                worker.ReportProgress((int)CloneProgress.VerifyVersionInformation);
                if (options.Version == ScriptVersion.Sql2019)
                {
                    if (SQLHelpers.Is2008(_Connection))
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2019To2008;
                    }
                    else if (SQLHelpers.Is2005(_Connection)) //2005 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2019To2005;  //no 2008 specific things needed
                    }
                    else if (SQLHelpers.Is2000(_Connection)) //2000 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2000Upgrade;
                    }
                    else if (SQLHelpers.Is2012(_Connection)) //2012 -> 2012
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2019To2012;
                    }
                    else if (SQLHelpers.Is2014(_Connection)) //2014 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2019To2014;
                    }
                    else if (SQLHelpers.Is2016(_Connection)) //2014 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2019To2016;
                    }
                    else if (SQLHelpers.Is2017(_Connection)) //2014 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2019To2017;
                    }
                    else if (SQLHelpers.Is2019(_Connection)) //2014 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2019To2019;
                    }
                    else if (SQLHelpers.Is2019orGreater(_Connection)) //2014 -> 2008
                    {
                        if (options.Password == null)  //can't use the same password for a downgrade.
                        {
                            if (MessageBoxEx.Show(ProductConstants.ConfirmationSql2019BlankPassword, CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                options.Password = string.Empty;
                            }
                            else
                            {
                                _Results.IsRequestSuccessful = false;
                                return _Results;
                            }
                        }
                        _VersionInfo = Utility.TransferVersionInfo.Sql2005To2005;
                    }
                }
                else if (options.Version == ScriptVersion.Sql2017)
                {
                    if (SQLHelpers.Is2008(_Connection))
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2017To2008;
                    }
                    else if (SQLHelpers.Is2005(_Connection)) //2005 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2017To2005;  //no 2008 specific things needed
                    }
                    else if (SQLHelpers.Is2000(_Connection)) //2000 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2000Upgrade;
                    }
                    else if (SQLHelpers.Is2012(_Connection)) //2012 -> 2012
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2017To2012;
                    }
                    else if (SQLHelpers.Is2014(_Connection)) //2014 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2017To2014;
                    }
                    else if (SQLHelpers.Is2016(_Connection)) //2014 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2017To2016;
                    }
                    else if (SQLHelpers.Is2016(_Connection)) //2014 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2017To2017;
                    }
                    else if (SQLHelpers.Is2017orGreater(_Connection)) //2014 -> 2008
                    {
                        if (SQLVersion.TryParse(SQLHelpers.GetSqlVersionString(_Connection), out _Version))
                        {
                            if (options.Password == null)  //can't use the same password for a downgrade.
                            {
                                if (MessageBoxEx.Show(ProductConstants.ConfirmationSqlVersionBlankPassword(_Version.Name), CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    options.Password = string.Empty;
                                }
                                else
                                {
                                    _Results.IsRequestSuccessful = false;
                                    return _Results;
                                }
                            }
                        }
                        _VersionInfo = Utility.TransferVersionInfo.Sql2005To2005;
                    }
                }
                else if (options.Version == ScriptVersion.Sql2016)
                {
                    if (SQLHelpers.Is2008(_Connection))
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2016To2008;
                    }
                    else if (SQLHelpers.Is2005(_Connection)) //2005 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2016To2005;  //no 2008 specific things needed
                    }
                    else if (SQLHelpers.Is2000(_Connection)) //2000 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2000Upgrade;
                    }
                    else if (SQLHelpers.Is2012(_Connection)) //2012 -> 2012
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2016To2012;
                    }
                    else if (SQLHelpers.Is2014(_Connection)) //2014 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2016To2014;
                    }
                    else if (SQLHelpers.Is2016(_Connection)) //2014 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2016To2016;
                    }
                    else if (SQLHelpers.Is2016orGreater(_Connection)) //2014 -> 2008
                    {
                        if (SQLVersion.TryParse(SQLHelpers.GetSqlVersionString(_Connection), out _Version))
                        {
                            if (options.Password == null)  //can't use the same password for a downgrade.
                            {
                                if (MessageBoxEx.Show(ProductConstants.ConfirmationSqlVersionBlankPassword(_Version.Name), CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    options.Password = string.Empty;
                                }
                                else
                                {
                                    _Results.IsRequestSuccessful = false;
                                    return _Results;
                                }
                            }
                        }
                        _VersionInfo = Utility.TransferVersionInfo.Sql2005To2005;
                    }
                }

                else if (options.Version == ScriptVersion.Sql2014)
                {
                    if (SQLHelpers.Is2008(_Connection))
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2014To2008;
                    }
                    else if (SQLHelpers.Is2005(_Connection)) //2005 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2014To2005;  //no 2008 specific things needed
                    }
                    else if (SQLHelpers.Is2000(_Connection)) //2000 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2000Upgrade;
                    }
                    else if (SQLHelpers.Is2012(_Connection)) //2012 -> 2012
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2014To2012;
                    }
                    else if (SQLHelpers.Is2014(_Connection)) //2014 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2014To2014;
                    }
                    else if (SQLHelpers.Is2016orGreater(_Connection)) //2014 -> 2008
                    {
                        if (SQLVersion.TryParse(SQLHelpers.GetSqlVersionString(_Connection), out _Version))
                        {
                            if (options.Password == null)  //can't use the same password for a downgrade.
                            {
                                if (MessageBoxEx.Show(ProductConstants.ConfirmationSqlVersionBlankPassword(_Version.Name), CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    options.Password = string.Empty;
                                }
                                else
                                {
                                    _Results.IsRequestSuccessful = false;
                                    return _Results;
                                }
                            }
                        }
                        _VersionInfo = Utility.TransferVersionInfo.Sql2005To2005;
                    }
                    else if (SQLHelpers.Is2017orGreater(_Connection)) //2014 -> 2008
                    {
                        if (options.Password == null)  //can't use the same password for a downgrade.
                        {
                            if (MessageBoxEx.Show(ProductConstants.ConfirmationSql2016BlankPassword, CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                options.Password = string.Empty;
                            }
                            else
                            {
                                _Results.IsRequestSuccessful = false;
                                return _Results;
                            }
                        }
                        _VersionInfo = Utility.TransferVersionInfo.Sql2005To2005;
                    }
                }

                else if (options.Version == ScriptVersion.Sql2012)
                {
                    if (SQLHelpers.Is2008(_Connection))
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2012To2008;
                    }
                    else if (SQLHelpers.Is2005(_Connection)) //2005 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2012To2005;  //no 2008 specific things needed
                    }
                    else if (SQLHelpers.Is2000(_Connection)) //2000 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2000Upgrade;
                    }
                    else if (SQLHelpers.Is2012(_Connection)) //2012 -> 2012
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2012To2012;
                    }
                    else if (SQLHelpers.Is2014(_Connection)) //2014 -> 2008
                    {
                        if (options.Password == null)  //can't use the same password for a downgrade.
                        {
                            if (MessageBoxEx.Show(ProductConstants.ConfirmationSql2014BlankPassword, CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                options.Password = string.Empty;
                            }
                            else
                            {
                                _Results.IsRequestSuccessful = false;
                                return _Results;
                            }
                        }

                        _VersionInfo = Utility.TransferVersionInfo.Sql2005To2005;
                    }
                    else if (SQLHelpers.Is2016orGreater(_Connection)) //2014 -> 2008
                    {
                        if (SQLVersion.TryParse(SQLHelpers.GetSqlVersionString(_Connection), out _Version))
                        {
                            if (options.Password == null)  //can't use the same password for a downgrade.
                            {
                                if (MessageBoxEx.Show(ProductConstants.ConfirmationSqlVersionBlankPassword(_Version.Name), CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    options.Password = string.Empty;
                                }
                                else
                                {
                                    _Results.IsRequestSuccessful = false;
                                    return _Results;
                                }
                            }
                        }
                        _VersionInfo = Utility.TransferVersionInfo.Sql2005To2005;
                    }

                    else if (SQLHelpers.Is2017orGreater(_Connection)) //2014 -> 2008
                    {
                        if (SQLVersion.TryParse(SQLHelpers.GetSqlVersionString(_Connection), out _Version))
                        {
                            if (options.Password == null)  //can't use the same password for a downgrade.
                            {
                                if (MessageBoxEx.Show(ProductConstants.ConfirmationSqlVersionBlankPassword(_Version.Name), CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    options.Password = string.Empty;
                                }
                                else
                                {
                                    _Results.IsRequestSuccessful = false;
                                    return _Results;
                                }
                            }
                        }
                        _VersionInfo = Utility.TransferVersionInfo.Sql2005To2005;
                    }
                }

                else if (options.Version == ScriptVersion.Sql2008)
                {
                    if (SQLHelpers.Is2008(_Connection))
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2008To2008;
                    }
                    else if (SQLHelpers.Is2005(_Connection)) //2005 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2005To2005;  //no 2008 specific things needed
                    }
                    else if (SQLHelpers.Is2000(_Connection)) //2000 -> 2008
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2000Upgrade;
                    }
                    else if (SQLHelpers.Is2012(_Connection)) //2012 -> 2008
                    {
                        if (options.Password == null)  //can't use the same password for a downgrade.
                        {
                            if (MessageBoxEx.Show(ProductConstants.ConfirmationSql2012BlankPassword, CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                options.Password = string.Empty;
                            }
                            else
                            {
                                _Results.IsRequestSuccessful = false;
                                return _Results;
                            }
                        }
                        _VersionInfo = Utility.TransferVersionInfo.Sql2012To2008;
                    }
                    else if (SQLHelpers.Is2014(_Connection)) //2014 -> 2008
                    {
                        if (options.Password == null)  //can't use the same password for a downgrade.
                        {
                            if (MessageBoxEx.Show(ProductConstants.ConfirmationSql2014BlankPassword, CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                options.Password = string.Empty;
                            }
                            else
                            {
                                _Results.IsRequestSuccessful = false;
                                return _Results;
                            }
                        }
                        _VersionInfo = Utility.TransferVersionInfo.Sql2014To2008;
                    }
                    else if (SQLHelpers.Is2016orGreater(_Connection)) //2014 -> 2008
                    {
                        if (SQLVersion.TryParse(SQLHelpers.GetSqlVersionString(_Connection), out _Version))
                        {
                            if (options.Password == null)  //can't use the same password for a downgrade.
                            {
                                if (MessageBoxEx.Show(ProductConstants.ConfirmationSqlVersionBlankPassword(_Version.Name), CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    options.Password = string.Empty;
                                }
                                else
                                {
                                    _Results.IsRequestSuccessful = false;
                                    return _Results;
                                }
                            }
                        }
                        _VersionInfo = Utility.TransferVersionInfo.Sql2014To2008;
                    }
                    else if (SQLHelpers.Is2017orGreater(_Connection)) //2014 -> 2008
                    {
                        if (options.Password == null)  //can't use the same password for a downgrade.
                        {
                            if (MessageBoxEx.Show(ProductConstants.ConfirmationSql2017BlankPassword, CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                options.Password = string.Empty;
                            }
                            else
                            {
                                _Results.IsRequestSuccessful = false;
                                return _Results;
                            }
                        }
                        _VersionInfo = Utility.TransferVersionInfo.Sql2014To2008;
                    }
                }
                else if (options.Version == ScriptVersion.Sql2005)
                {
                    if (SQLHelpers.Is2008(_Connection)) //2008 -> 2005
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2008To2005;
                    }
                    else if (SQLHelpers.Is2005(_Connection)) //2005 -> 2005
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2005To2005;
                    }
                    else if (SQLHelpers.Is2000(_Connection)) //2000 -> 2005
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2000Upgrade;
                    }
                    else if (SQLHelpers.Is2012(_Connection)) //2012 -> 2005
                    {
                        if (options.Password == null)  //can't use the same password for a downgrade.
                        {
                            if (MessageBoxEx.Show(ProductConstants.ConfirmationSql2012BlankPassword, CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                options.Password = string.Empty;
                            }
                            else
                            {
                                _Results.IsRequestSuccessful = false;
                                return _Results;
                            }
                        }
                        _VersionInfo = Utility.TransferVersionInfo.Sql2005To2005;
                    }
                    else if (SQLHelpers.Is2014(_Connection)) //2014 -> 2005
                    {
                        if (options.Password == null)  //can't use the same password for a downgrade.
                        {
                            if (MessageBoxEx.Show(ProductConstants.ConfirmationSql2014BlankPassword, CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                options.Password = string.Empty;
                            }
                            else
                            {
                                _Results.IsRequestSuccessful = false;
                                return _Results;
                            }
                        }
                        _VersionInfo = Utility.TransferVersionInfo.Sql2005To2005;
                    }
                    else if (SQLHelpers.Is2016orGreater(_Connection)) //2016 -> 2005
                    {
                        if (SQLVersion.TryParse(SQLHelpers.GetSqlVersionString(_Connection), out _Version))
                        {
                            if (options.Password == null)  //can't use the same password for a downgrade.
                            {
                                if (MessageBoxEx.Show(ProductConstants.ConfirmationSqlVersionBlankPassword(_Version.Name), CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    options.Password = string.Empty;
                                }
                                else
                                {
                                    _Results.IsRequestSuccessful = false;
                                    return _Results;
                                }
                            }
                        }
                        _VersionInfo = Utility.TransferVersionInfo.Sql2005To2005;
                    }
                    else if (SQLHelpers.Is2017orGreater(_Connection)) //2016 -> 2005
                    {
                        if (options.Password == null)  //can't use the same password for a downgrade.
                        {
                            if (MessageBoxEx.Show(ProductConstants.ConfirmationSql2017BlankPassword, CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                options.Password = string.Empty;
                            }
                            else
                            {
                                _Results.IsRequestSuccessful = false;
                                return _Results;
                            }
                        }
                        _VersionInfo = Utility.TransferVersionInfo.Sql2005To2005;
                    }
                }

                else
                {
                    if (SQLHelpers.Is2000(_Connection)) //2000 -> 2000
                    {
                        _VersionInfo = Utility.TransferVersionInfo.Sql2000To2000;
                    }
                    else if (SQLHelpers.Is2005orGreater(_Connection))  //2005 -> 2000...overwrite password to blank
                    {
                        if (options.Password == null)  //can't use the same password for a downgrade.
                        {
                            if (MessageBoxEx.Show(ProductConstants.ConfirmationSql2000BlankPassword, CoreGlobals.productName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                options.Password = string.Empty;
                            }
                            else
                            {
                                _Results.IsRequestSuccessful = false;
                                return _Results;
                            }
                        }
                        _VersionInfo = Utility.TransferVersionInfo.Sql2005To2000;
                    }
                }

                if (_VersionInfo == Utility.TransferVersionInfo.NotSupported)
                {
                    _Results.CloningException = new NotSupportedException(ProductConstants.ErrorVersionCombinationNotSupported);
                    _Results.IsRequestSuccessful = false;
                    return _Results;
                }
                else
                {
                    worker.ReportProgress((int)CloneProgress.LoginScript);
                    _Script.Append(GetLoginScript(sourceServer, sourceLoginName, options.UserName, options.Password, _VersionInfo));

                    if (!string.IsNullOrEmpty(options.DefaultDatabase))
                    {
                        worker.ReportProgress((int)CloneProgress.DefaultDatabase);
                        _Script.Append(Environment.NewLine);
                        _Script.Append(GetDefaultDatabaseScript(options.DefaultDatabase, options.UserName, _VersionInfo));
                        _Script.Append(Environment.NewLine);
                    }

                    if (_VersionInfo == Utility.TransferVersionInfo.Sql2005To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2008To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2008To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2012To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2016 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2017 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2019 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2012To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2012To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2012 ||
                         _VersionInfo == Utility.TransferVersionInfo.Sql2017To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2012 ||
                         _VersionInfo == Utility.TransferVersionInfo.Sql2017To2016||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2016 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2017)
                    {
                        _Script.Append(Environment.NewLine);

                        _Script.AppendFormat("USE [master]");
                        _Script.Append(Environment.NewLine);
                        foreach (ServerPermissionInfo _ServerLevelPermission in sourceServer.EnumServerPermissions(sourceLoginName))
                        {
                            _Script.Append(GetObjectPermissionScript(_ServerLevelPermission, options.UserName));
                            _Script.Append(Environment.NewLine);
                        }

                        foreach (ObjectPermissionInfo _ServerLevelPermission in sourceServer.EnumObjectPermissions(sourceLoginName))
                        {

                            _Script.Append(GetObjectPermissionScript(_ServerLevelPermission, options.UserName));
                            _Script.Append(Environment.NewLine);
                        }
                    }

                    if (options.ApplyDatabasePermissions)
                    {
                        worker.ReportProgress((int)CloneProgress.DatabasePermissions);

                        _Script.Append(Environment.NewLine);
                        foreach (Database _Database in sourceServer.Databases)
                        {
                            if (!options.Databases.Contains(_Database.Name))
                            {
                                continue;
                            }

                            if (_Database.CompatibilityLevel < CompatibilityLevel.Version70)
                            {
                                _Results.InaccessibleDatabases.Add(_Database.Name, ProductConstants.CaptionDatabaseCompatibilityNotSupported + ((int)_Database.CompatibilityLevel).ToString());
                                continue;
                            }

                            if (!_Database.IsAccessible)
                            {
                                _Results.InaccessibleDatabases.Add(_Database.Name, ProductConstants.CaptionDatabaseInaccessible);
                                continue;
                            }

                            if (_Database.IsAccessible)
                            {
                                foreach (User _User in _Database.Users)
                                {
                                    if (_User.Login == sourceLoginName)
                                    {
                                        if (SQLHelpers.Is2005orGreater(_Connection))
                                        {
                                            _User.DefaultSchema = GetDefaultSchema(_Database, _User.Name, _Connection);
                                        }

                                        string _DatabaseUserName = options.UserName;
                                        if (_User.Login == _DatabaseUserName) //if the destination login is the same as origin, then dont change the database user name
                                        {
                                            _DatabaseUserName = _User.Name;
                                        }

                                        _Script.Append(Environment.NewLine);
                                        _Script.AppendFormat("USE [{0}]", _Database.Name);
                                        _Script.Append(Environment.NewLine);

                                        string _UserDefaultSchema = string.Empty;
                                        if (_VersionInfo == Utility.TransferVersionInfo.Sql2005To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2008To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2008To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2012To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2016 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2017 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2019 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2012To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2012To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2016 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2016 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2017 )
                                        {
                                            _UserDefaultSchema = _User.DefaultSchema;
                                        }

                                        _Script.Append(Utility.GetDatabaseAccessScript(options.UserName, _DatabaseUserName, _VersionInfo, _UserDefaultSchema));
                                        _Script.Append(Environment.NewLine);

                                        foreach (DatabasePermissionInfo _DatabaseLevelPermission in _Database.EnumDatabasePermissions(sourceLoginName))
                                        {

                                            _Script.Append(GetObjectPermissionScript(_DatabaseLevelPermission, options.UserName));
                                            _Script.Append(Environment.NewLine);
                                        }

                                        foreach (string _RoleName in _User.EnumRoles())
                                        {
                                            if (_RoleName != "public")
                                            {
                                                if (!_Database.Roles[_RoleName].IsFixedRole)
                                                {
                                                    _Script.Append(Environment.NewLine);
                                                    DatabaseRole _Role = _Database.Roles[_RoleName];
                                                    _Script.Append(GetCreateRoleScript(_RoleName, _Role.Owner, _VersionInfo));
                                                    _Script.Append(Environment.NewLine);

                                                    if (_VersionInfo == Utility.TransferVersionInfo.Sql2005To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2008To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2008To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2012To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2016 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2017 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2019 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2012To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2012To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2016 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2016 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2017)
                                                    {
                                                        foreach (ObjectPermissionInfo _ObjectPermission in _Database.EnumObjectPermissions(_RoleName))
                                                        {
                                                            if (_VersionInfo == Utility.TransferVersionInfo.Sql2008To2005 && _ObjectPermission.PermissionType.ToString() == "VIEW CHANGE TRACKING")
                                                            {
                                                                continue;
                                                            }
                                                            _Script.Append(GetObjectPermissionScript(_ObjectPermission));
                                                            _Script.Append(Environment.NewLine);
                                                        }

                                                        if (options.IncludeSchemaOwnership)
                                                        {
                                                            _Script.Append(Environment.NewLine);
                                                            _Script.Append(GetSchemaOwnershipScript(_Database.Schemas, _RoleName, _RoleName));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        _Script.Append(GetObjectPermissionScript2000(_Database.Name, _RoleName, _RoleName, _Connection, (_VersionInfo == Utility.TransferVersionInfo.Sql2000To2000 || _VersionInfo == Utility.TransferVersionInfo.Sql2005To2000)) + Environment.NewLine);
                                                    }
                                                    _Script.Append("END");
                                                    _Script.Append(Environment.NewLine);
                                                }
                                                _Script.Append(Environment.NewLine);
                                                _Script.Append(GetAddRoleMemberScript(_RoleName, _DatabaseUserName, _VersionInfo));
                                                _Script.Append(Environment.NewLine);
                                            }
                                        }
                                        _Script.Append(Environment.NewLine);

                                        if (options.ApplyObjectLevelPermissions)
                                        {
                                            if (_VersionInfo == Utility.TransferVersionInfo.Sql2005To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2008To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2008To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2012To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2016 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2017 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2019 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2012To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2012To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2016 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2016 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2017)
                                            {
                                                _Script.Append(Environment.NewLine);
                                                foreach (ObjectPermissionInfo _ObjectPermission in _Database.EnumObjectPermissions(_User.Name))
                                                {
                                                    if (_VersionInfo == Utility.TransferVersionInfo.Sql2008To2005 && _ObjectPermission.PermissionType.ToString() == "VIEW CHANGE TRACKING")
                                                    {
                                                        continue;
                                                    }
                                                    _Script.Append(GetObjectPermissionScript(_ObjectPermission, _DatabaseUserName));
                                                    _Script.Append(Environment.NewLine);
                                                }
                                            }
                                            else
                                            {
                                                _Script.Append(GetObjectPermissionScript2000(_Database.Name, _User.Name, _DatabaseUserName, _Connection, (_VersionInfo == Utility.TransferVersionInfo.Sql2000To2000 || _VersionInfo == Utility.TransferVersionInfo.Sql2005To2000)) + Environment.NewLine);
                                            }
                                        }

                                        if ((_VersionInfo == Utility.TransferVersionInfo.Sql2005To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2008To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2008To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2012To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2016 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2017 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2019 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2012To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2012To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2014To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2016To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2017To2016 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2005 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2008 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2014 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2012 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2016 ||
                        _VersionInfo == Utility.TransferVersionInfo.Sql2019To2017) &&
                                                     options.IncludeSchemaOwnership)
                                        {
                                            _Script.Append(Environment.NewLine);
                                            _Script.Append(GetSchemaOwnershipScript(_Database.Schemas, _User.Name, _DatabaseUserName));
                                        }
                                    }
                                }
                            }
                        }
                    }

                    worker.ReportProgress((int)CloneProgress.EnableLogin);

                    _Script.Append(Environment.NewLine);
                    _Script.Append(GetEnableLoginScript(options.UserName, options.EnableLogin, _VersionInfo));
                    _Script.Append(Environment.NewLine);
                    _Script.Append("END");
                }
                _Connection.Close();
            }
            _Results.Script = _Script.ToString();
            CloneResults._listScript.Add(_Results.Script);
            return _Results;
        }

        private static string
           GetDefaultSchema(
              Database database,
              string user,
              SqlConnection connection
           )
        {
            string schemaName = null;

            try
            {
                string sql = string.Format("use {0}; exec sp_helpuser {1}",
                                           SQLHelpers.CreateSafeDatabaseName(database.Name),
                                           SQLHelpers.CreateSafeString(user));

                using (SqlCommand _Command = new SqlCommand(sql, connection))
                using (SqlDataReader _Reader = _Command.ExecuteReader())
                {
                    if (_Reader.Read())
                    {
                        schemaName = SQLHelpers.GetString(_Reader, 4);
                    }
                }
            }
            catch
            {
            }

            if (String.IsNullOrEmpty(schemaName)) schemaName = "dbo";

            return schemaName;
        }

        /// <summary>
        /// Returns a script used to create the specified login on the correct SQL Server version.
        /// </summary>
        private static string GetLoginScript(Server sourceServer, string sourceLogin, string destinationLogin, string password, Utility.TransferVersionInfo versionInfo)
        {
            string _Script = string.Empty;
            switch (versionInfo)
            {
                //same versions.
                case Utility.TransferVersionInfo.Sql2005To2005:
                case Utility.TransferVersionInfo.Sql2008To2008:
                case Utility.TransferVersionInfo.Sql2012To2012:
                case Utility.TransferVersionInfo.Sql2014To2014:
                case Utility.TransferVersionInfo.Sql2016To2016:
                case Utility.TransferVersionInfo.Sql2017To2017:
                case Utility.TransferVersionInfo.Sql2019To2019:
                //2008-2005.
                case Utility.TransferVersionInfo.Sql2008To2005:
                //2012-2005,2012-2008.
                case Utility.TransferVersionInfo.Sql2012To2005:
                case Utility.TransferVersionInfo.Sql2012To2008:
                //2014-2005,2014-2008,2014-2012.
                case Utility.TransferVersionInfo.Sql2014To2005:
                case Utility.TransferVersionInfo.Sql2014To2008:
                case Utility.TransferVersionInfo.Sql2014To2012:
                //2016-2005,2016-2008,2016-2012,2016-2014.
                case Utility.TransferVersionInfo.Sql2016To2005:
                case Utility.TransferVersionInfo.Sql2016To2008:
                case Utility.TransferVersionInfo.Sql2016To2014:
                case Utility.TransferVersionInfo.Sql2016To2012:
                //2017-2016,2017-2014,2017-2012,2017-2008,2017-2005.
                case Utility.TransferVersionInfo.Sql2017To2005:
                case Utility.TransferVersionInfo.Sql2017To2008:
                case Utility.TransferVersionInfo.Sql2017To2014:
                case Utility.TransferVersionInfo.Sql2017To2012:
                case Utility.TransferVersionInfo.Sql2017To2016:

                case Utility.TransferVersionInfo.Sql2019To2005:
                case Utility.TransferVersionInfo.Sql2019To2008:
                case Utility.TransferVersionInfo.Sql2019To2014:
                case Utility.TransferVersionInfo.Sql2019To2012:
                case Utility.TransferVersionInfo.Sql2019To2016:
                case Utility.TransferVersionInfo.Sql2019To2017:

                    _Script = string.Format("IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N{0})", SQLHelpers.CreateSafeString(destinationLogin));
                    _Script += Environment.NewLine + "BEGIN" + Environment.NewLine;
                    _Script += Utility.GetLoginScriptForUser2005(sourceServer, sourceLogin, destinationLogin, password);
                    break;
                case Utility.TransferVersionInfo.Sql2000Upgrade:
                    _Script = string.Format("IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N{0})", SQLHelpers.CreateSafeString(destinationLogin));
                    _Script += Environment.NewLine + "BEGIN" + Environment.NewLine;
                    _Script += Utility.GetLoginScriptForUser2005Upgrade(sourceServer, sourceLogin, destinationLogin, password);
                    break;
                case Utility.TransferVersionInfo.Sql2000To2000:
                    _Script = string.Format("IF NOT EXISTS (SELECT * FROM master..syslogins WHERE name = N{0})", SQLHelpers.CreateSafeString(destinationLogin));
                    _Script += Environment.NewLine + "BEGIN" + Environment.NewLine;
                    _Script += Utility.GetLoginScriptForUser2000(sourceServer, sourceLogin, destinationLogin, password);
                    break;
                case Utility.TransferVersionInfo.Sql2005To2000:
                    _Script = string.Format("IF NOT EXISTS (SELECT * FROM master..syslogins WHERE name = N{0})", SQLHelpers.CreateSafeString(destinationLogin));
                    _Script += Environment.NewLine + "BEGIN" + Environment.NewLine;
                    _Script += Utility.GetLoginScriptFor2000Downgrade(sourceServer, sourceLogin, destinationLogin, password);
                    break;
            }
            return _Script;
        }

        /// <summary>
        /// Returns a script to set the default database for a SQL Server login.
        /// </summary>
        private static string GetDefaultDatabaseScript(string database, string login, Utility.TransferVersionInfo versionInfo)
        {
            string _Script = GetIfDatabaseExistsScript(database, versionInfo) + Environment.NewLine;
            switch (versionInfo)
            {
                case Utility.TransferVersionInfo.Sql2008To2005:
                case Utility.TransferVersionInfo.Sql2008To2008:
                case Utility.TransferVersionInfo.Sql2005To2005:
                case Utility.TransferVersionInfo.Sql2012To2012:
                case Utility.TransferVersionInfo.Sql2014To2014:
                case Utility.TransferVersionInfo.Sql2016To2016:
                case Utility.TransferVersionInfo.Sql2017To2017:
                case Utility.TransferVersionInfo.Sql2019To2019:
                //2012-2005,2012-2008.
                case Utility.TransferVersionInfo.Sql2012To2005:
                case Utility.TransferVersionInfo.Sql2012To2008:
                //2014-2005,2014-2008,2014-2012.
                case Utility.TransferVersionInfo.Sql2014To2005:
                case Utility.TransferVersionInfo.Sql2014To2008:
                case Utility.TransferVersionInfo.Sql2014To2012:
                //2016-2005,2016-2008,2016-2012,2016-2014.
                case Utility.TransferVersionInfo.Sql2016To2005:
                case Utility.TransferVersionInfo.Sql2016To2008:
                case Utility.TransferVersionInfo.Sql2016To2014:
                case Utility.TransferVersionInfo.Sql2016To2012:
                //2017-2005,2017-2008,2017-2012,2017-2014,2016-2016.
                case Utility.TransferVersionInfo.Sql2017To2005:
                case Utility.TransferVersionInfo.Sql2017To2008:
                case Utility.TransferVersionInfo.Sql2017To2014:
                case Utility.TransferVersionInfo.Sql2017To2012:
                case Utility.TransferVersionInfo.Sql2017To2016:
                
                case Utility.TransferVersionInfo.Sql2019To2005:
                case Utility.TransferVersionInfo.Sql2019To2008:
                case Utility.TransferVersionInfo.Sql2019To2014:
                case Utility.TransferVersionInfo.Sql2019To2012:
                case Utility.TransferVersionInfo.Sql2019To2016:
                case Utility.TransferVersionInfo.Sql2019To2017:

                case Utility.TransferVersionInfo.Sql2000Upgrade:
                    _Script += Utility.GetScriptDefaultDatabase2005(database, login);
                    break;
                case Utility.TransferVersionInfo.Sql2000To2000:
                case Utility.TransferVersionInfo.Sql2005To2000:
                    _Script += Utility.GetScriptDefaultDatabase2000(database, login);
                    break;
            }
            return _Script;
        }

        private static string GetIfDatabaseExistsScript(string database, Utility.TransferVersionInfo versionInfo)
        {
            string _Script = string.Empty;
            switch (versionInfo)
            {
                case Utility.TransferVersionInfo.Sql2008To2005:
                case Utility.TransferVersionInfo.Sql2008To2008:
                case Utility.TransferVersionInfo.Sql2005To2005:
                case Utility.TransferVersionInfo.Sql2012To2012:
                case Utility.TransferVersionInfo.Sql2014To2014:
                case Utility.TransferVersionInfo.Sql2016To2016:
                case Utility.TransferVersionInfo.Sql2017To2017:
                case Utility.TransferVersionInfo.Sql2019To2019:
                //2012-2005,2012-2008.
                case Utility.TransferVersionInfo.Sql2012To2005:
                case Utility.TransferVersionInfo.Sql2012To2008:
                //2014-2005,2014-2008,2014-2012.
                case Utility.TransferVersionInfo.Sql2014To2005:
                case Utility.TransferVersionInfo.Sql2014To2008:
                case Utility.TransferVersionInfo.Sql2014To2012:
                //2016-2005,2016-2008,2016-2012,2016-2014.
                case Utility.TransferVersionInfo.Sql2016To2005:
                case Utility.TransferVersionInfo.Sql2016To2008:
                case Utility.TransferVersionInfo.Sql2016To2014:
                case Utility.TransferVersionInfo.Sql2016To2012:

                //2017-2005,2017-2008,2017-2012,2017-2014,2016-2016.
                case Utility.TransferVersionInfo.Sql2017To2005:
                case Utility.TransferVersionInfo.Sql2017To2008:
                case Utility.TransferVersionInfo.Sql2017To2014:
                case Utility.TransferVersionInfo.Sql2017To2012:
                case Utility.TransferVersionInfo.Sql2017To2016:

                case Utility.TransferVersionInfo.Sql2019To2005:
                case Utility.TransferVersionInfo.Sql2019To2008:
                case Utility.TransferVersionInfo.Sql2019To2014:
                case Utility.TransferVersionInfo.Sql2019To2012:
                case Utility.TransferVersionInfo.Sql2019To2016:
                case Utility.TransferVersionInfo.Sql2019To2017:

                case Utility.TransferVersionInfo.Sql2000Upgrade:
                    _Script = string.Format("IF EXISTS(SELECT * FROM sys.databases where name = N'{0}')", database);
                    break;
                case Utility.TransferVersionInfo.Sql2000To2000:
                case Utility.TransferVersionInfo.Sql2005To2000:
                    _Script = string.Format("IF EXISTS(SELECT * FROM master..sysdatabases where name = N'{0}')", database);
                    break;
            }
            return _Script;
        }

        /// <summary>
        /// Returns a script used to create a database role.
        /// </summary>
        private static string GetCreateRoleScript(string roleName, string roleOwner, Utility.TransferVersionInfo versionInfo)
        {
            string _Script = string.Empty;
            switch (versionInfo)
            {
                case Utility.TransferVersionInfo.Sql2008To2005:
                case Utility.TransferVersionInfo.Sql2008To2008:
                case Utility.TransferVersionInfo.Sql2005To2005:
                case Utility.TransferVersionInfo.Sql2012To2012:
                case Utility.TransferVersionInfo.Sql2014To2014:
                case Utility.TransferVersionInfo.Sql2016To2016:
                case Utility.TransferVersionInfo.Sql2017To2017:
                case Utility.TransferVersionInfo.Sql2019To2019:

                //2012-2005,2012-2008.
                case Utility.TransferVersionInfo.Sql2012To2005:
                case Utility.TransferVersionInfo.Sql2012To2008:
                //2014-2005,2014-2008,2014-2012.
                case Utility.TransferVersionInfo.Sql2014To2005:
                case Utility.TransferVersionInfo.Sql2014To2008:
                case Utility.TransferVersionInfo.Sql2014To2012:
                //2016-2005,2016-2008,2016-2012,2016-2014.
                case Utility.TransferVersionInfo.Sql2016To2005:
                case Utility.TransferVersionInfo.Sql2016To2008:
                case Utility.TransferVersionInfo.Sql2016To2014:
                case Utility.TransferVersionInfo.Sql2016To2012:
                //2017-2005,2017-2008,2017-2012,2017-2014,2016-2016.
                case Utility.TransferVersionInfo.Sql2017To2005:
                case Utility.TransferVersionInfo.Sql2017To2008:
                case Utility.TransferVersionInfo.Sql2017To2014:
                case Utility.TransferVersionInfo.Sql2017To2012:
                case Utility.TransferVersionInfo.Sql2017To2016:

                case Utility.TransferVersionInfo.Sql2019To2005:
                case Utility.TransferVersionInfo.Sql2019To2008:
                case Utility.TransferVersionInfo.Sql2019To2014:
                case Utility.TransferVersionInfo.Sql2019To2012:
                case Utility.TransferVersionInfo.Sql2019To2016:
                case Utility.TransferVersionInfo.Sql2019To2017:

                case Utility.TransferVersionInfo.Sql2000Upgrade:
                    _Script += string.Format("IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'{0}' AND type = 'R')", roleName) + Environment.NewLine;
                    _Script += string.Format("BEGIN") + Environment.NewLine;
                    _Script += string.Format("CREATE ROLE [{0}] AUTHORIZATION [{1}]", roleName, roleOwner);
                    break;
                case Utility.TransferVersionInfo.Sql2000To2000:
                case Utility.TransferVersionInfo.Sql2005To2000:
                    _Script += string.Format("IF NOT EXISTS (SELECT * FROM sysusers WHERE name = N'{0}' AND issqlrole = 1)", roleName) + Environment.NewLine;
                    _Script += string.Format("BEGIN") + Environment.NewLine;
                    _Script += string.Format("EXEC dbo.sp_addrole @rolename = N'{0}', @ownername = N'{1}'", roleName, roleOwner);
                    break;
            }
            return _Script;
        }

        /// <summary>
        /// Returns a script used to add a user to a database role.
        /// </summary>
        private static string GetAddRoleMemberScript(string roleName, string userName, Utility.TransferVersionInfo versionInfo)
        {
            string _Script = string.Empty;
            switch (versionInfo)
            {
                case Utility.TransferVersionInfo.Sql2008To2005:
                case Utility.TransferVersionInfo.Sql2008To2008:
                case Utility.TransferVersionInfo.Sql2005To2005:
                case Utility.TransferVersionInfo.Sql2012To2012:
                case Utility.TransferVersionInfo.Sql2014To2014:
                case Utility.TransferVersionInfo.Sql2016To2016:
                case Utility.TransferVersionInfo.Sql2017To2017:
                case Utility.TransferVersionInfo.Sql2019To2019:
                //2012-2005,2012-2008.
                case Utility.TransferVersionInfo.Sql2012To2005:
                case Utility.TransferVersionInfo.Sql2012To2008:
                //2014-2005,2014-2008,2014-2012.
                case Utility.TransferVersionInfo.Sql2014To2005:
                case Utility.TransferVersionInfo.Sql2014To2008:
                case Utility.TransferVersionInfo.Sql2014To2012:
                //2016-2005,2016-2008,2016-2012,2016-2014.
                case Utility.TransferVersionInfo.Sql2016To2005:
                case Utility.TransferVersionInfo.Sql2016To2008:
                case Utility.TransferVersionInfo.Sql2016To2014:
                case Utility.TransferVersionInfo.Sql2016To2012:

                //2017-2005,2017-2008,2017-2012,2017-2014,2016-2016.
                case Utility.TransferVersionInfo.Sql2017To2005:
                case Utility.TransferVersionInfo.Sql2017To2008:
                case Utility.TransferVersionInfo.Sql2017To2014:
                case Utility.TransferVersionInfo.Sql2017To2012:
                case Utility.TransferVersionInfo.Sql2017To2016:

                case Utility.TransferVersionInfo.Sql2019To2005:
                case Utility.TransferVersionInfo.Sql2019To2008:
                case Utility.TransferVersionInfo.Sql2019To2014:
                case Utility.TransferVersionInfo.Sql2019To2012:
                case Utility.TransferVersionInfo.Sql2019To2016:
                case Utility.TransferVersionInfo.Sql2019To2017:

                case Utility.TransferVersionInfo.Sql2000Upgrade:
                    _Script += string.Format("IF EXISTS (SELECT * FROM sys.database_principals WHERE name = N'{0}' AND type = 'R')", roleName) + Environment.NewLine;
                    break;
                case Utility.TransferVersionInfo.Sql2000To2000:
                case Utility.TransferVersionInfo.Sql2005To2000:
                    _Script += string.Format("IF EXISTS (SELECT * FROM sysusers WHERE name = N'{0}' AND issqlrole = 1)", roleName) + Environment.NewLine;
                    break;
            }

            _Script += string.Format("EXEC sp_addrolemember N'{0}', N'{1}'", roleName, userName);
            return _Script;
        }

        /// <summary>
        /// Returns a script to grant/deny permissions on database objects to a user or role.
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        private static string GetObjectPermissionScript(ObjectPermissionInfo permission)
        {
            return GetObjectPermissionScript(permission, permission.Grantee);
        }

        /// <summary>
        /// Returns a script to grant/deny permissions on server or database objects.
        /// </summary>
        private static string GetObjectPermissionScript(PermissionInfo permission, string grantee)
        {
            string _Script = string.Empty;
            string _State = string.Empty;
            string _EndOption = string.Empty;

            if (permission.PermissionState == PermissionState.GrantWithGrant)
            {
                _State = "GRANT";
                _EndOption = "WITH GRANT OPTION";
            }
            else
            {
                _State = permission.PermissionState.ToString().ToUpperInvariant();
            }

            if (permission is ObjectPermissionInfo)
            {
                ObjectPermissionInfo _ObjectPermission = permission as ObjectPermissionInfo;
                if (permission.ObjectSchema == null)
                {
                    _Script = string.Format("{0} {1} ON {2}::[{3}] {4} TO [{5}] {6}", _State, _ObjectPermission.PermissionType,
                                                                                  _ObjectPermission.ObjectClass, _ObjectPermission.ObjectName,
                                                                                   (_ObjectPermission.ColumnName == null) ? string.Empty : string.Format("([{0}])", _ObjectPermission.ColumnName),
                                                                                  grantee, _EndOption);
                    _Script = _Script.Replace("ON DatabaseRole::[", "ON Role::[");
                }
                else
                {
                    _Script = string.Format("{0} {1} ON [{2}].[{3}] {4} TO [{5}] {6}", _State, _ObjectPermission.PermissionType,
                                                                                   _ObjectPermission.ObjectSchema, _ObjectPermission.ObjectName,
                                                                                   (_ObjectPermission.ColumnName == null) ? string.Empty : string.Format("([{0}])", _ObjectPermission.ColumnName),
                                                                                   grantee, _EndOption);
                }
            }
            else if (permission is ServerPermissionInfo)
            {
                ServerPermissionInfo _ServerPermission = permission as ServerPermissionInfo;
                _Script = string.Format("{0} {1} TO [{2}] {3}", _State, _ServerPermission.PermissionType, grantee, _EndOption);
            }
            else if (permission is DatabasePermissionInfo)
            {
                DatabasePermissionInfo _DatabasePermission = permission as DatabasePermissionInfo;
                _Script = string.Format("{0} {1} TO [{2}] {3}", _State, _DatabasePermission.PermissionType, grantee, _EndOption);
            }
            return _Script;
        }

        /// <summary>
        /// Returns a script to grant/deny permissions on database objects to a user or role on SQL 2000.
        /// </summary>
        /// <remarks>
        /// The SMO Option for SQL 2000 doesn't work so we had to revert back to sp_helprotect
        /// </remarks>
        private static string GetObjectPermissionScript2000(string database, string sourceUser, string destinationUser, SqlConnection connection, bool isDestination2000)
        {
            StringBuilder _Script = new StringBuilder();
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                string sql = string.Format("use {0}; exec sp_helprotect @userName = {1}",
                                           SQLHelpers.CreateSafeDatabaseName(database),
                                           SQLHelpers.CreateSafeString(sourceUser));

                using (SqlCommand _Command = new SqlCommand(sql, connection))
                using (SqlDataReader _Reader = _Command.ExecuteReader())
                {
                    while (_Reader.Read())
                    {
                        string _State = _Reader.GetString(_Reader.GetOrdinal("ProtectType")).Trim().ToUpperInvariant();
                        string _EndOption = string.Empty;
                        if (_State == "GRANT_WGO")
                        {
                            _State = "GRANT";
                            _EndOption = "WITH GRANT OPTION";
                        }
                        string _ColumnName = null;
                        if (_Reader.GetValue(_Reader.GetOrdinal("Column")) != DBNull.Value)
                        {
                            _Reader.GetString(_Reader.GetOrdinal("Column"));
                        }
                        string _Owner = _Reader.GetString(_Reader.GetOrdinal("Owner"));
                        string _Object = _Reader.GetString(_Reader.GetOrdinal("Object"));

                        if (_ColumnName == "(All+New)" || _ColumnName == "(All)" || _ColumnName == ".")
                        {
                            _ColumnName = null;
                        }

                        string onString = "";
                        if (_ColumnName != null || _Object != ".")
                        {
                            onString = "ON ";

                            if (_Object != ".")
                            {
                                onString += String.Format("{0}{1}[{2}]",
                                                           (_Owner != ".") ? _Owner : "",
                                                           (_Owner != ".") ? "." : "",
                                                           _Object);
                            }

                            if (_ColumnName != null)
                            {
                                onString += String.Format("([{0}])", _ColumnName);
                            }
                        }

                        string _Action = _Reader.GetString(_Reader.GetOrdinal("Action")).ToUpperInvariant();
                        if (isDestination2000 && _Action != "DELETE" && _Action != "INSERT" && _Action != "REFERENCES" && _Action != "SELECT" && _Action != "UPDATE" && _Action != "EXECUTE")
                        {
                            continue;
                        }

                        _Script.AppendFormat("{0} {1} {2} TO [{3}] {4}",
                                             _State,
                                             _Action,
                                             onString,
                                             destinationUser,
                                             _EndOption);

                        _Script.Append(Environment.NewLine);
                    }
                }
            }
            catch (SqlException exc)
            {
                if (exc.Number == 15330)   //No permissions found
                {
                    return string.Empty;
                }
                _Script.Append(Environment.NewLine + Environment.NewLine);
                _Script.AppendFormat(ProductConstants.ErrorUnableToDetermineObjectLevelPermissions, sourceUser);
                _Script.Append(Environment.NewLine + Environment.NewLine);
            }
            return _Script.ToString();
        }

        /// <summary>
        /// Returns a script to enable or disable a login (SQL 2005 and above).
        /// </summary>
        private static string GetEnableLoginScript(string login, bool isEnabled, Utility.TransferVersionInfo versionInfo)
        {
            switch (versionInfo)
            {
                case Utility.TransferVersionInfo.Sql2008To2005:
                case Utility.TransferVersionInfo.Sql2008To2008:
                case Utility.TransferVersionInfo.Sql2005To2005:
                case Utility.TransferVersionInfo.Sql2012To2012:
                case Utility.TransferVersionInfo.Sql2014To2014:
                case Utility.TransferVersionInfo.Sql2016To2016:
                case Utility.TransferVersionInfo.Sql2017To2017:
                case Utility.TransferVersionInfo.Sql2019To2019:
                //2012-2005,2012-2008.
                case Utility.TransferVersionInfo.Sql2012To2005:
                case Utility.TransferVersionInfo.Sql2012To2008:
                //2014-2005,2014-2008,2014-2012.
                case Utility.TransferVersionInfo.Sql2014To2005:
                case Utility.TransferVersionInfo.Sql2014To2008:
                case Utility.TransferVersionInfo.Sql2014To2012:
                //2016-2005,2016-2008,2016-2012,2016-2014.
                case Utility.TransferVersionInfo.Sql2016To2005:
                case Utility.TransferVersionInfo.Sql2016To2008:
                case Utility.TransferVersionInfo.Sql2016To2014:
                case Utility.TransferVersionInfo.Sql2016To2012:

                //2017-2005,2017-2008,2017-2012,2017-2014,2016-2016.
                case Utility.TransferVersionInfo.Sql2017To2005:
                case Utility.TransferVersionInfo.Sql2017To2008:
                case Utility.TransferVersionInfo.Sql2017To2014:
                case Utility.TransferVersionInfo.Sql2017To2012:
                case Utility.TransferVersionInfo.Sql2017To2016:

                case Utility.TransferVersionInfo.Sql2019To2005:
                case Utility.TransferVersionInfo.Sql2019To2008:
                case Utility.TransferVersionInfo.Sql2019To2014:
                case Utility.TransferVersionInfo.Sql2019To2012:
                case Utility.TransferVersionInfo.Sql2019To2016:
                case Utility.TransferVersionInfo.Sql2019To2017:

                case Utility.TransferVersionInfo.Sql2000Upgrade:
                    return string.Format("ALTER LOGIN [{0}] {1}", login, isEnabled ? "ENABLE" : "DISABLE") + Environment.NewLine;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Generates a script to assign schema ownership.
        /// </summary>
        private static string GetSchemaOwnershipScript(SchemaCollection schemas, string currentOwner, string newOwner)
        {
            string _Script = "";
            foreach (Schema _Schema in schemas)
            {
                if (_Schema.Owner == currentOwner)
                {
                    _Script += string.Format("ALTER AUTHORIZATION ON SCHEMA::[{0}] TO [{1}]", _Schema.Name, newOwner);
                    _Script += Environment.NewLine;
                }
            }
            return _Script;
        }
    }
}
