using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Serilog;
using Zarmon.Connection.Core.Generic;
using DataReceivedEventArgs = Zarmon.Connection.Core.Generic.DataReceivedEventArgs;

namespace Zarmon.Connection.Extensions
{
    public static class ConnectionExtensions
    {
        public static void Listen(this IConnection connection, EventHandler<DataReceivedEventArgs> eventHandler, CancellationToken token)
        {
            connection.DataReceived += eventHandler;

            while (!token.IsCancellationRequested)
                connection.Receive();

            Log.Information("Got stop listen - by given token");
            connection.DataReceived -= eventHandler;
        }

        public static IConnection Execute(this IConnection connection, object command)
        {
            connection.Send(command);
            return connection;
        }

        //public static IConnection Execute(this IConnection connection, object data)
        //{
        //    command += connection.ConnectionSettings.OutgoingEndLineChar;
        //    connection.Send(Encoding.ASCII.GetBytes(command));
        //    return connection;
        //}

        public static string WaitForResponse(this IConnection connection, string ack, TimeSpan samplingRate = default(TimeSpan), TimeSpan timeout = default (TimeSpan))
        {
            //If not given set sampling rate default value to 1ms
            if (samplingRate == default(TimeSpan))
                samplingRate = TimeSpan.FromMilliseconds(1);
            
            //If not given set timeout default value to 3sec
            if (timeout == default(TimeSpan))
                timeout = TimeSpan.FromSeconds(3);

            byte[] ackBytes = Encoding.ASCII.GetBytes(ack);

            //Timer timer = new Timer(timeout.TotalMilliseconds);
            Stopwatch stopwatch = Stopwatch.StartNew();
            StringBuilder stringBuilder = new StringBuilder();
            while (stopwatch.Elapsed < timeout)
            {
                object receivedData = connection.Receive();
                string received = Encoding.ASCII.GetString(receivedData as byte[] ?? throw new InvalidOperationException());
                stringBuilder.Append(received);
                if (received.Contains(ack))
                    return stringBuilder.ToString();
                Thread.Sleep(samplingRate);
            }
            stopwatch.Stop();
            return "OK";
            if (stopwatch.Elapsed > timeout)
            {
                throw new TimeoutException($"Timeout occurred in {connection.GetType().Name}, Timeout value: {timeout}");
            }
            return string.Empty;
        }

    }
}