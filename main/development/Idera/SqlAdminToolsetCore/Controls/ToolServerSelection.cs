using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Core.Controls
{
   /// <summary>
   /// Selection options that should be presented the the user.
   /// </summary>
   public enum ServerSelectionOptions
   {
      ServersOnly,
      GroupsOnly,
      ServersAndGroups
   }

   /// <summary>
   /// Type of selection made by the user.
   /// </summary>
   public enum ServerSelectionType
   {
      Server,
      Group
   }

   /// <summary>
   /// Allows a user to select a SQL Server or a server group to run a task against.
   /// </summary>
   public partial class ToolServerSelection : UserControl
   {
      #region variables
      private ServerSelectionOptions _SelectionOptions = ServerSelectionOptions.ServersAndGroups;

      private SQLCredentials _SqlCredentials = null;
      private string         _Caption = string.Empty;
      
      private DateTime       _lastMruListDateTime = DateTime.MinValue;
      private string         _SaveGroupText = string.Empty;
      private string         _SaveServerText = string.Empty;
      private List<string>   _customServers = new List<string>();
      private List<string>   _customGroups = new List<string>();
      
      private bool           _loadingForm;
      
      static private string  _stringBrowsePrefix     = "<Browse to select ";
      static private string  _stringBrowseForGroups  = "<Browse to select from all Server Groups>";
      static private string  _stringBrowseForServers = "<Browse to select SQL Servers>";
      static private string  _stringManageGroups     = "<Manage Server Groups>";
      static public string   _stringNoGroupsDefined  = "No Server Groups Defined";
      
      private EventHandler  _ServerGroupsChangedHandler;
      
      
      #endregion

      #region .ctor
      
      //-----------------------------------------------------------------------
      // Constructor
      //-----------------------------------------------------------------------
      public ToolServerSelection()
      {
         InitializeComponent();
         textServer.TextChanged += new EventHandler(textServer_TextChanged);
         
         _ServerGroupsChangedHandler = new EventHandler( ServerGroupsChangedHandler );
         CoreGlobals.ServerGroupList.ServerGroupsChanged += _ServerGroupsChangedHandler;
         
         _loadingForm = true;
         
         LoadDropDownItems();
         if ( ToolsetOptions.mruServerCount == 0  )
         {
            textServer.Text = "(local)";
         }
         else
         {
            textServer.SelectedIndex = 0;
         }
         
         if ( ToolsetOptions.mruGroupCount != 0 )
         {
            _SaveGroupText = ToolsetOptions.mruGroups[0];
         }
         
         _loadingForm = false;
      }

      protected override void OnLoad( EventArgs e )
      {
         base.OnLoad( e );
         
         if ( ToolsetOptions.mruLastSelectionType == 0 )
            radioServers.Checked = true;
         else
            radioGroups.Checked = true;
      }
      
      #endregion

      #region Accessors
      /// <summary>
      /// Selected SQL Server group.
      /// </summary>
      [Browsable(false)]
      public ToolServerGroup SelectedGroup
      {
         get
         {
            if ( radioGroups.Checked )
            {
               return ToolServerGroup.FindServerGroup( textServer.Text );
             }
             else
             {
                return null;
             }
         }
      }
      
      public bool HaveSelection
      {
         get
         {
            bool valid = false;
            
            if ( radioGroups.Checked )
            {
               if ( ! (String.IsNullOrEmpty(textServer.Text)) && 
                    ! (textServer.Text == _stringNoGroupsDefined ))
               {
                  valid = true;
               }     
             }     
             else
             {
                 valid = (! String.IsNullOrEmpty(textServer.Text) );
             }     
            
            return valid;
         }
      }

      /// <summary>
      /// Selected SQL Server credentials.
      /// </summary>
      [Browsable(false)]
      public SQLCredentials SqlCredentials
      {
         get { return _SqlCredentials; }
      }

      /// <summary>
      /// Specifies the selection options that the user receives.
      /// </summary>
      public ServerSelectionOptions SelectionOptions
      {
         get { return _SelectionOptions; }
         set 
         {
            radioGroups.Checked = (value == ServerSelectionOptions.GroupsOnly);
            radioServers.Checked = !radioGroups.Checked;

            if (value == ServerSelectionOptions.ServersAndGroups)
            {
               radioGroups.Visible = radioServers.Visible = true;
               radioServers.Checked = true;
               this.Height = 40;
               this.MinimumSize = new Size(this.MinimumSize.Width, 40);
            }
            else
            {
               radioGroups.Visible = radioServers.Visible = false;
               this.MinimumSize = new Size(this.MinimumSize.Width, 20);               
               this.Height = 20;
            }
            
            _SelectionOptions = value; 
         }
      }

      /// <summary>
      /// Gets the current server text.
      /// </summary>
      [Browsable(true)]
      public override string Text
      {
         get
         {
            if ( radioServers.Checked )
            {
               return textServer.Text.Trim();
            }
            else // groups selected
            {
               if ( textServer.Text == _stringNoGroupsDefined )
               {
                  return "";
               }
               else
               {
                  return textServer.Text;
               }
            }
         }
         set 
         { 
            textServer.Text = value;
         } 
      }

      /// <summary>
      /// Server caption.  It overrides internal caption functionality.
      /// </summary>
      public string Caption
      {
         get{ return _Caption;}
         set 
         {
            _Caption = value;
            if (_Caption == string.Empty)
            {
               if ( radioGroups.Checked )
                  labelServer.Text = "Server group:";
               else
                  labelServer.Text = "SQL Server(s):";
            }
            else
            {
               labelServer.Text = _Caption;
            }
         } 
      }
      
      /// <summary>
      /// Returns the type of selection made by the user.
      /// </summary>
      [Browsable(false)]
      public ServerSelectionType SelectionType
      {
         get
         {
            if (_SelectionOptions == ServerSelectionOptions.GroupsOnly || radioGroups.Checked)
            {
               return ServerSelectionType.Group;
            }
            else
            {
               return ServerSelectionType.Server;
            }
         }
      }

      /// <summary>
      /// Returns a ServerInformation list based on the selections made by the user.
      /// </summary>
      [Browsable(false)]
      public List<ServerInformation> ServerList
      {
         get
         {
            List<ServerInformation> _ServerList = null; new List<ServerInformation>();

            if (radioServers.Checked)
            {
               _ServerList = new List<ServerInformation>();
            
               // List of servers
               string[] serverList = textServer.Text.Split(';');
               foreach (string _Server in serverList)
               {
                  if ( _Server.Trim() != "" )
                  {
                     string srv = SQLHelpers.NormalizeInstanceName(_Server);
                     if ( ! IsServerInServerList( _ServerList, srv, _SqlCredentials ) )
                     {
                        _ServerList.Add(new ServerInformation(srv, _SqlCredentials));
                     }
                  }
               }
            }
            else
            {
               ToolServerGroup serverGroup = ToolServerGroup.FindServerGroup( textServer.Text );
               if ( serverGroup == null )
               {
                  throw new Exception( "The specified server group does not exist." );
               }
               else
               {
                  _ServerList = new List<ServerInformation>();
                  
                  // Group - recursively add all servers from group to the list of servers to process
                  foreach (ToolServer toolServer in (serverGroup.GetServers(true)))
                  {
                     string srv = SQLHelpers.NormalizeInstanceName(toolServer.Name);
                     _ServerList.Add(new ServerInformation(srv, toolServer.Credentials));
                  }
               }
            }
            return _ServerList;
         }
      }
      
      private bool
         IsServerInServerList( 
            List<ServerInformation>  serverList,
            string                   server,
            SQLCredentials           credentials
         )
      {
         bool found = false;
         foreach ( ServerInformation s in serverList )
         {
            if ( s.Name == server )
            {
               if ( s.SqlCredentials == null || credentials == null )
               {
                  if ( s.SqlCredentials == credentials )
                  {
                     found = true;
                     break;
                  }
               }
               else
               {
                  if ( s.UseSqlAuthentication == credentials.useSqlAuthentication )
                  {
                     if ( s.UseSqlAuthentication )
                     {
                        if ( s.LoginName == credentials.loginName )
                        {
                           found = true;
                           break;
                        }
                     }
                     else
                     {
                        // windows
                        found = true;
                        break;
                     }
                  }
               }
            }
         }
         
         return found;
      }   

      /// <summary>
      /// True if credentials button should be visible, otherwise false.
      /// </summary>
      [Browsable(true)]
      public bool CredentialsVisible
      {
         get { return buttonCredentials.Visible; }
         set
         {
            if ( buttonCredentials.Visible == value ) return;
            
            buttonCredentials.Visible = value;
            
            if ( buttonCredentials.Visible )
            {
               textServer.Width -=25;
            }
            else
            {
               textServer.Width +=25;
            }
         }
      }
      #endregion

      #region Control Functionality

      //-----------------------------------------------------------------------
      // buttonBrowseServer_Click
      //-----------------------------------------------------------------------
      private void buttonBrowseServer_Click(object sender, EventArgs e)
      {
         string selection = Browse();
         if ( selection != "" )
         {
            textServer.Text = selection;
         }
      }
      
      //-----------------------------------------------------------------------
      // Browse
      //-----------------------------------------------------------------------
      private string Browse()
      {
         string newSelection = "";
         
         if (_SelectionOptions == ServerSelectionOptions.ServersOnly || radioServers.Checked)
         {
            // Browse Servers
            Form_SQLServerBrowse browseDlg = new Form_SQLServerBrowse();
            browseDlg.MultiSelect = true;

            this.ParentForm.Cursor = Cursors.WaitCursor;
            bool loaded = browseDlg.LoadServers();
            this.ParentForm.Cursor = Cursors.Default;

            if (loaded)
            {
               DialogResult choice = browseDlg.ShowDialog();
               if (choice == DialogResult.OK)
               {
                  if (textServer.Text != browseDlg.SelectedServer)
                  {
                     newSelection = browseDlg.SelectedServer;
                  }
               }
            }
         }
         else
         {
            // Browse Server Groups
            Form_ServerGroupBrowse dlg = new Form_ServerGroupBrowse();
            DialogResult choice = dlg.ShowDialog();
            if (choice == DialogResult.OK)
            {
               newSelection = dlg.FullPath;
            }
         }
         return newSelection;
      }

      //-----------------------------------------------------------------------
      // buttonCredentials_Click
      //-----------------------------------------------------------------------
      private void buttonCredentials_Click(object sender, EventArgs e)
      {
         Form_Credentials credentialsForm = new Form_Credentials(textServer.Text,_SqlCredentials);
         DialogResult choice = credentialsForm.ShowDialog();
         if (choice == DialogResult.OK)
         {
            _SqlCredentials = credentialsForm.sqlCredentials;
         }
      }

      //-----------------------------------------------------------------------
      // radioServers_CheckedChanged
      //-----------------------------------------------------------------------
      private void radioServers_CheckedChanged(object sender, EventArgs e)
      {
         if (radioServers.Checked)
         {
            CheckedChanged();
            
            textServer.SelectAll();
         }
         textServer.Select();
      }

      //-----------------------------------------------------------------------
      // radioGroups_CheckedChanged
      //-----------------------------------------------------------------------
      private void radioGroups_CheckedChanged(object sender, EventArgs e)
      {
         if (radioGroups.Checked)
         {
            CheckedChanged();
         }
         textServer.Select();
      }

      //-----------------------------------------------------------------------
      // CheckedChanged
      //-----------------------------------------------------------------------
      private void CheckedChanged()
      {
         if ( _loadingForm ) return;
         
         if (radioGroups.Checked)
         {
            //---------------------
            // Show Server Groups
            //---------------------
            
            // save server information
            _SaveServerText = textServer.Text;
            _customServers.Clear();
            for (int i=ToolsetOptions.mruServerCount;i<textServer.Items.Count-1;i++)
            {
               _customServers.Add( textServer.Items[i].ToString() );
            }

            // setup control
            textServer.SelectedIndex = -1;
            textServer.DropDownStyle = ComboBoxStyle.DropDownList;
            textServer.WatermarkText = "Specify a server group";
            this.toolTip1.SetToolTip( this.textServer, "Select a Server Group or choose <Manage Server Groups> to create and edit Server Groups." );
            if ( _Caption == "" ) labelServer.Text = "Server group:";

            buttonBrowse.Enabled = 
            buttonCredentials.Enabled = false;

            // load groups
            LoadDropDownItems();
            
            int ndx = FindListItem( _SaveGroupText );
            if ( ndx != -1 || textServer.Items.Count > 1 )
            {
               textServer.SelectedIndex = ( ndx != - 1) ? ndx : 0; 
            }
         }
         else
         {
            //---------------------
            // Show Servers
            //---------------------
            
            // save group information
            _SaveGroupText = textServer.Text;
            _customGroups.Clear();
            for (int i=ToolsetOptions.mruGroupCount;i<textServer.Items.Count-1;i++)
            {
               _customGroups.Add( textServer.Items[i].ToString() );
            }
            
            // setup control
            textServer.SelectedIndex = -1;
            textServer.DropDownStyle = ComboBoxStyle.DropDown;
            textServer.WatermarkText = "Enter SQL Server(s); separate with semi-colons";
            this.toolTip1.SetToolTip( this.textServer, "Enter one or more SQL Servers separated by semi-colons." );
            if ( _Caption == "" ) labelServer.Text = "SQL Server(s):";

            buttonBrowse.Enabled = 
            buttonCredentials.Enabled = true;
            
            // load groups
            LoadDropDownItems();
            int ndx = FindListItem( _SaveServerText );
            if ( ndx != -1 || textServer.Items.Count > 1 )
            {
               textServer.SelectedIndex = ( ndx != - 1) ? ndx : 0; 
            }
         }
         textServer.Invalidate();
         Application.DoEvents();
      }
      
      //-----------------------------------------------------------------------
      // FindListItem
      //-----------------------------------------------------------------------
      private int FindListItem( string name )
      {
         int pos = -1;
         
         for (int i=0;i<textServer.Items.Count;i++)
         {
            if ( textServer.Items[i].ToString() == name )
            {
               pos = i;
               break;
            }
         }
         return pos;
      }

      #endregion

      #region Events

      //-----------------------------------------------------------------------
      // TextChangedEventHandler
      //-----------------------------------------------------------------------
      private EventHandler _TextChanged;

      public EventHandler TextChangedEventHandler
      {
         get { return _TextChanged; }
         set { _TextChanged = value; }
      }

      /// <summary>
      /// Raised when the server text changes
      /// </summary>
      [EditorBrowsable(EditorBrowsableState.Always)]
      [Browsable(true)]
      public new event EventHandler TextChanged
      {
         add { _TextChanged += value; }
         remove { _TextChanged -= value; }
      }
      
      #endregion

      #region Methods

      //-----------------------------------------------------------------------
      // Select
      //-----------------------------------------------------------------------
      public new void Select()
      {
         textServer.Select();
      }

      #endregion

      #region Event Handlers

      //-----------------------------------------------------------------------
      // textServer_TextChanged
      //-----------------------------------------------------------------------
      void textServer_TextChanged(object sender, EventArgs e)
      {
         if ( ! textServer.Text.StartsWith( _stringBrowsePrefix ) && ! (textServer.Text == _stringManageGroups) )
         {
            EventHandler _Handler = TextChangedEventHandler;
            if (_Handler != null)
            {
               _Handler(this, e);
            }
         }
      }
      #endregion
      
      #region MRU List
      
      private int    m_lastSelectedIndex = -1;
      private string m_lastSelectedGroup = "";
      private bool   m_loadingDropDown = false;
      
      //-----------------------------------------------------------------------
      // LoadDropDownItems
      //-----------------------------------------------------------------------
      private object lockAndLoad = new Object();
      
      private void LoadDropDownItems()
      {
         lock ( lockAndLoad )
         {
         m_loadingDropDown = true;         
         
         textServer.Items.Clear();
         m_lastSelectedIndex = -1;
         
         _lastMruListDateTime = ToolsetOptions.mruLoadTime;
         
         if (radioGroups.Checked)
         {
            //--------------------
            // Load Server Groups
            //--------------------
            int foundNdx = -1;
            int count = 0;
            List<ToolServerGroup> groups = ToolServerGroup.GetAllServerGroups();
            
            if ( groups.Count == 0 )
            {
               _SaveGroupText = _stringNoGroupsDefined;
               AddComboBoxItem( _stringNoGroupsDefined, true );
               textServer.Text          = _stringNoGroupsDefined;
               textServer.SelectedIndex = 0;
            }
            else
            {
               foreach (ToolServerGroup grp in groups )
               {
                  AddComboBoxItem( grp.FullPath, false );
                  
                  if ( grp.FullPath == _SaveGroupText ) foundNdx = count;
                  
                  count ++;
                  if ( count == 25 ) break;
               }
               
               // do we need to add saved group?
               if ( foundNdx == -1)
               {
                  ToolServerGroup tsg = ToolServerGroup.FindServerGroup(_SaveGroupText );
                  if ( tsg == null )
                  {
                     _SaveGroupText = (groups.Count == 0) ? "" : groups[0].FullPath;
                  }
                  else
                  {
                     // add to list
                     AddComboBoxItem( _SaveGroupText, false ); 
                  }
               }
            }

            if ( groups.Count > 25 )
            {
               AddComboBoxItem( _stringBrowseForGroups, true );
            }
            AddComboBoxItem( _stringManageGroups, true );
         }
         else
         {
            //--------------------
            // Load Servers
            //--------------------
            
            for (int s=0; s<ToolsetOptions.mruServerCount; s++ )
            {
               AddComboBoxItem( ToolsetOptions.mruServers[s], false );
            }

            foreach (string srv in _customServers)
            {
               AddComboBoxItem( srv, false );
            }
            
            AddComboBoxItem( _stringBrowseForServers, true );
         }
         m_loadingDropDown = false;         
         }
      }
      
      //-----------------------------------------------------------------------
      // InsertComboBoxItem
      //-----------------------------------------------------------------------
      private void
         InsertComboBoxItem( 
            int       ndx,
            string    itemText,
            bool      specialItem
         )
      {
         DevComponents.Editors.ComboItem newItem = CreateComboBoxItem( itemText, specialItem );
         textServer.Items.Insert( ndx, newItem );
      }    

      //-----------------------------------------------------------------------
      // AddComboBoxItem
      //-----------------------------------------------------------------------
      private int
         AddComboBoxItem( 
            string    itemText,
            bool      specialItem
         )
      {
         DevComponents.Editors.ComboItem newItem = CreateComboBoxItem( itemText, specialItem );
         return textServer.Items.Add( newItem );
      }    
      
      //-----------------------------------------------------------------------
      // CreateComboBoxItem
      //-----------------------------------------------------------------------
      private DevComponents.Editors.ComboItem
         CreateComboBoxItem( 
            string    itemText,
            bool      specialItem
         )
      {
         DevComponents.Editors.ComboItem newItem = new DevComponents.Editors.ComboItem();
         newItem.Text              = itemText;
         newItem.TextLineAlignment = StringAlignment.Center;
         newItem.Tag               = (object)specialItem;
         
         return newItem;
      }    
      

      //-----------------------------------------------------------------------
      // textServer_SelectedIndexChanged
      //-----------------------------------------------------------------------
      private void textServer_SelectedIndexChanged( object sender, EventArgs e )
      {
         if ( m_loadingDropDown ) return;
         
         bool specialItem = false;
         try
         {
            DevComponents.Editors.ComboItem comboItem = (DevComponents.Editors.ComboItem)textServer.SelectedItem;
            specialItem = (comboItem != null ) && ( (bool)comboItem.Tag);
         }
         catch
         {
            /* this handles case where someone inserts without special APIs */ 
         }

         if ( specialItem && textServer.Text.StartsWith( _stringBrowsePrefix ) )
         {
            Application.DoEvents(); // let form redraw without drop down dropped
            string newSelection = Browse();
            
            if ( newSelection == "" )
            {
               textServer.SelectedIndex = m_lastSelectedIndex;
            }
            else
            {
               // they selected one with browse (is it already there?)
               bool found = false;
               for ( int i=0; i<textServer.Items.Count; i++)
               {
                  if ( textServer.Items[i].ToString() == newSelection )
                  {
                     found = true;
                     textServer.SelectedIndex = i;
                     break;
                  }
               }
               
               if ( ! found )
               {
                  // walk backwards to insert before special tag items
                  int ndx;
                  for ( ndx=textServer.Items.Count-1; ndx >=0; ndx-- )
                  {
                     try
                     {
                        DevComponents.Editors.ComboItem combo = (DevComponents.Editors.ComboItem)(textServer.Items[ndx]);
                        if ( ! (bool)combo.Tag )
                        {
                           ndx++;
                           break;
                        }
                     }
                     catch
                     {
                        break;
                     }
                  }
                  if ( ndx == -1 ) ndx = 0;
                  
                  InsertComboBoxItem( ndx, newSelection, false );
                  textServer.SelectedIndex = ndx;
               }
            }
            
            m_lastSelectedGroup = textServer.Text;
         }
         else if ( specialItem && textServer.Text == _stringNoGroupsDefined )
         {
            // do nothing?
            m_lastSelectedGroup = textServer.Text;
         }
         else if ( specialItem && textServer.Text == _stringManageGroups )
         {
            Application.DoEvents(); // let form redraw without drop down dropped
            
            //launch
            Form_ManageServerGroups frm = new Form_ManageServerGroups();
            DialogResult dialogResult = frm.ShowDialog();
            
            //reload
            _SaveGroupText = m_lastSelectedGroup;

            if ( dialogResult == DialogResult.OK )
               LoadDropDownItems();
               
            int ndx = FindListItem( _SaveGroupText );
            if ( ndx != -1 || textServer.Items.Count > 1 )
            {
               textServer.SelectedIndex = ( ndx != - 1) ? ndx : 0; 
            }
            else
            {
               textServer.SelectedIndex = -1;
            }
          }
         else if ( radioServers.Checked && textServer.SelectedIndex != -1)
         {
            m_lastSelectedIndex = textServer.SelectedIndex;
            
            // set credentials 
            if ( textServer.SelectedIndex < ToolsetOptions.mruServerCount )
            {
               this._SqlCredentials = ToolsetOptions.mruServerCredentials[textServer.SelectedIndex];
            }
            else
            {
               this._SqlCredentials = null;
            }
            
            m_lastSelectedGroup = textServer.Text;
         }
         else
         {
            m_lastSelectedIndex = textServer.SelectedIndex;
            m_lastSelectedGroup = textServer.Text;
         }
      }
      
      #endregion
      
      //-----------------------------------------------------------------------
      // labelServer_Resize
      //-----------------------------------------------------------------------
      private void labelServer_Resize(object sender, EventArgs e)
      {
         if ( _Caption != String.Empty )
         {
            int _PreviousX = textServer.Location.X;
            textServer.Location = new Point(labelServer.Size.Width + 5 + 6, textServer.Location.Y);
            textServer.Size = new Size(textServer.Size.Width - (textServer.Location.X - _PreviousX), textServer.Size.Height);
         }
      }
      
      //-----------------------------------------------------------------------
      // ServerGroupsChangedHandler
      //-----------------------------------------------------------------------
      public void ServerGroupsChangedHandler(object sender, EventArgs e)
      {
         if ( m_loadingDropDown ) return;
         
         if ( radioGroups.Checked )  // if server is checked, then we will reload
                                     // automatically when they switch radio button selection
         {
            _SaveGroupText = textServer.Text;

            LoadDropDownItems();
               
            int ndx = FindListItem( _SaveGroupText );
            if ( ndx != -1 || textServer.Items.Count > 1 )
            {
               textServer.SelectedIndex = ( ndx != - 1) ? ndx : 0; 
            }
            else
            {
               textServer.SelectedIndex = -1;
            }
         }
      }

      //-----------------------------------------------------------------------
      // textServer_DropDown
      //-----------------------------------------------------------------------
      private void textServer_DropDown( object sender, EventArgs e )
      {
         string saveText = textServer.Text;
         
         if ( _lastMruListDateTime != ToolsetOptions.mruLoadTime )
         {
            if ( radioServers.Checked )
            {
               _customServers.Clear();
               for (int i=ToolsetOptions.mruServerCount;i<textServer.Items.Count-1;i++)
               {
                  _customServers.Add( textServer.Items[i].ToString() );
               }
            }
            else
            {
               // save group information
               _customGroups.Clear();
               for (int i=ToolsetOptions.mruGroupCount;i<textServer.Items.Count-1;i++)
               {
                  _customGroups.Add( textServer.Items[i].ToString() );
               }
            }
            
            // load
            LoadDropDownItems();
            int ndx = FindListItem( saveText );
            if ( ndx != -1 || textServer.Items.Count > 1 )
            {
               textServer.SelectedIndex = ( ndx != - 1) ? ndx : 0; 
            }
         }
      }

      private void buttonBrowse_Click( object sender, EventArgs e )
      {
         string selection = Browse();
         if ( selection != "" )
         {
            textServer.Text = selection;
         }
      }
   }
}
