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

using Idera.SqlAdminToolset.Core;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.EmptyTool
{
    public partial class Form_Main : Form
    {
       #region Constructor

       public Form_Main()
        {
            InitializeComponent();
           this.Text = ideraTitleBar1.IderaProductNameText;
        }

       #endregion

       #region OnLoad (Common)

        protected override void OnLoad(EventArgs e)
        {
            #region Common Onload code

            base.OnLoad(e);
            if ( ! Startup.GuiStartup( this, menuTools, menuAbout, ideraTitleBar1) ) 
            {
               Close();
               return;
            }

            #endregion

            // Program Specific Logic
        }

       #endregion

       #region Common Code

        #region File Menu Event Handlers (Common)

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuExitToLaunchpad_Click(object sender, EventArgs e)
        {
           Launchpad.RunAndClose( this );
        }

        #endregion

        #region Help Menu Event Handlers (Common)

        private void menuShowHelp_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowHelp();
        }

        private void menuDeactivateLicense_Click(object sender, EventArgs e)
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
           HelpMenu.ShowURL_SearchIderaKnowledgeBase( this );
        }

        private void menuAboutIderaProducts_Click(object sender, EventArgs e)
        {
           HelpMenu.ShowURL_AboutIderaProducts( this );
        }

        private void menuContactTechnicalSupport_Click(object sender, EventArgs e)
        {
           HelpMenu.ShowURL_ContactTechnicalSupport( this );
        }

        private void menuCheckForUpdates_Click(object sender, EventArgs e)
        {
           HelpMenu.CheckForUpdates( this );
        }

        #endregion

        #region Tools Menu (Common )

       private void menuManageServerGroups_Click( object sender, EventArgs e )
       {
         ToolsMenu.ManageServerGroups();
       }
       
       private void menuToolsetOptions_Click( object sender, EventArgs e )
       {
          ToolsMenu.ShowToolsetOptions();
       }

        private void menuLaunchpad_Click( object sender, EventArgs e )
        {
           ToolsMenu.RunLaunchpad( this );
        }

       #endregion

        #endregion

       #region Program Logic

       private void buttonGetResults_Click( object sender, EventArgs e )
       {
         MRU.AddServerOrGroup( ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server,
                               ServerSelection.Text,
                               ServerSelection.SqlCredentials );
          
          // Validation
          if ( ServerSelection.Text.Trim().Length == 0 )
          {
             Core.Messaging.ShowError( "Specify a SQL Server instance name." );
             ServerSelection.Select();
             return;
          }

          // Do Work
          MessageBox.Show( "Here is where you shine - write some code here to get some cool results" );
       }
       #endregion

       private void menuHelp_Click(object sender, EventArgs e)
       {
          
          base.OnClick(e);
       }

        private void ideraTitleBar1_Load(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }
    }
}

