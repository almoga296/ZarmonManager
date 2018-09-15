using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.Rubidium.Models;

namespace Zarmon.Device.ApiCore.Rubidium
{
    public interface IRubidiumApi : IApi
    {
        BitReportModel GetBitReport();
        TimeReportModel GetTimeReport();
        SetupReportModel GetSystemReport();
    }
}