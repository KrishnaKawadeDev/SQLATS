namespace Idera.SqlAdminToolset.Core
{
   partial class Form_SQLServerBrowse
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_SQLServerBrowse ) );
         this.listBoxServers = new System.Windows.Forms.ListBox();
         this.btnCancel = new DevComponents.DotNetBar.ButtonX();
         this.btnOK = new DevComponents.DotNetBar.ButtonX();
         this.labelPrompt = new DevComponents.DotNetBar.LabelX();
         this.labelNoServers = new DevComponents.DotNetBar.LabelX();
         this.SuspendLayout();
         // 
         // listBoxServers
         // 
         this.listBoxServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.listBoxServers.Location = new System.Drawing.Point( 12, 24 );
         this.listBoxServers.Name = "listBoxServers";
         this.listBoxServers.Size = new System.Drawing.Size( 376, 225 );
         this.listBoxServers.Sorted = true;
         this.listBoxServers.TabIndex = 1;
         this.listBoxServers.SelectedIndexChanged += new System.EventHandler( this.listBoxServers_SelectedIndexChanged );
         this.listBoxServers.DoubleClick += new System.EventHandler( this.listBoxServers_DoubleClick );
         // 
         // btnCancel
         // 
         this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point( 397, 53 );
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
         this.btnCancel.TabIndex = 10;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
         // 
         // btnOK
         // 
         this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Enabled = false;
         this.btnOK.Location = new System.Drawing.Point( 397, 24 );
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size( 75, 23 );
         this.btnOK.TabIndex = 9;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler( this.btnOK_Click );
         // 
         // labelPrompt
         // 
         this.labelPrompt.Location = new System.Drawing.Point( 12, 8 );
         this.labelPrompt.Name = "labelPrompt";
         this.labelPrompt.Size = new System.Drawing.Size( 131, 10 );
         this.labelPrompt.TabIndex = 8;
         this.labelPrompt.Text = "Select SQL Server:";
         // 
         // labelNoServers
         // 
         this.labelNoServers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.labelNoServers.BackColor = System.Drawing.Color.White;
         this.labelNoServers.Font = new System.Drawing.Font( "Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
         this.labelNoServers.ForeColor = System.Drawing.Color.Red;
         this.labelNoServers.Location = new System.Drawing.Point( 12, 43 );
         this.labelNoServers.Name = "labelNoServers";
         this.labelNoServers.Size = new System.Drawing.Size( 376, 79 );
         this.labelNoServers.TabIndex = 28;
         this.labelNoServers.Text = "No servers available";
         this.labelNoServers.TextAlignment = System.Drawing.StringAlignment.Center;
         this.labelNoServers.TextLineAlignment = System.Drawing.StringAlignment.Near;
         this.labelNoServers.Visible = false;
         this.labelNoServers.WordWrap = true;
         // 
         // Form_SQLServerBrowse
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size( 479, 264 );
         this.Controls.Add( this.labelNoServers );
         this.Controls.Add( this.btnCancel );
         this.Controls.Add( this.btnOK );
         this.Controls.Add( this.labelPrompt );
         this.Controls.Add( this.listBoxServers );
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size( 312, 296 );
         this.Name = "Form_SQLServerBrowse";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Select SQL Server";
         this.ResumeLayout( false );

      }
      #endregion

      private System.Windows.Forms.ListBox listBoxServers;
      private DevComponents.DotNetBar.ButtonX btnCancel;
      private DevComponents.DotNetBar.ButtonX btnOK;
      private DevComponents.DotNetBar.LabelX labelPrompt;
      private DevComponents.DotNetBar.LabelX labelNoServers;
   }
}