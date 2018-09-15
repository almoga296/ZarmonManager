using System;
using System.Net.Http;
using System.Threading.Tasks;
using Zarmon.Connection.Core;
using Zarmon.Connection.Core.Generic;

namespace Zarmon.Connection.Connections.Http
{
    public class HttpConnection : Core.Connection
    {
        protected HttpClient HttpClient;
        private Task<HttpResponseMessage> _responseTask;

        public HttpConnection(ConnectionSettings connectionSettings) : base(connectionSettings)
        {
            HttpClient = new HttpClient();
            
        }

        public override void OpenConnection()
        {
            HttpClient.BaseAddress = (ConnectionSettings.EndPoint as UriEndPoint)?.Uri;
        }

        public override void Send(object data)
        {
            if (data is HttpRequestMessage httpRequestMessage)
            {
                _responseTask = HttpClient.SendAsync(httpRequestMessage);
            }
            else
            {
                throw new NotSupportedException($"data type: {data.GetType().Name} not supported");
            }

        }

        public override object Receive()
        {
            HttpResponseMessage response = _responseTask.Result;
            OnDataReceived(new DataReceivedEventArgs(response));
            return response;
        }

        //public override Task SendAsync(object data)
        //{
        //    if (data is HttpRequestMessage httpRequestMessage)
        //    {
        //        return HttpClient.SendAsync(httpRequestMessage);
        //    }
        //    throw new NotSupportedException($"data type: {data.GetType().Name} not supported");
        //}

        //public override Task<object> ReceiveAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public override void Dispose()
        {
            HttpClient.Dispose();
        }

        public override void ClearBuffer()
        {
        }
    }
}