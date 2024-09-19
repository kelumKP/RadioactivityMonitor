using Microsoft.Extensions.Configuration;
using RadioactivityMonitor.Infrastructure.Sensors;

namespace RadioactivityMonitor.Infrastructure.Entities
{
    public class Alarm : IAlarm
    {
        private readonly double _lowThreshold;
        private readonly double _highThreshold;
        // Use ISensor instead of Sensor
        private readonly ISensor _sensor; 

        private bool _alarmOn = false;
        private long _alarmCount = 0;

        /*
         * 
         *  Allow the Sensor to be passed via constructor injection to make the class more testable and adhere to the Dependency Inversion Principle.
         */
        public Alarm(ISensor sensor, IConfiguration config) // Accept ISensor
        {
            _sensor = sensor;
            // Consider making these values configurable through appesettings.json file
            _lowThreshold = double.Parse(config["AlarmSettings:LowThreshold"]);
            _highThreshold = double.Parse(config["AlarmSettings:HighThreshold"]);
        }

        public void Check()
        {
            double value = _sensor.NextMeasure();

            /*
             * "|" will always evaluate both sides of the condition.
             *  Replace "|" with the logical OR "||", which will short-circuit if the first condition is true. 
             */
            if (value < _lowThreshold || _highThreshold < value)
            {
                _alarmOn = true;
                // Use locking or consider using thread-safe types like Interlocked for managing _alarmCount.
                Interlocked.Increment(ref _alarmCount);
            }
            // Add logic to reset _alarmOn to false if the measurement is within the threshold range.
            else
            {
                _alarmOn = false;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }
    }
}