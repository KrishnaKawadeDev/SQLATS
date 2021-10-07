namespace Idera.SqlAdminToolset.DatabaseConfiguration
{
   partial class Form_EditConfiguration
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
          this.labelX1 = new DevComponents.DotNetBar.LabelX();
          this.labelX2 = new DevComponents.DotNetBar.LabelX();
          this.labelConfigurationName = new DevComponents.DotNetBar.LabelX();
          this.buttonOK = new DevComponents.DotNetBar.ButtonX();
          this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
          this.listNewValue = new DevComponents.DotNetBar.Controls.ComboBoxEx();
          this.labelDatabases = new DevComponents.DotNetBar.LabelX();
          this.listUpdateDatabaseList = new System.Windows.Forms.CheckedListBox();
          this.SuspendLayout();
          // 
          // labelX1
          // 
          this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.labelX1.Location = new System.Drawing.Point(12, 12);
          this.labelX1.Name = "labelX1";
          this.labelX1.Size = new System.Drawing.Size(48, 23);
          this.labelX1.TabIndex = 1;
          this.labelX1.Text = "Name:";
          // 
          // labelX2
          // 
          this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.labelX2.Location = new System.Drawing.Point(12, 41);
          this.labelX2.Name = "labelX2";
          this.labelX2.Size = new System.Drawing.Size(61, 23);
          this.labelX2.TabIndex = 2;
          this.labelX2.Text = "New Value:";
          // 
          // labelConfigurationName
          // 
          this.labelConfigurationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.labelConfigurationName.Location = new System.Drawing.Point(79, 12);
          this.labelConfigurationName.Name = "labelConfigurationName";
          this.labelConfigurationName.Size = new System.Drawing.Size(298, 23);
          this.labelConfigurationName.TabIndex = 3;
          this.labelConfigurationName.Text = "Name";
          // 
          // buttonOK
          // 
          this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
          this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
          this.buttonOK.Location = new System.Drawing.Point(202, 335);
          this.buttonOK.Name = "buttonOK";
          this.buttonOK.Size = new System.Drawing.Size(75, 23);
          this.buttonOK.TabIndex = 5;
          this.buttonOK.Text = "OK";
          this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
          // 
          // buttonCancel
          // 
          this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
          this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
          this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.buttonCancel.Location = new System.Drawing.Point(291, 335);
          this.buttonCancel.Name = "buttonCancel";
          this.buttonCancel.Size = new System.Drawing.Size(75, 23);
          this.buttonCancel.TabIndex = 6;
          this.buttonCancel.Text = "Cancel";
          this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
          // 
          // listNewValue
          // 
          this.listNewValue.DisplayMember = "value";
          this.listNewValue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
          this.listNewValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.listNewValue.FormattingEnabled = true;
          this.listNewValue.ItemHeight = 14;
          this.listNewValue.Location = new System.Drawing.Point(79, 42);
          this.listNewValue.Name = "listNewValue";
          this.listNewValue.Size = new System.Drawing.Size(287, 20);
          this.listNewValue.TabIndex = 7;
          this.listNewValue.ValueMember = "key";
          // 
          // labelDatabases
          // 
          this.labelDatabases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.labelDatabases.Location = new System.Drawing.Point(12, 79);
          this.labelDatabases.Name = "labelDatabases";
          this.labelDatabases.Size = new System.Drawing.Size(58, 23);
          this.labelDatabases.TabIndex = 11;
          this.labelDatabases.Text = "Databases:";
          // 
          // listUpdateDatabaseList
          // 
          this.listUpdateDatabaseList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.listUpdateDatabaseList.CheckOnClick = true;
          this.listUpdateDatabaseList.FormattingEnabled = true;
          this.listUpdateDatabaseList.Location = new System.Drawing.Point(79, 79);
          this.listUpdateDatabaseList.Name = "listUpdateDatabaseList";
          this.listUpdateDatabaseList.Size = new System.Drawing.Size(287, 244);
          this.listUpdateDatabaseList.TabIndex = 12;
          this.listUpdateDatabaseList.Visible = false;
          // 
          // Form_EditConfiguration
          // 
          this.AcceptButton = this.buttonOK;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.White;
          this.CancelButton = this.buttonCancel;
          this.ClientSize = new System.Drawing.Size(378, 366);
          this.Controls.Add(this.labelDatabases);
          this.Controls.Add(this.listUpdateDatabaseList);
          this.Controls.Add(this.listNewValue);
          this.Controls.Add(this.buttonCancel);
          this.Controls.Add(this.buttonOK);
          this.Controls.Add(this.labelConfigurationName);
          this.Controls.Add(this.labelX2);
          this.Controls.Add(this.labelX1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "Form_EditConfiguration";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Edit Configuration Value";
          this.ResumeLayout(false);

      }

      #endregion

      private DevComponents.DotNetBar.LabelX labelX1;
      private DevComponents.DotNetBar.LabelX labelX2;
      private DevComponents.DotNetBar.LabelX labelConfigurationName;
      private DevComponents.DotNetBar.ButtonX buttonOK;
      private DevComponents.DotNetBar.ButtonX buttonCancel;
      private DevComponents.DotNetBar.Controls.ComboBoxEx listNewValue;
      private DevComponents.DotNetBar.LabelX labelDatabases;
      private System.Windows.Forms.CheckedListBox listUpdateDatabaseList;
   }
}