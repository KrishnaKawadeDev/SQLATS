using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.ObjectSearch
{
   class CommandLineHandler : ToolCommandLineHandler
   {
      // Properties (store during parsing)

      //--------------
      // Constructor
      //--------------
      public CommandLineHandler() { }

      //----------------------------------------------------------------------------
      // Run - validates arguments and runs command line operations
      //       if invalid arguments - return -1
      //----------------------------------------------------------------------------
      override public int
         Run(
            string[] args
         )
      {
         // Parse Command Line
         if ( ! ParseArguments( args ) )
         {
            return -1;
         }

         // Do the Commands
         DoWork();


         return 0;
      }

      //----------------------------------------------------------------------------
      // ParseArguments - Parses and validates command line arguments
      //
      //                  return value: true = valid, false = invalid (shows usage)
      //----------------------------------------------------------------------------
      override protected bool
         ParseArguments(
            string[] args
         )
      {
         // if we got here all is good
         return true;
      }

      //-----------------------------------------------------------------------------------
      // ShowUsage
      //
      /// <summary>
      /// ShowUsage - Show Command Line Help Text
      /// </summary>
      //-----------------------------------------------------------------------------------
      override protected void ShowUsage()
      {
         // common CLI banner
         base.ShowUsage();

         // usage for this tool
         Console.WriteLine( ProductConstants.usage );
         Console.WriteLine();
      }

      //----------------------------------------------------------------------------
      // DoWork - does the work for the command line - called after parsing and
      //          setting of property values 
      //----------------------------------------------------------------------------
      override protected void DoWork()
      {
      }
   }
}
