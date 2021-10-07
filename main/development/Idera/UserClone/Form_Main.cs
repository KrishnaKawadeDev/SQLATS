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
using Microsoft.SqlServer.Management.Smo;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using IderaTrialExperienceCommon.Common;
using System.Linq;

namespace Idera.SqlAdminToolset.UserClone
{
    public partial class Form_Main : Form
    {
        #region Constructor

        public Form_Main()
        {
            InitializeComponent();
            this.Text = ideraTitleBar1.IderaProductNameText;
            ServerSelectionSource.Text = ServerSelectionDestination.Text = "(local)";
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
            ToggleControls(false);

            GetLastUsedValues();
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
            Launchpad.RunAndClose(this);
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

        private void menuManageServerGroups_Click(object sender, EventArgs e)
        {
            ToolsMenu.ManageServerGroups();
        }

        private void menuToolsetOptions_Click(object sender, EventArgs e)
        {
            ToolsMenu.ShowToolsetOptions();
        }

        private void menuLaunchpad_Click(object sender, EventArgs e)
        {
            ToolsMenu.RunLaunchpad(this);
        }

        #endregion

        #endregion

        #region Program Logic

        private Server _SourceServer = null;
        private Server _DestinationServer = null;
        private Dictionary<string, bool> _DatabaseList = new Dictionary<string, bool>();

        #region Control Events
        private void ServerSelectionSource_TextChanged(object sender, EventArgs e)
        {
            if (_SourceServer != null)
            {
                textSourceUser.Text = string.Empty;
                ToggleControls(false);
                _SourceServer = null;
                linkViewDatabases.Visible = false;
            }
            ServerSelectionDestination.Text = ServerSelectionSource.Text;
        }

        private void ServerSelectionDestination_TextChanged(object sender, EventArgs e)
        {
            if (_DestinationServer != null)
            {
                listDefaultDatabase.Items.Clear();
                _DestinationServer = null;
                ServerSelectionDestination.SqlCredentials = null;
            }
        }

        public Dictionary<string, bool> RefreshDatabaseList()
        {
            _DatabaseList.Clear();
            _SourceServer.Databases.Refresh();
            foreach (Database _Database in _SourceServer.Databases)
            {
                _DatabaseList.Add(_Database.Name, true);
            }
            return _DatabaseList;
        }

        private void linkViewDatabases_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_DatabaseList _DatabaseForm = new Form_DatabaseList(RefreshDatabaseList);
            _DatabaseForm.Databases = _DatabaseList;
            if (_DatabaseForm.ShowDialog() == DialogResult.OK)
            {
                _DatabaseList = _DatabaseForm.Databases;
            }
        }

        private void ToggleControls(bool enable)
        {
            textDestinationUserName.Enabled = enable;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            textScript.SelectAll();
            textScript.Copy();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textScript.Text.Trim().Length > 0)
            {
                SaveFileDialog _FileDialog = new SaveFileDialog();
                _FileDialog.Title = ProductConstants.FileDialogTitle;
                _FileDialog.AddExtension = true;
                _FileDialog.CheckPathExists = true;
                _FileDialog.DefaultExt = "sql";
                _FileDialog.FileName = string.Format("{0}.sql", textDestinationUserName.Text);
                _FileDialog.Filter = ProductConstants.FileDialogFilter;
                _FileDialog.InitialDirectory = Helpers.GetProductDirectory(true);

                if (_FileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (TextWriter _Writer = new StreamWriter(_FileDialog.FileName))
                    {
                        _Writer.Write(textScript.Text);
                        _Writer.Close();
                    }
                }
            }
        }

        private void checkSpecifyPassword_CheckedChanged(object sender, EventArgs e)
        {
            textPassword.Enabled = textConfirmPassword.Enabled = checkSpecifyPassword.Checked;
        }

        private void checkIncludeDatabaseAccess_CheckedChanged(object sender, EventArgs e)
        {
            linkViewDatabases.Visible = checkIncludeDatabaseAccess.Checked;
            if (checkIncludeDatabaseAccess.Checked)
            {
                checkIncludeSchemaOwnership.Enabled = checkIncludeObjectPermissions.Enabled = true;
            }
            else
            {
                checkIncludeSchemaOwnership.Checked = checkIncludeSchemaOwnership.Enabled =
                    checkIncludeObjectPermissions.Checked = checkIncludeObjectPermissions.Enabled = false;
            }
        }


