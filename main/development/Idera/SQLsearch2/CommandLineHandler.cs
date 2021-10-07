using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SqlSearch
{
   class CommandLineHandler : ToolCommandLineHandler
   {
      // Properties (store during parsing)

      //--------------
      // Constructor
      //--------------
      public CommandLineHandler() { }

      // Properties
      public string m_server         = null;
      public string m_database       = null;
      public string m_searchText     = null;
      public string m_loginName      = null;
      public string m_password       = null;
      public bool   m_matchCase      = false;
      public bool   m_allowWildcards = false;
      public bool   m_includeSystem  = false;

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
         string cmd;
         string value;
 
         foreach (string arg in args )
         {
            if ( arg[0] != '/' ) return false;

            int pos = arg.IndexOf(':');
            if ( pos == -1 )
            {
               cmd = arg.Substring(1);
               value = null;
            }
            else
            {
               cmd   = arg.Substring( 1,pos-1 ).ToUpper();
               value = arg.Substring( pos+1 );
            }

            switch (cmd )
            {
               case "SERVER":
                  if ( value == null ) return false;
                  m_server = value;
                  break;
               case "DATABASE":
                  if ( value == null ) return false;
                  m_database = value;
                  break;
               case "TEXT":
                  if ( value == null ) return false;
                  m_searchText = value;
                  break;
               case "USER":
                  if ( value == null ) return false;
                  m_loginName = value;
                  break;
               case "PASSWORD":
                  if ( value == null ) return false;
                  m_password = value;
                  break;
               case "MATCHCASE":
                  m_matchCase = true;
                  break;
               case "USEWILDCARDS":
                  m_allowWildcards = true;
                  break;
               case "INCLUDESYSTEM":
                  m_includeSystem = true;
                  break;
               default:
                  return false;
            }
         }

         // required fields
         if ( m_server == null ) return false;
         if ( m_searchText == null ) return false;
         if ( m_password != null && m_loginName == null ) return false;

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
          SQLCredentials sqlCredentials = null;
          if ( m_loginName != null )
          {
             sqlCredentials = new SQLCredentials( true, m_loginName, m_password );
          }
          
          ICollection results = null; //SqlSearchHelper.PerformSearch( m_server,
                                        //                       sqlCredentials,
                                          //                     m_database,
                                            //                   m_searchText,
                                              //                 true,
                                                //               true,
                                                  //             true,
                                                    //           true,
                                                      //         m_matchCase,
                                                        //       m_allowWildcards,
                                                          //     false,   // no limit on results
                                                            //   null,
                                                              // m_includeSystem );
          if ( results == null )
          {
             Console.WriteLine ( "No matches found" );
          }
          else
          {
              foreach (SqlSearchResult r in results)
              {
                 Console.WriteLine( "{3}, {0}.{1}.{2}",
                                    r.database,
                                    r.schema,
                                    r.name,
                                    r.GetObjectType() );
              }
          }
      }
   }
}
