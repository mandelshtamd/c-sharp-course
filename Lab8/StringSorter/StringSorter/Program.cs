using System;
using System.Collections.Generic;
using System.Text;

namespace StringSorter
{
    class Program
    {
        /* sorting("eA2a1E") ➞ "aAeE12"
           sorting("Re4r") ➞ "erR4"
           sorting("6jnM31Q") ➞ "jMnQ136"
           sorting("846ZIbo") ➞ "bIoZ468"  */

        static string sorting(string input)
        {
            var map = new Dictionary<char, int>();
            for (var i = 'a'; i <= 'z'; i++)
            {
                map.Add(i, 0);
                map.Add(char.ToUpper(i), 0);
            }

            for (var i = '0'; i <= '9'; i++)
            {
                map.Add(i, 0);
            }

            foreach (var e in input)
            {
                map[e]++;
            }

            var sb = new StringBuilder();

            for (var i = 'a'; i <= 'z'; i++)
            {
                for (var j = 0; j < map[i]; j++)
                {
                    sb.Append(i);
                }

                var capital = Char.ToUpper(i);

                for (var j = 0; j < map[capital]; j++)
                {
                    sb.Append(capital);
                }
            }

            for (var i = '0'; i <= '9'; i++)
            {
                for (var j = 0; j < map[i]; j++)
                {
                    sb.Append(i);
                }
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"sorting(eA2a1E) -> {sorting("eA2a1E")}");
            Console.WriteLine($"sorting(Re4r) -> {sorting("Re4r")}");
            Console.WriteLine($"sorting(6jnM31Q) -> {sorting("6jnM31Q")}");
            Console.WriteLine($"sorting(846ZIbo) -> {sorting("846ZIbo")}");
        }
    }
}
