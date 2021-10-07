using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using BBS.TracerX;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.JobMover.DataObjects
{
   /// <summary>
   /// This is the wrapper class that contains all Job data
   /// </summary>
   public class Job
   {
      protected Logger logger;

      private string            m_originalJobName;
      private JobMetaInfo       m_info;
      private JobSchedules      m_schedules;
      private JobSteps          m_steps;
      private JobStepResults    m_stepResults;
      private ServerInformation m_server;

      public Job(ServerInformation serverInformation, Guid jobId)
      {
         this.logger = CoreGlobals.traceLog;

         m_server = serverInformation;
         GetJob(serverInformation, jobId);
      }

      public Job(ServerInformation serverInformation, SqlConnection conn, Guid jobId)
      {
         this.logger = CoreGlobals.traceLog;

         m_server = serverInformation;
         GetJob(conn, jobId);
      }

      public Guid JobId
      {
         get { return m_info.JobId; }
      }

      public string JobName
      {
         get { return m_info.JobName; }
      }

      public string OriginalJobName
      {
         get { return m_originalJobName.Length > 0 ? m_originalJobName : (m_info != null ? m_info.JobName : string.Empty); }
      }

      public JobMetaInfo MetaInfo
      {
         get { return m_info; }
      }

      public JobSchedules Schedules
      {
         get { return m_schedules; }
      }

      public JobSteps Steps
      {
         get { return m_steps; }
      }

      public JobStepResults StepResults
      {
         get { return m_stepResults; }
      }

      public void SetJobName(string jobName)
      {
         if (m_originalJobName.Length > 0)
         {
            m_originalJobName = jobName;
         }

         // let it throw an exception if the meta info doesn't exist
         m_info.JobName = jobName;
      }

      private void GetJob(ServerInformation serverInformation, Guid jobId)
      {
         SqlConnection conn = null;
         try
         {
            using (conn = Connection.OpenConnection(serverInformation.Name, @"msdb", serverInformation.SqlCredentials))
            {
               GetJob(conn, jobId);
            }
         }
         catch (Exception ex)
         {
            throw new Exception(string.Format("Job.GetJob: {0}", Helpers.GetCombinedExceptionText(ex)));
         }
         finally
         {
            Connection.CloseConnection(conn);
         }
      }

      private void GetJob(SqlConnection conn, Guid jobId)
      {
         try
         {
            m_info            = new JobMetaInfo(conn, jobId);
            m_originalJobName = m_info.JobName;
            m_steps           = new JobSteps(conn, m_info);
            m_stepResults     = new JobStepResults(conn, m_info);
            m_schedules       = new JobSchedules(conn, m_info);
         }
         catch (Exception ex)
         {
            throw new Exception(string.Format("Job.GetJob: {0}", Helpers.GetCombinedExceptionText(ex)));
         }
      }

      /// <summary>
      /// Clear all schedule information from the job
      /// </summary>
      public void ClearSchedules()
      {
         m_schedules.Clear();
      }

      /// <summary>
      /// Clear all alerts and notifications from the job
      /// </summary>
      public void ClearNotifications()
      {
         //m_alerts.Clear();
         m_info.ClearNotifications();
      }

      public AgentObjectExistenceType NameExistsOnServer(SqlConnection conn)
      {
         if (m_info == null)
         {
            return AgentObjectExistenceType.NotExists;
         }

         return m_info.CheckNameExists(conn);
      }

      public AgentObjectExistenceType NameExistsOnServer(SqlConnection conn, SqlTransaction trans)
      {
         if (m_info == null)
         {
            return AgentObjectExistenceType.NotExists;
         }

         return m_info.CheckNameExists(conn, trans);
      }

      /// <summary>
      /// Saves the job to the specified server instance.
      /// </summary>
      public bool Save(ServerInformation serverInformation)
      {
         bool completed = false;

         if (serverInformation == null)
            throw new ApplicationException("Job.Save(): serverInformation cannot be null.");

         SqlConnection conn = null;
         SqlTransaction trans = null;
         try
         {
            using (conn = Connection.OpenConnection(serverInformation.Name, @"msdb", serverInformation.SqlCredentials))
            {
               trans = conn.BeginTransaction();

               m_info.Save(conn, trans);
               m_steps.Save(conn, trans);
               m_stepResults.Save(conn, trans);
               m_schedules.Save(conn, trans);

               trans.Commit();
               completed = true;
            }
         }
         catch (Exception ex)
         {
            logger.Debug("Job.Save(): " + Helpers.GetCombinedExceptionText(ex));
            try
            {
               if (trans != null && trans.Connection != null)
               {
                  trans.Rollback();
               }
            }
            finally
            {
               throw ex;
            }
         }
         finally
         {
            Connection.CloseConnection(conn);
         }

         return completed;
      }

      /// <summary>
      /// Saves the job to the specified connection.
      /// </summary>
      public bool Save(SqlConnection conn)
      {
         return Save(conn, null);
      }

      /// <summary>
      /// Saves the job to the specified connection using the specified transaction. If not transaction is passed, one will be used internally.
      /// </summary>
      public bool Save(SqlConnection conn, SqlTransaction transaction)
      {
         bool completed = false;
         bool internalTrans = (transaction == null);

         if (conn == null)
            throw new ApplicationException("Job.Save(): Connection cannot be null.");

         SqlTransaction trans = null;
         try
         {
            if (internalTrans)
            {
               trans = conn.BeginTransaction();
            }
            else
            {
               trans = transaction;
            }

            m_info.Save(conn, trans);
            m_steps.Save(conn, trans);
            m_stepResults.Save(conn, trans);
            m_schedules.Save(conn, trans);

            if (internalTrans)
            {
               trans.Commit();
            }
            else
            {
               trans.Save("Save Job " + JobName.Substring(0, Math.Min(JobName.Length,20)));
            }
            completed = true;
         }
         catch (Exception ex)
         {
            logger.Debug("Job.Save(): " + Helpers.GetCombinedExceptionText(ex));
            try
            {
               if (trans != null && trans.Connection != null)
               {
                  trans.Rollback();
               }
            }
            finally
            {
               throw ex;
            }
         }

         return completed;
      }

      /// <summary>
      /// Delete the job on the specified server instance.
      /// </summary>
      public bool Delete(ServerInformation serverInformation)
      {
         bool completed = false;

         if (serverInformation == null)
            throw new ApplicationException("Job.Delete(): serverInformation cannot be null.");

         SqlConnection conn = null;
         try
         {
            using (conn = Connection.OpenConnection(m_server.Name, @"msdb", m_server.SqlCredentials))
            {
               completed = Delete(conn);
            }
         }
         catch (Exception ex)
         {
            logger.Debug("JobInfo.Delete: " + Helpers.GetCombinedExceptionText(ex));
            throw ex;
         }
         finally
         {
            Connection.CloseConnection(conn);
         }

         return completed;
      }

      /// <summary>
      /// Delete the job on the specified connection.
      /// </summary>
      public bool Delete(SqlConnection conn)
      {
         return Delete(conn, null);
      }

      /// <summary>
      /// Delete the job on the specified connection using the specified transaction.
      /// </summary>
      public bool Delete(SqlConnection conn, SqlTransaction transaction)
      {
         bool completed = false;

         if (conn == null)
            throw new ApplicationException("Job.Delete(): Connection cannot be null.");

         try
         {
            m_info.Delete(conn, transaction);

            completed = true;
         }
         catch (Exception ex)
         {
            logger.Debug("JobInfo.Delete: " + Helpers.GetCombinedExceptionText(ex));
            throw ex;
         }

         return completed;
      }

      public override string ToString()
      {
         if (m_info != null)
         {
            return m_info.JobName;
         }

         return @"Unknown Job";
      }
   }
}
