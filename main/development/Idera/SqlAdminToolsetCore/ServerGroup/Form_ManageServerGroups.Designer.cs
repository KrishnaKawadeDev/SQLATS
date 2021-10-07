namespace Idera.SqlAdminToolset.Core
{
   partial class Form_ManageServerGroups
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose( bool disposing )
      {
         if ( disposing && (components != null) )
         {
            components.Dispose();
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_ManageServerGroups ) );
         this.labelNoServerGroups = new DevComponents.DotNetBar.LabelX();
         this.treeServerGroups = new System.Windows.Forms.TreeView();
         this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip( this.components );
         this.contextMenuAddGroup = new System.Windows.Forms.ToolStripMenuItem();
         this.contextMenuRenameGroup = new System.Windows.Forms.ToolStripMenuItem();
         this.contextMenuDeleteGroup = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
         this.contextMenuAddServer = new System.Windows.Forms.ToolStripMenuItem();
         this.contextMenuRenameServer = new System.Windows.Forms.ToolStripMenuItem();
         this.contextMenuSetServerCredentials = new System.Windows.Forms.ToolStripMenuItem();
         this.contextMenuTextConnection = new System.Windows.Forms.ToolStripMenuItem();
         this.contextMenuRemoveServer = new System.Windows.Forms.ToolStripMenuItem();
         this.imageList = new System.Windows.Forms.ImageList( this.components );
         this.buttonAddServer = new DevComponents.DotNetBar.ButtonX();
         this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
         this.labelPrompt = new DevComponents.DotNetBar.LabelX();
         this.buttonRemoveServer = new DevComponents.DotNetBar.ButtonX();
         this.buttonAddGroup = new DevComponents.DotNetBar.ButtonX();
         this.buttonDeleteGroup = new DevComponents.DotNetBar.ButtonX();
         this.buttonOK = new DevComponents.DotNetBar.ButtonX();
         this.buttonRenameGroup = new DevComponents.DotNetBar.ButtonX();
         this.buttonSetServerCredentials = new DevComponents.DotNetBar.ButtonX();
         this.buttonRenameServer = new DevComponents.DotNetBar.ButtonX();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.labelX3 = new DevComponents.DotNetBar.LabelX();
         this.labelX2 = new DevComponents.DotNetBar.LabelX();
         this.labelX1 = new DevComponents.DotNetBar.LabelX();
         this.pictureBox3 = new System.Windows.Forms.PictureBox();
         this.pictureBox2 = new System.Windows.Forms.PictureBox();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.contextMenuStrip1.SuspendLayout();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // labelNoServerGroups
         // 
         this.labelNoServerGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.labelNoServerGroups.BackColor = System.Drawing.Color.White;
         this.labelNoServerGroups.Font = new System.Drawing.Font( "Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
         this.labelNoServerGroups.ForeColor = System.Drawing.SystemColors.ControlText;
         this.labelNoServerGroups.Location = new System.Drawing.Point( 25, 33 );
         this.labelNoServerGroups.Name = "labelNoServerGroups";
         this.labelNoServerGroups.Size = new System.Drawing.Size( 384, 79 );
         this.labelNoServerGroups.TabIndex = 35;
         this.labelNoServerGroups.Text = "No server groups defined";
         this.labelNoServerGroups.TextAlignment = System.Drawing.StringAlignment.Center;
         this.labelNoServerGroups.TextLineAlignment = System.Drawing.StringAlignment.Near;
         this.labelNoServerGroups.Visible = false;
         this.labelNoServerGroups.WordWrap = true;
         // 
         // treeServerGroups
         // 
         this.treeServerGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.treeServerGroups.ContextMenuStrip = this.contextMenuStrip1;
         this.treeServerGroups.HideSelection = false;
         this.treeServerGroups.ImageIndex = 0;
         this.treeServerGroups.ImageList = this.imageList;
         this.treeServerGroups.Location = new System.Drawing.Point( 12, 27 );
         this.treeServerGroups.Name = "treeServerGroups";
         this.treeServerGroups.SelectedImageIndex = 0;
         this.treeServerGroups.Size = new System.Drawing.Size( 407, 257 );
         this.treeServerGroups.TabIndex = 1;
         this.treeServerGroups.MouseUp += new System.Windows.Forms.MouseEventHandler( this.treeServerGroups_MouseUp );
         this.treeServerGroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.treeServerGroups_AfterSelect );
         this.treeServerGroups.KeyUp += new System.Windows.Forms.KeyEventHandler( this.treeServerGroups_KeyUp );
         // 
         // contextMenuStrip1
         // 
         this.contextMenuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuAddGroup,
            this.contextMenuRenameGroup,
            this.contextMenuDeleteGroup,
            this.toolStripMenuItem1,
            this.contextMenuAddServer,
            this.contextMenuRenameServer,
            this.contextMenuSetServerCredentials,
            this.contextMenuTextConnection,
            this.contextMenuRemoveServer} );
         this.contextMenuStrip1.Name = "contextMenuStrip1";
         this.contextMenuStrip1.Size = new System.Drawing.Size( 212, 186 );
         // 
         // contextMenuAddGroup
         // 
         this.contextMenuAddGroup.Name = "contextMenuAddGroup";
         this.contextMenuAddGroup.Size = new System.Drawing.Size( 211, 22 );
         this.contextMenuAddGroup.Text = "Add &Group";
         this.contextMenuAddGroup.Click += new System.EventHandler( this.contextMenuAddGroup_Click );
         // 
         // contextMenuRenameGroup
         // 
         this.contextMenuRenameGroup.Enabled = false;
         this.contextMenuRenameGroup.Name = "contextMenuRenameGroup";
         this.contextMenuRenameGroup.Size = new System.Drawing.Size( 211, 22 );
         this.contextMenuRenameGroup.Text = "&Rename Group";
         this.contextMenuRenameGroup.Click += new System.EventHandler( this.contextMenuRenameGroup_Click );
         // 
         // contextMenuDeleteGroup
         // 
         this.contextMenuDeleteGroup.Enabled = false;
         this.contextMenuDeleteGroup.Name = "contextMenuDeleteGroup";
         this.contextMenuDeleteGroup.Size = new System.Drawing.Size( 211, 22 );
         this.contextMenuDeleteGroup.Text = "&Delete Group";
         this.contextMenuDeleteGroup.Click += new System.EventHandler( this.contextMenuDeleteGroup_Click );
         // 
         // toolStripMenuItem1
         // 
         this.toolStripMenuItem1.Name = "toolStripMenuItem1";
         this.toolStripMenuItem1.Size = new System.Drawing.Size( 208, 6 );
         // 
         // contextMenuAddServer
         // 
         this.contextMenuAddServer.Enabled = false;
         this.contextMenuAddServer.Name = "contextMenuAddServer";
         this.contextMenuAddServer.Size = new System.Drawing.Size( 211, 22 );
         this.contextMenuAddServer.Text = "Add &Server";
         this.contextMenuAddServer.Click += new System.EventHandler( this.contextMenuAddServer_Click );
         // 
         // contextMenuRenameServer
         // 
         this.contextMenuRenameServer.Enabled = false;
         this.contextMenuRenameServer.Name = "contextMenuRenameServer";
         this.contextMenuRenameServer.Size = new System.Drawing.Size( 211, 22 );
         this.contextMenuRenameServer.Text = "Re&name Server";
         this.contextMenuRenameServer.Click += new System.EventHandler( this.contextMenuRenameServer_Click );
         // 
         // contextMenuSetServerCredentials
         // 
         this.contextMenuSetServerCredentials.Enabled = false;
         this.contextMenuSetServerCredentials.Name = "contextMenuSetServerCredentials";
         this.contextMenuSetServerCredentials.Size = new System.Drawing.Size( 211, 22 );
         this.contextMenuSetServerCredentials.Text = "Set Server &Credentials";
         this.contextMenuSetServerCredentials.Click += new System.EventHandler( this.contextMenuSetServerCredentials_Click );
         // 
         // contextMenuTextConnection
         // 
         this.contextMenuTextConnection.Enabled = false;
         this.contextMenuTextConnection.Name = "contextMenuTextConnection";
         this.contextMenuTextConnection.Size = new System.Drawing.Size( 211, 22 );
         this.contextMenuTextConnection.Text = "&Test Connection to Server";
         this.contextMenuTextConnection.Click += new System.EventHandler( this.contextMenuTextConnection_Click );
         // 
         // contextMenuRemoveServer
         // 
         this.contextMenuRemoveServer.Enabled = false;
         this.contextMenuRemoveServer.Name = "contextMenuRemoveServer";
         this.contextMenuRemoveServer.Size = new System.Drawing.Size( 211, 22 );
         this.contextMenuRemoveServer.Text = "&Remove Server";
         this.contextMenuRemoveServer.Click += new System.EventHandler( this.contextMenuRemoveServer_Click );
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject( "imageList.ImageStream" )));
         this.imageList.TransparentColor = System.Drawing.Color.Black;
         this.imageList.Images.SetKeyName( 0, "ServerGroups_16.png" );
         this.imageList.Images.SetKeyName( 1, "server.png" );
         this.imageList.Images.SetKeyName( 2, "server_id_card.png" );
         // 
         // buttonAddServer
         // 
         this.buttonAddServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonAddServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonAddServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonAddServer.Enabled = false;
         this.buttonAddServer.Image = ((System.Drawing.Image)(resources.GetObject( "buttonAddServer.Image" )));
         this.buttonAddServer.Location = new System.Drawing.Point( 426, 155 );
         this.buttonAddServer.Name = "buttonAddServer";
         this.buttonAddServer.Size = new System.Drawing.Size( 143, 28 );
         this.buttonAddServer.TabIndex = 5;
         this.buttonAddServer.Text = "Add &Server(s)";
         this.buttonAddServer.Click += new System.EventHandler( this.buttonAddServer_Click );
         // 
         // buttonCancel
         // 
         this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point( 425, 350 );
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size( 143, 28 );
         this.buttonCancel.TabIndex = 10;
         this.buttonCancel.Text = "&Cancel";
         this.buttonCancel.Click += new System.EventHandler( this.buttonCancel_Click );
         // 
         // labelPrompt
         // 
         this.labelPrompt.AutoSize = true;
         this.labelPrompt.Location = new System.Drawing.Point( 12, 11 );
         this.labelPrompt.Name = "labelPrompt";
         this.labelPrompt.Size = new System.Drawing.Size( 77, 15 );
         this.labelPrompt.TabIndex = 0;
         this.labelPrompt.Text = "Server Groups:";
         // 
         // buttonRemoveServer
         // 
         this.buttonRemoveServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonRemoveServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonRemoveServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonRemoveServer.Enabled = false;
         this.buttonRemoveServer.Image = ((System.Drawing.Image)(resources.GetObject( "buttonRemoveServer.Image" )));
         this.buttonRemoveServer.Location = new System.Drawing.Point( 426, 256 );
         this.buttonRemoveServer.Name = "buttonRemoveServer";
         this.buttonRemoveServer.Size = new System.Drawing.Size( 143, 28 );
         this.buttonRemoveServer.TabIndex = 8;
         this.buttonRemoveServer.Text = "&Remove Server";
         this.buttonRemoveServer.Click += new System.EventHandler( this.buttonRemoveServer_Click );
         // 
         // buttonAddGroup
         // 
         this.buttonAddGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonAddGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonAddGroup.Image = ((System.Drawing.Image)(resources.GetObject( "buttonAddGroup.Image" )));
         this.buttonAddGroup.Location = new System.Drawing.Point( 426, 27 );
         this.buttonAddGroup.Name = "buttonAddGroup";
         this.buttonAddGroup.Size = new System.Drawing.Size( 143, 28 );
         this.buttonAddGroup.TabIndex = 2;
         this.buttonAddGroup.Text = "Create &Group";
         this.buttonAddGroup.Click += new System.EventHandler( this.buttonAddGroup_Click );
         // 
         // buttonDeleteGroup
         // 
         this.buttonDeleteGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonDeleteGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonDeleteGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonDeleteGroup.Enabled = false;
         this.buttonDeleteGroup.Image = ((System.Drawing.Image)(resources.GetObject( "buttonDeleteGroup.Image" )));
         this.buttonDeleteGroup.Location = new System.Drawing.Point( 426, 95 );
         this.buttonDeleteGroup.Name = "buttonDeleteGroup";
         this.buttonDeleteGroup.Size = new System.Drawing.Size( 143, 28 );
         this.buttonDeleteGroup.TabIndex = 4;
         this.buttonDeleteGroup.Text = "&Delete Group";
         this.buttonDeleteGroup.Click += new System.EventHandler( this.buttonDeleteGroup_Click );
         // 
         // buttonOK
         // 
         this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point( 426, 317 );
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size( 142, 28 );
         this.buttonOK.TabIndex = 9;
         this.buttonOK.Text = "&OK";
         this.buttonOK.Click += new System.EventHandler( this.buttonOK_Click );
         // 
         // buttonRenameGroup
         // 
         this.buttonRenameGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonRenameGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonRenameGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonRenameGroup.Enabled = false;
         this.buttonRenameGroup.Image = ((System.Drawing.Image)(resources.GetObject( "buttonRenameGroup.Image" )));
         this.buttonRenameGroup.Location = new System.Drawing.Point( 426, 61 );
         this.buttonRenameGroup.Name = "buttonRenameGroup";
         this.buttonRenameGroup.Size = new System.Drawing.Size( 143, 28 );
         this.buttonRenameGroup.TabIndex = 3;
         this.buttonRenameGroup.Text = "&Rename Group";
         this.buttonRenameGroup.Click += new System.EventHandler( this.buttonModifyGroup_Click );
         // 
         // buttonSetServerCredentials
         // 
         this.buttonSetServerCredentials.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonSetServerCredentials.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonSetServerCredentials.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonSetServerCredentials.Enabled = false;
         this.buttonSetServerCredentials.Image = ((System.Drawing.Image)(resources.GetObject( "buttonSetServerCredentials.Image" )));
         this.buttonSetServerCredentials.Location = new System.Drawing.Point( 426, 222 );
         this.buttonSetServerCredentials.Name = "buttonSetServerCredentials";
         this.buttonSetServerCredentials.Size = new System.Drawing.Size( 143, 28 );
         this.buttonSetServerCredentials.TabIndex = 7;
         this.buttonSetServerCredentials.Text = "&Set Server Credentials";
         this.buttonSetServerCredentials.Click += new System.EventHandler( this.buttonSetServerCredentials_Click );
         // 
         // buttonRenameServer
         // 
         this.buttonRenameServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonRenameServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonRenameServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonRenameServer.Enabled = false;
         this.buttonRenameServer.Image = ((System.Drawing.Image)(resources.GetObject( "buttonRenameServer.Image" )));
         this.buttonRenameServer.Location = new System.Drawing.Point( 426, 188 );
         this.buttonRenameServer.Name = "buttonRenameServer";
         this.buttonRenameServer.Size = new System.Drawing.Size( 143, 28 );
         this.buttonRenameServer.TabIndex = 6;
         this.buttonRenameServer.Text = "&Rename Server";
         this.buttonRenameServer.Click += new System.EventHandler( this.buttonRenameServer_Click );
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.groupBox1.Controls.Add( this.labelX3 );
         this.groupBox1.Controls.Add( this.labelX2 );
         this.groupBox1.Controls.Add( this.labelX1 );
         this.groupBox1.Controls.Add( this.pictureBox3 );
         this.groupBox1.Controls.Add( this.pictureBox2 );
         this.groupBox1.Controls.Add( this.pictureBox1 );
         this.groupBox1.Location = new System.Drawing.Point( 12, 292 );
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size( 236, 86 );
         this.groupBox1.TabIndex = 36;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Key";
         // 
         // labelX3
         // 
         this.labelX3.AutoSize = true;
         this.labelX3.Location = new System.Drawing.Point( 31, 62 );
         this.labelX3.Name = "labelX3";
         this.labelX3.Size = new System.Drawing.Size( 174, 15 );
         this.labelX3.TabIndex = 5;
         this.labelX3.Text = "= SQL Server (SQL Authentication)";
         // 
         // labelX2
         // 
         this.labelX2.AutoSize = true;
         this.labelX2.Location = new System.Drawing.Point( 31, 41 );
         this.labelX2.Name = "labelX2";
         this.labelX2.Size = new System.Drawing.Size( 197, 15 );
         this.labelX2.TabIndex = 4;
         this.labelX2.Text = "= SQL Server (Windows Authentication)";
         // 
         // labelX1
         // 
         this.labelX1.AutoSize = true;
         this.labelX1.Location = new System.Drawing.Point( 29, 19 );
         this.labelX1.Name = "labelX1";
         this.labelX1.Size = new System.Drawing.Size( 78, 15 );
         this.labelX1.TabIndex = 3;
         this.labelX1.Text = "= Server Group";
         // 
         // pictureBox3
         // 
         this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject( "pictureBox3.Image" )));
         this.pictureBox3.Location = new System.Drawing.Point( 10, 63 );
         this.pictureBox3.Name = "pictureBox3";
         this.pictureBox3.Size = new System.Drawing.Size( 16, 16 );
         this.pictureBox3.TabIndex = 2;
         this.pictureBox3.TabStop = false;
         // 
         // pictureBox2
         // 
         this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject( "pictureBox2.Image" )));
         this.pictureBox2.Location = new System.Drawing.Point( 10, 41 );
         this.pictureBox2.Name = "pictureBox2";
         this.pictureBox2.Size = new System.Drawing.Size( 16, 16 );
         this.pictureBox2.TabIndex = 1;
         this.pictureBox2.TabStop = false;
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject( "pictureBox1.Image" )));
         this.pictureBox1.Location = new System.Drawing.Point( 9, 19 );
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size( 16, 16 );
         this.pictureBox1.TabIndex = 0;
         this.pictureBox1.TabStop = false;
         // 
         // Form_ManageServerGroups
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size( 575, 390 );
         this.Controls.Add( this.groupBox1 );
         this.Controls.Add( this.buttonRenameServer );
         this.Controls.Add( this.buttonSetServerCredentials );
         this.Controls.Add( this.buttonRenameGroup );
         this.Controls.Add( this.buttonOK );
         this.Controls.Add( this.labelNoServerGroups );
         this.Controls.Add( this.buttonDeleteGroup );
         this.Controls.Add( this.buttonAddGroup );
         this.Controls.Add( this.treeServerGroups );
         this.Controls.Add( this.buttonRemoveServer );
         this.Controls.Add( this.labelPrompt );
         this.Controls.Add( this.buttonCancel );
         this.Controls.Add( this.buttonAddServer );
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size( 413, 398 );
         this.Name = "Form_ManageServerGroups";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Manage Server Groups";
         this.HelpRequested += new System.Windows.Forms.HelpEventHandler( this.Form_ManageServerGroups_HelpRequested );
         this.contextMenuStrip1.ResumeLayout( false );
         this.groupBox1.ResumeLayout( false );
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout( false );
         this.PerformLayout();

      }

      #endregion

      private DevComponents.DotNetBar.LabelX labelNoServerGroups;
      private System.Windows.Forms.TreeView treeServerGroups;
      private DevComponents.DotNetBar.ButtonX buttonAddServer;
      private DevComponents.DotNetBar.ButtonX buttonCancel;
      private DevComponents.DotNetBar.LabelX labelPrompt;
      private DevComponents.DotNetBar.ButtonX buttonRemoveServer;
      private DevComponents.DotNetBar.ButtonX buttonAddGroup;
      private DevComponents.DotNetBar.ButtonX buttonDeleteGroup;
      private System.Windows.Forms.ImageList imageList;
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
      private System.Windows.Forms.ToolStripMenuItem contextMenuAddServer;
      private System.Windows.Forms.ToolStripMenuItem contextMenuRemoveServer;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem contextMenuAddGroup;
      private System.Windows.Forms.ToolStripMenuItem contextMenuDeleteGroup;
      private DevComponents.DotNetBar.ButtonX buttonOK;
      private System.Windows.Forms.ToolStripMenuItem contextMenuRenameGroup;
      private DevComponents.DotNetBar.ButtonX buttonRenameGroup;
      private System.Windows.Forms.ToolStripMenuItem contextMenuSetServerCredentials;
      private DevComponents.DotNetBar.ButtonX buttonSetServerCredentials;
      private System.Windows.Forms.ToolStripMenuItem contextMenuTextConnection;
      private DevComponents.DotNetBar.ButtonX buttonRenameServer;
      private System.Windows.Forms.ToolStripMenuItem contextMenuRenameServer;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.PictureBox pictureBox1;
      private DevComponents.DotNetBar.LabelX labelX3;
      private DevComponents.DotNetBar.LabelX labelX2;
      private DevComponents.DotNetBar.LabelX labelX1;
      private System.Windows.Forms.PictureBox pictureBox3;
      private System.Windows.Forms.PictureBox pictureBox2;
   }
}