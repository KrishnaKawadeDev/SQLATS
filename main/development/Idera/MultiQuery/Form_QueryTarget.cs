using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using Idera.SqlAdminToolset.Core;
using System.Security.Principal;
using System.Threading;

namespace Idera.SqlAdminToolset.MultiQuery
{
    public partial class Form_QueryTarget : Form
    {
        #region Properties

        private bool m_editMode = false;
        private SQLCredentials m_credentials = null;
        QueryTarget m_originalQueryTarget = null;

        public List<QueryTarget> queryTargetList
        {
            get
            {
                if (radioGroups.Checked)
                {
                    return CreateQueryTargetList(true, textServerGroup.Text);
                }
                else
                {
                    return CreateQueryTargetList(false, textServer.Text);
                }
            }
        }

        #endregion
        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        //-----------------------------------------------------------------------
        // Constructors
        //-----------------------------------------------------------------------
        public Form_QueryTarget()
        {
            InitializeComponent();

            this.Text = "Add Query Target";
            m_editMode = false;
            radioServers.Text = "SQL Server(s):";
            textLoginName.WatermarkText = userName;
            LoadServerGroups(null);

            textServer.Text = "(local)";
            textServer.Select();

            SetButtons();
        }

        public Form_QueryTarget(
              QueryTarget inQueryTarget
           )
        {
            InitializeComponent();

            this.Text = "Edit Query Target";
            m_editMode = true;
            radioServers.Text = "SQL Server:";

            // save original values
            m_originalQueryTarget = inQueryTarget;

            if (inQueryTarget.isServerGroup)
            {
                // editing server group
                radioGroups.Checked = true;
                LoadServerGroups(inQueryTarget.server);
                textServerGroup.Select();
            }
            else
            {
                // editing server
                radioServers.Checked = true;
                textServer.Text = inQueryTarget.server;


                if (inQueryTarget.credentials == null)
                {
                    radioWindows.Checked = true;
                }
                else if (inQueryTarget.credentials.useWindowsAuthentication)
                {
                    radioWindows.Checked = true;
                    textLoginName.Text = inQueryTarget.credentials.loginName;
                    textPassword.Text = inQueryTarget.credentials.password;
                    textLoginName.WatermarkText = userName;
                }
                else
                {
                    radioSQL.Checked = true;
                    textLoginName.Text = inQueryTarget.credentials.loginName;
                    textPassword.Text = inQueryTarget.credentials.password;
                    textLoginName.WatermarkText = string.Empty;
                }
                textServer.Select();
            }

            if (String.IsNullOrEmpty(inQueryTarget.database))
            {
                radioDefaultDatabase.Checked = true;
            }
            else
            {
                radioSpecifiedDatabase.Checked = true;
                textDatabase.Text = inQueryTarget.database;
            }

            SetButtons();
        }

        //-----------------------------------------------------------------------
        // CreateQueryTargetList
        //-----------------------------------------------------------------------
        private List<QueryTarget>
           CreateQueryTargetList(
              bool isGroup,
              string server
           )
        {
            List<QueryTarget> listQueryTargets = new List<QueryTarget>();

            string db = radioDefaultDatabase.Checked ? "" : textDatabase.Text;
            string[] databaseList = db.Split(';');

            foreach (string database in databaseList)
            {
                if (isGroup)
                {
                    // server group - there can be only one
                    QueryTarget qt = new QueryTarget(server);
                    qt.isServerGroup = true;
                    qt.credentials = null;
                    qt.database = database;

                    listQueryTargets.Add(qt);
                }
                else
                {
                    // server list
                    string[] servers = server.Split(';');
                    foreach (string s in servers)
                    {
                        if (s.Trim().Length == 0) continue;

                        string normalizedServer = SQLHelpers.NormalizeInstanceName(s);
                        QueryTarget qt = new QueryTarget(normalizedServer);
                        qt.isServerGroup = false;
                        qt.credentials = new SQLCredentials(radioSQL.Checked, textLoginName.Text, textPassword.Text);
                        qt.database = database;

                        listQueryTargets.Add(qt);
                    }
                }
            }

            return listQueryTargets;
        }

