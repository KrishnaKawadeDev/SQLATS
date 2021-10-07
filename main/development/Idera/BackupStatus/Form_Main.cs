using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Idera.SqlAdminToolset.Core;
using Idera.SqlAdminToolset.Core.Export;
using IderaTrialExperienceCommon.Common;
using SortOrder = System.Windows.Forms.SortOrder;

namespace Idera.SqlAdminToolset.BackupStatus
{
    public partial class Form_Main : Form
    {
        #region Properties / Enums

        private readonly int m_NumberOfDaysForOld = 30;
        private JobPool<DataTable> m_JobPool;
        public static Dictionary<string, string> _ErrorReports = new Dictionary<string, string>();
        private const int UNKNOWN = -1;
        
        private ToolProgressBarDialog _ProgressDialog= new ToolProgressBarDialog();

        private static string overallStatus;
        public static string OverallStatus
        {
            get { return overallStatus; }
            set { overallStatus = value; }
        }

        private static int overallStatusPic = 3; //default to unknown pic
        public static int OverallStatusPic
        {
            get { return overallStatusPic; }
            set { overallStatusPic = value; }
        }

        private static int serversNeedingBackup;
        public static string ServersNeedingBackup
        {
            get
            {
                switch (serversNeedingBackup)
                {
                    case UNKNOWN:
                        return string.Format(ProductConstants.lblNeedingBackup, ProductConstants.lblUnknown, "s");
                    case 1:
                        return string.Format(ProductConstants.lblNeedingBackup, "1", "");
                    default:
                        return string.Format(ProductConstants.lblNeedingBackup, serversNeedingBackup, "s");
                }
            }
            set
            {
                serversNeedingBackup = ParseString(value);
            }
        }

        private static int neverBackedUp;
        public static string NeverBackedUp
        {
            get
            {
                switch (neverBackedUp)
                {
                    case UNKNOWN:
                        return string.Format(ProductConstants.lblNever, ProductConstants.lblUnknown, "s");
                    case 1:
                        return string.Format(ProductConstants.lblNever, "1", "");
                    default:
                        return string.Format(ProductConstants.lblNever, neverBackedUp, "s");
                }
            }
            set
            {
                neverBackedUp = ParseString(value);
            }
        }

        private static int noRecentBackup;
        public static string NoRecentBackup
        {
            get
            {
                string dayGrammar = GetDayGrammar(ProductConstants.NumberOfDaysForRecent);
                
                switch (noRecentBackup)
                {
                    case UNKNOWN:
                        return string.Format(ProductConstants.lblNotRecent, ProductConstants.lblUnknown, "s", dayGrammar);
                    case 1:
                        return string.Format(ProductConstants.lblNotRecent, "1", "", dayGrammar);
                    default:
                        return string.Format(ProductConstants.lblNotRecent, noRecentBackup, "s", dayGrammar);
                }
            }
            set
            {
                noRecentBackup = ParseString(value);
            }
        }

        private static int total;
        public static string Total
        {
            get
            {
                switch (total)
                {
                    case UNKNOWN:
                        return string.Format(ProductConstants.lblTotal, ProductConstants.lblUnknown, "s");
                    case 1:
                        return string.Format(ProductConstants.lblTotal, "1", "");
                    default:
                        return string.Format(ProductConstants.lblTotal, total, "s");
                }
            }
            set
            {
                total = ParseString(value);
            }
        }

        private static int newDatabases;
        public static string NewDatabases
        {
            get
            {
                switch (newDatabases)
                {
                    case UNKNOWN:
                        return string.Format(ProductConstants.lblNew, ProductConstants.lblUnknown, "s");
                    case 1:
                        return string.Format(ProductConstants.lblNew, "1", "");
                    default:
                        return string.Format(ProductConstants.lblNew, newDatabases, "s");
                }
            }
            set
            {
                newDatabases = ParseString(value);
            }
        }

        private static int serversScanned;
        public static string ServersScanned
        {
            get
            {
                switch (serversScanned)
                {
                    case UNKNOWN:
                        return string.Format(ProductConstants.lblServersScanned, ProductConstants.lblUnknown, "s");
                    case 1:
                        return string.Format(ProductConstants.lblServersScanned, "1", "");
                    default:
                        return string.Format(ProductConstants.lblServersScanned, serversScanned, "s");
                }
            }
            set
            {
                serversScanned = ParseString(value);
            }
        }
        
