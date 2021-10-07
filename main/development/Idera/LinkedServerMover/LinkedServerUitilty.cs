using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using System.Collections.Specialized;
using Idera.SqlAdminToolset.Core;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Transactions;
using System.Management;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using BBS.TracerX;
using Idera.SqlAdminToolset.DatabaseMoverLibrary;

namespace Idera.SqlAdminToolset.LinkedServerMover
{
   public class LinkedServerUtility
   {
      Logger logger = CoreGlobals.traceLog;
      LinkedServerMoveCompleteEventArgs _EventArgs = null;

      /// <summary>
      /// Finds linked servers that are missing between a source and a destination server.
      /// </summary>
      public static List<LinkedServer> FindMissingLinkedServers(Server sourceServer, Server destinationServer, BackgroundWorker worker)
      {
         sourceServer.SetDefaultInitFields(typeof(LinkedServer), new string[] { "Name"});

         List<LinkedServer> missingLinkedServers = new List<LinkedServer>();

         foreach (LinkedServer sourceLinkedServer in sourceServer.LinkedServers)
         {
            if (sourceLinkedServer.Name != "repl_distributor"                 && 
                !destinationServer.LinkedServers.Contains(sourceLinkedServer.Name)   &&
                destinationServer.Name.ToLower() != sourceLinkedServer.Name.ToLower())
            {
               missingLinkedServers.Add(sourceLinkedServer);
            }
            if (worker != null && worker.CancellationPending)
            {
               return missingLinkedServers;
            }
         }
         return missingLinkedServers;
      }

      /// <summary>
      /// Returns true if the requested operation is valid for the combination of source are destination servers.
      /// </summary>
      public static bool IsValidOperation(Server sourceServer, Server destinationServer, bool moveLoginInformationOnly)
      {
         return IsValidOperation(CheckVersion(sourceServer, destinationServer), moveLoginInformationOnly);
      }

      private static bool IsValidOperation(TransferVersionInfo versionInfo, bool moveLoginInformationOnly)
      {
         if (versionInfo == TransferVersionInfo.NotSupported)
         {
            return false;
         }
         return true;
      }

