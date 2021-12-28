using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearsAndBees
{
    public class HoneyPot
    {
        int potSize;
        int portions;
        public HoneyPot(int potSize)
        {
            this.potSize = potSize;
        }

        public void emptyPot()
        {
            portions = 0;
            Console.WriteLine("Бочонок пуст");
        }

        public void addPortion()
        {
            portions++;
            Console.WriteLine(portions.ToString() + " порция меда");
        }

        public bool isFull() { return potSize == portions; }
    }
}
