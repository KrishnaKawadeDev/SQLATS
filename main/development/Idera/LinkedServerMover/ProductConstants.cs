using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.LinkedServerMover
{
    class ProductConstants
    {
        // Product Name
        public static string shortProductName   = "Linked Server Mover";
        public static string productName        = "Linked Server Mover";
        public static string productHelpTopic = @"http://wiki.idera.com/display/SQLAdminToolset/Linked+Server+Copy";
        public static string productDescription = "One sentence tagline for this tool for here and launchpad";

        // CommandLine Support
        public static bool supportsCommandLine = false;

        public static string usage = "Syntax:\r\n" +
                                     "    Linked Server Mover /arg1:value /arg2:value\r\n" +
                                     "Parameters:\r\n" +
                                     "    /arg1:value" +
                                     "    /arg2:value";

        // Resource Strings
        public static string StatusPending = "Pending";
        public static string StatusSuccess = "Success";
        public static string StatusWarning = "Warning";
        public static string StatusNotRequested = "Not Requested";
        public static string StatusFailed = "Failed";

        public const string StatusTaskComplete = "Task complete";
        public const string StatusTaskFailed = "Task failed";
        public const string StatusTransferingLinkedServer = "\tCreating script for linked server: {0}";
        public const string StatusTransferingLinkedServerExecuteScript = "\tExecuting transfer linked server script";
        
        public static string CopyLinkedServers = "Copying Linked Servers";
        public static string ErrorMovingLinkedServersCaption = "Error copying linked servers";
        public static string ErrorNoSourceSqlServer = "Specify a source SQL Server.";
        public static string ErrorNoDestinationSqlServer = "Specify a destination SQL Server.";
        public static string ErrorSourceInvalidCharacters = "You may only specify one source SQL Server.";
        public static string ErrorDestinationInvalidCharacters = "You may only specify one destination SQL Server.";
        public static string ErrorDatabaseMoveMustHaveDifferentDestination = "The destination SQL Server must be different than the source SQL Server.";
        public static string ErrorNotSupportedSqlCombination = "The requested SQL Server version combination is not supported.";
        public static string ErrorConnectingToServer = "Error connecting to {0}\n";
        public static string ErrorOnlySql2000AndAboveSupported = "This tool only supports SQL 2000 and above";
        public const string StatusGatheringData = "Gathering Data";
        public const string CopyLocalLogins = "Copying Local Logins";

        public const string CopyLocalLoginsConfirm = "One or more local logins do not exist on the destination server for the linked servers being copied.  Would you like to copy them to the destination server?  Choosing No will cancel the linked server copy.";
        public const string NoneToMove = "There are not any Linked Servers to copy from the source SQL Server instance that are not already on the destination SQL Server instance.";
     }
}
