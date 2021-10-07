using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace Idera.SqlAdminToolset.Core
{
    /// <summary>
    /// Summary description for Form_DatabaseBrowse.
    /// </summary>
    public partial class Form_DatabaseBrowse : Form
    {
        #region Properties

        private bool m_allowMultiSelect = false;
        public bool allowMultiSelect
        {
            get { return m_allowMultiSelect; }
            set
            {
                m_allowMultiSelect = value;

                if (m_allowMultiSelect)
                    listBoxDatabases.SelectionMode = SelectionMode.MultiExtended;
                else
                    listBoxDatabases.SelectionMode = SelectionMode.One;
            }
        }

        public string SelectedDatabase
        {
            get
            {
                if (listBoxDatabases.SelectedItems.Count == 0)
                    return null;
                else
                {
                    string dbs = listBoxDatabases.SelectedItems[0].ToString();
                    if (dbs == "Database Not Found")
                    {
                        btnOK.Enabled = false;
                        return null;
                    }
                    for (int i = 1; i < listBoxDatabases.SelectedItems.Count; i++)
                    {
                        dbs += ";" + listBoxDatabases.SelectedItems[i].ToString();
                    }

                    return dbs;
                }
            }
        }

        public string[] SelectedDatabaseList
        {
            get
            {
                string[] dbList = null;
                if (listBoxDatabases.SelectedItems.Count != 0)
                {
                    dbList = new string[listBoxDatabases.SelectedItems.Count];
                    for (int i = 0; i < listBoxDatabases.SelectedItems.Count; i++)
                    {
                        dbList[i] = listBoxDatabases.SelectedItems[i].ToString();
                    }
                }
                return dbList;
            }
        }

        private string m_server = "";
        private SQLCredentials sqlCredentials = new SQLCredentials();
        //private SQLCredentials sqlCredentials;
        private bool m_loaded = false;

        #endregion

        #region Constructor / Dispose

        //-----------------------------------------------------------------------
        // Constructor
        //-----------------------------------------------------------------------
        public
           Form_DatabaseBrowse(
              string inServer
           )
        {
            // Required for Windows Form Designer support
            InitializeComponent();
            //   listBoxDatabases1.Clear();
            m_server = inServer;
            sqlCredentials = new SQLCredentials();
        }

        public
           Form_DatabaseBrowse(
              string inServer,
              SQLCredentials inSqlCredentials

           )
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            m_server = inServer;
            if (inSqlCredentials != null) { sqlCredentials = inSqlCredentials; }
            
        }

        #endregion

        #region Form Events

        //-----------------------------------------------------------------------
        // override OnLoad
        //-----------------------------------------------------------------------
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            databaseList.Clear();
            labelPrompt.Text = String.Format("Select Database from {0}", m_server);

            if (!m_loaded)
            {
                Cursor = Cursors.WaitCursor;
                LoadDatabases();

                if (listBoxDatabases.Items.Count != 0)
                {
                    listBoxDatabases.Select();
                    labelNoDatabases.Visible = false;
                }
                else
                {
                    labelNoDatabases.Visible = false;
                }

                Cursor = Cursors.Default;
            }
        }

        //-----------------------------------------------------------------------
        // btnCancel_Click
        //-----------------------------------------------------------------------
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // listBoxDatabases1.Clear();
            this.Close();
        }

        //-----------------------------------------------------------------------
        // btnOK_Click
        //-----------------------------------------------------------------------
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //-----------------------------------------------------------------------
        // listBoxDatabases_SelectedIndexChanged
        //-----------------------------------------------------------------------
        private void listBoxDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDatabases.SelectedItems.Count > 0)
                btnOK.Enabled = true;
            else
                btnOK.Enabled = false;
        }

        #endregion

        #region Load list logic

        //-----------------------------------------------------------------------
        // LoadDatabases
        //-----------------------------------------------------------------------
        public bool
             LoadDatabases()
        {
            return LoadDatabases(true);
        }

        private static List<string> databaseList = new List<string>();
     
        public bool
             LoadDatabases(
                bool userDatabaseOnly
             )
        {
            m_loaded = false;
            SqlConnection conn = null;

            try
            {              
                conn = Connection.OpenConnection(m_server, sqlCredentials);
                ICollection databases = SQLObjects.GetUserDatabases(conn);
                string searchQuery = sqlCredentials.searchPattern;
                searchQuery = searchQuery.ToLower();

                foreach (DatabaseObject db in databases)
                {
                    databaseList.Add(db.name);
                }

                foreach (var db in databaseList.ToList().Where(x => x.ToLower().Contains(searchQuery.ToLower())))
                {
                   
                    listBoxDatabases.Items.Add(db);
                    listBoxDatabases.SelectedItem = db;
                }
                if (listBoxDatabases.Items.Count <= 0)
                {
                    btnOK.Enabled = false;
                    listBoxDatabases.Items.Add("Database Not Found");

                }

                if (!userDatabaseOnly)
                {
                    databases = SQLObjects.GetSystemDatabases(conn);

                    foreach (DatabaseObject db in databases)
                    {
                        listBoxDatabases.Items.Add(db.name);
                    }
                }

                m_loaded = true;
            }
            catch (Exception ex)
            {
                Messaging.ShowError(String.Format("An error ocurred retrieving the databases on {0}.\r\n\r\nError: {1}",
                                                    m_server,
                                                    ex.Message),
                                 "Error enumerating Databases");
            }
            finally
            {
                Connection.CloseConnection(conn);

                this.Cursor = Cursors.Default;
            }
            return m_loaded;
        }



        public bool
             LoadDatabases(
                bool userDatabaseOnly,bool serverlist
             )
        {
            m_loaded = true;
           listBoxDatabases.Items.Add("Database Not Found");
           return m_loaded;
        }


        #endregion

        private void listBoxDatabases_DoubleClick(object sender, EventArgs e)
        {
            if (btnOK.Enabled)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

    }
}
