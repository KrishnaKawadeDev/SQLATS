namespace Idera.SqlAdminToolset.JobMover
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
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
            this.WizardJobMove = new DevComponents.DotNetBar.Wizard();
            this.pageWelcome = new DevComponents.DotNetBar.WizardPage();
            this.reflectionImage2 = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pageSelectTask = new DevComponents.DotNetBar.WizardPage();
            this.optionCopyJobs = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.OptionMoveJobs = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.OptionCopyJobsLocal = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.pageServerInformation = new DevComponents.DotNetBar.WizardPage();
            this.labelSourceServer = new DevComponents.DotNetBar.LabelX();
            this.textSourceServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonBrowseSourceServer = new DevComponents.DotNetBar.ButtonX();
            this.textDestinationServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonDestinationCredentials = new DevComponents.DotNetBar.ButtonX();
            this.buttonSourceCredentials = new DevComponents.DotNetBar.ButtonX();
            this.labelDestinationServer = new DevComponents.DotNetBar.LabelX();
            this.buttonBrowseDestinationServer = new DevComponents.DotNetBar.ButtonX();
            this.pageSelectJobs = new DevComponents.DotNetBar.WizardPage();
            this.labelJobListMessage = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.linkClearAllJobs = new System.Windows.Forms.LinkLabel();
            this.linkSelectAllJobs = new System.Windows.Forms.LinkLabel();
            this.ListJobs = new System.Windows.Forms.CheckedListBox();
            this.checkBoxIncludeNotifications = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.checkboxIncludeSchedule = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.pageTargetOptions = new DevComponents.DotNetBar.WizardPage();
            this.labelDatabases = new DevComponents.DotNetBar.LabelX();
            this.checkBoxAlwaysUseOwner = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxCreateOperators = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.comboBoxDatabases = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelOwners = new DevComponents.DotNetBar.LabelX();
            this.comboBoxOwners = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.checkBoxOverwrite = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxCreateCategory = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxCreateSchedule = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelChooseEnableOrDisable = new DevComponents.DotNetBar.LabelX();
            this.linkSelectAllDisableJobs = new System.Windows.Forms.LinkLabel();
            this.linkClearAllDisableJobs = new System.Windows.Forms.LinkLabel();
            this.ListDisableJobs = new System.Windows.Forms.CheckedListBox();
            this.pageSummary = new DevComponents.DotNetBar.WizardPage();
            this.groupMoveDatabase = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.LabelSummaryOperationTypeValue = new DevComponents.DotNetBar.LabelX();
            this.LabelSummaryOperationType = new DevComponents.DotNetBar.LabelX();
            this.LabelSummaryTargetOptionsValue = new DevComponents.DotNetBar.LabelX();
            this.LabelSummarySourceOptionsValue = new DevComponents.DotNetBar.LabelX();
            this.LabelSummaryDestinationServerValue = new DevComponents.DotNetBar.LabelX();
            this.LabelSummarySourceServerValue = new DevComponents.DotNetBar.LabelX();
            this.LabelSummaryTargetOptions = new DevComponents.DotNetBar.LabelX();
            this.LabelSummarySourceOptions = new DevComponents.DotNetBar.LabelX();
            this.LabelSummaryDestinationServer = new DevComponents.DotNetBar.LabelX();
            this.LabelSummarySourceServer = new DevComponents.DotNetBar.LabelX();
            this.panelResults = new System.Windows.Forms.Panel();
            this.buttonBack = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.ProgressList = new Idera.SqlAdminToolset.Core.ToolProgressListMini();
            this.textTaskLog = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.buttonDoAnotherScan = new DevComponents.DotNetBar.ButtonX();
            this.buttonClose = new DevComponents.DotNetBar.ButtonX();
            this.labelStatus = new DevComponents.DotNetBar.LabelX();
            this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.labelSelectOperation = new DevComponents.DotNetBar.LabelX();
            this.labelSourceDes = new DevComponents.DotNetBar.LabelX();
            this.labelJobOptions = new DevComponents.DotNetBar.LabelX();
            this.labelDesOptions = new DevComponents.DotNetBar.LabelX();
            this.labelSummary = new DevComponents.DotNetBar.LabelX();
            this.checkBoxEnable = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxDisable = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.WizardJobMove.SuspendLayout();
            this.pageWelcome.SuspendLayout();
            this.pageSelectTask.SuspendLayout();
            this.pageServerInformation.SuspendLayout();
            this.pageSelectJobs.SuspendLayout();
            this.pageTargetOptions.SuspendLayout();
            this.pageSummary.SuspendLayout();
            this.groupMoveDatabase.SuspendLayout();
            this.panelResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTop.Controls.Add(this.labelSubtitle);
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Controls.Add(this.pictureBoxTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 117);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(811, 152);
            this.panelTop.TabIndex = 16;
            // 
            // labelSubtitle
            // 
            // 
            // 
            // 
            this.labelSubtitle.BackgroundStyle.Class = "";
            this.labelSubtitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.Location = new System.Drawing.Point(330, 0);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(530, 52);
            this.labelSubtitle.TabIndex = 6;
            this.labelSubtitle.Text = "Move and copy jobs between SQL Servers";
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
            this.labelTitle.Size = new System.Drawing.Size(260, 52);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Job Mover</font></b> ";
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
            this.menuTools,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 93);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(811, 24);
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
            // WizardJobMove
            // 
            this.WizardJobMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(229)))), ((int)(((byte)(253)))));
            this.WizardJobMove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("WizardJobMove.BackgroundImage")));
            this.WizardJobMove.ButtonStyle = DevComponents.DotNetBar.eWizardStyle.Office2007;
            this.WizardJobMove.Cursor = System.Windows.Forms.Cursors.Default;
            this.WizardJobMove.FinishButtonAlwaysVisible = true;
            this.WizardJobMove.FinishButtonTabIndex = 3;
            // 
            // 
            // 
            this.WizardJobMove.FooterStyle.BackColor = System.Drawing.Color.Transparent;
            this.WizardJobMove.FooterStyle.Class = "";
            this.WizardJobMove.FooterStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.WizardJobMove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(57)))), ((int)(((byte)(129)))));
            this.WizardJobMove.HeaderCaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WizardJobMove.HeaderImageVisible = false;
            // 
            // 
            // 
            this.WizardJobMove.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.WizardJobMove.HeaderStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.WizardJobMove.HeaderStyle.BackColorGradientAngle = 90;
            this.WizardJobMove.HeaderStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.WizardJobMove.HeaderStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(157)))), ((int)(((byte)(182)))));
            this.WizardJobMove.HeaderStyle.BorderBottomWidth = 1;
            this.WizardJobMove.HeaderStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.WizardJobMove.HeaderStyle.BorderLeftWidth = 1;
            this.WizardJobMove.HeaderStyle.BorderRightWidth = 1;
            this.WizardJobMove.HeaderStyle.BorderTopWidth = 1;
            this.WizardJobMove.HeaderStyle.Class = "";
            this.WizardJobMove.HeaderStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.WizardJobMove.HeaderStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.WizardJobMove.HeaderStyle.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.WizardJobMove.HelpButtonVisible = false;
            this.WizardJobMove.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.WizardJobMove.Location = new System.Drawing.Point(0, 192);
            this.WizardJobMove.Name = "WizardJobMove";
            this.WizardJobMove.Size = new System.Drawing.Size(800, 525);
            this.WizardJobMove.TabIndex = 0;
            this.WizardJobMove.WizardPages.AddRange(new DevComponents.DotNetBar.WizardPage[] {
            this.pageWelcome,
            this.pageSelectTask,
            this.pageServerInformation,
            this.pageSelectJobs,
            this.pageTargetOptions,
            this.pageSummary});
            this.WizardJobMove.FinishButtonClick += new System.ComponentModel.CancelEventHandler(this.WizardJobMove_FinishButtonClick);
            this.WizardJobMove.CancelButtonClick += new System.ComponentModel.CancelEventHandler(this.WizardJobMove_CancelButtonClick);
            this.WizardJobMove.WizardPageChanging += new DevComponents.DotNetBar.WizardCancelPageChangeEventHandler(this.WizardJobMove_WizardPageChanging);
            this.WizardJobMove.WizardPageChanged += new DevComponents.DotNetBar.WizardPageChangeEventHandler(this.WizardJobMove_WizardPageChanged);
            // 
            // pageWelcome
            // 
            this.pageWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageWelcome.BackButtonVisible = DevComponents.DotNetBar.eWizardButtonState.False;
            this.pageWelcome.BackColor = System.Drawing.Color.Transparent;
            this.pageWelcome.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pageWelcome.Controls.Add(this.reflectionImage2);
            this.pageWelcome.Controls.Add(this.label4);
            this.pageWelcome.Controls.Add(this.label5);
            this.pageWelcome.Controls.Add(this.label6);
            this.pageWelcome.InteriorPage = false;
            this.pageWelcome.Location = new System.Drawing.Point(0, 0);
            this.pageWelcome.Name = "pageWelcome";
            this.pageWelcome.Size = new System.Drawing.Size(800, 479);
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
            this.pageWelcome.TabIndex = 1;
            // 
            // reflectionImage2
            // 
            // 
            // 
            // 
            this.reflectionImage2.BackgroundStyle.Class = "";
            this.reflectionImage2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionImage2.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.reflectionImage2.Image = ((System.Drawing.Image)(resources.GetObject("reflectionImage2.Image")));
            this.reflectionImage2.Location = new System.Drawing.Point(-24, 51);
            this.reflectionImage2.Name = "reflectionImage2";
            this.reflectionImage2.Size = new System.Drawing.Size(218, 206);
            this.reflectionImage2.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label4.Location = new System.Drawing.Point(210, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(376, 43);
            this.label4.TabIndex = 0;
            this.label4.Text = "Welcome to Idera new Job Mover";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(210, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(375, 105);
            this.label5.TabIndex = 1;
            this.label5.Text = "This tool will help you to move or copy your SQL Server Agent Jobs.";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(210, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "To continue, click Next.";
            // 
            // pageSelectTask
            // 
            this.pageSelectTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageSelectTask.AntiAlias = false;
            this.pageSelectTask.BackColor = System.Drawing.Color.Transparent;
            this.pageSelectTask.Controls.Add(this.optionCopyJobs);
            this.pageSelectTask.Controls.Add(this.labelX3);
            this.pageSelectTask.Controls.Add(this.OptionMoveJobs);
            this.pageSelectTask.Controls.Add(this.OptionCopyJobsLocal);
            this.pageSelectTask.Location = new System.Drawing.Point(7, 72);
            this.pageSelectTask.Name = "pageSelectTask";
            this.pageSelectTask.PageDescription = "Select the type of operation you wish to perform";
            this.pageSelectTask.PageTitle = "Step 1: Select Operation";
            this.pageSelectTask.Size = new System.Drawing.Size(786, 395);
            // 
            // 
            // 
            this.pageSelectTask.Style.Class = "";
            this.pageSelectTask.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageSelectTask.StyleMouseDown.Class = "";
            this.pageSelectTask.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageSelectTask.StyleMouseOver.Class = "";
            this.pageSelectTask.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pageSelectTask.TabIndex = 2;
            this.pageSelectTask.BeforePageDisplayed += new DevComponents.DotNetBar.WizardCancelPageChangeEventHandler(this.pageSelectTask_BeforePageDisplayed);
            // 
            // optionCopyJobs
            // 
            // 
            // 
            // 
            this.optionCopyJobs.BackgroundStyle.Class = "";
            this.optionCopyJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.optionCopyJobs.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.optionCopyJobs.Checked = true;
            this.optionCopyJobs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optionCopyJobs.CheckValue = "Y";
            this.optionCopyJobs.Location = new System.Drawing.Point(93, 53);
            this.optionCopyJobs.Name = "optionCopyJobs";
            this.optionCopyJobs.Size = new System.Drawing.Size(310, 23);
            this.optionCopyJobs.TabIndex = 3;
            this.optionCopyJobs.Text = "Copy Jobs from one SQL Server instance to another";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(83, 28);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(127, 16);
            this.labelX3.TabIndex = 18;
            this.labelX3.Text = "Please select an option:";
            // 
            // OptionMoveJobs
            // 
            // 
            // 
            // 
            this.OptionMoveJobs.BackgroundStyle.Class = "";
            this.OptionMoveJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.OptionMoveJobs.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.OptionMoveJobs.Location = new System.Drawing.Point(93, 86);
            this.OptionMoveJobs.Name = "OptionMoveJobs";
            this.OptionMoveJobs.Size = new System.Drawing.Size(310, 23);
            this.OptionMoveJobs.TabIndex = 4;
            this.OptionMoveJobs.Text = "Move Jobs from one SQL Server instance to another";
            // 
            // OptionCopyJobsLocal
            // 
            // 
            // 
            // 
            this.OptionCopyJobsLocal.BackgroundStyle.Class = "";
            this.OptionCopyJobsLocal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.OptionCopyJobsLocal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.OptionCopyJobsLocal.Location = new System.Drawing.Point(93, 119);
            this.OptionCopyJobsLocal.Name = "OptionCopyJobsLocal";
            this.OptionCopyJobsLocal.Size = new System.Drawing.Size(310, 23);
            this.OptionCopyJobsLocal.TabIndex = 5;
            this.OptionCopyJobsLocal.Text = "Copy Jobs within the same SQL Server Instance";
            // 
            // pageServerInformation
            // 
            this.pageServerInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageServerInformation.AntiAlias = false;
            this.pageServerInformation.BackColor = System.Drawing.Color.Transparent;
            this.pageServerInformation.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pageServerInformation.Controls.Add(this.labelSourceServer);
            this.pageServerInformation.Controls.Add(this.textSourceServer);
            this.pageServerInformation.Controls.Add(this.buttonBrowseSourceServer);
            this.pageServerInformation.Controls.Add(this.textDestinationServer);
            this.pageServerInformation.Controls.Add(this.buttonDestinationCredentials);
            this.pageServerInformation.Controls.Add(this.buttonSourceCredentials);
            this.pageServerInformation.Controls.Add(this.labelDestinationServer);
            this.pageServerInformation.Controls.Add(this.buttonBrowseDestinationServer);
            this.pageServerInformation.Location = new System.Drawing.Point(7, 72);
            this.pageServerInformation.Name = "pageServerInformation";
            this.pageServerInformation.PageDescription = "This information will be used to connect to the Source and Destination Servers";
            this.pageServerInformation.PageTitle = "Step 2: Select Source and Destination";
            this.pageServerInformation.Size = new System.Drawing.Size(786, 395);
            // 
            // 
            // 
            this.pageServerInformation.Style.Class = "";
            this.pageServerInformation.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageServerInformation.StyleMouseDown.Class = "";
            this.pageServerInformation.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageServerInformation.StyleMouseOver.Class = "";
            this.pageServerInformation.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pageServerInformation.TabIndex = 6;
            this.pageServerInformation.BeforePageDisplayed += new DevComponents.DotNetBar.WizardCancelPageChangeEventHandler(this.pageServerInformation_BeforePageDisplayed);
            this.pageServerInformation.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.pageServerInformation_NextButtonClick);
            // 
            // labelSourceServer
            // 
            this.labelSourceServer.AutoSize = true;
            this.labelSourceServer.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelSourceServer.BackgroundStyle.Class = "";
            this.labelSourceServer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSourceServer.Location = new System.Drawing.Point(83, 28);
            this.labelSourceServer.Name = "labelSourceServer";
            this.labelSourceServer.TabIndex = 3;
            this.labelSourceServer.Text = "&Source SQL Server:";
            // 
            // textSourceServer
            // 
            // 
            // 
            // 
            this.textSourceServer.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textSourceServer.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textSourceServer.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textSourceServer.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textSourceServer.Border.Class = "TextBoxBorder";
            this.textSourceServer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textSourceServer.Location = new System.Drawing.Point(208, 27);
            this.textSourceServer.Name = "textSourceServer";
            this.textSourceServer.Size = new System.Drawing.Size(384, 20);
            this.textSourceServer.TabIndex = 7;
            this.textSourceServer.Text = "(local)";
            this.textSourceServer.WatermarkText = "SQL Server Name";
            this.textSourceServer.Leave += new System.EventHandler(this.textSourceServer_Leave);
            // 
            // buttonBrowseSourceServer
            // 
            this.buttonBrowseSourceServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseSourceServer.BackColor = System.Drawing.Color.White;
            this.buttonBrowseSourceServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseSourceServer.Location = new System.Drawing.Point(599, 28);
            this.buttonBrowseSourceServer.Name = "buttonBrowseSourceServer";
            this.buttonBrowseSourceServer.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseSourceServer.TabIndex = 8;
            this.buttonBrowseSourceServer.Text = "...";
            this.buttonBrowseSourceServer.Click += new System.EventHandler(this.buttonBrowseSourceServer_Click);
            // 
            // textDestinationServer
            // 
            // 
            // 
            // 
            this.textDestinationServer.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textDestinationServer.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textDestinationServer.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textDestinationServer.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textDestinationServer.Border.Class = "TextBoxBorder";
            this.textDestinationServer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textDestinationServer.Location = new System.Drawing.Point(208, 87);
            this.textDestinationServer.Name = "textDestinationServer";
            this.textDestinationServer.Size = new System.Drawing.Size(384, 20);
            this.textDestinationServer.TabIndex = 10;
            this.textDestinationServer.WatermarkText = "SQL Server Name";
            this.textDestinationServer.Leave += new System.EventHandler(this.textDestinationServer_Leave);
            // 
            // buttonDestinationCredentials
            // 
            this.buttonDestinationCredentials.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonDestinationCredentials.BackColor = System.Drawing.Color.White;
            this.buttonDestinationCredentials.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonDestinationCredentials.Image = ((System.Drawing.Image)(resources.GetObject("buttonDestinationCredentials.Image")));
            this.buttonDestinationCredentials.Location = new System.Drawing.Point(623, 87);
            this.buttonDestinationCredentials.Name = "buttonDestinationCredentials";
            this.buttonDestinationCredentials.Size = new System.Drawing.Size(20, 20);
            this.buttonDestinationCredentials.TabIndex = 12;
            this.buttonDestinationCredentials.Tooltip = "Set the credentials used to connect to the specified SQL Server(s).";
            this.buttonDestinationCredentials.Click += new System.EventHandler(this.buttonDestinationCredentials_Click);
            // 
            // buttonSourceCredentials
            // 
            this.buttonSourceCredentials.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSourceCredentials.BackColor = System.Drawing.Color.White;
            this.buttonSourceCredentials.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSourceCredentials.Image = ((System.Drawing.Image)(resources.GetObject("buttonSourceCredentials.Image")));
            this.buttonSourceCredentials.Location = new System.Drawing.Point(623, 28);
            this.buttonSourceCredentials.Name = "buttonSourceCredentials";
            this.buttonSourceCredentials.Size = new System.Drawing.Size(20, 20);
            this.buttonSourceCredentials.TabIndex = 9;
            this.buttonSourceCredentials.Tooltip = "Set the credentials used to connect to the specified SQL Server(s).";
            this.buttonSourceCredentials.Click += new System.EventHandler(this.buttonSourceCredentials_Click);
            // 
            // labelDestinationServer
            // 
            this.labelDestinationServer.AutoSize = true;
            this.labelDestinationServer.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelDestinationServer.BackgroundStyle.Class = "";
            this.labelDestinationServer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelDestinationServer.Location = new System.Drawing.Point(81, 89);
            this.labelDestinationServer.Name = "labelDestinationServer";
            this.labelDestinationServer.TabIndex = 9;
            this.labelDestinationServer.Text = "Destination S&QL Server:";
            // 
            // buttonBrowseDestinationServer
            // 
            this.buttonBrowseDestinationServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseDestinationServer.BackColor = System.Drawing.Color.White;
            this.buttonBrowseDestinationServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseDestinationServer.Location = new System.Drawing.Point(599, 87);
            this.buttonBrowseDestinationServer.Name = "buttonBrowseDestinationServer";
            this.buttonBrowseDestinationServer.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseDestinationServer.TabIndex = 11;
            this.buttonBrowseDestinationServer.Text = "...";
            this.buttonBrowseDestinationServer.Click += new System.EventHandler(this.buttonBrowseDestinationServer_Click);
            // 
            // pageSelectJobs
            // 
            this.pageSelectJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageSelectJobs.AntiAlias = false;
            this.pageSelectJobs.BackColor = System.Drawing.Color.Transparent;
            this.pageSelectJobs.Controls.Add(this.labelJobListMessage);
            this.pageSelectJobs.Controls.Add(this.labelX6);
            this.pageSelectJobs.Controls.Add(this.linkClearAllJobs);
            this.pageSelectJobs.Controls.Add(this.linkSelectAllJobs);
            this.pageSelectJobs.Controls.Add(this.ListJobs);
            this.pageSelectJobs.Controls.Add(this.checkBoxIncludeNotifications);
            this.pageSelectJobs.Controls.Add(this.labelX5);
            this.pageSelectJobs.Controls.Add(this.checkboxIncludeSchedule);
            this.pageSelectJobs.Location = new System.Drawing.Point(7, 72);
            this.pageSelectJobs.Name = "pageSelectJobs";
            this.pageSelectJobs.PageDescription = "Choose which of the SQL Server Agent jobs on the source server are to be copied";
            this.pageSelectJobs.PageTitle = "Step 3: Select Jobs and Source options";
            this.pageSelectJobs.Size = new System.Drawing.Size(786, 395);
            // 
            // 
            // 
            this.pageSelectJobs.Style.Class = "";
            this.pageSelectJobs.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageSelectJobs.StyleMouseDown.Class = "";
            this.pageSelectJobs.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageSelectJobs.StyleMouseOver.Class = "";
            this.pageSelectJobs.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pageSelectJobs.TabIndex = 11;
            this.pageSelectJobs.BeforePageDisplayed += new DevComponents.DotNetBar.WizardCancelPageChangeEventHandler(this.pageSelectJobs_BeforePageDisplayed);
            this.pageSelectJobs.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.pageSelectJobs_NextButtonClick);
            // 
            // labelJobListMessage
            // 
            this.labelJobListMessage.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelJobListMessage.BackgroundStyle.Class = "";
            this.labelJobListMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelJobListMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJobListMessage.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelJobListMessage.Location = new System.Drawing.Point(45, 93);
            this.labelJobListMessage.Name = "labelJobListMessage";
            this.labelJobListMessage.Size = new System.Drawing.Size(440, 42);
            this.labelJobListMessage.TabIndex = 1;
            this.labelJobListMessage.Text = "Loading Jobs...";
            this.labelJobListMessage.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelJobListMessage.Visible = false;
            this.labelJobListMessage.WordWrap = true;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(43, 8);
            this.labelX6.Name = "labelX6";
            this.labelX6.TabIndex = 28;
            this.labelX6.Text = "Please select the SQL Server Agent Jobs that you would like to create on the dest" +
    "ination server";
            // 
            // linkClearAllJobs
            // 
            this.linkClearAllJobs.AutoSize = true;
            this.linkClearAllJobs.Location = new System.Drawing.Point(144, 171);
            this.linkClearAllJobs.Name = "linkClearAllJobs";
            this.linkClearAllJobs.Size = new System.Drawing.Size(45, 13);
            this.linkClearAllJobs.TabIndex = 15;
            this.linkClearAllJobs.TabStop = true;
            this.linkClearAllJobs.Text = "Clear All";
            this.linkClearAllJobs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClearAllJobs_LinkClicked);
            // 
            // linkSelectAllJobs
            // 
            this.linkSelectAllJobs.AutoSize = true;
            this.linkSelectAllJobs.Location = new System.Drawing.Point(52, 171);
            this.linkSelectAllJobs.Name = "linkSelectAllJobs";
            this.linkSelectAllJobs.Size = new System.Drawing.Size(51, 13);
            this.linkSelectAllJobs.TabIndex = 14;
            this.linkSelectAllJobs.TabStop = true;
            this.linkSelectAllJobs.Text = "Select All";
            this.linkSelectAllJobs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelectAllJobs_LinkClicked);
            // 
            // ListJobs
            // 
            this.ListJobs.BackColor = System.Drawing.Color.White;
            this.ListJobs.CheckOnClick = true;
            this.ListJobs.FormattingEnabled = true;
            this.ListJobs.Location = new System.Drawing.Point(43, 28);
            this.ListJobs.Name = "ListJobs";
            this.ListJobs.Size = new System.Drawing.Size(466, 139);
            this.ListJobs.TabIndex = 13;
            this.ListJobs.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListJobs_ItemCheck);
            // 
            // checkBoxIncludeNotifications
            // 
            this.checkBoxIncludeNotifications.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxIncludeNotifications.BackgroundStyle.Class = "";
            this.checkBoxIncludeNotifications.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxIncludeNotifications.Location = new System.Drawing.Point(53, 255);
            this.checkBoxIncludeNotifications.Name = "checkBoxIncludeNotifications";
            this.checkBoxIncludeNotifications.Size = new System.Drawing.Size(127, 15);
            this.checkBoxIncludeNotifications.TabIndex = 18;
            this.checkBoxIncludeNotifications.Text = "Copy job notifications";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(43, 210);
            this.labelX5.Name = "labelX5";
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "Specify the following source job options:";
            // 
            // checkboxIncludeSchedule
            // 
            this.checkboxIncludeSchedule.AutoSize = true;
            // 
            // 
            // 
            this.checkboxIncludeSchedule.BackgroundStyle.Class = "";
            this.checkboxIncludeSchedule.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkboxIncludeSchedule.Location = new System.Drawing.Point(53, 230);
            this.checkboxIncludeSchedule.Name = "checkboxIncludeSchedule";
            this.checkboxIncludeSchedule.Size = new System.Drawing.Size(118, 15);
            this.checkboxIncludeSchedule.TabIndex = 17;
            this.checkboxIncludeSchedule.Text = "Copy job schedules";
            // 
            // pageTargetOptions
            // 
            this.pageTargetOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageTargetOptions.AntiAlias = false;
            this.pageTargetOptions.BackColor = System.Drawing.Color.Transparent;
            this.pageTargetOptions.Controls.Add(this.labelDatabases);
            this.pageTargetOptions.Controls.Add(this.checkBoxAlwaysUseOwner);
            this.pageTargetOptions.Controls.Add(this.checkBoxCreateOperators);
            this.pageTargetOptions.Controls.Add(this.comboBoxDatabases);
            this.pageTargetOptions.Controls.Add(this.labelOwners);
            this.pageTargetOptions.Controls.Add(this.comboBoxOwners);
            this.pageTargetOptions.Controls.Add(this.checkBoxOverwrite);
            this.pageTargetOptions.Controls.Add(this.checkBoxCreateCategory);
            this.pageTargetOptions.Controls.Add(this.checkBoxCreateSchedule);
            this.pageTargetOptions.Controls.Add(this.labelX7);
            this.pageTargetOptions.Controls.Add(this.labelChooseEnableOrDisable);
            this.pageTargetOptions.Controls.Add(this.linkSelectAllDisableJobs);
            this.pageTargetOptions.Controls.Add(this.linkClearAllDisableJobs);
            this.pageTargetOptions.Controls.Add(this.ListDisableJobs);
            this.pageTargetOptions.Location = new System.Drawing.Point(7, 72);
            this.pageTargetOptions.Name = "pageTargetOptions";
            this.pageTargetOptions.PageDescription = "Choose how to create the new jobs on the destination server";
            this.pageTargetOptions.PageTitle = "Step 4: Specify Options for Destination Jobs";
            this.pageTargetOptions.Size = new System.Drawing.Size(786, 395);
            // 
            // 
            // 
            this.pageTargetOptions.Style.Class = "";
            this.pageTargetOptions.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageTargetOptions.StyleMouseDown.Class = "";
            this.pageTargetOptions.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageTargetOptions.StyleMouseOver.Class = "";
            this.pageTargetOptions.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pageTargetOptions.TabIndex = 20;
            this.pageTargetOptions.BeforePageDisplayed += new DevComponents.DotNetBar.WizardCancelPageChangeEventHandler(this.pageTargetOptions_BeforePageDisplayed);
            this.pageTargetOptions.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.pageTargetOptions_NextButtonClick);
            // 
            // labelDatabases
            // 
            this.labelDatabases.AutoSize = true;
            this.labelDatabases.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelDatabases.BackgroundStyle.Class = "";
            this.labelDatabases.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelDatabases.Location = new System.Drawing.Point(394, 944);
            this.labelDatabases.Name = "labelDatabases";
            this.labelDatabases.TabIndex = 24;
            this.labelDatabases.Text = "Use this database for all job steps:";
            // 
            // checkBoxAlwaysUseOwner
            // 
            this.checkBoxAlwaysUseOwner.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxAlwaysUseOwner.BackgroundStyle.Class = "";
            this.checkBoxAlwaysUseOwner.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxAlwaysUseOwner.Location = new System.Drawing.Point(419, 340);
            this.checkBoxAlwaysUseOwner.Name = "checkBoxAlwaysUseOwner";
            this.checkBoxAlwaysUseOwner.Size = new System.Drawing.Size(202, 15);
            this.checkBoxAlwaysUseOwner.TabIndex = 26;
            this.checkBoxAlwaysUseOwner.Text = "Always make this login the job owner";
            // 
            // checkBoxCreateOperators
            // 
            this.checkBoxCreateOperators.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxCreateOperators.BackgroundStyle.Class = "";
            this.checkBoxCreateOperators.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxCreateOperators.Location = new System.Drawing.Point(95, 340);
            this.checkBoxCreateOperators.Name = "checkBoxCreateOperators";
            this.checkBoxCreateOperators.Size = new System.Drawing.Size(245, 15);
            this.checkBoxCreateOperators.TabIndex = 23;
            this.checkBoxCreateOperators.Text = "Create notification operators if they don\'t exist";
            // 
            // comboBoxDatabases
            // 
            this.comboBoxDatabases.DisplayMember = "Text";
            this.comboBoxDatabases.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxDatabases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxDatabases.FormattingEnabled = true;
            this.comboBoxDatabases.ItemHeight = 14;
            this.comboBoxDatabases.Location = new System.Drawing.Point(394, 370);
            this.comboBoxDatabases.Name = "comboBoxDatabases";
            this.comboBoxDatabases.Size = new System.Drawing.Size(243, 20);
            this.comboBoxDatabases.TabIndex = 27;
            this.comboBoxDatabases.WatermarkText = "< use current database name >";
            // 
            // labelOwners
            // 
            this.labelOwners.AutoSize = true;
            this.labelOwners.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelOwners.BackgroundStyle.Class = "";
            this.labelOwners.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelOwners.Location = new System.Drawing.Point(394, 280);
            this.labelOwners.Name = "labelOwners";
            this.labelOwners.TabIndex = 19;
            this.labelOwners.Text = "Use this login if the current owner is not found:";
            // 
            // comboBoxOwners
            // 
            this.comboBoxOwners.DisplayMember = "Text";
            this.comboBoxOwners.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxOwners.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxOwners.FormattingEnabled = true;
            this.comboBoxOwners.ItemHeight = 14;
            this.comboBoxOwners.Location = new System.Drawing.Point(394, 300);
            this.comboBoxOwners.Name = "comboBoxOwners";
            this.comboBoxOwners.Size = new System.Drawing.Size(243, 20);
            this.comboBoxOwners.TabIndex = 25;
            this.comboBoxOwners.WatermarkText = "< use current job owner >";
            // 
            // checkBoxOverwrite
            // 
            this.checkBoxOverwrite.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxOverwrite.BackgroundStyle.Class = "";
            this.checkBoxOverwrite.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxOverwrite.Location = new System.Drawing.Point(95, 370);
            this.checkBoxOverwrite.Name = "checkBoxOverwrite";
            this.checkBoxOverwrite.Size = new System.Drawing.Size(194, 15);
            this.checkBoxOverwrite.TabIndex = 24;
            this.checkBoxOverwrite.Text = "Overwrite jobs with the same name";
            // 
            // checkBoxCreateCategory
            // 
            this.checkBoxCreateCategory.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxCreateCategory.BackgroundStyle.Class = "";
            this.checkBoxCreateCategory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxCreateCategory.Location = new System.Drawing.Point(95, 280);
            this.checkBoxCreateCategory.Name = "checkBoxCreateCategory";
            this.checkBoxCreateCategory.Size = new System.Drawing.Size(217, 15);
            this.checkBoxCreateCategory.TabIndex = 21;
            this.checkBoxCreateCategory.Text = "Create the job category if it doesn\'t exist";
            // 
            // checkBoxCreateSchedule
            // 
            this.checkBoxCreateSchedule.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxCreateSchedule.BackgroundStyle.Class = "";
            this.checkBoxCreateSchedule.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxCreateSchedule.Location = new System.Drawing.Point(95, 496);
            this.checkBoxCreateSchedule.Name = "checkBoxCreateSchedule";
            this.checkBoxCreateSchedule.Size = new System.Drawing.Size(170, 15);
            this.checkBoxCreateSchedule.TabIndex = 22;
            this.checkBoxCreateSchedule.Text = "Always create a new schedule";
            this.checkBoxCreateSchedule.Visible = false;
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(83, 8);
            this.labelX7.Name = "labelX7";
            this.labelX7.TabIndex = 10;
            this.labelX7.Text = "Destination Job Options:";
            // 
            // labelChooseEnableOrDisable
            // 
            this.labelChooseEnableOrDisable.AutoSize = true;
            this.labelChooseEnableOrDisable.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelChooseEnableOrDisable.BackgroundStyle.Class = "";
            this.labelChooseEnableOrDisable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelChooseEnableOrDisable.Location = new System.Drawing.Point(95, 27);
            this.labelChooseEnableOrDisable.Name = "labelChooseEnableOrDisable";
            this.labelChooseEnableOrDisable.TabIndex = 61;
            this.labelChooseEnableOrDisable.Text = "Please select the SQL Server Agent Jobs that you would like to disable on the des" +
    "tination server:";
            // 
            // linkSelectAllDisableJobs
            // 
            this.linkSelectAllDisableJobs.AutoSize = true;
            this.linkSelectAllDisableJobs.Location = new System.Drawing.Point(117, 220);
            this.linkSelectAllDisableJobs.Name = "linkSelectAllDisableJobs";
            this.linkSelectAllDisableJobs.Size = new System.Drawing.Size(51, 13);
            this.linkSelectAllDisableJobs.TabIndex = 14;
            this.linkSelectAllDisableJobs.TabStop = true;
            this.linkSelectAllDisableJobs.Text = "Select All";
            this.linkSelectAllDisableJobs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelectAllDisableJobs_LinkClicked);
            // 
            // linkClearAllDisableJobs
            // 
            this.linkClearAllDisableJobs.AutoSize = true;
            this.linkClearAllDisableJobs.Location = new System.Drawing.Point(190, 220);
            this.linkClearAllDisableJobs.Name = "linkClearAllDisableJobs";
            this.linkClearAllDisableJobs.Size = new System.Drawing.Size(45, 13);
            this.linkClearAllDisableJobs.TabIndex = 15;
            this.linkClearAllDisableJobs.TabStop = true;
            this.linkClearAllDisableJobs.Text = "Clear All";
            this.linkClearAllDisableJobs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClearAllDisableJobs_LinkClicked);
            // 
            // ListDisableJobs
            // 
            this.ListDisableJobs.BackColor = System.Drawing.Color.White;
            this.ListDisableJobs.CheckOnClick = true;
            this.ListDisableJobs.FormattingEnabled = true;
            this.ListDisableJobs.Location = new System.Drawing.Point(117, 47);
            this.ListDisableJobs.Name = "ListDisableJobs";
            this.ListDisableJobs.Size = new System.Drawing.Size(466, 169);
            this.ListDisableJobs.TabIndex = 63;
            // 
            // pageSummary
            // 
            this.pageSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageSummary.AntiAlias = false;
            this.pageSummary.BackColor = System.Drawing.Color.Transparent;
            this.pageSummary.Controls.Add(this.groupMoveDatabase);
            this.pageSummary.FinishButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.True;
            this.pageSummary.Location = new System.Drawing.Point(7, 72);
            this.pageSummary.Name = "pageSummary";
            this.pageSummary.NextButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.False;
            this.pageSummary.NextButtonVisible = DevComponents.DotNetBar.eWizardButtonState.False;
            this.pageSummary.PageDescription = "The requested operation will use the following settings";
            this.pageSummary.PageTitle = "Summary";
            this.pageSummary.Size = new System.Drawing.Size(786, 395);
            // 
            // 
            // 
            this.pageSummary.Style.Class = "";
            this.pageSummary.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageSummary.StyleMouseDown.Class = "";
            this.pageSummary.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageSummary.StyleMouseOver.Class = "";
            this.pageSummary.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pageSummary.TabIndex = 12;
            this.pageSummary.BeforePageDisplayed += new DevComponents.DotNetBar.WizardCancelPageChangeEventHandler(this.pageSummary_BeforePageDisplayed);
            // 
            // groupMoveDatabase
            // 
            this.groupMoveDatabase.BackColor = System.Drawing.Color.Transparent;
            this.groupMoveDatabase.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupMoveDatabase.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupMoveDatabase.Controls.Add(this.LabelSummaryOperationTypeValue);
            this.groupMoveDatabase.Controls.Add(this.LabelSummaryOperationType);
            this.groupMoveDatabase.Controls.Add(this.LabelSummaryTargetOptionsValue);
            this.groupMoveDatabase.Controls.Add(this.LabelSummarySourceOptionsValue);
            this.groupMoveDatabase.Controls.Add(this.LabelSummaryDestinationServerValue);
            this.groupMoveDatabase.Controls.Add(this.LabelSummarySourceServerValue);
            this.groupMoveDatabase.Controls.Add(this.LabelSummaryTargetOptions);
            this.groupMoveDatabase.Controls.Add(this.LabelSummarySourceOptions);
            this.groupMoveDatabase.Controls.Add(this.LabelSummaryDestinationServer);
            this.groupMoveDatabase.Controls.Add(this.LabelSummarySourceServer);
           
            this.groupMoveDatabase.IsShadowEnabled = true;
            this.groupMoveDatabase.Location = new System.Drawing.Point(135, 0);
            this.groupMoveDatabase.Name = "groupMoveDatabase";
            this.groupMoveDatabase.Size = new System.Drawing.Size(520, 196);
            // 
            // 
            // 
            this.groupMoveDatabase.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupMoveDatabase.Style.BackColorGradientAngle = 90;
            this.groupMoveDatabase.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupMoveDatabase.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupMoveDatabase.Style.BorderBottomWidth = 1;
            this.groupMoveDatabase.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupMoveDatabase.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupMoveDatabase.Style.BorderLeftWidth = 1;
            this.groupMoveDatabase.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupMoveDatabase.Style.BorderRightWidth = 1;
            this.groupMoveDatabase.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupMoveDatabase.Style.BorderTopWidth = 1;
            this.groupMoveDatabase.Style.Class = "";
            this.groupMoveDatabase.Style.CornerDiameter = 4;
            this.groupMoveDatabase.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupMoveDatabase.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupMoveDatabase.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupMoveDatabase.StyleMouseDown.Class = "";
            this.groupMoveDatabase.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupMoveDatabase.StyleMouseOver.Class = "";
            this.groupMoveDatabase.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupMoveDatabase.TabIndex = 28;
            // 
            // LabelSummaryOperationTypeValue
            // 
            this.LabelSummaryOperationTypeValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummaryOperationTypeValue.BackgroundStyle.Class = "";
            this.LabelSummaryOperationTypeValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummaryOperationTypeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummaryOperationTypeValue.Location = new System.Drawing.Point(177, 8);
            this.LabelSummaryOperationTypeValue.Name = "LabelSummaryOperationTypeValue";
            this.LabelSummaryOperationTypeValue.Size = new System.Drawing.Size(312, 16);
            this.LabelSummaryOperationTypeValue.TabIndex = 47;
            this.LabelSummaryOperationTypeValue.Text = "Value";
            // 
            // LabelSummaryOperationType
            // 
            this.LabelSummaryOperationType.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummaryOperationType.BackgroundStyle.Class = "";
            this.LabelSummaryOperationType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummaryOperationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummaryOperationType.Location = new System.Drawing.Point(45, 8);
            this.LabelSummaryOperationType.Name = "LabelSummaryOperationType";
            this.LabelSummaryOperationType.Size = new System.Drawing.Size(105, 16);
            this.LabelSummaryOperationType.TabIndex = 46;
            this.LabelSummaryOperationType.Text = "Type of Operation:";
            // 
            // LabelSummaryTargetOptionsValue
            // 
            this.LabelSummaryTargetOptionsValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummaryTargetOptionsValue.BackgroundStyle.Class = "";
            this.LabelSummaryTargetOptionsValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummaryTargetOptionsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummaryTargetOptionsValue.Location = new System.Drawing.Point(177, 121);
            this.LabelSummaryTargetOptionsValue.Name = "LabelSummaryTargetOptionsValue";
            this.LabelSummaryTargetOptionsValue.Size = new System.Drawing.Size(312, 67);
            this.LabelSummaryTargetOptionsValue.TabIndex = 43;
            this.LabelSummaryTargetOptionsValue.Text = "Value\r\n1\r\n2\r\n3\r\n4";
            this.LabelSummaryTargetOptionsValue.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // LabelSummarySourceOptionsValue
            // 
            this.LabelSummarySourceOptionsValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummarySourceOptionsValue.BackgroundStyle.Class = "";
            this.LabelSummarySourceOptionsValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummarySourceOptionsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummarySourceOptionsValue.Location = new System.Drawing.Point(177, 77);
            this.LabelSummarySourceOptionsValue.Name = "LabelSummarySourceOptionsValue";
            this.LabelSummarySourceOptionsValue.Size = new System.Drawing.Size(312, 39);
            this.LabelSummarySourceOptionsValue.TabIndex = 42;
            this.LabelSummarySourceOptionsValue.Text = "Value\r\n1\r\n2\r\n3";
            this.LabelSummarySourceOptionsValue.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // LabelSummaryDestinationServerValue
            // 
            this.LabelSummaryDestinationServerValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummaryDestinationServerValue.BackgroundStyle.Class = "";
            this.LabelSummaryDestinationServerValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummaryDestinationServerValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummaryDestinationServerValue.Location = new System.Drawing.Point(177, 54);
            this.LabelSummaryDestinationServerValue.Name = "LabelSummaryDestinationServerValue";
            this.LabelSummaryDestinationServerValue.Size = new System.Drawing.Size(312, 16);
            this.LabelSummaryDestinationServerValue.TabIndex = 40;
            this.LabelSummaryDestinationServerValue.Text = "Value";
            // 
            // LabelSummarySourceServerValue
            // 
            this.LabelSummarySourceServerValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummarySourceServerValue.BackgroundStyle.Class = "";
            this.LabelSummarySourceServerValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummarySourceServerValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummarySourceServerValue.Location = new System.Drawing.Point(177, 31);
            this.LabelSummarySourceServerValue.Name = "LabelSummarySourceServerValue";
            this.LabelSummarySourceServerValue.Size = new System.Drawing.Size(312, 16);
            this.LabelSummarySourceServerValue.TabIndex = 39;
            this.LabelSummarySourceServerValue.Text = "Value";
            // 
            // LabelSummaryTargetOptions
            // 
            this.LabelSummaryTargetOptions.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummaryTargetOptions.BackgroundStyle.Class = "";
            this.LabelSummaryTargetOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummaryTargetOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummaryTargetOptions.Location = new System.Drawing.Point(45, 121);
            this.LabelSummaryTargetOptions.Name = "LabelSummaryTargetOptions";
            this.LabelSummaryTargetOptions.Size = new System.Drawing.Size(126, 13);
            this.LabelSummaryTargetOptions.TabIndex = 38;
            this.LabelSummaryTargetOptions.Text = "Destination Options:";
            // 
            // LabelSummarySourceOptions
            // 
            this.LabelSummarySourceOptions.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummarySourceOptions.BackgroundStyle.Class = "";
            this.LabelSummarySourceOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummarySourceOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummarySourceOptions.Location = new System.Drawing.Point(45, 77);
            this.LabelSummarySourceOptions.Name = "LabelSummarySourceOptions";
            this.LabelSummarySourceOptions.Size = new System.Drawing.Size(126, 13);
            this.LabelSummarySourceOptions.TabIndex = 37;
            this.LabelSummarySourceOptions.Text = "Source Options:";
            // 
            // LabelSummaryDestinationServer
            // 
            this.LabelSummaryDestinationServer.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummaryDestinationServer.BackgroundStyle.Class = "";
            this.LabelSummaryDestinationServer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummaryDestinationServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummaryDestinationServer.Location = new System.Drawing.Point(45, 54);
            this.LabelSummaryDestinationServer.Name = "LabelSummaryDestinationServer";
            this.LabelSummaryDestinationServer.Size = new System.Drawing.Size(126, 16);
            this.LabelSummaryDestinationServer.TabIndex = 36;
            this.LabelSummaryDestinationServer.Text = "Destination SQL Server:";
            // 
            // LabelSummarySourceServer
            // 
            this.LabelSummarySourceServer.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummarySourceServer.BackgroundStyle.Class = "";
            this.LabelSummarySourceServer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummarySourceServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummarySourceServer.Location = new System.Drawing.Point(45, 31);
            this.LabelSummarySourceServer.Name = "LabelSummarySourceServer";
            this.LabelSummarySourceServer.Size = new System.Drawing.Size(105, 16);
            this.LabelSummarySourceServer.TabIndex = 17;
            this.LabelSummarySourceServer.Text = "Source SQL Server:";
            // 
            // panelResults
            // 
            this.panelResults.BackColor = System.Drawing.Color.White;
            this.panelResults.Controls.Add(this.buttonBack);
            this.panelResults.Controls.Add(this.labelX1);
            this.panelResults.Controls.Add(this.ProgressList);
            this.panelResults.Controls.Add(this.textTaskLog);
            this.panelResults.Controls.Add(this.labelX2);
            this.panelResults.Controls.Add(this.buttonDoAnotherScan);
            this.panelResults.Controls.Add(this.buttonClose);
            this.panelResults.Controls.Add(this.labelStatus);
           // this.panelResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelResults.Location = new System.Drawing.Point(0, 190);
            this.panelResults.Name = "panelResults";
            this.panelResults.Size = new System.Drawing.Size(811, 530);
            this.panelResults.TabIndex = 30;
            // 
            // buttonBack
            // 
            this.buttonBack.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBack.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBack.Location = new System.Drawing.Point(607, 302);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(66, 24);
            this.buttonBack.TabIndex = 31;
            this.buttonBack.Text = "&Back";
            this.buttonBack.Visible = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(12, 15);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 18);
            this.labelX1.TabIndex = 58;
            this.labelX1.Text = "Progress:";
            // 
            // ProgressList
            // 
            this.ProgressList.BackColor = System.Drawing.Color.White;
            this.ProgressList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProgressList.Location = new System.Drawing.Point(14, 39);
            this.ProgressList.Name = "ProgressList";
            this.ProgressList.NumberOfSteps = 6;
            this.ProgressList.Size = new System.Drawing.Size(305, 244);
            this.ProgressList.TabIndex = 29;
            // 
            // textTaskLog
            // 
            this.textTaskLog.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.textTaskLog.Border.Class = "TextBoxBorder";
            this.textTaskLog.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textTaskLog.Location = new System.Drawing.Point(349, 39);
            this.textTaskLog.Multiline = true;
            this.textTaskLog.Name = "textTaskLog";
            this.textTaskLog.ReadOnly = true;
            this.textTaskLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textTaskLog.Size = new System.Drawing.Size(396, 244);
            this.textTaskLog.TabIndex = 30;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(355, 15);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 18);
            this.labelX2.TabIndex = 55;
            this.labelX2.Text = "Task Log:";
            // 
            // buttonDoAnotherScan
            // 
            this.buttonDoAnotherScan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonDoAnotherScan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonDoAnotherScan.Location = new System.Drawing.Point(542, 302);
            this.buttonDoAnotherScan.Name = "buttonDoAnotherScan";
            this.buttonDoAnotherScan.Size = new System.Drawing.Size(131, 24);
            this.buttonDoAnotherScan.TabIndex = 32;
            this.buttonDoAnotherScan.Text = "Move &Additional Jobs";
            this.buttonDoAnotherScan.Visible = false;
            this.buttonDoAnotherScan.Click += new System.EventHandler(this.buttonDoAnotherScan_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonClose.Location = new System.Drawing.Point(679, 302);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(66, 24);
            this.buttonClose.TabIndex = 33;
            this.buttonClose.Text = "&Close";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelStatus
            // 
            // 
            // 
            // 
            this.labelStatus.BackgroundStyle.Class = "";
            this.labelStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(11, 302);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(525, 23);
            this.labelStatus.TabIndex = 53;
            this.labelStatus.Text = "Status";
            // 
            // ideraTitleBar1
            // 
            this.ideraTitleBar1.ActivateLicenseEventHandler = null;
            this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
            this.ideraTitleBar1.Close = true;
            this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
            this.ideraTitleBar1.IderaProductNameText = "SQL Job Mover";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.IsFormLocked = false;
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = false;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(811, 93);
            this.ideraTitleBar1.TabIndex = 31;
            this.ideraTitleBar1.TrialMode = true;
            this.ideraTitleBar1.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar1_LicenseInfoButtonClick);
            // 
            // labelSelectOperation
            // 
            // 
            // 
            // 
            this.labelSelectOperation.BackgroundStyle.Class = "";
            this.labelSelectOperation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSelectOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectOperation.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelSelectOperation.Location = new System.Drawing.Point(2, 160);
            this.labelSelectOperation.Name = "labelSelectOperation";
            this.labelSelectOperation.Size = new System.Drawing.Size(138, 20);
            this.labelSelectOperation.TabIndex = 55;
            this.labelSelectOperation.Text = "Step 1 - Operation >";
            // 
            // labelSourceDes
            // 
            // 
            // 
            // 
            this.labelSourceDes.BackgroundStyle.Class = "";
            this.labelSourceDes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSourceDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSourceDes.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelSourceDes.Location = new System.Drawing.Point(139, 160);
            this.labelSourceDes.Name = "labelSourceDes";
            this.labelSourceDes.Size = new System.Drawing.Size(208, 20);
            this.labelSourceDes.TabIndex = 56;
            this.labelSourceDes.Text = "Step 2 - Source && Destination >";
            // 
            // labelJobOptions
            // 
            // 
            // 
            // 
            this.labelJobOptions.BackgroundStyle.Class = "";
            this.labelJobOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelJobOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJobOptions.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelJobOptions.Location = new System.Drawing.Point(350, 160);
            this.labelJobOptions.Name = "labelJobOptions";
            this.labelJobOptions.Size = new System.Drawing.Size(167, 20);
            this.labelJobOptions.TabIndex = 57;
            this.labelJobOptions.Text = "Step 3 - Jobs && Options >";
            // 
            // labelDesOptions
            // 
            // 
            // 
            // 
            this.labelDesOptions.BackgroundStyle.Class = "";
            this.labelDesOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelDesOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDesOptions.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelDesOptions.Location = new System.Drawing.Point(521, 160);
            this.labelDesOptions.Name = "labelDesOptions";
            this.labelDesOptions.Size = new System.Drawing.Size(200, 20);
            this.labelDesOptions.TabIndex = 58;
            this.labelDesOptions.Text = "Step 4 - Destination Options >";
            // 
            // labelSummary
            // 
            // 
            // 
            // 
            this.labelSummary.BackgroundStyle.Class = "";
            this.labelSummary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSummary.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelSummary.Location = new System.Drawing.Point(722, 160);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(140, 20);
            this.labelSummary.TabIndex = 59;
            this.labelSummary.Text = "Summary";
            // 
            // checkBoxEnable
            // 
            // 
            // 
            // 
            this.checkBoxEnable.BackgroundStyle.Class = "";
            this.checkBoxEnable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxEnable.Location = new System.Drawing.Point(0, 0);
            this.checkBoxEnable.Name = "checkBoxEnable";
            this.checkBoxEnable.TabIndex = 0;
            // 
            // checkBoxDisable
            // 
            // 
            // 
            // 
            this.checkBoxDisable.BackgroundStyle.Class = "";
            this.checkBoxDisable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxDisable.Location = new System.Drawing.Point(0, 0);
            this.checkBoxDisable.Name = "checkBoxDisable";
            this.checkBoxDisable.TabIndex = 0;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(811, 688);
            this.ControlBox = false;
            this.Controls.Add(this.labelSelectOperation);
            this.Controls.Add(this.labelSourceDes);
            this.Controls.Add(this.labelJobOptions);
            this.Controls.Add(this.labelDesOptions);
            this.Controls.Add(this.labelSummary);
            this.Controls.Add(this.WizardJobMove);
            this.Controls.Add(this.panelResults);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ideraTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(815, 725);
            this.MinimumSize = new System.Drawing.Size(815, 725);
            this.Name = "Form_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.WizardJobMove.ResumeLayout(false);
            this.pageWelcome.ResumeLayout(false);
            this.pageSelectTask.ResumeLayout(false);
            this.pageServerInformation.ResumeLayout(false);
            this.pageServerInformation.PerformLayout();
            this.pageSelectJobs.ResumeLayout(false);
            this.pageSelectJobs.PerformLayout();
            this.pageTargetOptions.ResumeLayout(false);
            this.pageTargetOptions.PerformLayout();
            this.pageSummary.ResumeLayout(false);
            this.groupMoveDatabase.ResumeLayout(false);
            this.panelResults.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem menuManageServerGroups;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private DevComponents.DotNetBar.Wizard WizardJobMove;
        private DevComponents.DotNetBar.WizardPage pageWelcome;
        private DevComponents.DotNetBar.Controls.ReflectionImage reflectionImage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.WizardPage pageSelectTask;
        private DevComponents.DotNetBar.Controls.CheckBoxX optionCopyJobs;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.CheckBoxX OptionMoveJobs;
        private DevComponents.DotNetBar.Controls.CheckBoxX OptionCopyJobsLocal;
        private DevComponents.DotNetBar.WizardPage pageServerInformation;
        private DevComponents.DotNetBar.LabelX labelSourceServer;
        private DevComponents.DotNetBar.Controls.TextBoxX textSourceServer;
        private DevComponents.DotNetBar.ButtonX buttonBrowseSourceServer;
        private DevComponents.DotNetBar.Controls.TextBoxX textDestinationServer;
        private DevComponents.DotNetBar.ButtonX buttonSourceCredentials;
        private DevComponents.DotNetBar.ButtonX buttonDestinationCredentials;
        private DevComponents.DotNetBar.LabelX labelDestinationServer;
        private DevComponents.DotNetBar.ButtonX buttonBrowseDestinationServer;
        //  private DevComponents.DotNetBar.WizardPage pageSourceOptions;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkboxIncludeSchedule;
        private DevComponents.DotNetBar.WizardPage pageTargetOptions;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.WizardPage pageSelectJobs;
        private DevComponents.DotNetBar.LabelX labelX6;
        private System.Windows.Forms.LinkLabel linkClearAllJobs;
        private System.Windows.Forms.LinkLabel linkSelectAllJobs;
        private System.Windows.Forms.LinkLabel linkClearAllDisableJobs;
        private System.Windows.Forms.LinkLabel linkSelectAllDisableJobs;
        private DevComponents.DotNetBar.LabelX labelJobListMessage;
        private System.Windows.Forms.CheckedListBox ListJobs;
        private System.Windows.Forms.CheckedListBox ListDisableJobs;
        private DevComponents.DotNetBar.WizardPage pageSummary;
        private DevComponents.DotNetBar.Controls.GroupPanel groupMoveDatabase;
        private DevComponents.DotNetBar.LabelX LabelSummaryOperationTypeValue;
        private DevComponents.DotNetBar.LabelX LabelSummaryOperationType;
        private DevComponents.DotNetBar.LabelX LabelSummaryTargetOptionsValue;
        private DevComponents.DotNetBar.LabelX LabelSummarySourceOptionsValue;
        private DevComponents.DotNetBar.LabelX LabelSummaryDestinationServerValue;
        private DevComponents.DotNetBar.LabelX LabelSummaryTargetOptions;
        private DevComponents.DotNetBar.LabelX LabelSummarySourceOptions;
        private DevComponents.DotNetBar.LabelX LabelSummaryDestinationServer;
        private DevComponents.DotNetBar.LabelX LabelSummarySourceServer;
        private System.Windows.Forms.Panel panelResults;
        private DevComponents.DotNetBar.ButtonX buttonDoAnotherScan;
        private DevComponents.DotNetBar.ButtonX buttonClose;
        private DevComponents.DotNetBar.LabelX labelStatus;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxIncludeNotifications;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxOverwrite;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxCreateCategory;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxCreateSchedule;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxOwners;
        private DevComponents.DotNetBar.LabelX labelOwners;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxDatabases;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxCreateOperators;
        private DevComponents.DotNetBar.LabelX LabelSummarySourceServerValue;
        private DevComponents.DotNetBar.LabelX labelX1;
        private Idera.SqlAdminToolset.Core.ToolProgressListMini ProgressList;
        private DevComponents.DotNetBar.Controls.TextBoxX textTaskLog;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxAlwaysUseOwner;
        private DevComponents.DotNetBar.LabelX labelDatabases;
        private DevComponents.DotNetBar.ButtonX buttonBack;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
        private DevComponents.DotNetBar.LabelX labelSelectOperation;
        private DevComponents.DotNetBar.LabelX labelSourceDes;
        private DevComponents.DotNetBar.LabelX labelJobOptions;
        private DevComponents.DotNetBar.LabelX labelDesOptions;
        private DevComponents.DotNetBar.LabelX labelSummary;
        private DevComponents.DotNetBar.LabelX labelChooseEnableOrDisable;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxEnable;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxDisable;
    }
}

