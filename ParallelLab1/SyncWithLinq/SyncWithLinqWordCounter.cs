using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelLab1.SyncWithLinq
{
    class SyncWithLinqWordCounter : Counter, ICounter
    {
        public void CountAll()
        {
            stopwatch.Start();

            allWords = files.Select(f => CountInFile(f)).Aggregate((dict1, dict2) => MergeDictionaries(dict1, dict2));

            stopwatch.Stop();

            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}\n");
        }
        
    }
}
