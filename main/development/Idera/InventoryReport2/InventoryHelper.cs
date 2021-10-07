using System;
using System.Collections.Generic;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Management;
using System.Data.SqlClient;
using Idera.SqlAdminToolset.Core;
using System.Xml;
using System.Text.RegularExpressions;

namespace Idera.SqlAdminToolset.InventoryReport
{

    internal class InventoryHelper
    {
        private static object threadLock = new object();

        /// <summary>
        /// Gathers data to populate the InventoryData object.
        /// </summary>
        public static InventoryData HarvestData(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
            string wmiErrMsg = "";
            lock (threadLock)
            {
                try
                {
                    using (SqlConnection _Connection = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials))
                    {
                        Server _Server = new Server(new ServerConnection(_Connection));

                        InventoryData _InventoryData = new InventoryData(InventoryData.InventoryType.LiveData);
                        lock (options)
                        {
                            _InventoryData.serverName = _Server.Name;
                            _InventoryData.hostComputer = _Server.Information.NetName;
                            _InventoryData.reportDate = DateTime.Now;
                            _InventoryData.lastStartDate = SQLHelpers.GetServerStartDate(_Connection);

                            //cancel point
                            if (options.CancelRequested)
                            {
                                return _InventoryData;
                            }

                            try
                            {
                                CoreGlobals.traceLog.VerboseFormat("NetName: {0}", _Server.Information.NetName);

                                string wmiPath = String.Format(@"\\{0}\root\cimv2", _Server.Information.NetName);

                                CoreGlobals.traceLog.VerboseFormat("wmiPath: {0}", wmiPath);

                                ManagementScope _WMI = new ManagementScope(wmiPath);
                                _WMI.Connect();

                                CoreGlobals.traceLog.Verbose("WMI Connected");

                                //cancel point
                                if (options.CancelRequested)
                                {
                                    return _InventoryData;
                                }

                                string _ComputerSystemQuery = string.Empty;
                                bool _IncludeWorkGroupInfo = true;

                                //Win2K and below don't suppor the PartOfDomain and Workgroup properties
                                if (_Server.Information.OSVersion.Substring(0, 1) == "4" ||  //Windows NT
                                   _Server.Information.OSVersion.Substring(0, 3) == "5.0") //Windows 2000
                                {
                                    _ComputerSystemQuery = "SELECT Manufacturer, Domain, NumberOfProcessors FROM Win32_ComputerSystem";
                                    _IncludeWorkGroupInfo = false;
                                }
                                else
                                {
                                    _ComputerSystemQuery = "SELECT Manufacturer, Domain, Workgroup, PartOfDomain, NumberOfProcessors FROM Win32_ComputerSystem";
                                }

                                using (ManagementObjectSearcher _WmiSearcher = new ManagementObjectSearcher(_WMI,
                                                   new ObjectQuery(_ComputerSystemQuery)))
                                using (ManagementObjectCollection _WmiObjectCollection = _WmiSearcher.Get())
                                {
                                    CoreGlobals.traceLog.Verbose("Enumerating Win32_ComputerSystem");

                                    foreach (ManagementObject oReturn in _WmiObjectCollection)
                                    {
                                        _InventoryData.manufacturer = WmiHelpers.GetString(oReturn, "Manufacturer");

                                        bool partOfDomain = _IncludeWorkGroupInfo ? WmiHelpers.GetBool(oReturn, "PartOfDomain") : true;

                                        if (partOfDomain)
                                        {
                                            _InventoryData.domainWorkgroup = WmiHelpers.GetString(oReturn, "Domain");
                                            _InventoryData.domainOrWorkgroup = _IncludeWorkGroupInfo ? "Domain" : "N/A";
                                        }
                                        else //will skip this section for Win2k and below
                                        {
                                            if (oReturn["Workgroup"] == null && oReturn["Domain"] == null) //Note  If the computer is not part of a domain, then the name of the workgroup is returned.
                                            {
                                                _InventoryData.domainWorkgroup = "";
                                                _InventoryData.domainOrWorkgroup = "";
                                            }
                                            else
                                            {
                                                if (oReturn["Workgroup"] != null)
                                                {
                                                    _InventoryData.domainWorkgroup = WmiHelpers.GetString(oReturn, "Workgroup");
                                                }
                                                else if (oReturn["Domain"] != null)
                                                {
                                                    _InventoryData.domainWorkgroup = WmiHelpers.GetString(oReturn, "Domain");
                                                }
                                                _InventoryData.domainOrWorkgroup = "Workgroup";
                                            }
                                        }
                                        _InventoryData.numberOfPhysicalProcessors = int.Parse(WmiHelpers.GetString(oReturn, "NumberOfProcessors"));
                                    }
                                }

                                //cancel point
                                if (options.CancelRequested)
                                {
                                    return _InventoryData;
                                }

                                using (ManagementObjectSearcher _WmiSearcher = new ManagementObjectSearcher(_WMI, new ObjectQuery("SELECT Caption, Version, ServicePackMajorVersion, TotalVisibleMemorySize, FreePhysicalMemory, TotalVirtualMemorySize, FreeVirtualMemory FROM Win32_OperatingSystem")))
                                using (ManagementObjectCollection _WmiObjectCollection = _WmiSearcher.Get())
                                {
                                    CoreGlobals.traceLog.Verbose("Enumerating Win32_Operating");

                                    foreach (ManagementObject oReturn in _WmiObjectCollection)
                                    {
                                        _InventoryData.operatingSystem = WmiHelpers.GetString(oReturn, "Caption");
                                        _InventoryData.osVersion = WmiHelpers.GetString(oReturn, "Version");

                                        if (oReturn["ServicePackMajorVersion"] != null)
                                        {
                                            _InventoryData.osVersion += " Service Pack " + WmiHelpers.GetString(oReturn, "ServicePackMajorVersion");
                                        }

                                        _InventoryData.totalPhysicalMemory = WmiHelpers.GetUlong(oReturn, "TotalVisibleMemorySize");
                                        _InventoryData.availablePhysicalMemory = WmiHelpers.GetUlong(oReturn, "FreePhysicalMemory");
                                        _InventoryData.totalVirtualMemory = WmiHelpers.GetUlong(oReturn, "TotalVirtualMemorySize");
                                        _InventoryData.availableVirtualMemory = WmiHelpers.GetUlong(oReturn, "FreeVirtualMemory");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                CoreGlobals.traceLog.Verbose("WMI Exception: " + Helpers.GetCombinedExceptionText(ex));
                                _InventoryData.wmiException = ex;
                            }

                            if (_InventoryData.wmiException != null)  //if we get a WMI exception, try to get some values from SQL Server
                            {
                                if (string.IsNullOrEmpty(_InventoryData.domainOrWorkgroup))
                                {
                                    try
                                    {
                                        _InventoryData.domainWorkgroup = GetRegistryValue(_Connection, "HKEY_LOCAL_MACHINE", @"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters", "Domain");

                                        if (string.IsNullOrEmpty(_InventoryData.domainWorkgroup))
                                        {
                                            _InventoryData.domainOrWorkgroup = "Workgroup";
                                        }
                                        else
                                        {
                                            _InventoryData.domainOrWorkgroup = "Domain";
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        CoreGlobals.traceLog.Error("Domain Information error: " + Helpers.GetCombinedExceptionText(e));
                                    }
                                }

                                if (string.IsNullOrEmpty(_InventoryData.operatingSystem))
                                {
                                    _InventoryData.operatingSystem = Helpers.GetWindowsVersion(_Server.Information.OSVersion);
                                }
                                if (string.IsNullOrEmpty(_InventoryData.osVersion))
                                {
                                    _InventoryData.osVersion = _Server.Information.OSVersion.Replace(" ", string.Empty).Replace("(", ".").Replace(")", string.Empty);

                                    try
                                    {
                                        string _ServicePackString = string.Empty;
                                        using (SqlCommand _ServicePackCommand = new SqlCommand("select @@version", _Connection))
                                        {
                                            _ServicePackString = (string)_ServicePackCommand.ExecuteScalar();
                                        }
                                        Regex servicePackRegex = new Regex(@"(?<=:.Service.Pack\s+).*(?=\))", RegexOptions.IgnoreCase);
                                        if (servicePackRegex.IsMatch(_ServicePackString))
                                        {
                                            _InventoryData.osVersion += " Service Pack " + servicePackRegex.Matches(_ServicePackString)[0];
                                        }

                                    }
                                    catch (Exception e)
                                    {
                                        CoreGlobals.traceLog.Error("OS Information error: " + Helpers.GetCombinedExceptionText(e));
                                    }
                                }

                                if (_InventoryData.totalPhysicalMemory == ulong.MinValue)
                                {
                                    try
                                    {
                                        using (SqlCommand _PhysicalMemoryCommand = new SqlCommand("xp_msver 'PhysicalMemory'", _Connection))
                                        using (SqlDataReader _Reader = _PhysicalMemoryCommand.ExecuteReader())
                                        {
                                            if (_Reader.Read())
                                            {
                                                _InventoryData.totalPhysicalMemory = (ulong)_Reader.GetInt32(_Reader.GetOrdinal("Internal_Value")) * 1024;
                                            }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        CoreGlobals.traceLog.Error("Physical Memory information error: " + Helpers.GetCombinedExceptionText(e));
                                    }
                                }
                            }

                            _InventoryData.numberOfLogicalProcessors = _Server.Information.Processors;
                            _InventoryData.platform = _Server.Information.Platform;

                            //cancel point
                            if (options.CancelRequested)
                            {
                                return _InventoryData;
                            }

                            try
                            {
                                GetHardDriveInformation(serverInformation, commandTimeout, _InventoryData);
                            }
                            catch (SqlException sqlEx) //try again one more time in case it was caused by server-restart broken connection.
                            {
                                if (sqlEx.Number == 233)
                                {
                                    GetHardDriveInformation(serverInformation, commandTimeout, _InventoryData);
                                }
                                else
                                {
                                    throw;
                                }
                            }
                            //cancel point
                            if (options.CancelRequested)
                            {
                                return _InventoryData;
                            }

                            // SQL Server Version Handling
                            SQLVersion sqlVersion = SQLVersion.FromVersion(_Server.Information.Version);
                            _InventoryData.sqlServerRelease = sqlVersion.Name;
                            _InventoryData.sqlServerVersion = _Server.Information.VersionString;
                            _InventoryData.sqlServerEdition = _Server.Information.Edition;

                            // Other SQL Server Properties
                            _InventoryData.maximumNumberofConnections = _Server.Configuration.UserConnections.ConfigValue;
                            _InventoryData.databaseCount = _Server.Databases.Count;

                            _InventoryData.isClusteredServer = _Server.Information.IsClustered;
                            if (_InventoryData.isClusteredServer)
                            {
                                _InventoryData.hostComputer += ProductConstants.ClusteredServerAppendToHost;
                            }
                            _InventoryData.isAgentXpEnabled = (_Server.Configuration.AgentXPsEnabled.ConfigValue == 1);
                            _InventoryData.isDatabaseMailEnabled = (_Server.Configuration.DatabaseMailEnabled.ConfigValue == 1);
                            _InventoryData.isSqlClrEnabled = (_Server.Configuration.IsSqlClrEnabled.ConfigValue == 1);
                            _InventoryData.isRemoteAccessAllowed = (_Server.Configuration.RemoteAccess.ConfigValue == 1);
                            _InventoryData.isXpCommandShellEnabled = (_Server.Configuration.XPCmdShellEnabled.ConfigValue == 1);
                            _InventoryData.isSingleUser = _Server.Information.IsSingleUser;
                            _InventoryData.language = _Server.Information.Language;
                            _InventoryData.collation = _Server.Information.Collation;
                            _InventoryData.isCaseSensitive = _Server.Information.IsCaseSensitive;
                            _InventoryData.isFullTextInstalled = _Server.Information.IsFullTextInstalled;
                            _InventoryData.masterDBPath = _Server.Information.MasterDBPath;
                            _InventoryData.masterLogPath = _Server.Information.MasterDBLogPath;
                            _InventoryData.errorLogPath = _Server.Information.ErrorLogPath;
                            _InventoryData.c2AuditMode = (_Server.Configuration.C2AuditMode.ConfigValue == 1);

                            if (sqlVersion.Major < 11) // When SQL server version is lower than 2012
                                _InventoryData.aweEnabled = (_Server.Configuration.AweEnabled.ConfigValue == 1);

                            _InventoryData.maximumSqlServerMemory = _Server.Configuration.MaxServerMemory.ConfigValue;
                            _InventoryData.minimumSqlServerMemory = _Server.Configuration.MinServerMemory.ConfigValue;

                            string _RegistryLocalMachine = "HKEY_LOCAL_MACHINE";
                            string _RegistryNetworkLibrariesKey = @"Software\Microsoft\MSSQLServer\MSSQLServer\SuperSocketNetLib\";
                            if (SQLHelpers.Is2000(_Server.Information.Version.Major))
                            {
                                _InventoryData.memoryAllocationType = _Server.Configuration.SetWorkingSetSize.ConfigValue == 1 ?
                                    "Locked" : "Dynamic";

                                List<string> _ProtocolList = GetRegistryValueList(_Connection,
                                                                          _RegistryLocalMachine,
                                                                          _RegistryNetworkLibrariesKey,
                                                                          "ProtocolList");

                                _InventoryData.networkNamedPipesEnabled = false;
                                _InventoryData.networkTcpIpEnabled = false;
                                _InventoryData.networkMultiprotocolEnabled = false;
                                _InventoryData.networkNwLinkEnabled = false;
                                _InventoryData.networkAppleTalkEnabled = false;
                                _InventoryData.networkBanyanVinesEnabled = false;
                                _InventoryData.networkViaEnabled = false;
                                foreach (string _ProtocolCode in _ProtocolList)
                                {
                                    switch (_ProtocolCode.ToUpperInvariant())
                                    {
                                        case "NP":
                                            _InventoryData.networkNamedPipesEnabled = true;
                                            break;
                                        case "TCP":
                                            _InventoryData.networkTcpIpEnabled = true;
                                            break;
                                        case "RPC":
                                            _InventoryData.networkMultiprotocolEnabled = true;
                                            break;
                                        case "SPX":
                                            _InventoryData.networkNwLinkEnabled = true;
                                            break;
                                        case "ADSP":
                                            _InventoryData.networkAppleTalkEnabled = true;
                                            break;
                                        case "BV":
                                            _InventoryData.networkBanyanVinesEnabled = true;
                                            break;
                                        case "VIA":
                                            _InventoryData.networkViaEnabled = true;
                                            break;
                                    }
                                }
                            }
                            else if (SQLHelpers.Is2005orGreater(_Server.Information.Version.Major))
                            {
                                _InventoryData.memoryAllocationType = "Dynamic";

                                _InventoryData.networkNamedPipesEnabled = GetRegistryValueInt(_Connection,
                                                                            _RegistryLocalMachine,
                                                                            _RegistryNetworkLibrariesKey + "Np",
                                                                            "Enabled") == 1 ? true : false;

                                _InventoryData.networkSharedMemoryEnabled = GetRegistryValueInt(_Connection,
                                                                            _RegistryLocalMachine,
                                                                            _RegistryNetworkLibrariesKey + "Sm",
                                                                            "Enabled") == 1 ? true : false;

                                _InventoryData.networkTcpIpEnabled = GetRegistryValueInt(_Connection,
                                                                            _RegistryLocalMachine,
                                                                            _RegistryNetworkLibrariesKey + "Tcp",
                                                                            "Enabled") == 1 ? true : false;

                                _InventoryData.networkViaEnabled = GetRegistryValueInt(_Connection,
                                                                            _RegistryLocalMachine,
                                                                            _RegistryNetworkLibrariesKey + "Via",
                                                                            "Enabled") == 1 ? true : false;
                            }

                            string _ListeningPortPath = _RegistryNetworkLibrariesKey + @"Tcp\";
                            string _ListeningPortKeyDefault = "TcpPort";
                            string _ListeningPortKeyDynamic = "TcpDynamicPorts";
                            if (SQLHelpers.Is2005orGreater(_Connection))
                            {
                                _ListeningPortPath += @"IPAll";
                            }


                            int _PortValue = int.MinValue;
                            _InventoryData.tcpPort = int.MinValue;
                            if (int.TryParse(GetRegistryValue(_Connection, _RegistryLocalMachine, _ListeningPortPath, _ListeningPortKeyDefault), out _PortValue))
                            {
                                _InventoryData.tcpPort = _PortValue;
                            }
                            else
                            {
                                if (int.TryParse(GetRegistryValue(_Connection, _RegistryLocalMachine, _ListeningPortPath, _ListeningPortKeyDynamic), out _PortValue))
                                {
                                    _InventoryData.tcpPort = _PortValue;
                                }
                            }

                            _InventoryData.allocatedCpuCount = (_Server.Configuration.AffinityMask.ConfigValue == 0) ?
                                _Server.Information.Processors : GetEnabledBitCount(_Server.Configuration.AffinityMask.ConfigValue);
                            _InventoryData.allocatedCpuCountIO = (_Server.Configuration.AffinityIOMask.ConfigValue == 0) ?
                                _Server.Information.Processors : GetEnabledBitCount(_Server.Configuration.AffinityIOMask.ConfigValue);

                        }


                        return _InventoryData;
                    }
                }


                catch (Exception exc)
                {
                    string msg = "Error capturing SQL Configuration: " + Helpers.GetCombinedExceptionText(exc);

                    if (wmiErrMsg != "")
                    {
                        msg = wmiErrMsg + "\r\n\r\n" + msg;
                    }

                    throw new ApplicationException(msg);
                }
            }
        }

        /// <summary>
        /// Returns the number of "on" bits from the bitmask representation of the input integer.
        /// </summary>
        private static int GetEnabledBitCount(int value)
        {
            int _Count = 0;
            while (value != 0)
            {
                if ((value & 1) == 1)
                {
                    _Count++;
                }
                value >>= 1;
            }
            return _Count;
        }

        /// <summary>
        /// Retrieves a registry value through SQL Server and converts it to an integer.
        /// </summary>
        private static int GetRegistryValueInt(SqlConnection conn, string hive, string path, string key)
        {
            int _ReturnValue = int.MinValue;
            string _Sql = "DECLARE @Value INT " +
                          string.Format("EXEC master.dbo.xp_instance_regread N'{0}', N'{1}', N'{2}', @Value OUTPUT ", hive, path, key) +
                          "SELECT @Value";

            using (SqlCommand _Command = new SqlCommand(_Sql, conn))
            {
                object _Value = _Command.ExecuteScalar();
                if (_Value != DBNull.Value)
                {
                    _ReturnValue = (int)_Value;
                }
            }
            return _ReturnValue;
        }

        /// <summary>
        /// Retrieves a registry value through SQL Server.
        /// </summary>
        private static string GetRegistryValue(SqlConnection conn, string hive, string path, string key)
        {
            string _ReturnValue = string.Empty;
            string _Sql = "DECLARE @Value NVARCHAR(512) " +
                          string.Format("EXEC master.dbo.xp_instance_regread N'{0}', N'{1}', N'{2}', @Value OUTPUT ", hive, path, key) +
                          "SELECT @Value";

            using (SqlCommand _Command = new SqlCommand(_Sql, conn))
            {
                object _Value = _Command.ExecuteScalar();
                if (_Value != DBNull.Value)
                {
                    _ReturnValue = (string)_Value;
                }
            }
            return _ReturnValue;
        }

        /// <summary>
        /// Retrieves a registry value through SQL Server.
        /// </summary>
        private static List<string> GetRegistryValueList(SqlConnection conn, string hive, string path, string key)
        {
            List<string> _ReturnValues = new List<string>();
            string _Sql = "DECLARE @Value NVARCHAR(512) " +
                          string.Format("EXEC master.dbo.xp_instance_regread N'{0}', N'{1}', N'{2}', @Value OUTPUT ", hive, path, key) +
                          "SELECT @Value";

            using (SqlCommand _Command = new SqlCommand(_Sql, conn))
            using (SqlDataReader _Reader = _Command.ExecuteReader())
            {
                while (_Reader.Read())
                {
                    _ReturnValues.Add(_Reader.GetString(1));
                }
            }
            return _ReturnValues;
        }

        /// <summary>
        /// Gets hard drive information.
        /// </summary>
        private static void GetHardDriveInformation(ServerInformation serverInformation, int commandTimeout, InventoryData inventoryData)
        {
            inventoryData.numberOfHardDrives = 0;
            inventoryData.freeHardDriveSpace = 0;
            
            using (SqlConnection _Connection = Connection.OpenConnection(serverInformation.Name, "master", serverInformation.SqlCredentials))
            {
               using (SqlCommand _Command = new SqlCommand("xp_fixeddrives", _Connection))
               {
                   _Command.CommandTimeout = commandTimeout;
                   using (SqlDataReader _Reader = _Command.ExecuteReader())
                   {
                       while (_Reader.Read())
                       {
                           inventoryData.numberOfHardDrives++;
                           inventoryData.freeHardDriveSpace += _Reader.GetInt32(1);
                       }
                   }
               }
               _Connection.Close();
            }
        }

        /// <summary>
        /// Loads inventory data out of an XmlDocument.
        /// </summary>
        public static List<InventoryData> LoadFromXml(XmlDocument xmlDocument)
        {
            if (xmlDocument == null)
            {
                throw new ArgumentNullException("xmlDocument", "The XML Document is null");
            }

            if (xmlDocument.DocumentElement.SelectNodes("Server") == null)
            {
                throw new ArgumentException("The XML was not valid.", "xmlDocument");
            }

            try
            {
                List<InventoryData> _InventoryList = new List<InventoryData>();

                foreach (XmlNode _ServerInventory in xmlDocument.DocumentElement.SelectNodes("Server"))
                {
                    InventoryData _InventoryData = new InventoryData(InventoryData.InventoryType.Snapshot);

                    _InventoryData.availablePhysicalMemory = ulong.Parse(GetValueFromXml(_ServerInventory, ProductConstants.AvailablePhysicalMemoryCaption));
                    _InventoryData.availableVirtualMemory = ulong.Parse(GetValueFromXml(_ServerInventory, ProductConstants.AvailableVirtualMemoryCaption));
                    _InventoryData.databaseCount = int.Parse(GetValueFromXml(_ServerInventory, ProductConstants.DatabaseCountCaption));
                    _InventoryData.freeHardDriveSpace = int.Parse(GetValueFromXml(_ServerInventory, ProductConstants.FreeSpaceCaption));
                    _InventoryData.isAgentXpEnabled = bool.Parse(GetValueFromXml(_ServerInventory, ProductConstants.AgentXpsEnabledCaption));
                    _InventoryData.isClusteredServer = bool.Parse(GetValueFromXml(_ServerInventory, ProductConstants.ClusteredServerCaption));
                    _InventoryData.isDatabaseMailEnabled = bool.Parse(GetValueFromXml(_ServerInventory, ProductConstants.DatabaseMailEnabledCaption));
                    _InventoryData.isRemoteAccessAllowed = bool.Parse(GetValueFromXml(_ServerInventory, ProductConstants.RemoteAccessAllowedCaption));
                    _InventoryData.isSqlClrEnabled = bool.Parse(GetValueFromXml(_ServerInventory, ProductConstants.SqlClrEnabledCaption));
                    _InventoryData.isXpCommandShellEnabled = bool.Parse(GetValueFromXml(_ServerInventory, ProductConstants.XpCommandShellEnabledCaption));
                    _InventoryData.hostComputer = GetValueFromXml(_ServerInventory, ProductConstants.HostComputerCaption);
                    _InventoryData.domainWorkgroup = GetValueFromXml(_ServerInventory, ProductConstants.DomainWorkgroupCaption);
                    _InventoryData.domainOrWorkgroup = GetValueFromXml(_ServerInventory, ProductConstants.DomainOrWorkgroupCaption);
                    _InventoryData.manufacturer = GetValueFromXml(_ServerInventory, ProductConstants.ManufacturerCaption);
                    _InventoryData.maximumSqlServerMemory = int.Parse(GetValueFromXml(_ServerInventory, ProductConstants.MaximumServerMemoryCaption));
                    _InventoryData.maximumNumberofConnections = int.Parse(GetValueFromXml(_ServerInventory, ProductConstants.MaximumNumberOfUserConnectionsCaption));
                    _InventoryData.numberOfHardDrives = int.Parse(GetValueFromXml(_ServerInventory, ProductConstants.NumberOfHardDrivesCaption));
                    _InventoryData.operatingSystem = GetValueFromXml(_ServerInventory, ProductConstants.OperatingSystemCaption);
                    _InventoryData.osVersion = GetValueFromXml(_ServerInventory, ProductConstants.OperatingSystemVersionCaption);
                    _InventoryData.platform = GetValueFromXml(_ServerInventory, ProductConstants.PlatformCaption);
                    _InventoryData.reportDate = DateTime.Parse(GetValueFromXml(_ServerInventory, ProductConstants.ReportDateCaption));
                    _InventoryData.serverName = _ServerInventory.Attributes["Name"].Value;
                    _InventoryData.sqlServerRelease = GetValueFromXml(_ServerInventory, ProductConstants.SqlServerReleaseCaption);
                    _InventoryData.sqlServerVersion = GetValueFromXml(_ServerInventory, ProductConstants.SqlServerVersionCaption);
                    _InventoryData.sqlServerEdition = GetValueFromXml(_ServerInventory, ProductConstants.SqlServerEditionCaption);
                    _InventoryData.totalPhysicalMemory = ulong.Parse(GetValueFromXml(_ServerInventory, ProductConstants.TotalPhysicalMemoryCaption));
                    _InventoryData.totalVirtualMemory = ulong.Parse(GetValueFromXml(_ServerInventory, ProductConstants.TotalVirtualMemoryCaption));
                    _InventoryData.isSingleUser = bool.Parse(GetValueFromXml(_ServerInventory, ProductConstants.IsSingleUserCaption));
                    _InventoryData.language = GetValueFromXml(_ServerInventory, ProductConstants.LanguageCaption);
                    _InventoryData.collation = GetValueFromXml(_ServerInventory, ProductConstants.CollationCaption);
                    _InventoryData.isCaseSensitive = bool.Parse(GetValueFromXml(_ServerInventory, ProductConstants.IsCaseSensitiveCaption));
                    _InventoryData.isFullTextInstalled = bool.Parse(GetValueFromXml(_ServerInventory, ProductConstants.IsFullTextInstalledCaption));
                    _InventoryData.masterDBPath = GetValueFromXml(_ServerInventory, ProductConstants.MasterDBPathCaption);
                    _InventoryData.masterLogPath = GetValueFromXml(_ServerInventory, ProductConstants.MasterLogPathCaption);
                    _InventoryData.errorLogPath = GetValueFromXml(_ServerInventory, ProductConstants.ErrorLogPathCaption);
                    _InventoryData.c2AuditMode = bool.Parse(GetValueFromXml(_ServerInventory, ProductConstants.C2AuditModeCaption));

                    if (InventoryData.GetServerVersionAsInt(_InventoryData.sqlServerVersion) < 11) // When SQL server version is lower than 2012
                        _InventoryData.aweEnabled = bool.Parse(GetValueFromXml(_ServerInventory, ProductConstants.AweEnabledCaption));
                    else
                        _InventoryData.aweEnabled = false;
                    
                    //for legacy data
                    string _XmlValue = null;
                    if (TryGetValueFromXml(_ServerInventory, ProductConstants.LastServerRestart, out _XmlValue))
                    {
                        _InventoryData.lastStartDate = DateTime.Parse(_XmlValue);
                    }
                    if (TryGetValueFromXml(_ServerInventory, ProductConstants.ListeningPort, out _XmlValue))
                    {
                        _InventoryData.tcpPort = int.Parse(_XmlValue);
                    }
                    if (TryGetValueFromXml(_ServerInventory, ProductConstants.MinimumServerMemoryCaption, out _XmlValue))
                    {
                        _InventoryData.minimumSqlServerMemory = int.Parse(_XmlValue);
                    }
                    if (TryGetValueFromXml(_ServerInventory, ProductConstants.MemoryAllocationTypeCaption, out _XmlValue))
                    {
                        _InventoryData.memoryAllocationType = _XmlValue;
                    }
                    if (TryGetValueFromXml(_ServerInventory, ProductConstants.AllocatedCpuCountCaption, out _XmlValue))
                    {
                        _InventoryData.allocatedCpuCount = int.Parse(_XmlValue);
                    }
                    if (TryGetValueFromXml(_ServerInventory, ProductConstants.AllocatedCpuCountIOCaption, out _XmlValue))
                    {
                        _InventoryData.allocatedCpuCountIO = int.Parse(_XmlValue);
                    }
                    bool _IsNetworkLibraryEnabled;
                    if (TryGetValueFromXml(_ServerInventory, ProductConstants.NetworkProtocolApplteTalk, out _XmlValue))
                    {
                        if (bool.TryParse(_XmlValue, out _IsNetworkLibraryEnabled))
                        {
                            _InventoryData.networkAppleTalkEnabled = _IsNetworkLibraryEnabled;
                        }
                    }
                    if (TryGetValueFromXml(_ServerInventory, ProductConstants.NetworkProtocolBanyanVines, out _XmlValue))
                    {
                        if (bool.TryParse(_XmlValue, out _IsNetworkLibraryEnabled))
                        {
                            _InventoryData.networkBanyanVinesEnabled = _IsNetworkLibraryEnabled;
                        }
                    }
                    if (TryGetValueFromXml(_ServerInventory, ProductConstants.NetworkProtocolMultiprotocol, out _XmlValue))
                    {
                        if (bool.TryParse(_XmlValue, out _IsNetworkLibraryEnabled))
                        {
                            _InventoryData.networkMultiprotocolEnabled = _IsNetworkLibraryEnabled;
                        }
                    }
                    if (TryGetValueFromXml(_ServerInventory, ProductConstants.NetworkProtocolNamedPipes, out _XmlValue))
                    {
                        if (bool.TryParse(_XmlValue, out _IsNetworkLibraryEnabled))
                        {
                            _InventoryData.networkNamedPipesEnabled = _IsNetworkLibraryEnabled;
                        }
                    }
                    if (TryGetValueFromXml(_ServerInventory, ProductConstants.NetworkProtocolNwLink, out _XmlValue))
                    {
                        if (bool.TryParse(_XmlValue, out _IsNetworkLibraryEnabled))
                        {
                            _InventoryData.networkNwLinkEnabled = _IsNetworkLibraryEnabled;
                        }
                    }
                    if (TryGetValueFromXml(_ServerInventory, ProductConstants.NetworkProtocolSharedMemory, out _XmlValue))
                    {
                        if (bool.TryParse(_XmlValue, out _IsNetworkLibraryEnabled))
                        {
                            _InventoryData.networkSharedMemoryEnabled = _IsNetworkLibraryEnabled;
                        }
                    }
                    if (TryGetValueFromXml(_ServerInventory, ProductConstants.NetworkProtocolTcpIp, out _XmlValue))
                    {
                        if (bool.TryParse(_XmlValue, out _IsNetworkLibraryEnabled))
                        {
                            _InventoryData.networkTcpIpEnabled = _IsNetworkLibraryEnabled;
                        }
                    }
                    if (TryGetValueFromXml(_ServerInventory, ProductConstants.NetworkProtocolVia, out _XmlValue))
                    {
                        if (bool.TryParse(_XmlValue, out _IsNetworkLibraryEnabled))
                        {
                            _InventoryData.networkViaEnabled = _IsNetworkLibraryEnabled;
                        }
                    }
                    
                    if (TryGetValueFromXml(_ServerInventory, ProductConstants.NumberOfPhysicalProcessorsCaption, out _XmlValue))
                    {
                        _InventoryData.numberOfPhysicalProcessors = int.Parse(_XmlValue);
                    }
                    if (TryGetValueFromXml(_ServerInventory, ProductConstants.NumberOfLogicalProcessorsCaption, out _XmlValue))
                    {
                        _InventoryData.numberOfLogicalProcessors = int.Parse(_XmlValue);
                    }
                    else if (TryGetValueFromXml(_ServerInventory, ProductConstants.NumberOfLogicalProcessorsLegacyCaption, out _XmlValue))
                    {
                        _InventoryData.numberOfLogicalProcessors = int.Parse(_XmlValue);
                    }

                    _InventoryList.Add(_InventoryData);
                }

                return _InventoryList;
            }

            catch (InvalidOperationException exc)
            {
                throw new ArgumentException("The XML was not valid.", "xmlDocument", exc);
            }
        }

        private static bool TryGetValueFromXml(XmlNode xmlData, string nodeName, out string value)
        {
            try
            {
                value = GetValueFromXml(xmlData, nodeName);
                return true;
            }
            catch
            {
                value = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// Retrieves a value out of the XML file.
        /// </summary>
        private static string GetValueFromXml(XmlNode xmlData, string nodeName)
        {
            if ((xmlData.SelectNodes(string.Format("InventoryItem[@Name='{0}']", nodeName)) != null) && (xmlData.SelectNodes(string.Format("InventoryItem[@Name='{0}']", nodeName)).Count > 0))
            {
                nodeName = nodeName.Normalize();
                return xmlData.SelectNodes(string.Format("InventoryItem[@Name='{0}']", nodeName))[0].InnerText;
            }
            else
            {
                throw new InvalidOperationException("Inventory value not found");
            }
        }

        /// <summary>
        /// Loads inventory data from an XML file.
        /// </summary>
        public static List<InventoryData> LoadFromFile(string filePath)
        {
            XmlDocument _XmlDocument = new XmlDocument();
            _XmlDocument.Load(filePath);
            return LoadFromXml(_XmlDocument);
        }

        /// <summary>
        /// Converts inventory data into XML.
        /// </summary>
        public static XmlDocument ConvertInventoryDataToXml(List<InventoryData> dataList)
        {
            if (dataList.Count == 0) return null; //it's empty
            
            XmlDocument _XmlDocument = new XmlDocument();

            XmlElement rootNode = _XmlDocument.CreateElement("InventoryReport");
            _XmlDocument.AppendChild(rootNode);

            foreach (InventoryData _Data in dataList)
            {
                XmlElement _ParentNode = _XmlDocument.CreateElement("Server");
                _ParentNode.SetAttribute("Name", _Data.serverName);
                _XmlDocument.DocumentElement.AppendChild(_ParentNode);

                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.ReportDateCaption, _Data.reportDate.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.HostComputerCaption, _Data.hostComputer));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.DomainWorkgroupCaption, _Data.domainWorkgroup));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.DomainOrWorkgroupCaption, _Data.domainOrWorkgroup));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.ManufacturerCaption, _Data.manufacturer));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.OperatingSystemCaption, _Data.operatingSystem));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.OperatingSystemVersionCaption, _Data.osVersion));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.TotalPhysicalMemoryCaption, _Data.totalPhysicalMemory.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.AvailablePhysicalMemoryCaption, _Data.availablePhysicalMemory.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.TotalVirtualMemoryCaption, _Data.totalVirtualMemory.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.AvailableVirtualMemoryCaption, _Data.availableVirtualMemory.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.NumberOfPhysicalProcessorsCaption, _Data.numberOfPhysicalProcessors.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.NumberOfLogicalProcessorsCaption, _Data.numberOfLogicalProcessors.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.PlatformCaption, _Data.platform));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.NumberOfHardDrivesCaption, _Data.numberOfHardDrives.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.FreeSpaceCaption, _Data.freeHardDriveSpace.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.SqlServerReleaseCaption, _Data.sqlServerRelease));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.SqlServerVersionCaption, _Data.sqlServerVersion));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.SqlServerEditionCaption, _Data.sqlServerEdition));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.DatabaseCountCaption, _Data.databaseCount.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.MaximumNumberOfUserConnectionsCaption, _Data.maximumNumberofConnections.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.AgentXpsEnabledCaption, _Data.isAgentXpEnabled.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.ClusteredServerCaption, _Data.isClusteredServer.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.DatabaseMailEnabledCaption, _Data.isDatabaseMailEnabled.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.RemoteAccessAllowedCaption, _Data.isRemoteAccessAllowed.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.SqlClrEnabledCaption, _Data.isSqlClrEnabled.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.XpCommandShellEnabledCaption, _Data.isXpCommandShellEnabled.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.IsSingleUserCaption, _Data.isSingleUser.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.LanguageCaption, _Data.language));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.CollationCaption, _Data.collation));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.IsCaseSensitiveCaption, _Data.isCaseSensitive.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.IsFullTextInstalledCaption, _Data.isFullTextInstalled.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.MasterDBPathCaption, _Data.masterDBPath));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.MasterLogPathCaption, _Data.masterLogPath));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.ErrorLogPathCaption, _Data.errorLogPath));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.C2AuditModeCaption, _Data.c2AuditMode.ToString()));

                if (InventoryData.GetServerVersionAsInt(_Data.sqlServerVersion) < 11) // When SQL server version is lower than 2012
                    _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.AweEnabledCaption, _Data.aweEnabled.ToString()));
                else
                    _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.AweEnabledCaption, ProductConstants.AweEnabledMessage));

                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.MemoryAllocationTypeCaption, _Data.memoryAllocationType));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.MinimumServerMemoryCaption, _Data.minimumSqlServerMemory.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.MaximumServerMemoryCaption, _Data.maximumSqlServerMemory.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.LastServerRestart, _Data.lastStartDate.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.ListeningPort, _Data.tcpPort.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.AllocatedCpuCountCaption, _Data.allocatedCpuCount.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.AllocatedCpuCountIOCaption, _Data.allocatedCpuCountIO.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.NetworkProtocolApplteTalk, _Data.networkAppleTalkEnabled.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.NetworkProtocolBanyanVines, _Data.networkBanyanVinesEnabled.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.NetworkProtocolMultiprotocol, _Data.networkMultiprotocolEnabled.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.NetworkProtocolNamedPipes, _Data.networkNamedPipesEnabled.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.NetworkProtocolNwLink, _Data.networkNwLinkEnabled.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.NetworkProtocolSharedMemory, _Data.networkSharedMemoryEnabled.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.NetworkProtocolTcpIp, _Data.networkTcpIpEnabled.ToString()));
                _ParentNode.AppendChild(CreateChildElement(_XmlDocument, ProductConstants.NetworkProtocolVia, _Data.networkViaEnabled.ToString()));

            }

            return _XmlDocument;
        }

        /// <summary>
        /// Creates a child element out of inventory data to populate the XML file.
        /// </summary>
        private static XmlElement CreateChildElement(XmlDocument xmlDocument, string name, string value)
        {
            XmlElement _ItemNode = xmlDocument.CreateElement("InventoryItem");
            _ItemNode.SetAttribute("Name", name);
            _ItemNode.AppendChild(xmlDocument.CreateTextNode(value));
            return _ItemNode;
        }

        /// <summary>
        /// Saves inventory data to a file.
        /// </summary>
        public static void SaveToFile(List<InventoryData> dataList, string filePath)
        {
            ConvertInventoryDataToXml(dataList).Save(filePath);
        }
    }
}
