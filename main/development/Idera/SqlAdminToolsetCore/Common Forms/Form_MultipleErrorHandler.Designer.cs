namespace Idera.SqlAdminToolset.Core
{
    partial class Form_MultipleErrorHandler
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
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
           System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
           this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
           this.buttonOK = new DevComponents.DotNetBar.ButtonX();
           this.buttonClipboard = new DevComponents.DotNetBar.ButtonX();
           ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
           this.SuspendLayout();
           // 
           // dataGridViewX1
           // 
           this.dataGridViewX1.AllowUserToAddRows = false;
           this.dataGridViewX1.AllowUserToDeleteRows = false;
           dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))) );
           this.dataGridViewX1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
           this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.dataGridViewX1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
           this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
           dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
           dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
           dataGridViewCellStyle6.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
           dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
           dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
           dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
           dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
           this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle6;
           this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb( ((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))) );
           this.dataGridViewX1.HighlightSelectedColumnHeaders = false;
           this.dataGridViewX1.Location = new System.Drawing.Point( 0, 12 );
           this.dataGridViewX1.Name = "dataGridViewX1";
           this.dataGridViewX1.SelectAllSignVisible = false;
           this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
           this.dataGridViewX1.Size = new System.Drawing.Size( 695, 500 );
           this.dataGridViewX1.TabIndex = 0;
           // 
           // buttonOK
           // 
           this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
           this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
           this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.buttonOK.Location = new System.Drawing.Point( 607, 520 );
           this.buttonOK.Name = "buttonOK";
           this.buttonOK.Size = new System.Drawing.Size( 75, 23 );
           this.buttonOK.TabIndex = 1;
           this.buttonOK.Text = "&OK";
           // 
           // buttonClipboard
           // 
           this.buttonClipboard.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
           this.buttonClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this.buttonClipboard.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
           this.buttonClipboard.Location = new System.Drawing.Point( 9, 522 );
           this.buttonClipboard.Name = "buttonClipboard";
           this.buttonClipboard.Size = new System.Drawing.Size( 119, 23 );
           this.buttonClipboard.TabIndex = 2;
           this.buttonClipboard.Text = "&Copy to Clipboard";
           this.buttonClipboard.Click += new System.EventHandler( this.buttonClipboard_Click );
           // 
           // Form_MultipleErrorHandler
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size( 694, 551 );
           this.Controls.Add( this.buttonClipboard );
           this.Controls.Add( this.buttonOK );
           this.Controls.Add( this.dataGridViewX1 );
           this.MinimizeBox = false;
           this.MinimumSize = new System.Drawing.Size( 600, 300 );
           this.Name = "Form_MultipleErrorHandler";
           this.ShowIcon = false;
           this.ShowInTaskbar = false;
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Error Report";
           this.Load += new System.EventHandler( this.Form_MultipleErrorHandler_Load );
           ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
           this.ResumeLayout( false );

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX buttonOK;
       private DevComponents.DotNetBar.ButtonX buttonClipboard;
    }
}