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

namespace Idera.SqlAdminToolset.ObjectSearch
{
    public partial class Form_Main : Form
    {
        #region Properties

        private JobPool<bool>                   m_JobPool;
        public static Dictionary<string, string> _ErrorReports = new Dictionary<string, string>();
        
        private ToolProgressBarDialog _ProgressDialog;        
        
        
        #endregion

        #region Constructor

        public Form_Main()
        {
            InitializeComponent();
            this.Text = ideraTitleBar1.IderaProductNameText;
            string msg = "When 'Use SQL Wildcards' is not checked, Object Search\r\n" +
                         "will find all objects with the search text anywhere in\r\n" +
                         "their names. If this option is checked, you must specify\r\n" +
                         "SQL wildcards or the tool will perform an exact match.\r\n" +
                         "Example: SYS% will find any objects starting with SYS";
            
            this.toolTip1.SetToolTip( this.checkAllowWildcards, msg );
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

            SetSearchButtonEnabled();
            
            m_mainform = this;
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
        }

        private void SetSearchButtonEnabled()
        {
            buttonSearch.Enabled = (ServerSelection.textServer.Text.Trim().Length != 0) 
                                     && (textSearchText.Text.Trim().Length != 0); 
        }

        private void textSearchText_TextChanged(object sender, EventArgs e)
        {
            SetSearchButtonEnabled();
        }

        private void listResults_SelectedIndexChanged(object sender, EventArgs e)
        {
           bool someSelected = (listResults.SelectedItems.Count != 0);

           menuCopy.Enabled                 = someSelected;
           buttonCopyToClipboard.Enabled    = someSelected;
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
          listResults.Select();
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
           // save item to persisted MRU list
           MRU.AddServerOrGroup( ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server,
                                 ServerSelection.Text,
                                 ServerSelection.SqlCredentials );

           PerformSearch();
        }
        public delegate void DelegateShowInformationFromWorker(string msg);

        private DelegateShowInformationFromWorker m_ShowInformationFromWorkerDelegate = null;

        private void ShowInformationFromWorker(string msg)
        {
            if(this.InvokeRequired)
            {
                if(m_ShowInformationFromWorkerDelegate == null)
                {
                    m_ShowInformationFromWorkerDelegate = ShowInformationFromWorker;
                }
                this.Invoke(m_ShowInformationFromWorkerDelegate, new object[] { msg });
                return;
            }
            else
            {
                if (_ProgressDialog != null)
                {
                    Messaging.ShowInformation(_ProgressDialog, msg);
                }
                else
                {
                    Messaging.ShowInformation(msg);
                }
            }
        }
        public delegate DialogResult DelegateShowConfirmationFromWorker(string msg);

        private DelegateShowConfirmationFromWorker m_ShowConfirmationFromWorkerDelegate = null;

        private DialogResult ShowConfirmationFromWorker(string msg)
        {
            if (this.InvokeRequired)
            {
                if (m_ShowConfirmationFromWorkerDelegate == null)
                {
                    m_ShowConfirmationFromWorkerDelegate = ShowConfirmationFromWorker;
                }
                return (DialogResult)Invoke(m_ShowConfirmationFromWorkerDelegate, new object[] { msg });
                
            }
            else
            {
                if (_ProgressDialog != null)
                {
                    return Messaging.ShowConfirmation(_ProgressDialog, msg);
                }
                else
                {
                    return Messaging.ShowConfirmation(msg);
                }
            }
        }

