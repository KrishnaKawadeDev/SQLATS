namespace Idera.SqlAdminToolset.ServerConfiguration
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_EditConfiguration));
          this.labelChangeInstructions = new DevComponents.DotNetBar.LabelX();
          this.labelX1 = new DevComponents.DotNetBar.LabelX();
          this.labelX2 = new DevComponents.DotNetBar.LabelX();
          this.labelConfigurationName = new DevComponents.DotNetBar.LabelX();
          this.buttonOK = new DevComponents.DotNetBar.ButtonX();
          this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
          this.textNewValue = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
          this.labelServers = new DevComponents.DotNetBar.LabelX();
          this.listUpdateServerList = new System.Windows.Forms.CheckedListBox();
          this.dropDownNewValue = new DevComponents.DotNetBar.Controls.ComboBoxEx();
          this.SuspendLayout();
          // 
          // labelChangeInstructions
          // 
          this.labelChangeInstructions.Image = ((System.Drawing.Image)(resources.GetObject("labelChangeInstructions.Image")));
          this.labelChangeInstructions.Location = new System.Drawing.Point(16, 13);
          this.labelChangeInstructions.Name = "labelChangeInstructions";
          this.labelChangeInstructions.Size = new System.Drawing.Size(305, 62);
          this.labelChangeInstructions.TabIndex = 0;
          this.labelChangeInstructions.Text = "labelX1";
          this.labelChangeInstructions.WordWrap = true;
          // 
          // labelX1
          // 
          this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.labelX1.Location = new System.Drawing.Point(16, 81);
          this.labelX1.Name = "labelX1";
          this.labelX1.Size = new System.Drawing.Size(48, 23);
          this.labelX1.TabIndex = 1;
          this.labelX1.Text = "Name:";
          // 
          // labelX2
          // 
          this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.labelX2.Location = new System.Drawing.Point(16, 110);
          this.labelX2.Name = "labelX2";
          this.labelX2.Size = new System.Drawing.Size(67, 23);
          this.labelX2.TabIndex = 2;
          this.labelX2.Text = "New Value:";
          // 
          // labelConfigurationName
          // 
          this.labelConfigurationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.labelConfigurationName.Location = new System.Drawing.Point(80, 81);
          this.labelConfigurationName.Name = "labelConfigurationName";
          this.labelConfigurationName.Size = new System.Drawing.Size(232, 23);
          this.labelConfigurationName.TabIndex = 3;
          this.labelConfigurationName.Text = "Name:";
          // 
          // buttonOK
          // 
          this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
          this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
          this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
          this.buttonOK.Enabled = false;
          this.buttonOK.Location = new System.Drawing.Point(149, 314);
          this.buttonOK.Name = "buttonOK";
          this.buttonOK.Size = new System.Drawing.Size(75, 23);
          this.buttonOK.TabIndex = 5;
          this.buttonOK.Text = "OK";
          this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
          // 
          // buttonCancel
          // 
          this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
          this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
          this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
          this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.buttonCancel.Location = new System.Drawing.Point(238, 314);
          this.buttonCancel.Name = "buttonCancel";
          this.buttonCancel.Size = new System.Drawing.Size(75, 23);
          this.buttonCancel.TabIndex = 6;
          this.buttonCancel.Text = "Cancel";
          this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
          // 
          // textNewValue
          // 
          this.textNewValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          // 
          // 
          // 
          this.textNewValue.Border.Class = "TextBoxBorder";
          this.textNewValue.Location = new System.Drawing.Point(80, 112);
          this.textNewValue.Name = "textNewValue";
          this.textNewValue.Size = new System.Drawing.Size(231, 20);
          this.textNewValue.TabIndex = 7;
          this.textNewValue.TextChanged += new System.EventHandler(this.textNewValue_TextChanged);
          // 
          // labelServers
          // 
          this.labelServers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.labelServers.Location = new System.Drawing.Point(16, 139);
          this.labelServers.Name = "labelServers";
          this.labelServers.Size = new System.Drawing.Size(58, 23);
          this.labelServers.TabIndex = 9;
          this.labelServers.Text = "Servers:";
          // 
          // listUpdateServerList
          // 
          this.listUpdateServerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.listUpdateServerList.FormattingEnabled = true;
          this.listUpdateServerList.Location = new System.Drawing.Point(80, 139);
          this.listUpdateServerList.Name = "listUpdateServerList";
          this.listUpdateServerList.Size = new System.Drawing.Size(231, 169);
          this.listUpdateServerList.TabIndex = 10;
          this.listUpdateServerList.Visible = false;
          // 
          // dropDownNewValue
          // 
          this.dropDownNewValue.DisplayMember = "Text";
          this.dropDownNewValue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
          this.dropDownNewValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.dropDownNewValue.FormattingEnabled = true;
          this.dropDownNewValue.ItemHeight = 14;
          this.dropDownNewValue.Location = new System.Drawing.Point(80, 112);
          this.dropDownNewValue.Name = "dropDownNewValue";
          this.dropDownNewValue.Size = new System.Drawing.Size(231, 20);
          this.dropDownNewValue.TabIndex = 11;
          this.dropDownNewValue.Visible = false;
          // 
          // Form_EditConfiguration
          // 
          this.AcceptButton = this.buttonOK;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.White;
          this.CancelButton = this.buttonCancel;
          this.ClientSize = new System.Drawing.Size(325, 347);
          this.Controls.Add(this.dropDownNewValue);
          this.Controls.Add(this.labelServers);
          this.Controls.Add(this.textNewValue);
          this.Controls.Add(this.buttonCancel);
          this.Controls.Add(this.buttonOK);
          this.Controls.Add(this.labelConfigurationName);
          this.Controls.Add(this.labelX2);
          this.Controls.Add(this.labelX1);
          this.Controls.Add(this.labelChangeInstructions);
          this.Controls.Add(this.listUpdateServerList);
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

      private DevComponents.DotNetBar.LabelX labelChangeInstructions;
      private DevComponents.DotNetBar.LabelX labelX1;
      private DevComponents.DotNetBar.LabelX labelX2;
      private DevComponents.DotNetBar.LabelX labelConfigurationName;
      private DevComponents.DotNetBar.ButtonX buttonOK;
      private DevComponents.DotNetBar.ButtonX buttonCancel;
      private Idera.SqlAdminToolset.Core.ToolNumericTextBox textNewValue;
      private DevComponents.DotNetBar.LabelX labelServers;
      private System.Windows.Forms.CheckedListBox listUpdateServerList;
       private DevComponents.DotNetBar.Controls.ComboBoxEx dropDownNewValue;
   }
}