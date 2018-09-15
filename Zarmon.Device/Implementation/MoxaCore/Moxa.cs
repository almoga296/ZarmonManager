using System;
using System.Collections.Generic;
using System.Net;
using Connection.Core.Generic;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.PowerSupply.PowerManagment;
using Zarmon.Device.Core;
using Zarmon.Device.Implementation.PowerSupplyCore.PowerManagmentCore;

namespace Zarmon.Device.Implementation.MoxaCore
{
    public class Moxa : ControlledDevice
    {
        public Moxa(MoxaSettings controlledDeviceSettings, ICollection<IConnection> connections = null) : base(controlledDeviceSettings, connections)
        {
        }

        public override IApi ConfigureDeviceApis(IConnection connection)
        {
            if (connection.ConnectionSettings.EndPoint is IPEndPoint ipEndPoint)
            {
                switch (ipEndPoint.Port)
                {
                    case 4001:
                        return new PowerManagementApi(connection, new PowerManagementSyntax());
                    case 4002:
                        return new PowerManagementApi(connection, new PowerManagementSyntax());
                    case 4003:
                        return new PowerManagementApi(connection, new PowerManagementSyntax());
                    default:
                        break;
                }
            }
            throw new NotSupportedException();
        }

        public override void ConfigureLogics()
        {
            throw new NotImplementedException();
        }
    }
}
