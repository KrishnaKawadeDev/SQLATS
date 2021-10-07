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

namespace Idera.SqlAdminToolset.SpaceAnalyzer
{
    public partial class Form_Main : Form
    {
        #region fields
        // Job Pool
        private JobPool<Server> _JobPool;

        // Progress Bar
        private ToolProgressBarDialog _ProgressDialog;
        public delegate void DelegateUpdateProgressBar(string opText, string progressText);
        public DelegateUpdateProgressBar m_DelegateUpdateProgressBarText;

        // Message Box Delegates
        public delegate void DelegateGetWMICredentials(string server);
        public DelegateGetWMICredentials m_DelegateGetWMICredentials = null;

        // Working Fields
        private DataGridViewCellMouseEventArgs theCellImHoveringOver = null;
        private List<Server> servers;
        private List<Computer> _computers;
        private string _gridFileLabelBaseText = string.Empty;
        private BindingSource _bindingSource = new BindingSource();
        private Node lastSelectedIndexNode = null;

        #endregion

        #region Constructor

        public Form_Main()
        {
            InitializeComponent();
            this.Text = ideraTitleBar1.IderaProductNameText;
            //labelSubtitle.Text = ProductConstants.productDescription;
            m_DelegateUpdateProgressBarText = new DelegateUpdateProgressBar(this.ProgressBar_UpdateText);
            m_DelegateGetWMICredentials = new DelegateGetWMICredentials(this.GetWMICredentials);
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

        #region ProgressBar

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
            _JobPool.Cancel();
            ProgressBar_Close();
        }

