using System;
using System.Collections.Generic;
using System.Text;

namespace ConversionOperators
{
    internal class Horse
    {
        public int Years
        {
            get;
            private set;
        }

        public Color Color
        {
            get;
            private set;
        }

        public int MaxSpeed
        {
            get;
            private set;
        }

        public string Name;

        public Horse(int years, Color color, int maxSpeed, string name)
        {
            Years = years;
            Color = color;
            MaxSpeed = maxSpeed;
            Name = name;
        }

        public static bool operator <(Horse lhs, Horse rhs)
        {
            return lhs.MaxSpeed < rhs.MaxSpeed;
        }

        public static bool operator >(Horse lhs, Horse rhs)
        {
            return rhs < lhs && rhs != lhs;
        }


        public static bool operator ==(Horse lhs, Horse rhs)
        {
            return lhs.MaxSpeed == rhs.MaxSpeed;
        }

        public static bool operator !=(Horse lhs, Horse rhs)
        {
            return !(lhs == rhs);
        }

        public static implicit operator Car(Horse horse)
        {
            Console.WriteLine("conversion from Horse to Car");
            return new Car(horse.MaxSpeed, horse.Color, horse.Years);
        }

    }
}
