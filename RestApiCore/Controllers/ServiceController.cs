using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Service")]
    public class ServiceController : Controller
    {
        private readonly ILogger _logger;
        public ServiceController(ILogger<ServiceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Status")]
        [Produces(typeof(object))]
        public IActionResult Status()
        {
            var appName = Assembly.GetEntryAssembly().GetName().Name;
            var appVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();

            var info = new { ApplicationName = appName, AppVersion = appVersion, Status = "Running" };
            return Ok(info);
        }
    }
}