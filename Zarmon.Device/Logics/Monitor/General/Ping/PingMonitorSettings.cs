using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Zarmon.Device.Logics.Monitor.Core;

namespace Zarmon.Device.Logics.Monitor.General.Ping
{
    public class PingMonitorSettings :MonitorSettings
    {
        public IPAddress IPAddress { get; set; }
    }
}
