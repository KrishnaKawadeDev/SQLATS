using System;
using Idera.SqlAdminToolset.Core;
using System.Data.SqlClient;

namespace Idera.SqlAdminToolset.ServerConfiguration
{
    internal class ConfigurationHelper
    {
        private static object threadLock = new object();

        /// <summary>
        /// Gets configuration data from the requested server.
        /// </summary>
        internal static ConfigurationSettings GetServerConfiguration(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
            ConfigurationSettings _Settings = new ConfigurationSettings(serverInformation);
            lock (threadLock)
            {
                _Settings.DateCaptured = DateTime.Now;
                _Settings.Source = ConfigurationSettings.DataSource.LiveData;

                using (SqlConnection _Connection = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials))
                {
                    string _VersionString = SQLHelpers.GetSqlVersionString(_Connection);
                    SQLVersion _SqlVersion;

                    if (SQLVersion.TryParse(_VersionString, out _SqlVersion))
                    {
                        _Settings.Version = string.Format("{0} ({1}) - {2}", _SqlVersion.Name, _SqlVersion.ServiceLevel, _SqlVersion.Edition);
                    }
                    else
                    {
                        _Settings.Version = "Unknown";
                    }

                    _Settings.LastStartDate = SQLHelpers.GetServerStartDate(_Connection);

                    if (SQLHelpers.Is2000orGreater(_Connection))
                    {
                        using (SqlCommand _CollationCommand = new SqlCommand("SELECT SERVERPROPERTY(N'Collation')", _Connection))
                        {
                            _Settings.ServerCollation = (string)_CollationCommand.ExecuteScalar();
                        }
                    }

                    if (SQLHelpers.Is2005orGreater(_Connection))
                    {
                        using (SqlCommand _Command = new SqlCommand(ProductConstants.QuerySql2005ConfigurationValues, _Connection))
                        {
                            _Command.CommandTimeout = commandTimeout;

                            using (SqlDataReader _Reader = _Command.ExecuteReader())
                            {
                                while (_Reader.Read())
                                {
                                    ConfigurationData _Data = new ConfigurationData(_Reader.GetString(_Reader.GetOrdinal("name")),
                                                                                    _Reader.GetString(_Reader.GetOrdinal("description")),
                                                                                    _Reader.GetInt32(_Reader.GetOrdinal("minimum")),
                                                                                    _Reader.GetInt32(_Reader.GetOrdinal("maximum")),
                                                                                    _Reader.GetInt32(_Reader.GetOrdinal("config_value")),
                                                                                    _Reader.GetInt32(_Reader.GetOrdinal("run_value")),
                                                                                    (_Reader.GetInt32(_Reader.GetOrdinal("restart_required")) == 1),
                                                                                    _Reader.GetBoolean(_Reader.GetOrdinal("is_advanced")) ? ConfigurationType.Advanced : ConfigurationType.Standard,
                                                                                    _Settings.SetDirty);
                                    AssignConfigurationData(_Settings, _Data);
                                }
                            }
                        }
                    }
                    else
                    {
                        using (SqlCommand _Command = new SqlCommand(ProductConstants.QuerySql2000ConfigurationValues, _Connection))
                        {
                            _Command.CommandTimeout = commandTimeout;

                            using (SqlDataReader _Reader = _Command.ExecuteReader())
                            {
                                while (_Reader.Read())
                                {
                                    ConfigurationData _Data = new ConfigurationData(_Reader.GetString(_Reader.GetOrdinal("name")),
                                                                                    _Reader.GetString(_Reader.GetOrdinal("comment")),
                                                                                    _Reader.GetInt32(_Reader.GetOrdinal("minimum")),
                                                                                    _Reader.GetInt32(_Reader.GetOrdinal("maximum")),
                                                                                    _Reader.GetInt32(_Reader.GetOrdinal("config_value")),
                                                                                    _Reader.GetInt32(_Reader.GetOrdinal("run_value")),
                                                                                    (_Reader.GetInt32(_Reader.GetOrdinal("restart_required")) == 1),
                                                                                    (_Reader.GetInt32(_Reader.GetOrdinal("is_advanced")) == 1) ? ConfigurationType.Advanced : ConfigurationType.Standard,
                                                                                    _Settings.SetDirty);
                                    AssignConfigurationData(_Settings, _Data);
                                }
                            }
                        }
                    }

                    if (SQLHelpers.Is2000orGreater(_Connection))
                    {
                        //Security (registry) configuration
                        string _RegistrySql = "declare @Value int \n" +
                                               "exec master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\\Microsoft\\MSSQLServer\\MSSQLServer', N'{0}', @Value OUTPUT \n" +
                                               "select @Value";

                        ConfigurationData _AuditLevel = new ConfigurationData("Login Auditing", "Login Auditing", true, _Settings.SetDirty, "AuditLevel");
                        using (SqlCommand _Command = new SqlCommand(string.Format(_RegistrySql, _AuditLevel.RegistryKeyName), _Connection))
                        {
                            _AuditLevel.ConfiguredValue = (int)_Command.ExecuteScalar();
                            _AuditLevel.Lookup = new System.Collections.Generic.Dictionary<int, string>();
                            _AuditLevel.Lookup.Add(0, "None");
                            _AuditLevel.Lookup.Add(1, "Success");
                            _AuditLevel.Lookup.Add(2, "Failed");
                            _AuditLevel.Lookup.Add(3, "Success and failed");
                            _Settings.AuditLevel = _AuditLevel;
                        }
                    }

                    _Connection.Close();
                }
            }
            return _Settings;
        }

