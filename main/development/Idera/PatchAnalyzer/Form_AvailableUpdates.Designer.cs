namespace Idera.SqlAdminToolset.PatchAnalyzer
{
   partial class Form_AvailableUpdates
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
         System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup( "RTM", System.Windows.Forms.HorizontalAlignment.Left );
         System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup( "Service Pack 1", System.Windows.Forms.HorizontalAlignment.Left );
         System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup( "Service Pack 2", System.Windows.Forms.HorizontalAlignment.Left );
         System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup( "Service Pack 3", System.Windows.Forms.HorizontalAlignment.Left );
         System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup( "Service Pack 4", System.Windows.Forms.HorizontalAlignment.Left );
         System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup( "Service Pack 5", System.Windows.Forms.HorizontalAlignment.Left );
         System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup( "Service Pack 6", System.Windows.Forms.HorizontalAlignment.Left );
         System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup( "Service Pack 7", System.Windows.Forms.HorizontalAlignment.Left );
         System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup( "Service Pack 8", System.Windows.Forms.HorizontalAlignment.Left );
         System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup( "Service Pack 9", System.Windows.Forms.HorizontalAlignment.Left );
         System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem( new string[] {
            "6.00.1025.45",
            "FIX: Helped decide that cursors have something to do with datbases and not mice",
            "Will be retired on 4/8/2008"}, -1 );
         System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem( "6.00.1050" );
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_AvailableUpdates ) );
         this.buttonClose = new DevComponents.DotNetBar.ButtonX();
         this.listViewSQL = new DevComponents.DotNetBar.Controls.ListViewEx();
         this.columnBuild = new System.Windows.Forms.ColumnHeader();
         this.columncolumnTitle = new System.Windows.Forms.ColumnHeader();
         this.columnSupportStatus = new System.Windows.Forms.ColumnHeader();
         this.columnUrl = new System.Windows.Forms.ColumnHeader();
         this.contextViewKnowledgeBaseArticle = new System.Windows.Forms.ContextMenuStrip( this.components );
         this.viewMicrosoftKnowledgeBaseArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.buttonViewKbArticle = new DevComponents.DotNetBar.ButtonX();
         this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.labelX1 = new DevComponents.DotNetBar.LabelX();
         this.labelX2 = new DevComponents.DotNetBar.LabelX();
         this.textServer = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.textBuild = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.contextViewKnowledgeBaseArticle.SuspendLayout();
         this.groupPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonClose
         // 
         this.buttonClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonClose.Location = new System.Drawing.Point( 787, 493 );
         this.buttonClose.Name = "buttonClose";
         this.buttonClose.Size = new System.Drawing.Size( 70, 25 );
         this.buttonClose.TabIndex = 7;
         this.buttonClose.Text = "Close";
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
         this.listViewSQL.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnBuild,
            this.columncolumnTitle,
            this.columnSupportStatus,
            this.columnUrl} );
         this.listViewSQL.ContextMenuStrip = this.contextViewKnowledgeBaseArticle;
         listViewGroup1.Header = "RTM";
         listViewGroup1.Name = "groupRTM";
         listViewGroup2.Header = "Service Pack 1";
         listViewGroup2.Name = "groupSP1";
         listViewGroup3.Header = "Service Pack 2";
         listViewGroup3.Name = "groupSP2";
         listViewGroup4.Header = "Service Pack 3";
         listViewGroup4.Name = "groupSP3";
         listViewGroup5.Header = "Service Pack 4";
         listViewGroup5.Name = "groupSP4";
         listViewGroup6.Header = "Service Pack 5";
         listViewGroup6.Name = "groupSP5";
         listViewGroup7.Header = "Service Pack 6";
         listViewGroup7.Name = "groupSP6";
         listViewGroup8.Header = "Service Pack 7";
         listViewGroup8.Name = "groupSP7";
         listViewGroup9.Header = "Service Pack 8";
         listViewGroup9.Name = "groupSP8";
         listViewGroup10.Header = "Service Pack 9";
         listViewGroup10.Name = "groupsSP9";
         this.listViewSQL.Groups.AddRange( new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7,
            listViewGroup8,
            listViewGroup9,
            listViewGroup10} );
         listViewItem1.Group = listViewGroup2;
         listViewItem2.Group = listViewGroup3;
         this.listViewSQL.Items.AddRange( new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2} );
         this.listViewSQL.Location = new System.Drawing.Point( 3, 8 );
         this.listViewSQL.MultiSelect = false;
         this.listViewSQL.Name = "listViewSQL";
         this.listViewSQL.ShowItemToolTips = true;
         this.listViewSQL.Size = new System.Drawing.Size( 833, 386 );
         this.listViewSQL.Sorting = System.Windows.Forms.SortOrder.Ascending;
         this.listViewSQL.TabIndex = 5;
         this.listViewSQL.UseCompatibleStateImageBehavior = false;
         this.listViewSQL.View = System.Windows.Forms.View.Details;
         this.listViewSQL.SelectedIndexChanged += new System.EventHandler( this.listViewSQL_SelectedIndexChanged );
         this.listViewSQL.DoubleClick += new System.EventHandler( this.listViewSQL_DoubleClick );
         this.listViewSQL.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler( this.listSQL_ColumnClick );
         // 
         // columnBuild
         // 
         this.columnBuild.Text = "Build";
         this.columnBuild.Width = 80;
         // 
         // columncolumnTitle
         // 
         this.columncolumnTitle.Text = "Description";
         this.columncolumnTitle.Width = 595;
         // 
         // columnSupportStatus
         // 
         this.columnSupportStatus.Text = "Support Status";
         this.columnSupportStatus.Width = 145;
         // 
         // columnUrl
         // 
         this.columnUrl.Text = "KB Address";
         // 
         // contextViewKnowledgeBaseArticle
         // 
         this.contextViewKnowledgeBaseArticle.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.viewMicrosoftKnowledgeBaseArticleToolStripMenuItem} );
         this.contextViewKnowledgeBaseArticle.Name = "contextViewKnowledgeBaseArticle";
         this.contextViewKnowledgeBaseArticle.Size = new System.Drawing.Size( 272, 26 );
         // 
         // viewMicrosoftKnowledgeBaseArticleToolStripMenuItem
         // 
         this.viewMicrosoftKnowledgeBaseArticleToolStripMenuItem.Name = "viewMicrosoftKnowledgeBaseArticleToolStripMenuItem";
         this.viewMicrosoftKnowledgeBaseArticleToolStripMenuItem.Size = new System.Drawing.Size( 271, 22 );
         this.viewMicrosoftKnowledgeBaseArticleToolStripMenuItem.Text = "&View Microsoft Knowledge Base Article ";
         this.viewMicrosoftKnowledgeBaseArticleToolStripMenuItem.Click += new System.EventHandler( this.contextViewKnowledgeBaseArticle_Click );
         // 
         // buttonViewKbArticle
         // 
         this.buttonViewKbArticle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonViewKbArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonViewKbArticle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonViewKbArticle.Enabled = false;
         this.buttonViewKbArticle.Image = ((System.Drawing.Image)(resources.GetObject( "buttonViewKbArticle.Image" )));
         this.buttonViewKbArticle.Location = new System.Drawing.Point( 539, 493 );
         this.buttonViewKbArticle.Name = "buttonViewKbArticle";
         this.buttonViewKbArticle.Size = new System.Drawing.Size( 238, 25 );
         this.buttonViewKbArticle.TabIndex = 6;
         this.buttonViewKbArticle.Text = "View Microsoft Knowledge Base Articles";
         this.buttonViewKbArticle.Click += new System.EventHandler( this.buttonViewKbArticle_Click );
         // 
         // groupPanel1
         // 
         this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel1.Controls.Add( this.listViewSQL );
         this.groupPanel1.Location = new System.Drawing.Point( 12, 64 );
         this.groupPanel1.Name = "groupPanel1";
         this.groupPanel1.Size = new System.Drawing.Size( 845, 421 );
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
         this.groupPanel1.Style.CornerDiameter = 4;
         this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
         this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
         this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
         this.groupPanel1.TabIndex = 4;
         this.groupPanel1.Text = "Available Updates";
         // 
         // labelX1
         // 
         this.labelX1.Location = new System.Drawing.Point( 12, 12 );
         this.labelX1.Name = "labelX1";
         this.labelX1.Size = new System.Drawing.Size( 70, 15 );
         this.labelX1.TabIndex = 0;
         this.labelX1.Text = "SQL Server:";
         // 
         // labelX2
         // 
         this.labelX2.Location = new System.Drawing.Point( 12, 36 );
         this.labelX2.Name = "labelX2";
         this.labelX2.Size = new System.Drawing.Size( 53, 15 );
         this.labelX2.TabIndex = 2;
         this.labelX2.Text = "Build:";
         // 
         // textServer
         // 
         // 
         // 
         // 
         this.textServer.Border.Class = "TextBoxBorder";
         this.textServer.Location = new System.Drawing.Point( 81, 10 );
         this.textServer.Name = "textServer";
         this.textServer.ReadOnly = true;
         this.textServer.Size = new System.Drawing.Size( 360, 20 );
         this.textServer.TabIndex = 1;
         // 
         // textBuild
         // 
         // 
         // 
         // 
         this.textBuild.Border.Class = "TextBoxBorder";
         this.textBuild.Location = new System.Drawing.Point( 81, 34 );
         this.textBuild.Name = "textBuild";
         this.textBuild.ReadOnly = true;
         this.textBuild.Size = new System.Drawing.Size( 360, 20 );
         this.textBuild.TabIndex = 3;
         // 
         // Form_AvailableUpdates
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.ClientSize = new System.Drawing.Size( 869, 524 );
         this.Controls.Add( this.textBuild );
         this.Controls.Add( this.textServer );
         this.Controls.Add( this.labelX2 );
         this.Controls.Add( this.labelX1 );
         this.Controls.Add( this.groupPanel1 );
         this.Controls.Add( this.buttonViewKbArticle );
         this.Controls.Add( this.buttonClose );
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MinimumSize = new System.Drawing.Size( 648, 268 );
         this.Name = "Form_AvailableUpdates";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Available Updates";
         this.contextViewKnowledgeBaseArticle.ResumeLayout( false );
         this.groupPanel1.ResumeLayout( false );
         this.ResumeLayout( false );

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX buttonClose;
      private DevComponents.DotNetBar.Controls.ListViewEx listViewSQL;
      private System.Windows.Forms.ColumnHeader columnBuild;
      private System.Windows.Forms.ColumnHeader columnSupportStatus;
      private System.Windows.Forms.ContextMenuStrip contextViewKnowledgeBaseArticle;
      private System.Windows.Forms.ToolStripMenuItem viewMicrosoftKnowledgeBaseArticleToolStripMenuItem;
      private DevComponents.DotNetBar.ButtonX buttonViewKbArticle;
      private System.Windows.Forms.ColumnHeader columncolumnTitle;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.LabelX labelX1;
      private DevComponents.DotNetBar.LabelX labelX2;
      private DevComponents.DotNetBar.Controls.TextBoxX textServer;
      private DevComponents.DotNetBar.Controls.TextBoxX textBuild;
      private System.Windows.Forms.ColumnHeader columnUrl;
   }
}