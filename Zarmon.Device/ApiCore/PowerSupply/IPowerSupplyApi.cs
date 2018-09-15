using Zarmon.Device.ApiCore.Core;

namespace Zarmon.Device.ApiCore.PowerSupply
{
    public interface IPowerSupplyApi : IApi
    {
        void TurnOn(ushort channel);
        void TurnOff(ushort channel);
        bool GetOutputState(ushort channel);
    }
}