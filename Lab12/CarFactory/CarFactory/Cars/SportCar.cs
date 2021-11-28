using System;

namespace CarFactory.Cars
{
    class SportCar : Car
    {
        public SportCar(CarBody body, Chassis chassis, Dashboard dashboard, Engine engine,
                        Transmission transmission, StereoSystem stereo) : base(body, chassis, dashboard, engine,
                                                                                transmission, stereo) { }

        public override void driveSound()
        {
            Console.WriteLine("wwoooooooww");
        }
    }
}
