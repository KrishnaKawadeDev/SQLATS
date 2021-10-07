using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Core
{
   public partial class Form_MultipleServerError : Form
   {
      public Form_MultipleServerError()
      {
         InitializeComponent();
         
         this.Text = CoreGlobals.productName + " - " + this.Text;
      }
      
      public void
         AddError( 
            string    serverName,
            string    errorMessage )
      {
            gridErrors.Rows.Add( serverName, errorMessage );
      }

      private void buttonClipboard_Click( object sender, EventArgs e )
      {
         StringBuilder sb = new StringBuilder(2048);
         
         sb.AppendFormat( "{0}\r\n\r\n", labelX1.Text );
         sb.AppendFormat( "Server\tError Message\r\n" );
         sb.AppendFormat( "------\t-------------\r\n" );
         foreach( DataGridViewRow row in gridErrors.Rows )
         {
            try
            {
               sb.AppendFormat( "{0}\t{1}\r\n", row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString() );
            }
            catch {}
         }
         
         Clipboard.SetText( sb.ToString() );
      }
   }
}