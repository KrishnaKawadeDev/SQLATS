using System;
using System.Data;
using System.Data.SqlClient;

namespace Idera.SqlAdminToolset.JobMover.DataObjects
{
    public class JobMetaInfo : JobInfo
    {
        public JobMetaInfo(Guid jobId)
        {
            this.JobId = jobId;

            this.enabled = true;
            this.notifyLevelEventLog = 2;//(int)CompletionAction.OnFailure; // SMO

            this.categoryId = -1;
            this.deleteLevel = 0;
            this.notifyLevelEmail = 0;
            this.notifyLevelNetsend = 0;
            this.notifyLevelPage = 0;
            this.startStepId = 1;
        }

        public JobMetaInfo(SqlConnection conn, Guid jobId)
        {
            this.JobId = jobId;

            LoadData(conn);
        }

        #region Properties

        #region Parameter names

        private const string paramJobNameOut = "name";
        private const string paramCategoryNameOut = "category";
        private const string paramOwnerLoginNameOut = "owner";
        private const string paramNotifyEmailOperatorNameOut = "notify_email_operator";
        private const string paramNotifyNetsendOperatorNameOut = "notify_netsend_operator";
        private const string paramNotifyPageOperatorNameOut = "notify_page_operator";

        private const string paramEnabled = "enabled";
        private const string paramDescription = "description";
        private const string paramStartStepId = "start_step_id";
        private const string paramCategoryName = "category_name";
        private const string paramCategoryId = "category_id";
        private const string paramOwnerLoginName = "owner_login_name";
        private const string paramNotifyLevelEventLog = "notify_level_eventlog";
        private const string paramNotifyLevelEmail = "notify_level_email";
        private const string paramNotifyLevelNetsend = "notify_level_netsend";
        private const string paramNotifyLevelPage = "notify_level_page";
        private const string paramNotifyEmailOperatorName = "notify_email_operator_name";
        private const string paramNotifyNetsendOperatorName = "notify_netsend_operator_name";
        private const string paramNotifyPageOperatorName = "notify_page_operator_name";
        private const string paramDeleteLevel = "delete_level";

        #endregion

        private bool enabled;
        /// <summary>
        /// Gets/sets whether the job is enabled.
        /// </summary>
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        private string description;
        /// <summary>
        /// Gets/sets the job description.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; EnforceLength(ref description, 512); }
        }

        private int startStepId;
        /// <summary>
        /// Gets/sets the start step id.
        /// </summary>
        public int StartStepId
        {
            get { return startStepId; }
            set { startStepId = value; }
        }

