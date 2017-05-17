using Microsoft.AspNetCore.Mvc;
using System;

namespace GeoLocation.Controllers
{
    [Route("api/[controller]")]
    public class DateController : Controller
    {
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(new { Date = DateTime.Now.ToUniversalTime().ToString("r") });
        }
    }
}
