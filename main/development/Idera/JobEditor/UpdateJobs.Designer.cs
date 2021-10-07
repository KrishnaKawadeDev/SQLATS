namespace Idera.SqlAdminToolset.JobEditor
{
   partial class UpdateJobs
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
         this.labelSelection = new DevComponents.DotNetBar.LabelX();
         this.buttonOk = new DevComponents.DotNetBar.ButtonX();
         this.groupPanelValues = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.checkBoxCreateCategory = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.groupPanelNotifications = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.comboBoxNetSendOperator = new DevComponents.DotNetBar.Controls.ComboBoxEx();
         this.comboItem10 = new DevComponents.Editors.ComboItem();
         this.comboBoxPageOperator = new DevComponents.DotNetBar.Controls.ComboBoxEx();
         this.comboItem9 = new DevComponents.Editors.ComboItem();
         this.comboBoxEmailOperator = new DevComponents.DotNetBar.Controls.ComboBoxEx();
         this.comboItem8 = new DevComponents.Editors.ComboItem();
         this.labelOperator = new DevComponents.DotNetBar.LabelX();
         this.labelLevel = new DevComponents.DotNetBar.LabelX();
         this.comboBoxEventLogLevel = new DevComponents.DotNetBar.Controls.ComboBoxEx();
         this.comboItem6 = new DevComponents.Editors.ComboItem();
         this.labelEventLog = new DevComponents.DotNetBar.LabelX();
         this.comboBoxPageLevel = new DevComponents.DotNetBar.Controls.ComboBoxEx();
         this.comboItem5 = new DevComponents.Editors.ComboItem();
         this.labelPage = new DevComponents.DotNetBar.LabelX();
         this.comboBoxNetSendLevel = new DevComponents.DotNetBar.Controls.ComboBoxEx();
         this.comboItem4 = new DevComponents.Editors.ComboItem();
         this.labelNetSend = new DevComponents.DotNetBar.LabelX();
         this.comboBoxEmailLevel = new DevComponents.DotNetBar.Controls.ComboBoxEx();
         this.comboItem7 = new DevComponents.Editors.ComboItem();
         this.labelEmail = new DevComponents.DotNetBar.LabelX();
         this.comboBoxOwner = new DevComponents.DotNetBar.Controls.ComboBoxEx();
         this.comboItem3 = new DevComponents.Editors.ComboItem();
         this.labelOwner = new DevComponents.DotNetBar.LabelX();
         this.comboBoxEnabled = new DevComponents.DotNetBar.Controls.ComboBoxEx();
         this.comboItem2 = new DevComponents.Editors.ComboItem();
         this.labelEnabled = new DevComponents.DotNetBar.LabelX();
         this.comboBoxCategory = new DevComponents.DotNetBar.Controls.ComboBoxEx();
         this.comboItem1 = new DevComponents.Editors.ComboItem();
         this.labelCategory = new DevComponents.DotNetBar.LabelX();
         this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
         this.groupPanelJobs = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.listViewJobs = new DevComponents.DotNetBar.Controls.ListViewEx();
         this.columnServer = new System.Windows.Forms.ColumnHeader();
         this.columnJobName = new System.Windows.Forms.ColumnHeader();
         this.columnEnabled = new System.Windows.Forms.ColumnHeader();
         this.columnCategory = new System.Windows.Forms.ColumnHeader();
         this.columnOwner = new System.Windows.Forms.ColumnHeader();
         this.columnNotifyLevelEventLog = new System.Windows.Forms.ColumnHeader();
         this.columnNotifyLevelEmail = new System.Windows.Forms.ColumnHeader();
         this.columnNotifyOperatorEmail = new System.Windows.Forms.ColumnHeader();
         this.columnNotifyLevelNetSend = new System.Windows.Forms.ColumnHeader();
         this.columnNotifyOperatorNetSend = new System.Windows.Forms.ColumnHeader();
         this.columnLevelNotifyPage = new System.Windows.Forms.ColumnHeader();
         this.columnNotifyOperatorPage = new System.Windows.Forms.ColumnHeader();
         this.labelCount = new DevComponents.DotNetBar.LabelX();
         this.checkBoxClearSelections = new System.Windows.Forms.CheckBox();
         this.groupPanelValues.SuspendLayout();
         this.groupPanelNotifications.SuspendLayout();
         this.groupPanelJobs.SuspendLayout();
         this.SuspendLayout();
         // 
         // labelSelection
         // 
         this.labelSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.labelSelection.BackColor = System.Drawing.Color.Transparent;
         this.labelSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelSelection.Location = new System.Drawing.Point(10, 7);
         this.labelSelection.Name = "labelSelection";
         this.labelSelection.Size = new System.Drawing.Size(769, 39);
         this.labelSelection.TabIndex = 13;
         this.labelSelection.Text = "Choose new values and press Update to change settings for all the jobs listed.\r\nN" +
             "ote: Drop down selection lists contain only those values that are available on a" +
             "ll servers to be updated.";
         this.labelSelection.WordWrap = true;
         // 
         // buttonOk
         // 
         this.buttonOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOk.Enabled = false;
         this.buttonOk.Location = new System.Drawing.Point(601, 445);
         this.buttonOk.Name = "buttonOk";
         this.buttonOk.Size = new System.Drawing.Size(81, 29);
         this.buttonOk.TabIndex = 17;
         this.buttonOk.Text = "&Update";
         this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
         // 
         // groupPanelValues
         // 
         this.groupPanelValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupPanelValues.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanelValues.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanelValues.Controls.Add(this.checkBoxCreateCategory);
         this.groupPanelValues.Controls.Add(this.groupPanelNotifications);
         this.groupPanelValues.Controls.Add(this.comboBoxOwner);
         this.groupPanelValues.Controls.Add(this.labelOwner);
         this.groupPanelValues.Controls.Add(this.comboBoxEnabled);
         this.groupPanelValues.Controls.Add(this.labelEnabled);
         this.groupPanelValues.Controls.Add(this.comboBoxCategory);
         this.groupPanelValues.Controls.Add(this.labelCategory);
         this.groupPanelValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupPanelValues.Location = new System.Drawing.Point(10, 254);
         this.groupPanelValues.Name = "groupPanelValues";
         this.groupPanelValues.Padding = new System.Windows.Forms.Padding(6);
         this.groupPanelValues.Size = new System.Drawing.Size(768, 185);
         // 
         // 
         // 
         this.groupPanelValues.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
         this.groupPanelValues.Style.BackColorGradientAngle = 90;
         this.groupPanelValues.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
         this.groupPanelValues.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanelValues.Style.BorderBottomWidth = 1;
         this.groupPanelValues.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
         this.groupPanelValues.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanelValues.Style.BorderLeftWidth = 1;
         this.groupPanelValues.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanelValues.Style.BorderRightWidth = 1;
         this.groupPanelValues.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanelValues.Style.BorderTopWidth = 1;
         this.groupPanelValues.Style.CornerDiameter = 4;
         this.groupPanelValues.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
         this.groupPanelValues.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
         this.groupPanelValues.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
         this.groupPanelValues.TabIndex = 2;
         this.groupPanelValues.Text = "New Values";
         // 
         // checkBoxCreateCategory
         // 
         this.checkBoxCreateCategory.AutoSize = true;
         this.checkBoxCreateCategory.BackColor = System.Drawing.Color.Transparent;
         this.checkBoxCreateCategory.Location = new System.Drawing.Point(86, 94);
         this.checkBoxCreateCategory.Name = "checkBoxCreateCategory";
         this.checkBoxCreateCategory.Size = new System.Drawing.Size(239, 17);
         this.checkBoxCreateCategory.TabIndex = 5;
         this.checkBoxCreateCategory.Text = "Create category if not found on server";
         // 
         // groupPanelNotifications
         // 
         this.groupPanelNotifications.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupPanelNotifications.BackColor = System.Drawing.Color.Transparent;
         this.groupPanelNotifications.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanelNotifications.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanelNotifications.Controls.Add(this.comboBoxNetSendOperator);
         this.groupPanelNotifications.Controls.Add(this.comboBoxPageOperator);
         this.groupPanelNotifications.Controls.Add(this.comboBoxEmailOperator);
         this.groupPanelNotifications.Controls.Add(this.labelOperator);
         this.groupPanelNotifications.Controls.Add(this.labelLevel);
         this.groupPanelNotifications.Controls.Add(this.comboBoxEventLogLevel);
         this.groupPanelNotifications.Controls.Add(this.labelEventLog);
         this.groupPanelNotifications.Controls.Add(this.comboBoxPageLevel);
         this.groupPanelNotifications.Controls.Add(this.labelPage);
         this.groupPanelNotifications.Controls.Add(this.comboBoxNetSendLevel);
         this.groupPanelNotifications.Controls.Add(this.labelNetSend);
         this.groupPanelNotifications.Controls.Add(this.comboBoxEmailLevel);
         this.groupPanelNotifications.Controls.Add(this.labelEmail);
         this.groupPanelNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupPanelNotifications.Location = new System.Drawing.Point(331, 0);
         this.groupPanelNotifications.Name = "groupPanelNotifications";
         this.groupPanelNotifications.Padding = new System.Windows.Forms.Padding(6);
         this.groupPanelNotifications.Size = new System.Drawing.Size(424, 159);
         // 
         // 
         // 
         this.groupPanelNotifications.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
         this.groupPanelNotifications.Style.BackColorGradientAngle = 90;
         this.groupPanelNotifications.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
         this.groupPanelNotifications.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanelNotifications.Style.BorderBottomWidth = 1;
         this.groupPanelNotifications.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
         this.groupPanelNotifications.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanelNotifications.Style.BorderLeftWidth = 1;
         this.groupPanelNotifications.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanelNotifications.Style.BorderRightWidth = 1;
         this.groupPanelNotifications.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanelNotifications.Style.BorderTopWidth = 1;
         this.groupPanelNotifications.Style.CornerDiameter = 4;
         this.groupPanelNotifications.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
         this.groupPanelNotifications.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
         this.groupPanelNotifications.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
         this.groupPanelNotifications.TabIndex = 7;
         this.groupPanelNotifications.Text = "Notifications to perform when the job completes";
         // 
         // comboBoxNetSendOperator
         // 
         this.comboBoxNetSendOperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBoxNetSendOperator.DisplayMember = "Text";
         this.comboBoxNetSendOperator.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this.comboBoxNetSendOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxNetSendOperator.FormattingEnabled = true;
         this.comboBoxNetSendOperator.ItemHeight = 16;
         this.comboBoxNetSendOperator.Items.AddRange(new object[] {
            this.comboItem10});
         this.comboBoxNetSendOperator.Location = new System.Drawing.Point(258, 81);
         this.comboBoxNetSendOperator.MaxDropDownItems = 64;
         this.comboBoxNetSendOperator.Name = "comboBoxNetSendOperator";
         this.comboBoxNetSendOperator.Size = new System.Drawing.Size(151, 22);
         this.comboBoxNetSendOperator.TabIndex = 13;
         this.comboBoxNetSendOperator.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
         this.comboBoxNetSendOperator.WatermarkText = "Select an Operator";
         this.comboBoxNetSendOperator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
         this.comboBoxNetSendOperator.DropDown += new System.EventHandler(this.comboBoxNotifyOperator_DropDown);
         // 
         // comboItem10
         // 
         this.comboItem10.Text = "comboItem1";
         this.comboItem10.TextAlignment = System.Drawing.StringAlignment.Center;
         this.comboItem10.TextLineAlignment = System.Drawing.StringAlignment.Center;
         // 
         // comboBoxPageOperator
         // 
         this.comboBoxPageOperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBoxPageOperator.DisplayMember = "Text";
         this.comboBoxPageOperator.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this.comboBoxPageOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxPageOperator.FormattingEnabled = true;
         this.comboBoxPageOperator.ItemHeight = 16;
         this.comboBoxPageOperator.Items.AddRange(new object[] {
            this.comboItem9});
         this.comboBoxPageOperator.Location = new System.Drawing.Point(258, 53);
         this.comboBoxPageOperator.MaxDropDownItems = 64;
         this.comboBoxPageOperator.Name = "comboBoxPageOperator";
         this.comboBoxPageOperator.Size = new System.Drawing.Size(151, 22);
         this.comboBoxPageOperator.TabIndex = 11;
         this.comboBoxPageOperator.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
         this.comboBoxPageOperator.WatermarkText = "Select an Operator";
         this.comboBoxPageOperator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
         this.comboBoxPageOperator.DropDown += new System.EventHandler(this.comboBoxNotifyOperator_DropDown);
         // 
         // comboItem9
         // 
         this.comboItem9.Text = "comboItem1";
         this.comboItem9.TextAlignment = System.Drawing.StringAlignment.Center;
         this.comboItem9.TextLineAlignment = System.Drawing.StringAlignment.Center;
         // 
         // comboBoxEmailOperator
         // 
         this.comboBoxEmailOperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBoxEmailOperator.DisplayMember = "Text";
         this.comboBoxEmailOperator.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this.comboBoxEmailOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxEmailOperator.FormattingEnabled = true;
         this.comboBoxEmailOperator.ItemHeight = 16;
         this.comboBoxEmailOperator.Items.AddRange(new object[] {
            this.comboItem8});
         this.comboBoxEmailOperator.Location = new System.Drawing.Point(258, 25);
         this.comboBoxEmailOperator.MaxDropDownItems = 64;
         this.comboBoxEmailOperator.Name = "comboBoxEmailOperator";
         this.comboBoxEmailOperator.Size = new System.Drawing.Size(151, 22);
         this.comboBoxEmailOperator.TabIndex = 9;
         this.comboBoxEmailOperator.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
         this.comboBoxEmailOperator.WatermarkText = "Select an Operator";
         this.comboBoxEmailOperator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
         this.comboBoxEmailOperator.DropDown += new System.EventHandler(this.comboBoxNotifyOperator_DropDown);
         this.comboBoxEmailOperator.Click += new System.EventHandler(this.comboBox_TextChanged);
         // 
         // comboItem8
         // 
         this.comboItem8.Text = "comboItem1";
         this.comboItem8.TextAlignment = System.Drawing.StringAlignment.Center;
         this.comboItem8.TextLineAlignment = System.Drawing.StringAlignment.Center;
         // 
         // labelOperator
         // 
         this.labelOperator.AutoSize = true;
         this.labelOperator.BackColor = System.Drawing.Color.Transparent;
         this.labelOperator.Location = new System.Drawing.Point(258, 4);
         this.labelOperator.Name = "labelOperator";
         this.labelOperator.Size = new System.Drawing.Size(57, 17);
         this.labelOperator.TabIndex = 26;
         this.labelOperator.Text = "Operator:";
         // 
         // labelLevel
         // 
         this.labelLevel.AutoSize = true;
         this.labelLevel.BackColor = System.Drawing.Color.Transparent;
         this.labelLevel.Location = new System.Drawing.Point(82, 4);
         this.labelLevel.Name = "labelLevel";
         this.labelLevel.Size = new System.Drawing.Size(37, 17);
         this.labelLevel.TabIndex = 25;
         this.labelLevel.Text = "Level:";
         // 
         // comboBoxEventLogLevel
         // 
         this.comboBoxEventLogLevel.DisplayMember = "Text";
         this.comboBoxEventLogLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this.comboBoxEventLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxEventLogLevel.FormattingEnabled = true;
         this.comboBoxEventLogLevel.ItemHeight = 16;
         this.comboBoxEventLogLevel.Items.AddRange(new object[] {
            this.comboItem6});
         this.comboBoxEventLogLevel.Location = new System.Drawing.Point(82, 109);
         this.comboBoxEventLogLevel.MaxDropDownItems = 64;
         this.comboBoxEventLogLevel.Name = "comboBoxEventLogLevel";
         this.comboBoxEventLogLevel.Size = new System.Drawing.Size(166, 22);
         this.comboBoxEventLogLevel.TabIndex = 14;
         this.comboBoxEventLogLevel.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
         this.comboBoxEventLogLevel.WatermarkText = "Select a Level";
         this.comboBoxEventLogLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
         this.comboBoxEventLogLevel.DropDown += new System.EventHandler(this.comboBoxNotifyLevel_DropDown);
         this.comboBoxEventLogLevel.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
         // 
         // comboItem6
         // 
         this.comboItem6.Text = "comboItem1";
         this.comboItem6.TextAlignment = System.Drawing.StringAlignment.Center;
         this.comboItem6.TextLineAlignment = System.Drawing.StringAlignment.Center;
         // 
         // labelEventLog
         // 
         this.labelEventLog.AutoSize = true;
         this.labelEventLog.BackColor = System.Drawing.Color.Transparent;
         this.labelEventLog.Location = new System.Drawing.Point(13, 112);
         this.labelEventLog.Name = "labelEventLog";
         this.labelEventLog.Size = new System.Drawing.Size(64, 17);
         this.labelEventLog.TabIndex = 23;
         this.labelEventLog.Text = "Event Log:";
         // 
         // comboBoxPageLevel
         // 
         this.comboBoxPageLevel.DisplayMember = "Text";
         this.comboBoxPageLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this.comboBoxPageLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxPageLevel.FormattingEnabled = true;
         this.comboBoxPageLevel.ItemHeight = 16;
         this.comboBoxPageLevel.Items.AddRange(new object[] {
            this.comboItem5});
         this.comboBoxPageLevel.Location = new System.Drawing.Point(82, 53);
         this.comboBoxPageLevel.MaxDropDownItems = 64;
         this.comboBoxPageLevel.Name = "comboBoxPageLevel";
         this.comboBoxPageLevel.Size = new System.Drawing.Size(166, 22);
         this.comboBoxPageLevel.TabIndex = 10;
         this.comboBoxPageLevel.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
         this.comboBoxPageLevel.WatermarkText = "Select a Level";
         this.comboBoxPageLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
         this.comboBoxPageLevel.DropDown += new System.EventHandler(this.comboBoxNotifyLevel_DropDown);
         this.comboBoxPageLevel.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
         // 
         // comboItem5
         // 
         this.comboItem5.Text = "comboItem1";
         this.comboItem5.TextAlignment = System.Drawing.StringAlignment.Center;
         this.comboItem5.TextLineAlignment = System.Drawing.StringAlignment.Center;
         // 
         // labelPage
         // 
         this.labelPage.AutoSize = true;
         this.labelPage.BackColor = System.Drawing.Color.Transparent;
         this.labelPage.Location = new System.Drawing.Point(13, 56);
         this.labelPage.Name = "labelPage";
         this.labelPage.Size = new System.Drawing.Size(36, 17);
         this.labelPage.TabIndex = 21;
         this.labelPage.Text = "Page:";
         // 
         // comboBoxNetSendLevel
         // 
         this.comboBoxNetSendLevel.DisplayMember = "Text";
         this.comboBoxNetSendLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this.comboBoxNetSendLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxNetSendLevel.FormattingEnabled = true;
         this.comboBoxNetSendLevel.ItemHeight = 16;
         this.comboBoxNetSendLevel.Items.AddRange(new object[] {
            this.comboItem4});
         this.comboBoxNetSendLevel.Location = new System.Drawing.Point(82, 81);
         this.comboBoxNetSendLevel.MaxDropDownItems = 64;
         this.comboBoxNetSendLevel.Name = "comboBoxNetSendLevel";
         this.comboBoxNetSendLevel.Size = new System.Drawing.Size(166, 22);
         this.comboBoxNetSendLevel.TabIndex = 12;
         this.comboBoxNetSendLevel.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
         this.comboBoxNetSendLevel.WatermarkText = "Select a Level";
         this.comboBoxNetSendLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
         this.comboBoxNetSendLevel.DropDown += new System.EventHandler(this.comboBoxNotifyLevel_DropDown);
         this.comboBoxNetSendLevel.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
         // 
         // comboItem4
         // 
         this.comboItem4.Text = "comboItem1";
         this.comboItem4.TextAlignment = System.Drawing.StringAlignment.Center;
         this.comboItem4.TextLineAlignment = System.Drawing.StringAlignment.Center;
         // 
         // labelNetSend
         // 
         this.labelNetSend.AutoSize = true;
         this.labelNetSend.BackColor = System.Drawing.Color.Transparent;
         this.labelNetSend.Location = new System.Drawing.Point(13, 84);
         this.labelNetSend.Name = "labelNetSend";
         this.labelNetSend.Size = new System.Drawing.Size(58, 17);
         this.labelNetSend.TabIndex = 19;
         this.labelNetSend.Text = "Net send:";
         // 
         // comboBoxEmailLevel
         // 
         this.comboBoxEmailLevel.DisplayMember = "Text";
         this.comboBoxEmailLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this.comboBoxEmailLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxEmailLevel.FormattingEnabled = true;
         this.comboBoxEmailLevel.ItemHeight = 16;
         this.comboBoxEmailLevel.Items.AddRange(new object[] {
            this.comboItem7});
         this.comboBoxEmailLevel.Location = new System.Drawing.Point(82, 25);
         this.comboBoxEmailLevel.MaxDropDownItems = 64;
         this.comboBoxEmailLevel.Name = "comboBoxEmailLevel";
         this.comboBoxEmailLevel.Size = new System.Drawing.Size(166, 22);
         this.comboBoxEmailLevel.TabIndex = 8;
         this.comboBoxEmailLevel.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
         this.comboBoxEmailLevel.WatermarkText = "Select a Level";
         this.comboBoxEmailLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
         this.comboBoxEmailLevel.DropDown += new System.EventHandler(this.comboBoxNotifyLevel_DropDown);
         this.comboBoxEmailLevel.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
         // 
         // comboItem7
         // 
         this.comboItem7.Text = "comboItem1";
         this.comboItem7.TextAlignment = System.Drawing.StringAlignment.Center;
         this.comboItem7.TextLineAlignment = System.Drawing.StringAlignment.Center;
         // 
         // labelEmail
         // 
         this.labelEmail.AutoSize = true;
         this.labelEmail.BackColor = System.Drawing.Color.Transparent;
         this.labelEmail.Location = new System.Drawing.Point(13, 28);
         this.labelEmail.Name = "labelEmail";
         this.labelEmail.Size = new System.Drawing.Size(39, 17);
         this.labelEmail.TabIndex = 16;
         this.labelEmail.Text = "Email:";
         // 
         // comboBoxOwner
         // 
         this.comboBoxOwner.DisplayMember = "Text";
         this.comboBoxOwner.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this.comboBoxOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxOwner.FormattingEnabled = true;
         this.comboBoxOwner.ItemHeight = 16;
         this.comboBoxOwner.Items.AddRange(new object[] {
            this.comboItem3});
         this.comboBoxOwner.Location = new System.Drawing.Point(86, 128);
         this.comboBoxOwner.MaxDropDownItems = 64;
         this.comboBoxOwner.Name = "comboBoxOwner";
         this.comboBoxOwner.Size = new System.Drawing.Size(229, 22);
         this.comboBoxOwner.TabIndex = 6;
         this.comboBoxOwner.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
         this.comboBoxOwner.WatermarkText = "Select a new Owner";
         this.comboBoxOwner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
         this.comboBoxOwner.DropDown += new System.EventHandler(this.comboBoxOwner_DropDown);
         this.comboBoxOwner.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
         // 
         // comboItem3
         // 
         this.comboItem3.Text = "comboItem1";
         this.comboItem3.TextAlignment = System.Drawing.StringAlignment.Center;
         this.comboItem3.TextLineAlignment = System.Drawing.StringAlignment.Center;
         // 
         // labelOwner
         // 
         this.labelOwner.AutoSize = true;
         this.labelOwner.BackColor = System.Drawing.Color.Transparent;
         this.labelOwner.Location = new System.Drawing.Point(17, 131);
         this.labelOwner.Name = "labelOwner";
         this.labelOwner.Size = new System.Drawing.Size(44, 17);
         this.labelOwner.TabIndex = 6;
         this.labelOwner.Text = "Owner:";
         // 
         // comboBoxEnabled
         // 
         this.comboBoxEnabled.DisplayMember = "Text";
         this.comboBoxEnabled.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this.comboBoxEnabled.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxEnabled.FormattingEnabled = true;
         this.comboBoxEnabled.ItemHeight = 16;
         this.comboBoxEnabled.Items.AddRange(new object[] {
            this.comboItem2});
         this.comboBoxEnabled.Location = new System.Drawing.Point(86, 22);
         this.comboBoxEnabled.MaxDropDownItems = 64;
         this.comboBoxEnabled.Name = "comboBoxEnabled";
         this.comboBoxEnabled.Size = new System.Drawing.Size(229, 22);
         this.comboBoxEnabled.TabIndex = 3;
         this.comboBoxEnabled.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
         this.comboBoxEnabled.WatermarkText = "Select Enabled or Disabled";
         this.comboBoxEnabled.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
         this.comboBoxEnabled.DropDown += new System.EventHandler(this.comboBoxEnabled_DropDown);
         this.comboBoxEnabled.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
         // 
         // comboItem2
         // 
         this.comboItem2.Text = "comboItem1";
         this.comboItem2.TextAlignment = System.Drawing.StringAlignment.Center;
         this.comboItem2.TextLineAlignment = System.Drawing.StringAlignment.Center;
         // 
         // labelEnabled
         // 
         this.labelEnabled.AutoSize = true;
         this.labelEnabled.BackColor = System.Drawing.Color.Transparent;
         this.labelEnabled.Location = new System.Drawing.Point(17, 25);
         this.labelEnabled.Name = "labelEnabled";
         this.labelEnabled.Size = new System.Drawing.Size(54, 17);
         this.labelEnabled.TabIndex = 4;
         this.labelEnabled.Text = "Enabled:";
         // 
         // comboBoxCategory
         // 
         this.comboBoxCategory.DisplayMember = "Text";
         this.comboBoxCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this.comboBoxCategory.FormattingEnabled = true;
         this.comboBoxCategory.ItemHeight = 16;
         this.comboBoxCategory.Items.AddRange(new object[] {
            this.comboItem1});
         this.comboBoxCategory.Location = new System.Drawing.Point(86, 66);
         this.comboBoxCategory.MaxDropDownItems = 64;
         this.comboBoxCategory.Name = "comboBoxCategory";
         this.comboBoxCategory.Size = new System.Drawing.Size(229, 22);
         this.comboBoxCategory.TabIndex = 4;
         this.comboBoxCategory.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
         this.comboBoxCategory.WatermarkText = "Select or enter a new Category";
         this.comboBoxCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
         this.comboBoxCategory.DropDown += new System.EventHandler(this.comboBoxCategory_DropDown);
         this.comboBoxCategory.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
         // 
         // comboItem1
         // 
         this.comboItem1.Text = "comboItem1";
         this.comboItem1.TextAlignment = System.Drawing.StringAlignment.Center;
         this.comboItem1.TextLineAlignment = System.Drawing.StringAlignment.Center;
         // 
         // labelCategory
         // 
         this.labelCategory.AutoSize = true;
         this.labelCategory.BackColor = System.Drawing.Color.Transparent;
         this.labelCategory.Location = new System.Drawing.Point(17, 69);
         this.labelCategory.Name = "labelCategory";
         this.labelCategory.Size = new System.Drawing.Size(59, 17);
         this.labelCategory.TabIndex = 2;
         this.labelCategory.Text = "Category:";
         // 
         // buttonCancel
         // 
         this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(691, 445);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(81, 29);
         this.buttonCancel.TabIndex = 18;
         this.buttonCancel.Text = "&Cancel";
         // 
         // groupPanelJobs
         // 
         this.groupPanelJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupPanelJobs.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanelJobs.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanelJobs.Controls.Add(this.listViewJobs);
         this.groupPanelJobs.Controls.Add(this.labelCount);
         this.groupPanelJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupPanelJobs.Location = new System.Drawing.Point(10, 54);
         this.groupPanelJobs.Name = "groupPanelJobs";
         this.groupPanelJobs.Padding = new System.Windows.Forms.Padding(6, 6, 6, 2);
         this.groupPanelJobs.Size = new System.Drawing.Size(768, 194);
         // 
         // 
         // 
         this.groupPanelJobs.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
         this.groupPanelJobs.Style.BackColorGradientAngle = 90;
         this.groupPanelJobs.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
         this.groupPanelJobs.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanelJobs.Style.BorderBottomWidth = 1;
         this.groupPanelJobs.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
         this.groupPanelJobs.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanelJobs.Style.BorderLeftWidth = 1;
         this.groupPanelJobs.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanelJobs.Style.BorderRightWidth = 1;
         this.groupPanelJobs.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanelJobs.Style.BorderTopWidth = 1;
         this.groupPanelJobs.Style.CornerDiameter = 4;
         this.groupPanelJobs.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
         this.groupPanelJobs.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
         this.groupPanelJobs.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
         this.groupPanelJobs.TabIndex = 0;
         this.groupPanelJobs.Text = "Jobs to Update";
         // 
         // listViewJobs
         // 
         this.listViewJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         // 
         // 
         // 
         this.listViewJobs.Border.Class = "ListViewBorder";
         this.listViewJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnServer,
            this.columnJobName,
            this.columnEnabled,
            this.columnCategory,
            this.columnOwner,
            this.columnNotifyLevelEventLog,
            this.columnNotifyLevelEmail,
            this.columnNotifyOperatorEmail,
            this.columnNotifyLevelNetSend,
            this.columnNotifyOperatorNetSend,
            this.columnLevelNotifyPage,
            this.columnNotifyOperatorPage});
         this.listViewJobs.FullRowSelect = true;
         this.listViewJobs.Location = new System.Drawing.Point(7, 9);
         this.listViewJobs.Name = "listViewJobs";
         this.listViewJobs.ShowItemToolTips = true;
         this.listViewJobs.Size = new System.Drawing.Size(748, 144);
         this.listViewJobs.Sorting = System.Windows.Forms.SortOrder.Ascending;
         this.listViewJobs.TabIndex = 1;
         this.listViewJobs.UseCompatibleStateImageBehavior = false;
         this.listViewJobs.View = System.Windows.Forms.View.Details;
         this.listViewJobs.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewJobs_ColumnClick);
         // 
         // columnServer
         // 
         this.columnServer.Text = "Server";
         this.columnServer.Width = 149;
         // 
         // columnJobName
         // 
         this.columnJobName.Text = "Job Name";
         this.columnJobName.Width = 160;
         // 
         // columnEnabled
         // 
         this.columnEnabled.Text = "Enabled";
         this.columnEnabled.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         this.columnEnabled.Width = 69;
         // 
         // columnCategory
         // 
         this.columnCategory.Text = "Category";
         this.columnCategory.Width = 134;
         // 
         // columnOwner
         // 
         this.columnOwner.Text = "Owner";
         this.columnOwner.Width = 118;
         // 
         // columnNotifyLevelEventLog
         // 
         this.columnNotifyLevelEventLog.Text = "Notify Event Log";
         this.columnNotifyLevelEventLog.Width = 115;
         // 
         // columnNotifyLevelEmail
         // 
         this.columnNotifyLevelEmail.Text = "Notify Email";
         this.columnNotifyLevelEmail.Width = 76;
         // 
         // columnNotifyOperatorEmail
         // 
         this.columnNotifyOperatorEmail.Text = "Email Operator";
         this.columnNotifyOperatorEmail.Width = 90;
         // 
         // columnNotifyLevelNetSend
         // 
         this.columnNotifyLevelNetSend.Text = "Notify Net Send";
         this.columnNotifyLevelNetSend.Width = 94;
         // 
         // columnNotifyOperatorNetSend
         // 
         this.columnNotifyOperatorNetSend.Text = "Net Send Operator";
         this.columnNotifyOperatorNetSend.Width = 110;
         // 
         // columnLevelNotifyPage
         // 
         this.columnLevelNotifyPage.Text = "Notify Page";
         this.columnLevelNotifyPage.Width = 76;
         // 
         // columnNotifyOperatorPage
         // 
         this.columnNotifyOperatorPage.Text = "Page Operator";
         this.columnNotifyOperatorPage.Width = 90;
         // 
         // labelCount
         // 
         this.labelCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.labelCount.AutoSize = true;
         this.labelCount.BackColor = System.Drawing.Color.Transparent;
         this.labelCount.Location = new System.Drawing.Point(7, 154);
         this.labelCount.Name = "labelCount";
         this.labelCount.Size = new System.Drawing.Size(30, 17);
         this.labelCount.TabIndex = 40;
         this.labelCount.Text = "Jobs";
         // 
         // checkBoxClearSelections
         // 
         this.checkBoxClearSelections.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.checkBoxClearSelections.AutoSize = true;
         this.checkBoxClearSelections.Location = new System.Drawing.Point(22, 452);
         this.checkBoxClearSelections.Name = "checkBoxClearSelections";
         this.checkBoxClearSelections.Size = new System.Drawing.Size(213, 17);
         this.checkBoxClearSelections.TabIndex = 16;
         this.checkBoxClearSelections.Text = "Uncheck Jobs in Job List after updating";
         this.checkBoxClearSelections.UseVisualStyleBackColor = true;
         // 
         // UpdateJobs
         // 
         this.AcceptButton = this.buttonOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(788, 481);
         this.Controls.Add(this.groupPanelValues);
         this.Controls.Add(this.groupPanelJobs);
         this.Controls.Add(this.checkBoxClearSelections);
         this.Controls.Add(this.labelSelection);
         this.Controls.Add(this.buttonOk);
         this.Controls.Add(this.buttonCancel);
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size(740, 464);
         this.Name = "UpdateJobs";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Update Job Properties";
         this.groupPanelValues.ResumeLayout(false);
         this.groupPanelValues.PerformLayout();
         this.groupPanelNotifications.ResumeLayout(false);
         this.groupPanelNotifications.PerformLayout();
         this.groupPanelJobs.ResumeLayout(false);
         this.groupPanelJobs.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevComponents.DotNetBar.LabelX labelSelection;
      private DevComponents.DotNetBar.ButtonX buttonOk;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanelValues;
      public DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxOwner;
      private DevComponents.Editors.ComboItem comboItem3;
      private DevComponents.DotNetBar.LabelX labelOwner;
      public DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEnabled;
      private DevComponents.Editors.ComboItem comboItem2;
      private DevComponents.DotNetBar.LabelX labelEnabled;
      public DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxCategory;
      private DevComponents.Editors.ComboItem comboItem1;
      private DevComponents.DotNetBar.LabelX labelCategory;
      private DevComponents.DotNetBar.ButtonX buttonCancel;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanelJobs;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanelNotifications;
      public DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEmailLevel;
      private DevComponents.Editors.ComboItem comboItem7;
      private DevComponents.DotNetBar.LabelX labelEmail;
      public DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEventLogLevel;
      private DevComponents.Editors.ComboItem comboItem6;
      private DevComponents.DotNetBar.LabelX labelEventLog;
      public DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxPageLevel;
      private DevComponents.Editors.ComboItem comboItem5;
      private DevComponents.DotNetBar.LabelX labelPage;
      public DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxNetSendLevel;
      private DevComponents.Editors.ComboItem comboItem4;
      private DevComponents.DotNetBar.LabelX labelNetSend;
      private DevComponents.DotNetBar.LabelX labelOperator;
      private DevComponents.DotNetBar.LabelX labelLevel;
      private System.Windows.Forms.CheckBox checkBoxClearSelections;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxCreateCategory;
      public DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEmailOperator;
      private DevComponents.Editors.ComboItem comboItem8;
      public DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxNetSendOperator;
      private DevComponents.Editors.ComboItem comboItem10;
      public DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxPageOperator;
      private DevComponents.Editors.ComboItem comboItem9;
      private DevComponents.DotNetBar.Controls.ListViewEx listViewJobs;
      private System.Windows.Forms.ColumnHeader columnServer;
      private System.Windows.Forms.ColumnHeader columnJobName;
      private System.Windows.Forms.ColumnHeader columnEnabled;
      private System.Windows.Forms.ColumnHeader columnCategory;
      private System.Windows.Forms.ColumnHeader columnOwner;
      private System.Windows.Forms.ColumnHeader columnNotifyLevelEventLog;
      private System.Windows.Forms.ColumnHeader columnNotifyLevelEmail;
      private System.Windows.Forms.ColumnHeader columnNotifyOperatorEmail;
      private System.Windows.Forms.ColumnHeader columnNotifyLevelNetSend;
      private System.Windows.Forms.ColumnHeader columnNotifyOperatorNetSend;
      private System.Windows.Forms.ColumnHeader columnLevelNotifyPage;
      private System.Windows.Forms.ColumnHeader columnNotifyOperatorPage;
      private DevComponents.DotNetBar.LabelX labelCount;

   }
}