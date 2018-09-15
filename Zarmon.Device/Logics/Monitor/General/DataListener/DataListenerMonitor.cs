using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.Logics.Monitor.Core;

namespace Zarmon.Device.Logics.Monitor.General.DataListener
{
    public class DataListenerMonitor : MonitorLogic
    {
        public DataListenerMonitor(MonitorSettings monitorSettings) : base(monitorSettings)
        {
        }

        public DataListenerMonitor(MonitorSettings monitorSettings, params IApi[] apis) : base(monitorSettings, apis)
        {
        }

        protected override void Prepare()
        {
        }

        protected override MonitorResult Action()
        {
            //foreach (var api in Apis)
            //{
            //    Log.Debug("Monitor: {name}, returned: {@Result}",this.GetType().Name, api.Connection.WaitForResponse("").Replace(Environment.NewLine," "));
            //}
            return new MonitorResult();
        }

        protected override void Release()
        {
            throw new System.NotImplementedException();
        }
    }
}