        //-----------------------------------------------------------------------
        // radioWindows_CheckedChanged
        //-----------------------------------------------------------------------
        private void radioWindows_CheckedChanged(object sender, EventArgs e)
        {
            textLoginName.Enabled =
            textPassword.Enabled =
            labelLoginName.Enabled =
            labelPassword.Enabled = true;
            textLoginName.Text = string.Empty;
            textPassword.Text = string.Empty;
            if (radioWindows.Checked)
                textLoginName.WatermarkText = userName;
            else
                textLoginName.WatermarkText = string.Empty;
        }

        //-----------------------------------------------------------------------
        // textServer_TextChanged
        //-----------------------------------------------------------------------
        private void textServer_TextChanged(object sender, EventArgs e)
        {
            SetOkButtonStatus();

            buttonTestConnection.Enabled = (radioServers.Checked) && (textServer.Text.Trim().Length != 0);
        }

        //-----------------------------------------------------------------------
        // textServerGroup_TextChanged
        //-----------------------------------------------------------------------
        private void textServerGroup_TextChanged(object sender, EventArgs e)
        {
            // do something for special entries
            // Manage, Browse, No Groups Available

            SetOkButtonStatus();
        }

        //-----------------------------------------------------------------------
        // SetOkButtonStatus
        //-----------------------------------------------------------------------
        private void SetOkButtonStatus()
        {
            if (radioGroups.Checked)
            {
                // buttonBrowseDatabase.Enabled = true;
                textDatabase.Text = null;
                bool specialItem = false;
                try
                {
                    DevComponents.Editors.ComboItem comboItem = (DevComponents.Editors.ComboItem)textServerGroup.SelectedItem;
                    specialItem = (comboItem != null) && ((bool)comboItem.Tag);
                }
                catch
                {
                    /* this handles case where someone inserts without special APIs */
                }

                if (!specialItem && textServerGroup.Text.Length != 0)
                {
                    btnOK.Enabled = true;
                }
                else
                {
                    btnOK.Enabled = false;
                }
            }
            else
            {
                buttonBrowseDatabase.Enabled = radioSpecifiedDatabase.Checked;

                // server
                btnOK.Enabled = (textServer.Text.Trim().Length != 0) &&
                                (radioWindows.Checked || textLoginName.Text.Trim().Length != 0);
            }
        }

        //-----------------------------------------------------------------------
        // btnOK_Click
        //-----------------------------------------------------------------------
        private void btnOK_Click(object sender, EventArgs e)
        {
            List<QueryTarget> queryTargetList;
            if (radioGroups.Checked)
            {
                queryTargetList = CreateQueryTargetList(true, textServerGroup.Text);
            }
            else
            {
                queryTargetList = CreateQueryTargetList(false, textServer.Text);
            }

            if (queryTargetList.Count == 0)
            {
                Messaging.ShowError("Specify at least on server or server group for the query target");
                btnOK.Enabled = false;
                return;
            }

            // if we are editing we can only have one query target
            // if nothing has changed then there is nothing to do
            if (m_editMode && queryTargetList[0].Match(m_originalQueryTarget))
            {
                // nothing changed - just return 
                DialogResult = DialogResult.Cancel;
                return;
            }

            // if we are editing and server/database didnt change
            // do an update
            if (m_editMode && queryTargetList[0].MatchServerDatabasePairing(m_originalQueryTarget))
            {
                DialogResult = DialogResult.OK;
                return;
            }

            // Since we are here we are either adding new query targets or have edited the server
            // or database so we must check if targets are already in main list 
            string matches = "";
            string notMatchList = "";
            int matchCount = 0;
            foreach (QueryTarget qt in queryTargetList)
            {
                int ndx = ProductConstants.mainform.FindQueryTarget(qt);
                if (ndx != -1)
                {
                    matchCount++;
                    if (matches != "") matches += "\r\n";
                    matches += "    " + qt.server;
                }
                else
                {
                    if (notMatchList != "") notMatchList += ";";
                    notMatchList += qt.server;
                }
            }

            if (matchCount == 0)
            {
                // none in list match - just return
                DialogResult = DialogResult.OK;
            }
            else if (matchCount == queryTargetList.Count)
            {
                // all in list already exist
                string msg;
                if (matchCount == 1)
                    msg = String.Format("A Query target is already defined for this {0}/database pairing",
                                         radioGroups.Checked ? "server group" : "SQL Server");
                else
                    msg = "Query targets already defined for these server/database pairings";

                Messaging.ShowError(msg);
                DialogResult = DialogResult.None;
            }
            else
            {
                string msg = "Query targets already exist for the following SQL Servers:\r\n\r\n" + matches;

                DialogResult choice = Messaging.ShowError(msg,
                                                           ProductConstants.productName,
                                                           "Do you want to continue and add query targets for the other SQL Servers?");
                if (choice == DialogResult.Yes)
                {
                    textServer.Text = notMatchList;
                    DialogResult = DialogResult.OK;
                }
                else
                    DialogResult = DialogResult.None;
            }
            return;
        }

