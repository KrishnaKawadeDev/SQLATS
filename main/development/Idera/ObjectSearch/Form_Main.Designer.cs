namespace Idera.SqlAdminToolset.ObjectSearch
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
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ServerSelection = new Idera.SqlAdminToolset.Core.Controls.ToolServerSelection();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textLimit = new DevComponents.Editors.IntegerInput();
            this.radioButtonLimit = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxExcludeSystemObjects = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.textDatabase = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelLimit = new DevComponents.DotNetBar.LabelX();
            this.checkAllowWildcards = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkMatchCase = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelDatabase = new DevComponents.DotNetBar.LabelX();
            this.textSearchText = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonSearch = new DevComponents.DotNetBar.ButtonX();
            this.labelSearchText = new DevComponents.DotNetBar.LabelX();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonCopyToClipboard = new DevComponents.DotNetBar.ButtonX();
            this.labelNumberOfResults = new DevComponents.DotNetBar.LabelX();
            this.groupResults = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelEmptyResultSet = new DevComponents.DotNetBar.LabelX();
            this.listResults = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.colObject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colObjectType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDatabase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colParent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colParentType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExportAsCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExportAsXML = new System.Windows.Forms.ToolStripMenuItem();
            this.listImages = new System.Windows.Forms.ImageList(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.menuStrip1.SuspendLayout();
            this.toolProductBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.panelTop.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textLimit)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(942, 24);
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
            this.menuExportAsCSV.Size = new System.Drawing.Size(262, 22);
            this.menuExportAsCSV.Text = "&Comma Separated Values (CSV File)";
            this.menuExportAsCSV.Click += new System.EventHandler(this.menuExportAsCSV_Click);
            // 
            // menuExportAsXML
            // 
            this.menuExportAsXML.Name = "menuExportAsXML";
            this.menuExportAsXML.Size = new System.Drawing.Size(262, 22);
            this.menuExportAsXML.Text = "&XML File";
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
            this.menuAbout.Text = "&About Object Search";
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
            this.toolProductBanner.Size = new System.Drawing.Size(942, 52);
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
            this.labelSubtitle.Location = new System.Drawing.Point(370, 0);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(408, 52);
            this.labelSubtitle.TabIndex = 4;
            this.labelSubtitle.Text = "Find objects by name anywhere they are hiding in your SQL Servers.";
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
            this.labelTitle.Size = new System.Drawing.Size(400, 52);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Object Search</font></b> ";
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
            this.panelTop.Location = new System.Drawing.Point(0, 169);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.panelTop.Size = new System.Drawing.Size(942, 140);
            this.panelTop.TabIndex = 10;
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.ServerSelection);
            this.groupPanel1.Controls.Add(this.groupPanel2);
            this.groupPanel1.Controls.Add(this.textSearchText);
            this.groupPanel1.Controls.Add(this.buttonSearch);
            this.groupPanel1.Controls.Add(this.labelSearchText);
            this.groupPanel1.IsShadowEnabled = true;
            this.groupPanel1.Location = new System.Drawing.Point(8, 6);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(928, 130);
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
            this.groupPanel1.Text = "Search Criteria";
            // 
            // ServerSelection
            // 
            this.ServerSelection.BackColor = System.Drawing.Color.Transparent;
            this.ServerSelection.Caption = "";
            this.ServerSelection.CredentialsVisible = true;
            this.ServerSelection.Location = new System.Drawing.Point(4, 6);
            this.ServerSelection.MinimumSize = new System.Drawing.Size(290, 40);
            this.ServerSelection.Name = "ServerSelection";
            this.ServerSelection.SelectionOptions = Idera.SqlAdminToolset.Core.Controls.ServerSelectionOptions.ServersAndGroups;
            this.ServerSelection.Size = new System.Drawing.Size(402, 48);
            this.ServerSelection.TabIndex = 1;
            this.ServerSelection.TextChangedEventHandler = null;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.textLimit);
            this.groupPanel2.Controls.Add(this.radioButtonLimit);
            this.groupPanel2.Controls.Add(this.checkBoxExcludeSystemObjects);
            this.groupPanel2.Controls.Add(this.textDatabase);
            this.groupPanel2.Controls.Add(this.labelLimit);
            this.groupPanel2.Controls.Add(this.checkAllowWildcards);
            this.groupPanel2.Controls.Add(this.checkMatchCase);
            this.groupPanel2.Controls.Add(this.labelDatabase);
            this.groupPanel2.IsShadowEnabled = true;
            this.groupPanel2.Location = new System.Drawing.Point(571, 6);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(330, 98);
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
            this.groupPanel2.TabIndex = 5;
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
            this.textLimit.Location = new System.Drawing.Point(84, 5);
            this.textLimit.MaxValue = 999;
            this.textLimit.MinValue = 1;
            this.textLimit.Name = "textLimit";
            this.textLimit.Size = new System.Drawing.Size(32, 20);
            this.textLimit.TabIndex = 7;
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
            this.radioButtonLimit.Location = new System.Drawing.Point(2, 6);
            this.radioButtonLimit.Name = "radioButtonLimit";
            this.radioButtonLimit.Size = new System.Drawing.Size(86, 15);
            this.radioButtonLimit.TabIndex = 6;
            this.radioButtonLimit.Text = "&Limit to first";
            // 
            // checkBoxExcludeSystemObjects
            // 
            this.checkBoxExcludeSystemObjects.AutoSize = true;
            this.checkBoxExcludeSystemObjects.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxExcludeSystemObjects.BackgroundStyle.Class = "";
            this.checkBoxExcludeSystemObjects.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxExcludeSystemObjects.Location = new System.Drawing.Point(170, 28);
            this.checkBoxExcludeSystemObjects.Name = "checkBoxExcludeSystemObjects";
            this.checkBoxExcludeSystemObjects.Size = new System.Drawing.Size(137, 15);
            this.checkBoxExcludeSystemObjects.TabIndex = 11;
            this.checkBoxExcludeSystemObjects.Text = "Exclude system objects";
            // 
            // textDatabase
            // 
            // 
            // 
            // 
            this.textDatabase.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textDatabase.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textDatabase.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textDatabase.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textDatabase.Border.Class = "TextBoxBorder";
            this.textDatabase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textDatabase.Location = new System.Drawing.Point(58, 51);
            this.textDatabase.Name = "textDatabase";
            this.textDatabase.Size = new System.Drawing.Size(245, 20);
            this.textDatabase.TabIndex = 13;
            this.textDatabase.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.textDatabase.WatermarkText = "Database name or leave Blank to search All";
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
            this.labelLimit.Location = new System.Drawing.Point(120, 8);
            this.labelLimit.Name = "labelLimit";
            this.labelLimit.Size = new System.Drawing.Size(44, 15);
            this.labelLimit.TabIndex = 8;
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
            this.checkAllowWildcards.Location = new System.Drawing.Point(170, 6);
            this.checkAllowWildcards.Name = "checkAllowWildcards";
            this.checkAllowWildcards.Size = new System.Drawing.Size(116, 15);
            this.checkAllowWildcards.TabIndex = 10;
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
            this.checkMatchCase.Location = new System.Drawing.Point(2, 28);
            this.checkMatchCase.Name = "checkMatchCase";
            this.checkMatchCase.Size = new System.Drawing.Size(131, 15);
            this.checkMatchCase.TabIndex = 9;
            this.checkMatchCase.Text = "Case-sensitive search";
            // 
            // labelDatabase
            // 
            this.labelDatabase.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelDatabase.BackgroundStyle.Class = "";
            this.labelDatabase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelDatabase.Location = new System.Drawing.Point(5, 54);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(58, 12);
            this.labelDatabase.TabIndex = 12;
            this.labelDatabase.Text = "&Database:";
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
            this.textSearchText.Location = new System.Drawing.Point(91, 56);
            this.textSearchText.Name = "textSearchText";
            this.textSearchText.Size = new System.Drawing.Size(282, 20);
            this.textSearchText.TabIndex = 3;
            this.textSearchText.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.textSearchText.WatermarkText = "Text for which to search";
            this.textSearchText.TextChanged += new System.EventHandler(this.textSearchText_TextChanged);
            // 
            // buttonSearch
            // 
            this.buttonSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSearch.BackColor = System.Drawing.Color.White;
            this.buttonSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSearch.Enabled = false;
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonSearch.Location = new System.Drawing.Point(416, 6);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(138, 98);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "&Perform Search";
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
            this.labelSearchText.Location = new System.Drawing.Point(9, 59);
            this.labelSearchText.Name = "labelSearchText";
            this.labelSearchText.Size = new System.Drawing.Size(63, 12);
            this.labelSearchText.TabIndex = 2;
            this.labelSearchText.Text = "Search &Text:";
            // 
            // panelBottom
            // 
            this.panelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBottom.Controls.Add(this.buttonCopyToClipboard);
            this.panelBottom.Controls.Add(this.labelNumberOfResults);
            this.panelBottom.Controls.Add(this.groupResults);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 309);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.panelBottom.Size = new System.Drawing.Size(942, 270);
            this.panelBottom.TabIndex = 11;
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyToClipboard.BackColor = System.Drawing.Color.Transparent;
            this.buttonCopyToClipboard.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCopyToClipboard.Enabled = false;
            this.buttonCopyToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyToClipboard.Image")));
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(767, 240);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(169, 24);
            this.buttonCopyToClipboard.TabIndex = 18;
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
            this.labelNumberOfResults.Location = new System.Drawing.Point(10, 246);
            this.labelNumberOfResults.Name = "labelNumberOfResults";
            this.labelNumberOfResults.TabIndex = 17;
            this.labelNumberOfResults.Text = "Number of Results Status Line";
            this.labelNumberOfResults.Visible = false;
            // 
            // groupResults
            // 
            this.groupResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupResults.BackColor = System.Drawing.Color.Transparent;
            this.groupResults.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupResults.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupResults.Controls.Add(this.labelEmptyResultSet);
            this.groupResults.Controls.Add(this.listResults);
            this.groupResults.IsShadowEnabled = true;
            this.groupResults.Location = new System.Drawing.Point(8, 4);
            this.groupResults.Name = "groupResults";
            this.groupResults.Size = new System.Drawing.Size(928, 228);
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
            this.groupResults.TabIndex = 14;
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
            this.labelEmptyResultSet.Size = new System.Drawing.Size(896, 68);
            this.labelEmptyResultSet.TabIndex = 16;
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
            this.listResults.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listResults.Border.Class = "ListViewBorder";
            this.listResults.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colObject,
            this.colObjectType,
            this.colServer,
            this.colDatabase,
            this.colParent,
            this.colParentType});
            this.listResults.ContextMenuStrip = this.contextMenuStrip1;
            this.listResults.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listResults.FullRowSelect = true;
            this.listResults.Location = new System.Drawing.Point(7, 7);
            this.listResults.Name = "listResults";
            this.listResults.ShowGroups = false;
            this.listResults.Size = new System.Drawing.Size(908, 197);
            this.listResults.SmallImageList = this.listImages;
            this.listResults.TabIndex = 15;
            this.listResults.UseCompatibleStateImageBehavior = false;
            this.listResults.View = System.Windows.Forms.View.Details;
            this.listResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listResults_ColumnClick);
            this.listResults.SelectedIndexChanged += new System.EventHandler(this.listResults_SelectedIndexChanged);
            // 
            // colObject
            // 
            this.colObject.Text = "Name";
            this.colObject.Width = 197;
            // 
            // colObjectType
            // 
            this.colObjectType.Text = "Type";
            this.colObjectType.Width = 124;
            // 
            // colServer
            // 
            this.colServer.Text = "Server";
            this.colServer.Width = 156;
            // 
            // colDatabase
            // 
            this.colDatabase.Text = "Database";
            this.colDatabase.Width = 131;
            // 
            // colParent
            // 
            this.colParent.Text = "Parent Object";
            this.colParent.Width = 149;
            // 
            // colParentType
            // 
            this.colParentType.Text = "Parent Type";
            this.colParentType.Width = 122;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuCopy,
            this.contextMenuSelectAll,
            this.toolStripMenuItem7,
            this.contextMenuExport});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 76);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.regularListViewMenu_Opening);
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
            this.contextMenuExportAsCSV.Size = new System.Drawing.Size(260, 22);
            this.contextMenuExportAsCSV.Text = "&Comma Separated Values (CSV file)";
            this.contextMenuExportAsCSV.Click += new System.EventHandler(this.contextMenuExportAsCSV_Click);
            // 
            // contextMenuExportAsXML
            // 
            this.contextMenuExportAsXML.Name = "contextMenuExportAsXML";
            this.contextMenuExportAsXML.Size = new System.Drawing.Size(260, 22);
            this.contextMenuExportAsXML.Text = "&XML File";
            this.contextMenuExportAsXML.Click += new System.EventHandler(this.contextMenuExportAsXML_Click);
            // 
            // listImages
            // 
            this.listImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("listImages.ImageStream")));
            this.listImages.TransparentColor = System.Drawing.Color.Transparent;
            this.listImages.Images.SetKeyName(0, "form_blue.png");
            this.listImages.Images.SetKeyName(1, "data.png");
            this.listImages.Images.SetKeyName(2, "table.png");
            this.listImages.Images.SetKeyName(3, "column.png");
            this.listImages.Images.SetKeyName(4, "index.png");
            this.listImages.Images.SetKeyName(5, "data_view.png");
            this.listImages.Images.SetKeyName(6, "flash.png");
            this.listImages.Images.SetKeyName(7, "data_scroll.png");
            this.listImages.Images.SetKeyName(8, "text_code.png");
            this.listImages.Images.SetKeyName(9, "scroll.png");
            this.listImages.Images.SetKeyName(10, "user2.png");
            this.listImages.Images.SetKeyName(11, "users1.png");
            this.listImages.Images.SetKeyName(12, "table_sql_run.png");
            // 
            // ideraTitleBar1
            // 
            this.ideraTitleBar1.ActivateLicenseEventHandler = null;
            this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
            this.ideraTitleBar1.Close = true;
            this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
            this.ideraTitleBar1.IderaProductNameText = "SQL Object Search";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = true;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(942, 93);
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
            this.ClientSize = new System.Drawing.Size(942, 579);
            this.ControlBox = false;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.toolProductBanner);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ideraTitleBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(592, 459);
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
       private DevComponents.DotNetBar.LabelX  labelTitle;
       private DevComponents.DotNetBar.Controls.ListViewEx listResults;
       private System.Windows.Forms.ColumnHeader colDatabase;
       private System.Windows.Forms.ColumnHeader colObject;
       private System.Windows.Forms.ColumnHeader colObjectType;
       private System.Windows.Forms.ColumnHeader colParent;
       private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
       private DevComponents.DotNetBar.LabelX labelSearchText;
       private DevComponents.DotNetBar.LabelX labelDatabase;
       private DevComponents.DotNetBar.ButtonX buttonSearch;
       private DevComponents.DotNetBar.Controls.TextBoxX textSearchText;
       private DevComponents.DotNetBar.Controls.TextBoxX textDatabase;
       private DevComponents.DotNetBar.Controls.GroupPanel groupResults;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkMatchCase;
       private DevComponents.DotNetBar.LabelX labelLimit;
       private DevComponents.DotNetBar.Controls.CheckBoxX radioButtonLimit;
       private DevComponents.DotNetBar.ButtonX buttonCopyToClipboard;
       private DevComponents.DotNetBar.LabelX labelNumberOfResults;
       private DevComponents.DotNetBar.LabelX labelSubtitle;
       private System.Windows.Forms.ToolStripMenuItem menuToolsetOptions;
       private DevComponents.DotNetBar.LabelX labelEmptyResultSet;
       private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
       private System.Windows.Forms.ToolStripMenuItem contextMenuCopy;
       private System.Windows.Forms.ToolStripMenuItem menuManageServerGroups;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkAllowWildcards;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxExcludeSystemObjects;
       private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
       private System.Windows.Forms.ToolStripMenuItem menuEdit;
       private System.Windows.Forms.ToolStripMenuItem menuCopy;
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
       private System.Windows.Forms.ColumnHeader colServer;
       private System.Windows.Forms.ColumnHeader colParentType;
       private System.Windows.Forms.ImageList listImages;
       private Idera.SqlAdminToolset.Core.Controls.ToolServerSelection ServerSelection;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
        private DevComponents.Editors.IntegerInput textLimit;
    }
}

