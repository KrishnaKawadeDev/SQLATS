namespace Idera.SqlAdminToolset.SqlDiscovery
{
   partial class Form_Options
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Options));
         this.btnCancel = new DevComponents.DotNetBar.ButtonX();
         this.btnOK = new DevComponents.DotNetBar.ButtonX();
         this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.labelX3 = new DevComponents.DotNetBar.LabelX();
         this.textLocalSourcePort = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
         this.textICMPTimeout = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
         this.labelX2 = new DevComponents.DotNetBar.LabelX();
         this.labelX1 = new DevComponents.DotNetBar.LabelX();
         this.checkEnableIcmpCheck = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.checkDisableSSNetLibVersionCheck = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.labelX7 = new DevComponents.DotNetBar.LabelX();
         this.textDomain = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.textPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.textUserName = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.labelX4 = new DevComponents.DotNetBar.LabelX();
         this.labelX5 = new DevComponents.DotNetBar.LabelX();
         this.labelX6 = new DevComponents.DotNetBar.LabelX();
         this.checkUseAlternateCredentials = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.groupPanel1.SuspendLayout();
         this.groupPanel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnCancel
         // 
         this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(401, 310);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 28;
         this.btnCancel.Text = "&Cancel";
         // 
         // btnOK
         // 
         this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnOK.Location = new System.Drawing.Point(320, 310);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 27;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // groupPanel1
         // 
         this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel1.Controls.Add(this.labelX3);
         this.groupPanel1.Controls.Add(this.textLocalSourcePort);
         this.groupPanel1.Controls.Add(this.textICMPTimeout);
         this.groupPanel1.Controls.Add(this.labelX2);
         this.groupPanel1.Controls.Add(this.labelX1);
         this.groupPanel1.Controls.Add(this.checkEnableIcmpCheck);
         this.groupPanel1.Controls.Add(this.checkDisableSSNetLibVersionCheck);
         this.groupPanel1.IsShadowEnabled = true;
         this.groupPanel1.Location = new System.Drawing.Point(8, 8);
         this.groupPanel1.Name = "groupPanel1";
         this.groupPanel1.Size = new System.Drawing.Size(470, 136);
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
         this.groupPanel1.TabIndex = 26;
         this.groupPanel1.Text = "General Options";
         // 
         // labelX3
         // 
         this.labelX3.AutoSize = true;
         this.labelX3.BackColor = System.Drawing.Color.Transparent;
         this.labelX3.Location = new System.Drawing.Point(206, 90);
         this.labelX3.Name = "labelX3";
         this.labelX3.Size = new System.Drawing.Size(66, 15);
         this.labelX3.TabIndex = 20;
         this.labelX3.Text = "(0 = random)";
         // 
         // textLocalSourcePort
         // 
         // 
         // 
         // 
         this.textLocalSourcePort.Border.Class = "TextBoxBorder";
         this.textLocalSourcePort.Location = new System.Drawing.Point(134, 88);
         this.textLocalSourcePort.MaxLength = 5;
         this.textLocalSourcePort.Name = "textLocalSourcePort";
         this.textLocalSourcePort.Size = new System.Drawing.Size(66, 20);
         this.textLocalSourcePort.TabIndex = 19;
         this.textLocalSourcePort.Text = "0";
         // 
         // textICMPTimeout
         // 
         // 
         // 
         // 
         this.textICMPTimeout.Border.Class = "TextBoxBorder";
         this.textICMPTimeout.Location = new System.Drawing.Point(134, 62);
         this.textICMPTimeout.MaxLength = 5;
         this.textICMPTimeout.Name = "textICMPTimeout";
         this.textICMPTimeout.Size = new System.Drawing.Size(66, 20);
         this.textICMPTimeout.TabIndex = 18;
         this.textICMPTimeout.Text = "750";
         // 
         // labelX2
         // 
         this.labelX2.AutoSize = true;
         this.labelX2.BackColor = System.Drawing.Color.Transparent;
         this.labelX2.Location = new System.Drawing.Point(12, 90);
         this.labelX2.Name = "labelX2";
         this.labelX2.Size = new System.Drawing.Size(119, 15);
         this.labelX2.TabIndex = 17;
         this.labelX2.Text = "UDP Local Source Port:";
         // 
         // labelX1
         // 
         this.labelX1.AutoSize = true;
         this.labelX1.BackColor = System.Drawing.Color.Transparent;
         this.labelX1.Location = new System.Drawing.Point(29, 63);
         this.labelX1.Name = "labelX1";
         this.labelX1.Size = new System.Drawing.Size(95, 15);
         this.labelX1.TabIndex = 16;
         this.labelX1.Text = "Ping Timeout (ms):";
         // 
         // checkEnableIcmpCheck
         // 
         this.checkEnableIcmpCheck.AutoSize = true;
         this.checkEnableIcmpCheck.BackColor = System.Drawing.Color.Transparent;
         this.checkEnableIcmpCheck.Location = new System.Drawing.Point(8, 37);
         this.checkEnableIcmpCheck.Name = "checkEnableIcmpCheck";
         this.checkEnableIcmpCheck.Size = new System.Drawing.Size(308, 15);
         this.checkEnableIcmpCheck.TabIndex = 14;
         this.checkEnableIcmpCheck.Text = "Ping each computer to see if it is available before scanning";
         // 
         // checkDisableSSNetLibVersionCheck
         // 
         this.checkDisableSSNetLibVersionCheck.AutoSize = true;
         this.checkDisableSSNetLibVersionCheck.BackColor = System.Drawing.Color.Transparent;
         this.checkDisableSSNetLibVersionCheck.Location = new System.Drawing.Point(8, 12);
         this.checkDisableSSNetLibVersionCheck.Name = "checkDisableSSNetLibVersionCheck";
         this.checkDisableSSNetLibVersionCheck.Size = new System.Drawing.Size(220, 15);
         this.checkDisableSSNetLibVersionCheck.TabIndex = 13;
         this.checkDisableSSNetLibVersionCheck.Text = "Disable SSNetLib Version Check Packet";
         // 
         // groupPanel2
         // 
         this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel2.Controls.Add(this.labelX7);
         this.groupPanel2.Controls.Add(this.textDomain);
         this.groupPanel2.Controls.Add(this.textPassword);
         this.groupPanel2.Controls.Add(this.textUserName);
         this.groupPanel2.Controls.Add(this.labelX4);
         this.groupPanel2.Controls.Add(this.labelX5);
         this.groupPanel2.Controls.Add(this.labelX6);
         this.groupPanel2.Controls.Add(this.checkUseAlternateCredentials);
         this.groupPanel2.IsShadowEnabled = true;
         this.groupPanel2.Location = new System.Drawing.Point(8, 150);
         this.groupPanel2.Name = "groupPanel2";
         this.groupPanel2.Size = new System.Drawing.Size(470, 154);
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
         this.groupPanel2.TabIndex = 29;
         this.groupPanel2.Text = "Alternate Credentials";
         // 
         // labelX7
         // 
         this.labelX7.AutoSize = true;
         this.labelX7.BackColor = System.Drawing.Color.Transparent;
         this.labelX7.Location = new System.Drawing.Point(28, 117);
         this.labelX7.Name = "labelX7";
         this.labelX7.Size = new System.Drawing.Size(312, 15);
         this.labelX7.TabIndex = 24;
         this.labelX7.Text = "Note: Fully qualified name is required for Active Directory Probe";
         // 
         // textDomain
         // 
         // 
         // 
         // 
         this.textDomain.Border.Class = "TextBoxBorder";
         this.textDomain.Enabled = false;
         this.textDomain.Location = new System.Drawing.Point(104, 91);
         this.textDomain.Name = "textDomain";
         this.textDomain.Size = new System.Drawing.Size(207, 20);
         this.textDomain.TabIndex = 23;
         // 
         // textPassword
         // 
         // 
         // 
         // 
         this.textPassword.Border.Class = "TextBoxBorder";
         this.textPassword.Enabled = false;
         this.textPassword.Location = new System.Drawing.Point(104, 65);
         this.textPassword.Name = "textPassword";
         this.textPassword.PasswordChar = '*';
         this.textPassword.Size = new System.Drawing.Size(207, 20);
         this.textPassword.TabIndex = 22;
         // 
         // textUserName
         // 
         // 
         // 
         // 
         this.textUserName.Border.Class = "TextBoxBorder";
         this.textUserName.Enabled = false;
         this.textUserName.Location = new System.Drawing.Point(104, 39);
         this.textUserName.Name = "textUserName";
         this.textUserName.Size = new System.Drawing.Size(207, 20);
         this.textUserName.TabIndex = 21;
         // 
         // labelX4
         // 
         this.labelX4.AutoSize = true;
         this.labelX4.BackColor = System.Drawing.Color.Transparent;
         this.labelX4.Location = new System.Drawing.Point(28, 93);
         this.labelX4.Name = "labelX4";
         this.labelX4.Size = new System.Drawing.Size(44, 15);
         this.labelX4.TabIndex = 20;
         this.labelX4.Text = "Domain:";
         // 
         // labelX5
         // 
         this.labelX5.AutoSize = true;
         this.labelX5.BackColor = System.Drawing.Color.Transparent;
         this.labelX5.Location = new System.Drawing.Point(28, 67);
         this.labelX5.Name = "labelX5";
         this.labelX5.Size = new System.Drawing.Size(54, 15);
         this.labelX5.TabIndex = 17;
         this.labelX5.Text = "Password:";
         // 
         // labelX6
         // 
         this.labelX6.AutoSize = true;
         this.labelX6.BackColor = System.Drawing.Color.Transparent;
         this.labelX6.Location = new System.Drawing.Point(28, 41);
         this.labelX6.Name = "labelX6";
         this.labelX6.Size = new System.Drawing.Size(59, 15);
         this.labelX6.TabIndex = 16;
         this.labelX6.Text = "User name:";
         // 
         // checkUseAlternateCredentials
         // 
         this.checkUseAlternateCredentials.AutoSize = true;
         this.checkUseAlternateCredentials.BackColor = System.Drawing.Color.Transparent;
         this.checkUseAlternateCredentials.Location = new System.Drawing.Point(8, 12);
         this.checkUseAlternateCredentials.Name = "checkUseAlternateCredentials";
         this.checkUseAlternateCredentials.Size = new System.Drawing.Size(148, 15);
         this.checkUseAlternateCredentials.TabIndex = 13;
         this.checkUseAlternateCredentials.Text = "Use Alternate Credentials";
         this.checkUseAlternateCredentials.CheckedChanged += new System.EventHandler(this.checkUseAlternateCredentials_CheckedChanged);
         // 
         // Form_Options
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(487, 336);
         this.Controls.Add(this.groupPanel2);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.groupPanel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form_Options";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "SQL Discovery Options";
         this.groupPanel1.ResumeLayout(false);
         this.groupPanel1.PerformLayout();
         this.groupPanel2.ResumeLayout(false);
         this.groupPanel2.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX btnCancel;
      private DevComponents.DotNetBar.ButtonX btnOK;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private Idera.SqlAdminToolset.Core.ToolNumericTextBox textLocalSourcePort;
      private Idera.SqlAdminToolset.Core.ToolNumericTextBox textICMPTimeout;
      private DevComponents.DotNetBar.LabelX labelX2;
      private DevComponents.DotNetBar.LabelX labelX1;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkEnableIcmpCheck;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkDisableSSNetLibVersionCheck;
      private DevComponents.DotNetBar.LabelX labelX3;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
      private DevComponents.DotNetBar.Controls.TextBoxX textDomain;
      private DevComponents.DotNetBar.Controls.TextBoxX textPassword;
      private DevComponents.DotNetBar.Controls.TextBoxX textUserName;
      private DevComponents.DotNetBar.LabelX labelX4;
      private DevComponents.DotNetBar.LabelX labelX5;
      private DevComponents.DotNetBar.LabelX labelX6;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkUseAlternateCredentials;
       private DevComponents.DotNetBar.LabelX labelX7;
   }
}