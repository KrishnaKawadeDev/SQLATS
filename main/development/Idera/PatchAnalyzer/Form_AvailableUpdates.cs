using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.PatchAnalyzer
{
   public partial class Form_AvailableUpdates : Form
   {
      string m_server;
      string m_build;
      int    m_serverListIndex;
      
      public
         Form_AvailableUpdates(
            string    server,
            string    build,
            int       serverListIndex
         )
      {
         InitializeComponent();
         
         m_server          = server;
         m_build          = build;
         m_serverListIndex = serverListIndex;
      }

      protected override void OnLoad( EventArgs e )
      {
         base.OnLoad( e );
         
         // update group title
         textServer.Text = m_server;         
         textBuild.Text  = m_build;         
         
         // fill list box
         listViewSQL.Items.Clear();

         List<SQLServerVersion> availableUpdates = SQLServerVersion.GetAvailableUpdates( m_serverListIndex );
         
         foreach( SQLServerVersion sqlServerVersion in availableUpdates )
         {
				if (!sqlServerVersion.Level.Contains("CTP")) //CGVAK -Skip the CTP version 
				{ 
					ListViewItem lvi = listViewSQL.Items.Add( sqlServerVersion.Version);
					lvi.SubItems.Add( sqlServerVersion.KbTitle );
					lvi.SubItems.Add( sqlServerVersion.SupportStatus );
					lvi.SubItems.Add( sqlServerVersion.Url );

					// set group
					int groupIndex = 0;
					switch( sqlServerVersion.Level.Substring(0,3) )
					{
						case "SP1": groupIndex = 1; break;
						case "SP2": groupIndex = 2; break;
						case "SP3": groupIndex = 3; break;
						case "SP4": groupIndex = 4; break;
						case "SP5": groupIndex = 5; break;
						case "SP6": groupIndex = 6; break;
						case "SP7": groupIndex = 7; break;
						case "SP8": groupIndex = 8; break;
						case "SP9": groupIndex = 9; break;
					}
					lvi.Group = listViewSQL.Groups[groupIndex];
					}
         }
         
         listViewSQL.ListViewItemSorter = new ListViewItemComparer( 0, System.Windows.Forms.SortOrder.Ascending );
         listViewSQL.Sort();
         
         if ( listViewSQL.Items.Count > 0 )
         {
            listViewSQL.Items[0].Selected = true;
            listViewSQL.Select();
         }
      }

      private void buttonViewKbArticle_Click( object sender, EventArgs e )
      {
         ViewKbArticle();
      }
      private void contextViewKnowledgeBaseArticle_Click( object sender, EventArgs e )
      {
         ViewKbArticle();
      }
      
      private void listViewSQL_DoubleClick( object sender, EventArgs e )
      {
         if ( listViewSQL.SelectedItems.Count == 1 ) ViewKbArticle();
      }
      
      private void ViewKbArticle()
      {
         if ( listViewSQL.SelectedItems.Count == 0 ) return;
         string url = listViewSQL.SelectedItems[0].SubItems[3].Text;
         Form_Main.ViewKnowledgeBaseArticle( url );
      }

      private void listViewSQL_SelectedIndexChanged( object sender, EventArgs e )
      {
         bool enabled = false;
         if ( listViewSQL.SelectedItems.Count !=0 )
         {
            string url = listViewSQL.SelectedItems[0].SubItems[3].Text;
            if ( url!=null && url != "" && url.ToUpper()!= "NONE" )
               enabled = true;
         }
         contextViewKnowledgeBaseArticle.Enabled = enabled;
         buttonViewKbArticle.Enabled = enabled;
      }
      
      #region Column Sorting

      private int                            sortColumn = -1;
      private System.Windows.Forms.SortOrder sortOrder  = System.Windows.Forms.SortOrder.Ascending;

      private void ResetSort()
      {
         sortColumn = -1;
         listViewSQL.Sorting = sortOrder;
      }

      private void listSQL_ColumnClick( object sender, ColumnClickEventArgs e )
      {
         // Determine whether the column is the same as the last column clicked.
         if ( e.Column != sortColumn )
         {
            // Set the sort column to the new column.
            sortColumn = e.Column;

            // Set the sort order to ascending by default.
            listViewSQL.Sorting = sortOrder;
         }
         else
         {
            // Determine what the last sort order was and change it.
            if ( listViewSQL.Sorting == System.Windows.Forms.SortOrder.Ascending )
               listViewSQL.Sorting = System.Windows.Forms.SortOrder.Descending;
            else
               listViewSQL.Sorting = System.Windows.Forms.SortOrder.Ascending;
         }

         listViewSQL.ListViewItemSorter = new ListViewItemComparer( e.Column, listViewSQL.Sorting );
         listViewSQL.Sort();
      }

      // Implements the manual sorting of items by column.
      class ListViewItemComparer : IComparer
      {
          private int col;
          private System.Windows.Forms.SortOrder order;

          public ListViewItemComparer()
          {
              col=0;
              order = System.Windows.Forms.SortOrder.Ascending;
          }

         public ListViewItemComparer( int column, System.Windows.Forms.SortOrder order ) 
          {
              col           = column;
              this.order    = order;
          }

          public int Compare(object x, object y) 
          {
            int returnVal = -1;
            ListViewItem lv1= (ListViewItem)x;
            ListViewItem lv2= (ListViewItem)y;
            
            
            if ( col == 1 /* build */ )
            {
               returnVal = Helpers.CompareVersionString( lv1.SubItems[col].Text,
                                                         lv2.SubItems[col].Text );
            }
            else
            {
               /* the rest of the columns are simple strings */
               returnVal = String.Compare( lv1.SubItems[col].Text,
                                           lv2.SubItems[col].Text );
            }                                        
            
            if ( order == System.Windows.Forms.SortOrder.Descending ) returnVal *= -1;

            return returnVal;
          }
      }
      #endregion

   }
}