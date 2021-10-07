using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.LoginCopy
{
   internal class ProductConstants
   {
      // Product Name
      public static string shortProductName = "LoginCopy";
      public static string productName = "Login Copy";
      public static string productDescription = "tagline for new tool - a one sentence description";

      // CommandLine Support
      public static bool supportsCommandLine = false;

      public static string usage = "Syntax:\r\n" +
                                   "    LoginCopy /arg1:value /arg2:value\r\n" +
                                   "Parameters:\r\n" +
                                   "    /arg1:value" +
                                   "    /arg2:value";
      // Resource Strings
      public static string MessageSelectInstructions = "Select the logins to copy to the destination SQL Server:";
      public static string MessageNoLoginsFound = "Destination SQL Server already contains all logins from source SQL Server.";
      
      public static string StatusPending = "Pending";
      public static string StatusSuccess = "Success";
      public static string StatusWarning = "Warning";
      public static string StatusNotRequested = "Not Requested";
      public static string StatusFailed = "Failed";
      
      public static string ProgressInitializing = "Initializing";

      public static string ErrorNoSourceSqlServer = "Specify a source SQL Server.";
      public static string ErrorNoDestinationSqlServer = "Specify a destination SQL Server.";
      public static string ErrorSourceInvalidCharacters = "You may only specify one source SQL Server.";
      public static string ErrorDestinationInvalidCharacters = "You may only specify one destination SQL Server.";
      public static string ErrorDatabaseMoveMustHaveDifferentDestination = "The destination SQL Server must be different than the source SQL Server.";
      public static string ErrorNotSupportedSqlCombination = "The requested SQL Server version combination is not supported.";
      public static string ErrorConnectionToServerFailed = "Failed to establish connection with {0}.";
      public static string ErrorMovingLoginsCaption = "Error copying logins";
      public static string ErrorOnlySql2000AndAboveSupported = "This tool only supports SQL 2000 and above";
      public static string ErrorConnectingToServer = "Error connecting to {0}\n";
      public static string ErrorDestinationServerDoesNotHaveAccessToSourceDomainLogin = "Domain user or group is not accessible by the destination server.";
      public static string ErrorLoginCannotBeCopied = "The destination SQL Server is not compatible with this login.";

      public const int MaximumNumberOfLogins = 300;
      public static string WarningTooManyLogins = "Due to a large number of logins available on the source SQL server, the time to process all available logins may take a long time.";
   }
}
