using ParallelLab1.AsyncWithLinq;
using ParallelLab1.Sync;
using ParallelLab1.SyncWithLinq;
using System;

namespace ParallelLab1
{
    class Program
    {
        static void Main(string[] args)
        {

            ICounter syncCounter = new SyncWordCounter();
            Console.WriteLine("Sync");
            syncCounter.CountAll();
            Console.WriteLine($"Result:\n{syncCounter.ShowResult()}\n");
            Counter.Reset();

            ICounter syncWithLinqCounter = new SyncWithLinqWordCounter();
            Console.WriteLine("Sync With Linq");
            syncWithLinqCounter.CountAll();
            Console.WriteLine($"Result:\n{syncWithLinqCounter.ShowResult()}\n");
            Counter.Reset();

            ICounter asyncWithLinqCounter = new AsyncWithLinqWordCounter();
            Console.WriteLine("Async With Linq");
            asyncWithLinqCounter.CountAll();
            Console.WriteLine($"Result:\n{asyncWithLinqCounter.ShowResult()}\n");
            Counter.Reset();
        }
    }
}
