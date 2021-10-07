namespace Idera.SqlAdminToolset.DatabaseConfiguration
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Database Information (Read-Only)", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Auto", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Cursor", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Availability", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Date Correlation", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("External Access", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Parameterization", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Recovery", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Service Broker", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("Isolation", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("SQL", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("Database Information (Read-Only)", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup13 = new System.Windows.Forms.ListViewGroup("Auto", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup14 = new System.Windows.Forms.ListViewGroup("Cursor", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup15 = new System.Windows.Forms.ListViewGroup("Availability", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup16 = new System.Windows.Forms.ListViewGroup("Data Correlation", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup17 = new System.Windows.Forms.ListViewGroup("External Access", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup18 = new System.Windows.Forms.ListViewGroup("Parameterization", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup19 = new System.Windows.Forms.ListViewGroup("Recovery", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup20 = new System.Windows.Forms.ListViewGroup("Service Broker", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup21 = new System.Windows.Forms.ListViewGroup("Isolation", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup22 = new System.Windows.Forms.ListViewGroup("SQL", System.Windows.Forms.HorizontalAlignment.Left);
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkHideSystemDatabases = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.ServerSelection = new Idera.SqlAdminToolset.Core.Controls.ToolServerSelection();
            this.buttonGetConfiguration = new DevComponents.DotNetBar.ButtonX();
            this.groupResults = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.tabMainConfiguration = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.buttonConfigurationAddToComparison = new DevComponents.DotNetBar.ButtonItem();
            this.buttonConfigurationSaveSnapshot = new DevComponents.DotNetBar.ButtonItem();
            this.buttonSaveAllDatabases = new DevComponents.DotNetBar.ButtonItem();
            this.buttonConfigurationSetAsBaseline = new DevComponents.DotNetBar.ButtonItem();
            this.buttonConfigurationRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.PanelConfigurationContainer = new System.Windows.Forms.Panel();
            this.imageDataError = new System.Windows.Forms.PictureBox();
            this.listOptions = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnOptionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOptionValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuListOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemShowCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEditOption = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelDataError = new DevComponents.DotNetBar.LabelX();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.treeResults = new System.Windows.Forms.TreeView();
            this.contextComparisonReport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuItemAddDatabaseToComparison = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuItemAddServerToComparison = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuItemAddAllServersToComparison = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuItemSetAsBaseline = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuItemSaveSnapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.tabConfigurationResults = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel5 = new DevComponents.DotNetBar.TabControlPanel();
            this.barComparisonButtons = new DevComponents.DotNetBar.Bar();
            this.labelBaselineWarning = new DevComponents.DotNetBar.LabelItem();
            this.buttonAddToComparison = new DevComponents.DotNetBar.ButtonItem();
            this.buttonOpenSnapshot = new DevComponents.DotNetBar.ButtonItem();
            this.buttonSave = new DevComponents.DotNetBar.ButtonItem();
            this.buttonSaveAll = new DevComponents.DotNetBar.ButtonItem();
            this.buttonFixDifferences = new DevComponents.DotNetBar.ButtonItem();
            this.buttonFixDifferencesWithBaseline = new DevComponents.DotNetBar.ButtonItem();
            this.buttonFixDifferencesWithSnapshot = new DevComponents.DotNetBar.ButtonItem();
            this.buttonHighlightDifferences = new DevComponents.DotNetBar.ButtonItem();
            this.buttonCopyToClipboard = new DevComponents.DotNetBar.ButtonItem();
            this.buttonRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.buttonClear = new DevComponents.DotNetBar.ButtonItem();
            this.labelNoDatabasesToCompare = new DevComponents.DotNetBar.LabelX();
            this.listComparison = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextBulkEditMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuItemApplySingleSettingToServers = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuItemBulkUpdateSingleSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuItemClearItems = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuItemCopyItems = new System.Windows.Forms.ToolStripMenuItem();
            this.tabComparisonResults = new DevComponents.DotNetBar.TabItem(this.components);
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenSnapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveSnapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsXML = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAddDatabaseToComparison = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAddServerToComparison = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAddAllServersToComparison = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSetServerAsBaseline = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemRefreshComparison = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemClearComparison = new System.Windows.Forms.ToolStripMenuItem();
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
            this.contextComparisonHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuItemHeaderSetDatabaseAsBaseline = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuItemHeaderRemoveDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuItemHeaderCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuItemHeaderSaveSnapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.panelMiddle.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMainConfiguration)).BeginInit();
            this.tabMainConfiguration.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.PanelConfigurationContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageDataError)).BeginInit();
            this.contextMenuListOptions.SuspendLayout();
            this.contextComparisonReport.SuspendLayout();
            this.tabControlPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barComparisonButtons)).BeginInit();
            this.contextBulkEditMenuStrip.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextComparisonHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.groupPanel1);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMiddle.Location = new System.Drawing.Point(0, 169);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Padding = new System.Windows.Forms.Padding(6);
            this.panelMiddle.Size = new System.Drawing.Size(1030, 72);
            this.panelMiddle.TabIndex = 14;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.checkHideSystemDatabases);
            this.groupPanel1.Controls.Add(this.ServerSelection);
            this.groupPanel1.Controls.Add(this.buttonGetConfiguration);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.IsShadowEnabled = true;
            this.groupPanel1.Location = new System.Drawing.Point(6, 6);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1018, 60);
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
            // checkHideSystemDatabases
            // 
            this.checkHideSystemDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkHideSystemDatabases.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkHideSystemDatabases.BackgroundStyle.Class = "";
            this.checkHideSystemDatabases.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkHideSystemDatabases.Checked = true;
            this.checkHideSystemDatabases.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkHideSystemDatabases.CheckValue = "Y";
            this.checkHideSystemDatabases.Location = new System.Drawing.Point(708, 5);
            this.checkHideSystemDatabases.Name = "checkHideSystemDatabases";
            this.checkHideSystemDatabases.Size = new System.Drawing.Size(145, 23);
            this.checkHideSystemDatabases.TabIndex = 7;
            this.checkHideSystemDatabases.Text = "Hide System Databases";
            // 
            // ServerSelection
            // 
            this.ServerSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerSelection.BackColor = System.Drawing.Color.Transparent;
            this.ServerSelection.Caption = "";
            this.ServerSelection.CredentialsVisible = true;
            this.ServerSelection.Location = new System.Drawing.Point(16, 8);
            this.ServerSelection.MinimumSize = new System.Drawing.Size(0, 40);
            this.ServerSelection.Name = "ServerSelection";
            this.ServerSelection.SelectionOptions = Idera.SqlAdminToolset.Core.Controls.ServerSelectionOptions.ServersAndGroups;
            this.ServerSelection.Size = new System.Drawing.Size(686, 40);
            this.ServerSelection.TabIndex = 6;
            this.ServerSelection.TextChangedEventHandler = null;
            this.ServerSelection.TextChanged += new System.EventHandler(this.ServerSelection_TextChanged);
            // 
            // buttonGetConfiguration
            // 
            this.buttonGetConfiguration.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonGetConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetConfiguration.BackColor = System.Drawing.Color.White;
            this.buttonGetConfiguration.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonGetConfiguration.Image = ((System.Drawing.Image)(resources.GetObject("buttonGetConfiguration.Image")));
            this.buttonGetConfiguration.Location = new System.Drawing.Point(859, 2);
            this.buttonGetConfiguration.Name = "buttonGetConfiguration";
            this.buttonGetConfiguration.Size = new System.Drawing.Size(150, 46);
            this.buttonGetConfiguration.TabIndex = 5;
            this.buttonGetConfiguration.Text = "Get Configuration";
            this.buttonGetConfiguration.Click += new System.EventHandler(this.buttonGetResults_Click);
            // 
            // groupResults
            // 
            this.groupResults.BackColor = System.Drawing.Color.Transparent;
            this.groupResults.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupResults.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupResults.Controls.Add(this.tabMainConfiguration);
            this.groupResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupResults.IsShadowEnabled = true;
            this.groupResults.Location = new System.Drawing.Point(6, 3);
            this.groupResults.Name = "groupResults";
            this.groupResults.Size = new System.Drawing.Size(1018, 487);
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
            this.groupResults.Text = "Results";
            // 
            // tabMainConfiguration
            // 
            this.tabMainConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMainConfiguration.BackColor = System.Drawing.Color.Transparent;
            this.tabMainConfiguration.CanReorderTabs = false;
            this.tabMainConfiguration.CloseButtonOnTabsAlwaysDisplayed = false;
            this.tabMainConfiguration.Controls.Add(this.tabControlPanel2);
            this.tabMainConfiguration.Controls.Add(this.tabControlPanel5);
            this.tabMainConfiguration.FixedTabSize = new System.Drawing.Size(200, 0);
            this.tabMainConfiguration.Location = new System.Drawing.Point(3, 3);
            this.tabMainConfiguration.Name = "tabMainConfiguration";
            this.tabMainConfiguration.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabMainConfiguration.SelectedTabIndex = 0;
            this.tabMainConfiguration.Size = new System.Drawing.Size(1006, 460);
            this.tabMainConfiguration.TabIndex = 14;
            this.tabMainConfiguration.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabMainConfiguration.Tabs.Add(this.tabConfigurationResults);
            this.tabMainConfiguration.Tabs.Add(this.tabComparisonResults);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.bar1);
            this.tabControlPanel2.Controls.Add(this.PanelConfigurationContainer);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 42);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(1006, 418);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 1;
            this.tabControlPanel2.TabItem = this.tabConfigurationResults;
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "DotNetBar Bar (bar1)";
            this.bar1.AccessibleName = "DotNetBar Bar";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.bar1.BarType = DevComponents.DotNetBar.eBarType.MenuBar;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonConfigurationAddToComparison,
            this.buttonConfigurationSaveSnapshot,
            this.buttonConfigurationSetAsBaseline,
            this.buttonConfigurationRefresh});
            this.bar1.ItemSpacing = 5;
            this.bar1.Location = new System.Drawing.Point(1, 1);
            this.bar1.MenuBar = true;
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1004, 24);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.bar1.TabIndex = 47;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // buttonConfigurationAddToComparison
            // 
            this.buttonConfigurationAddToComparison.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonConfigurationAddToComparison.Enabled = false;
            this.buttonConfigurationAddToComparison.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfigurationAddToComparison.Image")));
            this.buttonConfigurationAddToComparison.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonConfigurationAddToComparison.Name = "buttonConfigurationAddToComparison";
            this.buttonConfigurationAddToComparison.Text = "Add to Comparison";
            this.buttonConfigurationAddToComparison.Click += new System.EventHandler(this.buttonConfigurationAddToComparison_Click);
            // 
            // buttonConfigurationSaveSnapshot
            // 
            this.buttonConfigurationSaveSnapshot.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonConfigurationSaveSnapshot.Enabled = false;
            this.buttonConfigurationSaveSnapshot.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfigurationSaveSnapshot.Image")));
            this.buttonConfigurationSaveSnapshot.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonConfigurationSaveSnapshot.Name = "buttonConfigurationSaveSnapshot";
            this.buttonConfigurationSaveSnapshot.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonSaveAllDatabases});
            this.buttonConfigurationSaveSnapshot.Text = "Save Snapshot";
            // 
            // buttonSaveAllDatabases
            // 
            this.buttonSaveAllDatabases.Name = "buttonSaveAllDatabases";
            this.buttonSaveAllDatabases.Text = "All Databases";
            this.buttonSaveAllDatabases.Click += new System.EventHandler(this.buttonSaveAllDatabases_Click);
            // 
            // buttonConfigurationSetAsBaseline
            // 
            this.buttonConfigurationSetAsBaseline.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonConfigurationSetAsBaseline.Enabled = false;
            this.buttonConfigurationSetAsBaseline.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfigurationSetAsBaseline.Image")));
            this.buttonConfigurationSetAsBaseline.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonConfigurationSetAsBaseline.Name = "buttonConfigurationSetAsBaseline";
            this.buttonConfigurationSetAsBaseline.Text = "Set as Baseline";
            // 
            // buttonConfigurationRefresh
            // 
            this.buttonConfigurationRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonConfigurationRefresh.Enabled = false;
            this.buttonConfigurationRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfigurationRefresh.Image")));
            this.buttonConfigurationRefresh.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonConfigurationRefresh.Name = "buttonConfigurationRefresh";
            this.buttonConfigurationRefresh.Text = "Refresh";
            this.buttonConfigurationRefresh.Click += new System.EventHandler(this.buttonConfigurationRefresh_Click);
            // 
            // PanelConfigurationContainer
            // 
            this.PanelConfigurationContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelConfigurationContainer.BackColor = System.Drawing.Color.Transparent;
            this.PanelConfigurationContainer.Controls.Add(this.imageDataError);
            this.PanelConfigurationContainer.Controls.Add(this.listOptions);
            this.PanelConfigurationContainer.Controls.Add(this.labelDataError);
            this.PanelConfigurationContainer.Controls.Add(this.expandableSplitter1);
            this.PanelConfigurationContainer.Controls.Add(this.treeResults);
            this.PanelConfigurationContainer.Location = new System.Drawing.Point(4, 31);
            this.PanelConfigurationContainer.Name = "PanelConfigurationContainer";
            this.PanelConfigurationContainer.Size = new System.Drawing.Size(998, 382);
            this.PanelConfigurationContainer.TabIndex = 46;
            // 
            // imageDataError
            // 
            this.imageDataError.BackColor = System.Drawing.Color.White;
            this.imageDataError.Image = ((System.Drawing.Image)(resources.GetObject("imageDataError.Image")));
            this.imageDataError.Location = new System.Drawing.Point(301, 58);
            this.imageDataError.Name = "imageDataError";
            this.imageDataError.Size = new System.Drawing.Size(34, 34);
            this.imageDataError.TabIndex = 22;
            this.imageDataError.TabStop = false;
            this.imageDataError.Visible = false;
            // 
            // listOptions
            // 
            // 
            // 
            // 
            this.listOptions.Border.Class = "ListViewBorder";
            this.listOptions.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listOptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnOptionName,
            this.columnOptionValue});
            this.listOptions.ContextMenuStrip = this.contextMenuListOptions;
            this.listOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listOptions.FullRowSelect = true;
            listViewGroup1.Header = "Database Information (Read-Only)";
            listViewGroup1.Name = "groupDatabaseInformation";
            listViewGroup2.Header = "Auto";
            listViewGroup2.Name = "groupAuto";
            listViewGroup3.Header = "Cursor";
            listViewGroup3.Name = "groupCursor";
            listViewGroup4.Header = "Availability";
            listViewGroup4.Name = "groupAvailability";
            listViewGroup5.Header = "Date Correlation";
            listViewGroup5.Name = "groupDateCorrelation";
            listViewGroup6.Header = "External Access";
            listViewGroup6.Name = "groupExternalAccess";
            listViewGroup7.Header = "Parameterization";
            listViewGroup7.Name = "groupParameterization";
            listViewGroup8.Header = "Recovery";
            listViewGroup8.Name = "groupRecovery";
            listViewGroup9.Header = "Service Broker";
            listViewGroup9.Name = "groupServiceBroker";
            listViewGroup10.Header = "Isolation";
            listViewGroup10.Name = "groupIsolation";
            listViewGroup11.Header = "SQL";
            listViewGroup11.Name = "groupSql";
            this.listOptions.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7,
            listViewGroup8,
            listViewGroup9,
            listViewGroup10,
            listViewGroup11});
            this.listOptions.Location = new System.Drawing.Point(255, 0);
            this.listOptions.MultiSelect = false;
            this.listOptions.Name = "listOptions";
            this.listOptions.Size = new System.Drawing.Size(743, 382);
            this.listOptions.SmallImageList = this.imageList1;
            this.listOptions.TabIndex = 20;
            this.listOptions.UseCompatibleStateImageBehavior = false;
            this.listOptions.View = System.Windows.Forms.View.Details;
            this.listOptions.DoubleClick += new System.EventHandler(this.listOptions_DoubleClick);
            // 
            // columnOptionName
            // 
            this.columnOptionName.Text = "Name";
            this.columnOptionName.Width = 349;
            // 
            // columnOptionValue
            // 
            this.columnOptionValue.Text = "Value";
            this.columnOptionValue.Width = 330;
            // 
            // contextMenuListOptions
            // 
            this.contextMenuListOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShowCategories,
            this.toolStripMenuItemEditOption});
            this.contextMenuListOptions.Name = "contextMenuListOptions";
            this.contextMenuListOptions.Size = new System.Drawing.Size(163, 48);
            // 
            // toolStripMenuItemShowCategories
            // 
            this.toolStripMenuItemShowCategories.Checked = true;
            this.toolStripMenuItemShowCategories.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemShowCategories.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItemShowCategories.Name = "toolStripMenuItemShowCategories";
            this.toolStripMenuItemShowCategories.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItemShowCategories.Text = "Show Categories";
            this.toolStripMenuItemShowCategories.Click += new System.EventHandler(this.toolStripMenuItemShowCategories_Click);
            // 
            // toolStripMenuItemEditOption
            // 
            this.toolStripMenuItemEditOption.Name = "toolStripMenuItemEditOption";
            this.toolStripMenuItemEditOption.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItemEditOption.Text = "Edit Option";
            this.toolStripMenuItemEditOption.Click += new System.EventHandler(this.toolStripMenuItemEditOption_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "server.png");
            this.imageList1.Images.SetKeyName(1, "data_into.png");
            this.imageList1.Images.SetKeyName(2, "data_certificate.ico");
            this.imageList1.Images.SetKeyName(3, "data_connection.ico");
            this.imageList1.Images.SetKeyName(4, "data_error.png");
            // 
            // labelDataError
            // 
            this.labelDataError.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelDataError.BackgroundStyle.Class = "";
            this.labelDataError.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelDataError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataError.Location = new System.Drawing.Point(341, 55);
            this.labelDataError.Name = "labelDataError";
            this.labelDataError.Size = new System.Drawing.Size(617, 241);
            this.labelDataError.TabIndex = 21;
            this.labelDataError.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.labelDataError.Visible = false;
            this.labelDataError.WordWrap = true;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandableControl = this.treeResults;
            this.expandableSplitter1.ExpandActionClick = false;
            this.expandableSplitter1.ExpandActionDoubleClick = true;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(139)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(250, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(5, 382);
            this.expandableSplitter1.TabIndex = 19;
            this.expandableSplitter1.TabStop = false;
            // 
            // treeResults
            // 
            this.treeResults.ContextMenuStrip = this.contextComparisonReport;
            this.treeResults.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeResults.HideSelection = false;
            this.treeResults.ImageIndex = 0;
            this.treeResults.ImageList = this.imageList1;
            this.treeResults.Location = new System.Drawing.Point(0, 0);
            this.treeResults.Name = "treeResults";
            this.treeResults.SelectedImageIndex = 0;
            this.treeResults.ShowNodeToolTips = true;
            this.treeResults.Size = new System.Drawing.Size(250, 382);
            this.treeResults.TabIndex = 0;
            this.treeResults.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeResults_AfterSelect);
            this.treeResults.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeResults_MouseUp);
            // 
            // contextComparisonReport
            // 
            this.contextComparisonReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuItemAddDatabaseToComparison,
            this.ContextMenuItemAddServerToComparison,
            this.contextMenuItemAddAllServersToComparison,
            this.toolStripSeparator1,
            this.contextMenuItemSetAsBaseline,
            this.contextMenuItemSaveSnapshot});
            this.contextComparisonReport.Name = "contextShowFailedOnly";
            this.contextComparisonReport.Size = new System.Drawing.Size(274, 120);
            // 
            // ContextMenuItemAddDatabaseToComparison
            // 
            this.ContextMenuItemAddDatabaseToComparison.Name = "ContextMenuItemAddDatabaseToComparison";
            this.ContextMenuItemAddDatabaseToComparison.Size = new System.Drawing.Size(273, 22);
            this.ContextMenuItemAddDatabaseToComparison.Text = "Add &Database to Comparison Report";
            this.ContextMenuItemAddDatabaseToComparison.Click += new System.EventHandler(this.ContextMenuItemAddDatabaseToComparison_Click);
            // 
            // ContextMenuItemAddServerToComparison
            // 
            this.ContextMenuItemAddServerToComparison.Name = "ContextMenuItemAddServerToComparison";
            this.ContextMenuItemAddServerToComparison.Size = new System.Drawing.Size(273, 22);
            this.ContextMenuItemAddServerToComparison.Text = "Add &Server to Comparison Report";
            this.ContextMenuItemAddServerToComparison.Click += new System.EventHandler(this.ContextMenuItemAddServerToComparison_Click);
            // 
            // contextMenuItemAddAllServersToComparison
            // 
            this.contextMenuItemAddAllServersToComparison.Name = "contextMenuItemAddAllServersToComparison";
            this.contextMenuItemAddAllServersToComparison.Size = new System.Drawing.Size(273, 22);
            this.contextMenuItemAddAllServersToComparison.Text = "&Add All Servers to Comparison Report";
            this.contextMenuItemAddAllServersToComparison.Click += new System.EventHandler(this.contextMenuItemAddAllServersToComparison_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(270, 6);
            // 
            // contextMenuItemSetAsBaseline
            // 
            this.contextMenuItemSetAsBaseline.Name = "contextMenuItemSetAsBaseline";
            this.contextMenuItemSetAsBaseline.Size = new System.Drawing.Size(273, 22);
            this.contextMenuItemSetAsBaseline.Text = "Set Selected Database as &Baseline";
            this.contextMenuItemSetAsBaseline.Click += new System.EventHandler(this.contextMenuItemSetAsBaseline_Click);
            // 
            // contextMenuItemSaveSnapshot
            // 
            this.contextMenuItemSaveSnapshot.Name = "contextMenuItemSaveSnapshot";
            this.contextMenuItemSaveSnapshot.Size = new System.Drawing.Size(273, 22);
            this.contextMenuItemSaveSnapshot.Text = "Save S&napshot";
            this.contextMenuItemSaveSnapshot.Click += new System.EventHandler(this.contextMenuItemSaveSnapshot_Click);
            // 
            // tabConfigurationResults
            // 
            this.tabConfigurationResults.AttachedControl = this.tabControlPanel2;
            this.tabConfigurationResults.Image = ((System.Drawing.Image)(resources.GetObject("tabConfigurationResults.Image")));
            this.tabConfigurationResults.Name = "tabConfigurationResults";
            this.tabConfigurationResults.Text = "Configuration";
            // 
            // tabControlPanel5
            // 
            this.tabControlPanel5.Controls.Add(this.barComparisonButtons);
            this.tabControlPanel5.Controls.Add(this.labelNoDatabasesToCompare);
            this.tabControlPanel5.Controls.Add(this.listComparison);
            this.tabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel5.Location = new System.Drawing.Point(0, 42);
            this.tabControlPanel5.Name = "tabControlPanel5";
            this.tabControlPanel5.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel5.Size = new System.Drawing.Size(1006, 418);
            this.tabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel5.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel5.Style.GradientAngle = 90;
            this.tabControlPanel5.TabIndex = 2;
            this.tabControlPanel5.TabItem = this.tabComparisonResults;
            // 
            // barComparisonButtons
            // 
            this.barComparisonButtons.AccessibleDescription = "DotNetBar Bar (barComparisonButtons)";
            this.barComparisonButtons.AccessibleName = "DotNetBar Bar";
            this.barComparisonButtons.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.barComparisonButtons.BarType = DevComponents.DotNetBar.eBarType.MenuBar;
            this.barComparisonButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barComparisonButtons.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.barComparisonButtons.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelBaselineWarning,
            this.buttonAddToComparison,
            this.buttonOpenSnapshot,
            this.buttonSave,
            this.buttonFixDifferences,
            this.buttonHighlightDifferences,
            this.buttonCopyToClipboard,
            this.buttonRefresh,
            this.buttonClear});
            this.barComparisonButtons.ItemSpacing = 5;
            this.barComparisonButtons.Location = new System.Drawing.Point(1, 1);
            this.barComparisonButtons.MenuBar = true;
            this.barComparisonButtons.Name = "barComparisonButtons";
            this.barComparisonButtons.Size = new System.Drawing.Size(1004, 24);
            this.barComparisonButtons.Stretch = true;
            this.barComparisonButtons.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.barComparisonButtons.TabIndex = 46;
            this.barComparisonButtons.TabStop = false;
            this.barComparisonButtons.Text = "bar1";
            // 
            // labelBaselineWarning
            // 
            this.labelBaselineWarning.Image = ((System.Drawing.Image)(resources.GetObject("labelBaselineWarning.Image")));
            this.labelBaselineWarning.Name = "labelBaselineWarning";
            this.labelBaselineWarning.Text = "No baseline settings found";
            // 
            // buttonAddToComparison
            // 
            this.buttonAddToComparison.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonAddToComparison.Enabled = false;
            this.buttonAddToComparison.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddToComparison.Image")));
            this.buttonAddToComparison.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonAddToComparison.Name = "buttonAddToComparison";
            this.buttonAddToComparison.Text = "Add to Comparison";
            this.buttonAddToComparison.Click += new System.EventHandler(this.buttonAddToComparison_Click);
            // 
            // buttonOpenSnapshot
            // 
            this.buttonOpenSnapshot.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonOpenSnapshot.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpenSnapshot.Image")));
            this.buttonOpenSnapshot.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonOpenSnapshot.Name = "buttonOpenSnapshot";
            this.buttonOpenSnapshot.Text = "Open Snapshot";
            this.buttonOpenSnapshot.Click += new System.EventHandler(this.buttonOpenSnapshot_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonSave.Enabled = false;
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonSaveAll});
            this.buttonSave.Text = "Save Snapshot";
            // 
            // buttonSaveAll
            // 
            this.buttonSaveAll.Name = "buttonSaveAll";
            this.buttonSaveAll.Text = "All Compared Databases";
            this.buttonSaveAll.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonFixDifferences
            // 
            this.buttonFixDifferences.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonFixDifferences.Enabled = false;
            this.buttonFixDifferences.Image = ((System.Drawing.Image)(resources.GetObject("buttonFixDifferences.Image")));
            this.buttonFixDifferences.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonFixDifferences.Name = "buttonFixDifferences";
            this.buttonFixDifferences.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonFixDifferencesWithBaseline,
            this.buttonFixDifferencesWithSnapshot});
            this.buttonFixDifferences.Text = "Fix Differences";
            // 
            // buttonFixDifferencesWithBaseline
            // 
            this.buttonFixDifferencesWithBaseline.Enabled = false;
            this.buttonFixDifferencesWithBaseline.Name = "buttonFixDifferencesWithBaseline";
            this.buttonFixDifferencesWithBaseline.Text = "Use Baseline";
            this.buttonFixDifferencesWithBaseline.Click += new System.EventHandler(this.buttonFixDifferencesWithBaseline_Click);
            // 
            // buttonFixDifferencesWithSnapshot
            // 
            this.buttonFixDifferencesWithSnapshot.Enabled = false;
            this.buttonFixDifferencesWithSnapshot.Name = "buttonFixDifferencesWithSnapshot";
            this.buttonFixDifferencesWithSnapshot.Text = "Use Snapshot";
            // 
            // buttonHighlightDifferences
            // 
            this.buttonHighlightDifferences.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonHighlightDifferences.Enabled = false;
            this.buttonHighlightDifferences.FixedSize = new System.Drawing.Size(110, 20);
            this.buttonHighlightDifferences.Image = ((System.Drawing.Image)(resources.GetObject("buttonHighlightDifferences.Image")));
            this.buttonHighlightDifferences.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonHighlightDifferences.Name = "buttonHighlightDifferences";
            this.buttonHighlightDifferences.Text = "Show Differences";
            this.buttonHighlightDifferences.Click += new System.EventHandler(this.buttonHighlightDifferences_Click);
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonCopyToClipboard.Enabled = false;
            this.buttonCopyToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyToClipboard.Image")));
            this.buttonCopyToClipboard.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Text = "Copy to Clipboard";
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.menuExportToClipboard_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonRefresh.Enabled = false;
            this.buttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.Image")));
            this.buttonRefresh.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonClear.Enabled = false;
            this.buttonClear.Image = ((System.Drawing.Image)(resources.GetObject("buttonClear.Image")));
            this.buttonClear.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Text = "Clear";
            this.buttonClear.Click += new System.EventHandler(this.ClearComparison);
            // 
            // labelNoDatabasesToCompare
            // 
            this.labelNoDatabasesToCompare.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelNoDatabasesToCompare.BackgroundStyle.Class = "";
            this.labelNoDatabasesToCompare.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelNoDatabasesToCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoDatabasesToCompare.Location = new System.Drawing.Point(31, 244);
            this.labelNoDatabasesToCompare.Name = "labelNoDatabasesToCompare";
            this.labelNoDatabasesToCompare.Size = new System.Drawing.Size(929, 23);
            this.labelNoDatabasesToCompare.TabIndex = 44;
            this.labelNoDatabasesToCompare.Text = "No databases selected to compare.  Press \'Add to Comparison\' to choose databases." +
    "";
            this.labelNoDatabasesToCompare.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // listComparison
            // 
            this.listComparison.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.listComparison.Border.Class = "ListViewBorder";
            this.listComparison.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listComparison.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listComparison.ContextMenuStrip = this.contextBulkEditMenuStrip;
            this.listComparison.FullRowSelect = true;
            listViewGroup12.Header = "Database Information (Read-Only)";
            listViewGroup12.Name = "ComparisonDatabaseInfo";
            listViewGroup13.Header = "Auto";
            listViewGroup13.Name = "ComparisonAuto";
            listViewGroup14.Header = "Cursor";
            listViewGroup14.Name = "ComparisonCursor";
            listViewGroup15.Header = "Availability";
            listViewGroup15.Name = "ComparisonAvailability";
            listViewGroup16.Header = "Data Correlation";
            listViewGroup16.Name = "ComparisonCorrelation";
            listViewGroup17.Header = "External Access";
            listViewGroup17.Name = "ComparisonExternalAccess";
            listViewGroup18.Header = "Parameterization";
            listViewGroup18.Name = "ComparisonParameterization";
            listViewGroup19.Header = "Recovery";
            listViewGroup19.Name = "ComparisonRecovery";
            listViewGroup20.Header = "Service Broker";
            listViewGroup20.Name = "ComparisonServiceBroker";
            listViewGroup21.Header = "Isolation";
            listViewGroup21.Name = "ComparisonIsolation";
            listViewGroup22.Header = "SQL";
            listViewGroup22.Name = "ComparisonSql";
            this.listComparison.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup12,
            listViewGroup13,
            listViewGroup14,
            listViewGroup15,
            listViewGroup16,
            listViewGroup17,
            listViewGroup18,
            listViewGroup19,
            listViewGroup20,
            listViewGroup21,
            listViewGroup22});
            this.listComparison.Location = new System.Drawing.Point(6, 31);
            this.listComparison.Name = "listComparison";
            this.listComparison.Size = new System.Drawing.Size(996, 383);
            this.listComparison.SmallImageList = this.imageList1;
            this.listComparison.TabIndex = 12;
            this.listComparison.UseCompatibleStateImageBehavior = false;
            this.listComparison.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Property";
            this.columnHeader1.Width = 200;
            // 
            // contextBulkEditMenuStrip
            // 
            this.contextBulkEditMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuItemApplySingleSettingToServers,
            this.ContextMenuItemBulkUpdateSingleSetting,
            this.toolStripSeparator2,
            this.ContextMenuItemRefresh,
            this.ContextMenuItemClearItems,
            this.ContextMenuItemCopyItems});
            this.contextBulkEditMenuStrip.Name = "contextShowFailedOnly";
            this.contextBulkEditMenuStrip.Size = new System.Drawing.Size(280, 120);
            this.contextBulkEditMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextBulkEditMenuStrip_Opening);
            // 
            // ContextMenuItemApplySingleSettingToServers
            // 
            this.ContextMenuItemApplySingleSettingToServers.Name = "ContextMenuItemApplySingleSettingToServers";
            this.ContextMenuItemApplySingleSettingToServers.Size = new System.Drawing.Size(279, 22);
            this.ContextMenuItemApplySingleSettingToServers.Text = "&Apply Selected Setting to All Databases";
            this.ContextMenuItemApplySingleSettingToServers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ContextMenuItemApplySingleSettingToServers.Click += new System.EventHandler(this.ContextMenuItemApplySingleSettingToServers_Click);
            // 
            // ContextMenuItemBulkUpdateSingleSetting
            // 
            this.ContextMenuItemBulkUpdateSingleSetting.Name = "ContextMenuItemBulkUpdateSingleSetting";
            this.ContextMenuItemBulkUpdateSingleSetting.Size = new System.Drawing.Size(279, 22);
            this.ContextMenuItemBulkUpdateSingleSetting.Text = "Bulk &Update Setting";
            this.ContextMenuItemBulkUpdateSingleSetting.Click += new System.EventHandler(this.ContextMenuItemBulkUpdateSingleSetting_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(276, 6);
            // 
            // ContextMenuItemRefresh
            // 
            this.ContextMenuItemRefresh.Name = "ContextMenuItemRefresh";
            this.ContextMenuItemRefresh.Size = new System.Drawing.Size(279, 22);
            this.ContextMenuItemRefresh.Text = "&Refresh";
            this.ContextMenuItemRefresh.Click += new System.EventHandler(this.ContextMenuItemRefresh_Click);
            // 
            // ContextMenuItemClearItems
            // 
            this.ContextMenuItemClearItems.Name = "ContextMenuItemClearItems";
            this.ContextMenuItemClearItems.Size = new System.Drawing.Size(279, 22);
            this.ContextMenuItemClearItems.Text = "C&lear All";
            this.ContextMenuItemClearItems.Click += new System.EventHandler(this.ClearComparison);
            // 
            // ContextMenuItemCopyItems
            // 
            this.ContextMenuItemCopyItems.Name = "ContextMenuItemCopyItems";
            this.ContextMenuItemCopyItems.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.ContextMenuItemCopyItems.Size = new System.Drawing.Size(279, 22);
            this.ContextMenuItemCopyItems.Text = "&Copy Selected";
            this.ContextMenuItemCopyItems.Click += new System.EventHandler(this.ContextMenuItemCopyItems_Click);
            // 
            // tabComparisonResults
            // 
            this.tabComparisonResults.AttachedControl = this.tabControlPanel5;
            this.tabComparisonResults.Image = ((System.Drawing.Image)(resources.GetObject("tabComparisonResults.Image")));
            this.tabComparisonResults.Name = "tabComparisonResults";
            this.tabComparisonResults.Text = "Comparison";
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
            this.panelTop.Size = new System.Drawing.Size(1030, 52);
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
            this.labelTitle.Size = new System.Drawing.Size(380, 52);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Database Configuration</font></b> ";
            // 
            // labelSubtitle
            // 
            // 
            // 
            // 
            this.labelSubtitle.BackgroundStyle.Class = "";
            this.labelSubtitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.Location = new System.Drawing.Point(450, 0);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(403, 52);
            this.labelSubtitle.TabIndex = 6;
            this.labelSubtitle.Text = "Compare and update the configuration for one or more databases";
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
            this.panelBottom.Location = new System.Drawing.Point(0, 241);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.panelBottom.Size = new System.Drawing.Size(1030, 496);
            this.panelBottom.TabIndex = 17;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.compareToolStripMenuItem,
            this.menuTools,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 93);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1030, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenSnapshot,
            this.menuSaveSnapshot,
            this.toolStripSeparator5,
            this.printToolStripMenuItem,
            this.toolStripSeparator4,
            this.menuExport,
            this.menuExitToLaunchpad,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuOpenSnapshot
            // 
            this.menuOpenSnapshot.Name = "menuOpenSnapshot";
            this.menuOpenSnapshot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuOpenSnapshot.Size = new System.Drawing.Size(198, 22);
            this.menuOpenSnapshot.Text = "&Open Snapshot";
            this.menuOpenSnapshot.Click += new System.EventHandler(this.buttonOpenSnapshot_Click);
            // 
            // menuSaveSnapshot
            // 
            this.menuSaveSnapshot.Enabled = false;
            this.menuSaveSnapshot.Name = "menuSaveSnapshot";
            this.menuSaveSnapshot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuSaveSnapshot.Size = new System.Drawing.Size(198, 22);
            this.menuSaveSnapshot.Text = "&Save Snapshot";
            this.menuSaveSnapshot.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(195, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Enabled = false;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.printToolStripMenuItem.Text = "&Print...";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(195, 6);
            // 
            // menuExport
            // 
            this.menuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExportAsCSV,
            this.menuExportAsXML,
            this.menuExportToClipboard});
            this.menuExport.Enabled = false;
            this.menuExport.Name = "menuExport";
            this.menuExport.Size = new System.Drawing.Size(198, 22);
            this.menuExport.Text = "Save Results As";
            // 
            // menuExportAsCSV
            // 
            this.menuExportAsCSV.Name = "menuExportAsCSV";
            this.menuExportAsCSV.Size = new System.Drawing.Size(140, 22);
            this.menuExportAsCSV.Text = "as &CSV file";
            this.menuExportAsCSV.Click += new System.EventHandler(this.menuExportAsCSV_Click);
            // 
            // menuExportAsXML
            // 
            this.menuExportAsXML.Name = "menuExportAsXML";
            this.menuExportAsXML.Size = new System.Drawing.Size(140, 22);
            this.menuExportAsXML.Text = "as X&ML file";
            this.menuExportAsXML.Click += new System.EventHandler(this.menuExportAsXML_Click);
            // 
            // menuExportToClipboard
            // 
            this.menuExportToClipboard.Name = "menuExportToClipboard";
            this.menuExportToClipboard.Size = new System.Drawing.Size(140, 22);
            this.menuExportToClipboard.Text = "to Clipboard";
            this.menuExportToClipboard.Click += new System.EventHandler(this.menuExportToClipboard_Click);
            // 
            // menuExitToLaunchpad
            // 
            this.menuExitToLaunchpad.Name = "menuExitToLaunchpad";
            this.menuExitToLaunchpad.Size = new System.Drawing.Size(198, 22);
            this.menuExitToLaunchpad.Text = "Exit to &Launchpad";
            this.menuExitToLaunchpad.Click += new System.EventHandler(this.menuExitToLaunchpad_Click);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(198, 22);
            this.menuFileExit.Text = "E&xit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddDatabaseToComparison,
            this.ToolStripMenuItemAddServerToComparison,
            this.ToolStripMenuItemAddAllServersToComparison,
            this.ToolStripMenuItemSetServerAsBaseline,
            this.toolStripSeparator3,
            this.ToolStripMenuItemRefreshComparison,
            this.ToolStripMenuItemClearComparison});
            this.compareToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.compareToolStripMenuItem.Text = "C&ompare";
            // 
            // ToolStripMenuItemAddDatabaseToComparison
            // 
            this.ToolStripMenuItemAddDatabaseToComparison.Enabled = false;
            this.ToolStripMenuItemAddDatabaseToComparison.Name = "ToolStripMenuItemAddDatabaseToComparison";
            this.ToolStripMenuItemAddDatabaseToComparison.Size = new System.Drawing.Size(276, 22);
            this.ToolStripMenuItemAddDatabaseToComparison.Text = "Add &Database To Comparison Report";
            // 
            // ToolStripMenuItemAddServerToComparison
            // 
            this.ToolStripMenuItemAddServerToComparison.Enabled = false;
            this.ToolStripMenuItemAddServerToComparison.Name = "ToolStripMenuItemAddServerToComparison";
            this.ToolStripMenuItemAddServerToComparison.Size = new System.Drawing.Size(276, 22);
            this.ToolStripMenuItemAddServerToComparison.Text = "Add &Server to Comparison Report";
            // 
            // ToolStripMenuItemAddAllServersToComparison
            // 
            this.ToolStripMenuItemAddAllServersToComparison.Enabled = false;
            this.ToolStripMenuItemAddAllServersToComparison.Name = "ToolStripMenuItemAddAllServersToComparison";
            this.ToolStripMenuItemAddAllServersToComparison.Size = new System.Drawing.Size(276, 22);
            this.ToolStripMenuItemAddAllServersToComparison.Text = "Add &All Servers to Comparision Report";
            this.ToolStripMenuItemAddAllServersToComparison.Click += new System.EventHandler(this.contextMenuItemAddAllServersToComparison_Click);
            // 
            // ToolStripMenuItemSetServerAsBaseline
            // 
            this.ToolStripMenuItemSetServerAsBaseline.Enabled = false;
            this.ToolStripMenuItemSetServerAsBaseline.Name = "ToolStripMenuItemSetServerAsBaseline";
            this.ToolStripMenuItemSetServerAsBaseline.Size = new System.Drawing.Size(276, 22);
            this.ToolStripMenuItemSetServerAsBaseline.Text = "Set as &Baseline";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(273, 6);
            // 
            // ToolStripMenuItemRefreshComparison
            // 
            this.ToolStripMenuItemRefreshComparison.Enabled = false;
            this.ToolStripMenuItemRefreshComparison.Name = "ToolStripMenuItemRefreshComparison";
            this.ToolStripMenuItemRefreshComparison.Size = new System.Drawing.Size(276, 22);
            this.ToolStripMenuItemRefreshComparison.Text = "&Refresh Report";
            this.ToolStripMenuItemRefreshComparison.Click += new System.EventHandler(this.ToolStripMenuItemRefreshComparison_Click);
            // 
            // ToolStripMenuItemClearComparison
            // 
            this.ToolStripMenuItemClearComparison.Enabled = false;
            this.ToolStripMenuItemClearComparison.Name = "ToolStripMenuItemClearComparison";
            this.ToolStripMenuItemClearComparison.Size = new System.Drawing.Size(276, 22);
            this.ToolStripMenuItemClearComparison.Text = "&Clear Report";
            this.ToolStripMenuItemClearComparison.Click += new System.EventHandler(this.ClearComparison);
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
            this.menuShowHelp.Size = new System.Drawing.Size(235, 22);
            this.menuShowHelp.Text = "Show &Help";
            this.menuShowHelp.Click += new System.EventHandler(this.menuShowHelp_Click);
            // 
            // menuContactTechnicalSupport
            // 
            this.menuContactTechnicalSupport.Name = "menuContactTechnicalSupport";
            this.menuContactTechnicalSupport.Size = new System.Drawing.Size(235, 22);
            this.menuContactTechnicalSupport.Text = "SQL admin toolset &Support";
            this.menuContactTechnicalSupport.Click += new System.EventHandler(this.menuContactTechnicalSupport_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(232, 6);
            // 
            // menuDeactivateLicense
            // 
            this.menuDeactivateLicense.Name = "menuDeactivateLicense";
            this.menuDeactivateLicense.Size = new System.Drawing.Size(235, 22);
            this.menuDeactivateLicense.Text = "Manage &License";
            this.menuDeactivateLicense.Click += new System.EventHandler(this.menuDeactivateLicense_Click);
            // 
            // menuCheckForUpdates
            // 
            this.menuCheckForUpdates.Name = "menuCheckForUpdates";
            this.menuCheckForUpdates.Size = new System.Drawing.Size(235, 22);
            this.menuCheckForUpdates.Text = "Check For &Updates";
            this.menuCheckForUpdates.Click += new System.EventHandler(this.menuCheckForUpdates_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(232, 6);
            // 
            // menuAboutIderaProducts
            // 
            this.menuAboutIderaProducts.Name = "menuAboutIderaProducts";
            this.menuAboutIderaProducts.Size = new System.Drawing.Size(235, 22);
            this.menuAboutIderaProducts.Text = "About Idera &Products";
            this.menuAboutIderaProducts.Click += new System.EventHandler(this.menuAboutIderaProducts_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(235, 22);
            this.menuAbout.Text = "&About Database Configuration";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // contextComparisonHeader
            // 
            this.contextComparisonHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuItemHeaderSetDatabaseAsBaseline,
            this.ContextMenuItemHeaderRemoveDatabase,
            this.ContextMenuItemHeaderCopyToClipboard,
            this.ContextMenuItemHeaderSaveSnapshot});
            this.contextComparisonHeader.Name = "contextComparisonHeader";
            this.contextComparisonHeader.Size = new System.Drawing.Size(304, 92);
            // 
            // ContextMenuItemHeaderSetDatabaseAsBaseline
            // 
            this.ContextMenuItemHeaderSetDatabaseAsBaseline.Name = "ContextMenuItemHeaderSetDatabaseAsBaseline";
            this.ContextMenuItemHeaderSetDatabaseAsBaseline.Size = new System.Drawing.Size(303, 22);
            this.ContextMenuItemHeaderSetDatabaseAsBaseline.Text = "Set Database as &Baseline";
            this.ContextMenuItemHeaderSetDatabaseAsBaseline.Click += new System.EventHandler(this.ContextMenuItemHeaderSetDatabaseAsBaseline_Click);
            // 
            // ContextMenuItemHeaderRemoveDatabase
            // 
            this.ContextMenuItemHeaderRemoveDatabase.Name = "ContextMenuItemHeaderRemoveDatabase";
            this.ContextMenuItemHeaderRemoveDatabase.Size = new System.Drawing.Size(303, 22);
            this.ContextMenuItemHeaderRemoveDatabase.Text = "&Remove Database from Comparison Report";
            this.ContextMenuItemHeaderRemoveDatabase.Click += new System.EventHandler(this.ContextMenuItemHeaderRemoveDatabase_Click);
            // 
            // ContextMenuItemHeaderCopyToClipboard
            // 
            this.ContextMenuItemHeaderCopyToClipboard.Name = "ContextMenuItemHeaderCopyToClipboard";
            this.ContextMenuItemHeaderCopyToClipboard.Size = new System.Drawing.Size(303, 22);
            this.ContextMenuItemHeaderCopyToClipboard.Text = "&Copy Server to Clipboard";
            this.ContextMenuItemHeaderCopyToClipboard.Click += new System.EventHandler(this.ContextMenuItemHeaderCopyToClipboard_Click);
            // 
            // ContextMenuItemHeaderSaveSnapshot
            // 
            this.ContextMenuItemHeaderSaveSnapshot.Name = "ContextMenuItemHeaderSaveSnapshot";
            this.ContextMenuItemHeaderSaveSnapshot.Size = new System.Drawing.Size(303, 22);
            this.ContextMenuItemHeaderSaveSnapshot.Text = "&Save Database Snapshot";
            this.ContextMenuItemHeaderSaveSnapshot.Click += new System.EventHandler(this.ContextMenuItemHeaderSaveSnapshot_Click);
            // 
            // ideraTitleBar1
            // 
            this.ideraTitleBar1.ActivateLicenseEventHandler = null;
            this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
            this.ideraTitleBar1.Close = true;
            this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/general-product-forum/";
            this.ideraTitleBar1.IderaProductNameText = "SQL Database Configuration";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://trialcenter.idera.com";
            this.ideraTitleBar1.IsFormLocked = false;
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = true;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(1030, 93);
            this.ideraTitleBar1.TabIndex = 19;
            this.ideraTitleBar1.TrialMode = true;
            this.ideraTitleBar1.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar1_LicenseInfoButtonClick);
            // 
            // Form_Main
            // 
            this.AcceptButton = this.buttonGetConfiguration;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1030, 737);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ideraTitleBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1000, 426);
            this.Name = "Form_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Database Configuration";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
            this.panelMiddle.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMainConfiguration)).EndInit();
            this.tabMainConfiguration.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.PanelConfigurationContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageDataError)).EndInit();
            this.contextMenuListOptions.ResumeLayout(false);
            this.contextComparisonReport.ResumeLayout(false);
            this.tabControlPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barComparisonButtons)).EndInit();
            this.contextBulkEditMenuStrip.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextComparisonHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMiddle;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX buttonGetConfiguration;
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
        private System.Windows.Forms.ToolStripMenuItem menuDeactivateLicense;
        private System.Windows.Forms.ToolStripMenuItem menuCheckForUpdates;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem menuManageServerGroups;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private Idera.SqlAdminToolset.Core.Controls.ToolServerSelection ServerSelection;
        private System.Windows.Forms.TreeView treeResults;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuListOptions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowCategories;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditOption;
        private DevComponents.DotNetBar.TabControl tabMainConfiguration;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel5;
        private DevComponents.DotNetBar.Controls.ListViewEx listComparison;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private DevComponents.DotNetBar.TabItem tabComparisonResults;
        private System.Windows.Forms.ContextMenuStrip contextComparisonReport;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuItemAddDatabaseToComparison;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuItemAddServerToComparison;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemAddAllServersToComparison;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemSetAsBaseline;
        private System.Windows.Forms.ContextMenuStrip contextBulkEditMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuItemApplySingleSettingToServers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuItemRefresh;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuItemClearItems;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddDatabaseToComparison;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddAllServersToComparison;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetServerAsBaseline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRefreshComparison;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClearComparison;
        private System.Windows.Forms.ToolStripMenuItem menuExport;
        private System.Windows.Forms.ToolStripMenuItem menuExportAsCSV;
        private System.Windows.Forms.ToolStripMenuItem menuExportAsXML;
        private System.Windows.Forms.ToolStripMenuItem menuExportToClipboard;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddServerToComparison;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkHideSystemDatabases;
        private System.Windows.Forms.ContextMenuStrip contextComparisonHeader;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuItemHeaderSetDatabaseAsBaseline;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuItemHeaderRemoveDatabase;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuItemBulkUpdateSingleSetting;
        private System.Windows.Forms.ToolStripMenuItem menuOpenSnapshot;
        private System.Windows.Forms.ToolStripMenuItem menuSaveSnapshot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private DevComponents.DotNetBar.LabelX labelNoDatabasesToCompare;
        private DevComponents.DotNetBar.Bar barComparisonButtons;
        private DevComponents.DotNetBar.LabelItem labelBaselineWarning;
        private DevComponents.DotNetBar.ButtonItem buttonOpenSnapshot;
        private DevComponents.DotNetBar.ButtonItem buttonSave;
        private DevComponents.DotNetBar.ButtonItem buttonFixDifferences;
        private DevComponents.DotNetBar.ButtonItem buttonHighlightDifferences;
        private DevComponents.DotNetBar.ButtonItem buttonCopyToClipboard;
        private DevComponents.DotNetBar.ButtonItem buttonRefresh;
        private DevComponents.DotNetBar.ButtonItem buttonClear;
        private DevComponents.DotNetBar.ButtonItem buttonAddToComparison;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuItemCopyItems;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuItemHeaderCopyToClipboard;
        private DevComponents.DotNetBar.ButtonItem buttonSaveAll;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuItemHeaderSaveSnapshot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemSaveSnapshot;
        private System.Windows.Forms.Panel PanelConfigurationContainer;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem buttonConfigurationAddToComparison;
        private DevComponents.DotNetBar.ButtonItem buttonConfigurationSaveSnapshot;
        private DevComponents.DotNetBar.ButtonItem buttonSaveAllDatabases;
        private DevComponents.DotNetBar.ButtonItem buttonConfigurationRefresh;
        private DevComponents.DotNetBar.ButtonItem buttonConfigurationSetAsBaseline;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private System.Windows.Forms.PictureBox imageDataError;
        private DevComponents.DotNetBar.LabelX labelDataError;
        private DevComponents.DotNetBar.Controls.ListViewEx listOptions;
        private System.Windows.Forms.ColumnHeader columnOptionName;
        private System.Windows.Forms.ColumnHeader columnOptionValue;
        private DevComponents.DotNetBar.ButtonItem buttonFixDifferencesWithBaseline;
        private DevComponents.DotNetBar.ButtonItem buttonFixDifferencesWithSnapshot;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
        private DevComponents.DotNetBar.TabItem tabConfigurationResults;
    }
}
