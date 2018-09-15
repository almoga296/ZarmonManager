using System;
using Zarmon.Connection.Core.Generic;

namespace Zarmon.Connection.Core
{
    public abstract class Connection : IConnection
    {
        public ConnectionSettings ConnectionSettings { get; set; }
        public event EventHandler<DataReceivedEventArgs> DataReceived;
        private readonly object _lock = new object();

        public abstract void OpenConnection();
        public abstract void Send(object data);
        public abstract object Receive();
        public abstract void ClearBuffer();
        //public abstract Task SendAsync(object data);
        //public abstract Task<object> ReceiveAsync();

        protected Connection(ConnectionSettings connectionSettings)
        {
            ConnectionSettings = connectionSettings;
        }
        
        public abstract void Dispose();

        #region Events Handlers

        protected virtual void OnDataReceived(DataReceivedEventArgs e)
        {
            DataReceived?.Invoke(this, e);
        }

        public object Execute(object data)
        {
            lock (_lock)
            {
                Send(data);
                return Receive();
            }
                    
        }

        

        #endregion

    }
}