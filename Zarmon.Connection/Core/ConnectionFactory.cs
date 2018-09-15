using System;
using System.Linq;
using System.Reflection;
using Serilog;
using Zarmon.Connection.Core.Generic;

namespace Zarmon.Connection.Core
{
    public static class ConnectionFactory
    {
        public static IConnection CreateConnection(AvailableConnection availableConnection,
            ConnectionSettings connectionSettings)
        {
            Type connectionType = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(connection => string.Equals(connection.Name,
                availableConnection.ToString(), StringComparison.InvariantCultureIgnoreCase));
            if (connectionType == null)
            {
                Log.Error("Connection: {@ConnectionType} doesn't exist in implementation list array", availableConnection.ToString());
                throw new NotImplementedException($"Connection: {availableConnection.ToString()} doesn't exist in implementation list array");
            }
            return (IConnection)Activator.CreateInstance(connectionType, connectionSettings);

        }

        public static TConnection CreateConnection<TConnection>(ConnectionSettings connectionSettings) where TConnection : IConnection
        {
            Type connectionType = typeof(TConnection);
            return (TConnection)Activator.CreateInstance(connectionType, connectionSettings);
        }
    }
}