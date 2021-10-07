using System;
using System.Diagnostics;
using System.Windows.Forms;
using DeployLX.Licensing.v5;

namespace Idera.SqlAdminToolset.Core.LicenseViews
{
    public partial class DeactivationConfirmationForm : Form
    {
        public string SerialKey { get; set; }
        public string DeactivationCode { get; set; }
        public delegate void LicenseHelpEventHandler(object sender, ValidationHelpEventArgs validationHelpEventArgs);
        public event LicenseHelpEventHandler LicenseHelp;
        public DeactivationConfirmationForm()
        {
            InitializeComponent();
        }

        public DeactivationConfirmationForm(string serialKey, string deactivationCode) : this()
        {
            SerialKey = serialKey;
            DeactivationCode = deactivationCode;
            this.Controls.Add(new SupportPanel(345));
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblLicenseKey.Text = SerialKey;
            lblDeactivationCode.Text = DeactivationCode;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(SerialKey) && !string.IsNullOrEmpty(DeactivationCode))
                Clipboard.SetText(string.Format("Serial Key: {0} \n Deactivation Confirmation Code: {1}", SerialKey,DeactivationCode));
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            try
            {
                if (null != LicenseHelp)
                {
                    LicenseHelp(sender, new ValidationHelpEventArgs());
                    return;
                }
                using (Process.Start("http://wiki.idera.com/display/SQLAdminToolset")) {} ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Opening page in your default browser failed. \nPlease Make shure you have installed any browser and it is registered as default application to opening weba pages.",
                    "License Deactivation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

     
    }
}
