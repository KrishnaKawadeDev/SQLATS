namespace Idera.SqlAdminToolset.ServerConfiguration
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Server Information", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Standard Options", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Advanced Options", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Security Options", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Server Information (Read-Only)", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Standard Options", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Advanced Options", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Security Options", System.Windows.Forms.HorizontalAlignment.Left);
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ServerSelection = new Idera.SqlAdminToolset.Core.Controls.ToolServerSelection();
            this.buttonGetConfiguration = new DevComponents.DotNetBar.ButtonX();
            this.groupResults = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.tabMainConfiguration = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.buttonConfigurationOpenSnapshot = new DevComponents.DotNetBar.ButtonItem();
            this.buttonConfigurationSaveSnapshot = new DevComponents.DotNetBar.ButtonItem();
            this.buttonSaveAll = new DevComponents.DotNetBar.ButtonItem();
            this.buttonConfigurationAddToComparison = new DevComponents.DotNetBar.ButtonItem();
            this.buttonAddAllServersToComparison = new DevComponents.DotNetBar.ButtonItem();
            this.buttonConfigurationSetAsBaseline = new DevComponents.DotNetBar.ButtonItem();
            this.buttonConfigurationRemove = new DevComponents.DotNetBar.ButtonItem();
            this.buttonConfigurationClear = new DevComponents.DotNetBar.ButtonItem();
            this.PanelConfigurationContainer = new System.Windows.Forms.Panel();
            this.PanelRightConfiguration = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupDetails = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.linkEdit = new System.Windows.Forms.LinkLabel();
            this.labelDescription = new DevComponents.DotNetBar.LabelX();
            this.labelX22 = new DevComponents.DotNetBar.LabelX();
            this.labelConfigValue = new DevComponents.DotNetBar.LabelX();
            this.labelRunValue = new DevComponents.DotNetBar.LabelX();
            this.labelName = new DevComponents.DotNetBar.LabelX();
            this.labelMaximumValue = new DevComponents.DotNetBar.LabelX();
            this.labelRestartRequired = new DevComponents.DotNetBar.LabelX();
            this.labelMinimumValue = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.listResults = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRunValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnConfigValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRestartNeeded = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.listServers = new DevComponents.DotNetBar.ItemPanel();
            this.contextComparisonReport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuItemAddServerToComparison = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuItemAddAllServersToComparison = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuItemRemoveServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuItemSetAsBaseline = new System.Windows.Forms.ToolStripMenuItem();
            this.tabConfigurationResults = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel5 = new DevComponents.DotNetBar.TabControlPanel();
            this.barComparisonButtons = new DevComponents.DotNetBar.Bar();
            this.labelBaselineWarning = new DevComponents.DotNetBar.LabelItem();
            this.buttonOpenSnapshot = new DevComponents.DotNetBar.ButtonItem();
            this.buttonSave = new DevComponents.DotNetBar.ButtonItem();
            this.buttonSaveAllCompared = new DevComponents.DotNetBar.ButtonItem();
            this.buttonFixDifferences = new DevComponents.DotNetBar.ButtonItem();
            this.buttonFixDifferencesBaseline = new DevComponents.DotNetBar.ButtonItem();
            this.buttonFixDifferencesSnapshot = new DevComponents.DotNetBar.ButtonItem();
            this.buttonHighlightDifferences = new DevComponents.DotNetBar.ButtonItem();
            this.buttonCopyToClipboard = new DevComponents.DotNetBar.ButtonItem();
            this.buttonRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.buttonClear = new DevComponents.DotNetBar.ButtonItem();
            this.listComparison = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextBulkEditMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuItemApplySingleSettingToServers = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuItemBulkUpdateSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuItemClearItems = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuItemCopyItems = new System.Windows.Forms.ToolStripMenuItem();
            this.tabComparisonResults = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabItem4 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsXML = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAddServerToComparison = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAddAllServersToComparison = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemRemoveServerFromComparison = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.listViewEx1 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX21 = new DevComponents.DotNetBar.LabelX();
            this.labelX20 = new DevComponents.DotNetBar.LabelX();
            this.labelX19 = new DevComponents.DotNetBar.LabelX();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.contextComparisonHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuItemHeaderSetServerAsBaseline = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuItemHeaderRemoveServer = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuItemHeaderCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuItemHeaderSaveServerSnapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.panelMiddle.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMainConfiguration)).BeginInit();
            this.tabMainConfiguration.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.PanelConfigurationContainer.SuspendLayout();
            this.PanelRightConfiguration.SuspendLayout();
            this.groupDetails.SuspendLayout();
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
            this.panelMiddle.Size = new System.Drawing.Size(938, 72);
            this.panelMiddle.TabIndex = 0;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.ServerSelection);
            this.groupPanel1.Controls.Add(this.buttonGetConfiguration);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.IsShadowEnabled = true;
            this.groupPanel1.Location = new System.Drawing.Point(6, 6);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(926, 60);
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
            this.groupPanel1.TabIndex = 1;
            // 
            // ServerSelection
            // 
            this.ServerSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerSelection.BackColor = System.Drawing.Color.Transparent;
            this.ServerSelection.Caption = "";
            this.ServerSelection.CredentialsVisible = true;
            this.ServerSelection.Location = new System.Drawing.Point(29, 9);
            this.ServerSelection.MinimumSize = new System.Drawing.Size(0, 40);
            this.ServerSelection.Name = "ServerSelection";
            this.ServerSelection.SelectionOptions = Idera.SqlAdminToolset.Core.Controls.ServerSelectionOptions.ServersAndGroups;
            this.ServerSelection.Size = new System.Drawing.Size(663, 40);
            this.ServerSelection.TabIndex = 2;
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
            this.buttonGetConfiguration.Location = new System.Drawing.Point(698, 5);
            this.buttonGetConfiguration.Name = "buttonGetConfiguration";
            this.buttonGetConfiguration.Size = new System.Drawing.Size(219, 44);
            this.buttonGetConfiguration.TabIndex = 3;
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
            this.groupResults.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupResults.Size = new System.Drawing.Size(926, 483);
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
            this.groupResults.TabIndex = 4;
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
            this.tabMainConfiguration.Location = new System.Drawing.Point(0, 3);
            this.tabMainConfiguration.Name = "tabMainConfiguration";
            this.tabMainConfiguration.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabMainConfiguration.SelectedTabIndex = 0;
            this.tabMainConfiguration.Size = new System.Drawing.Size(917, 464);
            this.tabMainConfiguration.TabIndex = 5;
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
            this.tabControlPanel2.Size = new System.Drawing.Size(917, 422);
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
            this.buttonConfigurationOpenSnapshot,
            this.buttonConfigurationSaveSnapshot,
            this.buttonConfigurationAddToComparison,
            this.buttonConfigurationSetAsBaseline,
            this.buttonConfigurationRemove,
            this.buttonConfigurationClear});
            this.bar1.ItemSpacing = 5;
            this.bar1.Location = new System.Drawing.Point(1, 1);
            this.bar1.MenuBar = true;
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(915, 24);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.bar1.TabIndex = 44;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // buttonConfigurationOpenSnapshot
            // 
            this.buttonConfigurationOpenSnapshot.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonConfigurationOpenSnapshot.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfigurationOpenSnapshot.Image")));
            this.buttonConfigurationOpenSnapshot.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonConfigurationOpenSnapshot.Name = "buttonConfigurationOpenSnapshot";
            this.buttonConfigurationOpenSnapshot.Text = "Open Snapshot";
            this.buttonConfigurationOpenSnapshot.Click += new System.EventHandler(this.buttonOpenSnapshot_Click);
            // 
            // buttonConfigurationSaveSnapshot
            // 
            this.buttonConfigurationSaveSnapshot.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonConfigurationSaveSnapshot.Enabled = false;
            this.buttonConfigurationSaveSnapshot.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfigurationSaveSnapshot.Image")));
            this.buttonConfigurationSaveSnapshot.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonConfigurationSaveSnapshot.Name = "buttonConfigurationSaveSnapshot";
            this.buttonConfigurationSaveSnapshot.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonSaveAll});
            this.buttonConfigurationSaveSnapshot.Text = "Save Snapshot";
            // 
            // buttonSaveAll
            // 
            this.buttonSaveAll.Name = "buttonSaveAll";
            this.buttonSaveAll.Text = "All Servers";
            this.buttonSaveAll.Click += new System.EventHandler(this.buttonSaveAll_Click);
            // 
            // buttonConfigurationAddToComparison
            // 
            this.buttonConfigurationAddToComparison.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonConfigurationAddToComparison.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfigurationAddToComparison.Image")));
            this.buttonConfigurationAddToComparison.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonConfigurationAddToComparison.Name = "buttonConfigurationAddToComparison";
            this.buttonConfigurationAddToComparison.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonAddAllServersToComparison});
            this.buttonConfigurationAddToComparison.Text = "Add to Comparison";
            // 
            // buttonAddAllServersToComparison
            // 
            this.buttonAddAllServersToComparison.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonAddAllServersToComparison.Name = "buttonAddAllServersToComparison";
            this.buttonAddAllServersToComparison.Text = "All Servers";
            this.buttonAddAllServersToComparison.Click += new System.EventHandler(this.contextMenuItemAddAllServersToComparison_Click);
            // 
            // buttonConfigurationSetAsBaseline
            // 
            this.buttonConfigurationSetAsBaseline.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonConfigurationSetAsBaseline.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfigurationSetAsBaseline.Image")));
            this.buttonConfigurationSetAsBaseline.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonConfigurationSetAsBaseline.Name = "buttonConfigurationSetAsBaseline";
            this.buttonConfigurationSetAsBaseline.Text = "Set as Baseline";
            // 
            // buttonConfigurationRemove
            // 
            this.buttonConfigurationRemove.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonConfigurationRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfigurationRemove.Image")));
            this.buttonConfigurationRemove.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonConfigurationRemove.Name = "buttonConfigurationRemove";
            this.buttonConfigurationRemove.Text = "Remove Server";
            // 
            // buttonConfigurationClear
            // 
            this.buttonConfigurationClear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonConfigurationClear.Enabled = false;
            this.buttonConfigurationClear.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfigurationClear.Image")));
            this.buttonConfigurationClear.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonConfigurationClear.Name = "buttonConfigurationClear";
            this.buttonConfigurationClear.Text = "Clear";
            this.buttonConfigurationClear.Click += new System.EventHandler(this.buttonConfigurationClear_Click);
            // 
            // PanelConfigurationContainer
            // 
            this.PanelConfigurationContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelConfigurationContainer.BackColor = System.Drawing.Color.Transparent;
            this.PanelConfigurationContainer.Controls.Add(this.PanelRightConfiguration);
            this.PanelConfigurationContainer.Controls.Add(this.expandableSplitter1);
            this.PanelConfigurationContainer.Controls.Add(this.listServers);
            this.PanelConfigurationContainer.Location = new System.Drawing.Point(1, 27);
            this.PanelConfigurationContainer.Name = "PanelConfigurationContainer";
            this.PanelConfigurationContainer.Size = new System.Drawing.Size(912, 395);
            this.PanelConfigurationContainer.TabIndex = 45;
            // 
            // PanelRightConfiguration
            // 
            this.PanelRightConfiguration.CanvasColor = System.Drawing.Color.Transparent;
            this.PanelRightConfiguration.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.PanelRightConfiguration.Controls.Add(this.groupDetails);
            this.PanelRightConfiguration.Controls.Add(this.listResults);
            this.PanelRightConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelRightConfiguration.Location = new System.Drawing.Point(163, 0);
            this.PanelRightConfiguration.Name = "PanelRightConfiguration";
            this.PanelRightConfiguration.Size = new System.Drawing.Size(749, 395);
            // 
            // 
            // 
            this.PanelRightConfiguration.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.PanelRightConfiguration.Style.BackColorGradientAngle = 90;
            this.PanelRightConfiguration.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PanelRightConfiguration.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRightConfiguration.Style.BorderBottomWidth = 1;
            this.PanelRightConfiguration.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PanelRightConfiguration.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRightConfiguration.Style.BorderLeftWidth = 1;
            this.PanelRightConfiguration.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRightConfiguration.Style.BorderRightWidth = 1;
            this.PanelRightConfiguration.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.PanelRightConfiguration.Style.BorderTopWidth = 1;
            this.PanelRightConfiguration.Style.Class = "";
            this.PanelRightConfiguration.Style.CornerDiameter = 4;
            this.PanelRightConfiguration.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.PanelRightConfiguration.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.PanelRightConfiguration.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PanelRightConfiguration.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.PanelRightConfiguration.StyleMouseDown.Class = "";
            this.PanelRightConfiguration.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.PanelRightConfiguration.StyleMouseOver.Class = "";
            this.PanelRightConfiguration.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PanelRightConfiguration.TabIndex = 16;
            // 
            // groupDetails
            // 
            this.groupDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupDetails.AutoScroll = true;
            this.groupDetails.BackColor = System.Drawing.Color.Transparent;
            this.groupDetails.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupDetails.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupDetails.Controls.Add(this.linkEdit);
            this.groupDetails.Controls.Add(this.labelDescription);
            this.groupDetails.Controls.Add(this.labelX22);
            this.groupDetails.Controls.Add(this.labelConfigValue);
            this.groupDetails.Controls.Add(this.labelRunValue);
            this.groupDetails.Controls.Add(this.labelName);
            this.groupDetails.Controls.Add(this.labelMaximumValue);
            this.groupDetails.Controls.Add(this.labelRestartRequired);
            this.groupDetails.Controls.Add(this.labelMinimumValue);
            this.groupDetails.Controls.Add(this.labelX4);
            this.groupDetails.Controls.Add(this.labelX5);
            this.groupDetails.Controls.Add(this.labelX6);
            this.groupDetails.Controls.Add(this.labelX3);
            this.groupDetails.Controls.Add(this.labelX2);
            this.groupDetails.Controls.Add(this.labelX1);
            this.groupDetails.IsShadowEnabled = true;
            this.groupDetails.Location = new System.Drawing.Point(0, 257);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(743, 129);
            // 
            // 
            // 
            this.groupDetails.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupDetails.Style.BackColorGradientAngle = 90;
            this.groupDetails.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupDetails.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupDetails.Style.BorderBottomWidth = 1;
            this.groupDetails.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupDetails.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupDetails.Style.BorderLeftWidth = 1;
            this.groupDetails.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupDetails.Style.BorderRightWidth = 1;
            this.groupDetails.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupDetails.Style.BorderTopWidth = 1;
            this.groupDetails.Style.Class = "";
            this.groupDetails.Style.CornerDiameter = 4;
            this.groupDetails.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupDetails.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupDetails.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupDetails.StyleMouseDown.Class = "";
            this.groupDetails.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupDetails.StyleMouseOver.Class = "";
            this.groupDetails.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupDetails.TabIndex = 13;
            this.groupDetails.Text = "Details";
            // 
            // linkEdit
            // 
            this.linkEdit.AutoSize = true;
            this.linkEdit.BackColor = System.Drawing.Color.Transparent;
            this.linkEdit.Location = new System.Drawing.Point(222, 31);
            this.linkEdit.Name = "linkEdit";
            this.linkEdit.Size = new System.Drawing.Size(25, 13);
            this.linkEdit.TabIndex = 16;
            this.linkEdit.TabStop = true;
            this.linkEdit.Text = "Edit";
            this.linkEdit.Visible = false;
            this.linkEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEdit_LinkClicked);
            // 
            // labelDescription
            // 
            this.labelDescription.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelDescription.BackgroundStyle.Class = "";
            this.labelDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(89, 78);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(229, 27);
            this.labelDescription.TabIndex = 13;
            this.labelDescription.Text = "Description";
            this.labelDescription.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.labelDescription.WordWrap = true;
            // 
            // labelX22
            // 
            this.labelX22.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX22.BackgroundStyle.Class = "";
            this.labelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX22.Location = new System.Drawing.Point(14, 72);
            this.labelX22.Name = "labelX22";
            this.labelX22.Size = new System.Drawing.Size(69, 23);
            this.labelX22.TabIndex = 12;
            this.labelX22.Text = "Description:";
            // 
            // labelConfigValue
            // 
            this.labelConfigValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelConfigValue.BackgroundStyle.Class = "";
            this.labelConfigValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelConfigValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfigValue.Location = new System.Drawing.Point(89, 26);
            this.labelConfigValue.Name = "labelConfigValue";
            this.labelConfigValue.Size = new System.Drawing.Size(136, 23);
            this.labelConfigValue.TabIndex = 11;
            this.labelConfigValue.Text = "Config";
            // 
            // labelRunValue
            // 
            this.labelRunValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelRunValue.BackgroundStyle.Class = "";
            this.labelRunValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelRunValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRunValue.Location = new System.Drawing.Point(89, 49);
            this.labelRunValue.Name = "labelRunValue";
            this.labelRunValue.Size = new System.Drawing.Size(229, 23);
            this.labelRunValue.TabIndex = 10;
            this.labelRunValue.Text = "Run Value";
            // 
            // labelName
            // 
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelName.BackgroundStyle.Class = "";
            this.labelName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(89, 3);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(197, 23);
            this.labelName.TabIndex = 9;
            this.labelName.Text = "Name";
            // 
            // labelMaximumValue
            // 
            this.labelMaximumValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelMaximumValue.BackgroundStyle.Class = "";
            this.labelMaximumValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelMaximumValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaximumValue.Location = new System.Drawing.Point(428, 26);
            this.labelMaximumValue.Name = "labelMaximumValue";
            this.labelMaximumValue.Size = new System.Drawing.Size(94, 23);
            this.labelMaximumValue.TabIndex = 8;
            this.labelMaximumValue.Text = "Maximum";
            // 
            // labelRestartRequired
            // 
            this.labelRestartRequired.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelRestartRequired.BackgroundStyle.Class = "";
            this.labelRestartRequired.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelRestartRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRestartRequired.Location = new System.Drawing.Point(428, 49);
            this.labelRestartRequired.Name = "labelRestartRequired";
            this.labelRestartRequired.Size = new System.Drawing.Size(94, 23);
            this.labelRestartRequired.TabIndex = 7;
            this.labelRestartRequired.Text = "Restart Needed";
            // 
            // labelMinimumValue
            // 
            this.labelMinimumValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelMinimumValue.BackgroundStyle.Class = "";
            this.labelMinimumValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelMinimumValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinimumValue.Location = new System.Drawing.Point(428, 3);
            this.labelMinimumValue.Name = "labelMinimumValue";
            this.labelMinimumValue.Size = new System.Drawing.Size(94, 23);
            this.labelMinimumValue.TabIndex = 6;
            this.labelMinimumValue.Text = "Minimum";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(338, 26);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(91, 23);
            this.labelX4.TabIndex = 5;
            this.labelX4.Text = "Maximum:";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(338, 49);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(91, 23);
            this.labelX5.TabIndex = 4;
            this.labelX5.Text = "Restart Needed:";
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.Location = new System.Drawing.Point(338, 3);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(91, 23);
            this.labelX6.TabIndex = 3;
            this.labelX6.Text = "Minimum:";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(14, 26);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(76, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "Config Value:";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(14, 49);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(69, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Run Value:";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(14, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(69, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Name:";
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
            this.columnName,
            this.columnRunValue,
            this.columnConfigValue,
            this.columnRestartNeeded,
            this.columnDescription});
            this.listResults.FullRowSelect = true;
            listViewGroup1.Header = "Server Information";
            listViewGroup1.Name = "groupServerInformation";
            listViewGroup2.Header = "Standard Options";
            listViewGroup2.Name = "groupStandard";
            listViewGroup3.Header = "Advanced Options";
            listViewGroup3.Name = "groupAdvanced";
            listViewGroup4.Header = "Security Options";
            listViewGroup4.Name = "groupSecurity";
            this.listResults.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            this.listResults.Location = new System.Drawing.Point(-2, -1);
            this.listResults.MultiSelect = false;
            this.listResults.Name = "listResults";
            this.listResults.Size = new System.Drawing.Size(742, 263);
            this.listResults.SmallImageList = this.imageList1;
            this.listResults.TabIndex = 12;
            this.listResults.UseCompatibleStateImageBehavior = false;
            this.listResults.View = System.Windows.Forms.View.Details;
            this.listResults.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listResults_ItemSelectionChanged);
            this.listResults.DoubleClick += new System.EventHandler(this.listResults_DoubleClick);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 175;
            // 
            // columnRunValue
            // 
            this.columnRunValue.Text = "Run Value";
            this.columnRunValue.Width = 67;
            // 
            // columnConfigValue
            // 
            this.columnConfigValue.Text = "Config Value";
            this.columnConfigValue.Width = 77;
            // 
            // columnRestartNeeded
            // 
            this.columnRestartNeeded.Text = "Restart Needed";
            this.columnRestartNeeded.Width = 92;
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "Description";
            this.columnDescription.Width = 306;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "warning.ico");
            this.imageList1.Images.SetKeyName(1, "server_certificate.ico");
            this.imageList1.Images.SetKeyName(2, "server_connection.ico");
            this.imageList1.Images.SetKeyName(3, "server_ok.ico");
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandableControl = this.listServers;
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
            this.expandableSplitter1.Location = new System.Drawing.Point(158, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(5, 395);
            this.expandableSplitter1.TabIndex = 15;
            this.expandableSplitter1.TabStop = false;
            // 
            // listServers
            // 
            this.listServers.AutoScroll = true;
            // 
            // 
            // 
            this.listServers.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.listServers.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.listServers.BackgroundStyle.BorderBottomWidth = 1;
            this.listServers.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.listServers.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.listServers.BackgroundStyle.BorderLeftWidth = 1;
            this.listServers.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.listServers.BackgroundStyle.BorderRightWidth = 1;
            this.listServers.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.listServers.BackgroundStyle.BorderTopWidth = 1;
            this.listServers.BackgroundStyle.Class = "";
            this.listServers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listServers.BackgroundStyle.PaddingBottom = 1;
            this.listServers.BackgroundStyle.PaddingLeft = 1;
            this.listServers.BackgroundStyle.PaddingRight = 1;
            this.listServers.BackgroundStyle.PaddingTop = 1;
            this.listServers.ContainerControlProcessDialogKey = true;
            this.listServers.ContextMenuStrip = this.contextComparisonReport;
            this.listServers.Dock = System.Windows.Forms.DockStyle.Left;
            this.listServers.Images = this.imageList1;
            this.listServers.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.listServers.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.listServers.Location = new System.Drawing.Point(0, 0);
            this.listServers.Name = "listServers";
            this.listServers.Size = new System.Drawing.Size(158, 395);
            this.listServers.TabIndex = 14;
            this.listServers.Text = "itemPanel1";
            this.listServers.ItemClick += new System.EventHandler(this.listServers_ItemClick);
            // 
            // contextComparisonReport
            // 
            this.contextComparisonReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuItemAddServerToComparison,
            this.contextMenuItemAddAllServersToComparison,
            this.contextMenuItemRemoveServer,
            this.toolStripSeparator1,
            this.contextMenuItemSetAsBaseline});
            this.contextComparisonReport.Name = "contextShowFailedOnly";
            this.contextComparisonReport.Size = new System.Drawing.Size(274, 98);
            this.contextComparisonReport.Text = "&Show found passwords only";
            this.contextComparisonReport.Opening += new System.ComponentModel.CancelEventHandler(this.contextComparisonReport_Opening);
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
            // contextMenuItemRemoveServer
            // 
            this.contextMenuItemRemoveServer.Name = "contextMenuItemRemoveServer";
            this.contextMenuItemRemoveServer.Size = new System.Drawing.Size(273, 22);
            this.contextMenuItemRemoveServer.Text = "&Remove Server";
            this.contextMenuItemRemoveServer.Click += new System.EventHandler(this.contextMenuItemRemoveServer_Click);
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
            this.contextMenuItemSetAsBaseline.Text = "Set Selected Server as &Baseline";
            this.contextMenuItemSetAsBaseline.Click += new System.EventHandler(this.contextMenuItemSetAsBaseline_Click);
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
            this.tabControlPanel5.Controls.Add(this.listComparison);
            this.tabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel5.Location = new System.Drawing.Point(0, 42);
            this.tabControlPanel5.Name = "tabControlPanel5";
            this.tabControlPanel5.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel5.Size = new System.Drawing.Size(917, 422);
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
            this.barComparisonButtons.Size = new System.Drawing.Size(915, 24);
            this.barComparisonButtons.Stretch = true;
            this.barComparisonButtons.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.barComparisonButtons.TabIndex = 42;
            this.barComparisonButtons.TabStop = false;
            this.barComparisonButtons.Text = "bar1";
            // 
            // labelBaselineWarning
            // 
            this.labelBaselineWarning.Image = ((System.Drawing.Image)(resources.GetObject("labelBaselineWarning.Image")));
            this.labelBaselineWarning.Name = "labelBaselineWarning";
            this.labelBaselineWarning.Text = "No baseline settings found";
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
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonSaveAllCompared});
            this.buttonSave.Text = "Save Snapshot";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonSaveAllCompared
            // 
            this.buttonSaveAllCompared.Name = "buttonSaveAllCompared";
            this.buttonSaveAllCompared.Text = "All Compared Servers";
            this.buttonSaveAllCompared.Click += new System.EventHandler(this.buttonSaveAllCompared_Click);
            // 
            // buttonFixDifferences
            // 
            this.buttonFixDifferences.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonFixDifferences.Image = ((System.Drawing.Image)(resources.GetObject("buttonFixDifferences.Image")));
            this.buttonFixDifferences.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonFixDifferences.Name = "buttonFixDifferences";
            this.buttonFixDifferences.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonFixDifferencesBaseline,
            this.buttonFixDifferencesSnapshot});
            this.buttonFixDifferences.Text = "Fix Differences";
            // 
            // buttonFixDifferencesBaseline
            // 
            this.buttonFixDifferencesBaseline.Enabled = false;
            this.buttonFixDifferencesBaseline.Name = "buttonFixDifferencesBaseline";
            this.buttonFixDifferencesBaseline.Text = "Use Baseline";
            this.buttonFixDifferencesBaseline.Click += new System.EventHandler(this.buttonFixBaselineDifferences_Click);
            // 
            // buttonFixDifferencesSnapshot
            // 
            this.buttonFixDifferencesSnapshot.Enabled = false;
            this.buttonFixDifferencesSnapshot.Name = "buttonFixDifferencesSnapshot";
            this.buttonFixDifferencesSnapshot.Text = "Use Snapshot";
            // 
            // buttonHighlightDifferences
            // 
            this.buttonHighlightDifferences.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
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
            this.buttonCopyToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyToClipboard.Image")));
            this.buttonCopyToClipboard.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Text = "Copy to Clipboard";
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.Image")));
            this.buttonRefresh.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonClear.Image = ((System.Drawing.Image)(resources.GetObject("buttonClear.Image")));
            this.buttonClear.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Text = "Clear";
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
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
            listViewGroup5.Header = "Server Information (Read-Only)";
            listViewGroup5.Name = "ComparisonReportGroup";
            listViewGroup6.Header = "Standard Options";
            listViewGroup6.Name = "ComparisonStandardGroup";
            listViewGroup7.Header = "Advanced Options";
            listViewGroup7.Name = "ComparisonAdvancedGroup";
            listViewGroup8.Header = "Security Options";
            listViewGroup8.Name = "ComparisonSecurityGroup";
            this.listComparison.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup5,
            listViewGroup6,
            listViewGroup7,
            listViewGroup8});
            this.listComparison.Location = new System.Drawing.Point(4, 31);
            this.listComparison.Name = "listComparison";
            this.listComparison.Size = new System.Drawing.Size(909, 387);
            this.listComparison.SmallImageList = this.imageList1;
            this.listComparison.Sorting = System.Windows.Forms.SortOrder.Ascending;
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
            this.ContextMenuItemBulkUpdateSetting,
            this.toolStripSeparator2,
            this.ContextMenuItemRefresh,
            this.ContextMenuItemClearItems,
            this.ContextMenuItemCopyItems});
            this.contextBulkEditMenuStrip.Name = "contextShowFailedOnly";
            this.contextBulkEditMenuStrip.Size = new System.Drawing.Size(264, 120);
            this.contextBulkEditMenuStrip.Text = "&Show found passwords only";
            this.contextBulkEditMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextBulkEditMenuStrip_Opening);
            // 
            // ContextMenuItemApplySingleSettingToServers
            // 
            this.ContextMenuItemApplySingleSettingToServers.Name = "ContextMenuItemApplySingleSettingToServers";
            this.ContextMenuItemApplySingleSettingToServers.Size = new System.Drawing.Size(263, 22);
            this.ContextMenuItemApplySingleSettingToServers.Text = "&Apply Selected Setting to All Servers";
            this.ContextMenuItemApplySingleSettingToServers.Click += new System.EventHandler(this.ContextMenuItemApplySingleSettingToServers_Click);
            // 
            // ContextMenuItemBulkUpdateSetting
            // 
            this.ContextMenuItemBulkUpdateSetting.Name = "ContextMenuItemBulkUpdateSetting";
            this.ContextMenuItemBulkUpdateSetting.Size = new System.Drawing.Size(263, 22);
            this.ContextMenuItemBulkUpdateSetting.Text = "&Bulk update";
            this.ContextMenuItemBulkUpdateSetting.Click += new System.EventHandler(this.ContextMenuItemBulkUpdateSetting_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(260, 6);
            // 
            // ContextMenuItemRefresh
            // 
            this.ContextMenuItemRefresh.Name = "ContextMenuItemRefresh";
            this.ContextMenuItemRefresh.Size = new System.Drawing.Size(263, 22);
            this.ContextMenuItemRefresh.Text = "&Refresh";
            this.ContextMenuItemRefresh.Click += new System.EventHandler(this.ContextMenuItemRefresh_Click);
            // 
            // ContextMenuItemClearItems
            // 
            this.ContextMenuItemClearItems.Name = "ContextMenuItemClearItems";
            this.ContextMenuItemClearItems.Size = new System.Drawing.Size(263, 22);
            this.ContextMenuItemClearItems.Text = "C&lear All";
            this.ContextMenuItemClearItems.Click += new System.EventHandler(this.ContextMenuItemClearItems_Click);
            // 
            // ContextMenuItemCopyItems
            // 
            this.ContextMenuItemCopyItems.Name = "ContextMenuItemCopyItems";
            this.ContextMenuItemCopyItems.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.ContextMenuItemCopyItems.Size = new System.Drawing.Size(263, 22);
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
            // tabItem4
            // 
            this.tabItem4.Name = "tabItem4";
            this.tabItem4.Text = "tabItem4";
            // 
            // tabItem1
            // 
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "tabItem1";
            // 
            // tabItem2
            // 
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "tabItem2";
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
            this.panelTop.Size = new System.Drawing.Size(938, 52);
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
            this.labelTitle.Size = new System.Drawing.Size(350, 52);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.TabStop = false;
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Server Configuration</font></b> ";
            // 
            // labelSubtitle
            // 
            // 
            // 
            // 
            this.labelSubtitle.BackgroundStyle.Class = "";
            this.labelSubtitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.Location = new System.Drawing.Point(410, 0);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(452, 52);
            this.labelSubtitle.TabIndex = 6;
            this.labelSubtitle.Text = "Compare and update the server configuration for one or more SQL Servers";
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
            this.panelBottom.Size = new System.Drawing.Size(938, 492);
            this.panelBottom.TabIndex = 17;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.editToolStripMenuItem,
            this.compareToolStripMenuItem,
            this.menuTools,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 93);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(938, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExport,
            this.toolStripSeparator4,
            this.printToolStripMenuItem,
            this.toolStripSeparator5,
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
            this.menuExport.Text = "&Save Results As";
            // 
            // menuExportAsCSV
            // 
            this.menuExportAsCSV.Name = "menuExportAsCSV";
            this.menuExportAsCSV.Size = new System.Drawing.Size(267, 22);
            this.menuExportAsCSV.Text = "&CSV File (comma separated values)...";
            this.menuExportAsCSV.Click += new System.EventHandler(this.menuExportAsCSV_Click);
            // 
            // menuExportAsXML
            // 
            this.menuExportAsXML.Name = "menuExportAsXML";
            this.menuExportAsXML.Size = new System.Drawing.Size(267, 22);
            this.menuExportAsXML.Text = "X&ML File...";
            this.menuExportAsXML.Click += new System.EventHandler(this.menuExportAsXML_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(165, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Enabled = false;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.printToolStripMenuItem.Text = "&Print...";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(165, 6);
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
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopy});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // menuCopy
            // 
            this.menuCopy.Enabled = false;
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Size = new System.Drawing.Size(102, 22);
            this.menuCopy.Text = "&Copy";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddServerToComparison,
            this.ToolStripMenuItemAddAllServersToComparison,
            this.ToolStripMenuItemRemoveServerFromComparison,
            this.ToolStripMenuItemSetServerAsBaseline,
            this.toolStripSeparator3,
            this.ToolStripMenuItemRefreshComparison,
            this.ToolStripMenuItemClearComparison});
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.compareToolStripMenuItem.Text = "C&ompare";
            // 
            // ToolStripMenuItemAddServerToComparison
            // 
            this.ToolStripMenuItemAddServerToComparison.Enabled = false;
            this.ToolStripMenuItemAddServerToComparison.Name = "ToolStripMenuItemAddServerToComparison";
            this.ToolStripMenuItemAddServerToComparison.Size = new System.Drawing.Size(289, 22);
            this.ToolStripMenuItemAddServerToComparison.Text = "A&dd Server To Comparison Report";
            // 
            // ToolStripMenuItemAddAllServersToComparison
            // 
            this.ToolStripMenuItemAddAllServersToComparison.Enabled = false;
            this.ToolStripMenuItemAddAllServersToComparison.Name = "ToolStripMenuItemAddAllServersToComparison";
            this.ToolStripMenuItemAddAllServersToComparison.Size = new System.Drawing.Size(289, 22);
            this.ToolStripMenuItemAddAllServersToComparison.Text = "Add &All Servers to Comparision Report";
            this.ToolStripMenuItemAddAllServersToComparison.Click += new System.EventHandler(this.contextMenuItemAddAllServersToComparison_Click);
            // 
            // ToolStripMenuItemRemoveServerFromComparison
            // 
            this.ToolStripMenuItemRemoveServerFromComparison.Enabled = false;
            this.ToolStripMenuItemRemoveServerFromComparison.Name = "ToolStripMenuItemRemoveServerFromComparison";
            this.ToolStripMenuItemRemoveServerFromComparison.Size = new System.Drawing.Size(289, 22);
            this.ToolStripMenuItemRemoveServerFromComparison.Text = "&Remove Server From Comparison Report";
            // 
            // ToolStripMenuItemSetServerAsBaseline
            // 
            this.ToolStripMenuItemSetServerAsBaseline.Enabled = false;
            this.ToolStripMenuItemSetServerAsBaseline.Name = "ToolStripMenuItemSetServerAsBaseline";
            this.ToolStripMenuItemSetServerAsBaseline.Size = new System.Drawing.Size(289, 22);
            this.ToolStripMenuItemSetServerAsBaseline.Text = "Set Server As &Baseline";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(286, 6);
            // 
            // ToolStripMenuItemRefreshComparison
            // 
            this.ToolStripMenuItemRefreshComparison.Enabled = false;
            this.ToolStripMenuItemRefreshComparison.Name = "ToolStripMenuItemRefreshComparison";
            this.ToolStripMenuItemRefreshComparison.Size = new System.Drawing.Size(289, 22);
            this.ToolStripMenuItemRefreshComparison.Text = "&Refresh Report";
            this.ToolStripMenuItemRefreshComparison.Click += new System.EventHandler(this.ToolStripMenuItemRefreshComparison_Click);
            // 
            // ToolStripMenuItemClearComparison
            // 
            this.ToolStripMenuItemClearComparison.Enabled = false;
            this.ToolStripMenuItemClearComparison.Name = "ToolStripMenuItemClearComparison";
            this.ToolStripMenuItemClearComparison.Size = new System.Drawing.Size(289, 22);
            this.ToolStripMenuItemClearComparison.Text = "&Clear Report";
            this.ToolStripMenuItemClearComparison.Click += new System.EventHandler(this.ToolStripMenuItemClearComparison_Click);
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
            this.menuAbout.Text = "&About BackupStatus";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 0);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.TabIndex = 0;
            // 
            // listViewEx1
            // 
            // 
            // 
            // 
            this.listViewEx1.Border.Class = "ListViewBorder";
            this.listViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx1.Location = new System.Drawing.Point(0, 0);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(121, 97);
            this.listViewEx1.TabIndex = 0;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            // 
            // groupPanel2
            // 
            this.groupPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.Color.Transparent;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.IsShadowEnabled = true;
            this.groupPanel2.Location = new System.Drawing.Point(14, 386);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(652, 132);
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
            this.groupPanel2.TabIndex = 13;
            this.groupPanel2.Text = "Details";
            // 
            // labelX21
            // 
            // 
            // 
            // 
            this.labelX21.BackgroundStyle.Class = "";
            this.labelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX21.Location = new System.Drawing.Point(0, 0);
            this.labelX21.Name = "labelX21";
            this.labelX21.TabIndex = 0;
            // 
            // labelX20
            // 
            // 
            // 
            // 
            this.labelX20.BackgroundStyle.Class = "";
            this.labelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX20.Location = new System.Drawing.Point(0, 0);
            this.labelX20.Name = "labelX20";
            this.labelX20.TabIndex = 0;
            // 
            // labelX19
            // 
            // 
            // 
            // 
            this.labelX19.BackgroundStyle.Class = "";
            this.labelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX19.Location = new System.Drawing.Point(0, 0);
            this.labelX19.Name = "labelX19";
            this.labelX19.TabIndex = 0;
            // 
            // labelX18
            // 
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.Class = "";
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.Location = new System.Drawing.Point(0, 0);
            this.labelX18.Name = "labelX18";
            this.labelX18.TabIndex = 0;
            // 
            // labelX17
            // 
            // 
            // 
            // 
            this.labelX17.BackgroundStyle.Class = "";
            this.labelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX17.Location = new System.Drawing.Point(0, 0);
            this.labelX17.Name = "labelX17";
            this.labelX17.TabIndex = 0;
            // 
            // labelX16
            // 
            // 
            // 
            // 
            this.labelX16.BackgroundStyle.Class = "";
            this.labelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX16.Location = new System.Drawing.Point(0, 0);
            this.labelX16.Name = "labelX16";
            this.labelX16.TabIndex = 0;
            // 
            // labelX15
            // 
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.Class = "";
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Location = new System.Drawing.Point(0, 0);
            this.labelX15.Name = "labelX15";
            this.labelX15.TabIndex = 0;
            // 
            // labelX14
            // 
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.Class = "";
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(0, 0);
            this.labelX14.Name = "labelX14";
            this.labelX14.TabIndex = 0;
            // 
            // labelX13
            // 
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.Class = "";
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(0, 0);
            this.labelX13.Name = "labelX13";
            this.labelX13.TabIndex = 0;
            // 
            // labelX12
            // 
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.Class = "";
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(0, 0);
            this.labelX12.Name = "labelX12";
            this.labelX12.TabIndex = 0;
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.Class = "";
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(0, 0);
            this.labelX11.Name = "labelX11";
            this.labelX11.TabIndex = 0;
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.Class = "";
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(0, 0);
            this.labelX10.Name = "labelX10";
            this.labelX10.TabIndex = 0;
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(0, 0);
            this.labelX9.Name = "labelX9";
            this.labelX9.TabIndex = 0;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(0, 0);
            this.labelX8.Name = "labelX8";
            this.labelX8.TabIndex = 0;
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 0);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.TabIndex = 0;
            // 
            // tabItem3
            // 
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "";
            // 
            // contextComparisonHeader
            // 
            this.contextComparisonHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuItemHeaderSetServerAsBaseline,
            this.ContextMenuItemHeaderRemoveServer,
            this.ContextMenuItemHeaderCopyToClipboard,
            this.ContextMenuItemHeaderSaveServerSnapshot});
            this.contextComparisonHeader.Name = "contextComparisonHeader";
            this.contextComparisonHeader.Size = new System.Drawing.Size(288, 92);
            // 
            // ContextMenuItemHeaderSetServerAsBaseline
            // 
            this.ContextMenuItemHeaderSetServerAsBaseline.Name = "ContextMenuItemHeaderSetServerAsBaseline";
            this.ContextMenuItemHeaderSetServerAsBaseline.Size = new System.Drawing.Size(287, 22);
            this.ContextMenuItemHeaderSetServerAsBaseline.Text = "Set Server as &Baseline";
            this.ContextMenuItemHeaderSetServerAsBaseline.Click += new System.EventHandler(this.ContextMenuItemHeaderSetServerAsBaseline_Click);
            // 
            // ContextMenuItemHeaderRemoveServer
            // 
            this.ContextMenuItemHeaderRemoveServer.Name = "ContextMenuItemHeaderRemoveServer";
            this.ContextMenuItemHeaderRemoveServer.Size = new System.Drawing.Size(287, 22);
            this.ContextMenuItemHeaderRemoveServer.Text = "&Remove Server from Comparison Report";
            this.ContextMenuItemHeaderRemoveServer.Click += new System.EventHandler(this.ContextMenuItemHeaderRemoveServer_Click);
            // 
            // ContextMenuItemHeaderCopyToClipboard
            // 
            this.ContextMenuItemHeaderCopyToClipboard.Name = "ContextMenuItemHeaderCopyToClipboard";
            this.ContextMenuItemHeaderCopyToClipboard.Size = new System.Drawing.Size(287, 22);
            this.ContextMenuItemHeaderCopyToClipboard.Text = "&Copy Server to Clipboard";
            this.ContextMenuItemHeaderCopyToClipboard.Click += new System.EventHandler(this.ContextMenuItemHeaderCopyToClipboard_Click);
            // 
            // ContextMenuItemHeaderSaveServerSnapshot
            // 
            this.ContextMenuItemHeaderSaveServerSnapshot.Name = "ContextMenuItemHeaderSaveServerSnapshot";
            this.ContextMenuItemHeaderSaveServerSnapshot.Size = new System.Drawing.Size(287, 22);
            this.ContextMenuItemHeaderSaveServerSnapshot.Text = "&Save Server Snapshot";
            this.ContextMenuItemHeaderSaveServerSnapshot.Click += new System.EventHandler(this.ContextMenuItemHeaderSaveServerSnapshot_Click);
            // 
            // buttonItem2
            // 
            this.buttonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem2.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem2.Image")));
            this.buttonItem2.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "Open Snapshot";
            // 
            // buttonItem3
            // 
            this.buttonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem3.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem3.Image")));
            this.buttonItem3.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "Open Snapshot";
            // 
            // ideraTitleBar1
            // 
            this.ideraTitleBar1.ActivateLicenseEventHandler = null;
            this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
            this.ideraTitleBar1.Close = true;
            this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
            this.ideraTitleBar1.IderaProductNameText = "SQL Server Configuration";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.IsFormLocked = false;
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = true;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(938, 93);
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
            this.ClientSize = new System.Drawing.Size(938, 733);
            this.ControlBox = false;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ideraTitleBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(763, 426);
            this.Name = "Form_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
            this.panelMiddle.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMainConfiguration)).EndInit();
            this.tabMainConfiguration.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.PanelConfigurationContainer.ResumeLayout(false);
            this.PanelRightConfiguration.ResumeLayout(false);
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
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
      private DevComponents.DotNetBar.TabItem tabItem1;
      private Idera.SqlAdminToolset.Core.Controls.ToolServerSelection ServerSelection;
      private DevComponents.DotNetBar.TabItem tabItem2;
      private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
      private DevComponents.DotNetBar.Controls.ListViewEx listViewEx1;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
      private DevComponents.DotNetBar.LabelX labelX21;
      private DevComponents.DotNetBar.LabelX labelX20;
      private DevComponents.DotNetBar.LabelX labelX19;
      private DevComponents.DotNetBar.LabelX labelX18;
      private DevComponents.DotNetBar.LabelX labelX17;
      private DevComponents.DotNetBar.LabelX labelX16;
      private DevComponents.DotNetBar.LabelX labelX15;
      private DevComponents.DotNetBar.LabelX labelX14;
      private DevComponents.DotNetBar.LabelX labelX13;
      private DevComponents.DotNetBar.LabelX labelX12;
      private DevComponents.DotNetBar.LabelX labelX11;
      private DevComponents.DotNetBar.LabelX labelX10;
      private DevComponents.DotNetBar.LabelX labelX9;
      private DevComponents.DotNetBar.LabelX labelX8;
      private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
      private DevComponents.DotNetBar.TabItem tabItem3;
      private DevComponents.DotNetBar.Controls.ListViewEx listResults;
      private System.Windows.Forms.ColumnHeader columnName;
      private System.Windows.Forms.ColumnHeader columnRunValue;
      private System.Windows.Forms.ColumnHeader columnConfigValue;
      private System.Windows.Forms.ColumnHeader columnDescription;
      private DevComponents.DotNetBar.TabItem tabItem4;
      private DevComponents.DotNetBar.Controls.GroupPanel groupDetails;
      private DevComponents.DotNetBar.LabelX labelX3;
      private DevComponents.DotNetBar.LabelX labelX2;
      private DevComponents.DotNetBar.LabelX labelX1;
      private DevComponents.DotNetBar.LabelX labelDescription;
      private DevComponents.DotNetBar.LabelX labelX22;
      private DevComponents.DotNetBar.LabelX labelConfigValue;
      private DevComponents.DotNetBar.LabelX labelRunValue;
      private DevComponents.DotNetBar.LabelX labelName;
      private DevComponents.DotNetBar.LabelX labelMaximumValue;
      private DevComponents.DotNetBar.LabelX labelRestartRequired;
      private DevComponents.DotNetBar.LabelX labelMinimumValue;
      private DevComponents.DotNetBar.LabelX labelX4;
      private DevComponents.DotNetBar.LabelX labelX5;
      private DevComponents.DotNetBar.LabelX labelX6;
      private System.Windows.Forms.ImageList imageList1;
      private DevComponents.DotNetBar.TabControl tabMainConfiguration;
      private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
      private DevComponents.DotNetBar.TabControlPanel tabControlPanel5;
      private DevComponents.DotNetBar.TabItem tabComparisonResults;
      private DevComponents.DotNetBar.Controls.ListViewEx listComparison;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ContextMenuStrip contextComparisonReport;
      private System.Windows.Forms.ToolStripMenuItem ContextMenuItemAddServerToComparison;
      private System.Windows.Forms.ToolStripMenuItem contextMenuItemAddAllServersToComparison;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem contextMenuItemSetAsBaseline;
      private System.Windows.Forms.LinkLabel linkEdit;
      private System.Windows.Forms.ContextMenuStrip contextBulkEditMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem ContextMenuItemApplySingleSettingToServers;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem ContextMenuItemRefresh;
      private System.Windows.Forms.ToolStripMenuItem ContextMenuItemClearItems;
      private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddServerToComparison;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddAllServersToComparison;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetServerAsBaseline;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRefreshComparison;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClearComparison;
      private System.Windows.Forms.ToolStripMenuItem menuExport;
      private System.Windows.Forms.ToolStripMenuItem menuExportAsCSV;
      private System.Windows.Forms.ToolStripMenuItem menuExportAsXML;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private DevComponents.DotNetBar.ItemPanel listServers;
      private System.Windows.Forms.ToolStripMenuItem contextMenuItemRemoveServer;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRemoveServerFromComparison;
      private System.Windows.Forms.ContextMenuStrip contextComparisonHeader;
      private System.Windows.Forms.ToolStripMenuItem ContextMenuItemHeaderSetServerAsBaseline;
      private System.Windows.Forms.ToolStripMenuItem ContextMenuItemHeaderRemoveServer;
      private System.Windows.Forms.ToolStripMenuItem ContextMenuItemBulkUpdateSetting;
      private System.Windows.Forms.ColumnHeader columnRestartNeeded;
      private System.Windows.Forms.ToolStripMenuItem ContextMenuItemCopyItems;
      private System.Windows.Forms.ToolStripMenuItem ContextMenuItemHeaderCopyToClipboard;
      private DevComponents.DotNetBar.Bar barComparisonButtons;
      private DevComponents.DotNetBar.ButtonItem buttonSave;
      private DevComponents.DotNetBar.ButtonItem buttonFixDifferences;
      private DevComponents.DotNetBar.ButtonItem buttonHighlightDifferences;
      private DevComponents.DotNetBar.ButtonItem buttonRefresh;
      private DevComponents.DotNetBar.ButtonItem buttonCopyToClipboard;
      private DevComponents.DotNetBar.ButtonItem buttonClear;
      private DevComponents.DotNetBar.LabelItem labelBaselineWarning;
      private DevComponents.DotNetBar.ButtonItem buttonOpenSnapshot;
      private DevComponents.DotNetBar.Bar bar1;
      private DevComponents.DotNetBar.ButtonItem buttonConfigurationOpenSnapshot;
      private DevComponents.DotNetBar.ButtonItem buttonConfigurationSaveSnapshot;
      private DevComponents.DotNetBar.ButtonItem buttonConfigurationClear;
      private System.Windows.Forms.Panel PanelConfigurationContainer;
      private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
      private DevComponents.DotNetBar.Controls.GroupPanel PanelRightConfiguration;
      private System.Windows.Forms.ToolStripMenuItem ContextMenuItemHeaderSaveServerSnapshot;
      private DevComponents.DotNetBar.ButtonItem buttonSaveAll;
      private DevComponents.DotNetBar.ButtonItem buttonSaveAllCompared;
      private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem menuCopy;
       private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
       private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
      private DevComponents.DotNetBar.ButtonItem buttonConfigurationAddToComparison;
      private DevComponents.DotNetBar.ButtonItem buttonConfigurationRemove;
      private DevComponents.DotNetBar.ButtonItem buttonConfigurationSetAsBaseline;
      private DevComponents.DotNetBar.ButtonItem buttonItem2;
      private DevComponents.DotNetBar.ButtonItem buttonItem3;
      private DevComponents.DotNetBar.ButtonItem buttonAddAllServersToComparison;
       private DevComponents.DotNetBar.ButtonItem buttonFixDifferencesBaseline;
       private DevComponents.DotNetBar.ButtonItem buttonFixDifferencesSnapshot;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
        private DevComponents.DotNetBar.TabItem tabConfigurationResults;
    }
}

