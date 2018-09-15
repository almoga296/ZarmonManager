using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.TplBooster.Models;

namespace Zarmon.Device.ApiCore.TplBooster
{
    public interface IBoosterApi : IApi
    {
        BoosterStatusModel GetConfiguration();
    }
}