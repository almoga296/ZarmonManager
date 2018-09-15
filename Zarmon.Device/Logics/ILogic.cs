using System.Collections.Generic;
using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;

namespace Zarmon.Device.Logics
{
    public interface ILogic
    {
        HashSet<IApi> Apis { get; set; }
        void AddApi(IApi api); 
        TApi GetApi<TApi>() where TApi : IApi;

    }
}