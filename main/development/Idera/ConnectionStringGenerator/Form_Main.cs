using System;
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
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Smo = Microsoft.SqlServer.Management.Smo;

using Idera.SqlAdminToolset.Core;
using IderaTrialExperienceCommon.Common;


// Reference websites for connection strings
// http://msdn2.microsoft.com/en-us/library/system.data.sqlclient.sqlconnection.connectionstring.aspx
// http://support.microsoft.com/kb/313295
// http://support.microsoft.com/kb/238949
// http://sqljunkies.com/HowTo/2E1101E0-D5C1-4DBD-A398-FE485DFA439B.scuk

namespace Idera.SqlAdminToolset.ConnectionStringGenerator
{
    public partial class Form_Main : Form
    {
       #region Constructor

       public Form_Main()
        {
            InitializeComponent();
            this.Text = ideraTitleBar1.IderaProductNameText;
            GenerateConnectionString();
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

        #region OnLoad ( Common )

        protected override void OnLoad(EventArgs e)
        {
           #region Common Onload code

           base.OnLoad( e );
           if ( !Startup.GuiStartup( this, menuTools, menuAbout, ideraTitleBar1) )
           {
              Close();
              return;
           }
           

           #endregion

           // Start off with focus in server field
           textServer.Select();
        }

       #endregion

       #region Common Code

        #region File Menu Event Handlers (Common)

        private void menuFileExit_Click( object sender, EventArgs e )
        {
           Close();
        }

        private void menuExitToLaunchpad_Click( object sender, EventArgs e )
        {
           Launchpad.RunAndClose( this );
        }

        #endregion

        #region Help Menu Event Handlers (Common)

        private void menuShowHelp_Click( object sender, EventArgs e )
        {
           HelpMenu.ShowHelp();
        }

       private void menuDeactivateLicense_Click(object sender, EventArgs e)
        {
           HelpMenu.ShowDeactivateLicense();
        }

        private void menuAbout_Click( object sender, EventArgs e )
        {
           HelpMenu.ShowAboutForm();
        }

        private void menuSearchIderaKnowledgeBase_Click( object sender, EventArgs e )
        {
           HelpMenu.ShowURL_SearchIderaKnowledgeBase( this );
        }

        private void menuAboutIderaProducts_Click( object sender, EventArgs e )
        {
           HelpMenu.ShowURL_AboutIderaProducts( this );
        }

        private void menuContactTechnicalSupport_Click( object sender, EventArgs e )
        {
           HelpMenu.ShowURL_ContactTechnicalSupport( this );
        }

        private void menuCheckForUpdates_Click( object sender, EventArgs e )
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

        //----------------------------------------------------------------
        // buttonGenerate_Click
        //----------------------------------------------------------------
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
           GenerateConnectionString();
        }

        StringBuilder connStr;

