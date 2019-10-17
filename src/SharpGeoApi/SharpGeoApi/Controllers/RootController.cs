using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharpGeoApi.Core;

namespace SharpGeoApi.Controllers
{
    [ApiController]
    [Route("/")]

    public class RootController:ControllerBase
    {
        private readonly ILogger<RootController> _logger;


        public RootController(ILogger<RootController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public RootObject Get()
        {
            var rootObject = new RootObject();
            rootObject.Description = "SharpGeoApi provides an API to geospatial data";
            rootObject.Title = "SharpGeoApi Demo instance";
            // rootObject.links
            return rootObject;
        }

    }
}
