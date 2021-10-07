using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DeployLX.Licensing.v5;

namespace Idera.SqlAdminToolset.Core.LicenseViews.Panels
{
    public class ActivatePanel: ActivationPanel
    {
        public ActivatePanel(ActivationLimit limit) : base(limit)
        {

        }

        protected override void HandleActivateOnline()
        {
            try
            {
                this.SuperForm.Context.Items["MachineName"] = BodyPanel.Controls["_registrationPanel"].Controls["_nicknameText"];
                var activationLimit = Limit as ActivationLimit;
                var activateOnlinePanel = new ActivateOnlinePanel(activationLimit);
                this.ShowPanel(activateOnlinePanel, new PanelResultHandler(ActivationResultHandler), false);

            }
            catch (Exception ex)
            {
                if (!CommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName, string.Format("Method: {0} Error:{1} \n StackTrace: {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace), EventLogEntryType.Error);
                }
                //ignore now
            }
        }

        private void ActivationResultHandler(FormResult result)
        {
            if(result!=FormResult.Incomplete)
            Return(result);
        }

     

        protected override void InitializePanel()
        {
            SidePanel.Controls.Remove(SidePanel.Controls["_extend"]);
            SidePanel.Controls.Remove(SidePanel.Controls["_statusPanel"]); 

            var closeButton = AddBottomButton("Close");
            closeButton.Click += HandleCloseForm;
            SuperForm.Text = "Idera SQL Admin Toolset: Activate";
            

            SidePanel.Controls.Add(new SupportPanel(SidePanel));


        }

    


        private void HandleCloseForm(object sender, EventArgs e)
        {
            if (SuperForm.Context.Items.Contains("Registered"))
                SuperForm.Context.Items.Remove("Registered");
            Return(FormResult.Closed);
        }


        protected override void LoadPanel(SecureLicenseContext context)
        {
            base.LoadPanel(context);

        }

        protected override void HandleNewSerial()
        {
            if (this.Limit == null || !this.Limit.License.CanUnlockBySerial)
                return;
            SecureLicenseContext context = this.SuperForm.Context;
            context.RequestInfo.ShouldGetNewSerialNumber = true;
            context.HasFormBeenShown = false;
            int num = (int)context.RetryWith(this.Limit.License.LicenseFile, (string)null);
            this.Return(FormResult.Retry);
        }


        protected override void HandleActivateManually()
        {
            try
            {
                this.SuperForm.Context.Items["MachineName"] =
                    BodyPanel.Controls["_registrationPanel"].Controls["_nicknameText"];

                var activationLimit = Limit as ActivationLimit;
                var activateManuallyPanel = new ActivateManually(activationLimit);
                this.ShowPanel(activateManuallyPanel, ManualActivationResultHandler, false);
            }
            catch (Exception ex)
            {
                //ignore now
                if (!CommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName, string.Format("Method: {0} Error:{1} \n StackTrace: {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace), EventLogEntryType.Error);
                }
            }
        }

        private void ManualActivationResultHandler(FormResult result)
        {
            switch (result)
            {
                case FormResult.Success:
                    this.Return(FormResult.Success);
                    break;
                case FormResult.Failure:
                    this.Return(FormResult.Failure);
                    break;
            }
        }

        protected override void HandleTellMeMore()
        {
            ActivationInformationPanel activationInfoPanel = new ActivationInformationPanel(Limit as ActivationLimit, true);
            ShowPanel(activationInfoPanel, null);
        }
    }
}
