using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Serilog;
using Zarmon.Connection.Core.Generic;
using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.Core.Interfaces;
using Zarmon.Device.Logics;
using Zarmon.Device.Logics.Monitor.Core;

namespace Zarmon.Device.Core
{
    public abstract class ControlledDevice : Device, IControlledDevice ,IMonitorManager
    {

        #region Data Members

        protected CancellationTokenSource GlobalMonitorCancellationTokenSource { get; set; }
        public ICollection<IConnection> Connections { get; set; }
        public ApiManager ApiManager { get; set; }
        public LogicManager LogicManager { get; set; }

        #endregion

        #region Casting Helpers

        public ControlledDeviceSettings ControlledDeviceSettings => DeviceSettings as ControlledDeviceSettings;

        #endregion

        #region C'tors

        protected ControlledDevice(ControlledDeviceSettings controlledDeviceSettings, ICollection<IConnection> connections = null) : base(controlledDeviceSettings)
        {
            Connections = connections ?? new List<IConnection>();
            ApiManager = new ApiManager();
            LogicManager = new LogicManager();
            GlobalMonitorCancellationTokenSource = new CancellationTokenSource();
        }

        #endregion

        public void Init()
        {
            ConfigureDeviceApis();
            ConfigureDeviceLogics();

            //if (((ControlledDeviceSettings) DeviceSettings).ActivateMonitorMode)
            //    foreach (var logic in LogicManager.Logics)
            //        if (logic is MonitorLogic monitorLogic)
            //            monitorLogic.StartMonitor(GlobalMonitorCancellationTokenSource.Token);
        }

        #region IMonitorManager implementation

        public void StartAllMonitors()
        {
            GlobalMonitorCancellationTokenSource = new CancellationTokenSource();

            foreach (var logic in LogicManager.Logics)
                if (logic is MonitorLogic monitorLogic)
                    monitorLogic.StartMonitor(GlobalMonitorCancellationTokenSource.Token);
        }

        public void StartMonitor(MonitorLogic monitorLogic)
        {
            monitorLogic.StartMonitor(GlobalMonitorCancellationTokenSource.Token);
        }

        public void StopAllMonitors()
        {
            Log.Information("Stop all monitors at {@device}", GetType().Name);
            GlobalMonitorCancellationTokenSource.Cancel();
        }

        public void StopMonitor(MonitorLogic monitorLogic)
        {
            Log.Information("Stop {@monitor} {@device}", monitorLogic.GetType().Name, GetType().Name);
            monitorLogic.StopMonitor();
        }

        #endregion

        #region Abstract Methods

        public abstract void ConfigureDeviceApis();
        public abstract void ConfigureDeviceLogics();
        
        #endregion

        public object Execute(string commandName, object[] args)
        {
            foreach (var logic in LogicManager.Logics)
            {
                ;
                IEnumerable<MethodInfo> methodType = logic.GetType().GetMethods()?.Where(method =>
                    string.Equals(method.Name, commandName, StringComparison.InvariantCultureIgnoreCase) &&
                    method.GetParameters().Length == args.Length);

                if (methodType == null)
                    throw new NotImplementedException($"Command {commandName} not found in {this.GetType().Name}");

                if (methodType.Count() > 1)
                    throw new Exception();

                var returnedValue = methodType.FirstOrDefault().Invoke(this, args);
                return returnedValue;
            }
            return null;
        }

    }
}