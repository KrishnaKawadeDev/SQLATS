using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.Core
{
   public partial class Form_OldLicenseWarning : Form
   {
       private string licenseKey = "";

       public string LicenseKey
       {
           get { return licenseKey; }
           set { licenseKey = value; }
       }

      public Form_OldLicenseWarning()
      {
         InitializeComponent();
      }

      private void btnOK_Click( object sender, EventArgs e )
      {
         DialogResult = DialogResult.OK;
      }

      private void OnLoad(object sender, EventArgs e)
      {
         base.OnLoad(e);

         // try to bring this screen to front so it is on top when it launches
         this.BringToFront();
      }

      private void linkGetLicense_Click(object sender, LinkLabelLinkClickedEventArgs e)
      {
          StringBuilder builder = new StringBuilder();

          builder.AppendFormat("www.idera.com/Action/RenewLicense.aspx?ProdID=9&LK={0}", licenseKey);
         Form_MiniBrowser licenseForm = new Form_MiniBrowser(builder.ToString(), "Obtain a new SQL admin toolset license");
         licenseForm.Show();
      }
   }
}