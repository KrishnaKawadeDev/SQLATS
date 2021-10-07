using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.JobMover.DataObjects
{
   public class JobStepResults : JobInfoList<int, JobStepResultInfo>
   {
      public JobStepResults(ServerInformation serverInformation, JobMetaInfo jobMetaInfo)
      {
         this.jobMetaInfo = jobMetaInfo;
         parameters.Add(new SqlParameter(paramJobId, jobMetaInfo.JobId));

         Load(GetItems(serverInformation));
      }

      public JobStepResults(SqlConnection conn, JobMetaInfo jobMetaInfo)
      {
         this.jobMetaInfo = jobMetaInfo;
         parameters.Add(new SqlParameter(paramJobId, jobMetaInfo.JobId));

         Load(GetItems(conn));
      }

      protected override void Initialize()
      {
         jobDataType = JobDataType.JobStepResult;
         spHelpCommand = "sp_help_jobstep";
      }

      protected void Load(DataTable items)
      {
         foreach (DataRow row in items.Rows)
         {
            JobStepResultInfo item = new JobStepResultInfo(jobMetaInfo, row);
            Add((int)row["step_id"], item);
         }
      }
   }
}
