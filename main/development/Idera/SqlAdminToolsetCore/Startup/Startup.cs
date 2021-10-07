using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DeployLX.Licensing.v5;
using IderaTrialExperienceCommon.Common;
using IderaTrialExperienceCommon.Controls;

namespace Idera.SqlAdminToolset.Core
{
    public class Startup
    {
        private static IderaTitleBar ideraTitleBar;
        static public bool
           GuiStartup(
              Form parent,
              ToolStripMenuItem toolMenu,
              ToolStripMenuItem aboutMenuItem,
              IderaTitleBar titleBar
           )
        {
            bool startupSucceeded = true;
            ideraTitleBar = titleBar;
            #region Check that developer linked in CommonAssemblyInfo.cs

            // Make sure developer switched to CommonAssemblyInfo.cs
            // since we commented out version in the Assemblynfo.cs the version value will be zero
            if (Assembly.GetExecutingAssembly().GetName().Version.Major == 0)
            {
                Messaging.ShowError("Excuse me - You forgot to link to CommonAssemblyInfo.cs in the SqlAdminToolsetCore project.",
                                     "ERROR: No link to CommonAssemblyInfo.cs");
            }
            #endregion

            CoreGlobals.showWelcomeScreen = false;
            // Startup License Check - no valid license - dont continue
            //if ( ! LicenseUI.StartupLicenseCheck() )
            //{
            //   startupSucceeded = false;
            //}
            //else
            //{
            var isvalidLicense = LicenseUI.StartupLicenseCheck();
            aboutMenuItem.Text = "About " + CoreGlobals.productName;
            titleBar.ActivateLicense += ActivateLicense;
            if (titleBar != null)
            {
            
                titleBar.LicenseInformation = LicenseUI.GetLicenseInfo();
              
            }
            // Set UI Text (has to be done after startup license call
            // parent.Text = CoreGlobals.productName;

            //if ( CoreGlobals.betaCopy ) parent.Text += " (Community Technology Preview)";
            //else if ( CoreGlobals.trialCopy ) parent.Text += " (Trial Version)";


            // Tools Menu
            try
            {
                ToolsMenu.LoadToolsMenu(toolMenu);
            }
            catch (Exception ex)
            {
                CoreGlobals.traceLog.ErrorFormat("Error loading tools menu: {0}", ex.Message);
            }
            //}

            return startupSucceeded;
        }

        private static void ActivateLicense(object sender, EventArgs e)
        {
            LicenseUI.ShowRegistrationForm();
            if (ideraTitleBar != null)
            {

                ideraTitleBar.LicenseInformation = LicenseUI.GetLicenseInfo();

            }
        }
    }
}
