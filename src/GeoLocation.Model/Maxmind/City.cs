using System.Collections.Generic;
using MaxMind.Db;

namespace GeoLocation.Model.Maxmind
{
    public class City
    {
        [Constructor]
        public City([Parameter("names")] Dictionary<string, string> names)
        {
            CityNames = names;
        }

        public Dictionary<string, string> CityNames { get; }
    }
}