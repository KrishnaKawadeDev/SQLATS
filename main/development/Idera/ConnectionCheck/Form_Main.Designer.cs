using System.Windows.Forms;

namespace Idera.SqlAdminToolset.ConnectionCheck
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.groupInput = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupServer = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelServer = new DevComponents.DotNetBar.LabelX();
            this.textServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelDatabase = new DevComponents.DotNetBar.LabelX();
            this.textDatabase = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textPort = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelPort = new DevComponents.DotNetBar.LabelX();
            this.buttonBrowseServer = new DevComponents.DotNetBar.ButtonX();
            this.groupCredentials = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textWindowsPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.textWindowsUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.radioWindows = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioSQL = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.textPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelLoginName = new DevComponents.DotNetBar.LabelX();
            this.textLoginName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelPassword = new DevComponents.DotNetBar.LabelX();
            this.buttonTestSQL = new DevComponents.DotNetBar.ButtonX();
            this.buttonTestAll = new DevComponents.DotNetBar.ButtonX();
            this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
            this.buttonTestNetwork = new DevComponents.DotNetBar.ButtonX();
            this.groupResults = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelCancelInProgress = new DevComponents.DotNetBar.LabelX();
            this.treeResults = new System.Windows.Forms.TreeView();
            this.contextMenuCollapse = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.collapseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExpand = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupRecommendation = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textRecommendation = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManageServerGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuToolsetOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContactTechnicalSupport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuManageLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAboutIderaProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.panelMiddle.SuspendLayout();
            this.groupInput.SuspendLayout();
            this.groupServer.SuspendLayout();
            this.groupCredentials.SuspendLayout();
            this.groupResults.SuspendLayout();
            this.contextMenuCollapse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupRecommendation.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.groupInput);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMiddle.Location = new System.Drawing.Point(0, 169);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Padding = new System.Windows.Forms.Padding(6);
            this.panelMiddle.Size = new System.Drawing.Size(1010, 156);
            this.panelMiddle.TabIndex = 14;
            // 
            // groupInput
            // 
            this.groupInput.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupInput.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupInput.Controls.Add(this.groupServer);
            this.groupInput.Controls.Add(this.groupCredentials);
            this.groupInput.Controls.Add(this.buttonTestSQL);
            this.groupInput.Controls.Add(this.buttonTestAll);
            this.groupInput.Controls.Add(this.buttonCancel);
            this.groupInput.Controls.Add(this.buttonTestNetwork);
            this.groupInput.IsShadowEnabled = true;
            this.groupInput.Location = new System.Drawing.Point(6, 6);
            this.groupInput.Name = "groupInput";
            this.groupInput.Size = new System.Drawing.Size(984, 144);
            // 
            // 
            // 
            this.groupInput.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupInput.Style.BackColorGradientAngle = 90;
            this.groupInput.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupInput.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupInput.Style.BorderBottomWidth = 1;
            this.groupInput.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupInput.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupInput.Style.BorderLeftWidth = 1;
            this.groupInput.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupInput.Style.BorderRightWidth = 1;
            this.groupInput.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupInput.Style.BorderTopWidth = 1;
            this.groupInput.Style.Class = "";
            this.groupInput.Style.CornerDiameter = 4;
            this.groupInput.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupInput.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupInput.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupInput.StyleMouseDown.Class = "";
            this.groupInput.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupInput.StyleMouseOver.Class = "";
            this.groupInput.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupInput.TabIndex = 0;
            // 
            // groupServer
            // 
            this.groupServer.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupServer.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupServer.Controls.Add(this.labelServer);
            this.groupServer.Controls.Add(this.textServer);
            this.groupServer.Controls.Add(this.labelDatabase);
            this.groupServer.Controls.Add(this.textDatabase);
            this.groupServer.Controls.Add(this.textPort);
            this.groupServer.Controls.Add(this.labelPort);
            this.groupServer.Controls.Add(this.buttonBrowseServer);
            this.groupServer.Location = new System.Drawing.Point(8, 3);
            this.groupServer.Name = "groupServer";
            this.groupServer.Size = new System.Drawing.Size(442, 88);
            // 
            // 
            // 
            this.groupServer.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupServer.Style.BackColorGradientAngle = 90;
            this.groupServer.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupServer.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupServer.Style.BorderBottomWidth = 1;
            this.groupServer.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupServer.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupServer.Style.BorderLeftWidth = 1;
            this.groupServer.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupServer.Style.BorderRightWidth = 1;
            this.groupServer.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupServer.Style.BorderTopWidth = 1;
            this.groupServer.Style.Class = "";
            this.groupServer.Style.CornerDiameter = 4;
            this.groupServer.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupServer.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupServer.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupServer.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupServer.StyleMouseDown.Class = "";
            this.groupServer.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupServer.StyleMouseOver.Class = "";
            this.groupServer.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupServer.TabIndex = 1;
            // 
            // labelServer
            // 
            this.labelServer.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelServer.BackgroundStyle.Class = "";
            this.labelServer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelServer.Location = new System.Drawing.Point(8, 11);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(62, 12);
            this.labelServer.TabIndex = 2;
            this.labelServer.Text = "&SQL Server:";
            // 
            // textServer
            // 
            this.textServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.textServer.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textServer.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textServer.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textServer.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textServer.Border.Class = "TextBoxBorder";
            this.textServer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textServer.Location = new System.Drawing.Point(74, 8);
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(325, 20);
            this.textServer.TabIndex = 3;
            this.textServer.Text = "(local)";
            this.textServer.WatermarkText = "Enter instance name";
            this.textServer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textServer_KeyPress);
            // 
            // labelDatabase
            // 
            this.labelDatabase.AutoSize = true;
            this.labelDatabase.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelDatabase.BackgroundStyle.Class = "";
            this.labelDatabase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelDatabase.Location = new System.Drawing.Point(8, 34);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(60, 15);
            this.labelDatabase.TabIndex = 5;
            this.labelDatabase.Text = "&Database:";
            // 
            // textDatabase
            // 
            this.textDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.textDatabase.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textDatabase.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textDatabase.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textDatabase.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textDatabase.Border.Class = "TextBoxBorder";
            this.textDatabase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textDatabase.Location = new System.Drawing.Point(74, 32);
            this.textDatabase.Name = "textDatabase";
            this.textDatabase.Size = new System.Drawing.Size(325, 20);
            this.textDatabase.TabIndex = 6;
            this.textDatabase.WatermarkText = "Optional, Enter database name";
            // 
            // textPort
            // 
            this.textPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.textPort.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textPort.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textPort.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textPort.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textPort.Border.Class = "TextBoxBorder";
            this.textPort.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textPort.Location = new System.Drawing.Point(74, 56);
            this.textPort.MaxLength = 5;
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(95, 20);
            this.textPort.TabIndex = 8;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelPort.BackgroundStyle.Class = "";
            this.labelPort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelPort.Location = new System.Drawing.Point(8, 58);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(33, 15);
            this.labelPort.TabIndex = 7;
            this.labelPort.Text = "&Port:";
            // 
            // buttonBrowseServer
            // 
            this.buttonBrowseServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseServer.BackColor = System.Drawing.Color.White;
            this.buttonBrowseServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseServer.Location = new System.Drawing.Point(405, 8);
            this.buttonBrowseServer.Name = "buttonBrowseServer";
            this.buttonBrowseServer.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseServer.TabIndex = 4;
            this.buttonBrowseServer.Text = "...";
            this.buttonBrowseServer.Click += new System.EventHandler(this.buttonBrowseServer_Click);
            // 
            // groupCredentials
            // 
            this.groupCredentials.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupCredentials.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupCredentials.Controls.Add(this.textWindowsPassword);
            this.groupCredentials.Controls.Add(this.labelX1);
            this.groupCredentials.Controls.Add(this.textWindowsUser);
            this.groupCredentials.Controls.Add(this.labelX2);
            this.groupCredentials.Controls.Add(this.radioWindows);
            this.groupCredentials.Controls.Add(this.radioSQL);
            this.groupCredentials.Controls.Add(this.textPassword);
            this.groupCredentials.Controls.Add(this.labelLoginName);
            this.groupCredentials.Controls.Add(this.textLoginName);
            this.groupCredentials.Controls.Add(this.labelPassword);
            this.groupCredentials.Location = new System.Drawing.Point(456, 3);
            this.groupCredentials.Name = "groupCredentials";
            this.groupCredentials.Size = new System.Drawing.Size(519, 88);
            // 
            // 
            // 
            this.groupCredentials.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupCredentials.Style.BackColorGradientAngle = 90;
            this.groupCredentials.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupCredentials.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupCredentials.Style.BorderBottomWidth = 1;
            this.groupCredentials.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupCredentials.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupCredentials.Style.BorderLeftWidth = 1;
            this.groupCredentials.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupCredentials.Style.BorderRightWidth = 1;
            this.groupCredentials.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupCredentials.Style.BorderTopWidth = 1;
            this.groupCredentials.Style.Class = "";
            this.groupCredentials.Style.CornerDiameter = 4;
            this.groupCredentials.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupCredentials.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupCredentials.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupCredentials.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupCredentials.StyleMouseDown.Class = "";
            this.groupCredentials.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupCredentials.StyleMouseOver.Class = "";
            this.groupCredentials.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupCredentials.TabIndex = 9;
            // 
            // textWindowsPassword
            // 
            // 
            // 
            // 
            this.textWindowsPassword.Border.Class = "TextBoxBorder";
            this.textWindowsPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textWindowsPassword.Location = new System.Drawing.Point(84, 54);
            this.textWindowsPassword.Name = "textWindowsPassword";
            this.textWindowsPassword.PasswordChar = '●';
            this.textWindowsPassword.Size = new System.Drawing.Size(164, 20);
            this.textWindowsPassword.TabIndex = 14;
            this.textWindowsPassword.UseSystemPasswordChar = true;
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
            this.labelX1.Location = new System.Drawing.Point(27, 31);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(29, 15);
            this.labelX1.TabIndex = 11;
            this.labelX1.Text = "User:";
            // 
            // textWindowsUser
            // 
            // 
            // 
            // 
            this.textWindowsUser.Border.Class = "TextBoxBorder";
            this.textWindowsUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textWindowsUser.Location = new System.Drawing.Point(84, 29);
            this.textWindowsUser.Name = "textWindowsUser";
            this.textWindowsUser.Size = new System.Drawing.Size(164, 20);
            this.textWindowsUser.TabIndex = 12;
            this.textWindowsUser.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.textWindowsUser.WatermarkText = "Leave blank for current user";
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
            this.labelX2.Location = new System.Drawing.Point(24, 57);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(54, 15);
            this.labelX2.TabIndex = 13;
            this.labelX2.Text = "Password:";
            // 
            // radioWindows
            // 
            this.radioWindows.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioWindows.BackgroundStyle.Class = "";
            this.radioWindows.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioWindows.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioWindows.Checked = true;
            this.radioWindows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioWindows.CheckValue = "Y";
            this.radioWindows.Location = new System.Drawing.Point(7, 3);
            this.radioWindows.Name = "radioWindows";
            this.radioWindows.Size = new System.Drawing.Size(250, 23);
            this.radioWindows.TabIndex = 10;
            this.radioWindows.Text = "Windows Authentication";
            this.radioWindows.CheckedChanged += new System.EventHandler(this.radioSQLorWindows_CheckedChanged);
            // 
            // radioSQL
            // 
            this.radioSQL.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioSQL.BackgroundStyle.Class = "";
            this.radioSQL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioSQL.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioSQL.Location = new System.Drawing.Point(259, 3);
            this.radioSQL.Name = "radioSQL";
            this.radioSQL.Size = new System.Drawing.Size(238, 21);
            this.radioSQL.TabIndex = 15;
            this.radioSQL.Text = "SQL Server Authentication";
            this.radioSQL.CheckedChanged += new System.EventHandler(this.radioSQLorWindows_CheckedChanged);
            // 
            // textPassword
            // 
            // 
            // 
            // 
            this.textPassword.Border.Class = "TextBoxBorder";
            this.textPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textPassword.Enabled = false;
            this.textPassword.Location = new System.Drawing.Point(343, 56);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '●';
            this.textPassword.Size = new System.Drawing.Size(164, 20);
            this.textPassword.TabIndex = 19;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // labelLoginName
            // 
            this.labelLoginName.AutoSize = true;
            this.labelLoginName.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelLoginName.BackgroundStyle.Class = "";
            this.labelLoginName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelLoginName.Location = new System.Drawing.Point(279, 31);
            this.labelLoginName.Name = "labelLoginName";
            this.labelLoginName.Size = new System.Drawing.Size(63, 15);
            this.labelLoginName.TabIndex = 16;
            this.labelLoginName.Text = "Login name:";
            // 
            // textLoginName
            // 
            // 
            // 
            // 
            this.textLoginName.Border.Class = "TextBoxBorder";
            this.textLoginName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textLoginName.Enabled = false;
            this.textLoginName.Location = new System.Drawing.Point(343, 29);
            this.textLoginName.Name = "textLoginName";
            this.textLoginName.Size = new System.Drawing.Size(164, 20);
            this.textLoginName.TabIndex = 17;
            this.textLoginName.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.textLoginName.WatermarkText = "Specify SQL Login";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelPassword.BackgroundStyle.Class = "";
            this.labelPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelPassword.Location = new System.Drawing.Point(279, 58);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(54, 15);
            this.labelPassword.TabIndex = 18;
            this.labelPassword.Text = "Password:";
            // 
            // buttonTestSQL
            // 
            this.buttonTestSQL.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonTestSQL.BackColor = System.Drawing.Color.White;
            this.buttonTestSQL.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonTestSQL.Image = ((System.Drawing.Image)(resources.GetObject("buttonTestSQL.Image")));
            this.buttonTestSQL.Location = new System.Drawing.Point(255, 97);
            this.buttonTestSQL.Name = "buttonTestSQL";
            this.buttonTestSQL.Size = new System.Drawing.Size(230, 34);
            this.buttonTestSQL.TabIndex = 26;
            this.buttonTestSQL.Text = "Test SQL Connection";
            this.buttonTestSQL.Click += new System.EventHandler(this.buttonTestSQL_Click);
            // 
            // buttonTestAll
            // 
            this.buttonTestAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonTestAll.BackColor = System.Drawing.Color.White;
            this.buttonTestAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonTestAll.Image = ((System.Drawing.Image)(resources.GetObject("buttonTestAll.Image")));
            this.buttonTestAll.Location = new System.Drawing.Point(10, 97);
            this.buttonTestAll.Name = "buttonTestAll";
            this.buttonTestAll.Size = new System.Drawing.Size(230, 34);
            this.buttonTestAll.TabIndex = 25;
            this.buttonTestAll.Text = "Run All Tests";
            this.buttonTestAll.Click += new System.EventHandler(this.buttonTestAll_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCancel.BackColor = System.Drawing.Color.White;
            this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCancel.Enabled = false;
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.Location = new System.Drawing.Point(745, 97);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(230, 34);
            this.buttonCancel.TabIndex = 28;
            this.buttonCancel.Text = "Cancel Test";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonTestNetwork
            // 
            this.buttonTestNetwork.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonTestNetwork.BackColor = System.Drawing.Color.White;
            this.buttonTestNetwork.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonTestNetwork.Image = ((System.Drawing.Image)(resources.GetObject("buttonTestNetwork.Image")));
            this.buttonTestNetwork.Location = new System.Drawing.Point(500, 97);
            this.buttonTestNetwork.Name = "buttonTestNetwork";
            this.buttonTestNetwork.Size = new System.Drawing.Size(230, 34);
            this.buttonTestNetwork.TabIndex = 27;
            this.buttonTestNetwork.Text = "Test Network Connections";
            this.buttonTestNetwork.Click += new System.EventHandler(this.buttonTestNetwork_Click);
            // 
            // groupResults
            // 
            this.groupResults.BackColor = System.Drawing.Color.Transparent;
            this.groupResults.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupResults.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupResults.Controls.Add(this.labelCancelInProgress);
            this.groupResults.Controls.Add(this.treeResults);
            this.groupResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupResults.IsShadowEnabled = true;
            this.groupResults.Location = new System.Drawing.Point(0, 0);
            this.groupResults.Name = "groupResults";
            this.groupResults.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.groupResults.Size = new System.Drawing.Size(594, 360);
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
            this.groupResults.TabIndex = 40;
            this.groupResults.Text = "Test Results";
            // 
            // labelCancelInProgress
            // 
            this.labelCancelInProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCancelInProgress.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelCancelInProgress.BackgroundStyle.Class = "";
            this.labelCancelInProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelCancelInProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCancelInProgress.ForeColor = System.Drawing.Color.Red;
            this.labelCancelInProgress.Location = new System.Drawing.Point(8, -106);
            this.labelCancelInProgress.Name = "labelCancelInProgress";
            this.labelCancelInProgress.Size = new System.Drawing.Size(458, 38);
            this.labelCancelInProgress.TabIndex = 1;
            this.labelCancelInProgress.Text = "Cancelling Test ...";
            this.labelCancelInProgress.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelCancelInProgress.Visible = false;
            // 
            // treeResults
            // 
            this.treeResults.ContextMenuStrip = this.contextMenuCollapse;
            this.treeResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeResults.ImageIndex = 0;
            this.treeResults.ImageList = this.imageList1;
            this.treeResults.Location = new System.Drawing.Point(3, 6);
            this.treeResults.Name = "treeResults";
            this.treeResults.SelectedImageIndex = 0;
            this.treeResults.ShowNodeToolTips = true;
            this.treeResults.Size = new System.Drawing.Size(582, 330);
            this.treeResults.TabIndex = 41;
            this.treeResults.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeResults_KeyUp);
            this.treeResults.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeResults_MouseUp);
            // 
            // contextMenuCollapse
            // 
            this.contextMenuCollapse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collapseAllToolStripMenuItem,
            this.contextMenuExpand,
            this.toolStripMenuItem5,
            this.contextMenuCopy});
            this.contextMenuCollapse.Name = "contextMenuCollapse";
            this.contextMenuCollapse.Size = new System.Drawing.Size(226, 76);
            // 
            // collapseAllToolStripMenuItem
            // 
            this.collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
            this.collapseAllToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.collapseAllToolStripMenuItem.Text = "Collapse &All";
            this.collapseAllToolStripMenuItem.Click += new System.EventHandler(this.collapseAllToolStripMenuItem_Click);
            // 
            // contextMenuExpand
            // 
            this.contextMenuExpand.Name = "contextMenuExpand";
            this.contextMenuExpand.Size = new System.Drawing.Size(225, 22);
            this.contextMenuExpand.Text = "&Expand All";
            this.contextMenuExpand.Click += new System.EventHandler(this.contextMenuExpand_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(222, 6);
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.Enabled = false;
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.contextMenuCopy.Size = new System.Drawing.Size(225, 22);
            this.contextMenuCopy.Text = "&Copy All Test Results";
            this.contextMenuCopy.Click += new System.EventHandler(this.contextMenuCopy_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "check2.png");
            this.imageList1.Images.SetKeyName(1, "warning.png");
            this.imageList1.Images.SetKeyName(2, "error.png");
            this.imageList1.Images.SetKeyName(3, "Working.gif");
            this.imageList1.Images.SetKeyName(4, "graph_node.png");
            this.imageList1.Images.SetKeyName(5, "arrow_up_green.png");
            this.imageList1.Images.SetKeyName(6, "arrow_down_blue.png");
            this.imageList1.Images.SetKeyName(7, "bullet_ball_glass_red.png");
            this.imageList1.Images.SetKeyName(8, "bullet_ball_blue.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(6, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupResults);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupRecommendation);
            this.splitContainer1.Size = new System.Drawing.Size(998, 360);
            this.splitContainer1.SplitterDistance = 594;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 5;
            // 
            // groupRecommendation
            // 
            this.groupRecommendation.BackColor = System.Drawing.Color.Transparent;
            this.groupRecommendation.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupRecommendation.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupRecommendation.Controls.Add(this.textRecommendation);
            this.groupRecommendation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupRecommendation.IsShadowEnabled = true;
            this.groupRecommendation.Location = new System.Drawing.Point(0, 0);
            this.groupRecommendation.Name = "groupRecommendation";
            this.groupRecommendation.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.groupRecommendation.Size = new System.Drawing.Size(398, 360);
            // 
            // 
            // 
            this.groupRecommendation.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupRecommendation.Style.BackColorGradientAngle = 90;
            this.groupRecommendation.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupRecommendation.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupRecommendation.Style.BorderBottomWidth = 1;
            this.groupRecommendation.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupRecommendation.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupRecommendation.Style.BorderLeftWidth = 1;
            this.groupRecommendation.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupRecommendation.Style.BorderRightWidth = 1;
            this.groupRecommendation.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupRecommendation.Style.BorderTopWidth = 1;
            this.groupRecommendation.Style.Class = "";
            this.groupRecommendation.Style.CornerDiameter = 4;
            this.groupRecommendation.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupRecommendation.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupRecommendation.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupRecommendation.StyleMouseDown.Class = "";
            this.groupRecommendation.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupRecommendation.StyleMouseOver.Class = "";
            this.groupRecommendation.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupRecommendation.TabIndex = 42;
            this.groupRecommendation.Text = "Recommendation";
            // 
            // textRecommendation
            // 
            this.textRecommendation.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.textRecommendation.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textRecommendation.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textRecommendation.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textRecommendation.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textRecommendation.Border.Class = "TextBoxBorder";
            this.textRecommendation.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textRecommendation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textRecommendation.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textRecommendation.Location = new System.Drawing.Point(3, 6);
            this.textRecommendation.Multiline = true;
            this.textRecommendation.Name = "textRecommendation";
            this.textRecommendation.ReadOnly = true;
            this.textRecommendation.Size = new System.Drawing.Size(386, 330);
            this.textRecommendation.TabIndex = 43;
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
            this.panelTop.Size = new System.Drawing.Size(1010, 52);
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
            this.labelTitle.Size = new System.Drawing.Size(330, 52);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Connection Check</font></b> ";
            // 
            // labelSubtitle
            // 
            // 
            // 
            // 
            this.labelSubtitle.BackgroundStyle.Class = "";
            this.labelSubtitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.Location = new System.Drawing.Point(404, -2);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(433, 52);
            this.labelSubtitle.TabIndex = 6;
            this.labelSubtitle.Text = "Check common issues surrounding SQL Server connectivity problems";
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
            this.panelBottom.Controls.Add(this.splitContainer1);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 325);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.panelBottom.Size = new System.Drawing.Size(1010, 369);
            this.panelBottom.TabIndex = 17;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuTools,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 93);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1010, 24);
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
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopy});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(39, 20);
            this.menuEdit.Text = "&Edit";
            // 
            // menuCopy
            // 
            this.menuCopy.Enabled = false;
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuCopy.Size = new System.Drawing.Size(225, 22);
            this.menuCopy.Text = "&Copy All Test Results";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManageServerGroups,
            this.menuLaunchpad,
            this.toolStripMenuItem4,
            this.menuToolsetOptions});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(47, 20);
            this.menuTools.Text = "&Tools";
            // 
            // menuManageServerGroups
            // 
            this.menuManageServerGroups.Name = "menuManageServerGroups";
            this.menuManageServerGroups.Size = new System.Drawing.Size(233, 22);
            this.menuManageServerGroups.Text = "Manage Server &Groups...";
            this.menuManageServerGroups.Click += new System.EventHandler(this.menuManageServerGroups_Click);
            // 
            // menuLaunchpad
            // 
            this.menuLaunchpad.Name = "menuLaunchpad";
            this.menuLaunchpad.Size = new System.Drawing.Size(233, 22);
            this.menuLaunchpad.Text = "SQL admin toolset &Launchpad";
            this.menuLaunchpad.Click += new System.EventHandler(this.menuLaunchpad_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(230, 6);
            // 
            // menuToolsetOptions
            // 
            this.menuToolsetOptions.Name = "menuToolsetOptions";
            this.menuToolsetOptions.Size = new System.Drawing.Size(233, 22);
            this.menuToolsetOptions.Text = "SQL admin toolset &Options...";
            this.menuToolsetOptions.Click += new System.EventHandler(this.menuToolsetOptions_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowHelp,
            this.menuContactTechnicalSupport,
            this.toolStripMenuItem2,
            this.menuManageLicense,
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
            // menuManageLicense
            // 
            this.menuManageLicense.Name = "menuManageLicense";
            this.menuManageLicense.Size = new System.Drawing.Size(216, 22);
            this.menuManageLicense.Text = "Manage &License";
            this.menuManageLicense.Click += new System.EventHandler(this.menuManageLicense_Click);
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
            this.menuAbout.Text = "&About Connection Check";
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
            this.ideraTitleBar1.IderaProductNameText = "SQL Connection Check";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.IsFormLocked = false;
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = true;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(1010, 93);
            this.ideraTitleBar1.TabIndex = 19;
            this.ideraTitleBar1.TrialMode = true;
            this.ideraTitleBar1.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar1_LicenseInfoButtonClick);
            // 
            // Form_Main
            // 
            this.AcceptButton = this.buttonTestAll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1010, 694);
            this.ControlBox = false;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ideraTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(104, 694);
            this.Name = "Form_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
            this.panelMiddle.ResumeLayout(false);
            this.groupInput.ResumeLayout(false);
            this.groupServer.ResumeLayout(false);
            this.groupServer.PerformLayout();
            this.groupCredentials.ResumeLayout(false);
            this.groupCredentials.PerformLayout();
            this.groupResults.ResumeLayout(false);
            this.contextMenuCollapse.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupRecommendation.ResumeLayout(false);
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
      private DevComponents.DotNetBar.Controls.GroupPanel groupInput;
      private DevComponents.DotNetBar.Controls.TextBoxX textServer;
      private DevComponents.DotNetBar.LabelX labelServer;
      private DevComponents.DotNetBar.ButtonX buttonTestNetwork;
      private DevComponents.DotNetBar.ButtonX buttonBrowseServer;
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
      private System.Windows.Forms.ToolStripMenuItem menuToolsetOptions;
      private System.Windows.Forms.ToolStripMenuItem menuLaunchpad;
      private System.Windows.Forms.ToolStripMenuItem menuHelp;
      private System.Windows.Forms.ToolStripMenuItem menuShowHelp;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem menuAboutIderaProducts;
      private System.Windows.Forms.ToolStripMenuItem menuContactTechnicalSupport;
      private System.Windows.Forms.ToolStripMenuItem menuCheckForUpdates;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem menuAbout;
      private System.Windows.Forms.ToolStripMenuItem menuManageServerGroups;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
      private System.Windows.Forms.ToolStripMenuItem menuEdit;
      private System.Windows.Forms.ToolStripMenuItem menuCopy;
      private DevComponents.DotNetBar.Controls.TextBoxX textRecommendation;
      private DevComponents.DotNetBar.ButtonX buttonCancel;
      private DevComponents.DotNetBar.Controls.TextBoxX textPort;
      private DevComponents.DotNetBar.LabelX labelPort;
      private DevComponents.DotNetBar.Controls.TextBoxX textDatabase;
      private DevComponents.DotNetBar.LabelX labelDatabase;
      private DevComponents.DotNetBar.ButtonX buttonTestSQL;
      private DevComponents.DotNetBar.ButtonX buttonTestAll;
      private DevComponents.DotNetBar.Controls.TextBoxX textPassword;
      private DevComponents.DotNetBar.Controls.TextBoxX textLoginName;
      private DevComponents.DotNetBar.LabelX labelPassword;
      private DevComponents.DotNetBar.LabelX labelLoginName;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioSQL;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioWindows;
      private DevComponents.DotNetBar.Controls.GroupPanel groupServer;
      private DevComponents.DotNetBar.Controls.GroupPanel groupCredentials;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private DevComponents.DotNetBar.Controls.GroupPanel groupRecommendation;
      private System.Windows.Forms.TreeView treeResults;
      private System.Windows.Forms.ImageList imageList1;
      private System.Windows.Forms.ContextMenuStrip contextMenuCollapse;
      private System.Windows.Forms.ToolStripMenuItem collapseAllToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem contextMenuExpand;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
      private System.Windows.Forms.ToolStripMenuItem contextMenuCopy;
      private DevComponents.DotNetBar.Controls.TextBoxX textWindowsPassword;
      private DevComponents.DotNetBar.LabelX labelX1;
      private DevComponents.DotNetBar.Controls.TextBoxX textWindowsUser;
      private DevComponents.DotNetBar.LabelX labelX2;
      private DevComponents.DotNetBar.LabelX labelCancelInProgress;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
        private ToolStripMenuItem menuManageLicense;
    }
}

