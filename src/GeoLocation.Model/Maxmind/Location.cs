using MaxMind.Db;
using System.Collections.Generic;

namespace GeoLocation.Model.Maxmind
{
    public class Location
    {
        [Constructor]
        public Location(
            [Parameter("city")] City city,
            [Parameter("continent")] Continent continent,
            [Parameter("country")] Country country,
            [Parameter("postal")] Postal postal,
            [Parameter("subdivisions")] IList<Region> regions
        )
        {
            CityDetail = city;
            ContinentDetail = continent;
            CountryDetail = country;
            PostalDetail = postal;
            Regions = regions;
        }

        public City CityDetail { get; }
        public Continent ContinentDetail { get; }
        public Country CountryDetail { get; }
        public Postal PostalDetail { get; }
        public IList<Region> Regions { get; }
    }
}