        public void ProgressBar_CancelHandlerWorker(object sender, EventArgs e)
        {
            //_ProgressDialog.OperationText = "Cancelling...";
            //_ProgressDialog.CancelEnabled = false;
            //_ProgressDialog.Update();
            //FileRecord.Cancel();
            //ProductConstants.globalCancelRequested = true;
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
            //tabControl1.SelectedTab = tabControl1.Tabs[0];

            LoadViewModeComboBox();

            _bindingSource.DataSource = CreateDataTable();
            _dataGridViewX_Files.DataSource = _bindingSource;
            SetGridColumns();

            UpdateDashBoard(0, -1, -1, -1, "");

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

        #region Loading Results Functions

        private void buttonGetResults_Click(object sender, EventArgs e)
        {
            List<ServerInformation> _ServerList = ServerSelection.ServerList;

            // Validation
            if (_ServerList.Count == 0)
            {
                string msg;
                if (ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server)
                    msg = ProductConstants.msgServerNeeded;
                else
                    msg = ProductConstants.msgServerGroupEmpty;

                Messaging.ShowError(msg);

                return;
            }

            // save item to persisted MRU list
            MRU.AddServerOrGroup(ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server,
                                  ServerSelection.Text,
                                  ServerSelection.SqlCredentials);

            UpdateDashBoard(0, -1, -1, -1, "All Servers");

            _advTree_Disks.Nodes.Clear();
            _bindingSource.DataSource = CreateDataTable();
            UpdateControlsAndMenus(false);
            SetGridColumns();

            ProgressBar_Initialize(ProductConstants.LoadingFiles, ProgressBar_CancelHandlerLoad);

            servers = new List<Server>();
            _JobPool = new JobPool<Server>(5);
            _JobPool.ServerTaskComplete += new EventHandler<JobExecutionResultsEventArgs>(JobPoolGetTaskComplete);
            _JobPool.TaskComplete += new EventHandler<JobExecutionEventArgs>(JobPoolAllGetTasksComplete);
            _JobPool.Enqueue(LoadServerData, _ServerList, ToolsetOptions.commandTimeout);
            _JobPool.StartAsync();
            
            ProgressBar_Show();
        }
        private static object threadLock = new object();

        private Server LoadServerData(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
        {
            Server server = null;
            lock (threadLock)
            {
                using (CoreGlobals.traceLog.InfoCall())
                {
                    // Verify the server is 2000 or greater
                    try
                    {
                        using (
                            SqlConnection conn =
                                new SqlConnection(
                                    Connection.CreateConnectionString(serverInformation.Name, string.Empty,
                                                                      serverInformation.SqlCredentials)))
                        {
                            Connection.Impersonate(serverInformation.SqlCredentials);
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
                        string msg = string.Format("Error connecting to Server {0} {1}.", serverInformation.Name, Helpers.GetCombinedExceptionText(ex));

                        CoreGlobals.traceLog.InfoFormat("Error connecting to Server {0} - Exception: {1}.",
                                                         serverInformation.Name,
                                                         Helpers.GetCombinedExceptionText(ex));

                        throw new Exception(msg);
                    }

                    try
                    {
                        server = new Server(serverInformation.Name, serverInformation.SqlCredentials);

                        if (ProductConstants.globalCancelRequested)
                        {
                            ProductConstants.globalOperationCancelled = true;
                        }
                        else
                        {
                            server.LoadFiles(m_DelegateUpdateProgressBarText, m_DelegateGetWMICredentials);
                        }
                    }
                    catch (Exception ex)
                    {
                        ProductConstants.globalErrors.Add(string.Format("Loading file data for Server {0}", serverInformation.Name),
                            Helpers.GetCombinedExceptionText(ex));

                        CoreGlobals.traceLog.InfoFormat("Loading file data for Server {0} - Exception: {1}",
                                                         serverInformation.Name,
                                                         Helpers.GetCombinedExceptionText(ex));
                    }
                }
            }
            return server;
        }

        private void JobPoolGetTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            if (e.Status == TaskStatus.Failed)
            {
                ProductConstants.globalErrors.Add(e.Server.Name, e.ErrorMessage);
            }
            else if (e.Status == TaskStatus.Success)
            {
                Server server = (Server)e.Resultset;
                if (server != null)
                {
                    servers.Add(server);
                    foreach (KeyValuePair<string, string> kvp in server.ErrorReports)
                    {
                        ProductConstants.globalErrors.Add(string.Format("{0}: {1}", server.ServerName, kvp.Key),
                                                          kvp.Value);
                    }
                }
            }
        }

        private void JobPoolAllGetTasksComplete(object sender, JobExecutionEventArgs e)
        {
            if (ProductConstants.globalOperationCancelled == true)
            {
                Messaging.ShowInformation("Loading Files cancelled by user");
                ProductConstants.globalErrors.Clear();
                ProgressBar_Close();
            }
            else
            {
               if (ProductConstants.globalErrors.Count > 0)
               {
                   Form_MultipleErrorHandler errorDlg = new Form_MultipleErrorHandler();
                   errorDlg.Title = "Load File Errors";
                   errorDlg.Errors = ProductConstants.globalErrors;
                   errorDlg.ShowDialog(this);
                  ProductConstants.globalErrors.Clear();
               }

               ProgressBar_UpdateText("Calculating Disk Usage...", string.Empty);
               _computers = new List<Computer>();
               foreach (Server server in servers)
               {
                   foreach (KeyValuePair<string, DiskRecord> kvp in server.Disks)
                   {
                       DiskRecord d = kvp.Value;
                       Computer computer = new Computer(d.ComputerName);
                       Disk disk = new Disk(d);
                       if (disk.ContainsDatabases)
                       {
                           if (_computers.Contains(computer))
                           {
                               foreach (Computer c in _computers)
                               {
                                   if (c.Name == disk.ComputerName)
                                   {
                                       if (!c.Disks.Contains(disk))
                                       {
                                           disk.Files.AddRange(server.GetFilesForDisk(disk.DriveLetter));
                                           c.Disks.Add(disk);
                                           break;
                                       }
                                       else
                                       {
                                           foreach (Disk ed in c.Disks)
                                           {
                                               if (ed.DriveLetter == disk.DriveLetter)
                                               {
                                                   ed.Files.AddRange(server.GetFilesForDisk(disk.DriveLetter));
                                               }
                                           }
                                       }
                                   }
                               }
                           }
                           else
                           {
                               disk.Files.AddRange(server.GetFilesForDisk(disk.DriveLetter));
                               computer.Disks.Add(disk);
                               _computers.Add(computer);
                           }
                       }
                   }
               }
               ServerDataLoaded();
           }
        }

        private void ServerDataLoaded()
        {           
            if(servers.Count < 1)
            {
                ProgressBar_Close();
                return;
            }
            
            try
            {
            //LoadViewModeComboBox();

            LoadDiskTree();
            SetFilterOptions();
            }
            catch ( Exception ex )
            {
                CoreGlobals.traceLog.InfoFormat( "ServerDataLoaded {0}",
                                                 Helpers.GetCombinedExceptionText(ex));
            }
            
            ProgressBar_Close();

            UpdateControlsAndMenus(true);
            SetGridColumns();
            SortGridColumns();
        }

        private void InsertNodeSorted(NodeCollection nodes, Node n)
        {
            bool nodeInserted = false;
            if (nodes.Count > 0)
            {
                foreach (Node node in nodes)
                {
                    if (string.Compare(n.Text, node.Text) < 0)
                    {
                        nodes.Insert(node.Index, n);
                        nodeInserted = true;
                        break;
                    }
                }                
            }
            if(!nodeInserted)
            {
                nodes.Add(n);
            }
        }

        private void LoadDiskTree()
        {
            _advTree_Disks.Nodes.Clear();
            _advTree_Disks.ImageList = imageList1;
            Node nodeA = new Node();
            nodeA.Text = "All Servers";
            List<Disk> allServerDisks = new List<Disk>();
            foreach(Computer c in _computers)
            {
                allServerDisks.AddRange(c.Disks);
            }
            nodeA.Tag = allServerDisks;
            nodeA.ImageIndex = 2;
            foreach (Computer c in _computers)
            {
                Node nodeS = new Node();
                nodeS.Text = c.Name;
                nodeS.Tag = c.Disks;
                nodeS.ImageIndex = 3;
                List<string> SQLserverNames = c.SQLServers;
                foreach(string serverName in SQLserverNames)
                {
                    Node nodeSQL = new Node();
                    nodeSQL.Text = string.Format("SQL Server {0}", serverName);
                    nodeSQL.Tag = c.GetFilesForSQLServer(serverName);
                    nodeSQL.ImageIndex = 0;
                    List<string> databases = c.DatabasesForSQLServer(serverName);
                    foreach(string databaseName in databases)
                    {
                        Node nodeDatabase = new Node();
                        nodeDatabase.Text = databaseName;
                        nodeDatabase.Tag = c.GetFilesForDatabase(serverName, databaseName);
                        nodeDatabase.ImageIndex = 1;
                        InsertNodeSorted(nodeSQL.Nodes, nodeDatabase);
                    }
                    InsertNodeSorted(nodeS.Nodes, nodeSQL);
                }
                foreach (Disk d in c.Disks)
                {                   
                    Node nodeD = new Node();
                    if (d.DiskSize > 0)
                    {
                        nodeD.Text =
                            string.Format("{0} {1} ({2:P} free space)", d.DriveType, d.DriveLetter, d.DiskPercentFree);
                    }
                    else
                    {
                        nodeD.Text = string.Format("Local Disk {0} (unavailable)", d.DriveLetter);
                    }
                    List<Disk> ds = new List<Disk>();
                    ds.Add(d);
                    nodeD.Tag = ds;
                    if(d.DiskSize == 0)
                    {
                        nodeD.ImageIndex = 7;    
                    }
                    else if(d.IsDiskSpaceCritical)
                    {
                        nodeD.ImageIndex = 6; 
                    }
                    else if (d.IsDiskSpaceCaution)
                    {
                        nodeD.ImageIndex = 5;
                    }
                    else
                    {
                        nodeD.ImageIndex = 4;
                    }
                    InsertNodeSorted(nodeS.Nodes, nodeD);
                    nodeS.Expand();
                    
                }
                InsertNodeSorted(nodeA.Nodes, nodeS);
            }
            nodeA.Expand();
            InsertNodeSorted(_advTree_Disks.Nodes, nodeA);
            _advTree_Disks.SelectedNode = nodeA;
            
        }     

        private void LoadDatabaseTree()
        {
            List<FileRecord> allServerFiles = new List<FileRecord>();
            _advTree_Disks.Nodes.Clear();
            _advTree_Disks.ImageList = imageList1;
            int numFiles = 0;
            Node nodeA = new Node();
            foreach (Server s in servers)
            {
                numFiles += s.NumberFiles;
                foreach (KeyValuePair<string, DiskRecord> kvp in s.Disks)
                {
                    DiskRecord d = kvp.Value;
                    allServerFiles.AddRange(s.GetFilesForDisk(d.DriveLetter));
                }   
            }
            string fileText = numFiles == 1 ? "file" : "files";
            nodeA.Text = string.Format("{0} ({1} {2})", "All Servers", numFiles, fileText);
            nodeA.Tag = allServerFiles;
            nodeA.ImageIndex = 0;
            foreach (Server s in servers)
            {
                numFiles = s.NumberFiles;
                fileText = numFiles == 1 ? "file" : "files";
                Node nodeS = new Node();
                nodeS.Text = string.Format("{0} ({1} {2})", s.ServerName, numFiles, fileText);
                nodeS.Tag = s.Files;
                nodeS.ImageIndex = 1;
                foreach (KeyValuePair<string, DiskRecord> kvp in s.Disks)
                {
                    DiskRecord d = kvp.Value;
                    List<FileRecord> f = s.GetFilesForDisk(d.DriveLetter);
                    numFiles = f.Count;
                    fileText = numFiles == 1 ? "file" : "files";
                    Node nodeD = new Node();
                    nodeD.Text = string.Format("{0} {1} ({2:P} free space)", d.DriveType, d.DriveLetter, d.DiskPercentFree);
                    nodeD.Tag = f;
                    nodeD.ImageIndex = 2;
                    foreach (FileRecord file in f)
                    {
                        List<FileRecord> singleFile = new List<FileRecord>();
                        singleFile.Add(file);
                        Node nodeF = new Node();
                        nodeF.Text = file.LogicalName;
                        nodeF.Tag = singleFile;
                        nodeF.ImageIndex = 2;
                        nodeD.Nodes.Add(nodeF);
                    }
                    nodeS.Nodes.Add(nodeD);
                }
                nodeA.Nodes.Add(nodeS);
            }
            nodeA.Expand();
            _advTree_Disks.Nodes.Add(nodeA);
            _advTree_Disks.SelectedNode = nodeA;
        }

        private void LoadViewModeComboBox()
        {
            //_comboBoxEx_View.Items.Clear();
            ViewMode iViewMode = new ViewMode();
            iViewMode.View = ProductConstants.View_DiskSummary;
            iViewMode.GroupBoxText = ProductConstants.GroupText_DiskSummary;
            iViewMode.CriticalText = ProductConstants.CriticalText_DiskSummary;
            iViewMode.CautionText = ProductConstants.CautionText_DiskSummary;
            iViewMode.AcceptableText = ProductConstants.AcceptableText_DiskSummary;
            iViewMode.HelpTitle = ProductConstants.HelpTitle_DiskSummary;
            iViewMode.HelpText = ProductConstants.HelpText_DiskSummary;
            _comboBoxEx_View.Items.Add(iViewMode);
            _comboBoxEx_View.SelectedItem = iViewMode;


            ViewMode iViewMode1 = new ViewMode();
            iViewMode1.View = ProductConstants.View_DatabaseSummary;
            iViewMode1.GroupBoxText = ProductConstants.GroupText_DatabaseSummary;
            iViewMode1.CriticalText = ProductConstants.CriticalText_DatabaseSummary;
            iViewMode1.CautionText = ProductConstants.CautionText_DatabaseSummary;
            iViewMode1.AcceptableText = ProductConstants.AcceptableText_DatabaseSummary;
            iViewMode1.HelpTitle = ProductConstants.HelpTitle_DatabaseSummary;
            iViewMode1.HelpText = ProductConstants.HelpText_DatabaseSummary;
            _comboBoxEx_View.Items.Add(iViewMode1);

            //_comboBoxEx_Datatypeview.Items.Clear();
            ViewMode iViewMode2 = new ViewMode();
            iViewMode2.View = ProductConstants.View_KB;
            _comboBoxEx_Datatypeview.Items.Add(iViewMode2);

            ViewMode iViewMode3 = new ViewMode();
            iViewMode3.View = ProductConstants.View_MB;
            _comboBoxEx_Datatypeview.Items.Add(iViewMode3);

            ViewMode iViewMode4 = new ViewMode();
            iViewMode4.View = ProductConstants.View_GB;
            _comboBoxEx_Datatypeview.Items.Add(iViewMode4);

            ViewMode iViewMode5 = new ViewMode();
            iViewMode5.View = ProductConstants.view_default;
            _comboBoxEx_Datatypeview.Items.Add(iViewMode5);
            _comboBoxEx_Datatypeview.SelectedItem = iViewMode5;
            //iViewMode5;
        }

        #endregion

        #region DataTable

        DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("DatabaseName", typeof(string));
            dataTable.Columns.Add("LogicalFileName", typeof(FileRecord));
            dataTable.Columns.Add("ComputerName", typeof(string));
            dataTable.Columns.Add("DiskName", typeof(string));
            dataTable.Columns.Add("Type", typeof(string));
            dataTable.Columns.Add("SQLServer", typeof(string));
            //dataTable.Columns.Add("DatabaseName", typeof(string));
            dataTable.Columns.Add("FileGroup", typeof(string));
            dataTable.Columns.Add("FileSize", typeof(long));
            dataTable.Columns.Add("FileUsed", typeof(long));
            dataTable.Columns.Add("MaxSize", typeof(string));
            dataTable.Columns.Add("File_%_Used", typeof(double));
            dataTable.Columns.Add("File_%_Free", typeof(double));
            dataTable.Columns.Add("Growth", typeof(string));
            dataTable.Columns.Add("DiskSize", typeof(ulong));
            dataTable.Columns.Add("DiskUsed", typeof(ulong));
            dataTable.Columns.Add("DiskFree", typeof(ulong));
            dataTable.Columns.Add("Disk_%_Used", typeof(double));
            dataTable.Columns.Add("Disk_%_Free", typeof(double));
            dataTable.Columns.Add("%DataToUsed", typeof(double));            
            dataTable.Columns.Add("FilesOnDisk", typeof(int));
            dataTable.Columns.Add("TotalFileSpaceOnDisk", typeof(ulong));
            dataTable.Columns.Add("PhysicalFileName", typeof(string));
            dataTable.Columns.Add("Disk_%_UsedByFile", typeof(double));

            return dataTable;

        }

        DataTable CreateDataTableFromDisks(List<Disk> disks)
        {
            DataTable dataTable = CreateDataTable();
            foreach (Disk d in disks)
            {
                ulong totalFileSpace = 0;
                foreach(FileRecord file in d.Files)
                {
                    totalFileSpace += (ulong)file.Size;
                }
                
                dataTable.Rows.Add(new object[]
                                       {
                                           string.Empty, //
                                           null,
                                           d.ComputerName,
                                           d.DriveLetter,
                                           string.Empty,
                                           string.Empty,
                                           string.Empty,
                                           //string.Empty,
                                           0,
                                           0,
                                           string.Empty,
                                           0.0,
                                           0.0,
                                           string.Empty,
                                           d.DiskSize,
                                           d.DiskUsedSize,
                                           (d.DiskSize - d.DiskUsedSize > 0) ? d.DiskSize - d.DiskUsedSize : 0,
                                           d.DiskPercentUsed,
                                           d.DiskPercentFree,
                                           (d.DiskSize == 0) ? -1.0 : (double)totalFileSpace/d.DiskSize,
                                           d.Files.Count,
                                           totalFileSpace,
                                           string.Empty});

            }

            return dataTable;
        }

        DataTable CreateDataTableFromFiles(List<FileRecord> files)
        {
            DataTable dataTable = CreateDataTable();
            foreach (FileRecord f in files)
            {
                dataTable.Rows.Add(new object[] {   f.DatabaseName,f,
                                                    f.ComputerName,
                                                    f.DriveLetter,                                                    
                                                    f.Type,
                                                    f.ServerName,
                                                    //f.DatabaseName,
                                                    f.FileGroup,
                                                    f.Size,
                                                    f.UsedSize,
                                                    f.MaxSize,
                                                    f.PercentUsed,
                                                    1.0 - f.PercentUsed,
                                                    f.AutoGrowth,
                                                    f.DiskSize,
                                                    f.DiskUsedSize,
                                                    f.DiskSize - f.DiskUsedSize,
                                                    f.DiskPercentUsed,
                                                    f.DiskPercentFree,
                                                    0.0,
                                                    0,
                                                    0,
                                                    f.FullPathName,
                                                    f.PercentUsedRelativeToDisk});

            }

            return dataTable;
        }

        #endregion

        #region Grid Column Functions

        private void SortGridColumns()
        {
            if (_dataGridViewX_Files != null && _dataGridViewX_Files.Columns.Count > 0)
            {
                if (_comboBoxEx_View.SelectedItem != null)
                {
                    switch (_comboBoxEx_View.SelectedItem.ToString())
                    {
                        case ProductConstants.View_DiskSummary:
                            _dataGridViewX_Files.Sort(_dataGridViewX_Files.Columns["Disk_%_Used"], ListSortDirection.Descending);
                            break;
                        case ProductConstants.View_DatabaseSummary:
                            _dataGridViewX_Files.Sort(_dataGridViewX_Files.Columns["Disk_%_Used"], ListSortDirection.Descending);
                            break;
                        default:
                            _dataGridViewX_Files.Sort(_dataGridViewX_Files.Columns["Disk_%_Used"], ListSortDirection.Descending); ;
                            break;
                    }
                }
                _dataGridViewX_Files.ClearSelection();
                if (_dataGridViewX_Files.Rows.Count > 0)
                {
                    _dataGridViewX_Files.Rows[0].Selected = true;
                }
                UpdateFileLabel();
            }
        }

        private void SetGridColumns()
        {
            if (_dataGridViewX_Files != null && _dataGridViewX_Files.Columns.Count > 0)
            {
                if (_comboBoxEx_View.SelectedItem != null)
                {
                    switch (_comboBoxEx_View.SelectedItem.ToString())
                    {
                        case ProductConstants.View_DiskSummary:
                            SetDiskSummaryColumns();
                            break;
                        case ProductConstants.View_DatabaseSummary:
                            SetDatabaseSummaryColumns();
                            break;
                        default:
                            SetDiskSummaryColumns();
                            break;
                    }
                }
                else
                {
                    SetDiskSummaryColumns();
                }
            }
        }

        #region Add Grid Columns

        private void AddComputerNameColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("ComputerName"))
            {
                int i = _dataGridViewX_Files.Columns["ComputerName"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 20;
                _dataGridViewX_Files.Columns[i].HeaderText = "Computer";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Computer Name";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
//                _dataGridViewX_Files.Columns[i].Frozen = true;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
            }
        }

