using System;

namespace Zarmon.Connection.Core.Generic
{
    public interface IConnection : IDisposable
    {   
        ConnectionSettings ConnectionSettings { get; set; }
        event EventHandler<DataReceivedEventArgs> DataReceived;

        void OpenConnection();

        void Send(object data);
        object Receive();

        object Execute(object data);

        void ClearBuffer();
        //Task SendAsync(object data);
        //Task<object> ReceiveAsync();
    }
}