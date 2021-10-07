namespace Idera.SqlAdminToolset.Core.Controls
{
   partial class ToolServerSelectionNoMru
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolServerSelectionNoMru));
          this.labelServer = new DevComponents.DotNetBar.LabelX();
          this.radioGroups = new DevComponents.DotNetBar.Controls.CheckBoxX();
          this.radioServers = new DevComponents.DotNetBar.Controls.CheckBoxX();
          this.buttonCredentials = new DevComponents.DotNetBar.ButtonX();
          this.textServer = new DevComponents.DotNetBar.Controls.TextBoxX();
          this.buttonBrowse = new DevComponents.DotNetBar.ButtonX();
          this.SuspendLayout();
          // 
          // labelServer
          // 
          this.labelServer.AutoSize = true;
          this.labelServer.BackColor = System.Drawing.Color.Transparent;
          this.labelServer.Location = new System.Drawing.Point(5, 2);
          this.labelServer.Name = "labelServer";
          this.labelServer.Size = new System.Drawing.Size(76, 15);
          this.labelServer.TabIndex = 0;
          this.labelServer.Text = "SQL Server(s):";
          this.labelServer.Resize += new System.EventHandler(this.labelServer_Resize);
          // 
          // radioGroups
          // 
          this.radioGroups.BackColor = System.Drawing.Color.Transparent;
          this.radioGroups.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
          this.radioGroups.Location = new System.Drawing.Point(204, 22);
          this.radioGroups.Name = "radioGroups";
          this.radioGroups.Size = new System.Drawing.Size(96, 21);
          this.radioGroups.TabIndex = 5;
          this.radioGroups.Text = "Server Group";
          this.radioGroups.CheckedChanged += new System.EventHandler(this.radioGroups_CheckedChanged);
          // 
          // radioServers
          // 
          this.radioServers.BackColor = System.Drawing.Color.Transparent;
          this.radioServers.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
          this.radioServers.Checked = true;
          this.radioServers.CheckState = System.Windows.Forms.CheckState.Checked;
          this.radioServers.CheckValue = "Y";
          this.radioServers.Location = new System.Drawing.Point(105, 22);
          this.radioServers.Name = "radioServers";
          this.radioServers.Size = new System.Drawing.Size(95, 21);
          this.radioServers.TabIndex = 4;
          this.radioServers.Text = "SQL Servers";
          this.radioServers.CheckedChanged += new System.EventHandler(this.radioServers_CheckedChanged);
          // 
          // buttonCredentials
          // 
          this.buttonCredentials.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
          this.buttonCredentials.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
          this.buttonCredentials.BackColor = System.Drawing.Color.White;
          this.buttonCredentials.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
          this.buttonCredentials.Image = ((System.Drawing.Image)(resources.GetObject("buttonCredentials.Image")));
          this.buttonCredentials.ImageFixedSize = new System.Drawing.Size(16, 16);
          this.buttonCredentials.Location = new System.Drawing.Point(446, 0);
          this.buttonCredentials.Name = "buttonCredentials";
          this.buttonCredentials.Size = new System.Drawing.Size(20, 20);
          this.buttonCredentials.TabIndex = 3;
          this.buttonCredentials.Tooltip = "Set the credentials used to connect to the specified SQL Server(s).";
          this.buttonCredentials.Click += new System.EventHandler(this.buttonCredentials_Click);
          // 
          // textServer
          // 
          this.textServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          // 
          // 
          // 
          this.textServer.Border.Class = "TextBoxBorder";
          this.textServer.Location = new System.Drawing.Point(87, 0);
          this.textServer.Name = "textServer";
          this.textServer.Size = new System.Drawing.Size(326, 20);
          this.textServer.TabIndex = 1;
          this.textServer.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty;
          this.textServer.WatermarkText = "Enter one or more SQL Servers separated by semi-colons";
          // 
          // buttonBrowse
          // 
          this.buttonBrowse.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
          this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
          this.buttonBrowse.BackColor = System.Drawing.Color.White;
          this.buttonBrowse.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
          this.buttonBrowse.Location = new System.Drawing.Point(420, 0);
          this.buttonBrowse.Name = "buttonBrowse";
          this.buttonBrowse.Size = new System.Drawing.Size(20, 20);
          this.buttonBrowse.TabIndex = 2;
          this.buttonBrowse.Text = "...";
          this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
          // 
          // ToolServerSelectionNoMru
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.Transparent;
          this.Controls.Add(this.buttonBrowse);
          this.Controls.Add(this.textServer);
          this.Controls.Add(this.labelServer);
          this.Controls.Add(this.radioGroups);
          this.Controls.Add(this.radioServers);
          this.Controls.Add(this.buttonCredentials);
          this.Name = "ToolServerSelectionNoMru";
          this.Size = new System.Drawing.Size(471, 40);
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private DevComponents.DotNetBar.LabelX labelServer;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioGroups;
      private DevComponents.DotNetBar.Controls.CheckBoxX radioServers;
      private DevComponents.DotNetBar.ButtonX buttonCredentials;
      private DevComponents.DotNetBar.Controls.TextBoxX textServer;
      private DevComponents.DotNetBar.ButtonX buttonBrowse;
   }
}
