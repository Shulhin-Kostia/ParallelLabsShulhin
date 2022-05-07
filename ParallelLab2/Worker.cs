using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelLab2
{
    class Worker
    {
        private ConcurrentQueue<WorkItem> queue;
        public Worker(ref ConcurrentQueue<WorkItem> queue)
        {
            this.queue = queue; 
        }

        public void Run()
        {
            new Thread(() =>
            {
                WorkItem item;
                while (true)
                {
                    if (!queue.TryDequeue(out item)) continue;

                    if (item == null) return;

                    item.future.Result = item.function(item.argument);
                }
            }).Start();
        }
    }
}
