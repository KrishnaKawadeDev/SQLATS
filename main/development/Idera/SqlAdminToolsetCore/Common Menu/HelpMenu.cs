using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace Idera.SqlAdminToolset.Core
{
    public class HelpMenu
    {
        static public void
           ShowHelp()
        {
            string helpTopic = String.Format(@"http://wiki.idera.com/display/SQLAdminToolset\{0}", CoreGlobals.productName);
            //helpTopic += ".htm";
            ShowHelp(helpTopic);
        }

        static public void
           ShowHelp(
               string helptopic
           )
        {
            Application.DoEvents();

            /*IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
            Control control = null; 
            if ( handle != (IntPtr)0 )
            {
               control = Control.FromChildHandle(handle); //new WindowWrapper( handle );
            }*/
            using (Process.Start(helptopic)) { };
            //  DisplayHelp.ShowHelp( /*control,*/ helptopic );
        }

        static public void ShowDeactivateLicense()
        {
            Application.DoEvents();
            LicenseUI.ShowLicenseManagementForm();
        }

        static public void ShowAboutForm()
        {
            Application.DoEvents();

            Form_About dlg = new Form_About(CoreGlobals.productName);
            dlg.ShowDialog();
        }

        static public void CheckForUpdates(Form parent)
        {
            string url = string.Format(CoreGlobals.urlCheckUpdates,
                                        CoreGlobals.productID,
                                        CoreGlobals.productVersion);
            HelpMenu.LaunchUrlInBrowser(parent, url);
        }

        static public void ShowURL_SearchIderaKnowledgeBase(Form parent)
        {
            HelpMenu.LaunchUrlInBrowser(parent, CoreGlobals.urlKnowledgeBase);
        }

        static public void ShowURL_AboutIderaProducts(Form parent)
        {
            HelpMenu.LaunchUrlInBrowser(parent, CoreGlobals.urlAboutProducts);
        }

        static public void ShowURL_ContactTechnicalSupport(Form parent)
        {
            HelpMenu.LaunchUrlInBrowser(parent, CoreGlobals.urlSupport);
        }



        static public void ShowURL_BuyNow(Form parent)
        {
            //HelpMenu.LaunchUrlInBrowser( parent, CoreGlobals.urlBuyNow );

            Application.DoEvents();

            Form_MiniBrowser helpForm = new Form_MiniBrowser(CoreGlobals.urlBuyNow,
                                                              "Purchase the SQL admin toolset");
            helpForm.Show();

        }


        static public void
           LaunchUrlInBrowser(
              Form parent,
              string url
           )
        {
            try
            {
                Application.DoEvents();

                if (parent != null) parent.Cursor = Cursors.WaitCursor;
                Process.Start(url);
            }
            catch { }
            finally
            {
                if (parent != null) parent.Cursor = Cursors.Default;
            }
        }
    }

}
