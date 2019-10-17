using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharpGeoApi.Core;

namespace SharpGeoApi.Controllers
{
    [ApiController]
    [Route("collections")]
    public class FeatureCollectionsController : ControllerBase
    {
        private readonly ILogger<FeatureCollectionsController> _logger;

        public FeatureCollectionsController(ILogger<FeatureCollectionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public FeatureCollections Get()
        {
            var featureCollections = new FeatureCollections();
            // todo: fill featurecollections
            return featureCollections;
        }
    }
}
