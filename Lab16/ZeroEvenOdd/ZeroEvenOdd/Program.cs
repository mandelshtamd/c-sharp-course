using System;
using System.Threading.Tasks;

namespace ZeroEvenOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var zeroEvenOddObj = new ZeroEvenOdd(n);

            var zeroTask = Task.Factory.StartNew(() => zeroEvenOddObj.Zero((i) => Console.Write($"{i}")));
            var evenTask = Task.Factory.StartNew(() => zeroEvenOddObj.Even((i) => Console.Write($"{i}")));
            var oddTask = Task.Factory.StartNew(() => zeroEvenOddObj.Odd((i) => Console.Write($"{i}")));

            zeroTask.Wait();
            evenTask.Wait();
            oddTask.Wait();
        }
    }
}
