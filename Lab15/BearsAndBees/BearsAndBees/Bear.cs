using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BearsAndBees
{
    public class Bear
    {
        HoneyPot pot;
        public Bear(HoneyPot pot)
        {
            this.pot = pot;
        }
        public void run()
        {
            while (true)
            {
                lock (pot)
                {
                    while (!pot.isFull())
                    {
                        Monitor.Wait(pot);
                    }
                    Console.WriteLine("Пчела будит медведя");
                    Console.WriteLine("Медведь проснулся");
                    pot.emptyPot();
                    Monitor.PulseAll(pot);
                }
            }

        }
    }
}
