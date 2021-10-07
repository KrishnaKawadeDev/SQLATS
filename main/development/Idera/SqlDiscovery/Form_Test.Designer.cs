namespace Idera.SqlAdminToolset.SqlDiscovery
{
   partial class Form_Test
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
         this.toolProgressList1 = new Idera.SqlAdminToolset.Core.ToolProgressList();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.button3 = new System.Windows.Forms.Button();
         this.button4 = new System.Windows.Forms.Button();
         this.button5 = new System.Windows.Forms.Button();
         this.button6 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // toolProgressList1
         // 
         this.toolProgressList1.BackColor = System.Drawing.Color.White;
         this.toolProgressList1.Location = new System.Drawing.Point( 12, 12 );
         this.toolProgressList1.Name = "toolProgressList1";
         this.toolProgressList1.NumberOfSteps = 4;
         this.toolProgressList1.Size = new System.Drawing.Size( 531, 233 );
         this.toolProgressList1.TabIndex = 0;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point( 459, 400 );
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size( 71, 26 );
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler( this.button1_Click );
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point( 12, 297 );
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size( 71, 26 );
         this.button2.TabIndex = 2;
         this.button2.Text = "Start Step 2";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler( this.button2_Click );
         // 
         // button3
         // 
         this.button3.Location = new System.Drawing.Point( 12, 329 );
         this.button3.Name = "button3";
         this.button3.Size = new System.Drawing.Size( 71, 26 );
         this.button3.TabIndex = 3;
         this.button3.Text = "Start Step 3";
         this.button3.UseVisualStyleBackColor = true;
         this.button3.Click += new System.EventHandler( this.button3_Click );
         // 
         // button4
         // 
         this.button4.Location = new System.Drawing.Point( 12, 361 );
         this.button4.Name = "button4";
         this.button4.Size = new System.Drawing.Size( 71, 26 );
         this.button4.TabIndex = 4;
         this.button4.Text = "Start Step 4";
         this.button4.UseVisualStyleBackColor = true;
         this.button4.Click += new System.EventHandler( this.button4_Click );
         // 
         // button5
         // 
         this.button5.Location = new System.Drawing.Point( 420, 319 );
         this.button5.Name = "button5";
         this.button5.Size = new System.Drawing.Size( 71, 26 );
         this.button5.TabIndex = 5;
         this.button5.Text = "Reset";
         this.button5.UseVisualStyleBackColor = true;
         this.button5.Click += new System.EventHandler( this.button5_Click );
         // 
         // button6
         // 
         this.button6.Location = new System.Drawing.Point( 12, 393 );
         this.button6.Name = "button6";
         this.button6.Size = new System.Drawing.Size( 71, 26 );
         this.button6.TabIndex = 6;
         this.button6.Text = "Done";
         this.button6.UseVisualStyleBackColor = true;
         this.button6.Click += new System.EventHandler( this.button6_Click );
         // 
         // Form_Test
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size( 558, 435 );
         this.Controls.Add( this.button6 );
         this.Controls.Add( this.button5 );
         this.Controls.Add( this.button4 );
         this.Controls.Add( this.button3 );
         this.Controls.Add( this.button2 );
         this.Controls.Add( this.button1 );
         this.Controls.Add( this.toolProgressList1 );
         this.Name = "Form_Test";
         this.Text = "aaaTest";
         this.ResumeLayout( false );

      }

      #endregion

      private Idera.SqlAdminToolset.Core.ToolProgressList toolProgressList1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button button3;
      private System.Windows.Forms.Button button4;
      private System.Windows.Forms.Button button5;
      private System.Windows.Forms.Button button6;
   }
}