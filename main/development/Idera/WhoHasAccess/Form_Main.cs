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
using DevComponents.AdvTree;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.WhoHasAccess
{
    public partial class Form_Main : Form
    {
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
        JobPool<AccessData> _JobPool;
        private static Dictionary<string, string> _ErrorReports = new Dictionary<string, string>();
        private ToolProgressBarDialog _ProgressDialog;

        private void buttonGetResults_Click(object sender, EventArgs e)
        {
            // Validation
            if (ServerSelection.ServerList.Count == 0)
            {
                Core.Messaging.ShowError("Specify a SQL Server instance name.");
                ServerSelection.Select();
                return;
            }

            MRU.AddServerOrGroup(ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server,
                                     ServerSelection.Text,
                                     ServerSelection.SqlCredentials);

            _JobPool = new JobPool<AccessData>(5);
            _JobPool.ServerTaskComplete += new EventHandler<JobExecutionResultsEventArgs>(JobPool_ServerTaskComplete);
            _JobPool.TaskComplete += new EventHandler<JobExecutionEventArgs>(JobPool_AllTasksComplet);
            ProgressBar_Initialize();

            _JobPool.Enqueue(PermissionsHelper.HarvestData, ServerSelection.ServerList, ToolsetOptions.commandTimeout);
            _JobPool.StartAsync();

            ProgressBar_Show();
        }

        #region Job Pool
        void JobPool_ServerTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            if (e.Status == TaskStatus.Success)
            {
                PopulateNodes(null, (AccessData)e.Resultset);
            }
            else
            {
                _ErrorReports.Add(e.Server.Name, e.ErrorMessage);
            }
        }

        void JobPool_AllTasksComplet(object sender, JobExecutionEventArgs e)
        {
            ProgressBar_Close();

            if (_ErrorReports.Count > 0)
            {
                Form_MultipleServerError frm = new Form_MultipleServerError();

                foreach (KeyValuePair<string, string> _Error in _ErrorReports)
                {
                    frm.AddError(_Error.Key, _Error.Value);
                }

                BeginInvoke((MethodInvoker)delegate () { frm.ShowDialog(); });

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

        /// <summary>
        /// Populates server objects
        /// </summary>
        private void PopulateNodes(Node rootNode, AccessData data)
        {
            Node _NewNode = new Node();
            _NewNode.Text = data.ObjectName;
            _NewNode.Tag = data;
            if (data.DataException == null)
            {
                _NewNode.ImageIndex = (int)data.Type;
                if (rootNode == null)
                {
                    treeObjects.Nodes.Add(_NewNode);
                }
                else
                {
                    rootNode.Nodes.Add(_NewNode);
                }
                foreach (AccessDataGroup _Group in data.ChildData)
                {
                    PopulateGroupNodes(_NewNode, _Group);
                }
            }
            else
            {
                Messaging.ShowException("Harvest Data", data.DataException);
            }
        }

        /// <summary>
        /// Populates server object groups
        /// </summary>
        private void PopulateGroupNodes(Node rootNode, AccessDataGroup group)
        {
            Node _GroupNode = new Node();
            _GroupNode.Text = group.Name;
            _GroupNode.Tag = group;
            _GroupNode.ImageIndex = (int)group.Type;
            rootNode.Nodes.Add(_GroupNode);

            foreach (AccessDataGroup _GroupData in group.Groups)
            {
                PopulateGroupNodes(_GroupNode, _GroupData);
            }

            foreach (AccessData _ChildData in group.Items)
            {
                PopulateNodes(_GroupNode, _ChildData);
            }
        }

        private void treeObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            treeUsers.Nodes.Clear();

            AccessData _Data = treeObjects.SelectedNode.Tag as AccessData;
            if (_Data == null)  //allow navigation on the right pane
            {
                foreach (Node _ChildNode in treeObjects.SelectedNode.Nodes)
                {
                    Node _ItemNode = new Node();
                    _ItemNode.Text = _ChildNode.Text;
                    _ItemNode.Tag = _ChildNode;
                    _ItemNode.ImageIndex = _ChildNode.ImageIndex;
                    treeUsers.Nodes.Add(_ItemNode);
                }
            }
            else
            {
                if (!_Data.PermissionsLoaded)
                {
                    PermissionsHelper.FillData(_Data);
                }

                FillPermissionTree(_Data.AccessList, treeUsers.Nodes);
            }
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Populates the permissions panel
        /// </summary>
        private void FillPermissionTree(List<AccessPermissions> permissionsList, NodeCollection nodes)
        {
            foreach (AccessPermissions _ObjectPermissions in permissionsList)
            {
                Node _Node = new Node();
                if (_ObjectPermissions.LoginName != null && _ObjectPermissions.UserName == null)
                {
                    _Node.Text = _ObjectPermissions.LoginName;
                }
                else if (_ObjectPermissions.LoginName == null && _ObjectPermissions.UserName != null)
                {
                    _Node.Text = _ObjectPermissions.UserName;
                }
                else
                {
                    _Node.Text = string.Format("{0} ({1})", _ObjectPermissions.UserName, _ObjectPermissions.LoginName);
                }
                if (_Node.Text.ToUpperInvariant() != "PUBLIC")
                {
                    if (_ObjectPermissions.DetailRelation == AccessDetailsRelation.MemberOf)
                    {
                        if (treeUsers.Columns.Contains(columnAccess))
                        {
                            treeUsers.Columns.Remove(columnAccess);
                        }
                    }
                    else
                    {
                        if (treeUsers.Columns.Count == 1)
                        {
                            treeUsers.Columns.Add(columnAccess);
                        }
                        if (_ObjectPermissions.Permissions.Count == 0)
                        {
                            _Node.Cells.Add(new Cell("Full"));
                        }
                        else
                        {
                            _Node.Cells.Add(new Cell("Restricted"));
                        }
                    }

                    _Node.Tag = _ObjectPermissions;

                    nodes.Add(_Node);

                    if (_ObjectPermissions.UserType == UserType.NtGroup || _ObjectPermissions.UserType == UserType.SqlRole)
                    {
                        _Node.ImageIndex = (int)ObjectType.ServerRole;
                        if (_ObjectPermissions.GroupMembers.Count > 0)
                        {
                            FillPermissionTree(_ObjectPermissions.GroupMembers, _Node.Nodes);
                        }
                    }
                    else
                    {
                        _Node.ImageIndex = (int)ObjectType.ServerLogin;
                    }
                }
            }
        }

        private void treeUsers_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            AccessPermissions _Permissions = e.Node.Tag as AccessPermissions;
            if (_Permissions != null)
            {
                if (_Permissions.Permissions.Count > 0)
                {
                    Form_AccessDetails _Details = new Form_AccessDetails(_Permissions.Permissions, _Permissions.DetailRelation);
                    _Details.ShowDialog();
                }
            }
            else
            {
                Node _SelectedNode = e.Node.Tag as Node;
                if (_SelectedNode != null)
                {
                    treeObjects.SelectedNode = _SelectedNode;
                }
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            treeUsers.Nodes.Clear();

            AccessData _Data = treeObjects.SelectedNode.Tag as AccessData;
            if (_Data != null)
            {
                _Data.AccessList.Clear();
                PermissionsHelper.FillData(_Data);

                FillPermissionTree(_Data.AccessList, treeUsers.Nodes);
            }
            Cursor = Cursors.Default;
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