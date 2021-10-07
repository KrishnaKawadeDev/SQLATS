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

using Idera.SqlAdminToolset.Core;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Idera.SqlAdminToolset.DatabaseMoverLibrary;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.LoginCopy
{
    public partial class Form_Main : Form
    {
        private Server _SourceServer = null;
        private Server _DestinationServer = null;
        Utility _MoverUtility = null;
        private int sortColumn = -1;
        private System.Windows.Forms.SortOrder sortOrder = System.Windows.Forms.SortOrder.Ascending;
        bool _BypassItemCheckEvent = false;

        private ToolProgressBarDialog _ProgressDialog;


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
            if (!Startup.GuiStartup(this, menuTools, menuAbout, ideraTitleBar1))
            {
                Close();
                return;
            }

            #endregion

            ClearFields();
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
            Launchpad.RunAndClose(this);
        }

        #endregion

        #region Help Menu Event Handlers (Common)

        private void menuShowHelp_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowHelp();
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
            HelpMenu.ShowURL_SearchIderaKnowledgeBase(this);
        }

        private void menuAboutIderaProducts_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowURL_AboutIderaProducts(this);
        }

        private void menuContactTechnicalSupport_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowURL_ContactTechnicalSupport(this);
        }

        private void menuCheckForUpdates_Click(object sender, EventArgs e)
        {
            HelpMenu.CheckForUpdates(this);
        }

        #endregion

        #region Tools Menu (Common )

        private void menuManageServerGroups_Click(object sender, EventArgs e)
        {
            ToolsMenu.ManageServerGroups();
        }

        private void menuToolsetOptions_Click(object sender, EventArgs e)
        {
            ToolsMenu.ShowToolsetOptions();
        }

        private void menuLaunchpad_Click(object sender, EventArgs e)
        {
            ToolsMenu.RunLaunchpad(this);
        }

        #endregion

        #endregion

        #region Program Logic

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

        #region Mover functionality
        private void buttonPreview_Click(object sender, EventArgs e)
        {
            if (ServerSelectionSource.Text == "")
            {
                Messaging.ShowError(ProductConstants.ErrorNoSourceSqlServer);
                return;
            }

            if (ServerSelectionDestination.Text == "")
            {
                Messaging.ShowError(ProductConstants.ErrorNoDestinationSqlServer);
                return;
            }

            if (ServerSelectionSource.Text.Contains(";"))
            {
                Messaging.ShowError(ProductConstants.ErrorSourceInvalidCharacters);
                return;
            }

            if (ServerSelectionDestination.Text.Contains(";"))
            {
                Messaging.ShowError(ProductConstants.ErrorDestinationInvalidCharacters);
                return;
            }

            buttonPreview.Enabled = false;

            try
            {
                ProgressBar_Initialize("Retrieving login list");

                ClearFields();

                _BypassItemCheckEvent = true;

                PreviewWorker.RunWorkerAsync();

                ProgressBar_Show();
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Copy Logins", exc);
                buttonPreview.Enabled = true;
            }
        }

        /// <summary>
        /// Asynchronous preview
        /// </summary>
        private void PreviewWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker _Worker = sender as BackgroundWorker;
            InitializeServers();

            ConnectionAttempt _SourceConnection = new ConnectionAttempt(_SourceServer);
            ConnectionAttempt _DestinationConnection = new ConnectionAttempt(_DestinationServer);

            Thread _InitializeSourceServer = new Thread(delegate () { Connection.Impersonate(ServerSelectionSource.SqlCredentials); TryConnect(_SourceConnection); });
            _InitializeSourceServer.IsBackground = true;
            _InitializeSourceServer.Start();
            Thread _InitializeDestinationServer = new Thread(delegate () { Connection.Impersonate(ServerSelectionDestination.SqlCredentials);  TryConnect(_DestinationConnection); });
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
            if (!Utility.IsValidOperation(_SourceServer, _DestinationServer, true))
            {
                throw new InvalidOperationException(ProductConstants.ErrorNotSupportedSqlCombination);
            }

            e.Result = Utility.FindMissingLogins(_SourceServer, _DestinationServer, _Worker);
        }

        /// <summary>
        /// Attempts to establish an SMO connection with a server.
        /// </summary>
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

        /// <summary>
        /// Preview complete.
        /// </summary>
        private void PreviewWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Messaging.ShowException("Preview Missing Logins", e.Error);
                    return;
                }

                if (e.Cancelled)
                {
                    Messaging.ShowWarning("Preview was canceled by user");
                    return;
                }

                List<Login> _MissingLogins = e.Result as List<Login>;

                if (_MissingLogins != null)
                {
                    listUsers.CheckBoxes = true;

                    if (_MissingLogins.Count > 0)
                    {
                        if (_MissingLogins.Count >= ProductConstants.MaximumNumberOfLogins)
                        {
                            Messaging.ShowInformation(ProductConstants.WarningTooManyLogins);
                        }
                        Application.DoEvents();
                        listUsers.BeginUpdate();
                        foreach (Login _MissingLogin in _MissingLogins)
                        {
                            ListViewItem _Item = new ListViewItem();
                            _Item.SubItems.Add(_MissingLogin.Name);
                            _Item.SubItems.Add(_MissingLogin.LoginType.ToString());
                            _Item.SubItems.Add(ProductConstants.StatusPending);
                            _Item.Tag = _MissingLogin;
                            _Item.Checked = true;
                            listUsers.Items.Add(_Item);
                        }

                        listUsers.EndUpdate();

                        buttonMove.Enabled = true;
                        labelInstructions.Text = ProductConstants.MessageSelectInstructions;
                        listUsers.Columns[0].ImageIndex = (int)ImageIcon.UnCheckedbox;
                    }
                    else
                    {
                        Messaging.ShowInformation(ProductConstants.MessageNoLoginsFound);
                        labelInstructions.Text = ProductConstants.MessageNoLoginsFound;
                    }

                }
            }
            finally
            {
                ProgressBar_Close();
                buttonPreview.Enabled = true;
                _BypassItemCheckEvent = false;
            }
        }


        private void buttonMove_Click(object sender, EventArgs e)
        {
            buttonMove.Enabled = false;

            ProgressBar_Initialize("Initializing");

            List<Login> _LoginsToMove = new List<Login>();
            foreach (ListViewItem _Item in listUsers.CheckedItems)
            {
                _LoginsToMove.Add((Login)_Item.Tag);
            }

            MoverWorker.RunWorkerAsync(_LoginsToMove);

            ProgressBar_Show();
        }

        /// <summary>
        /// Asynchronous mover.
        /// </summary>
        private void MoverWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _MoverUtility = new Utility();
            _MoverUtility.TaskStatus += new EventHandler<StatusEventArgs>(MoverUtility_TaskStatus);
            e.Result = _MoverUtility.MoveLogins(_SourceServer, _DestinationServer, (List<Login>)e.Argument);
        }

        /// <summary>
        /// Asynchronous move complete.
        /// </summary>
        private void MoverWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBar_Update("Processing Results");

            LoginMoveCompleteEventArgs _Args = e.Result as LoginMoveCompleteEventArgs;
            if (e.Error == null && _Args.Success)
            {
                foreach (ListViewItem _Item in listUsers.Items)
                {
                    if (_Item.Checked)
                    {
                        Login _Login = (Login)_Item.Tag;

                        if (_Args.MoveResults[_Login.Name] != null)  //exception thrown for item
                        {
                            SqlException _SqlException = _Args.MoveResults[_Login.Name] as SqlException;
                            if (_SqlException != null)
                            {
                                switch (_SqlException.Number)
                                {
                                    case 15247:  //Not enough permissions to add user to a server role
                                        _Item.SubItems[3].Text = DatabaseMoverLibrary.ProductConstants.StatusSynchronizingSecurityLoginsRolePermissionError;
                                        _Item.ImageIndex = (int)ImageIcon.Warning;
                                        break;
                                    case 15401: //NT User not found at destination
                                        _Item.SubItems[3].Text = ProductConstants.ErrorDestinationServerDoesNotHaveAccessToSourceDomainLogin;
                                        _Item.ImageIndex = (int)ImageIcon.Failure;
                                        break;
                                    case 15021: //Unable to copy login to Server 2012 due to incompatibility
                                        _Item.SubItems[3].Text = ProductConstants.ErrorLoginCannotBeCopied;
                                        _Item.ImageIndex = (int)ImageIcon.Failure;
                                        break;
                                }
                            }
                            else
                            {
                                _Item.SubItems[3].Text = Helpers.GetCombinedExceptionText(_Args.MoveResults[_Login.Name]);
                                _Item.ImageIndex = (int)ImageIcon.Failure;
                            }
                        }
                        else
                        {
                            _Item.SubItems[3].Text = ProductConstants.StatusSuccess;
                            _Item.ImageIndex = (int)ImageIcon.Success;
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
                foreach (ListViewItem _Item in listUsers.Items)
                {
                    if (_Item.Checked)
                    {
                        _Item.SubItems[3].Text = ProductConstants.StatusFailed;
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
                        Messaging.ShowError(_ErrorMessage, ProductConstants.ErrorMovingLoginsCaption);
                    }
                    else
                    {
                        Messaging.ShowException("Move Logins", _Args.TaskException);
                    }
                }
                else if (e.Error != null)
                {
                    Messaging.ShowException(ProductConstants.ErrorMovingLoginsCaption, e.Error);
                }
            }
            listUsers.CheckBoxes = false;
            listUsers.Columns[0].ImageIndex = -1;

            ProgressBar_Close();
        }

        void MoverUtility_TaskStatus(object sender, StatusEventArgs e)
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

        #region control events
        private void listUsers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0 && listUsers.Columns[0].ImageIndex > -1)
            {
                _BypassItemCheckEvent = true;
                if (listUsers.Columns[0].ImageIndex == (int)ImageIcon.UnCheckedbox)
                {
                    listUsers.Columns[0].ImageIndex = (int)ImageIcon.Checkedbox;
                    foreach (ListViewItem _Item in listUsers.Items)
                    {
                        _Item.Checked = true;
                    }
                    buttonMove.Enabled = listUsers.Items.Count > 0;
                }
                else
                {
                    listUsers.Columns[0].ImageIndex = (int)ImageIcon.UnCheckedbox;
                    foreach (ListViewItem _Item in listUsers.Items)
                    {
                        _Item.Checked = false;
                    }
                    buttonMove.Enabled = false;
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
                    listUsers.Sorting = sortOrder;
                }
                else
                {
                    // Determine what the last sort order was and change it.
                    if (listUsers.Sorting == System.Windows.Forms.SortOrder.Ascending)
                        listUsers.Sorting = System.Windows.Forms.SortOrder.Descending;
                    else
                        listUsers.Sorting = System.Windows.Forms.SortOrder.Ascending;
                }

                listUsers.ListViewItemSorter = new ListViewItemComparer(e.Column, listUsers.Sorting);
                listUsers.Sort();
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

                if (order == System.Windows.Forms.SortOrder.Descending) returnVal *= -1;

                return returnVal;
            }
        }

        private void ServerSelection_TextChanged(object sender, EventArgs e)
        {
            buttonPreview.Enabled = ServerSelectionSource.Text.Length != 0 && ServerSelectionDestination.Text.Length != 0;
            buttonMove.Enabled = false;
        }
        private void listUsers_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!_BypassItemCheckEvent)
            {
                try
                {
                    if (listUsers.Columns[0].ImageIndex == (int)ImageIcon.Checkedbox && !e.Item.Checked)
                    {
                        listUsers.Columns[0].ImageIndex = (int)ImageIcon.UnCheckedbox;
                    }

                    buttonMove.Enabled = (listUsers.CheckedItems != null) && (listUsers.CheckedItems.Count != 0);
                }
                catch (Exception ex)
                {
                    buttonMove.Enabled = true;
                }
            }
        }

        #endregion

        private void ClearFields()
        {
            _SourceServer = _DestinationServer = null;
            listUsers.Items.Clear();
            buttonMove.Enabled = false;
            labelInstructions.Text = string.Empty;
            listUsers.Columns[0].ImageIndex = -1;
        }

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
        #endregion

        #region Progress Bar

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
        }

        #endregion

        private void ShowF1Help(object sender, HelpEventArgs hlpevent)
        {
            HelpMenu.ShowHelp();
        }

        private void listUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listUsers.SelectedItems.Count == 1 && !listUsers.CheckBoxes)
            {
                Messaging.ShowInformation(listUsers.SelectedItems[0].SubItems[3].Text, "Copy Status");
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem _Item in listUsers.Items)
            {
                _Item.Selected = true;
            }
        }

        private void Copy()
        {
            int[] _ColumnWidths = new int[listUsers.Columns.Count];

            for (int i = 0; i < _ColumnWidths.Length; i++)
            {
                _ColumnWidths[i] = 35;
            }
            _ColumnWidths[listUsers.Columns.Count - 1] = 75;

            ExportToClipboard.CopyListView("Copy Results", listUsers, _ColumnWidths, true);
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

