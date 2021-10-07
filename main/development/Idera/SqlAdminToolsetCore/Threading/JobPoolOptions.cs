using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Idera.SqlAdminToolset.Core
{
   /// <summary>
   /// Options to be used by task in the job pool.
   /// </summary>
   public class JobPoolOptions
   {
      private ManualResetEvent _CancelHandle = null;

      /// <summary>
      /// Stop handle.
      /// </summary>
      internal ManualResetEvent CancelHandle
      {
         get { return _CancelHandle; }
         set { _CancelHandle = value; }
      }

      /// <summary>
      /// True if a cancel request was received, otherwise false.
      /// </summary>
      public bool CancelRequested
      {
         get
         {
            if (_CancelHandle != null)
            {
               return _CancelHandle.WaitOne(0, true);
            }
            return false;
         }
      }
   }
}
