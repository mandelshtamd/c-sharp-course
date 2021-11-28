namespace CarFactory
{
    class StereoSystem : CarDetail
    {
        private double _maxSoundLevel;
        public double maxSoundLevel
        {
            get
            {
                return _maxSoundLevel;
            }
        }

        public StereoSystem(string model, double maxSoundLevel)
        {
            _model = model;
            _maxSoundLevel = maxSoundLevel;
        }
    }
}
