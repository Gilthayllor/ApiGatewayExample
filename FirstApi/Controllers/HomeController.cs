using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult GetName()
        {
            return Ok("Gilthayllor Sousa");
        }
    }
}
