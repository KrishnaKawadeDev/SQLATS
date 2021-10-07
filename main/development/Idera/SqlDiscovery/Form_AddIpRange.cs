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
   public partial class Form_AddIpRange : Form
   {
      public string StartingIp = "";
      public string EndingIp   = "";
      
      public Form_AddIpRange()
      {
         InitializeComponent();
      }

      private void btnOK_Click( object sender, EventArgs e )
      {
         
         DialogResult = DialogResult.None;
         
         // validate
         if ( ! Utility.ValidateIPAddress( textStartIp.Text ) )
         {
            Messaging.ShowError( "Specify a valid IP Address for the starting IP address." );
            return;
         }
         StartingIp = textStartIp.Text.Trim();
         
         if ( textEndIp.Text.Trim().Length > 0 )
         {
            if ( ! Utility.ValidateIPAddress( textEndIp.Text ) )
            {
               Messaging.ShowError( "Specify a valid IP Address for the ending IP address." );
               return;
            }

            if ( ! Utility.ValidateSameSubnet( textStartIp.Text, textEndIp.Text ) )
            {
               Messaging.ShowError( "The starting and ending IP address must be in the same subnet. To scan multiple subnets, enter each subnet separately." );
            }
            
            EndingIp   = textEndIp.Text.Trim();
            if ( Utility.IPToLong(StartingIp) > Utility.IPToLong(EndingIp) )
            {
               string tmp = StartingIp;
               StartingIp = EndingIp;
               EndingIp = tmp;
    	      }
    	   }
    	   else
    	   {
            EndingIp   = "";
    	   }
         
         DialogResult = DialogResult.OK;
      }
      

      private void buttonSearchSubnet_Click( object sender, EventArgs e )
      {
			textStartIp.Text = textStartIp.Text.Substring(0,textStartIp.Text.LastIndexOf(".")+1)+"1";
			textEndIp.Text   = textStartIp.Text.Substring(0,textStartIp.Text.LastIndexOf(".")+1)+"254";
      }

      private void textIp_TextChanged( object sender, EventArgs e )
      {
         btnOK.Enabled = (textStartIp.Text.Trim().Length != 0);
      }

      private void btnCancel_Click( object sender, EventArgs e )
      {
         StartingIp = "";
         EndingIp   = "";
      }

      private void buttonGetLocalIP_Click( object sender, EventArgs e )
      {
         try
         {
            string localIP  = Helpers.GetIP4AddressString();
            if ( localIP.Length > 0 )
            {
			      textStartIp.Text = localIP;
			      textEndIp.Text   = "";
            }
         }
         catch {}

      }

      private void buttonGetLocalSubnet_Click( object sender, EventArgs e )
      {
         try
         {
            string localIP  = Helpers.GetIP4AddressString();
            if ( localIP.Length > 0 )
            {
	      		textStartIp.Text = localIP.Substring(0,localIP.LastIndexOf(".")+1)+"1";
			      textEndIp.Text   = localIP.Substring(0,localIP.LastIndexOf(".")+1)+"254";
            }
         }
         catch {}
      }
   }
}
