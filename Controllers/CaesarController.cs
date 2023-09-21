using Microsoft.AspNetCore.Mvc;
using ShiftAPI.Services.CaesarCode;

namespace ShiftAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CaesarController : Controller
    {
        private readonly IEncoder caesarEncoder;

        public CaesarController(IEncoder _caesarEncoder)
        {
            caesarEncoder = _caesarEncoder;
        }

        [HttpGet]
        public IActionResult Index()
        {   
            return Ok();
        }

        [HttpPost]
        public IActionResult Encode(CaesarDTO data)
        {
            var output = caesarEncoder.Encode(data);

            return Ok(output);
        }

        [HttpPost]
        public IActionResult Decode(CaesarDTO data)
        {
            var output = caesarEncoder.Decode(data);

            return Ok(output);
        }

    }
}
