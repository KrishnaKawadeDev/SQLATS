namespace Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs
{
  partial class EditJobNotificationsUC
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
       this.ultraLabel1 = new DevComponents.DotNetBar.LabelX();
       this.cbEmail = new System.Windows.Forms.CheckBox();
       this.cbPage = new System.Windows.Forms.CheckBox();
       this.cbNetSend = new System.Windows.Forms.CheckBox();
       this.cbEventLog = new System.Windows.Forms.CheckBox();
       this.cbDeleteJob = new System.Windows.Forms.CheckBox();
       this.comboNetSendOperator = new System.Windows.Forms.ComboBox();
       this.comboNetSendJobCondition = new System.Windows.Forms.ComboBox();
       this.comboPageJobCondition = new System.Windows.Forms.ComboBox();
       this.comboPageOperator = new System.Windows.Forms.ComboBox();
       this.comboEmailJobCondition = new System.Windows.Forms.ComboBox();
       this.comboEmailOperator = new System.Windows.Forms.ComboBox();
       this.comboEventLogJobCondition = new System.Windows.Forms.ComboBox();
       this.comboDeleteJobJobCondition = new System.Windows.Forms.ComboBox();
       this.SuspendLayout();
       // 
       // ultraLabel1
       // 
       this.ultraLabel1.AutoSize = true;
       this.ultraLabel1.Location = new System.Drawing.Point(3, 12);
       this.ultraLabel1.Name = "ultraLabel1";
       this.ultraLabel1.Size = new System.Drawing.Size(213, 15);
       this.ultraLabel1.TabIndex = 0;
       this.ultraLabel1.Text = "Actions to perform when the job completes:";
       // 
       // cbEmail
       // 
       this.cbEmail.AutoSize = true;
       this.cbEmail.Location = new System.Drawing.Point(13, 32);
       this.cbEmail.Name = "cbEmail";
       this.cbEmail.Size = new System.Drawing.Size(57, 17);
       this.cbEmail.TabIndex = 0;
       this.cbEmail.Text = "&E-mail:";
       this.cbEmail.UseVisualStyleBackColor = true;
       this.cbEmail.CheckedChanged += new System.EventHandler(this.cbEmail_CheckedChanged);
       // 
       // cbPage
       // 
       this.cbPage.AutoSize = true;
       this.cbPage.Location = new System.Drawing.Point(13, 70);
       this.cbPage.Name = "cbPage";
       this.cbPage.Size = new System.Drawing.Size(54, 17);
       this.cbPage.TabIndex = 3;
       this.cbPage.Text = "&Page:";
       this.cbPage.UseVisualStyleBackColor = true;
       this.cbPage.CheckedChanged += new System.EventHandler(this.cbPage_CheckedChanged);
       // 
       // cbNetSend
       // 
       this.cbNetSend.AutoSize = true;
       this.cbNetSend.Location = new System.Drawing.Point(13, 107);
       this.cbNetSend.Name = "cbNetSend";
       this.cbNetSend.Size = new System.Drawing.Size(72, 17);
       this.cbNetSend.TabIndex = 6;
       this.cbNetSend.Text = "&Net send:";
       this.cbNetSend.UseVisualStyleBackColor = true;
       this.cbNetSend.CheckedChanged += new System.EventHandler(this.cbNetSend_CheckedChanged);
       // 
       // cbEventLog
       // 
       this.cbEventLog.AutoSize = true;
       this.cbEventLog.Location = new System.Drawing.Point(13, 147);
       this.cbEventLog.Name = "cbEventLog";
       this.cbEventLog.Size = new System.Drawing.Size(233, 17);
       this.cbEventLog.TabIndex = 9;
       this.cbEventLog.Text = "&Write to the Windows Application event log:";
       this.cbEventLog.UseVisualStyleBackColor = true;
       this.cbEventLog.CheckedChanged += new System.EventHandler(this.cbEventLog_CheckedChanged);
       // 
       // cbDeleteJob
       // 
       this.cbDeleteJob.AutoSize = true;
       this.cbDeleteJob.Location = new System.Drawing.Point(13, 184);
       this.cbDeleteJob.Name = "cbDeleteJob";
       this.cbDeleteJob.Size = new System.Drawing.Size(140, 17);
       this.cbDeleteJob.TabIndex = 11;
       this.cbDeleteJob.Text = "A&utomatically delete job:";
       this.cbDeleteJob.UseVisualStyleBackColor = true;
       this.cbDeleteJob.CheckedChanged += new System.EventHandler(this.cbDeleteJob_CheckedChanged);
       // 
       // comboNetSendOperator
       // 
       this.comboNetSendOperator.BackColor = System.Drawing.SystemColors.ControlLightLight;
       this.comboNetSendOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
       this.comboNetSendOperator.FormattingEnabled = true;
       this.comboNetSendOperator.Location = new System.Drawing.Point(89, 105);
       this.comboNetSendOperator.Name = "comboNetSendOperator";
       this.comboNetSendOperator.Size = new System.Drawing.Size(204, 21);
       this.comboNetSendOperator.TabIndex = 7;
       // 
       // comboNetSendJobCondition
       // 
       this.comboNetSendJobCondition.BackColor = System.Drawing.SystemColors.ControlLightLight;
       this.comboNetSendJobCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
       this.comboNetSendJobCondition.FormattingEnabled = true;
       this.comboNetSendJobCondition.Items.AddRange(new object[] {
            "When the job succeeds",
            "When the job fails",
            "When the job completes"});
       this.comboNetSendJobCondition.Location = new System.Drawing.Point(299, 105);
       this.comboNetSendJobCondition.Name = "comboNetSendJobCondition";
       this.comboNetSendJobCondition.Size = new System.Drawing.Size(204, 21);
       this.comboNetSendJobCondition.TabIndex = 8;
       // 
       // comboPageJobCondition
       // 
       this.comboPageJobCondition.BackColor = System.Drawing.SystemColors.ControlLightLight;
       this.comboPageJobCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
       this.comboPageJobCondition.FormattingEnabled = true;
       this.comboPageJobCondition.Items.AddRange(new object[] {
            "When the job succeeds",
            "When the job fails",
            "When the job completes"});
       this.comboPageJobCondition.Location = new System.Drawing.Point(299, 68);
       this.comboPageJobCondition.Name = "comboPageJobCondition";
       this.comboPageJobCondition.Size = new System.Drawing.Size(204, 21);
       this.comboPageJobCondition.TabIndex = 5;
       // 
       // comboPageOperator
       // 
       this.comboPageOperator.BackColor = System.Drawing.SystemColors.ControlLightLight;
       this.comboPageOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
       this.comboPageOperator.FormattingEnabled = true;
       this.comboPageOperator.Location = new System.Drawing.Point(89, 68);
       this.comboPageOperator.Name = "comboPageOperator";
       this.comboPageOperator.Size = new System.Drawing.Size(204, 21);
       this.comboPageOperator.TabIndex = 4;
       // 
       // comboEmailJobCondition
       // 
       this.comboEmailJobCondition.BackColor = System.Drawing.SystemColors.ControlLightLight;
       this.comboEmailJobCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
       this.comboEmailJobCondition.FormattingEnabled = true;
       this.comboEmailJobCondition.Items.AddRange(new object[] {
            "When the job succeeds",
            "When the job fails",
            "When the job completes"});
       this.comboEmailJobCondition.Location = new System.Drawing.Point(299, 30);
       this.comboEmailJobCondition.Name = "comboEmailJobCondition";
       this.comboEmailJobCondition.Size = new System.Drawing.Size(204, 21);
       this.comboEmailJobCondition.TabIndex = 2;
       // 
       // comboEmailOperator
       // 
       this.comboEmailOperator.BackColor = System.Drawing.SystemColors.ControlLightLight;
       this.comboEmailOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
       this.comboEmailOperator.FormattingEnabled = true;
       this.comboEmailOperator.Location = new System.Drawing.Point(89, 30);
       this.comboEmailOperator.Name = "comboEmailOperator";
       this.comboEmailOperator.Size = new System.Drawing.Size(204, 21);
       this.comboEmailOperator.TabIndex = 1;
       // 
       // comboEventLogJobCondition
       // 
       this.comboEventLogJobCondition.BackColor = System.Drawing.SystemColors.ControlLightLight;
       this.comboEventLogJobCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
       this.comboEventLogJobCondition.FormattingEnabled = true;
       this.comboEventLogJobCondition.Items.AddRange(new object[] {
            "When the job succeeds",
            "When the job fails",
            "When the job completes"});
       this.comboEventLogJobCondition.Location = new System.Drawing.Point(299, 145);
       this.comboEventLogJobCondition.Name = "comboEventLogJobCondition";
       this.comboEventLogJobCondition.Size = new System.Drawing.Size(204, 21);
       this.comboEventLogJobCondition.TabIndex = 10;
       // 
       // comboDeleteJobJobCondition
       // 
       this.comboDeleteJobJobCondition.BackColor = System.Drawing.SystemColors.ControlLightLight;
       this.comboDeleteJobJobCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
       this.comboDeleteJobJobCondition.FormattingEnabled = true;
       this.comboDeleteJobJobCondition.Items.AddRange(new object[] {
            "When the job succeeds",
            "When the job fails",
            "When the job completes"});
       this.comboDeleteJobJobCondition.Location = new System.Drawing.Point(299, 182);
       this.comboDeleteJobJobCondition.Name = "comboDeleteJobJobCondition";
       this.comboDeleteJobJobCondition.Size = new System.Drawing.Size(204, 21);
       this.comboDeleteJobJobCondition.TabIndex = 12;
       // 
       // EditJobNotificationsUC
       // 
       this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
       this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
       this.Controls.Add(this.comboDeleteJobJobCondition);
       this.Controls.Add(this.comboEventLogJobCondition);
       this.Controls.Add(this.comboEmailJobCondition);
       this.Controls.Add(this.comboEmailOperator);
       this.Controls.Add(this.comboPageJobCondition);
       this.Controls.Add(this.comboPageOperator);
       this.Controls.Add(this.comboNetSendJobCondition);
       this.Controls.Add(this.comboNetSendOperator);
       this.Controls.Add(this.cbDeleteJob);
       this.Controls.Add(this.cbEventLog);
       this.Controls.Add(this.cbNetSend);
       this.Controls.Add(this.cbPage);
       this.Controls.Add(this.cbEmail);
       this.Controls.Add(this.ultraLabel1);
       this.Name = "EditJobNotificationsUC";
       this.Size = new System.Drawing.Size(507, 530);
       this.Load += new System.EventHandler(this.EditJobNotificationsUC_Load);
       this.ResumeLayout(false);
       this.PerformLayout();

    }

    #endregion

    private DevComponents.DotNetBar.LabelX ultraLabel1;
    private System.Windows.Forms.CheckBox cbEmail;
    private System.Windows.Forms.CheckBox cbPage;
    private System.Windows.Forms.CheckBox cbNetSend;
    private System.Windows.Forms.CheckBox cbEventLog;
    private System.Windows.Forms.CheckBox cbDeleteJob;
    private System.Windows.Forms.ComboBox comboNetSendOperator;
    private System.Windows.Forms.ComboBox comboNetSendJobCondition;
    private System.Windows.Forms.ComboBox comboPageJobCondition;
    private System.Windows.Forms.ComboBox comboPageOperator;
    private System.Windows.Forms.ComboBox comboEmailJobCondition;
    private System.Windows.Forms.ComboBox comboEmailOperator;
    private System.Windows.Forms.ComboBox comboEventLogJobCondition;
    private System.Windows.Forms.ComboBox comboDeleteJobJobCondition;
  }
}
