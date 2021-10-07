using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Core
{
    public partial class Form_HelpViewer : Form
    {
        public
           Form_HelpViewer(
              string productName,
              string helpFile
           )
        {
            InitializeComponent();

            this.Text = productName + " Help";

           // helpFile
           string helpUrl = "file://" + helpFile;
           webBrowser1.Url = new System.Uri(helpUrl);
        }
    }
}