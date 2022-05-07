using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelLab2
{
    class WorkItem
    {
        public Func<int, int> function;

        public int argument;

        public FutureResult future = new();
    }
}
