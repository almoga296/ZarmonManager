using System;

namespace Zarmon.Device.SyntaxCore.Core.Generic
{
    public class Command<POut> : Command
    {
        public Func<object, POut> Parser { get; set; }

        public Command()
        {

        }

        public Command(Func<object> builder = null, Func<object, POut> parser = null) : base(builder)
        {
            Parser = parser;
        }
    }
}