using GeoLocation.Model;
using GeoLocation.Model.Maxmind;
using MaxMind.Db;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using Microsoft.Extensions.Primitives;
using System.Linq;

namespace GeoLocation.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly IMemoryCache _cache;
        public CountryController(IHostingEnvironment env, IMemoryCache cache)
        {
            _environment = env;
            _cache = cache;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var webRoot = _environment.ContentRootPath;
            var dbPath = Path.Combine(webRoot, "App_Data", "GeoIP2-City.mmdb");

            if (!System.IO.File.Exists(dbPath))
            {
                return new EmptyResult();
            }

            StringValues clientIp;
            if (Request?.Headers != null && !Request.Headers.TryGetValue("Client-Ip", out clientIp) && clientIp.Any())
            {
                return new EmptyResult();
            }

            IPAddress ipAddress;
            if (!IPAddress.TryParse(clientIp.FirstOrDefault(), out ipAddress))
            {
                return new EmptyResult();
            }

            var maxmindDb = _cache.GetOrCreate("GeomindReader", readerCache =>
            {
                var reader = new Reader(dbPath);
                readerCache.SetSlidingExpiration(TimeSpan.FromHours(1));
                readerCache.SetPriority(CacheItemPriority.High);
                readerCache.SetValue(reader);
                readerCache.RegisterPostEvictionCallback((key, value, reason, state) =>
                {
                    (value as IDisposable)?.Dispose();
                });
                return reader;
            });

            #region Sample ip addresses
            //string ip_de = "46.101.203.115";
            //string ip_tr = "5.176.0.123";
            //string ip_usa = "54.244.58.13";
            #endregion

            var geoLocResult = maxmindDb.Find<Location>(ipAddress);
            var result = new Model.GeoLocation(geoLocResult, ipAddress.ToString(), LanguageCode.en);
            return Content(JsonConvert.SerializeObject(result), "application/json", System.Text.Encoding.UTF8);
        }
    }
}
