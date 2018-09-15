using System.Reflection;
using Serilog;
using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Rubidium;
using Zarmon.Device.ApiCore.Rubidium.Models;
using Zarmon.Device.Logics.Control.Core;

namespace Zarmon.Device.Logics.Control.Rubidium
{
    public class RubidiumControlLogic : ControlLogic, IRubidium
    {
        private readonly RubidiumApi _rubidiumApi;

        public RubidiumControlLogic(RubidiumControlSettings logicSettings) : base(logicSettings)
        {
        }

        public RubidiumControlLogic(ControlSettings controlSettings, RubidiumApi rubidiumApi) : base(controlSettings, rubidiumApi)
        {
            _rubidiumApi = rubidiumApi;
        }

        public BitReportModel GetBitReport()
        {
            Log.Debug($"Enter method {MethodBase.GetCurrentMethod().Name}");
            BitReportModel bitReportModel = _rubidiumApi.GetBitReport();
            //bool outputState = ApiManager.GetApi<IPowerSupplyApi>().GetOutputState(channel);
            //PowerStateValidator powerStateValidator = new PowerStateValidator(expectedValue: true);
            //var res = powerStateValidator.Validate(outputState);
            return bitReportModel;
        }

        public SetupReportModel GetSetupReport()
        {
            throw new System.NotImplementedException();
        }

        public TimeReportModel GetTimeReport()
        {
            throw new System.NotImplementedException();
        }
    }
}