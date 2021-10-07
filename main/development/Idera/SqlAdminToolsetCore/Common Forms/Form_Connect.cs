using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Idera.SqlAdminToolset.Core
{
   public partial class Form_Connect : Form
   {
      #region Input Properties

      public string title
      {
         get { return this.Text; }
         set { this.Text = value; }
      }

      public bool m_allowMultipleServers = false;
      public bool allowMultipleServers
      {
         get
         {
            return m_allowMultipleServers;
         }
         set
         {
            m_allowMultipleServers = value;

            if ( m_allowMultipleServers )
            {
               buttonTestConnection.Visible = false;
               this.textServer.WatermarkText =  "SQL Server names (separate by semi-colons)";
               this.toolTip.SetToolTip( this.textServer, "Specify SQL Server instance names separated by semi-colons" );
            }
            else
            {
               buttonTestConnection.Visible = false;
               this.textServer.WatermarkText =  "SQL Server name";
               this.toolTip.SetToolTip( this.textServer, "Specify a SQL Server instance name" );
            }
         }
      }

      #endregion

      #region Output Properties

      public string server
      {
         get
         {
            if ( m_allowMultipleServers )
            {
               StringBuilder normalizedServers = new StringBuilder(512);
               bool first = true;

               string[] servers = textServer.Text.Split(';');
               for ( int i=0;i<servers.Length;i++) servers[i] = servers[i].Trim();
 
               foreach ( string s in servers )
               {
                  if (! first)
                     normalizedServers.Append(";");
                  else       
                     first = false;

                  normalizedServers.Append( SQLHelpers.NormalizeInstanceName(s) );
               }
               return normalizedServers.ToString();
            }
            else
            {
               return SQLHelpers.NormalizeInstanceName(textServer.Text);
            }
         }
      }

      public string[] servers
      {
         get
         {
            string[] servers;
            if ( m_allowMultipleServers )
            {
               servers = textServer.Text.Split(';');
               for ( int i=0;i<servers.Length;i++) servers[i] = servers[i].Trim();

               for( int i=0; i<servers.Length; i++)
               {
                  servers[i] = SQLHelpers.NormalizeInstanceName(servers[i]);
               }
            }
            else
            {
               servers = new string[1];
               servers[0] = SQLHelpers.NormalizeInstanceName(textServer.Text);
            }
            return servers;
         }
      }

      public SQLCredentials sqlCredentials
      {
         get
         {
            return new SQLCredentials( radioSQL.Checked,
                                       textLoginName.Text,
                                       textPassword.Text );
         }
      }

      #endregion

      public Form_Connect()
      {
         InitializeComponent();
      }

      public Form_Connect( string inServer )
      {
         InitializeComponent();

         textServer.Text = inServer;
      }


      protected override void OnLoad( EventArgs e )
      {
         base.OnLoad( e );

         textServer.Select();
      }

      private void buttonBrowseServer_Click( object sender, EventArgs e )
      {
         Cursor = Cursors.WaitCursor;

         Form_SQLServerBrowse browseDlg = new Form_SQLServerBrowse();
         browseDlg.MultiSelect = m_allowMultipleServers;
         bool loaded = browseDlg.LoadServers();
         Cursor = Cursors.Default;

         if (loaded)
         {
             DialogResult choice = browseDlg.ShowDialog();
             if (choice == DialogResult.OK && textServer.Text != browseDlg.SelectedServer)
             {
                 textServer.Text = browseDlg.SelectedServer;
             }
         }
      }

      private void btnOK_Click( object sender, EventArgs e )
      {
            // if sql authentication and user name blank - dont allow close
            if (radioSQL.Checked && textLoginName.Text.Length == 0)
            {
                MessageBox.Show( "A login name is required when using SQL authentication.", 
                                 "Set Connection Credentials",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
      }

      private void textServer_TextChanged( object sender, EventArgs e )
      {
         btnOK.Enabled                = ( textServer.Text.Trim().Length != 0 );
         buttonTestConnection.Enabled = ( textServer.Text.Trim().Length != 0 );
      }

      private void buttonTestConnection_Click( object sender, EventArgs e )
      {
         string normalizedServer = SQLHelpers.NormalizeInstanceName(textServer.Text);
         
         SqlConnection conn = null;

         try
         {
            Cursor = Cursors.WaitCursor;

            conn = Connection.OpenConnection( normalizedServer,
                                              new SQLCredentials( radioSQL.Checked,
                                                                  textLoginName.Text,
                                                                  textPassword.Text) );
            Messaging.ShowInformation( "Successful connection established to " + normalizedServer,
                                       "Test Connection" );
         }
         catch ( Exception ex )
         {
            Messaging.ShowException( "Unable to establish a connection to " + normalizedServer,
                                     ex,
                                     "Test Connection" );
         }
         finally
         {
            Connection.CloseConnection(conn);
            
            Cursor = Cursors.Default;
         }
      }

      private void radioSQLorWindows_CheckedChanged( object sender, EventArgs e )
      {
         textLoginName.Enabled = radioSQL.Checked;
         textPassword.Enabled  = radioSQL.Checked;
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
   }
}