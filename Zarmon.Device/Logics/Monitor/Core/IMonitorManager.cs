namespace Zarmon.Device.Logics.Monitor.Core
{
    internal interface IMonitorManager
    {
        void StartAllMonitors();
        void StartMonitor(MonitorLogic monitorLogic);
        void StopAllMonitors();
        void StopMonitor(MonitorLogic monitorLogic);
    }
}