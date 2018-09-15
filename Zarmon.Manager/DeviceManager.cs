using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Serilog;
using Zarmon.Device.Core;

namespace Zarmon.Manager
{
    public class DeviceManager
    {
        public IDictionary<Guid,ControlledDevice> Devices { get; set; }
        public ICollection<Zone> Zones { get; set; }

        public DeviceManager()
        {
            Devices = new ConcurrentDictionary<Guid, ControlledDevice>();
            Zones = new List<Zone>();
        }

        public Zone AddZone(string zoneName)
        {
            Zone zone = new Zone(zoneName);
            Zones.Add(zone);
            Log.Debug("Zone {@zone} added successfully", zoneName);
            return zone;
        }

        public void AddSiteToZone(Site.Site site, Zone zone)
        {
            zone.AddSite(site);
        }

        public Guid AddDevice(ControlledDevice device, bool autoInit = false)
        {
            if (autoInit)
                device?.Init();
            Guid deviceId = Guid.NewGuid();
            Devices.Add(deviceId, device);
            Log.Debug("Added new device: {@device}", device);
            return deviceId;
        }

        public bool RemoveDevice(Guid deviceId)
        {
            bool removeRes = Devices.Remove(deviceId);
            Log.Debug("Device: {@device} removed", deviceId);
            return removeRes;
        }

        public object SendCommand(Guid deviceId , string commandName, params object[] args)
        {
            return Devices[deviceId].Execute(commandName, args);
        }
    }
}