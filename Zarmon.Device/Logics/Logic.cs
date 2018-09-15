using System.Collections.Generic;
using System.Linq;
using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;

namespace Zarmon.Device.Logics
{
    public abstract class Logic : ILogic
    {
        public HashSet<IApi> Apis { get; set; }
        public LogicSettings LogicSettings { get; set; }

        protected Logic(LogicSettings logicSettings)
        {
            Apis = new HashSet<IApi>();
            LogicSettings = logicSettings;
        }

        protected Logic(LogicSettings logicSettings, params IApi[] apis)
        {
            Apis = new HashSet<IApi>(apis);
            LogicSettings = logicSettings;
        }

        public void AddApi(IApi api)
        {
            Apis.Add(api);
        }

        public TApi GetApi<TApi>() where TApi : IApi
        {
            foreach (var api in Apis)
                if (api is TApi ap)
                    return ap;

            return default(TApi);
        }

    }
}