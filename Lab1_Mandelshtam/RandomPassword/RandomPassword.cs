using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RandomPassword
{
    public class RandomPassword
    {
        public static string GetRandomPassword()
        {
            var randomizer = new Random();
            var passwordSize = randomizer.Next(6, 20);
            var capitalLettersCount = randomizer.Next(2, passwordSize - 1);
            var freeCount = passwordSize - capitalLettersCount - 1;
            var numbersCount = freeCount <= 5 ? randomizer.Next(0, freeCount) : randomizer.Next(0, 5);
            var lowerLettersCount = passwordSize - capitalLettersCount - numbersCount - 1;

            var sb = new StringBuilder();
            sb.Append("_");

            for (var i = 0; i < capitalLettersCount; i++)
            {
                sb.Append((char)('A' + randomizer.Next(0, 26)));
            }

            for (var i = 0; i < numbersCount; i++)
            {
                sb.Append(randomizer.Next(0, 9));
            }

            for (var i = 0; i < lowerLettersCount; i++)
            {
                sb.Append((char)('a' + randomizer.Next(0, 26)));
            }

            var password = new string(sb.ToString().ToCharArray().OrderBy(item => randomizer.Next()).ToArray());
            while (Regex.IsMatch(password, "(.*)\\d{2}(.*)"))
            {
                password = new string(password.ToCharArray().OrderBy(item => randomizer.Next()).ToArray());
            }

            return password;
        }
    }
}
