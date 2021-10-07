namespace Idera.SqlAdminToolset.Core
{
   partial class Form_ShowWarning
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_ShowWarning ) );
         this.checkBoxDontShowWarning = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.labelMessage = new DevComponents.DotNetBar.LabelX();
         this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
         this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
         this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
         this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.groupPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // checkBoxDontShowWarning
         // 
         this.checkBoxDontShowWarning.BackColor = System.Drawing.Color.Transparent;
         this.checkBoxDontShowWarning.Location = new System.Drawing.Point( 12, 104 );
         this.checkBoxDontShowWarning.Name = "checkBoxDontShowWarning";
         this.checkBoxDontShowWarning.Size = new System.Drawing.Size( 220, 20 );
         this.checkBoxDontShowWarning.TabIndex = 5;
         this.checkBoxDontShowWarning.Text = "Do not show this warning ever again.";
         // 
         // labelMessage
         // 
         this.labelMessage.BackColor = System.Drawing.Color.Transparent;
         this.labelMessage.ForeColor = System.Drawing.SystemColors.ControlText;
         this.labelMessage.Location = new System.Drawing.Point( 12, 11 );
         this.labelMessage.Name = "labelMessage";
         this.labelMessage.Size = new System.Drawing.Size( 526, 87 );
         this.labelMessage.TabIndex = 0;
         this.labelMessage.Text = "test message";
         this.labelMessage.TextLineAlignment = System.Drawing.StringAlignment.Near;
         this.labelMessage.WordWrap = true;
         // 
         // buttonX1
         // 
         this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonX1.Location = new System.Drawing.Point( 328, 104 );
         this.buttonX1.Name = "buttonX1";
         this.buttonX1.Size = new System.Drawing.Size( 66, 20 );
         this.buttonX1.TabIndex = 2;
         this.buttonX1.Text = "Yes";
         // 
         // buttonX2
         // 
         this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonX2.Location = new System.Drawing.Point( 400, 104 );
         this.buttonX2.Name = "buttonX2";
         this.buttonX2.Size = new System.Drawing.Size( 66, 20 );
         this.buttonX2.TabIndex = 3;
         this.buttonX2.Text = "No";
         // 
         // buttonX3
         // 
         this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonX3.Location = new System.Drawing.Point( 472, 104 );
         this.buttonX3.Name = "buttonX3";
         this.buttonX3.Size = new System.Drawing.Size( 66, 20 );
         this.buttonX3.TabIndex = 4;
         this.buttonX3.Text = "Cancel";
         // 
         // groupPanel1
         // 
         this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel1.Controls.Add( this.buttonX3 );
         this.groupPanel1.Controls.Add( this.labelMessage );
         this.groupPanel1.Controls.Add( this.buttonX2 );
         this.groupPanel1.Controls.Add( this.checkBoxDontShowWarning );
         this.groupPanel1.Controls.Add( this.buttonX1 );
         this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupPanel1.Location = new System.Drawing.Point( 0, 0 );
         this.groupPanel1.Name = "groupPanel1";
         this.groupPanel1.Size = new System.Drawing.Size( 550, 131 );
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
         // Form_ShowWarning
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.ClientSize = new System.Drawing.Size( 550, 131 );
         this.Controls.Add( this.groupPanel1 );
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form_ShowWarning";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Warning";
         this.groupPanel1.ResumeLayout( false );
         this.ResumeLayout( false );

      }

      #endregion

      private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxDontShowWarning;
      private DevComponents.DotNetBar.LabelX labelMessage;
      private DevComponents.DotNetBar.ButtonX buttonX1;
      private DevComponents.DotNetBar.ButtonX buttonX2;
      private DevComponents.DotNetBar.ButtonX buttonX3;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
   }
}