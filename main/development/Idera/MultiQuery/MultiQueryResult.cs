using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace Idera.SqlAdminToolset.MultiQuery
{
   public class MultiQueryResult
   {
      public string  server               = "";
      public string  database             = "";
      
      public int     nResultSets          = 0;
      public int     nRows                = 0;
      
      public bool    cancelled            = false;
      public int     executionTimeInTicks = 0;
      
      public int     nTotal     = 0;
      public int     nSucceeded = 0;
      public int     nFailed    = 0;
      
      public List<BatchResult> batchResults = new List<BatchResult>();
      
      public string  message            = "";
      
      public MultiQueryResult() {}
      
      public MultiQueryResult( string s, string d)
      {
         server = s;
         database = d;
      }
   }
   
   public class BatchResult
   {
      public bool    succeeded            = false;
      public bool    cancelled            = false;
      
      public DataSet dataSet              = null;
   }
}
