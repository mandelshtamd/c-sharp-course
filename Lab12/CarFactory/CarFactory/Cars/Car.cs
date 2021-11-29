using System;
using System.Collections.Generic;
using System.Text;

namespace CarFactory
{
    abstract class Car
    {
        /*Каждый автомобиль состоит из кузова, двигателя, шасси, коробки передач, приборной панели,
          стерео-системы.Двигатель может включать в себя цилиндры.
          При этом каждый автомобиль имеет свой индивидуальный номер кузова*/

        private CarBody _body;
        private Chassis _chassis;
        private Dashboard _dashboard;
        private Engine _engine;
        private Transmission _transmission;
        private StereoSystem _stereo;

        public long UniqueNumber
        {
            get { return _body.UniqueNumber; }
        }

        protected Car(CarBody body, Chassis chassis, Dashboard dashboard, Engine engine, 
                        Transmission transmission, StereoSystem stereo)
        {
            _body = body;
            _chassis = chassis;
            _dashboard = dashboard;
            _engine = engine;
            _transmission = transmission;
            _stereo = stereo;
        }

        virtual public void driveSound()
        {
            Console.WriteLine("");
        }
    }
    // перечислители принято помещать в начале файла
    enum CarTypes
    {
        PassengerCar,
        SportCar,
        Truck
    }
}
