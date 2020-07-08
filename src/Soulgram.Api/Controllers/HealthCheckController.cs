using Microsoft.AspNetCore.Mvc;

namespace Soulgram.Api
{
    [Route("/hc")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

    }
}
