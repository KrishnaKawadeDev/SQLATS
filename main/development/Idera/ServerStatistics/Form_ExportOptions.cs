using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.ServerStatistics
{
    public partial class Form_ExportOptions : Form
    {
        /// <summary>
        /// List of servers that should be exported.
        /// </summary>
        public List<string> SelectedServers
        {
            get
            {
                List<String> _List = new List<string>();
                foreach (Object _CheckedItem in listServers.CheckedItems)
                {
                    _List.Add(_CheckedItem.ToString());
                }
                return _List;
            }
        }

        /// <summary>
        /// True if all server data should be exported, otherwise false.
        /// </summary>
        public bool RetrieveAllData
        {
            get
            {
                return radioExportAll.Checked;
            }
        }

        public Form_ExportOptions(string commandName, List<string> availableServers)
        {
            InitializeComponent();
            this.Text = string.Format(this.Text, commandName);
            labelTitle.Text = string.Format(labelTitle.Text, commandName);
            radioExportLoaded.Text = string.Format(radioExportLoaded.Text, commandName);
            radioExportAll.Text = string.Format(radioExportAll.Text, commandName);
            foreach (string _Server in availableServers)
            {
                listServers.Items.Add(_Server);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (listServers.CheckedItems.Count == 0)
            {
                Messaging.ShowWarning(ProductConstants.ExportNoServersSelected);
                return;
            }
            if (!radioExportAll.Checked && !radioExportLoaded.Checked)
            {
                Messaging.ShowWarning(ProductConstants.ExportNoOptionSelected);
                return;
            }
            if (radioExportAll.Checked && Messaging.ShowConfirmation(ProductConstants.RefreshDataWarning) == DialogResult.No)
            {
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void linkSelectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < listServers.Items.Count; i++)
            {
                listServers.SetItemChecked(i, true);
            }
        }

        private void linkClearAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < listServers.Items.Count; i++)
            {
                listServers.SetItemChecked(i, false);
            }
        }

        private void pictureHelp_Click(object sender, EventArgs e)
        {
            superTooltip1.SetSuperTooltip(this.pictureHelp, new DevComponents.DotNetBar.SuperTooltipInfo("Options", string.Empty, ProductConstants.RefreshDataHelp, null, null, DevComponents.DotNetBar.eTooltipColor.BlueMist));
            superTooltip1.ShowTooltip(pictureHelp);
        }
    }
}