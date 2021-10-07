using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

using BBS.TracerX;
using Idera.SqlAdminToolset.Core;
using Idera.SqlAdminToolset.JobMover.DataObjects;

namespace Idera.SqlAdminToolset.JobMover
{
    #region Enum

    public enum TaskToPerform
    {
        CopyJobsToDifferentServer,
        CopyJobsToSameServer,
        MoveJobsToDifferentServer
    }

    public enum TaskStep
    {
        [Description("Loading Job Information")]
        Initialize,
        [Description("Processing Job Information")]
        ProcessJobs,
        [Description("Processing Job Categories")]
        ProcessCategories,
        [Description("Processing Job Owners")]
        ProcessOwners,
        [Description("Processing Notification Operators")]
        ProcessOperators,
        [Description("Processing Job Steps")]
        ProcessSteps,
        [Description("Creating Jobs")]
        CreateJobs,

        // sub steps used for displaying process info
        [Description("Gathering Job Information")]
        SubGetJobs,
        [Description("Gathering Operator Information")]
        SubGetOperators,
        [Description("Validating Job Categories")]
        SubValidateCategories,
        [Description("Creating Job Categories")]
        SubCreateCategories,
        [Description("Validating Job Owners")]
        SubValidateOwners,
        [Description("Validating Notification Operators")]
        SubValidateOperators,
        [Description("Creating Notification Operators")]
        SubCreateOperators,
        [Description("Validating Job Step Databases")]
        SubValidateDatabases,
        [Description("Validating Job Names")]
        SubValidateJobNames,
        [Description("Creating Jobs")]
        SubDeleteSource,
        [Description("Completed Successfully")]
        CompleteSuccess,
        [Description("Failed")]
        CompleteFailed
    }

    public enum GetInfoType
    {
        Select,
        Copy
    }

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
        /// SQL Server 2000 to SQL Server 2005
        /// </summary>
        Sql2000To2005,

        /// <summary>
        /// SQL Server 2000 to SQL Server 2008
        /// </summary>
        Sql2000To2008,

        /// <summary>
        /// SQL Server 2000 to SQL Server 2012
        /// </summary>
        Sql2000To2012,
        /// <summary>
        /// SQL Server 2000 to SQL Server 2014
        /// </summary>
        Sql2000To2014,
        /// <summary>
        /// SQL Server 2000 to SQL Server 2016
        /// </summary>
        Sql2000To2016,
        /// <summary>
        /// SQL Server 2005 to SQL Server 2000 (security info only)
        /// </summary>
         Sql2000To2017,
        /// <summary>
        /// SQL Server 2005 to SQL Server 2000 (security info only)
        /// </summary>
        Sql2005To2000,

        /// <summary>
        /// SQL Server 2005 to SQL Server 2005
        /// </summary>
        Sql2005To2005,

        /// <summary>
        /// SQL Server 2005 to SQL Server 2008
        /// </summary>
        Sql2005To2008,

        /// <summary>
        /// SQL Server 2005 to SQL Server 2012
        /// </summary>
        Sql2005To2012,
        /// <summary>
        /// SQL Server 2005 to SQL Server 2014
        /// </summary>
        Sql2005To2014,
        /// <summary>
        /// SQL Server 2005 to SQL Server 2016
        /// </summary>
        Sql2005To2016,
        /// <summary>
        /// SQL Server 2008 to SQL Server 2000 (security info only)
        /// </summary>
         Sql2005To2017,
        /// <summary>
        /// SQL Server 2008 to SQL Server 2000 (security info only)
        /// </summary>
        Sql2008To2000,

        /// <summary>
        /// SQL Server 2008 to SQL Server 2005
        /// </summary>
        Sql2008To2005,

        /// <summary>
        /// SQL Server 2008 to SQL Server 2008
        /// </summary>
        Sql2008To2008,

        /// <summary>
        /// SQL Server 2008 to SQL Server 2012
        /// </summary>
        Sql2008To2012,
        /// <summary>
        /// SQL Server 2008 to SQL Server 2014
        /// </summary>
        Sql2008To2014,
        /// <summary>
        /// SQL Server 2008 to SQL Server 2016
        /// </summary>
        Sql2008To2016,
        /// <summary>
        /// SQL Server 2012 to SQL Server 2000 (security info only)
        /// </summary>
        Sql2008To2017,
        /// <summary>
        /// SQL Server 2012 to SQL Server 2000 (security info only)
        /// </summary>
        Sql2012To2000,

        /// <summary>
        /// SQL Server 2012 to SQL Server 2005
        /// </summary>
        Sql2012To2005,

        /// <summary>
        /// SQL Server 2012 to SQL Server 2008
        /// </summary>
        Sql2012To2008,

        /// <summary>
        /// SQL Server 2012 to SQL Server 2012
        /// </summary>
        Sql2012To2012,
        /// <summary>
        /// SQL Server 2012 to SQL Server 2014
        /// </summary>
        Sql2012To2014,
        /// <summary>
        /// SQL Server 2012 to SQL Server 2016
        /// </summary>
        Sql2012To2016,
        /// <summary>
        /// SQL Server 2014 to SQL Server 2000 (security info only)
        /// </summary>
        Sql2012To2017,
        /// <summary>
        /// SQL Server 2014 to SQL Server 2000 (security info only)
        /// </summary>
        Sql2014To2000,

        /// <summary>
        /// SQL Server 2014 to SQL Server 2005
        /// </summary>
        Sql2014To2005,

        /// <summary>
        /// SQL Server 2014 to SQL Server 2008
        /// </summary>
        Sql2014To2008,

        /// <summary>
        /// SQL Server 2014 to SQL Server 2012
        /// </summary>
        Sql2014To2012,
        /// <summary>
        /// SQL Server 2014 to SQL Server 2014
        /// </summary>
        Sql2014To2014,
        /// <summary>
        /// SQL Server 2014 to SQL Server 2016
        /// </summary>

        Sql2014To2016,
        /// <summary>
        /// SQL Server 2016 to SQL Server 2000 (security info only)
        /// </summary>
        /// 
        Sql2014To2017,
        /// <summary>
        /// SQL Server 2016 to SQL Server 2000 (security info only)
        /// </summary>
        Sql2016To2000,

        /// <summary>
        /// SQL Server 2016 to SQL Server 2005
        /// </summary>
        Sql2016To2005,

        /// <summary>
        /// SQL Server 2016 to SQL Server 2008
        /// </summary>
        Sql2016To2008,

        /// <summary>
        /// SQL Server 2016 to SQL Server 2012
        /// </summary>
        Sql2016To2012,
        /// <summary>
        /// SQL Server 2016 to SQL Server 2014
        /// </summary>
        Sql2016To2014,
        /// <summary>
        /// SQL Server 2016 to SQL Server 2016
        /// </summary>
         Sql2016To2017,
        /// <summary>
        /// SQL Server 2016 to SQL Server 2016
        /// </summary>
        Sql2016To2016,
            /// <summary>
            ///  SQL Server 2016 to SQL Server 2016
            /// </summary>
        Sql2017To2000,

        /// <summary>
        /// SQL Server 2016 to SQL Server 2005
        /// </summary>
        Sql2017To2005,

        /// <summary>
        /// SQL Server 2016 to SQL Server 2008
        /// </summary>
        Sql2017To2008,

