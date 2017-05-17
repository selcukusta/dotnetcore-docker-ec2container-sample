using MaxMind.Db;

namespace GeoLocation.Model.Maxmind
{
    public class Continent
    {
        [Constructor]
        public Continent([Parameter("code")] string continent)
        {
            Code = continent;
        }

        public string Code { get; }
    }
}