        //-----------------------------------------------------------------------
        // buttonCredentials_Click
        //-----------------------------------------------------------------------
        private void buttonCredentials_Click(object sender, EventArgs e)
        {
            Form_Credentials credentialsForm = new Form_Credentials(textServer.Text, m_credentials);
            DialogResult choice = credentialsForm.ShowDialog();
            if (choice == DialogResult.OK)
            {
                m_credentials = credentialsForm.sqlCredentials;
            }
        }

        //-----------------------------------------------------------------------
        // radioServers_CheckedChanged
        //-----------------------------------------------------------------------
        private void radioServers_CheckedChanged(object sender, EventArgs e)
        {
            if (radioServers.Checked)
            {
                textServerGroup.Enabled = false;
                textServer.Enabled = true;
                SetButtons();
                textServer.SelectAll();
                textDatabase.Text = null;
            }
            textServer.Select();

            SetOkButtonStatus();
        }

        //-----------------------------------------------------------------------
        // radioGroups_CheckedChanged
        //-----------------------------------------------------------------------
        private void radioGroups_CheckedChanged(object sender, EventArgs e)
        {
            if (radioGroups.Checked)
            {
                textServer.Enabled = false;
                textServerGroup.Enabled = true;

                SetButtons();
            }
            textServerGroup.Select();


            SetOkButtonStatus();
        }

        //-----------------------------------------------------------------------
        // SetButtons
        //-----------------------------------------------------------------------
        private void SetButtons()
        {
            //--------------------
            // supporting buttons
            //--------------------
            groupAuthentication.Enabled =
            buttonBrowseServer.Enabled =
            radioWindows.Enabled =
            radioSQL.Enabled = (radioServers.Checked);

            buttonTestConnection.Enabled = (radioServers.Checked) && (textServer.Text.Trim().Length != 0);

            if (radioSQL.Enabled)
            {
                labelLoginName.Enabled =
                labelPassword.Enabled =
                textLoginName.Enabled =
                textPassword.Enabled = true;
            }
            else
            {
                labelLoginName.Enabled =
                labelPassword.Enabled =
                textLoginName.Enabled =
                textPassword.Enabled = false;
            }
        }

        //-----------------------------------------------------------------------
        // buttonBrowseServer_Click
        //-----------------------------------------------------------------------
        private void buttonBrowseServer_Click(object sender, EventArgs e)
        {
            Form_SQLServerBrowse browseDlg = new Form_SQLServerBrowse();
            browseDlg.MultiSelect = true;

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

        private void radioDefaultDatabase_CheckedChanged(object sender, EventArgs e)
        {
            textDatabase.Enabled = radioSpecifiedDatabase.Checked;
            buttonBrowseDatabase.Enabled = radioSpecifiedDatabase.Checked;
            textDatabase.Text = null;

            //if (radioSpecifiedDatabase.Checked == true)
            //{
            //    // radioSpecifiedDatabase.CheckedChanged += new EventHandler(OnradioSpecifiedDatabaseCheck);
            //}
            SetOkButtonStatus();
        }

        //private void OnradioSpecifiedDatabaseCheck(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        IList dbList = null;

        //        string[] servers = textServer.Text.Split(';');
        //        SqlConnection conn = null;
        //        AutoCompleteStringCollection dbCollection = new AutoCompleteStringCollection();
        //        SQLCredentials sqlCredentials = new SQLCredentials(radioSQL.Checked, textLoginName.Text, textPassword.Text);

        //        conn = Connection.OpenConnection(servers[0], sqlCredentials);
        //        string cmdstr = "SELECT name, dbid, cmptlevel, status, sid" +
        //                          " FROM master..sysdatabases " +
        //                        " WHERE has_dbaccess(name) = 1 " +
        //                          " ORDER by name ASC";

        //        using (SqlCommand cmd = new SqlCommand(cmdstr, conn))
        //        {
        //            cmd.CommandTimeout = ToolsetOptions.commandTimeout;

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                dbList = new ArrayList();

        //                while (reader.Read())
        //                {
        //                    DatabaseObject db = new DatabaseObject();
        //                    db.name = reader.GetString(0);
        //                    db.dbid = reader.GetInt16(1);
        //                    db.compatabilityLevel = reader.GetByte(2);
        //                    db.status = reader.GetInt32(3);
        //                    dbCollection.Add(reader.GetValue(0).ToString());

        //                    // get database sid - if == 0x1 its a system database
        //                    int len = (int)reader.GetBytes(4, 0, null, 0, 0);
        //                    if (len > 0)
        //                    {
        //                        db.sid = new byte[len];
        //                        reader.GetBytes(4, 0, db.sid, 0, len);
        //                    }

        //                    // exclude system databases
        //                    if (!SQLHelpers.IsSystemDatabase(db.name)) //BySid(db.sid) )
        //                    {
        //                        dbList.Add(db);
        //                    }

        //                    textDatabase.AutoCompleteCustomSource = dbCollection;

        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}

