using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.JobMover
{
   class ProductConstants
   {
      // Product Name
      public static string shortProductName = "JobMover";
      public static string productName = "Job Mover";
      public static string productDescription = "Move Jobs across servers easily";

      // CommandLine Support
      public static bool supportsCommandLine = false;

      public static string usage = "Syntax:\r\n" +
                                   "    JobMover /arg1:value /arg2:value\r\n" +
                                   "Parameters:\r\n" +
                                   "    /arg1:value" +
                                   "    /arg2:value";

      // Resource Strings
      public const string CancelButtonExit = "Close";
      public const string CancelButtonCancel = "Cancel";

      public const string SourceServerLabel = "&Sql Server";
      public const string SourceDatabaseLabel = "&Database";
      public const string DifferentSourceFmt = "Source {0}";

      public const string ServerPageTitle = "Step 2: Specify the source and destination servers for copying jobs";
      public const string ServerPageDescr = "Specify the SQL Servers";
      public const string ServerPageTitleSame = "Step 2: Specify the server where you will be copying jobs";
      public const string ServerPageDescrSame = "Specify the SQL Server";

      public const string ServersLocal = "(local)";

      public const string PromptExitApplication = "Are you sure that you want to close {0}?";
      public const string PromptMustSpecifySourceServer = "Source Server must be specified.";
      public const string PromptMustSpecifyDestinationServer = "Destination Server must be specified.";
      public const string PromptSqlInstancesMustBeDifferent = "You must specify different SQL Server instances for the source and destination.";
      public const string PromptLoading = "Loading jobs...";
      public const string PromptNoJobs = "There are no jobs on the source SQL Server.";
      public const string PromptResetWizardValues = "Would you like to reset the wizard values before restarting?";

      public const string SummaryTaskCopyJobsToDifferentServer = "Copy {0} job{1} to different server";
      public const string SummaryTaskCopyJobsToSameServer = "Copy {0} job{1} on same server";
      public const string SummaryTaskMoveJobsToDifferentServer = "Move {0} job{1} to different server";

      public const string ActionServer = "Server information";

      public const string ErrorNotSupportedSqlCombination = "The requested SQL Server version combination is not supported.";
      public const string ErrorUnknownType = "Unknown result set returned of type {0}";
      public const string ErrorLoadingJobs = "Unable to load job information. Error: {0}";
      public const string ErrorLoadingOwners = "Unable to load job owners. Error: {0}";
      public const string ErrorLoadingAdmin = "Unable to retrieve the admin account name. Error: {0}";
      public const string ErrorLoadingOperators = "Unable to load job operators. Error: {0}";
      public const string ErrorLoadingDatabases = "Unable to load databases. Error: {0}";
      public const string ErrorSqlLoadingJobs = "Unable to load job information. sp_help_job returned the following error: {0}";
      public const string ErrorSqlLoadingCategories = "Unable to load job categories. sp_help_category returned the following error: {0}";
      public const string ErrorSqlLoadingOperators = "Unable to load job operators. sp_help_operator returned the following error: {0}";
      public const string ErrorValidatingJobs = "Unable to validate jobs. Error: {0}";
      public const string ErrorHandlingObject = "Unable to {0} job {1}. Error: {2}";
      public const string ErrorMissingCategories = "Categories not found: {0}";
      public const string ErrorMissingOwners = "Owners not found: {0}";
      public const string ErrorMissingDefaultOwner = "A login name must be specified if 'Always make this login the job owner' is checked.";
      public const string ErrorDefaultOwnerNotFound = "The default new job Owner '{0}' was not found.";
      public const string ErrorMissingOperators = "Operators not found: {0}";
      public const string ErrorDuplicateJobName = "Job name already exists.";
      public const string ErrorMissingDatabases = "Job step databases not found: {0}";
      public const string ErrorCopyingJobs = "Unable to create jobs. Error: {0}";
      public const string ErrorDeletingJobs = "Unable to delete jobs. Error: {0}";

      public const string LogResults = "Job '{0}' {1}: {2}";

      public const string messageHeaderFormat = "({0})JobInfo.{1}()";
      public const string messageFormat = "{0}: {1}";
      public const string messageSqlFormat = "{0} {1} returned the following error:";
      public const string messageListHeaderFormat = "JobInfoList({0}).{1}():";
      public static string messageJobListHeaderFormat = messageListHeaderFormat + " cannot {1} {0}s for job {2}";
      public const string messageListItemFormat = "{0}: cannot load item {1} for job {2}";
      public const string messageConnNotOpen = @"Server connection is not open.";
      public const string messageServerNull = @"serverInformation cannot be null.";
      public const string messageJobIdEmpty = @"jobId cannot be empty.";
      public const string messageJobMetaNull = @"jobMetaInfo cannot be null.";
      public const string messageJobsCopied = "{0} jobs succesfully created on {1}.";
      public const string messageActionCopyJobs = "Create Jobs";

      public const string displayLoading = "Loading Job information ...";
      public const string displayCancelling = "Cancelling...";
      
      public const string resultsValidate = "Problems were discovered validating the jobs to be copied. Press Cancel to return and make new selections or press Continue to create the jobs that can be created.";
      public const string resultsCopyOk = "All jobs were successfully created on the destination server.";
      public const string resultsCopyFailed = "Some jobs were unable to be created on the destination server. Review the results to determine the reasons.";
   }
}
