namespace Idera.SqlAdminToolset.PasswordChecker
{
   partial class Form_RoleSelection
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_RoleSelection ) );
         this.listRoles = new System.Windows.Forms.CheckedListBox();
         this.groupSelection = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.buttonClearAll = new DevComponents.DotNetBar.ButtonX();
         this.buttonSelectAll = new DevComponents.DotNetBar.ButtonX();
         this.labelRoles = new DevComponents.DotNetBar.LabelX();
         this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
         this.buttonOk = new DevComponents.DotNetBar.ButtonX();
         this.groupSelection.SuspendLayout();
         this.SuspendLayout();
         // 
         // listRoles
         // 
         this.listRoles.CheckOnClick = true;
         this.listRoles.FormattingEnabled = true;
         this.listRoles.Location = new System.Drawing.Point( 6, 28 );
         this.listRoles.Name = "listRoles";
         this.listRoles.Size = new System.Drawing.Size( 343, 199 );
         this.listRoles.Sorted = true;
         this.listRoles.TabIndex = 1;
         // 
         // groupSelection
         // 
         this.groupSelection.BackColor = System.Drawing.Color.Transparent;
         this.groupSelection.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupSelection.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupSelection.Controls.Add( this.buttonClearAll );
         this.groupSelection.Controls.Add( this.buttonSelectAll );
         this.groupSelection.Controls.Add( this.labelRoles );
         this.groupSelection.Controls.Add( this.buttonCancel );
         this.groupSelection.Controls.Add( this.buttonOk );
         this.groupSelection.Controls.Add( this.listRoles );
         this.groupSelection.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupSelection.IsShadowEnabled = true;
         this.groupSelection.Location = new System.Drawing.Point( 0, 0 );
         this.groupSelection.Name = "groupSelection";
         this.groupSelection.Size = new System.Drawing.Size( 361, 268 );
         // 
         // 
         // 
         this.groupSelection.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
         this.groupSelection.Style.BackColorGradientAngle = 90;
         this.groupSelection.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
         this.groupSelection.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupSelection.Style.BorderBottomWidth = 1;
         this.groupSelection.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
         this.groupSelection.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupSelection.Style.BorderLeftWidth = 1;
         this.groupSelection.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupSelection.Style.BorderRightWidth = 1;
         this.groupSelection.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupSelection.Style.BorderTopWidth = 1;
         this.groupSelection.Style.CornerDiameter = 4;
         this.groupSelection.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
         this.groupSelection.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
         this.groupSelection.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
         this.groupSelection.TabIndex = 16;
         // 
         // buttonClearAll
         // 
         this.buttonClearAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonClearAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonClearAll.Location = new System.Drawing.Point( 75, 236 );
         this.buttonClearAll.Name = "buttonClearAll";
         this.buttonClearAll.Size = new System.Drawing.Size( 65, 23 );
         this.buttonClearAll.TabIndex = 3;
         this.buttonClearAll.Text = "C&lear All";
         this.buttonClearAll.Click += new System.EventHandler( this.buttonClearAll_Click );
         // 
         // buttonSelectAll
         // 
         this.buttonSelectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonSelectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonSelectAll.Location = new System.Drawing.Point( 6, 236 );
         this.buttonSelectAll.Name = "buttonSelectAll";
         this.buttonSelectAll.Size = new System.Drawing.Size( 65, 23 );
         this.buttonSelectAll.TabIndex = 2;
         this.buttonSelectAll.Text = "Select &All";
         this.buttonSelectAll.Click += new System.EventHandler( this.buttonSelectAll_Click );
         // 
         // labelRoles
         // 
         this.labelRoles.AutoSize = true;
         this.labelRoles.Location = new System.Drawing.Point( 7, 12 );
         this.labelRoles.Name = "labelRoles";
         this.labelRoles.Size = new System.Drawing.Size( 67, 13 );
         this.labelRoles.TabIndex = 0;
         this.labelRoles.Text = "Select Roles:";
         // 
         // buttonCancel
         // 
         this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point( 284, 236 );
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size( 65, 23 );
         this.buttonCancel.TabIndex = 5;
         this.buttonCancel.Text = "&Cancel";
         // 
         // buttonOk
         // 
         this.buttonOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOk.Location = new System.Drawing.Point( 215, 236 );
         this.buttonOk.Name = "buttonOk";
         this.buttonOk.Size = new System.Drawing.Size( 65, 23 );
         this.buttonOk.TabIndex = 4;
         this.buttonOk.Text = "&OK";
         // 
         // Form_RoleSelection
         // 
         this.AcceptButton = this.buttonOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size( 361, 268 );
         this.Controls.Add( this.groupSelection );
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form_RoleSelection";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Role Browser";
         this.groupSelection.ResumeLayout( false );
         this.groupSelection.PerformLayout();
         this.ResumeLayout( false );

      }

      #endregion

      private System.Windows.Forms.CheckedListBox listRoles;
      private DevComponents.DotNetBar.Controls.GroupPanel groupSelection;
      private DevComponents.DotNetBar.ButtonX buttonCancel;
      private DevComponents.DotNetBar.ButtonX buttonOk;
      private DevComponents.DotNetBar.ButtonX buttonClearAll;
      private DevComponents.DotNetBar.ButtonX buttonSelectAll;
      private DevComponents.DotNetBar.LabelX labelRoles;
   }
}