        #region Server Group Support

        static private string _stringBrowseForGroups = "<Browse to select from all Server Groups>";
        static private string _stringManageGroups = "<Manage Server Groups>";
        static public string _stringNoGroupsDefined = "No Server Groups Defined";

        //-----------------------------------------------------------------------
        // LoadServerGroups
        //-----------------------------------------------------------------------
        private void LoadServerGroups(string selectedGroup)
        {
            //---------------------
            // Show Server Groups
            //---------------------

            // save last select group
            string m_SaveGroupText = String.IsNullOrEmpty(selectedGroup) ? textServerGroup.Text : selectedGroup;

            // setup control
            textServerGroup.SelectedIndex = -1;
            //this.toolTip1.SetToolTip( this.textServerGroup, "Select a Server Group or choose <Manage Server Groups> to create and edit Server Groups." );

            // load groups
            LoadDropDownItems();

            int ndx = FindListItem(m_SaveGroupText);
            if (ndx != -1 || textServerGroup.Items.Count > 1)
            {
                textServerGroup.SelectedIndex = (ndx != -1) ? ndx : 0;
            }
        }

        //-----------------------------------------------------------------------
        // FindListItem
        //-----------------------------------------------------------------------
        private int FindListItem(string name)
        {
            int pos = -1;

            for (int i = 0; i < textServerGroup.Items.Count; i++)
            {
                if (textServerGroup.Items[i].ToString() == name)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }



        //-----------------------------------------------------------------------
        // LoadDropDownItems
        //-----------------------------------------------------------------------
        private void LoadDropDownItems()
        {
            _saveGroupText = textServerGroup.Text;
            textServerGroup.Items.Clear();
            m_lastSelectedIndex = -1;

            //--------------------
            // Load Server Groups
            //--------------------
            int foundNdx = -1;
            int count = 0;
            List<ToolServerGroup> groups = ToolServerGroup.GetAllServerGroups();

            if (groups.Count == 0)
            {
                _saveGroupText = _stringNoGroupsDefined;
                AddComboBoxItem(_stringNoGroupsDefined, true);
                textServerGroup.Text = _stringNoGroupsDefined;
                textServerGroup.SelectedIndex = 0;
            }
            else
            {
                foreach (ToolServerGroup grp in groups)
                {
                    AddComboBoxItem(grp.FullPath, false);

                    if (grp.FullPath == _saveGroupText) foundNdx = count;

                    count++;
                    if (count == 25) break;
                }

                // do we need to add saved group?
                if (foundNdx == -1)
                {
                    ToolServerGroup tsg = ToolServerGroup.FindServerGroup(_saveGroupText);
                    if (tsg == null)
                    {
                        _saveGroupText = (groups.Count == 0) ? "" : groups[0].FullPath;
                    }
                    else
                    {
                        // add to list
                        AddComboBoxItem(_saveGroupText, false);
                    }
                }
            }

            if (groups.Count > 25)
            {
                AddComboBoxItem(_stringBrowseForGroups, true);
            }
            AddComboBoxItem(_stringManageGroups, true);
        }

        //-----------------------------------------------------------------------
        // InsertComboBoxItem
        //-----------------------------------------------------------------------
        private void
           InsertComboBoxItem(
              int ndx,
              string itemText,
              bool specialItem
           )
        {
            DevComponents.Editors.ComboItem newItem = CreateComboBoxItem(itemText, specialItem);
            textServerGroup.Items.Insert(ndx, newItem);
        }

        //-----------------------------------------------------------------------
        // AddComboBoxItem
        //-----------------------------------------------------------------------
        private int
           AddComboBoxItem(
              string itemText,
              bool specialItem
           )
        {
            DevComponents.Editors.ComboItem newItem = CreateComboBoxItem(itemText, specialItem);
            return textServerGroup.Items.Add(newItem);
        }

        //-----------------------------------------------------------------------
        // CreateComboBoxItem
        //-----------------------------------------------------------------------
        private DevComponents.Editors.ComboItem
           CreateComboBoxItem(
              string itemText,
              bool specialItem
           )
        {
            DevComponents.Editors.ComboItem newItem = new DevComponents.Editors.ComboItem();
            newItem.Text = itemText;
            newItem.TextLineAlignment = StringAlignment.Center;
            newItem.Tag = (object)specialItem;

            return newItem;
        }

        #endregion

        string _saveGroupText = "";
        int m_lastSelectedIndex = -1;
        string m_lastSelectedGroup = "";

        private void textServerGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool specialItem = false;
            try
            {
                DevComponents.Editors.ComboItem comboItem = (DevComponents.Editors.ComboItem)textServerGroup.SelectedItem;
                specialItem = (comboItem != null) && ((bool)comboItem.Tag);
            }
            catch
            {
                /* this handles case where someone inserts without special APIs */
            }

            if (specialItem && textServerGroup.Text == _stringBrowseForGroups)
            {
                Application.DoEvents(); // let form redraw without drop down dropped
                string newSelection = BrowseGroups();

                if (newSelection == "")
                {
                    textServerGroup.SelectedIndex = m_lastSelectedIndex;
                }
                else
                {
                    // they selected one with browse (is it already there?)
                    bool found = false;
                    for (int i = 0; i < textServerGroup.Items.Count; i++)
                    {
                        if (textServerGroup.Items[i].ToString() == newSelection)
                        {
                            found = true;
                            textServerGroup.SelectedIndex = i;
                            break;
                        }
                    }

                    if (!found)
                    {
                        // walk backwards to insert before special tag items
                        int ndx;
                        for (ndx = textServerGroup.Items.Count - 1; ndx >= 0; ndx--)
                        {
                            try
                            {
                                DevComponents.Editors.ComboItem combo = (DevComponents.Editors.ComboItem)(textServerGroup.Items[ndx]);
                                if (!(bool)combo.Tag)
                                {
                                    ndx++;
                                    break;
                                }
                            }
                            catch
                            {
                                break;
                            }
                        }
                        if (ndx == -1) ndx = 0;

                        InsertComboBoxItem(ndx, newSelection, false);
                        textServerGroup.SelectedIndex = ndx;
                    }
                }
            }
            else if (specialItem && textServerGroup.Text == _stringNoGroupsDefined)
            {
                // do nothing?
                m_lastSelectedGroup = textServerGroup.Text;
            }
            else if (specialItem && textServerGroup.Text == _stringManageGroups)
            {
                Application.DoEvents(); // let form redraw without drop down dropped

                //launch
                Form_ManageServerGroups frm = new Form_ManageServerGroups();
                DialogResult dialogResult = frm.ShowDialog();

                //reload
                string _saveGroupText = m_lastSelectedGroup;

                if (dialogResult == DialogResult.OK)
                {
                    LoadDropDownItems();
                }

                int ndx = FindListItem(_saveGroupText);
                if (ndx != -1 || textServerGroup.Items.Count > 1)
                {
                    textServerGroup.SelectedIndex = (ndx != -1) ? ndx : 0;
                }
                else
                {
                    textServerGroup.SelectedIndex = -1;
                }
            }
            else
            {
                m_lastSelectedIndex = textServerGroup.SelectedIndex;
                m_lastSelectedGroup = textServerGroup.Text;
            }

            SetOkButtonStatus();
        }

