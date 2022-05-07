using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelLab2
{
    class CustomExecutor
    {
        private int maxWorkers;
        private ConcurrentQueue<WorkItem> queue = new ConcurrentQueue<WorkItem>();

        public CustomExecutor(int maxWorkers)
        {
            this.maxWorkers = maxWorkers;
            Run();
        }

        public FutureResult Execute(Func<int, int> function, int arg)
        {
            WorkItem item = new WorkItem { function = function, argument = arg };

            while (queue.Count() >= maxWorkers)
                continue;

            queue.Enqueue(item);

            return item.future;
        }

        public List<FutureResult> Map(Func<int, int> function, int[] args)
        {
            List<FutureResult> futures = new List<FutureResult>(args.Length);

            foreach(int arg in args)
            {
                while (queue.Count() >= maxWorkers)
                    continue;
                WorkItem newWorkItem = new WorkItem { function = function, argument = arg };
                queue.Enqueue(newWorkItem);
                futures.Add(newWorkItem.future);
            }

            return futures;
        }
        
        public void Run()
        {
            for(int workers = 0; workers < maxWorkers; workers++)
            {
                new Worker(ref queue).Run();
            }
        }

        public void ShutDown()
        {
            if (queue.IsEmpty)
            {
                for(int i = 0; i < maxWorkers; i++)
                    queue.Enqueue(null);
            }
        }
    }
}
