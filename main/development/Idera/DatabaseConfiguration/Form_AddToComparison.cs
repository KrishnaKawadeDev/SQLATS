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
   public partial class Form_AddToComparison : Form
   {
      private Dictionary<string, List<string>> _SelectedDatabases = new Dictionary<string, List<string>>();
      private int _SelectedDatabaseCount = 0;

      public Form_AddToComparison(Dictionary<string, List<ConfigurationSettings>> configurationList, Dictionary<string, ConfigurationSettings> comparedDatabaseList)
      {
         InitializeComponent();

         foreach (KeyValuePair<string, List<ConfigurationSettings>> _ServerValues in configurationList)
         {
            TreeNode _ServerNode = new TreeNode(_ServerValues.Key);
            _ServerNode.Name = _ServerValues.Key;

            foreach (ConfigurationSettings _DatabaseValues in _ServerValues.Value)
            {
               if (!comparedDatabaseList.ContainsKey(_DatabaseValues.Key) && _DatabaseValues.DataException == null)
               {
                  TreeNode _DatabaseNode = new TreeNode(_DatabaseValues.DatabaseName);
                  _DatabaseNode.Name = _DatabaseValues.Key;
                  _ServerNode.Nodes.Add(_DatabaseNode);
               }
            }
            if (_ServerNode.Nodes.Count > 0)
            {
               treeDatabaseList.Nodes.Add(_ServerNode);
            }
         }

         if (treeDatabaseList.Nodes.Count == 0)
         {
            labelNoAvailableDatabases.Visible = true;
            buttonOK.Enabled = false;
         }
      }

      private void treeDatabaseList_AfterCheck(object sender, TreeViewEventArgs e)
      {
         if (e.Action == TreeViewAction.ByKeyboard || e.Action == TreeViewAction.ByMouse)
         {
            if (e.Node.Level == 0)
            {
               foreach (TreeNode _Node in e.Node.Nodes)
               {
                  _Node.Checked = e.Node.Checked;
               }
            }

            if (e.Node.Level == 1)
            {
               if (!e.Node.Checked && e.Node.Parent.Checked)
               {
                  e.Node.Parent.Checked = false;
               }
            }
         }
      }

      private void buttonOK_Click(object sender, EventArgs e)
      {
         foreach (TreeNode _ServerNode in treeDatabaseList.Nodes)
         {
            foreach (TreeNode _DatabaseNode in _ServerNode.Nodes)
            {
               if (_DatabaseNode.Checked)
               {
                  if (!_SelectedDatabases.ContainsKey(_ServerNode.Name))
                  {
                     _SelectedDatabases.Add(_ServerNode.Name, new List<string>());
                  }
                  _SelectedDatabases[_ServerNode.Name].Add(_DatabaseNode.Name);
                  _SelectedDatabaseCount++;
               }
            }
         }
         if (_SelectedDatabases.Count > 0)
         {
            DialogResult = DialogResult.OK;
         }
         else
         {
            Messaging.ShowError("You must select at least one database");
            return;
         }
      }

      /// <summary>
      /// Dictionary of Servers and Databases selected
      /// </summary>
      public Dictionary<string, List<string>> SelectedDatabases
      {
         get 
         {
            return _SelectedDatabases;
         }
      }

      /// <summary>
      /// Number of individual selected databases.
      /// </summary>
      public int SelectedDatabaseCount
      {
          get
          {
              return _SelectedDatabaseCount;
          }
      }
   }
}