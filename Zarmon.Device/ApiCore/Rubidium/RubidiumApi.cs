using Zarmon.Connection.Core.Generic;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.Rubidium.Models;
using Zarmon.Device.Implementation.RubidiumCore;
using Zarmon.Device.SyntaxCore.Core.Generic;

namespace Zarmon.Device.ApiCore.Rubidium
{
    public class RubidiumApi : Api , IRubidiumApi
    {
        private RubidiumSyntax _rubidiumSyntax;

        public RubidiumApi(IConnection connection, RubidiumSyntax rubidiumSyntax) : base(connection, rubidiumSyntax)
        {
            _rubidiumSyntax = rubidiumSyntax;
        }

        public BitReportModel GetBitReport()
        {
            Command<BitReportModel> command = _rubidiumSyntax.GET_BIT_REPORT;
            var response = Connection.Execute(command.Builder());
            return command.Parser(response);
        }

        public SetupReportModel GetSystemReport()
        {
            Command<SetupReportModel> command = _rubidiumSyntax.GET_SETUP_REPORT;
            var response = Connection.Execute(command.Builder());
            return command.Parser(response);
        }

        public TimeReportModel GetTimeReport()
        {
            Command<TimeReportModel> command = _rubidiumSyntax.GET_TIME_REPORT;
            var response = Connection.Execute(command.Builder());
            return command.Parser(response);
        }

    }
}