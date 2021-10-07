namespace Idera.SqlAdminToolset.Core.Controls
{
   partial class ToolProgressEx
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
          this.labelX_ProgressText = new DevComponents.DotNetBar.LabelX();
          this.SuspendLayout();
          // 
          // labelOperationText
          // 
          this.labelOperationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.labelOperationText.Location = new System.Drawing.Point(10, 48);
          this.labelOperationText.Name = "labelOperationText";
          this.labelOperationText.Size = new System.Drawing.Size(397, 21);
          this.labelOperationText.TabIndex = 1;
          this.labelOperationText.Text = "Description of Operation";
          this.labelOperationText.TextAlignment = System.Drawing.StringAlignment.Center;
          // 
          // progressBar
          // 
          this.progressBar.Location = new System.Drawing.Point(21, 18);
          this.progressBar.Name = "progressBar";
          this.progressBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
          this.progressBar.Size = new System.Drawing.Size(382, 24);
          this.progressBar.TabIndex = 2;
          this.progressBar.Text = "progressBarX1";
          // 
          // buttonCancel
          // 
          this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
          this.buttonCancel.Location = new System.Drawing.Point(175, 102);
          this.buttonCancel.Name = "buttonCancel";
          this.buttonCancel.Size = new System.Drawing.Size(75, 21);
          this.buttonCancel.TabIndex = 0;
          this.buttonCancel.Text = "Cancel";
          this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
          // 
          // labelX_ProgressText
          // 
          this.labelX_ProgressText.Location = new System.Drawing.Point(10, 74);
          this.labelX_ProgressText.Name = "labelX_ProgressText";
          this.labelX_ProgressText.Size = new System.Drawing.Size(397, 23);
          this.labelX_ProgressText.TabIndex = 3;
          this.labelX_ProgressText.Text = "Progress Text";
          this.labelX_ProgressText.TextAlignment = System.Drawing.StringAlignment.Center;
          // 
          // ToolProgressEx
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.Transparent;
          this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.Controls.Add(this.labelX_ProgressText);
          this.Controls.Add(this.buttonCancel);
          this.Controls.Add(this.labelOperationText);
          this.Controls.Add(this.progressBar);
          this.MaximumSize = new System.Drawing.Size(424, 136);
          this.MinimumSize = new System.Drawing.Size(424, 136);
          this.Name = "ToolProgressEx";
          this.Size = new System.Drawing.Size(424, 136);
          this.ResumeLayout(false);

      }

      #endregion

      private DevComponents.DotNetBar.LabelX labelOperationText;
      private DevComponents.DotNetBar.Controls.ProgressBarX progressBar;
      public DevComponents.DotNetBar.ButtonX buttonCancel;
       private DevComponents.DotNetBar.LabelX labelX_ProgressText;

   }
}
