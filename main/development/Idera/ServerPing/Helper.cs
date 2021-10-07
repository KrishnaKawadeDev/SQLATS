using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Management;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Wmi;
using Microsoft.SqlServer.Management.Common;

using Idera.SqlAdminToolset.Core;
using System.Threading;
using System.ServiceProcess;

namespace Idera.SqlAdminToolset.ServerPing
{
   class Helper
   {
      public static void
         WmiTest(
            int ndx // monitoredServerIndex
         )
      {
			try
			{
			   string host        = SQLHelpers.GetInstanceHost( ProductConstants.monitoredServers[ndx].server );
			   string serviceName = SQLHelpers.GetServiceName( ProductConstants.monitoredServers[ndx].server );
			   
			   if ( serviceName == "" ) throw new Exception("Unable to determine SQL Server service name");
			   
            string wmiPath = String.Format(@"\\{0}\root\cimv2", host);
			   
            CoreGlobals.traceLog.VerboseFormat("Instance: {0}",         ProductConstants.monitoredServers[ndx].server);
            CoreGlobals.traceLog.VerboseFormat("Instance Host: {0}",    host);
            CoreGlobals.traceLog.VerboseFormat("Instance Service: {0}", serviceName);
            
            ConnectionOptions co = new ConnectionOptions();
            co.Timeout = new TimeSpan(0, 0, ToolsetOptions.connectionTimeout);

            ManagementScope managementScope = new ManagementScope(wmiPath, co);
            managementScope.Connect();
            
            CoreGlobals.traceLog.Verbose("WMI Connected");
            
				System.Management.ObjectQuery objectQuery
				   = new System.Management.ObjectQuery( String.Format( "SELECT Name, Started, State FROM Win32_Service WHERE Name='{0}'",
                                                                   serviceName ) );

				//Query remote computer across the connection
				ManagementObjectSearcher query = new ManagementObjectSearcher(managementScope,objectQuery);
				
				ManagementObjectCollection queryCollection = query.Get();
				
				if ( queryCollection.Count == 0 )
				{
				   ProductConstants.monitoredServers[ndx].state = MonitoredServer.ServerState.NotInstalled;
				}
				else
				{
				   foreach ( ManagementObject managementObject in queryCollection )
				   {
                  // State 
                  // Current state of the base service.
                  // Values are:
                  // "Stopped"
                  // "Start Pending"
                  // "Stop Pending"
                  // "Running"
                  // "Continue Pending"
                  // "Pause Pending"
                  // "Paused"
                  // "Unknown"
   				   string state = WmiHelpers.GetString( managementObject, "State" );
   				   
				      if ( WmiHelpers.GetBool( managementObject, "Started" ) )
				      {
				         if ( state == "Running")
				         {
				            ProductConstants.monitoredServers[ndx].state = MonitoredServer.ServerState.OK;
                        ProductConstants.monitoredServers[ndx].errorMessage = "Service Running";
                     }
			            else
			            {
			               if ( state == "Paused" )
			               {
			                  ProductConstants.monitoredServers[ndx].state = MonitoredServer.ServerState.Paused;
                           ProductConstants.monitoredServers[ndx].errorMessage = "Service is paused.";
                        }
			               else if ( state == "Pause Pending" || state == "Continue Pending")
			               {
			                  ProductConstants.monitoredServers[ndx].state = MonitoredServer.ServerState.Paused;
                           ProductConstants.monitoredServers[ndx].errorMessage = "Service is paused.";
                        }
                        else
                        {
			                  ProductConstants.monitoredServers[ndx].state = MonitoredServer.ServerState.NotRunning;
                           ProductConstants.monitoredServers[ndx].errorMessage = "Service state is " + state;
                        }
			            }
				      }
				      else
				      {
				         ProductConstants.monitoredServers[ndx].state = MonitoredServer.ServerState.NotRunning;
                     ProductConstants.monitoredServers[ndx].errorMessage = "Service is stopped";
				      }
				      break; // we only care about one (and there should only be one exact match for an explicit service name
				   }
				}
			}
			catch (Exception e)
			{	
            ProductConstants.monitoredServers[ndx].state        = MonitoredServer.ServerState.Unknown;
            
            string msg = e.Message;
            if (e.Message.Contains( "is unavailable" ))
               msg = "Host computer is unavailable.";
            
            ProductConstants.monitoredServers[ndx].errorMessage = msg;
			}
      }

