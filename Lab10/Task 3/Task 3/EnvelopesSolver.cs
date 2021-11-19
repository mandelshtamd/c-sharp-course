using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3
{
    class EnvelopesSolver
    {
	// публичный метод должен начинаться с большой буквы
        public static int solve(Envelope[] envelopes)
        {
            Array.Sort(envelopes, new EnvelopeComparer());

            int[] dp = new int[envelopes.Length];
            var max = 0;

            for (int i = 0; i < envelopes.Length; i++)
            {
                int tmp = 1;
                for (int j = 0; j < i; j++)
                {
                    if (envelopes[j].Width < envelopes[i].Width && envelopes[j].Height < envelopes[i].Height)
                    {
                        tmp++;
                    }
                }
                max = Math.Max(max, tmp);
                dp[i] = max;
            }
            return dp[envelopes.Length - 1];
        }
    }
}
