using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.DatabaseMover
{
    class ProductConstants
    {
        // Product Name
        public static string shortProductName = "DatabaseMover";
        public static string productName = "Database Mover";
        public static string productDescription = "Moves data files within a server or databases across servers";

        // CommandLine Support
        public static bool supportsCommandLine = false;

        public static string usage = "Syntax:\r\n" +
                                        "    DatabaseMover /arg1:value /arg2:value\r\n" +
                                        "Parameters:\r\n" +
                                        "    /arg1:value" +
                                        "    /arg2:value";


        // Resource Strings
        public const string PromptCancelOperation = "Are you sure that you want to cancel the current operation?";
        public const string PromptExitApplication = "Are you sure that you want to close {0}?";
        public const string PromptMustSpecifyDatabase = "You must specify a database.";
        public const string PromptMustSpecifyDatabaseCaption = "Missing database";
        public const string PromtMustSpecifyServerVersion = "Server Versions";
        public const string PromptSqlInstancesMustBeDifferent = "You must specify different SQL Server instances for the source and destination.";
        public const string PromptDatabaseDoesNotExist = "The specified database does not exist on the source server.";
        public const string PromptDatabaseNameNeeded = "You must specify a new database name.";
        public const string PromptDatabaseNameNeededCaption = "Rename database";
        public const string PromptAllSourceLoginsSyncronized = "All needed SQL Server logins already exist on the destination SQL Server.";
        public const string PromptMustSelectAtLeastOneLogin = "You must select at least one login to synchronize.";
        public const string PromptNewDataFileDirectory = "Please select the directory to which the database files should be moved.";
        public const string PromptUnableToReachAdminShare = "Unable to access {0} on {1}.  Please verify that you have access through the Admin share and try again.";
        public const string PromptAdminSharePathIsNotValid = "The destination path is not valid.";
        public const string PromptUnableToAccessNetworkFiles = "Unable to access network files needed for the requested operation.  Please verify that you have access and try again.";
        public const string PromptSelectedDestinationFolderNotOnDestinationNetworkShare = "The destination folder must be part of the destination server's network share.";
        public const string PromptSelectedDestinationNotSelected = "You must select a destination path.";
        public const string PromptDestinationDatabaseAlreadyExists = "Destination database already exists, please go back and enter a new name for it or choose the overwrite option.";
        public const string PromptMustSpecifySourceServer = "Source Server must be specified.";
        public const string PromptMustSpecifyDestinationServer = "Destination Server must be specified.";
        public const string PromptResetWizardValues = "Would you like to reset the wizard values before restarting?";
        public const string PromptDestinationFilesMustChange = "At least one file must be different in order to process the file move operation.";
        public const string PromptMustSpecifyDifferentDatabaseName = "New database name must be different than source database.";
        public const string PromptMustSpecifyDifferentDatabaseNameCaption = "Invalid database name.";

        public const string ErrorNotSupportedSqlCombination = "The requested SQL Server version combination is not supported.";
        public const string ErrorCannotLoadServerDatabases = "Error loading databases from the selected SQL Server";
        public const string ErrorCannotLoadServerDatabasesDetails = "Error: Unable to retrieve the list of available databases";
        public const string ErrorVersionNotSupported = "You are attempting to move a SQL Server Database on a higher version {0} to a lower version {1}.  Some capabilities available or functions, including the ability to start the database, may not be available once you move to the lower version. Do you want to Continue ?";
        public const string ErrorEditionNotMatch = "The requested SQL Server Edition combination, SourceServer:{0} and DestinationServer:{1} are not compatible.. Do you want to Continue ?";
        public const string ErrorIncompatibleServerDatabases = "Some databases on the selected SQL Server are at an unsupported compatibility level and will not be available for selection.";
        public const string ErrorDatabaseMoveMustHaveDifferentDestination = "Destination folder must be different that source.";
        public const string ErrorSpecifyDestinationFolder = "A destination folder must be specified.";
        public const string ErrorGridValidationValueIsEmpty = "Value cannot be empty";
        public const string ErrorGridValidationMissingExtenstion = "File name is missing extension";
        public const string ErrorGridValidationInvalidPath = "Invalid file path";
        public const string ErrorMustHaveDifferentSourceAndDestination = "The destination must be different than the source for this type of operation.";

        public const string SummaryAbortOnConflict = "Abort";
        public const string SummaryOverwriteOnConflict = "Overwrite";
        public const string SummaryTaskDatabaseMoveToOtherInstance = "Database Move - Different Instance";
        public const string SummaryTaskDatabaseMoveToOtherServer = "Database Move - Different Server";
        public const string SummaryTaskDatabaseCopyToOtherInstance = "Database Copy - Different Instance";
        public const string SummaryTaskDatabaseCopyToOtherServer = "Database Copy - Different Server";
        public const string SummaryTaskDataFileMove = "Move Database Files";
        public const string SummaryTaskCloneDatabase = "Database Copy - Same Instance";

        public const string ResultsSuccess = "Task Completed Successfully";
        public const string ResultsFailed = "Task Failed";

        public const string ServersLocal = "(local)";

        public const string CancelButtonExit = "Close";
        public const string CancelButtonCancel = "Cancel";
    }
}
