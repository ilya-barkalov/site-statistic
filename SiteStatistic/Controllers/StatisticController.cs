using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace SiteStatistic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticController : Controller
    {
        /// <summary>
        /// Получить общую статистику
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        { 
            return Ok(new { Test = "Test" });
        }
    }
}
