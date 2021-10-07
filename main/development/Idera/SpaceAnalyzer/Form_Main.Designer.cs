namespace Idera.SqlAdminToolset.SpaceAnalyzer
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
			this.ServerSelection = new Idera.SqlAdminToolset.Core.Controls.ToolServerSelection();
			this.buttonLoadIndexes = new DevComponents.DotNetBar.ButtonX();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
			this.contextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuCSV = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuXML = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuFileProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.panelTop = new System.Windows.Forms.Panel();
			this.labelTitle = new DevComponents.DotNetBar.LabelX();
			this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
			this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
			this.panelBottom = new System.Windows.Forms.Panel();
			this.groupPanel6 = new DevComponents.DotNetBar.Controls.GroupPanel();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this._advTree_Disks = new DevComponents.AdvTree.AdvTree();
			this.node3 = new DevComponents.AdvTree.Node();
			this.nodeConnector3 = new DevComponents.AdvTree.NodeConnector();
			this.elementStyle3 = new DevComponents.DotNetBar.ElementStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this._labelX_FilesTitle = new DevComponents.DotNetBar.LabelX();
			this._labelX_FilterText = new DevComponents.DotNetBar.LabelX();
			this.groupPanel7 = new DevComponents.DotNetBar.Controls.GroupPanel();
			this._comboBoxEx_View = new DevComponents.DotNetBar.Controls.ComboBoxEx();
			this._comboBoxEx_Datatypeview = new DevComponents.DotNetBar.Controls.ComboBoxEx();
			this._checkBoxX_HideLogFiles = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this._checkBoxX_HideDataFiles = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this._groupPanel_Summary = new DevComponents.DotNetBar.Controls.GroupPanel();
			this._labelX_HelpTitle = new DevComponents.DotNetBar.LabelX();
			this._labelX_HelpText = new DevComponents.DotNetBar.LabelX();
			this.pictureBox7 = new System.Windows.Forms.PictureBox();
			this._labelX_Acceptable = new DevComponents.DotNetBar.LabelX();
			this.pictureBox8 = new System.Windows.Forms.PictureBox();
			this._labelX_Caution = new DevComponents.DotNetBar.LabelX();
			this.pictureBox9 = new System.Windows.Forms.PictureBox();
			this._labelX_Critical = new DevComponents.DotNetBar.LabelX();
			this._dataGridViewX_Files = new DevComponents.DotNetBar.Controls.DataGridViewX();
			this.buttonCopyToClipboard = new DevComponents.DotNetBar.ButtonX();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.fileSaveMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.fileSavetoCVSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fileSavetoXMLMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.editCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editSelectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFileProperties = new System.Windows.Forms.ToolStripMenuItem();
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
			this.checkBox_EnableWMI = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.panelMiddle.SuspendLayout();
			this.groupPanel1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.panelTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
			this.panelBottom.SuspendLayout();
			this.groupPanel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._advTree_Disks)).BeginInit();
			this.panel1.SuspendLayout();
			this.groupPanel7.SuspendLayout();
			this._groupPanel_Summary.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._dataGridViewX_Files)).BeginInit();
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
			this.groupPanel1.Controls.Add(this.ServerSelection);
			this.groupPanel1.Controls.Add(this.buttonLoadIndexes);
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
			// ServerSelection
			// 
			this.ServerSelection.BackColor = System.Drawing.Color.Transparent;
			this.ServerSelection.Caption = "";
			this.ServerSelection.CredentialsVisible = true;
			this.ServerSelection.Location = new System.Drawing.Point(6, 7);
			this.ServerSelection.MinimumSize = new System.Drawing.Size(0, 40);
			this.ServerSelection.Name = "ServerSelection";
			this.ServerSelection.SelectionOptions = Idera.SqlAdminToolset.Core.Controls.ServerSelectionOptions.ServersAndGroups;
			this.ServerSelection.Size = new System.Drawing.Size(480, 40);
			this.ServerSelection.TabIndex = 6;
			this.ServerSelection.TextChangedEventHandler = null;
			// 
			// buttonLoadIndexes
			// 
			this.buttonLoadIndexes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonLoadIndexes.BackColor = System.Drawing.Color.White;
			this.buttonLoadIndexes.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonLoadIndexes.Image = global::Idera.SqlAdminToolset.SpaceAnalyzer.Properties.Resources.GetData_24;
			this.buttonLoadIndexes.Location = new System.Drawing.Point(523, 4);
			this.buttonLoadIndexes.Name = "buttonLoadIndexes";
			this.buttonLoadIndexes.Size = new System.Drawing.Size(160, 46);
			this.buttonLoadIndexes.TabIndex = 5;
			this.buttonLoadIndexes.Text = "&Load Space Statistics";
			this.buttonLoadIndexes.Click += new System.EventHandler(this.buttonGetResults_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuCopy,
            this.contextMenuSelectAll,
            this.toolStripMenuItem7,
            this.contextMenuExport,
            this.contextMenuFileProperties});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(165, 98);
			// 
			// contextMenuCopy
			// 
			this.contextMenuCopy.Enabled = false;
			this.contextMenuCopy.Image = global::Idera.SqlAdminToolset.SpaceAnalyzer.Properties.Resources.copy_16;
			this.contextMenuCopy.Name = "contextMenuCopy";
			this.contextMenuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.contextMenuCopy.Size = new System.Drawing.Size(164, 22);
			this.contextMenuCopy.Text = "&Copy";
			this.contextMenuCopy.Click += new System.EventHandler(this.contextMenuCopy_Click);
			// 
			// contextMenuSelectAll
			// 
			this.contextMenuSelectAll.Enabled = false;
			this.contextMenuSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("contextMenuSelectAll.Image")));
			this.contextMenuSelectAll.Name = "contextMenuSelectAll";
			this.contextMenuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.contextMenuSelectAll.Size = new System.Drawing.Size(164, 22);
			this.contextMenuSelectAll.Text = "Select &All";
			this.contextMenuSelectAll.Click += new System.EventHandler(this.contextMenuSelectAll_Click);
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size(161, 6);
			// 
			// contextMenuExport
			// 
			this.contextMenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuCSV,
            this.contextMenuXML});
			this.contextMenuExport.Enabled = false;
			this.contextMenuExport.Name = "contextMenuExport";
			this.contextMenuExport.Size = new System.Drawing.Size(164, 22);
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
			// contextMenuFileProperties
			// 
			this.contextMenuFileProperties.Image = global::Idera.SqlAdminToolset.SpaceAnalyzer.Properties.Resources.file_view_16;
			this.contextMenuFileProperties.Name = "contextMenuFileProperties";
			this.contextMenuFileProperties.Size = new System.Drawing.Size(164, 22);
			this.contextMenuFileProperties.Text = "File &Properties";
			this.contextMenuFileProperties.Click += new System.EventHandler(this.contextMenuFileProperties_Click);
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
			this.labelTitle.ForeColor = System.Drawing.Color.Black;
			this.labelTitle.Location = new System.Drawing.Point(59, 0);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(330, 52);
			this.labelTitle.TabIndex = 5;
			this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Space Analyzer</font></b> ";
			// 
			// labelSubtitle
			// 
			// 
			// 
			// 
			this.labelSubtitle.BackgroundStyle.Class = "";
			this.labelSubtitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSubtitle.Location = new System.Drawing.Point(400, 0);
			this.labelSubtitle.Name = "labelSubtitle";
			this.labelSubtitle.Size = new System.Drawing.Size(388, 52);
			this.labelSubtitle.TabIndex = 6;
			this.labelSubtitle.Text = "Analyze the space usage of your SQL Server by drive or database";
			// 
			// pictureBoxTitle
			// 
			this.pictureBoxTitle.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxTitle.Image = global::Idera.SqlAdminToolset.SpaceAnalyzer.Properties.Resources.appIcon_48;
			this.pictureBoxTitle.Location = new System.Drawing.Point(5, 2);
			this.pictureBoxTitle.Name = "pictureBoxTitle";
			this.pictureBoxTitle.Size = new System.Drawing.Size(48, 48);
			this.pictureBoxTitle.TabIndex = 0;
			this.pictureBoxTitle.TabStop = false;
			// 
			// panelBottom
			// 
			this.panelBottom.Controls.Add(this.groupPanel6);
			this.panelBottom.Controls.Add(this.buttonCopyToClipboard);
			this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBottom.Location = new System.Drawing.Point(0, 241);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
			this.panelBottom.Size = new System.Drawing.Size(1236, 431);
			this.panelBottom.TabIndex = 17;
			// 
			// groupPanel6
			// 
			this.groupPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupPanel6.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel6.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.groupPanel6.Controls.Add(this.splitContainer3);
			this.groupPanel6.IsShadowEnabled = true;
			this.groupPanel6.Location = new System.Drawing.Point(6, 3);
			this.groupPanel6.Name = "groupPanel6";
			this.groupPanel6.Size = new System.Drawing.Size(1224, 382);
			// 
			// 
			// 
			this.groupPanel6.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.groupPanel6.Style.BackColorGradientAngle = 90;
			this.groupPanel6.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
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
			this.groupPanel6.TabIndex = 15;
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this._advTree_Disks);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.panel1);
			this.splitContainer3.Panel2.Controls.Add(this.groupPanel7);
			this.splitContainer3.Panel2.Controls.Add(this._groupPanel_Summary);
			this.splitContainer3.Panel2.Controls.Add(this._dataGridViewX_Files);
			this.splitContainer3.Size = new System.Drawing.Size(1218, 376);
			this.splitContainer3.SplitterDistance = 259;
			this.splitContainer3.TabIndex = 2;
			// 
			// _advTree_Disks
			// 
			this._advTree_Disks.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
			this._advTree_Disks.AllowDrop = true;
			this._advTree_Disks.AllowUserToResizeColumns = false;
			this._advTree_Disks.BackColor = System.Drawing.SystemColors.Window;
			// 
			// 
			// 
			this._advTree_Disks.BackgroundStyle.Class = "TreeBorderKey";
			this._advTree_Disks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this._advTree_Disks.Dock = System.Windows.Forms.DockStyle.Fill;
			this._advTree_Disks.DragDropEnabled = false;
			this._advTree_Disks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
			this._advTree_Disks.Location = new System.Drawing.Point(0, 0);
			this._advTree_Disks.Name = "_advTree_Disks";
			this._advTree_Disks.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node3});
			this._advTree_Disks.NodesConnector = this.nodeConnector3;
			this._advTree_Disks.NodeStyle = this.elementStyle3;
			this._advTree_Disks.PathSeparator = ";";
			this._advTree_Disks.Size = new System.Drawing.Size(259, 376);
			this._advTree_Disks.Styles.Add(this.elementStyle3);
			this._advTree_Disks.TabIndex = 2;
			this._advTree_Disks.Text = "_advTree_Disks";
			this._advTree_Disks.AfterNodeSelect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this._advTree_Disks_AfterNodeSelect);
			this._advTree_Disks.MouseHover += new System.EventHandler(this._advTree_Disks_MouseHover);
			// 
			// node3
			// 
			this.node3.Expanded = true;
			this.node3.Name = "node3";
			this.node3.Text = "No Data Available";
			// 
			// nodeConnector3
			// 
			this.nodeConnector3.LineColor = System.Drawing.SystemColors.ControlText;
			// 
			// elementStyle3
			// 
			this.elementStyle3.Class = "";
			this.elementStyle3.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.elementStyle3.Name = "elementStyle3";
			this.elementStyle3.TextColor = System.Drawing.SystemColors.ControlText;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this._labelX_FilesTitle);
			this.panel1.Controls.Add(this._labelX_FilterText);
			this.panel1.Location = new System.Drawing.Point(0, 119);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(955, 28);
			this.panel1.TabIndex = 18;
			// 
			// _labelX_FilesTitle
			// 
			this._labelX_FilesTitle.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this._labelX_FilesTitle.BackgroundStyle.Class = "";
			this._labelX_FilesTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this._labelX_FilesTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this._labelX_FilesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._labelX_FilesTitle.Location = new System.Drawing.Point(0, 0);
			this._labelX_FilesTitle.Name = "_labelX_FilesTitle";
			this._labelX_FilesTitle.Size = new System.Drawing.Size(707, 28);
			this._labelX_FilesTitle.TabIndex = 11;
			this._labelX_FilesTitle.Text = "Files";
			// 
			// _labelX_FilterText
			// 
			this._labelX_FilterText.AutoSize = true;
			this._labelX_FilterText.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this._labelX_FilterText.BackgroundStyle.Class = "";
			this._labelX_FilterText.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this._labelX_FilterText.Dock = System.Windows.Forms.DockStyle.Right;
			this._labelX_FilterText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._labelX_FilterText.Image = global::Idera.SqlAdminToolset.SpaceAnalyzer.Properties.Resources.filter_24;
			this._labelX_FilterText.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
			this._labelX_FilterText.Location = new System.Drawing.Point(707, 0);
			this._labelX_FilterText.Name = "_labelX_FilterText";
			this._labelX_FilterText.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._labelX_FilterText.Size = new System.Drawing.Size(248, 28);
			this._labelX_FilterText.TabIndex = 73;
			this._labelX_FilterText.Text = "12234567 files hidden (1234567 total)";
			this._labelX_FilterText.TextAlignment = System.Drawing.StringAlignment.Far;
			// 
			// groupPanel7
			// 
			this.groupPanel7.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel7.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.groupPanel7.Controls.Add(this.checkBox_EnableWMI);
			this.groupPanel7.Controls.Add(this._comboBoxEx_View);
			this.groupPanel7.Controls.Add(this._comboBoxEx_Datatypeview);
			this.groupPanel7.Controls.Add(this._checkBoxX_HideLogFiles);
			this.groupPanel7.Controls.Add(this._checkBoxX_HideDataFiles);
			this.groupPanel7.Location = new System.Drawing.Point(1, 0);
			this.groupPanel7.Name = "groupPanel7";
			this.groupPanel7.Size = new System.Drawing.Size(237, 115);
			// 
			// 
			// 
			this.groupPanel7.Style.BackColor = System.Drawing.Color.White;
			this.groupPanel7.Style.BackColor2 = System.Drawing.Color.White;
			this.groupPanel7.Style.BackColorGradientAngle = 90;
			this.groupPanel7.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.groupPanel7.Style.BorderBottomWidth = 1;
			this.groupPanel7.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.groupPanel7.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.groupPanel7.Style.BorderLeftWidth = 1;
			this.groupPanel7.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.groupPanel7.Style.BorderRightWidth = 1;
			this.groupPanel7.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.groupPanel7.Style.BorderTopWidth = 1;
			this.groupPanel7.Style.Class = "";
			this.groupPanel7.Style.CornerDiameter = 4;
			this.groupPanel7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
			this.groupPanel7.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.groupPanel7.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
			// 
			// 
			// 
			this.groupPanel7.StyleMouseDown.Class = "";
			this.groupPanel7.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			// 
			// 
			// 
			this.groupPanel7.StyleMouseOver.Class = "";
			this.groupPanel7.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.groupPanel7.TabIndex = 17;
			this.groupPanel7.Text = "View Options";
			// 
			// _comboBoxEx_View
			// 
			this._comboBoxEx_View.DisplayMember = "Text";
			this._comboBoxEx_View.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this._comboBoxEx_View.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._comboBoxEx_View.FormattingEnabled = true;
			this._comboBoxEx_View.ItemHeight = 14;
			this._comboBoxEx_View.Location = new System.Drawing.Point(8, 6);
			this._comboBoxEx_View.Name = "_comboBoxEx_View";
			this._comboBoxEx_View.Size = new System.Drawing.Size(211, 20);
			this._comboBoxEx_View.TabIndex = 12;
			this._comboBoxEx_View.SelectedIndexChanged += new System.EventHandler(this._comboBoxEx_View_SelectedIndexChanged);
			// 
			// _comboBoxEx_Datatypeview
			// 
			this._comboBoxEx_Datatypeview.DisplayMember = "Text";
			this._comboBoxEx_Datatypeview.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this._comboBoxEx_Datatypeview.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._comboBoxEx_Datatypeview.FormattingEnabled = true;
			this._comboBoxEx_Datatypeview.ItemHeight = 14;
			this._comboBoxEx_Datatypeview.Location = new System.Drawing.Point(8, 30);
			this._comboBoxEx_Datatypeview.Name = "_comboBoxEx_Datatypeview";
			this._comboBoxEx_Datatypeview.Size = new System.Drawing.Size(211, 20);
			this._comboBoxEx_Datatypeview.TabIndex = 12;
			this._comboBoxEx_Datatypeview.SelectedIndexChanged += new System.EventHandler(this._comboBoxEx_DataTypeView_SelectedIndexChanged);
			// 
			// _checkBoxX_HideLogFiles
			// 
			// 
			// 
			// 
			this._checkBoxX_HideLogFiles.BackgroundStyle.Class = "";
			this._checkBoxX_HideLogFiles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this._checkBoxX_HideLogFiles.Location = new System.Drawing.Point(103, 53);
			this._checkBoxX_HideLogFiles.Name = "_checkBoxX_HideLogFiles";
			this._checkBoxX_HideLogFiles.Size = new System.Drawing.Size(117, 23);
			this._checkBoxX_HideLogFiles.TabIndex = 15;
			this._checkBoxX_HideLogFiles.Text = "Hide Log Files";
			this._checkBoxX_HideLogFiles.CheckedChanged += new System.EventHandler(this.checkBoxX_HideLogFiles_CheckedChanged);
			// 
			// _checkBoxX_HideDataFiles
			// 
			// 
			// 
			// 
			this._checkBoxX_HideDataFiles.BackgroundStyle.Class = "";
			this._checkBoxX_HideDataFiles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this._checkBoxX_HideDataFiles.Location = new System.Drawing.Point(6, 53);
			this._checkBoxX_HideDataFiles.Name = "_checkBoxX_HideDataFiles";
			this._checkBoxX_HideDataFiles.Size = new System.Drawing.Size(146, 23);
			this._checkBoxX_HideDataFiles.TabIndex = 14;
			this._checkBoxX_HideDataFiles.Text = "Hide Data Files";
			this._checkBoxX_HideDataFiles.CheckedChanged += new System.EventHandler(this._checkBoxX_HideDataFiles_CheckedChanged);
			// 
			// _groupPanel_Summary
			// 
			this._groupPanel_Summary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._groupPanel_Summary.BackColor = System.Drawing.Color.Transparent;
			this._groupPanel_Summary.CanvasColor = System.Drawing.SystemColors.Control;
			this._groupPanel_Summary.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this._groupPanel_Summary.Controls.Add(this._labelX_HelpTitle);
			this._groupPanel_Summary.Controls.Add(this._labelX_HelpText);
			this._groupPanel_Summary.Controls.Add(this.pictureBox7);
			this._groupPanel_Summary.Controls.Add(this._labelX_Acceptable);
			this._groupPanel_Summary.Controls.Add(this.pictureBox8);
			this._groupPanel_Summary.Controls.Add(this._labelX_Caution);
			this._groupPanel_Summary.Controls.Add(this.pictureBox9);
			this._groupPanel_Summary.Controls.Add(this._labelX_Critical);
			this._groupPanel_Summary.IsShadowEnabled = true;
			this._groupPanel_Summary.Location = new System.Drawing.Point(243, 0);
			this._groupPanel_Summary.Name = "_groupPanel_Summary";
			this._groupPanel_Summary.Size = new System.Drawing.Size(710, 100);
			// 
			// 
			// 
			this._groupPanel_Summary.Style.BackColor = System.Drawing.Color.White;
			this._groupPanel_Summary.Style.BackColor2 = System.Drawing.Color.White;
			this._groupPanel_Summary.Style.BackColorGradientAngle = 90;
			this._groupPanel_Summary.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this._groupPanel_Summary.Style.BorderBottomWidth = 1;
			this._groupPanel_Summary.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this._groupPanel_Summary.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this._groupPanel_Summary.Style.BorderLeftWidth = 1;
			this._groupPanel_Summary.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this._groupPanel_Summary.Style.BorderRightWidth = 1;
			this._groupPanel_Summary.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this._groupPanel_Summary.Style.BorderTopWidth = 1;
			this._groupPanel_Summary.Style.Class = "";
			this._groupPanel_Summary.Style.CornerDiameter = 4;
			this._groupPanel_Summary.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
			this._groupPanel_Summary.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this._groupPanel_Summary.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
			// 
			// 
			// 
			this._groupPanel_Summary.StyleMouseDown.Class = "";
			this._groupPanel_Summary.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			// 
			// 
			// 
			this._groupPanel_Summary.StyleMouseOver.Class = "";
			this._groupPanel_Summary.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this._groupPanel_Summary.TabIndex = 10;
			this._groupPanel_Summary.Text = "Summary";
			// 
			// _labelX_HelpTitle
			// 
			// 
			// 
			// 
			this._labelX_HelpTitle.BackgroundStyle.Class = "";
			this._labelX_HelpTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this._labelX_HelpTitle.Location = new System.Drawing.Point(4, 1);
			this._labelX_HelpTitle.Name = "_labelX_HelpTitle";
			this._labelX_HelpTitle.Size = new System.Drawing.Size(279, 16);
			this._labelX_HelpTitle.TabIndex = 73;
			this._labelX_HelpTitle.Text = "<b><u>Disk Space Summary</u></b>";
			// 
			// _labelX_HelpText
			// 
			// 
			// 
			// 
			this._labelX_HelpText.BackgroundStyle.Class = "";
			this._labelX_HelpText.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this._labelX_HelpText.Location = new System.Drawing.Point(4, 15);
			this._labelX_HelpText.Name = "_labelX_HelpText";
			this._labelX_HelpText.Size = new System.Drawing.Size(279, 66);
			this._labelX_HelpText.TabIndex = 72;
			this._labelX_HelpText.Text = resources.GetString("_labelX_HelpText.Text");
			this._labelX_HelpText.TextLineAlignment = System.Drawing.StringAlignment.Near;
			this._labelX_HelpText.WordWrap = true;
			// 
			// pictureBox7
			// 
			this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox7.Image = global::Idera.SqlAdminToolset.SpaceAnalyzer.Properties.Resources.harddisk_ok_24;
			this.pictureBox7.Location = new System.Drawing.Point(303, 54);
			this.pictureBox7.Name = "pictureBox7";
			this.pictureBox7.Size = new System.Drawing.Size(24, 24);
			this.pictureBox7.TabIndex = 71;
			this.pictureBox7.TabStop = false;
			// 
			// _labelX_Acceptable
			// 
			this._labelX_Acceptable.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this._labelX_Acceptable.BackgroundStyle.Class = "";
			this._labelX_Acceptable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this._labelX_Acceptable.Location = new System.Drawing.Point(333, 59);
			this._labelX_Acceptable.Name = "_labelX_Acceptable";
			this._labelX_Acceptable.Size = new System.Drawing.Size(302, 14);
			this._labelX_Acceptable.TabIndex = 69;
			this._labelX_Acceptable.Text = "Acceptable";
			// 
			// pictureBox8
			// 
			this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox8.Image = global::Idera.SqlAdminToolset.SpaceAnalyzer.Properties.Resources.harddisk_warning_24;
			this.pictureBox8.Location = new System.Drawing.Point(303, 26);
			this.pictureBox8.Name = "pictureBox8";
			this.pictureBox8.Size = new System.Drawing.Size(24, 24);
			this.pictureBox8.TabIndex = 67;
			this.pictureBox8.TabStop = false;
			// 
			// _labelX_Caution
			// 
			this._labelX_Caution.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this._labelX_Caution.BackgroundStyle.Class = "";
			this._labelX_Caution.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this._labelX_Caution.Location = new System.Drawing.Point(333, 32);
			this._labelX_Caution.Name = "_labelX_Caution";
			this._labelX_Caution.Size = new System.Drawing.Size(302, 14);
			this._labelX_Caution.TabIndex = 65;
			this._labelX_Caution.Text = "Caution";
			// 
			// pictureBox9
			// 
			this.pictureBox9.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox9.Image = global::Idera.SqlAdminToolset.SpaceAnalyzer.Properties.Resources.harddisk_error_24;
			this.pictureBox9.Location = new System.Drawing.Point(303, -2);
			this.pictureBox9.Name = "pictureBox9";
			this.pictureBox9.Size = new System.Drawing.Size(24, 24);
			this.pictureBox9.TabIndex = 63;
			this.pictureBox9.TabStop = false;
			// 
			// _labelX_Critical
			// 
			this._labelX_Critical.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this._labelX_Critical.BackgroundStyle.Class = "";
			this._labelX_Critical.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this._labelX_Critical.Location = new System.Drawing.Point(333, 5);
			this._labelX_Critical.Name = "_labelX_Critical";
			this._labelX_Critical.Size = new System.Drawing.Size(302, 14);
			this._labelX_Critical.TabIndex = 61;
			this._labelX_Critical.Text = "123 Disk with 85% or more Used Space";
			// 
			// _dataGridViewX_Files
			// 
			this._dataGridViewX_Files.AllowUserToAddRows = false;
			this._dataGridViewX_Files.AllowUserToDeleteRows = false;
			this._dataGridViewX_Files.AllowUserToOrderColumns = true;
			this._dataGridViewX_Files.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
			this._dataGridViewX_Files.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this._dataGridViewX_Files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._dataGridViewX_Files.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this._dataGridViewX_Files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this._dataGridViewX_Files.ContextMenuStrip = this.contextMenuStrip1;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this._dataGridViewX_Files.DefaultCellStyle = dataGridViewCellStyle2;
			this._dataGridViewX_Files.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
			this._dataGridViewX_Files.HighlightSelectedColumnHeaders = false;
			this._dataGridViewX_Files.Location = new System.Drawing.Point(0, 149);
			this._dataGridViewX_Files.Name = "_dataGridViewX_Files";
			this._dataGridViewX_Files.ReadOnly = true;
			this._dataGridViewX_Files.RowHeadersVisible = false;
			this._dataGridViewX_Files.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this._dataGridViewX_Files.Size = new System.Drawing.Size(955, 225);
			this._dataGridViewX_Files.TabIndex = 0;
			this._dataGridViewX_Files.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._dataGridViewX_Files_CellDoubleClick);
			this._dataGridViewX_Files.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._dataGridViewX_Files_CellFormatting);
			this._dataGridViewX_Files.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._dataGridViewX_Files_CellMouseDown);
			this._dataGridViewX_Files.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this._dataGridViewX_Files_CellPainting);
			this._dataGridViewX_Files.SelectionChanged += new System.EventHandler(this._dataGridViewX_Files_SelectionChanged);
			this._dataGridViewX_Files.MouseDown += new System.Windows.Forms.MouseEventHandler(this._dataGridViewX_Files_MouseDown);
			this._dataGridViewX_Files.MouseHover += new System.EventHandler(this._dataGridViewX_Files_MouseHover);
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
            this.fileSavetoXMLMenuItem});
			this.fileSaveMenu.Enabled = false;
			this.fileSaveMenu.Name = "fileSaveMenu";
			this.fileSaveMenu.Size = new System.Drawing.Size(169, 22);
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
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.Enabled = false;
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			this.printToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.printToolStripMenuItem.Text = "&Print";
			this.printToolStripMenuItem.Visible = false;
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(166, 6);
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
			// editMenu
			// 
			this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editCopyMenuItem,
            this.editSelectAllMenuItem,
            this.menuFileProperties});
			this.editMenu.Name = "editMenu";
			this.editMenu.Size = new System.Drawing.Size(39, 20);
			this.editMenu.Text = "&Edit";
			// 
			// editCopyMenuItem
			// 
			this.editCopyMenuItem.Enabled = false;
			this.editCopyMenuItem.Image = global::Idera.SqlAdminToolset.SpaceAnalyzer.Properties.Resources.copy_16;
			this.editCopyMenuItem.Name = "editCopyMenuItem";
			this.editCopyMenuItem.Size = new System.Drawing.Size(148, 22);
			this.editCopyMenuItem.Text = "&Copy";
			this.editCopyMenuItem.Click += new System.EventHandler(this.editCopyMenuItem_Click);
			// 
			// editSelectAllMenuItem
			// 
			this.editSelectAllMenuItem.Enabled = false;
			this.editSelectAllMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editSelectAllMenuItem.Image")));
			this.editSelectAllMenuItem.Name = "editSelectAllMenuItem";
			this.editSelectAllMenuItem.Size = new System.Drawing.Size(148, 22);
			this.editSelectAllMenuItem.Text = "Select &All";
			this.editSelectAllMenuItem.Click += new System.EventHandler(this.editSelectAllMenuItem_Click);
			// 
			// menuFileProperties
			// 
			this.menuFileProperties.Image = global::Idera.SqlAdminToolset.SpaceAnalyzer.Properties.Resources.file_view_16;
			this.menuFileProperties.Name = "menuFileProperties";
			this.menuFileProperties.Size = new System.Drawing.Size(148, 22);
			this.menuFileProperties.Text = "File &Properties";
			this.menuFileProperties.Click += new System.EventHandler(this.menuFileProperties_Click);
			// 
			// menuTools
			// 
			this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManageServerGroups,
            this.menuToolsetOptions,
            this.toolStripMenuItem4,
            this.menuLaunchpad});
			this.menuTools.Name = "menuTools";
			this.menuTools.Size = new System.Drawing.Size(46, 20);
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
			this.imageList1.Images.SetKeyName(2, "AllServers.png");
			this.imageList1.Images.SetKeyName(3, "Computer.png");
			this.imageList1.Images.SetKeyName(4, "harddisk_ok.png");
			this.imageList1.Images.SetKeyName(5, "harddisk_warning.png");
			this.imageList1.Images.SetKeyName(6, "harddisk_error.png");
			this.imageList1.Images.SetKeyName(7, "harddisk_unknown.png");
			this.imageList1.Images.SetKeyName(8, "DataFile.png");
			this.imageList1.Images.SetKeyName(9, "LogFile.png");
			// 
			// ideraTitleBar1
			// 
			this.ideraTitleBar1.ActivateLicenseEventHandler = null;
			this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
			this.ideraTitleBar1.Close = true;
			this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
			this.ideraTitleBar1.IderaProductNameText = "SQL Space Analyzer";
			this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
			this.ideraTitleBar1.IsFormLocked = false;
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
			// checkBox_EnableWMI
			// 
			// 
			// 
			// 
			this.checkBox_EnableWMI.BackgroundStyle.Class = "";
			this.checkBox_EnableWMI.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.checkBox_EnableWMI.Checked = true;
			this.checkBox_EnableWMI.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_EnableWMI.CheckValue = "Y";
			this.checkBox_EnableWMI.Location = new System.Drawing.Point(6, 73);
			this.checkBox_EnableWMI.Name = "checkBox_EnableWMI";
			this.checkBox_EnableWMI.Size = new System.Drawing.Size(135, 23);
			this.checkBox_EnableWMI.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.checkBox_EnableWMI.TabIndex = 16;
			this.checkBox_EnableWMI.Text = "Use WMI Connection";
			this.checkBox_EnableWMI.CheckedChanged += new System.EventHandler(this.checkBox_EnableWMI_CheckedChanged);
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
			this.MinimumSize = new System.Drawing.Size(1024, 426);
			this.Name = "Form_Main";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
			this.panelMiddle.ResumeLayout(false);
			this.groupPanel1.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.panelTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
			this.panelBottom.ResumeLayout(false);
			this.groupPanel6.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this._advTree_Disks)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupPanel7.ResumeLayout(false);
			this._groupPanel_Summary.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._dataGridViewX_Files)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMiddle;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX buttonLoadIndexes;
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
        //  private System.Windows.Forms.DataGridView dataGridViewX1;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonX buttonCopyToClipboard;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contextMenuCopy;
        private System.Windows.Forms.ToolStripMenuItem contextMenuSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExport;
        private System.Windows.Forms.ToolStripMenuItem contextMenuCSV;
        private System.Windows.Forms.ToolStripMenuItem contextMenuXML;
        private System.Windows.Forms.ToolStripMenuItem fileSaveMenu;
        private System.Windows.Forms.ToolStripMenuItem fileSavetoCVSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSavetoXMLMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contextMenuFileProperties;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel6;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private DevComponents.AdvTree.Node node3;
        private DevComponents.AdvTree.NodeConnector nodeConnector3;
        private DevComponents.DotNetBar.ElementStyle elementStyle3;
        private DevComponents.DotNetBar.LabelX _labelX_FilterText;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx _comboBoxEx_View;
        private DevComponents.DotNetBar.Controls.ComboBoxEx _comboBoxEx_Datatypeview;
        private DevComponents.DotNetBar.Controls.CheckBoxX _checkBoxX_HideLogFiles;
        private DevComponents.DotNetBar.Controls.CheckBoxX _checkBoxX_HideDataFiles;
        private DevComponents.DotNetBar.LabelX _labelX_FilesTitle;
        private DevComponents.DotNetBar.Controls.GroupPanel _groupPanel_Summary;
        private DevComponents.DotNetBar.LabelX _labelX_HelpTitle;
        private DevComponents.DotNetBar.LabelX _labelX_HelpText;
        private System.Windows.Forms.PictureBox pictureBox7;
        private DevComponents.DotNetBar.LabelX _labelX_Acceptable;
        private System.Windows.Forms.PictureBox pictureBox8;
        private DevComponents.DotNetBar.LabelX _labelX_Caution;
        private System.Windows.Forms.PictureBox pictureBox9;
        private DevComponents.DotNetBar.LabelX _labelX_Critical;
        private DevComponents.DotNetBar.Controls.DataGridViewX _dataGridViewX_Files;
        private DevComponents.AdvTree.AdvTree _advTree_Disks;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem editCopyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSelectAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuFileProperties;
        private Idera.SqlAdminToolset.Core.Controls.ToolServerSelection ServerSelection;
        private System.Windows.Forms.Panel panel1;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
		private DevComponents.DotNetBar.Controls.CheckBoxX checkBox_EnableWMI;
	}
}

