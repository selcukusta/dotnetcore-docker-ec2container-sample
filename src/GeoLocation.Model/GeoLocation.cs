using GeoLocation.Model.Maxmind;
using System;
using System.Linq;

namespace GeoLocation.Model
{
    public class GeoLocation
    {
        public string City { get; }
        public string Region { get; }
        public string CountryCode { get; }
        public string CountryName { get; }
        public string PostalCode { get; }
        public string IpAddress { get; }
        public string RegionName { get; }
        public string ContinentCode { get; protected set; }

        public GeoLocation(Location location, string ipAddress, LanguageCode code)
        {
            IpAddress = ipAddress;
            City = location?.CityDetail?.CityNames[Enum.GetName(typeof(LanguageCode), code)];
            ContinentCode = location?.ContinentDetail?.Code;
            CountryCode = location?.CountryDetail?.Code;
            CountryName = location?.CountryDetail?.Names[Enum.GetName(typeof(LanguageCode), code)];
            PostalCode = location?.PostalDetail?.Code;
            if (location?.Regions != null && location.Regions.Any())
            {
                RegionName = location.Regions.FirstOrDefault().Names[Enum.GetName(typeof(LanguageCode), code)];
                Region = location.Regions.FirstOrDefault().Code;
            }
        }
    }
}
