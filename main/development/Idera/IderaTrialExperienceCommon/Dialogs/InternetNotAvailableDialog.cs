using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IderaTrialExperienceCommon.Dialogs
{
    public partial class InternetNotAvailableDialog : Form
    {


        public InternetNotAvailableDialog(string applicationName, string url)
        {
            InitializeComponent();

            base.Text = applicationName;
            webPageUrl.Text = url;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