        private void checkIncludeSchemaOwnership_CheckedChanged(object sender, EventArgs e)
        {
            if (checkIncludeSchemaOwnership.Checked)
            {
                Messaging.ShowWarning(ProductConstants.WarningSchemaOwnershipWillChange);
            }
        }

        private void Set2005OnlyCheckboxes()
        {
            bool _SetEnabled = true;
            if (_SourceServer != null && SQLHelpers.Is2000(_SourceServer.Information.Version.Major))
            {
                _SetEnabled = false;
            }
            if (_DestinationServer != null && SQLHelpers.Is2000(_DestinationServer.Information.Version.Major))
            {
                _SetEnabled = false;
            }
            if (_SetEnabled)
            {
                checkEnableLogin.Enabled = checkIncludeSchemaOwnership.Enabled = true;
            }
            else
            {
                checkEnableLogin.Enabled = checkIncludeSchemaOwnership.Enabled = false;
                checkEnableLogin.Checked = checkIncludeSchemaOwnership.Checked = false;
            }
        }

        private void ServerSelectionSource_Leave(object sender, EventArgs e)
        {
            if (_SourceServer == null && ServerSelectionSource.Text.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    BindSource();
                }
                catch (Exception exc)
                {
                    Messaging.ShowException("Connect to source server", exc);
                }
                Cursor = Cursors.Default;
            }
        }

        private void BindSource()
        {
            _SourceServer = UserCloneHelper.GetServerConnection(ServerSelectionSource.ServerList[0]);

            _DatabaseList.Clear();
            foreach (Database _Database in _SourceServer.Databases)
            {
                _DatabaseList.Add(_Database.Name, true);
            }
            linkViewDatabases.Visible = checkIncludeDatabaseAccess.Checked;

            Set2005OnlyCheckboxes();
            BindDestination();
            Connection.Impersonate(null);
        }

        private void ServerSelectionDestination_Leave(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                BindDestination();
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Connect to destination server", exc);
            }
            Cursor = Cursors.Default;
        }

        private void BindDestination()
        {
            if (_DestinationServer == null && ServerSelectionDestination.Text.Trim().Length > 0)
            {
                _DestinationServer = UserCloneHelper.GetServerConnection(ServerSelectionDestination.ServerList[0]);

                listDefaultDatabase.Items.Clear();
                foreach (Database _Database in _DestinationServer.Databases)
                {
                    listDefaultDatabase.Items.Add(_Database.Name);
                }

                if (_SourceServer != null && textSourceUser.Text.Length > 0)
                {
                    Login _SelectedLogin = _SourceServer.Logins[textSourceUser.Text.Split(';')[0]];
                    int _DefaultDatabaseIndex = listDefaultDatabase.FindString(_SelectedLogin.DefaultDatabase);
                    if (_DefaultDatabaseIndex > -1)
                    {
                        listDefaultDatabase.SelectedIndex = _DefaultDatabaseIndex;
                    }
                }
                Connection.Impersonate(null);
                Set2005OnlyCheckboxes();
            }
        }

        private void ServerSelectionSource_CredentialsChanged(object sender, EventArgs e)
        {
            textSourceUser.Text = string.Empty;
            ToggleControls(false);
            // _SourceServer = null;
            linkViewDatabases.Visible = false;
            // ServerSelectionDestination.Text = ServerSelectionSource.Text;
            if (ServerSelectionDestination.Text.Trim() == ServerSelectionSource.Text.Trim())
            {
                ServerSelectionDestination.SqlCredentials = new SQLCredentials(ServerSelectionSource.SqlCredentials);
            }

        }

        private void textSourceUser_ButtonCustomClick(object sender, EventArgs e)
        {
            try
            {
                BindSource();
                System.Security.Principal.WindowsPrincipal principal = (System.Security.Principal.WindowsPrincipal)Thread.CurrentPrincipal;
                string ComputerName = string.Empty;
                if (_SourceServer != null)
                {
                    _SourceServer.Logins.Refresh();
                    List<string> _Logins = new List<string>();
                    foreach (Login _Login in _SourceServer.Logins)
                    {
                        if (!_Login.Name.ToUpper().StartsWith("NT AUTHORITY") &&
                              (_Login.LoginType == LoginType.SqlLogin ||
                               _Login.LoginType == LoginType.WindowsUser ||
                               _Login.LoginType == LoginType.WindowsGroup) &&
                               !(_Login.Name.StartsWith("##MS") && _Login.Name.EndsWith("##"))
                               )
                        {
                            _Logins.Add(_Login.Name);
                        }
                    }
                    //foreach (Login _Login in _SourceServer.Logins)
                    //{

                    //    if (principal.Identity.Name == _Login.Name && ServerSelectionSource.ServerList[0].UseSqlAuthentication == false)
                    //    {
                    //        ComputerName = _Login.Name;
                    //        _Logins.Add(_Login.Name);
                    //    }
                    //    else
                    //    {


                    //        if (!_Login.Name.ToUpper().StartsWith("NT AUTHORITY") &&
                    //              (_Login.LoginType == LoginType.SqlLogin || _Login.LoginType == LoginType.WindowsUser
                    //              || _Login.LoginType == LoginType.WindowsGroup) &&
                    //               !(_Login.Name.StartsWith("##MS") && _Login.Name.EndsWith("##"))
                    //               )
                    //        {
                    //            try
                    //            {
                    //                if (ServerSelectionSource.ServerList[0].UseSqlAuthentication == false
                    //                    && _Login.LoginType == LoginType.WindowsUser
                    //              && _Login.LoginType == LoginType.WindowsGroup)
                    //                {
                    //                    textSourceUser.Text = "";
                    //                }
                    //                else if (ServerSelectionSource.ServerList[0].UseSqlAuthentication == true && _Login.LoginType == LoginType.SqlLogin
                    //                    && ServerSelectionDestination.SqlCredentials.useWindowsAuthentication == false)
                    //                {
                    //                    _Logins.Add(_Login.Name);
                    //                }
                    //                else if (ServerSelectionSource.ServerList[0].UseSqlAuthentication == false && _Login.LoginType == LoginType.WindowsUser)
                    //                {
                    //                    _Logins.Add(_Login.Name);
                    //                }
                    //            }
                    //            catch (Exception ex)
                    //            {
                    //                _Logins.Add(_Login.Name);
                    //            }
                    //        }
                    //    }
                    //}
                    if (_Logins.Count == 0)
                    {
                        Messaging.ShowError("No available logins found in the source server");
                        return;
                    }
                    Form_LoginList _LoginForm;
                    if (principal.Identity.Name == ComputerName)
                    {
                        _LoginForm = new Form_LoginList(_Logins);
                    }
                    else
                    {
                        // _Logins.Clear();
                        _LoginForm = new Form_LoginList(_Logins);
                    }
                    if (_LoginForm.ShowDialog() == DialogResult.OK)
                    {
                        textSourceUser.Text = _LoginForm.SelectedMultipleLogins; //_LoginForm.SelectedLogin;

                        Login _SelectedLogin = _SourceServer.Logins[_LoginForm.SelectedLogin];   //_SourceServer.Logins[textSourceUser.Text];
                        textDestinationUserName.Text = _LoginForm.SelectedMultipleLogins; //_SelectedLogin.Name;

                        int _DefaultDatabaseIndex = listDefaultDatabase.FindString(_SelectedLogin.DefaultDatabase);
                        if (_DefaultDatabaseIndex > -1)
                        {
                            listDefaultDatabase.SelectedIndex = _DefaultDatabaseIndex;
                        }

                        if (_SelectedLogin.LoginType == LoginType.WindowsUser || _SelectedLogin.LoginType == LoginType.WindowsGroup)
                        {
                            checkSpecifyPassword.Enabled = textPassword.Enabled = textConfirmPassword.Enabled = false;
                        }
                        else
                        {
                            checkSpecifyPassword.Enabled = true;
                            textPassword.Enabled = textConfirmPassword.Enabled = checkSpecifyPassword.Checked;
                        }

                        ToggleControls(true);
                    }
                }
                //else
                //{
                //    BindSource();
                //}
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Get login list", exc);
            }
        }

        #endregion

        private void buttonCloneUser_Click(object sender, EventArgs e)
        {
            try
            {
                CloneResults._listScript.Clear();
                CloneResults._userCloneList.Clear();
                if (ServerSelectionSource.Text.Trim().Length == 0)
                {
                    Messaging.ShowError(ProductConstants.ErrorMustEnterSourceServer);
                    return;
                }
                if (ServerSelectionSource.ServerList.Count > 1)
                {
                    Messaging.ShowError(ProductConstants.ErrorCanOnlyEnterOneServer);
                    return;
                }
                if (textSourceUser.Text.Trim().Length == 0)
                {
                    Messaging.ShowError(ProductConstants.ErrorMustEnterSourceUser);
                    return;
                }
                if (checkSpecifyPassword.Checked)
                {
                    if (textPassword.Text != textConfirmPassword.Text)
                    {
                        Messaging.ShowError(ProductConstants.ErrorPasswordMustMatch);
                        return;
                    }
                }

                if (ServerSelectionSource.Text.Trim().ToUpperInvariant() == ServerSelectionDestination.Text.Trim().ToUpperInvariant() &&
                   textSourceUser.Text.Trim().ToUpperInvariant() == textDestinationUserName.Text.Trim().ToUpperInvariant())
                {
                    Messaging.ShowError(ProductConstants.ErrorSourceAndDestinationUserMustBeDifferent);
                    return;
                }

                Progress.OperationText = ProductConstants.StatusInitializing;
                Progress.Visible = true;
                buttonCloneUser.Enabled = false;
                textScript.Clear();
                CloneOptions _Options = new CloneOptions();

                if (ServerSelectionDestination.Text.Trim().Length == 0)
                {
                    Progress.Visible = false;
                    buttonCloneUser.Enabled = true;
                    Messaging.ShowError(ProductConstants.ErrorMustEnterDestinationServer);
                    return;
                }
                if (ServerSelectionSource.ServerList.Count > 1)
                {
                    Progress.Visible = false;
                    buttonCloneUser.Enabled = true;
                    Messaging.ShowError(ProductConstants.ErrorCanOnlyEnterOneServer);
                    return;
                }
                if (_DestinationServer == null)
                {
                    _DestinationServer = UserCloneHelper.GetServerConnection(ServerSelectionDestination.ServerList[0]);
                }

                Set2005OnlyCheckboxes();

				 _Options.UserName = textDestinationUserName.Text;   

				// string[] DestinationUserName = textDestinationUserName.Text.Split(';');
				//foreach (string userName in DestinationUserName)
				//{
				//    if (checkSpecifyPassword.Checked)
				{
                    _Options.Password = textPassword.Text;
                }
                _Options.DefaultDatabase = listDefaultDatabase.Text;
                _Options.ApplyDatabasePermissions = checkIncludeDatabaseAccess.Checked;
                if (_Options.ApplyDatabasePermissions)
                {
                    foreach (KeyValuePair<string, bool> _Database in _DatabaseList)
                    {
                        if (_Database.Value)
                        {
                            _Options.Databases.Add(_Database.Key);
                        }
                    }
                }
                if (checkIncludeObjectPermissions.Enabled)
                {
                    _Options.ApplyObjectLevelPermissions = checkIncludeObjectPermissions.Checked;
                }
                _Options.EnableLogin = checkEnableLogin.Checked;
                _Options.IncludeSchemaOwnership = checkIncludeSchemaOwnership.Checked;
                _Options.SourceServer = ServerSelectionSource.ServerList[0];
                _Options.SourceUser = textSourceUser.Text; //CGVAK -Assigned the source user value 

				SaveLastUsedValues();

                ////  if (_DestinationServer.Logins.Contains(_Options.UserName))
                //if (_DestinationServer.Logins.Contains(userName))
                //{s
                //    Messaging.ShowError(ProductConstants.ErrorLoginExistsAtDestination);
                //    Progress.Visible = false;
                //    buttonCloneUser.Enabled = true;
                //    continue;
                //}
                //else
                //{
                _Options.DestinationServer = ServerSelectionDestination.ServerList[0];
                CloningWorker.RunWorkerAsync(_Options);
                // }
                // }
            }
            catch (Exception exc)
            {
                Progress.Visible = false;
                buttonCloneUser.Enabled = true;
                Messaging.ShowException(ProductConstants.productName, exc);
            }
            finally
            {
                //   Connection.Impersonate(null);
            }
        }

        #region Background workers
        private void PreviewWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CloneOptions _Options = (CloneOptions)e.Argument;
            Server _PreviewServer = UserCloneHelper.GetServerConnection(_Options.DestinationServer);
            if (SQLHelpers.Is2005(_PreviewServer.Information.VersionMajor))
            {
                _Options.Version = ScriptVersion.Sql2005;
            }
            if (SQLHelpers.Is2008(_PreviewServer.Information.VersionMajor))
            {
                _Options.Version = ScriptVersion.Sql2008;
            }
            if (SQLHelpers.Is2012(_PreviewServer.Information.VersionMajor))
            {
                _Options.Version = ScriptVersion.Sql2012;
            }
            if (SQLHelpers.Is2014(_PreviewServer.Information.VersionMajor))
            {
                _Options.Version = ScriptVersion.Sql2014;
            }
            if (SQLHelpers.Is2016orGreater(_PreviewServer.Information.VersionMajor))
            {
                _Options.Version = ScriptVersion.Sql2016;
            }
            if (SQLHelpers.Is2017orGreater(_PreviewServer.Information.VersionMajor))
            {
                _Options.Version = ScriptVersion.Sql2017;
            }
            if (SQLHelpers.Is2019orGreater(_PreviewServer.Information.VersionMajor))
            {
                _Options.Version = ScriptVersion.Sql2019;
            }
            //if (_Options.Version == ScriptVersion.Sql2005 && SQLHelpers.Is2008(_PreviewServer.Information.VersionMajor))
            //{
            //    _Options.Version = ScriptVersion.Sql2008;
            //}
            string[] logins = _Options.UserName.Split(';');
            for (int i = 0; i < logins.Length; i++)
            {
                _Options.UserName = logins[i].ToString();
                _Options.SourceUser = logins[i].ToString();
                e.Result = UserCloneHelper.GetCloneScript(_Options.SourceServer, textSourceUser.Text.ToString(), _Options, (BackgroundWorker)sender);
				//CGVAK -Passed  textSourceUser value
			}
		}

        private void PreviewWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateProgress((CloneProgress)e.ProgressPercentage);
        }

        private void PreviewWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Progress.Visible = false;
            buttonCloneUser.Enabled = true;
            if (e.Error != null)
            {
                Messaging.ShowException(ProductConstants.ErrorPreviewCaption, e.Error);
                return;
            }

            CloneResults _Results = e.Result as CloneResults;
            if (_Results != null)
            {
                if (_Results.IsRequestSuccessful)
                {
                    foreach (string Script in _Results.ListScript)
                    {
                        textScript.Text += Environment.NewLine + Script;
                    }
                    CloneResults._listScript.Clear();
                    CloneResults._userCloneList.Clear();
                    if (_Results.InaccessibleDatabases.Count > 0)
                    {
                        string _InaccessibleMessage = ProductConstants.ErrorUnableToConnectToSourceDatabase + Environment.NewLine + Environment.NewLine;
                        foreach (KeyValuePair<string, string> _Database in _Results.InaccessibleDatabases)
                        {
                            _InaccessibleMessage += string.Format("{0} - {1}", _Database.Key, _Database.Value) + Environment.NewLine;
                        }
                        Messaging.ShowWarning(_InaccessibleMessage);
                    }
                }
                else if (_Results.CloningException != null)
                {
                    Messaging.ShowException(ProductConstants.ErrorPreviewCaption, _Results.CloningException);
                    return;
                }
            }

        }

        private void CloningWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CloneOptions _Options = (CloneOptions)e.Argument;
            e.Result = UserCloneHelper.CloneUser(_Options.SourceServer, _Options.DestinationServer, _Options.SourceUser, _Options, (BackgroundWorker)sender);
        }

        private void CloningWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateProgress((CloneProgress)e.ProgressPercentage);
        }

        private void CloningWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Progress.Visible = false;
            buttonCloneUser.Enabled = true;
            Connection.Impersonate(null);
            if (e.Error != null)
            {
                Messaging.ShowException(ProductConstants.productName, e.Error);
                return;
            }

            CloneResults _Results = e.Result as CloneResults;
            if (_Results != null)
            {
                if (_Results.IsRequestSuccessful)
                {
                    foreach (string Script in _Results.ListScript)
                    {
                        textScript.Text += Environment.NewLine + Script;
                    }
                    CloneResults._listScript.Clear();

                    if (_Results.InaccessibleDatabases.Count > 0)
                    {
                        string _InaccessibleMessage = ProductConstants.StatusCloneCompleteWithIssues + ProductConstants.ErrorUnableToConnectToSourceDatabase + Environment.NewLine + Environment.NewLine;

                        foreach (KeyValuePair<string, string> _Database in _Results.InaccessibleDatabases)
                        {
                            _InaccessibleMessage += string.Format("{0} - {1}", _Database.Key, _Database.Value) + Environment.NewLine;
                        }

                        Messaging.ShowWarning(_InaccessibleMessage);
                    }
                    else
                    {
                        // Messaging.ShowInformation(ProductConstants.StatusCloneComplete);
                        string userNameAlreadyExist = string.Empty;
                        string userNameNewClone = string.Empty;
                        StringBuilder sb = new StringBuilder();
                        if (_Results.UserCloneList.Count > 0)
                        {
                            foreach (UserCloneStatus cloneResults in _Results.UserCloneList)
                            {
                                if (cloneResults.cloneStatus) userNameAlreadyExist += cloneResults.userName + ", ";
                                if (!cloneResults.cloneStatus) userNameNewClone += cloneResults.userName + ", ";
                            }

                            //Messaging.ShowError(ProductConstants.ErrorLoginExistsAtDestinationNewMsg(userNameAlreadyExist));
                            //if(_Results.UserCloneList.Where(uc => uc.cloneStatus == false).Count() > 0)  Messaging.ShowInformation(ProductConstants.StatusCloneCompleteNewMsg(userNameNewClone));

                            if (_Results.UserCloneList.Where(uc => uc.cloneStatus == false).Count() > 0)
                            {
                                if (_Results.UserCloneList.Where(uc => uc.cloneStatus == true).Count() > 0)
                                {
                                    sb.Append("Warning : Partial operation successful");
                                    sb.Append(Environment.NewLine);
                                    sb.Append(Environment.NewLine);
                                    sb.Append(ProductConstants.ErrorLoginExistsAtDestinationNewMsg(userNameAlreadyExist));
                                    sb.Append(Environment.NewLine);
                                    sb.Append(Environment.NewLine);
                                    sb.Append(ProductConstants.StatusCloneCompleteNewMsg(userNameNewClone));
                                    Messaging.ShowWarningDialog(sb.ToString());
                                }
                                else
                                {
                                    Messaging.ShowInformation(ProductConstants.StatusCloneComplete);
                                }
                            }
                            else
                            {
                                Messaging.ShowError(ProductConstants.ErrorLoginExistsAtDestinationNewMsg(userNameAlreadyExist));
                            }
                        }
                        else
                        {
                            //foreach (UserCloneStatus cloneResults in _Results.UserCloneList)
                            //    if (!cloneResults.cloneStatus) userNameNewClone += cloneResults.userName + ", ";
                            //Messaging.ShowInformation(ProductConstants.StatusCloneCompleteNewMsg(userNameNewClone));
                            Messaging.ShowInformation(ProductConstants.StatusCloneComplete);
                        }
                        CloneResults._userCloneList.Clear();
                    }
                }
                else if (_Results.CloningException != null)
                {
                    Messaging.ShowException(ProductConstants.productName, _Results.CloningException);

                    if (_Results.Script.Length > 0)
                    {
                        textScript.Text = _Results.Script;
                    }
                }
            }
        }

        private void UpdateProgress(CloneProgress progress)
        {
            switch (progress)
            {
                case CloneProgress.Initialize:
                    Progress.OperationText = "Initializing";
                    break;
                case CloneProgress.GenerateScript:
                    Progress.OperationText = "Generating Script";
                    break;
                case CloneProgress.VerifyVersionInformation:
                    Progress.OperationText = "Verifying SQL Version compatibility";
                    break;
                case CloneProgress.LoginScript:
                    Progress.OperationText = "Generating Login script";
                    break;
                case CloneProgress.DefaultDatabase:
                    Progress.OperationText = "Generating Default Database script";
                    break;
                case CloneProgress.DatabasePermissions:
                    Progress.OperationText = "Generating Database Permission script";
                    break;
                case CloneProgress.EnableLogin:
                    Progress.OperationText = "Generating Enable Login script";
                    break;
                case CloneProgress.ExecutingScript:
                    Progress.OperationText = "Executing SQL Script";
                    break;
            }
        }
        #endregion


        #endregion

        #region Create Scripts

        private void buttonCreate2000Script_Click(object sender, EventArgs e)
        {
            CreateScript(ScriptVersion.Sql2000);
        }
        private void buttonCreate2005Script_Click(object sender, EventArgs e)
        {
            CreateScript(ScriptVersion.Sql2005);
        }

        private void CreateScript(ScriptVersion scriptVersion)
        {
            try
            {
                CloneResults._listScript.Clear();
                CloneResults._userCloneList.Clear();
                if (ServerSelectionSource.Text.Trim().Length == 0)
                {
                    Messaging.ShowError(ProductConstants.ErrorMustEnterSourceServer);
                    return;
                }
                if (ServerSelectionSource.ServerList.Count > 1)
                {
                    Messaging.ShowError(ProductConstants.ErrorCanOnlyEnterOneServer);
                    return;
                }
                if (textSourceUser.Text.Trim().Length == 0)
                {
                    Messaging.ShowError(ProductConstants.ErrorMustEnterSourceUser);
                    return;
                }
                if (checkSpecifyPassword.Checked)
                {
                    if (textPassword.Text != textConfirmPassword.Text)
                    {
                        Messaging.ShowError(ProductConstants.ErrorPasswordMustMatch);
                        return;
                    }
                }
                Progress.OperationText = ProductConstants.StatusInitializing;
                Progress.Visible = true;
                buttonCloneUser.Enabled = false;
                textScript.Clear();
                CloneOptions _Options = new CloneOptions();

                _Options.Version = scriptVersion;
                _Options.UserName = textDestinationUserName.Text;
                if (checkSpecifyPassword.Checked)
                {
                    _Options.Password = textPassword.Text;
                }
                _Options.DefaultDatabase = listDefaultDatabase.Text;
                _Options.ApplyDatabasePermissions = checkIncludeDatabaseAccess.Checked;
                if (_Options.ApplyDatabasePermissions)
                {
                    foreach (KeyValuePair<string, bool> _Database in _DatabaseList)
                    {
                        if (_Database.Value)
                        {
                            _Options.Databases.Add(_Database.Key);
                        }
                    }
                }
                if (checkIncludeObjectPermissions.Enabled)
                {
                    _Options.ApplyObjectLevelPermissions = checkIncludeObjectPermissions.Checked;
                }
                _Options.EnableLogin = checkEnableLogin.Checked;
                _Options.IncludeSchemaOwnership = checkIncludeSchemaOwnership.Checked;
                _Options.SourceServer = ServerSelectionSource.ServerList[0];
                _Options.DestinationServer = ServerSelectionDestination.ServerList[0];
                _Options.SourceUser = textSourceUser.Text;

                SaveLastUsedValues();

                PreviewWorker.RunWorkerAsync(_Options);
            }
            catch (Exception exc)
            {
                Progress.Visible = false;
                buttonCloneUser.Enabled = true;
                Messaging.ShowException(ProductConstants.productName, exc);
            }
        }

        #endregion

        private void ShowF1Help(object sender, HelpEventArgs hlpevent)
        {
            HelpMenu.ShowHelp();
        }

        /// <summary>
        /// Saves the last used server and login to the registry.
        /// </summary>
        private void SaveLastUsedValues()
        {
            try
            {
                using (RegistryKey _Key = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey))
                using (RegistryKey _SubKey = _Key.CreateSubKey(ProductConstants.shortProductName))
                {
                    _SubKey.SetValue(ProductConstants.RegistryValueLastServerUsed, ServerSelectionSource.Text);
                    _SubKey.SetValue(ProductConstants.RegistryValueLastLoginUsed, textSourceUser.Text);
                }
            }
            catch { }
        }

        /// <summary>
        /// Retrieves the last used server and login from the registry.
        /// </summary>
        private void GetLastUsedValues()
        {
            try
            {
                using (RegistryKey _Key = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey))
                using (RegistryKey _SubKey = _Key.CreateSubKey(ProductConstants.shortProductName))
                {
                    string _LastUsedServer = (string)_SubKey.GetValue(ProductConstants.RegistryValueLastServerUsed);
                    if (!string.IsNullOrEmpty(_LastUsedServer))
                    {
                        ServerSelectionSource.Text = _LastUsedServer;
                        BindSource();
                    }
                    string _LastUsedLogin = (string)_SubKey.GetValue(ProductConstants.RegistryValueLastLoginUsed);
                    if (!string.IsNullOrEmpty(_LastUsedLogin))
                    {
                        if (_SourceServer != null && _SourceServer.Logins.Contains(_LastUsedLogin))
                        {
                            textSourceUser.Text = textDestinationUserName.Text = _LastUsedLogin;
                            ToggleControls(true);
                        }
                    }
                }
            }
            catch { }
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

