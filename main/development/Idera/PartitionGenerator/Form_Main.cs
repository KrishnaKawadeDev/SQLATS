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
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.PartitionGenerator
{
    public partial class Form_Main : Form
    {
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

            base.OnLoad(e);
            if (!Startup.GuiStartup(this, menuTools, menuAbout, ideraTitleBar1))
            {
                Close();
                return;
            }

            #endregion

            ProductConstants.ReadOptions();
            sqlCredentials = ProductConstants.lastCredentials;
            textServer.Text = ProductConstants.lastServer;

            // Program Specific Logic
            //labelSubtitle.Text = ProductConstants.productDescription;
            columnRowCount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnIsPartitioned.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnDetails.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            listDatabase.Enabled = checkShowPartitionedOnly.Enabled = false;
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

        #region SQL Server & Credentials Field Handling

        SQLCredentials sqlCredentials = null;

        private void buttonCredentials_Click(object sender, EventArgs e)
        {
            Form_Credentials credentialsForm = new Form_Credentials(textServer.Text, sqlCredentials);
            DialogResult choice = credentialsForm.ShowDialog();
            if (choice == DialogResult.OK)
            {
                sqlCredentials = credentialsForm.sqlCredentials;
            }
        }

        private void buttonBrowseServer_Click(object sender, EventArgs e)
        {
            Form_SQLServerBrowse browseDlg = new Form_SQLServerBrowse();

            Cursor = Cursors.WaitCursor;
            bool loaded = browseDlg.LoadServers();
            Cursor = Cursors.Default;

            if (loaded)
            {
                DialogResult choice = browseDlg.ShowDialog();
                if (choice == DialogResult.OK)
                {
                    if (textServer.Text != browseDlg.SelectedServer)
                    {
                        textServer.Text = browseDlg.SelectedServer;
                    }
                }
            }
        }

        #endregion

        #region Program Logic

        ServerInformation _ServerInfo = null;
        string _Database = string.Empty;
        List<string> _FileGroups = new List<string>();
        List<TableInfo> _Tables = null;

        /// <summary>
        /// Retrieves a list of all database tables and their partition information.
        /// </summary>
        private void RefreshTables()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                gridTables.Rows.Clear();
                _Database = listDatabase.Text;
                if (_Tables == null)
                {
                    _Tables = PartitionHelper.GetTableList(_ServerInfo, _Database);
                }

                foreach (TableInfo _Info in _Tables)
                {
                    if ((checkShowPartitionedOnly.Checked && _Info.IsPartitioned) || !checkShowPartitionedOnly.Checked)
                    {
                        int _RowIndex = gridTables.Rows.Add(string.Format("{0}.{1}", _Info.Schema, _Info.Name), _Info.RowCount, null, _Info.PartitionScheme, _Info.IsPartitioned ? "View" : "Create");
                        if (!_Info.IsPartitioned)
                        {
                            gridTables.Rows[_RowIndex].Cells[columnIsPartitioned.Name].Value = new Bitmap(1, 1);
                        }
                        gridTables.Rows[_RowIndex].Cells[columnDetails.Name].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        gridTables.Rows[_RowIndex].Tag = _Info;
                    }
                }
                gridTables.Tag = _Tables;

                _FileGroups.Clear();
                _FileGroups = PartitionHelper.GetFileGroups(_ServerInfo, _Database);
                Cursor = Cursors.Default;

                if (_Tables.Count == 0)
                {
                    Messaging.ShowInformation(ProductConstants.InformationNoTablesFound);
                }
            }
            catch (Exception exc)
            {
                Cursor = Cursors.Default;
                Messaging.ShowException("Retrieve Table Data", exc);
            }
        }

        private void gridTables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == columnDetails.Index && e.RowIndex > -1)
                {
                    TableInfo _Table = gridTables.Rows[e.RowIndex].Tag as TableInfo;
                    if (_Table != null)
                    {
                        PartitionAction _Action = PartitionAction.View;
                        PartitionScheme _Scheme = null;
                        if (_Table.PartitionScheme.Length > 0)
                        {
                            _Scheme = PartitionHelper.GetPartitionScheme(_ServerInfo, _Database, _Table);
                        }
                        else
                        {
                            _Action = PartitionAction.Create;
                        }
                        Form_PartitionInfo _PartitionForm = new Form_PartitionInfo(_ServerInfo, _Database, _Action, _FileGroups);
                        _PartitionForm.Scheme = _Scheme;
                        _PartitionForm.Table = _Table;
                        if (_PartitionForm.ShowDialog() == DialogResult.OK)
                        {
                            if (_Action == PartitionAction.Create)
                            {
                                _Tables = null;
                                RefreshTables();
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Messaging.ShowException("Schema Information", exc);
            }
        }

        private void checkShowPartitionedOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (_Tables != null)
            {
                RefreshTables();
            }
        }

        private void buttonGetDatabases_Click(object sender, EventArgs e)
        {
            // Validation
            if (textServer.Text.Trim().Length == 0)
            {
                Core.Messaging.ShowError("Specify a SQL Server instance name.");
                textServer.Select();
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
               
                ProductConstants.lastServer = textServer.Text;
                ProductConstants.lastCredentials = sqlCredentials;
                ProductConstants.WriteOptions();

                listDatabase.Items.Clear();
                gridTables.Rows.Clear();
                listDatabase.Enabled = checkShowPartitionedOnly.Enabled = false;
                Application.DoEvents();
                _ServerInfo = new ServerInformation(textServer.Text, sqlCredentials);
                using (SqlConnection _Connection = Connection.OpenConnection(_ServerInfo.Name, _ServerInfo.SqlCredentials))
                {
                    if (SQLHelpers.Is2005orGreater(_Connection))
                    {
                        SQLVersion _Version;
                        if (SQLVersion.TryParse(SQLHelpers.GetSqlVersionString(_Connection), out _Version))
                        {
                            if (SQLHelpers.Is2017orGreater(_Connection)==true || _Version.Edition.StartsWith("Enterprise") || _Version.Edition.StartsWith("Developer") || _Version.Edition.StartsWith("Data Center")
                                || (SQLHelpers.Is2016orGreater(_Connection) == true && SQLHelpers.GetSqlServicePackName(_Connection).StartsWith("SP")))
                            {
                                bool _ExcludedDatabases = false;

                                foreach (KeyValuePair<string, byte> _Database in PartitionHelper.GetDatabaseList(_Connection))
                                {
                                    if (_Database.Value >= 80)
                                    {
                                        listDatabase.Items.Add(_Database.Key);
                                    }
                                    else
                                    {
                                        _ExcludedDatabases = true;
                                    }
                                }
                                Cursor = Cursors.Default;

                                if (listDatabase.Items.Count > 0)
                                {
                                    listDatabase.SelectedIndex = 0;
                                }
                                else
                                {
                                    Messaging.ShowError(ProductConstants.ErrorNoDatabasesFound);
                                    return;
                                }

                                listDatabase.Enabled = checkShowPartitionedOnly.Enabled = true;

                                if (_ExcludedDatabases)
                                {
                                    Messaging.ShowInformation(ProductConstants.InformationDatabasesExcluded);
                                }
                            }
                            else
                            {
                                Cursor = Cursors.Default;
                                Messaging.ShowError(ProductConstants.ErrorOnlyEnterpriseEditionSupported);
                            }
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            Messaging.ShowError(ProductConstants.ErrorUnableToGetVersionInformation);
                        }
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                        Messaging.ShowError(ProductConstants.ErrorOnlySql2005OrAboveSupported);
                    }
                }
            }
            catch (Exception exc)
            {
                Cursor = Cursors.Default;
                Messaging.ShowException("Connect to server", exc);
                return;
            }
        }

        private void listDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Tables = null;
            RefreshTables();
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

