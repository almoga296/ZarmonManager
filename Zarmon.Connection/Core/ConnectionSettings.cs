using System;
using System.Net;

namespace Zarmon.Connection.Core
{
    public abstract class ConnectionSettings
    {
        public EndPoint EndPoint { get; set; }

        public string IncommingEndLineChar { get; set; } = Environment.NewLine;
        public string OutgoingEndLineChar { get; set; } = Environment.NewLine;
        public int ReceiveTimeout { get; set; } = 3000;
        public int SendTimeout { get; set; } = 3000;

        protected ConnectionSettings(EndPoint endPoint)
        {
            EndPoint = endPoint;
        }
    }
}