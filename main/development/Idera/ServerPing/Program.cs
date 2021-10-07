using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.ServerPing
{
   static class Program
   {
     [DllImport("user32.dll")]
     private static extern int GetForegroundWindow();         

     [DllImport("User32.dll")]
     public static extern int ShowWindowAsync(IntPtr hWnd , int swCommand);

     [DllImport("user32.dll")] 
     public static extern uint RegisterWindowMessage(string lpString);

     [return: MarshalAs(UnmanagedType.Bool)]
     [DllImport("user32.dll", SetLastError = true)]
     static extern bool PostMessage(HandleRef hRef, uint Msg, IntPtr wParam, IntPtr lParam);

     public static uint startHealthCheckPrivateMessage;
     public static HandleRef HWND_BROADCAST = new HandleRef(startHealthCheckPrivateMessage, (IntPtr)0xFFFF);

     enum ShowWindowConstants
     {
        SW_HIDE = 0,
        SW_SHOWNORMAL = 1,
        SW_NORMAL = 1,
        SW_SHOWMINIMIZED = 2,
        SW_SHOWMAXIMIZED = 3,
        SW_MAXIMIZE = 3,
        SW_SHOWNOACTIVATE = 4,
        SW_SHOW = 5,
        SW_MINIMIZE = 6,
        SW_SHOWMINNOACTIVE = 7,
        SW_SHOWNA = 8,
        SW_RESTORE = 9,
        SW_SHOWDEFAULT = 10,
        SW_FORCEMINIMIZE = 11,
        SW_MAX = 11
     }
   
      //-----------------------------------------------------------------------
      // Main
      //
      /// <summary>
      /// Main - The main entry point for the application.
      /// </summary>
      //-----------------------------------------------------------------------
      [STAThread]
      static int
         Main(
            string[] args
         )
      {
         int retval = 0;

          startHealthCheckPrivateMessage = RegisterWindowMessage(CoreGlobals.registerHealthCheckMessage);
         
         // check for already running process - if there is one, abort and bring the other one up
         Process c = Process.GetCurrentProcess();
         foreach (Process p in Process.GetProcessesByName(c.ProcessName))
         {
             if (p.Id != c.Id && p.SessionId == c.SessionId)
             {
                 if (p.MainModule.FileName.ToLower().Equals(c.MainModule.FileName.ToLower()))
                 {
                     PostMessage(HWND_BROADCAST, startHealthCheckPrivateMessage, IntPtr.Zero, IntPtr.Zero);
                     Mutex mut = new Mutex(true, CoreGlobals.showHealthCheckMutex);
                     for (int x = 0; x < 100; x++)
                     {
                         try
                         {
                             Mutex done = Mutex.OpenExisting(CoreGlobals.gotShowHealthCheckMutex);
                             done.Close();
                             break;
                         }
                         catch (Exception)
                         {
                             Thread.Sleep(100);
                         }
                     }
                     mut.Close();
                     mut = null;
                     return 0;
                 }
             }
         } 
        

         // start in system tray?         
         foreach (string arg in args )
         {
            if ( arg.ToUpper() == "/SYSTEMTRAY" )
            {
               ProductConstants.StartInSystemTray = true;
            }
            
            if ( arg.ToUpper() == "/UNINSTALL" )
            {
               ProductConstants.Uninstall = true;
               Form_Main.KillStartupEntry( "IderaServerCheck" );
               Form_Main.KillStartupEntry( "IderaServerPing" );
               return 0; // just close
            }
            
         }

         retval = Core.ToolStartup.ToolMain( args,
                                             ProductConstants.productName,
                                             ProductConstants.productDescription,
                                             ProductConstants.shortProductName,
                                             ProductConstants.supportsCommandLine,
                                             InterfaceFactory );
         return retval;
      }

      //--------------------------------------------
      // Class Factories for GUI and CLI interfaces
      //--------------------------------------------
      static public object InterfaceFactory( bool useGUI )
      {
         object userInterface = null;

         if ( useGUI )
         {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            userInterface = new Form_Main();
         }
         else
         {
            userInterface = new CommandLineHandler();
         }
         return userInterface;
      }
   }
}
