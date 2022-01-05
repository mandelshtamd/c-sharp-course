using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroEvenOdd
{
    public class ZeroEvenOdd
    {
        private int n;

        // можно сразу инициализировать и определить как private readonly
        System.Threading.Semaphore zeroSem;
        System.Threading.Semaphore evenSem;
        System.Threading.Semaphore oddSem;

        public ZeroEvenOdd(int n)
        {
            this.n = n;

            zeroSem = new System.Threading.Semaphore(1, 1);
            evenSem = new System.Threading.Semaphore(0, 1);
            oddSem = new System.Threading.Semaphore(0, 1);
        }

        public void Zero(Action<int> printNumber)
        {
            for (int i = 1; i <= this.n; i++)
            {
                zeroSem.WaitOne();
                printNumber(0);

                if (i % 2 == 0)
                    evenSem.Release();
                else
                    oddSem.Release();
            }
        }

        public void Even(Action<int> printNumber)
        {
            for (int i = 2; i <= this.n; i += 2)
            {
                evenSem.WaitOne();
                printNumber(i);
                zeroSem.Release();
            }
        }

        public void Odd(Action<int> printNumber)
        {
            for (int i = 1; i <= this.n; i += 2)
            {
                oddSem.WaitOne();
                printNumber(i);
                zeroSem.Release();
            }
        }
    }
}
