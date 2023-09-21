using Microsoft.AspNetCore.Mvc;
using ShiftAPI.Services.CaesarCode;

namespace ShiftAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            string s = "shit";

            var a = new CaesarDTO()
            {
                Key = 3,
                AlphabetKey = "English",
                Input = s
            };
            
            return Ok(caesarEncoder.Encode(a));
        }

    }
}
