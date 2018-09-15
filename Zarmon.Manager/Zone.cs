using System.Collections.Generic;
using Serilog;

namespace Zarmon.Manager
{
    public class Zone
    {
        public string ZoneName { get; set; }

        public ICollection<Site.Site> Sites { get; set; }

        public Zone(string zoneName)
        {
            ZoneName = zoneName;
            Sites = new List<Site.Site>();
        }

        public Site.Site AddSite(Site.Site site)
        {
            Sites.Add(site);
            Log.Debug("Site: {@site} added successfully", site);
            return site; 
        }
    }


}