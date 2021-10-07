using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.SqlDiscovery
{
   public partial class Form_AddLoadIP : Form
   {
      public string FileName = "";
      
      public Form_AddLoadIP()
      {
         InitializeComponent();
      }

      private void buttonBrowseIPList_Click( object sender, EventArgs e )
      {
         OpenFileDialog ofd = new OpenFileDialog();
         ofd.Title           = "Select IP List File";
         ofd.CheckFileExists = true;
         ofd.DefaultExt = "txt";
         ofd.Filter = "TXT File (*.txt)|*.txt|All Files (*.*)|*.*";
         ofd.Multiselect = false;
         
         DialogResult choice = ofd.ShowDialog();
         if ( choice == DialogResult.OK )
         {
            txtIPListFileName.Text = ofd.FileName;
         }
      }

      private void txtIPListFileName_TextChanged( object sender, EventArgs e )
      {
         btnOK.Enabled = (txtIPListFileName.Text.Trim().Length > 0);
      }

      private void btnOK_Click( object sender, EventArgs e )
      {
         FileName = txtIPListFileName.Text.Trim();
      }
   }
}