        public static string ShowOnlyFullBackups
        {
            get
            {
               return ProductConstants.optionsShowOnlyFull ? "True" : "False";
            }
        }
        
        
        #endregion

        #region Constructor

        public Form_Main()
        {
            InitializeComponent();
            this.Text = ideraTitleBar.IderaProductNameText;
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

            if (!Startup.GuiStartup(this, menuTools, menuAbout, ideraTitleBar))
            {
                Close();
                return;
            }

            #endregion

            ProductConstants.ReadOptions();
            
            checkExcludeSystemDatabases.Checked     = ProductConstants.optionsHideSystem;
            checkExcludeDatabasesWithBackup.Checked = ProductConstants.optionsHideDbsWithRecentBackups;
            checkIncludeOnlyFullBackups.Checked     = ProductConstants.optionsShowOnlyFull;
            checkExcludeOfflineDatabases.Checked    = ProductConstants.optionsHideOfflineDatabases;
            checkIncludeAllNodes.Checked            = ProductConstants.optionIncludeAllNodes;
             if ( ! checkIncludeOnlyFullBackups.Checked )
             {
                ColumnHeader hdr = new ColumnHeader();
                hdr.Text = "Last Backup Type";
                hdr.Width = 120;
                listResults.Columns.Insert(5,hdr );
                
                hdr = new ColumnHeader();
                hdr.Text = "Last Full Backup";
                hdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                hdr.Width = 120;
                listResults.Columns.Insert(7,hdr );
             }
            

            UpdateTitles();

            // dont update this one when you change value since it is the display from the last run
        }

