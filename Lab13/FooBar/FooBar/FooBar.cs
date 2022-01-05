using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FooBar
{
    public class FooBar
    {
        private readonly Semaphore foo = new Semaphore(1, 1);
        private readonly Semaphore bar = new Semaphore(0, 1);

        private int n;
        public FooBar(int n)
        {
            this.n = n;
        }

        public void Foo(Action printFoo)
        {

            for (int i = 0; i < n; i++)
            {

                foo.WaitOne();

                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();

                bar.Release();
            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {
                bar.WaitOne();

                // printBar() outputs "bar". Do not change or remove this line.
                printBar();

                foo.Release();
            }
        }
    }
}
