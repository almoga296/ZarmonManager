using System.Collections.Generic;
using Zarmon.Connection.Core.Generic;
using Zarmon.Device.ApiCore;
using Zarmon.Device.Logics;

namespace Zarmon.Device.Core.Interfaces
{
    public interface IControlledDevice : IDevice
    {
        ICollection<IConnection> Connections { get; set; }
        ApiManager ApiManager { get; set; }
        LogicManager LogicManager { get; set; }
    }
}