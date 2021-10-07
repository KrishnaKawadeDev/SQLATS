using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Core
{
   public partial class ToolProgressList : UserControl
   {
      public enum StepStatus
      {
         Working = 0,
         OK      = 1,
         Warning = 2,
         Error   = 3,
         None    = 4
      }
      
      private int m_numberOfSteps;
      public int NumberOfSteps
      {
         get { return m_numberOfSteps; }
         set
         {
            m_numberOfSteps = value;
            if ( m_numberOfSteps < 1 ) m_numberOfSteps = 1;
            if ( m_numberOfSteps > 6 ) m_numberOfSteps = 6;
            
            int i;
            for (i=1;i<=6;i++)
            {
               if ( i <= m_numberOfSteps )
                  ShowStep(i,true);
               else
                  ShowStep(i,false);
            }
         }
      }
      
      public ToolProgressList()
      {
         InitializeComponent();
      }
      
      public void Initialize()
      {
         SetStepStatus( 1, StepStatus.None );
         SetStepStatus( 2, StepStatus.None );
         SetStepStatus( 3, StepStatus.None );
         SetStepStatus( 4, StepStatus.None );
         SetStepStatus( 5, StepStatus.None );
         SetStepStatus( 6, StepStatus.None );
      }
      
      public void
         SetStepText(
            int step,
            string text
         )
     {
        switch (step)
        {
           case 1: label_Step1.Text = text; break;
           case 2: label_Step2.Text = text; break;
           case 3: label_Step3.Text = text; break;
           case 4: label_Step4.Text = text; break;
           case 5: label_Step5.Text = text; break;
           case 6: label_Step6.Text = text; break;
        }
     }
     
      public void
         SetStepStatus(
            int                         step,
            ToolProgressList.StepStatus status
         )
     {
        DevComponents.DotNetBar.LabelX labelx = null;
        System.Windows.Forms.PictureBox pictureBox = null;
        switch (step)
        {
           case 1:
              pictureBox = pictureBox_Step1;
              labelx     = label_Step1;
              break;
           case 2:
              pictureBox = pictureBox_Step2;
              labelx     = label_Step2;
              break;
           case 3:
              pictureBox = pictureBox_Step3;
              labelx     = label_Step3;
              break;
           case 4:
              pictureBox = pictureBox_Step4;
              labelx     = label_Step4;
              break;
           case 5:
              pictureBox = pictureBox_Step5;
              labelx     = label_Step5;
              break;
           case 6:
              pictureBox = pictureBox_Step6;
              labelx     = label_Step6;
              break;
        }
        
        if ( pictureBox != null )
        {
           if ( status == StepStatus.Working )
              pictureBox.Image = global::Idera.SqlAdminToolset.Core.Properties.Resources.Working;
           else if ( status == StepStatus.OK )
              pictureBox.Image = global::Idera.SqlAdminToolset.Core.Properties.Resources._32_SystemOK;
           else if ( status == StepStatus.Warning )
              pictureBox.Image = global::Idera.SqlAdminToolset.Core.Properties.Resources._32_SystemWarn;
           else if ( status == StepStatus.Error )
              pictureBox.Image = global::Idera.SqlAdminToolset.Core.Properties.Resources._32_SystemError;
           else
              pictureBox.Image = null;
              
           if ( pictureBox.Image != null )
              labelx.Font = new Font(label_Step1.Font, FontStyle.Bold);
           else
              labelx.Font = new Font(label_Step1.Font, FontStyle.Regular);
        }
     }
     
      public void
         ShowStep(
            int step,
            bool visible
         )
     {
        switch (step)
        {
           case 1: label_Step1.Visible = visible; break;
           case 2: label_Step2.Visible = visible; break;
           case 3: label_Step3.Visible = visible; break;
           case 4: label_Step4.Visible = visible; break;
           case 5: label_Step5.Visible = visible; break;
           case 6: label_Step6.Visible = visible; break;
        }
     }
   }
}
