using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Core.LicenseViews
{
    partial class ManageLicensePanel
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLicenseType = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.KeyColumn = new System.Windows.Forms.TableLayoutPanel();
            this.lblLicenseKey = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLicenseStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LimitCodeColumn = new System.Windows.Forms.TableLayoutPanel();
            this.lblLimitCode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.copyToClipboard = new System.Windows.Forms.Button();
            this.registerBtn = new System.Windows.Forms.Button();
            this.extendBtn = new System.Windows.Forms.Button();
            this.deactivateBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.contactUsBox = new System.Windows.Forms.GroupBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.KeyColumn.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.LimitCodeColumn.SuspendLayout();
            this.contactUsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage License Key";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.copyToClipboard);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(661, 97);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Key Information";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.KeyColumn);
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel4);
            this.flowLayoutPanel1.Controls.Add(this.LimitCodeColumn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(572, 69);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblLicenseType, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(104, 64);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblLicenseType
            // 
            this.lblLicenseType.AutoSize = true;
            this.lblLicenseType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLicenseType.Location = new System.Drawing.Point(4, 32);
            this.lblLicenseType.Name = "lblLicenseType";
            this.lblLicenseType.Size = new System.Drawing.Size(96, 31);
            this.lblLicenseType.TabIndex = 5;
            this.lblLicenseType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(1, 1);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 30);
            this.label6.TabIndex = 2;
            this.label6.Text = "Type";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KeyColumn
            // 
            this.KeyColumn.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.KeyColumn.ColumnCount = 1;
            this.KeyColumn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.KeyColumn.Controls.Add(this.lblLicenseKey, 0, 1);
            this.KeyColumn.Controls.Add(this.label7, 0, 0);
            this.KeyColumn.Location = new System.Drawing.Point(104, 0);
            this.KeyColumn.Margin = new System.Windows.Forms.Padding(0);
            this.KeyColumn.Name = "KeyColumn";
            this.KeyColumn.RowCount = 2;
            this.KeyColumn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.KeyColumn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.KeyColumn.Size = new System.Drawing.Size(233, 64);
            this.KeyColumn.TabIndex = 1;
            // 
            // lblLicenseKey
            // 
            this.lblLicenseKey.AutoSize = true;
            this.lblLicenseKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLicenseKey.Location = new System.Drawing.Point(4, 32);
            this.lblLicenseKey.Name = "lblLicenseKey";
            this.lblLicenseKey.Size = new System.Drawing.Size(225, 31);
            this.lblLicenseKey.TabIndex = 6;
            this.lblLicenseKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(1, 1);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(231, 30);
            this.label7.TabIndex = 3;
            this.label7.Text = "Key";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lblLicenseStatus, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(337, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(118, 64);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // lblLicenseStatus
            // 
            this.lblLicenseStatus.AutoSize = true;
            this.lblLicenseStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLicenseStatus.Location = new System.Drawing.Point(4, 32);
            this.lblLicenseStatus.Name = "lblLicenseStatus";
            this.lblLicenseStatus.Size = new System.Drawing.Size(110, 31);
            this.lblLicenseStatus.TabIndex = 7;
            this.lblLicenseStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Silver;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(1, 1);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 30);
            this.label9.TabIndex = 4;
            this.label9.Text = "Status";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LimitCodeColumn
            // 
            this.LimitCodeColumn.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.LimitCodeColumn.ColumnCount = 1;
            this.LimitCodeColumn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LimitCodeColumn.Controls.Add(this.lblLimitCode, 0, 1);
            this.LimitCodeColumn.Controls.Add(this.label5, 0, 0);
            this.LimitCodeColumn.Location = new System.Drawing.Point(455, 0);
            this.LimitCodeColumn.Margin = new System.Windows.Forms.Padding(0);
            this.LimitCodeColumn.Name = "LimitCodeColumn";
            this.LimitCodeColumn.RowCount = 2;
            this.LimitCodeColumn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LimitCodeColumn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LimitCodeColumn.Size = new System.Drawing.Size(105, 64);
            this.LimitCodeColumn.TabIndex = 3;
            // 
            // lblLimitCode
            // 
            this.lblLimitCode.AutoSize = true;
            this.lblLimitCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLimitCode.Location = new System.Drawing.Point(1, 32);
            this.lblLimitCode.Margin = new System.Windows.Forms.Padding(0);
            this.lblLimitCode.Name = "lblLimitCode";
            this.lblLimitCode.Size = new System.Drawing.Size(103, 31);
            this.lblLimitCode.TabIndex = 8;
            this.lblLimitCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(1, 1);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "Limit Code";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // copyToClipboard
            // 
            this.copyToClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.copyToClipboard.Location = new System.Drawing.Point(584, 35);
            this.copyToClipboard.Name = "copyToClipboard";
            this.copyToClipboard.Size = new System.Drawing.Size(71, 32);
            this.copyToClipboard.TabIndex = 1;
            this.copyToClipboard.Text = "Copy";
            this.copyToClipboard.UseVisualStyleBackColor = true;
            this.copyToClipboard.Click += new System.EventHandler(this.button1_Click);
            // 
            // registerBtn
            // 
            this.registerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.registerBtn.Location = new System.Drawing.Point(18, 174);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(109, 32);
            this.registerBtn.TabIndex = 4;
            this.registerBtn.Text = "Register";
            this.toolTip1.SetToolTip(this.registerBtn, "Register a Key");
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Visible = false;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // extendBtn
            // 
            this.extendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.extendBtn.Location = new System.Drawing.Point(18, 212);
            this.extendBtn.Name = "extendBtn";
            this.extendBtn.Size = new System.Drawing.Size(109, 32);
            this.extendBtn.TabIndex = 5;
            this.extendBtn.Text = "Extend";
            this.toolTip1.SetToolTip(this.extendBtn, "Extend Trial");
            this.extendBtn.UseVisualStyleBackColor = true;
            this.extendBtn.Visible = false;
            this.extendBtn.Click += new System.EventHandler(this.extendBtn_Click);
            // 
            // deactivateBtn
            // 
            this.deactivateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.deactivateBtn.Location = new System.Drawing.Point(18, 212);
            this.deactivateBtn.Name = "deactivateBtn";
            this.deactivateBtn.Size = new System.Drawing.Size(109, 32);
            this.deactivateBtn.TabIndex = 6;
            this.deactivateBtn.Text = "Deactivate";
            this.toolTip1.SetToolTip(this.deactivateBtn, "Deactivate Key on current machine");
            this.deactivateBtn.UseVisualStyleBackColor = true;
            this.deactivateBtn.Visible = false;
            this.deactivateBtn.Click += new System.EventHandler(this.deactivateBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.closeBtn.Location = new System.Drawing.Point(287, 358);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(109, 32);
            this.closeBtn.TabIndex = 7;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.linkLabel1.Location = new System.Drawing.Point(439, 180);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(135, 20);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Purchase License";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_Click);
            // 
            // contactUsBox
            // 
            this.contactUsBox.Controls.Add(this.linkLabel3);
            this.contactUsBox.Controls.Add(this.label4);
            this.contactUsBox.Controls.Add(this.linkLabel2);
            this.contactUsBox.Controls.Add(this.label3);
            this.contactUsBox.Controls.Add(this.label2);
            this.contactUsBox.Location = new System.Drawing.Point(434, 199);
            this.contactUsBox.Name = "contactUsBox";
            this.contactUsBox.Size = new System.Drawing.Size(239, 91);
            this.contactUsBox.TabIndex = 9;
            this.contactUsBox.TabStop = false;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.linkLabel3.Location = new System.Drawing.Point(119, 66);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(105, 13);
            this.linkLabel3.TabIndex = 4;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "licensing@idera.com";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(7, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "License Key Requests:";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.linkLabel2.Location = new System.Drawing.Point(49, 42);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(99, 13);
            this.linkLabel2.TabIndex = 2;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "support@idera.com";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(7, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Support:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Contact Us:";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(127, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "Type";
            // 
            // ManageLicensePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contactUsBox);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.deactivateBtn);
            this.Controls.Add(this.extendBtn);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ManageLicensePanel";
            this.VisibleChanged += new System.EventHandler(this.ManageLicensePanel_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.KeyColumn.ResumeLayout(false);
            this.KeyColumn.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.LimitCodeColumn.ResumeLayout(false);
            this.LimitCodeColumn.PerformLayout();
            this.contactUsBox.ResumeLayout(false);
            this.contactUsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button copyToClipboard;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button extendBtn;
        private System.Windows.Forms.Button deactivateBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox contactUsBox;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;

        
        private System.Windows.Forms.Label label11;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblLicenseType;
        private Label label6;
        private TableLayoutPanel KeyColumn;
        private Label lblLicenseKey;
        private Label label7;
        private TableLayoutPanel tableLayoutPanel4;
        private Label lblLicenseStatus;
        private Label label9;
        private TableLayoutPanel LimitCodeColumn;
        private Label lblLimitCode;
        private Label label5;
    }
}