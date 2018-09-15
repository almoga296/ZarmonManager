namespace Zarmon.Device.ApiCore.TplBooster.Models
{
    public class BoosterStatusModel
    {
        public double Vswr { get; set; }
        public double ReflectedPower { get; set; }
        public double ForwardPower { get; set; }

        public BoosterStatusModel()
        {

        }
    }
}