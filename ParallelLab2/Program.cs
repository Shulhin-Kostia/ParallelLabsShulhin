using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelLab2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var exec = new CustomExecutor(2);
            
            var futures = exec.Map((x) => { Thread.Sleep(2000); return x * 2; }, new int[] { 1, 2, 3, 4 });

            foreach(var future in futures)
            {
                Console.WriteLine($"{future.Result} - {DateTime.Now.TimeOfDay.ToString().Split(".").First()} ");
            }

            exec.ShutDown();
        }
    }
}
