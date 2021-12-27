using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressFactors
{
    class Solution
    {
        public static string ExpressFactors(int input)
        {
            var currentValue = input;
            var sqrtVal = (Int32) Math.Round(Math.Sqrt(input));
            var factorization = new Dictionary<int, int>();

            var factor = 2;
            while (currentValue > 1)
            {
                while (currentValue % factor == 0)
                {
                    currentValue /= factor;
                    factorization.TryGetValue(factor, out var currentCount);
                    factorization[factor] = currentCount + 1;
                }

                factor++;
            }

            var ans = new StringBuilder();
            // тут очень неоптимально в плане производительности выбрано решение
            // у словаря можно обратиться напрямую ко всей коллекции ключей, у нее есть перечислитель и ее можно отсортировать как хочется
            for (var i = 2; i <= input; i++)
            {
                factorization.TryGetValue(i, out var currentCount);

                if (currentCount == 0) continue;
                if (currentCount == 1) ans.Append($" x {i}");
                if (currentCount > 1) ans.Append($" x {i}^{factorization[i]}");
            }

            return ans.ToString().Substring(3);
        }
    }
}
