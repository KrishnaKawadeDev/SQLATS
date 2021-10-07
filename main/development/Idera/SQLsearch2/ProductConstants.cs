using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SqlSearch
{
    class ProductConstants
    {
        // Product Name
        public static string shortProductName   = "SQLsearch";
        public static string productName        = "SQL Search";
        public static string productDescription = "Search for text anywhere there is SQL code (stored procedures, functions, triggers etc)";

        // CommandLine Support
        public static bool supportsCommandLine = false;

       public static string usage = "Syntax:\r\n" +
                                       "    SQLsearch /text:<searchtext> /server:<name> [/database:<name>]\r\n" +
                                       "             [/matchcase] [/user:<login>] [/password:<password>]\r\n" +
                                       "Parameters:\r\n" +
                                       "    /text <text>      - Required: Search text\r\n" +
                                       "    /server <name>    - Required: SQL Server to search\r\n" +
                                       "    /database <name>  - Optional: Database to search. Omit this parameter\r\n" +
                                       "                                  to search all databases.\r\n" +
                                       "    /matchcase        - Optional: Does case sensitive search\r\n" +
                                       "    /user <name>      - Optional: Use to connect with SQL authentication\r\n" +
                                       "    /password <pwd>   - Optional: Use to connect with SQL authentication\r\n" +
                                       "                                  Leave /password off for blank password";


        // Strings
        public static string strAllDatabases = "<search all databases>";
        
        // Configurable Options
        public static string         lastServer      = "";
        public static string         lastDatabase    = "";
        public static string         lastSearch      = "";
        public static SQLCredentials lastCredentials = null;
        

        // Option Persistence
        public static void WriteOptions()
        {
            RegistryKey toolsetKey = null;
            RegistryKey productKey = null;

            try
            {
                toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
                productKey = toolsetKey.CreateSubKey(ProductConstants.shortProductName);
                
                productKey.SetValue("LastServer", lastServer);
                productKey.SetValue("LastDatabase", lastDatabase);
                productKey.SetValue("LastSearch", lastSearch);

                if ( lastCredentials != null && lastCredentials.useSqlAuthentication)
                {
                   // sql auth
                   productKey.SetValue("LastCT", 1);

                   string loginName = "";
                   if ( ! String.IsNullOrEmpty( lastCredentials.loginName ) )
                      loginName = EncryptionHelper.QuickEncrypt( lastCredentials.loginName );
                   productKey.SetValue("LastC1", loginName);

                   string password = "";
                   if ( ! String.IsNullOrEmpty( lastCredentials.password ) )
                      password = EncryptionHelper.QuickEncrypt( lastCredentials.password );
                   productKey.SetValue("LastC2", password);
                }
                else
                {
                   // windows authentication
                   productKey.SetValue("LastCT", 0);
                }
            }
            catch ( Exception ex )
            {
                CoreGlobals.traceLog.ErrorFormat( "WriteOptions error: {0}", ex.Message );
            }
            finally
            {
                if (toolsetKey != null) toolsetKey.Close();
                if (productKey != null) productKey.Close();
            }
        }

        public static void ReadOptions()
        {
            RegistryKey toolsetKey = null;
            RegistryKey productKey = null;

            try
            {
                toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
                productKey = toolsetKey.CreateSubKey(ProductConstants.shortProductName);
                
                // server
                lastServer   = (string)productKey.GetValue( "LastServer",   "(local)" );
                lastDatabase = (string)productKey.GetValue( "LastDatabase", "" );
                lastSearch   = (string)productKey.GetValue( "LastSearch",   "" );
                  
                // credentials
                lastCredentials  = new SQLCredentials();
                int    sql       = (int)productKey.GetValue( "LastCT", 0 );
                string loginName = (string)productKey.GetValue( "LastC1", "" );
                string password  = (string)productKey.GetValue( "LastC2", "" );

                if ( sql == 1 && loginName != "" )
                {
                   lastCredentials.useSqlAuthentication = true;
                   lastCredentials.loginName = EncryptionHelper.QuickDecrypt(loginName);

                   if ( String.IsNullOrEmpty(password) )
                      lastCredentials.password = "";
                   else
                      lastCredentials.password = EncryptionHelper.QuickDecrypt(password);
                }
                else
                {
                   lastCredentials.useSqlAuthentication = false;
                }

            }
            catch ( Exception ex )
            {
                CoreGlobals.traceLog.ErrorFormat( "ReadOptions error: {0}", ex.Message );
            }
            finally
            {
                if (toolsetKey != null) toolsetKey.Close();
                if (productKey != null) productKey.Close();
            }
        }
        
    }
}
