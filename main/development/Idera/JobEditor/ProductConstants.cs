using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.JobEditor
{
    class ProductConstants
    {
        // Product Name
        public static string shortProductName = "JobEditor";
        public static string productName = "Job Editor";
        public static string productDescription = "View and Edit Agent jobs across multiple SQL Servers";

        // CommandLine Support
        public static bool supportsCommandLine = false;

        public static string usage = "Syntax:\r\n" +
                                     "    JobEditor /arg1:value /arg2:value\r\n" +
                                     "Parameters:\r\n" +
                                     "    /arg1:value" +
                                     "    /arg2:value";

        public static int numbercount;
        public static string joblastrunstr;
        public static int compareRecentDays = 14;
        public static int compareNewDays = 30;

        public static string displayServers = "{0} SQL Servers scanned";
        public static string displayFailed = "{0} jobs failed on last run";
        //public static string displayNotRecent = "{0} jobs not run in last " + compareRecentDays + " days";
        public static string displayNotRecent = "{0} jobs not run in last " + numbercount + " " + joblastrunstr + "";
        public static string displayNotNotifying = "{0} jobs not notifying the event log";
        public static string displayNew = "{0} new jobs in last " + compareNewDays + " days";
        public static string displayTotal = "{0} jobs found";
        public static string displaySelected = displayTotal + ", {1} checked";
        public static string displayToUpdate = "{0} jobs to update";
        public static string displayUnknown = "???";
        public static string displayNone = "No";

        public static string displayGroupHeader = "Job Information";
        public static string displayGroupLabel = displayGroupHeader + " for {0}";
        public static string displayGroupLabelGenericValue = "each Job";
        public static string displayGroupHeaderMultiServer = "Multiple Server " + displayGroupHeader;
        public static string displayGroupHeaderGroup = "Multiple Server " + displayGroupHeader;

        public static string displayLoading = "Loading Job information ...";
        public static string displayUpdating = "Updating Job properties ...";
        public static string displayCancelling = "Cancelling...";

        public static string msgServerNeeded = "Specify at least one SQL Server.";
        public static string msgServerGroupEmpty = "The selected Server Group contains no SQL Servers.";
        public static string msgJobNeeded = "Check at least one Job before attempting to update.";
        public static string msgActionGetJobs = "Get Job Information";
        public static string msgActionUpdateJobs = "Update Jobs";
        public static string msgActionJobProperties = "Job Properties";
        public static string msgJobsUpdated = "{0} jobs succesfully updated on {1} servers.";

        public static string msgErrorUnknownType = "Unknown result set returned of type {0}";
        public static string msgErrorLoadingJobs = "Unable to load job information. Error: {0}";
        public static string msgErrorLoadingCategories = "Unable to load job categories. Error: {0}";
        public static string msgErrorLoadingOwners = "Unable to load job owners. Error: {0}";
        public static string msgErrorLoadingOperators = "Unable to load job operators. Error: {0}";
        public static string msgErrorGettingUpdateJobs = "Unable to process checked jobs for update.";
        public static string msgErrorUpdatingJobs = "Unable to update jobs. Error: {0}";
        public static string msgErrorUpdatingJob = "Unable to update job properties for job '{0}'. Error: {1}";
        public static string msgSqlErrorLoadingJobs = "Unable to load job information. sp_help_job returned the following error: {0}";
        public static string msgSqlErrorLoadingCategories = "Unable to load job categories. sp_help_category returned the following error: {0}";
        public static string msgSqlErrorLoadingOperators = "Unable to load job operators. sp_help_operator returned the following error: {0}";
        public static string msgSqlErrorUpdatingJob = "Unable to update job properties for job '{0}'. sp_update_job returned the following error: {1}";

        public const string LogCreate = "Creating {0} '{1}'";
        public const string LogCreateFailed = "Failed to create {0} '{1}': {2}";
        public const string LogUpdate = "Updating {0} '{1}': {2}";
        public const string LogUpdateFmt = ", {0}='{1}'";
        public const string LogUpdateFailed = "Failed to update {0} '{1}': {2}";

        // Resource Strings
    }
}
