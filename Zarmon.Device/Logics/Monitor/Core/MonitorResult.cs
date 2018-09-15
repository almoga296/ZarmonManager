using System;

namespace Zarmon.Device.Logics.Monitor.Core
{
    public enum ResultState
    {
        PASS,
        FAIL
    }

    public class MonitorResult : EventArgs
    {
        public ResultState ResultState { get; set; }
        public object ReturnedObject { get; set; }
    }
}