        private void AddDriveLetterColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("DiskName"))
            {
                int i = _dataGridViewX_Files.Columns["DiskName"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 20;
                _dataGridViewX_Files.Columns[i].HeaderText = "Drive";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Drive Letter";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
//                _dataGridViewX_Files.Columns[i].Frozen = true;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
            }
        }

        private void AddLogicalFileNameColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("LogicalFileName"))
            {
                int i = _dataGridViewX_Files.Columns["LogicalFileName"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 20;
                _dataGridViewX_Files.Columns[i].HeaderText = "Logical File Name";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Logical File Name";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                _dataGridViewX_Files.Columns[i].Frozen = true;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    if(_dataGridViewX_Files.Columns[i].Width > _dataGridViewX_Files.Width / 4)
                    {
                        _dataGridViewX_Files.Columns[i].Width = _dataGridViewX_Files.Width / 4;
                    }
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
            }
        }

        private void AddTypeColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("Type"))
            {
                int i = _dataGridViewX_Files.Columns["Type"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 20;
                _dataGridViewX_Files.Columns[i].HeaderText = "File Type";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Is this a data file or log file";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void AddSQLServerColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("SQLServer"))
            {
                int i = _dataGridViewX_Files.Columns["SQLServer"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 20;
                _dataGridViewX_Files.Columns[i].HeaderText = "SQL Server Instance";
                _dataGridViewX_Files.Columns[i].ToolTipText = "The SQL Server Instance that is using this file";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void AddDatabaseColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("DatabaseName"))
            {
                int i = _dataGridViewX_Files.Columns["DatabaseName"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 20;
                _dataGridViewX_Files.Columns[i].HeaderText = "Database";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Database Name";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    if (_dataGridViewX_Files.Columns[i].Width > _dataGridViewX_Files.Width / 4)
                    {
                        _dataGridViewX_Files.Columns[i].Width = _dataGridViewX_Files.Width / 4;
                    }
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
            }
        }

        private void AddFileGroupColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("FileGroup"))
            {
                int i = _dataGridViewX_Files.Columns["FileGroup"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 50;
                _dataGridViewX_Files.Columns[i].HeaderText = "File Group";
                _dataGridViewX_Files.Columns[i].ToolTipText = "File Group";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
            }
        }

        private void AddFileSizeColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("FileSize"))
            {
                int i = _dataGridViewX_Files.Columns["FileSize"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 50;
                _dataGridViewX_Files.Columns[i].HeaderText = "File Size";
                _dataGridViewX_Files.Columns[i].ToolTipText =
                    "Size of the File";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void AddFileUsedColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("FileUsed"))
            {
                int i = _dataGridViewX_Files.Columns["FileUsed"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 50;
                _dataGridViewX_Files.Columns[i].HeaderText = "Used Size";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Used Size";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
        }

        private void AddMaxSizeColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("MaxSize"))
            {
                int i = _dataGridViewX_Files.Columns["MaxSize"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 50;
                _dataGridViewX_Files.Columns[i].HeaderText = "Maximum Potential Size";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Maximum Potential Size";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
            }
        }

        private void AddFilePercentUsedColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("File_%_Used"))
            {
                int i = _dataGridViewX_Files.Columns["File_%_Used"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 120;
                _dataGridViewX_Files.Columns[i].HeaderText = "% Used";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Percentage of file space currently used";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void AddFilePercentFreeColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("File_%_Free"))
            {
                int i = _dataGridViewX_Files.Columns["File_%_Free"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 120;
                _dataGridViewX_Files.Columns[i].HeaderText = "% Free";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Percentage of file space currently free";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void AddGrowthColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("Growth"))
            {
                int i = _dataGridViewX_Files.Columns["Growth"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 20;
                _dataGridViewX_Files.Columns[i].HeaderText = "Auto Growth";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Auto Growth";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void AddDiskSizeColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("DiskSize"))
            {
                int i = _dataGridViewX_Files.Columns["DiskSize"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 20;
                _dataGridViewX_Files.Columns[i].HeaderText = "Disk Size";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Disk Size";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void AddDiskUsedColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("DiskUsed"))
            {
                int i = _dataGridViewX_Files.Columns["DiskUsed"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 20;
                _dataGridViewX_Files.Columns[i].HeaderText = "Disk Used";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Disk Used";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void AddDiskFreeColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("DiskFree"))
            {
                int i = _dataGridViewX_Files.Columns["DiskFree"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 20;
                _dataGridViewX_Files.Columns[i].HeaderText = "Disk Free";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Free space remaining on disk";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void AddDiskPercentUsedColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("Disk_%_Used"))
            {
                int i = _dataGridViewX_Files.Columns["Disk_%_Used"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 120;
                _dataGridViewX_Files.Columns[i].HeaderText = "% Disk Used";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Percentage of disk space currently used";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void AddDiskPercentFreeColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("Disk_%_Free"))
            {
                int i = _dataGridViewX_Files.Columns["Disk_%_Free"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 120;
                _dataGridViewX_Files.Columns[i].HeaderText = "% Disk Free";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Percentage of disk space currently free";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void AddPercentDataToUsedColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("%DataToUsed"))
            {
                int i = _dataGridViewX_Files.Columns["%DataToUsed"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 120;
                _dataGridViewX_Files.Columns[i].HeaderText = "% Used by Database Files";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Percentage of disk space used by database files";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void AddFilesOnDiskColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("FilesOnDisk"))
            {
                int i = _dataGridViewX_Files.Columns["FilesOnDisk"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 20;
                _dataGridViewX_Files.Columns[i].HeaderText = "Number Database Files";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Number of database files on disk";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
  
        private void AddTotalFileSpaceOnDiskColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("TotalFileSpaceOnDisk"))
            {
                int i = _dataGridViewX_Files.Columns["TotalFileSpaceOnDisk"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 20;
                _dataGridViewX_Files.Columns[i].HeaderText = "Size of Database Files";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Total space used by all database files on disk";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
 
        private void AddPhysicalFileNameColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("PhysicalFileName"))
            {
                int i = _dataGridViewX_Files.Columns["PhysicalFileName"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 20;
                _dataGridViewX_Files.Columns[i].HeaderText = "File Path";
                _dataGridViewX_Files.Columns[i].ToolTipText = "File Path";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void AddDiskPercentUsedByFileColumn(int width, int dispalyIndex, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (_dataGridViewX_Files.Columns.Contains("Disk_%_UsedByFile"))
            {
                int i = _dataGridViewX_Files.Columns["Disk_%_UsedByFile"].Index;
                _dataGridViewX_Files.Columns[i].Visible = true;
                _dataGridViewX_Files.Columns[i].DisplayIndex = dispalyIndex;
                _dataGridViewX_Files.Columns[i].Width = width;
                _dataGridViewX_Files.Columns[i].MinimumWidth = 120;
                _dataGridViewX_Files.Columns[i].HeaderText = "% Disk Used by Database File";
                _dataGridViewX_Files.Columns[i].ToolTipText = "Percentage of disk space used by the selected file";
                _dataGridViewX_Files.Columns[i].FillWeight = 100;
                if (autoSizeMode == DataGridViewAutoSizeColumnMode.DisplayedCells)
                {
                    _dataGridViewX_Files.AutoResizeColumn(i);
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                else
                {
                    _dataGridViewX_Files.Columns[i].AutoSizeMode = autoSizeMode;
                }
                _dataGridViewX_Files.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
                _dataGridViewX_Files.Columns[i].ReadOnly = true;
                _dataGridViewX_Files.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        #endregion

        private void SetDiskSummaryColumns()
        {
            int di = 0;
            foreach (DataGridViewColumn col in _dataGridViewX_Files.Columns)
            {
                col.Visible = false;
                col.Frozen = false;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
            _dataGridViewX_Files.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            _dataGridViewX_Files.AllowUserToResizeColumns = true;

            // Show these columns
            AddComputerNameColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddDriveLetterColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddFilesOnDiskColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddTotalFileSpaceOnDiskColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddDiskSizeColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddDiskUsedColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddDiskFreeColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddDiskPercentUsedColumn(160, di++, DataGridViewAutoSizeColumnMode.None);

            AddPercentDataToUsedColumn(120, di++, DataGridViewAutoSizeColumnMode.None);


        }

      

        private void SetDatabaseSummaryColumns()
        {
            int di = 0;
            foreach (DataGridViewColumn col in _dataGridViewX_Files.Columns)
            {
                col.Visible = false;
                col.Frozen = false;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
            _dataGridViewX_Files.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            _dataGridViewX_Files.AllowUserToResizeColumns = true;

            // Show these columns
            AddDatabaseColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddLogicalFileNameColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddTypeColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddFileSizeColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddFileUsedColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddFilePercentUsedColumn(100, di++, DataGridViewAutoSizeColumnMode.None);

            AddDiskSizeColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddDiskUsedColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddDiskPercentUsedColumn(100, di++, DataGridViewAutoSizeColumnMode.None);

            AddDiskPercentUsedByFileColumn(100, di++, DataGridViewAutoSizeColumnMode.None);

            AddFileGroupColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddGrowthColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddMaxSizeColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddComputerNameColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddDriveLetterColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddSQLServerColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            //AddDatabaseColumn(60, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

            AddPhysicalFileNameColumn(100, di++, DataGridViewAutoSizeColumnMode.DisplayedCells);

        }

        #endregion

        #region Update UI

        private void GetDiskCounts(List<Disk> disks, out int numDisks, out int numCritical, out int numCaution, out int numAcceptable )
        {
            numDisks = disks.Count;
            numCritical = 0;
            numCaution = 0;
            numAcceptable = 0;
            foreach (Disk disk in disks)
            {
                if (disk.IsDiskSpaceCritical)
                {
                    numCritical++;
                }
                else if (disk.IsDiskSpaceCaution)
                {
                    numCaution++;
                }
                else if(disk.DiskSize > 0)
                {
                    numAcceptable++;
                }
            }            
        }

        private void GetDiskCounts(List<FileRecord> files, out int numDisks, out int numCritical, out int numCaution, out int numAcceptable)
        {
            List<string> disks = new List<string>();
            numDisks = 0;
            numCritical = 0;
            numCaution = 0;
            numAcceptable = 0;
            foreach (FileRecord file in files)
            {
                string diskname = file.ComputerName + file.DriveLetter;
                if (!disks.Contains(diskname))
                {
                    disks.Add(diskname);
                    numDisks++;
                    if (file.IsDiskSpaceCritical)
                    {
                        numCritical++;
                    }
                    else if (file.IsDiskSpaceCaution)
                    {
                        numCaution++;
                    }
                    else if (file.DiskSize > 0)
                    {
                        numAcceptable++;
                    }
                }
            }
        }

        private void GetFileCounts(List<FileRecord> files, out int numFiles, out int numCritical, out int numCaution, out int numAcceptable)
        {
            numFiles = files.Count;
            numCritical = 0;
            numCaution = 0;
            numAcceptable = 0;
            foreach (FileRecord fr in files)
            {
                if (!fr.IsFiltered)
                {
                   // numFiles++;
                    if (fr.IsDiskSpaceCritical)
                    {
                        numCritical++;
                    }
                    else if (fr.IsDiskSpaceCaution)
                    {
                        numCaution++;
                    }
                    else if (fr.DiskSize > 0)
                    {
                        numAcceptable++;
                    }
                }
            }
        }
        
        private void UpdateDashBoard(bool resetDataSource)
        {
            if (_advTree_Disks.SelectedNode != null)
            {
                int numCritical = 0;
                int numCaution = 0;
                int numAcceptable = 0;
                int numDisks = 0;
                string filter = string.Empty;
                bool useFileMode = false;

                if (_advTree_Disks.SelectedNode.Level == 0)
                {
                    filter = "All Servers";
                }
                if (_advTree_Disks.SelectedNode.Level == 1)
                {
                    filter = string.Format("Computer '{0}'", _advTree_Disks.SelectedNode.Text);
                }
                if (_advTree_Disks.SelectedNode.Level == 2)
                {
                    filter = string.Format("'{0}'", _advTree_Disks.SelectedNode.Text);
                    if (_advTree_Disks.SelectedNode.Tag is List<FileRecord>)
                    {
                        useFileMode = true;
                        filter = string.Format("'{0}'", _advTree_Disks.SelectedNode.Text);
                    }
                }
                if (_advTree_Disks.SelectedNode.Level == 3)
                {
                    filter = string.Format("Database '{0}'", _advTree_Disks.SelectedNode.Text);
                    useFileMode = true;
                }

                ViewMode iViewMode = (ViewMode)_comboBoxEx_View.SelectedItem;
                List<FileRecord> allFiles = null;
                List<Disk> disks = null;
                if (useFileMode)
                {
                    allFiles = (List<FileRecord>)_advTree_Disks.SelectedNode.Tag;
                }
                else
                {
                    disks = (List<Disk>) _advTree_Disks.SelectedNode.Tag;
                }
                if (iViewMode.View == ProductConstants.View_DatabaseSummary)
                {
                    _checkBoxX_HideLogFiles.Visible = true;
                    _checkBoxX_HideDataFiles.Visible = true;
                    if (!useFileMode)
                    {
                        allFiles = new List<FileRecord>();
                        foreach (Disk d in disks)
                        {
                            allFiles.AddRange(d.Files);
                        }
                    }
                    if (resetDataSource)
                    {
                        _bindingSource.DataSource = CreateDataTableFromFiles(allFiles);                        
                    }
                    GetFileCounts(allFiles, out numDisks, out numCritical, out numCaution, out numAcceptable);
                }
                else
                {
                    _checkBoxX_HideLogFiles.Visible = false;
                    _checkBoxX_HideDataFiles.Visible = false;
                    if (useFileMode)
                    {
                        if (resetDataSource)
                        {
                            List<FileRecord> uniqueDisks = new List<FileRecord>();
                            List<string> diskNames = new List<string>();
                            foreach(FileRecord file in allFiles)
                            {
                                string diskName = file.ComputerName + file.DriveLetter;
                                if(!diskNames.Contains(diskName))
                                {
                                    diskNames.Add(diskName);
                                    uniqueDisks.Add(file);
                                }
                            }
                            _bindingSource.DataSource = CreateDataTableFromFiles(uniqueDisks);
                        }
                        GetDiskCounts(allFiles, out numDisks, out numCritical, out numCaution, out numAcceptable);
                    }
                    else if(disks != null)
                    {
                        if (resetDataSource)
                        {
                            _bindingSource.DataSource = CreateDataTableFromDisks(disks);
                        }
                        GetDiskCounts(disks, out numDisks, out numCritical, out numCaution, out numAcceptable);
                    }
                }


                UpdateDashBoard(numDisks, numCritical, numCaution, numAcceptable, filter);
            }
            else
            {
                UpdateDashBoard(0, -1, -1, -1, "");
            }
        }

        private void UpdateDashBoard(int files, int critical, int caution, int acceptable, string objectName)
        {
            ViewMode iViewMode = (ViewMode)_comboBoxEx_View.SelectedItem;
            if ((iViewMode != null))
            {
                _labelX_Critical.Text = string.Format(iViewMode.CriticalText, critical < 0 ? "?" : critical.ToString(), critical == 1 ? string.Empty : "s");
                _labelX_Caution.Text = string.Format(iViewMode.CautionText, caution < 0 ? "?" : caution.ToString(), caution == 1 ? string.Empty : "s");
                _labelX_Acceptable.Text = string.Format(iViewMode.AcceptableText, acceptable < 0 ? "?" : acceptable.ToString(), acceptable == 1 ? string.Empty : "s");
                _groupPanel_Summary.Text = string.Format(iViewMode.GroupBoxText, objectName);
                _gridFileLabelBaseText = string.Format("{0} for {1}", iViewMode.View, objectName);

                _labelX_HelpText.Text = iViewMode.HelpText;
                _labelX_HelpTitle.Text = iViewMode.HelpTitle;
                
                if (files > 0 && (ProductConstants.globalHideDataFiles || ProductConstants.globalHideLogFiles))
                {
                    int filteredfiles = 0;
                    if (_dataGridViewX_Files != null && _dataGridViewX_Files.Rows != null)
                    {
                        filteredfiles = files - _dataGridViewX_Files.Rows.Count;
                    }
                    _labelX_FilterText.Text = string.Format(ProductConstants.FilterText, filteredfiles, files);
                    _labelX_FilterText.Visible = true;
                }
                else
                {
                    _labelX_FilterText.Visible = false;
                }
            }
            UpdateFileLabel();

        }

        private void UpdateFileLabel()
        {
            int rows = _dataGridViewX_Files.Rows.Count;
            int selected = _dataGridViewX_Files.SelectedRows.Count;
            _labelX_FilesTitle.Text = string.Format("{0} ({1} file{2}, {3} selected)", _gridFileLabelBaseText, rows, rows == 1 ? string.Empty : "s", selected);            
        }    

        private void UpdateControlsAndMenus(bool bResetDataTable)
        {
            DataGridView dataGridView = _dataGridViewX_Files;
            UpdateDashBoard(bResetDataTable);

            if (dataGridView != null)
            {
                if (dataGridView.Rows.Count != 0)
                {
                    fileSaveMenu.Enabled = true;
                    editSelectAllMenuItem.Enabled = true;
                    contextMenuExport.Enabled = true;
                    contextMenuSelectAll.Enabled = true;
                    buttonCopyToClipboard.Enabled = true;
                    contextMenuFileProperties.Enabled = true;
                }
                else
                {
                    fileSaveMenu.Enabled = false;
                    editSelectAllMenuItem.Enabled = false;
                    contextMenuExport.Enabled = false;
                    contextMenuSelectAll.Enabled = false;
                    contextMenuFileProperties.Enabled = false;

                    buttonCopyToClipboard.Enabled = false;
                }

                if (dataGridView.SelectedRows.Count != 0)
                {
                    editCopyMenuItem.Enabled = true;
                    contextMenuCopy.Enabled = true;
                }
                else
                {
                    editCopyMenuItem.Enabled = false;
                    contextMenuCopy.Enabled = false;
                }

                if (dataGridView.SelectedRows.Count == 1)
                {
                    menuFileProperties.Enabled = true;
                }
                else
                {
                    menuFileProperties.Enabled = false;                    
                }
            }
            if( ((ViewMode)(_comboBoxEx_View.SelectedItem)).View == ProductConstants.View_DatabaseSummary )
            {
                contextMenuFileProperties.Enabled = true;
                menuFileProperties.Enabled = true;
            }
            else
            {
                contextMenuFileProperties.Enabled = false;
                menuFileProperties.Enabled = false;                
            }           
        }

        #endregion

  
        private void _advTree_Disks_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            if (e.Node != null && e.Node != lastSelectedIndexNode)
            {
                lastSelectedIndexNode = e.Node;
                int SortColumnIndex = (_dataGridViewX_Files.SortedColumn == null)
                                          ? 0
                                          : _dataGridViewX_Files.SortedColumn.Index;
                ListSortDirection sortDirection = (_dataGridViewX_Files.SortOrder == SortOrder.Ascending)
                                                      ? ListSortDirection.Ascending
                                                      : ListSortDirection.Descending;

                if (_advTree_Disks.SelectedNode.Level <= 1 )
                {
                    _comboBoxEx_View.SelectedItem = _comboBoxEx_View.Items[_comboBoxEx_View.FindStringExact(ProductConstants.View_DiskSummary)];
                }
                else
                {
                    _comboBoxEx_View.SelectedItem = _comboBoxEx_View.Items[_comboBoxEx_View.FindStringExact(ProductConstants.View_DatabaseSummary)];
                }     

                UpdateControlsAndMenus(true);
                SetGridColumns();
                SortGridColumns();

                if (_dataGridViewX_Files.Columns.Count >= SortColumnIndex)
                {
                    _dataGridViewX_Files.Sort(_dataGridViewX_Files.Columns[SortColumnIndex], sortDirection);
                }

            }
        }

        private void _comboBoxEx_View_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor curser = Cursor;
            Cursor = Cursors.WaitCursor;
            SetFilterOptions();
            UpdateControlsAndMenus(true);
            SetGridColumns();
            SortGridColumns();
            Cursor = curser;
            if (_comboBoxEx_Datatypeview.SelectedIndex != -1 && _comboBoxEx_Datatypeview.SelectedIndex != 0)
            {
                _comboBoxEx_Datatypeview.SelectedIndex = 3;
            }
        }

        private void _comboBoxEx_DataTypeView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor curser = Cursor;
            Cursor = Cursors.WaitCursor;
            SetFilterOptions();
            UpdateControlsAndMenus(true);
            SetGridColumns();
            SortGridColumns();
            Cursor = curser;
        }

   
        #region Menu & Button Handling

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

        private void menuFileProperties_Click(object sender, EventArgs e)
        {
            if (_dataGridViewX_Files.SelectedRows.Count == 1)
            {
                DataGridViewRow row = _dataGridViewX_Files.SelectedRows[0];
                if (row.Cells["LogicalFileName"].Value != DBNull.Value)
                {
                    ShowFileProperties((FileRecord)row.Cells["LogicalFileName"].Value);
                }
            }
        }

        private void contextMenuFileProperties_Click(object sender, EventArgs e)
        {
        
            if (theCellImHoveringOver != null && theCellImHoveringOver.RowIndex >= 0)
            {
                DataGridViewRow row = _dataGridViewX_Files.Rows[theCellImHoveringOver.RowIndex];
                if (row.Cells["LogicalFileName"].Value != DBNull.Value)
                {
                    ShowFileProperties((FileRecord)row.Cells["LogicalFileName"].Value);
                }
            }
        }

        private void checkBoxX_HideLogFiles_CheckedChanged(object sender, EventArgs e)
        {
            ProductConstants.globalHideLogFiles = _checkBoxX_HideLogFiles.Checked;
            SetFilterOptions();
            UpdateControlsAndMenus(false);
        }

        private void _checkBoxX_HideDataFiles_CheckedChanged(object sender, EventArgs e)
        {
            ProductConstants.globalHideDataFiles = _checkBoxX_HideDataFiles.Checked;
            SetFilterOptions();
            UpdateControlsAndMenus(false);
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
                          "  [ComputerName] [nvarchar](256)   NULL, " +
                          "  [DiskName] [nvarchar](12)   NULL, " +
                          "  [LogicalFileName] [nvarchar](256)   NULL, " +
                          "  [Type] [nvarchar](12) NULL, " +
                          "  [SQLServer] [nvarchar](256)   NULL, " +
                          "  [DatabaseName] [nvarchar](256) NULL, " +
                          "  [FileGroup] [nvarchar](256) NULL, " +
                          "  [FileSize] [BigInt] NULL, " +
                          "  [FileUsed] [BigInt] NULL, " +
                          "  [MaxSize] [nvarchar](256) NULL, " +
                          "  [File_%_Used] [float] NULL, " +
                          "  [File_%_Free] [float] NULL, " +
                          "  [Growth] [nvarchar](256) NULL, " +
                          "  [DiskSize] [BigInt] NULL, " +
                          "  [DiskUsed] [BigInt] NULL, " +
                          "  [Disk_%_Used] [float] NULL, " +
                          "  [Disk_%_Free] [float] NULL, " +
                          "  [%DataToUsed] [float] NULL, " +
                          "  [FilesOnDisk] [int] NULL, " +
                          "  [TotalFileSpaceOnDisk] [BigInt] NULL, " +
                          "  [PhysicalFileName] [nvarchar](256) NULL, " +
                          "  [Disk_%_UsedByFile] [float] NULL " +
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
                    if (((ViewMode)_comboBoxEx_View.SelectedItem).View == ProductConstants.View_DatabaseSummary)
                    {
                        FileRecord f = (FileRecord) (row.Cells["LogicalFileName"].Value);
                        if (f == null)
                        {
                            continue;
                        }
                        PopulateTable_AddProperty("ComputerName", SQLHelpers.CreateSafeString(f.ComputerName));
                        PopulateTable_AddProperty("DiskName", SQLHelpers.CreateSafeString(f.DriveLetter));
                        PopulateTable_AddProperty("LogicalFileName", SQLHelpers.CreateSafeString(f.LogicalName));
                        PopulateTable_AddProperty("Type", SQLHelpers.CreateSafeString(f.Type.ToString()));
                        PopulateTable_AddProperty("SQLServer", SQLHelpers.CreateSafeString(f.ServerName));
                        PopulateTable_AddProperty("DatabaseName", SQLHelpers.CreateSafeString(f.DatabaseName));
                        PopulateTable_AddProperty("FileGroup", SQLHelpers.CreateSafeString(f.FileGroup));
                        PopulateTable_AddProperty("FileSize", f.Size.ToString());
                        PopulateTable_AddProperty("FileUsed", f.UsedSize.ToString());
                        PopulateTable_AddProperty("MaxSize", SQLHelpers.CreateSafeString(f.MaxSize));
                        PopulateTable_AddProperty("File_%_Used", f.PercentUsed.ToString());
                        PopulateTable_AddProperty("File_%_Free", (1.0 - f.PercentUsed).ToString());
                        PopulateTable_AddProperty("Growth", SQLHelpers.CreateSafeString(f.AutoGrowth.ToString()));
                        PopulateTable_AddProperty("DiskSize", f.DiskSize.ToString());
                        PopulateTable_AddProperty("DiskUsed", f.DiskUsedSize.ToString());
                        PopulateTable_AddProperty("Disk_%_Used", f.DiskPercentUsed.ToString());
                        PopulateTable_AddProperty("Disk_%_Free", (f.DiskPercentFree).ToString());
                        PopulateTable_AddProperty("%DataToUsed", row.Cells["%DataToUsed"].Value.ToString());
                        PopulateTable_AddProperty("FilesOnDisk", row.Cells["FilesOnDisk"].Value.ToString());
                        PopulateTable_AddProperty("TotalFileSpaceOnDisk", row.Cells["TotalFileSpaceOnDisk"].Value.ToString());
                        PopulateTable_AddProperty("PhysicalFileName", SQLHelpers.CreateSafeString(row.Cells["PhysicalFileName"].Value.ToString()));
                        PopulateTable_AddProperty("Disk_%_UsedByFile", f.PercentUsedRelativeToDisk.ToString());
                    }
                    else
                    {
                        PopulateTable_AddProperty("ComputerName", SQLHelpers.CreateSafeString(row.Cells["ComputerName"].Value.ToString()));
                        PopulateTable_AddProperty("DiskName", SQLHelpers.CreateSafeString(row.Cells["DiskName"].Value.ToString()));
                        PopulateTable_AddProperty("DiskSize", row.Cells["DiskSize"].Value.ToString());
                        PopulateTable_AddProperty("DiskUsed", row.Cells["DiskUsed"].Value.ToString());
                        PopulateTable_AddProperty("Disk_%_Used", row.Cells["Disk_%_Used"].Value.ToString());
                        PopulateTable_AddProperty("Disk_%_Free", row.Cells["Disk_%_Free"].Value.ToString());
                        PopulateTable_AddProperty("%DataToUsed", row.Cells["%DataToUsed"].Value.ToString());
                        PopulateTable_AddProperty("FilesOnDisk", row.Cells["FilesOnDisk"].Value.ToString());
                        PopulateTable_AddProperty("TotalFileSpaceOnDisk", row.Cells["TotalFileSpaceOnDisk"].Value.ToString());
                    }

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
      
        #region Grid Events

        public string UnitOfMeasurement(double lBytes,bool isUlongtype)
        {
            string ConvertedValue;
            ViewMode iViewMode = (ViewMode)_comboBoxEx_Datatypeview.SelectedItem;
            if (iViewMode.View == ProductConstants.View_KB)
            {
                ConvertedValue = String.Format("{0:00.00}", ((double)lBytes / ProductConstants.ByteConversionValue));
            }
            else if (iViewMode.View == ProductConstants.View_MB)
            {
                ConvertedValue = String.Format("{0:00.00.00}", ((double)lBytes / (ProductConstants.ByteConversionValue * ProductConstants.ByteConversionValue)));
            }
            else if (iViewMode.View == ProductConstants.View_GB)
            {
                ConvertedValue = String.Format("{0:00.00.00.00.00}", ((double)lBytes / (ProductConstants.ByteConversionValue * ProductConstants.ByteConversionValue * ProductConstants.ByteConversionValue)));
            }
            else
            {
                if (isUlongtype)
                    ConvertedValue = Helpers.StrFormatByteSize((ulong)lBytes);
                else
                    ConvertedValue = Helpers.StrFormatByteSize((long)lBytes);
            }
            return ConvertedValue;
        }


        private void _dataGridViewX_Files_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            ViewMode iViewMode = (ViewMode)_comboBoxEx_Datatypeview.SelectedItem;
            if (e.ColumnIndex == _dataGridViewX_Files.Columns["FileUsed"].Index
                || e.ColumnIndex == _dataGridViewX_Files.Columns["FileSize"].Index)
            {
                e.FormattingApplied = true;
                DataGridViewX dv = (DataGridViewX)sender;
                if (Convert.ToInt64(dv.Rows[e.RowIndex].Cells["FileSize"].Value) == 0)
                {
                    e.Value = "unavailable";
                }
                else
                {
                    long lBytes = (long)e.Value;
                    double VBytes = (double)lBytes;
                    e.Value = UnitOfMeasurement(VBytes, false);

                }
            }
            else if (e.ColumnIndex == _dataGridViewX_Files.Columns["DiskSize"].Index
                || e.ColumnIndex == _dataGridViewX_Files.Columns["DiskUsed"].Index
                || e.ColumnIndex == _dataGridViewX_Files.Columns["DiskFree"].Index)
            {
                e.FormattingApplied = true;
                DataGridViewX dv = (DataGridViewX)sender;
                if (Convert.ToUInt64(dv.Rows[e.RowIndex].Cells["DiskSize"].Value) == 0)
                {
                    e.Value = "unavailable";
                }
                else
                {
                    ulong lBytes = (ulong)e.Value;
                    double VBytes = (double)lBytes;
                    e.Value = UnitOfMeasurement(VBytes, true);
                }
            }
            else if (e.ColumnIndex == _dataGridViewX_Files.Columns["TotalFileSpaceOnDisk"].Index)
            {
                e.FormattingApplied = true;
                ulong lBytes = (ulong)e.Value;
                double VBytes = (double)lBytes;
                e.Value = UnitOfMeasurement(VBytes, true);
            }     
            else if (e.ColumnIndex == _dataGridViewX_Files.Columns["File_%_Free"].Index
                    || e.ColumnIndex == _dataGridViewX_Files.Columns["File_%_Used"].Index)
            {
                e.FormattingApplied = true;
                DataGridViewX dv = (DataGridViewX) sender;
                if (Convert.ToInt64(dv.Rows[e.RowIndex].Cells["FileSize"].Value) == 0)
                {
                    e.Value = "unavailable";
                }
                else
                {
                    double value = (double) e.Value;
                    if (value < -0.0 || value > 1.0)
                    {
                        e.Value = "N/A";
                    }
                    else
                    {
                        string Svalue = string.Format("{0:P}", value);
                        if (iViewMode.View == ProductConstants.View_MB || iViewMode.View == ProductConstants.View_GB || iViewMode.View == ProductConstants.View_KB)
                        {
                            e.Value = Svalue.Replace(" %",string.Empty);
                        }
                        else
                        {
                            e.Value = Svalue;
                        }
                    }
                }
            }
            else if (e.ColumnIndex == _dataGridViewX_Files.Columns["Disk_%_Free"].Index
                     || e.ColumnIndex == _dataGridViewX_Files.Columns["Disk_%_Used"].Index
                     || e.ColumnIndex == _dataGridViewX_Files.Columns["%DataToUsed"].Index
                     || e.ColumnIndex == _dataGridViewX_Files.Columns["Disk_%_UsedByFile"].Index)
            {
                e.FormattingApplied = true;
                DataGridViewX dv = (DataGridViewX)sender;
                if (Convert.ToUInt64(dv.Rows[e.RowIndex].Cells["DiskSize"].Value) == 0)
                {
                    e.Value = "unavailable";
                }
                else
                {
                    double value = (double)e.Value;
                    if (value < -0.0 || value > 1.0)
                    {
                        e.Value = "N/A";
                    }
                    else
                    {
                        string svalue = string.Format("{0:P}", value);
                        if (iViewMode.View == ProductConstants.View_MB || iViewMode.View == ProductConstants.View_GB || iViewMode.View == ProductConstants.View_KB)
                        {

                            e.Value = svalue.Replace(" %",string.Empty);
                        }
                        else
                        {
                            e.Value = string.Format("{0:P}", value);
                        }
                    }
                }
            }           
        }

        private void _dataGridViewX_Files_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (_dataGridViewX_Files.Columns["File_%_Used"].Index ==
                        e.ColumnIndex && e.RowIndex >= 0)
            {
                DataGridViewRow row = _dataGridViewX_Files.Rows[e.RowIndex];
                double percent = 0.0;
                if (Convert.ToInt64(row.Cells["FileSize"].Value) == 0)
                {
                    percent = -1.0;
                }
                else
                {
                    percent = Convert.ToDouble(row.Cells["File_%_Used"].Value);
                }
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 0);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                DrawBar(row.Selected, e, percent, ProductConstants.CriticalPercentUsed, ProductConstants.AcceptablePercentUsed);

                // Paint Text
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            if (_dataGridViewX_Files.Columns["File_%_Free"].Index ==
                        e.ColumnIndex && e.RowIndex >= 0)
            {
                DataGridViewRow row = _dataGridViewX_Files.Rows[e.RowIndex];
                double percent = 0.0;
                if (Convert.ToInt64(row.Cells["FileSize"].Value) == 0)
                {
                    percent = -1.0;
                }
                else
                {
                    percent = Convert.ToDouble(row.Cells["File_%_Free"].Value);
                }
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 0);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                DrawBar(row.Selected, e, percent, ProductConstants.CriticalPercentFree, ProductConstants.AcceptablePercentFree);

                // Paint Text
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            if (_dataGridViewX_Files.Columns["Disk_%_Used"].Index ==
                        e.ColumnIndex && e.RowIndex >= 0)
            {
                DataGridViewRow row = _dataGridViewX_Files.Rows[e.RowIndex];
                double percent = 0.0;
                if (Convert.ToUInt64(row.Cells["DiskSize"].Value) == 0)
                {
                    percent = -1.0;
                }
                else
                {
                    percent = Convert.ToDouble(row.Cells["Disk_%_Used"].Value);
                }
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 0);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                DrawBar(row.Selected, e, percent, ProductConstants.CriticalPercentUsed, ProductConstants.AcceptablePercentUsed);

                // Paint Text
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            if (_dataGridViewX_Files.Columns["Disk_%_Free"].Index ==
                                   e.ColumnIndex && e.RowIndex >= 0)
            {
                DataGridViewRow row = _dataGridViewX_Files.Rows[e.RowIndex];
                double percent = 0.0;
                if (Convert.ToUInt64(row.Cells["DiskSize"].Value) == 0)
                {
                    percent = -1.0;
                }
                else
                {
                    percent = Convert.ToDouble(row.Cells["Disk_%_Free"].Value);
                }
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 0);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                DrawBar(row.Selected, e, percent, ProductConstants.CriticalPercentFree, ProductConstants.AcceptablePercentFree);

                // Paint Text
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            if (_dataGridViewX_Files.Columns["%DataToUsed"].Index ==
                                 e.ColumnIndex && e.RowIndex >= 0)
            {
                DataGridViewRow row = _dataGridViewX_Files.Rows[e.RowIndex];
                double percent = 0.0;
                if (Convert.ToUInt64(row.Cells["DiskSize"].Value) == 0)
                {
                    percent = -1.0;
                }
                else
                {
                    percent = Convert.ToDouble(row.Cells["%DataToUsed"].Value);
                }
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 0);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                DrawBar(row.Selected, e, percent, 0, 0, Color.SteelBlue, Color.LightSteelBlue);

                // Paint Text
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            if (_dataGridViewX_Files.Columns["Disk_%_UsedByFile"].Index ==
                        e.ColumnIndex && e.RowIndex >= 0)
            {
                DataGridViewRow row = _dataGridViewX_Files.Rows[e.RowIndex];
                double percent = 0.0;
                if (Convert.ToUInt64(row.Cells["DiskSize"].Value) == 0)
                {
                    percent = -1.0;
                }
                else
                {
                    percent = Convert.ToDouble(row.Cells["Disk_%_UsedByFile"].Value);
                }
                e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 0);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                DrawBar(row.Selected, e, percent, ProductConstants.CriticalPercentUsed, ProductConstants.AcceptablePercentUsed);

                // Paint Text
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
            //if (_dataGridViewX_Files.Columns["IsDisabled"].Index ==
            //                      e.ColumnIndex && e.RowIndex >= 0 && (string)e.Value == "Yes")
            //{

            //    e.CellStyle.SelectionBackColor = Color.FromArgb(255, 210, 0);
            //    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            //    DrawBar(e.State == DataGridViewElementStates.Selected, e, 0, 1.0, 0.0);

            //    // Paint Text
            //    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    e.PaintContent(e.CellBounds);
            //    e.Handled = true;
            //}
        }

        private void DrawBar(bool rowSelected, DataGridViewCellPaintingEventArgs e, 
                             double percent, double redThreshold, double greenThreshold)
        {
            DrawBar(rowSelected, e, percent, redThreshold, greenThreshold, Color.Empty, Color.Empty);
        }


        private void DrawBar(bool rowSelected, DataGridViewCellPaintingEventArgs e, 
                             double percent, double redThreshold, double greenThreshold,
                             Color barOnColor, Color barOffColor)
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
                // N/A color - blue
                backColor = Color.Blue;
                barBackColor = Color.FromArgb(200, 200, 255);
            }
            else if (!barOnColor.IsEmpty && !barOffColor.IsEmpty)
            {
                // Used specified colors
                barBackColor = barOffColor;
                backColor = barOnColor;
            }
            else
            {
                // Calulate color based off percent and thresholds
                barBackColor = Color.FromArgb(255, 255, 200);
                backColor = Color.Yellow;
                if (redThreshold == 1.0 && greenThreshold == 0.0)
                {
                    backColor = Color.Red;
                    barBackColor = Color.FromArgb(255, 200, 200);
                }
                else if (redThreshold == 1.0 && greenThreshold == 1.0)
                {
                    barBackColor = Color.FromArgb(255, 255, 200);
                    backColor = Color.Yellow;
                }
                else if (redThreshold == -1.0 && greenThreshold == -1.0)
                {
                    backColor = Color.Blue;
                    barBackColor = Color.FromArgb(200, 200, 255);
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

        private void _dataGridViewX_Files_SelectionChanged(object sender, EventArgs e)
        {
            if (_dataGridViewX_Files.Rows.Count > 0)
            {
                UpdateControlsAndMenus(false);
            }
        }

        private void _dataGridViewX_Files_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((ViewMode)_comboBoxEx_View.SelectedItem).View == ProductConstants.View_DatabaseSummary)
            {
               if (e.RowIndex >= 0)
               {
                   DataGridViewRow row = _dataGridViewX_Files.Rows[e.RowIndex];
                   if (row.Cells["LogicalFileName"].Value != DBNull.Value)
                   {
                       ShowFileProperties((FileRecord) row.Cells["LogicalFileName"].Value);
                   }
               }
            }
        }

        private void _dataGridViewX_Files_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                contextMenuFileProperties.Visible = false;
                theCellImHoveringOver = null;
            }
            else
            {
                contextMenuFileProperties.Visible = true;
                theCellImHoveringOver = e;
            }
        }

        private void _dataGridViewX_Files_MouseDown(object sender, MouseEventArgs e)
        {
            contextMenuFileProperties.Visible = false;
            theCellImHoveringOver = null;
        }

        #endregion


        private DataGridViewX GetActiveGrid()
        {
            return _dataGridViewX_Files;
        }

        private void ShowFileProperties(FileRecord f)
        {
            Form_FileProperties fileForm = new Form_FileProperties(f);
            fileForm.ShowDialog(this);
        }

        private void SetFilterOptions()
        {
            string temp = string.Empty;
            if (((ViewMode)_comboBoxEx_View.SelectedItem).View == ProductConstants.View_DatabaseSummary)
            {
                if (ProductConstants.globalHideLogFiles && ProductConstants.globalHideDataFiles)
                {
                    temp = string.Format("Type = 'HideAll?'");
                }
                else if (ProductConstants.globalHideLogFiles)
                {
                    if (!string.IsNullOrEmpty(temp))
                    {
                        temp += " and ";
                    }
                    temp = string.Format("Type = '{0}'", FileType.Data.ToString());
                }
                else if (ProductConstants.globalHideDataFiles)
                {
                    if (!string.IsNullOrEmpty(temp))
                    {
                        temp += " and ";
                    }
                    temp = string.Format("Type = '{0}'", FileType.Log.ToString());
                }
            }
            _bindingSource.Filter = temp;
        }

    
        #endregion   

        private void _advTree_Disks_MouseHover(object sender, EventArgs e)
        {
           if (Form.ActiveForm    == null ||
               Form.ActiveForm.ActiveControl == null ||
               Form.ActiveForm.ActiveControl != ServerSelection)
           {
              _advTree_Disks.Focus();
           }
        }

        private void _dataGridViewX_Files_MouseHover(object sender, EventArgs e)
        {
           if (Form.ActiveForm    == null ||
               Form.ActiveForm.ActiveControl == null ||
               Form.ActiveForm.ActiveControl != ServerSelection)
           {
              _dataGridViewX_Files.Focus();
           }
        }

       private void ShowF1Help(object sender, HelpEventArgs hlpevent)
       {
          HelpMenu.ShowHelp();
       }


        public void GetWMICredentials(string server)
        {
            if (InvokeRequired)
            {
                this.Invoke(m_DelegateGetWMICredentials, new object[] { server });
                return;
            }
            ProductConstants.globalWMIUser = string.Empty;
            ProductConstants.globalWMIPassword = string.Empty;

			if (ProductConstants.globalWMIEnable) //CGVAK -Condition for to display the WMI dialog
			{
				Form_GetWMICredentials dlg = new Form_GetWMICredentials(server);

				if( DialogResult.OK != dlg.ShowDialog())
				{
					ProductConstants.globalWMIUser = string.Empty;
					ProductConstants.globalWMIPassword = string.Empty;
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
		//CGVAK -Check changed function for checkBox_EnableWMI checkbox
		private void checkBox_EnableWMI_CheckedChanged(object sender, EventArgs e) 
		{
			ProductConstants.globalWMIEnable = checkBox_EnableWMI.Checked; 
		}
	}
}

