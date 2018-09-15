using Zarmon.Connection.Core.Generic;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.SyntaxCore.Core;
using Zarmon.Device.SyntaxCore.Core.Generic;
using Zarmon.Device.SyntaxCore.Core.Interfaces;

namespace Zarmon.Device.ApiCore.PowerSupply
{
    public class PowerSupplyApi : Api, IPowerSupplyApi
    {
        private IPowerSupplySyntax _powerSuppltSyntax;

        public PowerSupplyApi(IConnection connection, IPowerSupplySyntax powerSuppltSyntax = null) : base(connection, powerSuppltSyntax)
        {
            _powerSuppltSyntax = powerSuppltSyntax;
        }

        public void TurnOn(ushort channel)
        {
            Command command = _powerSuppltSyntax.TURN_POWER_ON(channel);
            Connection.Execute(command.Builder());
        }

        public void TurnOff(ushort channel)
        {
            Command command = _powerSuppltSyntax.TURN_POWER_OFF(channel);
            Connection.Execute(command.Builder());
        }

        public bool GetOutputState(ushort channel)
        {
            Command<bool> command = _powerSuppltSyntax.GET_POWER_STATE(channel);
            var response = Connection.Execute(command.Builder());
            return command.Parser(response);

        }
    }
}