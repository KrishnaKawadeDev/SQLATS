namespace Idera.SqlAdminToolset.PasswordChecker
{
   partial class Form_PasswordList
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_PasswordList ) );
         this.labelX1 = new DevComponents.DotNetBar.LabelX();
         this.textPasswordList = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.listPasswords = new DevComponents.DotNetBar.Controls.ListViewEx();
         this.buttonClose = new DevComponents.DotNetBar.ButtonX();
         this.labelPasswordCount = new DevComponents.DotNetBar.LabelX();
         this.columnPassword = new System.Windows.Forms.ColumnHeader();
         this.SuspendLayout();
         // 
         // labelX1
         // 
         this.labelX1.AutoSize = true;
         this.labelX1.Location = new System.Drawing.Point( 13, 14 );
         this.labelX1.Name = "labelX1";
         this.labelX1.Size = new System.Drawing.Size( 74, 13 );
         this.labelX1.TabIndex = 0;
         this.labelX1.Text = "Password List:";
         // 
         // textPasswordList
         // 
         this.textPasswordList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         // 
         // 
         // 
         this.textPasswordList.Border.Class = "TextBoxBorder";
         this.textPasswordList.Location = new System.Drawing.Point( 93, 12 );
         this.textPasswordList.Name = "textPasswordList";
         this.textPasswordList.ReadOnly = true;
         this.textPasswordList.Size = new System.Drawing.Size( 286, 20 );
         this.textPasswordList.TabIndex = 1;
         // 
         // listPasswords
         // 
         this.listPasswords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         // 
         // 
         // 
         this.listPasswords.Border.Class = "ListViewBorder";
         this.listPasswords.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnPassword} );
         this.listPasswords.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
         this.listPasswords.Location = new System.Drawing.Point( 13, 41 );
         this.listPasswords.Name = "listPasswords";
         this.listPasswords.Size = new System.Drawing.Size( 366, 458 );
         this.listPasswords.TabIndex = 2;
         this.listPasswords.UseCompatibleStateImageBehavior = false;
         this.listPasswords.View = System.Windows.Forms.View.Details;
         // 
         // buttonClose
         // 
         this.buttonClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonClose.Location = new System.Drawing.Point( 312, 507 );
         this.buttonClose.Name = "buttonClose";
         this.buttonClose.Size = new System.Drawing.Size( 66, 20 );
         this.buttonClose.TabIndex = 3;
         this.buttonClose.Text = "&Close";
         // 
         // labelPasswordCount
         // 
         this.labelPasswordCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.labelPasswordCount.AutoSize = true;
         this.labelPasswordCount.Location = new System.Drawing.Point( 13, 510 );
         this.labelPasswordCount.Name = "labelPasswordCount";
         this.labelPasswordCount.Size = new System.Drawing.Size( 74, 13 );
         this.labelPasswordCount.TabIndex = 4;
         this.labelPasswordCount.Text = "Password List:";
         // 
         // columnPassword
         // 
         this.columnPassword.Text = "Password";
         this.columnPassword.Width = 346;
         // 
         // Form_PasswordList
         // 
         this.AcceptButton = this.buttonClose;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.buttonClose;
         this.ClientSize = new System.Drawing.Size( 390, 534 );
         this.Controls.Add( this.labelPasswordCount );
         this.Controls.Add( this.buttonClose );
         this.Controls.Add( this.listPasswords );
         this.Controls.Add( this.textPasswordList );
         this.Controls.Add( this.labelX1 );
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.Name = "Form_PasswordList";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "View Password List";
         this.ResumeLayout( false );
         this.PerformLayout();

      }

      #endregion

      private DevComponents.DotNetBar.LabelX labelX1;
      private DevComponents.DotNetBar.Controls.TextBoxX textPasswordList;
      private DevComponents.DotNetBar.Controls.ListViewEx listPasswords;
      private DevComponents.DotNetBar.ButtonX buttonClose;
      private DevComponents.DotNetBar.LabelX labelPasswordCount;
      private System.Windows.Forms.ColumnHeader columnPassword;
   }
}