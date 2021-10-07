using Idera.SqlAdminToolset.Core.Controls;
namespace Idera.SqlAdminToolset.ServerPing
{
    partial class ProgressBarDialog
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
           this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
           this.toolProgress1 = new Idera.SqlAdminToolset.ServerPing.ProgressControl();
           this.groupPanel1.SuspendLayout();
           this.SuspendLayout();
           // 
           // groupPanel1
           // 
           this.groupPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
           this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
           this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
           this.groupPanel1.Controls.Add( this.toolProgress1 );
           this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.groupPanel1.Location = new System.Drawing.Point( 0, 0 );
           this.groupPanel1.Name = "groupPanel1";
           this.groupPanel1.Size = new System.Drawing.Size( 413, 137 );
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
           // toolProgress1
           // 
           this.toolProgress1.BackColor = System.Drawing.Color.Transparent;
           this.toolProgress1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
           this.toolProgress1.CancelButtonVisible = true;
           this.toolProgress1.Location = new System.Drawing.Point( 6, 7 );
           this.toolProgress1.MarqueeStyle = true;
           this.toolProgress1.Maximum = 100;
           this.toolProgress1.MaximumSize = new System.Drawing.Size( 394, 116 );
           this.toolProgress1.Minimum = 0;
           this.toolProgress1.MinimumSize = new System.Drawing.Size( 394, 92 );
           this.toolProgress1.Name = "toolProgress1";
           this.toolProgress1.OperationText = "Description of Operation";
           this.toolProgress1.ProgressCancelEventHandler = null;
           this.toolProgress1.ProgressMinimizeEventHandler = null;
           this.toolProgress1.Size = new System.Drawing.Size( 394, 116 );
           this.toolProgress1.Step = 1;
           this.toolProgress1.TabIndex = 0;
           // 
           // ProgressBarDialog
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.BackColor = System.Drawing.Color.WhiteSmoke;
           this.ClientSize = new System.Drawing.Size( 413, 137 );
           this.Controls.Add( this.groupPanel1 );
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
           this.Name = "ProgressBarDialog";
           this.ShowInTaskbar = false;
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "ProgressBarDialog";
           this.groupPanel1.ResumeLayout( false );
           this.ResumeLayout( false );

        }

        #endregion

        private ProgressControl toolProgress1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
    }
}