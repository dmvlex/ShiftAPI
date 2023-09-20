using Microsoft.AspNetCore.Mvc;

namespace ShiftAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaesarController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello!");
        }
    }
}
