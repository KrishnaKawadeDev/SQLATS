using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace Idera.SqlAdminToolset.PasswordChecker
{
   internal partial class Form_RoleSelection : Form
   {
      public Form_RoleSelection(RoleMode mode, TextBoxX sender)
      {
         
         InitializeComponent();
         if (mode == RoleMode.Database)
         {
            this.Text = "Database Roles";
            listRoles.Items.Add("db_owner");
            listRoles.Items.Add("db_accessadmin");
            listRoles.Items.Add("db_datareader");
            listRoles.Items.Add("db_datawriter");
            listRoles.Items.Add("db_ddladmin");
            listRoles.Items.Add("db_securityadmin");
            listRoles.Items.Add("db_backupoperator");
            listRoles.Items.Add("db_denydatareader");
            listRoles.Items.Add("db_denydatawriter");
            listRoles.Items.Add("db_ddladmin");
            listRoles.Items.Add("dbm_monitor");
         }
         else
         {
            this.Text = "Server Roles";
            listRoles.Items.Add("bulkadmin");
            listRoles.Items.Add("sysadmin");
            listRoles.Items.Add("serveradmin");
            listRoles.Items.Add("setupadmin");
            listRoles.Items.Add("securityadmin");
            listRoles.Items.Add("processadmin");
            listRoles.Items.Add("dbcreator");
            listRoles.Items.Add("diskadmin");
         }
         
         SelectAll( true);

         //listRoles.Size = new Size(listRoles.Size.Width, 10 + (15 * listRoles.Items.Count));
         //buttonOk.Location = new Point(buttonOk.Location.X, listRoles.Location.Y + listRoles.Size.Height + 5);
         //buttonCancel.Location = new Point(buttonCancel.Location.X, listRoles.Location.Y + listRoles.Size.Height + 5);
         //this.Size = new Size(this.Size.Width, 95 + (15 * listRoles.Items.Count));
         //this.MinimumSize = this.MaximumSize = this.Size;
      }

      /// <summary>
      /// Array with selected roles.
      /// </summary>
      public string[] Roles
      {
         get
         {
            string[] _Roles;
            
            if ( listRoles.CheckedItems.Count == listRoles.Items.Count )
            {
               _Roles = new string[0];
            }
            else
            {
               _Roles = new string[listRoles.CheckedItems.Count];
               listRoles.CheckedItems.CopyTo(_Roles, 0);
            }
            return _Roles;
         }
         set
         {
            if ( value.Length == 0 )
            {
               SelectAll( true);
            }
            else
            {
               foreach (string _Role in value)
               {
                  if (listRoles.Items.Contains(_Role))
                  {
                     listRoles.SetItemChecked(listRoles.Items.IndexOf(_Role), true);
                  }
               }
            }
         }
      }

      /// <summary>
      /// Display mode for the list that should be displayed to the user.
      /// </summary>
      internal enum RoleMode
      {
         Server,
         Database
      }
      
      internal static string [] GetAllRoles( RoleMode roleMode )
      {
         string[] _Roles;
         
         if ( roleMode == RoleMode.Server )
         {
            _Roles = new string[8];
            
            _Roles[0] = "bulkadmin";
            _Roles[1] = "sysadmin";
            _Roles[2] = "serveradmin";
            _Roles[3] = "setupadmin";
            _Roles[4] = "securityadmin";
            _Roles[5] = "processadmin";
            _Roles[6] = "dbcreator";
            _Roles[7] = "diskadmin";
         }
         else
         {
            _Roles = new string[11];
            
            _Roles[0]  = "db_owner";
            _Roles[1]  = "db_accessadmin";
            _Roles[2]  = "db_datareader";
            _Roles[3]  = "db_datawriter";
            _Roles[4]  = "db_ddladmin";
            _Roles[5]  = "db_securityadmin";
            _Roles[6]  = "db_backupoperator";
            _Roles[7]  = "db_denydatareader";
            _Roles[8]  = "db_denydatawriter";
            _Roles[9]  = "db_ddladmin";
            _Roles[10] = "dbm_monitor";
        }
        
        return _Roles;
      }
      
      private void SelectAll ( bool selected )
      {
         for ( int i=0; i<listRoles.Items.Count; i++ )
         {
            listRoles.SetItemChecked(i,selected);
         }
     }

      private void buttonSelectAll_Click( object sender, EventArgs e )
      {
         SelectAll( true);
      }

      private void buttonClearAll_Click( object sender, EventArgs e )
      {
         SelectAll( false);
      }      
   }
}