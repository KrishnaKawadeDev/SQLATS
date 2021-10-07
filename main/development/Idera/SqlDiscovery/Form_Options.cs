using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SqlDiscovery
{
   public partial class Form_Options : Form
   {
      public Form_Options()
      {
         InitializeComponent();
         
         checkEnableIcmpCheck.Checked            = Globals.enableICMPCheck;
         checkDisableSSNetLibVersionCheck.Checked = Globals.disableSSNetlibVersionCheck;
         
         textICMPTimeout.Text     = Globals.ICMPTimeout.ToString();
         textLocalSourcePort.Text = Globals.localSourcePort.ToString();

         if ( Globals.alternateUsername != "" )
         {
            checkUseAlternateCredentials.Checked = true;

            textDomain.Text   = Globals.alternateDomain;
            textUserName.Text = Globals.alternateUsername;
            textPassword.Text = Globals.alternatePassword;
         }
      }

      private void checkUseAlternateCredentials_CheckedChanged( object sender, EventArgs e )
      {
         textUserName.Enabled = (checkUseAlternateCredentials.Checked);
         textPassword.Enabled = (checkUseAlternateCredentials.Checked);
         textDomain.Enabled   = (checkUseAlternateCredentials.Checked);
      }

      private void btnOK_Click( object sender, EventArgs e )
      {
         if ( checkUseAlternateCredentials.Checked )
         {
            if ( textUserName.Text == "" )
            {
               Messaging.ShowError( "A user name is required to use alternate credentials." );
               return;
            }
         }
         
         // if we got here all data is valid, save and return
         Globals.enableICMPCheck            = checkEnableIcmpCheck.Checked;
         Globals.disableSSNetlibVersionCheck = checkDisableSSNetLibVersionCheck.Checked;
         
         Globals.ICMPTimeout     = ( textICMPTimeout.Text == "" )     ? 750 : System.Convert.ToInt32(textICMPTimeout.Text);
         Globals.localSourcePort = ( textLocalSourcePort.Text == "" ) ? 0    : System.Convert.ToInt32(textLocalSourcePort.Text);
         
         if ( checkUseAlternateCredentials.Checked )
         {
            Globals.alternateDomain   = textDomain.Text;
            Globals.alternateUsername = textUserName.Text;
            Globals.alternatePassword = textPassword.Text;
         }
         else
         {
            Globals.alternateDomain   = "";
            Globals.alternateUsername = "";
            Globals.alternatePassword = "";
         }
         
         DialogResult = DialogResult.OK;
      }
   }
}