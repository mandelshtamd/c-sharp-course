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

        public int Years
        {
            get;
            private set;
        }

        public Car(int maxSpeed, Color color, int years)
        {
            MaxSpeed = maxSpeed;
            Color = color;
            Years = years;
        }

        public void Beep()
        {
            Console.WriteLine("beep beep");
        }

        public string GetCharacteristic()
        {
            return $"max speed = {MaxSpeed}, color = {Color}, years of exploitation = {Years}";
        }
    }
}
