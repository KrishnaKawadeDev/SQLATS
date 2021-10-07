namespace Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs.Generic_SQL_Dialogs
{
  partial class ViewListWithNameDlg
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
       System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewListWithNameDlg));
       this.ultraLabel1 = new DevComponents.DotNetBar.LabelX();
       this.uteName = new DevComponents.DotNetBar.Controls.TextBoxX();
       this.lblListName = new DevComponents.DotNetBar.LabelX();
       this.lbList = new System.Windows.Forms.ListBox();
       this.ubnClose = new DevComponents.DotNetBar.ButtonX();
       this.SuspendLayout();
       // 
       // ultraLabel1
       // 
       this.ultraLabel1.AutoSize = true;
       this.ultraLabel1.Location = new System.Drawing.Point(12, 16);
       this.ultraLabel1.Name = "ultraLabel1";
       this.ultraLabel1.Size = new System.Drawing.Size(35, 15);
       this.ultraLabel1.TabIndex = 0;
       this.ultraLabel1.Text = "Name:";
       // 
       // uteName
       // 
       this.uteName.BackColor = System.Drawing.SystemColors.ControlLightLight;
       this.uteName.Location = new System.Drawing.Point(13, 36);
       this.uteName.Name = "uteName";
       this.uteName.ReadOnly = true;
       this.uteName.Size = new System.Drawing.Size(475, 21);
       this.uteName.TabIndex = 1;
       // 
       // lblListName
       // 
       this.lblListName.AutoSize = true;
       this.lblListName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
       this.lblListName.Location = new System.Drawing.Point(13, 63);
       this.lblListName.Name = "lblListName";
       this.lblListName.Size = new System.Drawing.Size(102, 15);
       this.lblListName.TabIndex = 2;
       this.lblListName.Text = "Jobs in this category";
       // 
       // lbList
       // 
       this.lbList.FormattingEnabled = true;
       this.lbList.Location = new System.Drawing.Point(13, 84);
       this.lbList.Name = "lbList";
       this.lbList.Size = new System.Drawing.Size(472, 251);
       this.lbList.TabIndex = 3;
       // 
       // ubnClose
       // 
       this.ubnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.ubnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
       this.ubnClose.Location = new System.Drawing.Point(410, 341);
       this.ubnClose.Name = "ubnClose";
       this.ubnClose.Size = new System.Drawing.Size(75, 23);
       this.ubnClose.TabIndex = 4;
       this.ubnClose.Text = "Close";
       // 
       // ViewListWithNameDlg
       // 
       this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
       this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
       this.BackColor = System.Drawing.SystemColors.ControlLightLight;
       this.ClientSize = new System.Drawing.Size(491, 372);
       this.Controls.Add(this.ubnClose);
       this.Controls.Add(this.lbList);
       this.Controls.Add(this.lblListName);
       this.Controls.Add(this.uteName);
       this.Controls.Add(this.ultraLabel1);
       this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
       this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
       this.Name = "ViewListWithNameDlg";
       this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
       this.Text = "ViewListWithNameDlg";
       this.ResumeLayout(false);
       this.PerformLayout();

    }

    #endregion

    private DevComponents.DotNetBar.LabelX ultraLabel1;
    private DevComponents.DotNetBar.Controls.TextBoxX uteName;
    private DevComponents.DotNetBar.LabelX lblListName;
    private System.Windows.Forms.ListBox lbList;
    private DevComponents.DotNetBar.ButtonX ubnClose;
  }
}