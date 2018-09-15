using System;
using System.Threading;
using System.Threading.Tasks;
using Zarmon.Connection.Core.Generic;
using Zarmon.Connection.Extensions;
using Zarmon.Device.SyntaxCore.Core;
using Zarmon.Device.SyntaxCore.Core.Interfaces;

namespace Zarmon.Device.ApiCore.Core
{
    public abstract class Api : IApi
    {
        public IConnection Connection { get; set; }
        public ISyntax Syntax { get; set; }

        protected Api(IConnection connection, ISyntax syntax)
        {
            Connection = connection;
            Syntax = syntax;
        }

        public virtual void StartListen(EventHandler<DataReceivedEventArgs> eventHandler , CancellationToken token)
        {
            Task.Factory.StartNew(()=> Connection.Listen(eventHandler, token), token);
        }

        public void ClearConnectionBuffer()
        {
            Connection.ClearBuffer();
        }
    }
}