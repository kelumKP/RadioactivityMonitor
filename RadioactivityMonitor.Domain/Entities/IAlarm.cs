namespace RadioactivityMonitor.Infrastructure.Entities
{
    public interface IAlarm
    {
        bool AlarmOn { get; }
        void Check();
    }
}
