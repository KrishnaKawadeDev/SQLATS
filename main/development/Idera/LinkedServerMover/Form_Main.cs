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
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Idera.SqlAdminToolset.Core;
using BBS.TracerX;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.LinkedServerMover
{
    public partial class Form_Main : Form
    {
       private enum ImageIcon
       {
          Success = 0,
          Failure = 1,
          NotRequested = 2,
          Checkedbox = 3,
          UnCheckedbox = 4,
          Warning = 5
       }

       private class ConnectionAttempt
       {
          public Server server;
          public Exception exception;

          public ConnectionAttempt(Server serverToConnect)
          {
             server = serverToConnect;
          }
       }

       private class MoveWorkerArgument
       {
          public List<LinkedServer> ServersToMove;
          public Dictionary<string, Dictionary<string, string>> LoginsMissingPasswords;
          public List<Login> LoginsToCopy;
       }

       #region Private Variables

       Logger logger = CoreGlobals.traceLog;
       SQLCredentials _SourceServerSqlCredentials = null;
       SQLCredentials _DestinationServerSqlCredentials = null;
       private Server _SourceServer = null;
       private Server _DestinationServer = null;
       private int sortColumn = -1;
       private System.Windows.Forms.SortOrder sortOrder = System.Windows.Forms.SortOrder.Ascending;
       bool _BypassItemCheckEvent = false;
       private ToolProgressBarDialog _ProgressDialog;

       #endregion
       
       #region Constructor

       public Form_Main()
        {
            InitializeComponent();
            this.Text = ideraTitleBar1.IderaProductNameText;
            ServerSelectionSource.Text = "(local)";
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

            base.OnLoad(e);
            if ( ! Startup.GuiStartup( this, menuTools, menuAbout, ideraTitleBar1) ) 
            {
               Close();
               return;
            }

            #endregion

            // Program Specific Logic
        }

       #endregion

       #region Common Code

        #region File Menu Event Handlers (Common)

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuExitToLaunchpad_Click(object sender, EventArgs e)
        {
           Launchpad.RunAndClose( this );
        }

        #endregion

        #region Help Menu Event Handlers (Common)

        private void menuShowHelp_Click(object sender, EventArgs e)
        {
           HelpMenu.ShowHelp(ProductConstants.productHelpTopic);
        }

        private void menuDeactivateLicense_Click(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }

      

        private void menuAbout_Click(object sender, EventArgs e)
        {
           HelpMenu.ShowAboutForm();
        }

        private void menuSearchIderaKnowledgeBase_Click(object sender, EventArgs e)
        {
           HelpMenu.ShowURL_SearchIderaKnowledgeBase( this );
        }

        private void menuAboutIderaProducts_Click(object sender, EventArgs e)
        {
           HelpMenu.ShowURL_AboutIderaProducts( this );
        }

        private void menuContactTechnicalSupport_Click(object sender, EventArgs e)
        {
           HelpMenu.ShowURL_ContactTechnicalSupport( this );
        }

        private void menuCheckForUpdates_Click(object sender, EventArgs e)
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

        private void ShowF1Help(object sender, HelpEventArgs hlpevent)
        {
           HelpMenu.ShowHelp(ProductConstants.productHelpTopic);
        }
        
      #region Program Logic

       private void PreviewWorker_DoWork(object sender, DoWorkEventArgs e)
       {
          BackgroundWorker _Worker = sender as BackgroundWorker;
          InitializeServers();

          ConnectionAttempt _SourceConnection = new ConnectionAttempt(_SourceServer);
          ConnectionAttempt _DestinationConnection = new ConnectionAttempt(_DestinationServer);

          Thread _InitializeSourceServer = new Thread(delegate() { Connection.Impersonate(ServerSelectionSource.SqlCredentials); TryConnect(_SourceConnection); });
          _InitializeSourceServer.IsBackground = true;
          _InitializeSourceServer.Start();
          Thread _InitializeDestinationServer = new Thread(delegate() { Connection.Impersonate(ServerSelectionDestination.SqlCredentials); TryConnect(_DestinationConnection); });
          _InitializeDestinationServer.IsBackground = true;
          _InitializeDestinationServer.Start();

          while (true)
          {
             if (_InitializeSourceServer.Join(2500) && _InitializeDestinationServer.Join(2500))
             {
                break;
             }
             else
             {
                if (_Worker.CancellationPending)
                {
                   e.Cancel = true;
                   return;
                }
             }
          }

          if (_SourceConnection.exception != null)
          {
             throw new Exception(string.Format(ProductConstants.ErrorConnectingToServer, ServerSelectionSource.Text), _SourceConnection.exception);
          }
          if (_DestinationConnection.exception != null)
          {
             throw new Exception(string.Format(ProductConstants.ErrorConnectingToServer, ServerSelectionDestination.Text), _DestinationConnection.exception);
          }

          if (SQLHelpers.GetSqlVersion(_SourceServer.ConnectionContext.SqlConnectionObject) <= 7 ||
             SQLHelpers.GetSqlVersion(_DestinationServer.ConnectionContext.SqlConnectionObject) <= 7)
          {
             throw new NotSupportedException(ProductConstants.ErrorOnlySql2000AndAboveSupported);
          }

          if (_SourceServer.Information.NetName == _DestinationServer.Information.NetName &&
               _SourceServer.InstanceName == _DestinationServer.InstanceName)
          {
             throw new InvalidOperationException(ProductConstants.ErrorDatabaseMoveMustHaveDifferentDestination);
          }
          if (!LinkedServerUtility.IsValidOperation(_SourceServer, _DestinationServer, true))
          {
             throw new InvalidOperationException(ProductConstants.ErrorNotSupportedSqlCombination);
          }
          e.Result = LinkedServerUtility.FindMissingLinkedServers(_SourceServer, _DestinationServer, _Worker);
       }

       private void TryConnect(ConnectionAttempt serverConnection)
       {
          try
          {
             serverConnection.server.ConnectionContext.SqlConnectionObject.Open();
          }
          catch (Exception e)
          {
             serverConnection.exception = e;
          }
       }

       private void PreviewWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
       {
          try
          {
             if (e.Error != null)
             {
                Messaging.ShowException("Preview Linked Servers", e.Error);
                return;
             }

             if (e.Cancelled)
             {
                Messaging.ShowWarning("Preview was canceled by user");
                return;
             }

             List<LinkedServer> missingLinkedServers = e.Result as List<LinkedServer>;
             int count = 0;

             if (missingLinkedServers != null)
             {
                listServers.CheckBoxes = true;
                if (missingLinkedServers.Count > 0)
                {
                   listServers.BeginUpdate();

                   foreach (LinkedServer server in missingLinkedServers)
                   {
                      count++;
                      ListViewItem item = new ListViewItem();

                      item.SubItems.Add(server.Name);

                      if (AllLoginsMoveable(server))
                         item.SubItems.Add("Y", Color.LimeGreen, Color.Transparent, null);
                      else
                         item.SubItems.Add("N", Color.Red, Color.Transparent, null);

                      //add blanks for the move status and the description
                      item.SubItems.Add("");
                      item.SubItems.Add("");
                      listServers.Items.Add(item);
                      item.Tag = server;

                      //Do events every 50 servers
                      if (count % 50 == 0)
                         Application.DoEvents();
                   }
                   listServers.EndUpdate();
                   listServers.Columns[0].ImageIndex = (int)ImageIcon.UnCheckedbox;
                   labelInstructions.Text = "Preview Missing Linked Servers";
                }
                else
                {
                   Messaging.ShowInformation(ProductConstants.NoneToMove);
                }
             }
          }
          finally
          {
             ProgressBar_Close();
             buttonGetLinkedServers.Enabled = true;
             _BypassItemCheckEvent = false;
          }
       }

       private void buttonMoveLinkedServers_Click( object sender, EventArgs e )
       {
          bool copy = false;

          buttonMoveLinkedServers.Enabled = false;
          MoveWorkerArgument workerArgument = new MoveWorkerArgument();
          ProgressBar_Initialize("Initializing");

          List<LinkedServer> serversToMove = new List<LinkedServer>();
          List<LinkedServer> needPasswords = new List<LinkedServer>();
          List<Login> loginList;

          foreach (ListViewItem _Item in listServers.CheckedItems)
          {
             serversToMove.Add((LinkedServer)_Item.Tag);
             if (_Item.SubItems[2].Text == "N")
                needPasswords.Add((LinkedServer)_Item.Tag);
          }
          loginList = GetListOfLocalLoginsToCopy(serversToMove);

          if (needPasswords.Count > 0)
          {
             Form_SetPasswords passwordDialog = new Form_SetPasswords();
             passwordDialog.LinkedServers = needPasswords;

             if (passwordDialog.ShowDialog(this) == DialogResult.OK)
             {
                workerArgument.LoginsMissingPasswords = passwordDialog.Logins;
                copy = true;
             }
          }
          else
          {
             workerArgument.LoginsMissingPasswords = null;
             copy = true;
          }

          if (copy)
          {
             workerArgument.LoginsToCopy = loginList;
             workerArgument.ServersToMove = serversToMove;
             MoveWorker.RunWorkerAsync(workerArgument);
             ProgressBar_Show();
          }
          else
            buttonMoveLinkedServers.Enabled = true;
       }

       private void MoverWorker_DoWork(object sender, DoWorkEventArgs e)
       {
          BackgroundWorker _Worker = sender as BackgroundWorker;
          LinkedServerUtility helpers = new LinkedServerUtility();
          helpers.TaskStatus += new EventHandler<StatusEventArgs>(TaskStatus);
          MoveWorkerArgument moverArgument = (MoveWorkerArgument)e.Argument;
          e.Result = helpers.MoveLinkedServers(_SourceServer, _DestinationServer, moverArgument.ServersToMove, moverArgument.LoginsMissingPasswords, moverArgument.LoginsToCopy, _Worker);
       }

       private void MoveWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
       {
         ProgressBar_Update( "Processing Results" );
         LinkedServerMoveCompleteEventArgs _Args = e.Result as LinkedServerMoveCompleteEventArgs;

         if (e.Error == null && _Args.Success)
         {
            foreach (ListViewItem _Item in listServers.Items)
            {
               if (_Item.Checked)
               {
                  LinkedServer linkedServer = (LinkedServer)_Item.Tag;

                  //If the Name is not in the move results, it is because the copy operation was cancelled.
                  if (_Args.MoveResults.ContainsKey(linkedServer.Name))
                  {
                     if (_Args.MoveResults[linkedServer.Name] != null)  //exception thrown for item
                     {
                        _Item.SubItems[3].Text = ProductConstants.StatusFailed;
                        _Item.SubItems[3].ForeColor = Color.Red;
                        _Item.SubItems[4].Text = Helpers.GetCombinedExceptionText(_Args.MoveResults[linkedServer.Name]);
                        _Item.ImageIndex = (int)ImageIcon.Failure;
                     }
                     else
                     {
                        _Item.SubItems[3].Text = ProductConstants.StatusSuccess;
                        _Item.SubItems[3].ForeColor = Color.LimeGreen;
                        _Item.ImageIndex = (int)ImageIcon.Success;
                     }
                  }
               }
               else
               {
                  _Item.SubItems[3].Text = ProductConstants.StatusNotRequested;
                  _Item.ImageIndex = -1;
               }
            }
         }
         else
         {
            foreach (ListViewItem _Item in listServers.Items)
            {
               if (_Item.Checked)
               {
                  _Item.SubItems[3].Text = ProductConstants.StatusFailed;
                  _Item.SubItems[3].ForeColor = Color.Red;
                  _Item.ImageIndex = (int)ImageIcon.Failure;
               }
               else
               {
                  _Item.SubItems[3].Text = ProductConstants.StatusNotRequested;
                  _Item.ImageIndex = (int)ImageIcon.NotRequested;
               }
            }
            
            ProgressBar_Close();
            
            if (!_Args.Success)
            {
               if (_Args.TaskException == null)
               {
                  string _ErrorMessage = "An error has ocurred with the requested operation. \n\n Login Copy Log: \n " + _Args.Log;
                  Messaging.ShowError(_ErrorMessage, ProductConstants.ErrorMovingLinkedServersCaption);
               }
               else
               {
                   Messaging.ShowException("An error occurred while copying logins to the destination server.  Please manually create the necessary logins on the destination server and repeat the linked server copy. ", _Args.TaskException);
               }
            }
            else if (e.Error != null)
            {
               Messaging.ShowException(ProductConstants.ErrorMovingLinkedServersCaption, e.Error);
            }
         }
         listServers.CheckBoxes = false;
         listServers.Columns[0].ImageIndex = -1;
         
         ProgressBar_Close();
      }

       private List<Login> GetListOfLocalLoginsToCopy(List<LinkedServer> serversToMove)
       {
          List<Login> loginList = new List<Login>();

          foreach (LinkedServer linkedServer in serversToMove)
          {
             foreach (LinkedServerLogin login in linkedServer.LinkedServerLogins)
             {
                if (String.IsNullOrEmpty(login.Name))
                   continue;

                //we only need to copy SQL Server logins to the destination server. Skip all windows logins.
                if (login.Name.IndexOf('\\') != -1)
                   continue;

                if (_DestinationServer.Logins.Contains(login.Name) == false)
                {
                   loginList.Add(_SourceServer.Logins[login.Name]);
                }
             }
          }
          return loginList;
       }

      void TaskStatus(object sender, StatusEventArgs e)
      {
         SetProgressText(e.Description);
      }

      delegate void SetProgressTextDelegate(string value);

      private void SetProgressText(string value)
      {
         if (InvokeRequired)
         {
            BeginInvoke(new SetProgressTextDelegate(SetProgressText), new object[] { value });
            return;
         }
         ProgressBar_Update(value);
      }

       #endregion

       private void menuHelp_Click(object sender, EventArgs e)
       {
          
          base.OnClick(e);
       }

       private void buttonViewLinkedServers_Click(object sender, EventArgs e)
       {
          if (ServerSelectionSource.Text == "")
          {
             Messaging.ShowError(ProductConstants.ErrorNoSourceSqlServer);
             ServerSelectionSource.Focus();
             buttonMoveLinkedServers.Enabled = false;
             return;
          }
          if (ServerSelectionDestination.Text == "")
          {
             Messaging.ShowError(ProductConstants.ErrorNoDestinationSqlServer);
             ServerSelectionDestination.Focus();
             buttonMoveLinkedServers.Enabled = false;
             return;
          }

          if (ServerSelectionSource.Text.Contains(";"))
          {
             Messaging.ShowError(ProductConstants.ErrorSourceInvalidCharacters);
             buttonMoveLinkedServers.Enabled = false;
             return;
          }

          if (ServerSelectionDestination.Text.Contains(";"))
          {
             Messaging.ShowError(ProductConstants.ErrorDestinationInvalidCharacters);
             buttonMoveLinkedServers.Enabled = false;
             return;
          }
          buttonGetLinkedServers.Enabled = false;

          try
          {
             ProgressBar_Initialize("Retrieving Linked Server list");
             ClearFields();
             _BypassItemCheckEvent = true;
             PreviewWorker.RunWorkerAsync();
             ProgressBar_Show();
          }
          catch (Exception exception)
          {
             Messaging.ShowException("Linked Servers", exception);
             buttonGetLinkedServers.Enabled = true;
          }
       }

       private bool AllLoginsMoveable(LinkedServer linkedServer)
       {
          if (linkedServer.LinkedServerLogins.Count > 0)
          {
             foreach (LinkedServerLogin login in linkedServer.LinkedServerLogins)
             {
                //Ignore empty logins.
                if (String.IsNullOrEmpty(login.Name) && String.IsNullOrEmpty(login.RemoteUser))
                   continue;

                if ((login.Impersonate == false) && (login.RemoteUser.IndexOf('\\') == -1))
                {
                   //if we find a local user that is not impersonated and the remote
                   //user name is not a windows login, then we can't move all of the logins.
                   return false;
                }
             }
          }
          return true;
       }

       private void listServers_ColumnClick(object sender, ColumnClickEventArgs e)
       {
          if (e.Column == 0 && listServers.Columns[0].ImageIndex > -1)
          {
             _BypassItemCheckEvent = true;
             if (listServers.Columns[0].ImageIndex == (int)ImageIcon.UnCheckedbox)
             {
                listServers.Columns[0].ImageIndex = (int)ImageIcon.Checkedbox;
                foreach (ListViewItem item in listServers.Items)
                {
                   item.Checked = true;
                }
                buttonMoveLinkedServers.Enabled = listServers.Items.Count > 0;
             }
             else
             {
                listServers.Columns[0].ImageIndex = (int)ImageIcon.UnCheckedbox;
                foreach (ListViewItem item in listServers.Items)
                {
                   item.Checked = false;
                }
                buttonMoveLinkedServers.Enabled = false;
             }
             _BypassItemCheckEvent = false;
          }
          else
          {
             // Determine whether the column is the same as the last column clicked.
             if (e.Column != sortColumn)
             {
                // Set the sort column to the new column.
                sortColumn = e.Column;

                // Set the sort order to ascending by default.
                listServers.Sorting = sortOrder;
             }
             else
             {
                // Determine what the last sort order was and change it.
                if (listServers.Sorting == System.Windows.Forms.SortOrder.Ascending)
                   listServers.Sorting = System.Windows.Forms.SortOrder.Descending;
                else
                   listServers.Sorting = System.Windows.Forms.SortOrder.Ascending;
             }
             listServers.ListViewItemSorter = new ListViewItemComparer(e.Column, listServers.Sorting);
             listServers.Sort();
          }
       }

       // Implements the manual sorting of items by column.
       class ListViewItemComparer : IComparer
       {
          private int col;
          private System.Windows.Forms.SortOrder order;

          public ListViewItemComparer()
          {
             col = 0;
             order = System.Windows.Forms.SortOrder.Ascending;
          }

          public ListViewItemComparer(int column, System.Windows.Forms.SortOrder order)
          {
             col = column;
             this.order = order;
          }

          public int Compare(object x, object y)
          {
             int returnVal = -1;

             returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                         ((ListViewItem)y).SubItems[col].Text);

             if (order == System.Windows.Forms.SortOrder.Descending) 
                returnVal *= -1;
             return returnVal;
          }
       }

       private void listServers_ItemChecked(object sender, ItemCheckedEventArgs e)
       {
          if (!_BypassItemCheckEvent)
          {
             if (listServers.Columns[0].ImageIndex == (int)ImageIcon.Checkedbox && !e.Item.Checked)
             {
                listServers.Columns[0].ImageIndex = (int)ImageIcon.UnCheckedbox;
             }
             buttonMoveLinkedServers.Enabled = (listServers.CheckedItems != null) && (listServers.CheckedItems.Count != 0);

             if (listServers.CheckedItems.Count == listServers.Items.Count)
                listServers.Columns[0].ImageIndex = (int)ImageIcon.Checkedbox;
          }
       }

       public void ProgressBar_Show()
       {
          if (_ProgressDialog != null)
          {
             _ProgressDialog.ShowDialog();
          }
       }
       public void ProgressBar_Close()
       {
          if (_ProgressDialog != null)
          {
             _ProgressDialog.TopLevel = false;
             _ProgressDialog.Visible = false;
             _ProgressDialog.Close();
             _ProgressDialog = null;
          }
       }

       public void ProgressBar_Update(string message)
       {
          _ProgressDialog.OperationText = message;
       }

       public void ProgressBar_Initialize(string message)
       {
          _ProgressDialog = new ToolProgressBarDialog();
          _ProgressDialog.Text = "";
          _ProgressDialog.OperationText = message;
          _ProgressDialog.CancelEnabled = true;
          _ProgressDialog.ProgressCancelEvent += new EventHandler<EventArgs>(ProgressBar_CancelHandler);
       }

       public void ProgressBar_CancelHandler(object sender, EventArgs e)
       {
          _ProgressDialog.OperationText = "Cancelling...";
          _ProgressDialog.CancelEnabled = false;

          if (PreviewWorker.IsBusy)
          {
             PreviewWorker.CancelAsync();
          }

          if (MoveWorker.IsBusy)
          {
             MoveWorker.CancelAsync();
          }
       }

       private void ClearFields()
       {
          _SourceServer = _DestinationServer = null;
          listServers.Items.Clear();
          buttonMoveLinkedServers.Enabled = false;
          labelInstructions.Text = string.Empty;
          listServers.Columns[0].ImageIndex = -1;
       }

       private void ServerSelectionSource_TextChanged(object sender, EventArgs e)
       {
          listServers.Items.Clear();
          buttonMoveLinkedServers.Enabled = false;
          listServers.Columns[0].ImageIndex = -1;
       }

       private void ServerSelectionDestination_TextChanged(object sender, EventArgs e)
       {
          listServers.Items.Clear();
          buttonMoveLinkedServers.Enabled = false;
          listServers.Columns[0].ImageIndex = -1;
       }

       #region SMO Initialize
       private void InitializeServers()
       {
          if (ServerSelectionSource.Text.Trim().Length > 0 && _SourceServer == null)
          {
             InitializeServer(ref _SourceServer, ServerSelectionSource.Text, ServerSelectionSource.SqlCredentials);
          }

          if (ServerSelectionDestination.Text.Trim().Length > 0 && _DestinationServer == null)
          {
             InitializeServer(ref _DestinationServer, ServerSelectionDestination.Text, ServerSelectionDestination.SqlCredentials);
          }
       }

       private void InitializeServer(ref Server server, string name, SQLCredentials credentials)
       {
          SqlConnection _Connection = new SqlConnection(Connection.CreateConnectionString(name, null, credentials));
          server = new Server(new ServerConnection(_Connection));
       }
        #endregion

        private void ideraTitleBar1_LicenseInfoButtonClick(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }
    }
}

