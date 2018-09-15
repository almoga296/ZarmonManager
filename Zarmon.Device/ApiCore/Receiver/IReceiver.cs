using Zarmon.Device.ApiCore.Core;

namespace Zarmon.Device.ApiCore.Receiver
{
    public interface IReceiver : IApi
    {
        byte[] Receive();
    }
}