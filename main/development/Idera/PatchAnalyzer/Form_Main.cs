using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core;
using Idera.SqlAdminToolset.Core.Export;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using IderaTrialExperienceCommon.Common;
using System.Linq;

namespace Idera.SqlAdminToolset.PatchAnalyzer
{
    public partial class Form_Main : Form
    {
        #region Properties

        private JobPool<DataTable> m_JobPool;

        private List<PatchData> m_PatchList;

        private Dictionary<string, string> _ErrorReports = new Dictionary<string, string>();
        
        private ToolProgressBarDialog _ProgressDialog;

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

            // Program Specific Logic
            LoadPatchFiles();
            this.listSQL.Groups.Clear();
            var listViewGroup1 = new ListViewGroup();
            listViewGroup1.Header = "Unknown SQL Server Version";
            listViewGroup1.Name = "groupUnknown";
            this.listSQL.Groups.Add(listViewGroup1);
          
            var listViewGroup9 = new ListViewGroup();
            listViewGroup9.Header = "SQL Server 7.0";
            listViewGroup9.Name = "group70";
            var listViewGroup10 = new ListViewGroup();
            listViewGroup10.Header = "SQL Server 6.5";
            listViewGroup10.Name = "group65";

           
            foreach (string sqlServerVersion in SQLServerVersion.SqlServerVersionList.OrderByDescending(x => x.Major).Select(x => x.Product).Distinct (StringComparer.CurrentCultureIgnoreCase))
            {
                if (!string.IsNullOrEmpty(sqlServerVersion))
                {
                    var grp = new System.Windows.Forms.ListViewGroup(sqlServerVersion, HorizontalAlignment.Left);
                    this.listSQL.Groups.Add(grp);
                }
            }

