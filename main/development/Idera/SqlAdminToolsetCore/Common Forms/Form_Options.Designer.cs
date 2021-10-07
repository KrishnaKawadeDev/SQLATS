namespace Idera.SqlAdminToolset.Core
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_Options ) );
         this.labelX1 = new DevComponents.DotNetBar.LabelX();
         this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.groupLaunchpad = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.checkCloseLaunchpad = new System.Windows.Forms.CheckBox();
         this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.labelX3 = new DevComponents.DotNetBar.LabelX();
         this.labelConnectionTimeout = new DevComponents.DotNetBar.LabelX();
         this.labelCommandTimeout = new DevComponents.DotNetBar.LabelX();
         this.btnCancel = new DevComponents.DotNetBar.ButtonX();
         this.btnOK = new DevComponents.DotNetBar.ButtonX();
         this.textConnectionTimeout = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
         this.textCommandTimeout = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
         this.groupPanel1.SuspendLayout();
         this.groupLaunchpad.SuspendLayout();
         this.groupPanel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // labelX1
         // 
         this.labelX1.BackColor = System.Drawing.Color.Transparent;
         this.labelX1.Location = new System.Drawing.Point( 5, 220 );
         this.labelX1.Name = "labelX1";
         this.labelX1.Size = new System.Drawing.Size( 395, 29 );
         this.labelX1.TabIndex = 0;
         this.labelX1.Text = "Note: These options are shared between the tools in the SQL admin toolset.";
         this.labelX1.WordWrap = true;
         // 
         // groupPanel1
         // 
         this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel1.Controls.Add( this.groupLaunchpad );
         this.groupPanel1.Controls.Add( this.groupPanel2 );
         this.groupPanel1.Controls.Add( this.labelX1 );
         this.groupPanel1.IsShadowEnabled = true;
         this.groupPanel1.Location = new System.Drawing.Point( 12, 11 );
         this.groupPanel1.Name = "groupPanel1";
         this.groupPanel1.Size = new System.Drawing.Size( 508, 255 );
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
         this.groupPanel1.TabIndex = 1;
         // 
         // groupLaunchpad
         // 
         this.groupLaunchpad.BackColor = System.Drawing.Color.Transparent;
         this.groupLaunchpad.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupLaunchpad.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupLaunchpad.Controls.Add( this.checkCloseLaunchpad );
         this.groupLaunchpad.Location = new System.Drawing.Point( 5, 102 );
         this.groupLaunchpad.Name = "groupLaunchpad";
         this.groupLaunchpad.Size = new System.Drawing.Size( 267, 58 );
         // 
         // 
         // 
         this.groupLaunchpad.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
         this.groupLaunchpad.Style.BackColorGradientAngle = 90;
         this.groupLaunchpad.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
         this.groupLaunchpad.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupLaunchpad.Style.BorderBottomWidth = 1;
         this.groupLaunchpad.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
         this.groupLaunchpad.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupLaunchpad.Style.BorderLeftWidth = 1;
         this.groupLaunchpad.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupLaunchpad.Style.BorderRightWidth = 1;
         this.groupLaunchpad.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupLaunchpad.Style.BorderTopWidth = 1;
         this.groupLaunchpad.Style.CornerDiameter = 4;
         this.groupLaunchpad.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
         this.groupLaunchpad.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
         this.groupLaunchpad.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
         this.groupLaunchpad.TabIndex = 4;
         this.groupLaunchpad.Text = "Launchpad";
         // 
         // checkCloseLaunchpad
         // 
         this.checkCloseLaunchpad.AutoSize = true;
         this.checkCloseLaunchpad.Location = new System.Drawing.Point( 6, 8 );
         this.checkCloseLaunchpad.Name = "checkCloseLaunchpad";
         this.checkCloseLaunchpad.Size = new System.Drawing.Size( 211, 17 );
         this.checkCloseLaunchpad.TabIndex = 0;
         this.checkCloseLaunchpad.Text = "Close Launchpad after launching a tool";
         this.checkCloseLaunchpad.UseVisualStyleBackColor = true;
         // 
         // groupPanel2
         // 
         this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
         this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel2.Controls.Add( this.labelX3 );
         this.groupPanel2.Controls.Add( this.textConnectionTimeout );
         this.groupPanel2.Controls.Add( this.textCommandTimeout );
         this.groupPanel2.Controls.Add( this.labelConnectionTimeout );
         this.groupPanel2.Controls.Add( this.labelCommandTimeout );
         this.groupPanel2.Location = new System.Drawing.Point( 5, 4 );
         this.groupPanel2.Name = "groupPanel2";
         this.groupPanel2.Size = new System.Drawing.Size( 490, 89 );
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
         this.groupPanel2.TabIndex = 0;
         this.groupPanel2.Text = "SQL Behavior";
         // 
         // labelX3
         // 
         this.labelX3.BackColor = System.Drawing.Color.Transparent;
         this.labelX3.Location = new System.Drawing.Point( 258, 35 );
         this.labelX3.Name = "labelX3";
         this.labelX3.Size = new System.Drawing.Size( 169, 17 );
         this.labelX3.TabIndex = 5;
         this.labelX3.Text = "(0 = no timeout; wait indefinitely)";
         // 
         // labelConnectionTimeout
         // 
         this.labelConnectionTimeout.BackColor = System.Drawing.Color.Transparent;
         this.labelConnectionTimeout.Location = new System.Drawing.Point( 6, 8 );
         this.labelConnectionTimeout.Name = "labelConnectionTimeout";
         this.labelConnectionTimeout.Size = new System.Drawing.Size( 140, 17 );
         this.labelConnectionTimeout.TabIndex = 0;
         this.labelConnectionTimeout.Text = "Connection Timeout (sec):";
         // 
         // labelCommandTimeout
         // 
         this.labelCommandTimeout.BackColor = System.Drawing.Color.Transparent;
         this.labelCommandTimeout.Location = new System.Drawing.Point( 5, 37 );
         this.labelCommandTimeout.Name = "labelCommandTimeout";
         this.labelCommandTimeout.Size = new System.Drawing.Size( 142, 14 );
         this.labelCommandTimeout.TabIndex = 2;
         this.labelCommandTimeout.Text = "Command Timeout (sec):";
         // 
         // btnCancel
         // 
         this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point( 445, 276 );
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
         this.btnCancel.TabIndex = 27;
         this.btnCancel.Text = "&Cancel";
         // 
         // btnOK
         // 
         this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnOK.Location = new System.Drawing.Point( 364, 276 );
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size( 75, 23 );
         this.btnOK.TabIndex = 26;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler( this.btnOK_Click );
         // 
         // textConnectionTimeout
         // 
         this.textConnectionTimeout.Location = new System.Drawing.Point( 148, 8 );
         this.textConnectionTimeout.MaxLength = 5;
         this.textConnectionTimeout.Name = "textConnectionTimeout";
         this.textConnectionTimeout.Size = new System.Drawing.Size( 100, 20 );
         this.textConnectionTimeout.TabIndex = 1;
         // 
         // textCommandTimeout
         // 
         this.textCommandTimeout.Location = new System.Drawing.Point( 148, 35 );
         this.textCommandTimeout.MaxLength = 5;
         this.textCommandTimeout.Name = "textCommandTimeout";
         this.textCommandTimeout.Size = new System.Drawing.Size( 100, 20 );
         this.textCommandTimeout.TabIndex = 3;
         // 
         // Form_Options
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size( 532, 308 );
         this.Controls.Add( this.btnCancel );
         this.Controls.Add( this.btnOK );
         this.Controls.Add( this.groupPanel1 );
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.Name = "Form_Options";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Options";
         this.HelpRequested += new System.Windows.Forms.HelpEventHandler( this.Form_Options_HelpRequested );
         this.groupPanel1.ResumeLayout( false );
         this.groupLaunchpad.ResumeLayout( false );
         this.groupLaunchpad.PerformLayout();
         this.groupPanel2.ResumeLayout( false );
         this.ResumeLayout( false );

      }

      #endregion

      private DevComponents.DotNetBar.LabelX labelX1;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.LabelX labelCommandTimeout;
      private DevComponents.DotNetBar.LabelX labelConnectionTimeout;
      private DevComponents.DotNetBar.ButtonX btnCancel;
      private DevComponents.DotNetBar.ButtonX btnOK;
      private ToolNumericTextBox textCommandTimeout;
      private ToolNumericTextBox textConnectionTimeout;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
      private DevComponents.DotNetBar.Controls.GroupPanel groupLaunchpad;
      private System.Windows.Forms.CheckBox checkCloseLaunchpad;
      private DevComponents.DotNetBar.LabelX labelX3;
   }
}