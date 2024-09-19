using RadioactivityMonitor.Infrastructure.Sensors;

namespace RadioactivityMonitor.Tests
{
    public class TestSensor : ISensor
    {
        private double _nextMeasure;

        public TestSensor(double initialMeasure)
        {
            _nextMeasure = initialMeasure;
        }

        public double NextMeasure()
        {
            return _nextMeasure;
        }

        public void SetNextMeasure(double measure)
        {
            _nextMeasure = measure;
        }
    }
}
