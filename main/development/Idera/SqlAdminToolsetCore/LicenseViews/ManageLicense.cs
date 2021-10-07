using System;
using System.Diagnostics;
using System.Windows.Forms;
using DeployLX.Licensing.v5;

namespace Idera.SqlAdminToolset.Core.LicenseViews
{

    public partial class ManageLicense : Form
    {
        private SecureLicenseContext _licenseContext;
        private SecureLicense _license;
        public delegate void LicenseHelpEventHandler(object sender, ValidationHelpEventArgs validationHelpEventArgs);
        public event LicenseHelpEventHandler LicenseHelp;

        const string BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm_content=bn&utm_campaign=buynow";

        private SecureLicenseContext LicenseContext
        {
            get { return SecureLicenseContext.CreateResolveContext(_license); }
         
        }


        public Type LicensedType
        {
            get; set;
        }


       

        public ManageLicense(SecureLicense license, Type licensedType) : this()
        {
            
            LicensedType = licensedType;
            _license = license;

        }

        


        public ManageLicense()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeInterface();
        }

        private void InitializeInterface()
        {
            this.deactivateBtn.Visible = _license.IsActivated;



            this.lblLicenseKey.Text = _license.SerialNumber;
            this.lblLicenseType.Text = GetLicenseType();
            this.lblLicenseStatus.Text = GetLicenseStatus();
            SetSupportEmail(_license.IsTrial);

        }



        private void SetSupportEmail(bool isTrial)
        {
            this.label3.Text = isTrial ? "Sales:" : "Support: ";
            this.linkLabel2.Text = isTrial ? "sales@idera.com" : "support@idera.com";
        }

      
       

        private string GetLicenseStatus()
        {

            if (_license.IsTrial)
            {
                var timeMonitor = _license.GetTimeMonitor();
                if (timeMonitor != null)
                {
                    var daysToExp = (int) decimal.Ceiling((decimal) timeMonitor.TimeRemaining.TotalDays);
                    if (daysToExp == 0) return "EXPIRED";
                }
            }
            if (!_license.IsActivation && !_license.IsActivated)
                return "UNACTIVATED";
            if (_license.IsActivation) return "REGISTERED";
            return "ACTIVATED";
        }

        private string GetLicenseType()
        {
            
            if (_license.IsUnlocked) return "STANDARD";
            return "TRIAL";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblLicenseKey.Text))
                Clipboard.SetText(this.lblLicenseKey.Text);
        }



        private void closeBtn_Click(object sender, EventArgs e)
        {
            CloseForm(DialogResult.Cancel);
        }







        private void deactivateBtn_Click(object sender, EventArgs e)
        {
            var serialKey = _license.SerialNumber;
            var deactivationCodes = DeactivateLicense();
            if (deactivationCodes.Length > 0)
            {
                this.Hide();
                var deactivationForm = new DeactivationConfirmationForm(serialKey, string.Join(",", deactivationCodes));
                deactivationForm.LicenseHelp += ShowHelp;
                deactivationForm.ShowDialog();

            }
            else
            {
                MessageBox.Show(string.Format("License was deactivated locally, but server server deactivation failed. ", string.Join(",", deactivationCodes)), "License deactivated", MessageBoxButtons.OK,
              MessageBoxIcon.Information);
            }
            DeactivateLicense(); //retry deactivation
            this.Close();
            Application.Exit();
            DialogResult = DialogResult.OK;
        }

        private void ShowHelp(object sender, ValidationHelpEventArgs hlpevent)
        {
            try
            {
                if (null != LicenseHelp)
                {
                    LicenseHelp(sender, hlpevent);
                    return;
                }
                using (Process.Start("http://www.idera.com/help/sqlvdb/2-1/web/default.htm")) { };
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Opening page in your default browser failed. \nPlease Make shure you have installed any browser and it is registered as default application to opening weba pages.",
                    "License Deactivation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        private string[] DeactivateLicense()
        {
            string[] deactivationCodes = new string[] { };
            bool result;
            try
            {
                var requestInfo = LicenseContext.RequestInfo;
                requestInfo.DontShowForms = true;


                result = SecureLicenseManager.Deactivate(_license, null, LicensedType, requestInfo,
                   out deactivationCodes);
                _license.ClearSerialNumbersAndActivationData(true);
                _license.LicenseFile.Delete(true, true);
                RevalidateLicense();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(Application.ProductName, string.Format("Method: {0} Error:{1} \n StackTrace: {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace), EventLogEntryType.Error);
                //ignore now
            }
            return deactivationCodes;

        }



        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_license.IsTrial)
            {
                GoToEmail("mailto:" + "sales@idera.com");
            }
            else
            {
                GoToEmail("mailto:" + "support@idera.com");
            }
        }

        private void GoToEmail(string mailto)
        {
            try
            {
                Process.Start(mailto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Email application can not be opened.", "Sending Email", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
            }
        }
        private void linkLabel1_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(BuyNowUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Your default browser can not be opened.", "SQL Admin Toolset", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GoToEmail("mailto:" + "licensing@idera.com");
        }





        private void RevalidateLicense()
        {
            RevalidateLicense(false);
        }
        private void RevalidateLicense(bool showForm)
        {

            if (LicenseContext == null)
            {
                MessageBox.Show("License context is empty", "Revalidation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LicenseContext.RequestInfo.ShouldGetNewSerialNumber = false;

            var requestInfo = LicenseContext.RequestInfo;

            if (requestInfo != null)
            {
                requestInfo.DontShowForms = !showForm;
                requestInfo.DisableCache = true;

            }
            try
            {
                _license = SecureLicenseManager.Validate(null, LicensedType, requestInfo);
                
                
            }
            catch (Exception ex)
            {
                // ignored
                EventLog.WriteEntry(Application.ProductName, string.Format("Method: {0} Error:{1} \n StackTrace: {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace), EventLogEntryType.Error);
            }
        }



        private void CloseForm(DialogResult dialogResult)
        {
            this.Close();
            DialogResult = dialogResult;
        }




    }
}
