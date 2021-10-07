namespace Idera.SqlAdminToolset.Core
{
   partial class Form_ServerGroupBrowse
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_ServerGroupBrowse ) );
         this.btnCancel = new DevComponents.DotNetBar.ButtonX();
         this.btnOK = new DevComponents.DotNetBar.ButtonX();
         this.labelPrompt = new DevComponents.DotNetBar.LabelX();
         this.treeServerGroups = new System.Windows.Forms.TreeView();
         this.imageList = new System.Windows.Forms.ImageList( this.components );
         this.checkBoxShowGroupMembers = new DevComponents.DotNetBar.Controls.CheckBoxX();
         this.labelNoServerGroups = new DevComponents.DotNetBar.LabelX();
         this.linkCheckVersionList = new System.Windows.Forms.LinkLabel();
         this.SuspendLayout();
         // 
         // btnCancel
         // 
         this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point( 443, 54 );
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
         this.btnCancel.TabIndex = 4;
         this.btnCancel.Text = "&Cancel";
         // 
         // btnOK
         // 
         this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Enabled = false;
         this.btnOK.Location = new System.Drawing.Point( 443, 25 );
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size( 75, 23 );
         this.btnOK.TabIndex = 3;
         this.btnOK.Text = "&OK";
         // 
         // labelPrompt
         // 
         this.labelPrompt.AutoSize = true;
         this.labelPrompt.Location = new System.Drawing.Point( 12, 9 );
         this.labelPrompt.Name = "labelPrompt";
         this.labelPrompt.Size = new System.Drawing.Size( 114, 15 );
         this.labelPrompt.TabIndex = 0;
         this.labelPrompt.Text = "Select a Server Group:";
         // 
         // treeServerGroups
         // 
         this.treeServerGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.treeServerGroups.HideSelection = false;
         this.treeServerGroups.ImageIndex = 0;
         this.treeServerGroups.ImageList = this.imageList;
         this.treeServerGroups.Location = new System.Drawing.Point( 12, 25 );
         this.treeServerGroups.Name = "treeServerGroups";
         this.treeServerGroups.SelectedImageIndex = 0;
         this.treeServerGroups.Size = new System.Drawing.Size( 423, 370 );
         this.treeServerGroups.TabIndex = 1;
         this.treeServerGroups.DoubleClick += new System.EventHandler( this.treeServerGroups_DoubleClick );
         this.treeServerGroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.treeServerGroups_AfterSelect );
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject( "imageList.ImageStream" )));
         this.imageList.TransparentColor = System.Drawing.Color.Black;
         this.imageList.Images.SetKeyName( 0, "ServerGroups_16.png" );
         this.imageList.Images.SetKeyName( 1, "server.png" );
         // 
         // checkBoxShowGroupMembers
         // 
         this.checkBoxShowGroupMembers.AutoSize = true;
         this.checkBoxShowGroupMembers.Checked = true;
         this.checkBoxShowGroupMembers.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBoxShowGroupMembers.CheckValue = "Y";
         this.checkBoxShowGroupMembers.Location = new System.Drawing.Point( 268, 403 );
         this.checkBoxShowGroupMembers.Name = "checkBoxShowGroupMembers";
         this.checkBoxShowGroupMembers.Size = new System.Drawing.Size( 167, 15 );
         this.checkBoxShowGroupMembers.TabIndex = 2;
         this.checkBoxShowGroupMembers.Text = "Show Server Group Members";
         this.checkBoxShowGroupMembers.CheckedChanged += new System.EventHandler( this.checkBoxShowGroupMembers_CheckedChanged );
         // 
         // labelNoServerGroups
         // 
         this.labelNoServerGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.labelNoServerGroups.BackColor = System.Drawing.Color.White;
         this.labelNoServerGroups.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
         this.labelNoServerGroups.ForeColor = System.Drawing.SystemColors.ControlText;
         this.labelNoServerGroups.Location = new System.Drawing.Point( 29, 33 );
         this.labelNoServerGroups.Name = "labelNoServerGroups";
         this.labelNoServerGroups.Size = new System.Drawing.Size( 390, 79 );
         this.labelNoServerGroups.TabIndex = 29;
         this.labelNoServerGroups.Text = "No server groups defined";
         this.labelNoServerGroups.TextAlignment = System.Drawing.StringAlignment.Center;
         this.labelNoServerGroups.TextLineAlignment = System.Drawing.StringAlignment.Near;
         this.labelNoServerGroups.Visible = false;
         this.labelNoServerGroups.WordWrap = true;
         // 
         // linkCheckVersionList
         // 
         this.linkCheckVersionList.AutoSize = true;
         this.linkCheckVersionList.Location = new System.Drawing.Point( 9, 403 );
         this.linkCheckVersionList.Name = "linkCheckVersionList";
         this.linkCheckVersionList.Size = new System.Drawing.Size( 117, 13 );
         this.linkCheckVersionList.TabIndex = 31;
         this.linkCheckVersionList.TabStop = true;
         this.linkCheckVersionList.Text = "Manage Server Groups";
         this.linkCheckVersionList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         this.linkCheckVersionList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.linkCheckVersionList_LinkClicked );
         // 
         // Form_ServerGroupBrowse
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size( 525, 425 );
         this.Controls.Add( this.linkCheckVersionList );
         this.Controls.Add( this.labelNoServerGroups );
         this.Controls.Add( this.checkBoxShowGroupMembers );
         this.Controls.Add( this.treeServerGroups );
         this.Controls.Add( this.btnCancel );
         this.Controls.Add( this.btnOK );
         this.Controls.Add( this.labelPrompt );
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form_ServerGroupBrowse";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Select Server Group";
         this.ResumeLayout( false );
         this.PerformLayout();

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX btnCancel;
      private DevComponents.DotNetBar.ButtonX btnOK;
      private DevComponents.DotNetBar.LabelX labelPrompt;
      private System.Windows.Forms.TreeView treeServerGroups;
      private System.Windows.Forms.ImageList imageList;
      private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxShowGroupMembers;
      private DevComponents.DotNetBar.LabelX labelNoServerGroups;
      private System.Windows.Forms.LinkLabel linkCheckVersionList;
   }
}