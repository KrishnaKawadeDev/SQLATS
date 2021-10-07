using System;

namespace Idera.SqlAdminToolset.Core
{
  partial class Form_ManageLicense
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
        System.Windows.Forms.Label label2;
        System.Windows.Forms.Label label5;
        System.Windows.Forms.Label label6;
        System.Windows.Forms.Label label1;
        System.Windows.Forms.PictureBox pictureBox1;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ManageLicense));
        System.Windows.Forms.Label labelLicenseKey;
        this.groupPanel1 = new System.Windows.Forms.GroupBox();
        this.textLicenseKey = new System.Windows.Forms.TextBox();
        this.groupPanel2 = new System.Windows.Forms.GroupBox();
        this.textBox_LicenseType = new System.Windows.Forms.TextBox();
        this.textBox_DaysToExpire = new System.Windows.Forms.TextBox();
        this.textBox_LicenseExpiration = new System.Windows.Forms.TextBox();
        this.button_Add = new System.Windows.Forms.Button();
        this.columnHeader_Key1 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_Servers = new System.Windows.Forms.ColumnHeader();
        this.columnHeader_DaystoExpiration = new System.Windows.Forms.ColumnHeader();
        this.button_OK = new System.Windows.Forms.Button();
        this.pictureStatus = new System.Windows.Forms.PictureBox();
        this.imageListStatus = new System.Windows.Forms.ImageList(this.components);
        this.labelStatus = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        label1 = new System.Windows.Forms.Label();
        pictureBox1 = new System.Windows.Forms.PictureBox();
        labelLicenseKey = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
        this.groupPanel1.SuspendLayout();
        this.groupPanel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureStatus)).BeginInit();
        this.SuspendLayout();
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new System.Drawing.Point(6, 18);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(34, 13);
        label2.TabIndex = 2;
        label2.Text = "Type:";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new System.Drawing.Point(6, 44);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(61, 13);
        label5.TabIndex = 4;
        label5.Text = "Expires On:";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new System.Drawing.Point(6, 70);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(95, 13);
        label6.TabIndex = 6;
        label6.Text = "Days to Expiration:";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.BackColor = System.Drawing.Color.Transparent;
        label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        label1.Location = new System.Drawing.Point(66, 21);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(297, 20);
        label1.TabIndex = 0;
        label1.Text = "SQL admin toolset License Management";
        // 
        // pictureBox1
        // 
        pictureBox1.BackColor = System.Drawing.Color.Transparent;
        pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
        pictureBox1.Location = new System.Drawing.Point(12, 7);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(48, 48);
        pictureBox1.TabIndex = 7;
        pictureBox1.TabStop = false;
        // 
        // labelLicenseKey
        // 
        labelLicenseKey.AutoSize = true;
        labelLicenseKey.Location = new System.Drawing.Point(9, 21);
        labelLicenseKey.Name = "labelLicenseKey";
        labelLicenseKey.Size = new System.Drawing.Size(68, 13);
        labelLicenseKey.TabIndex = 0;
        labelLicenseKey.Text = "License Key:";
        // 
        // groupPanel1
        // 
        this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
        this.groupPanel1.Controls.Add(this.textLicenseKey);
        this.groupPanel1.Controls.Add(labelLicenseKey);
        this.groupPanel1.Controls.Add(this.groupPanel2);
        this.groupPanel1.Controls.Add(this.button_Add);
        this.groupPanel1.Location = new System.Drawing.Point(12, 63);
        this.groupPanel1.Name = "groupPanel1";
        this.groupPanel1.Size = new System.Drawing.Size(477, 153);
        this.groupPanel1.TabIndex = 1;
        this.groupPanel1.TabStop = false;
        this.groupPanel1.Text = "License Information";
        // 
        // textLicenseKey
        // 
        this.textLicenseKey.BackColor = System.Drawing.SystemColors.ControlLight;
        this.textLicenseKey.Location = new System.Drawing.Point(83, 18);
        this.textLicenseKey.Name = "textLicenseKey";
        this.textLicenseKey.ReadOnly = true;
        this.textLicenseKey.Size = new System.Drawing.Size(254, 20);
        this.textLicenseKey.TabIndex = 1;
        this.textLicenseKey.Text = "AUSSL-BVHQF-3HJTL-HKBFE-YVCMKN";
        // 
        // groupPanel2
        // 
        this.groupPanel2.Controls.Add(this.textBox_LicenseType);
        this.groupPanel2.Controls.Add(label2);
        this.groupPanel2.Controls.Add(this.textBox_DaysToExpire);
        this.groupPanel2.Controls.Add(label5);
        this.groupPanel2.Controls.Add(label6);
        this.groupPanel2.Controls.Add(this.textBox_LicenseExpiration);
        this.groupPanel2.Location = new System.Drawing.Point(83, 44);
        this.groupPanel2.Name = "groupPanel2";
        this.groupPanel2.Size = new System.Drawing.Size(382, 97);
        this.groupPanel2.TabIndex = 1;
        this.groupPanel2.TabStop = false;
        this.groupPanel2.Text = "License Details";
        // 
        // textBox_LicenseType
        // 
        this.textBox_LicenseType.BackColor = System.Drawing.SystemColors.ControlLight;
        this.textBox_LicenseType.Location = new System.Drawing.Point(103, 15);
        this.textBox_LicenseType.Name = "textBox_LicenseType";
        this.textBox_LicenseType.ReadOnly = true;
        this.textBox_LicenseType.Size = new System.Drawing.Size(273, 20);
        this.textBox_LicenseType.TabIndex = 3;
        // 
        // textBox_DaysToExpire
        // 
        this.textBox_DaysToExpire.BackColor = System.Drawing.SystemColors.ControlLight;
        this.textBox_DaysToExpire.Location = new System.Drawing.Point(103, 67);
        this.textBox_DaysToExpire.Name = "textBox_DaysToExpire";
        this.textBox_DaysToExpire.ReadOnly = true;
        this.textBox_DaysToExpire.Size = new System.Drawing.Size(273, 20);
        this.textBox_DaysToExpire.TabIndex = 5;
        // 
        // textBox_LicenseExpiration
        // 
        this.textBox_LicenseExpiration.BackColor = System.Drawing.SystemColors.ControlLight;
        this.textBox_LicenseExpiration.Location = new System.Drawing.Point(103, 41);
        this.textBox_LicenseExpiration.Name = "textBox_LicenseExpiration";
        this.textBox_LicenseExpiration.ReadOnly = true;
        this.textBox_LicenseExpiration.Size = new System.Drawing.Size(273, 20);
        this.textBox_LicenseExpiration.TabIndex = 4;
        // 
        // button_Add
        // 
        this.button_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.button_Add.BackColor = System.Drawing.Color.White;
        this.button_Add.Location = new System.Drawing.Point(343, 16);
        this.button_Add.Name = "button_Add";
        this.button_Add.Size = new System.Drawing.Size(122, 23);
        this.button_Add.TabIndex = 2;
        this.button_Add.Text = "&Register New License";
        this.button_Add.UseVisualStyleBackColor = false;
        this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
        // 
        // columnHeader_Key1
        // 
        this.columnHeader_Key1.Text = "License String";
        this.columnHeader_Key1.Width = 225;
        // 
        // columnHeader_Servers
        // 
        this.columnHeader_Servers.Text = "Servers";
        this.columnHeader_Servers.Width = 111;
        // 
        // columnHeader_DaystoExpiration
        // 
        this.columnHeader_DaystoExpiration.Text = "Days to Expiration";
        this.columnHeader_DaystoExpiration.Width = 127;
        // 
        // button_OK
        // 
        this.button_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.button_OK.Location = new System.Drawing.Point(414, 221);
        this.button_OK.Name = "button_OK";
        this.button_OK.Size = new System.Drawing.Size(75, 23);
        this.button_OK.TabIndex = 0;
        this.button_OK.Text = "&Close";
        this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
        // 
        // pictureStatus
        // 
        this.pictureStatus.Image = ((System.Drawing.Image)(resources.GetObject("pictureStatus.Image")));
        this.pictureStatus.Location = new System.Drawing.Point(12, 224);
        this.pictureStatus.Name = "pictureStatus";
        this.pictureStatus.Size = new System.Drawing.Size(16, 16);
        this.pictureStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureStatus.TabIndex = 8;
        this.pictureStatus.TabStop = false;
        this.pictureStatus.Visible = false;
        // 
        // imageListStatus
        // 
        this.imageListStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListStatus.ImageStream")));
        this.imageListStatus.TransparentColor = System.Drawing.Color.Transparent;
        this.imageListStatus.Images.SetKeyName(0, "warning.png");
        this.imageListStatus.Images.SetKeyName(1, "error.png");
        // 
        // labelStatus
        // 
        this.labelStatus.AutoSize = true;
        this.labelStatus.Location = new System.Drawing.Point(30, 225);
        this.labelStatus.Name = "labelStatus";
        this.labelStatus.Size = new System.Drawing.Size(263, 13);
        this.labelStatus.TabIndex = 9;
        this.labelStatus.Text = "The license period granted by this key will expire soon.";
        this.labelStatus.Visible = false;
        // 
        // Form_ManageLicense
        // 
        this.AcceptButton = this.button_OK;
        this.BackColor = System.Drawing.Color.White;
        this.CancelButton = this.button_OK;
        this.CausesValidation = false;
        this.ClientSize = new System.Drawing.Size(501, 248);
        this.Controls.Add(this.labelStatus);
        this.Controls.Add(this.pictureStatus);
        this.Controls.Add(pictureBox1);
        this.Controls.Add(label1);
        this.Controls.Add(this.groupPanel1);
        this.Controls.Add(this.button_OK);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "Form_ManageLicense";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Manage License";
        this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Form_ManageLicense_HelpRequested);
        ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
        this.groupPanel1.ResumeLayout(false);
        this.groupPanel1.PerformLayout();
        this.groupPanel2.ResumeLayout(false);
        this.groupPanel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureStatus)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox groupPanel1;
    private System.Windows.Forms.TextBox textBox_LicenseType;
    private System.Windows.Forms.TextBox textBox_DaysToExpire;
     private System.Windows.Forms.TextBox textBox_LicenseExpiration;
      protected System.Windows.Forms.Button button_Add;
    private System.Windows.Forms.ColumnHeader columnHeader_Servers;
    private System.Windows.Forms.ColumnHeader columnHeader_DaystoExpiration;
    private System.Windows.Forms.GroupBox groupPanel2;
    private System.Windows.Forms.ColumnHeader columnHeader_Key1;
      private System.Windows.Forms.TextBox textLicenseKey;
      protected System.Windows.Forms.Button button_OK;
      private System.Windows.Forms.PictureBox pictureStatus;
     private System.Windows.Forms.ImageList imageListStatus;
     private System.Windows.Forms.Label labelStatus;
     
  }
}