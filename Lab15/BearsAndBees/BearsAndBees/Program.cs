using System;
using System.Threading;
using System.Threading.Tasks;

namespace BearsAndBees
{
    class Program
    {
        static void Main(string[] args)
        {
            int honeyPotVolume = 20;
            int beesNum = 5;

            HoneyPot pot = new HoneyPot(honeyPotVolume);
            Bear bear = new Bear(pot);
            var bearT = Task.Factory.StartNew(() => bear.run());

            for (int i = 0; i < beesNum; i++)
            {
                Bee bee = new Bee(pot);
                var beeT = Task.Factory.StartNew(() => bee.run());
            }

            bearT.Wait();
        }
    }
}
