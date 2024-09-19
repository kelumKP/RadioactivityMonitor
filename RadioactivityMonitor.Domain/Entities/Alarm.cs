using Microsoft.Extensions.Configuration;
using RadioactivityMonitor.Infrastructure.Sensors;

namespace RadioactivityMonitor.Infrastructure.Entities
{
    public class Alarm : IAlarm
    {
        private readonly double _lowThreshold;
        private readonly double _highThreshold;
        private readonly ISensor _sensor; // Use ISensor instead of Sensor

        private bool _alarmOn = false;
        private long _alarmCount = 0;

        public Alarm(ISensor sensor, IConfiguration config) // Accept ISensor
        {
            _sensor = sensor;
            _lowThreshold = double.Parse(config["AlarmSettings:LowThreshold"]);
            _highThreshold = double.Parse(config["AlarmSettings:HighThreshold"]);
        }

        public void Check()
        {
            double value = _sensor.NextMeasure();

            if (value < _lowThreshold || _highThreshold < value)
            {
                _alarmOn = true;
                Interlocked.Increment(ref _alarmCount);
            }
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