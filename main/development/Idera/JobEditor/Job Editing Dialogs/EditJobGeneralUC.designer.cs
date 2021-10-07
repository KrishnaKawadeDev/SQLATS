namespace Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs
{
  partial class EditJobGeneralUC
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
       this.ultraLabel1 = new System.Windows.Forms.Label();
       this.ultraLabel2 = new System.Windows.Forms.Label();
       this.ultraLabel3 = new System.Windows.Forms.Label();
       this.ultraLabel4 = new System.Windows.Forms.Label();
       this.ultraLabel5 = new System.Windows.Forms.Label();
       this.ultraLabel6 = new System.Windows.Forms.Label();
       this.ultraLabel7 = new System.Windows.Forms.Label();
       this.ultraLabel8 = new System.Windows.Forms.Label();
       this.llViewJobHistory = new System.Windows.Forms.LinkLabel();
       this.uteName = new DevComponents.DotNetBar.Controls.TextBoxX();
       this.uteOwner = new DevComponents.DotNetBar.Controls.TextBoxX();
       this.uteLastExecuted = new DevComponents.DotNetBar.Controls.TextBoxX();
       this.uteLastModified = new DevComponents.DotNetBar.Controls.TextBoxX();
       this.uteCreated = new DevComponents.DotNetBar.Controls.TextBoxX();
       this.uteSource = new DevComponents.DotNetBar.Controls.TextBoxX();
       this.uteDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
       this.bnBrowseOwners = new DevComponents.DotNetBar.ButtonX();
       this.bnShowOtherJobsInCategory = new DevComponents.DotNetBar.ButtonX();
       this.comboCategory = new System.Windows.Forms.ComboBox();
       this.SuspendLayout();
       // 
       // ultraLabel1
       // 
       this.ultraLabel1.AutoSize = true;
       this.ultraLabel1.Location = new System.Drawing.Point(3, 12);
       this.ultraLabel1.Name = "ultraLabel1";
       this.ultraLabel1.Size = new System.Drawing.Size(38, 13);
       this.ultraLabel1.TabIndex = 0;
       this.ultraLabel1.Text = "&Name:";
       // 
       // ultraLabel2
       // 
       this.ultraLabel2.AutoSize = true;
       this.ultraLabel2.Location = new System.Drawing.Point(3, 41);
       this.ultraLabel2.Name = "ultraLabel2";
       this.ultraLabel2.Size = new System.Drawing.Size(41, 13);
       this.ultraLabel2.TabIndex = 1;
       this.ultraLabel2.Text = "&Owner:";
       // 
       // ultraLabel3
       // 
       this.ultraLabel3.AutoSize = true;
       this.ultraLabel3.Location = new System.Drawing.Point(3, 70);
       this.ultraLabel3.Name = "ultraLabel3";
       this.ultraLabel3.Size = new System.Drawing.Size(52, 13);
       this.ultraLabel3.TabIndex = 2;
       this.ultraLabel3.Text = "&Category:";
       // 
       // ultraLabel4
       // 
       this.ultraLabel4.AutoSize = true;
       this.ultraLabel4.Location = new System.Drawing.Point(3, 96);
       this.ultraLabel4.Name = "ultraLabel4";
       this.ultraLabel4.Size = new System.Drawing.Size(63, 13);
       this.ultraLabel4.TabIndex = 3;
       this.ultraLabel4.Text = "&Description:";
       // 
       // ultraLabel5
       // 
       this.ultraLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
       this.ultraLabel5.AutoSize = true;
       this.ultraLabel5.Location = new System.Drawing.Point(3, 391);
       this.ultraLabel5.Name = "ultraLabel5";
       this.ultraLabel5.Size = new System.Drawing.Size(44, 13);
       this.ultraLabel5.TabIndex = 4;
       this.ultraLabel5.Text = "Source:";
       // 
       // ultraLabel6
       // 
       this.ultraLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
       this.ultraLabel6.AutoSize = true;
       this.ultraLabel6.Location = new System.Drawing.Point(3, 419);
       this.ultraLabel6.Name = "ultraLabel6";
       this.ultraLabel6.Size = new System.Drawing.Size(47, 13);
       this.ultraLabel6.TabIndex = 5;
       this.ultraLabel6.Text = "Created:";
       // 
       // ultraLabel7
       // 
       this.ultraLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
       this.ultraLabel7.AutoSize = true;
       this.ultraLabel7.Location = new System.Drawing.Point(3, 446);
       this.ultraLabel7.Name = "ultraLabel7";
       this.ultraLabel7.Size = new System.Drawing.Size(72, 13);
       this.ultraLabel7.TabIndex = 6;
       this.ultraLabel7.Text = "Last modified:";
       // 
       // ultraLabel8
       // 
       this.ultraLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
       this.ultraLabel8.AutoSize = true;
       this.ultraLabel8.Location = new System.Drawing.Point(3, 473);
       this.ultraLabel8.Name = "ultraLabel8";
       this.ultraLabel8.Size = new System.Drawing.Size(77, 13);
       this.ultraLabel8.TabIndex = 7;
       this.ultraLabel8.Text = "Last executed:";
       // 
       // llViewJobHistory
       // 
       this.llViewJobHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
       this.llViewJobHistory.AutoSize = true;
       this.llViewJobHistory.Location = new System.Drawing.Point(3, 499);
       this.llViewJobHistory.Name = "llViewJobHistory";
       this.llViewJobHistory.Size = new System.Drawing.Size(85, 13);
       this.llViewJobHistory.TabIndex = 10;
       this.llViewJobHistory.TabStop = true;
       this.llViewJobHistory.Text = "View Job History";
       this.llViewJobHistory.Visible = false;
       this.llViewJobHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llViewJobHistory_LinkClicked);
       // 
       // uteName
       // 
       this.uteName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
       this.uteName.Location = new System.Drawing.Point(88, 9);
       this.uteName.Name = "uteName";
       this.uteName.Size = new System.Drawing.Size(416, 21);
       this.uteName.TabIndex = 0;
       // 
       // uteOwner
       // 
       this.uteOwner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
       this.uteOwner.Location = new System.Drawing.Point(88, 38);
       this.uteOwner.Name = "uteOwner";
       this.uteOwner.Size = new System.Drawing.Size(381, 21);
       this.uteOwner.TabIndex = 1;
       this.uteOwner.Text = "ultraTextEditor2";
       // 
       // uteLastExecuted
       // 
       this.uteLastExecuted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
       this.uteLastExecuted.BackColor = System.Drawing.SystemColors.ControlLightLight;
       this.uteLastExecuted.Location = new System.Drawing.Point(87, 470);
       this.uteLastExecuted.Name = "uteLastExecuted";
       this.uteLastExecuted.ReadOnly = true;
       this.uteLastExecuted.Size = new System.Drawing.Size(417, 21);
       this.uteLastExecuted.TabIndex = 9;
       this.uteLastExecuted.Text = "ultraTextEditor4";
       // 
       // uteLastModified
       // 
       this.uteLastModified.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
       this.uteLastModified.BackColor = System.Drawing.SystemColors.ControlLightLight;
       this.uteLastModified.Location = new System.Drawing.Point(88, 443);
       this.uteLastModified.Name = "uteLastModified";
       this.uteLastModified.ReadOnly = true;
       this.uteLastModified.Size = new System.Drawing.Size(416, 21);
       this.uteLastModified.TabIndex = 8;
       this.uteLastModified.Text = "ultraTextEditor5";
       // 
       // uteCreated
       // 
       this.uteCreated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
       this.uteCreated.BackColor = System.Drawing.SystemColors.ControlLightLight;
       this.uteCreated.Location = new System.Drawing.Point(88, 416);
       this.uteCreated.Name = "uteCreated";
       this.uteCreated.ReadOnly = true;
       this.uteCreated.Size = new System.Drawing.Size(416, 21);
       this.uteCreated.TabIndex = 7;
       this.uteCreated.Text = "ultraTextEditor6";
       // 
       // uteSource
       // 
       this.uteSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
       this.uteSource.BackColor = System.Drawing.SystemColors.ControlLightLight;
       this.uteSource.Location = new System.Drawing.Point(88, 388);
       this.uteSource.Name = "uteSource";
       this.uteSource.ReadOnly = true;
       this.uteSource.Size = new System.Drawing.Size(416, 21);
       this.uteSource.TabIndex = 6;
       this.uteSource.Text = "ultraTextEditor7";
       // 
       // uteDescription
       // 
       this.uteDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                   | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
       this.uteDescription.Location = new System.Drawing.Point(88, 96);
       this.uteDescription.MaxLength = 500;
       this.uteDescription.Multiline = true;
       this.uteDescription.Name = "uteDescription";
       this.uteDescription.Size = new System.Drawing.Size(416, 283);
       this.uteDescription.TabIndex = 5;
       this.uteDescription.Text = "ultraTextEditor8";
       // 
       // bnBrowseOwners
       // 
       this.bnBrowseOwners.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.bnBrowseOwners.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
       this.bnBrowseOwners.AutoSize = true;
       this.bnBrowseOwners.Location = new System.Drawing.Point(475, 36);
       this.bnBrowseOwners.Name = "bnBrowseOwners";
       this.bnBrowseOwners.Size = new System.Drawing.Size(24, 24);
       this.bnBrowseOwners.TabIndex = 2;
       this.bnBrowseOwners.Text = "...";
       this.bnBrowseOwners.Click += new System.EventHandler(this.bnBrowseOwners_Click);
       // 
       // bnShowOtherJobsInCategory
       // 
       this.bnShowOtherJobsInCategory.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.bnShowOtherJobsInCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
       this.bnShowOtherJobsInCategory.AutoSize = true;
       this.bnShowOtherJobsInCategory.Location = new System.Drawing.Point(475, 65);
       this.bnShowOtherJobsInCategory.Name = "bnShowOtherJobsInCategory";
       this.bnShowOtherJobsInCategory.Size = new System.Drawing.Size(24, 24);
       this.bnShowOtherJobsInCategory.TabIndex = 4;
       this.bnShowOtherJobsInCategory.Text = "...";
       this.bnShowOtherJobsInCategory.Click += new System.EventHandler(this.bnShowOtherJobsInCategory_Click);
       // 
       // comboCategory
       // 
       this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
       this.comboCategory.FormattingEnabled = true;
       this.comboCategory.Location = new System.Drawing.Point(88, 67);
       this.comboCategory.Name = "comboCategory";
       this.comboCategory.Size = new System.Drawing.Size(381, 21);
       this.comboCategory.TabIndex = 3;
       // 
       // EditJobGeneralUC
       // 
       this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
       this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
       this.Controls.Add(this.comboCategory);
       this.Controls.Add(this.bnShowOtherJobsInCategory);
       this.Controls.Add(this.bnBrowseOwners);
       this.Controls.Add(this.uteDescription);
       this.Controls.Add(this.uteSource);
       this.Controls.Add(this.uteCreated);
       this.Controls.Add(this.uteLastModified);
       this.Controls.Add(this.uteLastExecuted);
       this.Controls.Add(this.uteOwner);
       this.Controls.Add(this.uteName);
       this.Controls.Add(this.llViewJobHistory);
       this.Controls.Add(this.ultraLabel8);
       this.Controls.Add(this.ultraLabel7);
       this.Controls.Add(this.ultraLabel6);
       this.Controls.Add(this.ultraLabel5);
       this.Controls.Add(this.ultraLabel4);
       this.Controls.Add(this.ultraLabel3);
       this.Controls.Add(this.ultraLabel2);
       this.Controls.Add(this.ultraLabel1);
       this.Name = "EditJobGeneralUC";
       this.Size = new System.Drawing.Size(507, 530);
       this.ResumeLayout(false);
       this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label ultraLabel1;
    private System.Windows.Forms.Label ultraLabel2;
    private System.Windows.Forms.Label ultraLabel3;
    private System.Windows.Forms.Label ultraLabel4;
    private System.Windows.Forms.Label ultraLabel5;
    private System.Windows.Forms.Label ultraLabel6;
    private System.Windows.Forms.Label ultraLabel7;
    private System.Windows.Forms.Label ultraLabel8;
    private System.Windows.Forms.LinkLabel llViewJobHistory;
    private DevComponents.DotNetBar.Controls.TextBoxX uteName;
    private DevComponents.DotNetBar.Controls.TextBoxX uteOwner;
    private DevComponents.DotNetBar.Controls.TextBoxX uteLastExecuted;
    private DevComponents.DotNetBar.Controls.TextBoxX uteLastModified;
    private DevComponents.DotNetBar.Controls.TextBoxX uteCreated;
    private DevComponents.DotNetBar.Controls.TextBoxX uteSource;
    private DevComponents.DotNetBar.Controls.TextBoxX uteDescription;
    private DevComponents.DotNetBar.ButtonX bnBrowseOwners;
    private DevComponents.DotNetBar.ButtonX bnShowOtherJobsInCategory;
    private System.Windows.Forms.ComboBox comboCategory;
  }
}
