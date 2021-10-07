using System;

namespace Idera.SqlAdminToolset.Core
{
    partial class Form_AddServerToGroup
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
                components.Dispose();

            base.Dispose(disposing);

            GC.SuppressFinalize(this);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AddServerToGroup));
            this.labelLicenseKey = new DevComponents.DotNetBar.LabelX();
            this.textServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textLoginName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelPassword = new DevComponents.DotNetBar.LabelX();
            this.labelLoginName = new DevComponents.DotNetBar.LabelX();
            this.labelAuthentication = new DevComponents.DotNetBar.LabelX();
            this.radioSQL = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioWindows = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
            this.buttonOK = new DevComponents.DotNetBar.ButtonX();
            this.buttonTestConnection = new DevComponents.DotNetBar.ButtonX();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLicenseKey
            // 
            this.labelLicenseKey.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelLicenseKey.BackgroundStyle.Class = "";
            this.labelLicenseKey.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelLicenseKey.Location = new System.Drawing.Point(8, 7);
            this.labelLicenseKey.Name = "labelLicenseKey";
            this.labelLicenseKey.Size = new System.Drawing.Size(79, 15);
            this.labelLicenseKey.TabIndex = 1;
            this.labelLicenseKey.Text = "SQL Server(s):";
            // 
            // textServer
            // 
            // 
            // 
            // 
            this.textServer.Border.Class = "TextBoxBorder";
            this.textServer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textServer.Location = new System.Drawing.Point(93, 6);
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(342, 21);
            this.textServer.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textServer, "Enter one or more SQL Servers separated by semi-colons.");
            this.textServer.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.textServer.WatermarkText = "Enter one or more SQL Servers separated by semi-colons";
            this.textServer.TextChanged += new System.EventHandler(this.textServer_TextChanged);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(441, 5);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(24, 22);
            this.buttonBrowse.TabIndex = 3;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.textPassword);
            this.groupPanel1.Controls.Add(this.textLoginName);
            this.groupPanel1.Controls.Add(this.labelPassword);
            this.groupPanel1.Controls.Add(this.labelLoginName);
            this.groupPanel1.Controls.Add(this.labelAuthentication);
            this.groupPanel1.Controls.Add(this.radioSQL);
            this.groupPanel1.Controls.Add(this.radioWindows);
            this.groupPanel1.Location = new System.Drawing.Point(93, 36);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(342, 132);
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
            this.groupPanel1.TabIndex = 4;
            this.groupPanel1.Text = "Specify Type of Authentication";
            // 
            // textPassword
            // 
            // 
            // 
            // 
            this.textPassword.Border.Class = "TextBoxBorder";
            this.textPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // this.textPassword.Enabled = false;
            this.textPassword.Location = new System.Drawing.Point(93, 65);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(227, 20);
            this.textPassword.TabIndex = 8;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // textLoginName
            // 
            // 
            // 
            // 
            this.textLoginName.Border.Class = "TextBoxBorder";
            this.textLoginName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            //this.textLoginName.Enabled = false;
            this.textLoginName.Location = new System.Drawing.Point(93, 35);
            this.textLoginName.Name = "textLoginName";
            this.textLoginName.Size = new System.Drawing.Size(227, 20);
            this.textLoginName.TabIndex = 7;
            // 
            // labelPassword
            // 
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelPassword.BackgroundStyle.Class = "";
            this.labelPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelPassword.Location = new System.Drawing.Point(22, 65);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(65, 17);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password:";
            // 
            // labelLoginName
            // 
            this.labelLoginName.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelLoginName.BackgroundStyle.Class = "";
            this.labelLoginName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelLoginName.Location = new System.Drawing.Point(22, 35);
            this.labelLoginName.Name = "labelLoginName";
            this.labelLoginName.Size = new System.Drawing.Size(65, 17);
            this.labelLoginName.TabIndex = 2;
            this.labelLoginName.Text = "Login name:";
            // 
            // radioSQL
            // 
            // 
            // labelAuthentication
            // 
            this.labelAuthentication.BackColor = System.Drawing.Color.Transparent;
            this.labelAuthentication.Location = new System.Drawing.Point(22, 8);
            this.labelAuthentication.Name = "labelAuthentication";
            this.labelAuthentication.Size = new System.Drawing.Size(75, 17);
            this.labelAuthentication.TabIndex = 5;
            this.labelAuthentication.Text = "Authentication:";
            this.radioSQL.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioSQL.BackgroundStyle.Class = "";
            this.radioSQL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioSQL.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioSQL.Location = new System.Drawing.Point(183, 6);
            this.radioSQL.Name = "radioSQL";
            this.radioSQL.Size = new System.Drawing.Size(110, 21);
            this.radioSQL.TabIndex = 6;
            this.radioSQL.Text = "SQL Server";
            this.radioSQL.CheckedChanged += new System.EventHandler(this.radioWindowsSql_CheckedChanged);
            // 
            // radioWindows
            // 
            this.radioWindows.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioWindows.BackgroundStyle.Class = "";
            this.radioWindows.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioWindows.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioWindows.Checked = true;
            this.radioWindows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioWindows.CheckValue = "Y";
            this.radioWindows.Location = new System.Drawing.Point(99, 6);
            this.radioWindows.Name = "radioWindows";
            this.radioWindows.Size = new System.Drawing.Size(77, 23);
            this.radioWindows.TabIndex = 5;
            this.radioWindows.Text = "Windows";
            this.radioWindows.CheckedChanged += new System.EventHandler(this.radioWindowsSql_CheckedChanged);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.labelLicenseKey);
            this.groupPanel2.Controls.Add(this.groupPanel1);
            this.groupPanel2.Controls.Add(this.textServer);
            this.groupPanel2.Controls.Add(this.buttonBrowse);
            this.groupPanel2.IsShadowEnabled = true;
            this.groupPanel2.Location = new System.Drawing.Point(8, 8);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(476, 204);
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
            this.groupPanel2.TabIndex = 0;
            this.groupPanel2.Text = "Specify Servers to add to the Server Group";
            // 
            // buttonCancel
            // 
            this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(409, 217);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 28;
            this.buttonCancel.Text = "&Cancel";
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(328, 217);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 27;
            this.buttonOK.Text = "&OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonTestConnection.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonTestConnection.Enabled = false;
            this.buttonTestConnection.Location = new System.Drawing.Point(8, 217);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(121, 23);
            this.buttonTestConnection.TabIndex = 26;
            this.buttonTestConnection.Text = "&Test Connection";
            this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
            // 
            // Form_AddServerToGroup
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(493, 245);
            this.Controls.Add(this.buttonTestConnection);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_AddServerToGroup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Servers to Server Group";
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelLicenseKey;
        private DevComponents.DotNetBar.Controls.TextBoxX textServer;
        private System.Windows.Forms.Button buttonBrowse;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX textPassword;
        private DevComponents.DotNetBar.Controls.TextBoxX textLoginName;
        private DevComponents.DotNetBar.LabelX labelPassword;
        private DevComponents.DotNetBar.LabelX labelLoginName;
        private DevComponents.DotNetBar.LabelX labelAuthentication;
        private DevComponents.DotNetBar.Controls.CheckBoxX radioSQL;
        private DevComponents.DotNetBar.Controls.CheckBoxX radioWindows;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX buttonCancel;
        private DevComponents.DotNetBar.ButtonX buttonOK;
        private DevComponents.DotNetBar.ButtonX buttonTestConnection;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}