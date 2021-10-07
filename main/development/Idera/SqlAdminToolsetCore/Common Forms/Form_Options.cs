using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Core
{
   public partial class Form_Options : Form
   {
      public Form_Options()
      {
         InitializeComponent();
      }

      protected override void OnLoad( EventArgs e )
      {
         base.OnLoad( e );
         
         ToolsetOptions.ReadOptions();

         // Load Options
         textConnectionTimeout.Text  = ToolsetOptions.connectionTimeout.ToString();
         textCommandTimeout.Text     = ToolsetOptions.commandTimeout.ToString();
         checkCloseLaunchpad.Checked = ToolsetOptions.closeLaunchpad;
      }

      private void btnOK_Click( object sender, EventArgs e )
      {
         // Validation
         int connTimeout = textConnectionTimeout.NumericValue;
         int cmdTimeout  = textCommandTimeout.NumericValue;

         if ( connTimeout < 0 || connTimeout > 32767 )
         {
            Messaging.ShowError( "The connection timeout must be between 0 and 32767 seconds" );
            return;
         }

         if ( cmdTimeout < 0 || cmdTimeout > 32767 )
         {
            Messaging.ShowError( "The command timeout must be between 0 and 32767 seconds" );
            return;
         }

         // Save Options
         ToolsetOptions.connectionTimeout  = connTimeout;
         ToolsetOptions.commandTimeout     = cmdTimeout;
         ToolsetOptions.closeLaunchpad     = checkCloseLaunchpad.Checked;
         ToolsetOptions.firstTimeLaunchpad = false;
         ToolsetOptions.WriteOptions();

         // Close
         DialogResult = DialogResult.OK;
         Close();
      }

      private void Form_Options_HelpRequested( object sender, HelpEventArgs hlpevent )
      {
         HelpMenu.ShowHelp( DisplayHelp.OPTIONS );
      }
   }
}