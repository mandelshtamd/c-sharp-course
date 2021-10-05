using System;
using System.Collections.Generic;
using System.Text;

namespace ConversionOperators
{
    class Horse
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

        public bool IsShod
        {
            get;
            private set;
        }
        public int MaxSpeed;

        Horse(int years, bool isShod, Color color)
        {
            Years = years;
            IsShod = isShod;
            Color = color;
        }

        Horse(int years, bool isShod, Color color, int maxSpeed)
        {
            Years = years;
            IsShod = isShod;
            Color = color;
            MaxSpeed = maxSpeed;
        }

        public static bool operator <(Horse lhs, Horse rhs)
        {
            return true;
        }

        public static bool operator >(Horse lhs, Horse rhs)
        {
            return rhs < lhs;
        }


        public static bool operator ==(Horse lhs, Horse rhs)
        {
            return lhs.IsShod == rhs.IsShod && lhs.Years == rhs.Years;
        }

        public static bool operator !=(Horse lhs, Horse rhs)
        {
            return lhs == rhs;
        }

        public static explicit operator Car(Horse horse)
        {
            return new Car(horse.MaxSpeed, horse.Color);
        }
    }
}
