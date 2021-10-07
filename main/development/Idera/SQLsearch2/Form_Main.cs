using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Smo = Microsoft.SqlServer.Management.Smo;
using System.Runtime.InteropServices;

using Idera.SqlAdminToolset.Core;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.SqlSearch
{
    public partial class Form_Main : Form
    {
        #region Properties

        SQLCredentials sqlCredentials = null;
        
        private JobPool<IList>                   m_JobPool;
        public static Dictionary<string, string> _ErrorReports = new Dictionary<string, string>();

        private ToolProgressBarDialog _ProgressDialog;
        
        private bool m_saveIncludeSystem;
        

        
        #endregion

        #region Constructor

        public Form_Main()
        {
            InitializeComponent();
            this.Text = ideraTitleBar1.IderaProductNameText;
        }
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x00C00000; // remove WS_CAPTION
                parms.Style |= 0x00040000;  // include WS_SIZEBOX
                return parms;
            }
        }
        #endregion

        #region OnLoad (Common)

        protected override void OnLoad(EventArgs e)
        {
           #region Common Onload code

           base.OnLoad( e );
           if ( !Startup.GuiStartup( this, menuTools, menuAbout, ideraTitleBar1) )
           {
              Close();
              return;
           }

           #endregion
           
           ProductConstants.ReadOptions();
           textServer.Text     = ProductConstants.lastServer;
           textDatabase.Text   = ProductConstants.lastDatabase;
           textSearchText.Text = ProductConstants.lastSearch;
           sqlCredentials      = ProductConstants.lastCredentials;

           SetSearchButtonEnabled();
           buttonBrowseDatabase.Enabled = textServer.Text.Trim().Length != 0;
           
           m_saveIncludeSystem = false;
        }

       #endregion

        #region Common Code

        #region File Menu Event Handlers (Common)

        private void menuFileExit_Click( object sender, EventArgs e )
        {
           Close();
        }

        private void menuExitToLaunchpad_Click( object sender, EventArgs e )
        {
           Launchpad.RunAndClose( this );
        }

        #endregion

        #region Help Menu Event Handlers (Common)

        private void menuShowHelp_Click( object sender, EventArgs e )
        {
           HelpMenu.ShowHelp();
        }

        private void menuDeactivateLicense_Click( object sender, EventArgs e )
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }

       

        private void menuAbout_Click( object sender, EventArgs e )
        {
           HelpMenu.ShowAboutForm();
        }

        private void menuSearchIderaKnowledgeBase_Click( object sender, EventArgs e )
        {
           HelpMenu.ShowURL_SearchIderaKnowledgeBase( this );
        }

        private void menuAboutIderaProducts_Click( object sender, EventArgs e )
        {
           HelpMenu.ShowURL_AboutIderaProducts( this );
        }

        private void menuContactTechnicalSupport_Click( object sender, EventArgs e )
        {
           HelpMenu.ShowURL_ContactTechnicalSupport( this );
        }

        private void menuCheckForUpdates_Click( object sender, EventArgs e )
        {
           HelpMenu.CheckForUpdates( this );
        }

        #endregion

        #region Tools Menu (Common )

        private void menuManageServerGroups_Click( object sender, EventArgs e )
        {
           ToolsMenu.ManageServerGroups();
        }
       
        private void menuToolsetOptions_Click( object sender, EventArgs e )
        {
           ToolsMenu.ShowToolsetOptions();
        }

        private void menuLaunchpad_Click( object sender, EventArgs e )
        {
           ToolsMenu.RunLaunchpad( this );
        }

        #endregion

        #endregion

        #region Control Events

        private void textServer_TextChanged(object sender, EventArgs e)
        {
            SetSearchButtonEnabled();

            buttonBrowseDatabase.Enabled = textServer.Text.Trim().Length != 0;
        }

        private void SetSearchButtonEnabled()
        {
            buttonSearch.Enabled = (textServer.Text.Trim().Length != 0) 
                                     && (textSearchText.Text.Trim().Length != 0) 
                                     && ( checkStoredProcedures.Checked
                                           || checkTriggers.Checked
                                           || checkFunctions.Checked
                                           || checkViews.Checked
                                           || checkJobs.Checked
                                            );
        }

        private void textSearchText_TextChanged(object sender, EventArgs e)
        {
            SetSearchButtonEnabled();
        }

        private void listResults_SelectedIndexChanged(object sender, EventArgs e)
        {
           bool someSelected = (listResults.SelectedItems.Count != 0);

           buttonView.Enabled               = someSelected;
           contextMenuViewSQLSource.Enabled = someSelected;
           menuCopy.Enabled                 = someSelected;
           contextMenuCopy.Enabled          = someSelected;
        }

        private void checkStoredProcedures_CheckedChanged(object sender, EventArgs e)
        {
            SetSearchButtonEnabled();
        }

        private void checkViews_CheckedChanged(object sender, EventArgs e)
        {
            SetSearchButtonEnabled();
        }

        private void checkFunctions_CheckedChanged(object sender, EventArgs e)
        {
            SetSearchButtonEnabled();
        }

        private void checkTriggers_CheckedChanged(object sender, EventArgs e)
        {
            SetSearchButtonEnabled();
        }
        
        private void checkJobs_CheckedChanged( object sender, EventArgs e )
        {
           SetSearchButtonEnabled();
        }

        private void buttonCredentials_Click(object sender, EventArgs e)
        {
            Form_Credentials credentialsForm = new Form_Credentials( textServer.Text, sqlCredentials );
            DialogResult choice = credentialsForm.ShowDialog();
            if (choice == DialogResult.OK)
            {
                sqlCredentials = credentialsForm.sqlCredentials;
            }
        }
        
        #endregion
        
        #region Clipboard

        private void buttonCopyToClipboard_Click(object sender, EventArgs e)
        {
           CopyToClipboard( false );
        }
        
        private void menuCopy_Click( object sender, EventArgs e )
        {
           CopyToClipboard( true );
        }
          
        private void contextMenuCopy_Click( object sender, EventArgs e )
        {
           CopyToClipboard( true );
        }

        private void CopyToClipboard( bool selectedOnly )
        {
           ExportToClipboard.CopyListViewToTabbedFormat( listResults, false, selectedOnly  );
        }

        private void CopyReportToClipboard()
        {
           int[] columnWidths = { 20,   // database
                                  25,   // tablename
                                  16,   // type
                                  40};  // excerpt
           ExportToClipboard.CopyListView( groupResults.Text,
                                           listResults,
                                           columnWidths, 
                                           false );
       }
       
       private void menuSelectAll_Click( object sender, EventArgs e )
       {
          SelectAll();
       }

       private void contextMenuSelectAll_Click( object sender, EventArgs e )
       {
          SelectAll();
       }
       
       private void SelectAll()
       {
          foreach( ListViewItem lvi in listResults.Items )
          {
             lvi.Selected = true;
          }
       }

       #endregion

        #region Perform Search

        // save variables for viewing sp later if user is editing criteria while results are shown
        private string saveSearchString   = "";
        private bool   saveMatchCase      = false;
        private bool   saveAllowWildcards = false;

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //listResults.OwnerDraw = true;
            //listResults.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listResults_DrawColumnHeader);
            
            //listResults.DrawColumnHeader +=
            //    new DrawListViewColumnHeaderEventHandler
            //    (
            //        (sender, e) => headerDraw(sender, e, backColor, foreColor)
            //    );
            PerformSearch();
        }

        private void PerformSearch()
        {
            // confirm that they meant to start search if search is < 3 characters
            if ( textSearchText.Text.Length < 3 )
            {
               DialogResult choice = Messaging.ShowConfirmation( "It is not recommended that you perform searches " + 
                                                                 "with very short strings because of the high number " + 
                                                                 "of likely matches.\r\n\r\nDo you want to continue with " + 
                                                                 "the search using the specified search string?" );
               if ( choice == DialogResult.No ) 
               {
                  return;
               }
            }
            
            // save off for future defaults
            ProductConstants.lastServer      = textServer.Text;
            ProductConstants.lastDatabase    = textDatabase.Text;
            ProductConstants.lastCredentials = sqlCredentials;
            ProductConstants.lastSearch      = textSearchText.Text;
            ProductConstants.WriteOptions();
        
            saveSearchString   = textSearchText.Text;
            saveMatchCase      = checkMatchCase.Checked;
            saveAllowWildcards = checkAllowWildcards.Checked;

            try
            {
                listResults.Items.Clear();
                m_searchSucceeded = false;
                m_searchCancelled = false;
                
                buttonCopyToClipboard.Enabled = false;
                contextMenuExport.Enabled = false;
                menuExport.Enabled = false;
                contextMenuSelectAll.Enabled = false;
                menuSelectAll.Enabled = false;
                
                groupResults.Text = String.Format("Search Results for '{0}' {1}{2} on {3}",
                                                 textSearchText.Text,
                                                 String.IsNullOrEmpty(textDatabase.Text) ? "in all databases" : "in database ",
                                                 String.IsNullOrEmpty(textDatabase.Text) ? "" : textDatabase.Text,
                                                 SQLHelpers.NormalizeInstanceName(textServer.Text));
                labelNumberOfResults.Text = "Search in progress...";
                labelNumberOfResults.Visible = true;
                labelEmptyResultSet.Visible = false;
                Application.DoEvents();
                
                // set up background thread for searches                
                _ErrorReports.Clear();
                
                List<ServerInformation> _ServerList = new List<ServerInformation>();
                ServerInformation sInfo = new ServerInformation( textServer.Text, sqlCredentials );
                _ServerList.Add( sInfo );
                
                //set up search parameters
                SqlSearchHelper.databaseList           = textDatabase.Text;
                SqlSearchHelper.searchText             = textSearchText.Text;
                SqlSearchHelper.matchStoredProc        = checkStoredProcedures.Checked;
                SqlSearchHelper.matchTrigger           = checkTriggers.Checked;
                SqlSearchHelper.matchView              = checkViews.Checked;
                SqlSearchHelper.matchFunction          = checkFunctions.Checked;
                SqlSearchHelper.matchJobSteps          = checkJobs.Checked;
                SqlSearchHelper.matchCase              = checkMatchCase.Checked;
                SqlSearchHelper.allowWildcards         = checkAllowWildcards.Checked;
                SqlSearchHelper.limitResults           = radioButtonLimit.Checked;
                SqlSearchHelper.strLimit               = textLimit.Text;
                SqlSearchHelper.includeSystemDatabases = checkBoxIncludeSystemDatabases.Checked;
                
                ProgressBar_Initialize();
                 
                m_JobPool = new JobPool<IList>(1);
                m_JobPool.ServerTaskComplete += new EventHandler<JobExecutionResultsEventArgs>(JobPoolTaskComplete);
                m_JobPool.TaskComplete += new EventHandler<JobExecutionEventArgs>(AllTasksComplete);
                m_JobPool.Enqueue(SqlSearchHelper.PerformSearch, _ServerList, ToolsetOptions.commandTimeout);
                m_JobPool.StartAsync();
                
                ProgressBar_Show();
            }
            catch (Exception ex )
            {
               ProgressBar_Close();
               m_searchCancelled = false;
               m_searchSucceeded = false;
               Messaging.ShowException( "Search request failed.", ex );
            }
        }
        
        bool   m_searchCancelled = false;
        bool   m_searchSucceeded = false;
        string m_searchError   = "";
        
        void JobPoolTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            m_searchCancelled = false;
            m_searchSucceeded = false;
            
            if (e.Status == TaskStatus.Cancelled)
            {
               m_searchCancelled = true;
            }
            else if (e.Status == TaskStatus.Failed)
            {
               labelNumberOfResults.Visible = false;
               labelEmptyResultSet.Visible  = true;
               labelEmptyResultSet.Text     = "Search Failed";
               
               m_searchSucceeded = false;
               m_searchError     = e.ErrorMessage;
            }
            else
            {
               m_searchSucceeded = true;
               
               ICollection results = (ICollection)e.Resultset;
                 
               listResults.BeginUpdate();

                if ( results != null && results.Count !=0)
                {
                    foreach (SqlSearchResult result in results)
                    {
                        ListViewItem r = new ListViewItem(result.database);
                        
                        r.SubItems.Add(result.GetFullName());
                        r.SubItems.Add(result.GetObjectType());
                        r.SubItems.Add(result.sqlExcerpt);
                        r.Tag = result;
                        listResults.Items.Add(r);
                        listResults.Columns[1].Width = 345;
                      //  listResults.Columns[3].Width = 927;
                    }

                    if (results.Count != 0)
                    {
                        listResults.Items[0].Selected = true;
                        listResults.Select();

                        buttonCopyToClipboard.Enabled = true;
                        contextMenuExport.Enabled = true;
                        menuExport.Enabled = true;
                        contextMenuSelectAll.Enabled = true;
                        menuSelectAll.Enabled = true;
                     }

                    labelNumberOfResults.Text = String.Format("{0} objects found containing search string", results.Count);
                    labelNumberOfResults.Visible = true;
                 }
                else 
                {
                   labelNumberOfResults.Visible = false;
                   labelEmptyResultSet.Visible = true;
                   labelEmptyResultSet.Text = "No objects found containing search string";
                }

               listResults.EndUpdate();
            }
        }

        void AllTasksComplete(object sender, JobExecutionEventArgs e)
        {
           ProgressBar_Close();

           if ( m_searchCancelled )           
           {
               Messaging.ShowInformation( "The requested search has been cancelled." );
           }
           else if ( !m_searchSucceeded )           
           {
               string msg = String.Format( "SQL Search was unable to perform the requested search.\r\n\r\nProblem: {0}",
                                           m_searchError );

               Messaging.ShowError( msg );
            }
        }

       #endregion

        #region Show Source Code

        private void buttonView_Click(object sender, EventArgs e)
        {
            ShowSourceCode();
        }

        private void listResults_DoubleClick(object sender, EventArgs e)
        {
            ShowSourceCode();
        }


        private void ShowSourceCode()
        {
           if ( listResults.SelectedItems.Count == 0 ) return;

           SqlSearchResult r = (SqlSearchResult)listResults.SelectedItems[0].Tag;
           string fullSql = r.fullSql;
           if ( fullSql == null )
           {
               fullSql = SqlSearchHelper.GetSqlForObject( textServer.Text,
                                                          sqlCredentials,
                                                          r.database,
                                                          r.id );
           }
            
            if ( fullSql != null )
            {
                Form_SQLViewer spviewer = new Form_SQLViewer( listResults.SelectedItems[0].SubItems[0].Text, 
                                                              listResults.SelectedItems[0].SubItems[1].Text,
                                                              fullSql,
                                                              r.isJob,
                                                              r.jobInfo,
                                                              saveSearchString,
                                                              saveMatchCase,
                                                              saveAllowWildcards,
                                                              listResults.SelectedIndices[0],
                                                              listResults.Items.Count,
                                                              this );
                spviewer.ShowDialog();
            }
        }

        public string
           GetObjectSql(
              int        index,
              out string name,
              out string database,
              out bool   isJob,
              out string jobInfo
           )
        {
           if ( index < 0 || index >= listResults.Items.Count )
           {
              throw new Exception( "Invalid Index" );
           }
           
           listResults.Items[index].Selected      = true;
           listResults.Items[index].EnsureVisible();
        
           database = listResults.Items[index].SubItems[0].Text; 
           name     = listResults.Items[index].SubItems[1].Text;

           SqlSearchResult r = (SqlSearchResult)listResults.Items[index].Tag;
           string fullSql = r.fullSql;
           if ( fullSql == null )
           {
               fullSql = SqlSearchHelper.GetSqlForObject( textServer.Text,
                                                          sqlCredentials,
                                                          r.database,
                                                          r.id );
           }
           
           if ( r.isJob )
           {
              isJob = r.isJob;
              jobInfo = r.jobInfo;
           }
           else
           {
              isJob   = false;
              jobInfo = "";
           }
           
           return fullSql;
        }

       #endregion

        #region Server/Database Browse

        private void buttonBrowseServer_Click(object sender, EventArgs e)
        {
           Form_SQLServerBrowse browseDlg = new Form_SQLServerBrowse();

           Cursor = Cursors.WaitCursor;
           bool loaded = browseDlg.LoadServers();
           Cursor = Cursors.Default;
   
           if ( loaded )
           {
                DialogResult choice = browseDlg.ShowDialog();
                if ( choice == DialogResult.OK )
                {
                   if ( textServer.Text != browseDlg.SelectedServer )
                   {
                      textServer.Text = browseDlg.SelectedServer;
                   }
                }
            }
        }

        private void buttonBrowseDatabase_Click(object sender, EventArgs e)
        {
           Form_DatabaseBrowse browseDlg = new Form_DatabaseBrowse(textServer.Text, sqlCredentials);
           
           browseDlg.allowMultiSelect = true;

           Cursor = Cursors.WaitCursor;
           bool loaded = browseDlg.LoadDatabases(!checkBoxIncludeSystemDatabases.Checked);
           Cursor = Cursors.Default;
   
           if ( loaded )
           {
               DialogResult choice = browseDlg.ShowDialog();
               if (choice == DialogResult.OK)
               {
                   textDatabase.Text  = browseDlg.SelectedDatabase;
               }
           }
       }
       #endregion

        #region Code to handle Enter while in list view

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ( listResults.Focused )
                   ShowSourceCode();
                else if (buttonSearch.Enabled)
                   PerformSearch();
            }
        }


        #endregion

       private void contextMenuViewSQLSource_Click( object sender, EventArgs e )
       {
            ShowSourceCode();
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

            returnVal = String.Compare( ((ListViewItem)x).SubItems[col].Text,
                                        ((ListViewItem)y).SubItems[col].Text );
            
            if ( order == System.Windows.Forms.SortOrder.Descending ) returnVal *= -1;

            return returnVal;
          }
      }
      #endregion
      
        #region Handle Context Menu at Column Header
 
        /// <summary>
        /// Called when the user right-clicks anywhere in the ListView, including the
        /// header bar.  It displays the appropriate context menu for the data row or
        /// header that was right-clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void regularListViewMenu_Opening(object sender, CancelEventArgs e)
        {
            // This call indirectly calls EnumWindowCallBack which sets _headerRect
            // to the area occupied by the ListView's header bar.
            EnumChildWindows(listResults.Handle, EnumWindowCallBack, IntPtr.Zero);

            // If the mouse position is in the header bar, cancel the display
            // of the regular context menu and display the column header context menu instead.
            Point mousePosition = MousePosition;
            
            if (_headerRect.Contains(mousePosition))
            {
                e.Cancel = true;
            }
        }

        // The area occupied by the ListView header. 
        private Rectangle _headerRect;

        // This should get called with the only child window of the ListView,
        // which should be the header bar.
        private bool EnumWindowCallBack(IntPtr hwnd, IntPtr lParam)
        {
            // Determine the rectangle of the ListView header bar and save it in _headerRect.
            RECT rct;

            if (!GetWindowRect(hwnd, out rct))
            {
                _headerRect = Rectangle.Empty;
            }
            else
            {
                _headerRect = new Rectangle(rct.Left, rct.Top, rct.Right - rct.Left, rct.Bottom - rct.Top);
            }

            return false; // Stop the enum
        }
        
        // Delegate that is called for each child window of the ListView.
        private delegate bool EnumWinCallBack(IntPtr hwnd, IntPtr lParam);

        // Calls EnumWinCallBack for each child window of hWndParent (i.e. the ListView).
        [DllImport("user32.Dll")]
        private static extern int EnumChildWindows(IntPtr hWndParent, EnumWinCallBack callBackFunc, IntPtr lParam);

        // Gets the bounding rectangle of the specified window (ListView header bar).
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        #endregion
      

       private void menuExportAsCSV_Click( object sender, EventArgs e )
       {
          ExportToCSV.CopyListView( listResults );
       }

       private void menuExportAsXML_Click( object sender, EventArgs e )
       {
          ExportToXML.CopyListView( listResults, "Search Results" , true );
       }

       private void contextMenuExportAsCSV_Click( object sender, EventArgs e )
       {
          ExportToCSV.CopyListView( listResults );
       }

       private void contextMenuExportAsXML_Click( object sender, EventArgs e )
       {
          ExportToXML.CopyListView( listResults, "Search Results" , true );
       }

      #region Progress Bar
      
        #region Progress Bar

        public void ProgressBar_Show()
        {
            if(_ProgressDialog != null)
            {
                _ProgressDialog.ShowDialog();
            }
        }
        public void ProgressBar_Close()
        {
            if(_ProgressDialog != null)
            {
                _ProgressDialog.TopLevel = false;
                _ProgressDialog.Visible = false;
                _ProgressDialog.Close();
                _ProgressDialog = null;
            }
        }

        public void ProgressBar_Initialize()
        {
            _ProgressDialog = new ToolProgressBarDialog();

            string msg;            
            if ( textDatabase.Text == "" )
            {
               msg = "Searching all databases...";
            }
            else
            {
               msg = "Searching ...";
            }
            
            _ProgressDialog.OperationText = msg;
            _ProgressDialog.CancelEnabled = true;
            _ProgressDialog.ProgressCancelEvent += new EventHandler<EventArgs>(ProgressBar_CancelHandler);
        }

        public void ProgressBar_CancelHandler(object sender, EventArgs e)
        {
            _ProgressDialog.OperationText = "Cancelling...";
            _ProgressDialog.CancelEnabled = false;
            
            labelNumberOfResults.Text = "Search cancelled";

            m_searchCancelled = true;

            m_JobPool.Cancel(true);
        }
        
        #endregion
      
      #endregion

       private void textServer_KeyPress( object sender, KeyPressEventArgs e )
       {
         // eat semi-colons so user cant try to supply multiple servers
         if (e.KeyChar == ';')
         {
            e.Handled=true; // input is not passed on to the control(TextBox) 
         }
         base.OnKeyPress (e);
       }

       private void ShowF1Help(object sender, HelpEventArgs hlpevent)
       {
          HelpMenu.ShowHelp();
       }

       private void textDatabase_TextChanged( object sender, EventArgs e )
       {
          if ( textDatabase.Text.Trim().Length != 0 )
          {
             checkBoxIncludeSystemDatabases.Enabled = false;
             m_saveIncludeSystem = checkBoxIncludeSystemDatabases.Checked;
             checkBoxIncludeSystemDatabases.Checked = false;
          }
          else
          {
             checkBoxIncludeSystemDatabases.Enabled = true;
             checkBoxIncludeSystemDatabases.Checked = m_saveIncludeSystem;
          }
       }

       private void menuHelp_Click(object sender, EventArgs e)
       {
          
          base.OnClick(e);
       }

        private void ideraTitleBar1_LicenseInfoButtonClick(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }

        private void listResults_DrawColumnHeader(object sender,
                                            DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
            e.DrawText();
        }

    }
}

