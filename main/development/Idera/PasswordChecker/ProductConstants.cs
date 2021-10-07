using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.PasswordChecker
{
   class ProductConstants
   {
      // Product Name
      public static string shortProductName = "PasswordChecker";
      public static string productName = "Password Checker";
      public static string productDescription = "tagline for new tool - a one sentence description";

      // CommandLine Support
      public static bool supportsCommandLine = false;

      public static string usage = "Syntax:\r\n" +
                                   "    PasswordChecker /arg1:value /arg2:value\r\n" +
                                   "Parameters:\r\n" +
                                   "    /arg1:value" +
                                   "    /arg2:value";
      
      // Resource Strings
      public static string PasswordListTop10 = "Top 10 List (plus Blank)";
      public static string PasswordListNifty50 = "Nifty Fifty";
      public static string PasswordList800 = "800 Common Passwords";
      public static string PasswordListComprehensive = "The Big List (2400+ Passwords)";
      public static string PasswordListCustom = "<Custom Password List>";
      public static char roleSeparator = ';';
      public static string PasswordSameAsLoginName = "<UserName>";
      public static string PasswordSameAsLoginNameReverse = ">emaNresU<";

      public static string labelCaptionServersChecked = "SQL Servers checked";
      public static string labelCaptionServerRolesChecked = "Fixed Server Roles checked";
      public static string labelCaptionDatabaseRolesChecked = "Fixed Database Roles checked";
      public static string labelCaptionUsersChecked = "Logins checked";
      public static string labelCaptionPasswordsAttempted = "Connections attempted";
      public static string labelCaptionPasswordsFailed = "Bad Passwords Found";
      
      public static string labelCaptionFailedServerConnection = "Failed server connections";

      public static string StatusCaptionStartingThreads = "Checking passwords against requested servers";
      public static string StatusCaptionInitializing = "Initializing";
      public static string StatusCaptionCompletedTask = "{0} - {1}";
      public static string StatusCaptionCancelingRequest = "Cancelling request";

      public static string ErrorInvalidDelimitedValue = "Please enter a correct value for {0}";

      public static string FileDialogTitle = "Select a password file";
      public static string BlankPassword = "<Blank Password>";

      public static string HideSuccessfulUsers = "&Show logins with found passwords only";

      public static string CommandLineServerArgumentName = "/SERVER:";
      public static string CommandLineServers = string.Empty;

      public static string ErrorConnectionError = "Connection Error";
      public static string ErrorCannotAccessUsers = "Can't Access Server";
      public static string ErrorCannotAccessUsersDescription = "Your credentials don't have access to test logins on the server. Please specify credentials with enough access and try again.";
      public static string ErrorCanceledOperation = "Operation Canceled.";
      public static string ErrorMustBeSysAdmin = "You don't have enough permissions to check for valid passwords.";
      
      public static char   PasswordMaskCharacter = '*';
      public static string PasswordMask          = "*****";
      public static string PasswordMaskRegistryValue = "MaskPassword";

      public static int MaximumWordPlusNumberTotal = 20000;
     
      public static string WarningPasswordVariations = "Warning: You have selected the option to test for common variations of the selected passwords.  " +
                                                       "Please note that enabling this option will add up to 20000 variations for each password part of the " +
                                                       "selected list.  Due to the increased number of tests that this option will generate, testing for common " +
                                                       "variations of a long password list against a lot of servers will take a long time to run. \n\n" +
                                                       "Would you like to continue?";
   }
}
