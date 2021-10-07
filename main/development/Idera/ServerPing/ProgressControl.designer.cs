namespace Idera.SqlAdminToolset.ServerPing
{
   partial class ProgressControl
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.labelOperationText = new DevComponents.DotNetBar.LabelX();
         this.progressBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
         this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
         this.buttonMinimize = new DevComponents.DotNetBar.ButtonX();
         this.SuspendLayout();
         // 
         // labelOperationText
         // 
         this.labelOperationText.Font = new System.Drawing.Font( "Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
         this.labelOperationText.Location = new System.Drawing.Point( 10, 48 );
         this.labelOperationText.Name = "labelOperationText";
         this.labelOperationText.Size = new System.Drawing.Size( 375, 21 );
         this.labelOperationText.TabIndex = 1;
         this.labelOperationText.Text = "Description of Operation";
         this.labelOperationText.TextAlignment = System.Drawing.StringAlignment.Center;
         // 
         // progressBar
         // 
         this.progressBar.Location = new System.Drawing.Point( 10, 23 );
         this.progressBar.Name = "progressBar";
         this.progressBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
         this.progressBar.Size = new System.Drawing.Size( 375, 24 );
         this.progressBar.TabIndex = 2;
         this.progressBar.Text = "progressBarX1";
         // 
         // buttonCancel
         // 
         this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonCancel.Location = new System.Drawing.Point( 115, 85 );
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size( 75, 21 );
         this.buttonCancel.TabIndex = 0;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.Click += new System.EventHandler( this.buttonCancel_Click );
         // 
         // buttonMinimize
         // 
         this.buttonMinimize.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonMinimize.Location = new System.Drawing.Point( 200, 85 );
         this.buttonMinimize.Name = "buttonMinimize";
         this.buttonMinimize.Size = new System.Drawing.Size( 75, 21 );
         this.buttonMinimize.TabIndex = 3;
         this.buttonMinimize.Text = "Minimize";
         this.buttonMinimize.Click += new System.EventHandler( this.buttonMinimize_Click );
         // 
         // ProgressControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.Transparent;
         this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.Controls.Add( this.buttonMinimize );
         this.Controls.Add( this.buttonCancel );
         this.Controls.Add( this.labelOperationText );
         this.Controls.Add( this.progressBar );
         this.MaximumSize = new System.Drawing.Size( 394, 116 );
         this.MinimumSize = new System.Drawing.Size( 394, 92 );
         this.Name = "ProgressControl";
         this.Size = new System.Drawing.Size( 390, 112 );
         this.ResumeLayout( false );

      }

      #endregion

      private DevComponents.DotNetBar.LabelX labelOperationText;
      private DevComponents.DotNetBar.Controls.ProgressBarX progressBar;
      public DevComponents.DotNetBar.ButtonX buttonCancel;
      public DevComponents.DotNetBar.ButtonX buttonMinimize;

   }
}
