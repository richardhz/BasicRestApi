using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestApiCore.Controllers
{
    [Route("api/Service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ILogger _logger;
        public ServiceController(ILogger<ServiceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Status")]
        public IActionResult Status()
        {
            var appName = Assembly.GetEntryAssembly().GetName().Name;
            var appVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();

            var info = new { ApplicationName = appName, AppVersion = appVersion, Status = "Running" };
            return Ok(info);
        }
    }
}