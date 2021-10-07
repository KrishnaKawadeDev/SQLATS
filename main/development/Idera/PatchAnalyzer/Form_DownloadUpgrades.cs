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
   public partial class Form_DownloadUpgrades : Form
   {
      public Form_DownloadUpgrades()
      {
         InitializeComponent();
      }

      private void link2008sp1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         ShowDownloadPage("http://www.microsoft.com/downloads/details.aspx?FamilyID=66ab3dbb-bf3e-4f46-9559-ccc6a4f9dc19&displaylang=en");
      }

      private void link2008general_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
          ShowDownloadPage("http://support.microsoft.com/kb/968382");
      }

      private void link2005sp3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         ShowDownloadPage("http://www.microsoft.com/downloads/details.aspx?FamilyID=ae7387c3-348c-4faa-8ae5-949fdfbe59c4&displaylang=en");
      }

      private void link2005sp2_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
      {
         ShowDownloadPage( "http://www.microsoft.com/downloads/details.aspx?familyid=D07219B2-1E23-49C8-8F0C-63FA18F26D3A&displaylang=en" );
      }

      private void link2005sp1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
      {
         ShowDownloadPage( "http://www.microsoft.com/downloads/details.aspx?FamilyID=cb6c71ea-d649-47ff-9176-e7cac58fd4bc&displaylang=en" );
      }

      private void link2005general_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
      {
         ShowDownloadPage( "http://support.microsoft.com/kb/913089/" );
      }

      private void link2000sp4_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
      {
         ShowDownloadPage( "http://www.microsoft.com/downloads/details.aspx?FamilyID=8E2DFC8D-C20E-4446-99A9-B7F0213F8BC5&displaylang=en" );
      }

      private void link2000sp3a_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
      {
         ShowDownloadPage( "http://www.microsoft.com/downloads/details.aspx?familyid=90DCD52C-0488-4E46-AFBF-ACACE5369FA3&displaylang=en" );
      }

      private void link200General_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
      {
         ShowDownloadPage( "http://support.microsoft.com/kb/290211" );
      }
      
      private void ShowDownloadPage( string url )
      {
         Form_MiniBrowser frm = new Form_MiniBrowser( url );
         frm.ShowDialog();
      }

      private void linkSupportPolicy_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
      {
         ShowDownloadPage( "http://support.microsoft.com/gp/lifesupsps" );
      }

       private void link2008sp2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
       {
           ShowDownloadPage("http://www.microsoft.com/en-us/download/details.aspx?id=12548");
       }

       private void link2008sp3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
       {
           ShowDownloadPage("http://www.microsoft.com/en-us/download/details.aspx?id=27594");
       }

       private void link2008R2general_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
       {
           ShowDownloadPage("http://support.microsoft.com/kb/2527041");
       }

       private void link2008R2sp1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
       {
           ShowDownloadPage("http://www.microsoft.com/en-us/download/details.aspx?id=26727");           
       }

       private void link2012general_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
       {
           ShowDownloadPage("http://support2.microsoft.com/kb/2755533");
       }

       private void link2014general_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
       {
           ShowDownloadPage("http://support2.microsoft.com/kb/2958069");
       }

       private void link2005sp4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
       {
           ShowDownloadPage("http://www.microsoft.com/en-us/download/details.aspx?id=7218");
       }
        private void link2016general_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowDownloadPage("http://support.microsoft.com/en-us/kb/3177534");
        }
        private void link2017general_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowDownloadPage("https://support.microsoft.com/en-in/help/4038634/cumulative-update-1-for-sql-server-2017");
        }
    }
}