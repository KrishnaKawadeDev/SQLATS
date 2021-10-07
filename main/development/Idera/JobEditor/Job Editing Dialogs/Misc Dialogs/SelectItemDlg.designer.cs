namespace Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs.Misc_Dialogs
{
  partial class SelectItemDlg
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
       System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectItemDlg));
       this.ubnOK = new DevComponents.DotNetBar.ButtonX();
       this.ubnCancel = new DevComponents.DotNetBar.ButtonX();
       this.lblListTitle = new DevComponents.DotNetBar.LabelX();
       this.lbList = new System.Windows.Forms.ListBox();
       this.SuspendLayout();
       // 
       // ubnOK
       // 
       this.ubnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.ubnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
       this.ubnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
       this.ubnOK.Location = new System.Drawing.Point(212, 427);
       this.ubnOK.Name = "ubnOK";
       this.ubnOK.Size = new System.Drawing.Size(75, 23);
       this.ubnOK.TabIndex = 1;
       this.ubnOK.Text = "OK";
       this.ubnOK.Click += new System.EventHandler(this.OK_Click);
       // 
       // ubnCancel
       // 
       this.ubnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.ubnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
       this.ubnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
       this.ubnCancel.Location = new System.Drawing.Point(293, 427);
       this.ubnCancel.Name = "ubnCancel";
       this.ubnCancel.Size = new System.Drawing.Size(75, 23);
       this.ubnCancel.TabIndex = 2;
       this.ubnCancel.Text = "Cancel";
       // 
       // lblListTitle
       // 
       this.lblListTitle.AutoSize = true;
       this.lblListTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
       this.lblListTitle.Location = new System.Drawing.Point(12, 7);
       this.lblListTitle.Name = "lblListTitle";
       this.lblListTitle.Size = new System.Drawing.Size(57, 15);
       this.lblListTitle.TabIndex = 3;
       this.lblListTitle.Text = "ultraLabel1";
       // 
       // lbList
       // 
       this.lbList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                   | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
       this.lbList.FormattingEnabled = true;
       this.lbList.Location = new System.Drawing.Point(13, 28);
       this.lbList.Name = "lbList";
       this.lbList.Size = new System.Drawing.Size(355, 394);
       this.lbList.TabIndex = 4;
       this.lbList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbList_MouseDoubleClick);
       this.lbList.SelectedIndexChanged += new System.EventHandler(this.lbList_SelectedIndexChanged);
       // 
       // SelectItemDlg
       // 
       this.BackColor = System.Drawing.SystemColors.ControlLightLight;
       this.ClientSize = new System.Drawing.Size(380, 462);
       this.Controls.Add(this.lbList);
       this.Controls.Add(this.lblListTitle);
       this.Controls.Add(this.ubnCancel);
       this.Controls.Add(this.ubnOK);
       this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
       this.Name = "SelectItemDlg";
       this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
       this.Text = "Select login";
       this.ResumeLayout(false);
       this.PerformLayout();

    }

    #endregion

    private DevComponents.DotNetBar.ButtonX ubnOK;
    private DevComponents.DotNetBar.ButtonX ubnCancel;
    private DevComponents.DotNetBar.LabelX lblListTitle;
    private System.Windows.Forms.ListBox lbList;
  }
}