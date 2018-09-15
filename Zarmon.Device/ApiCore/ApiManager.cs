using System.Collections.Generic;
using System.Linq;
using Zarmon.Device.ApiCore.Core;

namespace Zarmon.Device.ApiCore
{
    public class ApiManager
    {
        public HashSet<IApi> Apis { get; }

        public ApiManager()
        {
            Apis = new HashSet<IApi>();
        }

        public TApi GetApi<TApi>() where TApi : IApi
        {
            foreach (var api in Apis)
            {
                if (api is TApi ap)
                    return ap;
            }
            return default(TApi);
        }

        public IApi GetApi(string apiName)
        {
            return Apis.FirstOrDefault(api => api.GetType().Name == apiName);
        }

        public void AddApi(IApi api)
        {
            Apis.Add(api);
        }
    }
}