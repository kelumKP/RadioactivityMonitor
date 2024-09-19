using Microsoft.Extensions.Configuration;
using RadioactivityMonitor.Infrastructure.Entities;

namespace RadioactivityMonitor.Tests
{
    public class AlarmTests
    {
        private readonly TestSensor _sensor;
        private readonly IConfiguration _config;
        private readonly Alarm _alarm;

        public AlarmTests()
        {
            // Set up the configuration manually
            var configDict = new Dictionary<string, string>
            {
                { "AlarmSettings:LowThreshold", "17" },
                { "AlarmSettings:HighThreshold", "21" }
            };
            _config = new ConfigurationBuilder()
                .AddInMemoryCollection(configDict)
                .Build();

            // Create a TestSensor instance
            _sensor = new TestSensor(0);
            // Create the Alarm instance with the TestSensor and configuration
            _alarm = new Alarm(_sensor, _config);
        }

        [Fact]
        public void Check_AlarmShouldTurnOn_WhenValueIsBelowLowThreshold()
        {
            // Arrange
            _sensor.SetNextMeasure(10);

            // Act
            _alarm.Check();

            // Assert
            Assert.True(_alarm.AlarmOn);
        }

        [Fact]
        public void Check_AlarmShouldTurnOn_WhenValueIsAboveHighThreshold()
        {
            // Arrange
            _sensor.SetNextMeasure(25);

            // Act
            _alarm.Check();

            // Assert
            Assert.True(_alarm.AlarmOn);
        }

        [Fact]
        public void Check_AlarmShouldTurnOff_WhenValueIsWithinThresholds()
        {
            // Arrange
            _sensor.SetNextMeasure(18);

            // Act
            _alarm.Check();

            // Assert
            Assert.False(_alarm.AlarmOn);
        }

        [Fact]
        public void Check_AlarmShouldReset_WhenValueReturnsToNormal()
        {
            // Arrange
            _sensor.SetNextMeasure(10);
            _alarm.Check(); // Trigger alarm

            // Act
            // Return to normal
            _sensor.SetNextMeasure(18); 
            _alarm.Check();

            // Assert
            Assert.False(_alarm.AlarmOn);
        }
    }
}
