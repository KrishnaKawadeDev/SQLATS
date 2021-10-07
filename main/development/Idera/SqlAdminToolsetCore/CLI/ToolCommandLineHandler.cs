using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Idera.SqlAdminToolset.Core
{
   public class ToolCommandLineHandler
   {
      // Properties (store during parsing)
      public ToolCommandLineHandler()
      {
      }

      //----------------------------------------------------------------------------
      // Run - validates arguments and runs command line operations
      //       if invalid arguments - return -1
      //----------------------------------------------------------------------------
      public virtual int Run( string[] args )
      {
         return 0;
      }

      //----------------------------------------------------------------------------
      // ParseArguments - Parses and validates command line arguments
      //
      //                  return value: true = valid, false = invalid (shows usage)
      //----------------------------------------------------------------------------
      protected virtual bool
         ParseArguments(
            string[] args
         )
      {
         return true;
      }

      //----------------------------------------------------------------------------
      // DoWork - does the work for the command line - called after parsing and
      //          setting of property values 
      //----------------------------------------------------------------------------
      protected virtual void DoWork()
      {
      }

      //-----------------------------------------------------------------------------------
      // ShowUsage
      //
      /// <summary>
      /// ShowUsage - Show Command Line Help Text
      /// </summary>
      //-----------------------------------------------------------------------------------
      protected virtual void ShowUsage()
      {
         Console.WriteLine( CoreGlobals.cliBanner,
                            CoreGlobals.productName,
                            Assembly.GetExecutingAssembly().GetName().Version );
         Console.WriteLine();
      }
   }
}
