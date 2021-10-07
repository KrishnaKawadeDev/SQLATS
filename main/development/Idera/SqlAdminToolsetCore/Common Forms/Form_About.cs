using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.Core
{
    public partial class Form_About : Form
    {
        public Form_About(string productName)
        {
            InitializeComponent();

            this.Text = "About " + productName;

            labelVersion.Text = productName + " " + Assembly.GetExecutingAssembly().GetName().Version;

            if ( CoreGlobals.betaCopy )
            {
               labelTrialVersion.Visible = true;
               labelTrialVersion.Text    = "Community Technology Preview";
            }
            else if ( CoreGlobals.trialCopy )
            {
               labelTrialVersion.Visible = true;
               labelTrialVersion.Text    = "Trial Version";
            }
         }

       private void buttonClose_Click( object sender, EventArgs e )
       {

       }
    }
}