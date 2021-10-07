namespace IderaTrialExperienceCommon.Controls
{
    using System;
    using System.Drawing;
    using IderaTitleBarControls;
    using System.Drawing.Text;
    partial class IderaTitleBar
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
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
          IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font myFont;
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainTLP = new System.Windows.Forms.TableLayoutPanel();
            this.TitleTLP = new System.Windows.Forms.TableLayoutPanel();
            this.WindowControlButtons = new IderaTrialExperienceCommon.Controls.WindowControls();
            this.IderaLogo = new System.Windows.Forms.Label();
            this.lblIderaProductName_Right = new System.Windows.Forms.Label();
            this.lblIderaProductName_Left = new System.Windows.Forms.Label();
            this.TitleHorisontalLine = new System.Windows.Forms.Label();
            this.ButtonsTLP = new System.Windows.Forms.TableLayoutPanel();
            this.BuyNowButton = new System.Windows.Forms.Label();
            this.homeButton = new IderaTrialExperienceCommon.Controls.IderaButton();
            this.TrialHelpAndCommunityButton = new IderaTrialExperienceCommon.Controls.IderaButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.trialProgressBar = new IderaTrialExperienceCommon.Controls.IderaTrialProgress();
            this.TrialCounterLicenseInfoButton = new IderaTrialExperienceCommon.Controls.IderaButton();
            this.MainTLP.SuspendLayout();
            this.TitleTLP.SuspendLayout();
            this.ButtonsTLP.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTLP
            // 
            this.MainTLP.AutoSize = true;
            this.MainTLP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.MainTLP.ColumnCount = 1;
            this.MainTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTLP.Controls.Add(this.TitleTLP, 0, 0);
            this.MainTLP.Controls.Add(this.TitleHorisontalLine, 0, 1);
            this.MainTLP.Controls.Add(this.ButtonsTLP, 0, 2);
            this.MainTLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTLP.Location = new System.Drawing.Point(0, 0);
            this.MainTLP.Margin = new System.Windows.Forms.Padding(0);
            this.MainTLP.Name = "MainTLP";
            this.MainTLP.RowCount = 4;
            this.MainTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MainTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.MainTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.MainTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.MainTLP.Size = new System.Drawing.Size(822, 93);
            this.MainTLP.TabIndex = 0;
            // 
            // TitleTLP
            // 
            this.TitleTLP.AutoSize = true;
            this.TitleTLP.BackColor = System.Drawing.Color.White;
            this.TitleTLP.ColumnCount = 4;
            this.TitleTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.TitleTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.TitleTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TitleTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.TitleTLP.Controls.Add(this.WindowControlButtons, 3, 0);
            this.TitleTLP.Controls.Add(this.IderaLogo, 0, 0);
            this.TitleTLP.Controls.Add(this.lblIderaProductName_Right, 2, 0);
            this.TitleTLP.Controls.Add(this.lblIderaProductName_Left, 1, 0);
            this.TitleTLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleTLP.Location = new System.Drawing.Point(3, 3);
            this.TitleTLP.Name = "TitleTLP";
            this.TitleTLP.RowCount = 1;
            this.TitleTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TitleTLP.Size = new System.Drawing.Size(816, 34);
            this.TitleTLP.TabIndex = 0;
            this.TitleTLP.DoubleClick += new System.EventHandler(this.TitleTLP_DoubleClick);
            this.TitleTLP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleTLP_MouseDown);
            // 
            // WindowControlButtons
            // 
            this.WindowControlButtons.Close = true;
            this.WindowControlButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.WindowControlButtons.Location = new System.Drawing.Point(739, 3);
            this.WindowControlButtons.Maximize = true;
            this.WindowControlButtons.Minimize = true;
            this.WindowControlButtons.Name = "WindowControlButtons";
            this.WindowControlButtons.Size = new System.Drawing.Size(74, 28);
            this.WindowControlButtons.TabIndex = 4;
            // 
            // IderaLogo
            // 
            this.IderaLogo.AutoSize = true;
            this.IderaLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IderaLogo.Image = getLogoImage();
            this.IderaLogo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.IderaLogo.Location = new System.Drawing.Point(3, 9);
            this.IderaLogo.Margin = new System.Windows.Forms.Padding(3, 9, 3, 0);
            this.IderaLogo.Name = "IderaLogo";
            this.IderaLogo.Size = new System.Drawing.Size(130, 25);
            this.IderaLogo.TabIndex = 0;
            // 
            // lblIderaProductName_Right
            // 
            this.lblIderaProductName_Right.AutoSize = true;
            this.lblIderaProductName_Right.BackColor = System.Drawing.Color.White;
            this.lblIderaProductName_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            byte[] fontData = Properties.Resources.SourceSansPro_Bold;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.SourceSansPro_Bold.Length);
            AddFontMemResourceEx(fontPtr, (uint) Properties.Resources.SourceSansPro_Bold.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            myFont = new Font(fonts.Families[0], 16.0F,FontStyle.Bold);
            this.lblIderaProductName_Right.Font = myFont;
            this.lblIderaProductName_Right.ForeColor = System.Drawing.Color.Gray;
            this.lblIderaProductName_Right.Location = new System.Drawing.Point(224, 0);
            this.lblIderaProductName_Right.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblIderaProductName_Right.Name = "lblIderaProductName_Right";
            this.lblIderaProductName_Right.Size = new System.Drawing.Size(439, 34);
            this.lblIderaProductName_Right.TabIndex = 1;
            this.lblIderaProductName_Right.Text = "Idera Product Name";
            this.lblIderaProductName_Right.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblIderaProductName_Right.DoubleClick += new System.EventHandler(this.IderaProductName_DoubleClick);
            this.lblIderaProductName_Right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.IderaProductName_MouseDown);
            // 
            // lblIderaProductName_Left
            // 
            this.lblIderaProductName_Left.AutoSize = true;
            this.lblIderaProductName_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIderaProductName_Left.Font = myFont;
            this.lblIderaProductName_Left.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(201)))), ((int)(((byte)(66)))));
            this.lblIderaProductName_Left.Location = new System.Drawing.Point(139, 0);
            this.lblIderaProductName_Left.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblIderaProductName_Left.Name = "lblIderaProductName_Left";
            this.lblIderaProductName_Left.Size = new System.Drawing.Size(85, 34);
            this.lblIderaProductName_Left.TabIndex = 5;
            this.lblIderaProductName_Left.Tag = "";
            this.lblIderaProductName_Left.Text = "SQL";
            this.lblIderaProductName_Left.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TitleHorisontalLine
            // 
            this.TitleHorisontalLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(201)))), ((int)(((byte)(66)))));
            this.TitleHorisontalLine.CausesValidation = false;
            this.TitleHorisontalLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleHorisontalLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TitleHorisontalLine.Location = new System.Drawing.Point(0, 40);
            this.TitleHorisontalLine.Margin = new System.Windows.Forms.Padding(0);
            this.TitleHorisontalLine.Name = "TitleHorisontalLine";
            this.TitleHorisontalLine.Size = new System.Drawing.Size(822, 5);
            this.TitleHorisontalLine.TabIndex = 1;
            // 
            // ButtonsTLP
            // 
            this.ButtonsTLP.CausesValidation = false;
            this.ButtonsTLP.ColumnCount = 4;
            this.ButtonsTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.ButtonsTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.ButtonsTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonsTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.ButtonsTLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ButtonsTLP.Controls.Add(this.BuyNowButton, 3, 0);
            this.ButtonsTLP.Controls.Add(this.homeButton, 0, 0);
            this.ButtonsTLP.Controls.Add(this.TrialHelpAndCommunityButton, 1, 0);
            this.ButtonsTLP.Controls.Add(this.panel1, 2, 0);
            this.ButtonsTLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsTLP.Location = new System.Drawing.Point(3, 45);
            this.ButtonsTLP.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ButtonsTLP.Name = "ButtonsTLP";
            this.ButtonsTLP.RowCount = 1;
            this.ButtonsTLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonsTLP.Size = new System.Drawing.Size(816, 50);
            this.ButtonsTLP.TabIndex = 2;
            this.ButtonsTLP.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.ButtonsTLP_CellPaint);
            // 
            // BuyNowButton
            // 
            this.BuyNowButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.BuyNowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BuyNowButton.ForeColor = System.Drawing.Color.White;
            this.BuyNowButton.Image = global::IderaTrialExperienceCommon.Properties.Resources.Arrow_24;
            this.BuyNowButton.Location = new System.Drawing.Point(679, 0);
            this.BuyNowButton.Name = "BuyNowButton";
            this.BuyNowButton.Size = new System.Drawing.Size(134, 50);
            this.BuyNowButton.TabIndex = 5;
            this.BuyNowButton.Text = "Buy Now";
            this.BuyNowButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BuyNowButton.Click += new System.EventHandler(this.BuyNowButton_Click);
            // 
            // homeButton
            // 
            this.homeButton.Active = true;
            this.homeButton.ActiveButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(201)))), ((int)(((byte)(66)))));
            this.homeButton.ButtonText = "Home";
            this.homeButton.ButtonTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.homeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homeButton.InActiveButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.homeButton.Location = new System.Drawing.Point(3, 0);
            this.homeButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(81, 47);
            this.homeButton.TabIndex = 0;
            this.homeButton.ButtonClick += new System.EventHandler(this.homeButton_Click);
            // 
            // TrialHelpAndCommunityButton
            // 
            this.TrialHelpAndCommunityButton.Active = false;
            this.TrialHelpAndCommunityButton.ActiveButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(201)))), ((int)(((byte)(66)))));
            this.TrialHelpAndCommunityButton.ButtonText = "Trial Help";
            this.TrialHelpAndCommunityButton.ButtonTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.TrialHelpAndCommunityButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrialHelpAndCommunityButton.InActiveButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TrialHelpAndCommunityButton.Location = new System.Drawing.Point(90, 0);
            this.TrialHelpAndCommunityButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.TrialHelpAndCommunityButton.Name = "TrialHelpAndCommunityButton";
            this.TrialHelpAndCommunityButton.Size = new System.Drawing.Size(119, 47);
            this.TrialHelpAndCommunityButton.TabIndex = 1;
            this.TrialHelpAndCommunityButton.ButtonClick += new System.EventHandler(this.trialHelpAndCommunityButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Location = new System.Drawing.Point(313, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.panel1.Size = new System.Drawing.Size(325, 43);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel2.Controls.Add(this.trialProgressBar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.TrialCounterLicenseInfoButton, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(319, 39);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // trialProgressBar
            // 
            this.trialProgressBar.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.trialProgressBar.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.trialProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trialProgressBar.ExpiredText = "Expired";
            this.trialProgressBar.ForeColor = System.Drawing.Color.Gray;
            this.trialProgressBar.HighColor = System.Drawing.Color.Red;
            this.trialProgressBar.Location = new System.Drawing.Point(220, 0);
            this.trialProgressBar.LowColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(201)))), ((int)(((byte)(66)))));
            this.trialProgressBar.Margin = new System.Windows.Forms.Padding(0);
            this.trialProgressBar.MidColor = System.Drawing.Color.Yellow;
            this.trialProgressBar.Name = "trialProgressBar";
            this.trialProgressBar.RateValue = 100F;
            this.trialProgressBar.Size = new System.Drawing.Size(99, 39);
            this.trialProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.trialProgressBar.TabIndex = 6;
            this.trialProgressBar.UseWaitCursor = true;
            this.trialProgressBar.Value = 100;
            // 
            // TrialCounterLicenseInfoButton
            // 
            this.TrialCounterLicenseInfoButton.Active = false;
            this.TrialCounterLicenseInfoButton.ActiveButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(201)))), ((int)(((byte)(66)))));
            this.TrialCounterLicenseInfoButton.ButtonText = "Trial version - XX days left";
            this.TrialCounterLicenseInfoButton.ButtonTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.TrialCounterLicenseInfoButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.TrialCounterLicenseInfoButton.InActiveButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TrialCounterLicenseInfoButton.Location = new System.Drawing.Point(3, 0);
            this.TrialCounterLicenseInfoButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.TrialCounterLicenseInfoButton.Name = "TrialCounterLicenseInfoButton";
            this.TrialCounterLicenseInfoButton.Size = new System.Drawing.Size(214, 36);
            this.TrialCounterLicenseInfoButton.TabIndex = 5;
            this.TrialCounterLicenseInfoButton.ButtonClick += new System.EventHandler(this.TrialCounterButton_Click);
            // 
            // IderaTitleBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTLP);
            this.Name = "IderaTitleBar";
            this.Size = new System.Drawing.Size(822, 93);
            this.MainTLP.ResumeLayout(false);
            this.MainTLP.PerformLayout();
            this.TitleTLP.ResumeLayout(false);
            this.TitleTLP.PerformLayout();
            this.ButtonsTLP.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Bitmap getLogoImage()
        {
            Size outputSize = new System.Drawing.Size(120, 14);
            Bitmap backgroundBitmap = new System.Drawing.Bitmap(outputSize.Width, outputSize.Height);
            using (System.Drawing.Bitmap tempBitmap = new System.Drawing.Bitmap(Properties.Resources.logo1_))
            {
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(backgroundBitmap))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    // Get the set of points that determine our rectangle for resizing.
                    System.Drawing.Point[] corners = {
            new System.Drawing.Point(0, 0),
            new System.Drawing.Point(backgroundBitmap.Width, 0),
            new System.Drawing.Point(0, backgroundBitmap.Height)
        };
                    g.DrawImage(tempBitmap, corners);
                }
            }
            return backgroundBitmap;
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTLP;
        private System.Windows.Forms.TableLayoutPanel TitleTLP;
        private WindowControls WindowControlButtons;
        private System.Windows.Forms.Label IderaLogo;
        private System.Windows.Forms.Label lblIderaProductName_Right;
        private System.Windows.Forms.Label TitleHorisontalLine;
        private System.Windows.Forms.TableLayoutPanel ButtonsTLP;
        private IderaButton homeButton;
        private IderaButton TrialHelpAndCommunityButton;
        private System.Windows.Forms.Label BuyNowButton;
        private System.Windows.Forms.Label lblIderaProductName_Left;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private IderaTrialProgress trialProgressBar;
        private IderaButton TrialCounterLicenseInfoButton;
    }
}
