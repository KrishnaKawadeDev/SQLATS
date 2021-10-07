namespace IderaTrialExperienceCommon.Controls
{
    partial class LicenseInformationPanelControl
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBuyNow = new System.Windows.Forms.Button();
            this.lblContent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblActivateLicense = new System.Windows.Forms.Label();
            this.btnActivateLicense = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(53, 33);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(221, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "License Information";
            // 
            // btnBuyNow
            // 
            this.btnBuyNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(201)))), ((int)(((byte)(66)))));
            this.btnBuyNow.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuyNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuyNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBuyNow.ForeColor = System.Drawing.Color.White;
            this.btnBuyNow.Location = new System.Drawing.Point(537, 183);
            this.btnBuyNow.Name = "btnBuyNow";
            this.btnBuyNow.Size = new System.Drawing.Size(154, 32);
            this.btnBuyNow.TabIndex = 1;
            this.btnBuyNow.Text = "Buy Now";
            this.btnBuyNow.UseVisualStyleBackColor = false;
            this.btnBuyNow.Click += new System.EventHandler(this.btnBuyNow_Click);
            // 
            // lblContent
            // 
            this.lblContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblContent.Location = new System.Drawing.Point(56, 74);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(486, 103);
            this.lblContent.TabIndex = 2;
            this.lblContent.Text = "Expires: {0} days left\r\nType: {1} version\r\nKey: {2}\r\nLimit Code: {3}";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(61, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "If you would like to purchase a license, you can buy online.";
            // 
            // lblActivateLicense
            // 
            this.lblActivateLicense.AutoSize = true;
            this.lblActivateLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblActivateLicense.Location = new System.Drawing.Point(61, 241);
            this.lblActivateLicense.Name = "lblActivateLicense";
            this.lblActivateLicense.Size = new System.Drawing.Size(460, 20);
            this.lblActivateLicense.TabIndex = 5;
            this.lblActivateLicense.Text = "If you have already purchased a license, you can activate it here.";
            // 
            // btnActivateLicense
            // 
            this.btnActivateLicense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(98)))), ((int)(((byte)(138)))));
            this.btnActivateLicense.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnActivateLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivateLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnActivateLicense.ForeColor = System.Drawing.Color.White;
            this.btnActivateLicense.Location = new System.Drawing.Point(537, 235);
            this.btnActivateLicense.Name = "btnActivateLicense";
            this.btnActivateLicense.Size = new System.Drawing.Size(154, 32);
            this.btnActivateLicense.TabIndex = 4;
            this.btnActivateLicense.Text = "Activate License";
            this.btnActivateLicense.UseVisualStyleBackColor = false;
            this.btnActivateLicense.Click += new System.EventHandler(this.btnActivateLicense_Click);
            // 
            // LicenseInformationPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblActivateLicense);
            this.Controls.Add(this.btnActivateLicense);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.btnBuyNow);
            this.Controls.Add(this.lblTitle);
            this.Name = "LicenseInformationPanelControl";
            this.Size = new System.Drawing.Size(731, 351);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBuyNow;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblActivateLicense;
        private System.Windows.Forms.Button btnActivateLicense;
    }
}
