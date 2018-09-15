using System.Text;
using Zarmon.Device.ApiCore.Rubidium.Models;
using Zarmon.Device.SyntaxCore;
using Zarmon.Device.SyntaxCore.Core.Generic;

namespace Zarmon.Device.Implementation.RubidiumCore
{
    public class RubidiumSyntax : Syntax
    {
        public Command<TimeReportModel> GET_TIME_REPORT => new Command<TimeReportModel>
        {
            Builder = () => Encoding.ASCII.GetBytes("RTR"),
            Parser = (data) => TimeReportModel.Parse(Encoding.ASCII.GetString((byte[]) data))
        };

        public Command<SetupReportModel> GET_SETUP_REPORT => new Command<SetupReportModel>
        {
            Builder = () => Encoding.ASCII.GetBytes("RSR"),
            Parser = (data) => SetupReportModel.Parse(Encoding.ASCII.GetString((byte[]) data))
        };


        public Command<BitReportModel> GET_BIT_REPORT => new Command<BitReportModel>
        {
            Builder = () => Encoding.ASCII.GetBytes("RBR"),
            Parser = (data) => BitReportModel.Parse(Encoding.ASCII.GetString((byte[]) data))
        };
    }
}