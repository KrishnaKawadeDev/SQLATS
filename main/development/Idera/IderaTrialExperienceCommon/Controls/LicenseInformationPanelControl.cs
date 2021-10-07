using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Net;
using System.Text;
using System.Windows.Forms;
using IderaTrialExperienceCommon.Common;

namespace IderaTrialExperienceCommon.Controls
{
    public partial class LicenseInformationPanelControl : UserControl
    {
        private string _internetConnectionErrorMessage;
        private LicenseInformation _licenseInformation;
        public event EventHandler ActivateLicense;
        

        public LicenseInformationPanelControl()
        {
            InitializeComponent();
        }

        public LicenseInformationPanelControl(LicenseInformation licInfo) : this()
        {
            LicenseInformation = licInfo ?? new LicenseInformation();
            
        

        }

        public void ShowLicenseInformation(Form parentForm, Control parentContainer)
        {
            var licenseInfoString = new StringBuilder();
            if (LicenseInformation != null)
            {
                if(LicenseInformation.IsTrial)
                licenseInfoString.AppendLine(string.Format("Expires: {0}",
                    LicenseInformation.IsExpired
                        ? "Expired"
                        : string.Format("{0} {1}", LicenseInformation.DaysToExpire,
                            LicenseInformation.DaysToExpire == 1 ? "day" : "days")));

                licenseInfoString.AppendLine(string.Format("Type: {0}",
                    LicenseInformation.IsTrial ? "Trial" : LicenseInformation.LicenseType));

                if (!string.IsNullOrEmpty(LicenseInformation.SerialNumber))
                    licenseInfoString.AppendLine(string.Format("Key: {0}", LicenseInformation.SerialNumber));

                if (!string.IsNullOrEmpty(LicenseInformation.LimitCode))
                    licenseInfoString.AppendLine(string.Format("Limit Code: {0}", LicenseInformation.LimitCode));
            }

            lblContent.Text = licenseInfoString.ToString();
            if (parentForm != null)
            {
                this.Width = parentForm.Width;
                this.Height = parentForm.Height - parentContainer.Height;
                this.Top = parentContainer.Top + parentContainer.Height;
                this.Left = parentContainer.Left;
                this.Anchor = (AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom);
                parentForm.Controls.Add(this);
                this.BringToFront();
            }
        }

        public void CloseLicenseInformation()
        {
            if (ParentForm != null)
            {
                if (ParentForm.Controls.Contains(this))
                {
                    ParentForm.Controls.Remove(this);
                }
            }
        }

        private void GoToTheStore()
        {
            InternetConnection.OpenWebPage(ProductStoreUrl, IderaProductName);
        }
      

        public string ProductStoreUrl { get; set; }


        public LicenseInformation LicenseInformation
        {
            get { return _licenseInformation; }
            set
            {
                _licenseInformation = value;
                if (_licenseInformation != null)
                {
                    btnActivateLicense.Visible = _licenseInformation.IsTrial;
                    lblActivateLicense.Visible = _licenseInformation.IsTrial;
                }
            }
        }

        public string IderaProductName { get; set; }


        private void btnBuyNow_Click(object sender, EventArgs e)
        {
            GoToTheStore();
        }

        public virtual void OnActivateButtonClick(EventArgs e)
        {
            EventHandler handler = this.ActivateLicense;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void btnActivateLicense_Click(object sender, EventArgs e)
        {
            OnActivateButtonClick(e);

        }
    }
}
