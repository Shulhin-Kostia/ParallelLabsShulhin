using System.Collections.Generic;
using System.Linq;

namespace ParallelLab3.CounterTool
{
    class AsyncWithLinqWordCounter : Counter, ICounter
    {
        public AsyncWithLinqWordCounter(string dataPath) : base(dataPath)
        {
        }

        public Dictionary<string, int> CountAll()
        {
            return files.AsParallel().Select(f => CountInFile(f)).Aggregate((dict1, dict2) => MergeDictionaries(dict1, dict2));
        }
    }
}
