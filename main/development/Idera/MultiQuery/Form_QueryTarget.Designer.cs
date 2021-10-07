namespace Idera.SqlAdminToolset.MultiQuery
{
   partial class Form_QueryTarget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_QueryTarget));
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.groupAuthentication = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonTestConnection = new DevComponents.DotNetBar.ButtonX();
            this.textPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textLoginName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelPassword = new DevComponents.DotNetBar.LabelX();
            this.labelLoginName = new DevComponents.DotNetBar.LabelX();
            this.labelAuthentication = new DevComponents.DotNetBar.LabelX();
            this.radioSQL = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioWindows = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.textDatabase = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textServerGroup = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.radioGroups = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioServers = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.textServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonBrowseServer = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonBrowseDatabase = new DevComponents.DotNetBar.ButtonX();
            this.radioDefaultDatabase = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioSpecifiedDatabase = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelHelp = new DevComponents.DotNetBar.LabelX();
            this.groupAuthentication.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(424, 395);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "&Cancel";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(343, 395);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupAuthentication
            // 
            this.groupAuthentication.BackColor = System.Drawing.Color.Transparent;
            this.groupAuthentication.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupAuthentication.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupAuthentication.Controls.Add(this.buttonTestConnection);
            this.groupAuthentication.Controls.Add(this.textPassword);
            this.groupAuthentication.Controls.Add(this.textLoginName);
            this.groupAuthentication.Controls.Add(this.labelPassword);
            this.groupAuthentication.Controls.Add(this.labelLoginName);
            this.groupAuthentication.Controls.Add(this.labelAuthentication);
            this.groupAuthentication.Controls.Add(this.radioSQL);
            this.groupAuthentication.Controls.Add(this.radioWindows);
            this.groupAuthentication.IsShadowEnabled = true;
            this.groupAuthentication.Location = new System.Drawing.Point(104, 34);
            this.groupAuthentication.Name = "groupAuthentication";
            this.groupAuthentication.Size = new System.Drawing.Size(344, 160);
            // 
            // 
            // 
            this.groupAuthentication.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupAuthentication.Style.BackColorGradientAngle = 90;
            this.groupAuthentication.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupAuthentication.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupAuthentication.Style.BorderBottomWidth = 1;
            this.groupAuthentication.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupAuthentication.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupAuthentication.Style.BorderLeftWidth = 1;
            this.groupAuthentication.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupAuthentication.Style.BorderRightWidth = 1;
            this.groupAuthentication.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupAuthentication.Style.BorderTopWidth = 1;
            this.groupAuthentication.Style.Class = "";
            this.groupAuthentication.Style.CornerDiameter = 4;
            this.groupAuthentication.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupAuthentication.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupAuthentication.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupAuthentication.StyleMouseDown.Class = "";
            this.groupAuthentication.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupAuthentication.StyleMouseOver.Class = "";
            this.groupAuthentication.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupAuthentication.TabIndex = 5;
            this.groupAuthentication.Text = "Authentication Type";
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonTestConnection.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonTestConnection.Enabled = false;
            this.buttonTestConnection.Location = new System.Drawing.Point(13, 112);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(307, 23);
            this.buttonTestConnection.TabIndex = 12;
            this.buttonTestConnection.Text = "Test Connection";
            this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
            // 
            // textPassword
            // 
            // 
            // 
            // 
            this.textPassword.Border.Class = "TextBoxBorder";
            this.textPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textPassword.Enabled = false;
            this.textPassword.Location = new System.Drawing.Point(93, 68);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '●';
            this.textPassword.Size = new System.Drawing.Size(227, 20);
            this.textPassword.TabIndex = 11;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // textLoginName
            // 
            // 
            // 
            // 
            this.textLoginName.Border.Class = "TextBoxBorder";
            this.textLoginName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textLoginName.Enabled = false;
            this.textLoginName.Location = new System.Drawing.Point(93, 35);
            this.textLoginName.Name = "textLoginName";
            this.textLoginName.Size = new System.Drawing.Size(227, 20);
            this.textLoginName.TabIndex = 9;
            // 
            // labelPassword
            // 
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelPassword.BackgroundStyle.Class = "";
            this.labelPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelPassword.Location = new System.Drawing.Point(24, 68);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(65, 17);
            this.labelPassword.TabIndex = 10;
            this.labelPassword.Text = "Password:";
            // 
            // labelLoginName
            // 
            this.labelLoginName.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelLoginName.BackgroundStyle.Class = "";
            this.labelLoginName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelLoginName.Location = new System.Drawing.Point(24, 35);
            this.labelLoginName.Name = "labelLoginName";
            this.labelLoginName.Size = new System.Drawing.Size(65, 17);
            this.labelLoginName.TabIndex = 8;
            this.labelLoginName.Text = "Login name:";
            // 
            // labelAuthentication
            // 
            this.labelAuthentication.BackColor = System.Drawing.Color.Transparent;
            this.labelAuthentication.Location = new System.Drawing.Point(24, 8);
            this.labelAuthentication.Name = "labelAuthentication";
            this.labelAuthentication.Size = new System.Drawing.Size(75, 17);
            this.labelAuthentication.TabIndex = 5;
            this.labelAuthentication.Text = "Authentication:";
            // 
            // radioSQL
            // 
            this.radioSQL.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioSQL.BackgroundStyle.Class = "";
            this.radioSQL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioSQL.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioSQL.Location = new System.Drawing.Point(190, 5);
            this.radioSQL.Name = "radioSQL";
            this.radioSQL.Size = new System.Drawing.Size(100, 21);
            this.radioSQL.TabIndex = 7;
            this.radioSQL.Text = "SQL Server";
            // 
            // radioWindows
            // 
            this.radioWindows.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioWindows.BackgroundStyle.Class = "";
            this.radioWindows.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioWindows.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioWindows.Checked = true;
            this.radioWindows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioWindows.CheckValue = "Y";
            this.radioWindows.Location = new System.Drawing.Point(100, 4);
            this.radioWindows.Name = "radioWindows";
            this.radioWindows.Size = new System.Drawing.Size(77, 23);
            this.radioWindows.TabIndex = 6;
            this.radioWindows.Text = "Windows";
            this.radioWindows.CheckedChanged += new System.EventHandler(this.radioWindows_CheckedChanged);
            // 
            // textDatabase
            // 
            this.textDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textDatabase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.textDatabase.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textDatabase.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textDatabase.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textDatabase.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textDatabase.Border.Class = "TextBoxBorder";
            this.textDatabase.WatermarkText = "Search to filter Databases";
            this.textDatabase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textDatabase.Enabled = false;
            this.textDatabase.Location = new System.Drawing.Point(225, 32);
            this.textDatabase.Name = "textDatabase";
            this.textDatabase.Size = new System.Drawing.Size(225, 20);
            this.textDatabase.TabIndex = 17;
            // 
            // textServerGroup
            // 
            this.textServerGroup.DisplayMember = "Text";
            this.textServerGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.textServerGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textServerGroup.Enabled = false;
            this.textServerGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textServerGroup.FormattingEnabled = true;
            this.textServerGroup.ItemHeight = 14;
            this.textServerGroup.Items.AddRange(new object[] {
            this.comboItem1});
            this.textServerGroup.Location = new System.Drawing.Point(104, 204);
            this.textServerGroup.MaxDropDownItems = 64;
            this.textServerGroup.Name = "textServerGroup";
            this.textServerGroup.Size = new System.Drawing.Size(344, 20);
            this.textServerGroup.TabIndex = 13;
            this.textServerGroup.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.textServerGroup.WatermarkText = "Select a server group";
            this.textServerGroup.DropDown += new System.EventHandler(this.textServerGroup_DropDown);
            this.textServerGroup.SelectedIndexChanged += new System.EventHandler(this.textServerGroup_SelectedIndexChanged);
            this.textServerGroup.TextChanged += new System.EventHandler(this.textServerGroup_TextChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "comboItem1";
            this.comboItem1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem1.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // radioGroups
            // 
            this.radioGroups.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioGroups.BackgroundStyle.Class = "";
            this.radioGroups.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioGroups.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioGroups.Location = new System.Drawing.Point(4, 203);
            this.radioGroups.Name = "radioGroups";
            this.radioGroups.Size = new System.Drawing.Size(96, 21);
            this.radioGroups.TabIndex = 12;
            this.radioGroups.Text = "Server Group:";
            this.radioGroups.CheckedChanged += new System.EventHandler(this.radioGroups_CheckedChanged);
            // 
            // radioServers
            // 
            this.radioServers.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioServers.BackgroundStyle.Class = "";
            this.radioServers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioServers.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioServers.Checked = true;
            this.radioServers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioServers.CheckValue = "Y";
            this.radioServers.Location = new System.Drawing.Point(4, 4);
            this.radioServers.Name = "radioServers";
            this.radioServers.Size = new System.Drawing.Size(95, 21);
            this.radioServers.TabIndex = 2;
            this.radioServers.Text = "SQL Server(s):";
            this.radioServers.CheckedChanged += new System.EventHandler(this.radioServers_CheckedChanged);
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
            this.textServer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textServer.Location = new System.Drawing.Point(104, 6);
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(344, 20);
            this.textServer.TabIndex = 3;
            this.textServer.TextChanged += new System.EventHandler(this.textServer_TextChanged);
            this.textServer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textServer_KeyPress);
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.buttonBrowseServer);
            this.groupPanel3.Controls.Add(this.radioServers);
            this.groupPanel3.Controls.Add(this.textServer);
            this.groupPanel3.Controls.Add(this.textServerGroup);
            this.groupPanel3.Controls.Add(this.groupAuthentication);
            this.groupPanel3.Controls.Add(this.radioGroups);
            this.groupPanel3.IsShadowEnabled = true;
            this.groupPanel3.Location = new System.Drawing.Point(10, 45);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(488, 251);
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
            this.groupPanel3.Style.Class = "";
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.Class = "";
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.Class = "";
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 1;
            this.groupPanel3.Text = "Select a SQL Server or Server Group";
            // 
            // buttonBrowseServer
            // 
            this.buttonBrowseServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseServer.BackColor = System.Drawing.Color.White;
            this.buttonBrowseServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseServer.Location = new System.Drawing.Point(454, 6);
            this.buttonBrowseServer.Name = "buttonBrowseServer";
            this.buttonBrowseServer.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseServer.TabIndex = 4;
            this.buttonBrowseServer.Text = "...";
            this.buttonBrowseServer.Click += new System.EventHandler(this.buttonBrowseServer_Click);
            // 
            // groupPanel4
            // 
            this.groupPanel4.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.buttonBrowseDatabase);
            this.groupPanel4.Controls.Add(this.radioDefaultDatabase);
            this.groupPanel4.Controls.Add(this.radioSpecifiedDatabase);
            this.groupPanel4.Controls.Add(this.textDatabase);
            this.groupPanel4.IsShadowEnabled = true;
            this.groupPanel4.Location = new System.Drawing.Point(8, 304);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(490, 82);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.Class = "";
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.Class = "";
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.Class = "";
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 14;
            this.groupPanel4.Text = "Specify a Database";
            // 
            // buttonBrowseDatabase
            // 
            this.buttonBrowseDatabase.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonBrowseDatabase.BackColor = System.Drawing.Color.White;
            this.buttonBrowseDatabase.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonBrowseDatabase.Location = new System.Drawing.Point(456, 32);
            this.buttonBrowseDatabase.Name = "buttonBrowseDatabase";
            this.buttonBrowseDatabase.Size = new System.Drawing.Size(20, 20);
            this.buttonBrowseDatabase.TabIndex = 18;
            this.buttonBrowseDatabase.Text = "...";
            this.buttonBrowseDatabase.Click += new System.EventHandler(this.buttonBrowseDatabase_Click);
            // 
            // radioDefaultDatabase
            // 
            this.radioDefaultDatabase.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioDefaultDatabase.BackgroundStyle.Class = "";
            this.radioDefaultDatabase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioDefaultDatabase.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioDefaultDatabase.Checked = true;
            this.radioDefaultDatabase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioDefaultDatabase.CheckValue = "Y";
            this.radioDefaultDatabase.Location = new System.Drawing.Point(4, 4);
            this.radioDefaultDatabase.Name = "radioDefaultDatabase";
            this.radioDefaultDatabase.Size = new System.Drawing.Size(182, 21);
            this.radioDefaultDatabase.TabIndex = 15;
            this.radioDefaultDatabase.Text = "Connect using default database";
            this.radioDefaultDatabase.CheckedChanged += new System.EventHandler(this.radioDefaultDatabase_CheckedChanged);
            // 
            // radioSpecifiedDatabase
            // 
            this.radioSpecifiedDatabase.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.radioSpecifiedDatabase.BackgroundStyle.Class = "";
            this.radioSpecifiedDatabase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioSpecifiedDatabase.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.radioSpecifiedDatabase.Location = new System.Drawing.Point(4, 30);
            this.radioSpecifiedDatabase.Name = "radioSpecifiedDatabase";
            this.radioSpecifiedDatabase.Size = new System.Drawing.Size(224, 21);
            this.radioSpecifiedDatabase.TabIndex = 16;
            this.radioSpecifiedDatabase.Text = "Connect using the following database(s):";
            // 
            // labelHelp
            // 
            // 
            // 
            // 
            this.labelHelp.BackgroundStyle.Class = "";
            this.labelHelp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelHelp.Location = new System.Drawing.Point(11, 8);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(488, 27);
            this.labelHelp.TabIndex = 0;
            this.labelHelp.Text = "Specify a query target by selecting the server and database to which to connect a" +
    "nd the type of authentication to use for the connection. Use semi-colons to sepa" +
    "rate multiple servers or databases.";
            this.labelHelp.WordWrap = true;
            // 
            // Form_QueryTarget
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(508, 425);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupPanel4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_QueryTarget";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Query Target";
            this.groupAuthentication.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX btnCancel;
      private DevComponents.DotNetBar.ButtonX btnOK;
      private DevComponents.DotNetBar.Controls.GroupPanel groupAuthentication;
      private DevComponents.DotNetBar.Controls.TextBoxX textPassword;
      private DevComponents.DotNetBar.Controls.TextBoxX textLoginName;
      private DevComponents.DotNetBar.LabelX labelPassword;
      private DevComponents.DotNetBar.LabelX labelLoginName;
        private DevComponents.DotNetBar.LabelX labelAuthentication;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioSQL;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioWindows;
      private DevComponents.DotNetBar.Controls.TextBoxX textDatabase;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioGroups;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioServers;
      private DevComponents.Editors.ComboItem comboItem1;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
      private DevComponents.DotNetBar.Controls.TextBoxX textServer;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioDefaultDatabase;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioSpecifiedDatabase;
      private DevComponents.DotNetBar.LabelX labelHelp;
      private DevComponents.DotNetBar.ButtonX buttonBrowseServer;
      private DevComponents.DotNetBar.ButtonX buttonTestConnection;
      private DevComponents.DotNetBar.ButtonX buttonBrowseDatabase;
        private DevComponents.DotNetBar.Controls.ComboBoxEx textServerGroup;
    }
}