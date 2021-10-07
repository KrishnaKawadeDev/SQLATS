using System.Windows.Forms;

namespace Idera.SqlAdminToolset.ConnectionStringGenerator
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textServer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelServer = new System.Windows.Forms.Label();
            this.labelBasicPort = new System.Windows.Forms.Label();
            this.labelDatabase = new System.Windows.Forms.Label();
            this.labelConnectionLifetime = new System.Windows.Forms.Label();
            this.checkConnectionReset = new System.Windows.Forms.CheckBox();
            this.labelMinPoolSize = new System.Windows.Forms.Label();
            this.labelMaxPoolSize = new System.Windows.Forms.Label();
            this.checkPooling = new System.Windows.Forms.CheckBox();
            this.textDatabase = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.checkEncrypt = new System.Windows.Forms.CheckBox();
            this.labelApplicationName = new System.Windows.Forms.Label();
            this.textApplicationName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelConnectionTimeout = new System.Windows.Forms.Label();
            this.textPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textLoginName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelLogin = new System.Windows.Forms.Label();
            this.radioSQL = new System.Windows.Forms.RadioButton();
            this.radioWindows = new System.Windows.Forms.RadioButton();
            this.comboNetworkLibrary = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.textDriver = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textFailoverPartner = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.radioLibraryDefault = new System.Windows.Forms.RadioButton();
            this.textNamedPipe = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.radioLibraryBanyan = new System.Windows.Forms.RadioButton();
            this.radioLibraryAppleTalk = new System.Windows.Forms.RadioButton();
            this.radioLibraryNWLink = new System.Windows.Forms.RadioButton();
            this.radioLibrarySharedMemory = new System.Windows.Forms.RadioButton();
            this.radioLibraryMulti = new System.Windows.Forms.RadioButton();
            this.radioLibraryNamedPipes = new System.Windows.Forms.RadioButton();
            this.radioLibraryTCPIP = new System.Windows.Forms.RadioButton();
            this.radioMultiLocalProc = new System.Windows.Forms.RadioButton();
            this.radioMultiIPX = new System.Windows.Forms.RadioButton();
            this.radioMultiUDP = new System.Windows.Forms.RadioButton();
            this.radioMultiBanyan = new System.Windows.Forms.RadioButton();
            this.radioMultiSPX = new System.Windows.Forms.RadioButton();
            this.radioMultiNetBios = new System.Windows.Forms.RadioButton();
            this.radioMultiTCPIP = new System.Windows.Forms.RadioButton();
            this.radioMultiNamedPipes = new System.Windows.Forms.RadioButton();
            this.labelFailoverPartner = new System.Windows.Forms.Label();
            this.labelDriver = new System.Windows.Forms.Label();
            this.textCurrentLanguage = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelPacketSize = new System.Windows.Forms.Label();
            this.labelCurrentLanguage = new System.Windows.Forms.Label();
            this.labelProvider = new System.Windows.Forms.Label();
            this.textAttachFileDB = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textWorkstation = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.checkAsynchronousProcessing = new System.Windows.Forms.CheckBox();
            this.labelWorkstation = new System.Windows.Forms.Label();
            this.checkEnlist = new System.Windows.Forms.CheckBox();
            this.textProvider = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.checkMARSConnection = new System.Windows.Forms.CheckBox();
            this.labelNetworkLibrary = new System.Windows.Forms.Label();
            this.checkPersistSecurityInfo = new System.Windows.Forms.CheckBox();
            this.labelAttachFileDB = new System.Windows.Forms.Label();
            this.buttonCopyToClipboard = new System.Windows.Forms.Button();
            this.buttonResetDefaults = new System.Windows.Forms.Button();
            this.buttonTestConnection = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuResetDefaults = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitToLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManageServerGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolsetOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuLaunchpad = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContactTechnicalSupport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.manuManageLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAboutIderaProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolProductBanner = new System.Windows.Forms.Panel();
            this.labelTitle = new DevComponents.DotNetBar.LabelX();
            this.labelSubtitle = new DevComponents.DotNetBar.LabelX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.groupConnectionString = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textConnectionString = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tabControl2 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupBasic = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textConnectionTimeout = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
            this.textBasicPort = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
            this.groupConnectUsing = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupConnectionPool = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textConnectionLifetime = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
            this.textMinPoolSize = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
            this.textMaxPoolSize = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupAdvanced = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textPacketSize = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
            this.groupNetworkLibrary = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textAdvancedPort = new Idera.SqlAdminToolset.Core.ToolNumericTextBox();
            this.groupMultiprotocol = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.ideraTitleBar1 = new IderaTrialExperienceCommon.Controls.IderaTitleBar();
            this.menuStrip1.SuspendLayout();
            this.toolProductBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.groupConnectionString.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.groupBasic.SuspendLayout();
            this.groupConnectUsing.SuspendLayout();
            this.groupConnectionPool.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.groupAdvanced.SuspendLayout();
            this.groupNetworkLibrary.SuspendLayout();
            this.groupMultiprotocol.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(326, 5);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(25, 20);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textServer
            // 
            // 
            // 
            // 
            this.textServer.Border.Class = "TextBoxBorder";
            this.textServer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textServer.Location = new System.Drawing.Point(151, 5);
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(173, 20);
            this.textServer.TabIndex = 1;
            this.textServer.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.BackColor = System.Drawing.Color.Transparent;
            this.labelServer.Location = new System.Drawing.Point(6, 8);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(65, 13);
            this.labelServer.TabIndex = 0;
            this.labelServer.Text = "SQL Server:";
            // 
            // labelBasicPort
            // 
            this.labelBasicPort.AutoSize = true;
            this.labelBasicPort.BackColor = System.Drawing.Color.Transparent;
            this.labelBasicPort.Location = new System.Drawing.Point(6, 35);
            this.labelBasicPort.Name = "labelBasicPort";
            this.labelBasicPort.Size = new System.Drawing.Size(139, 13);
            this.labelBasicPort.TabIndex = 3;
            this.labelBasicPort.Text = "TCP/IP Port (default=1433):";
            // 
            // labelDatabase
            // 
            this.labelDatabase.AutoSize = true;
            this.labelDatabase.BackColor = System.Drawing.Color.Transparent;
            this.labelDatabase.Location = new System.Drawing.Point(6, 61);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(134, 13);
            this.labelDatabase.TabIndex = 5;
            this.labelDatabase.Text = "Database or Initial Catalog:";
            // 
            // labelConnectionLifetime
            // 
            this.labelConnectionLifetime.AutoSize = true;
            this.labelConnectionLifetime.BackColor = System.Drawing.Color.Transparent;
            this.labelConnectionLifetime.Location = new System.Drawing.Point(6, 83);
            this.labelConnectionLifetime.Name = "labelConnectionLifetime";
            this.labelConnectionLifetime.Size = new System.Drawing.Size(126, 13);
            this.labelConnectionLifetime.TabIndex = 23;
            this.labelConnectionLifetime.Text = "Connection Lifetime (sec)";
            // 
            // checkConnectionReset
            // 
            this.checkConnectionReset.AutoSize = true;
            this.checkConnectionReset.Checked = true;
            this.checkConnectionReset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkConnectionReset.Location = new System.Drawing.Point(9, 106);
            this.checkConnectionReset.Name = "checkConnectionReset";
            this.checkConnectionReset.Size = new System.Drawing.Size(305, 17);
            this.checkConnectionReset.TabIndex = 25;
            this.checkConnectionReset.Text = "Reset database connection when being removed from pool";
            this.checkConnectionReset.UseVisualStyleBackColor = true;
            this.checkConnectionReset.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // labelMinPoolSize
            // 
            this.labelMinPoolSize.AutoSize = true;
            this.labelMinPoolSize.BackColor = System.Drawing.Color.Transparent;
            this.labelMinPoolSize.Location = new System.Drawing.Point(5, 57);
            this.labelMinPoolSize.Name = "labelMinPoolSize";
            this.labelMinPoolSize.Size = new System.Drawing.Size(127, 13);
            this.labelMinPoolSize.TabIndex = 21;
            this.labelMinPoolSize.Text = "Min Pool Size: (default=0)";
            // 
            // labelMaxPoolSize
            // 
            this.labelMaxPoolSize.AutoSize = true;
            this.labelMaxPoolSize.BackColor = System.Drawing.Color.Transparent;
            this.labelMaxPoolSize.Location = new System.Drawing.Point(5, 31);
            this.labelMaxPoolSize.Name = "labelMaxPoolSize";
            this.labelMaxPoolSize.Size = new System.Drawing.Size(142, 13);
            this.labelMaxPoolSize.TabIndex = 19;
            this.labelMaxPoolSize.Text = "Max Pool Size: (default=100)";
            // 
            // checkPooling
            // 
            this.checkPooling.AutoSize = true;
            this.checkPooling.Checked = true;
            this.checkPooling.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPooling.Location = new System.Drawing.Point(8, 7);
            this.checkPooling.Name = "checkPooling";
            this.checkPooling.Size = new System.Drawing.Size(140, 17);
            this.checkPooling.TabIndex = 18;
            this.checkPooling.Text = "Use Connection Pooling";
            this.checkPooling.UseVisualStyleBackColor = true;
            this.checkPooling.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // textDatabase
            // 
            // 
            // 
            // 
            this.textDatabase.Border.Class = "TextBoxBorder";
            this.textDatabase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textDatabase.Location = new System.Drawing.Point(151, 58);
            this.textDatabase.Name = "textDatabase";
            this.textDatabase.Size = new System.Drawing.Size(201, 20);
            this.textDatabase.TabIndex = 6;
            this.textDatabase.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // checkEncrypt
            // 
            this.checkEncrypt.AutoSize = true;
            this.checkEncrypt.BackColor = System.Drawing.Color.Transparent;
            this.checkEncrypt.Location = new System.Drawing.Point(8, 141);
            this.checkEncrypt.Name = "checkEncrypt";
            this.checkEncrypt.Size = new System.Drawing.Size(208, 17);
            this.checkEncrypt.TabIndex = 11;
            this.checkEncrypt.Text = "Encrypt data sent over this connection";
            this.checkEncrypt.UseVisualStyleBackColor = false;
            this.checkEncrypt.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // labelApplicationName
            // 
            this.labelApplicationName.AutoSize = true;
            this.labelApplicationName.BackColor = System.Drawing.Color.Transparent;
            this.labelApplicationName.Location = new System.Drawing.Point(6, 87);
            this.labelApplicationName.Name = "labelApplicationName";
            this.labelApplicationName.Size = new System.Drawing.Size(93, 13);
            this.labelApplicationName.TabIndex = 7;
            this.labelApplicationName.Text = "Application Name:";
            // 
            // textApplicationName
            // 
            // 
            // 
            // 
            this.textApplicationName.Border.Class = "TextBoxBorder";
            this.textApplicationName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textApplicationName.Location = new System.Drawing.Point(151, 84);
            this.textApplicationName.Name = "textApplicationName";
            this.textApplicationName.Size = new System.Drawing.Size(200, 20);
            this.textApplicationName.TabIndex = 8;
            this.textApplicationName.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // labelConnectionTimeout
            // 
            this.labelConnectionTimeout.AutoSize = true;
            this.labelConnectionTimeout.BackColor = System.Drawing.Color.Transparent;
            this.labelConnectionTimeout.Location = new System.Drawing.Point(6, 114);
            this.labelConnectionTimeout.Name = "labelConnectionTimeout";
            this.labelConnectionTimeout.Size = new System.Drawing.Size(190, 13);
            this.labelConnectionTimeout.TabIndex = 9;
            this.labelConnectionTimeout.Text = "Connection Timeout: (default = 15 sec)";
            // 
            // textPassword
            // 
            // 
            // 
            // 
            this.textPassword.Border.Class = "TextBoxBorder";
            this.textPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textPassword.Enabled = false;
            this.textPassword.Location = new System.Drawing.Point(91, 80);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(223, 20);
            this.textPassword.TabIndex = 17;
            this.textPassword.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Location = new System.Drawing.Point(23, 83);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 16;
            this.labelPassword.Text = "Password:";
            // 
            // textLoginName
            // 
            // 
            // 
            // 
            this.textLoginName.Border.Class = "TextBoxBorder";
            this.textLoginName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textLoginName.Enabled = false;
            this.textLoginName.Location = new System.Drawing.Point(91, 54);
            this.textLoginName.Name = "textLoginName";
            this.textLoginName.Size = new System.Drawing.Size(223, 20);
            this.textLoginName.TabIndex = 15;
            this.textLoginName.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.Transparent;
            this.labelLogin.Location = new System.Drawing.Point(23, 57);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(65, 13);
            this.labelLogin.TabIndex = 14;
            this.labelLogin.Text = "Login name:";
            // 
            // radioSQL
            // 
            this.radioSQL.AutoSize = true;
            this.radioSQL.Location = new System.Drawing.Point(7, 31);
            this.radioSQL.Name = "radioSQL";
            this.radioSQL.Size = new System.Drawing.Size(151, 17);
            this.radioSQL.TabIndex = 13;
            this.radioSQL.Text = "SQL Server Authentication";
            this.radioSQL.UseVisualStyleBackColor = true;
            this.radioSQL.CheckedChanged += new System.EventHandler(this.radioWindowsSql_CheckedChanged);
            // 
            // radioWindows
            // 
            this.radioWindows.AutoSize = true;
            this.radioWindows.Checked = true;
            this.radioWindows.Location = new System.Drawing.Point(7, 8);
            this.radioWindows.Name = "radioWindows";
            this.radioWindows.Size = new System.Drawing.Size(285, 17);
            this.radioWindows.TabIndex = 12;
            this.radioWindows.TabStop = true;
            this.radioWindows.Text = "Windows Authentication (Used for trusted connections)";
            this.radioWindows.UseVisualStyleBackColor = true;
            this.radioWindows.CheckedChanged += new System.EventHandler(this.radioWindowsSql_CheckedChanged);
            // 
            // comboNetworkLibrary
            // 
            this.comboNetworkLibrary.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboNetworkLibrary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboNetworkLibrary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboNetworkLibrary.FormattingEnabled = true;
            this.comboNetworkLibrary.Items.AddRange(new object[] {
            "<default>",
            "Named Pipes (dbnmpntw)",
            "Winsock TCP/IP (dbmssocn)",
            "SPX/IPX  (dbmsspxn)",
            "Banyan Vines (dbmsvinn)",
            "Multi-Protocol (Windows RPC) (dbmsrpcn)"});
            this.comboNetworkLibrary.Location = new System.Drawing.Point(129, 109);
            this.comboNetworkLibrary.Name = "comboNetworkLibrary";
            this.comboNetworkLibrary.Size = new System.Drawing.Size(225, 21);
            this.comboNetworkLibrary.TabIndex = 35;
            this.comboNetworkLibrary.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // textDriver
            // 
            // 
            // 
            // 
            this.textDriver.Border.Class = "TextBoxBorder";
            this.textDriver.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textDriver.Location = new System.Drawing.Point(193, 57);
            this.textDriver.Name = "textDriver";
            this.textDriver.Size = new System.Drawing.Size(161, 20);
            this.textDriver.TabIndex = 31;
            this.textDriver.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // textFailoverPartner
            // 
            // 
            // 
            // 
            this.textFailoverPartner.Border.Class = "TextBoxBorder";
            this.textFailoverPartner.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textFailoverPartner.Location = new System.Drawing.Point(193, 162);
            this.textFailoverPartner.Name = "textFailoverPartner";
            this.textFailoverPartner.Size = new System.Drawing.Size(161, 20);
            this.textFailoverPartner.TabIndex = 41;
            this.textFailoverPartner.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // radioLibraryDefault
            // 
            this.radioLibraryDefault.AutoSize = true;
            this.radioLibraryDefault.Checked = true;
            this.radioLibraryDefault.Location = new System.Drawing.Point(6, 8);
            this.radioLibraryDefault.Name = "radioLibraryDefault";
            this.radioLibraryDefault.Size = new System.Drawing.Size(81, 17);
            this.radioLibraryDefault.TabIndex = 46;
            this.radioLibraryDefault.TabStop = true;
            this.radioLibraryDefault.Text = "Use Default";
            this.radioLibraryDefault.UseVisualStyleBackColor = true;
            this.radioLibraryDefault.CheckedChanged += new System.EventHandler(this.ClientNetworkLibraryChanged);
            // 
            // textNamedPipe
            // 
            // 
            // 
            // 
            this.textNamedPipe.Border.Class = "TextBoxBorder";
            this.textNamedPipe.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textNamedPipe.Enabled = false;
            this.textNamedPipe.Location = new System.Drawing.Point(176, 58);
            this.textNamedPipe.MaxLength = 256;
            this.textNamedPipe.Name = "textNamedPipe";
            this.textNamedPipe.Size = new System.Drawing.Size(107, 20);
            this.textNamedPipe.TabIndex = 50;
            this.textNamedPipe.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // radioLibraryBanyan
            // 
            this.radioLibraryBanyan.AutoSize = true;
            this.radioLibraryBanyan.Location = new System.Drawing.Point(6, 164);
            this.radioLibraryBanyan.Name = "radioLibraryBanyan";
            this.radioLibraryBanyan.Size = new System.Drawing.Size(90, 17);
            this.radioLibraryBanyan.TabIndex = 54;
            this.radioLibraryBanyan.Text = "Banyan Vines";
            this.radioLibraryBanyan.UseVisualStyleBackColor = true;
            this.radioLibraryBanyan.CheckedChanged += new System.EventHandler(this.ClientNetworkLibraryChanged);
            // 
            // radioLibraryAppleTalk
            // 
            this.radioLibraryAppleTalk.AutoSize = true;
            this.radioLibraryAppleTalk.Location = new System.Drawing.Point(6, 138);
            this.radioLibraryAppleTalk.Name = "radioLibraryAppleTalk";
            this.radioLibraryAppleTalk.Size = new System.Drawing.Size(73, 17);
            this.radioLibraryAppleTalk.TabIndex = 53;
            this.radioLibraryAppleTalk.Text = "AppleTalk";
            this.radioLibraryAppleTalk.UseVisualStyleBackColor = true;
            this.radioLibraryAppleTalk.CheckedChanged += new System.EventHandler(this.ClientNetworkLibraryChanged);
            // 
            // radioLibraryNWLink
            // 
            this.radioLibraryNWLink.AutoSize = true;
            this.radioLibraryNWLink.Location = new System.Drawing.Point(6, 112);
            this.radioLibraryNWLink.Name = "radioLibraryNWLink";
            this.radioLibraryNWLink.Size = new System.Drawing.Size(110, 17);
            this.radioLibraryNWLink.TabIndex = 52;
            this.radioLibraryNWLink.Text = "NWLink IPX/SPX";
            this.radioLibraryNWLink.UseVisualStyleBackColor = true;
            this.radioLibraryNWLink.CheckedChanged += new System.EventHandler(this.ClientNetworkLibraryChanged);
            // 
            // radioLibrarySharedMemory
            // 
            this.radioLibrarySharedMemory.AutoSize = true;
            this.radioLibrarySharedMemory.Location = new System.Drawing.Point(6, 86);
            this.radioLibrarySharedMemory.Name = "radioLibrarySharedMemory";
            this.radioLibrarySharedMemory.Size = new System.Drawing.Size(99, 17);
            this.radioLibrarySharedMemory.TabIndex = 51;
            this.radioLibrarySharedMemory.Text = "Shared Memory";
            this.radioLibrarySharedMemory.UseVisualStyleBackColor = true;
            this.radioLibrarySharedMemory.CheckedChanged += new System.EventHandler(this.ClientNetworkLibraryChanged);
            // 
            // radioLibraryMulti
            // 
            this.radioLibraryMulti.AutoSize = true;
            this.radioLibraryMulti.Location = new System.Drawing.Point(6, 190);
            this.radioLibraryMulti.Name = "radioLibraryMulti";
            this.radioLibraryMulti.Size = new System.Drawing.Size(85, 17);
            this.radioLibraryMulti.TabIndex = 55;
            this.radioLibraryMulti.Text = "Multiprotocol";
            this.radioLibraryMulti.UseVisualStyleBackColor = true;
            this.radioLibraryMulti.CheckedChanged += new System.EventHandler(this.ClientNetworkLibraryChanged);
            // 
            // radioLibraryNamedPipes
            // 
            this.radioLibraryNamedPipes.AutoSize = true;
            this.radioLibraryNamedPipes.Location = new System.Drawing.Point(6, 60);
            this.radioLibraryNamedPipes.Name = "radioLibraryNamedPipes";
            this.radioLibraryNamedPipes.Size = new System.Drawing.Size(170, 17);
            this.radioLibraryNamedPipes.TabIndex = 49;
            this.radioLibraryNamedPipes.Text = "Named Pipes -- Pipe (optional):";
            this.radioLibraryNamedPipes.UseVisualStyleBackColor = true;
            this.radioLibraryNamedPipes.CheckedChanged += new System.EventHandler(this.ClientNetworkLibraryChanged);
            // 
            // radioLibraryTCPIP
            // 
            this.radioLibraryTCPIP.AutoSize = true;
            this.radioLibraryTCPIP.Location = new System.Drawing.Point(6, 34);
            this.radioLibraryTCPIP.Name = "radioLibraryTCPIP";
            this.radioLibraryTCPIP.Size = new System.Drawing.Size(141, 17);
            this.radioLibraryTCPIP.TabIndex = 47;
            this.radioLibraryTCPIP.Text = "TCP/IP -- Port (optional):";
            this.radioLibraryTCPIP.UseVisualStyleBackColor = true;
            this.radioLibraryTCPIP.CheckedChanged += new System.EventHandler(this.ClientNetworkLibraryChanged);
            // 
            // radioMultiLocalProc
            // 
            this.radioMultiLocalProc.AutoSize = true;
            this.radioMultiLocalProc.Enabled = false;
            this.radioMultiLocalProc.Location = new System.Drawing.Point(139, 66);
            this.radioMultiLocalProc.Name = "radioMultiLocalProc";
            this.radioMultiLocalProc.Size = new System.Drawing.Size(122, 17);
            this.radioMultiLocalProc.TabIndex = 63;
            this.radioMultiLocalProc.Text = "Local Procedure call";
            this.radioMultiLocalProc.UseVisualStyleBackColor = true;
            this.radioMultiLocalProc.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // radioMultiIPX
            // 
            this.radioMultiIPX.AutoSize = true;
            this.radioMultiIPX.Enabled = false;
            this.radioMultiIPX.Location = new System.Drawing.Point(139, 45);
            this.radioMultiIPX.Name = "radioMultiIPX";
            this.radioMultiIPX.Size = new System.Drawing.Size(161, 17);
            this.radioMultiIPX.TabIndex = 62;
            this.radioMultiIPX.Text = "IPX (Internetwork Exchange)";
            this.radioMultiIPX.UseVisualStyleBackColor = true;
            this.radioMultiIPX.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // radioMultiUDP
            // 
            this.radioMultiUDP.AutoSize = true;
            this.radioMultiUDP.Enabled = false;
            this.radioMultiUDP.Location = new System.Drawing.Point(139, 24);
            this.radioMultiUDP.Name = "radioMultiUDP";
            this.radioMultiUDP.Size = new System.Drawing.Size(170, 17);
            this.radioMultiUDP.TabIndex = 61;
            this.radioMultiUDP.Text = "UDP (User Datagram Protocol)";
            this.radioMultiUDP.UseVisualStyleBackColor = true;
            this.radioMultiUDP.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // radioMultiBanyan
            // 
            this.radioMultiBanyan.AutoSize = true;
            this.radioMultiBanyan.Enabled = false;
            this.radioMultiBanyan.Location = new System.Drawing.Point(139, 3);
            this.radioMultiBanyan.Name = "radioMultiBanyan";
            this.radioMultiBanyan.Size = new System.Drawing.Size(90, 17);
            this.radioMultiBanyan.TabIndex = 60;
            this.radioMultiBanyan.Text = "Banyan Vines";
            this.radioMultiBanyan.UseVisualStyleBackColor = true;
            this.radioMultiBanyan.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // radioMultiSPX
            // 
            this.radioMultiSPX.AutoSize = true;
            this.radioMultiSPX.Enabled = false;
            this.radioMultiSPX.Location = new System.Drawing.Point(3, 66);
            this.radioMultiSPX.Name = "radioMultiSPX";
            this.radioMultiSPX.Size = new System.Drawing.Size(49, 17);
            this.radioMultiSPX.TabIndex = 59;
            this.radioMultiSPX.Text = "SPX ";
            this.radioMultiSPX.UseVisualStyleBackColor = true;
            this.radioMultiSPX.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // radioMultiNetBios
            // 
            this.radioMultiNetBios.AutoSize = true;
            this.radioMultiNetBios.Enabled = false;
            this.radioMultiNetBios.Location = new System.Drawing.Point(3, 45);
            this.radioMultiNetBios.Name = "radioMultiNetBios";
            this.radioMultiNetBios.Size = new System.Drawing.Size(131, 17);
            this.radioMultiNetBios.TabIndex = 58;
            this.radioMultiNetBios.Text = "NetBios over NetBEUI";
            this.radioMultiNetBios.UseVisualStyleBackColor = true;
            this.radioMultiNetBios.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // radioMultiTCPIP
            // 
            this.radioMultiTCPIP.AutoSize = true;
            this.radioMultiTCPIP.Enabled = false;
            this.radioMultiTCPIP.Location = new System.Drawing.Point(3, 24);
            this.radioMultiTCPIP.Name = "radioMultiTCPIP";
            this.radioMultiTCPIP.Size = new System.Drawing.Size(61, 17);
            this.radioMultiTCPIP.TabIndex = 57;
            this.radioMultiTCPIP.Text = "TCP/IP";
            this.radioMultiTCPIP.UseVisualStyleBackColor = true;
            this.radioMultiTCPIP.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // radioMultiNamedPipes
            // 
            this.radioMultiNamedPipes.AutoSize = true;
            this.radioMultiNamedPipes.Checked = true;
            this.radioMultiNamedPipes.Enabled = false;
            this.radioMultiNamedPipes.Location = new System.Drawing.Point(3, 3);
            this.radioMultiNamedPipes.Name = "radioMultiNamedPipes";
            this.radioMultiNamedPipes.Size = new System.Drawing.Size(88, 17);
            this.radioMultiNamedPipes.TabIndex = 56;
            this.radioMultiNamedPipes.TabStop = true;
            this.radioMultiNamedPipes.Text = "Named Pipes";
            this.radioMultiNamedPipes.UseVisualStyleBackColor = true;
            this.radioMultiNamedPipes.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // labelFailoverPartner
            // 
            this.labelFailoverPartner.AutoSize = true;
            this.labelFailoverPartner.BackColor = System.Drawing.Color.Transparent;
            this.labelFailoverPartner.Location = new System.Drawing.Point(6, 165);
            this.labelFailoverPartner.Name = "labelFailoverPartner";
            this.labelFailoverPartner.Size = new System.Drawing.Size(176, 13);
            this.labelFailoverPartner.TabIndex = 40;
            this.labelFailoverPartner.Text = "Database Mirroring Failover Partner:";
            // 
            // labelDriver
            // 
            this.labelDriver.AutoSize = true;
            this.labelDriver.BackColor = System.Drawing.Color.Transparent;
            this.labelDriver.Location = new System.Drawing.Point(6, 60);
            this.labelDriver.Name = "labelDriver";
            this.labelDriver.Size = new System.Drawing.Size(35, 13);
            this.labelDriver.TabIndex = 30;
            this.labelDriver.Text = "Driver";
            // 
            // textCurrentLanguage
            // 
            // 
            // 
            // 
            this.textCurrentLanguage.Border.Class = "TextBoxBorder";
            this.textCurrentLanguage.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textCurrentLanguage.Location = new System.Drawing.Point(193, 31);
            this.textCurrentLanguage.Name = "textCurrentLanguage";
            this.textCurrentLanguage.Size = new System.Drawing.Size(161, 20);
            this.textCurrentLanguage.TabIndex = 29;
            this.textCurrentLanguage.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // labelPacketSize
            // 
            this.labelPacketSize.AutoSize = true;
            this.labelPacketSize.BackColor = System.Drawing.Color.Transparent;
            this.labelPacketSize.Location = new System.Drawing.Point(6, 86);
            this.labelPacketSize.Name = "labelPacketSize";
            this.labelPacketSize.Size = new System.Drawing.Size(138, 13);
            this.labelPacketSize.TabIndex = 32;
            this.labelPacketSize.Text = "Packet Size: (default=8000)";
            // 
            // labelCurrentLanguage
            // 
            this.labelCurrentLanguage.AutoSize = true;
            this.labelCurrentLanguage.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentLanguage.Location = new System.Drawing.Point(6, 34);
            this.labelCurrentLanguage.Name = "labelCurrentLanguage";
            this.labelCurrentLanguage.Size = new System.Drawing.Size(95, 13);
            this.labelCurrentLanguage.TabIndex = 28;
            this.labelCurrentLanguage.Text = "Current Language:";
            // 
            // labelProvider
            // 
            this.labelProvider.AutoSize = true;
            this.labelProvider.BackColor = System.Drawing.Color.Transparent;
            this.labelProvider.Location = new System.Drawing.Point(245, 239);
            this.labelProvider.Name = "labelProvider";
            this.labelProvider.Size = new System.Drawing.Size(49, 13);
            this.labelProvider.TabIndex = 36;
            this.labelProvider.Text = "Provider:";
            this.labelProvider.Visible = false;
            // 
            // textAttachFileDB
            // 
            // 
            // 
            // 
            this.textAttachFileDB.Border.Class = "TextBoxBorder";
            this.textAttachFileDB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textAttachFileDB.Location = new System.Drawing.Point(193, 5);
            this.textAttachFileDB.Name = "textAttachFileDB";
            this.textAttachFileDB.Size = new System.Drawing.Size(161, 20);
            this.textAttachFileDB.TabIndex = 27;
            this.textAttachFileDB.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // textWorkstation
            // 
            // 
            // 
            // 
            this.textWorkstation.Border.Class = "TextBoxBorder";
            this.textWorkstation.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textWorkstation.Location = new System.Drawing.Point(193, 136);
            this.textWorkstation.Name = "textWorkstation";
            this.textWorkstation.Size = new System.Drawing.Size(161, 20);
            this.textWorkstation.TabIndex = 39;
            this.textWorkstation.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // checkAsynchronousProcessing
            // 
            this.checkAsynchronousProcessing.AutoSize = true;
            this.checkAsynchronousProcessing.BackColor = System.Drawing.Color.Transparent;
            this.checkAsynchronousProcessing.Location = new System.Drawing.Point(9, 190);
            this.checkAsynchronousProcessing.Name = "checkAsynchronousProcessing";
            this.checkAsynchronousProcessing.Size = new System.Drawing.Size(148, 17);
            this.checkAsynchronousProcessing.TabIndex = 42;
            this.checkAsynchronousProcessing.Text = "Asynchronous Processing";
            this.checkAsynchronousProcessing.UseVisualStyleBackColor = false;
            this.checkAsynchronousProcessing.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // labelWorkstation
            // 
            this.labelWorkstation.AutoSize = true;
            this.labelWorkstation.BackColor = System.Drawing.Color.Transparent;
            this.labelWorkstation.Location = new System.Drawing.Point(6, 139);
            this.labelWorkstation.Name = "labelWorkstation";
            this.labelWorkstation.Size = new System.Drawing.Size(81, 13);
            this.labelWorkstation.TabIndex = 38;
            this.labelWorkstation.Text = "Workstation ID:";
            // 
            // checkEnlist
            // 
            this.checkEnlist.AutoSize = true;
            this.checkEnlist.BackColor = System.Drawing.Color.Transparent;
            this.checkEnlist.Checked = true;
            this.checkEnlist.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkEnlist.Location = new System.Drawing.Point(9, 262);
            this.checkEnlist.Name = "checkEnlist";
            this.checkEnlist.Size = new System.Drawing.Size(51, 17);
            this.checkEnlist.TabIndex = 45;
            this.checkEnlist.Text = "Enlist";
            this.checkEnlist.UseVisualStyleBackColor = false;
            this.checkEnlist.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // textProvider
            // 
            // 
            // 
            // 
            this.textProvider.Border.Class = "TextBoxBorder";
            this.textProvider.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textProvider.Location = new System.Drawing.Point(196, 260);
            this.textProvider.Name = "textProvider";
            this.textProvider.Size = new System.Drawing.Size(161, 20);
            this.textProvider.TabIndex = 37;
            this.textProvider.Visible = false;
            this.textProvider.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // checkMARSConnection
            // 
            this.checkMARSConnection.AutoSize = true;
            this.checkMARSConnection.BackColor = System.Drawing.Color.Transparent;
            this.checkMARSConnection.Location = new System.Drawing.Point(9, 214);
            this.checkMARSConnection.Name = "checkMARSConnection";
            this.checkMARSConnection.Size = new System.Drawing.Size(114, 17);
            this.checkMARSConnection.TabIndex = 43;
            this.checkMARSConnection.Text = "MARS Connection";
            this.checkMARSConnection.UseVisualStyleBackColor = false;
            this.checkMARSConnection.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // labelNetworkLibrary
            // 
            this.labelNetworkLibrary.AutoSize = true;
            this.labelNetworkLibrary.BackColor = System.Drawing.Color.Transparent;
            this.labelNetworkLibrary.Location = new System.Drawing.Point(6, 112);
            this.labelNetworkLibrary.Name = "labelNetworkLibrary";
            this.labelNetworkLibrary.Size = new System.Drawing.Size(84, 13);
            this.labelNetworkLibrary.TabIndex = 34;
            this.labelNetworkLibrary.Text = "Network Library:";
            // 
            // checkPersistSecurityInfo
            // 
            this.checkPersistSecurityInfo.AutoSize = true;
            this.checkPersistSecurityInfo.BackColor = System.Drawing.Color.Transparent;
            this.checkPersistSecurityInfo.Location = new System.Drawing.Point(9, 238);
            this.checkPersistSecurityInfo.Name = "checkPersistSecurityInfo";
            this.checkPersistSecurityInfo.Size = new System.Drawing.Size(119, 17);
            this.checkPersistSecurityInfo.TabIndex = 44;
            this.checkPersistSecurityInfo.Text = "Persist Security Info";
            this.checkPersistSecurityInfo.UseVisualStyleBackColor = false;
            this.checkPersistSecurityInfo.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // labelAttachFileDB
            // 
            this.labelAttachFileDB.AutoSize = true;
            this.labelAttachFileDB.BackColor = System.Drawing.Color.Transparent;
            this.labelAttachFileDB.Location = new System.Drawing.Point(6, 8);
            this.labelAttachFileDB.Name = "labelAttachFileDB";
            this.labelAttachFileDB.Size = new System.Drawing.Size(188, 13);
            this.labelAttachFileDB.TabIndex = 26;
            this.labelAttachFileDB.Text = "Attach DB File Name/Initial File Name:";
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCopyToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyToClipboard.Image")));
            this.buttonCopyToClipboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(6, 103);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(147, 25);
            this.buttonCopyToClipboard.TabIndex = 67;
            this.buttonCopyToClipboard.Text = "Copy to Clipboard";
            this.buttonCopyToClipboard.UseVisualStyleBackColor = true;
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // buttonResetDefaults
            // 
            this.buttonResetDefaults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetDefaults.Location = new System.Drawing.Point(553, 103);
            this.buttonResetDefaults.Name = "buttonResetDefaults";
            this.buttonResetDefaults.Size = new System.Drawing.Size(132, 25);
            this.buttonResetDefaults.TabIndex = 68;
            this.buttonResetDefaults.Text = "Clear Properties";
            this.buttonResetDefaults.UseVisualStyleBackColor = true;
            this.buttonResetDefaults.Click += new System.EventHandler(this.buttonResetDefaults_Click);
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTestConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTestConnection.Image = ((System.Drawing.Image)(resources.GetObject("buttonTestConnection.Image")));
            this.buttonTestConnection.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonTestConnection.Location = new System.Drawing.Point(709, 7);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(123, 92);
            this.buttonTestConnection.TabIndex = 66;
            this.buttonTestConnection.Text = "Test Connection";
            this.buttonTestConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonTestConnection.UseVisualStyleBackColor = true;
            this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuTools,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 93);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(844, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuResetDefaults,
            this.toolStripMenuItem4,
            this.menuExitToLaunchpad,
            this.menuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuResetDefaults
            // 
            this.menuResetDefaults.Name = "menuResetDefaults";
            this.menuResetDefaults.Size = new System.Drawing.Size(168, 22);
            this.menuResetDefaults.Text = "Clear Properties";
            this.menuResetDefaults.Click += new System.EventHandler(this.menuResetDefaults_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(165, 6);
            // 
            // menuExitToLaunchpad
            // 
            this.menuExitToLaunchpad.Name = "menuExitToLaunchpad";
            this.menuExitToLaunchpad.Size = new System.Drawing.Size(168, 22);
            this.menuExitToLaunchpad.Text = "Exit to Launchpad";
            this.menuExitToLaunchpad.Click += new System.EventHandler(this.menuExitToLaunchpad_Click);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(168, 22);
            this.menuFileExit.Text = "Exit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManageServerGroups,
            this.menuToolsetOptions,
            this.toolStripMenuItem5,
            this.menuLaunchpad});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(47, 20);
            this.menuTools.Text = "Tools";
            // 
            // menuManageServerGroups
            // 
            this.menuManageServerGroups.Name = "menuManageServerGroups";
            this.menuManageServerGroups.Size = new System.Drawing.Size(233, 22);
            this.menuManageServerGroups.Text = "&Manage Server Groups...";
            this.menuManageServerGroups.Click += new System.EventHandler(this.menuManageServerGroups_Click);
            // 
            // menuToolsetOptions
            // 
            this.menuToolsetOptions.Name = "menuToolsetOptions";
            this.menuToolsetOptions.Size = new System.Drawing.Size(233, 22);
            this.menuToolsetOptions.Text = "SQL admin toolset &Options...";
            this.menuToolsetOptions.Click += new System.EventHandler(this.menuToolsetOptions_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(230, 6);
            // 
            // menuLaunchpad
            // 
            this.menuLaunchpad.Name = "menuLaunchpad";
            this.menuLaunchpad.Size = new System.Drawing.Size(233, 22);
            this.menuLaunchpad.Text = "SQL admin toolset &Launchpad";
            this.menuLaunchpad.Click += new System.EventHandler(this.menuLaunchpad_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowHelp,
            this.menuContactTechnicalSupport,
            this.toolStripMenuItem2,
            this.manuManageLicense,
            this.menuCheckForUpdates,
            this.toolStripMenuItem1,
            this.menuAboutIderaProducts,
            this.menuAbout});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.optionsToolStripMenuItem.Text = "Help";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.menuHelp_Click);
            // 
            // menuShowHelp
            // 
            this.menuShowHelp.Name = "menuShowHelp";
            this.menuShowHelp.Size = new System.Drawing.Size(261, 22);
            this.menuShowHelp.Text = "Show Help";
            this.menuShowHelp.Click += new System.EventHandler(this.menuShowHelp_Click);
            // 
            // menuContactTechnicalSupport
            // 
            this.menuContactTechnicalSupport.Name = "menuContactTechnicalSupport";
            this.menuContactTechnicalSupport.Size = new System.Drawing.Size(261, 22);
            this.menuContactTechnicalSupport.Text = "SQL admin toolset &Support";
            this.menuContactTechnicalSupport.Click += new System.EventHandler(this.menuContactTechnicalSupport_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(258, 6);
            // 
            // manuManageLicense
            // 
            this.manuManageLicense.Name = "manuManageLicense";
            this.manuManageLicense.Size = new System.Drawing.Size(261, 22);
            this.manuManageLicense.Text = "Manage &License";
            this.manuManageLicense.Click += new System.EventHandler(this.menuManageLicense_Click);
            // 
            // menuCheckForUpdates
            // 
            this.menuCheckForUpdates.Name = "menuCheckForUpdates";
            this.menuCheckForUpdates.Size = new System.Drawing.Size(261, 22);
            this.menuCheckForUpdates.Text = "Check For Updates";
            this.menuCheckForUpdates.Click += new System.EventHandler(this.menuCheckForUpdates_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(258, 6);
            // 
            // menuAboutIderaProducts
            // 
            this.menuAboutIderaProducts.Name = "menuAboutIderaProducts";
            this.menuAboutIderaProducts.Size = new System.Drawing.Size(261, 22);
            this.menuAboutIderaProducts.Text = "About Idera Products";
            this.menuAboutIderaProducts.Click += new System.EventHandler(this.menuAboutIderaProducts_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(261, 22);
            this.menuAbout.Text = "About Connection String Generator";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // toolProductBanner
            // 
            this.toolProductBanner.BackColor = System.Drawing.Color.Transparent;
            this.toolProductBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolProductBanner.Controls.Add(this.labelTitle);
            this.toolProductBanner.Controls.Add(this.labelSubtitle);
            this.toolProductBanner.Controls.Add(this.pictureBox1);
            this.toolProductBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolProductBanner.Location = new System.Drawing.Point(0, 117);
            this.toolProductBanner.Name = "toolProductBanner";
            this.toolProductBanner.Size = new System.Drawing.Size(844, 52);
            this.toolProductBanner.TabIndex = 10;
            // 
            // labelTitle
            // 
            // 
            // 
            // 
            this.labelTitle.BackgroundStyle.Class = "";
            this.labelTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Location = new System.Drawing.Point(61, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(430, 52);
            this.labelTitle.TabIndex = 7;
            this.labelTitle.Text = "<b><font size=\"+6\">Welcome to  Connection String Generator</font></b> ";
            // 
            // labelSubtitle
            // 
            // 
            // 
            // 
            this.labelSubtitle.BackgroundStyle.Class = "";
            this.labelSubtitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.Location = new System.Drawing.Point(381, 0);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(456, 52);
            this.labelSubtitle.TabIndex = 8;
            this.labelSubtitle.Text = "Create connection strings easily by picking and choosing from the available optio" +
    "ns";
            this.labelSubtitle.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBottom.Controls.Add(this.groupConnectionString);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 526);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(844, 168);
            this.panelBottom.TabIndex = 95;
            // 
            // groupConnectionString
            // 
            this.groupConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupConnectionString.BackColor = System.Drawing.Color.Transparent;
            this.groupConnectionString.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupConnectionString.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupConnectionString.Controls.Add(this.textConnectionString);
            this.groupConnectionString.Controls.Add(this.buttonCopyToClipboard);
            this.groupConnectionString.Controls.Add(this.buttonResetDefaults);
            this.groupConnectionString.Controls.Add(this.buttonTestConnection);
            this.groupConnectionString.IsShadowEnabled = true;
            this.groupConnectionString.Location = new System.Drawing.Point(6, 3);
            this.groupConnectionString.Name = "groupConnectionString";
            this.groupConnectionString.Size = new System.Drawing.Size(832, 163);
            // 
            // 
            // 
            this.groupConnectionString.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupConnectionString.Style.BackColorGradientAngle = 90;
            this.groupConnectionString.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupConnectionString.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupConnectionString.Style.BorderBottomWidth = 1;
            this.groupConnectionString.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupConnectionString.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupConnectionString.Style.BorderLeftWidth = 1;
            this.groupConnectionString.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupConnectionString.Style.BorderRightWidth = 1;
            this.groupConnectionString.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupConnectionString.Style.BorderTopWidth = 1;
            this.groupConnectionString.Style.Class = "";
            this.groupConnectionString.Style.CornerDiameter = 4;
            this.groupConnectionString.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupConnectionString.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupConnectionString.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupConnectionString.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupConnectionString.StyleMouseDown.Class = "";
            this.groupConnectionString.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupConnectionString.StyleMouseOver.Class = "";
            this.groupConnectionString.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupConnectionString.TabIndex = 65;
            this.groupConnectionString.Text = "Connection String";
            // 
            // textConnectionString
            // 
            // 
            // 
            // 
            this.textConnectionString.Border.Class = "TextBoxBorder";
            this.textConnectionString.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textConnectionString.Location = new System.Drawing.Point(9, 6);
            this.textConnectionString.Multiline = true;
            this.textConnectionString.Name = "textConnectionString";
            this.textConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textConnectionString.Size = new System.Drawing.Size(675, 93);
            this.textConnectionString.TabIndex = 65;
            // 
            // tabControl2
            // 
            this.tabControl2.BackColor = System.Drawing.Color.White;
            this.tabControl2.CanReorderTabs = false;
            this.tabControl2.Controls.Add(this.tabControlPanel1);
            this.tabControl2.Controls.Add(this.tabControlPanel2);
            this.tabControl2.Location = new System.Drawing.Point(6, 1);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl2.SelectedTabIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(824, 356);
            this.tabControl2.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabControl2.TabIndex = 14;
            this.tabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl2.Tabs.Add(this.tabItem1);
            this.tabControl2.Tabs.Add(this.tabItem2);
            this.tabControl2.TabStop = false;
            this.tabControl2.Text = "tabControl2";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.groupBasic);
            this.tabControlPanel1.Controls.Add(this.groupConnectUsing);
            this.tabControlPanel1.Controls.Add(this.groupConnectionPool);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 22);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(824, 334);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 92;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // groupBasic
            // 
            this.groupBasic.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupBasic.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupBasic.Controls.Add(this.textConnectionTimeout);
            this.groupBasic.Controls.Add(this.textBasicPort);
            this.groupBasic.Controls.Add(this.textDatabase);
            this.groupBasic.Controls.Add(this.textApplicationName);
            this.groupBasic.Controls.Add(this.labelBasicPort);
            this.groupBasic.Controls.Add(this.buttonBrowse);
            this.groupBasic.Controls.Add(this.labelServer);
            this.groupBasic.Controls.Add(this.labelConnectionTimeout);
            this.groupBasic.Controls.Add(this.labelDatabase);
            this.groupBasic.Controls.Add(this.checkEncrypt);
            this.groupBasic.Controls.Add(this.textServer);
            this.groupBasic.Controls.Add(this.labelApplicationName);
            this.groupBasic.IsShadowEnabled = true;
            this.groupBasic.Location = new System.Drawing.Point(12, 12);
            this.groupBasic.Name = "groupBasic";
            this.groupBasic.Size = new System.Drawing.Size(366, 165);
            // 
            // 
            // 
            this.groupBasic.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupBasic.Style.BackColorGradientAngle = 90;
            this.groupBasic.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupBasic.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupBasic.Style.BorderBottomWidth = 1;
            this.groupBasic.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupBasic.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupBasic.Style.BorderLeftWidth = 1;
            this.groupBasic.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupBasic.Style.BorderRightWidth = 1;
            this.groupBasic.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupBasic.Style.BorderTopWidth = 1;
            this.groupBasic.Style.Class = "";
            this.groupBasic.Style.CornerDiameter = 4;
            this.groupBasic.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupBasic.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupBasic.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupBasic.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupBasic.StyleMouseDown.Class = "";
            this.groupBasic.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupBasic.StyleMouseOver.Class = "";
            this.groupBasic.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupBasic.TabIndex = 0;
            // 
            // textConnectionTimeout
            // 
            // 
            // 
            // 
            this.textConnectionTimeout.Border.Class = "TextBoxBorder";
            this.textConnectionTimeout.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textConnectionTimeout.Location = new System.Drawing.Point(279, 110);
            this.textConnectionTimeout.Name = "textConnectionTimeout";
            this.textConnectionTimeout.Size = new System.Drawing.Size(72, 20);
            this.textConnectionTimeout.TabIndex = 10;
            this.textConnectionTimeout.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // textBasicPort
            // 
            // 
            // 
            // 
            this.textBasicPort.Border.Class = "TextBoxBorder";
            this.textBasicPort.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBasicPort.Location = new System.Drawing.Point(279, 33);
            this.textBasicPort.Name = "textBasicPort";
            this.textBasicPort.Size = new System.Drawing.Size(72, 20);
            this.textBasicPort.TabIndex = 4;
            this.textBasicPort.TextChanged += new System.EventHandler(this.textBasicPort_TextChanged);
            // 
            // groupConnectUsing
            // 
            this.groupConnectUsing.BackColor = System.Drawing.Color.Transparent;
            this.groupConnectUsing.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupConnectUsing.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupConnectUsing.Controls.Add(this.textPassword);
            this.groupConnectUsing.Controls.Add(this.radioSQL);
            this.groupConnectUsing.Controls.Add(this.labelPassword);
            this.groupConnectUsing.Controls.Add(this.radioWindows);
            this.groupConnectUsing.Controls.Add(this.textLoginName);
            this.groupConnectUsing.Controls.Add(this.labelLogin);
            this.groupConnectUsing.IsShadowEnabled = true;
            this.groupConnectUsing.Location = new System.Drawing.Point(12, 186);
            this.groupConnectUsing.Name = "groupConnectUsing";
            this.groupConnectUsing.Size = new System.Drawing.Size(359, 129);
            // 
            // 
            // 
            this.groupConnectUsing.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupConnectUsing.Style.BackColorGradientAngle = 90;
            this.groupConnectUsing.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupConnectUsing.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupConnectUsing.Style.BorderBottomWidth = 1;
            this.groupConnectUsing.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupConnectUsing.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupConnectUsing.Style.BorderLeftWidth = 1;
            this.groupConnectUsing.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupConnectUsing.Style.BorderRightWidth = 1;
            this.groupConnectUsing.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupConnectUsing.Style.BorderTopWidth = 1;
            this.groupConnectUsing.Style.Class = "";
            this.groupConnectUsing.Style.CornerDiameter = 4;
            this.groupConnectUsing.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupConnectUsing.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupConnectUsing.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupConnectUsing.StyleMouseDown.Class = "";
            this.groupConnectUsing.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupConnectUsing.StyleMouseOver.Class = "";
            this.groupConnectUsing.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupConnectUsing.TabIndex = 12;
            this.groupConnectUsing.Text = "Connect Using:";
            // 
            // groupConnectionPool
            // 
            this.groupConnectionPool.BackColor = System.Drawing.Color.Transparent;
            this.groupConnectionPool.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupConnectionPool.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupConnectionPool.Controls.Add(this.textConnectionLifetime);
            this.groupConnectionPool.Controls.Add(this.textMinPoolSize);
            this.groupConnectionPool.Controls.Add(this.textMaxPoolSize);
            this.groupConnectionPool.Controls.Add(this.checkPooling);
            this.groupConnectionPool.Controls.Add(this.labelConnectionLifetime);
            this.groupConnectionPool.Controls.Add(this.labelMaxPoolSize);
            this.groupConnectionPool.Controls.Add(this.checkConnectionReset);
            this.groupConnectionPool.Controls.Add(this.labelMinPoolSize);
            this.groupConnectionPool.IsShadowEnabled = true;
            this.groupConnectionPool.Location = new System.Drawing.Point(389, 4);
            this.groupConnectionPool.Name = "groupConnectionPool";
            this.groupConnectionPool.Size = new System.Drawing.Size(424, 150);
            // 
            // 
            // 
            this.groupConnectionPool.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupConnectionPool.Style.BackColorGradientAngle = 90;
            this.groupConnectionPool.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupConnectionPool.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupConnectionPool.Style.BorderBottomWidth = 1;
            this.groupConnectionPool.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupConnectionPool.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupConnectionPool.Style.BorderLeftWidth = 1;
            this.groupConnectionPool.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupConnectionPool.Style.BorderRightWidth = 1;
            this.groupConnectionPool.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupConnectionPool.Style.BorderTopWidth = 1;
            this.groupConnectionPool.Style.Class = "";
            this.groupConnectionPool.Style.CornerDiameter = 4;
            this.groupConnectionPool.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupConnectionPool.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupConnectionPool.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupConnectionPool.StyleMouseDown.Class = "";
            this.groupConnectionPool.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupConnectionPool.StyleMouseOver.Class = "";
            this.groupConnectionPool.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupConnectionPool.TabIndex = 18;
            this.groupConnectionPool.Text = "Connection Pooling";
            // 
            // textConnectionLifetime
            // 
            // 
            // 
            // 
            this.textConnectionLifetime.Border.Class = "TextBoxBorder";
            this.textConnectionLifetime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textConnectionLifetime.Location = new System.Drawing.Point(153, 81);
            this.textConnectionLifetime.Name = "textConnectionLifetime";
            this.textConnectionLifetime.Size = new System.Drawing.Size(72, 20);
            this.textConnectionLifetime.TabIndex = 24;
            this.textConnectionLifetime.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // textMinPoolSize
            // 
            // 
            // 
            // 
            this.textMinPoolSize.Border.Class = "TextBoxBorder";
            this.textMinPoolSize.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textMinPoolSize.Location = new System.Drawing.Point(153, 55);
            this.textMinPoolSize.Name = "textMinPoolSize";
            this.textMinPoolSize.Size = new System.Drawing.Size(72, 20);
            this.textMinPoolSize.TabIndex = 22;
            this.textMinPoolSize.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // textMaxPoolSize
            // 
            // 
            // 
            // 
            this.textMaxPoolSize.Border.Class = "TextBoxBorder";
            this.textMaxPoolSize.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textMaxPoolSize.Location = new System.Drawing.Point(153, 29);
            this.textMaxPoolSize.Name = "textMaxPoolSize";
            this.textMaxPoolSize.Size = new System.Drawing.Size(72, 20);
            this.textMaxPoolSize.TabIndex = 20;
            this.textMaxPoolSize.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "Basic Properties";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.groupAdvanced);
            this.tabControlPanel2.Controls.Add(this.groupNetworkLibrary);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 22);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(824, 334);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 93;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // groupAdvanced
            // 
            this.groupAdvanced.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupAdvanced.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupAdvanced.Controls.Add(this.textAttachFileDB);
            this.groupAdvanced.Controls.Add(this.textPacketSize);
            this.groupAdvanced.Controls.Add(this.textDriver);
            this.groupAdvanced.Controls.Add(this.textProvider);
            this.groupAdvanced.Controls.Add(this.comboNetworkLibrary);
            this.groupAdvanced.Controls.Add(this.labelDriver);
            this.groupAdvanced.Controls.Add(this.labelAttachFileDB);
            this.groupAdvanced.Controls.Add(this.textCurrentLanguage);
            this.groupAdvanced.Controls.Add(this.checkMARSConnection);
            this.groupAdvanced.Controls.Add(this.checkEnlist);
            this.groupAdvanced.Controls.Add(this.labelFailoverPartner);
            this.groupAdvanced.Controls.Add(this.labelProvider);
            this.groupAdvanced.Controls.Add(this.labelWorkstation);
            this.groupAdvanced.Controls.Add(this.textWorkstation);
            this.groupAdvanced.Controls.Add(this.labelNetworkLibrary);
            this.groupAdvanced.Controls.Add(this.textFailoverPartner);
            this.groupAdvanced.Controls.Add(this.labelPacketSize);
            this.groupAdvanced.Controls.Add(this.labelCurrentLanguage);
            this.groupAdvanced.Controls.Add(this.checkAsynchronousProcessing);
            this.groupAdvanced.Controls.Add(this.checkPersistSecurityInfo);
            this.groupAdvanced.IsShadowEnabled = true;
            this.groupAdvanced.Location = new System.Drawing.Point(12, 12);
            this.groupAdvanced.Name = "groupAdvanced";
            this.groupAdvanced.Size = new System.Drawing.Size(366, 313);
            // 
            // 
            // 
            this.groupAdvanced.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupAdvanced.Style.BackColorGradientAngle = 90;
            this.groupAdvanced.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupAdvanced.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupAdvanced.Style.BorderBottomWidth = 1;
            this.groupAdvanced.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupAdvanced.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupAdvanced.Style.BorderLeftWidth = 1;
            this.groupAdvanced.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupAdvanced.Style.BorderRightWidth = 1;
            this.groupAdvanced.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupAdvanced.Style.BorderTopWidth = 1;
            this.groupAdvanced.Style.Class = "";
            this.groupAdvanced.Style.CornerDiameter = 4;
            this.groupAdvanced.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupAdvanced.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupAdvanced.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupAdvanced.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupAdvanced.StyleMouseDown.Class = "";
            this.groupAdvanced.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupAdvanced.StyleMouseOver.Class = "";
            this.groupAdvanced.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupAdvanced.TabIndex = 26;
            // 
            // textPacketSize
            // 
            // 
            // 
            // 
            this.textPacketSize.Border.Class = "TextBoxBorder";
            this.textPacketSize.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textPacketSize.Location = new System.Drawing.Point(282, 84);
            this.textPacketSize.Name = "textPacketSize";
            this.textPacketSize.Size = new System.Drawing.Size(72, 20);
            this.textPacketSize.TabIndex = 33;
            this.textPacketSize.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // groupNetworkLibrary
            // 
            this.groupNetworkLibrary.BackColor = System.Drawing.Color.Transparent;
            this.groupNetworkLibrary.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupNetworkLibrary.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupNetworkLibrary.Controls.Add(this.textAdvancedPort);
            this.groupNetworkLibrary.Controls.Add(this.groupMultiprotocol);
            this.groupNetworkLibrary.Controls.Add(this.radioLibraryDefault);
            this.groupNetworkLibrary.Controls.Add(this.textNamedPipe);
            this.groupNetworkLibrary.Controls.Add(this.radioLibraryTCPIP);
            this.groupNetworkLibrary.Controls.Add(this.radioLibraryNamedPipes);
            this.groupNetworkLibrary.Controls.Add(this.radioLibraryMulti);
            this.groupNetworkLibrary.Controls.Add(this.radioLibraryBanyan);
            this.groupNetworkLibrary.Controls.Add(this.radioLibrarySharedMemory);
            this.groupNetworkLibrary.Controls.Add(this.radioLibraryAppleTalk);
            this.groupNetworkLibrary.Controls.Add(this.radioLibraryNWLink);
            this.groupNetworkLibrary.IsShadowEnabled = true;
            this.groupNetworkLibrary.Location = new System.Drawing.Point(388, 3);
            this.groupNetworkLibrary.Name = "groupNetworkLibrary";
            this.groupNetworkLibrary.Size = new System.Drawing.Size(424, 322);
            // 
            // 
            // 
            this.groupNetworkLibrary.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupNetworkLibrary.Style.BackColorGradientAngle = 90;
            this.groupNetworkLibrary.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupNetworkLibrary.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupNetworkLibrary.Style.BorderBottomWidth = 1;
            this.groupNetworkLibrary.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupNetworkLibrary.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupNetworkLibrary.Style.BorderLeftWidth = 1;
            this.groupNetworkLibrary.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupNetworkLibrary.Style.BorderRightWidth = 1;
            this.groupNetworkLibrary.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupNetworkLibrary.Style.BorderTopWidth = 1;
            this.groupNetworkLibrary.Style.Class = "";
            this.groupNetworkLibrary.Style.CornerDiameter = 4;
            this.groupNetworkLibrary.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupNetworkLibrary.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupNetworkLibrary.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupNetworkLibrary.StyleMouseDown.Class = "";
            this.groupNetworkLibrary.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupNetworkLibrary.StyleMouseOver.Class = "";
            this.groupNetworkLibrary.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupNetworkLibrary.TabIndex = 46;
            this.groupNetworkLibrary.Text = "Client Network Library";
            // 
            // textAdvancedPort
            // 
            // 
            // 
            // 
            this.textAdvancedPort.Border.Class = "TextBoxBorder";
            this.textAdvancedPort.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textAdvancedPort.Enabled = false;
            this.textAdvancedPort.Location = new System.Drawing.Point(176, 32);
            this.textAdvancedPort.Name = "textAdvancedPort";
            this.textAdvancedPort.Size = new System.Drawing.Size(107, 20);
            this.textAdvancedPort.TabIndex = 48;
            this.textAdvancedPort.TextChanged += new System.EventHandler(this.textAdvancedPort_TextChanged);
            // 
            // groupMultiprotocol
            // 
            this.groupMultiprotocol.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupMultiprotocol.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupMultiprotocol.Controls.Add(this.radioMultiLocalProc);
            this.groupMultiprotocol.Controls.Add(this.radioMultiNamedPipes);
            this.groupMultiprotocol.Controls.Add(this.radioMultiIPX);
            this.groupMultiprotocol.Controls.Add(this.radioMultiTCPIP);
            this.groupMultiprotocol.Controls.Add(this.radioMultiUDP);
            this.groupMultiprotocol.Controls.Add(this.radioMultiNetBios);
            this.groupMultiprotocol.Controls.Add(this.radioMultiBanyan);
            this.groupMultiprotocol.Controls.Add(this.radioMultiSPX);
            this.groupMultiprotocol.IsShadowEnabled = true;
            this.groupMultiprotocol.Location = new System.Drawing.Point(94, 195);
            this.groupMultiprotocol.Name = "groupMultiprotocol";
            this.groupMultiprotocol.Size = new System.Drawing.Size(310, 97);
            // 
            // 
            // 
            this.groupMultiprotocol.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupMultiprotocol.Style.BackColorGradientAngle = 90;
            this.groupMultiprotocol.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupMultiprotocol.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupMultiprotocol.Style.BorderBottomWidth = 1;
            this.groupMultiprotocol.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupMultiprotocol.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupMultiprotocol.Style.BorderLeftWidth = 1;
            this.groupMultiprotocol.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupMultiprotocol.Style.BorderRightWidth = 1;
            this.groupMultiprotocol.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupMultiprotocol.Style.BorderTopWidth = 1;
            this.groupMultiprotocol.Style.Class = "";
            this.groupMultiprotocol.Style.CornerDiameter = 4;
            this.groupMultiprotocol.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupMultiprotocol.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupMultiprotocol.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupMultiprotocol.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupMultiprotocol.StyleMouseDown.Class = "";
            this.groupMultiprotocol.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupMultiprotocol.StyleMouseOver.Class = "";
            this.groupMultiprotocol.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupMultiprotocol.TabIndex = 56;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "Advanced Properties";
            // 
            // panelMiddle
            // 
            this.panelMiddle.BackColor = System.Drawing.Color.Transparent;
            this.panelMiddle.Controls.Add(this.tabControl2);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMiddle.Location = new System.Drawing.Point(0, 169);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(844, 357);
            this.panelMiddle.TabIndex = 94;
            // 
            // ideraTitleBar1
            // 
            this.ideraTitleBar1.ActivateLicenseEventHandler = null;
            this.ideraTitleBar1.BuyNowUrl = "www.idera.com/buynow/admin-toolset?utm_source=sqltoolset&utm_medium=inproduct&utm" +
    "_content=bn&utm_campaign=buynow";
            this.ideraTitleBar1.Close = true;
            this.ideraTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ideraTitleBar1.IderaProductCommunityCenterUrl = "http://community.idera.com/forums/forum/products/idera-sql-admin-toolset/";
            this.ideraTitleBar1.IderaProductNameText = "SQL Connection String Generator";
            this.ideraTitleBar1.IderaTrialCenterUrl = "http://www.idera.com/trialcenter";
            this.ideraTitleBar1.IsFormLocked = false;
            this.ideraTitleBar1.LicenseInformation = null;
            this.ideraTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ideraTitleBar1.Maximize = false;
            this.ideraTitleBar1.Minimize = true;
            this.ideraTitleBar1.Name = "ideraTitleBar1";
            this.ideraTitleBar1.Size = new System.Drawing.Size(844, 93);
            this.ideraTitleBar1.TabIndex = 96;
            this.ideraTitleBar1.TrialMode = true;
            this.ideraTitleBar1.LicenseInfoButtonClick += new System.EventHandler(this.ideraTitleBar1_LicenseInfoButtonClick);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(844, 694);
            this.ControlBox = false;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.toolProductBanner);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ideraTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(844, 694);
            this.MinimumSize = new System.Drawing.Size(844, 694);
            this.Name = "Form_Main";
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ShowF1Help);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolProductBanner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.groupConnectionString.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.groupBasic.ResumeLayout(false);
            this.groupBasic.PerformLayout();
            this.groupConnectUsing.ResumeLayout(false);
            this.groupConnectUsing.PerformLayout();
            this.groupConnectionPool.ResumeLayout(false);
            this.groupConnectionPool.PerformLayout();
            this.tabControlPanel2.ResumeLayout(false);
            this.groupAdvanced.ResumeLayout(false);
            this.groupAdvanced.PerformLayout();
            this.groupNetworkLibrary.ResumeLayout(false);
            this.groupNetworkLibrary.PerformLayout();
            this.groupMultiprotocol.ResumeLayout(false);
            this.groupMultiprotocol.PerformLayout();
            this.panelMiddle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       private System.Windows.Forms.Button buttonTestConnection;
       private System.Windows.Forms.Button buttonResetDefaults;
        private System.Windows.Forms.RadioButton radioMultiLocalProc;
        private System.Windows.Forms.RadioButton radioMultiIPX;
        private System.Windows.Forms.RadioButton radioMultiUDP;
        private System.Windows.Forms.RadioButton radioMultiBanyan;
        private System.Windows.Forms.RadioButton radioMultiSPX;
        private System.Windows.Forms.RadioButton radioMultiNetBios;
        private System.Windows.Forms.RadioButton radioMultiTCPIP;
        private System.Windows.Forms.RadioButton radioMultiNamedPipes;
       private DevComponents.DotNetBar.Controls.TextBoxX textNamedPipe;
        private System.Windows.Forms.RadioButton radioLibraryBanyan;
        private System.Windows.Forms.RadioButton radioLibraryAppleTalk;
        private System.Windows.Forms.RadioButton radioLibraryNWLink;
        private System.Windows.Forms.RadioButton radioLibrarySharedMemory;
        private System.Windows.Forms.RadioButton radioLibraryMulti;
        private System.Windows.Forms.RadioButton radioLibraryNamedPipes;
        private System.Windows.Forms.RadioButton radioLibraryTCPIP;
       private System.Windows.Forms.CheckBox checkEncrypt;
       private System.Windows.Forms.Label labelConnectionTimeout;
        private DevComponents.DotNetBar.Controls.TextBoxX textPassword;
        private System.Windows.Forms.Label labelPassword;
        private DevComponents.DotNetBar.Controls.TextBoxX textLoginName;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.RadioButton radioSQL;
        private System.Windows.Forms.RadioButton radioWindows;
        private DevComponents.DotNetBar.Controls.TextBoxX textApplicationName;
        private System.Windows.Forms.Label labelApplicationName;
        private DevComponents.DotNetBar.Controls.TextBoxX textDatabase;
        private System.Windows.Forms.Label labelDatabase;
        private DevComponents.DotNetBar.Controls.TextBoxX textServer;
       private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.Label labelPacketSize;
        private System.Windows.Forms.Label labelProvider;
        private DevComponents.DotNetBar.Controls.TextBoxX textWorkstation;
        private System.Windows.Forms.Label labelWorkstation;
        private DevComponents.DotNetBar.Controls.TextBoxX textProvider;
        private System.Windows.Forms.Label labelNetworkLibrary;
        private DevComponents.DotNetBar.Controls.TextBoxX textDriver;
        private System.Windows.Forms.Label labelAttachFileDB;
        private System.Windows.Forms.CheckBox checkPersistSecurityInfo;
        private System.Windows.Forms.CheckBox checkMARSConnection;
        private System.Windows.Forms.CheckBox checkEnlist;
        private System.Windows.Forms.CheckBox checkAsynchronousProcessing;
        private DevComponents.DotNetBar.Controls.TextBoxX textAttachFileDB;
        private System.Windows.Forms.Label labelCurrentLanguage;
        private DevComponents.DotNetBar.Controls.TextBoxX textCurrentLanguage;
       private System.Windows.Forms.Label labelDriver;
        private System.Windows.Forms.Label labelConnectionLifetime;
       private System.Windows.Forms.CheckBox checkConnectionReset;
       private System.Windows.Forms.Label labelMinPoolSize;
        private System.Windows.Forms.Label labelMaxPoolSize;
       private System.Windows.Forms.CheckBox checkPooling;
        private System.Windows.Forms.Label labelBasicPort;
        private System.Windows.Forms.Button buttonCopyToClipboard;
        private System.Windows.Forms.RadioButton radioLibraryDefault;
        private DevComponents.DotNetBar.Controls.TextBoxX textFailoverPartner;
        private System.Windows.Forms.Label labelFailoverPartner;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboNetworkLibrary;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem menuShowHelp;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuAboutIderaProducts;
       private System.Windows.Forms.ToolStripMenuItem menuContactTechnicalSupport;
        private System.Windows.Forms.ToolStripMenuItem menuCheckForUpdates;
        private System.Windows.Forms.ToolStripMenuItem menuResetDefaults;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.Button buttonBrowse;
       private System.Windows.Forms.Panel toolProductBanner;
        private System.Windows.Forms.PictureBox pictureBox1;
       private System.Windows.Forms.ToolStripMenuItem menuExitToLaunchpad;
       private System.Windows.Forms.Panel panelBottom;
       private DevComponents.DotNetBar.LabelX labelSubtitle;
       private DevComponents.DotNetBar.LabelX labelTitle;
       private DevComponents.DotNetBar.TabControl tabControl2;
       private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
       private DevComponents.DotNetBar.TabItem tabItem2;
       private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
       private DevComponents.DotNetBar.TabItem tabItem1;
       private DevComponents.DotNetBar.Controls.GroupPanel groupConnectUsing;
       private DevComponents.DotNetBar.Controls.GroupPanel groupConnectionPool;
       private DevComponents.DotNetBar.Controls.GroupPanel groupBasic;
       private DevComponents.DotNetBar.Controls.GroupPanel groupNetworkLibrary;
       private DevComponents.DotNetBar.Controls.GroupPanel groupMultiprotocol;
       private DevComponents.DotNetBar.Controls.GroupPanel groupAdvanced;
       private System.Windows.Forms.ToolStripMenuItem menuTools;
       private System.Windows.Forms.ToolStripMenuItem menuToolsetOptions;
       private System.Windows.Forms.ToolStripMenuItem menuLaunchpad;
       private DevComponents.DotNetBar.Controls.GroupPanel groupConnectionString;
       private System.Windows.Forms.Panel panelMiddle;
       private Idera.SqlAdminToolset.Core.ToolNumericTextBox textPacketSize;
       private Idera.SqlAdminToolset.Core.ToolNumericTextBox textConnectionTimeout;
       private Idera.SqlAdminToolset.Core.ToolNumericTextBox textBasicPort;
       private Idera.SqlAdminToolset.Core.ToolNumericTextBox textConnectionLifetime;
       private Idera.SqlAdminToolset.Core.ToolNumericTextBox textMinPoolSize;
       private Idera.SqlAdminToolset.Core.ToolNumericTextBox textMaxPoolSize;
       private Idera.SqlAdminToolset.Core.ToolNumericTextBox textAdvancedPort;
       private DevComponents.DotNetBar.Controls.TextBoxX textConnectionString;
       private System.Windows.Forms.ToolStripMenuItem menuManageServerGroups;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private IderaTrialExperienceCommon.Controls.IderaTitleBar ideraTitleBar1;
        private ToolStripMenuItem manuManageLicense;
    }
}

