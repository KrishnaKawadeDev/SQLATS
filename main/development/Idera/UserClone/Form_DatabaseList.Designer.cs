namespace Idera.SqlAdminToolset.UserClone
{
   partial class Form_DatabaseList
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
          this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
          this.labelDatabaseNote = new DevComponents.DotNetBar.LabelX();
          this.linkDeselect = new System.Windows.Forms.LinkLabel();
          this.linkSelectAll = new System.Windows.Forms.LinkLabel();
          this.buttonOk = new System.Windows.Forms.Button();
          this.listDatabases = new System.Windows.Forms.CheckedListBox();
          this.lnkRefresh = new System.Windows.Forms.LinkLabel();
          this.groupPanel2.SuspendLayout();
          this.SuspendLayout();
          // 
          // groupPanel2
          // 
          this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
          this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
          this.groupPanel2.Controls.Add(this.lnkRefresh);
          this.groupPanel2.Controls.Add(this.labelDatabaseNote);
          this.groupPanel2.Controls.Add(this.linkDeselect);
          this.groupPanel2.Controls.Add(this.linkSelectAll);
          this.groupPanel2.Controls.Add(this.buttonOk);
          this.groupPanel2.Controls.Add(this.listDatabases);
          this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
          this.groupPanel2.Location = new System.Drawing.Point(0, 0);
          this.groupPanel2.Name = "groupPanel2";
          this.groupPanel2.Size = new System.Drawing.Size(268, 274);
          // 
          // 
          // 
          this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
          this.groupPanel2.Style.BackColorGradientAngle = 90;
          this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
          this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
          this.groupPanel2.Style.BorderBottomWidth = 1;
          this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
          this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
          this.groupPanel2.Style.BorderLeftWidth = 1;
          this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
          this.groupPanel2.Style.BorderRightWidth = 1;
          this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
          this.groupPanel2.Style.BorderTopWidth = 1;
          this.groupPanel2.Style.CornerDiameter = 4;
          this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
          this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
          this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
          this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
          this.groupPanel2.TabIndex = 37;
          // 
          // labelDatabaseNote
          // 
          this.labelDatabaseNote.BackColor = System.Drawing.Color.Transparent;
          this.labelDatabaseNote.Location = new System.Drawing.Point(3, 208);
          this.labelDatabaseNote.Name = "labelDatabaseNote";
          this.labelDatabaseNote.Size = new System.Drawing.Size(256, 33);
          this.labelDatabaseNote.TabIndex = 4;
          this.labelDatabaseNote.Text = "Only databases that the source login has permissions to will be included in the s" +
              "cript";
          this.labelDatabaseNote.WordWrap = true;
          // 
          // linkDeselect
          // 
          this.linkDeselect.AutoSize = true;
          this.linkDeselect.BackColor = System.Drawing.Color.Transparent;
          this.linkDeselect.Location = new System.Drawing.Point(55, 247);
          this.linkDeselect.Name = "linkDeselect";
          this.linkDeselect.Size = new System.Drawing.Size(63, 13);
          this.linkDeselect.TabIndex = 3;
          this.linkDeselect.TabStop = true;
          this.linkDeselect.Text = "Unselect All";
          this.linkDeselect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDeselect_LinkClicked);
          // 
          // linkSelectAll
          // 
          this.linkSelectAll.AutoSize = true;
          this.linkSelectAll.BackColor = System.Drawing.Color.Transparent;
          this.linkSelectAll.Location = new System.Drawing.Point(4, 247);
          this.linkSelectAll.Name = "linkSelectAll";
          this.linkSelectAll.Size = new System.Drawing.Size(51, 13);
          this.linkSelectAll.TabIndex = 2;
          this.linkSelectAll.TabStop = true;
          this.linkSelectAll.Text = "Select All";
          this.linkSelectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelectAll_LinkClicked);
          // 
          // buttonOk
          // 
          this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
          this.buttonOk.Location = new System.Drawing.Point(184, 242);
          this.buttonOk.Name = "buttonOk";
          this.buttonOk.Size = new System.Drawing.Size(75, 23);
          this.buttonOk.TabIndex = 1;
          this.buttonOk.Text = "OK";
          this.buttonOk.UseVisualStyleBackColor = true;
          // 
          // listDatabases
          // 
          this.listDatabases.CheckOnClick = true;
          this.listDatabases.FormattingEnabled = true;
          this.listDatabases.Location = new System.Drawing.Point(3, 6);
          this.listDatabases.Name = "listDatabases";
          this.listDatabases.Size = new System.Drawing.Size(256, 199);
          this.listDatabases.TabIndex = 0;
          // 
          // lnkRefresh
          // 
          this.lnkRefresh.AutoSize = true;
          this.lnkRefresh.BackColor = System.Drawing.Color.Transparent;
          this.lnkRefresh.Location = new System.Drawing.Point(118, 247);
          this.lnkRefresh.Name = "lnkRefresh";
          this.lnkRefresh.Size = new System.Drawing.Size(44, 13);
          this.lnkRefresh.TabIndex = 5;
          this.lnkRefresh.TabStop = true;
          this.lnkRefresh.Text = "Refresh";
          this.lnkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRefresh_LinkClicked);
          // 
          // Form_DatabaseList
          // 
          this.AcceptButton = this.buttonOk;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.White;
          this.ClientSize = new System.Drawing.Size(268, 274);
          this.Controls.Add(this.groupPanel2);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "Form_DatabaseList";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Select Databases";
          this.groupPanel2.ResumeLayout(false);
          this.groupPanel2.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
      private System.Windows.Forms.Button buttonOk;
      private System.Windows.Forms.CheckedListBox listDatabases;
      private System.Windows.Forms.LinkLabel linkDeselect;
      private System.Windows.Forms.LinkLabel linkSelectAll;
       private DevComponents.DotNetBar.LabelX labelDatabaseNote;
       private System.Windows.Forms.LinkLabel lnkRefresh;

   }
}