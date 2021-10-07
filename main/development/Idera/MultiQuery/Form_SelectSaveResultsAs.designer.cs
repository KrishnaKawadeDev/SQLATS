using System;

namespace Idera.SqlAdminToolset.MultiQuery
{
  partial class Form_SelectSaveResultsAs
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
       System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_SelectSaveResultsAs ) );
       this.labelX1 = new DevComponents.DotNetBar.LabelX();
       this.listTargets = new DevComponents.DotNetBar.Controls.ListViewEx();
       this.columnCheck = new System.Windows.Forms.ColumnHeader();
       this.columnTarget = new System.Windows.Forms.ColumnHeader();
       this.columnSucceeded = new System.Windows.Forms.ColumnHeader();
       this.buttonSelectAll = new DevComponents.DotNetBar.ButtonX();
       this.buttonClearAll = new DevComponents.DotNetBar.ButtonX();
       this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
       this.buttonOK = new DevComponents.DotNetBar.ButtonX();
       this.SuspendLayout();
       // 
       // labelX1
       // 
       this.labelX1.AutoSize = true;
       this.labelX1.Location = new System.Drawing.Point( 8, 6 );
       this.labelX1.Name = "labelX1";
       this.labelX1.Size = new System.Drawing.Size( 129, 15 );
       this.labelX1.TabIndex = 2;
       this.labelX1.Text = "Select which tabs to save:";
       // 
       // listTargets
       // 
       this.listTargets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                   | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
       // 
       // 
       // 
       this.listTargets.Border.Class = "ListViewBorder";
       this.listTargets.CheckBoxes = true;
       this.listTargets.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnCheck,
            this.columnTarget,
            this.columnSucceeded} );
       this.listTargets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
       this.listTargets.Location = new System.Drawing.Point( 8, 25 );
       this.listTargets.Name = "listTargets";
       this.listTargets.Size = new System.Drawing.Size( 380, 326 );
       this.listTargets.Sorting = System.Windows.Forms.SortOrder.Ascending;
       this.listTargets.TabIndex = 3;
       this.listTargets.UseCompatibleStateImageBehavior = false;
       this.listTargets.View = System.Windows.Forms.View.Details;
       this.listTargets.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler( this.checklistServers_ItemChecked );
       // 
       // columnCheck
       // 
       this.columnCheck.Text = "";
       this.columnCheck.Width = 20;
       // 
       // columnTarget
       // 
       this.columnTarget.Text = "Name";
       this.columnTarget.Width = 254;
       // 
       // columnSucceeded
       // 
       this.columnSucceeded.Text = "Result";
       this.columnSucceeded.Width = 80;
       // 
       // buttonSelectAll
       // 
       this.buttonSelectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.buttonSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
       this.buttonSelectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
       this.buttonSelectAll.Location = new System.Drawing.Point( 8, 357 );
       this.buttonSelectAll.Name = "buttonSelectAll";
       this.buttonSelectAll.Size = new System.Drawing.Size( 74, 20 );
       this.buttonSelectAll.TabIndex = 4;
       this.buttonSelectAll.Text = "Select &All";
       this.buttonSelectAll.Click += new System.EventHandler( this.buttonSelectAll_Click );
       // 
       // buttonClearAll
       // 
       this.buttonClearAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.buttonClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
       this.buttonClearAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
       this.buttonClearAll.Location = new System.Drawing.Point( 88, 357 );
       this.buttonClearAll.Name = "buttonClearAll";
       this.buttonClearAll.Size = new System.Drawing.Size( 74, 20 );
       this.buttonClearAll.TabIndex = 5;
       this.buttonClearAll.Text = "&Clear All";
       this.buttonClearAll.Click += new System.EventHandler( this.buttonClearAll_Click );
       // 
       // buttonCancel
       // 
       this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
       this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
       this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
       this.buttonCancel.Location = new System.Drawing.Point( 314, 357 );
       this.buttonCancel.Name = "buttonCancel";
       this.buttonCancel.Size = new System.Drawing.Size( 74, 20 );
       this.buttonCancel.TabIndex = 9;
       this.buttonCancel.Text = "&Cancel";
       // 
       // buttonOK
       // 
       this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
       this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
       this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
       this.buttonOK.Enabled = false;
       this.buttonOK.Location = new System.Drawing.Point( 235, 357 );
       this.buttonOK.Name = "buttonOK";
       this.buttonOK.Size = new System.Drawing.Size( 74, 20 );
       this.buttonOK.TabIndex = 8;
       this.buttonOK.Text = "&OK";
       this.buttonOK.Click += new System.EventHandler( this.buttonOK_Click );
       // 
       // Form_SelectSaveResultsAs
       // 
       this.AcceptButton = this.buttonOK;
       this.BackColor = System.Drawing.Color.White;
       this.CancelButton = this.buttonCancel;
       this.CausesValidation = false;
       this.ClientSize = new System.Drawing.Size( 394, 383 );
       this.Controls.Add( this.listTargets );
       this.Controls.Add( this.buttonOK );
       this.Controls.Add( this.labelX1 );
       this.Controls.Add( this.buttonCancel );
       this.Controls.Add( this.buttonClearAll );
       this.Controls.Add( this.buttonSelectAll );
       this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
       this.MaximizeBox = false;
       this.MinimizeBox = false;
       this.MinimumSize = new System.Drawing.Size( 334, 287 );
       this.Name = "Form_SelectSaveResultsAs";
       this.ShowInTaskbar = false;
       this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
       this.Text = "Save Results As CSV File";
       this.ResumeLayout( false );
       this.PerformLayout();

    }

    #endregion

     private DevComponents.DotNetBar.LabelX labelX1;
     private DevComponents.DotNetBar.ButtonX buttonSelectAll;
     private DevComponents.DotNetBar.ButtonX buttonClearAll;
     private System.Windows.Forms.ColumnHeader columnTarget;
     private DevComponents.DotNetBar.ButtonX buttonCancel;
     private DevComponents.DotNetBar.ButtonX buttonOK;
     private System.Windows.Forms.ColumnHeader columnCheck;
     public DevComponents.DotNetBar.Controls.ListViewEx listTargets;
     private System.Windows.Forms.ColumnHeader columnSucceeded;
  }
}