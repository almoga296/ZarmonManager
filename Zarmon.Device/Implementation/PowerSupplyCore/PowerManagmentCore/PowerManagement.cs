using System;
using System.Net;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.PowerSupply.PowerManagment;
using Zarmon.Device.Logics.Control.PowerManagement;
using Zarmon.Device.Logics.Control.PowerSupply;

namespace Zarmon.Device.Implementation.PowerSupplyCore.PowerManagmentCore
{
    public class PowerManagement : PowerSupply
    {
        public PowerManagement(PowerManagementSettings settings) : base(settings)
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
                        case 5025:
                            ApiManager.AddApi(new PowerManagementApi(connection, new PowerManagementSyntax()));
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                }
            }
        }
        public override void ConfigureDeviceLogics()
        {
            LogicManager.AddLogic(new PowerManagementControlLogic(new PowerSupplyControlSettings(),ApiManager.GetApi<PowerManagementApi>()));
        }
    }
}