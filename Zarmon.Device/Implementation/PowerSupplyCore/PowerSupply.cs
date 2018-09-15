using System.Collections.Generic;
using Zarmon.Connection.Core.Generic;
using Zarmon.Device.Core;

namespace Zarmon.Device.Implementation.PowerSupplyCore
{
    public abstract class PowerSupply : ControlledDevice
    {
        #region C'tors

        public PowerSupply(PowerSupplySettings powerSupplySettings, ICollection<IConnection> connections = null) : base(powerSupplySettings,connections)
        {
        }

        #endregion

        //protected override void PreConfigureApis()
        //{
        //    //TcpConnection tcpConnection = new TcpConnection(PowerSupplySettings.ConnectionSettings);
        //    //tcpConnection.OpenConnection();
        //    //Apis.Add(tcpConnection.ConnectionSettings.EndPoint , new PowerSupplyApi(tcpConnection,new ScpiSyntax()));
        //}

        //protected override void PreConfigureLogics()
        //{
        //    //Logics.Add(new PingMonitor(new MonitorSettings()));

        //    //PowerSupplyApi powerSupplyApi = GetApi<PowerSupplyApi>(ControlledDeviceSettings.ConnectionSettings.EndPoint);
        //    //PowerSupplyControlLogic powerSupplyControlLogic = new PowerSupplyControlLogic(powerSupplyApi);
        //    //Logics.Add(powerSupplyControlLogic);
        //}

    }
}