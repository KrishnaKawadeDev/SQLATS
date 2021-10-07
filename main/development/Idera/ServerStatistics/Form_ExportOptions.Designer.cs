namespace Idera.SqlAdminToolset.ServerStatistics
{
    partial class Form_ExportOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ExportOptions));
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.listServers = new System.Windows.Forms.CheckedListBox();
            this.linkSelectAll = new System.Windows.Forms.LinkLabel();
            this.linkClearAll = new System.Windows.Forms.LinkLabel();
            this.radioExportLoaded = new System.Windows.Forms.RadioButton();
            this.radioExportAll = new System.Windows.Forms.RadioButton();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
            this.buttonOK = new DevComponents.DotNetBar.ButtonX();
            this.pictureHelp = new System.Windows.Forms.PictureBox();
            this.superTooltip1 = new DevComponents.DotNetBar.SuperTooltip();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(9, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(137, 23);
            this.labelTitle.TabIndex = 15;
            this.labelTitle.Text = "Servers to {0}:";
            // 
            // listServers
            // 
            this.listServers.CheckOnClick = true;
            this.listServers.FormattingEnabled = true;
            this.listServers.Location = new System.Drawing.Point(9, 39);
            this.listServers.Name = "listServers";
            this.listServers.Size = new System.Drawing.Size(213, 124);
            this.listServers.TabIndex = 16;
            // 
            // linkSelectAll
            // 
            this.linkSelectAll.AutoSize = true;
            this.linkSelectAll.Location = new System.Drawing.Point(10, 170);
            this.linkSelectAll.Name = "linkSelectAll";
            this.linkSelectAll.Size = new System.Drawing.Size(51, 13);
            this.linkSelectAll.TabIndex = 17;
            this.linkSelectAll.TabStop = true;
            this.linkSelectAll.Text = "Select All";
            this.linkSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelectAll_LinkClicked);
            // 
            // linkClearAll
            // 
            this.linkClearAll.AutoSize = true;
            this.linkClearAll.Location = new System.Drawing.Point(58, 170);
            this.linkClearAll.Name = "linkClearAll";
            this.linkClearAll.Size = new System.Drawing.Size(45, 13);
            this.linkClearAll.TabIndex = 18;
            this.linkClearAll.TabStop = true;
            this.linkClearAll.Text = "Clear All";
            this.linkClearAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClearAll_LinkClicked);
            // 
            // radioExportLoaded
            // 
            this.radioExportLoaded.AutoSize = true;
            this.radioExportLoaded.Checked = true;
            this.radioExportLoaded.Location = new System.Drawing.Point(13, 223);
            this.radioExportLoaded.Name = "radioExportLoaded";
            this.radioExportLoaded.Size = new System.Drawing.Size(120, 17);
            this.radioExportLoaded.TabIndex = 19;
            this.radioExportLoaded.TabStop = true;
            this.radioExportLoaded.Text = "{0} loaded data only";
            this.radioExportLoaded.UseVisualStyleBackColor = true;
            // 
            // radioExportAll
            // 
            this.radioExportAll.AutoSize = true;
            this.radioExportAll.Location = new System.Drawing.Point(13, 246);
            this.radioExportAll.Name = "radioExportAll";
            this.radioExportAll.Size = new System.Drawing.Size(136, 17);
            this.radioExportAll.TabIndex = 20;
            this.radioExportAll.TabStop = true;
            this.radioExportAll.Text = "Load all data before {0}";
            this.radioExportAll.UseVisualStyleBackColor = true;
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(9, 194);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(52, 23);
            this.labelX1.TabIndex = 21;
            this.labelX1.Text = "Options:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(123, 280);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Cancel";
            // 
            // buttonOK
            // 
            this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonOK.Location = new System.Drawing.Point(37, 280);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 22;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // pictureHelp
            // 
            this.pictureHelp.Image = ((System.Drawing.Image)(resources.GetObject("pictureHelp.Image")));
            this.pictureHelp.Location = new System.Drawing.Point(57, 198);
            this.pictureHelp.Name = "pictureHelp";
            this.pictureHelp.Size = new System.Drawing.Size(16, 16);
            this.pictureHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureHelp.TabIndex = 24;
            this.pictureHelp.TabStop = false;
            this.pictureHelp.Click += new System.EventHandler(this.pictureHelp_Click);
            // 
            // superTooltip1
            // 
            this.superTooltip1.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTooltip1.DelayTooltipHideDuration = 5000;
            this.superTooltip1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superTooltip1.MinimumTooltipSize = new System.Drawing.Size(450, 100);
            this.superTooltip1.TooltipDuration = 5;
            // 
            // Form_ExportOptions
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(234, 312);
            this.Controls.Add(this.pictureHelp);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.radioExportAll);
            this.Controls.Add(this.radioExportLoaded);
            this.Controls.Add(this.linkClearAll);
            this.Controls.Add(this.linkSelectAll);
            this.Controls.Add(this.listServers);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ExportOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "{0} Options";
            ((System.ComponentModel.ISupportInitialize)(this.pictureHelp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelTitle;
        private System.Windows.Forms.CheckedListBox listServers;
        private System.Windows.Forms.LinkLabel linkSelectAll;
        private System.Windows.Forms.LinkLabel linkClearAll;
        private System.Windows.Forms.RadioButton radioExportLoaded;
        private System.Windows.Forms.RadioButton radioExportAll;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX buttonCancel;
        private DevComponents.DotNetBar.ButtonX buttonOK;
        private System.Windows.Forms.PictureBox pictureHelp;
        private DevComponents.DotNetBar.SuperTooltip superTooltip1;
    }
}