        /// <summary>
        /// Updates specified configuration data on a server.
        /// </summary>
        internal static ConfigurationChangeResults UpdateConfiguration(ServerInformation serverInformation, ConfigurationData data)
        {
            ConfigurationChangeResults _Results;
            
            try
            {
                if (data.Type == ConfigurationType.Security)
                {
                    UpdateRegistryConfiguration(serverInformation, data.RegistryKeyName, data.ConfiguredValue);
                }
                else
                {
                    UpdateSqlConfiguration(serverInformation, data.Name, data.ConfiguredValue);
                }
                _Results = new ConfigurationChangeResults(serverInformation, data, true);
            }
            catch (SqlException e)
            {
                switch (e.Number)
                {
                    case 15123: //Advanced options not enabled, automatically retry
                        UpdateSqlConfiguration(serverInformation, "Show Advanced Options", 1);
                        _Results = UpdateConfiguration(serverInformation, data);
                        break;
                    case 5808:
                    case 5843: //Value not supported by SQL Server version, set it back to previous value
                        UpdateSqlConfiguration(serverInformation, data.Name, data.RunningValue);
                        _Results = new ConfigurationChangeResults(serverInformation, data, false, e);
                        break;
                    default:
                        _Results = new ConfigurationChangeResults(serverInformation, data, false, e);
                        break;
                }
            }
            catch(Exception ex)
            {
                _Results = new ConfigurationChangeResults(serverInformation, data, false, ex);
            }

            return _Results;
        }

