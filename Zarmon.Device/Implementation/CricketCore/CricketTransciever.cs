using System;
using System.Net;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.CricketTransciever;
using Zarmon.Device.Core;
using Zarmon.Device.Logics.Monitor.Core;
using Zarmon.Device.Logics.Monitor.Cricket;
using Zarmon.Device.Logics.Monitor.General.Ping;

namespace Zarmon.Device.Implementation.CricketCore
{
    public class CricketTransciever : ControlledDevice
    {

        public CricketTransciever(CricketTranscieverSettings deviceSettings) : base(deviceSettings)
        {
        }

        public override void ConfigureDeviceApis()
        {
            foreach (var connection in Connections)
            {
                if (connection.ConnectionSettings.EndPoint is IPEndPoint iPEndPoint)
                {
                    switch (iPEndPoint.Port)
                    {
                        case 35005:
                            ApiManager.AddApi(new CricketTranscieverApi(connection, new CricketTransceiverSyntax()));
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                }
            }
        }
        
        public override void ConfigureDeviceLogics()
        {
            LogicManager.AddLogic(new CricketTranscieverMonitor(new MonitorSettings(), ApiManager.GetApi<CricketTranscieverApi>()));
            LogicManager.AddLogic(new PingMonitor(new PingMonitorSettings() { IPAddress = IPAddress.Loopback}, ApiManager.GetApi<CricketTranscieverApi>()));
        }
    }
}