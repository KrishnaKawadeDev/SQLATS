using System;

namespace Idera.SqlAdminToolset.Core
{
  partial class Form_AddLicense
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
       System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_AddLicense ) );
       this.labelLicenseKey = new DevComponents.DotNetBar.LabelX();
       this.textBox_NewKey = new DevComponents.DotNetBar.Controls.TextBoxX();
       this.buttonOK = new System.Windows.Forms.Button();
       this.buttonCancel = new System.Windows.Forms.Button();
       this.SuspendLayout();
       // 
       // labelLicenseKey
       // 
       this.labelLicenseKey.BackColor = System.Drawing.Color.Transparent;
       this.labelLicenseKey.Location = new System.Drawing.Point( 13, 20 );
       this.labelLicenseKey.Name = "labelLicenseKey";
       this.labelLicenseKey.Size = new System.Drawing.Size( 71, 15 );
       this.labelLicenseKey.TabIndex = 9;
       this.labelLicenseKey.Text = "License Key:";
       // 
       // textBox_NewKey
       // 
       // 
       // 
       // 
       this.textBox_NewKey.Border.Class = "TextBoxBorder";
       this.textBox_NewKey.Location = new System.Drawing.Point( 90, 19 );
       this.textBox_NewKey.Name = "textBox_NewKey";
       this.textBox_NewKey.Size = new System.Drawing.Size( 389, 20 );
       this.textBox_NewKey.TabIndex = 10;
       this.textBox_NewKey.TextChanged += new System.EventHandler( this.textBox_NewKey_TextChanged );
       // 
       // buttonOK
       // 
       this.buttonOK.Enabled = false;
       this.buttonOK.Location = new System.Drawing.Point( 325, 54 );
       this.buttonOK.Name = "buttonOK";
       this.buttonOK.Size = new System.Drawing.Size( 75, 23 );
       this.buttonOK.TabIndex = 11;
       this.buttonOK.Text = "&OK";
       this.buttonOK.UseVisualStyleBackColor = true;
       this.buttonOK.Click += new System.EventHandler( this.button_OK_Click );
       // 
       // buttonCancel
       // 
       this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
       this.buttonCancel.Location = new System.Drawing.Point( 406, 54 );
       this.buttonCancel.Name = "buttonCancel";
       this.buttonCancel.Size = new System.Drawing.Size( 75, 23 );
       this.buttonCancel.TabIndex = 12;
       this.buttonCancel.Text = "&Cancel";
       this.buttonCancel.UseVisualStyleBackColor = true;
       this.buttonCancel.Click += new System.EventHandler( this.button_Cancel_Click );
       // 
       // Form_AddLicense
       // 
       this.AcceptButton = this.buttonOK;
       this.BackColor = System.Drawing.Color.White;
       this.CancelButton = this.buttonCancel;
       this.CausesValidation = false;
       this.ClientSize = new System.Drawing.Size( 492, 84 );
       this.Controls.Add( this.buttonCancel );
       this.Controls.Add( this.buttonOK );
       this.Controls.Add( this.textBox_NewKey );
       this.Controls.Add( this.labelLicenseKey );
       this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
       this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
       this.MaximizeBox = false;
       this.MinimizeBox = false;
       this.Name = "Form_AddLicense";
       this.ShowInTaskbar = false;
       this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
       this.Text = "Register New License Key";
       this.ResumeLayout( false );

    }

    #endregion

    private DevComponents.DotNetBar.LabelX labelLicenseKey;
     private DevComponents.DotNetBar.Controls.TextBoxX textBox_NewKey;
     private System.Windows.Forms.Button buttonOK;
     private System.Windows.Forms.Button buttonCancel;
  }
}