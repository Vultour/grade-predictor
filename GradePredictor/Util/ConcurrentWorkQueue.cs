using System;
using System.Collections.Concurrent;
using System.Threading;


/// <copyright file="ConcurrentWorkQueue.cs">
///  Copyright (c) All Rights Reserved
///  <author>Martin Kukura</author>
/// </copyright>

namespace GradePredictor.Util
{
    /// <summary>
    /// <para>Provides static methods for queueing jobs that will be executed on a
    /// separate thread.</para>
    /// <para>This class differs from ThreadPool in the fact that it guarantees that
    /// jobs that were queued first will both execute and finish before any
    /// jobs that were queued later. This is accomplished by using a single
    /// worker thread to execute them.</para>
    /// You need to call the Initialize() method before calling any other methods
    /// of this class.
    /// </summary>
    public static class ConcurrentWorkQueue
    {
        private static bool _initialized = false;
        private static Thread _t;
        private volatile static AutoResetEvent _e;
        private volatile static ConcurrentQueue<Tuple<Action<object>, object>> _q;
        private static readonly Object _lock = new Object();


        /// <summary>
        /// Initializes the work queue.
        /// This function must be called before any calls to Enqueue().
        /// This call is thread safe.
        /// </summary>
        public static void Initialize()
        {
            lock (ConcurrentWorkQueue._lock)
            {
                if (ConcurrentWorkQueue._initialized) { return; }
                ConcurrentWorkQueue._q = new ConcurrentQueue<Tuple<Action<object>, object>>();
                ConcurrentWorkQueue._e = new AutoResetEvent(false);

                ConcurrentWorkQueue._t = new Thread(ConcurrentWorkQueue._work);
                ConcurrentWorkQueue._t.IsBackground = true;
                ConcurrentWorkQueue._t.Name = "ConcurrentWorkQueue";
                ConcurrentWorkQueue._t.Start();

                ConcurrentWorkQueue._initialized = true;
            }
        }

        /// <summary>
        /// Queues a job for execution on a separate thread.
        /// This call is thread safe.
        /// </summary>
        /// <param name="func">The function to be executed, accepting an object as a parameter</param>
        /// <param name="param">Instance of object that will be passed to the function</param>
        public static void Enqueue(Action<object> func, object param) {
            bool signal = (ConcurrentWorkQueue._q.Count < 1);
            ConcurrentWorkQueue._q.Enqueue(
                new Tuple<Action<object>, object>(
                    func,
                    param
                )
            );
            if (true) { ConcurrentWorkQueue._e.Set(); }
        }

        /// <summary>
        /// Queues a job for execution on a separate thread.
        /// This call is thread safe.
        /// </summary>
        /// <param name="func">The function to be executed</param>
        public static void Enqueue(Action func) { ConcurrentWorkQueue.Enqueue((object o) => func(), null); }

        private static void _work()
        {
            while (true)
            {
                if (ConcurrentWorkQueue._q.Count < 1) { ConcurrentWorkQueue._e.WaitOne(); }

                Tuple<Action<object>, object> func;
                if (ConcurrentWorkQueue._q.TryDequeue(out func))
                {
                    func.Item1(func.Item2);
                }
            }
        }
    }
}
