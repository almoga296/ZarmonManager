using System.Net;
using System.Net.Sockets;
using Zarmon.Common;
using Zarmon.Connection.Core.Generic;

namespace Zarmon.Connection.Connections.Udp
{
    public class UdpConnection : Core.Connection
    {
        protected UdpClient UdpClient;
        //Saved as data member to reduce the casting op every receive call
        private readonly UdpConnectionSettings _udpConnectionSettings;
        protected IPEndPoint IpEndPoint;

        public UdpConnection(UdpConnectionSettings udpConnectionSettings) : base(udpConnectionSettings)
        {
            UdpClient = new UdpClient();
            _udpConnectionSettings = udpConnectionSettings;
            UdpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            IpEndPoint = (IPEndPoint) _udpConnectionSettings.EndPoint;
            UdpClient.Client.Bind(IpEndPoint);
        }

        public override void OpenConnection()
        {
            Retry.Do(() =>
                {
                    UdpClient.Connect((IPEndPoint) _udpConnectionSettings.EndPoint);
                },
                () =>
                {
                    UdpClient.Dispose();
                    UdpClient = new UdpClient();
                }, 3);
        }

        public override void Send(object data)
        {
            if (!(data is byte[] byteArrayData)) return;
            UdpClient.Send(byteArrayData, byteArrayData.Length);
        }

        public override object Receive()
        {
            byte[] data = UdpClient.Receive(ref IpEndPoint);
            OnDataReceived(new DataReceivedEventArgs(data));
            return data;
        }

        public override void Dispose()
        {
            UdpClient.Dispose();
        }

        public override void ClearBuffer()
        {
            byte[] data = new byte[UdpClient.Available];
            UdpClient.Client.Receive(data, data.Length, SocketFlags.None);
            
        }
    }
}