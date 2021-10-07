using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using BBS.TracerX;

namespace Idera.SqlAdminToolset.Core
{
   public delegate object InterfaceFactoryDelegate( bool useGUI );

   public static class ToolStartup
   {
      [DllImport( "kernel32.dll", SetLastError = true )]
      static extern bool AttachConsole( uint dwProcessId );
      const uint ATTACH_PARENT_PROCESS = 0x0ffffffff;

      //-----------------------------------------------------------------------
      // ToolMain
      //
      /// <summary>
      /// ToolMain - The common entry point logic for all tools
      /// </summary>
      //-----------------------------------------------------------------------
      public static int
         ToolMain(
            string[]                    args,
            string                      productName,
            string                      produtBanner,
            bool                        productSupportsCommandLine,
            InterfaceFactoryDelegate    interfaceFactory
         )
      {
         bool useGUI = true;
         bool showWelcomeScreen = true;
         int returnVal = 0;

         Logger.FileLogging.Open();
         Logger logLaunch = Logger.GetLogger( productName );
         logLaunch.InfoFormat( "Started {0} - Version: {1}",
                               productName,
                               System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() );


         using (logLaunch.InfoCall())
         {
            CoreGlobals.productName = productName; 

            // if no arguments then we are running the GUI with a welcome screen
            if ( args.Length == 0 )
            {
               showWelcomeScreen = true;
               useGUI = true;
            }
            else
            {
               // if we have command line arguments we are either running as a command line
               // or are running with the one arguemnt to suppress the welcome screen when
               // the product is started from the product launchpad

               // Check for special command line parameter to prevent welcome screen when launched from
               // launchpad since launchpad already shows the welcome screen
               if ( args.Length == 1 && args[0].ToUpper() == "/NOWELCOMESCREEN" )
               {
                  showWelcomeScreen = false;
                  useGUI = true;
               }
               else if ( productSupportsCommandLine )
               {
                  useGUI = false;
               }
            }

            try
            {
               if ( useGUI )
               {
                  logLaunch.Verbose( "Launching product GUI" );

                  //-----
                  // GUI 
                  //-----
                  CoreGlobals.showWelcomeScreen = showWelcomeScreen;

                  Form startupForm = (Form)interfaceFactory( true );
                  Application.Run( startupForm  );
               }
               else
               {
                  logLaunch.Verbose( "Launching product CLI" );

                  //--------------
                  // Command Line
                  //--------------
                  if ( !AttachConsole( ATTACH_PARENT_PROCESS ) )
                  {
                     // cant write this error to the console so launch a messagebox - not the friendliest 
                     Messaging.ShowError( "AttachConsole failed" );
                  }


                  ToolCommandLineHandler cli = (ToolCommandLineHandler)interfaceFactory( false );


                  returnVal = cli.Run( args );
                  if ( returnVal == -1 )
                  {
                     Application.Exit();
                  }
               }
            }
            catch( Exception ex )
            {
               string exMsg = Helpers.GetCombinedExceptionText(ex);

               logLaunch.FatalFormat( "Unhandled Exception in {0}\r\n{1}",
                                      productName,
                                      exMsg );
               if ( useGUI )
               {
                  Messaging.ShowException( "An Unhandled Exception occured.", ex );
               }
               else
               {
                  Console.WriteLine( "An Unhandled Exception occured." );
                  Console.WriteLine( Helpers.GetCombinedExceptionText(ex) );
               }
            }
            return returnVal;
         }
      }
   }
}