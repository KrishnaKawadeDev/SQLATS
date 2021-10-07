#region SQL admin toolset © 2007, 2012 Idera, Inc. and Idera.

/* 
 * Idera reserves all rights in the program and source code as delivered.  The program 
 * or any portion thereof may not be reproduced or reverse engineered in any form 
 * whatsoever without the written consent of Idera.  
 * 
 * A license to the software does not constitute authorization.
 */

#endregion

using System;
using System.Windows.Forms;
using System.Reflection;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SqlDiscovery
{
  public partial class Form_CheckServerPasswords : Form
  {
   
    private bool m_loading = false;
    public Form_CheckServerPasswords( string [] inServers )
    {
      InitializeComponent();
      
      m_loading = true;
      
      foreach (string s in inServers )
      {
         ListViewItem lvi = checklistServers.Items.Add( s );
         lvi.Checked = true;
      }
      
      m_loading = false;
    }
    
    public Form_CheckServerPasswords( List<ServerForPassword> listServers )
    {
      InitializeComponent();
      
      m_loading = true;
      
      foreach (ServerForPassword s in listServers )
      {
         ListViewItem lvi = checklistServers.Items.Add( s.name );
         lvi.Checked = s.selected;
      }
      
      m_loading = false;
    }

     protected override void OnLoad( EventArgs e )
     {
        base.OnLoad( e );
        
        CheckButtonStatus();
     }

    private void textServerGroup_TextChanged(object sender, EventArgs e)
    {
       CheckButtonStatus();
    }
    
    private void CheckButtonStatus()
    {
       if ( m_loading ) return;
       
      bool enabled = true;

      if (  ( checklistServers.CheckedItems       == null ) 
         || ( checklistServers.CheckedItems.Count == 0    ) )
      {
         enabled = false;
      }
      
      buttonOK.Enabled = enabled;
    }

     private void buttonOK_Click( object sender, EventArgs e )
     {
        if ( checklistServers.CheckedItems != null && checklistServers.CheckedItems.Count != 0 )
        {
           // launch password checker
           string args = "/NOWELCOMESCREEN \"/SERVER:" + checklistServers.CheckedItems[0].Text;
           for (int i=1; i< checklistServers.CheckedItems.Count; i++ )
           {
              args += ";";
              args += checklistServers.CheckedItems[i].Text;
           }
           args += "\"";

           // launch password checker
            try
            {
               Cursor = Cursors.WaitCursor;

               string path = System.IO.Path.GetDirectoryName( Application.ExecutablePath );
               string fullPath = Path.Combine( path, "PasswordChecker.exe" );
               Process.Start( fullPath, args );
               
               Close();
            }
            catch ( Exception ex )
            {
               Messaging.ShowException( "Error starting the Password Checker tool.", ex );
            }
            finally
            {
               Cursor = Cursors.Default;
            }
        }
     }
      
     private void buttonSelectAll_Click( object sender, EventArgs e )
     {
        foreach ( ListViewItem lvi in checklistServers.Items )
        {
           lvi.Checked = true;
        }
     }

     private void buttonClearAll_Click( object sender, EventArgs e )
     {
        foreach ( ListViewItem lvi in checklistServers.Items )
        {
           lvi.Checked = false;
        }
     }
  }
}