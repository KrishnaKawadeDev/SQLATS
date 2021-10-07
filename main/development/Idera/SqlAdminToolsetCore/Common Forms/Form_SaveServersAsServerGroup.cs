#region SQL admin toolset © 2007, 2012 Idera, Inc. and Idera.

/* 
 * Idera reserves all rights in the program and source code as delivered.  The program 
 * or any portion thereof may not be reproduced or reverse engineered in any form 
 * whatsoever without the written consent of Idera.  
 * 
 * A license to the software does not constitute authorization.
 */

#endregion

using System;
using System.Windows.Forms;
using System.Reflection;
using System.Text;
using System.Drawing;

namespace Idera.SqlAdminToolset.Core
{
  public partial class Form_SaveServersAsServerGroup : Form
  {
    private TreeNode  rootNode = null;
  
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
    
    private bool m_loading = false;
    public Form_SaveServersAsServerGroup( string [] inServers )
    {
      InitializeComponent();
      
      m_loading = true;
      
      LoadServerGroups();
      
      foreach (string s in inServers )
      {
         ListViewItem lvi = checklistServers.Items.Add( s );
         lvi.Checked = true;
      }

      textServerGroup.Select();
      
      m_loading = false;
    }

     protected override void OnLoad( EventArgs e )
     {
        base.OnLoad( e );
        
        CheckButtonStatus();
        
        textServerGroup.Select();
     }

    private void textServerGroup_TextChanged(object sender, EventArgs e)
    {
       CheckButtonStatus();
    }
    
    private void CheckButtonStatus()
    {
       if ( m_loading ) return;
       
      bool enabled = true;

      if (textServerGroup.Text.Trim().Length == 0)         enabled = false;
      else if ( checklistServers.CheckedItems == null )    enabled = false;
      else if ( checklistServers.CheckedItems.Count == 0 ) enabled = false;

      buttonOK.Enabled = enabled;
    }

     private void buttonOK_Click( object sender, EventArgs e )
     {
        if ( ValidGroupName() )
        {
           if ( AddGroup() )
           {
              SaveGroup();
              DialogResult = DialogResult.OK;
           }
        }
     }
     
      private bool AddGroup()
      {
         TreeNode newNode= null;
         
         TreeNode targetGroupNode = GetCorrespondingGroupNode(treeServerGroups.SelectedNode); 
        
         ToolServerGroup newGroup   = new ToolServerGroup( textServerGroup.Text );
         newNode                    = new TreeNode ( textServerGroup.Text );
         newNode.Tag                = newGroup;
         newNode.ImageIndex         = 0;
         newNode.SelectedImageIndex = 0;

         if ( (targetGroupNode.Nodes.Count != 0 ) && NodeExists( targetGroupNode, newNode ) )
         {
            DialogResult choice = Messaging.ShowConfirmation( "A server group by that name already exists. Do you want to overwrite the existing server group?", "Add Server Group" );
            if ( choice == DialogResult.Yes )
            {
               foreach ( TreeNode node in targetGroupNode.Nodes )
               {
                  if (    node.Text.Trim().ToUpper() == newNode.Text.Trim().ToUpper()
                       && node.ImageIndex            == newNode.ImageIndex )
                  {
                     ClearServers( node );
                     AddServers( node );
                     break;
                  }
               }
               return true;
            }
            else
            {
               return false;
            }
         }
         else
         {
            targetGroupNode.Nodes.Add( newNode );
            AddServers( newNode );
         }
         
         return true;
      }
      
      private void SaveGroup()
      {
         // rebuild global groups list
         CoreGlobals.ServerGroupList.DisposeGroup();
         
         foreach (TreeNode node in treeServerGroups.Nodes[0].Nodes )
         {
            ToolServerGroup group = new ToolServerGroup( node.Text );
            CoreGlobals.ServerGroupList.Groups.Add( group );
            AddChildren( node, group );
         }
         
         // write to disk
         ToolServerGroup.WriteGlobalGroupList();
      }
      
      private void ClearServers( TreeNode parent )
      {
         bool found = true;
         while ( found )
         {
            found = false;
            foreach ( TreeNode node in parent.Nodes )
            {
               if ( node.ImageIndex == 1 )
               {
                  found = true;
                  node.Remove();
               }
            }
         }
      }
      
      private void AddServers( TreeNode parent )
      {
         foreach( ListViewItem lvi in checklistServers.CheckedItems )
         {
            string server = SQLHelpers.NormalizeInstanceName(lvi.Text);
            ToolServer newServer    = new ToolServer( server );
            TreeNode node           = new TreeNode( server );
            node.Tag                = newServer;
            node.ImageIndex         = 1;
            node.SelectedImageIndex = 1;
            
            if ( ! NodeExists( parent, node ) )
            {
               parent.Nodes.Add( node );
            }
         }
      }
      
