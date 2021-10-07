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
//using System.Data.SqlClient;
using Microsoft.Win32;
using System.Security.AccessControl;


using Idera.SqlAdminToolset.Core;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.ServerPing
{
    public partial class Form_Main : Form
    {
        #region Properties

        private bool minimizedToSystemTray = false;
        private ProgressBarDialog _ProgressDialog;
        private bool _exiting = false;

        private Mutex gotShowMessageMutex = null;

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

            notifyIcon1.Visible = false;

            base.OnLoad(e);
            if (!Startup.GuiStartup(this, menuTools, menuAbout, ideraTitleBar1))
            {
                _exiting = true; // need to set - otherwise it will keep runngin on system tray
                Close();
                return;
            }

            #endregion

            // Program Specific Logic
            ReadOptions();                     // check methods
            MonitoredServer.ReadServerList(); // what to check and what to ignore

            // get windows startup values to match tool registry value         
            SetRunAtStartup(ProductConstants.LaunchAtStartup, false);
            KillStartupEntry("IderaServerCheck");

            // update UI
            SetLinkLabel();
            ShowLastCheckTime();

            notifyIcon1.Visible = ProductConstants.RunInSystemTray;
            checkRunInSystemTray.Checked = ProductConstants.RunInSystemTray;
            checkAutoRefresh.Checked = ProductConstants.AutoRefresh;
            textRefreshInterval.Text = ProductConstants.AutoRefreshInterval.ToString();
            checkAlertOnline.Checked = ProductConstants.AlertOnline;
            checkAlertOffline.Checked = ProductConstants.AlertOffline;
            checkRunAtStartup.Checked = ProductConstants.LaunchAtStartup;
            checkMinimizeToSystemTray.Checked = ProductConstants.MinimizeToSystemTray;

            menuCopy.Enabled = false;
            contextCopy.Enabled = false;

            if (!radioServerGroup.Checked)
            {
                foreach (MonitoredServer srv in ProductConstants.monitoredServers)
                {
                    AddServerToListView(srv);
                }
            }

            timerAutoRefresh.Interval = ProductConstants.AutoRefreshInterval * 60 * 1000;
            if (ProductConstants.AutoRefresh)
            {
                timerAutoRefresh.Start();
            }

            timerCheckShow.Start();

            if (ProductConstants.StartInSystemTray)
            {
                WindowState = FormWindowState.Minimized;
                StartCheck();
            }

        }

        bool firstTime = true;
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (firstTime)
            {
                firstTime = false;
                if (ProductConstants.StartInSystemTray)
                {
                    Hide();
                }
            }

        }

        #endregion

        #region Common Code

        #region File Menu Event Handlers (Common)

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            if (CloseApp()) Close();
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!_exiting && ProductConstants.RunInSystemTray)
                {
                    // dont close if we are just minimizing
                    if (!CloseApp()) e.Cancel = true;
                }
            }
        }

        private bool CloseApp()
        {
            Debug.WriteLine("CloseApp");

            bool closeApp = true;

            bool runInSystemTray = ProductConstants.RunInSystemTray;

            if (runInSystemTray &&
                 ((radioServers.Checked && listServers.Items.Count == 0) ||
                   (radioServerGroup.Checked && (comboServerGroup.Text == "" ||
                                                  comboServerGroup.Text == _stringNoGroupsDefined)
               )))
            {
                // nothing being monitored - ask if they want to keep running
                DialogResult choice = Messaging.ShowConfirmation("You have not selected any servers to monitor. Do you still want to continue to keep Server Ping running as a system tray application?");
                if (choice == DialogResult.No)
                {
                    runInSystemTray = false;
                }
                else
                {
                    WindowState = FormWindowState.Minimized;
                    closeApp = false;
                }
            }
            else if (runInSystemTray)
            {
                DialogResult choice = DialogResult.OK;

                if (ProductConstants.warnOnExit)
                {
                    Form_Warning frm = new Form_Warning();
                    frm.Title = ProductConstants.productName;
                    choice = frm.ShowDialog();

                    if (frm.DoNotShowAgain)
                    {
                        ProductConstants.warnOnExit = false;
                        WriteOptions();
                    }
                }

                if (choice == DialogResult.OK)
                {
                    WindowState = FormWindowState.Minimized;
                    closeApp = false;
                }
                else
                {
                    closeApp = true;
                }
            }

            return closeApp;
        }

        private void menuExitToLaunchpad_Click(object sender, EventArgs e)
        {
            if (ProductConstants.RunInSystemTray)
            {
                if (Launchpad.Run(this))
                {
                    // delay to avoid blank screen when we close to early
                    Thread.Sleep(500);
                }
                CloseApp();
            }
            else
            {
                Launchpad.RunAndClose(this);
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

        protected override void WndProc(ref Message m)
        {
            if ((uint)m.Msg == Program.startHealthCheckPrivateMessage)
            {
                WindowState = FormWindowState.Normal;
                this.Activate();
            }
            base.WndProc(ref m);
        }


        private void Form_Main_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                if (checkRunning)
                {
                    ProgressBar_Close();
                }

                if (checkMinimizeToSystemTray.Checked)
                {
                    minimizedToSystemTray = true;
                    ShowInTaskbar = false;

                    // if Hide from task bar when minimzed and not Close to System Traychecked
                    // app would be invisible when minimized - so we just show in system tray then
                    if (!checkRunInSystemTray.Checked)
                    {
                        notifyIcon1.Visible = true;
                    }
                }
                else
                {
                    minimizedToSystemTray = false;
                    ShowInTaskbar = true;
                }
            }
            else  // return to normal or maximized
            {
                ShowInTaskbar = true;

                if (checkRunning)
                {
                    ProgressBar_Initialize();
                    ProgressBar_Show();
                }

                if (!checkRunInSystemTray.Checked && checkMinimizeToSystemTray.Checked)
                {
                    notifyIcon1.Visible = false;
                }

                minimizedToSystemTray = false;
            }
        }

        private string notifyBalloonText = "";

        private void showBalloonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolTipIcon ttIcon = ToolTipIcon.Info;

            if (notifyBalloonText != "")
            {
                notifyIcon1.ShowBalloonTip(20,
                                            "Information",
                                            notifyBalloonText,
                                            ttIcon);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _exiting = true;
            Close();
        }

        private void menuOpenHealthCheck_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        #region Server Management - Add

        private void buttonAddServer_Click(object sender, EventArgs e)
        {
            AddServer();
        }

        private void contextMenuAddServer_Click(object sender, EventArgs e)
        {
            AddServer();
        }

        private void AddServer()
        {
            Form_ServerProperties frm = new Form_ServerProperties();
            DialogResult choice = frm.ShowDialog();
            if (choice == DialogResult.OK)
            {
                listServers.BeginUpdate();
                foreach (MonitoredServer srv in frm.Servers)
                {
                    AddServerToListView(srv);
                }
                listServers.EndUpdate();
            }
        }

        private void AddServerToListView(MonitoredServer srv)
        {
            string newHost = SQLHelpers.GetInstanceHost(srv.server);
            string newInstance = SQLHelpers.GetInstance(srv.server);

            // check for service existence - if already exists - remove
            for (int i = 0; i < listServers.Items.Count; i++)
            {
                string oldHost = SQLHelpers.GetInstanceHost(listServers.Items[i].SubItems[1].Text);
                string oldInstance = SQLHelpers.GetInstance(listServers.Items[i].SubItems[1].Text);

                if (newHost == oldHost && newInstance == oldInstance)
                {
                    listServers.Items[i].Remove();
                    break;
                }
            }

            // add item
            ListViewItem lvi = new ListViewItem("");
            lvi.SubItems.Add(srv.server);

            if (srv.credentials == null || srv.credentials.useWindowsAuthentication)
                lvi.ImageIndex = 4;
            else
                lvi.ImageIndex = 5;

            lvi.Tag = srv;

            listServers.Items.Add(lvi);
        }

        #endregion

        #region Server Management - Edit

        private void buttonEditServer_Click(object sender, EventArgs e)
        {
            EditServer();
        }


        private void contextMenuEditServer_Click(object sender, EventArgs e)
        {
            EditServer();
        }

        private void EditServer()
        {
            if (listServers.SelectedItems.Count == 0)
            {
                buttonEditServer.Enabled = false;
                return;
            }

            int ndx = listServers.SelectedIndices[0];
            MonitoredServer monitoredServer = (MonitoredServer)listServers.SelectedItems[0].Tag;

            Form_ServerProperties frm = new Form_ServerProperties(monitoredServer);
            DialogResult choice = frm.ShowDialog();
            if (choice == DialogResult.OK)
            {
                listServers.BeginUpdate();

                listServers.Items[ndx].Remove(); // remove the one we edited - we will add it next
                foreach (MonitoredServer srv in frm.Servers)
                {
                    AddServerToListView(srv);
                }
                listServers.EndUpdate();
            }
        }

        #endregion

        #region Server Management - Remove

        private void buttonRemoveServer_Click(object sender, EventArgs e)
        {
            RemoveServer();
        }

        private void contextMenuRemoveServer_Click(object sender, EventArgs e)
        {
            RemoveServer();
        }

        private void RemoveServer()
        {
            if (listServers.SelectedItems.Count == 0)
            {
                buttonRemoveServer.Enabled = false;
                return;
            }

            DialogResult choice = Messaging.ShowConfirmation("Are you sure you want to remove the selected SQL server(s)?");
            if (choice == DialogResult.Yes)
            {
                listServers.BeginUpdate();
                listResults.BeginUpdate();
                while (listServers.SelectedItems.Count != 0)
                {
                    RemoveServerStatus(listServers.SelectedItems[0].SubItems[1].Text);
                    listServers.Items[listServers.SelectedIndices[0]].Remove();
                }
                listResults.EndUpdate();
                listServers.EndUpdate();
            }
            if (listResults.Items.Count < 1)
            {
                menuCopy.Enabled = false;
                contextCopy.Enabled = false;
            }
        }

        private void
           RemoveServerStatus(
              string server
           )
        {
            // remove from status list
            foreach (ListViewItem lvi in listResults.Items)
            {
                if (lvi.SubItems[1].Text == server)
                {
                    lvi.Remove();
                    break;
                }
            }
        }

        #endregion

        #region Check Health

        private bool ValidateHealthCheck()
        {
            if (minimizedToSystemTray) return true;

            if (radioServerGroup.Checked && (comboServerGroup.Text == ""))
            {
                Messaging.ShowError("Select a server group.");
                return false;
            }

            if (radioServerGroup.Checked && (comboServerGroup.Text == _stringNoGroupsDefined))
            {
                Messaging.ShowError("You have no server groups defined.");
                return false;
            }

            if (radioServers.Checked && (listServers.Items.Count == 0))
            {
                Messaging.ShowError("Specify a SQL Server.");
                return false;
            }

            return true;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if (ValidateHealthCheck())
            {
                PerformHealthCheck();
            }
        }

        private void contextMenuRefresh_Click(object sender, EventArgs e)
        {

            if (ValidateHealthCheck())
            {
                PerformHealthCheck();
            }
        }

        private void menuRefresh_Click(object sender, EventArgs e)
        {
            if (ValidateHealthCheck())
            {
                PerformHealthCheck();
            }
        }

        #endregion

        #region Clipboard / Export

        private void contextMenuCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard(false);
        }

        private void contextCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard(false);
        }


        private void menuCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard(false);
        }

        private void CopyToClipboard(bool selectedOnly)
        {
            ExportToClipboard.CopyListViewToTabbedFormat(listResults, true, selectedOnly);
        }

        private void contextMenuCSV_Click(object sender, EventArgs e)
        {
            SaveResultsAsCsv();
        }

        private void menuCsvFile_Click(object sender, EventArgs e)
        {
            SaveResultsAsCsv();
        }

        private void SaveResultsAsCsv()
        {
            ExportToCSV.CopyListView(listResults);
        }

        private void contextMenuXml_Click(object sender, EventArgs e)
        {
            SaveResultsAsXMl();
        }

        private void menuXmlFile_Click(object sender, EventArgs e)
        {
            SaveResultsAsXMl();
        }

        private void SaveResultsAsXMl()
        {
            ExportToXML.CopyListView(listResults, "Server Ping", true);
        }

        #endregion

        private void ShowLastCheckTime()
        {
            if (ProductConstants.lastCheckTime == DateTime.MinValue)
            {
                labelLastCheckTime.Text = "Last check: <None>";
            }
            else
            {
                labelLastCheckTime.Text = "Last check: " + ProductConstants.lastCheckTime.ToString();
            }
        }

        private void listServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonEditServer.Enabled =
            buttonRemoveServer.Enabled = listServers.SelectedItems.Count != 0;
        }

        private void radioServers_CheckedChanged(object sender, EventArgs e)
        {
            listServers.Enabled =
            buttonAddServer.Enabled =
            buttonEditServer.Enabled =
            buttonRemoveServer.Enabled = radioServers.Checked;

            if (radioServerGroup.Checked)
                listServers.BackColor = SystemColors.Control;
            else
                listServers.BackColor = Color.White;

            comboServerGroup.Enabled = radioServerGroup.Checked;
        }

        #region System Tray Options

        private void checkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkAutoRefresh.Checked)
            {
                timerAutoRefresh.Stop();
            }
            else
            {
                timerAutoRefresh.Start();
            }

            ProductConstants.AutoRefresh = checkAutoRefresh.Checked;
            textRefreshInterval.Enabled = checkAutoRefresh.Checked;
            WriteOptions();
        }

        private void textRefreshInterval_Leave(object sender, EventArgs e)
        {
            bool badValue = true;
            int autoRefresh = 10;

            try
            {
                autoRefresh = System.Convert.ToInt32(textRefreshInterval.Text);
                if (autoRefresh > 0 && autoRefresh < 10000) badValue = false;

                //reset timer            
                timerAutoRefresh.Stop();
                timerAutoRefresh.Interval = 60 * 1000 * autoRefresh;
                timerAutoRefresh.Start();
            }
            catch
            {
            }

            if (badValue)
            {
                Messaging.ShowError("Enter a valid interval between 1 and 9999 minutes.");
                textRefreshInterval.Select();
            }
            else
            {
                ProductConstants.AutoRefreshInterval = autoRefresh;
                WriteOptions();
            }
        }

        private void checkRunInSystemTray_CheckedChanged(object sender, EventArgs e)
        {
            ProductConstants.RunInSystemTray = checkRunInSystemTray.Checked;
            notifyIcon1.Visible = ProductConstants.RunInSystemTray;
            WriteOptions();
        }

        private void checkMinimizeToSystemTray_CheckedChanged(object sender, EventArgs e)
        {
            ProductConstants.MinimizeToSystemTray = checkMinimizeToSystemTray.Checked;
            WriteOptions();
        }

        private void checkAlertOnline_CheckedChanged(object sender, EventArgs e)
        {
            ProductConstants.AlertOnline = checkAlertOnline.Checked;
            WriteOptions();
        }

        private void checkAlertOffline_CheckedChanged(object sender, EventArgs e)
        {
            ProductConstants.AlertOffline = checkAlertOffline.Checked;
            WriteOptions();
        }

        private void checkRunAtStartup_CheckedChanged(object sender, EventArgs e)
        {
            SetRunAtStartup(checkRunAtStartup.Checked, true);
        }

        private void SetRunAtStartup(bool runAtStartup, bool writeOptions)
        {
            RegistryKey runKey = null;

            if (runAtStartup)
            {
                try
                {
                    runKey = ToolsetOptions.optionsRootKey.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");

                    string cmdLine = String.Format("{0} /NOWELCOMESCREEN /SYSTEMTRAY",
                                                    Application.ExecutablePath);
                    runKey.SetValue("IderaServerPing", cmdLine);

                    ProductConstants.LaunchAtStartup = true;
                    if (writeOptions) WriteOptions();
                }
                catch (Exception ex)
                {
                    if (writeOptions)  // only show msgbox if user just pressed checkbox
                    {
                        Messaging.ShowError(String.Format("Unable to set Ping Check startup value.\r\n\r\nError: {0}",
                                                            ex.Message));
                    }
                }
                finally
                {
                    if (runKey != null) runKey.Close();
                }
            }
            else
            {
                ProductConstants.LaunchAtStartup = false;
                if (writeOptions) WriteOptions();

                KillStartupEntry("IderaServerPing");
            }
        }

        static public void KillStartupEntry(string name)
        {
            RegistryKey runKey = null;

            // delete key            
            try
            {
                runKey = ToolsetOptions.optionsRootKey.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                runKey.DeleteValue(name);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            finally
            {
                if (runKey != null) runKey.Close();
            }
        }


        #endregion

        #region Server Group Combo Box Handling

        static private string _stringBrowsePrefix = "<Browse to select ";
        static private string _stringBrowseForGroups = "<Browse to select from all Server Groups>";
        static private string _stringManageGroups = "<Manage Server Groups>";
        static private string _stringNoGroupsDefined = "<No Server Groups Defined>";
        static private string _SaveGroupText = "";

        private int m_lastSelectedIndex = -1;
        private string m_lastSelectedGroup = "";

        private void comboServerGroup_DropDown(object sender, EventArgs e)
        {
            LoadDropDown(comboServerGroup.Text);
        }

        private void LoadDropDown(string selectedGroup)
        {
            comboServerGroup.BeginUpdate();
            try
            {
                _SaveGroupText = selectedGroup;

                comboServerGroup.Items.Clear();

                LoadComboBox();

                // selection text            
                int ndx = FindListItem(_SaveGroupText);
                if (ndx != -1 || comboServerGroup.Items.Count > 1)
                {
                    comboServerGroup.SelectedIndex = (ndx != -1) ? ndx : 0;
                }
            }
            finally
            {
                comboServerGroup.EndUpdate();
            }
        }

        private void LoadComboBox()
        {
            //--------------------
            // Load Server Groups
            //--------------------
            int foundNdx = -1;
            int count = 0;

            List<ToolServerGroup> groups = ToolServerGroup.GetAllServerGroups();

            if (groups.Count == 0)
            {
                _SaveGroupText = _stringNoGroupsDefined;
                AddComboBoxItem(_stringNoGroupsDefined, true);
                comboServerGroup.Text = _stringNoGroupsDefined;
                comboServerGroup.SelectedIndex = 0;
            }
            else
            {
                foreach (ToolServerGroup grp in groups)
                {
                    AddComboBoxItem(grp.FullPath, false);

                    if (grp.FullPath == _SaveGroupText) foundNdx = count;

                    count++;
                    if (count == 25) break;
                }

                // do we need to add saved group?
                if (foundNdx == -1)
                {
                    ToolServerGroup tsg = ToolServerGroup.FindServerGroup(_SaveGroupText);
                    if (tsg == null)
                    {
                        _SaveGroupText = (groups.Count == 0) ? "" : groups[0].FullPath;
                    }
                    else
                    {
                        // add to list
                        AddComboBoxItem(_SaveGroupText, false);
                    }
                }
            }

            if (groups.Count > 25)
            {
                AddComboBoxItem(_stringBrowseForGroups, true);
            }
            AddComboBoxItem(_stringManageGroups, true);
        }

        //-----------------------------------------------------------------------
        // InsertComboBoxItem
        //-----------------------------------------------------------------------
        private void
           InsertComboBoxItem(
              int ndx,
              string itemText,
              bool specialItem
           )
        {
            DevComponents.Editors.ComboItem newItem = CreateComboBoxItem(itemText, specialItem);
            comboServerGroup.Items.Insert(ndx, newItem);
        }

        //-----------------------------------------------------------------------
        // AddComboBoxItem
        //-----------------------------------------------------------------------
        private int
           AddComboBoxItem(
              string itemText,
              bool specialItem
           )
        {
            DevComponents.Editors.ComboItem newItem = CreateComboBoxItem(itemText, specialItem);
            return comboServerGroup.Items.Add(newItem);
        }

        //-----------------------------------------------------------------------
        // CreateComboBoxItem
        //-----------------------------------------------------------------------
        private DevComponents.Editors.ComboItem
           CreateComboBoxItem(
              string itemText,
              bool specialItem
           )
        {
            DevComponents.Editors.ComboItem newItem = new DevComponents.Editors.ComboItem();
            newItem.Text = itemText;
            newItem.TextLineAlignment = StringAlignment.Center;
            newItem.Tag = (object)specialItem;

            return newItem;
        }

        //-----------------------------------------------------------------------
        // comboServerGroup_SelectedIndexChanged
        //-----------------------------------------------------------------------
        private void comboServerGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool specialItem = false;
            try
            {
                DevComponents.Editors.ComboItem comboItem = (DevComponents.Editors.ComboItem)comboServerGroup.SelectedItem;
                specialItem = (comboItem != null) && ((bool)comboItem.Tag);
            }
            catch
            {
                /* this handles case where someone inserts without special APIs */
            }

            if (specialItem && comboServerGroup.Text.StartsWith(_stringBrowsePrefix))
            {
                Application.DoEvents(); // let form redraw without drop down dropped
                string newSelection = Browse();

                if (newSelection == "")
                {
                    comboServerGroup.SelectedIndex = m_lastSelectedIndex;
                }
                else
                {
                    // they selected one with browse (is it already there?)
                    bool found = false;
                    for (int i = 0; i < comboServerGroup.Items.Count; i++)
                    {
                        if (comboServerGroup.Items[i].ToString() == newSelection)
                        {
                            found = true;
                            comboServerGroup.SelectedIndex = i;
                            break;
                        }
                    }

                    if (!found)
                    {
                        // walk backwards to insert before special tag items
                        int ndx;
                        for (ndx = comboServerGroup.Items.Count - 1; ndx >= 0; ndx--)
                        {
                            try
                            {
                                DevComponents.Editors.ComboItem combo = (DevComponents.Editors.ComboItem)(comboServerGroup.Items[ndx]);
                                if (!(bool)combo.Tag)
                                {
                                    ndx++;
                                    break;
                                }
                            }
                            catch
                            {
                                break;
                            }
                        }
                        if (ndx == -1) ndx = 0;

                        InsertComboBoxItem(ndx, newSelection, false);
                        comboServerGroup.SelectedIndex = ndx;
                    }
                }

                m_lastSelectedGroup = comboServerGroup.Text;
            }
            else if (specialItem && comboServerGroup.Text == _stringNoGroupsDefined)
            {
                // do nothing?
                m_lastSelectedGroup = comboServerGroup.Text;
            }
            else if (specialItem && comboServerGroup.Text == _stringManageGroups)
            {
                Application.DoEvents(); // let form redraw without drop down dropped

                //launch
                Form_ManageServerGroups frm = new Form_ManageServerGroups();
                DialogResult dialogResult = frm.ShowDialog();

                //reload
                _SaveGroupText = m_lastSelectedGroup;

                if (dialogResult == DialogResult.OK)
                {
                    LoadComboBox();
                }

                int ndx = FindListItem(_SaveGroupText);
                if (ndx != -1 || comboServerGroup.Items.Count > 1)
                {
                    comboServerGroup.SelectedIndex = (ndx != -1) ? ndx : 0;
                }
                else
                {
                    comboServerGroup.SelectedIndex = -1;
                }
            }
        }

        //-----------------------------------------------------------------------
        // FindListItem
        //-----------------------------------------------------------------------
        private int FindListItem(string name)
        {
            int pos = -1;

            for (int i = 0; i < comboServerGroup.Items.Count; i++)
            {
                if (comboServerGroup.Items[i].ToString() == name)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        //-----------------------------------------------------------------------
        // Browse
        //-----------------------------------------------------------------------
        private string Browse()
        {
            string newSelection = "";

            // Browse Server Groups
            Form_ServerGroupBrowse dlg = new Form_ServerGroupBrowse();
            DialogResult choice = dlg.ShowDialog();
            if (choice == DialogResult.OK)
            {
                newSelection = dlg.FullPath;
            }

            return newSelection;
        }

        #endregion

        #region HealthCheck

        private static bool checkRunning = false;

        private JobPool<DataTable> m_JobPool;
        public static Dictionary<string, string> _ErrorReports = new Dictionary<string, string>();


        delegate void StartCheckDelegate();
        private void
           StartCheck()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new StartCheckDelegate(StartCheck));
                return;
            }

            PerformHealthCheck();
        }


        private void PerformHealthCheck()
        {
            if (checkRunning) return;
            checkRunning = true;

            timerAutoRefresh.Stop();

            labelProcessingError.Visible = false;

            // write server list to disk
            WriteServerOptions();

            _ErrorReports.Clear();
            listResults.Items.Clear();
            menuCopy.Enabled = false;
            contextCopy.Enabled = false;

            labelOverallStatus.Text = "Check in progress...";

            Application.DoEvents();

            try
            {
                List<ServerInformation> _ServerList = new List<ServerInformation>();

                for (int i = 0; i < ProductConstants.monitoredServers.Count; i++)
                {
                    ProductConstants.monitoredServers[i].partOfLastCheck = false;
                }

                if (radioServers.Checked)
                {
                    if (listServers.Items.Count == 0)
                    {
                        SetOverallStatusToUnknown();
                        labelProcessingError.Text = "No SQL Servers specified to check.";
                        labelProcessingError.Visible = true;
                        checkRunning = false;
                        if (ProductConstants.AutoRefresh) timerAutoRefresh.Start();
                        return;
                    }

                    foreach (ListViewItem lvi in listServers.Items)
                    {
                        MonitoredServer srv = (MonitoredServer)lvi.Tag;

                        int pos = MonitoredServer.FindServerInList(srv.server);
                        if (pos == -1)
                        {
                            ProductConstants.monitoredServers.Add(srv);
                        }
                        else
                        {
                            ProductConstants.monitoredServers[pos].credentials = srv.credentials;
                            ProductConstants.monitoredServers[pos].ignore = srv.ignore;
                        }

                        ServerInformation si = new ServerInformation(srv.server, srv.credentials);
                        _ServerList.Add(si);
                    }
                }
                else  // server group
                {
                    ToolServerGroup serverGroup = ToolServerGroup.FindServerGroup(comboServerGroup.Text);
                    if (serverGroup == null)
                    {
                        SetOverallStatusToUnknown();
                        labelProcessingError.Text = "No SQL Servers to check - The specified Server Group does not exist.";
                        labelProcessingError.Visible = true;
                        checkRunning = false;
                        if (ProductConstants.AutoRefresh) timerAutoRefresh.Start();
                        return;
                    }
                    List<ToolServer> servers = serverGroup.GetServers(true);

                    if (servers.Count == 0)
                    {
                        SetOverallStatusToUnknown();
                        labelProcessingError.Text = "No SQL Servers to check - The specified Server Group contains no SQL Servers.";
                        labelProcessingError.Visible = true;
                        checkRunning = false;
                        if (ProductConstants.AutoRefresh) timerAutoRefresh.Start();
                        return;
                    }

                    foreach (ToolServer ts in servers)
                    {
                        string instance = SQLHelpers.NormalizeInstanceName(ts.Name);

                        // update global list of monitored servers 
                        int ndx = MonitoredServer.FindServerInList(ts.Name);
                        if (ndx == -1)
                        {
                            MonitoredServer ms = new MonitoredServer(instance, ts.Credentials, false);
                            ProductConstants.monitoredServers.Add(ms);
                        }
                        else
                        {
                            ProductConstants.monitoredServers[ndx].credentials = ts.Credentials;
                        }

                        // server list for processing                  
                        ServerInformation si = new ServerInformation(instance, ts.Credentials);
                        _ServerList.Add(si);
                    }
                }

                labelLastCheckTime.Text = "Last check: In Progress...";
                ProgressBar_Initialize();

                m_JobPool = new JobPool<DataTable>(10);
                m_JobPool.ServerTaskComplete += JobPoolTaskComplete;
                m_JobPool.TaskComplete += AllTasksComplete;
                m_JobPool.Enqueue(CheckServerHealth, _ServerList, ToolsetOptions.commandTimeout);
                m_JobPool.StartAsync();

                if (!minimizedToSystemTray)
                {
                    ProgressBar_Show();
                }
            }
            finally
            {
            }
        }
        private static object threadLock = new object();

        public static DataTable
           CheckServerHealth(
              ServerInformation serverInformation,
              int commandTimeout,
              JobPoolOptions options
            )
        {
            lock (threadLock)
            {
                int ndx = MonitoredServer.FindServerInList(serverInformation.Name);
                if (ndx == -1)
                {
                    CoreGlobals.traceLog.ErrorFormat("CheckServerHealth: Cant find server {0} in list - skipping", serverInformation.Name);
                }
                else
                {
                    ProductConstants.monitoredServers[ndx].partOfLastCheck = true;
                    ProductConstants.monitoredServers[ndx].lastState = ProductConstants.monitoredServers[ndx].state;

                    if (ProductConstants.UseWMI)
                    {
                        Helper.WmiTest(ndx);
                    }
                    else
                    {
                        Helper.SqlTest(ndx);
                    }
                }
            }
            return null;
        }

        private static MonitoredServer
           GetMonitoredServer(
              string instance
           )
        {
            MonitoredServer ms = new MonitoredServer(instance, null, false);
            return ms;
        }

        private Object listLock = new Object();
        void JobPoolTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            int ndx = MonitoredServer.FindServerInList(e.Server.Name);

            ListViewItem lvi = new ListViewItem("");

            lvi.ImageIndex = GetImageIndexByState(ProductConstants.monitoredServers[ndx].state);
            if (ProductConstants.monitoredServers[ndx].ignore) lvi.ImageIndex += 3;

            lvi.SubItems.Add(ProductConstants.monitoredServers[ndx].server);
            lvi.SubItems.Add(GetStateString(ProductConstants.monitoredServers[ndx].state));
            lvi.SubItems.Add(ProductConstants.monitoredServers[ndx].ignore ? "Yes" : "No");
            lvi.SubItems.Add(ProductConstants.monitoredServers[ndx].errorMessage);

            if (ProductConstants.monitoredServers[ndx].lastState != ProductConstants.monitoredServers[ndx].state &&
                 ProductConstants.monitoredServers[ndx].lastState != MonitoredServer.ServerState.FirstTime)
            {
                // highlight rows that changes since last collection
                for (int i = 0; i < lvi.SubItems.Count; i++)
                {
                    lvi.SubItems[i].BackColor = Color.Yellow;
                }
            }
            lock (listLock)
            {
                listResults.Items.Add(lvi);
            }
            if (listResults.Items.Count > 0)
            {
                menuCopy.Enabled = true;
                contextCopy.Enabled = true;
            }

        }

        private Object alertLock = new Object();

        private void
           ShowAlert(
              int alertState,
              string instance
           )
        {
            lock (alertLock)
            {
                ToolTipIcon ttIcon = (alertState == 1) ? ToolTipIcon.Info : ToolTipIcon.Error;

                notifyIcon1.ShowBalloonTip(10,
                                            "Server Ping",
                                            String.Format("{0} {1}",
                                                           instance,
                                                           (alertState == 1) ? "has come online"
                                                                              : "has gone offline"),
                                            ttIcon);
            }
        }

        private int GetImageIndexByState(MonitoredServer.ServerState state)
        {
            int imageIndex;

            if (state == MonitoredServer.ServerState.OK)
                imageIndex = 6 + 1;
            //else if ( state == MonitoredServer.ServerState.Unknown )
            //   imageIndex = 6+2;
            else
                imageIndex = 6 + 3;

            return imageIndex;
        }

        private string GetStateString(MonitoredServer.ServerState state)
        {
            string txt;

            switch (state)
            {
                case MonitoredServer.ServerState.OK:
                    txt = "OK";
                    break;
                case MonitoredServer.ServerState.NotRunning:
                    txt = "Down";
                    break;
                case MonitoredServer.ServerState.NotInstalled:
                    txt = "Not Installed";
                    break;
                case MonitoredServer.ServerState.UnableToConnect:
                    txt = "Unable to Connect";
                    break;
                case MonitoredServer.ServerState.QueryFailed:
                    txt = "Query Failed";
                    break;
                case MonitoredServer.ServerState.Paused:
                    txt = "Paused";
                    break;
                default:
                    txt = "Unknown";
                    break;
            }
            return txt;
        }

        private int FindMatchingListItem(string instance)
        {
            int pos = -1;
            for (int i = 0; i < listResults.Items.Count; i++)
            {
                if (instance == listResults.Items[i].SubItems[1].Text)
                {
                    pos = i;
                    break;
                }
            }

            return pos;
        }

        void AllTasksComplete(object sender, JobExecutionEventArgs e)
        {
            ProgressBar_Close();
            ProductConstants.lastCheckTime = DateTime.Now;
            ShowLastCheckTime();

            // system tray alerts
            string offline = "";
            string online = "";
            int nOffline = 0;
            int nOnline = 0;

            for (int ndx = 0; ndx < ProductConstants.monitoredServers.Count; ndx++)
            {
                int alertState = MonitoredServer.GetAlertState(ndx);
                if (minimizedToSystemTray && alertState != 0)
                {
                    if (alertState == 1 && ProductConstants.AlertOnline)
                    {
                        if (online != "") online += ", ";
                        online += ProductConstants.monitoredServers[ndx].server;
                        nOnline++;
                    }
                    else if (alertState == 2 && ProductConstants.AlertOffline)
                    {
                        if (offline != "") offline += ", ";
                        offline += ProductConstants.monitoredServers[ndx].server;
                        nOffline++;
                    }
                }
            }

            if (nOnline != 0 || nOffline != 0)
            {
                string msg = "";
                if (online != "")
                {
                    if (online != "") msg += String.Format("{0} came online.", online);
                }

                if (offline != "")
                {
                    if (msg != "") msg += "\r\n";
                    if (offline != "") msg += String.Format("{0} went offline.", offline);
                }

                if (msg.Length >= 64)  // maximum length of balloon text for NotifyIcon is 64
                {
                    msg = "";
                    if (nOnline != 0) msg += String.Format("{0} servers came online.", nOnline);
                    if (nOffline != 0)
                    {
                        if (msg != "") msg += "\r\n";
                        msg += String.Format("{0} servers went offline.", nOffline);
                    }
                }

                ToolTipIcon ttIcon = (nOffline == 0) ? ToolTipIcon.Info : ToolTipIcon.Error;

                notifyIcon1.ShowBalloonTip(10,
                                            "Server Ping",
                                            msg,
                                            ttIcon);
            }

            MonitoredServer.WriteServerList(); // what to check and what to ignore

            // update overall status
            UpdateOverallStatus();

            if (ProductConstants.AutoRefresh)
            {
                timerAutoRefresh.Start();
            }

            checkRunning = false;

        }

        private void UpdateOverallStatus()
        {
            int overallStatus = MonitoredServer.GetOverallState();

            // form - overall status
            pictureOverallStatus.Image = imageListBig.Images[overallStatus];

            // notify icon - overall status
            using (Bitmap myBitmap = new Bitmap(imageList1.Images[overallStatus]))
            {
                IntPtr Hicon = myBitmap.GetHicon();
                using (Icon newIcon = Icon.FromHandle(Hicon))
                {
                    notifyIcon1.Icon = newIcon;
                }
            }

            if (overallStatus == 1)
            {
                notifyIcon1.Text = "All monitored servers are OK.";
                labelOverallStatus.Text = "All Servers are OK";
            }
            else
            {
                int count = 0;
                foreach (MonitoredServer ms in ProductConstants.monitoredServers)
                {
                    if (!ms.ignore && ms.state != MonitoredServer.ServerState.OK)
                    {
                        count++;
                    }
                }

                string msg = String.Format("{0} SQL Server{1} not OK", count, (count == 1) ? " is" : "s are");

                labelOverallStatus.Text = msg;
                notifyIcon1.Text = msg;
            }
        }

        private void SetOverallStatusToUnknown()
        {
            // form - overall status
            pictureOverallStatus.Image = imageListBig.Images[0];

            // notify icon - overall status
            using (Bitmap myBitmap = new Bitmap(imageList1.Images[0]))
            {
                IntPtr Hicon = myBitmap.GetHicon();
                using (Icon newIcon = Icon.FromHandle(Hicon))
                {
                    notifyIcon1.Icon = newIcon;
                }
            }

            labelOverallStatus.Text = "Unable to check server status";

            notifyIcon1.Text = "No SQL Servers specified to check.";
        }

        #endregion

        #region Options

        private void menuHealthCheckOptions_Click(object sender, EventArgs e)
        {
            UpdateOptions();
        }

        private void labelMethod_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateOptions();
        }

        private void UpdateOptions()
        {
            Form_Options frm = new Form_Options(ProductConstants.UseWMI,
                                                 ProductConstants.RunQuery,
                                                 ProductConstants.Query,
                                                 ProductConstants.warnOnExit);
            DialogResult choice = frm.ShowDialog();
            if (choice == DialogResult.OK)
            {
                // get values
                ProductConstants.UseWMI = frm.m_useWmi;
                ProductConstants.RunQuery = frm.m_runQuery;
                ProductConstants.Query = frm.m_query;
                ProductConstants.warnOnExit = frm.m_warnOnExit;

                // update link label
                SetLinkLabel();

                // write to registry
                WriteOptions();
            }
        }

        private void SetLinkLabel()
        {
            labelMethod.Text = ProductConstants.UseWMI ? "Server check method: WMI" :
                                                         "Server check method: SQL Connection";
        }


        private void WriteServerOptions()
        {
            RegistryKey toolsetKey = null;
            RegistryKey toolKey = null;

            try
            {
                toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
                toolKey = toolsetKey.CreateSubKey(ProductConstants.shortProductName);

                toolKey.SetValue("UseServerGroup", radioServerGroup.Checked ? 1 : 0);
                toolKey.SetValue("ServerGroup", comboServerGroup.Text);
            }
            catch (Exception ex)
            {
                CoreGlobals.traceLog.ErrorFormat("WriteServerOptions error: {0}", ex.Message);
            }
            finally
            {
                if (toolsetKey != null) toolsetKey.Close();
                if (toolKey != null) toolKey.Close();
            }
        }

        private void WriteOptions()
        {
            RegistryKey toolsetKey = null;
            RegistryKey toolKey = null;

            try
            {
                toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
                toolKey = toolsetKey.CreateSubKey(ProductConstants.shortProductName);

                toolKey.SetValue("Method", ProductConstants.UseWMI ? 1 : 0);
                toolKey.SetValue("RunQuery", ProductConstants.RunQuery ? 1 : 0);
                string encryptedQuery = "";
                if (!String.IsNullOrEmpty(ProductConstants.Query))
                {
                    encryptedQuery = EncryptionHelper.QuickEncrypt(ProductConstants.Query);
                }
                toolKey.SetValue("Query", encryptedQuery);

                toolKey.SetValue("RunInSystemTray", ProductConstants.RunInSystemTray ? 1 : 0);
                toolKey.SetValue("AutoRefresh", ProductConstants.AutoRefresh ? 1 : 0);
                toolKey.SetValue("AutoRefreshInterval", ProductConstants.AutoRefreshInterval);
                toolKey.SetValue("AlertOnline", ProductConstants.AlertOnline ? 1 : 0);
                toolKey.SetValue("AlertOffline", ProductConstants.AlertOffline ? 1 : 0);
                toolKey.SetValue("MinimizeToSystemTray", ProductConstants.MinimizeToSystemTray ? 1 : 0);
                toolKey.SetValue("LaunchAtStartup", ProductConstants.LaunchAtStartup ? 1 : 0);

                toolKey.SetValue("WarnOnExit", ProductConstants.warnOnExit ? 1 : 0);
                toolKey.SetValue("WarnOnMinimize", ProductConstants.warnOnMinimize ? 1 : 0);

            }
            catch (Exception ex)
            {
                CoreGlobals.traceLog.ErrorFormat("WriteOptions error: {0}", ex.Message);
            }
            finally
            {
                if (toolsetKey != null) toolsetKey.Close();
                if (toolKey != null) toolKey.Close();
            }
        }

        public void ReadOptions()
        {
            RegistryKey toolsetKey = null;
            RegistryKey toolKey = null;

            try
            {
                toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
                toolKey = toolsetKey.CreateSubKey(ProductConstants.shortProductName);

                // server specification
                int bGroup = (int)toolKey.GetValue("UseServerGroup", 0);
                string group = (string)toolKey.GetValue("ServerGroup", "");
                if (bGroup == 1)
                {
                    radioServerGroup.Checked = true;
                    LoadDropDown(group);
                }

                // connection timeout
                int method = (int)toolKey.GetValue("Method", 1);
                ProductConstants.UseWMI = (method != 0);

                int runQuery = (int)toolKey.GetValue("RunQuery", 0);
                ProductConstants.RunQuery = (runQuery != 0);

                string query = (string)toolKey.GetValue("Query", "");
                if (String.IsNullOrEmpty(query))
                {
                    ProductConstants.RunQuery = false;
                    ProductConstants.Query = "SELECT @@VERSION";
                }
                else
                {
                    ProductConstants.Query = EncryptionHelper.QuickDecrypt(query);
                }

                ProductConstants.RunInSystemTray = GetRegistryBool(toolKey, "RunInSystemTray", true);
                ProductConstants.AutoRefresh = GetRegistryBool(toolKey, "AutoRefresh", false);

                int val = (int)toolKey.GetValue("AutoRefreshInterval", 10);
                if (val < 1 || val > 9999) val = 10;
                ProductConstants.AutoRefreshInterval = val;

                ProductConstants.AlertOnline = GetRegistryBool(toolKey, "AlertOnline", false);
                ProductConstants.AlertOffline = GetRegistryBool(toolKey, "AlertOffline", true);
                ProductConstants.MinimizeToSystemTray = GetRegistryBool(toolKey, "MinimizeToSystemTray", true);
                ProductConstants.LaunchAtStartup = GetRegistryBool(toolKey, "LaunchAtStartup", false);

                ProductConstants.warnOnExit = GetRegistryBool(toolKey, "WarnOnExit", true);
                ProductConstants.warnOnMinimize = GetRegistryBool(toolKey, "WarnOnMinimize", true);
            }
            catch (Exception ex)
            {
                CoreGlobals.traceLog.ErrorFormat("ReadOptions error: {0}", ex.Message);
            }
            finally
            {
                if (toolsetKey != null) toolsetKey.Close();
                if (toolKey != null) toolKey.Close();
            }
        }

        private bool
           GetRegistryBool(
              RegistryKey key,
              string value,
              bool defaultValue
           )
        {
            bool retval = false;

            int val = (int)key.GetValue(value, (defaultValue) ? 1 : 0);
            retval = (val != 0);

            return retval;
        }

        #endregion

        #region Progress Bar

        public void ProgressBar_Show()
        {
            if (_ProgressDialog != null)
            {
                _ProgressDialog.ShowDialog();
            }
        }
        public void ProgressBar_Close()
        {
            if (_ProgressDialog != null)
            {
                _ProgressDialog.TopLevel = false;
                _ProgressDialog.Visible = false;
                _ProgressDialog.Close();
                _ProgressDialog = null;
            }
        }

        public void ProgressBar_MakeVisible()
        {
            if (_ProgressDialog != null)
            {
                _ProgressDialog.TopLevel = true;
                _ProgressDialog.Visible = true;
                _ProgressDialog.WindowState = FormWindowState.Normal;
            }
        }

        public void ProgressBar_Initialize()
        {
            _ProgressDialog = new ProgressBarDialog();
            _ProgressDialog.OperationText = "Checking Servers...";
            _ProgressDialog.CancelEnabled = true;
            _ProgressDialog.ProgressCancelEvent += new EventHandler<EventArgs>(ProgressBar_CancelHandler);
            _ProgressDialog.ProgressMinimizeEvent += new EventHandler<EventArgs>(ProgressBar_MinimizeHandler);
        }

        public void ProgressBar_CancelHandler(object sender, EventArgs e)
        {
            _ProgressDialog.OperationText = "Cancelling...";
            _ProgressDialog.CancelEnabled = false;

            m_JobPool.Cancel(true);
        }

        public void ProgressBar_MinimizeHandler(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Column Sorting

        private int sortColumn = -1;
        private readonly SortOrder sortOrder = SortOrder.Ascending;

        private void ResetSort()
        {
            sortColumn = -1;
            listResults.Sorting = sortOrder;
        }

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
                if (listResults.Sorting == SortOrder.Ascending)
                    listResults.Sorting = SortOrder.Descending;
                else
                    listResults.Sorting = SortOrder.Ascending;
            }

            listResults.ListViewItemSorter = new ListViewItemComparer(e.Column, listResults.Sorting);
            listResults.Sort();
        }

        // Implements the manual sorting of items by column.
        class ListViewItemComparer : IComparer
        {
            private readonly int col;
            private readonly SortOrder order;

            //public ListViewItemComparer()
            //{
            //    col=0;
            //    order = System.Windows.Forms.SortOrder.Ascending;
            //}

            public ListViewItemComparer(int column, SortOrder order)
            {
                col = column;
                this.order = order;
            }

            public int Compare(object x, object y)
            {
                int returnVal;

                if (col == 0 /* Icon */ )
                {
                    returnVal = Helpers.CompareInt(((ListViewItem)x).ImageIndex, ((ListViewItem)y).ImageIndex);
                }
                else /* the rest of the columns are simple strings */
                {
                    returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                                ((ListViewItem)y).SubItems[col].Text);
                }

                if (order == SortOrder.Descending) returnVal *= -1;

                return returnVal;
            }
        }

        #endregion

        private void listResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            contextMenuIgnoreServer.Enabled = (listResults.SelectedItems.Count != 0);

            if (listResults.SelectedItems.Count != 0)
            {
                ListViewItem lvi = listResults.SelectedItems[0];
                contextMenuIgnoreServer.Checked = lvi.SubItems[3].Text == "Yes";
            }

            contextMenuStartServer.Enabled = contextMenuStopServer.Enabled = contextMenuPauseServer.Enabled =
               contextMenuResumeServer.Enabled = contextMenuRestartServer.Enabled = false;
            if (listResults.SelectedItems.Count == 1 && ProductConstants.UseWMI)
            {
                int pos = listResults.SelectedIndices[0];
                int ndx = MonitoredServer.FindServerInList(listResults.Items[pos].SubItems[1].Text);
                if (ndx > -1)
                {
                    switch (ProductConstants.monitoredServers[ndx].state)
                    {
                        case MonitoredServer.ServerState.NotRunning:
                            contextMenuStartServer.Enabled = true;
                            break;
                        case MonitoredServer.ServerState.OK:
                            contextMenuStopServer.Enabled = contextMenuPauseServer.Enabled = contextMenuRestartServer.Enabled = true;
                            break;
                        case MonitoredServer.ServerState.Paused:
                            contextMenuStopServer.Enabled = contextMenuResumeServer.Enabled = contextMenuRestartServer.Enabled = true;
                            break;
                    }
                }
            }
        }

        private void contextMenuIgnoreServer_Click(object sender, EventArgs e)
        {
            if (listResults.SelectedItems.Count == 0) return;
            int pos = listResults.SelectedIndices[0];

            int ndx = MonitoredServer.FindServerInList(listResults.Items[pos].SubItems[1].Text);
            if (ndx == -1) return;

            if (listResults.Items[pos].SubItems[3].Text == "Yes")
            {
                ProductConstants.monitoredServers[ndx].ignore = false;
                listResults.Items[pos].SubItems[3].Text = "No";
                contextMenuIgnoreServer.Checked = false;

                listResults.Items[pos].ImageIndex = GetImageIndexByState(ProductConstants.monitoredServers[ndx].state);
            }
            else
            {
                ProductConstants.monitoredServers[ndx].ignore = true;
                listResults.Items[pos].SubItems[3].Text = "Yes";
                contextMenuIgnoreServer.Checked = true;

                listResults.Items[pos].ImageIndex = GetImageIndexByState(ProductConstants.monitoredServers[ndx].state) + 3;
            }

            UpdateOverallStatus();
            WriteServerOptions();
        }

        private void contextMenuStartServer_Click(object sender, EventArgs e)
        {
            ChangeServerState(ServerOperation.Start);
        }
        private void contextMenuStopServer_Click(object sender, EventArgs e)
        {
            ChangeServerState(ServerOperation.Stop);
        }

        private void contextMenuResumeServer_Click(object sender, EventArgs e)
        {
            ChangeServerState(ServerOperation.Resume);
        }

        private void contextMenuPauseServer_Click(object sender, EventArgs e)
        {
            ChangeServerState(ServerOperation.Pause);
        }

        private void contextMenuRestartServer_Click(object sender, EventArgs e)
        {
            ChangeServerState(ServerOperation.Restart);
        }

        private void ChangeServerState(ServerOperation operation)
        {
            if (listResults.SelectedItems.Count == 0) return;
            int pos = listResults.SelectedIndices[0];

            int ndx = MonitoredServer.FindServerInList(listResults.Items[pos].SubItems[1].Text);
            if (ndx == -1) return;

            try
            {
                Cursor = Cursors.WaitCursor;

                if (operation == ServerOperation.Restart)
                {
                    Helper.ChangeServerState(ndx, ServerOperation.Stop);
                    Helper.ChangeServerState(ndx, ServerOperation.Start);
                }
                else
                {
                    Helper.ChangeServerState(ndx, operation);
                }
            }
            catch (Exception exc)
            {
                Messaging.ShowException(operation.ToString(), exc);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if (ValidateHealthCheck())
            {
                PerformHealthCheck();
            }
        }

        private void menuReallyExit_Click(object sender, EventArgs e)
        {
            _exiting = true;
            Close();
        }

        #region Timer

        private void StartTimer()
        {
        }

        private void StopTimer()
        {
        }

        private void ResetTimer()
        {
        }

        #endregion

        private void timerAutoRefresh_Tick(object sender, EventArgs e)
        {
            StartCheck();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void timerCheckShow_Tick(object sender, EventArgs e)
        {
            try
            {
                if (gotShowMessageMutex != null)
                {
                    try
                    {
                        gotShowMessageMutex.Close();
                    }
                    catch (Exception) { }
                    finally
                    {
                        gotShowMessageMutex = null;
                    }
                }
                Mutex m = Mutex.OpenExisting(CoreGlobals.showHealthCheckMutex, MutexRights.Modify | MutexRights.Delete | MutexRights.Synchronize);
                m.Close();
                if (gotShowMessageMutex == null)
                {
                    gotShowMessageMutex = new Mutex(true, CoreGlobals.gotShowHealthCheckMutex);
                }
                Show();
                WindowState = FormWindowState.Normal;
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                // Mutex doesn't exist, so no one is trying to show us, continue...   
            }
            catch //(Exception ex)
            {
                //Messaging.ShowException("Timer", ex);
            }
        }

        private void ShowF1Help(object sender, HelpEventArgs hlpevent)
        {
            HelpMenu.ShowHelp();
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

