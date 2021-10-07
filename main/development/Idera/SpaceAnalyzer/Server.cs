using System;
using System.Collections.Generic;
using System.Text;

using Idera.SqlAdminToolset.Core;
using System.Data.SqlClient;
using System.Management;

namespace Idera.SqlAdminToolset.SpaceAnalyzer
{
    public class Server
    {
        private List<Database> _databases;
        private Dictionary<string, DiskRecord> _disks;
        private Dictionary<string, string> _errorReports;
        private string _serverName;
        private SQLCredentials _sqlCredentials;
        private ServerVersionType _serverVersion;
        private EngineEdition _engineEdition;
        private string _computer;
        private static SqlCommand _cmd = null;

        public string _userNameForWMI = string.Empty;
        public string _passwordForWMI = string.Empty;

        public delegate void DelegateGetWMICredentials(string server, bool cachedOnly, ref string userName, ref string password);
        public DelegateGetWMICredentials m_DelegateGetWMICredentials = null;

        public Form_Main.DelegateGetWMICredentials m_MainFormDelegateGetWMICredentials = null;

        public Server(string serverName, SQLCredentials sqlCredentials)
        {
            _serverName = serverName;
            _sqlCredentials = sqlCredentials;
            _databases = new List<Database>();
            _errorReports = new Dictionary<string, string>();
        }

        public static void Cancel()
        {
            if (_cmd != null)
            {
                _cmd.Cancel();
            }
            Database.Cancel();
        }
        public string ServerName
        {
            get { return _serverName; }
        }
        public ServerVersionType ServerVersion
        {
            get { return _serverVersion; }
        }
        public EngineEdition EngineEdition
        {
            get { return _engineEdition; }
        }
        public Dictionary<string, string> ErrorReports
        {
            get { return _errorReports; }
        }

        public bool Is2000
        {
            get { return _serverVersion == ServerVersionType.SQL2000; }
        }

        public bool Is2005
        {
            get { return _serverVersion == ServerVersionType.SQL2005; }
        }

        public List<Database> Databases
        {
            get { return _databases; }
        }
        public List<FileRecord> Files
        {
            get
            {
                List<FileRecord> files = new List<FileRecord>();
                foreach (Database d in _databases)
                {
                    files.AddRange(d.Files);
                }
                return files;
            }
        }
        public Dictionary<string, DiskRecord> Disks
        {
            get { return _disks; }
        }

        public int NumberFiles
        {
            get
            {
                int count = 0;
                foreach (Database d in _databases)
                {
                    count += d.Files.Count;
                }
                return count;
            }
        }
        public int NumberDisks
        {
            get { return _disks.Count; }
        }

