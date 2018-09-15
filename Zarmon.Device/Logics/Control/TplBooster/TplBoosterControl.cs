using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.TplBooster;
using Zarmon.Device.ApiCore.TplBooster.Models;
using Zarmon.Device.Logics.Control.Core;

namespace Zarmon.Device.Logics.Control.TplBooster
{
    public class TplBoosterControl : ControlLogic
    {
        public TplBoosterControl(ControlSettings controlSettings) : base(controlSettings)
        {
        }

        public TplBoosterControl(ControlSettings controlSettings, params IApi[] apis) : base(controlSettings, apis)
        {
        }

        public BoosterStatusModel GetStatus()
        {
            return GetApi<TplBoosterApi>().GetConfiguration();
        }
    }
}
