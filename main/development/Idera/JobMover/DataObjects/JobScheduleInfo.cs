using System;
using System.Data;
using System.Data.SqlClient;

namespace Idera.SqlAdminToolset.JobMover.DataObjects
{
   public class JobScheduleInfo : JobInfo
   {
      protected new JobDataType jobDataType = JobDataType.JobSchedule;
      protected new string spHelpCommand = "sp_help_jobschedule";
      protected new string spAddCommand = "sp_add_jobschedule";
      protected new string spUpdateCommand = "sp_update_jobschedule";
      protected new string spDeleteCommand = "sp_delete_jobschedule";

      public JobScheduleInfo(JobMetaInfo jobMetaInfo)
      {
         this.enabled = true;
         this.activeEndDate = 99991231;
         this.activeEndTime = 235959;

         this.jobMetaInfo = jobMetaInfo;
         this.JobName = jobMetaInfo.JobName;
         this.JobId = jobMetaInfo.JobId;
      }

      public JobScheduleInfo(JobMetaInfo jobMetaInfo, DataRow jobSchedules)
      {
         this.jobMetaInfo = jobMetaInfo;
         this.JobName = jobMetaInfo.JobName;
         this.JobId = jobMetaInfo.JobId;

         LoadDataRow(jobSchedules);
      }

      #region Properties

      #region Parameter names

      private const string paramName = "name";
      private const string paramEnabled = "enabled";
      private const string paramFrequencyType = "freq_type";
      private const string paramFrequencyInterval = "freq_interval";
      private const string paramFrequencySubdayType = "freq_subday_type";
      private const string paramFrequencySubdayInterval = "freq_subday_interval";
      private const string paramFrequencyRelativeInterval = "freq_relative_interval";
      private const string paramFrequencyRecurrenceFactor = "freq_recurrence_factor";
      private const string paramActiveStartDate = "active_start_date";
      private const string paramActiveEndDate = "active_end_date";
      private const string paramActiveStartTime = "active_start_time";
      private const string paramActiveEndTime = "active_end_time";

      #endregion

      private readonly JobMetaInfo jobMetaInfo;

      private string name;

      public string Name
      {
         get { return name; }
         set { name = value; EnforceLength(ref name, 128); }
      }

      private bool enabled;

      public bool Enabled
      {
         get { return enabled; }
         set { enabled = value; }
      }

      private int frequencytype;

      public int Frequencytype
      {
         get { return frequencytype; }
         set { frequencytype = value; }
      }

      private int frequencyInterval;

      public int FrequencyInterval
      {
         get { return frequencyInterval; }
         set { frequencyInterval = value; }
      }

      private int frequencySubdayType;

      public int FrequencySubdayType
      {
         get { return frequencySubdayType; }
         set { frequencySubdayType = value; }
      }

      private int frequencySubdayInterval;

      public int FrequencySubdayInterval
      {
         get { return frequencySubdayInterval; }
         set { frequencySubdayInterval = value; }
      }

      private int frequencyRelativeInterval;

      public int FrequencyRelativeInterval
      {
         get { return frequencyRelativeInterval; }
         set { frequencyRelativeInterval = value; }
      }

      private int frequencyRecurrenceFactor;

      public int FrequencyRecurrenceFactor
      {
         get { return frequencyRecurrenceFactor; }
         set { frequencyRecurrenceFactor = value; }
      }

      private int activeStartDate;

      public int ActiveStartDate
      {
         get { return activeStartDate; }
         set { activeStartDate = value; }
      }

      private int activeEndDate;

      public int ActiveEndDate
      {
         get { return activeEndDate; }
         set { activeEndDate = value; }
      }

      private int activeStartTime;

      public int ActiveStartTime
      {
         get { return activeStartTime; }
         set { activeStartTime = value; }
      }

      private int activeEndTime;

      public int ActiveEndTime
      {
         get { return activeEndTime; }
         set { activeEndTime = value; }
      }

      #endregion

      #region Overrides

      protected override void Initialize()
      {
         jobDataType = JobDataType.JobSchedule;
         spHelpCommand = "sp_help_jobschedule";
         spAddCommand = "sp_add_jobschedule";
         spUpdateCommand = "sp_update_jobschedule";
         spDeleteCommand = "sp_delete_jobschedule";
      }