        /// <summary>
        /// SQL Server 2016 to SQL Server 2012
        /// </summary>
        Sql2017To2012,
        /// <summary>
        /// SQL Server 2016 to SQL Server 2014
        /// </summary>
        Sql2017To2014,
        /// <summary>
        /// SQL Server 2016 to SQL Server 2016
        /// </summary>
        Sql2017To2016,
        /// <summary>
        /// SQL Server 2016 to SQL Server 2016
        /// </summary>
        Sql2017To2017


    }

    #endregion

    #endregion

    public class JobData
    {
        #region enums and constants

        public enum JobEnabled
        {
            [Description("Yes")]
            Enabled = 1,
            [Description("No")]
            Disabled = 0
        }

        public enum JobOutcome
        {
            Failed = 0,
            Succeeded = 1,
            Canceled = 3,
            Unknown = 5
        }

        public enum JobExecutionStatus
        {
            [Description("Returns only those jobs that are not idle or suspended")]
            NotIdle = 0,
            Executing = 1,
            [Description("Waiting for thread")]
            Waiting = 2,
            [Description("Between retries")]
            Retry = 3,
            Idle = 4,
            Suspended = 5,
            [Description("Performing completion actions")]
            Completing = 7
        }

        public enum JobType
        {
            [Description("Job has no target servers")]
            None = 0,
            [Description("Local job")]
            Local = 1,
            [Description("Multiserver job")]
            MultiServer = 2
        }

        public enum NotifyType
        {
            [Description("No notifications set")]
            None = 0,
            [Description("Event Log")]
            EventLog = 1,
            Email = 2,
            [Description("Net Send")]
            NetSend = 3,
            [Description("Pager")]
            Page = 4,
            Any = 5
        }

        public enum NotifyLevel
        {
            Never = 0,
            [Description("When the job succeeds")]
            Succeeds = 1,
            [Description("When the job fails")]
            Fails = 2,
            [Description("When the job completes")]
            Completes = 3
        }

        public enum JobTimeframe
        {
            [Description("The job has never run")]
            Never = 0,
            [Description("In the last hour")]
            InTheLastHour = 1,
            [Description("In the last day")]
            InTheLastDay = 2,
            [Description("In the last week")]
            InTheLastWeek = 3,
            [Description("In the last Month")]
            InTheLastMonth = 4
        }

        #endregion

        #region helpers

        public static string GetEnumDescription(object o)
        {
            System.Type otype = o.GetType();
            if (otype.IsEnum)
            {
                FieldInfo field = otype.GetField(Enum.GetName(otype, o));
                if (field != null)
                {
                    object[] attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    if (attributes.Length > 0)
                        return ((DescriptionAttribute)attributes[0]).Description;
                }
            }
            return o.ToString();
        }

        public static string GetEnumDescription(Type type, int value)
        {
            if (type.IsEnum)
            {
                FieldInfo field = type.GetField(Enum.GetName(type, value));
                if (field != null)
                {
                    object[] attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    if (attributes.Length > 0)
                        return ((DescriptionAttribute)attributes[0]).Description;
                    else
                        return Enum.GetName(type, value);
                }
            }
            return value.ToString();
        }

        #endregion

        #region data objects

        public class JobList
        {
            // this is the data object used to hold job info returned from the server
            // and calculate various counts on the data
            #region constants

            public static string ColSelect = "Select";
            public static string ColServer = "Server";
            public static string ColJobId = "JobId";
            public static string ColJobName = "JobName";
            public static string ColEnabled = "Enabled";
            public static string ColCategory = "Category";
            public static string ColOwner = "Owner";
            public static string ColStatus = "Status";
            public static string ColLastRun = "LastRun";
            public static string ColNextRun = "NextRun";
            public static string ColNotifyLevelEventLog = "NotifyLevelEventLog";
            public static string ColNotifyLevelEmail = "NotifyLevelEmail";
            public static string ColNotifyOperatorEmail = "NotifyOperatorEmail";
            public static string ColNotifyLevelNetSend = "NotifyLevelNetSend";
            public static string ColNotifyOperatorNetSend = "NotifyOperatorNetSend";
            public static string ColNotifyLevelPage = "NotifyLevelPage";
            public static string ColNotifyOperatorPage = "NotifyOperatorPage";
            public static string ColDateCreated = "DateCreated";
            public static string ColLastModified = "LastModified";
            public static string ColDescription = "Description";

            #endregion

            #region fields

            #endregion

            #region constructors

            public JobList()
            {
                Jobs = CreateTable();
            }

            #endregion

            #region properties

            public DataTable Jobs;

            #endregion

            #region methods

            public static DataTable CreateTable()
            {
                DataTable dt = new DataTable("JobInfoTable");

                dt.Columns.Add(new DataColumn(ColSelect, typeof(bool)));
                dt.Columns.Add(new DataColumn(ColJobId, typeof(Guid)));
                dt.Columns.Add(new DataColumn(ColServer, typeof(string)));
                dt.Columns.Add(new DataColumn(ColJobName, typeof(string)));
                dt.Columns.Add(new DataColumn(ColEnabled, typeof(JobData.JobEnabled)));
                dt.Columns.Add(new DataColumn(ColCategory, typeof(string)));
                dt.Columns.Add(new DataColumn(ColOwner, typeof(string)));
                dt.Columns.Add(new DataColumn(ColStatus, typeof(JobData.JobOutcome)));
                dt.Columns.Add(new DataColumn(ColLastRun, typeof(DateTime)));
                dt.Columns.Add(new DataColumn(ColNextRun, typeof(DateTime)));
                dt.Columns.Add(new DataColumn(ColNotifyLevelEventLog, typeof(JobData.NotifyLevel)));
                dt.Columns.Add(new DataColumn(ColNotifyLevelEmail, typeof(JobData.NotifyLevel)));
                dt.Columns.Add(new DataColumn(ColNotifyOperatorEmail, typeof(string)));
                dt.Columns.Add(new DataColumn(ColNotifyLevelNetSend, typeof(JobData.NotifyLevel)));
                dt.Columns.Add(new DataColumn(ColNotifyOperatorNetSend, typeof(string)));
                dt.Columns.Add(new DataColumn(ColNotifyLevelPage, typeof(JobData.NotifyLevel)));
                dt.Columns.Add(new DataColumn(ColNotifyOperatorPage, typeof(string)));
                dt.Columns.Add(new DataColumn(ColDateCreated, typeof(DateTime)));
                dt.Columns.Add(new DataColumn(ColLastModified, typeof(DateTime)));
                dt.Columns.Add(new DataColumn(ColDescription, typeof(string)));

                return dt;
            }

            #endregion
        }

        public class JobCategory
        {
            // these are the columns returned by the sp_help_category stored procedure
            public static string ColId = "category_id";
            public static string ColType = "category_type";
            public static string ColName = "name";

            public static DataTable CreateCategoryTable()
            {
                return JobData.NameList.CreateTable("JobCategories");
            }
        }

        public class JobInfo
        {
            // these are the columns returned by the sp_help_job stored procedure
            public static string ColJobId = @"job_id";
            public static string ColServer = @"originating_server";
            public static string ColJobName = @"name";
            public static string ColEnabled = @"enabled";
            //   public static string ColDisabled = @"disabled";
            public static string ColDescription = @"description";
            public static string ColCategory = @"category";
            public static string ColOwner = @"owner";
            public static string ColDateCreated = @"date_created";
            public static string ColDateModified = @"date_modified";
            public static string ColLastRunDate = @"last_run_date";
            public static string ColLastRunTime = @"last_run_time";
            public static string ColLastRunOutcome = @"last_run_outcome";
            public static string ColNextRunDate = @"next_run_date";
            public static string ColNextRunTime = @"next_run_time";
            public static string ColNotifyLevelEventLog = @"notify_level_eventlog";
            public static string ColNotifyLevelEmail = @"notify_level_email";
            public static string ColNotifyLevelNetSend = @"notify_level_netsend";
            public static string ColNotifyLevelPage = @"notify_level_page";
            public static string ColNotifyOperatorEmail = @"notify_email_operator";
            public static string ColNotifyOperatorNetSend = @"notify_netsend_operator";
            public static string ColNotifyOperatorPage = @"notify_page_operator";
        }

        public class NameList
        {
            // this is a generic list holder for the names of categories, owners, etc. from the server
            public static string ColServer = "server";
            public static string ColName = "name";

            public static DataTable CreateTable(string tableName)
            {
                DataTable dt = new DataTable(tableName);

                dt.Columns.Add(new DataColumn(ColServer, typeof(string)));
                dt.Columns.Add(new DataColumn(ColName, typeof(string)));

                return dt;
            }
        }

        public class JobOperator
        {
            // this is a generic list holder for the names of categories, owners, etc. from the server
            public static string ColName = "name";
            public static string ColId = "id";
        }

        #endregion
    }

    public class JobMoverRoutines
    {
        private static string cmdQueryJobs = @"msdb..sp_help_job";
        private static string cmdQueryCategories = @"msdb..sp_help_category";
        private static string cmdQueryOwners2000 = @"SELECT DISTINCT SUSER_SNAME() as name, ISNULL(IS_SRVROLEMEMBER(N'sysadmin'), 0) 
                                                   UNION 
                                                   SELECT DISTINCT loginname as name, sysadmin 
                                                   FROM master.dbo.syslogins 
                                                   WHERE (loginname IS NOT NULL) AND (isntgroup = 0)";
        private static string cmdQueryOwners2005 = @"SELECT log.name
                                                   FROM sys.server_principals AS log
                                                   WHERE (log.type in ('U', 'S') AND log.principal_id not between 101 and 255 AND log.name <> N'##MS_AgentSigningCertificate##')";
        private static string cmdQueryAdmin2000 = @"SELECT loginname as name
                                                   FROM master.dbo.syslogins 
                                                   WHERE sid = 0x01";
        private static string cmdQueryAdmin2005 = @"SELECT name
                                                   FROM sys.server_principals
                                                   WHERE sid = 0x01";
        private static string cmdQueryOperators = @"msdb..sp_help_operator";
        private static string cmdQueryDatabases2000 = @"select name from master..sysdatabases";
        private static string cmdQueryDatabases2005 = @"select name from master.sys.databases";
        private static string cmdAddCategory = @"msdb..sp_add_category";

        private static string paramCatClass = @"@class";
        private static string paramCatType = @"@type";
        private static string paramCatName = @"@name";
        private static object threadLock = new object();



        /// <summary>
        /// Create a valid DateTime value from the date info returned about a job that is in 2 ints
        /// </summary>
        /// <param name="runDate">an int representing the date portion of a job date</param>
        /// <param name="runTime">an int representing the time portion of a job date</param>
        /// <returns></returns>
        private static DateTime BuildJobRunTime(int runDate, int runTime)
        {
            DateTime dt = DateTime.MinValue;

            // this matches the sql validation in sp_verify_job_date and sp_verify_job_time
            if (runDate < 19900101 || runDate > 99991231 || runTime < 0 || runTime > 235959)
            {
                return dt;
            }

            try
            {
                // convert using the same logic as in the function agent_datetime
                int year = runDate / 10000;
                int month = (runDate % 10000) / 100;
                int day = runDate % 100;
                int hour = runTime / 10000;
                int min = (runTime % 10000) / 100;
                int sec = runTime % 100;

                dt = new DateTime(year, month, day, hour, min, sec);
            }
            catch
            {

            }

            return dt;
        }

        /// <summary>
        /// Returns true if the requested operation is valid for the combination of source and destination servers.
        /// </summary>
        public static bool IsValidOperation(ServerInformation sourceServer, ServerInformation destinationServer)
        {
            return IsValidOperation(CheckVersion(sourceServer, destinationServer));
        }

        private static bool IsValidOperation(TransferVersionInfo versionInfo)
        {
            if ((versionInfo == TransferVersionInfo.NotSupported)
                || (versionInfo == TransferVersionInfo.Sql2008To2000)
                || ((versionInfo == TransferVersionInfo.Sql2012To2000))
                || versionInfo == TransferVersionInfo.Sql2014To2000)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the version combination for the requested operation.
        ///// </summary>
        private static TransferVersionInfo CheckVersion(ServerInformation sourceServer, ServerInformation destinationServer)
        {
            TransferVersionInfo _VersionInfo = TransferVersionInfo.NotSupported;

            SqlConnection connSource;
            try
            {
                connSource = Connection.OpenConnection(sourceServer.Name, sourceServer.SqlCredentials);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to retrieve version information for source server", ex);
            }
            finally
            {
                Connection.Impersonate(null);
            }
            SqlConnection connDest;
            try
            {
                connDest = Connection.OpenConnection(destinationServer.Name, destinationServer.SqlCredentials);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to retrieve version information for destination server", ex);
            }
            finally
            {
                Connection.Impersonate(null);
            }
            if (SQLHelpers.Is2000(connSource))
            {
                if (SQLHelpers.Is2000(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2000To2000;
                }
                else if (SQLHelpers.Is2005(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2000To2005;
                }
                else if (SQLHelpers.Is2008(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2000To2008;
                }
                else if (SQLHelpers.Is2012(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2000To2012;
                }
                else if (SQLHelpers.Is2014(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2000To2014;
                }
                else if (SQLHelpers.Is2016(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2000To2016;
                }
                else if (SQLHelpers.Is2017orGreater(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2000To2017;
                }
            }
            else if (SQLHelpers.Is2005(connSource))
            {
                if (SQLHelpers.Is2000(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2005To2000;
                }
                else if (SQLHelpers.Is2005(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2005To2005;
                }
                else if (SQLHelpers.Is2008(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2005To2008;
                }
                else if (SQLHelpers.Is2012(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2005To2012;
                }
                else if (SQLHelpers.Is2014(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2005To2014;
                }
                else if (SQLHelpers.Is2016(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2005To2016;
                }
                else if (SQLHelpers.Is2017orGreater(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2000To2017;
                }

            }
            else if (SQLHelpers.Is2008(connSource))
            {
                if (SQLHelpers.Is2000(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2008To2000;
                }
                else if (SQLHelpers.Is2005(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2008To2005;
                }
                else if (SQLHelpers.Is2008(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2008To2008;
                }
                else if (SQLHelpers.Is2012(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2008To2012;
                }
                else if (SQLHelpers.Is2014(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2008To2014;
                }
                else if (SQLHelpers.Is2016(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2008To2016;
                }
                else if (SQLHelpers.Is2017orGreater(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2008To2017;
                }

            }
            else if (SQLHelpers.Is2012(connSource))
            {
                if (SQLHelpers.Is2000(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2012To2000;
                }
                else if (SQLHelpers.Is2005(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2012To2005;
                }
                else if (SQLHelpers.Is2008(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2012To2008;
                }
                else if (SQLHelpers.Is2012(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2012To2012;
                }
                else if (SQLHelpers.Is2014orGreater(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2012To2014;
                }
                else if (SQLHelpers.Is2016(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2012To2016;
                }
                else if (SQLHelpers.Is2017orGreater(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2008To2017;
                }

            }
            else if (SQLHelpers.Is2014(connSource))
            {
                if (SQLHelpers.Is2000(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2014To2000;
                }
                else if (SQLHelpers.Is2005(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2014To2005;
                }
                else if (SQLHelpers.Is2008(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2014To2008;
                }
                else if (SQLHelpers.Is2012(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2014To2012;
                }
                else if (SQLHelpers.Is2014(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2014To2014;
                }
                else if (SQLHelpers.Is2016(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2014To2016;
                }
                else if (SQLHelpers.Is2017orGreater(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2014To2017;
                }

            }
            else if (SQLHelpers.Is2016(connSource))
            {
                if (SQLHelpers.Is2000(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2016To2000;
                }
                else if (SQLHelpers.Is2005(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2016To2005;
                }
                else if (SQLHelpers.Is2008(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2016To2008;
                }
                else if (SQLHelpers.Is2012(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2016To2012;
                }
                else if (SQLHelpers.Is2014(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2016To2014;
                }
                else if (SQLHelpers.Is2016(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2016To2016;
                }
                else if (SQLHelpers.Is2017orGreater(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2017To2017;
                }

            }
            else if (SQLHelpers.Is2017orGreater(connSource))
            {
                if (SQLHelpers.Is2000(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2017To2000;
                }
                else if (SQLHelpers.Is2005(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2017To2005;
                }
                else if (SQLHelpers.Is2008(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2017To2008;
                }
                else if (SQLHelpers.Is2012(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2017To2012;
                }
                else if (SQLHelpers.Is2014(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2017To2014;
                }
                else if (SQLHelpers.Is2016(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2017To2016;
                }
                else if (SQLHelpers.Is2017orGreater(connDest))
                {
                    _VersionInfo = TransferVersionInfo.Sql2017To2017;
                }

            }

            return _VersionInfo;
        }

        #region Job Pool Tasks

        public static DataTable LoadJobInfo(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
            DataTable results = JobData.JobList.CreateTable();

            SqlConnection conn = null;

            try
            {
                conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials);

                using (SqlCommand cmd = new SqlCommand(cmdQueryJobs, conn))
                {
                    cmd.CommandTimeout = commandTimeout;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DataRow dr = results.NewRow();

                        dr[JobData.JobList.ColSelect] = false;
                        dr[JobData.JobList.ColJobId] = SQLHelpers.GetRowGuid(row, JobData.JobInfo.ColJobId);
                        dr[JobData.JobList.ColServer] = SQLHelpers.GetRowString(row, JobData.JobInfo.ColServer);
                        dr[JobData.JobList.ColJobName] = SQLHelpers.GetRowString(row, JobData.JobInfo.ColJobName);

                        //if (jobEnable == false && jobDisable == false)
                        //{
                        //    dr[JobData.JobList.ColEnabled] = SQLHelpers.GetRowByte(row, JobData.JobInfo.ColEnabled);
                        //}
                        //else if (jobEnable == true && jobDisable == false)
                        //{
                        //    dr[JobData.JobList.ColEnabled] = SQLHelpers.GetRowByte(row, JobData.JobInfo.ColEnabled);
                        //}
                        //else if (jobEnable == false && jobDisable == true)
                        //{
                        //    dr[JobData.JobList.ColEnabled] = 0;
                        //}

                        dr[JobData.JobList.ColEnabled] = SQLHelpers.GetRowByte(row, JobData.JobInfo.ColEnabled);
                        dr[JobData.JobList.ColCategory] = SQLHelpers.GetRowString(row, JobData.JobInfo.ColCategory);
                        dr[JobData.JobList.ColOwner] = SQLHelpers.GetRowString(row, JobData.JobInfo.ColOwner);
                        dr[JobData.JobList.ColStatus] = SQLHelpers.GetRowInt32(row, JobData.JobInfo.ColLastRunOutcome);
                        dr[JobData.JobList.ColLastRun] = BuildJobRunTime(SQLHelpers.GetRowInt32(row, JobData.JobInfo.ColLastRunDate), SQLHelpers.GetRowInt32(row, JobData.JobInfo.ColLastRunTime));
                        dr[JobData.JobList.ColNextRun] = BuildJobRunTime(SQLHelpers.GetRowInt32(row, JobData.JobInfo.ColNextRunDate), SQLHelpers.GetRowInt32(row, JobData.JobInfo.ColNextRunTime));
                        dr[JobData.JobList.ColNotifyLevelEventLog] = SQLHelpers.GetRowInt32(row, JobData.JobInfo.ColNotifyLevelEventLog);
                        dr[JobData.JobList.ColNotifyLevelEmail] = SQLHelpers.GetRowInt32(row, JobData.JobInfo.ColNotifyLevelEmail);
                        dr[JobData.JobList.ColNotifyOperatorEmail] = SQLHelpers.GetRowString(row, JobData.JobInfo.ColNotifyOperatorEmail);
                        dr[JobData.JobList.ColNotifyLevelNetSend] = SQLHelpers.GetRowInt32(row, JobData.JobInfo.ColNotifyLevelNetSend);
                        dr[JobData.JobList.ColNotifyOperatorNetSend] = SQLHelpers.GetRowString(row, JobData.JobInfo.ColNotifyOperatorNetSend);
                        dr[JobData.JobList.ColNotifyLevelPage] = SQLHelpers.GetRowInt32(row, JobData.JobInfo.ColNotifyLevelPage);
                        dr[JobData.JobList.ColNotifyOperatorPage] = SQLHelpers.GetRowString(row, JobData.JobInfo.ColNotifyOperatorPage);
                        dr[JobData.JobList.ColDateCreated] = SQLHelpers.GetRowDateTime(row, JobData.JobInfo.ColDateCreated);
                        dr[JobData.JobList.ColLastModified] = SQLHelpers.GetRowDateTime(row, JobData.JobInfo.ColDateModified);
                        dr[JobData.JobList.ColDescription] = SQLHelpers.GetRowString(row, JobData.JobInfo.ColDescription);

                        results.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = String.Format(ProductConstants.ErrorLoadingJobs, Helpers.GetCombinedExceptionText(ex));
                throw new Exception(msg);
            }
            finally
            {
                Connection.CloseConnection(conn);
            }

            return results;
        }

        public static DataTable LoadJobCategories(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
            DataTable categories = JobData.JobCategory.CreateCategoryTable();

            SqlConnection conn = null;

            try
            {
                conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials);

                using (SqlCommand cmd = new SqlCommand(cmdQueryCategories, conn))
                {
                    cmd.CommandTimeout = commandTimeout;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DataRow dr = categories.NewRow();

                        //dr[JobData.JobCategory.ColServer] = serverInformation.Name;
                        //dr[JobData.JobCategory.ColId] = SQLHelpers.GetRowInt32(row, JobData.JobCategory.ColId);
                        //dr[JobData.JobCategory.ColType] = SQLHelpers.GetRowByte(row, JobData.JobCategory.ColType);
                        //dr[JobData.JobCategory.ColName] = SQLHelpers.GetRowString(row, JobData.JobCategory.ColName);
                        dr[JobData.NameList.ColServer] = serverInformation.Name;
                        dr[JobData.NameList.ColName] = SQLHelpers.GetRowString(row, JobData.JobCategory.ColName);

                        categories.Rows.Add(dr);
                    }
                }
            }
            catch (SqlException ex)
            {
                string msg = String.Format(ProductConstants.ErrorSqlLoadingCategories, Helpers.GetCombinedExceptionText(ex));
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                string msg = String.Format(ProductConstants.ErrorHandlingObject, "Load", "Categories", Helpers.GetCombinedExceptionText(ex));
                throw new Exception(msg);
            }
            finally
            {
                Connection.CloseConnection(conn);
            }

            return categories;
        }

        public static DataTable LoadJobOwners(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
            SqlConnection conn = null;
            DataTable owners = JobData.NameList.CreateTable("Owners");

            try
            {
                conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials);

                string query;
                if (SQLHelpers.Is2005orGreater(conn))
                {
                    query = cmdQueryOwners2005;
                }
                else
                {
                    query = cmdQueryOwners2000;
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = commandTimeout;
                    cmd.CommandType = CommandType.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DataRow dr = owners.NewRow();

                        dr[JobData.NameList.ColServer] = serverInformation.Name;
                        dr[JobData.NameList.ColName] = SQLHelpers.GetRowString(row, JobData.NameList.ColName);

                        owners.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = String.Format(ProductConstants.ErrorLoadingOwners, Helpers.GetCombinedExceptionText(ex));
                throw new Exception(msg);
            }
            finally
            {
                Connection.CloseConnection(conn);
            }

            return owners;
        }

        public static string LoadAdminName(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
            SqlConnection conn = null;
            string adminName = string.Empty;
            try
            {
                conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials);

                string query;
                if (SQLHelpers.Is2005orGreater(conn))
                {
                    query = cmdQueryAdmin2005;
                }
                else
                {
                    query = cmdQueryAdmin2000;
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = commandTimeout;
                    cmd.CommandType = CommandType.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        adminName = SQLHelpers.GetRowString(row, JobData.NameList.ColName);
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = String.Format(ProductConstants.ErrorLoadingAdmin, Helpers.GetCombinedExceptionText(ex));
                throw new Exception(msg);
            }
            finally
            {
                Connection.CloseConnection(conn);
            }

            return adminName;
        }

        public static DataTable LoadJobOperators(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
            SqlConnection conn = null;
            DataTable operators = JobData.NameList.CreateTable("Operators");

            try
            {
                conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials);

                using (SqlCommand cmd = new SqlCommand(cmdQueryOperators, conn))
                {
                    cmd.CommandTimeout = commandTimeout;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DataRow dr = operators.NewRow();

                        dr[JobData.NameList.ColServer] = serverInformation.Name;
                        dr[JobData.NameList.ColName] = SQLHelpers.GetRowString(row, JobData.NameList.ColName);

                        operators.Rows.Add(dr);
                    }
                }
            }
            catch (SqlException ex)
            {
                string msg = String.Format(ProductConstants.ErrorSqlLoadingOperators, Helpers.GetCombinedExceptionText(ex));
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                string msg = String.Format(ProductConstants.ErrorLoadingOperators, Helpers.GetCombinedExceptionText(ex));
                throw new Exception(msg);
            }
            finally
            {
                Connection.CloseConnection(conn);
            }

            return operators;
        }

        public static SortedList<string, int> LoadJobOperatorIds(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
            SqlConnection conn = null;
            SortedList<string, int> operators = new SortedList<string, int>();

            try
            {
                conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials);

                using (SqlCommand cmd = new SqlCommand(cmdQueryOperators, conn))
                {
                    cmd.CommandTimeout = commandTimeout;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        operators.Add(SQLHelpers.GetRowString(row, JobData.JobOperator.ColName),
                                       SQLHelpers.GetRowInt32(row, JobData.JobOperator.ColId));
                    }
                }
            }
            catch (SqlException ex)
            {
                string msg = String.Format(ProductConstants.ErrorSqlLoadingOperators, Helpers.GetCombinedExceptionText(ex));
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                string msg = String.Format(ProductConstants.ErrorLoadingOperators, Helpers.GetCombinedExceptionText(ex));
                throw new Exception(msg);
            }
            finally
            {
                Connection.CloseConnection(conn);
            }

            return operators;
        }

        public static DataTable LoadDatabases(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
            SqlConnection conn = null;
            DataTable databases = JobData.NameList.CreateTable("Databases");

            try
            {
                conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials);

                string query;
                if (SQLHelpers.Is2005orGreater(conn))
                {
                    query = cmdQueryDatabases2005;
                }
                else
                {
                    query = cmdQueryDatabases2000;
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = commandTimeout;
                    cmd.CommandType = CommandType.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DataRow dr = databases.NewRow();

                        dr[JobData.NameList.ColServer] = serverInformation.Name;
                        dr[JobData.NameList.ColName] = SQLHelpers.GetRowString(row, JobData.NameList.ColName);

                        databases.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = String.Format(ProductConstants.ErrorLoadingDatabases, Helpers.GetCombinedExceptionText(ex));
                throw new Exception(msg);
            }
            finally
            {
                Connection.CloseConnection(conn);
            }

            return databases;
        }

        public static GetTaskResults LoadSourceInfo(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
            SqlConnection conn = null;
            GetTaskResults results = new GetTaskResults(serverInformation.Name, options);
            JobMoverOptions copyOptions = (JobMoverOptions)options;
            lock (threadLock)
            {
                try
                {


                    conn = Connection.OpenConnection(serverInformation.Name, "msdb", serverInformation.SqlCredentials);

                    copyOptions.RaiseStatus(TaskStep.Initialize, JobData.GetEnumDescription(TaskStep.SubGetJobs));
                    DataTable jobsTable = JobMoverRoutines.LoadJobInfo(serverInformation, ToolsetOptions.commandTimeout, new JobPoolOptions());

                    // if no jobs are passed, then return all
                    if (copyOptions.Jobs.Count == 0)
                    {
                        foreach (DataRow row in jobsTable.Rows)
                        {
                            results.Jobs.Add((string)row[JobData.JobList.ColJobName], new Job(serverInformation, conn, (Guid)row[JobData.JobList.ColJobId]));
                        }
                    }
                    else
                    {
                        // if a job list is passed, then return a list of refreshed jobs from that list
                        string jobName = string.Empty;
                        foreach (Job job in copyOptions.Jobs)
                        {
                            jobName = job.JobName.Replace("'", "''");
                            jobsTable.DefaultView.RowFilter = JobData.JobList.ColJobName + " = '" + jobName + "'";
                            if (jobsTable.DefaultView.Count > 0)
                            {
                                DataRowView row = jobsTable.DefaultView[0];
                                jobName = (string)row[JobData.JobList.ColJobName];

                                results.Jobs.Add(jobName, new Job(serverInformation, conn, (Guid)row[JobData.JobList.ColJobId]));

                            }
                            else
                            {
                                string msg = String.Format(ProductConstants.ErrorLoadingJobs, jobName);
                                copyOptions.RaiseStatus(TaskStep.CompleteFailed);
                            }
                        }
                    }
                    copyOptions.RaiseStatus(TaskStep.CompleteSuccess);

                    if (copyOptions.IncludeNotifications && copyOptions.CreateOperators)
                    {
                        copyOptions.RaiseStatus(TaskStep.Initialize, JobData.GetEnumDescription(TaskStep.SubGetOperators));
                        SortedList<string, int> operatorIds = JobMoverRoutines.LoadJobOperatorIds(serverInformation, ToolsetOptions.commandTimeout, new JobPoolOptions());

                        foreach (KeyValuePair<string, int> oper in operatorIds)
                        {
                            results.Operators.Add(oper.Key, new Operator(conn, oper.Value));
                        }
                        copyOptions.RaiseStatus(TaskStep.CompleteSuccess);
                    }
                }
                catch (Exception ex)
                {
                    string msg = String.Format(ProductConstants.ErrorLoadingJobs, Helpers.GetCombinedExceptionText(ex));
                    throw new Exception(msg);
                }
                finally
                {
                    Connection.CloseConnection(conn);
                }

                // results.Jobs.Clear();
                foreach (Job item in copyOptions.Jobs)
                {
                    results.Jobs.Remove(item.JobName);
                    if (item.MetaInfo.Enabled == false)
                    {
                        item.MetaInfo.Enabled = false;
                        results.Jobs.Add(item.JobName, item);
                    }
                    else
                    {
                        item.MetaInfo.Enabled = true;
                        results.Jobs.Add(item.JobName, item);
                    }
                }
            }

            return results;
        }

        public static JobTaskResults ValidateJobs(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
            SqlConnection conn = null;
            JobTaskResults results = new JobTaskResults(serverInformation.Name, options);
            JobMoverOptions copyOptions = (JobMoverOptions)options;
            lock (threadLock)
            {
                try
                {


                    conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials);

                    // process jobs for creation and build lists of all values to verify in one pass
                    List<string> jobCategories = new List<string>();
                    List<string> jobOwners = new List<string>();
                    List<string> jobOperators = new List<string>();
                    List<string> jobDatabases = new List<string>();

                    foreach (Job job in copyOptions.Jobs)
                    {
                        // save off the original job ids before creating new ones so they can be used for deleting source jobs 
                        copyOptions.OriginalJobIds.Add(job.JobName, job.JobId);

                        //remove schedules from jobs if not needed
                        if (!copyOptions.IncludeSchedules)
                        {
                            job.ClearSchedules();
                        }
                        //remove notifications from jobs if not needed
                        if (!copyOptions.IncludeNotifications)
                        {
                            job.ClearNotifications();
                        }
                        if (copyOptions.DestinationIsSource)
                        {
                            job.SetJobName("Copy of " + job.JobName);
                        }

                        //change the owner if required
                        if (copyOptions.AssignNewOwner)
                        {
                            job.MetaInfo.OwnerLoginName = copyOptions.OwnerName;
                        }

                        //change the database in each step if required
                        if (copyOptions.AssignNewDatabase)
                        {
                            foreach (JobStepInfo step in job.Steps.Values)
                            {
                                step.DatabaseName = copyOptions.DatabaseName;
                            }
                        }

                        // Add the modified jobs to the create list
                        results.JobsToProcess.Add(job);

                        if (!jobCategories.Contains(job.MetaInfo.CategoryName))
                        {
                            jobCategories.Add(job.MetaInfo.CategoryName);
                        }
                        if (!jobOwners.Contains(job.MetaInfo.OwnerLoginName))
                        {
                            jobOwners.Add(job.MetaInfo.OwnerLoginName);
                        }
                        if (copyOptions.IncludeNotifications)
                        {
                            if (!jobOperators.Contains(job.MetaInfo.NotifyEmailOperatorName))
                            {
                                jobOperators.Add(job.MetaInfo.NotifyEmailOperatorName);
                            }
                            if (!jobOperators.Contains(job.MetaInfo.NotifyNetsendOperatorName))
                            {
                                jobOperators.Add(job.MetaInfo.NotifyNetsendOperatorName);
                            }
                            if (!jobOperators.Contains(job.MetaInfo.NotifyPageOperatorName))
                            {
                                jobOperators.Add(job.MetaInfo.NotifyPageOperatorName);
                            }
                        }
                        foreach (JobStepInfo step in job.Steps.Values)
                        {
                            if (!jobDatabases.Contains(step.DatabaseName))
                            {
                                jobDatabases.Add(step.DatabaseName);
                            }
                        }
                    }


                    // Validate Job Names if not overwriting them
                    string jobName = string.Empty;
                    copyOptions.RaiseStatus(TaskStep.ProcessJobs, JobData.GetEnumDescription(TaskStep.SubValidateJobNames));
                    try
                    {
                        DataTable serverJobs = LoadJobInfo(serverInformation, commandTimeout, options);
                        if (copyOptions.Overwrite)
                        {
                            // just show success because we have gathered the job info and that is all there is to do
                            copyOptions.RaiseStatus(TaskStep.CompleteSuccess);
                        }
                        else
                        {

                            List<string> dupJobs = new List<string>();
                            foreach (Job job in copyOptions.Jobs)
                            {
                                jobName = job.JobName.Replace("'", "''");
                                serverJobs.DefaultView.RowFilter = JobData.JobList.ColJobName + " = '" + jobName + "'";
                                jobName = job.JobName;
                                if (serverJobs.DefaultView.Count > 0)
                                {
                                    dupJobs.Add(job.JobName);
                                    results.AddResult(TaskStep.ProcessJobs, jobName, JobTaskResults.Status.Failed, ProductConstants.ErrorDuplicateJobName);
                                }
                            }
                            if (dupJobs.Count > 0)
                            {
                                copyOptions.RaiseStatus(TaskStep.CompleteFailed);
                            }
                            else
                            {
                                copyOptions.RaiseStatus(TaskStep.CompleteSuccess);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        results.AddResult(TaskStep.ProcessJobs, jobName, JobTaskResults.Status.Failed, Helpers.GetCombinedExceptionText(ex));
                        copyOptions.RaiseStatus(TaskStep.CompleteFailed);
                    }


                    // Validate Categories
                    string category = string.Empty;
                    copyOptions.RaiseStatus(TaskStep.ProcessCategories, JobData.GetEnumDescription(TaskStep.SubValidateCategories));
                    try
                    {
                        DataTable serverCategories = LoadJobCategories(serverInformation, commandTimeout, options);
                        List<string> newCategories = new List<string>();
                        foreach (string cat in jobCategories)
                        {
                            category = cat;
                            serverCategories.DefaultView.RowFilter = JobData.JobCategory.ColName + " = '" + cat + "'";
                            if (serverCategories.DefaultView.Count == 0)
                            {
                                newCategories.Add(cat);
                            }
                        }
                        if (newCategories.Count > 0)
                        {
                            if (copyOptions.CreateCategories)
                            {
                                // Create Categories
                                copyOptions.RaiseStatus(TaskStep.ProcessCategories, JobData.GetEnumDescription(TaskStep.SubCreateCategories));
                                CreateCategoriesOptions catOptions = new CreateCategoriesOptions();
                                catOptions.Categories = newCategories;
                                JobTaskResults jr = CreateCategories(serverInformation, commandTimeout, catOptions);
                                results.AddResults(jr);
                                if (jr.FailedCount > 0)
                                {
                                    copyOptions.RaiseStatus(TaskStep.CompleteSuccess);
                                }
                                else
                                {
                                    copyOptions.RaiseStatus(TaskStep.CompleteFailed);
                                }
                            }
                            else
                            {
                                string msg = String.Format(ProductConstants.ErrorMissingCategories, string.Join(",", newCategories.ToArray()));
                                results.AddResult(TaskStep.ProcessCategories, category, JobTaskResults.Status.Failed, msg);
                                copyOptions.RaiseStatus(TaskStep.CompleteFailed);
                            }
                        }
                        else
                        {
                            copyOptions.RaiseStatus(TaskStep.CompleteSuccess);
                        }
                    }
                    catch (Exception ex)
                    {
                        results.AddResult(TaskStep.ProcessCategories, category, JobTaskResults.Status.Failed, Helpers.GetCombinedExceptionText(ex));
                        copyOptions.RaiseStatus(TaskStep.CompleteFailed);
                    }


                    // Validate Owners
                    string owner = string.Empty;
                    copyOptions.RaiseStatus(TaskStep.ProcessOwners, JobData.GetEnumDescription(TaskStep.SubValidateOwners));
                    try
                    {
                        DataTable serverOwners = LoadJobOwners(serverInformation, commandTimeout, options);
                        List<string> newOwners = new List<string>();
                        foreach (string own in jobOwners)
                        {
                            owner = own;
                            serverOwners.DefaultView.RowFilter = JobData.JobCategory.ColName + " = '" + own + "'";
                            if (serverOwners.DefaultView.Count == 0)
                            {
                                newOwners.Add(own);
                            }
                        }
                        if (newOwners.Count > 0)
                        {
                            if (copyOptions.OwnerName.Length > 0)
                            {
                                // attempt to set the jobs with owners not found to the default owner
                                owner = copyOptions.OwnerName;
                                serverOwners.DefaultView.RowFilter = JobData.JobCategory.ColName + " = '" + owner + "'";
                                if (serverOwners.DefaultView.Count == 0)
                                {
                                    // the default owner isn't found, so show an error on that
                                    string msg = String.Format(ProductConstants.ErrorDefaultOwnerNotFound, owner);
                                    results.AddResult(TaskStep.ProcessOwners, owner, JobTaskResults.Status.Failed, msg);
                                    copyOptions.RaiseStatus(TaskStep.CompleteFailed);

                                    // the owners can't be fixed, so treat these as missing owners
                                    msg = String.Format(ProductConstants.ErrorMissingOwners, string.Join(",", newOwners.ToArray()));
                                    results.AddResult(TaskStep.ProcessOwners, owner, JobTaskResults.Status.Failed, msg);
                                    copyOptions.RaiseStatus(TaskStep.CompleteFailed);
                                }
                                else
                                {
                                    // change any owners not found to the default owner
                                    foreach (Job job in results.JobsToProcess)
                                    {
                                        if (newOwners.Contains(job.MetaInfo.OwnerLoginName))
                                        {
                                            job.MetaInfo.OwnerLoginName = owner;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                string msg = String.Format(ProductConstants.ErrorMissingOwners, string.Join(",", newOwners.ToArray()));
                                results.AddResult(TaskStep.ProcessOwners, owner, JobTaskResults.Status.Failed, msg);
                                copyOptions.RaiseStatus(TaskStep.CompleteFailed);
                            }
                        }
                        else
                        {
                            copyOptions.RaiseStatus(TaskStep.CompleteSuccess);
                        }
                    }
                    catch (Exception ex)
                    {
                        results.AddResult(TaskStep.ProcessOwners, owner, JobTaskResults.Status.Failed, Helpers.GetCombinedExceptionText(ex));
                        copyOptions.RaiseStatus(TaskStep.CompleteFailed);
                    }

                    // Validate Operators
                    string oper = string.Empty;
                    copyOptions.RaiseStatus(TaskStep.ProcessOperators, JobData.GetEnumDescription(TaskStep.SubValidateOperators));
                    try
                    {
                        DataTable serverOperators = LoadJobOperators(serverInformation, commandTimeout, options);
                        List<string> newOperators = new List<string>();
                        foreach (string op in jobOperators)
                        {
                            oper = op;
                            if (op != "(unknown)")
                            {
                                serverOperators.DefaultView.RowFilter = JobData.JobCategory.ColName + " = '" + op + "'";
                                if (serverOperators.DefaultView.Count == 0)
                                {
                                    newOperators.Add(op);
                                }
                            }
                        }
                        if (newOperators.Count > 0)
                        {
                            if (copyOptions.CreateOperators)
                            {
                                // Create Operators
                                copyOptions.RaiseStatus(TaskStep.SubCreateOperators);
                                CreateOperatorsOptions operatorOptions = new CreateOperatorsOptions();
                                foreach (string op in newOperators)
                                {
                                    if (copyOptions.SourceOperators.ContainsKey(op))
                                    {
                                        operatorOptions.Operators.Add(op, copyOptions.SourceOperators[op]);
                                    }
                                    else
                                    {
                                        string msg = String.Format(ProductConstants.ErrorMissingOperators, op);
                                        results.AddResult(TaskStep.ProcessOperators, op, JobTaskResults.Status.Failed, msg);
                                        copyOptions.RaiseStatus(TaskStep.CompleteFailed);
                                    }
                                }

                                if (operatorOptions.Operators.Count > 0)
                                {
                                    results.AddResults(CreateOperators(serverInformation, commandTimeout, operatorOptions));
                                }
                            }
                            else
                            {
                                string msg = String.Format(ProductConstants.ErrorMissingOperators, string.Join(",", newOperators.ToArray()));
                                results.AddResult(TaskStep.ProcessOperators, oper, JobTaskResults.Status.Failed, msg);
                                copyOptions.RaiseStatus(TaskStep.CompleteFailed);
                            }
                        }
                        else
                        {
                            copyOptions.RaiseStatus(TaskStep.CompleteSuccess);
                        }
                    }
                    catch (Exception ex)
                    {
                        results.AddResult(TaskStep.ProcessOperators, oper, JobTaskResults.Status.Failed, Helpers.GetCombinedExceptionText(ex));
                        copyOptions.RaiseStatus(TaskStep.CompleteFailed);
                    }

                    // Validate Step Database Names
                    string jobDb = string.Empty;
                    copyOptions.RaiseStatus(TaskStep.ProcessSteps);
                    try
                    {
                        DataTable serverDatabases = LoadDatabases(serverInformation, commandTimeout, options);
                        List<string> missingDbs = new List<string>();
                        foreach (string db in jobDatabases)
                        {
                            if (db != null)
                            {
                                jobDb = db;
                                serverDatabases.DefaultView.RowFilter = JobData.NameList.ColName + " = '" + db + "'";
                                if (serverDatabases.DefaultView.Count == 0)
                                {
                                    missingDbs.Add(db);
                                }
                            }
                        }
                        if (missingDbs.Count > 0)
                        {
                            string msg = String.Format(ProductConstants.ErrorMissingDatabases, string.Join(",", missingDbs.ToArray()));
                            results.AddResult(TaskStep.ProcessSteps, jobDb, JobTaskResults.Status.Failed, msg);
                            copyOptions.RaiseStatus(TaskStep.CompleteFailed);
                        }
                        else
                        {
                            copyOptions.RaiseStatus(TaskStep.CompleteSuccess);
                        }
                    }
                    catch (Exception ex)
                    {
                        results.AddResult(TaskStep.ProcessSteps, jobDb, JobTaskResults.Status.Failed, Helpers.GetCombinedExceptionText(ex));
                        copyOptions.RaiseStatus(TaskStep.CompleteFailed);
                    }
                }
                catch (Exception ex)
                {
                    string msg = String.Format(ProductConstants.ErrorValidatingJobs, Helpers.GetCombinedExceptionText(ex));
                    throw new Exception(msg);
                }
                finally
                {
                    Connection.CloseConnection(conn);
                }

                results.JobsToProcess.Clear();
                foreach (Job item in copyOptions.Jobs)
                {
                    if (item.MetaInfo.Enabled == false)
                    {
                        item.MetaInfo.Enabled = false;
                        results.JobsToProcess.Add(item);
                    }
                    else
                    {
                        item.MetaInfo.Enabled = true;
                        results.JobsToProcess.Add(item);
                    }
                }
            }
            return results;
        }

        public static JobTaskResults CreateCategories(ServerInformation serverInformation, int commandTimeout, CreateCategoriesOptions options)
        {
            SqlConnection conn = null;
            JobTaskResults results = new JobTaskResults(serverInformation.Name, options);

            try
            {
                conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials);

                foreach (string cat in options.Categories)
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(cmdAddCategory, conn))
                        {
                            cmd.CommandTimeout = ToolsetOptions.commandTimeout;
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter pCatClass = new SqlParameter(paramCatClass, "JOB");
                            cmd.Parameters.Add(pCatClass);
                            SqlParameter pCatType = new SqlParameter(paramCatType, "LOCAL");
                            cmd.Parameters.Add(pCatType);
                            SqlParameter pCatName = new SqlParameter(paramCatName, cat);
                            cmd.Parameters.Add(pCatName);

                            cmd.ExecuteNonQuery();

                            results.AddResult(TaskStep.SubCreateCategories, cat, JobTaskResults.Status.Success, string.Empty);
                        }
                    }
                    catch (Exception ex)
                    {
                        string msg = string.Format(ProductConstants.ErrorHandlingObject,
                                                      "Create",
                                                      "Category \"" + cat + "\"",
                                                      Helpers.GetCombinedExceptionText(ex));
                        results.AddResult(TaskStep.SubCreateCategories, cat, JobTaskResults.Status.Failed, msg);
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format(ProductConstants.ErrorHandlingObject,
                                              "Create",
                                              "Categories",
                                              Helpers.GetCombinedExceptionText(ex));
                results.AddResult(TaskStep.SubCreateCategories, "Categories", JobTaskResults.Status.Failed, msg);
            }
            finally
            {
                Connection.CloseConnection(conn);
            }

            return results;
        }

        public static JobTaskResults CreateOperators(ServerInformation serverInformation, int commandTimeout, CreateOperatorsOptions options)
        {
            SqlConnection conn = null;
            JobTaskResults results = new JobTaskResults(serverInformation.Name, options);

            try
            {
                conn = Connection.OpenConnection(serverInformation.Name, "msdb", serverInformation.SqlCredentials);

                foreach (KeyValuePair<string, Operator> op in options.Operators)
                {
                    try
                    {
                        op.Value.Save(conn);

                        results.AddResult(TaskStep.SubCreateOperators, op.Key, JobTaskResults.Status.Success, string.Empty);
                    }
                    catch (Exception ex)
                    {
                        string msg = string.Format(ProductConstants.ErrorHandlingObject,
                                                      "Create",
                                                      "Operator '" + op.Key + "'",
                                                      Helpers.GetCombinedExceptionText(ex));
                        results.AddResult(TaskStep.SubCreateOperators, op.Key, JobTaskResults.Status.Failed, msg);
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = string.Format(ProductConstants.ErrorHandlingObject,
                                              "Create",
                                              "Operators",
                                              Helpers.GetCombinedExceptionText(ex));
                results.AddResult(TaskStep.SubCreateOperators, "Operators", JobTaskResults.Status.Failed, msg);
            }
            finally
            {
                Connection.CloseConnection(conn);
            }

            return results;
        }

        public static JobTaskResults CreateJobs(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
            SqlConnection conn = null;
            JobTaskResults results = new JobTaskResults(serverInformation.Name, options);
            lock (threadLock)
            {
                try
                {
                    JobMoverOptions copyOptions = (JobMoverOptions)options;
                    copyOptions.RaiseStatus(TaskStep.CreateJobs);

                    conn = Connection.OpenConnection(serverInformation.Name, @"msdb", serverInformation.SqlCredentials);

                    bool failed = false;
                    SqlTransaction trans = null;

                    foreach (Job job in copyOptions.Jobs)
                    {
                        try
                        {
                            copyOptions.RaiseStatus(TaskStep.CreateJobs, string.Format("Creating Job '{0}'", job.JobName));
                            trans = conn.BeginTransaction();

                            if (copyOptions.Overwrite)
                            {
                                if (job.NameExistsOnServer(conn, trans) == AgentObjectExistenceType.Exists)
                                {
                                    job.Delete(conn, trans);
                                }
                            }

                            if (job.Save(conn, trans))
                            {
                                results.AddResult(TaskStep.CreateJobs, job.JobName, JobTaskResults.Status.Success, "Job created successfully.");

                                // Add to the process list if they need to be deleted
                                results.JobsToProcess.Add(job);
                            }

                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            results.AddResult(TaskStep.CreateJobs, job.JobName, JobTaskResults.Status.Failed, "Job creation failed: " + Helpers.GetCombinedExceptionText(ex));
                            copyOptions.RaiseStatus(TaskStep.CreateJobs, "Job creation failed: " + Helpers.GetCombinedExceptionText(ex));
                            failed = true;

                            if (trans != null && trans.Connection != null)
                            {
                                trans.Rollback();
                            }
                        }
                    }

                    if (failed)
                    {
                        copyOptions.RaiseStatus(TaskStep.CompleteFailed, ProductConstants.resultsCopyFailed);
                    }
                    else
                    {
                        copyOptions.RaiseStatus(TaskStep.CompleteSuccess);
                    }
                }
                catch (Exception ex)
                {
                    string msg = String.Format(ProductConstants.ErrorCopyingJobs, Helpers.GetCombinedExceptionText(ex));
                    throw new Exception(msg);
                }
                finally
                {
                    Connection.CloseConnection(conn);
                }
            }
            return results;
        }

        public static JobTaskResults DeleteJobs(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
            SqlConnection conn = null;
            JobTaskResults results = new JobTaskResults(serverInformation.Name, options);
            lock (threadLock)
            {
                try
                {
                    JobMoverOptions copyOptions = (JobMoverOptions)options;
                    copyOptions.RaiseStatus(TaskStep.CreateJobs, JobData.GetEnumDescription(TaskStep.SubDeleteSource));

                    conn = Connection.OpenConnection(serverInformation.Name, @"msdb", serverInformation.SqlCredentials);

                    bool failed = false;
                    foreach (Job job in copyOptions.Jobs)
                    {
                        try
                        {
                            // get current on the source job
                            Guid jobId = copyOptions.OriginalJobIds[job.OriginalJobName];
                            Job deleteJob = new Job(serverInformation, jobId);

                            if (deleteJob.Delete(conn))
                            {
                                results.AddResult(TaskStep.CreateJobs, job.JobName, JobTaskResults.Status.Success, "Job deleted successfully.");
                            }
                        }
                        catch (Exception ex)
                        {
                            results.AddResult(TaskStep.CreateJobs, job.JobName, JobTaskResults.Status.Failed, "Job deletion failed: " + Helpers.GetCombinedExceptionText(ex));
                            failed = true;
                        }
                    }

                    if (failed)
                    {
                        copyOptions.RaiseStatus(TaskStep.CompleteFailed);
                    }
                    else
                    {
                        copyOptions.RaiseStatus(TaskStep.CompleteSuccess);
                    }
                }
                catch (Exception ex)
                {
                    string msg = String.Format(ProductConstants.ErrorDeletingJobs, Helpers.GetCombinedExceptionText(ex));
                    throw new Exception(msg);
                }
                finally
                {
                    Connection.CloseConnection(conn);
                }
            }
            return results;
        }

        #endregion
    }

    #region Job Pool objects

    public class JobMoverOptions : JobPoolOptions
    {
        public List<Job> Jobs = new List<Job>();
        public SortedList<string, Guid> OriginalJobIds = new SortedList<string, Guid>();
        public SortedList<string, Operator> SourceOperators = new SortedList<string, Operator>();

        // Source options
        public ServerInformation SourceServer = null;
        public bool IncludeNotifications = true;
        public bool IncludeSchedules = true;
        public bool DeleteSourceJobs = false;

        // Destination options
        public ServerInformation DestinationServer = null;
        public bool CreateCategories = false;
        public bool CreateOperators = false;
        public bool CreateSchedules = true;
        public bool Overwrite = false;
        public bool AssignNewOwner = false;
        public string OwnerName = string.Empty;
        public bool AssignNewDatabase = false;
        public string DatabaseName = string.Empty;
        public bool DestinationIsSource
        {
            get { return SourceServer.Name == DestinationServer.Name; }
        }

        // Status Notification
        private EventHandler<TaskStatusEventArgs> _TaskStatus;

        //public EventHandler<TaskStatusEventArgs> TaskStatusEventHandler
        //{
        //   get { return _TaskStatus; }
        //   set { _TaskStatus = value; }
        //}

        /// <summary>
        /// Raised when a task completes on a server.
        /// </summary>
        public event EventHandler<TaskStatusEventArgs> TaskStatus
        {
            add { _TaskStatus += value; }
            remove { _TaskStatus -= value; }
        }

        /// <summary>
        /// Notifies caller of new task status.
        /// </summary>
        public void RaiseStatus(TaskStep step)
        {
            RaiseStatus(step, JobData.GetEnumDescription(step));
        }

        /// <summary>
        /// Notifies caller of new task status.
        /// </summary>
        public void RaiseStatus(TaskStep step, string stepDescription)
        {
            if (_TaskStatus != null)
            {
                _TaskStatus(this, new TaskStatusEventArgs(step, stepDescription));
            }
        }
    }

    public class TaskStatusEventArgs : EventArgs
    {
        private TaskStep _Step;
        private string _Description;

        public TaskStatusEventArgs(TaskStep step, string description)
        {
            _Step = step;
            _Description = description;
        }

        /// <summary>
        /// Step
        /// </summary>
        public TaskStep Step
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

    public class CreateCategoriesOptions : JobPoolOptions
    {
        public List<string> Categories = new List<string>();
    }

    public class CreateOperatorsOptions : JobPoolOptions
    {
        public SortedList<string, Operator> Operators = new SortedList<string, Operator>();
    }

    public abstract class JobPoolResults
    {
        // used as the base clase for all result sets returned
        // so that there can be a common definition for the JobPool
        // used by the progress dialog routines

        #region fields

        // the Server these results were from
        protected string m_Server;

        // Options passed into the update function
        // this is the base class type for all options objects
        protected JobPoolOptions m_Options;

        #endregion

        #region constructor

        public JobPoolResults(string server, JobPoolOptions options)
        {
            m_Server = server;
            m_Options = options;
        }

        #endregion

        #region properties

        public string Server
        {
            get { return m_Server; }
        }

        public JobPoolOptions Options
        {
            get { return m_Options; }
        }

        #endregion
    }

    public class GetTaskResults : JobPoolResults
    {

        #region constructor

        public GetTaskResults(string server, JobPoolOptions options) : base(server, options)
        {
            Jobs = new SortedList<string, Job>();
            Operators = new SortedList<string, Operator>();
        }

        #endregion

        #region properties

        public SortedList<string, Job> Jobs;
        public SortedList<string, Operator> Operators;

        #endregion
    }

    public class JobTaskResults : JobPoolResults
    {
        #region constants and enums

        public enum Status
        {
            Success = 0,
            Failed = 1,
            Unknown = 2
        }

        public const string ColServer = @"server";
        public const string ColTask = @"task";
        public const string ColObjectName = @"name";
        public const string ColStatus = @"status";
        public const string ColResultsText = @"errortext";

        #endregion

        #region fields

        //Counts
        private int m_CountSuccessful = 0;
        private int m_CountFailed = 0;

        #endregion

        #region constructor

        public JobTaskResults(string server, JobPoolOptions options) : base(server, options)
        {
            Results = new DataTable();

            Results.Columns.Add(new DataColumn(ColServer, typeof(string)));
            Results.Columns.Add(new DataColumn(ColTask, typeof(string)));
            Results.Columns.Add(new DataColumn(ColObjectName, typeof(string)));
            Results.Columns.Add(new DataColumn(ColStatus, typeof(Status)));
            Results.Columns.Add(new DataColumn(ColResultsText, typeof(string)));

            JobsToProcess = new List<Job>();
        }

        #endregion

        #region properties

        public DataTable Results;
        public List<Job> JobsToProcess;

        public int TaskCount
        {
            get { return Results.Rows.Count; }
        }

        public int SuccessfulCount
        {
            get { return m_CountSuccessful; }
        }

        public int FailedCount
        {
            get { return m_CountFailed; }
        }

        #endregion

        #region methods

        public void AddResult(TaskStep task, string objectName, Status status, string errorText)
        {
            DataRow row = Results.NewRow();
            row[ColServer] = m_Server;
            row[ColTask] = task;
            row[ColObjectName] = objectName;
            row[ColStatus] = status;
            row[ColResultsText] = errorText;

            if (status == Status.Success)
            {
                m_CountSuccessful++;
            }
            else if (status == Status.Failed)
            {
                m_CountFailed++;
            }

            Results.Rows.Add(row);
        }

        /// <summary>
        /// Add the results set from another JobTaskResults to the current Results
        /// </summary>
        /// <param name="results">A JobTaskResults object with results from a performed task</param>
        public void AddResults(JobTaskResults results)
        {
            foreach (DataRow row in results.Results.Rows)
            {
                Results.ImportRow(row);
            }
        }

        #endregion
    }

    #endregion
}
