namespace Idera.SqlAdminToolset.PasswordChecker
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupServerInformation = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ServerSelection = new Idera.SqlAdminToolset.Core.Controls.ToolServerSelection();
            this.groupUsers = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.radioSa = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.textDatabaseRoles = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textServerRoles = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textSelectedUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.radioSpecificUser = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioDatabaseRoles = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioServerRoles = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioAllUsers = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupTestType = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkTestVariations = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkCustom = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkOther = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBlank = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.check2400 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.check800 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.check50 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.check10 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.linkView2400 = new System.Windows.Forms.LinkLabel();
            this.linkView800 = new System.Windows.Forms.LinkLabel();
            this.linkView50 = new System.Windows.Forms.LinkLabel();
            this.linkView10 = new System.Windows.Forms.LinkLabel();
            this.textCustom = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textPasswords = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonGetResults = new DevComponents.DotNetBar.ButtonX();
            this.groupResults = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listResults = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUsers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPasswordFailed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnBlankPasswords = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSameAsLogin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuServers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuCopy_Servers = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSelectAll_Servers = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListLockIcons = new System.Windows.Forms.ImageList(this.components);
            this.buttonShowPasswords = new DevComponents.DotNetBar.ButtonX();
            this.listUserDetails = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnResultsIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnResultsUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHasBadPassword = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnResultsFailedPassword = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextShowFailedOnly = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuShowFoundPasswordsOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuMaskPasswords = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuCopy_Logins = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSelectAll_Logins = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTestedLogins = new DevComponents.DotNetBar.LabelX();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsText = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsXML = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maskPasswordStringsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManageServerGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuToolsetOptions = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.panelMiddle.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupServerInformation.SuspendLayout();
            this.groupUsers.SuspendLayout();
            this.groupTestType.SuspendLayout();
            this.groupResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuServers.SuspendLayout();
            this.contextShowFailedOnly.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.groupPanel1);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMiddle.Location = new System.Drawing.Point(0, 169);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Padding = new System.Windows.Forms.Padding(6);
            this.panelMiddle.Size = new System.Drawing.Size(1015, 249);
            this.panelMiddle.TabIndex = 14;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.groupServerInformation);
            this.groupPanel1.Controls.Add(this.groupUsers);
            this.groupPanel1.Controls.Add(this.groupTestType);
            this.groupPanel1.Controls.Add(this.buttonGetResults);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.IsShadowEnabled = true;
            this.groupPanel1.Location = new System.Drawing.Point(6, 6);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1003, 237);
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
            // groupServerInformation
            // 
            this.groupServerInformation.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupServerInformation.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupServerInformation.Controls.Add(this.ServerSelection);
            this.groupServerInformation.Location = new System.Drawing.Point(5, 3);
            this.groupServerInformation.Name = "groupServerInformation";
            this.groupServerInformation.Size = new System.Drawing.Size(377, 76);
            // 
            // 
            // 
            this.groupServerInformation.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupServerInformation.Style.BackColorGradientAngle = 90;
            this.groupServerInformation.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupServerInformation.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupServerInformation.Style.BorderBottomWidth = 1;
            this.groupServerInformation.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupServerInformation.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupServerInformation.Style.BorderLeftWidth = 1;
            this.groupServerInformation.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupServerInformation.Style.BorderRightWidth = 1;
            this.groupServerInformation.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupServerInformation.Style.BorderTopWidth = 1;
            this.groupServerInformation.Style.Class = "";
            this.groupServerInformation.Style.CornerDiameter = 4;
            this.groupServerInformation.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupServerInformation.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupServerInformation.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupServerInformation.StyleMouseDown.Class = "";
            this.groupServerInformation.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupServerInformation.StyleMouseOver.Class = "";
            this.groupServerInformation.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupServerInformation.TabIndex = 1;
            this.groupServerInformation.Text = "Specify Server Information";
            // 
            // ServerSelection
            // 
            this.ServerSelection.BackColor = System.Drawing.Color.Transparent;
            this.ServerSelection.Caption = "";
            this.ServerSelection.CredentialsVisible = true;
            this.ServerSelection.Location = new System.Drawing.Point(2, 7);
            this.ServerSelection.MinimumSize = new System.Drawing.Size(290, 40);
            this.ServerSelection.Name = "ServerSelection";
            this.ServerSelection.SelectionOptions = Idera.SqlAdminToolset.Core.Controls.ServerSelectionOptions.ServersAndGroups;
            this.ServerSelection.Size = new System.Drawing.Size(366, 40);
            this.ServerSelection.TabIndex = 1;
            this.ServerSelection.TextChangedEventHandler = null;
            this.ServerSelection.TextChanged += new System.EventHandler(this.ServerSelection_TextChanged);
            // 
            // groupUsers
            // 
            this.groupUsers.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupUsers.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupUsers.Controls.Add(this.radioSa);
            this.groupUsers.Controls.Add(this.textDatabaseRoles);
            this.groupUsers.Controls.Add(this.textServerRoles);
            this.groupUsers.Controls.Add(this.textSelectedUser);
            this.groupUsers.Controls.Add(this.radioSpecificUser);
            this.groupUsers.Controls.Add(this.radioDatabaseRoles);
            this.groupUsers.Controls.Add(this.radioServerRoles);
            this.groupUsers.Controls.Add(this.radioAllUsers);
            this.groupUsers.Location = new System.Drawing.Point(5, 85);
            this.groupUsers.Name = "groupUsers";
            this.groupUsers.Size = new System.Drawing.Size(377, 138);
            // 
            // 
            // 
            this.groupUsers.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupUsers.Style.BackColorGradientAngle = 90;
            this.groupUsers.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupUsers.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupUsers.Style.BorderBottomWidth = 1;
            this.groupUsers.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupUsers.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupUsers.Style.BorderLeftWidth = 1;
            this.groupUsers.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupUsers.Style.BorderRightWidth = 1;
            this.groupUsers.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupUsers.Style.BorderTopWidth = 1;
            this.groupUsers.Style.Class = "";
            this.groupUsers.Style.CornerDiameter = 4;
            this.groupUsers.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupUsers.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupUsers.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupUsers.StyleMouseDown.Class = "";
            this.groupUsers.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupUsers.StyleMouseOver.Class = "";
            this.groupUsers.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupUsers.TabIndex = 2;
            this.groupUsers.Text = "Specify logins to test";
            // 
            // radioSa
            // 
            this.radioSa.AutoSize = true;
            // 
            // 
            // 
            this.radioSa.BackgroundStyle.Class = "";
            this.radioSa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioSa.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioSa.Location = new System.Drawing.Point(1, 27);
            this.radioSa.Name = "radioSa";
            this.radioSa.Size = new System.Drawing.Size(34, 15);
            this.radioSa.TabIndex = 11;
            this.radioSa.Text = "sa";
            // 
            // textDatabaseRoles
            // 
            this.textDatabaseRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.textDatabaseRoles.Border.Class = "TextBoxBorder";
            this.textDatabaseRoles.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textDatabaseRoles.ButtonCustom.Visible = true;
            this.textDatabaseRoles.Enabled = false;
            this.textDatabaseRoles.Location = new System.Drawing.Point(103, 72);
            this.textDatabaseRoles.Name = "textDatabaseRoles";
            this.textDatabaseRoles.ReadOnly = true;
            this.textDatabaseRoles.Size = new System.Drawing.Size(265, 20);
            this.textDatabaseRoles.TabIndex = 15;
            this.textDatabaseRoles.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.textDatabaseRoles.WatermarkText = "Browse for roles; leave blank for All";
            this.textDatabaseRoles.ButtonCustomClick += new System.EventHandler(this.textDatabaseRoles_ButtonCustomClick);
            // 
            // textServerRoles
            // 
            this.textServerRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.textServerRoles.Border.Class = "TextBoxBorder";
            this.textServerRoles.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textServerRoles.ButtonCustom.Visible = true;
            this.textServerRoles.Enabled = false;
            this.textServerRoles.Location = new System.Drawing.Point(103, 49);
            this.textServerRoles.Name = "textServerRoles";
            this.textServerRoles.ReadOnly = true;
            this.textServerRoles.Size = new System.Drawing.Size(265, 20);
            this.textServerRoles.TabIndex = 13;
            this.textServerRoles.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.textServerRoles.WatermarkText = "Browse for roles; leave blank for All";
            this.textServerRoles.ButtonCustomClick += new System.EventHandler(this.textServerRoles_ButtonCustomClick);
            // 
            // textSelectedUser
            // 
            this.textSelectedUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.textSelectedUser.Border.Class = "TextBoxBorder";
            this.textSelectedUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textSelectedUser.Enabled = false;
            this.textSelectedUser.Location = new System.Drawing.Point(102, 95);
            this.textSelectedUser.Name = "textSelectedUser";
            this.textSelectedUser.Size = new System.Drawing.Size(265, 20);
            this.textSelectedUser.TabIndex = 17;
            this.textSelectedUser.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.textSelectedUser.WatermarkText = "Enter users separated by semi-colons";
            // 
            // radioSpecificUser
            // 
            this.radioSpecificUser.AutoSize = true;
            // 
            // 
            // 
            this.radioSpecificUser.BackgroundStyle.Class = "";
            this.radioSpecificUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioSpecificUser.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioSpecificUser.Location = new System.Drawing.Point(1, 96);
            this.radioSpecificUser.Name = "radioSpecificUser";
            this.radioSpecificUser.Size = new System.Drawing.Size(84, 15);
            this.radioSpecificUser.TabIndex = 16;
            this.radioSpecificUser.Text = "List of logins";
            this.radioSpecificUser.CheckedChanged += new System.EventHandler(this.radioSpecificUser_CheckedChanged);
            // 
            // radioDatabaseRoles
            // 
            this.radioDatabaseRoles.AutoSize = true;
            // 
            // 
            // 
            this.radioDatabaseRoles.BackgroundStyle.Class = "";
            this.radioDatabaseRoles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioDatabaseRoles.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioDatabaseRoles.Location = new System.Drawing.Point(1, 73);
            this.radioDatabaseRoles.Name = "radioDatabaseRoles";
            this.radioDatabaseRoles.Size = new System.Drawing.Size(96, 15);
            this.radioDatabaseRoles.TabIndex = 14;
            this.radioDatabaseRoles.Text = "Database roles";
            this.radioDatabaseRoles.CheckedChanged += new System.EventHandler(this.radioDatabaseRoles_CheckedChanged);
            // 
            // radioServerRoles
            // 
            this.radioServerRoles.AutoSize = true;
            // 
            // 
            // 
            this.radioServerRoles.BackgroundStyle.Class = "";
            this.radioServerRoles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioServerRoles.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioServerRoles.Location = new System.Drawing.Point(1, 50);
            this.radioServerRoles.Name = "radioServerRoles";
            this.radioServerRoles.Size = new System.Drawing.Size(82, 15);
            this.radioServerRoles.TabIndex = 12;
            this.radioServerRoles.Text = "Server roles";
            this.radioServerRoles.CheckedChanged += new System.EventHandler(this.radioServerRoles_CheckedChanged);
            // 
            // radioAllUsers
            // 
            this.radioAllUsers.AutoSize = true;
            // 
            // 
            // 
            this.radioAllUsers.BackgroundStyle.Class = "";
            this.radioAllUsers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioAllUsers.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioAllUsers.Checked = true;
            this.radioAllUsers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioAllUsers.CheckValue = "Y";
            this.radioAllUsers.Location = new System.Drawing.Point(1, 5);
            this.radioAllUsers.Name = "radioAllUsers";
            this.radioAllUsers.Size = new System.Drawing.Size(67, 15);
            this.radioAllUsers.TabIndex = 10;
            this.radioAllUsers.Text = "All logins";
            // 
            // groupTestType
            // 
            this.groupTestType.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupTestType.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupTestType.Controls.Add(this.checkTestVariations);
            this.groupTestType.Controls.Add(this.checkCustom);
            this.groupTestType.Controls.Add(this.checkOther);
            this.groupTestType.Controls.Add(this.checkBlank);
            this.groupTestType.Controls.Add(this.check2400);
            this.groupTestType.Controls.Add(this.check800);
            this.groupTestType.Controls.Add(this.check50);
            this.groupTestType.Controls.Add(this.check10);
            this.groupTestType.Controls.Add(this.linkView2400);
            this.groupTestType.Controls.Add(this.linkView800);
            this.groupTestType.Controls.Add(this.linkView50);
            this.groupTestType.Controls.Add(this.linkView10);
            this.groupTestType.Controls.Add(this.textCustom);
            this.groupTestType.Controls.Add(this.textPasswords);
            this.groupTestType.Location = new System.Drawing.Point(401, 3);
            this.groupTestType.Name = "groupTestType";
            this.groupTestType.Size = new System.Drawing.Size(590, 142);
            // 
            // 
            // 
            this.groupTestType.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupTestType.Style.BackColorGradientAngle = 90;
            this.groupTestType.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupTestType.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupTestType.Style.BorderBottomWidth = 1;
            this.groupTestType.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupTestType.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupTestType.Style.BorderLeftWidth = 1;
            this.groupTestType.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupTestType.Style.BorderRightWidth = 1;
            this.groupTestType.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupTestType.Style.BorderTopWidth = 1;
            this.groupTestType.Style.Class = "";
            this.groupTestType.Style.CornerDiameter = 4;
            this.groupTestType.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupTestType.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupTestType.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupTestType.StyleMouseDown.Class = "";
            this.groupTestType.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupTestType.StyleMouseOver.Class = "";
            this.groupTestType.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupTestType.TabIndex = 3;
            this.groupTestType.Text = "Specify passwords to check";
            // 
            // checkTestVariations
            // 
            // 
            // 
            // 
            this.checkTestVariations.BackgroundStyle.Class = "";
            this.checkTestVariations.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkTestVariations.Location = new System.Drawing.Point(247, 88);
            this.checkTestVariations.Name = "checkTestVariations";
            this.checkTestVariations.Size = new System.Drawing.Size(274, 23);
            this.checkTestVariations.TabIndex = 34;
            this.checkTestVariations.Text = "Test Common Variations of Selected Passwords";
            // 
            // checkCustom
            // 
            // 
            // 
            // 
            this.checkCustom.BackgroundStyle.Class = "";
            this.checkCustom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkCustom.Location = new System.Drawing.Point(247, 62);
            this.checkCustom.Name = "checkCustom";
            this.checkCustom.Size = new System.Drawing.Size(88, 23);
            this.checkCustom.TabIndex = 33;
            this.checkCustom.Text = "Custom List";
            this.checkCustom.CheckedChanged += new System.EventHandler(this.checkCustom_CheckedChanged);
            // 
            // checkOther
            // 
            // 
            // 
            // 
            this.checkOther.BackgroundStyle.Class = "";
            this.checkOther.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkOther.Location = new System.Drawing.Point(247, 36);
            this.checkOther.Name = "checkOther";
            this.checkOther.Size = new System.Drawing.Size(75, 23);
            this.checkOther.TabIndex = 31;
            this.checkOther.Text = "Other";
            this.checkOther.CheckedChanged += new System.EventHandler(this.checkOther_CheckedChanged);
            // 
            // checkBlank
            // 
            // 
            // 
            // 
            this.checkBlank.BackgroundStyle.Class = "";
            this.checkBlank.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBlank.Location = new System.Drawing.Point(247, 10);
            this.checkBlank.Name = "checkBlank";
            this.checkBlank.Size = new System.Drawing.Size(262, 23);
            this.checkBlank.TabIndex = 29;
            this.checkBlank.Text = "Blank password and passwords matching login";
            // 
            // check2400
            // 
            // 
            // 
            // 
            this.check2400.BackgroundStyle.Class = "";
            this.check2400.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.check2400.Location = new System.Drawing.Point(3, 88);
            this.check2400.Name = "check2400";
            this.check2400.Size = new System.Drawing.Size(175, 23);
            this.check2400.TabIndex = 27;
            this.check2400.Text = "The Big List (2400+ Passwords)";
            // 
            // check800
            // 
            // 
            // 
            // 
            this.check800.BackgroundStyle.Class = "";
            this.check800.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.check800.Location = new System.Drawing.Point(3, 62);
            this.check800.Name = "check800";
            this.check800.Size = new System.Drawing.Size(159, 23);
            this.check800.TabIndex = 25;
            this.check800.Text = "800 Common Passwords";
            // 
            // check50
            // 
            // 
            // 
            // 
            this.check50.BackgroundStyle.Class = "";
            this.check50.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.check50.Location = new System.Drawing.Point(3, 36);
            this.check50.Name = "check50";
            this.check50.Size = new System.Drawing.Size(75, 23);
            this.check50.TabIndex = 23;
            this.check50.Text = "Nifty Fifty";
            // 
            // check10
            // 
            // 
            // 
            // 
            this.check10.BackgroundStyle.Class = "";
            this.check10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.check10.Checked = true;
            this.check10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check10.CheckValue = "Y";
            this.check10.Location = new System.Drawing.Point(3, 10);
            this.check10.Name = "check10";
            this.check10.Size = new System.Drawing.Size(75, 23);
            this.check10.TabIndex = 21;
            this.check10.Text = "Top 10 List (plus Blank)";
            // 
            // linkView2400
            // 
            this.linkView2400.AutoSize = true;
            this.linkView2400.Location = new System.Drawing.Point(184, 94);
            this.linkView2400.Name = "linkView2400";
            this.linkView2400.Size = new System.Drawing.Size(30, 13);
            this.linkView2400.TabIndex = 28;
            this.linkView2400.TabStop = true;
            this.linkView2400.Text = "View";
            this.linkView2400.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkView2400_LinkClicked);
            // 
            // linkView800
            // 
            this.linkView800.AutoSize = true;
            this.linkView800.Location = new System.Drawing.Point(184, 68);
            this.linkView800.Name = "linkView800";
            this.linkView800.Size = new System.Drawing.Size(30, 13);
            this.linkView800.TabIndex = 26;
            this.linkView800.TabStop = true;
            this.linkView800.Text = "View";
            this.linkView800.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkView800_LinkClicked);
            // 
            // linkView50
            // 
            this.linkView50.AutoSize = true;
            this.linkView50.Location = new System.Drawing.Point(184, 43);
            this.linkView50.Name = "linkView50";
            this.linkView50.Size = new System.Drawing.Size(30, 13);
            this.linkView50.TabIndex = 24;
            this.linkView50.TabStop = true;
            this.linkView50.Text = "View";
            this.linkView50.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkView50_LinkClicked);
            // 
            // linkView10
            // 
            this.linkView10.AutoSize = true;
            this.linkView10.Location = new System.Drawing.Point(184, 17);
            this.linkView10.Name = "linkView10";
            this.linkView10.Size = new System.Drawing.Size(30, 13);
            this.linkView10.TabIndex = 22;
            this.linkView10.TabStop = true;
            this.linkView10.Text = "View";
            this.linkView10.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkView10_LinkClicked);
            // 
            // textCustom
            // 
            // 
            // 
            // 
            this.textCustom.Border.Class = "TextBoxBorder";
            this.textCustom.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textCustom.ButtonCustom.Visible = true;
            this.textCustom.Enabled = false;
            this.textCustom.Location = new System.Drawing.Point(341, 62);
            this.textCustom.Name = "textCustom";
            this.textCustom.ReadOnly = true;
            this.textCustom.Size = new System.Drawing.Size(223, 20);
            this.textCustom.TabIndex = 33;
            this.textCustom.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.textCustom.ButtonCustomClick += new System.EventHandler(this.textCustom_ButtonCustomClick);
            // 
            // textPasswords
            // 
            // 
            // 
            // 
            this.textPasswords.Border.Class = "TextBoxBorder";
            this.textPasswords.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textPasswords.Enabled = false;
            this.textPasswords.Location = new System.Drawing.Point(341, 36);
            this.textPasswords.Name = "textPasswords";
            this.textPasswords.Size = new System.Drawing.Size(223, 20);
            this.textPasswords.TabIndex = 31;
            this.textPasswords.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.textPasswords.WatermarkText = "Enter passwords separated by semi-colons";
            // 
            // buttonGetResults
            // 
            this.buttonGetResults.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonGetResults.BackColor = System.Drawing.Color.White;
            this.buttonGetResults.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonGetResults.Image = ((System.Drawing.Image)(resources.GetObject("buttonGetResults.Image")));
            this.buttonGetResults.Location = new System.Drawing.Point(401, 153);
            this.buttonGetResults.Name = "buttonGetResults";
            this.buttonGetResults.Size = new System.Drawing.Size(590, 70);
            this.buttonGetResults.TabIndex = 50;
            this.buttonGetResults.Text = "Check Passwords";
            this.buttonGetResults.Click += new System.EventHandler(this.buttonGetResults_Click);
            // 
            // groupResults
            // 
            this.groupResults.BackColor = System.Drawing.Color.Transparent;
            this.groupResults.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupResults.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupResults.Controls.Add(this.splitContainer1);
            this.groupResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupResults.IsShadowEnabled = true;
            this.groupResults.Location = new System.Drawing.Point(6, 3);
            this.groupResults.Name = "groupResults";
            this.groupResults.Size = new System.Drawing.Size(1003, 233);
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
            this.groupResults.TabIndex = 19;
            this.groupResults.Text = "Test Results";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listResults);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonShowPasswords);
            this.splitContainer1.Panel2.Controls.Add(this.listUserDetails);
            this.splitContainer1.Panel2.Controls.Add(this.labelTestedLogins);
            this.splitContainer1.Size = new System.Drawing.Size(997, 212);
            this.splitContainer1.SplitterDistance = 512;
            this.splitContainer1.TabIndex = 67;
            // 
            // listResults
            // 
            // 
            // 
            // 
            this.listResults.Border.Class = "ListViewBorder";
            this.listResults.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnIcon,
            this.columnServer,
            this.columnUsers,
            this.columnPasswordFailed,
            this.columnBlankPasswords,
            this.columnSameAsLogin});
            this.listResults.ContextMenuStrip = this.contextMenuServers;
            this.listResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listResults.FullRowSelect = true;
            this.listResults.Location = new System.Drawing.Point(0, 0);
            this.listResults.Name = "listResults";
            this.listResults.Size = new System.Drawing.Size(512, 212);
            this.listResults.SmallImageList = this.imageListLockIcons;
            this.listResults.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listResults.TabIndex = 20;
            this.listResults.UseCompatibleStateImageBehavior = false;
            this.listResults.View = System.Windows.Forms.View.Details;
            this.listResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listResults_ColumnClick);
            this.listResults.SelectedIndexChanged += new System.EventHandler(this.listResults_SelectedIndexChanged);
            // 
            // columnIcon
            // 
            this.columnIcon.Text = "";
            this.columnIcon.Width = 25;
            // 
            // columnServer
            // 
            this.columnServer.Text = "Server";
            this.columnServer.Width = 150;
            // 
            // columnUsers
            // 
            this.columnUsers.Text = "Logins";
            this.columnUsers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnUsers.Width = 75;
            // 
            // columnPasswordFailed
            // 
            this.columnPasswordFailed.Text = "Bad Passwords";
            this.columnPasswordFailed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnPasswordFailed.Width = 95;
            // 
            // columnBlankPasswords
            // 
            this.columnBlankPasswords.Text = "Blank";
            this.columnBlankPasswords.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnSameAsLogin
            // 
            this.columnSameAsLogin.Text = "Same as Login";
            this.columnSameAsLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnSameAsLogin.Width = 90;
            // 
            // contextMenuServers
            // 
            this.contextMenuServers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuCopy_Servers,
            this.contextMenuSelectAll_Servers});
            this.contextMenuServers.Name = "contextMenuServers";
            this.contextMenuServers.Size = new System.Drawing.Size(165, 48);
            // 
            // contextMenuCopy_Servers
            // 
            this.contextMenuCopy_Servers.Enabled = false;
            this.contextMenuCopy_Servers.Name = "contextMenuCopy_Servers";
            this.contextMenuCopy_Servers.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.contextMenuCopy_Servers.Size = new System.Drawing.Size(164, 22);
            this.contextMenuCopy_Servers.Text = "&Copy";
            this.contextMenuCopy_Servers.Click += new System.EventHandler(this.contextMenuCopy_Servers_Click);
            // 
            // contextMenuSelectAll_Servers
            // 
            this.contextMenuSelectAll_Servers.Enabled = false;
            this.contextMenuSelectAll_Servers.Name = "contextMenuSelectAll_Servers";
            this.contextMenuSelectAll_Servers.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.contextMenuSelectAll_Servers.Size = new System.Drawing.Size(164, 22);
            this.contextMenuSelectAll_Servers.Text = "Select &All";
            this.contextMenuSelectAll_Servers.Click += new System.EventHandler(this.contextMenuSelectAll_Servers_Click);
            // 
            // imageListLockIcons
            // 
            this.imageListLockIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLockIcons.ImageStream")));
            this.imageListLockIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLockIcons.Images.SetKeyName(0, "lock_ok.png");
            this.imageListLockIcons.Images.SetKeyName(1, "lock_warning.png");
            this.imageListLockIcons.Images.SetKeyName(2, "lock_error.png");
            this.imageListLockIcons.Images.SetKeyName(3, "check2.png");
            this.imageListLockIcons.Images.SetKeyName(4, "warning.png");
            this.imageListLockIcons.Images.SetKeyName(5, "error.png");
            // 
            // buttonShowPasswords
            // 
            this.buttonShowPasswords.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonShowPasswords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowPasswords.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonShowPasswords.Location = new System.Drawing.Point(324, 0);
            this.buttonShowPasswords.Name = "buttonShowPasswords";
            this.buttonShowPasswords.Size = new System.Drawing.Size(150, 18);
            this.buttonShowPasswords.TabIndex = 21;
            this.buttonShowPasswords.Text = "Show passwords in cleartext";
            this.buttonShowPasswords.Click += new System.EventHandler(this.buttonShowPasswords_Click);
            // 
            // listUserDetails
            // 
            this.listUserDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.listUserDetails.Border.Class = "ListViewBorder";
            this.listUserDetails.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listUserDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnResultsIcon,
            this.columnResultsUserName,
            this.columnHasBadPassword,
            this.columnResultsFailedPassword});
            this.listUserDetails.ContextMenuStrip = this.contextShowFailedOnly;
            this.listUserDetails.FullRowSelect = true;
            this.listUserDetails.Location = new System.Drawing.Point(3, 21);
            this.listUserDetails.Name = "listUserDetails";
            this.listUserDetails.Size = new System.Drawing.Size(474, 171);
            this.listUserDetails.SmallImageList = this.imageListLockIcons;
            this.listUserDetails.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listUserDetails.TabIndex = 22;
            this.listUserDetails.UseCompatibleStateImageBehavior = false;
            this.listUserDetails.View = System.Windows.Forms.View.Details;
            this.listUserDetails.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listUserDetails_ColumnClick);
            this.listUserDetails.SelectedIndexChanged += new System.EventHandler(this.listUserDetails_SelectedIndexChanged);
            // 
            // columnResultsIcon
            // 
            this.columnResultsIcon.Text = "";
            this.columnResultsIcon.Width = 24;
            // 
            // columnResultsUserName
            // 
            this.columnResultsUserName.Text = "SQL Server Login";
            this.columnResultsUserName.Width = 133;
            // 
            // columnHasBadPassword
            // 
            this.columnHasBadPassword.Text = "Result";
            this.columnHasBadPassword.Width = 161;
            // 
            // columnResultsFailedPassword
            // 
            this.columnResultsFailedPassword.Text = "Password (if found)";
            this.columnResultsFailedPassword.Width = 116;
            // 
            // contextShowFailedOnly
            // 
            this.contextShowFailedOnly.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuShowFoundPasswordsOnly,
            this.ContextMenuMaskPasswords,
            this.toolStripMenuItem6,
            this.contextMenuCopy_Logins,
            this.contextMenuSelectAll_Logins});
            this.contextShowFailedOnly.Name = "contextShowFailedOnly";
            this.contextShowFailedOnly.Size = new System.Drawing.Size(267, 98);
            this.contextShowFailedOnly.Text = "&Show found passwords only";
            // 
            // ContextMenuShowFoundPasswordsOnly
            // 
            this.ContextMenuShowFoundPasswordsOnly.Name = "ContextMenuShowFoundPasswordsOnly";
            this.ContextMenuShowFoundPasswordsOnly.Size = new System.Drawing.Size(266, 22);
            this.ContextMenuShowFoundPasswordsOnly.Text = "&Show users with bad passwords only";
            this.ContextMenuShowFoundPasswordsOnly.Click += new System.EventHandler(this.ContextMenuShowFoundPasswordsOnly_Click);
            // 
            // ContextMenuMaskPasswords
            // 
            this.ContextMenuMaskPasswords.Name = "ContextMenuMaskPasswords";
            this.ContextMenuMaskPasswords.Size = new System.Drawing.Size(266, 22);
            this.ContextMenuMaskPasswords.Text = "&Show passwords in clear text";
            this.ContextMenuMaskPasswords.Click += new System.EventHandler(this.ContextMenuMaskPasswords_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(263, 6);
            // 
            // contextMenuCopy_Logins
            // 
            this.contextMenuCopy_Logins.Enabled = false;
            this.contextMenuCopy_Logins.Name = "contextMenuCopy_Logins";
            this.contextMenuCopy_Logins.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.contextMenuCopy_Logins.Size = new System.Drawing.Size(266, 22);
            this.contextMenuCopy_Logins.Text = "&Copy";
            this.contextMenuCopy_Logins.Click += new System.EventHandler(this.contextMenuCopy_Users_Click);
            // 
            // contextMenuSelectAll_Logins
            // 
            this.contextMenuSelectAll_Logins.Enabled = false;
            this.contextMenuSelectAll_Logins.Name = "contextMenuSelectAll_Logins";
            this.contextMenuSelectAll_Logins.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.contextMenuSelectAll_Logins.Size = new System.Drawing.Size(266, 22);
            this.contextMenuSelectAll_Logins.Text = "Select &All";
            this.contextMenuSelectAll_Logins.Click += new System.EventHandler(this.contextMenuSelectAll_Logins_Click);
            // 
            // labelTestedLogins
            // 
            this.labelTestedLogins.AutoSize = true;
            this.labelTestedLogins.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelTestedLogins.BackgroundStyle.Class = "";
            this.labelTestedLogins.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTestedLogins.Location = new System.Drawing.Point(3, 3);
            this.labelTestedLogins.Name = "labelTestedLogins";
            this.labelTestedLogins.Size = new System.Drawing.Size(75, 15);
            this.labelTestedLogins.TabIndex = 66;
            this.labelTestedLogins.Text = "Tested Logins:";
            this.labelTestedLogins.WordWrap = true;
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
            this.panelTop.Size = new System.Drawing.Size(1015, 52);
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
            this.labelTitle.Size = new System.Drawing.Size(330, 52);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.TabStop = false;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Password Checker</font></b> ";
            // 
            // labelSubtitle
            // 
            // 
            // 
            // 
            this.labelSubtitle.BackgroundStyle.Class = "";
            this.labelSubtitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.Location = new System.Drawing.Point(400, 0);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(393, 51);
            this.labelSubtitle.TabIndex = 6;
            this.labelSubtitle.Text = "Check the strength of your SQL Server passwords";
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
            this.panelBottom.Controls.Add(this.groupResults);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 418);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.panelBottom.Size = new System.Drawing.Size(1015, 242);
            this.panelBottom.TabIndex = 17;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.viewToolStripMenuItem,
            this.menuTools,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 93);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1015, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.menuExport,
            this.toolStripSeparator1,
            this.menuExitToLaunchpad,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Enabled = false;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.printToolStripMenuItem.Text = "&Print...";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // menuExport
            // 
            this.menuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExportAsText,
            this.menuExportAsCSV,
            this.menuExportAsXML});
            this.menuExport.Enabled = false;
            this.menuExport.Name = "menuExport";
            this.menuExport.Size = new System.Drawing.Size(168, 22);
            this.menuExport.Text = "Save &Results As";
            // 
            // menuExportAsText
            // 
            this.menuExportAsText.Name = "menuExportAsText";
            this.menuExportAsText.Size = new System.Drawing.Size(265, 22);
            this.menuExportAsText.Text = "&Text File";
            this.menuExportAsText.Click += new System.EventHandler(this.menuExportAsText_Click);
            // 
            // menuExportAsCSV
            // 
            this.menuExportAsCSV.Name = "menuExportAsCSV";
            this.menuExportAsCSV.Size = new System.Drawing.Size(265, 22);
            this.menuExportAsCSV.Text = "&CSV file (comma separated values)...";
            this.menuExportAsCSV.Click += new System.EventHandler(this.menuExportAsCSV_Click);
            // 
            // menuExportAsXML
            // 
            this.menuExportAsXML.Name = "menuExportAsXML";
            this.menuExportAsXML.Size = new System.Drawing.Size(265, 22);
            this.menuExportAsXML.Text = "X&ML file...";
            this.menuExportAsXML.Click += new System.EventHandler(this.menuExportAsXML_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
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
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopy,
            this.menuSelectAll});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(39, 20);
            this.menuEdit.Text = "&Edit";
            // 
            // menuCopy
            // 
            this.menuCopy.Enabled = false;
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Size = new System.Drawing.Size(122, 22);
            this.menuCopy.Text = "&Copy";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuSelectAll
            // 
            this.menuSelectAll.Enabled = false;
            this.menuSelectAll.Name = "menuSelectAll";
            this.menuSelectAll.Size = new System.Drawing.Size(122, 22);
            this.menuSelectAll.Text = "Select &All";
            this.menuSelectAll.Click += new System.EventHandler(this.menuSelectAll_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideToolStripMenuItem,
            this.maskPasswordStringsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.hideToolStripMenuItem.Text = "&Show users with bad passwords only";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // maskPasswordStringsToolStripMenuItem
            // 
            this.maskPasswordStringsToolStripMenuItem.Name = "maskPasswordStringsToolStripMenuItem";
            this.maskPasswordStringsToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.maskPasswordStringsToolStripMenuItem.Text = "&Show passwords in cleartext";
            this.maskPasswordStringsToolStripMenuItem.Click += new System.EventHandler(this.ContextMenuMaskPasswords_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManageServerGroups,
            this.toolStripMenuItem7,
            this.menuToolsetOptions,
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
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(230, 6);
            // 
            // menuToolsetOptions
            // 
            this.menuToolsetOptions.Name = "menuToolsetOptions";
            this.menuToolsetOptions.Size = new System.Drawing.Size(233, 22);
            this.menuToolsetOptions.Text = "SQL admin toolset &Options...";
            this.menuToolsetOptions.Click += new System.EventHandler(this.menuToolsetOptions_Click);
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
            this.menuAbout.Text = "&About Password Checker";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // ideraTitleBar1
            // 
            this.ideraTitleBar1.ActivateLicenseEventHandler = null;
            this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
            this.ideraTitleBar1.Close = true;
            this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
            this.ideraTitleBar1.IderaProductNameText = "SQL Password Checker";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = true;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(1015, 93);
            this.ideraTitleBar1.TabIndex = 21;
            this.ideraTitleBar1.TrialMode = true;
            this.ideraTitleBar1.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar1_LicenseInfoButtonClick);
            // 
            // Form_Main
            // 
            this.AcceptButton = this.buttonGetResults;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1015, 660);
            this.ControlBox = false;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ideraTitleBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(821, 442);
            this.Name = "Form_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
            this.panelMiddle.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupServerInformation.ResumeLayout(false);
            this.groupUsers.ResumeLayout(false);
            this.groupUsers.PerformLayout();
            this.groupTestType.ResumeLayout(false);
            this.groupTestType.PerformLayout();
            this.groupResults.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuServers.ResumeLayout(false);
            this.contextShowFailedOnly.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panelMiddle;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.ButtonX buttonGetResults;
      private DevComponents.DotNetBar.Controls.GroupPanel groupResults;
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
      private System.Windows.Forms.ToolStripMenuItem menuManageServerGroups;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
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
      private Idera.SqlAdminToolset.Core.Controls.ToolServerSelection ServerSelection;
       private DevComponents.DotNetBar.Controls.GroupPanel groupTestType;
      private DevComponents.DotNetBar.Controls.GroupPanel groupUsers;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioServerRoles;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioAllUsers;
      private DevComponents.DotNetBar.Controls.TextBoxX textSelectedUser;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioSpecificUser;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioDatabaseRoles;
      private DevComponents.DotNetBar.Controls.GroupPanel groupServerInformation;
      private DevComponents.DotNetBar.Controls.TextBoxX textDatabaseRoles;
      private DevComponents.DotNetBar.Controls.TextBoxX textServerRoles;
      private DevComponents.DotNetBar.Controls.ListViewEx listResults;
      private System.Windows.Forms.ColumnHeader columnIcon;
      private System.Windows.Forms.ColumnHeader columnServer;
       private System.Windows.Forms.ColumnHeader columnUsers;
      private System.Windows.Forms.ColumnHeader columnPasswordFailed;
      private System.Windows.Forms.ImageList imageListLockIcons;
      private DevComponents.DotNetBar.Controls.ListViewEx listUserDetails;
      private System.Windows.Forms.ColumnHeader columnResultsIcon;
      private System.Windows.Forms.ColumnHeader columnResultsUserName;
      private System.Windows.Forms.ColumnHeader columnResultsFailedPassword;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioSa;
      private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
      private System.Windows.Forms.ContextMenuStrip contextShowFailedOnly;
      private System.Windows.Forms.ToolStripMenuItem ContextMenuShowFoundPasswordsOnly;
      private DevComponents.DotNetBar.LabelX labelTestedLogins;
      private DevComponents.DotNetBar.Controls.TextBoxX textPasswords;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
      private System.Windows.Forms.ToolStripMenuItem contextMenuCopy_Logins;
      private System.Windows.Forms.ToolStripMenuItem menuEdit;
       private System.Windows.Forms.ToolStripMenuItem menuCopy;
      private System.Windows.Forms.ToolStripMenuItem menuSelectAll;
      private System.Windows.Forms.ToolStripMenuItem contextMenuSelectAll_Logins;
      private System.Windows.Forms.ContextMenuStrip contextMenuServers;
      private System.Windows.Forms.ToolStripMenuItem contextMenuCopy_Servers;
      private System.Windows.Forms.ToolStripMenuItem contextMenuSelectAll_Servers;
       private System.Windows.Forms.ColumnHeader columnHasBadPassword;
      private System.Windows.Forms.SplitContainer splitContainer1;
       private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
       private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem ContextMenuMaskPasswords;
      private System.Windows.Forms.ToolStripMenuItem maskPasswordStringsToolStripMenuItem;
       private DevComponents.DotNetBar.ButtonX buttonShowPasswords;
       private DevComponents.DotNetBar.Controls.TextBoxX textCustom;
       private System.Windows.Forms.LinkLabel linkView50;
       private System.Windows.Forms.LinkLabel linkView10;
       private System.Windows.Forms.LinkLabel linkView800;
       private System.Windows.Forms.LinkLabel linkView2400;
       private System.Windows.Forms.ToolStripMenuItem menuExport;
       private System.Windows.Forms.ToolStripMenuItem menuExportAsText;
       private System.Windows.Forms.ToolStripMenuItem menuExportAsCSV;
       private System.Windows.Forms.ToolStripMenuItem menuExportAsXML;
       private System.Windows.Forms.ColumnHeader columnBlankPasswords;
       private System.Windows.Forms.ColumnHeader columnSameAsLogin;
       private DevComponents.DotNetBar.Controls.CheckBoxX check800;
       private DevComponents.DotNetBar.Controls.CheckBoxX check50;
       private DevComponents.DotNetBar.Controls.CheckBoxX check10;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkOther;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkBlank;
       private DevComponents.DotNetBar.Controls.CheckBoxX check2400;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkCustom;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkTestVariations;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
    }
}

