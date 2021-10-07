using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

using Idera.SqlAdminToolset.Core;


namespace Idera.SqlAdminToolset.SqlDiscovery
{
	public class UdpCheck
	{

        // This class performs the UDP 1434 query for the SQL Resolution service.  This is ported from the original SQLPing application

		private Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram , ProtocolType.Udp );
		private EndPoint EPresponse = new IPEndPoint(0,1434);
		private byte[] recbuf = new byte[64000];
		private string remoteIP;
		private int localPort; 
        private bool bClosed = false;
        static int classCount = 0;

		public UdpCheck(string txtremoteIP, int txtlocalPort) 
		{
		
            classCount ++;
            remoteIP = txtremoteIP;
			localPort = txtlocalPort;
			//s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram , ProtocolType.Udp );
			s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			s.Bind(new IPEndPoint(IPAddress.Any, localPort));
			s.BeginReceiveFrom(recbuf,0,recbuf.GetLength(0),SocketFlags.None,ref EPresponse, new AsyncCallback(OnReceive), null); 

		}

		private void OnReceive(IAsyncResult ar)
		{
            Utility.WriteDebug(remoteIP, "UDP: OnReceive - Start (" + classCount.ToString() + ")");

            if (bClosed)
            {
                Utility.WriteDebug(remoteIP, "UDP: OnReceive - leave (socket closed)");
                return;
            }

            int len = 0;
			EndPoint clientEndPoint = new IPEndPoint(0, 1434);

			try
			{
				len = s.EndReceiveFrom(ar, ref clientEndPoint);
            }
            catch (Exception e1)
            {
                Utility.WriteDebug(remoteIP, "UDP: OnReceive 1 - " + e1.Message);
            }

            if (len <= 0)
            {
                Utility.WriteDebug(remoteIP, "UDP: OnReceive - leave (results length = 0)");
                return;
            }

            try
            {
                string instanceList = Encoding.ASCII.GetString(recbuf, 3, len - 3);
                string[] sql_instances = System.Text.RegularExpressions.Regex.Split(Encoding.ASCII.GetString(recbuf, 3, len - 3), "ServerName");
                
                Utility.WriteDebug(remoteIP, String.Format( "UDP: OnReceive - instancelist Count:{0} - {1}",
                                                            sql_instances.Length, instanceList ));

                foreach (string sql_response_instance in sql_instances)
                {
                    if (sql_response_instance.Length > 0)
                    {
                        //string[] sql_response = Encoding.ASCII.GetString(recbuf, 3, len-3).Replace(";;","\n;").Split(";".ToCharArray());
                        //int next_instance_start = sql_instances.IndexOf("ServerName",2);	
                        string[] sql_response = sql_response_instance.Split(";".ToCharArray());

                        string previous = "";
                        string tcpport = "";
                        foreach (string response in sql_response)
                        {
                            if (previous == "tcp")
                            {
                                tcpport = response;
                            }
                            previous = response;
                        }
                        
                        string protocols = Encoding.ASCII.GetString(recbuf, 3, len - 3);
                        string thisInstanceProtocol = GetInstanceProtocol( sql_response[1], sql_response[3], protocols );

                        Utility.PushResults(
                            /* txtServerIP        */   ((IPEndPoint)clientEndPoint).Address.ToString(),
                            /* txtServerName      */   sql_response[1],
                            /* txtInstanceName    */   sql_response[3],
                            /* txtIsClustered     */   sql_response[5],
                            /* txtVersion         */   sql_response[7],
                            /* txtTCPPort         */   tcpport,
                            /* txtProtocols       */   thisInstanceProtocol,
                            /* txtTrueVersion,    */   "",
                            /* txtServiceAccount  */   "",
                            /* txtDetectionMethod */   "UDP",
                            /* txtSSNetlibVersion */   (Globals.disableSSNetlibVersionCheck)
                                                           ? ""
                                                           : Idera.SqlAdminToolset.SqlDiscovery.UdpCheck.SSNetlibVersion(((IPEndPoint)clientEndPoint).Address.ToString(),
                                                                                               tcpport));
                        //sql_instances = sql_instances.Substring(next_instance_start);	
                    }
                }
                Utility.WriteDebug(remoteIP, "UDP: OnReceive - Done: Instances Count: " + sql_instances.Length.ToString());

            }
            catch (Exception e2)
            {
                Utility.WriteDebug(remoteIP, "UDP: OnReceive 2 - " + e2.Message);
            }

			//Start another Async Listener 
			try
			{
				s.BeginReceiveFrom( recbuf,
                                    0,
                                    recbuf.GetLength(0),
                                    SocketFlags.None,
                                    ref EPresponse,
                                    new AsyncCallback(OnReceive),
                                    null); 
			}
            catch (Exception e3)
            {
                Utility.WriteDebug(remoteIP, "UDP: OnReceive 3 - " + e3.Message);
            }

		}
		
