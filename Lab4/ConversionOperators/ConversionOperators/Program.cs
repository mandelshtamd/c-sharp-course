using System;

namespace ConversionOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            var horse = new Horse(16, Color.Black, 16, "Bob");
            // explicit conversion
            ((Car)horse).Beep();

            var newHorse = new Horse(3, Color.Red, 26, "Tom");
            // implicit conversion
            Car newCar = newHorse;
            newCar.Beep();

            // Comparison results
            Console.WriteLine($"horse < newHorse: {horse < newHorse}");
            Console.WriteLine($"newHorse < horse: {newHorse < horse}");
            Console.WriteLine($"horse == newHorse: {horse == newHorse}");
        }
    }
}
