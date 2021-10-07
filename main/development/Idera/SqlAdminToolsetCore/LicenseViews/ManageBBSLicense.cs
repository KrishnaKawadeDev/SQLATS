using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Core.LicenseViews
{
    public partial class ManageBBSLicense : Form
    {
        
        const string BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm_content=bn&utm_campaign=buynow";
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public ManageBBSLicense()
        {
            InitializeComponent();
            this.Load += ManageBBSLicense_Load;

             this.label2.Text = "When requesting new keys for this installation, specify " + Environment.MachineName.Trim() + " as the license scope.";

        }

        private void ManageBBSLicense_Load(object sender, EventArgs e)
        {
            var lic = CoreGlobals.License;
            dataGridView1.Rows.Add(lic.LicenseType, lic.Expiration, BBSProductLicense.Status == BBSProductLicense.LicenseState.Valid && !lic.IsExpired ? BBSProductLicense.LicenseState.Valid : BBSProductLicense.LicenseState.Expired, BBSProductLicense.licenseKey);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BBSProductLicense.AddLicenseKey(textBox1.Text.Trim());
            textBox1.Text = string.Empty;
            dataGridView1.Rows.Clear();
            var lic = CoreGlobals.License;
            dataGridView1.Rows.Add(lic.LicenseType, lic.Expiration, BBSProductLicense.Status==BBSProductLicense.LicenseState.Valid? BBSProductLicense.LicenseState.Valid: BBSProductLicense.LicenseState.Expired, BBSProductLicense.licenseKey);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://idera.force.com/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://trialcenter.idera.com");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CoreGlobals.BBSLic.IsTrial)
            {
                GoToEmail("mailto:" + "sales@idera.com");
            }
            else
            {
                GoToEmail("mailto:" + "support@idera.com");
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GoToEmail("mailto:" + "licensing@idera.com");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(BuyNowUrl);
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

        private void closeWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode =
             DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
