using System;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Core
{
    public partial class Form_Credentials : Form
    {
        #region Properties

        private bool m_firstTime = true;
        private SQLCredentials m_sqlCredentials = null;
        //private bool           m_loading = false;
        private string m_server = "";
        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public string Server
        {
            set
            {
                m_server = value;

                buttonTestConnection.Visible = !String.IsNullOrEmpty(m_server);
            }
            get
            {
                return m_server;
            }
        }

        public string Title
        {
            set { Text = value; }
        }

        public SQLCredentials sqlCredentials
        {
            get
            {
                m_sqlCredentials.useSqlAuthentication = radioSQL.Checked;
                m_sqlCredentials.loginName = (radioSQL.Checked) ? textLoginName.Text : textLoginName.Text;
                m_sqlCredentials.password = (radioSQL.Checked) ? textPassword.Text : textPassword.Text;

                return m_sqlCredentials;
            }
            set
            {
                m_sqlCredentials = value;
            }
        }

        #endregion

        public Form_Credentials()
        {
            InitializeComponent();

            m_sqlCredentials = new SQLCredentials();
            textLoginName.WatermarkText = userName;
            textLoginName.Text = string.Empty;
            textPassword.Text = string.Empty;
        }

        public Form_Credentials(SQLCredentials inSqlCredentials)
        {
            InitializeComponent();

            if (inSqlCredentials != null)
            {
                m_sqlCredentials = inSqlCredentials;
            }
        }

        public Form_Credentials(string inServer, SQLCredentials inSqlCredentials)
        {
            InitializeComponent();

            m_server = inServer;
            textLoginName.WatermarkText = userName;

            if (inSqlCredentials != null)
            {
                m_sqlCredentials = inSqlCredentials;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!String.IsNullOrEmpty(m_server))
            {
                buttonTestConnection.Visible = true;
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (m_firstTime)
            {
                m_firstTime = false;
                if (m_sqlCredentials == null) m_sqlCredentials = new SQLCredentials();
                SetFieldValues();
            }
        }

        private void SetFieldValues()
        {
            if (m_sqlCredentials != null && m_sqlCredentials.useSqlAuthentication)
            {
                radioSQL.Checked = true;
                textLoginName.Text = m_sqlCredentials.loginName;
                textPassword.Text = m_sqlCredentials.password;
            }
            else if (m_sqlCredentials != null && m_sqlCredentials.useWindowsAuthentication &&!string.IsNullOrEmpty(m_sqlCredentials.loginName))
            {
                radioWindows.Checked = true;
                textLoginName.Text = m_sqlCredentials.loginName;
                textPassword.Text = m_sqlCredentials.password;
              
            }
            else
            {
                radioWindows.Checked = true;
                textLoginName.Text = "";
                textPassword.Text = "";
              
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                // if sql authentication and user name blank - dont allow close
                if (radioSQL.Checked && textLoginName.Text.Length == 0)
                {
                    Messaging.ShowError("A login name is required when using SQL authentication.",
                                         "Set Connection Credentials");
                    DialogResult = DialogResult.None;
                    return;
                }

                // check if anything has changed
                bool dirty = false;
                if (radioSQL.Checked)
                {
                    if ((m_sqlCredentials == null)
                       || (!m_sqlCredentials.useSqlAuthentication)
                       || (m_sqlCredentials.loginName != textLoginName.Text)
                       || (m_sqlCredentials.password != textPassword.Text))
                    {
                        dirty = true;
                    }
                }
                else
                {
                    if ((m_sqlCredentials != null)
                    ) dirty = true;
                }

                DialogResult = (dirty) ? DialogResult.OK : DialogResult.Cancel;

                Close();
            }
            catch (Exception ex)
            {
               
                throw;
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioWindowsSql_CheckedChanged(object sender, EventArgs e)
        {
            textLoginName.WatermarkText = userName;
            //textLoginName.Enabled = radioSQL.Checked;
            //textPassword.Enabled = radioSQL.Checked;
        }

        private void radioSQL_CheckedChanged(object sender, EventArgs e)
        {
            textLoginName.WatermarkText = string.Empty;
            textLoginName.Text = string.Empty;
            textPassword.Text = string.Empty;
            //    textLoginName.Enabled = radioSQL.Checked;
            //  textPassword.Enabled  = radioSQL.Checked;
        }

        private void buttonTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Connection.TestConnection(m_server,
                                           radioSQL.Checked,
                                           textLoginName.Text,
                                           textPassword.Text);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}