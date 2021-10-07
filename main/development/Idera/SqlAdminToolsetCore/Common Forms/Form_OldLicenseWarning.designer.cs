namespace Idera.SqlAdminToolset.Core
{
    partial class Form_OldLicenseWarning
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_OldLicenseWarning));
          this.btnOK = new DevComponents.DotNetBar.ButtonX();
          this.labelConnectionTimeout = new DevComponents.DotNetBar.LabelX();
          this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
          this.labelX1 = new DevComponents.DotNetBar.LabelX();
          this.linkGetLicense = new System.Windows.Forms.LinkLabel();
          this.groupPanel1.SuspendLayout();
          this.SuspendLayout();
          // 
          // btnOK
          // 
          this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
          this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
          this.btnOK.Location = new System.Drawing.Point(141, 94);
          this.btnOK.Name = "btnOK";
          this.btnOK.Size = new System.Drawing.Size(75, 23);
          this.btnOK.TabIndex = 4;
          this.btnOK.Text = "&OK";
          this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
          // 
          // labelConnectionTimeout
          // 
          this.labelConnectionTimeout.AutoSize = true;
          this.labelConnectionTimeout.BackColor = System.Drawing.Color.Transparent;
          this.labelConnectionTimeout.Location = new System.Drawing.Point(3, 6);
          this.labelConnectionTimeout.Name = "labelConnectionTimeout";
          this.labelConnectionTimeout.Size = new System.Drawing.Size(315, 27);
          this.labelConnectionTimeout.TabIndex = 2;
          this.labelConnectionTimeout.Text = "To upgrade to the latest version of the SQL admin toolset, a new \r\nlicense key is" +
              " required.";
          this.labelConnectionTimeout.WordWrap = true;
          // 
          // groupPanel1
          // 
          this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
          this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
          this.groupPanel1.Controls.Add(this.labelX1);
          this.groupPanel1.Controls.Add(this.labelConnectionTimeout);
          this.groupPanel1.IsShadowEnabled = true;
          this.groupPanel1.Location = new System.Drawing.Point(6, 5);
          this.groupPanel1.Name = "groupPanel1";
          this.groupPanel1.Size = new System.Drawing.Size(342, 83);
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
          this.groupPanel1.TabIndex = 0;
          // 
          // labelX1
          // 
          this.labelX1.AutoSize = true;
          this.labelX1.BackColor = System.Drawing.Color.Transparent;
          this.labelX1.Location = new System.Drawing.Point(3, 43);
          this.labelX1.Name = "labelX1";
          this.labelX1.Size = new System.Drawing.Size(316, 27);
          this.labelX1.TabIndex = 3;
          this.labelX1.Text = "Click \'Get a new license\' to automatically generate a new key via \r\nthe Idera Web" +
              " site (requires Internet access).";
          this.labelX1.WordWrap = true;
          // 
          // linkGetLicense
          // 
          this.linkGetLicense.Image = ((System.Drawing.Image)(resources.GetObject("linkGetLicense.Image")));
          this.linkGetLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
          this.linkGetLicense.Location = new System.Drawing.Point(6, 96);
          this.linkGetLicense.Name = "linkGetLicense";
          this.linkGetLicense.Size = new System.Drawing.Size(113, 23);
          this.linkGetLicense.TabIndex = 5;
          this.linkGetLicense.TabStop = true;
          this.linkGetLicense.Text = "Get a new license.";
          this.linkGetLicense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          this.linkGetLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGetLicense_Click);
          // 
          // Form_OldLicenseWarning
          // 
          this.AcceptButton = this.btnOK;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.White;
          this.ClientSize = new System.Drawing.Size(357, 126);
          this.Controls.Add(this.linkGetLicense);
          this.Controls.Add(this.btnOK);
          this.Controls.Add(this.groupPanel1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "Form_OldLicenseWarning";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Welcome to the Idera SQL admin toolset";
          this.groupPanel1.ResumeLayout(false);
          this.groupPanel1.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

       private DevComponents.DotNetBar.ButtonX btnOK;
       private DevComponents.DotNetBar.LabelX labelConnectionTimeout;
       private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
       private System.Windows.Forms.LinkLabel linkGetLicense;
       private DevComponents.DotNetBar.LabelX labelX1;
   }
}