      /// <summary>
      /// Gets the version combination for the requested operation.
      /// </summary>
      private static TransferVersionInfo CheckVersion(Server sourceServer, Server destinationServer)
      {
         TransferVersionInfo versionInfo = TransferVersionInfo.NotSupported;

         if (SQLHelpers.Is2005(destinationServer.Information.Version.Major))
         {
            if (SQLHelpers.Is2005(sourceServer.Information.Version.Major))  //2005 -> 2005
            {
               versionInfo = TransferVersionInfo.Sql2005To2005;
            }
            else if (SQLHelpers.Is2012(sourceServer.Information.Version.Major))  //2012 -> 2005
            {
                versionInfo = TransferVersionInfo.Sql2012To2005;
            }
            else if (SQLHelpers.Is2008(sourceServer.Information.Version.Major))  //2008 -> 2005
            {
               versionInfo = TransferVersionInfo.Sql2008To2005;
            }
            else if (SQLHelpers.Is2000(sourceServer.Information.Version.Major))  //2000 -> 2005
            {
               versionInfo = TransferVersionInfo.Sql2000Upgrade;
            }
            else if (SQLHelpers.Is2014(sourceServer.Information.Version.Major))  //2012 -> 2005
            {
                versionInfo = TransferVersionInfo.Sql2014To2005;
            }
            else if (SQLHelpers.Is2016(sourceServer.Information.Version.Major))  //2012 -> 2005
            {
                versionInfo = TransferVersionInfo.Sql2016To2005;
            }
                else if (SQLHelpers.Is2017orGreater(sourceServer.Information.Version.Major))  //2012 -> 2005
                {
                    versionInfo = TransferVersionInfo.Sql2017To2005;
                }
            }
         else if (SQLHelpers.Is2000(destinationServer.Information.Version.Major))
         {
            if (SQLHelpers.Is2000(sourceServer.Information.Version.Major))  //2000 -> 2000
            {
               versionInfo = TransferVersionInfo.Sql2000To2000;
            }
            else if (SQLHelpers.Is2005(sourceServer.Information.Version.Major))  //2005 -> 2000
            {
               versionInfo = TransferVersionInfo.Sql2005To2000;
            }
            else if (SQLHelpers.Is2008(sourceServer.Information.Version.Major))  //2008 -> 2000
            {
               versionInfo = TransferVersionInfo.Sql2008To2000;
            }
            else if (SQLHelpers.Is2012(sourceServer.Information.Version.Major))  //2012 -> 2000
            {
                versionInfo = TransferVersionInfo.Sql2012To2000;
            }
            else if (SQLHelpers.Is2014(sourceServer.Information.Version.Major))  //2012 -> 2000
            {
                versionInfo = TransferVersionInfo.Sql2014To2000;
            }
            else if (SQLHelpers.Is2016(sourceServer.Information.Version.Major))  //2012 -> 2000
            {
                versionInfo = TransferVersionInfo.Sql2016To2000;
            }
                else if (SQLHelpers.Is2017orGreater(sourceServer.Information.Version.Major))  //2012 -> 2000
                {
                    versionInfo = TransferVersionInfo.Sql2017To2000;
                }

            }
         else if (SQLHelpers.Is2008(destinationServer.Information.Version.Major))
         {
            if (SQLHelpers.Is2000(sourceServer.Information.Version.Major))  //2000 -> 2008
            {
               versionInfo = TransferVersionInfo.Sql2000Upgrade;
            }
            else if (SQLHelpers.Is2005(sourceServer.Information.Version.Major))  //2005 -> 2008
            {
               versionInfo = TransferVersionInfo.Sql2005Upgrade;
            }
            else if (SQLHelpers.Is2008(sourceServer.Information.Version.Major))  //2008 -> 2008
            {
               versionInfo = TransferVersionInfo.Sql2008To2008;
            }
            else if (SQLHelpers.Is2012(sourceServer.Information.Version.Major))  //2012 -> 2008
            {
                versionInfo = TransferVersionInfo.Sql2012To2008;
            }
            else if (SQLHelpers.Is2014(sourceServer.Information.Version.Major))  //2012 -> 2008
            {
                versionInfo = TransferVersionInfo.Sql2014To2008;
            }
            else if (SQLHelpers.Is2016(sourceServer.Information.Version.Major))  //2012 -> 2008
            {
                versionInfo = TransferVersionInfo.Sql2016To2008;
            }
                else if (SQLHelpers.Is2017orGreater(sourceServer.Information.Version.Major))  //2012 -> 2008
                {
                    versionInfo = TransferVersionInfo.Sql2017To2008;
                }

            }
         else if (SQLHelpers.Is2012(destinationServer.Information.Version.Major))
         {
             if (SQLHelpers.Is2000(sourceServer.Information.Version.Major))  //2000 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2000Upgrade;
             }
             else if (SQLHelpers.Is2005(sourceServer.Information.Version.Major))  //2005 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2005Upgrade;
             }
             else if (SQLHelpers.Is2008(sourceServer.Information.Version.Major))  //2008 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2008Upgrade;
             }
             else if (SQLHelpers.Is2012(sourceServer.Information.Version.Major))  //2012 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2012To2012;
             }
             else if (SQLHelpers.Is2014(sourceServer.Information.Version.Major))  //2012 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2012Upgrade;
             }
             else if (SQLHelpers.Is2016(sourceServer.Information.Version.Major))  //2012 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2016To2012;
             }
                else if (SQLHelpers.Is2017orGreater(sourceServer.Information.Version.Major))  //2012 -> 2012
                {
                    versionInfo = TransferVersionInfo.Sql2017To2012;
                }

            }
         else if (SQLHelpers.Is2014(destinationServer.Information.Version.Major))
         {
             if (SQLHelpers.Is2000(sourceServer.Information.Version.Major))  //2000 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2000Upgrade;
             }
             else if (SQLHelpers.Is2005(sourceServer.Information.Version.Major))  //2005 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2005Upgrade;
             }
             else if (SQLHelpers.Is2008(sourceServer.Information.Version.Major))  //2008 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2008Upgrade;
             }
             else if (SQLHelpers.Is2012(sourceServer.Information.Version.Major))  //2012 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2014To2012;
             }
             else if (SQLHelpers.Is2014(sourceServer.Information.Version.Major))  //2012 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2014To2014;
             }
             else if (SQLHelpers.Is2016(sourceServer.Information.Version.Major))  //2012 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2016To2014;
             }
                else if (SQLHelpers.Is2017orGreater(sourceServer.Information.Version.Major))  //2012 -> 2012
                {
                    versionInfo = TransferVersionInfo.Sql2017To2014;
                }

            }
         else if (SQLHelpers.Is2016(destinationServer.Information.Version.Major))
         {
             if (SQLHelpers.Is2000(sourceServer.Information.Version.Major))  //2000 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2000Upgrade;
             }
             else if (SQLHelpers.Is2005(sourceServer.Information.Version.Major))  //2005 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2005Upgrade;
             }
             else if (SQLHelpers.Is2008(sourceServer.Information.Version.Major))  //2008 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2008Upgrade;
             }
             else if (SQLHelpers.Is2012(sourceServer.Information.Version.Major))  //2012 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2014To2012;
             }
             else if (SQLHelpers.Is2014(sourceServer.Information.Version.Major))  //2012 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2014Upgrade;
             }
             else if (SQLHelpers.Is2016(sourceServer.Information.Version.Major))  //2012 -> 2012
             {
                 versionInfo = TransferVersionInfo.Sql2016To2016;
             }
                else if (SQLHelpers.Is2017orGreater(sourceServer.Information.Version.Major))  //2012 -> 2012
                {
                    versionInfo = TransferVersionInfo.Sql2017To2017;
                }

            }
            else if (SQLHelpers.Is2017orGreater(destinationServer.Information.Version.Major))
            {
                if (SQLHelpers.Is2000(sourceServer.Information.Version.Major))  //2000 -> 2012
                {
                    versionInfo = TransferVersionInfo.Sql2000Upgrade;
                }
                else if (SQLHelpers.Is2005(sourceServer.Information.Version.Major))  //2005 -> 2012
                {
                    versionInfo = TransferVersionInfo.Sql2005Upgrade;
                }
                else if (SQLHelpers.Is2008(sourceServer.Information.Version.Major))  //2008 -> 2012
                {
                    versionInfo = TransferVersionInfo.Sql2008Upgrade;
                }
                else if (SQLHelpers.Is2012(sourceServer.Information.Version.Major))  //2012 -> 2012
                {
                    versionInfo = TransferVersionInfo.Sql2014To2012;
                }
                else if (SQLHelpers.Is2014(sourceServer.Information.Version.Major))  //2012 -> 2012
                {
                    versionInfo = TransferVersionInfo.Sql2014Upgrade;
                }
                else if (SQLHelpers.Is2016(sourceServer.Information.Version.Major))  //2012 -> 2012
                {
                    versionInfo = TransferVersionInfo.Sql2016To2016;
                }
                else if (SQLHelpers.Is2017orGreater(sourceServer.Information.Version.Major))  //2012 -> 2012
                {
                    versionInfo = TransferVersionInfo.Sql2017To2017;
                }

            }

            return versionInfo;
      }

      #region events
      private EventHandler<StatusEventArgs> _TaskStatus;

      public EventHandler<StatusEventArgs> TaskStatusEventHandler
      {
         get { return _TaskStatus; }
         set { _TaskStatus = value; }
      }

      /// <summary>
      /// Raised when a task completes on a server.
      /// </summary>
      public event EventHandler<StatusEventArgs> TaskStatus
      {
         add { _TaskStatus += value; }
         remove { _TaskStatus -= value; }
      }

      private EventHandler<TaskCompleteEventArgs> _TaskComplete;

      public EventHandler<TaskCompleteEventArgs> TaskCompleteEventHandler
      {
         get { return _TaskComplete; }
         set { _TaskComplete = value; }
      }

      /// <summary>
      /// Raised when a task completes on a server.
      /// </summary>
      public event EventHandler<TaskCompleteEventArgs> TaskComplete
      {
         add { _TaskComplete += value; }
         remove { _TaskComplete -= value; }
      }
      #endregion

      /// <summary>
      /// Moves missing linked servers from a SQL server to another.
      /// </summary>
      public LinkedServerMoveCompleteEventArgs MoveLinkedServers(Server sourceServer,           Server destinationServer, 
                                                                 List<LinkedServer> serverList, Dictionary<string, Dictionary<string, string>> logins, 
                                                                 List<Login> loginsToMove,      BackgroundWorker worker)
      {
         _EventArgs = new LinkedServerMoveCompleteEventArgs();


         try
         {
            if (loginsToMove.Count > 0)
            {
               if (worker != null && worker.CancellationPending)
               {
                  return _EventArgs;
               }
               RaiseStatus(MoverStep.CopyLogins, ProductConstants.CopyLocalLogins);
               Utility moverUtility = new Utility();
               LoginMoveCompleteEventArgs args = (LoginMoveCompleteEventArgs)moverUtility.MoveLogins(sourceServer, destinationServer, loginsToMove);
               
               if (args.Success == false)
               {
                  throw args.TaskException;
               }
            }

            RaiseStatus(MoverStep.Initialize, ProductConstants.StatusGatheringData);
            TransferVersionInfo versionInfo = CheckVersion(sourceServer, destinationServer);

            if (!IsValidOperation(versionInfo, true))
            {
               throw new NotSupportedException(ProductConstants.ErrorNotSupportedSqlCombination);
            }

            if (serverList.Count > 0)
            {
               try
               {
                  if (worker != null && worker.CancellationPending)
                  {
                     return _EventArgs;
                  }
                  RaiseStatus(MoverStep.MoveLinkedServers, ProductConstants.CopyLinkedServers);
                  TransferLinkedServers(sourceServer, destinationServer, serverList, logins, versionInfo, worker);
               }
               catch (Exception exc)
               {
                  logger.Error("Error moving linked servers", exc);
                  throw;
               }
            }
         }
         catch (Exception e)
         {
            logger.Error("Error moving linked servers", e);
            _EventArgs.TaskException = e;
            _EventArgs.AppendLog(Helpers.GetCombinedExceptionText(e));
            _EventArgs.Success = false;
         }

         if (_EventArgs.Success)
         {
            RaiseStatus(MoverStep.CompleteSuccess, ProductConstants.StatusTaskComplete);
         }
         else
         {
            RaiseStatus(MoverStep.CompleteFailed, ProductConstants.StatusTaskFailed);
         }

         if (_TaskComplete != null)
         {
            _TaskComplete(this, _EventArgs);
         }

         return _EventArgs;
      }

      /// <summary>
      /// Transfers logins from one database to another.
      /// </summary>
      private void TransferLinkedServers(Server sourceServer,              Server destinationServer, 
                                         List<LinkedServer> linkedServers, Dictionary<string, Dictionary<string, string>> logins, 
                                         TransferVersionInfo versionInfo,  BackgroundWorker worker)
      {
         LinkedServerMoveCompleteEventArgs linkedServerMoveArgs = _EventArgs;
         Dictionary<string, string> passwords = null;

         if (linkedServers.Count > 0)
         {
            foreach (LinkedServer linkedServer in linkedServers)
            {
               try
               {
                  logger.Debug(string.Format("Transfering Linked Server {0}:", linkedServer.Name));
                  
                  if (linkedServerMoveArgs != null)
                  {
                     linkedServerMoveArgs.MoveResults.Add(linkedServer.Name, null);
                  }
                  RaiseStatus(MoverStep.MoveLinkedServers, string.Format(ProductConstants.StatusTransferingLinkedServer, linkedServer.Name));
                  string copyScript = null;

                  if (logins != null)
                  {
                     if (logins.ContainsKey(linkedServer.Name))
                        passwords = logins[linkedServer.Name];
                     else
                        passwords = null;
                  }
                  else
                     passwords = null;
                  copyScript = GetLinkedServerCopyScript(linkedServer, versionInfo, passwords);

                  RaiseStatus(MoverStep.MoveLinkedServers, ProductConstants.StatusTransferingLinkedServerExecuteScript);

                  if (String.IsNullOrEmpty(copyScript) == false)
                  {
                     using (SqlCommand _Command = new SqlCommand())
                     {
                        if (destinationServer.ConnectionContext.SqlConnectionObject.State != System.Data.ConnectionState.Open)
                        {
                           destinationServer.ConnectionContext.SqlConnectionObject.Open();
                        }
                        _Command.Connection = destinationServer.ConnectionContext.SqlConnectionObject;
                        _Command.CommandTimeout = ToolsetOptions.commandTimeout;
                        _Command.CommandText = copyScript;
                        _Command.ExecuteNonQuery();
                     }
                  }
               }
               catch (Exception exc)
               {
                  logger.Error(string.Format("Error transfering linked server {0}:", linkedServer.Name), exc);
                  linkedServerMoveArgs.MoveResults[linkedServer.Name] = exc;
               }

               //check for cancel
               if (worker != null && worker.CancellationPending)
               {
                  return;
               }
            }
         }
      }

      #region Linked Server Copy Scripts

      /// <summary>
      /// Create the copy linked server script
      /// </summary>
      /// <param name="server"></param>
      /// <param name="linkedServerName"></param>
      private static string GetLinkedServerCopyScript(LinkedServer linkedServer, TransferVersionInfo versionInfo, Dictionary<string, string> passwords)
      {
         StringBuilder users = new StringBuilder();
         StringBuilder script = new StringBuilder();

         foreach (LinkedServerLogin login in linkedServer.LinkedServerLogins)
         {
            //Skip the empty logins
            if (String.IsNullOrEmpty(login.Name) && String.IsNullOrEmpty(login.RemoteUser))
            {
               continue;
            }
            users.Append("EXEC master.dbo.sp_addlinkedsrvlogin ");
            users.AppendFormat("@rmtsrvname=N{0}, ", Helpers.CreateSafeString(linkedServer.Name));

            if (login.Impersonate)
               users.Append("@useself=N'True', ");
            else
               users.Append("@useself=N'False', ");

            if (String.IsNullOrEmpty(login.Name) == false)
               users.AppendFormat("@locallogin=N{0}, ", Helpers.CreateSafeString(login.Name));
            else
               users.Append("@locallogin=null, ");

            if (String.IsNullOrEmpty(login.RemoteUser) == false)
            {
               users.AppendFormat("@rmtuser=N{0}, ", Helpers.CreateSafeString(login.RemoteUser));

               //This is a SQL Server login, get the password
               if (login.RemoteUser.Contains("\\") == false)
               {
                  //should not be ever be the case but need to check just in casae.
                  if (passwords != null)
                  {
                     if (passwords.ContainsKey(login.RemoteUser))
                        users.AppendFormat("@rmtpassword =N{0} ", Helpers.CreateSafeString(passwords[login.RemoteUser]));
                  }
               }
               else
                  users.Append("@rmtpassword=null ");
            }
            else
            {
               users.Append("@rmtuser=null, ");
               users.Append("@rmtpassword=null ");
            }

         }
         script.Append("EXEC master.dbo.sp_addlinkedserver ");
         script.AppendFormat("@server=N{0}, ", Helpers.CreateSafeString(linkedServer.Name));
         script.AppendFormat("@srvproduct=N{0}", Helpers.CreateSafeString(linkedServer.ProductName));

         if (linkedServer.ProductName.ToUpper() != "SQL SERVER")
         {
            script.AppendFormat(", @provider=N{0}, ", Helpers.CreateSafeString(linkedServer.ProviderName));
            script.AppendFormat("@datasrc=N{0}, ", Helpers.CreateSafeString(linkedServer.DataSource));
            script.AppendFormat("@location=N{0}, ", Helpers.CreateSafeString(linkedServer.Location));
            script.AppendFormat("@provstr=N{0}, ", Helpers.CreateSafeString(linkedServer.ProviderString));
            script.AppendFormat("@catalog=N{0} ", Helpers.CreateSafeString(linkedServer.Catalog));
         }
         else
            script.Append(" ");

         //Add the logins
         script.Append(users.ToString());

         //collation compatible
         script.Append("EXEC master.dbo.sp_serveroption ");
         script.AppendFormat("@server=N{0}, ", Helpers.CreateSafeString(linkedServer.Name));
         script.Append("@optname=N'collation compatible', ");
         script.AppendFormat("@optvalue=N{0} ", Helpers.CreateSafeString(linkedServer.CollationCompatible.ToString()));
         //data access
         script.Append("EXEC master.dbo.sp_serveroption ");
         script.AppendFormat("@server=N{0}, ", Helpers.CreateSafeString(linkedServer.Name));
         script.Append("@optname=N'data access', ");
         script.AppendFormat("@optvalue=N{0} ", Helpers.CreateSafeString(linkedServer.DataAccess.ToString()));
         //rpc
         script.Append("EXEC master.dbo.sp_serveroption ");
         script.AppendFormat("@server=N{0}, ", Helpers.CreateSafeString(linkedServer.Name));
         script.Append("@optname=N'rpc', ");
         script.AppendFormat("@optvalue=N{0} ", Helpers.CreateSafeString(linkedServer.Rpc.ToString()));
         //rpc out
         script.Append("EXEC master.dbo.sp_serveroption ");
         script.AppendFormat("@server=N{0}, ", Helpers.CreateSafeString(linkedServer.Name));
         script.Append("@optname=N'rpc out', ");
         script.AppendFormat("@optvalue=N{0} ", Helpers.CreateSafeString(linkedServer.RpcOut.ToString()));
         //use remote collation
         script.Append("EXEC master.dbo.sp_serveroption ");
         script.AppendFormat("@server=N{0}, ", Helpers.CreateSafeString(linkedServer.Name));
         script.Append("@optname=N'use remote collation', ");
         script.AppendFormat("@optvalue=N{0} ", Helpers.CreateSafeString(linkedServer.UseRemoteCollation.ToString()));
         // collation name
         script.Append("EXEC master.dbo.sp_serveroption ");
         script.AppendFormat("@server=N{0}, ", Helpers.CreateSafeString(linkedServer.Name));
         script.Append("@optname=N'collation name', ");

         if (String.IsNullOrEmpty(linkedServer.CollationName))
            script.AppendFormat("@optvalue=null ");
         else
            script.AppendFormat("@optvalue=N{0} ", Helpers.CreateSafeString(linkedServer.CollationName.ToString()));
         //connection timeout
         script.Append("EXEC master.dbo.sp_serveroption ");
         script.AppendFormat("@server=N{0}, ", Helpers.CreateSafeString(linkedServer.Name));
         script.Append("@optname=N'connect timeout', ");
         script.AppendFormat("@optvalue=N{0} ", Helpers.CreateSafeString(linkedServer.ConnectTimeout.ToString()));
         //query timeout
         script.Append("EXEC master.dbo.sp_serveroption ");
         script.AppendFormat("@server=N{0}, ", Helpers.CreateSafeString(linkedServer.Name));
         script.Append("@optname=N'query timeout', ");
         script.AppendFormat("@optvalue=N{0} ", Helpers.CreateSafeString(linkedServer.QueryTimeout.ToString()));

         // these options were added in 2008
         if (versionInfo == TransferVersionInfo.Sql2008To2008)
         {
            //distribtor
            script.Append("EXEC master.dbo.sp_serveroption ");
            script.AppendFormat("@server=N{0}, ", Helpers.CreateSafeString(linkedServer.Name));
            script.Append("@optname=N'dist', ");
            script.AppendFormat("@optvalue=N{0} ", Helpers.CreateSafeString(linkedServer.Distributor.ToString()));
            //publisher
            script.Append("EXEC master.dbo.sp_serveroption ");
            script.AppendFormat("@server=N{0}, ", Helpers.CreateSafeString(linkedServer.Name));
            script.Append("@optname=N'pub', ");
            script.AppendFormat("@optvalue=N{0} ", Helpers.CreateSafeString(linkedServer.Publisher.ToString()));
            //subscriber
            script.Append("EXEC master.dbo.sp_serveroption ");
            script.AppendFormat("@server=N{0}, ", Helpers.CreateSafeString(linkedServer.Name));
            script.Append("@optname=N'sub', ");
            script.AppendFormat("@optvalue=N{0} ", Helpers.CreateSafeString(linkedServer.Subscriber.ToString()));
            //lazy schema validation
            script.Append("EXEC master.dbo.sp_serveroption ");
            script.AppendFormat("@server=N{0}, ", Helpers.CreateSafeString(linkedServer.Name));
            script.Append("@optname=N'lazy schema validation', ");
            script.AppendFormat("@optvalue=N{0} ", Helpers.CreateSafeString(linkedServer.LazySchemaValidation.ToString()));
            //enable promotion of distributed transations
            script.Append("EXEC master.dbo.sp_serveroption ");
            script.AppendFormat("@server=N{0}, ", Helpers.CreateSafeString(linkedServer.Name));
            script.Append("@optname=N'remote proc transaction promotion', ");
            script.AppendFormat("@optvalue=N{0} ", Helpers.CreateSafeString(linkedServer.IsPromotionofDistributedTransactionsForRPCEnabled.ToString()));
         }
         return script.ToString();
      }
      #endregion 

      private void RaiseStatus(MoverStep step, string stepDescription)
      {
         _EventArgs.AppendLog(stepDescription);
         if (_TaskStatus != null)
         {
            _TaskStatus(this, new StatusEventArgs(step, stepDescription));
         }
         logger.InfoFormat("{0}: {1}", step, stepDescription);
      }

   }

   #region EventArgs
   public class StatusEventArgs : EventArgs
   {
      private MoverStep _Step;
      private string _Description;

      public StatusEventArgs(MoverStep step, string description)
      {
         _Step = step;
         _Description = description;
      }

      /// <summary>
      /// Step
      /// </summary>
      public MoverStep Step
      {
         get { return _Step; }
      }

      /// <summary>
      /// Description
      /// </summary>
      public string Description
      {
         get { return _Description; }
      }
   }

   public enum MoverStep
   {
      Initialize,
      CopyLogins,
      RenameExistingDestination,
      MoveLinkedServers,
      DetachDatabase,
      AttachDatabase,
      SetDefaultDatabase,
      CopyFiles,
      DeleteSource,
      ApplyDatabasePermissions,
      CompleteSuccess,
      CompleteFailed
   }

   public class LinkedServerMoveCompleteEventArgs : TaskCompleteEventArgs
   {
      Dictionary<string, Exception> _MoveResults = new Dictionary<string, Exception>();

      /// <summary>
      /// Dictionary containing moved logins and their exception (if any) during the move.
      /// </summary>
      public Dictionary<string, Exception> MoveResults
      {
         get { return _MoveResults; }
      }
   }

   public class TaskCompleteEventArgs : EventArgs
   {
      private StringBuilder _Log = new StringBuilder();
      private bool _Success = true;
      private Exception _Exception = null;

      /// <summary>
      /// Log
      /// </summary>
      public string Log
      {
         get { return _Log.ToString(); }
      }

      /// <summary>
      /// Success
      /// </summary>
      public bool Success
      {
         get { return _Success; }
         set { _Success = value; }
      }

      /// <summary>
      /// Exception encountered during the mover task.
      /// </summary>
      public Exception TaskException
      {
         get { return _Exception; }
         set { _Exception = value; }
      }

      public void AppendLog(string log)
      {
         _Log.Append(log);
         _Log.Append(Environment.NewLine);
      }
   }

   #endregion

   #region VersionInfo Enum
   /// <summary>
   /// Information about the version combination for the requested transfer.
   /// </summary>
   public enum TransferVersionInfo
   {
       /// <summary>
       /// The requested version combination is not supported
       /// </summary>
       NotSupported,

       /// <summary>
       /// SQL Server 2000 to SQL Server 2000
       /// </summary>
       Sql2000To2000,

       /// <summary>
       /// SQL Server 2000 to SQL Server 2005 or above
       /// </summary>
       Sql2000Upgrade,

       /// <summary>
       /// SQL Server 2005 to SQL Server 2005
       /// </summary>
       Sql2005To2005,

       /// <summary>
       /// SQL Server 2005 to SQL Server 2000 (security info only)
       /// </summary>
       Sql2005To2000,

       /// <summary>
       /// SQL Server 2005 upgrade to 2008
       /// </summary>
       Sql2005Upgrade,

       /// <summary>
       /// SQL Server 2008 to SQL Server 2008
       /// </summary>
       Sql2008To2008,

       /// <summary>
       /// SQL Server 2008 to SQL Server 2005
       /// </summary>
       Sql2008To2005,

       /// <summary>
       /// SQL Server 2008 to SQL Server 2000
       /// </summary>
       Sql2008To2000,

       /// <summary>
       /// SQL Server 2008 upgrade to 2012
       /// </summary>
       Sql2008Upgrade,

       /// <summary>
       /// SQL Server 2012 to SQL Server 2012
       /// </summary>
       Sql2012To2012,

       /// <summary>
       /// SQL Server 2012 to SQL Server 2008
       /// </summary>
       Sql2012To2008,

       /// <summary>
       /// SQL Server 2012 to SQL Server 2005
       /// </summary>
       Sql2012To2005,
       /// <summary>
       /// SQL Server 2012 to SQL Server 2000
       /// </summary>
       Sql2012To2000,
       /// <summary>
       /// SQL Server 2012 to SQL Server 2014
       /// </summary>
       Sql2012Upgrade,
       /// <summary>
       /// SQL Server 2014 to SQL Server 2014
       /// </summary>
       Sql2014To2014,
       /// <summary>
       /// SQL Server 2014 to SQL Server 2012
       /// </summary>
       Sql2014To2012,
       /// <summary>
       /// SQL Server 2014 to SQL Server 2008
       /// </summary>
       Sql2014To2008,
       /// <summary>
       /// SQL Server 2014 to SQL Server 2005
       /// </summary>
       Sql2014To2005,
       /// <summary>
       /// SQL Server 2014 to SQL Server 2000
       /// </summary>
       Sql2014To2000,
       // <summary>
       /// SQL Server 2016 to SQL Server 2005
       /// </summary>
       Sql2016To2005,
       // <summary>
       /// SQL Server 2016 to SQL Server 2000
       /// </summary>
       Sql2016To2000,
       // <summary>
       /// SQL Server 2016 to SQL Server 2008
       /// </summary>
       Sql2016To2008,
       // <summary>
       /// SQL Server 2016 to SQL Server 2012
       /// </summary>
       Sql2016To2012,
       // <summary>
       /// SQL Server 2016 to SQL Server 2014
       /// </summary>
       Sql2016To2014,
       // <summary>
       /// SQL Server 2016 to SQL Server 2016
       /// </summary>
       Sql2016To2016,
        // <summary>
        /// SQL Server 2014 to SQL Server 2000
        /// </summary>
          Sql2017To2005,
        // <summary>
        /// SQL Server 2016 to SQL Server 2000
        /// </summary>
        Sql2017To2000,
        // <summary>
        /// SQL Server 2016 to SQL Server 2008
        /// </summary>
        Sql2017To2008,
        // <summary>
        /// SQL Server 2016 to SQL Server 2012
        /// </summary>
        Sql2017To2012,
        // <summary>
        /// SQL Server 2016 to SQL Server 2014
        /// </summary>
        Sql2017To2014,
        // <summary>
        /// SQL Server 2016 to SQL Server 2016
        /// </summary>
        Sql2017To2016,
        // <summary>
        /// SQL Server 2014 to SQL Server 2000
        /// </summary>
         Sql2017To2017,
        // <summary>
        /// SQL Server 2014 to SQL Server 2000
        /// </summary>
        Sql2014Upgrade

    }
   #endregion
}
