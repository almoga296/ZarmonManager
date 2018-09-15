using System;
using System.Collections.Generic;
using System.Net;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.Rubidium;
using Zarmon.Device.Core;
using Zarmon.Device.Logics;
using Zarmon.Device.Logics.Control.Rubidium;
using Zarmon.Device.Logics.Monitor.Core;
using Zarmon.Device.Logics.Monitor.General.Ping;
using Zarmon.Device.Logics.Monitor.Rubidium;

namespace Zarmon.Device.Implementation.RubidiumCore
{
    public class Rubidium : ControlledDevice
    {
        public Rubidium(RubidiumSettings deviceSettings) : base(deviceSettings)
        {
        }

        public override void ConfigureDeviceApis()
        {
            foreach (var connection in Connections)
            {
                if (connection.ConnectionSettings.EndPoint is IPEndPoint ipEndPoint)
                    switch (ipEndPoint.Port)
                    {
                        case 5001:
                            ApiManager.AddApi(new RubidiumApi(connection, new RubidiumSyntax()));
                            break;
                        default:
                            throw new NotSupportedException();
                    }
            }
        }

        public override void ConfigureDeviceLogics()
        {
            LogicManager.AddLogic(new RubidiumControlLogic(new RubidiumControlSettings(),
                ApiManager.GetApi<RubidiumApi>()));
            LogicManager.AddLogic(new BitReportMonitor(new MonitorSettings(), ApiManager.GetApi<RubidiumApi>()));
            LogicManager.AddLogic(new TimeReportMonitor(new MonitorSettings(), ApiManager.GetApi<RubidiumApi>()));
            LogicManager.AddLogic(new SetupReportMonitor(new MonitorSettings(), ApiManager.GetApi<RubidiumApi>()));
            LogicManager.AddLogic(new PingMonitor(new PingMonitorSettings() {IPAddress = IPAddress.Loopback},
                ApiManager.GetApi<RubidiumApi>()));
        }
    }
}