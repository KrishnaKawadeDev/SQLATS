using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.ConnectionCheck
{
   class ProductConstants
   {
      // Product Name
      public static string shortProductName = "ConnectionCheck";
      public static string productName = "Connection Check";
      public static string productDescription = "Diagnose why you can't connect to your SQL Server";

      // CommandLine Support
      public static bool supportsCommandLine = false;

      public static string usage = "Syntax:\r\n" +
                                   "    ConnectionCheck /arg1:value /arg2:value\r\n" +
                                   "Parameters:\r\n" +
                                   "    /arg1:value" +
                                   "    /arg2:value";
      // Resource Strings
      
      //-----------------
      // Recommendations
      //-----------------

      // 18456 – Login fails
      public static string Error_18456 = "The attempt to connect to the SQL Server failed with error 18456: Login Failed\r\n\r\n " +
                                         "To resolve this error:\r\n" +
                                         "(1) If you are using Windows authentication:\r\n"+
                                         "    (a) Make sure a server login has been created for the current user.\r\n" +
                                         "(2) If you are using SQL authentication:\r\n" +
                                         "    (a) Make sure the SQL Server login exists\r\n" +
                                         "    (b) Check the spelling of the SQL Server login\r\n" +
                                         "    (c) Check that you are using the correct password\r\n" +
                                         "(3) Check if the Server login has been marked as Deny access to connect to the database engine.";
 
      // 18470 – Login fails – account disabled
      public static string Error_18470 = "The attempt to connect to the SQL Server failed with error 18470 - Login failed, account disabled. " +
                                         "This means that the user and password are correct but the login has been marked as disabled.\r\n\r\n" +
                                         "To resolve this error:\r\n" +
                                         "* You must re-enable the account to allow it to connect. ";
  
  
      //	18486 – Login fails – account locked out
      public static string Error_18486 = "The attempt to connect to the SQL Server failed with error 18486 - Login failed, account locked out. " +
                                         "This means that the user and password are correct but the account has been locked out of SQL Server" +
                                         "for too many attempts to login with a bad password.\r\n\r\n" +
                                         "To resolve this error:\r\n" +
                                         "* Unlock the account within SQL Server.\r\n" +
                                         "* This can be done with ALTER LOGIN using the UNLOCK option.";
                                         
      // 4060 - Cannot open database
      public static string Error_4060 = "The attempt to connect to the SQL Server failed with error 4060 - Cannot open database.\r\n\r\n" + 
                                         "To resolve this error:\r\n" +
                                         "(1) Check the spelling of the database name.\r\n" +
                                         "(2) Check that the user has a database level login defined.\r\n" +
                                         "(3) Check that the user is not marked as Deny access at the database level.";

      // 4064 - Cant open default database
      public static string Error_4064 = "The attempt to connect to the SQL Server failed with error 4064 - Cannot open default database\r\n\r\n" + 
                                         "To resolve this error:\r\n" +
                                         "(1) Specify a different database in which the user has permission to connect.\r\n" +
                                         "(2) Check that the user has a database level login defined.\r\n" +
                                         "(3) Check that the user is not marked as Deny access at the database level.";

      // Generic connection problem
      public static string Error_ConnectionFailedNoNetworkTest = 
                                         "The attempt to connect to the SQL Server failed\r\n\r\n" +      
                                         "To resolve this error:\r\n" +
                                         "(1) Check the spelling of the SQL Server name.\r\n" + 
                                         "(2) Check that the SQL Server has been setup to allow remote connections.\r\n" + 
                                         "(3) Check the SQL Server Database Engine port.\r\n" + 
                                         "(4) Make sure the SQL Server port is not blocked by a firewall.\r\n" + 
                                         "(5) Check that the client and server are both configured to use the same network protocol.\r\n" +
                                         "(6) Use the Network test feature to check the network connectivity to the host machine.";
                                         
      public static string ConnectionFailureWithGoodNetwork = 
                                         "The attempt to connect to the SQL Server failed. Network testing shows no problems " +
                                         "with your network configuration.\r\n\r\n" +      
                                         "To resolve this error:\r\n" +
                                         "(1) Check that the SQL Server has been setup to allow remote connections.\r\n" + 
                                         "(2) Check the SQL Server Database Engine port.\r\n" + 
                                         "(3) Make sure the SQL Server port is not blocked by a firewall.\r\n" + 
                                         "(4) Check that the client and server are both configured to use the same network protocol.";

      public static string Error_LocalProblem  = 
                                         "The network configuration for this machine is not set up correctly which is preventing it from correctly connecting to other machines on the network. " +
                                         "You must resolve this for connections to SQL Server to work. In the test results " +
                                         "section, a summary of your network configuration is available for review.\r\n\r\n" +      
                                         "To resolve this error:\r\n" +
                                         "(1) Review the configuration of your network interfaces and that the expected interfaces are up and running.\r\n" + 
                                         "(2) Check that the DNS Servers are correctly specified.\r\n" +
                                         "(3) Check that the default gateways are correctly specified.\r\n"; 
      
      public static string Error_DnsFailure    = 
                                         "An error occurred trying to retrieve the IP address of the host computer from DNS. This indicates " +
                                         "a problem with the network configuration in this computer and not a SQL Server problem. In the test results " +
                                         "section, a summary of your network configuration is available for review.\r\n\r\n" +      
                                         "To resolve this error:\r\n" +
                                         "(1) Check the spelling of the SQL Server name.\r\n" + 
                                         "(2) Review the configuration of your network interfaces and that the expected interfaces are up and running.\r\n" + 
                                         "(3) Check that the DNS Servers are  correctly specified.\r\n"; 
      
      public static string Error_PingFailure   = 
                                         "An error occurred trying to ping the host computer. This indicates that there is either " +
                                         "a problem with the network configuration in this computer or it could mean that your firewall is configured to block ping. " +
                                         "If it is just that ping is being blocked by your firewall, this may not affect SQL Server connectivity. \r\n\r\n " +
                                         "To resolve this error:\r\n" +
                                         "(1) Review the configuration of your network interfaces and that the expected interfaces are up and running.\r\n" + 
                                         "(2) Check your firewall settings to see if ping is being blocked.\r\n"; 
      
      public static string Error_ServiceIsUp =
                                         "The SQL Server service to which you are trying to connect is running and your network configuration appears to be OK. This indicates that there is a problem with your SQL Server configuration preventing the connection.\r\n\r\n" +
                                         "To resolve this error:\r\n" +
                                         "(1) Check that the SQL Server has been setup to allow remote connections.\r\n" + 
                                         "(2) Check the SQL Server Database Engine port.\r\n" + 
                                         "(3) Make sure the SQL Server port is not blocked by a firewall.\r\n" + 
                                         "(4) Check that the client and server are both configured to use the same network protocol.";
      
      public static string Error_ServiceIsDown = "The SQL Server service to which you are trying to connect is not running.\r\n\r\n " +
                                                 "To resolve this error:\r\n" +
                                                 "(1) Start the SQL Server service";
                                         
      public static string Error_ServiceError =
                                         "Your network connection is good but you are unable to check the status of the SQL Server service using this tool.\r\n\r\n" +
                                         "To resolve this error:\r\n" +
                                         "(1) Check that you have correctly specified the SQL Server.\r\n" + 
                                         "(2) Check that the SQL Server service is running.\r\n" + 
                                         "(3) Check the SQL Server Database Engine port.\r\n" + 
                                         "(4) Make sure the SQL Server port is not blocked by a firewall.\r\n" + 
                                         "(5) Check that the client and server are both configured to use the same network protocol.";

       public static string Error_Impersonate =
                                          "The network credentials that you provided are invalid.\r\n" +
                                          "To resolve this error:\r\n" +
                                          "(1) Verify that the values that you entered are correct.\r\n" +
                                          "(2) Verify that the network user is valid.";
      public static string TestCancelled = "The test was cancelled before it could be completed.";
      
      public static string AllIsWell = "Network tests passed successfully. No further action is required.";
   }
}
