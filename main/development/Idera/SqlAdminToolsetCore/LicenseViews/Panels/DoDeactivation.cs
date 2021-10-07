using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using DeployLX.Licensing.v5;

namespace Idera.SqlAdminToolset.Core.LicenseViews.Panels
{
    public partial class DoDeactivation : DoDeactivationPanel
    {
        public DoDeactivation(ActivationLimit limit) : base(limit)
        {

        }

        private AsyncValidationRequest deactivationRes;
        private DeactivationPhase deactivationPhase;
        private string _serialNumber = "";
        protected override void PanelShown(bool safeToChange)
        {
            try
            {
                //  base.PanelShown(safeToChange);
                Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
                if (!FirstInitialization || !safeToChange) return;
                if (!string.IsNullOrEmpty(SuperForm.Context.ValidatingLicense.SerialNumber))
                    _serialNumber = SuperForm.Context.ValidatingLicense.SerialNumber;
                ActivationLimit activationLimit = Limit as ActivationLimit;
                if (!activationLimit.HasActivated || !activationLimit.CanDeactivate)
                {
                    Return(FormResult.Failure);
                }
                else
                {
                    lock (this)
                    {
                        deactivationPhase = DeactivationPhase.CheckPermission;
                        deactivationRes = activationLimit.DeactivateAsync(SuperForm.Context, true, DeactivationPhase.CheckPermission, DeactivationResultHandler);
                    }
                }
            }
            catch (Exception ex)
            {
                if (!CommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName, string.Format("Method: {0} Error:{1} \n StackTrace: {2}", MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace), EventLogEntryType.Error);
                }
            }
        }

        private void DeactivationResultHandler(object sender, EventArgs e)
        {
            try
            {
                var deactivationResult = deactivationRes.GetResult();
                if (deactivationResult != ValidationResult.Valid)
                    Invoke(new MethodInvoker(DeactivationFailedHandler));
                else if (deactivationPhase == DeactivationPhase.CheckPermission)
                {
                    deactivationPhase = DeactivationPhase.Commit;
                    deactivationRes = ((ActivationLimit)Limit).DeactivateAsync(SuperForm.Context, true, deactivationPhase, DeactivationResultHandler);
                }
                else
                    Invoke(new MethodInvoker(PreProcessDeactivation));
            }
            catch (Exception ex)
            {
                if (!CommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName, string.Format("Method: {0} Error:{1} \n StackTrace: {2}", MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace), EventLogEntryType.Error);
                }
            }
        }

        private void PreProcessDeactivation()
        {
            try
            {
                Controls["_completePanel"].Top = (Parent.Height - Controls["_completePanel"].Height) / 2;
                ProcessDeactivation(Limit as ActivationLimit);
                ShowControlsWithEffects(TriBoolValue.Default,  Controls["_completePanel"]);
                ClearBottomControls();
                Button button = AddBottomButton("Ok");
                button.Click += OkButtonClick;
                SuperForm.AcceptButton = button;
                button.Select();

                var copyToClp = AddBottomButton("Copy to Clipboard");
                    copyToClp.Click += CopyToClipboardClick;
                copyToClp.Width = 150;
                copyToClp.Left -= 55;
            }
            catch (Exception ex)
            {
                if (!CommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName, string.Format("Method: {0} Error:{1} \n StackTrace: {2}", MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace), EventLogEntryType.Error);
                }
            }
        }

        private void CopyToClipboardClick(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(SuperForm.Context.MakeDeactivationConfirmationCode(Limit as ActivationLimit));
                stringBuilder.AppendLine(SuperForm.Context.ValidatingLicense.SerialNumber);
                Clipboard.SetData(DataFormats.Text, stringBuilder.ToString());
                var message =
                    @"The details have been copied to the clipboard. You can now paste them into an email or into you favorite word processing software for printing";
                int num = (int)ShowMessageBox(message, "Details Copied", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBoxEx.ShowException(ex);
            }
        }



        private void OkButtonClick(object sender, EventArgs e)
        {
            Return(FormResult.Success);
        }

        private void ProcessDeactivation(ActivationLimit activationLimit)
        {
            try
            {
                foreach (Control control in (ArrangedElementCollection)Controls["_completePanel"].Controls)
                {
                    if (control.Tag as Limit == activationLimit)
                        return;
                }
                
                int y = Controls["_completePanel"].Height - 60;
                string str = SuperForm.Context.MakeDeactivationConfirmationCode(activationLimit);
                string serialNumberString =
                    string.Format("You can use your current key on a different machine. \ncurrent Key: {0}",
                        SuperForm.Context.ValidatingLicense.SerialNumber);
                ShadowLabel shadowLabel = new ShadowLabel();
                shadowLabel.Font = new Font(SuperForm.Font.FontFamily.Name, 12f, FontStyle.Regular);
                shadowLabel.SetBounds(16, y, 433, 21);
                shadowLabel.BackColor = Color.Transparent;
                shadowLabel.Text = str;
                shadowLabel.TextAlign = ContentAlignment.MiddleCenter;
                shadowLabel.Tag = activationLimit;
                Controls["_completePanel"].Controls.Add(shadowLabel);
                Controls["_completePanel"].Height += 62;


                ShadowLabel serialNumber = new ShadowLabel
                {

                    BackColor = Color.Transparent,
                    Text = serialNumberString,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Tag = activationLimit,
                    ForeColor = Color.Red,
                    Font = new Font(SuperForm.Font.FontFamily.Name, 12f, FontStyle.Regular)

                };
                serialNumber.SetBounds(16, y + 25, 433, 62);
                Controls["_completePanel"].Controls.Add(serialNumber);
            }
            catch (Exception ex)
            {
                if (!CommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName,
                    string.Format("Method: {0} Error:{1} \n StackTrace: {2}",
                        MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace),
                    EventLogEntryType.Error);
                }
            }
        }





        private void DeactivationFailedHandler()
        {

            this.Controls["_completePanel"].Controls["_completeNotice"].Text =
                    "Deactivation was not successfull. You may not be authorized to use the software on another machine. \nPlease contact Idera Support immediately.";
            ((PictureBox)(this.Controls["_completePanel"].Controls["_completeIcon"])).Image = Images.BigError7_png;
            Controls["_completePanel"].Top = (this.Parent.Height - Controls["_completePanel"].Height) / 2;
            ShowControlsWithEffects(TriBoolValue.Default, Controls["_deactivatingNotice"], Controls["_progressing"], Controls["_completePanel"]);
            this.ClearBottomControls();
            this.AddBottomButton("Close").Click += new EventHandler(CloseClickHandler);
        }

        private void CloseClickHandler(object sender, EventArgs e)
        {
            this.Return(FormResult.Success);
        }
    }
}
