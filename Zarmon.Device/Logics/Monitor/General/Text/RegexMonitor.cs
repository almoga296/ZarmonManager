using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.Logics.Monitor.Core;

namespace Zarmon.Device.Logics.Monitor.General.Text
{
    public class RegexMonitor : MonitorLogic
    {

        public RegexMonitor(MonitorSettings monitorSettings) : base(monitorSettings)
        {
        }

        public RegexMonitor(MonitorSettings monitorSettings, params IApi[] apis) : base(monitorSettings, apis)
        {
        }

        protected override void Prepare()
        {
            throw new System.NotImplementedException();
        }

        protected override MonitorResult Action()
        {
            throw new System.NotImplementedException();
        }

        protected override void Release()
        {
            throw new System.NotImplementedException();
        }
    }
}