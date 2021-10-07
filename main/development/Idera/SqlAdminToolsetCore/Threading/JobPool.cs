using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections.ObjectModel;
using Idera.SqlAdminToolset.Core.Threading;
using System.ComponentModel;
using System.Data;


namespace Idera.SqlAdminToolset.Core
{
   /// <summary>
   /// Executes jobs asynchronously on specified servers.
   /// </summary>
   public class JobPool<T> : IDisposable
   {
      #region variables
      private ManualResetEvent _FlushHandle = new ManualResetEvent(false);
      private ManualResetEvent _StopHandle = new ManualResetEvent(false);
      private ManualResetEvent _CancelHandle = new ManualResetEvent(false);

      private Queue<WorkItem<T>> _WorkItems = new Queue<WorkItem<T>>();
      private List<WorkItem<T>> _WorkItemsList = new List<WorkItem<T>>();

      private int _MaxThreads = 0;
      private int _NotStartedCount = 0;
      private int _CompletedCount = 0;
      private int _InProgressCount = 0;
      
      private object countLock = new Object();

      private bool _JobsStarted = false;

      private Thread[] _ContainedThreads;
      private BackgroundWorker _BackgroundWorker;
      DoWorkEventArgs _DoWorkEventArgs;
      private bool _CancelRequested = false;
      #endregion

      #region .ctor
      /// <summary>
      /// Initializes a new instance of JobPool.
      /// </summary>
      public JobPool(int maxThreadCount)
      {
         if (maxThreadCount <= 0)
         {
            throw new ArgumentOutOfRangeException("maxThreadCount", "Maximum number of threads must be a positive number in order to start the thread pool.");
         }

         _BackgroundWorker = new BackgroundWorker();
         _BackgroundWorker.WorkerReportsProgress = true;
         _BackgroundWorker.WorkerSupportsCancellation = true;

         _MaxThreads = maxThreadCount;

         _BackgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
         _BackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
         _BackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
      }

      #endregion

      #region accessors
      /// <summary>
      /// Number of threads.
      /// </summary>
      public int MaxThreads
      {
         get
         {
            return _MaxThreads;
         }
      }

      /// <summary>
      /// Number of completed tasks.
      /// </summary>
      public int CompletedCount
      {
         get
         {
            return _CompletedCount;
         }
      }

      /// <summary>
      /// Number of tasks in progress.
      /// </summary>
      public int InProgressCount
      {
         get
         {
            return _InProgressCount;
         }
      }

      /// <summary>
      /// Number of tasks not started.
      /// </summary>
      public int NotStartedCount
      {
         get
         {
            return _NotStartedCount;
         }
      }

      /// <summary>
      /// List of Work items.
      /// </summary>
      public ReadOnlyCollection<WorkItem<T>> WorkItems
      {
         get { return _WorkItemsList.AsReadOnly(); }
      }
      #endregion

      #region Methods

      #region Public
      /// <summary>
      /// Starts the pool with the specified maximum number of threads.
      /// </summary>
      public void Start()
      {
         ExecuteThreads(null, null);
      }

      /// <summary>
      /// Starts the pool asynchronously with the specified maximum number of threads.
      /// </summary>
      public void StartAsync()
      {
         _CancelRequested = false;
         _BackgroundWorker.RunWorkerAsync();
      }

      /// <summary>
      /// Executes the requested threads.
      /// </summary>
      private void ExecuteThreads(BackgroundWorker worker, DoWorkEventArgs e)
      {
         try
         {
            if (worker != null && e != null)
            {
               _BackgroundWorker = worker;
               _DoWorkEventArgs = e;
               if (_BackgroundWorker.CancellationPending)
               {
                  _DoWorkEventArgs.Cancel = true;
                  return;
               }
            }

            if (_JobsStarted)
            {
               throw new InvalidOperationException("The Job Pool has already been started");
            }
            if (_WorkItems.Count == 0)
            {
               return;
               //throw new InvalidOperationException("No tasks have been loaded onto the thread pool.");
            }
            _ContainedThreads = new Thread[_MaxThreads];

            //start all threads
            for (int i = 0; i < _ContainedThreads.Length; i++)
            {
               _ContainedThreads[i] = new System.Threading.Thread(new ParameterizedThreadStart(Monitor));
               _ContainedThreads[i].Name = "PooledThread" + i.ToString();
               _ContainedThreads[i].Priority = ThreadPriority.BelowNormal;
               _ContainedThreads[i].Start(_StopHandle);
            }
            _JobsStarted = true;
            Flush();

            while (_StopHandle.WaitOne())
            {
               return;
            }
         }
         catch (Exception ex)
         {
            throw new ApplicationException("There was a problem starting the job pool", ex);
         }
      }

