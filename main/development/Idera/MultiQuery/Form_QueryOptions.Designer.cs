namespace Idera.SqlAdminToolset.MultiQuery
{
   partial class Form_QueryOptions
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_QueryOptions ) );
         this.labelRowcount = new DevComponents.DotNetBar.LabelX();
         this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.labelX3 = new DevComponents.DotNetBar.LabelX();
         this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.checkShowIndividualResults = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.checkShowCombinedResults = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.checkShowSummary = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.radioText = new System.Windows.Forms.RadioButton();
         this.radioGrid = new System.Windows.Forms.RadioButton();
         this.labelX2 = new DevComponents.DotNetBar.LabelX();
         this.labelX1 = new DevComponents.DotNetBar.LabelX();
         this.btnCancel = new DevComponents.DotNetBar.ButtonX();
         this.btnOK = new DevComponents.DotNetBar.ButtonX();
         this.labelX4 = new DevComponents.DotNetBar.LabelX();
         this.labelX5 = new DevComponents.DotNetBar.LabelX();
         this.textCommandTimeout = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
         this.textThreads = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
         this.textTextSize = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
         this.textRowCount = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
         this.groupPanel1.SuspendLayout();
         this.groupPanel3.SuspendLayout();
         this.groupPanel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // labelRowcount
         // 
         this.labelRowcount.AutoSize = true;
         this.labelRowcount.BackColor = System.Drawing.Color.Transparent;
         this.labelRowcount.Location = new System.Drawing.Point( 7, 7 );
         this.labelRowcount.Name = "labelRowcount";
         this.labelRowcount.Size = new System.Drawing.Size( 356, 15 );
         this.labelRowcount.TabIndex = 1;
         this.labelRowcount.Text = "Maximum number of rows to be returned from the server (ROWCOUNT):";
         // 
         // groupPanel1
         // 
         this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel1.Controls.Add( this.labelX5 );
         this.groupPanel1.Controls.Add( this.textCommandTimeout );
         this.groupPanel1.Controls.Add( this.labelX4 );
         this.groupPanel1.Controls.Add( this.textThreads );
         this.groupPanel1.Controls.Add( this.labelX3 );
         this.groupPanel1.Controls.Add( this.groupPanel3 );
         this.groupPanel1.Controls.Add( this.labelX2 );
         this.groupPanel1.Controls.Add( this.textTextSize );
         this.groupPanel1.Controls.Add( this.labelX1 );
         this.groupPanel1.Controls.Add( this.labelRowcount );
         this.groupPanel1.Controls.Add( this.textRowCount );
         this.groupPanel1.IsShadowEnabled = true;
         this.groupPanel1.Location = new System.Drawing.Point( 8, 7 );
         this.groupPanel1.Name = "groupPanel1";
         this.groupPanel1.Size = new System.Drawing.Size( 469, 242 );
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
         this.groupPanel1.Text = "Specify Query Options:";
         // 
         // labelX3
         // 
         this.labelX3.AutoSize = true;
         this.labelX3.BackColor = System.Drawing.Color.Transparent;
         this.labelX3.Location = new System.Drawing.Point( 7, 58 );
         this.labelX3.Name = "labelX3";
         this.labelX3.Size = new System.Drawing.Size( 277, 15 );
         this.labelX3.TabIndex = 5;
         this.labelX3.Text = "Maximum number of concurrent queries to run (threads):";
         // 
         // groupPanel3
         // 
         this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
         this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel3.Controls.Add( this.checkShowIndividualResults );
         this.groupPanel3.Controls.Add( this.checkShowCombinedResults );
         this.groupPanel3.Controls.Add( this.checkShowSummary );
         this.groupPanel3.Controls.Add( this.groupPanel2 );
         this.groupPanel3.IsShadowEnabled = true;
         this.groupPanel3.Location = new System.Drawing.Point( 7, 120 );
         this.groupPanel3.Name = "groupPanel3";
         this.groupPanel3.Size = new System.Drawing.Size( 448, 96 );
         // 
         // 
         // 
         this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
         this.groupPanel3.Style.BackColorGradientAngle = 90;
         this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
         this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanel3.Style.BorderBottomWidth = 1;
         this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
         this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanel3.Style.BorderLeftWidth = 1;
         this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanel3.Style.BorderRightWidth = 1;
         this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanel3.Style.BorderTopWidth = 1;
         this.groupPanel3.Style.CornerDiameter = 4;
         this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
         this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
         this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
         this.groupPanel3.TabIndex = 9;
         this.groupPanel3.Text = "Select query output views:";
         // 
         // checkShowIndividualResults
         // 
         this.checkShowIndividualResults.AutoSize = true;
         this.checkShowIndividualResults.Location = new System.Drawing.Point( 4, 54 );
         this.checkShowIndividualResults.Name = "checkShowIndividualResults";
         this.checkShowIndividualResults.Size = new System.Drawing.Size( 255, 15 );
         this.checkShowIndividualResults.TabIndex = 12;
         this.checkShowIndividualResults.Text = "Show individual result sets for each query target";
         // 
         // checkShowCombinedResults
         // 
         this.checkShowCombinedResults.AutoSize = true;
         this.checkShowCombinedResults.Checked = true;
         this.checkShowCombinedResults.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkShowCombinedResults.CheckValue = "Y";
         this.checkShowCombinedResults.Location = new System.Drawing.Point( 4, 31 );
         this.checkShowCombinedResults.Name = "checkShowCombinedResults";
         this.checkShowCombinedResults.Size = new System.Drawing.Size( 255, 15 );
         this.checkShowCombinedResults.TabIndex = 11;
         this.checkShowCombinedResults.Text = "Show result sets combined across query targets";
         // 
         // checkShowSummary
         // 
         this.checkShowSummary.AutoSize = true;
         this.checkShowSummary.Checked = true;
         this.checkShowSummary.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkShowSummary.CheckValue = "Y";
         this.checkShowSummary.Location = new System.Drawing.Point( 4, 8 );
         this.checkShowSummary.Name = "checkShowSummary";
         this.checkShowSummary.Size = new System.Drawing.Size( 287, 15 );
         this.checkShowSummary.TabIndex = 10;
         this.checkShowSummary.Text = "Show execution summary (execution times, status etc)";
         // 
         // groupPanel2
         // 
         this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
         this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel2.Controls.Add( this.radioText );
         this.groupPanel2.Controls.Add( this.radioGrid );
         this.groupPanel2.IsShadowEnabled = true;
         this.groupPanel2.Location = new System.Drawing.Point( 224, 9 );
         this.groupPanel2.Name = "groupPanel2";
         this.groupPanel2.Size = new System.Drawing.Size( 171, 73 );
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
         this.groupPanel2.TabIndex = 16;
         this.groupPanel2.Text = "How to show result sets from executed queries:";
         this.groupPanel2.Visible = false;
         // 
         // radioText
         // 
         this.radioText.AutoSize = true;
         this.radioText.Location = new System.Drawing.Point( 8, 28 );
         this.radioText.Name = "radioText";
         this.radioText.Size = new System.Drawing.Size( 143, 17 );
         this.radioText.TabIndex = 18;
         this.radioText.Text = "Display result sets as text";
         this.radioText.UseVisualStyleBackColor = true;
         // 
         // radioGrid
         // 
         this.radioGrid.AutoSize = true;
         this.radioGrid.Checked = true;
         this.radioGrid.Location = new System.Drawing.Point( 8, 6 );
         this.radioGrid.Name = "radioGrid";
         this.radioGrid.Size = new System.Drawing.Size( 145, 17 );
         this.radioGrid.TabIndex = 17;
         this.radioGrid.TabStop = true;
         this.radioGrid.Text = "Display result sets in grids";
         this.radioGrid.UseVisualStyleBackColor = true;
         // 
         // labelX2
         // 
         this.labelX2.AutoSize = true;
         this.labelX2.BackColor = System.Drawing.Color.Transparent;
         this.labelX2.Location = new System.Drawing.Point( 431, 32 );
         this.labelX2.Name = "labelX2";
         this.labelX2.Size = new System.Drawing.Size( 17, 15 );
         this.labelX2.TabIndex = 11;
         this.labelX2.Text = "KB";
         // 
         // labelX1
         // 
         this.labelX1.AutoSize = true;
         this.labelX1.BackColor = System.Drawing.Color.Transparent;
         this.labelX1.Location = new System.Drawing.Point( 7, 32 );
         this.labelX1.Name = "labelX1";
         this.labelX1.Size = new System.Drawing.Size( 360, 15 );
         this.labelX1.TabIndex = 3;
         this.labelX1.Text = "Maximum size of text data returned by a SELECT statement (TEXTSIZE):";
         // 
         // btnCancel
         // 
         this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point( 402, 255 );
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
         this.btnCancel.TabIndex = 14;
         this.btnCancel.Text = "&Cancel";
         // 
         // btnOK
         // 
         this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point( 321, 255 );
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size( 75, 23 );
         this.btnOK.TabIndex = 13;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler( this.btnOK_Click );
         // 
         // labelX4
         // 
         this.labelX4.AutoSize = true;
         this.labelX4.BackColor = System.Drawing.Color.Transparent;
         this.labelX4.Location = new System.Drawing.Point( 8, 85 );
         this.labelX4.Name = "labelX4";
         this.labelX4.Size = new System.Drawing.Size( 222, 15 );
         this.labelX4.TabIndex = 7;
         this.labelX4.Text = "Command execution timeout (0 = no timeout)";
         // 
         // labelX5
         // 
         this.labelX5.AutoSize = true;
         this.labelX5.BackColor = System.Drawing.Color.Transparent;
         this.labelX5.Location = new System.Drawing.Point( 435, 87 );
         this.labelX5.Name = "labelX5";
         this.labelX5.Size = new System.Drawing.Size( 20, 15 );
         this.labelX5.TabIndex = 21;
         this.labelX5.Text = "sec";
         // 
         // textCommandTimeout
         // 
         // 
         // 
         // 
         this.textCommandTimeout.Border.Class = "TextBoxBorder";
         this.textCommandTimeout.Location = new System.Drawing.Point( 380, 83 );
         this.textCommandTimeout.MaxLength = 4;
         this.textCommandTimeout.Name = "textCommandTimeout";
         this.textCommandTimeout.Size = new System.Drawing.Size( 50, 20 );
         this.textCommandTimeout.TabIndex = 8;
         this.textCommandTimeout.Text = "30";
         // 
         // textThreads
         // 
         // 
         // 
         // 
         this.textThreads.Border.Class = "TextBoxBorder";
         this.textThreads.Location = new System.Drawing.Point( 379, 56 );
         this.textThreads.MaxLength = 2;
         this.textThreads.Name = "textThreads";
         this.textThreads.Size = new System.Drawing.Size( 50, 20 );
         this.textThreads.TabIndex = 6;
         this.textThreads.Text = "10";
         // 
         // textTextSize
         // 
         // 
         // 
         // 
         this.textTextSize.Border.Class = "TextBoxBorder";
         this.textTextSize.Location = new System.Drawing.Point( 379, 30 );
         this.textTextSize.MaxLength = 7;
         this.textTextSize.Name = "textTextSize";
         this.textTextSize.Size = new System.Drawing.Size( 50, 20 );
         this.textTextSize.TabIndex = 4;
         this.textTextSize.Text = "8192";
         // 
         // textRowCount
         // 
         // 
         // 
         // 
         this.textRowCount.Border.Class = "TextBoxBorder";
         this.textRowCount.Location = new System.Drawing.Point( 379, 4 );
         this.textRowCount.MaxLength = 6;
         this.textRowCount.Name = "textRowCount";
         this.textRowCount.Size = new System.Drawing.Size( 50, 20 );
         this.textRowCount.TabIndex = 2;
         this.textRowCount.Text = "1000";
         // 
         // Form_QueryOptions
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size( 483, 285 );
         this.Controls.Add( this.btnCancel );
         this.Controls.Add( this.btnOK );
         this.Controls.Add( this.groupPanel1 );
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form_QueryOptions";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Query Options";
         this.groupPanel1.ResumeLayout( false );
         this.groupPanel1.PerformLayout();
         this.groupPanel3.ResumeLayout( false );
         this.groupPanel3.PerformLayout();
         this.groupPanel2.ResumeLayout( false );
         this.groupPanel2.PerformLayout();
         this.ResumeLayout( false );

      }

      #endregion

      private DevComponents.DotNetBar.LabelX labelRowcount;
      private Idera.SqlAdminToolset.Core.ToolNumericTextBox textRowCount;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
      private System.Windows.Forms.RadioButton radioText;
      private System.Windows.Forms.RadioButton radioGrid;
      private DevComponents.DotNetBar.LabelX labelX2;
      private Idera.SqlAdminToolset.Core.ToolNumericTextBox textTextSize;
      private DevComponents.DotNetBar.LabelX labelX1;
      private DevComponents.DotNetBar.ButtonX btnCancel;
      private DevComponents.DotNetBar.ButtonX btnOK;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkShowIndividualResults;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkShowCombinedResults;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkShowSummary;
      private Idera.SqlAdminToolset.Core.ToolNumericTextBox textThreads;
      private DevComponents.DotNetBar.LabelX labelX3;
      private Idera.SqlAdminToolset.Core.ToolNumericTextBox textCommandTimeout;
      private DevComponents.DotNetBar.LabelX labelX4;
      private DevComponents.DotNetBar.LabelX labelX5;
   }
}