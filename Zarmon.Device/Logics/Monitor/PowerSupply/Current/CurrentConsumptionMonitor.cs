using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.PowerSupply.PowerManagment;
using Zarmon.Device.Logics.Monitor.Core;

namespace Zarmon.Device.Logics.Monitor.PowerSupply.Current
{
    public class CurrentConsumptionMonitor : MonitorLogic
    {
        private IPowerManagmentApi _powerManagmentApi;
        public CurrentConsumptionMonitor(MonitorSettings monitorSettings) : base(monitorSettings)
        {
        }

        public CurrentConsumptionMonitor(MonitorSettings monitorSettings, IPowerManagmentApi powerManagmentApi) : base(monitorSettings, powerManagmentApi)
        {
            _powerManagmentApi = powerManagmentApi;
        }

        protected override void Prepare()
        {
        }

        protected override MonitorResult Action()
        {
            throw new System.NotImplementedException();
        }

        protected override void Release()
        {
            throw new System.NotImplementedException();
        }
    }
}