        public int NumberCriticalDisks
        {
            get
            {
                int count = 0;
                foreach (KeyValuePair<string, DiskRecord> kvp in _disks)
                {
                    DiskRecord d = kvp.Value;
                    if (d.DiskPercentUsed >= ProductConstants.CriticalPercentUsed)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        public int NumberCautionDisks
        {
            get
            {
                int count = 0;
                foreach (KeyValuePair<string, DiskRecord> kvp in _disks)
                {
                    DiskRecord d = kvp.Value;
                    if (d.DiskPercentUsed < ProductConstants.CriticalPercentUsed && d.DiskPercentUsed > ProductConstants.AcceptablePercentUsed)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        public int NumberAcceptableDisks
        {
            get
            {
                int count = 0;
                foreach (KeyValuePair<string, DiskRecord> kvp in _disks)
                {
                    DiskRecord d = kvp.Value;
                    if (d.DiskPercentUsed <= ProductConstants.AcceptablePercentUsed)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public List<FileRecord> GetFilesForDisk(string diskName)
        {
            List<FileRecord> files = new List<FileRecord>();
            foreach (Database d in _databases)
            {
                files.AddRange(d.GetFilesForDisk(diskName));
            }
            return files;
        }

        public bool LoadFiles(Form_Main.DelegateUpdateProgressBar updateTextDelegate,
                              Form_Main.DelegateGetWMICredentials getWMICredentials)
        {
            bool retVal = true;
            using (CoreGlobals.traceLog.InfoCall())
            {
                m_MainFormDelegateGetWMICredentials = getWMICredentials;
                m_DelegateGetWMICredentials = GetWMICredentials;
                try
                {
                    retVal = GetDatabases();
                    GetDiskSpace();

                    if (retVal)
                    {
                        foreach (Database database in _databases)
                        {
                            if (ProductConstants.globalCancelRequested)
                            {
                                ProductConstants.globalOperationCancelled = true;
                                break;
                            }
                            updateTextDelegate("Loading files for database...", string.Format("{0}", database.DatabaseName));
                            database.GetFiles(updateTextDelegate, ref _disks, ref _errorReports, m_DelegateGetWMICredentials);
                        }
                    }
                    else
                    {
                        CoreGlobals.traceLog.InfoFormat("LoadFiles - GetDatabases didnt return any databases - retval={0}",
                                                         retVal);
                    }
                }
                catch (Exception ex)
                {
                    _errorReports.Add("Error loading space information", Helpers.GetCombinedExceptionText(ex));

                    CoreGlobals.traceLog.InfoFormat("Error loading space information {0}",
                                                     Helpers.GetCombinedExceptionText(ex));
                }
            }

            return retVal;
        }

        public bool GetDatabases()
        {
            bool retVal = true;
            _engineEdition = EngineEdition.Unknown;
            _serverVersion = ServerVersionType.Unknown;
            _computer = string.Empty;
            
         using (CoreGlobals.traceLog.InfoCall())
         {
            try
            {
                using (SqlConnection conn = new SqlConnection(Connection.CreateConnectionString(_serverName, string.Empty, _sqlCredentials)))
                {
                        Connection.Impersonate(_sqlCredentials);
                        conn.Open();

                        string query = "SELECT SERVERPROPERTY('EngineEdition')";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.CommandTimeout = ToolsetOptions.commandTimeout;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    _engineEdition = (SpaceAnalyzer.EngineEdition)reader[0];
                                }
                            }
                        }

                        if (SQLHelpers.Is2000(conn))
                        {
                            _serverVersion = ServerVersionType.SQL2000;
                        }
                        else if (SQLHelpers.Is2005(conn))
                        {
                            _serverVersion = ServerVersionType.SQL2005;
                        }
                        else if (SQLHelpers.Is2008(conn))
                        {
                            _serverVersion = ServerVersionType.SQL2008;
                        }
                        if (SQLHelpers.Is2012(conn))
                        {
                            _serverVersion = ServerVersionType.SQL2012;
                        }
                        else if (SQLHelpers.Is2014(conn))
                        {
                            _serverVersion = ServerVersionType.SQL2014;
                        }
                        else if (SQLHelpers.Is2016(conn))
                        {
                            _serverVersion = ServerVersionType.SQL2016;
                        }
                        else if (SQLHelpers.Is2017(conn))
                        {
                            _serverVersion = ServerVersionType.SQL2017;
                        }


                        query = "select ServerProperty('MachineName')";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.CommandTimeout = ToolsetOptions.commandTimeout;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    _computer = (string)reader[0];
                                }
                            }
                        }

                        query = "select name,dbid,cmptlevel from master..sysdatabases WHERE has_dbaccess(name) = 1 ORDER BY name ASC";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.CommandTimeout = ToolsetOptions.commandTimeout;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Database db = new Database();
                                    int count = 0;
                                    db.DatabaseName = SQLHelpers.GetString(reader, count++);
                                    db.Id = SQLHelpers.GetInt16(reader, count++);
                                    //if (db.Id >= 1 && db.Id <= 4)
                                    //{
                                    //    // model, msdb, temp, master use 1 - 4
                                    //    continue;
                                    //}
                                    int compat = SQLHelpers.ByteToInt(reader, count++);
                                    if (compat < 80)
                                    {
                                        //                                    logX.WarnFormat("Database {0} has an unsupported compatability level: {1}\nSkipping this database.", db.Name, compat);
                                        continue;
                                    }
                                    db.ServerName = _serverName;
                                    db.ServerVersion = _serverVersion;
                                    db.EngineEdition = _engineEdition;
                                    db.ComputerName = _computer;
                                    db.SqlCredentials = _sqlCredentials;
                                    _databases.Add(db);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _errorReports.Add("Error loading databases", Helpers.GetCombinedExceptionText(ex));

                    CoreGlobals.traceLog.InfoFormat("Error loading databases {0}",
                                                     Helpers.GetCombinedExceptionText(ex));
                }
            }
            return retVal;
        }

        /// <summary>
        /// Retrieves all disks and their space, including mount points.
        /// </summary>
        /// <param name="errorReports"></param>
        /// <param name="getWMICredentials"></param>
        private void GetDiskSpace()
        {
            using (CoreGlobals.traceLog.InfoCall())
            {
                try
                {
                    _disks = new Dictionary<string, DiskRecord>();
                    StringBuilder scopeStr = null;
                    scopeStr = new StringBuilder();
                    scopeStr.Append(@"\\" + _computer);
                    scopeStr.Append(ProductConstants.Cimv2Root);
                    // Create management scope and connect.
                    ConnectionOptions options = new ConnectionOptions();
                    string userName = string.Empty;
                    string password = string.Empty;
                    m_DelegateGetWMICredentials(_computer, true, ref userName, ref password);
                    if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
                    {
                        options.Username = userName;
                        options.Password = password;
                    }
                    ManagementScope scope = new ManagementScope(scopeStr.ToString(), options);
                    try
                    {
                        scope.Connect();
                    }
                    catch
                    {
                        m_DelegateGetWMICredentials(_computer, false, ref userName, ref password);
                        options.Username = userName;
                        options.Password = password;
                        scope = new ManagementScope(scopeStr.ToString(), options);
                        try
                        {
                            scope.Connect();
                        }
                        catch (Exception ex1)
                        {
                            _errorReports.Add(string.Format("Error connection to WMI on computer {0}", _computer), ex1.Message);

                            CoreGlobals.traceLog.InfoFormat("Error connection to WMI on computer {0} - {1}",
                                                             _computer,
                                                             ex1.Message);

                            return;
                        }
                    }

                    if (ProductConstants.globalCancelRequested)
                    {
                        ProductConstants.globalOperationCancelled = true;
                        return;
                    }

                    string queryString = "SELECT DeviceID, FileSystem, Size, FreeSpace, VolumeName, DriveType FROM Win32_LogicalDisk";
                    SelectQuery query = new SelectQuery(queryString);
                    using (
                        ManagementObjectSearcher searcher =
                            new ManagementObjectSearcher(scope, query))
                    {
                        foreach (ManagementObject disk in searcher.Get())
                        {
                            if (ProductConstants.globalCancelRequested)
                            {
                                ProductConstants.globalOperationCancelled = true;
                                return;
                            }

                            DiskRecord diskRecord = null;
                            if (disk["Size"] == null)
                            {
                                diskRecord = LoadDiskRecord((string)disk["DeviceID"], (string)disk["FileSystem"],
                                                    (string)disk["VolumeName"]);
                            }
                            else
                            {
                                diskRecord = LoadDiskRecord((string)disk["DeviceID"], (string)disk["FileSystem"],
                                                    (string)disk["VolumeName"], (ulong)disk["Size"], (ulong)disk["FreeSpace"]);
                            }
                            diskRecord.DriveType = GetDriveTypeCaption((uint)disk["DriveType"]);

                            if (!_disks.ContainsKey(diskRecord.DriveLetter))
                            {
                                _disks.Add(diskRecord.DriveLetter, diskRecord);
                            }
                        }
                    }

                    //Mount points
                    try
                    {
                        queryString = "SELECT Name, FileSystem, Capacity, FreeSpace, Label, DriveType FROM Win32_volume WHERE DriveLetter IS NULL";
                        query = new SelectQuery(queryString);
                        using (
                            ManagementObjectSearcher searcher =
                                new ManagementObjectSearcher(scope, query))
                        {
                            foreach (ManagementObject mountPoint in searcher.Get())
                            {
                                if (ProductConstants.globalCancelRequested)
                                {
                                    ProductConstants.globalOperationCancelled = true;
                                    return;
                                }

                                DiskRecord diskRecord = null;
                                if (mountPoint["Capacity"] == null)
                                {
                                    diskRecord = LoadDiskRecord((string)mountPoint["Name"], (string)mountPoint["FileSystem"],
                                                        (string)mountPoint["Label"]);
                                }
                                else
                                {
                                    diskRecord = LoadDiskRecord((string)mountPoint["Name"], (string)mountPoint["FileSystem"],
                                                        (string)mountPoint["Label"], (ulong)mountPoint["Capacity"], (ulong)mountPoint["FreeSpace"]);
                                }
                                diskRecord.DriveType = "Mount Point";

                                if (!_disks.ContainsKey(diskRecord.DriveLetter))
                                {
                                    _disks.Add(diskRecord.DriveLetter, diskRecord);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        CoreGlobals.traceLog.InfoFormat("Error loading mount points on {0}: {1}",
                                                         _computer,
                                                         ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    _errorReports.Add(string.Format("Error getting Drive Space for {0}", _computer), ex.Message);

                    CoreGlobals.traceLog.InfoFormat("Error getting Drive Space for {0}: {1}",
                                                     _computer,
                                                     ex.Message);
                }
            }
        }

        /// <summary>
        /// Loads a DiskRecord object with the specified values.
        /// </summary>
        private DiskRecord LoadDiskRecord(string driveLetter, string fileSystem, string volumeName)
        {
            return LoadDiskRecord(driveLetter, fileSystem, volumeName, ulong.MinValue, ulong.MinValue);
        }

        /// <summary>
        /// Loads a DiskRecord object with the specified values, including disk usage data.
        /// </summary>
        private DiskRecord LoadDiskRecord(string driveLetter, string fileSystem, string volumeName, ulong diskSize, ulong freeSpace)
        {
            DiskRecord diskRecord = new DiskRecord();
            diskRecord.ComputerName = _computer;

            diskRecord.DriveLetter = driveLetter;
            diskRecord.DriveOS = fileSystem;
            if (diskSize > ulong.MinValue)
            {
                diskRecord.DiskSize = diskSize;
                diskRecord.DiskFreeSpace = freeSpace;
                diskRecord.DiskUsedSize = diskRecord.DiskSize - diskRecord.DiskFreeSpace;
                diskRecord.DiskPercentUsed = (double)diskRecord.DiskUsedSize / diskRecord.DiskSize;
                diskRecord.DiskPercentFree = (double)diskRecord.DiskFreeSpace / diskRecord.DiskSize;
            }
            diskRecord.VolumeName = volumeName;
            return diskRecord;
        }

        /// <summary>
        /// Returns the drive type caption for the specified id.
        /// </summary>
        internal static string GetDriveTypeCaption(uint driveType)
        {
            switch (driveType)
            {
                case 1:
                    return "No Root Directory";
                case 2:
                    return "Removable Disk";
                case 3:
                    return "Local Disk";
                case 4:
                    return "Network Drive";
                case 5:
                    return "Compact Disc";
                case 6:
                    return "RAM Disk";
                case 0:
                default:
                    return "Unknown";
            }

        }


        public void GetWMICredentials(string server, bool cachedOnly, ref string userName, ref string password)
        {
            if (!cachedOnly && (string.IsNullOrEmpty(_userNameForWMI) || string.IsNullOrEmpty(_passwordForWMI)))
            {
                m_MainFormDelegateGetWMICredentials(server);
                _userNameForWMI = ProductConstants.globalWMIUser;
                _passwordForWMI = ProductConstants.globalWMIPassword;
            }

            userName = _userNameForWMI;
            password = _passwordForWMI;
        }


    }
}
