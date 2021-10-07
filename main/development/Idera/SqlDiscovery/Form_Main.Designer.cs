namespace Idera.SqlAdminToolset.SqlDiscovery
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("UDP");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("TCP");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("WMI");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("SCM");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("REG");
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportAsXML = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.securityScannerOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.panelResults = new System.Windows.Forms.Panel();
            this.buttonDoSameScan = new DevComponents.DotNetBar.ButtonX();
            this.buttonCopyResultsToClipboard = new DevComponents.DotNetBar.ButtonX();
            this.buttonSaveAsServerGroup = new DevComponents.DotNetBar.ButtonX();
            this.buttonDoAnotherScan = new DevComponents.DotNetBar.ButtonX();
            this.buttonClose = new DevComponents.DotNetBar.ButtonX();
            this.labelScanHeading = new DevComponents.DotNetBar.LabelX();
            this.buttonCancelScan = new DevComponents.DotNetBar.ButtonX();
            this.listServers = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnSQLServer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnComputer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnResolution = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colClustered = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSSNetLib = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuSaveAsServerGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.contextExportAsCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.contextExportAsXML = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBarScanning = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.groupDetails = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textDetails_IsClustered = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textDetails_Port = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textDetails_ServiceAccount = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textDetails_BaseVersion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textDetails_SSNetLibVersion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textDetails_Computer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textDetails_IP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX33 = new DevComponents.DotNetBar.LabelX();
            this.labelX35 = new DevComponents.DotNetBar.LabelX();
            this.labelX37 = new DevComponents.DotNetBar.LabelX();
            this.labelX23 = new DevComponents.DotNetBar.LabelX();
            this.labelX25 = new DevComponents.DotNetBar.LabelX();
            this.labelX17 = new DevComponents.DotNetBar.LabelX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.listViewDetails = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelNoServersFound = new DevComponents.DotNetBar.LabelX();
            this.wizard = new DevComponents.DotNetBar.Wizard();
            this.pageWelcome = new DevComponents.DotNetBar.WizardPage();
            this.reflectionImage1 = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pageSelectScanType = new DevComponents.DotNetBar.WizardPage();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.radioScanType_Ip = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioScanType_Computers = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioScanType_SqlServers = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelScanTypeSQLServers = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.radioScanType_Stealth = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelServerGroup = new DevComponents.DotNetBar.LabelX();
            this.labelScanTypeComputers = new DevComponents.DotNetBar.LabelX();
            this.pageSelectSqlServers = new DevComponents.DotNetBar.WizardPage();
            this.textServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.radioSelectServers = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.buttonBrowseGroups = new DevComponents.DotNetBar.ButtonX();
            this.textServerGroup = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonBrowseServer = new DevComponents.DotNetBar.ButtonX();
            this.radioSelectGroups = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.pageSelectComputers = new DevComponents.DotNetBar.WizardPage();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.textComputerList = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonBrowseFroComputers = new DevComponents.DotNetBar.ButtonX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.pageSelectIpRange = new DevComponents.DotNetBar.WizardPage();
            this.buttonUnselectAll = new DevComponents.DotNetBar.ButtonX();
            this.buttonSelectAll = new DevComponents.DotNetBar.ButtonX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.buttonSaveIpList = new DevComponents.DotNetBar.ButtonX();
            this.buttonAddLocalSubnet = new DevComponents.DotNetBar.ButtonX();
            this.buttonAddLocalComputer = new DevComponents.DotNetBar.ButtonX();
            this.listIpAddresses = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.buttonRemoveIpAddress = new DevComponents.DotNetBar.ButtonX();
            this.buttonAddIpRange = new DevComponents.DotNetBar.ButtonX();
            this.buttonLoadIpList = new DevComponents.DotNetBar.ButtonX();
            this.pageOptions_ActiveScan = new DevComponents.DotNetBar.WizardPage();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.checkScan_SCM = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkScan_Reg = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkScan_WMI = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkScan_TCP = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkScan_UDP = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.pageOptions_StealthScan = new DevComponents.DotNetBar.WizardPage();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.checkScan_ActiveDirectory = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkScan_BrowserService = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelResults.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupDetails.SuspendLayout();
            this.wizard.SuspendLayout();
            this.pageWelcome.SuspendLayout();
            this.pageSelectScanType.SuspendLayout();
            this.pageSelectSqlServers.SuspendLayout();
            this.pageSelectComputers.SuspendLayout();
            this.pageSelectIpRange.SuspendLayout();
            this.pageOptions_ActiveScan.SuspendLayout();
            this.pageOptions_StealthScan.SuspendLayout();
            this.SuspendLayout();
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
            this.panelTop.Size = new System.Drawing.Size(914, 52);
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
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  SQL Discovery</font></b> ";
            // 
            // labelSubtitle
            // 
            // 
            // 
            // 
            this.labelSubtitle.BackgroundStyle.Class = "";
            this.labelSubtitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.Location = new System.Drawing.Point(360, 0);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(386, 52);
            this.labelSubtitle.TabIndex = 6;
            this.labelSubtitle.Text = "Find the SQL Servers lurking on your network";
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuTools,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 93);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(914, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExport,
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
            this.menuExportAsXML});
            this.menuExport.Enabled = false;
            this.menuExport.Name = "menuExport";
            this.menuExport.Size = new System.Drawing.Size(168, 22);
            this.menuExport.Text = "&Save Results As";
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
            this.menuCopy.Text = "Copy";
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
            this.securityScannerOptionsToolStripMenuItem,
            this.menuManageServerGroups,
            this.menuToolsetOptions,
            this.toolStripMenuItem4,
            this.menuLaunchpad});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(47, 20);
            this.menuTools.Text = "&Tools";
            // 
            // securityScannerOptionsToolStripMenuItem
            // 
            this.securityScannerOptionsToolStripMenuItem.Name = "securityScannerOptionsToolStripMenuItem";
            this.securityScannerOptionsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.securityScannerOptionsToolStripMenuItem.Text = "SQL Discovery Options...";
            this.securityScannerOptionsToolStripMenuItem.Click += new System.EventHandler(this.securityScannerOptionsToolStripMenuItem_Click);
            // 
            // menuManageServerGroups
            // 
            this.menuManageServerGroups.Name = "menuManageServerGroups";
            this.menuManageServerGroups.Size = new System.Drawing.Size(233, 22);
            this.menuManageServerGroups.Text = "Manage Server &Groups...";
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
            this.menuDeactivateLicense.Click += new System.EventHandler(this.menuDeacivateLicense_Click);
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
            this.menuAbout.Text = "&About SQL Discovery";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.panelResults);
            this.panelMiddle.Controls.Add(this.wizard);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(0, 169);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Padding = new System.Windows.Forms.Padding(6);
            this.panelMiddle.Size = new System.Drawing.Size(914, 453);
            this.panelMiddle.TabIndex = 14;
            // 
            // panelResults
            // 
            this.panelResults.Controls.Add(this.buttonDoSameScan);
            this.panelResults.Controls.Add(this.buttonCopyResultsToClipboard);
            this.panelResults.Controls.Add(this.buttonSaveAsServerGroup);
            this.panelResults.Controls.Add(this.buttonDoAnotherScan);
            this.panelResults.Controls.Add(this.buttonClose);
            this.panelResults.Controls.Add(this.labelScanHeading);
            this.panelResults.Controls.Add(this.buttonCancelScan);
            this.panelResults.Controls.Add(this.listServers);
            this.panelResults.Controls.Add(this.progressBarScanning);
            this.panelResults.Controls.Add(this.groupDetails);
            this.panelResults.Controls.Add(this.labelNoServersFound);
            this.panelResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResults.Location = new System.Drawing.Point(6, 6);
            this.panelResults.Name = "panelResults";
            this.panelResults.Size = new System.Drawing.Size(902, 441);
            this.panelResults.TabIndex = 1;
            // 
            // buttonDoSameScan
            // 
            this.buttonDoSameScan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonDoSameScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDoSameScan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonDoSameScan.Enabled = false;
            this.buttonDoSameScan.Location = new System.Drawing.Point(615, 415);
            this.buttonDoSameScan.Name = "buttonDoSameScan";
            this.buttonDoSameScan.Size = new System.Drawing.Size(102, 24);
            this.buttonDoSameScan.TabIndex = 22;
            this.buttonDoSameScan.Text = "Do Same Scan";
            this.buttonDoSameScan.Visible = false;
            this.buttonDoSameScan.Click += new System.EventHandler(this.buttonDoSameScan_Click);
            // 
            // buttonCopyResultsToClipboard
            // 
            this.buttonCopyResultsToClipboard.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCopyResultsToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCopyResultsToClipboard.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCopyResultsToClipboard.Enabled = false;
            this.buttonCopyResultsToClipboard.Location = new System.Drawing.Point(153, 415);
            this.buttonCopyResultsToClipboard.Name = "buttonCopyResultsToClipboard";
            this.buttonCopyResultsToClipboard.Size = new System.Drawing.Size(143, 24);
            this.buttonCopyResultsToClipboard.TabIndex = 21;
            this.buttonCopyResultsToClipboard.Text = "Copy &Results to Clipboard";
            this.buttonCopyResultsToClipboard.Click += new System.EventHandler(this.buttonCopyResultsToClipboard_Click);
            // 
            // buttonSaveAsServerGroup
            // 
            this.buttonSaveAsServerGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSaveAsServerGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveAsServerGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSaveAsServerGroup.Enabled = false;
            this.buttonSaveAsServerGroup.Location = new System.Drawing.Point(14, 415);
            this.buttonSaveAsServerGroup.Name = "buttonSaveAsServerGroup";
            this.buttonSaveAsServerGroup.Size = new System.Drawing.Size(133, 24);
            this.buttonSaveAsServerGroup.TabIndex = 19;
            this.buttonSaveAsServerGroup.Text = "Sa&ve as Server Group";
            this.buttonSaveAsServerGroup.Click += new System.EventHandler(this.buttonSaveAsServerGroup_Click);
            // 
            // buttonDoAnotherScan
            // 
            this.buttonDoAnotherScan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonDoAnotherScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDoAnotherScan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonDoAnotherScan.Enabled = false;
            this.buttonDoAnotherScan.Location = new System.Drawing.Point(723, 415);
            this.buttonDoAnotherScan.Name = "buttonDoAnotherScan";
            this.buttonDoAnotherScan.Size = new System.Drawing.Size(102, 24);
            this.buttonDoAnotherScan.TabIndex = 18;
            this.buttonDoAnotherScan.Text = "Do &Another Scan";
            this.buttonDoAnotherScan.Click += new System.EventHandler(this.buttonDoAnotherScan_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonClose.Location = new System.Drawing.Point(831, 415);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(66, 24);
            this.buttonClose.TabIndex = 17;
            this.buttonClose.Text = "&Close";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelScanHeading
            // 
            this.labelScanHeading.AutoSize = true;
            // 
            // 
            // 
            this.labelScanHeading.BackgroundStyle.Class = "";
            this.labelScanHeading.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelScanHeading.Location = new System.Drawing.Point(14, 14);
            this.labelScanHeading.Name = "labelScanHeading";
            this.labelScanHeading.Size = new System.Drawing.Size(70, 15);
            this.labelScanHeading.TabIndex = 2;
            this.labelScanHeading.Text = "Scan Results:";
            // 
            // buttonCancelScan
            // 
            this.buttonCancelScan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCancelScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelScan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCancelScan.Location = new System.Drawing.Point(831, 4);
            this.buttonCancelScan.Name = "buttonCancelScan";
            this.buttonCancelScan.Size = new System.Drawing.Size(66, 18);
            this.buttonCancelScan.TabIndex = 4;
            this.buttonCancelScan.Text = "&Stop Scan";
            this.buttonCancelScan.Click += new System.EventHandler(this.buttonCancelScan_Click);
            // 
            // listServers
            // 
            this.listServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.listServers.Border.Class = "ListViewBorder";
            this.listServers.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSQLServer,
            this.columnIP,
            this.columnComputer,
            this.columnVersion,
            this.columnResolution,
            this.colClustered,
            this.colPort,
            this.colService,
            this.colSSNetLib});
            this.listServers.ContextMenuStrip = this.contextMenuStrip1;
            this.listServers.FullRowSelect = true;
            this.listServers.Location = new System.Drawing.Point(13, 31);
            this.listServers.Name = "listServers";
            this.listServers.ShowGroups = false;
            this.listServers.Size = new System.Drawing.Size(884, 203);
            this.listServers.TabIndex = 0;
            this.listServers.UseCompatibleStateImageBehavior = false;
            this.listServers.View = System.Windows.Forms.View.Details;
            this.listServers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listResults_ColumnClick);
            this.listServers.SelectedIndexChanged += new System.EventHandler(this.listServers_SelectedIndexChanged);
            // 
            // columnSQLServer
            // 
            this.columnSQLServer.Text = "SQL Server";
            this.columnSQLServer.Width = 214;
            // 
            // columnIP
            // 
            this.columnIP.Text = "IP";
            this.columnIP.Width = 104;
            // 
            // columnComputer
            // 
            this.columnComputer.Text = "Computer";
            this.columnComputer.Width = 131;
            // 
            // columnVersion
            // 
            this.columnVersion.Text = "Version";
            this.columnVersion.Width = 118;
            // 
            // columnResolution
            // 
            this.columnResolution.Text = "Detected by Probes";
            this.columnResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnResolution.Width = 160;
            // 
            // colClustered
            // 
            this.colClustered.Text = "Clustered";
            this.colClustered.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colClustered.Width = 61;
            // 
            // colPort
            // 
            this.colPort.Text = "Port";
            this.colPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colService
            // 
            this.colService.Text = "Service Account";
            this.colService.Width = 150;
            // 
            // colSSNetLib
            // 
            this.colSSNetLib.Text = "SSNetLibVersion";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuSaveAsServerGroup,
            this.toolStripMenuItem6,
            this.contextMenuCopy,
            this.contextMenuSelectAll,
            this.toolStripMenuItem7,
            this.contextMenuExport});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(184, 104);
            // 
            // contextMenuSaveAsServerGroup
            // 
            this.contextMenuSaveAsServerGroup.Enabled = false;
            this.contextMenuSaveAsServerGroup.Name = "contextMenuSaveAsServerGroup";
            this.contextMenuSaveAsServerGroup.Size = new System.Drawing.Size(183, 22);
            this.contextMenuSaveAsServerGroup.Text = "Save as Server Group";
            this.contextMenuSaveAsServerGroup.Click += new System.EventHandler(this.contextMenuSaveAsServerGroup_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(180, 6);
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.Enabled = false;
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.contextMenuCopy.Size = new System.Drawing.Size(183, 22);
            this.contextMenuCopy.Text = "Copy";
            this.contextMenuCopy.Click += new System.EventHandler(this.contextMenuCopy_Click);
            // 
            // contextMenuSelectAll
            // 
            this.contextMenuSelectAll.Enabled = false;
            this.contextMenuSelectAll.Name = "contextMenuSelectAll";
            this.contextMenuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.contextMenuSelectAll.Size = new System.Drawing.Size(183, 22);
            this.contextMenuSelectAll.Text = "Select &All";
            this.contextMenuSelectAll.Click += new System.EventHandler(this.contextMenuSelectAll_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(180, 6);
            // 
            // contextMenuExport
            // 
            this.contextMenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextExportAsCSV,
            this.contextExportAsXML});
            this.contextMenuExport.Enabled = false;
            this.contextMenuExport.Name = "contextMenuExport";
            this.contextMenuExport.Size = new System.Drawing.Size(183, 22);
            this.contextMenuExport.Text = "Save &Results As";
            // 
            // contextExportAsCSV
            // 
            this.contextExportAsCSV.Name = "contextExportAsCSV";
            this.contextExportAsCSV.Size = new System.Drawing.Size(258, 22);
            this.contextExportAsCSV.Text = "CSV File (comma separated values)";
            this.contextExportAsCSV.Click += new System.EventHandler(this.contextExportAsCSV_Click);
            // 
            // contextExportAsXML
            // 
            this.contextExportAsXML.Name = "contextExportAsXML";
            this.contextExportAsXML.Size = new System.Drawing.Size(258, 22);
            this.contextExportAsXML.Text = "&XML File";
            this.contextExportAsXML.Click += new System.EventHandler(this.contextExportAsXML_Click);
            // 
            // progressBarScanning
            // 
            this.progressBarScanning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.progressBarScanning.BackgroundStyle.Class = "";
            this.progressBarScanning.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarScanning.Location = new System.Drawing.Point(443, 4);
            this.progressBarScanning.MarqueeAnimationSpeed = 50;
            this.progressBarScanning.Name = "progressBarScanning";
            this.progressBarScanning.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
            this.progressBarScanning.Size = new System.Drawing.Size(382, 18);
            this.progressBarScanning.TabIndex = 3;
            this.progressBarScanning.TextVisible = true;
            // 
            // groupDetails
            // 
            this.groupDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupDetails.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupDetails.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupDetails.Controls.Add(this.textDetails_IsClustered);
            this.groupDetails.Controls.Add(this.textDetails_Port);
            this.groupDetails.Controls.Add(this.textDetails_ServiceAccount);
            this.groupDetails.Controls.Add(this.textDetails_BaseVersion);
            this.groupDetails.Controls.Add(this.textDetails_SSNetLibVersion);
            this.groupDetails.Controls.Add(this.textDetails_Computer);
            this.groupDetails.Controls.Add(this.textDetails_IP);
            this.groupDetails.Controls.Add(this.labelX33);
            this.groupDetails.Controls.Add(this.labelX35);
            this.groupDetails.Controls.Add(this.labelX37);
            this.groupDetails.Controls.Add(this.labelX23);
            this.groupDetails.Controls.Add(this.labelX25);
            this.groupDetails.Controls.Add(this.labelX17);
            this.groupDetails.Controls.Add(this.labelX14);
            this.groupDetails.Controls.Add(this.listViewDetails);
            this.groupDetails.IsShadowEnabled = true;
            this.groupDetails.Location = new System.Drawing.Point(13, 240);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(884, 168);
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
            this.groupDetails.TabIndex = 1;
            this.groupDetails.Text = "Details for SQL Server: MERICKSONL2";
            // 
            // textDetails_IsClustered
            // 
            // 
            // 
            // 
            this.textDetails_IsClustered.Border.Class = "TextBoxBorder";
            this.textDetails_IsClustered.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textDetails_IsClustered.Location = new System.Drawing.Point(503, 4);
            this.textDetails_IsClustered.Name = "textDetails_IsClustered";
            this.textDetails_IsClustered.ReadOnly = true;
            this.textDetails_IsClustered.Size = new System.Drawing.Size(45, 20);
            this.textDetails_IsClustered.TabIndex = 26;
            this.textDetails_IsClustered.Text = "Yes";
            // 
            // textDetails_Port
            // 
            // 
            // 
            // 
            this.textDetails_Port.Border.Class = "TextBoxBorder";
            this.textDetails_Port.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textDetails_Port.Location = new System.Drawing.Point(503, 27);
            this.textDetails_Port.Name = "textDetails_Port";
            this.textDetails_Port.ReadOnly = true;
            this.textDetails_Port.Size = new System.Drawing.Size(45, 20);
            this.textDetails_Port.TabIndex = 25;
            this.textDetails_Port.Text = "14234";
            // 
            // textDetails_ServiceAccount
            // 
            // 
            // 
            // 
            this.textDetails_ServiceAccount.Border.Class = "TextBoxBorder";
            this.textDetails_ServiceAccount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textDetails_ServiceAccount.Location = new System.Drawing.Point(666, 4);
            this.textDetails_ServiceAccount.Name = "textDetails_ServiceAccount";
            this.textDetails_ServiceAccount.ReadOnly = true;
            this.textDetails_ServiceAccount.Size = new System.Drawing.Size(205, 20);
            this.textDetails_ServiceAccount.TabIndex = 24;
            this.textDetails_ServiceAccount.Text = "redhouse.hq\\merickson";
            // 
            // textDetails_BaseVersion
            // 
            // 
            // 
            // 
            this.textDetails_BaseVersion.Border.Class = "TextBoxBorder";
            this.textDetails_BaseVersion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textDetails_BaseVersion.Location = new System.Drawing.Point(328, 4);
            this.textDetails_BaseVersion.Name = "textDetails_BaseVersion";
            this.textDetails_BaseVersion.ReadOnly = true;
            this.textDetails_BaseVersion.Size = new System.Drawing.Size(75, 20);
            this.textDetails_BaseVersion.TabIndex = 22;
            this.textDetails_BaseVersion.Text = "9.0.1202.123";
            // 
            // textDetails_SSNetLibVersion
            // 
            // 
            // 
            // 
            this.textDetails_SSNetLibVersion.Border.Class = "TextBoxBorder";
            this.textDetails_SSNetLibVersion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textDetails_SSNetLibVersion.Location = new System.Drawing.Point(328, 27);
            this.textDetails_SSNetLibVersion.Name = "textDetails_SSNetLibVersion";
            this.textDetails_SSNetLibVersion.ReadOnly = true;
            this.textDetails_SSNetLibVersion.Size = new System.Drawing.Size(75, 20);
            this.textDetails_SSNetLibVersion.TabIndex = 21;
            this.textDetails_SSNetLibVersion.Text = "9.0.12024";
            // 
            // textDetails_Computer
            // 
            // 
            // 
            // 
            this.textDetails_Computer.Border.Class = "TextBoxBorder";
            this.textDetails_Computer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textDetails_Computer.Location = new System.Drawing.Point(76, 27);
            this.textDetails_Computer.Name = "textDetails_Computer";
            this.textDetails_Computer.ReadOnly = true;
            this.textDetails_Computer.Size = new System.Drawing.Size(147, 20);
            this.textDetails_Computer.TabIndex = 20;
            this.textDetails_Computer.Text = "255.255.255.0";
            // 
            // textDetails_IP
            // 
            // 
            // 
            // 
            this.textDetails_IP.Border.Class = "TextBoxBorder";
            this.textDetails_IP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textDetails_IP.Location = new System.Drawing.Point(76, 4);
            this.textDetails_IP.Name = "textDetails_IP";
            this.textDetails_IP.ReadOnly = true;
            this.textDetails_IP.Size = new System.Drawing.Size(94, 20);
            this.textDetails_IP.TabIndex = 19;
            this.textDetails_IP.Text = "255.255.255.255";
            // 
            // labelX33
            // 
            this.labelX33.AutoSize = true;
            this.labelX33.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX33.BackgroundStyle.Class = "";
            this.labelX33.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX33.Location = new System.Drawing.Point(575, 7);
            this.labelX33.Name = "labelX33";
            this.labelX33.Size = new System.Drawing.Size(85, 15);
            this.labelX33.TabIndex = 16;
            this.labelX33.Text = "Service Account:";
            // 
            // labelX35
            // 
            this.labelX35.AutoSize = true;
            this.labelX35.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX35.BackgroundStyle.Class = "";
            this.labelX35.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX35.Location = new System.Drawing.Point(427, 7);
            this.labelX35.Name = "labelX35";
            this.labelX35.Size = new System.Drawing.Size(67, 15);
            this.labelX35.TabIndex = 14;
            this.labelX35.Text = "Is Clustered?";
            // 
            // labelX37
            // 
            this.labelX37.AutoSize = true;
            this.labelX37.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX37.BackgroundStyle.Class = "";
            this.labelX37.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX37.Location = new System.Drawing.Point(237, 29);
            this.labelX37.Name = "labelX37";
            this.labelX37.Size = new System.Drawing.Size(89, 15);
            this.labelX37.TabIndex = 12;
            this.labelX37.Text = "SSNetLibVersion:";
            // 
            // labelX23
            // 
            this.labelX23.AutoSize = true;
            this.labelX23.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX23.BackgroundStyle.Class = "";
            this.labelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX23.Location = new System.Drawing.Point(237, 7);
            this.labelX23.Name = "labelX23";
            this.labelX23.Size = new System.Drawing.Size(43, 15);
            this.labelX23.TabIndex = 8;
            this.labelX23.Text = "Version:";
            // 
            // labelX25
            // 
            this.labelX25.AutoSize = true;
            this.labelX25.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX25.BackgroundStyle.Class = "";
            this.labelX25.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX25.Location = new System.Drawing.Point(427, 29);
            this.labelX25.Name = "labelX25";
            this.labelX25.Size = new System.Drawing.Size(49, 15);
            this.labelX25.TabIndex = 6;
            this.labelX25.Text = "TCP port:";
            // 
            // labelX17
            // 
            this.labelX17.AutoSize = true;
            this.labelX17.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX17.BackgroundStyle.Class = "";
            this.labelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX17.Location = new System.Drawing.Point(10, 29);
            this.labelX17.Name = "labelX17";
            this.labelX17.Size = new System.Drawing.Size(54, 15);
            this.labelX17.TabIndex = 2;
            this.labelX17.Text = "Computer:";
            // 
            // labelX14
            // 
            this.labelX14.AutoSize = true;
            this.labelX14.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.Class = "";
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(11, 7);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(59, 15);
            this.labelX14.TabIndex = 0;
            this.labelX14.Text = "IP Address:";
            // 
            // listViewDetails
            // 
            this.listViewDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.listViewDetails.Border.Class = "ListViewBorder";
            this.listViewDetails.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDetails.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.listViewDetails.Location = new System.Drawing.Point(9, 50);
            this.listViewDetails.Name = "listViewDetails";
            this.listViewDetails.Size = new System.Drawing.Size(862, 95);
            this.listViewDetails.TabIndex = 18;
            this.listViewDetails.UseCompatibleStateImageBehavior = false;
            this.listViewDetails.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Probe";
            this.columnHeader1.Width = 49;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Probe details";
            this.columnHeader2.Width = 799;
            // 
            // labelNoServersFound
            // 
            this.labelNoServersFound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNoServersFound.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelNoServersFound.BackgroundStyle.Class = "";
            this.labelNoServersFound.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelNoServersFound.ForeColor = System.Drawing.Color.Red;
            this.labelNoServersFound.Location = new System.Drawing.Point(25, 71);
            this.labelNoServersFound.Name = "labelNoServersFound";
            this.labelNoServersFound.Size = new System.Drawing.Size(862, 13);
            this.labelNoServersFound.TabIndex = 16;
            this.labelNoServersFound.Text = "No SQL Servers found";
            this.labelNoServersFound.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelNoServersFound.Visible = false;
            // 
            // wizard
            // 
            this.wizard.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.wizard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(229)))), ((int)(((byte)(253)))));
            this.wizard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("wizard.BackgroundImage")));
            this.wizard.ButtonStyle = DevComponents.DotNetBar.eWizardStyle.Office2007;
            this.wizard.Cursor = System.Windows.Forms.Cursors.Default;
            this.wizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard.FinishButtonAlwaysVisible = true;
            this.wizard.FinishButtonTabIndex = 3;
            // 
            // 
            // 
            this.wizard.FooterStyle.BackColor = System.Drawing.Color.Transparent;
            this.wizard.FooterStyle.Class = "";
            this.wizard.FooterStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.wizard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(57)))), ((int)(((byte)(129)))));
            this.wizard.HeaderCaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizard.HeaderImageVisible = false;
            // 
            // 
            // 
            this.wizard.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.wizard.HeaderStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.wizard.HeaderStyle.BackColorGradientAngle = 90;
            this.wizard.HeaderStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.wizard.HeaderStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(157)))), ((int)(((byte)(182)))));
            this.wizard.HeaderStyle.BorderBottomWidth = 1;
            this.wizard.HeaderStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.wizard.HeaderStyle.BorderLeftWidth = 1;
            this.wizard.HeaderStyle.BorderRightWidth = 1;
            this.wizard.HeaderStyle.BorderTopWidth = 1;
            this.wizard.HeaderStyle.Class = "";
            this.wizard.HeaderStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.wizard.HeaderStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.wizard.HeaderStyle.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.wizard.HelpButtonVisible = false;
            this.wizard.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.wizard.Location = new System.Drawing.Point(6, 6);
            this.wizard.Name = "wizard";
            this.wizard.Size = new System.Drawing.Size(902, 441);
            this.wizard.TabIndex = 0;
            this.wizard.WizardPages.AddRange(new DevComponents.DotNetBar.WizardPage[] {
            this.pageWelcome,
            this.pageSelectScanType,
            this.pageSelectSqlServers,
            this.pageSelectComputers,
            this.pageSelectIpRange,
            this.pageOptions_ActiveScan,
            this.pageOptions_StealthScan});
            this.wizard.FinishButtonClick += new System.ComponentModel.CancelEventHandler(this.wizard_FinishButtonClick);
            this.wizard.CancelButtonClick += new System.ComponentModel.CancelEventHandler(this.wizard_CancelButtonClick);
            this.wizard.WizardPageChanging += new DevComponents.DotNetBar.WizardCancelPageChangeEventHandler(this.wizard_WizardPageChanging);
            this.wizard.WizardPageChanged += new DevComponents.DotNetBar.WizardPageChangeEventHandler(this.wizard_WizardPageChanged);
            // 
            // pageWelcome
            // 
            this.pageWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageWelcome.BackColor = System.Drawing.Color.Transparent;
            this.pageWelcome.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pageWelcome.Controls.Add(this.reflectionImage1);
            this.pageWelcome.Controls.Add(this.label1);
            this.pageWelcome.Controls.Add(this.label2);
            this.pageWelcome.Controls.Add(this.label3);
            this.pageWelcome.FinishButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.False;
            this.pageWelcome.InteriorPage = false;
            this.pageWelcome.Location = new System.Drawing.Point(0, 0);
            this.pageWelcome.Name = "pageWelcome";
            this.pageWelcome.Size = new System.Drawing.Size(902, 395);
            // 
            // 
            // 
            this.pageWelcome.Style.Class = "";
            this.pageWelcome.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageWelcome.StyleMouseDown.Class = "";
            this.pageWelcome.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageWelcome.StyleMouseOver.Class = "";
            this.pageWelcome.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pageWelcome.TabIndex = 7;
            // 
            // reflectionImage1
            // 
            // 
            // 
            // 
            this.reflectionImage1.BackgroundStyle.Class = "";
            this.reflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.reflectionImage1.Image = ((System.Drawing.Image)(resources.GetObject("reflectionImage1.Image")));
            this.reflectionImage1.Location = new System.Drawing.Point(6, 18);
            this.reflectionImage1.Name = "reflectionImage1";
            this.reflectionImage1.Size = new System.Drawing.Size(183, 321);
            this.reflectionImage1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label1.Location = new System.Drawing.Point(210, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(678, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Idera SQL discovery";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(210, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(677, 263);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(210, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "To continue, click Next.";
            // 
            // pageSelectScanType
            // 
            this.pageSelectScanType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageSelectScanType.AntiAlias = false;
            this.pageSelectScanType.BackColor = System.Drawing.Color.Transparent;
            this.pageSelectScanType.Controls.Add(this.labelX8);
            this.pageSelectScanType.Controls.Add(this.radioScanType_Ip);
            this.pageSelectScanType.Controls.Add(this.radioScanType_Computers);
            this.pageSelectScanType.Controls.Add(this.radioScanType_SqlServers);
            this.pageSelectScanType.Controls.Add(this.labelScanTypeSQLServers);
            this.pageSelectScanType.Controls.Add(this.labelX9);
            this.pageSelectScanType.Controls.Add(this.radioScanType_Stealth);
            this.pageSelectScanType.Controls.Add(this.labelX1);
            this.pageSelectScanType.Controls.Add(this.labelServerGroup);
            this.pageSelectScanType.Controls.Add(this.labelScanTypeComputers);
            this.pageSelectScanType.FinishButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.False;
            this.pageSelectScanType.Location = new System.Drawing.Point(7, 72);
            this.pageSelectScanType.Name = "pageSelectScanType";
            this.pageSelectScanType.PageDescription = "Specify the type of scan to use to discover SQL Server instances.";
            this.pageSelectScanType.PageTitle = "Select Scan Type";
            this.pageSelectScanType.Size = new System.Drawing.Size(888, 311);
            // 
            // 
            // 
            this.pageSelectScanType.Style.Class = "";
            this.pageSelectScanType.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageSelectScanType.StyleMouseDown.Class = "";
            this.pageSelectScanType.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageSelectScanType.StyleMouseOver.Class = "";
            this.pageSelectScanType.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pageSelectScanType.TabIndex = 10;
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(83, 28);
            this.labelX8.Name = "labelX8";
            this.labelX8.TabIndex = 0;
            this.labelX8.Text = "Discover SQL Servers using Active Probe Techniques (Port Scans, WMI, etc):";
            // 
            // radioScanType_Ip
            // 
            // 
            // 
            // 
            this.radioScanType_Ip.BackgroundStyle.Class = "";
            this.radioScanType_Ip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioScanType_Ip.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioScanType_Ip.Checked = true;
            this.radioScanType_Ip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioScanType_Ip.CheckValue = "Y";
            this.radioScanType_Ip.Location = new System.Drawing.Point(91, 53);
            this.radioScanType_Ip.Name = "radioScanType_Ip";
            this.radioScanType_Ip.Size = new System.Drawing.Size(102, 15);
            this.radioScanType_Ip.TabIndex = 1;
            this.radioScanType_Ip.Text = "IP Range";
            // 
            // radioScanType_Computers
            // 
            // 
            // 
            // 
            this.radioScanType_Computers.BackgroundStyle.Class = "";
            this.radioScanType_Computers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioScanType_Computers.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioScanType_Computers.Location = new System.Drawing.Point(91, 119);
            this.radioScanType_Computers.Name = "radioScanType_Computers";
            this.radioScanType_Computers.Size = new System.Drawing.Size(102, 15);
            this.radioScanType_Computers.TabIndex = 5;
            this.radioScanType_Computers.Text = "Computer(s)";
            // 
            // radioScanType_SqlServers
            // 
            // 
            // 
            // 
            this.radioScanType_SqlServers.BackgroundStyle.Class = "";
            this.radioScanType_SqlServers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioScanType_SqlServers.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioScanType_SqlServers.Location = new System.Drawing.Point(91, 86);
            this.radioScanType_SqlServers.Name = "radioScanType_SqlServers";
            this.radioScanType_SqlServers.Size = new System.Drawing.Size(95, 15);
            this.radioScanType_SqlServers.TabIndex = 3;
            this.radioScanType_SqlServers.Text = "SQL Server(s)";
            // 
            // labelScanTypeSQLServers
            // 
            this.labelScanTypeSQLServers.AutoSize = true;
            // 
            // 
            // 
            this.labelScanTypeSQLServers.BackgroundStyle.Class = "";
            this.labelScanTypeSQLServers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelScanTypeSQLServers.Location = new System.Drawing.Point(199, 88);
            this.labelScanTypeSQLServers.Name = "labelScanTypeSQLServers";
            this.labelScanTypeSQLServers.TabIndex = 4;
            this.labelScanTypeSQLServers.Text = "Scan the computers hosting specified SQL Servers.";
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(83, 170);
            this.labelX9.Name = "labelX9";
            this.labelX9.TabIndex = 7;
            this.labelX9.Text = "Discover SQL Servers using Stealth Probe Techniques:";
            // 
            // radioScanType_Stealth
            // 
            // 
            // 
            // 
            this.radioScanType_Stealth.BackgroundStyle.Class = "";
            this.radioScanType_Stealth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioScanType_Stealth.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioScanType_Stealth.Location = new System.Drawing.Point(91, 193);
            this.radioScanType_Stealth.Name = "radioScanType_Stealth";
            this.radioScanType_Stealth.Size = new System.Drawing.Size(95, 15);
            this.radioScanType_Stealth.TabIndex = 8;
            this.radioScanType_Stealth.Text = "Stealth Mode";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(199, 55);
            this.labelX1.Name = "labelX1";
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "Scan a set of computers specified by IP addresses.";
            // 
            // labelServerGroup
            // 
            this.labelServerGroup.AutoSize = true;
            // 
            // 
            // 
            this.labelServerGroup.BackgroundStyle.Class = "";
            this.labelServerGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServerGroup.Location = new System.Drawing.Point(199, 195);
            this.labelServerGroup.Name = "labelServerGroup";
            this.labelServerGroup.TabIndex = 9;
            this.labelServerGroup.Text = "Scan for SQL Servers registered with the browser service or in Active Directory";
            // 
            // labelScanTypeComputers
            // 
            this.labelScanTypeComputers.AutoSize = true;
            // 
            // 
            // 
            this.labelScanTypeComputers.BackgroundStyle.Class = "";
            this.labelScanTypeComputers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelScanTypeComputers.Location = new System.Drawing.Point(199, 121);
            this.labelScanTypeComputers.Name = "labelScanTypeComputers";
            this.labelScanTypeComputers.TabIndex = 6;
            this.labelScanTypeComputers.Text = "Scan a list of computers.";
            // 
            // pageSelectSqlServers
            // 
            this.pageSelectSqlServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageSelectSqlServers.AntiAlias = false;
            this.pageSelectSqlServers.BackColor = System.Drawing.Color.Transparent;
            this.pageSelectSqlServers.Controls.Add(this.textServer);
            this.pageSelectSqlServers.Controls.Add(this.radioSelectServers);
            this.pageSelectSqlServers.Controls.Add(this.buttonBrowseGroups);
            this.pageSelectSqlServers.Controls.Add(this.textServerGroup);
            this.pageSelectSqlServers.Controls.Add(this.buttonBrowseServer);
            this.pageSelectSqlServers.Controls.Add(this.radioSelectGroups);
            this.pageSelectSqlServers.Controls.Add(this.labelX4);
            this.pageSelectSqlServers.FinishButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.True;
            this.pageSelectSqlServers.Location = new System.Drawing.Point(7, 72);
            this.pageSelectSqlServers.Name = "pageSelectSqlServers";
            this.pageSelectSqlServers.NextButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.True;
            this.pageSelectSqlServers.NextButtonVisible = DevComponents.DotNetBar.eWizardButtonState.True;
            this.pageSelectSqlServers.PageDescription = "Specify SQL Servers whose host computers you wish to scan for SQL Server instance" +
    "s.";
            this.pageSelectSqlServers.PageTitle = "Select SQL Servers";
            this.pageSelectSqlServers.Size = new System.Drawing.Size(888, 311);
            // 
            // 
            // 
            this.pageSelectSqlServers.Style.Class = "";
            this.pageSelectSqlServers.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageSelectSqlServers.StyleMouseDown.Class = "";
            this.pageSelectSqlServers.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageSelectSqlServers.StyleMouseOver.Class = "";
            this.pageSelectSqlServers.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pageSelectSqlServers.TabIndex = 20;
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
            this.textServer.Location = new System.Drawing.Point(192, 53);
            this.textServer.Multiline = true;
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(415, 20);
            this.textServer.TabIndex = 13;
            this.textServer.Text = "(local)";
            this.textServer.WatermarkText = "SQL Server(s); Separate servers by semi-colons";
            // 
            // radioSelectServers
            // 
            this.radioSelectServers.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioSelectServers.BackgroundStyle.Class = "";
            this.radioSelectServers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioSelectServers.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioSelectServers.Checked = true;
            this.radioSelectServers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioSelectServers.CheckValue = "Y";
            this.radioSelectServers.Location = new System.Drawing.Point(91, 53);
            this.radioSelectServers.Name = "radioSelectServers";
            this.radioSelectServers.Size = new System.Drawing.Size(95, 18);
            this.radioSelectServers.TabIndex = 12;
            this.radioSelectServers.Text = "&SQL Server(s):";
            this.radioSelectServers.CheckedChanged += new System.EventHandler(this.radioSelectServers_CheckedChanged);
            // 
            // buttonBrowseGroups
            // 
            this.buttonBrowseGroups.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseGroups.BackColor = System.Drawing.Color.White;
            this.buttonBrowseGroups.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseGroups.Location = new System.Drawing.Point(611, 87);
            this.buttonBrowseGroups.Name = "buttonBrowseGroups";
            this.buttonBrowseGroups.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseGroups.TabIndex = 18;
            this.buttonBrowseGroups.Text = "...";
            this.buttonBrowseGroups.Click += new System.EventHandler(this.buttonBrowseGroups_Click);
            // 
            // textServerGroup
            // 
            // 
            // 
            // 
            this.textServerGroup.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textServerGroup.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textServerGroup.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textServerGroup.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textServerGroup.Border.Class = "TextBoxBorder";
            this.textServerGroup.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textServerGroup.Location = new System.Drawing.Point(192, 87);
            this.textServerGroup.Name = "textServerGroup";
            this.textServerGroup.ReadOnly = true;
            this.textServerGroup.Size = new System.Drawing.Size(415, 20);
            this.textServerGroup.TabIndex = 17;
            this.textServerGroup.WatermarkText = "Browse to select a Server Group";
            // 
            // buttonBrowseServer
            // 
            this.buttonBrowseServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseServer.BackColor = System.Drawing.Color.White;
            this.buttonBrowseServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseServer.Location = new System.Drawing.Point(611, 53);
            this.buttonBrowseServer.Name = "buttonBrowseServer";
            this.buttonBrowseServer.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseServer.TabIndex = 14;
            this.buttonBrowseServer.Text = "...";
            this.buttonBrowseServer.Click += new System.EventHandler(this.buttonBrowseServer_Click);
            // 
            // radioSelectGroups
            // 
            this.radioSelectGroups.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioSelectGroups.BackgroundStyle.Class = "";
            this.radioSelectGroups.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioSelectGroups.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioSelectGroups.Location = new System.Drawing.Point(91, 86);
            this.radioSelectGroups.Name = "radioSelectGroups";
            this.radioSelectGroups.Size = new System.Drawing.Size(95, 18);
            this.radioSelectGroups.TabIndex = 16;
            this.radioSelectGroups.Text = "Server &Group:";
            this.radioSelectGroups.CheckedChanged += new System.EventHandler(this.radioSelectGroups_CheckedChanged);
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(83, 28);
            this.labelX4.Name = "labelX4";
            this.labelX4.TabIndex = 11;
            this.labelX4.Text = "Specify the SQL Servers whose host computers you wish to scan (separate multiple " +
    "SQL Servers with semi-colons):";
            // 
            // pageSelectComputers
            // 
            this.pageSelectComputers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageSelectComputers.AntiAlias = false;
            this.pageSelectComputers.BackColor = System.Drawing.Color.Transparent;
            this.pageSelectComputers.Controls.Add(this.labelX7);
            this.pageSelectComputers.Controls.Add(this.textComputerList);
            this.pageSelectComputers.Controls.Add(this.buttonBrowseFroComputers);
            this.pageSelectComputers.Controls.Add(this.labelX5);
            this.pageSelectComputers.FinishButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.True;
            this.pageSelectComputers.Location = new System.Drawing.Point(7, 72);
            this.pageSelectComputers.Name = "pageSelectComputers";
            this.pageSelectComputers.NextButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.True;
            this.pageSelectComputers.NextButtonVisible = DevComponents.DotNetBar.eWizardButtonState.True;
            this.pageSelectComputers.PageDescription = "Specify the names of computers you wish to scan for SQL Server instances.";
            this.pageSelectComputers.PageTitle = "Select Computers";
            this.pageSelectComputers.Size = new System.Drawing.Size(888, 311);
            // 
            // 
            // 
            this.pageSelectComputers.Style.Class = "";
            this.pageSelectComputers.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageSelectComputers.StyleMouseDown.Class = "";
            this.pageSelectComputers.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageSelectComputers.StyleMouseOver.Class = "";
            this.pageSelectComputers.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pageSelectComputers.TabIndex = 21;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(91, 53);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(65, 19);
            this.labelX7.TabIndex = 23;
            this.labelX7.Text = "Computer(s):";
            // 
            // textComputerList
            // 
            // 
            // 
            // 
            this.textComputerList.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textComputerList.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textComputerList.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textComputerList.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textComputerList.Border.Class = "TextBoxBorder";
            this.textComputerList.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textComputerList.Location = new System.Drawing.Point(162, 54);
            this.textComputerList.Multiline = true;
            this.textComputerList.Name = "textComputerList";
            this.textComputerList.Size = new System.Drawing.Size(522, 20);
            this.textComputerList.TabIndex = 24;
            // 
            // buttonBrowseFroComputers
            // 
            this.buttonBrowseFroComputers.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseFroComputers.BackColor = System.Drawing.Color.White;
            this.buttonBrowseFroComputers.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseFroComputers.Location = new System.Drawing.Point(690, 54);
            this.buttonBrowseFroComputers.Name = "buttonBrowseFroComputers";
            this.buttonBrowseFroComputers.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseFroComputers.TabIndex = 25;
            this.buttonBrowseFroComputers.Text = "...";
            this.buttonBrowseFroComputers.Visible = false;
            this.buttonBrowseFroComputers.Click += new System.EventHandler(this.buttonBrowseFroComputers_Click);
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(83, 28);
            this.labelX5.Name = "labelX5";
            this.labelX5.TabIndex = 22;
            this.labelX5.Text = "Specify one or more computers to scan for SQL Servers (separate multiple computer" +
    "s with semi-colons): ";
            // 
            // pageSelectIpRange
            // 
            this.pageSelectIpRange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageSelectIpRange.AntiAlias = false;
            this.pageSelectIpRange.AutoSize = true;
            this.pageSelectIpRange.BackColor = System.Drawing.Color.Transparent;
            this.pageSelectIpRange.Controls.Add(this.buttonUnselectAll);
            this.pageSelectIpRange.Controls.Add(this.buttonSelectAll);
            this.pageSelectIpRange.Controls.Add(this.labelX2);
            this.pageSelectIpRange.Controls.Add(this.buttonSaveIpList);
            this.pageSelectIpRange.Controls.Add(this.buttonAddLocalSubnet);
            this.pageSelectIpRange.Controls.Add(this.buttonAddLocalComputer);
            this.pageSelectIpRange.Controls.Add(this.listIpAddresses);
            this.pageSelectIpRange.Controls.Add(this.buttonRemoveIpAddress);
            this.pageSelectIpRange.Controls.Add(this.buttonAddIpRange);
            this.pageSelectIpRange.Controls.Add(this.buttonLoadIpList);
            this.pageSelectIpRange.FinishButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.True;
            this.pageSelectIpRange.Location = new System.Drawing.Point(7, 72);
            this.pageSelectIpRange.Name = "pageSelectIpRange";
            this.pageSelectIpRange.NextButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.True;
            this.pageSelectIpRange.NextButtonVisible = DevComponents.DotNetBar.eWizardButtonState.True;
            this.pageSelectIpRange.PageDescription = "Specify the set of IP addresses that you wish to scan";
            this.pageSelectIpRange.PageTitle = "Select IP Addresses";
            this.pageSelectIpRange.Size = new System.Drawing.Size(888, 311);
            // 
            // 
            // 
            this.pageSelectIpRange.Style.Class = "";
            this.pageSelectIpRange.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageSelectIpRange.StyleMouseDown.Class = "";
            this.pageSelectIpRange.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageSelectIpRange.StyleMouseOver.Class = "";
            this.pageSelectIpRange.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pageSelectIpRange.TabIndex = 26;
            // 
            // buttonUnselectAll
            // 
            this.buttonUnselectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonUnselectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonUnselectAll.Enabled = false;
            this.buttonUnselectAll.Location = new System.Drawing.Point(222, 283);
            this.buttonUnselectAll.Name = "buttonUnselectAll";
            this.buttonUnselectAll.Size = new System.Drawing.Size(82, 20);
            this.buttonUnselectAll.TabIndex = 39;
            this.buttonUnselectAll.Text = "Unselect All";
            this.buttonUnselectAll.Click += new System.EventHandler(this.buttonUnselectAll_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSelectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSelectAll.Enabled = false;
            this.buttonSelectAll.Location = new System.Drawing.Point(134, 283);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(82, 20);
            this.buttonSelectAll.TabIndex = 38;
            this.buttonSelectAll.Text = "Select All";
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(83, 28);
            this.labelX2.Name = "labelX2";
            this.labelX2.TabIndex = 30;
            this.labelX2.Text = "Specify one or more IP addresses or ranges to scan:";
            // 
            // buttonSaveIpList
            // 
            this.buttonSaveIpList.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSaveIpList.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSaveIpList.Enabled = false;
            this.buttonSaveIpList.Location = new System.Drawing.Point(351, 173);
            this.buttonSaveIpList.Name = "buttonSaveIpList";
            this.buttonSaveIpList.Size = new System.Drawing.Size(123, 20);
            this.buttonSaveIpList.TabIndex = 36;
            this.buttonSaveIpList.Text = "Save IP List to File";
            this.buttonSaveIpList.Click += new System.EventHandler(this.buttonSaveIpList_Click);
            // 
            // buttonAddLocalSubnet
            // 
            this.buttonAddLocalSubnet.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAddLocalSubnet.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonAddLocalSubnet.Location = new System.Drawing.Point(351, 102);
            this.buttonAddLocalSubnet.Name = "buttonAddLocalSubnet";
            this.buttonAddLocalSubnet.Size = new System.Drawing.Size(123, 20);
            this.buttonAddLocalSubnet.TabIndex = 34;
            this.buttonAddLocalSubnet.Text = "Add Local Subnet";
            this.buttonAddLocalSubnet.Click += new System.EventHandler(this.buttonAddLocalSubnet_Click);
            // 
            // buttonAddLocalComputer
            // 
            this.buttonAddLocalComputer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAddLocalComputer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonAddLocalComputer.Location = new System.Drawing.Point(351, 75);
            this.buttonAddLocalComputer.Name = "buttonAddLocalComputer";
            this.buttonAddLocalComputer.Size = new System.Drawing.Size(123, 20);
            this.buttonAddLocalComputer.TabIndex = 33;
            this.buttonAddLocalComputer.Text = "Add Local IP Address";
            this.buttonAddLocalComputer.Click += new System.EventHandler(this.buttonAddLocalComputer_Click);
            // 
            // listIpAddresses
            // 
            // 
            // 
            // 
            this.listIpAddresses.Border.Class = "ListViewBorder";
            this.listIpAddresses.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listIpAddresses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listIpAddresses.Location = new System.Drawing.Point(83, 48);
            this.listIpAddresses.Name = "listIpAddresses";
            this.listIpAddresses.Size = new System.Drawing.Size(262, 229);
            this.listIpAddresses.TabIndex = 31;
            this.listIpAddresses.UseCompatibleStateImageBehavior = false;
            this.listIpAddresses.View = System.Windows.Forms.View.List;
            this.listIpAddresses.SelectedIndexChanged += new System.EventHandler(this.listIpAddresses_SelectedIndexChanged);
            // 
            // buttonRemoveIpAddress
            // 
            this.buttonRemoveIpAddress.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonRemoveIpAddress.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonRemoveIpAddress.Enabled = false;
            this.buttonRemoveIpAddress.Location = new System.Drawing.Point(351, 257);
            this.buttonRemoveIpAddress.Name = "buttonRemoveIpAddress";
            this.buttonRemoveIpAddress.Size = new System.Drawing.Size(123, 20);
            this.buttonRemoveIpAddress.TabIndex = 37;
            this.buttonRemoveIpAddress.Text = "Remove";
            this.buttonRemoveIpAddress.Click += new System.EventHandler(this.buttonRemoveIpAddress_Click);
            // 
            // buttonAddIpRange
            // 
            this.buttonAddIpRange.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAddIpRange.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonAddIpRange.Location = new System.Drawing.Point(351, 48);
            this.buttonAddIpRange.Name = "buttonAddIpRange";
            this.buttonAddIpRange.Size = new System.Drawing.Size(123, 20);
            this.buttonAddIpRange.TabIndex = 32;
            this.buttonAddIpRange.Text = "Add IP Range";
            this.buttonAddIpRange.Click += new System.EventHandler(this.buttonAddIpRange_Click);
            // 
            // buttonLoadIpList
            // 
            this.buttonLoadIpList.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonLoadIpList.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonLoadIpList.Location = new System.Drawing.Point(351, 146);
            this.buttonLoadIpList.Name = "buttonLoadIpList";
            this.buttonLoadIpList.Size = new System.Drawing.Size(123, 20);
            this.buttonLoadIpList.TabIndex = 35;
            this.buttonLoadIpList.Text = "Load IP List from File";
            this.buttonLoadIpList.Click += new System.EventHandler(this.buttonLoadIpList_Click);
            // 
            // pageOptions_ActiveScan
            // 
            this.pageOptions_ActiveScan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageOptions_ActiveScan.AntiAlias = false;
            this.pageOptions_ActiveScan.BackColor = System.Drawing.Color.Transparent;
            this.pageOptions_ActiveScan.Controls.Add(this.labelX10);
            this.pageOptions_ActiveScan.Controls.Add(this.checkScan_SCM);
            this.pageOptions_ActiveScan.Controls.Add(this.checkScan_Reg);
            this.pageOptions_ActiveScan.Controls.Add(this.checkScan_WMI);
            this.pageOptions_ActiveScan.Controls.Add(this.checkScan_TCP);
            this.pageOptions_ActiveScan.Controls.Add(this.checkScan_UDP);
            this.pageOptions_ActiveScan.FinishButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.True;
            this.pageOptions_ActiveScan.Location = new System.Drawing.Point(7, 72);
            this.pageOptions_ActiveScan.Name = "pageOptions_ActiveScan";
            this.pageOptions_ActiveScan.NextButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.False;
            this.pageOptions_ActiveScan.PageDescription = "Specify which probes to use to discover SQL Servers";
            this.pageOptions_ActiveScan.PageTitle = "Select Probes";
            this.pageOptions_ActiveScan.Size = new System.Drawing.Size(888, 311);
            // 
            // 
            // 
            this.pageOptions_ActiveScan.Style.Class = "";
            this.pageOptions_ActiveScan.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageOptions_ActiveScan.StyleMouseDown.Class = "";
            this.pageOptions_ActiveScan.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageOptions_ActiveScan.StyleMouseOver.Class = "";
            this.pageOptions_ActiveScan.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pageOptions_ActiveScan.TabIndex = 40;
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.Class = "";
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(83, 28);
            this.labelX10.Name = "labelX10";
            this.labelX10.TabIndex = 41;
            this.labelX10.Text = "Select the type of probes you would like to employ to discover SQL Servers:";
            // 
            // checkScan_SCM
            // 
            this.checkScan_SCM.AutoSize = true;
            // 
            // 
            // 
            this.checkScan_SCM.BackgroundStyle.Class = "";
            this.checkScan_SCM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkScan_SCM.Checked = true;
            this.checkScan_SCM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkScan_SCM.CheckValue = "Y";
            this.checkScan_SCM.Location = new System.Drawing.Point(91, 185);
            this.checkScan_SCM.Name = "checkScan_SCM";
            this.checkScan_SCM.Size = new System.Drawing.Size(431, 15);
            this.checkScan_SCM.TabIndex = 46;
            this.checkScan_SCM.Text = "Service Control Manager Probe - Look for SQL Server services registered with SCM";
            // 
            // checkScan_Reg
            // 
            this.checkScan_Reg.AutoSize = true;
            // 
            // 
            // 
            this.checkScan_Reg.BackgroundStyle.Class = "";
            this.checkScan_Reg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkScan_Reg.Checked = true;
            this.checkScan_Reg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkScan_Reg.CheckValue = "Y";
            this.checkScan_Reg.Location = new System.Drawing.Point(91, 152);
            this.checkScan_Reg.Name = "checkScan_Reg";
            this.checkScan_Reg.Size = new System.Drawing.Size(431, 15);
            this.checkScan_Reg.TabIndex = 45;
            this.checkScan_Reg.Text = "Windows Registry Probe - Look in each machine\'s registry for installed SQL Server" +
    "s";
            // 
            // checkScan_WMI
            // 
            this.checkScan_WMI.AutoSize = true;
            // 
            // 
            // 
            this.checkScan_WMI.BackgroundStyle.Class = "";
            this.checkScan_WMI.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkScan_WMI.Checked = true;
            this.checkScan_WMI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkScan_WMI.CheckValue = "Y";
            this.checkScan_WMI.Location = new System.Drawing.Point(91, 119);
            this.checkScan_WMI.Name = "checkScan_WMI";
            this.checkScan_WMI.Size = new System.Drawing.Size(393, 15);
            this.checkScan_WMI.TabIndex = 44;
            this.checkScan_WMI.Text = "WMI Enumeration Probe - Use WMI to enumerate SQL Servers on each box";
            // 
            // checkScan_TCP
            // 
            this.checkScan_TCP.AutoSize = true;
            // 
            // 
            // 
            this.checkScan_TCP.BackgroundStyle.Class = "";
            this.checkScan_TCP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkScan_TCP.Checked = true;
            this.checkScan_TCP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkScan_TCP.CheckValue = "Y";
            this.checkScan_TCP.Location = new System.Drawing.Point(91, 86);
            this.checkScan_TCP.Name = "checkScan_TCP";
            this.checkScan_TCP.Size = new System.Drawing.Size(359, 15);
            this.checkScan_TCP.TabIndex = 43;
            this.checkScan_TCP.Text = "TCP Probe - Try to connect to standard SQL Server ports 1433, 2433";
            // 
            // checkScan_UDP
            // 
            this.checkScan_UDP.AutoSize = true;
            // 
            // 
            // 
            this.checkScan_UDP.BackgroundStyle.Class = "";
            this.checkScan_UDP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkScan_UDP.Checked = true;
            this.checkScan_UDP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkScan_UDP.CheckValue = "Y";
            this.checkScan_UDP.Location = new System.Drawing.Point(91, 53);
            this.checkScan_UDP.Name = "checkScan_UDP";
            this.checkScan_UDP.Size = new System.Drawing.Size(512, 15);
            this.checkScan_UDP.TabIndex = 42;
            this.checkScan_UDP.Text = "SQL Server Resolution Service Probe - Is SQL Server registered with resolution se" +
    "rvice? (Port 1434)";
            // 
            // pageOptions_StealthScan
            // 
            this.pageOptions_StealthScan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageOptions_StealthScan.AntiAlias = false;
            this.pageOptions_StealthScan.BackColor = System.Drawing.Color.Transparent;
            this.pageOptions_StealthScan.Controls.Add(this.labelX13);
            this.pageOptions_StealthScan.Controls.Add(this.checkScan_ActiveDirectory);
            this.pageOptions_StealthScan.Controls.Add(this.checkScan_BrowserService);
            this.pageOptions_StealthScan.FinishButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.True;
            this.pageOptions_StealthScan.Location = new System.Drawing.Point(7, 72);
            this.pageOptions_StealthScan.Name = "pageOptions_StealthScan";
            this.pageOptions_StealthScan.NextButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.False;
            this.pageOptions_StealthScan.PageDescription = "Specify which probes to use to discover SQL Servers";
            this.pageOptions_StealthScan.PageTitle = "Select Probes";
            this.pageOptions_StealthScan.Size = new System.Drawing.Size(888, 311);
            // 
            // 
            // 
            this.pageOptions_StealthScan.Style.Class = "";
            this.pageOptions_StealthScan.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageOptions_StealthScan.StyleMouseDown.Class = "";
            this.pageOptions_StealthScan.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageOptions_StealthScan.StyleMouseOver.Class = "";
            this.pageOptions_StealthScan.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pageOptions_StealthScan.TabIndex = 48;
            // 
            // labelX13
            // 
            this.labelX13.AutoSize = true;
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.Class = "";
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(83, 28);
            this.labelX13.Name = "labelX13";
            this.labelX13.TabIndex = 49;
            this.labelX13.Text = "Select the type of probes you would like to employ to discover SQL Servers:";
            // 
            // checkScan_ActiveDirectory
            // 
            this.checkScan_ActiveDirectory.AutoSize = true;
            // 
            // 
            // 
            this.checkScan_ActiveDirectory.BackgroundStyle.Class = "";
            this.checkScan_ActiveDirectory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkScan_ActiveDirectory.Checked = true;
            this.checkScan_ActiveDirectory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkScan_ActiveDirectory.CheckValue = "Y";
            this.checkScan_ActiveDirectory.Location = new System.Drawing.Point(91, 86);
            this.checkScan_ActiveDirectory.Name = "checkScan_ActiveDirectory";
            this.checkScan_ActiveDirectory.Size = new System.Drawing.Size(393, 15);
            this.checkScan_ActiveDirectory.TabIndex = 51;
            this.checkScan_ActiveDirectory.Text = "Active Directory Probe - Check SQL Servers registered with Active Directory";
            // 
            // checkScan_BrowserService
            // 
            this.checkScan_BrowserService.AutoSize = true;
            // 
            // 
            // 
            this.checkScan_BrowserService.BackgroundStyle.Class = "";
            this.checkScan_BrowserService.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkScan_BrowserService.Checked = true;
            this.checkScan_BrowserService.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkScan_BrowserService.CheckValue = "Y";
            this.checkScan_BrowserService.Location = new System.Drawing.Point(91, 53);
            this.checkScan_BrowserService.Name = "checkScan_BrowserService";
            this.checkScan_BrowserService.Size = new System.Drawing.Size(476, 15);
            this.checkScan_BrowserService.TabIndex = 50;
            this.checkScan_BrowserService.Text = "Browser Service Probe - Check for SQL Servers registered with the Network Browser" +
    " Service";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "check2.png");
            this.imageList1.Images.SetKeyName(1, "delete2.png");
            this.imageList1.Images.SetKeyName(2, "warning.png");
            this.imageList1.Images.SetKeyName(3, "led_yellow.png");
            this.imageList1.Images.SetKeyName(4, "led_blue.png");
            this.imageList1.Images.SetKeyName(5, "led_green.png");
            this.imageList1.Images.SetKeyName(6, "led_red.png");
            // 
            // ideraTitleBar1
            // 
            this.ideraTitleBar1.ActivateLicenseEventHandler = null;
            this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
            this.ideraTitleBar1.Close = true;
            this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
            this.ideraTitleBar1.IderaProductNameText = "SQL Discovery";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.IsFormLocked = false;
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = true;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(914, 93);
            this.ideraTitleBar1.TabIndex = 19;
            this.ideraTitleBar1.TrialMode = true;
            this.ideraTitleBar1.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar1_LicenseInfoButtonClick);
            // 
            // Form_Main
            // 
            this.AcceptButton = this.buttonDoAnotherScan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(914, 622);
            this.ControlBox = false;
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ideraTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(920, 628);
            this.Name = "Form_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Tag = "";
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelMiddle.ResumeLayout(false);
            this.panelResults.ResumeLayout(false);
            this.panelResults.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            this.wizard.ResumeLayout(false);
            this.wizard.PerformLayout();
            this.pageWelcome.ResumeLayout(false);
            this.pageSelectScanType.ResumeLayout(false);
            this.pageSelectScanType.PerformLayout();
            this.pageSelectSqlServers.ResumeLayout(false);
            this.pageSelectSqlServers.PerformLayout();
            this.pageSelectComputers.ResumeLayout(false);
            this.pageSelectComputers.PerformLayout();
            this.pageSelectIpRange.ResumeLayout(false);
            this.pageSelectIpRange.PerformLayout();
            this.pageOptions_ActiveScan.ResumeLayout(false);
            this.pageOptions_ActiveScan.PerformLayout();
            this.pageOptions_StealthScan.ResumeLayout(false);
            this.pageOptions_StealthScan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panelTop;
      private DevComponents.DotNetBar.LabelX labelTitle;
      private DevComponents.DotNetBar.LabelX labelSubtitle;
      private System.Windows.Forms.PictureBox pictureBoxTitle;
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
      private System.Windows.Forms.Panel panelMiddle;
      private DevComponents.DotNetBar.Wizard wizard;
      private DevComponents.DotNetBar.WizardPage pageWelcome;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private DevComponents.DotNetBar.WizardPage pageSelectScanType;
      private DevComponents.DotNetBar.WizardPage pageOptions_ActiveScan;
      private DevComponents.DotNetBar.Controls.ReflectionImage reflectionImage1;
      private DevComponents.DotNetBar.LabelX labelScanTypeComputers;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioScanType_Computers;
      private DevComponents.DotNetBar.LabelX labelScanTypeSQLServers;
      private DevComponents.DotNetBar.LabelX labelX1;
      private DevComponents.DotNetBar.LabelX labelServerGroup;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioScanType_Ip;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioScanType_Stealth;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioScanType_SqlServers;
      private DevComponents.DotNetBar.WizardPage pageSelectSqlServers;
      private DevComponents.DotNetBar.LabelX labelX4;
      private DevComponents.DotNetBar.WizardPage pageSelectComputers;
      private DevComponents.DotNetBar.LabelX labelX5;
      private DevComponents.DotNetBar.WizardPage pageSelectIpRange;
      private DevComponents.DotNetBar.LabelX labelX7;
      private DevComponents.DotNetBar.Controls.TextBoxX textServer;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioSelectServers;
      private DevComponents.DotNetBar.ButtonX buttonBrowseGroups;
      private DevComponents.DotNetBar.Controls.TextBoxX textServerGroup;
      private DevComponents.DotNetBar.ButtonX buttonBrowseServer;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioSelectGroups;
      private DevComponents.DotNetBar.Controls.TextBoxX textComputerList;
      private DevComponents.DotNetBar.ButtonX buttonBrowseFroComputers;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
      private System.Windows.Forms.ToolStripMenuItem menuManageServerGroups;
      private System.Windows.Forms.ToolStripMenuItem securityScannerOptionsToolStripMenuItem;
      private DevComponents.DotNetBar.LabelX labelX9;
      private DevComponents.DotNetBar.LabelX labelX8;
      private DevComponents.DotNetBar.Controls.ListViewEx listServers;
      private System.Windows.Forms.ColumnHeader columnComputer;
      private System.Windows.Forms.ColumnHeader columnIP;
      private System.Windows.Forms.ColumnHeader columnResolution;
      private DevComponents.DotNetBar.Controls.GroupPanel groupDetails;
      private System.Windows.Forms.ImageList imageList1;
      private DevComponents.DotNetBar.LabelX labelScanHeading;
      private System.Windows.Forms.ColumnHeader columnSQLServer;
      private System.Windows.Forms.ToolStripMenuItem menuEdit;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkScan_SCM;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkScan_Reg;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkScan_WMI;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkScan_TCP;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkScan_UDP;
      private DevComponents.DotNetBar.LabelX labelX10;
      private DevComponents.DotNetBar.WizardPage pageOptions_StealthScan;
      private DevComponents.DotNetBar.LabelX labelX13;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkScan_ActiveDirectory;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkScan_BrowserService;
      private DevComponents.DotNetBar.LabelX labelX23;
      private DevComponents.DotNetBar.LabelX labelX25;
      private DevComponents.DotNetBar.LabelX labelX17;
      private DevComponents.DotNetBar.LabelX labelX14;
      private DevComponents.DotNetBar.LabelX labelX33;
      private DevComponents.DotNetBar.LabelX labelX35;
      private DevComponents.DotNetBar.LabelX labelX37;
      private System.Windows.Forms.ColumnHeader columnVersion;
      private DevComponents.DotNetBar.ButtonX buttonCancelScan;
      private DevComponents.DotNetBar.Controls.ProgressBarX progressBarScanning;
      private DevComponents.DotNetBar.Controls.ListViewEx listViewDetails;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private DevComponents.DotNetBar.Controls.TextBoxX textDetails_BaseVersion;
      private DevComponents.DotNetBar.Controls.TextBoxX textDetails_SSNetLibVersion;
      private DevComponents.DotNetBar.Controls.TextBoxX textDetails_Computer;
      private DevComponents.DotNetBar.Controls.TextBoxX textDetails_IP;
      private DevComponents.DotNetBar.Controls.TextBoxX textDetails_IsClustered;
      private DevComponents.DotNetBar.Controls.TextBoxX textDetails_Port;
      private DevComponents.DotNetBar.Controls.TextBoxX textDetails_ServiceAccount;
      private DevComponents.DotNetBar.LabelX labelNoServersFound;
      private System.Windows.Forms.Panel panelResults;
      private DevComponents.DotNetBar.ButtonX buttonDoAnotherScan;
      private DevComponents.DotNetBar.ButtonX buttonClose;
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
      private System.Windows.Forms.ToolStripMenuItem contextMenuCopy;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
      private System.Windows.Forms.ToolStripMenuItem menuCopy;
      private DevComponents.DotNetBar.ButtonX buttonSaveAsServerGroup;
      private System.Windows.Forms.ToolStripMenuItem contextMenuSaveAsServerGroup;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
      private System.Windows.Forms.ToolStripMenuItem menuExport;
      private System.Windows.Forms.ToolStripMenuItem menuExportAsCSV;
      private System.Windows.Forms.ToolStripMenuItem menuExportAsXML;
      private System.Windows.Forms.ToolStripMenuItem contextMenuExport;
      private System.Windows.Forms.ToolStripMenuItem contextExportAsCSV;
      private System.Windows.Forms.ToolStripMenuItem contextExportAsXML;
      private DevComponents.DotNetBar.ButtonX buttonCopyResultsToClipboard;
      private System.Windows.Forms.ToolStripMenuItem menuSelectAll;
      private System.Windows.Forms.ToolStripMenuItem contextMenuSelectAll;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
      private System.Windows.Forms.ColumnHeader colClustered;
      private System.Windows.Forms.ColumnHeader colPort;
      private System.Windows.Forms.ColumnHeader colService;
      private System.Windows.Forms.ColumnHeader colSSNetLib;
      private DevComponents.DotNetBar.ButtonX buttonDoSameScan;
      private DevComponents.DotNetBar.ButtonX buttonRemoveIpAddress;
      private DevComponents.DotNetBar.ButtonX buttonLoadIpList;
      private DevComponents.DotNetBar.ButtonX buttonAddIpRange;
      private DevComponents.DotNetBar.Controls.ListViewEx listIpAddresses;
      private DevComponents.DotNetBar.ButtonX buttonAddLocalSubnet;
      private DevComponents.DotNetBar.ButtonX buttonAddLocalComputer;
      private DevComponents.DotNetBar.ButtonX buttonSaveIpList;
      private DevComponents.DotNetBar.LabelX labelX2;
      private DevComponents.DotNetBar.ButtonX buttonUnselectAll;
      private DevComponents.DotNetBar.ButtonX buttonSelectAll;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
    }
}

