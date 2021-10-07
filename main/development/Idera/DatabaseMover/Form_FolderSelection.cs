using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevComponents.AdvTree;
using Idera.SqlAdminToolset.Core;
using Idera.SqlAdminToolset.DatabaseMoverLibrary;

namespace Idera.SqlAdminToolset.DatabaseMover
{
    public partial class Form_FolderSelection : Form
    {
        string _ServerName;
        string[] _DriveList;
        bool _IsLocal;
        public Form_FolderSelection(string serverName, string[] driveList, string selectedFolder, bool isLocal)
        {
            InitializeComponent();
            _ServerName = serverName;
            _DriveList = driveList;
            textSelectedFolder.Text = selectedFolder;
            _IsLocal = isLocal;
            this.Text = string.Format(this.Text, serverName);
        }

        private void Form_FolderSelection_Load(object sender, EventArgs e)
        {
            treeFolders.BeginUpdate();
            foreach (string _Drive in _DriveList)
            {
                Node _Node = new Node();
                _Node.Name = _Node.Text = _Drive + ":";
                _Node.Image = imageList1.Images[0];

                string _RootDirectory = _IsLocal ? string.Format("{0}\\", _Node.Text) : string.Format(@"\\{0}\{1}$", _ServerName, _Node.Text.Remove(_Node.Text.Length - 1));
                _Node.Tag = new DirectoryInfo(_RootDirectory);

                treeFolders.Nodes.Add(_Node);
                _Node.ExpandVisibility = eNodeExpandVisibility.Visible;
            }
            ExpandSelected();
            treeFolders.EndUpdate();
            if (treeFolders.SelectedNode != null)
            {
                treeFolders.SelectedNode.EnsureVisible();
            }

        }

        private void ExpandSelected()
        {
            treeFolders.AutoScroll = true;
            string[] _FolderList = textSelectedFolder.Text.Split('\\');
            textSelectedFolder.Text = string.Empty;

            Node _FolderNode = FindNode(treeFolders.Nodes, _FolderList[0]);
            treeFolders.SelectNode(_FolderNode, eTreeAction.Code);
            for (int i = 1; i < _FolderList.Length; i++)
            {
                if (_FolderList[i].Trim().Length > 0)
                {
                    _FolderNode = FindNode(_FolderNode.Nodes, _FolderList[i]);
                    if (_FolderNode == null)
                    {
                        return;
                    }
                    treeFolders.SelectNode(_FolderNode, eTreeAction.Code);
                }
            }
            if (treeFolders.SelectedNode != null)
            {
                treeFolders.SelectedNode.Collapse();
            }
        }

        /// <summary>
        /// Finds a node in the specified collection.
        /// </summary>
        private Node FindNode(NodeCollection nodes, string name)
        {
            foreach (Node _Node in nodes)
            {
                if (_Node.Name.ToUpperInvariant() == name.ToUpperInvariant())
                {
                    _Node.Expand();
                    return _Node;
                }
            }
            return null;
        }

        private void treeFolders_BeforeExpand(object sender, AdvTreeNodeCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 0 && e.Node.ExpandVisibility != eNodeExpandVisibility.Hidden)
            {
                LoadDirectories(e.Node, (DirectoryInfo)e.Node.Tag);
            }
        }

        private void LoadDirectories(Node parent, DirectoryInfo directoryInfo)
        {
            foreach (DirectoryInfo _Directory in directoryInfo.GetDirectories())
            {
                if ((_Directory.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    continue;
                }
                Node _ChildNode = new Node();
                _ChildNode.Tag = _Directory;
                _ChildNode.Name = _ChildNode.Text = _Directory.Name;
                _ChildNode.Image = imageList1.Images[0];
                _ChildNode.ImageExpanded = imageList1.Images[0];
                parent.Nodes.Add(_ChildNode);
                if (_Directory.GetDirectories().Length > 0)
                {
                    _ChildNode.ExpandVisibility = eNodeExpandVisibility.Visible;
                }
                else
                {
                    _ChildNode.ExpandVisibility = eNodeExpandVisibility.Hidden;
                }
            }
        }

        private void treeFolders_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            if (e.Node != null)
            {
                textSelectedFolder.Text = GetPathFromNode(e.Node);
            }
        }

        /// <summary>
        /// Selected folder
        /// </summary>
        public string SelectedFolder
        {
            get { return textSelectedFolder.Text; }
        }

