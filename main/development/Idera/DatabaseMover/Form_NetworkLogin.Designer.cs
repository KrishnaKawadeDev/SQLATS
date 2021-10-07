namespace Idera.SqlAdminToolset.DatabaseMover
{
   partial class Form_NetworkLogin
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_NetworkLogin));
         this.textPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.labelInstructions = new DevComponents.DotNetBar.LabelX();
         this.textLoginName = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.labelPassword = new DevComponents.DotNetBar.LabelX();
         this.labelLoginName = new DevComponents.DotNetBar.LabelX();
         this.btnOK = new DevComponents.DotNetBar.ButtonX();
         this.btnCancel = new DevComponents.DotNetBar.ButtonX();
         this.groupPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // textPassword
         // 
         // 
         // 
         // 
         this.textPassword.Border.Class = "TextBoxBorder";
         this.textPassword.Location = new System.Drawing.Point(89, 77);
         this.textPassword.Name = "textPassword";
         this.textPassword.Size = new System.Drawing.Size(227, 20);
         this.textPassword.TabIndex = 5;
         this.textPassword.UseSystemPasswordChar = true;
         // 
         // groupPanel1
         // 
         this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel1.Controls.Add(this.labelInstructions);
         this.groupPanel1.Controls.Add(this.textPassword);
         this.groupPanel1.Controls.Add(this.textLoginName);
         this.groupPanel1.Controls.Add(this.labelPassword);
         this.groupPanel1.Controls.Add(this.labelLoginName);
         this.groupPanel1.Location = new System.Drawing.Point(8, 6);
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
         this.groupPanel1.Style.CornerDiameter = 4;
         this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
         this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
         this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
         this.groupPanel1.TabIndex = 26;
         this.groupPanel1.Text = "Specify Server Credentials";
         // 
         // labelInstructions
         // 
         this.labelInstructions.BackColor = System.Drawing.Color.Transparent;
         this.labelInstructions.Location = new System.Drawing.Point(18, 3);
         this.labelInstructions.Name = "labelInstructions";
         this.labelInstructions.Size = new System.Drawing.Size(298, 44);
         this.labelInstructions.TabIndex = 6;
         this.labelInstructions.Text = "{0} cannot be accessed with your windows credentials.  Please enter Windows crede" +
             "ntials (Domain\\User) to access the required network resources.";
         this.labelInstructions.WordWrap = true;
         // 
         // textLoginName
         // 
         // 
         // 
         // 
         this.textLoginName.Border.Class = "TextBoxBorder";
         this.textLoginName.Location = new System.Drawing.Point(89, 53);
         this.textLoginName.Name = "textLoginName";
         this.textLoginName.Size = new System.Drawing.Size(227, 20);
         this.textLoginName.TabIndex = 4;
         // 
         // labelPassword
         // 
         this.labelPassword.BackColor = System.Drawing.Color.Transparent;
         this.labelPassword.Location = new System.Drawing.Point(18, 77);
         this.labelPassword.Name = "labelPassword";
         this.labelPassword.Size = new System.Drawing.Size(65, 17);
         this.labelPassword.TabIndex = 3;
         this.labelPassword.Text = "Password:";
         // 
         // labelLoginName
         // 
         this.labelLoginName.BackColor = System.Drawing.Color.Transparent;
         this.labelLoginName.Location = new System.Drawing.Point(18, 53);
         this.labelLoginName.Name = "labelLoginName";
         this.labelLoginName.Size = new System.Drawing.Size(65, 17);
         this.labelLoginName.TabIndex = 2;
         this.labelLoginName.Text = "Login name:";
         // 
         // btnOK
         // 
         this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnOK.Location = new System.Drawing.Point(196, 144);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 27;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(277, 144);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 28;
         this.btnCancel.Text = "&Cancel";
         // 
         // Form_NetworkLogin
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(360, 172);
         this.Controls.Add(this.groupPanel1);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.btnCancel);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form_NetworkLogin";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "{0} Credentials";
         this.groupPanel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private DevComponents.DotNetBar.Controls.TextBoxX textPassword;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.Controls.TextBoxX textLoginName;
      private DevComponents.DotNetBar.LabelX labelPassword;
      private DevComponents.DotNetBar.LabelX labelLoginName;
      private DevComponents.DotNetBar.ButtonX btnOK;
      private DevComponents.DotNetBar.ButtonX btnCancel;
      private DevComponents.DotNetBar.LabelX labelInstructions;
   }
}