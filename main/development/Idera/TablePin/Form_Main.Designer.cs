namespace Idera.SqlAdminToolset.TablePin
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuXML = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopyResultsToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManageServerGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsetOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
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
            this.toolProductBanner = new System.Windows.Forms.Panel();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonUnpinTable = new DevComponents.DotNetBar.ButtonX();
            this.buttonPinTable = new DevComponents.DotNetBar.ButtonX();
            this.labelStatus = new DevComponents.DotNetBar.LabelX();
            this.buttonCopyToClipboard = new DevComponents.DotNetBar.ButtonX();
            this.groupResults = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelTableList = new DevComponents.DotNetBar.LabelX();
            this.labelEmptyResultSet = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.labelEstimatedSize = new DevComponents.DotNetBar.LabelX();
            this.labelRows = new DevComponents.DotNetBar.LabelX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelTotalPinnedTables = new DevComponents.DotNetBar.LabelX();
            this.labelTotalTables = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxUserDatabases = new System.Windows.Forms.PictureBox();
            this.pictureBoxSystemDatabases = new System.Windows.Forms.PictureBox();
            this.labelDatabasesWithPinnedTables = new DevComponents.DotNetBar.LabelX();
            this.labelTotalDatabases = new DevComponents.DotNetBar.LabelX();
            this.listResults = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDatabase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPinned = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRows = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuUnpin = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuPin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuXML = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkHideUnpinnedTables = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.textServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelServer = new DevComponents.DotNetBar.LabelX();
            this.buttonCredentials = new DevComponents.DotNetBar.ButtonX();
            this.buttonGetPinnedStatus = new DevComponents.DotNetBar.ButtonX();
            this.buttonBrowseServer = new DevComponents.DotNetBar.ButtonX();
            this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.menuStrip1.SuspendLayout();
            this.toolProductBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.groupResults.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserDatabases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSystemDatabases)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuEdit,
            this.menuTools,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 93);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(735, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExport,
            this.toolStripMenuItem4,
            this.menuExitToLaunchpad,
            this.menuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // menuExport
            // 
            this.menuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCSV,
            this.menuXML});
            this.menuExport.Enabled = false;
            this.menuExport.Name = "menuExport";
            this.menuExport.Size = new System.Drawing.Size(168, 22);
            this.menuExport.Text = "&Save Results As";
            // 
            // menuCSV
            // 
            this.menuCSV.Name = "menuCSV";
            this.menuCSV.Size = new System.Drawing.Size(258, 22);
            this.menuCSV.Text = "CSV File (comma separated values)";
            this.menuCSV.Click += new System.EventHandler(this.menuCSV_Click);
            // 
            // menuXML
            // 
            this.menuXML.Name = "menuXML";
            this.menuXML.Size = new System.Drawing.Size(258, 22);
            this.menuXML.Text = "XML File";
            this.menuXML.Click += new System.EventHandler(this.menuXML_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(165, 6);
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
            this.menuCopyResultsToClipboard,
            this.menuSelectAll});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(39, 20);
            this.menuEdit.Text = "&Edit";
            // 
            // menuCopyResultsToClipboard
            // 
            this.menuCopyResultsToClipboard.Enabled = false;
            this.menuCopyResultsToClipboard.Name = "menuCopyResultsToClipboard";
            this.menuCopyResultsToClipboard.Size = new System.Drawing.Size(122, 22);
            this.menuCopyResultsToClipboard.Text = "Copy";
            this.menuCopyResultsToClipboard.Click += new System.EventHandler(this.menuCopyResultsToClipboard_Click);
            // 
            // menuSelectAll
            // 
            this.menuSelectAll.Enabled = false;
            this.menuSelectAll.Name = "menuSelectAll";
            this.menuSelectAll.Size = new System.Drawing.Size(122, 22);
            this.menuSelectAll.Text = "Select &All";
            this.menuSelectAll.Click += new System.EventHandler(this.menuSelectAll_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManageServerGroups,
            this.menuToolsetOptions,
            this.toolStripMenuItem6,
            this.menuLaunchpad});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(48, 20);
            this.menuTools.Text = "&Tools";
            // 
            // menuManageServerGroups
            // 
            this.menuManageServerGroups.Name = "menuManageServerGroups";
            this.menuManageServerGroups.Size = new System.Drawing.Size(233, 22);
            this.menuManageServerGroups.Text = "&Manage Server Groups...";
            this.menuManageServerGroups.Click += new System.EventHandler(this.menuManageServerGroups_Click);
            // 
            // menuToolsetOptions
            // 
            this.menuToolsetOptions.Name = "menuToolsetOptions";
            this.menuToolsetOptions.Size = new System.Drawing.Size(233, 22);
            this.menuToolsetOptions.Text = "SQL admin toolset &Options...";
            this.menuToolsetOptions.Click += new System.EventHandler(this.menuToolsetOptions_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(230, 6);
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
            this.menuAbout.Text = "&About TablePin";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // toolProductBanner
            // 
            this.toolProductBanner.BackColor = System.Drawing.Color.Transparent;
            this.toolProductBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolProductBanner.Controls.Add(this.labelSubtitle);
            this.toolProductBanner.Controls.Add(this.labelTitle);
            this.toolProductBanner.Controls.Add(this.pictureBoxTitle);
            this.toolProductBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolProductBanner.Location = new System.Drawing.Point(0, 117);
            this.toolProductBanner.Name = "toolProductBanner";
            this.toolProductBanner.Size = new System.Drawing.Size(735, 52);
            this.toolProductBanner.TabIndex = 10;
            // 
            // labelSubtitle
            // 
            this.labelSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelSubtitle.BackgroundStyle.Class = "";
            this.labelSubtitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.Location = new System.Drawing.Point(216, 0);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(510, 52);
            this.labelSubtitle.TabIndex = 8;
            this.labelSubtitle.Text = "View and manage the pinned status of your tables (SQL Server 2000 and before only" +
    ")";
            this.labelSubtitle.WordWrap = true;
            // 
            // labelTitle
            // 
            // 
            // 
            // 
            this.labelTitle.BackgroundStyle.Class = "";
            this.labelTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTitle.Location = new System.Drawing.Point(65, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(145, 52);
            this.labelTitle.TabIndex = 7;
            this.labelTitle.TabStop = false;
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Table Pin</font></b> ";
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
            this.panelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBottom.Controls.Add(this.buttonUnpinTable);
            this.panelBottom.Controls.Add(this.buttonPinTable);
            this.panelBottom.Controls.Add(this.labelStatus);
            this.panelBottom.Controls.Add(this.buttonCopyToClipboard);
            this.panelBottom.Controls.Add(this.groupResults);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 242);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.panelBottom.Size = new System.Drawing.Size(735, 280);
            this.panelBottom.TabIndex = 11;
            // 
            // buttonUnpinTable
            // 
            this.buttonUnpinTable.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonUnpinTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUnpinTable.BackColor = System.Drawing.Color.White;
            this.buttonUnpinTable.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonUnpinTable.Enabled = false;
            this.buttonUnpinTable.Image = ((System.Drawing.Image)(resources.GetObject("buttonUnpinTable.Image")));
            this.buttonUnpinTable.Location = new System.Drawing.Point(353, 242);
            this.buttonUnpinTable.Name = "buttonUnpinTable";
            this.buttonUnpinTable.Size = new System.Drawing.Size(95, 24);
            this.buttonUnpinTable.TabIndex = 10;
            this.buttonUnpinTable.Text = "&Unpin Table";
            this.buttonUnpinTable.Click += new System.EventHandler(this.buttonUnpinTable_Click);
            // 
            // buttonPinTable
            // 
            this.buttonPinTable.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonPinTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPinTable.BackColor = System.Drawing.Color.White;
            this.buttonPinTable.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonPinTable.Enabled = false;
            this.buttonPinTable.Image = ((System.Drawing.Image)(resources.GetObject("buttonPinTable.Image")));
            this.buttonPinTable.Location = new System.Drawing.Point(452, 242);
            this.buttonPinTable.Name = "buttonPinTable";
            this.buttonPinTable.Size = new System.Drawing.Size(95, 24);
            this.buttonPinTable.TabIndex = 11;
            this.buttonPinTable.Text = "&Pin Table";
            this.buttonPinTable.Click += new System.EventHandler(this.buttonPinTable_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus.AutoSize = true;
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelStatus.BackgroundStyle.Class = "";
            this.labelStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelStatus.Location = new System.Drawing.Point(16, 247);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.TabIndex = 41;
            this.labelStatus.Text = "Total tables";
            this.labelStatus.Visible = false;
            this.labelStatus.WordWrap = true;
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyToClipboard.BackColor = System.Drawing.Color.White;
            this.buttonCopyToClipboard.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCopyToClipboard.Enabled = false;
            this.buttonCopyToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyToClipboard.Image")));
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(560, 242);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(169, 24);
            this.buttonCopyToClipboard.TabIndex = 12;
            this.buttonCopyToClipboard.Text = "&Copy Results To Clipboard";
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // groupResults
            // 
            this.groupResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupResults.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupResults.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupResults.Controls.Add(this.labelTableList);
            this.groupResults.Controls.Add(this.labelEmptyResultSet);
            this.groupResults.Controls.Add(this.groupPanel2);
            this.groupResults.Controls.Add(this.listResults);
            this.groupResults.IsShadowEnabled = true;
            this.groupResults.Location = new System.Drawing.Point(6, 3);
            this.groupResults.Name = "groupResults";
            this.groupResults.Size = new System.Drawing.Size(723, 233);
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
            this.groupResults.TabIndex = 6;
            this.groupResults.Text = "Pinned Status";
            // 
            // labelTableList
            // 
            this.labelTableList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTableList.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelTableList.BackgroundStyle.Class = "";
            this.labelTableList.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTableList.Location = new System.Drawing.Point(5, 71);
            this.labelTableList.Name = "labelTableList";
            this.labelTableList.Size = new System.Drawing.Size(687, 20);
            this.labelTableList.TabIndex = 8;
            this.labelTableList.Text = "&Tables";
            // 
            // labelEmptyResultSet
            // 
            this.labelEmptyResultSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEmptyResultSet.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelEmptyResultSet.BackgroundStyle.Class = "";
            this.labelEmptyResultSet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelEmptyResultSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmptyResultSet.ForeColor = System.Drawing.Color.Red;
            this.labelEmptyResultSet.Location = new System.Drawing.Point(11, 157);
            this.labelEmptyResultSet.Name = "labelEmptyResultSet";
            this.labelEmptyResultSet.Size = new System.Drawing.Size(697, 44);
            this.labelEmptyResultSet.TabIndex = 29;
            this.labelEmptyResultSet.Text = "No data available for this server";
            this.labelEmptyResultSet.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelEmptyResultSet.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.labelEmptyResultSet.Visible = false;
            this.labelEmptyResultSet.WordWrap = true;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.pictureBox3);
            this.groupPanel2.Controls.Add(this.pictureBox4);
            this.groupPanel2.Controls.Add(this.labelEstimatedSize);
            this.groupPanel2.Controls.Add(this.labelRows);
            this.groupPanel2.Controls.Add(this.pictureBox1);
            this.groupPanel2.Controls.Add(this.pictureBox2);
            this.groupPanel2.Controls.Add(this.labelTotalPinnedTables);
            this.groupPanel2.Controls.Add(this.labelTotalTables);
            this.groupPanel2.Controls.Add(this.pictureBoxUserDatabases);
            this.groupPanel2.Controls.Add(this.pictureBoxSystemDatabases);
            this.groupPanel2.Controls.Add(this.labelDatabasesWithPinnedTables);
            this.groupPanel2.Controls.Add(this.labelTotalDatabases);
            this.groupPanel2.Location = new System.Drawing.Point(5, 7);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(706, 59);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor = System.Drawing.Color.White;
            this.groupPanel2.Style.BackColor2 = System.Drawing.Color.White;
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
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
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
            this.groupPanel2.TabIndex = 7;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(443, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 71;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(443, 31);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.TabIndex = 72;
            this.pictureBox4.TabStop = false;
            // 
            // labelEstimatedSize
            // 
            this.labelEstimatedSize.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelEstimatedSize.BackgroundStyle.Class = "";
            this.labelEstimatedSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelEstimatedSize.Location = new System.Drawing.Point(462, 31);
            this.labelEstimatedSize.Name = "labelEstimatedSize";
            this.labelEstimatedSize.Size = new System.Drawing.Size(235, 16);
            this.labelEstimatedSize.TabIndex = 70;
            this.labelEstimatedSize.Text = "estimated size of all pinned tables";
            // 
            // labelRows
            // 
            this.labelRows.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelRows.BackgroundStyle.Class = "";
            this.labelRows.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelRows.Location = new System.Drawing.Point(462, 6);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(190, 16);
            this.labelRows.TabIndex = 69;
            this.labelRows.Text = "rows in the pinned tables";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(265, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 67;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(265, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 68;
            this.pictureBox2.TabStop = false;
            // 
            // labelTotalPinnedTables
            // 
            this.labelTotalPinnedTables.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelTotalPinnedTables.BackgroundStyle.Class = "";
            this.labelTotalPinnedTables.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTotalPinnedTables.Location = new System.Drawing.Point(284, 31);
            this.labelTotalPinnedTables.Name = "labelTotalPinnedTables";
            this.labelTotalPinnedTables.Size = new System.Drawing.Size(135, 16);
            this.labelTotalPinnedTables.TabIndex = 66;
            this.labelTotalPinnedTables.Text = "pinned tables";
            // 
            // labelTotalTables
            // 
            this.labelTotalTables.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelTotalTables.BackgroundStyle.Class = "";
            this.labelTotalTables.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTotalTables.Location = new System.Drawing.Point(284, 6);
            this.labelTotalTables.Name = "labelTotalTables";
            this.labelTotalTables.Size = new System.Drawing.Size(102, 16);
            this.labelTotalTables.TabIndex = 65;
            this.labelTotalTables.Text = "total tables";
            // 
            // pictureBoxUserDatabases
            // 
            this.pictureBoxUserDatabases.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxUserDatabases.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxUserDatabases.Image")));
            this.pictureBoxUserDatabases.Location = new System.Drawing.Point(16, 6);
            this.pictureBoxUserDatabases.Name = "pictureBoxUserDatabases";
            this.pictureBoxUserDatabases.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxUserDatabases.TabIndex = 63;
            this.pictureBoxUserDatabases.TabStop = false;
            // 
            // pictureBoxSystemDatabases
            // 
            this.pictureBoxSystemDatabases.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSystemDatabases.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSystemDatabases.Image")));
            this.pictureBoxSystemDatabases.Location = new System.Drawing.Point(16, 31);
            this.pictureBoxSystemDatabases.Name = "pictureBoxSystemDatabases";
            this.pictureBoxSystemDatabases.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxSystemDatabases.TabIndex = 64;
            this.pictureBoxSystemDatabases.TabStop = false;
            // 
            // labelDatabasesWithPinnedTables
            // 
            this.labelDatabasesWithPinnedTables.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelDatabasesWithPinnedTables.BackgroundStyle.Class = "";
            this.labelDatabasesWithPinnedTables.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelDatabasesWithPinnedTables.Location = new System.Drawing.Point(36, 31);
            this.labelDatabasesWithPinnedTables.Name = "labelDatabasesWithPinnedTables";
            this.labelDatabasesWithPinnedTables.Size = new System.Drawing.Size(182, 16);
            this.labelDatabasesWithPinnedTables.TabIndex = 62;
            this.labelDatabasesWithPinnedTables.Text = "databases with pinned tables";
            // 
            // labelTotalDatabases
            // 
            this.labelTotalDatabases.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelTotalDatabases.BackgroundStyle.Class = "";
            this.labelTotalDatabases.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTotalDatabases.Location = new System.Drawing.Point(36, 6);
            this.labelTotalDatabases.Name = "labelTotalDatabases";
            this.labelTotalDatabases.Size = new System.Drawing.Size(116, 16);
            this.labelTotalDatabases.TabIndex = 61;
            this.labelTotalDatabases.Text = "total databases";
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
            this.columnDatabase,
            this.columnTable,
            this.columnPinned,
            this.columnRows,
            this.columnSize});
            this.listResults.ContextMenuStrip = this.contextMenuStrip1;
            this.listResults.FullRowSelect = true;
            this.listResults.Location = new System.Drawing.Point(5, 91);
            this.listResults.Name = "listResults";
            this.listResults.Size = new System.Drawing.Size(709, 126);
            this.listResults.SmallImageList = this.imageList1;
            this.listResults.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listResults.TabIndex = 9;
            this.listResults.UseCompatibleStateImageBehavior = false;
            this.listResults.View = System.Windows.Forms.View.Details;
            this.listResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listResults_ColumnClick);
            this.listResults.SelectedIndexChanged += new System.EventHandler(this.listResults_SelectedIndexChanged);
            // 
            // columnIcon
            // 
            this.columnIcon.Text = "";
            this.columnIcon.Width = 24;
            // 
            // columnDatabase
            // 
            this.columnDatabase.Text = "Database";
            this.columnDatabase.Width = 209;
            // 
            // columnTable
            // 
            this.columnTable.Text = "Table";
            this.columnTable.Width = 193;
            // 
            // columnPinned
            // 
            this.columnPinned.Text = "Pinned";
            this.columnPinned.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnPinned.Width = 50;
            // 
            // columnRows
            // 
            this.columnRows.Text = "Rows";
            this.columnRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnRows.Width = 90;
            // 
            // columnSize
            // 
            this.columnSize.Text = "Estimated Size";
            this.columnSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnSize.Width = 99;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuUnpin,
            this.contextMenuPin,
            this.toolStripMenuItem5,
            this.contextMenuCopy,
            this.contextMenuSelectAll,
            this.toolStripMenuItem7,
            this.contextMenuExport});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 126);
            // 
            // contextMenuUnpin
            // 
            this.contextMenuUnpin.Enabled = false;
            this.contextMenuUnpin.Name = "contextMenuUnpin";
            this.contextMenuUnpin.Size = new System.Drawing.Size(164, 22);
            this.contextMenuUnpin.Text = "&Unpin Table";
            this.contextMenuUnpin.Click += new System.EventHandler(this.contextMenuUnpin_Click);
            // 
            // contextMenuPin
            // 
            this.contextMenuPin.Enabled = false;
            this.contextMenuPin.Name = "contextMenuPin";
            this.contextMenuPin.Size = new System.Drawing.Size(164, 22);
            this.contextMenuPin.Text = "&Pin Table";
            this.contextMenuPin.Click += new System.EventHandler(this.contextMenuPin_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(161, 6);
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.Enabled = false;
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.contextMenuCopy.Size = new System.Drawing.Size(164, 22);
            this.contextMenuCopy.Text = "&Copy";
            this.contextMenuCopy.Click += new System.EventHandler(this.contextMenuCopy_Click);
            // 
            // contextMenuSelectAll
            // 
            this.contextMenuSelectAll.Enabled = false;
            this.contextMenuSelectAll.Name = "contextMenuSelectAll";
            this.contextMenuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.contextMenuSelectAll.Size = new System.Drawing.Size(164, 22);
            this.contextMenuSelectAll.Text = "Select &All";
            this.contextMenuSelectAll.Click += new System.EventHandler(this.contextMenuSelectAll_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(161, 6);
            // 
            // contextMenuExport
            // 
            this.contextMenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuCSV,
            this.contextMenuXML});
            this.contextMenuExport.Enabled = false;
            this.contextMenuExport.Name = "contextMenuExport";
            this.contextMenuExport.Size = new System.Drawing.Size(164, 22);
            this.contextMenuExport.Text = "&Save Results As";
            // 
            // contextMenuCSV
            // 
            this.contextMenuCSV.Name = "contextMenuCSV";
            this.contextMenuCSV.Size = new System.Drawing.Size(255, 22);
            this.contextMenuCSV.Text = "CSV File(comma separated values)";
            this.contextMenuCSV.Click += new System.EventHandler(this.contextMenuCSV_Click);
            // 
            // contextMenuXML
            // 
            this.contextMenuXML.Name = "contextMenuXML";
            this.contextMenuXML.Size = new System.Drawing.Size(255, 22);
            this.contextMenuXML.Text = "XML File";
            this.contextMenuXML.Click += new System.EventHandler(this.contextMenuXML_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pin_blue.ico");
            this.imageList1.Images.SetKeyName(1, "table_sql.png");
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.groupPanel1);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMiddle.Location = new System.Drawing.Point(0, 169);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Padding = new System.Windows.Forms.Padding(6);
            this.panelMiddle.Size = new System.Drawing.Size(735, 73);
            this.panelMiddle.TabIndex = 12;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.checkHideUnpinnedTables);
            this.groupPanel1.Controls.Add(this.textServer);
            this.groupPanel1.Controls.Add(this.labelServer);
            this.groupPanel1.Controls.Add(this.buttonCredentials);
            this.groupPanel1.Controls.Add(this.buttonGetPinnedStatus);
            this.groupPanel1.Controls.Add(this.buttonBrowseServer);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.IsShadowEnabled = true;
            this.groupPanel1.Location = new System.Drawing.Point(6, 6);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(723, 61);
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
            // checkHideUnpinnedTables
            // 
            this.checkHideUnpinnedTables.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkHideUnpinnedTables.BackgroundStyle.Class = "";
            this.checkHideUnpinnedTables.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkHideUnpinnedTables.Checked = true;
            this.checkHideUnpinnedTables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkHideUnpinnedTables.CheckValue = "Y";
            this.checkHideUnpinnedTables.Location = new System.Drawing.Point(86, 37);
            this.checkHideUnpinnedTables.Name = "checkHideUnpinnedTables";
            this.checkHideUnpinnedTables.Size = new System.Drawing.Size(189, 13);
            this.checkHideUnpinnedTables.TabIndex = 4;
            this.checkHideUnpinnedTables.Text = "&Hide tables that are not pinned";
            // 
            // textServer
            // 
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
            this.textServer.Location = new System.Drawing.Point(78, 9);
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(394, 20);
            this.textServer.TabIndex = 1;
            this.textServer.Text = "(local)";
            this.textServer.WatermarkText = "Enter instance name";
            this.textServer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textServer_KeyPress);
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
            this.labelServer.Location = new System.Drawing.Point(7, 12);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(65, 12);
            this.labelServer.TabIndex = 0;
            this.labelServer.Text = "&SQL Server:";
            // 
            // buttonCredentials
            // 
            this.buttonCredentials.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCredentials.BackColor = System.Drawing.Color.White;
            this.buttonCredentials.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCredentials.Image = ((System.Drawing.Image)(resources.GetObject("buttonCredentials.Image")));
            this.buttonCredentials.Location = new System.Drawing.Point(503, 9);
            this.buttonCredentials.Name = "buttonCredentials";
            this.buttonCredentials.Size = new System.Drawing.Size(20, 20);
            this.buttonCredentials.TabIndex = 3;
            this.buttonCredentials.Click += new System.EventHandler(this.buttonCredentials_Click);
            // 
            // buttonGetPinnedStatus
            // 
            this.buttonGetPinnedStatus.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonGetPinnedStatus.BackColor = System.Drawing.Color.White;
            this.buttonGetPinnedStatus.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonGetPinnedStatus.Image = ((System.Drawing.Image)(resources.GetObject("buttonGetPinnedStatus.Image")));
            this.buttonGetPinnedStatus.Location = new System.Drawing.Point(536, 5);
            this.buttonGetPinnedStatus.Name = "buttonGetPinnedStatus";
            this.buttonGetPinnedStatus.Size = new System.Drawing.Size(174, 46);
            this.buttonGetPinnedStatus.TabIndex = 5;
            this.buttonGetPinnedStatus.Text = "&Get Pinned Status";
            this.buttonGetPinnedStatus.Click += new System.EventHandler(this.buttonGetResults_Click);
            // 
            // buttonBrowseServer
            // 
            this.buttonBrowseServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseServer.BackColor = System.Drawing.Color.White;
            this.buttonBrowseServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseServer.Location = new System.Drawing.Point(478, 9);
            this.buttonBrowseServer.Name = "buttonBrowseServer";
            this.buttonBrowseServer.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseServer.TabIndex = 2;
            this.buttonBrowseServer.Text = "...";
            this.buttonBrowseServer.Click += new System.EventHandler(this.buttonBrowseServer_Click);
            // 
            // ideraTitleBar1
            // 
            this.ideraTitleBar1.ActivateLicenseEventHandler = null;
            this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
            this.ideraTitleBar1.Close = true;
            this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
            this.ideraTitleBar1.IderaProductNameText = "SQL Table Pin";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = true;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(735, 93);
            this.ideraTitleBar1.TabIndex = 14;
            this.ideraTitleBar1.TrialMode = true;
            this.ideraTitleBar1.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar1_LicenseInfoButtonClick);
            // 
            // Form_Main
            // 
            this.AcceptButton = this.buttonGetPinnedStatus;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(735, 522);
            this.ControlBox = false;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.toolProductBanner);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ideraTitleBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(736, 426);
            this.Name = "Form_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolProductBanner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.groupResults.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserDatabases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSystemDatabases)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelMiddle.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem menuFileExit;
      private System.Windows.Forms.ToolStripMenuItem menuHelp;
      private System.Windows.Forms.ToolStripMenuItem menuDeactivateLicense;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem menuAbout;
      private System.Windows.Forms.ToolStripMenuItem menuShowHelp;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem menuAboutIderaProducts;
      private System.Windows.Forms.ToolStripMenuItem menuContactTechnicalSupport;
      private System.Windows.Forms.ToolStripMenuItem menuCheckForUpdates;
      private System.Windows.Forms.Panel toolProductBanner;
      private System.Windows.Forms.Panel panelBottom;
      private System.Windows.Forms.PictureBox pictureBoxTitle;
      private System.Windows.Forms.ToolStripMenuItem menuExitToLaunchpad;
      private System.Windows.Forms.ToolTip toolTip2;
      private System.Windows.Forms.ToolStripMenuItem menuTools;
      private System.Windows.Forms.ToolStripMenuItem menuLaunchpad;
      private System.Windows.Forms.Panel panelMiddle;
      private System.Windows.Forms.ToolStripMenuItem menuToolsetOptions;
      private DevComponents.DotNetBar.LabelX labelSubtitle;
      private DevComponents.DotNetBar.LabelX labelTitle;
      private DevComponents.DotNetBar.Controls.GroupPanel groupResults;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.Controls.TextBoxX textServer;
      private DevComponents.DotNetBar.LabelX labelServer;
      private DevComponents.DotNetBar.ButtonX buttonCredentials;
      private DevComponents.DotNetBar.ButtonX buttonGetPinnedStatus;
      private DevComponents.DotNetBar.ButtonX buttonBrowseServer;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkHideUnpinnedTables;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.PictureBox pictureBox2;
      private DevComponents.DotNetBar.LabelX labelTotalPinnedTables;
      private DevComponents.DotNetBar.LabelX labelTotalTables;
      private System.Windows.Forms.PictureBox pictureBoxUserDatabases;
      private System.Windows.Forms.PictureBox pictureBoxSystemDatabases;
      private DevComponents.DotNetBar.LabelX labelDatabasesWithPinnedTables;
      private DevComponents.DotNetBar.LabelX labelTotalDatabases;
      private System.Windows.Forms.PictureBox pictureBox3;
      private System.Windows.Forms.PictureBox pictureBox4;
      private DevComponents.DotNetBar.LabelX labelEstimatedSize;
      private DevComponents.DotNetBar.LabelX labelRows;
      private DevComponents.DotNetBar.LabelX labelStatus;
      private DevComponents.DotNetBar.ButtonX buttonCopyToClipboard;
      private DevComponents.DotNetBar.LabelX labelEmptyResultSet;
      private DevComponents.DotNetBar.Controls.ListViewEx listResults;
      private System.Windows.Forms.ColumnHeader columnIcon;
      private System.Windows.Forms.ColumnHeader columnDatabase;
      private System.Windows.Forms.ColumnHeader columnTable;
      private System.Windows.Forms.ColumnHeader columnPinned;
      private System.Windows.Forms.ColumnHeader columnRows;
      private System.Windows.Forms.ColumnHeader columnSize;
      private DevComponents.DotNetBar.LabelX labelTableList;
      private DevComponents.DotNetBar.ButtonX buttonUnpinTable;
      private DevComponents.DotNetBar.ButtonX buttonPinTable;
      private System.Windows.Forms.ImageList imageList1;
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
      private System.Windows.Forms.ToolStripMenuItem contextMenuUnpin;
      private System.Windows.Forms.ToolStripMenuItem contextMenuPin;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
      private System.Windows.Forms.ToolStripMenuItem contextMenuCopy;
      private System.Windows.Forms.ToolStripMenuItem menuManageServerGroups;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
      private System.Windows.Forms.ToolStripMenuItem menuEdit;
      private System.Windows.Forms.ToolStripMenuItem menuCopyResultsToClipboard;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
      private System.Windows.Forms.ToolStripMenuItem menuExport;
      private System.Windows.Forms.ToolStripMenuItem menuCSV;
      private System.Windows.Forms.ToolStripMenuItem menuXML;
      private System.Windows.Forms.ToolStripMenuItem menuSelectAll;
      private System.Windows.Forms.ToolStripMenuItem contextMenuSelectAll;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
      private System.Windows.Forms.ToolStripMenuItem contextMenuExport;
      private System.Windows.Forms.ToolStripMenuItem contextMenuCSV;
      private System.Windows.Forms.ToolStripMenuItem contextMenuXML;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
    }
}

