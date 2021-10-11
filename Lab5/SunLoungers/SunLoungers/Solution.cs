using System;
using System.Collections.Generic;
using System.Text;

namespace SunLoungers
{
    public class Solution
    {
        public static int SunLoungers(string s)
        {
            var input = s.ToCharArray();
            var count = 0;
            if (input.Length == 1) return input[0] == '0' ? 1 : 0;
            if (input.Length == 1) return input[0] == '0' && input[1] == '0' ? 1 : 0;

            for (int i = 0; i < input.Length; i++)
            {
                // case we are on the left side;
                if (input[i] == '0' && i == 0 && input[i + 1] == '0')
                {
                    input[i] = '1';
                    count++;
                    continue;
                }

                // case we are on the right side;
                if (input[i] == '0' && i == input.Length - 1 && input[i - 1] == '0')
                {
                    input[i] = '1';
                    count++;
                    continue;
                }

                // in the middle;
                if (input[i] == '0' && input[i - 1] == '0' && input[i + 1] == '0')
                {
                    input[i - 1] = '1';
                    count++;
                }
            }
            return count;
        }
    }
}
