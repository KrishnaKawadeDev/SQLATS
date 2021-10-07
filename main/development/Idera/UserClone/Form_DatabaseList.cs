using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.UserClone
{
   public partial class Form_DatabaseList : Form
   {
      public delegate Dictionary<string,bool> RefreshDatabasesDelegate();

      private RefreshDatabasesDelegate _RefreshDb = null;
      
      public Form_DatabaseList(RefreshDatabasesDelegate refreshDb)
      {
         InitializeComponent();
         _RefreshDb = refreshDb;
      }

      /// <summary>
      /// List of databases.
      /// </summary>
      public Dictionary<string, bool> Databases
      {
         get
         {
            Dictionary<string, bool> _Databases = new Dictionary<string, bool>();
            for (int i = 0; i < listDatabases.Items.Count; i++)
            {
               _Databases.Add(listDatabases.Items[i].ToString(), listDatabases.GetItemChecked(i));
            }
            return _Databases;
         }
         set
         {
            foreach(KeyValuePair<string, bool> _Database in value)
            {
               listDatabases.Items.Add(_Database.Key, _Database.Value);
            }
         }
      }

      private void linkSelectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         for (int i = 0; i < listDatabases.Items.Count; i++)
         {
            listDatabases.SetItemChecked(i, true);
         }
      }

      private void linkDeselect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         for (int i = 0; i < listDatabases.Items.Count; i++)
         {
            listDatabases.SetItemChecked(i, false);
         }
      }

       private void lnkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
       {
           Dictionary<string, bool> _RefreshedDatabaseList = _RefreshDb();
           for (int i = 0; i < listDatabases.Items.Count;)
           {
               if (!_RefreshedDatabaseList.ContainsKey(listDatabases.Items[i].ToString()))
               {
                   listDatabases.Items.RemoveAt(i);
               }
               else
               {
                   i++;
               }
           }
       }

   }
}