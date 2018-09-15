using Zarmon.Device.SyntaxCore.Core;
using Zarmon.Device.SyntaxCore.Core.Interfaces;

namespace Zarmon.Device.SyntaxCore
{
    public class ScpiSyntax : Syntax , IScpiSyntax
    {
        public Command RESET()
        {
            return new Command
            {
                Builder = ()=> "*RST"
            };
        }

        public Command CLEAR_SCREEN()
        {
            return new Command
            {
                Builder = () => "*CLS"
            };
        }
    }
}