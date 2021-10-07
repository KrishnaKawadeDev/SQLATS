using System;
using System.Data;
using System.Data.SqlClient;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.JobMover.DataObjects
{
    public class JobStepInfo : JobInfo
    {
        public JobStepInfo(JobMetaInfo jobMetaInfo)
        {
            this.stepId = 1;
            this.subsystem = "CMDEXEC";
            this.retryAttempts = 1;// SharedConstants.JobStepRetryAttempts;
            this.RetryInterval = 100;// SharedConstants.JobStepRetryInterval;
            this.OnSuccessAction = 1;// (int)StepCompletionAction.QuitWithSuccess; // SMO (agent)
            this.onFailAction = 2;// (int)StepCompletionAction.QuitWithFailure; // SMO (agent)

            this.jobMetaInfo = jobMetaInfo;
            this.JobName = jobMetaInfo.JobName;
            this.JobId = jobMetaInfo.JobId;
        }

        public JobStepInfo(JobMetaInfo jobMetaInfo, DataRow jobSteps)
        {
            this.jobMetaInfo = jobMetaInfo;
            this.JobName = jobMetaInfo.JobName;
            this.JobId = jobMetaInfo.JobId;

            LoadDataRow(jobSteps);
        }

        #region Properties

        #region Parameter names

        private const string paramStepId = "step_id";
        private const string paramStepName = "step_name";
        private const string paramSubsytem = "subsystem";
        private const string paramCommand = "command";
        private const string paramAdditionalParameters = "additional_parameters";
        private const string paramCmdExecSuccesCode = "cmdexec_success_code";
        private const string paramOnSuccessAction = "on_success_action";
        private const string paramOnSuccessStepId = "on_success_step_id";
        private const string paramOnFailAction = "on_fail_action";
        private const string paramOnFailStepId = "on_fail_step_id";
        private const string paramServer = "server";
        private const string paramDatabaseName = "database_name";
        private const string paramDatabaseUserName = "database_user_name";
        private const string paramRetryAttempts = "retry_attempts";
        private const string paramRetryInterval = "retry_interval";
        private const string paramOsRunPriority = "os_run_priority";
        private const string paramOutputFilename = "output_file_name";
        private const string paramFlags = "flags";

        #endregion

        private readonly JobMetaInfo jobMetaInfo;
        private int stepId;

        public int StepId
        {
            get { return stepId; }
            set { stepId = value; }
        }

        private string stepName;

        public string StepName
        {
            get { return stepName; }
            set { stepName = value; EnforceLength(ref stepName, 128); }
        }

        private string subsystem;

        public string Subsystem
        {
            get { return subsystem; }
            set { subsystem = value; EnforceLength(ref subsystem, 40); }
        }

        private string command;

        public string Command
        {
            get { return command; }
            set { command = value; EnforceLength(ref command, 3201); }
        }

        private string additionalParameters;

        public string AdditionalParameters
        {
            get { return additionalParameters; }
            set { additionalParameters = value; }
        }

        private int cmdExecSuccessCode;

        public int CmdExecSuccessCode
        {
            get { return cmdExecSuccessCode; }
            set { cmdExecSuccessCode = value; }
        }

        private int onSuccessAction;

        public int OnSuccessAction
        {
            get { return onSuccessAction; }
            set { onSuccessAction = value; }
        }

        private int onSuccessStepId;

        public int OnSuccessStepId
        {
            get { return onSuccessStepId; }
            set { onSuccessStepId = value; }
        }

        private int onFailAction;

        public int OnFailAction
        {
            get { return onFailAction; }
            set { onFailAction = value; }
        }

        private int onFailStepId;

        public int OnFailStepId
        {
            get { return onFailStepId; }
            set { onFailStepId = value; }
        }

        private string server;

        public string Server
        {
            get { return server; }
            set { server = value; EnforceLength(ref server, 30); }
        }

        private string databaseName;

        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; EnforceLength(ref databaseName, 128); }
        }

        private string databaseUserName;

        public string DatabaseUserName
        {
            get { return databaseUserName; }
            set { databaseUserName = value; EnforceLength(ref databaseUserName, 128); }
        }

        private int retryAttempts;

        public int RetryAttempts
        {
            get { return retryAttempts; }
            set { retryAttempts = value; }
        }

        private int retryInterval;

        public int RetryInterval
        {
            get { return retryInterval; }
            set { retryInterval = value; }
        }

        private int osRunPriority;

        public int OsRunPriority
        {
            get { return osRunPriority; }
            set { osRunPriority = value; }
        }

        private string outputFilename;

        public string OutputFilename
        {
            get { return outputFilename; }
            set { outputFilename = value; EnforceLength(ref outputFilename, 200); }
        }

        private int flags;

        public int Flags
        {
            get { return flags; }
            set { flags = value; }
        }

        #endregion

        #region Overrides

        protected override void Initialize()
        {
            jobDataType = JobDataType.JobStep;
            spHelpCommand = "sp_help_jobstep";
            spAddCommand = "sp_add_jobstep";
            spUpdateCommand = "sp_update_jobstep";
            spDeleteCommand = "sp_delete_jobstep";
        }

        protected override void SaveData(SqlConnection connection)
        {
            this.JobId = jobMetaInfo.JobId;

            if (JobId == Guid.Empty)
                throw new ApplicationException(String.Format("Cannot save job step {0} for job {1} because JobId id is empty.", stepName, JobName));

            // Clear out the parameters used by Delete
            parameters.Clear();

            AddGuidParam(JobId, paramJobId);
            AddIntParam(stepId, paramStepId);
            AddStringParam(stepName, paramStepName);
            AddStringParam(subsystem, paramSubsytem);
            AddStringParam(command, paramCommand);
            AddIntParam(cmdExecSuccessCode, paramCmdExecSuccesCode);
            //AddIntParam(onSuccessAction, paramOnSuccessAction);
            //AddIntParam(onSuccessStepId, paramOnSuccessStepId);
            //AddIntParam(onFailAction, paramOnFailAction);
            //AddIntParam(onFailStepId, paramOnFailStepId);
             AddIntParam(flags, paramFlags);
            AddStringParam(databaseName, paramDatabaseName);
            AddIntParam(retryAttempts, paramRetryAttempts);
            AddIntParam(retryInterval, paramRetryInterval);
            AddStringParam(outputFilename, paramOutputFilename);

            // Execute the save
            ExecuteStoredProcNonQuery(connection, spAddCommand);
        }

        protected override void UpdateData(SqlConnection connection)
        {
            this.JobId = jobMetaInfo.JobId;

            if (JobId == Guid.Empty)
                throw new ApplicationException(String.Format("Cannot update job step {0} for job {1} because JobId id is empty.", stepName, JobName));

            // Delete all previous steps, then create/save
            DeleteData(connection);

            // Clear out the parameters used by Delete
            parameters.Clear();

            AddGuidParam(JobId, paramJobId);
            AddIntParam(stepId, paramStepId);
            AddStringParam(stepName, paramStepName);
            AddStringParam(subsystem, paramSubsytem);
            AddStringParam(command, paramCommand);
            AddIntParam(cmdExecSuccessCode, paramCmdExecSuccesCode);
            //AddIntParam(onSuccessAction, paramOnSuccessAction);
            //AddIntParam(onSuccessStepId, paramOnSuccessStepId);
            //AddIntParam(onFailAction, paramOnFailAction);
            //AddIntParam(onFailStepId, paramOnFailStepId);
            AddIntParam(flags, paramFlags);
            AddStringParam(databaseName, paramDatabaseName);
            AddIntParam(retryAttempts, paramRetryAttempts);
            AddIntParam(retryInterval, paramRetryInterval);
            AddStringParam(outputFilename, paramOutputFilename);

            // Execute the save
            //ExecuteStoredProcNonQuery(connection, spUpdateCommand);
            ExecuteStoredProcNonQuery(connection, spAddCommand); // Because we are deleting all other steps, we should then be saving rather than updating
        }

        protected override void LoadData(SqlConnection connection)
        {
            this.JobId = jobMetaInfo.JobId;

            if (JobId == Guid.Empty)
                throw new ApplicationException(String.Format("Cannot load job step {0} for job {1} because JobId id is empty.", stepName, JobName));

            // Add the parameters for the command
            AddGuidParam(JobId, paramJobId);
            AddIntParam(stepId, paramStepId);

            using (DataTable table = ExecuteStoredProc(connection, spHelpCommand))
            {
                if (table == null || table.Rows.Count == 0)
                    throw new ApplicationException("Unable to load job step " + stepName + " for job " + JobName);

                LoadDataRow(table.Rows[0]);
            }
        }

        protected override void DeleteData(SqlConnection connection)
        {
            this.JobId = jobMetaInfo.JobId;

            if (JobId == Guid.Empty)
                throw new ApplicationException(String.Format("Cannot delete job step {0} for job {1} because JobId id is empty.", stepName, JobName));

            // Add the parameters for the command
            AddGuidParam(JobId, paramJobId);
            AddIntParam(0, paramStepId); // deletes all steps

            ExecuteStoredProcNonQuery(connection, spDeleteCommand);
        }

        protected override AgentObjectExistenceType CheckExistenceData(SqlConnection connection)
        {
            this.JobId = jobMetaInfo.JobId;

            if (JobId == Guid.Empty)
                return AgentObjectExistenceType.NotExists;

            // Run help command to see if step with this id exists at all
            AddGuidParam(JobId, paramJobId);
            AddIntParam(stepId, paramStepId);
            try
            {
                using (DataTable table = ExecuteStoredProc(connection, spHelpCommand))
                {
                    if (table == null || table.Rows.Count == 0)
                    {
                        return AgentObjectExistenceType.NotExists;
                    }

                    DataRow row = table.Rows[0];

                    // It exists, so load all its parameters and compare.  If any don't match, then something's different...

                    if (ReadColumn<int>(paramStepId, row) != this.stepId) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: stepId: {0}, {1}", ReadColumn<int>(paramStepId, row), this.stepId)); return AgentObjectExistenceType.ExistsMismatch; }
                    if (ReadColumn<string>(paramStepName, row) != this.stepName) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: stepName: {0}, {1}", ReadColumn<string>(paramStepName, row), this.stepName)); return AgentObjectExistenceType.ExistsMismatch; }
                    if (ReadColumn<string>(paramSubsytem, row) != this.subsystem) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: subsystem: {0}, {1}", ReadColumn<string>(paramSubsytem, row), this.subsystem)); return AgentObjectExistenceType.ExistsMismatch; }
                    if (ReadColumn<string>(paramCommand, row) != this.command) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: command: {0}, {1}", ReadColumn<string>(paramCommand, row), this.command)); return AgentObjectExistenceType.ExistsMismatch; }
                    if (ReadColumn<int>(paramCmdExecSuccesCode, row) != this.cmdExecSuccessCode) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: cmdExecSuccessCode: {0}, {1}", ReadColumn<int>(paramCmdExecSuccesCode, row), this.cmdExecSuccessCode)); return AgentObjectExistenceType.ExistsMismatch; }
                    if ((int)ReadColumn<byte>(paramOnSuccessAction, row) != this.onSuccessAction) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: onSuccessAction: {0}, {1}", ReadColumn<byte>(paramOnSuccessAction, row), this.onSuccessAction)); return AgentObjectExistenceType.ExistsMismatch; }
                    if (ReadColumn<int>(paramOnSuccessStepId, row) != this.onSuccessStepId) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: onSuccessStepId: {0}, {1}", ReadColumn<int>(paramOnSuccessStepId, row), this.onSuccessStepId)); return AgentObjectExistenceType.ExistsMismatch; }
                    if ((int)ReadColumn<byte>(paramOnFailAction, row) != this.onFailAction) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: onFailAction: {0}, {1}", ReadColumn<byte>(paramOnFailAction, row), this.onFailAction)); return AgentObjectExistenceType.ExistsMismatch; }
                    if (ReadColumn<int>(paramOnFailStepId, row) != this.onFailStepId) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: onFailStepId: {0}, {1}", ReadColumn<int>(paramOnFailStepId, row), this.onFailStepId)); return AgentObjectExistenceType.ExistsMismatch; }
                    if (ReadColumn<string>(paramDatabaseName, row) != this.databaseName) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: databaseName: {0}, {1}", ReadColumn<string>(paramDatabaseName, row), this.databaseName)); return AgentObjectExistenceType.ExistsMismatch; }
                    if (ReadColumn<int>(paramRetryAttempts, row) != this.retryAttempts) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: retryAttempts: {0}, {1}", ReadColumn<int>(paramRetryAttempts, row), this.retryAttempts)); return AgentObjectExistenceType.ExistsMismatch; }
                    if (ReadColumn<int>(paramRetryInterval, row) != this.retryInterval) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: retryInterval: {0}, {1}", ReadColumn<int>(paramRetryInterval, row), this.retryInterval)); return AgentObjectExistenceType.ExistsMismatch; }
                    if (ReadColumn<string>(paramOutputFilename, row) != this.outputFilename) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: outputFilename: {0}, {1}", ReadColumn<string>(paramOutputFilename, row), this.outputFilename)); return AgentObjectExistenceType.ExistsMismatch; }
                }
            }
            catch (Exception e)
            {
                if (e is SqlException)
                {
                    logger.Error("JobStepInfo.CheckExistenceData: Caught exception: " + e.Message);
                    return AgentObjectExistenceType.NotExists;
                }
                else
                    throw;
            }

            return AgentObjectExistenceType.Exists;
        }

        protected override bool Equals<T>(T info)
        {
            if (info == null || !(info is JobStepInfo))
                return false;

            JobStepInfo other = info as JobStepInfo;

            return this.JobId == other.JobId &&
                   this.JobName == other.JobName &&
                   this.additionalParameters == other.AdditionalParameters &&
                   this.cmdExecSuccessCode == other.CmdExecSuccessCode &&
                   this.command == other.Command &&
                   this.databaseName == other.DatabaseName &&
                   this.databaseUserName == other.DatabaseUserName &&
                   this.flags == other.Flags &&
                   this.onFailAction == other.OnFailAction &&
                   this.onFailStepId == other.OnFailStepId &&
                   this.onSuccessAction == other.OnSuccessAction &&
                   this.onSuccessStepId == other.OnSuccessStepId &&
                   this.osRunPriority == other.OsRunPriority &&
                   this.outputFilename == other.OutputFilename &&
                   this.retryAttempts == other.RetryAttempts &&
                   this.retryInterval == other.RetryInterval &&
                   this.server == other.Server &&
                   this.stepId == other.StepId &&
                   this.stepName == other.StepName &&
                   this.subsystem == other.Subsystem;
        }

        #endregion

        protected void LoadDataRow(DataRow jobData)
        {
            this.stepId = ReadColumn<int>(paramStepId, jobData);
            this.stepName = ReadColumn<string>(paramStepName, jobData);
            this.subsystem = ReadColumn<string>(paramSubsytem, jobData);
            this.command = ReadColumn<string>(paramCommand, jobData);
            this.flags = ReadColumn<int>(paramFlags, jobData);
            this.cmdExecSuccessCode = ReadColumn<int>(paramCmdExecSuccesCode, jobData);
            this.onSuccessAction = (int)ReadColumn<byte>(paramOnSuccessAction, jobData);
            this.onSuccessStepId = ReadColumn<int>(paramOnSuccessStepId, jobData);
            this.onFailAction = (int)ReadColumn<byte>(paramOnFailAction, jobData);
            this.onFailStepId = ReadColumn<int>(paramOnFailStepId, jobData);
            this.databaseName = ReadColumn<string>(paramDatabaseName, jobData);
            this.retryAttempts = ReadColumn<int>(paramRetryAttempts, jobData);
            this.retryInterval = ReadColumn<int>(paramRetryInterval, jobData);
            this.outputFilename = ReadColumn<string>(paramOutputFilename,jobData);
        }
    }
}
