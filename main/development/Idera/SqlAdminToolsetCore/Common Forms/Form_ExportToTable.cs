using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Idera.SqlAdminToolset.Core
{
   public partial class Form_ExportToTable : Form
   {
      #region Public Properties

      public string Server
      {
         get { return SQLHelpers.NormalizeInstanceName(textServer.Text); }
         set { textServer.Text = value; }
      }

      public string Database
      {
         get { return comboDatabase.Text; }
         set { comboDatabase.Text = value; }
      }

      public string Schema
      {
         get { return comboOwner.Text; }
         set { comboOwner.Text = value; }
      }

      public string Table
      {
         get { return comboTable.Text; }
         set { comboTable.Text = value; }
      }

      public SQLCredentials Credentials
      {
         get { return m_Credentials; }
         set { m_Credentials = value; }
      }

      #endregion

      #region Private Properties

      private SQLCredentials m_Credentials   = null;
      private SqlConnection  m_conn          = null;
      private bool           m_loading       = false;
      private bool           m_serverChanged = true;

      #endregion

      #region Ctor

      public Form_ExportToTable()
      {
         InitializeComponent();
      }

      #endregion

      #region Browse Server and Set Credentials

      private void buttonBrowseServer_Click( object sender, EventArgs e )
      {
         Cursor = Cursors.WaitCursor;

         Form_SQLServerBrowse browseDlg = new Form_SQLServerBrowse();
         bool loaded = browseDlg.LoadServers();
         if (loaded)
         {
             DialogResult choice = browseDlg.ShowDialog();
             if (choice == DialogResult.OK && textServer.Text != browseDlg.SelectedServer)
             {
                 textServer.Text = browseDlg.SelectedServer;
             }

           //  VerifyServerEnteredAndLoadDatabases();
         }

         Cursor = Cursors.Default;
      }

      private void buttonCredentials_Click( object sender, EventArgs e )
      {
         Form_Credentials credentialsForm = new Form_Credentials(textServer.Text,m_Credentials);
         DialogResult choice = credentialsForm.ShowDialog();
         if (choice == DialogResult.OK)
         {
            m_Credentials = credentialsForm.sqlCredentials;
         }
      }

      #endregion

      #region Load Object Routines

      private void VerifyServerEnteredAndLoadDatabases()
      {
         if (textServer.Text.Length == 0)
         {
            comboDatabase.Items.Clear();
            comboDatabase.Text = "";
            comboOwner.Items.Clear();
            comboOwner.Text = "";
            comboTable.Items.Clear();
            comboTable.Text = "";
         }
         else
         {
            LoadDatabases();
         }
      }

      //----------------------------------------------------------------------------------
      // LoadDatabases
      //----------------------------------------------------------------------------------
      private void
         LoadDatabases()
      {
         bool ownConnection = false;

         try
         {
            Cursor = Cursors.WaitCursor;

            comboDatabase.Items.Clear();
            comboDatabase.Text    = "";
            comboOwner.Items.Clear();
            comboOwner.Text    = "";
            comboTable.Items.Clear();
            comboTable.Text    = "";

            if ( m_conn == null || m_conn.State == ConnectionState.Closed )
            {
               m_conn = Connection.OpenConnection( textServer.Text, m_Credentials );
               ownConnection = true;
            }

            // load databases into combobox
            ICollection databases = SQLObjects.GetUserDatabases(m_conn);
            foreach ( DatabaseObject db in databases )
            {
               comboDatabase.Items.Add( db.name);
            }

            if ( comboDatabase.Items.Count > 0 )
            {
               comboDatabase.Text = (string)comboDatabase.Items[0];

               // now that we have databases, load the owners
               LoadOwners();
            }
         }
         catch ( Exception ex )
         {
            Messaging.ShowException( "Error loading databases from the selected SQL Server", ex );

            comboDatabase.Items.Clear();
            comboOwner.Items.Clear();
            comboTable.Items.Clear();

            comboDatabase.Text = "";
            comboOwner.Text    = "";
         }
         finally 
         {
            if ( ownConnection ) Connection.CloseConnection(m_conn);

            CheckOkButton();
            Cursor = Cursors.Default;
         }
      }

      //----------------------------------------------------------------------------------
      // LoadOwners
      //----------------------------------------------------------------------------------
      private void LoadOwners()
      {
         bool ownConnection = false;

         try
         {
            Cursor = Cursors.WaitCursor;

            comboOwner.Items.Clear();
            comboOwner.Text    = "";
            comboTable.Items.Clear();
            comboTable.Text    = "";

            if ( m_conn == null || m_conn.State == ConnectionState.Closed )
            {
               m_conn = Connection.OpenConnection( textServer.Text, m_Credentials );
               ownConnection = true;
            }

            if ( SQLHelpers.Is2005orGreater(m_conn) )
            {
               ICollection owners = SQLObjects.GetSchemas(m_conn, comboDatabase.Text);
               foreach ( SchemaObject owner in owners )
               {
                  comboOwner.Items.Add( owner.name);
               }
            }
            else
            {
               comboOwner.Items.Add( "dbo");
            }

            if ( comboOwner.Items.Count > 0 )
            {
               comboOwner.Text = "dbo";

               // now that we have tables; load the owners
               LoadTables();
            }
         }
         catch ( Exception ex )
         {
            Messaging.ShowException( "Error loading owners in the selected database", ex );

            comboOwner.Items.Clear();
            comboTable.Items.Clear();

            comboOwner.Text = "";
            comboTable.Text = "";
         }
         finally 
         {
            if ( ownConnection ) Connection.CloseConnection(m_conn);
            CheckOkButton();
            Cursor = Cursors.Default;
         }
      }

      //----------------------------------------------------------------------------------
      // LoadTables
      //----------------------------------------------------------------------------------
      private void LoadTables()
      {
          bool ownConnection = false;

         try
         {
            Cursor = Cursors.WaitCursor;

            comboTable.Items.Clear();
            comboTable.Text    = "";

            if ( m_conn == null || m_conn.State == ConnectionState.Closed )
            {
               m_conn = Connection.OpenConnection( textServer.Text, m_Credentials );
               ownConnection = true;
            }
            ICollection tables = null;
            if( SQLHelpers.Is2005orGreater(m_conn) )
            {
                tables = SQLObjects.GetTables(m_conn,
                                                      comboDatabase.Text,
                                                      comboOwner.Text );
            }
            else
            {
                tables = SQLObjects.GetTables(m_conn,
                                              comboDatabase.Text);  
            }

            foreach ( TableObject table in tables )
            {
               comboTable.Items.Add( table.name);
            }

            // find an unused table name
            bool found = false;
            string tableName = "";
            for ( int i=1; i<100; i++)
            {
               tableName = "New Table-" + i.ToString();
               if ( ! comboTable.Items.Contains( tableName ) )
               {
                  comboTable.Items.Add( tableName);
                  found = true;
                  break;
               }
            }
            if (! found) tableName = "New Table-1";

            comboTable.Text = tableName;
         }
         catch ( Exception ex )
         {
            Messaging.ShowException( "Error loading tables in the selected database", ex );

            comboTable.Items.Clear();
            comboTable.Text = "";
         }
         finally 
         {
            if ( ownConnection ) Connection.CloseConnection(m_conn);
            CheckOkButton();
            Cursor = Cursors.Default;
         }
      }

      #endregion

      #region Text Change Events

      //----------------------------------------------------------------------------------
      // textServer_Leave
      //----------------------------------------------------------------------------------
      private void textServer_Leave( object sender, EventArgs e )
      {
       
      }

      //----------------------------------------------------------------------------------
      // comboDatabase_SelectedIndexChanged
      //----------------------------------------------------------------------------------
      private void comboDatabase_SelectedIndexChanged( object sender, EventArgs e )
      {
         if ( m_loading ) return;
         try
         {
            Cursor = Cursors.WaitCursor;
            m_loading = true;

            LoadOwners();
         }
         finally
         {
            m_loading = false;
            Cursor = Cursors.Default;
         }
      }

      //----------------------------------------------------------------------------------
      // comboOwner_SelectedIndexChanged
      //----------------------------------------------------------------------------------
      private void comboOwner_SelectedIndexChanged( object sender, EventArgs e )
      {
         if ( m_loading ) return;
         try
         {
            Cursor = Cursors.WaitCursor;
            m_loading = true;

            LoadTables();
         }
         finally
         {
            m_loading = false;
            Cursor = Cursors.Default;
         }

      }

      //----------------------------------------------------------------------------------
      // comboTable_SelectedIndexChanged
      //----------------------------------------------------------------------------------
      private void comboTable_SelectedIndexChanged( object sender, EventArgs e )
      {
         if ( m_loading ) return;
         try
         {
            Cursor = Cursors.WaitCursor;
            m_loading = true;

            CheckOkButton();
         }
         finally
         {
            m_loading = false;
            Cursor = Cursors.Default;
         }
      }

      //----------------------------------------------------------------------------------
      // CheckOKButton
      //----------------------------------------------------------------------------------
      private void CheckOkButton()
      {
            // enable OK button
            btnOK.Enabled = ( textServer.Text.Length!=0
                              && comboDatabase.Text.Length!=0
                              && comboOwner.Text.Length!=0
                              && comboTable.Text.Length!=0 );
      }

      #endregion

      private void btnOK_Click( object sender, EventArgs e )
      {
         bool ownConnection = false;

         // check if exists
         bool tableExists = false;
         
         string existsSql2000 = String.Format( "USE {0};select count(o.Name) from sysobjects o where o.Name='{1}' and xtype='U'",
                                               SQLHelpers.CreateSafeDatabaseName(this.Database),
                                               this.Table );
         string existsSql2005 = String.Format( "USE {0};select count(o.Name) from sysobjects o, sys.schemas s where o.Name='{1}' and o.uid=s.schema_id and s.name='{2}' and xtype='U'",
                                               SQLHelpers.CreateSafeDatabaseName(this.Database),
                                               this.Table,
                                               this.Schema );
        
         try
         {
            Cursor = Cursors.WaitCursor;
            
            if ( m_conn == null || m_conn.State == ConnectionState.Closed )
            {
               m_conn = Connection.OpenConnection( textServer.Text, m_Credentials );
               ownConnection = true;
            }
            
            string sql = existsSql2005;
            if ( SQLHelpers.Is2000(m_conn) ) 
               sql = existsSql2000;
            
            using ( SqlCommand cmd = new SqlCommand( sql, m_conn ) )
            {
               cmd.CommandTimeout = ToolsetOptions.commandTimeout;
               int count = (int)cmd.ExecuteScalar();
               tableExists = (count!=0);
            }
            
            if ( tableExists )
            {
               // if exists ask if they want to overwrite - if no return to choosing tablename
               DialogResult choice = Messaging.ShowConfirmation( "The specified table already exists. Do you want to overwrite this table?" );
               if ( choice == DialogResult.Yes )
               {
                  string dropSql = String.Format( "USE {0};DROP TABLE [{1}].[{2}]",
                                                  SQLHelpers.CreateSafeDatabaseName(this.Database),
                                                  this.Schema,
                                                  this.Table );
                  using ( SqlCommand cmd = new SqlCommand( dropSql, m_conn ) )
                  {
                     cmd.CommandTimeout = ToolsetOptions.commandTimeout;
                     cmd.ExecuteNonQuery();
                  }

                  DialogResult = DialogResult.OK;
               }
            }
            else
            {
               // no table by the suggested name - just continue
               DialogResult = DialogResult.OK;
            }
         }
         finally 
         {
            if ( ownConnection ) Connection.CloseConnection(m_conn);
            Cursor = Cursors.Default;
         }
      }

       private void textServer_KeyPress( object sender, KeyPressEventArgs e )
       {
         // eat semi-colons so user cant try to supply multiple servers
         if (e.KeyChar == ';')
         {
            e.Handled=true; // input is not passed on to the control(TextBox) 
         }
         base.OnKeyPress (e);
       }

       private void comboDatabase_Enter(object sender, EventArgs e)
       {
           if (m_serverChanged)
           {
               try
               {
                   Cursor = Cursors.WaitCursor;
                   m_loading = true;

                   VerifyServerEnteredAndLoadDatabases();
               }
               finally
               {
                   m_loading = false;
                   m_serverChanged = false;
                   Cursor = Cursors.Default;
               }
           }
       }

       private void textServer_TextChanged(object sender, EventArgs e)
       {
           m_serverChanged = true;
       }
   }
}