      public static void 
         SqlTest(
            int ndx // monitoredServerIndex
         )
      {
         SqlConnection   conn = null;
         bool            connected = false;

         try
         {         
            // connect
            try
            {
               string connStr = Connection.CreateConnectionString( 
                   ProductConstants.monitoredServers[ndx].server, 
                   "",
                   ProductConstants.monitoredServers[ndx].credentials ); 
               connStr += "Pooling=false;";                                                        

               conn = new SqlConnection(connStr);
                        Connection.Impersonate(ProductConstants.monitoredServers[ndx].credentials);
                    conn.Open();
            
               connected = true;
            }
            catch ( SqlException ex )
            {
               ProductConstants.monitoredServers[ndx].state        = MonitoredServer.ServerState.UnableToConnect;
               ProductConstants.monitoredServers[ndx].errorMessage = ex.Message;
            }
            catch ( Exception ex )
            {
               ProductConstants.monitoredServers[ndx].state        = MonitoredServer.ServerState.UnableToConnect;
               ProductConstants.monitoredServers[ndx].errorMessage = ex.Message;
            }
            
            // optionally run a query after connection is established
            if ( connected )
            {
               if ( ! ProductConstants.RunQuery )
               {
                  ProductConstants.monitoredServers[ndx].state = MonitoredServer.ServerState.OK;
                  ProductConstants.monitoredServers[ndx].errorMessage = "Service Running";
               }
               else
               {
                  try
                  {
                     using ( SqlCommand cmd = new SqlCommand( ProductConstants.Query, conn ) )
                     {
                        cmd.ExecuteReader();
                     }
                     ProductConstants.monitoredServers[ndx].state = MonitoredServer.ServerState.OK;
                     ProductConstants.monitoredServers[ndx].errorMessage = "Service Running / Query Ran";
                  }
                  catch ( SqlException ex )
                  {
                     ProductConstants.monitoredServers[ndx].state        = MonitoredServer.ServerState.QueryFailed;
                     ProductConstants.monitoredServers[ndx].errorMessage = ex.Message;
                  }
                  catch ( Exception ex )
                  {
                     ProductConstants.monitoredServers[ndx].state        = MonitoredServer.ServerState.QueryFailed;
                     ProductConstants.monitoredServers[ndx].errorMessage = ex.Message;
                  }
               }
            }
         }
         finally
         {
            Connection.CloseConnection( conn );
         }
      }

       public static void ChangeServerState(int ndx, ServerOperation operation)
       {
           string host = SQLHelpers.GetInstanceHost(ProductConstants.monitoredServers[ndx].server);
           string serviceName = SQLHelpers.GetServiceName(ProductConstants.monitoredServers[ndx].server);

           if (serviceName == "") throw new Exception("Unable to determine SQL Server service name");

           ServiceController _Service = new ServiceController(serviceName, host);
           if (_Service == null) throw new Exception("Unable to find SQL Server Service");

           Stopwatch _StopWatch = new Stopwatch();
           _StopWatch.Start();

           ServiceControllerStatus _ExpectedStatus = ServiceControllerStatus.Running;
           switch(operation)
           {
               case ServerOperation.Start:
                   _Service.Start();
                   _ExpectedStatus = ServiceControllerStatus.Running;
                   break;
               case ServerOperation.Stop:
                   if (_Service.CanStop)
                   {
                       _Service.Stop();
                       _ExpectedStatus = ServiceControllerStatus.Stopped;
                   }
                   else
                   {
                       throw new Exception("The server is not in a stoppable state");
                   }
                   break;
               case ServerOperation.Pause:
                   if (_Service.CanPauseAndContinue)
                   {
                       _Service.Pause();
                       _ExpectedStatus = ServiceControllerStatus.Paused;
                   }
                   else 
                   {
                       throw new Exception("The server cannot be paused at the moment");
                   }
                   break;
               case ServerOperation.Resume:
                   _Service.Continue();
                   _ExpectedStatus = ServiceControllerStatus.Running;
                   break;
            }
           
           _Service.Refresh();
           while (_Service.Status != _ExpectedStatus)
           {
               Thread.Sleep(1000);
               _Service.Refresh();
               if (_StopWatch.Elapsed.TotalSeconds > ToolsetOptions.connectionTimeout)
               {
                   throw new Exception(string.Format("Timeout waiting for the server to enter the {0} state", _ExpectedStatus));
               }
           }
       }
   }
       internal enum ServerOperation
       {
           Start,
           Stop,
           Restart,
           Pause,
           Resume
       }
}
