namespace Idera.SqlAdminToolset.PatchAnalyzer
{
   partial class Form_VersionList
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Unknown", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("SQL Server 2014", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("SQL Server 2012", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("SQL Server 2008 R2", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("SQL Server 2008", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("SQL Server 2005", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("SQL Server 2000", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("SQL Server 7.0", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("SQL Server  2016", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("SQL Server  6.5", System.Windows.Forms.HorizontalAlignment.Left);

            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "6.00.1025.45",
            "SQL Server 2005",
            "November 2008 CTP",
            "Yes",
            "Mainstream support until 12/25/2009"}, -1);
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_VersionList));
          this.buttonClose = new DevComponents.DotNetBar.ButtonX();
          this.tabControl1 = new DevComponents.DotNetBar.TabControl();
          this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
          this.listViewSQL = new DevComponents.DotNetBar.Controls.ListViewEx();
          this.columnBuild = new System.Windows.Forms.ColumnHeader();
          this.columnProduct = new System.Windows.Forms.ColumnHeader();
          this.columnLevel = new System.Windows.Forms.ColumnHeader();
          this.columnSupported = new System.Windows.Forms.ColumnHeader();
          this.columnSupportStatus = new System.Windows.Forms.ColumnHeader();
          this.columncolumnTitle = new System.Windows.Forms.ColumnHeader();
          this.columnUrl = new System.Windows.Forms.ColumnHeader();
          this.contextViewKnowledgeBaseArticle = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.viewMicrosoftKnowledgeBaseArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.tabSQL = new DevComponents.DotNetBar.TabItem(this.components);
          this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
          this.tabWindows = new DevComponents.DotNetBar.TabItem(this.components);
          this.labelVersionListDate = new DevComponents.DotNetBar.LabelX();
          this.labelPatchVersionValue = new DevComponents.DotNetBar.LabelX();
          this.buttonViewKbArticle = new DevComponents.DotNetBar.ButtonX();
          ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
          this.tabControl1.SuspendLayout();
          this.tabControlPanel1.SuspendLayout();
          this.contextViewKnowledgeBaseArticle.SuspendLayout();
          this.SuspendLayout();
          // 
          // buttonClose
          // 
          this.buttonClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
          this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
          this.buttonClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
          this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
          this.buttonClose.Location = new System.Drawing.Point(779, 516);
          this.buttonClose.Name = "buttonClose";
          this.buttonClose.Size = new System.Drawing.Size(70, 25);
          this.buttonClose.TabIndex = 6;
          this.buttonClose.Text = "Close";
          // 
          // tabControl1
          // 
          this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.tabControl1.BackColor = System.Drawing.Color.Transparent;
          this.tabControl1.CanReorderTabs = true;
          this.tabControl1.Controls.Add(this.tabControlPanel1);
          this.tabControl1.Controls.Add(this.tabControlPanel2);
          this.tabControl1.Location = new System.Drawing.Point(0, 0);
          this.tabControl1.Name = "tabControl1";
          this.tabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
          this.tabControl1.SelectedTabIndex = 0;
          this.tabControl1.Size = new System.Drawing.Size(862, 507);
          this.tabControl1.TabIndex = 0;
          this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
          this.tabControl1.Tabs.Add(this.tabSQL);
          this.tabControl1.Tabs.Add(this.tabWindows);
          this.tabControl1.TabsVisible = false;
          this.tabControl1.Text = "tabControl1";
          // 
          // tabControlPanel1
          // 
          this.tabControlPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.tabControlPanel1.Controls.Add(this.listViewSQL);
          this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
          this.tabControlPanel1.Name = "tabControlPanel1";
          this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
          this.tabControlPanel1.Size = new System.Drawing.Size(862, 481);
          this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
          this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
          this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
          this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
          this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                      | DevComponents.DotNetBar.eBorderSide.Bottom)));
          this.tabControlPanel1.Style.GradientAngle = 90;
          this.tabControlPanel1.TabIndex = 1;
          this.tabControlPanel1.TabItem = this.tabSQL;
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
            this.columnProduct,
            this.columnLevel,
            this.columnSupported,
            this.columnSupportStatus,
            this.columncolumnTitle,
            this.columnUrl});
          this.listViewSQL.ContextMenuStrip = this.contextViewKnowledgeBaseArticle;
            listViewGroup1.Header = "Unknown";
            listViewGroup1.Name = "groupUnknown";
            listViewGroup2.Header = "SQL Server 2016";
            listViewGroup2.Name = "group2016";
            listViewGroup3.Header = "SQL Server 2014";
            listViewGroup3.Name = "group2014";
            listViewGroup4.Header = "SQL Server 2012";
            listViewGroup4.Name = "group2012";
            listViewGroup5.Header = "SQL Server 2008 R2";
            listViewGroup5.Name = "group2008R2";
            listViewGroup6.Header = "SQL Server 2008";
            listViewGroup6.Name = "group2008";
            listViewGroup7.Header = "SQL Server 2005";
            listViewGroup7.Name = "group2005";
            listViewGroup8.Header = "SQL Server 2000";
            listViewGroup8.Name = "group2000";
            listViewGroup9.Header = "SQL Server 7.0";
            listViewGroup9.Name = "group70";
            listViewGroup10.Header = "SQL Server  6.5";
            listViewGroup10.Name = "group65";

            this.listViewSQL.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            //listViewGroup2,
            //listViewGroup3,
            //listViewGroup4,
            //listViewGroup5,
            //listViewGroup6,
            //listViewGroup7,
            //listViewGroup8,
            //listViewGroup9
            });
            listViewItem1.Group = listViewGroup8;
          this.listViewSQL.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
          this.listViewSQL.Location = new System.Drawing.Point(11, 10);
          this.listViewSQL.MultiSelect = false;
          this.listViewSQL.Name = "listViewSQL";
          this.listViewSQL.ShowItemToolTips = true;
          this.listViewSQL.Size = new System.Drawing.Size(840, 460);
          this.listViewSQL.Sorting = System.Windows.Forms.SortOrder.Descending;
          this.listViewSQL.TabIndex = 1;
          this.listViewSQL.UseCompatibleStateImageBehavior = false;
          this.listViewSQL.View = System.Windows.Forms.View.Details;
          this.listViewSQL.SelectedIndexChanged += new System.EventHandler(this.listViewSQL_SelectedIndexChanged);
          this.listViewSQL.DoubleClick += new System.EventHandler(this.listViewSQL_DoubleClick);
          this.listViewSQL.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listSQL_ColumnClick);
          // 
          // columnBuild
          // 
          this.columnBuild.Text = "Build";
          this.columnBuild.Width = 80;
          // 
          // columnProduct
          // 
          this.columnProduct.Text = "Product";
          this.columnProduct.Width = 116;
          // 
          // columnLevel
          // 
          this.columnLevel.Text = "Level";
          this.columnLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
          this.columnLevel.Width = 114;
          // 
          // columnSupported
          // 
          this.columnSupported.Text = "Supported";
          this.columnSupported.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
          this.columnSupported.Width = 80;
          // 
          // columnSupportStatus
          // 
          this.columnSupportStatus.Text = "Support Status";
          this.columnSupportStatus.Width = 192;
          // 
          // columncolumnTitle
          // 
          this.columncolumnTitle.Text = "Description";
          this.columncolumnTitle.Width = 289;
          // 
          // columnUrl
          // 
          this.columnUrl.Text = "KB Address";
          // 
          // contextViewKnowledgeBaseArticle
          // 
          this.contextViewKnowledgeBaseArticle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewMicrosoftKnowledgeBaseArticleToolStripMenuItem});
          this.contextViewKnowledgeBaseArticle.Name = "contextViewKnowledgeBaseArticle";
          this.contextViewKnowledgeBaseArticle.Size = new System.Drawing.Size(283, 26);
          // 
          // viewMicrosoftKnowledgeBaseArticleToolStripMenuItem
          // 
          this.viewMicrosoftKnowledgeBaseArticleToolStripMenuItem.Name = "viewMicrosoftKnowledgeBaseArticleToolStripMenuItem";
          this.viewMicrosoftKnowledgeBaseArticleToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
          this.viewMicrosoftKnowledgeBaseArticleToolStripMenuItem.Text = "&View Microsoft Knowledge Base Article ";
          this.viewMicrosoftKnowledgeBaseArticleToolStripMenuItem.Click += new System.EventHandler(this.contextViewKnowledgeBaseArticle_Click);
          // 
          // tabSQL
          // 
          this.tabSQL.AttachedControl = this.tabControlPanel1;
          this.tabSQL.Name = "tabSQL";
          this.tabSQL.Text = "SQL Server Versions";
          // 
          // tabControlPanel2
          // 
          this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
          this.tabControlPanel2.Name = "tabControlPanel2";
          this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
          this.tabControlPanel2.Size = new System.Drawing.Size(862, 481);
          this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
          this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
          this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
          this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
          this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                      | DevComponents.DotNetBar.eBorderSide.Bottom)));
          this.tabControlPanel2.Style.GradientAngle = 90;
          this.tabControlPanel2.TabIndex = 2;
          this.tabControlPanel2.TabItem = this.tabWindows;
          // 
          // tabWindows
          // 
          this.tabWindows.AttachedControl = this.tabControlPanel2;
          this.tabWindows.Name = "tabWindows";
          this.tabWindows.Text = "Windows Versions";
          this.tabWindows.Visible = false;
          // 
          // labelVersionListDate
          // 
          this.labelVersionListDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
          this.labelVersionListDate.AutoSize = true;
          // 
          // 
          // 
          this.labelVersionListDate.BackgroundStyle.Class = "";
          this.labelVersionListDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
          this.labelVersionListDate.Location = new System.Drawing.Point(10, 522);
          this.labelVersionListDate.Name = "labelVersionListDate";
          this.labelVersionListDate.Size = new System.Drawing.Size(89, 15);
          this.labelVersionListDate.TabIndex = 2;
          this.labelVersionListDate.Text = "Date of Build List:";
          // 
          // labelPatchVersionValue
          // 
          this.labelPatchVersionValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
          this.labelPatchVersionValue.AutoSize = true;
          this.labelPatchVersionValue.BackColor = System.Drawing.Color.Transparent;
          // 
          // 
          // 
          this.labelPatchVersionValue.BackgroundStyle.Class = "";
          this.labelPatchVersionValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
          this.labelPatchVersionValue.Location = new System.Drawing.Point(100, 522);
          this.labelPatchVersionValue.Name = "labelPatchVersionValue";
          this.labelPatchVersionValue.Size = new System.Drawing.Size(58, 15);
          this.labelPatchVersionValue.TabIndex = 3;
          this.labelPatchVersionValue.Text = "12/25/2008";
          this.labelPatchVersionValue.WordWrap = true;
          // 
          // buttonViewKbArticle
          // 
          this.buttonViewKbArticle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
          this.buttonViewKbArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
          this.buttonViewKbArticle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
          this.buttonViewKbArticle.Enabled = false;
          this.buttonViewKbArticle.Image = ((System.Drawing.Image)(resources.GetObject("buttonViewKbArticle.Image")));
          this.buttonViewKbArticle.Location = new System.Drawing.Point(531, 516);
          this.buttonViewKbArticle.Name = "buttonViewKbArticle";
          this.buttonViewKbArticle.Size = new System.Drawing.Size(238, 25);
          this.buttonViewKbArticle.TabIndex = 5;
          this.buttonViewKbArticle.Text = "View Microsoft Knowledge Base Articles";
          this.buttonViewKbArticle.Click += new System.EventHandler(this.buttonViewKbArticle_Click);
          // 
          // Form_VersionList
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.White;
          this.ClientSize = new System.Drawing.Size(861, 549);
          this.Controls.Add(this.buttonViewKbArticle);
          this.Controls.Add(this.labelPatchVersionValue);
          this.Controls.Add(this.labelVersionListDate);
          this.Controls.Add(this.tabControl1);
          this.Controls.Add(this.buttonClose);
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.MinimumSize = new System.Drawing.Size(648, 268);
          this.Name = "Form_VersionList";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Build List";
          ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
          this.tabControl1.ResumeLayout(false);
          this.tabControlPanel1.ResumeLayout(false);
          this.contextViewKnowledgeBaseArticle.ResumeLayout(false);
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX buttonClose;
      private DevComponents.DotNetBar.TabControl tabControl1;
      private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
      private DevComponents.DotNetBar.TabItem tabSQL;
      private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
      private DevComponents.DotNetBar.TabItem tabWindows;
      private DevComponents.DotNetBar.Controls.ListViewEx listViewSQL;
      private System.Windows.Forms.ColumnHeader columnBuild;
      private System.Windows.Forms.ColumnHeader columnProduct;
      private System.Windows.Forms.ColumnHeader columnLevel;
      private System.Windows.Forms.ColumnHeader columnSupported;
      private System.Windows.Forms.ColumnHeader columnSupportStatus;
      private DevComponents.DotNetBar.LabelX labelVersionListDate;
      private DevComponents.DotNetBar.LabelX labelPatchVersionValue;
      private System.Windows.Forms.ContextMenuStrip contextViewKnowledgeBaseArticle;
      private System.Windows.Forms.ToolStripMenuItem viewMicrosoftKnowledgeBaseArticleToolStripMenuItem;
      private DevComponents.DotNetBar.ButtonX buttonViewKbArticle;
      private System.Windows.Forms.ColumnHeader columncolumnTitle;
      private System.Windows.Forms.ColumnHeader columnUrl;
   }
}