using System.Net.Sockets;
using Zarmon.Common;
using Zarmon.Connection.Core.Generic;

namespace Zarmon.Connection.Connections.Tcp
{
    public class TcpConnection : Core.Connection
    {
        protected TcpClient TcpClient { get; set; }

        #region Casting Helpers

        private readonly TcpConnectionSettings _tcpConnectionSettings;

        #endregion

        public TcpConnection(TcpConnectionSettings tcpConnectionSettings) : base(tcpConnectionSettings)
        {
            _tcpConnectionSettings = tcpConnectionSettings;
            TcpClient = new TcpClient();
        }

        public override void OpenConnection()
        {
            Retry.Do(() =>
            {
                TcpClient.Connect(_tcpConnectionSettings.IpEndPoint);
            },
            () =>
            {
                TcpClient.Dispose();
                TcpClient = new TcpClient();
            },3);
        }

        public override void Send(object data)
        {
            if (!(data is byte[] byteArrayData)) return;
            TcpClient.GetStream().Write(byteArrayData, 0, byteArrayData.Length);
        }

        public override object Receive()
        {
            byte[] receivedData = new byte[TcpClient.ReceiveBufferSize];
            int byteRead = TcpClient.GetStream().Read(receivedData, 0, receivedData.Length);
            byte[] data = receivedData.SubArray(0, byteRead - ConnectionSettings.IncommingEndLineChar.Length);
            OnDataReceived(new DataReceivedEventArgs(data));
            return data;
        }

        public override void Dispose()
        {
            TcpClient.Dispose();
        }

        public override void ClearBuffer()
        {
            TcpClient.GetStream().Flush();
        }
    }
}


//public override Task SendAsync(object data)
//{
//    if (!(data is byte[] byteArrayData)) throw new NotSupportedException();
//    return TcpClient.GetStream().WriteAsync(byteArrayData, 0, byteArrayData.Length);
//}

//public override async Task<object> ReceiveAsync()
//{
//    byte[] dataToRead = new byte[TcpClient.Available];
//    await TcpClient.GetStream().ReadAsync(dataToRead, 0, dataToRead.Length);
//    return dataToRead;
//}