namespace Idera.SqlAdminToolset.ServerConfiguration
{
   partial class Form_OpenSnapshot
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_OpenSnapshot));
         this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
         this.buttonOK = new DevComponents.DotNetBar.ButtonX();
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.checkClearAll = new System.Windows.Forms.CheckBox();
         this.labelSnapshot = new System.Windows.Forms.Label();
         this.comboSnapshot = new System.Windows.Forms.ComboBox();
         this.buttonBrowse = new System.Windows.Forms.Button();
         this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.groupPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonCancel
         // 
         this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(755, 95);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 11;
         this.buttonCancel.Text = "&Cancel";
         // 
         // buttonOK
         // 
         this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonOK.Enabled = false;
         this.buttonOK.Location = new System.Drawing.Point(673, 95);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 10;
         this.buttonOK.Text = "&OK";
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // checkClearAll
         // 
         this.checkClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.checkClearAll.AutoSize = true;
         this.checkClearAll.Location = new System.Drawing.Point(24, 99);
         this.checkClearAll.Name = "checkClearAll";
         this.checkClearAll.Size = new System.Drawing.Size(239, 17);
         this.checkClearAll.TabIndex = 12;
         this.checkClearAll.Tag = "e ";
         this.checkClearAll.Text = "Clear existing comparison data before loading";
         this.toolTip1.SetToolTip(this.checkClearAll, "If checked, will clear all the existing report data. Otherwise new columns are ad" +
                 "ded for the specified servers.");
         this.checkClearAll.UseVisualStyleBackColor = true;
         // 
         // labelSnapshot
         // 
         this.labelSnapshot.AutoSize = true;
         this.labelSnapshot.BackColor = System.Drawing.Color.Transparent;
         this.labelSnapshot.Location = new System.Drawing.Point(6, 12);
         this.labelSnapshot.Name = "labelSnapshot";
         this.labelSnapshot.Size = new System.Drawing.Size(74, 13);
         this.labelSnapshot.TabIndex = 13;
         this.labelSnapshot.Text = "Snapshot File:";
         // 
         // comboSnapshot
         // 
         this.comboSnapshot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.comboSnapshot.FormattingEnabled = true;
         this.comboSnapshot.Location = new System.Drawing.Point(86, 9);
         this.comboSnapshot.Name = "comboSnapshot";
         this.comboSnapshot.Size = new System.Drawing.Size(688, 21);
         this.comboSnapshot.TabIndex = 14;
         this.comboSnapshot.SelectedIndexChanged += new System.EventHandler(this.comboSnapshot_SelectedIndexChanged);
         // 
         // buttonBrowse
         // 
         this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonBrowse.Location = new System.Drawing.Point(780, 9);
         this.buttonBrowse.Name = "buttonBrowse";
         this.buttonBrowse.Size = new System.Drawing.Size(24, 21);
         this.buttonBrowse.TabIndex = 15;
         this.buttonBrowse.Text = "...";
         this.buttonBrowse.UseVisualStyleBackColor = true;
         this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
         // 
         // groupPanel1
         // 
         this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel1.Controls.Add(this.comboSnapshot);
         this.groupPanel1.Controls.Add(this.buttonBrowse);
         this.groupPanel1.Controls.Add(this.labelSnapshot);
         this.groupPanel1.IsShadowEnabled = true;
         this.groupPanel1.Location = new System.Drawing.Point(12, 10);
         this.groupPanel1.Name = "groupPanel1";
         this.groupPanel1.Size = new System.Drawing.Size(818, 76);
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
         this.groupPanel1.TabIndex = 16;
         this.groupPanel1.Text = "Select a snapshot file from which to load previously captured data";
         // 
         // Form_OpenSnapshot
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(842, 126);
         this.Controls.Add(this.groupPanel1);
         this.Controls.Add(this.checkClearAll);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOK);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size(546, 160);
         this.Name = "Form_OpenSnapshot";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Open Snapshot";
         this.groupPanel1.ResumeLayout(false);
         this.groupPanel1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX buttonCancel;
      private DevComponents.DotNetBar.ButtonX buttonOK;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.CheckBox checkClearAll;
      private System.Windows.Forms.Label labelSnapshot;
      private System.Windows.Forms.ComboBox comboSnapshot;
      private System.Windows.Forms.Button buttonBrowse;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
   }
}