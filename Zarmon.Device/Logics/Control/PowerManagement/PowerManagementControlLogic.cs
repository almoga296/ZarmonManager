using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.Logics.Control.Core;
using Zarmon.Device.Logics.Control.PowerSupply;

namespace Zarmon.Device.Logics.Control.PowerManagement
{
    public class PowerManagementControlLogic : PowerSupplyControlLogic
    {
        public PowerManagementControlLogic(PowerSupplyControlSettings powerSupplyControlSettings) : base(powerSupplyControlSettings)
        {
        }

        public PowerManagementControlLogic(ControlSettings controlSettings, params IApi[] apis) : base(controlSettings, apis)
        {
        }
    }
}