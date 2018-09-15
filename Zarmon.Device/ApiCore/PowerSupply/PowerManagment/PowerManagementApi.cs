using System;
using Zarmon.Connection.Core.Generic;
using Zarmon.Device.SyntaxCore.Core.Generic;
using Zarmon.Device.SyntaxCore.Core.Interfaces;

namespace Zarmon.Device.ApiCore.PowerSupply.PowerManagment
{
    public class PowerManagementApi : PowerSupplyApi , IPowerManagmentApi
    {
        private readonly IPowerManagementSyntax _powerManagementSyntax;

        public PowerManagementApi(IConnection connection, IPowerManagementSyntax powerManagementSyntax = null) : base(connection, powerManagementSyntax)
        {
            _powerManagementSyntax = powerManagementSyntax;
        }

        public void SetVoltage(ushort channel, double voltage)
        {
            _powerManagementSyntax.SET_VOLTAGE_LIMIT(channel, voltage);
        }

        public double GetVoltage(ushort channel)
        {
            Command<double> command = _powerManagementSyntax.GET_VOLTAGE(channel);
            object voltage = Connection.Execute(command);
            return command.Parser((string)voltage);
        }

        public void SetCurrentLimit(ushort channel, float currentLimit)
        {
            throw new System.NotImplementedException();
        }

        public void GetCurrentLimit(ushort channel)
        {
            throw new System.NotImplementedException();
        }

        public double GetCurrent(ushort channel)
        {
            throw new System.NotImplementedException();
        }

        public void SetCurrentLimit(ushort channel, double currentLimit)
        {
            throw new NotImplementedException();
        }
    }
}