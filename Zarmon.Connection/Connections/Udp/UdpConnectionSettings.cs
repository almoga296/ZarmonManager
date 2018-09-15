using System.Net;
using Zarmon.Connection.Core;

namespace Zarmon.Connection.Connections.Udp
{
    public class UdpConnectionSettings : ConnectionSettings
    {
        public UdpConnectionSettings(IPEndPoint endPoint) : base(endPoint)
        {
        }
    }
}   