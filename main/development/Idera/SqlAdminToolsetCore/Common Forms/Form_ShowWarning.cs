using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Core
{
   public partial class Form_ShowWarning : Form
   {
      public string Title
      {
         set { this.Text = value; }
         get { return this.Text;  }
      }

      public string Message
      {
         set { this.labelMessage.Text = value; }
         get { return this.labelMessage.Text;  }
      }
      
      private MessageBoxButtons _buttons = MessageBoxButtons.YesNoCancel;
      public MessageBoxButtons Buttons
      {
         set
         {
            _buttons = value;
            if ( value == MessageBoxButtons.OK )
            {
               buttonX1.Visible      = false;
               
               buttonX2.Visible      = false;
               
               buttonX3.Visible      = true;
               buttonX3.Text         = "OK";
               buttonX3.DialogResult = DialogResult.OK; 
            }
            else if ( value == MessageBoxButtons.YesNo )
            {
               buttonX1.Visible      = false;
               
               buttonX2.Visible      = true;
               buttonX2.Text         = "Yes";
               buttonX2.DialogResult = DialogResult.Yes; 
               
               buttonX3.Visible      = true;
               buttonX3.Text         = "No";
               buttonX3.DialogResult = DialogResult.No; 
            }
            else // value == MessageBoxButtons.YesNoCancel
            {
               _buttons = MessageBoxButtons.YesNoCancel;
               
               buttonX1.Visible      = true;
               buttonX1.Text         = "Yes";
               buttonX1.DialogResult = DialogResult.Yes; 
               
               buttonX2.Visible      = true;
               buttonX2.Text         = "No";
               buttonX2.DialogResult = DialogResult.No; 
               
               buttonX3.Visible      = true;
               buttonX3.Text         = "Cancel";
               buttonX3.DialogResult = DialogResult.Cancel; 
            }
         }
         get { return _buttons;  }
      }
         
      public bool DontShowWarningAgain
      {
         set { checkBoxDontShowWarning.Checked = value; } 
         get { return checkBoxDontShowWarning.Checked; }
      }
      
      #region CTORs

      public Form_ShowWarning( string message, string title, MessageBoxButtons buttons )
      {
         InitializeComponent();
         
         Title   = title;
         Message = message;
         Buttons = buttons;
      }
      

      public Form_ShowWarning( string message, string title )
      {
         InitializeComponent();
         
         Title   = title;
         Message = message;
      }
      
      public Form_ShowWarning( string message)
      {
         InitializeComponent();

         Message = message;
      }
      
      #endregion
   }
}