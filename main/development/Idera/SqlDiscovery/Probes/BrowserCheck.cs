using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Data ;
using System.Data.Sql ;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SqlDiscovery
{
	/// <summary>
    /// BrowserCheck - this is the browser service probe - uses NetServerEnum.cs 
	/// </summary>
	public class BrowserCheck
	{
		public BrowserCheck()
		{
		}

		public void Scan()
		{
		   try
		   {
            SqlDataSourceEnumerator enumerator = SqlDataSourceEnumerator.Instance;
            using (DataTable tbl = enumerator.GetDataSources())
            {
               foreach (DataRow row in tbl.Rows)
               {
                  string server    = row["ServerName"].ToString();
                  string instance  = row["InstanceName"].ToString();
      			   string ipAddress = Helpers.GetIP4AddressString( server );

					   Utility.PushResults(
                            /* txtServerIP        */   ipAddress,
                            /* txtServerName      */   server,
                            /* txtInstanceName    */   instance,
                            /* txtIsClustered     */   "",
                            /* txtVersion         */   "",
                            /* txtTCPPort         */   "",
                            /* txtProtocols       */   "No details for Browser probe",
                            /* txtTrueVersion,    */   "",
                            /* txtServiceAccount  */   "",
                            /* txtDetectionMethod */   "BRO",
                            /* txtSSNetlibVersion */   "");
                }
             }
          }
			 catch (Exception e)
			 {	
			    Utility.WriteDebug( "BrowserCheck : " + e.Source + " ->" + e.Message);
		 	 }
		}
	}
}
