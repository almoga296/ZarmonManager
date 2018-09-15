using Zarmon.Device.ApiCore.Rubidium.Models;

namespace Zarmon.Device.Logics.Control.Rubidium
{
    public interface IRubidium
    {
        BitReportModel GetBitReport();
        SetupReportModel GetSetupReport();
        TimeReportModel GetTimeReport();
    }
}