        private void UpdateTitles()
        {
            string days = ProductConstants.NumberOfDaysForRecent.ToString();
            linkDays.Text = days + " days";
            //this.linkDays.LinkArea = new System.Windows.Forms.LinkArea( 0, days.Length );

            // only change summary entry if we have never run - otherwise update when we run test
            if (String.Compare(labelNoRecentBackup.Text.Substring(0, 9), "Databases", false) == 0)
            {
                labelNoRecentBackup.Text = String.Format(ProductConstants.initialStatus,
                                                         ProductConstants.NumberOfDaysForRecent);
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
            Launchpad.RunAndClose(this);
        }

        /// <summary>
        /// Shows the report so that they can print it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents(); // let form redraw after main menu closes

                DataSet dataSet = ExportToDataSet.CopyListView(listResults, "BackupStatus");

                //is there data?
                if (dataSet.Tables["BackupStatus"].Rows.Count == 0)
                {
                    MessageBox.Show("No data to print.\r\n\r\nPlease click 'Get Backup Status' to gather data for the report.", "No Data",
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
            HelpMenu.ShowDeactivateLicense();
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

        #region Get Backup History

        //private bool ValidateInput()
        //{
        //   if ( ServerSelection.Text.Trim().Length == 0)
        //   {
        //      Messaging.ShowError( "Specify a SQL Server instance name." );
        //      ServerSelection.Select();
        //      return false;
        //   }

        //   return true;
        //}

        private void CaptureData()
        {
            bool failed = false;

            try
            {
                List<ServerInformation> _ServerList = ServerSelection.ServerList;

                if (_ServerList.Count == 0)
                {
                    string msg;
                    if (ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server)
                        msg = "Specify at least one SQL Server.";
                    else
                        msg = "The selected Server Group contains no SQL Servers.";

                    Messaging.ShowError(msg);

                    return;
                }

                //Cursor = Cursors.WaitCursor;

                SetResultsLabel();

                ResetSort();
                listResults.Items.Clear();
                
                if ( checkIncludeOnlyFullBackups.Checked )
                {
                   // Kill columns 4 and 5
                   if ( listResults.Columns.Count == 10 )
                   {
                      listResults.Columns.RemoveAt(7);
                      listResults.Columns.RemoveAt(5);
                   }
                }
                else
                {
                   if ( listResults.Columns.Count == 8 )
                   {
                      ColumnHeader hdr = new ColumnHeader();
                      hdr.Text = "Last Backup Type";
                      hdr.Width = 120;
                      listResults.Columns.Insert(5,hdr );
                      
                      hdr = new ColumnHeader();
                      hdr.Text = "Last Full Backup";
                      hdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                      hdr.Width = 120;
                      listResults.Columns.Insert(7,hdr );
                      
                   }
                }

                labelEmptyResultSet.Visible = false;

                //labelStatus.Text = ProductConstants.lblLoading;
                //labelStatus.Visible = true;

                Application.DoEvents();

                // set up server threads
                _ErrorReports.Clear();

                Application.DoEvents();

                BackupRoutines.IncludeOnlyFullBackups = checkIncludeOnlyFullBackups.Checked;
                BackupRoutines.ExcludeDatabasesWithABackup = checkExcludeDatabasesWithBackup.Checked;
                BackupRoutines.ExcludeOldDatabases = checkExcludeOldDatabases.Checked;
                BackupRoutines.ExcludeOfflineDatabases = checkExcludeOfflineDatabases.Checked;
                BackupRoutines.ExcludeSystemDatabases = checkExcludeSystemDatabases.Checked;
                BackupRoutines.NumberOfDaysForRecent = ProductConstants.NumberOfDaysForRecent;
                BackupRoutines.NumberOfDaysForOld = m_NumberOfDaysForOld;
                
                ProgressBar_Initialize();
                
                BackupCounts.ResetCounts();

                m_JobPool = new JobPool<DataTable>(10);
                m_JobPool.ServerTaskComplete += JobPoolTaskComplete;
                m_JobPool.TaskComplete += AllTasksComplete;
                m_JobPool.Enqueue(BackupRoutines.LoadBackupStatus, _ServerList, ToolsetOptions.commandTimeout);
                m_JobPool.StartAsync();
                
                ProgressBar_Show();
            }
            catch (Exception exc)
            {
                failed = true;
                Messaging.ShowException("Backup Status", exc);
            }
            finally
            {
                if (failed)
                {
                    BackupCounts.serversScanned = 0;
                    ProgressBar_Close();
                    
                    UpdateDashboard();
                }
            }
        }

        void SetResultsLabel()
        {
            if (ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server)
            {
                if (ServerSelection.ServerList.Count == 0)
                {
                    groupResults.Text = "Backup Status";
                    labelDatabaseList.Text = "Backup Status for each Database";
                    return;
                }
                else if (ServerSelection.ServerList.Count > 1)
                {
                    groupResults.Text = String.Format("Multiple Server Backup Status");
                }
                else
                {
                    groupResults.Text = String.Format("Backup Status for {0}",
                                                       SQLHelpers.NormalizeInstanceName(ServerSelection.Text));
                }
            }
            else
            {
                groupResults.Text = String.Format("Server Group Backup Status");
            }

            string filter = "";
            if (checkExcludeDatabasesWithBackup.Checked)
            {
                filter += String.Format(" with no backup in the last {0} days", ProductConstants.NumberOfDaysForRecent);
            }
            if (checkExcludeOldDatabases.Checked)
            {
                if (filter != "")
                    filter += " and less than 90 days old";
                else
                    filter += " less than 90 days old";
            }
            if(checkExcludeOfflineDatabases.Checked)
            {
                if (filter != "")
                    filter += "and excluded Offline database";
                else
                    filter += " excluded Offline database";
            }
            labelDatabaseList.Text = "Backup status";

            if (filter == "")
                labelDatabaseList.Text += " (All databases)";
            else
                labelDatabaseList.Text += " (Databases" + filter + ")";
        }

        void AllTasksComplete(object sender, JobExecutionEventArgs e)
        {
            using ( CoreGlobals.traceLog.DebugCall() )
            {
               CoreGlobals.traceLog.DebugFormat( "All tasks complete - errorcount {0} success {1} failed {2}",
                                                 _ErrorReports.Count,
                                                 e.SuccessCount,
                                                 e.FailedCount );
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
                       BeginInvoke((MethodInvoker)delegate() { frm.ShowDialog(); });
                   }
               }
               finally
               {
                   UpdateDashboard();
                   m_JobPool = null;
               }
            }
        }

        //private delegate void setLabelText(int index, string text, int width);
        //private delegate ListView.ListViewItemCollection getItemsDelegate();
        //private delegate void insertSubItem(int index, ListViewItem.ListViewSubItem subitem);

        void JobPoolTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            using ( CoreGlobals.traceLog.DebugCall() )
            {
               CoreGlobals.traceLog.DebugFormat( "Task Complete for server {0} - status {1}", e.Server, e.Status );
               
               if (e.Status == TaskStatus.Failed)
               {
                   _ErrorReports.Add(e.Server.Name, e.ErrorMessage);
               }
               else if (e.Status == TaskStatus.Success)
               {
                   listResults.BeginUpdate();
                   AddResultToListView((DataTable)e.Resultset);
                   listResults.EndUpdate();
                   
                   ((DataTable)e.Resultset).Dispose();;
               }
               else if (e.Status != TaskStatus.Cancelled)
               {
                   _ErrorReports.Add(e.Server.Name, "Invalid Job State: " + e.Status);
               }
            }
        }

