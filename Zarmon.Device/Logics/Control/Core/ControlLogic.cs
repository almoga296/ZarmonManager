using System;
using System.Threading;
using Zarmon.Device.ApiCore;
using Zarmon.Device.ApiCore.Core;

namespace Zarmon.Device.Logics.Control.Core
{
    public abstract class ControlLogic : Logic
    {
        protected ControlLogic(ControlSettings controlSettings) : base(controlSettings)
        {
        }

        protected ControlLogic(ControlSettings controlSettings,params IApi[] apis) : base(controlSettings, apis)
        {
        }
        
        public void Wait(TimeSpan timeToWait)
        {
            Thread.Sleep(timeToWait);
        }
 
    }
}