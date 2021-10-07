namespace Idera.SqlAdminToolset.JobEditor
{
    partial class SelectJobs
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
            this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
            this.checkBoxClearSelections = new System.Windows.Forms.CheckBox();
            this.groupPanel_Main = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkBoxCaseSensitive = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.buttonClear = new DevComponents.DotNetBar.ButtonX();
            this.comboBoxNotification = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.labelNotification = new DevComponents.DotNetBar.LabelX();
            this.comboBoxLastRun = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.labelLastRun = new DevComponents.DotNetBar.LabelX();
            this.comboBoxOutcome = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.labelOutcome = new DevComponents.DotNetBar.LabelX();
            this.comboBoxName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.labelName = new DevComponents.DotNetBar.LabelX();
            this.comboBoxOwner = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.labelOwner = new DevComponents.DotNetBar.LabelX();
            this.comboBoxEnabled = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.labelEnabled = new DevComponents.DotNetBar.LabelX();
            this.comboBoxCategory = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.labelCategory = new DevComponents.DotNetBar.LabelX();
            this.labeljobstatus = new DevComponents.DotNetBar.LabelX();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxjobdayhour = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buttonOk = new DevComponents.DotNetBar.ButtonX();
            this.labelSelection = new DevComponents.DotNetBar.LabelX();
            this.groupPanel_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(540, 449);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(81, 29);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "&Cancel";
            // 
            // checkBoxClearSelections
            // 
            this.checkBoxClearSelections.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxClearSelections.AutoSize = true;
            this.checkBoxClearSelections.Location = new System.Drawing.Point(22, 460);
            this.checkBoxClearSelections.Name = "checkBoxClearSelections";
            this.checkBoxClearSelections.Size = new System.Drawing.Size(213, 17);
            this.checkBoxClearSelections.TabIndex = 10;
            this.checkBoxClearSelections.Text = "Uncheck previous selections in Job List";
            this.checkBoxClearSelections.UseVisualStyleBackColor = true;
            // 
            // groupPanel_Main
            // 
            this.groupPanel_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel_Main.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Main.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Main.Controls.Add(this.checkBoxCaseSensitive);
            this.groupPanel_Main.Controls.Add(this.buttonClear);
            this.groupPanel_Main.Controls.Add(this.comboBoxNotification);
            this.groupPanel_Main.Controls.Add(this.labelNotification);
            this.groupPanel_Main.Controls.Add(this.comboBoxLastRun);
            this.groupPanel_Main.Controls.Add(this.labelLastRun);
            this.groupPanel_Main.Controls.Add(this.comboBoxOutcome);
            this.groupPanel_Main.Controls.Add(this.labelOutcome);
            this.groupPanel_Main.Controls.Add(this.comboBoxName);
            this.groupPanel_Main.Controls.Add(this.labelName);
            this.groupPanel_Main.Controls.Add(this.comboBoxOwner);
            this.groupPanel_Main.Controls.Add(this.labelOwner);
            this.groupPanel_Main.Controls.Add(this.comboBoxEnabled);
            this.groupPanel_Main.Controls.Add(this.labelEnabled);
            this.groupPanel_Main.Controls.Add(this.comboBoxCategory);
            this.groupPanel_Main.Controls.Add(this.labelCategory);
            this.groupPanel_Main.Controls.Add(this.labeljobstatus);
            this.groupPanel_Main.Controls.Add(this.numericUpDown1);
            this.groupPanel_Main.Controls.Add(this.comboBoxjobdayhour);
            this.groupPanel_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPanel_Main.Location = new System.Drawing.Point(6, 54);
            this.groupPanel_Main.Name = "groupPanel_Main";
            this.groupPanel_Main.Padding = new System.Windows.Forms.Padding(6);
            this.groupPanel_Main.Size = new System.Drawing.Size(659, 391);
            // 
            // 
            // 
            this.groupPanel_Main.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel_Main.Style.BackColorGradientAngle = 90;
            this.groupPanel_Main.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_Main.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Main.Style.BorderBottomWidth = 1;
            this.groupPanel_Main.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_Main.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Main.Style.BorderLeftWidth = 1;
            this.groupPanel_Main.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Main.Style.BorderRightWidth = 1;
            this.groupPanel_Main.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Main.Style.BorderTopWidth = 1;
            this.groupPanel_Main.Style.Class = "";
            this.groupPanel_Main.Style.CornerDiameter = 4;
            this.groupPanel_Main.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_Main.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_Main.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel_Main.StyleMouseDown.Class = "";
            this.groupPanel_Main.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_Main.StyleMouseOver.Class = "";
            this.groupPanel_Main.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_Main.TabIndex = 0;
            this.groupPanel_Main.Text = "Job Properties";
            // 
            // checkBoxCaseSensitive
            // 
            this.checkBoxCaseSensitive.AutoSize = true;
            this.checkBoxCaseSensitive.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxCaseSensitive.BackgroundStyle.Class = "";
            this.checkBoxCaseSensitive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxCaseSensitive.Checked = true;
            this.checkBoxCaseSensitive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCaseSensitive.CheckValue = "Y";
            this.checkBoxCaseSensitive.Location = new System.Drawing.Point(24, 338);
            this.checkBoxCaseSensitive.Name = "checkBoxCaseSensitive";
            this.checkBoxCaseSensitive.Size = new System.Drawing.Size(190, 17);
            this.checkBoxCaseSensitive.TabIndex = 8;
            this.checkBoxCaseSensitive.Text = "Use case sensitive compare";
            // 
            // buttonClear
            // 
            this.buttonClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.BackColor = System.Drawing.Color.Transparent;
            this.buttonClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonClear.Location = new System.Drawing.Point(496, 338);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(115, 23);
            this.buttonClear.TabIndex = 9;
            this.buttonClear.Text = "C&lear all values";
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // comboBoxNotification
            // 
            this.comboBoxNotification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxNotification.DisplayMember = "Text";
            this.comboBoxNotification.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxNotification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxNotification.FormattingEnabled = true;
            this.comboBoxNotification.ItemHeight = 16;
            this.comboBoxNotification.Items.AddRange(new object[] {
            this.comboItem7});
            this.comboBoxNotification.Location = new System.Drawing.Point(158, 296);
            this.comboBoxNotification.MaxDropDownItems = 64;
            this.comboBoxNotification.Name = "comboBoxNotification";
            this.comboBoxNotification.Size = new System.Drawing.Size(357, 22);
            this.comboBoxNotification.TabIndex = 7;
            this.comboBoxNotification.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.comboBoxNotification.WatermarkText = "Select Jobs by Notification Type";
            this.comboBoxNotification.DropDown += new System.EventHandler(this.comboBoxNotification_DropDown);
            this.comboBoxNotification.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
            this.comboBoxNotification.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "comboItem1";
            this.comboItem7.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem7.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelNotification
            // 
            this.labelNotification.AutoSize = true;
            this.labelNotification.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelNotification.BackgroundStyle.Class = "";
            this.labelNotification.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelNotification.Location = new System.Drawing.Point(25, 299);
            this.labelNotification.Name = "labelNotification";
            this.labelNotification.Size = new System.Drawing.Size(77, 17);
            this.labelNotification.TabIndex = 14;
            this.labelNotification.Text = "Notifications:";
            // 
            // comboBoxLastRun
            // 
            this.comboBoxLastRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLastRun.DisplayMember = "Text";
            this.comboBoxLastRun.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxLastRun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLastRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxLastRun.FormattingEnabled = true;
            this.comboBoxLastRun.ItemHeight = 16;
            this.comboBoxLastRun.Items.AddRange(new object[] {
            this.comboItem6});
            this.comboBoxLastRun.Location = new System.Drawing.Point(158, 257);
            this.comboBoxLastRun.MaxDropDownItems = 64;
            this.comboBoxLastRun.Name = "comboBoxLastRun";
            this.comboBoxLastRun.Size = new System.Drawing.Size(357, 22);
            this.comboBoxLastRun.TabIndex = 6;
            this.comboBoxLastRun.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.comboBoxLastRun.WatermarkText = "Select Jobs by timeframe";
            this.comboBoxLastRun.DropDown += new System.EventHandler(this.comboBoxLastRun_DropDown);
            this.comboBoxLastRun.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
            this.comboBoxLastRun.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "comboItem1";
            this.comboItem6.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem6.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelLastRun
            // 
            this.labelLastRun.AutoSize = true;
            this.labelLastRun.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelLastRun.BackgroundStyle.Class = "";
            this.labelLastRun.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelLastRun.Location = new System.Drawing.Point(25, 260);
            this.labelLastRun.Name = "labelLastRun";
            this.labelLastRun.Size = new System.Drawing.Size(58, 17);
            this.labelLastRun.TabIndex = 12;
            this.labelLastRun.Text = "Last Run:";
            // 
            // comboBoxOutcome
            // 
            this.comboBoxOutcome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOutcome.DisplayMember = "Text";
            this.comboBoxOutcome.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxOutcome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxOutcome.FormattingEnabled = true;
            this.comboBoxOutcome.ItemHeight = 16;
            this.comboBoxOutcome.Items.AddRange(new object[] {
            this.comboItem5});
            this.comboBoxOutcome.Location = new System.Drawing.Point(158, 179);
            this.comboBoxOutcome.MaxDropDownItems = 64;
            this.comboBoxOutcome.Name = "comboBoxOutcome";
            this.comboBoxOutcome.Size = new System.Drawing.Size(453, 22);
            this.comboBoxOutcome.TabIndex = 5;
            this.comboBoxOutcome.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.comboBoxOutcome.WatermarkText = "Enter one or more Outcomes separated by semi-colons";
            this.comboBoxOutcome.DropDown += new System.EventHandler(this.comboBoxOutcome_DropDown);
            this.comboBoxOutcome.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
            this.comboBoxOutcome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "comboItem1";
            this.comboItem5.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem5.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelOutcome
            // 
            this.labelOutcome.AutoSize = true;
            this.labelOutcome.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelOutcome.BackgroundStyle.Class = "";
            this.labelOutcome.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelOutcome.Location = new System.Drawing.Point(25, 182);
            this.labelOutcome.Name = "labelOutcome";
            this.labelOutcome.Size = new System.Drawing.Size(87, 17);
            this.labelOutcome.TabIndex = 10;
            this.labelOutcome.Text = "Last Outcome:";
            // 
            // comboBoxName
            // 
            this.comboBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxName.DisplayMember = "Text";
            this.comboBoxName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.ItemHeight = 16;
            this.comboBoxName.Items.AddRange(new object[] {
            this.comboItem4,
            this.comboItem4});
            this.comboBoxName.Location = new System.Drawing.Point(158, 23);
            this.comboBoxName.MaxDropDownItems = 64;
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(453, 22);
            this.comboBoxName.TabIndex = 1;
            this.comboBoxName.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.comboBoxName.WatermarkText = "Enter one or more Job Names separated by semi-colons";
            this.comboBoxName.DropDown += new System.EventHandler(this.comboBoxName_DropDown);
            this.comboBoxName.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
            this.comboBoxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "comboItem1";
            this.comboItem4.TextAlignment = System.Drawing.StringAlignment.Center;
            this.comboItem4.TextLineAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelName
            // 
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelName.BackgroundStyle.Class = "";
            this.labelName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelName.Location = new System.Drawing.Point(25, 26);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(65, 17);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "Job Name:";
            // 
            // comboBoxOwner
            // 
            this.comboBoxOwner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOwner.DisplayMember = "Text";
            this.comboBoxOwner.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxOwner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxOwner.FormattingEnabled = true;
            this.comboBoxOwner.ItemHeight = 16;
            this.comboBoxOwner.Items.AddRange(new object[] {
            this.comboItem3});
            this.comboBoxOwner.Location = new System.Drawing.Point(158, 140);
            this.comboBoxOwner.MaxDropDownItems = 64;
            this.comboBoxOwner.Name = "comboBoxOwner";
            this.comboBoxOwner.Size = new System.Drawing.Size(453, 22);
            this.comboBoxOwner.TabIndex = 4;
            this.comboBoxOwner.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.comboBoxOwner.WatermarkText = "Enter one or more Owners separated by semi-colons";
            this.comboBoxOwner.DropDown += new System.EventHandler(this.comboBoxOwner_DropDown);
            this.comboBoxOwner.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
            this.comboBoxOwner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
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
            // 
            // 
            // 
            this.labelOwner.BackgroundStyle.Class = "";
            this.labelOwner.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelOwner.Location = new System.Drawing.Point(25, 143);
            this.labelOwner.Name = "labelOwner";
            this.labelOwner.Size = new System.Drawing.Size(44, 17);
            this.labelOwner.TabIndex = 6;
            this.labelOwner.Text = "Owner:";
            // 
            // comboBoxEnabled
            // 
            this.comboBoxEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEnabled.DisplayMember = "Text";
            this.comboBoxEnabled.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEnabled.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxEnabled.FormattingEnabled = true;
            this.comboBoxEnabled.ItemHeight = 16;
            this.comboBoxEnabled.Items.AddRange(new object[] {
            this.comboItem2});
            this.comboBoxEnabled.Location = new System.Drawing.Point(158, 62);
            this.comboBoxEnabled.MaxDropDownItems = 64;
            this.comboBoxEnabled.Name = "comboBoxEnabled";
            this.comboBoxEnabled.Size = new System.Drawing.Size(357, 22);
            this.comboBoxEnabled.TabIndex = 2;
            this.comboBoxEnabled.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.comboBoxEnabled.WatermarkText = "Select Enabled or Disabled Jobs";
            this.comboBoxEnabled.DropDown += new System.EventHandler(this.comboBoxEnabled_DropDown);
            this.comboBoxEnabled.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
            this.comboBoxEnabled.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
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
            // 
            // 
            // 
            this.labelEnabled.BackgroundStyle.Class = "";
            this.labelEnabled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelEnabled.Location = new System.Drawing.Point(25, 65);
            this.labelEnabled.Name = "labelEnabled";
            this.labelEnabled.Size = new System.Drawing.Size(54, 17);
            this.labelEnabled.TabIndex = 4;
            this.labelEnabled.Text = "Enabled:";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCategory.DisplayMember = "Text";
            this.comboBoxCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.ItemHeight = 16;
            this.comboBoxCategory.Items.AddRange(new object[] {
            this.comboItem1});
            this.comboBoxCategory.Location = new System.Drawing.Point(158, 101);
            this.comboBoxCategory.MaxDropDownItems = 64;
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(453, 22);
            this.comboBoxCategory.TabIndex = 3;
            this.comboBoxCategory.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.comboBoxCategory.WatermarkText = "Enter one or more Categories separated by semi-colons";
            this.comboBoxCategory.DropDown += new System.EventHandler(this.comboBoxCategory_DropDown);
            this.comboBoxCategory.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
            this.comboBoxCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
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
            // 
            // 
            // 
            this.labelCategory.BackgroundStyle.Class = "";
            this.labelCategory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelCategory.Location = new System.Drawing.Point(25, 104);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(59, 17);
            this.labelCategory.TabIndex = 2;
            this.labelCategory.Text = "Category:";
            // 
            // labeljobstatus
            // 
            this.labeljobstatus.AutoSize = true;
            this.labeljobstatus.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labeljobstatus.BackgroundStyle.Class = "";
            this.labeljobstatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labeljobstatus.Location = new System.Drawing.Point(25, 221);
            this.labeljobstatus.Name = "labeljobstatus";
            this.labeljobstatus.Size = new System.Drawing.Size(136, 17);
            this.labeljobstatus.TabIndex = 18;
            this.labeljobstatus.Text = "Jobs not run in the last:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(160, 218);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 22);
            this.numericUpDown1.TabIndex = 20;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxjobdayhour
            // 
            this.comboBoxjobdayhour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxjobdayhour.DisplayMember = "Text";
            this.comboBoxjobdayhour.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxjobdayhour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxjobdayhour.FormattingEnabled = true;
            this.comboBoxjobdayhour.ItemHeight = 16;
            this.comboBoxjobdayhour.Items.AddRange(new object[] {
            this.comboItem1});
            this.comboBoxjobdayhour.Location = new System.Drawing.Point(244, 218);
            this.comboBoxjobdayhour.MaxDropDownItems = 64;
            this.comboBoxjobdayhour.Name = "comboBoxjobdayhour";
            this.comboBoxjobdayhour.Size = new System.Drawing.Size(117, 22);
            this.comboBoxjobdayhour.TabIndex = 22;
            this.comboBoxjobdayhour.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
            this.comboBoxjobdayhour.WatermarkText = "Select job by not run in last type";
            this.comboBoxjobdayhour.DropDown += new System.EventHandler(this.comboBoxjobdayhour_DropDown);
            this.comboBoxjobdayhour.TextChanged += new System.EventHandler(this.comboBox_TextChanged);
            this.comboBoxjobdayhour.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_KeyDown);
            // 
            // buttonOk
            // 
            this.buttonOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(386, 449);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(145, 29);
            this.buttonOk.TabIndex = 11;
            this.buttonOk.Text = "C&heck Matching Jobs";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelSelection
            // 
            this.labelSelection.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelSelection.BackgroundStyle.Class = "";
            this.labelSelection.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelection.Location = new System.Drawing.Point(10, 9);
            this.labelSelection.Name = "labelSelection";
            this.labelSelection.Size = new System.Drawing.Size(516, 39);
            this.labelSelection.TabIndex = 9;
            this.labelSelection.Text = "Choose property values from the list below to check all matching jobs in the job " +
    "list. Wildcards can be used in text values to select similar names.";
            this.labelSelection.WordWrap = true;
            // 
            // SelectJobs
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(672, 481);
            this.Controls.Add(this.labelSelection);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.checkBoxClearSelections);
            this.Controls.Add(this.groupPanel_Main);
            this.Controls.Add(this.buttonCancel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(706, 520);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(706, 520);
            this.Name = "SelectJobs";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Check Jobs by Property Values";
            this.groupPanel_Main.ResumeLayout(false);
            this.groupPanel_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxClearSelections;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel_Main;
        private DevComponents.DotNetBar.ButtonX buttonOk;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.DotNetBar.LabelX labelCategory;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.DotNetBar.LabelX labelOwner;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.LabelX labelEnabled;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.DotNetBar.LabelX labelName;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.DotNetBar.LabelX labelOutcome;
        private DevComponents.DotNetBar.LabelX labelSelection;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.DotNetBar.LabelX labelLastRun;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.DotNetBar.LabelX labelNotification;
        private DevComponents.DotNetBar.ButtonX buttonClear;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxCaseSensitive;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxCategory;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxOwner;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEnabled;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxName;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxOutcome;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxLastRun;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxNotification;
        private DevComponents.DotNetBar.LabelX labeljobstatus;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxjobdayhour;
    }
}