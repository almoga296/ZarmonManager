using System;
using System.Collections.Generic;
using System.Text;

namespace Zarmon.Device.ApiCore.CricketTransciever.Models
{
    public class CricketLogModel
    {
        public LogLevel Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ThreadId { get; set; }
        public string Messsage { get; set; }

        public CricketLogModel()
        {
        }
    }
}