        private void PerformSearch()
        {
            saveSearchString   = textSearchText.Text;
            saveMatchCase      = checkMatchCase.Checked;
            saveAllowWildcards = checkAllowWildcards.Checked;

            try
            {
               List<ServerInformation> _ServerList = ServerSelection.ServerList;
               
               if ( _ServerList.Count == 0 )
               {
                  string msg;
                  if ( ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server )
                     msg = "Specify at least one SQL Server.";
                  else
                     msg = "The selected Server Group contains no SQL Servers.";
                    
                  Messaging.ShowError( msg );
                  
                  return;
               }
               
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
               
               // clear display
                listResults.Items.Clear();
                listResults.Groups.Clear();
                
                ResetSearchResults();
                
                buttonCopyToClipboard.Enabled = false;
                contextMenuExport.Enabled = false;
                menuExport.Enabled = false;
                contextMenuSelectAll.Enabled = false;
                menuSelectAll.Enabled = false;
                
                groupResults.Text = String.Format("Search Results for '{0}' {1}{2}",
                                                 textSearchText.Text,
                                                 String.IsNullOrEmpty(textDatabase.Text) ? "in all databases" : "in database ",
                                                 String.IsNullOrEmpty(textDatabase.Text) ? "" : textDatabase.Text );
                labelNumberOfResults.Text = "Search in progress...";
                labelNumberOfResults.Visible = false;
                labelEmptyResultSet.Visible = false;
                Application.DoEvents();
                
                // set up background thread for searches                
                _ErrorReports.Clear();
                

                //set up stati csearch parameters
                SearchHelper.m_server               = ServerSelection.textServer.Text;
                SearchHelper.m_credentials          = ServerSelection.SqlCredentials;
                
                SearchHelper.m_databaseString       = textDatabase.Text;
                SearchHelper.m_searchString         = textSearchText.Text;
                SearchHelper.m_caseSensitiveSearch  = checkMatchCase.Checked;
                SearchHelper.m_excludeSystemObjects = checkBoxExcludeSystemObjects.Checked;
                SearchHelper.m_allowWildcards       = checkAllowWildcards.Checked;
                SearchHelper.m_ShowInfomationDelegate = ShowInformationFromWorker;
                SearchHelper.m_ShowConfirmationDelegate = ShowConfirmationFromWorker;
                
                try
                {
                   m_searchLimit          = System.Convert.ToInt32(textLimit.Text);
                   if ( m_searchLimit < 0 ) m_searchLimit = 500;
                }
                catch
                {
                   m_searchLimit          = 500;
                }
                
                ProgressBar_Initialize( "Performing Search..." );
                 
                m_JobPool = new JobPool<bool>(10);
                m_JobPool.ServerTaskComplete += new EventHandler<JobExecutionResultsEventArgs>(JobPoolTaskComplete);
                m_JobPool.TaskComplete       += new EventHandler<JobExecutionEventArgs>(AllTasksComplete);
                m_JobPool.Enqueue( SearchHelper.PerformSearch, _ServerList, ToolsetOptions.commandTimeout);
                m_JobPool.StartAsync();
                
                ProgressBar_Show();
                
                ProductConstants.searchLimitReached = false;
                ProductConstants.operationInProgress = true;
                ProductConstants.operationCancelled  = false;
            }
            catch (Exception ex )
            {
               Messaging.ShowException( "Search request failed.", ex );
               
               ProgressBar_Close();
            }
        }
        
        void JobPoolTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
           if (e.Status == TaskStatus.Failed)
           {
               _ErrorReports.Add(e.Server.Name, e.ErrorMessage);
           }
        }

        void AllTasksComplete(object sender, JobExecutionEventArgs e)
        {
           ProgressBar_Close();

           if (_ErrorReports.Count > 0)
           {
              Form_MultipleServerError frm = new Form_MultipleServerError();
              foreach (KeyValuePair<string, string> _Error in _ErrorReports)
              {
                 frm.AddError( _Error.Key, _Error.Value );
              }
              BeginInvoke((MethodInvoker)delegate() { frm.ShowDialog(); });
           }

           string status = String.Format ( "{0} matches found", listResults.Items.Count );
           
           if ( ProductConstants.operationCancelled )
           {
              status += " (Partial results - Search cancelled)";
           }
           else if ( ProductConstants.searchLimitReached )
           {
              status += " (Partial results - Result set limit reached)";
           }
           
           labelNumberOfResults.Text = status;
           
           labelNumberOfResults.Visible = true;
           
           if ( listResults.Items.Count == 0 )
           {
              labelEmptyResultSet.Visible = true;
           }
           
           bool enabled = (listResults.Items.Count != 0);
           menuExport.Enabled           = enabled;
           contextMenuExport.Enabled    = enabled;
           menuCopy.Enabled             = enabled;
           contextMenuCopy.Enabled      = enabled;
           menuSelectAll.Enabled        = enabled;
           contextMenuSelectAll.Enabled = enabled;
           buttonCopyToClipboard.Enabled = enabled;
           
           ProductConstants.operationInProgress = false;
        }

