using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Zarmon.Connection.Core.Generic;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.PowerSupply;
using Zarmon.Device.Logics.Control.PowerSupply;
using Zarmon.Device.Logics.Monitor.General.Ping;
using Zarmon.Device.Logics.Monitor.PowerSupply.State;

namespace Zarmon.Device.Implementation.PowerSupplyCore.ApcCore
{
    public class Apc7920B : PowerSupply
    {
        public Apc7920B(PowerSupplySettings powerSupplySettings, ICollection<IConnection> connections = null) : base(powerSupplySettings, connections)
        {
        }

        public override void ConfigureDeviceApis()
        {
            foreach (var connection in Connections)
            {
                if (connection.ConnectionSettings.EndPoint is IPEndPoint ipEndPoint)
                {
                    switch (ipEndPoint.Port)
                    {
                        case 23:
                            ApiManager.AddApi(new PowerSupplyApi(connection, new Apc7920bSyntax()));
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                }
            }
        }

        public override void ConfigureDeviceLogics()
        {
            LogicManager.AddLogic(new PowerSupplyControlLogic(new PowerSupplyControlSettings(), ApiManager.GetApi<PowerSupplyApi>()));
            LogicManager.AddLogic(new PowerStateMonitor(new PowerStateMonitorSettings() { Channel = 1, ExpectedState = true, SamplingRate = TimeSpan.FromSeconds(1)}, ApiManager.GetApi<PowerSupplyApi>()));
            LogicManager.AddLogic(new PingMonitor(new PingMonitorSettings() { IPAddress = IPAddress.Loopback }, ApiManager.GetApi<PowerSupplyApi>()));
        }
    }
}
