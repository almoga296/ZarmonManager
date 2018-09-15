using System;
using System.Net;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.PowerSupply;
using Zarmon.Device.Implementation.PowerSupplyCore.ApcCore;
using Zarmon.Device.Implementation.PowerSupplyCore.PowerManagmentCore;

namespace Zarmon.Device.Implementation.PowerSupplyCore.TdkLambda
{
    public class TdkLambda : PowerManagement
    {
        private PowerManagementSettings _settings;
        public TdkLambda(PowerManagementSettings settings) : base(settings)
        {
            _settings = settings;
        }

        public override void ConfigureDeviceApis()
        {
            foreach (var connection in Connections)
            {
                if (connection.ConnectionSettings.EndPoint is IPEndPoint ipEndPoint)
                {
                    switch (ipEndPoint.Port)
                    {
                        case int port when (port < 4000 && port >= 4016):
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
            
        }
    }
}