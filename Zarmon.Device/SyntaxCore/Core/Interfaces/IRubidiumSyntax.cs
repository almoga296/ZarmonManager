using Zarmon.Device.ApiCore.Rubidium.Models;
using Zarmon.Device.SyntaxCore.Core.Generic;

namespace Zarmon.Device.SyntaxCore.Core.Interfaces
{
    public interface IRubidiumSyntax : ISyntax
    {
        Command<TimeReportModel> GET_TIME_REPORT();
        Command<SetupReportModel> GET_SYSTEM_REPORT();
        Command<BitReportModel> GET_BIT_REPORT();
    }
}
