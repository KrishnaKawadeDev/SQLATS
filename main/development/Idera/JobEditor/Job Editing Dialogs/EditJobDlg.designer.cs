namespace Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs
{
  partial class EditJobDlg
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
       System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditJobDlg));
       this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
       this.bnOK = new DevComponents.DotNetBar.ButtonX();
       this.bnCancel = new DevComponents.DotNetBar.ButtonX();
       this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
       this.listBoxPages = new System.Windows.Forms.ListBox();
       this.pnConnectionInfo = new DevComponents.DotNetBar.PanelEx();
       this.ulbUsername = new System.Windows.Forms.Label();
       this.ultraLabel2 = new System.Windows.Forms.Label();
       this.ulbServerName = new System.Windows.Forms.Label();
       this.ultraLabel1 = new System.Windows.Forms.Label();
       this.panelEx6 = new DevComponents.DotNetBar.PanelEx();
       this.panelEx7 = new DevComponents.DotNetBar.PanelEx();
       this.panelEx8 = new DevComponents.DotNetBar.PanelEx();
       this.panelEx9 = new DevComponents.DotNetBar.PanelEx();
       this.UCPanel = new DevComponents.DotNetBar.PanelEx();
       this.panelEx1.SuspendLayout();
       this.panelEx2.SuspendLayout();
       this.pnConnectionInfo.SuspendLayout();
       this.SuspendLayout();
       // 
       // panelEx1
       // 
       this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
       this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
       this.panelEx1.Controls.Add(this.bnOK);
       this.panelEx1.Controls.Add(this.bnCancel);
       this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
       this.panelEx1.Location = new System.Drawing.Point(0, 558);
       this.panelEx1.Name = "panelEx1";
       this.panelEx1.Size = new System.Drawing.Size(688, 38);
       this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
       this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.White;
       this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.White;
       this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
       this.panelEx1.Style.GradientAngle = 90;
       this.panelEx1.TabIndex = 1;
       // 
       // bnOK
       // 
       this.bnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.bnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
       this.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
       this.bnOK.Location = new System.Drawing.Point(520, 6);
       this.bnOK.Name = "bnOK";
       this.bnOK.Size = new System.Drawing.Size(75, 23);
       this.bnOK.TabIndex = 1;
       this.bnOK.Text = "OK";
       this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
       // 
       // bnCancel
       // 
       this.bnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
       this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
       this.bnCancel.Location = new System.Drawing.Point(601, 6);
       this.bnCancel.Name = "bnCancel";
       this.bnCancel.Size = new System.Drawing.Size(75, 23);
       this.bnCancel.TabIndex = 0;
       this.bnCancel.Text = "Cancel";
       this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
       // 
       // panelEx2
       // 
       this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
       this.panelEx2.Controls.Add(this.listBoxPages);
       this.panelEx2.Controls.Add(this.pnConnectionInfo);
       this.panelEx2.Controls.Add(this.panelEx7);
       this.panelEx2.Dock = System.Windows.Forms.DockStyle.Left;
       this.panelEx2.Location = new System.Drawing.Point(0, 0);
       this.panelEx2.Name = "panelEx2";
       this.panelEx2.Size = new System.Drawing.Size(167, 558);
       this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
       this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
       this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
       this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
       this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
       this.panelEx2.Style.GradientAngle = 90;
       this.panelEx2.TabIndex = 1;
       // 
       // listBoxPages
       // 
       this.listBoxPages.Dock = System.Windows.Forms.DockStyle.Fill;
       this.listBoxPages.FormattingEnabled = true;
       this.listBoxPages.IntegralHeight = false;
       this.listBoxPages.Location = new System.Drawing.Point(0, 18);
       this.listBoxPages.Name = "listBoxPages";
       this.listBoxPages.Size = new System.Drawing.Size(167, 410);
       this.listBoxPages.TabIndex = 1;
       this.listBoxPages.SelectedIndexChanged += new System.EventHandler(this.listBoxPages_SelectedIndexChanged);
       // 
       // pnConnectionInfo
       // 
       this.pnConnectionInfo.CanvasColor = System.Drawing.SystemColors.Control;
       this.pnConnectionInfo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
       this.pnConnectionInfo.Controls.Add(this.ulbUsername);
       this.pnConnectionInfo.Controls.Add(this.ultraLabel2);
       this.pnConnectionInfo.Controls.Add(this.ulbServerName);
       this.pnConnectionInfo.Controls.Add(this.ultraLabel1);
       this.pnConnectionInfo.Controls.Add(this.panelEx6);
       this.pnConnectionInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
       this.pnConnectionInfo.Location = new System.Drawing.Point(0, 428);
       this.pnConnectionInfo.Name = "pnConnectionInfo";
       this.pnConnectionInfo.Size = new System.Drawing.Size(167, 130);
       this.pnConnectionInfo.Style.Alignment = System.Drawing.StringAlignment.Center;
       this.pnConnectionInfo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
       this.pnConnectionInfo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
       this.pnConnectionInfo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
       this.pnConnectionInfo.Style.GradientAngle = 90;
       this.pnConnectionInfo.TabIndex = 2;
       // 
       // ulbUsername
       // 
       this.ulbUsername.AutoSize = true;
       this.ulbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
       this.ulbUsername.Location = new System.Drawing.Point(8, 93);
       this.ulbUsername.Name = "ulbUsername";
       this.ulbUsername.Size = new System.Drawing.Size(57, 13);
       this.ulbUsername.TabIndex = 4;
       this.ulbUsername.Text = "UserName";
       // 
       // ultraLabel2
       // 
       this.ultraLabel2.AutoSize = true;
       this.ultraLabel2.Location = new System.Drawing.Point(3, 73);
       this.ultraLabel2.Name = "ultraLabel2";
       this.ultraLabel2.Size = new System.Drawing.Size(64, 13);
       this.ultraLabel2.TabIndex = 3;
       this.ultraLabel2.Text = "Connection:";
       // 
       // ulbServerName
       // 
       this.ulbServerName.AutoSize = true;
       this.ulbServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
       this.ulbServerName.Location = new System.Drawing.Point(8, 53);
       this.ulbServerName.Name = "ulbServerName";
       this.ulbServerName.Size = new System.Drawing.Size(66, 13);
       this.ulbServerName.TabIndex = 2;
       this.ulbServerName.Text = "ServerName";
       // 
       // ultraLabel1
       // 
       this.ultraLabel1.AutoSize = true;
       this.ultraLabel1.Location = new System.Drawing.Point(3, 33);
       this.ultraLabel1.Name = "ultraLabel1";
       this.ultraLabel1.Size = new System.Drawing.Size(41, 13);
       this.ultraLabel1.TabIndex = 1;
       this.ultraLabel1.Text = "Server:";
       // 
       // panelEx6
       // 
       this.panelEx6.CanvasColor = System.Drawing.SystemColors.Control;
       this.panelEx6.Dock = System.Windows.Forms.DockStyle.Top;
       this.panelEx6.Location = new System.Drawing.Point(0, 0);
       this.panelEx6.Name = "panelEx6";
       this.panelEx6.Size = new System.Drawing.Size(167, 26);
       this.panelEx6.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
       this.panelEx6.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
       this.panelEx6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
       this.panelEx6.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
       this.panelEx6.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
       this.panelEx6.Style.GradientAngle = 90;
       this.panelEx6.TabIndex = 0;
       this.panelEx6.Text = "Connection";
       // 
       // panelEx7
       // 
       this.panelEx7.CanvasColor = System.Drawing.SystemColors.Control;
       this.panelEx7.Dock = System.Windows.Forms.DockStyle.Top;
       this.panelEx7.Location = new System.Drawing.Point(0, 0);
       this.panelEx7.Name = "panelEx7";
       this.panelEx7.Size = new System.Drawing.Size(167, 18);
       this.panelEx7.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
       this.panelEx7.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
       this.panelEx7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
       this.panelEx7.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
       this.panelEx7.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
       this.panelEx7.Style.GradientAngle = 90;
       this.panelEx7.TabIndex = 0;
       this.panelEx7.Text = "Select a page";
       // 
       // panelEx8
       // 
       this.panelEx8.CanvasColor = System.Drawing.SystemColors.Control;
       this.panelEx8.Dock = System.Windows.Forms.DockStyle.Top;
       this.panelEx8.Location = new System.Drawing.Point(167, 0);
       this.panelEx8.Name = "panelEx8";
       this.panelEx8.Size = new System.Drawing.Size(521, 28);
       this.panelEx8.Style.Alignment = System.Drawing.StringAlignment.Center;
       this.panelEx8.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
       this.panelEx8.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
       this.panelEx8.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
       this.panelEx8.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
       this.panelEx8.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
       this.panelEx8.Style.GradientAngle = 90;
       this.panelEx8.TabIndex = 0;
       // 
       // panelEx9
       // 
       this.panelEx9.CanvasColor = System.Drawing.SystemColors.Control;
       this.panelEx9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
       this.panelEx9.Dock = System.Windows.Forms.DockStyle.Left;
       this.panelEx9.Location = new System.Drawing.Point(167, 28);
       this.panelEx9.Name = "panelEx9";
       this.panelEx9.Size = new System.Drawing.Size(14, 530);
       this.panelEx9.Style.Alignment = System.Drawing.StringAlignment.Center;
       this.panelEx9.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
       this.panelEx9.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
       this.panelEx9.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
       this.panelEx9.Style.GradientAngle = 90;
       this.panelEx9.TabIndex = 1;
       // 
       // UCPanel
       // 
       this.UCPanel.CanvasColor = System.Drawing.SystemColors.Control;
       this.UCPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
       this.UCPanel.Dock = System.Windows.Forms.DockStyle.Fill;
       this.UCPanel.Location = new System.Drawing.Point(181, 28);
       this.UCPanel.Name = "UCPanel";
       this.UCPanel.Size = new System.Drawing.Size(507, 530);
       this.UCPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
       this.UCPanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
       this.UCPanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
       this.UCPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
       this.UCPanel.Style.GradientAngle = 90;
       this.UCPanel.TabIndex = 0;
       this.UCPanel.SizeChanged += new System.EventHandler(this.UCPanel_SizeChanged);
       // 
       // EditJobDlg
       // 
       this.AcceptButton = this.bnOK;
       this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
       this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
       this.BackColor = System.Drawing.SystemColors.ControlLightLight;
       this.CancelButton = this.bnCancel;
       this.ClientSize = new System.Drawing.Size(688, 596);
       this.Controls.Add(this.UCPanel);
       this.Controls.Add(this.panelEx9);
       this.Controls.Add(this.panelEx8);
       this.Controls.Add(this.panelEx2);
       this.Controls.Add(this.panelEx1);
       this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
       this.Name = "EditJobDlg";
       this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
       this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
       this.Text = "Job Properties";
       this.Load += new System.EventHandler(this.EditJobDlg_Load);
       this.panelEx1.ResumeLayout(false);
       this.panelEx2.ResumeLayout(false);
       this.pnConnectionInfo.ResumeLayout(false);
       this.pnConnectionInfo.PerformLayout();
       this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.PanelEx panelEx1;
    private DevComponents.DotNetBar.PanelEx panelEx2;
    private System.Windows.Forms.ListBox listBoxPages;
    private DevComponents.DotNetBar.PanelEx pnConnectionInfo;
    private DevComponents.DotNetBar.PanelEx panelEx6;
    private DevComponents.DotNetBar.PanelEx panelEx7;
    private DevComponents.DotNetBar.PanelEx panelEx8;
    private DevComponents.DotNetBar.PanelEx panelEx9;
    private DevComponents.DotNetBar.PanelEx UCPanel;
    private DevComponents.DotNetBar.ButtonX bnCancel;
    private DevComponents.DotNetBar.ButtonX bnOK;
    private System.Windows.Forms.Label ulbServerName;
    private System.Windows.Forms.Label ultraLabel1;
    private System.Windows.Forms.Label ulbUsername;
    private System.Windows.Forms.Label ultraLabel2;

  }
}