       #endregion

        #region Search Results

        public   static ArrayList  m_searchResults = null;
        public   static int        m_searchLimit   = 500;
        private  static object     m_searchLock    = new Object();
        private  static Form_Main  m_mainform;
        
        static public void
           ResetSearchResults()
        {
            if ( m_searchResults == null )
            {
               m_searchResults = new ArrayList();
            }
            else
            {
               m_searchResults.Clear();
            }
        }

        static public bool 
           AddSearchResult(         
              SearchResult   searchResult
           )
        {
           bool added = false;
           lock ( m_searchLock )
           {
              
              if ( (!m_mainform.radioButtonLimit.Checked) || m_searchResults.Count < m_searchLimit )
              {
                 m_searchResults.Add( searchResult );
                 m_mainform.AddListViewItem( searchResult );
                 
                 if ( m_searchResults.Count % 10 == 0)
                 {
                    Application.DoEvents();  // so rows are displayed as they are added
                 }

                 added = true;
              }
              else
              {
                 ProductConstants.searchLimitReached = true;
              }
           }
           
           return added;
        }
        
        delegate void AddListViewItemDelegate(SearchResult searchResult);
        public void
           AddListViewItem(
              SearchResult searchResult
           )
        {
           if (InvokeRequired)
           {
              BeginInvoke(new AddListViewItemDelegate(AddListViewItem), searchResult);
              return;
           }
        
           ListViewItem lvi = new ListViewItem( searchResult.GetFullName(),(int)searchResult.iconIndex );
           lvi.SubItems.Add( searchResult.objectType );
           lvi.SubItems.Add( searchResult.server );
           lvi.SubItems.Add( searchResult.database );
           lvi.SubItems.Add( searchResult.GetFullParentName() );
           lvi.SubItems.Add( searchResult.parentObjectType );
           
           
           // Groups
           int groupIndex = FindGroup( searchResult.server );
           if ( groupIndex == -1 )
           {
              ListViewGroup group = new ListViewGroup( searchResult.server );
              groupIndex = listResults.Groups.Add( group );
           }
           lvi.Group = listResults.Groups[groupIndex];
           
           listResults.Items.Add( lvi );
        }
        
        int FindGroup( string server )
        {
           if (listResults.Groups == null ) return -1;
           for (int i=0; i<listResults.Groups.Count; i++ )
           {
              if ( listResults.Groups[i].ToString() == server )
                 return i;
           }
           return -1;
        }
        
        #endregion

        #region Code to handle Enter while in list view

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ( buttonSearch.Enabled && ! listResults.Focused )
                {
                   PerformSearch();
                }
            }
        }


        #endregion

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

        #region Export

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
       
       private void menuExportAsDataTable_Click( object sender, EventArgs e )
       {

       }

       private void contextMenuExportAsDataTable_Click( object sender, EventArgs e )
       {

       }
       
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

       #region Progress Bar Functions

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

        public void ProgressBar_Initialize(string text)
        {
            _ProgressDialog = new ToolProgressBarDialog();
            _ProgressDialog.OperationText = text;
            _ProgressDialog.CancelEnabled = true;
            _ProgressDialog.ProgressCancelEvent += new EventHandler<EventArgs>(ProgressBar_CancelHandler);
        }

        public void ProgressBar_CancelHandler(object sender, EventArgs e)
        {
            ProductConstants.operationCancelled  = true;
            
            m_JobPool.Cancel(true);
            _ProgressDialog.OperationText = "Cancelling...";
            _ProgressDialog.CancelEnabled = false;
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

       private void ShowF1Help(object sender, HelpEventArgs hlpevent)
       {
          HelpMenu.ShowHelp();
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
    }
}

