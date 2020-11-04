using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers.Server
{
    [Route("{path}/{controller}")]
    public class PositionController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            return new ObjectResult(path);
        }
    }
}