        private void AddResultToListView(DataTable dataTable)
        {
            BackupResultTable brt = new BackupResultTable(dataTable);
            for (int i = 0; i < brt.dataTable.Rows.Count; i++)
            {
                BackupResult br = brt.GetRow(i);

                ListViewItem r = new ListViewItem("", br.backupStatus);

                r.SubItems.Add(SQLHelpers.NormalizeInstanceName(br.server));
                var dbname = br.database;
                if (!string.IsNullOrEmpty(br.nodetype))
                    dbname += String.Format(" ({0}) ", br.nodetype);
                r.SubItems.Add(dbname);
                r.SubItems.Add(br.systemDatabase ? "System" 
                                                 : br.mirroringRole == 2 ? "Mirror"
                                                                         : "User");
                if ( br.mirroringRole == 2 )
                {
                   // Datbase is a mirror - backsup dont apply
                   r.SubItems.Add( "" );
                   if ( ! checkIncludeOnlyFullBackups.Checked ) r.SubItems.Add("");
                   r.SubItems.Add("");
                   if ( ! checkIncludeOnlyFullBackups.Checked ) r.SubItems.Add("");                   
                }
                else
                {
                   r.SubItems.Add((br.lastBackup == DateTime.MinValue)
                                       ? "Never"
                                       : br.lastBackup.ToString());
                   if ( ! checkIncludeOnlyFullBackups.Checked )
                   {
                      r.SubItems.Add(br.backupType);
                   }
                   r.SubItems.Add((br.backupSize == -1)
                                       ? ""
                                       : Helpers.StrFormatByteSize(br.backupSize));
                   if ( ! checkIncludeOnlyFullBackups.Checked )
                   {
                      r.SubItems.Add((br.lastFullBackup == DateTime.MinValue)
                                          ? "Never"
                                          : br.lastFullBackup.ToString());
                   }                    
                }
                r.SubItems.Add(br.dateCreated.ToShortDateString());
                r.SubItems.Add(br.RecoveryMode);
                r.Tag = br;

                listResults.Items.Add(r);
            }
        }

        private void buttonGetBackupHistory_Click(object sender, EventArgs e)
        {
            // Save Checkbox states
            ProductConstants.optionsHideSystem               = checkExcludeSystemDatabases.Checked;
            ProductConstants.optionsHideDbsWithRecentBackups = checkExcludeDatabasesWithBackup.Checked;
            ProductConstants.optionsShowOnlyFull             = checkIncludeOnlyFullBackups.Checked;
            ProductConstants.optionsHideOfflineDatabases     = checkExcludeOfflineDatabases.Checked;
            ProductConstants.WriteOptions();
            
            // save item to persisted MRU list
            MRU.AddServerOrGroup(ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server,
                                  ServerSelection.Text,
                                  ServerSelection.SqlCredentials);

            CaptureData();
        }

