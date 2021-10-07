namespace Idera.SqlAdminToolset.ServerPing
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
         this.btnCancel = new DevComponents.DotNetBar.ButtonX();
         this.btnOK = new DevComponents.DotNetBar.ButtonX();
         this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.checkQuery = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.textQuery = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.radioSQL = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.radioWmi = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.checkBoxWarnOnExit = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.groupPanel2.SuspendLayout();
         this.groupPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnCancel
         // 
         this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point( 512, 249 );
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
         this.btnCancel.TabIndex = 6;
         this.btnCancel.Text = "&Cancel";
         // 
         // btnOK
         // 
         this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnOK.Location = new System.Drawing.Point( 431, 249 );
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size( 75, 23 );
         this.btnOK.TabIndex = 5;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler( this.btnOK_Click );
         // 
         // groupPanel2
         // 
         this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
         this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel2.Controls.Add( this.checkQuery );
         this.groupPanel2.Controls.Add( this.textQuery );
         this.groupPanel2.Controls.Add( this.radioSQL );
         this.groupPanel2.Controls.Add( this.radioWmi );
         this.groupPanel2.Location = new System.Drawing.Point( 8, 8 );
         this.groupPanel2.Name = "groupPanel2";
         this.groupPanel2.Size = new System.Drawing.Size( 579, 169 );
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
         this.groupPanel2.Text = "Specify Detection Method";
         // 
         // checkQuery
         // 
         this.checkQuery.AutoSize = true;
         this.checkQuery.Enabled = false;
         this.checkQuery.Location = new System.Drawing.Point( 22, 60 );
         this.checkQuery.Name = "checkQuery";
         this.checkQuery.Size = new System.Drawing.Size( 291, 15 );
         this.checkQuery.TabIndex = 3;
         this.checkQuery.Text = "Run the following query after establishing a connection:";
         this.checkQuery.CheckedChanged += new System.EventHandler( this.checkQuery_CheckedChanged );
         // 
         // textQuery
         // 
         // 
         // 
         // 
         this.textQuery.Border.Class = "TextBoxBorder";
         this.textQuery.Enabled = false;
         this.textQuery.Location = new System.Drawing.Point( 44, 81 );
         this.textQuery.Multiline = true;
         this.textQuery.Name = "textQuery";
         this.textQuery.Size = new System.Drawing.Size( 525, 58 );
         this.textQuery.TabIndex = 4;
         this.textQuery.Text = "SELECT @@VERSION";
         this.textQuery.UseSystemPasswordChar = true;
         // 
         // radioSQL
         // 
         this.radioSQL.BackColor = System.Drawing.Color.Transparent;
         this.radioSQL.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
         this.radioSQL.Location = new System.Drawing.Point( 3, 33 );
         this.radioSQL.Name = "radioSQL";
         this.radioSQL.Size = new System.Drawing.Size( 371, 21 );
         this.radioSQL.TabIndex = 2;
         this.radioSQL.Text = "SQL Connection - Open a connection to the monitored SQL Server.";
         // 
         // radioWmi
         // 
         this.radioWmi.AutoSize = true;
         this.radioWmi.BackColor = System.Drawing.Color.Transparent;
         this.radioWmi.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
         this.radioWmi.Checked = true;
         this.radioWmi.CheckState = System.Windows.Forms.CheckState.Checked;
         this.radioWmi.CheckValue = "Y";
         this.radioWmi.Location = new System.Drawing.Point( 3, 8 );
         this.radioWmi.Name = "radioWmi";
         this.radioWmi.Size = new System.Drawing.Size( 566, 15 );
         this.radioWmi.TabIndex = 1;
         this.radioWmi.Text = "WMI - Use a WMI query to check if SQL Server service is running. Requires permiss" +
             "ion to perform WMI queries.";
         this.radioWmi.CheckedChanged += new System.EventHandler( this.radioWindows_CheckedChanged );
         // 
         // groupPanel1
         // 
         this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
         this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel1.Controls.Add( this.checkBoxWarnOnExit );
         this.groupPanel1.Location = new System.Drawing.Point( 8, 184 );
         this.groupPanel1.Name = "groupPanel1";
         this.groupPanel1.Size = new System.Drawing.Size( 579, 50 );
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
         this.groupPanel1.TabIndex = 5;
         this.groupPanel1.Text = "General Options";
         // 
         // checkBoxWarnOnExit
         // 
         this.checkBoxWarnOnExit.AutoSize = true;
         this.checkBoxWarnOnExit.Location = new System.Drawing.Point( 3, 8 );
         this.checkBoxWarnOnExit.Name = "checkBoxWarnOnExit";
         this.checkBoxWarnOnExit.Size = new System.Drawing.Size( 373, 15 );
         this.checkBoxWarnOnExit.TabIndex = 6;
         this.checkBoxWarnOnExit.Text = "On Close, show warning that program will continue to run in system tray.";
         // 
         // Form_Options
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size( 594, 278 );
         this.Controls.Add( this.groupPanel1 );
         this.Controls.Add( this.groupPanel2 );
         this.Controls.Add( this.btnCancel );
         this.Controls.Add( this.btnOK );
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form_Options";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Server Ping Options";
         this.groupPanel2.ResumeLayout( false );
         this.groupPanel2.PerformLayout();
         this.groupPanel1.ResumeLayout( false );
         this.groupPanel1.PerformLayout();
         this.ResumeLayout( false );

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX btnCancel;
      private DevComponents.DotNetBar.ButtonX btnOK;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
      private DevComponents.DotNetBar.Controls.TextBoxX textQuery;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioSQL;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioWmi;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkQuery;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxWarnOnExit;
   }
}