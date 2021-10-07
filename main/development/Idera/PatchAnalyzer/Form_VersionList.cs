using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.PatchAnalyzer
{
   public partial class Form_VersionList : Form
   {
      public Form_VersionList()
      {
         InitializeComponent();
      }

      protected override void OnLoad( EventArgs e )
      {
         base.OnLoad( e );
         
         if ( SQLServerVersion.SqlServerVersionDate == DateTime.MinValue )
         {
             labelPatchVersionValue.Text = "<Unknown>";
         }
         else
         {
             labelPatchVersionValue.Text = SQLServerVersion.SqlServerVersionDate.ToShortDateString();
         }
         
         // fill list box
         listViewSQL.Items.Clear();
         foreach( SQLServerVersion sqlServerVersion in SQLServerVersion.SqlServerVersionList.OrderByDescending(x=>x.Minor).OrderByDescending(x=>x.Major) )
         {
           ListViewItem lvi = listViewSQL.Items.Add( sqlServerVersion.Version );
           lvi.SubItems.Add( sqlServerVersion.Product );
           lvi.SubItems.Add( sqlServerVersion.Level );
           lvi.SubItems.Add( sqlServerVersion.Supported );
           lvi.SubItems.Add( sqlServerVersion.SupportStatus );
           lvi.SubItems.Add( sqlServerVersion.KbTitle );
           lvi.SubItems.Add( sqlServerVersion.Url );
           
           int groupIndex = 0;
           bool indexfound = false;
                //switch (sqlServerVersion.Major)
                //{
                //    case 13: groupIndex = 1; break;
                //    case 12: groupIndex = 2; break;
                //    case 11: groupIndex = 3; break;
                //    case 10:
                //        if (sqlServerVersion.Minor == 50)
                //            groupIndex = 4;
                //        else
                //            groupIndex = 5;
                //        break;
                //    case 9: groupIndex = 6; break;
                //    case 8: groupIndex = 7; break;
                //    case 7: groupIndex = 8; break;
                //    case 6: groupIndex = 9; break;
                //    default: indexfound = false; break;
                //}


                for (int i = 1; i < listViewSQL.Groups.Count; i++)
                {

                    if (!string.IsNullOrEmpty(sqlServerVersion.Product) && listViewSQL.Groups[i].Header.ToLower() == sqlServerVersion.Product.ToLower())
                    {
                        groupIndex = i;
                        indexfound = true;
                        break;
                    }
                    else if (sqlServerVersion.Major == 7 && listViewSQL.Groups[i].Header.ToLower() == ("SQL Server 7.0").ToLower())
                    {
                        groupIndex = i;
                        indexfound = true;
                        break;
                    }
                    else if (sqlServerVersion.Major == 6 && listViewSQL.Groups[i].Header.ToLower() == ("SQL Server 6.5").ToLower())
                    {
                        groupIndex = i;
                        indexfound = true;
                        break;
                    }

                }
                if (!indexfound)
                {
                    if (!string.IsNullOrEmpty(sqlServerVersion.Product))
                    {
                        var grp = new ListViewGroup(sqlServerVersion.Product, HorizontalAlignment.Left);
                        listViewSQL.Groups.Add(grp);
                        groupIndex = listViewSQL.Groups.Count - 1;
                        indexfound = true;
                    }
                    else if (sqlServerVersion.Major == 7)
                    {
                        var grp = new ListViewGroup("SQL Server 7.0", HorizontalAlignment.Left);
                        listViewSQL.Groups.Add(grp);
                        groupIndex = listViewSQL.Groups.Count - 1;
                        indexfound = true;
                    }
                    else if (sqlServerVersion.Major == 6)
                    {
                        var grp = new ListViewGroup("SQL Server 6.5", HorizontalAlignment.Left);
                        listViewSQL.Groups.Add(grp);
                        groupIndex = listViewSQL.Groups.Count - 1;
                        indexfound = true;
                    }
                }
                lvi.Group = listViewSQL.Groups[groupIndex];
         }
         
         listViewSQL.ListViewItemSorter = new ListViewItemComparer( 0, System.Windows.Forms.SortOrder.Descending );
         listViewSQL.Sort();
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
         string url = listViewSQL.SelectedItems[0].SubItems[6].Text;
         Form_Main.ViewKnowledgeBaseArticle( url );
      }

      private void listViewSQL_SelectedIndexChanged( object sender, EventArgs e )
      {
         bool enabled = false;
         if ( listViewSQL.SelectedItems.Count !=0 )
         {
            string url = listViewSQL.SelectedItems[0].SubItems[6].Text;
            if ( url!=null && url != "" && url.ToUpper()!= "NONE" )
               enabled = true;
         }
         contextViewKnowledgeBaseArticle.Enabled = enabled;
         buttonViewKbArticle.Enabled = enabled;
      }

      private void linkCheckVersionList_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
      {

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

            if ( col == 0 /* build */ )
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