        private void UpdateDashboard()
        {
            try
            {
               //labelStatus.Visible = false; 
            
            
               if (BackupCounts.serversScanned != 0)
               {
                   if (listResults.Items.Count != 0)
                   {
                       listResults.Items[0].Selected = true;
                       listResults.Select();
                   }
    
                   menuSelectAll.Enabled = 
                       contextMenuSelectAll.Enabled = 
                       menuExport.Enabled = 
                       contextMenuExport.Enabled = 
                       printToolStripMenuItem.Enabled = 
                       buttonCopyToClipboard.Enabled = (listResults.Items.Count != 0); // enable if there's results

                   #region overall status

                   // format for correct grammar regarding number of days
                   string numDaysRecent = GetDayGrammar(ProductConstants.NumberOfDaysForRecent);

                   if (BackupCounts.databasesWithNoBackup != 0)
                   {
                       int count = BackupCounts.databasesWithNoBackup + BackupCounts.databasesWithNoRecentBackup;
                       OverallStatus = String.Format("{0} database{1} need{2} to be backed up.",
                           count,
                           count == 1 ? "" : "s",   // make noun plural
                           count == 1 ? "s" : "");  // make verb singular
                       
                       OverallStatusPic = 2; //error image
                   }
                   else if (BackupCounts.databasesWithNoRecentBackup != 0)
                   {
                       int count = BackupCounts.databasesWithNoRecentBackup;
                       OverallStatus = String.Format("{0} database{1} need{2} to be backed up.",
                           count,
                           count == 1 ? "" : "s",   // make noun plural
                           count == 1 ? "s" : "");  // make verb singular

                       OverallStatusPic = 1; //warning image
                   }
                   else
                   {
                       OverallStatus = String.Format("All databases have been backed up in the last {0}", numDaysRecent);

                       OverallStatusPic = 0; //ok image
                   }

                   #endregion

                   ServersNeedingBackup = BackupCounts.serversNeedingBackups.ToString();
                   NeverBackedUp = BackupCounts.databasesWithNoBackup.ToString();
                   NoRecentBackup = (BackupCounts.databasesWithNoRecentBackup).ToString();
                   Total = BackupCounts.matchingDatabases.ToString();
                   NewDatabases = BackupCounts.newDatabases.ToString();

                   //labelStatus.Text = string.Format(ProductConstants.lblStatus,
                   //                                  BackupCounts.databasesWithNoBackup + BackupCounts.databasesWithNoRecentBackup,
                   //                                  BackupCounts.matchingDatabases,
                   //                                  GetDayGrammar(ProductConstants.NumberOfDaysForRecent));
               }
               else
               {
                   //labelStatus.Visible = false; 
                   
                   OverallStatus = "No servers successfully scanned";
                   OverallStatusPic = 2; // error pic

                   ServersNeedingBackup =
                       NeverBackedUp =
                       NoRecentBackup =
                       Total =
                       NewDatabases = UNKNOWN.ToString();
               }

               serversScanned = BackupCounts.serversScanned;
               labelServersScanned.Text = ServersScanned;
               labelOverallStatus.Text = OverallStatus;
               pictureOverallStatus.Image = imageOverallStatus.Images[OverallStatusPic];
               labelServersNeedingBackup.Text = ServersNeedingBackup;
               labelNeverBackedUp.Text = NeverBackedUp;
               labelNoRecentBackup.Text = NoRecentBackup;
               labelTotal.Text = Total;
               labelNewDatabases.Text = NewDatabases;
            }
            catch ( Exception ex )
            {
               string msg = String.Format( "An internal error occurred preparing the results of the backup status search.\r\n\r\nError: {0}", ex.Message );
               Messaging.ShowError( msg  );
               CoreGlobals.traceLog.Error( msg );
            }
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
            if (_ProgressDialog != null)
            {
                _ProgressDialog.TopLevel = false;
                _ProgressDialog.Visible = false;
                _ProgressDialog.Close();
                _ProgressDialog.ProgressCancelEvent -= ProgressBar_CancelHandler;
            }
        }

