using System;

namespace Interfaces
{
    public abstract class Cat
    {
        public abstract void MakeSound();

        public abstract void ChangeColor(string color);

        public string Name
        {
            get;
            protected set;
        }

        public string Color
        {
            get;
            protected set;
        }
    }

    internal interface IWild
    {
        void MakeSound();
    }

    internal interface IDomestic
    {
        void MakeSound();
    }

    public class Caracal : Cat, IWild, IDomestic
    {
        public Caracal(string color, string name)
        {
            Name = name;
            Color = color;
        }

        public override void ChangeColor(string color)
        {
            Color = color;
        }

        void IWild.MakeSound()
        {
            Console.WriteLine("ar");
        }

        void IDomestic.MakeSound()
        {
            Console.WriteLine("meow");
        }
        public override void MakeSound()
        {
            Console.WriteLine("I'm a cat");
        }
    }
}