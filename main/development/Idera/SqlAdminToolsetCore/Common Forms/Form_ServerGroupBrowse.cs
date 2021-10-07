using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Core
{
   public partial class Form_ServerGroupBrowse : Form
   {
      public string FullPath
      {
         get
         {
            string fullpath = "";
            
            if ( treeServerGroups.SelectedNode == null ) 
               return null;
            else
            {
               TreeNode node = treeServerGroups.SelectedNode;
               while ( node != null )
               {
                  if (fullpath != "" ) fullpath = "\\" + fullpath;
                  fullpath = node.Text + fullpath;
                  node = node.Parent;
               }
            }
               
            return fullpath;
         }
      }

      public ToolServerGroup SelectedGroup
      {
         get
         {
            if ( treeServerGroups.SelectedNode == null ) 
               return null;
            else
               return ( ToolServerGroup)treeServerGroups.SelectedNode.Tag;
         }
      }
      
      public Form_ServerGroupBrowse()
      {
         InitializeComponent();
         
         LoadServerGroups();
      }
      
      private void LoadServerGroups()
      {
         try
         {
            Cursor = Cursors.WaitCursor;
            treeServerGroups.BeginUpdate();
            
            treeServerGroups.Nodes.Clear();
         
            // Load Tree
            foreach ( ToolServerGroup group in CoreGlobals.ServerGroupList.Groups )
            {
               // add root node
               TreeNode node = new TreeNode( group.Name );
               node.Tag = group;
               node.ImageIndex         = 0;
               node.SelectedImageIndex = 0;
               treeServerGroups.Nodes.Add( node );
               
               // Add 
               if ( checkBoxShowGroupMembers.Checked )
               {
                  ProcessServers( node, group ); 
               }
               
               // recurse groups
               ProcessSubgroups( node, group ); 
            }
            
            if ( treeServerGroups.Nodes.Count != 0 )
            {
               treeServerGroups.ExpandAll();
               treeServerGroups.SelectedNode = treeServerGroups.Nodes[0];
               treeServerGroups.Select();
               labelNoServerGroups.Visible = false;
            }
            else
            {
               labelNoServerGroups.Visible = true;
            }
            
         }
         finally
         {
            treeServerGroups.EndUpdate();
            Cursor = Cursors.Default;
         }
      }
      
      public void
         ProcessServers(
            TreeNode         parentNode, 
            ToolServerGroup  parentGroup 
         )
      {
         foreach ( ToolServer server in parentGroup.Servers )
         {
            // add root node
            TreeNode node = new TreeNode( server.Name );
            node.Tag = server;
            node.ImageIndex         = 1;
            node.SelectedImageIndex = 1;
            parentNode.Nodes.Add( node );
         }
      }
      
      public void
         ProcessSubgroups(
            TreeNode         parentNode, 
            ToolServerGroup  parentGroup 
         )
      {
         foreach ( ToolServerGroup group in parentGroup.Groups )
         {
            // add root node
            TreeNode node = new TreeNode( group.Name );
            node.Tag = group;
            node.ImageIndex         = 0;
            node.SelectedImageIndex = 0;
            parentNode.Nodes.Add( node );
            
            // process servers in this group
            if ( checkBoxShowGroupMembers.Checked )
            {
               ProcessServers( node, group ); 
            }
            
            // recurse groups
            ProcessSubgroups( node, group ); 
         }
      }
      

      private void treeServerGroups_AfterSelect( object sender, TreeViewEventArgs e )
      {
         btnOK.Enabled = ( treeServerGroups.SelectedNode.ImageIndex == 0 );
         
      }

      private void checkBoxShowGroupMembers_CheckedChanged( object sender, EventArgs e )
      {
         LoadServerGroups();
      }

      private void treeServerGroups_DoubleClick( object sender, EventArgs e )
      {
         if ( btnOK.Enabled )
         {
            DialogResult = DialogResult.OK;
            Close();
         }
      }

      private void linkCheckVersionList_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
      {
         //launch
         Form_ManageServerGroups frm = new Form_ManageServerGroups();
         DialogResult dialogResult = frm.ShowDialog();
         
         //reload
         if ( dialogResult == DialogResult.OK )
         {
            LoadServerGroups();
         }
      }
   }
}