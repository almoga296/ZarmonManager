using Zarmon.Connection.Core.Generic;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.SyntaxCore.Core;
using Zarmon.Device.SyntaxCore.Core.Interfaces;

namespace Zarmon.Device.ApiCore.Transceiver
{
    public class TransceiverApi : Api, ITransceiverApi
    {
        public TransceiverApi(IConnection connection, ISyntax syntax) : base(connection, syntax)
        {
        }

        public void Transmit(byte[] data)
        {
            Connection.Send(data);
        }

        public byte[] Receive()
        {
            return (byte[])Connection.Receive();
        }
    }
}