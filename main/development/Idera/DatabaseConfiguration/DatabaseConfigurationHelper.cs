using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using System.Data;
//using Microsoft.SqlServer.Management.Common;

namespace Idera.SqlAdminToolset.DatabaseConfiguration
{
   internal class DatabaseConfigurationHelper
   {
        private static object threadLock = new object();

        static DatabaseConfigurationHelper()
      {
         ValidBooleanValues.Add("ON", true.ToString());
         ValidBooleanValues.Add("OFF", false.ToString());

         ValidReadIsolationOptions.Add("ON", true.ToString());
         ValidReadIsolationOptions.Add("OFF", false.ToString());

         ValidDatabaseAccessModeValues.Add("SINGLE_USER", "Single User");
         ValidDatabaseAccessModeValues.Add("RESTRICTED_USER", "Restricted User");
         ValidDatabaseAccessModeValues.Add("MULTI_USER", "Multi-User");

         ValidCursorDefaultValues.Add("LOCAL", "Local");
         ValidCursorDefaultValues.Add("GLOBAL", "Global");

         ValidDatabaseStateValues.Add("OFFLINE", "Offline");
         ValidDatabaseStateValues.Add("ONLINE", "Online");
         ValidDatabaseStateValues.Add("EMERGENCY", "Emergency");
         ValidDatabaseStateValues.Add("RESTORING", "Restoring");
         ValidDatabaseStateValues.Add("RECOVERING", "Recovering");
         ValidDatabaseStateValues.Add("RECOVERY PENDING", "Pending Recovery");
         ValidDatabaseStateValues.Add("SUSPECT", "Suspect");

         ValidDatabaseIsReadOnlyModeValues.Add("READ_ONLY", "Read-Only");
         ValidDatabaseIsReadOnlyModeValues.Add("READ_WRITE", "Read-Write");

         ValidParameterizationValues.Add("SIMPLE", "Simple");
         ValidParameterizationValues.Add("FORCED", "Forced");

         ValidRecoveryMode.Add("FULL", "Full");
         ValidRecoveryMode.Add("SIMPLE", "Simple");
         ValidRecoveryMode.Add("BULK_LOGGED", "Bulk-logged");

         ValidPageVerifyOptions.Add("CHECKSUM", "Checksum");
         ValidPageVerifyOptions.Add("TORN_PAGE_DETECTION", "Torn Page Detection");
         ValidPageVerifyOptions.Add("NONE", "None");

         ValidEnableBrokerOptions.Add("ENABLE_BROKER", "Enable Broker");
         ValidEnableBrokerOptions.Add("DISABLE_BROKER", "Disable Broker");
         ValidEnableBrokerOptions.Add("NEW_BROKER", "New Broker");
         ValidEnableBrokerOptions.Add("ERROR_BROKER_CONVERSATIONS", "Error Broker Conversations");

      }

