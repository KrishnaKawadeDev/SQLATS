using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Smo = Microsoft.SqlServer.Management.Smo;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.BackupStatus
{
   public partial class BackupHistory : Form
   {
      private string         m_server;
      private string         m_database;
      private SQLCredentials m_sqlCredentials;

      public BackupHistory( 
         string         inServer,
         SQLCredentials inSqlCredentials,
         string         inDatabase )
      {
         InitializeComponent();

         m_server         = inServer;
         m_sqlCredentials = inSqlCredentials;
         m_database       = inDatabase;

         groupPanel1.Text = "Backup History for " + inServer + "\\" + inDatabase;
      }

      private void buttonClose_Click( object sender, EventArgs e )
      {
         Close();
      }

      protected override void OnLoad( EventArgs e )
      {
         base.OnLoad( e );

         LoadBackupHistory();
      }

      #region LoadBackupHistory routine
      
      ICollection m_results = null;

      private void LoadBackupHistory()
      {
         try
         {
            Cursor = Cursors.WaitCursor;
            labelBackupStatus.Text = "Loading backup history...";
            labelBackupStatus.Visible = true;
            labelEmptyResultSet.Visible = false;

            // Set up ListView Columns
            listResults.Items.Clear();
            Application.DoEvents();

            // Get data for list
            BackgroundWorker _BackgroundWorker = new BackgroundWorker();
            _BackgroundWorker.DoWork += new DoWorkEventHandler(BackgroundLoadResults);
            _BackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ShowBackupHistoryOnceLoaded);
            _BackgroundWorker.RunWorkerAsync();
         }
         catch      
         {
            labelBackupStatus.Text = "";
            labelEmptyResultSet.Text = "Could not retrieve backup history";
            labelEmptyResultSet.Visible = true;
            
            Cursor = Cursors.Default;
         }
      }
      
      void BackgroundLoadResults(object sender, DoWorkEventArgs e)
      {
         m_results = BackupRoutines.LoadBackupHistory( m_server, m_sqlCredentials, m_database, checkLimitHistory.Checked );
      }
      
      void ShowBackupHistoryOnceLoaded(object sender, RunWorkerCompletedEventArgs e)
      {
         try
         {
            if ( m_results != null && m_results.Count!=0)
            {
               foreach ( BackupResult result in m_results )
               {
                  ListViewItem r = new ListViewItem( result.lastBackup.ToString() );
                  r.SubItems.Add( result.backupType );
                  r.SubItems.Add( Helpers.StrFormatByteSize( result.backupSize ) );
                  r.SubItems.Add( result.backupUser );
                  r.SubItems.Add( result.backupPath );
                  
                  r.ToolTipText = result.backupPath;
                  
                  r.Tag = result;
                  listResults.Items.Add( r );
               }

               if ( m_results.Count != 0 )
               {
                  listResults.Select();
                  listResults.Items[0].Selected = true;
                  buttonCopyToClipboard.Enabled = true;
                  contextMenuCopyToClipboard.Enabled = true;
               }

               labelBackupStatus.Text = String.Format( "{0} records available in the backup history.",
                                                       listResults.Items.Count );
            }
            else
            {
               labelBackupStatus.Text = "";
               labelEmptyResultSet.Text = String.Format( "The backup history for {0} is empty.",
                                                         m_database );
               labelEmptyResultSet.Visible = true;
            }
         }
         catch      
         {
            labelBackupStatus.Text = "";
            labelEmptyResultSet.Text = "Could not retrieve backup history";
            labelEmptyResultSet.Visible = true;
         }
         finally
         {
            Cursor = Cursors.Default;
         }
      }

      #region Column Sorting

      private int                            sortColumn = -1;
      private System.Windows.Forms.SortOrder sortOrder  = System.Windows.Forms.SortOrder.Ascending;

      private void ResetSort()
      {
         sortColumn = -1;
         listResults.Sorting = sortOrder;
      }

      private void listResults_ColumnClick( object sender, ColumnClickEventArgs e )
      {
         // Determine whether the column is the same as the last column clicked.
         if ( e.Column != sortColumn )
         {
            // Set the sort column to the new column.
            sortColumn = e.Column;

            // Set the sort order to ascending by default.
            listResults.Sorting = sortOrder;
         }
         else
         {
            // Determine what the last sort order was and change it.
            if ( listResults.Sorting == System.Windows.Forms.SortOrder.Ascending )
               listResults.Sorting = System.Windows.Forms.SortOrder.Descending;
            else
               listResults.Sorting = System.Windows.Forms.SortOrder.Ascending;
         }

         listResults.ListViewItemSorter = new ListViewItemComparer( e.Column, listResults.Sorting );
         listResults.Sort();
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
            BackupResult br1 = (BackupResult)(((ListViewItem)x).Tag);
            BackupResult br2 = (BackupResult)(((ListViewItem)y).Tag); 

            if ( col == 0 /* Last Backup Date */ )
            {
               returnVal = DateTime.Compare( br1.lastBackup, br2.lastBackup );
            }
            else if ( col == 2 /* Backup Size */ )
            {
               returnVal = 0;
               if ( br1.backupSize < br2.backupSize ) returnVal = -1;
               if ( br1.backupSize > br2.backupSize ) returnVal = 1;
            }
            else /* the rest of the columns are simple strings */
            {
                returnVal = String.Compare( ((ListViewItem)x).SubItems[col].Text,
                                            ((ListViewItem)y).SubItems[col].Text );
            }
            
            if ( order == System.Windows.Forms.SortOrder.Descending ) returnVal *= -1;

            return returnVal;
          }
      }
      #endregion

      private void buttonCopyToClipboard_Click( object sender, EventArgs e )
      {
         CopyToClipboard();
      }

      private void CopyToClipboard()
      {
         string heading = String.Format( "Server: {0}\r\nDatabase: {1}",
                                         m_server,
                                         m_database );
         ExportToClipboard.CopyListViewToTabbedFormat(heading, listResults, false, false);
      }

      #endregion

      #region Context Menu Handlers

      private void contextMenuCopyToClipboard_Click( object sender, EventArgs e )
      {
         CopyToClipboard();
      }

      private void contextMenuRefresh_Click( object sender, EventArgs e )
      {
         LoadBackupHistory();
      }

      #endregion

      private void checkLimitHistory_CheckedChanged( object sender, EventArgs e )
      {
         LoadBackupHistory();
      }
   }
}