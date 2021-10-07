namespace IderaTrialExperienceCommon.Controls
{
    partial class WindowPanelControl
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
            this.btnDoAction = new System.Windows.Forms.Button();
            this.lblContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(53, 33);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(225, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Trial Tips and Tricks";
            // 
            // btnDoAction
            // 
            this.btnDoAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(82)))), ((int)(((byte)(115)))));
            this.btnDoAction.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDoAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDoAction.ForeColor = System.Drawing.Color.White;
            this.btnDoAction.Location = new System.Drawing.Point(60, 180);
            this.btnDoAction.Name = "btnDoAction";
            this.btnDoAction.Size = new System.Drawing.Size(170, 32);
            this.btnDoAction.TabIndex = 1;
            this.btnDoAction.Text = "Get Help";
            this.btnDoAction.UseVisualStyleBackColor = false;
            // 
            // lblContent
            // 
            this.lblContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblContent.Location = new System.Drawing.Point(56, 74);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(486, 103);
            this.lblContent.TabIndex = 2;
            this.lblContent.Text = "Visit Idera\'s Trial Center to learn more about how to use the product and submit " +
    "Questions to product experts to get up to speed fast.";
            // 
            // WindowPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.btnDoAction);
            this.Controls.Add(this.lblTitle);
            this.Name = "WindowPanelControl";
            this.Size = new System.Drawing.Size(577, 253);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDoAction;
        private System.Windows.Forms.Label lblContent;
    }
}
