using System.Collections.Generic;

namespace Zarmon.Device.Logics
{
    public class LogicManager
    {
        public HashSet<ILogic> Logics { get; set; }

        public LogicManager()
        {
            Logics = new HashSet<ILogic>();
        }

        public TLogic GetLogic<TLogic>() where TLogic : ILogic
        {
            foreach (var logic in Logics)
                if (logic is TLogic log)
                    return log;

            return default(TLogic);
        }

        public void AddLogic(ILogic logic)
        {
            Logics.Add(logic);
        }

    }
}