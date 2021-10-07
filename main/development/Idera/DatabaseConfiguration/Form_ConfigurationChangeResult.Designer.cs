namespace Idera.SqlAdminToolset.DatabaseConfiguration
{
   partial class Form_ConfigurationChangeResult
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
         this.gridResults = new System.Windows.Forms.DataGridView();
         this.ColumnInstances = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.columnDatabaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnConfigurationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.columnResultsNewValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnResullt = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnErrorMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.btnOK = new DevComponents.DotNetBar.ButtonX();
         this.labelX1 = new DevComponents.DotNetBar.LabelX();
         ((System.ComponentModel.ISupportInitialize)(this.gridResults)).BeginInit();
         this.SuspendLayout();
         // 
         // gridResults
         // 
         this.gridResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.gridResults.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
         this.gridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.gridResults.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnInstances,
            this.columnDatabaseName,
            this.ColumnConfigurationName,
            this.columnResultsNewValue,
            this.ColumnResullt,
            this.ColumnErrorMessage} );
         this.gridResults.Location = new System.Drawing.Point( 2, 23 );
         this.gridResults.MultiSelect = false;
         this.gridResults.Name = "gridResults";
         this.gridResults.RowHeadersVisible = false;
         dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.gridResults.RowsDefaultCellStyle = dataGridViewCellStyle1;
         this.gridResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
         this.gridResults.Size = new System.Drawing.Size( 908, 349 );
         this.gridResults.TabIndex = 35;
         // 
         // ColumnInstances
         // 
         this.ColumnInstances.HeaderText = "SQL Server";
         this.ColumnInstances.Name = "ColumnInstances";
         this.ColumnInstances.Width = 180;
         // 
         // columnDatabaseName
         // 
         this.columnDatabaseName.HeaderText = "Database";
         this.columnDatabaseName.Name = "columnDatabaseName";
         // 
         // ColumnConfigurationName
         // 
         this.ColumnConfigurationName.HeaderText = "Configuration Name";
         this.ColumnConfigurationName.Name = "ColumnConfigurationName";
         this.ColumnConfigurationName.Width = 150;
         // 
         // columnResultsNewValue
         // 
         this.columnResultsNewValue.HeaderText = "New Value";
         this.columnResultsNewValue.Name = "columnResultsNewValue";
         // 
         // ColumnResullt
         // 
         this.ColumnResullt.HeaderText = "Result";
         this.ColumnResullt.Name = "ColumnResullt";
         this.ColumnResullt.Width = 75;
         // 
         // ColumnErrorMessage
         // 
         this.ColumnErrorMessage.HeaderText = "Error Message";
         this.ColumnErrorMessage.Name = "ColumnErrorMessage";
         this.ColumnErrorMessage.Width = 300;
         // 
         // btnOK
         // 
         this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point( 835, 378 );
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size( 75, 23 );
         this.btnOK.TabIndex = 34;
         this.btnOK.Text = "&OK";
         // 
         // labelX1
         // 
         this.labelX1.AutoSize = true;
         this.labelX1.Location = new System.Drawing.Point( 2, 4 );
         this.labelX1.Name = "labelX1";
         this.labelX1.Size = new System.Drawing.Size( 184, 15 );
         this.labelX1.TabIndex = 33;
         this.labelX1.Text = "Multiple configuration change results:";
         // 
         // Form_ConfigurationChangeResult
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.btnOK;
         this.ClientSize = new System.Drawing.Size( 922, 413 );
         this.Controls.Add( this.gridResults );
         this.Controls.Add( this.btnOK );
         this.Controls.Add( this.labelX1 );
         this.Name = "Form_ConfigurationChangeResult";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Configuration Change Results";
         ((System.ComponentModel.ISupportInitialize)(this.gridResults)).EndInit();
         this.ResumeLayout( false );
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.DataGridView gridResults;
      private DevComponents.DotNetBar.ButtonX btnOK;
      public DevComponents.DotNetBar.LabelX labelX1;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInstances;
      private System.Windows.Forms.DataGridViewTextBoxColumn columnDatabaseName;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnConfigurationName;
      private System.Windows.Forms.DataGridViewTextBoxColumn columnResultsNewValue;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnResullt;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnErrorMessage;
   }
}