using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SharpGeoApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        private readonly string externalUri;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ApiController> _logger;

        public ApiController(IConfiguration configuration, ILogger<ApiController> logger)
        {
            _logger = logger;
            _configuration = configuration;
            //externalUri = configuration["externalUri"];
        }

        [HttpGet]
        public string Get()
        {
            // todo: return openapi spec (how?)
            return "false";
        }
    }
}
