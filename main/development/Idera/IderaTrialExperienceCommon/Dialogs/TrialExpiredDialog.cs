using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IderaTrialExperienceCommon.Properties;
using IderaTrialExperienceCommon.Common;

namespace IderaTitleBarControls.Dialogs
{
    public partial class TrialExpiredDialog : Form
    {
      
        public TrialExpiredDialog()
        {
            InitializeComponent();
          //  this.Text = ""+ LicenseInformation.LicenseTypeName +" Period has expired";
        }


        public EventHandler ActivateLicenseClick;

        public void OnActivateLicenseClick(EventArgs e)
        {
            EventHandler handler = ActivateLicenseClick;
            if (handler != null)
                ActivateLicenseClick(this, e);

        }
        private const string DaysToExpireMsg = @"The Trial Key will expire in {0} {1}";

        private static bool dialogWasAlreadyShowed = false;
        private string applicationName;
        private static bool dialogIsVisibleNow = false;
        private bool isTrial;
        public TrialExpiredDialog(string onlineStoreUrl, string trialCenterHomepageUrl, string applicationName,  int daysLeft,bool istrial) : this()
        {
            this.onlineStoreUrl = onlineStoreUrl;
            this.trialCenterHomepageUrl = trialCenterHomepageUrl;
            this.daysLeft = daysLeft;

            this.applicationName = applicationName;
            isTrial = istrial;
       


        }

        public  DialogResult ShowDialog()
        {

            if (dialogIsVisibleNow) return DialogResult.Ignore;
            if (daysLeft > 0 && daysLeft <= 7)
            {
                if (!dialogWasAlreadyShowed)
                {
                    dialogWasAlreadyShowed = true;
                    this.lblTitle.Text = FormatMessageText(daysLeft);
                    btnClose.Text = Resources.TrialExpiredDialog_ContinueToTrial_ButtonText;
                    this.Text = this.lblTitle.Text;
                    dialogIsVisibleNow = true;
                    return base.ShowDialog();
                }
                return DialogResult.OK;
            }
            this.lblTitle.Text = Resources.TrialExpiredDialog_ExpiredTrialText ;
            this.Text = this.lblTitle.Text;
            this.btnClose.Text = Resources.TrialExpiredDialog_CloseButtonText;
            dialogIsVisibleNow = true;
            if (!isTrial)
            {
                lblTitle.Text = "Production License has expired";
                this.Text = this.lblTitle.Text;
                this.label4.Visible = false;
                this.llTrialCenter.Visible = false;
            }
            return base.ShowDialog();
        }

        private string FormatMessageText(int daysLeft)
        {
            return string.Format(DaysToExpireMsg, daysLeft, daysLeft == 1 ? "day" : "days");
        }

        private string onlineStoreUrl;

        private string trialCenterHomepageUrl;

        

        private int daysLeft;

        private void llOnlineStore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.onlineStoreUrl))
                InternetConnection.OpenWebPage(this.onlineStoreUrl, applicationName);
            this.Close();
        }

        private void llRegisterKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnActivateLicenseClick(e);
            this.Close();
        }

        private void llTrialCenter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.trialCenterHomepageUrl))
                InternetConnection.OpenWebPage(this.trialCenterHomepageUrl, applicationName);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrialExpiredDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            dialogIsVisibleNow = false;
        }
    }
}
