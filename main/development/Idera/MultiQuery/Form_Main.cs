using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Idera.SqlAdminToolset.Core;
using DevComponents.DotNetBar;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.MultiQuery
{
    public partial class Form_Main : Form
    {
        #region Properties

        private JobPool<MultiQueryResult> m_JobPool = null;
        private Dictionary<string, string> m_ErrorReports = new Dictionary<string, string>();
        private ToolProgressBarDialog m_ProgressDialog = null;
        private List<MultiQueryResult> m_queryResults = null;

        private DataSet m_combinedResultSet = null;

        private GenericMru m_recentFiles = new GenericMru(10);

        #endregion

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

            ProductConstants.ReadOptions();

            navQueryTargets.NavigationBar.Visible = false;
            navQuery.NavigationBar.Visible = false;
            navQueryResults.NavigationBar.Visible = false;

            ProductConstants.mainform = this;

            if (ProductConstants.lastQueryTargetFile != "")
            {
                try
                {
                    ReadQueryTarget(ProductConstants.lastQueryTargetFile);
                }
                catch
                {
                    // failed to read last one - just go back to default
                    listQueryTargets.Items.Clear();
                    ProductConstants.lastQueryTargetFile = "";
                    ProductConstants.WriteOptions();
                    SetQueryTargetFile(false, "<Untitled>");
                }
            }
            else
            {
                // use default query target file

                try
                {
                    ReadQueryTarget("");
                }
                catch
                {
                    // failure reading default target file - just start up empty
                    listQueryTargets.Items.Clear();
                }
                SetQueryTargetFile(false, "<Untitled>");
            }

            groupTargetHelp.Visible = (listQueryTargets.Items.Count == 0);

            // Query Editor Options
            m_recentFiles.Read(ProductConstants.RegistryValue_RecentFiles);

            for (int i = 0; i < m_recentFiles.Count; i++)
            {
                m_recentFiles.Items[i] = Path.GetFileName(m_recentFiles.Tags[i].ToString());
            }

            LoadRecentFileList();

            if (ProductConstants.optionsShowSyntaxErrors)
                this.mssqlParser1.Options = QWhale.Syntax.SyntaxOptions.SyntaxErrors;
            else
                this.mssqlParser1.Options = QWhale.Syntax.SyntaxOptions.None;

            textSQL.DisableSyntaxPaint = !ProductConstants.optionsShowSyntaxColor;
            textSQL.WordWrap = ProductConstants.optionsShowWordWrap;

            this.textSQL.Gutter.Options = (QWhale.Editor.GutterOptions)(QWhale.Editor.GutterOptions.PaintBookMarks);
            if (ProductConstants.optionsShowLineNumbers)
                this.textSQL.Gutter.Options |= (QWhale.Editor.GutterOptions)(QWhale.Editor.GutterOptions.PaintLineNumbers);
            if (ProductConstants.optionsShowModifiedLines)
                this.textSQL.Gutter.Options |= (QWhale.Editor.GutterOptions)(QWhale.Editor.GutterOptions.PaintLineModificators);

        }

        #region Common Code

        #region File Menu Event Handlers (Common)

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!CheckForDirtyQueryTarget()) { e.Cancel = true; return; }
            if (!CheckForDirtyQuery()) { e.Cancel = true; return; }

            base.OnClosing(e);
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            if (!CheckForDirtyQueryTarget()) return;
            ProductConstants.QueryTargetDirty = false;

            if (!CheckForDirtyQuery()) return;
            ProductConstants.QueryDirty = false;

            Close();
        }

        private void menuExitToLaunchpad_Click(object sender, EventArgs e)
        {
            if (!CheckForDirtyQueryTarget()) return;
            ProductConstants.QueryTargetDirty = false;

            if (!CheckForDirtyQuery()) return;
            ProductConstants.QueryDirty = false;

            Launchpad.RunAndClose(this);
        }

        #endregion

        #region Help Menu Event Handlers (Common)

        private void menuShowHelp_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowHelp(ProductConstants.productHelpTopic);
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

        #region Query Target Handling

        public int
           FindQueryTarget(
              QueryTarget queryTarget

           )
        {
            for (int i = 0; i < listQueryTargets.Items.Count; i++)
            {
                if (queryTarget.Match((QueryTarget)listQueryTargets.Items[i].Tag)) return i;
            }
            return -1;
        }

        private void buttonAddTarget_Click(object sender, EventArgs e)
        {
            AddQueryTarget();
        }

        private void linkLabelAddTarget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddQueryTarget();
        }

        private void contextTargetAdd_Click(object sender, EventArgs e)
        {
            AddQueryTarget();
        }

        private void AddQueryTarget()
        {
            Form_QueryTarget frm = new Form_QueryTarget();
            DialogResult choice = frm.ShowDialog();
            if (choice == DialogResult.OK)
            {
                foreach (QueryTarget queryTarget in frm.queryTargetList)
                {
                    // add to list
                    ListViewItem lvi = new ListViewItem("");
                    lvi.SubItems.Add(queryTarget.server);
                    lvi.SubItems.Add(String.IsNullOrEmpty(queryTarget.database) ? "<default>" : queryTarget.database);
                    if (queryTarget.isServerGroup)
                        lvi.ImageIndex = 2;
                    else
                        lvi.ImageIndex = (queryTarget.credentials != null) &&
                                           (queryTarget.credentials.useSqlAuthentication)
                                           ? 1 : 0;

                    lvi.Tag = queryTarget;
                    ListViewItem lv = listQueryTargets.Items.Add(lvi);

                    listQueryTargets.SelectedItems.Clear();
                    lv.Selected = true;
                }

                MarkQueryTargetDirty(true);
                SetExecuteButtonsEnabled();

                groupTargetHelp.Visible = false;
            }
        }


        private void contextTargetEdit_Click(object sender, EventArgs e)
        {
            EditQueryTarget();
        }

        private void buttonEditTarget_Click(object sender, EventArgs e)
        {
            EditQueryTarget();
        }

        private void EditQueryTarget()
        {
            if (listQueryTargets.SelectedItems.Count == 0)
            {
                buttonEditTarget.Enabled = false;
                return;
            }

            Form_QueryTarget frm = new Form_QueryTarget((QueryTarget)listQueryTargets.SelectedItems[0].Tag);
            DialogResult choice = frm.ShowDialog();
            if (choice == DialogResult.OK)
            {
                foreach (QueryTarget queryTarget in frm.queryTargetList)
                {
                    ListViewItem lvi = listQueryTargets.SelectedItems[0];

                    // subitem 0 is icon
                    lvi.SubItems[1].Text = queryTarget.server;
                    lvi.SubItems[2].Text = String.IsNullOrEmpty(queryTarget.database) ? "<default>" : queryTarget.database;

                    if (queryTarget.isServerGroup)
                        lvi.ImageIndex = 2;
                    else
                        lvi.ImageIndex = (queryTarget.credentials != null) &&
                                           (queryTarget.credentials.useSqlAuthentication)
                                           ? 1 : 0;

                    lvi.Tag = queryTarget;
                }

                MarkQueryTargetDirty(true);


                groupTargetHelp.Visible = false;
            }
        }

        private void buttonRemoveTarget_Click(object sender, EventArgs e)
        {
            RemoveQueryTarget();
        }

        private void contextTargetRemove_Click(object sender, EventArgs e)
        {
            RemoveQueryTarget();
        }

        private void RemoveQueryTarget()
        {
            DialogResult choice = Messaging.ShowConfirmation("Are you sure you want to remove the selected query targets?");
            if (choice == DialogResult.Yes)
            {
                try
                {
                    int firstNdx = listQueryTargets.SelectedIndices[0];

                    listQueryTargets.BeginUpdate();
                    while (listQueryTargets.SelectedItems.Count != 0)
                    {
                        listQueryTargets.Items.RemoveAt(listQueryTargets.SelectedIndices[0]);
                    }

                    if (firstNdx < listQueryTargets.Items.Count)
                    {
                        listQueryTargets.Items[firstNdx].Selected = true;
                    }
                    else if (listQueryTargets.Items.Count != 0)
                    {
                        listQueryTargets.Items[listQueryTargets.Items.Count - 1].Selected = true;
                    }

                    MarkQueryTargetDirty(true);
                    SetExecuteButtonsEnabled();
                }
                catch (Exception ex)
                {
                    CoreGlobals.traceLog.Debug(ex.Message);
                }
                finally
                {
                    listQueryTargets.EndUpdate();
                }
            }
        }

        private void listQueryTargets_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonEditTarget.Enabled = (listQueryTargets.SelectedItems.Count == 1);
            buttonRemoveTarget.Enabled = (listQueryTargets.SelectedItems.Count != 0);
        }

        #endregion // Query Target Handling

        #region Execution Handling

        private void contextQueryExecute_Click(object sender, EventArgs e)
        {
            if (listQueryTargets.Items.Count != 0)
            {
                StartQuery(false);
            }
        }

        private void contextQueryExecuteSelected_Click(object sender, EventArgs e)
        {
            SelectAndStartQuery();
        }

        private void contextTargetExecuteAgainstSelectedQueryTargets_Click(object sender, EventArgs e)
        {
           
            if (listQueryTargets.SelectedItems.Count != 0)
            {
                List<QueryTarget> qtList = new List<QueryTarget>();
                qtList.Add((QueryTarget)listQueryTargets.SelectedItems[0].Tag);
                StartQuery(qtList);
            }
        }

        private void SelectAndStartQuery()
        {
            Form_SelectQueryTargets frm = new Form_SelectQueryTargets(listQueryTargets);
            DialogResult choice = frm.ShowDialog();
            if (choice == DialogResult.OK)
            {
                StartQuery(frm.selectedQueryTargets);
            }
        }

        //-----------------------------------------------------------------------
        // Execute Methods
        //-----------------------------------------------------------------------
        private void buttonExecuteQuery_Click(object sender, EventArgs e)
        {
            if (listQueryTargets.Items.Count != 0)
            {
                listExecuteQueryResults.Items.Clear();
                navigationPanePanel4.Visible = listExecuteQueryResults.Visible = true;
                StartQuery(false);
            }
        }

        private void contextExecute_Click(object sender, EventArgs e)
        {
            if (listQueryTargets.Items.Count != 0)
            {
                StartQuery(false);
            }
        }

        //-----------------------------------------------------------------------
        // Execute Selected Methods
        //-----------------------------------------------------------------------
        private void contextExecuteSelected_Click(object sender, EventArgs e)
        {
            
            SelectAndStartQuery();
        }

        private void buttonExecuteSelected_Click(object sender, EventArgs e)
        {
            SelectAndStartQuery();
        }

        //-----------------------------------------------------------------------
        // StartQuery
        //-----------------------------------------------------------------------
        private void
           StartQuery(
              List<QueryTarget> queryTargetList
           )
        {
            listExecuteQueryResults.Items.Clear();
            navigationPanePanel4.Visible = listExecuteQueryResults.Visible = true;
            int count = 0;

            // save query target if its dirty and its the default - for user loaded files they have to save explcitly
            if (!ProductConstants.QueryTargetIsFile && ProductConstants.QueryTargetDirty)
            {
                InternalSaveQueryTargetFile("");
            }

            RemoveSummaryTabs();
            ResetQuery();

            // Parse SQL into batches (prepare query based on what is selected)
            if (textSQL.Selection.SelectedText != "")
            {
                // something selected - only run the selected text
                ProductConstants.QueryText = textSQL.Selection.SelectedText;
            }
            else
            {
                // nothing selected - run it all
                ProductConstants.QueryText = textSQL.Text;
            }
            ProductConstants.QueryBatches = QueryHelper.SqlParser(ProductConstants.QueryText, ProductConstants.optionsBatchSeparator);

            tabControlResults.SuspendLayout();
            AddSummaryTabs();

            //listExecuteQueryResults.Items.Add("Combined Results");
            //listExecuteQueryResults.Items.Add("Summary");
            if (ProductConstants.optionsShowCombinedResults)
            {
                listExecuteQueryResults.Items.Insert(0, "Combined Results");
            }
            else
            {
                try
                {
                    listExecuteQueryResults.Items.RemoveAt(0); // Combined Results tab remove
                }
                catch (Exception ex)
                {

                }
            }
            if (ProductConstants.optionsShowSummary)
            {
                try
                {
                    listExecuteQueryResults.Items.Insert(1, "Summary");
                }
                catch (Exception ex)
                {
                    listExecuteQueryResults.Items.Insert(0, "Summary");
                }
            }
            else
            {
                try
                {
                    listExecuteQueryResults.Items.RemoveAt(1); // Summary tab remove
                }
                catch (Exception ex)
                {

                }
            }
            // pre-fill arrays for execution
            foreach (QueryTarget qt in queryTargetList)
            {
                List<ServerInformation> serverList = GetServerList(qt);

                foreach (ServerInformation si in serverList)
                {
                    MultiQueryOptions mqo = new MultiQueryOptions(qt.database, count++);
                    si.Tag = mqo;

                    if (ProductConstants.optionsShowIndividualResults)
                    {
                        AddServerTab(si.Name, qt.database);
                        int stringlen = (si.Name + "." + qt.database).Length;
                        if (stringlen > 34)
                        {
                            listExecuteQueryResults.Items.Add((si.Name + "." + qt.database).Substring(0, 34) + ".....");
                        }
                        else
                        {
                            listExecuteQueryResults.Items.Add(si.Name + "." + qt.database);
                        }
                    }

                    if (ProductConstants.optionsShowSummary)
                    {
                        SummaryGrid_Initialize(si.Name, qt.database);
                    }
                }

                // add list to server group
                m_JobPool.Enqueue(QueryHelper.ExecuteQuery,
                                   serverList,
                                   0);
            }
            listExecuteQueryResults.DrawMode = DrawMode.OwnerDrawFixed;
            this.listExecuteQueryResults.DrawItem += new DrawItemEventHandler(listExecuteQueryResults_DrawItem);
            tabControlResults.ResumeLayout(true);
            ProgressBar_Initialize("Executing Query...");

            // prepare query results array
            InitializeResultsArray(count);

            // start job pool
            m_JobPool.StartAsync();
            ProgressBar_Show();
        }

        //-----------------------------------------------------------------------
        // StartQuery
        //-----------------------------------------------------------------------
        private void
           StartQuery(
              bool executeSelectedOnly
           )
        {
            int count = 0;

            // save query target if its dirty and its the default - for user loaded files they have to save explcitly
            if (!ProductConstants.QueryTargetIsFile && ProductConstants.QueryTargetDirty)
            {
                InternalSaveQueryTargetFile("");
            }

            RemoveSummaryTabs();
            ResetQuery();

            // Parse SQL into batches (prepare query based on what is selected)
            if (textSQL.Selection.SelectedText != "")
            {
                // something selected - only run the selected text
                ProductConstants.QueryText = textSQL.Selection.SelectedText;
            }
            else
            {
                // nothing selected - run it all
                ProductConstants.QueryText = textSQL.Text;
            }
            ProductConstants.QueryBatches = QueryHelper.SqlParser(ProductConstants.QueryText, ProductConstants.optionsBatchSeparator);

            tabControlResults.SuspendLayout();
            AddSummaryTabs();


            //listExecuteQueryResults.Items.Add("Combined Results");
            //listExecuteQueryResults.Items.Add("Summary");
            if (ProductConstants.optionsShowCombinedResults)
            {
                listExecuteQueryResults.Items.Insert(0, "Combined Results");
            }
            else
            {
                try
                {
                    listExecuteQueryResults.Items.RemoveAt(0); // Combined Results tab remove
                }
                catch (Exception ex)
                {

                }
            }
            if (ProductConstants.optionsShowSummary)
            {
                try
                {
                    listExecuteQueryResults.Items.Insert(1, "Summary");
                }
                catch (Exception ex)
                {
                    listExecuteQueryResults.Items.Insert(0, "Summary");
                }
            }
            else
            {
                try
                {
                    listExecuteQueryResults.Items.RemoveAt(1); // Summary tab remove
                }
                catch (Exception ex)
                {

                }
            }
            // pre-fill arrays for execution
            foreach (ListViewItem lvi in listQueryTargets.Items)
            {
                if (!executeSelectedOnly || lvi.Selected)
                {
                    QueryTarget qt = (QueryTarget)lvi.Tag;

                    List<ServerInformation> serverList = GetServerList(qt);

                    foreach (ServerInformation si in serverList)
                    {
                        MultiQueryOptions mqo = new MultiQueryOptions(qt.database, count++);
                        si.Tag = mqo;

                        if (ProductConstants.optionsShowIndividualResults)
                        {
                            AddServerTab(si.Name, qt.database);
                            int stringlen = (si.Name + "." + qt.database).Length;
                            if (stringlen > 34)
                            {
                                listExecuteQueryResults.Items.Add((si.Name + "." + qt.database).Substring(0, 34) + ".....");
                            }
                            else
                            {
                                if (qt.database == "")
                                {
                                    listExecuteQueryResults.Items.Add(si.Name);
                                }
                                else
                                {
                                    listExecuteQueryResults.Items.Add(si.Name + "." + qt.database);
                                }
                            }
                        }

                        if (ProductConstants.optionsShowSummary)
                        {
                            SummaryGrid_Initialize(si.Name, qt.database);
                        }
                    }

                    // add list to server group
                    m_JobPool.Enqueue(QueryHelper.ExecuteQuery,
                                       serverList,
                                       0);
                }
            }
            listExecuteQueryResults.SelectedIndex = 0;
            listExecuteQueryResults.DrawMode = DrawMode.OwnerDrawFixed;
            this.listExecuteQueryResults.DrawItem += new DrawItemEventHandler(listExecuteQueryResults_DrawItem);
            tabControlResults.ResumeLayout(true);
            ProgressBar_Initialize("Executing Query...");
            InitializeResultsArray(count);

            // start job pool
            m_JobPool.StartAsync();

            ProgressBar_Show();
        }

        private void listExecuteQueryResults_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {

            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          new Font(e.Font, (e.State & DrawItemState.Selected) == DrawItemState.Selected ? FontStyle.Bold : FontStyle.Regular),
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                         System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(174)))), ((int)(((byte)(77))))));//Choose the color

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Define the default color of the brush as black.

            Brush myBrushblack = Brushes.Black;

            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(74)))), ((int)(((byte)(147))))));

            Graphics g = e.Graphics;
            Color borderColor = Color.SteelBlue;
            g.DrawRectangle(new Pen(borderColor), e.Bounds);
            
            // Draw the current item text based on the current Font 
            // and the custom brush settings.
            e.Graphics.DrawString(listExecuteQueryResults.Items[e.Index].ToString(),
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.

            e.DrawFocusRectangle();
        }

        System.Windows.Forms.ToolTip _toolTip = new System.Windows.Forms.ToolTip
        {
            AutoPopDelay = 5000,
            InitialDelay = 1000,
            ReshowDelay = 500,
            ShowAlways = true,
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))))
        };
        private void listExecuteQueryResults_OnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            var listbox = sender as ListBox;
            if (listbox == null) return;

            // set tool tip for listbox
            var strTip = string.Empty;
            var index = listbox.IndexFromPoint(mouseEventArgs.Location);

            if ((index >= 0) && (index < listbox.Items.Count))
                strTip = listbox.Items[index].ToString();
            if (_toolTip.GetToolTip(listbox) != strTip)
            {
                //if (index == 0 || index == 1)
                //{
                //    _toolTip.SetToolTip(listbox, Convert.ToString(strTip));
                //}
                //if (listQueryTargets.Items[index].SubItems[2].Text == "<default>")
                //{
                //    _toolTip.SetToolTip(listbox, Convert.ToString(listQueryTargets.Items[index].SubItems[1].Text));
                //}
                //else
                //{
                //    _toolTip.SetToolTip(listbox, Convert.ToString(listQueryTargets.Items[index].SubItems[1].Text + "." + listQueryTargets.Items[index].SubItems[2].Text));
                //}
            }
        }


        private void ResetQuery()
        {
            ClearExecutionResults();

            tabItemSummary.Visible = ProductConstants.optionsShowSummary;
            tabItemRollup.Visible = ProductConstants.optionsShowCombinedResults;
            tabControlResults.Visible = true;

            // initialize results area
            m_ErrorReports.Clear();
            m_JobPool = new JobPool<MultiQueryResult>(ProductConstants.optionsMaxThreads);
            m_JobPool.ServerTaskComplete += JobPoolTaskComplete;
            m_JobPool.TaskComplete += AllTasksComplete;
        }

        private void InitializeResultsArray(int count)
        {
            m_queryResults = new List<MultiQueryResult>(count);
            for (int i = 0; i < count; i++)
            {
                MultiQueryResult mqr = new MultiQueryResult();
                m_queryResults.Add(mqr);
            }
        }

        //-----------------------------------------------------------------------
        // GetServerList - returns List<ServerInformation> based on query target
        //-----------------------------------------------------------------------
        private List<ServerInformation>
           GetServerList(
              QueryTarget qt
           )
        {
            List<ServerInformation> serverList = new List<ServerInformation>();

            if (qt.isServerGroup)
            {
                ToolServerGroup serverGroup = ToolServerGroup.FindServerGroup(qt.server);
                if (serverGroup == null)
                {
                    m_ErrorReports.Add(qt.server, "Skipped server group. The specified server group no longer exists.");
                }
                else
                {
                    // Group - recursively add all servers from group to the list of servers to process
                    foreach (ToolServer toolServer in (serverGroup.GetServers(true)))
                    {
                        string srv = SQLHelpers.NormalizeInstanceName(toolServer.Name);

                        ServerInformation si = new ServerInformation(srv, toolServer.Credentials);
                        serverList.Add(si);
                    }
                }
            }
            else
            {
                ServerInformation si = new ServerInformation(qt.server, qt.credentials);
                serverList.Add(si);
            }
            return serverList;
        }

        //-----------------------------------------------------------------------
        // AllTasksComplete - All threads have run to completion
        //-----------------------------------------------------------------------
        void AllTasksComplete(object sender, JobExecutionEventArgs e)
        {
            try
            {
                ProgressBar_Close();
                tabControlResults.SuspendLayout();

                if (ProductConstants.optionsShowSummary)
                {
                    // mark any tasks that stil say In Progress as Cancelled
                    for (int row = 0; row < m_queryResults.Count; row++)
                    {
                        if (dataGridSummary.Rows[row].Cells[1].Value.ToString() == "In Progress")
                        {
                            SummaryGrid_Update(row, "Cancelled");

                            dataGridSummary.Rows[row].Cells[3].Value = "Cancelled by user";

                            m_queryResults[row].cancelled = false;
                            m_queryResults[row].message = "Cancelled";

                            //skip past the summary and combined tabs if they are being displayed.
                            int serverIndex = row;
                            if (ProductConstants.optionsShowCombinedResults)
                                serverIndex++;
                            if (ProductConstants.optionsShowSummary)
                                serverIndex++;
                            try
                            {
                                AddMessageArea(tabControlResults.Tabs[serverIndex], serverIndex, m_queryResults[row].message);
                            }
                            catch { }
                           
                        }
                    }
                }

                // created combined results tab
                if (ProductConstants.optionsShowCombinedResults)
                {
                    CreateCombinedResults();
                }

                // select correct tab             
                //if ( ProductConstants.optionsShowSummary )
                //{
                //   tabControlResults.SelectedTab = tabItemSummary;
                //}
                //else if ( ProductConstants.optionsShowCombinedResults )
                //{
                //    tabControlResults.SelectedTab = tabItemRollup;
                //}
                //else
                //{
                tabControlResults.SelectedTabIndex = 0;
                //}
            }
            finally
            {
                tabControlResults.ResumeLayout();
            }
        }

        //------------------------------------------------------------------------
        // JobPoolTaskComplete - Called as each server finished - once per server
        //------------------------------------------------------------------------
        void JobPoolTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            MultiQueryOptions mqo = (MultiQueryOptions)e.Server.Tag;
            string server_database = GetServerDatabaseName(e.Server.Name, mqo.database);

            //offset past the summary tabs                  
            int row = mqo.queryIndex;

            //skip past the summary and combined tabs if they are being displayed.
            int serverIndex = row;
            if (ProductConstants.optionsShowCombinedResults)
                serverIndex++;
            if (ProductConstants.optionsShowSummary)
                serverIndex++;

            m_queryResults[row].server = e.Server.Name;
            m_queryResults[row].database = mqo.database;

            if (e.Resultset == null)
            {
                m_queryResults[row].executionTimeInTicks = 0;
                m_queryResults[row].nResultSets = 0;
                m_queryResults[row].nRows = 0;
            }
            else
            {
                m_queryResults[row] = (MultiQueryResult)e.Resultset;
                m_queryResults[row].server = e.Server.Name;
                m_queryResults[row].database = mqo.database;
            }

            if (e.Status == TaskStatus.Failed)
            {
                // should never get here
                if (ProductConstants.optionsShowSummary)
                {
                    string msg = e.ErrorMessage;
                    int pos = e.ErrorMessage.IndexOf("\r\n");
                    if (e.ErrorMessage.StartsWith("Msg ") && pos != -1)
                    {
                        msg = e.ErrorMessage.Substring(pos + 2);
                    }
                    SummaryGrid_Update(row, "Failed");
                    dataGridSummary.Rows[row].Cells[3].Value = msg;
                }

                m_queryResults[row].cancelled = false;
                m_queryResults[row].message = e.ErrorMessage;
            }
            else if (e.Status == TaskStatus.Success)
            {
                MultiQueryResult mqResult = (MultiQueryResult)e.Resultset;
                m_queryResults[row].cancelled = false;

                if (ProductConstants.optionsShowSummary)
                {
                    dataGridSummary.Rows[row].Cells[2].Value = mqResult.executionTimeInTicks.ToString();
                }

                if (ProductConstants.optionsShowSummary)
                {
                    dataGridSummary.Rows[row].Cells[3].Value
                        = String.Format("{0} Row{1} in {2} Result Set{3}",
                                         mqResult.nRows,
                                         (mqResult.nRows != 1) ? "s" : "",
                                         mqResult.nResultSets,
                                         (mqResult.nResultSets != 1) ? "s" : "");

                    if (mqResult.nFailed > 0)
                    {
                        int pos = mqResult.message.IndexOf("\r\n");
                        string msg = (mqResult.message.StartsWith("Msg ") && pos != -1)
                                        ? mqResult.message.Substring(pos + 2)
                                        : mqResult.message;

                        if (mqResult.nSucceeded > 0)
                        {
                            SummaryGrid_Update(row, "Partial Success");
                        }
                        else
                        {
                            SummaryGrid_Update(row, "Failed");
                        }
                        dataGridSummary.Rows[row].Cells[3].Value = msg;
                    }
                    else
                    {
                        SummaryGrid_Update(row, "Succeeded");
                    }
                }

                if (ProductConstants.optionsShowIndividualResults)
                {
                    // create individual grids
                    DevComponents.DotNetBar.TabControl tabControl = CreateTabControl(serverIndex);
                    tabControl.SuspendLayout();
                    ((System.ComponentModel.ISupportInitialize)(tabControl)).BeginInit();

                    int nTables = 0;
                    for (int i = 0; i < m_queryResults[row].nTotal; i++)
                    {
                        CreateResultSetAsGrid(false,
                                               tabControl,
                                               ref m_queryResults[row].batchResults[i].dataSet,
                                               serverIndex,
                                               nTables);

                        nTables += m_queryResults[row].batchResults[i].dataSet.Tables.Count;
                    }
                    CreateResultMessageArea(tabControl, m_queryResults[row].message, serverIndex);

                    ((System.ComponentModel.ISupportInitialize)(tabControl)).EndInit();
                    tabControl.ResumeLayout();

                    tabControlResults.Tabs[serverIndex].AttachedControl.Controls[0].Controls.Add(tabControl);
                }
            }
            else if (e.Status != TaskStatus.Cancelled)
            {
                if (ProductConstants.optionsShowSummary)
                {
                    SummaryGrid_Update(row, "Cancelled");
                    dataGridSummary.Rows[row].Cells[3].Value = "Cancelled by user";
                }
                m_queryResults[row].cancelled = false;

                string msg = String.Format("Query Cancelled - {0} of {1} batches executed.\r\n\r\n",
                                            m_queryResults[row].nFailed + m_queryResults[row].nSucceeded,
                                            m_queryResults[row].nTotal);

                m_queryResults[row].message = msg + m_queryResults[row].message;
            }

            if (ProductConstants.optionsShowIndividualResults)
            {
                AddMessageArea(tabControlResults.Tabs[serverIndex], serverIndex, m_queryResults[row].message);
            }
        }

        private void
           AddMessageArea(
              DevComponents.DotNetBar.TabItem ownerTab,
              int row,
              string message
           )
        {
            DevComponents.DotNetBar.Controls.TextBoxX textMessage = new DevComponents.DotNetBar.Controls.TextBoxX();
            textMessage.BackColor = System.Drawing.Color.White;
            textMessage.Border.Class = "TextBoxBorder";
            textMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            textMessage.Location = new System.Drawing.Point(1, 1);
            textMessage.Multiline = true;
            textMessage.Name = String.Format("textMessage{0}", row);
            textMessage.ReadOnly = true;
            textMessage.TabIndex = 0;
            textMessage.Text = message;
            textMessage.ContextMenuStrip = contextMenuResults;
            textMessage.ScrollBars = ScrollBars.Both;
            textMessage.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textMessage.WordWrap = false;

            ownerTab.AttachedControl.Controls[0].Controls.Add(textMessage);
        }

        #endregion

        #region Progress Bar Functions

        public void ProgressBar_Show()
        {
            if (m_ProgressDialog != null)
            {
                m_ProgressDialog.ShowDialog();
            }
        }

        public void ProgressBar_Close()
        {
            if (m_ProgressDialog != null)
            {
                m_ProgressDialog.TopLevel = false;
                m_ProgressDialog.Visible = false;
                m_ProgressDialog.Close();
                m_ProgressDialog = null;
            }
        }

        public void ProgressBar_Initialize(string text)
        {
            m_ProgressDialog = new ToolProgressBarDialog();
            m_ProgressDialog.OperationText = text;
            m_ProgressDialog.CancelEnabled = true;
            m_ProgressDialog.ProgressCancelEvent += new EventHandler<EventArgs>(ProgressBar_CancelHandler);

            ProductConstants.globalCancelRequested = false;
            ProductConstants.globalOperationCancelled = false;
        }

        public void ProgressBar_CancelHandler(object sender, EventArgs e)
        {
            m_ProgressDialog.OperationText = "Cancelling...";
            m_ProgressDialog.CancelEnabled = false;
            ProductConstants.globalCancelRequested = true;

            m_JobPool.Cancel(true);
        }

        #endregion

        private bool headerCollapsed = false;
        private void buttonHideHeader_Click(object sender, EventArgs e)
        {
            if (headerCollapsed)
            {
                panelTop.Show();
            }
            else
            {
                panelTop.Hide();
            }
            headerCollapsed = !headerCollapsed;
        }

        private void
           AddServerTab(
              string server,
              string database
           )
        {
            string serverName = GetServerDatabaseName(server, database);

            DevComponents.DotNetBar.TabItem newTabItem = new DevComponents.DotNetBar.TabItem();
            DevComponents.DotNetBar.TabControlPanel newTabControlPanel = new DevComponents.DotNetBar.TabControlPanel();
            System.Windows.Forms.Panel topPanel = new System.Windows.Forms.Panel();
            System.Windows.Forms.Panel bottomPanel = new System.Windows.Forms.Panel();
            System.Windows.Forms.Label labelHeading = new System.Windows.Forms.Label();

            // Initialize Tab Item
            newTabItem.AttachedControl = newTabControlPanel;
            newTabItem.Name = String.Format("tabItemServer{0}", this.tabControlResults.Tabs.Count);
            newTabItem.Text = serverName;
            newTabItem.Tooltip = serverName;

            // Initialize LabelHeading
            labelHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            labelHeading.BackColor = System.Drawing.Color.White;
            labelHeading.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelHeading.ForeColor = System.Drawing.Color.Black;
            labelHeading.Location = new System.Drawing.Point(0, 0);
            labelHeading.Name = String.Format("labelTabHeading{0}", this.tabControlResults.Tabs.Count);
            labelHeading.Size = new System.Drawing.Size(505, 22);
            labelHeading.TabIndex = 1;
            labelHeading.Text = String.Format("{0} Results", serverName);
            labelHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Initialize Top Panel
            topPanel.Controls.Add(labelHeading);
            topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topPanel.Location = new System.Drawing.Point(1, 1);
            topPanel.Name = String.Format("panelTabServer{0}", this.tabControlResults.Tabs.Count);
            topPanel.Size = new System.Drawing.Size(504, 22);
            topPanel.TabIndex = 0;

            // Initialize Bottom Panel
            bottomPanel.BackColor = System.Drawing.Color.Transparent;
            bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            bottomPanel.Location = new System.Drawing.Point(1, 23);
            bottomPanel.Name = String.Format("panelTabBottom{0}", this.tabControlResults.Tabs.Count);
            bottomPanel.Size = new System.Drawing.Size(504, 254);
            bottomPanel.TabIndex = 1;

            // Initialize Tab Control
            newTabControlPanel.Controls.Add(bottomPanel);
            newTabControlPanel.Controls.Add(topPanel);
            newTabControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            newTabControlPanel.Location = new System.Drawing.Point(183, 0);
            newTabControlPanel.Name = String.Format("tabControl{0}", this.tabControlResults.Tabs.Count);
            newTabControlPanel.Padding = new System.Windows.Forms.Padding(1);
            newTabControlPanel.Size = new System.Drawing.Size(506, 278);
            newTabControlPanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            newTabControlPanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            newTabControlPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            newTabControlPanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            newTabControlPanel.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Right | DevComponents.DotNetBar.eBorderSide.Top)
                   | DevComponents.DotNetBar.eBorderSide.Bottom)));
            newTabControlPanel.TabIndex = 2;
            newTabControlPanel.TabItem = newTabItem;

            // add them to the overall tab control         
            this.tabControlResults.SuspendLayout();
            this.tabControlResults.Controls.Add(newTabControlPanel);
            this.tabControlResults.Tabs.Add(newTabItem);
            this.tabControlResults.ResumeLayout();

            // add top panel
            // add top heading
            // add bottom panel

            this.tabControlResults.Invalidate();
            Application.DoEvents();
        }

        private void RemoveSummaryTabs()
        {
            try
            {
                tabControlResults.Tabs.Remove(tabItemSummary);
            }
            catch { };

            try
            {
                tabControlResults.Tabs.Remove(tabItemRollup);
            }
            catch { };
        }

        private void AddSummaryTabs()
        {
            if (ProductConstants.optionsShowCombinedResults)
            {
                tabControlResults.Tabs.Add(tabItemRollup);
                tabControlResults.Controls.Add(tabItemRollup.AttachedControl);
            }

            if (ProductConstants.optionsShowSummary)
            {
                tabControlResults.Tabs.Add(tabItemSummary);
                tabControlResults.Controls.Add(tabItemSummary.AttachedControl);
            }

            tabControlResults.Invalidate();
            Application.DoEvents();
        }

        #region Query Target IO

        private void buttonNewTarget_Click(object sender, EventArgs e)
        {
            CreateNewTarget();
        }

        private void CreateNewTarget()
        {
            if (ProductConstants.QueryTargetDirty)
            {
                string msg = String.Format("The query target list '{0}' has changed.\r\n\r\n" +
                                            "Do you want to save the changes?",
                                            ProductConstants.QueryTargetFile);
                DialogResult choice = Messaging.ShowConfirmationWithCancel(msg);
                if (choice == DialogResult.Yes)
                {
                    // save
                    choice = SaveQueryTargetFile(false);
                    if (choice == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                else if (choice == DialogResult.Cancel)
                {
                    return;
                }
            }

            // clear lists
            listQueryTargets.Items.Clear();
            SetExecuteButtonsEnabled();

            SetQueryTargetFile(false, "<Untitled>");
            MarkQueryTargetDirty(false);
        }

        private void menuOpenQueryTarget_Click(object sender, EventArgs e)
        {
            OpenQueryTarget();
        }

        private void buttonLoadTargets_Click(object sender, EventArgs e)
        {
            OpenQueryTarget();
        }

        private void contextOpenQueryTargetFile_Click(object sender, EventArgs e)
        {
            OpenQueryTarget();
        }


        private void linkLabelOpenTarget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenQueryTarget();
        }

        private void OpenQueryTarget()
        {
            if (!CheckForDirtyQueryTarget()) return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.DefaultExt = "sqt";
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Query Target Files (*.sqt)|*.sqt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ReadQueryTarget(openFileDialog.FileName);

                    ProductConstants.lastQueryTargetFile = openFileDialog.FileName;
                    ProductConstants.WriteOptions();
                }
                catch (Exception ex)
                {
                    Messaging.ShowError("An error occurred trying to open the specified query target file.\r\n\r\nError: " + ex.Message);
                }
            }
        }

        private bool ReadQueryTarget(string filepath)
        {
            bool success = false;
            bool readingDefault = false;

            if (filepath == "")
            {
                readingDefault = true;
                string folder = Helpers.GetProductDirectory(true);
                filepath = Path.Combine(folder, ProductConstants.defaultQueryTargetFile);
            }

            StreamReader streamReader = null;

            try
            {
                Cursor = Cursors.WaitCursor;

                // Open the data file  
                string query = "";

                query = File.ReadAllText(filepath);

                if (query.Length > ProductConstants.MaxQueryFileSize)
                {
                    throw new Exception(String.Format("Query file larger then maximum supported size: {0}",
                                                        ProductConstants.MaxQueryFileSize));
                }

                // load query target list
                List<QueryTarget> qtList = QueryTarget.ReadQueryTargetFile(filepath);


                if (ValidateQueryTargetServerGroups(qtList))
                {
                    bool skippedBadGroups = false;

                    listQueryTargets.Items.Clear();

                    foreach (QueryTarget qt in qtList)
                    {
                        ToolServerGroup g = ToolServerGroup.FindServerGroup(qt.server);
                        if (qt.isServerGroup && g == null)
                        {
                            skippedBadGroups = true;
                        }
                        else
                        {
                            AddQueryTargetListViewItem(qt);
                        }
                    }

                    if (!readingDefault)
                    {
                        SetQueryTargetFile(true, filepath);
                    }
                    MarkQueryTargetDirty(skippedBadGroups);  // if we had to skip bad groups then the file is dirty on the load
                    SetExecuteButtonsEnabled();
                    groupTargetHelp.Visible = false;
                }
            }
            finally
            {
                Cursor = Cursors.Default;
                if (streamReader != null) streamReader.Close();
            }

            return success;
        }

        private bool
           ValidateQueryTargetServerGroups(
              List<QueryTarget> qtList
           )
        {
            bool validFile = true;
            string badGroups = "";

            foreach (QueryTarget qt in qtList)
            {
                if (qt.isServerGroup)
                {
                    // does server group exist
                    ToolServerGroup g = ToolServerGroup.FindServerGroup(qt.server);
                    if (g == null)
                    {
                        if (badGroups != "") badGroups += "\r\n";
                        badGroups += "     " + qt.server;
                    }
                }
            }

            if (badGroups.Length != 0)
            {
                string msg = String.Format("The Query Target file contains the following server " +
                                            "groups that no longer exist. If you continue, these groups " +
                                            "will be ignored and removed from the query target list:\r\n\r\n" +
                                            "{0}\r\n\r\n" +
                                            "Do you want to continue loading this file?",
                                            badGroups);

                DialogResult choice = Messaging.ShowConfirmation(msg);
                if (choice == DialogResult.No)
                {
                    validFile = false;
                }
            }

            return validFile;
        }

        private bool CheckForDirtyQueryTarget()
        {
            if (ProductConstants.QueryTargetDirty)
            {
                if (ProductConstants.QueryTargetIsFile)
                {
                    string msg = String.Format("The query target list '{0}' has changed.\r\n\r\n" +
                                                "Do you want to save the changes?",
                                                ProductConstants.QueryTargetFile);
                    DialogResult choice = Messaging.ShowConfirmationWithCancel(msg);
                    if (choice == DialogResult.Yes)
                    {
                        // save
                        choice = SaveQueryTargetFile(false);
                        if (choice == DialogResult.Cancel)
                        {
                            return false;
                        }
                    }
                    else if (choice == DialogResult.Cancel)
                    {
                        return false;
                    }
                }
                else
                {
                    InternalSaveQueryTargetFile("");
                }
            }
            return true;
        }

        private void
           AddQueryTargetListViewItem(
              QueryTarget queryTarget
           )
        {
            ListViewItem lvi = new ListViewItem("");
            lvi.SubItems.Add(queryTarget.server);
            lvi.SubItems.Add(String.IsNullOrEmpty(queryTarget.database) ? "<default>" : queryTarget.database);
            if (queryTarget.isServerGroup)
                lvi.ImageIndex = 2;
            else
                lvi.ImageIndex = (queryTarget.credentials != null) &&
                                   (queryTarget.credentials.useSqlAuthentication)
                                   ? 1 : 0;

            lvi.Tag = queryTarget;

            listQueryTargets.Items.Add(lvi);
        }

        private void buttonSaveTarget_Click(object sender, EventArgs e)
        {
            SaveQueryTargetFile(false);
        }

        private void contextSaveQueryTargetFile_Click(object sender, EventArgs e)
        {
            SaveQueryTargetFile(false);
        }

        private void contextSaveQueryTargetFileAs_Click(object sender, EventArgs e)
        {
            SaveQueryTargetFile(true);
        }


        private DialogResult SaveQueryTargetFile(bool doSaveAs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.DefaultExt = "sqt";
            saveFileDialog.Filter = "Query Target Files (*.sqt)|*.sqt|All files (*.*)|*.*";

            if (ProductConstants.QueryTargetIsFile)
            {
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(ProductConstants.QueryTargetFile);
                saveFileDialog.FileName = ProductConstants.QueryTargetFile;
            }
            else
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.FileName = "*.sqt";
                doSaveAs = true;  // force request for filename since we dont have a file
            }

            DialogResult choice = DialogResult.OK;

            if (doSaveAs)
            {
                choice = saveFileDialog.ShowDialog();
            }

            if (choice == DialogResult.OK)
            {
                try
                {
                    InternalSaveQueryTargetFile(saveFileDialog.FileName);

                    ProductConstants.lastQueryTargetFile = saveFileDialog.FileName;
                    ProductConstants.WriteOptions();
                }
                catch (Exception ex)
                {
                    Messaging.ShowError(ex.Message);

                    return DialogResult.Cancel; // we cant write so just give up                                 
                }
            }

            return choice;
        }

        private bool
           InternalSaveQueryTargetFile(
              string filepath
           )
        {
            bool success = false;
            bool savingDefault = false;

            if (filepath == "")
            {
                savingDefault = true;
                string folder = Helpers.GetProductDirectory(true);
                filepath = Path.Combine(folder, ProductConstants.defaultQueryTargetFile);
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                // delete existing file               
                if (File.Exists(filepath))
                {
                    try
                    {
                        File.Delete(filepath);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(String.Format("An error occurred trying to overwrite the existing file.\r\n\r\nError: {0}",
                                                             ex.Message));
                    }
                }

                // write file
                QueryTarget.WriteQueryTarget(filepath);

                if (!savingDefault)
                {
                    SetQueryTargetFile(true, filepath);
                }
                MarkQueryTargetDirty(false);

                success = true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred trying to save the query target file.\r\n\r\nError: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            return success;
        }

        private void
           MarkQueryTargetDirty(bool dirty)
        {
            if (ProductConstants.QueryTargetDirty != dirty)
            {
                ProductConstants.QueryTargetDirty = dirty;
                labelQueryTargetFile.Text = String.Format("Query Target File: {0}{1}",
                                                           ProductConstants.QueryTargetFile,
                                                           (dirty) ? "*" : "");
            }
        }

        private void
           SetQueryTargetFile(
              bool isFile,
              string fileName
           )
        {
            ProductConstants.QueryTargetIsFile = isFile;
            ProductConstants.QueryTargetFile = fileName;

            labelQueryTargetFile.Text = "Query Target File: " + fileName;
        }



        #endregion

        #region SQL File IO


        private void contextQueryNew_Click(object sender, EventArgs e)
        {
            CreateNewQuery();
        }

        private void buttonQueryNew_Click(object sender, EventArgs e)
        {
            CreateNewQuery();
        }

        private void linkLabelNewQuery_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateNewQuery();
        }

        private void CreateNewQuery()
        {
            if (!CheckForDirtyQuery()) return;

            textSQL.Text = "";
            textSQL.Modified = false;
            groupPanelQueryHelp.Visible = false;

            SetQueryFile(false, "<Untitled>");
            MarkQueryDirty(false);

            textSQL.Select();
        }

        private bool CheckForDirtyQuery()
        {
            if (ProductConstants.QueryDirty)
            {
                string msg = String.Format("The text in the query '{0}' has changed.\r\n\r\n" +
                                            "Do you want to save the changes?",
                                            ProductConstants.QueryFile);
                DialogResult choice = Messaging.ShowConfirmationWithCancel(msg);
                if (choice == DialogResult.Yes)
                {
                    // save
                    choice = SaveQueryFile(false);
                    if (choice == DialogResult.Cancel)
                    {
                        return false;
                    }
                }
                else if (choice == DialogResult.Cancel)
                {
                    return false;
                }
            }
            return true;
        }

        private void contextQueryOpen_Click(object sender, EventArgs e)
        {
            OpenQuery("");
        }

        private void menuOpenQuery_Click(object sender, EventArgs e)
        {
            OpenQuery("");
        }

        private void buttonQueryOpen_Click(object sender, EventArgs e)
        {
            OpenQuery("");
        }

        private void linkLabelOpenQuery_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenQuery("");
        }

        private bool OpenQuery(string fileName)
        {
            if (ProductConstants.QueryDirty)
            {
                string msg = String.Format("The text in the query '{0}' has changed.\r\n\r\n" +
                                            "Do you want to save the changes?",
                                            ProductConstants.QueryFile);
                DialogResult choice = Messaging.ShowConfirmationWithCancel(msg);
                if (choice == DialogResult.Yes)
                {
                    // save
                    choice = SaveQueryFile(false);
                    if (choice == DialogResult.Cancel)
                    {
                        return false;
                    }
                }
                else if (choice == DialogResult.Cancel)
                {
                    return false;
                }
            }

            if (String.IsNullOrEmpty(fileName))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.DefaultExt = "sql";
                openFileDialog.AddExtension = true;
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Query Files (*.sql)|*.sql|All files (*.*)|*.*";

                if (!String.IsNullOrEmpty(ProductConstants.optionsQueryDirectory))
                {
                    openFileDialog.InitialDirectory = ProductConstants.optionsQueryDirectory;
                }

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return false;
                }
                fileName = openFileDialog.FileName;
            }

            StreamReader streamReader = null;

            try
            {
                Cursor = Cursors.WaitCursor;

                // Open the data file  
                string query = "";

                query = File.ReadAllText(fileName);

                textSQL.Text = query;
                textSQL.Modified = false;

                SetQueryFile(true, fileName);
                MarkQueryDirty(false);
                AddFileToRecentFileList(fileName);

                SetQueryDirectory(fileName);
            }
            catch (Exception ex)
            {
                Messaging.ShowError("An error occurred trying to open the specified query file.\r\n\r\nError: " + ex.Message);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
                if (streamReader != null) streamReader.Close();
            }

            return true;
        }

        private void contextQuerySave_Click(object sender, EventArgs e)
        {
            SaveQueryFile(false);
        }

        private void contextQuerySaveAs_Click(object sender, EventArgs e)
        {
            SaveQueryFile(true);
        }

        private void buttonQuerySave_Click(object sender, EventArgs e)
        {
            SaveQueryFile(false);
        }

        private void buttonQuerySaveAs_Click(object sender, EventArgs e)
        {
            SaveQueryFile(true);
        }

        private DialogResult SaveQueryFile(bool doSaveAs)
        {
            DialogResult choice;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.DefaultExt = "sql";
            saveFileDialog.Filter = "Query Files (*.sql)|*.sql|All files (*.*)|*.*";

            if (ProductConstants.QueryIsFile)
            {
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(ProductConstants.QueryFile);
                saveFileDialog.FileName = ProductConstants.QueryFile;
            }
            else
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.FileName = "*.sql";
                doSaveAs = true;  // force request for filename since we dont have a file
            }

            if (doSaveAs)
            {
                choice = saveFileDialog.ShowDialog();
            }
            else
            {
                choice = DialogResult.OK;
            }

            if (choice == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    // delete existing file               
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        try
                        {
                            File.Delete(saveFileDialog.FileName);
                        }
                        catch (Exception ex)
                        {
                            Messaging.ShowError(
                               String.Format("An error occurred trying to overwrite the existing file.\r\n\r\nError: {0}",
                                              ex.Message));
                            return DialogResult.Cancel; // we cant write so just give up                                 
                        }
                    }

                    // write file
                    using (FileStream _Stream = new FileStream(saveFileDialog.FileName,
                                                                FileMode.Create,
                                                                FileAccess.Write))
                    {
                        using (StreamWriter _Writer = new StreamWriter(_Stream))
                        {
                            _Writer.Write(textSQL.Text);
                        }
                    }

                    SetQueryDirectory(saveFileDialog.FileName);
                    SetQueryFile(true, saveFileDialog.FileName);
                    AddFileToRecentFileList(saveFileDialog.FileName);

                    MarkQueryDirty(false);
                }
                catch (Exception ex)
                {
                    Messaging.ShowError("An error occurred trying to save the query file.\r\n\r\nError: " + ex.Message);
                    choice = DialogResult.Cancel;
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
            return choice;
        }

        private void
           MarkQueryDirty(bool dirty)
        {
            if (ProductConstants.QueryDirty != dirty)
            {
                textSQL.Modified = dirty;
                ProductConstants.QueryDirty = dirty;
                navQuery.TitlePanel.Text = String.Format("Query - {0}{1}",
                                                          ProductConstants.QueryFile,
                                                          (dirty) ? "*" : "");
            }
        }

        private void
           SetQueryFile(
              bool isFile,
              string fileName
           )
        {
            ProductConstants.QueryIsFile = isFile;
            ProductConstants.QueryFile = fileName;

            navQuery.TitlePanel.Text = String.Format("Query - {0}", fileName);
        }

        private void textSQL_TextChanged(object sender, EventArgs e)
        {
            MarkQueryDirty(true);

            contextQuerySave.Enabled =
            contextQuerySaveAs.Enabled =
            buttonQuerySave.Enabled =
            buttonQuerySaveAs.Enabled = (textSQL.Text.Length != 0);

            SetExecuteButtonsEnabled();

            groupPanelQueryHelp.Visible = false;
        }

        #endregion

        private void SetExecuteButtonsEnabled()
        {
            // need both query targets and sql to run a query
            contextExecute.Enabled =
            contextExecuteSelected.Enabled =
            contextTargetExecuteAgainstSelectedQueryTargets.Enabled =
            buttonExecuteSelectedTargets.Enabled =
            buttonExecuteQuery.Enabled = (listQueryTargets.Items.Count != 0) &&
                                                   (textSQL.Text.Length != 0);
        }

        #region Query Options

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            EditOptions();
        }

        private void multiQueryOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditOptions();
        }

        private void contextQueryOptions_Click(object sender, EventArgs e)
        {
            EditOptions();
        }

        private void EditOptions()
        {
            Form_QueryOptions frm = new Form_QueryOptions();
            frm.ShowDialog();
        }

        #endregion

        private void contextQuerySelectAll_Click(object sender, EventArgs e)
        {
            textSQL.Selection.SelectAll();
        }

        private void contextQueryCut_Click(object sender, EventArgs e)
        {
            textSQL.Selection.Cut();
        }

        private void contextQueryCopy_Click(object sender, EventArgs e)
        {
            textSQL.Selection.Copy();
        }

        private void contextQueryPaste_Click(object sender, EventArgs e)
        {
            textSQL.Selection.Paste();
        }

        private void contextResultsClear_Click(object sender, EventArgs e)
        {
            ClearExecutionResults();

            tabControlResults.Visible = false;
        }

        private void ClearExecutionResults()
        {
            // combined results tab
            DeleteTabContents(tabItemRollup);

            // roll-up tab
            panelTabRollupBottom.Controls.Clear();

            // individual server tabs
            tabControlResults.SuspendLayout();

            while (tabControlResults.Tabs.Count > 0)
            {
                DeleteTabContents(tabControlResults.Tabs[0]);
                tabControlResults.Tabs[0].Visible = false;
                tabControlResults.Tabs.RemoveAt(0);
            }
            tabControlResults.ResumeLayout();

            // clear result sets array
            if (m_queryResults != null)
            {
                m_queryResults.Clear();
                m_queryResults = null;
            }


            // summary
            dataGridSummary.Rows.Clear();



            // kill dataset
            if (m_combinedResultSet != null)
            {
                m_combinedResultSet.Clear();
                m_combinedResultSet = null;
            }

        }

        #region Summary Grid

        private void
           SummaryGrid_Initialize(
              string server,
              string database
           )
        {
            string sd = GetServerDatabaseName(server, database);
            dataGridSummary.Rows.Add(sd, "In Progress", "", "");
        }

        private void
           SummaryGrid_Update(
              int row,
              string strStatus
           )
        {
            dataGridSummary.Rows[row].Cells[1].Value = strStatus;
            if (strStatus == "Cancelled")
            {
                dataGridSummary.Rows[row].Cells[1].Style.BackColor = Color.Yellow;
                dataGridSummary.Rows[row].Cells[1].Style.SelectionBackColor = Color.Yellow;
            }
            else if (strStatus == "Succeeded")
            {
                dataGridSummary.Rows[row].Cells[1].Style.BackColor = Color.LightGreen;
                dataGridSummary.Rows[row].Cells[1].Style.SelectionBackColor = Color.LightGreen;
            }
            else if (strStatus == "Failed")
            {
                dataGridSummary.Rows[row].Cells[1].Style.BackColor = Color.Red;
                dataGridSummary.Rows[row].Cells[1].Style.SelectionBackColor = Color.Red;
            }
        }

        #endregion

        private string
           GetServerDatabaseName(
              string server,
              string database
           )
        {
            string server_database = String.Format("{0}{1}{2}",
                                                    server,
                                                    String.IsNullOrEmpty(database) ? "" : ".",
                                                    String.IsNullOrEmpty(database) ? "" : database);
            return server_database;
        }

        private void Form_Main_Resize(object sender, EventArgs e)
        {
            int pos;

            pos = (this.navQueryTargets.Width - groupTargetHelp.Width) / 2;
            groupTargetHelp.Left = pos;

            pos = (navQuery.Width - groupPanelQueryHelp.Width) / 2;
            groupPanelQueryHelp.Left = pos;

            pos = (navQuery.Height - groupPanelQueryHelp.Height) / 2;
            if (pos < 0)
            {
                pos = 0;
            }
            groupPanelQueryHelp.Top = pos;
        }

        private void expandableSplitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            int pos;

            pos = (this.navQueryTargets.Width - groupTargetHelp.Width) / 2;
            groupTargetHelp.Left = pos;
        }

        private void textSQL_Enter(object sender, EventArgs e)
        {
            groupPanelQueryHelp.Visible = false;

            menuCut.Enabled =
            menuCopy.Enabled =
            menuPaste.Enabled =
            menuSelectAll.Enabled = true;
        }

        private void textSQL_Leave(object sender, EventArgs e)
        {
            menuCut.Enabled =
            menuCopy.Enabled =
            menuPaste.Enabled =
            menuSelectAll.Enabled = false;
        }

        #region Combined Results Tab Creation

        private void CreateCombinedResults()
        {
            // Do all datasets that had successful queries match?
            int first = -1;
            bool match = true;
            int matching = 0;

            for (int i = 0; i < m_queryResults.Count; i++)
            {
                if (first == -1)
                {
                    // looking for first successful query
                    if (m_queryResults[i].nResultSets > 0)
                    {
                        first = i;
                        matching = 1;
                    }
                }
                else
                {
                    if (m_queryResults[i].nResultSets > 0)
                    {
                        match = DoQueryResultsMatch(first, i);
                        if (match) matching++;
                    }
                    if (!match) break;
                }
            }

            StringBuilder combinedMessage = new StringBuilder(1024);
            for (int i = 0; i < m_queryResults.Count; i++)
            {
                if (combinedMessage.Length != 0) combinedMessage.Append("\r\n\r\n");
                combinedMessage.AppendFormat("Query Target: {0}\r\n\r\n",
                                              GetServerDatabaseName(m_queryResults[i].server, m_queryResults[i].database));
                combinedMessage.Append(m_queryResults[i].message);
            }

            if ((!match) || (first == -1))
            {
                string combinedErrorMsg = "";
                if (first == -1)
                {
                    combinedErrorMsg = ""; //"Note: Could not combine result sets. No data available for display. There was no result set information returned for the Query Targets.";
                }
                else
                {
                    combinedErrorMsg = "Note: Could not combine result sets. The number of results sets and their columns must be identical across all SQL Servers.";
                }

                if (combinedErrorMsg.Length != 0) combinedErrorMsg += "\r\n\r\n";
                combinedErrorMsg += combinedMessage.ToString();
                AddMessageArea(tabControlResults.Tabs[tabItemRollup.Name], -1, combinedErrorMsg);
            }
            //else if ( matching == 1 )
            // {
            //}
            else
            {
                CreateCombinedResultSet();

                if (m_combinedResultSet.Tables == null || m_combinedResultSet.Tables.Count == 0)
                {
                    //string msg = "Note: No data available for display. There was no result set information returned for the Query Targets.";
                    AddMessageArea(tabControlResults.Tabs[tabItemRollup.Name], -1, combinedMessage.ToString());
                }
                else
                {
                    DevComponents.DotNetBar.TabControl tabControl = CreateTabControl(-1);
                    tabControl.SuspendLayout();
                    ((System.ComponentModel.ISupportInitialize)(tabControl)).BeginInit();

                    CreateResultSetAsGrid(true,
                                           tabControl,
                                           ref m_combinedResultSet,
                                           -1,
                                           0);

                    string combinedMsg = "";
                    for (int t = 0; t < m_combinedResultSet.Tables.Count; t++)
                    {
                        string msg = String.Format("Combined Result Set {0}: {1} total rows\r\n",
                                                    t + 1,
                                                    m_combinedResultSet.Tables[t].Rows.Count);
                        combinedMsg += msg;
                    }

                    if (combinedMsg.Length != 0) combinedMsg += "\r\n\r\n";
                    combinedMsg += combinedMessage.ToString();
                    CreateResultMessageArea(tabControl, combinedMsg, -1);

                    ((System.ComponentModel.ISupportInitialize)(tabControl)).EndInit();
                    tabControl.ResumeLayout();

                    // if combined results grid - set backcolor of first columns
                    //if ( serverIndex == -1 && dataGrid.Columns.Count >=2 )
                    //{
                    //   dataGrid.Columns[0].DefaultCellStyle.BackColor = Color.LightGray;
                    //   dataGrid.Columns[1].DefaultCellStyle.BackColor = Color.LightGray;
                    //}


                    tabControlResults.Tabs[tabItemRollup.Name].AttachedControl.Controls[0].Controls.Add(tabControl);
                }
            }
        }

        //---------------------------------------------------------------------------------
        // DoQueryResultsMatch
        //---------------------------------------------------------------------------------
        private bool
           DoQueryResultsMatch(
              int mqr1,
              int mqr2
           )
        {
            bool match = true;

            if (m_queryResults[mqr1].nResultSets != m_queryResults[mqr2].nResultSets) return false;
            if (m_queryResults[mqr1].batchResults.Count != m_queryResults[mqr2].batchResults.Count) return false;

            for (int b = 0; b < m_queryResults[mqr1].batchResults.Count; b++)
            {
                if (!QueryHelper.DoDataSetMetaDataMatch(ref m_queryResults[mqr1].batchResults[b].dataSet,
                                                           ref m_queryResults[mqr2].batchResults[b].dataSet))
                {
                    match = false;
                }
            }

            return match;
        }

        private void CreateCombinedResultSet()
        {
            if (CreateCombinedDataSetMetaData())
            {
                FillCombinedDataSetValues();
            }
        }

        private bool CreateCombinedDataSetMetaData()
        {
            bool success = false;

            try
            {
                // find first result set with values
                int ndx = -1;
                for (int i = 0; i < m_queryResults.Count; i++)
                {
                    if ( /* m_queryResults[i].nSucceeded > 0 && */ m_queryResults[i].nResultSets > 0)
                    {
                        ndx = i;
                        break;
                    }
                }

                if (ndx != -1)
                {
                    m_combinedResultSet = new DataSet();

                    for (int batch = 0; batch < m_queryResults[ndx].batchResults.Count; batch++)
                    {
                        for (int dt = 0; dt < m_queryResults[ndx].batchResults[batch].dataSet.Tables.Count; dt++)
                        {
                            DataTable newTable = new DataTable(
                               String.Format("{0}--{1}",
                                               m_queryResults[ndx].batchResults[batch].dataSet.Tables[dt].TableName,
                                               batch));

                            // add server and database columns
                            string colName = GetUniqueColumnName(batch, ndx, "Server");
                            DataColumn newColumn = new DataColumn(colName, typeof(string));
                            newColumn.Caption = "qt";
                            newTable.Columns.Add(newColumn);

                            colName = GetUniqueColumnName(batch, ndx, "Database");
                            newColumn = new DataColumn(colName, typeof(string));
                            newColumn.Caption = "qt";
                            newTable.Columns.Add(newColumn);

                            // add rest of columns
                            for (int c = 0;
                                  c < m_queryResults[ndx].batchResults[batch].dataSet.Tables[dt].Columns.Count;
                                  c++)
                            {
                                newTable.Columns.Add(m_queryResults[ndx].batchResults[batch].dataSet.Tables[dt].Columns[c].ColumnName,
                                                      m_queryResults[ndx].batchResults[batch].dataSet.Tables[dt].Columns[c].DataType);
                            }

                            m_combinedResultSet.Tables.Add(newTable);

                            success = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CoreGlobals.traceLog.ErrorFormat("Error creating combined metadata - {0}", ex.Message);
                success = false;
            }

            return success;
        }

        private string GetUniqueColumnName(int batch, int ndx, string prefix)
        {
            string uniqueName = prefix;
            bool haveUniqueName = false;

            // try some elemetary prefixes first
            haveUniqueName = !DoesColumnNameExist(batch, ndx, uniqueName);
            if (!haveUniqueName)
            {
                uniqueName = "_" + prefix;
                haveUniqueName = !DoesColumnNameExist(batch, ndx, uniqueName);
                if (!haveUniqueName)
                {
                    uniqueName = "qt" + prefix;
                    haveUniqueName = !DoesColumnNameExist(batch, ndx, uniqueName);
                }
            }

            // just start creating database_#
            int count = 0;
            while (!haveUniqueName)
            {
                haveUniqueName = !DoesColumnNameExist(batch, ndx, uniqueName);
                if (!haveUniqueName)
                {
                    count++;
                    uniqueName = String.Format("qt{0}_{1}", prefix, count);
                }
            }

            return uniqueName;
        }

        private bool DoesColumnNameExist(int batch, int ndx, string columnName)
        {
            bool columnExists = false;

            for (int dt = 0; (!columnExists) && (dt < m_queryResults[ndx].batchResults[batch].dataSet.Tables.Count); dt++)
            {
                // add rest of columns
                for (int c = 0;
                      c < m_queryResults[ndx].batchResults[batch].dataSet.Tables[dt].Columns.Count;
                      c++)
                {
                    if (columnName == m_queryResults[ndx].batchResults[batch].dataSet.Tables[dt].Columns[c].ColumnName)
                    {
                        columnExists = true;
                        break;
                    }
                }
            }

            return columnExists;
        }

        private void FillCombinedDataSetValues()
        {
            try
            {
                int tablesProcessed = 0;


                // find first result set with values
                int firstNdx = -1;
                for (int i = 0; i < m_queryResults.Count; i++)
                {
                    if ( /* m_queryResults[i].nSucceeded > 0 && */ m_queryResults[i].nResultSets > 0)
                    {
                        firstNdx = i;
                        break;
                    }
                }

                // loop through each SQL batch
                for (int b = 0; b < m_queryResults[firstNdx].batchResults.Count; b++)
                {
                    // loop through each tables in each dataset from each batch
                    if (m_queryResults[firstNdx].batchResults[b].dataSet != null)
                    {
                        for (int t = 0; t < m_queryResults[firstNdx].batchResults[b].dataSet.Tables.Count; t++)
                        {
                            // add rows from every query target result set
                            for (int ds = 0; ds < m_queryResults.Count; ds++)
                            {
                                if (m_queryResults[ds].nResultSets > 0)
                                {
                                    // copy each row into the combined table
                                    for (int r = 0; r < m_queryResults[ds].batchResults[b].dataSet.Tables[t].Rows.Count; r++)
                                    {
                                        object[] itemArray = new object[m_combinedResultSet.Tables[tablesProcessed].Columns.Count];

                                        itemArray[0] = m_queryResults[ds].server;
                                        itemArray[1] = String.IsNullOrEmpty(m_queryResults[ds].database)
                                                          ? "<default>"
                                                          : m_queryResults[ds].database;

                                        // copy cells
                                        int pos = 2;
                                        foreach (object o in m_queryResults[ds].batchResults[b].dataSet.Tables[t].Rows[r].ItemArray)
                                        {
                                            itemArray[pos] = o;
                                            pos++;
                                        }

                                        m_combinedResultSet.Tables[tablesProcessed].Rows.Add(itemArray);
                                    }
                                }
                            }
                            tablesProcessed++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CoreGlobals.traceLog.ErrorFormat("FillCombinedDataSetValues Error : {0}", ex.Message);
            }
        }

        #endregion


        #region Create Text Tab

        private void
          CreateResultSetAsText(
             DevComponents.DotNetBar.TabItem ownerTab,
             ref DataSet dataSet,
             int row
          )
        {
        }

        #endregion

        private void listQueryTargets_DoubleClick(object sender, EventArgs e)
        {
            if (listQueryTargets.SelectedItems.Count == 1)
            {
                EditQueryTarget();
            }
        }

        private void listExecuteQueryResults_Click(object sender, EventArgs e)
        {
            if (listExecuteQueryResults.SelectedItems.Count == 1)
            {
                tabControlResults.SelectedTabIndex = listExecuteQueryResults.Items.IndexOf(listExecuteQueryResults.SelectedItems[0]);
            }
        }

      
        #region Create Grid Tab

        private void
         CreateResultSetAsGrid(
           bool isCombinedResultTable,
            DevComponents.DotNetBar.TabControl tabControl,
            ref DataSet dataSet,
            int serverIndex,
            int nTablesBefore
         )
        {
            DevComponents.DotNetBar.Controls.DataGridViewX dataGrid = null;
            DevComponents.DotNetBar.TabControlPanel tabControlPanel = null;
            DevComponents.DotNetBar.TabItem tabItem = null;

            // Create style to use on all result grids
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = CreateDataGridViewCellStyle();

            // loop through tables in dataset creating result tabs          
            for (int t = 0; t < dataSet.Tables.Count; t++)
            {
                try
                {
                    // create objects
                    dataGrid = CreateDataGrid(serverIndex, t, dataGridViewCellStyle);

                    tabControlPanel = CreateTabControlPanel(serverIndex, t, dataGrid);
                    tabItem = new DevComponents.DotNetBar.TabItem(this.components);

                    // associate components
                    tabControlPanel.TabItem = tabItem;

                    // create tab
                    tabItem.AttachedControl = tabControlPanel;
                    tabItem.Name = String.Format("tabItem-{0}-{1}", serverIndex, nTablesBefore + t);
                    tabItem.Text = String.Format("Results {0}", nTablesBefore + t + 1);

                    // add panel and tab to tab control
                    tabControl.Controls.Add(tabControlPanel);
                    tabControl.Tabs.Add(tabItem);

                    // add columns
                    foreach (DataColumn _Column in dataSet.Tables[t].Columns)
                    {
                        DataGridViewTextBoxColumn _GridColumn = new DataGridViewTextBoxColumn();
                        _GridColumn.DataPropertyName = _GridColumn.HeaderText = _Column.ColumnName;
                        dataGrid.Columns.Add(_GridColumn);
                    }

                    if (isCombinedResultTable)
                    {
                        dataGrid.Columns[0].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                        dataGrid.Columns[1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }


                    //Add data
                    for (int _RowIndex = 0; _RowIndex < dataSet.Tables[t].Rows.Count; _RowIndex++)
                    {
                        dataGrid.Rows.Add();
                        for (int _ColumnIndex = 0; _ColumnIndex < dataSet.Tables[t].Columns.Count; _ColumnIndex++)
                        {
                            try
                            {
                                object _Value = dataSet.Tables[t].Rows[_RowIndex][_ColumnIndex];
                                if (_Value is DBNull)
                                {
                                    dataGrid.Rows[_RowIndex].Cells[_ColumnIndex].Value = "NULL";
                                }
                                else if (_Value is byte[])
                                {
                                    string _HexValue = "0x";
                                    byte[] _BinaryValue = (byte[])_Value;
                                    for (int i = 0; i < _BinaryValue.Length; i++)
                                    {
                                        _HexValue += _BinaryValue[i].ToString("X2");
                                    }
                                    dataGrid.Rows[_RowIndex].Cells[_ColumnIndex].Value = _HexValue;
                                }
                                else
                                {
                                    dataGrid.Rows[_RowIndex].Cells[_ColumnIndex].Value = dataSet.Tables[t].Rows[_RowIndex][_ColumnIndex];
                                    dataGrid.Rows[_RowIndex].Cells[_ColumnIndex].ValueType = dataSet.Tables[t].Rows[_RowIndex][_ColumnIndex].GetType();
                                }
                            }
                            catch (Exception e)
                            {
                                dataGrid.Rows[_RowIndex].Cells[_ColumnIndex].Value = Helpers.GetCombinedExceptionText(e);
                            }
                        }
                    }

                    // bind grid
                    //dataGrid.DataSource = dataSet;
                    //dataGrid.DataMember = dataSet.Tables[t].TableName;

                }
                catch (Exception ex)
                {
                    Messaging.ShowException("Error occurred building Combined Results tab.", ex);

                    CoreGlobals.traceLog.ErrorFormat("Error creating results set grid {0} for table {1} ", ex.Message, t);
                }
            }
        }

        private void
          CreateResultMessageArea(
             DevComponents.DotNetBar.TabControl tabControl,
             string message,
             int serverIndex
          )
        {
            tabControl.SuspendLayout();

            // add message tab
            DevComponents.DotNetBar.TabControlPanel tabControlPanel = new DevComponents.DotNetBar.TabControlPanel();
            DevComponents.DotNetBar.TabItem tabItem = new DevComponents.DotNetBar.TabItem(this.components);

            // text box to hold messages
            DevComponents.DotNetBar.Controls.TextBoxX textMessage = new DevComponents.DotNetBar.Controls.TextBoxX();
            textMessage.BackColor = System.Drawing.Color.White;
            textMessage.Border.Class = "TextBoxBorder";
            textMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            textMessage.Location = new System.Drawing.Point(1, 1);
            textMessage.Multiline = true;
            textMessage.Name = String.Format("textMessage{0}", serverIndex);
            textMessage.ReadOnly = true;
            textMessage.TabIndex = 0;
            textMessage.Text = message;
            textMessage.ContextMenuStrip = contextMenuResults;
            textMessage.ScrollBars = ScrollBars.Both;
            textMessage.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textMessage.WordWrap = false;

            // create tabcontrolpanel
            tabControlPanel.Controls.Add(textMessage);
            tabControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlPanel.Location = new System.Drawing.Point(0, 22);
            tabControlPanel.Name = String.Format("tabControlPanel-{0}-m", serverIndex);
            tabControlPanel.Padding = new System.Windows.Forms.Padding(1);
            tabControlPanel.Size = new System.Drawing.Size(502, 211);
            tabControlPanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            tabControlPanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            tabControlPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            tabControlPanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            tabControlPanel.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            tabControlPanel.Style.GradientAngle = 90;
            tabControlPanel.TabIndex = 1;
            tabControlPanel.TabItem = tabItem;

            // create tab
            tabItem.AttachedControl = tabControlPanel;
            tabItem.Name = String.Format("tabItem-{0}-m", serverIndex);
            tabItem.Text = String.Format("Message");

            // add panel and tab to tab control
            tabControl.Controls.Add(tabControlPanel);
            tabControl.Tabs.Add(tabItem);

            tabControl.ResumeLayout();
        }

        #region Create UI Pieces

        private DevComponents.DotNetBar.TabControl CreateTabControl(int serverIndex)
        {
            // create tabControl
            DevComponents.DotNetBar.TabControl tabControl = new DevComponents.DotNetBar.TabControl();
            tabControl.BackColor = System.Drawing.Color.Transparent;
            tabControl.CanReorderTabs = true;
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl.Location = new System.Drawing.Point(0, 0);
            tabControl.Name = String.Format("tabControl-{0}", serverIndex);
            tabControl.SelectedTabFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tabControl.Size = new System.Drawing.Size(502, 233);
            tabControl.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            tabControl.TabIndex = 0;
            tabControl.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            tabControl.Text = String.Format("tabControl-{0}", serverIndex);

            return tabControl;
        }

        private System.Windows.Forms.DataGridViewCellStyle CreateDataGridViewCellStyle()
        {
            // Create style to use on all result grids
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;

            return dataGridViewCellStyle;
        }

        private DevComponents.DotNetBar.Controls.DataGridViewX
           CreateDataGrid(
              int serverIndex,
              int tableIndex,
              System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle
           )
        {
            DevComponents.DotNetBar.Controls.DataGridViewX dataGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            ((System.ComponentModel.ISupportInitialize)(dataGrid)).BeginInit();
            dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.DefaultCellStyle = dataGridViewCellStyle;
            dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            dataGrid.Location = new System.Drawing.Point(1, 1);
            dataGrid.Name = String.Format("dataGrid-{0}-{1}", serverIndex, tableIndex);
            dataGrid.Size = new System.Drawing.Size(500, 209);
            dataGrid.TabIndex = 0;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.ReadOnly = true;
            dataGrid.ShowCellErrors = false;
            dataGrid.ShowRowErrors = false;
            dataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(datagrid_DataError);
            ((System.ComponentModel.ISupportInitialize)(dataGrid)).EndInit();

            return dataGrid;
        }

        private DevComponents.DotNetBar.TabControlPanel
           CreateTabControlPanel(
              int serverIndex,
              int tableIndex,
              DevComponents.DotNetBar.Controls.DataGridViewX dataGrid
           )
        {
            // create tabcontrolpanel
            DevComponents.DotNetBar.TabControlPanel tabControlPanel = new DevComponents.DotNetBar.TabControlPanel();
            tabControlPanel.Controls.Add(dataGrid);
            tabControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlPanel.Location = new System.Drawing.Point(0, 22);
            tabControlPanel.Name = String.Format("tabControlPanel-{0}-{1}", serverIndex, tableIndex);
            tabControlPanel.Padding = new System.Windows.Forms.Padding(1);
            tabControlPanel.Size = new System.Drawing.Size(502, 211);
            tabControlPanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            tabControlPanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            tabControlPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            tabControlPanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            tabControlPanel.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            tabControlPanel.Style.GradientAngle = 90;
            tabControlPanel.TabIndex = 1;

            return tabControlPanel;
        }

        #endregion

        private void datagrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }


        private void
           DeleteTabContents(
              DevComponents.DotNetBar.TabItem ownerTab
           )
        {
            if (ownerTab.AttachedControl.Controls[0].Controls.Count == 0) return;

            // possible tabs - text area for messages or tab control for mixed message and grid
            if ((!ownerTab.AttachedControl.Controls[0].Controls[0].Name.StartsWith("text")) && (ownerTab.AttachedControl.Controls[0].Controls[0] is DevComponents.DotNetBar.TabControl))
            {
                // have to hand delete tabs since they are no in the controls list of the tab control
                while (((DevComponents.DotNetBar.TabControl)ownerTab.AttachedControl.Controls[0].Controls[0]).Tabs.Count != 0)
                {
                    ((DevComponents.DotNetBar.TabControlPanel)((DevComponents.DotNetBar.TabControl)ownerTab.AttachedControl.Controls[0].Controls[0]).Tabs[0].AttachedControl).TabItem.Dispose();
                    ((DevComponents.DotNetBar.TabControl)ownerTab.AttachedControl.Controls[0].Controls[0]).Tabs[0].AttachedControl.Dispose();

                }
                while (((DevComponents.DotNetBar.TabControl)ownerTab.AttachedControl.Controls[0].Controls[0]).Tabs.Count != 0)
                {
                    ((DevComponents.DotNetBar.TabControl)ownerTab.AttachedControl.Controls[0].Controls[0]).Tabs[0].Dispose();
                    ((DevComponents.DotNetBar.TabControl)ownerTab.AttachedControl.Controls[0].Controls[0]).Tabs.RemoveAt(0);
                }
               ((DevComponents.DotNetBar.TabControl)ownerTab.AttachedControl.Controls[0].Controls[0]).Tabs.Clear();

            }

            ownerTab.AttachedControl.Controls[0].Controls.Clear();
        }

        #endregion

        private void dataGridSummary_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tabControlResults.SelectedTab = tabControlResults.Tabs[e.RowIndex];
            }
        }

        #region Save Results As CSV

        private void contextSaveAsCSV_Click(object sender, EventArgs e)
        {
            string fileName = String.Format("MultiQuery ({0})", tabControlResults.SelectedTab.Text);

            // summary
            if (tabControlResults.SelectedTab == tabItemSummary)
            {
                ExportToCSV.CopyDataGridView(fileName, dataGridSummary);
            }
            // combined or individual server
            else
            {
                DevComponents.DotNetBar.TabControlPanel mainPanel = (DevComponents.DotNetBar.TabControlPanel)tabControlResults.SelectedTab.AttachedControl;

                if (!mainPanel.Controls[0].Controls[0].Name.StartsWith("text"))
                {
                    DevComponents.DotNetBar.TabControl childTabControl = (DevComponents.DotNetBar.TabControl)mainPanel.Controls[0].Controls[0];

                    if (childTabControl.SelectedTab.Text != "Message")
                    {
                        ExportToCSV.CopyDataGridView(
                            fileName,
                            (DevComponents.DotNetBar.Controls.DataGridViewX)(childTabControl.SelectedTab.AttachedControl.Controls[0]));
                    }
                }
            }
        }

        private void contextSaveAsXML_Click(object sender, EventArgs e)
        {
            string fileName = String.Format("MultiQuery ({0})", tabControlResults.SelectedTab.Text);

            // summary
            if (tabControlResults.SelectedTab == tabItemSummary)
            {
                ExportToXML.CopyDataGridView(fileName, dataGridSummary, tabControlResults.SelectedTab.Text);
            }
            // combined or individual server
            else
            {
                DevComponents.DotNetBar.TabControlPanel mainPanel = (DevComponents.DotNetBar.TabControlPanel)tabControlResults.SelectedTab.AttachedControl;

                if (!mainPanel.Controls[0].Controls[0].Name.StartsWith("text"))
                {
                    DevComponents.DotNetBar.TabControl childTabControl = (DevComponents.DotNetBar.TabControl)mainPanel.Controls[0].Controls[0];

                    if (childTabControl.SelectedTab.Text != "Message")
                    {
                        ExportToXML.CopyDataGridView(
                            fileName,
                            (DevComponents.DotNetBar.Controls.DataGridViewX)(childTabControl.SelectedTab.AttachedControl.Controls[0]),
                            tabControlResults.SelectedTab.Text);
                    }
                }
            }
        }


        #endregion

        #region Copy to Clipboard

        private void contextResultsCopy_Click(object sender, EventArgs e)
        {
            // summary
            if (tabControlResults.SelectedTab == tabItemSummary)
            {
                ExportToClipboard.CopyDataGridViewToTabbedFormat(dataGridSummary, false);
            }
            // combined or individual server
            else
            {
                DevComponents.DotNetBar.TabControlPanel mainPanel = (DevComponents.DotNetBar.TabControlPanel)tabControlResults.SelectedTab.AttachedControl;

                if (mainPanel.Controls[0].Controls[0].Name.StartsWith("text"))
                {
                    StringBuilder sb = new StringBuilder(1024);

                    sb.AppendFormat("{0}\r\n\r\n", tabControlResults.SelectedTab.Text);
                    sb.Append(((DevComponents.DotNetBar.Controls.TextBoxX)mainPanel.Controls[0].Controls[0]).Text);

                    Clipboard.SetDataObject(sb.ToString());
                }
                else
                {
                    DevComponents.DotNetBar.TabControl childTabControl = (DevComponents.DotNetBar.TabControl)mainPanel.Controls[0].Controls[0];

                    StringBuilder sb = new StringBuilder(1024);
                    sb.AppendFormat("{0}\r\n", tabControlResults.SelectedTab.Text);
                    sb.AppendFormat("{0}\r\n\r\n", childTabControl.SelectedTab.Text);

                    if (childTabControl.SelectedTab.Text == "Message")
                    {
                        sb.Append(((DevComponents.DotNetBar.Controls.TextBoxX)(childTabControl.SelectedTab.AttachedControl.Controls[0])).Text);
                    }
                    else
                    {
                        sb.Append(ExportToClipboard.GetDataGridViewInTabbedFormat(
                            (DevComponents.DotNetBar.Controls.DataGridViewX)(childTabControl.SelectedTab.AttachedControl.Controls[0]),
                            false));
                    }
                    Clipboard.SetDataObject(sb.ToString());
                }
            }
        }

        #endregion

        private void contextMenuResults_Opening(object sender, CancelEventArgs e)
        {
            bool haveGrid = false;

            // Do we have one of the following:
            // main tab = summary
            // child tab contains grid
            if (tabControlResults.SelectedTab == tabItemSummary)
            {
                haveGrid = true;
            }
            else
            {
                DevComponents.DotNetBar.TabControlPanel mainPanel = (DevComponents.DotNetBar.TabControlPanel)tabControlResults.SelectedTab.AttachedControl;

                if (!mainPanel.Controls[0].Controls[0].Name.StartsWith("text"))
                {
                    if (((DevComponents.DotNetBar.TabControl)mainPanel.Controls[0].Controls[0]).SelectedTab.Text != "Message")
                    {
                        haveGrid = true;
                    }
                }
            }

            contextResultsSave.Enabled = haveGrid;
        }

        #region Full Screen

        private bool m_fullScreenMode = false;
        private FormWindowState m_saveWindowState;

        private void contextMenuFullScreen_Click(object sender, EventArgs e)
        {
            ToggleFullScreen();
        }

        private void buttonFullScreen_Click(object sender, EventArgs e)
        {
            ToggleFullScreen();
        }

        private void ToggleFullScreen()
        {
            if (!m_fullScreenMode)
            {
                // hide other panels
                m_saveWindowState = this.WindowState;
                this.WindowState = FormWindowState.Maximized;

                if (!headerCollapsed) panelTop.Hide();
                navQueryTargets.Hide();
                splitContainer1.Panel1Collapsed = true;
                contextMenuFullScreen.Text =
                buttonFullScreen.Text = "Turn off Full Screen mode";
            }
            else
            {
                // restore other panels
                if (!headerCollapsed) panelTop.Show();
                navQueryTargets.Show();
                splitContainer1.Panel1Collapsed = false;
                contextMenuFullScreen.Text =
                buttonFullScreen.Text = "Full Screen";

                this.WindowState = m_saveWindowState;
            }
            m_fullScreenMode = !m_fullScreenMode;
        }

        #endregion

        private void menuCut_Click(object sender, EventArgs e)
        {
            if (textSQL.Focused)
            {
                textSQL.Selection.Cut();
            }
            else if (tabControlResults.Focused)
            {
                textSQL.Selection.Cut();
            }
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            if (textSQL.Focused)
            {
                textSQL.Selection.Copy();
            }
        }

        private void menuPaste_Click(object sender, EventArgs e)
        {
            if (textSQL.Focused)
            {
                textSQL.Selection.Paste();
            }
        }

        private void menuSelectAll_Click(object sender, EventArgs e)
        {
            if (textSQL.Focused)
            {
                textSQL.Selection.SelectAll();
            }
            else if (listQueryTargets.Focused)
            {
                foreach (ListViewItem lvi in listQueryTargets.Items)
                {
                    lvi.Selected = true;
                }
            }
        }

        private void contextMenuEditorOptions_Click(object sender, EventArgs e)
        {
            SetEditorOptions();
        }

        private void buttonEditorOptions_Click(object sender, EventArgs e)
        {
            SetEditorOptions();
        }

        private void SetEditorOptions()
        {
            Form_EditOptions frm = new Form_EditOptions();
            DialogResult choice = frm.ShowDialog();
            if (choice == DialogResult.OK)
            {
                // reset properties on edit control
                if (ProductConstants.optionsShowSyntaxErrors)
                    this.mssqlParser1.Options = QWhale.Syntax.SyntaxOptions.SyntaxErrors;
                else
                    this.mssqlParser1.Options = QWhale.Syntax.SyntaxOptions.None;

                this.mssqlParser1.ReparseText();

                textSQL.DisableSyntaxPaint = !ProductConstants.optionsShowSyntaxColor;
                textSQL.WordWrap = ProductConstants.optionsShowWordWrap;

                this.textSQL.Gutter.Options = (QWhale.Editor.GutterOptions)(QWhale.Editor.GutterOptions.PaintBookMarks);
                if (ProductConstants.optionsShowLineNumbers)
                    this.textSQL.Gutter.Options |= (QWhale.Editor.GutterOptions)(QWhale.Editor.GutterOptions.PaintLineNumbers);
                if (ProductConstants.optionsShowModifiedLines)
                    this.textSQL.Gutter.Options |= (QWhale.Editor.GutterOptions)(QWhale.Editor.GutterOptions.PaintLineModificators);
            }
        }

        private void contextCreateNewQueryTargetFile_Click(object sender, EventArgs e)
        {
            if (!CheckForDirtyQueryTarget()) return;

            listQueryTargets.Items.Clear();
            SetQueryTargetFile(false, "<Untitled>");
            MarkQueryTargetDirty(false);
        }

        private void ShowF1Help(object sender, HelpEventArgs hlpevent)
        {
            HelpMenu.ShowHelp(ProductConstants.productHelpTopic);
        }


        private void AddFileToRecentFileList(string fullPath)
        {
            m_recentFiles.AddItem(Path.GetFileName(fullPath), fullPath);
            m_recentFiles.Write(ProductConstants.RegistryValue_RecentFiles, true);

            LoadRecentFileList();
        }

        private void LoadRecentFileList()
        {
            buttonRecentQueries.SubItems.Clear();

            if (m_recentFiles.Count != 0)
            {
                buttonRecentQueries.Enabled = true;

                for (int i = 0; i < m_recentFiles.Count; i++)
                {
                    AddRecentFileButton(i, m_recentFiles.Tags[i].ToString());
                }
            }
            else
            {
                AddRecentFileButton(0, "fake");
                buttonRecentQueries.Enabled = false;
            }
        }

        private void AddRecentFileButton(int i, string fullPath)
        {
            DevComponents.DotNetBar.ButtonItem newButton = new DevComponents.DotNetBar.ButtonItem();
            newButton.Name = "buttonItem" + i.ToString();
            newButton.Text = String.Format("{0}. {1}", i + 1, Path.GetFileName(fullPath));
            newButton.Tooltip = fullPath;
            newButton.Tag = fullPath;
            newButton.Click += new System.EventHandler(buttonRecentQuery_Click);

            buttonRecentQueries.SubItems.Add(newButton);
        }

        private void buttonRecentQuery_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonItem button = (DevComponents.DotNetBar.ButtonItem)sender;

            string fullPath = (string)button.Tag;

            // are we reloading same file? if it is dirty its ok since we will ask if they want to save before reloading
            // otherwise do nothing since its the same file
            if (!ProductConstants.QueryDirty &&
                   ProductConstants.QueryIsFile &&
                   ProductConstants.QueryFile == fullPath)
            {
                return;
            }

            OpenQuery(fullPath);

            textSQL.Select();
        }

        private void SetQueryDirectory(string fileName)
        {
            string newPath = Path.GetDirectoryName(fileName);
            if (newPath != ProductConstants.optionsQueryDirectory)
            {
                ProductConstants.optionsQueryDirectory = newPath;
                ProductConstants.WriteOptions();
            }
        }

        private void menuHelp_Click(object sender, EventArgs e)
        {

            base.OnClick(e);
        }

        private void ideraTitleBar1_Load(object sender, EventArgs e)
        {

        }

        private void ideraTitleBar1_LicenseInfoButtonClick(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }
    }
}
