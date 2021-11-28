using System;

namespace CarFactory.Cars
{
    class Truck : Car
    {
        public Truck(CarBody body, Chassis chassis, Dashboard dashboard, Engine engine,
                        Transmission transmission, StereoSystem stereo) : base(body, chassis, dashboard, engine,
                                                                                transmission, stereo) { }

        public override void driveSound()
        {
            Console.WriteLine("pshh");
        }
    }
}
