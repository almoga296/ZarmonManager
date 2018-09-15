using System;
using System.Collections.Generic;
using System.Text;
using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.PowerSupply;
using Zarmon.Device.Logics.Monitor.Core;

namespace Zarmon.Device.Logics.Monitor.PowerSupply.State
{
    public class PowerStateMonitor : MonitorLogic
    {
        private PowerStateMonitorSettings _powerStateMonitorSettings;
        private IPowerSupplyApi _powerSupplyApi;

        public PowerStateMonitor(PowerStateMonitorSettings powerStateMonitorSettings, IPowerSupplyApi powerSupplyApi) : base(powerStateMonitorSettings, powerSupplyApi)
        {
            _powerStateMonitorSettings = powerStateMonitorSettings;
            _powerSupplyApi = powerSupplyApi;
        }

        protected override void Prepare()
        {
        }

        protected override MonitorResult Action()
        {
            bool powerState = _powerSupplyApi.GetOutputState(_powerStateMonitorSettings.Channel);
            if (powerState == _powerStateMonitorSettings.ExpectedState)
            {
                return new MonitorResult()
                {
                    ResultState = ResultState.PASS,
                    ReturnedObject = powerState
                };
            }
            return new MonitorResult()
            {
                ResultState = ResultState.FAIL,
                ReturnedObject = powerState
            };
        }

        protected override void Release()
        {
            throw new NotImplementedException();
        }
    }
}
