using System;

namespace Zarmon.Connection.Core.Generic
{
    public class DataReceivedEventArgs : EventArgs
    {
        public object Data { get; set; }

        public DataReceivedEventArgs(object data)
        {
            Data = data;
        }
    }
}