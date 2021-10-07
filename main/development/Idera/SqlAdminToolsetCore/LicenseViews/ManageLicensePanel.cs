using System;
using System.Diagnostics;
using System.Windows.Forms;
using DeployLX.Licensing.v5;
using Idera.SqlAdminToolset.Core.LicenseViews.Panels;
using DeactivationPanel = Idera.SqlAdminToolset.Core.LicenseViews.Panels.DeactivationPanel;

namespace Idera.SqlAdminToolset.Core.LicenseViews
{

    public partial class ManageLicensePanel : SuperFormPanel
    {
        private bool revalidateOnExit = false;
        const string BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm_content=bn&utm_campaign=buynow";




        private Limit _limit;
        private bool _wasDeactivated;

        public Type LicensedType { get; private set; }

        public object Instance { get; private set; }


        public SecureLicense CurrentLicense
        {
            get { return SuperForm.Context.ValidatingLicense; }

        }

        public static string _LimitCode = "";
        public RegistrationLimit LicenseRegistrationLimit
        {
            get { return SuperForm.Context.ValidatingLicense.Limits.FindLimitByType(typeof(RegistrationLimit), true) as RegistrationLimit; }
        }

        public ActivationLimit CurrentActivationLimit
        {
            get { return SuperForm.Context.ValidatingLicense.Limits.FindLimitByType(typeof(ActivationLimit), true) as ActivationLimit; }
        }

        public IExtendableLimit LicenseExtendableLimit
        {
            get { return SuperForm.Context.ValidatingLicense.Limits.FindLimitByType(typeof(IExtendableLimit), true) as IExtendableLimit; }
        }

        public ManageLicensePanel(Limit limit) : base(limit)
        {
            InitializeComponent();
            if (ParentForm != null) ParentForm.Load += OnLoadForm;
        }

        private void OnLoadForm(object sender, EventArgs e)
        {
            if (SuperForm.Context.ValidatingLicense.IsActivated && SuperForm.Context.ValidatingLicense.IsActivation) Return(FormResult.Success);
            
        }


        public TimeLimit TimeLimit
        {
            get
            {
                var timeLimit = CurrentLicense.Limits.FindLimitByType(typeof(TimeLimit), true);
                return timeLimit as TimeLimit;
            }
        }


        protected override void InitializePanel()
        {
            InitializeInterface();
            SuperForm.Text = "Idera SQL Admin Toolset: Manage License";

        }


        protected override void FormActivated()
        {
            base.FormActivated();
        }

        protected override void LoadPanel(SecureLicenseContext context)
        {
            base.LoadPanel(context);
            InitializeInterface();

        }
        
        protected override void PanelShown(bool safeToChange)
        {
            try
            {
                base.PanelShown(safeToChange);
              
                if (safeToChange && LicenseActivationLimit != null && !SuperForm.Context.ValidatingLicense.IsActivated && SuperForm.Context.ValidatingLicense.IsActivation && SuperForm.Context.Items.Contains("Registered"))
                {
                    ShowActivationPanel();
                }
            }
            catch (Exception ex)
            {
                if (!CommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName, string.Format("Method: {0} Error:{1} \n StackTrace: {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace), EventLogEntryType.Error);
                }
            }
        }
        
        protected override void UpdateFromTheme()
        {
            base.UpdateFromTheme();
        }

        IExtendableLimit _LicenseExtendableLimit;
        private void InitializeInterface()
        {
            try
            {
                

                this.deactivateBtn.Visible = CurrentLicense.IsActivated && !_wasDeactivated;
                registerBtn.Visible = !CurrentLicense.IsActivated;
                if(registerBtn.Visible) registerBtn.Text = CurrentLicense.IsActivation ? "Activate" : "Register";
                this.extendBtn.Visible = !CurrentLicense.IsActivation;
                this.lblLicenseKey.Text = CurrentLicense.IsTrial ? "Trial Key" : CurrentLicense.SerialNumber;
              
                this.lblLicenseType.Text = GetLicenseType();
                this.lblLicenseStatus.Text = GetLicenseStatus();
                SetSupportEmail(CurrentLicense.IsTrial);
                if (CurrentLicense.IsTrial)
                {
                    ShowLimitCodeColumn(true);
                    if (SuperForm.Context != null && LicenseExtendableLimit != null && string.IsNullOrEmpty(_LimitCode))                     
                          _LimitCode=  SuperForm.Context.MakeExtensionLimitCode(LicenseExtendableLimit as IExtendableLimit);
                    this.lblLimitCode.Text = _LimitCode;
                  copyToClipboard.Enabled = !string.IsNullOrEmpty(lblLicenseKey.Text);
                }
                else
                {
                    ShowLimitCodeColumn(false);
                }
            }
            catch (Exception ex)
            {
                if (!CommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName, string.Format("Method: {0} Error:{1} \n StackTrace: {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace), EventLogEntryType.Error);
                }
            }

        }

        private void ShowLimitCodeColumn(bool show)
        {
            if (show)
            {
                LimitCodeColumn.Visible = true;
                KeyColumn.Width = 239; 
            }
            else
            {
                LimitCodeColumn.Visible = false;
                KeyColumn.Width = 344;
            }
        }

        private void SetSupportEmail(bool isTrial)
        {
            this.label3.Text = isTrial ? "Sales:" : "Support: ";
            this.linkLabel2.Text = isTrial ? "sales@idera.com" : "support@idera.com";
        }



        private string GetLicenseStatus()
        {

            if (CurrentLicense.IsTrial)
            {
                var timeMonitor = CurrentLicense.GetTimeMonitor();
                if (timeMonitor != null)
                {
                    var daysToExp = (int) decimal.Ceiling((decimal) timeMonitor.TimeRemaining.TotalDays);
                    if (daysToExp == 0) return "EXPIRED";
                    return "UNACTIVATED";
                }
               
            }
            if ((CurrentLicense.IsActivation && !CurrentLicense.IsActivated) || _wasDeactivated)
                return "UNACTIVATED";
            if (CurrentLicense.IsActivated) return "REGISTERED";
            return "ACTIVATED";
        }
        private string GetLicenseType()
        {
            if (CurrentLicense.IsUnlocked) return "STANDARD";
            if (CurrentLicense.IsActivated || CurrentLicense.IsActivation) return "DEACTIVATED";
            return "TRIAL";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblLicenseKey.Text))
                Clipboard.SetText(this.lblLicenseKey.Text);
        }



