namespace CarFactory
{
    class Transmission : CarDetail
    {
        private double _power;
        public double Power
        {
            get { return _power; }
        }

        public Transmission(double power, string model)
        {
            _power = power;
            _model = model;
        }
    }
}
