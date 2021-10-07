using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Core
{
   public partial class Form_RenameServerGroup : Form
   {
      private bool m_isGroup = true;
      
      public string NewName
      {
         get { return textNewName.Text.Trim(); }
      }
      
      public Form_RenameServerGroup( bool isGroup, string groupName)
      {
         InitializeComponent();
         
         m_isGroup = isGroup;
         if ( ! isGroup )
         {
            this.Text = "Rename Server";
            groupPanel1.Text = "Specify New Server Name";
         }
         
         textOldName.Text = groupName;
         textNewName.Text = groupName;
         
         textNewName.Select();
         
         
      }

      private void buttonOK_Click( object sender, EventArgs e )
      {
         // dirty?
         if ( textOldName.Text.Trim() == textNewName.Text.Trim() )
         {
            DialogResult = DialogResult.Cancel;
         }
         else
         {
            if ( m_isGroup )
            {
               // validate name
               if ( ! ToolServerGroup.IsGroupNameValid( textNewName.Text ) )
               {
                  Messaging.ShowError( ToolServerGroup.InvalidGroupNameString );
                  DialogResult = DialogResult.None;
               }
               else
               {
                  DialogResult = DialogResult.OK;
               }
            }
            else
            {
               DialogResult = DialogResult.OK;
            }
         }
      }
      
      private void textNewName_TextChanged( object sender, EventArgs e )
      {
         btnOK.Enabled = (textNewName.Text.Trim().Length !=0);
      }
   }
}