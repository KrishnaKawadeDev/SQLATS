using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.DatabaseMoverLibrary
{
    public class ProductConstants
    {
       public const string StatusGatheringData = "Gathering Data";
       public const string StatusSynchronizingSecurityLogins = "Synchronizing security logins";
       public const string StatusSynchronizingSecurityLoginsRolePermissionError = "You must have access to a Server Role in order to add users to it.  Not all Server Roles were synchronized on the destination server.";
       public const string StatusTransferingLogin = "\tCreating script for login: {0}";
       public const string StatusTransferingLoginExecuteScript = "\tExecuting transfer login script";
       public const string StatusDetachingDatabase = "Detaching database {0} from {1}";
       public const string StatusDetachedDatabase = "Detached database {0} from {1}";
       public const string StatusCopyingDatabaseFiles = "Copying database files";
       public const string StatusCopyingFromTo = "\tCopying from {0} to {1}";
       public const string StatusCopyConflict = "\tDestination file exists, file name changed to {0}";
       public const string StatusAttachingDatabase = "Attaching Database {0} to {1}";
       public const string StatusAttachedDatabase = "Attached Database {0} to {1}";
       public const string StatusApplyDefaultDatabaseToLogins = "Applying default database to synchronized logins";
       public const string StatusApplyDefaultDatabaseToSpecificLogin = "\tApplying default database to {0}: {1}";
       public const string StatusGrantingDatabasePermissions = "\tGranting {0} database permissions to {1}";
       public const string StatusDeletingSourceFiles = "Deleting source files";
       public const string StatusDeletingSpecificSourceFile = "\tDeleting {0}";
       public const string StatusTaskComplete = "Task complete";
       public const string StatusTaskFailed = "Task failed";
       public const string StatusUserNotFoundAtDestination = "\tUser {0} not found at destination";
       public const string StatusUserAlreadyExistsAtDestination = "\tUser {0} already exists at destination";
       public const string StatusSettingDatabaseOnline = "Setting database {0} online";
       public const string StatusSettingDatabaseOnlineSuccess = "Successfully set database {0} online";
       public const string StatusRenamingLogicalFile = "Changing Logical File Name from {0} to {1}";
       public const string StatusRenamedLogicalFile = "Changed Logical File Name from {0} to {1}";

       public const string PromptActiveConnections = "The selected database has active connections that must be closed before proceeding. \r Would you like to kill the connections in order to proceed?";
       public const string PromptStandbyMode = "The source database is in Standby mode and must be set Online before proceeding.\r Would you like to set the database Online?";
       public const string PromptActiveConnectionsCaption = "Open Connections";
       public const string PromptDestinationDatabaseExistsRenaming = "Renaming existing destination database to {0}";
       
       public const string ErrorNoUserInformationFound = "No user information found.";
       public const string ErrorNoPermissionPolicyFound = "User permission policy data not found.";
       public const string ErrorNotSupportedSqlCombination = "The requested SQL Server version combination is not supported.";
       public const string ErrorDestinationDatabaseExists = "The destination database already exists.";
       public const string ErrorUnableToDetach = "Unable to successfully detach the source database.";
    }
}