      private void Flush()
      {
         _FlushHandle.Set();
      }

      /// <summary>
      /// Cancels thread execution.
      /// </summary>
      public void Cancel()
      {
         try
         {
            WorkItem<T> _Item;
            lock (_WorkItems)
            {
               while ((_Item = Dequeue()) != null)
               {
                  try
                  {
                     _Item.Cancel();
                  }
                  catch { throw; }  //throw specialized exception
               }
            }
            _BackgroundWorker.CancelAsync();
         }
         catch (Exception ex)
         {
            throw new ApplicationException("There was a problem cancelling the unstarted jobs", ex);
         }
      }

      public void Cancel(bool includeStartedThreads)
      {
         if (!_CancelRequested)
         {
            _CancelRequested = true;
            Cancel();
            _CancelHandle.Set();
            new Thread(new ThreadStart(KillRunningThreads)).Start();
         }
      }

      private void KillRunningThreads()
      {
         foreach (Thread _Thread in _ContainedThreads)
         {
            if (_Thread.ThreadState == ThreadState.Running && !_Thread.Join(5000)) //give them 5 seconds to cleanup
            {
               _StopHandle.Set();
               _Thread.Abort();
            }
         }
      }

      /// <summary>
      /// Adds items to be processed by the thread pool.
      /// </summary>
      /// <param name="item"></param>
      public void Enqueue(ProcessItem<T> task, List<ServerInformation> servers, int commandTimeout)
      {
         Enqueue(task, servers, commandTimeout, new JobPoolOptions());
      }

      /// <summary>
      /// Adds items to be processed by the thread pool.
      /// </summary>
      /// <param name="item"></param>
      public void Enqueue(ProcessItem<T> task, List<ServerInformation> servers, int commandTimeout, JobPoolOptions options) 
      {
         try
         {
            options.CancelHandle = _CancelHandle;
            servers.ForEach(delegate(ServerInformation server)
            {
               WorkItem<T> _Item = new WorkItem<T>(task, server, commandTimeout, options);
               _NotStartedCount++;
               lock (_WorkItems)
               {
                  _WorkItems.Enqueue(_Item);
                  _WorkItemsList.Add(_Item);
               }
            });
         }
         catch (Exception ex)
         {
            throw new ApplicationException("There was a problem adding items to the internal queue.", ex);
         }
      }

      ///// <summary>
      ///// Adds a SQL statement be processed by the thread pool.
      ///// </summary>
      ///// <param name="item"></param>
      //public void EnqueueSql(List<ServerInformation> servers, int commandTimeout, string sql)
      //{
      //   //Enqueue(CommonTasks.ExecuteSql, servers, commandTimeout, sql);
      //}

      ///// <summary>
      ///// Adds a WMI query be processed by the thread pool.
      ///// </summary>
      ///// <param name="item"></param>
      //public void EnqueueWmi(List<ServerInformation> servers, int commandTimeout, string wmiQuery)
      //{
      //   //Enqueue(CommonTasks.ExecuteWmi, servers, commandTimeout, wmiQuery);
      //}
      #endregion

      #region Private
      /// <summary>
      /// Main function to process pending tasks.
      /// </summary>
      private void Monitor(object stopHandle)
      {
         _StopHandle = (ManualResetEvent)stopHandle;
         while (WaitHandle.WaitAny(new WaitHandle[] { _StopHandle, _FlushHandle }) != 0) { ProcessQueuedItem(); }
      }

      /// <summary>
      /// Processes each queued item by calling the next not-yet executed server task.
      /// </summary>
      private void ProcessQueuedItem()
      {
         WorkItem<T> _Item;

         while ((_Item = Dequeue()) != null)
         {
            try
            {
               _Item.ServerTaskComplete += new EventHandler<JobExecutionResultsEventArgs>(WorkItemTaskComplete);
               _NotStartedCount--;
               _InProgressCount++;
               _Item.ProcessTask();
            }
            catch (ThreadAbortException)
            {
               _StopHandle.Set();
            }
            catch (InvalidOperationException)
            {
               _StopHandle.Set();
            }
            catch (Exception ex)
            {
               throw new ApplicationException("There was a problem executing the requested task", ex);
            }
         }
      }

