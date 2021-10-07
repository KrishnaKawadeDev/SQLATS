using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using DeployLX.Licensing.v5;

namespace Idera.SqlAdminToolset.Core.LicenseViews.Panels
{
    public partial class ExtendPanel : ExtensionPanel
    {


        public ExtendPanel(bool autoExtensionRequest, params Limit[] limits) : base(autoExtensionRequest, limits)
        {
           
        }

     

        protected override void InitializePanel()
        {
            base.InitializePanel();
            MailToSubject = string.Format("Please extend my {0} trial.", Application.ProductName);
            var salesEmailLink = new LinkLabel
            {
                Text = "sales@idera.com",
                Top = 17,
                Left = 265,
                AutoSize = true
            };
            salesEmailLink.LinkClicked += SendEmailToSales;


            BodyPanel.Controls["_extensionNotice"].Controls.Add(salesEmailLink);


            BodyPanel.Controls["_extensionsPanel"].Controls["_serialNumberLabel"].Visible = false;
            BodyPanel.Controls["_extensionsPanel"].Controls["_serialNumber"].Visible = false;

            BodyPanel.Controls["_extensionsPanel"].Controls["_extensionsHost"].Controls[0].Visible = false;
            BodyPanel.Controls["_extensionsPanel"].Controls["_extensionsHost"].Controls[1].Visible = false;

            BodyPanel.Controls["_extensionsPanel"].Controls["_extensionsHost"].Controls[2].Text = "Enter Trial Extension Code";
            SidePanel.Controls["_copyToClipboard"].Visible = false;

            ClearBottomControls();


            var extendButton = AddBottomButton("Extend");
            extendButton.Click += HandleExtendButtonClick;


            var goBackButton = AddBottomButton("<< Go Back");
            goBackButton.Click += HandleGoBackButtonClick;
            SuperForm.Text = "Idera SQL Admin Toolset: Extend";

           
            SidePanel.Controls.Add(new SupportPanel(SidePanel, "Sales", "sales@idera.com", MailToSubject));
        }

        private void SendEmailToSales(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var mailtoBuilder = new StringBuilder();
                mailtoBuilder.AppendFormat("mailto:{0}", "sales@idera.com");
                if (!string.IsNullOrEmpty(MailToSubject)) mailtoBuilder.AppendFormat("?subject=\"{0}\"", Uri.EscapeDataString(MailToSubject));
                Process.Start(mailtoBuilder.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open Trial Center page", "Extend License", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
            }
        }

        public string MailToSubject { get; set; }


        protected override void LoadPanel(SecureLicenseContext context)
        {
            base.LoadPanel(context);
         

        }


        

        private void HandleGoBackButtonClick(object sender, EventArgs e)
        {
            Return(FormResult.Incomplete);
        }

        private void HandleExtendButtonClick(object sender, EventArgs e)
        {
            try
            {

                bool flag1 = true;
                bool flag2 = false;
                foreach (Control control in (ArrangedElementCollection)this.BodyPanel.Controls["_extensionsPanel"].Controls["_extensionsHost"].Controls)
                {
                    PromptMaskedEdit promptMaskedEdit = control as PromptMaskedEdit;
                    if (promptMaskedEdit != null)
                    {
                        try
                        {
                            IExtendableLimit extendableLimit = promptMaskedEdit.Tag as IExtendableLimit;

                            if (promptMaskedEdit.Text.Length != 0)
                            {
                                if (!(promptMaskedEdit.Text == extendableLimit.License.SerialNumberInfo.Prefix))
                                {
                                    flag2 = true;
                                    if (!extendableLimit.ExtendByCode(SuperForm.Context, promptMaskedEdit.Text))
                                        flag1 = false;
                                }
                            }
                            else
                            {
                                ShowMessageBox("Extension code can not be empty. Please enter valid extension code.", "Trial Extension",
                                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                        }
                        catch
                        {
                            flag1 = false;
                        }
                    }
                   
                }
                if (flag1 && flag2)
                {
                    this.Return(FormResult.Success);
                }
                else
                {
                    string text;
                    if (flag2)
                    {
                        text = "Error occured during license extension. ";
                        if (this.SuperForm.Context.LatestValidationRecord != null)
                            text = text + this.SuperForm.Context.LatestValidationRecord.Message;
                    }
                    else
                        text = "Trial Extension failed. ";
                    int num = (int)this.ShowMessageBox(text, "Trial Extension", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception ex)
            {
                if (!CommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName, string.Format("Method: {0} Error:{1} \n StackTrace: {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace), EventLogEntryType.Error);
                }
                //ignore
            }
        }
    }
}
