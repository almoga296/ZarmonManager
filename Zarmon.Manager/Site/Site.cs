using System;
using System.Collections.Generic;
using Serilog;
using Zarmon.Device.Core;

namespace Zarmon.Manager.Site
{
    public class Site
    {
        public string SiteName { get; set; }
        public IDictionary<Guid, ControlledDevice> Devices { get; set; }


        public Site(string siteName)
        {
            SiteName = siteName;
            Devices = new Dictionary<Guid, ControlledDevice>();
        }

        public Guid AddDeviceToSite(ControlledDevice device)
        {
            Guid deviceId = Guid.NewGuid();
            Devices.Add(deviceId, device);
            Log.Debug("Device {@device} added successfully to site: {@site}", device.GetType().Name, SiteName);
            return deviceId;
        }
    }
}