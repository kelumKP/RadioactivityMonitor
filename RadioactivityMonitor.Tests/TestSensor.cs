using RadioactivityMonitor.Infrastructure.Sensors;

namespace RadioactivityMonitor.Tests
{
    /*
     *  'Sensor' class is responsible for generating random values, there shoul be a way to control these values for testing
     *  This subclass allows it to inject controlled values for testing
     */
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
