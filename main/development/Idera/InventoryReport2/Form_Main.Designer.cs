using System.Windows.Forms;

namespace Idera.SqlAdminToolset.InventoryReport
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Report", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("SQL Server Configuration", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("SQL Server Network Libraries", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Computer Configuration", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("SQL Server 6.5", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("SQL Server 7.0", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("SQL Server 2000", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("SQL Server 2005", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("SQL Server 2008", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("SQL Server 2012", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("SQL Server 2014", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("SQL Server 2016", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup13 = new System.Windows.Forms.ListViewGroup("SQL Server 2017", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup14 = new System.Windows.Forms.ListViewGroup("Unknown Version", System.Windows.Forms.HorizontalAlignment.Left);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenSnapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveSnapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsXML = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAsServerGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.menuClearLiveData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClearSnapshots = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowServersAsRows = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHighlightDifferences = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManageServerGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsetOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
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
            this.buttonLoadInventoryData = new DevComponents.DotNetBar.ButtonX();
            this.panelButtonBar = new System.Windows.Forms.Panel();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.buttonOpenSnapshot = new DevComponents.DotNetBar.ButtonItem();
            this.buttonSave = new DevComponents.DotNetBar.ButtonItem();
            this.buttonHighlightDifferences = new DevComponents.DotNetBar.ButtonItem();
            this.buttonCopy = new DevComponents.DotNetBar.ButtonItem();
            this.buttonClear = new DevComponents.DotNetBar.ButtonItem();
            this.comboReportType = new System.Windows.Forms.ComboBox();
            this.labelSelectReportType = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.linkWmiErrorDetails = new System.Windows.Forms.LinkLabel();
            this.groupInventory = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.listInventory = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuRemoveServer = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuShowServersAsRows = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuHighlightDifferences = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuSaveSnapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExportXML = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExportTable = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSaveAsServerGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.labelWmiErrors = new DevComponents.DotNetBar.LabelX();
            this.superTooltip1 = new DevComponents.DotNetBar.SuperTooltip();
            this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.menuStrip1.SuspendLayout();
            this.toolProductBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.panelTop.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.panelButtonBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.groupInventory.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuEdit,
            this.viewToolStripMenuItem,
            this.menuTools,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 93);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(853, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenSnapshot,
            this.menuSaveSnapshot,
            this.toolStripMenuItem8,
            this.menuExport,
            this.menuSaveAsServerGroup,
            this.toolStripMenuItem7,
            this.printToolStripMenuItem,
            this.toolStripMenuItem9,
            this.menuExitToLaunchpad,
            this.menuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // menuOpenSnapshot
            // 
            this.menuOpenSnapshot.Name = "menuOpenSnapshot";
            this.menuOpenSnapshot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuOpenSnapshot.Size = new System.Drawing.Size(198, 22);
            this.menuOpenSnapshot.Text = "&Open Snapshot";
            this.menuOpenSnapshot.Click += new System.EventHandler(this.openSnapshot_Click);
            // 
            // menuSaveSnapshot
            // 
            this.menuSaveSnapshot.Enabled = false;
            this.menuSaveSnapshot.Name = "menuSaveSnapshot";
            this.menuSaveSnapshot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuSaveSnapshot.Size = new System.Drawing.Size(198, 22);
            this.menuSaveSnapshot.Text = "&Save Snapshot";
            this.menuSaveSnapshot.Click += new System.EventHandler(this.saveSnapshot_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(195, 6);
            // 
            // menuExport
            // 
            this.menuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExportAsCSV,
            this.menuExportAsXML,
            this.menuExportAsTable});
            this.menuExport.Enabled = false;
            this.menuExport.Name = "menuExport";
            this.menuExport.Size = new System.Drawing.Size(198, 22);
            this.menuExport.Text = "Save &Results As";
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
            // menuExportAsTable
            // 
            this.menuExportAsTable.Name = "menuExportAsTable";
            this.menuExportAsTable.Size = new System.Drawing.Size(265, 22);
            this.menuExportAsTable.Text = "Data &Table...";
            this.menuExportAsTable.Click += new System.EventHandler(this.menuExportAsTable_Click);
            // 
            // menuSaveAsServerGroup
            // 
            this.menuSaveAsServerGroup.Enabled = false;
            this.menuSaveAsServerGroup.Name = "menuSaveAsServerGroup";
            this.menuSaveAsServerGroup.Size = new System.Drawing.Size(198, 22);
            this.menuSaveAsServerGroup.Text = "Save as Server &Group";
            this.menuSaveAsServerGroup.Click += new System.EventHandler(this.menuSaveAsServerGroup_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(195, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(195, 6);
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
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopy,
            this.menuSelectAll,
            this.toolStripMenuItem11,
            this.menuClearLiveData,
            this.menuClearSnapshots,
            this.menuClear});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(39, 20);
            this.menuEdit.Text = "&Edit";
            // 
            // menuCopy
            // 
            this.menuCopy.Enabled = false;
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Size = new System.Drawing.Size(158, 22);
            this.menuCopy.Text = "&Copy";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuSelectAll
            // 
            this.menuSelectAll.Enabled = false;
            this.menuSelectAll.Name = "menuSelectAll";
            this.menuSelectAll.Size = new System.Drawing.Size(158, 22);
            this.menuSelectAll.Text = "Select &All";
            this.menuSelectAll.Click += new System.EventHandler(this.menuSelectAll_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(155, 6);
            // 
            // menuClearLiveData
            // 
            this.menuClearLiveData.Name = "menuClearLiveData";
            this.menuClearLiveData.Size = new System.Drawing.Size(158, 22);
            this.menuClearLiveData.Text = "Clear &Live Data";
            this.menuClearLiveData.Click += new System.EventHandler(this.menuClearLiveData_Click);
            // 
            // menuClearSnapshots
            // 
            this.menuClearSnapshots.Name = "menuClearSnapshots";
            this.menuClearSnapshots.Size = new System.Drawing.Size(158, 22);
            this.menuClearSnapshots.Text = "Clear &Snapshots";
            this.menuClearSnapshots.Click += new System.EventHandler(this.menuClearSnapshots_Click);
            // 
            // menuClear
            // 
            this.menuClear.Name = "menuClear";
            this.menuClear.Size = new System.Drawing.Size(158, 22);
            this.menuClear.Text = "C&lear All";
            this.menuClear.Click += new System.EventHandler(this.menuClear_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowServersAsRows,
            this.menuHighlightDifferences,
            this.toolStripMenuItem6,
            this.refreshToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // menuShowServersAsRows
            // 
            this.menuShowServersAsRows.Name = "menuShowServersAsRows";
            this.menuShowServersAsRows.Size = new System.Drawing.Size(188, 22);
            this.menuShowServersAsRows.Text = "&Show Servers as Rows";
            this.menuShowServersAsRows.Click += new System.EventHandler(this.menuShowServersAsRows_Click);
            // 
            // menuHighlightDifferences
            // 
            this.menuHighlightDifferences.Name = "menuHighlightDifferences";
            this.menuHighlightDifferences.Size = new System.Drawing.Size(188, 22);
            this.menuHighlightDifferences.Text = "&Highlight Differences";
            this.menuHighlightDifferences.Click += new System.EventHandler(this.menuHighlightDifferences_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(185, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManageServerGroups,
            this.menuToolsetOptions,
            this.toolStripMenuItem12,
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
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(230, 6);
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
            this.menuAbout.Text = "&About Inventory Reporter";
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
            this.toolProductBanner.Size = new System.Drawing.Size(853, 52);
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
            this.labelSubtitle.Location = new System.Drawing.Point(390, 0);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(460, 52);
            this.labelSubtitle.TabIndex = 6;
            this.labelSubtitle.Text = "List and report on important computer and SQL Server configuration information";
            // 
            // labelTitle
            // 
            // 
            // 
            // 
            this.labelTitle.BackgroundStyle.Class = "";
            this.labelTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTitle.Location = new System.Drawing.Point(57, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(330, 52);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to   Inventory Reporter</font></b> ";
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
            this.panelTop.Size = new System.Drawing.Size(853, 58);
            this.panelTop.TabIndex = 12;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.ServerSelection);
            this.groupPanel1.Controls.Add(this.buttonLoadInventoryData);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.IsShadowEnabled = true;
            this.groupPanel1.Location = new System.Drawing.Point(6, 3);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(841, 52);
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
            // 
            // ServerSelection
            // 
            this.ServerSelection.BackColor = System.Drawing.Color.Transparent;
            this.ServerSelection.Caption = "";
            this.ServerSelection.CredentialsVisible = true;
            this.ServerSelection.Location = new System.Drawing.Point(2, 3);
            this.ServerSelection.MinimumSize = new System.Drawing.Size(0, 40);
            this.ServerSelection.Name = "ServerSelection";
            this.ServerSelection.SelectionOptions = Idera.SqlAdminToolset.Core.Controls.ServerSelectionOptions.ServersAndGroups;
            this.ServerSelection.Size = new System.Drawing.Size(480, 40);
            this.ServerSelection.TabIndex = 7;
            this.ServerSelection.TextChangedEventHandler = null;
            this.ServerSelection.TextChanged += new System.EventHandler(this.ServerSelection_TextChanged);
            // 
            // buttonLoadInventoryData
            // 
            this.buttonLoadInventoryData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonLoadInventoryData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonLoadInventoryData.Enabled = false;
            this.buttonLoadInventoryData.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoadInventoryData.Image")));
            this.buttonLoadInventoryData.Location = new System.Drawing.Point(503, 3);
            this.buttonLoadInventoryData.Name = "buttonLoadInventoryData";
            this.buttonLoadInventoryData.Size = new System.Drawing.Size(153, 40);
            this.buttonLoadInventoryData.TabIndex = 0;
            this.buttonLoadInventoryData.Text = "&Load Inventory Data";
            this.buttonLoadInventoryData.Click += new System.EventHandler(this.buttonCaptureData_Click);
            // 
            // panelButtonBar
            // 
            this.panelButtonBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtonBar.Controls.Add(this.bar1);
            this.panelButtonBar.Location = new System.Drawing.Point(388, -1);
            this.panelButtonBar.Name = "panelButtonBar";
            this.panelButtonBar.Size = new System.Drawing.Size(442, 36);
            this.panelButtonBar.TabIndex = 36;
            // 
            // bar1
            // 
            this.bar1.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.CenterRight;
            this.bar1.CanReorderTabs = false;
            this.bar1.DockedBorderStyle = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonOpenSnapshot,
            this.buttonSave,
            this.buttonHighlightDifferences,
            this.buttonCopy,
            this.buttonClear});
            this.bar1.ItemSpacing = 1;
            this.bar1.Location = new System.Drawing.Point(4, 3);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(438, 31);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.bar1.TabIndex = 35;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // buttonOpenSnapshot
            // 
            this.buttonOpenSnapshot.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonOpenSnapshot.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpenSnapshot.Image")));
            this.buttonOpenSnapshot.Name = "buttonOpenSnapshot";
            this.buttonOpenSnapshot.Text = "&Open Snapshot";
            this.buttonOpenSnapshot.Click += new System.EventHandler(this.openSnapshot_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Text = "&Save Snapshot";
            this.buttonSave.Click += new System.EventHandler(this.saveSnapshot_Click);
            // 
            // buttonHighlightDifferences
            // 
            this.buttonHighlightDifferences.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonHighlightDifferences.FixedSize = new System.Drawing.Size(110, 20);
            this.buttonHighlightDifferences.Image = ((System.Drawing.Image)(resources.GetObject("buttonHighlightDifferences.Image")));
            this.buttonHighlightDifferences.Name = "buttonHighlightDifferences";
            this.buttonHighlightDifferences.Text = "&Show Differences";
            this.buttonHighlightDifferences.Click += new System.EventHandler(this.buttonHighlightDifferences_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonCopy.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopy.Image")));
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Text = "&Copy";
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonClear.Image = ((System.Drawing.Image)(resources.GetObject("buttonClear.Image")));
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Text = "&Clear";
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // comboReportType
            // 
            this.comboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboReportType.FormattingEnabled = true;
            this.comboReportType.Items.AddRange(new object[] {
            "Comprehensive Inventory Report",
            "SQL Server Properties Report",
            "SQL Server Version Report",
            "Computer Properties Report"});
            this.comboReportType.Location = new System.Drawing.Point(81, 9);
            this.comboReportType.Name = "comboReportType";
            this.comboReportType.Size = new System.Drawing.Size(243, 21);
            this.comboReportType.TabIndex = 33;
            this.comboReportType.SelectedValueChanged += new System.EventHandler(this.comboReportType_SelectedValueChanged);
            // 
            // labelSelectReportType
            // 
            this.labelSelectReportType.AutoSize = true;
            this.labelSelectReportType.Location = new System.Drawing.Point(0, 13);
            this.labelSelectReportType.Name = "labelSelectReportType";
            this.labelSelectReportType.Size = new System.Drawing.Size(75, 13);
            this.labelSelectReportType.TabIndex = 32;
            this.labelSelectReportType.Text = "Select Report:";
            // 
            // panelBottom
            // 
            this.panelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBottom.Controls.Add(this.linkWmiErrorDetails);
            this.panelBottom.Controls.Add(this.groupInventory);
            this.panelBottom.Controls.Add(this.labelWmiErrors);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 227);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.panelBottom.Size = new System.Drawing.Size(853, 473);
            this.panelBottom.TabIndex = 13;
            // 
            // linkWmiErrorDetails
            // 
            this.linkWmiErrorDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkWmiErrorDetails.AutoSize = true;
            this.linkWmiErrorDetails.Location = new System.Drawing.Point(741, 452);
            this.linkWmiErrorDetails.Name = "linkWmiErrorDetails";
            this.linkWmiErrorDetails.Size = new System.Drawing.Size(102, 13);
            this.linkWmiErrorDetails.TabIndex = 13;
            this.linkWmiErrorDetails.TabStop = true;
            this.linkWmiErrorDetails.Text = "Click here for details";
            this.linkWmiErrorDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkWmiErrorDetails_LinkClicked);
            // 
            // groupInventory
            // 
            this.groupInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupInventory.BackColor = System.Drawing.Color.Transparent;
            this.groupInventory.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupInventory.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupInventory.Controls.Add(this.panelButtonBar);
            this.groupInventory.Controls.Add(this.comboReportType);
            this.groupInventory.Controls.Add(this.listInventory);
            this.groupInventory.Controls.Add(this.labelSelectReportType);
            this.groupInventory.IsShadowEnabled = true;
            this.groupInventory.Location = new System.Drawing.Point(8, 4);
            this.groupInventory.Name = "groupInventory";
            this.groupInventory.Size = new System.Drawing.Size(839, 441);
            // 
            // 
            // 
            this.groupInventory.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupInventory.Style.BackColorGradientAngle = 90;
            this.groupInventory.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupInventory.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupInventory.Style.BorderBottomWidth = 1;
            this.groupInventory.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupInventory.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupInventory.Style.BorderLeftWidth = 1;
            this.groupInventory.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupInventory.Style.BorderRightWidth = 1;
            this.groupInventory.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupInventory.Style.BorderTopWidth = 1;
            this.groupInventory.Style.Class = "";
            this.groupInventory.Style.CornerDiameter = 4;
            this.groupInventory.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupInventory.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupInventory.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupInventory.StyleMouseDown.Class = "";
            this.groupInventory.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupInventory.StyleMouseOver.Class = "";
            this.groupInventory.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupInventory.TabIndex = 24;
            this.groupInventory.Text = "Server Inventory";
            // 
            // listInventory
            // 
            this.listInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.listInventory.Border.Class = "ListViewBorder";
            this.listInventory.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listInventory.ContextMenuStrip = this.contextMenu;
            this.listInventory.FullRowSelect = true;
            listViewGroup1.Header = "Report";
            listViewGroup1.Name = "groupReport";
            listViewGroup2.Header = "SQL Server Configuration";
            listViewGroup2.Name = "groupSQL";
            listViewGroup3.Header = "SQL Server Network Libraries";
            listViewGroup3.Name = "groupNetworkLibraries";
            listViewGroup4.Header = "Computer Configuration";
            listViewGroup4.Name = "groupComputer";
            listViewGroup5.Header = "SQL Server 6.5";
            listViewGroup5.Name = "group65";
            listViewGroup6.Header = "SQL Server 7.0";
            listViewGroup6.Name = "group70";
            listViewGroup7.Header = "SQL Server 2000";
            listViewGroup7.Name = "group2000";
            listViewGroup8.Header = "SQL Server 2005";
            listViewGroup8.Name = "group2005";
            listViewGroup9.Header = "SQL Server 2008";
            listViewGroup9.Name = "group 2008";
            listViewGroup10.Header = "SQL Server 2012";
            listViewGroup10.Name = "group 2012";
            listViewGroup11.Header = "SQL Server 2014";
            listViewGroup11.Name = "group 2014";
            listViewGroup12.Header = "SQL Server 2016";
            listViewGroup12.Name = "group 2016";
            listViewGroup13.Header = "SQL Server 2017";
            listViewGroup13.Name = "group 2017";
            listViewGroup14.Header = "Unknown Version";
            listViewGroup14.Name = "groupUnknown";
            this.listInventory.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
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
            listViewGroup11,
            listViewGroup12,
            listViewGroup13,
            listViewGroup14 });
            this.listInventory.Location = new System.Drawing.Point(2, 42);
            this.listInventory.Name = "listInventory";
            this.listInventory.Size = new System.Drawing.Size(828, 375);
            this.listInventory.TabIndex = 11;
            this.listInventory.UseCompatibleStateImageBehavior = false;
            this.listInventory.View = System.Windows.Forms.View.Details;
            this.listInventory.SelectedIndexChanged += new System.EventHandler(this.listInventory_SelectedIndexChanged);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuRemoveServer,
            this.contextMenuShowServersAsRows,
            this.contextMenuHighlightDifferences,
            this.toolStripMenuItem5,
            this.contextMenuCopy,
            this.contextMenuSelectAll,
            this.toolStripMenuItem4,
            this.contextMenuSaveSnapshot,
            this.contextMenuExport,
            this.contextMenuSaveAsServerGroup,
            this.toolStripMenuItem10,
            this.contextMenuClear});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(189, 220);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.regularListViewMenu_Opening);
            // 
            // contextMenuRemoveServer
            // 
            this.contextMenuRemoveServer.Enabled = false;
            this.contextMenuRemoveServer.Name = "contextMenuRemoveServer";
            this.contextMenuRemoveServer.Size = new System.Drawing.Size(188, 22);
            this.contextMenuRemoveServer.Text = "Remove Server \'xxx\'";
            this.contextMenuRemoveServer.Click += new System.EventHandler(this.contextMenuRemoveServer_Click);
            // 
            // contextMenuShowServersAsRows
            // 
            this.contextMenuShowServersAsRows.Name = "contextMenuShowServersAsRows";
            this.contextMenuShowServersAsRows.Size = new System.Drawing.Size(188, 22);
            this.contextMenuShowServersAsRows.Text = "&Show Servers as Rows";
            this.contextMenuShowServersAsRows.Click += new System.EventHandler(this.contextMenuShowServersAsRows_Click);
            // 
            // contextMenuHighlightDifferences
            // 
            this.contextMenuHighlightDifferences.Name = "contextMenuHighlightDifferences";
            this.contextMenuHighlightDifferences.Size = new System.Drawing.Size(188, 22);
            this.contextMenuHighlightDifferences.Text = "&Highlight Differences";
            this.contextMenuHighlightDifferences.Click += new System.EventHandler(this.highlightDifferencesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(185, 6);
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.Enabled = false;
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.contextMenuCopy.Size = new System.Drawing.Size(188, 22);
            this.contextMenuCopy.Text = "Co&py";
            this.contextMenuCopy.Click += new System.EventHandler(this.contextMenuCopy_Click);
            // 
            // contextMenuSelectAll
            // 
            this.contextMenuSelectAll.Enabled = false;
            this.contextMenuSelectAll.Name = "contextMenuSelectAll";
            this.contextMenuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.contextMenuSelectAll.Size = new System.Drawing.Size(188, 22);
            this.contextMenuSelectAll.Text = "Select &All";
            this.contextMenuSelectAll.Click += new System.EventHandler(this.contextMenuSelectAll_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(185, 6);
            // 
            // contextMenuSaveSnapshot
            // 
            this.contextMenuSaveSnapshot.Enabled = false;
            this.contextMenuSaveSnapshot.Name = "contextMenuSaveSnapshot";
            this.contextMenuSaveSnapshot.Size = new System.Drawing.Size(188, 22);
            this.contextMenuSaveSnapshot.Text = "Save S&naphot";
            this.contextMenuSaveSnapshot.Click += new System.EventHandler(this.contextMenuSaveSnapshot_Click);
            // 
            // contextMenuExport
            // 
            this.contextMenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuExportCSV,
            this.contextMenuExportXML,
            this.contextMenuExportTable});
            this.contextMenuExport.Enabled = false;
            this.contextMenuExport.Name = "contextMenuExport";
            this.contextMenuExport.Size = new System.Drawing.Size(188, 22);
            this.contextMenuExport.Text = "Save &Results As";
            // 
            // contextMenuExportCSV
            // 
            this.contextMenuExportCSV.Name = "contextMenuExportCSV";
            this.contextMenuExportCSV.Size = new System.Drawing.Size(258, 22);
            this.contextMenuExportCSV.Text = "&CSV File (comma separated values)";
            this.contextMenuExportCSV.Click += new System.EventHandler(this.contextMenuExportCSV_Click);
            // 
            // contextMenuExportXML
            // 
            this.contextMenuExportXML.Name = "contextMenuExportXML";
            this.contextMenuExportXML.Size = new System.Drawing.Size(258, 22);
            this.contextMenuExportXML.Text = "&XML File";
            this.contextMenuExportXML.Click += new System.EventHandler(this.contextMenuExportXML_Click);
            // 
            // contextMenuExportTable
            // 
            this.contextMenuExportTable.Name = "contextMenuExportTable";
            this.contextMenuExportTable.Size = new System.Drawing.Size(258, 22);
            this.contextMenuExportTable.Text = "as Data &Table";
            this.contextMenuExportTable.Click += new System.EventHandler(this.contextMenuExportTable_Click);
            // 
            // contextMenuSaveAsServerGroup
            // 
            this.contextMenuSaveAsServerGroup.Enabled = false;
            this.contextMenuSaveAsServerGroup.Name = "contextMenuSaveAsServerGroup";
            this.contextMenuSaveAsServerGroup.Size = new System.Drawing.Size(188, 22);
            this.contextMenuSaveAsServerGroup.Text = "Save as Server &Group";
            this.contextMenuSaveAsServerGroup.Click += new System.EventHandler(this.contextMenuSaveAsServerGroup_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(185, 6);
            // 
            // contextMenuClear
            // 
            this.contextMenuClear.Name = "contextMenuClear";
            this.contextMenuClear.Size = new System.Drawing.Size(188, 22);
            this.contextMenuClear.Text = "&Clear";
            this.contextMenuClear.Click += new System.EventHandler(this.contextMenuClear_Click);
            // 
            // labelWmiErrors
            // 
            this.labelWmiErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelWmiErrors.BackgroundStyle.Class = "";
            this.labelWmiErrors.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelWmiErrors.Image = ((System.Drawing.Image)(resources.GetObject("labelWmiErrors.Image")));
            this.labelWmiErrors.Location = new System.Drawing.Point(522, 447);
            this.labelWmiErrors.Name = "labelWmiErrors";
            this.labelWmiErrors.Size = new System.Drawing.Size(218, 23);
            this.labelWmiErrors.TabIndex = 12;
            this.labelWmiErrors.Text = "Some server data was not accessible.  ";
            // 
            // superTooltip1
            // 
            this.superTooltip1.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTooltip1.DelayTooltipHideDuration = 5000;
            this.superTooltip1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superTooltip1.MinimumTooltipSize = new System.Drawing.Size(450, 100);
            this.superTooltip1.TooltipDuration = 5;
            this.superTooltip1.TooltipClosed += new System.EventHandler(this.superTooltip1_TooltipClosed);
            this.superTooltip1.MarkupLinkClick += new DevComponents.DotNetBar.MarkupLinkClickEventHandler(this.superTooltip1_MarkupLinkClick);
            // 
            // ideraTitleBar1
            // 
            this.ideraTitleBar1.ActivateLicenseEventHandler = null;
            this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
            this.ideraTitleBar1.Close = true;
            this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
            this.ideraTitleBar1.IderaProductNameText = "SQL Inventory Reporter";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = true;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(853, 93);
            this.ideraTitleBar1.TabIndex = 14;
            this.ideraTitleBar1.TrialMode = true;
            this.ideraTitleBar1.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar1_LicenseInfoButtonClick);
            // 
            // Form_Main
            // 
            this.AcceptButton = this.buttonLoadInventoryData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(853, 700);
            this.ControlBox = false;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.toolProductBanner);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ideraTitleBar1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "Form_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "xx";
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolProductBanner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.panelButtonBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.groupInventory.ResumeLayout(false);
            this.groupInventory.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.PictureBox pictureBoxTitle;
        private System.Windows.Forms.ToolStripMenuItem menuExitToLaunchpad;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuLaunchpad;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuOpenSnapshot;
        private System.Windows.Forms.ToolStripMenuItem menuSaveSnapshot;
        private DevComponents.DotNetBar.LabelX labelSubtitle;
        private DevComponents.DotNetBar.LabelX labelTitle;
        private System.Windows.Forms.Panel panelTop;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Panel panelBottom;
        private DevComponents.DotNetBar.Controls.GroupPanel groupInventory;
        private System.Windows.Forms.ToolStripMenuItem menuToolsetOptions;
        private DevComponents.DotNetBar.Controls.ListViewEx listInventory;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextMenuSaveSnapshot;
        private System.Windows.Forms.ToolStripMenuItem contextMenuCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem contextMenuClear;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuClear;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem menuExport;
        private System.Windows.Forms.ToolStripMenuItem menuExportAsCSV;
        private System.Windows.Forms.ToolStripMenuItem menuExportAsXML;
        private System.Windows.Forms.ToolStripMenuItem menuExportAsTable;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem menuHighlightDifferences;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ComboBox comboReportType;
        private System.Windows.Forms.Label labelSelectReportType;
        private System.Windows.Forms.ToolStripMenuItem contextMenuHighlightDifferences;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuShowServersAsRows;
        private System.Windows.Forms.ToolStripMenuItem contextMenuShowServersAsRows;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem menuClearSnapshots;
        private System.Windows.Forms.ToolStripMenuItem menuClearLiveData;
        private System.Windows.Forms.ToolStripMenuItem menuManageServerGroups;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExport;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExportCSV;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExportXML;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExportTable;
        private System.Windows.Forms.ToolStripMenuItem contextMenuRemoveServer;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAsServerGroup;
        private System.Windows.Forms.ToolStripMenuItem contextMenuSaveAsServerGroup;
        private System.Windows.Forms.ToolStripMenuItem menuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem contextMenuSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem buttonOpenSnapshot;
        private DevComponents.DotNetBar.ButtonItem buttonSave;
        private DevComponents.DotNetBar.ButtonItem buttonHighlightDifferences;
        private DevComponents.DotNetBar.ButtonItem buttonCopy;
        private DevComponents.DotNetBar.ButtonItem buttonClear;
        private System.Windows.Forms.Panel panelButtonBar;
        private DevComponents.DotNetBar.LabelX labelWmiErrors;
        private System.Windows.Forms.LinkLabel linkWmiErrorDetails;
        private DevComponents.DotNetBar.SuperTooltip superTooltip1;
        private DevComponents.DotNetBar.ButtonX buttonLoadInventoryData;
        private Idera.SqlAdminToolset.Core.Controls.ToolServerSelection ServerSelection;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
    }
}

