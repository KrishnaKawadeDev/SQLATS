namespace IderaTrialExperienceCommon.Controls
{
    partial class WindowControls
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.closeBtn = new System.Windows.Forms.Label();
            this.maximizeBtn = new System.Windows.Forms.Label();
            this.minimizeBtn = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeBtn.Image = global::IderaTrialExperienceCommon.Properties.Resources.Close;
            this.closeBtn.Location = new System.Drawing.Point(52, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(22, 22);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.closeBtn, "Close");
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // maximizeBtn
            // 
            this.maximizeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.maximizeBtn.Image = global::IderaTrialExperienceCommon.Properties.Resources.Maximize;
            this.maximizeBtn.Location = new System.Drawing.Point(30, 0);
            this.maximizeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.maximizeBtn.Name = "maximizeBtn";
            this.maximizeBtn.Size = new System.Drawing.Size(22, 22);
            this.maximizeBtn.TabIndex = 1;
            this.maximizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.maximizeBtn, "Maximize");
            this.maximizeBtn.Click += new System.EventHandler(this.maximizeBtn_Click);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimizeBtn.Image = global::IderaTrialExperienceCommon.Properties.Resources.Minimize;
            this.minimizeBtn.Location = new System.Drawing.Point(8, 0);
            this.minimizeBtn.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.minimizeBtn.Size = new System.Drawing.Size(22, 22);
            this.minimizeBtn.TabIndex = 0;
            this.minimizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.minimizeBtn, "Minimize");
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // WindowControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.maximizeBtn);
            this.Controls.Add(this.closeBtn);
            this.Name = "WindowControls";
            this.Size = new System.Drawing.Size(74, 22);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label minimizeBtn;
        private System.Windows.Forms.Label maximizeBtn;
        private System.Windows.Forms.Label closeBtn;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
