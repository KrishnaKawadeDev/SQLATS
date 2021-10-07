using System;

namespace Idera.SqlAdminToolset.Core
{
  partial class Form_SaveServersAsServerGroup
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
       System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_SaveServersAsServerGroup ) );
       this.labelLicenseKey = new DevComponents.DotNetBar.LabelX();
       this.textServerGroup = new DevComponents.DotNetBar.Controls.TextBoxX();
       this.treeServerGroups = new System.Windows.Forms.TreeView();
       this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip( this.components );
       this.contextMenuOverwrite = new System.Windows.Forms.ToolStripMenuItem();
       this.imageList = new System.Windows.Forms.ImageList( this.components );
       this.labelPrompt = new DevComponents.DotNetBar.LabelX();
       this.labelX1 = new DevComponents.DotNetBar.LabelX();
       this.checklistServers = new DevComponents.DotNetBar.Controls.ListViewEx();
       this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
       this.buttonSelectAll = new DevComponents.DotNetBar.ButtonX();
       this.buttonClearAll = new DevComponents.DotNetBar.ButtonX();
       this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
       this.buttonOK = new DevComponents.DotNetBar.ButtonX();
       this.contextMenuStrip1.SuspendLayout();
       this.SuspendLayout();
       // 
       // labelLicenseKey
       // 
       this.labelLicenseKey.BackColor = System.Drawing.Color.Transparent;
       this.labelLicenseKey.Location = new System.Drawing.Point( 12, 14 );
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
       this.textServerGroup.Location = new System.Drawing.Point( 91, 12 );
       this.textServerGroup.Name = "textServerGroup";
       this.textServerGroup.Size = new System.Drawing.Size( 508, 20 );
       this.textServerGroup.TabIndex = 1;
       this.textServerGroup.TextChanged += new System.EventHandler( this.textServerGroup_TextChanged );
       // 
       // treeServerGroups
       // 
       this.treeServerGroups.ContextMenuStrip = this.contextMenuStrip1;
       this.treeServerGroups.HideSelection = false;
       this.treeServerGroups.ImageIndex = 0;
       this.treeServerGroups.ImageList = this.imageList;
       this.treeServerGroups.Location = new System.Drawing.Point( 13, 229 );
       this.treeServerGroups.Name = "treeServerGroups";
       this.treeServerGroups.SelectedImageIndex = 0;
       this.treeServerGroups.Size = new System.Drawing.Size( 587, 207 );
       this.treeServerGroups.TabIndex = 7;
       this.treeServerGroups.MouseUp += new System.Windows.Forms.MouseEventHandler( this.treeServerGroups_MouseUp );
       this.treeServerGroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.treeServerGroups_AfterSelect );
       this.treeServerGroups.KeyUp += new System.Windows.Forms.KeyEventHandler( this.treeServerGroups_KeyUp );
       // 
       // contextMenuStrip1
       // 
       this.contextMenuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuOverwrite} );
       this.contextMenuStrip1.Name = "contextMenuStrip1";
       this.contextMenuStrip1.Size = new System.Drawing.Size( 221, 26 );
       // 
       // contextMenuOverwrite
       // 
       this.contextMenuOverwrite.Name = "contextMenuOverwrite";
       this.contextMenuOverwrite.Size = new System.Drawing.Size( 220, 22 );
       this.contextMenuOverwrite.Text = "Overwrite this Server Group";
       this.contextMenuOverwrite.Click += new System.EventHandler( this.contextMenuOverwrite_Click );
       // 
       // imageList
       // 
       this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject( "imageList.ImageStream" )));
       this.imageList.TransparentColor = System.Drawing.Color.Black;
       this.imageList.Images.SetKeyName( 0, "server_earth.png" );
       this.imageList.Images.SetKeyName( 1, "server.png" );
       // 
       // labelPrompt
       // 
       this.labelPrompt.AutoSize = true;
       this.labelPrompt.Location = new System.Drawing.Point( 13, 210 );
       this.labelPrompt.Name = "labelPrompt";
       this.labelPrompt.Size = new System.Drawing.Size( 208, 15 );
       this.labelPrompt.TabIndex = 6;
       this.labelPrompt.Text = "Select a location for the new server group:";
       // 
       // labelX1
       // 
       this.labelX1.AutoSize = true;
       this.labelX1.Location = new System.Drawing.Point( 12, 46 );
       this.labelX1.Name = "labelX1";
       this.labelX1.Size = new System.Drawing.Size( 152, 15 );
       this.labelX1.TabIndex = 2;
       this.labelX1.Text = "Select SQL Servers to include:";
       // 
       // checklistServers
       // 
       // 
       // 
       // 
       this.checklistServers.Border.Class = "ListViewBorder";
       this.checklistServers.CheckBoxes = true;
       this.checklistServers.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1} );
       this.checklistServers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
       this.checklistServers.Location = new System.Drawing.Point( 12, 65 );
       this.checklistServers.Name = "checklistServers";
       this.checklistServers.Size = new System.Drawing.Size( 508, 139 );
       this.checklistServers.Sorting = System.Windows.Forms.SortOrder.Ascending;
       this.checklistServers.TabIndex = 3;
       this.checklistServers.UseCompatibleStateImageBehavior = false;
       this.checklistServers.View = System.Windows.Forms.View.Details;
       this.checklistServers.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler( this.checklistServers_ItemChecked );
       // 
       // columnHeader1
       // 
       this.columnHeader1.Text = "SQL Server";
       this.columnHeader1.Width = 490;
       // 
       // buttonSelectAll
       // 
       this.buttonSelectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.buttonSelectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
       this.buttonSelectAll.Location = new System.Drawing.Point( 526, 65 );
       this.buttonSelectAll.Name = "buttonSelectAll";
       this.buttonSelectAll.Size = new System.Drawing.Size( 74, 20 );
       this.buttonSelectAll.TabIndex = 4;
       this.buttonSelectAll.Text = "Select &All";
       this.buttonSelectAll.Click += new System.EventHandler( this.buttonSelectAll_Click );
       // 
       // buttonClearAll
       // 
       this.buttonClearAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.buttonClearAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
       this.buttonClearAll.Location = new System.Drawing.Point( 526, 91 );
       this.buttonClearAll.Name = "buttonClearAll";
       this.buttonClearAll.Size = new System.Drawing.Size( 74, 20 );
       this.buttonClearAll.TabIndex = 5;
       this.buttonClearAll.Text = "C&lear All";
       this.buttonClearAll.Click += new System.EventHandler( this.buttonClearAll_Click );
       // 
       // buttonCancel
       // 
       this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
       this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
       this.buttonCancel.Location = new System.Drawing.Point( 527, 445 );
       this.buttonCancel.Name = "buttonCancel";
       this.buttonCancel.Size = new System.Drawing.Size( 74, 20 );
       this.buttonCancel.TabIndex = 9;
       this.buttonCancel.Text = "&Cancel";
       // 
       // buttonOK
       // 
       this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
       this.buttonOK.Location = new System.Drawing.Point( 447, 445 );
       this.buttonOK.Name = "buttonOK";
       this.buttonOK.Size = new System.Drawing.Size( 74, 20 );
       this.buttonOK.TabIndex = 8;
       this.buttonOK.Text = "&OK";
       this.buttonOK.Click += new System.EventHandler( this.buttonOK_Click );
       // 
       // Form_SaveServersAsServerGroup
       // 
       this.AcceptButton = this.buttonOK;
       this.BackColor = System.Drawing.Color.White;
       this.CancelButton = this.buttonCancel;
       this.CausesValidation = false;
       this.ClientSize = new System.Drawing.Size( 611, 473 );
       this.Controls.Add( this.buttonOK );
       this.Controls.Add( this.buttonCancel );
       this.Controls.Add( this.checklistServers );
       this.Controls.Add( this.buttonClearAll );
       this.Controls.Add( this.buttonSelectAll );
       this.Controls.Add( this.treeServerGroups );
       this.Controls.Add( this.labelX1 );
       this.Controls.Add( this.labelPrompt );
       this.Controls.Add( this.textServerGroup );
       this.Controls.Add( this.labelLicenseKey );
       this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
       this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
       this.MaximizeBox = false;
       this.MinimizeBox = false;
       this.Name = "Form_SaveServersAsServerGroup";
       this.ShowInTaskbar = false;
       this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
       this.Text = "Save As Server Group";
       this.contextMenuStrip1.ResumeLayout( false );
       this.ResumeLayout( false );
       this.PerformLayout();

    }

    #endregion

    private DevComponents.DotNetBar.LabelX labelLicenseKey;
     private DevComponents.DotNetBar.Controls.TextBoxX textServerGroup;
     private System.Windows.Forms.TreeView treeServerGroups;
     private DevComponents.DotNetBar.LabelX labelPrompt;
     private System.Windows.Forms.ImageList imageList;
     private DevComponents.DotNetBar.LabelX labelX1;
     private DevComponents.DotNetBar.Controls.ListViewEx checklistServers;
     private DevComponents.DotNetBar.ButtonX buttonSelectAll;
     private DevComponents.DotNetBar.ButtonX buttonClearAll;
     private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
     private System.Windows.Forms.ToolStripMenuItem contextMenuOverwrite;
     private System.Windows.Forms.ColumnHeader columnHeader1;
     private DevComponents.DotNetBar.ButtonX buttonCancel;
     private DevComponents.DotNetBar.ButtonX buttonOK;
  }
}