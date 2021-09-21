using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmutableType
{
    public class ImmutableDog
    {
        private readonly string _name;

        public string Name => _name;

        public ImmutableDog(string name)
        {
            _name = name;
        }

        public static void Bark()
        {
            Console.WriteLine(@"     |\_/|                  " +
                              "     | @ @   Woof! " +
                              "     |   <>              _  " +
                              @"     |  _/\------____ ((| |))" +
                              "     |               `--' |  " +
                              " ____|_       ___|   |___.' " +
                              "/_/_____/____/_______|");
        }

        public static ImmutableDog RenameDog(ImmutableDog _, string name)
        {
            return new ImmutableDog(name);
        }

        public ImmutableDog RenameDog(string name)
        {
            return ImmutableDog.RenameDog(this, name);
        }
    }
}