      /// <summary>
      /// Dequeues the next item in the queue and sets the waithandle as necessary.
      /// </summary>
      /// <returns></returns>
      private WorkItem<T> Dequeue()
      {
         lock (_WorkItems)
         {
            if (_WorkItems.Count > 0)
            {
               return _WorkItems.Dequeue();
            }
            else
            {
               _FlushHandle.Reset();
               return null;
            }
         }
      }
      #endregion

      #endregion

      #region Event Handler
      void WorkItemTaskComplete(object sender, JobExecutionResultsEventArgs e)
      {
         lock ( countLock )
         {
            _InProgressCount--;
            _CompletedCount++;
         }
         _FlushHandle.Set();

         if (_BackgroundWorker.IsBusy)
         {
            try
            {
               _BackgroundWorker.ReportProgress((int)_CompletedCount / (_NotStartedCount + _CompletedCount + _InProgressCount), e);
            }
            catch (Exception ex )
            {
               CoreGlobals.traceLog.ErrorFormat( "WorkItemTaskComplete - reportProgress exception {0}", ex.Message );
            }
         }

         lock (_WorkItems)
         {
            if (_WorkItems.Count <= 0 && _InProgressCount <= 0)
            {
               _StopHandle.Set();
            }
         }
      }

      #region BackgroundWorker
      void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         BackgroundWorker _Worker = sender as BackgroundWorker;
         ExecuteThreads(_Worker, e);
         
         // This is a hack to prevent a race condition on the last item in the queue
         // basically the progress event fails with an exception because the background worker
         // DoWork is done so backgroundworker thinks its job is done and gets unhappy 
         // about the reportprogress call - this sleep gives it time to get the progress started
         System.Threading.Thread.Sleep(500);
      }
      void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         EventHandler<JobExecutionEventArgs> _TaskCompleteHandler = TaskCompleteEventHandler;
         if (_TaskCompleteHandler != null)
         {
            JobExecutionEventArgs _Args = new JobExecutionEventArgs();
            _Args.SuccessCount = _WorkItemsList.FindAll(delegate(WorkItem<T> item) { return item.Status == TaskStatus.Success; }).Count;
            _Args.FailedCount = _WorkItemsList.FindAll(delegate(WorkItem<T> item) { return item.Status == TaskStatus.Failed; }).Count;
            _Args.CancelledCount = _WorkItemsList.FindAll(delegate(WorkItem<T> item) { return item.Status == TaskStatus.Cancelled; }).Count;

            _TaskCompleteHandler(this, _Args);
         }
      }
      void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
         EventHandler<JobExecutionResultsEventArgs> _Handler = ServerTaskCompleteEventHandler;
         if (_Handler != null)
         {
            _Handler(this, (JobExecutionResultsEventArgs)e.UserState);
         }
      }
      #endregion


      #endregion

      #region events
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

      private EventHandler<JobExecutionEventArgs> _TaskComplete;

      public EventHandler<JobExecutionEventArgs> TaskCompleteEventHandler
      {
         get { return _TaskComplete; }
         set { _TaskComplete = value; }
      }

      /// <summary>
      /// Raised when a task completes on a server.
      /// </summary>
      public event EventHandler<JobExecutionEventArgs> TaskComplete
      {
         add { _TaskComplete += value; }
         remove { _TaskComplete -= value; }
      }

      #endregion

      #region IDisposable Members

      /// <summary>
      /// Frees up resources.
      /// </summary>
      protected virtual void Dispose(bool disposing)
      {
         if (disposing)
         {
            _ServerTaskComplete = null;
            _TaskComplete = null;
            _StopHandle.Set();
            foreach (Thread thread in _ContainedThreads)
            {
               thread.Abort();
            }
            _FlushHandle.Close();
            _StopHandle.Close();
         }
      }

      /// <summary>
      /// Frees up resources.
      /// </summary>
      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(true);
      }

      #endregion
   }
}
