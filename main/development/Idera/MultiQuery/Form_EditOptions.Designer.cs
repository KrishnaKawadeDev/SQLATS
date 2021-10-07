namespace Idera.SqlAdminToolset.MultiQuery
{
   partial class Form_EditOptions
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_EditOptions ) );
         this.btnCancel = new DevComponents.DotNetBar.ButtonX();
         this.btnOK = new DevComponents.DotNetBar.ButtonX();
         this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.checkShowWordWrap = new System.Windows.Forms.CheckBox();
         this.checkShowSyntaxColors = new System.Windows.Forms.CheckBox();
         this.checkShowSyntaxErrors = new System.Windows.Forms.CheckBox();
         this.checkShowModifiedLines = new System.Windows.Forms.CheckBox();
         this.checkShowLineNumbers = new System.Windows.Forms.CheckBox();
         this.groupPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnCancel
         // 
         this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point( 340, 157 );
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
         this.btnCancel.TabIndex = 20;
         this.btnCancel.Text = "&Cancel";
         // 
         // btnOK
         // 
         this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point( 259, 157 );
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size( 75, 23 );
         this.btnOK.TabIndex = 19;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler( this.btnOK_Click );
         // 
         // groupPanel1
         // 
         this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel1.Controls.Add( this.checkShowWordWrap );
         this.groupPanel1.Controls.Add( this.checkShowSyntaxColors );
         this.groupPanel1.Controls.Add( this.checkShowSyntaxErrors );
         this.groupPanel1.Controls.Add( this.checkShowModifiedLines );
         this.groupPanel1.Controls.Add( this.checkShowLineNumbers );
         this.groupPanel1.IsShadowEnabled = true;
         this.groupPanel1.Location = new System.Drawing.Point( 8, 8 );
         this.groupPanel1.Name = "groupPanel1";
         this.groupPanel1.Size = new System.Drawing.Size( 407, 143 );
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
         this.groupPanel1.Text = "Specify Options for the Query Editor:";
         // 
         // checkShowWordWrap
         // 
         this.checkShowWordWrap.AutoSize = true;
         this.checkShowWordWrap.BackColor = System.Drawing.Color.Transparent;
         this.checkShowWordWrap.Location = new System.Drawing.Point( 8, 77 );
         this.checkShowWordWrap.Name = "checkShowWordWrap";
         this.checkShowWordWrap.Size = new System.Drawing.Size( 278, 17 );
         this.checkShowWordWrap.TabIndex = 4;
         this.checkShowWordWrap.Text = "Wrap words to beginning of next line when necessary";
         this.checkShowWordWrap.UseVisualStyleBackColor = false;
         // 
         // checkShowSyntaxColors
         // 
         this.checkShowSyntaxColors.AutoSize = true;
         this.checkShowSyntaxColors.BackColor = System.Drawing.Color.Transparent;
         this.checkShowSyntaxColors.Location = new System.Drawing.Point( 8, 54 );
         this.checkShowSyntaxColors.Name = "checkShowSyntaxColors";
         this.checkShowSyntaxColors.Size = new System.Drawing.Size( 168, 17 );
         this.checkShowSyntaxColors.TabIndex = 3;
         this.checkShowSyntaxColors.Text = "Show syntax color highlighting";
         this.checkShowSyntaxColors.UseVisualStyleBackColor = false;
         // 
         // checkShowSyntaxErrors
         // 
         this.checkShowSyntaxErrors.AutoSize = true;
         this.checkShowSyntaxErrors.BackColor = System.Drawing.Color.Transparent;
         this.checkShowSyntaxErrors.Location = new System.Drawing.Point( 273, 3 );
         this.checkShowSyntaxErrors.Name = "checkShowSyntaxErrors";
         this.checkShowSyntaxErrors.Size = new System.Drawing.Size( 115, 17 );
         this.checkShowSyntaxErrors.TabIndex = 2;
         this.checkShowSyntaxErrors.Text = "Show syntax errors";
         this.checkShowSyntaxErrors.UseVisualStyleBackColor = false;
         this.checkShowSyntaxErrors.Visible = false;
         // 
         // checkShowModifiedLines
         // 
         this.checkShowModifiedLines.AutoSize = true;
         this.checkShowModifiedLines.BackColor = System.Drawing.Color.Transparent;
         this.checkShowModifiedLines.Checked = true;
         this.checkShowModifiedLines.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkShowModifiedLines.Location = new System.Drawing.Point( 8, 31 );
         this.checkShowModifiedLines.Name = "checkShowModifiedLines";
         this.checkShowModifiedLines.Size = new System.Drawing.Size( 194, 17 );
         this.checkShowModifiedLines.TabIndex = 1;
         this.checkShowModifiedLines.Text = "Show lines that have been modified";
         this.checkShowModifiedLines.UseVisualStyleBackColor = false;
         // 
         // checkShowLineNumbers
         // 
         this.checkShowLineNumbers.AutoSize = true;
         this.checkShowLineNumbers.BackColor = System.Drawing.Color.Transparent;
         this.checkShowLineNumbers.Checked = true;
         this.checkShowLineNumbers.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkShowLineNumbers.Location = new System.Drawing.Point( 8, 8 );
         this.checkShowLineNumbers.Name = "checkShowLineNumbers";
         this.checkShowLineNumbers.Size = new System.Drawing.Size( 115, 17 );
         this.checkShowLineNumbers.TabIndex = 0;
         this.checkShowLineNumbers.Text = "Show line numbers";
         this.checkShowLineNumbers.UseVisualStyleBackColor = false;
         // 
         // Form_EditOptions
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size( 423, 185 );
         this.Controls.Add( this.btnCancel );
         this.Controls.Add( this.btnOK );
         this.Controls.Add( this.groupPanel1 );
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form_EditOptions";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Editor Options";
         this.groupPanel1.ResumeLayout( false );
         this.groupPanel1.PerformLayout();
         this.ResumeLayout( false );

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX btnCancel;
      private DevComponents.DotNetBar.ButtonX btnOK;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      public System.Windows.Forms.CheckBox checkShowSyntaxErrors;
      public System.Windows.Forms.CheckBox checkShowModifiedLines;
      public System.Windows.Forms.CheckBox checkShowLineNumbers;
      public System.Windows.Forms.CheckBox checkShowSyntaxColors;
      public System.Windows.Forms.CheckBox checkShowWordWrap;
   }
}