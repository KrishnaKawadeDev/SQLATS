using System ;
using System.Data ;
using System.Data.Sql ;
using System.Net ;
using System.Windows.Forms ;
using System.Collections;
using System.Collections.Generic;

namespace Idera.SqlAdminToolset.Core
{
	/// <summary>
	/// Summary description for Form_SQLServerBrowse.
	/// </summary>
	public partial class Form_SQLServerBrowse : Form
	{
	   #region Properties
	   
	  public string SelectedServer
	  {
	    get
       {
          if ( listBoxServers.SelectedItems.Count == 0 )
             return "";
          else
          {
             string selectedServer = null;

             foreach ( object selectedItem in listBoxServers.SelectedItems )
             {
                if ( string.IsNullOrEmpty( selectedServer ) )
                {
                   selectedServer = selectedItem.ToString();
                }
                else
                {
                   selectedServer += ";" + selectedItem.ToString();
                }
             }
             return selectedServer;
          }
       }
	  }

      public int SelectedServerCount
      {
         get
         {
            return listBoxServers.SelectedItems.Count;
         }
      }

     public string[] SelectedServerList
     {
        get
        {
            string[] serverList = null;
            if ( listBoxServers.SelectedItems.Count != 0 )
            {
               serverList = new string[listBoxServers.SelectedItems.Count];
               for ( int i = 0; i < listBoxServers.SelectedItems.Count; i++ )
               {
                  serverList[i] = listBoxServers.SelectedItems[i].ToString();
               }
            }
            return serverList;
        }
     }

      public bool MultiSelect
      {
          get { return (listBoxServers.SelectionMode == SelectionMode.MultiExtended); }
          set { listBoxServers.SelectionMode = value ? SelectionMode.MultiExtended : SelectionMode.One; }
      }
        
		
      private bool m_loaded = false;

		#endregion

      #region Constructor / Dispose

      //-----------------------------------------------------------------------
      // Constructor
      //-----------------------------------------------------------------------
		public Form_SQLServerBrowse()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
		}

        protected override void  OnLoad(EventArgs e)
        {
 	       base.OnLoad(e);

            if ( ! m_loaded )
            {
               Cursor = Cursors.WaitCursor;
               LoadServers();

               if ( listBoxServers.Items.Count != 0)
               {
                  listBoxServers.Select();
                  labelNoServers.Visible = false;
               }
               else
               {
                  labelNoServers.Visible = false;
               }

               Cursor = Cursors.Default;
           }
        }

		#endregion


      #region Load list logic

      //-----------------------------------------------------------------------
      // LoadServers
      //-----------------------------------------------------------------------
      public bool
		   LoadServers()
		{
		   m_loaded = false;
		   
			try 
			{
                SqlDataSourceEnumerator enumerator = SqlDataSourceEnumerator.Instance;
                using (DataTable tbl = enumerator.GetDataSources())
                {
                   foreach (DataRow row in tbl.Rows)
                   {
                      string server = row["ServerName"].ToString();
                      string instance = row["InstanceName"].ToString();

                      string fullName;

                      if (instance == null || instance.Length == 0)
                         fullName = server;
                      else
                         fullName = String.Format("{0}\\{1}", server, instance);

                     listBoxServers.Items.Add(fullName.ToUpper());
                   }
                }
                
                // add to this list any servers defined within our server groups
                List<ToolServer> groupServers = CoreGlobals.ServerGroupList.GetServers(true);
                foreach ( ToolServer s in groupServers )
                {
                  if ( ! listBoxServers.Items.Contains(s.Name.ToUpper()) )
                   {
                       listBoxServers.Items.Add(s.Name.ToUpper());
                   }
                }
                
                // add to this list any registered with 2000 and 2005 
                List<string> smoServers = ToolServerGroup.GetSmoRegisteredServers();
                foreach ( string s in smoServers )
                {
                   if ( ! listBoxServers.Items.Contains(s.ToUpper()) )
                   {
                      listBoxServers.Items.Add(s.ToUpper());
                   }
                }

                List<string> dmoServers = ToolServerGroup.GetDmoRegisteredServers();
                foreach ( string s in dmoServers )
                {
                   if ( ! listBoxServers.Items.Contains(s.ToUpper()) )
                   {
                      listBoxServers.Items.Add(s.ToUpper());
                   }
                }
                
                if ( listBoxServers.Items.Count == 0 )
                {
                   Messaging.ShowInformation( "No SQL Servers available from the SQL Server Browser service." );
                }
                else
                {
		             m_loaded = true;
		          }
	   	    }
   		    catch (Exception  ex) 
			{
			   MessageBox.Show( String.Format( "An error ocurred retrieving the available SQL Servers.\r\n\r\nError: {0}",
                                                ex.Message),
                                "Error enumerating SQL Servers",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error );
			}
			return m_loaded;
		}
		
		#endregion
		
		#region Form Events

      //-----------------------------------------------------------------------
      // btnCancel_Click
      //-----------------------------------------------------------------------
      private void btnCancel_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      //-----------------------------------------------------------------------
      // btnOK_Click
      //-----------------------------------------------------------------------
      private void btnOK_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      //-----------------------------------------------------------------------
      // listBoxServers_SelectedIndexChanged
      //-----------------------------------------------------------------------
      private void listBoxServers_SelectedIndexChanged( object sender, EventArgs e )
      {
         if (listBoxServers.SelectedItems.Count >= 1 )
            btnOK.Enabled = true;
         else
            btnOK.Enabled = false;
      }

      #endregion

      private void listBoxServers_DoubleClick( object sender, EventArgs e )
      {
         if ( btnOK.Enabled )
         {
            DialogResult = DialogResult.OK;
            Close();
         }
      }
   }
}
