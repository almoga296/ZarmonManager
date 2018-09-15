using System.Net;

namespace Zarmon.Connection.Connections.Serial
{
    public class SerialEndPoint : EndPoint
    {
        public string ComPort { get; set; }

        public SerialEndPoint(string comPort)
        {
            ComPort = comPort;
        }

        public override string ToString()
        {
            return $"{ComPort}";
        }
    }
}