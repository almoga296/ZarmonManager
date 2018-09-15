using System.Reflection;
using FluentValidation;
using Serilog;
using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.PowerSupply;
using Zarmon.Device.Logics.Control.Core;
using Zarmon.Device.Logics.Validation;

namespace Zarmon.Device.Logics.Control.PowerSupply
{
    public class PowerSupplyControlLogic : ControlLogic, IPowerSupplyLogic
    {
        public PowerSupplyControlLogic(PowerSupplyControlSettings powerSupplyControlSettings) : base(powerSupplyControlSettings)
        {
        }

        public PowerSupplyControlLogic(ControlSettings controlSettings, params IApi[] apis) : base(controlSettings, apis)
        {
        }

        public bool TurnOn(ushort channel)
        {
            Log.Debug($"Enter method {MethodBase.GetCurrentMethod().Name} with args :{channel}");
            GetApi<IPowerSupplyApi>().TurnOn(channel);
            bool outputState = GetApi<IPowerSupplyApi>().GetOutputState(channel);
            PowerStateValidator powerStateValidator = new PowerStateValidator(expectedValue: true);
            var res = powerStateValidator.Validate(outputState);

            return true;
        }

        public bool TurnOff(ushort channel)
        {
            GetApi<IPowerSupplyApi>().TurnOff(channel);
            PowerStateValidator powerStateValidator = new PowerStateValidator(expectedValue: true);
            bool outputState = GetApi<IPowerSupplyApi>().GetOutputState(channel);
            powerStateValidator.ValidateAndThrow(outputState);
            return true;
        }

    }
}