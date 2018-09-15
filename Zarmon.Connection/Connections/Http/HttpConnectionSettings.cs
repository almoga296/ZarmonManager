using System.Net;
using Zarmon.Connection.Core;

namespace Zarmon.Connection.Connections.Http
{
    public class HttpConnectionSettings : ConnectionSettings
    {
        
        public HttpConnectionSettings(EndPoint endPoint) : base(endPoint)
        {
        }
    }
}