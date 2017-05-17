using Microsoft.AspNetCore.Mvc;
using System;

namespace NetCoreSampleApp.Controllers
{
    public class HomeController : Controller
    {
        // GET api/values
        [HttpGet]
        public JsonResult Index()
        {
            return new JsonResult(new { Date = DateTime.Now.ToUniversalTime().ToString("r") });
        }
    }
}
