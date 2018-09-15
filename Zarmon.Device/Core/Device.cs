using Zarmon.Device.Core.Interfaces;

namespace Zarmon.Device.Core
{
    public abstract class Device : IDevice
    {
        public ControlledDeviceSettings DeviceSettings { get; set; }

        protected Device()
        {
            
        }
        protected Device(ControlledDeviceSettings deviceSettings)
        {
            DeviceSettings = deviceSettings;
        }
    }
}