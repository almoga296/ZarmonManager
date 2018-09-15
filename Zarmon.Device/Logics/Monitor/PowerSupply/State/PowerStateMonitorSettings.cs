using System;
using System.Collections.Generic;
using System.Text;
using Zarmon.Device.Logics.Monitor.Core;

namespace Zarmon.Device.Logics.Monitor.PowerSupply.State
{
    public class PowerStateMonitorSettings : MonitorSettings
    {
        public ushort Channel { get; set; }
        public bool ExpectedState { get; set; }
    }
}
