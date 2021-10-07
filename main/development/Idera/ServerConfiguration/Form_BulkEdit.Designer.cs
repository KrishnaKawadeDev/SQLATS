namespace Idera.SqlAdminToolset.ServerConfiguration
{
   partial class Form_BulkEdit
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
          this.buttonOK = new DevComponents.DotNetBar.ButtonX();
          this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
          this.labelBaselineName = new DevComponents.DotNetBar.LabelX();
          this.labelX4 = new DevComponents.DotNetBar.LabelX();
          this.labelX5 = new DevComponents.DotNetBar.LabelX();
          this.treeSettings = new System.Windows.Forms.TreeView();
          this.linkChangeView = new System.Windows.Forms.LinkLabel();
          this.labelCollationWarning = new DevComponents.DotNetBar.LabelX();
          this.SuspendLayout();
          // 
          // buttonOK
          // 
          this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
          this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
          this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
          this.buttonOK.Location = new System.Drawing.Point(149, 357);
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
          this.buttonCancel.Location = new System.Drawing.Point(238, 357);
          this.buttonCancel.Name = "buttonCancel";
          this.buttonCancel.Size = new System.Drawing.Size(75, 23);
          this.buttonCancel.TabIndex = 6;
          this.buttonCancel.Text = "Cancel";
          this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
          // 
          // labelBaselineName
          // 
          this.labelBaselineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.labelBaselineName.Location = new System.Drawing.Point(88, 13);
          this.labelBaselineName.Name = "labelBaselineName";
          this.labelBaselineName.Size = new System.Drawing.Size(221, 23);
          this.labelBaselineName.TabIndex = 13;
          this.labelBaselineName.Text = "Name:";
          // 
          // labelX4
          // 
          this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.labelX4.Location = new System.Drawing.Point(16, 12);
          this.labelX4.Name = "labelX4";
          this.labelX4.Size = new System.Drawing.Size(73, 23);
          this.labelX4.TabIndex = 12;
          this.labelX4.Text = "Source Data:";
          // 
          // labelX5
          // 
          this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.labelX5.Location = new System.Drawing.Point(16, 55);
          this.labelX5.Name = "labelX5";
          this.labelX5.Size = new System.Drawing.Size(96, 23);
          this.labelX5.TabIndex = 14;
          this.labelX5.Text = "Values to Update:";
          // 
          // treeSettings
          // 
          this.treeSettings.CheckBoxes = true;
          this.treeSettings.Location = new System.Drawing.Point(16, 82);
          this.treeSettings.Name = "treeSettings";
          this.treeSettings.Size = new System.Drawing.Size(296, 269);
          this.treeSettings.TabIndex = 15;
          this.treeSettings.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeSettings_AfterCheck);
          // 
          // linkChangeView
          // 
          this.linkChangeView.AutoSize = true;
          this.linkChangeView.Location = new System.Drawing.Point(217, 60);
          this.linkChangeView.Name = "linkChangeView";
          this.linkChangeView.Size = new System.Drawing.Size(92, 13);
          this.linkChangeView.TabIndex = 16;
          this.linkChangeView.TabStop = true;
          this.linkChangeView.Text = "Group By Settings";
          this.linkChangeView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkChangeView_LinkClicked);
          // 
          // labelCollationWarning
          // 
          this.labelCollationWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.labelCollationWarning.ForeColor = System.Drawing.SystemColors.Highlight;
          this.labelCollationWarning.Location = new System.Drawing.Point(16, 33);
          this.labelCollationWarning.Name = "labelCollationWarning";
          this.labelCollationWarning.Size = new System.Drawing.Size(293, 23);
          this.labelCollationWarning.TabIndex = 17;
          this.labelCollationWarning.Text = "Collation Warning";
          this.labelCollationWarning.Visible = false;
          // 
          // Form_BulkEdit
          // 
          this.AcceptButton = this.buttonOK;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.White;
          this.CancelButton = this.buttonCancel;
          this.ClientSize = new System.Drawing.Size(325, 385);
          this.Controls.Add(this.labelCollationWarning);
          this.Controls.Add(this.linkChangeView);
          this.Controls.Add(this.treeSettings);
          this.Controls.Add(this.labelX5);
          this.Controls.Add(this.labelBaselineName);
          this.Controls.Add(this.labelX4);
          this.Controls.Add(this.buttonCancel);
          this.Controls.Add(this.buttonOK);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "Form_BulkEdit";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Baseline Configuration options";
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX buttonOK;
       private DevComponents.DotNetBar.ButtonX buttonCancel;
       private DevComponents.DotNetBar.LabelX labelBaselineName;
       private DevComponents.DotNetBar.LabelX labelX4;
       private DevComponents.DotNetBar.LabelX labelX5;
       private System.Windows.Forms.TreeView treeSettings;
       private System.Windows.Forms.LinkLabel linkChangeView;
       private DevComponents.DotNetBar.LabelX labelCollationWarning;
   }
}