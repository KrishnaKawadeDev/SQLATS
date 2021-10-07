namespace Idera.SqlAdminToolset.Core
{
   partial class Form_Connect
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_Connect ) );
         this.buttonBrowseServer = new DevComponents.DotNetBar.ButtonX();
         this.textServer = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.labelServer = new DevComponents.DotNetBar.LabelX();
         this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.textPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.textLoginName = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.labelPassword = new DevComponents.DotNetBar.LabelX();
         this.labelLoginName = new DevComponents.DotNetBar.LabelX();
         this.radioSQL = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.radioWindows = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.btnCancel = new DevComponents.DotNetBar.ButtonX();
         this.btnOK = new DevComponents.DotNetBar.ButtonX();
         this.buttonTestConnection = new DevComponents.DotNetBar.ButtonX();
         this.toolTip = new System.Windows.Forms.ToolTip( this.components );
         this.groupPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonBrowseServer
         // 
         this.buttonBrowseServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonBrowseServer.BackColor = System.Drawing.Color.White;
         this.buttonBrowseServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonBrowseServer.Location = new System.Drawing.Point( 445, 14 );
         this.buttonBrowseServer.Name = "buttonBrowseServer";
         this.buttonBrowseServer.Size = new System.Drawing.Size( 20, 20 );
         this.buttonBrowseServer.TabIndex = 2;
         this.buttonBrowseServer.Text = "...";
         this.buttonBrowseServer.Click += new System.EventHandler( this.buttonBrowseServer_Click );
         // 
         // textServer
         // 
         // 
         // 
         // 
         this.textServer.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textServer.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textServer.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textServer.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textServer.Border.Class = "TextBoxBorder";
         this.textServer.Location = new System.Drawing.Point( 79, 14 );
         this.textServer.Name = "textServer";
         this.textServer.Size = new System.Drawing.Size( 360, 20 );
         this.textServer.TabIndex = 1;
         this.textServer.WatermarkText = "SQL Server name";
         this.textServer.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.textServer_KeyPress );
         this.textServer.TextChanged += new System.EventHandler( this.textServer_TextChanged );
         // 
         // labelServer
         // 
         this.labelServer.BackColor = System.Drawing.Color.Transparent;
         this.labelServer.Location = new System.Drawing.Point( 12, 18 );
         this.labelServer.Name = "labelServer";
         this.labelServer.Size = new System.Drawing.Size( 68, 12 );
         this.labelServer.TabIndex = 0;
         this.labelServer.Text = "&SQL Server:";
         // 
         // groupPanel1
         // 
         this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel1.Controls.Add( this.textPassword );
         this.groupPanel1.Controls.Add( this.textLoginName );
         this.groupPanel1.Controls.Add( this.labelPassword );
         this.groupPanel1.Controls.Add( this.labelLoginName );
         this.groupPanel1.Controls.Add( this.radioSQL );
         this.groupPanel1.Controls.Add( this.radioWindows );
         this.groupPanel1.Location = new System.Drawing.Point( 12, 46 );
         this.groupPanel1.Name = "groupPanel1";
         this.groupPanel1.Size = new System.Drawing.Size( 453, 132 );
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
         this.groupPanel1.TabIndex = 3;
         this.groupPanel1.Text = "Specify Type of Authentication";
         // 
         // textPassword
         // 
         // 
         // 
         // 
         this.textPassword.Border.Class = "TextBoxBorder";
         this.textPassword.Enabled = false;
         this.textPassword.Location = new System.Drawing.Point( 93, 79 );
         this.textPassword.Name = "textPassword";
         this.textPassword.Size = new System.Drawing.Size( 227, 20 );
         this.textPassword.TabIndex = 9;
         this.textPassword.UseSystemPasswordChar = true;
         // 
         // textLoginName
         // 
         // 
         // 
         // 
         this.textLoginName.Border.Class = "TextBoxBorder";
         this.textLoginName.Enabled = false;
         this.textLoginName.Location = new System.Drawing.Point( 93, 55 );
         this.textLoginName.Name = "textLoginName";
         this.textLoginName.Size = new System.Drawing.Size( 227, 20 );
         this.textLoginName.TabIndex = 7;
         // 
         // labelPassword
         // 
         this.labelPassword.BackColor = System.Drawing.Color.Transparent;
         this.labelPassword.Location = new System.Drawing.Point( 22, 79 );
         this.labelPassword.Name = "labelPassword";
         this.labelPassword.Size = new System.Drawing.Size( 65, 17 );
         this.labelPassword.TabIndex = 8;
         this.labelPassword.Text = "Password:";
         // 
         // labelLoginName
         // 
         this.labelLoginName.BackColor = System.Drawing.Color.Transparent;
         this.labelLoginName.Location = new System.Drawing.Point( 22, 55 );
         this.labelLoginName.Name = "labelLoginName";
         this.labelLoginName.Size = new System.Drawing.Size( 65, 17 );
         this.labelLoginName.TabIndex = 6;
         this.labelLoginName.Text = "Login name:";
         // 
         // radioSQL
         // 
         this.radioSQL.BackColor = System.Drawing.Color.Transparent;
         this.radioSQL.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
         this.radioSQL.Location = new System.Drawing.Point( 3, 31 );
         this.radioSQL.Name = "radioSQL";
         this.radioSQL.Size = new System.Drawing.Size( 290, 21 );
         this.radioSQL.TabIndex = 5;
         this.radioSQL.Text = "SQL Server Authentication";
         this.radioSQL.CheckedChanged += new System.EventHandler( this.radioSQLorWindows_CheckedChanged );
         // 
         // radioWindows
         // 
         this.radioWindows.BackColor = System.Drawing.Color.Transparent;
         this.radioWindows.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
         this.radioWindows.Checked = true;
         this.radioWindows.CheckState = System.Windows.Forms.CheckState.Checked;
         this.radioWindows.CheckValue = "Y";
         this.radioWindows.Location = new System.Drawing.Point( 3, 6 );
         this.radioWindows.Name = "radioWindows";
         this.radioWindows.Size = new System.Drawing.Size( 317, 23 );
         this.radioWindows.TabIndex = 4;
         this.radioWindows.Text = "Windows Authentication (Used for trusted connections)";
         this.radioWindows.CheckedChanged += new System.EventHandler( this.radioSQLorWindows_CheckedChanged );
         // 
         // btnCancel
         // 
         this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point( 390, 188 );
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
         this.btnCancel.TabIndex = 31;
         this.btnCancel.Text = "&Cancel";
         // 
         // btnOK
         // 
         this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnOK.Enabled = false;
         this.btnOK.Location = new System.Drawing.Point( 309, 188 );
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size( 75, 23 );
         this.btnOK.TabIndex = 30;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler( this.btnOK_Click );
         // 
         // buttonTestConnection
         // 
         this.buttonTestConnection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonTestConnection.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonTestConnection.Enabled = false;
         this.buttonTestConnection.Location = new System.Drawing.Point( 12, 188 );
         this.buttonTestConnection.Name = "buttonTestConnection";
         this.buttonTestConnection.Size = new System.Drawing.Size( 100, 23 );
         this.buttonTestConnection.TabIndex = 29;
         this.buttonTestConnection.Text = "Test Connection";
         this.buttonTestConnection.Click += new System.EventHandler( this.buttonTestConnection_Click );
         // 
         // Form_Connect
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size( 476, 220 );
         this.Controls.Add( this.buttonTestConnection );
         this.Controls.Add( this.btnCancel );
         this.Controls.Add( this.btnOK );
         this.Controls.Add( this.groupPanel1 );
         this.Controls.Add( this.buttonBrowseServer );
         this.Controls.Add( this.textServer );
         this.Controls.Add( this.labelServer );
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form_Connect";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Connect to Server";
         this.groupPanel1.ResumeLayout( false );
         this.ResumeLayout( false );

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX buttonBrowseServer;
      private DevComponents.DotNetBar.Controls.TextBoxX textServer;
      private DevComponents.DotNetBar.LabelX labelServer;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.Controls.TextBoxX textPassword;
      private DevComponents.DotNetBar.Controls.TextBoxX textLoginName;
      private DevComponents.DotNetBar.LabelX labelPassword;
      private DevComponents.DotNetBar.LabelX labelLoginName;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioSQL;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioWindows;
      private DevComponents.DotNetBar.ButtonX btnCancel;
      private DevComponents.DotNetBar.ButtonX btnOK;
      private DevComponents.DotNetBar.ButtonX buttonTestConnection;
      private System.Windows.Forms.ToolTip toolTip;
   }
}