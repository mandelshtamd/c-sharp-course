using System;
using System.Collections.Generic;
using System.Text;

namespace CarFactory
{
    class Engine : CarDetail
    {
        private double _power;
        public double Power
        {
            get { return _power; }
        }

        private List<Cylinder> _cylinders = null;


        public Engine(string model, double power, List<Cylinder> cylinders)
        {
            _model = model;
            _power = power;
            _cylinders = cylinders;
        }
    }
}
