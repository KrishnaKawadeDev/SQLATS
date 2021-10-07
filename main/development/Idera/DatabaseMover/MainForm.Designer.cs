using System.Windows.Forms;
namespace Idera.SqlAdminToolset.DatabaseMover
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.WizardDatabaseMove = new DevComponents.DotNetBar.Wizard();
            this.pageWelcome = new DevComponents.DotNetBar.WizardPage();
            this.reflectionImage2 = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pageSelectTask = new DevComponents.DotNetBar.WizardPage();
            this.OptionCloneToSameInstance = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.optionCopyDatabase = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.OptionMoveDatabase = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.OptionMoveDataFiles = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.pageServerInformation = new DevComponents.DotNetBar.WizardPage();
            this.textClonedDatabaseName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelClonedDatabaseName = new DevComponents.DotNetBar.LabelX();
            this.labelDetachWarning = new DevComponents.DotNetBar.LabelX();
            this.comboDestinationDatabase = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelDestinationDatabase = new DevComponents.DotNetBar.LabelX();
            this.labelSourceServer = new DevComponents.DotNetBar.LabelX();
            this.labelSourceDatabase = new DevComponents.DotNetBar.LabelX();
            this.textSourceServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboSourceDatabase = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buttonBrowseSourceServer = new DevComponents.DotNetBar.ButtonX();
            this.textDestinationServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonSourceCredentials = new DevComponents.DotNetBar.ButtonX();
            this.buttonDestinationCredentials = new DevComponents.DotNetBar.ButtonX();
            this.labelDestinationServer = new DevComponents.DotNetBar.LabelX();
            this.buttonBrowseDestinationServer = new DevComponents.DotNetBar.ButtonX();
            this.pageFileOptions = new DevComponents.DotNetBar.WizardPage();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.checkBoxOverwrite = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkboxDeleteSourceFiles = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkboxIncludeLogFiles = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.pageTargetFolder = new DevComponents.DotNetBar.WizardPage();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.DataFilePicker = new Idera.SqlAdminToolset.DatabaseMover.DatabaseFilePicker();
            this.pagePermissions = new DevComponents.DotNetBar.WizardPage();
            this.checkApplyMappingToAllDestinationDatabases = new System.Windows.Forms.CheckBox();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.linkClearAllLogins = new System.Windows.Forms.LinkLabel();
            this.linkSelectAllLogins = new System.Windows.Forms.LinkLabel();
            this.labelLoginsSynchronized = new DevComponents.DotNetBar.LabelX();
            this.ListMissingLogins = new System.Windows.Forms.CheckedListBox();
            this.pageSummary = new DevComponents.DotNetBar.WizardPage();
            this.groupMoveDatabase = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.LabelSummaryOperationTypeValue = new DevComponents.DotNetBar.LabelX();
            this.LabelSummaryOperationType = new DevComponents.DotNetBar.LabelX();
            this.LabelSummaryConflictValue = new DevComponents.DotNetBar.LabelX();
            this.LabelSummaryConflict = new DevComponents.DotNetBar.LabelX();
            this.LabelSummaryDeleteSourceFilesValue = new DevComponents.DotNetBar.LabelX();
            this.LabelSummaryIncludeLogFilesValue = new DevComponents.DotNetBar.LabelX();
            this.LabelSummaryDestinationDatabaseValue = new DevComponents.DotNetBar.LabelX();
            this.labelSummarySourceDatabaseValue = new DevComponents.DotNetBar.LabelX();
            this.LabelSummaryDeleteSourceFiles = new DevComponents.DotNetBar.LabelX();
            this.LabelSummaryIncludeLogFiles = new DevComponents.DotNetBar.LabelX();
            this.LabelSummaryDestinationDatabase = new DevComponents.DotNetBar.LabelX();
            this.LabelSummarySourceDatabase = new DevComponents.DotNetBar.LabelX();
            this.panelResults = new System.Windows.Forms.Panel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonDoAnotherScan = new DevComponents.DotNetBar.ButtonX();
            this.buttonClose = new DevComponents.DotNetBar.ButtonX();
            this.ProgressList = new Idera.SqlAdminToolset.Core.ToolProgressListMini();
            this.textTaskLog = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelStatus = new DevComponents.DotNetBar.LabelX();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
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
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.WizardDatabaseMove.SuspendLayout();
            this.pageWelcome.SuspendLayout();
            this.pageSelectTask.SuspendLayout();
            this.pageServerInformation.SuspendLayout();
            this.pageFileOptions.SuspendLayout();
            this.pageTargetFolder.SuspendLayout();
            this.pagePermissions.SuspendLayout();
            this.pageSummary.SuspendLayout();
            this.groupMoveDatabase.SuspendLayout();
            this.panelResults.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.Transparent;
            this.panelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTitle.Controls.Add(this.labelSubtitle);
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Controls.Add(this.pictureBoxTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 117);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(765, 52);
            this.panelTitle.TabIndex = 18;
            // 
            // labelSubtitle
            // 
            // 
            // 
            // 
            this.labelSubtitle.BackgroundStyle.Class = "";
            this.labelSubtitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.Location = new System.Drawing.Point(269, 0);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(490, 53);
            this.labelSubtitle.TabIndex = 6;
            this.labelSubtitle.Text = "Move or copy databases and their associated logins within or between SQL Servers";
            this.labelSubtitle.Visible = false;
            // 
            // labelTitle
            // 
            // 
            // 
            // 
            this.labelTitle.BackgroundStyle.Class = "";
            this.labelTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Location = new System.Drawing.Point(57, 6);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(400, 41);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Database Mover</font></b> ";
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
            // WizardDatabaseMove
            // 
            this.WizardDatabaseMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(229)))), ((int)(((byte)(253)))));
            this.WizardDatabaseMove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("WizardDatabaseMove.BackgroundImage")));
            this.WizardDatabaseMove.ButtonStyle = DevComponents.DotNetBar.eWizardStyle.Office2007;
            this.WizardDatabaseMove.Cursor = System.Windows.Forms.Cursors.Default;
            this.WizardDatabaseMove.FinishButtonAlwaysVisible = true;
            this.WizardDatabaseMove.FinishButtonTabIndex = 3;
            // 
            // 
            // 
            this.WizardDatabaseMove.FooterStyle.BackColor = System.Drawing.Color.Transparent;
            this.WizardDatabaseMove.FooterStyle.Class = "";
            this.WizardDatabaseMove.FooterStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.WizardDatabaseMove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(57)))), ((int)(((byte)(129)))));
            this.WizardDatabaseMove.HeaderCaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WizardDatabaseMove.HeaderImageVisible = false;
            // 
            // 
            // 
            this.WizardDatabaseMove.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.WizardDatabaseMove.HeaderStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.WizardDatabaseMove.HeaderStyle.BackColorGradientAngle = 90;
            this.WizardDatabaseMove.HeaderStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.WizardDatabaseMove.HeaderStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(157)))), ((int)(((byte)(182)))));
            this.WizardDatabaseMove.HeaderStyle.BorderBottomWidth = 1;
            this.WizardDatabaseMove.HeaderStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.WizardDatabaseMove.HeaderStyle.BorderLeftWidth = 1;
            this.WizardDatabaseMove.HeaderStyle.BorderRightWidth = 1;
            this.WizardDatabaseMove.HeaderStyle.BorderTopWidth = 1;
            this.WizardDatabaseMove.HeaderStyle.Class = "";
            this.WizardDatabaseMove.HeaderStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.WizardDatabaseMove.HeaderStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.WizardDatabaseMove.HeaderStyle.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.WizardDatabaseMove.HelpButtonVisible = false;
            this.WizardDatabaseMove.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.WizardDatabaseMove.Location = new System.Drawing.Point(0, 170);
            this.WizardDatabaseMove.Name = "WizardDatabaseMove";
            this.WizardDatabaseMove.Size = new System.Drawing.Size(752, 332);
            this.WizardDatabaseMove.TabIndex = 0;
            this.WizardDatabaseMove.WizardPages.AddRange(new DevComponents.DotNetBar.WizardPage[] {
            this.pageWelcome,
            this.pageSelectTask,
            this.pageServerInformation,
            this.pageFileOptions,
            this.pageTargetFolder,
            this.pagePermissions,
            this.pageSummary});
            this.WizardDatabaseMove.FinishButtonClick += new System.ComponentModel.CancelEventHandler(this.WizardDatabaseMove_FinishButtonClick);
            this.WizardDatabaseMove.CancelButtonClick += new System.ComponentModel.CancelEventHandler(this.WizardDatabaseMove_CancelButtonClick);
            this.WizardDatabaseMove.WizardPageChanging += new DevComponents.DotNetBar.WizardCancelPageChangeEventHandler(this.WizardDatabaseMove_WizardPageChanging);
            this.WizardDatabaseMove.WizardPageChanged += new DevComponents.DotNetBar.WizardPageChangeEventHandler(this.WizardDatabaseMove_WizardPageChanged);
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
            this.pageWelcome.Size = new System.Drawing.Size(752, 286);
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
            this.pageWelcome.TabIndex = 8;
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
            this.label4.Size = new System.Drawing.Size(528, 43);
            this.label4.TabIndex = 0;
            this.label4.Text = "Welcome to Idera Database Mover";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(210, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(527, 53);
            this.label5.TabIndex = 1;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(210, 203);
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
            this.pageSelectTask.Controls.Add(this.OptionCloneToSameInstance);
            this.pageSelectTask.Controls.Add(this.optionCopyDatabase);
            this.pageSelectTask.Controls.Add(this.labelX3);
            this.pageSelectTask.Controls.Add(this.OptionMoveDatabase);
            this.pageSelectTask.Controls.Add(this.OptionMoveDataFiles);
            this.pageSelectTask.Location = new System.Drawing.Point(7, 72);
            this.pageSelectTask.Name = "pageSelectTask";
            this.pageSelectTask.PageDescription = "Select the type of operation you wish to perform";
            this.pageSelectTask.PageTitle = "Step 1: Select Operation";
            this.pageSelectTask.Size = new System.Drawing.Size(738, 202);
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
            this.pageSelectTask.TabIndex = 9;
            this.pageSelectTask.BeforePageDisplayed += new DevComponents.DotNetBar.WizardCancelPageChangeEventHandler(this.pageSelectTask_BeforePageDisplayed);
            // 
            // OptionCloneToSameInstance
            // 
            // 
            // 
            // 
            this.OptionCloneToSameInstance.BackgroundStyle.Class = "";
            this.OptionCloneToSameInstance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.OptionCloneToSameInstance.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.OptionCloneToSameInstance.Location = new System.Drawing.Point(93, 152);
            this.OptionCloneToSameInstance.Name = "OptionCloneToSameInstance";
            this.OptionCloneToSameInstance.Size = new System.Drawing.Size(310, 23);
            this.OptionCloneToSameInstance.TabIndex = 20;
            this.OptionCloneToSameInstance.Text = "Copy a Database within the same SQL Server Instance";
            // 
            // optionCopyDatabase
            // 
            // 
            // 
            // 
            this.optionCopyDatabase.BackgroundStyle.Class = "";
            this.optionCopyDatabase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.optionCopyDatabase.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.optionCopyDatabase.Checked = true;
            this.optionCopyDatabase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optionCopyDatabase.CheckValue = "Y";
            this.optionCopyDatabase.Location = new System.Drawing.Point(93, 53);
            this.optionCopyDatabase.Name = "optionCopyDatabase";
            this.optionCopyDatabase.Size = new System.Drawing.Size(310, 23);
            this.optionCopyDatabase.TabIndex = 19;
            this.optionCopyDatabase.Text = "Copy a Database from one SQL Server instance to another";
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
            // OptionMoveDatabase
            // 
            // 
            // 
            // 
            this.OptionMoveDatabase.BackgroundStyle.Class = "";
            this.OptionMoveDatabase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.OptionMoveDatabase.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.OptionMoveDatabase.Location = new System.Drawing.Point(93, 86);
            this.OptionMoveDatabase.Name = "OptionMoveDatabase";
            this.OptionMoveDatabase.Size = new System.Drawing.Size(310, 23);
            this.OptionMoveDatabase.TabIndex = 0;
            this.OptionMoveDatabase.Text = "Move Database from one SQL Server instance to another";
            // 
            // OptionMoveDataFiles
            // 
            // 
            // 
            // 
            this.OptionMoveDataFiles.BackgroundStyle.Class = "";
            this.OptionMoveDataFiles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.OptionMoveDataFiles.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.OptionMoveDataFiles.Location = new System.Drawing.Point(93, 119);
            this.OptionMoveDataFiles.Name = "OptionMoveDataFiles";
            this.OptionMoveDataFiles.Size = new System.Drawing.Size(310, 23);
            this.OptionMoveDataFiles.TabIndex = 1;
            this.OptionMoveDataFiles.Text = "Move Data Files within the same SQL Server Instance";
            // 
            // pageServerInformation
            // 
            this.pageServerInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageServerInformation.AntiAlias = false;
            this.pageServerInformation.BackColor = System.Drawing.Color.Transparent;
            this.pageServerInformation.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pageServerInformation.Controls.Add(this.textClonedDatabaseName);
            this.pageServerInformation.Controls.Add(this.labelClonedDatabaseName);
            this.pageServerInformation.Controls.Add(this.labelDetachWarning);
            this.pageServerInformation.Controls.Add(this.comboDestinationDatabase);
            this.pageServerInformation.Controls.Add(this.labelDestinationDatabase);
            this.pageServerInformation.Controls.Add(this.labelSourceServer);
            this.pageServerInformation.Controls.Add(this.labelSourceDatabase);
            this.pageServerInformation.Controls.Add(this.textSourceServer);
            this.pageServerInformation.Controls.Add(this.comboSourceDatabase);
            this.pageServerInformation.Controls.Add(this.buttonBrowseSourceServer);
            this.pageServerInformation.Controls.Add(this.textDestinationServer);
            this.pageServerInformation.Controls.Add(this.buttonSourceCredentials);
            this.pageServerInformation.Controls.Add(this.buttonDestinationCredentials);
            this.pageServerInformation.Controls.Add(this.labelDestinationServer);
            this.pageServerInformation.Controls.Add(this.buttonBrowseDestinationServer);
            this.pageServerInformation.Location = new System.Drawing.Point(7, 72);
            this.pageServerInformation.Name = "pageServerInformation";
            this.pageServerInformation.PageDescription = "This information will be used to connect to the Source and Destination Servers";
            this.pageServerInformation.PageTitle = "Step 2: Select Source and Destination";
            this.pageServerInformation.Size = new System.Drawing.Size(738, 202);
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
            this.pageServerInformation.TabIndex = 8;
            this.pageServerInformation.BeforePageDisplayed += new DevComponents.DotNetBar.WizardCancelPageChangeEventHandler(this.WizardPageServerInformation_BeforePageDisplayed);
            this.pageServerInformation.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.WizardPageServerInformation_NextButtonClick);
            // 
            // textClonedDatabaseName
            // 
            this.textClonedDatabaseName.AcceptsReturn = true;
            // 
            // 
            // 
            this.textClonedDatabaseName.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textClonedDatabaseName.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textClonedDatabaseName.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textClonedDatabaseName.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textClonedDatabaseName.Border.Class = "TextBoxBorder";
            this.textClonedDatabaseName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textClonedDatabaseName.Location = new System.Drawing.Point(208, 85);
            this.textClonedDatabaseName.Name = "textClonedDatabaseName";
            this.textClonedDatabaseName.Size = new System.Drawing.Size(384, 20);
            this.textClonedDatabaseName.TabIndex = 23;
            this.textClonedDatabaseName.Visible = false;
            this.textClonedDatabaseName.TextChanged += new System.EventHandler(this.textClonedDatabaseName_TextChanged);
            // 
            // labelClonedDatabaseName
            // 
            this.labelClonedDatabaseName.AutoSize = true;
            this.labelClonedDatabaseName.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelClonedDatabaseName.BackgroundStyle.Class = "";
            this.labelClonedDatabaseName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelClonedDatabaseName.Location = new System.Drawing.Point(82, 90);
            this.labelClonedDatabaseName.Name = "labelClonedDatabaseName";
            this.labelClonedDatabaseName.TabIndex = 22;
            this.labelClonedDatabaseName.Text = "&New Database Name:";
            this.labelClonedDatabaseName.Visible = false;
            // 
            // labelDetachWarning
            // 
            this.labelDetachWarning.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelDetachWarning.BackgroundStyle.Class = "";
            this.labelDetachWarning.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelDetachWarning.Image = ((System.Drawing.Image)(resources.GetObject("labelDetachWarning.Image")));
            this.labelDetachWarning.Location = new System.Drawing.Point(83, 183);
            this.labelDetachWarning.Name = "labelDetachWarning";
            this.labelDetachWarning.Size = new System.Drawing.Size(542, 16);
            this.labelDetachWarning.TabIndex = 21;
            this.labelDetachWarning.Text = "Please note that the source database will be detached in order to complete the op" +
    "eration";
            // 
            // comboDestinationDatabase
            // 
            this.comboDestinationDatabase.DisplayMember = "Text";
            this.comboDestinationDatabase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboDestinationDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboDestinationDatabase.FormattingEnabled = true;
            this.comboDestinationDatabase.ItemHeight = 14;
            this.comboDestinationDatabase.Location = new System.Drawing.Point(208, 143);
            this.comboDestinationDatabase.Name = "comboDestinationDatabase";
            this.comboDestinationDatabase.Size = new System.Drawing.Size(384, 20);
            this.comboDestinationDatabase.TabIndex = 14;
            this.comboDestinationDatabase.WatermarkText = "Leave blank to keep same name or provide a name to rename on copy";
            this.comboDestinationDatabase.SelectedIndexChanged += new System.EventHandler(this.comboDestinationDatabase_SelectedIndexChanged);
            this.comboDestinationDatabase.TextChanged += new System.EventHandler(this.comboDestinationDatabase_TextChanged);
            this.comboDestinationDatabase.Enter += new System.EventHandler(this.comboDestinationDatabase_Enter);
            // 
            // labelDestinationDatabase
            // 
            this.labelDestinationDatabase.AutoSize = true;
            this.labelDestinationDatabase.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelDestinationDatabase.BackgroundStyle.Class = "";
            this.labelDestinationDatabase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelDestinationDatabase.Location = new System.Drawing.Point(82, 147);
            this.labelDestinationDatabase.Name = "labelDestinationDatabase";
            this.labelDestinationDatabase.TabIndex = 13;
            this.labelDestinationDatabase.Text = "Destination Data&base:";
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
            this.labelSourceServer.Location = new System.Drawing.Point(82, 28);
            this.labelSourceServer.Name = "labelSourceServer";
            this.labelSourceServer.TabIndex = 3;
            this.labelSourceServer.Text = "&Source SQL Server:";
            // 
            // labelSourceDatabase
            // 
            this.labelSourceDatabase.AutoSize = true;
            this.labelSourceDatabase.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelSourceDatabase.BackgroundStyle.Class = "";
            this.labelSourceDatabase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSourceDatabase.Location = new System.Drawing.Point(82, 59);
            this.labelSourceDatabase.Name = "labelSourceDatabase";
            this.labelSourceDatabase.TabIndex = 7;
            this.labelSourceDatabase.Text = "Source &Database:";
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
            this.textSourceServer.TabIndex = 4;
            this.textSourceServer.Text = "(local)";
            this.textSourceServer.WatermarkText = "SQL Server Name";
            this.textSourceServer.Leave += new System.EventHandler(this.textSourceServer_Leave);
            // 
            // comboSourceDatabase
            // 
            this.comboSourceDatabase.DisplayMember = "Text";
            this.comboSourceDatabase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboSourceDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSourceDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboSourceDatabase.FormattingEnabled = true;
            this.comboSourceDatabase.ItemHeight = 14;
            this.comboSourceDatabase.Location = new System.Drawing.Point(208, 57);
            this.comboSourceDatabase.Name = "comboSourceDatabase";
            this.comboSourceDatabase.Size = new System.Drawing.Size(384, 20);
            this.comboSourceDatabase.TabIndex = 8;
            this.comboSourceDatabase.SelectedIndexChanged += new System.EventHandler(this.comboSourceDatabase_SelectedIndexChanged);
            this.comboSourceDatabase.Enter += new System.EventHandler(this.comboDatabase_Enter);
            // 
            // buttonBrowseSourceServer
            // 
            this.buttonBrowseSourceServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseSourceServer.BackColor = System.Drawing.Color.White;
            this.buttonBrowseSourceServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseSourceServer.Location = new System.Drawing.Point(599, 28);
            this.buttonBrowseSourceServer.Name = "buttonBrowseSourceServer";
            this.buttonBrowseSourceServer.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseSourceServer.TabIndex = 5;
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
            this.textDestinationServer.Location = new System.Drawing.Point(208, 112);
            this.textDestinationServer.Name = "textDestinationServer";
            this.textDestinationServer.Size = new System.Drawing.Size(384, 20);
            this.textDestinationServer.TabIndex = 10;
            this.textDestinationServer.WatermarkText = "SQL Server Name";
            this.textDestinationServer.Leave += new System.EventHandler(this.textDestinationServer_Leave);
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
            this.buttonSourceCredentials.TabIndex = 6;
            this.buttonSourceCredentials.Tooltip = "Set the credentials used to connect to the specified SQL Server(s).";
            this.buttonSourceCredentials.Click += new System.EventHandler(this.buttonSourceCredentials_Click);
            // 
            // buttonDestinationCredentials
            // 
            this.buttonDestinationCredentials.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonDestinationCredentials.BackColor = System.Drawing.Color.White;
            this.buttonDestinationCredentials.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonDestinationCredentials.Image = ((System.Drawing.Image)(resources.GetObject("buttonDestinationCredentials.Image")));
            this.buttonDestinationCredentials.Location = new System.Drawing.Point(623, 112);
            this.buttonDestinationCredentials.Name = "buttonDestinationCredentials";
            this.buttonDestinationCredentials.Size = new System.Drawing.Size(20, 20);
            this.buttonDestinationCredentials.TabIndex = 12;
            this.buttonDestinationCredentials.Tooltip = "Set the credentials used to connect to the specified SQL Server(s).";
            this.buttonDestinationCredentials.Click += new System.EventHandler(this.buttonDestinationCredentials_Click);
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
            this.labelDestinationServer.Location = new System.Drawing.Point(82, 114);
            this.labelDestinationServer.Name = "labelDestinationServer";
            this.labelDestinationServer.TabIndex = 9;
            this.labelDestinationServer.Text = "Destination S&QL Server:";
            // 
            // buttonBrowseDestinationServer
            // 
            this.buttonBrowseDestinationServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseDestinationServer.BackColor = System.Drawing.Color.White;
            this.buttonBrowseDestinationServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseDestinationServer.Location = new System.Drawing.Point(599, 112);
            this.buttonBrowseDestinationServer.Name = "buttonBrowseDestinationServer";
            this.buttonBrowseDestinationServer.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseDestinationServer.TabIndex = 11;
            this.buttonBrowseDestinationServer.Text = "...";
            this.buttonBrowseDestinationServer.Click += new System.EventHandler(this.buttonBrowseDestinationServer_Click);
            // 
            // pageFileOptions
            // 
            this.pageFileOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageFileOptions.AntiAlias = false;
            this.pageFileOptions.BackColor = System.Drawing.Color.Transparent;
            this.pageFileOptions.Controls.Add(this.labelX5);
            this.pageFileOptions.Controls.Add(this.checkBoxOverwrite);
            this.pageFileOptions.Controls.Add(this.checkboxDeleteSourceFiles);
            this.pageFileOptions.Controls.Add(this.checkboxIncludeLogFiles);
            this.pageFileOptions.Location = new System.Drawing.Point(7, 72);
            this.pageFileOptions.Name = "pageFileOptions";
            this.pageFileOptions.PageDescription = "Select additional options that affect the selected operation";
            this.pageFileOptions.PageTitle = "Step 3: Specify Options";
            this.pageFileOptions.Size = new System.Drawing.Size(738, 202);
            // 
            // 
            // 
            this.pageFileOptions.Style.Class = "";
            this.pageFileOptions.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageFileOptions.StyleMouseDown.Class = "";
            this.pageFileOptions.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageFileOptions.StyleMouseOver.Class = "";
            this.pageFileOptions.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pageFileOptions.TabIndex = 13;
            this.pageFileOptions.BeforePageDisplayed += new DevComponents.DotNetBar.WizardCancelPageChangeEventHandler(this.WizardPageFileOptions_BeforePageDisplayed);
            this.pageFileOptions.AfterPageDisplayed += new DevComponents.DotNetBar.WizardPageChangeEventHandler(this.pageFileOptions_AfterPageDisplayed);
            this.pageFileOptions.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.WizardPageFileOptions_NextButtonClick);
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
            this.labelX5.Location = new System.Drawing.Point(83, 28);
            this.labelX5.Name = "labelX5";
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "Specify the following options:";
            // 
            // checkBoxOverwrite
            // 
            this.checkBoxOverwrite.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxOverwrite.BackgroundStyle.Class = "";
            this.checkBoxOverwrite.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxOverwrite.Location = new System.Drawing.Point(93, 86);
            this.checkBoxOverwrite.Name = "checkBoxOverwrite";
            this.checkBoxOverwrite.Size = new System.Drawing.Size(279, 15);
            this.checkBoxOverwrite.TabIndex = 2;
            this.checkBoxOverwrite.Text = "Overwrite the destination database if it already exists";
            // 
            // checkboxDeleteSourceFiles
            // 
            this.checkboxDeleteSourceFiles.AutoSize = true;
            // 
            // 
            // 
            this.checkboxDeleteSourceFiles.BackgroundStyle.Class = "";
            this.checkboxDeleteSourceFiles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkboxDeleteSourceFiles.Location = new System.Drawing.Point(93, 119);
            this.checkboxDeleteSourceFiles.Name = "checkboxDeleteSourceFiles";
            this.checkboxDeleteSourceFiles.Size = new System.Drawing.Size(336, 15);
            this.checkboxDeleteSourceFiles.TabIndex = 3;
            this.checkboxDeleteSourceFiles.Text = "Delete source database files after the move operation completes";
            // 
            // checkboxIncludeLogFiles
            // 
            this.checkboxIncludeLogFiles.AutoSize = true;
            // 
            // 
            // 
            this.checkboxIncludeLogFiles.BackgroundStyle.Class = "";
            this.checkboxIncludeLogFiles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkboxIncludeLogFiles.Location = new System.Drawing.Point(93, 53);
            this.checkboxIncludeLogFiles.Name = "checkboxIncludeLogFiles";
            this.checkboxIncludeLogFiles.Size = new System.Drawing.Size(301, 15);
            this.checkboxIncludeLogFiles.TabIndex = 1;
            this.checkboxIncludeLogFiles.Text = "Copy the transaction logs in addition to the database files";
            this.checkboxIncludeLogFiles.CheckedChanged += new System.EventHandler(this.checkboxIncludeLogFiles_CheckedChanged);
            // 
            // pageTargetFolder
            // 
            this.pageTargetFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageTargetFolder.AntiAlias = false;
            this.pageTargetFolder.BackColor = System.Drawing.Color.Transparent;
            this.pageTargetFolder.Controls.Add(this.labelX7);
            this.pageTargetFolder.Controls.Add(this.DataFilePicker);
            this.pageTargetFolder.Location = new System.Drawing.Point(7, 72);
            this.pageTargetFolder.Name = "pageTargetFolder";
            this.pageTargetFolder.PageDescription = "Specify information about the files that should be copied";
            this.pageTargetFolder.PageTitle = "Specify Destination File Options";
            this.pageTargetFolder.Size = new System.Drawing.Size(738, 202);
            // 
            // 
            // 
            this.pageTargetFolder.Style.Class = "";
            this.pageTargetFolder.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageTargetFolder.StyleMouseDown.Class = "";
            this.pageTargetFolder.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pageTargetFolder.StyleMouseOver.Class = "";
            this.pageTargetFolder.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pageTargetFolder.TabIndex = 14;
            this.pageTargetFolder.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.pageTargetFolder_NextButtonClick);
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
            this.labelX7.Location = new System.Drawing.Point(36, 0);
            this.labelX7.Name = "labelX7";
            this.labelX7.TabIndex = 10;
            this.labelX7.Text = "Destination File Options:";
            // 
            // DataFilePicker
            // 
            this.DataFilePicker.AutoScroll = true;
            this.DataFilePicker.BackColor = System.Drawing.Color.Transparent;
            this.DataFilePicker.BrowseButtonClickEventHandler = null;
            this.DataFilePicker.Location = new System.Drawing.Point(36, 21);
            this.DataFilePicker.Name = "DataFilePicker";
            this.DataFilePicker.Size = new System.Drawing.Size(668, 181);
            this.DataFilePicker.TabIndex = 9;
            this.DataFilePicker.BrowseButtonClick += new System.EventHandler<System.EventArgs>(this.DataFilePicker_BrowseButtonClick);
            // 
            // pagePermissions
            // 
            this.pagePermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pagePermissions.AntiAlias = false;
            this.pagePermissions.BackColor = System.Drawing.Color.Transparent;
            this.pagePermissions.Controls.Add(this.checkApplyMappingToAllDestinationDatabases);
            this.pagePermissions.Controls.Add(this.labelX6);
            this.pagePermissions.Controls.Add(this.linkClearAllLogins);
            this.pagePermissions.Controls.Add(this.linkSelectAllLogins);
            this.pagePermissions.Controls.Add(this.labelLoginsSynchronized);
            this.pagePermissions.Controls.Add(this.ListMissingLogins);
            this.pagePermissions.Location = new System.Drawing.Point(7, 72);
            this.pagePermissions.Name = "pagePermissions";
            this.pagePermissions.PageDescription = "Select which of the SQL Server login accounts missing on the destination server w" +
    "ill be created";
            this.pagePermissions.PageTitle = "Step 4: Login Accounts";
            this.pagePermissions.Size = new System.Drawing.Size(738, 202);
            // 
            // 
            // 
            this.pagePermissions.Style.Class = "";
            this.pagePermissions.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pagePermissions.StyleMouseDown.Class = "";
            this.pagePermissions.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pagePermissions.StyleMouseOver.Class = "";
            this.pagePermissions.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pagePermissions.TabIndex = 11;
            this.pagePermissions.BeforePageDisplayed += new DevComponents.DotNetBar.WizardCancelPageChangeEventHandler(this.WizardPagePermissions_BeforePageDisplayed);
            this.pagePermissions.NextButtonClick += new System.ComponentModel.CancelEventHandler(this.WizardPagePermissions_NextButtonClick);
            // 
            // checkApplyMappingToAllDestinationDatabases
            // 
            this.checkApplyMappingToAllDestinationDatabases.AutoSize = true;
            this.checkApplyMappingToAllDestinationDatabases.Enabled = false;
            this.checkApplyMappingToAllDestinationDatabases.Location = new System.Drawing.Point(88, 185);
            this.checkApplyMappingToAllDestinationDatabases.Name = "checkApplyMappingToAllDestinationDatabases";
            this.checkApplyMappingToAllDestinationDatabases.Size = new System.Drawing.Size(493, 17);
            this.checkApplyMappingToAllDestinationDatabases.TabIndex = 29;
            this.checkApplyMappingToAllDestinationDatabases.Text = "Grant Database Access and set Default Database if other source databases exist at" +
    " the destination";
            this.checkApplyMappingToAllDestinationDatabases.UseVisualStyleBackColor = true;
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
            this.labelX6.Location = new System.Drawing.Point(83, 4);
            this.labelX6.Name = "labelX6";
            this.labelX6.TabIndex = 28;
            this.labelX6.Text = "Please select the SQL Server logins that you would like to create on the destinat" +
    "ion server:";
            // 
            // linkClearAllLogins
            // 
            this.linkClearAllLogins.AutoSize = true;
            this.linkClearAllLogins.Location = new System.Drawing.Point(137, 165);
            this.linkClearAllLogins.Name = "linkClearAllLogins";
            this.linkClearAllLogins.Size = new System.Drawing.Size(45, 13);
            this.linkClearAllLogins.TabIndex = 26;
            this.linkClearAllLogins.TabStop = true;
            this.linkClearAllLogins.Text = "Clear All";
            this.linkClearAllLogins.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClearAllLogins_LinkClicked);
            // 
            // linkSelectAllLogins
            // 
            this.linkSelectAllLogins.AutoSize = true;
            this.linkSelectAllLogins.Location = new System.Drawing.Point(85, 165);
            this.linkSelectAllLogins.Name = "linkSelectAllLogins";
            this.linkSelectAllLogins.Size = new System.Drawing.Size(51, 13);
            this.linkSelectAllLogins.TabIndex = 25;
            this.linkSelectAllLogins.TabStop = true;
            this.linkSelectAllLogins.Text = "Select All";
            this.linkSelectAllLogins.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelectAllLogins_LinkClicked);
            // 
            // labelLoginsSynchronized
            // 
            this.labelLoginsSynchronized.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelLoginsSynchronized.BackgroundStyle.Class = "";
            this.labelLoginsSynchronized.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelLoginsSynchronized.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoginsSynchronized.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelLoginsSynchronized.Location = new System.Drawing.Point(95, 49);
            this.labelLoginsSynchronized.Name = "labelLoginsSynchronized";
            this.labelLoginsSynchronized.Size = new System.Drawing.Size(552, 42);
            this.labelLoginsSynchronized.TabIndex = 1;
            this.labelLoginsSynchronized.Text = "All needed SQL Server logins already exist on the destination SQL Server.";
            this.labelLoginsSynchronized.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelLoginsSynchronized.Visible = false;
            this.labelLoginsSynchronized.WordWrap = true;
            // 
            // ListMissingLogins
            // 
            this.ListMissingLogins.CheckOnClick = true;
            this.ListMissingLogins.FormattingEnabled = true;
            this.ListMissingLogins.Location = new System.Drawing.Point(83, 24);
            this.ListMissingLogins.Name = "ListMissingLogins";
            this.ListMissingLogins.Size = new System.Drawing.Size(575, 139);
            this.ListMissingLogins.TabIndex = 27;
            this.ListMissingLogins.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListMissingLogins_ItemCheck);
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
            this.pageSummary.Size = new System.Drawing.Size(738, 202);
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
            this.pageSummary.BeforePageDisplayed += new DevComponents.DotNetBar.WizardCancelPageChangeEventHandler(this.WizardPageSummary_BeforePageDisplayed);
            // 
            // groupMoveDatabase
            // 
            this.groupMoveDatabase.BackColor = System.Drawing.Color.Transparent;
            this.groupMoveDatabase.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupMoveDatabase.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupMoveDatabase.Controls.Add(this.LabelSummaryOperationTypeValue);
            this.groupMoveDatabase.Controls.Add(this.LabelSummaryOperationType);
            this.groupMoveDatabase.Controls.Add(this.LabelSummaryConflictValue);
            this.groupMoveDatabase.Controls.Add(this.LabelSummaryConflict);
            this.groupMoveDatabase.Controls.Add(this.LabelSummaryDeleteSourceFilesValue);
            this.groupMoveDatabase.Controls.Add(this.LabelSummaryIncludeLogFilesValue);
            this.groupMoveDatabase.Controls.Add(this.LabelSummaryDestinationDatabaseValue);
            this.groupMoveDatabase.Controls.Add(this.labelSummarySourceDatabaseValue);
            this.groupMoveDatabase.Controls.Add(this.LabelSummaryDeleteSourceFiles);
            this.groupMoveDatabase.Controls.Add(this.LabelSummaryIncludeLogFiles);
            this.groupMoveDatabase.Controls.Add(this.LabelSummaryDestinationDatabase);
            this.groupMoveDatabase.Controls.Add(this.LabelSummarySourceDatabase);
            this.groupMoveDatabase.IsShadowEnabled = true;
            this.groupMoveDatabase.Location = new System.Drawing.Point(135, 1);
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
            this.groupMoveDatabase.TabIndex = 26;
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
            this.LabelSummaryOperationTypeValue.Size = new System.Drawing.Size(290, 16);
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
            // LabelSummaryConflictValue
            // 
            this.LabelSummaryConflictValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummaryConflictValue.BackgroundStyle.Class = "";
            this.LabelSummaryConflictValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummaryConflictValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummaryConflictValue.Location = new System.Drawing.Point(177, 122);
            this.LabelSummaryConflictValue.Name = "LabelSummaryConflictValue";
            this.LabelSummaryConflictValue.Size = new System.Drawing.Size(208, 15);
            this.LabelSummaryConflictValue.TabIndex = 45;
            this.LabelSummaryConflictValue.Text = "Value";
            // 
            // LabelSummaryConflict
            // 
            this.LabelSummaryConflict.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummaryConflict.BackgroundStyle.Class = "";
            this.LabelSummaryConflict.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummaryConflict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummaryConflict.Location = new System.Drawing.Point(45, 123);
            this.LabelSummaryConflict.Name = "LabelSummaryConflict";
            this.LabelSummaryConflict.Size = new System.Drawing.Size(126, 13);
            this.LabelSummaryConflict.TabIndex = 44;
            this.LabelSummaryConflict.Text = "If destination exists:";
            // 
            // LabelSummaryDeleteSourceFilesValue
            // 
            this.LabelSummaryDeleteSourceFilesValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummaryDeleteSourceFilesValue.BackgroundStyle.Class = "";
            this.LabelSummaryDeleteSourceFilesValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummaryDeleteSourceFilesValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummaryDeleteSourceFilesValue.Location = new System.Drawing.Point(177, 97);
            this.LabelSummaryDeleteSourceFilesValue.Name = "LabelSummaryDeleteSourceFilesValue";
            this.LabelSummaryDeleteSourceFilesValue.Size = new System.Drawing.Size(208, 16);
            this.LabelSummaryDeleteSourceFilesValue.TabIndex = 43;
            this.LabelSummaryDeleteSourceFilesValue.Text = "Value";
            // 
            // LabelSummaryIncludeLogFilesValue
            // 
            this.LabelSummaryIncludeLogFilesValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummaryIncludeLogFilesValue.BackgroundStyle.Class = "";
            this.LabelSummaryIncludeLogFilesValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummaryIncludeLogFilesValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummaryIncludeLogFilesValue.Location = new System.Drawing.Point(177, 74);
            this.LabelSummaryIncludeLogFilesValue.Name = "LabelSummaryIncludeLogFilesValue";
            this.LabelSummaryIncludeLogFilesValue.Size = new System.Drawing.Size(208, 16);
            this.LabelSummaryIncludeLogFilesValue.TabIndex = 42;
            this.LabelSummaryIncludeLogFilesValue.Text = "Value";
            // 
            // LabelSummaryDestinationDatabaseValue
            // 
            this.LabelSummaryDestinationDatabaseValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummaryDestinationDatabaseValue.BackgroundStyle.Class = "";
            this.LabelSummaryDestinationDatabaseValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummaryDestinationDatabaseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummaryDestinationDatabaseValue.Location = new System.Drawing.Point(177, 54);
            this.LabelSummaryDestinationDatabaseValue.Name = "LabelSummaryDestinationDatabaseValue";
            this.LabelSummaryDestinationDatabaseValue.Size = new System.Drawing.Size(290, 16);
            this.LabelSummaryDestinationDatabaseValue.TabIndex = 40;
            this.LabelSummaryDestinationDatabaseValue.Text = "Value";
            // 
            // labelSummarySourceDatabaseValue
            // 
            this.labelSummarySourceDatabaseValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelSummarySourceDatabaseValue.BackgroundStyle.Class = "";
            this.labelSummarySourceDatabaseValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSummarySourceDatabaseValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSummarySourceDatabaseValue.Location = new System.Drawing.Point(177, 32);
            this.labelSummarySourceDatabaseValue.Name = "labelSummarySourceDatabaseValue";
            this.labelSummarySourceDatabaseValue.Size = new System.Drawing.Size(290, 16);
            this.labelSummarySourceDatabaseValue.TabIndex = 39;
            this.labelSummarySourceDatabaseValue.Text = "Value";
            // 
            // LabelSummaryDeleteSourceFiles
            // 
            this.LabelSummaryDeleteSourceFiles.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummaryDeleteSourceFiles.BackgroundStyle.Class = "";
            this.LabelSummaryDeleteSourceFiles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummaryDeleteSourceFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummaryDeleteSourceFiles.Location = new System.Drawing.Point(45, 99);
            this.LabelSummaryDeleteSourceFiles.Name = "LabelSummaryDeleteSourceFiles";
            this.LabelSummaryDeleteSourceFiles.Size = new System.Drawing.Size(126, 13);
            this.LabelSummaryDeleteSourceFiles.TabIndex = 38;
            this.LabelSummaryDeleteSourceFiles.Text = "Delete Source Files:";
            // 
            // LabelSummaryIncludeLogFiles
            // 
            this.LabelSummaryIncludeLogFiles.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummaryIncludeLogFiles.BackgroundStyle.Class = "";
            this.LabelSummaryIncludeLogFiles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummaryIncludeLogFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummaryIncludeLogFiles.Location = new System.Drawing.Point(45, 76);
            this.LabelSummaryIncludeLogFiles.Name = "LabelSummaryIncludeLogFiles";
            this.LabelSummaryIncludeLogFiles.Size = new System.Drawing.Size(126, 13);
            this.LabelSummaryIncludeLogFiles.TabIndex = 37;
            this.LabelSummaryIncludeLogFiles.Text = "Include Log Files:";
            // 
            // LabelSummaryDestinationDatabase
            // 
            this.LabelSummaryDestinationDatabase.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummaryDestinationDatabase.BackgroundStyle.Class = "";
            this.LabelSummaryDestinationDatabase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummaryDestinationDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummaryDestinationDatabase.Location = new System.Drawing.Point(45, 54);
            this.LabelSummaryDestinationDatabase.Name = "LabelSummaryDestinationDatabase";
            this.LabelSummaryDestinationDatabase.Size = new System.Drawing.Size(126, 16);
            this.LabelSummaryDestinationDatabase.TabIndex = 36;
            this.LabelSummaryDestinationDatabase.Text = "Destination Database:";
            // 
            // LabelSummarySourceDatabase
            // 
            this.LabelSummarySourceDatabase.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.LabelSummarySourceDatabase.BackgroundStyle.Class = "";
            this.LabelSummarySourceDatabase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelSummarySourceDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSummarySourceDatabase.Location = new System.Drawing.Point(45, 32);
            this.LabelSummarySourceDatabase.Name = "LabelSummarySourceDatabase";
            this.LabelSummarySourceDatabase.Size = new System.Drawing.Size(105, 16);
            this.LabelSummarySourceDatabase.TabIndex = 17;
            this.LabelSummarySourceDatabase.Text = "Source Database:";
            // 
            // panelResults
            // 
            this.panelResults.BackColor = System.Drawing.Color.White;
            this.panelResults.Controls.Add(this.labelX1);
            this.panelResults.Controls.Add(this.buttonDoAnotherScan);
            this.panelResults.Controls.Add(this.buttonClose);
            this.panelResults.Controls.Add(this.ProgressList);
            this.panelResults.Controls.Add(this.textTaskLog);
            this.panelResults.Controls.Add(this.labelX2);
            this.panelResults.Controls.Add(this.labelStatus);
            this.panelResults.Location = new System.Drawing.Point(0, 170);
            this.panelResults.Name = "panelResults";
            this.panelResults.Size = new System.Drawing.Size(752, 332);
            this.panelResults.TabIndex = 29;
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
            this.labelX1.Location = new System.Drawing.Point(11, 15);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 18);
            this.labelX1.TabIndex = 54;
            this.labelX1.Text = "Progress:";
            // 
            // buttonDoAnotherScan
            // 
            this.buttonDoAnotherScan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonDoAnotherScan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonDoAnotherScan.Enabled = false;
            this.buttonDoAnotherScan.Location = new System.Drawing.Point(534, 302);
            this.buttonDoAnotherScan.Name = "buttonDoAnotherScan";
            this.buttonDoAnotherScan.Size = new System.Drawing.Size(131, 24);
            this.buttonDoAnotherScan.TabIndex = 52;
            this.buttonDoAnotherScan.Text = "Move &Another Database";
            this.buttonDoAnotherScan.Click += new System.EventHandler(this.buttonDoAnotherScan_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonClose.Location = new System.Drawing.Point(671, 302);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(66, 24);
            this.buttonClose.TabIndex = 51;
            this.buttonClose.Text = "&Close";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ProgressList
            // 
            this.ProgressList.BackColor = System.Drawing.Color.White;
            this.ProgressList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProgressList.Location = new System.Drawing.Point(11, 39);
            this.ProgressList.Name = "ProgressList";
            this.ProgressList.NumberOfSteps = 6;
            this.ProgressList.Size = new System.Drawing.Size(305, 244);
            this.ProgressList.TabIndex = 50;
            // 
            // textTaskLog
            // 
            this.textTaskLog.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.textTaskLog.Border.Class = "TextBoxBorder";
            this.textTaskLog.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textTaskLog.Location = new System.Drawing.Point(322, 39);
            this.textTaskLog.Multiline = true;
            this.textTaskLog.Name = "textTaskLog";
            this.textTaskLog.ReadOnly = true;
            this.textTaskLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textTaskLog.Size = new System.Drawing.Size(416, 244);
            this.textTaskLog.TabIndex = 49;
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
            this.labelX2.Location = new System.Drawing.Point(323, 15);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 18);
            this.labelX2.TabIndex = 48;
            this.labelX2.Text = "Task Log:";
            // 
            // labelStatus
            // 
            // 
            // 
            // 
            this.labelStatus.BackgroundStyle.Class = "";
            this.labelStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(9, 302);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(519, 23);
            this.labelStatus.TabIndex = 53;
            this.labelStatus.Text = "Status";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuTools,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 93);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(765, 24);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExitToLaunchpad,
            this.menuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
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
            this.toolStripMenuItem12,
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
            this.menuAbout.Text = "&About Database Mover";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Logical Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "File Type";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "File Path";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 291;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "File Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // ideraTitleBar1
            // 
            this.ideraTitleBar1.ActivateLicenseEventHandler = null;
            this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
            this.ideraTitleBar1.Close = true;
            this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
            this.ideraTitleBar1.IderaProductNameText = "SQL Database Mover";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.IsFormLocked = false;
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = false;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(765, 93);
            this.ideraTitleBar1.TabIndex = 30;
            this.ideraTitleBar1.TrialMode = true;
            this.ideraTitleBar1.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar1_LicenseInfoButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(765, 510);
            this.ControlBox = false;
            this.Controls.Add(this.WizardDatabaseMove);
            this.Controls.Add(this.panelResults);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ideraTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(765, 510);
            this.MinimumSize = new System.Drawing.Size(765, 510);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
            this.panelTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.WizardDatabaseMove.ResumeLayout(false);
            this.pageWelcome.ResumeLayout(false);
            this.pageSelectTask.ResumeLayout(false);
            this.pageServerInformation.ResumeLayout(false);
            this.pageServerInformation.PerformLayout();
            this.pageFileOptions.ResumeLayout(false);
            this.pageFileOptions.PerformLayout();
            this.pageTargetFolder.ResumeLayout(false);
            this.pageTargetFolder.PerformLayout();
            this.pagePermissions.ResumeLayout(false);
            this.pagePermissions.PerformLayout();
            this.pageSummary.ResumeLayout(false);
            this.groupMoveDatabase.ResumeLayout(false);
            this.panelResults.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       private System.Windows.Forms.ToolTip toolTip1;
       private System.Windows.Forms.ToolTip toolTip2;
       private System.Windows.Forms.Panel panelTitle;
       private DevComponents.DotNetBar.LabelX labelSubtitle;
       private DevComponents.DotNetBar.LabelX labelTitle;
       private System.Windows.Forms.PictureBox pictureBoxTitle;
       private DevComponents.DotNetBar.Wizard WizardDatabaseMove;
       private DevComponents.DotNetBar.WizardPage pageServerInformation;
       private DevComponents.DotNetBar.WizardPage pageSelectTask;
       private DevComponents.DotNetBar.Controls.CheckBoxX OptionMoveDataFiles;
       private DevComponents.DotNetBar.Controls.CheckBoxX OptionMoveDatabase;
       private DevComponents.DotNetBar.LabelX labelX3;
       private DevComponents.DotNetBar.WizardPage pagePermissions;
       private DevComponents.DotNetBar.WizardPage pageSummary;
       private DevComponents.DotNetBar.Controls.GroupPanel groupMoveDatabase;
       private DevComponents.DotNetBar.LabelX LabelSummaryDestinationDatabase;
       private DevComponents.DotNetBar.LabelX LabelSummarySourceDatabase;
       private DevComponents.DotNetBar.LabelX labelSummarySourceDatabaseValue;
       private DevComponents.DotNetBar.LabelX LabelSummaryDeleteSourceFiles;
       private DevComponents.DotNetBar.LabelX LabelSummaryIncludeLogFiles;
       private DevComponents.DotNetBar.LabelX LabelSummaryDeleteSourceFilesValue;
       private DevComponents.DotNetBar.LabelX LabelSummaryIncludeLogFilesValue;
       private DevComponents.DotNetBar.LabelX LabelSummaryDestinationDatabaseValue;
       private DevComponents.DotNetBar.Controls.TextBoxX textDestinationServer;
       private DevComponents.DotNetBar.ButtonX buttonDestinationCredentials;
       private DevComponents.DotNetBar.ButtonX buttonBrowseDestinationServer;
       private DevComponents.DotNetBar.LabelX labelDestinationServer;
       private DevComponents.DotNetBar.ButtonX buttonSourceCredentials;
       private DevComponents.DotNetBar.ButtonX buttonBrowseSourceServer;
       private DevComponents.DotNetBar.Controls.TextBoxX textSourceServer;
       private DevComponents.DotNetBar.LabelX labelSourceDatabase;
       private DevComponents.DotNetBar.LabelX labelSourceServer;
       private DevComponents.DotNetBar.WizardPage pageFileOptions;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkboxDeleteSourceFiles;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkboxIncludeLogFiles;
       private DevComponents.DotNetBar.LabelX LabelSummaryConflictValue;
       private DevComponents.DotNetBar.LabelX LabelSummaryConflict;
       private DevComponents.DotNetBar.LabelX LabelSummaryOperationTypeValue;
       private DevComponents.DotNetBar.LabelX LabelSummaryOperationType;
       private System.Windows.Forms.CheckedListBox ListMissingLogins;
       private DevComponents.DotNetBar.LabelX labelX2;
       private DevComponents.DotNetBar.Controls.TextBoxX textTaskLog;
       private DevComponents.DotNetBar.LabelX labelLoginsSynchronized;
       private System.Windows.Forms.MenuStrip menuStrip1;
       private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
       private System.Windows.Forms.ToolStripMenuItem menuExitToLaunchpad;
       private System.Windows.Forms.ToolStripMenuItem menuFileExit;
       private System.Windows.Forms.ToolStripMenuItem menuTools;
       private System.Windows.Forms.ToolStripMenuItem menuManageServerGroups;
       private System.Windows.Forms.ToolStripMenuItem menuToolsetOptions;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
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
       private DevComponents.DotNetBar.Controls.ComboBoxEx comboSourceDatabase;
       private System.Windows.Forms.LinkLabel linkClearAllLogins;
       private System.Windows.Forms.LinkLabel linkSelectAllLogins;
       private DevComponents.DotNetBar.WizardPage pageWelcome;
       private DevComponents.DotNetBar.Controls.ReflectionImage reflectionImage2;
       private System.Windows.Forms.Label label4;
       private System.Windows.Forms.Label label5;
       private System.Windows.Forms.Label label6;
       private DevComponents.DotNetBar.Controls.ComboBoxEx comboDestinationDatabase;
       private DevComponents.DotNetBar.LabelX labelDestinationDatabase;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxOverwrite;
       private DevComponents.DotNetBar.LabelX labelX5;
       private DevComponents.DotNetBar.Controls.CheckBoxX optionCopyDatabase;
       private System.Windows.Forms.Panel panelResults;
       private Idera.SqlAdminToolset.Core.ToolProgressListMini ProgressList;
       private DevComponents.DotNetBar.ButtonX buttonDoAnotherScan;
       private DevComponents.DotNetBar.ButtonX buttonClose;
       private DevComponents.DotNetBar.LabelX labelStatus;
       private DevComponents.DotNetBar.LabelX labelX1;
       private DevComponents.DotNetBar.WizardPage pageTargetFolder;
       private DevComponents.DotNetBar.LabelX labelX6;
       private DevComponents.DotNetBar.LabelX labelDetachWarning;
       private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
       private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
       private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
       private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
       private DatabaseFilePicker DataFilePicker;
       private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.CheckBox checkApplyMappingToAllDestinationDatabases;
        private DevComponents.DotNetBar.Controls.CheckBoxX OptionCloneToSameInstance;
        private DevComponents.DotNetBar.Controls.TextBoxX textClonedDatabaseName;
        private DevComponents.DotNetBar.LabelX labelClonedDatabaseName;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
    }
}

