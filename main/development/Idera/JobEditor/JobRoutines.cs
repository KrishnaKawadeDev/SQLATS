using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using BBS.TracerX;
using Idera.SqlAdminToolset.Core;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using System.Threading;

namespace Idera.SqlAdminToolset.JobEditor
{
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

        public enum JobLastRun
        {
            [Description("day(s)")]
            days = 0,
            [Description("hour(s)")]
            hours = 1,
            [Description("minute(s)")]
            minutes = 2
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
            public static string ColServerInfo = "ServerInformationName";
            public static string ColServer = "Server";
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
                Counts = new JobCounts();
            }

            #endregion

            #region properties

            public DataTable Jobs;
            public JobCounts Counts;

            #endregion

            #region methods

            public static DataTable CreateTable()
            {
                DataTable dt = new DataTable("JobInfoTable");

                dt.Columns.Add(new DataColumn(ColSelect, typeof(bool)));
                dt.Columns.Add(new DataColumn(ColServerInfo, typeof(string)));
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

            public void AddJob(DataRow row)
            {
                Jobs.Rows.Add(row);
                
                // Update counts
                if ((JobOutcome)row[JobData.JobList.ColStatus] == JobOutcome.Failed)
                {
                    Counts.FailedJobs++;
                }
                if ((DateTime)row[JobData.JobList.ColLastRun] == DateTime.MinValue)
                {
                    Counts.JobsNeverRun++;
                }

                if (!IsDateRecent((DateTime)row[JobData.JobList.ColLastRun], JobRoutines.jobstatusval) && JobRoutines.jobstatusstr == "day(s)")
                {
                    if ((DateTime)row[JobData.JobList.ColLastRun] == DateTime.MinValue)
                    {

                    }
                    else
                    {
                        Counts.JobsNotRecentDay++;
                    }
                }
                else if (!IsHourRecent((DateTime)row[JobData.JobList.ColLastRun], JobRoutines.jobstatusval) && JobRoutines.jobstatusstr == "hour(s)")
                {
                    if ((DateTime)row[JobData.JobList.ColLastRun] == DateTime.MinValue)
                    {

                    }
                    else
                    {
                        Counts.JobsNotRecentHour++;
                    }
                    
                }
                else if (!IsMinuteRecent((DateTime)row[JobData.JobList.ColLastRun], JobRoutines.jobstatusval) && JobRoutines.jobstatusstr == "minute(s)")
                {
                    if ((DateTime)row[JobData.JobList.ColLastRun] == DateTime.MinValue)
                    {

                    }
                    else
                    {
                        Counts.JobsNotRecentMinute++;
                    }
                }

                else if (!IsDateRecent((DateTime)row[JobData.JobList.ColLastRun], ProductConstants.compareRecentDays))
                {
                    Counts.JobsNotRecent++;
                }

                if (IsDateRecent((DateTime)row[JobData.JobList.ColDateCreated], ProductConstants.compareNewDays))
                {
                    Counts.NewJobs++;
                }

                if ((JobData.NotifyLevel)row[JobData.JobList.ColNotifyLevelEventLog] == NotifyLevel.Never)
                {
                    Counts.JobsNotNotifying++;
                }
                
            }

            public static bool IsDateRecent(DateTime jobDate, int days)
            {
                DateTime dt = Convert.ToDateTime(DateTime.Now.AddDays(-days));
               
                if (jobDate < dt)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                 //return ((TimeSpan)(DateTime.Now - jobDate)).Days <= days;
            }
            public static bool IsHourRecent(DateTime jobDate, int hour)
            {
                DateTime dt = Convert.ToDateTime(DateTime.Now.AddHours(-hour));
                if (jobDate < dt)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                //return ((TimeSpan)(DateTime.Now - jobDate)).Hours <= hour;
            }
            public static bool IsMinuteRecent(DateTime jobDate, int minute)
            {
                DateTime dt = Convert.ToDateTime(DateTime.Now.AddMinutes(-minute));
                if (jobDate < dt)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                //return ((TimeSpan)(DateTime.Now - jobDate)).Minutes <= minute;
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
            public static string ColServer = @"originating_server";
            public static string ColJobName = @"name";
            public static string ColEnabled = @"enabled";
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

        public class UpdateJobsInfo
        {
            #region fields

            private SortedList<string, JobInfoResults> m_ServerList;
            private SortedList<string, string> m_CommonCategories;
            private SortedList<string, string> m_CommonOwners;
            private SortedList<string, string> m_CommonOperators;

            #endregion

            #region constructors

            public UpdateJobsInfo()
            {
                m_ServerList = new SortedList<string, JobInfoResults>();
                m_CommonCategories = new SortedList<string, string>();
                m_CommonOwners = new SortedList<string, string>();
                m_CommonOperators = new SortedList<string, string>();
            }

            #endregion

            #region properties

            public SortedList<string, JobInfoResults> ServerList
            {
                get { return m_ServerList; }
            }

            public SortedList<string, string> CommonCategoryList
            {
                get { return m_CommonCategories; }
            }

            public SortedList<string, string> CommonOwnersList
            {
                get { return m_CommonOwners; }
            }

            public SortedList<string, string> CommonOperatorsList
            {
                get { return m_CommonOperators; }
            }

            public DataTable SelectedJobList = JobData.JobList.CreateTable();

            #endregion

            #region methods

            public void AddServerInfo(JobInfoResults serverResults)
            {
                ServerInformation server = new ServerInformation(serverResults.Server);
                m_ServerList.Add(server.ActualName, serverResults);

                // fix the common lists
                // if this is the first server, then add all values
                if (m_ServerList.Count == 1)
                {
                    // Fill Categories
                    m_CommonCategories.Clear();
                    foreach (DataRow row in serverResults.CategoryList.Rows)
                    {
                        string cat = (string)row[JobData.NameList.ColName];
                        m_CommonCategories.Add(cat, cat);
                    }

                    // Fill Owners
                    m_CommonOwners.Clear();
                    foreach (DataRow row in serverResults.OwnerList.Rows)
                    {
                        string owner = (string)row[JobData.NameList.ColName];
                        m_CommonOwners.Add(owner, owner);
                    }

                    // Fill Operators
                    m_CommonOperators.Clear();
                    foreach (DataRow row in serverResults.OperatorList.Rows)
                    {
                        string op = (string)row[JobData.NameList.ColName];
                        m_CommonOperators.Add(op, op);
                    }
                }
                else
                {
                    // Merge Categories
                    DataView dv = new DataView(serverResults.CategoryList);
                    List<string> delkeys = new List<string>();
                    foreach (string cat in m_CommonCategories.Keys)
                    {
                        dv.RowFilter = JobData.NameList.ColName + " = '" + cat + "'";
                        if (dv.Count == 0)
                        {
                            delkeys.Add(cat);
                        }
                    }
                    foreach (string cat in delkeys)
                    {
                        m_CommonCategories.Remove(cat);
                    }

                    // Merge Owners
                    dv = new DataView(serverResults.OwnerList);
                    delkeys.Clear();
                    foreach (string owner in m_CommonOwners.Keys)
                    {
                        dv.RowFilter = JobData.NameList.ColName + " = '" + owner + "'";
                        if (dv.Count == 0)
                        {
                            delkeys.Add(owner);
                        }
                    }
                    foreach (string owner in delkeys)
                    {
                        m_CommonOwners.Remove(owner);
                    }

                    // Merge Operators
                    dv = new DataView(serverResults.OperatorList);
                    delkeys.Clear();
                    foreach (string op in m_CommonOperators.Keys)
                    {
                        dv.RowFilter = JobData.NameList.ColName + " = '" + op + "'";
                        if (dv.Count == 0)
                        {
                            delkeys.Add(op);
                        }
                    }
                    foreach (string op in delkeys)
                    {
                        m_CommonOperators.Remove(op);
                    }
                }
            }

            #endregion
        }

        #endregion
    }

    public class JobCounts
    {
        #region properties

        public int ServersScanned;
        public int JobsNeverRun;
        public int JobsNotRecent;
        public int JobsNotRecentDay;
        public int JobsNotRecentHour;
        public int JobsNotRecentMinute;
        public int JobsNotNotifying;
        public int NewJobs;
        public int FailedJobs;

        #endregion

        #region constructors

        public JobCounts()
        {
            ResetCounts();
        }

        #endregion

        #region methods

        public void ResetCounts()
        {
            ServersScanned = 0;
            JobsNeverRun = 0;
            JobsNotRecent = 0;
            JobsNotRecentDay=0;
            JobsNotRecentHour=0;
            JobsNotRecentMinute = 0;
            JobsNotNotifying = 0;
            NewJobs = 0;
            FailedJobs = 0;
        }

        public void AddCounts(JobCounts counts)
        {
            ServersScanned += counts.ServersScanned;
            JobsNeverRun += counts.JobsNeverRun;
            JobsNotRecent += counts.JobsNotRecent;
            JobsNotRecentDay += counts.JobsNotRecentDay;
            JobsNotRecentHour += counts.JobsNotRecentHour;
            JobsNotRecentMinute += counts.JobsNotRecentMinute;
            JobsNotNotifying += counts.JobsNotNotifying;
            NewJobs += counts.NewJobs;
            FailedJobs += counts.FailedJobs;
        }

        #endregion
    }

    public class JobRoutines
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
        private static string cmdQueryOperators = @"msdb..sp_help_operator";
        private static string cmdUpdateJob = @"msdb..sp_update_job";
        private static string cmdAddCategory = @"msdb..sp_add_category";

        private static string paramJobName = @"@job_name";
        private static string paramEnabled = @"@enabled";
        private static string paramCategory = @"@category_name";
        private static string paramOwner = @"@owner_login_name";
        private static string paramNotifyLevelEventLog = @"@notify_level_eventlog";
        private static string paramNotifyLevelEmail = @"@notify_level_email";
        private static string paramNotifyLevelNetSend = @"@notify_level_netsend";
        private static string paramNotifyLevelPage = @"@notify_level_page";
        private static string paramNotifyOpEmail = @"@notify_email_operator_name";
        private static string paramNotifyOpNetSend = @"@notify_netsend_operator_name";
        private static string paramNotifyOpPage = @"@notify_page_operator_name";

        private static string paramCatClass = @"@class";
        private static string paramCatType = @"@type";
        private static string paramCatName = @"@name";

        public static string jobstatusstr;
        public static int jobstatusval;

        public static void joblastrunstatusinfo(string jobstr, int jobint)
        {
            jobstatusstr = jobstr;
            jobstatusval = jobint;
        }

        public static JobInfoResults LoadJobInfo(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
         
            {
 
                JobInfoResults results = new JobInfoResults(serverInformation.Name, options);
                lock (threadLock)
                {

                    //Get the list of categories for this server
                    results.CategoryList = LoadJobCategories(serverInformation, commandTimeout, options);

                    //Get the list of owners for this server
                    results.OwnerList = LoadJobOwners(serverInformation, commandTimeout, options);

                    //Get the list of operators for this server
                    results.OperatorList = LoadJobOperators(serverInformation, commandTimeout, options);

                    results.Counts.ServersScanned++;
                    results.JobList.Counts.ServersScanned++;

                    SqlConnection conn = null;

                    try
                    {
                        conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials);

                        using (SqlCommand cmd = new SqlCommand(cmdQueryJobs, conn))
                        {
                            cmd.CommandTimeout = ToolsetOptions.commandTimeout;
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds);

                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                DataRow dr = results.JobList.Jobs.NewRow();

                                dr[JobData.JobList.ColSelect] = false;
                                dr[JobData.JobList.ColServerInfo] = serverInformation.Name;
                                dr[JobData.JobList.ColServer] = SQLHelpers.GetRowString(row, JobData.JobInfo.ColServer);
                                dr[JobData.JobList.ColJobName] = SQLHelpers.GetRowString(row, JobData.JobInfo.ColJobName);
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
                                results.JobList.AddJob(dr);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        string msg = String.Format(ProductConstants.msgSqlErrorLoadingJobs, Helpers.GetCombinedExceptionText(ex));
                        throw new Exception(msg);
                    }
                    catch (Exception ex)
                    {
                        string msg = String.Format(ProductConstants.msgErrorLoadingJobs, Helpers.GetCombinedExceptionText(ex));
                        throw new Exception(msg);
                    }
                    finally
                    {
                        Connection.CloseConnection(conn);
                    }
                    return results;
                }
            }
         
        }

       

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
        private static object threadLock = new object();
        public static DataTable LoadJobCategories(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
            DataTable categories = JobData.JobCategory.CreateCategoryTable();

            SqlConnection conn = null;
         
                try
            {
               
                    conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials);


                    using (SqlCommand cmd = new SqlCommand(cmdQueryCategories, conn))
                    {
                        cmd.CommandTimeout = ToolsetOptions.commandTimeout;
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
                string msg = String.Format(ProductConstants.msgSqlErrorLoadingCategories, Helpers.GetCombinedExceptionText(ex));
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                string msg = String.Format(ProductConstants.msgErrorLoadingCategories, Helpers.GetCombinedExceptionText(ex));
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
            DataTable operators = JobData.NameList.CreateTable("Owners");

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
                    cmd.CommandTimeout = ToolsetOptions.commandTimeout;
                    cmd.CommandType = CommandType.Text;

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
            catch (Exception ex)
            {
                string msg = String.Format(ProductConstants.msgErrorLoadingOwners, Helpers.GetCombinedExceptionText(ex));
                throw new Exception(msg);
            }
            finally
            {
                Connection.CloseConnection(conn);
            }

            return operators;
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
                    cmd.CommandTimeout = ToolsetOptions.commandTimeout;
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
                string msg = String.Format(ProductConstants.msgSqlErrorLoadingOperators, Helpers.GetCombinedExceptionText(ex));
                throw new Exception(msg);
            }
            catch (Exception ex)
            {
                string msg = String.Format(ProductConstants.msgErrorLoadingOperators, Helpers.GetCombinedExceptionText(ex));
                throw new Exception(msg);
            }
            finally
            {
                Connection.CloseConnection(conn);
            }

            return operators;
        }

