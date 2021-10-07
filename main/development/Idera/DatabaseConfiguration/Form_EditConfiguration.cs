using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.DatabaseConfiguration
{
   public partial class Form_EditConfiguration: Form
   {
      private ConfigurationData _Data;

      public Form_EditConfiguration(ConfigurationData data)
      {
         _Data = data;
         InitializeComponent();
         this.Size = new Size(this.Size.Width, 135);
         buttonCancel.Location = new Point(buttonCancel.Location.X, 70);
         buttonOK.Location = new Point(buttonOK.Location.X, 70);
         labelDatabases.Visible = listUpdateDatabaseList.Visible = false;
         this.MinimumSize = this.Size;
      }

      public Form_EditConfiguration(ConfigurationData data, List<string> databaseList)
      {
         InitializeComponent();
         _Data = data;

         if (databaseList != null && databaseList.Count > 0)
         {
            foreach (string _Database in databaseList)
            {
               listUpdateDatabaseList.Items.Add(_Database, true);
            }
            this.Size = new Size(this.Size.Width, 400);
            buttonCancel.Location = new Point(buttonCancel.Location.X, 335);
            buttonOK.Location = new Point(buttonOK.Location.X, 335);
            labelDatabases.Visible = listUpdateDatabaseList.Visible = true;
            this.MinimumSize = this.Size;
         }
      }

      protected override void OnLoad(EventArgs e)
      {
         base.OnLoad( e );
         
         foreach (KeyValuePair<string, string> _ValidValue in _Data.ValidValues)
         {
            listNewValue.Items.Add(_ValidValue);
         }

         for (int i = 0; i < listNewValue.Items.Count; i++)
         {
            if (((KeyValuePair<string, string>)listNewValue.Items[i]).Value == _Data.Value)
            {
               listNewValue.SelectedIndex = i;
               break;
            }
         }
         labelConfigurationName.Text = _Data.Name;
      }

      private void buttonOK_Click(object sender, EventArgs e)
      {
         _Data.Value = listNewValue.Text;
         DialogResult = DialogResult.OK;
      }

      private void buttonCancel_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
      }

      public ConfigurationData Data
      {
         get
         {
            return _Data;
         }
      }

      /// <summary>
      /// Selected databases.
      /// </summary>
      public List<string> SelectedDatabases
      {
         get
         {
            List<string> _SelectedDatabases = new List<string>();
            foreach (object _Item in listUpdateDatabaseList.CheckedItems)
            {
               _SelectedDatabases.Add(_Item.ToString());
            }
            return _SelectedDatabases;
         }
      }
   }
}