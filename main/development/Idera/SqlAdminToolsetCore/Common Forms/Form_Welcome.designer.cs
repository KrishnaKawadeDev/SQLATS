using System;

namespace Idera.SqlAdminToolset.Core
{
    partial class Form_Welcome
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
        components.Dispose();

      base.Dispose(disposing);

      GC.SuppressFinalize(this);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
       System.Windows.Forms.PictureBox pictureBox1;
       System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Welcome));
       this.labelExpiration = new System.Windows.Forms.Label();
       this.linkNewLicenseKey = new System.Windows.Forms.LinkLabel();
       this.labelTitle = new DevComponents.DotNetBar.LabelX();
       this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
       this.labelIntroduction = new DevComponents.DotNetBar.LabelX();
       this.labelVersion = new DevComponents.DotNetBar.LabelX();
       this.buttonClose = new DevComponents.DotNetBar.ButtonX();
       pictureBox1 = new System.Windows.Forms.PictureBox();
       ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
       this.SuspendLayout();
       // 
       // pictureBox1
       // 
       pictureBox1.BackColor = System.Drawing.Color.Transparent;
       pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
       pictureBox1.Location = new System.Drawing.Point(423, 12);
       pictureBox1.Name = "pictureBox1";
       pictureBox1.Size = new System.Drawing.Size(48, 48);
       pictureBox1.TabIndex = 14;
       pictureBox1.TabStop = false;
       // 
       // labelExpiration
       // 
       this.labelExpiration.CausesValidation = false;
       this.labelExpiration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
       this.labelExpiration.ForeColor = System.Drawing.SystemColors.ControlText;
       this.labelExpiration.Location = new System.Drawing.Point(9, 128);
       this.labelExpiration.Name = "labelExpiration";
       this.labelExpiration.Size = new System.Drawing.Size(464, 25);
       this.labelExpiration.TabIndex = 15;
       this.labelExpiration.Text = "There are 7 days remaining in the trial period.";
       this.labelExpiration.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
       // 
       // linkNewLicenseKey
       // 
       this.linkNewLicenseKey.Image = ((System.Drawing.Image)(resources.GetObject("linkNewLicenseKey.Image")));
       this.linkNewLicenseKey.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
       this.linkNewLicenseKey.Location = new System.Drawing.Point(9, 184);
       this.linkNewLicenseKey.Name = "linkNewLicenseKey";
       this.linkNewLicenseKey.Size = new System.Drawing.Size(150, 19);
       this.linkNewLicenseKey.TabIndex = 17;
       this.linkNewLicenseKey.TabStop = true;
       this.linkNewLicenseKey.Text = "Register New License Key";
       this.linkNewLicenseKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
       this.linkNewLicenseKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNewLicenseKey_LinkClicked);
       // 
       // labelTitle
       // 
       this.labelTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
       this.labelTitle.ForeColor = System.Drawing.Color.Black;
       this.labelTitle.Location = new System.Drawing.Point(41, 9);
       this.labelTitle.Name = "labelTitle";
       this.labelTitle.Size = new System.Drawing.Size(371, 21);
       this.labelTitle.TabIndex = 19;
       this.labelTitle.Text = "<div align=\"right\">Welcome to the <font color=\"#fd4703\">Idera SQL admin toolset</" +
           "font></div>";
       this.labelTitle.TextAlignment = System.Drawing.StringAlignment.Far;
       // 
       // labelSubtitle
       // 
       this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
       this.labelSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(53)))), ((int)(((byte)(3)))));
       this.labelSubtitle.Location = new System.Drawing.Point(41, 33);
       this.labelSubtitle.Name = "labelSubtitle";
       this.labelSubtitle.Size = new System.Drawing.Size(371, 21);
       this.labelSubtitle.TabIndex = 20;
       this.labelSubtitle.Text = "Connection String Generator";
       this.labelSubtitle.TextAlignment = System.Drawing.StringAlignment.Far;
       // 
       // labelIntroduction
       // 
       this.labelIntroduction.Location = new System.Drawing.Point(26, 81);
       this.labelIntroduction.Name = "labelIntroduction";
       this.labelIntroduction.Size = new System.Drawing.Size(447, 48);
       this.labelIntroduction.TabIndex = 21;
       this.labelIntroduction.Text = resources.GetString("labelIntroduction.Text");
       this.labelIntroduction.WordWrap = true;
       // 
       // labelVersion
       // 
       this.labelVersion.Location = new System.Drawing.Point(297, 57);
       this.labelVersion.Name = "labelVersion";
       this.labelVersion.Size = new System.Drawing.Size(115, 17);
       this.labelVersion.TabIndex = 22;
       this.labelVersion.Text = "1.6.0.0";
       this.labelVersion.TextAlignment = System.Drawing.StringAlignment.Far;
       // 
       // buttonClose
       // 
       this.buttonClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.buttonClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
       this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
       this.buttonClose.Location = new System.Drawing.Point(388, 184);
       this.buttonClose.Name = "buttonClose";
       this.buttonClose.Size = new System.Drawing.Size(85, 23);
       this.buttonClose.TabIndex = 5;
       this.buttonClose.Text = "&OK";
       this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
       // 
       // Form_Welcome
       // 
       this.AcceptButton = this.buttonClose;
       this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
       this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
       this.BackColor = System.Drawing.Color.White;
       this.CancelButton = this.buttonClose;
       this.CausesValidation = false;
       this.ClientSize = new System.Drawing.Size(482, 215);
       this.Controls.Add(this.buttonClose);
       this.Controls.Add(this.labelVersion);
       this.Controls.Add(this.labelIntroduction);
       this.Controls.Add(this.labelSubtitle);
       this.Controls.Add(this.labelTitle);
       this.Controls.Add(this.linkNewLicenseKey);
       this.Controls.Add(this.labelExpiration);
       this.Controls.Add(pictureBox1);
       this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
       this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
       this.MaximizeBox = false;
       this.MinimizeBox = false;
       this.Name = "Form_Welcome";
       this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
       this.Text = "Welcome to the Idera SQL admin toolset";
       this.Load += new System.EventHandler(this.Form_Welcome_Load);
       ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
       this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label labelExpiration;
       private System.Windows.Forms.LinkLabel linkNewLicenseKey;
       private DevComponents.DotNetBar.LabelX labelTitle;
       private DevComponents.DotNetBar.LabelX labelSubtitle;
       private DevComponents.DotNetBar.LabelX labelIntroduction;
       private DevComponents.DotNetBar.LabelX labelVersion;
       private DevComponents.DotNetBar.ButtonX buttonClose;
  }
}