namespace Idera.SqlAdminToolset.Core
{
    partial class Form_MiniBrowser
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_MiniBrowser ) );
           this.webBrowser1 = new System.Windows.Forms.WebBrowser();
           this.buttonClose = new System.Windows.Forms.Button();
           this.labelAddress = new DevComponents.DotNetBar.LabelX();
           this.textAddress = new DevComponents.DotNetBar.Controls.TextBoxX();
           this.buttonGo = new DevComponents.DotNetBar.ButtonX();
           this.buttonBack = new DevComponents.DotNetBar.ButtonX();
           this.buttonLaunchBrowser = new System.Windows.Forms.Button();
           this.buttonHome = new DevComponents.DotNetBar.ButtonX();
           this.buttonForward = new DevComponents.DotNetBar.ButtonX();
           this.progressBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
           this.SuspendLayout();
           // 
           // webBrowser1
           // 
           this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.webBrowser1.Location = new System.Drawing.Point( 0, 33 );
           this.webBrowser1.MinimumSize = new System.Drawing.Size( 20, 20 );
           this.webBrowser1.Name = "webBrowser1";
           this.webBrowser1.Size = new System.Drawing.Size( 992, 611 );
           this.webBrowser1.TabIndex = 6;
           this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler( this.webBrowser1_Navigating );
           this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler( this.webBrowser1_DocumentCompleted );
           this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler( this.webBrowser1_Navigated );
           this.webBrowser1.ScriptErrorsSuppressed = true;
           // 
           // buttonClose
           // 
           this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.buttonClose.Location = new System.Drawing.Point( 905, 653 );
           this.buttonClose.Name = "buttonClose";
           this.buttonClose.Size = new System.Drawing.Size( 82, 24 );
           this.buttonClose.TabIndex = 9;
           this.buttonClose.Text = "&Close";
           this.buttonClose.UseVisualStyleBackColor = true;
           this.buttonClose.Click += new System.EventHandler( this.buttonClose_Click );
           // 
           // labelAddress
           // 
           this.labelAddress.AutoSize = true;
           this.labelAddress.Location = new System.Drawing.Point( 6, 9 );
           this.labelAddress.Name = "labelAddress";
           this.labelAddress.Size = new System.Drawing.Size( 46, 15 );
           this.labelAddress.TabIndex = 0;
           this.labelAddress.Text = "Address:";
           // 
           // textAddress
           // 
           this.textAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           // 
           // 
           // 
           this.textAddress.Border.Class = "TextBoxBorder";
           this.textAddress.Location = new System.Drawing.Point( 55, 7 );
           this.textAddress.Name = "textAddress";
           this.textAddress.Size = new System.Drawing.Size( 834, 20 );
           this.textAddress.TabIndex = 1;
           // 
           // buttonGo
           // 
           this.buttonGo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
           this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
           this.buttonGo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
           this.buttonGo.Image = ((System.Drawing.Image)(resources.GetObject( "buttonGo.Image" )));
           this.buttonGo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
           this.buttonGo.Location = new System.Drawing.Point( 895, 7 );
           this.buttonGo.Name = "buttonGo";
           this.buttonGo.Size = new System.Drawing.Size( 20, 20 );
           this.buttonGo.TabIndex = 2;
           this.buttonGo.Click += new System.EventHandler( this.buttonGo_Click );
           // 
           // buttonBack
           // 
           this.buttonBack.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
           this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
           this.buttonBack.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
           this.buttonBack.Image = ((System.Drawing.Image)(resources.GetObject( "buttonBack.Image" )));
           this.buttonBack.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
           this.buttonBack.Location = new System.Drawing.Point( 919, 7 );
           this.buttonBack.Name = "buttonBack";
           this.buttonBack.Size = new System.Drawing.Size( 20, 20 );
           this.buttonBack.TabIndex = 3;
           this.buttonBack.Click += new System.EventHandler( this.buttonBack_Click );
           // 
           // buttonLaunchBrowser
           // 
           this.buttonLaunchBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this.buttonLaunchBrowser.Location = new System.Drawing.Point( 12, 653 );
           this.buttonLaunchBrowser.Name = "buttonLaunchBrowser";
           this.buttonLaunchBrowser.Size = new System.Drawing.Size( 134, 24 );
           this.buttonLaunchBrowser.TabIndex = 7;
           this.buttonLaunchBrowser.Text = "&Launch External Browser";
           this.buttonLaunchBrowser.UseVisualStyleBackColor = true;
           this.buttonLaunchBrowser.Click += new System.EventHandler( this.buttonLaunchBrowser_Click );
           // 
           // buttonHome
           // 
           this.buttonHome.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
           this.buttonHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
           this.buttonHome.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
           this.buttonHome.Image = ((System.Drawing.Image)(resources.GetObject( "buttonHome.Image" )));
           this.buttonHome.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
           this.buttonHome.Location = new System.Drawing.Point( 967, 7 );
           this.buttonHome.Name = "buttonHome";
           this.buttonHome.Size = new System.Drawing.Size( 20, 20 );
           this.buttonHome.TabIndex = 5;
           this.buttonHome.Click += new System.EventHandler( this.buttonHome_Click );
           // 
           // buttonForward
           // 
           this.buttonForward.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
           this.buttonForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
           this.buttonForward.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
           this.buttonForward.Image = ((System.Drawing.Image)(resources.GetObject( "buttonForward.Image" )));
           this.buttonForward.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
           this.buttonForward.Location = new System.Drawing.Point( 943, 7 );
           this.buttonForward.Name = "buttonForward";
           this.buttonForward.Size = new System.Drawing.Size( 20, 20 );
           this.buttonForward.TabIndex = 4;
           this.buttonForward.Click += new System.EventHandler( this.buttonForward_Click );
           // 
           // progressBar
           // 
           this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.progressBar.BackColor = System.Drawing.Color.Transparent;
           this.progressBar.Location = new System.Drawing.Point( 697, 655 );
           this.progressBar.Name = "progressBar";
           this.progressBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
           this.progressBar.Size = new System.Drawing.Size( 192, 20 );
           this.progressBar.TabIndex = 8;
           // 
           // Form_MiniBrowser
           // 
           this.AcceptButton = this.buttonGo;
           this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.BackColor = System.Drawing.Color.WhiteSmoke;
           this.CancelButton = this.buttonClose;
           this.ClientSize = new System.Drawing.Size( 992, 686 );
           this.Controls.Add( this.progressBar );
           this.Controls.Add( this.buttonHome );
           this.Controls.Add( this.buttonForward );
           this.Controls.Add( this.buttonLaunchBrowser );
           this.Controls.Add( this.textAddress );
           this.Controls.Add( this.buttonBack );
           this.Controls.Add( this.buttonGo );
           this.Controls.Add( this.labelAddress );
           this.Controls.Add( this.buttonClose );
           this.Controls.Add( this.webBrowser1 );
           this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
           this.MinimumSize = new System.Drawing.Size( 475, 250 );
           this.Name = "Form_MiniBrowser";
           this.ShowInTaskbar = false;
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "SQL admin toolset Mini Browser";
           this.ResumeLayout( false );
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button buttonClose;
       private DevComponents.DotNetBar.LabelX labelAddress;
       private DevComponents.DotNetBar.Controls.TextBoxX textAddress;
       private DevComponents.DotNetBar.ButtonX buttonGo;
       private DevComponents.DotNetBar.ButtonX buttonBack;
       private System.Windows.Forms.Button buttonLaunchBrowser;
       private DevComponents.DotNetBar.ButtonX buttonHome;
       private DevComponents.DotNetBar.ButtonX buttonForward;
       private DevComponents.DotNetBar.Controls.ProgressBarX progressBar;
    }
}