        /// <summary>
        /// Updates a configuration setting to the requested value.
        /// </summary>
        private static void UpdateSqlConfiguration(ServerInformation serverInformation, string configurationName, int configurationValue)
        {
            string _UpdateConfiguration = string.Format("sp_configure @configname = '{0}', @configvalue = '{1}'", configurationName, configurationValue);

            using (SqlConnection _Connection = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials))
            {
                using (SqlCommand _Command = new SqlCommand(_UpdateConfiguration))
                {
                    _Command.Connection = _Connection;
                    _Command.CommandTimeout = ToolsetOptions.commandTimeout;

                    _Command.ExecuteNonQuery();

                    string _Reconfigure = "RECONFIGURE WITH OVERRIDE";

                    _Command.CommandText = _Reconfigure;
                    _Command.ExecuteNonQuery();
                }

                _Connection.Close();
            }
        }

        /// <summary>
        /// Updates a configuration setting to the requested value.
        /// </summary>
        private static void UpdateRegistryConfiguration(ServerInformation serverInformation, string registryKeyName, int configurationValue)
        {
            string _UpdateConfiguration = string.Format("EXEC master.dbo.xp_instance_regwrite N'HKEY_LOCAL_MACHINE', N'SOFTWARE\\Microsoft\\MSSQLServer\\MSSQLServer',N'{0}', REG_DWORD, {1}", registryKeyName, configurationValue);

            using (SqlConnection _Connection = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials))
            {
                using (SqlCommand _Command = new SqlCommand(_UpdateConfiguration))
                {
                    _Command.Connection = _Connection;
                    _Command.CommandTimeout = ToolsetOptions.commandTimeout;

                    _Command.ExecuteNonQuery();
                }

                _Connection.Close();
            }
        }

        private static void AssignConfigurationData(ConfigurationSettings settings, ConfigurationData data)
        {
            switch (data.Name)
            {
                //SQLADMI 331.
                case "affinity64 I/O mask":
                    settings.Affinity64IOMask = data;
                    break;
                case "affinity64 mask":
                    settings.Affinity64Mask = data;
                    break;
                case "access check cache quota":
                    settings.AccessCheckCacheQuota = data;
                    break;
                case "access check cache bucket count":
                    settings.AccessCheckCacheBucketCount = data;
                    break;

                case "Ad Hoc Distributed Queries":
                    settings.AdHocDistributedQueries = data;
                    break;
                case "affinity I/O mask":
                    settings.AffinityIOMask = data;
                    break;
                case "affinity mask":
                    settings.AffinityMask = data;
                    break;
                case "Agent XPs":
                    settings.AgentXPs = data;
                    break;
                case "allow updates":
                    settings.AllowUpdates = data;
                    break;
                case "awe enabled":
                    settings.AweEnabled = data;
                    break;
                case "blocked process threshold":
                    settings.BlockedProcessThreshold = data;
                    break;
                case "c2 audit mode":
                    settings.C2AuditMode = data;
                    break;
                case "clr enabled":
                    settings.ClrEnabled = data;
                    break;
                case "common criteria compliance enabled":
                    settings.CommonCriteriaComplianceEnabled = data;
                    break;
                case "cost threshold for parallelism":
                    settings.CostThresholdForParallelism = data;
                    break;
                case "cross db ownership chaining":
                    settings.CrossDbOwnershipChaining = data;
                    break;
                case "cursor threshold":
                    settings.CursorThreshold = data;
                    break;
                case "Database Mail XPs":
                    settings.DatabaseMailXPs = data;
                    break;
                case "default full-text language":
                    settings.DefaultFullTextLanguage = data;
                    break;
                case "default language":
                    settings.DefaultLanguage = data;
                    break;
                case "default trace enabled":
                    settings.DefaultTraceEnabled = data;
                    break;
                case "disallow results from triggers":
                    settings.DisallowResultsFromTriggers = data;
                    break;
                case "fill factor (%)":
                    settings.FillFactorPercentage = data;
                    break;
                case "ft crawl bandwidth (max)":
                    settings.FullTextCrawlBandwidthMaximum = data;
                    break;
                case "ft crawl bandwidth (min)":
                    settings.FullTextCrawlBandwidthReserved = data;
                    break;
                case "ft notify bandwidth (max)":
                    settings.FullTextNotificationsBandwidthMaximum = data;
                    break;
                case "ft notify bandwidth (min)":
                    settings.FullTextNotificationsBandwidthReserved = data;
                    break;
                case "index create memory (KB)":
                    settings.MemoryForIndexCreate = data;
                    break;
                case "in-doubt xact resolution":
                    settings.InDoubtTransactionResolution = data;
                    break;
                case "lightweight pooling":
                    settings.LightweightPooling = data;
                    break;
                case "locks":
                    settings.Locks = data;
                    break;
                case "max degree of parallelism":
                    settings.MaximumDegreeOfParallelism = data;
                    break;
                case "max full-text crawl range":
                    settings.MaximumFullTextCrawlRange = data;
                    break;
                case "max server memory (MB)":
                    settings.MaximumServerMemory = data;
                    break;
                case "max text repl size (B)":
                    settings.MaximumTextFieldSizeInReplication = data;
                    break;
                case "max worker threads":
                    settings.MaximumWorkerThreads = data;
                    break;
                case "media retention":
                    settings.MediaRetentionPeriod = data;
                    break;
                case "min memory per query (KB)":
                    settings.MinimumMemoryPerQuery = data;
                    break;
                case "min server memory (MB)":
                    settings.MinimumServerMemory = data;
                    break;
                case "nested triggers":
                    settings.NestedTriggers = data;
                    break;
                case "network packet size (B)":
                    settings.NetworkPacketSize = data;
                    break;
                case "Ole Automation Procedures":
                    settings.OleAutomationProcedures = data;
                    break;
                case "open objects":
                    settings.OpenDatabaseObjects = data;
                    break;
                case "PH timeout (s)":
                    settings.ProtocolHandlerTimeout = data;
                    break;
                case "precompute rank":
                    settings.PrecomputedRank = data;
                    break;
                case "priority boost":
                    settings.PriorityBoost = data;
                    break;
                case "query governor cost limit":
                    settings.QueryGovernorCostLimit = data;
                    break;
                case "query wait (s)":
                    settings.QueryMemoryWaitTimeMaximum = data;
                    break;
                case "recovery interval (min)":
                    settings.RecoveryIntervalMaximum = data;
                    break;
                case "remote access":
                    settings.RemoteAccessAllowed = data;
                    break;
                case "remote admin connections":
                    settings.DedicatedRemoteAdminConnectionsAllowed = data;
                    break;
                case "remote login timeout (s)":
                    settings.RemoteLoginTimeout = data;
                    break;
                case "remote proc trans":
                    settings.CreateDtcTransactionForRemoteProcedures = data;
                    break;
                case "remote query timeout (s)":
                    settings.RemoteQueryTimeout = data;
                    break;
                case "Replication XPs":
                    settings.EnableReplicationXPs = data;
                    break;
                case "scan for startup procs":
                    settings.ScanForStartupProcs = data;
                    break;
                case "server trigger recursion":
                    settings.AllowServerTriggerRecursion = data;
                    break;
                case "set working set size":
                    settings.SetWorkingSetSize = data;
                    break;
                case "show advanced options":
                    settings.ShowAdvancedOptions = data;
                    break;
                case "SMO and DMO XPs":
                    settings.EnableSmoAndDmoXPs = data;
                    break;
                case "SQL Mail XPs":
                    settings.EnableSqlMailXPs = data;
                    break;
                case "transform noise words":
                    settings.TransformNoiseWordsForFullTextQuery = data;
                    break;
                case "two digit year cutoff":
                    settings.TwoDigitYearCutoff = data;
                    break;
                case "user connections":
                    settings.UserConnectionsCountAllowed = data;
                    break;
                case "user options":
                    settings.UserOptions = data;
                    break;
                case "Web Assistant Procedures":
                    settings.EnableWebAssistantProcedures = data;
                    break;
                case "xp_cmdshell":
                    settings.EnableXpCmdshell = data;
                    break;
            }
        }
    }
}