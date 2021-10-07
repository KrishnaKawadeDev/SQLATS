#region SQL admin toolset © 2007, 2012 Idera, Inc. and Idera.

/* 
 * Idera reserves all rights in the program and source code as delivered.  The program 
 * or any portion thereof may not be reproduced or reverse engineered in any form 
 * whatsoever without the written consent of Idera.  
 * 
 * A license to the software does not constitute authorization.
 */

#endregion

#region Using Directives

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using Idera.SqlAdminToolset.Core;

#endregion

namespace Idera.SqlAdminToolset.Core
{
    public partial class Form_ManageLicense : Form
    {
        private static Color warningColor = Color.OrangeRed;
        private static Color errorColor = Color.Red;

        #region Fields

        public string            licenseKey     = "";
        public BBSProductLicense BBSLicense     = null;
        public bool              licenseChanged = false;

        #endregion

        #region CTOR

        public Form_ManageLicense()
        {
            InitializeComponent();

            licenseKey = BBSProductLicense.ReadProductLicense();
            textLicenseKey.Text = licenseKey;

            BBSLicense = new BBSProductLicense(Assembly.GetExecutingAssembly().GetName().Version,
                                               licenseKey  );
            LoadLicenseInformation();

            button_OK.Focus();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            button_OK.Focus();
        }

        #endregion

        #region Helpers

        private void LoadLicenseInformation()
        {
            textBox_DaysToExpire.Text =
            textBox_LicenseExpiration.Text =
            textBox_LicenseType.Text = string.Empty;

            pictureStatus.Visible = false;
            labelStatus.Visible = false;

            if ( BBSLicense == null ) return;

            try
            {
                textBox_LicenseType.Text = BBSLicense.licenseData.typeStr;
                if ( BBSLicense.licenseData.isTrial && CoreGlobals.betaCopy )
                {
                   textBox_LicenseType.Text = "Community Technology Preview License";
                }

                textBox_LicenseExpiration.Text = BBSLicense.licenseData.expirationDateStr;
                textBox_DaysToExpire.Text = BBSLicense.licenseData.daysToExpireStr;

                if (BBSLicense.licenseData.licState != BBSProductLicense.LicenseState.Valid)
                {
                    textBox_LicenseType.ForeColor = errorColor;
                    textBox_LicenseType.BackColor = textLicenseKey.BackColor;
                }
                else
                {
                    textBox_LicenseType.ForeColor = SystemColors.ControlText;
                    textBox_LicenseType.BackColor = textLicenseKey.BackColor;
                }

                if (BBSLicense.licenseData.isAboutToExpire)
                {
                    textBox_DaysToExpire.ForeColor = warningColor;
                    textBox_LicenseExpiration.ForeColor = warningColor;
                    textBox_DaysToExpire.BackColor = textLicenseKey.BackColor;
                    textBox_LicenseExpiration.BackColor = textLicenseKey.BackColor;

                    if (BBSLicense.licenseData.daysToExpire > 0)
                    {
                       pictureStatus.Image = global::Idera.SqlAdminToolset.Core.Properties.Resources._32_SystemError;
                       this.labelStatus.Text = "The license period granted by this key will expire soon.";
                    }
                    else
                    {
                       pictureStatus.Image = global::Idera.SqlAdminToolset.Core.Properties.Resources._32_SystemWarn;
                       this.labelStatus.Text = "The license period granted by this key has expired.";
                    }
                    pictureStatus.Visible = true;
                    this.labelStatus.Visible = true;
                }
                else
                {
                    textBox_DaysToExpire.ForeColor = SystemColors.ControlText;
                    textBox_LicenseExpiration.ForeColor = SystemColors.ControlText;
                }
            }
            catch {}
        }

        #endregion

        #region Events

        private void button_OK_Click(object sender, EventArgs e)
        {
            if ( licenseChanged )
            {
               BBSProductLicense.WriteProductLicense(licenseKey);
            }

            DialogResult = DialogResult.OK;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            Form_AddLicense AddLicenseForm = new Form_AddLicense();
            DialogResult choice = AddLicenseForm.ShowDialog();
            if (choice == DialogResult.OK)
            {
               if ( licenseKey != AddLicenseForm.licenseKey )
               {
                   //mark license as changed
                   licenseChanged = true;
                   licenseKey = AddLicenseForm.licenseKey;

                   // update screen
                   textLicenseKey.Text = licenseKey;
                   BBSLicense = new BBSProductLicense(Assembly.GetExecutingAssembly().GetName().Version,
                                                      licenseKey);
                   LoadLicenseInformation();
                }
            }
        }

        #endregion

       private void Form_ManageLicense_HelpRequested( object sender, HelpEventArgs hlpevent )
       {
         HelpMenu.ShowHelp( DisplayHelp.LICENSE );

       }
    }
}