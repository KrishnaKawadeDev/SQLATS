namespace Idera.SqlAdminToolset.PatchEditor
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Unknown", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("SQL Server 2008", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("SQL Server 2005", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("SQL Server 2000", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("SQL Server 7.0", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("SQL Server  6.5", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "6.00.1025",
            "RTM + hotfix",
            "Yes",
            "Mainstream support until 12/25/2009",
            "0",
            "http://support.microsoft.com/kb/220156/",
            "B 220156: FIX: SQL Cluster Install Fails When SVS Name Contains Special Character" +
                "s "}, -1);
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.buttonSaveAs = new DevComponents.DotNetBar.ButtonX();
            this.buttonSaveBuildList = new DevComponents.DotNetBar.ButtonX();
            this.buttonLoadServerData = new DevComponents.DotNetBar.ButtonX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuAddBuild = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuEditBuild = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuRemoveBuild = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuProperties = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuViewKBArticle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuShowGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.textMax2005 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.textMax70 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.textMax2008 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.textMax2000 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.buttonRemoveBuild = new DevComponents.DotNetBar.ButtonX();
            this.textDirty = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonShowKbArticle = new DevComponents.DotNetBar.ButtonX();
            this.buttonEditBuildProperties = new DevComponents.DotNetBar.ButtonX();
            this.buttonAddNewBuild = new DevComponents.DotNetBar.ButtonX();
            this.textFileName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBuildListDate = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelFileName = new DevComponents.DotNetBar.LabelX();
            this.listViewSQL = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnBuild = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSupported = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSupportStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUrlType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnVersionName= ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columncolumnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelBuildListDate = new DevComponents.DotNetBar.LabelX();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.manageLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.panelMiddle.SuspendLayout();
            this.groupPanel1.SuspendLayout();
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
            this.panelMiddle.Size = new System.Drawing.Size(1017, 69);
            this.panelMiddle.TabIndex = 14;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.linkLabel5);
            this.groupPanel1.Controls.Add(this.linkLabel4);
            this.groupPanel1.Controls.Add(this.linkLabel3);
            this.groupPanel1.Controls.Add(this.linkLabel2);
            this.groupPanel1.Controls.Add(this.linkLabel1);
            this.groupPanel1.Controls.Add(this.buttonSaveAs);
            this.groupPanel1.Controls.Add(this.buttonSaveBuildList);
            this.groupPanel1.Controls.Add(this.buttonLoadServerData);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.IsShadowEnabled = true;
            this.groupPanel1.Location = new System.Drawing.Point(6, 6);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1005, 57);
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
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(626, 29);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(97, 15);
            this.labelX6.TabIndex = 11;
            this.labelX6.Text = "merickson;idera*88";
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel5.Location = new System.Drawing.Point(748, 1);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(147, 13);
            this.linkLabel5.TabIndex = 8;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "Search MS support for a build";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel4.Location = new System.Drawing.Point(748, 18);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(156, 13);
            this.linkLabel4.TabIndex = 7;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "2008 Builds released after RTM";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel3.Location = new System.Drawing.Point(506, 29);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(103, 13);
            this.linkLabel3.TabIndex = 6;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Upload to Idera.com";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Location = new System.Drawing.Point(748, 35);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(108, 13);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Another site for builds";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(506, 8);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(109, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Site with List of Builds";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSaveAs.BackColor = System.Drawing.Color.White;
            this.buttonSaveAs.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSaveAs.Enabled = false;
            this.buttonSaveAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveAs.Image")));
            this.buttonSaveAs.Location = new System.Drawing.Point(351, 8);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(122, 35);
            this.buttonSaveAs.TabIndex = 3;
            this.buttonSaveAs.Text = "Save As ...";
            this.buttonSaveAs.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // buttonSaveBuildList
            // 
            this.buttonSaveBuildList.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonSaveBuildList.BackColor = System.Drawing.Color.White;
            this.buttonSaveBuildList.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonSaveBuildList.Enabled = false;
            this.buttonSaveBuildList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveBuildList.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveBuildList.Image")));
            this.buttonSaveBuildList.Location = new System.Drawing.Point(219, 7);
            this.buttonSaveBuildList.Name = "buttonSaveBuildList";
            this.buttonSaveBuildList.Size = new System.Drawing.Size(117, 35);
            this.buttonSaveBuildList.TabIndex = 2;
            this.buttonSaveBuildList.Text = "Save";
            this.buttonSaveBuildList.Click += new System.EventHandler(this.buttonSaveBuildList_Click);
            // 
            // buttonLoadServerData
            // 
            this.buttonLoadServerData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonLoadServerData.BackColor = System.Drawing.Color.White;
            this.buttonLoadServerData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonLoadServerData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadServerData.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoadServerData.Image")));
            this.buttonLoadServerData.Location = new System.Drawing.Point(9, 7);
            this.buttonLoadServerData.Name = "buttonLoadServerData";
            this.buttonLoadServerData.Size = new System.Drawing.Size(192, 35);
            this.buttonLoadServerData.TabIndex = 1;
            this.buttonLoadServerData.Text = "Load Build List";
            this.buttonLoadServerData.Click += new System.EventHandler(this.buttonGetResults_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuAddBuild,
            this.contextMenuEditBuild,
            this.contextMenuRemoveBuild,
            this.contextMenuProperties,
            this.contextMenuViewKBArticle,
            this.toolStripMenuItem8,
            this.contextMenuShowGroups,
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(283, 132);
            // 
            // contextMenuAddBuild
            // 
            this.contextMenuAddBuild.Enabled = false;
            this.contextMenuAddBuild.Name = "contextMenuAddBuild";
            this.contextMenuAddBuild.Size = new System.Drawing.Size(282, 22);
            this.contextMenuAddBuild.Text = "Add Build";
            this.contextMenuAddBuild.Click += new System.EventHandler(this.contextMenuAddBuild_Click);
            // 
            // contextMenuEditBuild
            // 
            this.contextMenuEditBuild.Enabled = false;
            this.contextMenuEditBuild.Name = "contextMenuEditBuild";
            this.contextMenuEditBuild.Size = new System.Drawing.Size(282, 22);
            this.contextMenuEditBuild.Text = "Edit Build Properties";
            this.contextMenuEditBuild.Click += new System.EventHandler(this.contextMenuEditBuild_Click);
            // 
            // contextMenuRemoveBuild
            // 
            this.contextMenuRemoveBuild.Enabled = false;
            this.contextMenuRemoveBuild.Name = "contextMenuRemoveBuild";
            this.contextMenuRemoveBuild.Size = new System.Drawing.Size(282, 22);
            this.contextMenuRemoveBuild.Text = "Remove Build";
            this.contextMenuRemoveBuild.Click += new System.EventHandler(this.removeBuildToolStripMenuItem_Click);
            // 
            // contextMenuProperties
            // 
            this.contextMenuProperties.Name = "contextMenuProperties";
            this.contextMenuProperties.Size = new System.Drawing.Size(279, 6);
            // 
            // contextMenuViewKBArticle
            // 
            this.contextMenuViewKBArticle.Enabled = false;
            this.contextMenuViewKBArticle.Name = "contextMenuViewKBArticle";
            this.contextMenuViewKBArticle.Size = new System.Drawing.Size(282, 22);
            this.contextMenuViewKBArticle.Text = "&View Microsoft Knowledge Base Article ";
            this.contextMenuViewKBArticle.Click += new System.EventHandler(this.contextMenuViewKBArticle_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(279, 6);
            // 
            // contextMenuShowGroups
            // 
            this.contextMenuShowGroups.Enabled = false;
            this.contextMenuShowGroups.Name = "contextMenuShowGroups";
            this.contextMenuShowGroups.Size = new System.Drawing.Size(282, 22);
            this.contextMenuShowGroups.Text = "Show &Groups";
            this.contextMenuShowGroups.Click += new System.EventHandler(this.contextMenuShowGroups_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(279, 6);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "check.png");
            this.imageList.Images.SetKeyName(1, "error.png");
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTop.Controls.Add(this.labelX9);
            this.panelTop.Controls.Add(this.labelX8);
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Controls.Add(this.labelX7);
            this.panelTop.Controls.Add(this.labelSubtitle);
            this.panelTop.Controls.Add(this.pictureBoxTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 117);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1017, 52);
            this.panelTop.TabIndex = 16;
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(620, 34);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(265, 15);
            this.labelX9.TabIndex = 14;
            this.labelX9.Text = "3. Click \"Upload to Idera.com\" to update Idera website";
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
            this.labelX8.Location = new System.Drawing.Point(620, 18);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(89, 15);
            this.labelX8.TabIndex = 13;
            this.labelX8.Text = "2. \"Save\" the file ";
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
            this.labelTitle.Size = new System.Drawing.Size(175, 52);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.TabStop = false;
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Patch Editor</font></b> ";
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
            this.labelX7.Location = new System.Drawing.Point(620, 2);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(339, 15);
            this.labelX7.TabIndex = 12;
            this.labelX7.Text = "1. Check the \"Site with List of Builds\" for new hotfixes - add new ones";
            // 
            // labelSubtitle
            // 
            // 
            // 
            // 
            this.labelSubtitle.BackgroundStyle.Class = "";
            this.labelSubtitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.Location = new System.Drawing.Point(246, 0);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(346, 52);
            this.labelSubtitle.TabIndex = 6;
            this.labelSubtitle.Text = "View and Edit the build list used by the Patch Analyzer tool";
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
            this.panelBottom.Controls.Add(this.textMax2005);
            this.panelBottom.Controls.Add(this.labelX5);
            this.panelBottom.Controls.Add(this.textMax70);
            this.panelBottom.Controls.Add(this.labelX4);
            this.panelBottom.Controls.Add(this.textMax2008);
            this.panelBottom.Controls.Add(this.labelX3);
            this.panelBottom.Controls.Add(this.textMax2000);
            this.panelBottom.Controls.Add(this.labelX2);
            this.panelBottom.Controls.Add(this.buttonRemoveBuild);
            this.panelBottom.Controls.Add(this.textDirty);
            this.panelBottom.Controls.Add(this.labelX1);
            this.panelBottom.Controls.Add(this.buttonShowKbArticle);
            this.panelBottom.Controls.Add(this.buttonEditBuildProperties);
            this.panelBottom.Controls.Add(this.buttonAddNewBuild);
            this.panelBottom.Controls.Add(this.textFileName);
            this.panelBottom.Controls.Add(this.textBuildListDate);
            this.panelBottom.Controls.Add(this.labelFileName);
            this.panelBottom.Controls.Add(this.listViewSQL);
            this.panelBottom.Controls.Add(this.labelBuildListDate);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 238);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.panelBottom.Size = new System.Drawing.Size(1017, 470);
            this.panelBottom.TabIndex = 17;
            // 
            // textMax2005
            // 
            // 
            // 
            // 
            this.textMax2005.Border.Class = "TextBoxBorder";
            this.textMax2005.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textMax2005.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMax2005.Location = new System.Drawing.Point(432, 36);
            this.textMax2005.Name = "textMax2005";
            this.textMax2005.Size = new System.Drawing.Size(90, 24);
            this.textMax2005.TabIndex = 20;
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
            this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(326, 38);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(120, 19);
            this.labelX5.TabIndex = 19;
            this.labelX5.Text = "Max 2005 Build:";
            // 
            // textMax70
            // 
            // 
            // 
            // 
            this.textMax70.Border.Class = "TextBoxBorder";
            this.textMax70.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textMax70.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMax70.Location = new System.Drawing.Point(843, 36);
            this.textMax70.Name = "textMax70";
            this.textMax70.Size = new System.Drawing.Size(90, 24);
            this.textMax70.TabIndex = 18;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(750, 38);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(97, 19);
            this.labelX4.TabIndex = 17;
            this.labelX4.Text = "Max 7.0 Build:";
            // 
            // textMax2008
            // 
            // 
            // 
            // 
            this.textMax2008.Border.Class = "TextBoxBorder";
            this.textMax2008.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textMax2008.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMax2008.Location = new System.Drawing.Point(221, 36);
            this.textMax2008.Name = "textMax2008";
            this.textMax2008.Size = new System.Drawing.Size(90, 24);
            this.textMax2008.TabIndex = 16;
            this.textMax2008.Text = "10.1752.0";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(115, 38);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(110, 19);
            this.labelX3.TabIndex = 15;
            this.labelX3.Text = "Max 2008 Build:";
            // 
            // textMax2000
            // 
            // 
            // 
            // 
            this.textMax2000.Border.Class = "TextBoxBorder";
            this.textMax2000.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textMax2000.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMax2000.Location = new System.Drawing.Point(645, 36);
            this.textMax2000.Name = "textMax2000";
            this.textMax2000.Size = new System.Drawing.Size(90, 24);
            this.textMax2000.TabIndex = 14;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(539, 38);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(110, 19);
            this.labelX2.TabIndex = 13;
            this.labelX2.Text = "Max 2000 Build:";
            // 
            // buttonRemoveBuild
            // 
            this.buttonRemoveBuild.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonRemoveBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveBuild.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonRemoveBuild.Enabled = false;
            this.buttonRemoveBuild.Location = new System.Drawing.Point(314, 436);
            this.buttonRemoveBuild.Name = "buttonRemoveBuild";
            this.buttonRemoveBuild.Size = new System.Drawing.Size(148, 22);
            this.buttonRemoveBuild.TabIndex = 12;
            this.buttonRemoveBuild.Text = "Remove Build";
            this.buttonRemoveBuild.Click += new System.EventHandler(this.buttonRemoveBuild_Click);
            // 
            // textDirty
            // 
            // 
            // 
            // 
            this.textDirty.Border.Class = "TextBoxBorder";
            this.textDirty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textDirty.Location = new System.Drawing.Point(332, 3);
            this.textDirty.Name = "textDirty";
            this.textDirty.Size = new System.Drawing.Size(44, 20);
            this.textDirty.TabIndex = 11;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(228, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(98, 15);
            this.labelX1.TabIndex = 10;
            this.labelX1.Text = "Build List Changed:";
            // 
            // buttonShowKbArticle
            // 
            this.buttonShowKbArticle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonShowKbArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowKbArticle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonShowKbArticle.Enabled = false;
            this.buttonShowKbArticle.Location = new System.Drawing.Point(863, 436);
            this.buttonShowKbArticle.Name = "buttonShowKbArticle";
            this.buttonShowKbArticle.Size = new System.Drawing.Size(148, 22);
            this.buttonShowKbArticle.TabIndex = 9;
            this.buttonShowKbArticle.Text = "Show KB Article";
            this.buttonShowKbArticle.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonEditBuildProperties
            // 
            this.buttonEditBuildProperties.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonEditBuildProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEditBuildProperties.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonEditBuildProperties.Enabled = false;
            this.buttonEditBuildProperties.Location = new System.Drawing.Point(160, 436);
            this.buttonEditBuildProperties.Name = "buttonEditBuildProperties";
            this.buttonEditBuildProperties.Size = new System.Drawing.Size(148, 22);
            this.buttonEditBuildProperties.TabIndex = 8;
            this.buttonEditBuildProperties.Text = "Edit Build Properties";
            this.buttonEditBuildProperties.Click += new System.EventHandler(this.buttonEditBuildProperties_Click);
            // 
            // buttonAddNewBuild
            // 
            this.buttonAddNewBuild.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAddNewBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddNewBuild.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonAddNewBuild.Enabled = false;
            this.buttonAddNewBuild.Location = new System.Drawing.Point(6, 436);
            this.buttonAddNewBuild.Name = "buttonAddNewBuild";
            this.buttonAddNewBuild.Size = new System.Drawing.Size(148, 22);
            this.buttonAddNewBuild.TabIndex = 7;
            this.buttonAddNewBuild.Text = "Add New Build";
            this.buttonAddNewBuild.Click += new System.EventHandler(this.buttonAddNewBuild_Click);
            // 
            // textFileName
            // 
            // 
            // 
            // 
            this.textFileName.Border.Class = "TextBoxBorder";
            this.textFileName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textFileName.Location = new System.Drawing.Point(455, 3);
            this.textFileName.Name = "textFileName";
            this.textFileName.Size = new System.Drawing.Size(553, 20);
            this.textFileName.TabIndex = 6;
            this.textFileName.Text = "..\\..\\SQLServerVersionList.xml";
            // 
            // textBuildListDate
            // 
            // 
            // 
            // 
            this.textBuildListDate.Border.Class = "TextBoxBorder";
            this.textBuildListDate.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBuildListDate.Location = new System.Drawing.Point(100, 3);
            this.textBuildListDate.Name = "textBuildListDate";
            this.textBuildListDate.Size = new System.Drawing.Size(112, 20);
            this.textBuildListDate.TabIndex = 4;
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelFileName.BackgroundStyle.Class = "";
            this.labelFileName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelFileName.Location = new System.Drawing.Point(393, 5);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(56, 15);
            this.labelFileName.TabIndex = 5;
            this.labelFileName.Text = "File Name:";
            // 
            // listViewSQL
            // 
            this.listViewSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.listViewSQL.Border.Class = "ListViewBorder";
            this.listViewSQL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewSQL.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnBuild,
            this.columnLevel,
            this.columnSupported,
            this.columnSupportStatus,
            this.columnUrlType,
            this.columnUrl,
            this.columncolumnTitle,
            this.columnVersionName});
            this.listViewSQL.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewSQL.FullRowSelect = true;
            listViewGroup1.Header = "Unknown";
            listViewGroup1.Name = "groupUnknown";
            listViewGroup2.Header = "SQL Server 2008";
            listViewGroup2.Name = "group2008";
            listViewGroup3.Header = "SQL Server 2005";
            listViewGroup3.Name = "group2005";
            listViewGroup4.Header = "SQL Server 2000";
            listViewGroup4.Name = "group2000";
            listViewGroup5.Header = "SQL Server 7.0";
            listViewGroup5.Name = "group70";
            listViewGroup6.Header = "SQL Server  6.5";
            listViewGroup6.Name = "group65";
            this.listViewSQL.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6});
            this.listViewSQL.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listViewSQL.Location = new System.Drawing.Point(5, 77);
            this.listViewSQL.MultiSelect = false;
            this.listViewSQL.Name = "listViewSQL";
            this.listViewSQL.ShowGroups = false;
            this.listViewSQL.Size = new System.Drawing.Size(1003, 350);
            this.listViewSQL.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewSQL.TabIndex = 2;
            this.listViewSQL.UseCompatibleStateImageBehavior = false;
            this.listViewSQL.View = System.Windows.Forms.View.Details;
            this.listViewSQL.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listSQL_ColumnClick);
            this.listViewSQL.SelectedIndexChanged += new System.EventHandler(this.listViewSQL_SelectedIndexChanged);
            this.listViewSQL.DoubleClick += new System.EventHandler(this.listViewSQL_DoubleClick);
            // 
            // columnBuild
            // 
            this.columnBuild.Text = "Build";
            this.columnBuild.Width = 80;
            // 
            // columnLevel
            // 
            this.columnLevel.Text = "Level";
            this.columnLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnLevel.Width = 77;
            // 
            // columnSupported
            // 
            this.columnSupported.Text = "Supported";
            this.columnSupported.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnSupported.Width = 68;
            // 
            // columnSupportStatus
            // 
            this.columnSupportStatus.Text = "Status";
            this.columnSupportStatus.Width = 188;
            // 
            // columnUrlType
            // 
            this.columnUrlType.Text = "URL Type";
            this.columnUrlType.Width = 66;
            // 
            // columnUrl
            // 
            this.columnUrl.Text = "URL";
            this.columnUrl.Width = 170;
            //
            //columnVersionName
            //
            this.columnVersionName.Text = "VersionName";
            this.columnVersionName.Width = 250;
            // 
            // columncolumnTitle
            // 
            this.columncolumnTitle.Text = "Title";
            this.columncolumnTitle.Width = 348;
            // 
            // labelBuildListDate
            // 
            this.labelBuildListDate.AutoSize = true;
            this.labelBuildListDate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelBuildListDate.BackgroundStyle.Class = "";
            this.labelBuildListDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelBuildListDate.Location = new System.Drawing.Point(5, 5);
            this.labelBuildListDate.Name = "labelBuildListDate";
            this.labelBuildListDate.Size = new System.Drawing.Size(89, 15);
            this.labelBuildListDate.TabIndex = 3;
            this.labelBuildListDate.Text = "Date of Build List:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuView,
            this.menuTools,
            this.menuAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 93);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1017, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(92, 22);
            this.menuFileExit.Text = "E&xit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowGroups});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(44, 20);
            this.menuView.Text = "&View";
            // 
            // menuShowGroups
            // 
            this.menuShowGroups.Enabled = false;
            this.menuShowGroups.Name = "menuShowGroups";
            this.menuShowGroups.Size = new System.Drawing.Size(144, 22);
            this.menuShowGroups.Text = "Show &Groups";
            this.menuShowGroups.Click += new System.EventHandler(this.menuShowGroups_Click);
            // 
            // menuTools
            // 
            this.menuTools.Enabled = false;
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(47, 20);
            this.menuTools.Text = "Tools";
            // 
            // menuAbout
            // 
            this.menuAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageLicenseToolStripMenuItem});
            this.menuAbout.Enabled = false;
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(44, 20);
            this.menuAbout.Text = "Help";
            // 
            // manageLicenseToolStripMenuItem
            // 
            this.manageLicenseToolStripMenuItem.Name = "manageLicenseToolStripMenuItem";
            this.manageLicenseToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.manageLicenseToolStripMenuItem.Text = "Manage &License";
            this.manageLicenseToolStripMenuItem.Click += new System.EventHandler(this.manageLicenseToolStripMenuItem_Click);
            // 
            // ideraTitleBar1
            // 
            this.ideraTitleBar1.ActivateLicenseEventHandler = null;
            this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
            this.ideraTitleBar1.Close = true;
            this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
            this.ideraTitleBar1.IderaProductNameText = "SQL Patch Editor";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.IsFormLocked = false;
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = true;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(1017, 93);
            this.ideraTitleBar1.TabIndex = 20;
            this.ideraTitleBar1.TrialMode = true;
            this.ideraTitleBar1.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar1_LicenseInfoButtonClick);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1017, 708);
            this.ControlBox = false;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ideraTitleBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(736, 426);
            this.Name = "Form_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.panelMiddle.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panelMiddle;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.ButtonX buttonLoadServerData;
      private System.Windows.Forms.Panel panelTop;
      private DevComponents.DotNetBar.LabelX labelTitle;
      private DevComponents.DotNetBar.LabelX labelSubtitle;
      private System.Windows.Forms.PictureBox pictureBoxTitle;
      private System.Windows.Forms.Panel panelBottom;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem menuFile;
      private System.Windows.Forms.ToolStripMenuItem menuFileExit;
      private System.Windows.Forms.ToolStripMenuItem menuView;
      private System.Windows.Forms.ToolStripMenuItem menuShowGroups;
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
      private System.Windows.Forms.ToolStripMenuItem contextMenuShowGroups;
      private System.Windows.Forms.ToolStripMenuItem contextMenuViewKBArticle;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
      private System.Windows.Forms.ImageList imageList;
      private System.Windows.Forms.ToolStripSeparator contextMenuProperties;
      private DevComponents.DotNetBar.ButtonX buttonSaveBuildList;
      private DevComponents.DotNetBar.Controls.ListViewEx listViewSQL;
      private System.Windows.Forms.ColumnHeader columnBuild;
      private System.Windows.Forms.ColumnHeader columnLevel;
      private System.Windows.Forms.ColumnHeader columnSupported;
      private System.Windows.Forms.ColumnHeader columnSupportStatus;
      private System.Windows.Forms.ColumnHeader columncolumnTitle;
      private System.Windows.Forms.ColumnHeader columnUrl;
      private System.Windows.Forms.ColumnHeader columnVersionName;
      private DevComponents.DotNetBar.Controls.TextBoxX textBuildListDate;
      private DevComponents.DotNetBar.LabelX labelBuildListDate;
      private System.Windows.Forms.ColumnHeader columnUrlType;
      private System.Windows.Forms.ToolStripMenuItem menuTools;
      private System.Windows.Forms.ToolStripMenuItem menuAbout;
      private DevComponents.DotNetBar.Controls.TextBoxX textFileName;
      private DevComponents.DotNetBar.LabelX labelFileName;
      private System.Windows.Forms.ToolStripMenuItem contextMenuEditBuild;
      private System.Windows.Forms.ToolStripMenuItem contextMenuAddBuild;
      private DevComponents.DotNetBar.ButtonX buttonShowKbArticle;
      private DevComponents.DotNetBar.ButtonX buttonEditBuildProperties;
      private DevComponents.DotNetBar.ButtonX buttonAddNewBuild;
      private DevComponents.DotNetBar.Controls.TextBoxX textDirty;
      private DevComponents.DotNetBar.LabelX labelX1;
      private System.Windows.Forms.ToolStripMenuItem contextMenuRemoveBuild;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private DevComponents.DotNetBar.ButtonX buttonRemoveBuild;
      private DevComponents.DotNetBar.ButtonX buttonSaveAs;
      private System.Windows.Forms.LinkLabel linkLabel1;
      private System.Windows.Forms.LinkLabel linkLabel3;
      private System.Windows.Forms.LinkLabel linkLabel2;
      private System.Windows.Forms.LinkLabel linkLabel4;
      private DevComponents.DotNetBar.Controls.TextBoxX textMax2005;
      private DevComponents.DotNetBar.LabelX labelX5;
      private DevComponents.DotNetBar.Controls.TextBoxX textMax70;
      private DevComponents.DotNetBar.LabelX labelX4;
      private DevComponents.DotNetBar.Controls.TextBoxX textMax2008;
      private DevComponents.DotNetBar.LabelX labelX3;
      private DevComponents.DotNetBar.Controls.TextBoxX textMax2000;
      private DevComponents.DotNetBar.LabelX labelX2;
       private System.Windows.Forms.LinkLabel linkLabel5;
       private DevComponents.DotNetBar.LabelX labelX6;
       private DevComponents.DotNetBar.LabelX labelX9;
       private DevComponents.DotNetBar.LabelX labelX8;
       private DevComponents.DotNetBar.LabelX labelX7;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
        private System.Windows.Forms.ToolStripMenuItem manageLicenseToolStripMenuItem;
    }
}

