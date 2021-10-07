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

namespace Idera.SqlAdminToolset.$safeprojectname$
{
    public partial class Form_Main : Form
    {
       #region Constructor

       public Form_Main()
        {
            InitializeComponent();
        }

       #endregion

       #region OnLoad (Common)

        protected override void OnLoad(EventArgs e)
        {
            #region Common Onload code

            base.OnLoad(e);
            if ( ! Startup.GuiStartup( this, menuTools, menuAbout ) ) 
            {
               Close();
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

        private void menuManageLicense_Click(object sender, EventArgs e)
        {
           HelpMenu.ShowManageLicense( this );
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
        
        private void menuProvideFeedback_Click( object sender, EventArgs e )
        {
           HelpMenu.ShowURL_ProvideFeedback( this );
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

       #region SQL Server & Credentials Field Handling

       SQLCredentials sqlCredentials = null;

       private void buttonCredentials_Click( object sender, EventArgs e )
       {
          Form_Credentials credentialsForm = new Form_Credentials( sqlCredentials );
          DialogResult choice = credentialsForm.ShowDialog();
          if ( choice == DialogResult.OK )
          {
             sqlCredentials = credentialsForm.sqlCredentials;
          }
       }

       private void buttonBrowseServer_Click( object sender, EventArgs e )
       {
          Form_SQLServerBrowse browseDlg = new Form_SQLServerBrowse();

          Cursor = Cursors.WaitCursor;
          bool loaded = browseDlg.LoadServers();
          Cursor = Cursors.Default;

          if ( loaded )
          {
             DialogResult choice = browseDlg.ShowDialog();
             if ( choice == DialogResult.OK )
             {
                if ( textServer.Text != browseDlg.SelectedServer )
                {
                   textServer.Text = browseDlg.SelectedServer;
                }
             }
          }
       }

       #endregion

       #region Program Logic

       private void buttonGetResults_Click( object sender, EventArgs e )
       {
          // Validation
          if ( textServer.Text.Trim().Length == 0 )
          {
             Core.Messaging.ShowError( "Specify a SQL Server instance name." );
             textServer.Select();
             return;
          }

          // Do Work
          MessageBox.Show( "Here is where you shine - write some code here to get some cool results" );
       }
       #endregion
   }
}

