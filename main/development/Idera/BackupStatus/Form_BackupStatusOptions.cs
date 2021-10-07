using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.BackupStatus
{
   public partial class Form_BackupStatusOptions : Form
   {
      public Form_BackupStatusOptions()
      {
         InitializeComponent();
         
         textNumberOfDays.Text = ProductConstants.NumberOfDaysForRecent.ToString();
      }

      private void btnOK_Click( object sender, EventArgs e )
      {
         int days = ProductConstants.NumberOfDaysForRecent;
         try
         {
            days = System.Convert.ToInt32( textNumberOfDays.Text );
         }
         catch {}
         
         if ( days == ProductConstants.NumberOfDaysForRecent )
         {
            DialogResult = DialogResult.Cancel;
         }
         else if ( days < 1 || days > 9999)
         {
            Messaging.ShowError( "Enter a number of days between 1 and 9999." );
            DialogResult = DialogResult.None;
         }
         else
         {
            ProductConstants.NumberOfDaysForRecent = days;
            ProductConstants.WriteOptions();
            DialogResult = DialogResult.OK;
         }
      }

      private void textNumberOfDays_TextChanged( object sender, EventArgs e )
      {
         this.btnOK.Enabled = ( textNumberOfDays.Text.Trim().Length != 0 );
      }
   }
}