using MaxMind.Db;

namespace GeoLocation.Model.Maxmind
{
    public class Postal
    {
        [Constructor]
        public Postal([Parameter("code")] string postal)
        {
            Code = postal;
        }

        public string Code { get; }
    }
}