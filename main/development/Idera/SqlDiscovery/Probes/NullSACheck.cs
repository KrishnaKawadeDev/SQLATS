using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data.SqlClient;


using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SqlDiscovery
{
	/// <summary>
	/// NullSACheck
    /// 
    /// Check machines for null SA account access.  It also checks for Trusted access - very handy for determining true version where the applicable permissions
    /// are present.
	/// </summary>
	public class NullSACheck
	{
		private string remoteIP;
		private string remoteInstance;

		public NullSACheck(string txtRemoteIP, string txtInstance)
		{
			remoteInstance = txtInstance;
			remoteIP=txtRemoteIP;
		}

		public void Scan() 
		{
			if (remoteInstance=="")
				remoteInstance="MSSQLSERVER";

            string dataSource = "";
            if (Globals.localIP == remoteIP)
                dataSource = ".";
            else
                dataSource = remoteIP;

			if ((remoteInstance!="MSSQLSERVER")&&(remoteInstance!=""))
				dataSource = dataSource+"\\"+remoteInstance;
            SqlConnection conn = new SqlConnection("Data Source=" + dataSource + ";Initial Catalog=master;User ID=sa;Password=;Connection Timeout=10;Application Name='Idera SQL discovery'");

            string hostEntry = "";
            try
            {
                hostEntry = Utility.GetHostFromIP(remoteIP);
            }
            catch
            {
                hostEntry = "<Unknown> - DNS Lookup Failed";
            }


			try 
			{
				conn.Open();
				//We're in - might as well get the real version info
				string trueversion="";
				try
				{
					SqlCommand myCommand = new SqlCommand("xp_msver 'ProductVersion'",conn);
					SqlDataReader myReader;
					myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					myReader.Read();
					trueversion = myReader.GetString(3);
					myReader.Close();
				}
				catch
				{}
				Utility.PushResults(remoteIP,hostEntry,remoteInstance,"","","","Login with blank password succeeded for SA",trueversion,"","SA","");
			}
			catch (SqlException e)
			{
				//Debug.WriteLine(e.Number + " : " + e.Message);
				if (e.Number==18456)
					Utility.PushResults(remoteIP,hostEntry,remoteInstance,"","","","Login with blank password failed for SA",GetVersion(),"","SA","");
				else
					Utility.PushResults(remoteIP,hostEntry,remoteInstance,"","","","Login required trusted context so couldn't determine if SA has blank password",GetVersion(),"","SA","");
			}
			catch (Exception e)
			{
			   Messaging.ShowException( "SA", e );
			   Utility.WriteDebug(remoteIP + " SA : " + e.Source + " ->" + e.Message);
			}
		}

		private string GetVersion()
		{
			// Plan B - we couldn't get SA so lets just do a quick check
			// to see if we can get a trusted context and some version info
			string trueversion="";
			if (remoteInstance=="")
				remoteInstance="MSSQLSERVER";
			
            string dataSource = "";
            if (Globals.localIP == remoteIP)
                dataSource = ".";
            else
                dataSource = remoteIP;

			if ((remoteInstance!="MSSQLSERVER")&&(remoteInstance!=""))
				dataSource = dataSource+"\\"+remoteInstance;
            SqlConnection conn2 = new SqlConnection("Data Source=" + dataSource + ";Initial Catalog=master;Integrated Security=SSPI;Connection Timeout=10;Application Name='Idera SQL discovery'");
			try 
			{
				conn2.Open();
				//We're in - might as well get the real version info
				try
				{
					SqlCommand myCommand = new SqlCommand("xp_msver 'ProductVersion'",conn2);
					SqlDataReader myReader;
					myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
					myReader.Read();
					trueversion = myReader.GetString(3);
					myReader.Close();
				}
				catch
				{}
			}
			catch (Exception  e)
			{
                Debug.Print(e.Message);
            }
			return trueversion;
		}
	}
}
