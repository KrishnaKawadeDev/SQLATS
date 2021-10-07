namespace Idera.SqlAdminToolset.BackupStatus
{
   partial class BackupHistory
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
         System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem( new string[] {
            "12/31/2007 12:31:00 AM",
            "Differential Database",
            "999 MG",
            "NT AUTHORITY\\SYSTEM",
            "c:\\tree\\tree\\teree"}, -1 );
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( BackupHistory ) );
         this.buttonClose = new DevComponents.DotNetBar.ButtonX();
         this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.labelEmptyResultSet = new DevComponents.DotNetBar.LabelX();
         this.listResults = new DevComponents.DotNetBar.Controls.ListViewEx();
         this.columnLastBackup = new System.Windows.Forms.ColumnHeader();
         this.columnType = new System.Windows.Forms.ColumnHeader();
         this.columnSize = new System.Windows.Forms.ColumnHeader();
         this.columnUser = new System.Windows.Forms.ColumnHeader();
         this.columnPath = new System.Windows.Forms.ColumnHeader();
         this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip( this.components );
         this.contextMenuCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
         this.contextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
         this.labelBackupStatus = new DevComponents.DotNetBar.LabelX();
         this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
         this.buttonCopyToClipboard = new DevComponents.DotNetBar.ButtonX();
         this.checkLimitHistory = new System.Windows.Forms.CheckBox();
         this.groupPanel1.SuspendLayout();
         this.contextMenuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonClose
         // 
         this.buttonClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonClose.Location = new System.Drawing.Point( 745, 396 );
         this.buttonClose.Name = "buttonClose";
         this.buttonClose.Size = new System.Drawing.Size( 65, 26 );
         this.buttonClose.TabIndex = 3;
         this.buttonClose.Text = "&Close";
         this.buttonClose.Click += new System.EventHandler( this.buttonClose_Click );
         // 
         // groupPanel1
         // 
         this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel1.Controls.Add( this.labelEmptyResultSet );
         this.groupPanel1.Controls.Add( this.listResults );
         this.groupPanel1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
         this.groupPanel1.Location = new System.Drawing.Point( 6, 9 );
         this.groupPanel1.Name = "groupPanel1";
         this.groupPanel1.Padding = new System.Windows.Forms.Padding( 6 );
         this.groupPanel1.Size = new System.Drawing.Size( 804, 380 );
         // 
         // 
         // 
         this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
         this.groupPanel1.Style.BackColorGradientAngle = 90;
         this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
         this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanel1.Style.BorderBottomWidth = 1;
         this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
         this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanel1.Style.BorderLeftWidth = 1;
         this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanel1.Style.BorderRightWidth = 1;
         this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanel1.Style.BorderTopWidth = 1;
         this.groupPanel1.Style.CornerDiameter = 4;
         this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
         this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
         this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
         this.groupPanel1.TabIndex = 0;
         this.groupPanel1.Text = "Backup History for <DatabaseName>";
         // 
         // labelEmptyResultSet
         // 
         this.labelEmptyResultSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.labelEmptyResultSet.BackColor = System.Drawing.Color.White;
         this.labelEmptyResultSet.Font = new System.Drawing.Font( "Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
         this.labelEmptyResultSet.ForeColor = System.Drawing.Color.Red;
         this.labelEmptyResultSet.Location = new System.Drawing.Point( 9, 53 );
         this.labelEmptyResultSet.Name = "labelEmptyResultSet";
         this.labelEmptyResultSet.Size = new System.Drawing.Size( 780, 68 );
         this.labelEmptyResultSet.TabIndex = 28;
         this.labelEmptyResultSet.Text = "No data available for this server";
         this.labelEmptyResultSet.TextAlignment = System.Drawing.StringAlignment.Center;
         this.labelEmptyResultSet.TextLineAlignment = System.Drawing.StringAlignment.Near;
         this.labelEmptyResultSet.Visible = false;
         this.labelEmptyResultSet.WordWrap = true;
         // 
         // listResults
         // 
         // 
         // 
         // 
         this.listResults.Border.Class = "ListViewBorder";
         this.listResults.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnLastBackup,
            this.columnType,
            this.columnSize,
            this.columnUser,
            this.columnPath} );
         this.listResults.ContextMenuStrip = this.contextMenuStrip1;
         this.listResults.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listResults.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
         this.listResults.Items.AddRange( new System.Windows.Forms.ListViewItem[] {
            listViewItem1} );
         this.listResults.Location = new System.Drawing.Point( 6, 6 );
         this.listResults.MultiSelect = false;
         this.listResults.Name = "listResults";
         this.listResults.ShowItemToolTips = true;
         this.listResults.Size = new System.Drawing.Size( 786, 345 );
         this.listResults.Sorting = System.Windows.Forms.SortOrder.Descending;
         this.listResults.TabIndex = 1;
         this.listResults.UseCompatibleStateImageBehavior = false;
         this.listResults.View = System.Windows.Forms.View.Details;
         this.listResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler( this.listResults_ColumnClick );
         // 
         // columnLastBackup
         // 
         this.columnLastBackup.Text = "Backup Time";
         this.columnLastBackup.Width = 133;
         // 
         // columnType
         // 
         this.columnType.Text = "Type";
         this.columnType.Width = 121;
         // 
         // columnSize
         // 
         this.columnSize.Text = "Size";
         this.columnSize.Width = 56;
         // 
         // columnUser
         // 
         this.columnUser.Text = "User";
         this.columnUser.Width = 160;
         // 
         // columnPath
         // 
         this.columnPath.Text = "Path";
         this.columnPath.Width = 302;
         // 
         // contextMenuStrip1
         // 
         this.contextMenuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuCopyToClipboard,
            this.contextMenuRefresh} );
         this.contextMenuStrip1.Name = "contextMenuStrip1";
         this.contextMenuStrip1.Size = new System.Drawing.Size( 150, 48 );
         // 
         // contextMenuCopyToClipboard
         // 
         this.contextMenuCopyToClipboard.Enabled = false;
         this.contextMenuCopyToClipboard.Name = "contextMenuCopyToClipboard";
         this.contextMenuCopyToClipboard.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
         this.contextMenuCopyToClipboard.Size = new System.Drawing.Size( 149, 22 );
         this.contextMenuCopyToClipboard.Text = "Copy";
         this.contextMenuCopyToClipboard.Click += new System.EventHandler( this.contextMenuCopyToClipboard_Click );
         // 
         // contextMenuRefresh
         // 
         this.contextMenuRefresh.Image = ((System.Drawing.Image)(resources.GetObject( "contextMenuRefresh.Image" )));
         this.contextMenuRefresh.Name = "contextMenuRefresh";
         this.contextMenuRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
         this.contextMenuRefresh.Size = new System.Drawing.Size( 149, 22 );
         this.contextMenuRefresh.Text = "Refresh";
         this.contextMenuRefresh.Click += new System.EventHandler( this.contextMenuRefresh_Click );
         // 
         // labelBackupStatus
         // 
         this.labelBackupStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.labelBackupStatus.Location = new System.Drawing.Point( 11, 396 );
         this.labelBackupStatus.Name = "labelBackupStatus";
         this.labelBackupStatus.Size = new System.Drawing.Size( 220, 25 );
         this.labelBackupStatus.TabIndex = 2;
         this.labelBackupStatus.Text = "<nn> backup events";
         // 
         // directorySearcher1
         // 
         this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse( "-00:00:01" );
         this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse( "-00:00:01" );
         this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse( "-00:00:01" );
         // 
         // buttonCopyToClipboard
         // 
         this.buttonCopyToClipboard.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCopyToClipboard.BackColor = System.Drawing.Color.White;
         this.buttonCopyToClipboard.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonCopyToClipboard.Enabled = false;
         this.buttonCopyToClipboard.Image = ((System.Drawing.Image)(resources.GetObject( "buttonCopyToClipboard.Image" )));
         this.buttonCopyToClipboard.Location = new System.Drawing.Point( 548, 396 );
         this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
         this.buttonCopyToClipboard.Size = new System.Drawing.Size( 187, 26 );
         this.buttonCopyToClipboard.TabIndex = 2;
         this.buttonCopyToClipboard.Text = "Co&py Results To Clipboard";
         this.buttonCopyToClipboard.Click += new System.EventHandler( this.buttonCopyToClipboard_Click );
         // 
         // checkLimitHistory
         // 
         this.checkLimitHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.checkLimitHistory.AutoSize = true;
         this.checkLimitHistory.Checked = true;
         this.checkLimitHistory.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkLimitHistory.Location = new System.Drawing.Point( 407, 401 );
         this.checkLimitHistory.Name = "checkLimitHistory";
         this.checkLimitHistory.Size = new System.Drawing.Size( 134, 17 );
         this.checkLimitHistory.TabIndex = 4;
         this.checkLimitHistory.Text = "Limit to last 500 events";
         this.checkLimitHistory.UseVisualStyleBackColor = true;
         this.checkLimitHistory.CheckedChanged += new System.EventHandler( this.checkLimitHistory_CheckedChanged );
         // 
         // BackupHistory
         // 
         this.AcceptButton = this.buttonClose;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.ClientSize = new System.Drawing.Size( 816, 430 );
         this.Controls.Add( this.checkLimitHistory );
         this.Controls.Add( this.buttonCopyToClipboard );
         this.Controls.Add( this.labelBackupStatus );
         this.Controls.Add( this.groupPanel1 );
         this.Controls.Add( this.buttonClose );
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size( 553, 301 );
         this.Name = "BackupHistory";
         this.Padding = new System.Windows.Forms.Padding( 6 );
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Show Backup History";
         this.groupPanel1.ResumeLayout( false );
         this.contextMenuStrip1.ResumeLayout( false );
         this.ResumeLayout( false );
         this.PerformLayout();

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX buttonClose;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.Controls.ListViewEx listResults;
      private System.Windows.Forms.ColumnHeader columnLastBackup;
      private System.Windows.Forms.ColumnHeader columnType;
      private System.Windows.Forms.ColumnHeader columnSize;
      private System.Windows.Forms.ColumnHeader columnUser;
      private System.Windows.Forms.ColumnHeader columnPath;
      private DevComponents.DotNetBar.LabelX labelBackupStatus;
      private DevComponents.DotNetBar.LabelX labelEmptyResultSet;
      private System.DirectoryServices.DirectorySearcher directorySearcher1;
      private DevComponents.DotNetBar.ButtonX buttonCopyToClipboard;
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
      private System.Windows.Forms.ToolStripMenuItem contextMenuCopyToClipboard;
      private System.Windows.Forms.ToolStripMenuItem contextMenuRefresh;
      private System.Windows.Forms.CheckBox checkLimitHistory;
   }
}