        //----------------------------------------------------------------
        // GenetrateConnectionString - the magic!
        //----------------------------------------------------------------
        private void GenerateConnectionString()
        {
           connStr = new StringBuilder(2048);
            
           connStr.Append( GetServerProperty(textServer.Text) );

           AppendProperty("Database" ,          textDatabase.Text);
           AppendProperty("Application Name", textApplicationName.Text);
           AppendProperty("Connection Timeout", textConnectionTimeout.Text);

           if (radioWindows.Checked)
           {
               connStr.Append(";Integrated Security=SSPI");
           }
           else
           {
               connStr.AppendFormat(";User ID={0};Password={1}",
                                    EscapeString(textLoginName.Text),
                                    EscapeString(textPassword.Text));
           }
           AppendProperty("Encrypt", checkEncrypt.Checked, false);

           // Connection pooling
           AppendProperty("Pooling", checkPooling.Checked, true);
           AppendProperty("Connection Reset", checkConnectionReset.Checked, true);
           AppendProperty("Min Pool Size", textMinPoolSize.Text );
           AppendProperty("Max Pool Size", textMaxPoolSize.Text );
           AppendProperty("Connection Lifetime", textConnectionLifetime.Text );

           // Advanced Properties
           AppendProperty("AttachDBFilename", textAttachFileDB.Text );
           AppendProperty("Current Language", textCurrentLanguage.Text );
           AppendProperty("Driver", textDriver.Text );
           AppendProperty("Packet Size", textPacketSize.Text );

           string netlib = "";
           if ( comboNetworkLibrary.Text == "Named Pipes (dbnmpntw)" )
              netlib = "dbnmpntw";
           else if ( comboNetworkLibrary.Text == "Winsock TCP/IP (dbmssocn)" )
              netlib = "dbmssocn";
           else if ( comboNetworkLibrary.Text == "SPX/IPX  (dbmsspxn)" )
              netlib = "dbmsspxn";
           else if ( comboNetworkLibrary.Text == "Banyan Vines (dbmsvinn)" )
              netlib = "dbmsvinn";
           else if ( comboNetworkLibrary.Text == "Multi-Protocol (Windows RPC) (dbmsrpcn)" )
              netlib = "dbmsrpcn";
           else if ( comboNetworkLibrary.Text != "" && comboNetworkLibrary.Text != "<default>")
              netlib = comboNetworkLibrary.Text;
           AppendProperty("Network Library", netlib );

           AppendProperty("Provider", textProvider.Text );
           AppendProperty("WorkStation ID", textWorkstation.Text );
           AppendProperty("Failover Partner", textFailoverPartner.Text );

           AppendProperty("Persist Security Info", checkPersistSecurityInfo.Checked, false);
           AppendProperty("MARS_Connection", checkMARSConnection.Checked, false);
           AppendProperty("Enlist", checkEnlist.Checked, true);
           AppendProperty("Asynchronous Processing", checkAsynchronousProcessing.Checked, false);

           textConnectionString.Text = connStr.ToString();
        }

        private string GetServerProperty( string serverName )
        {
           StringBuilder server = new StringBuilder(512);

            if (serverName.Length == 0)
                server.Append("<SQL Server Instance>");
            else
                server.AppendFormat("{0}", EscapeString(serverName));


            // network library
            if (  radioLibraryDefault.Checked )
            {
                if (textBasicPort.Text.Length != 0)
                {
                    server.AppendFormat(",{0}", textBasicPort.Text);
                }
            }
            else
            {
               if ( radioLibraryBanyan.Checked )
               {
                  server.Insert(0,"vines:");
               }
               else if ( radioLibraryAppleTalk.Checked )
               {
                  server.Insert(0,"adsp:");
               }
               else if ( radioLibraryNWLink.Checked )
               {
                  server.Insert(0,"spx:");
               }
               else if ( radioLibrarySharedMemory.Checked )
               {
                  server.Insert(0,"lpc:");
               }
               else if ( radioLibraryNamedPipes.Checked )
               {
                  //np:\\<computer_name>\pipe\<pipename>

                  server.Insert(0,"np:");
                  string np = textNamedPipe.Text.Trim();
                  if ( np.Length != 0 ) server.Append(np);
               }
               else if ( radioLibraryTCPIP.Checked )
               {
                  server.Insert(0,"tcp:");
                  string port = textAdvancedPort.Text.Trim();
                  if ( port.Length != 0 ) server.Append(", " + port);
               }
               else if (radioLibraryMulti.Checked)
               {
                   // from http://support.microsoft.com/kb/313295

                   server.Insert(0,"rpc:");

                   if (radioMultiLocalProc.Checked )   server.Append(", ncalrpc");
                   if (radioMultiIPX.Checked )         server.Append(", ncadg_ipx");
                   if (radioMultiUDP.Checked )         server.Append(", ncadg_ip_udp");
                   if (radioMultiBanyan.Checked )      server.Append(", ncacn_vns_spp");
                   if (radioMultiSPX.Checked )         server.Append(", ncacn_spx");
                   if (radioMultiNetBios.Checked )     server.Append(", ncacn_nb_nb");
                   if (radioMultiTCPIP.Checked )       server.Append(", ncacn_ip_tcp");
                   if (radioMultiNamedPipes.Checked )  server.Append(", ncacn_np");
               }
            }
            
            server.Insert(0,"Server=");
            
            return server.ToString();
        }

        //----------------------------------------------------------------
        // AppendProperty (string)
        //----------------------------------------------------------------
        private void AppendProperty( string name, string value )
        {
           if (value.Length != 0)
           {
              connStr.AppendFormat(";{0}={1}", name, EscapeString(value) );
           }
        }

