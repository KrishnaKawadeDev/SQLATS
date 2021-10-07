using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using BBS.TracerX;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.JobMover.DataObjects
{
   public enum AgentObjectType
   {
      Job,        // The object contains a portion of a job
      Operator,   // The operator for a job notification
   }

   public enum AgentObjectExistenceType
   {
      Exists,           // The data exists and matches current data
      ExistsMismatch,   // The data exists, but does not match current data
      NotExists         // The data does not exist
   }

   public abstract class AgentObject
   {
      public AgentObject()
      {
         this.parameters = new List<SqlParameter>();
         this.existenceType = AgentObjectExistenceType.Exists;
         this.logger = CoreGlobals.traceLog;

         Initialize();
      }

      #region Properties

      protected string spHelpCommand;
      protected string spDeleteCommand;
      protected string spAddCommand;
      protected string spUpdateCommand;
      protected AgentObjectType agentObjectType;
      protected List<SqlParameter> parameters;

      protected SqlTransaction transaction = null;

      protected Logger logger;

      private AgentObjectExistenceType existenceType;
      /// <summary>
      /// Gets the existence type.  Make sure to call CheckExistence before getting this value to ensure it is up to date.
      /// </summary>
      public AgentObjectExistenceType ExistenceType
      {
         get { return existenceType; }
         set { existenceType = value; }
      }

      /// <summary>
      /// Gets the existence as a readable string.
      /// </summary>
      public string ExistenceTypeString
      {
         get
         {
            switch (existenceType)
            {
               case AgentObjectExistenceType.Exists:

                  return "Exists";

               case AgentObjectExistenceType.ExistsMismatch:

                  return "Does not match";

               case AgentObjectExistenceType.NotExists:

                  return "Does not exist";

               default:
                  return String.Empty;
            }
         }
      }

      private int objectId;
      /// <summary>
      /// Gets/sets the job id.
      /// </summary>
      public int ObjectId
      {
         get { return objectId; }
         set { objectId = value; }
      }

      /// <summary>
      /// Gets the job data type of this job info object (i.e., which part of the job this object represents).
      /// </summary>
      public AgentObjectType AgentObjectType
      {
         get { return agentObjectType; }
      }

      public string AgentObjectTypeString
      {
         get
         {
            switch (agentObjectType)
            {
               case AgentObjectType.Job:

                  return "Job definition";

               case AgentObjectType.Operator:

                  return "Notification operator definition";

               default:

                  return String.Empty;
            }
         }
      }

      #endregion

      #region Public methods

      /// <summary>
      /// Saves the job info to the specified server instance within the specified transaction.
      /// </summary>
      public void Save(SqlConnection conn, SqlTransaction trans)
      {
         transaction = trans;

         Save(conn);

         transaction = null;
      }

      /// <summary>
      /// Saves the job info to the specified server instance.
      /// </summary>
      public void Save(SqlConnection conn)
      {
         string msgHdr = string.Format(ProductConstants.messageHeaderFormat, agentObjectType.ToString(), "Save");
         if (conn == null || conn.State != ConnectionState.Open)
            throw new ApplicationException(string.Format(ProductConstants.messageFormat, msgHdr, ProductConstants.messageConnNotOpen));

         try
         {
            parameters.Clear();

            SaveData(conn);
         }
         catch (SqlException ex)
         {
            logger.Debug(string.Format(ProductConstants.messageSqlFormat, msgHdr, spAddCommand), Helpers.GetCombinedExceptionText(ex));
            throw new ApplicationException(string.Format(ProductConstants.messageSqlFormat, msgHdr, spAddCommand), ex);
         }
         catch (Exception ex)
         {
            logger.Debug(msgHdr, Helpers.GetCombinedExceptionText(ex));
            throw new ApplicationException(msgHdr, ex);
         }
      }

      /// <summary>
      /// Updates the job info to the specified instance.
      /// </summary>
      public void Update(ServerInformation serverInformation, int commandTimeout)
      {
         string msgHdr = string.Format(ProductConstants.messageHeaderFormat, agentObjectType.ToString(), "Update");
         if (serverInformation == null)
            throw new ApplicationException(string.Format(ProductConstants.messageFormat, msgHdr, ProductConstants.messageServerNull));

         try
         {
            using (SqlConnection conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials))
            {
               parameters.Clear();

               UpdateData(conn);
            }
         }
         catch (SqlException ex)
         {
            logger.Debug(string.Format(ProductConstants.messageSqlFormat, msgHdr, spUpdateCommand), Helpers.GetCombinedExceptionText(ex));
            throw new ApplicationException(string.Format(ProductConstants.messageSqlFormat, msgHdr, spUpdateCommand), ex);
         }
         catch (Exception ex)
         {
            logger.Debug(msgHdr, Helpers.GetCombinedExceptionText(ex));
            throw new ApplicationException(msgHdr, ex);
         }
      }

      /// <summary>
      /// Loads the job info from the specified instance.  Requires the job id to be set.
      /// </summary>
      public void Load(ServerInformation serverInformation, int commandTimeout)
      {
         string msgHdr = string.Format(ProductConstants.messageHeaderFormat, agentObjectType.ToString(), "Load");
         if (serverInformation == null)
            throw new ApplicationException(string.Format(ProductConstants.messageFormat, msgHdr, ProductConstants.messageServerNull));

         try
         {
            using (SqlConnection conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials))
            {
               parameters.Clear();

               LoadData(conn);
            }
         }
         catch (SqlException ex)
         {
            logger.Debug(string.Format(ProductConstants.messageSqlFormat, msgHdr, spHelpCommand), Helpers.GetCombinedExceptionText(ex));
            throw new ApplicationException(string.Format(ProductConstants.messageSqlFormat, msgHdr, spHelpCommand), ex);
         }
         catch (Exception ex)
         {
            logger.Debug(msgHdr, Helpers.GetCombinedExceptionText(ex));
            throw new ApplicationException(msgHdr, ex);
         }
      }

      /// <summary>
      /// Deletes the job info from the specified instance within the specified transaction. Requires the job id to be set.
      /// </summary>
      public void Delete(SqlConnection conn, SqlTransaction trans)
      {
         transaction = trans;

         Delete(conn);

         transaction = null;
      }

      /// <summary>
      /// Deletes the job info to the specified server instance. Requires the job id to be set.
      /// </summary>
      public void Delete(SqlConnection conn)
      {
         string msgHdr = string.Format(ProductConstants.messageHeaderFormat, agentObjectType.ToString(), "Delete");
         if (conn == null || conn.State != ConnectionState.Open)
            throw new ApplicationException(string.Format(ProductConstants.messageFormat, msgHdr, ProductConstants.messageConnNotOpen));

         try
         {
            parameters.Clear();

            DeleteData(conn);
         }
         catch (SqlException ex)
         {
            logger.Debug(string.Format(ProductConstants.messageSqlFormat, msgHdr, spDeleteCommand), Helpers.GetCombinedExceptionText(ex));
            throw new ApplicationException(string.Format(ProductConstants.messageSqlFormat, msgHdr, spDeleteCommand), ex);
         }
         catch (Exception ex)
         {
            logger.Debug(msgHdr, Helpers.GetCombinedExceptionText(ex));
            throw new ApplicationException(msgHdr, ex);
         }
      }

      /// <summary>
      /// Returns the existence of the job info data on the target instance (if it is already there and matches existing data or not, etc).  
      /// </summary>
      /// <returns></returns>
      public AgentObjectExistenceType CheckExistence(ServerInformation serverInformation, int commandTimeout)
      {
         string msgHdr = string.Format(ProductConstants.messageHeaderFormat, agentObjectType.ToString(), "CheckExistence");
         if (serverInformation == null)
            throw new ApplicationException(string.Format(ProductConstants.messageFormat, msgHdr, ProductConstants.messageServerNull));

         try
         {
            using (SqlConnection conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials))
            {
               parameters.Clear();

               existenceType = CheckExistenceData(conn);

               return existenceType;
            }
         }
         catch (Exception ex)
         {
            logger.Debug(msgHdr, Helpers.GetCombinedExceptionText(ex));
            return AgentObjectExistenceType.Exists;
         }
      }

      #endregion

      #region Private methods


      #endregion

      #region Protected abstract methods

      protected abstract void Initialize();
      protected abstract void SaveData(SqlConnection connection);
      protected abstract void UpdateData(SqlConnection connection);
      protected abstract void LoadData(SqlConnection connection);
      protected abstract void DeleteData(SqlConnection connection);
      protected abstract AgentObjectExistenceType CheckExistenceData(SqlConnection connection);
      protected abstract bool Equals<T>(T info) where T : JobInfo;

      #endregion

      #region Protected methods

      protected DataTable ExecuteStoredProc(SqlConnection conn, string procName)
      {
         DataTable resultTable = new DataTable();

         using (SqlCommand command = new SqlCommand())
         {
            command.Connection = conn;
            if (transaction != null)
            {
               command.Transaction = transaction;
            }
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            command.CommandTimeout = ToolsetOptions.commandTimeout;

            if (parameters != null)
            {
               command.Parameters.AddRange(parameters.ToArray());
            }

            using (SqlDataReader reader = command.ExecuteReader())
            {
               if (!reader.HasRows)
               {
                  command.Parameters.Clear();
                  return null;
               }

               // Add the columns
               for (int i = 0; i < reader.FieldCount; i++)
               {
                  DataColumn c = new DataColumn(reader.GetName(i), reader.GetFieldType(i));

                  if (!resultTable.Columns.Contains(c.ColumnName))
                  {
                     resultTable.Columns.Add(c);
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

         if (resultTable == null || resultTable.Rows.Count == 0)
         {
            return null;
         }

         return resultTable;
      }

      protected void ExecuteStoredProcNonQuery(SqlConnection conn, string procName)
        {
            using (SqlCommand command = new SqlCommand())
         {
            command.Connection = conn;
            if (transaction != null)
            {
               command.Transaction = transaction;
            }
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            command.CommandTimeout = ToolsetOptions.commandTimeout;

            if (parameters != null)
            {
               command.Parameters.AddRange(parameters.ToArray());
            }

            command.ExecuteNonQuery();
            command.Parameters.Clear();
         }
      }

      protected static T ReadColumn<T>(string colName, DataRow row)
      {
         if (row == null || row[colName] == null || row[colName] is System.DBNull)
            return default(T);

         return (T)row[colName];
      }

      protected void AddStringParam(string param, string paramName)
      {
         if (String.IsNullOrEmpty(param))
            return;

         AddParam(param, paramName, DbType.String, ParameterDirection.Input);
      }

      protected void AddByteParam(int param, string paramName)
      {
         if (param < 0)
            return;

         AddParam(param, paramName, DbType.Byte, ParameterDirection.Input);
      }

      protected void AddIntParam(int param, string paramName)
      {
         AddIntParam(param, paramName, ParameterDirection.Input);
      }

      protected void AddIntParam(int param, string paramName, ParameterDirection direction)
      {
         if (param < 0)
            return;

         AddParam(param, paramName, DbType.Int32, direction);
      }

      protected void AddGuidParam(Guid param, string paramName)
      {
         AddGuidParam(param, paramName, ParameterDirection.Input);
      }

      protected void AddGuidParam(Guid param, string paramName, ParameterDirection direction)
      {
         if (param == Guid.Empty && direction == ParameterDirection.Input)
            return;

         AddParam(param, paramName, DbType.Boolean, direction);
      }

      protected void AddBooleanParam(bool param, string paramName)
      {
         AddParam(param, paramName, DbType.Boolean, ParameterDirection.Input);
      }

      protected static void EnforceLength(ref string property, int length)
      {
         if (String.IsNullOrEmpty(property))
            return;

         if (property.Length > length)
            throw new ApplicationException(String.Format("Property is too long.  '{0}' cannot exceed {1} characters in length.", property, length));
         //property = property.Substring(0, length);
      }

      #endregion

      #region Private methods

      private void AddParam<T>(T param, string paramName, DbType type, ParameterDirection direction)
      {
         SqlParameter p = new SqlParameter("@" + paramName, type);

         p.Value = param;
         p.Direction = direction;

         parameters.Add(p);
      }

      #endregion
   }
}