using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BBS.TracerX;
using Microsoft.Win32;
using System.Configuration;

namespace Idera.SqlAdminToolset.Core
{
   /// <summary>
   ///  The Options class contains global variables that are persistent across product runs
   /// </summary>
   public class ToolsetOptions
   {
      // Options - Registry Keys and Values
      public static RegistryKey optionsRootKey                  = Registry.LocalMachine;  // if user is not local admin, we change this to current user at startup
      public static string optionsRegistryKey                   = @"Software\Idera\SQLadminToolset";
      public static string optionsRegValue_ConnectionTimeout    = "Connection Timeout";
      public static string optionsRegValue_CommandTimeout       = "Command Timeout";
      public static string optionsRegValue_CloseLaunchpad       = "Close Launchpad";
      public static string optionsRegValue_FirstTimeLaunchpad   = "First Time Launchpad";
      public static string optionsRegValue_MruLastSelectionType = "MruLastSelectionType";
      public static string optionsRegValue_MruServer            = "MruServer";
      public static string optionsRegValue_MruServerCount       = "MruServerCount";
      public static string optionsRegValue_MruGroup             = "MruGroup";
      public static string optionsRegValue_MruGroupCount        = "MruGroupCount";

      // Options
      public static int  connectionTimeout  = 20;  // seconds
      public static int  commandTimeout     = 300;  // seconds
      public static bool closeLaunchpad     = true;
      public static bool firstTimeLaunchpad = true;
      
      // server selection MRU - keep last 5 selected servers and server groups
      public static DateTime         mruLoadTime;
      public static int              mruMax               = 5;
      public static int              mruLastSelectionType = 0;
      public static int              mruServerCount       = 0;
      public static string[]         mruServers           = new string[mruMax];
      public static SQLCredentials[] mruServerCredentials = new SQLCredentials[mruMax];
      public static int              mruGroupCount        = 0;
      public static string[]         mruGroups            = new string[mruMax];

      #region Registry Persistence Functions

      //-------------
      // ReadOptions
      //-------------
      static public void
         ReadOptions()
      {
         RegistryKey rks = null;

         try
         {
            rks = optionsRootKey.CreateSubKey( ToolsetOptions.optionsRegistryKey );

            // connection timeout
            int connTimeout = (int)rks.GetValue( ToolsetOptions.optionsRegValue_ConnectionTimeout, 20 );
            if ( connTimeout < 0 ) connTimeout = 20;
            ToolsetOptions.connectionTimeout = connTimeout;

            // command timeout
            int cmdTimeout = (int)rks.GetValue( ToolsetOptions.optionsRegValue_CommandTimeout, 300 );
            if ( cmdTimeout < 0 ) cmdTimeout = 300;
            ToolsetOptions.commandTimeout = cmdTimeout;

            // first time launchpad
            string ftl = (string)rks.GetValue( ToolsetOptions.optionsRegValue_FirstTimeLaunchpad, "True" );
            ToolsetOptions.firstTimeLaunchpad = (ftl=="True") ? true : false;

            // close launchpad
            string cl = (string)rks.GetValue( ToolsetOptions.optionsRegValue_CloseLaunchpad, "True" );
            ToolsetOptions.closeLaunchpad = (cl=="True") ? true : false;

            // mru
            mruLoadTime = DateTime.Now;
            
            int lastType = (int)rks.GetValue( ToolsetOptions.optionsRegValue_MruLastSelectionType, 0 );
            ToolsetOptions.mruLastSelectionType = ( lastType == 0 ) ? 0 : 1;
            
            // read server mru
            int i,j;
            for ( i=0,j=0;i<ToolsetOptions.mruMax; i++ )
            {
               string srv = (string)rks.GetValue(ToolsetOptions.optionsRegValue_MruServer+i.ToString(),"" );
               if ( ! String.IsNullOrEmpty(srv) ) 
               {
                  try
                  {
                     MRU.DecryptServer( srv,
                                        out ToolsetOptions.mruServers[j],
                                        out ToolsetOptions.mruServerCredentials[j] );
                     j++;
                  }
                  catch
                  {
                     break;
                  }
               }
               else
               {
                  break;
               }
            }
            
            if ( j == 0 )  // no servers - lets pre-populate MRU with (local)
            {
               ToolsetOptions.mruServers[j]           = "(local)";
               ToolsetOptions.mruServerCredentials[j] = null;
               j++;
            }
            
            ToolsetOptions.mruServerCount = j;

            // read group mru
            for ( i=0,j=0;i<ToolsetOptions.mruMax; i++ )
            {
               string grp = (string)rks.GetValue(ToolsetOptions.optionsRegValue_MruGroup+i.ToString(),"" );
               if ( !  String.IsNullOrEmpty(grp) ) 
               {
                  try
                  {
                     ToolsetOptions.mruGroups[j] = MRU.DecryptGroup( grp );
                     j++;
                  }
                  catch
                  {
                     break;
                  }
               }
               else
               {
                  break;
               }
            }
            ToolsetOptions.mruGroupCount = j;
         }
         catch ( Exception ex )
         {
            CoreGlobals.traceLog.ErrorFormat( "ToolsetOptions.ReadOptions error: {0}", ex.Message );
         }
         finally
         {
            if ( rks != null ) rks.Close();
         }
      }

