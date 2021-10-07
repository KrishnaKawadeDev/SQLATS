#region SQL admin toolset © 2007, 2012 Idera, Inc. and Idera.

/* 
 * Idera reserves all rights in the program and source code as delivered.  The program 
 * or any portion thereof may not be reproduced or reverse engineered in any form 
 * whatsoever without the written consent of Idera.  
 * 
 * A license to the software does not constitute authorization.
 */

#endregion

#region Using Directives

using System;
using System.Windows.Forms;
using System.Reflection;
using Idera.SqlAdminToolset.Core;

#endregion

namespace Idera.SqlAdminToolset.Core
{
  public partial class Form_AddServerGroup : Form
  {
    public string serverGroup
    {
       get { return textServerGroup.Text; }
    }
    
    public ToolServerGroup parentGroup
    {
       get
       {
          TreeNode parent = treeServerGroups.SelectedNode;
          if ( parent == null ) return null;
          
          if (parent.Tag.GetType().ToString() == "System.String" )
          {
             return null; // root node selected so create at top level
          }
          else
          {
             return (ToolServerGroup)parent.Tag;
          }
       }
    }
    

    public
       Form_AddServerGroup(
          TreeNode                 targetGroupNode,
          TreeView                 parentTreeView
          )
    {
      InitializeComponent();
      
      if ( parentTreeView == null )
      {
         LoadServerGroups();
      }
      else
      {
         LoadServerGroupsFromParent( parentTreeView );
      }
      
      // select target group by default
       if (targetGroupNode.Tag.GetType().ToString() == "System.String" )
       {
          // root node selected so create at top level
          treeServerGroups.SelectedNode = treeServerGroups.Nodes[0];
       }
       else
       {
          // find the corresponding node
          treeServerGroups.SelectedNode = FindGroupNode( treeServerGroups.Nodes[0], (ToolServerGroup)targetGroupNode.Tag );
       }
       
       textServerGroup.Select();
    }

    private void textServerGroup_TextChanged(object sender, EventArgs e)
    {
      buttonOK.Enabled = (textServerGroup.Text.Trim().Length != 0);
    }

     private void buttonOK_Click( object sender, EventArgs e )
     {
        if ( ValidGroupName() )
        {
           DialogResult = DialogResult.OK;
        }
        else
        {
           DialogResult = DialogResult.None;
        }
     }
     
     private bool ValidGroupName()
     {
        if ( ! ToolServerGroup.IsGroupNameValid( textServerGroup.Text ) )
        {
           Messaging.ShowError( ToolServerGroup.InvalidGroupNameString );
           return false;
        }
        else
        {
           return true;
        }
     }
     
      private TreeNode
         FindGroupNode(
            TreeNode        parent,
            ToolServerGroup group
         )
      {
         TreeNode groupNode = null;
      
         foreach ( TreeNode node in parent.Nodes )
         {
            if ( node.ImageIndex == 0)
            {
               ToolServerGroup nodeGroup = (ToolServerGroup)node.Tag;
               if ( nodeGroup == group ) 
                  groupNode = node;
               else
                  groupNode = FindGroupNode( node, group );
                  
               if ( groupNode != null ) break;
            }
         }
         
         return groupNode;
      }
      
      #region Load Tree
      
      private void
         LoadServerGroupsFromParent(
           TreeView  parentTreeView
         )
      {
         try
         {
            Cursor = Cursors.WaitCursor;
            treeServerGroups.BeginUpdate();
            treeServerGroups.Nodes.Clear();
            
            foreach ( TreeNode n in parentTreeView.Nodes )
            {
               TreeNode newNode = (TreeNode)n.Clone();
               treeServerGroups.Nodes.Add( newNode );
            }
            
            treeServerGroups.Nodes[0].Expand();
            treeServerGroups.SelectedNode = treeServerGroups.Nodes[0];
            treeServerGroups.SelectedNode.EnsureVisible();
         }
         finally
         {
            treeServerGroups.EndUpdate();
            Cursor = Cursors.Default;
         }
      }

      private void LoadServerGroups()
      {
         try
         {
            Cursor = Cursors.WaitCursor;
            treeServerGroups.BeginUpdate();
            
            treeServerGroups.Nodes.Clear();
            
            TreeNode rootNode           = new TreeNode( "SQL admin toolset Server Groups" );
            rootNode.Tag                = "root";
            rootNode.ImageIndex         = 0;
            rootNode.SelectedImageIndex = 0;
            treeServerGroups.Nodes.Add( rootNode );
         
            // Load Tree
            foreach ( ToolServerGroup group in CoreGlobals.ServerGroupList.Groups )
            {
               // add root node
               TreeNode node = new TreeNode( group.Name );
               node.Tag = group;
               node.ImageIndex         = 0;
               node.SelectedImageIndex = 0;
               rootNode.Nodes.Add( node );
               
               // recurse groups
               ProcessSubgroups( node, group ); 
            }
            
            treeServerGroups.ExpandAll();
            treeServerGroups.SelectedNode = treeServerGroups.Nodes[0];
         }
         finally
         {
            treeServerGroups.EndUpdate();
            Cursor = Cursors.Default;
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
            
            // recurse groups
            ProcessSubgroups( node, group ); 
         }
      }
      
      #endregion
  }
}