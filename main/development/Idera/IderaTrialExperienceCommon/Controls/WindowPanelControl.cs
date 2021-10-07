using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Text;
using System.Net;
using System.Text;
using System.Windows.Forms;
using IderaTrialExperienceCommon.Common;

namespace IderaTrialExperienceCommon.Controls
{

    public partial class WindowPanelControl : UserControl
    {
       

        private string _internetConnectionErrorMessage;
        

        public WindowPanelControl()
        {
            
            InitializeComponent();
        }

        public string TrialCenterWebSiteUrl { get; set; }

        public void ShowTrialHelp(Form parentForm, Control parentContainer)
        {
            this.lblTitle.Text = Properties.Resources.TrialHelpPageTitle;
            this.lblContent.Text = Properties.Resources.TrialHelpPageContent;
            this.btnDoAction.Text = Properties.Resources.TrialHelpPageButtonText;
            EmptyDoActionButtonHandlers();
            this.btnDoAction.Click += DoGetHelpAction;
            SetPanelParameters(parentForm, parentContainer);

        }

        private void EmptyDoActionButtonHandlers()
        {
            this.btnDoAction.Click -= DoGetHelpAction;
            this.btnDoAction.Click -= DoGoCommuntiyAction;
        }

        public void ShowCommunity(Form parentForm, Control parentContainer)
        {
            this.lblTitle.Text = Properties.Resources.CommunityPageTitle;
            this.lblContent.Text = Properties.Resources.CommunityPageContent;
            this.btnDoAction.Text = Properties.Resources.CommunityPageButtonText;
            if (CommunityCenterUrl == null) CommunityCenterUrl = string.Empty;
            EmptyDoActionButtonHandlers();
            this.btnDoAction.Click += DoGoCommuntiyAction;
            SetPanelParameters(parentForm, parentContainer);

        }

        private void SetPanelParameters(Form parentForm, Control parentContainer)
        {
            if (parentForm != null)
            {
                this.Width = parentForm.Width;
                this.Height = parentForm.Height - parentContainer.Height;
                this.Top = parentContainer.Top + parentContainer.Height;
                this.Left = parentContainer.Left;
                this.Anchor = (AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom);
                parentForm.Controls.Add(this);
                this.BringToFront();
            }
        }

        public void Close()
        {
            if (ParentForm != null)
            {
                if (ParentForm.Controls.Contains(this))
                {
                    ParentForm.Controls.Remove(this);
                }
            }
        }

        private void DoGetHelpAction(object sender, EventArgs e)
        {
            InternetConnection.OpenWebPage(TrialCenterWebSiteUrl, IderaProductName);
        }
        private void DoGoCommuntiyAction(object sender, EventArgs e)
        {
            InternetConnection.OpenWebPage(CommunityCenterUrl, IderaProductName);
        }

        public string CommunityCenterUrl { get; set; }

        public string InternetConnectionErrorMessage
        {
            get { return string.IsNullOrEmpty(_internetConnectionErrorMessage)? Properties.Resources.InternetConnectionErrorMessage: _internetConnectionErrorMessage; }
            set { _internetConnectionErrorMessage = value; }
        }

        public string IderaProductName { get; set; }
    }
}
