using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.JobMover.DataObjects
{
   public class JobSchedules : JobInfoList<int, JobScheduleInfo>
   {
      public JobSchedules(ServerInformation serverInformation, JobMetaInfo jobMetaInfo)
      {
         this.jobMetaInfo = jobMetaInfo;
         parameters.Add(new SqlParameter(paramJobId, jobMetaInfo.JobId));

         Load(GetItems(serverInformation));
      }

      public JobSchedules(SqlConnection conn, JobMetaInfo jobMetaInfo)
      {
         this.jobMetaInfo = jobMetaInfo;
         parameters.Add(new SqlParameter(paramJobId, jobMetaInfo.JobId));

         Load(GetItems(conn));
      }

      protected override void Initialize()
      {
         jobDataType = JobDataType.JobSchedule;
         spHelpCommand = "sp_help_jobschedule";
      }

      protected void Load(DataTable items)
      {
         foreach (DataRow row in items.Rows)
         {
            JobScheduleInfo item = new JobScheduleInfo(jobMetaInfo, row);
            Add(Count + 1, item);
         }
      }
   }
}
