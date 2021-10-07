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
using System.Collections;
using System.Collections.Generic;

namespace Idera.SqlAdminToolset.MultiQuery
{
  public partial class Form_SelectQueryTargets : Form
  {
    public List<QueryTarget> selectedQueryTargets
    {
       get
       {
          List<QueryTarget> listQueryTarget = new List<QueryTarget>();
          
          foreach ( ListViewItem lvi in listTargets.CheckedItems )
          {
             listQueryTarget.Add( (QueryTarget)lvi.Tag );
          }
          
          return listQueryTarget;
       }
    }
    
    public Form_SelectQueryTargets( DevComponents.DotNetBar.Controls.ListViewEx listview )
    {
      InitializeComponent();
      
      foreach ( ListViewItem lvi in listview.Items )
      {
         // add to list
         ListViewItem newlvi = new ListViewItem( "" );
         newlvi.SubItems.Add( lvi.SubItems[1] );  // server
         newlvi.SubItems.Add( (lvi.ImageIndex==0) ? "Server" 
                            : (lvi.ImageIndex==1) ? "Server w/SQL"
                                                  : "Server Group" );  
         newlvi.SubItems.Add( lvi.SubItems[2] );
         newlvi.Tag        = lvi.Tag;
         
         listTargets.Items.Add( newlvi );
      }
      
        listTargets.Select();
    }

     private void buttonOK_Click( object sender, EventArgs e )
     {
        if ( listTargets.CheckedItems.Count == 0 )
        {
           DialogResult = DialogResult.None;
           buttonOK.Enabled = false;
        }
        else
        {
           DialogResult = DialogResult.OK;
        }
     }
     
      private void checklistServers_ItemChecked( object sender, ItemCheckedEventArgs e )
      {
         buttonOK.Enabled = ( listTargets.CheckedItems.Count != 0 );
      }

      private void buttonSelectAll_Click( object sender, EventArgs e )
      {
         foreach ( ListViewItem lvi in listTargets.Items )
         {
            lvi.Checked = true;
         }
      } 

      private void buttonClearAll_Click( object sender, EventArgs e )
      {
         foreach ( ListViewItem lvi in listTargets.Items )
         {
            lvi.Checked = false;
         }
      }
   }
}