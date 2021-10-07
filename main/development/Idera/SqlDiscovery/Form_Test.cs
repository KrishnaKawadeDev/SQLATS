using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SqlDiscovery
{
   public partial class Form_Test : Form
   {
      public Form_Test()
      {
         InitializeComponent();
         
         toolProgressList1.Initialize();
         toolProgressList1.SetStepStatus(1, Idera.SqlAdminToolset.Core.ToolProgressList.StepStatus.Working );
      }

      private void button1_Click( object sender, EventArgs e )
      {
         Close();
      }

      private void button2_Click( object sender, EventArgs e )
      {
         toolProgressList1.SetStepStatus(1, Idera.SqlAdminToolset.Core.ToolProgressList.StepStatus.OK );
         toolProgressList1.SetStepStatus(2, Idera.SqlAdminToolset.Core.ToolProgressList.StepStatus.Working );

      }

      private void button3_Click( object sender, EventArgs e )
      {
         toolProgressList1.SetStepStatus(2, Idera.SqlAdminToolset.Core.ToolProgressList.StepStatus.Warning );
         toolProgressList1.SetStepStatus(3, Idera.SqlAdminToolset.Core.ToolProgressList.StepStatus.Working );
      }
      
      private void button4_Click( object sender, EventArgs e )
      {
         toolProgressList1.SetStepStatus(3, Idera.SqlAdminToolset.Core.ToolProgressList.StepStatus.OK );
         toolProgressList1.SetStepStatus(4, Idera.SqlAdminToolset.Core.ToolProgressList.StepStatus.Working );
      }

      private void button5_Click( object sender, EventArgs e )
      {
         toolProgressList1.Initialize();
         toolProgressList1.SetStepStatus(1, Idera.SqlAdminToolset.Core.ToolProgressList.StepStatus.Working );
      }

      private void button6_Click( object sender, EventArgs e )
      {
         toolProgressList1.SetStepStatus(4, Idera.SqlAdminToolset.Core.ToolProgressList.StepStatus.OK );
      }

   }
}