using System;
using System.Collections.Generic;

namespace CarFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var passcar = CarFactory.ProducePassengerCar();
            var sportcar = CarFactory.ProduceSportCar();
            var truck = CarFactory.ProduceTruckCar();

            var carsList = new List<Car>() { passcar, sportcar, truck };

            foreach(var car in carsList)
            {
                Console.Write($"{car.GetType()} sounds:");
                car.driveSound();
            }
            Console.WriteLine();
        }
    }
}
