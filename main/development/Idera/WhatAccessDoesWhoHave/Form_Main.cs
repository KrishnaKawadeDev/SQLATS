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

namespace Idera.SqlAdminToolset.WhatAccessDoesWhoHave
{
    public partial class Form_Main : Form
    {
        #region Constructor

        public Form_Main()
        {
            InitializeComponent();
            this.Text = ideraTitleBar1.IderaProductNameText;
            ServerSelection.Text = "(local)";
            textLoginName.BackColor = Color.White;
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

        private void buttonGetResults_Click(object sender, EventArgs e)
        {
            if (IsServerInputValid() && textLoginName.Text.Trim().Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                treeObjects.Nodes.Clear();
                AccessOptions _Options = new AccessOptions();
                _Options.LoginName = textLoginName.Text.Trim();
                AccessData _AccessData = AccessHelper.HarvestData(ServerSelection.ServerList[0], ToolsetOptions.commandTimeout, _Options);
                PopulateNodes(null, _AccessData);
                Cursor = Cursors.Default;
            }
            else
            {
                Messaging.ShowError("You must specify a SQL Server instance and a server login");
            }
        }

        private bool IsServerInputValid()
        {
            if (ServerSelection.Text.Trim().Length == 0 || ServerSelection.ServerList.Count == 0)
            {
                Messaging.ShowError("You must specify a SQL Server instance name.");
                return false;
            }

            if (ServerSelection.ServerList.Count > 1)
            {
                Messaging.ShowError("You may only specify one SQL Server instance name.");
                return false;
            }

            return true;
        }

        private void textLoginName_ButtonCustomClick(object sender, EventArgs e)
        {
            try
            {
                if (IsServerInputValid())
                {
                    using (SqlConnection _Connection = Connection.OpenConnection(ServerSelection.ServerList[0].Name, ServerSelection.ServerList[0].SqlCredentials))
                    {
                        IList _Logins = SQLObjects.GetServerLogins(_Connection);
                        if (_Logins.Count == 0)
                        {
                            Messaging.ShowError("No available logins found in the source server");
                            return;
                        }

                        Form_LoginList _LoginForm = new Form_LoginList(_Logins);
                        if (_LoginForm.ShowDialog() == DialogResult.OK)
                        {
                            textLoginName.Text = _LoginForm.SelectedLogin;
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Get login list", exc);
            }
        }

        private void ServerSelection_TextChanged(object sender, EventArgs e)
        {
            textLoginName.Text = string.Empty;
        }

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
        #endregion

        private void treeObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (treeObjects.SelectedNode != null)
            {
                Cursor = Cursors.WaitCursor;
                listAccessDetails.Items.Clear();

                AccessData _Data = treeObjects.SelectedNode.Tag as AccessData;
                if (_Data == null)  //allow navigation on the right pane
                {
                    listAccessDetails.Columns[0].Text = "Objects";
                    foreach (Node _ChildNode in treeObjects.SelectedNode.Nodes)
                    {
                        ListViewItem _Item = new ListViewItem(_ChildNode.Text, _ChildNode.ImageIndex);
                        _Item.Tag = _ChildNode;
                        listAccessDetails.Items.Add(_Item);
                    }
                }
                else
                {
                    listAccessDetails.Columns[0].Text = "Effective Permissions";
                    foreach (string _Permission in _Data.AccessList)
                    {
                        listAccessDetails.Items.Add(_Permission);
                    }
                }
                Cursor = Cursors.Default;
            }
        }

        private void listAccessDetails_DoubleClick(object sender, EventArgs e)
        {
            if (listAccessDetails.SelectedItems != null && listAccessDetails.SelectedItems[0].Tag != null)
            {
                Node _SelectedNode = listAccessDetails.SelectedItems[0].Tag as Node;
                if (_SelectedNode != null)
                {
                    treeObjects.SelectedNode = _SelectedNode;
                    if (_SelectedNode.Nodes.Count > 0)
                    {
                        _SelectedNode.Expand();
                    }
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
    }
}

