namespace Idera.SqlAdminToolset.Core
{
   partial class Wiz_AddServerToGroup
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Wiz_AddServerToGroup ) );
         this.wizard1 = new DevComponents.DotNetBar.Wizard();
         this.pageWelcome = new DevComponents.DotNetBar.WizardPage();
         this.reflectionImage2 = new DevComponents.DotNetBar.Controls.ReflectionImage();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.pageGroup = new DevComponents.DotNetBar.WizardPage();
         this.labelX1 = new DevComponents.DotNetBar.LabelX();
         this.textServerGroup = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.labelPrompt = new DevComponents.DotNetBar.LabelX();
         this.treeServerGroups = new System.Windows.Forms.TreeView();
         this.pageServers = new DevComponents.DotNetBar.WizardPage();
         this.labelLicenseKey = new DevComponents.DotNetBar.LabelX();
         this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.textPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.textLoginName = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.labelPassword = new DevComponents.DotNetBar.LabelX();
         this.labelLoginName = new DevComponents.DotNetBar.LabelX();
         this.radioSQL = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.radioWindows = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.textServer = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.wizard1.SuspendLayout();
         this.pageWelcome.SuspendLayout();
         this.pageGroup.SuspendLayout();
         this.pageServers.SuspendLayout();
         this.groupPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // wizard1
         // 
         this.wizard1.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(205)))), ((int)(((byte)(229)))), ((int)(((byte)(253)))) );
         this.wizard1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject( "wizard1.BackgroundImage" )));
         this.wizard1.ButtonStyle = DevComponents.DotNetBar.eWizardStyle.Office2007;
         this.wizard1.Cursor = System.Windows.Forms.Cursors.Default;
         this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.wizard1.FinishButtonTabIndex = 3;
         // 
         // 
         // 
         this.wizard1.FooterStyle.BackColor = System.Drawing.Color.Transparent;
         this.wizard1.ForeColor = System.Drawing.Color.FromArgb( ((int)(((byte)(15)))), ((int)(((byte)(57)))), ((int)(((byte)(129)))) );
         this.wizard1.HeaderCaptionFont = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold );
         this.wizard1.HeaderDescriptionVisible = false;
         this.wizard1.HeaderHeight = 90;
         this.wizard1.HeaderImageAlignment = DevComponents.DotNetBar.eWizardTitleImageAlignment.Left;
         this.wizard1.HeaderImageSize = new System.Drawing.Size( 48, 48 );
         this.wizard1.HeaderImageVisible = false;
         // 
         // 
         // 
         this.wizard1.HeaderStyle.BackColor = System.Drawing.Color.Transparent;
         this.wizard1.HeaderStyle.BackColorGradientAngle = 90;
         this.wizard1.HeaderStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.wizard1.HeaderStyle.BorderBottomColor = System.Drawing.Color.FromArgb( ((int)(((byte)(121)))), ((int)(((byte)(157)))), ((int)(((byte)(182)))) );
         this.wizard1.HeaderStyle.BorderBottomWidth = 1;
         this.wizard1.HeaderStyle.BorderColor = System.Drawing.SystemColors.Control;
         this.wizard1.HeaderStyle.BorderLeftWidth = 1;
         this.wizard1.HeaderStyle.BorderRightWidth = 1;
         this.wizard1.HeaderStyle.BorderTopWidth = 1;
         this.wizard1.HeaderStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
         this.wizard1.HeaderStyle.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
         this.wizard1.HeaderTitleIndent = 62;
         this.wizard1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
         this.wizard1.Location = new System.Drawing.Point( 0, 0 );
         this.wizard1.Name = "wizard1";
         this.wizard1.Size = new System.Drawing.Size( 652, 411 );
         this.wizard1.TabIndex = 0;
         this.wizard1.WizardPages.AddRange( new DevComponents.DotNetBar.WizardPage[] {
            this.pageWelcome,
            this.pageGroup,
            this.pageServers} );
         // 
         // pageWelcome
         // 
         this.pageWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.pageWelcome.BackColor = System.Drawing.Color.Transparent;
         this.pageWelcome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
         this.pageWelcome.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.pageWelcome.Controls.Add( this.reflectionImage2 );
         this.pageWelcome.Controls.Add( this.label1 );
         this.pageWelcome.Controls.Add( this.label2 );
         this.pageWelcome.Controls.Add( this.label3 );
         this.pageWelcome.InteriorPage = false;
         this.pageWelcome.Location = new System.Drawing.Point( 0, 0 );
         this.pageWelcome.Name = "pageWelcome";
         this.pageWelcome.Size = new System.Drawing.Size( 652, 365 );
         this.pageWelcome.TabIndex = 7;
         // 
         // reflectionImage2
         // 
         // 
         // 
         // 
         this.reflectionImage2.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
         this.reflectionImage2.Image = ((System.Drawing.Image)(resources.GetObject( "reflectionImage2.Image" )));
         this.reflectionImage2.Location = new System.Drawing.Point( -12, 100 );
         this.reflectionImage2.Name = "reflectionImage2";
         this.reflectionImage2.Size = new System.Drawing.Size( 218, 206 );
         this.reflectionImage2.TabIndex = 20;
         // 
         // label1
         // 
         this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.label1.BackColor = System.Drawing.Color.Transparent;
         this.label1.Font = new System.Drawing.Font( "Tahoma", 16F );
         this.label1.Location = new System.Drawing.Point( 185, 18 );
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size( 453, 66 );
         this.label1.TabIndex = 0;
         this.label1.Text = "Welcome to the Create Server Group Wizard";
         // 
         // label2
         // 
         this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.label2.BackColor = System.Drawing.Color.Transparent;
         this.label2.Location = new System.Drawing.Point( 210, 100 );
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size( 427, 233 );
         this.label2.TabIndex = 1;
         this.label2.Text = resources.GetString( "label2.Text" );
         // 
         // label3
         // 
         this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label3.BackColor = System.Drawing.Color.Transparent;
         this.label3.Location = new System.Drawing.Point( 210, 342 );
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size( 120, 13 );
         this.label3.TabIndex = 2;
         this.label3.Text = "To continue, click Next.";
         // 
         // pageGroup
         // 
         this.pageGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.pageGroup.AntiAlias = false;
         this.pageGroup.BackColor = System.Drawing.Color.Transparent;
         this.pageGroup.Controls.Add( this.labelX1 );
         this.pageGroup.Controls.Add( this.textServerGroup );
         this.pageGroup.Controls.Add( this.labelPrompt );
         this.pageGroup.Controls.Add( this.treeServerGroups );
         this.pageGroup.Location = new System.Drawing.Point( 7, 102 );
         this.pageGroup.Name = "pageGroup";
         this.pageGroup.PageDescription = "< Wizard step description >";
         this.pageGroup.PageTitle = "< Wizard step title >";
         this.pageGroup.Size = new System.Drawing.Size( 638, 251 );
         this.pageGroup.TabIndex = 8;
         // 
         // labelX1
         // 
         this.labelX1.BackColor = System.Drawing.Color.Transparent;
         this.labelX1.Location = new System.Drawing.Point( 85, 18 );
         this.labelX1.Name = "labelX1";
         this.labelX1.Size = new System.Drawing.Size( 71, 15 );
         this.labelX1.TabIndex = 4;
         this.labelX1.Text = "Server Group:";
         // 
         // textServerGroup
         // 
         // 
         // 
         // 
         this.textServerGroup.Border.Class = "TextBoxBorder";
         this.textServerGroup.Location = new System.Drawing.Point( 162, 15 );
         this.textServerGroup.Name = "textServerGroup";
         this.textServerGroup.Size = new System.Drawing.Size( 389, 20 );
         this.textServerGroup.TabIndex = 5;
         // 
         // labelPrompt
         // 
         this.labelPrompt.AutoSize = true;
         this.labelPrompt.BackColor = System.Drawing.Color.Transparent;
         this.labelPrompt.Location = new System.Drawing.Point( 85, 53 );
         this.labelPrompt.Name = "labelPrompt";
         this.labelPrompt.Size = new System.Drawing.Size( 208, 15 );
         this.labelPrompt.TabIndex = 6;
         this.labelPrompt.Text = "Select a location for the new server group:";
         // 
         // treeServerGroups
         // 
         this.treeServerGroups.HideSelection = false;
         this.treeServerGroups.Location = new System.Drawing.Point( 85, 72 );
         this.treeServerGroups.Name = "treeServerGroups";
         this.treeServerGroups.Size = new System.Drawing.Size( 466, 206 );
         this.treeServerGroups.TabIndex = 7;
         // 
         // pageServers
         // 
         this.pageServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.pageServers.AntiAlias = false;
         this.pageServers.BackColor = System.Drawing.Color.Transparent;
         this.pageServers.Controls.Add( this.labelLicenseKey );
         this.pageServers.Controls.Add( this.groupPanel1 );
         this.pageServers.Controls.Add( this.textServer );
         this.pageServers.Location = new System.Drawing.Point( 7, 102 );
         this.pageServers.Name = "pageServers";
         this.pageServers.PageDescription = "< Wizard step description >";
         this.pageServers.PageTitle = "< Wizard step title >";
         this.pageServers.Size = new System.Drawing.Size( 638, 251 );
         this.pageServers.TabIndex = 9;
         // 
         // labelLicenseKey
         // 
         this.labelLicenseKey.BackColor = System.Drawing.Color.Transparent;
         this.labelLicenseKey.Location = new System.Drawing.Point( 106, 60 );
         this.labelLicenseKey.Name = "labelLicenseKey";
         this.labelLicenseKey.Size = new System.Drawing.Size( 79, 15 );
         this.labelLicenseKey.TabIndex = 5;
         this.labelLicenseKey.Text = "SQL Server(s):";
         // 
         // groupPanel1
         // 
         this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
         this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel1.Controls.Add( this.textPassword );
         this.groupPanel1.Controls.Add( this.textLoginName );
         this.groupPanel1.Controls.Add( this.labelPassword );
         this.groupPanel1.Controls.Add( this.labelLoginName );
         this.groupPanel1.Controls.Add( this.radioSQL );
         this.groupPanel1.Controls.Add( this.radioWindows );
         this.groupPanel1.Location = new System.Drawing.Point( 191, 89 );
         this.groupPanel1.Name = "groupPanel1";
         this.groupPanel1.Size = new System.Drawing.Size( 342, 132 );
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
         this.groupPanel1.TabIndex = 7;
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
         this.textPassword.TabIndex = 8;
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
         this.labelPassword.TabIndex = 3;
         this.labelPassword.Text = "Password:";
         // 
         // labelLoginName
         // 
         this.labelLoginName.BackColor = System.Drawing.Color.Transparent;
         this.labelLoginName.Location = new System.Drawing.Point( 22, 55 );
         this.labelLoginName.Name = "labelLoginName";
         this.labelLoginName.Size = new System.Drawing.Size( 65, 17 );
         this.labelLoginName.TabIndex = 2;
         this.labelLoginName.Text = "Login name:";
         // 
         // radioSQL
         // 
         this.radioSQL.BackColor = System.Drawing.Color.Transparent;
         this.radioSQL.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
         this.radioSQL.Location = new System.Drawing.Point( 3, 31 );
         this.radioSQL.Name = "radioSQL";
         this.radioSQL.Size = new System.Drawing.Size( 290, 21 );
         this.radioSQL.TabIndex = 6;
         this.radioSQL.Text = "SQL Server Authentication";
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
         this.radioWindows.TabIndex = 5;
         this.radioWindows.Text = "Windows Authentication (Used for trusted connections)";
         // 
         // textServer
         // 
         // 
         // 
         // 
         this.textServer.Border.Class = "TextBoxBorder";
         this.textServer.Location = new System.Drawing.Point( 191, 59 );
         this.textServer.Multiline = true;
         this.textServer.Name = "textServer";
         this.textServer.Size = new System.Drawing.Size( 342, 21 );
         this.textServer.TabIndex = 6;
         this.textServer.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
         this.textServer.WatermarkText = "Enter one or more SQL Servers separated by semi-colons";
         // 
         // Wiz_AddServerToGroup
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size( 652, 411 );
         this.Controls.Add( this.wizard1 );
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.Name = "Wiz_AddServerToGroup";
         this.ShowInTaskbar = false;
         this.Text = "Create Server Group";
         this.wizard1.ResumeLayout( false );
         this.pageWelcome.ResumeLayout( false );
         this.pageGroup.ResumeLayout( false );
         this.pageGroup.PerformLayout();
         this.pageServers.ResumeLayout( false );
         this.groupPanel1.ResumeLayout( false );
         this.ResumeLayout( false );

      }

      #endregion

      private DevComponents.DotNetBar.Wizard wizard1;
      private DevComponents.DotNetBar.WizardPage pageWelcome;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private DevComponents.DotNetBar.WizardPage pageGroup;
      private DevComponents.DotNetBar.WizardPage pageServers;
      private DevComponents.DotNetBar.LabelX labelX1;
      private DevComponents.DotNetBar.Controls.TextBoxX textServerGroup;
      private DevComponents.DotNetBar.LabelX labelPrompt;
      private System.Windows.Forms.TreeView treeServerGroups;
      private DevComponents.DotNetBar.LabelX labelLicenseKey;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.Controls.TextBoxX textPassword;
      private DevComponents.DotNetBar.Controls.TextBoxX textLoginName;
      private DevComponents.DotNetBar.LabelX labelPassword;
      private DevComponents.DotNetBar.LabelX labelLoginName;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioSQL;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioWindows;
      private DevComponents.DotNetBar.Controls.TextBoxX textServer;
      private DevComponents.DotNetBar.Controls.ReflectionImage reflectionImage2;
   }
}