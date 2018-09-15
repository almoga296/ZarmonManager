namespace Zarmon.Device.ApiCore.PowerSupply.PowerManagment
{
    public interface IPowerManagmentApi : IPowerSupplyApi
    {
        void SetVoltage(ushort channel, double voltage);
        double GetVoltage(ushort channel);
        void SetCurrentLimit(ushort channel, double currentLimit);
        void GetCurrentLimit(ushort channel);
        double GetCurrent(ushort channel);
    }
}