using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core;
using Microsoft.SqlServer.Management.Smo;

namespace Idera.SqlAdminToolset.UserClone
{
    public partial class Form_LoginList : Form
    {
        public Form_LoginList(List<string> logins)
        {
            InitializeComponent();
           
            foreach (string _Login in logins)
            {
                listLogins.Items.Add(_Login);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (listLogins.SelectedItem == null)
            {
                Messaging.ShowError("You must select a login");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Gets the selected login.
        /// </summary>
        public string SelectedLogin
        {
            get
            {
                if (listLogins.SelectedItem == null)
                {
                    return null;
                }
                else
                {
                    return listLogins.SelectedItem.ToString();
                }
            }
        }
        /// <summary>
        /// Gets multiple selected login.
        /// </summary>
        public string SelectedMultipleLogins
        {
            get
            {
                if (listLogins.SelectedItems.Count == 0)
                    return null;
                else
                {
                    string login = listLogins.SelectedItems[0].ToString();
                   
                    for (int i = 1; i < listLogins.SelectedItems.Count; i++)
                    {
                        login += ";" + listLogins.SelectedItems[i].ToString();
                    }

                    return login;
                }
            }
        }
    }
}