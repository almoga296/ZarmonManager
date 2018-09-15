using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Zarmon.Device.ApiCore.CricketTransciever.Models;
using Zarmon.Device.SyntaxCore;
using Zarmon.Device.SyntaxCore.Core.Generic;

namespace Zarmon.Device.Implementation.CricketCore
{
    public class CricketTransceiverSyntax : Syntax
    {
        public Command<CricketLogModel> GET_RECEIVED_DATA => new Command<CricketLogModel>(null, (dataBytes) =>
        {
            string data = Encoding.ASCII.GetString((byte[])dataBytes);
            string[] dataFragments = data.Split(',');
            string[] levelMessageFragments = dataFragments[3].Split(':');
            return new CricketLogModel()
            {
                TimeStamp = DateTime.ParseExact(dataFragments[0] + dataFragments[1], "yyyyMMdd HH:mm:ss.fff", CultureInfo.InvariantCulture),
                ThreadId = int.Parse(dataFragments[2]),
                Level = (LogLevel)Enum.Parse(typeof(LogLevel), levelMessageFragments[0], true),
                Messsage = levelMessageFragments[1].TrimStart()
            };
        });
        
    }
}
