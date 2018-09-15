using Zarmon.Connection.Core.Generic;
using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.Logics.Monitor.Core;

namespace Zarmon.Device.Logics.Monitor.General.Text
{
    public class SevirityMonitor : MonitorLogic
    {

        public SevirityMonitor(MonitorSettings monitorSettings) : base(monitorSettings)
        {
        }

        public SevirityMonitor(MonitorSettings monitorSettings, params IApi[] apis) : base(monitorSettings, apis)
        {
        }

        protected override void Prepare()
        {
            foreach (var api in Apis)
            {
                api.Connection.DataReceived += Connection_DataReceived;        
            }
        }

        protected override MonitorResult Action()
        {
            return new MonitorResult();
        }

        protected override void Release()
        {
            foreach (var api in Apis)
            {
                api.Connection.DataReceived -= Connection_DataReceived;
            }
        }

        private void Connection_DataReceived(object sender, DataReceivedEventArgs eventArgs)
        {
            throw new System.NotImplementedException();
        }

    }
}