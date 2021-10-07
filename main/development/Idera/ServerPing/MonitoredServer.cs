using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.ServerPing
{
   public class MonitoredServer
   {
      public enum ServerState
      {
         FirstTime       = -1,
         OK              = 0,  // green
         NotRunning      = 1,
         NotInstalled    = 2,
         Unknown         = 4,
         UnableToConnect = 5,
         QueryFailed     = 6,
         Paused          = 7,
      }
      
      public MonitoredServer( 
         string         inServer, 
         SQLCredentials inCredentials,
         bool           inIgnore )
      {
         server             = inServer;
         credentials        = inCredentials;
         ignore             = inIgnore;
      }
      
      
      public string         server;
      public SQLCredentials credentials;
      public bool           ignore;
      public ServerState    state           = ServerState.FirstTime;
      public ServerState    lastState       = ServerState.FirstTime;
      public bool           partOfLastCheck = false;
      public string         errorMessage;

      public MonitoredServer Clone()
      { 
         MonitoredServer clone = new MonitoredServer( this.server, 
                                                      this.credentials,
                                                      this.ignore );
         
         clone.state           = ServerState.Unknown;
         clone.lastState       = this.lastState;
         clone.partOfLastCheck = false;
         clone.errorMessage    = "";
         
         return clone;
      }
      
      public static int
         FindServerInList(
            string instance
         )
      {
         int ndx = -1;
         
         for ( int i=0; i<ProductConstants.monitoredServers.Count; i++ )
         {
            if ( ProductConstants.monitoredServers[i].server.ToUpper() == instance.ToUpper() )
            {
               ndx = i;
               break;
            }
         }
      
         return ndx;
      }
      
      public static void ReadServerList()
      {
         // open registry keys for read/writing/deleting
         RegistryKey toolsetKey  = null;
         RegistryKey toolKey     = null;
         RegistryKey serversKey  = null;
         
         try
         {
            toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
            toolKey    = toolsetKey.CreateSubKey(ProductConstants.shortProductName);
            serversKey = toolKey.CreateSubKey("Servers");
            
            // get 
            
            // get all keys under servers
            foreach ( string serverName in serversKey.GetSubKeyNames() )
            {
               RegistryKey serverKey = null;
               try
               {
                  serverKey = serversKey.OpenSubKey(serverName);
                  
                  SQLCredentials cred = new SQLCredentials();
                  int    sql       = (int)serverKey.GetValue( "Type", 0 );
                  string loginName = (string)serverKey.GetValue( "Param1", "" );
                  string password  = (string)serverKey.GetValue( "Param2", "" );
                  
                  if ( loginName != "" )
                  {
                     cred.useSqlAuthentication = Convert.ToBoolean(sql);
                     cred.loginName = EncryptionHelper.QuickDecrypt(loginName);

                     if ( String.IsNullOrEmpty(password) )
                        cred.password = "";
                     else
                        cred.password = EncryptionHelper.QuickDecrypt(password);
                  }
                  else
                  {
                     cred.useSqlAuthentication = false;
                  }
                  
                  int ignore = (int)serverKey.GetValue( "Ignore", 0 );
                  
                  string realServerName = serverName.Replace( ' ', '\\' );
                  MonitoredServer ms = new MonitoredServer( realServerName, cred, ignore!=0 );
                  
                  ProductConstants.monitoredServers.Add( ms );
               }
               catch ( Exception subEx )
               {
                  CoreGlobals.traceLog.ErrorFormat( "Error reading monitored server {0} information - {1}", serverName, subEx.Message );
               }
               finally
               {
                  if (serverKey != null )
                  {
                     serverKey.Close();
                     serverKey =null;
                  }
               }
            }
         }
         catch ( Exception ex )
         {
            CoreGlobals.traceLog.ErrorFormat( "Error reading monitored server list - {0}", ex.Message );
         }
         finally
         {
             if (toolsetKey != null) toolsetKey.Close();
             if (toolKey    != null) toolKey.Close();
             if (serversKey != null) serversKey.Close();
         }
      }
      
      public static void
         WriteServerList()
      {
         // open registry keys for read/writing/deleting
         RegistryKey toolsetKey = null;
         RegistryKey toolKey    = null;
         RegistryKey serversKey = null;
         
         List<MonitoredServer> monitoredServers = new List<MonitoredServer>();

         try
         {
            toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
            toolKey    = toolsetKey.CreateSubKey(ProductConstants.shortProductName);

            // kill old server keys
            try
            {
               toolKey.DeleteSubKeyTree( "Servers" );
            }
            catch {} // ignore exceptions for things like missing keys

            // write new entries            
            serversKey = toolKey.CreateSubKey("Servers");
            foreach ( MonitoredServer srv in ProductConstants.monitoredServers )
            {
               if ( srv.partOfLastCheck )
               {
                  RegistryKey serverKey = null;
                  
                  try
                  {
                      string keyName = srv.server.Replace( '\\', ' ' );
                      serverKey  = serversKey.CreateSubKey(keyName);

                      if ( srv.credentials != null)
                      {
                         // sql auth
                         serverKey.SetValue("Type", Convert.ToInt32(srv.credentials.useSqlAuthentication));

                         string loginName = "";
                         if ( ! String.IsNullOrEmpty( srv.credentials.loginName ) )
                            loginName = EncryptionHelper.QuickEncrypt( srv.credentials.loginName );
                         serverKey.SetValue("Param1", loginName);

                         string password = "";
                         if ( ! String.IsNullOrEmpty( srv.credentials.password ) )
                            password = EncryptionHelper.QuickEncrypt( srv.credentials.password );
                         serverKey.SetValue("Param2", password);
                      }
                      else
                      {
                         // windows authentication
                         serverKey.SetValue("Type", 0);
                      }
                      
                      serverKey.SetValue("Ignore", srv.ignore ? 1 : 0);
                  }
                  catch ( Exception ex )
                  {
                     CoreGlobals.traceLog.ErrorFormat( "Error reading monitored server list - {0}", ex.Message );
                  }
                  finally
                  {
                     if (serverKey != null)
                     {
                        serverKey.Close();
                        serverKey = null;
                     }
                  }
               }
            }

            // remove any servers from list that arent part of active processing anymore
            int i=0;
            while ( i<ProductConstants.monitoredServers.Count )
            {
               if ( ! ProductConstants.monitoredServers[i].partOfLastCheck )
               {
                  ProductConstants.monitoredServers.RemoveAt(i);
               }
               else
               {
                  i++;
               }
            }
         }
         catch ( Exception ex )
         {
            // probably only got here if we couldnt open registry keys
            CoreGlobals.traceLog.ErrorFormat( "WriteServerList error: {0}", ex.Message );
         }
         finally
         {
            if (toolsetKey != null) toolsetKey.Close();
            if (toolKey    != null) toolKey.Close();
            if (serversKey != null) serversKey.Close();
         }
      }

      // 0 = undefined
      // 1 = OK
      // 2 = Warning
      // 3 = Error      
      public static int
         GetOverallState()
      {
         int overallState = 0; 
         
         foreach ( MonitoredServer ms in ProductConstants.monitoredServers )
         {
            if ( ms.ignore || ! ms.partOfLastCheck ) continue;
            
            if ( ms.state == ServerState.OK && overallState <= 1)
            {
               overallState = 1;
            }
            else
            {
               overallState = 3;
               break;
            }
         }
         
         return overallState;
      }
      
      // 0 = no change
      // 1 = came online
      // 2 = went offline
      public static int
         GetAlertState(
            int ndx
         )
      {
         int alertState = 0; 
         
         if ( ( ProductConstants.monitoredServers[ndx].ignore )||
              ( ProductConstants.monitoredServers[ndx].state == ProductConstants.monitoredServers[ndx].lastState ) ||
              ( ProductConstants.monitoredServers[ndx].lastState == ServerState.FirstTime ) )
         {
            alertState = 0; // no alert
         }
         else
         {
            if ( ProductConstants.monitoredServers[ndx].state == ServerState.OK )
            {
               alertState= 1;
            }
            else
            {
               alertState= 2;
            }
         }    
         
         return alertState;
      }
      
   }
}