        private string categoryName;
        /// <summary>
        /// Gets/sets the cateogory name of the job.
        /// </summary>
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; EnforceLength(ref categoryName, 128); }
        }

        private int categoryId;
        /// <summary>
        /// Gets/sets the cateogry id.
        /// </summary>
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        private string ownerLoginName;
        /// <summary>
        /// Gets/sets the job owner login id.
        /// </summary>
        public string OwnerLoginName
        {
            get { return ownerLoginName; }
            set { ownerLoginName = value; EnforceLength(ref ownerLoginName, 128); }
        }

        private int notifyLevelEventLog;
        /// <summary>
        /// Gets/sets the notify level event log level.
        /// </summary>
        public int NotifyLevelEventLog
        {
            get { return notifyLevelEventLog; }
            set { notifyLevelEventLog = value; }
        }

        private int notifyLevelEmail;

        public int NotifyLevelEmail
        {
            get { return notifyLevelEmail; }
            set { notifyLevelEmail = value; }
        }

        private int notifyLevelNetsend;

        public int NotifyLevelNetsend
        {
            get { return notifyLevelNetsend; }
            set { notifyLevelNetsend = value; }
        }

        private int notifyLevelPage;

        public int NotifyLevelPage
        {
            get { return notifyLevelPage; }
            set { notifyLevelPage = value; }
        }

        private string notifyEmailOperatorName;

        public string NotifyEmailOperatorName
        {
            get { return notifyEmailOperatorName; }
            set { notifyEmailOperatorName = value; EnforceLength(ref notifyEmailOperatorName, 128); }
        }

        private string notifyNetsendOperatorName;

        public string NotifyNetsendOperatorName
        {
            get { return notifyNetsendOperatorName; }
            set { notifyNetsendOperatorName = value; EnforceLength(ref notifyNetsendOperatorName, 128); }
        }

        private string notifyPageOperatorName;

        public string NotifyPageOperatorName
        {
            get { return notifyPageOperatorName; }
            set { notifyPageOperatorName = value; EnforceLength(ref notifyPageOperatorName, 128); }
        }

        private int deleteLevel;

        public int DeleteLevel
        {
            get { return deleteLevel; }
            set { deleteLevel = value; }
        }

        #endregion

        #region Overrides

        protected override void Initialize()
        {
            jobDataType = JobDataType.JobMeta;
            spHelpCommand = "sp_help_job";
            spAddCommand = "sp_add_job";
            spUpdateCommand = "sp_update_job";
            spDeleteCommand = "sp_delete_job";
        }

        protected override void SaveData(SqlConnection connection)
        {
            // Add the parameters for the command
            AddStringParam(JobName, paramJobName);
            AddStringParam(description, paramDescription);
            AddStringParam(categoryName, paramCategoryName);

            AddStringParam(ownerLoginName, paramOwnerLoginName);

            if (notifyLevelEmail != (int)JobData.NotifyLevel.Never &&
                  notifyEmailOperatorName != "(unknown)")
            {
                AddStringParam(notifyEmailOperatorName, paramNotifyEmailOperatorName);
            }
            if (notifyLevelNetsend != (int)JobData.NotifyLevel.Never &&
                  notifyNetsendOperatorName != "(unknown)")
            {
                AddStringParam(notifyNetsendOperatorName, paramNotifyNetsendOperatorName);
            }
            if (notifyLevelPage != (int)JobData.NotifyLevel.Never &&
                  notifyPageOperatorName != "(unknown)")
            {
                AddStringParam(notifyPageOperatorName, paramNotifyPageOperatorName);
            }

            AddIntParam(startStepId, paramStartStepId);
            AddIntParam(notifyLevelEventLog, paramNotifyLevelEventLog);
            AddIntParam(notifyLevelEmail, paramNotifyLevelEmail);
            AddIntParam(notifyLevelNetsend, paramNotifyLevelNetsend);
            AddIntParam(notifyLevelPage, paramNotifyLevelPage);
            AddIntParam(deleteLevel, paramDeleteLevel);

            AddBooleanParam(enabled, paramEnabled);

            // Add as last parameter, since this is output
            AddGuidParam(JobId, paramJobId, ParameterDirection.Output);

            using (DataTable table = ExecuteStoredProc(connection, spAddCommand))
            {
                //if (table == null)
                //    throw new ApplicationException("Unable to save job "+ JobName + " on "+ ConnectionInfo.InstanceName);

                this.JobId = new Guid(parameters[parameters.Count - 1].Value.ToString());
            }

            // Need to associate this job with a job server
            parameters.Clear();
            AddGuidParam(JobId, paramJobId);
            AddStringParam("(LOCAL)", "server_name");
            ExecuteStoredProcNonQuery(connection, "sp_add_jobserver");
        }

        protected override void UpdateData(SqlConnection connection)
        {
            if (JobId == Guid.Empty)
                throw new ApplicationException(String.Format("Cannot update job {0} because Job id is empty.", JobName));

            // Add the parameters for the command
            AddGuidParam(JobId, paramJobId);

            //AddStringParam(JobName,                   paramJobName);
            AddStringParam(description, paramDescription);
            AddStringParam(categoryName, paramCategoryName);

            //if (this.ConnectionInfo.SecurityModel == SecurityModel.User)
            AddStringParam(ownerLoginName, paramOwnerLoginName);

            AddStringParam(notifyEmailOperatorName, paramNotifyEmailOperatorName);
            AddStringParam(notifyNetsendOperatorName, paramNotifyNetsendOperatorName);
            AddStringParam(notifyPageOperatorName, paramNotifyPageOperatorName);

            AddIntParam(startStepId, paramStartStepId);
            AddIntParam(notifyLevelEventLog, paramNotifyLevelEventLog);
            AddIntParam(notifyLevelEmail, paramNotifyLevelEmail);
            AddIntParam(notifyLevelNetsend, paramNotifyLevelNetsend);
            AddIntParam(notifyLevelPage, paramNotifyLevelPage);
            AddIntParam(deleteLevel, paramDeleteLevel);

            AddBooleanParam(enabled, paramEnabled);

            // Execute the udpate
            ExecuteStoredProcNonQuery(connection, spUpdateCommand);
        }

        protected override void LoadData(SqlConnection connection)
        {
            if (JobId == Guid.Empty)
                throw new ApplicationException(String.Format("Cannot load job {0} because Job id is empty.", JobName));

            // Add the parameters for the command
            AddGuidParam(JobId, paramJobId);

            using (DataTable table = ExecuteStoredProc(connection, spHelpCommand))
            {
                if (table == null || table.Rows.Count == 0)
                    throw new ApplicationException("Unable to load job " + JobName);

                LoadDataRow(table.Rows[0]);
            }
        }

        protected override void DeleteData(SqlConnection connection)
        {
            if (JobId == Guid.Empty)
                throw new ApplicationException(String.Format("Cannot delete job {0} because Job id is empty.", JobName));

            // Add the parameters for the command
            AddGuidParam(JobId, paramJobId);

            ExecuteStoredProcNonQuery(connection, spDeleteCommand);
        }

        protected override AgentObjectExistenceType CheckExistenceData(SqlConnection connection)
        {
            // If we have an id, then we search by ID for the job.  If we don't have an ID, then we search by name.  
            // If we search by name and find a job already there, then it means it was from a previous policy (or else 
            // is similarly named.  So, in that case we'll have to get permission from the user to update (...)

            if (JobId != Guid.Empty)
            {
                AddGuidParam(JobId, paramJobId);

                AgentObjectExistenceType existence = CheckExistenceWithParamAlreadySpecified(connection, false);

                // If the job id does not return a value, then we will have to continue and search by name
                // If the id returns a match of any kind, then we found our job.
                if (existence != AgentObjectExistenceType.NotExists)
                    return existence;

                parameters.Clear();
            }

            // We go here, so now we search by name
            AddStringParam(JobName, paramJobName);

            return CheckExistenceWithParamAlreadySpecified(connection, true);
        }

        public AgentObjectExistenceType CheckNameExists(SqlConnection connection, SqlTransaction trans)
        {
            transaction = trans;

            parameters.Clear();
            AddStringParam(JobName, paramJobName);

            AgentObjectExistenceType AgentObjectExistenceType = CheckExistenceWithParamAlreadySpecified(connection, true);

            transaction = null;

            return AgentObjectExistenceType;
        }

        public AgentObjectExistenceType CheckNameExists(SqlConnection connection)
        {
            AddStringParam(JobName, paramJobName);

            return CheckExistenceWithParamAlreadySpecified(connection, true);
        }

        /// <summary>
        /// The search parameter value (either name or id) should already be specified by the caller.
        /// </summary>
        /// <param name="searchedByName"></param>
        /// <returns></returns>
        private AgentObjectExistenceType CheckExistenceWithParamAlreadySpecified(SqlConnection connection, bool searchedByName)
        {
            // The search parameter value (either name or id) should already be specified by the caller.            

            try
            {
                using (DataTable table = ExecuteStoredProc(connection, spHelpCommand))
                {
                    if (table == null || table.Rows.Count == 0)
                    {
                        return AgentObjectExistenceType.NotExists;
                    }

                    DataRow row = table.Rows[0];

                    if (searchedByName)
                    {
                        // Get the id of the pre-existing job
                        this.JobId = ReadColumn<Guid>(paramJobId, row);
                    }

                    // It exists, so load all its parameters and compare.  If any don't match, then something's different...

                    // Get the job ID if we don't have it
                    if (JobId == Guid.Empty)
                        this.JobId = ReadColumn<Guid>(paramJobId, row);

                    //if (ReadColumn<int>(paramDeleteLevel, row) != this.deleteLevel) { logger.Debug(string.Format("JobMetaInfo.CheckExistence: delete level: {0}, {1}", ReadColumn<int>(paramDeleteLevel, row), this.deleteLevel)); return AgentObjectExistenceType.ExistsMismatch; }
                    //if ((ReadColumn<byte>(paramEnabled, row) == 1) != this.enabled) { logger.Debug(string.Format("JobMetaInfo.CheckExistence: enabled: {0}, {1}", ReadColumn<byte>(paramEnabled, row), this.enabled)); return AgentObjectExistenceType.ExistsMismatch; }
                    //if (String.Compare(ReadColumn<string>(paramJobNameOut, row), this.JobName, true) != 0) { logger.Debug(string.Format("JobMetaInfo.CheckExistence: JobName: [{0}], [{1}]", ReadColumn<string>(paramJobNameOut, row), this.JobName)); return AgentObjectExistenceType.ExistsMismatch; }
                    //if (ReadColumn<int>(paramNotifyLevelEmail, row) != this.notifyLevelEmail) { logger.Debug(string.Format("JobMetaInfo.CheckExistence: notifyLevelEmail: {0}, {1}", ReadColumn<int>(paramNotifyLevelEmail, row), this.notifyLevelEmail)); return AgentObjectExistenceType.ExistsMismatch; }
                    //if (ReadColumn<int>(paramNotifyLevelEventLog, row) != this.notifyLevelEventLog) { logger.Debug(string.Format("JobMetaInfo.CheckExistence: notifyLevelEventLog: {0}, {1}", ReadColumn<int>(paramNotifyLevelEventLog, row), this.notifyLevelEventLog)); return AgentObjectExistenceType.ExistsMismatch; }
                    //if (ReadColumn<int>(paramNotifyLevelNetsend, row) != this.notifyLevelNetsend) { logger.Debug(string.Format("JobMetaInfo.CheckExistence: notifyLevelNetsend: {0}, {1}", ReadColumn<int>(paramNotifyLevelNetsend, row), this.notifyLevelNetsend)); return AgentObjectExistenceType.ExistsMismatch; }
                    //if (ReadColumn<int>(paramNotifyLevelPage, row) != this.notifyLevelPage) { logger.Debug(string.Format("JobMetaInfo.CheckExistence: notifyLevelPage: {0}, {1}", ReadColumn<int>(paramNotifyLevelPage, row), this.notifyLevelPage)); return AgentObjectExistenceType.ExistsMismatch; }
                    //if (ReadColumn<int>(paramStartStepId, row) != this.startStepId) { logger.Debug(string.Format("JobMetaInfo.CheckExistence: startStepId: {0}, {1}", ReadColumn<int>(paramStartStepId, row), this.startStepId)); return AgentObjectExistenceType.ExistsMismatch; }

                    //if (String.Compare(ReadColumn<string>(paramCategoryNameOut, row), this.categoryName, true) != 0 && ReadColumn<string>(paramCategoryNameOut, row) != "[Uncategorized (Local)]")
                    //{
                    //   logger.Debug(string.Format("JobMetaInfo.CheckExistence: categoryName: {0}, {1}", ReadColumn<string>(paramCategoryNameOut, row), this.categoryName));
                    //   return AgentObjectExistenceType.ExistsMismatch;
                    //}

                    //if (String.Compare(ReadColumn<string>(paramDescription, row), this.description, true) != 0 && ReadColumn<string>(paramDescription, row) != "No description available.")
                    //{
                    //   logger.Debug(string.Format("JobMetaInfo.CheckExistence: description: {0}, {1}", ReadColumn<string>(paramDescription, row), this.description));
                    //   return AgentObjectExistenceType.ExistsMismatch;
                    //}

                    //if (ReadColumn<string>(paramNotifyEmailOperatorNameOut, row) != this.notifyEmailOperatorName && ReadColumn<string>(paramNotifyEmailOperatorNameOut, row) != "(unknown)")
                    //{
                    //   logger.Debug(string.Format("JobMetaInfo.CheckExistence: notifyEmailOperatorName: {0}, {1}", ReadColumn<string>(paramNotifyEmailOperatorNameOut, row), this.notifyEmailOperatorName));
                    //   return AgentObjectExistenceType.ExistsMismatch;
                    //}

                    //if (ReadColumn<string>(paramNotifyNetsendOperatorNameOut, row) != this.notifyNetsendOperatorName && ReadColumn<string>(paramNotifyNetsendOperatorNameOut, row) != "(unknown)")
                    //{
                    //   logger.Debug(string.Format("JobMetaInfo.CheckExistence: notifyNetsendOperatorName: {0}, {1}", ReadColumn<string>(paramNotifyNetsendOperatorNameOut, row), this.notifyNetsendOperatorName));
                    //   return AgentObjectExistenceType.ExistsMismatch;
                    //}

                    //if (ReadColumn<string>(paramNotifyPageOperatorNameOut, row) != this.notifyPageOperatorName && ReadColumn<string>(paramNotifyPageOperatorNameOut, row) != "(unknown)")
                    //{
                    //   logger.Debug(string.Format("JobMetaInfo.CheckExistence: notifyPageOperatorName: {0}, {1}", ReadColumn<string>(paramNotifyPageOperatorNameOut, row), this.notifyPageOperatorName));
                    //   return AgentObjectExistenceType.ExistsMismatch;
                    //}
                }
            }
            catch (Exception e)
            {
                if (e is SqlException)
                {
                    logger.Debug("JobMetaInfo.CheckExistenceData: Caught exception: " + e.Message);
                    return AgentObjectExistenceType.NotExists;
                }
                else
                    throw;
            }

            return AgentObjectExistenceType.Exists;
        }

        protected override bool Equals<T>(T info)
        {
            if (info == null || !(info is JobMetaInfo))
                return false;

            JobMetaInfo other = info as JobMetaInfo;

            return this.JobId == other.JobId &&
                   this.JobName == other.JobName &&
                   this.categoryId == other.CategoryId &&
                   this.categoryName == other.CategoryName &&
                   this.deleteLevel == other.DeleteLevel &&
                   this.description == other.Description &&
                   this.enabled == other.Enabled &&
                   this.notifyEmailOperatorName == other.NotifyEmailOperatorName &&
                   this.notifyLevelEmail == other.NotifyLevelEmail &&
                   this.notifyLevelEventLog == other.NotifyLevelEventLog &&
                   this.notifyLevelNetsend == other.NotifyLevelNetsend &&
                   this.notifyLevelPage == other.NotifyLevelPage &&
                   this.notifyNetsendOperatorName == other.NotifyNetsendOperatorName &&
                   this.notifyPageOperatorName == other.NotifyPageOperatorName &&
                   this.ownerLoginName == other.OwnerLoginName &&
                   this.startStepId == other.StartStepId;
        }

        #endregion

        private static bool jobEnable = false;
        private static bool jobDisable = false;
        public static void CheckJobInput(bool jobenable, bool jobdisable)
        {
            jobEnable = jobenable;
            jobDisable = jobdisable;
        }

        protected void LoadDataRow(DataRow jobData)
        {
            this.categoryName = ReadColumn<string>(paramCategoryNameOut, jobData);
            this.deleteLevel = ReadColumn<int>(paramDeleteLevel, jobData);
            this.description = ReadColumn<string>(paramDescription, jobData);

            //if (jobEnable == false && jobDisable == false)
            //{
            //    this.enabled = ReadColumn<byte>(paramEnabled, jobData) == 1;
            //}
            //else if (jobEnable == true && jobDisable == false)
            //{
            //    this.enabled = ReadColumn<byte>(paramEnabled, jobData) == 1;
            //}
            //else if (jobEnable == false && jobDisable == true)
            //{
            //    this.enabled = ReadColumn<byte>(paramEnabled, jobData) == 0;
            //}

            this.enabled = ReadColumn<byte>(paramEnabled, jobData) == 1; // old code comment 
            this.JobName = ReadColumn<string>(paramJobNameOut, jobData);
            this.notifyEmailOperatorName = ReadColumn<string>(paramNotifyEmailOperatorNameOut, jobData);
            this.notifyLevelEmail = ReadColumn<int>(paramNotifyLevelEmail, jobData);
            this.notifyLevelEventLog = ReadColumn<int>(paramNotifyLevelEventLog, jobData);
            this.notifyLevelNetsend = ReadColumn<int>(paramNotifyLevelNetsend, jobData);
            this.notifyLevelPage = ReadColumn<int>(paramNotifyLevelPage, jobData);
            this.notifyNetsendOperatorName = ReadColumn<string>(paramNotifyNetsendOperatorNameOut, jobData);
            this.notifyPageOperatorName = ReadColumn<string>(paramNotifyPageOperatorNameOut, jobData);
            this.ownerLoginName = ReadColumn<string>(paramOwnerLoginNameOut, jobData);
            this.startStepId = ReadColumn<int>(paramStartStepId, jobData);
        }

        public void ClearNotifications()
        {
            deleteLevel =
               notifyLevelEventLog =
               notifyLevelEmail =
               notifyLevelNetsend =
               notifyLevelPage = (int)JobData.NotifyLevel.Never;
            notifyEmailOperatorName =
               notifyNetsendOperatorName =
               notifyPageOperatorName = string.Empty;
        }
    }
}
