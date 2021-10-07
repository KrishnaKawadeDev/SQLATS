#region SQL admin toolset © 2007, 2008 BBS Technologies, Inc. and Idera.

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
  public partial class Form_SelectSaveResultsAs: Form
  {
    public Form_SelectSaveResultsAs(
       bool showSummary,
       bool showCombined,
       bool showIndividual,
       List<MultiQueryResult> mqrList )
    {
      InitializeComponent();
      
      if ( showSummary )
      {
         ListViewItem lvi = new ListViewItem( "" );
         lvi.SubItems.Add( "Summary" );
         listTargets.Items.Add( lvi );
      }
      
      if ( showCombined )
      {
         ListViewItem lvi = new ListViewItem( "" );
         lvi.SubItems.Add( "Combined Results" );
         listTargets.Items.Add( lvi );
      }

      if ( showIndividual )
      {      
         foreach( MultiQueryResult mqr in mqrList )
         {
            // add to list
            ListViewItem lvi = new ListViewItem( "" );
            
            string name = mqr.server;
            
            if ( ! String.IsNullOrEmpty(mqr.database) )
            {
               name += "." + mqr.database;
            }
            lvi.SubItems.Add( name );
            
            if ( mqr.cancelled )
               lvi.SubItems.Add( "Cancelled" );
            else if ( mqr.succeeded )
               lvi.SubItems.Add( "Succeeded" );
            else   
               lvi.SubItems.Add( "Failed" );
            
            listTargets.Items.Add( lvi );
         }
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