namespace Idera.SqlAdminToolset.SpaceAnalyzer
{
    partial class Form_GetWMICredentials
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_GetWMICredentials));
            this.button_Cancel = new DevComponents.DotNetBar.ButtonX();
            this.button_OK = new DevComponents.DotNetBar.ButtonX();
            this.label_WMI_Instructions = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.textBox_User = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBox_Password = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.button_TestWMIConnection = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(446, 154);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 0;
            this.button_Cancel.Text = "&Cancel";
            // 
            // button_OK
            // 
            this.button_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_OK.Location = new System.Drawing.Point(358, 154);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "&OK";
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // label_WMI_Instructions
            // 
            this.label_WMI_Instructions.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_WMI_Instructions.Location = new System.Drawing.Point(0, 0);
            this.label_WMI_Instructions.Name = "label_WMI_Instructions";
            this.label_WMI_Instructions.PaddingBottom = 3;
            this.label_WMI_Instructions.PaddingLeft = 3;
            this.label_WMI_Instructions.PaddingRight = 3;
            this.label_WMI_Instructions.PaddingTop = 3;
            this.label_WMI_Instructions.Size = new System.Drawing.Size(533, 70);
            this.label_WMI_Instructions.TabIndex = 2;
            this.label_WMI_Instructions.Text = resources.GetString("label_WMI_Instructions.Text");
            this.label_WMI_Instructions.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.label_WMI_Instructions.WordWrap = true;
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(7, 77);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(35, 23);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "User:";
            // 
            // textBox_User
            // 
            // 
            // 
            // 
            this.textBox_User.Border.Class = "TextBoxBorder";
            this.textBox_User.Location = new System.Drawing.Point(80, 80);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(441, 20);
            this.textBox_User.TabIndex = 4;
            // 
            // textBox_Password
            // 
            // 
            // 
            // 
            this.textBox_Password.Border.Class = "TextBoxBorder";
            this.textBox_Password.Location = new System.Drawing.Point(80, 115);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(441, 20);
            this.textBox_Password.TabIndex = 6;
            this.textBox_Password.UseSystemPasswordChar = true;
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(7, 112);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(67, 23);
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "Password:";
            // 
            // button_TestWMIConnection
            // 
            this.button_TestWMIConnection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_TestWMIConnection.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_TestWMIConnection.Location = new System.Drawing.Point(80, 154);
            this.button_TestWMIConnection.Name = "button_TestWMIConnection";
            this.button_TestWMIConnection.Size = new System.Drawing.Size(126, 23);
            this.button_TestWMIConnection.TabIndex = 7;
            this.button_TestWMIConnection.Text = "&Test WMI Connection";
            this.button_TestWMIConnection.Click += new System.EventHandler(this.button_TestWMIConnection_Click);
            // 
            // Form_GetWMICredentials
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(533, 190);
            this.Controls.Add(this.button_TestWMIConnection);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.textBox_User);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.label_WMI_Instructions);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_GetWMICredentials";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WMI Credentials - ";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX button_Cancel;
        private DevComponents.DotNetBar.ButtonX button_OK;
        private DevComponents.DotNetBar.LabelX label_WMI_Instructions;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBox_User;
        private DevComponents.DotNetBar.Controls.TextBoxX textBox_Password;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX button_TestWMIConnection;
    }
}