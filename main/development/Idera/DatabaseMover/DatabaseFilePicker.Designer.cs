namespace Idera.SqlAdminToolset.DatabaseMover
{
   partial class DatabaseFilePicker
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
         this.dataGridFileOptions = new DevComponents.DotNetBar.Controls.DataGridViewX();
         this.columnLogicalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.columnFileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.columnFilePath = new Idera.SqlAdminToolset.DatabaseMover.DatabaseFilePicker.CustomTextColumn();
         this.columnFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridFileOptions)).BeginInit();
         this.SuspendLayout();
         // 
         // dataGridFileOptions
         // 
         this.dataGridFileOptions.AllowUserToAddRows = false;
         this.dataGridFileOptions.AllowUserToDeleteRows = false;
         this.dataGridFileOptions.AllowUserToResizeRows = false;
         this.dataGridFileOptions.BackgroundColor = System.Drawing.Color.White;
         dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
         dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
         dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
         dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.dataGridFileOptions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
         this.dataGridFileOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridFileOptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnLogicalName,
            this.columnFileType,
            this.columnFilePath,
            this.columnFileName});
         dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
         dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(57)))), ((int)(((byte)(129)))));
         dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
         dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(57)))), ((int)(((byte)(129)))));
         dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
         this.dataGridFileOptions.DefaultCellStyle = dataGridViewCellStyle2;
         this.dataGridFileOptions.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridFileOptions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
         this.dataGridFileOptions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
         this.dataGridFileOptions.Location = new System.Drawing.Point(0, 0);
         this.dataGridFileOptions.Name = "dataGridFileOptions";
         dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
         dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
         dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
         dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.dataGridFileOptions.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
         this.dataGridFileOptions.RowHeadersVisible = false;
         this.dataGridFileOptions.SelectAllSignVisible = false;
         this.dataGridFileOptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
         this.dataGridFileOptions.Size = new System.Drawing.Size(668, 181);
         this.dataGridFileOptions.TabIndex = 11;
         this.dataGridFileOptions.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridFileOptions_CellValidating);
         this.dataGridFileOptions.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridFileOptions_CellEndEdit);
         // 
         // columnLogicalName
         // 
         this.columnLogicalName.HeaderText = "Logical Name";
         this.columnLogicalName.Name = "columnLogicalName";
         this.columnLogicalName.Width = 110;
         // 
         // columnFileType
         // 
         this.columnFileType.HeaderText = "File Type";
         this.columnFileType.Name = "columnFileType";
         this.columnFileType.ReadOnly = true;
         this.columnFileType.Width = 73;
         // 
         // columnFilePath
         // 
         this.columnFilePath.HeaderText = "File Path";
         this.columnFilePath.Name = "columnFilePath";
         this.columnFilePath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
         this.columnFilePath.Width = 357;
         // 
         // columnFileName
         // 
         this.columnFileName.HeaderText = "File Name";
         this.columnFileName.Name = "columnFileName";
         this.columnFileName.Width = 125;
         // 
         // DatabaseFilePicker
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.Transparent;
         this.Controls.Add(this.dataGridFileOptions);
         this.Name = "DatabaseFilePicker";
         this.Size = new System.Drawing.Size(668, 181);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridFileOptions)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevComponents.DotNetBar.Controls.DataGridViewX dataGridFileOptions;
      private System.Windows.Forms.DataGridViewTextBoxColumn columnLogicalName;
      private System.Windows.Forms.DataGridViewTextBoxColumn columnFileType;
      private DatabaseFilePicker.CustomTextColumn columnFilePath;
      private System.Windows.Forms.DataGridViewTextBoxColumn columnFileName;

   }
}
