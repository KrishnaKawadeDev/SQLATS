using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.PatchAnalyzer
{
   public partial class Form_DownloadError : Form
   {
      private string _message;
      public string Message
      {
         set
         {
            _message = value;
            this.labelErrorMessage.Text = "Error: " + _message;
         }
         
         get { return _message;  }
      }
      
      #region CTORs

      public Form_DownloadError( string message)
      {
         InitializeComponent();

         Message = message;
      }
      
      #endregion

      private void linkManualDownload_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
      {
         HelpMenu.LaunchUrlInBrowser( this, ProductConstants.ManualDownloadURL );
      }
   }
}