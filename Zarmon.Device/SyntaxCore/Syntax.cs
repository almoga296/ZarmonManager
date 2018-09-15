using Zarmon.Device.SyntaxCore.Core;
using Zarmon.Device.SyntaxCore.Core.Interfaces;

namespace Zarmon.Device.SyntaxCore
{
    public abstract class Syntax : ISyntax
    {
        //#region Common Commands

        //public virtual Command RESET => throw new NotImplementedException();
        //public virtual Command CLEAR_SCREEN => throw new NotImplementedException();
        //public virtual Command IS_ERROR => throw new NotImplementedException();

        //#endregion

        //#region Power Supply Commands

        //public virtual Command TURN_ON => throw new NotImplementedException();
        //public virtual Command TURN_OFF => throw new NotImplementedException();
        //public virtual Command GET_OUTPUT_STATE => throw new NotImplementedException();
        //public virtual Command SET_VOLTAGE => throw new NotImplementedException();
        //public virtual Command GET_VOLTAGE => throw new NotImplementedException();
        //public virtual Command SET_CURRENT_LIMIT => throw new NotImplementedException();
        //public virtual Command GET_CURRENT_LIMIT => throw new NotImplementedException();

        //#endregion

        //#region Rubidium Commands

        //public virtual Command GET_BIT_REPORT => throw new NotImplementedException();
        //public virtual Command GET_TIME_REPORT => throw new NotImplementedException();
        //public virtual Command GET_SYSTEM_REPORT => throw new NotImplementedException();

        //#endregion

        //public static string CommandBuilder(Command command, params object[] args)
        //{
        //    string pattern = @"\{\{\w+\}\}";
        //    Regex regex = new Regex(pattern);
        //    MatchCollection matches = regex.Matches(command.CommandString);

        //    for (int i = 0; i < args.Length; i++)
        //        command.CommandString = command.CommandString.Replace(matches[i].Value, args[i].ToString());
        //    return command.CommandString;
           
        //}
    }
}