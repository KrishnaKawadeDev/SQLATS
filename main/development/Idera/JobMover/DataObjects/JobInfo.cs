using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using BBS.TracerX;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.JobMover.DataObjects
{
   public enum JobDataType
   {
      JobMeta,        // The meta data portion of a job
      JobStep,        // The job step portion of a job
      JobStepResult,  // The job step result portion of a job
      JobSchedule     // The schedule portion of a job
   }

   public abstract class JobInfo : AgentObject
   {
      //public JobInfo()
      //{
      //}

      #region Properties
      protected JobDataType jobDataType;

      protected const string paramJobName = "job_name";
      protected const string paramJobId = "job_id";

      private string jobName;
      /// <summary>
      /// Gets/sets the job name.
      /// </summary>
      public string JobName
      {
         get { return jobName; }
         set { jobName = value; EnforceLength(ref jobName, 128); }
      }

      private Guid jobId;
      /// <summary>
      /// Gets/sets the job id.
      /// </summary>
      public Guid JobId
      {
         get { return jobId; }
         set { jobId = value; }
      }

      /// <summary>
      /// Gets the job data type of this job info object (i.e., which part of the job this object represents).
      /// </summary>
      public JobDataType JobDataType
      {
         get { return jobDataType; }
      }

      public string JobDataTypeString
      {
         get
         {
            switch (jobDataType)
            {
               case JobDataType.JobMeta:

                  return "Definition";

               case JobDataType.JobStep:

                  return "Step definition";

               case JobDataType.JobStepResult:

                  return "Step result definition";

               case JobDataType.JobSchedule:

                  return "Schedule definition";

               default:

                  return String.Empty;
            }
         }
      }

      #endregion

      #region Public methods


      #endregion

      #region Private methods


      #endregion

      #region Protected abstract methods

      #endregion
   }
}