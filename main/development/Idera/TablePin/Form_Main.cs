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

using Idera.SqlAdminToolset.Core;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.TablePin
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

            // Program Specific Logic
            textServer.Select();
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

        #region SQL Server & Credentials

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

        #region Clipboard

        private void buttonCopyToClipboard_Click(object sender, EventArgs e)
        {
            CopyResultsToClipboard(false);
        }

        private void menuCopyResultsToClipboard_Click(object sender, EventArgs e)
        {
            CopyResultsToClipboard(true);
        }

        private void contextMenuCopy_Click(object sender, EventArgs e)
        {
            CopyResultsToClipboard(true);
        }

        private void CopyResultsToClipboard(bool selectedOnly)
        {
            ExportToClipboard.CopyListViewToTabbedFormat(listResults, true, selectedOnly);
            /*
            int[] columnWidths = { 0,    // icon
                                   20,   // database
                                   30,   // tablename
                                   6,    // isPinned
                                   11,   // numRows
                                   11};  // estimated Size
            ExportToClipboard.CopyListView( groupResults.Text,
                                        listResults,
                                        columnWidths );
            */
        }

        private void menuSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void contextMenuSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void SelectAll()
        {
            foreach (ListViewItem lvi in listResults.Items)
            {
                lvi.Selected = true;
            }
        }

        private void menuCSV_Click(object sender, EventArgs e)
        {
            ExportToCSV.CopyListView(listResults);
        }

        private void menuXML_Click(object sender, EventArgs e)
        {
            ExportToXML.CopyListView(listResults, "Table Pin", true);
        }

        private void contextMenuCSV_Click(object sender, EventArgs e)
        {
            ExportToCSV.CopyListView(listResults);
        }

        private void contextMenuXML_Click(object sender, EventArgs e)
        {
            ExportToXML.CopyListView(listResults, "Table Pin", true);
        }

        #endregion

        #region Program Logic - Load List

        private void buttonGetResults_Click(object sender, EventArgs e)
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
                labelStatus.Text = "Loading pinned table information...";
                labelStatus.Visible = true;
                labelEmptyResultSet.Visible = false;

                if (checkHideUnpinnedTables.Checked)
                    groupResults.Text = "Pinned Tables on " + textServer.Text;
                else
                    groupResults.Text = "Pinned Status of all Tables on " + textServer.Text;


                // Set up ListView Columns
                listResults.Items.Clear();
                Application.DoEvents();

                // column heading
                // Pinned Tables on {0}
                // Tables on {0}

                // Get data for list

                bool notSQL2000orLower = false;
                ICollection results = SqlRoutines.GetPinnedTables(textServer.Text,
                                                                   sqlCredentials,
                                                                   checkHideUnpinnedTables.Checked,
                                                                   out notSQL2000orLower);



                if (notSQL2000orLower)
                {
                    labelStatus.Text = "";
                    labelEmptyResultSet.Text = String.Format("The Pin Table feature no longer exist as of SQL Server 2005.");
                    labelEmptyResultSet.Visible = true;

                    labelTotalDatabases.Text = String.Format(ProductConstants.strTotalDatabases, "");
                    labelDatabasesWithPinnedTables.Text = String.Format(ProductConstants.strDatabaseWithPinnedTables, "");
                    labelTotalTables.Text = String.Format(ProductConstants.strTotalTables, "");
                    labelTotalPinnedTables.Text = String.Format(ProductConstants.strPinnedTables, "");
                    labelRows.Text = String.Format(ProductConstants.strRows, "");
                    labelEstimatedSize.Text = String.Format(ProductConstants.strEstimatedSizeBlank, "");
                }
                else if (results != null && results.Count != 0)
                {
                    foreach (PinResult result in results)
                    {
                        ListViewItem r = new ListViewItem("", result.isPinned ? 0 : 1);
                        r.SubItems.Add(result.database);
                        r.SubItems.Add(result.owner + "." + result.table);
                        r.SubItems.Add(result.isPinned ? "Yes" : "No");
                        r.SubItems.Add(result.numRows.ToString());
                        r.SubItems.Add(Helpers.StrFormatByteSize(result.estimatedSize));
                        r.Tag = result;
                        listResults.Items.Add(r);
                    }

                    if (results.Count != 0)
                    {
                        listResults.Items[0].Selected = true;
                        listResults.Select();
                    }

                    labelStatus.Text = String.Format("{0} tables", listResults.Items.Count);

                    labelTotalDatabases.Text = String.Format(ProductConstants.strTotalDatabases, PinCounts.databases);
                    labelDatabasesWithPinnedTables.Text = String.Format(ProductConstants.strDatabaseWithPinnedTables, PinCounts.pinnedDatabase);
                    labelTotalTables.Text = String.Format(ProductConstants.strTotalTables, PinCounts.tables);
                    labelTotalPinnedTables.Text = String.Format(ProductConstants.strPinnedTables, PinCounts.pinnedTables);
                    labelRows.Text = String.Format(ProductConstants.strRows, PinCounts.totalRows);
                    labelEstimatedSize.Text = String.Format(ProductConstants.strEstimatedSize, Helpers.StrFormatByteSize(PinCounts.totalSize));
                }
                else
                {
                    labelStatus.Text = "";
                    labelEmptyResultSet.Text = String.Format("There are no pinned tables on this SQL Server.");
                    labelEmptyResultSet.Visible = true;

                    labelTotalDatabases.Text = String.Format(ProductConstants.strTotalDatabases, PinCounts.databases);
                    labelDatabasesWithPinnedTables.Text = String.Format(ProductConstants.strDatabaseWithPinnedTables, PinCounts.pinnedDatabase);
                    labelTotalTables.Text = String.Format(ProductConstants.strTotalTables, PinCounts.tables);
                    labelTotalPinnedTables.Text = String.Format(ProductConstants.strPinnedTables, PinCounts.pinnedTables);
                    labelRows.Text = String.Format(ProductConstants.strRows, PinCounts.totalRows);
                    labelEstimatedSize.Text = String.Format(ProductConstants.strEstimatedSize, Helpers.StrFormatByteSize(PinCounts.totalSize));
                }
            }
            catch
            {
                labelStatus.Text = "";
                labelEmptyResultSet.Text = "Could not retrieve pinned table information.";
                labelEmptyResultSet.Visible = true;

                labelTotalDatabases.Text = String.Format(ProductConstants.strTotalDatabases, ProductConstants.strUnknown);
                labelDatabasesWithPinnedTables.Text = String.Format(ProductConstants.strDatabaseWithPinnedTables, ProductConstants.strUnknown);
                labelTotalTables.Text = String.Format(ProductConstants.strTotalTables, ProductConstants.strUnknown);
                labelTotalPinnedTables.Text = String.Format(ProductConstants.strPinnedTables, ProductConstants.strUnknown);
                labelRows.Text = String.Format(ProductConstants.strRows, ProductConstants.strUnknown);
                labelEstimatedSize.Text = String.Format(ProductConstants.strEstimatedSize, ProductConstants.strUnknown);

                //
                // Update Dashboard
                //
            }
            finally
            {
                Cursor = Cursors.Default;

                buttonCopyToClipboard.Enabled = (listResults.Items.Count != 0);
                contextMenuSelectAll.Enabled = buttonCopyToClipboard.Enabled;
                menuSelectAll.Enabled = buttonCopyToClipboard.Enabled;
                menuExport.Enabled = buttonCopyToClipboard.Enabled;
                contextMenuExport.Enabled = buttonCopyToClipboard.Enabled;
            }
        }

        private void listResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonPinTable.Enabled = false;
            buttonUnpinTable.Enabled = false;
            if (listResults.SelectedItems.Count != 0)
            {
                PinResult r = (PinResult)(listResults.SelectedItems[0].Tag);
                buttonPinTable.Enabled = !r.isPinned;
                buttonUnpinTable.Enabled = r.isPinned;

                menuCopyResultsToClipboard.Enabled = true;
                contextMenuCopy.Enabled = true;
            }
            else
            {
                menuCopyResultsToClipboard.Enabled = false;
                contextMenuCopy.Enabled = false;
            }

            contextMenuPin.Enabled = buttonPinTable.Enabled;
            contextMenuUnpin.Enabled = buttonUnpinTable.Enabled;
        }

        #endregion

        #region Pin & Unpin Table

        private void contextMenuPin_Click(object sender, EventArgs e)
        {
            PinTable();
        }

        private void buttonPinTable_Click(object sender, EventArgs e)
        {
            PinTable();
        }

        private void PinTable()
        {
            if (listResults.SelectedItems.Count == 0)
            {
                buttonPinTable.Enabled = false;
                contextMenuPin.Enabled = false;
                return;
            }

            PinResult r = (PinResult)(listResults.SelectedItems[0].Tag);
            if (SqlRoutines.PinTable(textServer.Text,
                                       r,
                                       sqlCredentials))
            {
                listResults.SelectedItems[0].ImageIndex = 0;

                ((PinResult)(listResults.SelectedItems[0].Tag)).isPinned = true;
                buttonPinTable.Enabled = false;
                contextMenuPin.Enabled = false;
                buttonUnpinTable.Enabled = true;
                contextMenuUnpin.Enabled = true;
            }
        }

        private void contextMenuUnpin_Click(object sender, EventArgs e)
        {
            UnpinTable();
        }

        private void buttonUnpinTable_Click(object sender, EventArgs e)
        {
            UnpinTable();
        }

        private void UnpinTable()
        {
            if (listResults.SelectedItems.Count == 0)
            {
                buttonUnpinTable.Enabled = false;
                contextMenuUnpin.Enabled = false;
                return;
            }

            PinResult r = (PinResult)(listResults.SelectedItems[0].Tag);
            if (SqlRoutines.UnpinTable(textServer.Text,
                                         r,
                                       sqlCredentials))
            {
                listResults.SelectedItems[0].ImageIndex = 1;

                ((PinResult)(listResults.SelectedItems[0].Tag)).isPinned = false;
                buttonPinTable.Enabled = true;
                contextMenuPin.Enabled = true;
                buttonUnpinTable.Enabled = false;
                contextMenuUnpin.Enabled = false;
            }
        }
        #endregion

        #region Column Sorting

        private int sortColumn = -1;
        private System.Windows.Forms.SortOrder sortOrder = System.Windows.Forms.SortOrder.Ascending;

        private void ResetSort()
        {
            sortColumn = -1;
            listResults.Sorting = sortOrder;
        }

        private void listResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;

                // Set the sort order to ascending by default.
                listResults.Sorting = sortOrder;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listResults.Sorting == System.Windows.Forms.SortOrder.Ascending)
                    listResults.Sorting = System.Windows.Forms.SortOrder.Descending;
                else
                    listResults.Sorting = System.Windows.Forms.SortOrder.Ascending;
            }

            listResults.ListViewItemSorter = new ListViewItemComparer(e.Column, listResults.Sorting);
            listResults.Sort();
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
                PinResult r1 = (PinResult)(((ListViewItem)x).Tag);
                PinResult r2 = (PinResult)(((ListViewItem)y).Tag);

                if (col == 4 /* rows */ )
                {
                    returnVal = 0;
                    if (r1.numRows < r2.numRows) returnVal = -1;
                    if (r1.numRows > r2.numRows) returnVal = 1;
                }
                else if (col == 5 /* size */ )
                {
                    returnVal = 0;
                    if (r1.estimatedSize < r2.estimatedSize) returnVal = -1;
                    if (r1.estimatedSize > r2.estimatedSize) returnVal = 1;
                }
                else /* the rest of the columns are simple strings */
                {
                    returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                                ((ListViewItem)y).SubItems[col].Text);
                }

                if (order == System.Windows.Forms.SortOrder.Descending) returnVal *= -1;

                return returnVal;
            }
        }
        #endregion

        private void textServer_KeyPress(object sender, KeyPressEventArgs e)
        {
            // eat semi-colons so user cant try to supply multiple servers
            if (e.KeyChar == ';')
            {
                e.Handled = true; // input is not passed on to the control(TextBox) 
            }
            base.OnKeyPress(e);
        }

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

