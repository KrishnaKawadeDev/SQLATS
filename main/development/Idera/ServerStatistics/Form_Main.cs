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
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;
using System.Xml;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.ServerStatistics
{
    public partial class Form_Main : Form
    {
        private ToolProgressBarDialog _ProgressDialog;
        bool _IgnoreExpandEvent = false;

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

       private void ShowF1Help(object sender, HelpEventArgs hlpevent)
       {
          HelpMenu.ShowHelp();
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
        JobPool<StatisticalData> _JobPool;
        private static Dictionary<string, string> _ErrorReports = new Dictionary<string, string>();

        private void buttonGetResults_Click(object sender, EventArgs e)
        {
            // Validation
            if (serverSelection.Text.Trim().Length == 0)
            {
                Core.Messaging.ShowError("Specify a SQL Server instance name.");
                serverSelection.Select();
                return;
            }

            // save item to persisted MRU list
            MRU.AddServerOrGroup(serverSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server,
                                 serverSelection.Text,
                                 serverSelection.SqlCredentials);

            _JobPool = new JobPool<StatisticalData>(5);
            _JobPool.ServerTaskComplete += new EventHandler<JobExecutionResultsEventArgs>(JobPool_ServerTaskComplete);
            _JobPool.TaskComplete += new EventHandler<JobExecutionEventArgs>(JobPool_TaskComplete);

            ProgressBar_Initialize();

            treeCategories.Nodes.Clear();
            listDetails.Clear();
            menuExport.Enabled = false;
            _JobPool.Enqueue(StatisticsHelper.GetServerNode, serverSelection.ServerList, ToolsetOptions.commandTimeout);
            _JobPool.StartAsync();

            ProgressBar_Show();
        }

        DevComponents.AdvTree.Node AddDataToTree(DevComponents.AdvTree.NodeCollection nodes, StatisticalData data, bool expand, bool addToCollection)
        {
            DevComponents.AdvTree.Node _Node = null;
            foreach (DevComponents.AdvTree.Node _Item in nodes)
            {
                if (_Item.Name == data.Name)
                {
                    _Node = _Item;
                    break;
                }
            }

            if (_Node == null)
            {
                _Node = new DevComponents.AdvTree.Node();
                _Node.Text = _Node.Name = data.Name;

                if (data.IconImage != NodeIcon.None)
                {
                    _Node.ImageIndex = (int)data.IconImage;
                }
                if (addToCollection)
                {
                    nodes.Add(_Node);
                }
            }
            _Node.Tag = data;

            if (data.DataException == null)
            {
                if (data.ShowCount && _Node.Text == _Node.Name)  //Item count hasn't been attached
                {
                    _Node.Text = string.Format("{0} ({1})", _Node.Name, data.ItemCount);
                }
                if ((nodes.ParentNode == null && treeCategories.Nodes.Count == 1) || (expand && data.ChildData.Count > 0))
                {
                    _Node.Expanded = true;
                }
                if (data.Type == DataType.Rollup || data.Type == DataType.RawDataGroup || data.ChildData.Count > 0)
                {
                    _Node.ExpandVisibility = DevComponents.AdvTree.eNodeExpandVisibility.Visible;
                }
                if ((data.IsDataLoaded && data.ChildData.Count > 0) || data.Type == DataType.Rollup)
                {
                    foreach (StatisticalData _Data in data.ChildData)
                    {
                        AddDataToTree(_Node.Nodes, _Data, expand, true);
                    }
                }
            }
            return _Node;
        }


        #region Job Pool
        void JobPool_ServerTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            if (e.Status == TaskStatus.Success)
            {
                StatisticalData _ServerData = (StatisticalData)e.Resultset;
                AddDataToTree(treeCategories.Nodes, _ServerData, false, true);

                menuExport.Enabled = true;
            }
            else
            {
                _ErrorReports.Add(e.Server.Name, e.ErrorMessage);
            }
        }

        void JobPool_TaskComplete(object sender, JobExecutionEventArgs e)
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

                _ErrorReports.Clear();
            }
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

        public void ProgressBar_Initialize()
        {
            _ProgressDialog = new ToolProgressBarDialog();
            _ProgressDialog.OperationText = "Loading Server Statistics...";
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

        #region Control Events
        private void listDetails_DoubleClick(object sender, EventArgs e)
        {
            if (listDetails.SelectedItems.Count > 0 && listDetails.SelectedItems[0].Tag != null)
            {
                StatisticalData _Data = listDetails.SelectedItems[0].Tag as StatisticalData;
                if (_Data != null)
                {
                    foreach (DevComponents.AdvTree.Node _Node in treeCategories.SelectedNode.Nodes)
                    {
                        if (_Node.Text == _Data.Name)
                        {
                            treeCategories.SelectNode(_Node, DevComponents.AdvTree.eTreeAction.Mouse);
                            return;
                        }
                    }
                }
            }
        }

        private void treeCategories_BeforeExpand(object sender, DevComponents.AdvTree.AdvTreeNodeCancelEventArgs e)
        {
            if (!_IgnoreExpandEvent)
            {
                Cursor = Cursors.WaitCursor;
                LoadTreeNode(e.Node, false);
                Cursor = Cursors.Default;
            }
        }

        private void LoadTreeNode(DevComponents.AdvTree.Node node, bool expand)
        {
            if (node.Tag != null)
            {
                StatisticalData _Data = node.Tag as StatisticalData;
                if (_Data != null)
                {
                    if (!_Data.IsDataLoaded)
                    {
                        StatisticsHelper.PopulateStatistics(_Data);
                    }
                    if (_Data.ChildData.Count > 0)
                    {
                        foreach (StatisticalData _ChildData in _Data.ChildData)
                        {
                            AddDataToTree(node.Nodes, _ChildData, expand, true);
                        }
                    }
                }
            }
        }

        DevComponents.AdvTree.Node _SelectedNode = null;
        private void treeCategories_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                listDetails.BeginUpdate();
                if (e.Node != null && e.Node != _SelectedNode)
                {
                    _SelectedNode = e.Node;
                    listDetails.Visible = false;  //to stop jumpy visual behavior

                    listDetails.Columns.Clear();
                    listDetails.ListViewItemSorter = new ListViewItemComparer(0, System.Windows.Forms.SortOrder.Ascending);//reset sorting
                    listDetails.Clear();
                    if (e.Node.Tag != null)
                    {
                        StatisticalData _Data = e.Node.Tag as StatisticalData;
                        if (_Data != null)
                        {
                            if (!_Data.IsDataLoaded)
                            {
                                LoadTreeNode(e.Node, false);
                            }
                            if (_Data.DataException == null)
                            {
                                if (_Data.Type == DataType.RawData)
                                {
                                    foreach (StatisticsHeader _ColumnHeader in _Data.DetailNames)
                                    {
                                        ColumnHeader _Column = listDetails.Columns.Add(_ColumnHeader, _ColumnHeader);
                                        _Column.TextAlign = _ColumnHeader.TextAlign;
                                        _Column.Tag = _ColumnHeader;
                                    }

                                    foreach (DataRow _Row in _Data.Values.Rows)
                                    {
                                        ListViewItem _Item = new ListViewItem(_Row[0].ToString());
                                        _Item.SubItems[0].Tag = _Row[0];
                                        for (int i = 1; i < _Row.Table.Columns.Count; i++)
                                        {
                                            _Item.SubItems.Add(_Row[i].ToString()).Tag = _Row[i];
                                        }
                                        if (_Data.DetailIconImage != NodeIcon.None)
                                        {
                                            _Item.ImageIndex = (int)_Data.DetailIconImage;
                                        }
                                        else
                                        {
                                            _Item.ImageIndex = e.Node.ImageIndex;
                                        }
                                        listDetails.Items.Add(_Item);
                                    }

                                    if (listDetails.Columns.ContainsKey("Urn"))
                                    {
                                        int _Index = listDetails.Columns["Urn"].Index;
                                        listDetails.Columns.RemoveAt(_Index);
                                        foreach (ListViewItem _UrnItem in listDetails.Items)
                                        {
                                            _UrnItem.SubItems.RemoveAt(_Index);
                                        }
                                    }
                                }
                                else
                                {
                                    listDetails.Columns.Add("Name");
                                    ColumnHeader _CountColumn = listDetails.Columns.Add("Count");
                                    _CountColumn.TextAlign = HorizontalAlignment.Center;
                                    bool _IsCountColumnUsed = false;
                                    foreach (StatisticalData _ChildData in _Data.ChildData)
                                    {
                                        ListViewItem _Item = listDetails.Items.Add(_ChildData.Name);
                                        if (_ChildData.ShowCount)
                                        {
                                            _Item.SubItems.Add(_ChildData.ItemCount.ToString());
                                            _IsCountColumnUsed = true;
                                        }
                                        _Item.ImageIndex = (int)_ChildData.IconImage;
                                        _Item.Tag = _ChildData;
                                    }
                                    if(!_IsCountColumnUsed)
                                    {
                                        listDetails.Columns.Remove(_CountColumn);
                                    }
                                }
                            }
                            else
                            {
                                ColumnHeader _Column = listDetails.Columns.Add("Error");
                                _Column.TextAlign = HorizontalAlignment.Center;
                                ListViewItem _Item = new ListViewItem(Helpers.GetCombinedExceptionText(_Data.DataException));
                                if (_Data.DetailIconImage != NodeIcon.None)
                                {
                                    _Item.ImageIndex = (int)_Data.DetailIconImage;
                                }
                                listDetails.Items.Add(_Item);
                            }
                        }
                    }
                    else if (e.Node.HasChildNodes)
                    {
                        listDetails.Columns.Add("Name");
                        ColumnHeader _CountColumn = listDetails.Columns.Add("Count");
                        _CountColumn.TextAlign = HorizontalAlignment.Center;
                        foreach (DevComponents.AdvTree.Node _ChildNode in e.Node.Nodes)
                        {
                            StatisticalData _ChildData = _ChildNode.Tag as StatisticalData;
                            ListViewItem _Item = listDetails.Items.Add(_ChildData.Name);
                            _Item.SubItems.Add(_ChildData.ItemCount.ToString());
                            _Item.ImageIndex = _ChildNode.ImageIndex;
                            _Item.Tag = _ChildNode;
                        }
                    }

                    //Dummy so that the last column resizes correctly
                    listDetails.Columns.Add(string.Empty);

                    for (int i = 0; i < listDetails.Columns.Count; i++)
                    {
                        ColumnHeader _Column = listDetails.Columns[i];

                        _Column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                        int _ColumnSize = _Column.Width;
                        _Column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        if (_Column.Width < _ColumnSize)
                        {
                            _Column.Width = _ColumnSize;
                        }

                        _Column.Width += 10;

                        if (_Column.Width > 250 && listDetails.Columns.Count > 2)
                        {
                            _Column.Width = 250;
                        }
                    }
                    //remove dummy
                    listDetails.Columns.RemoveAt(listDetails.Columns.Count - 1);
                    listDetails.Visible = true;
                }
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Display Details", exc);
            }
            finally
            {
                listDetails.EndUpdate();
                Cursor = Cursors.Default;
            }
        }

        private void toolStripMenuExpand_Click(object sender, EventArgs e)
        {
            if (treeCategories.SelectedNode == null)
            {
                Messaging.ShowError(ProductConstants.ErrorExpandCollapseSelectNode);
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                _IgnoreExpandEvent = true;
                StatisticalData _Data = treeCategories.SelectedNode.Tag as StatisticalData;
                if (_Data != null)
                {
                    StatisticsHelper.PopulateStatisticsTree(_Data, 1);
                    LoadTreeNode(treeCategories.SelectedNode, true);
                    treeCategories.SelectedNode.Expand();
                    foreach (DevComponents.AdvTree.Node _ChildNode in treeCategories.SelectedNode.Nodes)
                    {
                        _ChildNode.Expand();
                    }
                }
                _IgnoreExpandEvent = false;
                Cursor = Cursors.Default;
            }
        }

        private void MenuExpand_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            _IgnoreExpandEvent = true;
            foreach (DevComponents.AdvTree.Node _Node in treeCategories.Nodes)
            {
                StatisticalData _Data = _Node.Tag as StatisticalData;
                if (_Data != null)
                {
                    StatisticsHelper.PopulateStatisticsTree(_Data, 1);
                    LoadTreeNode(_Node, true);
                    _Node.Expand();
                    foreach (DevComponents.AdvTree.Node _ChildNode in _Node.Nodes)
                    {
                        _ChildNode.Expand();
                    }
                }
            }
            _IgnoreExpandEvent = false;
            Cursor = Cursors.Default;
        }

        private void toolStripMenuCollapse_Click(object sender, EventArgs e)
        {
            if (treeCategories.SelectedNode == null)
            {
                Messaging.ShowError(ProductConstants.ErrorExpandCollapseSelectNode);
            }
            else
            {
                treeCategories.SelectedNode.CollapseAll();
                treeCategories.SelectedNode.Collapse();
            }
        }

        private void MenuCollapse_Click(object sender, EventArgs e)
        {
            foreach (DevComponents.AdvTree.Node _Node in treeCategories.Nodes)
            {
                _Node.CollapseAll();
                _Node.Collapse();
            }
        }

        private void contextMenuTree_Opening(object sender, CancelEventArgs e)
        {
            if (treeCategories.SelectedNode == null)
            {
                e.Cancel = true;
                return;
            }
        }

        private void RefreshData(object sender, EventArgs e)
        {
            if (treeCategories.SelectedNode == null)
            {
                return;
            }
            RefreshData(treeCategories.SelectedNode);
        }

        private void RefreshData(DevComponents.AdvTree.Node refreshedNode)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            try
            {
                treeCategories.BeginUpdate();
               
                DevComponents.AdvTree.Node _ParentNode = refreshedNode.Parent;
                StatisticalData _Data = refreshedNode.Tag as StatisticalData;
                if (_Data != null)
                {
                    StatisticsHelper.RefreshStatisticsTree(_Data);
                    int _NodeIndex = refreshedNode.Index;
                    if (_ParentNode == null)
                    {
                        treeCategories.Nodes.Remove(refreshedNode);
                    }
                    else
                    {
                        _ParentNode.Nodes.Remove(refreshedNode);
                    }

                    DevComponents.AdvTree.Node _NewNode = AddDataToTree(refreshedNode.Nodes, _Data, refreshedNode.Expanded, false);
                    if (_ParentNode == null)
                    {
                        treeCategories.Nodes.Insert(_NodeIndex, _NewNode);
                    }
                    else
                    {
                        _ParentNode.Nodes.Insert(_NodeIndex, _NewNode);
                    }
                    treeCategories.SelectedNode = _NewNode;
                }
            }
            catch (Exception ex)
            {
                Messaging.ShowError(Helpers.GetCombinedExceptionText(ex), "Error refreshing data");
            }
            finally
            {
               treeCategories.EndUpdate();
            }
            Cursor = Cursors.Default;
        }
        #endregion

        #region Column Sorting

        private int sortColumn = -1;
        private System.Windows.Forms.SortOrder sortOrder = System.Windows.Forms.SortOrder.Ascending;

        private void listDetails_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;

                // Set the sort order to ascending by default.
                listDetails.Sorting = sortOrder;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listDetails.Sorting == System.Windows.Forms.SortOrder.Ascending)
                    listDetails.Sorting = System.Windows.Forms.SortOrder.Descending;
                else
                    listDetails.Sorting = System.Windows.Forms.SortOrder.Ascending;
            }

            StatisticsHeader _Header = listDetails.Columns[e.Column].Tag as StatisticsHeader;
            listDetails.ListViewItemSorter = new ListViewItemComparer(e.Column, listDetails.Sorting, _Header);
            
            listDetails.Sort();
        }

        // Implements the manual sorting of items by column.
        class ListViewItemComparer : IComparer
        {
            private int col;
            private System.Windows.Forms.SortOrder order;
            StatisticsHeader _Header;

            public ListViewItemComparer(int column, System.Windows.Forms.SortOrder order)
            {
                col = column;
                this.order = order;
            }

            public ListViewItemComparer(int column, System.Windows.Forms.SortOrder order, StatisticsHeader header) : this(column, order)
            {
                _Header = header;
            }

            public int Compare(object x, object y)
            {
                int returnVal = 0;
                if (col < ((ListViewItem)x).ListView.Columns.Count)
                {
                    if (_Header == null)
                    {
                        if (col == 1) //Count column
                        {
                            returnVal = Helpers.CompareInt(int.Parse(((ListViewItem)x).SubItems[col].Text), int.Parse(((ListViewItem)y).SubItems[col].Text));
                        }
                        else
                        {
                            returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                                                   ((ListViewItem)y).SubItems[col].Text);
                        }
                    }
                    else
                    {
                        switch (_Header.DataType)
                        {
                            case HeaderType.IntValue:
                                DataValue<int> _IntValue1 = ((ListViewItem)x).SubItems[col].Tag as DataValue<int>;
                                DataValue<int> _IntValue2 = ((ListViewItem)y).SubItems[col].Tag as DataValue<int>;
                                returnVal = Helpers.CompareInt((_IntValue1 == null) ? int.MinValue : _IntValue1.Value,
                                    (_IntValue2 == null) ? int.MinValue : _IntValue2.Value);
                                break;
                            case HeaderType.DoubleValue:
                                DataValue<double> _DoubleValue1 = ((ListViewItem)x).SubItems[col].Tag as DataValue<double>;
                                DataValue<double> _DoubleValue2 = ((ListViewItem)y).SubItems[col].Tag as DataValue<double>;
                                returnVal = Helpers.CompareDouble((_DoubleValue1 == null) ? double.MinValue : _DoubleValue1.Value,
                                    (_DoubleValue2 == null) ? double.MinValue : _DoubleValue2.Value);
                                break;
                            case HeaderType.DateValue:
                                DataValue<DateTime> _DateValue1 = ((ListViewItem)x).SubItems[col].Tag as DataValue<DateTime>;
                                DataValue<DateTime> _DateValue2 = ((ListViewItem)y).SubItems[col].Tag as DataValue<DateTime>;
                                returnVal = DateTime.Compare((_DateValue1 == null) ? DateTime.MinValue : _DateValue1.Value,
                                    (_DateValue2 == null) ? DateTime.MinValue : _DateValue2.Value);
                                break;
                            case HeaderType.StringValue:
                                DataValue<string> _StringValue1 = ((ListViewItem)x).SubItems[col].Tag as DataValue<string>;
                                DataValue<string> _StringValue2 = ((ListViewItem)y).SubItems[col].Tag as DataValue<string>;
                                returnVal = string.Compare((_StringValue1 == null) ? string.Empty : _StringValue1.Value,
                                    (_StringValue2 == null) ? string.Empty : _StringValue2.Value);
                                break;
                        }
                    }
                }

                if (order == System.Windows.Forms.SortOrder.Descending) returnVal *= -1;
                return returnVal;
            }
        }

        #endregion

        #region Clipboard
        private void toolStripMenuCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard(true);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyToClipboard(false);
        }

        private void CopyToClipboard(bool selectedOnly)
        {
            if (listDetails.Columns.Count > 0)
            {
                int[] _ColumnWidths = new int[listDetails.Columns.Count];

                for (int i = 0; i < _ColumnWidths.Length; i++)
                {
                    _ColumnWidths[i] = 35;
                }

                ExportToClipboard.CopyListView(treeCategories.SelectedNode.Text, listDetails, _ColumnWidths, selectedOnly);
            }
        }
        #endregion

        #region Export

        private List<string> GetLoadedServerList()
        {
            List<string> _Servers = new List<string>();
            foreach (DevComponents.AdvTree.Node _Node in treeCategories.Nodes)
            {
                _Servers.Add(_Node.Name);
            }
            return _Servers;
        }

        private void RefreshServers(List<string> serversToRefresh)
        {
            Cursor = Cursors.WaitCursor;
            foreach(string _Server in serversToRefresh)
            {
                DevComponents.AdvTree.Node _ServerNode = treeCategories.FindNodeByName(_Server);
                if (_ServerNode != null && _ServerNode.Tag != null)
                {
                    StatisticalData _Data = _ServerNode.Tag as StatisticalData;
                    LoadDataTree(_Data);
                    //refresh the Perf counter node
                    _ServerNode.Nodes.RemoveAt(_ServerNode.Nodes.Count - 1);
                    AddDataToTree(_ServerNode.Nodes, _Data.ChildData[_Data.ChildData.Count - 1], false, true);
                }   
                LoadTreeNode(_ServerNode, false);
            }
            Cursor = Cursors.Default;
        }

        private void LoadDataTree(StatisticalData data)
        {
            if (data.BulkLoadMethod != null)
            {
                StatisticsHelper.BulkLoadStatistics(data);
            }
            if (!data.IsDataLoaded)
            {
                StatisticsHelper.PopulateStatistics(data);
            }
            if (data.ChildData.Count > 0)
            {
                foreach (StatisticalData _ChildData in data.ChildData)
                {
                    LoadDataTree(_ChildData);
                }
            }
        }

        private void menuExportAsCSV_Click(object sender, EventArgs e)
        {
            try
            {

                Form_ExportOptions _OptionsForm = new Form_ExportOptions(ProductConstants.ExportCommand, GetLoadedServerList());
                if (_OptionsForm.ShowDialog() == DialogResult.OK)
                {
                    SaveFileDialog _FileDialog = new SaveFileDialog();
                    _FileDialog.AddExtension = true;
                    _FileDialog.CheckPathExists = true;
                    _FileDialog.OverwritePrompt = true;
                    _FileDialog.DefaultExt = "csv";
                    _FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    _FileDialog.FileName = CoreGlobals.productName + ".csv";
                    _FileDialog.Filter = "CSV File (Comma Separated Values)(*.csv)|*.csv|All files (*.*)|*.*";

                    if (_FileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (_OptionsForm.RetrieveAllData)
                        {
                            RefreshServers(_OptionsForm.SelectedServers);
                        }

                        StringBuilder _CsvData = new StringBuilder();

                        foreach (string _Server in _OptionsForm.SelectedServers)
                        {
                            DevComponents.AdvTree.Node _Node = treeCategories.FindNodeByName(_Server);
                            if (_Node != null && _Node.Tag != null)
                            {
                                _CsvData.Append(ParseNodeCsv(_Node));
                                _CsvData.Append(Environment.NewLine);
                            }
                        }

                        if (File.Exists(_FileDialog.FileName))
                        {
                            try
                            {
                                File.Delete(_FileDialog.FileName);
                            }
                            catch (Exception ex)
                            {
                                Messaging.ShowError(
                                   String.Format("An error occurred trying to overwrite the existing file.\r\n\r\nError: {0}",
                                                  ex.Message));
                                return; // we cant write so just give up                                 
                            }
                        }

                        using (FileStream _Stream = new FileStream(_FileDialog.FileName, FileMode.Create, FileAccess.Write))
                        using (StreamWriter _Writer = new StreamWriter(_Stream))
                        {
                            _Writer.Write(_CsvData.ToString());
                        }

                        Messaging.ShowInformation("Export completed successfully");
                    }
                }
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Export to CSV", exc);
            }
        }

        private string ParseNodeCsv(DevComponents.AdvTree.Node node)
        {
            StringBuilder _CsvData = new StringBuilder();
            string _TitleLine = node.Name;
            _TitleLine = string.Empty.PadLeft(node.Level, ',') + _TitleLine;
            _CsvData.Append(_TitleLine);
            _CsvData.Append(Environment.NewLine);

            StatisticalData _NodeData = node.Tag as StatisticalData;
            if (_NodeData != null && _NodeData.IsDataLoaded && _NodeData.Type == DataType.RawData && _NodeData.DataException == null)
            {
                string _HeaderLine = string.Empty;
                string _HeaderUnderLine = string.Empty;
                foreach (StatisticsHeader _Header in _NodeData.DetailNames)
                {
                    _HeaderLine += _Header.HeaderText + ",";
                    _HeaderUnderLine += string.Empty.PadRight(_Header.HeaderText.Length, '-') + ",";
                }
                _HeaderLine = _HeaderLine.Remove(_HeaderLine.LastIndexOf(','));
                _HeaderUnderLine = _HeaderUnderLine.Remove(_HeaderUnderLine.LastIndexOf(','));
                _HeaderLine = string.Empty.PadLeft(node.Level, ',') + _HeaderLine;
                _HeaderUnderLine = string.Empty.PadLeft(node.Level, ',') + _HeaderUnderLine;
                _CsvData.Append(_HeaderLine);
                _CsvData.Append(Environment.NewLine);
                _CsvData.Append(_HeaderUnderLine);
                _CsvData.Append(Environment.NewLine);

                foreach (DataRow _DataValues in _NodeData.Values.Rows)
                {
                    string _DataLine = string.Empty;
                    for (int i = 0; i < _DataValues.Table.Columns.Count; i++)
                    {
                        _DataLine += string.Format("\"{0}\"", _DataValues[i].ToString().Trim()) + ",";
                    }
                    _DataLine = _DataLine.Remove(_DataLine.LastIndexOf(','));
                    _DataLine = string.Empty.PadLeft(node.Level, ',') + _DataLine;
                    _CsvData.Append(_DataLine);
                    _CsvData.Append(Environment.NewLine);
                }
            }

            foreach (DevComponents.AdvTree.Node _ChildNode in node.Nodes)
            {
                _CsvData.Append(ParseNodeCsv(_ChildNode));
                _CsvData.Append(Environment.NewLine);
            }
            return _CsvData.ToString();
        }

        private void menuExportAsXML_Click(object sender, EventArgs e)
        {
            try
            {
                 Form_ExportOptions _OptionsForm = new Form_ExportOptions(ProductConstants.ExportCommand, GetLoadedServerList());
                 if (_OptionsForm.ShowDialog() == DialogResult.OK)
                 {
                     SaveFileDialog _FileDialog = new SaveFileDialog();
                     _FileDialog.AddExtension = true;
                     _FileDialog.CheckPathExists = true;
                     _FileDialog.OverwritePrompt = true;
                     _FileDialog.DefaultExt = "xml";
                     _FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                     _FileDialog.FileName = CoreGlobals.productName + ".xml";
                     _FileDialog.Filter = "XML Data(*.xml)|*.xml|All files (*.*)|*.*";

                     if (_FileDialog.ShowDialog() == DialogResult.OK)
                     {
                         if (_OptionsForm.RetrieveAllData)
                         {
                             RefreshServers(_OptionsForm.SelectedServers);
                         }

                         XmlDocument _XmlDocument = new XmlDocument();

                         XmlElement _RootElement = _XmlDocument.CreateElement(ExportToXML.GetSafeXmlString("Server Statistics"));
                         _XmlDocument.AppendChild(_RootElement);

                         foreach (DevComponents.AdvTree.Node _Node in treeCategories.Nodes)
                         {
                             ParseNodeXml(_Node, _RootElement);
                         }
                         _XmlDocument.Save(_FileDialog.FileName);
                     }
                     Messaging.ShowInformation("Export completed successfully");
                 }
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Export to XML", exc);
            }
        }

        private void ParseNodeXml(DevComponents.AdvTree.Node node, XmlElement topElement)
        {
            XmlElement _ChildElement = topElement.OwnerDocument.CreateElement(XmlConvert.EncodeName(ExportToXML.GetSafeXmlString(node.Name)));
            topElement.AppendChild(_ChildElement);

            StatisticalData _NodeData = node.Tag as StatisticalData;
            if (_NodeData != null && _NodeData.IsDataLoaded && _NodeData.Type == DataType.RawData && _NodeData.DataException == null)
            {
                foreach (DataRow _DataValues in _NodeData.Values.Rows)
                {
                    XmlElement _DetailHeaderElement = _ChildElement.OwnerDocument.CreateElement(XmlConvert.EncodeName(ExportToXML.GetSafeXmlString(_DataValues[0].ToString())));
                    _ChildElement.AppendChild(_DetailHeaderElement);

                    for (int i = 0; i < _DataValues.Table.Columns.Count; i++)
                    {
                        XmlElement _DetailElement = _DetailHeaderElement.OwnerDocument.CreateElement(XmlConvert.EncodeName(_NodeData.DetailNames[i].HeaderText));
                        _DetailElement.AppendChild(_ChildElement.OwnerDocument.CreateTextNode(_DataValues[i].ToString()));
                        _DetailHeaderElement.AppendChild(_DetailElement);
                    }
                }
            }

            foreach (DevComponents.AdvTree.Node _ChildNode in node.Nodes)
            {
                ParseNodeXml(_ChildNode, _ChildElement);
            }
        }

        #endregion

       private void menuHelp_Click(object sender, EventArgs e)
       {
          
          base.OnClick(e);
       }


        #endregion

        private void ideraTitleBar1_LicenseInfoButtonClick(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }
    }
}

