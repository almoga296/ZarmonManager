using System.Net;
using System.Net.NetworkInformation;
using Serilog;
using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.Logics.Monitor.Core;

namespace Zarmon.Device.Logics.Monitor.General.Ping
{
    public class PingMonitor : MonitorLogic
    {
        private readonly PingMonitorSettings _pingMonitorSettings;

        public PingMonitor(PingMonitorSettings pingMonitorSettings) : base(pingMonitorSettings)
        {
            _pingMonitorSettings = pingMonitorSettings;
        }

        public PingMonitor(PingMonitorSettings monitorSettings, params IApi[] apis) : base(monitorSettings, apis)
        {
            _pingMonitorSettings = monitorSettings;
        }

        protected override void Prepare()
        {
        }

        protected override MonitorResult Action()
        {
            System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
            IPAddress address = _pingMonitorSettings.IPAddress;
            PingReply reply = pingSender.Send(address);

            if (reply?.Status == IPStatus.Success)
            {
                Log.Debug("Address: {Address}, RoundTrip time: {RoundTrip}, Time to live: {Ttl}", reply.Address.ToString(), reply.RoundtripTime, reply.Options.Ttl);
                return new MonitorResult { ResultState =  ResultState.PASS , ReturnedObject = reply };
            }
            Log.Warning("Ping failed {@pingStatus}", reply?.Status);
            return new MonitorResult {ResultState = ResultState.FAIL, ReturnedObject = reply};
        }

        protected override void Release()
        {
        }
    }
}