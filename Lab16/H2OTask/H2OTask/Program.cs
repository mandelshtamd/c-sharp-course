using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H2OTask
{
    class Program
    {
        static void Main(string[] args)
        {
            H2O h2o = new H2O();
            var tasks = new List<Task>();
            for (int i = 0; i < 3; i++)
            {
                var job = Task.Run(() => h2o.Oxygen(() => Console.Write("O")));
                tasks.Add(job);
            }
            for (int i = 0; i < 6; i++)
            {
                var job = Task.Run(() => h2o.Hydrogen(() => Console.Write("H")));
                tasks.Add(job);
            }

            foreach(var task in tasks)
            {
                task.Wait();
            }
        }
    }
}
