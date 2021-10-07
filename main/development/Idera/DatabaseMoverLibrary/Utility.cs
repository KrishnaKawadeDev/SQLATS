using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using System.Collections.Specialized;
using Idera.SqlAdminToolset.Core;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Transactions;
using System.Management;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;

using BBS.TracerX;

namespace Idera.SqlAdminToolset.DatabaseMoverLibrary
{
    public class Utility
    {
        #region Variables
        Logger logger = CoreGlobals.traceLog;
        TaskCompleteEventArgs _EventArgs = new TaskCompleteEventArgs();
        SQLCredentials SourceSqlCredentials;
        SQLCredentials DestinationSqlCredentials;
        #endregion

        #region public
        /// <summary>
        /// Moves a database across the network from one server to another.
        /// </summary>
        public void
           MoveDatabase(
              Server sourceServer,
              Server destinationServer,
              string database,
              List<DatabaseMoverFile> fileList,
              List<Login> loginList,
              bool deleteSourceFiles,
              string newDatabaseName,
              bool overwriteIfExists,
              bool keepSourceDatabase,
              bool grantAccessToAllMatchingDatabases,
              SQLCredentials sourceServerCred,
              SQLCredentials destinationCred)
        {
            try
            {
                SourceSqlCredentials = sourceServerCred;
                DestinationSqlCredentials = destinationCred;
                StringCollection _DefaultDatabaseLogins = new StringCollection();
                RaiseStatus(MoverStep.Initialize, ProductConstants.StatusGatheringData);
                GenerateScript _TransferLoginMethod = null;
                ApplyDefaultDatabase _DefaultDatabaseMethod = null;

                if (newDatabaseName.Trim().Length == 0)
                {
                    newDatabaseName = database;
                }

                if (destinationServer.Databases.Contains(newDatabaseName))
                {
                    if (overwriteIfExists)
                    {
                        string _Renamed = newDatabaseName + "(Old)";
                        int _NumberToAppend = 1;
                        while (destinationServer.Databases.Contains(_Renamed))
                        {
                            _NumberToAppend++;
                            _Renamed = newDatabaseName + string.Format("(Old-{0})", _NumberToAppend);
                        }

                        logger.InfoFormat("Renaming database {0} to {1}", newDatabaseName, _Renamed);
                        RaiseStatus(MoverStep.RenameExistingDestination, string.Format(ProductConstants.PromptDestinationDatabaseExistsRenaming, _Renamed));
                        destinationServer.Databases[newDatabaseName].Rename(_Renamed);
                    }
                    else
                    {
                        throw new Exception(ProductConstants.ErrorDestinationDatabaseExists);
                    }
                }

                TransferVersionInfo _VersionInfo = CheckVersion(sourceServer, destinationServer);
                //if (!IsValidOperation(_VersionInfo, false))
                //{
                //    throw new NotSupportedException(ProductConstants.ErrorNotSupportedSqlCombination);
                //}

                GetLoginDelegates(_VersionInfo, ref _TransferLoginMethod, ref _DefaultDatabaseMethod);

                if (loginList.Count > 0 && _TransferLoginMethod != null)
                {
                    RaiseStatus(MoverStep.SynchronizeLogins, ProductConstants.StatusSynchronizingSecurityLogins);
                    _DefaultDatabaseLogins = TransferLogins(_TransferLoginMethod, sourceServer, database, destinationServer, loginList);
                }

                DetachAndMove(sourceServer, destinationServer, database, newDatabaseName, fileList, keepSourceDatabase);

                if (_DefaultDatabaseLogins.Count > 0 && _DefaultDatabaseMethod != null)
                {
                    RaiseStatus(MoverStep.SetDefaultDatabase, ProductConstants.StatusApplyDefaultDatabaseToLogins);
                    foreach (string _Login in _DefaultDatabaseLogins)
                    {
                        RaiseStatus(MoverStep.SetDefaultDatabase, string.Format(ProductConstants.StatusApplyDefaultDatabaseToSpecificLogin, _Login, newDatabaseName));
                        _DefaultDatabaseMethod(destinationServer, newDatabaseName, _Login);
                    }
                }

                if (grantAccessToAllMatchingDatabases)
                {
                    foreach (Login _Login in loginList)
                    {
                        //logins that default to other databases
                        if (!string.IsNullOrEmpty(_Login.DefaultDatabase) && !_DefaultDatabaseLogins.Contains(_Login.Name) && destinationServer.Databases.Contains(_Login.DefaultDatabase))
                        {
                            RaiseStatus(MoverStep.ApplyDatabasePermissions, string.Format(ProductConstants.StatusApplyDefaultDatabaseToSpecificLogin, _Login, _Login.DefaultDatabase));
                            _DefaultDatabaseMethod(destinationServer, _Login.DefaultDatabase, _Login.Name);
                        }

                        //grant access to other databases
                        foreach (DatabaseMapping _Mapping in _Login.EnumDatabaseMappings())
                        {
                            if (destinationServer.Databases.Contains(_Mapping.DBName))
                            {
                                RaiseStatus(MoverStep.ApplyDatabasePermissions, string.Format(ProductConstants.StatusGrantingDatabasePermissions, _Login, _Mapping.DBName));
                                using (SqlCommand _Command = new SqlCommand())
                                {
                                    if (destinationServer.ConnectionContext.SqlConnectionObject.State != System.Data.ConnectionState.Open)
                                    {
                                        destinationServer.ConnectionContext.SqlConnectionObject.Open();
                                    }
                                    _Command.Connection = destinationServer.ConnectionContext.SqlConnectionObject;
                                    _Command.CommandTimeout = ToolsetOptions.commandTimeout;
                                    _Command.CommandText = string.Format("USE [{0}] \n", _Mapping.DBName) + GetDatabaseAccessScript(_Login.Name, _Mapping.UserName, _VersionInfo, sourceServer.Databases[_Mapping.DBName].Users[_Mapping.UserName].DefaultSchema);
                                    _Command.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }

                if (deleteSourceFiles)
                {
                    RaiseStatus(MoverStep.DeleteSource, ProductConstants.StatusDeletingSourceFiles);
                    fileList.ForEach(delegate (DatabaseMoverFile file)
                       {
                           RaiseStatus(MoverStep.DeleteSource, string.Format(ProductConstants.StatusDeletingSpecificSourceFile, file.SourceNetworkShare));
                           File.Delete(file.SourceNetworkShare);
                       });
                }
            }
            catch (Exception e)
            {
                logger.Error("Error moving database", e);
                RaiseStatus(MoverStep.CompleteFailed, Helpers.GetCombinedExceptionText(e));

                _EventArgs.TaskException = e;
                _EventArgs.Success = false;
            }

            if (_EventArgs.Success)
            {
                RaiseStatus(MoverStep.CompleteSuccess, ProductConstants.StatusTaskComplete);
            }
            else
            {
                RaiseStatus(MoverStep.CompleteFailed, ProductConstants.StatusTaskFailed);
            }

            if (_TaskComplete != null)
            {
                _TaskComplete(this, _EventArgs);
            }
        }

        /// <summary>
        /// Moves data files from one location to another within the same server.
        /// </summary>
        public void MoveDataFiles(Server server, string database, List<DatabaseMoverFile> dataFiles, bool deleteSourceFiles)
        {
            try
            {
                RaiseStatus(MoverStep.Initialize, ProductConstants.StatusGatheringData);

                StringCollection _SourceFileColletion = new StringCollection();
                StringCollection _DestinationFilesCollection = new StringCollection();

                Database _Database = server.Databases[database];

                DetachAndMove(server, server, database, database, dataFiles, false);

                if (deleteSourceFiles)
                {
                    RaiseStatus(MoverStep.DeleteSource, ProductConstants.StatusDeletingSourceFiles);
                    foreach (DatabaseMoverFile _File in dataFiles)
                    {
                        File.Delete(_File.SourceNetworkShare);
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("Error moving data files", e);
                RaiseStatus(MoverStep.CompleteFailed, Helpers.GetCombinedExceptionText(e));

                _EventArgs.TaskException = e;
                _EventArgs.Success = false;
            }

            if (_EventArgs.Success)
            {
                RaiseStatus(MoverStep.CompleteSuccess, ProductConstants.StatusTaskComplete);
            }
            else
            {
                RaiseStatus(MoverStep.CompleteFailed, ProductConstants.StatusTaskFailed);
            }

            if (_TaskComplete != null)
            {
                _TaskComplete(this, _EventArgs);
            }
        }

        /// <summary>
        /// Moves missing logins from a SQL server to another.
        /// </summary>
        public TaskCompleteEventArgs MoveLogins(Server sourceServer, Server destinationServer, List<Login> loginList)
        {
            _EventArgs = new LoginMoveCompleteEventArgs();
            return (LoginMoveCompleteEventArgs)MoveLogins(sourceServer, destinationServer, string.Empty, loginList);
        }

        /// <summary>
        /// Moves missing logins from a SQL server to another.
        /// </summary>
        public TaskCompleteEventArgs MoveLogins(Server sourceServer, Server destinationServer, string database, List<Login> loginList)
        {
            try
            {
                RaiseStatus(MoverStep.Initialize, ProductConstants.StatusGatheringData);
                GenerateScript _TransferLoginMethod = null;
                ApplyDefaultDatabase _DefaultDatabaseMethod = null;

                TransferVersionInfo _VersionInfo = CheckVersion(sourceServer, destinationServer);

                if (!IsValidOperation(_VersionInfo, true))
                {
                    throw new NotSupportedException(ProductConstants.ErrorNotSupportedSqlCombination);
                }

                GetLoginDelegates(_VersionInfo, ref _TransferLoginMethod, ref _DefaultDatabaseMethod);

                StringCollection _DefaultDatabaseLogins = new StringCollection();
                if (loginList.Count > 0 && _TransferLoginMethod != null)
                {
                    try
                    {
                        RaiseStatus(MoverStep.SynchronizeLogins, ProductConstants.StatusSynchronizingSecurityLogins);
                        _DefaultDatabaseLogins = TransferLogins(_TransferLoginMethod, sourceServer, database, destinationServer, loginList);
                    }
                    catch (Exception exc)
                    {
                        logger.Error("Error moving logins", exc);
                        if (exc is SqlException && ((SqlException)exc).Number == 15247)  //Not enough permissions to add user to a server role
                        {
                            RaiseStatus(MoverStep.SynchronizeLogins, ProductConstants.StatusSynchronizingSecurityLoginsRolePermissionError);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                if (database.Trim().Length > 0)
                {
                    if (_DefaultDatabaseLogins.Count > 0 && _DefaultDatabaseMethod != null)
                    {
                        RaiseStatus(MoverStep.SetDefaultDatabase, ProductConstants.StatusApplyDefaultDatabaseToLogins);
                        foreach (string _Login in _DefaultDatabaseLogins)
                        {
                            try
                            {
                                logger.DebugFormat("Setting default database to '{0}' for login '{1}'", database, _Login);
                                RaiseStatus(MoverStep.SetDefaultDatabase, string.Format(ProductConstants.StatusApplyDefaultDatabaseToSpecificLogin, _Login, database));
                                _DefaultDatabaseMethod(destinationServer, database, _Login);
                            }
                            catch (Exception exc)
                            {
                                logger.Error("Error setting default database for login", exc);
                                if (exc is SqlException && ((SqlException)exc).Number == 15007) //user not found
                                {
                                    RaiseStatus(MoverStep.SetDefaultDatabase, string.Format(ProductConstants.StatusUserNotFoundAtDestination, _Login));
                                }
                                else
                                {
                                    throw;
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (Login _Login in loginList)
                    {
                        try
                        {
                            RaiseStatus(MoverStep.SetDefaultDatabase, string.Format(ProductConstants.StatusApplyDefaultDatabaseToSpecificLogin, _Login.Name, _Login.DefaultDatabase));
                            if (destinationServer.Databases.Contains(_Login.DefaultDatabase))
                            {
                                logger.DebugFormat("Setting default database to '{0}' for login '{1}'", _Login.DefaultDatabase, _Login.Name);
                                _DefaultDatabaseMethod(destinationServer, _Login.DefaultDatabase, _Login.Name);
                            }
                            else
                            {
                                logger.DebugFormat("Setting default database to 'master' for login '{0}'", _Login.Name);
                                _DefaultDatabaseMethod(destinationServer, "master", _Login.Name);
                            }
                        }
                        catch (Exception exc)
                        {
                            logger.Error("Error setting default database for login", exc);
                            if (exc is SqlException && (((SqlException)exc).Number == 15007 || ((SqlException)exc).Number == 15151)) //user not found
                            {
                                RaiseStatus(MoverStep.SetDefaultDatabase, string.Format(ProductConstants.StatusUserNotFoundAtDestination, _Login));
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                logger.Error("Error moving logins", e);
                _EventArgs.TaskException = e;
                _EventArgs.AppendLog(Helpers.GetCombinedExceptionText(e));
                _EventArgs.Success = false;
            }

            if (_EventArgs.Success)
            {
                RaiseStatus(MoverStep.CompleteSuccess, ProductConstants.StatusTaskComplete);
            }
            else
            {
                RaiseStatus(MoverStep.CompleteFailed, ProductConstants.StatusTaskFailed);
            }

            if (_TaskComplete != null)
            {
                _TaskComplete(this, _EventArgs);
            }

            return _EventArgs;
        }

        /// <summary>
        /// Finds logins that are missing between a source and a destination server, related to the specified database.
        /// </summary>
        public static List<Login> FindMissingLogins(Server sourceServer, string sourceDatabase, Server destinationServer)
        {
            UserCollection _SourceUsers = sourceServer.Databases[sourceDatabase].Users;
            LoginCollection _DestinationLogins = destinationServer.Logins;
            List<Login> _MissingLogins = new List<Login>();

            foreach (User _User in _SourceUsers)
            {
                //skip if it has already been added.
                if (_MissingLogins.Find(delegate (Login item) { return item.Name == _User.Login; }) != null)
                {
                    continue;
                }

                if (_User.UserType != UserType.NoLogin && !_DestinationLogins.Contains(_User.Login) && _User.Login.Trim().Length > 0)
                {
                    if (sourceServer.Logins[_User.Login] == null)  //user is part of a group
                    {
                        if (_User.LoginType == LoginType.WindowsUser)
                        {
                            Login _Login = new Login(sourceServer, _User.Login);
                            _Login.LoginType = LoginType.WindowsUser;
                            if (!IsLocalUserConflict(_Login, sourceServer, destinationServer))
                            {
                                _MissingLogins.Add(_Login);
                            }
                        }
                    }
                    else
                    {
                        if ((_User.LoginType == LoginType.WindowsUser && !IsLocalUserConflict(sourceServer.Logins[_User.Login], sourceServer, destinationServer) ||
                            _User.LoginType == LoginType.SqlLogin)
                           )
                        {
                            _MissingLogins.Add(sourceServer.Logins[_User.Login]);
                        }
                    }
                }
            }
            return _MissingLogins;
        }

        /// <summary>
        /// Finds logins that are missing between a source and a destination server.
        /// </summary>
        public static List<Login> FindMissingLogins(Server sourceServer, Server destinationServer, BackgroundWorker worker)
        {
            sourceServer.SetDefaultInitFields(typeof(Login), new string[] { "Name", "LoginType" });

            List<Login> _MissingLogins = new List<Login>();

            foreach (Login _SourceLogin in sourceServer.Logins)
            {
                if (!_SourceLogin.Name.ToUpperInvariant().StartsWith("BUILTIN") && !destinationServer.Logins.Contains(_SourceLogin.Name))
                {
                    if (((_SourceLogin.LoginType == LoginType.WindowsUser || _SourceLogin.LoginType == LoginType.WindowsGroup) && !IsLocalUserConflict(_SourceLogin, sourceServer, destinationServer) ||
                           _SourceLogin.LoginType == LoginType.SqlLogin)
                          )
                    {
                        _MissingLogins.Add(_SourceLogin);
                    }
                }
                if (worker != null && worker.CancellationPending)
                {
                    return _MissingLogins;
                }
            }
            return _MissingLogins;
        }

        /// <summary>
        /// Returns true if the server version is supported.
        /// </summary>
        public static bool IsValidVersion(Server server)
        {
            return server.ConnectionContext.ServerVersion.Major >= 8;
        }

        /// <summary>
        /// Returns true if the requested operation is valid for the combination of source are destination servers.
        /// </summary>
        public static bool IsValidOperation(Server sourceServer, Server destinationServer, bool moveLoginInformationOnly)
        {
            return IsValidOperation(CheckVersion(sourceServer, destinationServer), moveLoginInformationOnly);
        }

        private static bool IsValidOperation(TransferVersionInfo versionInfo, bool moveLoginInformationOnly)
        {
            if (versionInfo == TransferVersionInfo.NotSupported ||
                versionInfo == TransferVersionInfo.Sql2005To2000 ||
                versionInfo == TransferVersionInfo.Sql2008To2000 ||
                versionInfo == TransferVersionInfo.Sql2008To2005 ||
                versionInfo == TransferVersionInfo.Sql2012To2000 ||
                versionInfo == TransferVersionInfo.Sql2012To2005 ||
                versionInfo == TransferVersionInfo.Sql2012To2008 ||
                versionInfo == TransferVersionInfo.Sql2014To2000 ||
                versionInfo == TransferVersionInfo.Sql2014To2005 ||
                versionInfo == TransferVersionInfo.Sql2014To2008 ||
                versionInfo == TransferVersionInfo.Sql2014To2012 ||
                versionInfo == TransferVersionInfo.Sql2016To2000 ||
                versionInfo == TransferVersionInfo.Sql2016To2005 ||
                versionInfo == TransferVersionInfo.Sql2016To2008 ||
                versionInfo == TransferVersionInfo.Sql2016To2012 ||
                versionInfo == TransferVersionInfo.Sql2016To2014 ||
                versionInfo == TransferVersionInfo.Sql2017To2000 ||
                versionInfo == TransferVersionInfo.Sql2017To2005 ||
                versionInfo == TransferVersionInfo.Sql2017To2008 ||
                versionInfo == TransferVersionInfo.Sql2017To2012 ||
                versionInfo == TransferVersionInfo.Sql2017To2014 ||
                versionInfo == TransferVersionInfo.Sql2017To2016 || 
                versionInfo == TransferVersionInfo.Sql2019To2000 ||
                versionInfo == TransferVersionInfo.Sql2019To2005 ||
                versionInfo == TransferVersionInfo.Sql2019To2008 ||
                versionInfo == TransferVersionInfo.Sql2019To2012 ||
                versionInfo == TransferVersionInfo.Sql2019To2014 ||
                versionInfo == TransferVersionInfo.Sql2019To2016 ||
                versionInfo == TransferVersionInfo.Sql2019To2017)
            {
                return false;
            }

            return true;
        }

        public static bool IsValidEdition(SQLVersion _SourceVersion, SQLVersion _DestinationVersion)
        {
            //if source express then destination (standard,enterprise,express)
            bool express = (_SourceVersion.Edition.Contains("Express") && (_DestinationVersion.Edition.Contains("Standard") ||
                _DestinationVersion.Edition.Contains("Enterprise") || _DestinationVersion.Edition.Contains("Express")));
            //if source standard then destination (standard,express)
            bool standard = (_SourceVersion.Edition.Contains("Standard") && (_DestinationVersion.Edition.Contains("Standard") || _DestinationVersion.Edition.Contains("Enterprise")));
            //if source enterprise then destination (enterprise)
            bool enterprise = (_SourceVersion.Edition.Contains("Enterprise") && _DestinationVersion.Edition.Contains("Enterprise"));

            if (express || standard || enterprise)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the version combination for the requested operation.
        /// </summary>
        private static TransferVersionInfo CheckVersion(Server sourceServer, Server destinationServer)
        {
            TransferVersionInfo _VersionInfo = TransferVersionInfo.NotSupported;

            if (SQLHelpers.Is2005(destinationServer.Information.Version.Major))
            {
                if (SQLHelpers.Is2005(sourceServer.Information.Version.Major))  //2005 -> 2005
                {
                    _VersionInfo = TransferVersionInfo.Sql2005To2005;
                }
                else if (SQLHelpers.Is2008(sourceServer.Information.Version.Major))  //2008 -> 2005
                {
                    _VersionInfo = TransferVersionInfo.Sql2008To2005;
                }
                else if (SQLHelpers.Is2000(sourceServer.Information.Version.Major))  //2000 -> 2005
                {
                    _VersionInfo = TransferVersionInfo.Sql2000Upgrade;
                }
                else if (SQLHelpers.Is2012(sourceServer.Information.Version.Major))  //2012 -> 2005
                {
                    _VersionInfo = TransferVersionInfo.Sql2012To2005;
                }
                else if (SQLHelpers.Is2014(sourceServer.Information.Version.Major))  //2014 -> 2005
                {
                    _VersionInfo = TransferVersionInfo.Sql2014To2005;
                }
                else if (SQLHelpers.Is2016(sourceServer.Information.Version.Major))  //2016 -> 2005
                {
                    _VersionInfo = TransferVersionInfo.Sql2016To2005;
                }
                else if(SQLHelpers.Is2017(sourceServer.Information.Version.MajorRevision)) //2017 -> 2005
                {
                    _VersionInfo = TransferVersionInfo.Sql2017To2005;
                }
                else if (SQLHelpers.Is2019orGreater(sourceServer.Information.Version.Major))  //2019 -> 2005
                {
                    _VersionInfo = TransferVersionInfo.Sql2019To2005;
                }

            }
            else if (SQLHelpers.Is2000(destinationServer.Information.Version.Major))
            {
                if (SQLHelpers.Is2000(sourceServer.Information.Version.Major))  //2000 -> 2000
                {
                    _VersionInfo = TransferVersionInfo.Sql2000To2000;
                }
                else if (SQLHelpers.Is2005(sourceServer.Information.Version.Major))  //2005 -> 2000
                {
                    _VersionInfo = TransferVersionInfo.Sql2005To2000;
                }
                else if (SQLHelpers.Is2008(sourceServer.Information.Version.Major))  //2008 -> 2000
                {
                    _VersionInfo = TransferVersionInfo.Sql2008To2000;
                }
                else if (SQLHelpers.Is2012(sourceServer.Information.Version.Major))  //2012 -> 2000
                {
                    _VersionInfo = TransferVersionInfo.Sql2012To2000;
                }
                else if (SQLHelpers.Is2014(sourceServer.Information.Version.Major))  //2014 -> 2000
                {
                    _VersionInfo = TransferVersionInfo.Sql2014To2000;
                }
                else if (SQLHelpers.Is2016(sourceServer.Information.Version.Major))  //2016 -> 2000
                {
                    _VersionInfo = TransferVersionInfo.Sql2016To2000;
                }
                else if (SQLHelpers.Is2017(sourceServer.Information.Version.Major))  //2017 -> 2000
                {
                    _VersionInfo = TransferVersionInfo.Sql2017To2000;
                }
                else if (SQLHelpers.Is2019orGreater(sourceServer.Information.Version.Major))  //2019 -> 2000
                {
                    _VersionInfo = TransferVersionInfo.Sql2019To2000;
                }

            }
            else if (SQLHelpers.Is2008(destinationServer.Information.Version.Major))
            {
                if (SQLHelpers.Is2000(sourceServer.Information.Version.Major))  //2000 -> 2008
                {
                    _VersionInfo = TransferVersionInfo.Sql2000Upgrade;
                }
                else if (SQLHelpers.Is2005(sourceServer.Information.Version.Major))  //2005 -> 2008
                {
                    _VersionInfo = TransferVersionInfo.Sql2005Upgrade;
                }
                else if (SQLHelpers.Is2008(sourceServer.Information.Version.Major))  //2008 -> 2008
                {
                    _VersionInfo = TransferVersionInfo.Sql2008To2008;
                }
                else if (SQLHelpers.Is2012(sourceServer.Information.Version.Major))  //2012 -> 2008
                {
                    _VersionInfo = TransferVersionInfo.Sql2012To2008;
                }
                else if (SQLHelpers.Is2014(sourceServer.Information.Version.Major))  //2014 -> 2008
                {
                    _VersionInfo = TransferVersionInfo.Sql2014To2008;
                }
                else if (SQLHelpers.Is2016(sourceServer.Information.Version.Major))  //2016 -> 2008
                {
                    _VersionInfo = TransferVersionInfo.Sql2016To2008;
                }
                else if (SQLHelpers.Is2017(sourceServer.Information.Version.Major))  //2017 -> 2008
                {
                    _VersionInfo = TransferVersionInfo.Sql2017To2008;
                }
                else if (SQLHelpers.Is2019orGreater(sourceServer.Information.Version.Major))  //2019 -> 2008
                {
                    _VersionInfo = TransferVersionInfo.Sql2019To2008;
                }
            }
            else if (SQLHelpers.Is2012(destinationServer.Information.Version.Major))
            {
                if (SQLHelpers.Is2000(sourceServer.Information.Version.Major))  //2000 -> 2012
                {
                    _VersionInfo = TransferVersionInfo.Sql2000Upgrade;
                }
                else if (SQLHelpers.Is2005(sourceServer.Information.Version.Major))  //2005 -> 2012
                {
                    _VersionInfo = TransferVersionInfo.Sql2005Upgrade;
                }
                else if (SQLHelpers.Is2008(sourceServer.Information.Version.Major))  //2008 -> 2012
                {
                    _VersionInfo = TransferVersionInfo.Sql2008Upgrade;
                }
                else if (SQLHelpers.Is2012(sourceServer.Information.Version.Major))  //2012 -> 2012
                {
                    _VersionInfo = TransferVersionInfo.Sql2012To2012;
                }
                else if (SQLHelpers.Is2014(sourceServer.Information.Version.Major))  //2014 -> 2012
                {
                    _VersionInfo = TransferVersionInfo.Sql2014To2012;
                }
                else if (SQLHelpers.Is2016(sourceServer.Information.Version.Major))  //2016 -> 2012
                {
                    _VersionInfo = TransferVersionInfo.Sql2016To2012;
                }
                else if (SQLHelpers.Is2017(sourceServer.Information.Version.Major))  //2017 -> 2012
                {
                    _VersionInfo = TransferVersionInfo.Sql2017To2012;
                }
                else if (SQLHelpers.Is2019orGreater(sourceServer.Information.Version.Major))  //2019 -> 2012
                {
                    _VersionInfo = TransferVersionInfo.Sql2019To2012;
                }
            }
            else if (SQLHelpers.Is2014(destinationServer.Information.Version.Major))
            {
                if (SQLHelpers.Is2000(sourceServer.Information.Version.Major))  //2000 -> 2014
                {
                    _VersionInfo = TransferVersionInfo.Sql2000Upgrade;
                }
                else if (SQLHelpers.Is2005(sourceServer.Information.Version.Major))  //2005 -> 2014
                {
                    _VersionInfo = TransferVersionInfo.Sql2005Upgrade;
                }
                else if (SQLHelpers.Is2008(sourceServer.Information.Version.Major))  //2008 -> 2014
                {
                    _VersionInfo = TransferVersionInfo.Sql2008Upgrade;
                }
                else if (SQLHelpers.Is2012(sourceServer.Information.Version.Major))  //2012 -> 2014
                {
                    _VersionInfo = TransferVersionInfo.Sql2012Upgrade;
                }
                else if (SQLHelpers.Is2014(sourceServer.Information.Version.Major))  //2014 -> 2014
                {
                    _VersionInfo = TransferVersionInfo.Sql2014To2014;
                }
                else if (SQLHelpers.Is2016(sourceServer.Information.Version.Major))  //2016 -> 2014
                {
                    _VersionInfo = TransferVersionInfo.Sql2016To2014;
                }
                else if (SQLHelpers.Is2017(sourceServer.Information.Version.Major))  //2017 -> 2014
                {
                    _VersionInfo = TransferVersionInfo.Sql2017To2014;
                }
                else if (SQLHelpers.Is2019orGreater(sourceServer.Information.Version.Major))  //2019 -> 2014
                {
                    _VersionInfo = TransferVersionInfo.Sql2019To2014;
                }
            }
            else if (SQLHelpers.Is2016(destinationServer.Information.Version.Major))
            {
                if (SQLHelpers.Is2000(sourceServer.Information.Version.Major))  //2000 -> 2016
                {
                    _VersionInfo = TransferVersionInfo.Sql2000Upgrade;
                }
                else if (SQLHelpers.Is2005(sourceServer.Information.Version.Major))  //2005 -> 2016
                {
                    _VersionInfo = TransferVersionInfo.Sql2005Upgrade;
                }
                else if (SQLHelpers.Is2008(sourceServer.Information.Version.Major))  //2008 -> 2016
                {
                    _VersionInfo = TransferVersionInfo.Sql2008Upgrade;
                }
                else if (SQLHelpers.Is2012(sourceServer.Information.Version.Major))  //2012 -> 2016
                {
                    _VersionInfo = TransferVersionInfo.Sql2012Upgrade;
                }
                else if (SQLHelpers.Is2014(sourceServer.Information.Version.Major))  //2014 -> 2016
                {
                    _VersionInfo = TransferVersionInfo.Sql2014Upgrade;
                }
                else if (SQLHelpers.Is2016(sourceServer.Information.Version.Major))  //2016 -> 2016
                {
                    _VersionInfo = TransferVersionInfo.Sql2016To2016;
                }
                else if (SQLHelpers.Is2017(sourceServer.Information.Version.Major))  //2017 -> 2016
                {
                    _VersionInfo = TransferVersionInfo.Sql2017To2016;
                }
                else if (SQLHelpers.Is2019orGreater(sourceServer.Information.Version.Major))  //2017 -> 2016
                {
                    _VersionInfo = TransferVersionInfo.Sql2019To2016;
                }

            }
            else if (SQLHelpers.Is2017(destinationServer.Information.Version.Major))
            {
                if (SQLHelpers.Is2000(sourceServer.Information.Version.Major))  //2000 -> 2017
                {
                    _VersionInfo = TransferVersionInfo.Sql2000Upgrade;
                }
                else if (SQLHelpers.Is2005(sourceServer.Information.Version.Major))  //2005 -> 2017
                {
                    _VersionInfo = TransferVersionInfo.Sql2005Upgrade;
                }
                else if (SQLHelpers.Is2008(sourceServer.Information.Version.Major))  //2008 -> 2017
                {
                    _VersionInfo = TransferVersionInfo.Sql2008Upgrade;
                }
                else if (SQLHelpers.Is2012(sourceServer.Information.Version.Major))  //2012 -> 2017
                {
                    _VersionInfo = TransferVersionInfo.Sql2012Upgrade;
                }
                else if (SQLHelpers.Is2014(sourceServer.Information.Version.Major))  //2014 -> 2017
                {
                    _VersionInfo = TransferVersionInfo.Sql2014Upgrade;
                }
                else if (SQLHelpers.Is2016(sourceServer.Information.Version.Major))  //2016 -> 2017
                {
                    _VersionInfo = TransferVersionInfo.Sql2016To2017;
                }
                else if (SQLHelpers.Is2017(sourceServer.Information.Version.Major))  //2017 -> 2017
                {
                    _VersionInfo = TransferVersionInfo.Sql2017To2017;
                }
                else if (SQLHelpers.Is2019orGreater(sourceServer.Information.Version.Major))  //2019 -> 2017
                {
                    _VersionInfo = TransferVersionInfo.Sql2019To2017;
                }
            }
            else if (SQLHelpers.Is2019orGreater(destinationServer.Information.Version.Major))
            {
                if (SQLHelpers.Is2000(sourceServer.Information.Version.Major))  //2000 -> 2019
                {
                    _VersionInfo = TransferVersionInfo.Sql2000Upgrade;
                }
                else if (SQLHelpers.Is2005(sourceServer.Information.Version.Major))  //2005 -> 2019
                {
                    _VersionInfo = TransferVersionInfo.Sql2005Upgrade;
                }
                else if (SQLHelpers.Is2008(sourceServer.Information.Version.Major))  //2008 -> 2019
                {
                    _VersionInfo = TransferVersionInfo.Sql2008Upgrade;
                }
                else if (SQLHelpers.Is2012(sourceServer.Information.Version.Major))  //2012 -> 2019
                {
                    _VersionInfo = TransferVersionInfo.Sql2012Upgrade;
                }
                else if (SQLHelpers.Is2014(sourceServer.Information.Version.Major))  //2014 -> 2019
                {
                    _VersionInfo = TransferVersionInfo.Sql2014Upgrade;
                }
                else if (SQLHelpers.Is2016(sourceServer.Information.Version.Major))  //2016 -> 2019
                {
                    _VersionInfo = TransferVersionInfo.Sql2016Upgrade;
                }
                else if (SQLHelpers.Is2017(sourceServer.Information.Version.Major))  //2019 -> 2019
                {
                    _VersionInfo = TransferVersionInfo.Sql2017Upgrade;
                }
                else if (SQLHelpers.Is2019orGreater(sourceServer.Information.Version.Major))  //2019 -> 2019
                {
                    _VersionInfo = TransferVersionInfo.Sql2019To2019;
                }
            }
            return _VersionInfo;
        }

        /// <summary>
        /// Retrieves a server's default datafile path.
        /// </summary>
        /// <remarks>
        /// Returns an empty string if the path is not found.
        /// </remarks>
        public static string GetSqlServerDefaultFilePath(Server server, DatabaseMoverFile.DatabaseFileType fileType)
        {
            string _DefaultDataRoot = @"EXEC xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'DefaultData'";
            string _DefaultLogRoot = @"EXEC xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'DefaultLog'";
            string _SetupRoot = @"EXEC xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\Setup', N'SQLDataRoot'";

            using (SqlCommand _Command = new SqlCommand())
            {
                if (server.ConnectionContext.SqlConnectionObject.State != System.Data.ConnectionState.Open)
                {
                    server.ConnectionContext.SqlConnectionObject.Open();
                }
                _Command.Connection = server.ConnectionContext.SqlConnectionObject;
                _Command.CommandTimeout = ToolsetOptions.commandTimeout;

                if (fileType == DatabaseMoverFile.DatabaseFileType.Data)
                {
                    _Command.CommandText = _DefaultDataRoot;
                }
                else
                {
                    _Command.CommandText = _DefaultLogRoot;
                }

                using (SqlDataReader _DefaultReader = _Command.ExecuteReader())
                {
                    if (_DefaultReader.Read())
                    {
                        return _DefaultReader.GetString(_DefaultReader.GetOrdinal("Data"));
                    }
                }

                _Command.CommandText = _SetupRoot;

                using (SqlDataReader _SetupReader = _Command.ExecuteReader())
                {
                    if (_SetupReader.Read())
                    {
                        return string.Format(@"{0}\Data", _SetupReader.GetString(_SetupReader.GetOrdinal("Data")));
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Returns a script used to grant a login access to a database.
        /// </summary>
        public static string GetDatabaseAccessScript(string newLoginName, string newUserName, TransferVersionInfo versionInfo, string defaultSchema)
        {
            string _Script = string.Empty;
            switch (versionInfo)
            {
                case TransferVersionInfo.Sql2000Upgrade:
                    _Script += string.Format("IF NOT EXISTS (SELECT * FROM sysusers WHERE name = N{0})", SQLHelpers.CreateSafeString(newUserName)) + Environment.NewLine;
                    _Script += string.Format("CREATE USER [{0}] FOR LOGIN [{1}]", newUserName, newLoginName);
                    break;
                case TransferVersionInfo.Sql2005To2005:
                case TransferVersionInfo.Sql2008To2008:
                case TransferVersionInfo.Sql2012To2012:
                case TransferVersionInfo.Sql2014To2014:
                case TransferVersionInfo.Sql2016To2016:
                case TransferVersionInfo.Sql2017To2017:
                case TransferVersionInfo.Sql2005Upgrade:
                case TransferVersionInfo.Sql2008To2005:
                case TransferVersionInfo.Sql2019To2019:
                case TransferVersionInfo.Sql2017Upgrade:
                case TransferVersionInfo.Sql2016Upgrade:
                case TransferVersionInfo.Sql2014Upgrade:
                case TransferVersionInfo.Sql2012Upgrade:
                case TransferVersionInfo.Sql2008Upgrade:
                    _Script += string.Format("IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N{0})", SQLHelpers.CreateSafeString(newUserName)) + Environment.NewLine;
                    _Script += string.Format("CREATE USER [{0}] FOR LOGIN [{1}] WITH DEFAULT_SCHEMA=[{2}]", newUserName, newLoginName, defaultSchema);
                    break;
                case TransferVersionInfo.Sql2000To2000:
                case TransferVersionInfo.Sql2005To2000:
                case TransferVersionInfo.Sql2008To2000:
                case TransferVersionInfo.Sql2012To2008:
                case TransferVersionInfo.Sql2012To2005:
                case TransferVersionInfo.Sql2012To2000:
                case TransferVersionInfo.Sql2014To2000: 
                case TransferVersionInfo.Sql2014To2005:
                case TransferVersionInfo.Sql2014To2008:
                case TransferVersionInfo.Sql2014To2012:
                case TransferVersionInfo.Sql2016To2000:
                case TransferVersionInfo.Sql2016To2005:
                case TransferVersionInfo.Sql2016To2008:
                case TransferVersionInfo.Sql2016To2012:
                case TransferVersionInfo.Sql2016To2014:
                case TransferVersionInfo.Sql2017To2000:
                case TransferVersionInfo.Sql2017To2005:
                case TransferVersionInfo.Sql2017To2008:
                case TransferVersionInfo.Sql2017To2012:
                case TransferVersionInfo.Sql2017To2014:
                case TransferVersionInfo.Sql2017To2016:
                case TransferVersionInfo.Sql2019To2000:
                case TransferVersionInfo.Sql2019To2005:
                case TransferVersionInfo.Sql2019To2008:
                case TransferVersionInfo.Sql2019To2012:
                case TransferVersionInfo.Sql2019To2014:
                case TransferVersionInfo.Sql2019To2016:
                case TransferVersionInfo.Sql2019To2017:
                    _Script += string.Format("IF NOT EXISTS (SELECT * FROM sysusers WHERE name = N{0})", SQLHelpers.CreateSafeString(newUserName)) + Environment.NewLine;
                    _Script += string.Format("EXEC sp_grantdbaccess @loginame = [{0}], @name_in_db = [{1}]", newLoginName, newUserName);
                    break;
            }
            return _Script;
        }
        #endregion

        #region private
        private void DetachAndMove(Server sourceServer, Server destinationServer, string database, string newDatabaseName, List<DatabaseMoverFile> fileList, bool keepSourceDatabase)
        {
            string _DatabaseOwner;
            try
            {
                _DatabaseOwner = sourceServer.Databases[database].Owner;
            }
            catch
            {
                _DatabaseOwner = string.Empty;
            }

            if (newDatabaseName.Trim().Length == 0)
            {
                newDatabaseName = database;
            }

            StringCollection _SourceDatabaseFiles = new StringCollection();

            foreach (LogFile _LogFile in sourceServer.Databases[database].LogFiles)
            {
                _SourceDatabaseFiles.Add(_LogFile.FileName);
            }

            foreach (FileGroup _FileGroup in sourceServer.Databases[database].FileGroups)
            {
                foreach (DataFile _DataFile in _FileGroup.Files)
                {
                    _SourceDatabaseFiles.Add(_DataFile.FileName);
                }
            }
            bool _SourceDetached = false;
            try
            {
                RaiseStatus(MoverStep.DetachDatabase, string.Format(ProductConstants.StatusDetachingDatabase, database, sourceServer.Name));
                if (DetachDatabase(sourceServer, database))
                {
                    _SourceDetached = true;
                    RaiseStatus(MoverStep.DetachDatabase, string.Format(ProductConstants.StatusDetachedDatabase, database, sourceServer.Name));

                    StringCollection _Files = new StringCollection();

                    RaiseStatus(MoverStep.CopyFiles, ProductConstants.StatusCopyingDatabaseFiles);
                    CopyFiles(fileList);

                    if (keepSourceDatabase)
                    {
                        RaiseStatus(MoverStep.AttachDatabase, string.Format(ProductConstants.StatusAttachingDatabase, database, sourceServer.Name));
                        try
                        {
                            if (_DatabaseOwner.Length > 0)
                            {
                                sourceServer.AttachDatabase(database, _SourceDatabaseFiles, _DatabaseOwner);
                            }
                            else
                            {
                                sourceServer.AttachDatabase(database, _SourceDatabaseFiles);
                            }
                        }
                        catch (SmoException smoExc)
                        {
                            if (!HandleAttachException(smoExc, sourceServer, database))
                            {
                                throw;
                            }
                        }
                        _SourceDetached = false;
                        RaiseStatus(MoverStep.AttachDatabase, string.Format(ProductConstants.StatusAttachedDatabase, database, sourceServer.Name));
                    }

                    fileList.ForEach(delegate (DatabaseMoverFile file) { _Files.Add(file.FullDestinationPath); });

                    RaiseStatus(MoverStep.AttachDatabase, string.Format(ProductConstants.StatusAttachingDatabase, newDatabaseName, destinationServer.Name));

                    try
                    {
                        if (destinationServer.Logins.Contains(_DatabaseOwner))
                        {
                            destinationServer.AttachDatabase(newDatabaseName, _Files, _DatabaseOwner);
                        }
                        else
                        {
                            destinationServer.AttachDatabase(newDatabaseName, _Files);
                        }
                    }
                    catch (SmoException smoExc)
                    {
                        if (!HandleAttachException(smoExc, destinationServer, newDatabaseName))
                        {
                            throw;
                        }
                    }
                    RaiseStatus(MoverStep.AttachDatabase, string.Format(ProductConstants.StatusAttachedDatabase, newDatabaseName, destinationServer.Name));

                    fileList.ForEach(delegate (DatabaseMoverFile file)
                             {
                                 if (file.DestinationLogicalName.Trim().ToUpperInvariant() != file.SourceLogicalName.Trim().ToUpperInvariant())
                                 {
                                     RaiseStatus(MoverStep.AttachDatabase, string.Format(ProductConstants.StatusRenamingLogicalFile, file.SourceLogicalName, file.DestinationLogicalName));
                                     RenameLogicalFile(destinationServer, newDatabaseName, file.SourceLogicalName, file.DestinationLogicalName);
                                     RaiseStatus(MoverStep.AttachDatabase, string.Format(ProductConstants.StatusRenamedLogicalFile, file.SourceLogicalName, file.DestinationLogicalName));
                                 }
                             });

                }
                else
                {
                    throw new Exception(ProductConstants.ErrorUnableToDetach);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error detaching database", ex);
                if (_SourceDetached)
                {
                    logger.Info("Reattaching database after error");
                    RaiseStatus(MoverStep.AttachDatabase, string.Format(ProductConstants.StatusAttachingDatabase, database, sourceServer.Name));
                    sourceServer.AttachDatabase(database, _SourceDatabaseFiles, _DatabaseOwner);
                    RaiseStatus(MoverStep.AttachDatabase, string.Format(ProductConstants.StatusAttachedDatabase, database, sourceServer.Name));
                }
                throw;
            }
        }

        /// <summary>
        /// Handles an exception generated during a database attach.  If the database was attached succesfully, then returns true.
        /// </summary>
        private bool HandleAttachException(SmoException exception, Server server, string database)
        {
            bool _Handled = false;
            Exception _InnerException = exception.InnerException;
            while (_InnerException != null && !_Handled)
            {
                SqlException _SqlException = _InnerException as SqlException;
                if (_SqlException != null && (_SqlException.Number == 5120 || //Unable to open the physical file
                                              _SqlException.Number == 5105 || //Invalid log file name
                                              _SqlException.Number == 15110)) //The proposed new database owner is already a user or aliased in the database
                {
                    server.Databases.Refresh();
                    if (server.Databases.Contains(database)) //Database attached successfully, log not found.
                    {
                        _Handled = true;
                        logger.WarnFormat("Error {0} attaching {1}\nException\n{2}", _SqlException.Number, database, Helpers.GetCombinedExceptionText(exception));
                    }
                    break;
                }
                _InnerException = _InnerException.InnerException;
            }

            return _Handled;
        }

        /// <summary>
        /// Renames a logical file name once a database has been attached.
        /// </summary>
        private void RenameLogicalFile(Server server, string database, string oldFileName, string newFileName)
        {
            using (SqlCommand _Command = new SqlCommand())
            {
                logger.Debug(string.Format("Renaming Logical File {0} to {1}", oldFileName, newFileName));
                if (server.ConnectionContext.SqlConnectionObject.State != System.Data.ConnectionState.Open)
                {
                    server.ConnectionContext.SqlConnectionObject.Open();
                }
                _Command.Connection = server.ConnectionContext.SqlConnectionObject;
                _Command.CommandTimeout = ToolsetOptions.commandTimeout;

                _Command.CommandText = string.Format("ALTER DATABASE [{0}] MODIFY file(name=[{1}],newname=[{2}])", database, oldFileName.Trim(), newFileName.Trim());
                _Command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Kills any active connections and detaches a database.
        /// </summary>
        private bool DetachDatabase(Server server, string database)
        {
            if (server.Databases.Contains(database) && (server.Databases[database].Status & DatabaseStatus.Standby) == DatabaseStatus.Standby)
            {
                using (SqlCommand _Command = new SqlCommand())
                {
                    RaiseStatus(MoverStep.DetachDatabase, string.Format(ProductConstants.StatusSettingDatabaseOnline, database));
                    if (server.ConnectionContext.SqlConnectionObject.State != System.Data.ConnectionState.Open)
                    {
                        server.ConnectionContext.SqlConnectionObject.Open();
                    }
                    _Command.Connection = server.ConnectionContext.SqlConnectionObject;
                    _Command.CommandTimeout = ToolsetOptions.commandTimeout;

                    _Command.CommandText = string.Format("RESTORE DATABASE [{0}] WITH RECOVERY", database);
                    _Command.ExecuteNonQuery();
                    RaiseStatus(MoverStep.DetachDatabase, string.Format(ProductConstants.StatusSettingDatabaseOnlineSuccess, database));
                }
            }

            // this will always kill any processes now. The user will be prompted if there are active ones before the move starts.
            if (server.GetActiveDBConnectionCount(database) > 0)
            {
                logger.InfoFormat("Killing all processes on database {0} on {1}", database, server.Name);
                server.KillAllProcesses(database);
                logger.InfoFormat("Processes killed");
            }

            server.DetachDatabase(database, false);
            return true;
        }

        /// <summary>
        /// Copies a list of database files to a specified destination.
        /// </summary>
        private void CopyFiles(List<DatabaseMoverFile> files)
        {
            files.ForEach(delegate (DatabaseMoverFile file)
               {
                   if (file.SourceNetworkShare != file.DestinationNetworkShare)
                   {
                       string _NewFilePath = CopyFile(file.SourceNetworkShare, file.DestinationNetworkShare);
                       if (_NewFilePath != file.DestinationNetworkShare)  //the requested file might have existed and had to be changed.
                       {
                           file.DestinationFileName = Path.GetFileName(_NewFilePath);
                       }
                   }
               });
        }

        /// <summary>
        /// Copies a file to a new location and returns the new file path;
        /// </summary>
        private string CopyFile(string sourceFile, string destinationFile)
        {
            string _DestinationPath = Path.GetDirectoryName(destinationFile);

            RaiseStatus(MoverStep.CopyFiles, string.Format(ProductConstants.StatusCopyingFromTo, sourceFile, _DestinationPath));
            if (!_DestinationPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                _DestinationPath = _DestinationPath + Path.DirectorySeparatorChar.ToString();
            }
            if (!Directory.Exists(_DestinationPath))
            {
                logger.Debug(string.Format("Creating Directory {0}", _DestinationPath));
                Directory.CreateDirectory(_DestinationPath);
            }

            string _NewFilePath = Path.Combine(_DestinationPath, Path.GetFileName(destinationFile));
            int _NumberToAppend = 1;
            bool _ChangedFileName = false;
            while (File.Exists(_NewFilePath))
            {
                _NumberToAppend++;
                _NewFilePath = Path.Combine(_DestinationPath, Path.GetFileNameWithoutExtension(sourceFile) + _NumberToAppend.ToString() + Path.GetExtension(sourceFile));
                _ChangedFileName = true;
            }

            if (_ChangedFileName)
            {
                RaiseStatus(MoverStep.CopyFiles, string.Format(ProductConstants.StatusCopyConflict, Path.GetFileName(_NewFilePath)));
            }

            logger.Debug(string.Format("Copying File {0} to {1}", sourceFile, _NewFilePath));
            var temppathfolder = Helpers.GetSuiteDirectory(false);
            var temppath = Path.Combine(temppathfolder, String.Format("temp_{0}.ldf",Guid.NewGuid()));
            Connection.Impersonate(SourceSqlCredentials);
            File.Copy(sourceFile, temppath, true);
            Connection.Impersonate(DestinationSqlCredentials);
            File.Copy(temppath, _NewFilePath, false);
            try
            {
                File.Delete(temppath);
            }
            catch
            {

            }
            Connection.Impersonate(null);
            return _NewFilePath;
        }

        /// <summary>
        /// Transfers logins from one database to another.
        /// </summary>
        private StringCollection TransferLogins(GenerateScript scriptMethod, Server sourceServer, string sourceDatabase, Server destinationServer, List<Login> logins)
        {
            StringCollection _DefaultDatabaseLogins = new StringCollection();
            LoginMoveCompleteEventArgs _LoginMoveArgs = _EventArgs as LoginMoveCompleteEventArgs;

            if (logins.Count > 0)
            {
                foreach (Login _Login in logins)
                {
                    try
                    {
                        List<string> properties = new List<string>();
                        List<string> denyProperties = new List<string>();
                        List<string> withGrant = new List<string>();
                        string _Pscript = string.Empty;
                        using (SqlCommand _Command = new SqlCommand())
                        {
                            string sqlcmd =string.Format( "SELECT prmssn.permission_name,prmssn.state from sys.server_permissions AS prmssn " +
                                "INNER JOIN sys.server_principals AS grantee_principal ON grantee_principal.principal_id = prmssn.grantee_principal_id" +
                                " WHERE (prmssn.class = 100)and(grantee_principal.name= '{0}')",_Login.Name);
                            if (sourceServer.ConnectionContext.SqlConnectionObject.State != System.Data.ConnectionState.Open)
                            {
                                sourceServer.ConnectionContext.SqlConnectionObject.Open();
                            }
                            _Command.Connection = sourceServer.ConnectionContext.SqlConnectionObject;
                            _Command.CommandText = sqlcmd;//"execute as login = '" + _Login.Name + "'; select permission_name from sys.fn_my_permissions(null, 'server'); revert;";
                            _Command.CommandTimeout = ToolsetOptions.commandTimeout;
                            SqlDataAdapter sda = new SqlDataAdapter(_Command);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                switch (dt.Rows[i].ItemArray[1].ToString().ToUpper())
                                {
                                    case "G":
                                        properties.Add(dt.Rows[i].ItemArray[0].ToString());
                                        break;
                                    case "D":
                                        denyProperties.Add(dt.Rows[i].ItemArray[0].ToString());
                                        break;
                                    case "W":
                                        withGrant.Add(dt.Rows[i].ItemArray[0].ToString());
                                        break;
                                }
                            }

                            foreach (string p in properties)
                            {
                                _Pscript += "GRANT " + p + " TO [" + _Login.Name + "]; ";

                            }
                            denyProperties.ForEach(p => _Pscript += "Deny " + p + " TO [" + _Login.Name + "]; ");
                            withGrant.ForEach(p => _Pscript += "GRANT " + p + " TO [" + _Login.Name + "] WITH GRANT OPTION; ");

                        }

                        logger.Debug(string.Format("Transfering login {0}:", _Login.Name));
                        if (_LoginMoveArgs != null)
                        {
                            _LoginMoveArgs.MoveResults.Add(_Login.Name, null);
                        }

                        StringBuilder _FullScript = new StringBuilder();

                        RaiseStatus(MoverStep.SynchronizeLogins, string.Format(ProductConstants.StatusTransferingLogin, _Login.Name));
                        string _Script = scriptMethod(sourceServer, _Login.Name);

                        if (IsLocalUserConflict(_Login, sourceServer, destinationServer))
                        {
                            logger.Debug(string.Format("Login {0} is a local user and cannot be transfered.", _Login.Name));
                            continue; //can't include local users
                        }

                        if (sourceDatabase.Trim().Length > 0 && sourceServer.Logins[_Login.Name].DefaultDatabase.ToUpperInvariant() == sourceDatabase.ToUpperInvariant())
                        {
                            _DefaultDatabaseLogins.Add(_Login.Name);
                        }

                        RaiseStatus(MoverStep.SynchronizeLogins, ProductConstants.StatusTransferingLoginExecuteScript);
                        using (SqlCommand _Command = new SqlCommand())
                        {
                            
                            if (destinationServer.ConnectionContext.SqlConnectionObject.State != System.Data.ConnectionState.Open)
                            {
                                destinationServer.ConnectionContext.SqlConnectionObject.Open();
                            }
                            _Command.Connection = destinationServer.ConnectionContext.SqlConnectionObject;
                            _Command.CommandTimeout = ToolsetOptions.commandTimeout;

                            _Command.CommandText = _Script;
                            _Command.ExecuteNonQuery();
                            _Command.CommandText = _Pscript;
                            _Command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception exc)
                    {
                        logger.Error(string.Format("Error transfering login {0}:", _Login.Name), exc);
                        if (_LoginMoveArgs != null)
                        {
                            _LoginMoveArgs.MoveResults[_Login.Name] = exc;
                        }
                        else
                        {
                            if (exc is SqlException)
                            {
                                switch (((SqlException)exc).Number)
                                {
                                    case 15401: //user not found
                                        RaiseStatus(MoverStep.SynchronizeLogins, string.Format(ProductConstants.StatusUserNotFoundAtDestination, _Login));
                                        break;
                                    case 15025: //user already exists
                                        RaiseStatus(MoverStep.SynchronizeLogins, string.Format(ProductConstants.StatusUserAlreadyExistsAtDestination, _Login));
                                        break;
                                    default:
                                        throw;
                                }
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                }
            }

            return _DefaultDatabaseLogins;

        }

        /// <summary>
        /// Detects if a local windows user is going accross to another server.
        /// </summary>
        private static bool IsLocalUserConflict(Login login, Server sourceServer, Server destinationServer)
        {
            try
            {
                if (login.LoginType == LoginType.SqlLogin)
                {
                    return false;
                }
                //don't move local users
                bool _IsConflict = ((login.LoginType == LoginType.WindowsUser || login.LoginType == LoginType.WindowsGroup) &&
                            (sourceServer.Information.NetName != destinationServer.Information.NetName) &&
                            (login.Name.Contains(@"\") && login.Name.Substring(0, login.Name.IndexOf('\\')).ToUpperInvariant() == sourceServer.Information.NetName.ToUpperInvariant()));

                return _IsConflict;
            }
            catch
            {
                return true;
            }
        }

        private static string GetLoginScriptForUser2005(Server server, string login)
        {
            return GetLoginScriptForUser2005(server, login, null, null);
        }

        /// <summary>
        /// Generates a script to transfer a SQL Server login, including password and SID between SQL 2005 servers. 
        /// </summary>
        /// <remarks>
        /// Based on KB Article 918992 (http://support.microsoft.com/kb/918992/)
        /// </remarks>
        public static string GetLoginScriptForUser2005(Server server, string login, string newLogin, string newPassword)
        {
            if (string.IsNullOrEmpty(newLogin))
            {
                newLogin = login;
            }

            StringBuilder _Script = new StringBuilder();

            string _LoginInformationGet =
                        "SELECT p.sid, p.name, p.type, p.is_disabled, l.hasaccess, l.denylogin, l.language FROM " +
                        "sys.server_principals p LEFT JOIN sys.syslogins l " +
                        "ON ( l.name = p.name ) WHERE p.type IN ( 'S', 'G', 'U' ) AND p.name = " + SQLHelpers.CreateSafeString(login);

            byte[] _SID = null;
            string _UserType;
            bool _IsUserDisabled = false;
            int _HasAccess = 0;
            int _DenyLogin = 0;
            string _DefaultLanguage = "";

            if (server.ConnectionContext.SqlConnectionObject.State != System.Data.ConnectionState.Open)
            {
                server.ConnectionContext.SqlConnectionObject.Open();
            }
            using (SqlCommand _Command = new SqlCommand(_LoginInformationGet, server.ConnectionContext.SqlConnectionObject))
            {
                _Command.CommandTimeout = ToolsetOptions.commandTimeout;
                using (SqlDataReader _Reader = _Command.ExecuteReader())
                {
                    if (_Reader.Read())
                    {
                        _SID = (byte[])_Reader.GetValue(_Reader.GetOrdinal("sid"));
                        login = _Reader.GetString(_Reader.GetOrdinal("name"));
                        _UserType = SQLHelpers.GetString(_Reader, _Reader.GetOrdinal("type"));
                        _IsUserDisabled = _Reader.GetBoolean(_Reader.GetOrdinal("is_disabled"));
                        _HasAccess = _Reader.GetInt32(_Reader.GetOrdinal("hasaccess"));
                        _DenyLogin = _Reader.GetInt32(_Reader.GetOrdinal("denylogin"));
                        _DefaultLanguage = _Reader.GetString(_Reader.GetOrdinal("language"));
                    }
                    else
                    {
                        throw new Exception(ProductConstants.ErrorNoUserInformationFound);
                    }
                }
                _Script.Append("DECLARE @"+ Regex.Replace(login.Replace("\\",""), @"[^0-9a-zA-Z:,]+", "").Trim() + "CreateError INT");
                _Script.Append(Environment.NewLine);

                if (_UserType == "G" || _UserType == "U")  //NT authenticated account/group
                {
                    _Script.Append(string.Format("CREATE LOGIN [{0}] FROM WINDOWS", newLogin));
                }
                else  //sql authentication
                {
                    _Command.CommandText = string.Format("SELECT CAST( LOGINPROPERTY( {0}, 'PasswordHash' ) AS varbinary (256) )", SQLHelpers.CreateSafeString(login));

                    byte[] _Password = null;
                    string _PasswordString = string.Empty;
                    object _TempPassword = _Command.ExecuteScalar();
                    if (_TempPassword != System.DBNull.Value)
                    {
                        _Password = (byte[])_TempPassword;
                        _PasswordString = GetHexValue(_Password);
                    }

                    string _SIDString = GetHexValue(_SID);
                    _Script.AppendFormat("CREATE LOGIN [{0}] ", newLogin);
                    if (newPassword == null)
                    {
                        if (_PasswordString.Length > 0)
                        {
                            _Script.AppendFormat("WITH PASSWORD = {0} HASHED, ", _PasswordString);
                        }
                        else
                        {
                            _Script.Append("WITH PASSWORD = '', ");
                        }
                    }
                    else
                    {
                        _Script.AppendFormat("WITH PASSWORD = '{0}', ", newPassword);
                    }

                    if (login == newLogin)
                    {
                        _Script.AppendFormat("SID = {0}, ", _SIDString);
                    }

                    _Script.AppendFormat("DEFAULT_LANGUAGE = {0}", _DefaultLanguage);

                    _Command.CommandText = string.Format("SELECT is_policy_checked, is_expiration_checked FROM sys.sql_logins WHERE name = {0}", SQLHelpers.CreateSafeString(login));
                    using (SqlDataReader _Reader = _Command.ExecuteReader())
                    {
                        if (_Reader.Read())
                        {
                            if (!_Reader.IsDBNull(_Reader.GetOrdinal("is_policy_checked")))
                            {
                                if (_Reader.GetBoolean(_Reader.GetOrdinal("is_policy_checked")))
                                {
                                    _Script.Append(", CHECK_POLICY = ON");
                                }
                                else
                                {
                                    _Script.Append(", CHECK_POLICY = OFF");
                                }
                            }
                            if (!_Reader.IsDBNull(_Reader.GetOrdinal("is_expiration_checked")))
                            {
                                if (_Reader.GetBoolean(_Reader.GetOrdinal("is_expiration_checked")))
                                {
                                    _Script.Append(", CHECK_EXPIRATION = ON");
                                }
                                else
                                {
                                    _Script.Append(", CHECK_EXPIRATION = OFF");
                                }
                            }
                        }
                        else
                        {
                            throw new Exception(ProductConstants.ErrorNoPermissionPolicyFound);
                        }
                    }
                }
            }
            _Script.Append(Environment.NewLine);
            _Script.Append("SET @" + Regex.Replace(login.Replace("\\", ""), @"[^0-9a-zA-Z:,]+", "").Trim() + "CreateError = @@ERROR");
            _Script.Append(Environment.NewLine);

            if (_DenyLogin == 1) //login is denied access
            {
                _Script.Append("IF(@" + Regex.Replace(login.Replace("\\", ""), @"[^0-9a-zA-Z:,]+", "").Trim() + "CreateError = 0)");
                _Script.Append(Environment.NewLine);
                _Script.Append("BEGIN");
                _Script.Append(Environment.NewLine);
                _Script.Append(string.Format("DENY CONNECT SQL TO [{0}]", newLogin));
                _Script.Append(Environment.NewLine);
                _Script.Append("SET @" + Regex.Replace(login.Replace("\\", ""), @"[^0-9a-zA-Z:,]+", "").Trim() + "CreateError = @@ERROR");
                _Script.Append(Environment.NewLine);
                _Script.Append("END");
                _Script.Append(Environment.NewLine);
            }
            else if (_HasAccess == 0)//login exists but does not have access
            {
                _Script.Append("IF(@" + Regex.Replace(login.Replace("\\", ""), @"[^0-9a-zA-Z:,]+", "").Trim() + "CreateError = 0)");
                _Script.Append(Environment.NewLine);
                _Script.Append("BEGIN");
                _Script.Append(Environment.NewLine);
                _Script.Append(string.Format("REVOKE CONNECT SQL TO [{0}]", newLogin));
                _Script.Append(Environment.NewLine);
                _Script.Append("SET @" + Regex.Replace(login.Replace("\\", ""), @"[^0-9a-zA-Z:,]+", "").Trim() + "CreateError = @@ERROR");
                _Script.Append(Environment.NewLine);
                _Script.Append("END");
                _Script.Append(Environment.NewLine);
            }

            if (_IsUserDisabled)
            {
                _Script.Append("IF(@" + Regex.Replace(login.Replace("\\", ""), @"[^0-9a-zA-Z:,]+", "").Trim() + "CreateError = 0)");
                _Script.Append(Environment.NewLine);
                _Script.Append("BEGIN");
                _Script.Append(Environment.NewLine);
                _Script.Append(string.Format("ALTER LOGIN [{0}] DISABLE", newLogin));
                _Script.Append(Environment.NewLine);
                _Script.Append("SET @" + Regex.Replace(login.Replace("\\", ""), @"[^0-9a-zA-Z:,]+", "").Trim() + "CreateError = @@ERROR");
                _Script.Append(Environment.NewLine);
                _Script.Append("END");
                _Script.Append(Environment.NewLine);
            }

            _Script.Append(Environment.NewLine);

            bool _ServerRolesFound = false;
            StringBuilder _ServerRoleScript = new StringBuilder();
            _ServerRoleScript.Append("IF(@" + Regex.Replace(login.Replace("\\", ""), @"[^0-9a-zA-Z:,]+", "").Trim() + "CreateError = 0)" + Environment.NewLine + "BEGIN");
            _ServerRoleScript.Append(Environment.NewLine);

            //Server roles
            foreach (ServerRole _Role in server.Roles)
            {
                foreach (string _Login in _Role.EnumServerRoleMembers())
                {
                    if (_Login == login)
                    {
                        _ServerRolesFound = true;
                        _ServerRoleScript.AppendFormat("exec master.dbo.sp_addsrvrolemember @loginame={0}, @rolename='{1}'", SQLHelpers.CreateSafeString(newLogin), _Role.Name);
                        _ServerRoleScript.Append(Environment.NewLine);
                        break;
                    }
                }
            }

            if (_ServerRolesFound)
            {
                _Script.Append(_ServerRoleScript.ToString());
                _Script.Append("END");
                _Script.Append(Environment.NewLine);
            }

            return _Script.ToString();
        }

        private static string GetLoginScriptForUser2000(Server server, string login)
        {
            return GetLoginScriptForUser2000(server, login, null, null);
        }
        /// <summary>
        /// Generates a script to transfer a SQL Server login, including password and SID for the following scenarios:
        /// - From SQL Server 7.0 to 7.0
        /// - From SQL Server 7.0 to 2000
        /// - Between instances of SQL Server 2000
        /// </summary>
        /// <remarks>
        /// Based on KB Article 246133 (http://support.microsoft.com/?id=246133)
        /// </remarks>
        public static string GetLoginScriptForUser2000(Server server, string login, string newLogin, string newPassword)
        {
            if (string.IsNullOrEmpty(newLogin))
            {
                newLogin = login;
            }
            StringBuilder _Script = new StringBuilder();
            _Script.Append("DECLARE @pwd sysname");
            _Script.Append(Environment.NewLine);

            string _LoginInformationGet =
                        "SELECT sid, name, xstatus, password, language FROM master..sysxlogins " +
                        "WHERE srvid IS NULL AND name = " + SQLHelpers.CreateSafeString(login);

            short _Status = 0;
            byte[] _Password = null;
            byte[] _SID = null;
            string _SIDString = "";
            string _DefaultLanguage = "";

            if (server.ConnectionContext.SqlConnectionObject.State != System.Data.ConnectionState.Open)
            {
                server.ConnectionContext.SqlConnectionObject.Open();
            }
            using (SqlCommand _Command = new SqlCommand(_LoginInformationGet, server.ConnectionContext.SqlConnectionObject))
            {
                _Command.CommandTimeout = ToolsetOptions.commandTimeout;
                using (SqlDataReader _Reader = _Command.ExecuteReader())
                {
                    if (_Reader.Read())
                    {
                        _SID = (byte[])_Reader.GetValue(_Reader.GetOrdinal("sid"));
                        login = _Reader.GetString(_Reader.GetOrdinal("name"));
                        _Status = _Reader.GetInt16(_Reader.GetOrdinal("xstatus"));
                        if (!_Reader.IsDBNull(_Reader.GetOrdinal("password")))
                        {
                            _Password = (byte[])_Reader.GetValue(_Reader.GetOrdinal("password"));
                        }
                        if (!_Reader.IsDBNull(_Reader.GetOrdinal("language")))
                        {
                            _DefaultLanguage = _Reader.GetString(_Reader.GetOrdinal("language"));
                        }
                    }
                    else
                    {
                        throw new Exception(ProductConstants.ErrorNoUserInformationFound);
                    }
                }
            }

            if ((_Status & 4) == 4)  //NT authenticated account/group
            {
                if ((_Status & 1) == 1)  //NT logon denied access
                {
                    _Script.Append(string.Format("EXEC master..sp_denylogin {0}", SQLHelpers.CreateSafeString(newLogin)));
                }
                else  //NT login has access
                {
                    _Script.Append(string.Format("EXEC master..sp_grantlogin {0}", SQLHelpers.CreateSafeString(newLogin)));
                }
                _Script.Append(Environment.NewLine);
            }
            else  //SQL Authentication
            {
                _SIDString = GetHexValue(_SID);

                if (newPassword != null)
                {
                    _Script.Append(string.Format("SET @pwd = CONVERT (varchar(256), '{0}')", newPassword));
                }
                else if (_Password != null)
                {
                    string _PasswordString = GetHexValue(_Password);
                    if ((_Status & 2048) == 2048)
                    {
                        _Script.Append(string.Format("SET @pwd = CONVERT (varchar(256), {0})", _PasswordString));
                    }
                    else
                    {
                        _Script.Append(string.Format("SET @pwd = CONVERT (varbinary(256), {0})", _PasswordString));
                    }
                }
                else
                {
                    _Script.Append("SET @pwd = NULL");
                }

                _Script.Append(Environment.NewLine);
                _Script.AppendFormat("EXEC master..sp_addlogin {0}, @pwd, ", SQLHelpers.CreateSafeString(newLogin));

                if (login == newLogin)
                {
                    _Script.AppendFormat("@sid = {0}, ", _SIDString);
                }

                if (_DefaultLanguage.Length > 0)
                {
                    _Script.AppendFormat("@deflanguage = {0}, @encryptopt = ", _DefaultLanguage);
                }
                else
                {
                    _Script.Append("@encryptopt = ");
                }

                if (!string.IsNullOrEmpty(newPassword))
                {
                    _Script.Append("NULL");
                }
                else if ((_Status & 2048) == 2048)  //login upgraded from 6.5
                {
                    _Script.Append("'skip_encryption_old'");
                }
                else
                {
                    _Script.Append("'skip_encryption'");
                }
                _Script.Append(Environment.NewLine);

            }

            bool _ServerRolesFound = false;
            StringBuilder _ServerRoleScript = new StringBuilder();
            _ServerRoleScript.Append("IF(@@ERROR = 0)" + Environment.NewLine + "BEGIN");
            _ServerRoleScript.Append(Environment.NewLine);

            //Server roles
            if ((_Status & 16) == 16)//sysadmin 
            {
                _ServerRolesFound = true;
                _ServerRoleScript.AppendFormat("EXEC master..sp_addsrvrolemember {0}, 'sysadmin'", SQLHelpers.CreateSafeString(newLogin));
                _ServerRoleScript.Append(Environment.NewLine);
            }

            if ((_Status & 32) == 32)//securityadmin 
            {
                _ServerRolesFound = true;
                _ServerRoleScript.AppendFormat("EXEC master..sp_addsrvrolemember {0}, 'securityadmin'", SQLHelpers.CreateSafeString(newLogin));
                _ServerRoleScript.Append(Environment.NewLine);
            }

            if ((_Status & 64) == 64)//serveradmin 
            {
                _ServerRolesFound = true;
                _ServerRoleScript.AppendFormat("EXEC master..sp_addsrvrolemember {0}, 'serveradmin'", SQLHelpers.CreateSafeString(newLogin));
                _ServerRoleScript.Append(Environment.NewLine);
            }

            if ((_Status & 128) == 128)//setupadmin
            {
                _ServerRolesFound = true;
                _ServerRoleScript.AppendFormat("EXEC master..sp_addsrvrolemember {0}, 'setupadmin'", SQLHelpers.CreateSafeString(newLogin));
                _ServerRoleScript.Append(Environment.NewLine);
            }

            if ((_Status & 256) == 256)//processadmin
            {
                _ServerRolesFound = true;
                _ServerRoleScript.AppendFormat("EXEC master..sp_addsrvrolemember {0}, 'processadmin'", SQLHelpers.CreateSafeString(newLogin));
                _ServerRoleScript.Append(Environment.NewLine);
            }

            if ((_Status & 512) == 512)//diskadmin
            {
                _ServerRolesFound = true;
                _ServerRoleScript.AppendFormat("EXEC master..sp_addsrvrolemember {0}, 'diskadmin'", SQLHelpers.CreateSafeString(newLogin));
                _ServerRoleScript.Append(Environment.NewLine);
            }

            if ((_Status & 1024) == 1024)//dbcreator
            {
                _ServerRolesFound = true;
                _ServerRoleScript.AppendFormat("EXEC master..sp_addsrvrolemember {0}, 'dbcreator'", SQLHelpers.CreateSafeString(newLogin));
                _ServerRoleScript.Append(Environment.NewLine);
            }

            if ((_Status & 4096) == 4096)//bulkadmin
            {
                _ServerRolesFound = true;
                _ServerRoleScript.AppendFormat("EXEC master..sp_addsrvrolemember {0}, 'bulkadmin'", SQLHelpers.CreateSafeString(newLogin));
                _ServerRoleScript.Append(Environment.NewLine);
            }

            if (_ServerRolesFound)
            {
                _Script.Append(_ServerRoleScript.ToString());
                _Script.Append("END");
                _Script.Append(Environment.NewLine);
            }

            return _Script.ToString();
        }

        /// <summary>
        /// Generates a script to transfer a SQL Server login, including password and SID for the following scenarios:
        /// You transfer logins and passwords from SQL Server 7.0 to SQL Server 2005. 
        /// You transfer logins and passwords from SQL Server 2000 to SQL Server 2005. 
        /// You assign logins to roles. 
        /// </summary>
        /// <remarks>
        /// Based on KB Article 246133 (http://support.microsoft.com/?id=246133)
        /// </remarks>
        private static string GetLoginScriptForUser2005Upgrade(Server server, string login)
        {
            return GetLoginScriptForUser2005Upgrade(server, login, null, null);
        }

        public static string GetLoginScriptForUser2005Upgrade(Server server, string login, string newLogin, string newPassword)
        {
            if (string.IsNullOrEmpty(newLogin))
            {
                newLogin = login;
            }

            StringBuilder _Script = new StringBuilder();

            string _LoginInformationGet =
                        "SELECT sid, name, xstatus, password, language FROM master..sysxlogins " +
                        "WHERE srvid IS NULL AND name = " + SQLHelpers.CreateSafeString(login);

            short _Status = 0;
            byte[] _Password = null;
            byte[] _SID = null;
            string _SIDString = "";
            string _DefaultLanguage = "";

            if (server.ConnectionContext.SqlConnectionObject.State != System.Data.ConnectionState.Open)
            {
                server.ConnectionContext.SqlConnectionObject.Open();
            }
            using (SqlCommand _Command = new SqlCommand(_LoginInformationGet, server.ConnectionContext.SqlConnectionObject))
            {
                _Command.CommandTimeout = ToolsetOptions.commandTimeout;
                using (SqlDataReader _Reader = _Command.ExecuteReader())
                {
                    if (_Reader.Read())
                    {
                        _SID = (byte[])_Reader.GetValue(_Reader.GetOrdinal("sid"));
                        login = _Reader.GetString(_Reader.GetOrdinal("name"));
                        _Status = _Reader.GetInt16(_Reader.GetOrdinal("xstatus"));
                        if (!_Reader.IsDBNull(_Reader.GetOrdinal("password")))
                        {
                            _Password = (byte[])_Reader.GetValue(_Reader.GetOrdinal("password"));
                        }

                        if (!_Reader.IsDBNull(_Reader.GetOrdinal("language")))
                        {
                            _DefaultLanguage = _Reader.GetString(_Reader.GetOrdinal("language"));
                        }
                    }
                    else
                    {
                        throw new Exception(ProductConstants.ErrorNoUserInformationFound);  //TODO: specialized exception
                    }
                }
            }

            if ((_Status & 4) == 4)  //NT authenticated account/group
            {
                if ((_Status & 1) == 1)  //NT logon denied access
                {
                    _Script.Append(string.Format("EXEC master..sp_denylogin {0}", SQLHelpers.CreateSafeString(newLogin)));
                }
                else  //NT login has access
                {
                    _Script.AppendFormat("IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE [name] = {0})", SQLHelpers.CreateSafeString(newLogin));
                    _Script.Append(Environment.NewLine);
                    _Script.AppendFormat("CREATE LOGIN [{0}] FROM WINDOWS", newLogin);
                }
                _Script.Append(Environment.NewLine);
            }
            else  //SQL Authentication
            {
                _SIDString = GetHexValue(_SID);

                if (newPassword != null)
                {
                    _Script.AppendFormat("CREATE LOGIN [{0}] WITH PASSWORD='{1}'", newLogin, newPassword);
                }
                else if (_Password != null)
                {
                    string _PasswordString = GetHexValue(_Password);
                    _Script.AppendFormat("CREATE LOGIN [{0}] WITH PASSWORD={1} HASHED", newLogin, _PasswordString);
                }
                else
                {
                    _Script.AppendFormat("CREATE LOGIN [{0}] WITH PASSWORD=''", newLogin);
                }

                if (_DefaultLanguage.Length > 0)
                {
                    _Script.AppendFormat(", CHECK_POLICY=OFF, DEFAULT_LANGUAGE = {0}", _DefaultLanguage);
                }
                else
                {
                    _Script.Append(", CHECK_POLICY=OFF");
                }
                if (login == newLogin)
                {
                    _Script.AppendFormat(", SID={0}", _SIDString);
                }
                _Script.Append(Environment.NewLine);
            }

            bool _ServerRolesFound = false;
            StringBuilder _ServerRoleScript = new StringBuilder();
            _ServerRoleScript.Append("IF(@@ERROR = 0)" + Environment.NewLine + "BEGIN");
            _ServerRoleScript.Append(Environment.NewLine);

            //Server roles
            if ((_Status & 16) == 16)//sysadmin 
            {
                _ServerRolesFound = true;
                _ServerRoleScript.AppendFormat("exec master.dbo.sp_addsrvrolemember @loginame={0}, @rolename='sysadmin'", SQLHelpers.CreateSafeString(newLogin));
                _ServerRoleScript.Append(Environment.NewLine);
            }

            if ((_Status & 32) == 32)//securityadmin 
            {
                _ServerRolesFound = true;
                _ServerRoleScript.AppendFormat("exec master.dbo.sp_addsrvrolemember @loginame={0}, @rolename='securityadmin'", SQLHelpers.CreateSafeString(newLogin));
                _ServerRoleScript.Append(Environment.NewLine);
            }

            if ((_Status & 64) == 64)//serveradmin 
            {
                _ServerRolesFound = true;
                _ServerRoleScript.AppendFormat("exec master.dbo.sp_addsrvrolemember @loginame={0}, @rolename='serveradmin'", SQLHelpers.CreateSafeString(newLogin));
                _ServerRoleScript.Append(Environment.NewLine);
            }

            if ((_Status & 128) == 128)//setupadmin
            {
                _ServerRolesFound = true;
                _ServerRoleScript.AppendFormat("exec master.dbo.sp_addsrvrolemember @loginame={0}, @rolename='setupadmin'", SQLHelpers.CreateSafeString(newLogin));
                _ServerRoleScript.Append(Environment.NewLine);
            }

            if ((_Status & 256) == 256)//processadmin
            {
                _ServerRolesFound = true;
                _ServerRoleScript.AppendFormat("exec master.dbo.sp_addsrvrolemember @loginame={0}, @rolename='processadmin'", SQLHelpers.CreateSafeString(newLogin));
                _ServerRoleScript.Append(Environment.NewLine);
            }

            if ((_Status & 512) == 512)//diskadmin
            {
                _ServerRolesFound = true;
                _ServerRoleScript.AppendFormat("exec master.dbo.sp_addsrvrolemember @loginame={0}, @rolename='diskadmin'", SQLHelpers.CreateSafeString(newLogin));
                _ServerRoleScript.Append(Environment.NewLine);
            }

            if ((_Status & 1024) == 1024)//dbcreator
            {
                _ServerRolesFound = true;
                _ServerRoleScript.AppendFormat("exec master.dbo.sp_addsrvrolemember @loginame={0}, @rolename='dbcreator'", SQLHelpers.CreateSafeString(newLogin));
                _ServerRoleScript.Append(Environment.NewLine);
            }

            if ((_Status & 4096) == 4096)//bulkadmin
            {
                _ServerRolesFound = true;
                _ServerRoleScript.AppendFormat("exec master.dbo.sp_addsrvrolemember @loginame={0}, @rolename='bulkadmin'", SQLHelpers.CreateSafeString(newLogin));
                _ServerRoleScript.Append(Environment.NewLine);
            }

            if (_ServerRolesFound)
            {
                _Script.Append(_ServerRoleScript.ToString());
                _Script.Append("END");
                _Script.Append(Environment.NewLine);
            }

            return _Script.ToString();
        }

        /// <summary>
        /// Generates a script to transfer a SQL Server login from SQL 2005 to SQL 2000.
        /// </summary>
        private static string GetLoginScriptFor2000Downgrade(Server server, string login)
        {
            return GetLoginScriptFor2000Downgrade(server, login, null, null);
        }

        public static string GetLoginScriptFor2000Downgrade(Server server, string login, string newLogin, string newPassword)
        {
            if (string.IsNullOrEmpty(newLogin))
            {
                newLogin = login;
            }

            StringBuilder _Script = new StringBuilder();
            _Script.Append("DECLARE @pwd sysname");
            _Script.Append(Environment.NewLine);

            string _LoginInformationGet =
                        "SELECT p.sid, p.name, p.type, p.is_disabled, l.hasaccess, l.denylogin, l.language FROM " +
                        "sys.server_principals p LEFT JOIN sys.syslogins l " +
                        "ON ( l.name = p.name ) WHERE p.type IN ( 'S', 'G', 'U' ) AND p.name = " + SQLHelpers.CreateSafeString(login);

            byte[] _SID = null;
            string _UserType;
            bool _IsUserDisabled = false;
            int _HasAccess = 0;
            int _DenyLogin = 0;
            string _DefaultLanguage = "";

            if (server.ConnectionContext.SqlConnectionObject.State != System.Data.ConnectionState.Open)
            {
                server.ConnectionContext.SqlConnectionObject.Open();
            }
            using (SqlCommand _Command = new SqlCommand(_LoginInformationGet, server.ConnectionContext.SqlConnectionObject))
            {
                _Command.CommandTimeout = ToolsetOptions.commandTimeout;
                using (SqlDataReader _Reader = _Command.ExecuteReader())
                {
                    if (_Reader.Read())
                    {
                        _SID = (byte[])_Reader.GetValue(_Reader.GetOrdinal("sid"));
                        login = _Reader.GetString(_Reader.GetOrdinal("name"));
                        _UserType = SQLHelpers.GetString(_Reader, _Reader.GetOrdinal("type"));
                        _IsUserDisabled = _Reader.GetBoolean(_Reader.GetOrdinal("is_disabled"));
                        _HasAccess = _Reader.GetInt32(_Reader.GetOrdinal("hasaccess"));
                        _DenyLogin = _Reader.GetInt32(_Reader.GetOrdinal("denylogin"));
                        _DefaultLanguage = _Reader.GetString(_Reader.GetOrdinal("language"));
                    }
                    else
                    {
                        throw new Exception(ProductConstants.ErrorNoUserInformationFound);
                    }
                }

                if (_UserType == "G" || _UserType == "U")  //NT authenticated account/group
                {
                    _Script.Append(string.Format("EXEC master..sp_grantlogin {0}", SQLHelpers.CreateSafeString(newLogin)));
                    _Script.Append(Environment.NewLine);
                }
                else  //sql authentication
                {
                    string _SIDString = GetHexValue(_SID);
                    string _EncryptionOption = "'skip_encryption'";

                    if (newPassword != null)
                    {
                        _Script.Append(string.Format("SET @pwd = CONVERT (varchar(256), '{0}')", newPassword));
                        _EncryptionOption = "NULL";
                    }
                    else
                    {
                        _Command.CommandText = string.Format("SELECT CAST( LOGINPROPERTY( {0}, 'PasswordHash' ) AS varbinary (256) )", SQLHelpers.CreateSafeString(login));

                        byte[] _Password = null;
                        string _PasswordString = string.Empty;
                        object _TempPassword = _Command.ExecuteScalar();
                        if (_TempPassword != System.DBNull.Value)
                        {
                            _Password = (byte[])_TempPassword;
                            _PasswordString = GetHexValue(_Password);
                            _Script.Append(string.Format("SET @pwd = {0}", _PasswordString));
                        }
                        else
                        {
                            _Script.Append("SET @pwd = NULL)");
                        }
                    }
                    _Script.Append(Environment.NewLine);
                    _Script.AppendFormat("EXEC master..sp_addlogin {0}, @pwd, ", SQLHelpers.CreateSafeString(newLogin));
                    if (login == newLogin)
                    {
                        _Script.AppendFormat("@sid = {0}, ", _SIDString);
                    }
                    _Script.AppendFormat("@deflanguage = {0}, @encryptopt = {1}", _DefaultLanguage, _EncryptionOption);

                    _Script.Append(Environment.NewLine);
                }
            }

            bool _ServerRolesFound = false;
            StringBuilder _ServerRoleScript = new StringBuilder();
            _ServerRoleScript.Append("IF(@@ERROR = 0)" + Environment.NewLine + "BEGIN");
            _ServerRoleScript.Append(Environment.NewLine);

            //Server roles
            foreach (ServerRole _Role in server.Roles)
            {
                if (_Role.Name.ToUpperInvariant() == "SYSADMIN" || _Role.Name.ToUpperInvariant() == "SECURITYADMIN" || _Role.Name.ToUpperInvariant() == "SERVERADMIN" ||
                   _Role.Name.ToUpperInvariant() == "SETUPADMIN" || _Role.Name.ToUpperInvariant() == "PROCESSADMIN" || _Role.Name.ToUpperInvariant() == "DISKADMIN" ||
                   _Role.Name.ToUpperInvariant() == "DBCREATOR" || _Role.Name.ToUpperInvariant() == "BULKADMIN")
                {
                    foreach (string _Login in _Role.EnumServerRoleMembers())
                    {
                        if (_Login == login)
                        {
                            _ServerRolesFound = true;
                            _ServerRoleScript.AppendFormat("exec master.dbo.sp_addsrvrolemember @loginame={0}, @rolename='{1}'", SQLHelpers.CreateSafeString(newLogin), _Role.Name);
                            _ServerRoleScript.Append(Environment.NewLine);
                            break;
                        }
                    }
                }
            }

            if (_ServerRolesFound)
            {
                _Script.Append(_ServerRoleScript.ToString());
                _Script.Append("END");
                _Script.Append(Environment.NewLine);
            }

            return _Script.ToString();
        }

        /// <summary>
        /// Gets a Hex value that corresponds to the requested binary value.
        /// </summary>
        /// <param name="binaryValue"></param>
        /// <returns></returns>
        private static string GetHexValue(byte[] binaryValue)
        {
            StringBuilder _HexString = new StringBuilder(binaryValue.Length + 2);
            _HexString.Append("0x");
            for (int i = 0; i < binaryValue.Length; i++)
            {
                _HexString.Append(binaryValue[i].ToString("X2"));
            }
            return _HexString.ToString();
        }

        /// <summary>
        /// Sets the default database for users that were transfered into a 2005 database.
        /// </summary>
        private static void ApplyDefaultDatabaseToUsers2005(Server server, string database, string login)
        {
            string _Script = GetScriptDefaultDatabase2005(database, login);
            if (server.ConnectionContext.SqlConnectionObject.State != System.Data.ConnectionState.Open)
            {
                server.ConnectionContext.SqlConnectionObject.Open();
            }
            using (SqlCommand _Command = new SqlCommand(_Script, server.ConnectionContext.SqlConnectionObject))
            {
                _Command.CommandTimeout = ToolsetOptions.commandTimeout;
                _Command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Generates a default database script for SQL 2005.
        /// </summary>
        public static string GetScriptDefaultDatabase2005(string database, string login)
        {
            return string.Format("ALTER LOGIN [{0}] WITH DEFAULT_DATABASE=[{1}]", login, database);
        }

        /// <summary>
        /// Sets the default database for a user on a 2000 database.
        /// </summary>
        private static void ApplyDefaultDatabaseToUsers2000(Server server, string database, string login)
        {
            string _Script = GetScriptDefaultDatabase2000(database, login);
            if (server.ConnectionContext.SqlConnectionObject.State != System.Data.ConnectionState.Open)
            {
                server.ConnectionContext.SqlConnectionObject.Open();
            }
            using (SqlCommand _Command = new SqlCommand(_Script, server.ConnectionContext.SqlConnectionObject))
            {
                _Command.CommandTimeout = ToolsetOptions.commandTimeout;
                _Command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Generates a default database script for SQL 2000.
        /// </summary>
        public static string GetScriptDefaultDatabase2000(string database, string login)
        {
            return string.Format("EXEC sp_defaultdb {0}, '{1}'", SQLHelpers.CreateSafeString(login), database);
        }

        /// <summary>
        /// Notifies caller of new task status.
        /// </summary>
        private void RaiseStatus(MoverStep step, string stepDescription)
        {
            _EventArgs.AppendLog(stepDescription);
            if (_TaskStatus != null)
            {
                _TaskStatus(this, new StatusEventArgs(step, stepDescription));
            }
            logger.InfoFormat("{0}: {1}", step, stepDescription);
        }

        /// <summary>
        /// Gets the correct login operation delegates for a valid sql server combination.
        /// </summary>
        private static void GetLoginDelegates(TransferVersionInfo versionInfo, ref GenerateScript transferLoginMethod, ref ApplyDefaultDatabase defaultDatabaseMethod)
        {
            switch (versionInfo)
            {
                case TransferVersionInfo.Sql2005To2005:
                case TransferVersionInfo.Sql2008To2008:
                case TransferVersionInfo.Sql2005Upgrade:
                case TransferVersionInfo.Sql2008To2005:
                case TransferVersionInfo.Sql2008Upgrade:
                case TransferVersionInfo.Sql2012To2012:
                case TransferVersionInfo.Sql2012To2005:
                case TransferVersionInfo.Sql2012To2008:
                case TransferVersionInfo.Sql2012Upgrade:
                case TransferVersionInfo.Sql2014To2014:
                case TransferVersionInfo.Sql2014To2005:
                case TransferVersionInfo.Sql2014To2008:
                case TransferVersionInfo.Sql2014To2012:
                case TransferVersionInfo.Sql2014Upgrade:
                case TransferVersionInfo.Sql2016To2016:
                case TransferVersionInfo.Sql2016To2005:
                case TransferVersionInfo.Sql2016To2008:
                case TransferVersionInfo.Sql2016To2012:
                case TransferVersionInfo.Sql2016To2014:
                case TransferVersionInfo.Sql2017To2017:
                case TransferVersionInfo.Sql2016To2017:
                case TransferVersionInfo.Sql2017To2005:
                case TransferVersionInfo.Sql2017To2008:
                case TransferVersionInfo.Sql2017To2012:
                case TransferVersionInfo.Sql2017To2014:
                case TransferVersionInfo.Sql2017To2016:
                case TransferVersionInfo.Sql2016Upgrade:
                case TransferVersionInfo.Sql2017Upgrade:
                case TransferVersionInfo.Sql2019To2005:
                case TransferVersionInfo.Sql2019To2008:
                case TransferVersionInfo.Sql2019To2012:
                case TransferVersionInfo.Sql2019To2014:
                case TransferVersionInfo.Sql2019To2016:
                case TransferVersionInfo.Sql2019To2017:
                case TransferVersionInfo.Sql2019To2019:
                    transferLoginMethod = GetLoginScriptForUser2005;
                    defaultDatabaseMethod = ApplyDefaultDatabaseToUsers2005;
                    break;
                case TransferVersionInfo.Sql2000Upgrade:
                    transferLoginMethod = GetLoginScriptForUser2005Upgrade;
                    defaultDatabaseMethod = ApplyDefaultDatabaseToUsers2005;
                    break;
                case TransferVersionInfo.Sql2000To2000:
                    transferLoginMethod = GetLoginScriptForUser2000;
                    defaultDatabaseMethod = ApplyDefaultDatabaseToUsers2000;
                    break;
                case TransferVersionInfo.Sql2005To2000:
                case TransferVersionInfo.Sql2008To2000:
                case TransferVersionInfo.Sql2012To2000:
                case TransferVersionInfo.Sql2014To2000:
                case TransferVersionInfo.Sql2016To2000:
                case TransferVersionInfo.Sql2017To2000:
                case TransferVersionInfo.Sql2019To2000:
                    transferLoginMethod = GetLoginScriptFor2000Downgrade;
                    defaultDatabaseMethod = ApplyDefaultDatabaseToUsers2000;
                    break;
            }
        }
        #endregion

        #region Delegate
        private delegate string GenerateScript(Server server, string loginName);
        private delegate void ApplyDefaultDatabase(Server serverName, string database, string loginName);
        #endregion

        #region events
        private EventHandler<StatusEventArgs> _TaskStatus;

        public EventHandler<StatusEventArgs> TaskStatusEventHandler
        {
            get { return _TaskStatus; }
            set { _TaskStatus = value; }
        }

        /// <summary>
        /// Raised when a task completes on a server.
        /// </summary>
        public event EventHandler<StatusEventArgs> TaskStatus
        {
            add { _TaskStatus += value; }
            remove { _TaskStatus -= value; }
        }

        private EventHandler<TaskCompleteEventArgs> _TaskComplete;

        public EventHandler<TaskCompleteEventArgs> TaskCompleteEventHandler
        {
            get { return _TaskComplete; }
            set { _TaskComplete = value; }
        }

        /// <summary>
        /// Raised when a task completes on a server.
        /// </summary>
        public event EventHandler<TaskCompleteEventArgs> TaskComplete
        {
            add { _TaskComplete += value; }
            remove { _TaskComplete -= value; }
        }
        #endregion

        #region VersionInfo Enum
        /// <summary>
        /// Information about the version combination for the requested transfer.
        /// </summary>
        public enum TransferVersionInfo
        {
            /// <summary>
            /// The requested version combination is not supported
            /// </summary>
            NotSupported,

            /// <summary>
            /// SQL Server 2000 to SQL Server 2000
            /// </summary>
            Sql2000To2000,

            /// <summary>
            /// SQL Server 2000 to SQL Server 2005 or above
            /// </summary>
            Sql2000Upgrade,

            /// <summary>
            /// SQL Server 2005 to SQL Server 2005
            /// </summary>
            Sql2005To2005,

            /// <summary>
            /// SQL Server 2005 to SQL Server 2000 (security info only)
            /// </summary>
            Sql2005To2000,

            /// <summary>
            /// SQL Server 2005 upgrade to 2008
            /// </summary>
            Sql2005Upgrade,

            /// <summary>
            /// SQL Server 2008 to SQL Server 2008
            /// </summary>
            Sql2008To2008,

            /// <summary>
            /// SQL Server 2008 to SQL Server 2005
            /// </summary>
            Sql2008To2005,

            /// <summary>
            /// SQL Server 2008 to SQL Server 2000
            /// </summary>
            Sql2008To2000,

            /// <summary>
            /// SQL Server 2008 upgrade to 2012
            /// </summary>
            Sql2008Upgrade,

            /// <summary>
            /// SQL Server 2012 to SQL Server 2012
            /// </summary>
            Sql2012To2012,

            /// <summary>
            /// SQL Server 2012 to SQL Server 2008
            /// </summary>
            Sql2012To2008,

            /// <summary>
            /// SQL Server 2012 to SQL Server 2005
            /// </summary>
            Sql2012To2005,

            /// <summary>
            /// SQL Server 2012 to SQL Server 2008
            /// </summary>
            Sql2012To2000,

            /// <summary>
            /// SQL Server 2012 upgrade to 2014
            /// </summary>
            Sql2012Upgrade,

            /// SQL Server 2014 to SQL Server 2014
            /// </summary>
            /// 
            Sql2014To2014,
            /// <summary>
            /// SQL Server 2014 to SQL Server 2012
            /// </summary>
            ///
            Sql2014To2012,

            /// <summary>
            /// SQL Server 2014 to SQL Server 2008
            /// </summary>
            Sql2014To2008,

            /// <summary>
            /// SQL Server 2014 to SQL Server 2005
            /// </summary>
            Sql2014To2005,

            /// <summary>
            /// SQL Server 2014 to SQL Server 2008
            /// </summary>
            /// 
            Sql2014To2000,
            /// <summary>
            /// SQL Server 2014 upgrade to 2016
            /// </summary>
            /// 
            Sql2014Upgrade,
            Sql2016Upgrade,
            Sql2017Upgrade,
            /// <summary>
            /// SQL Server 2016 to SQL Server 2000
            /// </summary>
            /// 
            Sql2016To2000,
            /// <summary>
            /// SQL Server 2016 to SQL Server 2005
            /// </summary>
            /// 
            Sql2016To2005,
            /// <summary>
            /// SQL Server 2016 to SQL Server 2008
            /// </summary>
            /// 
            Sql2016To2008,
            /// <summary>
            /// SQL Server 2016 to SQL Server 2012
            /// </summary>
            /// 
            Sql2016To2012,
            /// <summary>
            /// SQL Server 2016 to SQL Server 2014
            /// </summary>
            /// 
            Sql2016To2014,
            /// <summary>
            /// SQL Server 2016 to SQL Server 2016
            /// </summary>
            /// 
            Sql2016To2016,
            /// <summary>
            /// SQL Server 2016 to SQL Server 2017
            /// </summary>
            /// 
            Sql2016To2017,

            /// <summary>
            /// SQL Server 2016 to SQL Server 2016
            /// </summary>
            /// 
            Sql2017To2017,
            /// <summary>
            /// SQL Server 2017 to SQL Server 2017
            /// </summary>
            /// 
            Sql2017To2016,
            /// <summary>
            /// SQL Server 2017 to SQL Server 2016
            /// </summary>
            /// 
            Sql2017To2014,
            /// <summary>
            /// SQL Server 2017 to SQL Server 2016
            /// </summary>
            /// 
            Sql2017To2012,
            /// <summary>
            /// SQL Server 2017 to SQL Server 2016
            /// </summary>
            /// 
            Sql2017To2008,
            /// <summary>
            /// SQL Server 2017 to SQL Server 2016
            /// </summary>
            /// 
            Sql2017To2005,
            /// <summary>
            /// SQL Server 2017 to SQL Server 2016
            /// </summary>
            Sql2017To2000,
            /// <summary>
            /// SQL Server 2019 to SQL Server 2017
            /// </summary>
            Sql2019To2019,
            /// <summary>
            /// SQL Server 2019 to SQL Server 2017
            /// </summary>
            Sql2019To2017,
            /// <summary>
            /// SQL Server 2019 to SQL Server 2016
            /// </summary>
            /// 
            Sql2019To2016,
            /// <summary>
            /// SQL Server 2019 to SQL Server 2014
            /// </summary>
            /// 
            Sql2019To2014,
            /// <summary>
            /// SQL Server 2019 to SQL Server 2012
            /// </summary>
            /// 
            Sql2019To2012,
            /// <summary>
            /// SQL Server 2019 to SQL Server 2008
            /// </summary>
            /// 
            Sql2019To2008,
            /// <summary>
            /// SQL Server 2019 to SQL Server 2005
            /// </summary>
            Sql2019To2005,
            /// <summary>
            /// SQL Server 2019 to SQL Server 2000
            /// </summary>
            Sql2019To2000



        }
        #endregion




    }

    #region EventArgs
    public class StatusEventArgs : EventArgs
    {
        private MoverStep _Step;
        private string _Description;

        public StatusEventArgs(MoverStep step, string description)
        {
            _Step = step;
            _Description = description;
        }

        /// <summary>
        /// Step
        /// </summary>
        public MoverStep Step
        {
            get { return _Step; }
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get { return _Description; }
        }
    }

    public class LoginMoveCompleteEventArgs : TaskCompleteEventArgs
    {
        Dictionary<string, Exception> _MoveResults = new Dictionary<string, Exception>();

        /// <summary>
        /// Dictionary containing moved logins and their exception (if any) during the move.
        /// </summary>
        public Dictionary<string, Exception> MoveResults
        {
            get { return _MoveResults; }
        }
    }

    public class TaskCompleteEventArgs : EventArgs
    {
        private StringBuilder _Log = new StringBuilder();
        private bool _Success = true;
        private Exception _Exception = null;

        /// <summary>
        /// Log
        /// </summary>
        public string Log
        {
            get { return _Log.ToString(); }
        }

        /// <summary>
        /// Success
        /// </summary>
        public bool Success
        {
            get { return _Success; }
            set { _Success = value; }
        }

        /// <summary>
        /// Exception encountered during the mover task.
        /// </summary>
        public Exception TaskException
        {
            get { return _Exception; }
            set { _Exception = value; }
        }

        public void AppendLog(string log)
        {
            _Log.Append(log);
            _Log.Append(Environment.NewLine);
        }
    }
    #endregion

    public enum MoverStep
    {
        Initialize,
        RenameExistingDestination,
        SynchronizeLogins,
        DetachDatabase,
        AttachDatabase,
        SetDefaultDatabase,
        CopyFiles,
        DeleteSource,
        ApplyDatabasePermissions,
        CompleteSuccess,
        CompleteFailed
    }
}
