using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.LinkedServerMover
{
   public partial class Form_SetPasswords : Form
   {
      List<LinkedServer> linkedServers = null;
      Dictionary<string, Dictionary<string, string>> logins = null;

      public List<LinkedServer> LinkedServers
      {
         get { return linkedServers; }
         set { linkedServers = value; }
      }

      public Dictionary<string, Dictionary<string, string>> Logins
      {
         get { return logins; }
      }

      public Form_SetPasswords()
      {
         InitializeComponent();
      }

      protected override void OnLoad(EventArgs e)
      {
         base.OnLoad(e);

         if (LinkedServers != null)
         {
            int tabIndex = 0;

            foreach (LinkedServer linkedServer in linkedServers)
            {
               AddServerTab(linkedServer.Name);
               AddLinkedServerLogins(linkedServer.LinkedServerLogins, tabIndex);
               tabIndex++;
            }
         }
      }

      private void AddServerTab(string serverName)
      {
         DevComponents.DotNetBar.TabItem newTabItem = new DevComponents.DotNetBar.TabItem();
         DevComponents.DotNetBar.TabControlPanel newTabControlPanel = new DevComponents.DotNetBar.TabControlPanel();
         DevComponents.DotNetBar.Controls.GroupPanel loginsPanel = new DevComponents.DotNetBar.Controls.GroupPanel();

         // Initialize Tab Item
         newTabItem.AttachedControl = newTabControlPanel;
         newTabItem.Name = String.Format("tab{0}", serverName);
         newTabItem.Text = serverName;
         newTabItem.Tooltip = serverName;

         //Initialize the loginsPanel
         loginsPanel.Dock = DockStyle.Fill;
         loginsPanel.AutoScroll = true;
         loginsPanel.BackColor = Color.Transparent;
         loginsPanel.CanvasColor = System.Drawing.SystemColors.Control;
         loginsPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
         loginsPanel.IsShadowEnabled = true;
         loginsPanel.Location = new System.Drawing.Point(5, 5);
         loginsPanel.Name = serverName;
         loginsPanel.Size = new System.Drawing.Size(375, 320);
         loginsPanel.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
         loginsPanel.Style.BackColorGradientAngle = 90;
         loginsPanel.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
         loginsPanel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
         loginsPanel.Style.BorderBottomWidth = 1;
         loginsPanel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
         loginsPanel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
         loginsPanel.Style.BorderLeftWidth = 1;
         loginsPanel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
         loginsPanel.Style.BorderRightWidth = 1;
         loginsPanel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
         loginsPanel.Style.BorderTopWidth = 1;
         loginsPanel.Style.Class = "";
         loginsPanel.Style.CornerDiameter = 4;
         loginsPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
         loginsPanel.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
         loginsPanel.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
         loginsPanel.StyleMouseDown.Class = "";
         loginsPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
         loginsPanel.StyleMouseOver.Class = "";
         loginsPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
         //loginsPanel.TabIndex = 0;
         loginsPanel.Text = String.Format("{0} Logins", serverName);

         // Initialize Tab Control
         newTabControlPanel.Controls.Add(loginsPanel);
         newTabControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         newTabControlPanel.Location = new System.Drawing.Point(183, 0);
         newTabControlPanel.Name = String.Format("tabControl{0}", this.tabControlLogins.Tabs.Count);
         newTabControlPanel.Padding = new System.Windows.Forms.Padding(1);
         newTabControlPanel.Size = new System.Drawing.Size(506, 278);
         newTabControlPanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
         newTabControlPanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
         newTabControlPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
         newTabControlPanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
         newTabControlPanel.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Right | DevComponents.DotNetBar.eBorderSide.Top)
                | DevComponents.DotNetBar.eBorderSide.Bottom)));
         //newTabControlPanel.TabIndex = 2;
         newTabControlPanel.TabItem = newTabItem;

         // add them to the overall tab control         
         this.tabControlLogins.SuspendLayout();
         this.tabControlLogins.Controls.Add(newTabControlPanel);
         this.tabControlLogins.Tabs.Add(newTabItem);

         this.tabControlLogins.ResumeLayout();
         this.tabControlLogins.Invalidate();
         Application.DoEvents();
      }

      private void AddLinkedServerLogins(LinkedServerLoginCollection logins, int tabIndex)
      {
         int loginIndex = 0;
         int prevControlHeight = 0;
         ToolLinkedServerLogin controlLogin = null;

         this.tabControlLogins.SuspendLayout();

         foreach (LinkedServerLogin login in logins)
         {
            //skip blank logins
            if (String.IsNullOrEmpty(login.Name) && String.IsNullOrEmpty(login.RemoteUser))
               continue;

            //only show remote sql server logins.
            if ((login.Impersonate) || (login.RemoteUser.IndexOf('\\') != -1))
            {
               continue;
            }

            controlLogin = new ToolLinkedServerLogin();
            controlLogin.Name = String.Format("controllogin{0}", loginIndex++);
            controlLogin.Location = new Point(5, prevControlHeight + 5);
            prevControlHeight += controlLogin.Size.Height;
            controlLogin.Username = login.RemoteUser;
            tabControlLogins.Tabs[tabIndex].AttachedControl.Controls[0].Controls.Add(controlLogin);
         }
         this.tabControlLogins.ResumeLayout();
         this.tabControlLogins.Invalidate();
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         if (logins == null)
            logins = new Dictionary<string,Dictionary<string,string>>();

         ToolLinkedServerLogin login;
         Dictionary<string, string> usernames;

         foreach (DevComponents.DotNetBar.TabItem tab in tabControlLogins.Tabs)
         {
            usernames = new Dictionary<string, string>();

            foreach (Control control in tab.AttachedControl.Controls[0].Controls)
            {
               try
               {
                  login = (ToolLinkedServerLogin)control;

                  if (String.IsNullOrEmpty(login.Password))
                  {
                     Messaging.ShowError(this, "Passwords must be set for all logins.");
                     login.PasswordFocus();
                     return;
                  }
                  else
                  {
                     usernames.Add(login.Username, login.Password);
                  }
               }
               catch { }
            }
            logins.Add(tab.AttachedControl.Controls[0].Name, usernames);
         } 
         DialogResult = DialogResult.OK;
      }
   }
}