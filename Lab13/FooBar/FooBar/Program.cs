using System;
using System.Threading;
using System.Threading.Tasks;

namespace FooBar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number of foobars: ");
            var n = int.Parse(Console.ReadLine());

            var f1 = new FooBar(n);

            var fooTask = Task.Factory.StartNew(() => f1.Foo(FooPrinter));
            var barTask = Task.Factory.StartNew(() => f1.Bar(BarPrinter));

            fooTask.Wait();
            barTask.Wait();
        }

        static void FooPrinter()
        {
            Console.Write("foo");
        }
        static void BarPrinter()
        {
            Console.Write("bar");
        }
    }
}
