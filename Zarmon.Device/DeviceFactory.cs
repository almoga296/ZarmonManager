using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using Zarmon.Connection.Core;
using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.Core;
using Zarmon.Device.Logics;
using Zarmon.Device.SyntaxCore;

namespace Zarmon.Device
{
    /// <summary>
    /// Used to create instances of device, Abstract Factory Design Pattern
    /// </summary>
    public static class DeviceFactory
    {

        public static TDevice CreateDevice<TDevice>(ConnectionSettings connectionSettings ,ControlledDeviceSettings deviceSettings, ICollection<Logic> deviveLogics, bool useDefaultLogics = true) where TDevice : ControlledDevice
        {
            Type deviceType = Assembly.GetExecutingAssembly().GetTypes().Single(type => type.Name == typeof(TDevice).Name);
            TDevice device = (TDevice) Activator.CreateInstance(deviceType, deviceSettings);
            foreach (var deviveLogic in deviveLogics)
                device.LogicManager.AddLogic(deviveLogic);
            return device;
        }

        public static ControlledDevice CreateDevice(AvailableDeviceType availableDeviceType, List<(AvailableApi, AvailableConnection, AvailableSyntax, ConnectionSettings)> ce, bool useDefaultLogics = true , ICollection<Logic> deviveLogics = null , ControlledDeviceSettings deviceSettings = null)
        {
            Type deviceType = Assembly.GetExecutingAssembly().GetTypes().Single(type => type.Name == availableDeviceType.ToString());
            if (deviceSettings == null)
            {   
                var settingsType = ExtractSettingsFromConstructor(deviceType);
                deviceSettings = (ControlledDeviceSettings)Activator.CreateInstance(settingsType);
            }
            var device = (ControlledDevice)Activator.CreateInstance(deviceType, deviceSettings);
            //Connect to all given apis
            foreach (var valueTuple in ce)
            {
                device.ApiManager.AddApi(ApiFactory.CreateApi(valueTuple.Item1, valueTuple.Item2,valueTuple.Item3, valueTuple.Item4));
            }

            if (useDefaultLogics)
            {
                //add default logics
                //var defaultLogics = device.DefaultLogics();
                //foreach (Type defaultLogic in defaultLogics)
                //{
                //    var logic = CreateLogic(defaultLogic, device.ApiManager);
                //    device.LogicManager.AddLogic(logic);
                //}
            }
            return device;
        }

        

        public static void CreateDefaultDevice(AvailableDeviceType powerSupply, Dictionary<EndPoint, AvailableApi> connectionApis)
        {
            foreach (var connectioApi in connectionApis)
            {
                //ApiFactory.ConfigureDeviceApis(connectioApi.Value,)

            }
        }

        #region Help Methods

        private static ILogic CreateLogic(Type logicType, ApiManager apiManager, LogicSettings logicSettings = null, bool useDefaultApis = true, params IApi[] apis)
        {
            if (logicSettings == null)
            {
                var settingsType = ExtractSettingsFromConstructor(logicType);
                logicSettings = (LogicSettings)Activator.CreateInstance(settingsType);
            }
            ILogic logic = (ILogic)Activator.CreateInstance(logicType, logicSettings, apis);

            if (useDefaultApis)
            {
                //var defaultApis = logic.RequiredApis();
                //foreach (Type defaultApi in defaultApis)
                //{
                //    logic.AddApi(apiManager.GetApi(defaultApi.Name));
                //} 
            }
            return logic;
        }

        public static Type ExtractSettingsFromConstructor(Type objectType)
        {
            ConstructorInfo[] constructorsInfo = objectType.GetConstructors();
            foreach (var constructorInfo in constructorsInfo)
            {
                ParameterInfo parameterInfo = constructorInfo.GetParameters().FirstOrDefault(param => param.Name.Contains("Settings"));
                if (parameterInfo != null)
                    return parameterInfo.ParameterType;
            }
            return null;

        }
        
        #endregion
    }

}