using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.ServerConfiguration
{
   public partial class Form_EditConfiguration : Form
   {
      private ConfigurationData _Data;

      public Form_EditConfiguration()
      {
         InitializeComponent();
         this.Size = new Size(this.Size.Width, 205);
         buttonCancel.Location = new Point(buttonCancel.Location.X, 140);
         buttonOK.Location = new Point(buttonOK.Location.X, 140);
         labelServers.Visible = listUpdateServerList.Visible = false;
         this.MinimumSize = this.Size;
      }

      public Form_EditConfiguration(List<string> serverList)
      {
         InitializeComponent();

         if (serverList != null && serverList.Count > 0)
         {
            foreach(string _Server in serverList)
            {
               listUpdateServerList.Items.Add(_Server, true);
            }
            this.Size = new Size(this.Size.Width, 385);
            buttonCancel.Location = new Point(buttonCancel.Location.X, 320);
            buttonOK.Location = new Point(buttonOK.Location.X, 320);
            labelServers.Visible = listUpdateServerList.Visible = true;
            this.MinimumSize = this.Size;
         }
      }

      protected override void OnLoad(EventArgs e)
      {
          if (_Data.Type == ConfigurationType.Security)
          {
              dropDownNewValue.Visible = true;
              textNewValue.Visible = false;
              dropDownNewValue.DisplayMember = "value";
              dropDownNewValue.ValueMember = "key";
              foreach (KeyValuePair<int, string> _Item in _Data.Lookup)
              {
                  int _Index = dropDownNewValue.Items.Add(_Item);
                  if (_Data.ConfiguredValue == _Item.Key)
                  {
                      dropDownNewValue.SelectedIndex = _Index;
                  }
              }
              buttonOK.Enabled = true;
          }
          else
          {
              dropDownNewValue.Visible = false;
              textNewValue.Visible = true;
              textNewValue.Text = _Data.ConfiguredValue.ToString();
          }
         labelConfigurationName.Text = _Data.Name;
         labelChangeInstructions.Text = _Data.RestartRequired ? ProductConstants.LabelChangesRequireRestart : ProductConstants.LabelChangesWillBeImmediate;
         textNewValue.Select();
         base.OnLoad(e);
      }

      private void buttonOK_Click(object sender, EventArgs e)
      {
          if (listUpdateServerList.Visible && SelectedServers.Count == 0)
          {
              Messaging.ShowWarning(ProductConstants.WarningNoSelectedServersToEdit);
              return;
          }

          if (_Data.Type == ConfigurationType.Security)
          {
              _Data.ConfiguredValue = ((KeyValuePair<int, string>)dropDownNewValue.SelectedItem).Key;
          }
          else
          {
              int _EnteredValue = int.Parse(textNewValue.Text);
              if (_EnteredValue > _Data.MaximumValue || _EnteredValue < _Data.MinimumValue)
              {
                  Messaging.ShowWarning(string.Format(ProductConstants.WarningInvalidRange, _Data.MinimumValue, _Data.MaximumValue));
                  return;
              }
              _Data.ConfiguredValue = _EnteredValue;
          }
         
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
         set
         {
            _Data = value;
         }
      }

      /// <summary>
      /// Selected servers.
      /// </summary>
      public List<string> SelectedServers
      {
         get
         {
            List<string> _SelectedServers = new List<string>();
            foreach(object _Item in listUpdateServerList.CheckedItems)
            {
               _SelectedServers.Add(_Item.ToString());
            }
            return _SelectedServers;
         }
      }

      private void textNewValue_TextChanged(object sender, EventArgs e)
      {
         buttonOK.Enabled = (textNewValue.Text.Length > 0);
      }
   }
}