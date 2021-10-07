using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeployLX.Licensing.v5;

namespace Idera.SqlAdminToolset.Core.LicenseViews.Panels
{
    public partial class ActivationInformationPanel : ActivationInfoPanel
    {


        public ActivationInformationPanel(ActivationLimit limit, bool showRequirementsNotice) : base(limit, showRequirementsNotice)
        {
            InitializeComponent();
        }

        protected override void InitializePanel()
        {
            base.InitializePanel();

            SidePanel.Controls.Add(new SupportPanel(SidePanel));


        }

    }
}
