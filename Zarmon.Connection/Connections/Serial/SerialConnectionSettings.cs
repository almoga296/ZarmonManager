using System.IO.Ports;
using Zarmon.Connection.Core;

namespace Zarmon.Connection.Connections.Serial
{
    public class SerialConnectionSettings : ConnectionSettings
    {
        public SerialEndPoint SerialEndPoint => EndPoint as SerialEndPoint;

        public int BaudRate { get; set; }
        public Parity Parity { get; set; }
        public string Com { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }

        public SerialConnectionSettings(SerialEndPoint endPoint) : base(endPoint)
        {
        }
    }
}