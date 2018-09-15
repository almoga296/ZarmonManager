namespace Zarmon.Device.Implementation.PowerSupplyCore.PowerManagmentCore
{
    public class PowerManagementSettings : PowerSupplySettings
    {
        public short OverVoltageProtection { get; set; } = 12;
        public short OverCurrentProtection { get; set; } = 1;
    }
}