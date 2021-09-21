using System;

namespace Simplifier
{
    internal class Simplifier
    {
        public static string Simplify(string arg)
        {
            var numerator = int.Parse(arg.Substring(0, arg.IndexOf('/')));
            var denominator = int.Parse(arg.Substring(arg.IndexOf('/') + 1, arg.Length - arg.IndexOf('/') - 1));
            var gcd = Gcd(numerator, denominator);
            return (denominator / gcd) == 1 ? (numerator / gcd).ToString() : numerator / gcd + "/" + denominator / gcd;
        }

        public static int Gcd(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }
            return a + b;
        }
    }


    class Program
    {
        public static void Main(string[] args)
        {
            var expr = Console.ReadLine();
            var ans = Simplifier.Simplify(expr);
            Console.WriteLine(ans);
        }
    }
}