        //----------------------------------------------------------------
        // AppendProperty (bool)
        //----------------------------------------------------------------
        private void AppendProperty( string name, bool value, bool defaultValue )
        {
            if (value != defaultValue) connStr.AppendFormat(";{0}={1}", name, (value) ? "true" : "false");
        }

        //----------------------------------------------------------------
        // PropertiesValid
        //----------------------------------------------------------------
        private bool PropertiesValid()
        {
            if (radioSQL.Checked && textLoginName.Text.Length == 0)
            {
                Messaging.ShowError("A login name is required to use SQL authentication for connections.");
                return false;
            }

            if (textServer.Text.Length == 0)
            {
                Messaging.ShowError("An instance name is required for connections.");
                return false;
            }
            return true;
        }

        //----------------------------------------------------------------
        // buttonTextConnection_Click
        //----------------------------------------------------------------
        private void buttonTestConnection_Click( object sender, EventArgs e )
        {
            if (!PropertiesValid()) return;

            try
            {
                Cursor = Cursors.WaitCursor;

               using ( SqlConnection conn = new SqlConnection(textConnectionString.Text ) )
               {
                  conn.Open();
                  conn.Close();
               }

               Messaging.ShowInformation( String.Format( "Test Passed. A connection to '{0}' was successfully opened using the generated connection string.", textServer.Text ),
                                          "Test Connection" );
           }
           catch ( Exception ex )
           {
               Messaging.ShowException("Connection Test Failed", ex);
           }
           finally
           {
               Cursor = Cursors.Default;
           }

        }

        //----------------------------------------------------------------
        // radioWindowsSql_CheckedChanged
        //----------------------------------------------------------------
        private void radioWindowsSql_CheckedChanged( object sender, EventArgs e )
        {
            textLoginName.Enabled = radioSQL.Checked;
            textPassword.Enabled = radioSQL.Checked;

            GenerateConnectionString();
        }

        //----------------------------------------------------------------
        // PropertyChanged
        //----------------------------------------------------------------
        private void PropertyChanged( object sender, EventArgs e )
        {
           GenerateConnectionString();
        }

        //----------------------------------------------------------------
        // buttonCopyToClipboard_Click
        //----------------------------------------------------------------
        private void buttonCopyToClipboard_Click( object sender, EventArgs e )
        {
             CopyToClipboard();
        }

        private void contextMenuCopy_Click( object sender, EventArgs e )
        {
             CopyToClipboard();
        }

        private void CopyToClipboard()
        {
           if ( String.IsNullOrEmpty(textConnectionString.SelectedText) )
              Clipboard.SetDataObject(textConnectionString.Text);
           else
              Clipboard.SetDataObject(textConnectionString.SelectedText);
        }

        private void contextMenuSelectAll_Click( object sender, EventArgs e )
        {
           textConnectionString.SelectAll();
        }

        //----------------------------------------------------------------
        // menuResetDefaults_Click
        //----------------------------------------------------------------
        private void menuResetDefaults_Click( object sender, EventArgs e )
        {
           ResetDefaults();
        }

        //----------------------------------------------------------------
        // buttonResetDefaults_Click
        //----------------------------------------------------------------
        private void buttonResetDefaults_Click( object sender, EventArgs e )
        {
            ResetDefaults();
        }

        //----------------------------------------------------------------
        // ResetDefaults
        //----------------------------------------------------------------
        private void ResetDefaults()
        {
            DialogResult choice = Messaging.ShowConfirmation( "This will clear all the properties and set them back to their default values.\r\n\r\nAre you sure you want to continue?" );
            if ( choice != DialogResult.Yes ) return;

            textServer.Text = "";
            textBasicPort.Text = "";
            textDatabase.Text = "";
            textApplicationName.Text = "";
            textConnectionTimeout.Text = "";

            radioWindows.Checked = true;
            textPassword.Text = "";
            textLoginName.Text = "";

            checkEncrypt.Checked = false;

            checkPooling.Checked = true;
            textMaxPoolSize.Text = "";
            textMinPoolSize.Text = "";
            textConnectionLifetime.Text = "";
            checkConnectionReset.Checked = true;

            textAttachFileDB.Text = "";
            textCurrentLanguage.Text = "";
            textDriver.Text = "";
            textPacketSize.Text = "";
            comboNetworkLibrary.Text = "";
            textProvider.Text = "";
            textWorkstation.Text = "";
            textFailoverPartner.Text = "";

            checkAsynchronousProcessing.Checked = false;
            checkMARSConnection.Checked = false;
            checkPersistSecurityInfo.Checked = false;
            checkEnlist.Checked = true;

            radioLibraryDefault.Checked = true;

            radioMultiNamedPipes.Checked = true;

            textNamedPipe.Text = "";
            textAdvancedPort.Text = "";

            GenerateConnectionString();
        }

