using System;
using System.Collections.Generic;
using System.Xml.Xsl;
using Serilog;
using Zarmon.Connection.Core.Generic;
using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.CricketTransciever;
using Zarmon.Device.ApiCore.CricketTransciever.Models;
using Zarmon.Device.Logics.Monitor.Core;

namespace Zarmon.Device.Logics.Monitor.Cricket
{
    public class CricketTranscieverMonitor : MonitorLogic
    {
        private readonly CricketTranscieverApi _cricketTranscieverApi;
        private readonly Queue<CricketLogModel> _cricketLogsQueue;

        public CricketTranscieverMonitor(MonitorSettings monitorSettings) : base(monitorSettings)
        {
            _cricketLogsQueue = new Queue<CricketLogModel>();
        }

        public CricketTranscieverMonitor(MonitorSettings monitorSettings, CricketTranscieverApi cricketTranscieverApi) :
            base(monitorSettings, cricketTranscieverApi)
        {
            _cricketTranscieverApi = cricketTranscieverApi;
            _cricketLogsQueue = new Queue<CricketLogModel>();
        }

        protected override void Prepare()
        {
            _cricketLogsQueue.Clear();
            _cricketTranscieverApi.ClearConnectionBuffer();
            _cricketTranscieverApi.StartListen(EventHandler, CancellationTokenSource.Token);
        }

        private void EventHandler(object sender, DataReceivedEventArgs dataReceivedEventArgs)
        {
            _cricketLogsQueue.Enqueue(dataReceivedEventArgs.Data as CricketLogModel);
            Log.Debug("{@data}", dataReceivedEventArgs.Data);
        }

        protected override MonitorResult Action()
        {
            MonitorResult monitorResult = new MonitorResult {ResultState = ResultState.PASS};
            ICollection<CricketLogModel> errorLogs = new List<CricketLogModel>();
            //Clear and handle the queue
            while (_cricketLogsQueue.Count > 0)
            {
                var cricketLogModel = _cricketLogsQueue.Dequeue();
                if (cricketLogModel.Level == LogLevel.ALERT || cricketLogModel.Level == LogLevel.ERROR)
                {
                    monitorResult.ResultState = ResultState.FAIL;
                    errorLogs.Add(cricketLogModel);
                    Log.Error("Got error log: {@cricketErrorLog}", cricketLogModel);
                }
            }
            monitorResult.ReturnedObject = errorLogs;
            return monitorResult;
        }

        protected override void Release()
        {
        }
    }
}