using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Core.LicenseViews
{
    public partial class SupportPanel : UserControl
    {
        private readonly int _parrentHeigh;

        private Timer timer;
        private Control ParentControl;
        public SupportPanel()
        {
            InitializeComponent();
            
            if (ParentControl == null)
            {
                this.Width = 150;
                this.Height = 25;
            }
        }

        public SupportPanel(Control parent, string title, string email) : this(parent)
        {
            this.lblHeader.Text = title;
            this.linkEmail.Text = email;
            
        }

        public SupportPanel(Control parent, string title, string email, string subject) : this(parent, title, email)
        {
            MailToSubject = subject;

        }

        public SupportPanel(int parrentHeigh):this()
        {
            _parrentHeigh = parrentHeigh;
            this.Width = 150;
            this.Height = 25;
            this.Top = SupportPanelClosedTop;
            
        }

        public SupportPanel(Control parent):this()
        {
            ParentControl = parent;
            this.Width = ParentControl.Width;
            this.Height = 25;
            this.Top = SupportPanelClosedTop;
        }

        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var mailtoBuilder = new StringBuilder();
                mailtoBuilder.AppendFormat("mailto:{0}", linkEmail.Text);
                if (!string.IsNullOrEmpty(MailToSubject)) mailtoBuilder.AppendFormat("?subject=\"{0}\"", Uri.EscapeDataString(MailToSubject));
                Process.Start(mailtoBuilder.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open default email application.", "Email sending error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public string MailToSubject { get; set; }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            ShowSupportPanel();
        }

        private void ShowSupportPanel()
        {
            this.Height = 95;
            this.Top = SupportPanelOpenedTop;
            this.BringToFront();
            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += timer_Tick;
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                HideSupportPanel();
            }
            catch (Exception ex)
            {
                if (!CommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName, string.Format("Method: {0} Error:{1} \n StackTrace: {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace), EventLogEntryType.Error);
                }
            }
        }

        private void HideSupportPanel()
        {
            bool entered = this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));
            if (!entered)
            {
                this.Height = 25;
                this.Top = SupportPanelClosedTop;
                timer.Enabled = false;
            }
        }
        

        public int SupportPanelClosedTop
        {
            get { return ParentHeight - 25; }
        }

        public int ParentHeight
        {
            get { return ParentControl != null ? ParentControl.Height : _parrentHeigh; } 
        }

        public int SupportPanelOpenedTop
        {
            get { return ParentHeight - 95; }
        }
    }
}
