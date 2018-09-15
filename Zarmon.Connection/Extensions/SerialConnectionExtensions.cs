using System.IO.Ports;
using Zarmon.Connection.Connections.Serial;

namespace Zarmon.Connection.Extensions
{
    public static class SerialConnectionExtensions
    {
        public static string[] GetAllComPorts(this SerialConnection connection)
        {
            return SerialPort.GetPortNames();
        }
    }
}