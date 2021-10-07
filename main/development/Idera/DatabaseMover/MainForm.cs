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
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Smo = Microsoft.SqlServer.Management.Smo;

using Idera.SqlAdminToolset.Core;
using System.Collections.Specialized;
using DevComponents.DotNetBar;
using Idera.SqlAdminToolset.DatabaseMoverLibrary;
using System.Net;
using System.Runtime.InteropServices;
using DevComponents.DotNetBar.Controls;

using BBS.TracerX;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.DatabaseMover
{
   public partial class MainForm : Form
   {
      #region private variables

      Logger logger = CoreGlobals.traceLog;
      SQLCredentials _SourceServerSqlCredentials = null;
      SQLCredentials _DestinationServerSqlCredentials = null;
      private Server _SourceServer = null;
      private Server _DestinationServer = null;
      private List<Login> _MissingLogins = new List<Login>();
      private TaskToPerform _Task = TaskToPerform.MoveDatabaseToDifferentServer;
      List<DatabaseMoverFile> _FilesToMove = new List<DatabaseMoverFile>();
      string _SourceServerCachedValue = string.Empty;
      string _DestinationServerCachedValue = string.Empty;

      List<string> _CreatedShares = new List<string>();

      SQLVersion _SourceVersion;
      SQLVersion _DestinationVersion;
        bool brokerEnable = false;
        bool HonorBroker = false;
        bool TrustWorthy = false;
        #endregion

        #region Constructor

        public MainForm()
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

         // Program Specific Logic
         ResetValues();
         
         WizardDatabaseMove.BringToFront();
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

      #region browse Server/Database
      private void buttonBrowseSourceServer_Click(object sender, EventArgs e)
      {
         string selectedServer = BrowseServer();
         
            if (textSourceServer.Text != selectedServer && selectedServer != string.Empty)
         {
            textSourceServer.Text = selectedServer;
            _SourceServer = null;
            _FilesToMove.Clear();
            comboSourceDatabase.Items.Clear();
         }
      }

      private void buttonBrowseDestinationServer_Click(object sender, EventArgs e)
      {
         string selectedServer = BrowseServer();
         if (textDestinationServer.Text != selectedServer && selectedServer != string.Empty)
         {
            textDestinationServer.Text = selectedServer;
            _DestinationServer = null;
            comboDestinationDatabase.Items.Clear();
         }
      }

      private string BrowseServer()
      {
         Form_SQLServerBrowse browseDlg = new Form_SQLServerBrowse();

         Cursor = Cursors.WaitCursor;
         bool loaded = browseDlg.LoadServers();
         Cursor = Cursors.Default;

         if (loaded)
         {
            DialogResult choice = browseDlg.ShowDialog();
            if (choice == DialogResult.OK)
            {
               return browseDlg.SelectedServer;
            }
               
         }
            
            return string.Empty;
      }

      private void buttonSourceCredentials_Click(object sender, EventArgs e)
      {
         bool _WindowsAuthentication = (_SourceServerSqlCredentials == null) ? true : _SourceServerSqlCredentials.useWindowsAuthentication;
         string _LoginName = (_SourceServerSqlCredentials == null) ? null : _SourceServerSqlCredentials.loginName;
         string _Password = (_SourceServerSqlCredentials == null) ? null : _SourceServerSqlCredentials.password;

         Form_Credentials credentialsForm = new Form_Credentials(textSourceServer.Text, _SourceServerSqlCredentials);
         DialogResult choice = credentialsForm.ShowDialog();
         if (choice == DialogResult.OK)
         {
            if ( _SourceServerSqlCredentials != credentialsForm.sqlCredentials ||
                 _WindowsAuthentication != credentialsForm.sqlCredentials.useWindowsAuthentication ||
                 _LoginName != credentialsForm.sqlCredentials.loginName ||
                 _Password != credentialsForm.sqlCredentials.password)
            {
               _SourceServerSqlCredentials = credentialsForm.sqlCredentials;
               _SourceServer = null;
               _FilesToMove.Clear();
               comboSourceDatabase.Items.Clear();
            }
         }
      }

      private void buttonDestinationCredentials_Click(object sender, EventArgs e)
      {
         bool _WindowsAuthentication = (_DestinationServerSqlCredentials == null) ? true : _DestinationServerSqlCredentials.useWindowsAuthentication;
         string _LoginName = (_DestinationServerSqlCredentials == null) ? null : _DestinationServerSqlCredentials.loginName;
         string _Password = (_DestinationServerSqlCredentials == null) ? null : _DestinationServerSqlCredentials.password;

         Form_Credentials credentialsForm = new Form_Credentials(textDestinationServer.Text, _DestinationServerSqlCredentials);
         DialogResult choice = credentialsForm.ShowDialog();
         if (choice == DialogResult.OK)
         {
            if ( _DestinationServerSqlCredentials != credentialsForm.sqlCredentials ||
                 //_WindowsAuthentication != credentialsForm.sqlCredentials.useWindowsAuthentication ||
                 _LoginName != credentialsForm.sqlCredentials.loginName ||
                 _Password != credentialsForm.sqlCredentials.password)
            {
               _DestinationServerSqlCredentials = credentialsForm.sqlCredentials;
               _DestinationServer = null;
               comboDestinationDatabase.Items.Clear();
            }
         }
      }

      /// <summary>
      /// Loads databases into drop-down list based on the supplied server name
      /// </summary>
      private void
         LoadDatabases(
            DevComponents.DotNetBar.Controls.ComboBoxEx comboBox,
            Server                                      server,
            bool                                        selectFirst )
      {
         try
         {
            Cursor = Cursors.WaitCursor;

            comboBox.Items.Clear();
            comboBox.Text = "";

            if (Utility.IsValidVersion(server))
            {
               bool unsupportedDb = false;
               foreach (Database _Database in server.Databases)
               {
                  if (_Database.CompatibilityLevel > CompatibilityLevel.Version65)
                  {
                     if (!_Database.IsSystemObject && IsDatabaseValidState(_Database))
                     {
                        comboBox.Items.Add(_Database.Name);
                     }
                  }
                  else
                  {
                     logger.WarnFormat("Database '{0}' on Server '{1}' is at unsupported compatibility level {2}", _Database.Name, server.Name, _Database.CompatibilityLevel.ToString());
                     unsupportedDb = true;
                  }
               }

               if (selectFirst && (comboBox.Items.Count > 0))
               {
                  comboBox.Text = (string)comboBox.Items[0];
               }
               if (unsupportedDb)
               {
                  Messaging.ShowWarning(ProductConstants.ErrorIncompatibleServerDatabases);
               }
            }
         }
         catch (Exception ex)
         {
            logger.Error(ProductConstants.ErrorCannotLoadServerDatabases, Helpers.GetCombinedExceptionText(ex));
            Messaging.ShowError(ProductConstants.ErrorCannotLoadServerDatabasesDetails, ProductConstants.ErrorCannotLoadServerDatabases);

            comboBox.Items.Clear();
            comboBox.Text = "";
         }
         finally
         {
            Cursor = Cursors.Default;
         }
      }

      /// <summary>
      /// True if a database is in a valid state for moving purposes, otherwise false.
      /// </summary>
      private bool IsDatabaseValidState(Database database)
      {
         return (database.Status == (database.Status | DatabaseStatus.Normal) ||
                 database.Status == (database.Status | DatabaseStatus.EmergencyMode) ||
                 database.Status == (database.Status | DatabaseStatus.Standby));
      }

      
      #endregion

      #region Wizard functionality
      
      #region Page Changing
      /// <summary>
      /// Wizard navigation
      /// </summary>
      private void WizardDatabaseMove_WizardPageChanging(object sender, DevComponents.DotNetBar.WizardCancelPageChangeEventArgs e)
      {
         if (e.PageChangeSource == DevComponents.DotNetBar.eWizardPageChangeSource.NextButton)
         {
                if (e.OldPage == pageSelectTask)
            {
               e.NewPage = pageServerInformation;
               if (OptionMoveDatabase.Checked)
               {
                  _Task = TaskToPerform.MoveDatabaseToDifferentServer;
                  checkboxDeleteSourceFiles.Checked = true;
               }
               else if (optionCopyDatabase.Checked)
               {
                  _Task = TaskToPerform.CopyDatabaseToDifferentServer;
                  checkboxDeleteSourceFiles.Checked = false;
               }
               else if (OptionMoveDataFiles.Checked)
               {
                  _Task = TaskToPerform.MoveDataFilesOnly;
               }
               else if (OptionCloneToSameInstance.Checked)
               {
                   _Task = TaskToPerform.CloneDatabaseToSameInstance;
               }
               else
               {
                   e.Cancel = true;
                   return;
               }
            }

            else if (e.OldPage == pageServerInformation)
            {
               
                    if ( (_Task == TaskToPerform.MoveDatabaseToDifferentServer) && (_SourceServer.Information.ComputerNamePhysicalNetBIOS == _DestinationServer.Information.ComputerNamePhysicalNetBIOS))  //same server, new instance
               {
                  _Task = TaskToPerform.MoveDatabaseToDifferentInstance;
               }
               if ( (_Task == TaskToPerform.CopyDatabaseToDifferentServer) && (_SourceServer.Information.ComputerNamePhysicalNetBIOS == _DestinationServer.Information.ComputerNamePhysicalNetBIOS))  //same server, new instance
               {
                  _Task = TaskToPerform.CopyDatabaseToDifferentInstance;
               }
            }

            else if (e.OldPage == pageFileOptions)
            {
               e.NewPage = pageTargetFolder;
            }
            else if (e.OldPage == pageTargetFolder)
            {
               if (_Task == TaskToPerform.MoveDataFilesOnly || _Task == TaskToPerform.CloneDatabaseToSameInstance)
               {
                  e.NewPage = pageSummary;
               }
            }
            
         }
      }

      private void WizardDatabaseMove_CancelButtonClick(object sender, CancelEventArgs e)
      {
         Wizard wiz = (Wizard)sender;

         if (Messaging.ShowConfirmation(string.Format(ProductConstants.PromptExitApplication, CoreGlobals.productName)) == DialogResult.Yes)
         {
            Close();
         }
      }
      
      private void WizardDatabaseMove_WizardPageChanged( object sender, WizardPageChangeEventArgs e )
      {
         if (e.NewPage == pageWelcome || e.NewPage == pageSelectTask)
         {
            WizardDatabaseMove.CancelButtonText = ProductConstants.CancelButtonExit;
         }
         else
         {
            WizardDatabaseMove.CancelButtonText = ProductConstants.CancelButtonCancel;

            if (e.NewPage == pageServerInformation)
            {
               textSourceServer.Select();
            }
         }
      }

      private void WizardDatabaseMove_FinishButtonClick( object sender, CancelEventArgs e )
      {
         //reset source connection
         if (_SourceServer.Databases.Contains("master"))
         {
             _SourceServer.ConnectionContext.SqlConnectionObject.ChangeDatabase("master");
         }

            brokerEnable = _SourceServer.Databases[comboSourceDatabase.Text].BrokerEnabled;
            if (SQLHelpers.Is2008orGreater(_SourceServer.VersionMajor))
            {
                HonorBroker = _SourceServer.Databases[comboSourceDatabase.Text].HonorBrokerPriority;
            }
            TrustWorthy = _SourceServer.Databases[comboSourceDatabase.Text].Trustworthy;
            //Prompt the user before starting any threads to kill connections if active
            if (comboSourceDatabase.Enabled)
         {
            if (comboSourceDatabase.Text.Length > 0 && _SourceServer.GetActiveDBConnectionCount(comboSourceDatabase.Text) > 0)
            {
               if (Messaging.ShowConfirmation(DatabaseMoverLibrary.ProductConstants.PromptActiveConnections, DatabaseMoverLibrary.ProductConstants.PromptActiveConnectionsCaption) == DialogResult.No)
               {
                  return;
               }
               logger.Info("User selected to kill all active connections.");
            }
         }

         panelResults.BringToFront();

         pageSummary.BackButtonEnabled =
            pageSummary.CancelButtonEnabled =
            pageSummary.NextButtonEnabled =
            pageSummary.FinishButtonEnabled =
            DevComponents.DotNetBar.eWizardButtonState.False;
         Application.DoEvents();

         DoMove();
      }

      #endregion

      #region Select Task
      private void pageSelectTask_BeforePageDisplayed(object sender, WizardCancelPageChangeEventArgs e)
      {
         if (e.PageChangeSource == eWizardPageChangeSource.Code && e.OldPage == pageSummary)
         {
            e.NewPage.BackButtonVisible = eWizardButtonState.False;
         }
      }
      #endregion

      #region Servers

      private void WizardPageServerInformation_NextButtonClick(object sender, CancelEventArgs e)
      {
         try
         {
            if (textSourceServer.Text.Trim().Length == 0)
            {
               Messaging.ShowError(ProductConstants.PromptMustSpecifySourceServer);
               e.Cancel = true;
               return;
            }
            
            if (comboSourceDatabase.Text.Trim().Length == 0)
            {
               Messaging.ShowError(ProductConstants.PromptMustSpecifyDatabase, ProductConstants.PromptMustSpecifyDatabaseCaption);
               e.Cancel = true;
               return;
            }

            if (_Task == TaskToPerform.CloneDatabaseToSameInstance && comboSourceDatabase.Text.ToUpperInvariant() == textClonedDatabaseName.Text.ToUpperInvariant())
            {
                Messaging.ShowError(ProductConstants.PromptMustSpecifyDifferentDatabaseName, ProductConstants.PromptMustSpecifyDifferentDatabaseNameCaption);
                e.Cancel = true;
                return;
            }

            // Fix problem with hitting enter when in Source Server field and not resetting server correctly
            if (_SourceServerCachedValue != textSourceServer.Text)
            {
               _SourceServer = null;
            }

            // Fix problem with hitting enter when in Destination Server field and not resetting server correctly
            if (_DestinationServerCachedValue != textDestinationServer.Text)
            {
               _DestinationServer = null;
            }

            if (_Task == TaskToPerform.MoveDataFilesOnly || _Task == TaskToPerform.CloneDatabaseToSameInstance)
            {
               if (textSourceServer.Text.Trim().Length > 0 && _SourceServer == null)
               {
                  InitializeServer(ref _SourceServer, textSourceServer.Text, _SourceServerSqlCredentials);
               }
               InitializeServer(ref _DestinationServer, _SourceServer.Name, _SourceServerSqlCredentials);
            }
            else
            {
               if (textDestinationServer.Text.Trim().Length == 0)
               {
                  Messaging.ShowError(ProductConstants.PromptMustSpecifyDestinationServer);
                  e.Cancel = true;
                  return;
               }

               if (_SourceServer == null || _DestinationServer == null)
               {
                  InitializeServers();
               }
            

                    if (!Utility.IsValidOperation(_SourceServer, _DestinationServer, false))
                    {
                        //  Messaging.ShowError(ProductConstants.ErrorNotSupportedSqlCombination);
                        SQLVersion sourceServerName = SQLVersion.FromVersion(_SourceServer.Version);
                        SQLVersion destinationServerName = SQLVersion.FromVersion(_DestinationServer.Version);
                        if (Messaging.ShowVersion(string.Format(ProductConstants.ErrorVersionNotSupported,sourceServerName.Name, destinationServerName.Name)) == DialogResult.Yes)
                        {
                            e.Cancel = false;
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                //SQLADMI -1603
                //Get sqlserver versions.
               GetSQLServerEditions(_SourceServer, _DestinationServer);

                //Check is valid edition or not.
               if (!(Utility.IsValidEdition(_SourceVersion,_DestinationVersion)))
               {
                       // Messaging.ShowError(String.Format("The requested SQL Server Edition combination, SourceServer:{0} and DestinationServer:{1} are not compatible.", SourceVersion.Edition, DestinationVersion.Edition));
                        if (Messaging.ShowVersion(string.Format(ProductConstants.ErrorEditionNotMatch, _SourceServer.Edition, _DestinationServer.Edition)) == DialogResult.Yes)
                        {
                            e.Cancel = false;
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }

               logger.Info("Checking server net name");
               try
               {
                   if (_SourceServer.Information.ComputerNamePhysicalNetBIOS == _DestinationServer.Information.ComputerNamePhysicalNetBIOS &&
                      _SourceServer.InstanceName == _DestinationServer.InstanceName)
                   {
                       Messaging.ShowError(ProductConstants.PromptSqlInstancesMustBeDifferent);
                       e.Cancel = true;
                       return;
                   }
               }
               catch (Exception ex) //log the error wihtout aborting the move
               {
                   logger.Error("Failed to compare server\\instance names: ", ex);
               }

            }

            if (!_SourceServer.Databases.Contains(comboSourceDatabase.Text))
            {
               Messaging.ShowError(ProductConstants.PromptDatabaseDoesNotExist);
               e.Cancel = true;
               return;
            }
            if ((_SourceServer.Databases[comboSourceDatabase.Text].Status & DatabaseStatus.Standby) == DatabaseStatus.Standby)
            {
               if (Messaging.ShowConfirmation(DatabaseMoverLibrary.ProductConstants.PromptStandbyMode, DatabaseMoverLibrary.ProductConstants.PromptActiveConnectionsCaption) == DialogResult.No)
               {
                  e.Cancel = true;
                  return;
               }
            }
         }
         catch(Exception exc)
         {
            logger.Error("Error gathering Server information", exc);
            Messaging.ShowException("Server information", exc);
            e.Cancel = true;
         }
      }

      private void GetSQLServerEditions(Server sourceServer, Server destinationServer)
      {
          using (SqlConnection _Connection = Connection.OpenConnection(sourceServer.Name, _SourceServerSqlCredentials))
          {
              SQLVersion.TryParse(SQLHelpers.GetSqlVersionString(_Connection), out _SourceVersion);
          }

          using (SqlConnection _Connection = Connection.OpenConnection(destinationServer.Name, _DestinationServerSqlCredentials))
          {
              SQLVersion.TryParse(SQLHelpers.GetSqlVersionString(_Connection), out _DestinationVersion);
          }
            Connection.Impersonate(null);
      }

      
      

      private void WizardPageServerInformation_BeforePageDisplayed(object sender, DevComponents.DotNetBar.WizardCancelPageChangeEventArgs e)
      {
         labelClonedDatabaseName.Visible = textClonedDatabaseName.Visible = false;

         if ( _Task == TaskToPerform.MoveDataFilesOnly || _Task == TaskToPerform.CloneDatabaseToSameInstance)
         {
            labelDestinationServer.Visible        = false;
            textDestinationServer.Visible         = false;
            buttonBrowseDestinationServer.Visible = false;
            buttonDestinationCredentials.Visible  = false;
            comboDestinationDatabase.Visible      = false;
            labelDestinationDatabase.Visible      = false;
            
            labelSourceServer.Text   = "&SQL Server";
            labelSourceDatabase.Text = "&Database";

            pageServerInformation.PageDescription = "Specify the SQL Server and Database";

            if (_Task == TaskToPerform.MoveDataFilesOnly)
            {
                pageServerInformation.PageTitle = "Step 2: Specify the database that you will be moving.";
            }
            else
            {
                pageServerInformation.PageTitle = "Step 2: Specify the database that you will be copying.";
                labelClonedDatabaseName.Visible = textClonedDatabaseName.Visible = true;
            }
         }
         else
         {
            labelDestinationServer.Visible        = true;
            textDestinationServer.Visible         = true;
            buttonBrowseDestinationServer.Visible = true;
            buttonDestinationCredentials.Visible  = true;
            comboDestinationDatabase.Visible      = true;
            labelDestinationDatabase.Visible      = true;
                        
            labelSourceServer.Text = "Source &SQL Server";
            labelSourceDatabase.Text = "Source &Database";

            pageServerInformation.PageTitle = "Step 2: Specify the source and destination servers plus databases for the selected operation";
            pageServerInformation.PageDescription = "Specify the SQL Servers and Databases";
         }

         checkboxDeleteSourceFiles.Visible = checkboxIncludeLogFiles.Visible = true;

         // If moving back and changing task and then moving forward, these could be incorrect, so clear them so they get rebuilt
         if (_SourceServer != null && !_SourceServer.Name.Equals(textSourceServer.Text, StringComparison.CurrentCultureIgnoreCase))
         {
            _SourceServer = null;
         }

         if (_DestinationServer != null && !_DestinationServer.Name.Equals(textDestinationServer.Text, StringComparison.CurrentCultureIgnoreCase))
         {
            _DestinationServer = null;
         }
      }

      private void comboSourceDatabase_SelectedIndexChanged(object sender, EventArgs e)
      {
         _FilesToMove.Clear();
      }

      private void comboDestinationDatabase_SelectedIndexChanged(object sender, EventArgs e)
      {
         _FilesToMove.Clear();
      }

      private void comboDestinationDatabase_TextChanged(object sender, EventArgs e)
      {
         _FilesToMove.Clear();
      }

      private void textClonedDatabaseName_TextChanged(object sender, EventArgs e)
      {
          _FilesToMove.Clear();
      }
      #endregion

      #region File options

      private void WizardPageFileOptions_NextButtonClick(object sender, CancelEventArgs e)
      {
         if (!OverwriteCheck())
         {
            e.Cancel = true;
            return;
         }
         try
         {
            Database _Database = _SourceServer.Databases[comboSourceDatabase.Text];

            if (_FilesToMove.Count == 0)
            {
               DataFilePicker.Clear();

               string _DestinationDirectory = Utility.GetSqlServerDefaultFilePath(_DestinationServer, DatabaseMoverFile.DatabaseFileType.Data);

               foreach (FileGroup _FileGroup in _Database.FileGroups)
               {
                  foreach (DataFile _DataFile in _FileGroup.Files)
                  {
                     DatabaseMoverFile _File = new DatabaseMoverFile(_SourceServer.Information.ComputerNamePhysicalNetBIOS, _DestinationServer.Information.ComputerNamePhysicalNetBIOS, _DataFile.FileName, _DataFile.Name, DatabaseMoverFile.DatabaseFileType.Data);

                     if (!AddFileToFilePicker(_File, _Database, _DestinationDirectory))
                     {
                        logger.ErrorFormat("Error accessing database file {0}", _DataFile.FileName);
                        Messaging.ShowError(ProductConstants.PromptUnableToAccessNetworkFiles);
                        e.Cancel = true;
                        return;
                     }
                  }
               }
            }

            if (checkboxIncludeLogFiles.Checked && !_FilesToMove.Exists(delegate(DatabaseMoverFile file) { return file.Type == DatabaseMoverFile.DatabaseFileType.Log; }))
            {
               LogFileCollection _LogFileCollection = _Database.LogFiles;
               string _DestinationDirectory = Utility.GetSqlServerDefaultFilePath(_DestinationServer, DatabaseMoverFile.DatabaseFileType.Log);

               foreach (LogFile _LogFile in _LogFileCollection)
               {
                  DatabaseMoverFile _File = new DatabaseMoverFile(_SourceServer.Information.ComputerNamePhysicalNetBIOS, _DestinationServer.Information.ComputerNamePhysicalNetBIOS, _LogFile.FileName, _LogFile.Name, DatabaseMoverFile.DatabaseFileType.Log);
                  if (!AddFileToFilePicker(_File, _Database, _DestinationDirectory))
                  {
                     logger.ErrorFormat("Error accessing log file {0}", _LogFile.FileName);
                     Messaging.ShowError(ProductConstants.PromptUnableToAccessNetworkFiles);
                     e.Cancel = true;
                     return;
                  }
               }
            }
         }
         catch (Exception ex)
         {
            logger.Error("Error accessing database files", ex);
            Messaging.ShowError(ProductConstants.PromptUnableToAccessNetworkFiles);
            e.Cancel = true;
            return;
         }
      }

      /// <summary>
      /// Adds a file to the file picker control, returns false if no access to the destination network share was possible.
      /// </summary>
      private bool AddFileToFilePicker(DatabaseMoverFile file, Database database, string destinationDirectory)
      {
         string _DestinationDatabase = (_Task == TaskToPerform.CloneDatabaseToSameInstance) ? textClonedDatabaseName.Text : comboDestinationDatabase.Text;

         if (_DestinationDatabase.Trim().Length > 0)
         {
            int _MatchIndex = file.DestinationFileName.ToUpperInvariant().IndexOf(database.Name.Trim().ToUpperInvariant());
            if (_MatchIndex >= 0)
            {
               file.DestinationFileName = file.DestinationFileName.Remove(_MatchIndex, database.Name.Trim().Length);
               file.DestinationFileName = file.DestinationFileName.Insert(_MatchIndex, _DestinationDatabase.Trim());
            }
            
            _MatchIndex = file.DestinationLogicalName.ToUpperInvariant().IndexOf(database.Name.Trim().ToUpperInvariant());
            if (_MatchIndex >= 0)
            {
               file.DestinationLogicalName = file.DestinationLogicalName.Remove(_MatchIndex, database.Name.Trim().Length);
               file.DestinationLogicalName = file.DestinationLogicalName.Insert(_MatchIndex, _DestinationDatabase.Trim());
            }
         }
         if (VerifyRemoteAccess(file.SourceServerName, file.SourceNetworkShare))
         {
            if (destinationDirectory.Length > 0)
            {
               file.DestinationDirectory = destinationDirectory;
            }
            _FilesToMove.Add(file);
            DataFilePicker.AddItem(file);
            return true;
         }

         return false;
      }

      private void WizardPageFileOptions_BeforePageDisplayed(object sender, WizardCancelPageChangeEventArgs e)
      {
         if (_Task == TaskToPerform.MoveDataFilesOnly || 
             _Task == TaskToPerform.CopyDatabaseToDifferentInstance || 
             _Task == TaskToPerform.CopyDatabaseToDifferentServer ||
             _Task == TaskToPerform.CloneDatabaseToSameInstance)
         {
            checkboxDeleteSourceFiles.Enabled = false;
         }
         else
         {
            checkboxDeleteSourceFiles.Enabled = true;
         }
      }

      private void pageFileOptions_AfterPageDisplayed(object sender, WizardPageChangeEventArgs e)
      {
         OverwriteCheck();
      }

      #endregion

      #region Destination Folder Page

      private void DataFilePicker_BrowseButtonClick(object sender, EventArgs e)
      {
         TextBoxX _Sender = sender as TextBoxX;
         if(_Sender != null)
         {
            DatabaseMoverFile _FileInfo = _Sender.Tag as DatabaseMoverFile;
            if (_FileInfo != null)
            {
               Cursor = Cursors.WaitCursor;
               string _OriginalDestination = _FileInfo.DestinationDirectory;
               if (_Sender.Text.Trim().Length > 0 && (Path.IsPathRooted(_Sender.Text.Trim()) || _Sender.Text.StartsWith(@"\\")))
               {
                   _FileInfo.DestinationDirectory = _Sender.Text;
               }

               List<string> _DestinationDrives = GetMappedServerDrives(_DestinationServer);

               if (_DestinationDrives.Count > 0)
               {
                  Form_FolderSelection _FolderSelect = new Form_FolderSelection(_DestinationServer.Information.ComputerNamePhysicalNetBIOS, 
                                    _DestinationDrives.ToArray(), _FileInfo.DestinationDirectory,
                                    (_DestinationServer.Information.ComputerNamePhysicalNetBIOS == Environment.MachineName));
                  if (_FolderSelect.ShowDialog() == DialogResult.OK)
                  {
                      _Sender.Text = _FolderSelect.SelectedFolder;
                  }
               }
               else
               {
                  _FileInfo.DestinationDirectory = _Sender.Text = _OriginalDestination; 
                  Messaging.ShowError("Network resource was not accessible");
               }
               Cursor = Cursors.Default;
            }
         }
      }

       private List<string> GetMappedServerDrives(Server server)
       {
           string _DriveCommand = "EXECUTE master.dbo.xp_fixeddrives";
           if (server.IsClustered)
           {
               if (SQLHelpers.Is2000(server.Information.Version.Major))
               {
                   _DriveCommand = "SELECT * FROM ::fn_servershareddrives()";
                   
               }
               else
               {
                   _DriveCommand = "SELECT * FROM sys.fn_servershareddrives()";
               }
           }

           List<string> _DestinationDrives = new List<string>();
           using (SqlCommand _Command = new SqlCommand(_DriveCommand, server.ConnectionContext.SqlConnectionObject))
           {
               if (_DestinationServer.ConnectionContext.SqlConnectionObject.State != ConnectionState.Open)
               {
                   _DestinationServer.ConnectionContext.SqlConnectionObject.Open();
               }
               using (SqlDataReader _Reader = _Command.ExecuteReader())
               {
                   while (_Reader.Read())
                   {
                       _DestinationDrives.Add(_Reader.GetString(0));
                   }
               }
              // _Command.Connection.Close();
           }
           if (server.Information.ComputerNamePhysicalNetBIOS != Environment.MachineName)  //no local
           {
               for (int i = _DestinationDrives.Count - 1; i >= 0; i--)//Verify access to each drive
               {
                   if (!VerifyRemoteAccess(server.Information.ComputerNamePhysicalNetBIOS, DatabaseMoverFile.ConvertLocalToAdminSharePath(server.Information.ComputerNamePhysicalNetBIOS, string.Format("{0}:\\", _DestinationDrives[i]))))
                   {
                       _DestinationDrives.RemoveAt(i);
                   }
               }
           }
           return _DestinationDrives;
       }

      private void pageTargetFolder_NextButtonClick(object sender, CancelEventArgs e)
      {
         if(!DataFilePicker.ValidateGrid())
         {
             e.Cancel = true;
             return;
         }
         Database _Database = _SourceServer.Databases[comboSourceDatabase.Text];

         _FilesToMove = DataFilePicker.Files;
         bool _DifferentDestinationPath = false;

         foreach (DatabaseMoverFile _File in _FilesToMove)
         {
            if (_Task == TaskToPerform.CloneDatabaseToSameInstance && _File.FullSourcePath.ToUpperInvariant() == _File.FullDestinationPath.ToUpperInvariant())
            {
                Messaging.ShowError(ProductConstants.ErrorMustHaveDifferentSourceAndDestination);
                e.Cancel = true;
                return;
            }
            if (_File.DestinationDirectory.Length == 0)
            {
               Messaging.ShowError(ProductConstants.ErrorSpecifyDestinationFolder);
               e.Cancel = true;
               return;
            }

            if (_File.DestinationNetworkShare.ToUpperInvariant() == _File.SourceNetworkShare.ToUpperInvariant()) //if destination is the same as the source
            {
               if (_Task == TaskToPerform.CopyDatabaseToDifferentInstance)
               {
                  Messaging.ShowError(ProductConstants.ErrorDatabaseMoveMustHaveDifferentDestination);
                  e.Cancel = true;
                  return;
               }
               checkboxDeleteSourceFiles.Checked = false;
            }
            else
            {
               _DifferentDestinationPath = true;
            }

            if (!VerifyRemoteAccess(_File.DestinationServerName, _File.DestinationNetworkShare))
            {
               Messaging.ShowError(string.Format(ProductConstants.PromptUnableToReachAdminShare, Path.GetDirectoryName(_File.DestinationNetworkShare), _File.DestinationServerName));
               e.Cancel = true;
               return;
            }
         }
         if (_Task == TaskToPerform.MoveDataFilesOnly && !_DifferentDestinationPath)
         {
            Messaging.ShowError(ProductConstants.PromptDestinationFilesMustChange);
            e.Cancel = true;
            return;
         }
      }

      private bool VerifyRemoteAccess(string serverName, string remotePath)
      {
         remotePath = Path.GetDirectoryName(remotePath);
         if (new DirectoryInfo(remotePath).Exists)
         {
            return true;
         }
         else
         {
            Form_NetworkLogin dlg = new Form_NetworkLogin(serverName, remotePath);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               _CreatedShares.Add(dlg.Share);
               if (!new DirectoryInfo(remotePath).Exists)
               {
                  try
                  {
                     Directory.CreateDirectory(remotePath);
                     return true;
                  }
                  catch
                  {
                     return false;
                  }
               }
               return true;
            }
            return false;
         }
      }

      #endregion

      #region Missing logins
      private void WizardPagePermissions_BeforePageDisplayed(object sender, DevComponents.DotNetBar.WizardCancelPageChangeEventArgs e)
      {
        _MissingLogins.Clear();
        checkApplyMappingToAllDestinationDatabases.Enabled = checkApplyMappingToAllDestinationDatabases.Checked = false;
        ListMissingLogins.Items.Clear();
        List<Login> _Logins =  Utility.FindMissingLogins(_SourceServer, comboSourceDatabase.Text, _DestinationServer);

        if (_Logins.Count == 0)
        {
          labelLoginsSynchronized.Visible = true;
           labelLoginsSynchronized.Text = ProductConstants.PromptAllSourceLoginsSyncronized;
           linkClearAllLogins.Visible = linkSelectAllLogins.Visible = false;
        }
        else
        {
           ListMissingLogins.Visible = true;
           labelLoginsSynchronized.Visible = false;
           _Logins.ForEach(delegate(Login login)
                {
                   ListMissingLogins.Items.Add(login, true);
                });
        }
      }

      private void WizardPagePermissions_NextButtonClick(object sender, CancelEventArgs e)
      {
         foreach (Object _Item in ListMissingLogins.CheckedItems)
         {
             Login _LoginToadd = (Login)_Item;
             if (_MissingLogins.Find(delegate(Login item) { return item.Name == _LoginToadd.Name; }) != null)
             {
                 continue;
             }
            _MissingLogins.Add(_LoginToadd);
         }
      }
      #endregion

      #region Summary

      private void WizardPageSummary_BeforePageDisplayed(object sender, DevComponents.DotNetBar.WizardCancelPageChangeEventArgs e)
      {
         labelSummarySourceDatabaseValue.Text = textSourceServer.Text + "\\" + comboSourceDatabase.Text;

         string targetDB = (comboDestinationDatabase.Text != "" ) ? comboDestinationDatabase.Text : comboSourceDatabase.Text;
         LabelSummaryDestinationDatabaseValue.Text = textDestinationServer.Text + "\\" + targetDB;
                
         LabelSummaryIncludeLogFilesValue.Text = checkboxIncludeLogFiles.Checked.ToString();
         LabelSummaryDeleteSourceFilesValue.Text = checkboxDeleteSourceFiles.Checked.ToString();
         LabelSummaryConflictValue.Text = (!checkBoxOverwrite.Checked) ? ProductConstants.SummaryAbortOnConflict : ProductConstants.SummaryOverwriteOnConflict;
         
         switch (_Task)
         {
            case TaskToPerform.CopyDatabaseToDifferentInstance:
               LabelSummaryOperationTypeValue.Text = ProductConstants.SummaryTaskDatabaseCopyToOtherInstance;
               break;
            case TaskToPerform.CopyDatabaseToDifferentServer:
               LabelSummaryOperationTypeValue.Text = ProductConstants.SummaryTaskDatabaseCopyToOtherServer;
               break;
            case TaskToPerform.MoveDatabaseToDifferentInstance:
               LabelSummaryOperationTypeValue.Text = ProductConstants.SummaryTaskDatabaseMoveToOtherInstance;
               break;
            case TaskToPerform.MoveDatabaseToDifferentServer:
               LabelSummaryOperationTypeValue.Text = ProductConstants.SummaryTaskDatabaseMoveToOtherServer;
               break;
            case TaskToPerform.MoveDataFilesOnly:
               LabelSummaryOperationTypeValue.Text = ProductConstants.SummaryTaskDataFileMove;
               // Fix the destination name which could be left at anything because it isn't used for this task.
               LabelSummaryDestinationDatabaseValue.Text = labelSummarySourceDatabaseValue.Text;
               break;
            case TaskToPerform.CloneDatabaseToSameInstance:
               LabelSummaryOperationTypeValue.Text = ProductConstants.SummaryTaskCloneDatabase;
               LabelSummaryDestinationDatabaseValue.Text = textClonedDatabaseName.Text;
               break;
         }

      }

      #endregion

      #endregion

      #region Form functionality
      private void InitializeServers()
      {
         if (textSourceServer.Text.Trim().Length > 0 && _SourceServer == null)
         {
            InitializeServer(ref _SourceServer, textSourceServer.Text, _SourceServerSqlCredentials);
         }

         if (textDestinationServer.Text.Trim().Length > 0 && _DestinationServer == null)
         {
            InitializeServer(ref _DestinationServer, textDestinationServer.Text, _DestinationServerSqlCredentials);
         }
      }

      private void InitializeServer(ref Server server, string name, SQLCredentials credentials)
      {
            try
            {
                server = new Server(new ServerConnection(Connection.OpenConnection(name, credentials)));
            }
            catch (Exception exc)
            {
                Messaging.ShowException(string.Format("Initialize Server Connection: {0}", name), exc);
            }
            finally
            {
                Connection.Impersonate(null);
            }
        }

      private void checkboxIncludeLogFiles_CheckedChanged(object sender, EventArgs e)
      {
         if (!checkboxIncludeLogFiles.Checked)
         {
            for (int i = _FilesToMove.Count - 1; i >= 0; i--)
            {
               if (_FilesToMove[i].Type == DatabaseMoverFile.DatabaseFileType.Log)
               {
                  _FilesToMove.RemoveAt(i);
               }
            }
            DataFilePicker.ClearLogFiles();
         }
      }

      private void ResetValues()
      {
         _SourceServerSqlCredentials = null;
         _DestinationServerSqlCredentials = null;
         _SourceServer = null;
         _DestinationServer = null;
         _FilesToMove.Clear();
         
         _Task = TaskToPerform.CopyDatabaseToDifferentServer;
         optionCopyDatabase.Checked = true;

         textSourceServer.Text = ProductConstants.ServersLocal;
         comboSourceDatabase.Items.Clear();
         comboSourceDatabase.Text = "";

         textDestinationServer.Text = ProductConstants.ServersLocal;
         comboDestinationDatabase.Items.Clear();
         comboDestinationDatabase.Text = "";
         
         checkboxIncludeLogFiles.Checked = true;
         checkboxDeleteSourceFiles.Checked = false;
         checkboxDeleteSourceFiles.Enabled = true;
         checkBoxOverwrite.Checked = false;

         checkApplyMappingToAllDestinationDatabases.Checked = false;

         textClonedDatabaseName.Text = string.Empty;

         ResetDynamicValues();
      }

      private void ResetDynamicValues()
      {
         _MissingLogins.Clear();
         _TaskCompleteResults = null;

         ListMissingLogins.Items.Clear();
         textTaskLog.Text = "";
         linkClearAllLogins.Visible = linkSelectAllLogins.Visible = true;
         
         _LoadedSteps.Clear();
         ProgressList.NumberOfSteps = 0;
         for (int i = 1; i <= 6; i++)
         {
            ProgressList.SetStepText(i, string.Empty);
         }
         WizardDatabaseMove.CancelButtonText = ProductConstants.CancelButtonExit;

         pageSummary.BackButtonEnabled =
            pageSummary.CancelButtonEnabled =
            pageSummary.NextButtonEnabled =
            pageSummary.FinishButtonEnabled =
            DevComponents.DotNetBar.eWizardButtonState.True;
      }

      private bool OverwriteCheck()
      {
         if ( _Task == TaskToPerform.CopyDatabaseToDifferentServer
           || _Task == TaskToPerform.CopyDatabaseToDifferentInstance
           || _Task == TaskToPerform.MoveDatabaseToDifferentServer
           || _Task == TaskToPerform.MoveDatabaseToDifferentInstance)
         {
            try
            {
               string _DestinationDatabase = (comboDestinationDatabase.Text.Trim().Length > 0) ? comboDestinationDatabase.Text : comboSourceDatabase.Text;
               if (_DestinationServer.Databases.Contains(_DestinationDatabase) && !checkBoxOverwrite.Checked)
               {
                  Messaging.ShowInformation(ProductConstants.PromptDestinationDatabaseAlreadyExists);
                  return false;
               }
            }
            catch (Exception ex)
            {
               logger.Error("Error checking if destination database exists. ", ex);
               Messaging.ShowException("Check destination database", ex);
               return false;
            }
         }
         return true;
      }

      private void textSourceServer_Leave(object sender, EventArgs e)
      {
         if (WizardDatabaseMove.SelectedPage == pageServerInformation)
         {
            if (_SourceServerCachedValue != textSourceServer.Text) 
            {
               _SourceServer = null;
               _FilesToMove.Clear();
               if (comboSourceDatabase.Items.Count > 0)
               {
                  comboSourceDatabase.Items.Clear();
               }
            }
         }
      }
      
      private void textDestinationServer_Leave(object sender, EventArgs e)
      {
         if (WizardDatabaseMove.SelectedPage == pageServerInformation)
         {
            if (_DestinationServerCachedValue != textDestinationServer.Text)
            {
               //_DestinationServer = null;
               //_FilesToMove.Clear();
               if (comboDestinationDatabase.Items.Count > 0)
               {
                  comboDestinationDatabase.Items.Clear();
               }
            }
         }
      }

      private void LoadSourceDatabases()
      {
         _SourceServerCachedValue = textSourceServer.Text;
         if (comboSourceDatabase.Enabled)
         {
            InitializeServer(ref _SourceServer, textSourceServer.Text, _SourceServerSqlCredentials);
            if (_SourceServer != null)
            {
                LoadDatabases(comboSourceDatabase, _SourceServer, true);
            }
         }
      }
      
      private void LoadDestinationDatabases()
      {
         _DestinationServerCachedValue = textDestinationServer.Text;
         InitializeServer(ref _DestinationServer, textDestinationServer.Text, _DestinationServerSqlCredentials);
         if (_DestinationServer != null)
         {
             LoadDatabases(comboDestinationDatabase, _DestinationServer, false);
         }
      }

      private void comboDatabase_Enter(object sender, EventArgs e)
      {
         VerifyAndLoadSource();
      }

      private void comboDestinationDatabase_Enter(object sender, EventArgs e)
      {
         VerifyAndLoadDestination();
      }

      /// <summary>
      /// Verifies that the correct source server is loaded and loads it if needed.
      /// </summary>
      private void VerifyAndLoadSource()
      {
         if (_SourceServer == null || _SourceServerCachedValue != textSourceServer.Text)
         {
            _SourceServer = null;
            _FilesToMove.Clear();
            LoadSourceDatabases();
         }
         else if (comboSourceDatabase.Items.Count == 0)
         {
            LoadDatabases(comboSourceDatabase, _SourceServer, true);
         }
      }

      /// <summary>
      /// Verifies that the correct destination server is loaded and loads it if needed.
      /// </summary>
      private void VerifyAndLoadDestination()
      {
         if (_DestinationServer == null || _DestinationServerCachedValue != textDestinationServer.Text)
         {
            _DestinationServer = null;
            _FilesToMove.Clear();
            LoadDestinationDatabases();
         }
         else if (comboDestinationDatabase.Items.Count == 0)
         {
            LoadDatabases(comboDestinationDatabase, _DestinationServer, false);
         }
      }

      private void linkSelectAllLogins_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         for (int i = 0; i < ListMissingLogins.Items.Count; i++)
         {
            ListMissingLogins.SetItemCheckState(i, CheckState.Checked);
         }
      }

      private void linkClearAllLogins_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         for (int i = 0; i < ListMissingLogins.Items.Count; i++)
         {
            ListMissingLogins.SetItemCheckState(i, CheckState.Unchecked);
         }
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         CloseCreatedShares();
      }

      private void CloseCreatedShares()
      {
         if (_CreatedShares.Count > 0)
         {
            foreach (string share in _CreatedShares)
            {
               uint returnCode = NetUseDel(null, share, 2);

               if (returnCode != 0)
               {
                  CoreGlobals.traceLog.ErrorFormat("Error attempting to remove share {0}: {1}", share, returnCode);
               }
            }
            // clear the shares so it won't keep trying again if there was an error
            _CreatedShares.Clear();
         }
      }

      #endregion

      #region Threading Helpers
      delegate void StringParameterDelegate(string value);
      delegate void ChangePageDelegate(WizardPage newPage);
      
      private void ChangeWizardPage(WizardPage newPage)
      {
         if (InvokeRequired)
         {
            BeginInvoke(new ChangePageDelegate(ChangeWizardPage), new object[] { newPage });
            return;
         }
         WizardDatabaseMove.SelectedPage = newPage;
      }
      #endregion

      #region Enum
      private enum TaskToPerform
      {
         CopyDatabaseToDifferentServer,
         CopyDatabaseToDifferentInstance,
         MoveDatabaseToDifferentServer,
         MoveDatabaseToDifferentInstance,
         MoveDataFilesOnly,
         CloneDatabaseToSameInstance
      }
      #endregion

      #region Results Panel 

      private void buttonClose_Click( object sender, EventArgs e )
      {
         if (Messaging.ShowConfirmation(string.Format(ProductConstants.PromptExitApplication, CoreGlobals.productName)) == DialogResult.Yes)
         {
            Close();
         }
      }

      private void buttonDoAnotherScan_Click( object sender, EventArgs e )
      {
         Connection.Impersonate(null);
         if (Messaging.ShowConfirmation(ProductConstants.PromptResetWizardValues) == DialogResult.Yes)
         {
            ResetValues();
         }
         else
         {
            buttonDoAnotherScan.Enabled = false;
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            if (_SourceServer != null)
            {
               string _SelectedDatabase = comboSourceDatabase.Text;
               LoadSourceDatabases();
               if (comboSourceDatabase.Items.Contains(_SelectedDatabase))
               {
                  comboSourceDatabase.Text = _SelectedDatabase;
               }
            }

            if (_Task == TaskToPerform.MoveDataFilesOnly || _Task == TaskToPerform.CloneDatabaseToSameInstance)
            {
               // set the destination server and database to match the source if the last operation was single server
               // so that it will show up that way if the user changes the operation on the next pass
               textDestinationServer.Text = textSourceServer.Text;
               if (_SourceServerSqlCredentials == null)
               {
                  _DestinationServerSqlCredentials = null;
               }
               else
               {
                  _DestinationServerSqlCredentials = new SQLCredentials(_SourceServerSqlCredentials);
               }
               InitializeServer(ref _DestinationServer, textDestinationServer.Text, _DestinationServerSqlCredentials);
               comboDestinationDatabase.Text = comboSourceDatabase.Text;
            }

            if (_DestinationServer != null)
            {
               string _SelectedDatabase = comboDestinationDatabase.Text;
               LoadDestinationDatabases();
               if (comboDestinationDatabase.Items.Contains(_SelectedDatabase))
               {
                  comboDestinationDatabase.Text = _SelectedDatabase;
               }
            }
            buttonDoAnotherScan.Enabled = true;
            ResetDynamicValues();
            Cursor = Cursors.Default;
         }

         ChangeWizardPage(pageSelectTask);
         WizardDatabaseMove.BringToFront();
      }
      
      #endregion
      
      #region Move Engine      

      Utility _MoverUtility = null;
      TaskCompleteEventArgs _TaskCompleteResults;
      List<MoverStep> _LoadedSteps = new List<MoverStep>();
      MoverStep _CurrentStep = MoverStep.Initialize;

      private void DoMove()
      {
         string _DatabaseName = (comboSourceDatabase.Enabled) ? comboSourceDatabase.Text : string.Empty;
         string _RenamedDatabaseName = (comboDestinationDatabase.Text.Trim().Length == 0) ? _DatabaseName : comboDestinationDatabase.Text.Trim();
      
         // Prepare to perform task
         _MoverUtility = new Utility();
         _MoverUtility.TaskStatus += new EventHandler<StatusEventArgs>(Helper_TaskStatusChange);
         _MoverUtility.TaskComplete += new EventHandler<TaskCompleteEventArgs>(Helper_TaskComplete);

         ProgressList.Initialize();
         _CurrentStep = MoverStep.Initialize;
         labelStatus.Visible = false;
         buttonDoAnotherScan.Enabled = false;
         buttonClose.Enabled = false;

         //--------------
         // Perform Task
         //--------------
         switch (_Task)
         {
            case TaskToPerform.CopyDatabaseToDifferentServer:
            case TaskToPerform.CopyDatabaseToDifferentInstance:
               MoveDatabase(_SourceServer, _DestinationServer, _DatabaseName, _FilesToMove, _MissingLogins, checkboxDeleteSourceFiles.Checked, _RenamedDatabaseName, checkBoxOverwrite.Checked, true, checkApplyMappingToAllDestinationDatabases.Checked);
               break;
            case TaskToPerform.MoveDatabaseToDifferentServer:
            case TaskToPerform.MoveDatabaseToDifferentInstance:
                MoveDatabase(_SourceServer, _DestinationServer, _DatabaseName, _FilesToMove, _MissingLogins, checkboxDeleteSourceFiles.Checked, _RenamedDatabaseName, checkBoxOverwrite.Checked, false, checkApplyMappingToAllDestinationDatabases.Checked);
               break;
            case TaskToPerform.MoveDataFilesOnly:
               MoveDataFiles(_SourceServer, _DatabaseName, _FilesToMove, checkboxDeleteSourceFiles.Checked);
               break;
            case TaskToPerform.CloneDatabaseToSameInstance:
                MoveDatabase(_SourceServer, _DestinationServer, _DatabaseName, _FilesToMove, _MissingLogins, false, textClonedDatabaseName.Text, checkBoxOverwrite.Checked, true, false);
                break;
         }
      }
      
      #region Engine Entry Points
      
      public void
         MoveDatabase(
            Server             sourceServer,
            Server             destinationServer,
            string             database,
            List<DatabaseMoverFile> fileList,
            List<Login>        loginList,
            bool               deleteSourceFiles,
            string             newDatabaseName,
            bool               overwriteIfExists,
            bool               keepSourceDatabase,
            bool               grantAccessToAllMatchingDatabases
         )
      {
         
         List<MoverStep> _Steps = new List<MoverStep>();
         _Steps.Add(MoverStep.Initialize);
         if (loginList.Count > 0)
         {
            _Steps.Add(MoverStep.SynchronizeLogins);
         }
         _Steps.Add(MoverStep.DetachDatabase);


         if (sourceServer.Information.ComputerNamePhysicalNetBIOS == destinationServer.Information.ComputerNamePhysicalNetBIOS)
         {
            foreach (DatabaseMoverFile _File in fileList)
            {
               if (_File.SourceNetworkShare != _File.DestinationNetworkShare)
               {
                  _Steps.Add(MoverStep.CopyFiles);
                  break;
               }
            }
         }
         else
         {
            _Steps.Add(MoverStep.CopyFiles);
         }
         _Steps.Add(MoverStep.AttachDatabase);
         if (grantAccessToAllMatchingDatabases)
         {
             _Steps.Add(MoverStep.ApplyDatabasePermissions);
         }

         LoadSteps(_Steps);
         Application.DoEvents();

         StartThread(delegate() { _MoverUtility.MoveDatabase(sourceServer, destinationServer, database, fileList, loginList, deleteSourceFiles, newDatabaseName, overwriteIfExists, keepSourceDatabase, grantAccessToAllMatchingDatabases,_SourceServerSqlCredentials,_DestinationServerSqlCredentials); });
      }

      public void MoveDataFiles(Server server, string database, List<DatabaseMoverFile> dataFiles, bool deleteSourceFiles)
      {
         List<MoverStep> _Steps = new List<MoverStep>();
         _Steps.Add(MoverStep.Initialize);
         _Steps.Add(MoverStep.DetachDatabase);
         _Steps.Add(MoverStep.CopyFiles);
         _Steps.Add(MoverStep.AttachDatabase);
         
         LoadSteps(_Steps);
         Application.DoEvents();
         
         StartThread(delegate() { _MoverUtility.MoveDataFiles(server, database, dataFiles, deleteSourceFiles); });
      }
      
      #endregion
      
      #region Engine Worker Routines
      
      private void StartThread(ThreadStart threadStart)
      {
         Thread _ExecutionThread = new Thread(threadStart);
         _ExecutionThread.IsBackground = true;
         _ExecutionThread.Start();
      }

      private void LoadSteps(List<MoverStep> steps)
      {
         for (int i = 0; i < steps.Count; i++)
			{
            _LoadedSteps.Add(steps[i]);
            switch (steps[i])
            {
               case MoverStep.Initialize:
                  ProgressList.SetStepText(i + 1, "Initialize");
                  break;
               case MoverStep.RenameExistingDestination:
                  ProgressList.SetStepText(i + 1, "Rename Destination Database");
                  break;
               case MoverStep.SynchronizeLogins:
                  ProgressList.SetStepText(i + 1, "Synchronize Login Information");
                  break;
               case MoverStep.DetachDatabase:
                  ProgressList.SetStepText(i + 1, "Detach Database");
                  break;
               case MoverStep.AttachDatabase:
                  ProgressList.SetStepText(i + 1, "Attach Database");
                  break;
               case MoverStep.SetDefaultDatabase:
                  ProgressList.SetStepText(i + 1, "Set Default Database");
                  break;
               case MoverStep.CopyFiles:
                  ProgressList.SetStepText(i+1, "Copy Files");
                  break;
               case MoverStep.DeleteSource:
                  ProgressList.SetStepText(i + 1, "Delete Source Files");
                  break;
               case MoverStep.ApplyDatabasePermissions:
                  ProgressList.SetStepText(i + 1, "Apply Database Permissions");
                  break;
            }
			}
			
			ProgressList.NumberOfSteps = steps.Count;

         if (steps.Count < 6)
         {
            for (int i = steps.Count + 1; i <= 6; i++)
            {
               ProgressList.SetStepText(i, string.Empty);
            }
         }

         ProgressList.SetStepStatus( 1,Idera.SqlAdminToolset.Core.ToolProgressListMini.StepStatus.Working);
      }

      private bool SetStepStatus(MoverStep step, Idera.SqlAdminToolset.Core.ToolProgressListMini.StepStatus status)
      {
         if (_LoadedSteps.Exists(delegate(MoverStep moverStep) { return moverStep == step; }))
         {
            int _Index = _LoadedSteps.FindIndex(delegate(MoverStep moverStep) { return moverStep == step; });
            ProgressList.SetStepStatus(_Index+1, status);
            return true;
         }
         return false;
      }

      #endregion

      #region Engine Event Handlers
      
      void Helper_TaskComplete(object sender, TaskCompleteEventArgs e)
      {
         _TaskCompleteResults = e;
         EnableStatus(true);
      }

      private void Helper_TaskStatusChange(object sender, StatusEventArgs e)
      {
         UpdateTaskLog(e.Description);
         if (e.Step == MoverStep.CompleteFailed)
         {
            SetStepStatus(_CurrentStep, Idera.SqlAdminToolset.Core.ToolProgressListMini.StepStatus.Error);
         }
         else if (e.Step != _CurrentStep || e.Step == MoverStep.CompleteSuccess)
         {
            SetStepStatus(_CurrentStep, Idera.SqlAdminToolset.Core.ToolProgressListMini.StepStatus.OK);
            _CurrentStep = e.Step;
            SetStepStatus(e.Step, Idera.SqlAdminToolset.Core.ToolProgressListMini.StepStatus.Working);
         }
      }
      #endregion
      
      delegate void EnableStatusDelegate(bool enable);

      private void EnableStatus(bool enable)
      {
         if (InvokeRequired)
         {
            BeginInvoke(new EnableStatusDelegate(EnableStatus), new object[] { enable });
            return;
         }
         labelStatus.Visible         = enable;
         labelStatus.Text            = _TaskCompleteResults.Success ? ProductConstants.ResultsSuccess : ProductConstants.ResultsFailed;
         buttonDoAnotherScan.Enabled = true;
         buttonClose.Enabled         = true;

            using (SqlConnection sconn = Connection.OpenConnection(_SourceServer.Name, _SourceServerSqlCredentials))
            {
                using (SqlConnection dconn = Connection.OpenConnection(_DestinationServer.Name, _DestinationServerSqlCredentials))
                {
                   
                    string desinationDb = string.IsNullOrEmpty(comboDestinationDatabase.Text) ? comboSourceDatabase.Text : comboDestinationDatabase.Text;
                    if (_Task == TaskToPerform.MoveDataFilesOnly || _Task == TaskToPerform.CloneDatabaseToSameInstance)
                    {
                        desinationDb = string.IsNullOrEmpty(textClonedDatabaseName.Text) ? comboSourceDatabase.Text : textClonedDatabaseName.Text;
                    }
                    if (brokerEnable == true)
                    {
                        SQLHelpers.updateSetting(comboSourceDatabase.Text, sconn);
                        SQLHelpers.updateSetting(desinationDb, dconn);
                    }
                    if (TrustWorthy == true)
                    {
                        SQLHelpers.updateTrustworthy(comboSourceDatabase.Text, sconn);
                        SQLHelpers.updateTrustworthy(desinationDb, dconn);
                    }
                    if (HonorBroker == true && SQLHelpers.Is2008orGreater(_SourceServer.VersionMajor))
                    {
                        SQLHelpers.updateHonorBrker(comboSourceDatabase.Text, sconn);
                        SQLHelpers.updateHonorBrker(desinationDb, dconn);
                    }
                }
            }
        }

      delegate void TaskLogUpdateDelegate(string value);

      private void UpdateTaskLog(string value)
      {
         if (InvokeRequired)
         {
            BeginInvoke(new TaskLogUpdateDelegate(UpdateTaskLog), new object[] { value });
            return;
         }
         textTaskLog.Text += DateTime.Now.ToLongTimeString() + ": " + value + Environment.NewLine;
      }

      #endregion     

      [DllImport("NetApi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
      internal static extern UInt32 NetUseDel(
        string UncServerName,
        string UseName,
        UInt32 ForceCond);

      private void ShowF1Help(object sender, HelpEventArgs hlpevent)
      {
         HelpMenu.ShowHelp();
      }

       private void ListMissingLogins_ItemCheck(object sender, ItemCheckEventArgs e)
       {
           if (e.NewValue == CheckState.Checked)
           {
               checkApplyMappingToAllDestinationDatabases.Enabled = true;
           }
           else
           {
               if (ListMissingLogins.CheckedItems.Count - 1 == 0)
               {
                   checkApplyMappingToAllDestinationDatabases.Enabled = checkApplyMappingToAllDestinationDatabases.Checked = false;
               }
           }
        }

      private void menuHelp_Click(object sender, EventArgs e)
      {
         
         base.OnClick(e);
      }

        private void ideraTitleBar1_LicenseInfoButtonClick(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }
    }
}

