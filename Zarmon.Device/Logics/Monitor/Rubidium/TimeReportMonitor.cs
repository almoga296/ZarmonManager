using Serilog;
using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.Rubidium;
using Zarmon.Device.ApiCore.Rubidium.Models;
using Zarmon.Device.Logics.Monitor.Core;

namespace Zarmon.Device.Logics.Monitor.Rubidium
{
    public class TimeReportMonitor :MonitorLogic
    {
        public TimeReportMonitor(MonitorSettings monitorSettings) : base(monitorSettings)
        {
        }

        public TimeReportMonitor(MonitorSettings monitorSettings, params IApi[] apis) : base(monitorSettings, apis)
        {
        }

        protected override void Prepare()
        {
        }

        protected override MonitorResult Action()
        {
            TimeReportModel timeReportModel = GetApi<RubidiumApi>().GetTimeReport();
            Log.Debug("{@bitReport}",timeReportModel);
            return new MonitorResult();
        }

        protected override void Release()
        {
            throw new System.NotImplementedException();
        }
    }
}