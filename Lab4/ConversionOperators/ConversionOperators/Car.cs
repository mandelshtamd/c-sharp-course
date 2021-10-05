using System;
using System.Collections.Generic;
using System.Text;

namespace ConversionOperators
{
    public enum Color
    {
        Green,
        Red,
        White,
        Black
    }
    public class Car
    {
        public int MaxSpeed
        {
            get;
            private set;
        }

        public Color Color
        {
            get;
            private set;
        }

        public Car(int maxSpeed, Color color)
        {
            MaxSpeed = maxSpeed;
            Color = color;
        }
    }
}
