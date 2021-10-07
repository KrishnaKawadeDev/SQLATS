#region SQL admin toolset © 2006, 2007, 2012 Idera, Inc. and Idera.

/* 
 * Idera reserves all rights in the program and source code as delivered.  The program 
 * or any portion thereof may not be reproduced or reverse engineered in any form 
 * whatsoever without the written consent of Idera.  
 * 
 * A license to the software does not constitute authorization.
 */

#endregion
using System;
using System.Collections.Generic;
using System.Text;
using BBS.License;
using BBS.TracerX;
using DeployLX.Licensing.v5;
using DevComponents.DotNetBar;
using Idera.SqlAdminToolset.Core.Licensing;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.Core
{
    public class CoreGlobals
    {
       // License Information
       public static string        hostComputer;
       public static string        licenseRegistryKey        = @"Software\Idera\LimitCheck_"+BBSLicenseConstants.ProductID;// @"Software\Idera\SQLadminToolset";
        public static string        licenseRegistryValue     = "License";
       public static string        licenseTrialRegistryValue = "Trial";
        public static string       trialRegistryKey          = "SubVersion";
       public static bool          trialCopy                 = false;
       public static bool          activated                 = false;
       public static bool          isBypassLicense           = false;
        private static SecureLicense license                 = null;
        private static BBSLic bBSLic = null;
       // Used during beta period
       public static bool     betaCopy           = false;
       public static DateTime betaLicenseEndDate = new DateTime( 2008, 07, 15 );  // last day beta license works
       public static DateTime betaDropDeadDate   = new DateTime( 2008, 07, 15 );  // last day beta software will run (even with a production license)
       
       // Product Name
       public static string companyName        = "Idera";
       public static string suiteName          = "Idera SQL admin toolset";
       public static string shortSuiteName     = "SQL admin toolset";
       public static string productName        = suiteName; // product should override at startup for use in MessageBoxes, etc
       public static string shortProductName   = shortSuiteName; // product should override at startup for use in MessageBoxes, etc
       public static string productDescription = "";
       
       // Server Groups
       public static string          serverGroupFile      = "ServerGroups.xml";
       public static ToolServerGroup ServerGroupList = new ToolServerGroup();

       public static DateTime        ServerGroupTimestamp = DateTime.MinValue;
       public static string          AllSMOServersGroup   = "Registered Servers";
       public static string ServerGroupXmlFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Microsoft SQL Server\{0}\Tools\Shell\RegSrvr.xml";

       // Startup
       public static bool     showWelcomeScreen = true;
       public static string[] commandLineArgs;
       public static string   configurationPath;

       // Common Message to Register for HealthCheck
       public const string registerHealthCheckMessage = "IderaHealthCheckMessage";
        public const string showHealthCheckMutex = "IderaShowHealthCheckMutex";
        public const string gotShowHealthCheckMutex = "IderaGotShowHealthCheckMutex";
       
       // Logging
       public static Logger   traceLog;

       // Command Line Interface
       public static string cliBanner = "\r\n{0} - Idera SQL admin toolset Version {1}\r\n" +
                                        "(c) Copyright 2013 Idera Inc.";

       // Tools Menu Stuff
       public static string RegKeyIderaProducts       = @"Software\Idera\RegisteredProducts";
       public static string toolsLaunchpadDescription = "SQL admin toolset Launchpad";
       public static string toolsLaunchpadExe         = "Launchpad.exe";

       // Check Update
       public static string urlCheckUpdates = @"http://www.idera.com/webscripts/VersionCheck.aspx?productid={0}&v={1}";
       public static string productID       = "sqladmintoolset";
       public static string productVersion  = "9.88.777.666";  // placeholder for build replacement

       // Help
       public static string helpFolder         = "Documentation";
       public static string helpFile           = "SqlAdminToolset.html";

       public static string urlKnowledgeBase   = @"http://www.idera.com/support/customer-portal#SecondaryNav";
       public static string urlSupport         = @"http://www.idera.com/support/productsupport";
       public static string urlAboutProducts   = @"http://www.idera.com/productssolutions/sqlserver";
       public static string urlBuyNow          = @"https://www.idera.com/buynow/shoppingcart";
     
        public static ToolsetLicense License
        {
            get
            {
                // if (license == null) LicenseUI.ValidateLicense(false);
                // return ToolsetLicense.FromSecureLicense(license);
                if (bBSLic != null)
                    return ToolsetLicense.FromSecureLicense(bBSLic);
                else
                    return ToolsetLicense.FromSecureLicense(license);
            }
        }

        public static SecureLicense SecureLicense
        {
            get { return license; }
            set { license = value; }
        }

        public static BBSLic BBSLic { get { return bBSLic; }  set { bBSLic = value; } }
    }
}
