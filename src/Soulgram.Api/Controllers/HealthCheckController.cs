using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Soulgram.Api
{
    [Route("/hc")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<HealthCheckController> _logger;

        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Health check");
            return Ok();
        }

    }
}