        private void closeBtn_Click(object sender, EventArgs e)
        {
            if (_wasDeactivated)
            {
                Application.Exit();
            }
            Return(FormResult.Success);
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {


            RegisterOrActivateLicense();

        }

        private void RegisterOrActivateLicense()
        {
            if (LicenseRegistrationLimit != null)
            {
                ShowRegistrationPanel();
            }
            else if (CurrentActivationLimit != null)
            {
                ShowActivationPanel();

            }
        }

        private void ShowActivationPanel()
        {
            try
            {
                var activationPanel = new ActivatePanel(LicenseActivationLimit);
                ShowPanel(activationPanel, ActivationResultHandler, false);

            }
            catch (Exception ex)
            {
                if (!CommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName, string.Format("Method: {0} Error:{1} \n StackTrace: {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace), EventLogEntryType.Error);
                }
            }

        }

        private void ShowRegistrationPanel()
        {
            try
            {
                var regPanel = new RegisterPanel(LicenseRegistrationLimit);
                ShowPanel(regPanel, RegistrationResultHandler, false);
            }
            catch (Exception ex)
            {
                if (!CommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName, string.Format("Method: {0} Error:{1} \n StackTrace: {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace), EventLogEntryType.Error);
                }
            }
        }

        private void ActivationResultHandler(FormResult result)
        {
        }

        private void RegistrationResultHandler(FormResult result)
        {
            switch (result)
            {
                case FormResult.Retry:
                    if(LicenseActivationLimit!=null) ShowActivationPanel();
                    else return;
                    break;
                case FormResult.Success:
                case FormResult.Failure:
                    Return(result);
                    break;
            }
        }

        public ActivationLimit LicenseActivationLimit
        {
            get { return SuperForm.Context.ValidatingLicense.Limits.FindLimitByType(typeof(ActivationLimit), true) as ActivationLimit; }

        }

        private void extendBtn_Click(object sender, EventArgs e)
        {
            var extendResult = ExtendLicense();

        }

        private FormResult ExtendLicense()
        {
            var extendPanel = new ExtendPanel(false, (Limit)LicenseExtendableLimit);
            ShowPanel(extendPanel, ExtensionResultHandler, false);

            return FormResult.Success;
        }

        private void ExtensionResultHandler(FormResult result)
        {
            switch (result)
            {
                case FormResult.Success:
                case FormResult.Failure:
                    Return(result);
                    break;
            }
        }

        private void deactivateBtn_Click(object sender, EventArgs e)
        {
            DeactivateLicense();
           

        }

        private void DeactivateLicense()
        {
            if (LicenseActivationLimit != null)
            {
                var deactivationPanel = new DeactivationPanel(LicenseActivationLimit);
                ShowPanel(deactivationPanel, DeactivationResultHandler, false);
               
            }
            
            
        }

        private void DeactivationResultHandler(FormResult result)
        {
            if (result == FormResult.Success)
            {
                SuperForm.Context.ValidatingLicense.ClearSerialNumbersAndActivationData(true);
                SuperForm.Context.ValidatingLicense.LicenseFile.Delete(true, true);
                _wasDeactivated = true;
            }
            
           
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentLicense.IsTrial)
            {
                GoToEmail("mailto:" + "sales@idera.com");
            }
            else
            {
                GoToEmail("mailto:" + "support@idera.com");
            }
        }

        private void linkLabel1_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(BuyNowUrl);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GoToEmail("mailto:" + "licensing@idera.com");
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



        private void ManageLicensePanel_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
