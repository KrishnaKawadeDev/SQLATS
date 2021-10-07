namespace Idera.SqlAdminToolset.ServerPing
{
    partial class Form_ServerProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ServerProperties));
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelLicenseKey = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.textPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonTestConnection = new DevComponents.DotNetBar.ButtonX();
            this.textLoginName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelPassword = new DevComponents.DotNetBar.LabelX();
            this.labelLoginName = new DevComponents.DotNetBar.LabelX();
            this.labelAuthentication = new DevComponents.DotNetBar.LabelX();
            this.radioSQL = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioWindows = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.textServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.checkIgnore = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonBrowseServer = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(383, 302);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "&Cancel";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(302, 302);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.buttonBrowseServer);
            this.groupPanel1.Controls.Add(this.labelLicenseKey);
            this.groupPanel1.Controls.Add(this.groupPanel2);
            this.groupPanel1.Controls.Add(this.textServer);
            this.groupPanel1.Controls.Add(this.checkIgnore);
            this.groupPanel1.IsShadowEnabled = true;
            this.groupPanel1.Location = new System.Drawing.Point(8, 8);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(451, 286);
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
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel1.TabIndex = 0;
            // 
            // labelLicenseKey
            // 
            this.labelLicenseKey.BackColor = System.Drawing.Color.Transparent;
            this.labelLicenseKey.Location = new System.Drawing.Point(8, 4);
            this.labelLicenseKey.Name = "labelLicenseKey";
            this.labelLicenseKey.Size = new System.Drawing.Size(79, 15);
            this.labelLicenseKey.TabIndex = 27;
            this.labelLicenseKey.Text = "SQL Server(s):";
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.labelX1);
            this.groupPanel2.Controls.Add(this.textPassword);
            this.groupPanel2.Controls.Add(this.buttonTestConnection);
            this.groupPanel2.Controls.Add(this.textLoginName);
            this.groupPanel2.Controls.Add(this.labelPassword);
            this.groupPanel2.Controls.Add(this.labelLoginName);
            this.groupPanel2.Controls.Add(this.labelAuthentication);
            this.groupPanel2.Controls.Add(this.radioSQL);
            this.groupPanel2.Controls.Add(this.radioWindows);
            this.groupPanel2.Location = new System.Drawing.Point(93, 33);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(342, 204);
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
            this.groupPanel2.TabIndex = 2;
            this.groupPanel2.Text = "Specify Type of Authentication";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Location = new System.Drawing.Point(21, 133);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(300, 44);
            this.labelX1.TabIndex = 10;
            this.labelX1.Text = "Note: The Authentication Type only applies when testing by creating a SQL connect" +
                "ion to each server. This has no effect when testing via WMI.";
            this.labelX1.WordWrap = true;
            // 
            // textPassword
            // 
            // 
            // 
            // 
            this.textPassword.Border.Class = "TextBoxBorder";
            // this.textPassword.Enabled = false;
            this.textPassword.Location = new System.Drawing.Point(93, 65);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(227, 20);
            this.textPassword.TabIndex = 8;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonTestConnection.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonTestConnection.Location = new System.Drawing.Point(93, 99);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(227, 23);
            this.buttonTestConnection.TabIndex = 9;
            this.buttonTestConnection.Text = "&Test Connection";
            this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
            // 
            // textLoginName
            // 
            // 
            // 
            // 
            this.textLoginName.Border.Class = "TextBoxBorder";
            //    this.textLoginName.Enabled = false;
            this.textLoginName.Location = new System.Drawing.Point(93, 38);
            this.textLoginName.Name = "textLoginName";
            this.textLoginName.Size = new System.Drawing.Size(227, 20);
            this.textLoginName.TabIndex = 6;
            // 
            // labelPassword
            // 
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Location = new System.Drawing.Point(22, 65);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(65, 17);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "Password:";
            // 
            // labelLoginName
            // 
            this.labelLoginName.BackColor = System.Drawing.Color.Transparent;
            this.labelLoginName.Location = new System.Drawing.Point(22, 38);
            this.labelLoginName.Name = "labelLoginName";
            this.labelLoginName.Size = new System.Drawing.Size(65, 17);
            this.labelLoginName.TabIndex = 5;
            this.labelLoginName.Text = "Login name:";
            // 
            // labelAuthentication
            // 
            this.labelAuthentication.BackColor = System.Drawing.Color.Transparent;
            this.labelAuthentication.Location = new System.Drawing.Point(23, 12);
            this.labelAuthentication.Name = "labelAuthentication";
            this.labelAuthentication.Size = new System.Drawing.Size(75, 17);
            this.labelAuthentication.TabIndex = 5;
            this.labelAuthentication.Text = "Authentication:";
            // 
            // radioSQL
            // 
            this.radioSQL.BackColor = System.Drawing.Color.Transparent;
            this.radioSQL.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioSQL.Location = new System.Drawing.Point(183, 12);
            this.radioSQL.Name = "radioSQL";
            this.radioSQL.Size = new System.Drawing.Size(110, 21);
            this.radioSQL.TabIndex = 4;
            this.radioSQL.Text = "SQL Server";
            // 
            // radioWindows
            // 
            this.radioWindows.BackColor = System.Drawing.Color.Transparent;
            this.radioWindows.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioWindows.Checked = true;
            this.radioWindows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioWindows.CheckValue = "Y";
            this.radioWindows.Location = new System.Drawing.Point(99, 10);
            this.radioWindows.Name = "radioWindows";
            this.radioWindows.Size = new System.Drawing.Size(77, 23);
            this.radioWindows.TabIndex = 3;
            this.radioWindows.Text = "Windows";
            this.radioWindows.CheckedChanged += new System.EventHandler(this.radioWindows_CheckedChanged);
            // 
            // textServer
            // 
            // 
            // 
            // 
            this.textServer.Border.Class = "TextBoxBorder";
            this.textServer.Location = new System.Drawing.Point(93, 3);
            this.textServer.Multiline = true;
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(316, 20);
            this.textServer.TabIndex = 1;
            this.textServer.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.textServer.WatermarkText = "Enter one or more SQL Servers separated by semi-colons";
            // 
            // checkIgnore
            // 
            this.checkIgnore.AutoSize = true;
            this.checkIgnore.BackColor = System.Drawing.Color.Transparent;
            this.checkIgnore.Location = new System.Drawing.Point(1, 255);
            this.checkIgnore.Name = "checkIgnore";
            this.checkIgnore.Size = new System.Drawing.Size(398, 15);
            this.checkIgnore.TabIndex = 10;
            this.checkIgnore.Text = "Ignore this SQL Server in calculation of overall status,  alerts and notification" +
                "s";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "server_add.ico");
            this.imageList1.Images.SetKeyName(1, "server_edit.ico");
            // 
            // buttonBrowseServer
            // 
            this.buttonBrowseServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseServer.BackColor = System.Drawing.Color.White;
            this.buttonBrowseServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseServer.Location = new System.Drawing.Point(415, 3);
            this.buttonBrowseServer.Name = "buttonBrowseServer";
            this.buttonBrowseServer.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseServer.TabIndex = 2;
            this.buttonBrowseServer.Text = "...";
            this.buttonBrowseServer.Click += new System.EventHandler(this.buttonBrowseServer_Click);
            // 
            // Form_ServerProperties
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(466, 332);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ServerProperties";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Server";
            this.Load += new System.EventHandler(this.Form_ServerProperties_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkIgnore;
        private DevComponents.DotNetBar.LabelX labelLicenseKey;
        private DevComponents.DotNetBar.ButtonX buttonTestConnection;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.TextBoxX textPassword;
        private DevComponents.DotNetBar.Controls.TextBoxX textLoginName;
        private DevComponents.DotNetBar.LabelX labelPassword;
        private DevComponents.DotNetBar.LabelX labelLoginName;
        private DevComponents.DotNetBar.LabelX labelAuthentication;
        private DevComponents.DotNetBar.Controls.CheckBoxX radioSQL;
        private DevComponents.DotNetBar.Controls.CheckBoxX radioWindows;
        private DevComponents.DotNetBar.Controls.TextBoxX textServer;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX buttonBrowseServer;
    }
}