        //-----------------------------------------------------------------------
        // BrowseGroups
        //-----------------------------------------------------------------------
        private string BrowseGroups()
        {
            string newSelection = "";

            // Browse Server Groups
            Form_ServerGroupBrowse dlg = new Form_ServerGroupBrowse();
            DialogResult choice = dlg.ShowDialog();
            if (choice == DialogResult.OK)
            {
                newSelection = dlg.FullPath;
            }

            return newSelection;
        }

        private void textServerGroup_DropDown(object sender, EventArgs e)
        {
            LoadServerGroups(null);
        }

        private void textServer_KeyPress(object sender, KeyPressEventArgs e)
        {
            // eat semi-colons so user cant try to supply multiple servers
            if (m_editMode)
            {
                if (e.KeyChar == ';')
                {
                    //Console.Beep();
                    e.Handled = true; // input is not passed on to the control(TextBox) 
                }
                base.OnKeyPress(e);
            }
        }

        private void buttonTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Connection.TestConnection(this,
                                           textServer.Text,
                                           radioSQL.Checked,
                                           textLoginName.Text,
                                           textPassword.Text);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        private void buttonBrowseDatabase_Click(object sender, EventArgs e)
        {
            if (radioGroups.Checked)
            {
                List<ServerInformation> serverList;
                bool loaded = false;
                Form_DatabaseBrowse browseDlg = new Form_DatabaseBrowse("", null);
                SQLCredentials sqlCredentials;

                ToolServerGroup serverGroup = ToolServerGroup.FindServerGroup(textServerGroup.Text);
                if (serverGroup == null)
                {
                    throw new Exception("The specified server group does not exist.");
                }
                else
                {
                    serverList = new List<ServerInformation>();
                    foreach (ToolServer toolServer in (serverGroup.GetServers(true)))
                    {
                        string srv = SQLHelpers.NormalizeInstanceName(toolServer.Name);
                        serverList.Add(new ServerInformation(srv, toolServer.Credentials));
                    }

                    if (serverList.Count == 0)
                    {
                        Cursor = Cursors.WaitCursor;
                        loaded = browseDlg.LoadDatabases(true,true);
                        Cursor = Cursors.Default;
                    }
                    else
                    {
                        foreach (var server in serverList)
                        {
                            if (server.SqlCredentials == null || Convert.ToString(server.SqlCredentials) == "")
                            {
                                sqlCredentials = new SQLCredentials(false, "", "", textDatabase.Text);
                            }
                            else
                            {
                                sqlCredentials = new SQLCredentials(server.SqlCredentials.useSqlAuthentication, server.SqlCredentials.loginName, server.SqlCredentials.password, textDatabase.Text);
                            }
                            browseDlg = new Form_DatabaseBrowse(server.Name, sqlCredentials);

                            browseDlg.allowMultiSelect = true;

                            Cursor = Cursors.WaitCursor;
                            loaded = browseDlg.LoadDatabases();
                            Cursor = Cursors.Default;
                        }
                    }
                }
                if (loaded)
                {
                    DialogResult choice = browseDlg.ShowDialog();
                    if (choice == DialogResult.OK)
                    {
                        textDatabase.Text = browseDlg.SelectedDatabase;
                    }
                }
            }
            else
            {
                string[] servers = textServer.Text.Split(';');
                if (servers.Length > 0)
                {
                    SQLCredentials sqlCredentials = new SQLCredentials(radioSQL.Checked, textLoginName.Text, textPassword.Text, textDatabase.Text);

                    Form_DatabaseBrowse browseDlg = new Form_DatabaseBrowse(servers[0], sqlCredentials);

                    browseDlg.allowMultiSelect = true;

                    Cursor = Cursors.WaitCursor;
                    bool loaded = browseDlg.LoadDatabases();
                    Cursor = Cursors.Default;

                    if (loaded)
                    {
                        DialogResult choice = browseDlg.ShowDialog();
                        if (choice == DialogResult.OK)
                        {
                            textDatabase.Text = browseDlg.SelectedDatabase;
                        }
                    }
                }
            }
        }
    }
}