using System;
using System.Threading;
using Zarmon.Connection.Core.Generic;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.CricketTransciever.Models;
using Zarmon.Device.ApiCore.Transceiver;
using Zarmon.Device.Implementation.CricketCore;
using Zarmon.Device.SyntaxCore.Core;
using Zarmon.Device.SyntaxCore.Core.Generic;

namespace Zarmon.Device.ApiCore.CricketTransciever
{
    public class CricketTranscieverApi : TransceiverApi
    {
        private readonly CricketTransceiverSyntax _syntax;

        public CricketTranscieverApi(IConnection connection, CricketTransceiverSyntax cricketTransceiverSyntax) : base(connection, cricketTransceiverSyntax)
        {
            _syntax = cricketTransceiverSyntax;
        }

        public override void StartListen(EventHandler<DataReceivedEventArgs> eventHandler, CancellationToken token)
        {
            base.StartListen(EventHandler, token);

            void EventHandler(object sender, DataReceivedEventArgs dataReceivedEventArgs)
            {
                Command<CricketLogModel> command = _syntax.GET_RECEIVED_DATA;
                CricketLogModel cricketLogModel =  command.Parser(dataReceivedEventArgs.Data);
                eventHandler.Invoke(sender, new DataReceivedEventArgs(cricketLogModel));
            }
        }


    }
}