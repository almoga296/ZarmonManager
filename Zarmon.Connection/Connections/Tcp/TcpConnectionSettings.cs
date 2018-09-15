using System.Net;
using Zarmon.Connection.Core;

namespace Zarmon.Connection.Connections.Tcp
{
    public class TcpConnectionSettings : ConnectionSettings
    {
        public IPEndPoint IpEndPoint => EndPoint as IPEndPoint;

        public TcpConnectionSettings(IPEndPoint endPoint) : base(endPoint)
        {
        }
    }
}