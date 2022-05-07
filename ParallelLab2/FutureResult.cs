using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelLab2
{
    class FutureResult
    {
        public bool hasResult;
        private int result;

        public int Result {
            get
            {
                while (!hasResult)
                    continue;
                return result;
            }
            set
            {
                result = value;
                hasResult = true;
            }
        }
    }
}
