using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SharpGeoApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public bool Get()
        {
            // todo: return openapi spec (how?)
            return false;
        }
    }
}
