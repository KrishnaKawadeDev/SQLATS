using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DeployLX.Licensing.v5;

namespace Idera.SqlAdminToolset.Core.LicenseViews.Panels
{
    public partial class DeactivationPanel : DeployLX.Licensing.v5.DeactivationPanel
    {


        public DeactivationPanel(ActivationLimit limit) : base(limit)
        {
            
        }

        protected override void LoadPanel(SecureLicenseContext context)
        {
            base.LoadPanel(context);

        }

        protected override void InitializePanel()
        {
            base.InitializePanel();

            SidePanel.Controls.Add(new SupportPanel(SidePanel));

            this.ClearBottomControls();
            
            Button button1 = this.AddBottomButton("Cancel", 30);
            button1.Click += CancelDeactivation;
            ((SuperFormPanel)this).SuperForm.CancelButton = (IButtonControl)button1;
            Button button2 = this.AddBottomButton("Deactivate");
            button2.Click += new EventHandler(DeactivateLicense);
            ((SuperFormPanel)this).SuperForm.AcceptButton = (IButtonControl)button2;
            this.AddBottomLabel("Tell me more about activation", "", Images.Notice_png).Click += new EventHandler(TellMeMoreClickHandler);
            if (this.Limit.License.EulaAddress == null)
                return;
            this.AddBottomLabel("License Support", "", Images.License_png).Click += new EventHandler(EulaClickHandler);


        }

        private void EulaClickHandler(object sender, EventArgs e)
        {
            HandleEula();
        }

        private void TellMeMoreClickHandler(object sender, EventArgs e)
        {
            if (Limit is ActivationLimit)
            {
                var activationInfoPanel = new ActivationInformationPanel((ActivationLimit)this.Limit, true);
                ShowPanel(activationInfoPanel, null);
            }
        }

        private void DeactivateLicense(object sender, EventArgs e)
        {
            var message =
                string.Format(
                    "Are you sure you want to deactivate {0} from this machine& You will no longer be able to use it on this machine.",
                    this.SuperForm.Context.SupportInfo.Product);
            if (this.ShowMessageBox(message, "Validation notice", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;
            this.ShowPanel((SuperFormPanel)new DoDeactivation(this.Limit as ActivationLimit), new PanelResultHandler(DeactivationResultHandler), true);
        }

        private void DeactivationResultHandler(FormResult result)
        {
            Return(result);
        }

        private void CancelDeactivation(object sender, EventArgs e)
        {
          Return(FormResult.Failure);
        }

    }
}
