namespace Idera.SqlAdminToolset.Core
{
   partial class Form_MultipleServerError
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
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_MultipleServerError ) );
         this.labelX1 = new DevComponents.DotNetBar.LabelX();
         this.btnOK = new DevComponents.DotNetBar.ButtonX();
         this.gridErrors = new System.Windows.Forms.DataGridView();
         this.ColumnInstances = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnErrMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.buttonClipboard = new DevComponents.DotNetBar.ButtonX();
         ((System.ComponentModel.ISupportInitialize)(this.gridErrors)).BeginInit();
         this.SuspendLayout();
         // 
         // labelX1
         // 
         this.labelX1.AutoSize = true;
         this.labelX1.Location = new System.Drawing.Point( 12, 14 );
         this.labelX1.Name = "labelX1";
         this.labelX1.Size = new System.Drawing.Size( 333, 15 );
         this.labelX1.TabIndex = 0;
         this.labelX1.Text = "Errors occurred trying to capture data for the following SQL Servers:";
         // 
         // btnOK
         // 
         this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point( 604, 362 );
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size( 75, 23 );
         this.btnOK.TabIndex = 31;
         this.btnOK.Text = "&OK";
         // 
         // gridErrors
         // 
         this.gridErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.gridErrors.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
         this.gridErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.gridErrors.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnInstances,
            this.ColumnErrMsg} );
         this.gridErrors.Location = new System.Drawing.Point( 12, 33 );
         this.gridErrors.MultiSelect = false;
         this.gridErrors.Name = "gridErrors";
         this.gridErrors.RowHeadersVisible = false;
         dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.gridErrors.RowsDefaultCellStyle = dataGridViewCellStyle1;
         this.gridErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
         this.gridErrors.Size = new System.Drawing.Size( 667, 323 );
         this.gridErrors.TabIndex = 32;
         // 
         // ColumnInstances
         // 
         this.ColumnInstances.HeaderText = "SQL Server";
         this.ColumnInstances.Name = "ColumnInstances";
         this.ColumnInstances.Width = 200;
         // 
         // ColumnErrMsg
         // 
         this.ColumnErrMsg.HeaderText = "Error Message";
         this.ColumnErrMsg.Name = "ColumnErrMsg";
         this.ColumnErrMsg.Width = 450;
         // 
         // buttonClipboard
         // 
         this.buttonClipboard.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonClipboard.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonClipboard.Location = new System.Drawing.Point( 12, 362 );
         this.buttonClipboard.Name = "buttonClipboard";
         this.buttonClipboard.Size = new System.Drawing.Size( 116, 23 );
         this.buttonClipboard.TabIndex = 33;
         this.buttonClipboard.Text = "&Copy to Clipboard";
         this.buttonClipboard.Click += new System.EventHandler( this.buttonClipboard_Click );
         // 
         // Form_MultipleServerError
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.btnOK;
         this.ClientSize = new System.Drawing.Size( 687, 391 );
         this.Controls.Add( this.buttonClipboard );
         this.Controls.Add( this.gridErrors );
         this.Controls.Add( this.btnOK );
         this.Controls.Add( this.labelX1 );
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MinimumSize = new System.Drawing.Size( 486, 306 );
         this.Name = "Form_MultipleServerError";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Error capturing data";
         ((System.ComponentModel.ISupportInitialize)(this.gridErrors)).EndInit();
         this.ResumeLayout( false );
         this.PerformLayout();

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX btnOK;
      public DevComponents.DotNetBar.LabelX labelX1;
      private System.Windows.Forms.DataGridView gridErrors;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInstances;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnErrMsg;
      private DevComponents.DotNetBar.ButtonX buttonClipboard;
   }
}