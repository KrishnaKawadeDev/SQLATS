namespace Idera.SqlAdminToolset.Core
{
    partial class Form_Credentials
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Credentials));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textLoginName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelPassword = new DevComponents.DotNetBar.LabelX();
            this.labelLoginName = new DevComponents.DotNetBar.LabelX();
            this.labelAuthentication = new DevComponents.DotNetBar.LabelX();
            this.radioSQL = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioWindows = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.buttonTestConnection = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.textPassword);
            this.groupPanel1.Controls.Add(this.textLoginName);
            this.groupPanel1.Controls.Add(this.labelPassword);
            this.groupPanel1.Controls.Add(this.labelLoginName);
            this.groupPanel1.Controls.Add(this.labelAuthentication);
            this.groupPanel1.Controls.Add(this.radioSQL);
            this.groupPanel1.Controls.Add(this.radioWindows);
            this.groupPanel1.Location = new System.Drawing.Point(9, 8);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(344, 132);
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
            this.groupPanel1.Text = "Specify Type of Authentication";
            // 
            // textPassword
            // 
            // 
            // 
            // 
            this.textPassword.Border.Class = "TextBoxBorder";
            this.textPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textPassword.Location = new System.Drawing.Point(93, 65);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '●';
            this.textPassword.Size = new System.Drawing.Size(227, 20);
            this.textPassword.TabIndex = 6;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // textLoginName
            // 
            // 
            // 
            // 
            this.textLoginName.Border.Class = "TextBoxBorder";
            this.textLoginName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textLoginName.Location = new System.Drawing.Point(93, 35);
            this.textLoginName.Name = "textLoginName";
            this.textLoginName.Size = new System.Drawing.Size(227, 20);
            this.textLoginName.TabIndex = 4;
            // 
            // labelPassword
            // 
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelPassword.BackgroundStyle.Class = "";
            this.labelPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelPassword.Location = new System.Drawing.Point(12, 65);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(65, 17);
            this.labelPassword.TabIndex = 5;
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
            this.labelLoginName.Location = new System.Drawing.Point(12, 35);
            this.labelLoginName.Name = "labelLoginName";
            this.labelLoginName.Size = new System.Drawing.Size(65, 17);
            this.labelLoginName.TabIndex = 3;
            this.labelLoginName.Text = "Login name:";
            // 
            // labelAuthentication
            // 
            this.labelAuthentication.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelAuthentication.BackgroundStyle.Class = "";
            this.labelAuthentication.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelAuthentication.Location = new System.Drawing.Point(12, 8);
            this.labelAuthentication.Name = "labelAuthentication";
            this.labelAuthentication.Size = new System.Drawing.Size(80, 17);
            this.labelAuthentication.TabIndex = 4;
            this.labelAuthentication.Text = "Authentication:";
            // 
            // radioSQL
            // 
            this.radioSQL.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioSQL.BackgroundStyle.Class = "";
            this.radioSQL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioSQL.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioSQL.Location = new System.Drawing.Point(180, 8);
            this.radioSQL.Name = "radioSQL";
            this.radioSQL.Size = new System.Drawing.Size(110, 21);
            this.radioSQL.TabIndex = 2;
            this.radioSQL.Text = "SQL Server";
            this.radioSQL.CheckedChanged += new System.EventHandler(this.radioSQL_CheckedChanged);
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
            this.radioWindows.Location = new System.Drawing.Point(95, 6);
            this.radioWindows.Name = "radioWindows";
            this.radioWindows.Size = new System.Drawing.Size(77, 23);
            this.radioWindows.TabIndex = 1;
            this.radioWindows.Text = "Windows";
            this.radioWindows.CheckedChanged += new System.EventHandler(this.radioWindowsSql_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(197, 146);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 25;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(278, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonTestConnection.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonTestConnection.Location = new System.Drawing.Point(9, 146);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(121, 23);
            this.buttonTestConnection.TabIndex = 24;
            this.buttonTestConnection.Text = "&Test Connection";
            this.buttonTestConnection.Visible = false;
            this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
            // 
            // Form_Credentials
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(362, 174);
            this.Controls.Add(this.buttonTestConnection);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Credentials";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Connection Credentials";
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
       private DevComponents.DotNetBar.Controls.CheckBoxX radioSQL;
       private DevComponents.DotNetBar.Controls.CheckBoxX radioWindows;
       private DevComponents.DotNetBar.ButtonX btnOK;
       private DevComponents.DotNetBar.ButtonX btnCancel;
       private DevComponents.DotNetBar.Controls.TextBoxX textPassword;
       private DevComponents.DotNetBar.Controls.TextBoxX textLoginName;
       private DevComponents.DotNetBar.LabelX labelPassword;
       private DevComponents.DotNetBar.LabelX labelLoginName;
        private DevComponents.DotNetBar.LabelX labelAuthentication;
       private DevComponents.DotNetBar.ButtonX buttonTestConnection;
    }
}