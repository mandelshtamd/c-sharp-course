using System;
using System.Collections.Generic;
using System.Text;

namespace MaxyMinny
{
    class MaxyMinnySolver
    {
        public static Tuple<long, long> Solve(long input)
        {
            var parsedInput = input.ToString().ToCharArray();

            //find max
            Array.Sort<char>(parsedInput, new Comparison<char>(
                  (i1, i2) => i2.CompareTo(i1)));
            var maxValue = (char[]) parsedInput.Clone();

            //find min
            Array.Sort(parsedInput);
            //find first non-zero value to prevent leading zeros
            var i = 0;
            while (parsedInput[i] == '0')
                i++;
            (parsedInput[0], parsedInput[i]) = (parsedInput[i], parsedInput[0]);

            return new Tuple<long, long>(long.Parse(maxValue), long.Parse(parsedInput));
        }
    }
}
