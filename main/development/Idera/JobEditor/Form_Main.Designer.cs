namespace Idera.SqlAdminToolset.JobEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelUserInput = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupPanelSelect = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labeljobstatus = new DevComponents.DotNetBar.LabelX();
            this.comboBoxjobdayhour = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buttonGetResults = new DevComponents.DotNetBar.ButtonX();
            this.contextMenuStripJobList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuEditJob = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuCheckAllSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuClearAllChecked = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuXML = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListCheckboxes = new System.Windows.Forms.ImageList(this.components);
            this.groupResults = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupStatistics = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pictureBoxNotNotifying = new System.Windows.Forms.PictureBox();
            this.labelNotNotifying = new DevComponents.DotNetBar.LabelX();
            this.labelServersScanned = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxServersScanned = new System.Windows.Forms.PictureBox();
            this.pictureBoxNewJobs = new System.Windows.Forms.PictureBox();
            this.labelNewJobs = new DevComponents.DotNetBar.LabelX();
            this.labelFailed = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxFailed = new System.Windows.Forms.PictureBox();
            this.pictureBoxNotRecent = new System.Windows.Forms.PictureBox();
            this.labelNotRecent = new DevComponents.DotNetBar.LabelX();
            this.buttonSelectJobs = new DevComponents.DotNetBar.ButtonX();
            this.labelEmptyResultSet = new DevComponents.DotNetBar.LabelX();
            this.labelJobList = new DevComponents.DotNetBar.LabelX();
            this.dataGridViewJobs = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuXML = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditJob = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuCheckAllSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClearAllChecked = new System.Windows.Forms.ToolStripMenuItem();
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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonUpdateJobs = new DevComponents.DotNetBar.ButtonX();
            this.labelStatus = new DevComponents.DotNetBar.LabelX();
            this.buttonCopyToClipboard = new DevComponents.DotNetBar.ButtonX();
            this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.ServerSelection = new Idera.SqlAdminToolset.Core.Controls.ToolServerSelection();
            this.panelUserInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupPanelSelect.SuspendLayout();
            this.contextMenuStripJobList.SuspendLayout();
            this.groupResults.SuspendLayout();
            this.groupStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotNotifying)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServersScanned)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFailed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotRecent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJobs)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.panelMiddle.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUserInput
            // 
            this.panelUserInput.Controls.Add(this.numericUpDown1);
            this.panelUserInput.Controls.Add(this.comboBoxjobdayhour);
            this.panelUserInput.Controls.Add(this.groupPanelSelect);
            this.panelUserInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUserInput.Location = new System.Drawing.Point(0, 169);
            this.panelUserInput.Name = "panelUserInput";
            this.panelUserInput.Padding = new System.Windows.Forms.Padding(6);
            this.panelUserInput.Size = new System.Drawing.Size(939, 72);
            this.panelUserInput.TabIndex = 14;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(607, 13);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(42, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupPanelSelect
            // 
            this.groupPanelSelect.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanelSelect.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanelSelect.Controls.Add(this.ServerSelection);
            this.groupPanelSelect.Controls.Add(this.labeljobstatus);
           // this.groupPanelSelect.Controls.Add(this.comboBoxjobdayhour);
            this.groupPanelSelect.Controls.Add(this.buttonGetResults);
            this.groupPanelSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanelSelect.IsShadowEnabled = true;
            this.groupPanelSelect.Location = new System.Drawing.Point(6, 6);
            this.groupPanelSelect.Name = "groupPanelSelect";
            this.groupPanelSelect.Size = new System.Drawing.Size(927, 60);
            // 
            // 
            // 
            this.groupPanelSelect.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanelSelect.Style.BackColorGradientAngle = 90;
            this.groupPanelSelect.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanelSelect.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelSelect.Style.BorderBottomWidth = 1;
            this.groupPanelSelect.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanelSelect.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelSelect.Style.BorderLeftWidth = 1;
            this.groupPanelSelect.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelSelect.Style.BorderRightWidth = 1;
            this.groupPanelSelect.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelSelect.Style.BorderTopWidth = 1;
            this.groupPanelSelect.Style.Class = "";
            this.groupPanelSelect.Style.CornerDiameter = 4;
            this.groupPanelSelect.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanelSelect.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanelSelect.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanelSelect.StyleMouseDown.Class = "";
            this.groupPanelSelect.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanelSelect.StyleMouseOver.Class = "";
            this.groupPanelSelect.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanelSelect.TabIndex = 0;
            // 
            // labeljobstatus
            // 
            this.labeljobstatus.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labeljobstatus.BackgroundStyle.Class = "";
            this.labeljobstatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labeljobstatus.Location = new System.Drawing.Point(480, 0);
            this.labeljobstatus.Name = "labeljobstatus";
            this.labeljobstatus.Size = new System.Drawing.Size(120, 32);
            this.labeljobstatus.TabIndex = 21;
            this.labeljobstatus.Text = "Jobs not run in the last:";
            // 
            // comboBoxjobdayhour
            // 
            this.comboBoxjobdayhour.DisplayMember = "Text";
            this.comboBoxjobdayhour.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxjobdayhour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxjobdayhour.FormattingEnabled = true;
            this.comboBoxjobdayhour.ItemHeight = 16;
            this.comboBoxjobdayhour.Location = new System.Drawing.Point(654, 13);
            this.comboBoxjobdayhour.MaxDropDownItems = 64;
            this.comboBoxjobdayhour.Name = "comboBoxjobdayhour";
            this.comboBoxjobdayhour.Size = new System.Drawing.Size(87, 22);
            this.comboBoxjobdayhour.TabIndex = 22;
            this.comboBoxjobdayhour.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.comboBoxjobdayhour.DropDown += new System.EventHandler(this.comboBoxjobdayhour_DropDown);
            // 
            // buttonGetResults
            // 
            this.buttonGetResults.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonGetResults.BackColor = System.Drawing.Color.White;
            this.buttonGetResults.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonGetResults.Image = ((System.Drawing.Image)(resources.GetObject("buttonGetResults.Image")));
            this.buttonGetResults.Location = new System.Drawing.Point(747, 4);
            this.buttonGetResults.Name = "buttonGetResults";
            this.buttonGetResults.Size = new System.Drawing.Size(160, 46);
            this.buttonGetResults.TabIndex = 1;
            this.buttonGetResults.Text = "&Get Job Information";
            this.buttonGetResults.Click += new System.EventHandler(this.buttonGetResults_Click);
            // 
            // contextMenuStripJobList
            // 
            this.contextMenuStripJobList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuEditJob,
            this.toolStripMenuItem6,
            this.contextMenuCopy,
            this.contextMenuSelectAll,
            this.contextMenuClearAll,
            this.toolStripSeparator2,
            this.contextMenuCheckAllSelected,
            this.contextMenuCheckAll,
            this.contextMenuClearAllChecked,
            this.toolStripMenuItem7,
            this.contextMenuExport});
            this.contextMenuStripJobList.Name = "contextMenuStrip1";
            this.contextMenuStripJobList.Size = new System.Drawing.Size(215, 198);
            this.contextMenuStripJobList.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripJobList_Opening);
            // 
            // contextMenuEditJob
            // 
            this.contextMenuEditJob.Enabled = false;
            this.contextMenuEditJob.Image = ((System.Drawing.Image)(resources.GetObject("contextMenuEditJob.Image")));
            this.contextMenuEditJob.Name = "contextMenuEditJob";
            this.contextMenuEditJob.Size = new System.Drawing.Size(214, 22);
            this.contextMenuEditJob.Text = "&Edit Job";
            this.contextMenuEditJob.Click += new System.EventHandler(this.contextMenuEditJob_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(211, 6);
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.Enabled = false;
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.contextMenuCopy.Size = new System.Drawing.Size(214, 22);
            this.contextMenuCopy.Text = "&Copy to Clipboard";
            this.contextMenuCopy.Click += new System.EventHandler(this.contextMenuCopyToClipboard_Click);
            // 
            // contextMenuSelectAll
            // 
            this.contextMenuSelectAll.Enabled = false;
            this.contextMenuSelectAll.Name = "contextMenuSelectAll";
            this.contextMenuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.contextMenuSelectAll.Size = new System.Drawing.Size(214, 22);
            this.contextMenuSelectAll.Text = "Select &All";
            this.contextMenuSelectAll.Click += new System.EventHandler(this.contextMenuSelectAll_Click);
            // 
            // contextMenuClearAll
            // 
            this.contextMenuClearAll.Enabled = false;
            this.contextMenuClearAll.Name = "contextMenuClearAll";
            this.contextMenuClearAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.contextMenuClearAll.Size = new System.Drawing.Size(214, 22);
            this.contextMenuClearAll.Text = "C&lear All";
            this.contextMenuClearAll.Click += new System.EventHandler(this.contextMenuClearAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // contextMenuCheckAllSelected
            // 
            this.contextMenuCheckAllSelected.Enabled = false;
            this.contextMenuCheckAllSelected.Name = "contextMenuCheckAllSelected";
            this.contextMenuCheckAllSelected.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.contextMenuCheckAllSelected.Size = new System.Drawing.Size(214, 22);
            this.contextMenuCheckAllSelected.Text = "C&heck All Selected";
            this.contextMenuCheckAllSelected.Click += new System.EventHandler(this.contextMenuCheckAllSelected_Click);
            // 
            // contextMenuCheckAll
            // 
            this.contextMenuCheckAll.Enabled = false;
            this.contextMenuCheckAll.Name = "contextMenuCheckAll";
            this.contextMenuCheckAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.contextMenuCheckAll.Size = new System.Drawing.Size(214, 22);
            this.contextMenuCheckAll.Text = "Chec&k All";
            this.contextMenuCheckAll.Click += new System.EventHandler(this.contextMenuCheckAll_Click);
            // 
            // contextMenuClearAllChecked
            // 
            this.contextMenuClearAllChecked.Enabled = false;
            this.contextMenuClearAllChecked.Name = "contextMenuClearAllChecked";
            this.contextMenuClearAllChecked.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.contextMenuClearAllChecked.Size = new System.Drawing.Size(214, 22);
            this.contextMenuClearAllChecked.Text = "&Uncheck All";
            this.contextMenuClearAllChecked.Click += new System.EventHandler(this.contextMenuClearAllChecked_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(211, 6);
            // 
            // contextMenuExport
            // 
            this.contextMenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuCSV,
            this.contextMenuXML});
            this.contextMenuExport.Enabled = false;
            this.contextMenuExport.Name = "contextMenuExport";
            this.contextMenuExport.Size = new System.Drawing.Size(214, 22);
            this.contextMenuExport.Text = "&Save Results As";
            // 
            // contextMenuCSV
            // 
            this.contextMenuCSV.Name = "contextMenuCSV";
            this.contextMenuCSV.Size = new System.Drawing.Size(258, 22);
            this.contextMenuCSV.Text = "CSV File (comma separated values)";
            this.contextMenuCSV.Click += new System.EventHandler(this.contextMenuCSV_Click);
            // 
            // contextMenuXML
            // 
            this.contextMenuXML.Name = "contextMenuXML";
            this.contextMenuXML.Size = new System.Drawing.Size(258, 22);
            this.contextMenuXML.Text = "XML File";
            this.contextMenuXML.Click += new System.EventHandler(this.contextMenuXML_Click);
            // 
            // imageListCheckboxes
            // 
            this.imageListCheckboxes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCheckboxes.ImageStream")));
            this.imageListCheckboxes.TransparentColor = System.Drawing.Color.Black;
            this.imageListCheckboxes.Images.SetKeyName(0, "RibbonCheckboxUnchecked.png");
            this.imageListCheckboxes.Images.SetKeyName(1, "RibbonCheckboxChecked.png");
            // 
            // groupResults
            // 
            this.groupResults.BackColor = System.Drawing.Color.Transparent;
            this.groupResults.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupResults.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupResults.Controls.Add(this.groupStatistics);
            this.groupResults.Controls.Add(this.buttonSelectJobs);
            this.groupResults.Controls.Add(this.labelEmptyResultSet);
            this.groupResults.Controls.Add(this.labelJobList);
            this.groupResults.Controls.Add(this.dataGridViewJobs);
            this.groupResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupResults.IsShadowEnabled = true;
            this.groupResults.Location = new System.Drawing.Point(6, 3);
            this.groupResults.Name = "groupResults";
            this.groupResults.Size = new System.Drawing.Size(927, 299);
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
            this.groupResults.TabIndex = 5;
            this.groupResults.Text = "Job List";
            // 
            // groupStatistics
            // 
            this.groupStatistics.BackColor = System.Drawing.Color.Transparent;
            this.groupStatistics.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupStatistics.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupStatistics.Controls.Add(this.pictureBoxNotNotifying);
            this.groupStatistics.Controls.Add(this.labelNotNotifying);
            this.groupStatistics.Controls.Add(this.labelServersScanned);
            this.groupStatistics.Controls.Add(this.pictureBoxServersScanned);
            this.groupStatistics.Controls.Add(this.pictureBoxNewJobs);
            this.groupStatistics.Controls.Add(this.labelNewJobs);
            this.groupStatistics.Controls.Add(this.labelFailed);
            this.groupStatistics.Controls.Add(this.pictureBoxFailed);
            this.groupStatistics.Controls.Add(this.pictureBoxNotRecent);
            this.groupStatistics.Controls.Add(this.labelNotRecent);
            this.groupStatistics.Location = new System.Drawing.Point(3, 5);
            this.groupStatistics.Name = "groupStatistics";
            this.groupStatistics.Size = new System.Drawing.Size(915, 42);
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
            this.groupStatistics.TabIndex = 33;
            // 
            // pictureBoxNotNotifying
            // 
            this.pictureBoxNotNotifying.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxNotNotifying.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNotNotifying.Image")));
            this.pictureBoxNotNotifying.Location = new System.Drawing.Point(520, 10);
            this.pictureBoxNotNotifying.Name = "pictureBoxNotNotifying";
            this.pictureBoxNotNotifying.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxNotNotifying.TabIndex = 62;
            this.pictureBoxNotNotifying.TabStop = false;
            // 
            // labelNotNotifying
            // 
            this.labelNotNotifying.AutoSize = true;
            this.labelNotNotifying.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelNotNotifying.BackgroundStyle.Class = "";
            this.labelNotNotifying.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelNotNotifying.Location = new System.Drawing.Point(542, 10);
            this.labelNotNotifying.Name = "labelNotNotifying";
            this.labelNotNotifying.Size = new System.Drawing.Size(159, 15);
            this.labelNotNotifying.TabIndex = 61;
            this.labelNotNotifying.Text = "Jobs not notifying the Event Log";
            this.labelNotNotifying.WordWrap = true;
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
            // pictureBoxServersScanned
            // 
            this.pictureBoxServersScanned.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxServersScanned.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxServersScanned.Image")));
            this.pictureBoxServersScanned.Location = new System.Drawing.Point(14, 10);
            this.pictureBoxServersScanned.Name = "pictureBoxServersScanned";
            this.pictureBoxServersScanned.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxServersScanned.TabIndex = 59;
            this.pictureBoxServersScanned.TabStop = false;
            // 
            // pictureBoxNewJobs
            // 
            this.pictureBoxNewJobs.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxNewJobs.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNewJobs.Image")));
            this.pictureBoxNewJobs.Location = new System.Drawing.Point(730, 10);
            this.pictureBoxNewJobs.Name = "pictureBoxNewJobs";
            this.pictureBoxNewJobs.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxNewJobs.TabIndex = 58;
            this.pictureBoxNewJobs.TabStop = false;
            // 
            // labelNewJobs
            // 
            this.labelNewJobs.AutoSize = true;
            this.labelNewJobs.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelNewJobs.BackgroundStyle.Class = "";
            this.labelNewJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelNewJobs.Location = new System.Drawing.Point(752, 10);
            this.labelNewJobs.Name = "labelNewJobs";
            this.labelNewJobs.Size = new System.Drawing.Size(121, 15);
            this.labelNewJobs.TabIndex = 53;
            this.labelNewJobs.Text = "New jobs in last 30 days";
            this.labelNewJobs.WordWrap = true;
            // 
            // labelFailed
            // 
            this.labelFailed.AutoSize = true;
            this.labelFailed.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelFailed.BackgroundStyle.Class = "";
            this.labelFailed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelFailed.Location = new System.Drawing.Point(196, 10);
            this.labelFailed.Name = "labelFailed";
            this.labelFailed.Size = new System.Drawing.Size(109, 15);
            this.labelFailed.TabIndex = 38;
            this.labelFailed.Text = "Jobs failed on last run";
            this.labelFailed.WordWrap = true;
            // 
            // pictureBoxFailed
            // 
            this.pictureBoxFailed.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxFailed.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFailed.Image")));
            this.pictureBoxFailed.Location = new System.Drawing.Point(174, 10);
            this.pictureBoxFailed.Name = "pictureBoxFailed";
            this.pictureBoxFailed.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxFailed.TabIndex = 37;
            this.pictureBoxFailed.TabStop = false;
            // 
            // pictureBoxNotRecent
            // 
            this.pictureBoxNotRecent.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxNotRecent.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNotRecent.Image")));
            this.pictureBoxNotRecent.Location = new System.Drawing.Point(322, 10); //334
            this.pictureBoxNotRecent.Name = "pictureBoxNotRecent";
            this.pictureBoxNotRecent.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxNotRecent.TabIndex = 49;
            this.pictureBoxNotRecent.TabStop = false;
            // 
            // labelNotRecent
            // 
            this.labelNotRecent.AutoSize = true;
            this.labelNotRecent.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelNotRecent.BackgroundStyle.Class = "";
            this.labelNotRecent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelNotRecent.Location = new System.Drawing.Point(344, 10); //356
            this.labelNotRecent.Name = "labelNotRecent";
            this.labelNotRecent.Size = new System.Drawing.Size(136, 15); 
            this.labelNotRecent.TabIndex = 46;
            this.labelNotRecent.Text = "Jobs not run in last 14 days";
            this.labelNotRecent.WordWrap = true;
            // 
            // buttonSelectJobs
            // 
            this.buttonSelectJobs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSelectJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectJobs.BackColor = System.Drawing.Color.White;
            this.buttonSelectJobs.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSelectJobs.Enabled = false;
            this.buttonSelectJobs.Location = new System.Drawing.Point(728, 53);
            this.buttonSelectJobs.Name = "buttonSelectJobs";
            this.buttonSelectJobs.Size = new System.Drawing.Size(186, 16);
            this.buttonSelectJobs.TabIndex = 4;
            this.buttonSelectJobs.Text = "C&heck Jobs by Property Values";
            this.buttonSelectJobs.Click += new System.EventHandler(this.buttonSelectJobs_Click);
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
            this.labelEmptyResultSet.Location = new System.Drawing.Point(5, 117);
            this.labelEmptyResultSet.Name = "labelEmptyResultSet";
            this.labelEmptyResultSet.Size = new System.Drawing.Size(909, 79);
            this.labelEmptyResultSet.TabIndex = 32;
            this.labelEmptyResultSet.Text = "No data available";
            this.labelEmptyResultSet.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelEmptyResultSet.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.labelEmptyResultSet.Visible = false;
            this.labelEmptyResultSet.WordWrap = true;
            // 
            // labelJobList
            // 
            this.labelJobList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelJobList.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelJobList.BackgroundStyle.Class = "";
            this.labelJobList.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelJobList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJobList.Location = new System.Drawing.Point(4, 53);
            this.labelJobList.Name = "labelJobList";
            this.labelJobList.Size = new System.Drawing.Size(718, 20);
            this.labelJobList.TabIndex = 29;
            this.labelJobList.Text = "Job Information for each Job";
            // 
            // dataGridViewJobs
            // 
            this.dataGridViewJobs.AllowUserToAddRows = false;
            this.dataGridViewJobs.AllowUserToDeleteRows = false;
            this.dataGridViewJobs.AllowUserToOrderColumns = true;
            this.dataGridViewJobs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.dataGridViewJobs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewJobs.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewJobs.ContextMenuStrip = this.contextMenuStripJobList;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewJobs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewJobs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewJobs.HighlightSelectedColumnHeaders = false;
            this.dataGridViewJobs.Location = new System.Drawing.Point(3, 75);
            this.dataGridViewJobs.Name = "dataGridViewJobs";
            this.dataGridViewJobs.RowHeadersVisible = false;
            this.dataGridViewJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewJobs.ShowEditingIcon = false;
            this.dataGridViewJobs.Size = new System.Drawing.Size(915, 203);
            this.dataGridViewJobs.TabIndex = 34;
            this.dataGridViewJobs.DataSourceChanged += new System.EventHandler(this.dataGridViewJobs_DataSourceChanged);
            this.dataGridViewJobs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewJobs_CellContentClick);
            this.dataGridViewJobs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewJobs_CellDoubleClick);
            this.dataGridViewJobs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewJobs_CellFormatting);
            this.dataGridViewJobs.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewJobs_CellMouseDown);
            this.dataGridViewJobs.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewJobs_CellPainting);
            this.dataGridViewJobs.SelectionChanged += new System.EventHandler(this.dataGridViewJobs_SelectionChanged);
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
            this.panelTop.Size = new System.Drawing.Size(939, 52);
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
            this.labelTitle.Size = new System.Drawing.Size(260, 52);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Job Editor</font></b> ";
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
            this.labelSubtitle.Size = new System.Drawing.Size(386, 52);
            this.labelSubtitle.TabIndex = 6;
            this.labelSubtitle.Text = "View and edit jobs across multiple SQL Servers";
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
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.groupResults);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(0, 241);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.panelMiddle.Size = new System.Drawing.Size(939, 308);
            this.panelMiddle.TabIndex = 17;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuTools,
            this.menuHelp});
            this.menuStripMain.Location = new System.Drawing.Point(0, 93);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(939, 24);
            this.menuStripMain.TabIndex = 18;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExport,
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
            this.menuXML});
            this.menuExport.Enabled = false;
            this.menuExport.Name = "menuExport";
            this.menuExport.Size = new System.Drawing.Size(168, 22);
            this.menuExport.Text = "Save Results As";
            // 
            // menuCSV
            // 
            this.menuCSV.Name = "menuCSV";
            this.menuCSV.Size = new System.Drawing.Size(255, 22);
            this.menuCSV.Text = "CSV File(comma separated values)";
            this.menuCSV.Click += new System.EventHandler(this.menuCSV_Click);
            // 
            // menuXML
            // 
            this.menuXML.Name = "menuXML";
            this.menuXML.Size = new System.Drawing.Size(255, 22);
            this.menuXML.Text = "XML File";
            this.menuXML.Click += new System.EventHandler(this.menuXML_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
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
            this.menuEditJob,
            this.toolStripSeparator4,
            this.menuCopy,
            this.menuSelectAll,
            this.menuClearAll,
            this.toolStripSeparator3,
            this.menuCheckAllSelected,
            this.menuCheckAll,
            this.menuClearAllChecked});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(39, 20);
            this.menuEdit.Text = "&Edit";
            // 
            // menuEditJob
            // 
            this.menuEditJob.Enabled = false;
            this.menuEditJob.Name = "menuEditJob";
            this.menuEditJob.Size = new System.Drawing.Size(171, 22);
            this.menuEditJob.Text = "Edit Job";
            this.menuEditJob.Click += new System.EventHandler(this.menuEditJob_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(168, 6);
            // 
            // menuCopy
            // 
            this.menuCopy.Enabled = false;
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.Size = new System.Drawing.Size(171, 22);
            this.menuCopy.Text = "&Copy to Clipboard";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuSelectAll
            // 
            this.menuSelectAll.Enabled = false;
            this.menuSelectAll.Name = "menuSelectAll";
            this.menuSelectAll.Size = new System.Drawing.Size(171, 22);
            this.menuSelectAll.Text = "Select &All";
            this.menuSelectAll.Click += new System.EventHandler(this.menuSelectAll_Click);
            // 
            // menuClearAll
            // 
            this.menuClearAll.Enabled = false;
            this.menuClearAll.Name = "menuClearAll";
            this.menuClearAll.Size = new System.Drawing.Size(171, 22);
            this.menuClearAll.Text = "C&lear All";
            this.menuClearAll.Click += new System.EventHandler(this.menuClearAll_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(168, 6);
            // 
            // menuCheckAllSelected
            // 
            this.menuCheckAllSelected.Enabled = false;
            this.menuCheckAllSelected.Name = "menuCheckAllSelected";
            this.menuCheckAllSelected.Size = new System.Drawing.Size(171, 22);
            this.menuCheckAllSelected.Text = "C&heck All Selected";
            this.menuCheckAllSelected.Click += new System.EventHandler(this.menuCheckAllSelected_Click);
            // 
            // menuCheckAll
            // 
            this.menuCheckAll.Enabled = false;
            this.menuCheckAll.Name = "menuCheckAll";
            this.menuCheckAll.Size = new System.Drawing.Size(171, 22);
            this.menuCheckAll.Text = "Chec&k All";
            this.menuCheckAll.Click += new System.EventHandler(this.menuCheckAll_Click);
            // 
            // menuClearAllChecked
            // 
            this.menuClearAllChecked.Enabled = false;
            this.menuClearAllChecked.Name = "menuClearAllChecked";
            this.menuClearAllChecked.Size = new System.Drawing.Size(171, 22);
            this.menuClearAllChecked.Text = "&Uncheck All";
            this.menuClearAllChecked.Click += new System.EventHandler(this.menuClearAllChecked_Click);
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
            this.menuAbout.Text = "&About Job Editor";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBottom.Controls.Add(this.buttonUpdateJobs);
            this.panelBottom.Controls.Add(this.labelStatus);
            this.panelBottom.Controls.Add(this.buttonCopyToClipboard);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 549);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.panelBottom.Size = new System.Drawing.Size(939, 32);
            this.panelBottom.TabIndex = 19;
            // 
            // buttonUpdateJobs
            // 
            this.buttonUpdateJobs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonUpdateJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdateJobs.BackColor = System.Drawing.Color.White;
            this.buttonUpdateJobs.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonUpdateJobs.Enabled = false;
            this.buttonUpdateJobs.Image = ((System.Drawing.Image)(resources.GetObject("buttonUpdateJobs.Image")));
            this.buttonUpdateJobs.Location = new System.Drawing.Point(609, 4);
            this.buttonUpdateJobs.Name = "buttonUpdateJobs";
            this.buttonUpdateJobs.Size = new System.Drawing.Size(146, 24);
            this.buttonUpdateJobs.TabIndex = 8;
            this.buttonUpdateJobs.Text = "&Update Checked Jobs";
            this.buttonUpdateJobs.Click += new System.EventHandler(this.buttonUpdateJobs_Click);
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
            this.labelStatus.Size = new System.Drawing.Size(53, 15);
            this.labelStatus.TabIndex = 39;
            this.labelStatus.Text = "Total Jobs";
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
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(761, 4);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(169, 24);
            this.buttonCopyToClipboard.TabIndex = 9;
            this.buttonCopyToClipboard.Text = "&Copy Results To Clipboard";
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // ideraTitleBar1
            // 
            this.ideraTitleBar1.ActivateLicenseEventHandler = null;
            this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
            this.ideraTitleBar1.Close = true;
            this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
            this.ideraTitleBar1.IderaProductNameText = "SQL Job Editor";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.IsFormLocked = false;
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = true;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(939, 93);
            this.ideraTitleBar1.TabIndex = 20;
            this.ideraTitleBar1.TrialMode = true;
            this.ideraTitleBar1.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar1_LicenseInfoButtonClick);
            // 
            // ServerSelection
            // 
            this.ServerSelection.BackColor = System.Drawing.Color.Transparent;
            this.ServerSelection.Caption = "";
            this.ServerSelection.CredentialsVisible = true;
            this.ServerSelection.Location = new System.Drawing.Point(5, 4);
            this.ServerSelection.MinimumSize = new System.Drawing.Size(290, 40);
            this.ServerSelection.Name = "ServerSelection";
            this.ServerSelection.SelectionOptions = Idera.SqlAdminToolset.Core.Controls.ServerSelectionOptions.ServersAndGroups;
            this.ServerSelection.Size = new System.Drawing.Size(471, 48);
            this.ServerSelection.TabIndex = 0;
            this.ServerSelection.TextChangedEventHandler = null;
            this.ServerSelection.TextChanged += new System.EventHandler(this.ServerSelection_TextChanged);
            // 
            // Form_Main
            // 
            this.AcceptButton = this.buttonGetResults;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(939, 581);
            this.ControlBox = false;
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelUserInput);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.ideraTitleBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(736, 426);
            this.Name = "Form_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
            this.panelUserInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupPanelSelect.ResumeLayout(false);
            this.contextMenuStripJobList.ResumeLayout(false);
            this.groupResults.ResumeLayout(false);
            this.groupStatistics.ResumeLayout(false);
            this.groupStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotNotifying)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxServersScanned)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFailed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotRecent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJobs)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.panelMiddle.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelUserInput;
       private DevComponents.DotNetBar.Controls.GroupPanel groupPanelSelect;
       private DevComponents.DotNetBar.ButtonX buttonGetResults;
        private DevComponents.DotNetBar.Controls.GroupPanel groupResults;
        private System.Windows.Forms.Panel panelTop;
        private DevComponents.DotNetBar.LabelX labelTitle;
        private DevComponents.DotNetBar.LabelX labelSubtitle;
        private System.Windows.Forms.PictureBox pictureBoxTitle;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.MenuStrip menuStripMain;
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
       private DevComponents.DotNetBar.LabelX labelJobList;
        private DevComponents.DotNetBar.LabelX labelEmptyResultSet;
       private System.Windows.Forms.Panel panelBottom;
       private DevComponents.DotNetBar.LabelX labelStatus;
       private DevComponents.DotNetBar.ButtonX buttonCopyToClipboard;
       private System.Windows.Forms.ImageList imageListCheckboxes;
       private DevComponents.DotNetBar.ButtonX buttonSelectJobs;
       private DevComponents.DotNetBar.ButtonX buttonUpdateJobs;
       private System.Windows.Forms.ContextMenuStrip contextMenuStripJobList;
       private System.Windows.Forms.ToolStripMenuItem contextMenuEditJob;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
       private System.Windows.Forms.ToolStripMenuItem contextMenuCopy;
       private System.Windows.Forms.ToolStripMenuItem contextMenuSelectAll;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
       private System.Windows.Forms.ToolStripMenuItem contextMenuExport;
       private System.Windows.Forms.ToolStripMenuItem contextMenuCSV;
       private System.Windows.Forms.ToolStripMenuItem contextMenuXML;
       private System.Windows.Forms.ToolStripMenuItem menuEdit;
       private System.Windows.Forms.ToolStripMenuItem menuCopy;
       private System.Windows.Forms.ToolStripMenuItem menuSelectAll;
       private System.Windows.Forms.ToolStripMenuItem menuClearAll;
       private System.Windows.Forms.ToolStripMenuItem contextMenuClearAll;
       private System.Windows.Forms.ToolStripMenuItem menuExport;
       private System.Windows.Forms.ToolStripMenuItem menuCSV;
       private System.Windows.Forms.ToolStripMenuItem menuXML;
       private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
       private DevComponents.DotNetBar.Controls.GroupPanel groupStatistics;
       private DevComponents.DotNetBar.LabelX labelServersScanned;
       private System.Windows.Forms.PictureBox pictureBoxServersScanned;
       private System.Windows.Forms.PictureBox pictureBoxNewJobs;
       private DevComponents.DotNetBar.LabelX labelNewJobs;
       private DevComponents.DotNetBar.LabelX labelFailed;
       private System.Windows.Forms.PictureBox pictureBoxFailed;
       private System.Windows.Forms.PictureBox pictureBoxNotRecent;
       private DevComponents.DotNetBar.LabelX labelNotRecent;
       private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewJobs;
       private Idera.SqlAdminToolset.Core.Controls.ToolServerSelection ServerSelection;
       private System.Windows.Forms.ToolStripMenuItem contextMenuCheckAll;
       private System.Windows.Forms.ToolStripMenuItem contextMenuClearAllChecked;
       private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
       private System.Windows.Forms.ToolStripMenuItem contextMenuCheckAllSelected;
       private System.Windows.Forms.PictureBox pictureBoxNotNotifying;
       private DevComponents.DotNetBar.LabelX labelNotNotifying;
       private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
       private System.Windows.Forms.ToolStripMenuItem menuCheckAllSelected;
       private System.Windows.Forms.ToolStripMenuItem menuCheckAll;
       private System.Windows.Forms.ToolStripMenuItem menuClearAllChecked;
       private System.Windows.Forms.ToolStripMenuItem menuEditJob;
       private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
        private DevComponents.DotNetBar.LabelX labeljobstatus;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxjobdayhour;
    }
}

