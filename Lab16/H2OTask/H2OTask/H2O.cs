using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H2OTask
{
    class H2O
    {
        object hLock = new object();
        object oLock = new object();
        int h = 0;
        Barrier b = new Barrier(2);

        public H2O()
        {

        }

        public void Hydrogen(Action releaseHydrogen)
        {
            lock (hLock)
            {
                ++h;

                releaseHydrogen();

                if (h == 2)
                {
                    b.SignalAndWait();
                    h = 0;
                }
            }
        }

        public void Oxygen(Action releaseOxygen)
        {
            lock (oLock)
            {
                releaseOxygen();
                b.SignalAndWait();
            }
        }
    }
}
