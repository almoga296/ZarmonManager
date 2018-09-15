using Zarmon.Device.SyntaxCore.Core.Generic;

namespace Zarmon.Device.SyntaxCore.Core.Interfaces
{
    public interface IPowerManagementSyntax : IPowerSupplySyntax
    {
        Command<double> GET_VOLTAGE(ushort channel);
        Command<double> GET_CURRENT(ushort channel);

        Command SET_CURRENT_LIMIT(ushort channel,double currentLimit);
        Command<double> GET_CURRENT_LIMIT(ushort channel);

        Command SET_VOLTAGE_LIMIT(ushort channel, double voltageLimit);
        Command<double> GET_VOLTAGE_LIMIT(ushort channel);
    }
}