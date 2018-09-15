using System;
using System.Linq;
using System.Reflection;
using Zarmon.Connection.Core;
using Zarmon.Connection.Core.Generic;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.SyntaxCore;

namespace Zarmon.Device.ApiCore
{
    public static class ApiFactory
    {
        public static TApi CreateApi<TApi>(AvailableConnection availableConnectionType, ConnectionSettings connectionSettings, Syntax syntax, bool autoConnect = true) where TApi : IApi
        {
            //Create Connection settings
            Type apiType = Assembly.GetAssembly(typeof(TApi)).GetTypes()?.SingleOrDefault(type =>
                string.Equals(typeof(TApi).Name, type.Name,
                    StringComparison.InvariantCultureIgnoreCase));

            var connectionType = Assembly.GetAssembly(typeof(IConnection)).GetTypes().SingleOrDefault(type => string.Equals(availableConnectionType.ToString(), type.Name,
                StringComparison.InvariantCultureIgnoreCase));

            Type connectionSettingsType = connectionType?.GetConstructors()?.FirstOrDefault()?.GetParameters()
                ?.SingleOrDefault(param => param.Name.Contains("Settings"))?.ParameterType;

            var connectionSettingsInstance = (ConnectionSettings)Activator.CreateInstance(connectionSettingsType, connectionSettings.EndPoint);

            IConnection connection = (IConnection)Activator.CreateInstance(connectionType, connectionSettings);
            if (autoConnect)
                connection.OpenConnection();
            return (TApi)Activator.CreateInstance(apiType, connection, syntax);

        }

        public static IApi CreateApi(AvailableApi availableApi, AvailableConnection availableConnectionType, AvailableSyntax availableSyntax, ConnectionSettings connectionSettings,
            bool autoConnect = true)
        {
            Type apiType = Assembly.GetExecutingAssembly().GetTypes()?.SingleOrDefault(type =>
                string.Equals(availableApi.ToString(), type.Name,
                    StringComparison.InvariantCultureIgnoreCase));

            Type syntaxType = Assembly.GetExecutingAssembly().GetTypes()?.SingleOrDefault(type =>
                string.Equals(availableSyntax.ToString(), type.Name,
                    StringComparison.InvariantCultureIgnoreCase));

            Type connectionType = Assembly.GetAssembly(typeof(IConnection)).GetTypes().SingleOrDefault(type =>
                string.Equals(availableConnectionType.ToString(), type.Name,
                    StringComparison.InvariantCultureIgnoreCase));

            IConnection connection = (IConnection)Activator.CreateInstance(connectionType, connectionSettings);
            Syntax syntax = (Syntax)Activator.CreateInstance(syntaxType);

            if (autoConnect)
                connection.OpenConnection();
            return (IApi)Activator.CreateInstance(apiType, connection, syntax);
        }
    }
}