      protected override void SaveData(SqlConnection connection)
      {
         this.JobId = jobMetaInfo.JobId;

         if (JobId == Guid.Empty)
            throw new ApplicationException(String.Format("Cannot save job schedule {0} for job {1} because JobId id is empty.", name, JobName));

         //// Delete all schedules, then create/save
         //if (this.ExistenceType == AgentObjectExistenceType.Exists)
         //   DeleteData(connection);

         // Clear out the parameters used by Delete
         parameters.Clear();

         AddGuidParam(JobId, paramJobId);
         AddStringParam(name, paramName);
         AddBooleanParam(enabled, paramEnabled);
         AddIntParam(frequencytype, paramFrequencyType);
         AddIntParam(frequencyInterval, paramFrequencyInterval);
         AddIntParam(frequencySubdayType, paramFrequencySubdayType);
         AddIntParam(frequencySubdayInterval, paramFrequencySubdayInterval);
         AddIntParam(frequencyRelativeInterval, paramFrequencyRelativeInterval);
         AddIntParam(frequencyRecurrenceFactor, paramFrequencyRecurrenceFactor);
         AddIntParam(activeStartDate, paramActiveStartDate);
         AddIntParam(activeEndDate, paramActiveEndDate);
         AddIntParam(activeStartTime, paramActiveStartTime);
         AddIntParam(activeEndTime, paramActiveEndTime);

         // Execute the save
         ExecuteStoredProcNonQuery(connection, spAddCommand);
      }

      protected override void UpdateData(SqlConnection connection)
      {
         this.JobId = jobMetaInfo.JobId;

         if (JobId == Guid.Empty)
            throw new ApplicationException(String.Format("Cannot udpate job schedule {0} for job {1} because JobId id is empty.", name, JobName));

         // Delete all schedules, then create/save
         //if (this.ExistenceType == AgentObjectExistenceType.Exists)
         DeleteData(connection);

         // Clear out the parameters used by Delete
         parameters.Clear();

         AddGuidParam(JobId, paramJobId);
         AddStringParam(name, paramName);
         AddBooleanParam(enabled, paramEnabled);
         AddIntParam(frequencytype, paramFrequencyType);
         AddIntParam(frequencyInterval, paramFrequencyInterval);
         AddIntParam(frequencySubdayType, paramFrequencySubdayType);
         AddIntParam(frequencySubdayInterval, paramFrequencySubdayInterval);
         AddIntParam(frequencyRelativeInterval, paramFrequencyRelativeInterval);
         AddIntParam(frequencyRecurrenceFactor, paramFrequencyRecurrenceFactor);
         AddIntParam(activeStartDate, paramActiveStartDate);
         AddIntParam(activeEndDate, paramActiveEndDate);
         AddIntParam(activeStartTime, paramActiveStartTime);
         AddIntParam(activeEndTime, paramActiveEndTime);

         // Execute the save
         //ExecuteStoredProcNonQuery(connection, spUpdateCommand);
         ExecuteStoredProcNonQuery(connection, spAddCommand); // Since we delete all other schedules, then we should just be saving here rather than updating
      }

      protected override void LoadData(SqlConnection connection)
      {
         this.JobId = jobMetaInfo.JobId;

         if (JobId == Guid.Empty)
            throw new ApplicationException(String.Format("Cannot load job schedule {0} for job {1} because JobId id is empty.", name, JobName));

         // Add the parameters for the command
         AddGuidParam(JobId, paramJobId);
         AddStringParam(name, paramName);

         using (DataTable table = ExecuteStoredProc(connection, spHelpCommand))
         {
            if (table == null || table.Rows.Count == 0)
               throw new ApplicationException("Unable to load job schedule " + name + " for job " + JobName);

            LoadDataRow(table.Rows[0]);
         }
      }

      protected override void DeleteData(SqlConnection connection)
      {
         this.JobId = jobMetaInfo.JobId;

         if (JobId == Guid.Empty)
            throw new ApplicationException(String.Format("Cannot delete job schedule {0} for job {1} because JobId id is empty.", name, JobName));

         AddGuidParam(JobId, paramJobId);
         AddStringParam(name, paramName);

         ExecuteStoredProcNonQuery(connection, spDeleteCommand);
      }

