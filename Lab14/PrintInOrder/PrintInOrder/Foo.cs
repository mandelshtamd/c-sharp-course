using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrintInOrder
{
    public class Foo
    {
        private readonly Semaphore firstSem = new Semaphore(1, 1);
        private readonly Semaphore secondSem = new Semaphore(0, 1);
        private readonly Semaphore thirdSem = new Semaphore(0, 1);

        public void first() 
        {
            firstSem.WaitOne();
            Console.Write("first");
            secondSem.Release();
        }

        public void second() 
        {
            secondSem.WaitOne();
            Console.Write("second");
            thirdSem.Release();
        }

        public void third() 
        {
            thirdSem.WaitOne();
            Console.Write("third");
            firstSem.Release();
        }
    }
}
