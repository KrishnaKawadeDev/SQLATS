using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Smo = Microsoft.SqlServer.Management.Smo;
using System.ServiceProcess;


using Idera.SqlAdminToolset.Core;
using System.Security.Principal;
using Idera.SqlAdminToolset.Core.Security;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.ConnectionCheck
{
   public partial class Form_Main : Form
   {
      string    m_server;
      string    m_host;
      string    m_instance;
      string    m_port;
      IPAddress m_hostIP;
      
      enum TestResult
      {
         OK = 0,
         Warning = 1,
         Error = 2,
         InProgress = 3,
         None = 4,
         Up = 5,
         Down = 6
      }
      
      Thread _executionThread;
      bool   cancelRequested;
      Impersonation _Impersonation;
   
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

        protected override void OnLoad( EventArgs e )
      {
         #region Common Onload code

         base.OnLoad( e );
         if ( !Startup.GuiStartup( this, menuTools, menuAbout, ideraTitleBar1) )
         {
            Close();
            return;
         }

         #endregion

         // Program Specific Logic
      }

      #endregion

      #region Common Code

      #region File Menu Event Handlers (Common)

      private void menuFileExit_Click( object sender, EventArgs e )
      {
         Close();
      }

      private void menuExitToLaunchpad_Click( object sender, EventArgs e )
      {
         Launchpad.RunAndClose( this );
      }

      #endregion

      #region Help Menu Event Handlers (Common)

      private void menuShowHelp_Click( object sender, EventArgs e )
      {
         HelpMenu.ShowHelp();
      }

      private void menuDeactivateLicense_Click( object sender, EventArgs e )
      {
         HelpMenu.ShowDeactivateLicense();
      }

      private void menuAbout_Click( object sender, EventArgs e )
      {
         HelpMenu.ShowAboutForm();
      }

      private void menuSearchIderaKnowledgeBase_Click( object sender, EventArgs e )
      {
         HelpMenu.ShowURL_SearchIderaKnowledgeBase( this );
      }

      private void menuAboutIderaProducts_Click( object sender, EventArgs e )
      {
         HelpMenu.ShowURL_AboutIderaProducts( this );
      }

      private void menuContactTechnicalSupport_Click( object sender, EventArgs e )
      {
         HelpMenu.ShowURL_ContactTechnicalSupport( this );
      }

      private void menuCheckForUpdates_Click( object sender, EventArgs e )
      {
         HelpMenu.CheckForUpdates( this );
      }

      #endregion

      #region Tools Menu (Common )

      private void menuManageServerGroups_Click( object sender, EventArgs e )
      {
         ToolsMenu.ManageServerGroups();
      }

      private void menuToolsetOptions_Click( object sender, EventArgs e )
      {
         ToolsMenu.ShowToolsetOptions();
      }

      private void menuLaunchpad_Click( object sender, EventArgs e )
      {
         ToolsMenu.RunLaunchpad( this );
      }

      #endregion

      #endregion

      #region SQL Server & Credentials Field Handling

      private void buttonBrowseServer_Click( object sender, EventArgs e )
      {
         Form_SQLServerBrowse browseDlg = new Form_SQLServerBrowse();

         Cursor = Cursors.WaitCursor;
         bool loaded = browseDlg.LoadServers();
         Cursor = Cursors.Default;

         if ( loaded )
         {
            DialogResult choice = browseDlg.ShowDialog();
            if ( choice == DialogResult.OK )
            {
               if ( textServer.Text != browseDlg.SelectedServer )
               {
                  textServer.Text = browseDlg.SelectedServer;
               }
            }
         }
      }

      private void textServer_TextChanged( object sender, EventArgs e )
      {
         buttonTestNetwork.Enabled = textServer.Text.Trim().Length != 0;
      }

      #endregion

      #region Display Logic
      
      TreeNode m_currentTestNode = null;
      
      delegate void StartTestDelegate(string testName);
      private void
         StartTest(
            string testName
         )
      {
         if (InvokeRequired)
         {
            BeginInvoke(new StartTestDelegate(StartTest), testName);
            Thread.Sleep(200);
            return;
         }
         m_currentTestNode = new TreeNode( testName );
         m_currentTestNode.ToolTipText = testName;
         m_currentTestNode.ImageIndex         = 3;
         m_currentTestNode.SelectedImageIndex = 3;
         treeResults.Nodes.Add( m_currentTestNode );
         m_currentTestNode.Expand();
         m_currentTestNode.EnsureVisible();
      }
      
      delegate void StopTestDelegate(TestResult testResult);
      private void
         StopTest(
            TestResult testResult
         )
      {
         if (InvokeRequired)
         {
            BeginInvoke(new StopTestDelegate(StopTest), testResult);
            return;
         }
         m_currentTestNode.ImageIndex         = (int)testResult;
         m_currentTestNode.SelectedImageIndex = (int)testResult;
      }
      
      private void AddResult( string result )
      {
         AddResult( m_currentTestNode, result, TestResult.None, true );
      }
      
      private void AddResult( TreeNode parent, string result )
      {
         AddResult( parent, result, TestResult.None, true );
      }
      
      private void AddErrorResult( string result )
      {
         AddResult( m_currentTestNode, result, TestResult.None, false );
      }
      
      private void AddErrorResult( TreeNode parent, string result )
      {
         AddResult( parent, result, TestResult.None, false );
      }
      
      
//      private void
//         AddResult(
//            string     result,
//            TestResult testResult
//         )
//      {
//         AddResult( m_currentTestNode, result, testResult );
//      }

      delegate void AddResultDelegate(TreeNode parentNode, string result, TestResult testResult, bool successfulStep);
      private void
         AddResult(
            TreeNode   parentNode,
            string     result,
            TestResult testResult,
            bool       succesfulStep
         )
      {
         if (InvokeRequired)
         {
            BeginInvoke(new AddResultDelegate(AddResult), parentNode, result, testResult, succesfulStep);
            return;
         }

         TreeNode rNode = new TreeNode( result );
         parentNode.Nodes.Add( rNode );
         parentNode.Expand();
         
         if ( succesfulStep )
         {
            rNode.ImageIndex         = 8;
            rNode.SelectedImageIndex = 8;
         }
         else
         {
            rNode.ImageIndex         = 7;
            rNode.SelectedImageIndex = 7;
            rNode.ForeColor          = Color.Red;
         }
         //rNode.EnsureVisible();
         
         rNode.ToolTipText = Helpers.CreateWrappedString(result, 60);
         
         Application.DoEvents();
         
         //return rNode;
      }
      
     
      private TreeNode m_nicRoot = null;
      private TreeNode m_nicNode = null;
      
      delegate void AddNicNodeDelegate( bool root, TreeNode parent, string result, TestResult testResult);
      private void
         AddNicNode(
            bool       root,
            TreeNode   parent,
            string     result,
            TestResult testResult
            
         )
      {
         if (InvokeRequired)
         {
            BeginInvoke(new AddNicNodeDelegate(AddNicNode), root, parent, result, testResult);
            Thread.Sleep(200);
            return;
         }
         
         TreeNode rNode = new TreeNode( result );
         parent.Nodes.Add( rNode );
         rNode.ImageIndex         = (int)TestResult.None;
         rNode.SelectedImageIndex = (int)TestResult.None;
         rNode.Expand();
         
         Application.DoEvents();
         
         if ( root ) 
            m_nicRoot = rNode;
         else
            m_nicNode = rNode;
      }

      delegate void CollapseNodeDelegate(TreeNode node);
      private void CollapseNode( TreeNode node )
      {
         if (InvokeRequired)
         {
            BeginInvoke(new CollapseNodeDelegate(CollapseNode), node);
            return;
         }
         node.Collapse();
      }

      delegate void SetRecommendationDelegate(string recommendation);
      private void SetRecommendation( string recommendation)
      {
         if (InvokeRequired)
         {
            BeginInvoke(new SetRecommendationDelegate(SetRecommendation), recommendation);
            return;
         }
         if ( textRecommendation.Text != "" ) textRecommendation.Text += "\r\n\r\n";
         textRecommendation.Text += recommendation;
      }
      
      #endregion
      
      #region Impersonation
      
      private void Impersonate()
      {
         if ( radioWindows.Checked && textWindowsUser.Text != "" )
         {
             if (_Impersonation != null)
             {
                 _Impersonation.Undo();
             }
             _Impersonation = new Impersonation(textWindowsUser.Text, textWindowsPassword.Text);
             _Impersonation.Start();
         }
      }
      
      #endregion
      
      #region Test Engine
      
      bool runAllTests = false;
      
      private delegate void TestFunction();
      
      private void
         RunTest(
            TestFunction test
         )
      {
          try
          {
              buttonTestAll.Enabled = false;
              buttonTestNetwork.Enabled = false;
              buttonTestSQL.Enabled = false;
              buttonCancel.Enabled = true;
              cancelRequested = false;

              menuCopy.Enabled = false;
              contextMenuCopy.Enabled = false;

              textRecommendation.ResetText();
              treeResults.Nodes.Clear();
              Application.DoEvents();

              if (test == TestSQL || test == TestAll)
              {
                  Impersonate();
              }

              ThreadStart testDelegate = new ThreadStart(test);
              _executionThread = new Thread(testDelegate);
              //_executionThread.IsBackground = true;
              _executionThread.Start();
          }
          catch (Exception exc)
          {
              Messaging.ShowException("Running Test", exc);
              TestsCompleted();
          }
      }
         
      delegate void TestCompletedDelegate();
      private void TestsCompleted()
      {   
         if (InvokeRequired)
         {
            BeginInvoke(new TestCompletedDelegate(TestsCompleted));
            return;
         }
         buttonCancel.Enabled = false;
         buttonTestAll.Enabled = true;
         buttonTestNetwork.Enabled = true;
         buttonTestSQL.Enabled = true;
         labelCancelInProgress.Visible = false;
         
         menuCopy.Enabled = true;
         contextMenuCopy.Enabled = true;
         
         
         treeResults.Select();
         
         _executionThread = null;

         if (_Impersonation != null)
         {
             _Impersonation.Undo();
         }
      }
      
      delegate void MarkCancelDelegate();
      private void MarkCancel()
      {
         if (InvokeRequired)
         {
            BeginInvoke(new MarkCancelDelegate(MarkCancel));
            return;
         }
         
         StartTest( "Test Cancelled" );
         StopTest(TestResult.Warning );
         textRecommendation.Text = ProductConstants.TestCancelled;
      }

      private void buttonTestAll_Click( object sender, EventArgs e )
      {
         if ( ! ValidateInput() ) return;
         
         RunTest( TestAll );
      }
      
      private void buttonTestSQL_Click( object sender, EventArgs e )
      {
         if ( ! ValidateInput() ) return;
         
         RunTest( TestSQL );
      }
      
      private void buttonTestNetwork_Click( object sender, EventArgs e )
      {
         if ( ! ValidateInput(false) ) return;
         
         RunTest( TestNetwork );
      }
      
      #endregion
      
      #region Validation

      private bool ValidateInput()
      {
          return ValidateInput(true);
      }

      private bool ValidateInput(bool includeSqlCredentials)
      {
         if ( includeSqlCredentials && radioSQL.Checked && textLoginName.Text.Trim().Length == 0 )
         {
            Messaging.ShowError( "A login name is required when using SQL authentication." ); 
            return false;
         }
         return true;
      }
      
      #endregion
      
      #region Main Test Routines
      
      private void TestAll()
      {
         string recommendation = "";
         
         runAllTests = true;
         
         PrepWork();
         
         // SQL Tests
         bool sqlFailed = DoSqlTests();
         
         if ( cancelRequested )
         {
            MarkCancel();              
            TestsCompleted();
            return;
         }
         
         // Network Tests
         if ( DoNetworkTests( ref recommendation) )
         {
            if ( sqlFailed )
            {
               // network passed but SQL failed
               SetRecommendation( ProductConstants.ConnectionFailureWithGoodNetwork );
            }
            else
            {
               // all tests passed
               SetRecommendation( ProductConstants.AllIsWell );
            }
         }
         else
         {
           // network failed
           SetRecommendation( recommendation );
         }
         
         TestsCompleted();
      }

      
      private void TestSQL()
      {
         runAllTests = false;
   
         PrepWork();
         DoSqlTests();
         
         TestsCompleted();
      }
      
      private void TestNetwork()
      {
         string recommendation = "";
         
         runAllTests = false;
         
         
         PrepWork();
         if ( DoNetworkTests( ref recommendation ) )
         {
            SetRecommendation( ProductConstants.AllIsWell );
         }
         else
         {
            SetRecommendation( recommendation );
         }
         
         TestsCompleted();
      }
      
      private bool DoSqlTests()
      {
         bool keepGoing = SqlConnectionTest();
         
         return keepGoing;
      }
      
      private bool
         DoNetworkTests(
            ref string recommendation
         )
      {
         bool success = false;
         
         // Step 1 - Get Host Computer IP
         if ( GetRemoteIP()  )
         {
            if ( cancelRequested )
            {
               MarkCancel();
               return false;
            }
            
            // Step 2 - Ping Host Computer
            if ( PingRemoteIP() )
            {
               if ( cancelRequested )
               {
                  MarkCancel();
                  return false;
               }
            
               // Step 3 - Check state of SQL Service on Host Computer
               //          this is the only path that can succeed!
               success = TestRemoteService( ref recommendation);
            }
            else
            {
               if ( cancelRequested )
               {
                  MarkCancel();
                  return false;
               }
            
               // Ping failed - check local computer
               if ( CheckLocalComputer() )
               {
                  // local OK - ping failure recommendation
                  recommendation = ProductConstants.Error_PingFailure;
               }
               else
               {
                  // local not OK - ping failure recommendation
                  recommendation = ProductConstants.Error_LocalProblem;
               }
            }
         }
         else
         {
            if ( cancelRequested )
            {
               MarkCancel();
               return false;
            }
            
            // Cant resolve host computer IP, DNS problem - check local computer network settings
            if ( CheckLocalComputer() )
            {
               // local OK - dns failure recommendation
               recommendation = ProductConstants.Error_DnsFailure;
            }
            else
            {
               // local not setup up right
               recommendation = ProductConstants.Error_LocalProblem;
            }
         }
         
         return success;
      }
      
      private void PrepWork()
      {
         // Possible server name formats:
         // name, name,port, name\name, name\name,port
         m_server   = SQLHelpers.NormalizeInstanceName(textServer.Text);
         m_host     = SQLHelpers.GetInstanceHost(m_server);
         m_instance = SQLHelpers.GetInstance(m_server);
         m_port     = SQLHelpers.GetPort(m_server);
      }
      
      #endregion
      
      #region SQL Connect Test
      
      private bool SqlConnectionTest()
      {
         TestResult testResult = TestResult.Error;
         StartTest( "Test: Open Connection to target SQL Server" );
      
         bool keepGoing = false;

         string msg = "Connecting to SQL Server '" + m_server + "'";
         
         if ( textDatabase.Text != "" )
         {
            msg += ", database '" + textDatabase.Text + "'";
         }
         
         if ( textPort.Text != "" )
         {
            msg += ", port " + textPort.Text;
         }
         
         SQLCredentials sqlCredentials = new SQLCredentials( radioSQL.Checked,
                                                             textLoginName.Text,
                                                             textPassword.Text );
                                                             
         if ( sqlCredentials == null || sqlCredentials.useWindowsAuthentication )
         {
            msg += " using Windows Authentication";
         }
         else
         {
            msg += " using SQL Login " + sqlCredentials.loginName;
         }
         
         
         AddResult( msg );
         
         SqlConnection conn = null;
         
         
         try
         {
            string server = m_server;
            if ( ! String.IsNullOrEmpty(textPort.Text.Trim()))
               server += "," + textPort.Text.Trim();
               
            conn = Connection.OpenConnection( server,
                                              textDatabase.Text,
                                              sqlCredentials );
            // connection succeeded!                                                
            AddResult( "Test passed - Connection opened successfully." );
            
            testResult = TestResult.OK;

            SetRecommendation( "SQL Connection test passed. No further action is required. " );
         }
			catch (SqlException sqlEx)
			{
            string m = String.Format( "Error: {0},{1} - {2}",  sqlEx.ErrorCode, sqlEx.Number, Helpers.StripFormatCharacters(sqlEx.Message) );
            AddErrorResult( m );
            testResult = TestResult.Error;

				if (sqlEx.Number==18456)
				{
				   SetRecommendation( ProductConstants.Error_18456 );
				}
				else if (sqlEx.Number==18470)
				{
				   SetRecommendation( ProductConstants.Error_18470 );
				}
				else if (sqlEx.Number==18486)
				{
				   SetRecommendation( ProductConstants.Error_18486 );
				}
				else if (sqlEx.Number==4060)
				{
				   SetRecommendation( ProductConstants.Error_4060 );
				}
				else if (sqlEx.Number==4064)
				{
				   SetRecommendation( ProductConstants.Error_4064 );
				}
				else if ( ! runAllTests )
				{
				   // only do generic SQL at this point if we are not running any more tests
				   SetRecommendation( ProductConstants.Error_ConnectionFailedNoNetworkTest );
				}
				else
				{
				   // even though we failed; we are going to run network tests next so we will keep going
               keepGoing = true;             
				}
			}
         catch ( ThreadAbortException tae )
         {
            throw tae;
         }
         catch ( Exception ex )
         {
            string m = "Error: " + Helpers.StripFormatCharacters(Helpers.GetCombinedExceptionText(ex));
            AddErrorResult( m);
            testResult = TestResult.Error;
            
				if ( runAllTests )
				{
               keepGoing = true;             
				}
				else
				{
				   SetRecommendation( ProductConstants.Error_ConnectionFailedNoNetworkTest );
				}
         }
         finally
         {
           Connection.CloseConnection(conn);

           StopTest( testResult );
         }
         
         return keepGoing;
      }
      
      #endregion
      
      #region GetRemoteIP
      
      private bool GetRemoteIP()
      {
         StartTest( "Get IP Address for Host Computer" );
      
         TestResult testResult = TestResult.Error;
         bool success = false;
         
         AddResult( "Host Computer: " + m_host) ;
         
         try
         {
            IPHostEntry hostEntry = Dns.GetHostEntry(m_host);
            AddResult( "Fully Qualifed Name of Computer: " + hostEntry.HostName) ;
         }
         catch (Exception ex )
         {
            AddErrorResult ( String.Format( "Error retrieving fully qualified computer name - Error: {0}",
                                            Helpers.StripFormatCharacters(Helpers.GetCombinedExceptionText(ex))) );
         }
         
         AddResult( "Retrieving IP address" );

         //-----------------         
         // Get IP from DNS
         //-----------------         
         try
         {
            m_hostIP = Helpers.GetIP4Address(m_host);
            AddResult( "Host IP Address: " + m_hostIP.ToString()) ;
            
            testResult = TestResult.OK;
            success    = true;
            AddResult( "Test passed - IP address succesfully retrieved" );
         }
         catch ( ThreadAbortException tae )
         {
            throw tae;
         }
         catch (Exception ex )
         {
            m_hostIP = null;

            AddErrorResult ( String.Format( "Error retrieving IP Address for {0} - Error: {1}",
                                            m_host,
                                            Helpers.StripFormatCharacters(Helpers.GetCombinedExceptionText(ex))) );

   		 //  SetRecommendation( ProductConstants.Error_DnsFailure );
         }
         finally
         {
            StopTest(testResult );
         }
         
         return success;
      }

      #endregion
      
      #region PingRemoteIP
      
      private bool PingRemoteIP()
      {
         StartTest( "Ping Host Computer" );
         TestResult testResult = TestResult.Error;
         bool success = false;
         
         try
         {
            AddResult( String.Format( "Pinging {0} ({1})", m_host, m_hostIP.ToString() ));
            StartPing( m_hostIP );
            testResult = TestResult.OK;
            success    = true;
         }
         catch ( ThreadAbortException tae )
         {
            throw tae;
         }
         catch (Exception pingEx )
         {
            AddErrorResult( "Error: " + Helpers.StripFormatCharacters(pingEx.Message) );
   		  // SetRecommendation( ProductConstants.Error_PingFailure );
         }
         finally
         {
            StopTest(testResult );
         }
         
         return success;
      }
      
      private void StartPing(IPAddress ip)
      {
          //set options ttl=128 and no fragmentation
          PingOptions options = new PingOptions(128, true);

          //create a Ping object
          Ping ping = new Ping();

          //32 empty bytes buffer
          byte[] data = new byte[32];

          int received = 0;
          List<long> responseTimes = new List<long>();

          PingReply reply = ping.Send(ip, 1000, data, options);

          if (reply != null)
          {
              switch (reply.Status)
              {
                  case IPStatus.Success:
                      AddResult( String.Format( "Test Passed - Ping successful (Reply from {0}: " + 
                          "bytes={1} time={2}ms TTL={3}",
                          reply.Address, reply.Buffer.Length, 
                          reply.RoundtripTime, reply.Options.Ttl) );
                      received++;
                      responseTimes.Add(reply.RoundtripTime);
                      break;
                  case IPStatus.TimedOut:
                      throw new Exception ("Ping request timed out.");
                  default:
                      throw new Exception ("Error: " + reply.Status.ToString());
              }
          }
          else
          {
              throw new Exception( "Error: Unknown problem pinging computer");
          }
      }
      
      #endregion
      
      #region Test Remote Service

      private bool
         TestRemoteService(
            ref string recommendation
         )
      {
         StartTest( "Check SQL Server service" );
      
         TestResult testResult = TestResult.Error;
         bool success = false;
         
         AddResult( "Host Computer: " + m_host) ;
         
         try
         {
            if ( m_instance == "" ) throw new Exception( "Cant test service status - cant determine service name for the SQL Server." );
            
            string serviceName ;
            if (m_instance == m_host && m_server == m_host)
                serviceName = "MSSQLSERVER";
            else
            {
                serviceName = "MSSQL$" + m_instance;
            }
               
            AddResult( "Service Name: " + serviceName) ;
            
            AddResult( "Contacting Service Controller on host to determine service status." );
         
            ServiceController sc = new ServiceController( serviceName, m_host );
            
            AddResult( "Service Status  " + sc.Status.ToString());
            
            if ( sc.Status == ServiceControllerStatus.Running )
            {
               success    = true;
               testResult = TestResult.OK;
               AddResult( "Test Passed: The SQL Server service is running." );
               recommendation = ProductConstants.Error_ServiceIsUp;
            }
            else
            {
               AddErrorResult( "Test Failed: The SQL Server service is not running." );
               recommendation = ProductConstants.Error_ServiceIsDown;
            }
         }
         catch ( ThreadAbortException tae )
         {
            throw tae;
         }
         catch ( Exception ex )
         {
            AddErrorResult("Error: " + Helpers.StripFormatCharacters(ex.Message.ToString() +" "+ ex.InnerException.Message.ToString()));
            AddErrorResult( "Test Failed: Could not connect to the SQL Server service on the host computer" );
            recommendation = ProductConstants.Error_ServiceError;
         }
         finally
         {
            StopTest(testResult );
         }

         return success;         
      }
      
      #endregion
      
      #region CheckLocalComputer
      
      private bool CheckLocalComputer()
      {
         StartTest( "Check Local Computer Network Settings" );
         TestResult testResult = TestResult.Error;
         bool success = false;
         
         int upCount      = 0;
         int dnsCount     = 0;
         int gatewayCount = 0;
         
         try
         {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            if (nics == null || nics.Length < 1)
            {
               AddErrorResult( "Test Failed: No network interfaces found.");
               return false;
            }
            
            //Count dns servers and Gateway so that we CancelButton pass OrderedDictionary fail based on existence
            //only Count if up

            AddNicNode( true, m_currentTestNode, "Network Interfaces", TestResult.None );
            TreeNode nicRoot = m_nicRoot;
            
            TreeNode nicNode;
            foreach (NetworkInterface adapter in nics)
            {
               IPInterfaceProperties ip = adapter.GetIPProperties();
               
               string ipAddress;
               if ( ip.UnicastAddresses.Count > 0 )
                  ipAddress = ip.UnicastAddresses[0].Address.ToString();
               else
                  ipAddress = "No IP Address";

               string nodeName = String.Format( "{0} ({1})", adapter.Name, ipAddress );
               
               AddNicNode( false,
                           nicRoot,
                           nodeName,
                           adapter.OperationalStatus == OperationalStatus.Up ? TestResult.Up : TestResult.Down);
               nicNode = m_nicNode;

               if ( adapter.OperationalStatus == OperationalStatus.Up )
                  upCount ++;
               
               AddResult( nicNode, "Type: " + adapter.NetworkInterfaceType.ToString() );
               AddResult( nicNode, "Status: " + adapter.OperationalStatus.ToString() );

               AddResult( nicNode, "Type: " + ip.GetType());
               AddResult( nicNode, "IP Address: " + ipAddress );
               
               // gateway
               string gateway = "";
               foreach (GatewayIPAddressInformation address in ip.GatewayAddresses)
               {
                  if ( gateway != "" ) gateway += ", ";
                  gateway += address.Address.ToString();
                  gatewayCount++;
               }
               if ( gateway=="") gateway += "None";
               AddResult( nicNode, "Default Gateway: " + gateway );
               
               // dns
               string dns = "";
               foreach (IPAddress dnsAddr in ip.DnsAddresses)
               {
                  if ( dns != "" ) dns+= ", ";
                  dns += dnsAddr.ToString();
                  dnsCount++;
               }
               if ( dns=="") dns += "None";
               AddResult( nicNode, "DNS Servers: " + dns );
               
               CollapseNode( nicNode );
            }
            
            if ( upCount != 0 && gatewayCount != 0 && dnsCount != 0 )
            {
               AddResult( "Check Passed: Local network interfaces are configured in a reasonable manner." );
               success = true;
               testResult = TestResult.OK;
            }
            else if (upCount == 0 )
            {
               AddErrorResult( "Error: No network interfaces are Up." );
            }
            else if (gatewayCount == 0 )
            {
               AddErrorResult( "Error: No gateways are defined." );
            }
            else if (dnsCount == 0 )
            {
               AddErrorResult( "Error: No DNS Servers are defined." );
            }
         }
         finally
         {
            StopTest(testResult );
         }

         return success;         
      }
      
      #endregion
      
      #region Window Events

      private void radioSQLorWindows_CheckedChanged( object sender, EventArgs e )
      {
         textLoginName.Enabled = radioSQL.Checked;
         textPassword.Enabled  = radioSQL.Checked;
         textWindowsUser.Enabled     = radioWindows.Checked;
         textWindowsPassword.Enabled = radioWindows.Checked;
      }
      
      private void contextMenuCopy_Click( object sender, EventArgs e )
      {
         CopyTests();
      }
      
      private void CopyTests()
      {
         StringBuilder clipboard = new StringBuilder (2048);
         
         clipboard.Append("Connection Check Test Results");
         clipboard.Append(Environment.NewLine);
         clipboard.Append(DateTime.Now.ToString() );
         clipboard.Append(Environment.NewLine);
         clipboard.Append(Environment.NewLine);
         
         clipboard.Append("SQL Server:\t" + textServer.Text );
         clipboard.Append(Environment.NewLine);
         clipboard.Append("Database:  \t" + (String.IsNullOrEmpty(textDatabase.Text) ? "<Not specified>" : textDatabase.Text));
         clipboard.Append(Environment.NewLine);
         clipboard.Append("Port:      \t" + (String.IsNullOrEmpty(textPort.Text) ? "<Not specified>" : textPort.Text));
         clipboard.Append(Environment.NewLine);
         clipboard.Append(Environment.NewLine);
         
         foreach ( TreeNode test in treeResults.Nodes )
         {
            string msg = String.Format( "{0} ({1})", 
                                        test.Text,
                                        ( test.ImageIndex == 0 ) ? "Passed" : 
                                        ( test.ImageIndex == 1 ) ? "Warning" : "Failed" ); 
            clipboard.Append(msg);
            clipboard.Append(Environment.NewLine);
            
            // sub nodes
            foreach ( TreeNode step in test.Nodes )
            {
               clipboard.Append( CopyChildNode( step, 1) );
            }
         }
         
         clipboard.Append(Environment.NewLine);
         clipboard.Append(Environment.NewLine);
         clipboard.Append("Recommendation:");
         clipboard.Append(Environment.NewLine);
         clipboard.Append(textRecommendation.Text);
         
         Clipboard.SetDataObject(clipboard.ToString());
      }
      
      private string CopyChildNode( TreeNode node, int level )
      {
         StringBuilder clipboard = new StringBuilder(1024);

         // indent         
         for ( int i=0; i<level; i++ ) clipboard.Append("\t");
         
         clipboard.Append(node.Text);
         clipboard.Append(Environment.NewLine);
         
         // sub nodes
         foreach ( TreeNode childNode in node.Nodes )
         {
            clipboard.Append( CopyChildNode( childNode, level+1) );
         }
         
         return clipboard.ToString();
      }

      private void contextMenuExpand_Click( object sender, EventArgs e )
      {
         foreach ( TreeNode treeNode in treeResults.Nodes )
         {
            treeNode.ExpandAll();
         }
      }

      private void collapseAllToolStripMenuItem_Click( object sender, EventArgs e )
      {
         foreach ( TreeNode treeNode in treeResults.Nodes )
         {
            treeNode.Collapse();
         }
      }

      private void menuCopy_Click( object sender, EventArgs e )
      {
         CopyTests();
      }

      private void buttonCancel_Click( object sender, EventArgs e )
      {
         labelCancelInProgress.Visible = true;
         Cursor = Cursors.WaitCursor; 
         cancelRequested = true;
         buttonCancel.Enabled = false;
         Application.DoEvents();
      
         new Thread(new ThreadStart(KillTestThread)).Start();
      }
      
      delegate void ResetCursorDelegate();
      private void ResetCursorToDefault()
      {
         if (InvokeRequired)
         {
            BeginInvoke(new ResetCursorDelegate(ResetCursorToDefault));
            return;
         }
         
         Cursor = Cursors.Default;
      }

      private void KillTestThread()
      {
         try
         {
            Debug.Write( _executionThread.ThreadState.ToString() );
         
            if (_executionThread.ThreadState != System.Threading.ThreadState.Running &&
                _executionThread.ThreadState != System.Threading.ThreadState.WaitSleepJoin )
            {
               return;
            }
            
            if ( ! _executionThread.Join(5000))
            {
               if ( _executionThread != null ) _executionThread.Abort();
               MarkCancel();
               TestsCompleted();
           }
         }
         catch ( Exception ex )
         {
            Debug.Write( ex.Message );
         }
         finally
         {
            ResetCursorToDefault();
            if (_Impersonation != null)
            {
                _Impersonation.Undo();
            }
        }
      }
      
      #endregion
      
      #region Context Menu Display Overload Routines
      // Because we cant tell what node was right clicked on, we cant 
      // make context sensitive context menus without hand doing it
      // behind the scenes. So we overload KeyUp and MouseUp and 
      // determine the node and do the right thing
      private void treeResults_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
      {
         // Handle the context menu key
         if ( e.KeyCode == Keys.Apps )
         {
            Point pt = new Point( treeResults.SelectedNode.Bounds.Left,
                                  treeResults.SelectedNode.Bounds.Bottom );
            //ResetContextMenu();
            contextMenuCollapse.Show( treeResults, pt );
         }
      }

      private void treeResults_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if ( e.Button != MouseButtons.Right ) return;
         
         Point pt = new Point( e.X, e.Y );
         treeResults.PointToClient( pt );

         TreeNode Node = treeResults.GetNodeAt( pt );
         if ( Node == null ) return;
         if ( Node.Bounds.Contains( pt ) )
         {
            treeResults.SelectedNode = Node;
            //ResetContextMenu();
            contextMenuCollapse.Show( treeResults, pt );
         }
      }
      
      #endregion

      private void textServer_KeyPress( object sender, KeyPressEventArgs e )
      {
         // eat semi-colons so user cant try to supply multiple servers
         if (e.KeyChar == ';')
         {
            e.Handled=true; // input is not passed on to the control(TextBox) 
         }
         base.OnKeyPress (e);
      }

      private void ShowF1Help(object sender, HelpEventArgs hlpevent)
      {
         HelpMenu.ShowHelp();
      }

      private void menuHelp_Click(object sender, EventArgs e)
      {
         base.OnClick(e);
      }

        private void menuManageLicense_Click(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }

        private void ideraTitleBar1_LicenseInfoButtonClick(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }
    }
}

