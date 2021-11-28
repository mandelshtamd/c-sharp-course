﻿using CarFactory.Cars;
using System.Collections.Generic;

namespace CarFactory
{
    class CarFactory
    {
        private static long lastUniqueCarBodyNumber = 0;

        public static SportCar ProduceSportCar(string bodyModel = "default model", double bodyLength = 13.0,
            Dashboard dashboard = default, StereoSystem stereo = default)
        {
            var body = new CarBody(bodyModel, bodyLength, lastUniqueCarBodyNumber + 1);
            lastUniqueCarBodyNumber++;

            var commonChassis = new Chassis("default model");
            var commonEngine = new Engine("default model", 123.5, new List<Cylinder>() { new Cylinder("default model") });
            var commonTransmission = new Transmission(0.9, "default model");

            return new SportCar(body, commonChassis, dashboard, commonEngine, commonTransmission, stereo);
        }

        public static PassengerCar ProducePassengerCar(string bodyModel = "default model", double bodyLength = 13.0,
            Dashboard dashboard = default, StereoSystem stereo = default)
        {
            var body = new CarBody(bodyModel, bodyLength, lastUniqueCarBodyNumber + 1);
            lastUniqueCarBodyNumber++;

            var commonChassis = new Chassis("default model");
            var commonEngine = new Engine("default model", 123.5, new List<Cylinder>() { new Cylinder("default model") });
            var commonTransmission = new Transmission(0.9, "default model");

            return new PassengerCar(body, commonChassis, dashboard, commonEngine, commonTransmission, stereo);
        }

        public static Truck ProduceTruckCar(string bodyModel = "default model", double bodyLength = 13.0,
            Dashboard dashboard = default, StereoSystem stereo = default)
        {
            var body = new CarBody(bodyModel, bodyLength, lastUniqueCarBodyNumber + 1);
            lastUniqueCarBodyNumber++;

            var commonChassis = new Chassis("default model");
            var commonEngine = new Engine("default model", 123.5, new List<Cylinder>() { new Cylinder("default model") });
            var commonTransmission = new Transmission(0.9, "default model");

            return new Truck(body, commonChassis, dashboard, commonEngine, commonTransmission, stereo);
        }
    }
}
