using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.ServerConfiguration
{
   public partial class Form_OpenSnapshot : Form
   {
      #region Properties
      
      public string snapshotFile
      {
         get { return comboSnapshot.Text; }
      }

      public bool clearAllExisting
      {
         get { return checkClearAll.Checked; }
      }

      #endregion

      #region Ctor

      public Form_OpenSnapshot()
      {
         InitializeComponent();
      }

      protected override void OnLoad( EventArgs e )
      {
         base.OnLoad( e );
         
         //load snapshots from default directory
         foreach ( string snapshotFile in Directory.GetFiles(ProductConstants.SnapshotDirectory, "*.xml") )
         {
            comboSnapshot.Items.Add( snapshotFile );
         }
         if ( comboSnapshot.Items.Count != 0 )
         {
            comboSnapshot.Text = comboSnapshot.Items[0].ToString();
         }
      }

      #endregion

      private void comboSnapshot_SelectedIndexChanged( object sender, EventArgs e )
      {
         buttonOK.Enabled = (comboSnapshot.Text.Length != 0);
      }

      private void buttonBrowse_Click( object sender, EventArgs e )
      {
          OpenFileDialog _FileDialog = new OpenFileDialog();
          _FileDialog.CheckFileExists = true;
          _FileDialog.DefaultExt = "xml";
          _FileDialog.Filter = "XML File (*.xml)|*.xml|All Files (*.*)|*.*";
          _FileDialog.Multiselect = false;
          _FileDialog.InitialDirectory = ProductConstants.SnapshotDirectory;
          if (_FileDialog.ShowDialog() == DialogResult.OK)
          {
             comboSnapshot.Text = _FileDialog.FileName;
             buttonOK.Enabled = true;
          }
      }

      private void buttonOK_Click( object sender, EventArgs e )
      {
         // check if path exists
         if ( ! File.Exists( comboSnapshot.Text ) )
         {
             Messaging.ShowError( "The specified snaphot file can not be found.", "Open Snapshot" );
             return;
         }
         
         DialogResult = DialogResult.OK;
         Close();
      }
   }
}