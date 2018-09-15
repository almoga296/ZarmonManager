using Zarmon.Device.SyntaxCore.Core.Generic;

namespace Zarmon.Device.SyntaxCore.Core.Interfaces
{
    public interface IPowerSupplySyntax: ISyntax
    {
        Command TURN_POWER_ON(ushort channel);
        Command TURN_POWER_OFF(ushort channel);
        Command<bool> GET_POWER_STATE(ushort channel);
    }
}