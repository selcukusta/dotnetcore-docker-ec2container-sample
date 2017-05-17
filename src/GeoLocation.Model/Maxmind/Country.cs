using MaxMind.Db;
using System.Collections.Generic;

namespace GeoLocation.Model.Maxmind
{
    public class Country
    {
        [Constructor]
        public Country(
            [Parameter("iso_code")] string code,
            [Parameter("names")] Dictionary<string, string> names
        )
        {
            Code = code;
            Names = names;
        }
        public Dictionary<string, string> Names { get; }
        public string Code { get; }
    }
}