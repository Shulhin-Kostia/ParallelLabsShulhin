using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelLab1.AsyncWithLinq
{
    class AsyncWithLinqWordCounter : Counter, ICounter
    {
        public void CountAll()
        {
            stopwatch.Start();

            allWords = files.AsParallel().Select(f => CountInFile(f)).Aggregate((dict1, dict2) => MergeDictionaries(dict1, dict2));

            stopwatch.Stop();

            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}\n");
        }
    }
}