		private string
		   GetInstanceProtocol(
		      string server,
		      string instance,
		      string fullProtocol
		   )
		{
		   List<string> indivProtocols = new List<String>();
		   int pos;
		   int startPos = 0;
		   while ( -1 != (pos = fullProtocol.IndexOf(";;", startPos)) )
		   {
		      indivProtocols.Add( fullProtocol.Substring(startPos, pos-startPos));
		      startPos = pos + 2;
		      if ( startPos >= fullProtocol.Length ) break;
		   }
		   indivProtocols.Add( fullProtocol.Substring(startPos));
		   
         string prefix = String.Format( "ServerName;{0};InstanceName;{1}", server, instance );
		   
		   string protocol = "";
		   
		   for ( int i=0; i<indivProtocols.Count; i++ )
		   {
		      if ( indivProtocols[i].StartsWith(prefix) )
		      {
		         protocol = indivProtocols[i];
		         break;
		      }
		   }
		   
		   if ( protocol == "" ) protocol = fullProtocol;
		   
		   return protocol;
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		public void SendSingle()
		{
			try
			{
            using ( CoreGlobals.traceLog.DebugCall() )
            {
                   //
				   // Create new UDP socket and acquire some port number
				   // for it
				   //
				   //s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				   //s.Bind(new IPEndPoint(IPAddress.Any, 0));

				   // Get Endpoint for Responses
				   //EndPoint serverEndPoint = new IPEndPoint(0,0);
   				
				   // Calls back to a function if message returns on this socket from a remote host.
				   //s.BeginReceiveFrom(recbuf,0,recbuf.GetLength(0),SocketFlags.None,ref EPresponse, new AsyncCallback(OnReceive), null); 

				   //
				   // Send query packet (x03) to server
				   //
				   byte[] buffer = new byte[] {3};
   			
				   s.SendTo(buffer, new IPEndPoint(IPAddress.Parse(remoteIP), 1434));
   				
				   //s.ReceiveFrom(recbuf,ref serverEndPoint);

				   Thread.Sleep(1000);

				   s.Close();
                   bClosed = true;

            }
         }
			catch (Exception e)
			{
		        Utility.WriteDebug(remoteIP, "UDP: SendSingleMessage - " + e.Message);
			}
		}

		public void SendBroadcast()
		{
			try
			{
				//
				// Create new UDP socket and acquire some port number
				// for it
				//
				//s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				//s.Bind(new IPEndPoint(IPAddress.Any, 0));

				// Get Endpoint for Responses
				//EndPoint serverEndPoint = new IPEndPoint(0,0);
				
				
				// Calls back to a function if message returns on this socket from a remote host.


				//s.BeginReceiveFrom(recbuf,0,recbuf.GetLength(0),SocketFlags.None,ref EPresponse, new AsyncCallback(OnReceive), null); 

				//
				// Send query packet (x02) to server
				//
				byte[] buffer = new byte[] {4};
				s.SendTo(buffer, new IPEndPoint(IPAddress.Parse(Dns.GetHostEntry(remoteIP).AddressList[0].ToString()), 1434));


				//Start a 5 second countdown to stop execution
				Thread.Sleep(3000);				
			
		
				s.Shutdown(0);
				s.Close();
			}
            catch (Exception e)
            {
                Utility.WriteDebug(remoteIP, "UDP: SendBroadcast - " + e.Message);
            }
		}
/*
		public static void SendRange(string targetstart, string targetend)
		{
			try
			{
				//
				// Create new UDP socket and acquire some port number
				// for it
				//
				s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				s.Bind(new IPEndPoint(IPAddress.Any, 0));

				// Get Endpoint for Responses
				EndPoint serverEndPoint = new IPEndPoint(0,0);
				
				// Calls back to a function if message returns on this socket from a remote host.
				s.BeginReceiveFrom(recbuf,0,recbuf.GetLength(0),SocketFlags.None,ref EPresponse, new AsyncCallback(OnReceive), null); 

				//
				// Send query packet (x02) to server
				//
				byte[] buffer = new byte[] {2};
				for (long ip=IPToLong(targetstart);ip<=IPToLong(targetend);ip++)
				{
					s.SendTo(buffer, new IPEndPoint(IPAddress.Parse(LongToIP(ip)), 1434));
					//Start a 5 second countdown to stop execution
					DateTime mark = new DateTime();
					mark = DateTime.Now;			
					while (mark.AddSeconds(1)>DateTime.Now)
					{
						System.Windows.Forms.Application.DoEvents();
					}
					
				}


		
				//s.Close();
			}
			catch 
			{
				//Console.WriteLine("Error: "+e.Message);
			}
		}
*/




		public static string SSNetlibVersion(string remoteIP, string port)
		{
			string versionString="";

            // no port - no connect 
            if (port == "") return versionString;

			try
			{
				TcpClient objTCP = new TcpClient();
				objTCP.Connect(remoteIP, Convert.ToInt16(port));
				NetworkStream stream = objTCP.GetStream();

				// Send the message to the connected TcpServer. 
				Byte[] data = new Byte[] {(byte)0x12,(byte)0x01,(byte)0x00,(byte)0x34,(byte)0x00,(byte)0x00,(byte)0x00,(byte)0x00,
											 (byte)0x00,(byte)0x00,(byte)0x15,(byte)0x00,(byte)0x06,(byte)0x01,(byte)0x00,(byte)0x1b,
											 (byte)0x00,(byte)0x01,(byte)0x02,(byte)0x00,(byte)0x1c,(byte)0x00,(byte)0x0c,(byte)0x03,
											 (byte)0x00,(byte)0x28,(byte)0x00,(byte)0x04,(byte)0xff,(byte)0x08,(byte)0x00,(byte)0x01,
											 (byte)0x55,(byte)0x00,(byte)0x00,(byte)0x00,(byte)0x4d,(byte)0x53,(byte)0x53,(byte)0x51,
											 (byte)0x4c,(byte)0x53,(byte)0x65,(byte)0x72,(byte)0x76,(byte)0x65,(byte)0x72,(byte)0x00,
											 (byte)0x04,(byte)0x08,(byte)0x00,(byte)0x00};
				stream.Write(data, 0, data.Length);

				// Buffer to store the response bytes.
				Byte[] returndata = new Byte[255];

				// String to store the response ASCII representation.
				String responseData = String.Empty;

				// Read the first batch of the TcpServer response bytes.
				Int32 bytes = stream.Read(returndata, 0, returndata.Length);

				responseData = System.Text.Encoding.ASCII.GetString(returndata, 0, bytes);
				versionString=returndata[29].ToString()+"."+returndata[30].ToString()+"."+((returndata[31]*256)+returndata[32]).ToString();
				if (versionString.Substring(0,1)=="0") versionString="";

			}
            catch (Exception e)
            {
                Utility.WriteDebug(remoteIP, "UDP: SSNetlibVersion - " + e.Message);
            }
			
			return versionString;
			}

	}
}