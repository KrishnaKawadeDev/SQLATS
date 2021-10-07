namespace Idera.SqlAdminToolset.SqlSearch
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsXML = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolProductBanner = new System.Windows.Forms.Panel();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.labelTitle = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textLimit = new DevComponents.Editors.IntegerInput();
            this.radioButtonLimit = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxIncludeSystemDatabases = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelLimit = new DevComponents.DotNetBar.LabelX();
            this.checkAllowWildcards = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkMatchCase = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.buttonBrowseDatabase = new DevComponents.DotNetBar.ButtonX();
            this.groupObjectTypes = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkJobs = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkTriggers = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkFunctions = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkViews = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkStoredProcedures = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.textSearchText = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textDatabase = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonCredentials = new DevComponents.DotNetBar.ButtonX();
            this.buttonBrowseServer = new DevComponents.DotNetBar.ButtonX();
            this.textServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonSearch = new DevComponents.DotNetBar.ButtonX();
            this.labelSearchText = new DevComponents.DotNetBar.LabelX();
            this.labelDatabase = new DevComponents.DotNetBar.LabelX();
            this.labelServer = new DevComponents.DotNetBar.LabelX();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonView = new DevComponents.DotNetBar.ButtonX();
            this.buttonCopyToClipboard = new DevComponents.DotNetBar.ButtonX();
            this.labelNumberOfResults = new DevComponents.DotNetBar.LabelX();
            this.groupResults = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelEmptyResultSet = new DevComponents.DotNetBar.LabelX();
            this.listResults = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuViewSQLSource = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExportAsCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExportAsXML = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.menuStrip1.SuspendLayout();
            this.toolProductBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.panelTop.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textLimit)).BeginInit();
            this.groupObjectTypes.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.groupResults.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExport,
            this.toolStripMenuItem6,
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
            this.menuExportAsXML});
            this.menuExport.Enabled = false;
            this.menuExport.Name = "menuExport";
            this.menuExport.Size = new System.Drawing.Size(168, 22);
            this.menuExport.Text = "Save Results As ";
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
            this.menuExportAsXML.Text = "XML File";
            this.menuExportAsXML.Click += new System.EventHandler(this.menuExportAsXML_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(165, 6);
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
            this.menuCopy.Text = "Copy";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuSelectAll
            // 
            this.menuSelectAll.Enabled = false;
            this.menuSelectAll.Name = "menuSelectAll";
            this.menuSelectAll.Size = new System.Drawing.Size(122, 22);
            this.menuSelectAll.Text = "&Select All";
            this.menuSelectAll.Click += new System.EventHandler(this.menuSelectAll_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManageServerGroups,
            this.menuToolsetOptions,
            this.toolStripMenuItem4,
            this.menuLaunchpad});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(47, 20);
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
            this.menuAbout.Text = "&About SQL Search";
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
            this.toolProductBanner.Size = new System.Drawing.Size(1008, 60);
            this.toolProductBanner.TabIndex = 10;
            // 
            // labelSubtitle
            // 
            // 
            // 
            // 
            this.labelSubtitle.BackgroundStyle.Class = "";
            this.labelSubtitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.Location = new System.Drawing.Point(60, 30);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(550, 16);
            this.labelSubtitle.TabIndex = 4;
            this.labelSubtitle.Text = "Search for text anywhere you have SQL code  (stored procedures, functions, trigge" +
    "rs etc)";
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
            this.labelTitle.Size = new System.Drawing.Size(400, 52);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  SQL Search</font></b> ";
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
            // panelTop
            // 
            this.panelTop.Controls.Add(this.groupPanel1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 177);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.panelTop.Size = new System.Drawing.Size(1008, 171);
            this.panelTop.TabIndex = 10;
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.groupPanel2);
            this.groupPanel1.Controls.Add(this.buttonBrowseDatabase);
            this.groupPanel1.Controls.Add(this.groupObjectTypes);
            this.groupPanel1.Controls.Add(this.textSearchText);
            this.groupPanel1.Controls.Add(this.textDatabase);
            this.groupPanel1.Controls.Add(this.buttonCredentials);
            this.groupPanel1.Controls.Add(this.buttonBrowseServer);
            this.groupPanel1.Controls.Add(this.textServer);
            this.groupPanel1.Controls.Add(this.buttonSearch);
            this.groupPanel1.Controls.Add(this.labelSearchText);
            this.groupPanel1.Controls.Add(this.labelDatabase);
            this.groupPanel1.Controls.Add(this.labelServer);
            this.groupPanel1.IsShadowEnabled = true;
            this.groupPanel1.Location = new System.Drawing.Point(8, 6);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(993, 156);
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
            this.groupPanel1.TabIndex = 24;
            this.groupPanel1.Text = "Search Criteria";
            // 
            // groupPanel2
            // 
            this.groupPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.textLimit);
            this.groupPanel2.Controls.Add(this.radioButtonLimit);
            this.groupPanel2.Controls.Add(this.checkBoxIncludeSystemDatabases);
            this.groupPanel2.Controls.Add(this.labelLimit);
            this.groupPanel2.Controls.Add(this.checkAllowWildcards);
            this.groupPanel2.Controls.Add(this.checkMatchCase);
            this.groupPanel2.IsShadowEnabled = true;
            this.groupPanel2.Location = new System.Drawing.Point(788, 6);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(193, 126);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
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
            this.groupPanel2.TabIndex = 33;
            this.groupPanel2.Text = "Search Options";
            // 
            // textLimit
            // 
            this.textLimit.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.textLimit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textLimit.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.textLimit.Location = new System.Drawing.Point(85, 6);
            this.textLimit.MaxValue = 999;
            this.textLimit.MinValue = 1;
            this.textLimit.Name = "textLimit";
            this.textLimit.Size = new System.Drawing.Size(32, 20);
            this.textLimit.TabIndex = 35;
            this.textLimit.Value = 500;
            // 
            // radioButtonLimit
            // 
            this.radioButtonLimit.AutoSize = true;
            this.radioButtonLimit.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioButtonLimit.BackgroundStyle.Class = "";
            this.radioButtonLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioButtonLimit.Checked = true;
            this.radioButtonLimit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioButtonLimit.CheckValue = "Y";
            this.radioButtonLimit.Location = new System.Drawing.Point(3, 6);
            this.radioButtonLimit.Name = "radioButtonLimit";
            this.radioButtonLimit.Size = new System.Drawing.Size(86, 15);
            this.radioButtonLimit.TabIndex = 34;
            this.radioButtonLimit.Text = "&Limit to first";
            // 
            // checkBoxIncludeSystemDatabases
            // 
            this.checkBoxIncludeSystemDatabases.AutoSize = true;
            this.checkBoxIncludeSystemDatabases.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxIncludeSystemDatabases.BackgroundStyle.Class = "";
            this.checkBoxIncludeSystemDatabases.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxIncludeSystemDatabases.Location = new System.Drawing.Point(3, 66);
            this.checkBoxIncludeSystemDatabases.Name = "checkBoxIncludeSystemDatabases";
            this.checkBoxIncludeSystemDatabases.Size = new System.Drawing.Size(149, 15);
            this.checkBoxIncludeSystemDatabases.TabIndex = 39;
            this.checkBoxIncludeSystemDatabases.Text = "Include system databases";
            // 
            // labelLimit
            // 
            this.labelLimit.AutoSize = true;
            this.labelLimit.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelLimit.BackgroundStyle.Class = "";
            this.labelLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelLimit.Location = new System.Drawing.Point(123, 9);
            this.labelLimit.Name = "labelLimit";
            this.labelLimit.Size = new System.Drawing.Size(44, 15);
            this.labelLimit.TabIndex = 36;
            this.labelLimit.Text = "matches";
            // 
            // checkAllowWildcards
            // 
            this.checkAllowWildcards.AutoSize = true;
            this.checkAllowWildcards.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkAllowWildcards.BackgroundStyle.Class = "";
            this.checkAllowWildcards.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkAllowWildcards.Location = new System.Drawing.Point(3, 46);
            this.checkAllowWildcards.Name = "checkAllowWildcards";
            this.checkAllowWildcards.Size = new System.Drawing.Size(116, 15);
            this.checkAllowWildcards.TabIndex = 38;
            this.checkAllowWildcards.Text = "Use SQL wildcards";
            // 
            // checkMatchCase
            // 
            this.checkMatchCase.AutoSize = true;
            this.checkMatchCase.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkMatchCase.BackgroundStyle.Class = "";
            this.checkMatchCase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkMatchCase.Location = new System.Drawing.Point(3, 26);
            this.checkMatchCase.Name = "checkMatchCase";
            this.checkMatchCase.Size = new System.Drawing.Size(179, 15);
            this.checkMatchCase.TabIndex = 37;
            this.checkMatchCase.Text = "Perform a case-sensitive search";
            // 
            // buttonBrowseDatabase
            // 
            this.buttonBrowseDatabase.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseDatabase.BackColor = System.Drawing.Color.White;
            this.buttonBrowseDatabase.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseDatabase.Enabled = false;
            this.buttonBrowseDatabase.Location = new System.Drawing.Point(386, 34);
            this.buttonBrowseDatabase.Name = "buttonBrowseDatabase";
            this.buttonBrowseDatabase.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseDatabase.TabIndex = 35;
            this.buttonBrowseDatabase.Text = "...";
            this.buttonBrowseDatabase.Click += new System.EventHandler(this.buttonBrowseDatabase_Click);
            // 
            // groupObjectTypes
            // 
            this.groupObjectTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupObjectTypes.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupObjectTypes.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupObjectTypes.Controls.Add(this.checkJobs);
            this.groupObjectTypes.Controls.Add(this.checkTriggers);
            this.groupObjectTypes.Controls.Add(this.checkFunctions);
            this.groupObjectTypes.Controls.Add(this.checkViews);
            this.groupObjectTypes.Controls.Add(this.checkStoredProcedures);
            this.groupObjectTypes.IsShadowEnabled = true;
            this.groupObjectTypes.Location = new System.Drawing.Point(642, 6);
            this.groupObjectTypes.Name = "groupObjectTypes";
            this.groupObjectTypes.Size = new System.Drawing.Size(136, 126);
            // 
            // 
            // 
            this.groupObjectTypes.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupObjectTypes.Style.BackColorGradientAngle = 90;
            this.groupObjectTypes.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupObjectTypes.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupObjectTypes.Style.BorderBottomWidth = 1;
            this.groupObjectTypes.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupObjectTypes.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupObjectTypes.Style.BorderLeftWidth = 1;
            this.groupObjectTypes.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupObjectTypes.Style.BorderRightWidth = 1;
            this.groupObjectTypes.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupObjectTypes.Style.BorderTopWidth = 1;
            this.groupObjectTypes.Style.Class = "";
            this.groupObjectTypes.Style.CornerDiameter = 4;
            this.groupObjectTypes.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupObjectTypes.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupObjectTypes.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupObjectTypes.StyleMouseDown.Class = "";
            this.groupObjectTypes.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupObjectTypes.StyleMouseOver.Class = "";
            this.groupObjectTypes.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupObjectTypes.TabIndex = 28;
            this.groupObjectTypes.Text = "Object Types to Search";
            // 
            // checkJobs
            // 
            this.checkJobs.AutoSize = true;
            this.checkJobs.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkJobs.BackgroundStyle.Class = "";
            this.checkJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkJobs.Checked = true;
            this.checkJobs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkJobs.CheckValue = "Y";
            this.checkJobs.Location = new System.Drawing.Point(2, 86);
            this.checkJobs.Name = "checkJobs";
            this.checkJobs.Size = new System.Drawing.Size(79, 15);
            this.checkJobs.TabIndex = 32;
            this.checkJobs.Text = "&Job Steps";
            this.checkJobs.CheckedChanged += new System.EventHandler(this.checkJobs_CheckedChanged);
            // 
            // checkTriggers
            // 
            this.checkTriggers.AutoSize = true;
            this.checkTriggers.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkTriggers.BackgroundStyle.Class = "";
            this.checkTriggers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkTriggers.Checked = true;
            this.checkTriggers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkTriggers.CheckValue = "Y";
            this.checkTriggers.Location = new System.Drawing.Point(2, 66);
            this.checkTriggers.Name = "checkTriggers";
            this.checkTriggers.Size = new System.Drawing.Size(70, 15);
            this.checkTriggers.TabIndex = 31;
            this.checkTriggers.Text = "Tri&ggers";
            this.checkTriggers.CheckedChanged += new System.EventHandler(this.checkTriggers_CheckedChanged);
            // 
            // checkFunctions
            // 
            this.checkFunctions.AutoSize = true;
            this.checkFunctions.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkFunctions.BackgroundStyle.Class = "";
            this.checkFunctions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkFunctions.Checked = true;
            this.checkFunctions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkFunctions.CheckValue = "Y";
            this.checkFunctions.Location = new System.Drawing.Point(2, 46);
            this.checkFunctions.Name = "checkFunctions";
            this.checkFunctions.Size = new System.Drawing.Size(78, 15);
            this.checkFunctions.TabIndex = 30;
            this.checkFunctions.Text = "&Functions";
            this.checkFunctions.CheckedChanged += new System.EventHandler(this.checkFunctions_CheckedChanged);
            // 
            // checkViews
            // 
            this.checkViews.AutoSize = true;
            this.checkViews.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkViews.BackgroundStyle.Class = "";
            this.checkViews.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkViews.Checked = true;
            this.checkViews.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkViews.CheckValue = "Y";
            this.checkViews.Location = new System.Drawing.Point(2, 26);
            this.checkViews.Name = "checkViews";
            this.checkViews.Size = new System.Drawing.Size(59, 15);
            this.checkViews.TabIndex = 29;
            this.checkViews.Text = "Vie&ws";
            this.checkViews.CheckedChanged += new System.EventHandler(this.checkViews_CheckedChanged);
            // 
            // checkStoredProcedures
            // 
            this.checkStoredProcedures.AutoSize = true;
            this.checkStoredProcedures.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkStoredProcedures.BackgroundStyle.Class = "";
            this.checkStoredProcedures.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkStoredProcedures.Checked = true;
            this.checkStoredProcedures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkStoredProcedures.CheckValue = "Y";
            this.checkStoredProcedures.Location = new System.Drawing.Point(2, 6);
            this.checkStoredProcedures.Name = "checkStoredProcedures";
            this.checkStoredProcedures.Size = new System.Drawing.Size(121, 15);
            this.checkStoredProcedures.TabIndex = 28;
            this.checkStoredProcedures.Text = "Sto&red Procedures";
            this.checkStoredProcedures.CheckedChanged += new System.EventHandler(this.checkStoredProcedures_CheckedChanged);
            // 
            // textSearchText
            // 
            // 
            // 
            // 
            this.textSearchText.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textSearchText.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textSearchText.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textSearchText.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textSearchText.Border.Class = "TextBoxBorder";
            this.textSearchText.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textSearchText.Location = new System.Drawing.Point(74, 61);
            this.textSearchText.Name = "textSearchText";
            this.textSearchText.Size = new System.Drawing.Size(306, 20);
            this.textSearchText.TabIndex = 26;
            this.textSearchText.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.textSearchText.WatermarkText = "Text for which to search";
            this.textSearchText.TextChanged += new System.EventHandler(this.textSearchText_TextChanged);
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
            this.textDatabase.Location = new System.Drawing.Point(74, 34);
            this.textDatabase.Name = "textDatabase";
            this.textDatabase.Size = new System.Drawing.Size(307, 20);
            this.textDatabase.TabIndex = 25;
            this.textDatabase.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.textDatabase.WatermarkText = "Database name or leave Blank to search All";
            this.textDatabase.TextChanged += new System.EventHandler(this.textDatabase_TextChanged);
            // 
            // buttonCredentials
            // 
            this.buttonCredentials.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCredentials.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCredentials.BackColor = System.Drawing.Color.White;
            this.buttonCredentials.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCredentials.Image = ((System.Drawing.Image)(resources.GetObject("buttonCredentials.Image")));
            this.buttonCredentials.Location = new System.Drawing.Point(410, 6);
            this.buttonCredentials.Name = "buttonCredentials";
            this.buttonCredentials.Size = new System.Drawing.Size(20, 20);
            this.buttonCredentials.TabIndex = 24;
            this.buttonCredentials.Click += new System.EventHandler(this.buttonCredentials_Click);
            // 
            // buttonBrowseServer
            // 
            this.buttonBrowseServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseServer.BackColor = System.Drawing.Color.White;
            this.buttonBrowseServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseServer.Location = new System.Drawing.Point(386, 6);
            this.buttonBrowseServer.Name = "buttonBrowseServer";
            this.buttonBrowseServer.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseServer.TabIndex = 22;
            this.buttonBrowseServer.Text = "...";
            this.buttonBrowseServer.Click += new System.EventHandler(this.buttonBrowseServer_Click);
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
            this.textServer.Location = new System.Drawing.Point(74, 6);
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(307, 20);
            this.textServer.TabIndex = 21;
            this.textServer.Text = "(local)";
            this.textServer.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.textServer.WatermarkText = "SQL Server Name";
            this.textServer.TextChanged += new System.EventHandler(this.textServer_TextChanged);
            this.textServer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textServer_KeyPress);
            // 
            // buttonSearch
            // 
            this.buttonSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.BackColor = System.Drawing.Color.White;
            this.buttonSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSearch.Enabled = false;
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.Location = new System.Drawing.Point(75, 89);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(306, 36);
            this.buttonSearch.TabIndex = 20;
            this.buttonSearch.Text = "     &Perform Search     ";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelSearchText
            // 
            this.labelSearchText.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelSearchText.BackgroundStyle.Class = "";
            this.labelSearchText.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSearchText.Location = new System.Drawing.Point(3, 64);
            this.labelSearchText.Name = "labelSearchText";
            this.labelSearchText.Size = new System.Drawing.Size(63, 12);
            this.labelSearchText.TabIndex = 19;
            this.labelSearchText.Text = "Search &Text:";
            // 
            // labelDatabase
            // 
            this.labelDatabase.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelDatabase.BackgroundStyle.Class = "";
            this.labelDatabase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelDatabase.Location = new System.Drawing.Point(4, 37);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(73, 12);
            this.labelDatabase.TabIndex = 18;
            this.labelDatabase.Text = "&Database:";
            // 
            // labelServer
            // 
            this.labelServer.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelServer.BackgroundStyle.Class = "";
            this.labelServer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer.Location = new System.Drawing.Point(4, 10);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(68, 12);
            this.labelServer.TabIndex = 17;
            this.labelServer.Text = "&SQL Server:";
            // 
            // panelBottom
            // 
            this.panelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBottom.Controls.Add(this.buttonView);
            this.panelBottom.Controls.Add(this.buttonCopyToClipboard);
            this.panelBottom.Controls.Add(this.labelNumberOfResults);
            this.panelBottom.Controls.Add(this.groupResults);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 348);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.panelBottom.Size = new System.Drawing.Size(1008, 245);
            this.panelBottom.TabIndex = 11;
            // 
            // buttonView
            // 
            this.buttonView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonView.BackColor = System.Drawing.Color.Transparent;
            this.buttonView.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonView.Enabled = false;
            this.buttonView.Image = ((System.Drawing.Image)(resources.GetObject("buttonView.Image")));
            this.buttonView.Location = new System.Drawing.Point(651, 211);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(149, 24);
            this.buttonView.TabIndex = 47;
            this.buttonView.Text = "&View Source";
            this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyToClipboard.BackColor = System.Drawing.Color.Transparent;
            this.buttonCopyToClipboard.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCopyToClipboard.Enabled = false;
            this.buttonCopyToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyToClipboard.Image")));
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(476, 211);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(169, 24);
            this.buttonCopyToClipboard.TabIndex = 46;
            this.buttonCopyToClipboard.Text = "&Copy Results To Clipboard";
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // labelNumberOfResults
            // 
            this.labelNumberOfResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelNumberOfResults.AutoSize = true;
            this.labelNumberOfResults.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelNumberOfResults.BackgroundStyle.Class = "";
            this.labelNumberOfResults.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelNumberOfResults.Location = new System.Drawing.Point(10, 221);
            this.labelNumberOfResults.Name = "labelNumberOfResults";
            this.labelNumberOfResults.TabIndex = 45;
            this.labelNumberOfResults.Text = "Number of Results Status Line";
            this.labelNumberOfResults.Visible = false;
            // 
            // groupResults
            // 
            this.groupResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            //this.groupResults.AutoScroll = true;
            this.groupResults.BackColor = System.Drawing.Color.Transparent;
            this.groupResults.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupResults.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupResults.Controls.Add(this.labelEmptyResultSet);
            this.groupResults.Controls.Add(this.listResults);
            this.groupResults.IsShadowEnabled = true;
            this.groupResults.Location = new System.Drawing.Point(8, 4);
            this.groupResults.Name = "groupResults";
            this.groupResults.Size = new System.Drawing.Size(994, 195);
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
            this.groupResults.TabIndex = 41;
            this.groupResults.Text = "Search Results";
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
            this.labelEmptyResultSet.Location = new System.Drawing.Point(13, 51);
            this.labelEmptyResultSet.Name = "labelEmptyResultSet";
            this.labelEmptyResultSet.Size = new System.Drawing.Size(962, 68);
            this.labelEmptyResultSet.TabIndex = 43;
            this.labelEmptyResultSet.Text = "No matches found";
            this.labelEmptyResultSet.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelEmptyResultSet.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.labelEmptyResultSet.Visible = false;
            this.labelEmptyResultSet.WordWrap = true;
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
           // this.listResults.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.listResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listResults.ContextMenuStrip = this.contextMenuStrip1;
            this.listResults.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listResults.FullRowSelect = true;
            this.listResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listResults.Location = new System.Drawing.Point(7, 7);
            this.listResults.Name = "listResults";
            this.listResults.Size = new System.Drawing.Size(981, 203);
            this.listResults.TabIndex = 42;
            this.listResults.UseCompatibleStateImageBehavior = false;
            this.listResults.View = System.Windows.Forms.View.Details;
            this.listResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listResults_ColumnClick);
            this.listResults.SelectedIndexChanged += new System.EventHandler(this.listResults_SelectedIndexChanged);
            this.listResults.DoubleClick += new System.EventHandler(this.listResults_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Database";
            this.columnHeader1.Width = 123;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 114;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 129;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "SQL  Excerpt";
            this.columnHeader4.Width = 600;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuViewSQLSource,
            this.toolStripMenuItem5,
            this.contextMenuCopy,
            this.contextMenuSelectAll,
            this.toolStripMenuItem7,
            this.contextMenuExport});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 104);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.regularListViewMenu_Opening);
            // 
            // contextMenuViewSQLSource
            // 
            this.contextMenuViewSQLSource.Enabled = false;
            this.contextMenuViewSQLSource.Name = "contextMenuViewSQLSource";
            this.contextMenuViewSQLSource.Size = new System.Drawing.Size(139, 22);
            this.contextMenuViewSQLSource.Text = "&View Source";
            this.contextMenuViewSQLSource.Click += new System.EventHandler(this.contextMenuViewSQLSource_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(136, 6);
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.Enabled = false;
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.contextMenuCopy.Size = new System.Drawing.Size(139, 22);
            this.contextMenuCopy.Text = "&Copy";
            this.contextMenuCopy.Click += new System.EventHandler(this.contextMenuCopy_Click);
            // 
            // contextMenuSelectAll
            // 
            this.contextMenuSelectAll.Enabled = false;
            this.contextMenuSelectAll.Name = "contextMenuSelectAll";
            this.contextMenuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.contextMenuSelectAll.Size = new System.Drawing.Size(139, 22);
            this.contextMenuSelectAll.Text = "Select &All";
            this.contextMenuSelectAll.Click += new System.EventHandler(this.contextMenuSelectAll_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(136, 6);
            // 
            // contextMenuExport
            // 
            this.contextMenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuExportAsCSV,
            this.contextMenuExportAsXML});
            this.contextMenuExport.Enabled = false;
            this.contextMenuExport.Name = "contextMenuExport";
            this.contextMenuExport.Size = new System.Drawing.Size(139, 22);
            this.contextMenuExport.Text = "Save Results As";
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
            this.contextMenuExportAsXML.Text = "XML File";
            this.contextMenuExportAsXML.Click += new System.EventHandler(this.contextMenuExportAsXML_Click);
            // 
            // ideraTitleBar1
            // 
            this.ideraTitleBar1.ActivateLicenseEventHandler = null;
            this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
            this.ideraTitleBar1.Close = true;
            this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
            this.ideraTitleBar1.IderaProductNameText = "SQL Search";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.IsFormLocked = false;
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = true;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(1008, 93);
            this.ideraTitleBar1.TabIndex = 12;
            this.ideraTitleBar1.TrialMode = true;
            this.ideraTitleBar1.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar1_LicenseInfoButtonClick);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 593);
            this.ControlBox = false;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
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
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolProductBanner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textLimit)).EndInit();
            this.groupObjectTypes.ResumeLayout(false);
            this.groupObjectTypes.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.groupResults.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
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
       private System.Windows.Forms.Panel panelTop;
       private System.Windows.Forms.Panel panelBottom;
       private System.Windows.Forms.PictureBox pictureBoxTitle;
       private System.Windows.Forms.ToolStripMenuItem menuExitToLaunchpad;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
       private System.Windows.Forms.ToolStripMenuItem menuLaunchpad;
       private DevComponents.DotNetBar.Controls.ReflectionLabel labelTitle;
       private DevComponents.DotNetBar.Controls.ListViewEx listResults;
       private System.Windows.Forms.ColumnHeader columnHeader1;
       private System.Windows.Forms.ColumnHeader columnHeader2;
       private System.Windows.Forms.ColumnHeader columnHeader3;
       private System.Windows.Forms.ColumnHeader columnHeader4;
       private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
       private DevComponents.DotNetBar.LabelX labelServer;
       private DevComponents.DotNetBar.LabelX labelSearchText;
       private DevComponents.DotNetBar.LabelX labelDatabase;
       private DevComponents.DotNetBar.Controls.TextBoxX textServer;
       private DevComponents.DotNetBar.ButtonX buttonSearch;
       private DevComponents.DotNetBar.ButtonX buttonBrowseServer;
       private DevComponents.DotNetBar.Controls.TextBoxX textSearchText;
       private DevComponents.DotNetBar.Controls.TextBoxX textDatabase;
       private DevComponents.DotNetBar.ButtonX buttonCredentials;
       private DevComponents.DotNetBar.Controls.GroupPanel groupResults;
       private DevComponents.DotNetBar.Controls.GroupPanel groupObjectTypes;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkTriggers;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkFunctions;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkViews;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkStoredProcedures;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkMatchCase;
       private DevComponents.DotNetBar.LabelX labelLimit;
       private DevComponents.DotNetBar.Controls.CheckBoxX radioButtonLimit;
       private DevComponents.DotNetBar.ButtonX buttonView;
       private DevComponents.DotNetBar.ButtonX buttonCopyToClipboard;
       private DevComponents.DotNetBar.LabelX labelNumberOfResults;
       private DevComponents.DotNetBar.LabelX labelSubtitle;
       private DevComponents.DotNetBar.ButtonX buttonBrowseDatabase;
       private System.Windows.Forms.ToolStripMenuItem menuToolsetOptions;
       private DevComponents.DotNetBar.LabelX labelEmptyResultSet;
       private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
       private System.Windows.Forms.ToolStripMenuItem contextMenuViewSQLSource;
       private System.Windows.Forms.ToolStripMenuItem contextMenuCopy;
       private System.Windows.Forms.ToolStripMenuItem menuManageServerGroups;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkAllowWildcards;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxIncludeSystemDatabases;
       private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
       private System.Windows.Forms.ToolStripMenuItem menuEdit;
       private System.Windows.Forms.ToolStripMenuItem menuCopy;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
       private System.Windows.Forms.ToolStripMenuItem menuExport;
       private System.Windows.Forms.ToolStripMenuItem menuExportAsCSV;
       private System.Windows.Forms.ToolStripMenuItem menuExportAsXML;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
       private System.Windows.Forms.ToolStripMenuItem contextMenuExport;
       private System.Windows.Forms.ToolStripMenuItem contextMenuExportAsCSV;
       private System.Windows.Forms.ToolStripMenuItem contextMenuExportAsXML;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
       private System.Windows.Forms.ToolStripMenuItem menuSelectAll;
       private System.Windows.Forms.ToolStripMenuItem contextMenuSelectAll;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkJobs;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
        private DevComponents.Editors.IntegerInput textLimit;
    }
}

