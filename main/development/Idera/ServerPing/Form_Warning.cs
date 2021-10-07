using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.ServerPing
{
   public partial class Form_Warning : Form
   {
      public Form_Warning()
      {
         InitializeComponent();
         
         btnOK.Select();
      }
      
      public string Message
      {
         set { labelMessage.Text = value; }
      }
      
      public string Title
      {
         set { this.Text = value; }
      }
      
      public bool DoNotShowAgain
      {
         get { return checkDoNotShowAgain.Checked; }
      }

   }
}