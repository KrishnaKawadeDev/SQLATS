using System;
using System.Data;
using System.Data.SqlClient;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.JobMover.DataObjects
{
   public class JobStepResultInfo : JobInfo
   {
      public JobStepResultInfo(JobMetaInfo jobMetaInfo)
      {
         this.stepId          = 1;
         this.OnSuccessAction = 1;// (int)StepCompletionAction.QuitWithSuccess; // SMO (agent)
         this.onFailAction    = 2;// (int)StepCompletionAction.QuitWithFailure; // SMO (agent)

         this.jobMetaInfo = jobMetaInfo;
         this.JobName     = jobMetaInfo.JobName;
         this.JobId       = jobMetaInfo.JobId;
      }

      public JobStepResultInfo(JobMetaInfo jobMetaInfo, DataRow jobSteps)
      {
         this.jobMetaInfo = jobMetaInfo;
         this.JobName     = jobMetaInfo.JobName;
         this.JobId       = jobMetaInfo.JobId;

         LoadDataRow(jobSteps);
      }

      #region Properties

      #region Parameter names

      private const string paramStepId          = "step_id";
      private const string paramOnSuccessAction = "on_success_action";
      private const string paramOnSuccessStepId = "on_success_step_id";
      private const string paramOnFailAction    = "on_fail_action";
      private const string paramOnFailStepId    = "on_fail_step_id";
      private const string paramServer          = "server";

      #endregion

      private readonly JobMetaInfo jobMetaInfo;
      private int stepId;

      public int StepId
      {
         get { return stepId; }
         set { stepId = value; }
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


      #endregion

      #region Overrides

      protected override void Initialize()
      {
         jobDataType     = JobDataType.JobStepResult;
         spHelpCommand   = "sp_help_jobstep";
         spAddCommand    = "sp_add_jobstep";
         spUpdateCommand = "sp_update_jobstep";
         spDeleteCommand = "sp_delete_jobstep";
      }

      protected override void SaveData(SqlConnection connection)
      {
         this.JobId = jobMetaInfo.JobId;

         if (JobId == Guid.Empty)
            throw new ApplicationException(String.Format("Cannot save job step {0} for job {1} because JobId id is empty.", stepId, JobName));

         parameters.Clear();

         AddGuidParam(JobId,          paramJobId);
         AddIntParam(stepId,          paramStepId);
         AddIntParam(onSuccessAction, paramOnSuccessAction);
         AddIntParam(onSuccessStepId, paramOnSuccessStepId);
         AddIntParam(onFailAction,    paramOnFailAction);
         AddIntParam(onFailStepId,    paramOnFailStepId);

         // Execute the save
         ExecuteStoredProcNonQuery(connection, spUpdateCommand);
      }

      protected override void UpdateData(SqlConnection connection)
      {
         this.JobId = jobMetaInfo.JobId;

         if (JobId == Guid.Empty)
            throw new ApplicationException(String.Format("Cannot update job step {0} for job {1} because JobId id is empty.", stepId, JobName));

         parameters.Clear();

         AddGuidParam(JobId,          paramJobId);
         AddIntParam(stepId,          paramStepId);
         AddIntParam(onSuccessAction, paramOnSuccessAction);
         AddIntParam(onSuccessStepId, paramOnSuccessStepId);
         AddIntParam(onFailAction,    paramOnFailAction);
         AddIntParam(onFailStepId,    paramOnFailStepId);

         // Execute the save
         ExecuteStoredProcNonQuery(connection, spUpdateCommand);
      }

      protected override void LoadData(SqlConnection connection)
      {
         this.JobId = jobMetaInfo.JobId;

         if (JobId == Guid.Empty)
            throw new ApplicationException(String.Format("Cannot load job step {0} for job {1} because JobId id is empty.", stepId, JobName));

         // Add the parameters for the command
         AddGuidParam(JobId, paramJobId);
         AddIntParam(stepId, paramStepId);

         using (DataTable table = ExecuteStoredProc(connection, spHelpCommand))
         {
            if (table == null || table.Rows.Count == 0)
               throw new ApplicationException("Unable to load job step " + stepId + " for job " + JobName);

            LoadDataRow(table.Rows[0]);
         }
      }

      protected override void DeleteData(SqlConnection connection)
      {
         this.JobId = jobMetaInfo.JobId;

         if (JobId == Guid.Empty)
            throw new ApplicationException(String.Format("Cannot delete job step {0} for job {1} because JobId id is empty.", stepId, JobName));

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
               if ((int)ReadColumn<byte>(paramOnSuccessAction, row) != this.onSuccessAction) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: onSuccessAction: {0}, {1}", ReadColumn<byte>(paramOnSuccessAction, row), this.onSuccessAction)); return AgentObjectExistenceType.ExistsMismatch; }
               if (ReadColumn<int>(paramOnSuccessStepId, row) != this.onSuccessStepId) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: onSuccessStepId: {0}, {1}", ReadColumn<int>(paramOnSuccessStepId, row), this.onSuccessStepId)); return AgentObjectExistenceType.ExistsMismatch; }
               if ((int)ReadColumn<byte>(paramOnFailAction, row) != this.onFailAction) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: onFailAction: {0}, {1}", ReadColumn<byte>(paramOnFailAction, row), this.onFailAction)); return AgentObjectExistenceType.ExistsMismatch; }
               if (ReadColumn<int>(paramOnFailStepId, row) != this.onFailStepId) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: onFailStepId: {0}, {1}", ReadColumn<int>(paramOnFailStepId, row), this.onFailStepId)); return AgentObjectExistenceType.ExistsMismatch; }
            }
         }
         catch (Exception e)
         {
            if (e is SqlException)
            {
               logger.Error("JobStepResultInfo.CheckExistenceData: Caught exception: " + e.Message);
               return AgentObjectExistenceType.NotExists;
            }
            else
               throw;
         }

         return AgentObjectExistenceType.Exists;
      }

      protected override bool Equals<T>(T info)
      {
         if (info == null || !(info is JobStepResultInfo))
            return false;

         JobStepResultInfo other = info as JobStepResultInfo;

         return this.JobId == other.JobId &&
                this.onFailAction == other.OnFailAction &&
                this.onFailStepId == other.OnFailStepId &&
                this.onSuccessAction == other.OnSuccessAction &&
                this.onSuccessStepId == other.OnSuccessStepId &&
                this.server == other.Server &&
                this.stepId == other.StepId;
      }

      #endregion

      protected void LoadDataRow(DataRow jobData)
      {
         this.stepId          = ReadColumn<int>(paramStepId, jobData);
         this.onSuccessAction = (int)ReadColumn<byte>(paramOnSuccessAction, jobData);
         this.onSuccessStepId = ReadColumn<int>(paramOnSuccessStepId, jobData);
         this.onFailAction    = (int)ReadColumn<byte>(paramOnFailAction, jobData);
         this.onFailStepId    = ReadColumn<int>(paramOnFailStepId, jobData);
      }
   }
}
