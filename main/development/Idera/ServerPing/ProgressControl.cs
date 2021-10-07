using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.ServerPing
{
   public partial class ProgressControl : UserControl
   {
      public ProgressControl()
      {
         InitializeComponent();
      }

      public string OperationText
      {
         get { return labelOperationText.Text; }
         set { labelOperationText.Text = value; }
      }
      
      public bool MarqueeStyle
      {
         get
         {
            return (progressBar.ProgressType == DevComponents.DotNetBar.eProgressItemType.Marquee);
         }

         set
         {
            progressBar.ProgressType = (value) ? DevComponents.DotNetBar.eProgressItemType.Marquee 
                                               : DevComponents.DotNetBar.eProgressItemType.Standard;
         }
      }

      public int Step
      {
        get { return progressBar.Step; }
        set { progressBar.Step = value; }
      }

      public int Maximum
      {
        get { return progressBar.Maximum; }
        set { progressBar.Maximum = value; }
      }

      public int Minimum
      {
        get { return progressBar.Minimum; }
        set { progressBar.Minimum = value; }
      }

      public bool CancelButtonVisible
      {
         get { return buttonCancel.Visible; }
         set 
         {
            buttonCancel.Visible = value;
            if (value)
            {
               this.Height = this.MaximumSize.Height;
               this.Width = this.MaximumSize.Width;
            }
            else
            {
               this.Height = this.MinimumSize.Height;
               this.Width = this.MinimumSize.Width;
            }
         }
      }

      public void
      SetMarqueeStyle(
            string operationText
         )
      {
         labelOperationText.Text = operationText;
         progressBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
      }

      public void
      SetStandardStyle(
            string operationText,
            int    minimum,
            int    maximum,
            int    step
         )
      {
         labelOperationText.Text = operationText;
         progressBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Standard;
         progressBar.Maximum = maximum;
         progressBar.Minimum = minimum;
         progressBar.Step    = step;
      }

      public int IncrementStep()
      {
         if ( progressBar.Step <progressBar.Maximum ) 
            progressBar.Step++;

         return ( progressBar.Step );
      }

      public void MarkComplete()
      {
         progressBar.Step = progressBar.Maximum;
      }

      #region Cancel Handling
      
      private EventHandler<EventArgs> _ProgressCancelEvent = null;

      public EventHandler<EventArgs> ProgressCancelEventHandler
      {
         get { return _ProgressCancelEvent; }
         set { _ProgressCancelEvent = value; }
      }
      
      public event EventHandler<EventArgs> ProgressCancelEvent
      {
         add { _ProgressCancelEvent += value; }
         remove { _ProgressCancelEvent -= value; }
      }

      private void buttonCancel_Click( object sender, EventArgs e )
      {
         if ( _ProgressCancelEvent != null )
         {
            _ProgressCancelEvent(this, new EventArgs());
         }
      }
      
      #endregion
      
      #region Minimize Handling

      private EventHandler<EventArgs> _ProgressMinimizeEvent = null;

      public EventHandler<EventArgs> ProgressMinimizeEventHandler
      {
         get { return _ProgressMinimizeEvent; }
         set { _ProgressMinimizeEvent = value; }
      }
      
      public event EventHandler<EventArgs> ProgressMinimizeEvent
      {
         add { _ProgressMinimizeEvent += value; }
         remove { _ProgressMinimizeEvent -= value; }
      }

      private void buttonMinimize_Click( object sender, EventArgs e )
      {
         if ( _ProgressMinimizeEvent != null )
         {
            _ProgressMinimizeEvent(this, new EventArgs());
         }
      }
      
      #endregion
   }
}
