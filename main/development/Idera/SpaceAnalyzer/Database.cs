using System;
using System.Collections.Generic;
using System.Text;
using System.Management;


using Idera.SqlAdminToolset.Core;
using System.Data.SqlClient;

namespace Idera.SqlAdminToolset.SpaceAnalyzer
{
    public class Database : FileRecord
    {
        private List<FileRecord> _files;

        private static SqlCommand cmd = null;

        public static void Cancel()
        {
            if (cmd != null)
            {
                cmd.Cancel();
            }
        }

        public List<FileRecord> Files
        {
            get { return _files; }
        }



        public int NumberFiles
        {
            get { return _files.Count; }
        }


        public int NumberDatabaseFiles
        {
            get
            {
                int count = 0;
                foreach (FileRecord f in _files)
                {
                    if (f.Type == FileType.Data)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        public int NumberLogFiles
        {
            get
            {
                int count = 0;
                foreach (FileRecord f in _files)
                {
                    if (f.Type == FileType.Log)
                    {
                        count++;
                    }
                }
                return count;
            }
        }


        public Database()
        {
            _files = new List<FileRecord>();

        }

        public bool GetFiles(Form_Main.DelegateUpdateProgressBar updateTextDelegate,
                             ref Dictionary<string, DiskRecord> diskDict,
                             ref Dictionary<string, string> errorReports,
                            Server.DelegateGetWMICredentials getWMICredentials)
        {
            bool RetVal = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(Connection.CreateConnectionString(ServerName, string.Empty, SqlCredentials)))
                {
                    Connection.Impersonate(SqlCredentials);

                    conn.Open();
                    string queryColumns = string.Empty;
                    string query = string.Empty;
                    string driveLetter = string.Empty;


                    if (ServerVersion == ServerVersionType.SQL2000)
                    {
                        query = String.Format("USE {0}"
                                            + "select CAST(fileid as int), "
                                            + "CAST(CASE f.status & 0x40 WHEN 0x40 THEN 1 ELSE 0 END AS tinyint) AS [type], "
                                            + "name, "
                                            + "filename, "
                                            + "groupname, size, "
                                            + "usedsize = fileproperty(name,'SpaceUsed'), "
                                            + "maxsize, growth, "
                                            + "CAST(CASE f.status & 0x100000 WHEN 0x100000 THEN 1 ELSE 0 END AS bit) AS [is_percent_growth] "
                                            + "from dbo.sysfiles f "
                                            + "left join dbo.sysfilegroups g on f.groupid = g.groupid",
                                                    SQLHelpers.CreateSafeDatabaseName(DatabaseName));

                    }
                    else
                    {
                        query =
                            String.Format("USE {0} "
                                          + "select "
                                            + "file_id, "
                                            + "type, "
                                            + "name, "
                                            + "physical_name, "
                                            + "groupname, "
                                            + "size, "
                                            + "usedsize = fileproperty(name,'SpaceUsed'), "
                                            + "max_size, "
                                            + "growth, "
                                            + "is_percent_growth "
                                          + "from sys.database_files f "
                                          + "left join dbo.sysfilegroups g on f.data_space_id = g.groupid",
                                       SQLHelpers.CreateSafeDatabaseName(DatabaseName));
                    }

                    using (cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = ToolsetOptions.commandTimeout * 3;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                FileRecord file = new FileRecord();
                                int count = 0;
                                file.Id = SQLHelpers.GetInt32(reader, count++);
                                file.Type = (FileType)SQLHelpers.ByteToInt(reader, count++);
                                if (Convert.ToInt32(file.Type) == 2)
                                {
                                    file.Type = FileType.Data;
                                }
                                file.LogicalName = SQLHelpers.GetString(reader, count++).Trim();
                                file.FullPathName = SQLHelpers.GetString(reader, count++).Trim();
                                updateTextDelegate("Adding Files...", string.Format("\\{0}  {1}", ComputerName, file.LogicalName));
                                file.FileGroup = SQLHelpers.GetString(reader, count++);
                                if (string.IsNullOrEmpty(file.FileGroup))
                                {
                                    file.FileGroup = "n/a";
                                }
                                file.Size = (long)(SQLHelpers.GetInt32(reader, count++)) * (long)ProductConstants.FilePageSize * (long)ProductConstants.ByteConversionValue;
                                file.UsedSize = (long)(SQLHelpers.GetInt32(reader, count++)) * (long)ProductConstants.FilePageSize * (long)ProductConstants.ByteConversionValue;
                                file.PercentUsed = file.Size == 0 ? -1.0 : (double)file.UsedSize / file.Size;
                                int maxsize = SQLHelpers.GetInt32(reader, count++);
                                if (maxsize == -1)
                                {
                                    file.MaxSize = "Unrestricted growth";
                                }
                                else if (maxsize == 268435456)
                                {
                                    file.MaxSize = string.Format("Limited to 2 TB");
                                }
                                else
                                {
                                    file.MaxSize = string.Format("Limited to {0}", Helpers.StrFormatByteSize(maxsize * ProductConstants.FilePageSize));
                                }
                                int growth = SQLHelpers.GetInt32(reader, count++);
                                file.IsGrowthPercent = SQLHelpers.GetBool(reader, count++);
                                if (growth == 0)
                                {
                                    file.AutoGrowth = "Fixed size";
                                }
                                else if (file.IsGrowthPercent)
                                {
                                    file.AutoGrowth = string.Format("Grows by {0}%", growth);
                                }
                                else
                                {
                                    //file.AutoGrowth = string.Format("Grows by {0}", Helpers.StrFormatByteSize(growth * ProductConstants.FilePageSize));

                                    //file.AutoGrowth = string.Format("Grows by {0} MB", ConvertKilobytesToMegabytes(growth * ProductConstants.FilePageSize));

                                    string objval = convertbytesToMB.ToFileSize(growth * ProductConstants.FilePageSize * ProductConstants.ByteConversionValue);
                                    if (objval == "1,024 KB")
                                    {
                                        file.AutoGrowth = string.Format("Grows by 1 MB");
                                    }
                                    else
                                    {
                                        file.AutoGrowth = string.Format("Grows by {0}", objval);
                                    }
                                }

                                file.ComputerName = ComputerName;
                                file.ServerVersion = ServerVersion;
                                file.EngineEdition = EngineEdition;
                                file.ServerName = ServerName;
                                file.DatabaseId = DatabaseId;
                                file.DatabaseName = DatabaseName;

                                driveLetter = GetDiskFromPath(file.FullPathName);
                                if (!diskDict.ContainsKey(driveLetter))
                                {
                                    //in case something failed when gathering all drives.
                                    DiskRecord dr1 = GetDiskSpace(driveLetter, ref errorReports, getWMICredentials);
                                    if (dr1 != null)
                                    {
                                        diskDict.Add(driveLetter, dr1);
                                    }
                                }

                                //find the drive or mount point that matches the file's path
                                DiskRecord dr = null;
                                foreach (string drivePath in diskDict.Keys)
                                {
                                    if (file.FullPathName.ToUpperInvariant().StartsWith(drivePath.ToUpperInvariant()) && (dr == null || drivePath.Length > dr.DriveLetter.Length))
                                    {
                                        dr = diskDict[drivePath];
                                    }
                                }

                                if (dr != null)
                                {
                                    file.DiskPercentUsed = dr.DiskPercentUsed;
                                    file.DiskPercentFree = dr.DiskPercentFree;
                                    file.DiskFreeSpace = dr.DiskFreeSpace;
                                    file.DiskSize = dr.DiskSize;
                                    file.DiskUsedSize = dr.DiskUsedSize;
                                    file.PercentUsedRelativeToDisk = dr.DiskSize == 0 ? -1.0 : (double)file.Size / dr.DiskSize;
                                    file.DriveLetter = dr.DriveLetter;
                                    file.DriveOS = dr.DriveOS;
                                    file.DriveType = dr.DriveType;
                                    file.VolumeName = dr.VolumeName;

                                    dr.ContainsDatabases = true;
                                }

                                _files.Add(file);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorReports.Add(string.Format("Error loading files for database {0}", DatabaseName),
                        Helpers.GetCombinedExceptionText(ex));
            }

            return RetVal;
        }



        static double ConvertKilobytesToMegabytes(long kilobytes)
        {
            return kilobytes / 1024f;
        }




        private string ConvertLocalPathToUNCPath(string path)
        {
            string UNCPath = path;
            if (path[1] == ':')
            {
                UNCPath = string.Format(@"\\{0}\{1}${2}", ComputerName, path[0], path.Substring(2));
            }
            return UNCPath;
        }

        private string GetDiskFromPath(string path)
        {
            string drive = string.Empty;
            if (path[1] == ':')
            {
                drive = path[0].ToString().ToUpper() + ":";
            }
            return drive;
        }

        private DiskRecord GetDiskSpace(string drive, ref Dictionary<string, string> errorReports, Server.DelegateGetWMICredentials getWMICredentials)
        {
            DiskRecord diskRecord = new DiskRecord();
            diskRecord.ComputerName = ComputerName;
            diskRecord.DriveLetter = drive;

            try
            {
                StringBuilder scopeStr = null;
                scopeStr = new StringBuilder();
                scopeStr.Append(@"\\" + ComputerName);
                scopeStr.Append(ProductConstants.Cimv2Root);
                // Create management scope and connect.
                ConnectionOptions options = new ConnectionOptions();
                string userName = string.Empty;
                string password = string.Empty;
                getWMICredentials(ComputerName, true, ref userName, ref password);
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

                    getWMICredentials(ComputerName, false, ref userName, ref password);
                    options.Username = userName;
                    options.Password = password;
                    scope = new ManagementScope(scopeStr.ToString(), options);
                    try
                    {
                        scope.Connect();
                    }
                    catch (Exception ex1)
                    {
                        string errorMessage = string.Format("Error connection to WMI on computer {0}", ComputerName);
                        if (!errorReports.ContainsKey(errorMessage))
                        {
                            errorReports.Add(errorMessage, ex1.Message);
                        }
                        return diskRecord;

                    }
                }
                string queryString = string.Format(
                    "SELECT FileSystem, Size, FreeSpace, VolumeName, DriveType FROM Win32_LogicalDisk where DeviceID = '{0}'", drive);
                SelectQuery query = new SelectQuery(queryString);
                using (
                    ManagementObjectSearcher searcher =
                        new ManagementObjectSearcher(scope, query))
                {
                    foreach (ManagementObject disk in searcher.Get())
                    {
                        diskRecord.DriveOS = (string)disk["FileSystem"];
                        diskRecord.DiskSize = (ulong)disk["Size"];
                        diskRecord.DiskFreeSpace = (ulong)disk["FreeSpace"];
                        diskRecord.DiskUsedSize = diskRecord.DiskSize - diskRecord.DiskFreeSpace;
                        diskRecord.DiskPercentUsed = (double)diskRecord.DiskUsedSize / diskRecord.DiskSize;
                        diskRecord.DiskPercentFree = (double)diskRecord.DiskFreeSpace / diskRecord.DiskSize;
                        diskRecord.VolumeName = (string)disk["VolumeName"];
                        diskRecord.DriveType = Server.GetDriveTypeCaption((uint)disk["DriveType"]);
                    }
                }
            }
            catch (Exception ex)
            {
                errorReports.Add(string.Format("Error getting Drive Space for {0}", drive), ex.Message);
            }

            return diskRecord;
        }

        public List<FileRecord> GetFilesForDisk(string driveLetter)
        {
            List<FileRecord> files = new List<FileRecord>();
            foreach (FileRecord f in _files)
            {
                if (f.DriveLetter == driveLetter)
                {
                    files.Add(f);
                }
            }
            return files;
        }

    }
}
public static class convertbytesToMB
{
    public static string ToFileSize(this double value)
    {
        string[] suffixes = { "bytes", "KB", "MB", "GB",
        "TB", "PB", "EB", "ZB", "YB"};
        for (int i = 0; i < suffixes.Length; i++)
        {
            if (value <= (Math.Pow(1024, i + 1)))
            {
                return ThreeNonZeroDigits(value /
                    Math.Pow(1024, i)) +
                    " " + suffixes[i];
            }
        }

        return ThreeNonZeroDigits(value /
            Math.Pow(1024, suffixes.Length - 1)) +
            " " + suffixes[suffixes.Length - 1];
    }

    private static string ThreeNonZeroDigits(double value)
    {
        if (value >= 100)
        {
            // No digits after the decimal.
            return value.ToString("0,0");
        }
        else if (value >= 10)
        {
            // One digit after the decimal.
            return value.ToString("0.0");
        }
        else
        {
            // Two digits after the decimal.
            return value.ToString("0.00");
        }
    }
}