using DeployLX.Licensing.v5;

namespace Idera.SqlAdminToolset.Core.LicenseViews.Panels
{
    public partial class ActivateManually : ActivateManuallyPanel
    {
        public ActivateManually(ActivationLimit limit) : base(limit)
        {
        }

        protected override void InitializePanel()
        {
         base.InitializePanel();
            SuperForm.Text = "Idera SQL Admin Toolset: Activate";
            SidePanel.Controls.Add(new SupportPanel(SidePanel));
        }

        protected override void LoadPanel(SecureLicenseContext context)
        {
            base.LoadPanel(context);
           
           
        }

        protected override void PanelShown(bool safeToChange)
        {
            base.PanelShown(safeToChange);
        }

        protected override void HandleEula()
        {
            base.HandleEula();
        }
    }
}
