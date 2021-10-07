using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevComponents.DotNetBar;

using Idera.SqlAdminToolset.Core;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.SqlDiscovery
{
    public partial class Form_Main : Form
    {
        enum Task
        {
            ScanIPRange,
            ScanComputerList,
            ScanSQLServerList,
            ScanStealth
        }

        private Task selectedTask = Task.ScanIPRange;

        #region Constructor

        public Form_Main()
        {
            InitializeComponent();
            this.Text = ideraTitleBar1.IderaProductNameText;
        }
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x00C00000; // remove WS_CAPTION
                parms.Style |= 0x00040000;  // include WS_SIZEBOX
                return parms;
            }
        }
        #endregion

        #region OnLoad (Common)

        protected override void OnLoad(EventArgs e)
        {
            #region Common Onload code

            base.OnLoad(e);
            if (!Startup.GuiStartup(this, menuTools, menuAbout, ideraTitleBar1))
            {
                Close();
            }

            #endregion

            ProductConstants.mainform = this;

#if DEBUG
            buttonDoSameScan.Visible = true;
#endif

            // Program Specific Logic

            ProductConstants.ReadOptions();

            // Get Local IP;
            string localIP = Helpers.GetIP4AddressString();
            Globals.localIP = localIP;

            wizard.BringToFront();
        }

        #endregion

        #region Common Code

        #region File Menu Event Handlers (Common)

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuExitToLaunchpad_Click(object sender, EventArgs e)
        {
            Launchpad.RunAndClose(this);
        }

        #endregion

        #region Help Menu Event Handlers (Common)

        private void menuShowHelp_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowHelp();
        }

        private void menuDeacivateLicense_Click(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }

      

        private void menuAbout_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowAboutForm();
        }

        private void menuSearchIderaKnowledgeBase_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowURL_SearchIderaKnowledgeBase(this);
        }

        private void menuAboutIderaProducts_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowURL_AboutIderaProducts(this);
        }

        private void menuContactTechnicalSupport_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowURL_ContactTechnicalSupport(this);
        }

        private void menuCheckForUpdates_Click(object sender, EventArgs e)
        {
            HelpMenu.CheckForUpdates(this);
        }

        #endregion

        #region Tools Menu (Common )

        private void menuManageServerGroups_Click(object sender, EventArgs e)
        {
            ToolsMenu.ManageServerGroups();
        }

        private void menuToolsetOptions_Click(object sender, EventArgs e)
        {
            ToolsMenu.ShowToolsetOptions();
        }

        private void menuLaunchpad_Click(object sender, EventArgs e)
        {
            ToolsMenu.RunLaunchpad(this);
        }

        #endregion

        #endregion

        #region Wizard Routines

        private void wizard_WizardPageChanging(object sender, DevComponents.DotNetBar.WizardCancelPageChangeEventArgs e)
        {
            //------
            // NEXT
            //------
            if (e.PageChangeSource == DevComponents.DotNetBar.eWizardPageChangeSource.NextButton)
            {
                if (e.OldPage == pageSelectScanType)
                {
                    if (radioScanType_Ip.Checked)
                    {
                        selectedTask = Task.ScanIPRange;
                        e.NewPage = pageSelectIpRange;
                    }
                    else if (radioScanType_Computers.Checked)
                    {
                        selectedTask = Task.ScanComputerList;
                        e.NewPage = pageSelectComputers;
                    }
                    else if (radioScanType_SqlServers.Checked)
                    {
                        selectedTask = Task.ScanSQLServerList;
                        e.NewPage = pageSelectSqlServers;
                    }
                    else // Stealth
                    {
                        selectedTask = Task.ScanStealth;
                        e.NewPage = pageOptions_StealthScan;
                    }
                }
                else if (e.OldPage == pageSelectIpRange)
                {
                    if (!ValidateIpRange())
                    {
                        e.Cancel = true;
                        return;
                    }
                    e.NewPage = pageOptions_ActiveScan;
                }
                else if (e.OldPage == pageSelectComputers)
                {
                    if (!ValidateComputerList())
                    {
                        e.Cancel = true;
                        return;
                    }
                    e.NewPage = pageOptions_ActiveScan;
                }
                else if (e.OldPage == pageSelectSqlServers)
                {
                    if (!ValidateServerList())
                    {
                        e.Cancel = true;
                        return;
                    }
                    e.NewPage = pageOptions_ActiveScan;
                }
                else if (e.OldPage == pageOptions_ActiveScan)
                {
                    if (!ValidateScanSelection())
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                else if (e.OldPage == pageOptions_StealthScan)
                {
                    if (!ValidateScanSelection())
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            //------
            // BACK
            //------
            else if (e.PageChangeSource == DevComponents.DotNetBar.eWizardPageChangeSource.BackButton)
            {
                if (e.OldPage == pageSelectScanType)
                {
                    e.NewPage = pageWelcome;
                }
                else if (e.OldPage == pageSelectIpRange ||
                          e.OldPage == pageSelectComputers ||
                          e.OldPage == pageSelectSqlServers)
                {
                    e.NewPage = pageSelectScanType;
                }
                else if (e.OldPage == pageOptions_ActiveScan)
                {
                    if (selectedTask == Task.ScanIPRange)
                    {
                        e.NewPage = pageSelectIpRange;
                    }
                    else if (selectedTask == Task.ScanComputerList)
                    {
                        e.NewPage = pageSelectComputers;
                    }
                    else if (selectedTask == Task.ScanSQLServerList)
                    {
                        e.NewPage = pageSelectSqlServers;
                    }
                }
                else if (e.OldPage == pageOptions_StealthScan)
                {
                    e.NewPage = pageSelectScanType;
                }
            }
        }

        #region Validation

        private bool ValidateIpRange()
        {
            if (listIpAddresses.Items.Count == 0)
            {
                Messaging.ShowError("Specify IP addresses to scan");
                return false;
            }
            return true;
        }

        private bool ValidateComputerList()
        {
            if (textComputerList.Text.Length == 0)
            {
                Messaging.ShowError("Specify computer name(s) to scan");
                return false;
            }
            return true;
        }

        private bool ValidateServerList()
        {
            if (radioSelectServers.Checked)
            {
                if (textServer.Text.Length == 0)
                {
                    Messaging.ShowError("Specify SQL Server instance(s) to scan");
                    return false;
                }
            }
            else
            {
                if (textServerGroup.Text.Length == 0)
                {
                    Messaging.ShowError("Specify a Server Group to scan");
                    return false;
                }
            }
            return true;
        }

        private bool ValidateScanSelection()
        {
            if (selectedTask == Task.ScanStealth)
            {
                // make sure at least one option is checked
                if (!checkScan_BrowserService.Checked &&
                     !checkScan_ActiveDirectory.Checked)
                {
                    Messaging.ShowError("At least one type of probe must be selected to continue with the scan.");
                    return false;
                }
            }
            else
            {
                // make sure at least one option is checked
                if (!checkScan_UDP.Checked &&
                     !checkScan_TCP.Checked &&
                     !checkScan_WMI.Checked &&
                     !checkScan_SCM.Checked &&
                     !checkScan_Reg.Checked)
                {
                    Messaging.ShowError("At least one type of probe must be selected to continue with the scan.");
                    return false;
                }
            }
            return true;
        }

        #endregion

        private void wizard_FinishButtonClick(object sender, CancelEventArgs e)
        {
            bool inputValid = true;

            // validation
            if (!ValidateScanSelection())
                inputValid = false;
            else if (selectedTask == Task.ScanIPRange)
            {
                if (!ValidateIpRange())
                    inputValid = false;
            }
            else if (selectedTask == Task.ScanComputerList)
            {
                if (!ValidateComputerList())
                    inputValid = false;
            }
            else if (selectedTask == Task.ScanSQLServerList)
            {
                if (!ValidateServerList())
                    inputValid = false;
            }

            if (inputValid)
                PerformScan();
            else
                e.Cancel = true;
        }

        delegate void ChangePageDelegate(WizardPage newPage);

        private void ChangeWizardPage(WizardPage newPage)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ChangePageDelegate(ChangeWizardPage), new object[] { newPage });
                return;
            }
            wizard.SelectedPage = newPage;
        }

        private void wizard_CancelButtonClick(object sender, CancelEventArgs e)
        {
            Wizard wiz = (Wizard)sender;
            if (wiz.SelectedPageIndex > 1)
            {
                DialogResult choice = Messaging.ShowConfirmation("Are you sure you want to cancel this scan?");
                if (choice == DialogResult.Yes)
                {
                    ResetResults();
                    ChangeWizardPage(pageWelcome);
                }
            }
            else
            {
                Close();
            }
        }

        #endregion

        private void ResetValues()
        {
            // scan type
            radioScanType_Ip.Checked = true;
            selectedTask = Task.ScanIPRange;

            // ip
            listIpAddresses.Items.Clear();

            // sql server
            radioSelectServers.Checked = true;
            textServer.Text = "(local)";
            textServerGroup.Text = "";

            // computer
            textComputerList.Text = "";

            // active options
            checkScan_Reg.Checked = true;
            checkScan_SCM.Checked = true;
            checkScan_TCP.Checked = true;
            checkScan_UDP.Checked = true;
            checkScan_WMI.Checked = true;

            // stealthoptions
            checkScan_ActiveDirectory.Checked = true;
            checkScan_BrowserService.Checked = true;
        }

        private void ResetResults()
        {
            // result screen buttons        
            buttonCopyResultsToClipboard.Enabled = false;
            menuSelectAll.Enabled = false;
            menuExport.Enabled = false;
            contextMenuSelectAll.Enabled = false;
            contextMenuExport.Enabled = false;
            buttonSaveAsServerGroup.Enabled = false;
            contextMenuSaveAsServerGroup.Enabled = false;
        }

        delegate void UpdateProgressBarDelegate(string message);
        private void
           UpdateProgressBar(
              string message
           )
        {
            if (InvokeRequired)
            {
                BeginInvoke(new UpdateProgressBarDelegate(UpdateProgressBar), message);
                return;
            }

            progressBarScanning.Text = message;
        }

        delegate void WaitForScansToCompleteDelegate();
        private void WaitForScansToComplete()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new WaitForScansToCompleteDelegate(WaitForScansToComplete));
                return;
            }

            UpdateProgressBar("Waiting on scans to complete...");
            Application.DoEvents();
            ThreadCleanup();
            updateTreeView();
        }


        #region PerformScan

        private bool breakActivated;
        private Thread[] threads;

        private void PerformScan()
        {
            string not_able_to_reach_list = string.Empty;
            try
            {
                panelResults.BringToFront();
                this.AcceptButton = this.buttonDoAnotherScan; // without this the acceptbutton is left as
                                                              // the wizard finish but luckily the wizard 
                                                              // resets it when we enter for another scan

                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.MaximizeBox = true;

                // Initialize Results Screen
                breakActivated = false;
                buttonCancelScan.Enabled = true;
                buttonCancelScan.Visible = true;
                progressBarScanning.Visible = true;
                progressBarScanning.Text = "Scanning...";
                listServers.BeginUpdate();
                listServers.Items.Clear();
                ClearDetails();
                listServers.EndUpdate();
                labelNoServersFound.Visible = false;
                buttonDoAnotherScan.Enabled = false;
                buttonDoSameScan.Enabled = false;
                menuEdit.Enabled = false;
                menuTools.Enabled = false;
                labelScanHeading.Text = "Scan Results:";
                Application.DoEvents();

                lastSelectedIndex = -1;
                Globals.serversFound.Clear();

                threads = new Thread[ProductConstants.optionMaxThreads];

                // Get Data
                if (selectedTask == Task.ScanStealth)
                {
                    PerformStealthScan();
                }
                else
                {
                    not_able_to_reach_list = PerformActiveScan();
                }

                // Finalize Results Screen
                if (listServers.Items.Count > 0)
                {
                    listServers.Items[0].Selected = true;
                    listServers.Select();
                }
                else
                {
                    labelNoServersFound.Visible = true;
                }
            }
            finally
            {
                buttonCancelScan.Enabled = false;
                progressBarScanning.Text = "Scan Complete";

                if (listServers.Items.Count == 0)
                {
                    labelScanHeading.Text = "Scan Results: (No SQL Servers discovered)";
                }
                progressBarScanning.ProgressType = eProgressItemType.Standard;
                if (!string.IsNullOrEmpty(not_able_to_reach_list))
                {
                    Messaging.ShowError(String.Format(
                                "SQL discovery was unable to scan the following server(s) for SQL Server instances:\n{0}", not_able_to_reach_list));
                }
                buttonCopyResultsToClipboard.Enabled = true;
                menuSelectAll.Enabled = true;
                menuExport.Enabled = true;
                contextMenuSelectAll.Enabled = true;
                contextMenuExport.Enabled = true;
                buttonDoAnotherScan.Enabled = true;
                buttonDoSameScan.Enabled = true;
                buttonSaveAsServerGroup.Enabled = true;
                contextMenuSaveAsServerGroup.Enabled = true;
                menuEdit.Enabled = true;
                menuTools.Enabled = true;

                threads = null;
            }
        }

        #region Active Scan

        List<string> failedPingList;

        private string PerformActiveScan()
        {
            using (CoreGlobals.traceLog.DebugCall())
            {
                UpdateProgressBar("Performing Active Scan...");
                string not_able_to_reach_list = string.Empty;
                failedPingList = new List<string>();

                // Scan a list of IP addresses
                Queue ipq = new Queue();

                if (selectedTask == Task.ScanIPRange)
                {
                    foreach (ListViewItem lvi in listIpAddresses.Items)
                    {
                        string start, end;

                        if (ParseIpRange(lvi.Text, out start, out end))
                        {
                            if (end == "") end = start;

                            // loop through range
                            for (long ip = Utility.IPToLong(start); ip <= Utility.IPToLong(end); ip++)
                            {
                                string ipaddr = Utility.LongToIP(ip);

                                //Add range to queue if not already there		
                                if (!ipq.Contains(ipaddr))
                                {
                                    ipq.Enqueue(ipaddr);
                                }
                            }
                        }
                    }
                }
                else if (selectedTask == Task.ScanComputerList)
                {
                    // translate computer names into IP addresses
                    string[] computers = textComputerList.Text.Split(';');
                    for (int i = 0; i < computers.Length; i++) computers[i] = computers[i].Trim();

                    foreach (String computer in computers)
                    {
                        try
                        {
                            if (computer.ToUpper() == Dns.GetHostName().ToUpper())
                            {
                                string localIP = Helpers.GetIP4AddressString();

                                not_able_to_reach_list += PingTest(computer);
                                ipq.Enqueue(localIP);
                            }
                            else
                            {
                                IPHostEntry IP = Dns.GetHostEntry(computer);

                                not_able_to_reach_list += PingTest(computer);

                                if (!ipq.Contains(IP.AddressList[0].ToString()))
                                {
                                    ipq.Enqueue(IP.AddressList[0].ToString());
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            not_able_to_reach_list += "\n    " + computer + " - " + e.Message;
                            Application.DoEvents();
                        }
                    }
                }
                else if (selectedTask == Task.ScanSQLServerList)
                {
                    // translate SQL Server names into computer names and then into IP addresses
                    if (radioSelectServers.Checked)
                    {
                        string[] servers = textServer.Text.Split(';');
                        for (int i = 0; i < servers.Length; i++) servers[i] = servers[i].Trim();

                        foreach (String server in servers)
                        {
                            string host = SQLHelpers.GetInstanceHost(SQLHelpers.NormalizeInstanceName(server));

                            string ip = GetSQLServerIP(host);
                            if (ip == null)
                            {
                                not_able_to_reach_list += "\n    " + host + " - SQL Discovery could not obtain an IP address for this computer";

                                Application.DoEvents();
                            }
                            else if (!ipq.Contains(ip))
                            {
                                not_able_to_reach_list += PingTest(host);
                                ipq.Enqueue(ip);
                            }
                        }
                    }
                    else
                    {
                        // Server Group
                        foreach (ToolServer toolServer in (toolServerGroup.GetServers(true)))
                        {
                            string ip = GetSQLServerIP(toolServer.Name);
                            if (ip == null)
                            {

                                not_able_to_reach_list += "\n    " + toolServer.Name + " - SQL Discovery could not obtain an IP address for this computer";

                                Application.DoEvents();
                            }
                            else if (!ipq.Contains(ip))
                            {
                                string host = SQLHelpers.GetInstanceHost(SQLHelpers.NormalizeInstanceName(toolServer.Name));

                                not_able_to_reach_list += PingTest(host);
                                ipq.Enqueue(ip);
                            }
                        }
                    }
                }

                //this.Refresh();
                foreach (string ip in ipq)
                {
                    if (Utility.IsValid(ip))
                    {
                        ScanIP(Utility.IPToLong(ip));
                    }
                    //Application.DoEvents();
                    if (breakActivated)
                        break;
                }

                WaitForScansToComplete();
                return not_able_to_reach_list;
            }
        }

        private string PingTest(string computer)
        {
            if (!Globals.enableICMPCheck) return string.Empty;

            Ping png = new Ping();
            if (!png.CheckByNameOrIP(computer))
            {
                Application.DoEvents();
                return String.Format("\n    {0} - SQL Discovery could not obtain an IP address for this computer", computer);
            }

            return string.Empty;
        }

        private string
           GetSQLServerIP(
              string instanceName
           )
        {
            string ip = null;

            try
            {
                instanceName = SQLHelpers.NormalizeInstanceName(instanceName);
                string[] parts = instanceName.Split('\\');
                for (int i = 0; i < parts.Length; i++) parts[i] = parts[i].Trim();


                if (parts[0].ToUpper() == Dns.GetHostName().ToUpper())
                {
                    ip = Helpers.GetIP4AddressString();
                }
                else
                {
                    IPHostEntry IP = Dns.GetHostEntry(parts[0]);
                    ip = IP.AddressList[0].ToString();
                }
            }
            catch
            {
            }
            return ip;
        }


        private void ScanIP(long ip)
        {
            using (CoreGlobals.traceLog.DebugCall())
            {
                string txtIP = Utility.LongToIP(ip);

                UpdateProgressBar("Starting scan of " + txtIP);

                Ping png = new Ping(Globals.ICMPTimeout);

                bool pingSucceeded = true;

                if (Globals.enableICMPCheck)
                {
                    pingSucceeded = png.CheckByIpAddr(txtIP);
                    if (!pingSucceeded)
                    {
                        failedPingList.Add(txtIP);
                    }
                }

                if (!Globals.enableICMPCheck || pingSucceeded)
                {
                    //UDP 1434 Probe
                    if (checkScan_UDP.Checked)
                    {
                        try
                        {
                            Utility.WriteDebug(txtIP, "UDP Probe - Enter");
                            UdpCheck sp = new UdpCheck(Utility.LongToIP(ip), Globals.localSourcePort);
                            int thr = getNextThread();
                            threads[thr] = new Thread(new ThreadStart(sp.SendSingle));
                            threads[thr].IsBackground = true;
                            threads[thr].Priority = ThreadPriority.BelowNormal;
                            threads[thr].Start();
                            threads[thr].Join();
                            Utility.WriteDebug(txtIP, "UDP Probe - Leave");
                        }
                        catch (Exception ex)
                        {
                            Utility.WriteDebug(txtIP, "UDP Probe: Exception: " + ex.Message);
                        }
                    }

                    //Registry Probe
                    if (checkScan_Reg.Checked)
                    {
                        try
                        {
                            Utility.WriteDebug(txtIP, "REG Probe - Enter");
                            RegistryCheck sp1 = new RegistryCheck(Utility.LongToIP(ip), Globals.alternateUsername, Globals.alternatePassword, Globals.alternateDomain);
                            int thr = getNextThread();
                            threads[thr] = new Thread(new ThreadStart(sp1.Scan));
                            threads[thr].IsBackground = true;
                            threads[thr].Priority = ThreadPriority.BelowNormal;
                            threads[thr].Start();
                            Utility.WriteDebug(txtIP, "REG Probe - Leave");
                        }
                        catch (Exception ex2)
                        {
                            Utility.WriteDebug(txtIP, "REG Probe: Exception: " + ex2.Message);
                        }
                    }


                    //WMI Probe
                    if (checkScan_WMI.Checked)
                    {
                        try
                        {
                            Utility.WriteDebug(txtIP, "WMI Probe - Enter");
                            WMICheck sp1 = new WMICheck(Utility.LongToIP(ip), Globals.alternateUsername, Globals.alternatePassword, Globals.alternateDomain);
                            int thr = getNextThread();
                            threads[thr] = new Thread(new ThreadStart(sp1.Scan));
                            threads[thr].IsBackground = true;
                            threads[thr].Priority = ThreadPriority.BelowNormal;
                            threads[thr].Start();
                            Utility.WriteDebug(txtIP, "WMI Probe - Leave");
                        }
                        catch (Exception ex3)
                        {
                            Utility.WriteDebug(txtIP, String.Format("WMI Probe Exception - IP: {0} Message: {1}", ip, ex3.Message));
                        }
                    }

                    //PortScan Probe
                    if (checkScan_TCP.Checked)
                    {
                        try
                        {
                            Utility.WriteDebug(txtIP, "TCP Probe - Enter");

                            TcpCheck sp1 = new TcpCheck(Utility.LongToIP(ip), 1433, Globals.localSourcePort);
                            int thr1 = getNextThread();
                            threads[thr1] = new Thread(new ThreadStart(sp1.Scan));
                            threads[thr1].IsBackground = true;
                            threads[thr1].Priority = ThreadPriority.BelowNormal;
                            threads[thr1].Start();

                            TcpCheck sp2 = new TcpCheck(Utility.LongToIP(ip), 2433, Globals.localSourcePort);
                            int thr2 = getNextThread();
                            threads[thr2] = new Thread(new ThreadStart(sp2.Scan));
                            threads[thr2].IsBackground = true;
                            threads[thr2].Priority = ThreadPriority.BelowNormal;
                            threads[thr2].Start();

                            Utility.WriteDebug(txtIP, "TCP Probe - Leave");
                        }
                        catch (Exception ex4)
                        {
                            Utility.WriteDebug(txtIP, String.Format("TCP Probe Exception - IP: {0} Message: {1}", ip, ex4.Message));
                        }
                    }

                    //SCM Probe
                    if (checkScan_SCM.Checked)
                    {
                        try
                        {
                            Utility.WriteDebug(txtIP, "SCM Probe - Enter");
                            SCMCheck sp1 = new SCMCheck(Utility.LongToIP(ip), Globals.alternateUsername, Globals.alternatePassword, Globals.alternateDomain);
                            int thr = getNextThread();
                            threads[thr] = new Thread(new ThreadStart(sp1.Scan));
                            threads[thr].IsBackground = true;
                            threads[thr].Priority = ThreadPriority.BelowNormal;
                            threads[thr].Start();
                            Utility.WriteDebug(txtIP, "SCM Probe - Leave");
                        }
                        catch (Exception ex5)
                        {
                            Utility.WriteDebug(txtIP, String.Format("SCM Probe Exception - IP: {0} Message: {1}", ip, ex5.Message));
                        }
                    }
                }
                else
                {
                    Utility.WriteDebug(txtIP, "ScanIP: Skipping IP as ping test failed");
                }
            }
        }

        delegate void UpdateTreeViewDelegate();
        public void updateTreeView()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new UpdateTreeViewDelegate(updateTreeView));
                return;
            }

            try
            {
                listServers.SuspendLayout();
                listServers.Items.Clear();

                Dictionary<string, Result> results;
                results = Globals.serversFound;
                Result result = null;
                foreach (KeyValuePair<string, Result> kvp in results)
                {
                    result = kvp.Value;
                    string instance;

                    if (!String.IsNullOrEmpty(result.ServerName))
                    {
                        instance = result.ServerName;
                        if (!String.IsNullOrEmpty(result.InstanceName) && result.InstanceName != "MSSQLSERVER")
                        {
                            instance = String.Format("{0}\\{1}", instance, result.InstanceName);
                        }
                    }
                    else
                    {
                        instance = "N/A";
                    }
                    ListViewItem lvi = new ListViewItem(instance);
                    SetListViewItem(lvi, result);
                    listServers.Items.Add(lvi);
                }
                //Toggle back so that we won't update this again until changes are made
                Globals.datasetUpdated = false;
            }
            catch
            {
            }
            finally
            {
                listServers.ResumeLayout();
                labelScanHeading.Text = String.Format("Scan Results: ({0} SQL Servers discovered)", listServers.Items.Count);
                Application.DoEvents();
            }
        }

        delegate void PaintNewRowDelegate(Result result);
        public void PaintNewRow(Result result)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new PaintNewRowDelegate(PaintNewRow), result);
                return;
            }

            try
            {
                listServers.SuspendLayout();

                string instance;
                if (!String.IsNullOrEmpty(result.ServerName))
                {
                    instance = result.ServerName;
                    if (!String.IsNullOrEmpty(result.InstanceName) && result.InstanceName != "MSSQLSERVER")
                    {
                        instance = String.Format("{0}\\{1}", instance, result.InstanceName);
                    }
                }
                else
                {
                    instance = "N/A";
                }
                ListViewItem lvi = new ListViewItem(instance);
                SetListViewItem(lvi, result);
                listServers.Items.Add(lvi);
                labelScanHeading.Text = String.Format("Scan Results: ({0} SQL Servers discovered)", listServers.Items.Count);

                //Toggle back so that we won't update this again until changes are made
                Globals.datasetUpdated = false;
            }
            catch
            {
            }
            finally
            {
                listServers.ResumeLayout();
                Application.DoEvents();
            }
        }

        private void SetListViewItem(ListViewItem lvi, Result result)
        {
            string instance = lvi.SubItems[0].Text;

            lvi.SubItems.Clear();
            lvi.SubItems[0].Text = instance;
            lvi.SubItems.Add(result.ServerIP);
            lvi.SubItems.Add(result.ServerName);

            string version = "";
            if (!String.IsNullOrEmpty(result.TrueVersion))
                version = result.TrueVersion;
            else if (!String.IsNullOrEmpty(result.SSNetlibVersion))
                version = result.SSNetlibVersion;
            else if (!String.IsNullOrEmpty(result.BaseVersion))
                version = result.BaseVersion;
            if (version == "")
                version = "N/A";
            lvi.SubItems.Add(version);

            lvi.SubItems.Add(result.DetectionMethod);
            lvi.SubItems.Add(GetDisplayString(result.IsClustered));
            lvi.SubItems.Add(GetDisplayString(result.TCPPort));
            lvi.SubItems.Add(GetDisplayString(result.ServiceAccount));
            lvi.SubItems.Add(GetDisplayString(result.SSNetlibVersion));
            lvi.Tag = result;
        }

        private string GetDisplayString(string s)
        {
            if (String.IsNullOrEmpty(s))
                return "N/A";
            else
                return s;
        }

        enum BlankPasswordType
        {
            Succeeded,
            Failed,
            Unknown
        }

        private void
           HighlightRow(
              ListViewItem lvi,
              BlankPasswordType passwordType
           )
        {
            // Figure out background color for Row
            Color backColor = Color.White;
            if (passwordType == BlankPasswordType.Unknown)
            {
                backColor = Color.Yellow;
            }
            else if (passwordType == BlankPasswordType.Succeeded)
            {
                backColor = Color.Red;
            }

            // Draw Row
            lvi.SubItems[5].BackColor = backColor;
        }

        #endregion

        #region Stealth Scan

        private void PerformStealthScan()
        {
            UpdateProgressBar("Performing Stealth Scan...");
            System.Threading.Thread.Sleep(200); // let them read this message

            //Browser Service Probe
            if (checkScan_BrowserService.Checked && !breakActivated)
            {
                UpdateProgressBar("Performing Browser Service Probe...");
                BrowserCheck sp1 = new BrowserCheck();

                int thr = getNextThread();
                threads[thr] = new Thread(new ThreadStart(sp1.Scan));
                threads[thr].IsBackground = true;
                threads[thr].Priority = ThreadPriority.BelowNormal;
                threads[thr].Start();
                while (threads[thr].IsAlive && !breakActivated)
                {
                    Application.DoEvents();
                    Thread.Sleep(1000);
                }
                try { if (threads[thr].IsAlive) threads[thr] = null; } catch { }
            }

            // Active Directory Scan
            if (checkScan_ActiveDirectory.Checked && !breakActivated)
            {
                UpdateProgressBar("Performing Active Directory Probe...");

                ActiveDirectoryCheck sp1 = new ActiveDirectoryCheck(Globals.alternateUsername,
                                                                     Globals.alternatePassword,
                                                                     Globals.alternateDomain);

                int thr = getNextThread();
                threads[thr] = new Thread(new ThreadStart(sp1.Scan));
                threads[thr].IsBackground = true;
                threads[thr].Priority = ThreadPriority.BelowNormal;
                threads[thr].Start();
                while (threads[thr].IsAlive && !breakActivated)
                {
                    Application.DoEvents();
                    Thread.Sleep(1000);
                }
                try { if (threads[thr].IsAlive) threads[thr] = null; } catch { }
            }

            WaitForScansToComplete();
        }

        #endregion

        private void buttonCancelScan_Click(object sender, EventArgs e)
        {
            breakActivated = true;
            buttonCancelScan.Enabled = false;
            progressBarScanning.Text = "Scan cancelled - waiting for scans to end...";
        }

        private void ClearDetails()
        {
            groupDetails.Text = "Details";
            textDetails_BaseVersion.Text = "";
            textDetails_Computer.Text = "";
            textDetails_IP.Text = "";
            textDetails_IsClustered.Text = "";
            textDetails_Port.Text = "";
            textDetails_ServiceAccount.Text = "";
            textDetails_SSNetLibVersion.Text = "";

            listViewDetails.BeginUpdate();
            listViewDetails.Items.Clear();
            listViewDetails.EndUpdate();
        }

        int lastSelectedIndex = -1; // -1 = none selected, -2 = > 1 selected

        private void listServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupDetails.SuspendLayout();

            if ((listServers.SelectedIndices.Count == 0 && lastSelectedIndex != -1)
              || (listServers.SelectedIndices.Count > 1 && lastSelectedIndex != -2)
              || (listServers.SelectedIndices.Count == 1 && lastSelectedIndex != listServers.SelectedIndices[0]))
            {
                if (listServers.SelectedItems.Count == 0)
                {
                    ClearDetails();
                    lastSelectedIndex = -1;
                }
                else if (listServers.SelectedItems.Count > 1)
                {
                    ClearDetails();
                    groupDetails.Text = "Details: <Multiple Servers Selected>";
                    lastSelectedIndex = -2;
                }
                else if (listServers.SelectedItems.Count == 1)
                {
                    lastSelectedIndex = listServers.SelectedIndices[0];
                    SetDetails();
                }

                groupDetails.ResumeLayout();

                bool enabled = (listServers.SelectedItems.Count > 0);

                menuCopy.Enabled = enabled;
                contextMenuCopy.Enabled = enabled;
            }
        }

        private void SetDetails()
        {
            Result result = (Result)listServers.SelectedItems[0].Tag;

            groupDetails.Text = listServers.SelectedItems[0].Text;

            string version = "";
            if (!String.IsNullOrEmpty(result.TrueVersion))
                version = result.TrueVersion;
            else if (!String.IsNullOrEmpty(result.SSNetlibVersion))
                version = result.SSNetlibVersion;
            else if (!String.IsNullOrEmpty(result.BaseVersion))
                version = result.BaseVersion;
            if (version == "")
                version = "N/A";
            textDetails_BaseVersion.Text = version;

            textDetails_Computer.Text = result.ServerName;
            textDetails_IP.Text = result.ServerIP;
            textDetails_IsClustered.Text = GetDisplayString(result.IsClustered);
            textDetails_Port.Text = GetDisplayString(result.TCPPort);
            textDetails_ServiceAccount.Text = GetDisplayString(result.ServiceAccount);
            textDetails_SSNetLibVersion.Text = GetDisplayString(result.SSNetlibVersion);

            listViewDetails.BeginUpdate();
            listViewDetails.Items.Clear();

            ListViewItem lvi;

            foreach (string det in result.Details.Split("\t".ToCharArray()))
            {
                string[] parts = det.Split(';');

                for (int i = 0; i < parts.Length; i++)
                    parts[i] = parts[i].Trim();

                lvi = listViewDetails.Items.Add(parts[0]);

                string details = "";
                for (int i = 1; i < parts.Length; i++)
                {
                    if (details != "") details += ";";
                    details += parts[i];
                }
                lvi.SubItems.Add(details);
            }
            listViewDetails.EndUpdate();
        }


        #endregion

        #region Thread Pool Management

        private int getNextThread()
        {
            int j = -1;
            bool found = false;
            while (!found)
            {
                j = -1;
                foreach (Thread thr in threads)
                {
                    j++;
                    try
                    {
                        if ((thr == null) || (!thr.IsAlive))
                        {
                            found = true;
                            break;
                        }
                    }
                    catch
                    {
                        found = true;
                        break;
                    }
                }
                Application.DoEvents();
                Thread.Sleep(362); // sleep until my birthday
            }
            return j;
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            int liveThreads = 0;
            for (int i = 0; i < ProductConstants.optionMaxThreads; i++)
            {
                try
                {
                    if ((threads[i] != null) && (threads[i].IsAlive))
                    {
                        liveThreads++;
                    }
                }
                catch
                { }
            }
        }

        private void ThreadCleanup()
        {
            bool anyAlive = true;
            int pass = 0;
            while (anyAlive == true && !breakActivated)  // && pass < 20  <-- stop from hanging
            {
                anyAlive = false;
                for (int i = 0; i < ProductConstants.optionMaxThreads; i++)
                {
                    try
                    {
                        if ((threads[i] != null) && threads[i].IsAlive)
                        {
                            anyAlive = true;
                        }

                        try { if (!threads[i].IsAlive) threads[i] = null; }
                        catch { }
                    }
                    catch
                    { }
                }
                Application.DoEvents();
                pass++;
                Thread.Sleep(500);
            }

            for (int i = 0; i < ProductConstants.optionMaxThreads; i++)
            {
                try
                {
                    if (threads[i] != null)
                    {
                        if (threads[i].IsAlive) threads[i].Abort();
                        threads[i] = null;
                    }
                }
                catch
                { }
            }
        }

        #endregion

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonDoAnotherScan_Click(object sender, EventArgs e)
        {
            // change back to unsizeable wizard screen
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Height = 628;
            this.Width = 920;
            this.MaximizeBox = false;

            ResetResults();
            ChangeWizardPage(pageSelectScanType);
            wizard.BringToFront();
        }

        private void securityScannerOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Options frm = new Form_Options();
            frm.ShowDialog();
        }


        #region Select SQL Servers

        ToolServerGroup toolServerGroup;

        private void radioSelectServers_CheckedChanged(object sender, EventArgs e)
        {
            textServer.Enabled = radioSelectServers.Checked;
        }

        private void radioSelectGroups_CheckedChanged(object sender, EventArgs e)
        {
            textServer.Enabled = radioSelectServers.Checked;
        }

        private void buttonBrowseServer_Click(object sender, EventArgs e)
        {
            Form_SQLServerBrowse browseDlg = new Form_SQLServerBrowse();
            browseDlg.MultiSelect = true;

            Cursor = Cursors.WaitCursor;
            bool loaded = browseDlg.LoadServers();
            Cursor = Cursors.Default;

            if (loaded)
            {
                DialogResult choice = browseDlg.ShowDialog();
                if (choice == DialogResult.OK)
                {
                    if (textServer.Text != browseDlg.SelectedServer)
                    {
                        textServer.Text = browseDlg.SelectedServer;
                    }
                    radioSelectServers.Checked = true;
                }
            }
        }

        private void buttonBrowseGroups_Click(object sender, EventArgs e)
        {
            Form_ServerGroupBrowse dlg = new Form_ServerGroupBrowse();
            DialogResult choice = dlg.ShowDialog();
            if (choice == DialogResult.OK)
            {
                toolServerGroup = dlg.SelectedGroup;
                textServerGroup.Text = dlg.FullPath;

                radioSelectGroups.Checked = true;
            }
        }

        #endregion

        #region Select Computers

        private void buttonBrowseFroComputers_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Clipboard / Save Results As

        private void buttonCopyResultsToClipboard_Click(object sender, EventArgs e)
        {
            CopyToClipboard(false);
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard(true);
        }
        private void contextMenuCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard(true);
        }

        private void CopyToClipboard(bool selectedOnly)
        {
            ExportToClipboard.CopyListViewToTabbedFormat(listServers, false, selectedOnly);
        }

        private void menuSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void contextMenuSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void SelectAll()
        {
            foreach (ListViewItem lvi in listServers.Items)
            {
                lvi.Selected = true;
            }
        }

        private void menuExportAsCSV_Click(object sender, EventArgs e)
        {
            ExportToCSV.CopyListView(listServers);
        }
        private void contextExportAsCSV_Click(object sender, EventArgs e)
        {
            ExportToCSV.CopyListView(listServers);
        }

        private void menuExportAsXML_Click(object sender, EventArgs e)
        {
            ExportToXML.CopyListView(listServers, "Discovered Servers", true);
        }
        private void contextExportAsXML_Click(object sender, EventArgs e)
        {
            ExportToXML.CopyListView(listServers, "Discovered Servers", true);
        }

        #endregion

        #region Save as TXT (IP List)

        private void menuExportAsTXT_Click(object sender, EventArgs e)
        {
            SaveIPList();
        }
        private void contextExportAsTXT_Click(object sender, EventArgs e)
        {
            SaveIPList();
        }

        private void SaveIPList()
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text File|*.txt";
            saveFileDialog1.Title = "Save Scan IP List";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                try
                {
                    // load queue of unique IP addresses
                    Queue ipq = new Queue();
                    for (int i = 0; i < listServers.Items.Count; i++)
                    {
                        string ip = listServers.Items[i].SubItems[1].Text;
                        if (!ipq.Contains(ip))
                        {
                            ipq.Enqueue(ip);
                        }
                    }

                    // Saves the Image via a FileStream created by the OpenFile method.
                    using (StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile()))
                    {
                        foreach (string ipAddr in ipq)
                        {
                            sw.WriteLine(ipAddr);
                        }
                        sw.Close();
                    }


                    Messaging.ShowInformation("Save IP List Complete.");
                }
                catch (Exception ex)
                {
                    Messaging.ShowException("Save IP List Failed.", ex);
                }
            }
        }

        #endregion

        private void wizard_WizardPageChanged(object sender, WizardPageChangeEventArgs e)
        {
            // we have to reselect the radio buttons on the first tab when we re-enter it because of a bug in the wizard control
            if (e.NewPage == pageSelectScanType)
            {
                if (selectedTask == Task.ScanComputerList)
                {
                    radioScanType_Computers.Checked = true;
                }
                else if (selectedTask == Task.ScanSQLServerList)
                {
                    radioScanType_SqlServers.Checked = true;
                }
                else if (selectedTask == Task.ScanStealth)
                {
                    radioScanType_Stealth.Checked = true;
                }
                else
                {
                    radioScanType_Ip.Checked = true;
                }
            }
        }

        #region Save as Server Group

        private void buttonSaveAsServerGroup_Click(object sender, EventArgs e)
        {
            SaveServerGroup();
        }

        private void contextMenuSaveAsServerGroup_Click(object sender, EventArgs e)
        {
            SaveServerGroup();
        }

        private void SaveServerGroup()
        {
            // get servers
            if (listServers.Items.Count == 0) return;

            List<string> serverList = new List<string>();
            for (int i = 0; i < listServers.Items.Count; i++)
            {
                if (!serverList.Contains(listServers.Items[i].Text))
                {
                    serverList.Add(listServers.Items[i].Text);
                }
            }

            // show dialog      
            Form_SaveServersAsServerGroup frm = new Form_SaveServersAsServerGroup(serverList.ToArray());
            DialogResult choice = frm.ShowDialog();
            if (choice == DialogResult.OK)
            {
                CoreGlobals.ServerGroupList.RaiseServerGroupsChangedEvent();
                Messaging.ShowInformation("Server Group saved");
            }
        }

        #endregion

        #region Column Sorting

        private int sortColumn = -1;
        private System.Windows.Forms.SortOrder sortOrder = System.Windows.Forms.SortOrder.Ascending;

        private void ResetSort()
        {
            sortColumn = -1;
            listServers.Sorting = sortOrder;
        }

        private void listResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;

                // Set the sort order to ascending by default.
                listServers.Sorting = sortOrder;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listServers.Sorting == System.Windows.Forms.SortOrder.Ascending)
                    listServers.Sorting = System.Windows.Forms.SortOrder.Descending;
                else
                    listServers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            }

            listServers.ListViewItemSorter = new ListViewItemComparer(e.Column, listServers.Sorting);
            listServers.Sort();
        }

        // Implements the manual sorting of items by column.
        class ListViewItemComparer : IComparer
        {
            private int col;
            private System.Windows.Forms.SortOrder order;

            public ListViewItemComparer()
            {
                col = 0;
                order = System.Windows.Forms.SortOrder.Ascending;
            }

            public ListViewItemComparer(int column, System.Windows.Forms.SortOrder order)
            {
                col = column;
                this.order = order;
            }

            public int Compare(object x, object y)
            {
                int returnVal = -1;

                if (col == 1) // ip
                {
                    returnVal = Helpers.CompareIP(((ListViewItem)x).SubItems[col].Text,
                                                   ((ListViewItem)y).SubItems[col].Text);
                }
                else if (col == 3 || col == 8) // version
                {
                    returnVal = Helpers.CompareVersionString(((ListViewItem)x).SubItems[col].Text,
                                                              ((ListViewItem)y).SubItems[col].Text);
                }
                else if (col == 6) // port
                {
                    returnVal = Helpers.CompareIntString(((ListViewItem)x).SubItems[col].Text,
                                                          ((ListViewItem)y).SubItems[col].Text);
                }
                else // the rest are simple strings
                {
                    returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                                ((ListViewItem)y).SubItems[col].Text);
                }

                if (order == System.Windows.Forms.SortOrder.Descending) returnVal *= -1;

                return returnVal;
            }
        }
        #endregion

        private void CheckServerPasswords()
        {
            // get servers
            if (listServers.Items.Count == 0) return;

            List<ServerForPassword> serverList = new List<ServerForPassword>();

            foreach (ListViewItem lvi in listServers.Items)
            {
                ServerForPassword newEntry = new ServerForPassword(lvi.Text, lvi.Selected);
                if (!serverList.Contains(newEntry))
                {
                    serverList.Add(newEntry);
                }
            }

            // show dialog      
            Form_CheckServerPasswords frm = new Form_CheckServerPasswords(serverList);
            frm.ShowDialog();
        }

        private void ShowF1Help(object sender, HelpEventArgs hlpevent)
        {
            HelpMenu.ShowHelp();
        }

        private void buttonDoSameScan_Click(object sender, EventArgs e)
        {
            PerformScan();
        }

        private void AddIpRangeToList(string start, bool showError)
        {
            AddIpRangeToList(start, "", showError);
        }

        private void AddIpRangeToList(string start, string end, bool showError)
        {
            string newEntry = "";
            string msg = "";
            if (end.Length == 0 || start == end)
            {
                newEntry = String.Format("{0}", start);
                msg = "address";
            }
            else
            {
                newEntry = String.Format("{0} - {1}", start, end);
                msg = "address range";
            }

            if (ListContainsRange(newEntry))
            {
                if (showError)
                {
                    Messaging.ShowError(String.Format("The IP {0} '{1}' is already specified in the list of addresses to be searched.",
                                                        msg, newEntry));
                }
            }
            else
            {
                listIpAddresses.Items.Add(newEntry);
                buttonSelectAll.Enabled =
                buttonUnselectAll.Enabled =
                buttonSaveIpList.Enabled = true;
            }
        }

        private bool ListContainsRange(string range)
        {
            bool found = false;

            foreach (ListViewItem lvi in listIpAddresses.Items)
            {
                if (lvi.Text == range)
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        private bool ParseIpRange(string range, out string start, out string end)
        {
            // look for forms
            //    (1) 255.255.255.255
            //    (2) 255.255.255.255 to 255.255.255.255
            //    (3) 255.255.255.255 - 255.255.255.255
            bool valid = false;

            bool dashFound = false;
            int pos = range.IndexOf("-");
            if (pos != -1)
                dashFound = true;
            else
                pos = range.IndexOf("to");

            if (pos == -1)
            {
                start = range.Trim();
                end = "";
            }
            else
            {
                start = range.Substring(0, pos).Trim();
                if (dashFound)
                    end = range.Substring(pos + 1).Trim();
                else
                    end = range.Substring(pos + 2).Trim();
            }

            if (Utility.ValidateIPAddress(start))
            {
                if (end.Trim().Length == 0 || end == start)
                {
                    valid = true;
                }
                else
                {
                    if (Utility.ValidateIPAddress(end))
                    {
                        if (Utility.ValidateSameSubnet(start, end))
                        {
                            valid = true;
                        }
                    }
                }
            }

            if (!valid)
            {
                start = "";
                end = "";
            }

            return valid;
        }

        private void buttonAddIpRange_Click(object sender, EventArgs e)
        {
            Form_AddIpRange frm = new Form_AddIpRange();
            DialogResult choice = frm.ShowDialog();
            if (choice == DialogResult.OK)
            {
                AddIpRangeToList(frm.StartingIp, frm.EndingIp, true);
            }
        }

        private void buttonLoadIpList_Click(object sender, EventArgs e)
        {
            Form_AddLoadIP frm = new Form_AddLoadIP();
            DialogResult choice = frm.ShowDialog();
            if (choice == DialogResult.OK)
            {
                // read IP List from file
                try
                {
                    StreamReader sr = new StreamReader(frm.FileName);

                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        string start, end;

                        if (ParseIpRange(line, out start, out end))
                        {
                            AddIpRangeToList(start, end, false);
                        }

                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    string msg = String.Format("Could not load IP address from {0}.\r\nError: {1}", frm.FileName, ex);
                    Messaging.ShowError(msg);
                }
            }
        }

        private void buttonAddLocalComputer_Click(object sender, EventArgs e)
        {
            try
            {
                string localIP = Helpers.GetIP4AddressString();
                if (localIP.Length > 0)
                {
                    AddIpRangeToList(localIP, true);
                }
            }
            catch { }
        }

        private void buttonAddLocalSubnet_Click(object sender, EventArgs e)
        {
            try
            {
                string localIP = Helpers.GetIP4AddressString();
                if (localIP.Length > 0)
                {
                    string start = localIP.Substring(0, localIP.LastIndexOf(".") + 1) + "1";
                    string end = localIP.Substring(0, localIP.LastIndexOf(".") + 1) + "254";

                    AddIpRangeToList(start, end, true);
                }
            }
            catch { }
        }

        private void listIpAddresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemoveIpAddress.Enabled = (listIpAddresses.SelectedItems.Count != 0);
        }

        private void buttonRemoveIpAddress_Click(object sender, EventArgs e)
        {
            if (listIpAddresses.SelectedItems.Count == 0) return;

            int ndx = -1;

            while (listIpAddresses.SelectedIndices.Count != 0)
            {
                if (ndx == -1 || listIpAddresses.SelectedIndices[0] < ndx) ndx = listIpAddresses.SelectedIndices[0];
                listIpAddresses.Items[listIpAddresses.SelectedIndices[0]].Remove();
            }

            if (listIpAddresses.Items.Count > 0)
            {
                if (ndx > listIpAddresses.Items.Count - 1)
                    listIpAddresses.Items[listIpAddresses.Items.Count - 1].Selected = true;
                else
                    listIpAddresses.Items[ndx].Selected = true;
            }
            else
            {
                buttonSelectAll.Enabled =
                buttonUnselectAll.Enabled =
                buttonSaveIpList.Enabled = false;
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listIpAddresses.Items)
            {
                lvi.Selected = true;
            }
        }

        private void buttonUnselectAll_Click(object sender, EventArgs e)
        {
            listIpAddresses.SelectedItems.Clear();
        }

        private void buttonSaveIpList_Click(object sender, EventArgs e)
        {
            SaveFileDialog _FileDialog = new SaveFileDialog();
            _FileDialog.Title = "Save IP List to File";
            _FileDialog.AddExtension = true;
            _FileDialog.CheckPathExists = true;
            _FileDialog.OverwritePrompt = true;
            _FileDialog.DefaultExt = "txt";
            _FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _FileDialog.FileName = CoreGlobals.productName + ".txt";
            _FileDialog.Filter = "TXT File (Text File)(*.txt)|*.txt|All files (*.*)|*.*";

            if (_FileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(_FileDialog.FileName))
                {
                    try
                    {
                        File.Delete(_FileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        Messaging.ShowError(
                           String.Format("An error occurred trying to overwrite the existing file.\r\n\r\nError: {0}",
                                          ex.Message));
                        return; // we cant write so just give up                                 
                    }
                }

                using (FileStream _Stream = new FileStream(_FileDialog.FileName, FileMode.Create, FileAccess.Write))
                using (StreamWriter _Writer = new StreamWriter(_Stream))
                {
                    foreach (ListViewItem lvi in listIpAddresses.Items)
                    {
                        _Writer.WriteLine(lvi.Text);
                    }
                }
            }

        }

        private void menuHelp_Click(object sender, EventArgs e)
        {
            
            base.OnClick(e);
        }

        private void ideraTitleBar1_LicenseInfoButtonClick(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }
    }

    public class ServerForPassword
    {
        public string name = "";
        public bool selected = false;

        public ServerForPassword(string inName, bool inSelected)
        {
            name = inName;
            selected = inSelected;
        }
    }
}

