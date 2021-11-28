namespace CarFactory
{
    class CarBody : CarDetail
    {

        private double _length;
        private long _uniqueNumber;

        public long UniqueNumber
        {
            get
            {
                return _uniqueNumber;
            }
        }

        public CarBody(string model, double length, long uniqueNumber)
        {
            _model = model;
            _length = length;
            _uniqueNumber = uniqueNumber;
        }
    }
}
