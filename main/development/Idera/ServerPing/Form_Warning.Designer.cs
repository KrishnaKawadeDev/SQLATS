namespace Idera.SqlAdminToolset.ServerPing
{
   partial class Form_Warning
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_Warning ) );
         this.btnOK = new DevComponents.DotNetBar.ButtonX();
         this.checkDoNotShowAgain = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.labelMessage = new DevComponents.DotNetBar.LabelX();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // btnOK
         // 
         this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point( 227, 94 );
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size( 143, 23 );
         this.btnOK.TabIndex = 2;
         this.btnOK.Text = "&Yes, Run in System Tray";
         // 
         // checkDoNotShowAgain
         // 
         this.checkDoNotShowAgain.Location = new System.Drawing.Point( 12, 96 );
         this.checkDoNotShowAgain.Name = "checkDoNotShowAgain";
         this.checkDoNotShowAgain.Size = new System.Drawing.Size( 183, 16 );
         this.checkDoNotShowAgain.TabIndex = 1;
         this.checkDoNotShowAgain.Text = "Do not show this message again";
         // 
         // labelMessage
         // 
         this.labelMessage.BackColor = System.Drawing.Color.White;
         this.labelMessage.Location = new System.Drawing.Point( 55, 8 );
         this.labelMessage.Name = "labelMessage";
         this.labelMessage.Size = new System.Drawing.Size( 443, 56 );
         this.labelMessage.TabIndex = 0;
         this.labelMessage.Text = resources.GetString( "labelMessage.Text" );
         this.labelMessage.TextLineAlignment = System.Drawing.StringAlignment.Near;
         this.labelMessage.WordWrap = true;
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject( "pictureBox1.Image" )));
         this.pictureBox1.Location = new System.Drawing.Point( 12, 7 );
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size( 32, 32 );
         this.pictureBox1.TabIndex = 9;
         this.pictureBox1.TabStop = false;
         // 
         // buttonCancel
         // 
         this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point( 375, 94 );
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size( 123, 23 );
         this.buttonCancel.TabIndex = 10;
         this.buttonCancel.Text = "&No, Exit Program";
         // 
         // Form_Warning
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.btnOK;
         this.ClientSize = new System.Drawing.Size( 503, 124 );
         this.Controls.Add( this.buttonCancel );
         this.Controls.Add( this.pictureBox1 );
         this.Controls.Add( this.labelMessage );
         this.Controls.Add( this.checkDoNotShowAgain );
         this.Controls.Add( this.btnOK );
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form_Warning";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Warning Dialog";
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout( false );

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX btnOK;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkDoNotShowAgain;
      private DevComponents.DotNetBar.LabelX labelMessage;
      private System.Windows.Forms.PictureBox pictureBox1;
      private DevComponents.DotNetBar.ButtonX buttonCancel;
   }
}