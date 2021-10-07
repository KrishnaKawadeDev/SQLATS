using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.ServerPing
{
   public partial class Form_ServerProperties : Form
   {
      #region Properties & Accessors
        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        private bool             m_editMode;
      private MonitoredServer  m_saveMonitoredServer;
      
      public List<MonitoredServer> Servers
      {
         get
         {
            SQLCredentials sqlCredentials = new SQLCredentials( radioSQL.Checked,
                                                                textLoginName.Text,
                                                                textPassword.Text );
            string [] serverList = textServer.Text.Split(';');
            
            List<MonitoredServer> servers = new List<MonitoredServer>();
            foreach ( string srv in serverList )
            {
               MonitoredServer s = new MonitoredServer( SQLHelpers.NormalizeInstanceName(srv), 
                                                        sqlCredentials,
                                                        checkIgnore.Checked );
               servers.Add( s );                                                        
            }
            return servers;
         }
      }
      
      #endregion
      
      #region CTOR
      
      public Form_ServerProperties()
      {
         InitializeComponent();

         m_editMode = false;
            textLoginName.WatermarkText = userName;
         this.Text = "Add Server";
         this.Icon = Icon.FromHandle(((Bitmap)imageList1.Images[0]).GetHicon());
      }
      
      public Form_ServerProperties( MonitoredServer monitoredServer )
      {
         InitializeComponent();
         
         this.Text = "Edit Server";
         this.Icon = Icon.FromHandle(((Bitmap)imageList1.Images[1]).GetHicon());

         m_editMode = true; 
         
         textServer.Text = monitoredServer.server;

            if (monitoredServer.credentials == null)
            {
                radioWindows.Checked = true;
            }
            else if (monitoredServer.credentials.useWindowsAuthentication)
            {
                radioWindows.Checked = true;
                textLoginName.Text = monitoredServer.credentials.loginName;
                textPassword.Text = monitoredServer.credentials.password;
                textLoginName.WatermarkText = userName;
            }
            else
            {
                radioSQL.Checked = true;
                textLoginName.Text = monitoredServer.credentials.loginName;
                textPassword.Text = monitoredServer.credentials.password;
                textLoginName.WatermarkText = string.Empty;
            }

            checkIgnore.Checked = monitoredServer.ignore;

         //save input for dirty check            
         m_saveMonitoredServer = monitoredServer;
      }
      
      #endregion

      private void btnOK_Click( object sender, EventArgs e )
      {
         if ( textServer.Text.Trim().Length == 0 )
         {
            Messaging.ShowError( "You must specify a SQL Server name." );
            DialogResult = DialogResult.None;
            return;
         }
         
         if ( radioSQL.Checked && textLoginName.Text.Trim().Length == 0 )
         {
            Messaging.ShowError("A login name is required when using SQL authentication." );
            DialogResult = DialogResult.None;
            return;
         }
         
         if ( m_editMode )
         {
            // Editing servers
            bool dirty = false;
            
            if ( ( textServer.Text != m_saveMonitoredServer.server ) ||
                 ( m_saveMonitoredServer.credentials.useSqlAuthentication != radioSQL.Checked ) ||
                 (  (( textLoginName.Text != m_saveMonitoredServer.credentials.loginName ) ||
                                            ( textPassword.Text  != m_saveMonitoredServer.credentials.password ) ) ) ||
                 ( checkIgnore.Checked != m_saveMonitoredServer.ignore )
               )
            {
               dirty = true;
            }
            
            if ( ! dirty )
            {
               DialogResult = DialogResult.Cancel;
            }
            else
            {
               DialogResult = DialogResult.OK;
            }
         }
         else
         {
            // Adding Servers
            DialogResult = DialogResult.OK;
         }
      }

      private void radioWindows_CheckedChanged(object sender, EventArgs e)
        {
            textLoginName.Text =string.Empty;
            textPassword.Text = string.Empty;
            textLoginName.Enabled =
            textPassword.Enabled = true;
            if (radioSQL.Checked)
                textLoginName.WatermarkText = string.Empty;
            else
                textLoginName.WatermarkText = userName;
        }

      private void buttonTestConnection_Click( object sender, EventArgs e )
      {
        try
        {
           Cursor = Cursors.WaitCursor;
           Connection.TestConnection( textServer.Text,
                                      radioSQL.Checked,
                                      textLoginName.Text,
                                      textPassword.Text );
         }
         finally
         {
            Cursor = Cursors.Default;
         }
      }

      private void Form_ServerProperties_Load( object sender, EventArgs e )
      {

      }

      private void buttonBrowseServer_Click( object sender, EventArgs e )
      {
        Form_SQLServerBrowse browseDlg = new Form_SQLServerBrowse();
        browseDlg.MultiSelect = true;

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
   }
}