using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.PowerSupply.PowerManagment;
using Zarmon.Device.Logics.Monitor.Core;

namespace Zarmon.Device.Logics.Monitor.PowerSupply.Voltage
{
    public sealed class VoltageMonitor : MonitorLogic
    {
        public VoltageMonitorSettings VoltageMonitorSettings => MonitorSettings as VoltageMonitorSettings;

        public VoltageMonitor(VoltageMonitorSettings voltageMonitorSettings) : base(voltageMonitorSettings)
        {
        }

        public VoltageMonitor(MonitorSettings monitorSettings, params IApi[] apis) : base(monitorSettings, apis)
        {
        }

        protected override void Prepare()
        {
        }

        protected override MonitorResult Action()
        {
            double voltage = GetApi<IPowerManagmentApi>().GetVoltage(VoltageMonitorSettings.Channel);
            return new MonitorResult();
        }

        protected override void Release()
        {
            throw new System.NotImplementedException();
        }
    }
}