using Microsoft.Extensions.Configuration;
using RadioactivityMonitor.Application.DTOs;
using RadioactivityMonitor.Application.Interfaces;
using RadioactivityMonitor.Infrastructure.Entities;
using RadioactivityMonitor.Infrastructure.Sensors;

namespace RadioactivityMonitor.Application.Services
    {
        public class AlarmService : IAlarmService
        {
            private readonly Sensor _sensor;
            private readonly Alarm _alarm;

            public AlarmService(Sensor sensor, IConfiguration config)
            {
                _sensor = sensor;
                _alarm = new Alarm(_sensor, config);
            }

            public AlarmDto CheckAlarm()
            {
                _alarm.Check();
                return new AlarmDto
                {
                    IsAlarmOn = _alarm.AlarmOn
                };
            }
        }
    }
