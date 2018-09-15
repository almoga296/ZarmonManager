using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;

namespace Zarmon.Device.Logics.Repair
{
    public class RepairLogic : Logic
    {
        public RepairLogic(LogicSettings logicSettings) : base(logicSettings)
        {
        }

        public RepairLogic(LogicSettings logicSettings, params IApi[] apis) : base(logicSettings, apis)
        {
        }
    }
}