      internal static List<ConfigurationSettings> GetDatabaseConfiguration(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
      {
         ConfigurationOptions _ConfigurationOptions = options as ConfigurationOptions;

         List<ConfigurationSettings> _SettingsList = new List<ConfigurationSettings>();
         lock (options)
         {
             using (SqlConnection _Connection = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials))
             {
                 Server _Server = new Server(new Microsoft.SqlServer.Management.Common.ServerConnection(_Connection));

                 string _VersionString = SQLHelpers.GetSqlVersionString(_Connection);
                 string _ServerVersion = "Unknown";
                 SQLVersion _SqlVersion;
                 if (SQLVersion.TryParse(_VersionString, out _SqlVersion))
                 {
                     _ServerVersion = string.Format("{0} ({1})", _SqlVersion.Name, _SqlVersion.Edition);
                 }

                 foreach (Database _Database in _Server.Databases)
                 {
                     if (SQLHelpers.Is2000orGreater(_Server.Information.Version.Major))
                     {
                         ConfigurationSettings _Settings = new ConfigurationSettings();
                         _Settings.Server = serverInformation;
                         _Settings.ServerVersion = _ServerVersion;
                         _Settings.DatabaseName = _Database.Name;
                         try
                         {
                             if (_Database.IsSystemObject && _ConfigurationOptions.IgnoreSystemDatabases)
                             {
                                 continue;
                             }
                             try
                             {
                                 _Settings.DatabaseOwner = _Database.Owner;
                             }
                             catch (SmoException)
                             {
                                 _Settings.DatabaseOwner = ProductConstants.ErrorCaptionCannotRetrieveDbOwner;
                             }
                             DateTime creationDate = _Database.CreateDate;
                             if (!_Database.IsSystemObject)
                             {
                                 try
                                 {
                                     creationDate =
                                         SQLHelpers.GetCreationDateForUserDatabase(serverInformation.Name,
                                                                                   serverInformation.SqlCredentials,
                                                                                   _Database.Name);
                                 }
                                 catch { }
                             }
                             _Settings.DateCreated = creationDate;
                             _Settings.Collation = _Database.Collation;
                             _Settings.Size = _Database.Size;
                             _Settings.NumberOfUsers = _Database.Users.Count;
                             _Settings.IsSystemDatabase = _Database.IsSystemObject;
                             _Settings.CompatibilityLevel = _Database.CompatibilityLevel.ToString().Replace("Version", string.Empty);
                             _Settings.Source = DataSource.LiveData;
                             _Settings.DateCaptured = DateTime.Now;

                             _Settings.AutoClose.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.AutoClose);
                             _Settings.AutoCreateStatistics.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.AutoCreateStatistics);
                             _Settings.AutoUpdateStatistics.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.AutoUpdateStatistics);
                             _Settings.AutoShrink.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.AutoShrink);


                             _Settings.CursorCloseOnCommit.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.CloseCursorsOnCommitEnabled);
                             _Settings.CursorDefaultScope.Value = _Database.DatabaseOptions.LocalCursorsDefault ? DatabaseConfigurationHelper.ValidCursorDefaultValues["LOCAL"] : DatabaseConfigurationHelper.ValidCursorDefaultValues["GLOBAL"];


                             if ((_Database.Status & DatabaseStatus.Offline) == DatabaseStatus.Offline)
                             {
                                 _Settings.State = DatabaseConfigurationHelper.ValidDatabaseStateValues["OFFLINE"];
                             }
                             else if ((_Database.Status & DatabaseStatus.Normal) == DatabaseStatus.Normal)
                             {
                                 _Settings.State = DatabaseConfigurationHelper.ValidDatabaseStateValues["ONLINE"];
                             }
                             else if ((_Database.Status & DatabaseStatus.EmergencyMode) == DatabaseStatus.EmergencyMode)
                             {
                                 _Settings.State = DatabaseConfigurationHelper.ValidDatabaseStateValues["EMERGENCY"];
                             }
                             else if ((_Database.Status & DatabaseStatus.Restoring) == DatabaseStatus.Restoring)
                             {
                                 _Settings.State = DatabaseConfigurationHelper.ValidDatabaseStateValues["RESTORING"];
                             }
                             else if ((_Database.Status & DatabaseStatus.Recovering) == DatabaseStatus.Recovering)
                             {
                                 _Settings.State = DatabaseConfigurationHelper.ValidDatabaseStateValues["RECOVERING"];
                             }
                             else if ((_Database.Status & DatabaseStatus.RecoveryPending) == DatabaseStatus.RecoveryPending)
                             {
                                 _Settings.State = DatabaseConfigurationHelper.ValidDatabaseStateValues["RECOVERY PENDING"];
                             }
                             else if ((_Database.Status & DatabaseStatus.Suspect) == DatabaseStatus.Suspect)
                             {
                                 _Settings.State = DatabaseConfigurationHelper.ValidDatabaseStateValues["SUSPECT"];
                             }
                             _Settings.DataAccess.Value = _Database.DatabaseOptions.ReadOnly ? DatabaseConfigurationHelper.ValidDatabaseIsReadOnlyModeValues["READ_ONLY"] : DatabaseConfigurationHelper.ValidDatabaseIsReadOnlyModeValues["READ_WRITE"];

                             _Settings.RestrictAccess.Value = GetUserAccessConfigurationValue(_Database.DatabaseOptions.UserAccess);

                             _Settings.Recovery.Value = GetRecoveryModelConfigurationValue(_Database.DatabaseOptions.RecoveryModel);

                             _Settings.AnsiNullDefault.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.AnsiNullDefault);
                             _Settings.AnsiNullsEnabled.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.AnsiNullsEnabled);
                             _Settings.AnsiPaddingEnabled.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.AnsiPaddingEnabled);
                             _Settings.AnsiWarningsEnabled.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.AnsiWarningsEnabled);
                             _Settings.ArithmeticAbortEnabled.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.ArithmeticAbortEnabled);
                             _Settings.ConcatenatedNullYieldsNull.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.ConcatenateNullYieldsNull);
                             _Settings.QuotedIdentifiersEnabled.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.QuotedIdentifiersEnabled);
                             _Settings.NumericRoundAbort.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.NumericRoundAbortEnabled);
                             _Settings.RecursiveTriggersEnabled.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.RecursiveTriggersEnabled);

                             if (SQLHelpers.Is2005orGreater(_Server.Information.Version.Major))
                             {
                                 _Settings.AutoUpdateStatisticsAsync.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.AutoUpdateStatisticsAsync);
                                 _Settings.DateCorrelationOptimizationEnabled.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.DateCorrelationOptimization);
                                 _Settings.IsTrustWorthy.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.Trustworthy);
                                 _Settings.Parameterization.Value = _Database.DatabaseOptions.IsParameterizationForced ? DatabaseConfigurationHelper.ValidParameterizationValues["FORCED"] : DatabaseConfigurationHelper.ValidParameterizationValues["SIMPLE"];
                                 _Settings.EnableBroker.Value = _Database.DatabaseOptions.BrokerEnabled ? DatabaseConfigurationHelper.ValidEnableBrokerOptions["ENABLE_BROKER"] : DatabaseConfigurationHelper.ValidEnableBrokerOptions["DISABLE_BROKER"];
                                 _Settings.AllowSnapshotIsolation.Value = GetBooleanConfigurationValue((_Database.DatabaseOptions.SnapshotIsolationState == SnapshotIsolationState.Enabled || _Database.DatabaseOptions.SnapshotIsolationState == SnapshotIsolationState.PendingOn));
                                 //SQLADMI-350
                                 _Settings.ReadCommittedSnapshot.Value = GetReadIsolationConfigurationValue(_Database.IsReadCommittedSnapshotOn);
                                 _Settings.PageVerifyMode.Value = GetPageVerifyConfigurationValue(_Database.DatabaseOptions.PageVerify);
                                 _Settings.DatabaseChaining.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.DatabaseOwnershipChaining);
                             }
                             else
                             {
                                 _Settings.TornPageDetection.Value = GetBooleanConfigurationValue(_Database.DatabaseOptions.PageVerify == PageVerify.TornPageDetection);
                             }
                         }
                         catch (Exception e)
                         {
                             _Settings.DataException = e;
                         }
                         _SettingsList.Add(_Settings);
                     }
                 }
                 _Connection.Close();
             }
         }
            
         return _SettingsList;
      }

      internal static ConfigurationChangeResults UpdateDatabaseConfiguration(ServerInformation serverInformation, string databaseName, ConfigurationData data)
      {
         ConfigurationChangeResults _Results = null;
         try
         {
            string _Sql;
            
            if (data.InternalName.Length == 0)
            {
               _Sql = string.Format("ALTER DATABASE [{0}] SET {1}", databaseName, data.InternalValue);
            }
            else
            {
               _Sql = string.Format("ALTER DATABASE [{0}] SET {1} {2}", databaseName, data.InternalName, data.InternalValue);
            }

            using (SqlConnection _Connection = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials))
            {
               using (SqlCommand _Command = new SqlCommand(_Sql))
               {
                  _Command.Connection = _Connection;
                  _Command.CommandTimeout = ToolsetOptions.commandTimeout;

                  _Command.ExecuteNonQuery();
               }
               _Connection.Close();
            }
            _Results = new ConfigurationChangeResults(serverInformation, databaseName, data, true);
         }
         catch (Exception exc)
         {
            _Results = new ConfigurationChangeResults(serverInformation, databaseName, data, false, exc);
         }
         return _Results;
      }

      private static string GetBooleanConfigurationValue(bool value)
      {
         return value ? DatabaseConfigurationHelper.ValidBooleanValues["ON"] : DatabaseConfigurationHelper.ValidBooleanValues["OFF"];
      }

      private static string GetReadIsolationConfigurationValue(bool value)
      {
          return value ? DatabaseConfigurationHelper.ValidReadIsolationOptions["ON"] : DatabaseConfigurationHelper.ValidReadIsolationOptions["OFF"];
      }

      private static string GetUserAccessConfigurationValue(DatabaseUserAccess access)
      {
         switch (access)
         {
            case DatabaseUserAccess.Multiple:
               return DatabaseConfigurationHelper.ValidDatabaseAccessModeValues["MULTI_USER"];
            case DatabaseUserAccess.Restricted:
               return DatabaseConfigurationHelper.ValidDatabaseAccessModeValues["RESTRICTED_USER"];
            case DatabaseUserAccess.Single:
               return DatabaseConfigurationHelper.ValidDatabaseAccessModeValues["SINGLE_USER"];
            default:
               throw new NotSupportedException(string.Format("The requested value is not supported: {0}", access));
         }
      }

      private static string GetRecoveryModelConfigurationValue(RecoveryModel model)
      {
         switch (model)
         {
            case RecoveryModel.BulkLogged:
               return DatabaseConfigurationHelper.ValidRecoveryMode["BULK_LOGGED"];
            case RecoveryModel.Full:
               return DatabaseConfigurationHelper.ValidRecoveryMode["FULL"];
            case RecoveryModel.Simple:
               return DatabaseConfigurationHelper.ValidRecoveryMode["SIMPLE"];
            default:
               throw new NotSupportedException(string.Format("The requested value is not supported: {0}", model));
         }
      }

      private static string GetPageVerifyConfigurationValue(PageVerify verify)
      {
         switch (verify)
         {
            case PageVerify.Checksum:
               return DatabaseConfigurationHelper.ValidPageVerifyOptions["CHECKSUM"];
            case PageVerify.TornPageDetection:
               return DatabaseConfigurationHelper.ValidPageVerifyOptions["TORN_PAGE_DETECTION"];
            case PageVerify.None:
               return DatabaseConfigurationHelper.ValidPageVerifyOptions["NONE"];
            default:
               throw new NotSupportedException(string.Format("The requested value is not supported: {0}", verify));
         }
      }


      public static Dictionary<string, string> ValidBooleanValues = new Dictionary<string, string>();
      public static Dictionary<string, string> ValidDatabaseAccessModeValues = new Dictionary<string, string>();
      public static Dictionary<string, string> ValidCursorDefaultValues = new Dictionary<string, string>();
      public static Dictionary<string, string> ValidDatabaseStateValues = new Dictionary<string, string>();
      public static Dictionary<string, string> ValidDatabaseIsReadOnlyModeValues = new Dictionary<string, string>();
      public static Dictionary<string, string> ValidParameterizationValues = new Dictionary<string, string>();
      public static Dictionary<string, string> ValidRecoveryMode = new Dictionary<string, string>();
      public static Dictionary<string, string> ValidPageVerifyOptions = new Dictionary<string, string>();
      public static Dictionary<string, string> ValidEnableBrokerOptions = new Dictionary<string, string>();
      public static Dictionary<string, string> ValidReadIsolationOptions = new Dictionary<string, string>();

   }
}
