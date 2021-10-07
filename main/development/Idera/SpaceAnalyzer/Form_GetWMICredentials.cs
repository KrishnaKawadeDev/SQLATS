using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Idera.SqlAdminToolset.Core;
using System.Management;

namespace Idera.SqlAdminToolset.SpaceAnalyzer
{
    public partial class Form_GetWMICredentials : Office2007Form
    {
        private string _server;

        public Form_GetWMICredentials(string server)
        {
            InitializeComponent();

            _server = server;

            TitleText = string.Format(ProductConstants.WMIDialogTitle, server);

            label_WMI_Instructions.Text = string.Format(ProductConstants.WmiErrorInstructions, server);

         }


        private void button_OK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            ProductConstants.globalWMIUser = textBox_User.Text;
            ProductConstants.globalWMIPassword = textBox_Password.Text;
        }

        private void button_TestWMIConnection_Click(object sender, EventArgs e)
        {
            StringBuilder scopeStr = null;
            scopeStr = new StringBuilder();
            scopeStr.Append(@"\\" + _server);
            scopeStr.Append(ProductConstants.Cimv2Root);
            // Create management scope and connect.
            ConnectionOptions options = new ConnectionOptions();
            if (_server != Environment.MachineName)
            {
                if (!string.IsNullOrEmpty(textBox_User.Text))
                {
                    options.Username = textBox_User.Text;
                    options.Password = textBox_Password.Text;
                }
            }
            ManagementScope scope = new ManagementScope(scopeStr.ToString(), options);
            try
            {
                scope.Connect();
                Messaging.ShowInformation(string.Format("Connection to WMI on {0} Succeded", _server));
            }
            catch (Exception ex)
            {
                Messaging.ShowException(string.Format("Connection to WMI on {0} Failed", _server), ex);
            }
        }
    }


}