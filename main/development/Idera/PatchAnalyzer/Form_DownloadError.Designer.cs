namespace Idera.SqlAdminToolset.PatchAnalyzer
{
   partial class Form_DownloadError
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_DownloadError ) );
         this.labelMessage = new DevComponents.DotNetBar.LabelX();
         this.buttonOK = new DevComponents.DotNetBar.ButtonX();
         this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.labelX2 = new DevComponents.DotNetBar.LabelX();
         this.labelX3 = new DevComponents.DotNetBar.LabelX();
         this.linkManualDownload = new System.Windows.Forms.LinkLabel();
         this.labelErrorMessage = new DevComponents.DotNetBar.LabelX();
         this.groupPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.groupPanel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // labelMessage
         // 
         this.labelMessage.BackColor = System.Drawing.Color.Transparent;
         this.labelMessage.ForeColor = System.Drawing.SystemColors.ControlText;
         this.labelMessage.Location = new System.Drawing.Point( 45, 10 );
         this.labelMessage.Name = "labelMessage";
         this.labelMessage.Size = new System.Drawing.Size( 471, 34 );
         this.labelMessage.TabIndex = 0;
         this.labelMessage.Text = "Patch Analyzer was unable to connect to the Idera website to check for the latest" +
             " build list file. Your network settings may be preventing Patch Analyzer from do" +
             "wnloading the latest build list. ";
         this.labelMessage.TextLineAlignment = System.Drawing.StringAlignment.Near;
         this.labelMessage.WordWrap = true;
         // 
         // buttonOK
         // 
         this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonOK.BackColor = System.Drawing.Color.Transparent;
         this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point( 465, 205 );
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size( 71, 20 );
         this.buttonOK.TabIndex = 4;
         this.buttonOK.Text = "OK";
         // 
         // groupPanel1
         // 
         this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel1.Controls.Add( this.pictureBox1 );
         this.groupPanel1.Controls.Add( this.groupPanel2 );
         this.groupPanel1.Controls.Add( this.labelErrorMessage );
         this.groupPanel1.Controls.Add( this.buttonOK );
         this.groupPanel1.Controls.Add( this.labelMessage );
         this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupPanel1.Location = new System.Drawing.Point( 0, 0 );
         this.groupPanel1.Name = "groupPanel1";
         this.groupPanel1.Size = new System.Drawing.Size( 547, 234 );
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
         this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
         this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
         this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
         this.groupPanel1.TabIndex = 5;
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject( "pictureBox1.Image" )));
         this.pictureBox1.Location = new System.Drawing.Point( 10, 11 );
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size( 24, 24 );
         this.pictureBox1.TabIndex = 10;
         this.pictureBox1.TabStop = false;
         // 
         // groupPanel2
         // 
         this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
         this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel2.Controls.Add( this.labelX2 );
         this.groupPanel2.Controls.Add( this.labelX3 );
         this.groupPanel2.Controls.Add( this.linkManualDownload );
         this.groupPanel2.IsShadowEnabled = true;
         this.groupPanel2.Location = new System.Drawing.Point( 10, 134 );
         this.groupPanel2.Name = "groupPanel2";
         this.groupPanel2.Size = new System.Drawing.Size( 526, 62 );
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
         this.groupPanel2.Style.CornerDiameter = 4;
         this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
         this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
         this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
         this.groupPanel2.TabIndex = 9;
         this.groupPanel2.Text = "Manual Update Instructions";
         // 
         // labelX2
         // 
         this.labelX2.AutoSize = true;
         this.labelX2.BackColor = System.Drawing.Color.Transparent;
         this.labelX2.ForeColor = System.Drawing.SystemColors.ControlText;
         this.labelX2.Location = new System.Drawing.Point( 63, 7 );
         this.labelX2.Name = "labelX2";
         this.labelX2.Size = new System.Drawing.Size( 437, 15 );
         this.labelX2.TabIndex = 7;
         this.labelX2.Text = "to see instructions for manual updating the build list. Alternatively, you can po" +
             "int your web";
         this.labelX2.TextLineAlignment = System.Drawing.StringAlignment.Near;
         // 
         // labelX3
         // 
         this.labelX3.BackColor = System.Drawing.Color.Transparent;
         this.labelX3.ForeColor = System.Drawing.SystemColors.ControlText;
         this.labelX3.Location = new System.Drawing.Point( 11, 21 );
         this.labelX3.Name = "labelX3";
         this.labelX3.Size = new System.Drawing.Size( 492, 18 );
         this.labelX3.TabIndex = 8;
         this.labelX3.Text = "browser to http://www.idera.com/SQLvs.";
         this.labelX3.TextLineAlignment = System.Drawing.StringAlignment.Near;
         this.labelX3.WordWrap = true;
         // 
         // linkManualDownload
         // 
         this.linkManualDownload.AutoSize = true;
         this.linkManualDownload.BackColor = System.Drawing.Color.Transparent;
         this.linkManualDownload.Location = new System.Drawing.Point( 9, 7 );
         this.linkManualDownload.Name = "linkManualDownload";
         this.linkManualDownload.Size = new System.Drawing.Size( 54, 13 );
         this.linkManualDownload.TabIndex = 5;
         this.linkManualDownload.TabStop = true;
         this.linkManualDownload.Text = "Click here";
         this.linkManualDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.linkManualDownload_LinkClicked );
         // 
         // labelErrorMessage
         // 
         this.labelErrorMessage.BackColor = System.Drawing.Color.Transparent;
         this.labelErrorMessage.ForeColor = System.Drawing.SystemColors.ControlText;
         this.labelErrorMessage.Location = new System.Drawing.Point( 45, 47 );
         this.labelErrorMessage.Name = "labelErrorMessage";
         this.labelErrorMessage.Size = new System.Drawing.Size( 468, 78 );
         this.labelErrorMessage.TabIndex = 6;
         this.labelErrorMessage.Text = "Error message on why the connection failed goes here";
         this.labelErrorMessage.TextLineAlignment = System.Drawing.StringAlignment.Near;
         this.labelErrorMessage.WordWrap = true;
         // 
         // Form_DownloadError
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.buttonOK;
         this.ClientSize = new System.Drawing.Size( 547, 234 );
         this.Controls.Add( this.groupPanel1 );
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form_DownloadError";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Patch Analyzer";
         this.groupPanel1.ResumeLayout( false );
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.groupPanel2.ResumeLayout( false );
         this.groupPanel2.PerformLayout();
         this.ResumeLayout( false );

      }

      #endregion

      private DevComponents.DotNetBar.LabelX labelMessage;
      private DevComponents.DotNetBar.ButtonX buttonOK;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.LabelX labelErrorMessage;
      private System.Windows.Forms.LinkLabel linkManualDownload;
      private DevComponents.DotNetBar.LabelX labelX3;
      private DevComponents.DotNetBar.LabelX labelX2;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
      private System.Windows.Forms.PictureBox pictureBox1;
   }
}