        public void ProgressBar_Initialize()
        {
            _ProgressDialog.TopLevel = true;
            _ProgressDialog.OperationText = "Loading Backup Data...";
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
                BackupResult br1 = (BackupResult)(((ListViewItem)x).Tag);
                BackupResult br2 = (BackupResult)(((ListViewItem)y).Tag);

                if (col == 0 /* Icon */ )
                {
                    returnVal = 0;
                    if (br1.backupStatus < br2.backupStatus) returnVal = -1;
                    if (br1.backupStatus > br2.backupStatus) returnVal = 1;
                }
                else if (col == 4 /* Last Backup Date */ )
                {
                    returnVal = DateTime.Compare(br1.lastBackup, br2.lastBackup);
                }
                else if (col == 6 /* Backup Size */ )
                {
                    if (col == 6 && true == true)
                    {
                        returnVal = DateTime.Compare(br1.dateCreated, br2.dateCreated);
                    }
                    else
                    { 
                    returnVal = 0;
                    if (br1.backupSize < br2.backupSize) returnVal = -1;
                    if (br1.backupSize > br2.backupSize) returnVal = 1;
                    }
                }
                else if (col == 7 /* Last Full Backup */ )
                {
                    returnVal = DateTime.Compare(br1.lastFullBackup, br2.lastFullBackup);
                }
                else if (col == 8 /* Create Date */ )
                {
                    returnVal = DateTime.Compare(br1.dateCreated, br2.dateCreated);
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

        #region Show Backup History

        private void buttonShowBackupHistory_Click(object sender, EventArgs e)
        {
            ShowBackupHistory();
        }

        private void ShowBackupHistory()
        {
            if (listResults.SelectedItems.Count == 0)
            {
                buttonShowBackupHistory.Enabled = false;
                return;
            }

            string databaseName = listResults.SelectedItems[0].SubItems[2].Text;
            string serverName   = listResults.SelectedItems[0].SubItems[1].Text;
            
            SQLCredentials credentials;
            if ( ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server )
            {
               credentials = ServerSelection.SqlCredentials;
            }
            else
            {
               credentials = ToolServerGroup.GetServerCredentials( ServerSelection.SelectedGroup, serverName );
            }

            BackupHistory frm = new BackupHistory(serverName,
                                                  credentials,
                                                  databaseName);
            frm.ShowDialog();
        }

        private void listResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool someSelected = (listResults.SelectedItems.Count != 0);
            
            if ( someSelected && listResults.SelectedItems[0].SubItems[3].Text != "Mirror" )
            {
               buttonShowBackupHistory.Enabled      = 
               contextMenuShowBackupHistory.Enabled = true;
            }
            else
            {
               buttonShowBackupHistory.Enabled      = 
               contextMenuShowBackupHistory.Enabled = false;
            }
            
            menuCopy.Enabled = someSelected;
            contextMenuCopy.Enabled = someSelected;
        }

        private void listResults_DoubleClick(object sender, EventArgs e)
        {
           if ( buttonShowBackupHistory.Enabled ) ShowBackupHistory();
        }

        private void showBackupHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowBackupHistory();
        }

        #endregion

        #region Clipboard / Save Results As

        private void buttonCopyToClipboard_Click_1(object sender, EventArgs e)
        {
            CopyToClipboard(false);
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard(true);
        }

        private void contextMenuCopyToClipboard_Click(object sender, EventArgs e)
        {
            CopyToClipboard(true);
        }

        private void CopyToClipboard(bool selectedOnly)
        {
            ExportToClipboard.CopyListViewToTabbedFormat(listResults, true, selectedOnly);

            /*
               int [] columnWidths = { 0,    // icon
                                       20,   // server
                                       20,   // database
                                       6,    // db type
                                       22,   // lastBackup
                                       11,   // backupType
                                       11,   // backupSize
                                       22,    // lastFullBackup
                                       12 }; // dateCreated

               ExportToClipboard.CopyListView( labelDatabaseList.Text,
                                           listResults,
                                           columnWidths );
             */
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
            foreach (ListViewItem lvi in listResults.Items)
            {
                lvi.Selected = true;
            }
        }

        private void menuCSV_Click(object sender, EventArgs e)
        {
            ExportToCSV.CopyListView(listResults);
        }

        private void menuXML_Click(object sender, EventArgs e)
        {
            ExportToXML.CopyListView(listResults, "Backup Status", true);
        }

        private void contextMenuCSV_Click(object sender, EventArgs e)
        {
            ExportToCSV.CopyListView(listResults);
        }

        private void contextMenuXML_Click(object sender, EventArgs e)
        {
            ExportToXML.CopyListView(listResults, "Backup Status", true);
        }

        #endregion

        private void ServerSelection_TextChanged(object sender, EventArgs e)
        {
            buttonGetBackupHistory.Enabled = (ServerSelection.Text != "");
        }

