using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.PatchEditor
{
   public partial class Form_BuildProperties : Form
   {
      public SQLServerVersion sqlServerVersion;
      public SQLServerVersion oldSqlServerVersion = null;
      
      public Form_BuildProperties()
      {
         InitializeComponent();
         
         this.Text = "Add New Build";
      }
      
      public Form_BuildProperties( SQLServerVersion inSqlServerVersion )
      {
         InitializeComponent();
         
         oldSqlServerVersion = inSqlServerVersion;
         
         textBuild.Text = inSqlServerVersion.Version;
         textLevel.Text = inSqlServerVersion.Level;
         textSupported.Text = inSqlServerVersion.Supported;
         textStatus.Text = inSqlServerVersion.SupportStatus;
         textUrlType.Text = inSqlServerVersion.UrlType;
         textUrl.Text = inSqlServerVersion.Url;
         textTitle.Text = inSqlServerVersion.KbTitle;
         textVersionName.Text = inSqlServerVersion.Product;
         this.Text = "Edit Build Properties (Build " + textBuild.Text + ")";
      }

      protected override void OnLoad( EventArgs e )
      {
         base.OnLoad( e );
         
         textBuild.Focus();
      }

      private void buttonOK_Click( object sender, EventArgs e )
      {
         if ( textBuild.Text.Trim().Length == 0 || 
              textLevel.Text.Trim().Length == 0 || 
              textSupported.Text.Trim().Length == 0 || 
              textStatus.Text.Trim().Length == 0 || 
              textUrlType.Text.Trim().Length == 0 || 
              textTitle.Text.Trim().Length == 0  ||
              textVersionName.Text.Trim().Length==0)
         {
            Messaging.ShowError( "Fill out all the required fields (everything but URL)" );
            DialogResult = DialogResult.None;
            return;
         }                                                  

         // cant handle double quotes in strings - convert to single quotes
         textTitle.Text = textTitle.Text.Replace('"', '\'');
    
         sqlServerVersion = new SQLServerVersion( textBuild.Text, 
                                                  textLevel.Text,
                                                  textSupported.Text,
                                                  textStatus.Text,
                                                  textUrlType.Text,
                                                  textUrl.Text,
                                                  textTitle.Text,
                                                  textVersionName.Text);
                                                  
         if ( oldSqlServerVersion != null && sqlServerVersion.SameAs(oldSqlServerVersion) )
            DialogResult = DialogResult.Cancel;
         else                                                  
            DialogResult = DialogResult.OK;
      }

      private void buttonViewKBArticle_Click( object sender, EventArgs e )
      {
         Form_Main.ViewKnowledgeBaseArticle( textUrl.Text );
      }

      private void textUrl_TextChanged( object sender, EventArgs e )
      {
           buttonViewKBArticle.Enabled = (textUrl.Text.Trim().Length != 0 );
      }
   }
}