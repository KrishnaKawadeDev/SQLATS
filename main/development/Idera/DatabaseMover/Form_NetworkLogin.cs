using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core;
using System.Runtime.InteropServices;

namespace Idera.SqlAdminToolset.DatabaseMover
{
   public partial class Form_NetworkLogin : Form
   {
      string _Server;
      string _Share = string.Empty;

      public Form_NetworkLogin(string server, string share)
      {
         InitializeComponent();
         _Server = server;
         _Share = share.Substring(0, share.IndexOf("$") + 1);
         labelInstructions.Text = string.Format(labelInstructions.Text, server);
         this.Text = string.Format(this.Text, server);
      }

      public string Share
      {
         get { return _Share; }
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         try
         {
            Cursor = Cursors.WaitCursor;
            string _DomainName = _Server;
            string _LoginName = textLoginName.Text;
            if (textLoginName.Text.Contains(@"\"))
            {
               _DomainName = textLoginName.Text.Substring(0, textLoginName.Text.IndexOf(@"\"));
               _LoginName = textLoginName.Text.Substring(textLoginName.Text.IndexOf(@"\") + 1);
            }

            CoreGlobals.traceLog.DebugFormat("Server: {0}", _Server);
            CoreGlobals.traceLog.DebugFormat("Login Textbox: {0}", textLoginName.Text);
            CoreGlobals.traceLog.DebugFormat("Domain Name: {0}", _DomainName);
            CoreGlobals.traceLog.DebugFormat("Login Name: {0}", textLoginName.Text);
            CoreGlobals.traceLog.DebugFormat("Share: {0}", _Share);

            USE_INFO_2 _UserInfo = new USE_INFO_2();
            _UserInfo.ui2_remote = _Share;
            _UserInfo.ui2_username = _LoginName;
            _UserInfo.ui2_domainname = _DomainName;
            _UserInfo.ui2_password = textPassword.Text;
            _UserInfo.ui2_asg_type = 0;
            _UserInfo.ui2_usecount = 1;
            uint paramErrorIndex;
            uint returnCode = NetUseAdd(null, 2, ref _UserInfo, out paramErrorIndex);
            if (returnCode != 0)
            {
               throw new Win32Exception((int)returnCode);
            }


            DialogResult = DialogResult.OK;

            Close();
         }
         catch (Exception exc)
         {
            Cursor = Cursors.Default;
            Messaging.ShowException("Authenticate user", exc);
         }
         finally
         {
            Cursor = Cursors.Default;
         }
      }

      [DllImport("NetApi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
      internal static extern UInt32 NetUseAdd(
        string UncServerName,
        UInt32 Level,
        ref USE_INFO_2 Buf,
        out UInt32 ParmError);


      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
      internal struct USE_INFO_2
      {
         internal string ui2_local;
         internal string ui2_remote;
         internal string ui2_password;
         internal UInt32 ui2_status;
         internal UInt32 ui2_asg_type;
         internal UInt32 ui2_refcount;
         internal UInt32 ui2_usecount;
         internal string ui2_username;
         internal string ui2_domainname;
      }
   }
}