        private void listResults_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowBackupHistory();
            }
        }

        private void listResults_Enter(object sender, EventArgs e)
        {
            AcceptButton = null; //buttonGetBackupHistory;
        }

        private void listResults_Leave(object sender, EventArgs e)
        {
            AcceptButton = buttonGetBackupHistory;
        }

        private void contextMenuSaveAsDataTable_Click(object sender, EventArgs e)
        {
            SaveDataTable();
        }

        private void dataTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDataTable();
        }

        private void SaveDataTable()
        {
            ExportToTable.CreateTableDelegate ctd = this.CreateTable;
            ExportToTable.PopulateTableDelegate ptd = this.PopulateTable;

            ExportToTable.Export(ctd, ptd);
        }

        #region Export Support

        public void CreateTable(SqlConnection conn, string tableName) //include owner name
        {
            string sql = "CREATE TABLE {0}( " +
                          "  [SqlServer] [nvarchar](256)   NULL, " +
                          "  [Database] [nvarchar](256)   NULL, " +
                          "  [Type] [nvarchar](32)   NULL, " +
                          "  [LastBackup] [datetime] NULL, " +
                          "  [BackupType] [nvarchar](32)   NULL, " +
                          "  [BackupSize] [float] NULL, " +
                          "  [LastFullBackup] [datetime] NULL, " +
                          "  [DateCreated] [datetime] NULL " +
                          ")";

            string cmd = String.Format(sql, tableName);

            using (SqlCommand command = new SqlCommand(cmd, conn))
            {
                command.CommandTimeout = ToolsetOptions.commandTimeout;
                command.ExecuteNonQuery();
            }
        }

        static readonly StringBuilder props = new StringBuilder(2048);
        protected static StringBuilder values = new StringBuilder(2048);

        public void PopulateTable(SqlConnection conn, string tableName) //include owner name
        {
            foreach (ListViewItem lvi in listResults.Items)
            {
                props.Length = 0;
                values.Length = 0;

                BackupResult br = (BackupResult)lvi.Tag;

                PopulateTable_AddProperty("SqlServer", SQLHelpers.CreateSafeString(br.server));
                PopulateTable_AddProperty("Database", SQLHelpers.CreateSafeString(br.database));
                PopulateTable_AddProperty("Type", SQLHelpers.CreateSafeString(br.systemDatabase ? "System" : "User"));
                PopulateTable_AddProperty("LastBackup", SQLHelpers.CreateSafeDateTimeString(br.lastBackup));
                PopulateTable_AddProperty("BackupType", SQLHelpers.CreateSafeString(br.backupType));
                PopulateTable_AddProperty("BackupSize", br.backupSize.ToString());
                PopulateTable_AddProperty("LastFullBackup", SQLHelpers.CreateSafeDateTimeString(br.lastFullBackup));
                PopulateTable_AddProperty("DateCreated", SQLHelpers.CreateSafeDateTimeString(br.dateCreated));

                string sql = String.Format("INSERT INTO {0} ({1}) VALUES ({2})",
                                             tableName,
                                             props,
                                             values);

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.CommandTimeout = ToolsetOptions.commandTimeout;
                    command.ExecuteNonQuery();
                }
            }
        }

        static private void PopulateTable_AddProperty(string propertyName, string propertyValue)
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

        private void menuBackupStatusOptions_Click(object sender, EventArgs e)
        {
           ShowBackupStatusOptions();
        }
        
        private void            ShowBackupStatusOptions()
        {
            Form_BackupStatusOptions frm = new Form_BackupStatusOptions();
            DialogResult choice = frm.ShowDialog();

            if (choice == DialogResult.OK)
            {
                UpdateTitles();
            }
        }
        
       private void linkDays_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
       {
           ShowBackupStatusOptions();
       }
       
       private void ShowF1Help(object sender, HelpEventArgs hlpevent)
       {
          HelpMenu.ShowHelp();
       }
        

        #region helpers

        /// <summary>
        /// format for correct grammar regarding number of days
        /// </summary>
        /// <param name="numDays">number of days to check</param>
        /// <returns>correct grammar for number of days</returns>
        private static string GetDayGrammar(int numDays)
        {
            if (numDays < 0) numDays = 0; //to handle unknown
            
            return numDays == 1
                ? "1 day"
                : string.Format("{0} days", numDays);
        }


        /// <summary>
        /// Parses the string value into an int.
        /// </summary>
        /// <param name="value">string to parse</param>
        /// <returns>int of parsed value- returns const UNKNOWN if it can't parse</returns>
        private static int ParseString(string value)
        {
            int val;
            bool parsed = Int32.TryParse(value, out val);

            if (!parsed)
                return UNKNOWN;
            else
                return val;
        }

        #endregion

       private void menuHelp_Click(object sender, EventArgs e)
       {
          base.OnClick(e);
       }

        private void menuManageLicense_Click(object sender, EventArgs e)
        {
            
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar.LicenseInformation = LicenseUI.GetLicenseInfo();
        }

        private void ideraTitleBar_LicenseInfoButtonClick(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar.LicenseInformation = LicenseUI.GetLicenseInfo();
        }
    }
}