using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.DatabaseConfiguration
{
    public partial class Form_BulkEdit : Form
    {
        private Dictionary<ConfigurationSettings, List<ConfigurationData>> _Settings;
        bool _IsGroupedByServers = true;

        public Form_BulkEdit(string baselineName, Dictionary<ConfigurationSettings, List<ConfigurationData>> settingsToChange,
                             bool collationConflicts, bool compatibilityConflicts)
        {
            InitializeComponent();
            this.MinimumSize = this.Size;
            _Settings = settingsToChange;
            SetGroupView();
            labelBaselineName.Text = baselineName;

            if (collationConflicts || compatibilityConflicts)
            {
                
                string _Message = ProductConstants.InformationReadOnlyConflictsFound + "(";
                if (collationConflicts)
                {
                    _Message += ProductConstants.ConfigurationValueCollation;
                }
                if (compatibilityConflicts)
                {
                    if (collationConflicts)
                    {
                        _Message += ", ";
                    }
                    _Message += ProductConstants.ConfigurationValueCompatibility + ").";
                }

                labelReadOnlyConflicts.Text = _Message;
                labelReadOnlyConflicts.Visible = true;
            }
        }

        private void SetGroupView()
        {
            if (_IsGroupedByServers)
            {
                linkChangeView.Text = ProductConstants.BulkEditGroupBySetting;
                treeSettings.Nodes.Clear();

                foreach (KeyValuePair<ConfigurationSettings, List<ConfigurationData>> _Item in _Settings)
                {
                    TreeNode _ServerNode;
                    if (treeSettings.Nodes.ContainsKey(_Item.Key.ServerName))
                    {
                        _ServerNode = treeSettings.Nodes[_Item.Key.ServerName];
                    }
                    else
                    {
                        _ServerNode = treeSettings.Nodes.Add(_Item.Key.ServerName, _Item.Key.ServerName);
                    }
                    TreeNode _DatabaseNode = _ServerNode.Nodes.Add(_Item.Key.DatabaseName);
                    _DatabaseNode.Tag = _Item.Key;

                    foreach (ConfigurationData _Data in _Item.Value)
                    {
                        TreeNode _ChildNode = new TreeNode(_Data.Name);
                        _ChildNode.Name = _Data.Name;
                        _ChildNode.Tag = _Data;
                        _DatabaseNode.Nodes.Add(_ChildNode);
                    }
                    _ServerNode.Checked = true;
                }
            }
            else
            {
                linkChangeView.Text = ProductConstants.BulkEditGroupByServer;
                treeSettings.Nodes.Clear();

                foreach (KeyValuePair<ConfigurationSettings, List<ConfigurationData>> _Item in _Settings)
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
                        _SettingNode.Nodes.Add(_Item.Key.Key, _Item.Key.Key);
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
                    foreach (TreeNode _DatabaseNode in _ServerNode.Nodes)
                    {
                        ConfigurationSettings _ConfigurationSettings = _DatabaseNode.Tag as ConfigurationSettings;

                        if (_DatabaseNode.Checked)
                        {
                            foreach (TreeNode _ChildNode in _DatabaseNode.Nodes)
                            {
                                if (!_ChildNode.Checked)
                                {
                                    ConfigurationData _Data = _ChildNode.Tag as ConfigurationData;
                                    _Settings[_ConfigurationSettings].Remove(_Data);
                                }
                            }
                        }
                        else
                        {
                            _Settings.Remove(_ConfigurationSettings);
                        }
                    }
                }
            }
            else
            {
                foreach (TreeNode _SettingNode in treeSettings.Nodes)
                {
                    foreach (TreeNode _DatabaseNode in _SettingNode.Nodes)
                    {
                        if (!_DatabaseNode.Checked)
                        {
                            foreach (ConfigurationSettings _ConfigurationSettings in _Settings.Keys)
                            {
                                if (_ConfigurationSettings.Key == _DatabaseNode.Name)
                                {
                                    _Settings[_ConfigurationSettings].Remove(_Settings[_ConfigurationSettings].Find(delegate(ConfigurationData data) { return data.Name == _SettingNode.Name; }));
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
        public Dictionary<ConfigurationSettings, List<ConfigurationData>> SelectedSettings
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
            if (e.Node.Level <= 1)
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