namespace Zarmon.Device.SyntaxCore.Core.Interfaces
{
    public interface IScpiSyntax : ISyntax
    {
        Command RESET();
        Command CLEAR_SCREEN();

    }
}