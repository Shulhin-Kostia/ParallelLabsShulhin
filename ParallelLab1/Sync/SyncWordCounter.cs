using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelLab1.Sync
{
    class SyncWordCounter : Counter, ICounter
    {
        
        public void CountAll()
        {
            stopwatch.Start();

            files.ForEach(f =>
            {
                allWords = MergeDictionaries(CountInFile(f), allWords);
            });

            stopwatch.Stop();

            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}\n");
        }
    }
}
