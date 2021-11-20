using System;
using System.Text;

namespace Task4
{
    class Program
    {
        public static string Rational(int numerator, int denominator)
        {
            var sb = new StringBuilder();

            float x = (float)numerator / denominator;
            int dev = numerator / denominator;

            if (numerator == denominator)
                sb.Append(dev.ToString());
            else if (denominator % 2 == 0 || denominator % 5 == 0)
                sb.Append(x.ToString());
            else
                sb.Append(dev.ToString() + "," + GetPeriod(numerator, denominator));

            return sb.ToString();
        }

        static string GetPeriod(int numerator, int denominator)
        {
            var digits = new int[denominator];
            int k = 0, n = numerator;
            do
            {
                n *= 10;
                digits[k++] = n / denominator;
                n %= denominator;
            }
            while (n != numerator);

            var period = new int[k];
            for (n = 0; n < k; ++n)
            {
                period[n] = digits[n];
            }

            var sb = new StringBuilder();

            if (period.Length > 0)
            {
                sb.Append("(");
                for (var i = 0; i <= period.Length - 1; i++)
                {
                    sb.Append(period[i]);
                }
                sb.Append(")");
            }

            return sb.ToString();
        }


        static void Main(string[] args)
        {
            var numerator = int.Parse(Console.ReadLine());
            var denominator = int.Parse(Console.ReadLine());

            var ans = Rational(numerator, denominator);
            Console.WriteLine(ans);
        }
    }
}
