using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.Threading;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.ServerConfiguration
{
    public partial class Form_Main : Form
    {
        private bool _ShowDifferences = true;
        private Dictionary<string, ConfigurationSettings> _ServerList = new Dictionary<string, ConfigurationSettings>();
        private Dictionary<string, ConfigurationSettings> _ComparedServerList = new Dictionary<string, ConfigurationSettings>();
        private ConfigurationSettings _BaselineConfiguration;
        private JobPool<ConfigurationSettings> _JobPool;
        ButtonItem _SelectedServer = null;
        private static Dictionary<string, string> _ErrorReports = new Dictionary<string, string>();
        private List<string> _DifferencesList = new List<string>();
        private ToolProgressBarDialog _ProgressDialog;
        private bool _CollationDifferencesFound = false;
        

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

            ProductConstants.BaselineDirectory = Path.Combine(Helpers.GetProductDirectory(true), "Baseline");
            ProductConstants.SnapshotDirectory = Path.Combine(Helpers.GetProductDirectory(true), "Snapshot");

            if (!Directory.Exists(ProductConstants.SnapshotDirectory))
            {
                Directory.CreateDirectory(ProductConstants.SnapshotDirectory);
            }

            if (!Directory.Exists(ProductConstants.BaselineDirectory))
            {
                Directory.CreateDirectory(ProductConstants.BaselineDirectory);
            }
            buttonHighlightDifferences.Text = ProductConstants.HighlightButtonShowDifferences;

            buttonFixDifferences.Enabled = buttonHighlightDifferences.Enabled = buttonCopyToClipboard.Enabled =
               buttonSave.Enabled = buttonRefresh.Enabled = buttonClear.Enabled =
               buttonConfigurationAddToComparison.Enabled = buttonConfigurationRemove.Enabled =
               buttonConfigurationSetAsBaseline.Enabled = false;

            ClearDetails();
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

        #region Configuration Data

        private void buttonGetResults_Click(object sender, EventArgs e)
        {
            // Validation
            if (ServerSelection.Text.Trim().Length == 0)
            {
                Messaging.ShowError(ProductConstants.ErrorServerNameNeeded);
                ServerSelection.Select();
                return;
            }

            LoadConfigurationData(ServerSelection.ServerList);

            MRU.AddServerOrGroup(ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server,
                         ServerSelection.Text,
                         ServerSelection.SqlCredentials);
        }

        private void LoadConfigurationData(List<ServerInformation> serverInformationList)
        {
            if (serverInformationList.Count > 0)
            {
                ProgressBar_Initialize( ProductConstants.ProgressGatherData );
                _JobPool = new JobPool<ConfigurationSettings>(5);
                _JobPool.ServerTaskComplete += JobPool_ServerTaskComplete;
                _JobPool.TaskComplete += JobPool_TaskComplete;

                _JobPool.Enqueue(ConfigurationHelper.GetServerConfiguration, serverInformationList, ToolsetOptions.commandTimeout);
                _JobPool.StartAsync();
                
                ProgressBar_Show();
            }
        }

        private void LoadConfigurationData(ServerInformation serverInformation)
        {
            List<ServerInformation> _List = new List<ServerInformation>();
            _List.Add(serverInformation);
            LoadConfigurationData(_List);
        }

        private void AddConfigurationToList(ConfigurationSettings settings)
        {
            listResults.Items.Clear();
            listResults.BeginUpdate();
            AddItemToConfigurationList(settings.ServerName, settings.Version);
            AddItemToConfigurationList(ProductConstants.RestartDateCaption, settings.LastStartDate.ToString());
            AddItemToConfigurationList(ProductConstants.ServerCollationCaption, settings.ServerCollation);

            if (settings.Source == ConfigurationSettings.DataSource.Snapshot)
            {
                AddItemToConfigurationList("Snapshot", settings.DateCaptured.ToString());
            }

            foreach (PropertyInfo _Property in settings.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                ConfigurationData _Data = _Property.GetValue(settings, null) as ConfigurationData;
                if (_Data != null)
                {
                    if (_Data.Type == ConfigurationType.Security)
                    {
                        AddItemToConfigurationList(Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_Data.Name),
                            _Data.DisplayValue, _Data.DisplayValue, _Data.RestartRequired,
                            _Data.Description, (int)_Data.Type, _Data.NeedsAttention, _Data);
                    }
                    else
                    {
                        AddItemToConfigurationList(Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_Data.Name), 
                            _Data.RunningValue.ToString(), _Data.ConfiguredValue.ToString(), _Data.RestartRequired,
                            _Data.Description, (int)_Data.Type, _Data.NeedsAttention, _Data);
                    }
                }
            }

            Helpers.ApplyAlternateColorsToListView(listResults);
            listResults.EndUpdate();
        }

        private void AddItemToConfigurationList(string name, string description)
        {
            AddItemToConfigurationList(name, "", "", false, description, 0, false, null);
        }

        private void AddItemToConfigurationList(string name, string runningValue, string configuredValue, bool restartRequired,
           string description, int group, bool needsAttention, object tag)
        {
            ListViewItem _Item = new ListViewItem(name);
            _Item.Name = name;
            _Item.SubItems.Add(runningValue);
            _Item.SubItems.Add(configuredValue);

            if (runningValue == string.Empty)
            {
                _Item.SubItems.Add(string.Empty);
            }
            else
            {
                _Item.SubItems.Add(restartRequired.ToString());
            }

            _Item.SubItems.Add(description);
            _Item.Group = listResults.Groups[group];
            _Item.Tag = tag;

            if (needsAttention)
            {
                _Item.ImageIndex = 0;
                _Item.ToolTipText = ProductConstants.WarningInconsistentSettings;
            }

            listResults.Items.Add(_Item);
        }

        private void AddServerToList(ConfigurationSettings settings)
        {
            ButtonItem _Item = new ButtonItem(settings.Key, settings.ServerName);
            _Item.Tag = settings;
            _Item.ButtonStyle = eButtonStyle.ImageAndText;
            _Item.ImagePosition = eImagePosition.Left;
            _Item.ImagePaddingHorizontal = 8;
            _Item.ImagePaddingVertical = 6;
            _Item.AutoCheckOnClick = true;
            _Item.ColorTable = eButtonColor.Blue;
            _Item.MouseUp += ServerItem_MouseUp;

            ApplyServerButtonStyle(_Item, settings);

            _ServerList.Add(settings.Key, settings);
            listServers.Items.Add(_Item);
            listServers.Refresh();

            if (settings.Source == ConfigurationSettings.DataSource.LiveData)
            {
                ButtonItem _SaveSubItem = new ButtonItem(settings.Key, settings.ServerName);
                _SaveSubItem.Click += buttonConfigurationSaveSingleServer_Click;
                buttonConfigurationSaveSnapshot.SubItems.Add(_SaveSubItem);
                buttonConfigurationSaveSnapshot.Enabled = true;
            }
        }

        private void ReplaceTab(ConfigurationSettings settings)
        {
            ButtonItem _ExistingItem = listServers.Items[settings.Key] as ButtonItem;
            if (_ExistingItem == null)
            {
                AddServerToList(settings);
            }
            else
            {
                _ExistingItem.Tag = settings;
                ApplyServerButtonStyle(_ExistingItem, settings);

                _ServerList[settings.Key] = settings;
                listServers.Refresh();
            }
        }

        /// <summary>
        /// Applies button icon and tooltip based on server status and source.
        /// </summary>
        private void ApplyServerButtonStyle(ButtonItem button, ConfigurationSettings settings)
        {
            switch (settings.Source)
            {
                case ConfigurationSettings.DataSource.LiveData:
                    if (settings.InconsistentValuesFound)
                    {
                        button.ImageIndex = 0;
                        button.Tooltip = ProductConstants.TooltipServerInconsistentSettings;
                    }
                    else
                    {
                        button.ImageIndex = 3;
                        button.Tooltip = ProductConstants.TooltipServerOnline;
                    }
                    break;
                case ConfigurationSettings.DataSource.Snapshot:
                    button.ImageIndex = 2;
                    button.Tooltip = ProductConstants.TooltipServerSnapshot;
                    break;
            }
        }

        private void ShowConfigurationItem(ButtonItem item)
        {
            AddConfigurationToList((ConfigurationSettings)item.Tag);
            ClearDetails();
        }

        private void ClearDetails()
        {
            labelName.Text =
               labelConfigValue.Text =
               labelRunValue.Text =
               labelMinimumValue.Text =
               labelMaximumValue.Text =
               labelRestartRequired.Text =
               labelDescription.Text = string.Empty;

            linkEdit.Visible = false;
        }

        private void listResults_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                ConfigurationData _Data = e.Item.Tag as ConfigurationData;

                if (_Data != null)
                {
                    if (_Data.Type == ConfigurationType.Security)
                    {
                        labelConfigValue.Text = _Data.DisplayValue;
                        labelRunValue.Text = _Data.DisplayValue;
                        labelMinimumValue.Text = _Data.Lookup[0];
                        labelMaximumValue.Text = _Data.Lookup[_Data.Lookup.Count - 1];
                    }
                    else
                    {
                        labelConfigValue.Text = _Data.ConfiguredValue.ToString();
                        labelRunValue.Text = _Data.RunningValue.ToString();
                        labelMinimumValue.Text = _Data.MinimumValue.ToString();
                        labelMaximumValue.Text = _Data.MaximumValue.ToString();
                    }

                    labelName.Text = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_Data.Name);
                    
                    labelRestartRequired.Text = _Data.RestartRequired.ToString();
                    labelDescription.Text = _Data.Description;

                    linkEdit.Visible = true;
                    groupDetails.Tag = _Data;

                    linkEdit.Visible = (((ConfigurationSettings)_SelectedServer.Tag).Source == ConfigurationSettings.DataSource.LiveData);
                }
            }
        }

        private void linkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditItem();
        }

        private void EditItem()
        {
            if (_SelectedServer != null)
            {
                ConfigurationSettings _Settings = _SelectedServer.Tag as ConfigurationSettings;

                if (_Settings != null && _Settings.Source == ConfigurationSettings.DataSource.LiveData)
                {
                    ConfigurationData _Data = listResults.SelectedItems[0].Tag as ConfigurationData;

                    if (_Data != null)
                    {
                        SubmitSingleValueConfigurationChange(_Settings, _Data);
                    }
                }
            }

            //if (_SelectedServer != null)
            //{
            //    ConfigurationSettings _Settings = _SelectedServer.Tag as ConfigurationSettings;

            //    if (_Settings != null && _Settings.Source == ConfigurationSettings.DataSource.LiveData)
            //    {
            //        ConfigurationData _Data = listResults.SelectedItems[0].Tag as ConfigurationData;
            //        string _SelectedKey = listResults.SelectedItems[0].Name;

            //        if (_Data != null)
            //        {
            //            SubmitSingleValueConfigurationChange(_Settings, _Data);
            //        }


            //        ListViewItem _FocusItem = listResults.Items.Find(_SelectedKey, false)[0];
            //        if(_FocusItem != null)
            //        {
            //            this.Focus();
            //            listResults.BeginUpdate();
            //            listResults.SelectedItems.Clear();
            //            _FocusItem.EnsureVisible();
            //            listResults.FocusedItem = _FocusItem;
            //            listResults.EndUpdate();
                        
            //            //listResults.Items[0].fo
            //            //int _GroupIndex = 0;
            //            //foreach (ListViewGroup _Group in listResults.Groups)
            //            //{
            //            //    _GroupIndex ++;
            //            //    if(_Group.Name == _FocusItem.Group.Name)
            //            //    {
            //            //        break;
            //            //    }
            //            //}
            //            //listResults.EnsureVisible(_FocusItem.Index + _GroupIndex);
            //        }
            //    }
            //}
        }

        private void listServers_ItemClick(object sender, EventArgs e)
        {
            if (sender is ButtonItem)
            {
                SelectNewItem((ButtonItem)sender);
            }
        }

        private void SelectNewItem(ButtonItem newItem)
        {
            if (newItem != null)
            {

                if (_SelectedServer != null)
                {
                    _SelectedServer.Checked = false;
                }

                _SelectedServer = newItem;
                newItem.Checked = true;
                ShowConfigurationItem(newItem);
            }
        }

        void ServerItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SelectNewItem((ButtonItem)sender);
            }
        }

        private void listResults_DoubleClick(object sender, EventArgs e)
        {
            EditItem();
        }

        private void SetSelectedServer()
        {
            if (_SelectedServer != null)
            {
                SelectNewItem(_SelectedServer);
            }
            else if (listServers.Items.Count > 0)
            {
                ButtonItem _Item = listServers.Items[0] as ButtonItem;

                if (_Item != null)
                {
                    SelectNewItem(_Item);
                }
            }
            else
            {
                linkEdit.Visible = false;
            }
        }

        private void buttonSaveAll_Click(object sender, EventArgs e)
        {
            SaveSnapshot(false);
        }

        private void buttonConfigurationSaveSingleServer_Click(object sender, EventArgs e)
        {
            if (_ServerList.ContainsKey(((ButtonItem)sender).Text))
            {
                SaveSnapshot(_ServerList[((ButtonItem)sender).Text]);
            }
        }

        private void ClearConfigurationSnapshotList()
        {
            for (int i = buttonConfigurationSaveSnapshot.SubItems.Count - 1; i > 0; i--)
            {
                buttonConfigurationSaveSnapshot.SubItems.Remove(i);
            }

            buttonConfigurationSaveSnapshot.Enabled = false;
        }

        private void buttonConfigurationClear_Click(object sender, EventArgs e)
        {
            ClearComparisonList();
            listServers.BeginUpdate();
            listServers.Items.Clear();
            listResults.Items.Clear();
            ClearConfigurationSnapshotList();
            ClearDetails();
            _ServerList.Clear();
            ToolStripMenuItemAddServerToComparison.DropDownItems.Clear();
            ToolStripMenuItemSetServerAsBaseline.DropDownItems.Clear();
            ToolStripMenuItemRemoveServerFromComparison.DropDownItems.Clear();
            for (int i = buttonConfigurationAddToComparison.SubItems.Count - 1; i > 0; i--)
            {
               buttonConfigurationAddToComparison.SubItems.RemoveAt(i);
            }
            buttonConfigurationRemove.SubItems.Clear();
            buttonConfigurationSetAsBaseline.SubItems.Clear();


            _SelectedServer = null;
            listServers.EndUpdate();

            ToolStripMenuItemAddServerToComparison.Enabled =
                ToolStripMenuItemSetServerAsBaseline.Enabled =
                ToolStripMenuItemRemoveServerFromComparison.Enabled =
                ToolStripMenuItemAddAllServersToComparison.Enabled =
                buttonConfigurationAddToComparison.Enabled = buttonConfigurationRemove.Enabled =
                buttonConfigurationSetAsBaseline.Enabled = false;
                buttonConfigurationClear.Enabled = false;
        }

        #endregion

        #region Comparison report

        private void AddDataToComparisonReport(ConfigurationSettings data)
        {
            if (data == null) return;

            if (listComparison.Columns.Count == (int)ComparisonListColumn.Baseline)
            {
                _BaselineConfiguration = data;
                AddBaselineToComparison();
            }

            if (_ComparedServerList.ContainsKey(data.Key))
            {
                ReplaceComparisonColumn(data);
            }
            else
            {
                AddNewComparisonColumn(listComparison.Columns.Count, ProductConstants.ComparisonColumnWidth, data);

                ToolStripMenuItemRemoveServerFromComparison.DropDownItems[data.Key].Enabled = true;
                ToolStripMenuItemAddServerToComparison.DropDownItems[data.Key].Enabled = false;
                buttonConfigurationAddToComparison.SubItems[ProductConstants.MenuAddServerKeyPrePend + data.Key].Enabled = false;
            }

            Helpers.ApplyAlternateColorsToListView(listComparison, true, (int)ComparisonListColumn.Baseline);
            ToggleComparisonDifferences(_ShowDifferences);

            ToolStripMenuItemRefreshComparison.Enabled =
                ToolStripMenuItemClearComparison.Enabled =
                menuCopy.Enabled =
                menuExport.Enabled =
                printToolStripMenuItem.Enabled =
                buttonCopyToClipboard.Enabled =
                buttonRefresh.Enabled =
                buttonClear.Enabled = true;

            if (data.Source == ConfigurationSettings.DataSource.LiveData && !buttonSave.SubItems.Contains(data.Key))
            {
                ButtonItem _SaveSubItem = new ButtonItem(data.Key, data.ServerName);
                _SaveSubItem.Click += buttonConfigurationSaveSingleServer_Click;
                buttonSave.SubItems.Add(_SaveSubItem);
                buttonSave.Enabled = true;
            }

            if (data.Source == ConfigurationSettings.DataSource.Snapshot && !buttonFixDifferencesSnapshot.SubItems.Contains(data.Key))
            {
                ButtonItem _FixSnapshotItem = new ButtonItem(data.Key, data.ServerName);
                _FixSnapshotItem.Click += new EventHandler(buttonFixSnapshotDifferences_Click);
                _FixSnapshotItem.Tag = data;
                buttonFixDifferencesSnapshot.SubItems.Add(_FixSnapshotItem);
                buttonFixDifferences.Enabled = buttonFixDifferencesSnapshot.Enabled = true;
            }

            buttonHighlightDifferences.Enabled = (listComparison.Columns.Count > (int)ComparisonListColumn.Baseline + 1);
            buttonAddAllServersToComparison.Enabled = (_ComparedServerList.Count != _ServerList.Count);            
        }

        /// <summary>
        /// Adds baseline configurations to comparison report
        /// </summary>
        private void AddBaselineToComparison()
        {
            if (_BaselineConfiguration == null)
            {
                labelBaselineWarning.Visible = true;
                listComparison.ContextMenu = null;
            }
            else
            {
                if (listComparison.Columns[ProductConstants.ComparisonColumnBaseline] == null)
                {
                    AddNewComparisonColumn((int)ComparisonListColumn.Baseline, ProductConstants.ComparisonColumnWidth, _BaselineConfiguration);
                    ToolStripMenuItemRemoveServerFromComparison.DropDownItems[_BaselineConfiguration.Key].Enabled = true;
                    ToolStripMenuItemAddServerToComparison.DropDownItems[_BaselineConfiguration.Key].Enabled = false;
                    ToolStripMenuItemSetServerAsBaseline.DropDownItems[_BaselineConfiguration.Key].Enabled = false;
                    buttonConfigurationSetAsBaseline.SubItems[ProductConstants.MenuAddBaselineKeyPrePend + _BaselineConfiguration.Key].Enabled = false;
                    buttonConfigurationAddToComparison.SubItems[ProductConstants.MenuAddServerKeyPrePend + _BaselineConfiguration.Key].Enabled = false;
                }
                else
                {
                    ReplaceComparisonColumn(_BaselineConfiguration);
                }

                labelBaselineWarning.Visible = false;
                buttonFixDifferences.Enabled = buttonFixDifferencesBaseline.Enabled = buttonCopyToClipboard.Enabled = buttonRefresh.Enabled = buttonClear.Enabled = true;

                if (_BaselineConfiguration.Source == ConfigurationSettings.DataSource.LiveData && !buttonSave.SubItems.Contains(_BaselineConfiguration.Key))
                {
                    ButtonItem _SaveSubItem = new ButtonItem(_BaselineConfiguration.Key, _BaselineConfiguration.ServerName);
                    _SaveSubItem.Click += buttonConfigurationSaveSingleServer_Click;
                    buttonSave.SubItems.Insert(1, _SaveSubItem);
                    buttonSave.Enabled = true;
                }
            }
        }

        private void AddNewComparisonColumn(int index, int colWidth, ConfigurationSettings settings)
        {
            int _ImageIndex = 3;

            if (settings == _BaselineConfiguration)
            {
                _ImageIndex = 1;
            }
            else if (settings.Source == ConfigurationSettings.DataSource.Snapshot)
            {
                _ImageIndex = 2;
            }

            listComparison.Columns.Insert(index, settings.Key, settings.ServerName, colWidth, HorizontalAlignment.Center, _ImageIndex);

            foreach (ListViewItem _Item in listComparison.Items)
            {
                _Item.SubItems.Insert(index, new ListViewItem.ListViewSubItem());
            }

            listComparison.Columns[index].Tag = settings;
            AddConfigurationToComparisionList(settings, index);
            _ComparedServerList.Add(settings.Key, settings);
        }

        private void ReplaceComparisonColumn(ConfigurationSettings settings)
        {
            if (listComparison.Columns[settings.Key] == null)
            {
                _ComparedServerList.Remove(settings.Key);
                AddDataToComparisonReport(settings);
                return;
            }
            else
            {
                if (_BaselineConfiguration != null && _BaselineConfiguration.Key == settings.Key)
                {
                    _BaselineConfiguration = settings;
                }
                listComparison.Columns[settings.Key].Tag = settings;
                AddConfigurationToComparisionList(settings, listComparison.Columns[settings.Key].Index);
                _ComparedServerList[settings.Key] = settings;
            }
        }

        private void AddConfigurationToComparisionList(ConfigurationSettings settings, int column)
        {
            listComparison.BeginUpdate();

            string _Source = string.Empty;

            switch (settings.Source)
            {
                case ConfigurationSettings.DataSource.LiveData:
                    _Source = "Live Data";
                    break;
                case ConfigurationSettings.DataSource.Snapshot:
                    _Source = "Snapshot";
                    break;
            }

            AddComparisonItem("Data Source", 0, column, _Source, null);
            AddComparisonItem("Date Captured", 0, column, settings.DateCaptured.ToString(), null);
            AddComparisonItem(ProductConstants.RestartDateCaption, 0, column, (settings.LastStartDate == DateTime.MinValue) ? "UNKNOWN" : settings.LastStartDate.ToString(), null);
            AddComparisonItem(ProductConstants.ServerCollationCaption, 0, column, settings.ServerCollation, settings.ServerCollation);
            AddComparisonItem("Version", 0, column, (settings.Version == null) ? "UNKNOWN" : settings.Version.Replace("SQL Server ", ""), null);

            foreach (PropertyInfo _Property in settings.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                ConfigurationData _Data = _Property.GetValue(settings, null) as ConfigurationData;

                if (_Data != null)
                {
                    AddComparisonItem(Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_Data.Name), (int)_Data.Type, column, _Data.DisplayValue, _Data);
                }
            }

            listComparison.EndUpdate();
        }

        /// <summary>
        /// Checks if a new columns needs to be added to the list and applies the requested parameters if one if needed.
        /// </summary>
        private void AddComparisonItem(string name, int group, int column, string value, object tag)
        {
            if (!listComparison.Items.ContainsKey(name))
            {
                ListViewItem _DataSourceItem = listComparison.Items.Add(name, name, -1);
                _DataSourceItem.Group = listComparison.Groups[group];

                for (int i = 1; i <= column; i++)
                {
                    _DataSourceItem.SubItems.Insert(i, new ListViewItem.ListViewSubItem());
                }
            }

            listComparison.Items[name].SubItems[column].Text = value;
            listComparison.Items[name].SubItems[column].Tag = tag;
        }

        private void ToggleComparisonDifferences(bool showDifferences)
        {
            _DifferencesList.Clear();
            _CollationDifferencesFound = false;

            for (int _Row = 0; _Row < listComparison.Items.Count; _Row++)
            {
                ListViewItem _Item = listComparison.Items[_Row];

                // Check For Differences
                bool _DifferenceDetected = false;

                if (listComparison.Columns.Count > (int)ComparisonListColumn.Baseline + 1)
                {
                    string _BaseValue = _Item.SubItems[(int)ComparisonListColumn.Baseline].Text;

                    for (int i = (int)ComparisonListColumn.Baseline + 1; i < _Item.SubItems.Count; i++)
                    {
                        if (_Item.SubItems[i].Tag != null && _Item.SubItems[(int)ComparisonListColumn.Baseline].Tag != null && _BaseValue != _Item.SubItems[i].Text)
                        {
                            if (_Item.Text == ProductConstants.ServerCollationCaption)
                            {
                                _CollationDifferencesFound = true;
                            }

                            if (!_DifferencesList.Contains(_Item.Name))
                            {
                                _DifferencesList.Add(_Item.Name);
                            }
                            if (showDifferences)
                            {
                                _Item.SubItems[i].BackColor = Color.Yellow;
                            }

                            //_DifferenceDetected = true;
                            //break;
                        }
                    }
                }

                //if (_DifferenceDetected)
                //{
                //    for (int i = 0; i < _Item.SubItems.Count; i++)
                //    {
                //        if (!_DifferencesList.Contains(_Item.Name))
                //        {
                //            _DifferencesList.Add(_Item.Name);
                //        }
                //        if (showDifferences)
                //        {
                //            _Item.SubItems[i].BackColor = Color.Yellow;
                //        }
                //    }
                //}
            }

            if (showDifferences)
            {
                buttonHighlightDifferences.Text = ProductConstants.HighlightButtonHideDifferences;
            }
            else
            {
                buttonHighlightDifferences.Text = ProductConstants.HighlightButtonShowDifferences;
            }
        }

        private void buttonHighlightDifferences_Click(object sender, EventArgs e)
        {
            Helpers.ApplyAlternateColorsToListView(listComparison, true, (int)ComparisonListColumn.Baseline);
            _ShowDifferences = !_ShowDifferences;
            ToggleComparisonDifferences(_ShowDifferences);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearComparisonList();
        }

        private void buttonFixBaselineDifferences_Click(object sender, EventArgs e)
        {
            if (_BaselineConfiguration != null)
            {
                ApplyAllSettingsToComparedServers(_BaselineConfiguration);
            }
        }

        private void buttonFixSnapshotDifferences_Click(object sender, EventArgs e)
        {
            ConfigurationSettings _SnapshotSettings = ((ButtonItem)sender).Tag as ConfigurationSettings;
            if (_SnapshotSettings != null)
            {
                ApplyAllSettingsToComparedServers(_SnapshotSettings);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshComparisonData();
        }

        private void RemoveServerFromComparisonReport(string key)
        {
            ToolStripMenuItemRemoveServerFromComparison.DropDownItems[key].Enabled = false;
            ToolStripMenuItemAddServerToComparison.DropDownItems[key].Enabled = true;
            ToolStripMenuItemSetServerAsBaseline.DropDownItems[key].Enabled = true;
            buttonConfigurationAddToComparison.SubItems[ProductConstants.MenuAddServerKeyPrePend + key].Enabled = true;
            buttonConfigurationSetAsBaseline.SubItems[ProductConstants.MenuAddBaselineKeyPrePend + key].Enabled = true;
            buttonAddAllServersToComparison.Enabled = (_ServerList.Count > 1);

            _ComparedServerList.Remove(key);

            if (listComparison.Columns.ContainsKey(key))
            {
                int _Column = listComparison.Columns[key].Index;

                foreach (ListViewItem _Item in listComparison.Items)
                {
                    _Item.SubItems.RemoveAt(_Column);
                }

                listComparison.Columns.RemoveAt(_Column);
            }

            if (buttonSave.SubItems.Contains(key))
            {
                buttonSave.SubItems.Remove(key);

                if (buttonSave.SubItems.Count <= 1)
                {
                    buttonSave.Enabled = false;
                }
            }

            if (_BaselineConfiguration != null && _BaselineConfiguration.Key == key)
            {
                _BaselineConfiguration = null;
                labelBaselineWarning.Visible = true;
                buttonFixDifferencesBaseline.Enabled = false;

                if (listComparison.Columns.Count > (int)ComparisonListColumn.Baseline)
                {
                    ConfigurationSettings _NewBaseline = listComparison.Columns[(int)ComparisonListColumn.Baseline].Tag as ConfigurationSettings;
                    if (_NewBaseline != null)
                    {
                        SetServerAsBaseline(_NewBaseline);
                    }
                }
            }

            if (buttonFixDifferencesSnapshot.SubItems.Contains(key))
            {
                buttonFixDifferencesSnapshot.SubItems.Remove(key);
                if (buttonFixDifferencesSnapshot.SubItems.Count == 0)
                {
                    buttonFixDifferencesSnapshot.Enabled = false;
                }
            }

            if (!buttonFixDifferencesBaseline.Enabled && !buttonFixDifferencesSnapshot.Enabled)
            {
                buttonFixDifferences.Enabled = false;
            }

            ToggleComparisonDifferences(_ShowDifferences);
        }

        private enum ComparisonListColumn
        {
            DataName = 0,
            Baseline = 1
        }

        #endregion

        #region Context Menus

        #region Compare

        private void ContextMenuItemApplySingleSettingToServers_Click(object sender, EventArgs e)
        {
            ApplySingleBaselineSettingToComparedServers();
        }

        private void ContextMenuItemRefresh_Click(object sender, EventArgs e)
        {
            RefreshComparisonData();
        }

        private void ContextMenuItemClearItems_Click(object sender, EventArgs e)
        {
            ClearComparisonList();
        }

        private void ButtonComparisonRemoveServerFromConfiguration_Click(object sender, EventArgs e)
        {
           RemoveServerFromConfiguration(((ButtonItem)sender).Name.Remove(0, ProductConstants.MenuRemoveServerKeyPrePend.Length));
        }

        private void contextMenuItemRemoveServer_Click(object sender, EventArgs e)
        {
            if (_SelectedServer != null)
            {
               RemoveServerFromConfiguration(_SelectedServer.Name);
            }
        }

        private void RemoveServerFromConfiguration(string name)
        {
           listServers.BeginUpdate();
           listServers.Items.Remove(name);

           if (buttonConfigurationSaveSnapshot.SubItems.Contains(name))
           {
              buttonConfigurationSaveSnapshot.SubItems.Remove(name);
           }

           if (buttonConfigurationSaveSnapshot.SubItems.Count <= 1)
           {
              buttonConfigurationSaveSnapshot.Enabled = false;
           }

           listResults.Items.Clear();
           ClearDetails();
           _ServerList.Remove(name);
           RemoveServerFromComparisonReport(name);
           ToolStripMenuItemAddServerToComparison.DropDownItems.RemoveByKey(name);
           ToolStripMenuItemSetServerAsBaseline.DropDownItems.RemoveByKey(name);
           ToolStripMenuItemRemoveServerFromComparison.DropDownItems.RemoveByKey(name);
           if (_SelectedServer.Name == name)
           {
              _SelectedServer = null;
              SetSelectedServer();
           }
           listServers.EndUpdate();
           buttonConfigurationSetAsBaseline.SubItems.Remove(ProductConstants.MenuAddBaselineKeyPrePend + name);
           buttonConfigurationRemove.SubItems.Remove(ProductConstants.MenuRemoveServerKeyPrePend + name);
           buttonConfigurationAddToComparison.SubItems.Remove(ProductConstants.MenuAddServerKeyPrePend + name);

           if (_ServerList.Count == 0)
           {
              ToolStripMenuItemAddServerToComparison.Enabled =
                  ToolStripMenuItemSetServerAsBaseline.Enabled =
                  ToolStripMenuItemRemoveServerFromComparison.Enabled =
                  ToolStripMenuItemAddAllServersToComparison.Enabled =
                  buttonConfigurationAddToComparison.Enabled =
                  buttonConfigurationRemove.Enabled =
                  buttonConfigurationSetAsBaseline.Enabled =
                  buttonConfigurationClear.Enabled = false;
           }
        }

        #endregion

        #region Comparison Header

        private void ContextMenuItemHeaderSetServerAsBaseline_Click(object sender, EventArgs e)
        {
            ConfigurationSettings _Settings = contextComparisonHeader.Tag as ConfigurationSettings;

            if (_Settings != null)
            {
                SetServerAsBaseline(_Settings);
            }
        }

        private void ContextMenuItemHeaderRemoveServer_Click(object sender, EventArgs e)
        {
            ConfigurationSettings _Settings = contextComparisonHeader.Tag as ConfigurationSettings;

            if (_Settings != null)
            {
                RemoveServerFromComparisonReport(_Settings.Key);
            }
        }

        private void ContextMenuItemHeaderSaveServerSnapshot_Click(object sender, EventArgs e)
        {
            ConfigurationSettings _Settings = contextComparisonHeader.Tag as ConfigurationSettings;

            if (_Settings != null)
            {
                SaveSnapshot(_Settings);
            }
        }

        #endregion

        #region Configuration

        private void ContextMenuItemAddServerToComparison_Click(object sender, EventArgs e)
        {
            if (_SelectedServer != null)
            {
                ConfigurationSettings _Settings = _SelectedServer.Tag as ConfigurationSettings;

                if (_Settings != null)
                {
                    AddDataToComparisonReport(_Settings);
                }
            }
        }

        private void ButtonComparisonAddServerToComparison_Click(object sender, EventArgs e)
        {
           ConfigurationSettings _Settings = _ServerList[((ButtonItem)sender).Name.Remove(0, ProductConstants.MenuAddServerKeyPrePend.Length)] as ConfigurationSettings;
           if (_Settings != null)
           {
              AddDataToComparisonReport(_Settings);
           }
        }

        private void contextMenuItemAddAllServersToComparison_Click(object sender, EventArgs e)
        {
            foreach (ConfigurationSettings _Settings in _ServerList.Values)
            {
                AddDataToComparisonReport(_Settings);
            }
        }
        private void contextMenuItemSetAsBaseline_Click(object sender, EventArgs e)
        {
            if (_SelectedServer != null)
            {
                SetServerAsBaseline(_ServerList[_SelectedServer.Name]);
            }
        }

        private void ButtonComparisonSetAsBaseline_Click(object sender, EventArgs e)
        {
           ConfigurationSettings _Settings = _ServerList[((ButtonItem)sender).Name.Remove(0, ProductConstants.MenuAddBaselineKeyPrePend.Length)] as ConfigurationSettings;
           if (_Settings != null)
           {
              SetServerAsBaseline(_Settings);
           }
        }

       private void contextComparisonReport_Opening(object sender, CancelEventArgs e)
       {
          contextMenuItemSetAsBaseline.Enabled = true;
          Point _ListPosition = listServers.PointToClient(MousePosition);

          foreach (BaseItem _Item in listServers.Items)
          {
             if (_Item.DisplayRectangle.Contains(_ListPosition))
             {
                ConfigurationSettings _Settings = _Item.Tag as ConfigurationSettings;
                if (_Settings != null && _Settings == _BaselineConfiguration)
                {
                   contextMenuItemSetAsBaseline.Enabled = false;
                }
             }
          }
       }

        private void ContextMenuItemBulkUpdateSetting_Click(object sender, EventArgs e)
        {
            if (listComparison.SelectedItems.Count == 1)
            {
                ListViewItem _Item = listComparison.SelectedItems[0];

                ConfigurationData _Data = null;

                foreach (ListViewItem.ListViewSubItem _SubItem in _Item.SubItems)
                {
                    _Data = _SubItem.Tag as ConfigurationData;

                    if (_Data != null)
                    {
                        _Data = _Data.Copy();
                        break;
                    }
                }

                if (_Data != null)
                {
                    List<string> _ServersToList = new List<string>();

                    foreach (ConfigurationSettings _Settings in _ComparedServerList.Values)
                    {
                        if (_Settings.Source == ConfigurationSettings.DataSource.LiveData)
                        {
                            _ServersToList.Add(_Settings.Key);
                        }
                    }

                    Form_EditConfiguration _EditForm = new Form_EditConfiguration(_ServersToList);
                    _EditForm.Data = _Data;

                    if (_EditForm.ShowDialog() == DialogResult.OK)
                    {
                        _Data = _EditForm.Data;

                        Dictionary<ServerInformation, ConfigurationData> _SettingsToChange = new Dictionary<ServerInformation, ConfigurationData>();

                        for (int i = 0; i < _Item.SubItems.Count; i++)
                        {
                            ConfigurationSettings _Settings = listComparison.Columns[i].Tag as ConfigurationSettings;

                            if (_Settings != null && _Settings.Source == ConfigurationSettings.DataSource.LiveData && _EditForm.SelectedServers.Contains(_Settings.Key))
                            {
                                ConfigurationData _ServerData = _Item.SubItems[i].Tag as ConfigurationData;

                                if (_ServerData != null && _ServerData.ConfiguredValue != _Data.ConfiguredValue)
                                {
                                    ServerInformation _Server = ((ConfigurationSettings)listComparison.Columns[i].Tag).Server;
                                    ConfigurationData _UpdatedData = _ServerData.Copy();
                                    _UpdatedData.ConfiguredValue = _Data.ConfiguredValue;
                                    _SettingsToChange.Add(_Server, _UpdatedData);
                                }
                            }
                        }

                        ApplySingleSettingToServers(_SettingsToChange);
                    }
                }
                else
                {
                    Messaging.ShowWarning("The selected row has no updatable values");
                }
            }
        }

        #endregion

        #region Menu bar

        private void ToolStripAddServerToCompare_Click(object sender, EventArgs e)
        {
            AddDataToComparisonReport(_ServerList[((ToolStripMenuItem)sender).Text]);
        }

        private void ToolStripSetServerAsBaseline_Click(object sender, EventArgs e)
        {
            SetServerAsBaseline(_ServerList[((ToolStripMenuItem)sender).Text]);
        }

        private void ToolStripMenuItemRefreshComparison_Click(object sender, EventArgs e)
        {
            RefreshComparisonData();
        }

        private void ToolStripMenuItemClearComparison_Click(object sender, EventArgs e)
        {
            ClearComparisonList();
        }

        private void ToolStripRemoveServerFromCompare_Click(object sender, EventArgs e)
        {
            RemoveServerFromComparisonReport(((ToolStripMenuItem)sender).Text);
        }

        #endregion

        #endregion

        #region JobPool event handlers

        void JobPool_ServerTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            if (e.Status == TaskStatus.Success)
            {
                ConfigurationSettings _Settings = (ConfigurationSettings)e.Resultset;

                LoadDataIntoTabs(_Settings);

            }
            else
            {
                _ErrorReports.Add(e.Server.Name, e.ErrorMessage);
            }
        }

        void JobPool_TaskComplete(object sender, JobExecutionEventArgs e)
        {
            ProgressBar_Close();
            
            if (listComparison.Columns.Count <= (int)ComparisonListColumn.Baseline)
            {
                tabMainConfiguration.SelectedTabIndex = 0;
            }

            SetSelectedServer();

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

            if (e.SuccessCount > 0)
            {
                buttonConfigurationClear.Enabled =
                   ToolStripMenuItemAddServerToComparison.Enabled =
                   ToolStripMenuItemSetServerAsBaseline.Enabled =
                   ToolStripMenuItemRemoveServerFromComparison.Enabled =
                   ToolStripMenuItemAddAllServersToComparison.Enabled = 
                   buttonConfigurationAddToComparison.Enabled = 
                   buttonConfigurationRemove.Enabled = 
                   buttonConfigurationSetAsBaseline.Enabled =
                   true;
            }
        }

        #endregion

        #region common
        private void SubmitSingleValueConfigurationChange(ConfigurationSettings settings, ConfigurationData data)
        {
            if (settings != null && data != null)
            {
                Form_EditConfiguration _EditForm = new Form_EditConfiguration();
                _EditForm.Data = data;

                if (_EditForm.ShowDialog() == DialogResult.OK)
                {
                    data = _EditForm.Data;

                    ConfigurationChangeResults _Results = ConfigurationHelper.UpdateConfiguration(settings.Server, data);

                    if (_Results.IsSuccessful)
                    {
                        Messaging.ShowInformation(ProductConstants.InformationConfigurationChangeSuccessful, ProductConstants.CaptionConfigurationChange);

                        LoadConfigurationData(settings.Server);

                        if (!data.RestartRequired)
                        {
                            labelRunValue.Text = listResults.Items[data.Name].SubItems[1].Text = data.ConfiguredValue.ToString();
                        }

                        labelConfigValue.Text = listResults.Items[data.Name].SubItems[2].Text = data.DisplayValue;

                        if (data.Type == ConfigurationType.Security)
                        {
                            Messaging.ShowInformation("Changing the audit level requires restarting SQL Server.");
                        }
                    }
                    else
                    {
                        Messaging.ShowException(ProductConstants.CaptionConfigurationChange, _Results.ChangeException);
                    }
                }
            }
        }

        /// <summary>
        /// Applies all baseline settings to servers in comparison report.
        /// </summary>
        private void ApplyAllSettingsToComparedServers(ConfigurationSettings settingsToApply)
        {
            Cursor = Cursors.WaitCursor;
            Dictionary<ServerInformation, List<ConfigurationData>> _SettingsToChange = new Dictionary<ServerInformation, List<ConfigurationData>>();
            string _OptionChangeList = string.Empty;

            foreach (ListViewItem _Item in listComparison.Items)
            {
                Dictionary<ServerInformation, ConfigurationData> _SingleSettingToChange = RetrieveChangeRequestFromListView(_Item, settingsToApply.GetValueByName(_Item.Name));

                foreach (KeyValuePair<ServerInformation, ConfigurationData> _ChangeItem in _SingleSettingToChange)
                {
                    if (!_SettingsToChange.ContainsKey(_ChangeItem.Key))
                    {
                        _SettingsToChange.Add(_ChangeItem.Key, new List<ConfigurationData>());
                    }

                    _SettingsToChange[_ChangeItem.Key].Add(_ChangeItem.Value);
                    _OptionChangeList += "\t" + _ChangeItem.Value.Name + Environment.NewLine;
                }
            }

            if (_SettingsToChange.Count > 0)
            {
                Form_BulkEdit _BulkEditForm = new Form_BulkEdit(settingsToApply.ServerName, _SettingsToChange, _CollationDifferencesFound);
                if (_BulkEditForm.ShowDialog() == DialogResult.OK)
                {
                    _SettingsToChange = _BulkEditForm.SelectedSettings;
                    Form_ConfigurationChangeResult _ChangeResults = new Form_ConfigurationChangeResult();

                    foreach (KeyValuePair<ServerInformation, List<ConfigurationData>> _ServerChanges in _SettingsToChange)
                    {
                        foreach (ConfigurationData _ChangeData in _ServerChanges.Value)
                        {
                            _ChangeResults.AddResult(ConfigurationHelper.UpdateConfiguration(_ServerChanges.Key, _ChangeData));
                        }
                    }

                    Cursor = Cursors.Default;
                    _ChangeResults.ShowDialog();
                    RefreshComparisonData();
                }
                else
                {
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                Cursor = Cursors.Default;
                string _Message = ProductConstants.InformationAllComparedServersEqual;
                if (_CollationDifferencesFound)
                {
                    _Message = ProductConstants.InformationCollationConflictsFound + Environment.NewLine + Environment.NewLine + _Message;
                }

                Messaging.ShowInformation(_Message);
            }
        }

        /// <summary>
        /// Applies the selected setting to all compared servers.
        /// </summary>
        private void ApplySingleBaselineSettingToComparedServers()
        {
            if (listComparison.SelectedItems.Count == 1)
            {
                Dictionary<ServerInformation, ConfigurationData> _SettingsToChange = RetrieveChangeRequestFromListView(listComparison.SelectedItems[0]);

                ApplySingleSettingToServers(_SettingsToChange);
            }
        }

        private void ApplySingleSettingToServers(Dictionary<ServerInformation, ConfigurationData> _SettingsToChange)
        {
            if (_SettingsToChange.Count > 0)
            {
                Form_ConfigurationChangeResult _ChangeResults = new Form_ConfigurationChangeResult();

                foreach (KeyValuePair<ServerInformation, ConfigurationData> _ServerChanges in _SettingsToChange)
                {
                    _ChangeResults.AddResult(ConfigurationHelper.UpdateConfiguration(_ServerChanges.Key, _ServerChanges.Value));
                }

                _ChangeResults.ShowDialog();
                RefreshComparisonData();
            }
            else
            {
                Messaging.ShowInformation(ProductConstants.InformationAllComparedRowsAreEqual);
            }
        }

        /// <summary>
        /// Retrieves change data from a row in the comparison report.
        /// </summary>
        private Dictionary<ServerInformation, ConfigurationData> RetrieveChangeRequestFromListView(ListViewItem item)
        {
            ConfigurationData _BaselineData = item.SubItems[(int)ComparisonListColumn.Baseline].Tag as ConfigurationData;
            return RetrieveChangeRequestFromListView(item, _BaselineData);
        }

        /// <summary>
        /// Retrieves change data from a row in the comparison report.
        /// </summary>
        private Dictionary<ServerInformation, ConfigurationData> RetrieveChangeRequestFromListView(ListViewItem item, ConfigurationData data)
        {
            Dictionary<ServerInformation, ConfigurationData> _SettingsToChange = new Dictionary<ServerInformation, ConfigurationData>();

            if (_DifferencesList.Contains(item.Name))
            {
                if (data != null)
                {
                    for (int i = 1; i < item.SubItems.Count; i++)
                    {
                        ConfigurationSettings _Settings = listComparison.Columns[i].Tag as ConfigurationSettings;

                        if (_Settings != null && _Settings.Source == ConfigurationSettings.DataSource.LiveData)
                        {
                            ConfigurationData _ServerData = item.SubItems[i].Tag as ConfigurationData;

                            if (_ServerData != null && _ServerData.ConfiguredValue != data.ConfiguredValue && _ServerData != data)
                            {
                                ServerInformation _Server = ((ConfigurationSettings)listComparison.Columns[i].Tag).Server;

                                ConfigurationData _NewData = _ServerData.Copy();
                                _NewData.ConfiguredValue = data.ConfiguredValue;
                                _SettingsToChange.Add(_Server, _NewData);
                            }
                        }
                    }
                }
            }

            return _SettingsToChange;
        }

        /// <summary>
        /// Refreshes comparison data with server information.
        /// </summary>
        private void RefreshComparisonData()
        {
            List<ServerInformation> _ServersToRefresh = new List<ServerInformation>();
            for (int i = (int)ComparisonListColumn.DataName + 1; i < listComparison.Columns.Count; i++)
            {
                if (_ComparedServerList[listComparison.Columns[i].Name].Source == ConfigurationSettings.DataSource.LiveData)
                {
                    _ServersToRefresh.Add(_ComparedServerList[listComparison.Columns[i].Name].Server);
                }
            }
            LoadConfigurationData(_ServersToRefresh);
        }

        /// <summary>
        /// Clears the comparison list.
        /// </summary>
        private void ClearComparisonList()
        {
            for (int i = listComparison.Columns.Count - 1; i >= (int)ComparisonListColumn.Baseline; i--)
            {
               RemoveServerFromComparisonReport(listComparison.Columns[i].Name);
            }

            listComparison.Items.Clear();
            _ComparedServerList.Clear();
            _DifferencesList.Clear();
            _BaselineConfiguration = null;
            ClearComparisonSnapshotList();

            menuCopy.Enabled =
               menuExport.Enabled =
               printToolStripMenuItem.Enabled =
               ToolStripMenuItemRefreshComparison.Enabled =
               ToolStripMenuItemClearComparison.Enabled =
               buttonFixDifferences.Enabled =
               buttonFixDifferencesSnapshot.Enabled =
               buttonFixDifferencesBaseline.Enabled =
               buttonHighlightDifferences.Enabled =
               buttonCopyToClipboard.Enabled =
               buttonRefresh.Enabled =
               buttonClear.Enabled = false;
        }

        /// <summary>
        /// Removes servers from Save snapshot button sub items.
        /// </summary>
        private void ClearComparisonSnapshotList()
        {
            for (int i = buttonSave.SubItems.Count - 1; i > 0; i--)
            {
                buttonSave.SubItems.Remove(i);
            }

            buttonSave.Enabled = false;
        }

        private void SetServerAsBaseline(ConfigurationSettings settings)
        {
            if (settings != null)
            {
                ConfigurationSettings _OldBaseline = null;

                //move old baseline to the end of the list
                if (_BaselineConfiguration != null)
                {
                    _OldBaseline = _BaselineConfiguration;
                    RemoveServerFromComparisonReport(_BaselineConfiguration.Key);
                    ToolStripMenuItemSetServerAsBaseline.DropDownItems[_OldBaseline.Key].Enabled = true;
                    buttonConfigurationSetAsBaseline.SubItems[ProductConstants.MenuAddBaselineKeyPrePend + _OldBaseline.Key].Enabled = true;
                }

                RemoveServerFromComparisonReport(settings.Key);
                _BaselineConfiguration = settings;

                AddBaselineToComparison();

                if (_OldBaseline != null)
                {
                    AddDataToComparisonReport(_OldBaseline);
                }

                Helpers.ApplyAlternateColorsToListView(listComparison, true, (int)ComparisonListColumn.Baseline);
                ToggleComparisonDifferences(_ShowDifferences);
            }
        }

        private void LoadDataIntoTabs(ConfigurationSettings settings)
        {
            if (_ServerList.ContainsKey(settings.Key))
            {
                ReplaceTab(settings);
            }
            else
            {
                AddServerToList(settings);
                ToolStripMenuItemAddServerToComparison.DropDownItems.Add(new ToolStripMenuItem(settings.Key, null, ToolStripAddServerToCompare_Click, settings.Key));
                ToolStripMenuItemSetServerAsBaseline.DropDownItems.Add(new ToolStripMenuItem(settings.Key, null, ToolStripSetServerAsBaseline_Click, settings.Key));
                int _NewRemoveItem = ToolStripMenuItemRemoveServerFromComparison.DropDownItems.Add(new ToolStripMenuItem(settings.Key, null, ToolStripRemoveServerFromCompare_Click, settings.Key));
                ToolStripMenuItemRemoveServerFromComparison.DropDownItems[_NewRemoveItem].Enabled = false;
                
                ButtonItem _AddServerSubItem = new ButtonItem(ProductConstants.MenuAddServerKeyPrePend + settings.Key, settings.ServerName);
                _AddServerSubItem.Click += ButtonComparisonAddServerToComparison_Click;
                buttonConfigurationAddToComparison.SubItems.Add(_AddServerSubItem);
                buttonAddAllServersToComparison.Enabled = (_ServerList.Count > 1);

                ButtonItem _SetAsBaselineSubItem = new ButtonItem(ProductConstants.MenuAddBaselineKeyPrePend + settings.Key, settings.ServerName);
                _SetAsBaselineSubItem.Click += ButtonComparisonSetAsBaseline_Click;
                buttonConfigurationSetAsBaseline.SubItems.Add(_SetAsBaselineSubItem);

                ButtonItem _RemoveServerSubItem = new ButtonItem(ProductConstants.MenuRemoveServerKeyPrePend + settings.Key, settings.ServerName);
                _RemoveServerSubItem.Click += ButtonComparisonRemoveServerFromConfiguration_Click;
                buttonConfigurationRemove.SubItems.Add(_RemoveServerSubItem);
            }

            buttonConfigurationClear.Enabled = true;

            AddDataToComparisonReport(settings);
        }

        private void ServerSelection_TextChanged(object sender, EventArgs e)
        {
            buttonGetConfiguration.Enabled = (ServerSelection.Text != "");
        }

        #endregion

        #region Export Functionality

        private void menuExportAsCSV_Click(object sender, EventArgs e)
        {
            ExportToCSV.CopyListView(listComparison);
        }

        private void menuExportAsXML_Click(object sender, EventArgs e)
        {
            ExportToXML.CopyListView(listComparison, ProductConstants.CopyComparisonToXmlDataSetName, true);
        }

        /// <summary>
        /// Copies selected values to clipboard.
        /// </summary>
        private void ContextMenuItemCopyItems_Click(object sender, EventArgs e)
        {
            ExportToClipboard.CopyListViewToTabbedFormat(ProductConstants.ClipboardHeader, listComparison, false, true);

        }

        /// <summary>
        /// Copies all the settings from a server to the clipboard.
        /// </summary>
        private void ContextMenuItemHeaderCopyToClipboard_Click(object sender, EventArgs e)
        {
            ConfigurationSettings _Settings = contextComparisonHeader.Tag as ConfigurationSettings;

            if (_Settings != null)
            {
                int[] _ColumnWidths = new int[listComparison.Columns.Count];

                for (int i = 0; i < _ColumnWidths.Length; i++)
                {
                    if (i == 0 || i == listComparison.Columns[_Settings.Key].Index)
                    {
                        _ColumnWidths[i] = 35;
                    }
                    else
                    {
                        _ColumnWidths[i] = 0;
                    }
                }

                ExportToClipboard.CopyListView(ProductConstants.ClipboardHeader, listComparison, _ColumnWidths, false);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents(); // let form redraw after main menu closes

                if (tabMainConfiguration.SelectedTab == tabConfigurationResults)
                {
                    //We're going to generate our dataset here since it's not complete in the list view
                    DataSet dataSet = new DataSet();
                    DataTable dataTable = dataSet.Tables.Add("ServerConfiguration");

                    //add the columns
                    dataTable.Columns.Add("SQLServer");
                    dataTable.Columns.Add("Name");
                    dataTable.Columns.Add("Value");
                    dataTable.Columns.Add("Description");

                    foreach (ButtonItem item in listServers.Items)
                    {
                        ConfigurationSettings settings = (ConfigurationSettings)item.Tag;

                        if (settings == null) continue;

                        string serverName = settings.ServerName;

                        addRow(dataTable, settings.AdHocDistributedQueries, serverName);
                        addRow(dataTable, settings.AffinityIOMask, serverName);
                        addRow(dataTable, settings.AffinityMask, serverName);
                        addRow(dataTable, settings.AgentXPs, serverName);

                        //New added fields.
                        addRow(dataTable, settings.Affinity64IOMask, serverName);
                        addRow(dataTable, settings.Affinity64Mask, serverName);
                        addRow(dataTable, settings.AccessCheckCacheBucketCount, serverName);
                        addRow(dataTable, settings.AccessCheckCacheQuota, serverName);

                        addRow(dataTable, settings.AllowServerTriggerRecursion, serverName);
                        addRow(dataTable, settings.AllowUpdates, serverName);
                        addRow(dataTable, settings.AweEnabled, serverName);
                        addRow(dataTable, settings.BlockedProcessThreshold, serverName);
                        addRow(dataTable, settings.C2AuditMode, serverName);
                        addRow(dataTable, settings.ClrEnabled, serverName);
                        addRow(dataTable, settings.CommonCriteriaComplianceEnabled, serverName);
                        addRow(dataTable, settings.CostThresholdForParallelism, serverName);
                        addRow(dataTable, settings.CreateDtcTransactionForRemoteProcedures, serverName);
                        addRow(dataTable, settings.CrossDbOwnershipChaining, serverName);
                        addRow(dataTable, settings.CursorThreshold, serverName);
                        addRow(dataTable, settings.DatabaseMailXPs, serverName);
                        addRow(dataTable, settings.DedicatedRemoteAdminConnectionsAllowed, serverName);
                        addRow(dataTable, settings.DefaultFullTextLanguage, serverName);
                        addRow(dataTable, settings.DefaultLanguage, serverName);
                        addRow(dataTable, settings.DefaultTraceEnabled, serverName);
                        addRow(dataTable, settings.DisallowResultsFromTriggers, serverName);
                        addRow(dataTable, settings.EnableReplicationXPs, serverName);
                        addRow(dataTable, settings.EnableSmoAndDmoXPs, serverName);
                        addRow(dataTable, settings.EnableSqlMailXPs, serverName);
                        addRow(dataTable, settings.EnableWebAssistantProcedures, serverName);
                        addRow(dataTable, settings.EnableXpCmdshell, serverName);
                        addRow(dataTable, settings.FillFactorPercentage, serverName);
                        addRow(dataTable, settings.FullTextCrawlBandwidthMaximum, serverName);
                        addRow(dataTable, settings.FullTextCrawlBandwidthReserved, serverName);
                        addRow(dataTable, settings.FullTextNotificationsBandwidthMaximum, serverName);
                        addRow(dataTable, settings.FullTextNotificationsBandwidthReserved, serverName);
                        addRow(dataTable, settings.InDoubtTransactionResolution, serverName);
                        addRow(dataTable, settings.LightweightPooling, serverName);
                        addRow(dataTable, settings.Locks, serverName);
                        addRow(dataTable, settings.MaximumDegreeOfParallelism, serverName);
                        addRow(dataTable, settings.MaximumFullTextCrawlRange, serverName);
                        addRow(dataTable, settings.MaximumServerMemory, serverName);
                        addRow(dataTable, settings.MaximumTextFieldSizeInReplication, serverName);
                        addRow(dataTable, settings.MaximumWorkerThreads, serverName);
                        addRow(dataTable, settings.MediaRetentionPeriod, serverName);
                        addRow(dataTable, settings.MemoryForIndexCreate, serverName);
                        addRow(dataTable, settings.MinimumMemoryPerQuery, serverName);
                        addRow(dataTable, settings.MinimumServerMemory, serverName);
                        addRow(dataTable, settings.NestedTriggers, serverName);
                        addRow(dataTable, settings.NetworkPacketSize, serverName);
                        addRow(dataTable, settings.OleAutomationProcedures, serverName);
                        addRow(dataTable, settings.OpenDatabaseObjects, serverName);
                        addRow(dataTable, settings.PrecomputedRank, serverName);
                        addRow(dataTable, settings.PriorityBoost, serverName);
                        addRow(dataTable, settings.ProtocolHandlerTimeout, serverName);
                        addRow(dataTable, settings.QueryGovernorCostLimit, serverName);
                        addRow(dataTable, settings.QueryMemoryWaitTimeMaximum, serverName);
                        addRow(dataTable, settings.RecoveryIntervalMaximum, serverName);
                        addRow(dataTable, settings.RemoteAccessAllowed, serverName);
                        addRow(dataTable, settings.RemoteLoginTimeout, serverName);
                        addRow(dataTable, settings.RemoteQueryTimeout, serverName);
                        addRow(dataTable, settings.ScanForStartupProcs, serverName);
                        addRow(dataTable, settings.SetWorkingSetSize, serverName);
                        addRow(dataTable, settings.ShowAdvancedOptions, serverName);
                        addRow(dataTable, settings.TransformNoiseWordsForFullTextQuery, serverName);
                        addRow(dataTable, settings.TwoDigitYearCutoff, serverName);
                        addRow(dataTable, settings.UserConnectionsCountAllowed, serverName);
                        addRow(dataTable, settings.UserOptions, serverName);
                        addRow(dataTable, settings.AuditLevel, serverName);
                    }

                    //is there data?
                    if (dataSet.Tables["ServerConfiguration"].Rows.Count == 0)
                    {
                        MessageBox.Show(
                            "No data to print.\r\n\r\nPlease click 'Get Configuration' to gather data for the report.",
                            "No Data",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                    }

                    //launch the report dialog
                    Form_Report frm = new Form_Report(dataSet);
                    frm.Show(this);
                }
                else
                {
                    if (_ComparedServerList.Count == 0)
                    {
                        Messaging.ShowError("You must add servers to the comparison tab in order to print them");
                        return;
                    }

                    List<ServerConfiguration_ReportData> _ComparisonData = new List<ServerConfiguration_ReportData>();

                    foreach (ConfigurationSettings _ServerConfiguration in _ComparedServerList.Values)
                    {

                        string _Source = string.Empty;

                        switch (_ServerConfiguration.Source)
                        {
                            case ConfigurationSettings.DataSource.LiveData:
                                _Source = "Live Data";
                                break;
                            case ConfigurationSettings.DataSource.Snapshot:
                                _Source = "Snapshot";
                                break;
                        }

                        
                        _ComparisonData.Add(new ServerConfiguration_ReportData(_ServerConfiguration.Key, "Data Source", _Source, listResults.Groups[0].Header));
                        _ComparisonData.Add(new ServerConfiguration_ReportData(_ServerConfiguration.Key, "Date Captured", _ServerConfiguration.DateCaptured.ToString(), listResults.Groups[0].Header));
                        _ComparisonData.Add(new ServerConfiguration_ReportData(_ServerConfiguration.Key, ProductConstants.RestartDateCaption, (_ServerConfiguration.LastStartDate == DateTime.MinValue) ? "UNKNOWN" : _ServerConfiguration.LastStartDate.ToString(), listResults.Groups[0].Header));
                        _ComparisonData.Add(new ServerConfiguration_ReportData(_ServerConfiguration.Key, ProductConstants.ServerCollationCaption, _ServerConfiguration.ServerCollation, listResults.Groups[0].Header));
                        _ComparisonData.Add(new ServerConfiguration_ReportData(_ServerConfiguration.Key, "Version", (_ServerConfiguration.Version == null) ? "UNKNOWN" : _ServerConfiguration.Version.Replace("SQL Server ", ""), listResults.Groups[0].Header));

                        foreach (PropertyInfo _Property in _ServerConfiguration.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                        {
                            ConfigurationData _Data = _Property.GetValue(_ServerConfiguration, null) as ConfigurationData;
                            if (_Data != null)
                            {
                                _ComparisonData.Add(new ServerConfiguration_ReportData(
                                        _ServerConfiguration.Key, 
                                        Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(_Data.Name), 
                                        _Data.DisplayValue,
                                        listResults.Groups[(int)_Data.Type].Header));
                            }
                        }
                    }

                    Form_ComparisonReport frm = new Form_ComparisonReport(_ComparisonData);
                    frm.Show();
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private static void addRow(DataTable dataTable, ConfigurationData data, string serverName)
        {
           if ( data != null )
           {
            DataRow dataRow = dataTable.NewRow();
            string[] subItems = new string[4]; //for the four columns

            subItems[0] = serverName;
            subItems[1] = data.Name;
            subItems[2] = data.RunningValue.ToString();
            subItems[3] = data.Description;

            dataRow.ItemArray = subItems;
            dataTable.Rows.Add(dataRow);
           }
        }

        #endregion

        #region Snapshot

        private void buttonSaveAllCompared_Click(object sender, EventArgs e)
        {
            SaveSnapshot(true);
        }

        private void buttonOpenSnapshot_Click(object sender, EventArgs e)
        {
            LoadSnapshot();
        }

        /// <summary>
        /// Saves a snapshot of a single server.
        /// </summary>
        private void SaveSnapshot(ConfigurationSettings settings)
        {
            // create default name
            SaveFileDialog _FileDialog = new SaveFileDialog();
            _FileDialog.Title = "Save Snapshot As";
            _FileDialog.AddExtension = true;
            _FileDialog.CheckPathExists = true;
            _FileDialog.DefaultExt = "xml";
            _FileDialog.FileName = string.Format("{0}_{1}_{2}.xml",
                                                  settings.ServerName.Replace("\\", "-"),
                                                  ProductConstants.shortProductName,
                                                  DateTime.Now.ToString("yyyyMMdd"));
            _FileDialog.Filter = "XML File (*.xml)|*.xml|All Files (*.*)|*.*";
            _FileDialog.InitialDirectory = ProductConstants.SnapshotDirectory;

            if (_FileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveSnapshot(settings, _FileDialog.FileName, false);
            }
        }

        /// <summary>
        /// Saves a snapshot of a server to the specified file.
        /// </summary>
        private void SaveSnapshot(ConfigurationSettings settings, string fileName, bool checkforFileExists)
        {
            try
            {
                if (settings.Source == ConfigurationSettings.DataSource.LiveData)
                {
                    if (checkforFileExists && File.Exists(fileName) && Messaging.ShowConfirmation(string.Format("The file\n {0} \n already exists, do you want to replace it?", fileName)) == DialogResult.No)
                    {
                        return;
                    }

                    XmlSerializer _Serializer = new XmlSerializer(typeof(ConfigurationSettings));
                    using (TextWriter _Writer = new StreamWriter(fileName))
                    {
                        _Serializer.Serialize(_Writer, settings);
                        _Writer.Close();
                    }
                }
                else
                {
                    Messaging.ShowError("You can only save Snapshots for live servers");
                }
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Save Snapshot", exc);
            }
        }

        /// <summary>
        /// Save snapshots for all live servers.
        /// </summary>
        private void SaveSnapshot(bool comparisonOnly)
        {
            if ((comparisonOnly && _ComparedServerList.Count > 0) || (!comparisonOnly && _ServerList.Count >= 1))
            {
                FolderBrowserDialog _FolderDialog = new FolderBrowserDialog();
                _FolderDialog.Description = "Select the folder to save snapshots for each live server into";
                _FolderDialog.SelectedPath = ProductConstants.SnapshotDirectory;

                if (_FolderDialog.ShowDialog() == DialogResult.OK)
                {
                    List<ConfigurationSettings> _SettingsToSerialize = new List<ConfigurationSettings>();

                    if (comparisonOnly)
                    {
                        foreach (ConfigurationSettings _Settings in _ComparedServerList.Values)
                        {
                            if (_Settings.Source == ConfigurationSettings.DataSource.LiveData)
                            {
                                _SettingsToSerialize.Add(_Settings);
                            }
                        }
                    }
                    else
                    {
                        foreach (ConfigurationSettings _Settings in _ServerList.Values)
                        {
                            if (_Settings.Source == ConfigurationSettings.DataSource.LiveData)
                            {
                                _SettingsToSerialize.Add(_Settings);
                            }
                        }
                    }

                    foreach (ConfigurationSettings _Settings in _SettingsToSerialize)
                    {
                        SaveSnapshot(_Settings, Path.Combine(_FolderDialog.SelectedPath,
                                       string.Format("{0}_{1}_{2}.xml", _Settings.ServerName.Replace("\\", "-"), ProductConstants.shortProductName, DateTime.Now.ToString("yyyyMMdd"))),
                                       true);
                    }
                }
            }
            else
            {
                if (comparisonOnly)
                {
                    Messaging.ShowError("You must add items to the comparison report before saving a snapshot.");
                }
                else
                {
                    Messaging.ShowError("You must have server configurations on the list before saving a snapshot.");
                }
            }
        }

        /// <summary>
        /// Loads a snapshot view of a server.
        /// </summary>
        /// <remarks>
        /// For backwards compatibility, it tries to load a list of servers if the attempt to load just one server fails.
        /// </remarks>
        private void LoadSnapshot()
        {
            Form_OpenSnapshot frm = new Form_OpenSnapshot();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.clearAllExisting)
                {
                    ClearComparisonList();
                }

                if (File.Exists(frm.snapshotFile))
                {
                    List<ConfigurationSettings> _SnapshotSettings = new List<ConfigurationSettings>();

                    try
                    {
                        using (TextReader _Reader = new StreamReader(frm.snapshotFile))
                        {
                            XmlSerializer _Serializer = new XmlSerializer(typeof(ConfigurationSettings));
                            _SnapshotSettings.Add((ConfigurationSettings)_Serializer.Deserialize(_Reader));
                            _Reader.Close();
                        }
                    }
                    catch
                    {
                        try
                        {
                            using (TextReader _Reader = new StreamReader(frm.snapshotFile))
                            {
                                XmlSerializer _Serializer = new XmlSerializer(typeof(List<ConfigurationSettings>));
                                _SnapshotSettings.AddRange((List<ConfigurationSettings>)_Serializer.Deserialize(_Reader));
                                _Reader.Close();
                            }
                        }
                        catch
                        {
                            Messaging.ShowError("Error loading snapshot data");
                            _SnapshotSettings = null;
                        }
                    }


                    if (_SnapshotSettings != null && _SnapshotSettings.Count > 0)
                    {
                        foreach (ConfigurationSettings _LoadedSettings in _SnapshotSettings)
                        {
                            _LoadedSettings.Source = ConfigurationSettings.DataSource.Snapshot;
                            LoadDataIntoTabs(_LoadedSettings);
                        }
                    }
                }
                else
                {
                    Messaging.ShowError("Snapshot data does not exist");
                }
            }
        }

        #endregion

        #region Handle Context Menu at Column Header

        // Called when the user right-clicks anywhere in the ListView, including the
        // header bar.  It displays the appropriate context menu for the data row or
        // header that was right-clicked. 
        private void contextBulkEditMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            // This call indirectly calls EnumWindowCallBack which sets _headerRect
            // to the area occupied by the ListView's header bar.
            EnumChildWindows(listComparison.Handle, EnumWindowCallBack, IntPtr.Zero);

            // If the mouse position is in the header bar, cancel the display
            // of the regular context menu and display the column header context menu instead.
            Point mousePosition = MousePosition;

            contextComparisonHeader.Visible = false;

            if (_headerRect.Contains(mousePosition))
            {
                e.Cancel = true;

                // The xoffset is how far the mouse is from the left edge of the header.
                int xoffset = mousePosition.X - _headerRect.Left;

                // Iterate through the column headers in the order they are displayed, adding up
                // their widths as we go.  When the sum exceeds the xoffset, we know the mouse
                // is on the current header. 
                int col = 0;
                int sum = 0;

                foreach (ColumnHeader header in GetOrderedHeaders(listComparison))
                {
                    sum += header.Width;

                    if (sum > xoffset)
                    {
                        if (col != 0)
                        {
                            ConfigurationSettings _Settings = header.Tag as ConfigurationSettings;
                            if (_Settings != null)
                            {
                                contextComparisonHeader.Tag = header.Tag;
                                ContextMenuItemHeaderSetServerAsBaseline.Text = string.Format("Set {0} as &Baseline", header.Text);
                                ContextMenuItemHeaderRemoveServer.Text = string.Format("&Remove {0} from Comparison Report", header.Text);
                                ContextMenuItemHeaderCopyToClipboard.Text = string.Format("&Copy {0} to Clipboard", header.Text);
                                ContextMenuItemHeaderSaveServerSnapshot.Text = string.Format("Save &Snapshot for {0}", header.Text);
                                ContextMenuItemHeaderSaveServerSnapshot.Visible = _Settings.Source == ConfigurationSettings.DataSource.LiveData;
                                ContextMenuItemHeaderSetServerAsBaseline.Enabled = (_Settings != _BaselineConfiguration);
                                contextComparisonHeader.Show(mousePosition);
                            }
                        }

                        break;
                    }

                    col++;
                }
            }
            else
            {
                Point _ListPosition = listComparison.PointToClient(mousePosition);
                ListViewItem _SelectedItem = listComparison.GetItemAt(_ListPosition.X, _ListPosition.Y);

                if (_SelectedItem != null)
                {
                    if (_SelectedItem.Group == listComparison.Groups[0] || listComparison.SelectedItems.Count > 1)
                    {
                        ContextMenuItemBulkUpdateSetting.Visible = toolStripSeparator2.Visible = ContextMenuItemApplySingleSettingToServers.Visible = false;
                    }
                    else
                    {
                        ContextMenuItemBulkUpdateSetting.Visible = toolStripSeparator2.Visible = ContextMenuItemApplySingleSettingToServers.Visible = true;
                        ContextMenuItemApplySingleSettingToServers.Text = string.Format("Set baseline value for \"{0}\" to all servers", _SelectedItem.Name);
                        ContextMenuItemApplySingleSettingToServers.Enabled = (_BaselineConfiguration != null && _SelectedItem.SubItems[(int)ComparisonListColumn.Baseline].Text.Length > 0);
                        ContextMenuItemBulkUpdateSetting.Text = string.Format("Bulk update \"{0}\"", _SelectedItem.Name);
                    }
                    _SelectedItem.Selected = true;
                }
                else
                {
                    e.Cancel = true;
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

        private void menuCopy_Click(object sender, EventArgs e)
        {
           CopyComparison();
        }

       private void buttonCopyToClipboard_Click(object sender, EventArgs e)
       {
          CopyComparison();
       }

       private void CopyComparison()
       {

           ExportToClipboard.CopyListViewToTabbedFormat(ProductConstants.ClipboardHeader, listComparison, false, false);

       }

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

        public void ProgressBar_Update( string msg)
        {
            if(_ProgressDialog != null)
            {
               _ProgressDialog.OperationText = msg;
            }
        }
        
        public void ProgressBar_Initialize( string msg)
        {
            _ProgressDialog = new ToolProgressBarDialog();
            _ProgressDialog.OperationText = msg;
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

       private void ShowF1Help(object sender, HelpEventArgs hlpevent)
       {
          HelpMenu.ShowHelp();
       }

        private void buttonSave_Click(object sender, EventArgs e)
        {

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