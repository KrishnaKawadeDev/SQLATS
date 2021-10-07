using System;
using System.Data;
using System.Data.SqlClient;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.JobMover.DataObjects
{
   public class Operator : AgentObject
   {
      public Operator(int operatorId)
      {
         this.operatorId = operatorId;

         this.enabled = true;

         this.weekdayPagerStartTime = 0;
         this.weekdayPagerEndTime = 0;
         this.saturdayPagerStartTime = 0;
         this.saturdayPagerEndTime = 0;
         this.sundayPagerStartTime = 0;
         this.sundayPagerEndTime = 0;
         this.pagerDays = 0;
      }

      public Operator(SqlConnection conn, int operatorId)
      {
         this.operatorId = operatorId;

         LoadData(conn);
      }

      #region Properties

      #region Parameter names

      private const string paramOperatorNameOut = "name";
      private const string paramOperatorIdOut = "id";

      private const string paramOperatorId = "operator_id";
      private const string paramOperatorName = "operator_name";
      private const string paramEnabled = "enabled";
      private const string paramEmailAddress = "email_address";
      private const string paramPagerAddress = "pager_address";
      private const string paramWeekdayPagerStartTime = "weekday_pager_start_time";
      private const string paramWeekdayPagerEndTime = "weekday_pager_end_time";
      private const string paramSaturdayPagerStartTime = "saturday_pager_start_time";
      private const string paramSaturdayPagerEndTime = "saturday_pager_end_time";
      private const string paramSundayPagerStartTime = "sunday_pager_start_time";
      private const string paramSundayPagerEndTime = "sunday_pager_end_time";
      private const string paramPagerDays = "pager_days";
      private const string paramNetSendAddress = "netsend_address";
      private const string paramCategoryName = "category_name";

      #endregion

      private string operatorName;
      /// <summary>
      /// Gets/sets the operator name.
      /// </summary>
      public string OperatorName
      {
         get { return operatorName; }
         set { operatorName = value; EnforceLength(ref operatorName, 128); }
      }

      private int operatorId;
      /// <summary>
      /// Gets/sets the operator id.
      /// </summary>
      public int OperatorId
      {
         get { return operatorId; }
         set { operatorId = value; }
      }

      private bool enabled;
      /// <summary>
      /// Gets/sets whether the operator is enabled.
      /// </summary>
      public bool Enabled
      {
         get { return enabled; }
         set { enabled = value; }
      }

      private string emailAddress;
      /// <summary>
      /// Gets/sets the email address.
      /// </summary>
      public string EmailAddress
      {
         get { return emailAddress; }
         set { emailAddress = value; EnforceLength(ref emailAddress, 100); }
      }

      private string pagerAddress;
      /// <summary>
      /// Gets/sets the pager address.
      /// </summary>
      public string PagerAddress
      {
         get { return pagerAddress; }
         set { pagerAddress = value; EnforceLength(ref pagerAddress, 100); }
      }

      private int weekdayPagerStartTime;
      /// <summary>
      /// Gets/sets the weekday pager start time.
      /// </summary>
      public int WeekdayPagerStartTime
      {
         get { return weekdayPagerStartTime; }
         set { weekdayPagerStartTime = value; }
      }

      private int weekdayPagerEndTime;
      /// <summary>
      /// Gets/sets the weekday pager end time.
      /// </summary>
      public int WeekdayPagerEndTime
      {
         get { return weekdayPagerEndTime; }
         set { weekdayPagerEndTime = value; }
      }

      private int saturdayPagerStartTime;
      /// <summary>
      /// Gets/sets the saturday pager start time.
      /// </summary>
      public int SaturdayPagerStartTime
      {
         get { return saturdayPagerStartTime; }
         set { saturdayPagerStartTime = value; }
      }

      private int saturdayPagerEndTime;
      /// <summary>
      /// Gets/sets the saturday pager end time.
      /// </summary>
      public int SaturdayPagerEndTime
      {
         get { return saturdayPagerEndTime; }
         set { saturdayPagerEndTime = value; }
      }

      private int sundayPagerStartTime;
      /// <summary>
      /// Gets/sets the sunday pager start time.
      /// </summary>
      public int SundayPagerStartTime
      {
         get { return sundayPagerStartTime; }
         set { sundayPagerStartTime = value; }
      }

      private int sundayPagerEndTime;
      /// <summary>
      /// Gets/sets the sunday pager end time.
      /// </summary>
      public int SundayPagerEndTime
      {
         get { return sundayPagerEndTime; }
         set { sundayPagerEndTime = value; }
      }

      private byte pagerDays;
      /// <summary>
      /// Gets/sets the pager days.
      /// </summary>
      public byte PagerDays
      {
         get { return pagerDays; }
         set { pagerDays = value; }
      }

      private string netSendAddress;
      /// <summary>
      /// Gets/sets the netsend address.
      /// </summary>
      public string NetSendAddress
      {
         get { return netSendAddress; }
         set { netSendAddress = value; EnforceLength(ref netSendAddress, 100); }
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

      #endregion

      #region Overrides

      protected override void Initialize()
      {
         agentObjectType = AgentObjectType.Operator;
         spHelpCommand = "sp_help_operator";
         spAddCommand = "sp_add_operator";
         spUpdateCommand = "sp_update_operator";
         spDeleteCommand = "sp_delete_operator";
      }

      protected override void SaveData(SqlConnection connection)
      {
         // Add the parameters for the command
         AddStringParam(OperatorName, paramOperatorNameOut);
         AddBooleanParam(enabled, paramEnabled);
         AddStringParam(emailAddress, paramEmailAddress);
         AddStringParam(pagerAddress, paramPagerAddress);
         AddIntParam(weekdayPagerStartTime, paramWeekdayPagerStartTime);
         AddIntParam(weekdayPagerEndTime, paramWeekdayPagerEndTime);
         AddIntParam(saturdayPagerStartTime, paramSaturdayPagerStartTime);
         AddIntParam(saturdayPagerEndTime, paramSaturdayPagerEndTime);
         AddIntParam(sundayPagerStartTime, paramSundayPagerStartTime);
         AddIntParam(sundayPagerEndTime, paramSundayPagerEndTime);
         AddByteParam(pagerDays, paramPagerDays);
         AddStringParam(netSendAddress, paramNetSendAddress);
         AddStringParam(categoryName, paramCategoryName);

         // Add as last parameter, since this is output
         //AddIntParam(operatorId, paramOperatorIdOut, ParameterDirection.Output);

         ExecuteStoredProcNonQuery(connection, spAddCommand);
      }

      protected override void UpdateData(SqlConnection connection)
      {
         if (OperatorId == 0)
            throw new ApplicationException(String.Format("Cannot load operator {0} because operator id is empty.", OperatorName));

         // Add the parameters for the command
         AddIntParam(OperatorId, paramOperatorId);

         AddBooleanParam(enabled, paramEnabled);
         AddStringParam(emailAddress, paramEmailAddress);
         AddStringParam(pagerAddress, paramPagerAddress);
         AddIntParam(weekdayPagerStartTime, paramWeekdayPagerStartTime);
         AddIntParam(weekdayPagerEndTime, paramWeekdayPagerEndTime);
         AddIntParam(saturdayPagerStartTime, paramSaturdayPagerStartTime);
         AddIntParam(saturdayPagerEndTime, paramSaturdayPagerEndTime);
         AddIntParam(sundayPagerStartTime, paramSundayPagerStartTime);
         AddIntParam(sundayPagerEndTime, paramSundayPagerEndTime);
         AddByteParam(pagerDays, paramPagerDays);
         AddStringParam(netSendAddress, paramNetSendAddress);
         AddStringParam(categoryName, paramCategoryName);

         // Execute the udpate
         ExecuteStoredProcNonQuery(connection, spUpdateCommand);
      }

      protected override void LoadData(SqlConnection connection)
      {
         if (OperatorId == 0)
            throw new ApplicationException(String.Format("Cannot load operator {0} because operator id is empty.", OperatorName));

         // Add the parameters for the command
         AddIntParam(OperatorId, paramOperatorId);

         using (DataTable table = ExecuteStoredProc(connection, spHelpCommand))
         {
            if (table == null || table.Rows.Count == 0)
               throw new ApplicationException("Unable to load operator " + OperatorName);

            LoadDataRow(table.Rows[0]);
         }
      }

      protected override void DeleteData(SqlConnection connection)
      {
         if (OperatorId == 0)
            throw new ApplicationException(String.Format("Cannot delete operator {0} because operator id is empty.", OperatorName));

         // Add the parameters for the command
         AddIntParam(OperatorId, paramOperatorId);

         ExecuteStoredProcNonQuery(connection, spDeleteCommand);
      }

      protected override AgentObjectExistenceType CheckExistenceData(SqlConnection connection)
      {
         // If we have an id, then we search by ID for the operator.  If we don't have an ID, then we search by name.  
         // If we search by name and find an operator already there, check if data is the same

         if (OperatorId != 0)
         {
            AddIntParam(OperatorId, paramOperatorId);

            AgentObjectExistenceType existence = CheckExistenceWithParamAlreadySpecified(connection, false);

            // If the operator id does not return a value, then we will have to continue and search by name
            // If the id returns a match of any kind, then we found our operator.
            if (existence != AgentObjectExistenceType.NotExists)
               return existence;

            parameters.Clear();
         }

         // We go here, so now we search by name
         AddStringParam(OperatorName, paramOperatorName);

         return CheckExistenceWithParamAlreadySpecified(connection, true);
      }

      public AgentObjectExistenceType CheckNameExists(SqlConnection connection, SqlTransaction trans)
      {
         transaction = trans;

         parameters.Clear();
         AddStringParam(OperatorName, paramOperatorName);

         AgentObjectExistenceType AgentObjectExistenceType = CheckExistenceWithParamAlreadySpecified(connection, true);

         transaction = null;

         return AgentObjectExistenceType;
      }

      public AgentObjectExistenceType CheckNameExists(SqlConnection connection)
      {
         AddStringParam(OperatorName, paramOperatorName);

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
                  // Get the id of the pre-existing operator
                  this.OperatorId = ReadColumn<int>(paramOperatorId, row);
               }

               // It exists, so load all its parameters and compare.  If any don't match, then something's different...

               // Get the operator ID if we don't have it
               if (OperatorId == 0)
                  this.OperatorId = ReadColumn<int>(paramOperatorId, row);

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
               logger.Debug("Operator.CheckExistenceData: Caught exception: " + e.Message);
               return AgentObjectExistenceType.NotExists;
            }
            else
               throw;
         }

         return AgentObjectExistenceType.Exists;
      }

      protected override bool Equals<T>(T info)
      {
         if (info == null || !(info is Operator))
            return false;

         Operator other = info as Operator;

         return this.operatorId == other.OperatorId &&
                this.operatorName == other.OperatorName &&
                this.enabled == other.Enabled &&
                this.emailAddress == other.EmailAddress &&
                this.pagerAddress == other.PagerAddress &&
                this.weekdayPagerStartTime == other.WeekdayPagerStartTime &&
                this.weekdayPagerEndTime == other.WeekdayPagerEndTime &&
                this.saturdayPagerStartTime == other.SaturdayPagerStartTime &&
                this.saturdayPagerEndTime == other.SaturdayPagerEndTime &&
                this.sundayPagerStartTime == other.SundayPagerStartTime &&
                this.sundayPagerEndTime == other.SundayPagerEndTime &&
                this.pagerDays == other.PagerDays &&
                this.netSendAddress == other.NetSendAddress &&
                this.categoryName == other.CategoryName;
      }

      #endregion

      protected void LoadDataRow(DataRow jobData)
      {
         this.operatorName = ReadColumn<string>(paramOperatorNameOut, jobData);
         this.enabled = ReadColumn<byte>(paramEnabled, jobData) == 1;
         this.emailAddress = ReadColumn<string>(paramEmailAddress, jobData);
         this.pagerAddress = ReadColumn<string>(paramPagerAddress, jobData);
         this.weekdayPagerStartTime = ReadColumn<int>(paramWeekdayPagerStartTime, jobData);
         this.weekdayPagerEndTime = ReadColumn<int>(paramWeekdayPagerEndTime, jobData);
         this.saturdayPagerStartTime = ReadColumn<int>(paramSaturdayPagerStartTime, jobData);
         this.saturdayPagerEndTime = ReadColumn<int>(paramSaturdayPagerEndTime, jobData);
         this.sundayPagerStartTime = ReadColumn<int>(paramSundayPagerStartTime, jobData);
         this.sundayPagerEndTime = ReadColumn<int>(paramSundayPagerEndTime, jobData);
         this.pagerDays = ReadColumn<byte>(paramPagerDays, jobData);
         this.netSendAddress = ReadColumn<string>(paramNetSendAddress, jobData);
         this.categoryName = ReadColumn<string>(paramCategoryName, jobData);
      }
   }
}
