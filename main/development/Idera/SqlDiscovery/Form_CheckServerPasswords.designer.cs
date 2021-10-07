using System;

namespace Idera.SqlAdminToolset.SqlDiscovery
{
  partial class Form_CheckServerPasswords
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
       System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_CheckServerPasswords ) );
       this.labelX1 = new DevComponents.DotNetBar.LabelX();
       this.checklistServers = new DevComponents.DotNetBar.Controls.ListViewEx();
       this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
       this.buttonSelectAll = new DevComponents.DotNetBar.ButtonX();
       this.buttonClearAll = new DevComponents.DotNetBar.ButtonX();
       this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
       this.buttonOK = new DevComponents.DotNetBar.ButtonX();
       this.labelX2 = new DevComponents.DotNetBar.LabelX();
       this.SuspendLayout();
       // 
       // labelX1
       // 
       this.labelX1.AutoSize = true;
       this.labelX1.Location = new System.Drawing.Point( 12, 40 );
       this.labelX1.Name = "labelX1";
       this.labelX1.Size = new System.Drawing.Size( 152, 13 );
       this.labelX1.TabIndex = 8;
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
       this.checklistServers.Location = new System.Drawing.Point( 12, 57 );
       this.checklistServers.Name = "checklistServers";
       this.checklistServers.Size = new System.Drawing.Size( 508, 330 );
       this.checklistServers.Sorting = System.Windows.Forms.SortOrder.Ascending;
       this.checklistServers.TabIndex = 9;
       this.checklistServers.UseCompatibleStateImageBehavior = false;
       this.checklistServers.View = System.Windows.Forms.View.Details;
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
       this.buttonSelectAll.Location = new System.Drawing.Point( 12, 394 );
       this.buttonSelectAll.Name = "buttonSelectAll";
       this.buttonSelectAll.Size = new System.Drawing.Size( 74, 20 );
       this.buttonSelectAll.TabIndex = 10;
       this.buttonSelectAll.Text = "Select &All";
       this.buttonSelectAll.Click += new System.EventHandler( this.buttonSelectAll_Click );
       // 
       // buttonClearAll
       // 
       this.buttonClearAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.buttonClearAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
       this.buttonClearAll.Location = new System.Drawing.Point( 92, 394 );
       this.buttonClearAll.Name = "buttonClearAll";
       this.buttonClearAll.Size = new System.Drawing.Size( 74, 20 );
       this.buttonClearAll.TabIndex = 11;
       this.buttonClearAll.Text = "C&lear All";
       this.buttonClearAll.Click += new System.EventHandler( this.buttonClearAll_Click );
       // 
       // buttonCancel
       // 
       this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
       this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
       this.buttonCancel.Location = new System.Drawing.Point( 446, 394 );
       this.buttonCancel.Name = "buttonCancel";
       this.buttonCancel.Size = new System.Drawing.Size( 74, 20 );
       this.buttonCancel.TabIndex = 13;
       this.buttonCancel.Text = "&Cancel";
       // 
       // buttonOK
       // 
       this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
       this.buttonOK.Location = new System.Drawing.Point( 366, 394 );
       this.buttonOK.Name = "buttonOK";
       this.buttonOK.Size = new System.Drawing.Size( 74, 20 );
       this.buttonOK.TabIndex = 12;
       this.buttonOK.Text = "&OK";
       this.buttonOK.Click += new System.EventHandler( this.buttonOK_Click );
       // 
       // labelX2
       // 
       this.labelX2.AutoSize = true;
       this.labelX2.Location = new System.Drawing.Point( 12, 12 );
       this.labelX2.Name = "labelX2";
       this.labelX2.Size = new System.Drawing.Size( 483, 13 );
       this.labelX2.TabIndex = 14;
       this.labelX2.Text = "This will launch the Password Checker tool to check the passwords on the servers " +
           "that you specify,";
       // 
       // Form_CheckServerPasswords
       // 
       this.BackColor = System.Drawing.Color.White;
       this.CancelButton = this.buttonCancel;
       this.CausesValidation = false;
       this.ClientSize = new System.Drawing.Size( 531, 421 );
       this.Controls.Add( this.labelX2 );
       this.Controls.Add( this.buttonCancel );
       this.Controls.Add( this.buttonOK );
       this.Controls.Add( this.checklistServers );
       this.Controls.Add( this.buttonClearAll );
       this.Controls.Add( this.buttonSelectAll );
       this.Controls.Add( this.labelX1 );
       this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
       this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
       this.MaximizeBox = false;
       this.MinimizeBox = false;
       this.Name = "Form_CheckServerPasswords";
       this.ShowInTaskbar = false;
       this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
       this.Text = "Check Server Passwords";
       this.ResumeLayout( false );
       this.PerformLayout();

    }

    #endregion

    private DevComponents.DotNetBar.LabelX labelX1;
     private DevComponents.DotNetBar.Controls.ListViewEx checklistServers;
     private DevComponents.DotNetBar.ButtonX buttonSelectAll;
     private DevComponents.DotNetBar.ButtonX buttonClearAll;
     private System.Windows.Forms.ColumnHeader columnHeader1;
     private DevComponents.DotNetBar.ButtonX buttonCancel;
     private DevComponents.DotNetBar.ButtonX buttonOK;
     private DevComponents.DotNetBar.LabelX labelX2;
  }
}