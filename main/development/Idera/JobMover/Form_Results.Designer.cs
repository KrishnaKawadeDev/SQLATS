namespace Idera.SqlAdminToolset.JobMover
{
   partial class Form_Results
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
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
         this.buttonOk = new DevComponents.DotNetBar.ButtonX();
         this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
         this.dataGridViewResults = new DevComponents.DotNetBar.Controls.DataGridViewX();
         this.Object = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.labelResults = new DevComponents.DotNetBar.LabelX();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
         this.SuspendLayout();
         // 
         // buttonOk
         // 
         this.buttonOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOk.Enabled = false;
         this.buttonOk.Location = new System.Drawing.Point(462, 386);
         this.buttonOk.Name = "buttonOk";
         this.buttonOk.Size = new System.Drawing.Size(81, 29);
         this.buttonOk.TabIndex = 1;
         this.buttonOk.Text = "C&ontinue";
         this.buttonOk.Visible = false;
         // 
         // buttonCancel
         // 
         this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(549, 386);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(81, 29);
         this.buttonCancel.TabIndex = 2;
         this.buttonCancel.Text = "&Cancel";
         // 
         // dataGridViewResults
         // 
         this.dataGridViewResults.AllowUserToAddRows = false;
         this.dataGridViewResults.AllowUserToDeleteRows = false;
         this.dataGridViewResults.AllowUserToOrderColumns = true;
         this.dataGridViewResults.AllowUserToResizeRows = false;
         dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
         this.dataGridViewResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
         this.dataGridViewResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.dataGridViewResults.BackgroundColor = System.Drawing.Color.WhiteSmoke;
         dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
         dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
         dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
         dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.dataGridViewResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
         this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
         this.dataGridViewResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Object,
            this.Value});
         dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
         dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
         dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
         dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
         dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
         this.dataGridViewResults.DefaultCellStyle = dataGridViewCellStyle3;
         this.dataGridViewResults.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
         this.dataGridViewResults.HighlightSelectedColumnHeaders = false;
         this.dataGridViewResults.Location = new System.Drawing.Point(12, 49);
         this.dataGridViewResults.Name = "dataGridViewResults";
         dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
         dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
         dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
         dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.dataGridViewResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
         this.dataGridViewResults.RowHeadersVisible = false;
         this.dataGridViewResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.dataGridViewResults.ShowEditingIcon = false;
         this.dataGridViewResults.Size = new System.Drawing.Size(622, 329);
         this.dataGridViewResults.TabIndex = 0;
         // 
         // Object
         // 
         this.Object.HeaderText = "Task";
         this.Object.Name = "Object";
         this.Object.Width = 200;
         // 
         // Value
         // 
         this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
         this.Value.HeaderText = "Result";
         this.Value.Name = "Value";
         // 
         // labelResults
         // 
         this.labelResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.labelResults.BackColor = System.Drawing.Color.Transparent;
         this.labelResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelResults.Location = new System.Drawing.Point(12, 4);
         this.labelResults.Name = "labelResults";
         this.labelResults.Size = new System.Drawing.Size(622, 39);
         this.labelResults.TabIndex = 36;
         this.labelResults.Text = "Results description";
         this.labelResults.WordWrap = true;
         // 
         // Form_Results
         // 
         this.AcceptButton = this.buttonOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(646, 423);
         this.Controls.Add(this.labelResults);
         this.Controls.Add(this.dataGridViewResults);
         this.Controls.Add(this.buttonOk);
         this.Controls.Add(this.buttonCancel);
         this.MinimizeBox = false;
         this.Name = "Form_Results";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Job Mover Results";
         this.Shown += new System.EventHandler(this.Form_Results_Shown);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX buttonOk;
      private DevComponents.DotNetBar.ButtonX buttonCancel;
      private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewResults;
      private System.Windows.Forms.DataGridViewTextBoxColumn Object;
      private System.Windows.Forms.DataGridViewTextBoxColumn Value;
      private DevComponents.DotNetBar.LabelX labelResults;
   }
}