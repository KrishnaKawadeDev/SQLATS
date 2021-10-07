using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.SqlDiscovery
{
   public class ProbeData
   {
      public enum DetectionMethod
      {
         UDP = 0,
         TCP = 1,
         WMI = 2,
         SCM = 3,
         REG = 4,
         SA  = 5,
         AD  = 6,
         BRO = 7
      }
      
      public string   ipAddress       = "";
      public string   serverName      = "";
      public string   instanceName    =  "";
      public string   isClustered     = "";
      public string   baseVersion     = "";
      public string   trueVersion     = "";
      public string   SSNetlibVersion = "";
      public string   tcpipPort       = "";
      public string   serviceAccount  = "";
      
      public List<ProbeResult> probeResults = new List<ProbeResult>();
      
      public string GetProbes()
      {
         string probes = "";
         if ( probeResults.Count != 0 )
         {
            probes = probeResults[0].detectionMethod.ToString();
            
            for (int i=1;i<probeResults.Count;i++)
            {
               probes = ", " + probeResults[i].detectionMethod.ToString();
            }
         }
         return probes;
      }
   }
      
   public class ProbeResult
   {   
      public ProbeResult()
      {
      } 

      public
         ProbeResult(
            ProbeData.DetectionMethod _detectionMethod,
            string                    _ipAddress,
            string                    _serverName,
            string                    _instanceName,
            string                    _isClustered,
            string                    _baseVersion,
            string                    _trueVersion,
            string                    _SSNetlibVersion,
            string                    _tcpipPort,
            string                    _serviceAccount
         )
      {
         detectionMethod = _detectionMethod;
         ipAddress       = _ipAddress;
         serverName      = _serverName;
         instanceName    = _instanceName;
         isClustered     = _isClustered;
         baseVersion     = _baseVersion;
         trueVersion     = _trueVersion;
         SSNetlibVersion = _SSNetlibVersion;
         tcpipPort       = _tcpipPort;
         serviceAccount  = _serviceAccount;
      }
      
      public ProbeData.DetectionMethod  detectionMethod;
      public string                     ipAddress       = "";
      public string                     serverName      = "";
      public string                     instanceName    = "";
      public string                     isClustered     = "";
      public string                     baseVersion     = "";
      public string                     trueVersion     = "";
      public string                     SSNetlibVersion = "";
      public string                     tcpipPort       = "";
      public string                     serviceAccount  = "";
   }
}
