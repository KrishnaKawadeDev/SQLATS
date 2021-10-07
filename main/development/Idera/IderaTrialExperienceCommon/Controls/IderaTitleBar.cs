using System.Drawing;
using System.Drawing.Drawing2D;
using IderaTrialExperienceCommon.Common;

namespace IderaTrialExperienceCommon.Controls
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using IderaTitleBarControls.Dialogs;

    public partial class IderaTitleBar : UserControl
    {
        [DllImportAttribute("uxtheme.dll")]
        private static extern int SetWindowTheme(IntPtr hWnd, string appname, string idlist);

        public bool IsFormLocked
        {
            get { return _isFormLocked; }
            set
            {
                _isFormLocked = value;
                OnWindowLockChanged(EventArgs.Empty);
            }
        }

        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        private const string TrialFormatString = @"Trial version - {0} {1} left";
        private WindowPanelControl HelpPanel;
        private LicenseInformationPanelControl LicenseInfoPanel;
        private ApplicationWindowLocker ApplicationLocker;

        private int trialDaysLeft;
        private bool trialMode;
        private string _ideraTrialCenterUrl;
        private string _buyNowUrl;
        private LicenseInformation _licenseInformation;
        private string _ideraProductCommunityCenterUrl;
        private bool _isFormLocked;


        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        public IderaTitleBar()
        {

            this.InitializeComponent();
            MainTLP.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            this.Dock = DockStyle.Top;
            HelpPanel = new WindowPanelControl();
            IsFormLocked = false;
            LicenseInfoPanel = new LicenseInformationPanelControl(LicenseInformation);
            if (ActivateLicenseEventHandler != null) LicenseInfoPanel.ActivateLicense += ActivateLicenseEventHandler;


            ApplicationLocker = new ApplicationWindowLocker();

            if (!DesignMode) ApplyFont();

            this.SetDefaultValues();
            // this.SetTitleBarMode(this.TrialMode);
            SetWindowTheme(trialProgressBar.Handle, "", "");
        }

       

        private void ApplyFont()
        {

            FontLoader.ApplyFont(lblIderaProductName_Left);
            FontLoader.ApplyFont(lblIderaProductName_Right);
            FontLoader.ApplyFont(BuyNowButton);

        }


        private void SetDefaultValues()
        {

            this.TrialMode = true;
            this.SetTitleBarMode(false);
            this.AddLicenseButtonText = Properties.Resources.AddLicenseButtonDefaultText;
            this.BuyNowButtonText = Properties.Resources.BuyNowButtonDefaultText;
            this.CommunityButtonText = Properties.Resources.CommunityButtonDefaultText;

            this.IderaProductCommunityCenterUrl = Properties.Resources.IderaProductCommunityCenterUrl;
            this.IderaTrialCenterUrl = Properties.Resources.IderaTrialCenterUrl;
            this.MaxTrialDays = 14;
            this.TrialDaysLeft = 14;
            this.DaysBeforTrialExpireToAnounce = 8;
            this.TrialHelpButtonText = Properties.Resources.TrialHelpButtonDefaultText;


            this.TrialHelpAndCommunityButton.ButtonText = this.CommunityButtonText;
            TrialCounterLicenseInfoButton.ButtonText = Properties.Resources.LicenseInfoButtonText;
            this.trialProgressBar.Visible = false;
            //BuyNowButton.Visible = false;
            this.BuyNowButton.Text = this.AddLicenseButtonText;


        }

        public event EventHandler AddLicenseClick;

        public event EventHandler BuyNowClick;

        public event EventHandler CommunityButtonClick;

        public event EventHandler HomeButtonClick;
        public event EventHandler LicenseExpiredStatusChanged;
        public event EventHandler WindowLockChanged;
        public event EventHandler ActivateLicense
        {
            add
            {
                if (ActivateLicenseEventHandler == null) ActivateLicenseEventHandler = value;
                else
                    lock (ActivateLicenseEventHandler)
                    {

                        ActivateLicenseEventHandler += value;

                    }
                if (LicenseInfoPanel != null) LicenseInfoPanel.ActivateLicense += value;
            }
            remove
            {
                if (ActivateLicenseEventHandler != null)
                    lock (ActivateLicenseEventHandler)
                    {
                        LicenseInfoPanel.ActivateLicense -= value;

                    }
                if (value != null) ActivateLicenseEventHandler -= value;
            }

        }

        public EventHandler ActivateLicenseEventHandler { get; set; }


        public event EventHandler TrialButtonClick;
        public event EventHandler RegisterKeyFormShow;
        public event EventHandler TrialVersionCountdownLinkClick;
        public event EventHandler LicenseInfoButtonClick;
        [DefaultValue("Add Licenses")]
        public string AddLicenseButtonText { get; set; }

        [DefaultValue("Buy Now")]
        public string BuyNowButtonText { get; set; }



        [DefaultValue("Community")]
        public string CommunityButtonText { get; set; }

        public string IderaProductCommunityCenterUrl
        {
            get { return _ideraProductCommunityCenterUrl; }
            set
            {
                _ideraProductCommunityCenterUrl = value;
                HelpPanel.CommunityCenterUrl = value;
            }
        }

        [DefaultValue("http://trialcenter.idera.com/")]
        public string IderaTrialCenterUrl
        {
            get { return _ideraTrialCenterUrl; }
            set
            {
                _ideraTrialCenterUrl = value;
                HelpPanel.TrialCenterWebSiteUrl = _ideraTrialCenterUrl;

            }
        }



        [Category("Appearance")]
        [Description("Gets or sets application window title")]
        public string IderaProductNameText
        {
            get
            {
                return string.Format("{0} {1}", this.lblIderaProductName_Left.Text, this.lblIderaProductName_Right.Text);
            }
            set
            {

                if (value.Split(' ').Length > 1)
                {
                    lblIderaProductName_Left.Text = value.Split(' ')[0];
                    lblIderaProductName_Right.Text = value.TrimStart(value.Split(' ')[0].ToCharArray()).Trim();
                }
                else this.lblIderaProductName_Left.Text = value;
                if (HelpPanel != null) HelpPanel.IderaProductName = value;
                if (LicenseInfoPanel != null) LicenseInfoPanel.IderaProductName = value;
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets maximum trial days")]
        [DefaultValue(14)]
        public int MaxTrialDays { get; set; }



        [Category("Appearance")]
        [Description("Gets or sets count of days to the end of trial period")]
        [DefaultValue(14)]
        public int TrialDaysLeft
        {
           
            get
            {
                return this.trialDaysLeft;
            }
            set
            {
                // UnlockForm();
                try
                {
                    var prevValue = trialDaysLeft;
                    this.trialDaysLeft = value;

                    if (this.TrialMode)
                    {
                        if (this.MaxTrialDays == 0)
                        {
                            this.MaxTrialDays = 14;
                        }

                        SetProgressBarValue();
                        this.TrialCounterLicenseInfoButton.ButtonText = string.Format(TrialFormatString,
                            this.TrialDaysLeft, TrialDaysLeft == 1 ? "day" : "days");
                        if (ParentForm != null && ParentForm.Visible && prevValue != value) ShowTrialExpiredDialog();

                    }
                    else
                    {
                      UnlockForm();
                    }
                    OnLicenseExpiredStatusChanged();
                }
                catch (Exception ex)
                {
                    if (!TrailExCommonFunctions.IsUserRestrictted())
                    {
                        EventLog.WriteEntry(Application.ProductName,
                        string.Format("{0}\nStackTrace:\n{1}", ex.Message, ex.StackTrace), EventLogEntryType.Error);
                    }
                }
            }
        }

        private void SetProgressBarValue()
        {
            var val = 100 / (this.MaxTrialDays / (float)this.TrialDaysLeft);

            this.trialProgressBar.Value = (int)Math.Round(val) >= trialProgressBar.Minimum &&
                                          (int)Math.Round(val) <= trialProgressBar.Maximum
                ? (int)Math.Round(val)
                : (int)Math.Round(val) > trialProgressBar.Maximum ? trialProgressBar.Maximum : 0;

        }

        [Category("Appearance")]
        [Description("Gets or sets count of days to the end of trial that user will be informed with dialog")]
        [DefaultValue(8)]
        public int DaysBeforTrialExpireToAnounce { get; set; }

        [Category("Appearance")]
        [Description("Gets or sets if application is in trial mode")]
        [DefaultValue(false)]
        public bool TrialMode
        {
            get
            {
                return this.trialMode;
            }
            set
            {
                this.trialMode = value;
                this.SetTitleBarMode(value);
            }
        }

        [Category("Appearance")]
        [DefaultValue("Trial Help")]
        public string TrialHelpButtonText { get; set; }




        protected virtual void OnAddLicenseClick(EventArgs e)
        {
            EventHandler handler = this.AddLicenseClick;
            if (handler != null)
            {
                handler(this, e);
            }
            else
            {
                OnBuyNowClick(e);
            }
        }

        public virtual void OnLicenseExpiredStatusChanged()
        {
            EventHandler handler = this.LicenseExpiredStatusChanged;
            if (handler != null)
            {
                handler(this, null);
            }
           
        }

        protected virtual void OnBuyNowClick(EventArgs e)
        {
            EventHandler handler = this.BuyNowClick;
            if (handler != null)
            {
                handler(this, e);
            }
            else
            {
                InternetConnection.OpenWebPage(BuyNowUrl, IderaProductNameText);
            }
        }




        protected virtual void OnCommunityButtonClick(EventArgs e)
        {
            EventHandler handler = this.CommunityButtonClick;
            if (handler != null)
            {
                handler(this, e);
            }
            else //Do Default action
            {
                HelpPanel.ShowCommunity(ParentForm, this);
                // InternetConnection.OpenWebPage(IderaProductCommunityCenterUrl, IderaProductNameText);

            }
        }

        public string BuyNowUrl
        {
            get { return _buyNowUrl; }
            set
            {
                _buyNowUrl = value;
                LicenseInfoPanel.ProductStoreUrl = _buyNowUrl;
            }
        }

        protected virtual void OnHomeButtonClick(EventArgs e)
        {
            EventHandler handler = this.HomeButtonClick;
            if (this.TrialDaysLeft == 0)
            {
                this.ShowTrialExpiredDialog();

            }
            else
            {
                UnlockForm();
            }
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void ShowTrialExpiredDialog()
        {
            try
            {
                //      UnlockForm();
                if (this.trialDaysLeft < this.DaysBeforTrialExpireToAnounce)
                {
                    var trialExpiredDialog = new TrialExpiredDialog(this.BuyNowUrl, this.IderaTrialCenterUrl,
                        IderaProductNameText, this.trialDaysLeft,trialMode);
                    if (ActivateLicenseEventHandler != null)
                        trialExpiredDialog.ActivateLicenseClick += ActivateLicenseEventHandler;
                    if (trialDaysLeft == 0)
                        LockForm();
                    else UnlockForm();
                    if(TrialMode||(!TrialMode && this.trialDaysLeft==0))
                    trialExpiredDialog.ShowDialog();

                }
                else
                {
                    if (trialDaysLeft > 0)
                    {
                        UnlockForm();
                    }
                }
            }
            catch (Exception ex)
            {
                if (!TrailExCommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName,
                    string.Format("{0}\nStackTrace:\n{1}", ex.Message, ex.StackTrace), EventLogEntryType.Error);
                    }
            }
        }

        private void LockForm()
        {
            if (TrialHelpAndCommunityButton.Active || TrialCounterLicenseInfoButton.Active) return;
            ApplicationLocker.LockForm(ParentForm, this);
            IsFormLocked = true;
        }

        private void UnlockForm()
        {
            ApplicationLocker.UnlockForm(ParentForm);
            IsFormLocked = false;
        }


        protected virtual void OnTrialButtonClick(EventArgs e)
        {
            EventHandler handler = this.TrialButtonClick;
            if (handler != null)
            {
                handler(this, e);
            }
            else
            {
                HelpPanel.ShowTrialHelp(ParentForm, this); //Do Default Action
            }
        }

        protected virtual void OnWindowLockChanged(EventArgs e)
        {
            EventHandler handler = this.WindowLockChanged;
            if (handler != null)
            {
                handler(this, e);
            }
          
        }

        public LicenseInformation LicenseInformation
        {
            get { return _licenseInformation; }
            set
            {
                _licenseInformation = value;
                
                LicenseInfoPanel.LicenseInformation = _licenseInformation;
                if (_licenseInformation != null)
                {
                
                    _licenseInformation.PropertyChanged += UpdateLicenseInformation;
                    TrialMode = _licenseInformation.IsTrial;
                    TrialDaysLeft =  _licenseInformation.DaysToExpire;
                    if (!_licenseInformation.IsTrial)
                    {
                        homeButton_Click(this, new EventArgs());
                    }
                }
            }
        }

        private void UpdateLicenseInformation(object sender, PropertyChangedEventArgs e)
        {
            var licInfo = sender as LicenseInformation;
            if (licInfo == null) return;
            switch (e.PropertyName)
            {
                case LicenseInformationFieldNames.IsTrial:
                    TrialMode = licInfo.IsTrial;
                    if (!licInfo.IsTrial)
                    {
                        homeButton_Click(this, e); //go home if become not trial
                    }
                    break;
                case LicenseInformationFieldNames.DaysToExpire:
                    TrialDaysLeft = licInfo.DaysToExpire;
                    break;
            }
        }

        protected virtual void OnLicenseInfoClick(EventArgs e)
        {
            EventHandler handler = this.LicenseInfoButtonClick;
            if (handler != null)
            {
                handler(this, e);
            }
            else
            {
                OnTrialVersionCountdownLinkClick(e);
            }
        }



        protected virtual void OnTrialVersionCountdownLinkClick(EventArgs e)
        {
            EventHandler handler = this.ActivateLicenseEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
            //else //Do default action
            //{
            //    if (LicenseInformation != null)
            //    {
            //        LicenseInfoPanel.LicenseInformation = LicenseInformation;
            //    }
            //    LicenseInfoPanel.ShowLicenseInformation(ParentForm, this);
            //}
        }

        private void BuyNowButton_Click(object sender, EventArgs e)
        {
            if (this.TrialMode)
            {
                this.OnBuyNowClick(e);
            }
            else
            {
                this.OnAddLicenseClick(e);
            }
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            this.TrialHelpAndCommunityButton.Active = false;
            this.TrialCounterLicenseInfoButton.Active = false;
            this.homeButton.Active = true;
            HelpPanel.Close();
            LicenseInfoPanel.CloseLicenseInformation();
            panel1.Invalidate();
            this.OnHomeButtonClick(e);
        }







        private void SetTitleBarMode(bool isTrial)
        {
            if (isTrial) //If trial mode
            {
                this.trialProgressBar.Maximum = 100;
                this.TrialHelpAndCommunityButton.ButtonText = this.TrialHelpButtonText;
                this.trialProgressBar.Visible = true;
                if (this.MaxTrialDays == 0)
                {
                    this.MaxTrialDays = 14;
                }
                SetProgressBarValue();


                this.BuyNowButton.Text = this.BuyNowButtonText;
            }
            else
            {
                this.TrialHelpAndCommunityButton.ButtonText = this.CommunityButtonText;
                this.TrialCounterLicenseInfoButton.ButtonText = Properties.Resources.LicenseInfoButtonText;
                this.trialProgressBar.Visible = false;
                //BuyNowButton.Visible = false;
                this.BuyNowButton.Text = this.AddLicenseButtonText;
                UnlockForm();
            }
        }


        private void TitleTLP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((e.Clicks == 1) && (this.ParentForm.WindowState != FormWindowState.Maximized))
                {
                    ReleaseCapture();
                    SendMessage(this.ParentForm.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        private void TrialCounterButton_Click(object sender, EventArgs e)
        {

            this.homeButton.Active = false;
            this.TrialHelpAndCommunityButton.Active = false;
            this.TrialCounterLicenseInfoButton.Active = true;
            panel1.Invalidate();
            if (TrialMode)
            {
                this.OnTrialVersionCountdownLinkClick(e);
            }
            else
            {
                OnLicenseInfoClick(e);
            }
        }

        private void trialHelpAndCommunityButton_Click(object sender, EventArgs e)
        {


            this.homeButton.Active = false;
            this.TrialCounterLicenseInfoButton.Active = false;
            this.TrialHelpAndCommunityButton.Active = true;
            LicenseInfoPanel.CloseLicenseInformation();
            panel1.Invalidate();
            if (this.TrialMode)
            {

                this.OnTrialButtonClick(e);
            }
            else //Not trial
            {

                this.OnCommunityButtonClick(e);
            }
        }

        public virtual void OnActivateLicense(EventArgs e)
        {

            EventHandler handler = ActivateLicenseEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }

        }

        private void ButtonsTLP_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            trialProgressBar.Update();
        }




        #region WindowControl

        private void TitleTLP_DoubleClick(object sender, EventArgs e)
        {
            this.WindowControlButtons.ToggleFormSize();
        }
        private void IderaProductName_DoubleClick(object sender, EventArgs e)
        {
            this.WindowControlButtons.ToggleFormSize();
        }

        //Move window
        private void IderaProductName_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((e.Clicks == 1) && (this.ParentForm.WindowState != FormWindowState.Maximized))
                {
                    ReleaseCapture();
                    SendMessage(this.ParentForm.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        public bool Minimize
        {
            get
            {
                return this.WindowControlButtons.Minimize;
            }

            set
            {
                this.WindowControlButtons.Minimize = value;
            }
        }

        public bool Maximize
        {
            get
            {
                return this.WindowControlButtons.Maximize;
            }
            set
            {
                this.WindowControlButtons.Maximize = value;
            }
        }
        public bool Close
        {
            get
            {
                return this.WindowControlButtons.Close;
            }
            set
            {
                this.WindowControlButtons.Close = value;
            }
        }
        #endregion

        private void TrialCounterLicenseInfoButton_Load(object sender, EventArgs e)
        {

        }

        

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (TrialMode)
            {
                var panel = sender as Control;
                var rectangle = new Rectangle(1, 1, panel.Size.Width - 2, panel.Size.Height - 2);
                var selectedColor = System.Drawing.Color.FromArgb(((int) (((byte) (149)))), ((int) (((byte) (201)))),
                    ((int) (((byte) (66)))));
                var unselectedColor = Color.WhiteSmoke;
                using (var pen = new Pen(TrialCounterLicenseInfoButton.Active ? selectedColor : unselectedColor, 2))
                {
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    e.Graphics.DrawRectangle(pen, rectangle); // dotted border}
                }
            }
        }

    }
}