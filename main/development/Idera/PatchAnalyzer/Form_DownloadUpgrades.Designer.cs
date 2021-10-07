using System;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.PatchAnalyzer
{
   partial class Form_DownloadUpgrades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DownloadUpgrades));
            this.buttonClose = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.link2005sp4 = new System.Windows.Forms.LinkLabel();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.link2014general = new System.Windows.Forms.LinkLabel();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.link2016general = new System.Windows.Forms.LinkLabel();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.link2017general = new System.Windows.Forms.LinkLabel();
            this.link2012general = new System.Windows.Forms.LinkLabel();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.link2008R2sp1 = new System.Windows.Forms.LinkLabel();
            this.link2008R2general = new System.Windows.Forms.LinkLabel();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.link2008sp3 = new System.Windows.Forms.LinkLabel();
            this.link2008sp2 = new System.Windows.Forms.LinkLabel();
            this.link2008sp1 = new System.Windows.Forms.LinkLabel();
            this.link2005sp3 = new System.Windows.Forms.LinkLabel();
            this.link2008general = new System.Windows.Forms.LinkLabel();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.link2005sp2 = new System.Windows.Forms.LinkLabel();
            this.link2005sp1 = new System.Windows.Forms.LinkLabel();
            this.link2005general = new System.Windows.Forms.LinkLabel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.link2000sp4 = new System.Windows.Forms.LinkLabel();
            this.link2000sp3a = new System.Windows.Forms.LinkLabel();
            this.link200General = new System.Windows.Forms.LinkLabel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.linkSupportPolicy = new System.Windows.Forms.LinkLabel();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClose.Location = new System.Drawing.Point(599, 489);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(65, 23);
            this.buttonClose.TabIndex = 16;
            this.buttonClose.Text = "&Close";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.link2005sp4);
            this.groupPanel1.Controls.Add(this.labelX9);
            this.groupPanel1.Controls.Add(this.link2014general);
            this.groupPanel1.Controls.Add(this.labelX10);
            this.groupPanel1.Controls.Add(this.link2016general);
            this.groupPanel1.Controls.Add(this.labelX11);
            this.groupPanel1.Controls.Add(this.link2017general);
            this.groupPanel1.Controls.Add(this.link2012general);
            this.groupPanel1.Controls.Add(this.labelX8);
            this.groupPanel1.Controls.Add(this.link2008R2sp1);
            this.groupPanel1.Controls.Add(this.link2008R2general);
            this.groupPanel1.Controls.Add(this.labelX7);
            this.groupPanel1.Controls.Add(this.link2008sp3);
            this.groupPanel1.Controls.Add(this.link2008sp2);
            this.groupPanel1.Controls.Add(this.link2008sp1);
            this.groupPanel1.Controls.Add(this.link2005sp3);
            this.groupPanel1.Controls.Add(this.link2008general);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.link2005sp2);
            this.groupPanel1.Controls.Add(this.link2005sp1);
            this.groupPanel1.Controls.Add(this.link2005general);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.link2000sp4);
            this.groupPanel1.Controls.Add(this.link2000sp3a);
            this.groupPanel1.Controls.Add(this.link200General);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Location = new System.Drawing.Point(10, 9);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(654, 410);
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
            this.groupPanel1.Text = "SQL Server Download Information";
            // 
            // link2005sp4
            // 
            this.link2005sp4.AutoSize = true;
            this.link2005sp4.BackColor = System.Drawing.Color.Transparent;
            this.link2005sp4.Location = new System.Drawing.Point(9, 263);
            this.link2005sp4.Name = "link2005sp4";
            this.link2005sp4.Size = new System.Drawing.Size(165, 13);
            this.link2005sp4.TabIndex = 24;
            this.link2005sp4.TabStop = true;
            this.link2005sp4.Text = "SQL Server 2005 Service Pack 4";
            this.link2005sp4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2005sp4_LinkClicked);
            // 
            // labelX9
            // 
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX9.Location = new System.Drawing.Point(329, 240);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(207, 17);
            this.labelX9.TabIndex = 24;
            this.labelX9.Text = "SQL Server 2014";
            // 
            // link2014general
            // 
            this.link2014general.AutoSize = true;
            this.link2014general.BackColor = System.Drawing.Color.Transparent;
            this.link2014general.Location = new System.Drawing.Point(329, 263);
            this.link2014general.Name = "link2014general";
            this.link2014general.Size = new System.Drawing.Size(300, 13);
            this.link2014general.TabIndex = 25;
            this.link2014general.TabStop = true;
            this.link2014general.Text = "How to download the latest service pack for SQL Server 2014";
            this.link2014general.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2014general_LinkClicked);
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.Class = "";
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX10.Location = new System.Drawing.Point(329, 290);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(207, 17);
            this.labelX10.TabIndex = 24;
            this.labelX10.Text = "SQL Server 2016";
            // 
            // link2016general
            // 
            this.link2016general.AutoSize = true;
            this.link2016general.BackColor = System.Drawing.Color.Transparent;
            this.link2016general.Location = new System.Drawing.Point(329, 313);
            this.link2016general.Name = "link2016general";
            this.link2016general.Size = new System.Drawing.Size(300, 13);
            this.link2016general.TabIndex = 25;
            this.link2016general.TabStop = true;
            this.link2016general.Text = "How to download the latest service pack for SQL Server 2016";
            this.link2016general.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2016general_LinkClicked);
            // 
            // labelX11
            // 
            this.labelX11.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.Class = "";
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX11.Location = new System.Drawing.Point(331, 340);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(207, 17);
            this.labelX11.TabIndex = 24;
            this.labelX11.Text = "SQL Server 2017";
            // 
            // link2017general
            // 
            this.link2017general.AutoSize = true;
            this.link2017general.BackColor = System.Drawing.Color.Transparent;
            this.link2017general.Location = new System.Drawing.Point(329, 363);
            this.link2017general.Name = "link2017general";
            this.link2017general.Size = new System.Drawing.Size(300, 13);
            this.link2017general.TabIndex = 25;
            this.link2017general.TabStop = true;
            this.link2017general.Text = "How to download the latest service pack for SQL Server 2017";
            this.link2017general.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2017general_LinkClicked);
            // 
            // link2012general
            // 
            this.link2012general.AutoSize = true;
            this.link2012general.BackColor = System.Drawing.Color.Transparent;
            this.link2012general.Location = new System.Drawing.Point(329, 214);
            this.link2012general.Name = "link2012general";
            this.link2012general.Size = new System.Drawing.Size(300, 13);
            this.link2012general.TabIndex = 23;
            this.link2012general.TabStop = true;
            this.link2012general.Text = "How to download the latest service pack for SQL Server 2012";
            this.link2012general.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2012general_LinkClicked);
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX8.Location = new System.Drawing.Point(329, 189);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(207, 17);
            this.labelX8.TabIndex = 22;
            this.labelX8.Text = "SQL Server 2012";
            // 
            // link2008R2sp1
            // 
            this.link2008R2sp1.AutoSize = true;
            this.link2008R2sp1.BackColor = System.Drawing.Color.Transparent;
            this.link2008R2sp1.Location = new System.Drawing.Point(329, 163);
            this.link2008R2sp1.Name = "link2008R2sp1";
            this.link2008R2sp1.Size = new System.Drawing.Size(182, 13);
            this.link2008R2sp1.TabIndex = 19;
            this.link2008R2sp1.TabStop = true;
            this.link2008R2sp1.Text = "SQL Server 2008 R2 Service Pack 1";
            this.link2008R2sp1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2008R2sp1_LinkClicked);
            // 
            // link2008R2general
            // 
            this.link2008R2general.AutoSize = true;
            this.link2008R2general.BackColor = System.Drawing.Color.Transparent;
            this.link2008R2general.Location = new System.Drawing.Point(329, 143);
            this.link2008R2general.Name = "link2008R2general";
            this.link2008R2general.Size = new System.Drawing.Size(317, 13);
            this.link2008R2general.TabIndex = 18;
            this.link2008R2general.TabStop = true;
            this.link2008R2general.Text = "How to download the latest service pack for SQL Server 2008 R2";
            this.link2008R2general.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2008R2general_LinkClicked);
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.Location = new System.Drawing.Point(329, 118);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(207, 17);
            this.labelX7.TabIndex = 17;
            this.labelX7.Text = "SQL Server 2008 R2";
            // 
            // link2008sp3
            // 
            this.link2008sp3.AutoSize = true;
            this.link2008sp3.BackColor = System.Drawing.Color.Transparent;
            this.link2008sp3.Location = new System.Drawing.Point(329, 92);
            this.link2008sp3.Name = "link2008sp3";
            this.link2008sp3.Size = new System.Drawing.Size(165, 13);
            this.link2008sp3.TabIndex = 16;
            this.link2008sp3.TabStop = true;
            this.link2008sp3.Text = "SQL Server 2008 Service Pack 3";
            this.link2008sp3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2008sp3_LinkClicked);
            // 
            // link2008sp2
            // 
            this.link2008sp2.AutoSize = true;
            this.link2008sp2.BackColor = System.Drawing.Color.Transparent;
            this.link2008sp2.Location = new System.Drawing.Point(329, 72);
            this.link2008sp2.Name = "link2008sp2";
            this.link2008sp2.Size = new System.Drawing.Size(165, 13);
            this.link2008sp2.TabIndex = 15;
            this.link2008sp2.TabStop = true;
            this.link2008sp2.Text = "SQL Server 2008 Service Pack 2";
            this.link2008sp2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2008sp2_LinkClicked);
            // 
            // link2008sp1
            // 
            this.link2008sp1.AutoSize = true;
            this.link2008sp1.BackColor = System.Drawing.Color.Transparent;
            this.link2008sp1.Location = new System.Drawing.Point(329, 52);
            this.link2008sp1.Name = "link2008sp1";
            this.link2008sp1.Size = new System.Drawing.Size(165, 13);
            this.link2008sp1.TabIndex = 14;
            this.link2008sp1.TabStop = true;
            this.link2008sp1.Text = "SQL Server 2008 Service Pack 1";
            this.link2008sp1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2008sp1_LinkClicked);
            // 
            // link2005sp3
            // 
            this.link2005sp3.AutoSize = true;
            this.link2005sp3.BackColor = System.Drawing.Color.Transparent;
            this.link2005sp3.Location = new System.Drawing.Point(9, 243);
            this.link2005sp3.Name = "link2005sp3";
            this.link2005sp3.Size = new System.Drawing.Size(165, 13);
            this.link2005sp3.TabIndex = 11;
            this.link2005sp3.TabStop = true;
            this.link2005sp3.Text = "SQL Server 2005 Service Pack 3";
            this.link2005sp3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2005sp3_LinkClicked);
            // 
            // link2008general
            // 
            this.link2008general.AutoSize = true;
            this.link2008general.BackColor = System.Drawing.Color.Transparent;
            this.link2008general.Location = new System.Drawing.Point(329, 32);
            this.link2008general.Name = "link2008general";
            this.link2008general.Size = new System.Drawing.Size(300, 13);
            this.link2008general.TabIndex = 13;
            this.link2008general.TabStop = true;
            this.link2008general.Text = "How to download the latest service pack for SQL Server 2008";
            this.link2008general.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2008general_LinkClicked);
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.Location = new System.Drawing.Point(329, 7);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(207, 17);
            this.labelX6.TabIndex = 12;
            this.labelX6.Text = "SQL Server 2008";
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
            this.labelX5.Location = new System.Drawing.Point(12, 92);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(266, 15);
            this.labelX5.TabIndex = 4;
            this.labelX5.Text = "SQL Server 2000 Service Pack 3 (no longer available)";
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
            this.labelX4.Location = new System.Drawing.Point(12, 72);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(266, 15);
            this.labelX4.TabIndex = 3;
            this.labelX4.Text = "SQL Server 2000 Service Pack 2 (no longer available)";
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
            this.labelX3.Location = new System.Drawing.Point(12, 52);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(266, 15);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "SQL Server 2000 Service Pack 1 (no longer available)";
            // 
            // link2005sp2
            // 
            this.link2005sp2.AutoSize = true;
            this.link2005sp2.BackColor = System.Drawing.Color.Transparent;
            this.link2005sp2.Location = new System.Drawing.Point(9, 223);
            this.link2005sp2.Name = "link2005sp2";
            this.link2005sp2.Size = new System.Drawing.Size(165, 13);
            this.link2005sp2.TabIndex = 10;
            this.link2005sp2.TabStop = true;
            this.link2005sp2.Text = "SQL Server 2005 Service Pack 2";
            this.link2005sp2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2005sp2_LinkClicked);
            // 
            // link2005sp1
            // 
            this.link2005sp1.AutoSize = true;
            this.link2005sp1.BackColor = System.Drawing.Color.Transparent;
            this.link2005sp1.Location = new System.Drawing.Point(9, 203);
            this.link2005sp1.Name = "link2005sp1";
            this.link2005sp1.Size = new System.Drawing.Size(165, 13);
            this.link2005sp1.TabIndex = 9;
            this.link2005sp1.TabStop = true;
            this.link2005sp1.Text = "SQL Server 2005 Service Pack 1";
            this.link2005sp1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2005sp1_LinkClicked);
            // 
            // link2005general
            // 
            this.link2005general.AutoSize = true;
            this.link2005general.BackColor = System.Drawing.Color.Transparent;
            this.link2005general.Location = new System.Drawing.Point(9, 183);
            this.link2005general.Name = "link2005general";
            this.link2005general.Size = new System.Drawing.Size(300, 13);
            this.link2005general.TabIndex = 8;
            this.link2005general.TabStop = true;
            this.link2005general.Text = "How to download the latest service pack for SQL Server 2005";
            this.link2005general.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2005general_LinkClicked);
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(9, 158);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(207, 17);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "SQL Server 2005";
            // 
            // link2000sp4
            // 
            this.link2000sp4.AutoSize = true;
            this.link2000sp4.BackColor = System.Drawing.Color.Transparent;
            this.link2000sp4.Location = new System.Drawing.Point(9, 132);
            this.link2000sp4.Name = "link2000sp4";
            this.link2000sp4.Size = new System.Drawing.Size(165, 13);
            this.link2000sp4.TabIndex = 6;
            this.link2000sp4.TabStop = true;
            this.link2000sp4.Text = "SQL Server 2000 Service Pack 4";
            this.link2000sp4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2000sp4_LinkClicked);
            // 
            // link2000sp3a
            // 
            this.link2000sp3a.AutoSize = true;
            this.link2000sp3a.BackColor = System.Drawing.Color.Transparent;
            this.link2000sp3a.Location = new System.Drawing.Point(9, 112);
            this.link2000sp3a.Name = "link2000sp3a";
            this.link2000sp3a.Size = new System.Drawing.Size(171, 13);
            this.link2000sp3a.TabIndex = 5;
            this.link2000sp3a.TabStop = true;
            this.link2000sp3a.Text = "SQL Server 2000 Service Pack 3a";
            this.link2000sp3a.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link2000sp3a_LinkClicked);
            // 
            // link200General
            // 
            this.link200General.AutoSize = true;
            this.link200General.BackColor = System.Drawing.Color.Transparent;
            this.link200General.Location = new System.Drawing.Point(9, 32);
            this.link200General.Name = "link200General";
            this.link200General.Size = new System.Drawing.Size(300, 13);
            this.link200General.TabIndex = 1;
            this.link200General.TabStop = true;
            this.link200General.Text = "How to download the latest service pack for SQL Server 2000";
            this.link200General.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link200General_LinkClicked);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(9, 7);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(207, 17);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "SQL Server 2000";
            // 
            // groupPanel2
            // 
            this.groupPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.linkSupportPolicy);
            this.groupPanel2.Location = new System.Drawing.Point(10, 429);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(654, 56);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
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
            this.groupPanel2.TabIndex = 2;
            this.groupPanel2.Text = "Microsoft Support Lifecycle Policy";
            // 
            // linkSupportPolicy
            // 
            this.linkSupportPolicy.AutoSize = true;
            this.linkSupportPolicy.BackColor = System.Drawing.Color.Transparent;
            this.linkSupportPolicy.Location = new System.Drawing.Point(7, 11);
            this.linkSupportPolicy.Name = "linkSupportPolicy";
            this.linkSupportPolicy.Size = new System.Drawing.Size(265, 13);
            this.linkSupportPolicy.TabIndex = 15;
            this.linkSupportPolicy.TabStop = true;
            this.linkSupportPolicy.Text = "Microsoft Support - Lifecycle Supported Service Packs";
            this.linkSupportPolicy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSupportPolicy_LinkClicked);
            // 
            // Form_DownloadUpgrades
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(672, 520);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_DownloadUpgrades";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SQL Server Download and Support Lifecycle Policy";
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.ResumeLayout(false);

      }

     

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonClose;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.LabelX labelX1;
      private DevComponents.DotNetBar.LabelX labelX5;
      private DevComponents.DotNetBar.LabelX labelX4;
      private DevComponents.DotNetBar.LabelX labelX3;
      private System.Windows.Forms.LinkLabel link2005sp2;
      private System.Windows.Forms.LinkLabel link2005sp1;
      private System.Windows.Forms.LinkLabel link2005general;
      private DevComponents.DotNetBar.LabelX labelX2;
      private System.Windows.Forms.LinkLabel link2000sp4;
      private System.Windows.Forms.LinkLabel link2000sp3a;
      private System.Windows.Forms.LinkLabel link200General;
      private System.Windows.Forms.LinkLabel link2008general;
      private DevComponents.DotNetBar.LabelX labelX6;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
      private System.Windows.Forms.LinkLabel linkSupportPolicy;
      private System.Windows.Forms.LinkLabel link2005sp3;
      private System.Windows.Forms.LinkLabel link2008sp1;
      private System.Windows.Forms.LinkLabel link2008sp2;
       private System.Windows.Forms.LinkLabel link2008sp3;
       private System.Windows.Forms.LinkLabel link2012general;
       private System.Windows.Forms.LinkLabel link2014general;
        private System.Windows.Forms.LinkLabel link2016general;
        private System.Windows.Forms.LinkLabel link2017general;
        private DevComponents.DotNetBar.LabelX labelX8;
       private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX11;
        private System.Windows.Forms.LinkLabel link2008R2sp1;
       private System.Windows.Forms.LinkLabel link2008R2general;
       private DevComponents.DotNetBar.LabelX labelX7;
       private System.Windows.Forms.LinkLabel link2005sp4;
   }
}