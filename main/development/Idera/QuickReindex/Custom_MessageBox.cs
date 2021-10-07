using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.QuickReindex
{
    public partial class Custom_MessageBox : Form
    {
        public Custom_MessageBox(string message)
        {
            InitializeComponent(message);
            
        }

        private void buttonX_Yes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonX_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
