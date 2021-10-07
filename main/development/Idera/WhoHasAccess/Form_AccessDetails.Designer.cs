namespace Idera.SqlAdminToolset.WhoHasAccess
{
   partial class Form_AccessDetails
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
         System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Server Information", System.Windows.Forms.HorizontalAlignment.Left);
         System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Standard Options", System.Windows.Forms.HorizontalAlignment.Left);
         System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Advanced Options", System.Windows.Forms.HorizontalAlignment.Left);
         System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Security Options", System.Windows.Forms.HorizontalAlignment.Left);
         this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.buttonOK = new DevComponents.DotNetBar.ButtonX();
         this.listDetails = new DevComponents.DotNetBar.Controls.ListViewEx();
         this.columnMembers = new System.Windows.Forms.ColumnHeader();
         this.groupPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupPanel1
         // 
         this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel1.Controls.Add(this.buttonOK);
         this.groupPanel1.Controls.Add(this.listDetails);
         this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupPanel1.Location = new System.Drawing.Point(0, 0);
         this.groupPanel1.Name = "groupPanel1";
         this.groupPanel1.Size = new System.Drawing.Size(457, 352);
         // 
         // 
         // 
         this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
         this.groupPanel1.Style.BackColorGradientAngle = 90;
         this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
         this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanel1.Style.BorderBottomWidth = 1;
         this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
         this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanel1.Style.BorderLeftWidth = 1;
         this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanel1.Style.BorderRightWidth = 1;
         this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         this.groupPanel1.Style.BorderTopWidth = 1;
         this.groupPanel1.Style.CornerDiameter = 4;
         this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
         this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
         this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
         this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
         this.groupPanel1.TabIndex = 0;
         // 
         // buttonOK
         // 
         this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonOK.Location = new System.Drawing.Point(367, 320);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 14;
         this.buttonOK.Text = "&OK";
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // listDetails
         // 
         this.listDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         // 
         // 
         // 
         this.listDetails.Border.Class = "ListViewBorder";
         this.listDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnMembers});
         this.listDetails.FullRowSelect = true;
         listViewGroup1.Header = "Server Information";
         listViewGroup1.Name = "groupServerInformation";
         listViewGroup2.Header = "Standard Options";
         listViewGroup2.Name = "groupStandard";
         listViewGroup3.Header = "Advanced Options";
         listViewGroup3.Name = "groupAdvanced";
         listViewGroup4.Header = "Security Options";
         listViewGroup4.Name = "groupSecurity";
         this.listDetails.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
         this.listDetails.Location = new System.Drawing.Point(0, 0);
         this.listDetails.MultiSelect = false;
         this.listDetails.Name = "listDetails";
         this.listDetails.Size = new System.Drawing.Size(451, 314);
         this.listDetails.TabIndex = 13;
         this.listDetails.UseCompatibleStateImageBehavior = false;
         this.listDetails.View = System.Windows.Forms.View.Details;
         // 
         // columnMembers
         // 
         this.columnMembers.Text = "Access";
         this.columnMembers.Width = 425;
         // 
         // Form_AccessDetails
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.buttonOK;
         this.ClientSize = new System.Drawing.Size(457, 352);
         this.Controls.Add(this.groupPanel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "Form_AccessDetails";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Access Details";
         this.groupPanel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
      private DevComponents.DotNetBar.Controls.ListViewEx listDetails;
      private DevComponents.DotNetBar.ButtonX buttonOK;
      private System.Windows.Forms.ColumnHeader columnMembers;
   }
}