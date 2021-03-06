using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Data;

namespace Idera.SqlAdminToolset.Core
{
    public class WorkItem<T>
    {
        #region private variables
        private int _CommandTimeout = 0;
        private ProcessItem<T> _ProcessDelegate;
        private ServerInformation _Server;
        private TaskStatus _Status = TaskStatus.WaitingToStart;
        private string _Task;
        private T _Resultset;
        private JobPoolOptions _Options;
        private Exception _Exception;
        #endregion

        #region .ctor
        /// <summary>
        /// Initializes a new instance of WorkItem.
        /// </summary>
        /// <param name="processDelegate"></param>
        public WorkItem(ProcessItem<T> processDelegate, ServerInformation server, int commandTimeout, JobPoolOptions options)
        {
            _ProcessDelegate = processDelegate;
            _Server = server;
            _CommandTimeout = commandTimeout;
            _Options = options;
        }
        #endregion

        #region Accessors
        /// <summary>
        /// Status of the job executiion.
        /// </summary>
        public TaskStatus Status
        {
            get
            {
                return _Status;
            }
        }
        
        public JobPoolOptions Options
        {
           get { return _Options; }
        }

        /// <summary>
        /// Information about the server that the task will be run against.
        /// </summary>
        public ServerInformation Server
        {
            get { return _Server; }
        }

        /// <summary>
        /// Name of the task that is executed as part of the workitem.
        /// </summary>
        public string Task
        {
            get { return _Task; }
        }

        /// <summary>
        /// DataTable array containing reults
        /// </summary>
        public T Resultset
        {
            get { return _Resultset; }
        }

        /// <summary>
        /// Exception generated by task.  Null if no exception generated.
        /// </summary>
        public Exception Exception
        {
           get { return _Exception; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Processes a task on the specified server.
        /// </summary>
        public void ProcessTask()
        {
            Stopwatch _Stopwatch = Stopwatch.StartNew();
            _Stopwatch.Start();
            _Status = TaskStatus.Started;
            _Task = _ProcessDelegate.Method.Name;
            JobExecutionResultsEventArgs _EventArgs = new JobExecutionResultsEventArgs(_Server, _Task);
            try
            {
                _EventArgs.Resultset = _Resultset = _ProcessDelegate(_Server, _CommandTimeout, _Options);
                _EventArgs.Status = _Status = TaskStatus.Success;
            }
            catch (Exception exc)
            {
                _Exception = _EventArgs.Exception = exc;
                _EventArgs.Status = _Status = TaskStatus.Failed;
            }
            finally
            {
                _Stopwatch.Stop();
            }

            _EventArgs.Duration = _Stopwatch.Elapsed.TotalSeconds;

            EventHandler<JobExecutionResultsEventArgs> _Handler = ServerTaskCompleteEventHandler;
            if (_Handler != null)
            {
                _Handler(this, _EventArgs);
            }
        }

        /// <summary>
        /// Cancels execution of a task before it starts.
        /// </summary>
        public void Cancel()
        {
            JobExecutionResultsEventArgs _EventArgs = new JobExecutionResultsEventArgs(_Server, _ProcessDelegate.Method.Name);
            _EventArgs.Status = _Status = TaskStatus.Cancelled;
            _EventArgs.Duration = 0;

            EventHandler<JobExecutionResultsEventArgs> _Handler = ServerTaskCompleteEventHandler;
            if (_Handler != null)
            {
                _Handler(this, _EventArgs);
            }
        }
        #endregion

        #region Events
        private EventHandler<JobExecutionResultsEventArgs> _ServerTaskComplete;

        public EventHandler<JobExecutionResultsEventArgs> ServerTaskCompleteEventHandler
        {
            get { return _ServerTaskComplete; }
            set { _ServerTaskComplete = value; }
        }

        /// <summary>
        /// Raised when a task completes on a server.
        /// </summary>
        public event EventHandler<JobExecutionResultsEventArgs> ServerTaskComplete
        {
            add { _ServerTaskComplete += value; }
            remove { _ServerTaskComplete -= value; }
        }
        #endregion
    }

    #region Delegate
    public delegate T ProcessItem<T>(ServerInformation Server, int commandTimeout, JobPoolOptions options);
    #endregion
}
