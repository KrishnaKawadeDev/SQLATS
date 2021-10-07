using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.LinkedServerMover
{
   public partial class ToolLinkedServerLogin : UserControl
   {
      public ToolLinkedServerLogin()
      {
         InitializeComponent();
      }

      public string Username
      {
         get { return labelUsername.Text; }
         set { labelUsername.Text = value; }
      }

      [Browsable(false)]
      public bool DisablePassword
      {
         get { return textBoxPassword.Enabled; }
         set { textBoxPassword.Enabled = value; }
      }

      [Browsable(false)]
      public string Password
      {
         get { return textBoxPassword.Text; }
         set { textBoxPassword.Text = value; }
      }

      public bool PasswordFocus()
      {
         return textBoxPassword.Focus();
      }
   }
}
