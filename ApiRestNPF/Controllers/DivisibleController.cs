using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestNPF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DivisibleController : Controller
    {
        [HttpGet]
        public IActionResult Calculates(long[] numbers)
        {
            foreach (var item in numbers)
            {

            }

            return Ok();
        }
    }
}
