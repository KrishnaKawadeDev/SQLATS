using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using System.Data.SqlClient;
using IderaTrialExperienceCommon.Common;
using IderaTrialExperienceCommon.Dialogs;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Smo = Microsoft.SqlServer.Management.Smo;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.Launchpad
{
    public partial class Form_Main : Form
    {
        #region Constructor

        public Form_Main()
        {
            InitializeComponent();
            this.Text = ideraTitleBar1.IderaProductNameText;

        }



        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x00C00000; // remove WS_CAPTION
                parms.Style |= 0x00040000;  // include WS_SIZEBOX
                return parms;
            }
        }
        #endregion

        #region OnLoad (Common)

        protected override void OnLoad(EventArgs e)
        {
            #region Common Onload code

            base.OnLoad(e);
            if (!Startup.GuiStartup(this, menuTools, menuAbout, ideraTitleBar1))
            {
                Close();
                return;
            }

            #endregion

            // Enable buttons based on whether EXE exists for the feature button
            // this is too support custom install
            EnableFeaturesInPanel(groupPanel1);
            EnableFeaturesInPanel(groupPanel2);
            EnableFeaturesInPanel(groupPanel4);


        }

        private void
           EnableFeaturesInPanel(
              DevComponents.DotNetBar.Controls.GroupPanel groupPanel
           )
        {
            bool enabled = false;

            foreach (Control c in groupPanel.Controls)
            {
                enabled = false;
                if (c.GetType().ToString() == "Idera.SqlAdminToolset.Launchpad.FeatureButton")
                {
                    if (c.Tag != null)
                    {
                        try
                        {
                            string fullpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                            fullpath = Path.Combine(fullpath, (string)c.Tag);
                            if (File.Exists(fullpath)) enabled = true;
                        }
                        catch { }
                    }
                }
                if (c.Enabled != enabled) c.Enabled = enabled;
            }
        }

        #endregion

        #region Common Code

        #region File Menu Event Handlers (Common)

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Help Menu Event Handlers (Common)

        private void menuShowHelp_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowHelp(DisplayHelp.MAINTOPIC);
        }

        private void menuManageLicense_Click(object sender, EventArgs e)
        {

            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }



        private void menuAbout_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowAboutForm();
        }

        private void menuSearchIderaKnowledgeBase_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowURL_SearchIderaKnowledgeBase(this);
        }

        private void menuAboutIderaProducts_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowURL_AboutIderaProducts(this);
        }

        private void menuContactTechnicalSupport_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowURL_ContactTechnicalSupport(this);
        }

        private void menuCheckForUpdates_Click(object sender, EventArgs e)
        {
            HelpMenu.CheckForUpdates(this);
        }

        #endregion

        #region Tools Menu (Common )

        private void menuManageServerGroups_Click(object sender, EventArgs e)
        {
            ToolsMenu.ManageServerGroups();
        }

        private void menuToolsetOptions_Click(object sender, EventArgs e)
        {
            ToolsMenu.ShowToolsetOptions();
        }

        #endregion

        #endregion

        #region Program Logic

        private void buttonTool_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonX button = (DevComponents.DotNetBar.ButtonX)sender;

            if (button.Tag != null)
            {
                RunTool((string)button.Tag);
            }
            else
            {
                Messaging.ShowError("Error: No application set for that tool button");
            }
        }

        public void
           RunTool(
              string toolname
           )
        {
            string fullPath = "<path not set>";

            Cursor = Cursors.WaitCursor;

            try
            {
                string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                fullPath = Path.Combine(path, toolname);
                Process.Start(fullPath, "/NOWELCOMESCREEN");

                Thread.Sleep(500); // if we shut down immediately you get a blank screen so we will just stay up a bit before shutting down
                if (ToolsetOptions.closeLaunchpad) Close();
            }
            catch (Exception ex)
            {
                Messaging.ShowException(String.Format("An error occurred starting the request tool: {0}.",
                                                        toolname),
                                         ex);
            }

            Cursor = Cursors.Default;
        }

        #endregion

        private void buttonEditToolSetOptions_Click(object sender, EventArgs e)
        {
            ToolsMenu.ShowToolsetOptions();
        }

        private void buttonManageServerGroups_Click(object sender, EventArgs e)
        {
            ToolsMenu.ManageServerGroups();
        }

        private void buttonShowHelp_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowHelp(DisplayHelp.MAINTOPIC);
        }

        private void ShowF1Help(object sender, HelpEventArgs hlpevent)
        {
            HelpMenu.ShowHelp(DisplayHelp.LAUNCHPAD);
        }

        private void Task_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control c = (Control)sender;
                if (c.Tag != null)
                {
                    if (ToolsetOptions.firstTimeLaunchpad)
                    {
                        ToolsetOptions.firstTimeLaunchpad = false;

                        DialogResult choice = Messaging.ShowConfirmation(
                            "Would you like to close the SQL admin toolset Launchpad when you launch tools?\r\n" +
                            "This setting can be modified later via the SQL admin toolset Options entry under the Tools menu.");

                        Core.ToolsetOptions.closeLaunchpad = (choice == DialogResult.Yes);
                        ToolsetOptions.WriteOptions();

                        Application.DoEvents();
                    }

                    RunTool((string)c.Tag);
                }
            }
        }

        private void buttonProvideFeedback_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowURL_BuyNow(this);
        }

        private void menuPurchase_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowURL_BuyNow(this);
        }

        private void linkBuyNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HelpMenu.ShowURL_BuyNow(this);
        }

        private void ideraTitleBar1_LicenseInfoButtonClick(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }

        private void ideraTitleBar1_WindowLockChanged(object sender, EventArgs e)
        {
            if (!ideraTitleBar1.IsFormLocked)
            {
                if (!CommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName, string.Format("Unlocking window", ideraTitleBar1.TrialDaysLeft));
                }
                EnableFeaturesInPanel(groupPanel1);
                EnableFeaturesInPanel(groupPanel2);
                EnableFeaturesInPanel(groupPanel4);
                //EventLog.WriteEntry(Application.ProductName, string.Format("Unlocking window", ideraTitleBar1.TrialDaysLeft));
                //EnableFeaturesInPanel(groupPanel1);
                //EnableFeaturesInPanel(groupPanel2);
                //EnableFeaturesInPanel(groupPanel4);
            }
        }

        //private void menuHelp_Click(object sender, EventArgs e)
        //{
        //   //this.menuManageLicense.Enabled = CoreGlobals.activated;
        //   base.OnClick(e);
        //}
    }
}

