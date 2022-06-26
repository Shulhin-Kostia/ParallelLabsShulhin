using System.Collections.Generic;

namespace ParallelLab3.CounterTool
{
    interface ICounter
    {
        public Dictionary<string, int> CountAll();
    }
}
