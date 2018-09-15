using System.Text;
using Zarmon.Device.SyntaxCore;
using Zarmon.Device.SyntaxCore.Core;
using Zarmon.Device.SyntaxCore.Core.Generic;
using Zarmon.Device.SyntaxCore.Core.Interfaces;

namespace Zarmon.Device.Implementation.PowerSupplyCore.TdkLambda
{
    public class TdkLambdaScpiSyntax : ScpiSyntax , IPowerManagementSyntax
    {
        public Command TURN_POWER_ON(ushort channel)
        {
            return new Command
            {
                Builder = () => Encoding.ASCII.GetBytes("OUTP:STAT ON")
            };
        }

        public Command TURN_POWER_OFF(ushort channel)
        {
            return new Command
            {
                Builder = () => Encoding.ASCII.GetBytes("OUTP:STAT OFF")
            };
        }

        public Command<bool> GET_POWER_STATE(ushort channel)
        {
            return new Command<bool>
            {
                Builder = () => Encoding.ASCII.GetBytes("OUTP:STAT?"),
                Parser = bytes => bool.Parse(Encoding.ASCII.GetString((byte[])bytes))
            };
        }

        public Command<double> GET_VOLTAGE(ushort channel)
        {
            return new Command<double>
            {
                Builder = () => Encoding.ASCII.GetBytes("MEAS:VOLT?"),
                Parser = bytes => double.Parse(Encoding.ASCII.GetString((byte[])bytes))
            };
        }

        public Command<double> GET_CURRENT(ushort channel)
        {
            return new Command<double>
            {
                Builder = () => Encoding.ASCII.GetBytes("MEAS:CURR?"),
                Parser = bytes => double.Parse(Encoding.ASCII.GetString((byte[])bytes))
            };
        }

        public Command SET_CURRENT_LIMIT(ushort channel, double currentLimit)
        {
            return new Command
            {
                Builder = () => Encoding.ASCII.GetBytes($"SOUR:CURR {currentLimit}")
            };
        }

        public Command<double> GET_CURRENT_LIMIT(ushort channel)
        {
            return new Command<double>
            {
                Builder = () => Encoding.ASCII.GetBytes("SOUR:CURR?"),
                Parser = bytes => double.Parse(Encoding.ASCII.GetString((byte[])bytes))
            };
        }

        public Command SET_VOLTAGE_LIMIT(ushort channel, double voltageLimit)
        {
            return new Command
            {
                Builder = () => Encoding.ASCII.GetBytes($"SOUR:VOLT {voltageLimit}")
            };
        }

        public Command<double> GET_VOLTAGE_LIMIT(ushort channel)
        {
            return new Command<double>
            {
                Builder = () => Encoding.ASCII.GetBytes("SOUR:VOLT?"),
                Parser = bytes => double.Parse(Encoding.ASCII.GetString((byte[])bytes))
            };
        }
    }
}