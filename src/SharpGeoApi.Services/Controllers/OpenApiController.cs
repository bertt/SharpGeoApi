using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SharpGeoApi.Controllers
{
    [ApiController]
    [Route("openapi")]
    public class OpenApiController : ControllerBase
    {
        private readonly string externalUri;
        private readonly IConfiguration _configuration;
        private readonly ILogger<OpenApiController> _logger;

        public OpenApiController(IConfiguration configuration, ILogger<OpenApiController> logger)
        {
            _logger = logger;
            _configuration = configuration;
            externalUri = configuration["externalUri"];
        }

        [HttpGet, FormatFilter]
        public string Get()
        {
            // todo: return openapi spec (how?)
            return "false";
        }
    }
}
