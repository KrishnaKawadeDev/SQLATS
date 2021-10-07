using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core.Controls;

namespace Idera.SqlAdminToolset.ServerPing
{
    public partial class ProgressBarDialog : Form
    {
        public ProgressBarDialog()
        {
            InitializeComponent();
        }


        public string OperationText
        {
            set { toolProgress1.OperationText = value; }
        }

        public bool CancelEnabled
        {
            set { toolProgress1.buttonCancel.Enabled = value; }
        }

        public event EventHandler<EventArgs> ProgressCancelEvent
        {
            add { toolProgress1.ProgressCancelEventHandler += value; }
            remove { toolProgress1.ProgressCancelEventHandler -= value; }
        }

        public EventHandler<EventArgs> ProgressCancelEventHandler
        {
            get { return toolProgress1.ProgressCancelEventHandler; }
            set { toolProgress1.ProgressCancelEventHandler = value; }
        }
        
        public event EventHandler<EventArgs> ProgressMinimizeEvent
        {
            add { toolProgress1.ProgressMinimizeEventHandler += value; }
            remove { toolProgress1.ProgressMinimizeEventHandler -= value; }
        }

        public EventHandler<EventArgs> ProgressMinimizeEventHandler
        {
            get { return toolProgress1.ProgressMinimizeEventHandler; }
            set { toolProgress1.ProgressMinimizeEventHandler = value; }
        }
    }
}