            this.listSQL.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup9,
            listViewGroup10
            });
            m_PatchList = new List<PatchData>();
           
            var productlist= SQLServerVersion.SqlServerVersionList.OrderByDescending(x => x.Major).Select(x => x.Product).Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();
            if (productlist.Count > 0)
            {
                labelServer1Title.Text = productlist[0] + ":";
                labelServer1.Name = productlist[0];
            }
            if (productlist.Count > 1)
            {
                labelServer2Title.Text = productlist[1] + ":";
                labelServer2.Name = productlist[1];
            }
            if (productlist.Count > 2)
            {
                labelServer3Title.Text = productlist[2] + ":";
                labelServer3.Name = productlist[2];
            }
            if (productlist.Count > 3)
            {
                labelServer4Title.Text = productlist[3] + ":";
                labelServer4.Name = productlist[3];
            }
            if (productlist.Count > 4)
            {
                labelServer5Title.Text = productlist[4] + ":";
                labelServer5.Name = productlist[4];
            }
            if (productlist.Count > 5)
            {
                labelserver6Title.Text = productlist[5] + ":";
                labelServer6.Name = productlist[5];
            }
            if (productlist.Count > 6)
            {
                labelServer7Title.Text = productlist[6] + ":";
                labelServer7.Name = productlist[6];
            }
            if (productlist.Count > 7)
            {
                labelServer8Title.Text = productlist[7] + ":";
                labelServer8.Name = productlist[7];
            }
            // 
            // groupBox1
            // 
            if (!string.IsNullOrEmpty(labelServer5Title.Text.Split(':')[0]) && labelServer5Title.Text.ToLower() != "sql server 7.0:")
            {
                this.groupBox1.Controls.Add(this.labelServer5Title);
                sql5lbl = labelServer5Title.Text;
                this.groupBox1.Controls.Add(this.labelServer5);
            }

            if (!string.IsNullOrEmpty(labelServer3Title.Text.Split(':')[0]) && labelServer3Title.Text.ToLower() != "sql server 7.0:")
            {
                this.groupBox1.Controls.Add(this.labelServer3Title);
                sql3lbl = labelServer3Title.Text;
                this.groupBox1.Controls.Add(this.labelServer3);
            }
            if (!string.IsNullOrEmpty(labelServer2Title.Text.Split(':')[0]) && labelServer2Title.Text.ToLower() != "sql server 7.0:")
            {
                this.groupBox1.Controls.Add(this.labelServer2);
                sql2lbl = labelServer2Title.Text;
                this.groupBox1.Controls.Add(this.labelServer2Title);
            }
            if (!string.IsNullOrEmpty(labelServer1Title.Text.Split(':')[0]) && labelServer1Title.Text.ToLower() != "sql server 7.0:")
            {
                this.groupBox1.Controls.Add(this.labelServer1);
                sql1lbl = labelServer1Title.Text;
                this.groupBox1.Controls.Add(this.labelServer1Title);
            }
            if (!string.IsNullOrEmpty(labelServer4Title.Text.Split(':')[0]) && labelServer4Title.Text.ToLower() != "sql server 7.0:")
            {
                this.groupBox1.Controls.Add(this.labelServer4Title);
                sql4lbl = labelServer4Title.Text;
                this.groupBox1.Controls.Add(this.labelServer4);
            }
            if (!string.IsNullOrEmpty(labelserver6Title.Text.Split(':')[0]) && labelserver6Title.Text.ToLower() != "sql server 7.0:")
            {
                this.groupBox1.Controls.Add(this.labelserver6Title);
                sql6lbl = labelserver6Title.Text;
                this.groupBox1.Controls.Add(this.labelServer6);
            }

            if (!string.IsNullOrEmpty(labelServer8Title.Text.Split(':')[0]) && labelServer8Title.Text.ToLower() != "sql server 7.0:")
            {
                this.groupBox1.Controls.Add(this.labelServer8Title);
                sql8lbl = labelServer8Title.Text;
                this.groupBox1.Controls.Add(this.labelServer8);
            }
          
            if (!string.IsNullOrEmpty(labelServer7Title.Text.Split(':')[0]) && labelServer8Title.Text.ToLower() != "sql server 7.0:" )
            {
                this.groupBox1.Controls.Add(this.labelServer7Title);
                sql7lbl = labelServer7Title.Text;
                this.groupBox1.Controls.Add(this.labelServer7);
            }
           
          
           
           
            ClearResults();
        }

        private void LoadPatchFiles()
        {
            //----------------
            // SQL Patch File
            //----------------
            try
            {
                ProductConstants.SQLServerVersionFullPath = SQLServerVersion.GetPatchFilePath(out ProductConstants.usingOverrideFile);

                DateTime patchFileDate = SQLServerVersion.LoadSqlPatchFile(ProductConstants.SQLServerVersionFullPath);
            }
            catch
            {
                buttonLoadServerData.Enabled = false;
            }

            if (SQLServerVersion.SqlServerVersionDate == DateTime.MinValue)
            {
                labelPatchVersionValue.Text = "<Unknown>";
            }
            else
            {
                labelPatchVersionValue.Text = SQLServerVersion.SqlServerVersionDate.ToShortDateString();
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

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents(); // let form redraw after main menu closes

                DataSet dataSet = ExportToDataSet.CopyListView(listSQL, "PatchAnalyzer");

                //is there data?
                if (dataSet.Tables["PatchAnalyzer"].Rows.Count == 0)
                {
                    MessageBox.Show("No data to print.\r\n\r\nPlease click 'Load Version Information' to gather data for the report.", "No Data",
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

        private void menuToolsetOptions_Click(object sender, EventArgs e)
        {
            ToolsMenu.ShowToolsetOptions();
        }

        private void menuLaunchpad_Click(object sender, EventArgs e)
        {
            ToolsMenu.RunLaunchpad(this);
        }

        private void menuManageServerGroups_Click(object sender, EventArgs e)
        {
            ToolsMenu.ManageServerGroups();
        }

        #endregion

        #endregion

        #region Program Logic

        private void ClearResults()
        {
            m_PatchList.Clear();
            ResetDashboard();
            listSQL.Items.Clear();
        }

        private void buttonGetResults_Click(object sender, EventArgs e)
        {
            if (ServerSelection.ServerList == null )
            {
               Messaging.ShowError( "The selected Server Group does not exist." );
               return;
            }
            else if (ServerSelection.ServerList.Count == 0)
            {
                string msg;
                if (ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server)
                    msg = "Specify at least one SQL Server.";
                else
                    msg = "The selected Server Group contains no SQL Servers.";

                Messaging.ShowError(msg);

                return;
            }

            // save item to persisted MRU list
            MRU.AddServerOrGroup(ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server,
                                  ServerSelection.Text,
                                  ServerSelection.SqlCredentials);

            CaptureData(true);
        }

        private void CaptureData(bool clearAll)
        {
            try
            {
                _ErrorReports.Clear();
                Cursor = Cursors.WaitCursor;

                // clear existing entries
                ResetDashboard();
                ClearResults();

                List<ServerInformation> _ServerList = ServerSelection.ServerList;

                if (ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server)
                {
                    labelSQLServers.Text = "SQL Servers";
                }
                else
                {
                    labelSQLServers.Text = "SQL Servers in the server group: " + ServerSelection.Text;
                }

                Application.DoEvents();
                
                ProgressBar_Initialize();

                m_JobPool = new JobPool<DataTable>(10);
                m_JobPool.ServerTaskComplete += new EventHandler<JobExecutionResultsEventArgs>(JobPoolTaskComplete);
                m_JobPool.TaskComplete += new EventHandler<JobExecutionEventArgs>(AllTasksComplete);
                m_JobPool.Enqueue(VersionHelper.Harvest, _ServerList, ToolsetOptions.commandTimeout);
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
                
                UpdateDashboard();
                
                //HighlightRows();

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
                Cursor = Cursors.Default;

                if (listSQL.Items.Count > 0)
                {
                    listSQL.Items[0].Selected = true;
                    listSQL.Select();
                }

                menuSelectAll.Enabled =
                    contextMenuSelectAll.Enabled =
                    menuExport.Enabled =
                    contextMenuExport.Enabled =
                    buttonCopyToClipboard.Enabled =
                    printToolStripMenuItem.Enabled = (listSQL.Items.Count > 0); //enable if there's items
            }
        }

        void JobPoolTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            if (e.Status == TaskStatus.Failed)
            {
                _ErrorReports.Add(e.Server.Name, e.ErrorMessage);
            }
            else if (e.Status == TaskStatus.Success)
            {
                listSQL.BeginUpdate();
                AddDataToListView(PatchData.LoadFromDataTable((DataTable)e.Resultset));
                
                listSQL.ListViewItemSorter = new ListViewItemComparer(columnInstance.Index, System.Windows.Forms.SortOrder.Ascending);
                listSQL.Sort();
                listSQL.EndUpdate();
            }
        }

        #endregion

        #region Dashboard

        private static int total = 0;
        public static string Total
        {
            get { return string.Format("{0} Total SQL Server{1}", total, total == 1 ? "" : "s"); }  
        }
        private static int supported = 0;
        public static string Supported
        {
            get { return string.Format("{0} SQL Server{1} at Supported Levels", supported, supported == 1 ? "" : "s"); }
        }
        private static int unsupported = 0;
        public static string Unsupported
        {
            get { return string.Format("{0} SQL Server{1} at Unsupported Levels", unsupported, unsupported == 1 ? "" : "s"); }
        }
        private static int sql2 = 0;
        public static string Sql2
        {
            get { if (!string.IsNullOrEmpty(sql2lbl)) { return sql2.ToString(); } else { return string.Empty; } }
        }
        private static int sql1 = 0;
        public static string SQL1
        {
            get { if (!string.IsNullOrEmpty(sql1lbl)) { return sql1.ToString(); } else { return string.Empty; } }
          
        }
        private static int sql3 = 0;
        public static string Sql3
        {
            get { if (!string.IsNullOrEmpty(sql3lbl)) { return sql3.ToString(); } else { return string.Empty; } }

        }
        private static int sql5 = 0;
        public static string Sql5
        {
            get { if (!string.IsNullOrEmpty(sql5lbl)) { return sql5.ToString(); } else { return string.Empty; } }
        }
        private static int sql4 = 0;
        public static string Sql4
        {
            get { if (!string.IsNullOrEmpty(sql4lbl)) { return sql4.ToString(); } else { return string.Empty; } }
        }
        private static int sql6 = 0;
        public static string Sql6
        {
            get { if (!string.IsNullOrEmpty(sql6lbl)) { return sql6.ToString(); } else { return string.Empty; } }
        }
        private static int sql7 = 0;
        public static string Sql7
        {
            get { if (!string.IsNullOrEmpty(sql7lbl)) { return sql7.ToString(); } else { return string.Empty; } }
        }
        private static int sql8 = 0;
        public static string Sql8
        {
            get { if (!string.IsNullOrEmpty(sql8lbl)) { return sql8.ToString(); } else { return string.Empty; } }
        }
        private static int sql65 = 0;
        public static string Sql65
        {
            get { return sql65.ToString(); }
        }
        private static string sql1lbl = string.Empty;
        public static string sql1labl 
        {
            get { return sql1lbl; }
        }
        private static string sql2lbl = string.Empty;
        public static string sql2labl
        {
            get { return sql2lbl; }
        }
        private static string sql3lbl = string.Empty;
        public static string sql3labl
        {
            get { return sql3lbl; }
        }
        private static string sql4lbl = string.Empty;
        public static string sql4labl
        {
            get { return sql4lbl; }
        }
        private static string sql5lbl = string.Empty;
        public static string sql5labl
        {
            get { return sql5lbl; }
        }
        private static string sql6lbl = string.Empty;
        public static string sql6labl
        {
            get { return sql6lbl; }
        }
        private static string sql7lbl = string.Empty;
        public static string sql7labl
        {
            get { return sql7lbl; }
        }
        private static string sql8lbl = string.Empty;
        public static string sql8labl
        {
            get { return sql8lbl; }
        }
        private void ResetDashboard()
        {
            total = 
                supported =
                unsupported =
                sql1=
                sql2=
                sql3 =
                sql5 = 
                sql4 = 
                sql6 = 
                sql7 = 
                sql8 = 
                sql65 = 0;

            // Dashboard
            labelTotal.Text = "Total SQL Servers";
            labelSupported.Text = "SQL Servers at Supported Levels";
            labelUnsupported.Text = "SQL Servers at Unsupported Levels";
            labelServer1.Text =
            labelServer2.Text =
            labelServer3.Text =
            labelServer5.Text =
            labelServer4.Text =
            labelServer6.Text =
            labelServer7.Text =
            labelServer8.Text = string.Empty;
        }

        private void UpdateDashboard()
        {
            // Dashboard
            labelTotal.Text = Total;
            labelSupported.Text = Supported;
            labelUnsupported.Text = Unsupported;
            foreach(ListViewGroup group in listSQL.Groups)
            {
                foreach (var control in groupBox1.Controls)
                {
                    if (control.GetType() == typeof(DevComponents.DotNetBar.LabelX))
                    {
                        var label = control as DevComponents.DotNetBar.LabelX;
                        if (label.Name.ToLower() == group.Header.ToLower())
                        {
                            switch(listSQL.Groups.IndexOf(group))
                            {
                                case 1:
                                    sql1 = group.Items.Count;
                                    break;
                                case 2:
                                    sql2 = group.Items.Count;
                                    break;
                                case 3:
                                    sql3 = group.Items.Count;
                                    break;
                                case 4:
                                    sql4 = group.Items.Count;
                                    break;
                                case 5:
                                    sql5 = group.Items.Count;
                                    break;
                                case 6:
                                    sql6 = group.Items.Count;
                                    break;
                                case 7:
                                    sql7 = group.Items.Count;
                                    break;
                                case 8:
                                    sql8 = group.Items.Count;
                                    break;
                            }
                            label.Text = group.Items.Count.ToString();
                            break;
                        }
                    }

                }
            }
           // label2014.Text = Sql2014;
           // label2016.Text = Sql2016;
           // label2012.Text = Sql2012;
            //label2008R2.Text = Sql2008R2;
            //label2008.Text = Sql2008;
            //label2005.Text = Sql2005;
           // label2000.Text = Sql2000;
           // label70.Text = Sql70;
        }

        #endregion

        #region List Item Manipulation

        private void AddDataToListView(PatchData patchData)
        {
        

            int matchingVersionIndex;
            // get version and edition for s
            SQLServerVersion ssv = SQLServerVersion.GetMatchingVersion(patchData.version, out matchingVersionIndex);
            if (ssv != null)
            {
                bool indexfound = false;
                // increment counts
                total++;
                if (ssv.Supported.ToUpper() == "YES")
                    supported++;
                else
                    unsupported++;

                int groupIndex = 0;


                if (!indexfound && !string.IsNullOrEmpty(ssv.Product))
                {
                    for (int i = 0; i < listSQL.Groups.Count; i++)
                    {
                        if (listSQL.Groups[i].Header.ToLower() == ssv.Product.ToLower())
                        {
                            groupIndex = i;
                            indexfound = true;
                            break;
                        }
                        else if (ssv.Major == 7 && listSQL.Groups[i].Header.ToLower() == ("SQL Server 7.0").ToLower())
                        {
                            groupIndex = i;
                            indexfound = true;
                            break;
                        }
                        else if (ssv.Major == 6 && listSQL.Groups[i].Header.ToLower() == ("SQL Server 6.5").ToLower())
                        {
                            groupIndex = i;
                            indexfound = true;
                            break;
                        }
                    }

                }
                // add to list            
                ListViewItem lvi = listSQL.Items.Add("");
                lvi.ImageIndex = (ssv.Supported.ToUpper() == "YES") ? 0 : 1;
                lvi.SubItems.Add(patchData.server);
                lvi.SubItems.Add(ssv.Product);
                lvi.SubItems.Add(ssv.Level);
                lvi.SubItems.Add(patchData.edition);
                lvi.SubItems.Add(patchData.GetVersionString());
                lvi.SubItems.Add(SQLServerVersion.GetAvailableUpdateTypeAsString(matchingVersionIndex));
                lvi.SubItems.Add(ssv.Supported);
                lvi.SubItems.Add(ssv.SupportStatus);

                if (ssv.UrlType == "2")
                {
                    lvi.SubItems.Add("Search for KB");  // we are going to search for build number
                }
                else
                    lvi.SubItems.Add((ssv.Url == "" || ssv.Url.ToUpper() == "NONE") ? "No" : "Yes");

                lvi.Tag = matchingVersionIndex;  // store index of match for later use

                lvi.Group = listSQL.Groups[groupIndex];
            }
        }


        #endregion
        
        
        private void HighlightRows()
        {
            bool oddRow = true;

            for (int row = 0; row < listSQL.Items.Count; row++)
            {
                ListViewItem _Item = listSQL.Items[row];

                // Figure out background color for Row
                Color backColor = Color.White;
                if (! oddRow) backColor = Color.WhiteSmoke;

                // Draw Row
                for (int i = 0; i < _Item.SubItems.Count; i++)
                {
                    _Item.SubItems[i].BackColor = backColor;
                }

                oddRow = !oddRow;
            }
        }
        

        private void menuShowGroups_Click(object sender, EventArgs e)
        {
            ToggleShowGroups();
        }

        private void contextMenuShowGroups_Click(object sender, EventArgs e)
        {
            ToggleShowGroups();
        }

        private void ToggleShowGroups()
        {
            menuShowGroups.Checked = !menuShowGroups.Checked;
            contextMenuShowGroups.Checked = menuShowGroups.Checked;
            listSQL.ShowGroups = menuShowGroups.Checked;
        }

        #region Clipboard / Save Results As

        private void buttonCopyToClipboard_Click(object sender, EventArgs e)
        {
            CopyToClipboard(false);
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard(true);
        }

        private void contextMenuCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard(true);
        }

        private void CopyToClipboard(bool selectedOnly)
        {
            ExportToClipboard.CopyListViewToTabbedFormat(listSQL, true, selectedOnly);
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
            foreach (ListViewItem lvi in listSQL.Items)
            {
                lvi.Selected = true;
            }
        }

        private void menuExportAsCSV_Click(object sender, EventArgs e)
        {
            ExportToCSV.CopyListView(listSQL);
        }

        private void contextMenuExportAsCSV_Click(object sender, EventArgs e)
        {
            ExportToCSV.CopyListView(listSQL);
        }

        private void menuExportAsXML_Click(object sender, EventArgs e)
        {
            ExportToXML.CopyListView(listSQL, "Version", false);
        }
        private void contextMenuExportAsXML_Click(object sender, EventArgs e)
        {
            ExportToXML.CopyListView(listSQL, "Version Report", false);
        }

        private void menuExportAsDataTable_Click(object sender, EventArgs e)
        {
            ExportToTable.Export(this.CreateTable, this.PopulateTable);
        }

        private void contextMenuExportAsDatatable_Click(object sender, EventArgs e)
        {
            ExportToTable.Export(this.CreateTable, this.PopulateTable);
        }

        #endregion

        private void linkDisplayVersionList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_VersionList frm = new Form_VersionList();
            frm.ShowDialog();
        }

        private void linkCheckVersionList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (SQLServerVersion.CheckForNewFile())
            {
                LoadPatchFiles();
                this.listSQL.Groups.Clear();
                var listViewGroup1 = new ListViewGroup();
                listViewGroup1.Header = "Unknown SQL Server Version";
                listViewGroup1.Name = "groupUnknown";
                this.listSQL.Groups.Add(listViewGroup1);

                var listViewGroup9 = new ListViewGroup();
                listViewGroup9.Header = "SQL Server 7.0";
                listViewGroup9.Name = "group70";
                var listViewGroup10 = new ListViewGroup();
                listViewGroup10.Header = "SQL Server 6.5";
                listViewGroup10.Name = "group65";


                foreach (string sqlServerVersion in SQLServerVersion.SqlServerVersionList.OrderByDescending(x => x.Major).Select(x => x.Product).Distinct())
                {
                    if (!string.IsNullOrEmpty(sqlServerVersion))
                    {
                        var grp = new System.Windows.Forms.ListViewGroup(sqlServerVersion, HorizontalAlignment.Left);
                        this.listSQL.Groups.Add(grp);
                    }
                }
                this.listSQL.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup9,
            listViewGroup10
            });

                labelServer1Title.Text =
                labelServer2Title.Text =
                labelServer3Title.Text =
                labelServer4Title.Text =
                labelServer5Title.Text =
                labelserver6Title.Text =
                labelServer7Title.Text =
                labelServer8Title.Text =
                labelServer1.Name =
                labelServer2.Name =
                labelServer3.Name =
                labelServer4.Name =
                labelServer5.Name =
                labelServer6.Name =
                labelServer7.Name =
                labelServer8.Name =
                sql1lbl =
                sql2lbl =
                sql3lbl =
                sql4lbl =
                sql5lbl =
                sql6lbl =
                sql7lbl =
                sql8lbl = string.Empty;
                this.groupBox1.Controls.Clear();
                m_PatchList = new List<PatchData>();

                var productlist = SQLServerVersion.SqlServerVersionList.OrderByDescending(x => x.Major).Select(x => x.Product).Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();
                if (productlist.Count > 0)
                {
                    labelServer1Title.Text = productlist[0] + ":";
                    labelServer1.Name = productlist[0];
                }
                if (productlist.Count > 1)
                {
                    labelServer2Title.Text = productlist[1] + ":";
                    labelServer2.Name = productlist[1];
                }
                if (productlist.Count > 2)
                {
                    labelServer3Title.Text = productlist[2] + ":";
                    labelServer3.Name = productlist[2];
                }
                if (productlist.Count > 3)
                {
                    labelServer4Title.Text = productlist[3] + ":";
                    labelServer4.Name = productlist[3];
                }
                if (productlist.Count > 4)
                {
                    labelServer5Title.Text = productlist[4] + ":";
                    labelServer5.Name = productlist[4];
                }
                if (productlist.Count > 5)
                {
                    labelserver6Title.Text = productlist[5] + ":";
                    labelServer6.Name = productlist[5];
                }
                if (productlist.Count > 6)
                {
                    labelServer7Title.Text = productlist[6] + ":";
                    labelServer7.Name = productlist[6];
                }
                if (productlist.Count > 7)
                {
                    labelServer8Title.Text = productlist[7] + ":";
                    labelServer8.Name = productlist[7];
                }
                // 
                // groupBox1
                // 
                if (!string.IsNullOrEmpty(labelServer5Title.Text.Split(':')[0]) && labelServer5Title.Text.ToLower() != "sql server 7.0:")
                {
                    this.groupBox1.Controls.Add(this.labelServer5Title);
                    sql5lbl = labelServer5Title.Text;
                    this.groupBox1.Controls.Add(this.labelServer5);
                }

                if (!string.IsNullOrEmpty(labelServer3Title.Text.Split(':')[0]) && labelServer3Title.Text.ToLower() != "sql server 7.0:")
                {
                    this.groupBox1.Controls.Add(this.labelServer3Title);
                    sql3lbl = labelServer3Title.Text;
                    this.groupBox1.Controls.Add(this.labelServer3);
                }
                if (!string.IsNullOrEmpty(labelServer2Title.Text.Split(':')[0]) && labelServer2Title.Text.ToLower() != "sql server 7.0:")
                {
                    this.groupBox1.Controls.Add(this.labelServer2);
                    sql2lbl = labelServer2Title.Text;
                    this.groupBox1.Controls.Add(this.labelServer2Title);
                }
                if (!string.IsNullOrEmpty(labelServer1Title.Text.Split(':')[0]) && labelServer1Title.Text.ToLower() != "sql server 7.0:")
                {
                    this.groupBox1.Controls.Add(this.labelServer1);
                    sql1lbl = labelServer1Title.Text;
                    this.groupBox1.Controls.Add(this.labelServer1Title);
                }
                if (!string.IsNullOrEmpty(labelServer4Title.Text.Split(':')[0]) && labelServer4Title.Text.ToLower() != "sql server 7.0:")
                {
                    this.groupBox1.Controls.Add(this.labelServer4Title);
                    sql4lbl = labelServer4Title.Text;
                    this.groupBox1.Controls.Add(this.labelServer4);
                }
                if (!string.IsNullOrEmpty(labelserver6Title.Text.Split(':')[0]) && labelserver6Title.Text.ToLower() != "sql server 7.0:")
                {
                    this.groupBox1.Controls.Add(this.labelserver6Title);
                    sql6lbl = labelserver6Title.Text;
                    this.groupBox1.Controls.Add(this.labelServer6);
                }

                if (!string.IsNullOrEmpty(labelServer8Title.Text.Split(':')[0]) && labelServer8Title.Text.ToLower() != "sql server 7.0:")
                {
                    this.groupBox1.Controls.Add(this.labelServer8Title);
                    sql8lbl = labelServer8Title.Text;
                    this.groupBox1.Controls.Add(this.labelServer8);
                }

                if (!string.IsNullOrEmpty(labelServer7Title.Text.Split(':')[0]) && labelServer8Title.Text.ToLower() != "sql server 7.0:")
                {
                    this.groupBox1.Controls.Add(this.labelServer7Title);
                    sql7lbl = labelServer7Title.Text;
                    this.groupBox1.Controls.Add(this.labelServer7);
                }
                ClearResults();
            }
            Cursor = Cursors.Default;
        }

        private void listSQL_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enabled = false;
            bool updatesAvailable = false;

            if (listSQL.SelectedItems.Count != 0)
            {
                int matchingIndex = (int)(listSQL.SelectedItems[0].Tag);
                if ( matchingIndex >= 0 && matchingIndex < SQLServerVersion.SqlServerVersionList.Count  )
                {
                   SQLServerVersion ssv = SQLServerVersion.GetSqlVersion(matchingIndex);

                   string url = ssv.Url;
                   if (url != "" && url.ToUpper() != "NONE")
                       enabled = true;

                   menuCopy.Enabled = true;
                   contextMenuCopy.Enabled = true;

                   updatesAvailable = listSQL.SelectedItems[0].SubItems[6].Text != "None";
                }
                else
                {
                   CoreGlobals.traceLog.VerboseFormat( "Matching Index: {0}   Build: {1}" , matchingIndex, listSQL.SelectedItems[0].SubItems[5] );
                }
            }
            else
            {
                menuCopy.Enabled = false;
                contextMenuCopy.Enabled = false;
            }
            buttonViewKbArticle.Enabled = enabled;
            contextMenuViewKBArticle.Enabled = enabled;

            buttonViewAvailableHotfixes.Enabled = updatesAvailable;
            contextMenuViewAvailableHotfixes.Enabled = updatesAvailable;
        }

        #region View Available Hotfixes

        private void contextMenuViewAvailableHotfixes_Click(object sender, EventArgs e)
        {
            ShowAvailableUpdates();
        }

        private void buttonViewAvailableHotfixes_Click(object sender, EventArgs e)
        {
            ShowAvailableUpdates();
        }

        private void ShowAvailableUpdates()
        {
            if (listSQL.SelectedItems.Count == 0) return;
            int matchingIndex = (int)(listSQL.SelectedItems[0].Tag);
            
            if ( matchingIndex >= 0 && matchingIndex < SQLServerVersion.SqlServerVersionList.Count  )
            {
               string build = listSQL.SelectedItems[0].SubItems[2].Text + " " + // version
                              listSQL.SelectedItems[0].SubItems[3].Text + " " + // sp level
                              "(" +
                              listSQL.SelectedItems[0].SubItems[5].Text + // build
                              ")";

               Form_AvailableUpdates frm = new Form_AvailableUpdates(listSQL.SelectedItems[0].SubItems[1].Text,
                                                                      build,
                                                                      matchingIndex);
               frm.ShowDialog();
            }
        }

        #endregion

        #region View Knowledge Base Article

        private void buttonViewKbArticle_Click(object sender, EventArgs e)
        {
           ViewKbArticle();
        }
        
        private void contextMenuViewKBArticle_Click(object sender, EventArgs e)
        {
           ViewKbArticle();
        }
        
        private void listSQL_DoubleClick( object sender, EventArgs e )
        {
          if ( buttonViewKbArticle.Enabled )
          {
             ViewKbArticle();
          }
        }
        
        private void ViewKbArticle()
        {
            if (listSQL.SelectedItems.Count == 0) return;

            int matchingIndex = (int)(listSQL.SelectedItems[0].Tag);
            if ( matchingIndex >= 0 && matchingIndex < SQLServerVersion.SqlServerVersionList.Count  )
            {
               SQLServerVersion ssv = SQLServerVersion.GetSqlVersion(matchingIndex);
               ViewKnowledgeBaseArticle(ssv.Url);
            }
        }

        static public void ViewKnowledgeBaseArticle(string url)
        {
            if (url == null || url.ToUpper() == "NONE" || url == "")
            {
                Messaging.ShowInformation("No Knowledge Base article exists for this build of SQL Server");
                return;
            }
            else if (url.ToUpper().StartsWith("GOOGLE:"))
            {
                url = String.Format(@"http://www.google.com/search?q=+{0}+site%3Asupport.microsoft.com&lr=lang_en",
                                     url.Substring(7));
            }
            else if (url.ToUpper().StartsWith("SEARCH:"))
            {
                url = String.Format(@"http://support.microsoft.com/search/default.aspx?mode=a&query={0}",
                                     url.Substring(7));
            }

            Form_MiniBrowser frm = new Form_MiniBrowser(url);
            frm.ShowDialog();
        }

        #endregion

        #region Column Sorting

        private int sortColumn = -1;
        private System.Windows.Forms.SortOrder sortOrder = System.Windows.Forms.SortOrder.Ascending;

        private void ResetSort()
        {
            sortColumn = -1;
            listSQL.Sorting = sortOrder;
        }

        private void listSQL_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;

                // Set the sort order to ascending by default.
                listSQL.Sorting = sortOrder;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listSQL.Sorting == System.Windows.Forms.SortOrder.Ascending)
                    listSQL.Sorting = System.Windows.Forms.SortOrder.Descending;
                else
                    listSQL.Sorting = System.Windows.Forms.SortOrder.Ascending;
            }

            listSQL.ListViewItemSorter = new ListViewItemComparer(e.Column, listSQL.Sorting);
            listSQL.Sort();
        }

        // Implements the manual sorting of items by column.
        class ListViewItemComparer : IComparer
        {
            private int col;
            private System.Windows.Forms.SortOrder order;

            public ListViewItemComparer()
            {
                col = 0;
                order = System.Windows.Forms.SortOrder.Ascending;
            }

            public ListViewItemComparer(int column, System.Windows.Forms.SortOrder order)
            {
                col = column;
                this.order = order;
            }

            public int Compare(object x, object y)
            {
                int returnVal = -1;
                ListViewItem lv1 = (ListViewItem)x;
                ListViewItem lv2 = (ListViewItem)y;

                if (col == 0 /* Icon */ )
                {
                    returnVal = 0;
                    if (lv1.ImageIndex < lv2.ImageIndex) returnVal = -1;
                    if (lv1.ImageIndex > lv2.ImageIndex) returnVal = 1;
                }
                else if (col == 5 /* build */ )
                {
                    returnVal = Helpers.CompareVersionString(lv1.SubItems[col].Text,
                                                              lv2.SubItems[col].Text);
                }
                else /* the rest of the columns are simple strings */
                {
                   if ( lv1.SubItems.Count <= col && lv2.SubItems.Count <= col ) return 0;
                   if ( lv1.SubItems.Count <= col  ) return 1;
                   if ( lv2.SubItems.Count <= col  ) return -1;
                   
                   returnVal = String.Compare(lv1.SubItems[col].Text,
                                              lv2.SubItems[col].Text);
                }

                if (order == System.Windows.Forms.SortOrder.Descending) returnVal *= -1;

                return returnVal;
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
            _ProgressDialog.OperationText = "Loading Version Information...";
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

        private void buttonObtainingUpgrades_Click(object sender, EventArgs e)
        {
            Form_DownloadUpgrades frm = new Form_DownloadUpgrades();
            frm.ShowDialog();
        }

       private void ServerSelection_TextChanged( object sender, EventArgs e )
       {
          buttonLoadServerData.Enabled = ServerSelection.HaveSelection;
       }

       private void ShowF1Help(object sender, HelpEventArgs hlpevent)
       {
          HelpMenu.ShowHelp();
       }

        #region Export Support

        public void
           CreateTable(
              SqlConnection conn,
              string tableName //include owner name

           )
        {

            string sql = "CREATE TABLE {0}( " +
                          "  [ServerName] [nvarchar](256)   NULL, " +
                          "  [Release] [nvarchar](256)   NULL, " +
                          "  [Level] [nvarchar](50)   NULL, " +
                          "  [Edition] [nvarchar] (256)   NULL, " +
                          "  [Build] [nvarchar](30)   NULL, " +
                          "  [UpdatesAvailable]  [nvarchar] (30)  NULL," +
                          "  [IsSupported] [nvarchar] (12) NULL, " +
                          "  [SupportStatus] [nvarchar] (256) NULL, " +
                          "  [IsKBAvailable] [nvarchar] (12) NULL " +
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
            foreach (ListViewItem _Item in listSQL.Items)
            {
                props.Length = 0;
                values.Length = 0;

                PopulateTable_AddProperty("ServerName", SQLHelpers.CreateSafeString(_Item.SubItems[columnInstance.Index].Text));
                PopulateTable_AddProperty("Release", SQLHelpers.CreateSafeString(_Item.SubItems[columnRelease.Index].Text));
                PopulateTable_AddProperty("Level", SQLHelpers.CreateSafeString(_Item.SubItems[columnLevel.Index].Text));
                PopulateTable_AddProperty("Edition", SQLHelpers.CreateSafeString(_Item.SubItems[columnEdition.Index].Text));
                PopulateTable_AddProperty("Build", SQLHelpers.CreateSafeString(_Item.SubItems[columnBuild.Index].Text));
                PopulateTable_AddProperty("UpdatesAvailable", SQLHelpers.CreateSafeString(_Item.SubItems[columnHotfixAvailable.Index].Text));
                PopulateTable_AddProperty("IsSupported", SQLHelpers.CreateSafeString(_Item.SubItems[columnSupported.Index].Text));
                PopulateTable_AddProperty("SupportStatus", SQLHelpers.CreateSafeString(_Item.SubItems[columnStatus.Index].Text));
                PopulateTable_AddProperty("IsKBAvailable", SQLHelpers.CreateSafeString(_Item.SubItems[columnKb.Index].Text));

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