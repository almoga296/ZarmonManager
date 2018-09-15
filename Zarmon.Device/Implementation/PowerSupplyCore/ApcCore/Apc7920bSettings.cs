using System;
using System.Collections.Generic;
using System.Text;

namespace Zarmon.Device.Implementation.PowerSupplyCore.ApcCore
{
    public class Apc7920bSettings : PowerSupplySettings
    {
        public ushort FirstChannel { get; set; }
        public ushort LastChannel { get; set; }

    }
}
