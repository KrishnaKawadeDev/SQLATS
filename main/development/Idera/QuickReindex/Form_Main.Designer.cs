namespace Idera.SqlAdminToolset.QuickReindex
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
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonBrowseDatabase = new DevComponents.DotNetBar.ButtonX();
            this.textDatabase = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this._checkBoxX_CollectFrag = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.textServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelServer = new DevComponents.DotNetBar.LabelX();
            this.buttonCredentials = new DevComponents.DotNetBar.ButtonX();
            this.buttonLoadIndexes = new DevComponents.DotNetBar.ButtonX();
            this.buttonBrowseServer = new DevComponents.DotNetBar.ButtonX();
            this.groupResults = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.groupPanel6 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.fillFact = new System.Windows.Forms.RadioButton();
            this.fillFactDefault = new System.Windows.Forms.RadioButton();
            this._textBoxX_FillFactor = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.checkBoxX2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX_FilteredIndexes = new DevComponents.DotNetBar.LabelX();
            this.pictureBox_Filter = new System.Windows.Forms.PictureBox();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkBoxX_HideNonClustered = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this._textBoxX_Rows = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.checkBoxX_HideIndexesUnderXRows = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBoxX_HideDisabled = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelTableList = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
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
            this.contextMenuAnalyzeFragmentation = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuReorganizeIndexes = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuRebuildIndexes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRefreshStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonCopyToClipboard = new DevComponents.DotNetBar.ButtonX();
            this.buttonRebuild = new DevComponents.DotNetBar.ButtonX();
            this.buttonCalculateFrag = new DevComponents.DotNetBar.ButtonX();
            this.buttonReorganize = new DevComponents.DotNetBar.ButtonX();
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
            this.analyzeFragmentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReorganizeIndexes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRebuildIndexes = new System.Windows.Forms.ToolStripMenuItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.groupPanel6.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel4.SuspendLayout();
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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.groupPanel1);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMiddle.Location = new System.Drawing.Point(0, 169);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Padding = new System.Windows.Forms.Padding(6);
            this.panelMiddle.Size = new System.Drawing.Size(1236, 72);
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
            this.groupPanel1.Controls.Add(this._checkBoxX_CollectFrag);
            this.groupPanel1.Controls.Add(this.textServer);
            this.groupPanel1.Controls.Add(this.labelServer);
            this.groupPanel1.Controls.Add(this.buttonCredentials);
            this.groupPanel1.Controls.Add(this.buttonLoadIndexes);
            this.groupPanel1.Controls.Add(this.buttonBrowseServer);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.IsShadowEnabled = true;
            this.groupPanel1.Location = new System.Drawing.Point(6, 6);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1224, 60);
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
            this.buttonBrowseDatabase.Location = new System.Drawing.Point(451, 31);
            this.buttonBrowseDatabase.Name = "buttonBrowseDatabase";
            this.buttonBrowseDatabase.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseDatabase.TabIndex = 39;
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
            this.textDatabase.Location = new System.Drawing.Point(78, 31);
            this.textDatabase.Name = "textDatabase";
            this.textDatabase.Size = new System.Drawing.Size(364, 20);
            this.textDatabase.TabIndex = 38;
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
            this.labelX4.Location = new System.Drawing.Point(12, 35);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(62, 12);
            this.labelX4.TabIndex = 16;
            this.labelX4.Text = "&Database:";
            // 
            // _checkBoxX_CollectFrag
            // 
            this._checkBoxX_CollectFrag.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this._checkBoxX_CollectFrag.BackgroundStyle.Class = "";
            this._checkBoxX_CollectFrag.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._checkBoxX_CollectFrag.Location = new System.Drawing.Point(669, 3);
            this._checkBoxX_CollectFrag.Name = "_checkBoxX_CollectFrag";
            this._checkBoxX_CollectFrag.Size = new System.Drawing.Size(307, 23);
            this._checkBoxX_CollectFrag.TabIndex = 7;
            this._checkBoxX_CollectFrag.Text = "Analyze index fragmentation when loading index statistics";
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
            this.textServer.Location = new System.Drawing.Point(78, 5);
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(364, 20);
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
            this.labelServer.Location = new System.Drawing.Point(12, 8);
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
            this.buttonCredentials.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources.buttonCredentials_Image;
            this.buttonCredentials.Location = new System.Drawing.Point(476, 5);
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
            this.buttonLoadIndexes.Location = new System.Drawing.Point(504, 4);
            this.buttonLoadIndexes.Name = "buttonLoadIndexes";
            this.buttonLoadIndexes.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.buttonLoadIndexes.Size = new System.Drawing.Size(160, 50);
            this.buttonLoadIndexes.TabIndex = 5;
            this.buttonLoadIndexes.Text = "&Load Index Statistics";
            this.buttonLoadIndexes.Click += new System.EventHandler(this.buttonGetResults_Click);
            // 
            // buttonBrowseServer
            // 
            this.buttonBrowseServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseServer.BackColor = System.Drawing.Color.White;
            this.buttonBrowseServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseServer.Location = new System.Drawing.Point(451, 5);
            this.buttonBrowseServer.Name = "buttonBrowseServer";
            this.buttonBrowseServer.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseServer.TabIndex = 3;
            this.buttonBrowseServer.Text = "...";
            this.buttonBrowseServer.Click += new System.EventHandler(this.buttonBrowseServer_Click);
            // 
            // groupResults
            // 
            this.groupResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupResults.BackColor = System.Drawing.Color.Transparent;
            this.groupResults.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupResults.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupResults.Controls.Add(this.splitContainer1);
            this.groupResults.IsShadowEnabled = true;
            this.groupResults.Location = new System.Drawing.Point(6, 3);
            this.groupResults.Name = "groupResults";
            this.groupResults.Size = new System.Drawing.Size(1224, 382);
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
            this.groupResults.Text = "Index Statistics";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.advTree1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel6);
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel3);
            this.splitContainer1.Panel2.Controls.Add(this.labelX_FilteredIndexes);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox_Filter);
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel5);
            this.splitContainer1.Panel2.Controls.Add(this.labelTableList);
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel2);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewX1);
            this.splitContainer1.Size = new System.Drawing.Size(1218, 361);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 2;
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.AllowDrop = true;
            this.advTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTree1.Location = new System.Drawing.Point(0, 0);
            this.advTree1.Name = "advTree1";
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(260, 361);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 2;
            this.advTree1.Text = "advTree1";
            this.advTree1.AfterNodeSelect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.advTree1_AfterNodeSelect);
            this.advTree1.MouseHover += new System.EventHandler(this.advTree1_MouseHover);
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
            // groupPanel6
            // 
            this.groupPanel6.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel6.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel6.Controls.Add(this.labelX5);
            this.groupPanel6.Controls.Add(this.fillFact);
            this.groupPanel6.Controls.Add(this.fillFactDefault);
            this.groupPanel6.Controls.Add(this._textBoxX_FillFactor);
            this.groupPanel6.Location = new System.Drawing.Point(291, 0);
            this.groupPanel6.Name = "groupPanel6";
            this.groupPanel6.Size = new System.Drawing.Size(164, 98);
            // 
            // 
            // 
            this.groupPanel6.Style.BackColor = System.Drawing.Color.White;
            this.groupPanel6.Style.BackColor2 = System.Drawing.Color.White;
            this.groupPanel6.Style.BackColorGradientAngle = 90;
            this.groupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderBottomWidth = 1;
            this.groupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderLeftWidth = 1;
            this.groupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderRightWidth = 1;
            this.groupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderTopWidth = 1;
            this.groupPanel6.Style.Class = "";
            this.groupPanel6.Style.CornerDiameter = 4;
            this.groupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseDown.Class = "";
            this.groupPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseOver.Class = "";
            this.groupPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel6.TabIndex = 76;
            this.groupPanel6.Text = "Index Settings";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(4, 45);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(150, 28);
            this.labelX5.TabIndex = 2;
            this.labelX5.Text = "Note: This setting will be applied to all selected indexes.";
            this.labelX5.WordWrap = true;
            // 
            // fillFact
            // 
            this.fillFact.Location = new System.Drawing.Point(5, 5);
            this.fillFact.Name = "fillFact";
            this.fillFact.Size = new System.Drawing.Size(70, 20);
            this.fillFact.TabIndex = 3;
            this.fillFact.Text = "Fill Factor";
            this.fillFact.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged_fillFactor);
            // 
            // fillFactDefault
            // 
            this.fillFactDefault.Checked = true;
            this.fillFactDefault.Location = new System.Drawing.Point(5, 25);
            this.fillFactDefault.Name = "fillFactDefault";
            this.fillFactDefault.Size = new System.Drawing.Size(130, 20);
            this.fillFactDefault.TabIndex = 4;
            this.fillFactDefault.TabStop = true;
            this.fillFactDefault.Text = "Current Fill Factor";
            // 
            // _textBoxX_FillFactor
            // 
            // 
            // 
            // 
            this._textBoxX_FillFactor.Border.Class = "TextBoxBorder";
            this._textBoxX_FillFactor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._textBoxX_FillFactor.Enabled = false;
            this._textBoxX_FillFactor.Location = new System.Drawing.Point(75, 5);
            this._textBoxX_FillFactor.MaxLength = 3;
            this._textBoxX_FillFactor.Name = "_textBoxX_FillFactor";
            this._textBoxX_FillFactor.Size = new System.Drawing.Size(36, 20);
            this._textBoxX_FillFactor.TabIndex = 0;
            this._textBoxX_FillFactor.Text = "100";
            this._textBoxX_FillFactor.TextChanged += new System.EventHandler(this._textBoxX_FillFactor_TextChanged);
            this._textBoxX_FillFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textBoxX_FillFactor_KeyPress);
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.groupPanel4);
            this.groupPanel3.Location = new System.Drawing.Point(290, 47);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(8, 8);
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
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
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
            this.groupPanel3.TabIndex = 76;
            this.groupPanel3.Text = "groupPanel3";
            // 
            // groupPanel4
            // 
            this.groupPanel4.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.checkBoxX1);
            this.groupPanel4.Controls.Add(this.labelX2);
            this.groupPanel4.Controls.Add(this.textBoxX1);
            this.groupPanel4.Controls.Add(this.checkBoxX2);
            this.groupPanel4.Controls.Add(this.checkBoxX3);
            this.groupPanel4.Location = new System.Drawing.Point(-290, -44);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(258, 98);
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
            this.groupPanel4.TabIndex = 16;
            this.groupPanel4.Text = "View Options";
            // 
            // checkBoxX1
            // 
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.Class = "";
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Location = new System.Drawing.Point(3, 53);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(180, 23);
            this.checkBoxX1.TabIndex = 18;
            this.checkBoxX1.Text = "Hide Non-Clustered Indexes";
            this.checkBoxX1.CheckedChanged += new System.EventHandler(this.checkBoxX_HideNonClustered_CheckedChanged);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(189, 4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 17;
            this.labelX2.Text = "pages";
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Location = new System.Drawing.Point(126, 7);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(57, 20);
            this.textBoxX1.TabIndex = 16;
            this.textBoxX1.Text = "5";
            this.textBoxX1.TextChanged += new System.EventHandler(this._textBoxX_Rows_TextChanged);
            this.textBoxX1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textBoxX_Rows_KeyPress);
            // 
            // checkBoxX2
            // 
            // 
            // 
            // 
            this.checkBoxX2.BackgroundStyle.Class = "";
            this.checkBoxX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX2.Checked = true;
            this.checkBoxX2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxX2.CheckValue = "Y";
            this.checkBoxX2.Location = new System.Drawing.Point(3, 4);
            this.checkBoxX2.Name = "checkBoxX2";
            this.checkBoxX2.Size = new System.Drawing.Size(117, 23);
            this.checkBoxX2.TabIndex = 15;
            this.checkBoxX2.Text = "Hide Indexes under ";
            this.checkBoxX2.CheckedChanged += new System.EventHandler(this.checkBoxX_HideIndexesUnderXRows_CheckedChanged);
            // 
            // checkBoxX3
            // 
            // 
            // 
            // 
            this.checkBoxX3.BackgroundStyle.Class = "";
            this.checkBoxX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX3.Checked = true;
            this.checkBoxX3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxX3.CheckValue = "Y";
            this.checkBoxX3.Location = new System.Drawing.Point(3, 29);
            this.checkBoxX3.Name = "checkBoxX3";
            this.checkBoxX3.Size = new System.Drawing.Size(180, 23);
            this.checkBoxX3.TabIndex = 14;
            this.checkBoxX3.Text = "Hide Disabled Indexes";
            this.checkBoxX3.CheckedChanged += new System.EventHandler(this.checkBoxX_HideDisabled_CheckedChanged);
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
            this.labelX_FilteredIndexes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX_FilteredIndexes.Location = new System.Drawing.Point(655, 104);
            this.labelX_FilteredIndexes.Name = "labelX_FilteredIndexes";
            this.labelX_FilteredIndexes.Size = new System.Drawing.Size(268, 18);
            this.labelX_FilteredIndexes.TabIndex = 75;
            this.labelX_FilteredIndexes.Text = "12234567 / 1234567 Indexes Filtered";
            this.labelX_FilteredIndexes.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // pictureBox_Filter
            // 
            this.pictureBox_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Filter.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Filter.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources.filter_24;
            this.pictureBox_Filter.Location = new System.Drawing.Point(929, 99);
            this.pictureBox_Filter.Name = "pictureBox_Filter";
            this.pictureBox_Filter.Size = new System.Drawing.Size(24, 24);
            this.pictureBox_Filter.TabIndex = 74;
            this.pictureBox_Filter.TabStop = false;
            // 
            // groupPanel5
            // 
            this.groupPanel5.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.checkBoxX_HideNonClustered);
            this.groupPanel5.Controls.Add(this.labelX1);
            this.groupPanel5.Controls.Add(this._textBoxX_Rows);
            this.groupPanel5.Controls.Add(this.checkBoxX_HideIndexesUnderXRows);
            this.groupPanel5.Controls.Add(this.checkBoxX_HideDisabled);
            this.groupPanel5.Location = new System.Drawing.Point(3, 0);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(279, 98);
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
            this.groupPanel5.TabIndex = 16;
            this.groupPanel5.Text = "View Options";
            // 
            // checkBoxX_HideNonClustered
            // 
            // 
            // 
            // 
            this.checkBoxX_HideNonClustered.BackgroundStyle.Class = "";
            this.checkBoxX_HideNonClustered.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_HideNonClustered.Location = new System.Drawing.Point(3, 53);
            this.checkBoxX_HideNonClustered.Name = "checkBoxX_HideNonClustered";
            this.checkBoxX_HideNonClustered.Size = new System.Drawing.Size(180, 23);
            this.checkBoxX_HideNonClustered.TabIndex = 18;
            this.checkBoxX_HideNonClustered.Text = "Hide Non-Clustered Indexes";
            this.checkBoxX_HideNonClustered.CheckedChanged += new System.EventHandler(this.checkBoxX_HideNonClustered_CheckedChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(189, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 17;
            this.labelX1.Text = "pages";
            // 
            // _textBoxX_Rows
            // 
            // 
            // 
            // 
            this._textBoxX_Rows.Border.Class = "TextBoxBorder";
            this._textBoxX_Rows.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this._textBoxX_Rows.Location = new System.Drawing.Point(126, 7);
            this._textBoxX_Rows.MaxLength = 10;
            this._textBoxX_Rows.Name = "_textBoxX_Rows";
            this._textBoxX_Rows.Size = new System.Drawing.Size(57, 20);
            this._textBoxX_Rows.TabIndex = 16;
            this._textBoxX_Rows.Text = "5";
            this._textBoxX_Rows.TextChanged += new System.EventHandler(this._textBoxX_Rows_TextChanged);
            this._textBoxX_Rows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textBoxX_Rows_KeyPress);
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
            this.checkBoxX_HideIndexesUnderXRows.Location = new System.Drawing.Point(3, 4);
            this.checkBoxX_HideIndexesUnderXRows.Name = "checkBoxX_HideIndexesUnderXRows";
            this.checkBoxX_HideIndexesUnderXRows.Size = new System.Drawing.Size(117, 23);
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
            this.checkBoxX_HideDisabled.Location = new System.Drawing.Point(3, 29);
            this.checkBoxX_HideDisabled.Name = "checkBoxX_HideDisabled";
            this.checkBoxX_HideDisabled.Size = new System.Drawing.Size(180, 23);
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
            this.labelTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTableList.Location = new System.Drawing.Point(3, 102);
            this.labelTableList.Name = "labelTableList";
            this.labelTableList.Size = new System.Drawing.Size(618, 20);
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
            this.groupPanel2.Controls.Add(this.pictureBox3);
            this.groupPanel2.Controls.Add(this.labelAcceptableIndexes);
            this.groupPanel2.Controls.Add(this.pictureBox1);
            this.groupPanel2.Controls.Add(this.labelCautionIndexes);
            this.groupPanel2.Controls.Add(this.pictureBoxUserDatabases);
            this.groupPanel2.Controls.Add(this.labelCriticalIndexes);
            this.groupPanel2.IsShadowEnabled = true;
            this.groupPanel2.Location = new System.Drawing.Point(461, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(487, 96);
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
            this.groupPanel2.Text = "Index Fragmentation Summary";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources.I_AcceptableFiltered;
            this.pictureBox3.Location = new System.Drawing.Point(16, 50);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 71;
            this.pictureBox3.TabStop = false;
            // 
            // labelAcceptableIndexes
            // 
            this.labelAcceptableIndexes.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelAcceptableIndexes.BackgroundStyle.Class = "";
            this.labelAcceptableIndexes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelAcceptableIndexes.Location = new System.Drawing.Point(37, 50);
            this.labelAcceptableIndexes.Name = "labelAcceptableIndexes";
            this.labelAcceptableIndexes.Size = new System.Drawing.Size(242, 16);
            this.labelAcceptableIndexes.TabIndex = 69;
            this.labelAcceptableIndexes.Text = "Indexes 25% or less fragmented";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources.I_CautionFiltered;
            this.pictureBox1.Location = new System.Drawing.Point(16, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 67;
            this.pictureBox1.TabStop = false;
            // 
            // labelCautionIndexes
            // 
            this.labelCautionIndexes.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelCautionIndexes.BackgroundStyle.Class = "";
            this.labelCautionIndexes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelCautionIndexes.Location = new System.Drawing.Point(37, 28);
            this.labelCautionIndexes.Name = "labelCautionIndexes";
            this.labelCautionIndexes.Size = new System.Drawing.Size(242, 16);
            this.labelCautionIndexes.TabIndex = 65;
            this.labelCautionIndexes.Text = "Indexes 25% to 75% fragmented";
            // 
            // pictureBoxUserDatabases
            // 
            this.pictureBoxUserDatabases.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxUserDatabases.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources.I_CriticalFiltered;
            this.pictureBoxUserDatabases.Location = new System.Drawing.Point(16, 6);
            this.pictureBoxUserDatabases.Name = "pictureBoxUserDatabases";
            this.pictureBoxUserDatabases.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxUserDatabases.TabIndex = 63;
            this.pictureBoxUserDatabases.TabStop = false;
            // 
            // labelCriticalIndexes
            // 
            this.labelCriticalIndexes.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelCriticalIndexes.BackgroundStyle.Class = "";
            this.labelCriticalIndexes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelCriticalIndexes.Location = new System.Drawing.Point(37, 6);
            this.labelCriticalIndexes.Name = "labelCriticalIndexes";
            this.labelCriticalIndexes.Size = new System.Drawing.Size(242, 16);
            this.labelCriticalIndexes.TabIndex = 61;
            this.labelCriticalIndexes.Text = "Indexes 75% or more fragmented";
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
            this.dataGridViewX1.Location = new System.Drawing.Point(3, 125);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(951, 236);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewX1_CellFormatting);
            this.dataGridViewX1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewX1_CellPainting);
            this.dataGridViewX1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewX1_ColumnHeaderMouseClick);
            this.dataGridViewX1.SelectionChanged += new System.EventHandler(this.dataGridViewX1_SelectionChanged);
            this.dataGridViewX1.MouseHover += new System.EventHandler(this.dataGridViewX1_MouseHover);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuCopy,
            this.contextMenuSelectAll,
            this.toolStripMenuItem7,
            this.contextMenuExport,
            this.contextMenuAnalyzeFragmentation,
            this.contextMenuReorganizeIndexes,
            this.contextMenuRebuildIndexes,
            this.toolStripMenuItem6,
            this.menuRefreshStatistics});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(197, 170);
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.Enabled = false;
            this.contextMenuCopy.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources.copy_16;
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.contextMenuCopy.Size = new System.Drawing.Size(196, 22);
            this.contextMenuCopy.Text = "&Copy";
            this.contextMenuCopy.Click += new System.EventHandler(this.contextMenuCopy_Click);
            // 
            // contextMenuSelectAll
            // 
            this.contextMenuSelectAll.Enabled = false;
            this.contextMenuSelectAll.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources.table_selection_all_16;
            this.contextMenuSelectAll.Name = "contextMenuSelectAll";
            this.contextMenuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.contextMenuSelectAll.Size = new System.Drawing.Size(196, 22);
            this.contextMenuSelectAll.Text = "Select &All";
            this.contextMenuSelectAll.Click += new System.EventHandler(this.contextMenuSelectAll_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(193, 6);
            // 
            // contextMenuExport
            // 
            this.contextMenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuCSV,
            this.contextMenuXML});
            this.contextMenuExport.Enabled = false;
            this.contextMenuExport.Name = "contextMenuExport";
            this.contextMenuExport.Size = new System.Drawing.Size(196, 22);
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
            // contextMenuAnalyzeFragmentation
            // 
            this.contextMenuAnalyzeFragmentation.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources._16_analyze;
            this.contextMenuAnalyzeFragmentation.Name = "contextMenuAnalyzeFragmentation";
            this.contextMenuAnalyzeFragmentation.Size = new System.Drawing.Size(196, 22);
            this.contextMenuAnalyzeFragmentation.Text = "&Analyze Fragmentation";
            this.contextMenuAnalyzeFragmentation.Click += new System.EventHandler(this.contextMenuAnalyzeFragmentation_Click);
            // 
            // contextMenuReorganizeIndexes
            // 
            this.contextMenuReorganizeIndexes.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources._16_defrag;
            this.contextMenuReorganizeIndexes.Name = "contextMenuReorganizeIndexes";
            this.contextMenuReorganizeIndexes.Size = new System.Drawing.Size(196, 22);
            this.contextMenuReorganizeIndexes.Text = "Re&organize Indexes";
            this.contextMenuReorganizeIndexes.Click += new System.EventHandler(this.contextMenuReorganizeIndexes_Click);
            // 
            // contextMenuRebuildIndexes
            // 
            this.contextMenuRebuildIndexes.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources._16_DefragReorgThenRebuild;
            this.contextMenuRebuildIndexes.Name = "contextMenuRebuildIndexes";
            this.contextMenuRebuildIndexes.Size = new System.Drawing.Size(196, 22);
            this.contextMenuRebuildIndexes.Text = "Re&build Indexes";
            this.contextMenuRebuildIndexes.Click += new System.EventHandler(this.contextMenuRebuildIndexes_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(193, 6);
            // 
            // menuRefreshStatistics
            // 
            this.menuRefreshStatistics.Name = "menuRefreshStatistics";
            this.menuRefreshStatistics.Size = new System.Drawing.Size(196, 22);
            this.menuRefreshStatistics.Text = "&Refresh All Statistics";
            this.menuRefreshStatistics.Click += new System.EventHandler(this.menuRefreshStatistics_Click);
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
            this.panelTop.Size = new System.Drawing.Size(1236, 52);
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
            this.labelTitle.Size = new System.Drawing.Size(290, 52);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.TabStop = false;
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Quick Reindex</font></b> ";
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
            this.labelSubtitle.Size = new System.Drawing.Size(437, 52);
            this.labelSubtitle.TabIndex = 6;
            this.labelSubtitle.Text = "Review fragmentation levels and rebuild the indexes on your SQL Servers";
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
            this.panelBottom.Controls.Add(this.buttonCopyToClipboard);
            this.panelBottom.Controls.Add(this.groupResults);
            this.panelBottom.Controls.Add(this.buttonRebuild);
            this.panelBottom.Controls.Add(this.buttonCalculateFrag);
            this.panelBottom.Controls.Add(this.buttonReorganize);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 241);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.panelBottom.Size = new System.Drawing.Size(1236, 431);
            this.panelBottom.TabIndex = 17;
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyToClipboard.BackColor = System.Drawing.Color.White;
            this.buttonCopyToClipboard.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCopyToClipboard.Enabled = false;
            this.buttonCopyToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyToClipboard.Image")));
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(1058, 391);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(160, 34);
            this.buttonCopyToClipboard.TabIndex = 13;
            this.buttonCopyToClipboard.Text = "&Copy Results To Clipboard";
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // buttonRebuild
            // 
            this.buttonRebuild.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonRebuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRebuild.BackColor = System.Drawing.Color.White;
            this.buttonRebuild.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonRebuild.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources._16_DefragReorgThenRebuild;
            this.buttonRebuild.Location = new System.Drawing.Point(881, 391);
            this.buttonRebuild.Name = "buttonRebuild";
            this.buttonRebuild.Size = new System.Drawing.Size(160, 34);
            this.buttonRebuild.TabIndex = 7;
            this.buttonRebuild.Text = "Re&build Indexes";
            this.buttonRebuild.Click += new System.EventHandler(this.buttonRebuild_Click);
            // 
            // buttonCalculateFrag
            // 
            this.buttonCalculateFrag.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCalculateFrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCalculateFrag.BackColor = System.Drawing.Color.White;
            this.buttonCalculateFrag.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCalculateFrag.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources._16_analyze;
            this.buttonCalculateFrag.Location = new System.Drawing.Point(527, 391);
            this.buttonCalculateFrag.Name = "buttonCalculateFrag";
            this.buttonCalculateFrag.Size = new System.Drawing.Size(160, 34);
            this.buttonCalculateFrag.TabIndex = 8;
            this.buttonCalculateFrag.Text = "&Analyze Fragmentation";
            this.buttonCalculateFrag.Click += new System.EventHandler(this.buttonCalculateFrag_Click);
            // 
            // buttonReorganize
            // 
            this.buttonReorganize.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonReorganize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReorganize.BackColor = System.Drawing.Color.White;
            this.buttonReorganize.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonReorganize.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources._16_defrag;
            this.buttonReorganize.Location = new System.Drawing.Point(704, 391);
            this.buttonReorganize.Name = "buttonReorganize";
            this.buttonReorganize.Size = new System.Drawing.Size(160, 34);
            this.buttonReorganize.TabIndex = 6;
            this.buttonReorganize.Text = "Re&organize Indexes";
            this.buttonReorganize.Click += new System.EventHandler(this.buttonReorganize_Click);
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
            this.menuStrip1.Size = new System.Drawing.Size(1236, 24);
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
            this.analyzeFragmentationToolStripMenuItem,
            this.menuReorganizeIndexes,
            this.menuRebuildIndexes});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(39, 20);
            this.editMenu.Text = "&Edit";
            // 
            // editCopyMenuItem
            // 
            this.editCopyMenuItem.Enabled = false;
            this.editCopyMenuItem.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources.copy_16;
            this.editCopyMenuItem.Name = "editCopyMenuItem";
            this.editCopyMenuItem.Size = new System.Drawing.Size(196, 22);
            this.editCopyMenuItem.Text = "&Copy";
            this.editCopyMenuItem.Click += new System.EventHandler(this.editCopyMenuItem_Click);
            // 
            // editSelectAllMenuItem
            // 
            this.editSelectAllMenuItem.Enabled = false;
            this.editSelectAllMenuItem.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources.table_selection_all_16;
            this.editSelectAllMenuItem.Name = "editSelectAllMenuItem";
            this.editSelectAllMenuItem.Size = new System.Drawing.Size(196, 22);
            this.editSelectAllMenuItem.Text = "Select &All";
            this.editSelectAllMenuItem.Click += new System.EventHandler(this.editSelectAllMenuItem_Click);
            // 
            // analyzeFragmentationToolStripMenuItem
            // 
            this.analyzeFragmentationToolStripMenuItem.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources._16_analyze;
            this.analyzeFragmentationToolStripMenuItem.Name = "analyzeFragmentationToolStripMenuItem";
            this.analyzeFragmentationToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.analyzeFragmentationToolStripMenuItem.Text = "&Analyze Fragmentation";
            this.analyzeFragmentationToolStripMenuItem.Click += new System.EventHandler(this.analyzeFragmentationToolStripMenuItem_Click);
            // 
            // menuReorganizeIndexes
            // 
            this.menuReorganizeIndexes.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources._16_defrag;
            this.menuReorganizeIndexes.Name = "menuReorganizeIndexes";
            this.menuReorganizeIndexes.Size = new System.Drawing.Size(196, 22);
            this.menuReorganizeIndexes.Text = "Re&organize Indexes";
            this.menuReorganizeIndexes.Click += new System.EventHandler(this.menuReorganizeIndexes_Click);
            // 
            // menuRebuildIndexes
            // 
            this.menuRebuildIndexes.Image = global::Idera.SqlAdminToolset.QuickReindex.Properties.Resources._16_DefragReorgThenRebuild;
            this.menuRebuildIndexes.Name = "menuRebuildIndexes";
            this.menuRebuildIndexes.Size = new System.Drawing.Size(196, 22);
            this.menuRebuildIndexes.Text = "Re&build Indexes";
            this.menuRebuildIndexes.Click += new System.EventHandler(this.menuRebuildIndexes_Click);
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
            this.ideraTitleBar1.IderaProductNameText = "SQL Quick Reindex";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = true;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(1236, 93);
            this.ideraTitleBar1.TabIndex = 19;
            this.ideraTitleBar1.TrialMode = true;
            this.ideraTitleBar1.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar1_LicenseInfoButtonClick);
            // 
            // Form_Main
            // 
            this.AcceptButton = this.buttonLoadIndexes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1236, 672);
            this.ControlBox = false;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ideraTitleBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(996, 426);
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
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.groupPanel6.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel4.ResumeLayout(false);
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        //Fill factor
        private System.Windows.Forms.RadioButton fillFact;
        //Fill factor Default
        private System.Windows.Forms.RadioButton fillFactDefault;
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
        private DevComponents.DotNetBar.ButtonX buttonReorganize;
        private DevComponents.DotNetBar.ButtonX buttonRebuild;
        private DevComponents.DotNetBar.ButtonX buttonCalculateFrag;
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
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX _textBoxX_Rows;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX_HideIndexesUnderXRows;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX_HideDisabled;
        private System.Windows.Forms.ToolStripMenuItem contextMenuReorganizeIndexes;
        private System.Windows.Forms.ToolStripMenuItem contextMenuRebuildIndexes;
        private System.Windows.Forms.ToolStripMenuItem menuReorganizeIndexes;
        private System.Windows.Forms.ToolStripMenuItem menuRebuildIndexes;
        private DevComponents.DotNetBar.LabelX labelX_FilteredIndexes;
        private System.Windows.Forms.PictureBox pictureBox_Filter;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX_HideNonClustered;
        private DevComponents.DotNetBar.Controls.CheckBoxX _checkBoxX_CollectFrag;
        private System.Windows.Forms.ToolStripMenuItem contextMenuAnalyzeFragmentation;
        private System.Windows.Forms.ToolStripMenuItem analyzeFragmentationToolStripMenuItem;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
       private System.Windows.Forms.ToolStripMenuItem menuRefreshStatistics;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX buttonBrowseDatabase;
        private DevComponents.DotNetBar.Controls.TextBoxX textDatabase;
       private DevComponents.DotNetBar.Controls.GroupPanel groupPanel6;
       private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
       private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
       private DevComponents.DotNetBar.LabelX labelX2;
       private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX2;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX3;
       private DevComponents.DotNetBar.Controls.TextBoxX _textBoxX_FillFactor;
       //private DevComponents.DotNetBar.LabelX labelX3;
       private DevComponents.DotNetBar.LabelX labelX5;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
    }
}

