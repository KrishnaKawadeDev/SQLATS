using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using System.Data;
using Microsoft.SqlServer.Management.Smo.Agent;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Idera.SqlAdminToolset.ServerStatistics
{
    internal static class StatisticsHelper
    {
        private static object threadLock = new object();

        internal static StatisticalData GetServerNode(ServerInformation serverInfo, int commandTimeout, JobPoolOptions options)
        {
            lock (threadLock)
            {
                using (SqlConnection _Connection = Connection.OpenConnection(serverInfo.Name, serverInfo.SqlCredentials))
                {
                    #region Server Node
                    Server _Server = new Server(new ServerConnection(_Connection));

                    if (_Server.Information.Version.Major <= 7)
                    {
                        return null;
                    }
                    StatisticalData _ServerData = new StatisticalData(_Connection.DataSource, PopulateServer, null, DataType.RawData, NodeIcon.Server, serverInfo);
                    PopulateStatistics(_ServerData, _Server);

                    if (options.CancelRequested)
                    {
                        return _ServerData;
                    }

                    #endregion

                    #region Database Node

                    StatisticalData _DatabaseData = _ServerData.AddChild(new StatisticalData("Databases", PopulateDatabase, PreviewDatabase, DataType.RawData, NodeIcon.Database));
                    _DatabaseData.AddChild(new StatisticalData("Compatibility Level", PopulateDatabaseCompatibility, null, DataType.Rollup, NodeIcon.DbCompatibility));
                    _DatabaseData.AddChild(new StatisticalData("Database State", PopulateDatabaseState, null, DataType.Rollup, NodeIcon.DbState));
                    StatisticalData _DataFileData = _DatabaseData.AddChild(new StatisticalData("Data Files", PopulateDataFiles, PreviewDataFile, DataType.RawData, NodeIcon.DataFiles));
                    StatisticalData _LogFileData = _DatabaseData.AddChild(new StatisticalData("Log Files", PopulateLogFiles, PreviewDataFile, DataType.RawData, NodeIcon.LogFiles));
                    lock (options)
                    {
                        PreviewStatistics(_DatabaseData, _Server);
                        PreviewStatistics(_DataFileData, _Server);
                        PreviewStatistics(_LogFileData, _Server);
                    }
                    if (options.CancelRequested)
                    {
                        return _ServerData;
                    }


                    #endregion

                    #region Logins Node

                    StatisticalData _LoginData = _ServerData.AddChild(new StatisticalData("Logins", PopulateLogins, PreviewLogins, DataType.RawData, NodeIcon.Logins));
                    _LoginData.AddChild(new StatisticalData("Login Type", PopulateLoginType, null, DataType.Rollup, NodeIcon.LoginType));
                    _LoginData.AddChild(new StatisticalData("Login Enabled", PopulateLoginEnabled, null, DataType.Rollup, NodeIcon.LoginEnabled));
                    _LoginData.AddChild(new StatisticalData("Password Policy Enabled", PopulateLoginPasswordPolicy, null, DataType.Rollup, NodeIcon.LoginPolicy));

                    lock (options)
                    {
                        PreviewStatistics(_LoginData, _Server);
                    }
                    if (options.CancelRequested)
                    {
                        return _ServerData;
                    }
                    #endregion

                    #region Backup Devices Node

                    StatisticalData _BackupDeviceData = _ServerData.AddChild(new StatisticalData("Backup Devices", PopulateBackupDevices, PreviewBackupDevices, DataType.RawData, NodeIcon.BackupDevices));
                    _BackupDeviceData.AddChild(new StatisticalData("Device Type", PopulateBackupDeviceType, null, DataType.Rollup, NodeIcon.None));

                    PreviewStatistics(_BackupDeviceData, _Server);

                    if (options.CancelRequested)
                    {
                        return _ServerData;
                    }
                    #endregion

                    #region Linked Servers

                    StatisticalData _LinkedServerData = _ServerData.AddChild(new StatisticalData("Linked Servers", PopulateLinkedServers, PreviewLinkedServers, DataType.RawData, NodeIcon.LinkedServers));
                    PreviewStatistics(_LinkedServerData, _Server);

                    if (options.CancelRequested)
                    {
                        return _ServerData;
                    }

                    #endregion

                    #region SQL Agent Node

                    StatisticalData _SqlAgentData = _ServerData.AddChild(new StatisticalData("SQL Server Agent", PopulateSqlServerAgent, null, DataType.RawData, NodeIcon.Agent));
                    StatisticalData _JobData = _SqlAgentData.AddChild(new StatisticalData("Jobs", PopulateAgentJobs, PreviewAgentJobs, DataType.RawData, NodeIcon.Jobs));
                    StatisticalData _OperatorData = _SqlAgentData.AddChild(new StatisticalData("Operators", PopulateAgentOperators, PreviewAgentOperators, DataType.RawData, NodeIcon.Operators));
                    StatisticalData _AgentErrorLogData = _SqlAgentData.AddChild(new StatisticalData("Agent Error Logs", PopulateAgentErrorLogs, PreviewAgentErrorLogs, DataType.RawData, NodeIcon.ErrorLogs));
                    PreviewStatistics(_JobData, _Server);
                    PreviewStatistics(_OperatorData, _Server);
                    PreviewStatistics(_AgentErrorLogData, _Server);

                    #endregion

                    #region Processes

                    StatisticalData _ProcessData = _ServerData.AddChild(new StatisticalData("Processes", PopulateProcesses, PreviewProcesses, DataType.RawData, NodeIcon.Processes));
                    PreviewStatistics(_ProcessData, _Server);

                    if (options.CancelRequested)
                    {
                        return _ServerData;
                    }

                    #endregion

                    #region Media

                    StatisticalData _Media = _ServerData.AddChild(new StatisticalData("Media", PopulateMedia, null, DataType.RawData, NodeIcon.Media));
                    PopulateStatistics(_Media, _Server);

                    if (options.CancelRequested)
                    {
                        return _ServerData;
                    }

                    #endregion

                    #region Logs

                    StatisticalData _LogData = _ServerData.AddChild(new StatisticalData("Error Logs", PopulateServerErrorLogs, PreviewServerErrorLogs, DataType.RawData, NodeIcon.ErrorLogs));
                    PreviewStatistics(_LogData, _Server);

                    if (options.CancelRequested)
                    {
                        return _ServerData;
                    }

                    #endregion

                    #region Locks

                    StatisticalData _LockData = _ServerData.AddChild(new StatisticalData("Locks", PopulateLocks, PreviewLocks, DataType.RawData, NodeIcon.Locks));
                    PreviewStatistics(_LockData, _Server);

                    if (options.CancelRequested)
                    {
                        return _ServerData;
                    }

                    #endregion

                    #region Performance Counters

                    _ServerData.AddChild(new StatisticalData("Performance Counters", PopulateCounters, null, PopulateAllCounters, DataType.RawDataGroup, NodeIcon.PerformanceCounter));

                    #endregion

                    _Server = null;
                    _Connection.Close();

                    return _ServerData;
                }
            }
        }

        #region Populate data
        /// <summary>
        /// Populates statistical data using the credentials supplied with the data object.
        /// </summary>
        /// <param name="data"></param>
        internal static void PopulateStatistics(StatisticalData data)
        {
            if (data.Type != DataType.Rollup)
            {
                using (SqlConnection _Connection = Connection.OpenConnection(data.Credentials.Name, data.Credentials.SqlCredentials))
                {
                    PopulateStatistics(data, new Server(new ServerConnection(_Connection)));
                }
            }
            else
            {
                data.PopulateMethod(null, data);
                data.IsDataLoaded = true;
            }
        }

        internal static void PopulateStatistics(StatisticalData data, Server server)
        {
            data.PopulateMethod(server, data);
            data.IsDataLoaded = true;
        }

        internal static void PreviewStatistics(StatisticalData data)
        {
            if (data.Credentials != null)
            {
                using (SqlConnection _Connection = Connection.OpenConnection(data.Credentials.Name, data.Credentials.SqlCredentials))
                {
                    PreviewStatistics(data, new Server(new ServerConnection(_Connection)));
                }
            }
        }

        internal static void PreviewStatistics(StatisticalData data, Server server)
        {
            try
            {
                if (data.PreviewMethod != null)
                {
                    data.PreviewMethod(server, data);
                    data.IsDataLoaded = false;
                }
            }
            catch (Exception e)
            {
                data.DataException = e;
            }
        }


        /// <summary>
        /// Loads all the child values of a statistical data element
        /// </summary>
        /// <param name="data"></param>
        internal static void BulkLoadStatistics(StatisticalData data)
        {
            using (SqlConnection _Connection = Connection.OpenConnection(data.Credentials.Name, data.Credentials.SqlCredentials))
            {
                data.BulkLoadMethod(new Server(new ServerConnection(_Connection)), data);
                data.IsDataLoaded = true;
            }
        }

        /// <summary>
        /// Populates statistical data of all child stats for the requested object.  Data is skipped if data is already marked as loaded.
        /// </summary>
        internal static void PopulateStatisticsTree(StatisticalData data)
        {
            PopulateStatisticsTree(data, int.MaxValue);
        }

        /// <summary>
        /// Populates statistical data of all child stats for the requested object, up to the level specified by the maximum depth.  Data is skipped if data is already marked as loaded.
        /// </summary>
        internal static void PopulateStatisticsTree(StatisticalData data, int maxDepth)
        {
            using (SqlConnection _Connection = Connection.OpenConnection(data.Credentials.Name, data.Credentials.SqlCredentials))
            {
                Server _Server = new Server(new ServerConnection(_Connection));
                LoadDataTree(data, _Server, maxDepth, 0);
            }
        }

        /// <summary>
        /// Recursively loads statistical data onto the data tree.
        /// </summary>
        private static void LoadDataTree(StatisticalData data, Server server, int maxCount, int currentCount)
        {
            if (!data.IsDataLoaded)
            {
                PopulateStatistics(data, server);
            }
            currentCount++;
            if (currentCount <= maxCount)
            {
                foreach (StatisticalData _ChildData in data.ChildData)
                {
                    LoadDataTree(_ChildData, server, maxCount, currentCount);
                }
            }
        }

        /// <summary>
        /// Refreshes statistical data of all child stats for the requested object.
        /// </summary>
        internal static void RefreshStatisticsTree(StatisticalData data)
        {
            switch(data.Type)
            {
                case DataType.Rollup:
                case DataType.RawDataGroup:
                    data.ChildData.Clear();
                    break;
                case DataType.RawData:
                    if (data.Values != null)
                    {
                        data.Values.Clear();
                        data.Values.Columns.Clear();
                    }
                    data.DetailNames = null;
                    break;
            }

            if (data.IsDataLoaded)
            {
                PopulateStatistics(data);
            }
            else
            {
                PreviewStatistics(data);
            }

            if (data.Type != DataType.Rollup)
            {
                foreach (StatisticalData _ChildData in data.ChildData)
                {
                    RefreshStatisticsTree(_ChildData);
                }
            }
        }


        #endregion

        #region Pre-populate data counts
        /// <summary>
        /// Retrieves data used to preview database information.
        /// </summary>
        private static void PreviewDatabase(Server server, StatisticalData data)
        {
            data.ItemCount = server.Databases.Count;
        }

        /// <summary>
        /// Retrieves data used to preview database file information.
        /// </summary>
        private static void PreviewDataFile(Server server, StatisticalData data)
        {
            int _DataFileCount = 0;
            foreach (Database _Database in server.Databases)
            {
                try
                {
                    foreach (FileGroup _FileGroup in _Database.FileGroups)
                    {
                        _DataFileCount += _FileGroup.Files.Count;
                    }
                }
                catch { }
            }
            data.ItemCount = _DataFileCount;
        }

        /// <summary>
        /// Retrieves data used to preview database log file information.
        /// </summary>
        private static void PreviewLogFile(Server server, StatisticalData data)
        {
            int _LogFileCount = 0;
            foreach (Database _Database in server.Databases)
            {
                try
                {
                    _LogFileCount += _Database.LogFiles.Count;
                }
                catch { }
            }
            data.ItemCount = _LogFileCount;
        }

        /// <summary>
        /// Retrieves data used to preview database login information.
        /// </summary>
        private static void PreviewLogins(Server server, StatisticalData data)
        {
            data.ItemCount = server.Logins.Count;
        }

        /// <summary>
        /// Retrieves data used to preview backup device information.
        /// </summary>
        private static void PreviewBackupDevices(Server server, StatisticalData data)
        {
            data.ItemCount = server.BackupDevices.Count;
        }

        /// <summary>
        /// Retrieves data used to preview linked server information.
        /// </summary>
        private static void PreviewLinkedServers(Server server, StatisticalData data)
        {
            data.ItemCount = server.LinkedServers.Count;
        }

        /// <summary>
        /// Retrieves data used to preview agent job information.
        /// </summary>
        private static void PreviewAgentJobs(Server server, StatisticalData data)
        {
            data.ItemCount = server.JobServer.Jobs.Count;
        }

        /// <summary>
        /// Retrieves data used to preview agent operator information.
        /// </summary>
        private static void PreviewAgentOperators(Server server, StatisticalData data)
        {
            data.ItemCount = server.JobServer.Operators.Count;
        }

        /// <summary>
        /// Retrieves data used to preview agent error log information.
        /// </summary>
        private static void PreviewAgentErrorLogs(Server server, StatisticalData data)
        {
            data.ItemCount = server.JobServer.EnumErrorLogs().Rows.Count;
        }

        /// <summary>
        /// Retrieves data used to preview process information.
        /// </summary>
        private static void PreviewProcesses(Server server, StatisticalData data)
        {
            data.ItemCount = server.EnumProcesses().Rows.Count;
        }

        /// <summary>
        /// Retrieves data used to preview server error log information.
        /// </summary>
        private static void PreviewServerErrorLogs(Server server, StatisticalData data)
        {
            data.ItemCount = server.EnumErrorLogs().Rows.Count;
        }

        /// <summary>
        /// Retrieves data used to preview lock information.
        /// </summary>
        private static void PreviewLocks(Server server, StatisticalData data)
        {
            data.ItemCount = server.EnumLocks().Rows.Count;
        }

        #endregion

        #region Retrieve data
        /// <summary>
        /// Retrieves top-level server data
        /// </summary>
        private static void PopulateServer(Server server, StatisticalData data)
        {
            data.DetailNames = new StatisticsHeader[] { "Release", "Version", "Edition", "OS Version", 
                               StatisticsHeader.Center("Processors"), StatisticsHeader.Int("Memory"), StatisticsHeader.Center("Last Start Date")};

            string _ServerSql = "CREATE TABLE #ServerStats(ID int,  Name  sysname, Internal_Value int, Value nvarchar(512))\n" +
                                "INSERT #ServerStats EXEC master.dbo.xp_msver\n" +
                                "SELECT SERVERPROPERTY(N'servername') AS [ServerName], \n" +
                                "@@VERSION AS SQLVersion, \n" +
                                "SERVERPROPERTY(N'ProductVersion') AS [VersionString],\n" +
                                "(SELECT Value FROM #ServerStats WHERE Name = N'WindowsVersion') AS [WindowsVersion],\n" +
                                "(SELECT Internal_Value FROM #ServerStats WHERE Name = N'ProcessorCount') AS [Processors],\n" +
                                "(SELECT Internal_Value FROM #ServerStats WHERE Name = N'PhysicalMemory') AS [PhysicalMemory]\n" +
                                "DROP TABLE #ServerStats";

            using (SqlCommand _Command = new SqlCommand(_ServerSql, server.ConnectionContext.SqlConnectionObject))
            using (SqlDataReader _Reader = _Command.ExecuteReader())
            {
                if (_Reader.Read())
                {
                    string _ServerName = _Reader.GetString(_Reader.GetOrdinal("ServerName"));

                    SQLVersion _SqlVersion;
                    if (SQLVersion.TryParse(_Reader.GetString(_Reader.GetOrdinal("SQLVersion")), out _SqlVersion))
                    {
                        data.AddRow(new object[] {_SqlVersion.Name, _Reader.GetString(_Reader.GetOrdinal("VersionString")), _SqlVersion.Edition,
                                    Helpers.GetWindowsVersion(_Reader.GetString(_Reader.GetOrdinal("WindowsVersion"))), _Reader.GetInt32(_Reader.GetOrdinal("Processors")), 
                                    new DataValue<int>(_Reader.GetInt32(_Reader.GetOrdinal("PhysicalMemory")), Helpers.StrFormatByteSize((ulong)_Reader.GetInt32(_Reader.GetOrdinal("PhysicalMemory")) * 1024 * 1024)),
                                    DateTime.MinValue});
                    }
                }
                else
                {
                    throw new InvalidOperationException("No server data found");
                }
            }

            data.Values.Rows[0][data.Values.Columns.Count - 1] = new DataValue<string>(SQLHelpers.GetServerStartDate(server.ConnectionContext.SqlConnectionObject).ToString());
        }

        private static void PopulateDatabase(Server server, StatisticalData data)
        {
            try
            {
                data.DetailNames = new StatisticsHeader[] {"Name", "Owner", "State", StatisticsHeader.Int("Compatibility Level"), 
                                   StatisticsHeader.Int("Active Connections"), StatisticsHeader.IntCenter("Tables"), 
                                   StatisticsHeader.IntCenter("Stored Procedures"), StatisticsHeader.Double("Size (MB)"), 
                                   StatisticsHeader.Date("Create Date")};


                foreach (Database _Database in server.Databases)
                {
                    object[] _Data = null;
                    int _CompatibilityLevel;
                    if (_Database.CompatibilityLevel.ToString().Length >= 7)
                    {
                        _CompatibilityLevel = int.Parse(_Database.CompatibilityLevel.ToString().Remove(0, 7));
                    }
                    else
                    {
                        _CompatibilityLevel = int.Parse(_Database.CompatibilityLevel.ToString());
                    }
                    if (_Database.CompatibilityLevel == CompatibilityLevel.Version60 || _Database.CompatibilityLevel == CompatibilityLevel.Version65)
                    {
                        _Data = new object[] { string.Format("{0} (Not Supported)", _Database.Name), null, null, _CompatibilityLevel, null, null, null, null, null };
                    }
                    else
                    {
                        DateTime creationDate = _Database.CreateDate;
                        if (!_Database.IsSystemObject)
                        {
                            try
                            {
                                creationDate = SQLHelpers.GetCreationDateForUserDatabase(server.ConnectionContext.SqlConnectionObject,
                                                                          _Database.Name);
                            }
                            catch
                            {
                                creationDate = _Database.CreateDate;
                            }
                        }

                        string _DatabaseStatus = string.Empty;
                        try
                        {
                            if (SQLHelpers.Is2005orGreater(server.Information.Version.Major) && _Database.IsMirroringEnabled)
                            {
                                string _MirroringRole = string.Empty;
                                string _MirroringRoleSql = string.Format("select mirroring_role_desc from sys.database_mirroring dm inner join sys.databases d on dm.database_id = d.database_id where [name] = '{0}'", _Database.Name);

                                using (SqlCommand _RoleCommand = new SqlCommand(_MirroringRoleSql, server.ConnectionContext.SqlConnectionObject))
                                {
                                    _MirroringRole = (string)_RoleCommand.ExecuteScalar();
                                }

                                _DatabaseStatus = string.Format("{0}: {1} / {2}", _MirroringRole, _Database.MirroringStatus, _Database.Status);
                            }
                            else
                            {
                                _DatabaseStatus = _Database.Status.ToString();
                            }
                        }
                        catch
                        {
                            _DatabaseStatus = "ERROR";
                        }

                        try
                        {
                            _Data = new object[] { _Database.Name, _Database.Owner, _DatabaseStatus, _CompatibilityLevel, _Database.ActiveConnections, _Database.Tables.Count, _Database.StoredProcedures.Count, new DataValue<double>(_Database.Size, _Database.Size.ToString("N2")), creationDate };
                        }
                        catch
                        {
                            try
                            {
                                _Data = new object[] { _Database.Name, _Database.Owner, _DatabaseStatus, _CompatibilityLevel, null, null, null, null, creationDate };
                            }
                            catch
                            {
                                _Data = new object[] { _Database.Name, null, _DatabaseStatus, null, null, null, null, null, null };
                            }
                        }
                    }
                    data.AddRow(_Data);
                 }
            }
            catch (Exception exc)
            {
                data.DataException = exc;
            }
        }

        private static void PopulateDatabaseCompatibility(Server server, StatisticalData data)
        {
            AddDataGrouping(data, "Compatibility Level", NodeIcon.Database);
        }

        private static void PopulateDatabaseState(Server server, StatisticalData data)
        {
            AddDataGrouping(data, "State", NodeIcon.Database);
        }

        private static void PopulateDataFiles(Server server, StatisticalData data)
        {
            try
            {
                server.SetDefaultInitFields(typeof(FileGroup), true);
                server.SetDefaultInitFields(typeof(DataFile), false);
                
                data.DetailNames = new StatisticsHeader[] {"Database", "Logical Name", "File Name", "File Group", 
                                    StatisticsHeader.Double("Size"), StatisticsHeader.Double("Used Space"), "Growth", 
                                    StatisticsHeader.Double("Maximum Size"), "Online", "Read-Only", "File Path" };
                data.DetailIconImage = NodeIcon.DataFiles;

                foreach (Database _Database in server.Databases)
                {
                    try
                    {
                        foreach (FileGroup _FileGroup in _Database.FileGroups)
                        {
                            foreach (DataFile _File in _FileGroup.Files)
                            {
                                Nullable<bool> _IsReadOnly = null;
                                Nullable<bool> _IsOffline = null;
                                try { _IsReadOnly = _File.IsReadOnly; }
                                catch { }
                                try { _IsOffline = _File.IsOffline; }
                                catch { }
                                data.AddRow(new object[]{_Database.Name, _File.Name, Path.GetFileName(_File.FileName), _FileGroup.Name, 
                                         new DataValue<double>(_File.Size, Helpers.StrFormatByteSize((ulong)_File.Size * 1024)), 
                                         new DataValue<double>(_File.UsedSpace, Helpers.StrFormatByteSize((ulong)_File.UsedSpace * 1024)),
                                         _File.GrowthType == FileGrowthType.KB ? Helpers.StrFormatByteSize((ulong)_File.Growth * 1024) : string.Format("{0} %", _File.Growth),
                                         _File.MaxSize == -1 ? new DataValue<double>(double.MaxValue, "Unrestricted") : new DataValue<double>(_File.MaxSize, Helpers.StrFormatByteSize((ulong)_File.MaxSize * 1024)), 
                                         _IsOffline.HasValue ? (!_IsOffline.Value).ToString() : "N/A", 
                                         _IsReadOnly.HasValue ? _IsReadOnly.Value.ToString() : "N/A", _File.FileName});
                            }
                        }
                    }
                    catch { }
                }
            }
            catch (Exception exc)
            {
                data.DataException = exc;
            }
         }

        private static void PopulateLogFiles(Server server, StatisticalData data)
        {
            try
            {
                server.SetDefaultInitFields(typeof(LogFile), true);

                data.DetailNames = new StatisticsHeader[] { "Database", "Logical Name", "File Name", 
                                                   StatisticsHeader.Double("Size"), StatisticsHeader.Double("Used Space"), "Growth", 
                                                   StatisticsHeader.Double("Maximum Size"), "Online", "Read-Only", "File Path" };
                data.DetailIconImage = NodeIcon.LogFiles;

                foreach (Database _Database in server.Databases)
                {
                    try
                    {
                        foreach (LogFile _LogFile in _Database.LogFiles)
                        {
                            Nullable<bool> _IsReadOnly = null;
                            Nullable<bool> _IsOffline = null;
                            try { _IsReadOnly = _LogFile.IsReadOnly; }
                            catch { }
                            try { _IsOffline = _LogFile.IsOffline; }
                            catch { }

                            data.AddRow(new object[]{_Database.Name, _LogFile.Name, Path.GetFileName(_LogFile.FileName), 
                                        new DataValue<double>(_LogFile.Size, Helpers.StrFormatByteSize((ulong)_LogFile.Size * 1024)), 
                                        new DataValue<double>(_LogFile.UsedSpace, Helpers.StrFormatByteSize((ulong)_LogFile.UsedSpace * 1024)),
                                        _LogFile.GrowthType == FileGrowthType.KB ? Helpers.StrFormatByteSize((ulong)_LogFile.Growth * 1024) : string.Format("{0} %", _LogFile.Growth),
                                        _LogFile.MaxSize == -1 ? new DataValue<double>(double.MaxValue, "Unrestricted") : new DataValue<double>(_LogFile.MaxSize, Helpers.StrFormatByteSize((ulong)_LogFile.MaxSize * 1024)), 
                                        _IsOffline.HasValue ? (!_IsOffline.Value).ToString() : "N/A", 
                                        _IsReadOnly.HasValue ? _IsReadOnly.Value.ToString() : "N/A", _LogFile.FileName});
                        }
                    }
                    catch { }
                }
            }
            catch (Exception exc)
            {
                data.DataException = exc;
            }
        }

        private static void PopulateLogins(Server server, StatisticalData data)
        {
            try
            {
                server.SetDefaultInitFields(typeof(Login), true);

                data.DetailNames = new StatisticsHeader[] {"Name", "Type", "Default Database", StatisticsHeader.Center("Granted Access"), StatisticsHeader.Center("Enabled"), 
                         StatisticsHeader.Center("Locked"), StatisticsHeader.Center("Must Change Password"), 
                         StatisticsHeader.Center("Password Expired"), StatisticsHeader.Center("Password Policy Enforced"), 
                         StatisticsHeader.Center("Password Expiration Enabled"),
                          "Create Date", "Last Modified"};
                data.DetailIconImage = NodeIcon.Login;

                foreach (Login _Login in server.Logins)
                {
                    object[] _Data = null;
                    if (_Login.LoginType == LoginType.SqlLogin)
                    {
                        if (SQLHelpers.Is2005orGreater(server.Information.Version.Major))
                        {
                            _Data = new object[] {_Login.Name, _Login.LoginType, _Login.DefaultDatabase, _Login.HasAccess, !_Login.IsDisabled,
                                   _Login.IsLocked, _Login.MustChangePassword, _Login.IsPasswordExpired, _Login.PasswordPolicyEnforced,
                                   _Login.PasswordExpirationEnabled, _Login.CreateDate, _Login.DateLastModified};
                        }
                        else
                        {
                            _Data = new object[] {_Login.Name, _Login.LoginType, _Login.DefaultDatabase, _Login.HasAccess, null,
                                   null, null, null, null, null, _Login.CreateDate, _Login.DateLastModified};
                        }
                    }
                    else
                    {
                        _Data = new object[] {_Login.Name, _Login.LoginType, _Login.DefaultDatabase, _Login.HasAccess, 
                            SQLHelpers.Is2005orGreater(server.Information.Version.Major) ? (!_Login.IsDisabled).ToString() : null,
                                null, null, null, null, null, _Login.CreateDate, _Login.DateLastModified};
                    }

                    data.AddRow(_Data);
                }
            }
            catch (Exception exc)
            {
                data.DataException = exc;
            }
        }

        private static void PopulateLoginType(Server server, StatisticalData data)
        {
            AddDataGrouping(data, "Type", NodeIcon.Login);
        }

        private static void PopulateLoginEnabled(Server server, StatisticalData data)
        {
            AddDataGrouping(data, "Enabled", NodeIcon.Login);
        }

        private static void PopulateLoginPasswordPolicy(Server server, StatisticalData data)
        {
            AddDataGrouping(data, "Password Policy Enforced", NodeIcon.Login);
        }

        private static void PopulateBackupDevices(Server server, StatisticalData data)
        {
            try
            {
                server.SetDefaultInitFields(typeof(BackupDevice), true);

                data.DetailNames = new StatisticsHeader[] { "Name", StatisticsHeader.Center("Type"), "Path" };

                foreach (BackupDevice _Device in server.BackupDevices)
                {
                    data.AddRow(new object[] { _Device.Name, _Device.BackupDeviceType, _Device.PhysicalLocation });
                }
            }
            catch (Exception exc)
            {
                data.DataException = exc;
            }
        }

        private static void PopulateBackupDeviceType(Server server, StatisticalData data)
        {
            AddDataGrouping(data, "Type", NodeIcon.None);
        }

        private static void PopulateLinkedServers(Server server, StatisticalData data)
        {
            try
            {
                server.SetDefaultInitFields(typeof(LinkedServer), true);

                data.DetailNames = new StatisticsHeader[] { "Name", StatisticsHeader.Center("Data Access"), StatisticsHeader.Center("RPC"), StatisticsHeader.Center("RPC Out"), 
                                       StatisticsHeader.Center("Collation Compatible"), StatisticsHeader.Center("Use Remote Collation"), 
                                       "Collation Name", StatisticsHeader.Int("Connection Timeout"), StatisticsHeader.Int("Query Timeout")};

                foreach (LinkedServer _LinkedServer in server.LinkedServers)
                {
                    data.AddRow(new object[] {_LinkedServer.Name, _LinkedServer.DataAccess, _LinkedServer.Rpc, _LinkedServer.RpcOut,
                     _LinkedServer.CollationCompatible, _LinkedServer.UseRemoteCollation, _LinkedServer.CollationName,
                     _LinkedServer.ConnectTimeout, _LinkedServer.QueryTimeout});
                }
            }
            catch (Exception exc)
            {
                data.DataException = exc;
            }
        }

        private static void PopulateSqlServerAgent(Server server, StatisticalData data)
        {
            try
            {
                server.SetDefaultInitFields(typeof(JobServer), true);

                data.DetailNames = new StatisticsHeader[] {"Type", "Log Level", "Error Log File", 
                                       StatisticsHeader.Center("Mail Type"), StatisticsHeader.Center("Mail Profile"), 
                                       StatisticsHeader.Int("Maximum History Rows"), StatisticsHeader.Int("Maximum History Rows Per Job"),
                                       StatisticsHeader.Center("Auto-Start"), StatisticsHeader.Center("Auto-Restart"), StatisticsHeader.Center("Auto-Restart SQL Server")};

                if (SQLHelpers.Is2005orGreater(server.Information.Version.Major))
                {
                    data.AddRow(new object[] { server.JobServer.JobServerType, server.JobServer.AgentLogLevel, server.JobServer.ErrorLogFile,
                                             server.JobServer.AgentMailType, server.JobServer.DatabaseMailProfile,
                                             server.JobServer.MaximumHistoryRows, server.JobServer.MaximumJobHistoryRows,
                                             server.JobServer.SqlAgentAutoStart, server.JobServer.SqlAgentRestart, server.JobServer.SqlServerRestart});
                }
                else
                {
                    data.AddRow(new object[] { server.JobServer.JobServerType, server.JobServer.AgentLogLevel, server.JobServer.ErrorLogFile,
                                             "SQL Mail", string.Empty,
                                             server.JobServer.MaximumHistoryRows, server.JobServer.MaximumJobHistoryRows,
                                             server.JobServer.SqlAgentAutoStart, server.JobServer.SqlAgentRestart, server.JobServer.SqlServerRestart});
                }
            }
            catch (Exception exc)
            {
                SqlException _SqlException = exc.InnerException as SqlException;
                if (_SqlException != null && _SqlException.Number == 15281)
                {
                    data.DataException = new Exception(ProductConstants.SqlAgentError);
                }
                else
                {
                    data.DataException = exc;
                }
            }
        }

        private static void PopulateAgentJobs(Server server, StatisticalData data)
        {
            try
            {
                server.SetDefaultInitFields(typeof(Job), true);

                data.DetailNames = new StatisticsHeader[] {"Name", "Description", "Category", StatisticsHeader.Center("Type"), 
                                       StatisticsHeader.Center("Enabled"), StatisticsHeader.Date("Last Run Date"), "Last Run Outcome",
                                       StatisticsHeader.Date("Next Run Date"), StatisticsHeader.Date("Date Created"), 
                                       StatisticsHeader.Date("Last Modified"), StatisticsHeader.Int("Version"), "Owner"};

                foreach (Job _Job in server.JobServer.Jobs)
                {
                    data.AddRow(new object[]{_Job.Name, _Job.Description, _Job.Category, _Job.JobType, _Job.IsEnabled, 
                                          new DataValue<DateTime>(_Job.LastRunDate, GetFormattedDate(_Job.LastRunDate)), 
                                          _Job.LastRunOutcome, new DataValue<DateTime>(_Job.NextRunDate, GetFormattedDate(_Job.NextRunDate)),
                                          _Job.DateCreated, _Job.DateLastModified, 
                                          _Job.VersionNumber, _Job.OwnerLoginName});
                }
            }
            catch (Exception exc)
            {
                data.DataException = exc;
            }
        }

        private static void PopulateAgentOperators(Server server, StatisticalData data)
        {
            try
            {
                server.SetDefaultInitFields(typeof(Operator), true);

                data.DetailNames = new StatisticsHeader[] {"Name", StatisticsHeader.Center("Enabled"), "Email", StatisticsHeader.Date("Last Email"), "Net Send", 
                                       StatisticsHeader.Date("Last Net Send"), "Pager", StatisticsHeader.Date("Last Page")};

                foreach (Operator _Operator in server.JobServer.Operators)
                {
                    data.AddRow(new object[]{_Operator.Name, _Operator.Enabled, 
                                          _Operator.EmailAddress, new DataValue<DateTime>(_Operator.LastEmailDate, GetFormattedDate(_Operator.LastEmailDate)), 
                                          _Operator.NetSendAddress, new DataValue<DateTime>(_Operator.LastNetSendDate, GetFormattedDate(_Operator.LastNetSendDate)), 
                                          _Operator.PagerAddress, new DataValue<DateTime>(_Operator.LastPagerDate, GetFormattedDate(_Operator.LastPagerDate))});
                }
            }
            catch (Exception exc)
            {
                SqlException _SqlException = exc.InnerException as SqlException;
                if (_SqlException != null && _SqlException.Number == 15281)
                {
                    data.DataException = new Exception(ProductConstants.SqlAgentError);
                }
                else
                {
                    data.DataException = exc;
                }
            }
        }

        private static void PopulateAgentErrorLogs(Server server, StatisticalData data)
        {
            try
            {
                AddDataFromErrorLogs(data, server.JobServer.EnumErrorLogs());
            }
            catch (Exception exc)
            {
                SqlException _SqlException = exc.InnerException as SqlException;
                if (_SqlException != null && _SqlException.Number == 15281)
                {
                    data.DataException = new Exception(ProductConstants.SqlAgentError);
                }
                else
                {
                    data.DataException = exc;
                }
            }
        }

        private static void PopulateProcesses(Server server, StatisticalData data)
        {
            try
            {
                data.DetailNames = new StatisticsHeader[] {StatisticsHeader.IntCenter("SPID"), "Login", "Host", "Status", 
                                                           "Command", "Database", StatisticsHeader.IntCenter("CPU"), 
                                                           StatisticsHeader.IntCenter("Memory Usage"), 
                                                           StatisticsHeader.IntCenter("Blocking SPID"), 
                                                           StatisticsHeader.Center("Is System"), "Program", 
                                                           StatisticsHeader.IntCenter("ExecutionContextID")};

                foreach (DataRow _Row in server.EnumProcesses().Rows)
                {
                    data.AddRow(new object[]{int.Parse(_Row[2].ToString()), _Row[3], _Row[4], _Row[5],
                                             _Row[6], _Row[7], _Row[8], _Row[9], int.Parse(_Row[10].ToString()), _Row[11], _Row[12], int.Parse(_Row[13].ToString())});
                }
            }
            catch (Exception exc)
            {
                data.DataException = exc;
            }
        }

        private static void PopulateMedia(Server server, StatisticalData data)
        {
            try
            {
                data.DetailNames = new StatisticsHeader[] { "Drive", StatisticsHeader.IntCenter("Free Space") };
                int _MediaCount = 0;
                using (SqlCommand _Command = new SqlCommand("master..xp_fixeddrives", server.ConnectionContext.SqlConnectionObject))
                {
                    using (SqlDataReader _Reader = _Command.ExecuteReader())
                    {
                        while (_Reader.Read())
                        {
                            data.AddRow(new object[] { _Reader.GetValue(0), new DataValue<int>(_Reader.GetInt32(1), Helpers.StrFormatByteSize((ulong)_Reader.GetInt32(1) * 1024 * 1024)) });
                            _MediaCount++;
                        }
                    }
                }
                data.ItemCount = _MediaCount;
            }
            catch (Exception exc)
            {
                data.DataException = exc;
            }
        }

        private static void PopulateServerErrorLogs(Server server, StatisticalData data)
        {
            try
            {
                AddDataFromErrorLogs(data, server.EnumErrorLogs());
            }
            catch (Exception exc)
            {
                data.DataException = exc;
            }
        }

        private static void PopulateLocks(Server server, StatisticalData data)
        {
            try
            {
                AddDataFromTable(data, server.EnumLocks());
            }
            catch (Exception exc)
            {
                data.DataException = exc;
            }
        }

        #region Counters
        //Counter constants
        const int _RatioCounter2005 = 537003264;
        const int _DivisorCounter2005 = 1073939712;
        const int _PerSecondCounter2005 = 272696576;
        const string _CounterTable2005 = "sys.dm_os_performance_counters";
        const int _RatioCounter2000 = 537003008;
        const int _DivisorCounter2000 = 1073939459;
        const int _PerSecondCounter2000 = 272696320;
        const string _CounterTable2000 = "master..sysperfinfo";


        /// <summary>
        /// Populates all counters at once.
        /// </summary>
        private static void PopulateAllCounters(Server server, StatisticalData data)
        {
            try
            {
                data.ChildData.Clear();

                string _PerfCounterSql = "DECLARE @FirstMeasure TABLE \n" +
                                         "([object_name] NCHAR(128), counter_name NCHAR(128), instance_name NCHAR(128), cntr_value BIGINT, captureTime DATETIME) \n" +
                                         "DECLARE @SecondMeasure TABLE \n" +
                                         "([object_name] NCHAR(128), counter_name NCHAR(128), instance_name NCHAR(128), cntr_value BIGINT, captureTime DATETIME) \n" +
                                         "INSERT INTO @FirstMeasure \n" +
                                         "SELECT [object_name], counter_name, instance_name, cntr_value, GETDATE() \n" +
                                         "FROM {2} \n" +
                                         "WHERE cntr_type = {3} \n" +
                                         "ORDER BY 1,2,3,4 \n" +
                                         "WAITFOR DELAY '00:00:01' \n" +
                                         "INSERT INTO @SecondMeasure \n" +
                                         "SELECT [object_name], counter_name, instance_name, cntr_value, GETDATE() \n" +
                                         "FROM {2} \n" +
                                         "WHERE cntr_type = {3} \n" +
                                         "ORDER BY 1,2,3,4 \n" +
                                         "SELECT perf1.[object_name], perf1.counter_name, perf1.instance_name, perf1.cntr_type, \n" +
                                         "'value' = CASE perf1.cntr_type \n" +
                                         "          WHEN {0}    -- This counter is expressed  as a ratio and requires calculation.  \n" +
                                         "          THEN CONVERT(FLOAT, \n" +
                                         "perf1.cntr_value) / \n" +
                                         "(SELECT CASE perf2.cntr_value \n" +
                                         "WHEN 0 THEN 1 \n" +
                                         "ELSE perf2.cntr_value \n" +
                                         "END \n" +
                                         "FROM {2} perf2 \n" +
                                         "WHERE (perf1.counter_name + ' ' \n" +
                                         "= SUBSTRING(perf2.counter_name, 1, \n" +
                                         "PATINDEX('% Base%', perf2.counter_name))) \n" +
                                         "AND perf1.[object_name] = perf2.[object_name] \n" +
                                         "AND perf1.instance_name = perf2.instance_name \n" +
                                         "AND perf2.cntr_type in ({1})) \n" +
                                         "ELSE perf1.cntr_value  --Already calculated \n" +
                                         "END \n" +
                                         "FROM {2} perf1 \n" +
                                         "WHERE perf1.cntr_type not in ({1},{3}) -- Don't display the divisors and per second counters \n" +
                                         "UNION \n" +
                                         "SELECT m1.[object_name], m1.counter_name, m1.instance_name, {3} AS cntr_type, \n" +
                                         "((m2.cntr_value - m1.cntr_value)/datediff(ss,m1.captureTime,m2.captureTime)) AS cntr_value \n" +
                                         "FROM @FirstMeasure m1 INNER JOIN  \n" +
                                         "@SecondMeasure m2 ON m1.[object_name] = m2.[object_name] \n" +
                                         "        AND m1.counter_name = m2.counter_name \n" +
                                         "        AND m1.instance_name = m2.instance_name \n" +
                                         "ORDER BY 1,2,3,4";

                //0 - ratio counter
                //1 - divisor counter
                //2 - table
                //3 - per-second counter
                int _RatioCounter2005 = 537003264;
                int _DivisorCounter2005 = 1073939712;
                int _PerSecondCounter2005 = 272696576;
                string _CounterTable2005 = "sys.dm_os_performance_counters";
                int _RatioCounter2000 = 537003008;
                int _DivisorCounter2000 = 1073939459;
                int _PerSecondCounter2000 = 272696320;
                string _CounterTable2000 = "master..sysperfinfo";
                string _SqlCommand = string.Empty;

                if (SQLHelpers.Is2005orGreater(server.Information.Version.Major))
                {
                    _SqlCommand = string.Format(_PerfCounterSql, _RatioCounter2005, _DivisorCounter2005, _CounterTable2005, _PerSecondCounter2005);
                }
                else if (SQLHelpers.Is2000(server.Information.Version.Major))
                {
                    _SqlCommand = string.Format(_PerfCounterSql, _RatioCounter2000, _DivisorCounter2000, _CounterTable2000, _PerSecondCounter2000);
                }

                if (_SqlCommand.Length > 0)
                {
                    using (SqlCommand _Command = new SqlCommand(_SqlCommand, server.ConnectionContext.SqlConnectionObject))
                    {
                        using (SqlDataReader _Reader = _Command.ExecuteReader())
                        {
                            string _CurrentObjectName = null;
                            StatisticalData _ObjectChild = null;
                            Dictionary<string, StatisticalData> _DatabaseNodes = new Dictionary<string, StatisticalData>();
                            while (_Reader.Read())
                            {
                                if (_Reader.GetString(_Reader.GetOrdinal("object_name")) != _CurrentObjectName)
                                {
                                    if (_ObjectChild != null)
                                    {
                                        if (_DatabaseNodes.Count > 0)
                                        {
                                            _ObjectChild.Type = DataType.RawDataGroup;
                                            foreach (KeyValuePair<string, StatisticalData> _DatabaseNode in _DatabaseNodes)
                                            {
                                                _ObjectChild.ChildData.Add(_DatabaseNode.Value);
                                            }
                                            _DatabaseNodes.Clear();
                                        }
                                    }
                                    _CurrentObjectName = _Reader.GetString(_Reader.GetOrdinal("object_name"));

                                    _ObjectChild = new StatisticalData(_CurrentObjectName.Substring(_CurrentObjectName.IndexOf(":") + 1),
                                                PopulateCounterGroup, null, DataType.RawData,
                                                NodeIcon.PerformanceCounter);
                                    _ObjectChild.IsDataLoaded = true;
                                    _ObjectChild.DetailNames = new StatisticsHeader[] { "Name", StatisticsHeader.Double("Value") };
                                    data.AddChild(_ObjectChild);
                                }

                                DataValue<double> _Value = null;
                                if (!_Reader.IsDBNull(_Reader.GetOrdinal("value")))
                                {
                                    if (_Reader.GetInt32(_Reader.GetOrdinal("cntr_type")) == _RatioCounter2005 || _Reader.GetInt32(_Reader.GetOrdinal("cntr_type")) == _RatioCounter2000)
                                    {
                                        if (_Reader.GetDouble(_Reader.GetOrdinal("value")) > 1)
                                        {
                                            _Value = new DataValue<double>(100, "100%");
                                        }
                                        else
                                        {
                                            _Value = new DataValue<double>(_Reader.GetDouble(_Reader.GetOrdinal("value")), _Reader.GetDouble(_Reader.GetOrdinal("value")).ToString("P"));
                                        }
                                    }
                                    else
                                    {
                                        _Value = new DataValue<double>(_Reader.GetDouble(_Reader.GetOrdinal("value")));
                                    }
                                }

                                string _InstanceName = _Reader.GetString(_Reader.GetOrdinal("instance_name")).Trim();
                                if (_InstanceName == "_Total")
                                {
                                    _InstanceName = "Total";
                                }
                                if (string.IsNullOrEmpty(_InstanceName))
                                {
                                    _ObjectChild.AddRow(new object[] { _Reader.GetString(_Reader.GetOrdinal("counter_name")).Trim(), _Value });
                                }
                                else
                                {
                                    if (!_DatabaseNodes.ContainsKey(_InstanceName))
                                    {
                                        _DatabaseNodes.Add(_InstanceName, new StatisticalData(_InstanceName, PopulateInstanceCounter, null, DataType.RawData, NodeIcon.PerformanceCounter));
                                        _DatabaseNodes[_InstanceName].DetailNames = new StatisticsHeader[] { "Name", StatisticsHeader.Double("Value") };
                                    }
                                    _DatabaseNodes[_InstanceName].AddRow(new object[] { _Reader.GetString(_Reader.GetOrdinal("counter_name")).Trim(), _Value });
                                    _DatabaseNodes[_InstanceName].IsDataLoaded = true;

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                data.DataException = exc;
            }
        }

        private static void PopulateCounters(Server server, StatisticalData data)
        {
            try
            {
                string _CounterListSql = "SELECT [object_name], COUNT(1) AS CounterCount, \n" +
                                         "    (SELECT COUNT(DISTINCT instance_name) FROM {0} WHERE [object_name] = pc.[object_name] AND instance_name <> '') AS InstanceCount \n" +
                                         "FROM {0} pc \n" +
                                         "WHERE cntr_type <> {1} \n" +
                                         "GROUP BY [object_name] \n" +
                                         "ORDER BY 1";

                if (SQLHelpers.Is2005orGreater(server.Information.Version.Major))
                {
                    _CounterListSql = string.Format(_CounterListSql, _CounterTable2005, _DivisorCounter2005);
                }
                else if (SQLHelpers.Is2000(server.Information.Version.Major))
                {
                    _CounterListSql = string.Format(_CounterListSql, _CounterTable2000, _DivisorCounter2000);
                }
                else
                {
                    throw new NotSupportedException(ProductConstants.VersionNotSupported);
                }
                
                using (SqlCommand _Command = new SqlCommand(_CounterListSql, server.ConnectionContext.SqlConnectionObject))
                {
                    using (SqlDataReader _Reader = _Command.ExecuteReader())
                    {
                        while (_Reader.Read())
                        {
                            string _CounterObjectName = _Reader.GetString(_Reader.GetOrdinal("object_name")).Trim();
                            StatisticalData _ChildData = new StatisticalData(_CounterObjectName.Substring(_CounterObjectName.IndexOf(":") + 1),
                                PopulateCounterGroup, null, _Reader.GetInt32(_Reader.GetOrdinal("InstanceCount")) == 0 ? DataType.RawData : DataType.RawDataGroup,
                                NodeIcon.PerformanceCounter);
                            data.AddChild(_ChildData);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                data.DataException = exc;
            }
        }

        private static void PopulateCounterGroup(Server server, StatisticalData data)
        {
            try
            {
                GetCounterData(server, data, false);
            }
            catch (Exception exc)
            {
                data.DataException = exc;
            }
        }

        private static void PopulateInstanceCounter(Server server, StatisticalData data)
        {
            try
            {
                GetCounterData(server, data, true);
            }
            catch (Exception exc)
            {
                data.DataException = exc;
            }
        }

        private static void GetCounterData(Server server, StatisticalData data, bool isInstanceCounter)
        {
            string _PerfCounterSql = "DECLARE @FirstMeasure TABLE \n" +
                                         "(counter_name NCHAR(128), instance_name NCHAR(128), cntr_value BIGINT, captureTime DATETIME) \n" +
                                         "DECLARE @SecondMeasure TABLE \n" +
                                         "(counter_name NCHAR(128), instance_name NCHAR(128), cntr_value BIGINT, captureTime DATETIME) \n" +
                                         "INSERT INTO @FirstMeasure \n" +
                                         "SELECT counter_name, instance_name, cntr_value, GETDATE() \n" +
                                         "FROM {2} \n" +
                                         "WHERE [object_name] LIKE '%{4}%' \n" +
                                         "{5}" +
                                         "AND cntr_type = {3} \n" +
                                         "ORDER BY 1,2,3 \n" +
                                         "WAITFOR DELAY '00:00:01' \n" +
                                         "INSERT INTO @SecondMeasure \n" +
                                         "SELECT counter_name, instance_name, cntr_value, GETDATE() \n" +
                                         "FROM {2} \n" +
                                         "WHERE [object_name] LIKE '%{4}%' \n" +
                                         "{5}" +
                                         "AND cntr_type = {3} \n" +
                                         "ORDER BY 1,2,3 \n" +
                                         "SELECT perf1.counter_name, perf1.instance_name, perf1.cntr_type, \n" +
                                         "'value' = CASE perf1.cntr_type \n" +
                                         "          WHEN {0}    -- This counter is expressed  as a ratio and requires calculation.  \n" +
                                         "          THEN CONVERT(FLOAT, \n" +
                                         "perf1.cntr_value) / \n" +
                                         "(SELECT CASE perf2.cntr_value \n" +
                                         "WHEN 0 THEN 1 \n" +
                                         "ELSE perf2.cntr_value \n" +
                                         "END \n" +
                                         "FROM {2} perf2 \n" +
                                         "WHERE ([object_name] LIKE '%{4}%' \n" +
                                         "{5}" +
                                         "AND perf1.counter_name + ' ' \n" +
                                         "= SUBSTRING(perf2.counter_name, 1, \n" +
                                         "PATINDEX('% Base%', perf2.counter_name))) \n" +
                                         "AND perf1.[object_name] = perf2.[object_name] \n" +
                                         "AND perf1.instance_name = perf2.instance_name \n" +
                                         "AND perf2.cntr_type in ({1})) \n" +
                                         "ELSE perf1.cntr_value  --Already calculated \n" +
                                         "END \n" +
                                         "FROM {2} perf1 \n" +
                                         "WHERE [object_name] LIKE '%{4}%' \n" +
                                         "{5}" +
                                         "AND perf1.cntr_type not in ({1},{3}) -- Don't display the divisors and per second counters \n" +
                                         "UNION \n" +
                                         "SELECT m1.counter_name, m1.instance_name, {3} AS cntr_type, \n" +
                                         "((m2.cntr_value - m1.cntr_value)/datediff(ss,m1.captureTime,m2.captureTime)) AS cntr_value \n" +
                                         "FROM @FirstMeasure m1 INNER JOIN  \n" +
                                         "@SecondMeasure m2 ON m1.counter_name = m2.counter_name \n" +
                                         "        AND m1.instance_name = m2.instance_name \n" +
                                         "ORDER BY 1,2,3";

            //0 - ratio counter
            //1 - divisor counter
            //2 - table
            //3 - per-second counter
            //4 - counter object name
            //5 - instance clause

            string _InstanceClause = isInstanceCounter ? string.Format("AND instance_name = '{0}' \n", data.Name == "Total" ? "_Total" : data.Name) : string.Empty;
            string _ObjectName = isInstanceCounter ? data.Parent.Name : data.Name;

            if (SQLHelpers.Is2005orGreater(server.Information.Version.Major))
            {
                _PerfCounterSql = string.Format(_PerfCounterSql, _RatioCounter2005, _DivisorCounter2005, _CounterTable2005, _PerSecondCounter2005, _ObjectName, _InstanceClause);
            }
            else if (SQLHelpers.Is2000(server.Information.Version.Major))
            {
                _PerfCounterSql = string.Format(_PerfCounterSql, _RatioCounter2000, _DivisorCounter2000, _CounterTable2000, _PerSecondCounter2000, _ObjectName, _InstanceClause);
            }
            else
            {
                throw new NotSupportedException(ProductConstants.VersionNotSupported);
            }

            using (SqlCommand _Command = new SqlCommand(_PerfCounterSql, server.ConnectionContext.SqlConnectionObject))
            {
                using (SqlDataReader _Reader = _Command.ExecuteReader())
                {
                    if (data.Type == DataType.RawData)
                    {
                        data.DetailNames = new StatisticsHeader[] { "Name", StatisticsHeader.Double("Value") };
                        while (_Reader.Read())
                        {
                            DataValue<double> _Value = null;
                            if (!_Reader.IsDBNull(_Reader.GetOrdinal("value")))
                            {
                                if (_Reader.GetInt32(_Reader.GetOrdinal("cntr_type")) == _RatioCounter2005 || _Reader.GetInt32(_Reader.GetOrdinal("cntr_type")) == _RatioCounter2000)
                                {
                                    if (_Reader.GetDouble(_Reader.GetOrdinal("value")) > 1)
                                    {
                                        _Value = new DataValue<double>(100, "100%");
                                    }
                                    else
                                    {
                                        _Value = new DataValue<double>(_Reader.GetDouble(_Reader.GetOrdinal("value")), _Reader.GetDouble(_Reader.GetOrdinal("value")).ToString("P"));
                                    }
                                }
                                else
                                {
                                    _Value = new DataValue<double>(_Reader.GetDouble(_Reader.GetOrdinal("value")));
                                }
                            }
                            data.AddRow(new object[] { _Reader.GetString(_Reader.GetOrdinal("counter_name")).Trim(), _Value });
                        }
                    }
                    else
                    {
                        Dictionary<string, int> _CounterInstances = new Dictionary<string, int>();
                        while (_Reader.Read())
                        {
                            string _InstanceName = _Reader.GetString(_Reader.GetOrdinal("instance_name")).Trim();
                            if (_InstanceName == "_Total")
                            {
                                _InstanceName = "Total";
                            }
                            if (!_CounterInstances.ContainsKey(_InstanceName))
                            {
                                _CounterInstances.Add(_InstanceName, 0);
                            }
                            _CounterInstances[_InstanceName]++;
                        }
                        foreach (KeyValuePair<string, int> _InstanceCount in _CounterInstances)
                        {
                            StatisticalData _ChildData = new StatisticalData(_InstanceCount.Key, PopulateInstanceCounter, null, DataType.RawData, NodeIcon.PerformanceCounter);
                            data.AddChild(_ChildData);
                        }
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Groups statistics by the specified row column
        /// </summary>
        private static void AddDataGrouping(StatisticalData data, string columnName, NodeIcon deatailIconImage)
        {
            try
            {
                SortedDictionary<string, StatisticalData> _GroupedValues = new SortedDictionary<string, StatisticalData>();
                foreach (DataRow _Row in data.Parent.Values.Rows)
                {
                    string _DataValue = _Row[columnName].ToString();
                    if (_DataValue.Trim().Length == 0)
                    {
                        continue;
                    }
                    if (!_GroupedValues.ContainsKey(_DataValue))
                    {
                        StatisticalData _GroupedData = new StatisticalData(_DataValue, data.Parent.DetailNames);
                        _GroupedData.IconImage = data.Parent.IconImage;
                        _GroupedData.DetailIconImage = deatailIconImage;
                        _GroupedData.IsDataLoaded = true;
                        _GroupedValues.Add(_DataValue, _GroupedData);
                    }
                    _GroupedValues[_DataValue].Values.ImportRow(_Row);
                }

                foreach (KeyValuePair<string, StatisticalData> _Item in _GroupedValues)
                {
                    _Item.Value.ItemCount = _Item.Value.Values.Rows.Count;
                    data.ChildData.Add(_Item.Value);
                }
            }
            catch(Exception exc)
            {
                data.DataException = exc;
            }
        }

        /// <summary>
        /// Copies the values of a DataTable onto the specified StatisticalData object.        
        /// </summary>
        private static void AddDataFromTable(StatisticalData data, DataTable table)
        {
            StatisticsHeader[] _Header = new StatisticsHeader[table.Columns.Count];
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (table.Columns[i].DataType == typeof(int))
                {
                    _Header[i] = StatisticsHeader.Int(table.Columns[i].ColumnName);
                }
                else if (table.Columns[i].DataType == typeof(double))
                {
                    _Header[i] = StatisticsHeader.Double(table.Columns[i].ColumnName);                    
                }
                else if (table.Columns[i].DataType == typeof(DateTime))
                {
                    _Header[i] = StatisticsHeader.Date(table.Columns[i].ColumnName);
                }
                else
                {
                    _Header[i] = table.Columns[i].ColumnName;
                }
            }
            data.DetailNames = _Header;
            
            foreach (DataRow _Row in table.Rows)
            {
                data.AddRow(_Row.ItemArray);
            }
        }

        /// <summary>
        /// Copies the values from an errorlogs (EnumErrorLogs()) DataTable onto the specified StatisticalData object.        
        /// </summary>
        private static void AddDataFromErrorLogs(StatisticalData data, DataTable logTable)
        {
            data.DetailNames = new StatisticsHeader[]{StatisticsHeader.IntCenter("Archive Number"),
                                                    StatisticsHeader.Date("Create Date"), StatisticsHeader.Int("Log Size")};

            foreach (DataRow _Row in logTable.Rows)
            {
                data.AddRow(new object[] { _Row[2], _Row[3], new DataValue<int>((int)_Row[4], Helpers.StrFormatByteSize((long)(int)_Row[4])) });
            }
        }

        #endregion

        /// <summary>
        /// Returns a date string if the date is not MinValue, otherwise null.
        /// </summary>
        private static string GetFormattedDate(DateTime date)
        {
            return (date == DateTime.MinValue) ? null : date.ToString();
        }
    }
}
