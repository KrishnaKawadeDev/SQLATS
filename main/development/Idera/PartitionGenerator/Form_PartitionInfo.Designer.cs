namespace Idera.SqlAdminToolset.PartitionGenerator
{
   partial class Form_PartitionInfo
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
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_PartitionInfo ) );
         this.panelMiddle = new System.Windows.Forms.Panel();
         this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.textIndex = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.labelX7 = new DevComponents.DotNetBar.LabelX();
         this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
         this.textDataType = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.labelX6 = new DevComponents.DotNetBar.LabelX();
         this.linkAddNewRange = new System.Windows.Forms.LinkLabel();
         this.labelX5 = new DevComponents.DotNetBar.LabelX();
         this.buttonOk = new DevComponents.DotNetBar.ButtonX();
         this.gridRanges = new DevComponents.DotNetBar.Controls.DataGridViewX();
         this.columnMinimum = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.columnMaximum = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.columnFileGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
         this.columnRowCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.columnSplit = new System.Windows.Forms.DataGridViewImageColumn();
         this.columnMerge = new System.Windows.Forms.DataGridViewImageColumn();
         this.labelX4 = new DevComponents.DotNetBar.LabelX();
         this.textSchemeName = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.labelX2 = new DevComponents.DotNetBar.LabelX();
         this.textFunctionName = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.labelX3 = new DevComponents.DotNetBar.LabelX();
         this.labelX1 = new DevComponents.DotNetBar.LabelX();
         this.textTableName = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.labelServer = new DevComponents.DotNetBar.LabelX();
         this.listBoundaryType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
         this.BoundaryLeft = new DevComponents.Editors.ComboItem();
         this.BoundaryRight = new DevComponents.Editors.ComboItem();
         this.textColumnName = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.listColumns = new DevComponents.DotNetBar.Controls.ComboBoxEx();
         this.textBoundaryType = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.panelMiddle.SuspendLayout();
         this.groupPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.gridRanges)).BeginInit();
         this.SuspendLayout();
         // 
         // panelMiddle
         // 
         this.panelMiddle.Controls.Add( this.groupPanel1 );
         this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelMiddle.Location = new System.Drawing.Point( 0, 0 );
         this.panelMiddle.Name = "panelMiddle";
         this.panelMiddle.Padding = new System.Windows.Forms.Padding( 6 );
         this.panelMiddle.Size = new System.Drawing.Size( 595, 435 );
         this.panelMiddle.TabIndex = 19;
         // 
         // groupPanel1
         // 
         this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel1.Controls.Add( this.textIndex );
         this.groupPanel1.Controls.Add( this.labelX7 );
         this.groupPanel1.Controls.Add( this.buttonCancel );
         this.groupPanel1.Controls.Add( this.textDataType );
         this.groupPanel1.Controls.Add( this.labelX6 );
         this.groupPanel1.Controls.Add( this.linkAddNewRange );
         this.groupPanel1.Controls.Add( this.labelX5 );
         this.groupPanel1.Controls.Add( this.buttonOk );
         this.groupPanel1.Controls.Add( this.gridRanges );
         this.groupPanel1.Controls.Add( this.labelX4 );
         this.groupPanel1.Controls.Add( this.textSchemeName );
         this.groupPanel1.Controls.Add( this.labelX2 );
         this.groupPanel1.Controls.Add( this.textFunctionName );
         this.groupPanel1.Controls.Add( this.labelX3 );
         this.groupPanel1.Controls.Add( this.labelX1 );
         this.groupPanel1.Controls.Add( this.textTableName );
         this.groupPanel1.Controls.Add( this.labelServer );
         this.groupPanel1.Controls.Add( this.listBoundaryType );
         this.groupPanel1.Controls.Add( this.textColumnName );
         this.groupPanel1.Controls.Add( this.listColumns );
         this.groupPanel1.Controls.Add( this.textBoundaryType );
         this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupPanel1.IsShadowEnabled = true;
         this.groupPanel1.Location = new System.Drawing.Point( 6, 6 );
         this.groupPanel1.Name = "groupPanel1";
         this.groupPanel1.Size = new System.Drawing.Size( 583, 423 );
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
         // 
         // textIndex
         // 
         this.textIndex.BackColor = System.Drawing.SystemColors.Window;
         // 
         // 
         // 
         this.textIndex.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textIndex.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textIndex.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textIndex.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textIndex.Border.Class = "TextBoxBorder";
         this.textIndex.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
         this.textIndex.Location = new System.Drawing.Point( 98, 95 );
         this.textIndex.Name = "textIndex";
         this.textIndex.Size = new System.Drawing.Size( 184, 20 );
         this.textIndex.TabIndex = 34;
         this.textIndex.WatermarkText = "Optional";
         // 
         // labelX7
         // 
         this.labelX7.AutoSize = true;
         this.labelX7.BackColor = System.Drawing.Color.Transparent;
         this.labelX7.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
         this.labelX7.Location = new System.Drawing.Point( 12, 98 );
         this.labelX7.Name = "labelX7";
         this.labelX7.Size = new System.Drawing.Size( 90, 15 );
         this.labelX7.TabIndex = 35;
         this.labelX7.Text = "Clustered &Index:";
         // 
         // buttonCancel
         // 
         this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonCancel.Location = new System.Drawing.Point( 489, 391 );
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size( 75, 23 );
         this.buttonCancel.TabIndex = 33;
         this.buttonCancel.Text = "&Cancel";
         this.buttonCancel.Click += new System.EventHandler( this.buttonCancel_Click );
         // 
         // textDataType
         // 
         this.textDataType.BackColor = System.Drawing.SystemColors.Window;
         // 
         // 
         // 
         this.textDataType.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textDataType.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textDataType.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textDataType.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textDataType.Border.Class = "TextBoxBorder";
         this.textDataType.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
         this.textDataType.Location = new System.Drawing.Point( 380, 70 );
         this.textDataType.Name = "textDataType";
         this.textDataType.ReadOnly = true;
         this.textDataType.Size = new System.Drawing.Size( 184, 20 );
         this.textDataType.TabIndex = 6;
         // 
         // labelX6
         // 
         this.labelX6.AutoSize = true;
         this.labelX6.BackColor = System.Drawing.Color.Transparent;
         this.labelX6.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
         this.labelX6.Location = new System.Drawing.Point( 310, 75 );
         this.labelX6.Name = "labelX6";
         this.labelX6.Size = new System.Drawing.Size( 64, 15 );
         this.labelX6.TabIndex = 32;
         this.labelX6.Text = "&Data Type:";
         // 
         // linkAddNewRange
         // 
         this.linkAddNewRange.AutoSize = true;
         this.linkAddNewRange.BackColor = System.Drawing.Color.Transparent;
         this.linkAddNewRange.Location = new System.Drawing.Point( 101, 131 );
         this.linkAddNewRange.Name = "linkAddNewRange";
         this.linkAddNewRange.Size = new System.Drawing.Size( 51, 13 );
         this.linkAddNewRange.TabIndex = 7;
         this.linkAddNewRange.TabStop = true;
         this.linkAddNewRange.Text = "Add New";
         this.linkAddNewRange.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.linkAddNewRange_LinkClicked );
         // 
         // labelX5
         // 
         this.labelX5.AutoSize = true;
         this.labelX5.BackColor = System.Drawing.Color.Transparent;
         this.labelX5.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
         this.labelX5.Location = new System.Drawing.Point( 12, 69 );
         this.labelX5.Name = "labelX5";
         this.labelX5.Size = new System.Drawing.Size( 87, 15 );
         this.labelX5.TabIndex = 14;
         this.labelX5.Text = "&Boundary Type:";
         // 
         // buttonOk
         // 
         this.buttonOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonOk.Location = new System.Drawing.Point( 408, 391 );
         this.buttonOk.Name = "buttonOk";
         this.buttonOk.Size = new System.Drawing.Size( 75, 23 );
         this.buttonOk.TabIndex = 9;
         this.buttonOk.Text = "&OK";
         this.buttonOk.Click += new System.EventHandler( this.buttonOk_Click );
         // 
         // gridRanges
         // 
         this.gridRanges.AllowUserToAddRows = false;
         this.gridRanges.AllowUserToDeleteRows = false;
         this.gridRanges.AllowUserToResizeRows = false;
         this.gridRanges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         this.gridRanges.BackgroundColor = System.Drawing.Color.White;
         dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
         dataGridViewCellStyle1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
         dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
         dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
         dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.gridRanges.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
         this.gridRanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.gridRanges.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.columnMinimum,
            this.columnMaximum,
            this.columnFileGroup,
            this.columnRowCount,
            this.columnSplit,
            this.columnMerge} );
         dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
         dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
         dataGridViewCellStyle2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
         dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
         dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
         dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
         dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
         this.gridRanges.DefaultCellStyle = dataGridViewCellStyle2;
         this.gridRanges.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
         this.gridRanges.GridColor = System.Drawing.Color.FromArgb( ((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))) );
         this.gridRanges.HighlightSelectedColumnHeaders = false;
         this.gridRanges.Location = new System.Drawing.Point( 12, 150 );
         this.gridRanges.MultiSelect = false;
         this.gridRanges.Name = "gridRanges";
         this.gridRanges.RowHeadersVisible = false;
         this.gridRanges.SelectAllSignVisible = false;
         this.gridRanges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
         this.gridRanges.ShowEditingIcon = false;
         this.gridRanges.Size = new System.Drawing.Size( 552, 232 );
         this.gridRanges.TabIndex = 8;
         this.gridRanges.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler( this.gridRanges_CellBeginEdit );
         this.gridRanges.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler( this.gridRanges_CellEndEdit );
         this.gridRanges.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler( this.gridRanges_CellContentClick );
         // 
         // columnMinimum
         // 
         this.columnMinimum.FillWeight = 60F;
         this.columnMinimum.HeaderText = "Minimum";
         this.columnMinimum.Name = "columnMinimum";
         this.columnMinimum.ReadOnly = true;
         this.columnMinimum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
         // 
         // columnMaximum
         // 
         this.columnMaximum.FillWeight = 60F;
         this.columnMaximum.HeaderText = "Maximum";
         this.columnMaximum.Name = "columnMaximum";
         this.columnMaximum.ReadOnly = true;
         this.columnMaximum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
         // 
         // columnFileGroup
         // 
         this.columnFileGroup.FillWeight = 120F;
         this.columnFileGroup.HeaderText = "File Group";
         this.columnFileGroup.Name = "columnFileGroup";
         this.columnFileGroup.ReadOnly = true;
         this.columnFileGroup.Resizable = System.Windows.Forms.DataGridViewTriState.True;
         // 
         // columnRowCount
         // 
         this.columnRowCount.FillWeight = 60F;
         this.columnRowCount.HeaderText = "Row Count";
         this.columnRowCount.Name = "columnRowCount";
         // 
         // columnSplit
         // 
         this.columnSplit.FillWeight = 45F;
         this.columnSplit.HeaderText = "Split";
         this.columnSplit.Image = ((System.Drawing.Image)(resources.GetObject( "columnSplit.Image" )));
         this.columnSplit.Name = "columnSplit";
         this.columnSplit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
         // 
         // columnMerge
         // 
         this.columnMerge.FillWeight = 45F;
         this.columnMerge.HeaderText = "Merge";
         this.columnMerge.Image = ((System.Drawing.Image)(resources.GetObject( "columnMerge.Image" )));
         this.columnMerge.Name = "columnMerge";
         this.columnMerge.Resizable = System.Windows.Forms.DataGridViewTriState.False;
         // 
         // labelX4
         // 
         this.labelX4.AutoSize = true;
         this.labelX4.BackColor = System.Drawing.Color.Transparent;
         this.labelX4.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
         this.labelX4.Location = new System.Drawing.Point( 12, 129 );
         this.labelX4.Name = "labelX4";
         this.labelX4.Size = new System.Drawing.Size( 82, 15 );
         this.labelX4.TabIndex = 11;
         this.labelX4.Text = "&Range Values:";
         // 
         // textSchemeName
         // 
         this.textSchemeName.BackColor = System.Drawing.SystemColors.Window;
         // 
         // 
         // 
         this.textSchemeName.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textSchemeName.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textSchemeName.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textSchemeName.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textSchemeName.Border.Class = "TextBoxBorder";
         this.textSchemeName.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
         this.textSchemeName.Location = new System.Drawing.Point( 380, 40 );
         this.textSchemeName.Name = "textSchemeName";
         this.textSchemeName.Size = new System.Drawing.Size( 184, 20 );
         this.textSchemeName.TabIndex = 4;
         // 
         // labelX2
         // 
         this.labelX2.AutoSize = true;
         this.labelX2.BackColor = System.Drawing.Color.Transparent;
         this.labelX2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
         this.labelX2.Location = new System.Drawing.Point( 310, 45 );
         this.labelX2.Name = "labelX2";
         this.labelX2.Size = new System.Drawing.Size( 53, 15 );
         this.labelX2.TabIndex = 9;
         this.labelX2.Text = "&Scheme:";
         // 
         // textFunctionName
         // 
         this.textFunctionName.BackColor = System.Drawing.SystemColors.Window;
         // 
         // 
         // 
         this.textFunctionName.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textFunctionName.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textFunctionName.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textFunctionName.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textFunctionName.Border.Class = "TextBoxBorder";
         this.textFunctionName.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
         this.textFunctionName.Location = new System.Drawing.Point( 98, 35 );
         this.textFunctionName.Name = "textFunctionName";
         this.textFunctionName.Size = new System.Drawing.Size( 184, 20 );
         this.textFunctionName.TabIndex = 3;
         // 
         // labelX3
         // 
         this.labelX3.AutoSize = true;
         this.labelX3.BackColor = System.Drawing.Color.Transparent;
         this.labelX3.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
         this.labelX3.Location = new System.Drawing.Point( 12, 40 );
         this.labelX3.Name = "labelX3";
         this.labelX3.Size = new System.Drawing.Size( 55, 15 );
         this.labelX3.TabIndex = 7;
         this.labelX3.Text = "&Function:";
         // 
         // labelX1
         // 
         this.labelX1.AutoSize = true;
         this.labelX1.BackColor = System.Drawing.Color.Transparent;
         this.labelX1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
         this.labelX1.Location = new System.Drawing.Point( 310, 17 );
         this.labelX1.Name = "labelX1";
         this.labelX1.Size = new System.Drawing.Size( 51, 15 );
         this.labelX1.TabIndex = 5;
         this.labelX1.Text = "&Column:";
         // 
         // textTableName
         // 
         this.textTableName.BackColor = System.Drawing.SystemColors.Window;
         // 
         // 
         // 
         this.textTableName.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textTableName.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textTableName.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textTableName.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textTableName.Border.Class = "TextBoxBorder";
         this.textTableName.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
         this.textTableName.Location = new System.Drawing.Point( 98, 7 );
         this.textTableName.Name = "textTableName";
         this.textTableName.ReadOnly = true;
         this.textTableName.Size = new System.Drawing.Size( 184, 20 );
         this.textTableName.TabIndex = 1;
         // 
         // labelServer
         // 
         this.labelServer.AutoSize = true;
         this.labelServer.BackColor = System.Drawing.Color.Transparent;
         this.labelServer.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
         this.labelServer.Location = new System.Drawing.Point( 12, 13 );
         this.labelServer.Name = "labelServer";
         this.labelServer.Size = new System.Drawing.Size( 40, 15 );
         this.labelServer.TabIndex = 3;
         this.labelServer.Text = "&Table:";
         // 
         // listBoundaryType
         // 
         this.listBoundaryType.DisplayMember = "Text";
         this.listBoundaryType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this.listBoundaryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.listBoundaryType.FormattingEnabled = true;
         this.listBoundaryType.ItemHeight = 14;
         this.listBoundaryType.Items.AddRange( new object[] {
            this.BoundaryLeft,
            this.BoundaryRight} );
         this.listBoundaryType.Location = new System.Drawing.Point( 98, 65 );
         this.listBoundaryType.Name = "listBoundaryType";
         this.listBoundaryType.Size = new System.Drawing.Size( 184, 20 );
         this.listBoundaryType.TabIndex = 5;
         this.listBoundaryType.SelectedIndexChanged += new System.EventHandler( this.listBoundaryType_SelectedIndexChanged );
         // 
         // BoundaryLeft
         // 
         this.BoundaryLeft.Text = "LEFT";
         // 
         // BoundaryRight
         // 
         this.BoundaryRight.Text = "RIGHT";
         // 
         // textColumnName
         // 
         this.textColumnName.BackColor = System.Drawing.SystemColors.Window;
         // 
         // 
         // 
         this.textColumnName.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textColumnName.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textColumnName.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textColumnName.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textColumnName.Border.Class = "TextBoxBorder";
         this.textColumnName.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
         this.textColumnName.Location = new System.Drawing.Point( 380, 13 );
         this.textColumnName.Name = "textColumnName";
         this.textColumnName.Size = new System.Drawing.Size( 184, 20 );
         this.textColumnName.TabIndex = 2;
         // 
         // listColumns
         // 
         this.listColumns.DisplayMember = "Text";
         this.listColumns.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this.listColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.listColumns.FormattingEnabled = true;
         this.listColumns.ItemHeight = 14;
         this.listColumns.Location = new System.Drawing.Point( 380, 13 );
         this.listColumns.Name = "listColumns";
         this.listColumns.Size = new System.Drawing.Size( 184, 20 );
         this.listColumns.TabIndex = 2;
         this.listColumns.SelectedIndexChanged += new System.EventHandler( this.listColumns_SelectedIndexChanged );
         // 
         // textBoundaryType
         // 
         this.textBoundaryType.BackColor = System.Drawing.SystemColors.Window;
         // 
         // 
         // 
         this.textBoundaryType.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textBoundaryType.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textBoundaryType.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textBoundaryType.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.textBoundaryType.Border.Class = "TextBoxBorder";
         this.textBoundaryType.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F );
         this.textBoundaryType.Location = new System.Drawing.Point( 98, 65 );
         this.textBoundaryType.Name = "textBoundaryType";
         this.textBoundaryType.Size = new System.Drawing.Size( 184, 20 );
         this.textBoundaryType.TabIndex = 5;
         // 
         // Form_PartitionInfo
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.ClientSize = new System.Drawing.Size( 595, 435 );
         this.Controls.Add( this.panelMiddle );
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form_PartitionInfo";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Partition Information";
         this.panelMiddle.ResumeLayout( false );
         this.groupPanel1.ResumeLayout( false );
         this.groupPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.gridRanges)).EndInit();
         this.ResumeLayout( false );

      }

      #endregion

      private System.Windows.Forms.Panel panelMiddle;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.Controls.TextBoxX textColumnName;
      private DevComponents.DotNetBar.LabelX labelX1;
      private DevComponents.DotNetBar.Controls.TextBoxX textTableName;
      private DevComponents.DotNetBar.LabelX labelServer;
      private DevComponents.DotNetBar.Controls.TextBoxX textSchemeName;
      private DevComponents.DotNetBar.LabelX labelX2;
      private DevComponents.DotNetBar.Controls.TextBoxX textFunctionName;
      private DevComponents.DotNetBar.LabelX labelX3;
      private DevComponents.DotNetBar.LabelX labelX4;
      private DevComponents.DotNetBar.Controls.DataGridViewX gridRanges;
      private DevComponents.DotNetBar.ButtonX buttonOk;
      private DevComponents.DotNetBar.LabelX labelX5;
      private DevComponents.DotNetBar.Controls.ComboBoxEx listBoundaryType;
      private DevComponents.Editors.ComboItem BoundaryLeft;
      private DevComponents.Editors.ComboItem BoundaryRight;
      private DevComponents.DotNetBar.Controls.TextBoxX textBoundaryType;
      private DevComponents.DotNetBar.Controls.ComboBoxEx listColumns;
      private System.Windows.Forms.LinkLabel linkAddNewRange;
      private DevComponents.DotNetBar.Controls.TextBoxX textDataType;
      private DevComponents.DotNetBar.LabelX labelX6;
      private DevComponents.DotNetBar.ButtonX buttonCancel;
      private DevComponents.DotNetBar.Controls.TextBoxX textIndex;
      private DevComponents.DotNetBar.LabelX labelX7;
      private System.Windows.Forms.DataGridViewTextBoxColumn columnMinimum;
      private System.Windows.Forms.DataGridViewTextBoxColumn columnMaximum;
      private System.Windows.Forms.DataGridViewComboBoxColumn columnFileGroup;
      private System.Windows.Forms.DataGridViewTextBoxColumn columnRowCount;
      private System.Windows.Forms.DataGridViewImageColumn columnSplit;
      private System.Windows.Forms.DataGridViewImageColumn columnMerge;

   }
}