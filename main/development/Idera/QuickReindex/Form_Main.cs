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
using DevComponents.AdvTree;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.QuickReindex
{
    public partial class Form_Main : Form
    {
        #region fields

        public delegate void DelegateWorkerThreadFinished(string text);
        public delegate void DelegateUpdateProgressBar(string opText, string progressText);
        public delegate void DelagateCloseProgressBar();

        public DelegateWorkerThreadFinished m_DelegateLoadDataWorkerThreadFinished;
        public DelegateWorkerThreadFinished m_DelegateDefragWorkerThreadFinished;
        public DelegateUpdateProgressBar m_DelegateUpdateProgressBarText;
        public DelagateCloseProgressBar m_DelegateCloseProgressBar;


        public delegate void DelagateShowExpection(string text, Exception ex);
        public DelagateShowExpection m_DelegateShowExpection;

        private Server _server = null;
        private string _serverName;
        private ToolProgressBarDialog _ProgressDialog;
        private string _gridIndexesLabelBaseText = string.Empty;

        private List<Index> selectedIndexes = null;
        private bool areAllRowsSelected = false;
        private Node lastSelectedIndexNode = null;

        private Thread workerThread = null;

        private BindingSource _bindingSource = new BindingSource();

       private bool _OnlineRebuild = false;

		private bool _SortInTempdbOnOff = false; 
		#endregion

		#region Constructor

		public Form_Main()
        {
            InitializeComponent();
            this.Text = ideraTitleBar1.IderaProductNameText;
            //labelSubtitle.Text = ProductConstants.productDescription;
            m_DelegateLoadDataWorkerThreadFinished = new DelegateWorkerThreadFinished(this.WorkerThreadFinished);
            m_DelegateDefragWorkerThreadFinished =new DelegateWorkerThreadFinished(this.DefragFinished);   
            m_DelegateShowExpection = new DelagateShowExpection(this.ShowExpection);
            m_DelegateUpdateProgressBarText = new DelegateUpdateProgressBar(this.ProgressBar_UpdateText);
            m_DelegateCloseProgressBar = new DelagateCloseProgressBar(this.ProgressBar_Close);

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

        #region Progress Bar

        public void ProgressBar_Show()
        {
            if(_ProgressDialog != null)
            {
                _ProgressDialog.ShowDialog(this);
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

        public void ProgressBar_Initialize(string text, EventHandler cancelHandler )
        {
            _ProgressDialog = new ToolProgressBarDialog();
            _ProgressDialog.OperationText = text;
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

            ProductConstants.ReadOptions();
            textServer.Text = ProductConstants.lastServer;
            ProductConstants.globalSqlCredentials = ProductConstants.lastCredentials;

            buttonRebuild.Enabled = false;
            buttonReorganize.Enabled = false;
            buttonCalculateFrag.Enabled = false;
            dataGridViewX1.DataSource = CreateDataTable();
            SetIndexColumns();

            UpdateDashBoard(false);

            #endregion

            // Program Specific Logic
            _textBoxX_Rows.Text = ProductConstants.globalPageThreshold.ToString();
            _textBoxX_FillFactor.Text = ProductConstants.fillFactor.ToString();
            buttonBrowseDatabase.Enabled = (textServer.Text.Trim().Length > 0);
        }

        #endregion

        #region Common Code

        public void ShowExpection(string text, Exception ex)
        {
            Messaging.ShowException(text, ex);
        }

        public void WorkerThreadFinished(string text)
        {
            ServerDataLoaded();
        }


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
            HelpMenu.ShowHelp( ProductConstants.productHelpTopic );
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
            DialogResult choice = credentialsForm.ShowDialog();
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

        #region Load Data
        
       private void menuRefreshStatistics_Click( object sender, EventArgs e )
       {
           GetResults();
       }

        private void buttonGetResults_Click(object sender, EventArgs e)
        {
           GetResults();
        }
        
        private void GetResults()
        {
            // Validation
            if (textServer.Text.Trim().Length == 0)
            {
                Core.Messaging.ShowError("Specify a SQL Server instance name.");
                textServer.Select();
                return;
            }
            
            ProductConstants.lastServer = textServer.Text.Trim();
            ProductConstants.lastCredentials = ProductConstants.globalSqlCredentials;
            ProductConstants.WriteOptions();

            // Get Real Server name
            _serverName = SQLHelpers.NormalizeInstanceName(textServer.Text);

            groupResults.Text = string.Format("Index Statistics for {0}", _serverName);
            groupPanel2.Text = string.Format("Fragmentation Summary for Server {0}", _serverName);
            _gridIndexesLabelBaseText = string.Format("Indexes for Server {0}", _serverName);

            UpdateIndexLabel();
            _server = null;
            advTree1.Nodes.Clear();
            _bindingSource.DataSource = CreateDataTable();
            dataGridViewX1.DataSource = _bindingSource;
            SetIndexColumns();
            
            ProgressBar_Initialize(string.Format("Connecting to Server '{0}'...", _serverName), ProgressBar_CancelHandlerLoad);
            
            workerThread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(LoadServerData));
            workerThread.Start(textDatabase.Text.Trim());


            ProgressBar_Show();

            if (ProductConstants.globalOperationCancelled == true)
            {
                ProgressBar_Close();
                ProductConstants.globalErrorReports.Clear();
                Messaging.ShowInformation(this, "Loading Indexes cancelled by user");
            }
            if (ProductConstants.globalErrorReports.Count > 0)
            {
                ProgressBar_Close();
                Core.Form_MultipleErrorHandler errorDlg = new Core.Form_MultipleErrorHandler();
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
                        List<string> _Databases = new List<string>();
                        if (((string)databaseList).Trim().Length > 0)
                        {
                            _Databases.AddRange(((string)databaseList).Split(';'));
                        }

                        _server = new Server(_serverName);
                        _server.LoadDTIs(m_DelegateUpdateProgressBarText, ProductConstants.globalIncludeFrag, _Databases);
                        ProgressBar_UpdateText("Updating UI..", string.Empty);
                    }
                    catch (Exception ex)
                    {
                        Messaging.ShowException(string.Format("Loading Index data for Server {0}.", _serverName), ex);
                    }
                }

                if (ProductConstants.globalCancelRequested)
                {
                    ProductConstants.globalOperationCancelled = true;
                }
                this.Invoke(m_DelegateLoadDataWorkerThreadFinished, new object[] { _serverName });
            }
            catch (Exception ex)
            {
                ProductConstants.globalErrorReports.Add(
                                                       string.Format("Error loading Indexes for {0}.", _serverName),
                                                       Helpers.GetCombinedExceptionText(ex));
            }
            finally
            {
                ProgressBar_Close();
            }
        }

        private void ServerDataLoaded()
        {

            if (_server == null)
            {
                return;
            }

            advTree1.Nodes.Clear();
            advTree1.ImageList = imageList1;
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
            advTree1.Nodes.Add(nodeS);
            advTree1.SelectedNode = nodeS;

            _bindingSource.DataSource = CreateDataTableFromIndex(_server.Indexes);
            SetFilterOptions();

            dataGridViewX1.DataSource = _bindingSource;
            SetIndexColumns();
            dataGridViewX1.Sort(dataGridViewX1.Columns["HiddenPercent"], ListSortDirection.Descending);

            ProgressBar_Close();

            UpdateControlsAndMenus();

        }

        #endregion

        #region Update UI

        private void UpdateIndexLabel()
        {
            int rows = dataGridViewX1.Rows.Count;
            int selected = dataGridViewX1.SelectedRows.Count;
            labelTableList.Text = string.Format("{0} ({1} index{2}, {3} selected)", _gridIndexesLabelBaseText, rows, rows == 1 ? string.Empty : "es", selected);
        }

        private void UpdateControlsAndMenus()
        {
            if (dataGridViewX1.Rows.Count != 0)
            {
                editCopyMenuItem.Enabled = true;
                fileSaveMenu.Enabled = true;
                editSelectAllMenuItem.Enabled = true;
                contextMenuExport.Enabled = true;
                contextMenuSelectAll.Enabled = true;
                contextMenuCopy.Enabled = true;

                buttonRebuild.Enabled = true;
                buttonReorganize.Enabled = true;
                menuRebuildIndexes.Enabled = true;
                contextMenuRebuildIndexes.Enabled = true;
                menuRebuildIndexes.Enabled = true;
                contextMenuReorganizeIndexes.Enabled = true;
                buttonCalculateFrag.Enabled = true;
                buttonCopyToClipboard.Enabled = true;
            }
            else
            {
                editCopyMenuItem.Enabled = false;
                fileSaveMenu.Enabled = false;
                editSelectAllMenuItem.Enabled = false;
                contextMenuExport.Enabled = false;
                contextMenuSelectAll.Enabled = false;
                contextMenuCopy.Enabled = false;

                buttonRebuild.Enabled = false;
                buttonReorganize.Enabled = false;
                menuRebuildIndexes.Enabled = false;
                contextMenuRebuildIndexes.Enabled = false;
                menuRebuildIndexes.Enabled = false;
                contextMenuReorganizeIndexes.Enabled = false;

                buttonCalculateFrag.Enabled = false;
                buttonCopyToClipboard.Enabled = false;
            }            
            UpdateDashBoard(false);
        }

        private void SetIndexColumns()
        {
            //foreach (DataGridViewColumn col in dataGridViewX1.Columns)
            //{
            //    col.Visible = false;
            //}
            dataGridViewX1.RowHeadersWidth = 24;
            dataGridViewX1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int di = 0;
            // Show these columns
            if (dataGridViewX1.Columns.Contains("DatabaseName"))
            {
                dataGridViewX1.Columns["DatabaseName"].Visible = true;
                dataGridViewX1.Columns["DatabaseName"].DisplayIndex = di++;
                dataGridViewX1.Columns["DatabaseName"].Width = 60;
                dataGridViewX1.Columns["DatabaseName"].MinimumWidth = 20;
                dataGridViewX1.Columns["DatabaseName"].HeaderText = "Database";
                dataGridViewX1.Columns["DatabaseName"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns["DatabaseName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewX1.Columns["DatabaseName"].ReadOnly = true;
            }           
            if (dataGridViewX1.Columns.Contains("TableName"))
            {
                dataGridViewX1.Columns["TableName"].Visible = true;
                dataGridViewX1.Columns["TableName"].DisplayIndex = di++;
                dataGridViewX1.Columns["TableName"].Width = 60;
                dataGridViewX1.Columns["TableName"].MinimumWidth = 20;
                dataGridViewX1.Columns["TableName"].HeaderText = "Table";
                dataGridViewX1.Columns["TableName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewX1.Columns["TableName"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns["TableName"].ReadOnly = true;
            }
            
            if (dataGridViewX1.Columns.Contains("Index"))
            {
                dataGridViewX1.Columns["Index"].Visible = true;
                dataGridViewX1.Columns["Index"].DisplayIndex = di++;
                dataGridViewX1.Columns["Index"].Width = 150;
                dataGridViewX1.Columns["Index"].MinimumWidth = 20;
                dataGridViewX1.Columns["Index"].HeaderText = "Index";
                dataGridViewX1.Columns["Index"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewX1.Columns["Index"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns["Index"].ReadOnly = true;
            }
            
            if (dataGridViewX1.Columns.Contains("IsColumnStore"))
            {
                dataGridViewX1.Columns["IsColumnStore"].Visible = false;
            }
            
            if (dataGridViewX1.Columns.Contains("IsClustered"))
            {
                dataGridViewX1.Columns["IsClustered"].Visible = true;
                dataGridViewX1.Columns["IsClustered"].DisplayIndex = di++;
                dataGridViewX1.Columns["IsClustered"].Width = 64;
                dataGridViewX1.Columns["IsClustered"].MinimumWidth = 20;
                dataGridViewX1.Columns["IsClustered"].HeaderText = "Clustered";
                dataGridViewX1.Columns["IsClustered"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns["IsClustered"].ReadOnly = true;
                dataGridViewX1.Columns["IsClustered"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                    
                dataGridViewX1.Columns["IsClustered"].Resizable = DataGridViewTriState.False;
                dataGridViewX1.Columns["IsClustered"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridViewX1.Columns["IsClustered"].HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                    
            }

            if (dataGridViewX1.Columns.Contains("FillFactor"))
            {
                dataGridViewX1.Columns["FillFactor"].Visible = true;
                dataGridViewX1.Columns["FillFactor"].DisplayIndex = di++;
                dataGridViewX1.Columns["FillFactor"].Width = 60;
                dataGridViewX1.Columns["FillFactor"].MinimumWidth = 20;
                dataGridViewX1.Columns["FillFactor"].HeaderText = "Fill Factor";
                dataGridViewX1.Columns["FillFactor"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                dataGridViewX1.Columns["FillFactor"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns["FillFactor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridViewX1.Columns["FillFactor"].ReadOnly = true;
                dataGridViewX1.Columns["FillFactor"].HeaderCell.Style.Alignment =
                   DataGridViewContentAlignment.MiddleCenter;
                    
            }   
            if (dataGridViewX1.Columns.Contains("IsDisabled"))
            {
                dataGridViewX1.Columns["IsDisabled"].Visible = true;
                dataGridViewX1.Columns["IsDisabled"].DisplayIndex = di++;
                dataGridViewX1.Columns["IsDisabled"].Width = 64;
                dataGridViewX1.Columns["IsDisabled"].MinimumWidth = 20;
                dataGridViewX1.Columns["IsDisabled"].HeaderText = "Disabled";
                dataGridViewX1.Columns["IsDisabled"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns["IsDisabled"].ReadOnly = true;
                dataGridViewX1.Columns["IsDisabled"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dataGridViewX1.Columns["IsDisabled"].Resizable = DataGridViewTriState.False;
                dataGridViewX1.Columns["IsDisabled"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridViewX1.Columns["IsDisabled"].HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            }
            if (dataGridViewX1.Columns.Contains("CountPages"))
            {
                dataGridViewX1.Columns["CountPages"].Visible = true;
                dataGridViewX1.Columns["CountPages"].DisplayIndex = di++;
                dataGridViewX1.Columns["CountPages"].Width = 55;
                dataGridViewX1.Columns["CountPages"].HeaderText = "Pages";
                dataGridViewX1.Columns["CountPages"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns["CountPages"].ReadOnly = true;
                dataGridViewX1.Columns["CountPages"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;        

                dataGridViewX1.Columns["CountPages"].Resizable = DataGridViewTriState.False;
                dataGridViewX1.Columns["CountPages"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridViewX1.Columns["CountPages"].HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            }
            if (dataGridViewX1.Columns.Contains("EstimatedSize"))
            {
                dataGridViewX1.Columns["EstimatedSize"].Visible = true;
                dataGridViewX1.Columns["EstimatedSize"].DisplayIndex = di++;
                dataGridViewX1.Columns["EstimatedSize"].Width = 74;
                dataGridViewX1.Columns["EstimatedSize"].MinimumWidth = 20;
                dataGridViewX1.Columns["EstimatedSize"].HeaderText = "Estimated Size";
                dataGridViewX1.Columns["EstimatedSize"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewX1.Columns["EstimatedSize"].ReadOnly = true;
                dataGridViewX1.Columns["EstimatedSize"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dataGridViewX1.Columns["EstimatedSize"].Resizable = DataGridViewTriState.False;
                dataGridViewX1.Columns["EstimatedSize"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridViewX1.Columns["EstimatedSize"].HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

            }
            if (dataGridViewX1.Columns.Contains("FragmentationPercent"))
            {
                dataGridViewX1.Columns["FragmentationPercent"].Visible = true;
                dataGridViewX1.Columns["FragmentationPercent"].DisplayIndex = di++;
                dataGridViewX1.Columns["FragmentationPercent"].Width = 120;
                dataGridViewX1.Columns["FragmentationPercent"].MinimumWidth = 120;
                dataGridViewX1.Columns["FragmentationPercent"].HeaderText = "Fragmentation Percent";
                dataGridViewX1.Columns["FragmentationPercent"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridViewX1.Columns["FragmentationPercent"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewX1.Columns["FragmentationPercent"].ReadOnly = true;
                dataGridViewX1.Columns["FragmentationPercent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dataGridViewX1.Columns["FragmentationPercent"].HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }            
            if (dataGridViewX1.Columns.Contains("HiddenPercent"))
            {
                dataGridViewX1.Columns["HiddenPercent"].Visible = false;
            }
        }   

        private void UpdateDashBoard(bool resetDataSource)
        {
            int numIndexes = 0;
            int numCritical = -1;
            int numCaution = -1;
            int numAcceptable = -1;
            string filter = "Server ?";
            if (advTree1.SelectedNode != null)
            {
                object obj = advTree1.SelectedNode.Tag;
                if (obj is Server)
                {
                    Server s = (Server) obj;
                    if (resetDataSource)
                    {
                        _bindingSource.DataSource = CreateDataTableFromIndex(s.Indexes);
                    }
                    numIndexes = s.NumberIndexes;
                    numCritical = s.NumberCriticalIndexes;
                    numCaution = s.NumberCautionIndexes;
                    numAcceptable = s.NumberAcceptableIndexes;
                    filter = string.Format("SQL Server '{0}'", _serverName);
                }
                else if (obj is Database)
                {
                    Database d = (Database) obj;
                    if (resetDataSource)
                    {
                        _bindingSource.DataSource = CreateDataTableFromIndex(d.Indexes);
                    }
                    numIndexes = d.NumberIndexes;
                    numCritical = d.NumberCriticalIndexes;
                    numCaution = d.NumberCautionIndexes;
                    numAcceptable = d.NumberAcceptableIndexes;
                    filter = string.Format("Database '{0}'", d.Name);
                }
                else if (obj is Table)
                {
                    Table t = (Table) obj;
                    if (resetDataSource)
                    {
                        _bindingSource.DataSource = CreateDataTableFromIndex(t.Indexes);
                    }
                    numIndexes = t.NumberIndexes;
                    numCritical = t.NumberCriticalIndexes;
                    numCaution = t.NumberCautionIndexes;
                    numAcceptable = t.NumberAcceptableIndexes;
                    filter = string.Format("Table '{0}'", t.Name);
                }

            }
            labelCriticalIndexes.Text =
                string.Format("{0} {1} 75% or more fragmented", numCritical == -1 ? "?" : numCritical.ToString(), numCritical == 1 ? "Index" : "Indexes");
            labelCautionIndexes.Text =
                string.Format("{0} {1} 25% to 75% fragmented", numCaution == -1 ? "?" : numCaution.ToString(), numCaution == 1 ? "Index" : "Indexes");
            labelAcceptableIndexes.Text =
                string.Format("{0} {1} 25% or less fragmented", numAcceptable == -1 ? "?" : numAcceptable.ToString(),
                              numAcceptable == 1 ? "Index" : "Indexes");

            groupPanel2.Text = string.Format("Fragmentation Summary for {0}", filter);
            _gridIndexesLabelBaseText = string.Format("Indexes for {0}", filter);
        
            if (numIndexes > 0 && IsFiltered)
            {
                int filteredIndexes = 0;
                if (dataGridViewX1 != null && dataGridViewX1.Rows != null)
                {
                    filteredIndexes = numIndexes - dataGridViewX1.Rows.Count;
                }
                labelX_FilteredIndexes.Text = string.Format(ProductConstants.FilterText, filteredIndexes, numIndexes);
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

        #endregion

        #region DataTable

        //private int DatabaseNameCol = 0;
        //private int TableNameCol = 1;
        //private int IndexCol = 2;
        //private int IsClusteredCol = 3;
        private int IsDisabledCol = 5;
        private int CountPagesCol = 6;
        private int EstimatedSizeCol = 7;
        private int FragmentationPercentCol = 8;
        private int HiddenPercentCol = 9;

        DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("DatabaseName", typeof(string));
//            dataTable.Columns.Add("SchemaName", typeof(string));
            dataTable.Columns.Add("TableName", typeof(string));
            dataTable.Columns.Add("Index", typeof(Index));
            dataTable.Columns.Add("IsColumnStore", typeof(string));
            dataTable.Columns.Add("IsClustered", typeof(string));
            dataTable.Columns.Add("FillFactor", typeof(string));
            dataTable.Columns.Add("IsDisabled", typeof(string));
            dataTable.Columns.Add("CountPages", typeof(int));
            dataTable.Columns.Add("EstimatedSize", typeof(long));
            dataTable.Columns.Add("FragmentationPercent", typeof(double));
            dataTable.Columns.Add("HiddenPercent", typeof(double));
            return dataTable;
            
        }

        DataTable CreateDataTableFromIndex(List<Index> indexes)
        {
            DataTable dataTable = CreateDataTable();
            try
            {
                foreach (Index i in indexes)
                {
                    dataTable.Rows.Add(new object[] {   i.DatabaseName, 
                                                string.Format("{0}.{1}", i.SchemaName, i.TableName),
                                                i,
                                                i.IsColumnStore ? "Yes" : "No",
                                                i.IsClustered ? "Yes" : "No",
                                                i.FillFactor,
                                                i.IsDisabled ? "Yes" : "No",
                                                i.CountPages,
                                                i.CountPages * ProductConstants.IndexPageSize,
                                                i.AverageFragLevel,
                                                i.AverageFragLevel
                                               });
               }
            }
            catch (Exception ex)
            {
                ShowExpection("Error Loading Data Grid", ex);
            }

            return dataTable;
        }

        #endregion

        #region Events

        private void advTree1_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            if (e.Node != null && e.Node != lastSelectedIndexNode)
            {
                lastSelectedIndexNode = e.Node;
                int SortColumnIndex = (dataGridViewX1.SortedColumn == null)
                                      ? 0 : dataGridViewX1.SortedColumn.Index;
                ListSortDirection sortDirection = (dataGridViewX1.SortOrder == SortOrder.Ascending)
                                            ? ListSortDirection.Ascending
                                            : ListSortDirection.Descending;
                
                UpdateDashBoard(true);

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
                DataGridViewRow row = dataGridViewX1.Rows[e.RowIndex];
                e.Value = Helpers.StrFormatByteSize(Convert.ToInt64(row.Cells["EstimatedSize"].Value));
            }
            else if (e.ColumnIndex == dataGridViewX1.Columns["FragmentationPercent"].Index)
            {
                e.FormattingApplied = true;
                DataGridViewRow row = dataGridViewX1.Rows[e.RowIndex];
                double value = Convert.ToDouble(row.Cells["FragmentationPercent"].Value);
                if(value == -10.0)
                {
                    e.Value = "Not Analyzed";
                }
                else if (value < 0.0)
                {
                    e.Value = "N/A";
                }
                else
                {
                    e.Value = string.Format("{0:P}", value / 100);
                }
            }          
        }
      
        private void dataGridViewX1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            const int offset = 2;
           
            if (dataGridViewX1.Columns["FragmentationPercent"].Index ==
                        e.ColumnIndex && e.RowIndex >= 0)
            {
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 0);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                DataGridViewRow row = dataGridViewX1.Rows[e.RowIndex];

                // Get Size of bar to paint based on percent value
                int width = 0;
                double percent = Convert.ToDouble(row.Cells["FragmentationPercent"].Value) / 100;
                if (Convert.ToDouble(row.Cells["FragmentationPercent"].Value) > 0.0)
                {
                    width = (int)((e.CellBounds.Width - (offset *2)) * percent);
                    width = (width < 2) ? 2 : width;
                }
                Rectangle barRect = new Rectangle(e.CellBounds.X + offset,
                                                  e.CellBounds.Y + offset,
                                                  width,
                                                  e.CellBounds.Height - (offset * 2));
                // Get size for graph to hold bar
                Rectangle outLineRect = e.CellBounds;
                outLineRect.Inflate(-2,-2);

                // Get color for % graph
                Color barBackColor = Color.FromArgb(255, 255, 200);
                Color backColor = Color.Yellow;
                if (percent >= 0.75)
                {
                    backColor = Color.Red;
                    barBackColor = Color.FromArgb(255, 200, 200);
                }
                else if (percent <= 0.25 && percent >= 0.0)
                {
                    backColor = Color.LimeGreen;
                    barBackColor = Color.FromArgb(200, 255, 200);
                }
                else if (percent < 0.0)
                {
                    backColor = Color.Blue;
                    barBackColor = Color.FromArgb(200, 200, 255);
                }
                Color eraseColor = (row.Selected) ? e.CellStyle.BackColor : e.CellStyle.BackColor;
                // Paint Graph
                using (Brush backColorBrush = new SolidBrush(backColor),
                      eraseBrush = new SolidBrush(eraseColor),
                      barEraseBrush = new SolidBrush(barBackColor))
                {
//                    e.Graphics.FillRectangle(eraseBrush, e.CellBounds);
                    e.Graphics.FillRectangle(barEraseBrush, outLineRect);
                    e.Graphics.FillRectangle(backColorBrush, barRect);
                    using (Pen pen = new Pen(Color.Silver))
                    {
                        pen.Width = 1;
                        e.Graphics.DrawLine(pen, outLineRect.Left, outLineRect.Top-1, outLineRect.Right, outLineRect.Top-1);
                        e.Graphics.DrawLine(pen, outLineRect.Left, outLineRect.Top-1, outLineRect.Left, outLineRect.Bottom-1);
                        pen.Color = Color.LightSlateGray;
                        pen.Width = 2;
                        e.Graphics.DrawLine(pen, outLineRect.Left, outLineRect.Bottom-1, outLineRect.Right, outLineRect.Bottom-1);
                        e.Graphics.DrawLine(pen, outLineRect.Right, outLineRect.Bottom-1, outLineRect.Right, outLineRect.Top);
                    }
                }

                // Paint Text
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }                        
        }

        private void buttonCalculateFrag_Click(object sender, EventArgs e)
        {
            AnalyzeFragmentation();
        }

        private void buttonReorganize_Click(object sender, EventArgs e)
        {
            ReorganizeIndexes();
        }

        private void buttonRebuild_Click(object sender, EventArgs e)
        {
            RebuildIndexes();
        }

        private void AnalyzeFragmentation()
        {
            DialogResult choice = Messaging.ShowHideableConfirmation(
               "showAnalysisWarning",
               "Analyzing Index Fragmentation can take a long time.\r\n\r\nDo you want to continue?",
               MessageBoxButtons.YesNo );
               
            if ( choice == System.Windows.Forms.DialogResult.Yes)
            {
                if (dataGridViewX1 != null)
                {
                    ProgressBar_Initialize(ProductConstants.AnalyzingIndexFragmentation, ProgressBar_CancelHandlerWorker);
                    selectedIndexes = new List<Index>();
                    areAllRowsSelected = dataGridViewX1.AreAllCellsSelected(false);
                    foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
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

        private void ReorganizeIndexes()
        {
            if (dataGridViewX1.SelectedRows.Count > 0)
            {
                DialogResult choice = Messaging.ShowHideableConfirmation(
                   "showReorgWarning",
                   "Reorganizing indexes can take a long time to complete.\r\n\r\nDo you want to continue?",
                   MessageBoxButtons.YesNo );
                  
                if ( choice == System.Windows.Forms.DialogResult.Yes)
                {
                    ProgressBar_Initialize(ProductConstants.ReorganizingIndexes, ProgressBar_CancelHandlerWorker);
                    selectedIndexes = new List<Index>();
                    areAllRowsSelected = dataGridViewX1.AreAllCellsSelected(false);                                  
                    foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
                    {
                        selectedIndexes.Add((Index) (row.Cells["Index"].Value));
                    }                   
                    workerThread = new System.Threading.Thread(new System.Threading.ThreadStart(ReorganizeWorker));
                    workerThread.Start();

                    ProgressBar_Show();

                    ShowWorkerThreadMessages("Reorganizing Indexes");
                    
                }
            }
            else
            {
                Messaging.ShowError("No index selected.");
            }            
        }

        private void RebuildIndexes()
        {
            if (dataGridViewX1.SelectedRows.Count > 0 )
            {
                    Form_ReindexWarning rebuildSettings = new Form_ReindexWarning();

                    if (_server.ServerVersion == ServerVersionType.SQL2000 || _server.EngineEdition == EngineEdition.Standard || _server.EngineEdition == EngineEdition.Express)
                    {
                        rebuildSettings.HideOnline();
                    }
                    rebuildSettings.MaxDOP = ProductConstants.maxDOP;
                    DialogResult choice = rebuildSettings.ShowDialog(this);

                    if (choice == System.Windows.Forms.DialogResult.OK)
                    {
                        ProductConstants.maxDOP = rebuildSettings.MaxDOP;
                        _OnlineRebuild = rebuildSettings.OnlineRebuild;
						_SortInTempdbOnOff = rebuildSettings.SortInTempdbON; //CGVAK -Assign the value for the variable
					ProgressBar_Initialize(ProductConstants.RebuildingIndexes, ProgressBar_CancelHandlerWorker);
                        selectedIndexes = new List<Index>();                         
                        foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
                        {
                            Index tempindex = (Index)(row.Cells["Index"].Value);
                            int canUpdateFillFactor = GetCurrentFillFactor(tempindex);                  
                            if (canUpdateFillFactor == 0)
                            {
                                selectedIndexes.Add(tempindex);
                            }
                            else
                            {
                                Custom_MessageBox messageBox = new Custom_MessageBox(String.Format("The Fill Factor has been changed for {0} - would you like to use the updated value in SQL Server ?", tempindex.Name));
                                DialogResult messagebox = messageBox.ShowDialog(this);
                                if (messagebox == System.Windows.Forms.DialogResult.Cancel)
                                {
                                    selectedIndexes.Add(tempindex);
                                }
                            }

                        }
                        workerThread = new System.Threading.Thread(new System.Threading.ThreadStart(RebuildWorker));
                        workerThread.Start();
                        ProgressBar_Show();
                        ShowWorkerThreadMessages("Rebuilding Indexes");
                    //to reload the Grid
                    //GetResults();   //Comment Ram kendre SQLADMI-1707 based on ticket problem
                }
            }
            else
            {
                Messaging.ShowError("No index selected.");
            }            
        }

        private int GetCurrentFillFactor(Index i)
        {
            using (
                        SqlConnection conn =
                            new SqlConnection(
                                Connection.CreateConnectionString(_serverName, string.Empty,
                                                                  ProductConstants.globalSqlCredentials)))
            {
                Connection.Impersonate(ProductConstants.globalSqlCredentials);

                conn.Open();
                return i.IsFillFactorChangable(conn);

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
                                                    "Analyzing fragmentation may not be performed on disabled indexes.");                                
                            }
                        }
                    }
                    if (ProductConstants.globalCancelRequested == true)
                    {
                        ProductConstants.globalOperationCancelled = true;
                    }
                    this.Invoke(m_DelegateDefragWorkerThreadFinished, new object[] { "Analyzing Fragmentation" });
                }               
            }
            catch (ThreadAbortException)
            {
                this.Invoke(m_DelegateDefragWorkerThreadFinished, new object[] { string.Empty });
            }
            catch (Exception ex)
            {
                this.Invoke(m_DelegateDefragWorkerThreadFinished, new object[] { string.Empty });
                this.Invoke(m_DelegateShowExpection,
                            new object[] { "Analyzing Fragmentation", ex });
            }
            finally
            {
                ProgressBar_Close();
            }
        }

        private void RebuildWorker()
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
                                break;
                            }
                            m_DelegateUpdateProgressBarText("Rebuilding Indexes...", string.Format("'{0}.{1}.{2}.{3}'",
                                                i.DatabaseName, i.SchemaName, i.TableName, i.Name));
                            
                            if (fillFact.Checked)
                            {
                                ProductConstants.fillFactor = Convert.ToInt32(_textBoxX_FillFactor.Text);
                            }
                            else
                            {
                                if (i.FillFactor == "Not Set")
                                {
                                    ProductConstants.fillFactor = -1;
                                }
                                else
                                {
                                    ProductConstants.fillFactor = int.Parse(i.FillFactor);
                                }
                            }

                            i.Rebuild(_OnlineRebuild, _SortInTempdbOnOff, i.IsColumnStore, conn); //CGVAK -Passed the assignd variable

						}
                    }
                    if (ProductConstants.globalCancelRequested == true)
                    {
                        ProductConstants.globalOperationCancelled = true;
                    }
                    this.Invoke(m_DelegateDefragWorkerThreadFinished, new object[] {"RebuildWorker"});
                }               
            }
            catch (ThreadAbortException)
            {
                this.Invoke(m_DelegateDefragWorkerThreadFinished, new object[] { string.Empty });
            }
            catch (Exception ex)
            {
                this.Invoke(m_DelegateDefragWorkerThreadFinished, new object[] { string.Empty });
                this.Invoke(m_DelegateShowExpection, new object[] { "Rebuilding Indexes", ex });
            }
            finally
            {
                ProgressBar_Close();
            }
        }

        private void ReorganizeWorker()
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
                                break;
                            }
                            if (!i.IsDisabled)
                            {
                                m_DelegateUpdateProgressBarText("Reorganizing Indexes...", string.Format("'{0}.{1}.{2}.{3}'",
                                                                    i.DatabaseName, i.SchemaName, i.TableName, i.Name));
 
                                i.Reorganize(conn);
                            }
                            else
                            {
                                ProductConstants.globalErrorReports.Add(
                                    string.Format("Error reorganizing index {0}.{1}.{2}.{3}",
                                                  i.DatabaseName, i.SchemaName, i.TableName, i.Name),
                                    "Reorganize is not allowed for disabled indexes. Use rebuild to rebuild and enable this index.");
                            }
                        }
                        if (ProductConstants.globalCancelRequested == true)
                        {
                            ProductConstants.globalOperationCancelled = true;
                        }
                    }
                    this.Invoke(m_DelegateDefragWorkerThreadFinished, new object[] { "ReorganizeWorker" });
                }                
            }
            catch (ThreadAbortException)
            {
                this.Invoke(m_DelegateDefragWorkerThreadFinished, new object[] { string.Empty });
            }
            catch (Exception ex)
            {
                this.Invoke(m_DelegateDefragWorkerThreadFinished, new object[] { string.Empty });
                this.Invoke(m_DelegateShowExpection, new object[] { "Reorganizing Index", ex });
            }
            finally 
            {
                ProgressBar_Close();
            }
        }

        private void DefragFinished(string opText)
        {
            try
            {
                ProgressBar_UpdateText(string.Format("{0} Completing...", opText), string.Empty);
                Index curIndex = null;
                if (dataGridViewX1.CurrentRow != null)
                {
                    curIndex = (Index) dataGridViewX1.CurrentRow.Cells["Index"].Value;
                    dataGridViewX1.CurrentCell = dataGridViewX1.Rows[0].Cells[0];
                }
                dataGridViewX1.ClearSelection();
                _bindingSource.RemoveFilter();
                if (areAllRowsSelected || selectedIndexes.Count > 20)
                {
                    UpdateDashBoard(true);
                }
                else
                {
                    foreach (Index i in selectedIndexes)
                    {
                        foreach (DataGridViewRow row in dataGridViewX1.Rows)
                        {
                            if (row.Index >= 0)
                            {
                                Index idx = (Index) (row.Cells["Index"].Value);
                                if (idx != null && idx.DatabaseId == i.DatabaseId && idx.TableId == i.TableId &&
                                    idx.Id == i.Id)
                                {
                                    row.Cells[CountPagesCol].Value = i.CountPages;
                                    row.Cells[IsDisabledCol].Value = i.IsDisabled ? "Yes" : "No";
                                    row.Cells[EstimatedSizeCol].Value = i.CountPages*ProductConstants.IndexPageSize;
                                    row.Cells[FragmentationPercentCol].Value = i.AverageFragLevel;
                                    if (row.Index >= 0)
                                    {
                                        dataGridViewX1.InvalidateRow(row.Index);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                ProgressBar_UpdateText("Updating UI...", string.Empty);
                SetFilterOptions();
                dataGridViewX1.Update();
                if (areAllRowsSelected)
                {
                    dataGridViewX1.SelectAll();
                }
                else
                {
                    if (curIndex != null)
                    {
                        foreach (DataGridViewRow row in dataGridViewX1.Rows)
                        {
                            if (row.Index >= 0)
                            {
                                Index idx = (Index) (row.Cells["Index"].Value);
                                if (idx != null && idx.DatabaseId == curIndex.DatabaseId &&
                                    idx.TableId == curIndex.TableId &&
                                    idx.Id == curIndex.Id)
                                {
                                    dataGridViewX1.CurrentCell = row.Cells[0];
                                    break;
                                }
                            }
                        }
                    }
                    foreach (Index i in selectedIndexes)
                    {
                        foreach (DataGridViewRow row in dataGridViewX1.Rows)
                        {
                            if (row.Index >= 0)
                            {
                                Index idx = (Index) (row.Cells["Index"].Value);
                                if (idx != null && idx.DatabaseId == i.DatabaseId && idx.TableId == i.TableId &&
                                    idx.Id == i.Id)
                                {
                                    row.Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                }               
            }
            catch(Exception ex)
            {
                ProductConstants.globalErrorReports.Add("Error updating grid", Helpers.GetCombinedExceptionText(ex));
            }          
        }

        private void ShowWorkerThreadMessages(string opText)
        {
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

        private void buttonCopyToClipboard_Click(object sender, EventArgs e)
        {
            ExportToClipboard.CopyDataGridViewToTabbedFormat(dataGridViewX1, false);
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateControlsAndMenus();
        }

        private void dataGridViewX1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewX1.Columns["FragmentationPercent"].Index)
            {
               // we need to sort by fragmentation percent - then update the hidden column with the 
               // fragmentation percent column
                int fragCol   = dataGridViewX1.Columns["FragmentationPercent"].Index;
                int hiddenCol = dataGridViewX1.Columns["HiddenPercent"].Index;
                
                foreach ( DataGridViewRow row in dataGridViewX1.Rows )
                {
                   row.Cells[hiddenCol].Value = row.Cells[fragCol].Value;
                }
                
                ListSortDirection lsd = ListSortDirection.Descending;
                if ( dataGridViewX1.SortedColumn == dataGridViewX1.Columns["HiddenPercent"] 
                  && dataGridViewX1.SortOrder == SortOrder.Descending )
                {
                   lsd = ListSortDirection.Ascending;
                }
                
                dataGridViewX1.Sort(dataGridViewX1.Columns[hiddenCol], lsd);
            }

            if (dataGridViewX1.SortedColumn == null)
            {
                foreach (DataGridViewColumn c in dataGridViewX1.Columns)
                {
                    c.Frozen = true;
                    c.SortMode = DataGridViewColumnSortMode.Automatic;
                }
                

                dataGridViewX1.Sort(dataGridViewX1.Columns[e.ColumnIndex], ListSortDirection.Descending);
            }
        }

        private void analyzeFragmentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnalyzeFragmentation();
        }

        private void _checkBoxX_CollectFrag_CheckedChanged(object sender, EventArgs e)
        {
            ProductConstants.globalIncludeFrag = _checkBoxX_CollectFrag.Checked;
        }

        #endregion

        #region Menu

        private void contextMenuAnalyzeFragmentation_Click(object sender, EventArgs e)
        {
            AnalyzeFragmentation();
        }

        private void contextMenuReorganizeIndexes_Click(object sender, EventArgs e)
        {
            ReorganizeIndexes();
            UpdateControlsAndMenus();
        }

        private void contextMenuRebuildIndexes_Click(object sender, EventArgs e)
        {
            RebuildIndexes();
            UpdateControlsAndMenus();
        }

        private void menuReorganizeIndexes_Click(object sender, EventArgs e)
        {
            ReorganizeIndexes();
            UpdateControlsAndMenus();
        }

        private void menuRebuildIndexes_Click(object sender, EventArgs e)
        {
            RebuildIndexes();
            UpdateControlsAndMenus();
        }

        private void contextMenuCSV_Click(object sender, EventArgs e)
        {
            ExportToCSV.CopyDataGridView(dataGridViewX1);
        }

        private void contextMenuXML_Click(object sender, EventArgs e)
        {
            ExportToXML.CopyDataGridView(dataGridViewX1, "FragmentationSummary", false);
        }

        private void contextMenuCopy_Click(object sender, EventArgs e)
        {
            ExportToClipboard.CopyDataGridViewToTabbedFormat(dataGridViewX1, true);
        }

        private void contextMenuSelectAll_Click(object sender, EventArgs e)
        {
            dataGridViewX1.SelectAll();
        }

        private void editCopyMenuItem_Click(object sender, EventArgs e)
        {
            ExportToClipboard.CopyDataGridViewToTabbedFormat(dataGridViewX1, true);
        }

        private void editSelectAllMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewX1.SelectAll();
        }

        private void fileSavetoCVSMenuItem_Click(object sender, EventArgs e)
        {
            ExportToCSV.CopyDataGridView(dataGridViewX1);
        }

        private void fileSavetoXMLMenuItem_Click(object sender, EventArgs e)
        {
            ExportToXML.CopyDataGridView(dataGridViewX1, "FragmentationSummary", false);
        }

        private void fileSavetoDatatableMenuItem_Click(object sender, EventArgs e)
        {
            ExportToTable.CreateTableDelegate ctd = new ExportToTable.CreateTableDelegate(this.CreateTable);
            ExportToTable.PopulateTableDelegate ptd = new ExportToTable.PopulateTableDelegate(this.PopulateTable);

            ExportToTable.Export(ctd, ptd);

        }


        #endregion

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
                          "  [IsColumnStore] [nvarchar] (12) NULL, " +
                          "  [IsClustered] [nvarchar](12)   NULL, " +
                          "  [IsDisabled]  [nvarchar] (12)  NULL," +
                          "  [CountPages] [int] NULL, " +
                          "  [EstimatedSize] [int] NULL, " +
                          "  [FragmentationPercent] [float] NULL, " +
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
            foreach (DataGridViewRow row in this.dataGridViewX1.Rows)
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
                    PopulateTable_AddProperty("IsColumnStore", SQLHelpers.CreateSafeString(index.IsColumnStore ? "Yes" : "No"));
                    PopulateTable_AddProperty("IsClustered", SQLHelpers.CreateSafeString(index.IsClustered ? "Yes" : "No"));
                    PopulateTable_AddProperty("IsDisabled", SQLHelpers.CreateSafeString(index.IsDisabled ? "Yes" : "No"));
                    PopulateTable_AddProperty("CountPages", index.CountPages.ToString());
                    PopulateTable_AddProperty("EstimatedSize", (index.CountPages * ProductConstants.IndexPageSize).ToString());
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

        #region Filtering

        public bool IsFiltered
        {
            get
            {
                bool filtered = false;
                if (ProductConstants.globalHideBasedOnPageThreshold)
                {
                    filtered = true;
                }
                else if (ProductConstants.globalHideDisabled)
                {
                    filtered = true;
                }
                else if (ProductConstants.globalHideNonClustered)
                {
                    filtered = true;
                }
                return filtered;
            }
        }

        private void SetFilterOptions()
        {
            string temp = string.Empty;
            if (ProductConstants.globalHideDisabled)
            {
                temp = "IsDisabled = 'No'";
            }
            if (ProductConstants.globalHideBasedOnPageThreshold)
            {                
                if (!string.IsNullOrEmpty(temp))
                {
                    temp += " and ";
                }
                temp += string.Format("CountPages >= {0}", ProductConstants.globalPageThreshold);
            }
            if(ProductConstants.globalHideNonClustered)
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

        private void checkBoxX_HideIndexesUnderXRows_CheckedChanged(object sender, EventArgs e)
        {
            ProductConstants.globalHideBasedOnPageThreshold = checkBoxX_HideIndexesUnderXRows.Checked;
            SetFilterOptions();
            UpdateControlsAndMenus();
        }

        private void checkBoxX_HideNonClustered_CheckedChanged(object sender, EventArgs e)
        {
            ProductConstants.globalHideNonClustered = checkBoxX_HideNonClustered.Checked;
            SetFilterOptions();
            UpdateControlsAndMenus();
        }

        private void _textBoxX_Rows_TextChanged(object sender, EventArgs e)
        {
            long pages = 0;
            string str_pages = _textBoxX_Rows.Text;
            if (!string.IsNullOrEmpty(str_pages) && System.Text.RegularExpressions.Regex.IsMatch(str_pages, "^[0-9]*$"))
            {
                pages = Convert.ToInt64(str_pages);

                if (pages > Int32.MaxValue)
                {
                    pages = Int32.MaxValue;
                    _textBoxX_Rows.Text = pages.ToString();
                }
            }
            else
            {
                _textBoxX_Rows.Text = "2";
                pages = 2;
            }
            ProductConstants.globalPageThreshold = pages;

            SetFilterOptions();
            UpdateControlsAndMenus();

        }
        #endregion

        #endregion

       private void ShowF1Help(object sender, HelpEventArgs hlpevent)
       {
          HelpMenu.ShowHelp(ProductConstants.productHelpTopic);
       }

       private void _textBoxX_Rows_KeyPress( object sender, KeyPressEventArgs e )
       {
          if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
          {
             e.Handled = true;
          }
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

       private void advTree1_MouseHover(object sender, EventArgs e)
       {
          if (Form.ActiveForm    == null ||
              Form.ActiveForm.ActiveControl == null ||
              !(Form.ActiveForm.ActiveControl == textServer || 
                Form.ActiveForm.ActiveControl == textDatabase ||
                Form.ActiveForm.ActiveControl == buttonBrowseServer ||
                Form.ActiveForm.ActiveControl == buttonBrowseDatabase ||
                Form.ActiveForm.ActiveControl == buttonCredentials))
          {
             advTree1.Focus();
          }
       }

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

       private void menuHelp_Click(object sender, EventArgs e)
       {
          
          base.OnClick(e);
       }

       //US5148 Disable the textbox
       private void radioButton_CheckedChanged_fillFactor(object sender, EventArgs e)
       {
           if (this.fillFact.Checked)
           {
               this._textBoxX_FillFactor.Enabled = true;
           }
           else
           {
               this._textBoxX_FillFactor.Enabled = false;
           }
       }

       private void _textBoxX_FillFactor_TextChanged(object sender, EventArgs e)
       {
          int fillFactor = 0;
          String str_rows = _textBoxX_FillFactor.Text;
          if (!string.IsNullOrEmpty(str_rows) && System.Text.RegularExpressions.Regex.IsMatch(str_rows, "^[0-9]*$"))
          {
              fillFactor = Convert.ToInt32(str_rows);

              if (fillFactor < 0)
              {
                  fillFactor = 0;
                  _textBoxX_FillFactor.Text = fillFactor.ToString();
              }
              else
              {
                  if (fillFactor > 100)
                  {
                      fillFactor = 100;
                      _textBoxX_FillFactor.Text = fillFactor.ToString();
                  }
              }
          }
          else
          {
              _textBoxX_FillFactor.Text = fillFactor.ToString();
          }
          ProductConstants.fillFactor = fillFactor;
       }

       private void _textBoxX_FillFactor_KeyPress(object sender, KeyPressEventArgs e)
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

