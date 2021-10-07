using System.Linq;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.PatchAnalyzer
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Unknown SQL Server Version", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("SQL Server 2017", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("SQL Server 2016", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("SQL Server 2014", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("SQL Server 2012", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("SQL Server 2008 R2", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("SQL Server 2008", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("SQL Server 2005", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("SQL Server 2000", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("SQL Server 7.0", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("SQL Server 6.5", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "MERICKSONL2\\TestInstance",
            "SQL Server 2005",
            "SP4 + hotfixes",
            "Developer Edition",
            "9.00.1234",
            "Yes",
            "Yes",
            "Extended Support Only after 12/25/2008",
            "Yes"}, 0);
            System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("SQL Server 2008", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup13 = new System.Windows.Forms.ListViewGroup("SQL Server 2005", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup14 = new System.Windows.Forms.ListViewGroup("SQL Server 2000", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup15 = new System.Windows.Forms.ListViewGroup("SQL Server 7.0", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup16 = new System.Windows.Forms.ListViewGroup("SQL Server 6.5", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup17 = new System.Windows.Forms.ListViewGroup("Unknown SQL Server Version", System.Windows.Forms.HorizontalAlignment.Left);
            
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "MERICKSONL2\\TestInstance",
            "Microsoft Windows XP Professional",
            "5.1.2600 Build 2600",
            "Service Pack 2",
            "Yes",
            "Extended Support Only after 12/25/2008"}, -1);
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ServerSelection = new Idera.SqlAdminToolset.Core.Controls.ToolServerSelection();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelPatchVersionValue = new DevComponents.DotNetBar.LabelX();
            this.linkDisplayVersionList = new System.Windows.Forms.LinkLabel();
            this.linkCheckVersionList = new System.Windows.Forms.LinkLabel();
            this.labelPatchVersion = new DevComponents.DotNetBar.LabelX();
            this.buttonLoadServerData = new DevComponents.DotNetBar.ButtonX();
            this.labelSQLServers = new DevComponents.DotNetBar.LabelX();
            this.listSQL = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnInstance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRelease = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEdition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnBuild = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHotfixAvailable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSupported = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnKb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuViewAvailableHotfixes = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuViewKBArticle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuShowGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExportAsCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExportAsXML = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExportAsDatatable = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.buttonObtainingUpgrades = new DevComponents.DotNetBar.ButtonX();
            this.buttonViewAvailableHotfixes = new DevComponents.DotNetBar.ButtonX();
            this.buttonCopyToClipboard = new DevComponents.DotNetBar.ButtonX();
            this.buttonViewKbArticle = new DevComponents.DotNetBar.ButtonX();
            this.groupStatistics = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelServer5 = new DevComponents.DotNetBar.LabelX();
            this.labelServer3 = new DevComponents.DotNetBar.LabelX();
            this.labelServer2 = new DevComponents.DotNetBar.LabelX();
            this.labelServer2Title = new DevComponents.DotNetBar.LabelX();
            this.labelServer1 = new DevComponents.DotNetBar.LabelX();
            this.labelServer1Title = new DevComponents.DotNetBar.LabelX();
            this.labelServer17 = new DevComponents.DotNetBar.LabelX();
            this.labelServer17Title = new DevComponents.DotNetBar.LabelX();
            this.labelServer5Title = new DevComponents.DotNetBar.LabelX();
            this.labelServer3Title = new DevComponents.DotNetBar.LabelX();
            this.labelServer8 = new DevComponents.DotNetBar.LabelX();
            this.labelServer7 = new DevComponents.DotNetBar.LabelX();
            this.labelServer6 = new DevComponents.DotNetBar.LabelX();
            this.labelServer4 = new DevComponents.DotNetBar.LabelX();
            this.labelServer7Title = new DevComponents.DotNetBar.LabelX();
            this.labelserver6Title = new DevComponents.DotNetBar.LabelX();
            this.labelServer8Title = new DevComponents.DotNetBar.LabelX();
            this.labelServer4Title = new DevComponents.DotNetBar.LabelX();
            this.labelUnsupported = new DevComponents.DotNetBar.LabelX();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelSupported = new DevComponents.DotNetBar.LabelX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelTotal = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxDatabasesNeverBackedUp = new System.Windows.Forms.PictureBox();
            this.tabSqlServer = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.listViewEx1 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnInstance2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOSName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOSLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOSVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSupported2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSupportStatus2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tabWindows = new DevComponents.DotNetBar.TabItem(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsXML = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsDataTable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowGroups = new System.Windows.Forms.ToolStripMenuItem();
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
            this.groupPanel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.groupStatistics.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDatabasesNeverBackedUp)).BeginInit();
            this.tabControlPanel2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
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
            this.panelMiddle.Size = new System.Drawing.Size(1017, 69);
            this.panelMiddle.TabIndex = 14;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.ServerSelection);
            this.groupPanel1.Controls.Add(this.groupPanel2);
            this.groupPanel1.Controls.Add(this.buttonLoadServerData);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.IsShadowEnabled = true;
            this.groupPanel1.Location = new System.Drawing.Point(6, 6);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1005, 57);
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
            // ServerSelection
            // 
            this.ServerSelection.BackColor = System.Drawing.Color.Transparent;
            this.ServerSelection.Caption = "";
            this.ServerSelection.CredentialsVisible = true;
            this.ServerSelection.Location = new System.Drawing.Point(0, 4);
            this.ServerSelection.MinimumSize = new System.Drawing.Size(290, 40);
            this.ServerSelection.Name = "ServerSelection";
            this.ServerSelection.SelectionOptions = Idera.SqlAdminToolset.Core.Controls.ServerSelectionOptions.ServersAndGroups;
            this.ServerSelection.Size = new System.Drawing.Size(396, 48);
            this.ServerSelection.TabIndex = 11;
            this.ServerSelection.TextChangedEventHandler = null;
            this.ServerSelection.TextChanged += new System.EventHandler(this.ServerSelection_TextChanged);
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.labelPatchVersionValue);
            this.groupPanel2.Controls.Add(this.linkDisplayVersionList);
            this.groupPanel2.Controls.Add(this.linkCheckVersionList);
            this.groupPanel2.Controls.Add(this.labelPatchVersion);
            this.groupPanel2.Location = new System.Drawing.Point(597, 4);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(339, 45);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupPanel2.Style.BackColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.Class = "";
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.Class = "";
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.Class = "";
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 2;
            // 
            // labelPatchVersionValue
            // 
            this.labelPatchVersionValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelPatchVersionValue.BackgroundStyle.Class = "";
            this.labelPatchVersionValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelPatchVersionValue.Location = new System.Drawing.Point(62, 0);
            this.labelPatchVersionValue.Name = "labelPatchVersionValue";
            this.labelPatchVersionValue.Size = new System.Drawing.Size(61, 40);
            this.labelPatchVersionValue.TabIndex = 4;
            this.labelPatchVersionValue.Text = "12/25/2008";
            this.labelPatchVersionValue.WordWrap = true;
            // 
            // linkDisplayVersionList
            // 
            this.linkDisplayVersionList.Location = new System.Drawing.Point(241, 0);
            this.linkDisplayVersionList.Name = "linkDisplayVersionList";
            this.linkDisplayVersionList.Size = new System.Drawing.Size(87, 40);
            this.linkDisplayVersionList.TabIndex = 6;
            this.linkDisplayVersionList.TabStop = true;
            this.linkDisplayVersionList.Text = "Display Build List";
            this.linkDisplayVersionList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkDisplayVersionList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDisplayVersionList_LinkClicked);
            // 
            // linkCheckVersionList
            // 
            this.linkCheckVersionList.Location = new System.Drawing.Point(131, 0);
            this.linkCheckVersionList.Name = "linkCheckVersionList";
            this.linkCheckVersionList.Size = new System.Drawing.Size(104, 40);
            this.linkCheckVersionList.TabIndex = 5;
            this.linkCheckVersionList.TabStop = true;
            this.linkCheckVersionList.Text = "Check for New List";
            this.linkCheckVersionList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkCheckVersionList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCheckVersionList_LinkClicked);
            // 
            // labelPatchVersion
            // 
            this.labelPatchVersion.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelPatchVersion.BackgroundStyle.Class = "";
            this.labelPatchVersion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelPatchVersion.Location = new System.Drawing.Point(9, 0);
            this.labelPatchVersion.Name = "labelPatchVersion";
            this.labelPatchVersion.Size = new System.Drawing.Size(55, 40);
            this.labelPatchVersion.TabIndex = 3;
            this.labelPatchVersion.Text = "Build List:";
            this.labelPatchVersion.WordWrap = true;
            // 
            // buttonLoadServerData
            // 
            this.buttonLoadServerData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonLoadServerData.BackColor = System.Drawing.Color.White;
            this.buttonLoadServerData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonLoadServerData.Enabled = false;
            this.buttonLoadServerData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadServerData.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoadServerData.Image")));
            this.buttonLoadServerData.Location = new System.Drawing.Point(399, 3);
            this.buttonLoadServerData.Name = "buttonLoadServerData";
            this.buttonLoadServerData.Size = new System.Drawing.Size(192, 46);
            this.buttonLoadServerData.TabIndex = 1;
            this.buttonLoadServerData.Text = "Load Version Information";
            this.buttonLoadServerData.Click += new System.EventHandler(this.buttonGetResults_Click);
            // 
            // labelSQLServers
            // 
            this.labelSQLServers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSQLServers.AutoSize = true;
            this.labelSQLServers.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelSQLServers.BackgroundStyle.Class = "";
            this.labelSQLServers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSQLServers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSQLServers.Location = new System.Drawing.Point(6, 112);
            this.labelSQLServers.Name = "labelSQLServers";
            this.labelSQLServers.Size = new System.Drawing.Size(77, 17);
            this.labelSQLServers.TabIndex = 54;
            this.labelSQLServers.Text = "SQL Servers";
            // 
            // listSQL
            // 
            this.listSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.listSQL.Border.Class = "ListViewBorder";
            this.listSQL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listSQL.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnIcon,
            this.columnInstance,
            this.columnRelease,
            this.columnLevel,
            this.columnEdition,
            this.columnBuild,
            this.columnHotfixAvailable,
            this.columnSupported,
            this.columnStatus,
            this.columnKb});
            this.listSQL.ContextMenuStrip = this.contextMenuStrip1;
            this.listSQL.FullRowSelect = true;
            listViewGroup1.Header = "Unknown SQL Server Version";
            listViewGroup1.Name = "groupUnknown";
            //listViewGroup2.Header = "SQL Server 2016";
            //listViewGroup2.Name = "group2016";
            //listViewGroup3.Header = "SQL Server 2014";
            //listViewGroup3.Name = "group2014";
            //listViewGroup4.Header = "SQL Server 2012";
            //listViewGroup4.Name = "group2012";
            //listViewGroup5.Header = "SQL Server 2008 R2";
            //listViewGroup5.Name = "group2008R2";
            //listViewGroup6.Header = "SQL Server 2008";
            //listViewGroup6.Name = "group2008";
            //listViewGroup7.Header = "SQL Server 2005";
            //listViewGroup7.Name = "group2005";
            //listViewGroup8.Header = "SQL Server 2000";
            //listViewGroup8.Name = "group 2000";
            listViewGroup10.Header = "SQL Server 7.0";
            listViewGroup10.Name = "group70";
            listViewGroup11.Header = "SQL Server 6.5";
            listViewGroup11.Name = "group65";
            //this.listSQL.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            //listViewGroup1,
            ////listViewGroup2,
            ////listViewGroup3,
            ////listViewGroup4,
            ////listViewGroup5,
            ////listViewGroup6,
            ////listViewGroup7,
            ////listViewGroup8,
            ////listViewGroup9,
            ////listViewGroup10
            //});
            //foreach (string sqlServerVersion in SQLServerVersion.SqlServerVersionList.OrderByDescending(x => x.Major).Select(x => x.Product).Distinct())
            //{
            //    if(!string.IsNullOrEmpty(sqlServerVersion))
            //    {
            //        var grp = new System.Windows.Forms.ListViewGroup(sqlServerVersion, HorizontalAlignment.Left);
            //        this.listSQL.Groups.Add(grp);
            //    }
            //}
            //this.listSQL.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            //listViewGroup9,
            //listViewGroup10
            //});
            this.listSQL.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listSQL.Location = new System.Drawing.Point(6, 131);
            this.listSQL.Name = "listSQL";
            this.listSQL.Size = new System.Drawing.Size(993, 289);
            this.listSQL.SmallImageList = this.imageList;
            this.listSQL.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listSQL.TabIndex = 8;
            this.listSQL.UseCompatibleStateImageBehavior = false;
            this.listSQL.View = System.Windows.Forms.View.Details;
            this.listSQL.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listSQL_ColumnClick);
            this.listSQL.SelectedIndexChanged += new System.EventHandler(this.listSQL_SelectedIndexChanged);
            this.listSQL.DoubleClick += new System.EventHandler(this.listSQL_DoubleClick);
            // 
            // columnIcon
            // 
            this.columnIcon.Text = "";
            this.columnIcon.Width = 24;
            // 
            // columnInstance
            // 
            this.columnInstance.Text = "SQL Server";
            this.columnInstance.Width = 158;
            // 
            // columnRelease
            // 
            this.columnRelease.Text = "Release";
            this.columnRelease.Width = 100;
            // 
            // columnLevel
            // 
            this.columnLevel.Text = "Level";
            this.columnLevel.Width = 84;
            // 
            // columnEdition
            // 
            this.columnEdition.Text = "Edition";
            this.columnEdition.Width = 100;
            // 
            // columnBuild
            // 
            this.columnBuild.Text = "Build";
            this.columnBuild.Width = 64;
            // 
            // columnHotfixAvailable
            // 
            this.columnHotfixAvailable.Text = "Updates Available";
            this.columnHotfixAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHotfixAvailable.Width = 104;
            // 
            // columnSupported
            // 
            this.columnSupported.Text = "Supported";
            this.columnSupported.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnSupported.Width = 67;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Support Status";
            this.columnStatus.Width = 210;
            // 
            // columnKb
            // 
            this.columnKb.Text = "KB Available";
            this.columnKb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnKb.Width = 80;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuViewAvailableHotfixes,
            this.contextMenuViewKBArticle,
            this.toolStripMenuItem8,
            this.contextMenuShowGroups,
            this.toolStripMenuItem9,
            this.contextMenuCopy,
            this.contextMenuSelectAll,
            this.toolStripMenuItem6,
            this.contextMenuExport});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(283, 154);
            // 
            // contextMenuViewAvailableHotfixes
            // 
            this.contextMenuViewAvailableHotfixes.Name = "contextMenuViewAvailableHotfixes";
            this.contextMenuViewAvailableHotfixes.Size = new System.Drawing.Size(282, 22);
            this.contextMenuViewAvailableHotfixes.Text = "View &Available Updates";
            this.contextMenuViewAvailableHotfixes.Click += new System.EventHandler(this.contextMenuViewAvailableHotfixes_Click);
            // 
            // contextMenuViewKBArticle
            // 
            this.contextMenuViewKBArticle.Name = "contextMenuViewKBArticle";
            this.contextMenuViewKBArticle.Size = new System.Drawing.Size(282, 22);
            this.contextMenuViewKBArticle.Text = "&View Microsoft Knowledge Base Article ";
            this.contextMenuViewKBArticle.Click += new System.EventHandler(this.contextMenuViewKBArticle_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(279, 6);
            // 
            // contextMenuShowGroups
            // 
            this.contextMenuShowGroups.Checked = true;
            this.contextMenuShowGroups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.contextMenuShowGroups.Name = "contextMenuShowGroups";
            this.contextMenuShowGroups.Size = new System.Drawing.Size(282, 22);
            this.contextMenuShowGroups.Text = "Show &Groups";
            this.contextMenuShowGroups.Click += new System.EventHandler(this.contextMenuShowGroups_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(279, 6);
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.Enabled = false;
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.contextMenuCopy.Size = new System.Drawing.Size(282, 22);
            this.contextMenuCopy.Text = "&Copy";
            this.contextMenuCopy.Click += new System.EventHandler(this.contextMenuCopy_Click);
            // 
            // contextMenuSelectAll
            // 
            this.contextMenuSelectAll.Enabled = false;
            this.contextMenuSelectAll.Name = "contextMenuSelectAll";
            this.contextMenuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.contextMenuSelectAll.Size = new System.Drawing.Size(282, 22);
            this.contextMenuSelectAll.Text = "Select &All";
            this.contextMenuSelectAll.Click += new System.EventHandler(this.contextMenuSelectAll_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(279, 6);
            // 
            // contextMenuExport
            // 
            this.contextMenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuExportAsCSV,
            this.contextMenuExportAsXML,
            this.contextMenuExportAsDatatable});
            this.contextMenuExport.Enabled = false;
            this.contextMenuExport.Name = "contextMenuExport";
            this.contextMenuExport.Size = new System.Drawing.Size(282, 22);
            this.contextMenuExport.Text = "Save &Results As";
            // 
            // contextMenuExportAsCSV
            // 
            this.contextMenuExportAsCSV.Name = "contextMenuExportAsCSV";
            this.contextMenuExportAsCSV.Size = new System.Drawing.Size(258, 22);
            this.contextMenuExportAsCSV.Text = "CSV File (comma separated values)";
            this.contextMenuExportAsCSV.Click += new System.EventHandler(this.contextMenuExportAsCSV_Click);
            // 
            // contextMenuExportAsXML
            // 
            this.contextMenuExportAsXML.Name = "contextMenuExportAsXML";
            this.contextMenuExportAsXML.Size = new System.Drawing.Size(258, 22);
            this.contextMenuExportAsXML.Text = "&XML File";
            this.contextMenuExportAsXML.Click += new System.EventHandler(this.contextMenuExportAsXML_Click);
            // 
            // contextMenuExportAsDatatable
            // 
            this.contextMenuExportAsDatatable.Name = "contextMenuExportAsDatatable";
            this.contextMenuExportAsDatatable.Size = new System.Drawing.Size(258, 22);
            this.contextMenuExportAsDatatable.Text = "&Datatable";
            this.contextMenuExportAsDatatable.Click += new System.EventHandler(this.contextMenuExportAsDatatable_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "check.png");
            this.imageList.Images.SetKeyName(1, "error.png");
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
            this.panelTop.Size = new System.Drawing.Size(1017, 52);
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
            this.labelTitle.Size = new System.Drawing.Size(300, 52);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.TabStop = false;
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Patch Analyzer</font></b> ";
            // 
            // labelSubtitle
            // 
            // 
            // 
            // 
            this.labelSubtitle.BackgroundStyle.Class = "";
            this.labelSubtitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.Location = new System.Drawing.Point(370, 0);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(438, 52);
            this.labelSubtitle.TabIndex = 6;
            this.labelSubtitle.Text = "Find out if your SQL Servers are up to date with the latest available patches";
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
            this.panelBottom.Controls.Add(this.tabControl1);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 238);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.panelBottom.Size = new System.Drawing.Size(1017, 470);
            this.panelBottom.TabIndex = 17;
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.White;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(6, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1005, 461);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabSqlServer);
            this.tabControl1.Tabs.Add(this.tabWindows);
            this.tabControl1.TabsVisible = false;
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.buttonObtainingUpgrades);
            this.tabControlPanel1.Controls.Add(this.buttonViewAvailableHotfixes);
            this.tabControlPanel1.Controls.Add(this.buttonCopyToClipboard);
            this.tabControlPanel1.Controls.Add(this.buttonViewKbArticle);
            this.tabControlPanel1.Controls.Add(this.labelSQLServers);
            this.tabControlPanel1.Controls.Add(this.listSQL);
            this.tabControlPanel1.Controls.Add(this.groupStatistics);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 0);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(1005, 461);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabSqlServer;
            // 
            // buttonObtainingUpgrades
            // 
            this.buttonObtainingUpgrades.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonObtainingUpgrades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonObtainingUpgrades.BackColor = System.Drawing.Color.White;
            this.buttonObtainingUpgrades.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonObtainingUpgrades.Image = ((System.Drawing.Image)(resources.GetObject("buttonObtainingUpgrades.Image")));
            this.buttonObtainingUpgrades.Location = new System.Drawing.Point(181, 426);
            this.buttonObtainingUpgrades.Name = "buttonObtainingUpgrades";
            this.buttonObtainingUpgrades.Size = new System.Drawing.Size(249, 29);
            this.buttonObtainingUpgrades.TabIndex = 58;
            this.buttonObtainingUpgrades.Text = "&SQL Server Downloads / Support Lifecycle";
            this.buttonObtainingUpgrades.Click += new System.EventHandler(this.buttonObtainingUpgrades_Click);
            // 
            // buttonViewAvailableHotfixes
            // 
            this.buttonViewAvailableHotfixes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonViewAvailableHotfixes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonViewAvailableHotfixes.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonViewAvailableHotfixes.Enabled = false;
            this.buttonViewAvailableHotfixes.Image = ((System.Drawing.Image)(resources.GetObject("buttonViewAvailableHotfixes.Image")));
            this.buttonViewAvailableHotfixes.Location = new System.Drawing.Point(688, 426);
            this.buttonViewAvailableHotfixes.Name = "buttonViewAvailableHotfixes";
            this.buttonViewAvailableHotfixes.Size = new System.Drawing.Size(153, 29);
            this.buttonViewAvailableHotfixes.TabIndex = 60;
            this.buttonViewAvailableHotfixes.Text = "View Available Updates";
            this.buttonViewAvailableHotfixes.Click += new System.EventHandler(this.buttonViewAvailableHotfixes_Click);
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCopyToClipboard.BackColor = System.Drawing.Color.White;
            this.buttonCopyToClipboard.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCopyToClipboard.Enabled = false;
            this.buttonCopyToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyToClipboard.Image")));
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(6, 426);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(169, 29);
            this.buttonCopyToClipboard.TabIndex = 57;
            this.buttonCopyToClipboard.Text = "&Copy Results To Clipboard";
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // buttonViewKbArticle
            // 
            this.buttonViewKbArticle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonViewKbArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonViewKbArticle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonViewKbArticle.Enabled = false;
            this.buttonViewKbArticle.Image = ((System.Drawing.Image)(resources.GetObject("buttonViewKbArticle.Image")));
            this.buttonViewKbArticle.Location = new System.Drawing.Point(847, 426);
            this.buttonViewKbArticle.Name = "buttonViewKbArticle";
            this.buttonViewKbArticle.Size = new System.Drawing.Size(152, 29);
            this.buttonViewKbArticle.TabIndex = 61;
            this.buttonViewKbArticle.Text = "View the KB Article";
            this.buttonViewKbArticle.Click += new System.EventHandler(this.buttonViewKbArticle_Click);
            // 
            // groupStatistics
            // 
            this.groupStatistics.BackColor = System.Drawing.Color.Transparent;
            this.groupStatistics.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupStatistics.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupStatistics.Controls.Add(this.groupBox1);
            this.groupStatistics.Controls.Add(this.labelUnsupported);
            this.groupStatistics.Controls.Add(this.pictureBox2);
            this.groupStatistics.Controls.Add(this.labelSupported);
            this.groupStatistics.Controls.Add(this.pictureBox1);
            this.groupStatistics.Controls.Add(this.labelTotal);
            this.groupStatistics.Controls.Add(this.pictureBoxDatabasesNeverBackedUp);
            this.groupStatistics.Location = new System.Drawing.Point(6, 4);
            this.groupStatistics.Name = "groupStatistics";
            this.groupStatistics.Size = new System.Drawing.Size(990, 101);
            // 
            // 
            // 
            this.groupStatistics.Style.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupStatistics.Style.BackColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.groupStatistics.Style.BackColorGradientAngle = 90;
            this.groupStatistics.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupStatistics.Style.BorderBottomWidth = 1;
            this.groupStatistics.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupStatistics.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupStatistics.Style.BorderLeftWidth = 1;
            this.groupStatistics.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupStatistics.Style.BorderRightWidth = 1;
            this.groupStatistics.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupStatistics.Style.BorderTopWidth = 1;
            this.groupStatistics.Style.Class = "";
            this.groupStatistics.Style.CornerDiameter = 4;
            this.groupStatistics.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupStatistics.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupStatistics.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupStatistics.StyleMouseDown.Class = "";
            this.groupStatistics.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupStatistics.StyleMouseOver.Class = "";
            this.groupStatistics.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupStatistics.TabIndex = 53;
            this.groupStatistics.Text = "Summary Information";
            // 
            // groupBox1
            // 
           // this.groupBox1.Controls.Add(this.label2008R2);
           // this.groupBox1.Controls.Add(this.label2012);
           // this.groupBox1.Controls.Add(this.label2014);
           // this.groupBox1.Controls.Add(this.label2014Title);
           // this.groupBox1.Controls.Add(this.label2016);
           // this.groupBox1.Controls.Add(this.label2016Title);
           // this.groupBox1.Controls.Add(this.label2008R2Title);
           // this.groupBox1.Controls.Add(this.label2012Title);
           //// this.groupBox1.Controls.Add(this.label70);
           // this.groupBox1.Controls.Add(this.label2000);
           // this.groupBox1.Controls.Add(this.label2005);
           // this.groupBox1.Controls.Add(this.label2008);
           // this.groupBox1.Controls.Add(this.label2000Title);
           // this.groupBox1.Controls.Add(this.label2005Title);
            //this.groupBox1.Controls.Add(this.label70Title);
           // this.groupBox1.Controls.Add(this.label2008Title);
            this.groupBox1.Location = new System.Drawing.Point(256, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 73);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SQL Servers by Release";
            // 
            // label2008R2
            // 
            this.labelServer5.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.labelServer5.BackgroundStyle.Class = "";
            this.labelServer5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer5.Location = new System.Drawing.Point(500, 20);
            this.labelServer5.Name = "label2008R2";
            this.labelServer5.Size = new System.Drawing.Size(44, 16);
            this.labelServer5.TabIndex = 81;
            this.labelServer5.WordWrap = true;
            // 
            // label2012
            // 
            this.labelServer3.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.labelServer3.BackgroundStyle.Class = "";
            this.labelServer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer3.Location = new System.Drawing.Point(324, 20);
            this.labelServer3.Name = "label2012";
            this.labelServer3.Size = new System.Drawing.Size(48, 16);
            this.labelServer3.TabIndex = 80;
            this.labelServer3.WordWrap = true;
            // 
            // label2014
            // 
            this.labelServer2.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.labelServer2.BackgroundStyle.Class = "";
            this.labelServer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer2.Location = new System.Drawing.Point(129, 44);
            this.labelServer2.Name = "label2014";
            this.labelServer2.Size = new System.Drawing.Size(48, 16);
            this.labelServer2.TabIndex = 82;
            this.labelServer2.WordWrap = true;
            // 
            // label2014Title
            // 
            // 
            // 
            // 
            this.labelServer2Title.BackgroundStyle.Class = "";
            this.labelServer2Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer2Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServer2Title.Location = new System.Drawing.Point(17, 44);
            this.labelServer2Title.Name = "label2014Title";
            this.labelServer2Title.Size = new System.Drawing.Size(107, 16); 
            this.labelServer2Title.TabIndex = 78;
            this.labelServer2Title.Text = string.Empty;
            this.labelServer2Title.WordWrap = true;
            // 
            // label2016
            // 
            this.labelServer1.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.labelServer1.BackgroundStyle.Class = "";
            this.labelServer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer1.Location = new System.Drawing.Point(129, 20);
            this.labelServer1.Name = "label 2016";
            this.labelServer1.Size = new System.Drawing.Size(48, 16);
            this.labelServer1.TabIndex = 82;
            this.labelServer1.WordWrap = true;
            // 
            // label2016Title
            // 
            // 
            // 
            // 
            this.labelServer1Title.BackgroundStyle.Class = "";
            this.labelServer1Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer1Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServer1Title.Location = new System.Drawing.Point(17, 20);
            this.labelServer1Title.Name = "label2016Title";
            this.labelServer1Title.Size = new System.Drawing.Size(107, 16);
            this.labelServer1Title.TabIndex = 78;
            this.labelServer1Title.Text = string.Empty;
            this.labelServer1Title.WordWrap = true;
            // 
            // label2017
            // 
            this.labelServer17.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.labelServer17.BackgroundStyle.Class = "";
            this.labelServer17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer17.Location = new System.Drawing.Point(129, 20);
            this.labelServer17.Name = "label 2017";
            this.labelServer17.Size = new System.Drawing.Size(48, 16);
            this.labelServer17.TabIndex = 82;
            this.labelServer17.WordWrap = true;
            // 
            // label2017Title
            // 
            // 
            // 
            // 
            this.labelServer17Title.BackgroundStyle.Class = "";
            this.labelServer17Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer17Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServer17Title.Location = new System.Drawing.Point(17, 20);
            this.labelServer17Title.Name = "label2017Title";
            this.labelServer17Title.Size = new System.Drawing.Size(107, 16);
            this.labelServer17Title.TabIndex = 78;
            this.labelServer17Title.Text = string.Empty;
            this.labelServer17Title.WordWrap = true;
            // 
            // label2008R2Title
            // 
            this.labelServer5Title.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelServer5Title.BackgroundStyle.Class = "";
            this.labelServer5Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer5Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServer5Title.Location = new System.Drawing.Point(394, 20);
            this.labelServer5Title.Name = "label2008R2Title";
            this.labelServer5Title.Size = new System.Drawing.Size(107, 16);
            this.labelServer5Title.TabIndex = 79;
            this.labelServer5Title.Text = string.Empty;
            // 
            // label2012Title
            // 
            this.labelServer3Title.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelServer3Title.BackgroundStyle.Class = "";
            this.labelServer3Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer3Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServer3Title.Location = new System.Drawing.Point(194, 20);
            this.labelServer3Title.Name = "label2012Title";
            this.labelServer3Title.Size = new System.Drawing.Size(107, 16);
            this.labelServer3Title.TabIndex = 78;
            this.labelServer3Title.Text = string.Empty;
            this.labelServer3Title.WordWrap = true;
            // 
            // label70
            // 
            this.labelServer8.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.labelServer8.BackgroundStyle.Class = "";
            this.labelServer8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer8.Location = new System.Drawing.Point(667, 44);
            this.labelServer8.Name = "label70";
            this.labelServer8.Size = new System.Drawing.Size(48, 16);
            this.labelServer8.TabIndex = 77;
            this.labelServer8.WordWrap = true;
            // 
            // label2000
            // 
            this.labelServer7.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.labelServer7.BackgroundStyle.Class = "";
            this.labelServer7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer7.Location = new System.Drawing.Point(667, 20);
            this.labelServer7.Name = "label2000";
            this.labelServer7.Size = new System.Drawing.Size(48, 16);
            this.labelServer7.TabIndex = 76;
            this.labelServer7.WordWrap = true;
            // 
            // label2005
            // 
            this.labelServer6.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.labelServer6.BackgroundStyle.Class = "";
            this.labelServer6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer6.Location = new System.Drawing.Point(501, 44);
            this.labelServer6.Name = "label2005";
            this.labelServer6.Size = new System.Drawing.Size(44, 16);
            this.labelServer6.TabIndex = 75;
            this.labelServer6.WordWrap = true;
            // 
            // label2008
            // 
            this.labelServer4.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.labelServer4.BackgroundStyle.Class = "";
            this.labelServer4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer4.Location = new System.Drawing.Point(324, 44);
            this.labelServer4.Name = "label2008";
            this.labelServer4.Size = new System.Drawing.Size(48, 16);
            this.labelServer4.TabIndex = 74;
            this.labelServer4.WordWrap = true;
            // 
            // label2000Title
            // 
            this.labelServer7Title.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelServer7Title.BackgroundStyle.Class = "";
            this.labelServer7Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer7Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServer7Title.Location = new System.Drawing.Point(559, 20);
            this.labelServer7Title.Name = "label2000Title";
            this.labelServer7Title.Size = new System.Drawing.Size(107, 16);
            this.labelServer7Title.TabIndex = 71;
            this.labelServer7Title.Text = string.Empty;
            // 
            // label2005Title
            // 
            this.labelserver6Title.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelserver6Title.BackgroundStyle.Class = "";
            this.labelserver6Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelserver6Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelserver6Title.Location = new System.Drawing.Point(394, 44);
            this.labelserver6Title.Name = "label2005Title";
            this.labelserver6Title.Size = new System.Drawing.Size(107, 16);
            this.labelserver6Title.TabIndex = 70;
            this.labelserver6Title.Text = string.Empty;
            // 
            // label70Title
            // 
            this.labelServer8Title.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelServer8Title.BackgroundStyle.Class = "";
            this.labelServer8Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer8Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServer8Title.Location = new System.Drawing.Point(559, 44);
            this.labelServer8Title.Name = "label70Title";
            this.labelServer8Title.Size = new System.Drawing.Size(107, 16);
            this.labelServer8Title.TabIndex = 73;
            this.labelServer8Title.Text = string.Empty;
            this.labelServer8Title.WordWrap = true;
            // 
            // label2008Title
            // 
            this.labelServer4Title.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelServer4Title.BackgroundStyle.Class = "";
            this.labelServer4Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer4Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServer4Title.Location = new System.Drawing.Point(194, 44);
            this.labelServer4Title.Name = "label2008Title";
            this.labelServer4Title.Size = new System.Drawing.Size(107, 16);
            this.labelServer4Title.TabIndex = 69;
            this.labelServer4Title.Text = string.Empty;
            this.labelServer4Title.WordWrap = true;
            // 
            // labelUnsupported
            // 
            this.labelUnsupported.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelUnsupported.BackgroundStyle.Class = "";
            this.labelUnsupported.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelUnsupported.Location = new System.Drawing.Point(33, 52);
            this.labelUnsupported.Name = "labelUnsupported";
            this.labelUnsupported.Size = new System.Drawing.Size(217, 16);
            this.labelUnsupported.TabIndex = 62;
            this.labelUnsupported.Text = "SQL Servers at Unsupported Levels";
            this.labelUnsupported.WordWrap = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(11, 52);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 61;
            this.pictureBox2.TabStop = false;
            // 
            // labelSupported
            // 
            this.labelSupported.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelSupported.BackgroundStyle.Class = "";
            this.labelSupported.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSupported.Location = new System.Drawing.Point(33, 29);
            this.labelSupported.Name = "labelSupported";
            this.labelSupported.Size = new System.Drawing.Size(208, 16);
            this.labelSupported.TabIndex = 60;
            this.labelSupported.Text = "SQL Servers at Supported Levels";
            this.labelSupported.WordWrap = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // labelTotal
            // 
            this.labelTotal.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelTotal.BackgroundStyle.Class = "";
            this.labelTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTotal.Location = new System.Drawing.Point(33, 7);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(217, 16);
            this.labelTotal.TabIndex = 38;
            this.labelTotal.Text = "Total SQL Servers";
            this.labelTotal.WordWrap = true;
            // 
            // pictureBoxDatabasesNeverBackedUp
            // 
            this.pictureBoxDatabasesNeverBackedUp.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxDatabasesNeverBackedUp.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDatabasesNeverBackedUp.Image")));
            this.pictureBoxDatabasesNeverBackedUp.Location = new System.Drawing.Point(11, 7);
            this.pictureBoxDatabasesNeverBackedUp.Name = "pictureBoxDatabasesNeverBackedUp";
            this.pictureBoxDatabasesNeverBackedUp.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxDatabasesNeverBackedUp.TabIndex = 37;
            this.pictureBoxDatabasesNeverBackedUp.TabStop = false;
            // 
            // tabSqlServer
            // 
            this.tabSqlServer.AttachedControl = this.tabControlPanel1;
            this.tabSqlServer.Name = "tabSqlServer";
            this.tabSqlServer.Text = "SQL Server Build Report";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.labelX2);
            this.tabControlPanel2.Controls.Add(this.labelX4);
            this.tabControlPanel2.Controls.Add(this.listViewEx1);
            this.tabControlPanel2.Controls.Add(this.groupPanel3);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 0);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(1005, 461);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabWindows;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.Color.Red;
            this.labelX2.Location = new System.Drawing.Point(65, 250);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(776, 28);
            this.labelX2.TabIndex = 59;
            this.labelX2.Text = "The Windows OS Version Report is not implemented at this time.";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX4
            // 
            this.labelX4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(6, 104);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(543, 20);
            this.labelX4.TabIndex = 57;
            this.labelX4.Text = "SQL Servers";
            // 
            // listViewEx1
            // 
            this.listViewEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.listViewEx1.Border.Class = "ListViewBorder";
            this.listViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnInstance2,
            this.columnOSName,
            this.columnOSLevel,
            this.columnOSVersion,
            this.columnSupported2,
            this.columnSupportStatus2});
            this.listViewEx1.FullRowSelect = true;
            listViewGroup12.Header = "SQL Server 2008";
            listViewGroup12.Name = "group2008";
            listViewGroup13.Header = "SQL Server 2005";
            listViewGroup13.Name = "group2005";
            listViewGroup14.Header = "SQL Server 2000";
            listViewGroup14.Name = "group 2000";
            listViewGroup15.Header = "SQL Server 7.0";
            listViewGroup15.Name = "group70";
            listViewGroup16.Header = "SQL Server 6.5";
            listViewGroup16.Name = "group65";
            listViewGroup17.Header = "Unknown SQL Server Version";
            listViewGroup17.Name = "groupUnknown";
            this.listViewEx1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup11,
            listViewGroup12,
            listViewGroup13,
            listViewGroup14,
            listViewGroup15,
            listViewGroup16});
            this.listViewEx1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listViewEx1.Location = new System.Drawing.Point(6, 124);
            this.listViewEx1.MultiSelect = false;
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(993, 327);
            this.listViewEx1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewEx1.TabIndex = 58;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.Details;
            // 
            // columnInstance2
            // 
            this.columnInstance2.Text = "SQL Server";
            this.columnInstance2.Width = 178;
            // 
            // columnOSName
            // 
            this.columnOSName.Text = "OS Name";
            this.columnOSName.Width = 184;
            // 
            // columnOSLevel
            // 
            this.columnOSLevel.Text = "OS Level";
            this.columnOSLevel.Width = 116;
            // 
            // columnOSVersion
            // 
            this.columnOSVersion.Text = "OS Version";
            this.columnOSVersion.Width = 97;
            // 
            // columnSupported2
            // 
            this.columnSupported2.Text = "Supported";
            this.columnSupported2.Width = 90;
            // 
            // columnSupportStatus2
            // 
            this.columnSupportStatus2.Text = "Support Status";
            this.columnSupportStatus2.Width = 206;
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.labelX1);
            this.groupPanel3.Location = new System.Drawing.Point(6, 0);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(788, 101);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupPanel3.Style.BackColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.Class = "";
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.Class = "";
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.Class = "";
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 56;
            this.groupPanel3.Text = "Summary Information";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.Red;
            this.labelX1.Location = new System.Drawing.Point(3, 24);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(776, 28);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "The Windows OS Version Report is not implemented at this time.";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // tabWindows
            // 
            this.tabWindows.AttachedControl = this.tabControlPanel2;
            this.tabWindows.Name = "tabWindows";
            this.tabWindows.Text = "Windows OS Version Report";
            this.tabWindows.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuView,
            this.menuTools,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 93);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1017, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExport,
            this.toolStripMenuItem4,
            this.printToolStripMenuItem,
            this.toolStripMenuItem5,
            this.menuExitToLaunchpad,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuExport
            // 
            this.menuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExportAsCSV,
            this.menuExportAsXML,
            this.menuExportAsDataTable});
            this.menuExport.Enabled = false;
            this.menuExport.Name = "menuExport";
            this.menuExport.Size = new System.Drawing.Size(168, 22);
            this.menuExport.Text = "Save &Results As";
            // 
            // menuExportAsCSV
            // 
            this.menuExportAsCSV.Name = "menuExportAsCSV";
            this.menuExportAsCSV.Size = new System.Drawing.Size(258, 22);
            this.menuExportAsCSV.Text = "CSV File (comma separated values)";
            this.menuExportAsCSV.Click += new System.EventHandler(this.menuExportAsCSV_Click);
            // 
            // menuExportAsXML
            // 
            this.menuExportAsXML.Name = "menuExportAsXML";
            this.menuExportAsXML.Size = new System.Drawing.Size(258, 22);
            this.menuExportAsXML.Text = "&XML File";
            this.menuExportAsXML.Click += new System.EventHandler(this.menuExportAsXML_Click);
            // 
            // menuExportAsDataTable
            // 
            this.menuExportAsDataTable.Name = "menuExportAsDataTable";
            this.menuExportAsDataTable.Size = new System.Drawing.Size(258, 22);
            this.menuExportAsDataTable.Text = "&Datatable";
            this.menuExportAsDataTable.Click += new System.EventHandler(this.menuExportAsDataTable_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(165, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Enabled = false;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.printToolStripMenuItem.Text = "&Print...";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(165, 6);
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
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowGroups});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(44, 20);
            this.menuView.Text = "&View";
            // 
            // menuShowGroups
            // 
            this.menuShowGroups.Checked = true;
            this.menuShowGroups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuShowGroups.Name = "menuShowGroups";
            this.menuShowGroups.Size = new System.Drawing.Size(144, 22);
            this.menuShowGroups.Text = "Show &Groups";
            this.menuShowGroups.Click += new System.EventHandler(this.menuShowGroups_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManageServerGroups,
            this.toolStripMenuItem7,
            this.menuToolsetOptions,
            this.menuLaunchpad});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(47, 20);
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
            this.menuAbout.Text = "&About Patch Analyzer";
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
            this.ideraTitleBar1.IderaProductNameText = "SQL Patch Analyzer";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.IsFormLocked = false;
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = true;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(1017, 93);
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
            this.ClientSize = new System.Drawing.Size(1017, 708);
            this.ControlBox = false;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ideraTitleBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(736, 426);
            this.Name = "Form_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
            this.panelMiddle.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel1.PerformLayout();
            this.groupStatistics.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDatabasesNeverBackedUp)).EndInit();
            this.tabControlPanel2.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panelMiddle;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.ButtonX buttonLoadServerData;
      private System.Windows.Forms.Panel panelTop;
      private DevComponents.DotNetBar.LabelX labelTitle;
      private DevComponents.DotNetBar.LabelX labelSubtitle;
      private System.Windows.Forms.PictureBox pictureBoxTitle;
      private System.Windows.Forms.Panel panelBottom;
      private DevComponents.DotNetBar.LabelX labelSQLServers;
      private DevComponents.DotNetBar.Controls.ListViewEx listSQL;
      private System.Windows.Forms.ColumnHeader columnInstance;
      private System.Windows.Forms.ColumnHeader columnRelease;
      private System.Windows.Forms.ColumnHeader columnEdition;
      private System.Windows.Forms.ColumnHeader columnBuild;
      private System.Windows.Forms.ColumnHeader columnSupported;
      private System.Windows.Forms.ColumnHeader columnStatus;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
      private System.Windows.Forms.LinkLabel linkDisplayVersionList;
      private System.Windows.Forms.LinkLabel linkCheckVersionList;
      private DevComponents.DotNetBar.LabelX labelPatchVersion;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem menuFile;
      private System.Windows.Forms.ToolStripMenuItem menuExitToLaunchpad;
      private System.Windows.Forms.ToolStripMenuItem menuFileExit;
      private System.Windows.Forms.ToolStripMenuItem menuView;
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
      private System.Windows.Forms.ToolStripMenuItem menuExport;
      private System.Windows.Forms.ToolStripMenuItem menuExportAsCSV;
      private System.Windows.Forms.ToolStripMenuItem menuExportAsXML;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
       private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
      private DevComponents.DotNetBar.TabControl tabControl1;
      private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
      private DevComponents.DotNetBar.TabItem tabWindows;
      private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
      private DevComponents.DotNetBar.TabItem tabSqlServer;
      private DevComponents.DotNetBar.Controls.GroupPanel groupStatistics;
      private DevComponents.DotNetBar.LabelX labelUnsupported;
      private System.Windows.Forms.PictureBox pictureBox2;
      private DevComponents.DotNetBar.LabelX labelSupported;
      private System.Windows.Forms.PictureBox pictureBox1;
      private DevComponents.DotNetBar.LabelX labelTotal;
      private System.Windows.Forms.PictureBox pictureBoxDatabasesNeverBackedUp;
      private DevComponents.DotNetBar.LabelX labelX4;
      private DevComponents.DotNetBar.Controls.ListViewEx listViewEx1;
      private System.Windows.Forms.ColumnHeader columnInstance2;
      private System.Windows.Forms.ColumnHeader columnSupported2;
      private System.Windows.Forms.ColumnHeader columnSupportStatus2;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
      private System.Windows.Forms.ColumnHeader columnOSName;
      private System.Windows.Forms.ColumnHeader columnOSVersion;
      private System.Windows.Forms.ColumnHeader columnOSLevel;
      private System.Windows.Forms.ColumnHeader columnLevel;
      private System.Windows.Forms.GroupBox groupBox1;
      private DevComponents.DotNetBar.LabelX labelServer7Title;
      private DevComponents.DotNetBar.LabelX labelserver6Title;
      private DevComponents.DotNetBar.LabelX labelServer8Title;
      private DevComponents.DotNetBar.LabelX labelServer4Title;
      private DevComponents.DotNetBar.LabelX labelServer8;
      private DevComponents.DotNetBar.LabelX labelServer7;
      private DevComponents.DotNetBar.LabelX labelServer6;
      private DevComponents.DotNetBar.LabelX labelServer4;
      private System.Windows.Forms.ToolStripMenuItem menuEdit;
      private System.Windows.Forms.ToolStripMenuItem menuCopy;
      private System.Windows.Forms.ToolStripMenuItem menuShowGroups;
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
      private System.Windows.Forms.ToolStripMenuItem contextMenuShowGroups;
      private System.Windows.Forms.ToolStripMenuItem contextMenuCopy;
      private System.Windows.Forms.ToolStripMenuItem menuManageServerGroups;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
      private DevComponents.DotNetBar.LabelX labelPatchVersionValue;
      private DevComponents.DotNetBar.LabelX labelX2;
      private DevComponents.DotNetBar.LabelX labelX1;
      private System.Windows.Forms.ToolStripMenuItem contextMenuViewKBArticle;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
      private DevComponents.DotNetBar.ButtonX buttonViewKbArticle;
      private System.Windows.Forms.ImageList imageList;
      private System.Windows.Forms.ColumnHeader columnIcon;
      private System.Windows.Forms.ColumnHeader columnKb;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
      private System.Windows.Forms.ToolStripMenuItem contextMenuExport;
      private System.Windows.Forms.ToolStripMenuItem contextMenuExportAsCSV;
      private System.Windows.Forms.ToolStripMenuItem contextMenuExportAsXML;
      private Idera.SqlAdminToolset.Core.Controls.ToolServerSelection ServerSelection;
      private System.Windows.Forms.ToolStripMenuItem menuSelectAll;
      private System.Windows.Forms.ToolStripMenuItem contextMenuSelectAll;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
      private DevComponents.DotNetBar.ButtonX buttonCopyToClipboard;
      private System.Windows.Forms.ToolStripMenuItem contextMenuViewAvailableHotfixes;
      private DevComponents.DotNetBar.ButtonX buttonViewAvailableHotfixes;
      private System.Windows.Forms.ColumnHeader columnHotfixAvailable;
       private DevComponents.DotNetBar.ButtonX buttonObtainingUpgrades;
       private System.Windows.Forms.ToolStripMenuItem menuExportAsDataTable;
       private System.Windows.Forms.ToolStripMenuItem contextMenuExportAsDatatable;
       private DevComponents.DotNetBar.LabelX labelServer5;
       private DevComponents.DotNetBar.LabelX labelServer3;
       private DevComponents.DotNetBar.LabelX labelServer2;
       private DevComponents.DotNetBar.LabelX labelServer2Title;
        private DevComponents.DotNetBar.LabelX labelServer1;
        private DevComponents.DotNetBar.LabelX labelServer17;
        private DevComponents.DotNetBar.LabelX labelServer1Title;
        private DevComponents.DotNetBar.LabelX labelServer17Title;
        private DevComponents.DotNetBar.LabelX labelServer5Title;
       private DevComponents.DotNetBar.LabelX labelServer3Title;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
    }
}

