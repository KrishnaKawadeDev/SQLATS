using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IderaTrialExperienceCommon.Common;

namespace IderaTrialExperienceCommon.Dialogs
{
    public partial class ManageLicenseDialog : Form
    {

        public delegate void Action();
        private readonly Action _registerBtnAction;
        private readonly Action _extendBtnAction;
        private readonly Action _deactivateBtnAction;
        public ManageLicenseDialog()
        {

        }
        public ManageLicenseDialog(LicenseInformation licenseInfo, Action registerAction,
            Action extendAction, Action deactivateAction)
        {
            _registerBtnAction = registerAction;
            _extendBtnAction = extendAction;
            _deactivateBtnAction = deactivateAction;
            InitializeComponent();

            if (ParentForm != null)
            {
                MessageBox.Show(ParentForm.Text);
            }

            if (licenseInfo != null)
            {
                if ((licenseInfo.IsTrial && licenseInfo.IsActivated) ||
                                                      (licenseInfo.IsTrial && !licenseInfo.IsActivated))
                {
                    this.tableLayoutPanel1.ColumnStyles[3].SizeType = SizeType.Absolute;
                    this.tableLayoutPanel1.ColumnStyles[3].Width = 0;
                }
                //if (
                //    !((!licenseInfo.IsTrial && licenseInfo.IsActivated) ||
                //      (!licenseInfo.IsTrial && !licenseInfo.IsActivated)))
                //{
                //    this.tableLayoutPanel1.Controls.Add(this.limitCodeValueLabel, 3, 1);
                //    this.tableLayoutPanel1.Controls.Add(this.label8, 3, 0);
                //}
                this.lblLicenseStatus.Text = this.GetStatus(licenseInfo);
                this.lblLicenseKey.Text = licenseInfo.SerialNumber ?? string.Empty;
                this.lblLicenseType.Text = licenseInfo.LicenseType;
                this.lblLimitCode.Text = licenseInfo.LimitCode;
               
                this.extendBtn.Visible = ((licenseInfo.IsTrial && licenseInfo.IsActivated && !licenseInfo.IsExpired)
                                          || (licenseInfo.IsExpired));
               
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(lblLicenseKey.Text))
                Clipboard.SetText(this.lblLicenseKey.Text);
        }

        public string BuyNowUrl { get; set; }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            _registerBtnAction();
        }

        private void extendBtn_Click(object sender, EventArgs e)
        {
            _extendBtnAction();
        }

        private void deactivateBtn_Click(object sender, EventArgs e)
        {
            _deactivateBtnAction();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:" + "support@idera.com");
        }

        private void linkLabel1_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(BuyNowUrl);
        }

        private string GetStatus(LicenseInformation licenseInfo)
        {
            if (licenseInfo.IsActivated) return "Activated";
            return "Deactivated";
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:" + "licensing@idera.com");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
