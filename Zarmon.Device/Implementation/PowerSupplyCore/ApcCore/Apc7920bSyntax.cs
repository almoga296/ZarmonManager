using System;
using System.Collections.Generic;
using System.Text;
using Zarmon.Device.SyntaxCore;
using Zarmon.Device.SyntaxCore.Core;
using Zarmon.Device.SyntaxCore.Core.Generic;
using Zarmon.Device.SyntaxCore.Core.Interfaces;

namespace Zarmon.Device.Implementation.PowerSupplyCore.ApcCore
{
    public class Apc7920bSyntax : Syntax, IPowerSupplySyntax
    {
        public Command<bool> GET_POWER_STATE(ushort channel)
        {
            return new Command<bool>(() => Encoding.ASCII.GetBytes("STATE?"), (data) => Encoding.ASCII.GetString((byte[])data) == "1" ? true : false);
        }

        public Command TURN_POWER_OFF(ushort channel)
        {
            return new Command(() => Encoding.ASCII.GetBytes("OFF"));
        }

        public Command TURN_POWER_ON(ushort channel)
        {
            return new Command(() => Encoding.ASCII.GetBytes("ON"));
        }
    }
}
