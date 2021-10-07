namespace Idera.SqlAdminToolset.IndexAnalyzer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonBrowseDatabase = new DevComponents.DotNetBar.ButtonX();
            this.textDatabase = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.checkBoxX_IncludeColumnStats = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this._checkBoxX_CollectStatistics = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this._checkBoxX_CollectFrag = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.textServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelServer = new DevComponents.DotNetBar.LabelX();
            this.buttonCredentials = new DevComponents.DotNetBar.ButtonX();
            this.buttonLoadIndexes = new DevComponents.DotNetBar.ButtonX();
            this.buttonBrowseServer = new DevComponents.DotNetBar.ButtonX();
            this.groupResults = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.advTreeIndexes = new DevComponents.AdvTree.AdvTree();
            this.node1 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.labelX_FilteredIndexes = new DevComponents.DotNetBar.LabelX();
            this.pictureBox_Filter = new System.Windows.Forms.PictureBox();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkBoxX_HideNonClusteredIndexes = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this._textBoxX_Rows = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboBoxExFilter = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.checkBoxX_HideIndexesUnderXRows = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX_HideDisabled = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelTableList = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX_HelpTitle = new DevComponents.DotNetBar.LabelX();
            this.labelX_HelpText = new DevComponents.DotNetBar.LabelX();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.labelAcceptableIndexes = new DevComponents.DotNetBar.LabelX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelCautionIndexes = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxUserDatabases = new System.Windows.Forms.PictureBox();
            this.labelCriticalIndexes = new DevComponents.DotNetBar.LabelX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuXML = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuLoadSelectivity = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuUpdateStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuUpdateStatisticsFullScan = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuIndexProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonX_LoadSelectivity = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_AnalyzeFragmentation = new DevComponents.DotNetBar.ButtonX();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.advTreeColumns = new DevComponents.AdvTree.AdvTree();
            this.node2 = new DevComponents.AdvTree.Node();
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelX_ColumnAcceptable = new DevComponents.DotNetBar.LabelX();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.labelX_ColumnCaution = new DevComponents.DotNetBar.LabelX();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.labelX_ColumnCritical = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this._labelXStatistics = new DevComponents.DotNetBar.LabelX();
            this.dataGridViewX2 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.buttonCopyToClipboard = new DevComponents.DotNetBar.ButtonX();
            this.buttonUpdateFull = new DevComponents.DotNetBar.ButtonX();
            this.buttonUpdate = new DevComponents.DotNetBar.ButtonX();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSavetoCVSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSavetoXMLMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSavetoDatatableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoadSelectivity = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUpdateStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUpdateStatisticsFullScan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIndexProperties = new System.Windows.Forms.ToolStripMenuItem();
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.panelMiddle.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeIndexes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Filter)).BeginInit();
            this.groupPanel5.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserDatabases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeColumns)).BeginInit();
            this.groupPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).BeginInit();
            this.tabControlPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.groupPanel1);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMiddle.Location = new System.Drawing.Point(0, 169);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Padding = new System.Windows.Forms.Padding(3);
            this.panelMiddle.Size = new System.Drawing.Size(1436, 72);
            this.panelMiddle.TabIndex = 14;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.White;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.buttonBrowseDatabase);
            this.groupPanel1.Controls.Add(this.textDatabase);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.checkBoxX_IncludeColumnStats);
            this.groupPanel1.Controls.Add(this._checkBoxX_CollectStatistics);
            this.groupPanel1.Controls.Add(this._checkBoxX_CollectFrag);
            this.groupPanel1.Controls.Add(this.textServer);
            this.groupPanel1.Controls.Add(this.labelServer);
            this.groupPanel1.Controls.Add(this.buttonCredentials);
            this.groupPanel1.Controls.Add(this.buttonLoadIndexes);
            this.groupPanel1.Controls.Add(this.buttonBrowseServer);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.IsShadowEnabled = true;
            this.groupPanel1.Location = new System.Drawing.Point(3, 3);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1430, 66);
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
            // buttonBrowseDatabase
            // 
            this.buttonBrowseDatabase.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseDatabase.BackColor = System.Drawing.Color.White;
            this.buttonBrowseDatabase.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseDatabase.Enabled = false;
            this.buttonBrowseDatabase.Location = new System.Drawing.Point(474, 35);
            this.buttonBrowseDatabase.Name = "buttonBrowseDatabase";
            this.buttonBrowseDatabase.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseDatabase.TabIndex = 37;
            this.buttonBrowseDatabase.Text = "...";
            this.buttonBrowseDatabase.Click += new System.EventHandler(this.buttonBrowseDatabase_Click);
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
            this.textDatabase.Location = new System.Drawing.Point(78, 35);
            this.textDatabase.Name = "textDatabase";
            this.textDatabase.Size = new System.Drawing.Size(389, 20);
            this.textDatabase.TabIndex = 36;
            this.textDatabase.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.textDatabase.WatermarkText = "Database name or leave Blank to search All";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelX4.Location = new System.Drawing.Point(12, 39);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(62, 12);
            this.labelX4.TabIndex = 14;
            this.labelX4.Text = "&Database:";
            // 
            // checkBoxX_IncludeColumnStats
            // 
            this.checkBoxX_IncludeColumnStats.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX_IncludeColumnStats.BackgroundStyle.Class = "";
            this.checkBoxX_IncludeColumnStats.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_IncludeColumnStats.Location = new System.Drawing.Point(692, 22);
            this.checkBoxX_IncludeColumnStats.Name = "checkBoxX_IncludeColumnStats";
            this.checkBoxX_IncludeColumnStats.Size = new System.Drawing.Size(307, 18);
            this.checkBoxX_IncludeColumnStats.TabIndex = 8;
            this.checkBoxX_IncludeColumnStats.Text = "(unused) &Include Column Statistics";
            this.checkBoxX_IncludeColumnStats.Visible = false;
            this.checkBoxX_IncludeColumnStats.CheckedChanged += new System.EventHandler(this.checkBoxX_IncludeColumnStats_CheckedChanged);
            // 
            // _checkBoxX_CollectStatistics
            // 
            this._checkBoxX_CollectStatistics.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this._checkBoxX_CollectStatistics.BackgroundStyle.Class = "";
            this._checkBoxX_CollectStatistics.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._checkBoxX_CollectStatistics.Location = new System.Drawing.Point(692, 3);
            this._checkBoxX_CollectStatistics.Name = "_checkBoxX_CollectStatistics";
            this._checkBoxX_CollectStatistics.Size = new System.Drawing.Size(307, 18);
            this._checkBoxX_CollectStatistics.TabIndex = 7;
            this._checkBoxX_CollectStatistics.Text = "Load &Selectivity while loading Statistics";
            this._checkBoxX_CollectStatistics.CheckedChanged += new System.EventHandler(this._checkBoxX_CollectStatistics_CheckedChanged);
            // 
            // _checkBoxX_CollectFrag
            // 
            this._checkBoxX_CollectFrag.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this._checkBoxX_CollectFrag.BackgroundStyle.Class = "";
            this._checkBoxX_CollectFrag.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._checkBoxX_CollectFrag.Location = new System.Drawing.Point(692, 41);
            this._checkBoxX_CollectFrag.Name = "_checkBoxX_CollectFrag";
            this._checkBoxX_CollectFrag.Size = new System.Drawing.Size(307, 18);
            this._checkBoxX_CollectFrag.TabIndex = 6;
            this._checkBoxX_CollectFrag.Text = "(unused) Analyze index fragmentation while loading index statistics";
            this._checkBoxX_CollectFrag.Visible = false;
            this._checkBoxX_CollectFrag.CheckedChanged += new System.EventHandler(this._checkBoxX_CollectFrag_CheckedChanged);
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
            this.textServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textServer.Location = new System.Drawing.Point(78, 7);
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(389, 20);
            this.textServer.TabIndex = 2;
            this.textServer.Text = "(local)";
            this.textServer.WatermarkText = "Enter instance name";
            this.textServer.TextChanged += new System.EventHandler(this.textServer_TextChanged);
            // 
            // labelServer
            // 
            this.labelServer.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelServer.BackgroundStyle.Class = "";
            this.labelServer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelServer.Location = new System.Drawing.Point(12, 10);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(62, 12);
            this.labelServer.TabIndex = 1;
            this.labelServer.Text = "&SQL Server:";
            // 
            // buttonCredentials
            // 
            this.buttonCredentials.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCredentials.BackColor = System.Drawing.Color.White;
            this.buttonCredentials.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCredentials.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.buttonCredentials_Image;
            this.buttonCredentials.Location = new System.Drawing.Point(498, 7);
            this.buttonCredentials.Name = "buttonCredentials";
            this.buttonCredentials.Size = new System.Drawing.Size(20, 20);
            this.buttonCredentials.TabIndex = 4;
            this.buttonCredentials.Click += new System.EventHandler(this.buttonCredentials_Click);
            // 
            // buttonLoadIndexes
            // 
            this.buttonLoadIndexes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonLoadIndexes.BackColor = System.Drawing.Color.White;
            this.buttonLoadIndexes.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonLoadIndexes.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoadIndexes.Image")));
            this.buttonLoadIndexes.Location = new System.Drawing.Point(526, 4);
            this.buttonLoadIndexes.Name = "buttonLoadIndexes";
            this.buttonLoadIndexes.Size = new System.Drawing.Size(160, 46);
            this.buttonLoadIndexes.TabIndex = 5;
            this.buttonLoadIndexes.Text = "&Load Statistics";
            this.buttonLoadIndexes.Click += new System.EventHandler(this.buttonGetResults_Click);
            // 
            // buttonBrowseServer
            // 
            this.buttonBrowseServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseServer.BackColor = System.Drawing.Color.White;
            this.buttonBrowseServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseServer.Location = new System.Drawing.Point(473, 7);
            this.buttonBrowseServer.Name = "buttonBrowseServer";
            this.buttonBrowseServer.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseServer.TabIndex = 3;
            this.buttonBrowseServer.Text = "...";
            this.buttonBrowseServer.Click += new System.EventHandler(this.buttonBrowseServer_Click);
            // 
            // groupResults
            // 
            this.groupResults.BackColor = System.Drawing.Color.Transparent;
            this.groupResults.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupResults.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupResults.Controls.Add(this.splitContainer1);
            this.groupResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupResults.IsShadowEnabled = true;
            this.groupResults.Location = new System.Drawing.Point(1, 1);
            this.groupResults.Name = "groupResults";
            this.groupResults.Size = new System.Drawing.Size(1228, 443);
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
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.advTreeIndexes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelX_FilteredIndexes);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox_Filter);
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel5);
            this.splitContainer1.Panel2.Controls.Add(this.labelTableList);
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel2);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewX1);
            this.splitContainer1.Size = new System.Drawing.Size(1222, 437);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 2;
            // 
            // advTreeIndexes
            // 
            this.advTreeIndexes.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeIndexes.AllowDrop = true;
            this.advTreeIndexes.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTreeIndexes.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeIndexes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTreeIndexes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTreeIndexes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTreeIndexes.Location = new System.Drawing.Point(0, 0);
            this.advTreeIndexes.Name = "advTreeIndexes";
            this.advTreeIndexes.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.advTreeIndexes.NodesConnector = this.nodeConnector1;
            this.advTreeIndexes.NodeStyle = this.elementStyle1;
            this.advTreeIndexes.PathSeparator = ";";
            this.advTreeIndexes.Size = new System.Drawing.Size(260, 437);
            this.advTreeIndexes.Styles.Add(this.elementStyle1);
            this.advTreeIndexes.TabIndex = 2;
            this.advTreeIndexes.Text = "advTree1";
            this.advTreeIndexes.AfterNodeSelect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.advTreeIndexes_AfterNodeSelect);
            this.advTreeIndexes.MouseHover += new System.EventHandler(this.advTreeIndexes_MouseHover);
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Text = "No Indexes Loaded";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.Class = "";
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // labelX_FilteredIndexes
            // 
            this.labelX_FilteredIndexes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX_FilteredIndexes.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX_FilteredIndexes.BackgroundStyle.Class = "";
            this.labelX_FilteredIndexes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_FilteredIndexes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX_FilteredIndexes.Location = new System.Drawing.Point(520, 112);
            this.labelX_FilteredIndexes.Name = "labelX_FilteredIndexes";
            this.labelX_FilteredIndexes.Size = new System.Drawing.Size(405, 18);
            this.labelX_FilteredIndexes.TabIndex = 73;
            this.labelX_FilteredIndexes.Text = "12234567 indexes hidden (1234567 total) as of 8/24/01 10:24:00 AM";
            this.labelX_FilteredIndexes.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // pictureBox_Filter
            // 
            this.pictureBox_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Filter.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Filter.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.filter_24;
            this.pictureBox_Filter.Location = new System.Drawing.Point(934, 108);
            this.pictureBox_Filter.Name = "pictureBox_Filter";
            this.pictureBox_Filter.Size = new System.Drawing.Size(24, 24);
            this.pictureBox_Filter.TabIndex = 72;
            this.pictureBox_Filter.TabStop = false;
            // 
            // groupPanel5
            // 
            this.groupPanel5.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.checkBoxX_HideNonClusteredIndexes);
            this.groupPanel5.Controls.Add(this.labelX1);
            this.groupPanel5.Controls.Add(this._textBoxX_Rows);
            this.groupPanel5.Controls.Add(this.comboBoxExFilter);
            this.groupPanel5.Controls.Add(this.checkBoxX_HideIndexesUnderXRows);
            this.groupPanel5.Controls.Add(this.checkBoxX_HideDisabled);
            this.groupPanel5.Location = new System.Drawing.Point(1, 1);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(237, 106);
            // 
            // 
            // 
            this.groupPanel5.Style.BackColor = System.Drawing.Color.White;
            this.groupPanel5.Style.BackColor2 = System.Drawing.Color.White;
            this.groupPanel5.Style.BackColorGradientAngle = 90;
            this.groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderBottomWidth = 1;
            this.groupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderLeftWidth = 1;
            this.groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderRightWidth = 1;
            this.groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderTopWidth = 1;
            this.groupPanel5.Style.Class = "";
            this.groupPanel5.Style.CornerDiameter = 4;
            this.groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseDown.Class = "";
            this.groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseOver.Class = "";
            this.groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel5.TabIndex = 17;
            this.groupPanel5.Text = "View Options";
            // 
            // checkBoxX_HideNonClusteredIndexes
            // 
            // 
            // 
            // 
            this.checkBoxX_HideNonClusteredIndexes.BackgroundStyle.Class = "";
            this.checkBoxX_HideNonClusteredIndexes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_HideNonClusteredIndexes.Checked = true;
            this.checkBoxX_HideNonClusteredIndexes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxX_HideNonClusteredIndexes.CheckValue = "Y";
            this.checkBoxX_HideNonClusteredIndexes.Location = new System.Drawing.Point(6, 68);
            this.checkBoxX_HideNonClusteredIndexes.Name = "checkBoxX_HideNonClusteredIndexes";
            this.checkBoxX_HideNonClusteredIndexes.Size = new System.Drawing.Size(177, 18);
            this.checkBoxX_HideNonClusteredIndexes.TabIndex = 18;
            this.checkBoxX_HideNonClusteredIndexes.Text = "Hide Non-Clustered Indexes";
            this.checkBoxX_HideNonClusteredIndexes.CheckedChanged += new System.EventHandler(this.checkBoxX_HideNonClusteredIndexes_CheckedChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(189, 26);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 18);
            this.labelX1.TabIndex = 17;
            this.labelX1.Text = "rows";
            // 
            // _textBoxX_Rows
            // 
            // 
            // 
            // 
            this._textBoxX_Rows.Border.Class = "TextBoxBorder";
            this._textBoxX_Rows.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._textBoxX_Rows.Location = new System.Drawing.Point(126, 27);
            this._textBoxX_Rows.MaxLength = 10;
            this._textBoxX_Rows.Name = "_textBoxX_Rows";
            this._textBoxX_Rows.Size = new System.Drawing.Size(57, 20);
            this._textBoxX_Rows.TabIndex = 16;
            this._textBoxX_Rows.Text = "10";
            this._textBoxX_Rows.TextChanged += new System.EventHandler(this._textBoxX_Rows_TextChanged);
            this._textBoxX_Rows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textBoxX_Rows_KeyPress);
            // 
            // comboBoxExFilter
            // 
            this.comboBoxExFilter.DisplayMember = "Text";
            this.comboBoxExFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxExFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxExFilter.FormattingEnabled = true;
            this.comboBoxExFilter.ItemHeight = 14;
            this.comboBoxExFilter.Location = new System.Drawing.Point(8, 3);
            this.comboBoxExFilter.Name = "comboBoxExFilter";
            this.comboBoxExFilter.Size = new System.Drawing.Size(217, 20);
            this.comboBoxExFilter.TabIndex = 12;
            this.comboBoxExFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxExFilter_SelectedIndexChanged);
            // 
            // checkBoxX_HideIndexesUnderXRows
            // 
            // 
            // 
            // 
            this.checkBoxX_HideIndexesUnderXRows.BackgroundStyle.Class = "";
            this.checkBoxX_HideIndexesUnderXRows.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_HideIndexesUnderXRows.Checked = true;
            this.checkBoxX_HideIndexesUnderXRows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxX_HideIndexesUnderXRows.CheckValue = "Y";
            this.checkBoxX_HideIndexesUnderXRows.Location = new System.Drawing.Point(6, 26);
            this.checkBoxX_HideIndexesUnderXRows.Name = "checkBoxX_HideIndexesUnderXRows";
            this.checkBoxX_HideIndexesUnderXRows.Size = new System.Drawing.Size(117, 18);
            this.checkBoxX_HideIndexesUnderXRows.TabIndex = 15;
            this.checkBoxX_HideIndexesUnderXRows.Text = "Hide Indexes under ";
            this.checkBoxX_HideIndexesUnderXRows.CheckedChanged += new System.EventHandler(this.checkBoxX_HideIndexesUnderXRows_CheckedChanged);
            // 
            // checkBoxX_HideDisabled
            // 
            // 
            // 
            // 
            this.checkBoxX_HideDisabled.BackgroundStyle.Class = "";
            this.checkBoxX_HideDisabled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_HideDisabled.Checked = true;
            this.checkBoxX_HideDisabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxX_HideDisabled.CheckValue = "Y";
            this.checkBoxX_HideDisabled.Location = new System.Drawing.Point(6, 47);
            this.checkBoxX_HideDisabled.Name = "checkBoxX_HideDisabled";
            this.checkBoxX_HideDisabled.Size = new System.Drawing.Size(146, 18);
            this.checkBoxX_HideDisabled.TabIndex = 14;
            this.checkBoxX_HideDisabled.Text = "Hide Disabled Indexes";
            this.checkBoxX_HideDisabled.CheckedChanged += new System.EventHandler(this.checkBoxX_HideDisabled_CheckedChanged);
            // 
            // labelTableList
            // 
            this.labelTableList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTableList.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelTableList.BackgroundStyle.Class = "";
            this.labelTableList.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTableList.Location = new System.Drawing.Point(0, 112);
            this.labelTableList.Name = "labelTableList";
            this.labelTableList.Size = new System.Drawing.Size(900, 18);
            this.labelTableList.TabIndex = 11;
            this.labelTableList.Text = "Indexes";
            // 
            // groupPanel2
            // 
            this.groupPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.labelX_HelpTitle);
            this.groupPanel2.Controls.Add(this.labelX_HelpText);
            this.groupPanel2.Controls.Add(this.pictureBox3);
            this.groupPanel2.Controls.Add(this.labelAcceptableIndexes);
            this.groupPanel2.Controls.Add(this.pictureBox1);
            this.groupPanel2.Controls.Add(this.labelCautionIndexes);
            this.groupPanel2.Controls.Add(this.pictureBoxUserDatabases);
            this.groupPanel2.Controls.Add(this.labelCriticalIndexes);
            this.groupPanel2.IsShadowEnabled = true;
            this.groupPanel2.Location = new System.Drawing.Point(243, 1);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(713, 106);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor = System.Drawing.Color.White;
            this.groupPanel2.Style.BackColor2 = System.Drawing.Color.White;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
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
            this.groupPanel2.TabIndex = 10;
            this.groupPanel2.Text = "Summary";
            // 
            // labelX_HelpTitle
            // 
            this.labelX_HelpTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX_HelpTitle.BackgroundStyle.Class = "";
            this.labelX_HelpTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_HelpTitle.Location = new System.Drawing.Point(4, 2);
            this.labelX_HelpTitle.Name = "labelX_HelpTitle";
            this.labelX_HelpTitle.Size = new System.Drawing.Size(316, 16);
            this.labelX_HelpTitle.TabIndex = 73;
            this.labelX_HelpTitle.Text = "<b><u>Index Usefulness Summary</u></b>";
            // 
            // labelX_HelpText
            // 
            this.labelX_HelpText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX_HelpText.BackgroundStyle.Class = "";
            this.labelX_HelpText.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_HelpText.Location = new System.Drawing.Point(4, 16);
            this.labelX_HelpText.Name = "labelX_HelpText";
            this.labelX_HelpText.Size = new System.Drawing.Size(298, 0);
            this.labelX_HelpText.TabIndex = 72;
            this.labelX_HelpText.Text = "provides a summary of the usefulness of the index based on the measured values of" +
    " Fragmentation, Selectivity, % of Index Updates to Total Index Accesses and the " +
    "age of the statistics.";
            this.labelX_HelpText.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.labelX_HelpText.WordWrap = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.I_AcceptableFiltered;
            this.pictureBox3.Location = new System.Drawing.Point(325, 56);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 71;
            this.pictureBox3.TabStop = false;
            // 
            // labelAcceptableIndexes
            // 
            this.labelAcceptableIndexes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAcceptableIndexes.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelAcceptableIndexes.BackgroundStyle.Class = "";
            this.labelAcceptableIndexes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelAcceptableIndexes.Location = new System.Drawing.Point(346, 56);
            this.labelAcceptableIndexes.Name = "labelAcceptableIndexes";
            this.labelAcceptableIndexes.Size = new System.Drawing.Size(312, 14);
            this.labelAcceptableIndexes.TabIndex = 69;
            this.labelAcceptableIndexes.Text = "Acceptable";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.I_CautionFiltered;
            this.pictureBox1.Location = new System.Drawing.Point(326, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 67;
            this.pictureBox1.TabStop = false;
            // 
            // labelCautionIndexes
            // 
            this.labelCautionIndexes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCautionIndexes.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelCautionIndexes.BackgroundStyle.Class = "";
            this.labelCautionIndexes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelCautionIndexes.Location = new System.Drawing.Point(346, 32);
            this.labelCautionIndexes.Name = "labelCautionIndexes";
            this.labelCautionIndexes.Size = new System.Drawing.Size(312, 14);
            this.labelCautionIndexes.TabIndex = 65;
            this.labelCautionIndexes.Text = "Caution";
            // 
            // pictureBoxUserDatabases
            // 
            this.pictureBoxUserDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxUserDatabases.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxUserDatabases.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.I_CriticalFiltered;
            this.pictureBoxUserDatabases.Location = new System.Drawing.Point(326, 6);
            this.pictureBoxUserDatabases.Name = "pictureBoxUserDatabases";
            this.pictureBoxUserDatabases.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxUserDatabases.TabIndex = 63;
            this.pictureBoxUserDatabases.TabStop = false;
            // 
            // labelCriticalIndexes
            // 
            this.labelCriticalIndexes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCriticalIndexes.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelCriticalIndexes.BackgroundStyle.Class = "";
            this.labelCriticalIndexes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelCriticalIndexes.Location = new System.Drawing.Point(346, 8);
            this.labelCriticalIndexes.Name = "labelCriticalIndexes";
            this.labelCriticalIndexes.Size = new System.Drawing.Size(312, 14);
            this.labelCriticalIndexes.TabIndex = 61;
            this.labelCriticalIndexes.Text = "123456 Indexes with 50% or more Updates to Total Accessess";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToOrderColumns = true;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.dataGridViewX1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.HighlightSelectedColumnHeaders = false;
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 133);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(958, 304);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellDoubleClick);
            this.dataGridViewX1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewX1_CellFormatting);
            this.dataGridViewX1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_CellMouseDown);
            this.dataGridViewX1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewX1_CellPainting);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            this.dataGridViewX1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewX1_MouseDown);
            this.dataGridViewX1.MouseHover += new System.EventHandler(this.dataGridViewX1_MouseHover);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuCopy,
            this.contextMenuSelectAll,
            this.toolStripMenuItem7,
            this.contextMenuExport,
            this.contextMenuLoadSelectivity,
            this.contextMenuUpdateStatistics,
            this.contextMenuUpdateStatisticsFullScan,
            this.contextMenuIndexProperties});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(267, 164);
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.Enabled = false;
            this.contextMenuCopy.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.copy_16;
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.contextMenuCopy.Size = new System.Drawing.Size(266, 22);
            this.contextMenuCopy.Text = "&Copy";
            this.contextMenuCopy.Click += new System.EventHandler(this.contextMenuCopy_Click);
            // 
            // contextMenuSelectAll
            // 
            this.contextMenuSelectAll.Enabled = false;
            this.contextMenuSelectAll.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.table_selection_all_16;
            this.contextMenuSelectAll.Name = "contextMenuSelectAll";
            this.contextMenuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.contextMenuSelectAll.Size = new System.Drawing.Size(266, 22);
            this.contextMenuSelectAll.Text = "Select &All";
            this.contextMenuSelectAll.Click += new System.EventHandler(this.contextMenuSelectAll_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(263, 6);
            // 
            // contextMenuExport
            // 
            this.contextMenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuCSV,
            this.contextMenuXML});
            this.contextMenuExport.Enabled = false;
            this.contextMenuExport.Name = "contextMenuExport";
            this.contextMenuExport.Size = new System.Drawing.Size(266, 22);
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
            // contextMenuLoadSelectivity
            // 
            this.contextMenuLoadSelectivity.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources._16_analyze;
            this.contextMenuLoadSelectivity.Name = "contextMenuLoadSelectivity";
            this.contextMenuLoadSelectivity.Size = new System.Drawing.Size(266, 22);
            this.contextMenuLoadSelectivity.Text = "L&oad Selectivity";
            this.contextMenuLoadSelectivity.Click += new System.EventHandler(this.contextMenuLoadingSelectivity_Click);
            // 
            // contextMenuUpdateStatistics
            // 
            this.contextMenuUpdateStatistics.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.data_refresh_16;
            this.contextMenuUpdateStatistics.Name = "contextMenuUpdateStatistics";
            this.contextMenuUpdateStatistics.Size = new System.Drawing.Size(266, 22);
            this.contextMenuUpdateStatistics.Text = "&Update Selected Statistics";
            this.contextMenuUpdateStatistics.Click += new System.EventHandler(this.contextMenuUpdateStatistics_Click);
            // 
            // contextMenuUpdateStatisticsFullScan
            // 
            this.contextMenuUpdateStatisticsFullScan.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.data_replace_16;
            this.contextMenuUpdateStatisticsFullScan.Name = "contextMenuUpdateStatisticsFullScan";
            this.contextMenuUpdateStatisticsFullScan.Size = new System.Drawing.Size(266, 22);
            this.contextMenuUpdateStatisticsFullScan.Text = "Update Selected Statistics (&Full Scan)";
            this.contextMenuUpdateStatisticsFullScan.Click += new System.EventHandler(this.contextMenuUpdateStatisticsFullScan_Click);
            // 
            // contextMenuIndexProperties
            // 
            this.contextMenuIndexProperties.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.index_view_16;
            this.contextMenuIndexProperties.Name = "contextMenuIndexProperties";
            this.contextMenuIndexProperties.Size = new System.Drawing.Size(266, 22);
            this.contextMenuIndexProperties.Text = "Index &Properties";
            this.contextMenuIndexProperties.Click += new System.EventHandler(this.contextMenuIndexProperties_Click);
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
            this.panelTop.Size = new System.Drawing.Size(1436, 52);
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
            this.labelTitle.Size = new System.Drawing.Size(300, 52);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Index Analyzer</font></b> ";
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
            this.labelSubtitle.Size = new System.Drawing.Size(344, 52);
            this.labelSubtitle.TabIndex = 6;
            this.labelSubtitle.Text = "View and analyze statistics for your columns and indexes";
            // 
            // pictureBoxTitle
            // 
            this.pictureBoxTitle.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTitle.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.index_view_48;
            this.pictureBoxTitle.Location = new System.Drawing.Point(5, 2);
            this.pictureBoxTitle.Name = "pictureBoxTitle";
            this.pictureBoxTitle.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxTitle.TabIndex = 0;
            this.pictureBoxTitle.TabStop = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.buttonX_LoadSelectivity);
            this.panelBottom.Controls.Add(this.buttonX_AnalyzeFragmentation);
            this.panelBottom.Controls.Add(this.tabControl1);
            this.panelBottom.Controls.Add(this.buttonCopyToClipboard);
            this.panelBottom.Controls.Add(this.buttonUpdateFull);
            this.panelBottom.Controls.Add(this.buttonUpdate);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 241);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(3);
            this.panelBottom.Size = new System.Drawing.Size(1436, 431);
            this.panelBottom.TabIndex = 17;
            // 
            // buttonX_LoadSelectivity
            // 
            this.buttonX_LoadSelectivity.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_LoadSelectivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX_LoadSelectivity.BackColor = System.Drawing.Color.White;
            this.buttonX_LoadSelectivity.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_LoadSelectivity.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources._16_analyze;
            this.buttonX_LoadSelectivity.Location = new System.Drawing.Point(721, 393);
            this.buttonX_LoadSelectivity.Name = "buttonX_LoadSelectivity";
            this.buttonX_LoadSelectivity.Size = new System.Drawing.Size(172, 33);
            this.buttonX_LoadSelectivity.TabIndex = 16;
            this.buttonX_LoadSelectivity.Text = "L&oad Selectivity";
            this.buttonX_LoadSelectivity.Tooltip = "Retrieve index Selectivity from SQL Server";
            this.buttonX_LoadSelectivity.Click += new System.EventHandler(this.buttonX_LoadSelectivity_Click);
            // 
            // buttonX_AnalyzeFragmentation
            // 
            this.buttonX_AnalyzeFragmentation.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_AnalyzeFragmentation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX_AnalyzeFragmentation.BackColor = System.Drawing.Color.White;
            this.buttonX_AnalyzeFragmentation.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_AnalyzeFragmentation.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources._16_analyze;
            this.buttonX_AnalyzeFragmentation.Location = new System.Drawing.Point(533, 393);
            this.buttonX_AnalyzeFragmentation.Name = "buttonX_AnalyzeFragmentation";
            this.buttonX_AnalyzeFragmentation.Size = new System.Drawing.Size(172, 33);
            this.buttonX_AnalyzeFragmentation.TabIndex = 15;
            this.buttonX_AnalyzeFragmentation.Text = "(unused) &Analyze Fragmentation";
            this.buttonX_AnalyzeFragmentation.Visible = false;
            this.buttonX_AnalyzeFragmentation.Click += new System.EventHandler(this.buttonX_LoadSelectivity_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.BackColor = System.Drawing.Color.White;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.ColorScheme.TabBackground = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.tabControl1.ColorScheme.TabBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.tabControl1.ColorScheme.TabItemBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(230)))), ((int)(((byte)(249))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(220)))), ((int)(((byte)(248))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(208)))), ((int)(((byte)(245))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(229)))), ((int)(((byte)(247))))), 1F)});
            this.tabControl1.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(235))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(168))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(218)))), ((int)(((byte)(89))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(141))))), 1F)});
            this.tabControl1.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.White, 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254))))), 1F)});
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 1;
            this.tabControl1.Size = new System.Drawing.Size(1430, 385);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabControl1.TabIndex = 14;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Text = "tabControl1";
            this.tabControl1.SelectedTabChanged += new DevComponents.DotNetBar.TabStrip.SelectedTabChangedEventHandler(this.tabControl1_SelectedTabChanged);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.groupPanel3);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 33);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(1430, 352);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.splitContainer2);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel3.IsShadowEnabled = true;
            this.groupPanel3.Location = new System.Drawing.Point(1, 1);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(1428, 350);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.Class = "";
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.Class = "";
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.Class = "";
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 7;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.advTreeColumns);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupPanel4);
            this.splitContainer2.Panel2.Controls.Add(this._labelXStatistics);
            this.splitContainer2.Panel2.Controls.Add(this.dataGridViewX2);
            this.splitContainer2.Size = new System.Drawing.Size(1422, 344);
            this.splitContainer2.SplitterDistance = 302;
            this.splitContainer2.TabIndex = 2;
            // 
            // advTreeColumns
            // 
            this.advTreeColumns.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeColumns.AllowDrop = true;
            this.advTreeColumns.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTreeColumns.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeColumns.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTreeColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTreeColumns.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTreeColumns.Location = new System.Drawing.Point(0, 0);
            this.advTreeColumns.Name = "advTreeColumns";
            this.advTreeColumns.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node2});
            this.advTreeColumns.NodesConnector = this.nodeConnector2;
            this.advTreeColumns.NodeStyle = this.elementStyle2;
            this.advTreeColumns.PathSeparator = ";";
            this.advTreeColumns.Size = new System.Drawing.Size(302, 344);
            this.advTreeColumns.Styles.Add(this.elementStyle2);
            this.advTreeColumns.TabIndex = 0;
            this.advTreeColumns.Text = "advTree1";
            this.advTreeColumns.AfterNodeSelect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.advTreeColumns_AfterNodeSelect);
            this.advTreeColumns.MouseHover += new System.EventHandler(this.advTreeColumns_MouseHover);
            // 
            // node2
            // 
            this.node2.Expanded = true;
            this.node2.Name = "node2";
            this.node2.Text = "No Columns Loaded";
            // 
            // nodeConnector2
            // 
            this.nodeConnector2.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle2
            // 
            this.elementStyle2.Class = "";
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // groupPanel4
            // 
            this.groupPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel4.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.pictureBox2);
            this.groupPanel4.Controls.Add(this.labelX_ColumnAcceptable);
            this.groupPanel4.Controls.Add(this.pictureBox4);
            this.groupPanel4.Controls.Add(this.labelX_ColumnCaution);
            this.groupPanel4.Controls.Add(this.pictureBox5);
            this.groupPanel4.Controls.Add(this.labelX_ColumnCritical);
            this.groupPanel4.Controls.Add(this.labelX3);
            this.groupPanel4.Controls.Add(this.labelX2);
            this.groupPanel4.IsShadowEnabled = true;
            this.groupPanel4.Location = new System.Drawing.Point(3, 3);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(1105, 89);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor = System.Drawing.Color.White;
            this.groupPanel4.Style.BackColor2 = System.Drawing.Color.White;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.Class = "";
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.Class = "";
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.Class = "";
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 12;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.I_AcceptableFiltered;
            this.pictureBox2.Location = new System.Drawing.Point(464, 60);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 77;
            this.pictureBox2.TabStop = false;
            // 
            // labelX_ColumnAcceptable
            // 
            this.labelX_ColumnAcceptable.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX_ColumnAcceptable.BackgroundStyle.Class = "";
            this.labelX_ColumnAcceptable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_ColumnAcceptable.Location = new System.Drawing.Point(485, 60);
            this.labelX_ColumnAcceptable.Name = "labelX_ColumnAcceptable";
            this.labelX_ColumnAcceptable.Size = new System.Drawing.Size(294, 14);
            this.labelX_ColumnAcceptable.TabIndex = 76;
            this.labelX_ColumnAcceptable.Text = "? Statistics 90% or more Selective";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.I_CautionFiltered;
            this.pictureBox4.Location = new System.Drawing.Point(465, 35);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.TabIndex = 75;
            this.pictureBox4.TabStop = false;
            // 
            // labelX_ColumnCaution
            // 
            this.labelX_ColumnCaution.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX_ColumnCaution.BackgroundStyle.Class = "";
            this.labelX_ColumnCaution.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_ColumnCaution.Location = new System.Drawing.Point(485, 36);
            this.labelX_ColumnCaution.Name = "labelX_ColumnCaution";
            this.labelX_ColumnCaution.Size = new System.Drawing.Size(294, 14);
            this.labelX_ColumnCaution.TabIndex = 74;
            this.labelX_ColumnCaution.Text = "? Statistics 60% to 90% Selective";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.I_CriticalFiltered;
            this.pictureBox5.Location = new System.Drawing.Point(465, 10);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 16);
            this.pictureBox5.TabIndex = 73;
            this.pictureBox5.TabStop = false;
            // 
            // labelX_ColumnCritical
            // 
            this.labelX_ColumnCritical.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX_ColumnCritical.BackgroundStyle.Class = "";
            this.labelX_ColumnCritical.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_ColumnCritical.Location = new System.Drawing.Point(485, 12);
            this.labelX_ColumnCritical.Name = "labelX_ColumnCritical";
            this.labelX_ColumnCritical.Size = new System.Drawing.Size(294, 14);
            this.labelX_ColumnCritical.TabIndex = 72;
            this.labelX_ColumnCritical.Text = "? Statistics 60% or less Selective";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(2, 20);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(390, 60);
            this.labelX3.TabIndex = 61;
            this.labelX3.Text = "are automatically generated by SQL Server on frequently used columns that are not" +
    " indexed.  Reviewing these column statistics can provide good insight into which" +
    " columns are candidates for indexing.";
            this.labelX3.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.labelX3.WordWrap = true;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(2, 2);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(324, 17);
            this.labelX2.TabIndex = 62;
            this.labelX2.Text = "<b><u>Column Statistics</u></b>";
            // 
            // _labelXStatistics
            // 
            this._labelXStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._labelXStatistics.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this._labelXStatistics.BackgroundStyle.Class = "";
            this._labelXStatistics.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._labelXStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelXStatistics.Location = new System.Drawing.Point(3, 99);
            this._labelXStatistics.Name = "_labelXStatistics";
            this._labelXStatistics.Size = new System.Drawing.Size(955, 20);
            this._labelXStatistics.TabIndex = 11;
            this._labelXStatistics.Text = "Statistics";
            // 
            // dataGridViewX2
            // 
            this.dataGridViewX2.AllowUserToAddRows = false;
            this.dataGridViewX2.AllowUserToDeleteRows = false;
            this.dataGridViewX2.AllowUserToOrderColumns = true;
            this.dataGridViewX2.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.dataGridViewX2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewX2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewX2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewX2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX2.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX2.HighlightSelectedColumnHeaders = false;
            this.dataGridViewX2.Location = new System.Drawing.Point(0, 121);
            this.dataGridViewX2.Name = "dataGridViewX2";
            this.dataGridViewX2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX2.Size = new System.Drawing.Size(1116, 213);
            this.dataGridViewX2.TabIndex = 0;
            this.dataGridViewX2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewX2_CellFormatting);
            this.dataGridViewX2.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewX2_CellPainting);
            this.dataGridViewX2.SelectionChanged += new System.EventHandler(this.dataGridViewX2_SelectionChanged);
            this.dataGridViewX2.MouseHover += new System.EventHandler(this.dataGridViewX2_MouseHover);
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.column_24;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "Column Statistics";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.groupResults);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 33);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(1230, 445);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            this.tabControlPanel1.Visible = false;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.index_24;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "Index Statistics";
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyToClipboard.BackColor = System.Drawing.Color.White;
            this.buttonCopyToClipboard.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCopyToClipboard.Enabled = false;
            this.buttonCopyToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyToClipboard.Image")));
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(1261, 392);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(160, 34);
            this.buttonCopyToClipboard.TabIndex = 13;
            this.buttonCopyToClipboard.Text = "&Copy Results To Clipboard";
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // buttonUpdateFull
            // 
            this.buttonUpdateFull.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonUpdateFull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdateFull.BackColor = System.Drawing.Color.White;
            this.buttonUpdateFull.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonUpdateFull.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.data_replace_24;
            this.buttonUpdateFull.Location = new System.Drawing.Point(1085, 392);
            this.buttonUpdateFull.Name = "buttonUpdateFull";
            this.buttonUpdateFull.Size = new System.Drawing.Size(160, 34);
            this.buttonUpdateFull.TabIndex = 7;
            this.buttonUpdateFull.Text = "Update Statistics<br></br>(using &Full Scan)";
            this.buttonUpdateFull.Tooltip = "Request SQL Server to recalculate index Statistics by scanning all rows";
            this.buttonUpdateFull.Click += new System.EventHandler(this.buttonUpdateFullScan_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdate.BackColor = System.Drawing.Color.White;
            this.buttonUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonUpdate.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.data_refresh_24;
            this.buttonUpdate.Location = new System.Drawing.Point(909, 392);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(160, 34);
            this.buttonUpdate.TabIndex = 6;
            this.buttonUpdate.Text = "&Update Statistics<br></br>(using Sampling)";
            this.buttonUpdate.Tooltip = "Request SQL Server to recalculate index Statistics by sampling rows";
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.editMenu,
            this.menuTools,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 93);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1436, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileSaveMenu,
            this.printToolStripMenuItem,
            this.toolStripMenuItem5,
            this.menuExitToLaunchpad,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // fileSaveMenu
            // 
            this.fileSaveMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileSavetoCVSMenuItem,
            this.fileSavetoXMLMenuItem,
            this.fileSavetoDatatableMenuItem});
            this.fileSaveMenu.Enabled = false;
            this.fileSaveMenu.Name = "fileSaveMenu";
            this.fileSaveMenu.Size = new System.Drawing.Size(168, 22);
            this.fileSaveMenu.Text = "&Save Results As";
            // 
            // fileSavetoCVSMenuItem
            // 
            this.fileSavetoCVSMenuItem.Name = "fileSavetoCVSMenuItem";
            this.fileSavetoCVSMenuItem.Size = new System.Drawing.Size(258, 22);
            this.fileSavetoCVSMenuItem.Text = "&CSV File (comma separated values)";
            this.fileSavetoCVSMenuItem.Click += new System.EventHandler(this.fileSavetoCVSMenuItem_Click);
            // 
            // fileSavetoXMLMenuItem
            // 
            this.fileSavetoXMLMenuItem.Name = "fileSavetoXMLMenuItem";
            this.fileSavetoXMLMenuItem.Size = new System.Drawing.Size(258, 22);
            this.fileSavetoXMLMenuItem.Text = "&XML File";
            this.fileSavetoXMLMenuItem.Click += new System.EventHandler(this.fileSavetoXMLMenuItem_Click);
            // 
            // fileSavetoDatatableMenuItem
            // 
            this.fileSavetoDatatableMenuItem.Enabled = false;
            this.fileSavetoDatatableMenuItem.Name = "fileSavetoDatatableMenuItem";
            this.fileSavetoDatatableMenuItem.Size = new System.Drawing.Size(258, 22);
            this.fileSavetoDatatableMenuItem.Text = "&Datatable";
            this.fileSavetoDatatableMenuItem.Visible = false;
            this.fileSavetoDatatableMenuItem.Click += new System.EventHandler(this.fileSavetoDatatableMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Enabled = false;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Visible = false;
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
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editCopyMenuItem,
            this.editSelectAllMenuItem,
            this.menuLoadSelectivity,
            this.menuUpdateStatistics,
            this.menuUpdateStatisticsFullScan,
            this.menuIndexProperties});
            this.editMenu.Name = "editMenu";
            this.editMenu.ShowShortcutKeys = false;
            this.editMenu.Size = new System.Drawing.Size(39, 20);
            this.editMenu.Text = "&Edit";
            // 
            // editCopyMenuItem
            // 
            this.editCopyMenuItem.Enabled = false;
            this.editCopyMenuItem.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.copy_16;
            this.editCopyMenuItem.Name = "editCopyMenuItem";
            this.editCopyMenuItem.Size = new System.Drawing.Size(219, 22);
            this.editCopyMenuItem.Text = "&Copy";
            this.editCopyMenuItem.Click += new System.EventHandler(this.editCopyMenuItem_Click);
            // 
            // editSelectAllMenuItem
            // 
            this.editSelectAllMenuItem.Enabled = false;
            this.editSelectAllMenuItem.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.table_selection_all_16;
            this.editSelectAllMenuItem.Name = "editSelectAllMenuItem";
            this.editSelectAllMenuItem.Size = new System.Drawing.Size(219, 22);
            this.editSelectAllMenuItem.Text = "Select &All";
            this.editSelectAllMenuItem.Click += new System.EventHandler(this.editSelectAllMenuItem_Click);
            // 
            // menuLoadSelectivity
            // 
            this.menuLoadSelectivity.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources._16_analyze;
            this.menuLoadSelectivity.Name = "menuLoadSelectivity";
            this.menuLoadSelectivity.Size = new System.Drawing.Size(219, 22);
            this.menuLoadSelectivity.Text = "L&oad Selectivity";
            this.menuLoadSelectivity.Click += new System.EventHandler(this.menuLoadingSelectivity_Click);
            // 
            // menuUpdateStatistics
            // 
            this.menuUpdateStatistics.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.data_refresh_16;
            this.menuUpdateStatistics.Name = "menuUpdateStatistics";
            this.menuUpdateStatistics.Size = new System.Drawing.Size(219, 22);
            this.menuUpdateStatistics.Text = "&Update Statistics";
            this.menuUpdateStatistics.Click += new System.EventHandler(this.menuUpdateStatistics_Click);
            // 
            // menuUpdateStatisticsFullScan
            // 
            this.menuUpdateStatisticsFullScan.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.data_replace_16;
            this.menuUpdateStatisticsFullScan.Name = "menuUpdateStatisticsFullScan";
            this.menuUpdateStatisticsFullScan.Size = new System.Drawing.Size(219, 22);
            this.menuUpdateStatisticsFullScan.Text = "Update Statistics (&Full Scan)";
            this.menuUpdateStatisticsFullScan.Click += new System.EventHandler(this.menuUpdateStatisticsFullScan_Click);
            // 
            // menuIndexProperties
            // 
            this.menuIndexProperties.Image = global::Idera.SqlAdminToolset.IndexAnalyzer.Properties.Resources.index_view_16;
            this.menuIndexProperties.Name = "menuIndexProperties";
            this.menuIndexProperties.Size = new System.Drawing.Size(219, 22);
            this.menuIndexProperties.Text = "Index &Properties";
            this.menuIndexProperties.Click += new System.EventHandler(this.menuIndexProperties_Click);
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "SQLServer_16.png");
            this.imageList1.Images.SetKeyName(1, "Database_16.png");
            this.imageList1.Images.SetKeyName(2, "Table_16.png");
            this.imageList1.Images.SetKeyName(3, "Index_16.png");
            // 
            // ideraTitleBar1
            // 
            this.ideraTitleBar1.ActivateLicenseEventHandler = null;
            this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
            this.ideraTitleBar1.Close = true;
            this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
            this.ideraTitleBar1.IderaProductNameText = "SQL Index Analyzer";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.IsFormLocked = false;
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = true;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(1436, 93);
            this.ideraTitleBar1.TabIndex = 19;
            this.ideraTitleBar1.TrialMode = true;
            this.ideraTitleBar1.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar1_LicenseInfoButtonClick);
            // 
            // Form_Main
            // 
            this.AcceptButton = this.buttonLoadIndexes;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1436, 672);
            this.ControlBox = false;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ideraTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1436, 426);
            this.Name = "Form_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
            this.panelMiddle.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupResults.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTreeIndexes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Filter)).EndInit();
            this.groupPanel5.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserDatabases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTreeColumns)).EndInit();
            this.groupPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX2)).EndInit();
            this.tabControlPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMiddle;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX textServer;
        private DevComponents.DotNetBar.LabelX labelServer;
        private DevComponents.DotNetBar.ButtonX buttonCredentials;
        private DevComponents.DotNetBar.ButtonX buttonLoadIndexes;
        private DevComponents.DotNetBar.ButtonX buttonBrowseServer;
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
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        //  private System.Windows.Forms.DataGridView dataGridViewX1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonX buttonUpdate;
        private DevComponents.DotNetBar.ButtonX buttonUpdateFull;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private DevComponents.DotNetBar.LabelX labelAcceptableIndexes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.LabelX labelCautionIndexes;
        private System.Windows.Forms.PictureBox pictureBoxUserDatabases;
        private DevComponents.DotNetBar.LabelX labelCriticalIndexes;
        private DevComponents.DotNetBar.LabelX labelTableList;
        private DevComponents.DotNetBar.ButtonX buttonCopyToClipboard;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuCopy;
        private System.Windows.Forms.ToolStripMenuItem contextMenuSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExport;
        private System.Windows.Forms.ToolStripMenuItem contextMenuCSV;
        private System.Windows.Forms.ToolStripMenuItem contextMenuXML;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem editSelectAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCopyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSaveMenu;
        private System.Windows.Forms.ToolStripMenuItem fileSavetoCVSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSavetoXMLMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSavetoDatatableMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuUpdateStatistics;
        private System.Windows.Forms.ToolStripMenuItem menuUpdateStatisticsFullScan;
        private System.Windows.Forms.ToolStripMenuItem contextMenuUpdateStatistics;
        private System.Windows.Forms.ToolStripMenuItem contextMenuUpdateStatisticsFullScan;
        private System.Windows.Forms.ToolStripMenuItem menuIndexProperties;
        private System.Windows.Forms.ToolStripMenuItem contextMenuIndexProperties;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevComponents.DotNetBar.LabelX _labelXStatistics;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxExFilter;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.AdvTree advTreeIndexes;
        private DevComponents.AdvTree.AdvTree advTreeColumns;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX _textBoxX_Rows;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX_HideIndexesUnderXRows;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX_HideDisabled;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX_HelpText;
        private DevComponents.DotNetBar.LabelX labelX_HelpTitle;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevComponents.DotNetBar.LabelX labelX_ColumnAcceptable;
        private System.Windows.Forms.PictureBox pictureBox4;
        private DevComponents.DotNetBar.LabelX labelX_ColumnCaution;
        private System.Windows.Forms.PictureBox pictureBox5;
        private DevComponents.DotNetBar.LabelX labelX_ColumnCritical;
        private System.Windows.Forms.PictureBox pictureBox_Filter;
        private DevComponents.DotNetBar.LabelX labelX_FilteredIndexes;
        private DevComponents.DotNetBar.Controls.CheckBoxX _checkBoxX_CollectFrag;
        private DevComponents.DotNetBar.ButtonX buttonX_AnalyzeFragmentation;
        private System.Windows.Forms.ToolStripMenuItem contextMenuLoadSelectivity;
        private System.Windows.Forms.ToolStripMenuItem menuLoadSelectivity;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private DevComponents.DotNetBar.Controls.CheckBoxX _checkBoxX_CollectStatistics;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX_IncludeColumnStats;
        private DevComponents.DotNetBar.ButtonX buttonX_LoadSelectivity;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX_HideNonClusteredIndexes;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX buttonBrowseDatabase;
        private DevComponents.DotNetBar.Controls.TextBoxX textDatabase;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
    }
}

