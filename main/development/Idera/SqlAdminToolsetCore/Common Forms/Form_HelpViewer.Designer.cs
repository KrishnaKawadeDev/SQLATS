namespace Idera.SqlAdminToolset.Core
{
    partial class Form_HelpViewer
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_HelpViewer ) );
           this.webBrowser1 = new System.Windows.Forms.WebBrowser();
           this.buttonClose = new System.Windows.Forms.Button();
           this.SuspendLayout();
           // 
           // webBrowser1
           // 
           this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.webBrowser1.Location = new System.Drawing.Point( 0, 0 );
           this.webBrowser1.MinimumSize = new System.Drawing.Size( 20, 20 );
           this.webBrowser1.Name = "webBrowser1";
           this.webBrowser1.Size = new System.Drawing.Size( 892, 480 );
           this.webBrowser1.TabIndex = 0;
           // 
           // buttonClose
           // 
           this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.buttonClose.Location = new System.Drawing.Point( 802, 489 );
           this.buttonClose.Name = "buttonClose";
           this.buttonClose.Size = new System.Drawing.Size( 82, 24 );
           this.buttonClose.TabIndex = 1;
           this.buttonClose.Text = "&Close";
           this.buttonClose.UseVisualStyleBackColor = true;
           // 
           // Form_HelpViewer
           // 
           this.AcceptButton = this.buttonClose;
           this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.CancelButton = this.buttonClose;
           this.ClientSize = new System.Drawing.Size( 892, 522 );
           this.Controls.Add( this.buttonClose );
           this.Controls.Add( this.webBrowser1 );
           this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
           this.Name = "Form_HelpViewer";
           this.ShowInTaskbar = false;
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "SQL admin toolkit Help";
           this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button buttonClose;
    }
}