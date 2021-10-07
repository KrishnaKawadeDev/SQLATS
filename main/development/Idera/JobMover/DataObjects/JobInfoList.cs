using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using BBS.TracerX;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.JobMover.DataObjects
{
   public abstract class JobInfoList<TKey, TValue> : Dictionary<TKey, DataObjects.JobInfo>
   {
      protected string spHelpCommand;
      protected JobDataType jobDataType;
      protected List<SqlParameter> parameters;

      protected const string paramJobId = "job_id";

      protected SqlTransaction transaction = null;

      protected JobMetaInfo jobMetaInfo;

      protected Logger logger;

      public JobInfoList()
      {
         this.parameters = new List<SqlParameter>();
         this.logger = CoreGlobals.traceLog;
 
         Initialize();
      }

      protected abstract void Initialize();

      protected DataTable GetItems(ServerInformation serverInformation)
      {
         string msgHdr = string.Format(ProductConstants.messageListHeaderFormat, jobDataType.ToString(), "GetItems");
         if (serverInformation == null)
            throw new ApplicationException(string.Format(ProductConstants.messageFormat, msgHdr, ProductConstants.messageServerNull));
         if (jobMetaInfo == null)
            throw new ApplicationException(string.Format(ProductConstants.messageFormat, msgHdr, ProductConstants.messageJobMetaNull));
         msgHdr = string.Format(ProductConstants.messageJobListHeaderFormat, jobDataType.ToString(), "GetItems", jobMetaInfo.JobName);

         DataTable resultTable = new DataTable();

         try
         {
            using (SqlConnection conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials))
            {
               resultTable = GetItems(conn);
            }
         }
         catch (Exception ex)
         {
            logger.Debug(msgHdr, Helpers.GetCombinedExceptionText(ex));
            throw new ApplicationException(msgHdr, ex);
         }

         return resultTable;
      }

      protected DataTable GetItems(SqlConnection conn)
      {
         string msgHdr = string.Format(ProductConstants.messageListHeaderFormat, jobDataType.ToString(), "GetItems");
         if (conn == null || conn.State != ConnectionState.Open)
            throw new ApplicationException(string.Format(ProductConstants.messageFormat, msgHdr, ProductConstants.messageConnNotOpen));
         if (jobMetaInfo == null)
            throw new ApplicationException(string.Format(ProductConstants.messageFormat, msgHdr, ProductConstants.messageJobMetaNull));
         msgHdr = string.Format(ProductConstants.messageJobListHeaderFormat, jobDataType.ToString(), "GetItems", jobMetaInfo.JobName);

         DataTable resultTable = new DataTable();
         int i = 0;

         try
         {
            Clear();
            using (SqlCommand command = new SqlCommand(spHelpCommand, conn))
            {
               if (transaction != null)
               {
                  command.Transaction = transaction;
               }
               command.CommandType = CommandType.StoredProcedure;
               command.CommandTimeout = ToolsetOptions.commandTimeout;

               // Add the parameters for the command
               command.Parameters.AddRange(parameters.ToArray());

               using (SqlDataReader reader = command.ExecuteReader())
               {
                  if (!reader.HasRows)
                  {
                     command.Parameters.Clear();
                     return resultTable;
                  }

                  // Add the columns
                  for (i = 0; i < reader.FieldCount; i++)
                  {
                     DataColumn col = new DataColumn(reader.GetName(i), reader.GetFieldType(i));

                     if (!resultTable.Columns.Contains(col.ColumnName))
                     {
                        resultTable.Columns.Add(col);
                     }
                  }

                  // Populate the table
                  foreach (System.Data.Common.DbDataRecord row in reader)
                  {
                     object[] values = new object[row.FieldCount];
                     row.GetValues(values);

                     resultTable.Rows.Add(values);
                  }

                  command.Parameters.Clear();
               }
            }
         }
         catch (Exception ex)
         {
            logger.Debug(msgHdr, Helpers.GetCombinedExceptionText(ex));
            throw new ApplicationException(msgHdr, ex);
         }

         return resultTable;
      }

      /// <summary>
      /// Saves the job items to the specified server instance within a transaction.
      /// </summary>
      public void Save(SqlConnection conn, SqlTransaction trans)
      {
         transaction = trans;

         Save(conn);

         transaction = null;
      }

      /// <summary>
      /// Saves the job items to the specified server instance.
      /// </summary>
      public void Save(SqlConnection conn)
      {
         string msgHdr = string.Format(ProductConstants.messageListHeaderFormat, jobDataType.ToString(), "Save");
         if (conn == null || conn.State != ConnectionState.Open)
            throw new ApplicationException(string.Format(ProductConstants.messageFormat, msgHdr, ProductConstants.messageConnNotOpen));
         if (jobMetaInfo == null)
            throw new ApplicationException(string.Format(ProductConstants.messageFormat, msgHdr, ProductConstants.messageJobMetaNull));

         int item = 0;

         try
         {
            foreach (JobInfo jobInfo in Values)
            {
               item++;
               jobInfo.Save(conn, transaction);
            }
         }
         catch (Exception ex)
         {
            logger.Debug(string.Format(ProductConstants.messageListItemFormat, msgHdr, item, jobMetaInfo.JobName), Helpers.GetCombinedExceptionText(ex));
            throw new ApplicationException(string.Format(ProductConstants.messageListItemFormat, msgHdr, item, jobMetaInfo.JobName), ex);
         }
      }

      /// <summary>
      /// Delete the job on the specified server instance within a transaction.
      /// </summary>
      public void Delete(SqlConnection conn, SqlTransaction trans)
      {
         transaction = trans;

         Delete(conn);

         transaction = null;
      }

      /// <summary>
      /// Delete the job on the specified server instance.
      /// </summary>
      public void Delete(SqlConnection conn)
      {
         string msgHdr = string.Format(ProductConstants.messageListHeaderFormat, jobDataType.ToString(), "Delete");
         if (conn == null || conn.State != ConnectionState.Open)
            throw new ApplicationException(string.Format(ProductConstants.messageFormat, msgHdr, ProductConstants.messageConnNotOpen));
         if (jobMetaInfo == null)
            throw new ApplicationException(string.Format(ProductConstants.messageFormat, msgHdr, ProductConstants.messageJobMetaNull));

         int item = 0;

         try
         {
            foreach (JobInfo jobInfo in Values)
            {
               item++;
               jobInfo.Delete(conn, transaction);
            }
         }
         catch (Exception ex)
         {
            logger.Debug(string.Format(ProductConstants.messageListItemFormat, msgHdr, item, jobMetaInfo.JobName), Helpers.GetCombinedExceptionText(ex));
            throw new ApplicationException(string.Format(ProductConstants.messageListItemFormat, msgHdr, item, jobMetaInfo.JobName), ex);
         }
      }
   }
}
