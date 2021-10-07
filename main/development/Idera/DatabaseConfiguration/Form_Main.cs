using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core;
using DevComponents.DotNetBar.Controls;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using DevComponents.DotNetBar;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.DatabaseConfiguration
{
    public partial class Form_Main : Form
    {
        private bool _ShowDifferences = true;
        Dictionary<string, List<ConfigurationSettings>> _ServerConfigurations = new Dictionary<string, List<ConfigurationSettings>>();
        ConfigurationSettings _BaselineConfiguration = null;
        private Dictionary<string, ConfigurationSettings> _ComparedDatabaseList = new Dictionary<string, ConfigurationSettings>();
        private JobPool<List<ConfigurationSettings>> _JobPool;
        bool _IgnoreSystemDatabases = false;
        private static Dictionary<string, string> _ErrorReports = new Dictionary<string, string>();
        private List<string> _DifferencesList = new List<string>();
        bool _TooManyDatabasesWarningDisplayed = false;
        
        private ToolProgressBarDialog _ProgressDialog;

        bool _CollationDifferencesFound = false;
        bool _CompatibilityDifferencesFound = false;
        

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

            // Program Specific Logic
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
                    DataTable dataTable = dataSet.Tables.Add("DatabaseConfiguration");

                    //add the columns
                    dataTable.Columns.Add("SQLServer");
                    dataTable.Columns.Add("Database");
                    dataTable.Columns.Add("Name");
                    dataTable.Columns.Add("Value");

                    //loop through the servers
                    foreach (KeyValuePair<string, List<ConfigurationSettings>> _ServerValues in _ServerConfigurations)
                    {
                        string serverName = _ServerValues.Key;

                        foreach (ConfigurationSettings _DatabaseValues in _ServerValues.Value)
                        {
                            string databaseName = _DatabaseValues.Key;

                            addRow(dataTable, _DatabaseValues.AllowSnapshotIsolation, serverName, databaseName);
                            //SQLADMI-350.
                            addRow(dataTable, _DatabaseValues.ReadCommittedSnapshot, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.AnsiNullDefault, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.AnsiNullsEnabled, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.AnsiPaddingEnabled, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.AnsiWarningsEnabled, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.ArithmeticAbortEnabled, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.AutoClose, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.AutoCreateStatistics, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.AutoShrink, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.AutoUpdateStatistics, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.AutoUpdateStatisticsAsync, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.ConcatenatedNullYieldsNull, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.CursorCloseOnCommit, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.CursorDefaultScope, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.DataAccess, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.DatabaseChaining, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.DateCorrelationOptimizationEnabled, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.EnableBroker, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.IsTrustWorthy, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.NumericRoundAbort, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.PageVerifyMode, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.Parameterization, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.QuotedIdentifiersEnabled, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.Recovery, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.RecursiveTriggersEnabled, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.RestrictAccess, serverName, databaseName);
                            addRow(dataTable, _DatabaseValues.TornPageDetection, serverName, databaseName);
                        }
                    }

                    //is there data?
                    if (dataSet.Tables["DatabaseConfiguration"].Rows.Count == 0)
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
                    if (_ComparedDatabaseList.Count == 0)
                    {
                        Messaging.ShowError("You must add databases to the comparison tab in order to print them.");
                        return;
                    }

                    List<DatabaseConfiguration_ReportData> _ComparisonData = new List<DatabaseConfiguration_ReportData>();

                    
                    
                    foreach (ConfigurationSettings _DatabaseConfiguration in _ComparedDatabaseList.Values)
                    {
                        _ComparisonData.Add(new DatabaseConfiguration_ReportData(
                                       _DatabaseConfiguration.Key, _DatabaseConfiguration.DatabaseName, "Server Name", _DatabaseConfiguration.ServerName, "Database Information"));
                       
                        _ComparisonData.Add(new DatabaseConfiguration_ReportData(
                                       _DatabaseConfiguration.Key, _DatabaseConfiguration.DatabaseName, "Server Version", _DatabaseConfiguration.ServerVersion.Replace("SQL Server", string.Empty), "Database Information"));

                        _ComparisonData.Add(new DatabaseConfiguration_ReportData(
                                       _DatabaseConfiguration.Key, _DatabaseConfiguration.DatabaseName, "Database Name", _DatabaseConfiguration.DatabaseName, "Database Information"));


                        _ComparisonData.Add(new DatabaseConfiguration_ReportData(
                                       _DatabaseConfiguration.Key, _DatabaseConfiguration.DatabaseName, ProductConstants.ConfigurationValueCompatibility, _DatabaseConfiguration.CompatibilityLevel, "Database Information"));
                        
                        _ComparisonData.Add(new DatabaseConfiguration_ReportData(
                                       _DatabaseConfiguration.Key, _DatabaseConfiguration.DatabaseName, ProductConstants.ConfigurationValueCollation, _DatabaseConfiguration.Collation, "Database Information"));


                        string _Source = string.Empty;
                        switch (_DatabaseConfiguration.Source)
                        {
                            case DataSource.LiveData:
                                _Source = "Live Data";
                                break;
                            case DataSource.Snapshot:
                                _Source = "Snapshot";
                                break;
                        }

                        _ComparisonData.Add(new DatabaseConfiguration_ReportData(
                                       _DatabaseConfiguration.Key, _DatabaseConfiguration.DatabaseName, "Data Source", _Source, "Database Information"));

                        _ComparisonData.Add(new DatabaseConfiguration_ReportData(
                                       _DatabaseConfiguration.Key, _DatabaseConfiguration.DatabaseName, "Date Captured", _DatabaseConfiguration.DateCaptured.ToString(), "Database Information"));

                        foreach (PropertyInfo _Property in _DatabaseConfiguration.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                        {
                            ConfigurationData _Data = _Property.GetValue(_DatabaseConfiguration, null) as ConfigurationData;
                            if (_Data != null)
                            {
                                _ComparisonData.Add(new DatabaseConfiguration_ReportData(
                                        _DatabaseConfiguration.Key, _DatabaseConfiguration.DatabaseName, _Data.Name, _Data.Value, listComparison.Groups[(int)_Data.Group].Header));
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

        private static void addRow(DataTable dataTable, ConfigurationData data, string serverName, string dbName)
        {
            DataRow dataRow = dataTable.NewRow();
            string[] subItems = new string[4]; //for the four columns

            subItems[0] = serverName;
            subItems[1] = dbName;
            subItems[2] = data.Name;
            subItems[3] = data.Value;

            dataRow.ItemArray = subItems;
            dataTable.Rows.Add(dataRow);
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

        #region Options List

        private void buttonGetResults_Click(object sender, EventArgs e)
        {
            // Validation
            if (ServerSelection.Text.Trim().Length == 0)
            {
                Messaging.ShowError("Specify a SQL Server instance name.");
                ServerSelection.Select();
                return;
            }

            _IgnoreSystemDatabases = checkHideSystemDatabases.Checked;

            LoadConfigurationData(ServerSelection.ServerList);

            MRU.AddServerOrGroup(ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server,
                                  ServerSelection.Text,
                                  ServerSelection.SqlCredentials);
        }

        private void LoadConfigurationData(List<ServerInformation> serverInformationList)
        {
            if (serverInformationList.Count == 0) return;

            ConfigurationOptions _Options = new ConfigurationOptions();
            _Options.IgnoreSystemDatabases = _IgnoreSystemDatabases;
            
            ProgressBar_Initialize( ProductConstants.ProgressGatherData );
            _JobPool = new JobPool<List<ConfigurationSettings>>(5);
            _JobPool.ServerTaskComplete += JobPool_ServerTaskComplete;
            _JobPool.TaskComplete += JobPool_TaskComplete;

            _JobPool.Enqueue(DatabaseConfigurationHelper.GetDatabaseConfiguration, serverInformationList, ToolsetOptions.commandTimeout, _Options);
            _JobPool.StartAsync();
            
            ProgressBar_Show();
        }

        private void AddServerToTree(KeyValuePair<string, List<ConfigurationSettings>> serverData)
        {
            string _SelectedDatabase = null;
            string _SelectedServer = null;
            bool _ReplaceComparisonValues = (_ComparedDatabaseList.Count > 0);

            if (_ServerConfigurations.ContainsKey(serverData.Key))
            {
                _ServerConfigurations[serverData.Key] = serverData.Value;
            }
            else
            {
                _ServerConfigurations.Add(serverData.Key, serverData.Value);
            }

            if (treeResults.SelectedNode != null && treeResults.SelectedNode.ImageIndex != (int)IconImage.DatabaseError)
            {
                if (treeResults.SelectedNode.Level == 0)
                {
                    _SelectedServer = treeResults.SelectedNode.Name;
                }
                else
                {
                    _SelectedDatabase = treeResults.SelectedNode.Name;
                    _SelectedServer = treeResults.SelectedNode.Parent.Name;
                }
            }


            buttonAddToComparison.Enabled = true;
            TreeNode _ServerNode = null;
            if (treeResults.Nodes.ContainsKey(serverData.Key))
            {
                _ServerNode = treeResults.Nodes[serverData.Key];
            }
            else
            {
                _ServerNode = new TreeNode(serverData.Key, (int)IconImage.Server, (int)IconImage.Server);
                _ServerNode.ToolTipText = ProductConstants.TooltipServer;
                _ServerNode.Name = serverData.Key;
                treeResults.Nodes.Add(_ServerNode);
            }

            int _ServerAddDatabaseDropDownItem;

            if (ToolStripMenuItemAddDatabaseToComparison.DropDownItems.ContainsKey(_ServerNode.Name))
            {
                _ServerAddDatabaseDropDownItem = ToolStripMenuItemAddDatabaseToComparison.DropDownItems.IndexOfKey(_ServerNode.Name);
            }
            else
            {
                _ServerAddDatabaseDropDownItem = ToolStripMenuItemAddDatabaseToComparison.DropDownItems.Add(new ToolStripMenuItem(_ServerNode.Name, null, null, _ServerNode.Name));
            }

            if (!ToolStripMenuItemAddServerToComparison.DropDownItems.ContainsKey(_ServerNode.Name))
            {
                ToolStripMenuItemAddServerToComparison.DropDownItems.Add(new ToolStripMenuItem(_ServerNode.Name, null, ToolStripMenuItemAddServerToComparison_Click, _ServerNode.Name));
            }
            int _SetDatabaseAsBaselineDropDownItem;

            if (ToolStripMenuItemSetServerAsBaseline.DropDownItems.ContainsKey(_ServerNode.Name))
            {
                _SetDatabaseAsBaselineDropDownItem = ToolStripMenuItemSetServerAsBaseline.DropDownItems.IndexOfKey(_ServerNode.Name);
            }
            else
            {
                _SetDatabaseAsBaselineDropDownItem = ToolStripMenuItemSetServerAsBaseline.DropDownItems.Add(new ToolStripMenuItem(_ServerNode.Name, null, null, _ServerNode.Name));
            }


            ButtonItem _SaveServerButton;
            if (buttonConfigurationSaveSnapshot.SubItems.Contains(serverData.Key))
            {
                _SaveServerButton = (ButtonItem)buttonConfigurationSaveSnapshot.SubItems[serverData.Key];
            }
            else
            {
                _SaveServerButton = new ButtonItem(serverData.Key, serverData.Key);
                buttonConfigurationSaveSnapshot.SubItems.Add(_SaveServerButton);
            }

            ButtonItem _SetBaselineButton;
            if (buttonConfigurationSetAsBaseline.SubItems.Contains(serverData.Key))
            {
                _SetBaselineButton = (ButtonItem)buttonConfigurationSetAsBaseline.SubItems[serverData.Key];
            }
            else
            {
                _SetBaselineButton = new ButtonItem(serverData.Key, serverData.Key);
                buttonConfigurationSetAsBaseline.SubItems.Add(_SetBaselineButton);
            }

            foreach (ConfigurationSettings _DatabaseValues in serverData.Value)
            {
                TreeNode _DatabaseNode = null;
                if(_ServerNode.Nodes.ContainsKey(_DatabaseValues.Key))
                {
                    _DatabaseNode = _ServerNode.Nodes[_DatabaseValues.Key];
                }
                else
                {
                    _DatabaseNode = new TreeNode(_DatabaseValues.DatabaseName, (int)IconImage.DatabaseOk, (int)IconImage.DatabaseOk);
                    _DatabaseNode.ToolTipText = ProductConstants.TooltipDatabase;
                    _DatabaseNode.Name = _DatabaseValues.Key;
                    _ServerNode.Nodes.Add(_DatabaseNode);
                }
                
                _DatabaseNode.Tag = _DatabaseValues;

                if (_DatabaseValues.DataException != null)
                {
                    _DatabaseNode.ImageIndex = _DatabaseNode.SelectedImageIndex = (int)IconImage.DatabaseError;
                    _DatabaseNode.ToolTipText = ProductConstants.TooltipDatabaseError;
                }
                else
                {
                    int _DatabaseItemIndex;

                    if (((ToolStripMenuItem)ToolStripMenuItemAddDatabaseToComparison.DropDownItems[_ServerAddDatabaseDropDownItem]).DropDownItems.ContainsKey(_DatabaseValues.Key))
                    {
                        _DatabaseItemIndex = ((ToolStripMenuItem)ToolStripMenuItemAddDatabaseToComparison.DropDownItems[_ServerAddDatabaseDropDownItem]).DropDownItems.IndexOfKey(_DatabaseValues.Key);
                    }
                    else
                    {
                        _DatabaseItemIndex = ((ToolStripMenuItem)ToolStripMenuItemAddDatabaseToComparison.DropDownItems[_ServerAddDatabaseDropDownItem]).DropDownItems.Add(new ToolStripMenuItem(_DatabaseValues.DatabaseName, null, ToolStripMenuItemAddDatabaseToComparison_Click, _DatabaseValues.Key));
                    }
                    ((ToolStripMenuItem)ToolStripMenuItemAddDatabaseToComparison.DropDownItems[_ServerAddDatabaseDropDownItem]).DropDownItems[_DatabaseItemIndex].Tag = _DatabaseValues;

                    if (((ToolStripMenuItem)ToolStripMenuItemSetServerAsBaseline.DropDownItems[_SetDatabaseAsBaselineDropDownItem]).DropDownItems.ContainsKey(_DatabaseValues.Key))
                    {
                        _DatabaseItemIndex = ((ToolStripMenuItem)ToolStripMenuItemSetServerAsBaseline.DropDownItems[_SetDatabaseAsBaselineDropDownItem]).DropDownItems.IndexOfKey(_DatabaseValues.Key);
                    }
                    else
                    {
                        _DatabaseItemIndex = ((ToolStripMenuItem)ToolStripMenuItemSetServerAsBaseline.DropDownItems[_SetDatabaseAsBaselineDropDownItem]).DropDownItems.Add(new ToolStripMenuItem(_DatabaseValues.DatabaseName, null, toolStripMenuItemSetAsBaseline_Click, _DatabaseValues.Key));
                    }
                    ((ToolStripMenuItem)ToolStripMenuItemSetServerAsBaseline.DropDownItems[_SetDatabaseAsBaselineDropDownItem]).DropDownItems[_DatabaseItemIndex].Tag = _DatabaseValues;

                    if (_ReplaceComparisonValues && _ComparedDatabaseList.ContainsKey(_DatabaseValues.Key))
                    {
                        AddDataToComparisonReport(_DatabaseValues);
                    }

                    if (!_SaveServerButton.SubItems.Contains(_DatabaseValues.Key))
                    {
                        ButtonItem _SaveDatabaseItem = new ButtonItem(_DatabaseValues.Key, _DatabaseValues.DatabaseName);
                        _SaveDatabaseItem.Click += buttonSaveDatabaseSnapshot_Click;
                        _SaveServerButton.SubItems.Add(_SaveDatabaseItem);
                    }
                    _SaveServerButton.SubItems[_DatabaseValues.Key].Tag = _DatabaseValues;

                    if (!_SetBaselineButton.SubItems.Contains(_DatabaseValues.Key))
                    {
                        ButtonItem _SetBaselineDatabaseItem = new ButtonItem(_DatabaseValues.Key, _DatabaseValues.DatabaseName);
                        _SetBaselineDatabaseItem.Click += buttonConfigurationSetAsBaseline_Click;
                        _SetBaselineButton.SubItems.Add(_SetBaselineDatabaseItem);
                    }
                    _SetBaselineButton.SubItems[_DatabaseValues.Key].Tag = _DatabaseValues;
                    
                }
            }

            if (_SelectedServer != null)
            {
                treeResults.SelectedNode = treeResults.Nodes[_SelectedServer];
            }

            if (_SelectedDatabase != null)
            {
                treeResults.SelectedNode = treeResults.Nodes[_SelectedServer].Nodes[_SelectedDatabase];
            }

            PopulateListOnItemSelect(treeResults.SelectedNode);
        }
        
        private void PopulateListOnItemSelect(TreeNode selectedNode)
        {
            if (selectedNode == null) return;

            switch (selectedNode.Level)
            {
                case 0:  //Server
                    listOptions.BeginUpdate();
                    listOptions.Items.Clear();
                    listOptions.ShowGroups = false;
                    AddItemToOptionsList("Server Name", selectedNode.Text, OptionGroup.DatabaseInformation, null);
                    AddItemToOptionsList("Database Count", selectedNode.Nodes.Count.ToString(), OptionGroup.DatabaseInformation, null);
                    listOptions.EndUpdate();
                    break;
                case 1:  //Database
                    ConfigurationSettings _Settings = selectedNode.Tag as ConfigurationSettings;
                    
                    if (_Settings != null)
                    {
                        listOptions.ShowGroups = toolStripMenuItemShowCategories.Checked;
                        listOptions.Tag = _Settings;
                        PopulateOptionsList();
                    }

                    break;
            }
        }

        private void PopulateOptionsList()
        {
            imageDataError.Visible = labelDataError.Visible = false;

            ConfigurationSettings settings = listOptions.Tag as ConfigurationSettings;

            if (settings == null)
            {
                labelDataError.Text = "There was a problem populating the list";
                imageDataError.Visible = labelDataError.Visible = true;
                return;
            }

            listOptions.BeginUpdate();
            listOptions.Items.Clear();

            if (settings.DataException != null)
            {
                listOptions.EndUpdate();
                labelDataError.Text = Helpers.GetCombinedExceptionText(settings.DataException);
                imageDataError.Visible = labelDataError.Visible = true;
                return;
            }

            AddItemToOptionsList("Server Name", settings.ServerName, OptionGroup.DatabaseInformation, null);
            AddItemToOptionsList("Server Version", settings.ServerVersion, OptionGroup.DatabaseInformation, null);
            AddItemToOptionsList("Database Name", settings.DatabaseName, OptionGroup.DatabaseInformation, null);
            AddItemToOptionsList("Database Owner", settings.DatabaseOwner, OptionGroup.DatabaseInformation, null);
            AddItemToOptionsList("Date Created", settings.DateCreated.ToShortDateString(), OptionGroup.DatabaseInformation, null);
            AddItemToOptionsList("Collation", settings.Collation, OptionGroup.DatabaseInformation, null);
            AddItemToOptionsList("Database Size", Helpers.StrFormatByteSize((ulong)(settings.Size * 1024 * 1024)), OptionGroup.DatabaseInformation, null);
            AddItemToOptionsList("Number of Users", settings.NumberOfUsers.ToString(), OptionGroup.DatabaseInformation, null);
            AddItemToOptionsList("Database State", settings.State, OptionGroup.DatabaseInformation, null);
            AddItemToOptionsList("Compatibility Level", settings.CompatibilityLevel, OptionGroup.DatabaseInformation, null);
            AddItemToOptionsList("System Database", settings.IsSystemDatabase.ToString(), OptionGroup.DatabaseInformation, null);

            AddItemToOptionsList(settings.AutoClose);
            AddItemToOptionsList(settings.AutoCreateStatistics);
            AddItemToOptionsList(settings.AutoUpdateStatistics);
            AddItemToOptionsList(settings.AutoUpdateStatisticsAsync);
            AddItemToOptionsList(settings.AutoShrink);
            AddItemToOptionsList(settings.CursorCloseOnCommit);
            AddItemToOptionsList(settings.CursorDefaultScope);
            AddItemToOptionsList(settings.DataAccess);
            AddItemToOptionsList(settings.RestrictAccess);
            AddItemToOptionsList(settings.DateCorrelationOptimizationEnabled);
            AddItemToOptionsList(settings.DatabaseChaining);
            AddItemToOptionsList(settings.IsTrustWorthy);
            AddItemToOptionsList(settings.Parameterization);
            AddItemToOptionsList(settings.Recovery);
            AddItemToOptionsList(settings.PageVerifyMode);
            AddItemToOptionsList(settings.TornPageDetection);
            AddItemToOptionsList(settings.EnableBroker);
            AddItemToOptionsList(settings.AllowSnapshotIsolation);
            //SQLADMI-350.
            AddItemToOptionsList(settings.ReadCommittedSnapshot);
            AddItemToOptionsList(settings.AnsiNullDefault);
            AddItemToOptionsList(settings.AnsiNullsEnabled);
            AddItemToOptionsList(settings.AnsiPaddingEnabled);
            AddItemToOptionsList(settings.AnsiWarningsEnabled);
            AddItemToOptionsList(settings.ArithmeticAbortEnabled);
            AddItemToOptionsList(settings.ConcatenatedNullYieldsNull);
            AddItemToOptionsList(settings.QuotedIdentifiersEnabled);
            AddItemToOptionsList(settings.NumericRoundAbort);
            AddItemToOptionsList(settings.RecursiveTriggersEnabled);
            listOptions.Tag = settings;

            listOptions.EndUpdate();
        }

        private void AddItemToOptionsList(ConfigurationData data)
        {
            AddItemToOptionsList(data.Name, data.Value, data.Group, data);
        }

        private void AddItemToOptionsList(string name, string value, OptionGroup group, ConfigurationData tag)
        {
            if (string.IsNullOrEmpty(value)) return;

            ListViewItem _Item = new ListViewItem(new string[] { name, value });
            _Item.Group = listOptions.Groups[(int)group];
            _Item.Tag = tag;
            listOptions.Items.Add(_Item);
        }

        /// <summary>
        /// Edit the selected value
        /// </summary>
        private void listOptions_DoubleClick(object sender, EventArgs e)
        {
            EditOption();
        }

        private void EditOption()
        {
            if (listOptions.SelectedItems.Count != 1) return;

            ConfigurationData _Configuration = listOptions.SelectedItems[0].Tag as ConfigurationData;

            if (_Configuration == null || string.IsNullOrEmpty(_Configuration.Value))
            {
                Messaging.ShowInformation("Selected option is not editable");
                return;
            }

            Form_EditConfiguration _EditForm = new Form_EditConfiguration(_Configuration.Copy());

            if (_EditForm.ShowDialog() != DialogResult.OK) return;

            if (!_EditForm.Data.IsDirty) return;

            ConfigurationSettings _Settings = listOptions.Tag as ConfigurationSettings;

            if (_Settings == null)
            {
                Messaging.ShowWarning("The selected database could not be determined");
                return;
            }

            try
            {
                ConfigurationChangeResults _Results = DatabaseConfigurationHelper.UpdateDatabaseConfiguration(_Settings.Server, _Settings.DatabaseName, _EditForm.Data);
                
                if (!_Results.IsSuccessful)
                {
                    Messaging.ShowException("Update Configuration", _Results.ChangeException);
                    return;
                }

                _Configuration.Value = _EditForm.Data.Value;
                PopulateOptionsList();
                
                if (_ComparedDatabaseList.ContainsKey(_Settings.Key))
                {
                    AddDataToComparisonReport(_Settings);
                }
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Update Configuration", exc);
            }
        }

        #region toolstrip events

        private void toolStripMenuItemShowCategories_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItemShowCategories.Checked)
            {
                listOptions.ShowGroups = false;
                listOptions.Sorting = SortOrder.Ascending;
                listOptions.Sort();
                toolStripMenuItemShowCategories.Checked = false;
            }
            else
            {
                listOptions.ShowGroups = true;
                listOptions.Sorting = SortOrder.None;
                PopulateOptionsList();
                toolStripMenuItemShowCategories.Checked = true;
            }
        }

        private void toolStripMenuItemEditOption_Click(object sender, EventArgs e)
        {
            EditOption();
        }

        #endregion

        #region treeResults events

        private void treeResults_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            bool _EnableButtons = true;
            ContextMenuItemAddServerToComparison.Enabled = true;

            TreeNode _SelectedNode = treeResults.GetNodeAt(e.X, e.Y);

            if (_SelectedNode == null)
            {
                ContextMenuItemAddServerToComparison.Enabled = _EnableButtons = false;
            }
            else
            {
                treeResults.SelectedNode = _SelectedNode;

                if (treeResults.SelectedNode.Level == 0)
                {
                    _EnableButtons = false;
                }
                else
                {
                    ConfigurationSettings _Settings = _SelectedNode.Tag as ConfigurationSettings;

                    if (_Settings != null && _Settings.DataException != null)
                    {
                        _EnableButtons = false;
                    }
                }
            }

            ContextMenuItemAddDatabaseToComparison.Enabled = contextMenuItemSetAsBaseline.Enabled =
                contextMenuItemSaveSnapshot.Enabled = _EnableButtons;
        }

        private void treeResults_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PopulateListOnItemSelect(e.Node);
        }

        #endregion

        #region JobPool

        void JobPool_ServerTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            if (e.Status == TaskStatus.Success)
            {
                AddServerToTree(new KeyValuePair<string, List<ConfigurationSettings>>(e.Server.Name, (List<ConfigurationSettings>)e.Resultset));
            }
            else
            {
                _ErrorReports.Add(e.Server.Name, e.ErrorMessage);
            }
        }

        void JobPool_TaskComplete(object sender, JobExecutionEventArgs e)
        {
            //PopulateTree();
            ToolStripMenuItemAddAllServersToComparison.Enabled = 
                ToolStripMenuItemAddDatabaseToComparison.Enabled =
                ToolStripMenuItemAddServerToComparison.Enabled = 
                ToolStripMenuItemSetServerAsBaseline.Enabled = 
                printToolStripMenuItem.Enabled =
                buttonConfigurationAddToComparison.Enabled =
                buttonConfigurationSaveSnapshot.Enabled =
                buttonConfigurationSetAsBaseline.Enabled =
                buttonConfigurationRefresh.Enabled =  true;
                
            ProgressBar_Close();
            
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

        #endregion

        #region Icon toolbar events

        private void buttonConfigurationAddToComparison_Click(object sender, EventArgs e)
        {
            AddToComparison();
        }

        private void buttonSaveDatabaseSnapshot_Click(object sender, EventArgs e)
        {
            SaveSnapshot((ConfigurationSettings)((ButtonItem)sender).Tag);
        }

        private void buttonSaveAllDatabases_Click(object sender, EventArgs e)
        {
            SaveSnapshotAllConfiguration();
        }

        private void buttonConfigurationSetAsBaseline_Click(object sender, EventArgs e)
        {
            SetDatabaseAsBaseline((ConfigurationSettings)((ButtonItem)sender).Tag);
        }

        private void buttonConfigurationRefresh_Click(object sender, EventArgs e)
        {
            List<ServerInformation> _ServersToRefresh = new List<ServerInformation>();

            foreach (KeyValuePair<string, List<ConfigurationSettings>> _Server in _ServerConfigurations)
            {
                foreach (ConfigurationSettings _Settings in _Server.Value)
                {
                    if (!_ServersToRefresh.Contains(_Settings.Server))
                    {
                        _ServersToRefresh.Add(_Settings.Server);
                    }
                }
            }

            LoadConfigurationData(_ServersToRefresh);
        }

        #endregion

        #endregion

        #region Comparison

        private void AddDataToComparisonReport(ConfigurationSettings data)
        {
            if (data == null || data.DataException != null) return;

            if (listComparison.Columns.Count == (int)ComparisonListColumn.Baseline)
            {
                _BaselineConfiguration = data;
                AddBaselineToComparison();
            }

            if (_ComparedDatabaseList.ContainsKey(data.Key))
            {
                ReplaceComparisonColumn(data);
            }
            else
            {
                AddNewComparisonColumn(listComparison.Columns.Count, ProductConstants.ComparisonColumnWidth, data);
            }

            Helpers.ApplyAlternateColorsToListView(listComparison, true, (int)ComparisonListColumn.Baseline);
            ToggleComparisonDifferences(_ShowDifferences);
            menuSaveSnapshot.Enabled = 
               ToolStripMenuItemRefreshComparison.Enabled = 
               ToolStripMenuItemClearComparison.Enabled =
               menuExport.Enabled = 
               buttonCopyToClipboard.Enabled = 
               buttonRefresh.Enabled = 
               buttonClear.Enabled = 
               printToolStripMenuItem.Enabled = true;

            labelNoDatabasesToCompare.Visible = false;

            buttonHighlightDifferences.Enabled = (listComparison.Columns.Count > (int)ComparisonListColumn.Baseline + 1);

            if (data.Source == DataSource.LiveData && !buttonSave.SubItems.Contains(data.Key))
            {
                ButtonItem _SaveSubItem = new ButtonItem(data.Key, data.Key);
                _SaveSubItem.Click += buttonSaveServer_Click;
                buttonSave.SubItems.Add(_SaveSubItem);
                buttonSave.Enabled = true;
            }
        }

        /// <summary>
        /// Adds baseline configurations to comparison report
        /// </summary>
        private void AddBaselineToComparison()
        {
            if (_BaselineConfiguration == null)
            {
                labelBaselineWarning.Visible = true;
                return;
            }
            
            if (listComparison.Columns[ProductConstants.ComparisonColumnBaseline] == null)
            {
                AddNewComparisonColumn((int)ComparisonListColumn.Baseline, ProductConstants.ComparisonColumnWidth, _BaselineConfiguration);
            }
            else
            {
                ReplaceComparisonColumn(_BaselineConfiguration);
            }

            labelBaselineWarning.Visible = false;
            buttonFixDifferences.Enabled = buttonFixDifferencesWithBaseline.Enabled = true;

            if (_BaselineConfiguration.Source == DataSource.LiveData && !buttonSave.SubItems.Contains(_BaselineConfiguration.Key))
            {
                ButtonItem _SaveSubItem = new ButtonItem(_BaselineConfiguration.Key, _BaselineConfiguration.Key);
                _SaveSubItem.Click += buttonSaveServer_Click;
                buttonSave.SubItems.Insert(1, _SaveSubItem);
                buttonSave.Enabled = true;
            }
        }

        private void AddNewComparisonColumn(int index, int colWidth, ConfigurationSettings settings)
        {
            int _ImageIndex = -1;
            
            if (settings == _BaselineConfiguration)
            {
                _ImageIndex = (int)IconImage.DatabaseBaseline;
            }
            else if (settings.Source == DataSource.Snapshot)
            {
                _ImageIndex = (int)IconImage.DatabaseSnapshot;
            }

            listComparison.Columns.Insert(index, settings.Key, settings.DatabaseName, colWidth, HorizontalAlignment.Center, _ImageIndex);

            foreach (ListViewItem _Item in listComparison.Items)
            {
                _Item.SubItems.Insert(index, new ListViewItem.ListViewSubItem());
            }

            listComparison.Columns[index].Tag = settings;
            AddConfigurationToComparisionList(settings, index);
            _ComparedDatabaseList.Add(settings.Key, settings);
        }

        private void ReplaceComparisonColumn(ConfigurationSettings settings)
        {
            if (listComparison.Columns[settings.Key] == null)
            {
                _ComparedDatabaseList.Remove(settings.Key);
                AddDataToComparisonReport(settings);
                return;
            }
            else
            {
                listComparison.Columns[settings.Key].Tag = settings;
                AddConfigurationToComparisionList(settings, listComparison.Columns[settings.Key].Index);
                _ComparedDatabaseList[settings.Key] = settings;
            }
        }

        private void AddConfigurationToComparisionList(ConfigurationSettings settings, int column)
        {
            listComparison.BeginUpdate();

            AddSubItemToComparisonList("Server Name", settings.ServerName, column, OptionGroup.DatabaseInformation, null);
            
            if (string.IsNullOrEmpty(settings.ServerVersion))
            {
                settings.ServerVersion = string.Empty;
            }

            AddSubItemToComparisonList("Server Version", settings.ServerVersion.Replace("SQL Server", string.Empty), column, OptionGroup.DatabaseInformation, null);
            AddSubItemToComparisonList("Database Name", settings.DatabaseName, column, OptionGroup.DatabaseInformation, null);
            AddSubItemToComparisonList(ProductConstants.ConfigurationValueCompatibility, settings.CompatibilityLevel, column, OptionGroup.DatabaseInformation, settings.CompatibilityLevel);
            AddSubItemToComparisonList(ProductConstants.ConfigurationValueCollation, settings.Collation, column, OptionGroup.DatabaseInformation, settings.Collation);

            string _Source = string.Empty;
            switch (settings.Source)
            {
                case DataSource.LiveData:
                    _Source = "Live Data";
                    break;
                case DataSource.Snapshot:
                    _Source = "Snapshot";
                    break;
            }

            AddSubItemToComparisonList("Data Source", _Source, column, OptionGroup.DatabaseInformation, null);
            AddSubItemToComparisonList("Date Captured", settings.DateCaptured.ToString(), column, OptionGroup.DatabaseInformation, null);
            
            foreach (PropertyInfo _Property in settings.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                ConfigurationData _Data = _Property.GetValue(settings, null) as ConfigurationData;
                if (_Data != null)
                {
                    AddSubItemToComparisonList(_Data.Name, _Data.Value, column, _Data.Group, _Data);
                }
            }

            listComparison.EndUpdate();


            if (settings.Source == DataSource.Snapshot && !buttonFixDifferencesWithSnapshot.SubItems.Contains(settings.Key))
            {
                ButtonItem _SnapshotFix = new ButtonItem(settings.Key, settings.ToString());
                _SnapshotFix.Click += new EventHandler(buttonFixDifferencesWithSnapshot_Click);
                _SnapshotFix.Tag = settings;
                buttonFixDifferencesWithSnapshot.SubItems.Add(_SnapshotFix);
                buttonFixDifferences.Enabled = buttonFixDifferencesWithSnapshot.Enabled = true;
            }
        }

        private void AddSubItemToComparisonList(string name, string value, int column, OptionGroup group, object tag)
        {
            if (!listComparison.Items.ContainsKey(name))
            {
                ListViewItem _NewItem = listComparison.Items.Add(name, name, -1);
                _NewItem.Group = listComparison.Groups[(int)group];
                
                for (int i = 1; i <= column; i++)
                {
                    _NewItem.SubItems.Insert(i, new ListViewItem.ListViewSubItem());
                }
            }

            listComparison.Items[name].SubItems[column].Text = string.IsNullOrEmpty(value) && tag != null ? ProductConstants.OptionNotAvailableString : value;
            listComparison.Items[name].SubItems[column].Tag = tag;
        }

        private void ToggleComparisonDifferences(bool showDifferences)
        {
            _DifferencesList.Clear();
            _CollationDifferencesFound = _CompatibilityDifferencesFound = false;

            for (int _Row = 0; _Row < listComparison.Items.Count; _Row++)
            {
                ListViewItem _Item = listComparison.Items[_Row];

                if (listComparison.Columns.Count > (int)ComparisonListColumn.Baseline + 1)
                {
                    string _BaseValue = _Item.SubItems[(int)ComparisonListColumn.Baseline].Text;
                    
                    for (int i = (int)ComparisonListColumn.Baseline + 1; i < _Item.SubItems.Count; i++)
                    {
                        if (_Item.SubItems[i].Tag != null && _Item.SubItems[(int)ComparisonListColumn.Baseline].Tag != null &&
                            _BaseValue != _Item.SubItems[i].Text && _BaseValue != ProductConstants.OptionNotAvailableString &&
                            _Item.SubItems[i].Text != ProductConstants.OptionNotAvailableString)
                        {
                            if (_Item.Text == ProductConstants.ConfigurationValueCollation)
                            {
                                _CollationDifferencesFound = true;
                            }
                            if (_Item.Text == ProductConstants.ConfigurationValueCompatibility)
                            {
                                _CompatibilityDifferencesFound = true;
                            }

                            if (!_DifferencesList.Contains(_Item.Name))
                            {
                                _DifferencesList.Add(_Item.Name);
                            }

                            if (showDifferences)
                            {
                                _Item.SubItems[i].BackColor = Color.Yellow;
                            }
                        }
                    }
                }
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

        private void ClearComparison(object sender, EventArgs e)
        {
            ClearComparisonList();
        }

        private void ClearComparisonList()
        {
            for (int i = listComparison.Columns.Count - 1; i >= (int)ComparisonListColumn.Baseline; i--)
            {
                listComparison.Columns.RemoveAt(i);
            }

            listComparison.Items.Clear();
            _ComparedDatabaseList.Clear();
            _DifferencesList.Clear();
            buttonFixDifferencesWithSnapshot.SubItems.Clear();
            _BaselineConfiguration = null;
            labelBaselineWarning.Visible = 
                menuExport.Enabled = 
                ToolStripMenuItemRefreshComparison.Enabled = 
                ToolStripMenuItemClearComparison.Enabled =
                buttonFixDifferences.Enabled = 
                buttonHighlightDifferences.Enabled = 
                buttonCopyToClipboard.Enabled =
                buttonRefresh.Enabled =
                buttonClear.Enabled = 
                menuSaveSnapshot.Enabled =
                printToolStripMenuItem.Enabled = false;

            labelNoDatabasesToCompare.Visible = true;
            ClearSnapshotList();
        }

        private void RefreshComparisonData()
        {
            List<ServerInformation> _ServersToRefresh = new List<ServerInformation>();
            
            foreach (ConfigurationSettings _Settings in _ComparedDatabaseList.Values)
            {
                if (!_ServersToRefresh.Contains(_Settings.Server) && _Settings.Source == DataSource.LiveData)
                {
                    _ServersToRefresh.Add(_Settings.Server);
                }
            }

            LoadConfigurationData(_ServersToRefresh);
        }

        private void buttonFixDifferencesWithBaseline_Click(object sender, EventArgs e)
        {
            if (_BaselineConfiguration == null)
            {
                Messaging.ShowError("No baseline settings found");
            }
            else
            {
                FixDifferences(_BaselineConfiguration);
            }
        }

        private void buttonFixDifferencesWithSnapshot_Click(object sender, EventArgs e)
        {
            ConfigurationSettings _Settings = ((ButtonItem)sender).Tag as ConfigurationSettings;
            if (_Settings == null)
            {
                Messaging.ShowError("Snapshot settings not found");
            }
            else
            {
                FixDifferences(_Settings);
            }
        }

        private void FixDifferences(ConfigurationSettings settingsToApply)
        {
            string _OptionChangeList = string.Empty;

            if (settingsToApply != null)
            {
                Cursor = Cursors.WaitCursor;
                Dictionary<ConfigurationSettings, List<ConfigurationData>> _SettingsToChange = new Dictionary<ConfigurationSettings, List<ConfigurationData>>();
                
                foreach (ListViewItem _Item in listComparison.Items)
                {
                    
                    bool _AddedToPrompt = false;
                    Dictionary<ConfigurationSettings, ConfigurationData> _SingleSettingToChange = RetrieveChangeRequestFromListView(_Item, settingsToApply.GetValueByName(_Item.Name));
                    
                    foreach (KeyValuePair<ConfigurationSettings, ConfigurationData> _ChangeItem in _SingleSettingToChange)
                    {
                        if (!_SettingsToChange.ContainsKey(_ChangeItem.Key))
                        {
                            _SettingsToChange.Add(_ChangeItem.Key, new List<ConfigurationData>());
                        }
                        
                        _SettingsToChange[_ChangeItem.Key].Add(_ChangeItem.Value);
                        
                        if (!_AddedToPrompt)
                        {
                            _OptionChangeList += "\t" + _ChangeItem.Value.Name + Environment.NewLine;
                            _AddedToPrompt = true;
                        }
                    }
                }

                if (_SettingsToChange.Count > 0)
                {
                    Form_BulkEdit _BulkEditForm = new Form_BulkEdit(settingsToApply.Key, _SettingsToChange, _CollationDifferencesFound, _CompatibilityDifferencesFound);
                    if(_BulkEditForm.ShowDialog() == DialogResult.OK)
                    {
                        _SettingsToChange = _BulkEditForm.SelectedSettings;
                        Form_ConfigurationChangeResult _ChangeResults = new Form_ConfigurationChangeResult();
                        
                        foreach (KeyValuePair<ConfigurationSettings, List<ConfigurationData>> _DatabaseChanges in _SettingsToChange)
                        {
                            foreach (ConfigurationData _ChangeData in _DatabaseChanges.Value)
                            {
                                _ChangeResults.AddResult(DatabaseConfigurationHelper.UpdateDatabaseConfiguration(_DatabaseChanges.Key.Server, _DatabaseChanges.Key.DatabaseName, _ChangeData));
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
                    string _Message = string.Empty;
                    if (_CompatibilityDifferencesFound || _CollationDifferencesFound)
                    {
                        _Message = ProductConstants.InformationReadOnlyConflictsFound + "(";
                        if (_CollationDifferencesFound)
                        {
                            _Message += ProductConstants.ConfigurationValueCollation;
                        }
                        if (_CompatibilityDifferencesFound)
                        {
                            if (_CollationDifferencesFound)
                            {
                                _Message += ", ";
                            }
                            _Message += ProductConstants.ConfigurationValueCompatibility + ").";
                        }
                        _Message += Environment.NewLine + Environment.NewLine;
                    }
                    
                    _Message += ProductConstants.InformationAllSettingsAreEqual;
                    Messaging.ShowInformation(_Message);
                }
            }
            else
            {
                Messaging.ShowInformation(ProductConstants.InformationNoBaselineFound);
            }
        }

        private void ApplySingleSettingToDatabases(Dictionary<ConfigurationSettings, ConfigurationData> _SettingsToChange)
        {
            if (_SettingsToChange.Count > 0)
            {
                Form_ConfigurationChangeResult _ChangeResults = new Form_ConfigurationChangeResult();
                
                foreach (KeyValuePair<ConfigurationSettings, ConfigurationData> _DatabaseChanges in _SettingsToChange)
                {
                    _ChangeResults.AddResult(DatabaseConfigurationHelper.UpdateDatabaseConfiguration(_DatabaseChanges.Key.Server, _DatabaseChanges.Key.DatabaseName, _DatabaseChanges.Value));
                }

                _ChangeResults.ShowDialog();
                RefreshComparisonData();
            }
            else
            {
                Cursor.Current = Cursors.Default;
                Messaging.ShowInformation(ProductConstants.InformationAllComparedRowsAreEqual);
            }
        }

        /// <summary>
        /// Retrieves change data from a row in the comparison report.
        /// </summary>
        private Dictionary<ConfigurationSettings, ConfigurationData> RetrieveChangeRequestFromListView(ListViewItem item)
        {
            ConfigurationData _BaselineData = item.SubItems[(int)ComparisonListColumn.Baseline].Tag as ConfigurationData;
            return RetrieveChangeRequestFromListView(item, _BaselineData);
        }

        private Dictionary<ConfigurationSettings, ConfigurationData> RetrieveChangeRequestFromListView(ListViewItem item, ConfigurationData data)
        {
            Dictionary<ConfigurationSettings, ConfigurationData> _SettingsToChange = new Dictionary<ConfigurationSettings, ConfigurationData>();

            if (_DifferencesList.Contains(item.Name))
            {
                if (data != null && !string.IsNullOrEmpty(data.Value))
                {
                    for (int i = 1; i < item.SubItems.Count; i++)
                    {
                        ConfigurationSettings _Settings = listComparison.Columns[i].Tag as ConfigurationSettings;
                        if (_Settings != null && _Settings.Source == DataSource.LiveData)
                        {
                            ConfigurationData _DatabaseData = item.SubItems[i].Tag as ConfigurationData;
                            if (_DatabaseData != null && _DatabaseData.Value != data.Value && !string.IsNullOrEmpty(_DatabaseData.Value) && _DatabaseData != data)
                            {
                                ConfigurationData _DataToChange = _DatabaseData.Copy();
                                _DataToChange.Value = data.Value;
                                _SettingsToChange.Add(_Settings, _DataToChange);
                            }
                        }
                    }
                }
            }

            return _SettingsToChange;

        }

        private void RemoveSettingsFromComparison(ConfigurationSettings settings)
        {
            RemoveSettingsFromComparison(settings, true);
        }

        private void RemoveSettingsFromComparison(ConfigurationSettings settings, bool setNewBaseline)
        {
            if (settings == null) return;
            
            _ComparedDatabaseList.Remove(settings.Key);
            
            if (listComparison.Columns.ContainsKey(settings.Key))
            {
                int _Column = listComparison.Columns[settings.Key].Index;
                
                foreach (ListViewItem _Item in listComparison.Items)
                {
                    _Item.SubItems.RemoveAt(_Column);
                }

                listComparison.Columns.RemoveAt(_Column);
            }

            if (settings == _BaselineConfiguration)
            {
                _BaselineConfiguration = null;
                labelBaselineWarning.Visible = true;

                if (listComparison.Columns.Count > (int)ComparisonListColumn.Baseline  && setNewBaseline)
                {
                    ConfigurationSettings _NewBaseline = listComparison.Columns[(int)ComparisonListColumn.Baseline].Tag as ConfigurationSettings;
                    if (_NewBaseline != null)
                    {
                        SetDatabaseAsBaseline(_NewBaseline);
                    }
                }
            }

            if (buttonFixDifferencesWithSnapshot.SubItems.Contains(settings.Key))
            {
                buttonFixDifferencesWithSnapshot.SubItems.Remove(settings.Key);
                if (buttonFixDifferencesWithSnapshot.SubItems.Count == 0)
                {
                    buttonFixDifferencesWithSnapshot.Enabled = false;
                }
            }

            if (_BaselineConfiguration == null)
            {
                buttonFixDifferencesWithBaseline.Enabled = false;
            }

            if (!buttonFixDifferencesWithBaseline.Enabled && !buttonFixDifferencesWithSnapshot.Enabled)
            {
                buttonFixDifferences.Enabled = false;
            }

            ToggleComparisonDifferences(_ShowDifferences);

            menuExport.Enabled = 
                ToolStripMenuItemRefreshComparison.Enabled = 
                ToolStripMenuItemClearComparison.Enabled =
                buttonHighlightDifferences.Enabled = 
                buttonCopyToClipboard.Enabled = 
                buttonRefresh.Enabled =
                buttonClear.Enabled = 
                menuSaveSnapshot.Enabled =
                printToolStripMenuItem.Enabled = (listComparison.Columns.Count > 0);

            labelNoDatabasesToCompare.Visible = (listComparison.Columns.Count <= 1);

            if (buttonSave.SubItems.Contains(settings.Key))
            {
                buttonSave.SubItems.Remove(settings.Key);
                
                if (buttonSave.SubItems.Count <= 1)
                {
                    buttonSave.Enabled = false;
                }
            }
        }

        private void buttonAddToComparison_Click(object sender, EventArgs e)
        {
            AddToComparison();
        }

        private void AddToComparison()
        {
            Form_AddToComparison _AddComparisonForm = new Form_AddToComparison(_ServerConfigurations, _ComparedDatabaseList);

            if (_AddComparisonForm.ShowDialog() == DialogResult.OK)
            {
                if (ExcessiveCompareCountCheck(_AddComparisonForm.SelectedDatabaseCount))
                {
                    foreach (KeyValuePair<string, List<string>> _SelectedServer in _AddComparisonForm.SelectedDatabases)
                    {
                        foreach (string _Database in _SelectedServer.Value)
                        {
                            AddDataToComparisonReport(_ServerConfigurations[_SelectedServer.Key].Find(delegate(ConfigurationSettings settings) { return settings.Key == _Database; }));
                        }
                    }
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshComparisonData();
        }

        #region toolStrip events

        private void ToolStripMenuItemAddDatabaseToComparison_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem _MenuItem = sender as ToolStripMenuItem;
            
            if (_MenuItem == null) return;
            
            ConfigurationSettings _Settings = _MenuItem.Tag as ConfigurationSettings;
            
            if (_Settings != null)
            {
                if (ExcessiveCompareCountCheck(1))
                {
                    AddDataToComparisonReport(_Settings);
                }
            }
        }

        private void ToolStripMenuItemAddServerToComparison_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem _MenuItem = sender as ToolStripMenuItem;
            
            if (_MenuItem == null) return;
            
            Cursor.Current = Cursors.WaitCursor;

            if (ExcessiveCompareCountCheck(_ServerConfigurations.Count))
            {
                foreach (ConfigurationSettings _DatabaseSettings in _ServerConfigurations[_MenuItem.Name])
                {
                    AddDataToComparisonReport(_DatabaseSettings);
                }
            }
                
            Cursor.Current = Cursors.Default;
        }

        private void toolStripMenuItemSetAsBaseline_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem _MenuItem = sender as ToolStripMenuItem;
            
            if (_MenuItem == null) return;
            
            Cursor.Current = Cursors.WaitCursor;

            ConfigurationSettings _Settings = _MenuItem.Tag as ConfigurationSettings;
            
            if (_Settings != null)
            {
                SetDatabaseAsBaseline(_Settings);
            }

            Cursor.Current = Cursors.Default;
        }

        private void ToolStripMenuItemRefreshComparison_Click(object sender, EventArgs e)
        {
            RefreshComparisonData();
        }

        private bool ExcessiveCompareCountCheck(int additional)
        {
            bool _Proceed = true;
            if (_ComparedDatabaseList.Count + additional >= ProductConstants.TooManyComparedDatabasesCount && !_TooManyDatabasesWarningDisplayed)
            {
                _TooManyDatabasesWarningDisplayed = _Proceed = (Messaging.ShowConfirmation(string.Format(ProductConstants.WarningTooManyDatabases, ProductConstants.TooManyComparedDatabasesCount)) == DialogResult.Yes);
            }
            return _Proceed;
        }

        #endregion

        #region ContextMenu events

        private void ContextMenuItemAddDatabaseToComparison_Click(object sender, EventArgs e)
        {
            if (treeResults.SelectedNode == null)
            {
                Messaging.ShowWarning("You must select an item on the list");
                return;
            }

            ConfigurationSettings _Settings = treeResults.SelectedNode.Tag as ConfigurationSettings;
            
            if (_Settings != null)
            {
                if (ExcessiveCompareCountCheck(1))
                {
                    AddDataToComparisonReport(_Settings);
                }
            }
        }

        private void ContextMenuItemAddServerToComparison_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (treeResults.SelectedNode == null)
            {
                Messaging.ShowWarning("You must select an item on the list");
                return;
            }

            switch (treeResults.SelectedNode.Level)
            {
                case 0: //server
                    if (ExcessiveCompareCountCheck(_ServerConfigurations[treeResults.SelectedNode.Name].Count))
                    {
                        foreach (ConfigurationSettings _DatabaseSettings in _ServerConfigurations[treeResults.SelectedNode.Name])
                        {
                            AddDataToComparisonReport(_DatabaseSettings);
                        }
                    }
                    break;
                case 1: //database
                    if (ExcessiveCompareCountCheck(_ServerConfigurations[treeResults.SelectedNode.Parent.Name].Count))
                    {
                        foreach (ConfigurationSettings _DatabaseSettings in _ServerConfigurations[treeResults.SelectedNode.Parent.Name])
                        {
                            AddDataToComparisonReport(_DatabaseSettings);
                        }
                    }
                    break;
            }

            Cursor.Current = Cursors.Default;
        }

        private void contextMenuItemAddAllServersToComparison_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            int _DatabaseCount = 0;
            foreach (KeyValuePair<string, List<ConfigurationSettings>> _ServerConfigurationCount in _ServerConfigurations)
            {
                _DatabaseCount += _ServerConfigurationCount.Value.Count;
            }

            if (ExcessiveCompareCountCheck(_DatabaseCount))
            {
                foreach (KeyValuePair<string, List<ConfigurationSettings>> _ServerConfiguration in _ServerConfigurations)
                {
                    foreach (ConfigurationSettings _DatabaseSettings in _ServerConfiguration.Value)
                    {
                        AddDataToComparisonReport(_DatabaseSettings);
                    }
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void contextMenuItemSetAsBaseline_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            if (treeResults.SelectedNode == null || treeResults.SelectedNode.Level == 0)
            {
                Messaging.ShowWarning("You must select a database from the list");
                return;
            }

            ConfigurationSettings _Settings = treeResults.SelectedNode.Tag as ConfigurationSettings;

            SetDatabaseAsBaseline(_Settings);

            Cursor.Current = Cursors.Default;
        }

        private void contextMenuItemSaveSnapshot_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (treeResults.SelectedNode == null || treeResults.SelectedNode.Level == 0)
            {
                Messaging.ShowWarning("You must select a database from the list");
                return;
            }

            ConfigurationSettings _Settings = treeResults.SelectedNode.Tag as ConfigurationSettings;
            if (_Settings != null)
            {
                SaveSnapshot(_Settings);
            }

            Cursor.Current = Cursors.Default;
        }

        private void ContextMenuItemApplySingleSettingToServers_Click(object sender, EventArgs e)
        {
            if (listComparison.SelectedItems.Count != 1) return;
            
            Cursor.Current = Cursors.WaitCursor;
            Dictionary<ConfigurationSettings, ConfigurationData> _SettingsToChange = RetrieveChangeRequestFromListView(listComparison.SelectedItems[0]);

            ApplySingleSettingToDatabases(_SettingsToChange);
            Cursor.Current = Cursors.Default;
        }

        private void ContextMenuItemHeaderSetDatabaseAsBaseline_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ConfigurationSettings _Settings = contextComparisonHeader.Tag as ConfigurationSettings;
            
            if (_Settings != null)
            {
                SetDatabaseAsBaseline(_Settings);
            }

            Cursor.Current = Cursors.Default;
        }

        private void ContextMenuItemHeaderRemoveDatabase_Click(object sender, EventArgs e)
        {
            ConfigurationSettings _Settings = contextComparisonHeader.Tag as ConfigurationSettings;
            RemoveSettingsFromComparison(_Settings);
        }

        private void ContextMenuItemBulkUpdateSingleSetting_Click(object sender, EventArgs e)
        {
            if (listComparison.SelectedItems.Count != 1) return;
            
            ListViewItem _Item = listComparison.SelectedItems[0];

            ConfigurationData _Data = null;
            foreach (ListViewItem.ListViewSubItem _SubItem in _Item.SubItems)
            {
                _Data = _SubItem.Tag as ConfigurationData;
                
                if (_Data != null && _Data.ValidValues != null)
                {
                    _Data = _Data.Copy();
                    break;
                }
            }

            if (_Data != null && _Data.ValidValues != null)
            {
                List<string> _ServersToList = new List<string>();
                
                foreach (ConfigurationSettings _Settings in _ComparedDatabaseList.Values)
                {
                    if (_Settings.Source == DataSource.LiveData)
                    {
                        _ServersToList.Add(_Settings.Key);
                    }
                }

                Form_EditConfiguration _EditForm = new Form_EditConfiguration(_Data, _ServersToList);

                if (_EditForm.ShowDialog() == DialogResult.OK)
                {
                    _Data = _EditForm.Data;


                    Dictionary<ConfigurationSettings, ConfigurationData> _SettingsToChange = new Dictionary<ConfigurationSettings, ConfigurationData>();
                    for (int i = 0; i < _Item.SubItems.Count; i++)
                    {
                        ConfigurationSettings _Settings = listComparison.Columns[i].Tag as ConfigurationSettings;
                        if (_Settings != null && _Settings.Source == DataSource.LiveData && _EditForm.SelectedDatabases.Contains(_Settings.Key))
                        {
                            ConfigurationData _DatabaseData = _Item.SubItems[i].Tag as ConfigurationData;
                            if (_DatabaseData != null && _DatabaseData.Value != _Data.Value && !string.IsNullOrEmpty(_DatabaseData.Value))
                            {
                                ConfigurationData _DataToChange = _DatabaseData.Copy();
                                _DataToChange.Value = _Data.Value;
                                _SettingsToChange.Add(_Settings, _DataToChange);
                            }
                        }
                    }

                    ApplySingleSettingToDatabases(_SettingsToChange);
                }
            }
            else
            {
                Messaging.ShowWarning("The selected row has no updatable values");
            }
        }

        private void ContextMenuItemRefresh_Click(object sender, EventArgs e)
        {
            RefreshComparisonData();
        }

        #endregion

        #endregion

        #region Common
        /// <summary>
        /// Sets the specified configuration as baseline and updates the UI accordingly.
        /// </summary>
        /// <param name="settings"></param>
        private void SetDatabaseAsBaseline(ConfigurationSettings settings)
        {
            if (settings == null) return;
            
            ConfigurationSettings _OldBaseline = null;
            
            if (_BaselineConfiguration != null)
            {
                _OldBaseline = _BaselineConfiguration;
                RemoveSettingsFromComparison(_OldBaseline, false);
            }

            RemoveSettingsFromComparison(settings);
            _BaselineConfiguration = settings;

            AddBaselineToComparison();
            
            if (_OldBaseline != null)
            {
                AddDataToComparisonReport(_OldBaseline);
            }

            Helpers.ApplyAlternateColorsToListView(listComparison, true, (int)ComparisonListColumn.Baseline);
            ToggleComparisonDifferences(_ShowDifferences);
        }

        private void ServerSelection_TextChanged(object sender, EventArgs e)
        {
            buttonGetConfiguration.Enabled = (ServerSelection.Text != "");
        }

        #endregion

        #region Export

        private void menuExportAsCSV_Click(object sender, EventArgs e)
        {
            ExportToCSV.CopyListView(listComparison);
        }

        private void menuExportAsXML_Click(object sender, EventArgs e)
        {
            ExportToXML.CopyListView(listComparison, ProductConstants.CopyComparisonToXmlDataSetName, true);
        }

        /// <summary>
        /// Copies all values from the comparison tab to the clipboard.
        /// </summary>
        private void menuExportToClipboard_Click(object sender, EventArgs e)
        {
            ExportToClipboard.CopyListViewToTabbedFormat(ProductConstants.ClipboardHeader, listComparison, false, false);
        }

        /// <summary>
        /// Copies selected values to the clipboard.
        /// </summary>
        private void ContextMenuItemCopyItems_Click(object sender, EventArgs e)
        {
            ExportToClipboard.CopyListViewToTabbedFormat(ProductConstants.ClipboardHeader, listComparison, false, true);
        }

        /// <summary>
        /// Copies all settigs from a database to the clipboard.
        /// </summary>
        private void ContextMenuItemHeaderCopyToClipboard_Click(object sender, EventArgs e)
        {
            ConfigurationSettings _Settings = contextComparisonHeader.Tag as ConfigurationSettings;
            
            if (_Settings == null) return;
            
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

        private void ContextMenuItemHeaderSaveSnapshot_Click(object sender, EventArgs e)
        {
            ConfigurationSettings _Settings = contextComparisonHeader.Tag as ConfigurationSettings;
            
            if (_Settings != null)
            {
                SaveSnapshot(_Settings);
            }
        }

        #endregion

        #region Snapshot

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveSnapshot();
        }

        private void buttonSaveServer_Click(object sender, EventArgs e)
        {
            if (_ComparedDatabaseList.ContainsKey(((ButtonItem)sender).Text))
            {
                SaveSnapshot(_ComparedDatabaseList[((ButtonItem)sender).Text]);
            }
        }

        private void buttonOpenSnapshot_Click(object sender, EventArgs e)
        {
            LoadSnapshot();
        }

        /// <summary>
        /// Removes servers from Save snapshot button sub items.
        /// </summary>
        private void ClearSnapshotList()
        {
            for (int i = buttonSave.SubItems.Count - 1; i > 0; i--)
            {
                buttonSave.SubItems.Remove(i);
            }

            buttonSave.Enabled = false;
        }

        /// <summary>
        /// Saves snapshot of a single server
        /// </summary>
        private void SaveSnapshot(ConfigurationSettings settings)
        {
           string filename = settings.Key;

           filename = filename.Replace('\\', '-');
           filename = filename.Replace('/', '-');
           filename = filename.Replace(':', '-');
           filename = filename.Replace('*', '-');
           filename = filename.Replace('?', '-');
           filename = filename.Replace('\"', '-');
           filename = filename.Replace('<', '-');
           filename = filename.Replace('>', '-');
           filename = filename.Replace('|', '-');

            // create default name
            SaveFileDialog _FileDialog = new SaveFileDialog();
            _FileDialog.Title = "Save Snapshot As";
            _FileDialog.AddExtension = true;
            _FileDialog.CheckPathExists = true;
            _FileDialog.DefaultExt = "xml";
            _FileDialog.FileName = string.Format("{0}_{1}_{2}.xml",
                                                  filename,
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
        /// Saves snapshot of a single server to the specified file path.
        /// </summary>
        private void SaveSnapshot(ConfigurationSettings settings, string fileName, bool checkFileExists)
        {
            try
            {
                if (settings.Source == DataSource.LiveData)
                {
                    if (checkFileExists && File.Exists(fileName) && Messaging.ShowConfirmation(string.Format("The file\n {0} \n already exists, do you want to override it?", fileName)) == DialogResult.No)
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
                    Messaging.ShowError("You can only save Snapshots for live data");
                }
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Save Snapshot", exc);
            }
        }

        private void SaveSnapshot()
        {
           string filename;
           
           if (listComparison.Columns.Count > 1)
            {
                FolderBrowserDialog _FolderDialog = new FolderBrowserDialog();
                _FolderDialog.Description = "Select the folder to save snapshots for each live server into";
                _FolderDialog.SelectedPath = ProductConstants.SnapshotDirectory;

                if (_FolderDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (ConfigurationSettings _Settings in _ComparedDatabaseList.Values)
                    {
                       filename = _Settings.Key;

                       filename = filename.Replace('\\', '-');
                       filename = filename.Replace('/', '-');
                       filename = filename.Replace(':', '-');
                       filename = filename.Replace('*', '-');
                       filename = filename.Replace('?', '-');
                       filename = filename.Replace('\"', '-');
                       filename = filename.Replace('<', '-');
                       filename = filename.Replace('>', '-');
                       filename = filename.Replace('|', '-');
                       
                       SaveSnapshot(_Settings, Path.Combine(_FolderDialog.SelectedPath,
                                       string.Format("{0}_{1}_{2}.xml", filename, ProductConstants.shortProductName, DateTime.Now.ToString("yyyyMMdd"))),
                                       true);
                    }

                }
            }
            else
            {
                Messaging.ShowError("You must add items to the comparison report before saving a snapshot.");
            }
        }

        private void SaveSnapshotAllConfiguration()
        {
           string filename;

            if (_ServerConfigurations.Count > 0)
            {
                FolderBrowserDialog _FolderDialog = new FolderBrowserDialog();
                _FolderDialog.Description = "Select the folder to save snapshots for each live server into";
                _FolderDialog.SelectedPath = ProductConstants.SnapshotDirectory;

                if (_FolderDialog.ShowDialog() == DialogResult.OK)
                {

                    foreach (KeyValuePair<string, List<ConfigurationSettings>> _Item in _ServerConfigurations)
                    {
                        foreach (ConfigurationSettings _Data in _Item.Value)
                        {
                           filename = _Data.Key;

                           filename = filename.Replace('\\', '-');
                           filename = filename.Replace('/', '-');
                           filename = filename.Replace(':', '-');
                           filename = filename.Replace('*', '-');
                           filename = filename.Replace('?', '-');
                           filename = filename.Replace('\"', '-');
                           filename = filename.Replace('<', '-');
                           filename = filename.Replace('>', '-');
                           filename = filename.Replace('|', '-');
                           
                           SaveSnapshot(_Data, Path.Combine(_FolderDialog.SelectedPath,
                                           string.Format("{0}_{1}_{2}.xml", filename, ProductConstants.shortProductName, DateTime.Now.ToString("yyyyMMdd"))),
                                           true);
                        }
                    }

                }
            }
            else
            {
                Messaging.ShowError("No databases found.");
            }
        }

        private void LoadSnapshot()
        {
            Form_OpenSnapshot frm = new Form_OpenSnapshot();
            
            if (frm.ShowDialog() != DialogResult.OK) return;
            
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
                    catch (Exception exc)
                    {
                        Messaging.ShowException("Load snapshot data", exc);
                        _SnapshotSettings = null;
                    }
                }
                if (_SnapshotSettings != null && _SnapshotSettings.Count > 0)
                {
                    if (ExcessiveCompareCountCheck(_SnapshotSettings.Count))
                    {
                        foreach (ConfigurationSettings _LoadedSettings in _SnapshotSettings)
                        {
                            _LoadedSettings.Source = DataSource.Snapshot;
                            AddDataToComparisonReport(_LoadedSettings);
                        }
                    }
                }
            }
            else
            {
                Messaging.ShowError("Snapshot data does not exist");
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
                        if (col != 0)// dont allow remove on properties or baseline column
                        {
                            contextComparisonHeader.Tag = header.Tag;
                            ContextMenuItemHeaderSetDatabaseAsBaseline.Text = string.Format("Set {0} as &Baseline", header.Text);
                            ContextMenuItemHeaderRemoveDatabase.Text = string.Format("&Remove {0} from Comparison Report", header.Text);
                            ContextMenuItemHeaderCopyToClipboard.Text = string.Format("Copy {0} to Clipboard", header.Text);
                            ContextMenuItemHeaderSaveSnapshot.Text = string.Format("Save Snapshot of {0}", header.Text);
                            ContextMenuItemHeaderSaveSnapshot.Visible = (((ConfigurationSettings)header.Tag).Source == DataSource.LiveData);
                            contextComparisonHeader.Show(mousePosition);
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
                        contextBulkEditMenuStrip.Visible = toolStripSeparator2.Visible =
                           ContextMenuItemBulkUpdateSingleSetting.Visible = ContextMenuItemApplySingleSettingToServers.Visible = false;
                    }
                    else
                    {
                        contextBulkEditMenuStrip.Visible = toolStripSeparator2.Visible =
                           ContextMenuItemBulkUpdateSingleSetting.Visible = ContextMenuItemApplySingleSettingToServers.Visible = true;
                        ContextMenuItemApplySingleSettingToServers.Text = string.Format("Set baseline value for \"{0}\" to all databases", _SelectedItem.Name);
                        ContextMenuItemApplySingleSettingToServers.Enabled = (_BaselineConfiguration != null && _SelectedItem.SubItems[(int)ComparisonListColumn.Baseline].Text != ProductConstants.OptionNotAvailableString);
                        ContextMenuItemBulkUpdateSingleSetting.Text = string.Format("Bulk update \"{0}\"", _SelectedItem.Name);
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

        #region Enums

        private enum ComparisonListColumn
        {
            //DataName = 0,
            Baseline = 1
        }

        private enum IconImage
        {
            Server = 0,
            DatabaseOk = 1,
            DatabaseBaseline = 2,
            DatabaseSnapshot = 3,
            DatabaseError = 4
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

        public void ProgressBar_Initialize( string msg)
        {
            _ProgressDialog = new ToolProgressBarDialog();
            _ProgressDialog.OperationText = msg;
            _ProgressDialog.CancelEnabled = true;
            _ProgressDialog.ProgressCancelEvent += new EventHandler<EventArgs>(ProgressBar_CancelHandler);
        }
        
        public void ProgressBar_Update( string msg)
        {
            if(_ProgressDialog != null)
            {
               _ProgressDialog.OperationText = msg;
            }
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

       private void Form_Main_Load(object sender, EventArgs e)
        {

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