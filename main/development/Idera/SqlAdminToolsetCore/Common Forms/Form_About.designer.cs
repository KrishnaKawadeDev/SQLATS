namespace Idera.SqlAdminToolset.Core
{
    partial class Form_About 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_About));
            this.labelDesc = new DevComponents.DotNetBar.LabelX();
            this.labelVersion = new DevComponents.DotNetBar.LabelX();
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.labelTrialVersion = new DevComponents.DotNetBar.LabelX();
            this.label1 = new DevComponents.DotNetBar.LabelX();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonClose = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDesc
            // 
            // 
            // 
            // 
            this.labelDesc.BackgroundStyle.Class = "";
            this.labelDesc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelDesc.Location = new System.Drawing.Point(12, 79);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(173, 117);
            this.labelDesc.TabIndex = 22;
            this.labelDesc.Text = resources.GetString("labelDesc.Text");
            this.labelDesc.WordWrap = true;
            // 
            // labelVersion
            // 
            // 
            // 
            // 
            this.labelVersion.BackgroundStyle.Class = "";
            this.labelVersion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelVersion.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.labelVersion.Location = new System.Drawing.Point(177, 35);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(291, 16);
            this.labelVersion.TabIndex = 21;
            this.labelVersion.Text = "Connection String Generator";
            this.labelVersion.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // picProduct
            // 
            this.picProduct.BackColor = System.Drawing.Color.White;
            this.picProduct.Image = ((System.Drawing.Image)(resources.GetObject("picProduct.Image")));
            this.picProduct.Location = new System.Drawing.Point(13, 15);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(156, 52);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProduct.TabIndex = 20;
            this.picProduct.TabStop = false;
            // 
            // labelTrialVersion
            // 
            // 
            // 
            // 
            this.labelTrialVersion.BackgroundStyle.Class = "";
            this.labelTrialVersion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTrialVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTrialVersion.Location = new System.Drawing.Point(177, 55);
            this.labelTrialVersion.Name = "labelTrialVersion";
            this.labelTrialVersion.PaddingRight = 2;
            this.labelTrialVersion.Size = new System.Drawing.Size(291, 18);
            this.labelTrialVersion.TabIndex = 25;
            this.labelTrialVersion.Text = "Trial Version";
            this.labelTrialVersion.TextAlignment = System.Drawing.StringAlignment.Far;
            this.labelTrialVersion.Visible = false;
            // 
            // label1
            // 
            // 
            // 
            // 
            this.label1.BackgroundStyle.Class = "";
            this.label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "SQL admin toolset";
            this.label1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(198, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 1);
            this.label2.TabIndex = 29;
            // 
            // buttonClose
            // 
            this.buttonClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClose.Location = new System.Drawing.Point(383, 173);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(85, 23);
            this.buttonClose.TabIndex = 30;
            this.buttonClose.Text = "&OK";
            // 
            // Form_About
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(483, 208);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.picProduct);
            this.Controls.Add(this.labelTrialVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_About";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Connection String Generator";
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       private DevComponents.DotNetBar.LabelX labelDesc;
       private DevComponents.DotNetBar.LabelX labelVersion;
       private System.Windows.Forms.PictureBox picProduct;
       private DevComponents.DotNetBar.LabelX labelTrialVersion;
       private DevComponents.DotNetBar.LabelX label1;
       private System.Windows.Forms.Label label2;
       private DevComponents.DotNetBar.ButtonX buttonClose;
    }
}