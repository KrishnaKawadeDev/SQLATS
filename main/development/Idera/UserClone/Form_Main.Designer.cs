namespace Idera.SqlAdminToolset.UserClone
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
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
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
			this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
			this.buttonCreate2005Script = new DevComponents.DotNetBar.ButtonX();
			this.buttonCreate2000Script = new DevComponents.DotNetBar.ButtonX();
			this.groupPanel6 = new DevComponents.DotNetBar.Controls.GroupPanel();
			this.checkIncludeSchemaOwnership = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.labelX6 = new DevComponents.DotNetBar.LabelX();
			this.checkSpecifyPassword = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.labelX4 = new DevComponents.DotNetBar.LabelX();
			this.linkViewDatabases = new System.Windows.Forms.LinkLabel();
			this.textConfirmPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.checkEnableLogin = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.textPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.checkIncludeDatabaseAccess = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.checkIncludeObjectPermissions = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.labelX2 = new DevComponents.DotNetBar.LabelX();
			this.textDestinationUserName = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.listDefaultDatabase = new DevComponents.DotNetBar.Controls.ComboBoxEx();
			this.labelX5 = new DevComponents.DotNetBar.LabelX();
			this.ServerSelectionDestination = new Idera.SqlAdminToolset.Core.Controls.ToolServerSelectionNoMru();
			this.buttonCloneUser = new DevComponents.DotNetBar.ButtonX();
			this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
			this.textSourceUser = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.ServerSelectionSource = new Idera.SqlAdminToolset.Core.Controls.ToolServerSelectionNoMru();
			this.labelX1 = new DevComponents.DotNetBar.LabelX();
			this.panelTop = new System.Windows.Forms.Panel();
			this.labelTitle = new DevComponents.DotNetBar.LabelX();
			this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
			this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
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
			this.panelBottom = new System.Windows.Forms.Panel();
			this.groupResults = new DevComponents.DotNetBar.Controls.GroupPanel();
			this.Progress = new Idera.SqlAdminToolset.Core.Controls.ToolProgress();
			this.buttonCopy = new DevComponents.DotNetBar.ButtonX();
			this.buttonSave = new DevComponents.DotNetBar.ButtonX();
			this.textScript = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.labelX7 = new DevComponents.DotNetBar.LabelX();
			this.PreviewWorker = new System.ComponentModel.BackgroundWorker();
			this.CloningWorker = new System.ComponentModel.BackgroundWorker();
			this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
			this.panelMiddle.SuspendLayout();
			this.groupPanel1.SuspendLayout();
			this.groupPanel6.SuspendLayout();
			this.groupPanel5.SuspendLayout();
			this.panelTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.panelBottom.SuspendLayout();
			this.groupResults.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelMiddle
			// 
			this.panelMiddle.Controls.Add(this.groupPanel1);
			this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelMiddle.Location = new System.Drawing.Point(0, 169);
			this.panelMiddle.Name = "panelMiddle";
			this.panelMiddle.Padding = new System.Windows.Forms.Padding(6);
			this.panelMiddle.Size = new System.Drawing.Size(868, 328);
			this.panelMiddle.TabIndex = 14;
			// 
			// groupPanel1
			// 
			this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.groupPanel1.Controls.Add(this.buttonCreate2005Script);
			this.groupPanel1.Controls.Add(this.buttonCreate2000Script);
			this.groupPanel1.Controls.Add(this.groupPanel6);
			this.groupPanel1.Controls.Add(this.buttonCloneUser);
			this.groupPanel1.Controls.Add(this.groupPanel5);
			this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupPanel1.IsShadowEnabled = true;
			this.groupPanel1.Location = new System.Drawing.Point(6, 6);
			this.groupPanel1.Name = "groupPanel1";
			this.groupPanel1.Size = new System.Drawing.Size(856, 316);
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
			this.groupPanel1.Style.Class = "";
			this.groupPanel1.Style.CornerDiameter = 4;
			this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
			this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
			// 
			// 
			// 
			this.groupPanel1.StyleMouseDown.Class = "";
			this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			// 
			// 
			// 
			this.groupPanel1.StyleMouseOver.Class = "";
			this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.groupPanel1.TabIndex = 0;
			// 
			// buttonCreate2005Script
			// 
			this.buttonCreate2005Script.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonCreate2005Script.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonCreate2005Script.Image = ((System.Drawing.Image)(resources.GetObject("buttonCreate2005Script.Image")));
			this.buttonCreate2005Script.Location = new System.Drawing.Point(568, 265);
			this.buttonCreate2005Script.Name = "buttonCreate2005Script";
			this.buttonCreate2005Script.Size = new System.Drawing.Size(275, 41);
			this.buttonCreate2005Script.TabIndex = 26;
			this.buttonCreate2005Script.Text = "Create &SQL Script for SQL Server 2005 and Up";
			this.buttonCreate2005Script.Click += new System.EventHandler(this.buttonCreate2005Script_Click);
			// 
			// buttonCreate2000Script
			// 
			this.buttonCreate2000Script.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonCreate2000Script.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonCreate2000Script.Image = ((System.Drawing.Image)(resources.GetObject("buttonCreate2000Script.Image")));
			this.buttonCreate2000Script.Location = new System.Drawing.Point(286, 265);
			this.buttonCreate2000Script.Name = "buttonCreate2000Script";
			this.buttonCreate2000Script.Size = new System.Drawing.Size(275, 41);
			this.buttonCreate2000Script.TabIndex = 25;
			this.buttonCreate2000Script.Text = "&Create SQL Script for SQL Server 2000";
			this.buttonCreate2000Script.Click += new System.EventHandler(this.buttonCreate2000Script_Click);
			// 
			// groupPanel6
			// 
			this.groupPanel6.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel6.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.groupPanel6.Controls.Add(this.checkIncludeSchemaOwnership);
			this.groupPanel6.Controls.Add(this.labelX6);
			this.groupPanel6.Controls.Add(this.checkSpecifyPassword);
			this.groupPanel6.Controls.Add(this.labelX4);
			this.groupPanel6.Controls.Add(this.linkViewDatabases);
			this.groupPanel6.Controls.Add(this.textConfirmPassword);
			this.groupPanel6.Controls.Add(this.checkEnableLogin);
			this.groupPanel6.Controls.Add(this.textPassword);
			this.groupPanel6.Controls.Add(this.checkIncludeDatabaseAccess);
			this.groupPanel6.Controls.Add(this.checkIncludeObjectPermissions);
			this.groupPanel6.Controls.Add(this.labelX2);
			this.groupPanel6.Controls.Add(this.textDestinationUserName);
			this.groupPanel6.Controls.Add(this.listDefaultDatabase);
			this.groupPanel6.Controls.Add(this.labelX5);
			this.groupPanel6.Controls.Add(this.ServerSelectionDestination);
			this.groupPanel6.Location = new System.Drawing.Point(4, 88);
			this.groupPanel6.Name = "groupPanel6";
			this.groupPanel6.Size = new System.Drawing.Size(841, 171);
			// 
			// 
			// 
			this.groupPanel6.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.groupPanel6.Style.BackColorGradientAngle = 90;
			this.groupPanel6.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.groupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.groupPanel6.Style.BorderBottomWidth = 1;
			this.groupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.groupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.groupPanel6.Style.BorderLeftWidth = 1;
			this.groupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.groupPanel6.Style.BorderRightWidth = 1;
			this.groupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.groupPanel6.Style.BorderTopWidth = 1;
			this.groupPanel6.Style.Class = "";
			this.groupPanel6.Style.CornerDiameter = 4;
			this.groupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
			this.groupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.groupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
			// 
			// 
			// 
			this.groupPanel6.StyleMouseDown.Class = "";
			this.groupPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			// 
			// 
			// 
			this.groupPanel6.StyleMouseOver.Class = "";
			this.groupPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.groupPanel6.TabIndex = 6;
			this.groupPanel6.Text = "New User";
			// 
			// checkIncludeSchemaOwnership
			// 
			this.checkIncludeSchemaOwnership.AutoSize = true;
			this.checkIncludeSchemaOwnership.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.checkIncludeSchemaOwnership.BackgroundStyle.Class = "";
			this.checkIncludeSchemaOwnership.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.checkIncludeSchemaOwnership.Location = new System.Drawing.Point(528, 105);
			this.checkIncludeSchemaOwnership.Name = "checkIncludeSchemaOwnership";
			this.checkIncludeSchemaOwnership.Size = new System.Drawing.Size(266, 15);
			this.checkIncludeSchemaOwnership.TabIndex = 24;
			this.checkIncludeSchemaOwnership.Text = "Include schema ownership (SQL 2005 and above)";
			this.checkIncludeSchemaOwnership.CheckedChanged += new System.EventHandler(this.checkIncludeSchemaOwnership_CheckedChanged);
			// 
			// labelX6
			// 
			this.labelX6.AutoSize = true;
			this.labelX6.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX6.BackgroundStyle.Class = "";
			this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX6.Location = new System.Drawing.Point(8, 11);
			this.labelX6.Name = "labelX6";
			this.labelX6.Size = new System.Drawing.Size(63, 15);
			this.labelX6.TabIndex = 7;
			this.labelX6.Text = "SQL Server:";
			// 
			// checkSpecifyPassword
			// 
			this.checkSpecifyPassword.AutoSize = true;
			this.checkSpecifyPassword.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.checkSpecifyPassword.BackgroundStyle.Class = "";
			this.checkSpecifyPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.checkSpecifyPassword.Location = new System.Drawing.Point(511, 9);
			this.checkSpecifyPassword.Name = "checkSpecifyPassword";
			this.checkSpecifyPassword.Size = new System.Drawing.Size(135, 15);
			this.checkSpecifyPassword.TabIndex = 15;
			this.checkSpecifyPassword.Text = "Specify new password:";
			this.checkSpecifyPassword.CheckedChanged += new System.EventHandler(this.checkSpecifyPassword_CheckedChanged);
			// 
			// labelX4
			// 
			this.labelX4.AutoSize = true;
			this.labelX4.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX4.BackgroundStyle.Class = "";
			this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX4.Location = new System.Drawing.Point(531, 34);
			this.labelX4.Name = "labelX4";
			this.labelX4.Size = new System.Drawing.Size(95, 15);
			this.labelX4.TabIndex = 17;
			this.labelX4.Text = "Confirm Password:";
			// 
			// linkViewDatabases
			// 
			this.linkViewDatabases.AutoSize = true;
			this.linkViewDatabases.Location = new System.Drawing.Point(656, 61);
			this.linkViewDatabases.Name = "linkViewDatabases";
			this.linkViewDatabases.Size = new System.Drawing.Size(91, 13);
			this.linkViewDatabases.TabIndex = 21;
			this.linkViewDatabases.TabStop = true;
			this.linkViewDatabases.Text = "Select Databases";
			this.linkViewDatabases.Visible = false;
			this.linkViewDatabases.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkViewDatabases_LinkClicked);
			// 
			// textConfirmPassword
			// 
			// 
			// 
			// 
			this.textConfirmPassword.Border.Class = "TextBoxBorder";
			this.textConfirmPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.textConfirmPassword.Enabled = false;
			this.textConfirmPassword.Location = new System.Drawing.Point(655, 32);
			this.textConfirmPassword.Name = "textConfirmPassword";
			this.textConfirmPassword.PasswordChar = '●';
			this.textConfirmPassword.Size = new System.Drawing.Size(168, 20);
			this.textConfirmPassword.TabIndex = 18;
			this.textConfirmPassword.UseSystemPasswordChar = true;
			// 
			// checkEnableLogin
			// 
			this.checkEnableLogin.AutoSize = true;
			this.checkEnableLogin.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.checkEnableLogin.BackgroundStyle.Class = "";
			this.checkEnableLogin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.checkEnableLogin.Location = new System.Drawing.Point(511, 126);
			this.checkEnableLogin.Name = "checkEnableLogin";
			this.checkEnableLogin.Size = new System.Drawing.Size(198, 15);
			this.checkEnableLogin.TabIndex = 23;
			this.checkEnableLogin.Text = "Enable login (SQL 2005 and Above)";
			// 
			// textPassword
			// 
			// 
			// 
			// 
			this.textPassword.Border.Class = "TextBoxBorder";
			this.textPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.textPassword.Enabled = false;
			this.textPassword.Location = new System.Drawing.Point(655, 8);
			this.textPassword.Name = "textPassword";
			this.textPassword.PasswordChar = '●';
			this.textPassword.Size = new System.Drawing.Size(168, 20);
			this.textPassword.TabIndex = 16;
			this.textPassword.UseSystemPasswordChar = true;
			// 
			// checkIncludeDatabaseAccess
			// 
			this.checkIncludeDatabaseAccess.AutoSize = true;
			this.checkIncludeDatabaseAccess.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.checkIncludeDatabaseAccess.BackgroundStyle.Class = "";
			this.checkIncludeDatabaseAccess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.checkIncludeDatabaseAccess.Checked = true;
			this.checkIncludeDatabaseAccess.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkIncludeDatabaseAccess.CheckValue = "Y";
			this.checkIncludeDatabaseAccess.Location = new System.Drawing.Point(511, 59);
			this.checkIncludeDatabaseAccess.Name = "checkIncludeDatabaseAccess";
			this.checkIncludeDatabaseAccess.Size = new System.Drawing.Size(143, 15);
			this.checkIncludeDatabaseAccess.TabIndex = 19;
			this.checkIncludeDatabaseAccess.Text = "Include database access";
			this.checkIncludeDatabaseAccess.CheckedChanged += new System.EventHandler(this.checkIncludeDatabaseAccess_CheckedChanged);
			// 
			// checkIncludeObjectPermissions
			// 
			this.checkIncludeObjectPermissions.AutoSize = true;
			this.checkIncludeObjectPermissions.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.checkIncludeObjectPermissions.BackgroundStyle.Class = "";
			this.checkIncludeObjectPermissions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.checkIncludeObjectPermissions.Checked = true;
			this.checkIncludeObjectPermissions.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkIncludeObjectPermissions.CheckValue = "Y";
			this.checkIncludeObjectPermissions.Location = new System.Drawing.Point(528, 84);
			this.checkIncludeObjectPermissions.Name = "checkIncludeObjectPermissions";
			this.checkIncludeObjectPermissions.Size = new System.Drawing.Size(179, 15);
			this.checkIncludeObjectPermissions.TabIndex = 22;
			this.checkIncludeObjectPermissions.Text = "Include object-level permissions";
			// 
			// labelX2
			// 
			this.labelX2.AutoSize = true;
			this.labelX2.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX2.BackgroundStyle.Class = "";
			this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX2.Location = new System.Drawing.Point(9, 36);
			this.labelX2.Name = "labelX2";
			this.labelX2.Size = new System.Drawing.Size(61, 15);
			this.labelX2.TabIndex = 11;
			this.labelX2.Text = "User Name:";
			// 
			// textDestinationUserName
			// 
			// 
			// 
			// 
			this.textDestinationUserName.Border.Class = "TextBoxBorder";
			this.textDestinationUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.textDestinationUserName.Enabled = false;
			this.textDestinationUserName.Location = new System.Drawing.Point(105, 34);
			this.textDestinationUserName.Name = "textDestinationUserName";
			this.textDestinationUserName.Size = new System.Drawing.Size(327, 20);
			this.textDestinationUserName.TabIndex = 12;
			// 
			// listDefaultDatabase
			// 
			this.listDefaultDatabase.DisplayMember = "Text";
			this.listDefaultDatabase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.listDefaultDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.listDefaultDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.listDefaultDatabase.FormattingEnabled = true;
			this.listDefaultDatabase.ItemHeight = 14;
			this.listDefaultDatabase.Location = new System.Drawing.Point(105, 60);
			this.listDefaultDatabase.Name = "listDefaultDatabase";
			this.listDefaultDatabase.Size = new System.Drawing.Size(327, 20);
			this.listDefaultDatabase.TabIndex = 14;
			// 
			// labelX5
			// 
			this.labelX5.AutoSize = true;
			this.labelX5.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX5.BackgroundStyle.Class = "";
			this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX5.Location = new System.Drawing.Point(9, 61);
			this.labelX5.Name = "labelX5";
			this.labelX5.Size = new System.Drawing.Size(90, 15);
			this.labelX5.TabIndex = 13;
			this.labelX5.Text = "Default Database:";
			// 
			// ServerSelectionDestination
			// 
			this.ServerSelectionDestination.AllowMultiSelect = true;
			this.ServerSelectionDestination.BackColor = System.Drawing.Color.Transparent;
			this.ServerSelectionDestination.Caption = " ";
			this.ServerSelectionDestination.CredentialsChangedEventHandler = null;
			this.ServerSelectionDestination.CredentialsVisible = true;
			this.ServerSelectionDestination.Location = new System.Drawing.Point(87, 8);
			this.ServerSelectionDestination.MinimumSize = new System.Drawing.Size(0, 20);
			this.ServerSelectionDestination.Name = "ServerSelectionDestination";
			this.ServerSelectionDestination.SelectionOptions = Idera.SqlAdminToolset.Core.Controls.ServerSelectionOptions.ServersOnly;
			this.ServerSelectionDestination.Size = new System.Drawing.Size(403, 20);
			this.ServerSelectionDestination.SqlCredentials = null;
			this.ServerSelectionDestination.TabIndex = 8;
			this.ServerSelectionDestination.TextChangedEventHandler = null;
			this.ServerSelectionDestination.WatermarkEnabled = false;
			this.ServerSelectionDestination.TextChanged += new System.EventHandler(this.ServerSelectionDestination_TextChanged);
			this.ServerSelectionDestination.Leave += new System.EventHandler(this.ServerSelectionDestination_Leave);
			// 
			// buttonCloneUser
			// 
			this.buttonCloneUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonCloneUser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonCloneUser.Image = ((System.Drawing.Image)(resources.GetObject("buttonCloneUser.Image")));
			this.buttonCloneUser.Location = new System.Drawing.Point(4, 265);
			this.buttonCloneUser.Name = "buttonCloneUser";
			this.buttonCloneUser.Size = new System.Drawing.Size(275, 41);
			this.buttonCloneUser.TabIndex = 24;
			this.buttonCloneUser.Text = "&Clone User";
			this.buttonCloneUser.Click += new System.EventHandler(this.buttonCloneUser_Click);
			// 
			// groupPanel5
			// 
			this.groupPanel5.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.groupPanel5.Controls.Add(this.textSourceUser);
			this.groupPanel5.Controls.Add(this.ServerSelectionSource);
			this.groupPanel5.Controls.Add(this.labelX1);
			this.groupPanel5.Location = new System.Drawing.Point(4, 4);
			this.groupPanel5.Name = "groupPanel5";
			this.groupPanel5.Size = new System.Drawing.Size(841, 78);
			// 
			// 
			// 
			this.groupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.groupPanel5.Style.BackColorGradientAngle = 90;
			this.groupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.groupPanel5.Style.BorderBottomWidth = 1;
			this.groupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.groupPanel5.Style.BorderLeftWidth = 1;
			this.groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.groupPanel5.Style.BorderRightWidth = 1;
			this.groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.groupPanel5.Style.BorderTopWidth = 1;
			this.groupPanel5.Style.Class = "";
			this.groupPanel5.Style.CornerDiameter = 4;
			this.groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
			this.groupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.groupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
			// 
			// 
			// 
			this.groupPanel5.StyleMouseDown.Class = "";
			this.groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			// 
			// 
			// 
			this.groupPanel5.StyleMouseOver.Class = "";
			this.groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.groupPanel5.TabIndex = 0;
			this.groupPanel5.Text = "Source User";
			// 
			// textSourceUser
			// 
			// 
			// 
			// 
			this.textSourceUser.Border.Class = "TextBoxBorder";
			this.textSourceUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.textSourceUser.ButtonCustom.Visible = true;
			this.textSourceUser.Location = new System.Drawing.Point(75, 29);
			this.textSourceUser.Name = "textSourceUser";
			this.textSourceUser.ReadOnly = true;
			this.textSourceUser.Size = new System.Drawing.Size(357, 20);
			this.textSourceUser.TabIndex = 6;
			this.textSourceUser.ButtonCustomClick += new System.EventHandler(this.textSourceUser_ButtonCustomClick);
			// 
			// ServerSelectionSource
			// 
			this.ServerSelectionSource.AllowMultiSelect = false;
			this.ServerSelectionSource.BackColor = System.Drawing.Color.Transparent;
			this.ServerSelectionSource.Caption = "SQL Server:";
			this.ServerSelectionSource.CredentialsChangedEventHandler = null;
			this.ServerSelectionSource.CredentialsVisible = true;
			this.ServerSelectionSource.Location = new System.Drawing.Point(3, 3);
			this.ServerSelectionSource.MinimumSize = new System.Drawing.Size(2, 20);
			this.ServerSelectionSource.Name = "ServerSelectionSource";
			this.ServerSelectionSource.SelectionOptions = Idera.SqlAdminToolset.Core.Controls.ServerSelectionOptions.ServersOnly;
			this.ServerSelectionSource.Size = new System.Drawing.Size(487, 20);
			this.ServerSelectionSource.SqlCredentials = null;
			this.ServerSelectionSource.TabIndex = 1;
			this.ServerSelectionSource.TextChangedEventHandler = null;
			this.ServerSelectionSource.WatermarkEnabled = false;
			this.ServerSelectionSource.TextChanged += new System.EventHandler(this.ServerSelectionSource_TextChanged);
			this.ServerSelectionSource.CredentialsChanged += new System.EventHandler(this.ServerSelectionSource_CredentialsChanged);
			this.ServerSelectionSource.Leave += new System.EventHandler(this.ServerSelectionSource_Leave);
			// 
			// labelX1
			// 
			this.labelX1.AutoSize = true;
			this.labelX1.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX1.BackgroundStyle.Class = "";
			this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX1.Location = new System.Drawing.Point(8, 30);
			this.labelX1.Name = "labelX1";
			this.labelX1.Size = new System.Drawing.Size(61, 15);
			this.labelX1.TabIndex = 4;
			this.labelX1.Text = "User Name:";
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
			this.panelTop.Size = new System.Drawing.Size(868, 52);
			this.panelTop.TabIndex = 16;
			// 
			// labelTitle
			// 
			// 
			// 
			// 
			this.labelTitle.BackgroundStyle.Class = "";
			this.labelTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelTitle.ForeColor = System.Drawing.Color.Black;
			this.labelTitle.Location = new System.Drawing.Point(59, 0);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(270, 52);
			this.labelTitle.TabIndex = 5;
			this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  User Clone</font></b> ";
			// 
			// labelSubtitle
			// 
			// 
			// 
			// 
			this.labelSubtitle.BackgroundStyle.Class = "";
			this.labelSubtitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSubtitle.Location = new System.Drawing.Point(226, 0);
			this.labelSubtitle.Name = "labelSubtitle";
			this.labelSubtitle.Size = new System.Drawing.Size(411, 52);
			this.labelSubtitle.TabIndex = 6;
			this.labelSubtitle.Text = "Create a new SQL Server login using an existing login as a template";
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
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuTools,
            this.menuHelp});
			this.menuStrip1.Location = new System.Drawing.Point(0, 93);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(868, 24);
			this.menuStrip1.TabIndex = 18;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuFile
			// 
			this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExitToLaunchpad,
            this.menuFileExit});
			this.menuFile.Name = "menuFile";
			this.menuFile.Size = new System.Drawing.Size(37, 20);
			this.menuFile.Text = "&File";
			// 
			// menuExitToLaunchpad
			// 
			this.menuExitToLaunchpad.Name = "menuExitToLaunchpad";
			this.menuExitToLaunchpad.Size = new System.Drawing.Size(168, 22);
			this.menuExitToLaunchpad.Text = "Exit to &Launchpad";
			this.menuExitToLaunchpad.Click += new System.EventHandler(this.menuExitToLaunchpad_Click);
			// 
			// menuFileExit
			// 
			this.menuFileExit.Name = "menuFileExit";
			this.menuFileExit.Size = new System.Drawing.Size(168, 22);
			this.menuFileExit.Text = "E&xit";
			this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
			// 
			// menuTools
			// 
			this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManageServerGroups,
            this.menuToolsetOptions,
            this.toolStripMenuItem4,
            this.menuLaunchpad});
			this.menuTools.Name = "menuTools";
			this.menuTools.Size = new System.Drawing.Size(48, 20);
			this.menuTools.Text = "&Tools";
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
			this.menuAbout.Text = "&About User Clone";
			this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
			// 
			// panelBottom
			// 
			this.panelBottom.Controls.Add(this.groupResults);
			this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBottom.Location = new System.Drawing.Point(0, 497);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
			this.panelBottom.Size = new System.Drawing.Size(868, 214);
			this.panelBottom.TabIndex = 19;
			// 
			// groupResults
			// 
			this.groupResults.BackColor = System.Drawing.Color.Transparent;
			this.groupResults.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupResults.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.groupResults.Controls.Add(this.Progress);
			this.groupResults.Controls.Add(this.buttonCopy);
			this.groupResults.Controls.Add(this.buttonSave);
			this.groupResults.Controls.Add(this.textScript);
			this.groupResults.Controls.Add(this.labelX7);
			this.groupResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupResults.IsShadowEnabled = true;
			this.groupResults.Location = new System.Drawing.Point(6, 3);
			this.groupResults.Name = "groupResults";
			this.groupResults.Size = new System.Drawing.Size(856, 205);
			// 
			// 
			// 
			this.groupResults.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.groupResults.Style.BackColorGradientAngle = 90;
			this.groupResults.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.groupResults.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.groupResults.Style.BorderBottomWidth = 1;
			this.groupResults.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.groupResults.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.groupResults.Style.BorderLeftWidth = 1;
			this.groupResults.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.groupResults.Style.BorderRightWidth = 1;
			this.groupResults.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.groupResults.Style.BorderTopWidth = 1;
			this.groupResults.Style.Class = "";
			this.groupResults.Style.CornerDiameter = 4;
			this.groupResults.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
			this.groupResults.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.groupResults.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
			// 
			// 
			// 
			this.groupResults.StyleMouseDown.Class = "";
			this.groupResults.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			// 
			// 
			// 
			this.groupResults.StyleMouseOver.Class = "";
			this.groupResults.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.groupResults.TabIndex = 28;
			// 
			// Progress
			// 
			this.Progress.BackColor = System.Drawing.Color.Transparent;
			this.Progress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Progress.CancelButtonVisible = false;
			this.Progress.Location = new System.Drawing.Point(234, 53);
			this.Progress.MarqueeStyle = true;
			this.Progress.Maximum = 100;
			this.Progress.MaximumSize = new System.Drawing.Size(394, 116);
			this.Progress.Minimum = 0;
			this.Progress.MinimumSize = new System.Drawing.Size(394, 92);
			this.Progress.Name = "Progress";
			this.Progress.OperationText = "Description of Operation";
			this.Progress.ProgressCancelEventHandler = null;
			this.Progress.Size = new System.Drawing.Size(394, 92);
			this.Progress.Step = 1;
			this.Progress.TabIndex = 30;
			this.Progress.Visible = false;
			// 
			// buttonCopy
			// 
			this.buttonCopy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCopy.BackColor = System.Drawing.Color.White;
			this.buttonCopy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.buttonCopy.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopy.Image")));
			this.buttonCopy.Location = new System.Drawing.Point(708, 167);
			this.buttonCopy.Name = "buttonCopy";
			this.buttonCopy.Size = new System.Drawing.Size(139, 28);
			this.buttonCopy.TabIndex = 30;
			this.buttonCopy.Text = "&Copy to Clipboard";
			this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.BackColor = System.Drawing.Color.White;
			this.buttonSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
			this.buttonSave.Location = new System.Drawing.Point(575, 167);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(127, 28);
			this.buttonSave.TabIndex = 29;
			this.buttonSave.Text = "&Save Script";
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// textScript
			// 
			this.textScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textScript.BackColor = System.Drawing.SystemColors.Window;
			// 
			// 
			// 
			this.textScript.Border.Class = "TextBoxBorder";
			this.textScript.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.textScript.Location = new System.Drawing.Point(2, 26);
			this.textScript.Multiline = true;
			this.textScript.Name = "textScript";
			this.textScript.ReadOnly = true;
			this.textScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textScript.Size = new System.Drawing.Size(843, 130);
			this.textScript.TabIndex = 1;
			// 
			// labelX7
			// 
			// 
			// 
			// 
			this.labelX7.BackgroundStyle.Class = "";
			this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX7.Location = new System.Drawing.Point(4, 4);
			this.labelX7.Name = "labelX7";
			this.labelX7.Size = new System.Drawing.Size(40, 23);
			this.labelX7.TabIndex = 0;
			this.labelX7.Text = "Script:";
			// 
			// PreviewWorker
			// 
			this.PreviewWorker.WorkerReportsProgress = true;
			this.PreviewWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PreviewWorker_DoWork);
			this.PreviewWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.PreviewWorker_ProgressChanged);
			this.PreviewWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.PreviewWorker_RunWorkerCompleted);
			// 
			// CloningWorker
			// 
			this.CloningWorker.WorkerReportsProgress = true;
			this.CloningWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CloningWorker_DoWork);
			this.CloningWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.CloningWorker_ProgressChanged);
			this.CloningWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.CloningWorker_RunWorkerCompleted);
			// 
			// ideraTitleBar1
			// 
			this.ideraTitleBar1.ActivateLicenseEventHandler = null;
			this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
			this.ideraTitleBar1.Close = true;
			this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
			this.ideraTitleBar1.IderaProductNameText = "SQL User Clone";
			this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
			this.ideraTitleBar1.LicenseInformation = null;
			this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
			this.ideraTitleBar1.Maximize = true;
			this.ideraTitleBar1.Minimize = true;
			this.ideraTitleBar1.Name = "ideraTitleBar1";
			this.ideraTitleBar1.Size = new System.Drawing.Size(868, 93);
			this.ideraTitleBar1.TabIndex = 20;
			this.ideraTitleBar1.TrialMode = true;
			this.ideraTitleBar1.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar1_LicenseInfoButtonClick);
			// 
			// Form_Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(868, 711);
			this.ControlBox = false;
			this.Controls.Add(this.panelBottom);
			this.Controls.Add(this.panelMiddle);
			this.Controls.Add(this.panelTop);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.ideraTitleBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(680, 727);
			this.Name = "Form_Main";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
			this.panelMiddle.ResumeLayout(false);
			this.groupPanel1.ResumeLayout(false);
			this.groupPanel6.ResumeLayout(false);
			this.groupPanel6.PerformLayout();
			this.groupPanel5.ResumeLayout(false);
			this.groupPanel5.PerformLayout();
			this.panelTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panelBottom.ResumeLayout(false);
			this.groupResults.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panelMiddle;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private System.Windows.Forms.Panel panelTop;
      private DevComponents.DotNetBar.LabelX labelTitle;
      private DevComponents.DotNetBar.LabelX labelSubtitle;
      private System.Windows.Forms.PictureBox pictureBoxTitle;
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
      private System.Windows.Forms.Panel panelBottom;
      private DevComponents.DotNetBar.Controls.GroupPanel groupResults;
      private DevComponents.DotNetBar.LabelX labelX7;
      private DevComponents.DotNetBar.Controls.TextBoxX textScript;
      private DevComponents.DotNetBar.ButtonX buttonCopy;
      private DevComponents.DotNetBar.ButtonX buttonSave;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel6;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkEnableLogin;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkIncludeDatabaseAccess;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkIncludeObjectPermissions;
      private DevComponents.DotNetBar.LabelX labelX2;
      private DevComponents.DotNetBar.Controls.TextBoxX textDestinationUserName;
      private DevComponents.DotNetBar.Controls.ComboBoxEx listDefaultDatabase;
      private DevComponents.DotNetBar.LabelX labelX5;
      private DevComponents.DotNetBar.Controls.TextBoxX textPassword;
      private DevComponents.DotNetBar.Controls.TextBoxX textConfirmPassword;
      private DevComponents.DotNetBar.LabelX labelX4;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
      private Idera.SqlAdminToolset.Core.Controls.ToolServerSelectionNoMru ServerSelectionSource;
       private DevComponents.DotNetBar.LabelX labelX1;
      private DevComponents.DotNetBar.ButtonX buttonCloneUser;
      private Idera.SqlAdminToolset.Core.Controls.ToolServerSelectionNoMru ServerSelectionDestination;
      private System.ComponentModel.BackgroundWorker PreviewWorker;
      private System.ComponentModel.BackgroundWorker CloningWorker;
      private Idera.SqlAdminToolset.Core.Controls.ToolProgress Progress;
      private System.Windows.Forms.LinkLabel linkViewDatabases;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkSpecifyPassword;
      private DevComponents.DotNetBar.LabelX labelX6;
      private DevComponents.DotNetBar.ButtonX buttonCreate2005Script;
      private DevComponents.DotNetBar.ButtonX buttonCreate2000Script;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkIncludeSchemaOwnership;
       private DevComponents.DotNetBar.Controls.TextBoxX textSourceUser;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
    }
}

