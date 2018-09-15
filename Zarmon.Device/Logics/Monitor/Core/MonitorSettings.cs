using System;

namespace Zarmon.Device.Logics.Monitor.Core
{
    public class MonitorSettings : LogicSettings
    {
        public TimeSpan SamplingRate { get; set; } = TimeSpan.FromSeconds(5);
    }
}