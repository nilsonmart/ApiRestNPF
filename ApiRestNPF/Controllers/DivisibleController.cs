using ApiRestNPF.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ApiRestNPF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DivisibleController : Controller
    {
        [HttpGet]
        public IActionResult Calculate([FromBody] JsonElement jsonElement)
        {
            if (string.IsNullOrWhiteSpace(jsonElement.ToString()))
            {
                return BadRequest("Argument is null");
            }
            string rawJson = jsonElement.ToString();
            var numbers = JsonConvert.DeserializeObject<NumberModel>(rawJson);
            List<ResultModel> listNumber = new List<ResultModel>();
            foreach (var number in numbers.Numbers)
            {
                ResultModel result = new ResultModel();

                long difference = 0;
                long minuend = number / 10;
                long subtractive = number % 10;
                long count = minuend.ToString().Count();

                result.Number = number;

                while (count != 2)
                {
                    if (minuend < 11)
                        break;

                    difference = minuend - subtractive;
                    minuend = difference / 10;
                    subtractive = difference % 10;
                    count = difference.ToString().Length;
                }

                if (difference % 11 == 0)
                {
                    result.IsMultiple = true;
                }
                listNumber.Add(result);
            }

            return Ok(listNumber);
        }
    }
}
