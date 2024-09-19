using RadioactivityMonitor.Application.DTOs;

namespace RadioactivityMonitor.Application.Interfaces
{
    public interface IAlarmService
    {
        AlarmDto CheckAlarm();
    }
}