using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var envelopes = new Envelope[] { new Envelope(5, 4), 
                                            new Envelope(6, 4), 
                                            new Envelope(6, 7),
                                            new Envelope(2, 3) };
            var ans = EnvelopesSolver.solve(envelopes);
            Console.WriteLine(ans);
        }
    }
}
