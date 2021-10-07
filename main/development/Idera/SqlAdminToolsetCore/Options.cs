using System;
using System.Collections.Generic;
using System.Text;
using BBS.TracerX;
using Microsoft.Win32;

namespace Idera.SqlAdminToolset.Core
{
   /// <summary>
   ///  The Options class contains global variables that are persistent across product runs
   /// </summary>
   public class Options
   {
      // Options - Registry Keys and Values
      public static string optionsRegistryKey = @"Software\Idera\SQLadminToolset";
      public static string optionsRegValue_ConnectionTimeout = "Connection Timeout";
      public static string optionsRegValue_CommandTimeout    = "Command Timeout";
      public static string optionsRegValue_CloseLaunchpad    = "Close Launchpad";

      // Options
      public static int connectionTimeout = 20;  // seconds
      public static int commandTimeout    = 60;  // seconds
      public static bool closeLaunchpad   = true;

      #region Persistence Functions

      //-------------
      // ReadOptions
      //-------------
      static public void
         ReadOptions()
      {
         RegistryKey rk = null;
         RegistryKey rks = null;

         try
         {
            rk = Registry.LocalMachine;
            rks = rk.CreateSubKey( Options.optionsRegistryKey );

            // connection timeout
            int connTimeout = (int)rks.GetValue( Options.optionsRegValue_ConnectionTimeout, "15" );
            if ( connTimeout < 15 ) connTimeout = 15;
            Options.connectionTimeout = connTimeout;

            // command timeout
            int cmdTimeout = (int)rks.GetValue( Options.optionsRegValue_CommandTimeout, "30" );
            if ( cmdTimeout < 10 ) cmdTimeout = 30;
            Options.commandTimeout = connTimeout;

            // close launchpad
            //object o = rks.GetValue( Options.optionsRegValue_CloseLaunchpad, "True" );
            //Options.closeLaunchpad = (bool)rks.GetValue( Options.optionsRegValue_CloseLaunchpad, "True" );
         }
         catch // ( Exception ex )
         {
            //logX.ErrorFormat( "ReadOptions error: {0}", ex.Message );
         }
         finally
         {
            if ( rks != null ) rks.Close();
            if ( rk != null ) rk.Close();
         }
      }

      //--------------
      // WriteOptions
      //--------------
      static public void
        WriteOptions()
      {
         RegistryKey rk = null;
         RegistryKey rks = null;

         try
         {
            rk = Registry.LocalMachine;
            rks = rk.CreateSubKey( Options.optionsRegistryKey );

            rks.SetValue( Options.optionsRegValue_ConnectionTimeout, Options.connectionTimeout );
            rks.SetValue( Options.optionsRegValue_CommandTimeout, Options.commandTimeout );
            rks.SetValue( Options.optionsRegValue_CloseLaunchpad, Options.closeLaunchpad );
         }
         catch // ( Exception ex )
         {
            //logX.ErrorFormat( "WriteOptions error: {0}", ex.Message );
         }
         finally
         {
            if ( rks != null ) rks.Close();
            if ( rk != null ) rk.Close();
         }
      }

      #endregion
   }
}
