using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.IndexAnalyzer
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
        public override int
           Run(
              string[] args
           )
        {
            // Parse Command Line
            if (!ParseArguments(args))
            {
                ShowUsage();
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
        protected override bool
           ParseArguments(
              string[] args
           )
        {
            //string cmd;
            //string value;

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
        protected override void DoWork()
        {
            // Do the actual work from the command line here

            // output command line results
            Console.WriteLine("results");
        }

        //-----------------------------------------------------------------------------------
        // ShowUsage
        //
        /// <summary>
        /// ShowUsage - Show Command Line Help Text
        /// </summary>
        //-----------------------------------------------------------------------------------
        protected override void ShowUsage()
        {
            // common CLI banner
            base.ShowUsage();

            // usage for this tool
            Console.WriteLine(ProductConstants.usage);
            Console.WriteLine();
        }

    }
}