        public static JobUpdateResults UpdateJobs(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
            Logger logger = CoreGlobals.traceLog;
            SqlConnection conn = null;
            JobUpdateResults results = new JobUpdateResults(serverInformation.ActualName, options);
            lock (threadLock)
            {
                try
                {
                    DataTable jobList = ((JobUpdateOptions)options).JobList;
                    JobUpdateValues updates = ((JobUpdateOptions)options).UpdateValues;

                    conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials);

                    // Create the category if necessary
                    if (updates.CreateCategory)
                    {
                        DataTable categories = LoadJobCategories(serverInformation, commandTimeout, options);
                        bool found = false;
                        foreach (DataRow cat in categories.Rows)
                        {
                            if (((string)cat[JobData.NameList.ColName]).Equals(updates.Category, StringComparison.CurrentCultureIgnoreCase))
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            using (SqlCommand cmd = new SqlCommand(cmdAddCategory, conn))
                            {
                                cmd.CommandTimeout = ToolsetOptions.commandTimeout;
                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlParameter pCatClass = new SqlParameter(paramCatClass, "JOB");
                                cmd.Parameters.Add(pCatClass);
                                SqlParameter pCatType = new SqlParameter(paramCatType, "LOCAL");
                                cmd.Parameters.Add(pCatType);
                                SqlParameter pCatName = new SqlParameter(paramCatName, updates.Category);
                                cmd.Parameters.Add(pCatName);

                                logger.InfoFormat(ProductConstants.LogCreate, "Category", updates.Category);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    DataView jobs = new DataView(jobList);
                    jobs.Table.CaseSensitive = false;
                    jobs.RowFilter = JobData.JobList.ColServer + " = '" + serverInformation.ActualName + "'";

                    foreach (DataRowView row in jobs)
                    {
                        string jobName = (string)row[JobData.JobList.ColJobName];
                        string updateText = string.Empty;

                        try
                        {
                            using (SqlCommand cmd = new SqlCommand(cmdUpdateJob, conn))
                            {
                                cmd.CommandTimeout = ToolsetOptions.commandTimeout;
                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlParameter pJob = new SqlParameter(paramJobName, jobName);
                                cmd.Parameters.Add(pJob);

                                SqlParameter pEnabled;
                                if (updates.Enabled.HasValue)
                                {
                                    pEnabled = new SqlParameter(paramEnabled, updates.Enabled.Value);
                                    cmd.Parameters.Add(pEnabled);
                                    updateText += string.Format(ProductConstants.LogUpdateFmt, paramEnabled, JobData.GetEnumDescription(updates.Enabled.Value));
                                }
                                SqlParameter pCategory;
                                if (updates.Category.Length > 0)
                                {
                                    pCategory = new SqlParameter(paramCategory, updates.Category);
                                    cmd.Parameters.Add(pCategory);
                                    updateText += string.Format(ProductConstants.LogUpdateFmt, paramCategory, updates.Category);
                                }
                                SqlParameter pOwner;
                                if (updates.Owner.Length > 0)
                                {
                                    pOwner = new SqlParameter(paramOwner, updates.Owner);
                                    cmd.Parameters.Add(pOwner);
                                    updateText += string.Format(ProductConstants.LogUpdateFmt, paramOwner, updates.Owner);
                                }
                                SqlParameter pNotifyLevelEventLog;
                                if (updates.NotifyLevelEventLog.HasValue)
                                {
                                    pNotifyLevelEventLog = new SqlParameter(paramNotifyLevelEventLog, updates.NotifyLevelEventLog.Value);
                                    cmd.Parameters.Add(pNotifyLevelEventLog);
                                    updateText += string.Format(ProductConstants.LogUpdateFmt, paramNotifyLevelEventLog, JobData.GetEnumDescription(updates.NotifyLevelEventLog.Value));
                                }
                                SqlParameter pNotifyLevelEmail;
                                if (updates.NotifyLevelEmail.HasValue)
                                {
                                    pNotifyLevelEmail = new SqlParameter(paramNotifyLevelEmail, updates.NotifyLevelEmail.Value);
                                    cmd.Parameters.Add(pNotifyLevelEmail);
                                    updateText += string.Format(ProductConstants.LogUpdateFmt, paramNotifyLevelEmail, JobData.GetEnumDescription(updates.NotifyLevelEmail.Value));
                                }
                                SqlParameter pNotifyLevelNetSend;
                                if (updates.NotifyLevelNetSend.HasValue)
                                {
                                    pNotifyLevelNetSend = new SqlParameter(paramNotifyLevelNetSend, updates.NotifyLevelNetSend.Value);
                                    cmd.Parameters.Add(pNotifyLevelNetSend);
                                    updateText += string.Format(ProductConstants.LogUpdateFmt, paramNotifyLevelNetSend, JobData.GetEnumDescription(updates.NotifyLevelNetSend.Value));
                                }
                                SqlParameter pNotifyLevelPage;
                                if (updates.NotifyLevelPage.HasValue)
                                {
                                    pNotifyLevelPage = new SqlParameter(paramNotifyLevelPage, updates.NotifyLevelPage.Value);
                                    cmd.Parameters.Add(pNotifyLevelPage);
                                    updateText += string.Format(ProductConstants.LogUpdateFmt, paramNotifyLevelPage, JobData.GetEnumDescription(updates.NotifyLevelPage.Value));
                                }
                                SqlParameter pNotifyOpEmail;
                                if (updates.NotifyOpEmail.Length > 0)
                                {
                                    pNotifyOpEmail = new SqlParameter(paramNotifyOpEmail, updates.NotifyOpEmail);
                                    cmd.Parameters.Add(pNotifyOpEmail);
                                    updateText += string.Format(ProductConstants.LogUpdateFmt, paramNotifyOpEmail, updates.NotifyOpEmail);
                                }
                                SqlParameter pNotifyOpNetSend;
                                if (updates.NotifyOpNetSend.Length > 0)
                                {
                                    pNotifyOpNetSend = new SqlParameter(paramNotifyOpNetSend, updates.NotifyOpNetSend);
                                    cmd.Parameters.Add(pNotifyOpNetSend);
                                    updateText += string.Format(ProductConstants.LogUpdateFmt, paramNotifyOpNetSend, updates.NotifyOpNetSend);
                                }
                                SqlParameter pNotifyOpPage;
                                if (updates.NotifyOpPage.Length > 0)
                                {
                                    pNotifyOpPage = new SqlParameter(paramNotifyOpPage, updates.NotifyOpPage);
                                    cmd.Parameters.Add(pNotifyOpPage);
                                    updateText += string.Format(ProductConstants.LogUpdateFmt, paramNotifyOpPage, updates.NotifyOpPage);
                                }
                                updateText = "Set" + updateText.Substring(1);
                                logger.InfoFormat(string.Format(ProductConstants.LogUpdate, "Job", jobName, updateText));

                                cmd.ExecuteNonQuery();

                                results.AddResult(jobName, JobUpdateResults.UpdateStatus.Success, string.Empty);
                            }
                        }
                        catch (SqlException ex)
                        {
                            string msg = String.Format(ProductConstants.msgSqlErrorUpdatingJob, jobName, Helpers.GetCombinedExceptionText(ex));
                            results.AddResult(jobName, JobUpdateResults.UpdateStatus.Failed, msg);
                            logger.ErrorFormat(ProductConstants.LogUpdateFailed, "Job", jobName, Helpers.GetCombinedExceptionText(ex));
                        }
                        catch (Exception ex)
                        {
                            string msg = String.Format(ProductConstants.msgErrorUpdatingJob, jobName, Helpers.GetCombinedExceptionText(ex));
                            results.AddResult(jobName, JobUpdateResults.UpdateStatus.Failed, msg);
                            logger.ErrorFormat(ProductConstants.LogUpdateFailed, "Job", jobName, Helpers.GetCombinedExceptionText(ex));
                        }
                    }
                }
                catch (Exception ex)
                {
                    string msg = String.Format(ProductConstants.msgErrorUpdatingJobs, Helpers.GetCombinedExceptionText(ex));
                    throw new Exception(msg);
                }
                finally
                {
                    Connection.CloseConnection(conn);
                }
            }
            return results;
        }

        #region shared combo box helpers

        /// <summary>
        /// Fill the passed combobox with items from the passed column in the job list DataTable
        /// </summary>
        /// <param name="comboBox">The comboBox to fill</param>
        /// <param name="jobList">The DataTable that contains the JobData job list</param>
        /// <param name="column">The JobData.JobList.Column to use in the job list DataTable</param>
        public static void FillComboBoxFromJobList(ComboBoxEx comboBox, DataTable jobList, string column)
        {
            string selectedText = comboBox.Text;
            bool found = false;

            comboBox.Items.Clear();

            DataView dv = new DataView(jobList);
            dv.Sort = column;
            DataTable dt = dv.ToTable(true, new string[] { column });

            foreach (DataRow dr in dt.Rows)
            {
                string textval = (string)dr[column];
                AddComboBoxItem(comboBox, textval);
                if (selectedText == textval)
                {
                    found = true;
                }
            }

            if (found || comboBox.DropDownStyle != ComboBoxStyle.DropDownList)
            {
                comboBox.Text = selectedText;
            }
        }

        /// <summary>
        /// Fill the passed combobox with the item names in the passed enum
        /// </summary>
        /// <param name="comboBox">The comboBox to fill</param>
        /// <param name="column">The JobData.JobList.Column to use in the job list DataTable</param>
        public static void FillComboBoxFromEnum(ComboBoxEx comboBox, Type enumList, bool useDescription)
        {
            if (enumList.IsEnum)
            {
                string selectedText = comboBox.Text;
                bool found = false;

                comboBox.Items.Clear();

                foreach (int val in Enum.GetValues(enumList))
                {
                    string textval = useDescription ? JobData.GetEnumDescription(enumList, val) : Enum.GetName(enumList, val);
                    AddComboBoxItem(comboBox, textval, val);
                    if (selectedText == textval)
                    {
                        found = true;
                    }
                }

                if (found || comboBox.DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    comboBox.Text = selectedText;
                }
            }
        }

        /// <summary>
        /// Fill the passed combobox with items from the name column in the namelist DataTable
        /// </summary>
        /// <param name="comboBox">The comboBox to fill</param>
        /// <param name="nameList">The DataTable that contains the list of names</param>
        public static void FillComboBoxFromNameList(ComboBoxEx comboBox, DataTable nameList)
        {
            string column = JobData.NameList.ColName;
            string selectedText = comboBox.Text;
            bool found = false;

            comboBox.Items.Clear();

            DataView dv = new DataView(nameList);
            dv.Sort = column;
            DataTable dt = dv.ToTable(true, new string[] { column });

            foreach (DataRow dr in dt.Rows)
            {
                string textval = (string)dr[column];
                AddComboBoxItem(comboBox, textval);
                if (selectedText == textval)
                {
                    found = true;
                }
            }

            if (found || comboBox.DropDownStyle != ComboBoxStyle.DropDownList)
            {
                comboBox.Text = selectedText;
            }
        }

        /// <summary>
        /// Fill the passed combobox with items from the passed list
        /// </summary>
        /// <param name="comboBox">The comboBox to fill</param>
        /// <param name="nameList">The SortedList that contains the list of names</param>
        public static void FillComboBoxFromNameList(ComboBoxEx comboBox, SortedList<string, string> nameList)
        {
            string selectedText = comboBox.Text;
            bool found = false;

            comboBox.Items.Clear();

            foreach (string textval in nameList.Values)
            {
                AddComboBoxItem(comboBox, textval);
                if (selectedText == textval)
                {
                    found = true;
                }
            }

            if (found || comboBox.DropDownStyle != ComboBoxStyle.DropDownList)
            {
                comboBox.Text = selectedText;
            }
        }

        /// <summary>
        /// Add an item to the combobox that displays the itemText for the value in value
        /// </summary>
        /// <param name="comboBox">The comboBox to fill</param>
        /// <param name="itemText">The item to display in the combobox</param>
        /// <param name="value">An object associated with the item for value comparisons</param>
        /// <returns>The zero-based index of the item in the collection</returns>
        private static int AddComboBoxItem(ComboBoxEx comboBox, string itemText, object value)
        {
            ComboItem newItem = CreateComboBoxItem(itemText, value);
            return comboBox.Items.Add(newItem);
        }

        /// <summary>
        /// Add an item to the combobox with the value in itemText
        /// </summary>
        /// <param name="comboBox">The comboBox to fill</param>
        /// <param name="itemText">The item to display in the combobox</param>
        /// <returns>The zero-based index of the item in the collection</returns>
        private static int AddComboBoxItem(ComboBoxEx comboBox, string itemText)
        {
            ComboItem newItem = CreateComboBoxItem(itemText);
            return comboBox.Items.Add(newItem);
        }

        /// <summary>
        /// Create a combobox item that displays the itemText for the value in value
        /// </summary>
        /// <param name="itemText">The item display value</param>
        /// <param name="value">An object associated with the item for value comparisons</param>
        /// <returns>A ComboItem to be added to a ComboBoxEx control</returns>
        private static ComboItem CreateComboBoxItem(string itemText, object value)
        {
            ComboItem newItem = new ComboItem();
            newItem.Text = itemText;
            newItem.TextLineAlignment = StringAlignment.Center;
            newItem.Tag = value;

            return newItem;
        }

        /// <summary>
        /// Create a combobox item with the value in itemText
        /// </summary>
        /// <param name="itemText">The item display value</param>
        /// <returns>A ComboItem to be added to a ComboBoxEx control</returns>
        private static ComboItem CreateComboBoxItem(string itemText)
        {
            ComboItem newItem = new ComboItem();
            newItem.Text = itemText;
            newItem.TextLineAlignment = StringAlignment.Center;

            return newItem;
        }

        #endregion
    }

    public class JobSelections
    {
        #region fields

        private string m_JobName = string.Empty;
        private JobData.JobEnabled? m_Enabled = null;
        private string m_Category = string.Empty;
        private string m_Owner = string.Empty;
        private string m_Outcome = string.Empty;
        private int m_Jobstatusval = 1;
        private JobData.JobLastRun? m_Jobstatustext = null;
        private JobData.JobTimeframe? m_Timeframe = null;
        private JobData.NotifyType? m_Notification = null;

        private static char[] DELIMS = { ';' };

        #endregion

        #region properties

        public bool ClearPreviousSelections = false;
        public bool CaseSensitive = false;

        //display values for comboboxes
        public string JobName
        {
            get
            {
                return m_JobName;
            }
        }

        public JobData.JobEnabled? Enabled
        {
            get
            {
                return m_Enabled;
            }
        }

        public string Category
        {
            get
            {
                return m_Category;
            }
        }

        public string Owner
        {
            get
            {
                return m_Owner;
            }
        }

        public string Outcome
        {
            get
            {
                return m_Outcome;
            }
        }
        public int Jobstatusvalue
        {
            get
            {
                return m_Jobstatusval;
            }
        }
        public JobData.JobLastRun? JobstatusText
        {
            get
            {
                return m_Jobstatustext;
            }
        }

        public JobData.JobTimeframe? Timeframe
        {
            get
            {
                return m_Timeframe;
            }
        }

        public JobData.NotifyType? Notification
        {
            get
            {
                return m_Notification;
            }
        }

        // values used for filtering
        public string[] JobNames
        {
            get
            {
                return JobName.Split(DELIMS, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public JobData.JobEnabled[] EnabledStatus
        {
            get
            {
                if (Enabled.HasValue)
                {
                    return new JobData.JobEnabled[1] { Enabled.Value };
                }
                else
                {
                    return new JobData.JobEnabled[0];
                }
            }
        }

        public string[] Categories
        {
            get
            {
                return Category.Split(DELIMS, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public string[] Owners
        {
            get
            {
                return Owner.Split(DELIMS, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public JobData.JobOutcome[] Outcomes
        {
            get
            {
                if (Outcome.Trim().Length > 0)
                {
                    string[] textValues = Outcome.Split(DELIMS, StringSplitOptions.RemoveEmptyEntries);

                    JobData.JobOutcome[] values = new JobData.JobOutcome[textValues.GetLength(0)];
                    foreach (string val in textValues)
                    {
                        values[values.Length - 1] = (JobData.JobOutcome)Enum.Parse(typeof(JobData.JobOutcome), val);
                    }
                    return values;
                }
                else
                {
                    return new JobData.JobOutcome[0];
                }
            }
        }

        public JobData.JobTimeframe[] Timeframes
        {
            get
            {
                if (Timeframe.HasValue)
                {
                    return new JobData.JobTimeframe[1] { Timeframe.Value };
                }
                else
                {
                    return new JobData.JobTimeframe[0];
                }
            }
        }

        public JobData.NotifyType[] Notifications
        {
            get
            {
                if (Notification.HasValue)
                {
                    return new JobData.NotifyType[1] { Notification.Value };
                }
                else
                {
                    return new JobData.NotifyType[0];
                }
            }
        }

        #endregion

        #region methods

        public void SetJobName(string jobtext)
        {
            m_JobName = jobtext;
        }

        public void SetEnabled(int? enabledvalue)
        {
            m_Enabled = (JobData.JobEnabled?)enabledvalue;
        }

        public void SetCategory(string categorytext)
        {
            m_Category = categorytext;
        }

        public void SetOwner(string ownertext)
        {
            m_Owner = ownertext;
        }

        public void SetOutcome(string outcometext)
        {
            m_Outcome = outcometext;
        }
        public void SetJobStatusValue(int jobval)
        {
            m_Jobstatusval = jobval;
        }
        public void SetJobStatusText(int? jobtext)
        {
            m_Jobstatustext = (JobData.JobLastRun?)jobtext;
        }
        public void SetTimeframe(int? timeframevalue)
        {
            m_Timeframe = (JobData.JobTimeframe?)timeframevalue;
        }

        public void SetNotification(int? notificationvalue)
        {
            m_Notification = (JobData.NotifyType?)notificationvalue;
        }

        #endregion
    }

    #region Job Pool objects

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

    public class JobUpdateOptions : JobPoolOptions
    {
        public DataTable JobList;
        public JobUpdateValues UpdateValues;
    }

    public class JobInfoResults : JobPoolResults
    {
        #region fields

        private JobData.JobList m_JobList;

        #endregion

        #region constructor

        public JobInfoResults(string server, JobPoolOptions options) : base(server, options)
        {
            m_JobList = new JobData.JobList();

            CategoryList = JobData.JobCategory.CreateCategoryTable();
            OwnerList = JobData.NameList.CreateTable("Owners");
            OperatorList = JobData.NameList.CreateTable("Operators");

            Counts = new JobCounts();
        }

        #endregion

        #region properties

        public JobData.JobList JobList
        {
            get { return m_JobList; }
            set
            {
                m_JobList = value;
            }
        }
        public DataTable CategoryList;
        public DataTable OwnerList;
        public DataTable OperatorList;

        public JobCounts Counts;

        #endregion

        #region methods

        #endregion
    }

    public class JobUpdateValues
    {
        #region fields

        private JobData.JobEnabled? m_Enabled = null;
        private string m_Category = string.Empty;
        private string m_Owner = string.Empty;
        private JobData.NotifyLevel? m_NotifyLevelEventLog = null;
        private JobData.NotifyLevel? m_NotifyLevelEmail = null;
        private JobData.NotifyLevel? m_NotifyLevelNetSend = null;
        private JobData.NotifyLevel? m_NotifyLevelPage = null;
        private string m_NotifyOpEmail = string.Empty;
        private string m_NotifyOpNetSend = string.Empty;
        private string m_NotifyOpPage = string.Empty;

        private bool m_CreateCategory = false;
        private bool m_ClearSelections = false;

        #endregion

        #region constructors

        public JobUpdateValues(
           JobData.JobEnabled? enabled,
           string category,
           string owner,
           JobData.NotifyLevel? notifyLevelEventLog,
           JobData.NotifyLevel? notifyLevelEmail,
           JobData.NotifyLevel? notifyLevelNetSend,
           JobData.NotifyLevel? notifyLevelPage,
           string notifyOpEmail,
           string notifyOpNetSend,
           string notifyOpPage,
           bool createCategory,
           bool clearSelections
        )
        {
            // data values
            m_Enabled = enabled;
            m_Category = category;
            m_Owner = owner;
            m_NotifyLevelEventLog = notifyLevelEventLog;
            m_NotifyLevelEmail = notifyLevelEmail;
            m_NotifyLevelNetSend = notifyLevelNetSend;
            m_NotifyLevelPage = notifyLevelPage;
            m_NotifyOpEmail = notifyOpEmail;
            m_NotifyOpNetSend = notifyOpNetSend;
            m_NotifyOpPage = notifyOpPage;

            // options
            m_CreateCategory = createCategory;
            m_ClearSelections = clearSelections;
        }

        #endregion

        #region properties

        public JobData.JobEnabled? Enabled
        {
            get
            {
                return m_Enabled;
            }
        }

        public string Category
        {
            get
            {
                return m_Category;
            }
        }

        public string Owner
        {
            get
            {
                return m_Owner;
            }
        }

        public JobData.NotifyLevel? NotifyLevelEventLog
        {
            get
            {
                return m_NotifyLevelEventLog;
            }
        }

        public JobData.NotifyLevel? NotifyLevelEmail
        {
            get
            {
                return m_NotifyLevelEmail;
            }
        }

        public JobData.NotifyLevel? NotifyLevelNetSend
        {
            get
            {
                return m_NotifyLevelNetSend;
            }
        }

        public JobData.NotifyLevel? NotifyLevelPage
        {
            get
            {
                return m_NotifyLevelPage;
            }
        }

        public string NotifyOpEmail
        {
            get
            {
                return m_NotifyOpEmail;
            }
        }

        public string NotifyOpNetSend
        {
            get
            {
                return m_NotifyOpNetSend;
            }
        }

        public string NotifyOpPage
        {
            get
            {
                return m_NotifyOpPage;
            }
        }

        public bool CreateCategory
        {
            get
            {
                return m_CreateCategory;
            }
        }

        public bool ClearSelections
        {
            get
            {
                return m_ClearSelections;
            }
        }

        #endregion
    }

    public class JobUpdateResults : JobPoolResults
    {
        #region constants and enums

        public enum UpdateStatus
        {
            Success = 0,
            Failed = 1,
            Unknown = 2
        }

        public const string ColServer = @"server";
        public const string ColJob = @"jobname";
        public const string ColUpdateStatus = @"status";
        public const string ColErrorText = @"errortext";

        #endregion

        #region fields

        //Counts
        private int m_CountSuccessful = 0;
        private int m_CountFailed = 0;

        #endregion

        #region constructor

        public JobUpdateResults(string server, JobPoolOptions options) : base(server, options)
        {
            Results = new DataTable();

            Results.Columns.Add(new DataColumn(ColServer, typeof(string)));
            Results.Columns.Add(new DataColumn(ColJob, typeof(string)));
            Results.Columns.Add(new DataColumn(ColUpdateStatus, typeof(UpdateStatus)));
            Results.Columns.Add(new DataColumn(ColErrorText, typeof(string)));
        }

        #endregion

        #region properties

        public DataTable Results;

        public int JobCount
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

        public void AddResult(string jobName, UpdateStatus status, string errorText)
        {
            DataRow row = Results.NewRow();
            ServerInformation server = new ServerInformation(m_Server);
            row[ColServer] = server.ActualName;
            row[ColJob] = jobName;
            row[ColUpdateStatus] = status;
            row[ColErrorText] = errorText;

            if (status == UpdateStatus.Success)
            {
                m_CountSuccessful++;
            }
            else if (status == UpdateStatus.Failed)
            {
                m_CountFailed++;
            }

            Results.Rows.Add(row);
        }

        #endregion
    }

    #endregion
}
