using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core;
using Idera.SqlAdminToolset.Core.Export;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Xml;
using System.Diagnostics;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.PatchEditor
{
    public partial class Form_Main : Form
    {
        #region Constructor

        public Form_Main()
        {
            InitializeComponent();
            this.Text = ideraTitleBar1.IderaProductNameText;
        }
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x00C00000; // remove WS_CAPTION
                parms.Style |= 0x00040000;  // include WS_SIZEBOX
                return parms;
            }
        }
        #endregion

        #region OnLoad (Common)

        protected override void OnLoad(EventArgs e)
        {
            #region Common Onload code

            base.OnLoad(e);
           // if (!Startup.GuiStartup(this, menuTools, menuAbout))
           // {
           //     Close();
           //     return;
           // }

            #endregion
            
            listViewSQL.Items.Clear();

            // Program Specific Logic
            textFileName.Text = "SQLServerVersionList.xml";
            if ( ! File.Exists( textFileName.Text ) )
            {
               textFileName.Text = @"..\..\SQLServerVersionList.xml";
            }
            if ( File.Exists( textFileName.Text ) )
            {
               LoadPatchFiles();
            }
        }

        private void LoadPatchFiles()
        {
             buttonAddNewBuild.Enabled = 
             contextMenuAddBuild.Enabled =
             buttonSaveAs.Enabled = 
             contextMenuRemoveBuild.Enabled = 
             contextMenuViewKBArticle.Enabled = 
             contextMenuEditBuild.Enabled =
             buttonEditBuildProperties.Enabled = 
             buttonShowKbArticle.Enabled = 
             buttonRemoveBuild.Enabled = false;

             textDirty.Text = ""; 
             
            //----------------
            // SQL Patch File
            //----------------
            try
            {
                ProductConstants.SQLServerVersionFullPath = textFileName.Text;
                DateTime patchFileDate = SQLServerVersion.LoadSqlPatchFile(ProductConstants.SQLServerVersionFullPath);
                textDirty.Text = "No"; 
                buttonSaveBuildList.Enabled = false;
                
                textFileName.Text = ProductConstants.SQLServerVersionFullPath;
              
               if ( SQLServerVersion.SqlServerVersionDate == DateTime.MinValue )
               {
                  textBuildListDate.Text = "<Unknown>";
               }
               else
               {
                   textBuildListDate.Text = SQLServerVersion.SqlServerVersionDate.ToShortDateString();
               }
                listViewSQL.ListViewItemSorter = new ListViewItemComparer(0, System.Windows.Forms.SortOrder.Descending);
                // fill list box
                listViewSQL.Items.Clear();
            
               foreach ( SQLServerVersion sqlServerVersion in SQLServerVersion.SqlServerVersionList )
               {
                  AddListViewItem( sqlServerVersion );
               }
               
               listViewSQL.ListViewItemSorter = new ListViewItemComparer( 0, System.Windows.Forms.SortOrder.Descending );
               listViewSQL.Sort();
               
               FindMaxVersions();
               
               buttonSaveAs.Enabled = 
               buttonAddNewBuild.Enabled = 
               contextMenuAddBuild.Enabled = true;
            }
            catch (Exception ex)
            {
               Messaging.ShowException( "Error loading patch file: " + textFileName.Text, ex );
            }
        }
        
        private void FindMaxVersions()
        {
           foreach ( SQLServerVersion ssv in SQLServerVersion.SqlServerVersionList )
           {
              if      ( ssv.Major ==  7 ) textMax70.Text   = ssv.Version.ToString();
              else if ( ssv.Major ==  8 ) textMax2000.Text = ssv.Version.ToString();
              else if ( ssv.Major ==  9 ) textMax2005.Text = ssv.Version.ToString();
              else if ( ssv.Major == 10 ) textMax2008.Text = ssv.Version.ToString();
           }
        }

        #endregion

        #region Common Code

        #region File Menu Event Handlers (Common)

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuExitToLaunchpad_Click(object sender, EventArgs e)
        {
            Launchpad.RunAndClose(this);
        }

        #endregion

        #region Help Menu Event Handlers (Common)

        private void menuShowHelp_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowHelp();
        }

        private void menuDeactivateLicense_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowDeactivateLicense();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowAboutForm();
        }

        private void menuSearchIderaKnowledgeBase_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowURL_SearchIderaKnowledgeBase(this);
        }

        private void menuAboutIderaProducts_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowURL_AboutIderaProducts(this);
        }

        private void menuContactTechnicalSupport_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowURL_ContactTechnicalSupport(this);
        }

        private void menuCheckForUpdates_Click(object sender, EventArgs e)
        {
            HelpMenu.CheckForUpdates(this);
        }

        #endregion

        #region Tools Menu (Common )

        private void menuToolsetOptions_Click(object sender, EventArgs e)
        {
            ToolsMenu.ShowToolsetOptions();
        }

        private void menuLaunchpad_Click(object sender, EventArgs e)
        {
            ToolsMenu.RunLaunchpad(this);
        }

        private void menuManageServerGroups_Click(object sender, EventArgs e)
        {
            ToolsMenu.ManageServerGroups();
        }

        #endregion

        #endregion

        #region Program Logic

        private void buttonGetResults_Click(object sender, EventArgs e)
        {
         LoadPatchFiles();
        }
        
        private ListViewItem AddListViewItem( SQLServerVersion sqlServerVersion )
        {
           ListViewItem lvi = listViewSQL.Items.Add( sqlServerVersion.Version );
           lvi.SubItems.Add( sqlServerVersion.Level );
           lvi.SubItems.Add( sqlServerVersion.Supported );
           lvi.SubItems.Add( sqlServerVersion.SupportStatus );
           lvi.SubItems.Add( sqlServerVersion.UrlType);
           lvi.SubItems.Add( sqlServerVersion.Url );
           lvi.SubItems.Add( sqlServerVersion.KbTitle );
           lvi.SubItems.Add(sqlServerVersion.Product);
           lvi.Tag = sqlServerVersion;
           
           lvi.Group = listViewSQL.Groups[GetGroupIndex( sqlServerVersion )];
           
           return lvi;
        }

        #endregion

        private void menuShowGroups_Click(object sender, EventArgs e)
        {
            ToggleShowGroups();
        }

        private void contextMenuShowGroups_Click(object sender, EventArgs e)
        {
            ToggleShowGroups();
        }

        private void ToggleShowGroups()
        {
            menuShowGroups.Checked = !menuShowGroups.Checked;
            contextMenuShowGroups.Checked = menuShowGroups.Checked;
            listViewSQL.ShowGroups = menuShowGroups.Checked;
        }

        #region View Knowledge Base Article


       private void buttonX2_Click( object sender, EventArgs e )
       {
          ViewKbArticle();
       }

       private void contextMenuViewKBArticle_Click( object sender, EventArgs e )
       {
          ViewKbArticle();
       }

      private void ViewKbArticle( )
      {
         if ( listViewSQL.SelectedItems.Count == 0 ) return;
         string url = listViewSQL.SelectedItems[0].SubItems[5].Text;
         ViewKnowledgeBaseArticle( url );
      }

        static public void ViewKnowledgeBaseArticle(string url)
        {
            if (url == null || url.ToUpper() == "NONE" || url == "")
            {
                Messaging.ShowInformation("No Knowledge Base article exists for this build of SQL Server");
                return;
            }
            else if (url.ToUpper().StartsWith("GOOGLE:"))
            {
                url = String.Format(@"http://www.google.com/search?q=+{0}+site%3Asupport.microsoft.com&lr=lang_en",
                                     url.Substring(7));
            }
            else if (url.ToUpper().StartsWith("SEARCH:"))
            {
                url = String.Format(@"http://support.microsoft.com/search/default.aspx?mode=a&query={0}",
                                     url.Substring(7));
            }

            Form_MiniBrowser frm = new Form_MiniBrowser(url);
            frm.ShowDialog();
        }

        #endregion

        

      #region Column Sorting

      private int                            sortColumn = -1;
      private System.Windows.Forms.SortOrder sortOrder  = System.Windows.Forms.SortOrder.Ascending;

      private void ResetSort()
      {
         sortColumn = -1;
         listViewSQL.Sorting = sortOrder;
      }

      private void listSQL_ColumnClick( object sender, ColumnClickEventArgs e )
      {
         // Determine whether the column is the same as the last column clicked.
         if ( e.Column != sortColumn )
         {
            // Set the sort column to the new column.
            sortColumn = e.Column;

            // Set the sort order to ascending by default.
            listViewSQL.Sorting = sortOrder;
         }
         else
         {
            // Determine what the last sort order was and change it.
            if ( listViewSQL.Sorting == System.Windows.Forms.SortOrder.Ascending )
               listViewSQL.Sorting = System.Windows.Forms.SortOrder.Descending;
            else
               listViewSQL.Sorting = System.Windows.Forms.SortOrder.Ascending;
         }

         listViewSQL.ListViewItemSorter = new ListViewItemComparer( e.Column, listViewSQL.Sorting );
         listViewSQL.Sort();
      }

      // Implements the manual sorting of items by column.
      class ListViewItemComparer : IComparer
      {
          private int col;
          private System.Windows.Forms.SortOrder order;

          public ListViewItemComparer()
          {
              col=0;
              order = System.Windows.Forms.SortOrder.Descending;
          }

         public ListViewItemComparer( int column, System.Windows.Forms.SortOrder order ) 
          {
              col           = column;
              this.order    = order;
          }

          public int Compare(object x, object y) 
          {
            int returnVal = -1;
            ListViewItem lv1= (ListViewItem)x;
            ListViewItem lv2= (ListViewItem)y;
            
            
            if ( col == 0 /* build */ )
            {
               returnVal = Helpers.CompareVersionString( lv1.SubItems[col].Text,
                                                         lv2.SubItems[col].Text );
            }
            else
            {
               /* the rest of the columns are simple strings */
               returnVal = String.Compare( lv1.SubItems[col].Text,
                                           lv2.SubItems[col].Text );
            }                                        
            
            if ( order == System.Windows.Forms.SortOrder.Descending ) returnVal *= -1;

            return returnVal;
          }
      }
      #endregion

       private void buttonAddNewBuild_Click( object sender, EventArgs e )
       {
          AddNewBuild();
       }
       
       private void contextMenuAddBuild_Click(object sender, EventArgs e)
       {
          AddNewBuild();      
       }
       
       private void AddNewBuild()
       {
          Form_BuildProperties frm = new Form_BuildProperties();
          DialogResult choice = frm.ShowDialog();
          if ( choice == DialogResult.OK )
          {
             ListViewItem lvi = AddListViewItem( frm.sqlServerVersion );
             
            listViewSQL.ListViewItemSorter = new ListViewItemComparer( 0, System.Windows.Forms.SortOrder.Descending );
             listViewSQL.Sort();
             lvi.EnsureVisible();
             lvi.Selected = true;
             Application.DoEvents();
             
              textDirty.Text = "Yes";
              buttonSaveBuildList.Enabled = true;
             
          }
       }
       

       private void listViewSQL_DoubleClick( object sender, EventArgs e )
       {
          EditSelectedBuild();
       }
       
       private void buttonEditBuildProperties_Click( object sender, EventArgs e )
       {
          EditSelectedBuild();
       }
       
       private void contextMenuEditBuild_Click(object sender, EventArgs e)
       {
          EditSelectedBuild();
       }
       
       
       private void EditSelectedBuild()
       {
         if ( listViewSQL.SelectedItems.Count == 0 ) return;
         
          Form_BuildProperties frm = new Form_BuildProperties((SQLServerVersion)listViewSQL.SelectedItems[0].Tag);
          DialogResult choice = frm.ShowDialog();
          if ( choice == DialogResult.OK )
          {
              // update current listview item
              listViewSQL.SelectedItems[0].Tag = frm.sqlServerVersion;

                listViewSQL.SelectedItems[0].SubItems[0].Text = frm.sqlServerVersion.Version;
                listViewSQL.SelectedItems[0].SubItems[1].Text = frm.sqlServerVersion.Level;
                listViewSQL.SelectedItems[0].SubItems[2].Text = frm.sqlServerVersion.Supported;
                listViewSQL.SelectedItems[0].SubItems[3].Text = frm.sqlServerVersion.SupportStatus;
                listViewSQL.SelectedItems[0].SubItems[4].Text = frm.sqlServerVersion.UrlType;
                listViewSQL.SelectedItems[0].SubItems[5].Text = frm.sqlServerVersion.Url;
                listViewSQL.SelectedItems[0].SubItems[6].Text = frm.sqlServerVersion.KbTitle;
                listViewSQL.SelectedItems[0].SubItems[7].Text = frm.sqlServerVersion.Product;
                listViewSQL.SelectedItems[0].Group = listViewSQL.Groups[GetGroupIndex( frm.sqlServerVersion )];
              
              textDirty.Text = "Yes";
              buttonSaveBuildList.Enabled = true;
          }
       }
       
       private int GetGroupIndex( SQLServerVersion ssv )
       {
           int groupIndex = 0;
           switch( ssv.Major )
           {
              case 10: groupIndex = 1; break;
              case 9:  groupIndex = 2; break;
              case 8:  groupIndex = 3; break;
              case 7:  groupIndex = 4; break;
              case 6:  groupIndex = 5; break;
           }
           return groupIndex;
       }


       private void buttonRemoveBuild_Click(object sender, EventArgs e)
       {
          RemoveBuild();
       }

       private void removeBuildToolStripMenuItem_Click(object sender, EventArgs e)
       {
          RemoveBuild();
       }
       
       private void RemoveBuild()
       {
         if ( listViewSQL.SelectedItems.Count == 0 ) return;
         
         // are you sure
         DialogResult choice = Messaging.ShowConfirmation( "Are you sure you want to remove the selected build?" );
         if ( choice == DialogResult.Yes )
         {
            listViewSQL.SelectedItems[0].Remove();
         }
         
         textDirty.Text = "Yes";
         buttonSaveBuildList.Enabled = true;
       }

       private void listViewSQL_SelectedIndexChanged( object sender, EventArgs e )
       {
          contextMenuRemoveBuild.Enabled = 
          contextMenuViewKBArticle.Enabled = 
          contextMenuEditBuild.Enabled =
          buttonEditBuildProperties.Enabled = 
          buttonShowKbArticle.Enabled = 
          buttonRemoveBuild.Enabled = (listViewSQL.SelectedItems.Count != 0 );
       }
       
        private void SaveBuildList( string fileName )
        {
            string dt = DateTime.Now.ToShortDateString();
           
            try
            {
                // make sure list is in proper order for saving
                listViewSQL.ListViewItemSorter = new ListViewItemComparer( 0, System.Windows.Forms.SortOrder.Ascending );
                listViewSQL.Sort();
            
                using (XmlTextWriter textWriter = new XmlTextWriter(fileName, Encoding.UTF8))
                {
                    textWriter.WriteStartDocument();
                    
                    textWriter.WriteStartElement("PatchFile");
                    textWriter.WriteAttributeString("Version", dt);
                    
                    textWriter.WriteWhitespace("\r\n\r\n");
                    
                    textWriter.WriteComment("Build     -  build number" );
                    textWriter.WriteWhitespace("\r\n");
                    textWriter.WriteComment("Level     - SQL Server release level (e.g. RTM or SP1)" );
                    textWriter.WriteWhitespace("\r\n");
                    textWriter.WriteComment("Supported - Still supported by Microsoft" );
                    textWriter.WriteWhitespace("\r\n");
                    textWriter.WriteComment("Status    - Comments about support available" );
                    textWriter.WriteWhitespace("\r\n");
                    textWriter.WriteComment("UrlType   - 0 = Normal, 1=Use this URL for all buids after this" );
                    textWriter.WriteWhitespace("\r\n");
                    textWriter.WriteComment("Url       - Microsoft KB Article on this build" );
                    textWriter.WriteWhitespace("\r\n");
                    textWriter.WriteComment("Title     - Title of KB Article" );
                    textWriter.WriteWhitespace("\r\n\r\n");
                    textWriter.WriteWhitespace("\r\n");
                    textWriter.WriteComment("Version Name     - SQL Server Version Name");
                    textWriter.WriteWhitespace("\r\n\r\n");

                    foreach (ListViewItem lvi in listViewSQL.Items )
                    {
                        textWriter.WriteStartElement("Version");
                        textWriter.WriteAttributeString("Build",     lvi.SubItems[0].Text);
                        textWriter.WriteAttributeString("Level",     lvi.SubItems[1].Text);
                        textWriter.WriteAttributeString("Supported", lvi.SubItems[2].Text);
                        textWriter.WriteAttributeString("Status",    lvi.SubItems[3].Text);
                        textWriter.WriteAttributeString("UrlType",   lvi.SubItems[4].Text);
                        textWriter.WriteAttributeString("Url",       lvi.SubItems[5].Text);
                        textWriter.WriteAttributeString("Title",     lvi.SubItems[6].Text);
                        textWriter.WriteAttributeString("VersionName", lvi.SubItems[7].Text);
                        textWriter.WriteEndElement();
                        textWriter.WriteWhitespace("\r\n");
                    }
                    
                    textWriter.WriteEndElement();

                    textWriter.WriteEndDocument();

                    textWriter.Close();
                    
                    Messaging.ShowInformation("Build file saved!");
                    
                    textBuildListDate.Text = dt;
                    textDirty.Text = "No";
                    buttonSaveBuildList.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Messaging.ShowException("Error writing build list file: " + textFileName.Text, ex);
            }
        }

       private void buttonSaveBuildList_Click( object sender, EventArgs e )
       {
          SaveBuildList( textFileName.Text );
       }

       private void buttonSaveAs_Click( object sender, EventArgs e )
       {
          SaveFileDialog sfd = new SaveFileDialog();
          sfd.Title = "Save Build List";
          sfd.AddExtension = true;
          sfd.CheckPathExists = true;
          sfd.OverwritePrompt = true;
          sfd.DefaultExt = "xml";
          sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
          sfd.FileName = "SQLServerVersionList.xml";
          sfd.Filter = "XML Data(*.xml)|*.xml|All files (*.*)|*.*";

          DialogResult choice = sfd.ShowDialog();
          if ( choice == DialogResult.OK )
          {
             SaveBuildList( sfd.FileName );
          }
       }

       private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
       {
          LaunchUrl( @"http://sqlserverbuilds.blogspot.com/" );
       }
       
       private void LaunchUrl( string url )
       {
         try
         {
            Application.DoEvents();

            Cursor = Cursors.WaitCursor;
            Process.Start( url );
         }
         catch { }
         finally
         {
            Cursor = Cursors.Default;
         }
       }

       private void linkLabel2_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
       {
          LaunchUrl( @"http://www.sqlsecurity.com/FAQs/SQLServerVersionDatabase/tabid/63/Default.aspx" );
       }

       private void linkLabel3_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
       {
           LaunchUrl(@"http://www.idera.com/admin/SQLVSUpload.aspx");
       }

       private void Form_Main_FormClosing( object sender, FormClosingEventArgs e )
       {
          if ( textDirty.Text == "Yes" )
          {
             if ( e.CloseReason == CloseReason.UserClosing )
             {
                DialogResult choice = Messaging.ShowConfirmationWithCancel("You have made changes to the build list. Do you want to save the file before you exit?" );
                if ( choice == DialogResult.Cancel )
                {
                   e.Cancel = true;
                }
                else if ( choice == DialogResult.Yes )
                {
                   SaveBuildList( textFileName.Text );
                }
            }
         }
       }

       private void linkLabel4_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
       {
          LaunchUrl( @"http://support.microsoft.com/kb/956909/" );
       }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LaunchUrl(@"http://support.microsoft.com/search");
        }

        private void manageLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }

        private void ideraTitleBar1_LicenseInfoButtonClick(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }
    }
}