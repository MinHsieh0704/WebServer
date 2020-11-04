using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.Server
{
    [Route("{path}/{controller}")]
    public class TimeController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            DateTime now = DateTime.Now;

            return new ObjectResult(now.ToString("yyyy/MM/dd HH:mm:ss"));
        }
    }
}
