using System;

namespace Zarmon.Device.SyntaxCore.Core
{
    public class Command
    {
        public Func<object> Builder { get; set; }

        #region C'tors

        public Command(Func<object> builder)
        {
            Builder = builder;
        }

        public Command()
        {
        }

        #endregion
    }
}