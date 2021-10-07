using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.Core
{
    public partial class Form_MiniBrowser : Form
    {
        public string homePage;
        
        public
           Form_MiniBrowser(
              string startUrl,
              string caption
           ) : this (startUrl )
        {
            this.Text = caption;
        }

        public
           Form_MiniBrowser(
              string startUrl
           )
        {
            InitializeComponent();

            this.textAddress.Text = startUrl;
            homePage             = startUrl;
            
            SetUrl(startUrl);
        }

       private void buttonLaunchBrowser_Click( object sender, EventArgs e )
       {
         try
         {
            Application.DoEvents();

            Cursor = Cursors.WaitCursor;
            Process.Start( textAddress.Text );
         }
         catch { }
         finally
         {
            Cursor = Cursors.Default;
         }
       }

       private void buttonHome_Click( object sender, EventArgs e )
       {
          textAddress.Text = homePage;
          SetUrl(homePage);
      }

       private void buttonGo_Click( object sender, EventArgs e )
       {
          SetUrl( textAddress.Text );
       }

       private void buttonBack_Click( object sender, EventArgs e )
       {
          webBrowser1.GoBack();
       }

       private void buttonForward_Click( object sender, EventArgs e )
       {
          webBrowser1.GoForward();
       }
       
       private void
          SetUrl(
             string url 
          )
       {
          string fullUrl = url;
          if ( ! fullUrl.Contains( @"://" ) )
          {
             fullUrl = @"http://" + fullUrl;
          } 
          
          try
          {
            webBrowser1.Url = new System.Uri(fullUrl);
          }
          catch (Exception ex )
          {
             Messaging.ShowException( "An error occurred trying to display the specified address.", ex, this.Text );
          }
       }

       private void webBrowser1_Navigating( object sender, WebBrowserNavigatingEventArgs e )
       {
          progressBar.Visible      = true;
          progressBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
       }

       private void webBrowser1_Navigated( object sender, WebBrowserNavigatedEventArgs e )
       {
          progressBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Standard;
          progressBar.Value        = 100;
          textAddress.Text     =    webBrowser1.Url.ToString();          
       }

       private void webBrowser1_DocumentCompleted( object sender, WebBrowserDocumentCompletedEventArgs e )
       {
          progressBar.Visible  = false;
       }

       private void buttonClose_Click( object sender, EventArgs e )
       {
          Close();
       }
    }
}