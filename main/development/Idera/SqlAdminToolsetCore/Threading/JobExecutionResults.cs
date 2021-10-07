using System;
namespace Idera.SqlAdminToolset.Core
{
    /// <summary>
    /// Event arguments related to the completion of a server's task.
    /// </summary>
    public class JobExecutionResultsEventArgs : EventArgs
    {
        private readonly ServerInformation _Server;
        private TaskStatus _Status;
        private object _Resultset;
        //private string _ErrorMessage;
        private double _Duration;
        private readonly string _TaskName;
        private Exception _Exception;

        public JobExecutionResultsEventArgs(ServerInformation server, string taskName)
        {
            _Server = server;
            _TaskName = taskName;
        }

        /// <summary>
        /// Name of the method executed by the thread.
        /// </summary>
        public string TaskName
        {
            get { return _TaskName; }
        }

        /// <summary>
        /// Server that the job ran against.
        /// </summary>
        public ServerInformation Server
        {
            get { return _Server; }
        }

        /// <summary>
        /// Task status.
        /// </summary>
        public TaskStatus Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        
        /// <summary>
        /// DataTable array containing reults
        /// </summary>
        public object Resultset
        {
            get { return _Resultset; }
            set { _Resultset = value; }
        }

        /// <summary>
        /// Error message.  Null if no error message was generated.
        /// </summary>
        public string ErrorMessage
        {
            get 
            {
               if (_Exception == null)
               {
                  return null;
               }
               else
               {
                  return  Helpers.GetCombinedExceptionText(_Exception);
               }
            }
        }

        /// <summary>
        /// Exception generated by task.  Null if no error message generated.
        /// </summary>
        public Exception Exception
        {
           get { return _Exception; }
           set { _Exception = value; }
        }

        /// <summary>
        /// Number of seconds that it took the task to complete.
        /// </summary>
        public double Duration
        {
            get { return _Duration; }
            set { _Duration = value; }
        }
    }

    /// <summary>
    /// Status of a task on a specific server.
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// Task is queued and waiting to process.
        /// </summary>
        WaitingToStart,
        /// <summary>
        /// Task started processing.
        /// </summary>
        Started,
        /// <summary>
        /// Task processed successfully.
        /// </summary>
        Success,
        /// <summary>
        /// Task failed processing.
        /// </summary>
        Failed,
        /// <summary>
        /// Task was cancelled before it started.
        /// </summary>
        Cancelled
    }

    /// <summary>
    /// Event arguments related to the completion of all requested tasks.
    /// </summary>
    public class JobExecutionEventArgs : EventArgs
    {
        private int _SuccessCount;
        private int _FailedCount;
        private int _CancelledCount;

        /// <summary>
        /// Number of successfully completed tasks.
        /// </summary>
        public int SuccessCount
        {
            get { return _SuccessCount; }
            set { _SuccessCount = value; }
        }

        /// <summary>
        /// Number of failed tasks.
        /// </summary>
        public int FailedCount
        {
            get { return _FailedCount; }
            set { _FailedCount = value; }
        }

        /// <summary>
        /// Number of cancelled tasks.
        /// </summary>
        public int CancelledCount
        {
            get { return _CancelledCount; }
            set { _CancelledCount = value; }
        }
    }
}