      protected override AgentObjectExistenceType CheckExistenceData(SqlConnection connection)
      {
         this.JobId = jobMetaInfo.JobId;

         if (JobId == Guid.Empty)
            return AgentObjectExistenceType.NotExists;

         // Run help command to see if step with this id exists at all
         AddGuidParam(JobId, paramJobId);
         AddStringParam(name, "schedule_name");

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

               //if (ReadColumn<string>(paramName, row)                   != this.name)                      return AgentObjectExistenceType.ExistsMismatch;
               if ((ReadColumn<int>(paramEnabled, row) == 1) != this.enabled) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: enabled: {0}, {1}", ReadColumn<int>(paramEnabled, row), this.enabled)); return AgentObjectExistenceType.ExistsMismatch; }
               if (ReadColumn<int>(paramFrequencyType, row) != this.frequencytype) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: frequencytype: {0}, {1}", ReadColumn<int>(paramFrequencyType, row), this.frequencytype)); return AgentObjectExistenceType.ExistsMismatch; }
               if (ReadColumn<int>(paramFrequencyInterval, row) != this.frequencyInterval) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: frequencyInterval: {0}, {1}", ReadColumn<int>(paramFrequencyInterval, row), this.frequencyInterval)); return AgentObjectExistenceType.ExistsMismatch; }
               if (ReadColumn<int>(paramFrequencySubdayType, row) != this.frequencySubdayType) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: frequencySubdayType: {0}, {1}", ReadColumn<int>(paramFrequencySubdayType, row), this.frequencySubdayType)); return AgentObjectExistenceType.ExistsMismatch; }
               if (ReadColumn<int>(paramFrequencySubdayInterval, row) != this.frequencySubdayInterval) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: frequencySubdayInterval: {0}, {1}", ReadColumn<int>(paramFrequencySubdayInterval, row), this.frequencySubdayInterval)); return AgentObjectExistenceType.ExistsMismatch; }
               if (ReadColumn<int>(paramFrequencyRelativeInterval, row) != this.frequencyRelativeInterval) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: frequencyRelativeInterval: {0}, {1}", ReadColumn<int>(paramFrequencyRelativeInterval, row), this.frequencyRelativeInterval)); return AgentObjectExistenceType.ExistsMismatch; }
               if (ReadColumn<int>(paramFrequencyRecurrenceFactor, row) != this.frequencyRecurrenceFactor) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: frequencyRecurrenceFactor: {0}, {1}", ReadColumn<int>(paramFrequencyRecurrenceFactor, row), this.frequencyRecurrenceFactor)); return AgentObjectExistenceType.ExistsMismatch; }
               if (ReadColumn<int>(paramActiveStartDate, row) != this.activeStartDate) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: activeStartDate: {0}, {1}", ReadColumn<int>(paramActiveStartDate, row), this.activeStartDate)); return AgentObjectExistenceType.ExistsMismatch; }
               if (ReadColumn<int>(paramActiveEndDate, row) != this.activeEndDate) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: activeEndDate: {0}, {1}", ReadColumn<int>(paramActiveEndDate, row), this.activeEndDate)); return AgentObjectExistenceType.ExistsMismatch; }
               if (ReadColumn<int>(paramActiveStartTime, row) != this.activeStartTime) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: activeStartTime: {0}, {1}", ReadColumn<int>(paramActiveStartTime, row), this.activeStartTime)); return AgentObjectExistenceType.ExistsMismatch; }
               if (ReadColumn<int>(paramActiveEndTime, row) != this.activeEndTime) { logger.Debug(string.Format("JobscheduleInfo.CheckExistence: activeEndTime: {0}, {1}", ReadColumn<int>(paramActiveEndTime, row), this.activeEndTime)); return AgentObjectExistenceType.ExistsMismatch; }
            }
         }
         catch (Exception e)
         {
            if (e is SqlException)
            {
               logger.Error("JobScheduleInfo.CheckExistenceData: Caught exception: " + e.Message);
               return AgentObjectExistenceType.NotExists;
            }
            else
               throw;
         }

         return AgentObjectExistenceType.Exists;
      }

      protected override bool Equals<T>(T info)
      {
         if (info == null || !(info is JobScheduleInfo))
            return false;

         JobScheduleInfo other = info as JobScheduleInfo;

         return this.JobId == other.JobId &&
                this.JobName == other.JobName &&
                this.activeEndDate == other.ActiveEndDate &&
                this.activeEndTime == other.ActiveEndTime &&
                this.activeStartDate == other.ActiveStartDate &&
                this.activeStartTime == other.ActiveStartTime &&
                this.enabled == other.enabled &&
                this.frequencyInterval == other.FrequencyInterval &&
                this.frequencyRecurrenceFactor == other.FrequencyRecurrenceFactor &&
                this.frequencyRelativeInterval == other.FrequencyRelativeInterval &&
                this.frequencySubdayInterval == other.FrequencySubdayInterval &&
                this.frequencySubdayType == other.FrequencySubdayType &&
                this.frequencytype == other.Frequencytype &&
                this.name == other.Name;
      }

      #endregion

      protected void LoadDataRow(DataRow jobData)
      {
         this.name = ReadColumn<string>("schedule_name", jobData);
         this.enabled = ReadColumn<int>(paramEnabled, jobData) == 1;
         this.frequencytype = ReadColumn<int>(paramFrequencyType, jobData);
         this.frequencyInterval = ReadColumn<int>(paramFrequencyInterval, jobData);
         this.frequencySubdayType = ReadColumn<int>(paramFrequencySubdayType, jobData);
         this.frequencySubdayInterval = ReadColumn<int>(paramFrequencySubdayInterval, jobData);
         this.frequencyRelativeInterval = ReadColumn<int>(paramFrequencyRelativeInterval, jobData);
         this.frequencyRecurrenceFactor = ReadColumn<int>(paramFrequencyRecurrenceFactor, jobData);
         this.activeStartDate = ReadColumn<int>(paramActiveStartDate, jobData);
         this.activeEndDate = ReadColumn<int>(paramActiveEndDate, jobData);
         this.activeStartTime = ReadColumn<int>(paramActiveStartTime, jobData);
         this.activeEndTime = ReadColumn<int>(paramActiveEndTime, jobData);
      }
   }
}
