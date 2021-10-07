using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SqlDiscovery
{

    /// <summary>
    /// Ping
    /// 
    /// Very simple class to enable ICMP check for remote hosts.  I find this essential in speeding up the host scans.  However, since XP SP2, this
    /// may need to default to disabled.  All those firewalls means lots of false negatives where machines are blocking ICMP but SQL is listening.
    /// Something to consider.
    /// </summary>
		public class Ping
		{
			IPAddress hostadd;
			int timeout_ms;
			string last_error = "";
			string resolved_ip_address = "";

			public Ping()
			{
				timeout_ms = 2000;		
			}

			public Ping(int a_timeout_ms)
			{
				timeout_ms = a_timeout_ms;
			}

			public  string  LastError
			{
				get
				{
					return last_error;
				}
			}

			public  string  IpAddress
			{
				get
				{
					return resolved_ip_address;
				}
			}
		
			public bool CheckByNameOrIP(String vw_name)
			{

				try
				{
					hostadd = Dns.GetHostEntry(vw_name).AddressList[0];
				}
				catch (System.Net.Sockets.SocketException  ex)
				{
					last_error = ex.Message;
					return false;
				}
				catch
				{}
	
				return local_ping();
			}
				
									 
			public bool CheckByIpAddr(String ip_addr)
			{
            using ( CoreGlobals.traceLog.DebugCall() )
            {
				   try
				   {
					   hostadd = IPAddress.Parse(ip_addr);
				   }
				   catch (System.Net.Sockets.SocketException  ex )
				   {
                 Utility.WriteDebug(ip_addr, "CheckByIpAddr Error parsing IP: SocketException: " + ex.Message);
				   
					   last_error = ex.Message;
					   return false;
				   }
				   catch (Exception ex2 )
				   {
                  Utility.WriteDebug(ip_addr, "CheckByIpAddr Error parsing IP: Exception: " + ex2.Message);
				   }
				}

				return local_ping();
			}

         private bool local_ping()
         {
             bool pingSucceeded = false;
             
             //set options ttl=128 and no fragmentation
             PingOptions options = new PingOptions(128, true);
  
             //create a Ping object
             System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
             
            
                //32 empty bytes buffer
             byte[] data = new byte[32];

             List<long> responseTimes = new List<long>();

             System.Net.NetworkInformation.PingReply reply = ping.Send(hostadd, timeout_ms, data, options);

             if (reply != null)
             {
                 switch (reply.Status)
                 {
                     case IPStatus.Success:
                        pingSucceeded = true;
                         break;
                     case IPStatus.TimedOut:
                         Utility.WriteDebug(resolved_ip_address, "local_ping: TimeOut" );
                         break;
                     default:
                         Utility.WriteDebug(resolved_ip_address,
                                            String.Format( "local_ping: Error:" + reply.Status.ToString() ) );
                         break;                   
                 }
             }
             else
             {
                Utility.WriteDebug(resolved_ip_address, "local_ping: Error: Unknown Problem");
             }
             
             return pingSucceeded;
         }

			private  bool local_ping_old()
			{
 		      Socket socket = null;
          
            using ( CoreGlobals.traceLog.DebugCall() )
            {
				   const  int SEND_SIZE  = 16;
				   const  int RECEIVE_SIZE  = 200;
				   const  int ECHO_PORT = 7;

				   resolved_ip_address = hostadd.ToString();

				   byte[] SendBytes = new byte[SEND_SIZE];
				   byte[] RecvBytes = new byte[RECEIVE_SIZE];


				   int rcvd;
				   IPEndPoint EPhost;
				   int sent;

				   try
				   {
					   EPhost = new IPEndPoint(hostadd, ECHO_PORT);

					   socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
					   
					   SendBytes[0] = 8;
					   SendBytes[1] = 0;
					   SendBytes[2] = 0xF7;
					   SendBytes[3] = 0xFF;
					   SendBytes[4] = 0;
					   SendBytes[5] = 0;
					   SendBytes[6] = 0;
					   SendBytes[7] = 0;
					   SendBytes[8] = 0;
					   SendBytes[9] = 0;
					   SendBytes[10] = 0;
					   SendBytes[11] = 0;
					   SendBytes[12] = 0;
					   SendBytes[13] = 0;
					   SendBytes[14] = 0;
					   SendBytes[15] = 0;

					   // send the ECHO
					   sent = socket.SendTo(SendBytes, SEND_SIZE, SocketFlags.None, EPhost);

					   ArrayList cr = new ArrayList();
					   cr.Add(socket);

					   //now receive the ECHO response
					   Socket.Select(cr, null, null, timeout_ms);            //1 sec  select time in microseconds

					   if (cr.Count > 0)
					   {
						   rcvd = socket.Receive(RecvBytes, RECEIVE_SIZE, SocketFlags.None);
						   last_error = "";
						   return true;
					   }

				   }

				   catch (System.Net.Sockets.SocketException ex)
				   {
                  Utility.WriteDebug(resolved_ip_address, String.Format( "local_ping: {0} SocketException: {1} ",
                                                           resolved_ip_address,
                                                           ex.Message) );
					   last_error = ex.Message;
					   return false;
				   }
				   catch ( Exception ex2 )
				   {
                  Utility.WriteDebug(resolved_ip_address, String.Format( "local_ping: {0} Exception: {1} ",
                                                          resolved_ip_address,
                                                          ex2.Message) );
				   }
				   finally
				   {
				      try { if ( socket != null ) socket.Close(); } catch {}
				   }

				   last_error = "Timeout trying to reach the remote host";
				   return false;
			   }
			}
		}
	}