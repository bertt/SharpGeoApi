using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharpGeoApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpGeoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConformanceController : ControllerBase
    {
        private readonly ILogger<ConformanceController> _logger;

        public ConformanceController(ILogger<ConformanceController> logger)
        {
            _logger = logger;
        }

        [HttpGet, FormatFilter]
        public Conformance Get()
        {
            var conformance = new Conformance();
            conformance.ConformsTo = new List<string>() {
                "http://www.opengis.net/spec/ogcapi-features-1/1.0/req/core",
                "http://www.opengis.net/spec/ogcapi-features-1/1.0/req/oas30",
                "http://www.opengis.net/spec/ogcapi-features-1/1.0/req/html",
                "http://www.opengis.net/spec/ogcapi-features-1/1.0/req/geojson"};
            return conformance;
        }

    }
}
