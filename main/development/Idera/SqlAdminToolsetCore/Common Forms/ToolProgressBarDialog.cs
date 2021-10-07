using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core.Controls;

namespace Idera.SqlAdminToolset.Core
{
    public partial class ToolProgressBarDialog : Form
    {
        public ToolProgressBarDialog()
        {
            InitializeComponent();
            toolProgressEx1.ProgressText = string.Empty;
        }

        public string OperationText
        {
            set { toolProgressEx1.OperationText = value; }
        }

        public string ProgressText
        {
            set { toolProgressEx1.ProgressText = value; }
        }

        public bool CancelEnabled
        {
            set { toolProgressEx1.buttonCancel.Enabled = value; }
        }

        public event EventHandler<EventArgs> ProgressCancelEvent
        {
            add { toolProgressEx1.ProgressCancelEventHandler += value; }
            remove { toolProgressEx1.ProgressCancelEventHandler -= value; }
        }

        public EventHandler<EventArgs> ProgressCancelEventHandler
        {
            get { return toolProgressEx1.ProgressCancelEventHandler; }
            set { toolProgressEx1.ProgressCancelEventHandler = value; }
        }
       
    }
}