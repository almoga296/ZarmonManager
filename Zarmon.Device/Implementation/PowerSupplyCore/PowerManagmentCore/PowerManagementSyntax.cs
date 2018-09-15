using System.Text;
using Zarmon.Device.SyntaxCore.Core;
using Zarmon.Device.SyntaxCore.Core.Generic;
using Zarmon.Device.SyntaxCore.Core.Interfaces;

namespace Zarmon.Device.Implementation.PowerSupplyCore.PowerManagmentCore
{
    public class PowerManagementSyntax : IPowerManagementSyntax
    {

        public Command RESET()
        {
            return new Command
            {
                Builder = () => Encoding.ASCII.GetBytes($"*RST")
            };
        }

        public Command TURN_POWER_ON(ushort channel)
        {
            return new Command
            {
                Builder = () => Encoding.ASCII.GetBytes($"OUTP ON (@{channel})")
            };
        }

        public Command TURN_POWER_OFF(ushort channel)
        {
            return new Command
            {
                Builder = () => Encoding.ASCII.GetBytes($"OUTP OFF (@{channel})")
            };
        }

        public Command<bool> GET_POWER_STATE(ushort channel)
        {
            return new Command<bool>
            {
                Builder = () => Encoding.ASCII.GetBytes($"OUTP? (@{channel})"),
                Parser = bytes => bool.Parse(Encoding.ASCII.GetString((byte[])bytes))
            };
        }

        public Command SET_VOLTAGE(ushort channel, double voltage)
        {
            return new Command
            {
                Builder = ()=> Encoding.ASCII.GetBytes($"V{channel} {voltage}")
            };
        }

        public Command<double> GET_VOLTAGE(ushort channel)
        {
            return new Command<double>
            {
                Builder = () => Encoding.ASCII.GetBytes($"VOLT?"),
                Parser = bytes => double.Parse(Encoding.ASCII.GetString((byte[])bytes))
            };
        }

        public Command<double> GET_CURRENT(ushort channel)
        {
            throw new System.NotImplementedException();
        }

        public Command SET_CURRENT_LIMIT(ushort channel, double currentLimit)
        {
            throw new System.NotImplementedException();
        }

        public Command<double> GET_CURRENT_LIMIT(ushort channel)
        {
            throw new System.NotImplementedException();
        }

        public Command SET_VOLTAGE_LIMIT(ushort channel, double voltageLimit)
        {
            throw new System.NotImplementedException();
        }

        public Command<double> GET_VOLTAGE_LIMIT(ushort channel)
        {
            throw new System.NotImplementedException();
        }
    }
}