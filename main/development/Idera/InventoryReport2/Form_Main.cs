using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Idera.SqlAdminToolset.Core;
using Microsoft.Win32;
using System.Diagnostics;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.InventoryReport
{
    public partial class Form_Main : Form
    {
        public static Dictionary<string, string> _ErrorReports = new Dictionary<string, string>();
        public static Dictionary<string, Exception> _WmiExceptions = new Dictionary<string, Exception>(); 
        private enum GroupEnum
        {
            reportGroup = 0,
            sqlGroup = 1,
            networkLibraries = 2,
            computerGroup = 3,
            sql65 = 4,
            sql70 = 5,
            sql2000 = 6,
            sql2005 = 7,
            sql2008 = 8,
            sql2012= 9,
            sql2014 = 10,
            sql2016 = 11,
            sql2017=12,
            sqlUnknown = 13
            
        }

        private bool m_highlightDifferences = false;
        private bool m_saveHighlightDifferences;

        private bool m_showServersAsRows = false;
        private bool m_showComputerProperties;
        private bool m_showSqlProperties;
        private bool m_showSqlVersionProperties;
        private bool m_ClearAllChecked = false;

        private bool m_workingWithServerGroup = false;
        private string m_serverSelection = "";
        List<ServerInformation> m_ServerList;

        private JobPool<InventoryData> m_JobPool;
        static public List<InventoryData> m_InventoryData;
        
        private ToolProgressBarDialog _ProgressDialog;

        #region Constructor

        public Form_Main()
        {
            InitializeComponent();
            this.Text = ideraTitleBar1.IderaProductNameText;
            m_InventoryData = new List<InventoryData>();
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
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

            // create snapshot folder if it doesnt already exist
            ProductConstants.SnapshotFolder = Helpers.GetProductDirectory(true);

            comboReportType.Text = comboReportType.Items[0].ToString();
            SetReportParametersBasedOnType();
            buttonHighlightDifferences.Text = ProductConstants.HighlightButtonShowDifferences;
            labelWmiErrors.Visible = linkWmiErrorDetails.Visible = false;
            //Get Clear Reports value out of registry
            try
            {
               using (RegistryKey _Key = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey))
               using (RegistryKey _SubKey = _Key.CreateSubKey(ProductConstants.shortProductName))
               {
                  bool.TryParse(_SubKey.GetValue(ProductConstants.ClearReportsCheckedRegistryValue).ToString(), out m_ClearAllChecked);
               }
            }
            catch { }
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
            _ProgressDialog.OperationText = "Loading Inventory Data...";
            _ProgressDialog.CancelEnabled = true;
            _ProgressDialog.ProgressCancelEvent += new EventHandler<EventArgs>(ProgressBar_CancelHandler);
        }

        public void ProgressBar_CancelHandler(object sender, EventArgs e)
        {
            _ProgressDialog.OperationText = "Cancelling...";
            _ProgressDialog.CancelEnabled = false;
            
            m_JobPool.Cancel(true);
        }
        
        #endregion

        #region Capture Data

        private void buttonCaptureData_Click(object sender, EventArgs e)
        {
            // Validation
            if (ServerSelection.Text.Trim().Length == 0)
            {
                Messaging.ShowError("Specify a SQL Server or Server Group");
                ServerSelection.Select();
                return;
            }

            m_workingWithServerGroup = ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Group;
            m_serverSelection = ServerSelection.Text;
            m_ServerList = ServerSelection.ServerList;
            m_ClearAllChecked = false;

            if (m_ServerList.Count == 0)
            {
               Messaging.ShowError(ProductConstants.ErrorServerGroupIsEmpty);
               return;
            }
            
            MRU.AddServerOrGroup(ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server,
                                 ServerSelection.Text,
                                 ServerSelection.SqlCredentials);

            CaptureLiveData(true);
        }
        
        private void CaptureLiveData(bool clearAllExisting)
        {
            try
            {
                _ErrorReports.Clear();
                //Cursor = Cursors.WaitCursor;

                if (clearAllExisting)
                {
                    listInventory.BeginUpdate();
                    listInventory.Clear();
                    m_InventoryData.Clear();
                    LoadPropertyNames();
                    ApplyHighlights(false);
                    listInventory.EndUpdate();
                    _WmiExceptions.Clear();
                    labelWmiErrors.Visible = linkWmiErrorDetails.Visible = false;
                }

                if (m_workingWithServerGroup)
                {
                    groupInventory.Text = "Server Inventory for the server group " + m_serverSelection;
                }
                else
                {
                    groupInventory.Text = "Server Inventory";
                }

                Application.DoEvents();
                
                ProgressBar_Initialize();

                m_JobPool = new JobPool<InventoryData>(10);

                m_JobPool.ServerTaskComplete += JobPoolTaskComplete;
                m_JobPool.TaskComplete += AllTasksComplete;
                m_JobPool.Enqueue(InventoryHelper.HarvestData, m_ServerList, ToolsetOptions.commandTimeout);
                m_JobPool.StartAsync();
                
                ProgressBar_Show();
            }
            catch (Exception exc)
            {
                ProgressBar_Close();
                Messaging.ShowException("Inventory Report", exc);
            }
        }

        void AllTasksComplete(object sender, JobExecutionEventArgs e)
        {
            try
            {
                ProgressBar_Close();

                if (_ErrorReports.Count > 0)
                {
                    Form_MultipleServerError frm = new Form_MultipleServerError();
                    foreach (KeyValuePair<string, string> _Error in _ErrorReports)
                    {
                        frm.AddError(_Error.Key, _Error.Value);
                    }

                    IntPtr _Handle = Process.GetCurrentProcess().MainWindowHandle;

                    if (_Handle != (IntPtr)0)
                    {
                        frm.ShowDialog(new WindowWrapper(_Handle));
                    }
                    else
                    {
                        BeginInvoke((MethodInvoker)delegate() { frm.ShowDialog(); });
                    }
                }
                if (_WmiExceptions.Count > 0)
                {
                    labelWmiErrors.Visible = linkWmiErrorDetails.Visible = true;
                    BeginInvoke((MethodInvoker)delegate() { ShowWmiToolTip(); });
                }
            }
            finally
            {
                CheckButtonStatus();

                if (listInventory.Items.Count != 0)
                {
                    listInventory.Items[0].Selected = true;
                    listInventory.Select();
                }

                Cursor = Cursors.Default;
            }
        }

        void JobPoolTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            if (e.Status == TaskStatus.Failed)
            {
               if (_ErrorReports.ContainsKey(e.Server.Name))
               {
                  _ErrorReports[e.Server.Name] += Environment.NewLine + e.ErrorMessage;
               }
               else
               {
                  _ErrorReports.Add(e.Server.Name, e.ErrorMessage);
               }
            }
            else if (e.Status == TaskStatus.Success)
            {
                listInventory.BeginUpdate();
                try
                {
                    InventoryData _Data = e.Resultset as InventoryData;
                    if (_Data != null)
                    {
                        AddDataToListView(_Data, "", true);
                        if (_Data.wmiException != null && !_WmiExceptions.ContainsKey(e.Server.Name))
                        {
                            _WmiExceptions.Add(e.Server.Name, _Data.wmiException);
                        }
                    }
                }
                catch (Exception exc)
                {
                    if (_ErrorReports.ContainsKey(e.Server.Name))
                    {
                        _ErrorReports[e.Server.Name] += Environment.NewLine + Helpers.GetCombinedExceptionText(exc);
                    }
                    else
                    {
                        _ErrorReports.Add(e.Server.Name, Helpers.GetCombinedExceptionText(exc));
                    }
                }
                listInventory.EndUpdate();
            }
        }

        #endregion

        #region List Management

        public List<InventoryData> CreateInventoryList()
        {
            List<InventoryData> _InventoryList = new List<InventoryData>();

            //we need to temporarily change the orientation of the list to columns (the default view)
            //to print, save the snapshot, etc.  This is a cheezy way to do it, but it works and it's 
            //a quick way to accomplish the goal.  ;)
            bool shownAsRowsToggled = false;
            if (m_showServersAsRows)
            {
                m_showServersAsRows = false;
                shownAsRowsToggled = true;
                RedrawList(false);
            }

            for (int i = 1; i < listInventory.Columns.Count; i++)
            {
                _InventoryList.Add((InventoryData)listInventory.Columns[i].Tag);
            }

            //put it back to what it was
            if (shownAsRowsToggled)
            {
                m_showServersAsRows = true;
                RedrawList(false);
            }

            return _InventoryList;
        }
        
        private void ClearList()
        {
            m_InventoryData.Clear();
            _WmiExceptions.Clear();
            labelWmiErrors.Visible = linkWmiErrorDetails.Visible = false;
            RedrawList(true);
        }

        private void RedrawList(bool checkButtonStatus)
        {
            listInventory.BeginUpdate();
            listInventory.Clear();
            LoadPropertyNames();

            for (int i = 0; i < m_InventoryData.Count; i++)
            {
                AddDataToListView(m_InventoryData[i], m_InventoryData[i].SnapshotFile, false);
            }

            ApplyHighlights(m_highlightDifferences);

            listInventory.EndUpdate();

            if (checkButtonStatus) CheckButtonStatus();
        }

        private void CheckButtonStatus()
        {
            bool hasItems;

            if (m_showServersAsRows)
            {
                hasItems = (listInventory.Items.Count != 0);
            }
            else
            {
                hasItems = (listInventory.Columns.Count > 1);
            }

            buttonSave.Enabled = hasItems;
            menuSaveSnapshot.Enabled = hasItems;
            contextMenuSaveSnapshot.Enabled = hasItems;

            menuSelectAll.Enabled = hasItems;
            contextMenuSelectAll.Enabled = hasItems;

            contextMenuRemoveServer.Enabled = hasItems;

            buttonClear.Enabled = hasItems;
            menuClear.Enabled = hasItems;
            contextMenuClear.Enabled = hasItems;
            printToolStripMenuItem.Enabled = hasItems;

            menuClearLiveData.Enabled = hasItems;
            menuClearSnapshots.Enabled = hasItems;

            menuExport.Enabled = hasItems;
            contextMenuExport.Enabled = hasItems;

            menuSaveAsServerGroup.Enabled = hasItems;
            contextMenuSaveAsServerGroup.Enabled = hasItems;
        }

        private void LoadPropertyNames()
        {
            AddPropertyHeader();

            // Report Properties
            if (!m_showServersAsRows)
            {
                AddPropertyItem(ProductConstants.ReportTypeCaption, GroupEnum.reportGroup);
                AddPropertyItem(ProductConstants.ReportDateCaption, GroupEnum.reportGroup);
            }

            // SQL properties
            if (m_showSqlVersionProperties)
            {
                AddPropertyItem(ProductConstants.SqlServerReleaseCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.SqlServerEditionCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.SqlServerVersionCaption, GroupEnum.sqlGroup);
            }

            if (m_showSqlProperties)
            {
                AddPropertyItem(ProductConstants.MaximumNumberOfUserConnectionsCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.DatabaseCountCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.ClusteredServerCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.AgentXpsEnabledCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.DatabaseMailEnabledCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.SqlClrEnabledCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.RemoteAccessAllowedCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.XpCommandShellEnabledCaption, GroupEnum.sqlGroup);

                AddPropertyItem(ProductConstants.IsSingleUserCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.LanguageCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.CollationCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.IsCaseSensitiveCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.IsFullTextInstalledCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.C2AuditModeCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.AweEnabledCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.MemoryAllocationTypeCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.MinimumServerMemoryCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.MaximumServerMemoryCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.AllocatedCpuCountCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.AllocatedCpuCountIOCaption, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.ListeningPort, GroupEnum.sqlGroup);
                AddPropertyItem(ProductConstants.LastServerRestart, GroupEnum.sqlGroup);

                AddPropertyItem(ProductConstants.NetworkProtocolTcpIp, GroupEnum.networkLibraries);
                AddPropertyItem(ProductConstants.NetworkProtocolSharedMemory, GroupEnum.networkLibraries);
                AddPropertyItem(ProductConstants.NetworkProtocolNamedPipes, GroupEnum.networkLibraries);
                AddPropertyItem(ProductConstants.NetworkProtocolVia, GroupEnum.networkLibraries);
                AddPropertyItem(ProductConstants.NetworkProtocolApplteTalk, GroupEnum.networkLibraries);
                AddPropertyItem(ProductConstants.NetworkProtocolBanyanVines, GroupEnum.networkLibraries);
                AddPropertyItem(ProductConstants.NetworkProtocolMultiprotocol, GroupEnum.networkLibraries);
                AddPropertyItem(ProductConstants.NetworkProtocolNwLink, GroupEnum.networkLibraries);
            }

            // Computer properties
            if (m_showComputerProperties)
            {
                AddPropertyItem(ProductConstants.HostComputerCaption, GroupEnum.computerGroup);
                AddPropertyItem(ProductConstants.DomainWorkgroupCaption, GroupEnum.computerGroup);
                AddPropertyItem(ProductConstants.DomainOrWorkgroupCaption, GroupEnum.computerGroup);
                AddPropertyItem(ProductConstants.ManufacturerCaption, GroupEnum.computerGroup);
                AddPropertyItem(ProductConstants.OperatingSystemCaption, GroupEnum.computerGroup);
                AddPropertyItem(ProductConstants.OperatingSystemVersionCaption, GroupEnum.computerGroup);
                AddPropertyItem(ProductConstants.TotalPhysicalMemoryCaption, GroupEnum.computerGroup);
                AddPropertyItem(ProductConstants.AvailablePhysicalMemoryCaption, GroupEnum.computerGroup);
                AddPropertyItem(ProductConstants.TotalVirtualMemoryCaption, GroupEnum.computerGroup);
                AddPropertyItem(ProductConstants.AvailableVirtualMemoryCaption, GroupEnum.computerGroup);
                AddPropertyItem(ProductConstants.NumberOfPhysicalProcessorsCaption, GroupEnum.computerGroup);
                AddPropertyItem(ProductConstants.NumberOfLogicalProcessorsCaption, GroupEnum.computerGroup);
                AddPropertyItem(ProductConstants.PlatformCaption, GroupEnum.computerGroup);
                AddPropertyItem(ProductConstants.NumberOfHardDrivesCaption, GroupEnum.computerGroup);
                AddPropertyItem(ProductConstants.FreeSpaceCaption, GroupEnum.computerGroup);
            }

            if (m_showServersAsRows)
            {
                AddPropertyItem(ProductConstants.ReportTypeCaption, GroupEnum.reportGroup);
                AddPropertyItem(ProductConstants.ReportDateCaption, GroupEnum.reportGroup);
            }
        }

        private void LoadServerValues(int ndx)
        {
            InventoryData _Data;
            
            if (m_showServersAsRows)
            {
                _Data = (InventoryData)listInventory.Items[ndx].Tag;
            }
            else
            {
                _Data = (InventoryData)listInventory.Columns[ndx].Tag;
            }

            if (!m_showServersAsRows)
            {
                AddInventoryItems(ndx, ProductConstants.ReportDateCaption, _Data.reportDate.ToString());
                AddInventoryItems(ndx, ProductConstants.ReportTypeCaption, Path.GetFileName(_Data.Source));
            }

            if (m_showSqlVersionProperties)
            {
                AddInventoryItems(ndx, ProductConstants.SqlServerReleaseCaption, _Data.sqlServerRelease);
                AddInventoryItems(ndx, ProductConstants.SqlServerEditionCaption, _Data.sqlServerEdition);
                AddInventoryItems(ndx, ProductConstants.SqlServerVersionCaption, _Data.sqlServerVersion);
            }

            if (m_showSqlProperties)
            {
                AddInventoryItems(ndx, ProductConstants.MaximumNumberOfUserConnectionsCaption, _Data.maximumNumberofConnections.ToString());
                AddInventoryItems(ndx, ProductConstants.DatabaseCountCaption, _Data.databaseCount.ToString());
                AddInventoryItems(ndx, ProductConstants.ClusteredServerCaption, _Data.isClusteredServer.ToString());
                AddInventoryItems(ndx, ProductConstants.AgentXpsEnabledCaption, _Data.isAgentXpEnabled.ToString());
                AddInventoryItems(ndx, ProductConstants.DatabaseMailEnabledCaption, _Data.isDatabaseMailEnabled.ToString());
                AddInventoryItems(ndx, ProductConstants.SqlClrEnabledCaption, _Data.isSqlClrEnabled.ToString());
                AddInventoryItems(ndx, ProductConstants.RemoteAccessAllowedCaption, _Data.isRemoteAccessAllowed.ToString());
                AddInventoryItems(ndx, ProductConstants.XpCommandShellEnabledCaption, _Data.isXpCommandShellEnabled.ToString());
                AddInventoryItems(ndx, ProductConstants.IsSingleUserCaption, _Data.isSingleUser.ToString());
                AddInventoryItems(ndx, ProductConstants.LanguageCaption, _Data.language);
                AddInventoryItems(ndx, ProductConstants.CollationCaption, _Data.collation);
                AddInventoryItems(ndx, ProductConstants.IsCaseSensitiveCaption, _Data.isCaseSensitive.ToString());
                AddInventoryItems(ndx, ProductConstants.IsFullTextInstalledCaption, _Data.isFullTextInstalled.ToString());
                AddInventoryItems(ndx, ProductConstants.C2AuditModeCaption, _Data.c2AuditMode.ToString());

                if (InventoryData.GetServerVersionAsInt(_Data.sqlServerVersion) < 11) // When SQL server version is lower than 2012
                    AddInventoryItems(ndx, ProductConstants.AweEnabledCaption, _Data.aweEnabled.ToString());
                else
                    AddInventoryItems(ndx, ProductConstants.AweEnabledCaption, ProductConstants.AweEnabledMessage);

                AddInventoryItems(ndx, ProductConstants.MemoryAllocationTypeCaption, string.IsNullOrEmpty(_Data.memoryAllocationType) ? ProductConstants.UnknownValue : _Data.memoryAllocationType);
                AddInventoryItems(ndx, ProductConstants.MinimumServerMemoryCaption, _Data.minimumSqlServerMemory == int.MinValue ? ProductConstants.UnknownValue : Helpers.StrFormatByteSize((long)_Data.minimumSqlServerMemory * 1024 * 1024));
                AddInventoryItems(ndx, ProductConstants.MaximumServerMemoryCaption, Helpers.StrFormatByteSize((long)_Data.maximumSqlServerMemory * 1024 * 1024));
                AddInventoryItems(ndx, ProductConstants.AllocatedCpuCountCaption, _Data.allocatedCpuCount == int.MinValue ? ProductConstants.UnknownValue : _Data.allocatedCpuCount.ToString());
                AddInventoryItems(ndx, ProductConstants.AllocatedCpuCountIOCaption, _Data.allocatedCpuCountIO == int.MinValue ? ProductConstants.UnknownValue : _Data.allocatedCpuCountIO.ToString());                
                AddInventoryItems(ndx, ProductConstants.ListeningPort, _Data.tcpPort == Int32.MinValue ? ProductConstants.UnknownValue : _Data.tcpPort.ToString());
                AddInventoryItems(ndx, ProductConstants.LastServerRestart, _Data.lastStartDate == DateTime.MinValue ? ProductConstants.UnknownValue : _Data.lastStartDate.ToString());

                if (!string.IsNullOrEmpty(_Data.sqlServerVersion))
                {
                    AddInventoryItems(ndx, ProductConstants.NetworkProtocolTcpIp, _Data.networkTcpIpEnabled.HasValue ? (_Data.networkTcpIpEnabled.Value ? "Enabled" : "Disabled") : ProductConstants.UnknownValue);                   
                    if (_Data.sqlServerVersion.Substring(0, 1) == "8")
                    {
                        AddInventoryItems(ndx, ProductConstants.NetworkProtocolSharedMemory, _Data.networkSharedMemoryEnabled.ToString());
                        AddInventoryItems(ndx, ProductConstants.NetworkProtocolNamedPipes, _Data.networkNamedPipesEnabled.HasValue ? (_Data.networkNamedPipesEnabled.Value ? "Enabled" : "Disabled") : ProductConstants.UnknownValue);
                        AddInventoryItems(ndx, ProductConstants.NetworkProtocolVia, _Data.networkViaEnabled.HasValue ? (_Data.networkViaEnabled.Value ? "Enabled" : "Disabled") : ProductConstants.UnknownValue);
                        AddInventoryItems(ndx, ProductConstants.NetworkProtocolApplteTalk, _Data.networkAppleTalkEnabled.HasValue ? (_Data.networkAppleTalkEnabled.Value ? "Enabled" : "Disabled") : ProductConstants.UnknownValue);
                        AddInventoryItems(ndx, ProductConstants.NetworkProtocolBanyanVines, _Data.networkBanyanVinesEnabled.HasValue ? (_Data.networkBanyanVinesEnabled.Value ? "Enabled" : "Disabled") : ProductConstants.UnknownValue);
                        AddInventoryItems(ndx, ProductConstants.NetworkProtocolMultiprotocol, _Data.networkMultiprotocolEnabled.HasValue ? (_Data.networkMultiprotocolEnabled.Value ? "Enabled" : "Disabled") : ProductConstants.UnknownValue);
                        AddInventoryItems(ndx, ProductConstants.NetworkProtocolNwLink, _Data.networkNwLinkEnabled.HasValue ? (_Data.networkNwLinkEnabled.Value ? "Enabled" : "Disabled") : ProductConstants.UnknownValue);
                    }
                    else
                    {
                        AddInventoryItems(ndx, ProductConstants.NetworkProtocolSharedMemory, _Data.networkSharedMemoryEnabled.HasValue ? (_Data.networkSharedMemoryEnabled.Value ? "Enabled" : "Disabled") : ProductConstants.UnknownValue);
                        AddInventoryItems(ndx, ProductConstants.NetworkProtocolNamedPipes, _Data.networkNamedPipesEnabled.HasValue ? (_Data.networkNamedPipesEnabled.Value ? "Enabled" : "Disabled") : ProductConstants.UnknownValue);
                        AddInventoryItems(ndx, ProductConstants.NetworkProtocolVia, _Data.networkViaEnabled.HasValue ? (_Data.networkViaEnabled.Value ? "Enabled" : "Disabled") : ProductConstants.UnknownValue);
                        AddInventoryItems(ndx, ProductConstants.NetworkProtocolApplteTalk, _Data.networkAppleTalkEnabled.ToString());
                        AddInventoryItems(ndx, ProductConstants.NetworkProtocolBanyanVines, _Data.networkBanyanVinesEnabled.ToString());
                        AddInventoryItems(ndx, ProductConstants.NetworkProtocolMultiprotocol, _Data.networkMultiprotocolEnabled.ToString());
                        AddInventoryItems(ndx, ProductConstants.NetworkProtocolNwLink, _Data.networkNwLinkEnabled.ToString());
                    }
                }
            }

            if (m_showComputerProperties)
            {
                AddInventoryItems(ndx, ProductConstants.HostComputerCaption, _Data.hostComputer);

                if (_Data.hostComputer != "")
                {
                    AddInventoryItems(ndx, ProductConstants.DomainWorkgroupCaption, _Data.domainWorkgroup);
                    AddInventoryItems(ndx, ProductConstants.DomainOrWorkgroupCaption, _Data.domainOrWorkgroup);
                    AddInventoryItems(ndx, ProductConstants.ManufacturerCaption, _Data.manufacturer);
                    AddInventoryItems(ndx, ProductConstants.OperatingSystemCaption, _Data.operatingSystem);
                    AddInventoryItems(ndx, ProductConstants.OperatingSystemVersionCaption, _Data.osVersion);
                    AddInventoryItems(ndx, ProductConstants.TotalPhysicalMemoryCaption, Helpers.StrFormatByteSize(_Data.totalPhysicalMemory * 1024));
                    if (_Data.wmiException == null)
                    {
                        AddInventoryItems(ndx, ProductConstants.AvailablePhysicalMemoryCaption, Helpers.StrFormatByteSize(_Data.availablePhysicalMemory * 1024));
                        AddInventoryItems(ndx, ProductConstants.TotalVirtualMemoryCaption, Helpers.StrFormatByteSize(_Data.totalVirtualMemory * 1024));
                        AddInventoryItems(ndx, ProductConstants.AvailableVirtualMemoryCaption, Helpers.StrFormatByteSize(_Data.availableVirtualMemory * 1024));
                    }
                    else
                    {
                        AddInventoryItems(ndx, ProductConstants.AvailablePhysicalMemoryCaption, string.Empty);
                        AddInventoryItems(ndx, ProductConstants.TotalVirtualMemoryCaption, string.Empty);
                        AddInventoryItems(ndx, ProductConstants.AvailableVirtualMemoryCaption, string.Empty);
                    }
                    AddInventoryItems(ndx, ProductConstants.NumberOfPhysicalProcessorsCaption, _Data.numberOfPhysicalProcessors > 0 ? _Data.numberOfPhysicalProcessors.ToString() : "");
                    AddInventoryItems(ndx, ProductConstants.NumberOfLogicalProcessorsCaption, _Data.numberOfLogicalProcessors > 0 ? _Data.numberOfLogicalProcessors.ToString() : "");
                    AddInventoryItems(ndx, ProductConstants.PlatformCaption, _Data.platform);
                    AddInventoryItems(ndx, ProductConstants.NumberOfHardDrivesCaption, _Data.numberOfHardDrives.ToString());
                    AddInventoryItems(ndx, ProductConstants.FreeSpaceCaption, Helpers.StrFormatByteSize((long)_Data.freeHardDriveSpace * 1024 * 1024));
                }
            }

            if (m_showServersAsRows)
            {
                AddInventoryItems(ndx, ProductConstants.ReportTypeCaption, _Data.Source);
                AddInventoryItems(ndx, ProductConstants.ReportDateCaption, _Data.reportDate.ToString());
            }

            ApplyHighlights(m_highlightDifferences);
        }

        private void listInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listInventory.SelectedItems.Count == 0 || (!m_showServersAsRows && listInventory.Columns.Count == 1))
            {
                menuCopy.Enabled = false;
                contextMenuCopy.Enabled = false;
            }
            else
            {
                menuCopy.Enabled = true;
                contextMenuCopy.Enabled = true;
            }
        }

        #endregion

        #region Worker Routines for filling ListView

        private void AddPropertyHeader()
        {
            if (m_showServersAsRows)
            {
                listInventory.Columns.Add("SQL Server", 200);
            }
            else
            {
                AddNewColumn(0, "Property", 200);
            }
        }

        /// <summary>
        /// Adds a new item to the Inventory Item list.  The item doesn't contain any sub-items.
        /// </summary>
        private void AddPropertyItem(string name, GroupEnum groupIndex)
        {
            if (m_showServersAsRows)
            {
                int _ValuesColumn = listInventory.Columns.Count;
                AddNewColumn(_ValuesColumn, name);
            }
            else
            {
                ListViewItem _Item = new ListViewItem();
                _Item.Text = _Item.Name = name;
                _Item.UseItemStyleForSubItems = true;
                _Item.Group = listInventory.Groups[(int)groupIndex];
                listInventory.Items.Add(_Item);
            }
        }

        /// <summary>
        /// Adds sub-items to an already existing item in the inventory list.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="_ndx"></param>
        private void AddInventoryItems(int _ndx, string name, string value)
        {
            if (m_showServersAsRows)
            {
                listInventory.Items[_ndx].SubItems.Add(value);
            }
            else
            {
                listInventory.Items[name].SubItems[_ndx].Text = value;
            }
        }

        private void AddNewColumn(int index, string title)
        {
            if (m_showServersAsRows)
            {
                AddNewColumn(index, title, 120);
            }
            else
            {
                AddNewColumn(index, title, 180);
            }
        }

        private void AddNewColumn(int index, string title, int colWidth)
        {
            if (m_showServersAsRows)
            {
                listInventory.Columns.Add(title, colWidth);
            }
            else
            {
                listInventory.Columns.Insert(index, title, colWidth);
                
                foreach (ListViewItem _Item in listInventory.Items)
                {
                    _Item.SubItems.Insert(index, new ListViewItem.ListViewSubItem());
                }
            }
        }

        private void AddDataToListView(InventoryData data, string snapshotFile, bool addToArray)
        {
            if (data == null) return;

            if (!String.IsNullOrEmpty(snapshotFile)) data.SnapshotFile = snapshotFile;
            
            if (addToArray) m_InventoryData.Add(data);

            if (m_showServersAsRows)
            {
                int _ValuesRow = listInventory.Items.Count;
                ListViewItem lvi = new ListViewItem(data.serverName);
                lvi.Tag = data;

                int groupIndex = GetVersionGroup(data.sqlServerVersion);
                lvi.Group = listInventory.Groups[groupIndex];

                listInventory.Items.Add(lvi);

                LoadServerValues(_ValuesRow);
            }
            else
            {
                int _ValuesColumn = listInventory.Columns.Count;
                AddNewColumn(_ValuesColumn, data.serverName);
                listInventory.Columns[_ValuesColumn].Tag = data;
                LoadServerValues(_ValuesColumn);
            }

        }

        //private void
        //   AddDataToListView(
        //      List<InventoryData> _DataList,
        //      string snapshotFile,
        //      bool addToArray
        //   )
        //{
        //    if (_DataList == null || _DataList.Count == 0) return;

        //    foreach (InventoryData _Data in _DataList)
        //    {
        //        AddDataToListView(_Data, snapshotFile, addToArray);
        //    }
        //}

        private int GetVersionGroup(string sqlVersion)
        {
            int groupIndex;
            string[] serverVersionDetails = sqlVersion.Split(new string[] { "." }, StringSplitOptions.None);

            string version = serverVersionDetails[0];

            switch (version)
            {
                case "6":
                    groupIndex = (int)GroupEnum.sql65;
                    break;
                case "7":
                    groupIndex = (int)GroupEnum.sql70;
                    break;
                case "8":
                    groupIndex = (int)GroupEnum.sql2000;
                    break;
                case "9":
                    groupIndex = (int)GroupEnum.sql2005;
                    break;
                case "10":
                    groupIndex = (int)GroupEnum.sql2008;
                    break;
                case "11":
                    groupIndex = (int)GroupEnum.sql2012;
                    break;
                case "12":
                    groupIndex = (int)GroupEnum.sql2014;
                    break;
                case "13":
                    groupIndex = (int)GroupEnum.sql2016;
                    break;
                case "14":
                    groupIndex = (int)GroupEnum.sql2017;
                    break;
                default:
                    groupIndex = (int)GroupEnum.sqlUnknown;
                    break;
            }

            return groupIndex;
        }

        #endregion

        #region Report Type

        private void comboReportType_SelectedValueChanged(object sender, EventArgs e)
        {
            SetReportParametersBasedOnType();
            RedrawList(true);
        }

        private void SetReportParametersBasedOnType()
        {
            if (comboReportType.Text == "Computer Properties Report")
            {
                m_showComputerProperties = true;
                m_showSqlProperties = false;
                m_showSqlVersionProperties = false;
                listInventory.ShowGroups = (!m_showServersAsRows);
            }
            else if (comboReportType.Text == "SQL Server Properties Report")
            {
                m_showComputerProperties = false;
                m_showSqlProperties = true;
                m_showSqlVersionProperties = true;
                listInventory.ShowGroups = (!m_showServersAsRows);
            }
            else if (comboReportType.Text == "SQL Server Version Report")
            {
                m_showComputerProperties = false;
                m_showSqlProperties = false;
                m_showSqlVersionProperties = true;
                listInventory.ShowGroups = true;
            }
            else
            {
                // comprehensive report
                m_showComputerProperties = true;
                m_showSqlProperties = true;
                m_showSqlVersionProperties = true;
                listInventory.ShowGroups = (!m_showServersAsRows);
            }
        }

        #endregion

        #region Highlight Differences

        private void highlightDifferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleHighlightDifferences();
        }

        private void buttonHighlightDifferences_Click(object sender, EventArgs e)
        {
            ToggleHighlightDifferences();
        }

        private void menuHighlightDifferences_Click(object sender, EventArgs e)
        {
            ToggleHighlightDifferences();
        }

        private void ToggleHighlightDifferences()
        {
            menuHighlightDifferences.Checked = !menuHighlightDifferences.Checked;
            m_highlightDifferences = menuHighlightDifferences.Checked;
            if (m_highlightDifferences)
            {
                buttonHighlightDifferences.Text = ProductConstants.HighlightButtonHideDifferences;
            }
            else
            {
                buttonHighlightDifferences.Text = ProductConstants.HighlightButtonShowDifferences;
            }

            listInventory.BeginUpdate();
            ApplyHighlights(m_highlightDifferences);
            listInventory.EndUpdate();
        }

        private void ApplyHighlights(bool showDifferences)
        {
            if (m_showServersAsRows)
            {
                HighlightColumns(showDifferences);
            }
            else
            {
                HighlightRows(showDifferences);
            }
        }

        private void HighlightRows(bool showDifferences)
        {
            bool oddRow = true;

            for (int row = 0; row < listInventory.Items.Count; row++)
            {
                ListViewItem _Item = listInventory.Items[row];

                // Check For Differences
                bool _DifferenceDetected = false;

                if (showDifferences && listInventory.Columns.Count > 2)
                {
                    if (_Item.Group != listInventory.Groups[(int)GroupEnum.reportGroup])
                    {
                        string _BaseValue = string.Empty;
                        //if the base value is empty, find the first item with a value
                        for (int i = 1; i < _Item.SubItems.Count; i++)
                        {
                           _BaseValue = _Item.SubItems[i].Text.Trim();
                           if (_BaseValue.Length > 0)
                           {
                              break;
                           }
                        }

                        if (_BaseValue.Length > 0)
                        {
                           for (int i = 1; i < _Item.SubItems.Count; i++)
                           {
                              if (_BaseValue != _Item.SubItems[i].Text.Trim() && _Item.SubItems[i].Text.Trim().Length > 0)
                              {
                                 _DifferenceDetected = true;
                                 break;
                              }
                           }
                        }
                    }
                }

                // Odd Row Calculation
                if (row == 0 || listInventory.Items[row].Group != listInventory.Items[row - 1].Group) oddRow = true;

                // Figure out background color for Row
                Color backColor = Color.White;
                if (oddRow) backColor = Color.WhiteSmoke;
                if (_DifferenceDetected) backColor = Color.Yellow;

                // Draw Row
                for (int i = 0; i < _Item.SubItems.Count; i++)
                {
                    _Item.SubItems[i].BackColor = backColor;
                }

                oddRow = !oddRow;
            }
        }

        private void HighlightColumns(bool showDifferences)
        {
            // loop through columns - skip column 0 (server)
            for (int col = 0; col < listInventory.Columns.Count - 2; col++)
            {
                // Check For Differences
                bool _DifferenceDetected = false;
                
                if (showDifferences && col != 0 && !IsReportGroupColumn(col))
                {
                    string _BaseValue = string.Empty;
                    //if the base value is empty, find the first item with a value
                    for (int r = 0; r < listInventory.Items.Count; r++)
                    {
                       if (listInventory.Items[r].SubItems.Count > col && listInventory.Items[r].SubItems[col] != null)
                       {
                          _BaseValue = listInventory.Items[r].SubItems[col].Text.Trim();
                          if (_BaseValue.Length > 0)
                          {
                             break;
                          }
                       }
                    }

                    if (_BaseValue.Length > 0)
                    {
                       for (int r = 0; r < listInventory.Items.Count; r++)
                       {
                          if (listInventory.Items[r].SubItems.Count > col && listInventory.Items[r].SubItems[col] != null && _BaseValue != listInventory.Items[r].SubItems[col].Text.Trim() && listInventory.Items[r].SubItems[col].Text.Trim().Length > 0)
                          {
                             _DifferenceDetected = true;
                             break;
                          }
                       }
                    }
                }

                // Figure out background color for Row
                Color backColor = Color.White;
                if (_DifferenceDetected) backColor = Color.Yellow;

                // Draw Row
                for (int r = 0; r < listInventory.Items.Count; r++)
                {
                   if (listInventory.Items[r].SubItems.Count > col && listInventory.Items[r].SubItems[col] != null)
                   {
                      listInventory.Items[r].SubItems[col].BackColor = backColor;
                   }
                }
            }
        }

        private bool IsReportGroupColumn(int col)
        {
            bool reportGroup = false;

            if (listInventory.Columns[col].Text == ProductConstants.ReportDateCaption
              || listInventory.Columns[col].Text == ProductConstants.ReportTypeCaption) 
            {
                reportGroup = true;
            }

            return reportGroup;
        }

        #endregion

        #region Snapshot

        private void saveSnapshot_Click(object sender, EventArgs e)
        {
            SaveSnapshot();
        }

        private void contextMenuSaveSnapshot_Click(object sender, EventArgs e)
        {
            SaveSnapshot();
        }

        private void openSnapshot_Click(object sender, EventArgs e)
        {
            LoadSnapshot();
        }

        private void SaveSnapshot()
        {
            if (listInventory.Columns.Count > 1)
            {
                string defaultPrefix;
                if (m_workingWithServerGroup)
                {
                    defaultPrefix = m_serverSelection;
                }
                else
                {
                    defaultPrefix = listInventory.Columns[1].Text;
                }

                // create default name
                SaveFileDialog _FileDialog = new SaveFileDialog();
                _FileDialog.Title = "Save Snapshot As";
                _FileDialog.AddExtension = true;
                _FileDialog.CheckPathExists = true;
                _FileDialog.DefaultExt = "xml";
                _FileDialog.FileName = string.Format("{0}_{1}.xml",
                                                      defaultPrefix.Replace("\\", "_"),
                                                      DateTime.Now.ToString("yyyyMMdd"));
                _FileDialog.Filter = "XML File (*.xml)|*.xml|All Files (*.*)|*.*";
                _FileDialog.InitialDirectory = ProductConstants.SnapshotFolder;

                if (_FileDialog.ShowDialog() == DialogResult.OK)
                {
                    InventoryHelper.SaveToFile(CreateInventoryList(), _FileDialog.FileName);
                }
            }
            else
            {
                Messaging.ShowError("You must generate a report before you can save it.");
            }
        }

        private void LoadSnapshot()
        {
            Form_OpenSnapshot frm = new Form_OpenSnapshot();
            DialogResult choice = frm.ShowDialog();
            if (choice == DialogResult.OK)
            {
                if (frm.clearAllExisting)
                {
                    listInventory.BeginUpdate();
                    listInventory.Clear();
                    m_InventoryData.Clear();
                    LoadPropertyNames();
                    listInventory.EndUpdate();
                }

                try
                {
                    List<InventoryData> newData = InventoryHelper.LoadFromFile(frm.snapshotFile);
                    foreach (InventoryData data in newData)
                    {
                        data.DataType = InventoryData.InventoryType.Snapshot;
                        data.SnapshotFile = frm.snapshotFile;
                        m_InventoryData.Add(data);
                    }

                    RedrawList(true);
                }
                catch (Exception exc)
                {
                    Messaging.ShowException("Open Snapshot file", exc);
                }
            }
        }

        #endregion

        #region Window Events

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearList();
        }

        private void menuClear_Click(object sender, EventArgs e)
        {
            ClearList();
        }

        private void contextMenuClear_Click(object sender, EventArgs e)
        {
            ClearList();
        }

        private void contextMenuShowServersAsRows_Click(object sender, EventArgs e)
        {
            ChangeShowServerAsRows(!m_showServersAsRows, true);
        }

        private void menuShowServersAsRows_Click(object sender, EventArgs e)
        {
            ChangeShowServerAsRows(!m_showServersAsRows, true);
        }

        private void ChangeShowServerAsRows(bool newValue, bool redrawList)
        {
            m_showServersAsRows = newValue;

            // Adjust Menus
            if (m_showServersAsRows)
            {
                menuShowServersAsRows.Text = "&Show Servers As Columns";
                menuHighlightDifferences.Enabled = false;
                m_saveHighlightDifferences = menuHighlightDifferences.Checked;
                menuHighlightDifferences.Checked = false;

                listInventory.ShowGroups = (comboReportType.Text == "SQL Server Version Report");
            }
            else
            {
                menuShowServersAsRows.Text = "&Show Servers As Rows";
                menuHighlightDifferences.Enabled = true;
                menuHighlightDifferences.Checked = m_saveHighlightDifferences;
                listInventory.ShowGroups = true;
            }

            contextMenuShowServersAsRows.Text = menuShowServersAsRows.Text;
            contextMenuHighlightDifferences.Enabled = menuHighlightDifferences.Enabled;
            contextMenuHighlightDifferences.Checked = menuHighlightDifferences.Checked;

            // Adjust ListView
            if (redrawList)
            {
                RedrawList(true);
                //ApplyHighlights( menuHighlightDifferences.Checked );
            }
        }

        private void menuClearLiveData_Click(object sender, EventArgs e)
        {
            DeleteDataMatchingDataType(InventoryData.InventoryType.LiveData);
        }

        private void menuClearSnapshots_Click(object sender, EventArgs e)
        {
            DeleteDataMatchingDataType(InventoryData.InventoryType.Snapshot);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        #endregion

        #region Report

        private void ShowReport()
        {
            
            try
            {
               Cursor = Cursors.WaitCursor;
               Application.DoEvents(); // let form redraw after main menu closes
            
               List<InventoryData> list = CreateInventoryList();

               //is there data?
               if (list.Count == 0)
               {
                   MessageBox.Show("No data to print.\r\n\r\nPlease click 'Capture Live Data' or 'Open Snapshot' to gather data for the report.", "No Data",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);

                   return;
               }

               //launch the report dialog
               Form_Report frm = new Form_Report(list);
               frm.Show(this);
            }
            finally
            {
               Cursor = Cursors.Default;
            }
        }

        #endregion

        #region Clipboard Support

        private void menuCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard(true);
        }

        private void contextMenuCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard(true);
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard(false);
        }

        private void CopyToClipboard(bool selectedOnly)
        {
            ExportToClipboard.CopyListViewToTabbedFormat(listInventory, false, selectedOnly);
        }

        private void menuSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void contextMenuSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void SelectAll()
        {
            foreach (ListViewItem lvi in listInventory.Items)
            {
                lvi.Selected = true;
            }
        }

        #endregion

        #region Export

        private void menuExportAsCSV_Click(object sender, EventArgs e)
        {
            ExportToCSV.CopyListView(listInventory);
        }

        private void contextMenuExportCSV_Click(object sender, EventArgs e)
        {
            ExportToCSV.CopyListView(listInventory);
        }

        private void menuExportAsXML_Click(object sender, EventArgs e)
        {
            ExportToXML.CopyListView(listInventory, "Inventory Report", true);
        }

        private void contextMenuExportXML_Click(object sender, EventArgs e)
        {
            ExportToXML.CopyListView(listInventory, "Inventory Report", true);
        }

        private void menuExportAsTable_Click(object sender, EventArgs e)
        {
            ExportToTable.CreateTableDelegate ctd = InventoryData.CreateTable;
            ExportToTable.PopulateTableDelegate ptd = InventoryData.PopulateTable;

            ExportToTable.Export(ctd, ptd);
        }

        private void contextMenuExportTable_Click(object sender, EventArgs e)
        {
            ExportToTable.CreateTableDelegate ctd = InventoryData.CreateTable;
            ExportToTable.PopulateTableDelegate ptd = InventoryData.PopulateTable;

            ExportToTable.Export(ctd, ptd);
        }

        #endregion

        private void DeleteDataMatchingDataType(InventoryData.InventoryType dataTypeToDelete)
        {
            bool found = false;
            
            for (int i = m_InventoryData.Count - 1; i >= 0; i--)
            {
                if (m_InventoryData[i].DataType == dataTypeToDelete)
                {
                    found = true;
                    m_InventoryData.RemoveAt(i);
                }
            }

            if (found) RedrawList(true);
        }

        #region Handle Context Menu at Column Header
 
        /// <summary>
        /// Called when the user right-clicks anywhere in the ListView, including the
        /// header bar.  It displays the appropriate context menu for the data row or
        /// header that was right-clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void regularListViewMenu_Opening(object sender, CancelEventArgs e)
        {
            // This call indirectly calls EnumWindowCallBack which sets _headerRect
            // to the area occupied by the ListView's header bar.
            EnumChildWindows(listInventory.Handle, EnumWindowCallBack, IntPtr.Zero);

            // If the mouse position is in the header bar, cancel the display
            // of the regular context menu and display the column header context menu instead.
            Point mousePosition = MousePosition;

            contextMenuRemoveServer.Visible = false;

            if (m_showServersAsRows)
            {
                if (listInventory.SelectedItems.Count != 0)
                {
                    contextMenuRemoveServer.Tag = listInventory.SelectedIndices[0];
                    contextMenuRemoveServer.Text = "Remove Server '" + listInventory.SelectedItems[0].Text + "'";
                    contextMenuRemoveServer.Visible = true;
                }
            }
            else
            {
                if (_headerRect.Contains(mousePosition))
                {
                    //e.Cancel = true;  // used if you want to dispaly alternate context menu - we just tweak regular one

                    // The xoffset is how far the mouse is from the left edge of the header.
                    int xoffset = mousePosition.X - _headerRect.Left;

                    // Iterate through the column headers in the order they are displayed, adding up
                    // their widths as we go.  When the sum exceeds the xoffset, we know the mouse
                    // is on the current header. 
                    int col = 0;
                    int sum = 0;
                    
                    foreach (ColumnHeader header in GetOrderedHeaders(listInventory))
                    {
                        sum += header.Width;
                        if (sum > xoffset)
                        {
                            if (col != 0) // dont allow remove on properties column
                            {
                                HandleRightClickOnHeader(header);
                            }
                            break;
                        }
                        col++;
                    }
                }
            }
        }

        // The area occupied by the ListView header. 
        private Rectangle _headerRect;

        // This returns an array of ColumnHeaders in the order they are
        // displayed by the ListView.  
        private static ColumnHeader[] GetOrderedHeaders(ListView lv)
        {
            ColumnHeader[] arr = new ColumnHeader[lv.Columns.Count];

            foreach (ColumnHeader header in lv.Columns)
            {
                arr[header.DisplayIndex] = header;
            }

            return arr;
        }

        // Called when the specified column header is right-clicked.
        private void HandleRightClickOnHeader(ColumnHeader header)
        {
            // We can do anything here, but most likely we want to 
            // display a context menu for the header.  This code
            // displays the same context menu for every header, but
            // changes the menu item text based on the header.
            // It sets the context menu tag to the specified header so the 
            // handler for whatever command the user clicks can know the column.
            contextMenuRemoveServer.Tag = header.Index - 1;
            contextMenuRemoveServer.Text = "Remove Server '" + header.Text + "'";
            contextMenuRemoveServer.Visible = true;
            //contextMenu.Show(Control.MousePosition);
            //headerMenu.Tag = header;
            //headerMenu.Items[0].Text = "Command for Header " + header.Text;
            //headerMenu.Show(Control.MousePosition);
        }

        // This should get called with the only child window of the ListView,
        // which should be the header bar.
        private bool EnumWindowCallBack(IntPtr hwnd, IntPtr lParam)
        {
            // Determine the rectangle of the ListView header bar and save it in _headerRect.
            RECT rct;

            if (!GetWindowRect(hwnd, out rct))
            {
                _headerRect = Rectangle.Empty;
            }
            else
            {
                _headerRect = new Rectangle(rct.Left, rct.Top, rct.Right - rct.Left, rct.Bottom - rct.Top);
            }

            return false; // Stop the enum
        }
        
        // Delegate that is called for each child window of the ListView.
        private delegate bool EnumWinCallBack(IntPtr hwnd, IntPtr lParam);

        // Calls EnumWinCallBack for each child window of hWndParent (i.e. the ListView).
        [DllImport("user32.Dll")]
        private static extern int EnumChildWindows(IntPtr hWndParent, EnumWinCallBack callBackFunc, IntPtr lParam);

        // Gets the bounding rectangle of the specified window (ListView header bar).
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        #endregion

        #region Remove Server

        private void contextMenuRemoveServer_Click(object sender, EventArgs e)
        {
            int index = (int)((ToolStripMenuItem)sender).Tag;
            RemoveServer(index);
        }

        private void RemoveServer(int index)
        {
            string _ServerName = m_InventoryData[index].serverName;
            if (_ErrorReports.ContainsKey(_ServerName))
            {
                _ErrorReports.Remove(_ServerName);
            }
            if (_WmiExceptions.ContainsKey(_ServerName))
            {
                _WmiExceptions.Remove(_ServerName);
            }
            if (_WmiExceptions.Count == 0)
            {
                labelWmiErrors.Visible = linkWmiErrorDetails.Visible = false;
            }
            // remove from listdata
            m_InventoryData.RemoveAt(index);
            RedrawList(true);

            // reselect
            if (m_showServersAsRows)
            {
                if (index >= listInventory.Items.Count)
                {
                    index = listInventory.Items.Count - 1;
                }
                if (index != -1)
                {
                    listInventory.Items[index].Selected = true;
                }
            }
        }

        #endregion

        #region Save As Server Group

        private void contextMenuSaveAsServerGroup_Click(object sender, EventArgs e)
        {
            SaveAsServerGroup();
        }

        private void menuSaveAsServerGroup_Click(object sender, EventArgs e)
        {
            SaveAsServerGroup();
        }

        private void SaveAsServerGroup()
        {
            // Get Servers
            List<string> serverList = new List<string>();
            
            if (m_showServersAsRows)
            {
                if (listInventory.Items.Count == 0) return;
                
                for (int i = 0; i < listInventory.Items.Count; i++)
                {
                    if (!serverList.Contains(listInventory.Items[i].Text))
                    {
                        serverList.Add(listInventory.Items[i].Text);
                    }
                }
            }
            else
            {
                if (listInventory.Columns.Count == 1) return;

                // get name from column header
                for (int c = 1; c < listInventory.Columns.Count; c++)
                {
                    if (!serverList.Contains(listInventory.Columns[c].Text))
                    {
                        serverList.Add(listInventory.Columns[c].Text);
                    }
                }
            }

            Form_SaveServersAsServerGroup frm = new Form_SaveServersAsServerGroup(serverList.ToArray());
            DialogResult choice = frm.ShowDialog();
            
            if (choice == DialogResult.OK)
            {
                Messaging.ShowInformation("Server group saved.");
            }
        }

        #endregion

        private void linkWmiErrorDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowWmiToolTip();
        }

        private void ShowWmiToolTip()
        {
            superTooltip1.SetSuperTooltip(this.linkWmiErrorDetails, new DevComponents.DotNetBar.SuperTooltipInfo(ProductConstants.WmiErrorTitle, string.Empty, ProductConstants.WmiErrorInstructions, null, null, DevComponents.DotNetBar.eTooltipColor.BlueMist));
            superTooltip1.Enabled = true;
            superTooltip1.ShowTooltip(linkWmiErrorDetails);
        }

        private void superTooltip1_MarkupLinkClick(object sender, DevComponents.DotNetBar.MarkupLinkClickEventArgs e)
        {
            if (e.HRef.Length > 0)
            {
                Process.Start(e.HRef);
            }
            else
            {
                Form_MultipleServerError frm = new Form_MultipleServerError();
                foreach (KeyValuePair<string, Exception> _Error in _WmiExceptions)
                {
                    frm.AddError(_Error.Key, Helpers.GetCombinedExceptionText(_Error.Value));
                }
                frm.ShowDialog();
            }
        }

        private void superTooltip1_TooltipClosed(object sender, EventArgs e)
        {
            superTooltip1.Enabled = false;
        }

        private void ShowF1Help(object sender, HelpEventArgs hlpevent)
        {
           HelpMenu.ShowHelp();
        }

        private void ServerSelection_TextChanged(object sender, EventArgs e)
       {
           buttonLoadInventoryData.Enabled = (ServerSelection.Text != "");
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

