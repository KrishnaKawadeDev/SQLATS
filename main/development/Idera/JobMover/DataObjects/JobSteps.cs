using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.JobMover.DataObjects
{
    public class JobSteps : JobInfoList<int, JobStepInfo>
    {
        public static string ServerName;
        public JobSteps(ServerInformation serverInformation, JobMetaInfo jobMetaInfo)
        {
            this.jobMetaInfo = jobMetaInfo;
            parameters.Add(new SqlParameter(paramJobId, jobMetaInfo.JobId));

            Load(GetItems(serverInformation));
        }

        public JobSteps(SqlConnection conn, JobMetaInfo jobMetaInfo)
        {
            this.jobMetaInfo = jobMetaInfo;
            parameters.Add(new SqlParameter(paramJobId, jobMetaInfo.JobId));

            Load(GetItems(conn));
        }

        protected override void Initialize()
        {
            jobDataType = JobDataType.JobStep;
            spHelpCommand = "sp_help_jobstep";
        }

        protected void Load(DataTable items)
        {
            StringBuilder stringbuilder = new StringBuilder();
            foreach (DataRow row in items.Rows)
            {
                JobStepInfo item = new JobStepInfo(jobMetaInfo, row);
                if (item.Command != null)
                {
                    var command = item.Command.Split(' ');
                    if (item.Command.Contains("File System"))
                    {
                        for (int i = 0; i < command.Length; i++)
                        {
                            if (command[i].Contains("SERVER"))
                            {
                                stringbuilder.Append(" /SERVER " + "\"\\\"" + ServerName + "\\\"\"");
                                i++;
                            }
                            else
                            {
                                stringbuilder.Append(" " + command[i]);
                            }
                        }
                        item.Command = stringbuilder.ToString();
                    }
                    else if (command[0].Contains("SERVER") && !item.Command.Contains("ISSERVER"))
                    {
                        for (int i = 0; i < command.Length; i++)
                        {
                            if (command[i].Contains("SERVER"))
                            {
                                stringbuilder.Append("/SERVER " + ServerName + "");
                            }
                            else
                            {
                                if (i == command.Length - 1)
                                {
                                }
                                else
                                {
                                    stringbuilder.Append(" " + command[i + 1]);
                                }
                            }
                        }
                        item.Command = stringbuilder.ToString();
                    }
                }
                Add((int)row["step_id"], item);
            }
        }
    }
}