        //-----------------------------------------------------------------------
        // EscapeString
        //
        // (1) If value begins or ends with blanks, wrap in quotes
        // (2) If contains one of ;'" then you need to espace with ' or ". Use "
        //     unless first character is single quote then use double quote
        // (3) If string contains any escaped chars enclose in quotes
        //-----------------------------------------------------------------------
        private  string
           EscapeString(
              string value
           )
        {
            if (value == null || value.Length == 0) return value;

            // Use double quote as escape character unless first character is double
            // quote; then use single quote
            string doubleQuote = "\"";

            bool encloseInQuotes = false;

            // Do we need to enclose in quotes? (contains semicolon or leading or trailing spaces)
            if ((-1 != value.IndexOf(";")) ||
                 (value[0] == ' ' || value[value.Length - 1] == ' '))
            {
                encloseInQuotes = true;
            }

            if (encloseInQuotes)
            {
                // escape any double quotes
                value = value.Replace(doubleQuote, "\"\"");
                value = doubleQuote + value + doubleQuote;
            }

            return value;
        }

        private void ClientNetworkLibraryChanged(object sender, EventArgs e)
        {
           textAdvancedPort.Enabled = radioLibraryTCPIP.Checked;
           
           textBasicPort.Enabled = radioLibraryDefault.Checked || radioLibraryTCPIP.Checked;
           
           textNamedPipe.Enabled    = radioLibraryNamedPipes.Checked;

           radioMultiLocalProc.Enabled = radioLibraryMulti.Checked;
           radioMultiIPX.Enabled = radioLibraryMulti.Checked;
           radioMultiUDP.Enabled = radioLibraryMulti.Checked;
           radioMultiBanyan.Enabled = radioLibraryMulti.Checked;
           radioMultiSPX.Enabled = radioLibraryMulti.Checked;
           radioMultiNetBios.Enabled = radioLibraryMulti.Checked;
           radioMultiTCPIP.Enabled = radioLibraryMulti.Checked;
           radioMultiNamedPipes.Enabled = radioLibraryMulti.Checked;

           GenerateConnectionString();
       }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            Form_SQLServerBrowse browseDlg = new Form_SQLServerBrowse();

            Cursor = Cursors.WaitCursor;
            bool loaded = browseDlg.LoadServers();
            Cursor = Cursors.Default;
   
            if ( loaded )
            {
                DialogResult choice = browseDlg.ShowDialog();
                if (choice == DialogResult.OK)
                {
                    textServer.Text = browseDlg.SelectedServer;
                }
            }
        }

       #endregion

       private void ShowF1Help(object sender, HelpEventArgs hlpevent)
       {
          HelpMenu.ShowHelp();
       }
        
        bool inBasic = false;
        bool inAdvanced = false;

       private void textAdvancedPort_TextChanged( object sender, EventArgs e )
       {
          if ( ! inBasic )
          {
             inAdvanced = true;
             
             textBasicPort.Text = textAdvancedPort.Text;
         
             PropertyChanged(sender, e);
             inAdvanced = false;
         }
       }

       private void textBasicPort_TextChanged( object sender, EventArgs e )
       {
          if ( ! inAdvanced )
          {
             inBasic = true;
             
             textAdvancedPort.Text = textBasicPort.Text;
             
             PropertyChanged(sender, e);
             inBasic = false;
          }
       }

       private void menuHelp_Click(object sender, EventArgs e)
       {
          base.OnClick(e);
       }

        private void menuManageLicense_Click(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }

        private void ideraTitleBar1_LicenseInfoButtonClick(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }
    }
}

