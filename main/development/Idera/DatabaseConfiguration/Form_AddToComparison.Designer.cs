namespace Idera.SqlAdminToolset.DatabaseConfiguration
{
   partial class Form_AddToComparison
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_AddToComparison ) );
         this.labelDatabases = new DevComponents.DotNetBar.LabelX();
         this.buttonCancel = new DevComponents.DotNetBar.ButtonX();
         this.buttonOK = new DevComponents.DotNetBar.ButtonX();
         this.treeDatabaseList = new System.Windows.Forms.TreeView();
         this.labelNoAvailableDatabases = new DevComponents.DotNetBar.LabelX();
         this.SuspendLayout();
         // 
         // labelDatabases
         // 
         this.labelDatabases.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
         this.labelDatabases.Location = new System.Drawing.Point( 12, 12 );
         this.labelDatabases.Name = "labelDatabases";
         this.labelDatabases.Size = new System.Drawing.Size( 349, 23 );
         this.labelDatabases.TabIndex = 19;
         this.labelDatabases.Text = "Add the following databases to the Comparison Report:";
         // 
         // buttonCancel
         // 
         this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point( 286, 333 );
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size( 75, 23 );
         this.buttonCancel.TabIndex = 17;
         this.buttonCancel.Text = "Cancel";
         // 
         // buttonOK
         // 
         this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
         this.buttonOK.Location = new System.Drawing.Point( 197, 333 );
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size( 75, 23 );
         this.buttonOK.TabIndex = 16;
         this.buttonOK.Text = "OK";
         this.buttonOK.Click += new System.EventHandler( this.buttonOK_Click );
         // 
         // treeDatabaseList
         // 
         this.treeDatabaseList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.treeDatabaseList.CheckBoxes = true;
         this.treeDatabaseList.Location = new System.Drawing.Point( 13, 42 );
         this.treeDatabaseList.Name = "treeDatabaseList";
         this.treeDatabaseList.Size = new System.Drawing.Size( 353, 285 );
         this.treeDatabaseList.TabIndex = 20;
         this.treeDatabaseList.AfterCheck += new System.Windows.Forms.TreeViewEventHandler( this.treeDatabaseList_AfterCheck );
         // 
         // labelNoAvailableDatabases
         // 
         this.labelNoAvailableDatabases.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
         this.labelNoAvailableDatabases.Location = new System.Drawing.Point( 15, 172 );
         this.labelNoAvailableDatabases.Name = "labelNoAvailableDatabases";
         this.labelNoAvailableDatabases.Size = new System.Drawing.Size( 349, 23 );
         this.labelNoAvailableDatabases.TabIndex = 21;
         this.labelNoAvailableDatabases.Text = "No databases available";
         this.labelNoAvailableDatabases.TextAlignment = System.Drawing.StringAlignment.Center;
         this.labelNoAvailableDatabases.Visible = false;
         // 
         // Form_AddToComparison
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size( 378, 366 );
         this.Controls.Add( this.labelNoAvailableDatabases );
         this.Controls.Add( this.treeDatabaseList );
         this.Controls.Add( this.labelDatabases );
         this.Controls.Add( this.buttonCancel );
         this.Controls.Add( this.buttonOK );
         this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "Form_AddToComparison";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Add Database to Comparison Report";
         this.ResumeLayout( false );

      }

      #endregion

      private DevComponents.DotNetBar.LabelX labelDatabases;
      private DevComponents.DotNetBar.ButtonX buttonCancel;
      private DevComponents.DotNetBar.ButtonX buttonOK;
      private System.Windows.Forms.TreeView treeDatabaseList;
      private DevComponents.DotNetBar.LabelX labelNoAvailableDatabases;

   }
}