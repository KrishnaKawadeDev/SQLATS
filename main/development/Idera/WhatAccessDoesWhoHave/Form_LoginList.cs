using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core;
using Microsoft.SqlServer.Management.Smo;
using System.Collections;

namespace Idera.SqlAdminToolset.WhatAccessDoesWhoHave
{
    public partial class Form_LoginList : Form
    {
        public Form_LoginList(IList logins)
        {
            InitializeComponent();
            foreach (LoginObject _Login in logins)
            {
               if (!(_Login.name.StartsWith("#") && _Login.name.EndsWith("#")))
               {
                  listLogins.Items.Add(_Login.name);
               }
            }
            listLogins.Sorted = true;
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
    }
}