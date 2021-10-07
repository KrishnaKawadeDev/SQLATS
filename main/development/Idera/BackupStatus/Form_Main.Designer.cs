using System.Windows.Forms;

namespace Idera.SqlAdminToolset.BackupStatus
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
            this.menuCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuXML = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBackupStatusOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.menuManageServerGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsetOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContactTechnicalSupport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuManageLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAboutIderaProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.labelStatus = new DevComponents.DotNetBar.LabelX();
            this.buttonShowBackupHistory = new DevComponents.DotNetBar.ButtonX();
            this.buttonCopyToClipboard = new DevComponents.DotNetBar.ButtonX();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.panelContents = new System.Windows.Forms.Panel();
            this.groupResults = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupStatistics = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelServersScanned = new DevComponents.DotNetBar.LabelX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelServersNeedingBackup = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTotalDatabases = new System.Windows.Forms.PictureBox();
            this.pictureBoxNewDatabases = new System.Windows.Forms.PictureBox();
            this.labelTotal = new DevComponents.DotNetBar.LabelX();
            this.labelNewDatabases = new DevComponents.DotNetBar.LabelX();
            this.labelNeverBackedUp = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxDatabasesNeverBackedUp = new System.Windows.Forms.PictureBox();
            this.pictureBoxDatbasesWithNoRecent = new System.Windows.Forms.PictureBox();
            this.labelNoRecentBackup = new DevComponents.DotNetBar.LabelX();
            this.groupStatus = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pictureOverallStatus = new System.Windows.Forms.PictureBox();
            this.labelOverallStatus = new DevComponents.DotNetBar.LabelX();
            this.labelDatabaseList = new DevComponents.DotNetBar.LabelX();
            this.listResults = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDatabase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDbType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLastFullBackup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnBackupSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRecoveryMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuShowBackupHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuXML = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSaveAsDataTable = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelEmptyResultSet = new DevComponents.DotNetBar.LabelX();
            this.panelUserInput = new System.Windows.Forms.Panel();
            this.groupTop = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkIncludeOnlyFullBackups = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.linkDays = new System.Windows.Forms.LinkLabel();
            this.ServerSelection = new Idera.SqlAdminToolset.Core.Controls.ToolServerSelection();
            this.checkExcludeSystemDatabases = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkExcludeOldDatabases = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkExcludeOfflineDatabases = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkExcludeDatabasesWithBackup = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkIncludeAllNodes = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.buttonGetBackupHistory = new DevComponents.DotNetBar.ButtonX();
            this.imageOverallStatus = new System.Windows.Forms.ImageList(this.components);
            this.ideraTitleBar = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.menuStrip1.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelContents.SuspendLayout();
            this.groupResults.SuspendLayout();
            this.groupStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTotalDatabases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewDatabases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDatabasesNeverBackedUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDatbasesWithNoRecent)).BeginInit();
            this.groupStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOverallStatus)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panelUserInput.SuspendLayout();
            this.groupTop.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(982, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExport,
            this.toolStripMenuItem5,
            this.printToolStripMenuItem,
            this.toolStripSeparator1,
            this.menuExitToLaunchpad,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuExport
            // 
            this.menuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCSV,
            this.menuXML,
            this.dataTableToolStripMenuItem});
            this.menuExport.Enabled = false;
            this.menuExport.Name = "menuExport";
            this.menuExport.Size = new System.Drawing.Size(169, 22);
            this.menuExport.Text = "Save Results As";
            // 
            // menuCSV
            // 
            this.menuCSV.Name = "menuCSV";
            this.menuCSV.Size = new System.Drawing.Size(264, 22);
            this.menuCSV.Text = "CSV File(comma separated values)...";
            this.menuCSV.Click += new System.EventHandler(this.menuCSV_Click);
            // 
            // menuXML
            // 
            this.menuXML.Name = "menuXML";
            this.menuXML.Size = new System.Drawing.Size(264, 22);
            this.menuXML.Text = "XML File...";
            this.menuXML.Click += new System.EventHandler(this.menuXML_Click);
            // 
            // dataTableToolStripMenuItem
            // 
            this.dataTableToolStripMenuItem.Name = "dataTableToolStripMenuItem";
            this.dataTableToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.dataTableToolStripMenuItem.Text = "&Data Table...";
            this.dataTableToolStripMenuItem.Click += new System.EventHandler(this.dataTableToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(166, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Enabled = false;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // menuExitToLaunchpad
            // 
            this.menuExitToLaunchpad.Name = "menuExitToLaunchpad";
            this.menuExitToLaunchpad.Size = new System.Drawing.Size(169, 22);
            this.menuExitToLaunchpad.Text = "Exit to &Launchpad";
            this.menuExitToLaunchpad.Click += new System.EventHandler(this.menuExitToLaunchpad_Click);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(169, 22);
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
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBackupStatusOptions,
            this.toolStripMenuItem8,
            this.menuManageServerGroups,
            this.menuToolsetOptions,
            this.toolStripMenuItem4,
            this.menuLaunchpad});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(46, 20);
            this.menuTools.Text = "&Tools";
            // 
            // menuBackupStatusOptions
            // 
            this.menuBackupStatusOptions.Name = "menuBackupStatusOptions";
            this.menuBackupStatusOptions.Size = new System.Drawing.Size(233, 22);
            this.menuBackupStatusOptions.Text = "Backup Status Options...";
            this.menuBackupStatusOptions.Click += new System.EventHandler(this.menuBackupStatusOptions_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(230, 6);
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
            this.menuAbout.Text = "&About BackupStatus";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
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
            this.panelTop.Size = new System.Drawing.Size(982, 52);
            this.panelTop.TabIndex = 0;
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
            this.labelTitle.Size = new System.Drawing.Size(300, 52);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Backup Status</font></b> ";
            // 
            // labelSubtitle
            // 
            // 
            // 
            // 
            this.labelSubtitle.BackgroundStyle.Class = "";
            this.labelSubtitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.Location = new System.Drawing.Point(380, 0);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(425, 52);
            this.labelSubtitle.TabIndex = 6;
            this.labelSubtitle.Text = "Check whether your databases are backed up";
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
            this.panelBottom.Controls.Add(this.labelStatus);
            this.panelBottom.Controls.Add(this.buttonShowBackupHistory);
            this.panelBottom.Controls.Add(this.buttonCopyToClipboard);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 647);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.panelBottom.Size = new System.Drawing.Size(982, 32);
            this.panelBottom.TabIndex = 11;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelStatus.BackgroundStyle.Class = "";
            this.labelStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelStatus.Location = new System.Drawing.Point(14, 9);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.TabIndex = 39;
            this.labelStatus.Text = "TotalDatabases";
            this.labelStatus.Visible = false;
            this.labelStatus.WordWrap = true;
            // 
            // buttonShowBackupHistory
            // 
            this.buttonShowBackupHistory.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonShowBackupHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowBackupHistory.BackColor = System.Drawing.Color.White;
            this.buttonShowBackupHistory.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonShowBackupHistory.Enabled = false;
            this.buttonShowBackupHistory.Image = ((System.Drawing.Image)(resources.GetObject("buttonShowBackupHistory.Image")));
            this.buttonShowBackupHistory.Location = new System.Drawing.Point(591, 4);
            this.buttonShowBackupHistory.Name = "buttonShowBackupHistory";
            this.buttonShowBackupHistory.Size = new System.Drawing.Size(207, 24);
            this.buttonShowBackupHistory.TabIndex = 11;
            this.buttonShowBackupHistory.Text = "&Show Backup History for Database";
            this.buttonShowBackupHistory.Click += new System.EventHandler(this.buttonShowBackupHistory_Click);
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyToClipboard.BackColor = System.Drawing.Color.White;
            this.buttonCopyToClipboard.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCopyToClipboard.Enabled = false;
            this.buttonCopyToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyToClipboard.Image")));
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(804, 4);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(169, 24);
            this.buttonCopyToClipboard.TabIndex = 12;
            this.buttonCopyToClipboard.Text = "&Copy Results To Clipboard";
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click_1);
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.panelContents);
            this.panelMiddle.Controls.Add(this.panelUserInput);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(0, 169);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(982, 478);
            this.panelMiddle.TabIndex = 0;
            // 
            // panelContents
            // 
            this.panelContents.Controls.Add(this.groupResults);
            this.panelContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContents.Location = new System.Drawing.Point(0, 115);
            this.panelContents.Name = "panelContents";
            this.panelContents.Padding = new System.Windows.Forms.Padding(6);
            this.panelContents.Size = new System.Drawing.Size(982, 363);
            this.panelContents.TabIndex = 5;
            // 
            // groupResults
            // 
            this.groupResults.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupResults.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupResults.Controls.Add(this.groupStatistics);
            this.groupResults.Controls.Add(this.groupStatus);
            this.groupResults.Controls.Add(this.labelDatabaseList);
            this.groupResults.Controls.Add(this.listResults);
            this.groupResults.Controls.Add(this.labelEmptyResultSet);
            this.groupResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupResults.IsShadowEnabled = true;
            this.groupResults.Location = new System.Drawing.Point(6, 6);
            this.groupResults.Name = "groupResults";
            this.groupResults.Size = new System.Drawing.Size(970, 351);
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
            this.groupResults.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
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
            this.groupResults.TabIndex = 10;
            this.groupResults.Text = "Backup Status";
            // 
            // groupStatistics
            // 
            this.groupStatistics.BackColor = System.Drawing.Color.Transparent;
            this.groupStatistics.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupStatistics.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupStatistics.Controls.Add(this.labelServersScanned);
            this.groupStatistics.Controls.Add(this.pictureBox1);
            this.groupStatistics.Controls.Add(this.pictureBox2);
            this.groupStatistics.Controls.Add(this.labelServersNeedingBackup);
            this.groupStatistics.Controls.Add(this.pictureBoxTotalDatabases);
            this.groupStatistics.Controls.Add(this.pictureBoxNewDatabases);
            this.groupStatistics.Controls.Add(this.labelTotal);
            this.groupStatistics.Controls.Add(this.labelNewDatabases);
            this.groupStatistics.Controls.Add(this.labelNeverBackedUp);
            this.groupStatistics.Controls.Add(this.pictureBoxDatabasesNeverBackedUp);
            this.groupStatistics.Controls.Add(this.pictureBoxDatbasesWithNoRecent);
            this.groupStatistics.Controls.Add(this.labelNoRecentBackup);
            this.groupStatistics.Location = new System.Drawing.Point(212, 7);
            this.groupStatistics.Name = "groupStatistics";
            this.groupStatistics.Size = new System.Drawing.Size(725, 65);
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
            this.groupStatistics.TabIndex = 8;
            // 
            // labelServersScanned
            // 
            this.labelServersScanned.AutoSize = true;
            this.labelServersScanned.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelServersScanned.BackgroundStyle.Class = "";
            this.labelServersScanned.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServersScanned.Location = new System.Drawing.Point(36, 10);
            this.labelServersScanned.Name = "labelServersScanned";
            this.labelServersScanned.Size = new System.Drawing.Size(110, 15);
            this.labelServersScanned.TabIndex = 60;
            this.labelServersScanned.Text = "SQL Servers scanned";
            this.labelServersScanned.WordWrap = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(14, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 62;
            this.pictureBox2.TabStop = false;
            // 
            // labelServersNeedingBackup
            // 
            this.labelServersNeedingBackup.AutoSize = true;
            this.labelServersNeedingBackup.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelServersNeedingBackup.BackgroundStyle.Class = "";
            this.labelServersNeedingBackup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServersNeedingBackup.Location = new System.Drawing.Point(36, 36);
            this.labelServersNeedingBackup.Name = "labelServersNeedingBackup";
            this.labelServersNeedingBackup.Size = new System.Drawing.Size(151, 15);
            this.labelServersNeedingBackup.TabIndex = 61;
            this.labelServersNeedingBackup.Text = "SQL Servers needing backups";
            this.labelServersNeedingBackup.WordWrap = true;
            // 
            // pictureBoxTotalDatabases
            // 
            this.pictureBoxTotalDatabases.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTotalDatabases.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTotalDatabases.Image")));
            this.pictureBoxTotalDatabases.Location = new System.Drawing.Point(503, 36);
            this.pictureBoxTotalDatabases.Name = "pictureBoxTotalDatabases";
            this.pictureBoxTotalDatabases.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxTotalDatabases.TabIndex = 57;
            this.pictureBoxTotalDatabases.TabStop = false;
            // 
            // pictureBoxNewDatabases
            // 
            this.pictureBoxNewDatabases.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxNewDatabases.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNewDatabases.Image")));
            this.pictureBoxNewDatabases.Location = new System.Drawing.Point(503, 10);
            this.pictureBoxNewDatabases.Name = "pictureBoxNewDatabases";
            this.pictureBoxNewDatabases.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxNewDatabases.TabIndex = 58;
            this.pictureBoxNewDatabases.TabStop = false;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelTotal.BackgroundStyle.Class = "";
            this.labelTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTotal.Location = new System.Drawing.Point(529, 36);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(99, 15);
            this.labelTotal.TabIndex = 52;
            this.labelTotal.Text = "Databases checked";
            // 
            // labelNewDatabases
            // 
            this.labelNewDatabases.AutoSize = true;
            this.labelNewDatabases.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelNewDatabases.BackgroundStyle.Class = "";
            this.labelNewDatabases.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelNewDatabases.Location = new System.Drawing.Point(529, 10);
            this.labelNewDatabases.Name = "labelNewDatabases";
            this.labelNewDatabases.Size = new System.Drawing.Size(168, 15);
            this.labelNewDatabases.TabIndex = 53;
            this.labelNewDatabases.Text = "Databases created in last 30 days";
            this.labelNewDatabases.WordWrap = true;
            // 
            // labelNeverBackedUp
            // 
            this.labelNeverBackedUp.AutoSize = true;
            this.labelNeverBackedUp.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelNeverBackedUp.BackgroundStyle.Class = "";
            this.labelNeverBackedUp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelNeverBackedUp.Location = new System.Drawing.Point(267, 11);
            this.labelNeverBackedUp.Name = "labelNeverBackedUp";
            this.labelNeverBackedUp.Size = new System.Drawing.Size(139, 15);
            this.labelNeverBackedUp.TabIndex = 38;
            this.labelNeverBackedUp.Text = "Databases never backed up";
            this.labelNeverBackedUp.WordWrap = true;
            // 
            // pictureBoxDatabasesNeverBackedUp
            // 
            this.pictureBoxDatabasesNeverBackedUp.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxDatabasesNeverBackedUp.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDatabasesNeverBackedUp.Image")));
            this.pictureBoxDatabasesNeverBackedUp.Location = new System.Drawing.Point(245, 11);
            this.pictureBoxDatabasesNeverBackedUp.Name = "pictureBoxDatabasesNeverBackedUp";
            this.pictureBoxDatabasesNeverBackedUp.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxDatabasesNeverBackedUp.TabIndex = 37;
            this.pictureBoxDatabasesNeverBackedUp.TabStop = false;
            // 
            // pictureBoxDatbasesWithNoRecent
            // 
            this.pictureBoxDatbasesWithNoRecent.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxDatbasesWithNoRecent.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDatbasesWithNoRecent.Image")));
            this.pictureBoxDatbasesWithNoRecent.Location = new System.Drawing.Point(245, 37);
            this.pictureBoxDatbasesWithNoRecent.Name = "pictureBoxDatbasesWithNoRecent";
            this.pictureBoxDatbasesWithNoRecent.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxDatbasesWithNoRecent.TabIndex = 49;
            this.pictureBoxDatbasesWithNoRecent.TabStop = false;
            // 
            // labelNoRecentBackup
            // 
            this.labelNoRecentBackup.AutoSize = true;
            this.labelNoRecentBackup.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelNoRecentBackup.BackgroundStyle.Class = "";
            this.labelNoRecentBackup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelNoRecentBackup.Location = new System.Drawing.Point(267, 37);
            this.labelNoRecentBackup.Name = "labelNoRecentBackup";
            this.labelNoRecentBackup.Size = new System.Drawing.Size(192, 15);
            this.labelNoRecentBackup.TabIndex = 46;
            this.labelNoRecentBackup.Text = "Databases backed up but not in 7 days";
            this.labelNoRecentBackup.WordWrap = true;
            // 
            // groupStatus
            // 
            this.groupStatus.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupStatus.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupStatus.Controls.Add(this.pictureOverallStatus);
            this.groupStatus.Controls.Add(this.labelOverallStatus);
            this.groupStatus.DrawTitleBox = false;
            this.groupStatus.Location = new System.Drawing.Point(5, 7);
            this.groupStatus.Name = "groupStatus";
            this.groupStatus.Size = new System.Drawing.Size(191, 65);
            // 
            // 
            // 
            this.groupStatus.Style.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupStatus.Style.BackColor2 = System.Drawing.SystemColors.ControlLightLight;
            this.groupStatus.Style.BackColorGradientAngle = 90;
            this.groupStatus.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupStatus.Style.BorderBottomWidth = 1;
            this.groupStatus.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupStatus.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupStatus.Style.BorderLeftWidth = 1;
            this.groupStatus.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupStatus.Style.BorderRightWidth = 1;
            this.groupStatus.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupStatus.Style.BorderTopWidth = 1;
            this.groupStatus.Style.Class = "";
            this.groupStatus.Style.CornerDiameter = 4;
            this.groupStatus.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupStatus.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupStatus.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupStatus.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupStatus.StyleMouseDown.Class = "";
            this.groupStatus.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupStatus.StyleMouseOver.Class = "";
            this.groupStatus.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupStatus.TabIndex = 7;
            // 
            // pictureOverallStatus
            // 
            this.pictureOverallStatus.BackColor = System.Drawing.Color.Transparent;
            this.pictureOverallStatus.Image = ((System.Drawing.Image)(resources.GetObject("pictureOverallStatus.Image")));
            this.pictureOverallStatus.Location = new System.Drawing.Point(5, 6);
            this.pictureOverallStatus.Name = "pictureOverallStatus";
            this.pictureOverallStatus.Size = new System.Drawing.Size(48, 48);
            this.pictureOverallStatus.TabIndex = 50;
            this.pictureOverallStatus.TabStop = false;
            // 
            // labelOverallStatus
            // 
            this.labelOverallStatus.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelOverallStatus.BackgroundStyle.Class = "";
            this.labelOverallStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelOverallStatus.Location = new System.Drawing.Point(58, 3);
            this.labelOverallStatus.Name = "labelOverallStatus";
            this.labelOverallStatus.Size = new System.Drawing.Size(123, 52);
            this.labelOverallStatus.TabIndex = 51;
            this.labelOverallStatus.Text = "Overall Backup Status";
            this.labelOverallStatus.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelOverallStatus.WordWrap = true;
            // 
            // labelDatabaseList
            // 
            this.labelDatabaseList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDatabaseList.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelDatabaseList.BackgroundStyle.Class = "";
            this.labelDatabaseList.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelDatabaseList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDatabaseList.Location = new System.Drawing.Point(5, 78);
            this.labelDatabaseList.Name = "labelDatabaseList";
            this.labelDatabaseList.Size = new System.Drawing.Size(954, 20);
            this.labelDatabaseList.TabIndex = 9;
            this.labelDatabaseList.Text = "B&ackup Status for each Database";
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
            this.columnServer,
            this.columnDatabase,
            this.columnDbType,
            this.columnLastFullBackup,
            this.columnBackupSize,
            this.columnCreateDate,
            this.columnRecoveryMode});
            this.listResults.ContextMenuStrip = this.contextMenuStrip1;
            this.listResults.FullRowSelect = true;
            this.listResults.Location = new System.Drawing.Point(4, 100);
            this.listResults.Name = "listResults";
            this.listResults.Size = new System.Drawing.Size(957, 233);
            this.listResults.SmallImageList = this.imageList1;
            this.listResults.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listResults.TabIndex = 10;
            this.listResults.UseCompatibleStateImageBehavior = false;
            this.listResults.View = System.Windows.Forms.View.Details;
            this.listResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listResults_ColumnClick);
            this.listResults.SelectedIndexChanged += new System.EventHandler(this.listResults_SelectedIndexChanged);
            this.listResults.DoubleClick += new System.EventHandler(this.listResults_DoubleClick);
            this.listResults.Enter += new System.EventHandler(this.listResults_Enter);
            this.listResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listResults_KeyDown);
            this.listResults.Leave += new System.EventHandler(this.listResults_Leave);
            // 
            // columnIcon
            // 
            this.columnIcon.Text = "";
            this.columnIcon.Width = 24;
            // 
            // columnServer
            // 
            this.columnServer.Text = "SQL Server";
            this.columnServer.Width = 120;
            // 
            // columnDatabase
            // 
            this.columnDatabase.Text = "Database";
            this.columnDatabase.Width = 130;
            // 
            // columnDbType
            // 
            this.columnDbType.Text = "DB Type";
            // 
            // columnLastFullBackup
            // 
            this.columnLastFullBackup.Text = "Last Backup";
            this.columnLastFullBackup.Width = 80;
            // 
            // columnBackupSize
            // 
            this.columnBackupSize.Text = "Backup Size";
            this.columnBackupSize.Width = 80;
            // 
            // columnCreateDate
            // 
            this.columnCreateDate.Text = "Date DB Created";
            this.columnCreateDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnCreateDate.Width = 90;
            // 
            // columnRecoveryMode
            // 
            this.columnRecoveryMode.Text = "Recovery Model";
            this.columnRecoveryMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnRecoveryMode.Width = 90;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuShowBackupHistory,
            this.toolStripMenuItem6,
            this.contextMenuCopy,
            this.contextMenuSelectAll,
            this.toolStripMenuItem7,
            this.contextMenuExport});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 104);
            // 
            // contextMenuShowBackupHistory
            // 
            this.contextMenuShowBackupHistory.Enabled = false;
            this.contextMenuShowBackupHistory.Image = ((System.Drawing.Image)(resources.GetObject("contextMenuShowBackupHistory.Image")));
            this.contextMenuShowBackupHistory.Name = "contextMenuShowBackupHistory";
            this.contextMenuShowBackupHistory.Size = new System.Drawing.Size(186, 22);
            this.contextMenuShowBackupHistory.Text = "Show &Backup History";
            this.contextMenuShowBackupHistory.Click += new System.EventHandler(this.showBackupHistoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(183, 6);
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.Enabled = false;
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.contextMenuCopy.Size = new System.Drawing.Size(186, 22);
            this.contextMenuCopy.Text = "&Copy";
            this.contextMenuCopy.Click += new System.EventHandler(this.contextMenuCopyToClipboard_Click);
            // 
            // contextMenuSelectAll
            // 
            this.contextMenuSelectAll.Enabled = false;
            this.contextMenuSelectAll.Name = "contextMenuSelectAll";
            this.contextMenuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.contextMenuSelectAll.Size = new System.Drawing.Size(186, 22);
            this.contextMenuSelectAll.Text = "Select &All";
            this.contextMenuSelectAll.Click += new System.EventHandler(this.contextMenuSelectAll_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(183, 6);
            // 
            // contextMenuExport
            // 
            this.contextMenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuCSV,
            this.contextMenuXML,
            this.contextMenuSaveAsDataTable});
            this.contextMenuExport.Enabled = false;
            this.contextMenuExport.Name = "contextMenuExport";
            this.contextMenuExport.Size = new System.Drawing.Size(186, 22);
            this.contextMenuExport.Text = "&Save Results As";
            // 
            // contextMenuCSV
            // 
            this.contextMenuCSV.Name = "contextMenuCSV";
            this.contextMenuCSV.Size = new System.Drawing.Size(258, 22);
            this.contextMenuCSV.Text = "&CSV File (comma separated values)";
            this.contextMenuCSV.Click += new System.EventHandler(this.contextMenuCSV_Click);
            // 
            // contextMenuXML
            // 
            this.contextMenuXML.Name = "contextMenuXML";
            this.contextMenuXML.Size = new System.Drawing.Size(258, 22);
            this.contextMenuXML.Text = "&XML File";
            this.contextMenuXML.Click += new System.EventHandler(this.contextMenuXML_Click);
            // 
            // contextMenuSaveAsDataTable
            // 
            this.contextMenuSaveAsDataTable.Name = "contextMenuSaveAsDataTable";
            this.contextMenuSaveAsDataTable.Size = new System.Drawing.Size(258, 22);
            this.contextMenuSaveAsDataTable.Text = "&Data Table";
            this.contextMenuSaveAsDataTable.Click += new System.EventHandler(this.contextMenuSaveAsDataTable_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Black;
            this.imageList1.Images.SetKeyName(0, "check2.png");
            this.imageList1.Images.SetKeyName(1, "warning.png");
            this.imageList1.Images.SetKeyName(2, "error.png");
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
            this.labelEmptyResultSet.Location = new System.Drawing.Point(5, 142);
            this.labelEmptyResultSet.Name = "labelEmptyResultSet";
            this.labelEmptyResultSet.Size = new System.Drawing.Size(954, 79);
            this.labelEmptyResultSet.TabIndex = 27;
            this.labelEmptyResultSet.Text = "No data available";
            this.labelEmptyResultSet.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelEmptyResultSet.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.labelEmptyResultSet.Visible = false;
            this.labelEmptyResultSet.WordWrap = true;
            // 
            // panelUserInput
            // 
            this.panelUserInput.Controls.Add(this.groupTop);
            this.panelUserInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUserInput.Location = new System.Drawing.Point(0, 0);
            this.panelUserInput.Margin = new System.Windows.Forms.Padding(6);
            this.panelUserInput.Name = "panelUserInput";
            this.panelUserInput.Padding = new System.Windows.Forms.Padding(6);
            this.panelUserInput.Size = new System.Drawing.Size(982, 115);
            this.panelUserInput.TabIndex = 4;
            // 
            // groupTop
            // 
            this.groupTop.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupTop.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupTop.Controls.Add(this.checkIncludeOnlyFullBackups);
            this.groupTop.Controls.Add(this.linkDays);
            this.groupTop.Controls.Add(this.ServerSelection);
            this.groupTop.Controls.Add(this.checkExcludeSystemDatabases);
            this.groupTop.Controls.Add(this.checkExcludeOldDatabases);
            this.groupTop.Controls.Add(this.checkExcludeOfflineDatabases);
            this.groupTop.Controls.Add(this.checkExcludeDatabasesWithBackup);
            this.groupTop.Controls.Add(this.checkIncludeAllNodes);
            this.groupTop.Controls.Add(this.buttonGetBackupHistory);
            this.groupTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupTop.IsShadowEnabled = true;
            this.groupTop.Location = new System.Drawing.Point(6, 6);
            this.groupTop.Name = "groupTop";
            this.groupTop.Size = new System.Drawing.Size(970, 103);
            // 
            // 
            // 
            this.groupTop.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupTop.Style.BackColorGradientAngle = 90;
            this.groupTop.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupTop.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupTop.Style.BorderBottomWidth = 1;
            this.groupTop.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupTop.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupTop.Style.BorderLeftWidth = 1;
            this.groupTop.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupTop.Style.BorderRightWidth = 1;
            this.groupTop.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupTop.Style.BorderTopWidth = 1;
            this.groupTop.Style.Class = "";
            this.groupTop.Style.CornerDiameter = 4;
            this.groupTop.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupTop.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupTop.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupTop.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupTop.StyleMouseDown.Class = "";
            this.groupTop.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupTop.StyleMouseOver.Class = "";
            this.groupTop.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupTop.TabIndex = 0;
            // 
            // checkIncludeOnlyFullBackups
            // 
            this.checkIncludeOnlyFullBackups.AutoSize = true;
            this.checkIncludeOnlyFullBackups.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkIncludeOnlyFullBackups.BackgroundStyle.Class = "";
            this.checkIncludeOnlyFullBackups.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkIncludeOnlyFullBackups.Location = new System.Drawing.Point(678, 42);
            this.checkIncludeOnlyFullBackups.Name = "checkIncludeOnlyFullBackups";
            this.checkIncludeOnlyFullBackups.Size = new System.Drawing.Size(192, 15);
            this.checkIncludeOnlyFullBackups.TabIndex = 11;
            this.checkIncludeOnlyFullBackups.Text = "Only include full database backups";
            // 
            // linkDays
            // 
            this.linkDays.AutoSize = true;
            this.linkDays.BackColor = System.Drawing.Color.Transparent;
            this.linkDays.LinkArea = new System.Windows.Forms.LinkArea(0, 255);
            this.linkDays.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkDays.Location = new System.Drawing.Point(895, 5);
            this.linkDays.Name = "linkDays";
            this.linkDays.Size = new System.Drawing.Size(45, 17);
            this.linkDays.TabIndex = 10;
            this.linkDays.TabStop = true;
            this.linkDays.Text = "{0} days";
            this.linkDays.UseCompatibleTextRendering = true;
            this.linkDays.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDays_LinkClicked);
            // 
            // ServerSelection
            // 
            this.ServerSelection.BackColor = System.Drawing.Color.Transparent;
            this.ServerSelection.Caption = "";
            this.ServerSelection.CredentialsVisible = true;
            this.ServerSelection.Location = new System.Drawing.Point(5, 8);
            this.ServerSelection.MinimumSize = new System.Drawing.Size(290, 40);
            this.ServerSelection.Name = "ServerSelection";
            this.ServerSelection.SelectionOptions = Idera.SqlAdminToolset.Core.Controls.ServerSelectionOptions.ServersAndGroups;
            this.ServerSelection.Size = new System.Drawing.Size(471, 48);
            this.ServerSelection.TabIndex = 1;
            this.ServerSelection.TextChangedEventHandler = null;
            this.ServerSelection.TextChanged += new System.EventHandler(this.ServerSelection_TextChanged);
            // 
            // checkExcludeSystemDatabases
            // 
            this.checkExcludeSystemDatabases.AutoSize = true;
            this.checkExcludeSystemDatabases.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkExcludeSystemDatabases.BackgroundStyle.Class = "";
            this.checkExcludeSystemDatabases.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkExcludeSystemDatabases.Checked = true;
            this.checkExcludeSystemDatabases.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkExcludeSystemDatabases.CheckValue = "Y";
            this.checkExcludeSystemDatabases.Location = new System.Drawing.Point(678, 23);
            this.checkExcludeSystemDatabases.Name = "checkExcludeSystemDatabases";
            this.checkExcludeSystemDatabases.Size = new System.Drawing.Size(143, 15);
            this.checkExcludeSystemDatabases.TabIndex = 9;
            this.checkExcludeSystemDatabases.Text = "Skip s&ystem databases";
            // 
            // checkExcludeOldDatabases
            // 
            this.checkExcludeOldDatabases.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkExcludeOldDatabases.BackgroundStyle.Class = "";
            this.checkExcludeOldDatabases.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkExcludeOldDatabases.Location = new System.Drawing.Point(881, 25);
            this.checkExcludeOldDatabases.Name = "checkExcludeOldDatabases";
            this.checkExcludeOldDatabases.Size = new System.Drawing.Size(68, 15);
            this.checkExcludeOldDatabases.TabIndex = 9;
            this.checkExcludeOldDatabases.Text = "Skip databases &older than 90 days";
            this.checkExcludeOldDatabases.Visible = false;
            // 
            // checkExcludeOfflineDatabases
            // 
            this.checkExcludeOfflineDatabases.AutoSize = true;
            this.checkExcludeOfflineDatabases.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkExcludeOfflineDatabases.BackgroundStyle.Class = "";
            this.checkExcludeOfflineDatabases.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkExcludeOfflineDatabases.Location = new System.Drawing.Point(677, 60);
            this.checkExcludeOfflineDatabases.Name = "checkExcludeOfflineDatabases";
            this.checkExcludeOfflineDatabases.Size = new System.Drawing.Size(152, 15);
            this.checkExcludeOfflineDatabases.TabIndex = 9;
            this.checkExcludeOfflineDatabases.Text = "Exclude Offline Databases";
            // 
            // checkExcludeDatabasesWithBackup
            // 
            this.checkExcludeDatabasesWithBackup.AutoSize = true;
            this.checkExcludeDatabasesWithBackup.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkExcludeDatabasesWithBackup.BackgroundStyle.Class = "";
            this.checkExcludeDatabasesWithBackup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkExcludeDatabasesWithBackup.Checked = true;
            this.checkExcludeDatabasesWithBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkExcludeDatabasesWithBackup.CheckValue = "Y";
            this.checkExcludeDatabasesWithBackup.Location = new System.Drawing.Point(678, 3);
            this.checkExcludeDatabasesWithBackup.Name = "checkExcludeDatabasesWithBackup";
            this.checkExcludeDatabasesWithBackup.Size = new System.Drawing.Size(225, 15);
            this.checkExcludeDatabasesWithBackup.TabIndex = 8;
            this.checkExcludeDatabasesWithBackup.Text = "&Skip databases with a backup in the last";
            // 
            // checkIncludeAllNodes
            // 
            this.checkIncludeAllNodes.AutoSize = true;
            this.checkIncludeAllNodes.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkIncludeAllNodes.BackgroundStyle.Class = "";
            this.checkIncludeAllNodes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkIncludeAllNodes.Location = new System.Drawing.Point(677, 78);
            this.checkIncludeAllNodes.Name = "checkIncludeAllNodes";
            this.checkIncludeAllNodes.Size = new System.Drawing.Size(105, 15);
            this.checkIncludeAllNodes.TabIndex = 8;
            this.checkIncludeAllNodes.Text = "Include all nodes";
            // 
            // buttonGetBackupHistory
            // 
            this.buttonGetBackupHistory.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonGetBackupHistory.BackColor = System.Drawing.Color.White;
            this.buttonGetBackupHistory.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonGetBackupHistory.Image = ((System.Drawing.Image)(resources.GetObject("buttonGetBackupHistory.Image")));
            this.buttonGetBackupHistory.Location = new System.Drawing.Point(478, 7);
            this.buttonGetBackupHistory.Name = "buttonGetBackupHistory";
            this.buttonGetBackupHistory.Size = new System.Drawing.Size(191, 46);
            this.buttonGetBackupHistory.TabIndex = 7;
            this.buttonGetBackupHistory.Text = "&Get Backup Status";
            this.buttonGetBackupHistory.Click += new System.EventHandler(this.buttonGetBackupHistory_Click);
            // 
            // imageOverallStatus
            // 
            this.imageOverallStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageOverallStatus.ImageStream")));
            this.imageOverallStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.imageOverallStatus.Images.SetKeyName(0, "check2.png");
            this.imageOverallStatus.Images.SetKeyName(1, "warning.png");
            this.imageOverallStatus.Images.SetKeyName(2, "error.png");
            this.imageOverallStatus.Images.SetKeyName(3, "unknown.png");
            // 
            // ideraTitleBar
            // 
            this.ideraTitleBar.ActivateLicenseEventHandler = null;
            this.ideraTitleBar.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
            this.ideraTitleBar.Close = true;
            this.ideraTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ideraTitleBar.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
            this.ideraTitleBar.IderaProductNameText = "SQL Backup Status";
            this.ideraTitleBar.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar.IsFormLocked = false;
            this.ideraTitleBar.LicenseInformation = null;
            this.ideraTitleBar.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar.Maximize = true;
            this.ideraTitleBar.Minimize = true;
            this.ideraTitleBar.Name = "ideraTitleBar";
            this.ideraTitleBar.Size = new System.Drawing.Size(982, 93);
            this.ideraTitleBar.TabIndex = 12;
            this.ideraTitleBar.TrialDaysLeft = 15;
            this.ideraTitleBar.TrialMode = true;
            this.ideraTitleBar.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar_LicenseInfoButtonClick);
            // 
            // Form_Main
            // 
            this.AcceptButton = this.buttonGetBackupHistory;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 679);
            this.ControlBox = false;
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.ideraTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(700, 426);
            this.Name = "Form_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelMiddle.ResumeLayout(false);
            this.panelContents.ResumeLayout(false);
            this.groupResults.ResumeLayout(false);
            this.groupStatistics.ResumeLayout(false);
            this.groupStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTotalDatabases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewDatabases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDatabasesNeverBackedUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDatbasesWithNoRecent)).EndInit();
            this.groupStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureOverallStatus)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelUserInput.ResumeLayout(false);
            this.groupTop.ResumeLayout(false);
            this.groupTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void CheckIncludeAllNodes_CheckedChanged(object sender, System.EventArgs e)
        {
            ProductConstants.optionIncludeAllNodes = checkIncludeAllNodes.Checked;
        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem menuShowHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuAboutIderaProducts;
        private System.Windows.Forms.ToolStripMenuItem menuContactTechnicalSupport;
        private System.Windows.Forms.ToolStripMenuItem menuCheckForUpdates;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.PictureBox pictureBoxTitle;
        private System.Windows.Forms.ToolStripMenuItem menuExitToLaunchpad;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuLaunchpad;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.Panel panelUserInput;
        private System.Windows.Forms.Panel panelContents;
        private DevComponents.DotNetBar.LabelX labelSubtitle;
        private DevComponents.DotNetBar.LabelX labelTitle;
        private DevComponents.DotNetBar.Controls.GroupPanel groupResults;
        private DevComponents.DotNetBar.ButtonX buttonCopyToClipboard;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonX buttonShowBackupHistory;
        private DevComponents.DotNetBar.LabelX labelDatabaseList;
        private DevComponents.DotNetBar.LabelX labelEmptyResultSet;
        private DevComponents.DotNetBar.Controls.ListViewEx listResults;
        private System.Windows.Forms.ColumnHeader columnIcon;
        private System.Windows.Forms.ColumnHeader columnDatabase;
      //  private System.Windows.Forms.ColumnHeader.columnPrimarySecondary;
        private System.Windows.Forms.ColumnHeader columnCreateDate;
        private System.Windows.Forms.ColumnHeader columnLastFullBackup;
        private System.Windows.Forms.ColumnHeader columnBackupSize;
        private DevComponents.DotNetBar.LabelX labelNeverBackedUp;
        private System.Windows.Forms.PictureBox pictureBoxDatabasesNeverBackedUp;
        private DevComponents.DotNetBar.LabelX labelNoRecentBackup;
        private DevComponents.DotNetBar.LabelX labelOverallStatus;
        private System.Windows.Forms.PictureBox pictureOverallStatus;
        private System.Windows.Forms.PictureBox pictureBoxDatbasesWithNoRecent;
        private DevComponents.DotNetBar.Controls.GroupPanel groupStatistics;
        private DevComponents.DotNetBar.Controls.GroupPanel groupStatus;
        private DevComponents.DotNetBar.LabelX labelTotal;
        private DevComponents.DotNetBar.LabelX labelNewDatabases;
        private System.Windows.Forms.PictureBox pictureBoxTotalDatabases;
        private System.Windows.Forms.PictureBox pictureBoxNewDatabases;
        private System.Windows.Forms.ImageList imageOverallStatus;
        private DevComponents.DotNetBar.LabelX labelStatus;
        private DevComponents.DotNetBar.Controls.GroupPanel groupTop;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkExcludeOldDatabases;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkExcludeDatabasesWithBackup;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkIncludeAllNodes;
        private DevComponents.DotNetBar.ButtonX buttonGetBackupHistory;
        private System.Windows.Forms.ToolStripMenuItem menuToolsetOptions;
        private System.Windows.Forms.ColumnHeader columnDbType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuCopy;
        private System.Windows.Forms.ToolStripMenuItem contextMenuShowBackupHistory;
        private System.Windows.Forms.ToolStripMenuItem menuManageServerGroups;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ColumnHeader columnServer;
        private DevComponents.DotNetBar.LabelX labelServersScanned;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevComponents.DotNetBar.LabelX labelServersNeedingBackup;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkExcludeSystemDatabases;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkExcludeOfflineDatabases;
        private Idera.SqlAdminToolset.Core.Controls.ToolServerSelection ServerSelection;
        private System.Windows.Forms.ToolStripMenuItem menuExport;
        private System.Windows.Forms.ToolStripMenuItem menuCSV;
        private System.Windows.Forms.ToolStripMenuItem menuXML;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem menuSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem contextMenuSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExport;
        private System.Windows.Forms.ToolStripMenuItem contextMenuCSV;
        private System.Windows.Forms.ToolStripMenuItem contextMenuXML;
        private System.Windows.Forms.ToolStripMenuItem dataTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contextMenuSaveAsDataTable;
        private System.Windows.Forms.ToolStripMenuItem menuBackupStatusOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.LinkLabel linkDays;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkIncludeOnlyFullBackups;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar;
        private ToolStripMenuItem menuManageLicense;
        private ColumnHeader columnRecoveryMode;
    }
}

