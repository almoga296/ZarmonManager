using System;
using System.Net;

namespace Zarmon.Connection.Connections.Http
{
    public class UriEndPoint : EndPoint
    {
        public Uri Uri { get; set; }

        public UriEndPoint(Uri uri)
        {
            Uri = uri;
        }
    }
}