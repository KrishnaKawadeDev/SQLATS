namespace Idera.SqlAdminToolset.Core
{
   partial class Form_DatabaseBrowse
	{
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (components != null)
            {
               components.Dispose();
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DatabaseBrowse));
            this.listBoxDatabases = new System.Windows.Forms.ListBox();
            this.labelPrompt = new DevComponents.DotNetBar.LabelX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.labelNoDatabases = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // listBoxDatabases
            // 
            this.listBoxDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxDatabases.Location = new System.Drawing.Point(12, 24);
            this.listBoxDatabases.Name = "listBoxDatabases";
            this.listBoxDatabases.Size = new System.Drawing.Size(203, 225);
            this.listBoxDatabases.Sorted = true;
            this.listBoxDatabases.TabIndex = 1;
            this.listBoxDatabases.SelectedIndexChanged += new System.EventHandler(this.listBoxDatabases_SelectedIndexChanged);
            this.listBoxDatabases.DoubleClick += new System.EventHandler(this.listBoxDatabases_DoubleClick);
            // 
            // labelPrompt
            // 
            // 
            // 
            // 
            this.labelPrompt.BackgroundStyle.Class = "";
            this.labelPrompt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelPrompt.Location = new System.Drawing.Point(12, 9);
            this.labelPrompt.Name = "labelPrompt";
            this.labelPrompt.Size = new System.Drawing.Size(131, 10);
            this.labelPrompt.TabIndex = 4;
            this.labelPrompt.Text = "Select Database from {0}:";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(224, 24);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(224, 53);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelNoDatabases
            // 
            this.labelNoDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNoDatabases.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelNoDatabases.BackgroundStyle.Class = "";
            this.labelNoDatabases.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelNoDatabases.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoDatabases.ForeColor = System.Drawing.Color.Red;
            this.labelNoDatabases.Location = new System.Drawing.Point(12, 41);
            this.labelNoDatabases.Name = "labelNoDatabases";
            this.labelNoDatabases.Size = new System.Drawing.Size(203, 79);
            this.labelNoDatabases.TabIndex = 29;
            this.labelNoDatabases.Text = "No databases available";
            this.labelNoDatabases.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelNoDatabases.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.labelNoDatabases.Visible = false;
            this.labelNoDatabases.WordWrap = true;
            // 
            // Form_DatabaseBrowse
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(306, 268);
            this.Controls.Add(this.labelNoDatabases);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelPrompt);
            this.Controls.Add(this.listBoxDatabases);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(314, 302);
            this.Name = "Form_DatabaseBrowse";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Database";
            this.ResumeLayout(false);

      }
      #endregion

      private System.Windows.Forms.ListBox listBoxDatabases;
      private DevComponents.DotNetBar.LabelX labelPrompt;
      private DevComponents.DotNetBar.ButtonX btnOK;
      private DevComponents.DotNetBar.ButtonX btnCancel;
      private DevComponents.DotNetBar.LabelX labelNoDatabases;
   }
}