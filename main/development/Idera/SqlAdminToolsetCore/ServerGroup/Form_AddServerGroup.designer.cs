using System;

namespace Idera.SqlAdminToolset.Core
{
  partial class Form_AddServerGroup
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
       this.components = new System.ComponentModel.Container();
       System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_AddServerGroup ) );
       this.labelLicenseKey = new DevComponents.DotNetBar.LabelX();
       this.textServerGroup = new DevComponents.DotNetBar.Controls.TextBoxX();
       this.treeServerGroups = new System.Windows.Forms.TreeView();
       this.imageList = new System.Windows.Forms.ImageList( this.components );
       this.labelPrompt = new DevComponents.DotNetBar.LabelX();
       this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
       this.buttonOK = new DevComponents.DotNetBar.ButtonX();
       this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
       this.groupPanel1.SuspendLayout();
       this.SuspendLayout();
       // 
       // labelLicenseKey
       // 
       this.labelLicenseKey.BackColor = System.Drawing.Color.Transparent;
       this.labelLicenseKey.Location = new System.Drawing.Point( 9, 12 );
       this.labelLicenseKey.Name = "labelLicenseKey";
       this.labelLicenseKey.Size = new System.Drawing.Size( 71, 15 );
       this.labelLicenseKey.TabIndex = 0;
       this.labelLicenseKey.Text = "Server Group:";
       // 
       // textServerGroup
       // 
       // 
       // 
       // 
       this.textServerGroup.Border.Class = "TextBoxBorder";
       this.textServerGroup.Location = new System.Drawing.Point( 86, 9 );
       this.textServerGroup.Name = "textServerGroup";
       this.textServerGroup.Size = new System.Drawing.Size( 389, 20 );
       this.textServerGroup.TabIndex = 1;
       this.textServerGroup.TextChanged += new System.EventHandler( this.textServerGroup_TextChanged );
       // 
       // treeServerGroups
       // 
       this.treeServerGroups.HideSelection = false;
       this.treeServerGroups.ImageIndex = 0;
       this.treeServerGroups.ImageList = this.imageList;
       this.treeServerGroups.Location = new System.Drawing.Point( 9, 65 );
       this.treeServerGroups.Name = "treeServerGroups";
       this.treeServerGroups.SelectedImageIndex = 0;
       this.treeServerGroups.Size = new System.Drawing.Size( 466, 303 );
       this.treeServerGroups.TabIndex = 3;
       // 
       // imageList
       // 
       this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject( "imageList.ImageStream" )));
       this.imageList.TransparentColor = System.Drawing.Color.Black;
       this.imageList.Images.SetKeyName( 0, "ServerGroups_16.png" );
       this.imageList.Images.SetKeyName( 1, "server.png" );
       // 
       // labelPrompt
       // 
       this.labelPrompt.AutoSize = true;
       this.labelPrompt.BackColor = System.Drawing.Color.Transparent;
       this.labelPrompt.Location = new System.Drawing.Point( 9, 46 );
       this.labelPrompt.Name = "labelPrompt";
       this.labelPrompt.Size = new System.Drawing.Size( 208, 15 );
       this.labelPrompt.TabIndex = 2;
       this.labelPrompt.Text = "Select a location for the new server group:";
       // 
       // buttonCancel
       // 
       this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
       this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
       this.buttonCancel.Location = new System.Drawing.Point( 424, 419 );
       this.buttonCancel.Name = "buttonCancel";
       this.buttonCancel.Size = new System.Drawing.Size( 75, 23 );
       this.buttonCancel.TabIndex = 29;
       this.buttonCancel.Text = "&Cancel";
       // 
       // buttonOK
       // 
       this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
       this.buttonOK.Enabled = false;
       this.buttonOK.Location = new System.Drawing.Point( 343, 419 );
       this.buttonOK.Name = "buttonOK";
       this.buttonOK.Size = new System.Drawing.Size( 75, 23 );
       this.buttonOK.TabIndex = 28;
       this.buttonOK.Text = "&OK";
       this.buttonOK.Click += new System.EventHandler( this.buttonOK_Click );
       // 
       // groupPanel1
       // 
       this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
       this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
       this.groupPanel1.Controls.Add( this.labelLicenseKey );
       this.groupPanel1.Controls.Add( this.textServerGroup );
       this.groupPanel1.Controls.Add( this.labelPrompt );
       this.groupPanel1.Controls.Add( this.treeServerGroups );
       this.groupPanel1.IsShadowEnabled = true;
       this.groupPanel1.Location = new System.Drawing.Point( 8, 8 );
       this.groupPanel1.Name = "groupPanel1";
       this.groupPanel1.Size = new System.Drawing.Size( 491, 403 );
       // 
       // 
       // 
       this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
       this.groupPanel1.Style.BackColorGradientAngle = 90;
       this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
       this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
       this.groupPanel1.Style.BorderBottomWidth = 1;
       this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
       this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
       this.groupPanel1.Style.BorderLeftWidth = 1;
       this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
       this.groupPanel1.Style.BorderRightWidth = 1;
       this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
       this.groupPanel1.Style.BorderTopWidth = 1;
       this.groupPanel1.Style.CornerDiameter = 4;
       this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
       this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
       this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
       this.groupPanel1.TabIndex = 30;
       this.groupPanel1.Text = "Specify New Server Group";
       // 
       // Form_AddServerGroup
       // 
       this.AcceptButton = this.buttonOK;
       this.BackColor = System.Drawing.Color.White;
       this.CancelButton = this.buttonCancel;
       this.CausesValidation = false;
       this.ClientSize = new System.Drawing.Size( 507, 449 );
       this.Controls.Add( this.groupPanel1 );
       this.Controls.Add( this.buttonCancel );
       this.Controls.Add( this.buttonOK );
       this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
       this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
       this.MaximizeBox = false;
       this.MinimizeBox = false;
       this.Name = "Form_AddServerGroup";
       this.ShowInTaskbar = false;
       this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
       this.Text = "Add Server Group";
       this.groupPanel1.ResumeLayout( false );
       this.groupPanel1.PerformLayout();
       this.ResumeLayout( false );

    }

    #endregion

    private DevComponents.DotNetBar.LabelX labelLicenseKey;
     private DevComponents.DotNetBar.Controls.TextBoxX textServerGroup;
     private System.Windows.Forms.TreeView treeServerGroups;
     private DevComponents.DotNetBar.LabelX labelPrompt;
     private System.Windows.Forms.ImageList imageList;
     private DevComponents.DotNetBar.ButtonX buttonCancel;
     private DevComponents.DotNetBar.ButtonX buttonOK;
     private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
  }
}