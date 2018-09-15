using FluentValidation.Results;
using Serilog;
using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.TplBooster;
using Zarmon.Device.ApiCore.TplBooster.Models;
using Zarmon.Device.Logics.Monitor.Core;
using Zarmon.Device.Logics.Validation;

namespace Zarmon.Device.Logics.Monitor.TplBooster
{
    public class TplBoosterMonitor : MonitorLogic
    {
        private TplBoosterApi _tplBoosterApi;

        public TplBoosterMonitor(MonitorSettings monitorSettings) : base(monitorSettings)
        {
        }

        public TplBoosterMonitor(MonitorSettings monitorSettings, TplBoosterApi tplBoosterApi) : base(monitorSettings, tplBoosterApi)
        {
            _tplBoosterApi = tplBoosterApi;
        }

        protected override MonitorResult Action()
        {
            BoosterStatusModel boosterStatusModel = _tplBoosterApi.GetConfiguration();
            Log.Debug("{@boosterStatusModel}", boosterStatusModel);
            BoosterStatusValidator validator = new BoosterStatusValidator();

            ValidationResult validationResult =  validator.Validate(boosterStatusModel);
            if (validationResult.IsValid)
            {
                return new MonitorResult()
                {
                    ResultState = ResultState.PASS,
                    ReturnedObject = boosterStatusModel
                };
            }
            return new MonitorResult()
            {
                ResultState = ResultState.FAIL,
                ReturnedObject = boosterStatusModel
            };
        }

        protected override void Release()
        {
            throw new System.NotImplementedException();
        }

        protected override void Prepare()
        {
        }
    }
}
