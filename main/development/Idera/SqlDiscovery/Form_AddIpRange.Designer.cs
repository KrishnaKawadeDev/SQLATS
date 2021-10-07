namespace Idera.SqlAdminToolset.SqlDiscovery
{
   partial class Form_AddIpRange
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_AddIpRange ) );
         this.btnCancel = new DevComponents.DotNetBar.ButtonX();
         this.btnOK = new DevComponents.DotNetBar.ButtonX();
         this.textStartIp = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.labelStartIp = new DevComponents.DotNetBar.LabelX();
         this.labelEndIp = new DevComponents.DotNetBar.LabelX();
         this.textEndIp = new DevComponents.DotNetBar.Controls.TextBoxX();
         this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
         this.labelX1 = new DevComponents.DotNetBar.LabelX();
         this.buttonGetLocalIP = new DevComponents.DotNetBar.ButtonX();
         this.buttonGetLocalSubnet = new DevComponents.DotNetBar.ButtonX();
         this.groupPanel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnCancel
         // 
         this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point( 431, 98 );
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size( 75, 20 );
         this.btnCancel.TabIndex = 9;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.Click += new System.EventHandler( this.btnCancel_Click );
         // 
         // btnOK
         // 
         this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Enabled = false;
         this.btnOK.Location = new System.Drawing.Point( 350, 98 );
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size( 75, 20 );
         this.btnOK.TabIndex = 8;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler( this.btnOK_Click );
         // 
         // textStartIp
         // 
         // 
         // 
         // 
         this.textStartIp.Border.Class = "TextBoxBorder";
         this.textStartIp.Location = new System.Drawing.Point( 68, 10 );
         this.textStartIp.MaxLength = 15;
         this.textStartIp.Name = "textStartIp";
         this.textStartIp.Size = new System.Drawing.Size( 97, 20 );
         this.textStartIp.TabIndex = 2;
         this.textStartIp.TextChanged += new System.EventHandler( this.textIp_TextChanged );
         // 
         // labelStartIp
         // 
         this.labelStartIp.AutoSize = true;
         this.labelStartIp.BackColor = System.Drawing.Color.Transparent;
         this.labelStartIp.Location = new System.Drawing.Point( 11, 11 );
         this.labelStartIp.Name = "labelStartIp";
         this.labelStartIp.Size = new System.Drawing.Size( 51, 15 );
         this.labelStartIp.TabIndex = 1;
         this.labelStartIp.Text = "&IP Range:";
         // 
         // labelEndIp
         // 
         this.labelEndIp.AutoSize = true;
         this.labelEndIp.BackColor = System.Drawing.Color.Transparent;
         this.labelEndIp.Location = new System.Drawing.Point( 170, 12 );
         this.labelEndIp.Name = "labelEndIp";
         this.labelEndIp.Size = new System.Drawing.Size( 12, 15 );
         this.labelEndIp.TabIndex = 3;
         this.labelEndIp.Text = "to";
         // 
         // textEndIp
         // 
         // 
         // 
         // 
         this.textEndIp.Border.Class = "TextBoxBorder";
         this.textEndIp.Location = new System.Drawing.Point( 183, 11 );
         this.textEndIp.MaxLength = 15;
         this.textEndIp.Name = "textEndIp";
         this.textEndIp.Size = new System.Drawing.Size( 93, 20 );
         this.textEndIp.TabIndex = 4;
         this.textEndIp.TextChanged += new System.EventHandler( this.textIp_TextChanged );
         // 
         // groupPanel2
         // 
         this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
         this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         this.groupPanel2.Controls.Add( this.buttonGetLocalSubnet );
         this.groupPanel2.Controls.Add( this.buttonGetLocalIP );
         this.groupPanel2.Controls.Add( this.labelX1 );
         this.groupPanel2.Controls.Add( this.labelStartIp );
         this.groupPanel2.Controls.Add( this.textEndIp );
         this.groupPanel2.Controls.Add( this.labelEndIp );
         this.groupPanel2.Controls.Add( this.textStartIp );
         this.groupPanel2.IsShadowEnabled = true;
         this.groupPanel2.Location = new System.Drawing.Point( 8, 8 );
         this.groupPanel2.Name = "groupPanel2";
         this.groupPanel2.Size = new System.Drawing.Size( 498, 82 );
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
         this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
         this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
         this.groupPanel2.TabIndex = 0;
         this.groupPanel2.Text = "Specify IP Range";
         // 
         // labelX1
         // 
         this.labelX1.BackColor = System.Drawing.Color.Transparent;
         this.labelX1.Location = new System.Drawing.Point( 68, 41 );
         this.labelX1.Name = "labelX1";
         this.labelX1.Size = new System.Drawing.Size( 389, 16 );
         this.labelX1.TabIndex = 5;
         this.labelX1.Text = "Note: Leave the ending IP address blank to specify a single IP address.";
         this.labelX1.WordWrap = true;
         // 
         // buttonGetLocalIP
         // 
         this.buttonGetLocalIP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonGetLocalIP.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonGetLocalIP.Location = new System.Drawing.Point( 296, 12 );
         this.buttonGetLocalIP.Name = "buttonGetLocalIP";
         this.buttonGetLocalIP.Size = new System.Drawing.Size( 82, 20 );
         this.buttonGetLocalIP.TabIndex = 46;
         this.buttonGetLocalIP.Text = "Get Local IP";
         this.buttonGetLocalIP.Click += new System.EventHandler( this.buttonGetLocalIP_Click );
         // 
         // buttonGetLocalSubnet
         // 
         this.buttonGetLocalSubnet.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonGetLocalSubnet.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonGetLocalSubnet.Location = new System.Drawing.Point( 384, 12 );
         this.buttonGetLocalSubnet.Name = "buttonGetLocalSubnet";
         this.buttonGetLocalSubnet.Size = new System.Drawing.Size( 98, 20 );
         this.buttonGetLocalSubnet.TabIndex = 47;
         this.buttonGetLocalSubnet.Text = "Get Local Subnet";
         this.buttonGetLocalSubnet.Click += new System.EventHandler( this.buttonGetLocalSubnet_Click );
         // 
         // Form_AddIpRange
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size( 513, 124 );
         this.Controls.Add( this.groupPanel2 );
         this.Controls.Add( this.btnCancel );
         this.Controls.Add( this.btnOK );
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form_AddIpRange";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Add IP Range";
         this.groupPanel2.ResumeLayout( false );
         this.groupPanel2.PerformLayout();
         this.ResumeLayout( false );

      }

      #endregion

      private DevComponents.DotNetBar.ButtonX btnCancel;
      private DevComponents.DotNetBar.ButtonX btnOK;
      private DevComponents.DotNetBar.Controls.TextBoxX textStartIp;
      private DevComponents.DotNetBar.LabelX labelStartIp;
      private DevComponents.DotNetBar.LabelX labelEndIp;
      private DevComponents.DotNetBar.Controls.TextBoxX textEndIp;
      private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
      private DevComponents.DotNetBar.LabelX labelX1;
      private DevComponents.DotNetBar.ButtonX buttonGetLocalSubnet;
      private DevComponents.DotNetBar.ButtonX buttonGetLocalIP;
   }
}