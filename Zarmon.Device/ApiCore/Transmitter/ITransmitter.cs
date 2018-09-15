using Zarmon.Device.ApiCore.Core;

namespace Zarmon.Device.ApiCore.Transmitter
{
    public interface ITransmitter : IApi
    {
        void Transmit(byte[] data);
    }
}