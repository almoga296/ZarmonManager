using System.IO.Ports;
using Zarmon.Connection.Core;

namespace Zarmon.Connection.Connections.Serial
{
    public class SerialConnection : Core.Connection
    {
        protected SerialPort SerialPort;

        public SerialConnection(ConnectionSettings connectionSettings) : base(connectionSettings)
        {
            SerialPort = new SerialPort();
        }

        public override void OpenConnection()
        {
            SerialConnectionSettings serialConnectionSettings = (SerialConnectionSettings) ConnectionSettings;
            //Set the serial connection settings
            SerialPort.BaudRate = serialConnectionSettings.BaudRate;
            SerialPort.DataBits = serialConnectionSettings.DataBits;
            SerialPort.Parity = serialConnectionSettings.Parity;
            SerialPort.PortName = serialConnectionSettings.EndPoint.ToString();
            SerialPort.StopBits = serialConnectionSettings.StopBits;
            //Open the serial connection
            SerialPort.Open();
        }

        public override void Send(object data)
        {
            if (!(data is byte[] byteArrayData)) return;
            if (byteArrayData.Length == 0)
                return;

            SerialPort.Write(byteArrayData, 0, byteArrayData.Length);
        }

        public override object Receive()
        {
            if (SerialPort.BytesToRead == 0)
                return new byte[] { };

            byte[] data = new byte[SerialPort.BytesToRead];
            SerialPort.BaseStream.Read(data, 0, data.Length);
            return data;
        }

        public override void Dispose()
        {
            SerialPort.Dispose();
        }

        public override void ClearBuffer()
        {
            SerialPort.DiscardInBuffer();
            SerialPort.DiscardOutBuffer();
        }
    }
}