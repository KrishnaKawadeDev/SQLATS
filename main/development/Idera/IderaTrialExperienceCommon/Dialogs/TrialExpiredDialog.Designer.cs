namespace IderaTitleBarControls.Dialogs
{
    partial class TrialExpiredDialog
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.llOnlineStore = new System.Windows.Forms.LinkLabel();
            this.llRegisterKey = new System.Windows.Forms.LinkLabel();
            this.llTrialCenter = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(12, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(461, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Trial Period has expired";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To purchase a license, visit the ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "To apply a License Key, ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "For further questions or to extend the trial, visit the ";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(198, 130);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // llOnlineStore
            // 
            this.llOnlineStore.AutoSize = true;
            this.llOnlineStore.Location = new System.Drawing.Point(163, 51);
            this.llOnlineStore.Name = "llOnlineStore";
            this.llOnlineStore.Size = new System.Drawing.Size(61, 13);
            this.llOnlineStore.TabIndex = 5;
            this.llOnlineStore.TabStop = true;
            this.llOnlineStore.Text = "online store";
            this.llOnlineStore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOnlineStore_LinkClicked);
            // 
            // llRegisterKey
            // 
            this.llRegisterKey.AutoSize = true;
            this.llRegisterKey.Location = new System.Drawing.Point(130, 75);
            this.llRegisterKey.Name = "llRegisterKey";
            this.llRegisterKey.Size = new System.Drawing.Size(70, 13);
            this.llRegisterKey.TabIndex = 6;
            this.llRegisterKey.TabStop = true;
            this.llRegisterKey.Text = "click here";
            this.llRegisterKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRegisterKey_LinkClicked);
            // 
            // llTrialCenter
            // 
            this.llTrialCenter.AutoSize = true;
            this.llTrialCenter.Location = new System.Drawing.Point(251, 98);
            this.llTrialCenter.Name = "llTrialCenter";
            this.llTrialCenter.Size = new System.Drawing.Size(61, 13);
            this.llTrialCenter.TabIndex = 7;
            this.llTrialCenter.TabStop = true;
            this.llTrialCenter.Text = "Trial Center";
            this.llTrialCenter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llTrialCenter_LinkClicked);
            // 
            // TrialExpiredDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 165);
            this.Controls.Add(this.llTrialCenter);
            this.Controls.Add(this.llRegisterKey);
            this.Controls.Add(this.llOnlineStore);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TrialExpiredDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trial Period has expired";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TrialExpiredDialog_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel llOnlineStore;
        private System.Windows.Forms.LinkLabel llRegisterKey;
        private System.Windows.Forms.LinkLabel llTrialCenter;
    }
}