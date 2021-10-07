using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.PasswordChecker
{
   public partial class Form_PasswordList : Form
   {
      public Form_PasswordList( string listName, List<string> passwords )
      {
         InitializeComponent();
         
         textPasswordList.Text = listName;
         labelPasswordCount.Text = passwords.Count.ToString() + " Passwords";
         
         foreach (string p in passwords)
         {
            if ( String.IsNullOrEmpty(p) )
            {
               listPasswords.Items.Add( "<Blank Password>" );
            }
            else
            {
               listPasswords.Items.Add( p );
            }
         }
      }
   }
}