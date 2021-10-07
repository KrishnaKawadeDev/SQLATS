using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DeployLX.Licensing.v5;
using DevComponents.DotNetBar;

namespace Idera.SqlAdminToolset.Core.LicenseViews.Panels
{
    public class RegisterPanel : RegistrationPanel
    {
        private AsyncValidationRequest registrationValidationRequest;
        private AsyncValidationRequest _asyncRequestResult;
        public RegisterPanel(RegistrationLimit limit) : base(limit)
        {
        }


        protected override void LoadPanel(SecureLicenseContext context)
        {

            base.LoadPanel(context);
            SuperForm.Text = "Idera SQL Admin Toolset: Register";

        }


        protected override void InitializePanel()
        {
            var nextButton = AddBottomButton("Next");
            nextButton.Click += NextButtonClickHandler;

            SidePanel.Controls.Add(new SupportPanel(SidePanel));


        }


        private void NextButtonClickHandler(object sender, EventArgs e)
        {
            DoRegister();
        }

        protected override void HandleRegister()
        {
            try
            {
                if (!ValidateForm())
                    return;
                LicenseValuesDictionary registrationInfo = this.GetRegistrationInfo();
                RegistrationLimit limit = this.Limit as RegistrationLimit;
                

                if (limit.FindTargetLicense(this.SuperForm.Context, BodyPanel.Controls["_registrationPanel"].Controls["_regControlsPanel"].Controls["serialNumber"].Text) == null)
                {
                    int num = (int)this.ShowMessageBox("License key not valid", (string)null, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    if (this.CheckUpgradeSerial(registrationInfo))
                        return;
                    if (((RegistrationLimit)this.Limit).Servers.Count == 0)
                    {
                        _asyncRequestResult = limit.RegisterAsync(((SuperFormPanel)this).SuperForm.Context, true,
                                                    registrationInfo, new EventHandler(RegistrationCompleteHandler));
                        

                        BodyPanel.Enabled = false;
                        this.Cursor = Cursors.WaitCursor;
                    }
                    else
                    {
                        this.ShowPanel((SuperFormPanel)new RegisterOnline(limit, registrationInfo),
                            new PanelResultHandler(OnlineRegistrationResultHandler));
                    }
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

        private void OnlineRegistrationResultHandler(FormResult result)
        {
            Return(result);
        }

        private void RegistrationCompleteHandler(object sender, EventArgs e)
        {
            ValidationResult registrationResult = _asyncRequestResult.GetResult();
            var checkBox = BodyPanel.Controls["_activateOption"] as CheckBox;
            if (checkBox != null && !checkBox.Checked)
            {
                if (!SuperForm.Context.Items.Contains("Registered"))
                {
                    SuperForm.Context.Items.Add("Registered", "true");
                }
              
            }

            switch (registrationResult)
            {
                    case ValidationResult.Valid:
                    Return(FormResult.Success);
                    break;
                    case ValidationResult.Retry:
                    Return(FormResult.Success);
                    break;
                    default:
                    Return(FormResult.Failure);
                    break;
           }
            
            
           
        }

        private bool DoRegister()
        {
            if (!this.ValidateForm()) return false;
            RegistrationLimit limit = this.Limit as RegistrationLimit;
            if (limit.FindTargetLicense(this.SuperForm.Context, BodyPanel.Controls["_registrationPanel"].Controls["_regControlsPanel"].Controls["serialNumber"].Text) == null)
            {
                int num = (int)this.ShowMessageBox("Entered license key is not valid", (string)null, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            try
            {
                HandleRegister();
            }
            catch (Exception ex)
            {
                //ignore
                if (!CommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName, string.Format("Method: {0} Error:{1} \n StackTrace: {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace), EventLogEntryType.Error);
                }
            }
            
            return true;


        }



    }
}
