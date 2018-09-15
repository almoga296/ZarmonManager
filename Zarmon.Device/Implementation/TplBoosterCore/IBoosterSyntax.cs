using Zarmon.Device.ApiCore.TplBooster.Models;
using Zarmon.Device.SyntaxCore.Core;
using Zarmon.Device.SyntaxCore.Core.Generic;
using Zarmon.Device.SyntaxCore.Core.Interfaces;

namespace Zarmon.Device.Implementation.TplBoosterCore
{
    internal interface IBoosterSyntax : ISyntax
    {
        Command<BoosterStatusModel> GET_STATUS();
    }
}