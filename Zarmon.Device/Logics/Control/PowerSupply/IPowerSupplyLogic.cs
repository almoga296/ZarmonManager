namespace Zarmon.Device.Logics.Control.PowerSupply
{
    public interface IPowerSupplyLogic
    {
        bool TurnOn(ushort channel);
        bool TurnOff(ushort channel);
    }
}