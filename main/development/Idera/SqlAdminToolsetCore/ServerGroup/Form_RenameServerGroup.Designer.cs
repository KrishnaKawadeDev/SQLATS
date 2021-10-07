namespace Idera.SqlAdminToolset.Core
{
   partial class Form_RenameServerGroup
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_RenameServerGroup ) );
         this.textOldName = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.labelOldName = new DevComponents.DotNetBar.LabelX();
         this.textNewName = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.labelNewName = new DevComponents.DotNetBar.LabelX();
         this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.btnCancel = new DevComponents.DotNetBar.ButtonX();
         this.btnOK = new DevComponents.DotNetBar.ButtonX();
         this.groupPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // textOldName
         // 
         // 
         // 
         // 
         this.textOldName.Border.Class = "TextBoxBorder";
         this.textOldName.Location = new System.Drawing.Point( 87, 11 );
         this.textOldName.Name = "textOldName";
         this.textOldName.ReadOnly = true;
         this.textOldName.Size = new System.Drawing.Size( 390, 20 );
         this.textOldName.TabIndex = 1;
         this.textOldName.Tag = "";
         // 
         // labelOldName
         // 
         this.labelOldName.AutoSize = true;
         this.labelOldName.BackColor = System.Drawing.Color.Transparent;
         this.labelOldName.Location = new System.Drawing.Point( 7, 12 );
         this.labelOldName.Name = "labelOldName";
         this.labelOldName.Size = new System.Drawing.Size( 74, 15 );
         this.labelOldName.TabIndex = 0;
         this.labelOldName.Tag = "";
         this.labelOldName.Text = "Current Name:";
         // 
         // textNewName
         // 
         // 
         // 
         // 
         this.textNewName.Border.Class = "TextBoxBorder";
         this.textNewName.Location = new System.Drawing.Point( 87, 37 );
         this.textNewName.Name = "textNewName";
         this.textNewName.Size = new System.Drawing.Size( 390, 20 );
         this.textNewName.TabIndex = 3;
         this.textNewName.TextChanged += new System.EventHandler( this.textNewName_TextChanged );
         // 
         // labelNewName
         // 
         this.labelNewName.BackColor = System.Drawing.Color.Transparent;
         this.labelNewName.Location = new System.Drawing.Point( 7, 38 );
         this.labelNewName.Name = "labelNewName";
         this.labelNewName.Size = new System.Drawing.Size( 71, 15 );
         this.labelNewName.TabIndex = 2;
         this.labelNewName.Text = "New Name:";
         // 
         // groupPanel1
         // 
         this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel1.Controls.Add( this.labelOldName );
         this.groupPanel1.Controls.Add( this.textNewName );
         this.groupPanel1.Controls.Add( this.textOldName );
         this.groupPanel1.Controls.Add( this.labelNewName );
         this.groupPanel1.IsShadowEnabled = true;
         this.groupPanel1.Location = new System.Drawing.Point( 8, 8 );
         this.groupPanel1.Name = "groupPanel1";
         this.groupPanel1.Size = new System.Drawing.Size( 492, 87 );
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
         this.groupPanel1.TabIndex = 6;
         this.groupPanel1.Text = "Specify New Server Group Name";
         // 
         // btnCancel
         // 
         this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point( 425, 101 );
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
         this.btnCancel.TabIndex = 27;
         this.btnCancel.Text = "&Cancel";
         // 
         // btnOK
         // 
         this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnOK.Enabled = false;
         this.btnOK.Location = new System.Drawing.Point( 344, 101 );
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size( 75, 23 );
         this.btnOK.TabIndex = 26;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler( this.buttonOK_Click );
         // 
         // Form_RenameServerGroup
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size( 506, 129 );
         this.Controls.Add( this.btnCancel );
         this.Controls.Add( this.btnOK );
         this.Controls.Add( this.groupPanel1 );
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form_RenameServerGroup";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Rename Server Group";
         this.groupPanel1.ResumeLayout( false );
         this.groupPanel1.PerformLayout();
         this.ResumeLayout( false );

      }

      #endregion

      private DevComponents.DotNetBar.Controls.TextBoxX textOldName;
      private DevComponents.DotNetBar.LabelX labelOldName;
      private DevComponents.DotNetBar.Controls.TextBoxX textNewName;
      private DevComponents.DotNetBar.LabelX labelNewName;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.ButtonX btnCancel;
      private DevComponents.DotNetBar.ButtonX btnOK;
   }
}