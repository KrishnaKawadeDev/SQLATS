namespace Idera.SqlAdminToolset.ServerPing
{
   partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.groupOptions_Servers = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.radioServers = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.listServers = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.colIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.buttonAddServer = new DevComponents.DotNetBar.ButtonX();
            this.buttonEditServer = new DevComponents.DotNetBar.ButtonX();
            this.buttonRemoveServer = new DevComponents.DotNetBar.ButtonX();
            this.radioServerGroup = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.comboServerGroup = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupOptions = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkRunInSystemTray = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkAlertOnline = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkRunAtStartup = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkAlertOffline = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkAutoRefresh = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkMinimizeToSystemTray = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelRefreshInterval2 = new DevComponents.DotNetBar.LabelX();
            this.textRefreshInterval = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
            this.buttonRefresh = new DevComponents.DotNetBar.ButtonX();
            this.groupServers = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelProcessingError = new DevComponents.DotNetBar.LabelX();
            this.groupStatus = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pictureOverallStatus = new System.Windows.Forms.PictureBox();
            this.labelOverallStatus = new DevComponents.DotNetBar.LabelX();
            this.listResults = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnIgnore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnError = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuResults = new System.Windows.Forms.ContextMenuStrip();
            this.contextMenuIgnoreServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStartServer = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStopServer = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuPauseServer = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuResumeServer = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuRestartServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuList = new System.Windows.Forms.ContextMenuStrip();
            this.contextMenuAddServer = new System.Windows.Forms.ToolStripMenuItem();
            this.contextgMenuEditServer = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuRemoveServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.labelMethod = new System.Windows.Forms.LinkLabel();
            this.labelLastCheckTime = new DevComponents.DotNetBar.LabelX();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.menuReallyExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHealthCheckOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuManageServerGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsetOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContactTechnicalSupport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuDeactivateLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAboutIderaProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon();
            this.contextMenuNotify = new System.Windows.Forms.ContextMenuStrip();
            this.ContextMenuRefreshStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuOpenHealthCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListBig = new System.Windows.Forms.ImageList();
            this.timerAutoRefresh = new System.Windows.Forms.Timer();
            this.timerCheckShow = new System.Windows.Forms.Timer();
            this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.panelMiddle.SuspendLayout();
            this.groupOptions_Servers.SuspendLayout();
            this.groupOptions.SuspendLayout();
            this.groupServers.SuspendLayout();
            this.groupStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOverallStatus)).BeginInit();
            this.contextMenuResults.SuspendLayout();
            this.contextMenuList.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.groupOptions_Servers);
            this.panelMiddle.Controls.Add(this.groupOptions);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMiddle.Location = new System.Drawing.Point(0, 169);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Padding = new System.Windows.Forms.Padding(6);
            this.panelMiddle.Size = new System.Drawing.Size(319, 337);
            this.panelMiddle.TabIndex = 14;
            // 
            // groupOptions_Servers
            // 
            this.groupOptions_Servers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupOptions_Servers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupOptions_Servers.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupOptions_Servers.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupOptions_Servers.Controls.Add(this.radioServers);
            this.groupOptions_Servers.Controls.Add(this.listServers);
            this.groupOptions_Servers.Controls.Add(this.buttonAddServer);
            this.groupOptions_Servers.Controls.Add(this.buttonEditServer);
            this.groupOptions_Servers.Controls.Add(this.buttonRemoveServer);
            this.groupOptions_Servers.Controls.Add(this.radioServerGroup);
            this.groupOptions_Servers.Controls.Add(this.comboServerGroup);
            this.groupOptions_Servers.IsShadowEnabled = true;
            this.groupOptions_Servers.Location = new System.Drawing.Point(6, 6);
            this.groupOptions_Servers.Name = "groupOptions_Servers";
            this.groupOptions_Servers.Size = new System.Drawing.Size(307, 156);
            // 
            // 
            // 
            this.groupOptions_Servers.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupOptions_Servers.Style.BackColorGradientAngle = 90;
            this.groupOptions_Servers.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupOptions_Servers.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupOptions_Servers.Style.BorderBottomWidth = 1;
            this.groupOptions_Servers.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupOptions_Servers.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupOptions_Servers.Style.BorderLeftWidth = 1;
            this.groupOptions_Servers.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupOptions_Servers.Style.BorderRightWidth = 1;
            this.groupOptions_Servers.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupOptions_Servers.Style.BorderTopWidth = 1;
            this.groupOptions_Servers.Style.Class = "";
            this.groupOptions_Servers.Style.CornerDiameter = 4;
            this.groupOptions_Servers.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupOptions_Servers.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupOptions_Servers.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupOptions_Servers.StyleMouseDown.Class = "";
            this.groupOptions_Servers.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupOptions_Servers.StyleMouseOver.Class = "";
            this.groupOptions_Servers.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupOptions_Servers.TabIndex = 1;
            this.groupOptions_Servers.Text = "Specify SQL Servers to check:";
            // 
            // radioServers
            // 
            this.radioServers.AutoSize = true;
            this.radioServers.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioServers.BackgroundStyle.Class = "";
            this.radioServers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioServers.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioServers.Checked = true;
            this.radioServers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioServers.CheckValue = "Y";
            this.radioServers.Location = new System.Drawing.Point(1, 6);
            this.radioServers.Name = "radioServers";
            this.radioServers.Size = new System.Drawing.Size(169, 15);
            this.radioServers.TabIndex = 10;
            this.radioServers.Text = "Check specified SQL Servers:";
            this.radioServers.CheckedChanged += new System.EventHandler(this.radioServers_CheckedChanged);
            // 
            // listServers
            // 
            this.listServers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listServers.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listServers.Border.Class = "ListViewBorder";
            this.listServers.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIcon,
            this.colServer});
            this.listServers.FullRowSelect = true;
            this.listServers.Location = new System.Drawing.Point(21, 26);
            this.listServers.Name = "listServers";
            this.listServers.ShowItemToolTips = true;
            this.listServers.Size = new System.Drawing.Size(195, 57);
            this.listServers.SmallImageList = this.imageList1;
            this.listServers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listServers.TabIndex = 12;
            this.listServers.UseCompatibleStateImageBehavior = false;
            this.listServers.View = System.Windows.Forms.View.Details;
            this.listServers.SelectedIndexChanged += new System.EventHandler(this.listServers_SelectedIndexChanged);
            // 
            // colIcon
            // 
            this.colIcon.Text = "";
            this.colIcon.Width = 20;
            // 
            // colServer
            // 
            this.colServer.Text = "SQL Server";
            this.colServer.Width = 159;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "server_unknown.ico");
            this.imageList1.Images.SetKeyName(1, "server_ok.ico");
            this.imageList1.Images.SetKeyName(2, "server_warning.ico");
            this.imageList1.Images.SetKeyName(3, "server_error.ico");
            this.imageList1.Images.SetKeyName(4, "server.png");
            this.imageList1.Images.SetKeyName(5, "server_id_card.png");
            this.imageList1.Images.SetKeyName(6, "unknown.png");
            this.imageList1.Images.SetKeyName(7, "check2.ico");
            this.imageList1.Images.SetKeyName(8, "warning.ico");
            this.imageList1.Images.SetKeyName(9, "error.ico");
            this.imageList1.Images.SetKeyName(10, "check2_disabled.ico");
            this.imageList1.Images.SetKeyName(11, "warning_disabled.ico");
            this.imageList1.Images.SetKeyName(12, "error_disabled.ico");
            // 
            // buttonAddServer
            // 
            this.buttonAddServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAddServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonAddServer.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddServer.Image")));
            this.buttonAddServer.Location = new System.Drawing.Point(223, 26);
            this.buttonAddServer.Name = "buttonAddServer";
            this.buttonAddServer.Size = new System.Drawing.Size(75, 25);
            this.buttonAddServer.TabIndex = 7;
            this.buttonAddServer.Text = "Add";
            this.buttonAddServer.Click += new System.EventHandler(this.buttonAddServer_Click);
            // 
            // buttonEditServer
            // 
            this.buttonEditServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonEditServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonEditServer.Image = ((System.Drawing.Image)(resources.GetObject("buttonEditServer.Image")));
            this.buttonEditServer.Location = new System.Drawing.Point(223, 58);
            this.buttonEditServer.Name = "buttonEditServer";
            this.buttonEditServer.Size = new System.Drawing.Size(75, 25);
            this.buttonEditServer.TabIndex = 9;
            this.buttonEditServer.Text = "Edit";
            this.buttonEditServer.Click += new System.EventHandler(this.buttonEditServer_Click);
            // 
            // buttonRemoveServer
            // 
            this.buttonRemoveServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonRemoveServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonRemoveServer.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemoveServer.Image")));
            this.buttonRemoveServer.Location = new System.Drawing.Point(223, 89);
            this.buttonRemoveServer.Name = "buttonRemoveServer";
            this.buttonRemoveServer.Size = new System.Drawing.Size(75, 25);
            this.buttonRemoveServer.TabIndex = 8;
            this.buttonRemoveServer.Text = "Remove";
            this.buttonRemoveServer.Click += new System.EventHandler(this.buttonRemoveServer_Click);
            // 
            // radioServerGroup
            // 
            this.radioServerGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioServerGroup.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioServerGroup.BackgroundStyle.Class = "";
            this.radioServerGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioServerGroup.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioServerGroup.Location = new System.Drawing.Point(1, 87);
            this.radioServerGroup.Name = "radioServerGroup";
            this.radioServerGroup.Size = new System.Drawing.Size(233, 20);
            this.radioServerGroup.TabIndex = 11;
            this.radioServerGroup.Text = "Check SQL Servers in the server group:";
            // 
            // comboServerGroup
            // 
            this.comboServerGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboServerGroup.DisplayMember = "Text";
            this.comboServerGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboServerGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboServerGroup.Enabled = false;
            this.comboServerGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboServerGroup.FormattingEnabled = true;
            this.comboServerGroup.ItemHeight = 14;
            this.comboServerGroup.Location = new System.Drawing.Point(21, 108);
            this.comboServerGroup.Name = "comboServerGroup";
            this.comboServerGroup.Size = new System.Drawing.Size(195, 20);
            this.comboServerGroup.TabIndex = 13;
            this.comboServerGroup.DropDown += new System.EventHandler(this.comboServerGroup_DropDown);
            this.comboServerGroup.SelectedIndexChanged += new System.EventHandler(this.comboServerGroup_SelectedIndexChanged);
            // 
            // groupOptions
            // 
            this.groupOptions.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupOptions.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupOptions.Controls.Add(this.checkRunInSystemTray);
            this.groupOptions.Controls.Add(this.checkAlertOnline);
            this.groupOptions.Controls.Add(this.checkRunAtStartup);
            this.groupOptions.Controls.Add(this.checkAlertOffline);
            this.groupOptions.Controls.Add(this.checkAutoRefresh);
            this.groupOptions.Controls.Add(this.checkMinimizeToSystemTray);
            this.groupOptions.Controls.Add(this.labelRefreshInterval2);
            this.groupOptions.Controls.Add(this.textRefreshInterval);
            this.groupOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupOptions.IsShadowEnabled = true;
            this.groupOptions.Location = new System.Drawing.Point(6, 171);
            this.groupOptions.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(307, 160);
            // 
            // 
            // 
            this.groupOptions.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupOptions.Style.BackColorGradientAngle = 90;
            this.groupOptions.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupOptions.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupOptions.Style.BorderBottomWidth = 1;
            this.groupOptions.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupOptions.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupOptions.Style.BorderLeftWidth = 1;
            this.groupOptions.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupOptions.Style.BorderRightWidth = 1;
            this.groupOptions.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupOptions.Style.BorderTopWidth = 1;
            this.groupOptions.Style.Class = "";
            this.groupOptions.Style.CornerDiameter = 4;
            this.groupOptions.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupOptions.Style.PaddingTop = 3;
            this.groupOptions.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupOptions.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupOptions.StyleMouseDown.Class = "";
            this.groupOptions.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupOptions.StyleMouseOver.Class = "";
            this.groupOptions.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupOptions.TabIndex = 0;
            this.groupOptions.Text = "System Tray Options";
            // 
            // checkRunInSystemTray
            // 
            this.checkRunInSystemTray.AutoSize = true;
            this.checkRunInSystemTray.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkRunInSystemTray.BackgroundStyle.Class = "";
            this.checkRunInSystemTray.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkRunInSystemTray.Checked = true;
            this.checkRunInSystemTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkRunInSystemTray.CheckValue = "Y";
            this.checkRunInSystemTray.Location = new System.Drawing.Point(4, 6);
            this.checkRunInSystemTray.Name = "checkRunInSystemTray";
            this.checkRunInSystemTray.Size = new System.Drawing.Size(282, 15);
            this.checkRunInSystemTray.TabIndex = 15;
            this.checkRunInSystemTray.Text = "On Close, keep running as a System Tray application";
            this.checkRunInSystemTray.CheckedChanged += new System.EventHandler(this.checkRunInSystemTray_CheckedChanged);
            // 
            // checkAlertOnline
            // 
            this.checkAlertOnline.AutoSize = true;
            this.checkAlertOnline.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkAlertOnline.BackgroundStyle.Class = "";
            this.checkAlertOnline.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkAlertOnline.Checked = true;
            this.checkAlertOnline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAlertOnline.CheckValue = "Y";
            this.checkAlertOnline.Location = new System.Drawing.Point(4, 50);
            this.checkAlertOnline.Name = "checkAlertOnline";
            this.checkAlertOnline.Size = new System.Drawing.Size(252, 15);
            this.checkAlertOnline.TabIndex = 2;
            this.checkAlertOnline.Text = "Display alert when a SQL Server comes online.";
            this.checkAlertOnline.CheckedChanged += new System.EventHandler(this.checkAlertOnline_CheckedChanged);
            // 
            // checkRunAtStartup
            // 
            this.checkRunAtStartup.AutoSize = true;
            this.checkRunAtStartup.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkRunAtStartup.BackgroundStyle.Class = "";
            this.checkRunAtStartup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkRunAtStartup.Location = new System.Drawing.Point(4, 113);
            this.checkRunAtStartup.Name = "checkRunAtStartup";
            this.checkRunAtStartup.Size = new System.Drawing.Size(139, 15);
            this.checkRunAtStartup.TabIndex = 14;
            this.checkRunAtStartup.Text = "Run at Windows startup";
            this.checkRunAtStartup.CheckedChanged += new System.EventHandler(this.checkRunAtStartup_CheckedChanged);
            // 
            // checkAlertOffline
            // 
            this.checkAlertOffline.AutoSize = true;
            this.checkAlertOffline.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkAlertOffline.BackgroundStyle.Class = "";
            this.checkAlertOffline.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkAlertOffline.Checked = true;
            this.checkAlertOffline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAlertOffline.CheckValue = "Y";
            this.checkAlertOffline.Location = new System.Drawing.Point(4, 71);
            this.checkAlertOffline.Name = "checkAlertOffline";
            this.checkAlertOffline.Size = new System.Drawing.Size(244, 15);
            this.checkAlertOffline.TabIndex = 3;
            this.checkAlertOffline.Text = "Display alert when a SQL Server goes offline.";
            this.checkAlertOffline.CheckedChanged += new System.EventHandler(this.checkAlertOffline_CheckedChanged);
            // 
            // checkAutoRefresh
            // 
            this.checkAutoRefresh.AutoSize = true;
            this.checkAutoRefresh.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkAutoRefresh.BackgroundStyle.Class = "";
            this.checkAutoRefresh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkAutoRefresh.Checked = true;
            this.checkAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoRefresh.CheckValue = "Y";
            this.checkAutoRefresh.Location = new System.Drawing.Point(4, 28);
            this.checkAutoRefresh.Name = "checkAutoRefresh";
            this.checkAutoRefresh.Size = new System.Drawing.Size(164, 15);
            this.checkAutoRefresh.TabIndex = 7;
            this.checkAutoRefresh.Text = "Perform a status check every";
            this.checkAutoRefresh.CheckedChanged += new System.EventHandler(this.checkAutoRefresh_CheckedChanged);
            // 
            // checkMinimizeToSystemTray
            // 
            this.checkMinimizeToSystemTray.AutoSize = true;
            this.checkMinimizeToSystemTray.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkMinimizeToSystemTray.BackgroundStyle.Class = "";
            this.checkMinimizeToSystemTray.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkMinimizeToSystemTray.Location = new System.Drawing.Point(4, 92);
            this.checkMinimizeToSystemTray.Name = "checkMinimizeToSystemTray";
            this.checkMinimizeToSystemTray.Size = new System.Drawing.Size(212, 15);
            this.checkMinimizeToSystemTray.TabIndex = 12;
            this.checkMinimizeToSystemTray.Text = "Remove from task bar when Minimized";
            this.checkMinimizeToSystemTray.CheckedChanged += new System.EventHandler(this.checkMinimizeToSystemTray_CheckedChanged);
            // 
            // labelRefreshInterval2
            // 
            this.labelRefreshInterval2.AutoSize = true;
            this.labelRefreshInterval2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelRefreshInterval2.BackgroundStyle.Class = "";
            this.labelRefreshInterval2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelRefreshInterval2.Location = new System.Drawing.Point(209, 29);
            this.labelRefreshInterval2.Name = "labelRefreshInterval2";
            this.labelRefreshInterval2.Size = new System.Drawing.Size(44, 15);
            this.labelRefreshInterval2.TabIndex = 5;
            this.labelRefreshInterval2.Text = "minutes.";
            // 
            // textRefreshInterval
            // 
            // 
            // 
            // 
            this.textRefreshInterval.Border.Class = "TextBoxBorder";
            this.textRefreshInterval.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textRefreshInterval.Location = new System.Drawing.Point(170, 27);
            this.textRefreshInterval.MaxLength = 4;
            this.textRefreshInterval.Name = "textRefreshInterval";
            this.textRefreshInterval.Size = new System.Drawing.Size(35, 20);
            this.textRefreshInterval.TabIndex = 6;
            this.textRefreshInterval.Text = "10";
            this.textRefreshInterval.Leave += new System.EventHandler(this.textRefreshInterval_Leave);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.Image")));
            this.buttonRefresh.Location = new System.Drawing.Point(402, 7);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(146, 52);
            this.buttonRefresh.TabIndex = 11;
            this.buttonRefresh.Text = "Check Servers Now";
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // groupServers
            // 
            this.groupServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupServers.BackColor = System.Drawing.Color.Transparent;
            this.groupServers.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupServers.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupServers.Controls.Add(this.labelProcessingError);
            this.groupServers.Controls.Add(this.groupStatus);
            this.groupServers.Controls.Add(this.listResults);
            this.groupServers.Controls.Add(this.buttonRefresh);
            this.groupServers.IsShadowEnabled = true;
            this.groupServers.Location = new System.Drawing.Point(6, 6);
            this.groupServers.Name = "groupServers";
            this.groupServers.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupServers.Size = new System.Drawing.Size(561, 301);
            // 
            // 
            // 
            this.groupServers.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupServers.Style.BackColorGradientAngle = 90;
            this.groupServers.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupServers.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupServers.Style.BorderBottomWidth = 1;
            this.groupServers.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupServers.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupServers.Style.BorderLeftWidth = 1;
            this.groupServers.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupServers.Style.BorderRightWidth = 1;
            this.groupServers.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupServers.Style.BorderTopWidth = 1;
            this.groupServers.Style.Class = "";
            this.groupServers.Style.CornerDiameter = 4;
            this.groupServers.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupServers.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupServers.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupServers.StyleMouseDown.Class = "";
            this.groupServers.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupServers.StyleMouseOver.Class = "";
            this.groupServers.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupServers.TabIndex = 6;
            this.groupServers.Text = "Server Status";
            // 
            // labelProcessingError
            // 
            this.labelProcessingError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProcessingError.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelProcessingError.BackgroundStyle.Class = "";
            this.labelProcessingError.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelProcessingError.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProcessingError.ForeColor = System.Drawing.Color.Red;
            this.labelProcessingError.Location = new System.Drawing.Point(13, 97);
            this.labelProcessingError.Name = "labelProcessingError";
            this.labelProcessingError.Size = new System.Drawing.Size(526, 79);
            this.labelProcessingError.TabIndex = 28;
            this.labelProcessingError.Text = "No data available";
            this.labelProcessingError.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelProcessingError.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.labelProcessingError.Visible = false;
            this.labelProcessingError.WordWrap = true;
            // 
            // groupStatus
            // 
            this.groupStatus.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupStatus.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupStatus.Controls.Add(this.pictureOverallStatus);
            this.groupStatus.Controls.Add(this.labelOverallStatus);
            this.groupStatus.DrawTitleBox = false;
            this.groupStatus.Location = new System.Drawing.Point(5, 7);
            this.groupStatus.Name = "groupStatus";
            this.groupStatus.Size = new System.Drawing.Size(230, 50);
            // 
            // 
            // 
            this.groupStatus.Style.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupStatus.Style.BackColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.groupStatus.Style.BackColorGradientAngle = 90;
            this.groupStatus.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupStatus.Style.BorderBottomWidth = 1;
            this.groupStatus.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupStatus.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupStatus.Style.BorderLeftWidth = 1;
            this.groupStatus.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupStatus.Style.BorderRightWidth = 1;
            this.groupStatus.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupStatus.Style.BorderTopWidth = 1;
            this.groupStatus.Style.Class = "";
            this.groupStatus.Style.CornerDiameter = 4;
            this.groupStatus.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupStatus.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupStatus.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupStatus.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupStatus.StyleMouseDown.Class = "";
            this.groupStatus.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupStatus.StyleMouseOver.Class = "";
            this.groupStatus.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupStatus.TabIndex = 14;
            // 
            // pictureOverallStatus
            // 
            this.pictureOverallStatus.BackColor = System.Drawing.Color.Transparent;
            this.pictureOverallStatus.Image = ((System.Drawing.Image)(resources.GetObject("pictureOverallStatus.Image")));
            this.pictureOverallStatus.Location = new System.Drawing.Point(5, 6);
            this.pictureOverallStatus.Name = "pictureOverallStatus";
            this.pictureOverallStatus.Size = new System.Drawing.Size(32, 32);
            this.pictureOverallStatus.TabIndex = 50;
            this.pictureOverallStatus.TabStop = false;
            // 
            // labelOverallStatus
            // 
            this.labelOverallStatus.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelOverallStatus.BackgroundStyle.Class = "";
            this.labelOverallStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelOverallStatus.Location = new System.Drawing.Point(43, 6);
            this.labelOverallStatus.Name = "labelOverallStatus";
            this.labelOverallStatus.Size = new System.Drawing.Size(178, 32);
            this.labelOverallStatus.TabIndex = 51;
            this.labelOverallStatus.Text = "Unknown Status (Run check)";
            this.labelOverallStatus.WordWrap = true;
            // 
            // listResults
            // 
            this.listResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.listResults.Border.Class = "ListViewBorder";
            this.listResults.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnIcon,
            this.columnServer,
            this.columnStatus,
            this.columnIgnore,
            this.columnError});
            this.listResults.ContextMenuStrip = this.contextMenuResults;
            this.listResults.FullRowSelect = true;
            this.listResults.Location = new System.Drawing.Point(5, 65);
            this.listResults.MultiSelect = false;
            this.listResults.Name = "listResults";
            this.listResults.Size = new System.Drawing.Size(543, 211);
            this.listResults.SmallImageList = this.imageList1;
            this.listResults.TabIndex = 13;
            this.listResults.UseCompatibleStateImageBehavior = false;
            this.listResults.View = System.Windows.Forms.View.Details;
            this.listResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listResults_ColumnClick);
            this.listResults.SelectedIndexChanged += new System.EventHandler(this.listResults_SelectedIndexChanged);
            // 
            // columnIcon
            // 
            this.columnIcon.Text = "";
            this.columnIcon.Width = 20;
            // 
            // columnServer
            // 
            this.columnServer.Text = "SQL Server";
            this.columnServer.Width = 120;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 75;
            // 
            // columnIgnore
            // 
            this.columnIgnore.Text = "Ignore";
            this.columnIgnore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnIgnore.Width = 50;
            // 
            // columnError
            // 
            this.columnError.Text = "Details";
            this.columnError.Width = 230;
            // 
            // contextMenuResults
            // 
            this.contextMenuResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuIgnoreServer,
            this.toolStripSeparator3,
            this.contextMenuStartServer,
            this.contextMenuStopServer,
            this.contextMenuPauseServer,
            this.contextMenuResumeServer,
            this.contextMenuRestartServer,
            this.toolStripSeparator2,
            this.toolStripMenuItem8,
            this.contextCopy});
            this.contextMenuResults.Name = "contextMenuStrip1";
            this.contextMenuResults.Size = new System.Drawing.Size(316, 192);
            // 
            // contextMenuIgnoreServer
            // 
            this.contextMenuIgnoreServer.Enabled = false;
            this.contextMenuIgnoreServer.Name = "contextMenuIgnoreServer";
            this.contextMenuIgnoreServer.Size = new System.Drawing.Size(315, 22);
            this.contextMenuIgnoreServer.Text = "Ignore Server for Alerts and Status Calculation";
            this.contextMenuIgnoreServer.Click += new System.EventHandler(this.contextMenuIgnoreServer_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(312, 6);
            // 
            // contextMenuStartServer
            // 
            this.contextMenuStartServer.Enabled = false;
            this.contextMenuStartServer.Name = "contextMenuStartServer";
            this.contextMenuStartServer.Size = new System.Drawing.Size(315, 22);
            this.contextMenuStartServer.Text = "Start";
            this.contextMenuStartServer.Click += new System.EventHandler(this.contextMenuStartServer_Click);
            // 
            // contextMenuStopServer
            // 
            this.contextMenuStopServer.Enabled = false;
            this.contextMenuStopServer.Name = "contextMenuStopServer";
            this.contextMenuStopServer.Size = new System.Drawing.Size(315, 22);
            this.contextMenuStopServer.Text = "Stop";
            this.contextMenuStopServer.Click += new System.EventHandler(this.contextMenuStopServer_Click);
            // 
            // contextMenuPauseServer
            // 
            this.contextMenuPauseServer.Enabled = false;
            this.contextMenuPauseServer.Name = "contextMenuPauseServer";
            this.contextMenuPauseServer.Size = new System.Drawing.Size(315, 22);
            this.contextMenuPauseServer.Text = "Pause";
            this.contextMenuPauseServer.Click += new System.EventHandler(this.contextMenuPauseServer_Click);
            // 
            // contextMenuResumeServer
            // 
            this.contextMenuResumeServer.Enabled = false;
            this.contextMenuResumeServer.Name = "contextMenuResumeServer";
            this.contextMenuResumeServer.Size = new System.Drawing.Size(315, 22);
            this.contextMenuResumeServer.Text = "Resume";
            this.contextMenuResumeServer.Click += new System.EventHandler(this.contextMenuResumeServer_Click);
            // 
            // contextMenuRestartServer
            // 
            this.contextMenuRestartServer.Enabled = false;
            this.contextMenuRestartServer.Name = "contextMenuRestartServer";
            this.contextMenuRestartServer.Size = new System.Drawing.Size(315, 22);
            this.contextMenuRestartServer.Text = "Restart";
            this.contextMenuRestartServer.Click += new System.EventHandler(this.contextMenuRestartServer_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(312, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(315, 22);
            this.toolStripMenuItem8.Text = "Refresh Status";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.contextMenuRefresh_Click);
            // 
            // contextCopy
            // 
            this.contextCopy.Name = "contextCopy";
            this.contextCopy.Size = new System.Drawing.Size(315, 22);
            this.contextCopy.Text = "&Copy";
            this.contextCopy.Click += new System.EventHandler(this.contextCopy_Click);
            // 
            // contextMenuList
            // 
            this.contextMenuList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuAddServer,
            this.contextgMenuEditServer,
            this.contextMenuRemoveServer,
            this.toolStripMenuItem7,
            this.contextMenuCopy,
            this.toolStripSeparator1,
            this.contextMenuRefresh});
            this.contextMenuList.Name = "contextMenuList";
            this.contextMenuList.Size = new System.Drawing.Size(153, 126);
            // 
            // contextMenuAddServer
            // 
            this.contextMenuAddServer.Name = "contextMenuAddServer";
            this.contextMenuAddServer.Size = new System.Drawing.Size(152, 22);
            this.contextMenuAddServer.Text = "Add Server";
            this.contextMenuAddServer.Click += new System.EventHandler(this.contextMenuAddServer_Click);
            // 
            // contextgMenuEditServer
            // 
            this.contextgMenuEditServer.Name = "contextgMenuEditServer";
            this.contextgMenuEditServer.Size = new System.Drawing.Size(152, 22);
            this.contextgMenuEditServer.Text = "Edit Server";
            // 
            // contextMenuRemoveServer
            // 
            this.contextMenuRemoveServer.Name = "contextMenuRemoveServer";
            this.contextMenuRemoveServer.Size = new System.Drawing.Size(152, 22);
            this.contextMenuRemoveServer.Text = "Remove Server";
            this.contextMenuRemoveServer.Click += new System.EventHandler(this.contextMenuRemoveServer_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(149, 6);
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.Size = new System.Drawing.Size(152, 22);
            this.contextMenuCopy.Text = "Copy";
            this.contextMenuCopy.Click += new System.EventHandler(this.contextMenuCopy_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // contextMenuRefresh
            // 
            this.contextMenuRefresh.Name = "contextMenuRefresh";
            this.contextMenuRefresh.Size = new System.Drawing.Size(152, 22);
            this.contextMenuRefresh.Text = "Refresh";
            this.contextMenuRefresh.Click += new System.EventHandler(this.contextMenuRefresh_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Controls.Add(this.labelSubtitle);
            this.panelTop.Controls.Add(this.pictureBoxTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 117);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(892, 52);
            this.panelTop.TabIndex = 16;
            // 
            // labelTitle
            // 
            // 
            // 
            // 
            this.labelTitle.BackgroundStyle.Class = "";
            this.labelTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTitle.Location = new System.Drawing.Point(59, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(270, 52);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.TabStop = false;
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Server Ping</font></b> ";
            // 
            // labelSubtitle
            // 
            // 
            // 
            // 
            this.labelSubtitle.BackgroundStyle.Class = "";
            this.labelSubtitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.Location = new System.Drawing.Point(330, 0);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(398, 52);
            this.labelSubtitle.TabIndex = 6;
            this.labelSubtitle.Text = "Continuously monitor the status and availability of your SQL Servers";
            // 
            // pictureBoxTitle
            // 
            this.pictureBoxTitle.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTitle.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTitle.Image")));
            this.pictureBoxTitle.Location = new System.Drawing.Point(5, 2);
            this.pictureBoxTitle.Name = "pictureBoxTitle";
            this.pictureBoxTitle.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxTitle.TabIndex = 0;
            this.pictureBoxTitle.TabStop = false;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.White;
            this.panelBottom.Controls.Add(this.labelMethod);
            this.panelBottom.Controls.Add(this.labelLastCheckTime);
            this.panelBottom.Controls.Add(this.groupServers);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(319, 169);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.panelBottom.Size = new System.Drawing.Size(573, 337);
            this.panelBottom.TabIndex = 17;
            // 
            // labelMethod
            // 
            this.labelMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMethod.AutoSize = true;
            this.labelMethod.LinkArea = new System.Windows.Forms.LinkArea(21, 17);
            this.labelMethod.Location = new System.Drawing.Point(6, 315);
            this.labelMethod.Name = "labelMethod";
            this.labelMethod.Size = new System.Drawing.Size(200, 17);
            this.labelMethod.TabIndex = 9;
            this.labelMethod.TabStop = true;
            this.labelMethod.Text = "Server check method: SQL Connection";
            this.labelMethod.UseCompatibleTextRendering = true;
            this.labelMethod.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelMethod_LinkClicked);
            // 
            // labelLastCheckTime
            // 
            this.labelLastCheckTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLastCheckTime.AutoSize = true;
            // 
            // 
            // 
            this.labelLastCheckTime.BackgroundStyle.Class = "";
            this.labelLastCheckTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelLastCheckTime.Location = new System.Drawing.Point(391, 314);
            this.labelLastCheckTime.Name = "labelLastCheckTime";
            this.labelLastCheckTime.Size = new System.Drawing.Size(169, 15);
            this.labelLastCheckTime.TabIndex = 8;
            this.labelLastCheckTime.Text = "Last check: 12/13/2008  10:13 AM";
            this.labelLastCheckTime.WordWrap = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.editToolStripMenuItem,
            this.menuTools,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 93);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(892, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExitToLaunchpad,
            this.menuFileExit,
            this.toolStripMenuItem9,
            this.menuReallyExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuExitToLaunchpad
            // 
            this.menuExitToLaunchpad.Name = "menuExitToLaunchpad";
            this.menuExitToLaunchpad.Size = new System.Drawing.Size(214, 22);
            this.menuExitToLaunchpad.Text = "Close and start &Launchpad";
            this.menuExitToLaunchpad.Click += new System.EventHandler(this.menuExitToLaunchpad_Click);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(214, 22);
            this.menuFileExit.Text = "&Close";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(211, 6);
            // 
            // menuReallyExit
            // 
            this.menuReallyExit.Name = "menuReallyExit";
            this.menuReallyExit.Size = new System.Drawing.Size(214, 22);
            this.menuReallyExit.Text = "&Exit";
            this.menuReallyExit.Click += new System.EventHandler(this.menuReallyExit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopy,
            this.menuRefresh});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // menuCopy
            // 
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Size = new System.Drawing.Size(148, 22);
            this.menuCopy.Text = "&Copy";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuRefresh
            // 
            this.menuRefresh.Name = "menuRefresh";
            this.menuRefresh.Size = new System.Drawing.Size(148, 22);
            this.menuRefresh.Text = "&Refresh Status";
            this.menuRefresh.Click += new System.EventHandler(this.menuRefresh_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHealthCheckOptions,
            this.toolStripMenuItem6,
            this.menuManageServerGroups,
            this.menuToolsetOptions,
            this.toolStripMenuItem4,
            this.menuLaunchpad});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(48, 20);
            this.menuTools.Text = "&Tools";
            // 
            // menuHealthCheckOptions
            // 
            this.menuHealthCheckOptions.Name = "menuHealthCheckOptions";
            this.menuHealthCheckOptions.Size = new System.Drawing.Size(233, 22);
            this.menuHealthCheckOptions.Text = "Server Ping Options...";
            this.menuHealthCheckOptions.Click += new System.EventHandler(this.menuHealthCheckOptions_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(230, 6);
            // 
            // menuManageServerGroups
            // 
            this.menuManageServerGroups.Name = "menuManageServerGroups";
            this.menuManageServerGroups.Size = new System.Drawing.Size(233, 22);
            this.menuManageServerGroups.Text = "Manage Server Groups...";
            this.menuManageServerGroups.Click += new System.EventHandler(this.menuManageServerGroups_Click);
            // 
            // menuToolsetOptions
            // 
            this.menuToolsetOptions.Name = "menuToolsetOptions";
            this.menuToolsetOptions.Size = new System.Drawing.Size(233, 22);
            this.menuToolsetOptions.Text = "SQL admin toolset &Options...";
            this.menuToolsetOptions.Click += new System.EventHandler(this.menuToolsetOptions_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(230, 6);
            // 
            // menuLaunchpad
            // 
            this.menuLaunchpad.Name = "menuLaunchpad";
            this.menuLaunchpad.Size = new System.Drawing.Size(233, 22);
            this.menuLaunchpad.Text = "SQL admin toolset &Launchpad";
            this.menuLaunchpad.Click += new System.EventHandler(this.menuLaunchpad_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowHelp,
            this.menuContactTechnicalSupport,
            this.toolStripMenuItem2,
            this.menuDeactivateLicense,
            this.menuCheckForUpdates,
            this.toolStripMenuItem1,
            this.menuAboutIderaProducts,
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 20);
            this.menuHelp.Text = "&Help";
            this.menuHelp.Click += new System.EventHandler(this.menuHelp_Click);
            // 
            // menuShowHelp
            // 
            this.menuShowHelp.Name = "menuShowHelp";
            this.menuShowHelp.Size = new System.Drawing.Size(216, 22);
            this.menuShowHelp.Text = "Show &Help";
            this.menuShowHelp.Click += new System.EventHandler(this.menuShowHelp_Click);
            // 
            // menuContactTechnicalSupport
            // 
            this.menuContactTechnicalSupport.Name = "menuContactTechnicalSupport";
            this.menuContactTechnicalSupport.Size = new System.Drawing.Size(216, 22);
            this.menuContactTechnicalSupport.Text = "SQL admin toolset &Support";
            this.menuContactTechnicalSupport.Click += new System.EventHandler(this.menuContactTechnicalSupport_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(213, 6);
            // 
            // menuDeactivateLicense
            // 
            this.menuDeactivateLicense.Name = "menuDeactivateLicense";
            this.menuDeactivateLicense.Size = new System.Drawing.Size(216, 22);
            this.menuDeactivateLicense.Text = "Manage &License";
            this.menuDeactivateLicense.Click += new System.EventHandler(this.menuDeactivateLicense_Click);
            // 
            // menuCheckForUpdates
            // 
            this.menuCheckForUpdates.Name = "menuCheckForUpdates";
            this.menuCheckForUpdates.Size = new System.Drawing.Size(216, 22);
            this.menuCheckForUpdates.Text = "Check For &Updates";
            this.menuCheckForUpdates.Click += new System.EventHandler(this.menuCheckForUpdates_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(213, 6);
            // 
            // menuAboutIderaProducts
            // 
            this.menuAboutIderaProducts.Name = "menuAboutIderaProducts";
            this.menuAboutIderaProducts.Size = new System.Drawing.Size(216, 22);
            this.menuAboutIderaProducts.Text = "About Idera &Products";
            this.menuAboutIderaProducts.Click += new System.EventHandler(this.menuAboutIderaProducts_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(216, 22);
            this.menuAbout.Text = "&About Server Ping";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuNotify;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Idera Server Ping";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuNotify
            // 
            this.contextMenuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuRefreshStatus,
            this.toolStripMenuItem5,
            this.menuOpenHealthCheck,
            this.contextMenuExit});
            this.contextMenuNotify.Name = "contextMenuStrip1";
            this.contextMenuNotify.Size = new System.Drawing.Size(166, 76);
            // 
            // ContextMenuRefreshStatus
            // 
            this.ContextMenuRefreshStatus.Name = "ContextMenuRefreshStatus";
            this.ContextMenuRefreshStatus.Size = new System.Drawing.Size(165, 22);
            this.ContextMenuRefreshStatus.Text = "Refresh Status";
            this.ContextMenuRefreshStatus.Click += new System.EventHandler(this.contextMenuRefresh_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(162, 6);
            // 
            // menuOpenHealthCheck
            // 
            this.menuOpenHealthCheck.Name = "menuOpenHealthCheck";
            this.menuOpenHealthCheck.Size = new System.Drawing.Size(165, 22);
            this.menuOpenHealthCheck.Text = "Open Server Ping";
            this.menuOpenHealthCheck.Click += new System.EventHandler(this.menuOpenHealthCheck_Click);
            // 
            // contextMenuExit
            // 
            this.contextMenuExit.Name = "contextMenuExit";
            this.contextMenuExit.Size = new System.Drawing.Size(165, 22);
            this.contextMenuExit.Text = "Exit";
            this.contextMenuExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // imageListBig
            // 
            this.imageListBig.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBig.ImageStream")));
            this.imageListBig.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListBig.Images.SetKeyName(0, "unknown.png");
            this.imageListBig.Images.SetKeyName(1, "check2.png");
            this.imageListBig.Images.SetKeyName(2, "warning.png");
            this.imageListBig.Images.SetKeyName(3, "error.png");
            // 
            // timerAutoRefresh
            // 
            this.timerAutoRefresh.Interval = 600000;
            this.timerAutoRefresh.Tick += new System.EventHandler(this.timerAutoRefresh_Tick);
            // 
            // timerCheckShow
            // 
            this.timerCheckShow.Interval = 1000;
            this.timerCheckShow.Tick += new System.EventHandler(this.timerCheckShow_Tick);
            // 
            // ideraTitleBar1
            // 
            this.ideraTitleBar1.ActivateLicenseEventHandler = null;
            this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
            this.ideraTitleBar1.Close = true;
            this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
            this.ideraTitleBar1.IderaProductNameText = "SQL Server Ping";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = true;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(892, 93);
            this.ideraTitleBar1.TabIndex = 19;
            this.ideraTitleBar1.TrialMode = true;
            this.ideraTitleBar1.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar1_LicenseInfoButtonClick);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(892, 506);
            this.ControlBox = false;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ideraTitleBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(710, 500);
            this.Name = "Form_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
            this.Resize += new System.EventHandler(this.Form_Main_Resize);
            this.panelMiddle.ResumeLayout(false);
            this.groupOptions_Servers.ResumeLayout(false);
            this.groupOptions_Servers.PerformLayout();
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            this.groupServers.ResumeLayout(false);
            this.groupStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureOverallStatus)).EndInit();
            this.contextMenuResults.ResumeLayout(false);
            this.contextMenuList.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuNotify.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panelMiddle;
      private DevComponents.DotNetBar.Controls.GroupPanel groupOptions;
      private DevComponents.DotNetBar.Controls.GroupPanel groupServers;
      private System.Windows.Forms.Panel panelTop;
      private DevComponents.DotNetBar.LabelX labelTitle;
      private DevComponents.DotNetBar.LabelX labelSubtitle;
      private System.Windows.Forms.PictureBox pictureBoxTitle;
      private System.Windows.Forms.Panel panelBottom;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem menuFile;
      private System.Windows.Forms.ToolStripMenuItem menuExitToLaunchpad;
      private System.Windows.Forms.ToolStripMenuItem menuFileExit;
      private System.Windows.Forms.ToolStripMenuItem menuTools;
      private System.Windows.Forms.ToolStripMenuItem menuToolsetOptions;
      private System.Windows.Forms.ToolStripMenuItem menuLaunchpad;
      private System.Windows.Forms.ToolStripMenuItem menuHelp;
      private System.Windows.Forms.ToolStripMenuItem menuShowHelp;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem menuAboutIderaProducts;
      private System.Windows.Forms.ToolStripMenuItem menuContactTechnicalSupport;
      private System.Windows.Forms.ToolStripMenuItem menuDeactivateLicense;
      private System.Windows.Forms.ToolStripMenuItem menuCheckForUpdates;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem menuAbout;
      private System.Windows.Forms.ToolStripMenuItem menuManageServerGroups;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
      private System.Windows.Forms.NotifyIcon notifyIcon1;
      private System.Windows.Forms.ContextMenuStrip contextMenuNotify;
      private System.Windows.Forms.ToolStripMenuItem menuOpenHealthCheck;
      private System.Windows.Forms.ImageList imageList1;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
       private System.Windows.Forms.ToolStripMenuItem contextMenuExit;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkAlertOffline;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkAlertOnline;
      private Idera.SqlAdminToolset.Core.ToolNumericTextBox textRefreshInterval;
      private DevComponents.DotNetBar.LabelX labelRefreshInterval2;
      private System.Windows.Forms.ToolStripMenuItem ContextMenuRefreshStatus;
      private DevComponents.DotNetBar.ButtonX buttonRefresh;
      private DevComponents.DotNetBar.ButtonX buttonEditServer;
      private DevComponents.DotNetBar.ButtonX buttonRemoveServer;
      private DevComponents.DotNetBar.ButtonX buttonAddServer;
      private DevComponents.DotNetBar.LabelX labelLastCheckTime;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkAutoRefresh;
      private System.Windows.Forms.ContextMenuStrip contextMenuList;
      private System.Windows.Forms.ToolStripMenuItem contextMenuCopy;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem contextMenuRefresh;
      private System.Windows.Forms.ToolStripMenuItem contextMenuAddServer;
      private System.Windows.Forms.ToolStripMenuItem contextMenuRemoveServer;
      private System.Windows.Forms.ToolStripMenuItem contextgMenuEditServer;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
      private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem menuCopy;
      private System.Windows.Forms.ToolStripMenuItem menuRefresh;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkMinimizeToSystemTray;
      private DevComponents.DotNetBar.Controls.GroupPanel groupOptions_Servers;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioServerGroup;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioServers;
      private DevComponents.DotNetBar.Controls.ComboBoxEx comboServerGroup;
      private DevComponents.DotNetBar.Controls.ListViewEx listServers;
      private System.Windows.Forms.ColumnHeader colIcon;
      private System.Windows.Forms.ColumnHeader colServer;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkRunAtStartup;
      private System.Windows.Forms.ToolStripMenuItem menuHealthCheckOptions;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
      private System.Windows.Forms.LinkLabel labelMethod;
      private DevComponents.DotNetBar.Controls.ListViewEx listResults;
      private System.Windows.Forms.ColumnHeader columnIcon;
      private System.Windows.Forms.ColumnHeader columnServer;
      private System.Windows.Forms.ColumnHeader columnStatus;
      private System.Windows.Forms.ColumnHeader columnIgnore;
      private System.Windows.Forms.ColumnHeader columnError;
      private System.Windows.Forms.ContextMenuStrip contextMenuResults;
      private System.Windows.Forms.ToolStripMenuItem contextMenuIgnoreServer;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
      private DevComponents.DotNetBar.Controls.GroupPanel groupStatus;
      private System.Windows.Forms.PictureBox pictureOverallStatus;
      private DevComponents.DotNetBar.LabelX labelOverallStatus;
      private System.Windows.Forms.ImageList imageListBig;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkRunInSystemTray;
      private DevComponents.DotNetBar.LabelX labelProcessingError;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
      private System.Windows.Forms.ToolStripMenuItem menuReallyExit;
      private System.Windows.Forms.Timer timerAutoRefresh;
       private System.Windows.Forms.Timer timerCheckShow;
       private System.Windows.Forms.ToolStripMenuItem contextCopy;
       private System.Windows.Forms.ToolStripMenuItem contextMenuStartServer;
       private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
       private System.Windows.Forms.ToolStripMenuItem contextMenuStopServer;
       private System.Windows.Forms.ToolStripMenuItem contextMenuPauseServer;
       private System.Windows.Forms.ToolStripMenuItem contextMenuResumeServer;
       private System.Windows.Forms.ToolStripMenuItem contextMenuRestartServer;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
    }
}

