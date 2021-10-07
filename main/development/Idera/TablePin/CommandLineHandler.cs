using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.TablePin
{
   class CommandLineHandler
   {
      // Properties (store during parsing)

      //----------------------------------------------------------------------------
      // Run - validates arguments and runs command line operations
      //       if invalid arguments - return -1
      //----------------------------------------------------------------------------
      public static int
         Run(
            string[] args
         )
      {
         // Parse Command Line
         if ( !ParseArguments( args ) )
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
      private static bool
         ParseArguments(
            string[] args
         )
      {
         // walk arguments - parse and validate
         //foreach (string arg in args )
         //{
         //}

         // validate that required fields have been passed
         // if ( m_server == null ) return false;

         // if we got here all is good
         return true;
      }

      //----------------------------------------------------------------------------
      // DoWork - does the work for the command line - called after parsing and
      //          setting of property values 
      //----------------------------------------------------------------------------
      private static void DoWork()
      {
         // Do the actual work from the command line here

         // output command line results
         Console.WriteLine( "results" );
      }
   }
}
