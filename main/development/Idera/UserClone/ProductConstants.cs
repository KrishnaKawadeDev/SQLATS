using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.UserClone
{
    class ProductConstants
    {
        // Product Name
        public static string shortProductName = "UserClone";
        public static string productName = "User Clone";
        public static string productDescription = "Create a new user with the same permissions as an existing user";

        // CommandLine Support
        public static bool supportsCommandLine = false;

        public static string usage = "Syntax:\r\n" +
                                     "    UserClone /arg1:value /arg2:value\r\n" +
                                     "Parameters:\r\n" +
                                     "    /arg1:value" +
                                     "    /arg2:value";
        // Resource Strings

        public static string FileDialogTitle = "Save Script As";
        public static string FileDialogFilter = "SQL files (*.sql)|*.sql|All Files (*.*)|*.*";

        public static string ErrorMustEnterSourceServer = "You must enter a source server";
        public static string ErrorCanOnlyEnterOneServer = "You can only enter one SQL Server";
        public static string ErrorMustEnterSourceUser = "You must enter a source user";
        public static string ErrorPasswordMustMatch = "Password and Password confirmation fields must match";
        public static string ErrorMustEnterDestinationServer = "You must enter a destination server";
        public static string ErrorVersionNotSupported = "The version of the destination server is not supported";
        public static string ErrorPreviewCaption = "Preview Clone Script";
        public static string ErrorDatabaseNotFoundAtDestination =
           "Database not found on destination. This should be corrected by one of the folowing:\r\n" +
           "(1) If this database is the default database of the new user, switch to a database\r\n" +
           "    that exists on the destination SQL Server.\r\n " +
           "(2) Remove the database from the list of databases whose access is being copied by\r\n" +
           "    clicking on 'Select Databases'.\r\n" +
           "(3) Exclude cloning of the user's database access to stop all database permissions\r\n" +
           "    from being copied.";
        public static string ErrorVersionCombinationNotSupported = "The requested SQL Server version combination is not supported";
        public static string ErrorUnableToDetermineObjectLevelPermissions = "---------------Unable to determine object permissions for {0}---------------";
        public static string ErrorUnableToConnectToSourceDatabase = "User permissions were not determined on the following databases:";
        public static string ErrorUserAlreadyExistsAtDestination = "User already exists at the destination";
        public static string ErrorSourceAndDestinationUserMustBeDifferent = "Source and Destination user must be different when cloning to the same server.";
        public static string ErrorLoginExistsAtDestination = "The specified login already exists at the destination, the requested operation cannot complete.";
        public static string ErrorLoginExistsAtDestinationNewMsg(string userCloneName)
        {
            return "The specified login  " + userCloneName.Remove(userCloneName.Length - 2) + "  already exists at the destination, the requested operation cannot complete.";
        }

        public static string StatusInitializing = "Initializing";
        public static string StatusCloneComplete = "Clone complete!";
        public static string StatusCloneCompleteNewMsg(string userName)
        {
            return " " + userName.Remove(userName.Length - 2) + "  Clone complete!";
        }
        public static string StatusCloneCompleteWithIssues = "Clone complete with the following issues: \n\n";

        public static string CaptionDatabaseInaccessible = "Database is Inaccessible";
        public static string CaptionDatabaseCompatibilityNotSupported = "Compatibility Level Not Supported: ";

        public static string ConfirmationSql2000BlankPassword = "You cannot keep the original password when downgrading to SQL 2000, do you want to proceed with a blank password?";
        public static string ConfirmationSql2012BlankPassword = "You cannot keep the original password when downgrading from SQL 2012, do you want to proceed with a blank password?";
        public static string ConfirmationSql2014BlankPassword = "You cannot keep the original password when downgrading from SQL 2014, do you want to proceed with a blank password?";
        public static string ConfirmationSql2016BlankPassword = "You cannot keep the original password when downgrading from SQL 2016, do you want to proceed with a blank password?";
        public static string ConfirmationSql2017BlankPassword = "You cannot keep the original password when downgrading from SQL 2017, do you want to proceed with a blank password?";
        public static string ConfirmationSql2019BlankPassword = "You cannot keep the original password when downgrading from SQL 2019, do you want to proceed with a blank password?";
        public static string WarningSchemaOwnershipWillChange = "This option will transfer any existing schema ownership to the new user";


        public static string ConfirmationSqlVersionBlankPassword(string ServerName)
        {
            return "You cannot keep the original password when downgrading from " + ServerName + ", do you want to proceed with a blank password?";
        }

        public const string RegistryValueLastServerUsed = "LastServerUsed";
        public const string RegistryValueLastLoginUsed = "LastLoginUsed";

    }
}