      private void
         AddChildren(
            TreeNode        parentNode,
            ToolServerGroup parentGroup
         )
      {
         foreach ( TreeNode node in parentNode.Nodes )
         {
            if ( node.ImageIndex == 0 )
            {
               ToolServerGroup group = new ToolServerGroup( node.Text );
               parentGroup.Groups.Add( group );
               AddChildren( node, group );
            }
            else
            {
               ToolServer server = new ToolServer( (ToolServer)node.Tag );
               parentGroup.Servers.Add( server );
            }
         }
      }
     
     private bool ValidGroupName()
     {
        char [] invalidChars = new char[] { '&','<','>',';','"','\''};
        if ( -1 != textServerGroup.Text.IndexOfAny(invalidChars) )
        {
           Messaging.ShowError( "Server group names may not include any of the following characters:\r\n" + 
                                "    &  <  >  ;  \"  '   \\ " );
           return false;
        }
        else
        {
           return true;
        }
     }
      
      #region Worker Routines
      
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
      
      private TreeNode
         GetCorrespondingGroupNode(
            TreeNode currentNode
         )
      {
         if ( currentNode == null )
            return rootNode;
         else if ( currentNode.ImageIndex == 0 )   // we are already on a group
            return currentNode;
         else // we are on a server - get parent
            return currentNode.Parent;
      }
      
      private bool
         NodeExists(
            TreeNode    parentNode,
            TreeNode    newNode
         )
      {
         bool found = false;
         foreach ( TreeNode node in parentNode.Nodes )
         {
            if (    node.Text.Trim().ToUpper() == newNode.Text.Trim().ToUpper()
                 && node.ImageIndex            == newNode.ImageIndex )
            {
               found = true;
               break;
            }
         }
         return found;
      }
      
      #endregion
      

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
               
               // Add 
               ProcessServers( node, group ); 
               
               // recurse groups
               ProcessSubgroups( node, group ); 
            }
            
            treeServerGroups.Nodes[0].Expand();
            treeServerGroups.SelectedNode = treeServerGroups.Nodes[0];
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
            
            // Add 
            ProcessServers( node, group ); 
               
            // recurse groups
            ProcessSubgroups( node, group ); 
         }
      }

     private void checklistServers_ItemChecked( object sender, ItemCheckedEventArgs e )
     {
        CheckButtonStatus();
     }

     private void buttonSelectAll_Click( object sender, EventArgs e )
     {
        foreach ( ListViewItem lvi in checklistServers.Items )
        {
           lvi.Checked = true;
        }
     }

     private void buttonClearAll_Click( object sender, EventArgs e )
     {
        foreach ( ListViewItem lvi in checklistServers.Items )
        {
           lvi.Checked = false;
        }
     }

     private void treeServerGroups_DoubleClick( object sender, EventArgs e )
     {
        if ( treeServerGroups.SelectedNode.ImageIndex == 0 )
        {
           textServerGroup.Text = treeServerGroups.SelectedNode.Text;
        }
     }

     private void treeServerGroups_AfterSelect( object sender, TreeViewEventArgs e )
     {
        contextMenuOverwrite.Enabled = ( treeServerGroups.SelectedNode.ImageIndex == 0 );
     }

     private void contextMenuOverwrite_Click( object sender, EventArgs e )
     {
        textServerGroup.Text = treeServerGroups.SelectedNode.Text;
        
        // set selected node to parent node
        treeServerGroups.SelectedNode = treeServerGroups.SelectedNode.Parent;
        treeServerGroups.SelectedNode.EnsureVisible();
     }

      #region Context Menu Display Overload Routines
      // Because we cant tell what node was right clicked on, we cant 
      // make context sensitive context menus without hand doing it
      // behind the scenes. So we overload KeyUp and MouseUp and 
      // determine the node and do the right thing
      private void treeServerGroups_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
      {
         // Handle the context menu key
         if ( e.KeyCode == Keys.Apps )
         {
            Point pt = new Point( treeServerGroups.SelectedNode.Bounds.Left,
                                  treeServerGroups.SelectedNode.Bounds.Bottom );
            //ResetContextMenu();
            contextMenuStrip1.Show( treeServerGroups, pt );
         }
      }

      private void treeServerGroups_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if ( e.Button != MouseButtons.Right ) return;
         
         Point pt = new Point( e.X, e.Y );
         treeServerGroups.PointToClient( pt );

         TreeNode Node = treeServerGroups.GetNodeAt( pt );
         if ( Node == null ) return;
         if ( Node.Bounds.Contains( pt ) )
         {
            treeServerGroups.SelectedNode = Node;
            //ResetContextMenu();
            contextMenuStrip1.Show( treeServerGroups, pt );
         }
      }
      
      #endregion
  }
}