      //--------------
      // WriteOptions
      //--------------
      static public void
         WriteOptions()
      {
         RegistryKey rks = null;

         try
         {
            rks = optionsRootKey.CreateSubKey( ToolsetOptions.optionsRegistryKey );

            rks.SetValue( ToolsetOptions.optionsRegValue_ConnectionTimeout,  ToolsetOptions.connectionTimeout );
            rks.SetValue( ToolsetOptions.optionsRegValue_CommandTimeout,     ToolsetOptions.commandTimeout );
            rks.SetValue( ToolsetOptions.optionsRegValue_FirstTimeLaunchpad, ToolsetOptions.firstTimeLaunchpad );
            rks.SetValue( ToolsetOptions.optionsRegValue_CloseLaunchpad,     ToolsetOptions.closeLaunchpad );

            rks.SetValue( ToolsetOptions.optionsRegValue_MruLastSelectionType, ToolsetOptions.mruLastSelectionType);
            
            // write mru servers
            for ( int i=0; i<ToolsetOptions.mruServerCount;i++)
            {
               rks.SetValue( ToolsetOptions.optionsRegValue_MruServer + i.ToString(),
                             MRU.EncryptServer(i) );
            }

            // write mru groups
            for ( int g=0; g<ToolsetOptions.mruGroupCount; g++)
            {
               rks.SetValue( ToolsetOptions.optionsRegValue_MruGroup + g.ToString(),
                             MRU.EncryptGroup(g) );
            }
         }
         catch ( Exception ex )
         {
            CoreGlobals.traceLog.ErrorFormat( "ToolsetOptions.WriteOptions error: {0}", ex.Message );
         }
         finally
         {
            if ( rks != null ) rks.Close();
         }
      }
      
      #endregion

      #region Reading/Writing from on disk config file
/*            

      /// <summary>
      /// Reads options from the config file.
      /// </summary>
      static public void
         ReadOptionsFromConfig()
      {
         try
         {
            System.Configuration.Configuration _Configuration = ConfigurationManager.OpenExeConfiguration( ToolsetOptions.GetOptionsFile() );
         
            // connection timeout
            int connectionTimeout = GetIntegerFromConfig( _Configuration, "ConnectionTimeout", 15, 15, Int32.MaxValue );
            //ToolsetOptions.commandTimeout    = GetIntegerFromConfig( ToolsetOptions.optionsRegValue_CommandTimeout,    30, 15, Int32.MaxValue );
            //ToolsetOptions.closeLaunchpad    = GetBoolFromConfig( ToolsetOptions.optionsRegValue_CloseLaunchpad,       true );
         }
         catch // ( Exception ex )
         {
            //logX.ErrorFormat( "ReadOptions error: {0}", ex.Message );
         }
      }
      
      static private int
         GetIntegerFromConfig(
            System.Configuration.Configuration  _Configuration,
            string                              optionName,
            int                                 defaultValue,
            int                                 minValue,
            int                                 maxValue
         )
      {
         // connection timeout
         string _Value = _Configuration.AppSettings.Settings[optionName].Value;
         int returnValue;
         if (!int.TryParse(_Value, out returnValue))
         {
            returnValue = defaultValue;
         }
         
         if ( minValue != Int32.MinValue )
         {
            if ( returnValue < minValue ) returnValue = minValue;
         }
         
         if ( maxValue != Int32.MaxValue )
         {
            if ( returnValue > maxValue ) returnValue = maxValue;
         }
         
         return returnValue;
      }

      static private bool GetBoolFromConfig( string optionName, bool defaultValue )
      {
         // connection timeout
         string _Value = ConfigurationManager.AppSettings[optionName];

         bool returnValue;
         if (!bool.TryParse(_Value, out returnValue))
         {
            returnValue = defaultValue;
         }
         
         return returnValue;
      }

      
      /// <summary>
      /// Write options to the config file.
      /// </summary>
      static public void
        WriteOptionsToConfig()
      {
         try
         {
            System.Configuration.Configuration _Configuration = ConfigurationManager.OpenExeConfiguration( OpenExeConfiguration( ToolsetOptions.GetOptionsFile() );

            if ( _Configuration.AppSettings.Settings["ConnectionTimeout"] == null)
            {
               _Configuration.AppSettings.Settings.Add("ConnectionTimeout", "3456");
            }
            else
            {
               _Configuration.AppSettings.Settings["ConnectionTimeout"].Value = "6789";
            }

            if (_Configuration.AppSettings.Settings["ConnectionTimeout"] == null)
            {
               _Configuration.AppSettings.Settings.Add("ConnectionTimeout", ToolsetOptions.connectionTimeout.ToString());
            }
            else
            {
               _Configuration.AppSettings.Settings["ConnectionTimeout"].Value = ToolsetOptions.connectionTimeout.ToString();
            }


            if (_Configuration.AppSettings.Settings[ToolsetOptions.optionsRegValue_CommandTimeout] == null)
            {
               _Configuration.AppSettings.Settings.Add(ToolsetOptions.optionsRegValue_CommandTimeout, ToolsetOptions.commandTimeout.ToString());
            }
            else
            {
               _Configuration.AppSettings.Settings[ToolsetOptions.optionsRegValue_CommandTimeout].Value = ToolsetOptions.commandTimeout.ToString();
            }

            if (_Configuration.AppSettings.Settings[ToolsetOptions.optionsRegValue_CloseLaunchpad] == null)
            {
               _Configuration.AppSettings.Settings.Add(ToolsetOptions.optionsRegValue_CloseLaunchpad, ToolsetOptions.closeLaunchpad.ToString());
            }
            else
            {
               _Configuration.AppSettings.Settings[ToolsetOptions.optionsRegValue_CloseLaunchpad].Value = ToolsetOptions.closeLaunchpad.ToString();
            }
            _Configuration.Save(); //(ConfigurationSaveMode.Full);
         }
         catch ( Exception ex )
         {
            //logX.ErrorFormat( "WriteOptions error: {0}", ex.Message );
         }
      }
      
      static private string GetOptionsFile()
      {
         return Path.Combine( Helpers.GetSuiteDirectory(true), "SqlAdminToolsetOptions.config" );
      }

*/ 

      #endregion
   }
}
