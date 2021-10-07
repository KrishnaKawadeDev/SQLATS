using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Xml;


namespace Idera.SqlAdminToolset.Core
{
   public partial class Form_ManageServerGroups : Form
   {
      private TreeNode  rootNode = null;
      private bool      dirty = false;
       
      public Form_ManageServerGroups()
      {
         InitializeComponent();
         
         treeServerGroups.TreeViewNodeSorter = new NodeSorter();         
         
         LoadServerGroups();
      }
      
      #region Load Groups

      private void LoadServerGroups()
      {
         try
         {
            Cursor = Cursors.WaitCursor;
            treeServerGroups.BeginUpdate();
            
            treeServerGroups.Nodes.Clear();
            
            rootNode                    = new TreeNode( "SQL admin toolset Server Groups" );
            rootNode.Tag                = "root";
            rootNode.ImageIndex         = 0;
            rootNode.SelectedImageIndex = 0;
            treeServerGroups.Nodes.Add( rootNode );
            Application.DoEvents();
            
            // check if on disk list is newer
            if (ToolServerGroup.IsOnDiskFileGroupListNewer())
            {
               // reload list and fire event to tell tool that the list has changed
                ToolServerGroup.ReadGlobalGroupList();
               CoreGlobals.ServerGroupList.RaiseServerGroupsChangedEvent();
            }
           
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
            
            if ( treeServerGroups.Nodes.Count != 0 )
            {
               //treeServerGroups.ExpandAll();
               treeServerGroups.SelectedNode = treeServerGroups.Nodes[0];
               treeServerGroups.Nodes[0].Expand();
               treeServerGroups.Select();
               labelNoServerGroups.Visible = false;
            }
            else
            {
               buttonAddGroup.Enabled      = true;
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
            
            if ( server.Credentials == null || server.Credentials.useWindowsAuthentication )
            {
               node.ImageIndex         = 1;
               node.SelectedImageIndex = 1;
            }
            else
            {
               node.ImageIndex         = 2;
               node.SelectedImageIndex = 2;
            }
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

      #endregion

      private void treeServerGroups_AfterSelect( object sender, TreeViewEventArgs e )
      {
         buttonDeleteGroup.Enabled = false;
         buttonRenameGroup.Enabled = false;
         buttonAddServer.Enabled = false;
         buttonSetServerCredentials.Enabled = false;
         buttonRemoveServer.Enabled = false;
         buttonRenameServer.Enabled = false;
         
         if  ( treeServerGroups.SelectedNode != null )
         {
            if ( treeServerGroups.SelectedNode.ImageIndex == 0 )
            {
               // group node selected - if not root then allow adding server
              if (treeServerGroups.SelectedNode.Tag.GetType().ToString() == "Idera.SqlAdminToolset.Core.ToolServerGroup")
                 buttonAddServer.Enabled = true;
                 
              if  ( treeServerGroups.SelectedNode != rootNode )
              {
                 buttonRenameGroup.Enabled = true;
                 buttonDeleteGroup.Enabled = true;
              }
            }
            else
            {
               // server node selected
               buttonAddServer.Enabled = true;
               buttonSetServerCredentials.Enabled = true;
               buttonRemoveServer.Enabled = true;
               buttonRenameServer.Enabled = true;
            }
         }

         contextMenuDeleteGroup.Enabled = buttonDeleteGroup.Enabled;
         contextMenuRenameGroup.Enabled = buttonRenameGroup.Enabled;
         contextMenuAddServer.Enabled = buttonAddServer.Enabled;
         contextMenuSetServerCredentials.Enabled = buttonSetServerCredentials.Enabled;
         contextMenuRemoveServer.Enabled = buttonRemoveServer.Enabled;
         contextMenuTextConnection.Enabled = buttonRemoveServer.Enabled;
         contextMenuRenameServer.Enabled = buttonRenameServer.Enabled;
      }
      
      #region Add Group
      
      private void buttonAddGroup_Click( object sender, EventArgs e )
      {
         AddGroup();
      }
      private void contextMenuAddGroup_Click( object sender, EventArgs e )
      {
         AddGroup();
      }

      private void AddGroup()
      {
         TreeNode newNode= null;
         bool     unique = false;
         
         TreeNode targetGroupNode = GetCorrespondingGroupNode(treeServerGroups.SelectedNode); 
        
         
         Form_AddServerGroup frm = new Form_AddServerGroup( targetGroupNode, this.treeServerGroups );
         while ( ! unique )
         {
            DialogResult choice = frm.ShowDialog();
            if ( choice == DialogResult.Cancel )
            {
               return;
            }
            
            if ( frm.parentGroup == null )
               targetGroupNode = rootNode;
            else
               targetGroupNode = FindGroupNode( rootNode, frm.parentGroup );
            
            ToolServerGroup newGroup = new ToolServerGroup( frm.serverGroup, frm.parentGroup );
            newNode                    = new TreeNode ( frm.serverGroup );
            newNode.Tag                = newGroup;
            newNode.ImageIndex         = 0;
            newNode.SelectedImageIndex = 0;

            if ( (targetGroupNode.Nodes.Count == 0 ) ||
                 (! NodeExists( targetGroupNode, newNode ))
               )
            {
               unique = true;
            }
            else
            {
               Messaging.ShowError( "A server group by that name already exists. Please specify a unique name for the new server group.", "Add Server Group" );
            }
         }
         
         if ( targetGroupNode.Nodes.Count == 0 )
         {
            labelNoServerGroups.Visible = false;
         }

         targetGroupNode.Nodes.Add( newNode );
         if ( targetGroupNode.Nodes.Count == 1 )
            targetGroupNode.Expand();

         treeServerGroups.SelectedNode = newNode;
         
         dirty = true;
         treeServerGroups.Select();
      }
      
      #endregion
      
      #region Delete Group
            
      private void buttonDeleteGroup_Click( object sender, EventArgs e )
      {
         DeleteGroup();
      }
      private void contextMenuDeleteGroup_Click( object sender, EventArgs e )
      {
         DeleteGroup();
      }      
      private void DeleteGroup()
      {
         if ( treeServerGroups.SelectedNode == null ) return;

         if (Messaging.ShowConfirmation("This will remove the selected Server Group and all its children.\r\n\r\n Do you want to continue?", "Delete Server Group") == DialogResult.Yes)
         {
            dirty = true;
            treeServerGroups.SelectedNode.Remove();
            treeServerGroups.Select();
         }
      }
      
      #endregion

      #region Rename Group
      
      private void buttonModifyGroup_Click( object sender, EventArgs e )
      {
         RenameGroup();
      }
      private void contextMenuRenameGroup_Click( object sender, EventArgs e )
      {
         RenameGroup();
      }
      
      private void RenameGroup()
      {
         if ( treeServerGroups.SelectedNode == null ) return;

         Form_RenameServerGroup frm = new Form_RenameServerGroup( true, treeServerGroups.SelectedNode.Text );

         bool duplicates = true;         
         while ( duplicates )
         {
            DialogResult choice = frm.ShowDialog();
            if (choice == DialogResult.OK)
            {
               // dummy node for existence check
               TreeNode newGroupNode = new TreeNode(frm.NewName);
               newGroupNode.ImageIndex = 0;

               if (!NodeExists(treeServerGroups.SelectedNode.Parent, newGroupNode))
               {
                  duplicates = false;

                  treeServerGroups.SelectedNode.Text = frm.NewName;
                  ((ToolServerGroup)treeServerGroups.SelectedNode.Tag).Name = frm.NewName;
                  
                  dirty = true;
               }
               else
               {
                  Messaging.ShowInformation("A server group by that name already exists. Please specify a unique name for the server group.", "Rename Server Group");
               }
            }
            else
            {
               return;
            }
         }
      }
      
      #endregion
      
      #region AddServer

      private void buttonAddServer_Click( object sender, EventArgs e )
      {
         AddServer();
      }
      private void contextMenuAddServer_Click( object sender, EventArgs e )
      {
         AddServer();
      }
      
      private void AddServer()
      {
         bool duplicates = false;
         if ( treeServerGroups.SelectedNode == null ) return;
         
         TreeNode targetGroupNode = GetCorrespondingGroupNode(treeServerGroups.SelectedNode); 

         Form_AddServerToGroup frm = new Form_AddServerToGroup();
         DialogResult choice = frm.ShowDialog();
         if ( choice == DialogResult.OK )
         {
            foreach( string s in frm.serverList )
            {
               if ( s.Trim() == "" ) continue;  // skip blank server names
               
               string server = SQLHelpers.NormalizeInstanceName(s);
               ToolServer newServer    = new ToolServer( server, frm.sqlCredentials );
               TreeNode node           = new TreeNode( server );
               node.Tag                = newServer;
               
               if ( frm.sqlCredentials == null || frm.sqlCredentials.useWindowsAuthentication )
               {
                  node.ImageIndex         = 1;
                  node.SelectedImageIndex = 1;
               }
               else
               {
                  node.ImageIndex         = 2;
                  node.SelectedImageIndex = 2;
               }
               
               if ( ! NodeExists( targetGroupNode, node ) )
               {
                  targetGroupNode.Nodes.Add( node );
                  if ( targetGroupNode.Nodes.Count == 1 )
                    targetGroupNode.Expand();
               }
               else
               {
                  duplicates = true;
               }
            }
            if ( duplicates )
            {
               Messaging.ShowInformation( "Some of the specified servers already exist in the selected Server Group and were not added", "Add Server To Server Group" );
            }
            dirty = true;
         }
         treeServerGroups.Select();
      }
      
      #endregion
      
      #region Remove Server

      private void buttonRemoveServer_Click( object sender, EventArgs e )
      {
         RemoveServer();
      }
      private void contextMenuRemoveServer_Click( object sender, EventArgs e )
      {
         RemoveServer();
      }
      
      private void RemoveServer()
      {
         if ( treeServerGroups.SelectedNode == null ) return;

         if (Messaging.ShowConfirmation("This will remove the selected Server.\r\n\r\n Do you want to continue?", "Remove Server") == DialogResult.Yes)
         {
            dirty = true;
            treeServerGroups.SelectedNode.Remove();
            treeServerGroups.Select();
         }
      }
      
      #endregion
      
      #region Set Server Credentials

      private void buttonSetServerCredentials_Click( object sender, EventArgs e )
      {
         SetServerCredentials();
      }
      private void contextMenuSetServerCredentials_Click( object sender, EventArgs e )
      {
         SetServerCredentials();
      }
      
      private void SetServerCredentials()
      {
         if  ( ( treeServerGroups.SelectedNode == null )
               || ( treeServerGroups.SelectedNode.ImageIndex == 0 ) )
         {      
            return;
         }
         
         Form_Credentials frm = new Form_Credentials( ((ToolServer)treeServerGroups.SelectedNode.Tag).Name,
                                                      ((ToolServer)treeServerGroups.SelectedNode.Tag).Credentials );
         frm.Title = "Set Server Credentials";
         DialogResult choice = frm.ShowDialog();
         if ( choice == DialogResult.OK )
         {
            ((ToolServer)treeServerGroups.SelectedNode.Tag).Credentials = frm.sqlCredentials;
            
            if ( frm.sqlCredentials == null || frm.sqlCredentials.useWindowsAuthentication )
            {
               treeServerGroups.SelectedNode.ImageIndex = 1;
               treeServerGroups.SelectedNode.SelectedImageIndex = 1;
            }
            else
            {
               treeServerGroups.SelectedNode.ImageIndex = 2;
               treeServerGroups.SelectedNode.SelectedImageIndex = 2;
            }
            
            dirty = true;
         }
      }

      #endregion

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
            found = true;
            if ( node.Text.Trim().ToUpper() != newNode.Text.Trim().ToUpper() ) found = false;
            if ( node.ImageIndex == 0 && newNode.ImageIndex != 0 ) found = false;
            if ( node.ImageIndex != 0 && newNode.ImageIndex == 0 ) found = false;
            
            if ( found )   
            {
               break;
            }
         }
         return found;
      }
      
      #endregion
      
      #region OK

      private void buttonOK_Click( object sender, EventArgs e )
      {
         if ( dirty )
         {
            // check if a write occurred in another tool while we were in this dialog
             if (ToolServerGroup.IsOnDiskFileGroupListNewer())
            {
               DialogResult choice = Messaging.ShowConfirmation( 
                  "Warning: The Server Group definitions were changed in another tool while this window was open. " +
                  "If you save now, you will overwrite and lose the changes made in the other tool. We suggest that " +
                  "you cancel this operation, reopen the form and make your changes again to avoid losing work.\r\n\r\n" +
                  "Do you want to continue and overrite the changes made in the other tool?",
                  "Warning: Conflicting Server Group Changes" );
               if ( choice == DialogResult.No )
               {
                  DialogResult = DialogResult.None;
                  return;
               }
            }
            
            // rebuild global groups list
            CoreGlobals.ServerGroupList.DisposeGroup();
            
            foreach (TreeNode node in treeServerGroups.Nodes[0].Nodes )
            {
               ToolServerGroup group = new ToolServerGroup( node.Text, CoreGlobals.ServerGroupList );
               CoreGlobals.ServerGroupList.Groups.Add( group );
               AddChildren( node, group );
            }
            
            // write to disk
            ToolServerGroup.WriteGlobalGroupList();
            
            CoreGlobals.ServerGroupList.RaiseServerGroupsChangedEvent();
            
            DialogResult = DialogResult.OK;
         }
         else
         {
            DialogResult = DialogResult.Cancel;
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
               ToolServerGroup group = new ToolServerGroup( node.Text, parentGroup );
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

      #endregion

      private void buttonCancel_Click( object sender, EventArgs e )
      {
         if ( dirty )
         {
            DialogResult choice = Messaging.ShowConfirmation( "The changes you have made to your Server Group definitions will be lost if you continue.\r\nDo you want to continue and lose your changes?" ); 
            if ( choice == DialogResult.Yes )
            {
               DialogResult = DialogResult.Cancel;
            }
            else
            {
               DialogResult = DialogResult.None;
            }
         }
         else
            DialogResult = DialogResult.Cancel;
      }

      private void contextMenuRefresh_Click( object sender, EventArgs e )
      {
         // reload server groups from disk
          ToolServerGroup.ReadGlobalGroupList();
         LoadServerGroups();
         CoreGlobals.ServerGroupList.RaiseServerGroupsChangedEvent();
     }

      private void contextMenuTextConnection_Click( object sender, EventArgs e )
      {
         if ( treeServerGroups.SelectedNode == null ) return;
         
         try
         {
            Cursor = Cursors.WaitCursor;
            
            SQLCredentials cred = ((ToolServer)treeServerGroups.SelectedNode.Tag).Credentials;
            if ( cred == null )
            {
               cred = new SQLCredentials(false);
            }
            
            Connection.TestConnection( ((ToolServer)treeServerGroups.SelectedNode.Tag).Name,
                                       cred.useSqlAuthentication,
                                       cred.loginName,
                                       cred.password );
          }
          finally
          {
             Cursor = Cursors.Default;
          }
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
            ResetContextMenu();
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
            ResetContextMenu();
            contextMenuStrip1.Show( treeServerGroups, pt );
         }
      }
      
      private void ResetContextMenu()
      {
      }
      
#endregion      

      private void buttonRenameServer_Click( object sender, EventArgs e )
      {
         RenameServer();
      }

      private void contextMenuRenameServer_Click( object sender, EventArgs e )
      {
         RenameServer();
      }
      
      private void RenameServer()
      {
         if ( treeServerGroups.SelectedNode == null ) return;

         Form_RenameServerGroup frm = new Form_RenameServerGroup( false, treeServerGroups.SelectedNode.Text );

         bool duplicates = true;         
         while ( duplicates )
         {
            DialogResult choice = frm.ShowDialog();
            if (choice == DialogResult.OK)
            {
               // dummy node for existence check
               TreeNode newServerNode = new TreeNode(frm.NewName);
               newServerNode.ImageIndex = treeServerGroups.SelectedNode.ImageIndex;

               if (!NodeExists(treeServerGroups.SelectedNode.Parent, newServerNode))
               {
                  duplicates = false;

                  treeServerGroups.SelectedNode.Text = frm.NewName;
                  ((ToolServer)treeServerGroups.SelectedNode.Tag).Name = frm.NewName;
                  
                  dirty = true;
               }
               else
               {
                  Messaging.ShowInformation("A server by that name already exists in this server group.", "Rename Server");
               }
            }
            else
            {
               return;
            }
         }
      }

      private void Form_ManageServerGroups_HelpRequested( object sender, HelpEventArgs hlpevent )
      {
         HelpMenu.ShowHelp( DisplayHelp.SERVERGROUPS );
      }
   }
   
   #region Class NodeSorter - Compare Routine for Tree

   // Create a node sorter that implements the IComparer interface.
   public class NodeSorter : IComparer
   {
       public int Compare(object x, object y)
       {
           TreeNode tx = x as TreeNode;
           TreeNode ty = y as TreeNode;
           
           if ( tx.ImageIndex != ty.ImageIndex )
           {
              if ( tx.ImageIndex == 0 )
                 return 1;
              else
                 return -1;
           }
           else
           {
              return string.Compare(tx.Text, ty.Text);
           }           
       }
   }

   #endregion
   
}