using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BearsAndBees
{
    class Bee
    {
        HoneyPot pot;

        public Bee(HoneyPot pot)
        {
            this.pot = pot;
        }


        public void run()
        {
            while (true)
            {
                Thread.Sleep(50);

                lock (pot)
                {
                    while (pot.isFull())
                    {
                        Monitor.Wait(pot);
                    }
                    pot.addPortion();
                    if (pot.isFull())
                        Monitor.PulseAll(pot);
                }
            }
        }
    }

}
