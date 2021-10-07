using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Idera.SqlAdminToolset.Core;


namespace Idera.SqlAdminToolset.Launchpad
{
   static class Program
   {
      //-----------------------------------------------------------------------
      // Main
      //
      /// <summary>
      /// Main - The main entry point for the application.
      /// </summary>
      //-----------------------------------------------------------------------
      [STAThread]
      static int Main(string[] args)
      {
         int retval = 0;

         // check if launchpad already running an dif it is - bring it to the foreground
         if (AppIsAlreadyRunning()) 
         { 
            Application.Exit(); 
         } 
         else
         {
            retval = Core.ToolStartup.ToolMain( args,
                                                ProductConstants.productName,
                                                ProductConstants.productDescription,
                                                ProductConstants.shortProductName,
                                                ProductConstants.supportsCommandLine,
                                                InterfaceFactory );
         }
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

      //-------------------------------------------------------------------------------
      // AppIsAlreadyRunning - if launchpad already running bring it to the foreground
      //-------------------------------------------------------------------------------
      [DllImport("user32.dll", EntryPoint="SetForegroundWindow")] 
      static extern IntPtr SetForegroundWindow(IntPtr hWnd); 

      [DllImport("user32.dll", EntryPoint="ShowWindow")]
      static extern IntPtr ShowWindow(IntPtr hwnd, int nCmdShow);

      public const int SW_SHOWNORMAL=1;

      static private bool AppIsAlreadyRunning() 
      { 
         Process c = Process.GetCurrentProcess(); 
         foreach (Process p in Process.GetProcessesByName(c.ProcessName)) 
         { 
            if (p.Id != c.Id && p.SessionId == c.SessionId) 
            { 
               // MessageBox.Show( "p: " + p.MainModule.FileName + " - c: " + c.MainModule.FileName );

               if (p.MainModule.FileName.ToLower().Equals(c.MainModule.FileName.ToLower())) 
               { 
                  ShowWindow(p.MainWindowHandle,SW_SHOWNORMAL);
                  SetForegroundWindow(p.MainWindowHandle); 
                  return true; 
               } 
            } 
         } 
         return false; 
      } 
 
   }
}