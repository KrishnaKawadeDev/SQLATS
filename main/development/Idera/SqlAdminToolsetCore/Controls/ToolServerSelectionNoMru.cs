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
   /// Allows a user to select a SQL Server or a server group to run a task against.
   /// </summary>
   public partial class ToolServerSelectionNoMru : UserControl
   {
      #region variables
      private ServerSelectionOptions _SelectionOptions = ServerSelectionOptions.ServersAndGroups;

      private SQLCredentials _SqlCredentials = null;
      private string         _Caption = string.Empty;
      
      private string         _SaveGroupText = string.Empty;
      private string         _SaveServerText = string.Empty;
      private bool           _AllowMultiSelect = true;
      #endregion

      #region .ctor
      public ToolServerSelectionNoMru()
      {
         InitializeComponent();
         textServer.TextChanged += new EventHandler(textServer_TextChanged);
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

      /// <summary>
      /// Selected SQL Server credentials.
      /// </summary>
      [Browsable(false)]
      public SQLCredentials SqlCredentials
      {
         get { return _SqlCredentials; }
         set { _SqlCredentials = value; }
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
         get { return textServer.Text; }
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
            List<ServerInformation> _ServerList = new List<ServerInformation>();

            if (radioServers.Checked)
            {
               // List of servers
               string[] serverList = textServer.Text.Split(';');
               foreach (string _Server in serverList)
               {
                  string srv = SQLHelpers.NormalizeInstanceName(_Server);
                  if ( ! IsServerInServerList( _ServerList, srv, _SqlCredentials ) )
                  {
                     _ServerList.Add(new ServerInformation(srv, _SqlCredentials));
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

      /// <summary>
      /// Gets or sets whether watermark text is displayed when control is empty. Default value is true.
      /// </summary>
      [Browsable(true)]
      public bool WatermarkEnabled
      {
         get
         {
            return textServer.WatermarkEnabled;
         }
         set
         {
            textServer.WatermarkEnabled = value;
         }
      }

      /// <summary>
      /// True if the server selection should allow for multiple selections, otherwise false.  Defaults to true.
      /// </summary>
      [Browsable(true)]
      public bool AllowMultiSelect
      {
         get
         {
            return _AllowMultiSelect;
         }
         set
         {
            _AllowMultiSelect = value;
         }
      }
      #endregion

      #region Control Functionality
      private void buttonBrowseServer_Click(object sender, EventArgs e)
      {
         string selection = Browse();
         if ( selection != "" )
         {
            textServer.Text = selection;
         }
      }
      
      private string Browse()
      {
         if (_SelectionOptions == ServerSelectionOptions.ServersOnly || radioServers.Checked)
         {
            // Browse Servers
            Form_SQLServerBrowse browseDlg = new Form_SQLServerBrowse();
            browseDlg.MultiSelect = _AllowMultiSelect;

            this.ParentForm.Cursor = Cursors.WaitCursor;
            bool loaded = browseDlg.LoadServers();
            this.ParentForm.Cursor = Cursors.Default;

            if (loaded)
            {
               DialogResult choice = browseDlg.ShowDialog();
               if (choice == DialogResult.OK)
               {
                  textServer.Text = browseDlg.SelectedServer;
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
               textServer.Text = dlg.FullPath;
            }
         }
         return textServer.Text;
      }

      private void buttonCredentials_Click(object sender, EventArgs e)
      {
         Form_Credentials credentialsForm = new Form_Credentials(textServer.Text,_SqlCredentials);
         DialogResult choice = credentialsForm.ShowDialog();
         if (choice == DialogResult.OK)
         {
            _SqlCredentials = credentialsForm.sqlCredentials;

            EventHandler _Handler = CredentialsChangedEventHandler;
            if (_Handler != null)
            {
                _Handler(this, e);
            }
         }
      }

      private void radioServers_CheckedChanged(object sender, EventArgs e)
      {
         if (radioServers.Checked)
         {
            CheckedChanged();
            textServer.SelectAll();
         }
         textServer.Select();
      }

      private void radioGroups_CheckedChanged(object sender, EventArgs e)
      {
         if (radioGroups.Checked)
         {
            CheckedChanged();
         }
         textServer.Select();
      }

      private void CheckedChanged()
      {
         if (radioGroups.Checked)
         {
            // save server information
            _SaveServerText = textServer.Text;
            textServer.Text = _SaveGroupText;

            // setup control
            textServer.WatermarkText = "";
            if ( _Caption == "" ) labelServer.Text = "Server group:";
            buttonCredentials.Enabled = false;
         }
         else
         {
            // save group information
            _SaveGroupText = textServer.Text;
            textServer.Text = _SaveServerText;
            
            // setup control
            textServer.WatermarkText = "Enter SQL Server(s); separate with semi-colons";
            if ( _Caption == "" ) labelServer.Text = "SQL Server(s):";
            buttonCredentials.Enabled = true;
         }
         textServer.Invalidate();
         Application.DoEvents();
      }
      
      #endregion

      #region Events
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

      private EventHandler _CredentialsChanged;

      public EventHandler CredentialsChangedEventHandler
      {
          get { return _CredentialsChanged; }
          set { _CredentialsChanged = value; }
      }

      /// <summary>
      /// Raised when the server credentials change.
      /// </summary>
      [EditorBrowsable(EditorBrowsableState.Always)]
      [Browsable(true)]
      public new event EventHandler CredentialsChanged
      {
          add { _CredentialsChanged += value; }
          remove { _CredentialsChanged -= value; }
      }
      #endregion

      #region Methods
      public new void Select()
      {
         textServer.Select();
      }

      #endregion

      #region Event Handlers

      void textServer_TextChanged(object sender, EventArgs e)
      {
         EventHandler _Handler = TextChangedEventHandler;
         if (_Handler != null)
         {
            _Handler(this, e);
         }
      }
      #endregion
      
      private void labelServer_Resize(object sender, EventArgs e)
      {
         if ( _Caption != String.Empty )
         {
            int _PreviousX = textServer.Location.X;
            textServer.Location = new Point(labelServer.Size.Width + 5 + 6, textServer.Location.Y);
            textServer.Size = new Size(textServer.Size.Width - (textServer.Location.X - _PreviousX), textServer.Size.Height);
         }
      }

      private void buttonBrowse_Click( object sender, EventArgs e )
      {
         Browse();
      }
   }
}
