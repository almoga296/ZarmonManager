using System;
using System.Net;
using Zarmon.Connection.Connections.Http;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.TplBooster;
using Zarmon.Device.Core;
using Zarmon.Device.Logics.Control.Core;
using Zarmon.Device.Logics.Control.TplBooster;
using Zarmon.Device.Logics.Monitor.General.Ping;
using Zarmon.Device.Logics.Monitor.TplBooster;

namespace Zarmon.Device.Implementation.TplBoosterCore
{
    public class TplBooster : ControlledDevice
    {

        public TplBooster(TplBoosterSettings tplBoosterSettings) : base(tplBoosterSettings)
        {
        }

        public override void ConfigureDeviceApis()
        {
            foreach (var connection in Connections)
            {
                if (connection.ConnectionSettings.EndPoint is UriEndPoint uriEndPoint)
                {
                    switch (uriEndPoint.Uri.AbsolutePath)
                    {
                        case "/api/booster":
                            ApiManager.AddApi(new TplBoosterApi(connection, new TplBoosterSyntax()));
                            break;
                        default:
                            throw new NotSupportedException();
                            
                    }
                }
            }
        }

        public override void ConfigureDeviceLogics()
        {
            LogicManager.AddLogic(new TplBoosterControl(new ControlSettings(), ApiManager.GetApi<TplBoosterApi>()));
            LogicManager.AddLogic(new TplBoosterMonitor(new Logics.Monitor.Core.MonitorSettings(),ApiManager.GetApi<TplBoosterApi>()));
            LogicManager.AddLogic(new PingMonitor(new PingMonitorSettings() { IPAddress = IPAddress.Loopback }, ApiManager.GetApi<TplBoosterApi>()));
        }
    }
}