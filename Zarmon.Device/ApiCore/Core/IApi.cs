using Zarmon.Connection.Core.Generic;
using Zarmon.Device.SyntaxCore.Core;
using Zarmon.Device.SyntaxCore.Core.Interfaces;

namespace Zarmon.Device.ApiCore.Core
{
    public interface IApi
    {
        IConnection Connection { get; set; }
        ISyntax Syntax { get; set; }
    }
}