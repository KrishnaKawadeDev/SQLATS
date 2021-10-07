using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.PasswordChecker
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
      static int
         Main(
            string[] args
         )
      {
         foreach (string _ArgValue in args)
         {
            if (_ArgValue != null && _ArgValue.StartsWith(ProductConstants.CommandLineServerArgumentName))
            {
               ProductConstants.CommandLineServers = _ArgValue.Substring(ProductConstants.CommandLineServerArgumentName.Length);
               break;
            }
         }

         int retval = 0;
         
         retval = Core.ToolStartup.ToolMain(args,
                                             ProductConstants.productName,
                                             ProductConstants.productDescription,
                                             ProductConstants.shortProductName,
                                             ProductConstants.supportsCommandLine,
                                             InterfaceFactory);
         return retval;
      }

      //--------------------------------------------
      // Class Factories for GUI and CLI interfaces
      //--------------------------------------------
      static public object InterfaceFactory(bool useGUI)
      {
         object userInterface = null;

         if (useGUI)
         {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
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
