using Serilog;
using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.Rubidium;
using Zarmon.Device.ApiCore.Rubidium.Models;
using Zarmon.Device.Logics.Monitor.Core;

namespace Zarmon.Device.Logics.Monitor.Rubidium
{
    public class BitReportMonitor :MonitorLogic
    {
        public BitReportMonitor(MonitorSettings monitorSettings) : base(monitorSettings)
        {
        }

        public BitReportMonitor(MonitorSettings monitorSettings, params IApi[] apis) : base(monitorSettings, apis)
        {
        }

        protected override void Prepare()
        {
        }

        protected override MonitorResult Action()
        {
            BitReportModel bitReportModel = GetApi<RubidiumApi>().GetBitReport();
            Log.Debug("{@bitReport}", bitReportModel);
            return new MonitorResult();
        }

        protected override void Release()
        {
            throw new System.NotImplementedException();
        }
    }
}