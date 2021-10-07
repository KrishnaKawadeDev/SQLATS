namespace IderaTrialExperienceCommon.Controls
{
    partial class IderaButton
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ActiveArrow = new System.Windows.Forms.Label();
            this.btnText = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ActiveArrow, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnText, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.53489F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.46511F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(122, 43);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ActiveArrow
            // 
            this.ActiveArrow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.ActiveArrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActiveArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActiveArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 0.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            var backgroundBitmap1 = new System.Drawing.Bitmap(50, 14);
            using (System.Drawing.Bitmap tempBitmap = new System.Drawing.Bitmap(global::IderaTrialExperienceCommon.Properties.Resources.ActiveBtnTitle))
            {
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(backgroundBitmap1))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    // Get the set of points that determine our rectangle for resizing.
                    System.Drawing.Point[] corners = {
            new System.Drawing.Point(0, 0),
            new System.Drawing.Point(backgroundBitmap1.Width, 0),
            new System.Drawing.Point(0, backgroundBitmap1.Height)
        };
                    g.DrawImage(tempBitmap, corners);
                }
            }
            this.ActiveArrow.Image = backgroundBitmap1;
            this.ActiveArrow.Location = new System.Drawing.Point(0, 0);
            this.ActiveArrow.Margin = new System.Windows.Forms.Padding(0);
            this.ActiveArrow.Name = "ActiveArrow";
            this.ActiveArrow.Size = new System.Drawing.Size(122, 17);
            this.ActiveArrow.TabIndex = 0;
            this.ActiveArrow.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ActiveArrow.UseMnemonic = false;
            this.ActiveArrow.Click += new System.EventHandler(this.ActiveArrow_Click);
            // 
            // btnText
            // 
            this.btnText.AutoSize = true;
            this.btnText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.btnText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnText.ForeColor = System.Drawing.Color.White;
            this.btnText.Location = new System.Drawing.Point(0, 17);
            this.btnText.Margin = new System.Windows.Forms.Padding(0);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(122, 26);
            this.btnText.TabIndex = 1;
            this.btnText.Text = "ButtonText";
            this.btnText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnText.Click += new System.EventHandler(this.btnText_Click);
            // 
            // IderaButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Name = "IderaButton";
            this.Size = new System.Drawing.Size(122, 43);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label btnText;
        private System.Windows.Forms.Label ActiveArrow;
    }
}
