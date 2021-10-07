using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core;
using System.Collections.Specialized;
using Idera.SqlAdminToolset.Core.Export;
using Microsoft.SqlServer.Management.Common;
using Microsoft.Win32;
using System.Text;
using System.Xml;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.PasswordChecker
{
    public partial class Form_Main : Form
    {
        #region private variables

        private JobPool<TestResults> _JobPool;
        int _TotalUserCount = 0;
        int _TotalServerCount = 0;
        int _TotalPasswordCount = 0;
        int _TotalFailureCount = 0;
        private Dictionary<string, string> _ErrorReports = new Dictionary<string, string>();
        private const int ICON_OK = 3;
        private const int ICON_WARN = 4;
        private const int ICON_ERR = 5;

        //int _LastPasswordListSelection = -1;
        
        private ToolProgressBarDialog _ProgressDialog;

        bool _firstTime = true;

        #endregion

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

            ResetDefaults();

            contextShowFailedOnly.Text = hideToolStripMenuItem.Text = ProductConstants.HideSuccessfulUsers;

            m_maskPasswords = GetMaskSettingFromRegistry();
            ShowPasswordChanged();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (_firstTime)
            {
                _firstTime = false;
                if (ProductConstants.CommandLineServers.Trim().Length > 0)
                {
                    ServerSelection.Text = ProductConstants.CommandLineServers;
                }
            }
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
            if (Launchpad.Run(this))
            {
                Close();
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents(); // let form redraw after main menu closes

                //DataSet dataSet = ExportToDataSet.CopyListView(listUserDetails, "PasswordChecker");
                //We're going to generate our dataset here since it's a combination of two list views
                DataSet dataSet = new DataSet();
                DataTable dataTable = dataSet.Tables.Add("PasswordChecker");

                //add the columns
                dataTable.Columns.Add("SQLServer");
                dataTable.Columns.Add("SQLServerLogin");
                dataTable.Columns.Add("SQLServerResult");
                dataTable.Columns.Add("Password");
                dataTable.Columns.Add("Icon");

                //now add the data
                //loop through the items in the listResults
                for (int i = 0; i < listResults.Items.Count; i++)
                {
                    string serverName = listResults.Items[i].SubItems[1].Text;
                    TestResults results = (TestResults)listResults.Items[i].Tag;

                    if (results == null) //no tag, populate with "n/a"
                    {
                        DataRow dataRow = dataTable.NewRow();
                        string[] subItems = new string[5]; //for the five columns

                        //server name is the only one with data
                        subItems[0] = serverName;
                        for (int j = 1; j < 4; j++)
                            subItems[j] = "n/a";

                        dataRow.ItemArray = subItems;
                        dataTable.Rows.Add(dataRow);

                        continue;
                    }
                    else
                    {
                        //loop through its login tests
                        foreach (LoginResults loginResults in results.LoginResultsList)
                        {
                            DataRow dataRow = dataTable.NewRow();
                            string[] subItems = new string[5]; //for the five columns

                            subItems[0] = serverName;
                            subItems[1] = loginResults.UserName;

                            if (loginResults.IsLoginSkipped)
                            {
                                subItems[2] = loginResults.WhySkippedString;
                                subItems[3] = "n/a";
                                subItems[4] = ICON_WARN.ToString();
                            }
                            else
                            {
                                subItems[2] = loginResults.IsLoginSuccessful ? "Failed" : "Passed";

                                subItems[3] = loginResults.SuccessfulPassword == string.Empty
                                                ? ProductConstants.BlankPassword
                                                : (m_maskPasswords) ? "*****"
                                                                    : loginResults.SuccessfulPassword;
                                subItems[4] = loginResults.IsLoginSuccessful ? ICON_ERR.ToString() : ICON_OK.ToString();
                            }

                            dataRow.ItemArray = subItems;
                            dataTable.Rows.Add(dataRow);
                        }
                    }
                }

                //is there data?
                if (dataSet.Tables["PasswordChecker"].Rows.Count == 0)
                {
                    MessageBox.Show("No data to print.\r\n\r\nPlease click 'Check Passwords' to gather data for the report.", "No Data",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                //launch the report dialog
                Form_Report frm = new Form_Report(dataSet);
                frm.Show(this);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
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

        private void buttonGetResults_Click(object sender, EventArgs e)
        {
            // validation
            if (radioSpecificUser.Checked && textSelectedUser.Text == "")
            {
                Messaging.ShowError("Specify at least one login to check.");
                return;
            }

            if (ServerSelection.ServerList.Count == 0)
            {
                string msg;
                if (ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server)
                    msg = "Specify at least one SQL Server.";
                else
                    msg = "The selected Server Group contains no SQL Servers.";

                Messaging.ShowError(msg);

                return;
            }

            if (!check10.Checked && !check50.Checked && !check800.Checked && !check2400.Checked && !checkBlank.Checked && !checkOther.Checked && !checkCustom.Checked)
            {
                Messaging.ShowError("You must specify a password option");
                return;
            }

            MRU.AddServerOrGroup(ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server,
                                 ServerSelection.Text,
                                 ServerSelection.SqlCredentials);

            try
            {
                if (!VerifyDelimitedText(ServerSelection, ProductConstants.roleSeparator, "SQL Server"))
                {
                    return;
                }

                // Password Policy Behavior
                //ProductConstants.SkipPolicyEnabledLogins = checkSkipLogins.Checked;

                ResetDefaults();

                List<string> _PasswordList = new List<string>();

                if (check10.Checked)
                {
                    AddItemsToList(_PasswordList, GetPasswordList(ProductConstants.PasswordListTop10));
                }
                if (check50.Checked)
                {
                    AddItemsToList(_PasswordList, GetPasswordList(ProductConstants.PasswordListNifty50));
                }
                if (check800.Checked)
                {
                    AddItemsToList(_PasswordList, GetPasswordList(ProductConstants.PasswordList800));
                }
                if (check2400.Checked)
                {
                    AddItemsToList(_PasswordList, GetPasswordList(ProductConstants.PasswordListComprehensive));
                }
                if (checkBlank.Checked)
                {
                    if (!_PasswordList.Contains(string.Empty))
                    {
                        _PasswordList.Add(string.Empty);
                    }

                    AddItemsToList(_PasswordList, new string[] { ProductConstants.PasswordSameAsLoginName });
                }
                if(checkOther.Checked)
                {
                    string[] pwds = textPasswords.Text.Split(';');
                    if (pwds == null || pwds.Length == 0)
                    {
                        Messaging.ShowError("Specify one or more passwords to check.");
                        return;
                    }

                    AddItemsToList(_PasswordList, pwds);
                }
                if (checkCustom.Checked)
                {
                    try
                    {
                        string _FilePath = textCustom.Text;

                        if (File.Exists(_FilePath))
                        {
                            using (StreamReader _Reader = File.OpenText(_FilePath))
                            {
                                List<string> _CustomPasswords = new List<string>();
                                string _Password;

                                while ((_Password = _Reader.ReadLine()) != null)
                                {
                                    if (_Password.Length > 128)
                                    {
                                        throw new ArgumentException("The password list contains passwords whose length exceeds 128 characters.");
                                    }

                                    _CustomPasswords.Add(_Password);
                                }
                                AddItemsToList(_PasswordList, _CustomPasswords);
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Password list not found in the specified location: " + _FilePath, "filePath");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("The specified password list is invalid. " + ex.Message);
                    }
                }

                PasswordCheckerOptions _Options = new PasswordCheckerOptions();
                _Options.PasswordList = _PasswordList;

                if (radioAllUsers.Checked)
                {
                    _Options.UserType = UsersToTest.All;
                }
                else if (radioSa.Checked)
                {
                    _Options.UserType = UsersToTest.Sa;
                }
                else if (radioServerRoles.Checked)
                {
                    if (textServerRoles.Text != "")
                    {
                        if (!VerifyDelimitedText(textServerRoles, ProductConstants.roleSeparator, "Server Roles"))
                        {
                            return;
                        }
                        _Options.ServerRoles = textServerRoles.Text.Split(ProductConstants.roleSeparator);
                        for ( int i=0;i<_Options.ServerRoles.Length;i++) _Options.ServerRoles[i] = _Options.ServerRoles[i].Trim();
                        
                    }
                    else
                    {
                        _Options.ServerRoles = Form_RoleSelection.GetAllRoles(Form_RoleSelection.RoleMode.Server);
                    }
                    _Options.UserType = UsersToTest.ServerRole;
                }
                else if (radioDatabaseRoles.Checked)
                {
                    if (textDatabaseRoles.Text != "")
                    {
                        if (!VerifyDelimitedText(textDatabaseRoles, ProductConstants.roleSeparator, "Database Roles"))
                        {
                            return;
                        }
                        _Options.DatabaseRoles = textDatabaseRoles.Text.Split(ProductConstants.roleSeparator);
                        for ( int i=0;i<_Options.DatabaseRoles.Length;i++) _Options.DatabaseRoles[i] = _Options.DatabaseRoles[i].Trim();
                    }
                    else
                    {
                        _Options.DatabaseRoles = Form_RoleSelection.GetAllRoles(Form_RoleSelection.RoleMode.Database);
                    }

                    _Options.UserType = UsersToTest.DatabaseRole;
                }
                else if (radioSpecificUser.Checked)
                {
                    if (!VerifyDelimitedText(textSelectedUser, ProductConstants.roleSeparator, "Selected Users"))
                    {
                        return;
                    }

                    _Options.UserType = UsersToTest.SpecifiedUser;
                    _Options.Users = textSelectedUser.Text.Split(ProductConstants.roleSeparator);

                    for (int i = 0; i < _Options.Users.Length; i++)
                    {
                        _Options.Users[i] = _Options.Users[i].Trim();
                    }
                }

                _Options.TestCommonVariations = checkTestVariations.Checked;

                buttonGetResults.Enabled = false;
                Application.DoEvents();

                if (ServerSelection.ServerList.Count > 0)
                {
                    ProgressBar_Initialize();
                
                    _ErrorReports.Clear();
                    _JobPool = new JobPool<TestResults>(1);
                    _JobPool.ServerTaskComplete += JobPoolTaskComplete;
                    _JobPool.TaskComplete += AllTasksComplete;

                    _JobPool.Enqueue(PasswordCheckerHelper.ExecutePasswordCheck, ServerSelection.ServerList, 0, _Options);

                    _JobPool.StartAsync();

                    ProgressBar_Show();
                }
            }
            catch (Exception exc)
            {
                ProgressBar_Close();
                Messaging.ShowException("Check passwords", exc);
            }
        }

        /// <summary>
        /// Verifies that a delimited textbox has a correct value.
        /// </summary>
        public bool VerifyDelimitedText(Control textbox, char delimiter, string friendlyName)
        {
            textbox.Text = textbox.Text.Trim();
            if (textbox.Text.EndsWith(delimiter.ToString()))
            {
                textbox.Text = textbox.Text.Remove(textbox.Text.Length - 1);
            }
            if (textbox.Text.Trim().Length == 0)
            {
                Messaging.ShowError(string.Format(ProductConstants.ErrorInvalidDelimitedValue, friendlyName));
                return false;
            }
            return true;
        }

        private void AddItemsToList(List<string> completeList, IEnumerable<string> newItems)
        {
            foreach (string _Password in newItems)
            {
                if (!completeList.Contains(_Password))
                {
                    completeList.Add(_Password);
                }
            }
        }

        /// <summary>
        /// Retrieves the file path for the requested dictionary.
        /// </summary>
        private List<string> GetPasswordList(string key)
        {
            List<string> _PasswordList = new List<string>();

            if (key == ProductConstants.PasswordListTop10 ||
                 key == ProductConstants.PasswordListNifty50 ||
                 key == ProductConstants.PasswordList800 ||
                 key == ProductConstants.PasswordListComprehensive)
            {
                Assembly _Assembly = Assembly.GetExecutingAssembly();
                using (StreamReader _Reader = new StreamReader(_Assembly.GetManifestResourceStream(string.Format("Idera.SqlAdminToolset.PasswordChecker.PasswordFiles.{0}.txt", key))))
                {
                    string _Password;

                    while ((_Password = _Reader.ReadLine()) != null)
                    {
                        _PasswordList.Add(_Password);
                    }
                }
            }
            return _PasswordList;
        
        }

        private void ResetDefaults()
        {
            lastSelectedIndex = -1;

            listResults.Items.Clear();
            listUserDetails.Items.Clear();

            _TotalFailureCount =
                _TotalPasswordCount =
                _TotalServerCount =
                _TotalUserCount = 0;
            menuCopy.Enabled =
                contextMenuCopy_Logins.Enabled =
                menuExport.Enabled =
                printToolStripMenuItem.Enabled = false;

            Application.DoEvents();
        }

        #region Job Pool Event handling

        void AllTasksComplete(object sender, JobExecutionEventArgs e)
        {
            ProgressBar_Close();
        
            foreach (WorkItem<TestResults> _WorkItem in _JobPool.WorkItems)
            {
                if (_WorkItem.Status != TaskStatus.Success)
                {
                    if (_WorkItem.Exception == null)
                    {
                        AddFailedServerToList(_WorkItem.Server.Name, null, ProductConstants.ErrorCanceledOperation);
                    }
                }
            }

            buttonGetResults.Enabled = true;

            // select first server
            if (listResults.Items.Count != 0)
            {
                listResults.Select();
                listResults.Items[0].Selected = true;
            }

            //enable if there's results
            menuSelectAll.Enabled =
                printToolStripMenuItem.Enabled =
                menuExport.Enabled =
                contextMenuSelectAll_Servers.Enabled = listResults.Items.Count > 0;

            if (_ErrorReports.Count > 0)
            {
                Form_MultipleServerError frm = new Form_MultipleServerError();
                foreach (KeyValuePair<string, string> _Error in _ErrorReports)
                {
                    frm.AddError(_Error.Key, _Error.Value);
                }
                BeginInvoke((MethodInvoker)delegate() { frm.ShowDialog(); });                
                _ErrorReports.Clear();
            }
        }

        void JobPoolTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            TestResults _Results = e.Resultset as TestResults;

            if (_Results != null)
            {
                _TotalServerCount++;
                _TotalUserCount += _Results.TestedLoginCount;
                _TotalPasswordCount += _Results.ConnectionAttemptCount;
                _TotalFailureCount += _Results.FailureLoginCount;

                int iconNdx = ICON_OK; // all is ok
                if (!_Results.PassedTest)
                    iconNdx = ICON_ERR; // error
                else if (_Results.TestedLoginCount != _Results.ActuallyTestedCount)
                    iconNdx = ICON_WARN;  // warning - some skipped

                ListViewItem _Item = new ListViewItem("", iconNdx);

                _Item.SubItems.Add(_Results.ServerName);

                _Item.SubItems.Add(String.Format("{0} of {1}",
                                                   _Results.ActuallyTestedCount,
                                                   _Results.TestedLoginCount));

                _Item.SubItems.Add(_Results.FailureLoginCount.ToString());
                _Item.SubItems.Add(_Results.BlankPasswordCount.ToString());
                _Item.SubItems.Add(_Results.PasswordSameAsLoginCount.ToString());
                _Item.Tag = _Results;
                listResults.Items.Add(_Item);
            }
            else if (e.Exception != null)
            {
                AddFailedServerToList(e.Server.Name, e.Exception, null);
            }

            System.Diagnostics.Debug.WriteLine(string.Format("{0} - {1}", e.Server, e.Status));
            _ProgressDialog.OperationText = string.Format("{0} - {1}", e.Server.Name, e.Status == TaskStatus.Success ? "Complete" : e.Status.ToString());
        }

        private void AddFailedServerToList(string serverName, Exception exception, string errorMessage)
        {
            if (exception == null)
            {
                _ErrorReports.Add(serverName, errorMessage);
            }
            else
            {
                _ErrorReports.Add(serverName, (exception is ConnectionFailureException) ? ProductConstants.ErrorCannotAccessUsersDescription : Helpers.GetCombinedExceptionText(exception));
                errorMessage = (exception is ConnectionFailureException) ? ProductConstants.ErrorCannotAccessUsers : ProductConstants.ErrorConnectionError;
            }
            ListViewItem _Item = new ListViewItem("", 4);    //0=ok, 1=warning, 2=error
            _Item.SubItems.Add(serverName);
            _Item.SubItems.Add(errorMessage);
            _Item.SubItems.Add("");
            _Item.SubItems.Add("");
            listResults.Items.Add(_Item);
        }

        #endregion

        #region Control events

        private void ServerSelection_TextChanged(object sender, EventArgs e)
        {
            buttonGetResults.Enabled = ServerSelection.Text.Trim().Length != 0;
        }

        private void textServerRoles_ButtonCustomClick(object sender, EventArgs e)
        {
            Form_RoleSelection _RoleSelection = new Form_RoleSelection(Form_RoleSelection.RoleMode.Server, textServerRoles);
            _RoleSelection.Roles = textServerRoles.Text.Split(';');
            for ( int i=0;i<_RoleSelection.Roles.Length;i++) _RoleSelection.Roles[i] = _RoleSelection.Roles[i].Trim();
            
            if (_RoleSelection.ShowDialog() == DialogResult.OK)
            {
                textServerRoles.Text = string.Join(ProductConstants.roleSeparator.ToString(), _RoleSelection.Roles);
            }
        }

        private void textDatabaseRoles_ButtonCustomClick(object sender, EventArgs e)
        {
            Form_RoleSelection _RoleSelection = new Form_RoleSelection(Form_RoleSelection.RoleMode.Database, textDatabaseRoles);
            _RoleSelection.Roles = textDatabaseRoles.Text.Split(';');
            for ( int i=0;i<_RoleSelection.Roles.Length;i++) _RoleSelection.Roles[i] = _RoleSelection.Roles[i].Trim();

            if (_RoleSelection.ShowDialog() == DialogResult.OK)
            {
                textDatabaseRoles.Text = string.Join(ProductConstants.roleSeparator.ToString(), _RoleSelection.Roles);
            }
        }

        private void radioServerRoles_CheckedChanged(object sender, EventArgs e)
        {
            textServerRoles.Enabled = radioServerRoles.Checked;
        }

        private void radioDatabaseRoles_CheckedChanged(object sender, EventArgs e)
        {
            textDatabaseRoles.Enabled = radioDatabaseRoles.Checked;
        }

        private void radioSpecificUser_CheckedChanged(object sender, EventArgs e)
        {
            textSelectedUser.Enabled = radioSpecificUser.Checked;
        }

        private int lastSelectedIndex = -1;

        private void listResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((listResults.SelectedIndices.Count == 0 && lastSelectedIndex != -1)
             || (listResults.SelectedIndices[0] != lastSelectedIndex))
            {
                if (listResults.SelectedIndices.Count == 0)
                {
                    listUserDetails.Items.Clear();
                    contextMenuCopy_Servers.Enabled = false;
                    menuCopy.Enabled = (listUserDetails.SelectedIndices.Count > 0);
                    buttonShowPasswords.Enabled = false;
                    lastSelectedIndex = -1;
                }
                else
                {
                    lastSelectedIndex = listResults.SelectedIndices[0];
                    contextMenuCopy_Servers.Enabled = true;
                    menuCopy.Enabled = true;
                    buttonShowPasswords.Enabled = true;
                    DisplayPasswordCheckDetails();
                }
            }
        }

        private void listUserDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listUserDetails.SelectedIndices.Count == 0)
            {
                contextMenuCopy_Logins.Enabled = false;
                menuCopy.Enabled = (listResults.SelectedIndices.Count > 0);
            }
            else
            {
                contextMenuCopy_Logins.Enabled = true;
                menuCopy.Enabled = true;
            }
        }
        
        #region Progress Bar

        public void ProgressBar_Show()
        {
            if(_ProgressDialog != null)
            {
                _ProgressDialog.ShowDialog();
            }
        }
        public void ProgressBar_Close()
        {
            if(_ProgressDialog != null)
            {
                _ProgressDialog.TopLevel = false;
                _ProgressDialog.Visible = false;
                _ProgressDialog.Close();
                _ProgressDialog = null;
            }
        }

        public void ProgressBar_Initialize()
        {
            _ProgressDialog = new ToolProgressBarDialog();
            _ProgressDialog.OperationText = "Checking Passwords...";
            _ProgressDialog.CancelEnabled = true;
            _ProgressDialog.ProgressCancelEvent += new EventHandler<EventArgs>(ProgressBar_CancelHandler);
        }

        public void ProgressBar_CancelHandler(object sender, EventArgs e)
        {
            _ProgressDialog.OperationText = "Cancelling...";
            _ProgressDialog.CancelEnabled = false;
            
            _JobPool.Cancel(true);
        }
        
        #endregion
        
        #region Clipboard

        private void contextMenuCopy_Users_Click(object sender, EventArgs e)
        {
            CopyToClipboard(listUserDetails, true);
        }

        private void contextMenuCopy_Servers_Click(object sender, EventArgs e)
        {
            CopyToClipboard(listResults, true);
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            if (listUserDetails.Focused)
            {
                CopyToClipboard(listUserDetails, true);
            }
            else
            {
                CopyToClipboard(listResults, true);
            }
        }

        private void CopyToClipboard(ListView listView, bool selectedOnly)
        {
            ExportToClipboard.CopyListViewToTabbedFormat(listView, true, selectedOnly);
        }

        private void menuSelectAll_Click(object sender, EventArgs e)
        {
            if (listUserDetails.Focused)
            {
                SelectAll(listUserDetails);
            }
            else
            {
                SelectAll(listResults);
            }
        }

        private void contextMenuSelectAll_Servers_Click(object sender, EventArgs e)
        {
            SelectAll(listResults);
        }

        private void contextMenuSelectAll_Logins_Click(object sender, EventArgs e)
        {
            SelectAll(listUserDetails);
        }

        private void SelectAll(ListView listView)
        {
            foreach (ListViewItem lvi in listView.Items)
            {
                lvi.Selected = true;
            }
        }

        #endregion

       #region Toggle - Show Users With Bad Passwords Only

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ToggleShowUsers();
        }
        
        private void ContextMenuShowFoundPasswordsOnly_Click(object sender, EventArgs e)
        {
           ToggleShowUsers();
        }
        
        private void ToggleShowUsers()
        {
            ContextMenuShowFoundPasswordsOnly.Checked = hideToolStripMenuItem.Checked = !hideToolStripMenuItem.Checked;
            DisplayPasswordCheckDetails();
        }
        
        #endregion
        
        
        #region Show Passwords
        
        private bool m_maskPasswords = true;

        private void ContextMenuMaskPasswords_Click(object sender, EventArgs e)
        {
           ToggleShowPasswords();
        }
        
       private void buttonShowPasswords_Click( object sender, EventArgs e )
       {
           ToggleShowPasswords();
        }
        
        private void ToggleShowPasswords()
        {
           m_maskPasswords = ! m_maskPasswords;
           ShowPasswordChanged();
        }
        
        private void ShowPasswordChanged()
        {
           if ( m_maskPasswords )
           {
              // turning on - will show passwords
              buttonShowPasswords.Text                  =
              ContextMenuMaskPasswords.Text             =
              maskPasswordStringsToolStripMenuItem.Text = "Show passwords in cleartext";

              textPasswords.UseSystemPasswordChar       = true;
           }
           else
           {
              // turning off - will mask passwords
              buttonShowPasswords.Text                  =
              ContextMenuMaskPasswords.Text             =
              maskPasswordStringsToolStripMenuItem.Text = "Mask passwords";

              textPasswords.UseSystemPasswordChar       = false;
           }
           
           SaveMaskSettingToRegistry(m_maskPasswords);
           DisplayPasswordCheckDetails();
        }

       #endregion
       

        /// <summary>
        /// Displays details about a server's password checking results.
        /// </summary>
        private void DisplayPasswordCheckDetails()
        {
            labelTestedLogins.Text = "Tested Logins:";

            if (listResults.SelectedItems != null && listResults.SelectedItems.Count != 0)
            {
                labelTestedLogins.Text = String.Format("Tested Logins on {0}: ", listResults.SelectedItems[0].SubItems[1].Text);

                ListViewItem _SelectedItem = listResults.SelectedItems[0];
                listUserDetails.Items.Clear();

                if (_SelectedItem.Tag != null)
                {
                    TestResults _Results = (TestResults)_SelectedItem.Tag;

                    listUserDetails.Items.Clear();
                    foreach (LoginResults _LoginResults in _Results.LoginResultsList)
                    {
                        if (hideToolStripMenuItem.Checked &&
                               (!_LoginResults.IsLoginSuccessful ||
                               _LoginResults.IsLoginSkipped)
                           )
                        {
                            continue;
                        }

                        ListViewItem _Item;
                        if (_LoginResults.IsLoginSkipped)
                        {
                            _Item = new ListViewItem("", ICON_WARN);  // warn if skipped
                            _Item.SubItems.Add(_LoginResults.UserName);
                            _Item.SubItems.Add(_LoginResults.WhySkippedString);
                            _Item.SubItems.Add("");
                            _Item.Tag = _LoginResults;
                        }
                        else
                        {
                            _Item = new ListViewItem("", _LoginResults.IsLoginSuccessful ? ICON_ERR : ICON_OK);

                            _Item.SubItems.Add(_LoginResults.UserName);
                            //_Item.SubItems.Add(_LoginResults.PasswordAttempts.Count.ToString());

                            if (_LoginResults.IsLoginSuccessful)
                            {
                               _Item.SubItems.Add("Failed");

                               ListViewItem.ListViewSubItem _FailedItem = _Item.SubItems.Add((_LoginResults.SuccessfulPassword == string.Empty) ?
                               ProductConstants.BlankPassword :
                               _LoginResults.SuccessfulPassword);

                               if ( m_maskPasswords )
                               {
                                  _FailedItem.Text = ProductConstants.PasswordMask ;
                               }
                            }
                            else
                            {
                               _Item.SubItems.Add("Passed");
                               _Item.SubItems.Add(string.Empty);
                            }
                            _Item.Tag = _LoginResults;
                        }
                        listUserDetails.Items.Add(_Item);
                    }

                    contextMenuSelectAll_Logins.Enabled = (listUserDetails.Items.Count != 0);
                }
            }
        }

        private void textCustom_ButtonCustomClick(object sender, EventArgs e)
        {
            OpenFileDialog _FileDialog = new OpenFileDialog();
            _FileDialog.CheckFileExists = true;
            _FileDialog.DefaultExt = "txt";
            _FileDialog.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
            _FileDialog.Multiselect = false;
            _FileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            _FileDialog.Title = ProductConstants.FileDialogTitle;
            if (_FileDialog.ShowDialog() == DialogResult.OK)
            {
                textCustom.Text = _FileDialog.FileName;
            }
        }


        private void checkOther_CheckedChanged(object sender, EventArgs e)
        {
            textPasswords.Enabled = checkOther.Checked;
        }

        private void checkCustom_CheckedChanged(object sender, EventArgs e)
        {
            textCustom.Enabled = checkCustom.Checked;
        }

        private void linkView10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewList(ProductConstants.PasswordListTop10);
        }

        private void linkView50_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewList(ProductConstants.PasswordListNifty50);
        }

        private void linkView800_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewList(ProductConstants.PasswordList800);
        }

        private void linkView2400_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewList(ProductConstants.PasswordListComprehensive);
        }

        #endregion

        private void ViewList(string key)
        {
            List<string> _PasswordList = null;
            bool loadSucceeded = false;

            try
            {
                Cursor = Cursors.WaitCursor;
                _PasswordList = GetPasswordList(key);
                loadSucceeded = true;
            }
            catch
            { }
            finally
            {
                Cursor = Cursors.Default;
            }

            if (loadSucceeded)
            {
                Form_PasswordList frm = new Form_PasswordList(key, _PasswordList);
                frm.ShowDialog();
            }
        }

        #endregion

        #region Column Sorting

        private int sortColumn = -1;
        private System.Windows.Forms.SortOrder sortOrder = System.Windows.Forms.SortOrder.Ascending;

        private void listResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;

                // Set the sort order to ascending by default.
                listResults.Sorting = sortOrder;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listResults.Sorting == System.Windows.Forms.SortOrder.Ascending)
                    listResults.Sorting = System.Windows.Forms.SortOrder.Descending;
                else
                    listResults.Sorting = System.Windows.Forms.SortOrder.Ascending;
            }

            listResults.ListViewItemSorter = new ListViewItemComparer(e.Column, listResults.Sorting);
            listResults.Sort();
        }

        // Implements the manual sorting of items by column.
        class ListViewItemComparer : IComparer
        {
            private int col;
            private System.Windows.Forms.SortOrder order;

            public ListViewItemComparer(int column, System.Windows.Forms.SortOrder order)
            {
                col = column;
                this.order = order;
            }

            public int Compare(object x, object y)
            {
                int returnVal;

                if (col == 0 /* icon */ )
                {
                    returnVal = Helpers.CompareInt(((ListViewItem)x).ImageIndex,
                                                     ((ListViewItem)y).ImageIndex);
                }
                else if (col == 1 /* server */ ||
                         col == 2 /* Login count*/)
                {
                    returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                                ((ListViewItem)y).SubItems[col].Text);
                }
                else  // all other columns are numeric
                {
                    int xValue = int.MinValue;
                    int yValue = int.MinValue;

                    ListViewItem _XItem = (ListViewItem)x;
                    ListViewItem _YItem = (ListViewItem)y;

                    if (_XItem.SubItems.Count >= col + 1 && _XItem.SubItems[col].Text.Trim() != string.Empty)
                    {
                        xValue = int.Parse(_XItem.SubItems[col].Text);
                    }

                    if (_YItem.SubItems.Count >= col + 1 && _YItem.SubItems[col].Text.Trim() != string.Empty)
                    {
                        yValue = int.Parse(_YItem.SubItems[col].Text);
                    }

                    returnVal = Helpers.CompareInt(xValue, yValue);
                }

                if (order == System.Windows.Forms.SortOrder.Descending) returnVal *= -1;

                return returnVal;
            }
        }

        #endregion

        #region Column Sorting for User Details

        private int uSortColumn = -1;
        private System.Windows.Forms.SortOrder uSortOrder = System.Windows.Forms.SortOrder.Ascending;

        //private void uResetSort()
        //{
        //    sortColumn = -1;
        //    listUserDetails.Sorting = sortOrder;
        //}

        private void listUserDetails_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != uSortColumn)
            {
                // Set the sort column to the new column.
                uSortColumn = e.Column;

                // Set the sort order to ascending by default.
                listUserDetails.Sorting = uSortOrder;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listUserDetails.Sorting == System.Windows.Forms.SortOrder.Ascending)
                    listUserDetails.Sorting = System.Windows.Forms.SortOrder.Descending;
                else
                    listUserDetails.Sorting = System.Windows.Forms.SortOrder.Ascending;
            }

            listUserDetails.ListViewItemSorter = new UserListViewItemComparer(e.Column, listUserDetails.Sorting);
            listUserDetails.Sort();
        }

        // Implements the manual sorting of items by column.
        class UserListViewItemComparer : IComparer
        {
            private int col;
            private System.Windows.Forms.SortOrder order;

            //public UserListViewItemComparer()
            //{
            //    col = 0;
            //    order = System.Windows.Forms.SortOrder.Ascending;
            //}

            public UserListViewItemComparer(int column, System.Windows.Forms.SortOrder order)
            {
                col = column;
                this.order = order;
            }

            public int Compare(object x, object y)
            {
                int returnVal;

                if (col == 0 /* icon */ )
                {
                    returnVal = Helpers.CompareInt(((ListViewItem)x).ImageIndex,
                                                     ((ListViewItem)y).ImageIndex);
                }
                else  // all other columns are string
                {
                    returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                                ((ListViewItem)y).SubItems[col].Text);
                }

                if (order == System.Windows.Forms.SortOrder.Descending) returnVal *= -1;

                return returnVal;
            }
        }

        #endregion

        #region Registry
        private void SaveMaskSettingToRegistry(bool value)
        {
           try
           {
              using (RegistryKey _Key = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey))
              using (RegistryKey _SubKey = _Key.CreateSubKey(ProductConstants.shortProductName))
              {
                 _SubKey.SetValue(ProductConstants.PasswordMaskRegistryValue, value);
              }
           }
           catch { }
        }

        private bool GetMaskSettingFromRegistry()
        {
           bool _MaskPasswords = true;
           try
           {
              using (RegistryKey _Key = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey))
              using (RegistryKey _SubKey = _Key.CreateSubKey(ProductConstants.shortProductName))
              {
                 bool.TryParse(_SubKey.GetValue(ProductConstants.PasswordMaskRegistryValue).ToString(), out _MaskPasswords);
              }
           }
           catch { }
           return _MaskPasswords;
        }

        #endregion

       private void ShowF1Help(object sender, HelpEventArgs hlpevent)
       {
          HelpMenu.ShowHelp();
       }


        private bool SaveExportFile(string fileName, string fileData)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    File.Delete(fileName);
                }
                catch (Exception ex)
                {
                    Messaging.ShowError(
                       String.Format("An error occurred trying to overwrite the existing file.\r\n\r\nError: {0}",
                                      ex.Message));
                    return false; // we cant write so just give up                                 
                }
            }

            using (FileStream _Stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            using (StreamWriter _Writer = new StreamWriter(_Stream))
            {
                _Writer.Write(fileData);
            }
            return true;
        }

        private void menuExportAsCSV_Click(object sender, EventArgs e)
        {
            try
            {
                if(listResults.Items.Count == 0)
                {
                    Messaging.ShowError("There's no results to export");
                }

                SaveFileDialog _FileDialog = new SaveFileDialog();
                _FileDialog.AddExtension = true;
                _FileDialog.CheckPathExists = true;
                _FileDialog.OverwritePrompt = true;
                _FileDialog.DefaultExt = "csv";
                _FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                _FileDialog.FileName = CoreGlobals.productName + ".csv";
                _FileDialog.Filter = "CSV File (Comma Separated Values)(*.csv)|*.csv|All files (*.*)|*.*";

                if (_FileDialog.ShowDialog() == DialogResult.OK)
                {

                    StringBuilder _CsvData = new StringBuilder();
                    _CsvData.Append("SQL Server,Logins Tested,Bad Passwords,Blank Passwords,Same as Login,Login,Result,Password (if found)");
                    _CsvData.Append(Environment.NewLine);

                    foreach (ListViewItem _Item in listResults.Items)
                    {
                        TestResults _Results = _Item.Tag as TestResults;
                        if (_Results != null)
                        {
                            _CsvData.Append(ExportToCSV.GetCsvString(_Results.ServerName, false));
                            _CsvData.Append(ExportToCSV.GetCsvString(_Results.ActuallyTestedCount.ToString(), true));
                            _CsvData.Append(ExportToCSV.GetCsvString(_Results.FailureLoginCount.ToString(), true));
                            _CsvData.Append(ExportToCSV.GetCsvString(_Results.BlankPasswordCount.ToString(), true));
                            _CsvData.Append(ExportToCSV.GetCsvString(_Results.PasswordSameAsLoginCount.ToString(), true));
                            _CsvData.Append(",,,");
                            _CsvData.Append(Environment.NewLine);

                            foreach (LoginResults _LoginResult in _Results.LoginResultsList)
                            {
                                _CsvData.Append(",,,,");
                                _CsvData.Append(ExportToCSV.GetCsvString(_LoginResult.UserName, true));
                                string _TestResult = _LoginResult.IsLoginSkipped ? "Skipped" : (_LoginResult.IsLoginSuccessful ? "Failed" : "Passed");
                                _CsvData.Append(ExportToCSV.GetCsvString(_TestResult, true));
                                
                                string pwd = (m_maskPasswords) ? "***" : _LoginResult.SuccessfulPassword;
                                
                                _CsvData.Append(ExportToCSV.GetCsvString(string.IsNullOrEmpty(pwd) ? "" : pwd, true));
                                _CsvData.Append(Environment.NewLine);                        
                            }
                        }
                    }

                    if (SaveExportFile(_FileDialog.FileName, _CsvData.ToString()))
                    {
                        Messaging.ShowInformation("Export completed successfully");
                    }
                }
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Export to CSV", exc);
            }
        }



        private void menuExportAsXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (listResults.Items.Count == 0)
                {
                    Messaging.ShowError("There's no results to export");
                }

                SaveFileDialog _FileDialog = new SaveFileDialog();
                _FileDialog.AddExtension = true;
                _FileDialog.CheckPathExists = true;
                _FileDialog.OverwritePrompt = true;
                _FileDialog.DefaultExt = "xml";
                _FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                _FileDialog.FileName = CoreGlobals.productName + ".xml";
                _FileDialog.Filter = "XML File (*.xml)|*.xml|All files (*.*)|*.*";

                if (_FileDialog.ShowDialog() == DialogResult.OK)
                {
                    XmlDocument _XmlDocument = new XmlDocument();
                    XmlElement rootNode = _XmlDocument.CreateElement(ProductConstants.shortProductName);
                    _XmlDocument.AppendChild(rootNode);

                    foreach (ListViewItem _Item in listResults.Items)
                    {
                        TestResults _Results = _Item.Tag as TestResults;
                        if (_Results != null)
                        {
                            XmlElement _ServerResultsElement = _XmlDocument.CreateElement("Results");
                            XmlAttribute _ServerName = _XmlDocument.CreateAttribute("ServerName");
                            _ServerName.Value = _Results.ServerName;
                            _ServerResultsElement.Attributes.Append(_ServerName);
                            _XmlDocument.DocumentElement.AppendChild(_ServerResultsElement);

                            AddXmlElement("LoginsTested", _Results.ActuallyTestedCount.ToString(), _ServerResultsElement);
                            AddXmlElement("BadPasswordCount", _Results.FailureLoginCount.ToString(), _ServerResultsElement);
                            AddXmlElement("BlankPasswordCount", _Results.BlankPasswordCount.ToString(), _ServerResultsElement);
                            AddXmlElement("PasswordSameAsLoginCount", _Results.PasswordSameAsLoginCount.ToString(), _ServerResultsElement);

                            foreach (LoginResults _LoginResult in _Results.LoginResultsList)
                            {
                                XmlElement _DetailsElement = _XmlDocument.CreateElement("TestResults");
                                XmlAttribute _LoginName = _XmlDocument.CreateAttribute("LoginName");
                                _LoginName.Value = _LoginResult.UserName;
                                _DetailsElement.Attributes.Append(_LoginName);
                                _ServerResultsElement.AppendChild(_DetailsElement);

                                string _TestResult = _LoginResult.IsLoginSkipped ? "Skipped" : (_LoginResult.IsLoginSuccessful ? "Failed" : "Passed");
                                AddXmlElement("Result", _TestResult, _DetailsElement);
                                
                                string pwd = (m_maskPasswords) ? "***" : _LoginResult.SuccessfulPassword;
                                
                                AddXmlElement("Password", string.IsNullOrEmpty(pwd) ? "" : pwd, _DetailsElement);
                            }
                        }
                    }

                    _XmlDocument.Save(_FileDialog.FileName);
                    Messaging.ShowInformation("Export completed successfully");
                }
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Export to XML", exc);
            }
        }

        private void AddXmlElement(string name, string value, XmlElement parent)
        {
            XmlElement _NewElement = parent.OwnerDocument.CreateElement(name);
            _NewElement.AppendChild(parent.OwnerDocument.CreateTextNode(value));
            parent.AppendChild(_NewElement);
        }

        private void menuExportAsText_Click(object sender, EventArgs e)
        {
            try
            {
                if(listResults.Items.Count == 0)
                {
                    Messaging.ShowError("There's no results to export");
                }

                SaveFileDialog _FileDialog = new SaveFileDialog();
                _FileDialog.AddExtension = true;
                _FileDialog.CheckPathExists = true;
                _FileDialog.OverwritePrompt = true;
                _FileDialog.DefaultExt = "txt";
                _FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                _FileDialog.FileName = CoreGlobals.productName + ".txt";
                _FileDialog.Filter = "Text File (*.txt)|*.txt|All files (*.*)|*.*";

                if (_FileDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder _TextData = new StringBuilder();
                    
                    foreach (ListViewItem _Item in listResults.Items)
                    {
                        TestResults _Results = _Item.Tag as TestResults;
                        if (_Results != null)
                        {
                            if ( _TextData.Length != 0 )
                            {
                               _TextData.Append(Environment.NewLine);
                               _TextData.Append(Environment.NewLine);
                            }
                            
                            _TextData.Append("SQL Server          \tLogins\tBad Passwords\tBlank Password\tSame as Login");
                            _TextData.Append(Environment.NewLine);
                            _TextData.Append("--------------------\t------\t-------------\t--------------\t-------------");
                            _TextData.Append(Environment.NewLine);
                            
                            _TextData.AppendFormat("{0}\t{1}\t{2}\t{3}\t{4}", _Results.ServerName.PadRight(20), 
                                                                         _Results.ActuallyTestedCount.ToString().PadRight(6),
                                                                         _Results.FailureLoginCount.ToString().PadRight(13),
                                                                         _Results.BlankPasswordCount.ToString().PadRight(14),
                                                                         _Results.PasswordSameAsLoginCount.ToString().PadRight(13));
                            _TextData.Append(Environment.NewLine);
                            _TextData.Append(Environment.NewLine);
                            _TextData.Append("\tLogin\tResult\tPassword (if found)");
                            _TextData.Append(Environment.NewLine);
                            _TextData.Append("\t-----\t------\t-------------------");
                            _TextData.Append(Environment.NewLine);
                            foreach (LoginResults _LoginResult in _Results.LoginResultsList)
                            {
                                string pwd = (m_maskPasswords) ? "***" : _LoginResult.SuccessfulPassword;
                            
                                string _TestResult = _LoginResult.IsLoginSkipped ? "Skipped" : (_LoginResult.IsLoginSuccessful ? "Failed" : "Passed");
                                _TextData.AppendFormat("\t{0}\t{1}\t{2}", _LoginResult.UserName, 
                                                                          _TestResult,
                                                                          string.IsNullOrEmpty(pwd) ? "" : pwd);
                                _TextData.Append(Environment.NewLine);                        
                            }
                        }
                    }

                    if (SaveExportFile(_FileDialog.FileName, _TextData.ToString()))
                    {
                        Messaging.ShowInformation("Export completed successfully");
                    }
                }
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Export to TXT", exc);
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
