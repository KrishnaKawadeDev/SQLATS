namespace Idera.SqlAdminToolset.SqlSearch
{
    partial class Form_SQLViewer
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
           this.components = new System.ComponentModel.Container();
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_SQLViewer ) );
           this.textSQL = new System.Windows.Forms.RichTextBox();
           this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip( this.components );
           this.contextMenuFindNextMatch = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
           this.contextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
           this.contextMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
           this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
           this.labelObject = new DevComponents.DotNetBar.LabelX();
           this.buttonFindNextMatch = new DevComponents.DotNetBar.ButtonX();
           this.buttonClose = new DevComponents.DotNetBar.ButtonX();
           this.checkWordWrap = new DevComponents.DotNetBar.Controls.CheckBoxX();
           this.buttonPrev = new DevComponents.DotNetBar.ButtonX();
           this.buttonNext = new DevComponents.DotNetBar.ButtonX();
           this.contextMenuStrip1.SuspendLayout();
           this.groupPanel1.SuspendLayout();
           this.SuspendLayout();
           // 
           // textSQL
           // 
           this.textSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.textSQL.BackColor = System.Drawing.Color.White;
           this.textSQL.ContextMenuStrip = this.contextMenuStrip1;
           this.textSQL.DetectUrls = false;
           this.textSQL.Font = new System.Drawing.Font( "Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
           this.textSQL.HideSelection = false;
           this.textSQL.Location = new System.Drawing.Point( 5, 6 );
           this.textSQL.Name = "textSQL";
           this.textSQL.ReadOnly = true;
           this.textSQL.Size = new System.Drawing.Size( 664, 315 );
           this.textSQL.TabIndex = 3;
           this.textSQL.Text = "";
           this.textSQL.WordWrap = false;
           // 
           // contextMenuStrip1
           // 
           this.contextMenuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuFindNextMatch,
            this.toolStripMenuItem1,
            this.contextMenuCopy,
            this.contextMenuSelectAll} );
           this.contextMenuStrip1.Name = "contextMenuStrip1";
           this.contextMenuStrip1.ShowImageMargin = false;
           this.contextMenuStrip1.Size = new System.Drawing.Size( 158, 76 );
           // 
           // contextMenuFindNextMatch
           // 
           this.contextMenuFindNextMatch.Name = "contextMenuFindNextMatch";
           this.contextMenuFindNextMatch.ShortcutKeys = System.Windows.Forms.Keys.F3;
           this.contextMenuFindNextMatch.Size = new System.Drawing.Size( 157, 22 );
           this.contextMenuFindNextMatch.Text = "Find Next Match";
           this.contextMenuFindNextMatch.Click += new System.EventHandler( this.contextMenuFindNextMatch_Click );
           // 
           // toolStripMenuItem1
           // 
           this.toolStripMenuItem1.Name = "toolStripMenuItem1";
           this.toolStripMenuItem1.Size = new System.Drawing.Size( 154, 6 );
           // 
           // contextMenuCopy
           // 
           this.contextMenuCopy.Name = "contextMenuCopy";
           this.contextMenuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
           this.contextMenuCopy.Size = new System.Drawing.Size( 157, 22 );
           this.contextMenuCopy.Text = "Copy";
           this.contextMenuCopy.Click += new System.EventHandler( this.contextMenuCopy_Click );
           // 
           // contextMenuSelectAll
           // 
           this.contextMenuSelectAll.Name = "contextMenuSelectAll";
           this.contextMenuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
           this.contextMenuSelectAll.Size = new System.Drawing.Size( 157, 22 );
           this.contextMenuSelectAll.Text = "Select All";
           this.contextMenuSelectAll.Click += new System.EventHandler( this.contextMenuSelectAll_Click );
           // 
           // groupPanel1
           // 
           this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
           this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
           this.groupPanel1.Controls.Add( this.textSQL );
           this.groupPanel1.Location = new System.Drawing.Point( 3, 49 );
           this.groupPanel1.Name = "groupPanel1";
           this.groupPanel1.Size = new System.Drawing.Size( 680, 346 );
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
           this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
           this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
           this.groupPanel1.TabIndex = 2;
           this.groupPanel1.Text = "Source";
           // 
           // labelObject
           // 
           this.labelObject.Font = new System.Drawing.Font( "Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
           this.labelObject.Location = new System.Drawing.Point( 12, 2 );
           this.labelObject.Name = "labelObject";
           this.labelObject.Size = new System.Drawing.Size( 533, 44 );
           this.labelObject.TabIndex = 0;
           this.labelObject.Text = "ObjectName in DatabaseName";
           this.labelObject.WordWrap = true;
           // 
           // buttonFindNextMatch
           // 
           this.buttonFindNextMatch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
           this.buttonFindNextMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
           this.buttonFindNextMatch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
           this.buttonFindNextMatch.Image = ((System.Drawing.Image)(resources.GetObject( "buttonFindNextMatch.Image" )));
           this.buttonFindNextMatch.Location = new System.Drawing.Point( 550, 30 );
           this.buttonFindNextMatch.Name = "buttonFindNextMatch";
           this.buttonFindNextMatch.Size = new System.Drawing.Size( 125, 22 );
           this.buttonFindNextMatch.TabIndex = 1;
           this.buttonFindNextMatch.Text = "&Find Next Match";
           this.buttonFindNextMatch.Click += new System.EventHandler( this.buttonFindNextMatch_Click );
           // 
           // buttonClose
           // 
           this.buttonClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
           this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.buttonClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
           this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.buttonClose.Location = new System.Drawing.Point( 605, 403 );
           this.buttonClose.Name = "buttonClose";
           this.buttonClose.Size = new System.Drawing.Size( 69, 22 );
           this.buttonClose.TabIndex = 7;
           this.buttonClose.Text = "&Close";
           // 
           // checkWordWrap
           // 
           this.checkWordWrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this.checkWordWrap.Location = new System.Drawing.Point( 258, 404 );
           this.checkWordWrap.Name = "checkWordWrap";
           this.checkWordWrap.Size = new System.Drawing.Size( 187, 19 );
           this.checkWordWrap.TabIndex = 6;
           this.checkWordWrap.Text = "&Wrap text based on window size";
           this.checkWordWrap.CheckValueChanged += new System.EventHandler( this.checkWordWrap_CheckedChanged );
           // 
           // buttonPrev
           // 
           this.buttonPrev.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
           this.buttonPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this.buttonPrev.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
           this.buttonPrev.Image = ((System.Drawing.Image)(resources.GetObject( "buttonPrev.Image" )));
           this.buttonPrev.Location = new System.Drawing.Point( 3, 403 );
           this.buttonPrev.Name = "buttonPrev";
           this.buttonPrev.Size = new System.Drawing.Size( 118, 22 );
           this.buttonPrev.TabIndex = 4;
           this.buttonPrev.Text = "&Previous Object";
           this.buttonPrev.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
           this.buttonPrev.Tooltip = "Show Source for Previous Object";
           this.buttonPrev.Click += new System.EventHandler( this.buttonPrevious_Click );
           // 
           // buttonNext
           // 
           this.buttonNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
           this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this.buttonNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
           this.buttonNext.Image = ((System.Drawing.Image)(resources.GetObject( "buttonNext.Image" )));
           this.buttonNext.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
           this.buttonNext.Location = new System.Drawing.Point( 125, 403 );
           this.buttonNext.Name = "buttonNext";
           this.buttonNext.Size = new System.Drawing.Size( 118, 22 );
           this.buttonNext.TabIndex = 5;
           this.buttonNext.Text = "&Next Object";
           this.buttonNext.Tooltip = "Show Source for Next Object";
           this.buttonNext.Click += new System.EventHandler( this.buttonNext_Click );
           // 
           // Form_SQLViewer
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.BackColor = System.Drawing.Color.White;
           this.ClientSize = new System.Drawing.Size( 686, 431 );
           this.Controls.Add( this.buttonFindNextMatch );
           this.Controls.Add( this.buttonClose );
           this.Controls.Add( this.buttonNext );
           this.Controls.Add( this.buttonPrev );
           this.Controls.Add( this.groupPanel1 );
           this.Controls.Add( this.checkWordWrap );
           this.Controls.Add( this.labelObject );
           this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
           this.KeyPreview = true;
           this.MinimumSize = new System.Drawing.Size( 534, 243 );
           this.Name = "Form_SQLViewer";
           this.ShowInTaskbar = false;
           this.Text = "View Source Code";
           this.KeyDown += new System.Windows.Forms.KeyEventHandler( this.Form_SQLViewer_KeyDown );
           this.contextMenuStrip1.ResumeLayout( false );
           this.groupPanel1.ResumeLayout( false );
           this.ResumeLayout( false );

        }

        #endregion

       private System.Windows.Forms.RichTextBox textSQL;
       private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
       private DevComponents.DotNetBar.LabelX labelObject;
       private DevComponents.DotNetBar.ButtonX buttonFindNextMatch;
       private DevComponents.DotNetBar.ButtonX buttonClose;
       private DevComponents.DotNetBar.Controls.CheckBoxX checkWordWrap;
       private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
       private System.Windows.Forms.ToolStripMenuItem contextMenuFindNextMatch;
       private System.Windows.Forms.ToolStripMenuItem contextMenuCopy;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
       private System.Windows.Forms.ToolStripMenuItem contextMenuSelectAll;
       private DevComponents.DotNetBar.ButtonX buttonPrev;
       private DevComponents.DotNetBar.ButtonX buttonNext;
    }
}