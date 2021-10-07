/* 
 * SQL admin toolset © 2007, 2012 Idera, Inc. and Idera.
 * 
 * Idera reserves all rights in the program and source code as delivered.  The program 
 * or any portion thereof may not be reproduced or reverse engineered in any form 
 * whatsoever without the written consent of Idera.  
 * 
 * A license to the software does not constitute authorization.
 */

using System;
using System.Windows.Forms;
using System.Reflection;
using Idera.SqlAdminToolset.Core;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Idera.SqlAdminToolset.Core
{
  public partial class Form_AddServerToGroup : Form
  {
        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        public string[] serverList
        {
            get
            {
                string[] servers = textServer.Text.Trim().Split(';');
                for (int i = 0; i < servers.Length; i++) servers[i] = servers[i].Trim();
                return servers;
            }
        }

        public SQLCredentials sqlCredentials
        {
            get
            {
                if (radioSQL.Checked)
                    return new SQLCredentials(true, textLoginName.Text, textPassword.Text);
                else if(!string.IsNullOrEmpty(textLoginName.Text)&&!string.IsNullOrEmpty(textPassword.Text))
                    return new SQLCredentials(false, textLoginName.Text, textPassword.Text);
                else
                    return null;
            }
        }

        public Form_AddServerToGroup()
        {
            InitializeComponent();
            textLoginName.WatermarkText = userName;
            textServer.Select();
        }

        private void textServer_TextChanged(object sender, EventArgs e)
    {
      buttonOK.Enabled             = (textServer.Text.Trim().Length != 0);
      buttonTestConnection.Enabled = (textServer.Text.Trim().Length != 0);
    }

     private void buttonBrowse_Click( object sender, EventArgs e )
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

     private void radioWindowsSql_CheckedChanged(object sender, EventArgs e)
     {
            if (radioWindows.Checked)
                textLoginName.WatermarkText = userName;
            else
                textLoginName.WatermarkText = string.Empty;


            //textLoginName.Enabled = radioSQL.Checked;
            //textPassword.Enabled  = radioSQL.Checked;
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

     private void buttonOK_Click( object sender, EventArgs e )
     {
        if ( radioSQL.Checked && textLoginName.Text.Trim().Length == 0 )
        {
           Messaging.ShowError("A login name is required when using SQL authentication.",
                               "Add Servers to Server Group");
           DialogResult = DialogResult.None;
        }
        else
        {
           DialogResult = DialogResult.OK;
        }
     }
   }
}