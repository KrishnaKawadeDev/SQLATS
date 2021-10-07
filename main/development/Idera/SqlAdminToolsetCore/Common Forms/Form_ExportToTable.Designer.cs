namespace Idera.SqlAdminToolset.Core
{
   partial class Form_ExportToTable
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ExportToTable));
          this.btnCancel = new DevComponents.DotNetBar.ButtonX();
          this.btnOK = new DevComponents.DotNetBar.ButtonX();
          this.labelServer = new DevComponents.DotNetBar.LabelX();
          this.labelOwner = new DevComponents.DotNetBar.LabelX();
          this.labelTable = new DevComponents.DotNetBar.LabelX();
          this.textServer = new DevComponents.DotNetBar.Controls.TextBoxX();
          this.groupSelectTable = new DevComponents.DotNetBar.Controls.GroupPanel();
          this.buttonCredentials = new DevComponents.DotNetBar.ButtonX();
          this.comboTable = new DevComponents.DotNetBar.Controls.ComboBoxEx();
          this.comboOwner = new DevComponents.DotNetBar.Controls.ComboBoxEx();
          this.comboDatabase = new DevComponents.DotNetBar.Controls.ComboBoxEx();
          this.labelDatabase = new DevComponents.DotNetBar.LabelX();
          this.buttonBrowseServer = new DevComponents.DotNetBar.ButtonX();
          this.groupSelectTable.SuspendLayout();
          this.SuspendLayout();
          // 
          // btnCancel
          // 
          this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
          this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
          this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.btnCancel.Location = new System.Drawing.Point(371, 177);
          this.btnCancel.Name = "btnCancel";
          this.btnCancel.Size = new System.Drawing.Size(75, 23);
          this.btnCancel.TabIndex = 12;
          this.btnCancel.Text = "&Cancel";
          // 
          // btnOK
          // 
          this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
          this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
          this.btnOK.Enabled = false;
          this.btnOK.Location = new System.Drawing.Point(290, 177);
          this.btnOK.Name = "btnOK";
          this.btnOK.Size = new System.Drawing.Size(75, 23);
          this.btnOK.TabIndex = 11;
          this.btnOK.Text = "&OK";
          this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
          // 
          // labelServer
          // 
          this.labelServer.BackColor = System.Drawing.Color.Transparent;
          this.labelServer.Location = new System.Drawing.Point(9, 11);
          this.labelServer.Name = "labelServer";
          this.labelServer.Size = new System.Drawing.Size(70, 20);
          this.labelServer.TabIndex = 1;
          this.labelServer.Text = "&SQL Server:";
          // 
          // labelOwner
          // 
          this.labelOwner.BackColor = System.Drawing.Color.Transparent;
          this.labelOwner.Location = new System.Drawing.Point(9, 72);
          this.labelOwner.Name = "labelOwner";
          this.labelOwner.Size = new System.Drawing.Size(70, 20);
          this.labelOwner.TabIndex = 7;
          this.labelOwner.Text = "&Owner:";
          // 
          // labelTable
          // 
          this.labelTable.BackColor = System.Drawing.Color.Transparent;
          this.labelTable.Location = new System.Drawing.Point(9, 102);
          this.labelTable.Name = "labelTable";
          this.labelTable.Size = new System.Drawing.Size(70, 20);
          this.labelTable.TabIndex = 9;
          this.labelTable.Text = "&Table:";
          // 
          // textServer
          // 
          // 
          // 
          // 
          this.textServer.Border.Class = "TextBoxBorder";
          this.textServer.Location = new System.Drawing.Point(85, 11);
          this.textServer.Name = "textServer";
          this.textServer.Size = new System.Drawing.Size(291, 20);
          this.textServer.TabIndex = 2;
          this.textServer.Text = "(local)";
          this.textServer.Leave += new System.EventHandler(this.textServer_Leave);
          this.textServer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textServer_KeyPress);
          this.textServer.TextChanged += new System.EventHandler(this.textServer_TextChanged);
          // 
          // groupSelectTable
          // 
          this.groupSelectTable.CanvasColor = System.Drawing.SystemColors.Control;
          this.groupSelectTable.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
          this.groupSelectTable.Controls.Add(this.buttonCredentials);
          this.groupSelectTable.Controls.Add(this.comboTable);
          this.groupSelectTable.Controls.Add(this.comboOwner);
          this.groupSelectTable.Controls.Add(this.comboDatabase);
          this.groupSelectTable.Controls.Add(this.labelDatabase);
          this.groupSelectTable.Controls.Add(this.buttonBrowseServer);
          this.groupSelectTable.Controls.Add(this.textServer);
          this.groupSelectTable.Controls.Add(this.labelServer);
          this.groupSelectTable.Controls.Add(this.labelOwner);
          this.groupSelectTable.Controls.Add(this.labelTable);
          this.groupSelectTable.IsShadowEnabled = true;
          this.groupSelectTable.Location = new System.Drawing.Point(6, 5);
          this.groupSelectTable.Name = "groupSelectTable";
          this.groupSelectTable.Size = new System.Drawing.Size(440, 166);
          // 
          // 
          // 
          this.groupSelectTable.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
          this.groupSelectTable.Style.BackColorGradientAngle = 90;
          this.groupSelectTable.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
          this.groupSelectTable.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
          this.groupSelectTable.Style.BorderBottomWidth = 1;
          this.groupSelectTable.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
          this.groupSelectTable.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
          this.groupSelectTable.Style.BorderLeftWidth = 1;
          this.groupSelectTable.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
          this.groupSelectTable.Style.BorderRightWidth = 1;
          this.groupSelectTable.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
          this.groupSelectTable.Style.BorderTopWidth = 1;
          this.groupSelectTable.Style.CornerDiameter = 4;
          this.groupSelectTable.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
          this.groupSelectTable.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
          this.groupSelectTable.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
          this.groupSelectTable.TabIndex = 0;
          this.groupSelectTable.Text = "Specify Destination Table";
          // 
          // buttonCredentials
          // 
          this.buttonCredentials.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
          this.buttonCredentials.BackColor = System.Drawing.Color.White;
          this.buttonCredentials.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
          this.buttonCredentials.Image = ((System.Drawing.Image)(resources.GetObject("buttonCredentials.Image")));
          this.buttonCredentials.Location = new System.Drawing.Point(408, 11);
          this.buttonCredentials.Name = "buttonCredentials";
          this.buttonCredentials.Size = new System.Drawing.Size(20, 20);
          this.buttonCredentials.TabIndex = 4;
          this.buttonCredentials.Click += new System.EventHandler(this.buttonCredentials_Click);
          // 
          // comboTable
          // 
          this.comboTable.DisplayMember = "Text";
          this.comboTable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
          this.comboTable.FormattingEnabled = true;
          this.comboTable.ItemHeight = 14;
          this.comboTable.Location = new System.Drawing.Point(85, 102);
          this.comboTable.Name = "comboTable";
          this.comboTable.Size = new System.Drawing.Size(291, 20);
          this.comboTable.TabIndex = 10;
          this.comboTable.SelectedIndexChanged += new System.EventHandler(this.comboTable_SelectedIndexChanged);
          this.comboTable.Enter += new System.EventHandler(this.comboDatabase_Enter);
          // 
          // comboOwner
          // 
          this.comboOwner.DisplayMember = "Text";
          this.comboOwner.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
          this.comboOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.comboOwner.FormattingEnabled = true;
          this.comboOwner.ItemHeight = 14;
          this.comboOwner.Location = new System.Drawing.Point(85, 72);
          this.comboOwner.Name = "comboOwner";
          this.comboOwner.Size = new System.Drawing.Size(291, 20);
          this.comboOwner.TabIndex = 8;
          this.comboOwner.SelectedIndexChanged += new System.EventHandler(this.comboOwner_SelectedIndexChanged);
          this.comboOwner.Enter += new System.EventHandler(this.comboDatabase_Enter);
          // 
          // comboDatabase
          // 
          this.comboDatabase.DisplayMember = "Text";
          this.comboDatabase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
          this.comboDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.comboDatabase.FormattingEnabled = true;
          this.comboDatabase.ItemHeight = 14;
          this.comboDatabase.Location = new System.Drawing.Point(85, 41);
          this.comboDatabase.Name = "comboDatabase";
          this.comboDatabase.Size = new System.Drawing.Size(291, 20);
          this.comboDatabase.TabIndex = 6;
          this.comboDatabase.SelectedIndexChanged += new System.EventHandler(this.comboDatabase_SelectedIndexChanged);
          this.comboDatabase.Enter += new System.EventHandler(this.comboDatabase_Enter);
          // 
          // labelDatabase
          // 
          this.labelDatabase.BackColor = System.Drawing.Color.Transparent;
          this.labelDatabase.Location = new System.Drawing.Point(9, 41);
          this.labelDatabase.Name = "labelDatabase";
          this.labelDatabase.Size = new System.Drawing.Size(70, 20);
          this.labelDatabase.TabIndex = 5;
          this.labelDatabase.Text = "&Database:";
          // 
          // buttonBrowseServer
          // 
          this.buttonBrowseServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
          this.buttonBrowseServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
          this.buttonBrowseServer.Location = new System.Drawing.Point(382, 11);
          this.buttonBrowseServer.Name = "buttonBrowseServer";
          this.buttonBrowseServer.Size = new System.Drawing.Size(20, 20);
          this.buttonBrowseServer.TabIndex = 3;
          this.buttonBrowseServer.Text = "...";
          this.buttonBrowseServer.Click += new System.EventHandler(this.buttonBrowseServer_Click);
          // 
          // Form_ExportToTable
          // 
          this.AcceptButton = this.btnOK;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.White;
          this.CancelButton = this.btnCancel;
          this.ClientSize = new System.Drawing.Size(451, 205);
          this.Controls.Add(this.groupSelectTable);
          this.Controls.Add(this.btnCancel);
          this.Controls.Add(this.btnOK);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "Form_ExportToTable";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Export To Table";
          this.groupSelectTable.ResumeLayout(false);
          this.ResumeLayout(false);

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX btnCancel;
      private DevComponents.DotNetBar.ButtonX btnOK;
      private DevComponents.DotNetBar.LabelX labelServer;
      private DevComponents.DotNetBar.LabelX labelOwner;
      private DevComponents.DotNetBar.LabelX labelTable;
      private DevComponents.DotNetBar.Controls.TextBoxX textServer;
      private DevComponents.DotNetBar.Controls.GroupPanel groupSelectTable;
      private DevComponents.DotNetBar.LabelX labelDatabase;
      private DevComponents.DotNetBar.ButtonX buttonBrowseServer;
      private DevComponents.DotNetBar.Controls.ComboBoxEx comboTable;
      private DevComponents.DotNetBar.Controls.ComboBoxEx comboOwner;
      private DevComponents.DotNetBar.Controls.ComboBoxEx comboDatabase;
      private DevComponents.DotNetBar.ButtonX buttonCredentials;
   }
}