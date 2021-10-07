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
using SortOrder = System.Windows.Forms.SortOrder;
using System.Drawing.Drawing2D;
using DevComponents.DotNetBar.Controls;
using DevComponents.AdvTree;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.IndexAnalyzer
{
    public partial class Form_Main : Form
    {
        #region fields

        public delegate void DelegateWorkerThreadFinished(string text);
        public delegate void DelegateUpdateProgressBar(string opText, string progressText);
        public delegate void DelagateCloseProgressBar();

        public DelegateWorkerThreadFinished m_DelegateLoadDataWorkerThreadFinished;
        public DelegateWorkerThreadFinished m_DelegateUpdateStatsWorkerThreadFinished;
        public DelegateUpdateProgressBar m_DelegateUpdateProgressBarText;
        public DelagateCloseProgressBar m_DelegateCloseProgressBar;


        public delegate void DelagateShowExpection(string text, Exception ex);
        public DelagateShowExpection m_DelegateShowExpection;
        
        private Server _server = null;
        private string _serverName;
        private ToolProgressBarDialog _ProgressDialog;
        private string _gridIndexesLabelBaseText = string.Empty;
        private string _gridColumnsLabelBaseText = string.Empty;

        private DataGridViewCellMouseEventArgs theCellImHoveringOver = null;
        private List<Index> selectedIndexes = null;
        private bool areAllRowsSelected = false;
        private bool disableUpdates = false;
        private Node lastSelectedIndexNode = null;
        private Thread workerThread = null;

        private BindingSource _bindingSource = new BindingSource();
        private Selectivity _selectivity = new Selectivity();

        #endregion

        #region Constructor

        public Form_Main()
        {
            InitializeComponent();
            this.Text = ideraTitleBar1.IderaProductNameText;
            //labelSubtitle.Text = ProductConstants.productDescription;
            m_DelegateLoadDataWorkerThreadFinished = new DelegateWorkerThreadFinished(this.WorkerThreadFinished);
            m_DelegateUpdateStatsWorkerThreadFinished = new DelegateWorkerThreadFinished(this.UpdateStatisticsFinished); 
            m_DelegateShowExpection = new DelagateShowExpection(this.ShowExpection);
            m_DelegateUpdateProgressBarText = new DelegateUpdateProgressBar(this.ProgressBar_UpdateText);
            m_DelegateCloseProgressBar = new DelagateCloseProgressBar(this.ProgressBar_Close);

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);


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


        public void ShowExpection(string text, Exception ex)
        {
            Messaging.ShowException(text, ex);
        }
        public void WorkerThreadFinished(string text)
        {
            ServerDataLoaded();
        }

        #region Progress Bar

        public void ProgressBar_Show()
        {
            if(_ProgressDialog != null)
            {
                _ProgressDialog.ShowDialog(this);
            }
        }

        public void ProgressBar_Close()
        {
            if (InvokeRequired)
            {
                this.Invoke(m_DelegateCloseProgressBar);
                return;
            }
            workerThread = null;
            if(_ProgressDialog != null)
            {
                _ProgressDialog.TopLevel = false;
                _ProgressDialog.Visible = false;
                _ProgressDialog.Close();
                _ProgressDialog = null;
            }
        }

        public void ProgressBar_UpdateText(string opText, string progressText)
        {
            if (InvokeRequired)
            {
                this.Invoke(m_DelegateUpdateProgressBarText, new object[] { opText, progressText });
                return;
            }
            if (_ProgressDialog != null)
            {
                _ProgressDialog.OperationText = opText;
                _ProgressDialog.ProgressText = progressText;
                _ProgressDialog.Update();
            }
        }

        public void ProgressBar_Initialize(string text, EventHandler cancelHandler)
        {
            _ProgressDialog = new ToolProgressBarDialog();
            _ProgressDialog.OperationText = text;
            _ProgressDialog.ProgressText = string.Empty;
            _ProgressDialog.CancelEnabled = true;
            _ProgressDialog.ProgressCancelEventHandler = new EventHandler<EventArgs>(cancelHandler);

            ProductConstants.globalCancelRequested = false;
            ProductConstants.globalOperationCancelled = false;
        }

        public void ProgressBar_CancelHandlerLoad(object sender, EventArgs e)
        {
            _ProgressDialog.OperationText = "Cancelling...";
            _ProgressDialog.CancelEnabled = false;
            _ProgressDialog.Update();
            Server.Cancel();
            ProductConstants.globalCancelRequested = true;          
        }

        public void ProgressBar_CancelHandlerWorker(object sender, EventArgs e)
        {
            _ProgressDialog.OperationText = "Cancelling...";
            _ProgressDialog.CancelEnabled = false;
            _ProgressDialog.Update();
            Index.Cancel();
            ProductConstants.globalCancelRequested = true;
            if (workerThread.ThreadState != System.Threading.ThreadState.Running)
            {
                ProgressBar_Close();
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
            ProductConstants.ReadOptions();
            textServer.Text = ProductConstants.lastServer;
            ProductConstants.globalSqlCredentials = ProductConstants.lastCredentials;
            
            tabControl1.SelectedTab = tabControl1.Tabs[0];

            LoadViewModeComboBox();

            buttonUpdateFull.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonX_LoadSelectivity.Enabled = false;
            buttonCopyToClipboard.Enabled = false;

            checkBoxX_HideNonClusteredIndexes.Checked = ProductConstants.globalHideNonClustered;
            checkBoxX_HideDisabled.Checked = ProductConstants.globalHideDisabled;
            checkBoxX_HideIndexesUnderXRows.Checked = ProductConstants.globalHideBasedOnRowThreshold;
            _textBoxX_Rows.Text = ProductConstants.globalRowThreshold.ToString();

            _bindingSource.DataSource = CreateDataTable();            
            dataGridViewX1.DataSource = _bindingSource;
            SetGridColumns();

            dataGridViewX2.DataSource = CreateDataTable();
            SetStatColumns();

            UpdateDashBoard(0, -1, -1, -1, "");

            buttonBrowseDatabase.Enabled = (textServer.Text.Trim().Length > 0);
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

        #region SQL Server & Credentials Field Handling

        private void buttonCredentials_Click(object sender, EventArgs e)
        {
            Form_Credentials credentialsForm = new Form_Credentials(textServer.Text.Trim(), ProductConstants.globalSqlCredentials);
            DialogResult choice = credentialsForm.ShowDialog(this);
            if (choice == DialogResult.OK)
            {
                ProductConstants.globalSqlCredentials = credentialsForm.sqlCredentials;
            }
        }

        private void buttonBrowseServer_Click(object sender, EventArgs e)
        {
            Form_SQLServerBrowse browseDlg = new Form_SQLServerBrowse();

            Cursor = Cursors.WaitCursor;
            bool loaded = browseDlg.LoadServers();
            Cursor = Cursors.Default;

            if (loaded)
            {
                DialogResult choice = browseDlg.ShowDialog(this);
                if (choice == DialogResult.OK)
                {
                    if (textServer.Text != browseDlg.SelectedServer)
                    {
                        textServer.Text = browseDlg.SelectedServer;
                    }
                }
            }
        }

        #endregion

        #region Program Logic

        private void LoadViewModeComboBox()
        {
            comboBoxExFilter.Items.Clear();
            IndexViewMode iViewMode99 = new IndexViewMode();
            iViewMode99.ViewMode = ProductConstants.ViewMode_Summary;
            iViewMode99.GroupBoxText = ProductConstants.GroupText_Summary;
            iViewMode99.CriticalText = ProductConstants.CriticalText_Summary;
            iViewMode99.CautionText = ProductConstants.CautionText_Summary;
            iViewMode99.AcceptableText = ProductConstants.AcceptableText_Summary;
            iViewMode99.CriticalPercent = ProductConstants.CriticalPercent_AllColumns;
            iViewMode99.AcceptablePercent = ProductConstants.AccpetablePercent_AllColumns;
            iViewMode99.HelpTitle = ProductConstants.HelpTitle_Summary;
            iViewMode99.HelpText = ProductConstants.HelpText_Summary;
            iViewMode99.GetCritcalIndexesDelegate = GetCritcalSummaryIndexes;
            iViewMode99.GetCautionIndexesDelegate = GetCautionSummaryIndexes;
            iViewMode99.GetAcceptableIndexesDelegate = GetAcceptableSummaryIndexes;
            comboBoxExFilter.Items.Add(iViewMode99);
            comboBoxExFilter.SelectedItem = iViewMode99;

            if (_server != null && !_server.Is2000)
            {
                IndexViewMode iViewMode1 = new IndexViewMode();
                iViewMode1.ViewMode = ProductConstants.ViewMode_Usage;
                iViewMode1.GroupBoxText = ProductConstants.GroupText_Usage;
                iViewMode1.CriticalText = ProductConstants.CriticalText_Usage;
                iViewMode1.CautionText = ProductConstants.CautionText_Usage;
                iViewMode1.AcceptableText = ProductConstants.AcceptableText_Usage;
                iViewMode1.CriticalPercent = ProductConstants.CriticalPercent_Usage;
                iViewMode1.AcceptablePercent = ProductConstants.AccpetablePercent_Usage;
                iViewMode1.HelpTitle = ProductConstants.HelpTitle_Usage;
                iViewMode1.HelpText = ProductConstants.HelpText_Usage;
                iViewMode1.GetCritcalIndexesDelegate = GetCritcalUsageIndexes;
                iViewMode1.GetCautionIndexesDelegate = GetCautionUsageIndexes;
                iViewMode1.GetAcceptableIndexesDelegate = GetAcceptableUsageIndexes;
                comboBoxExFilter.Items.Add(iViewMode1);
            }

            //IndexViewMode iViewMode2 = new IndexViewMode();
            //iViewMode2.ViewMode = ProductConstants.ViewMode_Fragmentation;
            //iViewMode2.GroupBoxText = ProductConstants.GroupText_Fragmentation;
            //iViewMode2.CriticalText = ProductConstants.CriticalText_Fragmentation;
            //iViewMode2.CautionText = ProductConstants.CautionText_Fragmentation;
            //iViewMode2.AcceptableText = ProductConstants.AcceptableText_Fragmentation;
            //iViewMode2.CriticalPercent = ProductConstants.CriticalPercent_Fragmentation;
            //iViewMode2.AcceptablePercent = ProductConstants.AccpetablePercent_Fragmentation;
            //iViewMode2.HelpTitle = ProductConstants.HelpTitle_Fragmentation;
            //iViewMode2.HelpText = ProductConstants.HelpText_Fragmentation;
            //iViewMode2.GetCritcalIndexesDelegate = GetCritcalFragIndexes;
            //iViewMode2.GetCautionIndexesDelegate = GetCautionFragIndexes;
            //iViewMode2.GetAcceptableIndexesDelegate = GetAcceptableFragIndexes;
            //comboBoxExFilter.Items.Add(iViewMode2);

            IndexViewMode iViewMode3 = new IndexViewMode();
            iViewMode3.ViewMode = ProductConstants.ViewMode_Selectivity;
            iViewMode3.GroupBoxText = ProductConstants.GroupText_Selectivity;
            iViewMode3.CriticalText = ProductConstants.CriticalText_Selectivity;
            iViewMode3.CautionText = ProductConstants.CautionText_Selectivity;
            iViewMode3.AcceptableText = ProductConstants.AcceptableText_Selectivity;
            iViewMode3.CriticalPercent = ProductConstants.CriticalPercent_Selectivity;
            iViewMode3.AcceptablePercent = ProductConstants.AccpetablePercent_Selectivity;
            iViewMode3.HelpTitle = ProductConstants.HelpTitle_Selectivity;
            iViewMode3.HelpText = ProductConstants.HelpText_Selectivity;
            iViewMode3.GetCritcalIndexesDelegate = GetCritcalSelectivityIndexes;
            iViewMode3.GetCautionIndexesDelegate = GetCautionSelectivityIndexes;
            iViewMode3.GetAcceptableIndexesDelegate = GetAcceptableSelectivityIndexes;
            comboBoxExFilter.Items.Add(iViewMode3);

            IndexViewMode iViewMode4 = new IndexViewMode();
            iViewMode4.ViewMode = ProductConstants.ViewMode_Modified;
            iViewMode4.GroupBoxText = ProductConstants.GroupText_Modified;
            iViewMode4.CriticalText = ProductConstants.CriticalText_Modified;
            iViewMode4.CautionText = ProductConstants.CautionText_Modified;
            iViewMode4.AcceptableText = ProductConstants.AcceptableText_Modified;
            iViewMode4.CriticalPercent = ProductConstants.CriticalPercent_Modified;
            iViewMode4.AcceptablePercent = ProductConstants.AccpetablePercent_Modified;
            iViewMode4.HelpTitle = ProductConstants.HelpTitle_Modified;
            iViewMode4.HelpText = ProductConstants.HelpText_Modified;
            iViewMode4.GetCritcalIndexesDelegate = GetCritcalModifiedIndexes;
            iViewMode4.GetCautionIndexesDelegate = GetCautionModifiedIndexes;
            iViewMode4.GetAcceptableIndexesDelegate = GetAcceptableModifiedIndexes;
            comboBoxExFilter.Items.Add(iViewMode4);

            IndexViewMode iViewMode = new IndexViewMode();
            iViewMode.ViewMode = ProductConstants.ViewMode_AllColumns;
            iViewMode.GroupBoxText = ProductConstants.GroupText_AllColumns;
            iViewMode.CriticalText = ProductConstants.CriticalText_AllColumns;
            iViewMode.CautionText = ProductConstants.CautionText_AllColumns;
            iViewMode.AcceptableText = ProductConstants.AcceptableText_Summary;
            iViewMode.CriticalPercent = ProductConstants.CriticalPercent_AllColumns;
            iViewMode.AcceptablePercent = ProductConstants.AccpetablePercent_AllColumns;
            iViewMode.HelpTitle = ProductConstants.HelpTitle_AllColumns;
            iViewMode.HelpText = ProductConstants.HelpText_AllColumns;
            iViewMode.GetCritcalIndexesDelegate = GetCritcalSummaryIndexes;
            iViewMode.GetCautionIndexesDelegate = GetCautionSummaryIndexes;
            iViewMode.GetAcceptableIndexesDelegate = GetAcceptableSummaryIndexes;
            comboBoxExFilter.Items.Add(iViewMode);

        }

        private void buttonGetResults_Click(object sender, EventArgs e)
        {
            // Validation
            if (textServer.Text.Trim().Length == 0)
            {
                Core.Messaging.ShowError("Specify a SQL Server instance name.");
                textServer.Select();
                return;
            }
            
            // Get Real Server name
            _serverName = SQLHelpers.NormalizeInstanceName( textServer.Text );
            
            ProductConstants.lastServer = textServer.Text.Trim();
            ProductConstants.lastCredentials = ProductConstants.globalSqlCredentials;
            ProductConstants.WriteOptions();
            
            UpdateDashBoard(0, -1, -1, -1, string.Format("Server {0}", _serverName));
            _server = null;
            advTreeIndexes.Nodes.Clear();
            _bindingSource.DataSource = CreateDataTable();
            dataGridViewX1.DataSource = _bindingSource;

            advTreeColumns.Nodes.Clear();
            dataGridViewX2.DataSource = CreateDataTable();

            SetGridColumns();
            UpdateControlsAndMenus();

            ProgressBar_Initialize(string.Format("Connecting to Server '{0}'...", _serverName), ProgressBar_CancelHandlerLoad);
            
            workerThread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(LoadServerData));
            workerThread.Start(textDatabase.Text.Trim());

            ProgressBar_Show();

            this.Focus();

            if (ProductConstants.globalOperationCancelled == true)
            {
                ProgressBar_Close();
                ProductConstants.globalErrorReports.Clear();
                Messaging.ShowInformation(this, "Loading Indexes cancelled by user");
            }
            if (ProductConstants.globalErrorReports.Count > 0)
            {
                ProgressBar_Close();
                Form_MultipleErrorHandler errorDlg = new Form_MultipleErrorHandler();
                errorDlg.Title = "Load Index Errors";
                errorDlg.Errors = ProductConstants.globalErrorReports;
                errorDlg.ShowDialog(this);
                ProductConstants.globalErrorReports.Clear();
            }
        }

        private void LoadServerData(object databaseList)
        {
            try
            {
                // Verify the server is 2000 or greater
                try
                {
                    using (
                        SqlConnection conn =
                            new SqlConnection(
                                Connection.CreateConnectionString(_serverName, string.Empty,
                                                                  ProductConstants.globalSqlCredentials)))
                    {
                        Connection.Impersonate(ProductConstants.globalSqlCredentials);
                        conn.Open();
                        if (!SQLHelpers.Is2000orGreater(conn))
                        {
                            throw new Exception(String.Format("{0} only supports SQL Server 2000 and greater.",
                                                              ProductConstants.productName));
                        }
                    }
                }
                catch (Exception ex)
                {
                    ProductConstants.globalErrorReports.Add(
                        string.Format("Error connecting to Server {0}.", _serverName),
                        Helpers.GetCombinedExceptionText(ex));
                }
                if (ProductConstants.globalErrorReports.Count == 0 && !ProductConstants.globalCancelRequested)
                {
                    try
                    {
                        _server = new Server(_serverName);

                        List<string> _Databases = new List<string>();
                        if (((string)databaseList).Trim().Length > 0)
                        {
                            _Databases.AddRange(((string)databaseList).Split(';'));
                        }
                        _server.LoadDTIs(m_DelegateUpdateProgressBarText, ProductConstants.globalIncludeColumnStats,
                                        ProductConstants.globalIncludeFrag, ProductConstants.globalIncludeSelectivity,
                                        _Databases);

                        ProgressBar_UpdateText("Updating UI..", string.Empty);
                    }
                    catch (Exception ex)
                    {
                        Messaging.ShowException(string.Format("Loading Index data for Server {0}", _serverName), ex);
                    }
                }

                if (ProductConstants.globalCancelRequested)
                {
                    ProductConstants.globalOperationCancelled = true;
                }
                this.Invoke(m_DelegateLoadDataWorkerThreadFinished, new object[] {_serverName});
            }
            catch(Exception ex)
            {
                ProductConstants.globalErrorReports.Add(
                                        string.Format("Error loading Statistics for {0}.", _serverName),
                                        Helpers.GetCombinedExceptionText(ex));                
            }
            finally
            {
                ProgressBar_Close();
            }
        }

        private void ServerDataLoaded()
        {           
            if(_server == null)
            {
                return;
            }

            LoadViewModeComboBox();

            LoadIndexTree();
            _bindingSource.DataSource = CreateDataTableFromIndex(_server.Indexes);
            SetFilterOptions();
            dataGridViewX1.DataSource = _bindingSource;
            SetGridColumns();


            LoadStatTree();
            dataGridViewX2.DataSource = CreateDataTableFromIndex(_server.Stats);
            SetStatColumns();
            dataGridViewX2.Sort(dataGridViewX2.Columns["Selectivity"], ListSortDirection.Descending);

            UpdateControlsAndMenus();

        }

        private void LoadIndexTree()
        {
            advTreeIndexes.Nodes.Clear();
            advTreeIndexes.ImageList = imageList1;
            int numIndexes = _server.NumberIndexes;
            string indexText = numIndexes == 1 ? "index" : "indexes";
            Node nodeS = new Node();
            nodeS.Text = string.Format("{0} ({1} {2})", _serverName, numIndexes, indexText);
            nodeS.Tag = _server;
            nodeS.ImageIndex = 0;
            foreach (Database d in _server.Databases)
            {
                numIndexes = d.NumberIndexes;
                indexText = numIndexes == 1 ? "index" : "indexes";
                Node nodeD = new Node();
                nodeD.Text = string.Format("{0} ({1} {2})", d.Name, numIndexes, indexText);
                nodeD.Tag = d;
                nodeD.ImageIndex = 1;
                foreach (Table t in d.Tables)
                {
                    numIndexes = t.NumberIndexes;
                    indexText = numIndexes == 1 ? "index" : "indexes";
                    Node nodeT = new Node();
                    nodeT.Text = string.Format("{0}.{1} ({2} {3})", t.SchemaName, t.Name, numIndexes, indexText);
                    nodeT.Tag = t;
                    nodeT.ImageIndex = 2;
                    nodeD.Nodes.Add(nodeT);
                }
                nodeS.Nodes.Add(nodeD);
            }
            nodeS.Expand();
            advTreeIndexes.Nodes.Add(nodeS);
            advTreeIndexes.SelectedNode = nodeS;
        }

        private void LoadStatTree()
        {
            advTreeColumns.Nodes.Clear();
            advTreeColumns.ImageList = imageList1;
            int numStats = _server.NumberStats;
            string statText = numStats == 1 ? "stat" : "stats";
            Node nodeS = new Node();
            nodeS.Text = string.Format("{0} ({1} {2})", _serverName, numStats, statText);
            nodeS.Tag = _server;
            nodeS.ImageIndex = 0;
            foreach (Database d in _server.Databases)
            {
                numStats = d.NumberStats;
                statText = numStats == 1 ? "stat" : "stats";
                Node nodeD = new Node();
                nodeD.Text = string.Format("{0} ({1} {2})", d.Name, numStats, statText);
                nodeD.Tag = d;
                nodeD.ImageIndex = 1;
                foreach (Table t in d.StatTables)
                {
                    numStats = t.NumberStats;
                    statText = numStats == 1 ? "stat" : "stats";
                    Node nodeT = new Node();
                    nodeT.Text = string.Format("{0}.{1} ({1} {2})", t.SchemaName, t.Name, numStats, statText);
                    nodeT.Tag = t;
                    nodeT.ImageIndex = 2;
                    nodeD.Nodes.Add(nodeT);
                }
                nodeS.Nodes.Add(nodeD);
            }
            nodeS.Expand();
            advTreeColumns.Nodes.Add(nodeS);
            advTreeColumns.SelectedNode = nodeS;
        }

        DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("DatabaseName", typeof(string));
            //            dataTable.Columns.Add("SchemaName", typeof(string));
            dataTable.Columns.Add("TableName", typeof(string));
            dataTable.Columns.Add("Index", typeof(Index));
            dataTable.Columns.Add("IsClustered", typeof(string));
            dataTable.Columns.Add("IsDisabled", typeof(string));
            dataTable.Columns.Add("Summary", typeof(int));
            dataTable.Columns.Add("Rows", typeof(long));
            dataTable.Columns.Add("LastUpdated", typeof(DateTime));
            dataTable.Columns.Add("ModifiedRows", typeof(long));
            dataTable.Columns.Add("PercentModifiedRows", typeof(double));
            dataTable.Columns.Add("CountPages", typeof(int));
            dataTable.Columns.Add("EstimatedSize", typeof(long));
            dataTable.Columns.Add("FragmentationPercent", typeof(double));
            dataTable.Columns.Add("FillFactor", typeof(string));
            dataTable.Columns.Add("Selectivity", typeof(double));
            dataTable.Columns.Add("TotalAccesses", typeof(long));
            dataTable.Columns.Add("Seeks", typeof(long));
            dataTable.Columns.Add("Scans", typeof(long));
            dataTable.Columns.Add("Lookups", typeof(long));
            dataTable.Columns.Add("Updates", typeof(long));
            dataTable.Columns.Add("UpdatesToAccesses", typeof(double));
            dataTable.Columns.Add("Columns", typeof(string));
            return dataTable;

        }

        DataTable CreateDataTableFromIndex(List<Index> indexes)
        {
            DataTable dataTable = CreateDataTable();
            double frag, selectivity, updateRatio, modifiedRowsRatio;
            foreach (Index i in indexes)
            {
                frag = i.AverageFragLevel;
                selectivity = _selectivity.calculate_selectivity(i.AverageDensity, i.Rows);
                updateRatio = i.TotalAccess == 0 ? 0 : (double)i.Updates / i.TotalAccess;
                modifiedRowsRatio = i.Rows == 0 ? -1.0 : i.ModifiedRows > i.Rows ? 1.0 : (double)i.ModifiedRows / i.Rows;
                i.UsefulnessSummary = CalculateIndexUsefulnessSummary(i);
                dataTable.Rows.Add(new object[] {   i.DatabaseName, 
                                                    string.Format("{0}.{1}",i.SchemaName, i.TableName),
                                                    i,
                                                    i.IsClustered ? "Yes" : "No",
                                                    i.IsDisabled ? "Yes" : "No",
                                                    (int)i.UsefulnessSummary,
                                                    i.Rows,
                                                    i.LastStatisticsUpdate,
                                                    i.ModifiedRows,
                                                    modifiedRowsRatio,
                                                    i.CountPages,
                                                    i.CountPages * ProductConstants.IndexPageSize,
                                                    frag,
                                                    i.FillFactor,
                selectivity,
                i.TotalAccess,
                i.Seeks,
                i.Scans,
                i.Lookups,
                i.Updates,                
                updateRatio,
                i.Columns});

                //if (i.AverageDensity > 1)
                //{
                //    _serverName = _server.ServerName;
                //}
            }

            return dataTable;
        }
        
        private void UpdateDashBoard(bool resetDataSource)
        {
            if (advTreeIndexes.SelectedNode != null)
            {
                int numCritical = 0;
                int numCaution = 0;
                int numAcceptable = 0;
                int numIndexes = 0;
                string filter = string.Empty;
                IndexViewMode iViewMode = (IndexViewMode)comboBoxExFilter.SelectedItem;
                object obj = advTreeIndexes.SelectedNode.Tag;
                if (obj is Server)
                {
                    Server s = (Server)obj;
                    if (resetDataSource)
                    {
                        _bindingSource.DataSource = CreateDataTableFromIndex(s.Indexes);
                        SetGridColumns();
                    }
                    numIndexes = s.NumberIndexes;
                    numCritical = iViewMode.GetCriticalIndexes(s);
                    numCaution = iViewMode.GetCautionIndexes(s);
                    numAcceptable = iViewMode.GetAcceptableIndexes(s);
                    filter = string.Format("SQL Server '{0}'", _serverName);
                }
                else if (obj is Database)
                {
                    Database d = (Database)obj;
                    if (resetDataSource)
                    {
                        _bindingSource.DataSource = CreateDataTableFromIndex(d.Indexes);
                        SetGridColumns();
                    }
                    numIndexes = d.NumberIndexes;
                    numCritical = iViewMode.GetCriticalIndexes(d);
                    numCaution = iViewMode.GetCautionIndexes(d);
                    numAcceptable = iViewMode.GetAcceptableIndexes(d);
                    filter = string.Format("Database '{0}'", d.Name);
                }
                else if (obj is Table)
                {
                    Table t = (Table)obj;
                    if (resetDataSource)
                    {
                        _bindingSource.DataSource = CreateDataTableFromIndex(t.Indexes);
                        SetGridColumns();
                    }
                    numIndexes = t.NumberIndexes;
                    numCritical = iViewMode.GetCriticalIndexes(t);
                    numCaution = iViewMode.GetCautionIndexes(t);
                    numAcceptable = iViewMode.GetAcceptableIndexes(t);
                    filter = string.Format("Table '{0}'", t.Name);
                }

                UpdateDashBoard(numIndexes, numCritical, numCaution, numAcceptable, filter);
            }
            else
            {
                UpdateDashBoard(0, -1, -1, -1, "");
            }
        }

        private void UpdateDashBoard(int indexes, int critical, int caution, int acceptable, string objectName)
        {
            if (disableUpdates == true)
            {
                return;
            }
            IndexViewMode iViewMode = (IndexViewMode)comboBoxExFilter.SelectedItem;
            if (iViewMode != null)
            {
                labelCriticalIndexes.Text = string.Format(iViewMode.CriticalText, critical < 0 ? "?" : critical.ToString(), critical == 1 ? string.Empty : "es");
                labelCautionIndexes.Text = string.Format(iViewMode.CautionText, caution < 0 ? "?" : caution.ToString(), caution == 1 ? string.Empty : "es");
                labelAcceptableIndexes.Text = string.Format(iViewMode.AcceptableText, acceptable < 0 ? "?" : acceptable.ToString(), acceptable == 1 ? string.Empty : "es");
                groupPanel2.Text = string.Format(iViewMode.GroupBoxText, objectName);
                _gridIndexesLabelBaseText = string.Format("{0} for {1}", iViewMode.ViewMode, objectName);

                labelX_HelpText.Text = iViewMode.HelpText;
                labelX_HelpTitle.Text = iViewMode.HelpTitle;

                if (indexes > 0 && (ProductConstants.globalHideBasedOnRowThreshold || ProductConstants.globalHideDisabled || ProductConstants.globalHideNonClustered))
                {
                    int filteredIndexes = 0;
                    if (dataGridViewX1 != null && dataGridViewX1.Rows != null)
                    {
                        filteredIndexes = indexes - dataGridViewX1.Rows.Count;
                    }
                    labelX_FilteredIndexes.Text = string.Format(ProductConstants.FilterText, filteredIndexes, indexes)
                        + " as of " + DateTime.Now.ToString();
                    pictureBox_Filter.Visible = true;
                    labelX_FilteredIndexes.Visible = true;
                }
                else
                {
                    pictureBox_Filter.Visible = false;
                    labelX_FilteredIndexes.Visible = false;
                }

                UpdateIndexLabel();
            }
        }

        private void UpdateIndexLabel()
        {
            int rows = dataGridViewX1.Rows.Count;
            int selected = dataGridViewX1.SelectedRows.Count;
            labelTableList.Text = string.Format("{0} ({1} index{2}, {3} selected)", _gridIndexesLabelBaseText, rows, rows == 1 ? string.Empty : "es", selected);            
        }

        private void UpdateColumnLabel()
        {
            int rows = dataGridViewX2.Rows.Count;
            int selected = dataGridViewX2.SelectedRows.Count;
            _labelXStatistics.Text = string.Format("{0} ({1} column{2}, {3} selected)", _gridColumnsLabelBaseText, rows, rows == 1 ? string.Empty : "s", selected);
        }

        private void UpdateControlsAndMenus()
        {
            if(disableUpdates == true)
            {
                return;
            }
            DataGridView dataGridView = GetActiveGrid();
            bool enableCopyToClipboard = false;
            bool enableSelectivity = false;
            bool enableUpdateStats = false;

            if (dataGridView != null)
            {
                if (dataGridView.Rows.Count != 0)
                {
                    fileSaveMenu.Enabled = true;
                    editSelectAllMenuItem.Enabled = true;
                    contextMenuExport.Enabled = true;
                    contextMenuSelectAll.Enabled = true;
                    enableCopyToClipboard = true;
                    contextMenuIndexProperties.Enabled = true;
                }
                else
                {
                    fileSaveMenu.Enabled = false;
                    editSelectAllMenuItem.Enabled = false;
                    contextMenuExport.Enabled = false;
                    contextMenuSelectAll.Enabled = false;
                    contextMenuIndexProperties.Enabled = false;

                    enableCopyToClipboard = false;
                }

                if (dataGridView.SelectedRows.Count != 0)
                {
                    editCopyMenuItem.Enabled = true;
                    contextMenuCopy.Enabled = true;

                    contextMenuUpdateStatistics.Enabled = true;
                    menuUpdateStatistics.Enabled = true;
                    contextMenuUpdateStatisticsFullScan.Enabled = true;
                    menuUpdateStatisticsFullScan.Enabled = true;
                    enableSelectivity = true;
                    enableUpdateStats = true;                    
//                    buttonX_AnalyzeFragmentation.Enabled = true;
                }
                else
                {
                    editCopyMenuItem.Enabled = false;
                    contextMenuCopy.Enabled = false;

                    contextMenuUpdateStatistics.Enabled = false;
                    menuUpdateStatistics.Enabled = false;
                    contextMenuUpdateStatisticsFullScan.Enabled = false;
                    menuUpdateStatisticsFullScan.Enabled = false;
                    enableSelectivity = false;
                    enableUpdateStats = false;
//                    buttonX_AnalyzeFragmentation.Enabled = false;

                }

                if (dataGridView.SelectedRows.Count == 1)
                {
                    menuIndexProperties.Enabled = true;
                }
                else
                {
                    menuIndexProperties.Enabled = false;                    
                }
            }
            if(dataGridView == dataGridViewX1)
            {
                UpdateDashBoard(false);
//                buttonX_AnalyzeFragmentation.Visible = true;
            }
            else if (dataGridView == dataGridViewX2)
            {
                UpdateColumnLabel();
                contextMenuIndexProperties.Enabled = false;
                menuIndexProperties.Enabled = false;
//                buttonX_AnalyzeFragmentation.Visible = false;  
            }

            buttonUpdate.Enabled = enableUpdateStats;
            buttonUpdateFull.Enabled = enableUpdateStats;
            buttonCopyToClipboard.Enabled = enableCopyToClipboard;
            buttonX_LoadSelectivity.Enabled = enableSelectivity;
        }

        private void SetGridColumns()
        {
            if (dataGridViewX1 != null && dataGridViewX1.Columns.Count > 0)
            {
                switch (comboBoxExFilter.SelectedItem.ToString())
                {
                    case ProductConstants.ViewMode_Summary:
                        SetSummaryColumns();
                        dataGridViewX1.Sort(dataGridViewX1.Columns["Summary"], ListSortDirection.Ascending);
                        break;
                    case ProductConstants.ViewMode_AllColumns:
                        SetIndexColumns();
                        dataGridViewX1.Sort(dataGridViewX1.Columns["Summary"], ListSortDirection.Ascending);
                        break;
                    case ProductConstants.ViewMode_Usage:
                        SetUsageColumns();
                        dataGridViewX1.Sort(dataGridViewX1.Columns["UpdatesToAccesses"], ListSortDirection.Descending);
                        break;
                    case ProductConstants.ViewMode_Fragmentation:
                        SetFragColumns();
                        dataGridViewX1.Sort(dataGridViewX1.Columns["FragmentationPercent"], ListSortDirection.Descending);
                        break;
                    case ProductConstants.ViewMode_Selectivity:
                        SetSelectivityColumns();
                        dataGridViewX1.Sort(dataGridViewX1.Columns["Selectivity"], ListSortDirection.Ascending);
                        break;
                    case ProductConstants.ViewMode_Modified:
                        SetOutDatedColumns();
                        dataGridViewX1.Sort(dataGridViewX1.Columns["PercentModifiedRows"], ListSortDirection.Descending);
                        break;
                    default:
                        SetSummaryColumns();
                        break;
                }
                dataGridViewX1.Invalidate();

                dataGridViewX1.Refresh();
            }
        }

        #region Add Grid Columns
        private void AddDatabaseColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("DatabaseName"))
            {
                int i = dataGridViewX1.Columns["DatabaseName"].Index; 
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Database";
                dataGridViewX1.Columns[i].ToolTipText = "Database Name";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
            }            
        }
        private void AddTableColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("TableName"))
            {
                int i = dataGridViewX1.Columns["TableName"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].FillWeight = 100;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Table";
                dataGridViewX1.Columns[i].ToolTipText = "Table Name";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
            }
        }
        private void AddIndexColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("Index"))
            {
                int i = dataGridViewX1.Columns["Index"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Index";
                dataGridViewX1.Columns[i].ToolTipText = "Index Name";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
            }
        }
        private void AddColumnsColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("Columns"))
            {
                int i = dataGridViewX1.Columns["Columns"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Columns";
                dataGridViewX1.Columns[i].ToolTipText = "Columns used by Index";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
            }
        }
        private void AddIsClusteredColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("IsClustered"))
            {
                int i = dataGridViewX1.Columns["IsClustered"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Clustered";
                dataGridViewX1.Columns[i].ToolTipText = "Is the index clustered";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void AddIsDisabledColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("IsDisabled"))
            {
                int i = dataGridViewX1.Columns["IsDisabled"].Index; 
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Disabled";
                dataGridViewX1.Columns[i].ToolTipText = "Is the index disabled";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void AddSummaryColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("Summary"))
            {
                int i = dataGridViewX1.Columns["Summary"].Index; 
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 50;
                dataGridViewX1.Columns[i].HeaderText = "Index Usefulness";
                dataGridViewX1.Columns[i].ToolTipText = "Estimated usefulness of the index based off current statistics";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewX1.Columns[i].ReadOnly = true;
            }       
        }
        private void AddPercentModifiedRowsColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("PercentModifiedRows"))
            {
                int i = dataGridViewX1.Columns["PercentModifiedRows"].Index; 
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 50;
                dataGridViewX1.Columns[i].HeaderText = "% Rows Modified";
                dataGridViewX1.Columns[i].ToolTipText =
                    "Percentage of rows modified since last statistics update";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewX1.Columns[i].ReadOnly = true;
            }
        }
        private void AddFragmentationPercentColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("FragmentationPercent"))
            {
                int i = dataGridViewX1.Columns["FragmentationPercent"].Index;
                dataGridViewX1.Columns[i].Visible = false;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 50;
                dataGridViewX1.Columns[i].HeaderText = "Fragmentation";
                dataGridViewX1.Columns[i].ToolTipText = "Fragmentation percentage of the index";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewX1.Columns[i].ReadOnly = true;
            }
        }
        private void AddSelectivityColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("Selectivity"))
            {
                int i = dataGridViewX1.Columns["Selectivity"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 50;
                dataGridViewX1.Columns[i].HeaderText = "Selectivity";
                dataGridViewX1.Columns[i].ToolTipText = "Selectivity of the index - an approximation of the percent of unique values";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewX1.Columns[i].ReadOnly = true;
            }
        }
        private void AddUpdatesToAccessesColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("UpdatesToAccesses"))
            {
                int i = dataGridViewX1.Columns["UpdatesToAccesses"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 50;
                dataGridViewX1.Columns[i].HeaderText = "% Updates to Total Accesses";
                dataGridViewX1.Columns[i].ToolTipText = "Percentage of Index Updates to Total Index Accesses";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewX1.Columns[i].ReadOnly = true;
            }        
        }
        private void AddRowsColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("Rows"))
            {
                int i = dataGridViewX1.Columns["Rows"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Rows";
                dataGridViewX1.Columns[i].ToolTipText = "Number of rows in index";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void AddLastUpdatedColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("LastUpdated"))
            {
                int i = dataGridViewX1.Columns["LastUpdated"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Last Statistics Update";
                dataGridViewX1.Columns[i].ToolTipText = "Time statistics were last updated for this index";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        private void AddModifiedRowsColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("ModifiedRows"))
            {
                int i = dataGridViewX1.Columns["ModifiedRows"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Rows Modified Since Last Update";
                dataGridViewX1.Columns[i].ToolTipText = "Number of rows modified since statistics were last updated for this index";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }       
        private void AddCountPagesColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("CountPages"))
            {
                int i = dataGridViewX1.Columns["CountPages"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Pages";
                dataGridViewX1.Columns[i].ToolTipText = "Number pages used by this index";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void AddEstimatedSizeColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("EstimatedSize"))
            {
                int i = dataGridViewX1.Columns["EstimatedSize"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Size";
                dataGridViewX1.Columns[i].ToolTipText = "Storage space used by index";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void AddFillFactorColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("FillFactor"))
            {
                int i = dataGridViewX1.Columns["FillFactor"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Fill Factor";
                dataGridViewX1.Columns[i].ToolTipText = "Fill Factor for index pages";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void AddTotalAccessesColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("TotalAccesses"))
            {
                int i = dataGridViewX1.Columns["TotalAccesses"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Total Accesses";
                dataGridViewX1.Columns[i].ToolTipText = "Number of accesses (seeks, scans, lookups, updates) to index";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void AddSeeksColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("Seeks"))
            {
                int i = dataGridViewX1.Columns["Seeks"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Seeks";
                dataGridViewX1.Columns[i].ToolTipText = "Number of seeks on index";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void AddScansColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("Scans"))
            {
                int i = dataGridViewX1.Columns["Scans"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Scans";
                dataGridViewX1.Columns[i].ToolTipText = "Number of scans on index";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void AddLookupsColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("Lookups"))
            {
                int i = dataGridViewX1.Columns["Lookups"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Lookups";
                dataGridViewX1.Columns[i].ToolTipText = "Number of lookups on index";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void AddUpdatesColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (dataGridViewX1.Columns.Contains("Updates"))
            {
                int i = dataGridViewX1.Columns["Updates"].Index;
                dataGridViewX1.Columns[i].Visible = true;
                dataGridViewX1.Columns[i].DisplayIndex = dispalyIndex;
                dataGridViewX1.Columns[i].Width = width;
                dataGridViewX1.Columns[i].MinimumWidth = 20;
                dataGridViewX1.Columns[i].HeaderText = "Updates";
                dataGridViewX1.Columns[i].ToolTipText = "Number of updates to index";
                dataGridViewX1.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    dataGridViewX1.AutoResizeColumn(i);
                    dataGridViewX1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    dataGridViewX1.Columns[i].AutoSizeMode = autoSizeMode;
                }
                dataGridViewX1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns[i].ReadOnly = true;
                dataGridViewX1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        #endregion

        private void SetSummaryColumns()
        {
            int di = 0;
            foreach (DataGridViewColumn col in dataGridViewX1.Columns)
            {
                col.Visible = false;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
            //            dataGridViewX1.RowHeadersWidth = 24;
            dataGridViewX1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridViewX1.AllowUserToResizeColumns = true;

            // Show these columns
            AddDatabaseColumn(80, di++, DataGridViewAutoSizeColumnMode.None);

            AddTableColumn(80, di++, DataGridViewAutoSizeColumnMode.None);

            AddIndexColumn(100, di++, DataGridViewAutoSizeColumnMode.None);

//            AddColumnsColumn(100, di++, DataGridViewAutoSizeColumnMode.None);

            AddIsClusteredColumn(60, di++, DataGridViewAutoSizeColumnMode.None);

            AddFillFactorColumn(60, di++, DataGridViewAutoSizeColumnMode.None);

            AddIsDisabledColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddRowsColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddSummaryColumn(100, di++, DataGridViewAutoSizeColumnMode.None);

            AddPercentModifiedRowsColumn(100, di++, DataGridViewAutoSizeColumnMode.None);

            AddFragmentationPercentColumn(100, di++, DataGridViewAutoSizeColumnMode.None);

            AddSelectivityColumn(100, di++, DataGridViewAutoSizeColumnMode.None);

            AddUpdatesToAccessesColumn(100, di++, DataGridViewAutoSizeColumnMode.None);          
          
        }

        private void SetIndexColumns()
        {
            int di = 0;
            foreach (DataGridViewColumn col in dataGridViewX1.Columns)
            {
                col.Visible = false;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

//            dataGridViewX1.RowHeadersWidth = 24;
            dataGridViewX1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridViewX1.AllowUserToResizeColumns = true;

            // Show these columns
            AddDatabaseColumn(60, di++, DataGridViewAutoSizeColumnMode.None);

            AddTableColumn(60, di++, DataGridViewAutoSizeColumnMode.None);

            AddIndexColumn(100, di++, DataGridViewAutoSizeColumnMode.None);

            AddColumnsColumn(100, di++, DataGridViewAutoSizeColumnMode.None);

            AddIsClusteredColumn(60, di++, DataGridViewAutoSizeColumnMode.None);

            AddIsDisabledColumn(60, di++, DataGridViewAutoSizeColumnMode.None);

            AddSummaryColumn(100, di++, DataGridViewAutoSizeColumnMode.None);

            AddRowsColumn(60, di++, DataGridViewAutoSizeColumnMode.None);
                  
            AddLastUpdatedColumn(120, di++, DataGridViewAutoSizeColumnMode.None);

            AddModifiedRowsColumn(80, di++, DataGridViewAutoSizeColumnMode.None);

            AddPercentModifiedRowsColumn(100, di++, DataGridViewAutoSizeColumnMode.None);

            AddCountPagesColumn(60, di++, DataGridViewAutoSizeColumnMode.None);

            AddEstimatedSizeColumn(60, di++, DataGridViewAutoSizeColumnMode.None);

            AddFragmentationPercentColumn(100, di++, DataGridViewAutoSizeColumnMode.None);

            AddFillFactorColumn(60, di++, DataGridViewAutoSizeColumnMode.None);

            AddSelectivityColumn(100, di++, DataGridViewAutoSizeColumnMode.None);

            if (_server != null && !_server.Is2000)
            {
                AddTotalAccessesColumn(60, di++, DataGridViewAutoSizeColumnMode.None);

                AddSeeksColumn(60, di++, DataGridViewAutoSizeColumnMode.None);

                AddScansColumn(60, di++, DataGridViewAutoSizeColumnMode.None);

                AddLookupsColumn(60, di++, DataGridViewAutoSizeColumnMode.None);

                AddUpdatesColumn(60, di++, DataGridViewAutoSizeColumnMode.None);

                AddUpdatesToAccessesColumn(100, di++, DataGridViewAutoSizeColumnMode.None);
            }
        }

        private void SetUsageColumns()
        {
            int di = 0;
            foreach (DataGridViewColumn col in dataGridViewX1.Columns)
            {
                col.Visible = false;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
          //  dataGridViewX1.RowHeadersWidth = 24;
            dataGridViewX1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            AddDatabaseColumn(100, di++, DataGridViewAutoSizeColumnMode.Fill);

            AddTableColumn(100, di++, DataGridViewAutoSizeColumnMode.Fill);

            AddIndexColumn(100, di++, DataGridViewAutoSizeColumnMode.Fill);
            
            AddColumnsColumn(100, di++, DataGridViewAutoSizeColumnMode.Fill);

            if (_server != null && !_server.Is2000)
            {
                AddTotalAccessesColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

                AddScansColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

                AddScansColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

                AddLookupsColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

                AddUpdatesColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

                AddUpdatesToAccessesColumn(120, di++, DataGridViewAutoSizeColumnMode.None);
            }
        }

        private void SetSelectivityColumns()
        {
            int di = 0;
            foreach (DataGridViewColumn col in dataGridViewX1.Columns)
            {
                col.Visible = false;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
      //       dataGridViewX1.RowHeadersWidth = 24;
            dataGridViewX1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;                       

            AddDatabaseColumn(100, di++, DataGridViewAutoSizeColumnMode.Fill);

            AddTableColumn(100, di++, DataGridViewAutoSizeColumnMode.Fill);
             
            AddIndexColumn(100, di++, DataGridViewAutoSizeColumnMode.Fill);

            AddColumnsColumn(100, di++, DataGridViewAutoSizeColumnMode.Fill);

            AddFillFactorColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddSelectivityColumn(120, di++, DataGridViewAutoSizeColumnMode.None);
         }

        private void SetFragColumns()
        {
            int di = 0;
            foreach (DataGridViewColumn col in dataGridViewX1.Columns)
            {
                col.Visible = false;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
//            dataGridViewX1.RowHeadersWidth = 24;
            dataGridViewX1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            AddDatabaseColumn(100, di++, DataGridViewAutoSizeColumnMode.Fill);

            AddTableColumn(100, di++, DataGridViewAutoSizeColumnMode.Fill);

            AddIndexColumn(100, di++, DataGridViewAutoSizeColumnMode.Fill);

            AddColumnsColumn(100, di++, DataGridViewAutoSizeColumnMode.Fill);

            AddCountPagesColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);
        
            AddEstimatedSizeColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddFragmentationPercentColumn(120, di++, DataGridViewAutoSizeColumnMode.None);         
        }
    
        private void SetOutDatedColumns()
        {
            int di = 0;
            foreach (DataGridViewColumn col in dataGridViewX1.Columns)
            {
                col.Visible = false;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
           // dataGridViewX1.RowHeadersWidth = 24;
            dataGridViewX1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            AddDatabaseColumn(100, di++, DataGridViewAutoSizeColumnMode.Fill);

            AddTableColumn(100, di++, DataGridViewAutoSizeColumnMode.Fill);

            AddIndexColumn(100, di++, DataGridViewAutoSizeColumnMode.Fill);

            AddColumnsColumn(100, di++, DataGridViewAutoSizeColumnMode.Fill);

            //AddIsClusteredColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);
            //AddIsDisabledColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddRowsColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddLastUpdatedColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddModifiedRowsColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddPercentModifiedRowsColumn(120, di++, DataGridViewAutoSizeColumnMode.None);
        }

        private void SetStatColumns()
        {
            foreach (DataGridViewColumn col in dataGridViewX2.Columns)
            {
                col.Visible = false;
            }
            //            dataGridViewX2.RowHeadersWidth = 24;
            dataGridViewX2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Show these columns
            if (dataGridViewX2.Columns.Contains("DatabaseName"))
            {
                dataGridViewX2.Columns["DatabaseName"].Visible = true;
                dataGridViewX2.Columns["DatabaseName"].DisplayIndex = 0;
                dataGridViewX2.Columns["DatabaseName"].MinimumWidth = 60;
                dataGridViewX2.Columns["DatabaseName"].HeaderText = "Database";
                dataGridViewX2.Columns["DatabaseName"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX2.Columns["DatabaseName"].ReadOnly = true;
            }
          
            if (dataGridViewX2.Columns.Contains("TableName"))
            {
                dataGridViewX2.Columns["TableName"].Visible = true;
                dataGridViewX2.Columns["TableName"].DisplayIndex = 2;
                dataGridViewX2.Columns["TableName"].MinimumWidth = 60;
                dataGridViewX2.Columns["TableName"].HeaderText = "Table";
                dataGridViewX2.Columns["TableName"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX2.Columns["TableName"].ReadOnly = true;
            }
            if (dataGridViewX2.Columns.Contains("Index"))
            {
                dataGridViewX2.Columns["Index"].Visible = true;
                dataGridViewX2.Columns["Index"].DisplayIndex = 3;
                dataGridViewX2.Columns["Index"].MinimumWidth = 150;
                dataGridViewX2.Columns["Index"].HeaderText = "Statistic";
                dataGridViewX2.Columns["Index"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX2.Columns["Index"].ReadOnly = true;
            }

            if (dataGridViewX2.Columns.Contains("Columns"))
            {
                dataGridViewX2.Columns["Columns"].Visible = true;
                dataGridViewX2.Columns["Columns"].DisplayIndex = 4;
                dataGridViewX2.Columns["Columns"].MinimumWidth = 80;
                dataGridViewX2.Columns["Columns"].HeaderText = "Column";
                dataGridViewX2.Columns["Columns"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX2.Columns["Columns"].ReadOnly = true;
            }

            if (dataGridViewX2.Columns.Contains("ModifiedRows"))
            {
                dataGridViewX2.Columns["ModifiedRows"].Visible = true;
                dataGridViewX2.Columns["ModifiedRows"].DisplayIndex = 5;
                dataGridViewX2.Columns["ModifiedRows"].MinimumWidth = 80;
                dataGridViewX2.Columns["ModifiedRows"].HeaderText = "Modified Rows";
                dataGridViewX2.Columns["ModifiedRows"].ToolTipText = "Number of rows modified since statistics were last updated for this column";
                dataGridViewX2.Columns["ModifiedRows"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX2.Columns["ModifiedRows"].ReadOnly = true;
            }

            if (dataGridViewX2.Columns.Contains("Selectivity"))
            {
                dataGridViewX2.Columns["Selectivity"].Visible = true;
                dataGridViewX2.Columns["Selectivity"].DisplayIndex = 6;
                dataGridViewX2.Columns["Selectivity"].MinimumWidth = 80;
                dataGridViewX2.Columns["Selectivity"].HeaderText = "Selectivity";
                dataGridViewX2.Columns["Selectivity"].ToolTipText = "Selectivity of the index - a statistical approximation of the percent of unique values";
                dataGridViewX2.Columns["Selectivity"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX2.Columns["Selectivity"].ReadOnly = true;
            }


        }             

        private IndexUsefulness CalculateIndexUsefulnessSummary(Index i)
        {
            IndexUsefulness summary = IndexUsefulness.Low;
            double frag, selectivity, updateRatio, modifiedRowsRatio;
            frag = i.AverageFragLevel;
            selectivity = _selectivity.calculate_selectivity(i.AverageDensity, i.Rows);
            updateRatio = i.TotalAccess == 0 ? 0 : (double)i.Updates / i.TotalAccess;
            modifiedRowsRatio = i.Rows == 0 ? -1.0 : i.ModifiedRows > i.Rows ? 1.0 : (double)i.ModifiedRows / i.Rows;           
            if (i.IsDisabled)
            {
                summary = IndexUsefulness.Low;
            }
            else  if(i.Rows == 0)
            {
                summary = IndexUsefulness.NA;
            }
            else if (frag <= ProductConstants.AccpetablePercent_Fragmentation
                && selectivity >= ProductConstants.AccpetablePercent_Selectivity
                && updateRatio <= ProductConstants.AccpetablePercent_Usage
                && modifiedRowsRatio <= ProductConstants.AccpetablePercent_Modified)
            {
                summary = IndexUsefulness.High;
            }
            else if (frag < ProductConstants.CriticalPercent_Fragmentation
                    && selectivity > ProductConstants.CriticalPercent_Selectivity
                    && updateRatio < ProductConstants.CriticalPercent_Usage
                    && modifiedRowsRatio < ProductConstants.CriticalPercent_Modified)
            {
                summary = IndexUsefulness.Medium;
            }
            return summary;
        }

        private void advTreeIndexes_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            if (e.Node != null && e.Node != lastSelectedIndexNode)
            {
                lastSelectedIndexNode = e.Node;
                int SortColumnIndex = (dataGridViewX1.SortedColumn == null)
                                          ? 0
                                          : dataGridViewX1.SortedColumn.Index;
                ListSortDirection sortDirection = (dataGridViewX1.SortOrder == SortOrder.Ascending)
                                                      ? ListSortDirection.Ascending
                                                      : ListSortDirection.Descending;

                dataGridViewX1.SuspendLayout();
                disableUpdates = true;
                UpdateDashBoard(true);
                dataGridViewX1.ResumeLayout();
                disableUpdates = false;
                dataGridViewX1.Select();
                if (dataGridViewX1.Columns.Count >= SortColumnIndex)
                {
                    dataGridViewX1.Sort(dataGridViewX1.Columns[SortColumnIndex], sortDirection);
                }
                UpdateControlsAndMenus();
            }
        }

        private void dataGridViewX1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewX1.Columns["Index"].Index)
            {
                e.FormattingApplied = true;
                DataGridViewRow row = dataGridViewX1.Rows[e.RowIndex];
                Index i = (Index) (row.Cells["Index"].Value);
                e.Value = i.Name;
            }
            else if(e.ColumnIndex == dataGridViewX1.Columns["EstimatedSize"].Index)
            {
                e.FormattingApplied = true;
                e.Value = Helpers.StrFormatByteSize(Convert.ToInt64(e.Value));
            }
            else if (e.ColumnIndex == dataGridViewX1.Columns["FragmentationPercent"].Index)
            {
                e.FormattingApplied = true;
                double value = (double)e.Value;
                if (value == -10.0)
                {
                    e.Value = "Not Analyzed";
                }
                else if (value < 0.0)
                {
                    e.Value = "N/A";
                }
                else
                {
                    e.Value = string.Format("{0:P}", value);
                }
            }
            else if (e.ColumnIndex == dataGridViewX1.Columns["Selectivity"].Index)
            {
                e.FormattingApplied = true;                
                double value = (double)e.Value;
                if(value ==  0.0)
                {
                    e.Value = "Not Loaded";
                }
                else if (value < -0.0)
                {
                    e.Value = "No Statistics Available";
                }
                else
                {
                    e.Value = string.Format("{0:P}", value);
                }
            }        
            else if (e.ColumnIndex == dataGridViewX1.Columns["PercentModifiedRows"].Index)
            {
                e.FormattingApplied = true;
                double value = (double)e.Value;
                if (value < -0.0 || value > 1.0)
                {
                    e.Value = "N/A";
                }
                else
                {
                    e.Value = string.Format("{0:P}", value);
                }
            }
            else if (e.ColumnIndex == dataGridViewX1.Columns["UpdatesToAccesses"].Index)
            {
                e.FormattingApplied = true;
                double value = (double)e.Value;
                if (value < 0.0 || value > 1.0)
                {
                    e.Value = "N/A";
                }
                else
                {
                    e.Value = string.Format("{0:P}", value);
                }
            }
            else if (e.ColumnIndex == dataGridViewX1.Columns["Summary"].Index)
            {
                IndexUsefulness summary = (IndexUsefulness) e.Value;
                e.FormattingApplied = true;
                e.Value = "N/A";
                if (summary == IndexUsefulness.Medium)
                {
                    e.Value = "Medium";
                }
                else if (summary == IndexUsefulness.Low)
                {
                    e.Value = "Low";
                }
                else if (summary == IndexUsefulness.High)
                {
                    e.Value = "High";
                }
            }
            else if (e.ColumnIndex == dataGridViewX1.Columns["LastUpdated"].Index)
            {                
                if ((DateTime) e.Value == DateTime.MinValue)
                {
                    e.Value = "No Statistics Available";
                    e.FormattingApplied = true;
                }
            }
        }
        
        private void dataGridViewX1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (dataGridViewX1.Columns["FragmentationPercent"].Index ==
                        e.ColumnIndex && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewX1.Rows[e.RowIndex];
                double percent = Convert.ToDouble(row.Cells["FragmentationPercent"].Value);
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 0);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                DrawBar(row.Selected, e, percent, ProductConstants.CriticalPercent_Fragmentation, ProductConstants.AccpetablePercent_Fragmentation);

                // Paint Text
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            if (dataGridViewX1.Columns["Selectivity"].Index ==
                        e.ColumnIndex && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewX1.Rows[e.RowIndex];
                double percent = Convert.ToDouble(row.Cells["Selectivity"].Value) ;
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 0);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                if (percent > 1)
                {
                    //value is approximately one when rounded off but since the datatype is double it shows greater than 1
                    DrawBar(row.Selected, e, 1, ProductConstants.CriticalPercent_Selectivity, ProductConstants.AccpetablePercent_Selectivity);
                }
                else if (percent == 0.00)
                {
                    //Condition for percent == 0.00 i.e when the selectivity is not loaded
                    DrawBar(row.Selected, e, 2, ProductConstants.CriticalPercent_Selectivity, ProductConstants.AccpetablePercent_Selectivity);
                }
                else
                {
                    DrawBar(row.Selected, e, percent, ProductConstants.CriticalPercent_Selectivity, ProductConstants.AccpetablePercent_Selectivity);
                }
                // Paint Text
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            if (dataGridViewX1.Columns["PercentModifiedRows"].Index ==
                        e.ColumnIndex && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewX1.Rows[e.RowIndex];
                double percent = Convert.ToDouble(row.Cells["PercentModifiedRows"].Value) ;
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 0);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                DrawBar(row.Selected, e, percent, ProductConstants.CriticalPercent_Modified, ProductConstants.AccpetablePercent_Modified);

                // Paint Text
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            if (dataGridViewX1.Columns["UpdatesToAccesses"].Index ==
                                   e.ColumnIndex && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewX1.Rows[e.RowIndex];
                double percent = Convert.ToDouble(row.Cells["UpdatesToAccesses"].Value);
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 0);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                DrawBar(row.Selected, e, percent, ProductConstants.CriticalPercent_Usage, ProductConstants.AccpetablePercent_Usage);

                // Paint Text
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            if (dataGridViewX1.Columns["Summary"].Index ==
                                            e.ColumnIndex && e.RowIndex >= 0 )
            {
                double red = 1.0;
                double green = 1.0;
                double percent = 0.0;
                if ((IndexUsefulness)e.Value == IndexUsefulness.High)
                {
                    red = 0.0;
                    green = 1.0;
                }
                else if ((IndexUsefulness)e.Value == IndexUsefulness.Low)
                {
                    red = 1.0;
                    green = 0.0;                    
                }
                else if ((IndexUsefulness)e.Value == IndexUsefulness.NA)
                {
                    percent = -1.0;
                }
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 0);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                DrawBar(e.State == DataGridViewElementStates.Selected, e, percent, red, green);

                // Paint Text
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            if (dataGridViewX1.Columns["IsDisabled"].Index ==
                                  e.ColumnIndex && e.RowIndex >= 0 && (string)e.Value == "Yes")
            {

                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 0);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                DrawBar(e.State == DataGridViewElementStates.Selected, e, 0, 1.0, 0.0);

                // Paint Text
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
        }

        private void DrawBar(bool rowSelected, DataGridViewCellPaintingEventArgs e, double percent, double redThreshold, double greenThreshold)
        {
            const int offset = 2;
            int width = 0;

            // Get Size of bar to paint based on percent value
            if (percent > 0.0 && percent <= 1.0)
            {
                width = (int)((e.CellBounds.Width - (offset * 2)) * percent);
                width = (width < 2) ? 2 : width;
            }

            Rectangle barRect = new Rectangle(e.CellBounds.X + offset,
                                              e.CellBounds.Y + offset,
                                              width,
                                              e.CellBounds.Height - (offset * 2));
            // Get size for graph to hold bar
            Rectangle outLineRect = e.CellBounds;
            outLineRect.Inflate(-2, -2);

            // Get color for % graph
            Color barBackColor = Color.FromArgb(255, 255, 200);
            Color backColor = Color.Yellow;
            if (percent < 0.0 || percent > 1.0)
            {
                backColor = Color.Blue;
                barBackColor = Color.FromArgb(200, 200, 255);
            }
            else if (redThreshold == 1.0 && greenThreshold == 0.0)
            {
                backColor = Color.Red;
                barBackColor = Color.FromArgb(255, 200, 200);
            }
            else if (redThreshold == 1.0 && greenThreshold == 1.0)
            {
                barBackColor = Color.FromArgb(255, 255, 200);
                backColor = Color.Yellow;
            }
            else if (redThreshold == 0.0 && greenThreshold == 1.0)
            {
                backColor = Color.LimeGreen;
                barBackColor = Color.FromArgb(200, 255, 200);
            }
            else if (redThreshold < greenThreshold)
            {
                if (percent <= redThreshold)
                {
                    backColor = Color.Red;
                    barBackColor = Color.FromArgb(255, 200, 200);
                }
                else if (percent >= greenThreshold && percent >= 0.0)
                {
                    backColor = Color.LimeGreen;
                    barBackColor = Color.FromArgb(200, 255, 200);
                }
            }
            else
            {
                if (percent >= redThreshold)
                {
                    backColor = Color.Red;
                    barBackColor = Color.FromArgb(255, 200, 200);
                }
                else if (percent <= greenThreshold && percent >= 0.0)
                {
                    backColor = Color.LimeGreen;
                    barBackColor = Color.FromArgb(200, 255, 200);
                }
            }
            Color eraseColor = (rowSelected) ? e.CellStyle.BackColor : e.CellStyle.BackColor;
            // Paint Graph
            using (Brush backColorBrush = new SolidBrush(backColor),
                  eraseBrush = new SolidBrush(eraseColor),
                  barEraseBrush = new SolidBrush(barBackColor))
            {
                //                e.Graphics.FillRectangle(eraseBrush, e.CellBounds);
                e.Graphics.FillRectangle(barEraseBrush, outLineRect);
                e.Graphics.FillRectangle(backColorBrush, barRect);
                using (Pen pen = new Pen(Color.Silver))
                {
                    pen.Width = 1;
                    e.Graphics.DrawLine(pen, outLineRect.Left, outLineRect.Top - 1, outLineRect.Right, outLineRect.Top - 1);
                    e.Graphics.DrawLine(pen, outLineRect.Left, outLineRect.Top - 1, outLineRect.Left, outLineRect.Bottom - 1);
                    pen.Color = Color.LightSlateGray;
                    pen.Width = 2;
                    e.Graphics.DrawLine(pen, outLineRect.Left, outLineRect.Bottom - 1, outLineRect.Right, outLineRect.Bottom - 1);
                    e.Graphics.DrawLine(pen, outLineRect.Right, outLineRect.Bottom - 1, outLineRect.Right, outLineRect.Top);
                }
            }
        }

        private void buttonX_LoadSelectivity_Click(object sender, EventArgs e)
        {
            LoadingSelectivity();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateIndexStatistics();
        }

        private void buttonUpdateFullScan_Click(object sender, EventArgs e)
        {
            UpdateIndexStatisticsFullScan();
        }

        private void AnalyzeFragmentation()
        {
            DialogResult choice = Messaging.ShowHideableConfirmation(
               "showAnalysisWarning",
               "Analyzing Index Fragmentation can take a long time.\r\n\r\nDo you want to continue?",
               MessageBoxButtons.YesNo );
               
            if ( choice == System.Windows.Forms.DialogResult.Yes)
            {
                DataGridViewX activeDataGridView = GetActiveGrid();
                if (activeDataGridView != null)
                {
                    ProgressBar_Initialize(ProductConstants.AnalyzingIndexFragmentation, ProgressBar_CancelHandlerWorker);
                    selectedIndexes = new List<Index>();
                    areAllRowsSelected = dataGridViewX1.AreAllCellsSelected(false);
                    foreach (DataGridViewRow row in activeDataGridView.SelectedRows)
                    {
                        selectedIndexes.Add((Index)(row.Cells["Index"].Value));
                    }

                    workerThread =
                        new System.Threading.Thread(new System.Threading.ThreadStart(AnalyzeFragmentationWorker));
                    workerThread.Start();

                    ProgressBar_Show();

                    ShowWorkerThreadMessages("Analyzing Fragmentation");
                }
            }
        }

        private void LoadingSelectivity()
        {
            DialogResult choice = Messaging.ShowHideableConfirmation(
               "showSelectivityWarning",
               "Loading Index Selectivity can take a long time.\r\n\r\nDo you want to continue?",
               MessageBoxButtons.YesNo );
               
            if ( choice == System.Windows.Forms.DialogResult.Yes)
            {
                DataGridViewX activeDataGridView = GetActiveGrid();
                if (activeDataGridView != null)
                {
                    ProgressBar_Initialize(ProductConstants.LoadingIndexSelectivity, ProgressBar_CancelHandlerWorker);
                    selectedIndexes = new List<Index>();
                    areAllRowsSelected = dataGridViewX1.AreAllCellsSelected(false);
                    foreach (DataGridViewRow row in activeDataGridView.SelectedRows)
                    {
                        selectedIndexes.Add((Index)(row.Cells["Index"].Value));
                    }

                    workerThread =
                        new System.Threading.Thread(new System.Threading.ThreadStart(LoadSelectivityWorker));
                    workerThread.Start();

                    ProgressBar_Show();

                    ShowWorkerThreadMessages("Loading Selectivity");
                }
            }
        }

        private void UpdateIndexStatistics()
        {
            DialogResult choice = Messaging.ShowHideableConfirmation(
               "showUpdateWarning",
               "Updating index statistics can take a long time.\r\n\r\nDo you want to continue?",
               MessageBoxButtons.YesNo );
               
            if ( choice == System.Windows.Forms.DialogResult.Yes)
            {
                DataGridViewX activeDataGridView = GetActiveGrid();
                if (activeDataGridView != null)
                {
                    ProgressBar_Initialize(ProductConstants.UpdatingStatistics, ProgressBar_CancelHandlerWorker);
                    selectedIndexes = new List<Index>();
                    areAllRowsSelected = dataGridViewX1.AreAllCellsSelected(false); 
                    foreach (DataGridViewRow row in activeDataGridView.SelectedRows)
                    {
                        selectedIndexes.Add((Index) (row.Cells["Index"].Value));
                    }

                    workerThread =
                        new System.Threading.Thread(new System.Threading.ThreadStart(UpdateStatisticsWorker));
                    workerThread.Start();

                    ProgressBar_Show();

                    ShowWorkerThreadMessages("Updating Statistics using Sampling");
                }
            }            
        }

        private void UpdateIndexStatisticsFullScan()
        {
            DialogResult choice = Messaging.ShowHideableConfirmation(
               "showUpdateWarning",
               "Updating index statistics can take a long time.\r\n\r\nDo you want to continue?",
               MessageBoxButtons.YesNo );
               
            if ( choice == System.Windows.Forms.DialogResult.Yes)
            {
                DataGridViewX activeDataGridView = GetActiveGrid();
                if (activeDataGridView != null)
                {
                    ProgressBar_Initialize(ProductConstants.UpdatingStatistics, ProgressBar_CancelHandlerWorker);
                    selectedIndexes = new List<Index>();
                    areAllRowsSelected = dataGridViewX1.AreAllCellsSelected(false); 
                    foreach (DataGridViewRow row in activeDataGridView.SelectedRows)
                    {
                        selectedIndexes.Add((Index) (row.Cells["Index"].Value));
                    }

                    workerThread =
                        new System.Threading.Thread(new System.Threading.ThreadStart(UpdateStatisticsFullScanWorker));
                    workerThread.Start();

                    ProgressBar_Show();

                    ShowWorkerThreadMessages("Updating Statistics using Full Scan");
                }
            }
        }

        private void AnalyzeFragmentationWorker()
        {
            try
            {
                
                if (selectedIndexes != null && selectedIndexes.Count > 0)
                {
                    using (
                        SqlConnection conn =
                            new SqlConnection(
                                Connection.CreateConnectionString(_serverName, string.Empty,
                                                                  ProductConstants.globalSqlCredentials)))
                    {
                        Connection.Impersonate(ProductConstants.globalSqlCredentials);

                        conn.Open();

                        foreach (Index i in selectedIndexes)
                        {
                            if (ProductConstants.globalCancelRequested == true)
                            {
                                ProductConstants.globalOperationCancelled = true;
                                break;
                            }
                            if (!i.IsDisabled)
                            {
                                m_DelegateUpdateProgressBarText("Analyzing Fragmentation...", string.Format("'{0}.{1}.{2}.{3}'",
                                                                                i.DatabaseName, i.SchemaName, i.TableName, i.Name));
                                i.Analyze(conn);
                            }
                            else
                            {
                                ProductConstants.globalErrorReports.Add(
                                    string.Format("Error Analyzing index {0}.{1}.{2}.{3}",
                                                  i.DatabaseName, i.SchemaName, i.TableName, i.Name),
                                    "Analyzing Fragmentation is not allowed for disabled indexes.");
                            }
                        }
                    }
                    if (ProductConstants.globalCancelRequested == true)
                    {
                        ProductConstants.globalOperationCancelled = true;
                    }
                    this.Invoke(m_DelegateUpdateStatsWorkerThreadFinished, new object[] { "Analyzing Fragmentation" });
                }               
            }
            catch (ThreadAbortException)
            {
                this.Invoke(m_DelegateUpdateStatsWorkerThreadFinished, new object[] { string.Empty });
            }
            catch (Exception ex)
            {
                this.Invoke(m_DelegateUpdateStatsWorkerThreadFinished, new object[] { string.Empty });
                this.Invoke(m_DelegateShowExpection,
                            new object[] { "Analyzing Fragmentation", ex });
            }
            finally
            {
                ProgressBar_Close();
            }
        }

        private void LoadSelectivityWorker()
        {
            try
            {
                if (selectedIndexes != null && selectedIndexes.Count > 0)
                {
                    int defaultDensity = -2;
                    using (
                        SqlConnection conn =
                            new SqlConnection(
                                Connection.CreateConnectionString(_serverName, string.Empty,
                                                                  ProductConstants.globalSqlCredentials)))
                    {
                        Connection.Impersonate(ProductConstants.globalSqlCredentials);

                        conn.Open();

                        foreach (Index i in selectedIndexes)
                        {
                            if (ProductConstants.globalCancelRequested == true)
                            {
                                ProductConstants.globalOperationCancelled = true;
                                break;
                            }
                            if (!i.IsDisabled)
                            {
                                m_DelegateUpdateProgressBarText("Loading Selectivity...", string.Format("'{0}.{1}.{2}.{3}'",
                                                                                i.DatabaseName, i.SchemaName, i.TableName, i.Name));
                                i.GetStatistics(conn, defaultDensity);
                            }
                            else
                            {
                                ProductConstants.globalErrorReports.Add(
                                    string.Format("Error Loading Statistics for index {0}.{1}.{2}.{3}",
                                                  i.DatabaseName, i.SchemaName, i.TableName, i.Name),
                                    "Loading Selectivity is not allowed for disabled indexes.");
                            }
                        }
                    }
                    if (ProductConstants.globalCancelRequested == true)
                    {
                        ProductConstants.globalOperationCancelled = true;
                    }
                    this.Invoke(m_DelegateUpdateStatsWorkerThreadFinished, new object[] { "Loading Selectivity" });
                }
            }
            catch (ThreadAbortException)
            {
                this.Invoke(m_DelegateUpdateStatsWorkerThreadFinished, new object[] { string.Empty });
            }
            catch (Exception ex)
            {
                this.Invoke(m_DelegateUpdateStatsWorkerThreadFinished, new object[] { string.Empty });
                this.Invoke(m_DelegateShowExpection,
                            new object[] { "Loading Selectivity", ex });
            }
            finally
            {
                ProgressBar_Close();
            }
        }

        private void UpdateStatisticsWorker()
        {
            try
            {
                if (selectedIndexes != null && selectedIndexes.Count > 0)
                {
                    using (
                        SqlConnection conn =
                            new SqlConnection(
                                Connection.CreateConnectionString(_serverName, string.Empty,
                                                                  ProductConstants.globalSqlCredentials)))
                    {
                        Connection.Impersonate(ProductConstants.globalSqlCredentials);

                        conn.Open();

                        foreach (Index i in selectedIndexes)
                        {
                            if (ProductConstants.globalCancelRequested == true)
                            {
                                ProductConstants.globalOperationCancelled = true;
                                break;
                            }
                            if (!i.IsDisabled)
                            {
                                m_DelegateUpdateProgressBarText("Updating Statistics...", string.Format("'{0}.{1}.{2}.{3}'",
                                                                                i.DatabaseName, i.SchemaName, i.TableName, i.Name));
                                i.Update(false, conn);
                            }
                            else
                            {
                                ProductConstants.globalErrorReports.Add(
                                    string.Format("Error Updating Statistics for index {0}.{1}.{2}.{3}",
                                                  i.DatabaseName, i.SchemaName, i.TableName, i.Name),
                                    "Updating Statistics is not allowed for disabled indexes.");
                            }
                        }
                    }
                    if (ProductConstants.globalCancelRequested == true)
                    {
                        ProductConstants.globalOperationCancelled = true;
                    }
                    this.Invoke(m_DelegateUpdateStatsWorkerThreadFinished, new object[] { "Upadating Statistics" });
                }
            }
            catch (ThreadAbortException)
            {
                this.Invoke(m_DelegateUpdateStatsWorkerThreadFinished, new object[] { string.Empty });
            }
            catch (Exception ex)
            {
                this.Invoke(m_DelegateUpdateStatsWorkerThreadFinished, new object[] {string.Empty});
                this.Invoke(m_DelegateShowExpection,
                            new object[] {"Updating Statistics", ex});
            }
            finally
            {
                ProgressBar_Close();
            }
        }

        private void UpdateStatisticsFullScanWorker()
        {
            try
            {
                if (selectedIndexes != null && selectedIndexes.Count > 0)
                {
                    using (
                        SqlConnection conn =
                            new SqlConnection(
                                Connection.CreateConnectionString(_serverName, string.Empty,
                                                                  ProductConstants.globalSqlCredentials)))
                    {
                        Connection.Impersonate(ProductConstants.globalSqlCredentials);

                        conn.Open();

                        foreach (Index i in selectedIndexes)
                        {
                            if (ProductConstants.globalCancelRequested == true)
                            {
                                ProductConstants.globalOperationCancelled = true;
                                break;
                            }
                            if (!i.IsDisabled)
                            {
                                m_DelegateUpdateProgressBarText("Updating Statistics (FullScan)...", string.Format("'{0}.{1}.{2}.{3}'",
                                                                                i.DatabaseName, i.SchemaName, i.TableName, i.Name));
                                i.Update(true, conn);
                            }
                            else
                            {
                                ProductConstants.globalErrorReports.Add(
                                    string.Format("Error Updating Statistics for index {0}.{1}.{2}.{3}",
                                                  i.DatabaseName, i.SchemaName, i.TableName, i.Name),
                                    "Updating Statistics is not allowed for disabled indexes.");
                            }
                        }
                    }
                    if (ProductConstants.globalCancelRequested == true)
                    {
                        ProductConstants.globalOperationCancelled = true;
                    }
                    this.Invoke(m_DelegateUpdateStatsWorkerThreadFinished, new object[] { "Upadating Statistics (FullScan)" });
                }               
            }
            catch (ThreadAbortException)
            {
                this.Invoke(m_DelegateUpdateStatsWorkerThreadFinished, new object[] { string.Empty });
            }
            catch (Exception ex)
            {
                this.Invoke(m_DelegateUpdateStatsWorkerThreadFinished, new object[] { string.Empty });
                this.Invoke(m_DelegateShowExpection,
                            new object[] { "Updating Statistics (FullScan)", ex });
            }
            finally
            {
                ProgressBar_Close();
            }
        }

        private void UpdateStatisticsFinished(string opText)
        {
            try
            {
                DataGridViewX activeDataGridView = GetActiveGrid();
                ProgressBar_UpdateText(string.Format("{0} Completing...", opText), string.Empty);
                Index curIndex = null;
                if (activeDataGridView.CurrentRow != null)
                {
                    curIndex = (Index) activeDataGridView.CurrentRow.Cells["Index"].Value;
                    if (activeDataGridView.CurrentRow.Index == 0 && activeDataGridView.Rows.Count > 1)
                    {
                        activeDataGridView.CurrentCell = activeDataGridView.Rows[1].Cells[0];
                    }
                    else
                    {
                        activeDataGridView.CurrentCell = activeDataGridView.Rows[0].Cells[0];
                    }
                }
                activeDataGridView.ClearSelection();
                _bindingSource.RemoveFilter();
                if (areAllRowsSelected || selectedIndexes.Count > 20)
                {
                    if (activeDataGridView == dataGridViewX1)
                    {
                        UpdateDashBoard(true);
                    }
                    else
                    {
                        UpdateColumnsFromTreeNode(advTreeColumns.SelectedNode);
                    }
                }
                else
                {
                    foreach (Index i in selectedIndexes)
                    {
                        foreach (DataGridViewRow row in activeDataGridView.Rows)
                        {
                            if (row.Index >= 0)
                            {
                                Index idx = (Index) (row.Cells["Index"].Value);
                                if (idx != null && idx.DatabaseId == i.DatabaseId && idx.TableId == i.TableId && idx.Id == i.Id)
                                {
                                    UpdateRow(row, i);
                                    activeDataGridView.InvalidateRow(row.Index);
                                    break;
                                }
                            }
                        }
                    }
                }
                ProgressBar_UpdateText("Updating UI...", string.Empty);
                SetFilterOptions();
                activeDataGridView.Update();
                if (areAllRowsSelected)
                {
                    activeDataGridView.SelectAll();
                }
                else
                {
                    if (curIndex != null)
                    {
                        foreach (DataGridViewRow row in activeDataGridView.Rows)
                        {
                            if (row.Index >= 0)
                            {
                                Index idx = (Index) (row.Cells["Index"].Value);
                                if (idx != null && idx.DatabaseId == curIndex.DatabaseId && idx.TableId == curIndex.TableId &&
                                    idx.Id == curIndex.Id)
                                {
                                    activeDataGridView.CurrentCell = row.Cells[0];
                                    break;
                                }
                            }
                        }
                    }
                    //activeDataGridView.Update();
                    foreach (Index i in selectedIndexes)
                    {
                        foreach (DataGridViewRow row in activeDataGridView.Rows)
                        {
                            if (row.Index >= 0)
                            {
                                Index idx = (Index) (row.Cells["Index"].Value);
                                if (idx != null && idx.DatabaseId == i.DatabaseId && idx.TableId == i.TableId && idx.Id == i.Id)
                                {
                                    row.Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                }             
            }
            catch (Exception ex)
            {
                ProductConstants.globalErrorReports.Add("Error updating grid", Helpers.GetCombinedExceptionText(ex));
            }
        }

        private void ShowWorkerThreadMessages(string opText)
        {
            ProgressBar_Close();

            if (!ProductConstants.globalOperationCancelled && !string.IsNullOrEmpty(opText))
            {
                string msg = string.Format("{0} completed for selected indexes", opText);
                Messaging.ShowInformation(this, msg);
            }
            if (ProductConstants.globalOperationCancelled)
            {
                string msg = string.Format("{0} cancelled by user", opText);
                Messaging.ShowInformation(this, msg);
                ProductConstants.globalErrorReports.Clear();
            }
            else if (ProductConstants.globalErrorReports.Count > 0)
            {
                Core.Form_MultipleErrorHandler errorDlg = new Core.Form_MultipleErrorHandler();
                errorDlg.Title = string.Format("{0} Errors", opText);
                errorDlg.Errors = ProductConstants.globalErrorReports;
                errorDlg.ShowDialog(this);
                ProductConstants.globalErrorReports.Clear();
            }            
        }

        private void UpdateRow(DataGridViewRow row, Index i)
        {
            if (GetActiveGrid() == dataGridViewX2)
            {
                if (row.Cells != null)
                {
                    row.Cells["Selectivity"].Value = _selectivity.calculate_selectivity(i.AverageDensity,i.Rows);
                    row.Cells["ModifiedRows"].Value = i.ModifiedRows;
                }
            }
            else
            {
                if (row.Cells != null)
                {
                    row.Cells["Rows"].Value = i.Rows;
                    row.Cells["ModifiedRows"].Value = i.ModifiedRows;
                    row.Cells["PercentModifiedRows"].Value = i.Rows == 0
                                                                 ? -1.0 : i.ModifiedRows > i.Rows
                                                                       ? 1.0 : (double) i.ModifiedRows/i.Rows;
                    row.Cells["Selectivity"].Value =_selectivity.calculate_selectivity(i.AverageDensity,i.Rows);
                    row.Cells["Summary"].Value = (int) CalculateIndexUsefulnessSummary(i);
                    row.Cells["LastUpdated"].Value = i.LastStatisticsUpdate;
                    row.Cells["FragmentationPercent"].Value = i.AverageFragLevel;
                }
            }
        }

        private DataGridViewX GetActiveGrid()
        {
            DataGridViewX activeDataGridView = dataGridViewX1.Visible ? dataGridViewX1 : null;
            if (activeDataGridView == null)
            {
                activeDataGridView = dataGridViewX2.Visible ? dataGridViewX2 : null;
            }
            return activeDataGridView;
        }

        private void contextMenuCSV_Click(object sender, EventArgs e)
        {
            DataGridViewX activeDataGridView = GetActiveGrid();

            if (activeDataGridView != null)
            {
                ExportToCSV.CopyDataGridView(activeDataGridView);
            }
        }

        private void contextMenuXML_Click(object sender, EventArgs e)
        {
            DataGridViewX activeDataGridView = GetActiveGrid();

            if (activeDataGridView != null)
            {
                ExportToXML.CopyDataGridView(activeDataGridView, "FragmentationSummary");
            }
        }
        
        private void contextMenuCopy_Click(object sender, EventArgs e)
        {
            DataGridViewX activeDataGridView = GetActiveGrid();

            if (activeDataGridView != null)
            {
                ExportToClipboard.CopyDataGridViewToTabbedFormat(activeDataGridView, true);
            }
        }
        
        private void contextMenuSelectAll_Click(object sender, EventArgs e)
        {
            DataGridViewX activeDataGridView = GetActiveGrid();

            if (activeDataGridView != null)
            {
                activeDataGridView.SelectAll();
            }
        }

        private void buttonCopyToClipboard_Click(object sender, EventArgs e)
        {
            DataGridViewX activeDataGridView = GetActiveGrid();

            if (activeDataGridView != null)
            {
                ExportToClipboard.CopyDataGridViewToTabbedFormat(activeDataGridView, false);
            }
        }

        private void editCopyMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewX activeDataGridView = GetActiveGrid();

            if (activeDataGridView != null)
            {
                ExportToClipboard.CopyDataGridViewToTabbedFormat(activeDataGridView, true);
            }
        }

        private void editSelectAllMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewX activeDataGridView = GetActiveGrid();

            if (activeDataGridView != null)
            {
                activeDataGridView.SelectAll();
            }
        }

        private void fileSavetoCVSMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewX activeDataGridView = GetActiveGrid();

            if (activeDataGridView != null)
            {
                ExportToCSV.CopyDataGridView(activeDataGridView);
            }
        }

        private void fileSavetoXMLMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewX activeDataGridView = GetActiveGrid();

            if (activeDataGridView != null)
            {
                ExportToXML.CopyDataGridView(activeDataGridView, "FragmentationSummary");
            }

        }

        private void fileSavetoDatatableMenuItem_Click(object sender, EventArgs e)
        {
            ExportToTable.CreateTableDelegate ctd = new ExportToTable.CreateTableDelegate(this.CreateTable);
            ExportToTable.PopulateTableDelegate ptd = new ExportToTable.PopulateTableDelegate(this.PopulateTable);

            ExportToTable.Export(ctd, ptd);

        }

        #region Export Support

        public void
           CreateTable(
              SqlConnection conn,
              string tableName //include owner name

           )
        {


            string sql = "CREATE TABLE {0}( " +
                          "  [Database] [nvarchar](256)   NULL, " +
                          "  [Schema] [nvarchar](256)   NULL, " +
                          "  [Table] [nvarchar](256)   NULL, " +
                          "  [Index] [nvarchar] (256)   NULL, " +
                          "  [IsClustered] [nvarchar](12)   NULL, " +
                          "  [CountPages] [int] NULL, " +
                          "  [EstimatedSize] [int] NULL, " +
                          "  [FragmentationPercent] [float] NULL " +                          
                          ")";

            string cmd = String.Format(sql, tableName);

            using (SqlCommand command = new SqlCommand(cmd, conn))
            {
                command.CommandTimeout = ToolsetOptions.commandTimeout;
                command.ExecuteNonQuery();
            }
        }


        static StringBuilder props = new StringBuilder(2048);
        static StringBuilder values = new StringBuilder(2048);

        public void
           PopulateTable(
              SqlConnection conn,
              string tableName //include owner name
           )
        {
            DataGridViewX activeDataGridView = GetActiveGrid();

            if (activeDataGridView != null)
            {
                foreach (DataGridViewRow row in activeDataGridView.Rows)
                {
                    props.Length = 0;
                    values.Length = 0;

                    Index index = (Index) (row.Cells["Index"].Value);
                    if (index != null)
                    {
                        PopulateTable_AddProperty("Database", SQLHelpers.CreateSafeString(index.DatabaseName));
                        PopulateTable_AddProperty("Schema", SQLHelpers.CreateSafeString(index.SchemaName));
                        PopulateTable_AddProperty("Table", SQLHelpers.CreateSafeString(index.TableName));
                        PopulateTable_AddProperty("Index", SQLHelpers.CreateSafeString(index.Name));
                        PopulateTable_AddProperty("IsClustered",
                                                  SQLHelpers.CreateSafeString(index.IsClustered ? "Yes" : "No"));
                        PopulateTable_AddProperty("CountPages", index.CountPages.ToString());
                        PopulateTable_AddProperty("EstimatedSize",
                                                  (index.CountPages*ProductConstants.IndexPageSize).ToString());
                        PopulateTable_AddProperty("FragmentationPercent", index.AverageFragLevel.ToString());


                        string sql = String.Format("INSERT INTO {0} ({1}) VALUES ({2})",
                                                   tableName,
                                                   props.ToString(),
                                                   values.ToString());

                        using (SqlCommand command = new SqlCommand(sql, conn))
                        {
                            command.CommandTimeout = ToolsetOptions.commandTimeout;
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        static private void
           PopulateTable_AddProperty(
             string propertyName,
             string propertyValue
           )
        {
            if (props.Length != 0)
                props.AppendFormat(",[{0}]", propertyName);
            else
                props.AppendFormat("[{0}]", propertyName);

            if (values.Length != 0)
                values.AppendFormat(",{0}", propertyValue);
            else
                values.AppendFormat("{0}", propertyValue);

        }

        #endregion      

        private void dataGridViewX2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           if (e.ColumnIndex == dataGridViewX2.Columns["Selectivity"].Index)
            {
                e.FormattingApplied = true;
                double value = Convert.ToDouble(e.Value);
                if (value == 0.0)
                {
                    e.Value = "Not Loaded";
                }
                else if (value < -0.0)
                {
                    e.Value = "No Statistics Available";
                }
                else
                {
                    e.Value = string.Format("{0:P}", value);
                }
            }        
        }

        private void dataGridViewX2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (dataGridViewX2.Columns["Selectivity"].Index ==
                       e.ColumnIndex && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewX2.Rows[e.RowIndex];
                double percent = Convert.ToDouble(row.Cells["Selectivity"].Value);
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 0);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                if (percent > 1)
                {
                    //value is approximately one when rounded off but since the datatype is double it shows greater than 1
                    DrawBar(row.Selected, e, 1, 0.60,0.90);
                }
                else if (percent == 0.00)
                {
                    //Condition for percent == 0.00 i.e when the selectivity is not loaded
                    DrawBar(row.Selected, e, 2, 0.60,0.90);
                }
                else
                {
                    DrawBar(row.Selected, e, percent, 0.60,0.90);
                }

                // Paint Text
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
        }

        private void UpdateColumnsFromTreeNode(Node node)
        {
            if(node != null)
            {
                int SortColumnIndex = (dataGridViewX2.SortedColumn == null)
                                          ? 0
                                          : dataGridViewX2.SortedColumn.Index;
                ListSortDirection sortDirection = (dataGridViewX2.SortOrder == SortOrder.Ascending)
                                                      ? ListSortDirection.Ascending
                                                      : ListSortDirection.Descending;

                int acceptableCount = 0;
                int cautionCount = 0;
                int criticalCount = 0;
                string filter = string.Empty;
                if (node.Tag is Server)
                {
                    Server s = (Server) node.Tag;
                    acceptableCount = s.NumberAcceptableStats_Selectivity;
                    cautionCount = s.NumberCautionStats_Selectivity;
                    criticalCount = s.NumberCriticalStats_Selectivity;
                    dataGridViewX2.DataSource = CreateDataTableFromIndex(s.Stats);
                    filter = string.Format("SQL Server '{0}'", _serverName);
                }
                else if (node.Tag is Database)
                {
                    Database d = (Database) node.Tag;
                    acceptableCount = d.NumberAcceptableStats_Selectivity;
                    cautionCount = d.NumberCautionStats_Selectivity;
                    criticalCount = d.NumberCriticalStats_Selectivity;
                    dataGridViewX2.DataSource = CreateDataTableFromIndex(d.Stats);
                    filter = string.Format("Database '{0}'", d.Name);
                }
                else if (node.Tag is Table)
                {
                    Table t = (Table) node.Tag;
                    acceptableCount = t.NumberAcceptableStats_Selectivity;
                    cautionCount = t.NumberCautionStats_Selectivity;
                    criticalCount = t.NumberCriticalStats_Selectivity;

                    dataGridViewX2.DataSource = CreateDataTableFromIndex(t.Stats);
                    filter = string.Format("Table '{0}'", t.Name);
                }

                _gridColumnsLabelBaseText = string.Format("Column statistics for {0}", filter);
                UpdateColumnLabel();

                labelX_ColumnCritical.Text = string.Format(ProductConstants.StatisticCriticalText_Selectivity, criticalCount < 0 ? "?" : criticalCount.ToString(), criticalCount == 1 ? string.Empty : "s");
                labelX_ColumnCaution.Text = string.Format(ProductConstants.StatisticCautionText_Selectivity, cautionCount < 0 ? "?" : cautionCount.ToString(), cautionCount == 1 ? string.Empty : "s");
                labelX_ColumnAcceptable.Text = string.Format(ProductConstants.StatisticAcceptableText_Selectivity, acceptableCount < 0 ? "?" : acceptableCount.ToString(), acceptableCount == 1 ? string.Empty : "s");

                if (dataGridViewX2.Columns.Count > 0 && dataGridViewX2.Columns.Count >= SortColumnIndex)
                {
                    dataGridViewX2.Sort(dataGridViewX2.Columns[SortColumnIndex], sortDirection);
                }
            }
        }

        private void advTreeColumns_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            if (e.Node != null)
            {
                UpdateColumnsFromTreeNode(e.Node);
            }
        }
       
        private void comboBoxExFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetGridColumns();
            SetFilterOptions();
            UpdateControlsAndMenus();
        }

        private void dataGridViewX2_SelectionChanged(object sender, EventArgs e)
        {
            UpdateControlsAndMenus();
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateControlsAndMenus();
        }

        private void tabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
            UpdateControlsAndMenus();
        }

        #region Dashboard Delagate Functions

        private int GetCritcalSummaryIndexes(object obj)
        {
            if (obj is Server)
            {
                Server s = (Server)obj;
                return s.NumberCriticalSummaryIndexes;
            }
            else if (obj is Database)
            {
                Database d = (Database)obj;
                return d.NumberCriticalSummaryIndexes;
            }
            else if (obj is Table)
            {
                Table t = (Table)obj;
                return t.NumberCriticalSummaryIndexes;
            }
            else
            {
                return -1;
            }
        }

        private int GetCautionSummaryIndexes(object obj)
        {
            if (obj is Server)
            {
                Server s = (Server)obj;
                return s.NumberCautionSummaryIndexes;
            }
            else if (obj is Database)
            {
                Database d = (Database)obj;
                return d.NumberCautionSummaryIndexes;
            }
            else if (obj is Table)
            {
                Table t = (Table)obj;
                return t.NumberCautionSummaryIndexes;
            }
            else
            {
                return -1;
            }
        }

        private int GetAcceptableSummaryIndexes(object obj)
        {
            if (obj is Server)
            {
                Server s = (Server)obj;
                return s.NumberAcceptableSummaryIndexes;
            }
            else if (obj is Database)
            {
                Database d = (Database)obj;
                return d.NumberAcceptableSummaryIndexes;
            }
            else if (obj is Table)
            {
                Table t = (Table)obj;
                return t.NumberAcceptableSummaryIndexes;
            }
            else
            {
                return -1;
            }
        }

        private int GetCritcalFragIndexes(object obj)
        {
            if (obj is Server)
            {
                Server s = (Server)obj;
                return s.NumberCriticalIndexes;
            }
            else if (obj is Database)
            {
                Database d = (Database)obj;
                return d.NumberCriticalIndexes;
            }
            else if (obj is Table)
            {
                Table t = (Table)obj;
                return t.NumberCriticalIndexes;
            }
            else
            {
                return -1;
            }
        }

        private int GetCautionFragIndexes(object obj)
        {
            if (obj is Server)
            {
                Server s = (Server)obj;
                return s.NumberCautionIndexes;
            }
            else if (obj is Database)
            {
                Database d = (Database)obj;
                return d.NumberCautionIndexes;
            }
            else if (obj is Table)
            {
                Table t = (Table)obj;
                return t.NumberCautionIndexes;
            }
            else
            {
                return -1;
            }
        }

        private int GetAcceptableFragIndexes(object obj)
        {
            if (obj is Server)
            {
                Server s = (Server)obj;
                return s.NumberAcceptableIndexes;
            }
            else if (obj is Database)
            {
                Database d = (Database)obj;
                return d.NumberAcceptableIndexes;
            }
            else if (obj is Table)
            {
                Table t = (Table)obj;
                return t.NumberAcceptableIndexes;
            }
            else
            {
                return -1;
            }
        }

        private int GetCritcalSelectivityIndexes(object obj)
        {
            if (obj is Server)
            {
                Server s = (Server)obj;
                return s.NumberCriticalIndexes_Selectivity;
            }
            else if (obj is Database)
            {
                Database d = (Database)obj;
                return d.NumberCriticalIndexes_Selectivity;
            }
            else if (obj is Table)
            {
                Table t = (Table)obj;
                return t.NumberCriticalIndexes_Selectivity;
            }
            else
            {
                return -1;
            }
        }

        private int GetCautionSelectivityIndexes(object obj)
        {
            if (obj is Server)
            {
                Server s = (Server)obj;
                return s.NumberCautionIndexes_Selectivity;
            }
            else if (obj is Database)
            {
                Database d = (Database)obj;
                return d.NumberCautionIndexes_Selectivity;
            }
            else if (obj is Table)
            {
                Table t = (Table)obj;
                return t.NumberCautionIndexes_Selectivity;
            }
            else
            {
                return -1;
            }
        }

        private int GetAcceptableSelectivityIndexes(object obj)
        {
            if (obj is Server)
            {
                Server s = (Server)obj;
                return s.NumberAcceptableIndexes_Selectivity;
            }
            else if (obj is Database)
            {
                Database d = (Database)obj;
                return d.NumberAcceptableIndexes_Selectivity;
            }
            else if (obj is Table)
            {
                Table t = (Table)obj;
                return t.NumberAcceptableIndexes_Selectivity;
            }
            else
            {
                return -1;
            }
        }

        private int GetCritcalUsageIndexes(object obj)
        {
            if (obj is Server)
            {
                Server s = (Server)obj;
                return s.NumberCriticalIndexes_Usage;
            }
            else if (obj is Database)
            {
                Database d = (Database)obj;
                return d.NumberCriticalIndexes_Usage;
            }
            else if (obj is Table)
            {
                Table t = (Table)obj;
                return t.NumberCriticalIndexes_Usage;
            }
            else
            {
                return -1;
            }
        }

        private int GetCautionUsageIndexes(object obj)
        {
            if (obj is Server)
            {
                Server s = (Server)obj;
                return s.NumberCautionIndexes_Usage;
            }
            else if (obj is Database)
            {
                Database d = (Database)obj;
                return d.NumberCautionIndexes_Usage;
            }
            else if (obj is Table)
            {
                Table t = (Table)obj;
                return t.NumberCautionIndexes_Usage;
            }
            else
            {
                return -1;
            }
        }

        private int GetAcceptableUsageIndexes(object obj)
        {
            if (obj is Server)
            {
                Server s = (Server)obj;
                return s.NumberAcceptableIndexes_Usage;
            }
            else if (obj is Database)
            {
                Database d = (Database)obj;
                return d.NumberAcceptableIndexes_Usage;
            }
            else if (obj is Table)
            {
                Table t = (Table)obj;
                return t.NumberAcceptableIndexes_Usage;
            }
            else
            {
                return -1;
            }
        }

        private int GetCritcalModifiedIndexes(object obj)
        {
            if (obj is Server)
            {
                Server s = (Server)obj;
                return s.NumberCriticalIndexes_Modified;
            }
            else if (obj is Database)
            {
                Database d = (Database)obj;
                return d.NumberCriticalIndexes_Modified;
            }
            else if (obj is Table)
            {
                Table t = (Table)obj;
                return t.NumberCriticalIndexes_Modified;
            }
            else
            {
                return -1;
            }
        }

        private int GetCautionModifiedIndexes(object obj)
        {
            if (obj is Server)
            {
                Server s = (Server)obj;
                return s.NumberCautionIndexes_Modified;
            }
            else if (obj is Database)
            {
                Database d = (Database)obj;
                return d.NumberCautionIndexes_Modified;
            }
            else if (obj is Table)
            {
                Table t = (Table)obj;
                return t.NumberCautionIndexes_Modified;
            }
            else
            {
                return -1;
            }
        }

        private int GetAcceptableModifiedIndexes(object obj)
        {
            if (obj is Server)
            {
                Server s = (Server)obj;
                return s.NumberAcceptableIndexes_Modified;
            }
            else if (obj is Database)
            {
                Database d = (Database)obj;
                return d.NumberAcceptableIndexes_Modified;
            }
            else if (obj is Table)
            {
                Table t = (Table)obj;
                return t.NumberAcceptableIndexes_Modified;
            }
            else
            {
                return -1;
            }
        }

        #endregion

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewX1.Rows[e.RowIndex];
                Index i = (Index) row.Cells["Index"].Value;
                ShowIndexProperties(i);
            }
        }

        private void ShowIndexProperties(Index i)
        {
            Form_IndexProperties idxForm = new Form_IndexProperties(i);
            idxForm.ShowDialog(this);
            
        }

        private void contextMenuUpdateStatistics_Click(object sender, EventArgs e)
        {
            UpdateIndexStatistics();
        }

        private void contextMenuUpdateStatisticsFullScan_Click(object sender, EventArgs e)
        {
            UpdateIndexStatisticsFullScan();
        }

        private void menuUpdateStatistics_Click(object sender, EventArgs e)
        {
            UpdateIndexStatistics();
        }       

        private void menuUpdateStatisticsFullScan_Click(object sender, EventArgs e)
        {
            UpdateIndexStatisticsFullScan();
        }

        private void menuLoadingSelectivity_Click(object sender, EventArgs e)
        {
            LoadingSelectivity();
        }

        private void contextMenuLoadingSelectivity_Click(object sender, EventArgs e)
        {
            LoadingSelectivity();
        }

        private void menuIndexProperties_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridViewX1.SelectedRows[0];
                Index i = (Index) (row.Cells["Index"].Value);
                ShowIndexProperties(i);
            }
        }

        private void contextMenuIndexProperties_Click(object sender, EventArgs e)
        {
            if (theCellImHoveringOver != null && theCellImHoveringOver.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewX1.Rows[theCellImHoveringOver.RowIndex];
                Index i = (Index) (row.Cells["Index"].Value);
                ShowIndexProperties(i);
            }
        }

        private void dataGridViewX1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                contextMenuIndexProperties.Visible = false;
            }
            else
            {
                contextMenuIndexProperties.Visible = true;
                theCellImHoveringOver = e;
            }
        }

        private void SetFilterOptions()
        {
            string temp = string.Empty;
            if (ProductConstants.globalHideDisabled)
            {
                temp = "IsDisabled = 'No'";
            }
            if (ProductConstants.globalHideBasedOnRowThreshold)
            {
                if (!string.IsNullOrEmpty(temp))
                {
                    temp += " and ";
                }
                temp += string.Format("Rows >= {0}", ProductConstants.globalRowThreshold);
            }
            if (ProductConstants.globalHideNonClustered)
            {
                if (!string.IsNullOrEmpty(temp))
                {
                    temp += " and ";
                }
                temp += "IsClustered = 'Yes'";
            }

            _bindingSource.Filter = temp;
        }

        private void checkBoxX_HideDisabled_CheckedChanged(object sender, EventArgs e)
        {
            ProductConstants.globalHideDisabled = checkBoxX_HideDisabled.Checked;
            SetFilterOptions();
            UpdateControlsAndMenus();
        }

        private void checkBoxX_HideNonClusteredIndexes_CheckedChanged(object sender, EventArgs e)
        {
            ProductConstants.globalHideNonClustered = checkBoxX_HideNonClusteredIndexes.Checked;
            SetFilterOptions();
            UpdateControlsAndMenus();
        }

        private void checkBoxX_HideIndexesUnderXRows_CheckedChanged(object sender, EventArgs e)
        {
            ProductConstants.globalHideBasedOnRowThreshold = checkBoxX_HideIndexesUnderXRows.Checked;
            SetFilterOptions();
            UpdateControlsAndMenus();
        }

        private void _textBoxX_Rows_TextChanged(object sender, EventArgs e)
        {
            long rows = 0;
            string str_rows = _textBoxX_Rows.Text;
            if (!string.IsNullOrEmpty(str_rows) && System.Text.RegularExpressions.Regex.IsMatch(str_rows, "^[0-9]*$"))
            {
                rows = Convert.ToInt64(str_rows);

                    if (rows > Int32.MaxValue)
                    {
                        rows = Int32.MaxValue;
                        _textBoxX_Rows.Text = rows.ToString();
                    }
            }
            else
            {
                _textBoxX_Rows.Text = "10";
                  rows = 10;
             }
            ProductConstants.globalRowThreshold = rows;

            SetFilterOptions();
            UpdateControlsAndMenus();
        }

        private void _checkBoxX_CollectFrag_CheckedChanged(object sender, EventArgs e)
        {
            ProductConstants.globalIncludeFrag = _checkBoxX_CollectFrag.Checked;
        }


        #endregion

        private void dataGridViewX1_MouseHover(object sender, EventArgs e)
        {
          if (Form.ActiveForm    == null ||
              Form.ActiveForm.ActiveControl == null ||
              !(Form.ActiveForm.ActiveControl == textServer || 
                Form.ActiveForm.ActiveControl == textDatabase ||
                Form.ActiveForm.ActiveControl == buttonBrowseServer ||
                Form.ActiveForm.ActiveControl == buttonBrowseDatabase ||
                Form.ActiveForm.ActiveControl == buttonCredentials))
           {
              dataGridViewX1.Focus();
           }
        }

        private void advTreeIndexes_MouseHover(object sender, EventArgs e)
        {
          if (Form.ActiveForm    == null ||
              Form.ActiveForm.ActiveControl == null ||
              !(Form.ActiveForm.ActiveControl == textServer || 
                Form.ActiveForm.ActiveControl == textDatabase ||
                Form.ActiveForm.ActiveControl == buttonBrowseServer ||
                Form.ActiveForm.ActiveControl == buttonBrowseDatabase ||
                Form.ActiveForm.ActiveControl == buttonCredentials))
           {
              advTreeIndexes.Focus();
           }
        }

        private void dataGridViewX2_MouseHover(object sender, EventArgs e)
        {
          if (Form.ActiveForm    == null ||
              Form.ActiveForm.ActiveControl == null ||
              !(Form.ActiveForm.ActiveControl == textServer || 
                Form.ActiveForm.ActiveControl == textDatabase ||
                Form.ActiveForm.ActiveControl == buttonBrowseServer ||
                Form.ActiveForm.ActiveControl == buttonBrowseDatabase ||
                Form.ActiveForm.ActiveControl == buttonCredentials))
           {
              dataGridViewX2.Focus();
           }
        }

        private void advTreeColumns_MouseHover(object sender, EventArgs e)
        {
          if (Form.ActiveForm    == null ||
              Form.ActiveForm.ActiveControl == null ||
              !(Form.ActiveForm.ActiveControl == textServer || 
                Form.ActiveForm.ActiveControl == textDatabase ||
                Form.ActiveForm.ActiveControl == buttonBrowseServer ||
                Form.ActiveForm.ActiveControl == buttonBrowseDatabase ||
                Form.ActiveForm.ActiveControl == buttonCredentials))
           {
              advTreeColumns.Focus();
           }
        }

        private void checkBoxX_IncludeColumnStats_CheckedChanged(object sender, EventArgs e)
        {
            ProductConstants.globalIncludeColumnStats = checkBoxX_IncludeColumnStats.Checked;
        }

        private void _checkBoxX_CollectStatistics_CheckedChanged(object sender, EventArgs e)
        {
            ProductConstants.globalIncludeSelectivity = _checkBoxX_CollectStatistics.Checked;
        }

        private void dataGridViewX1_MouseDown(object sender, MouseEventArgs e)
        {
            theCellImHoveringOver = null;
            contextMenuIndexProperties.Visible = false;
        }

       private void ShowF1Help(object sender, HelpEventArgs hlpevent)
       {
          HelpMenu.ShowHelp();
       }

        private void textServer_TextChanged(object sender, EventArgs e)
        {
            textDatabase.Text = string.Empty;
            buttonBrowseDatabase.Enabled = (textServer.Text.Trim().Length > 0);
        }

        private void buttonBrowseDatabase_Click(object sender, EventArgs e)
        {
            Form_DatabaseBrowse browseDlg = new Form_DatabaseBrowse(textServer.Text, ProductConstants.globalSqlCredentials);

            browseDlg.allowMultiSelect = true;

            Cursor = Cursors.WaitCursor;
            bool loaded = browseDlg.LoadDatabases();
            Cursor = Cursors.Default;

            if (loaded)
            {
                DialogResult choice = browseDlg.ShowDialog();
                if (choice == DialogResult.OK)
                {
                    textDatabase.Text = browseDlg.SelectedDatabase;
                }
            }
        }

       private void menuHelp_Click(object sender, EventArgs e)
       {
          
          base.OnClick(e);
       }
       private void _textBoxX_Rows_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
           {
               e.Handled = true;
           }
       }

        private void ideraTitleBar1_LicenseInfoButtonClick(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }
    }
}

