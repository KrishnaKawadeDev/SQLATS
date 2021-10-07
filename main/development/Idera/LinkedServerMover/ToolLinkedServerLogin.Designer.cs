namespace Idera.SqlAdminToolset.LinkedServerMover
{
   partial class ToolLinkedServerLogin
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.labelUsername = new DevComponents.DotNetBar.LabelX();
         this.textBoxPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.SuspendLayout();
         // 
         // labelUsername
         // 
         // 
         // 
         // 
         this.labelUsername.BackgroundStyle.Class = "";
         this.labelUsername.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
         this.labelUsername.Location = new System.Drawing.Point(3, 1);
         this.labelUsername.Name = "labelUsername";
         this.labelUsername.Size = new System.Drawing.Size(151, 23);
         this.labelUsername.TabIndex = 1;
         // 
         // textBoxPassword
         // 
         // 
         // 
         // 
         this.textBoxPassword.Border.Class = "TextBoxBorder";
         this.textBoxPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
         this.textBoxPassword.Location = new System.Drawing.Point(173, 4);
         this.textBoxPassword.Name = "textBoxPassword";
         this.textBoxPassword.PasswordChar = '*';
         this.textBoxPassword.Size = new System.Drawing.Size(139, 20);
         this.textBoxPassword.TabIndex = 2;
         // 
         // ToolLinkedServerLogin
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.Transparent;
         this.Controls.Add(this.textBoxPassword);
         this.Controls.Add(this.labelUsername);
         this.Name = "ToolLinkedServerLogin";
         this.Size = new System.Drawing.Size(315, 29);
         this.ResumeLayout(false);

      }

      #endregion

      private DevComponents.DotNetBar.LabelX labelUsername;
      private DevComponents.DotNetBar.Controls.TextBoxX textBoxPassword;
   }
}
