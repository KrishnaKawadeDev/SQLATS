namespace Idera.SqlAdminToolset.SqlDiscovery
{
   partial class Form_AddLoadIP
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose( bool disposing )
      {
         if ( disposing && (components != null) )
         {
            components.Dispose();
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_AddLoadIP ) );
         this.buttonBrowseIPList = new DevComponents.DotNetBar.ButtonX();
         this.txtIPListFileName = new System.Windows.Forms.TextBox();
         this.labelX1 = new DevComponents.DotNetBar.LabelX();
         this.btnCancel = new DevComponents.DotNetBar.ButtonX();
         this.btnOK = new DevComponents.DotNetBar.ButtonX();
         this.SuspendLayout();
         // 
         // buttonBrowseIPList
         // 
         this.buttonBrowseIPList.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonBrowseIPList.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonBrowseIPList.Location = new System.Drawing.Point( 521, 12 );
         this.buttonBrowseIPList.Name = "buttonBrowseIPList";
         this.buttonBrowseIPList.Size = new System.Drawing.Size( 18, 20 );
         this.buttonBrowseIPList.TabIndex = 42;
         this.buttonBrowseIPList.Text = "...";
         this.buttonBrowseIPList.Click += new System.EventHandler( this.buttonBrowseIPList_Click );
         // 
         // txtIPListFileName
         // 
         this.txtIPListFileName.Location = new System.Drawing.Point( 65, 12 );
         this.txtIPListFileName.Name = "txtIPListFileName";
         this.txtIPListFileName.Size = new System.Drawing.Size( 450, 20 );
         this.txtIPListFileName.TabIndex = 41;
         this.txtIPListFileName.TextChanged += new System.EventHandler( this.txtIPListFileName_TextChanged );
         // 
         // labelX1
         // 
         this.labelX1.AutoSize = true;
         this.labelX1.Location = new System.Drawing.Point( 9, 14 );
         this.labelX1.Name = "labelX1";
         this.labelX1.Size = new System.Drawing.Size( 50, 15 );
         this.labelX1.TabIndex = 43;
         this.labelX1.Text = "IP list file:";
         // 
         // btnCancel
         // 
         this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point( 464, 56 );
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
         this.btnCancel.TabIndex = 45;
         this.btnCancel.Text = "&Cancel";
         // 
         // btnOK
         // 
         this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Enabled = false;
         this.btnOK.Location = new System.Drawing.Point( 383, 56 );
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size( 75, 23 );
         this.btnOK.TabIndex = 44;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler( this.btnOK_Click );
         // 
         // Form_AddLoadIP
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size( 546, 86 );
         this.Controls.Add( this.btnCancel );
         this.Controls.Add( this.btnOK );
         this.Controls.Add( this.labelX1 );
         this.Controls.Add( this.buttonBrowseIPList );
         this.Controls.Add( this.txtIPListFileName );
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form_AddLoadIP";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Load IP List from File";
         this.ResumeLayout( false );
         this.PerformLayout();

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX buttonBrowseIPList;
      private System.Windows.Forms.TextBox txtIPListFileName;
      private DevComponents.DotNetBar.LabelX labelX1;
      private DevComponents.DotNetBar.ButtonX btnCancel;
      private DevComponents.DotNetBar.ButtonX btnOK;
   }
}