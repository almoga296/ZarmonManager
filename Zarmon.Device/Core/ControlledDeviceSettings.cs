namespace Zarmon.Device.Core
{
    public abstract class ControlledDeviceSettings : DeviceSettings
    {
        public bool ResetOnConnect { get; set; } = false;
        public bool ActivateMonitorMode { get; set; } = true;
        public bool ActivateControlMode { get; set; } = true;

        protected ControlledDeviceSettings()
        {
        }
    }
}