        private void addNewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeFolders.SelectedNode.ExpandVisibility == eNodeExpandVisibility.Visible)
                {
                    treeFolders.SelectedNode.Expand();
                }
                Node _NewNode = new Node();
                _NewNode.Name = _NewNode.Text = "New Folder";
                _NewNode.Image = imageList1.Images[0];
                _NewNode.ImageExpanded = imageList1.Images[0];

                bool _DuplicateName = false;
                int _FolderAppend = 2;
                do
                {
                    _DuplicateName = false;
                    foreach (Node _TreeNode in treeFolders.SelectedNode.Nodes)
                    {
                        if (_TreeNode.Name == _NewNode.Name)
                        {
                            _DuplicateName = true;
                            break;
                        }
                    }
                    if (_DuplicateName)
                    {
                        _NewNode.Name = _NewNode.Text = string.Format("New Folder ({0})", _FolderAppend);
                        _FolderAppend++;
                    }
                }
                while (_DuplicateName);

                DirectoryInfo _ParentDirectory = treeFolders.SelectedNode.Tag as DirectoryInfo;
                string _NewPath = Path.Combine(_ParentDirectory.FullName, _NewNode.Name);
                Directory.CreateDirectory(_NewPath);

                _NewNode.Tag = new DirectoryInfo(_NewPath);

                treeFolders.SelectedNode.Nodes.Add(_NewNode);
                treeFolders.SelectedNode.Nodes.Sort();
                //Sort(treeFolders.SelectedNode.Nodes, _NewNode);
                treeFolders.SelectedNode.ExpandVisibility = eNodeExpandVisibility.Visible;
                treeFolders.SelectedNode = _NewNode;
                _NewNode.EnsureVisible();
                _NewNode.BeginEdit();
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Add New Folder", exc);
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeFolders.SelectedNode.BeginEdit();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Messaging.ShowConfirmation(string.Format("Are you sure that you want to delete the folder '{0}'?", treeFolders.SelectedNode.Text)) == DialogResult.Yes)
                {
                    Node _DeletedNode = treeFolders.SelectedNode;
                    DirectoryInfo _Directory = _DeletedNode.Tag as DirectoryInfo;
                    Directory.Delete(_Directory.FullName, true);
                    treeFolders.SelectedNode = _DeletedNode.Parent;
                    if (_DeletedNode.Parent.Nodes.Count == 1)
                    {
                        _DeletedNode.Parent.ExpandVisibility = eNodeExpandVisibility.Hidden;
                    }
                    _DeletedNode.Remove();
                }
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Remove Folder", exc);
            }
        }

        private void treeFolders_CellEditEnding(object sender, CellEditEventArgs e)
        {
            try
            {
                if (e.NewText != e.Cell.Text)
                {
                    DirectoryInfo _Directory = e.Cell.Parent.Tag as DirectoryInfo;
                    DirectoryInfo _ParentDirectory = e.Cell.Parent.Parent.Tag as DirectoryInfo;
                    Directory.Move(_Directory.FullName, 
                                   Path.Combine(_ParentDirectory.FullName, e.NewText));
                    e.Cell.Parent.Tag = new DirectoryInfo(Path.Combine(_ParentDirectory.FullName, e.NewText));
                    e.Cell.Parent.Name = e.NewText;
                }
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Rename Folder", exc);
                e.Cancel = true;
            }
        }

        private void treeFolders_AfterCellEditComplete(object sender, CellEditEventArgs e)
        {
            //Sort(e.Cell.Parent.Parent.Nodes, e.Cell.Parent);
            e.Cell.Parent.Parent.Nodes.Sort();
            textSelectedFolder.Text = GetPathFromNode(e.Cell.Parent);
            treeFolders.SelectedNode = e.Cell.Parent;
            e.Cell.Parent.EnsureVisible();

        }


        private string GetPathFromNode(Node node)
        {
            string _Path = node.FullPath.Replace(';', '\\');
            if (node.Level == 0)
            {
                textSelectedFolder.Text += "\\";
            }
            return _Path;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (treeFolders.SelectedNode == null)
            {
                e.Cancel = true;
                return;
            }
            renameToolStripMenuItem.Enabled = deleteToolStripMenuItem.Enabled = (treeFolders.SelectedNode.Level > 0);
        }
    }
}