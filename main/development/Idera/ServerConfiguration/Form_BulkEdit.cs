using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.ServerConfiguration
{
    public partial class Form_BulkEdit : Form
    {
        private Dictionary<ServerInformation, List<ConfigurationData>> _Settings;
        bool _IsGroupedByServers = true;

        public Form_BulkEdit(string baseline, Dictionary<ServerInformation, List<ConfigurationData>> settingsToChange, bool showCollationWarning)
        {
            InitializeComponent();
            this.MinimumSize = this.Size;
            _Settings = settingsToChange;
            SetGroupView();
            labelBaselineName.Text = baseline;
            if (showCollationWarning)
            {
                labelCollationWarning.Text = ProductConstants.InformationCollationConflictsFound;
                labelCollationWarning.Visible = true;
            }
        }

        private void SetGroupView()
        {
            if (_IsGroupedByServers)
            {
                linkChangeView.Text = ProductConstants.BulkEditGroupBySetting;
                treeSettings.Nodes.Clear();
                foreach (KeyValuePair<ServerInformation, List<ConfigurationData>> _Item in _Settings)
                {
                    TreeNode _ServerNode = treeSettings.Nodes.Add(_Item.Key.Name, _Item.Key.Name);
                    _ServerNode.Tag = _Item.Key;
                    foreach (ConfigurationData _Data in _Item.Value)
                    {
                        TreeNode _ChildNode = new TreeNode(_Data.Name);
                        _ChildNode.Name = _Data.Name;
                        _ChildNode.Tag = _Data;
                        _ServerNode.Nodes.Add(_ChildNode);
                    }
                    _ServerNode.Checked = true;
                }
            }
            else
            {
                linkChangeView.Text = ProductConstants.BulkEditGroupByServer;
                treeSettings.Nodes.Clear();
                foreach (KeyValuePair<ServerInformation, List<ConfigurationData>> _Item in _Settings)
                {
                    foreach (ConfigurationData _Data in _Item.Value)
                    {
                        TreeNode _SettingNode;
                        if (treeSettings.Nodes.ContainsKey(_Data.Name))
                        {
                            _SettingNode = treeSettings.Nodes[_Data.Name];
                        }
                        else
                        {
                            _SettingNode = treeSettings.Nodes.Add(_Data.Name, _Data.Name);
                        }
                        _SettingNode.Nodes.Add(_Item.Key.Name, _Item.Key.Name);
                    }

                    foreach (TreeNode _Node in treeSettings.Nodes)
                    {
                        _Node.Checked = true;
                    }
                }
            }
            treeSettings.Sort();
        }

        protected override void OnLoad(EventArgs e)
        {
            SetGroupView();
            base.OnLoad(e);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (_IsGroupedByServers)
            {
                foreach (TreeNode _ServerNode in treeSettings.Nodes)
                {
                    ServerInformation _ServerInformation = _ServerNode.Tag as ServerInformation;

                    if (_ServerNode.Checked)
                    {
                        foreach (TreeNode _ChildNode in _ServerNode.Nodes)
                        {
                            if (!_ChildNode.Checked)
                            {
                                ConfigurationData _Data = _ChildNode.Tag as ConfigurationData;
                                _Settings[_ServerInformation].Remove(_Data);
                            }
                        }
                    }
                    else
                    {
                        _Settings.Remove(_ServerInformation);
                    }
                }
            }
            else
            {
                foreach (TreeNode _SettingNode in treeSettings.Nodes)
                {
                    foreach (TreeNode _ServerNode in _SettingNode.Nodes)
                    {
                        if (!_ServerNode.Checked)
                        {
                            foreach (ServerInformation _ServerInfo in _Settings.Keys)
                            {
                                if (_ServerInfo.Name == _ServerNode.Name)
                                {
                                    _Settings[_ServerInfo].Remove(_Settings[_ServerInfo].Find(delegate(ConfigurationData data) { return data.Name == _SettingNode.Name; }));
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Selected server values.
        /// </summary>
        public Dictionary<ServerInformation, List<ConfigurationData>> SelectedSettings
        {
            get
            {
                return _Settings;
            }
        }

        /// <summary>
        /// Check/uncheck all items in the tree node.
        /// </summary>
        private void treeSettings_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                foreach (TreeNode _ChildNode in e.Node.Nodes)
                {
                    _ChildNode.Checked = e.Node.Checked;
                }
            }
        }

        private void linkChangeView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _IsGroupedByServers = !_IsGroupedByServers;
            SetGroupView();
        }
    }
}