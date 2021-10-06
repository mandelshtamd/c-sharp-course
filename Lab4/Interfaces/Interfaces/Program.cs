using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Caracal("orange", "Peter");
            IDomestic testDomesticCat = new Caracal("green", "Alex");
            IWild testWildCat = new Caracal("white", "Vlad");

            cat.MakeSound();
            testDomesticCat.MakeSound();
            testWildCat.MakeSound();
        }
    }
}
