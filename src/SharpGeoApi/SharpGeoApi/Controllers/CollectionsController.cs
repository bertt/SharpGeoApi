using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharpGeoApi.Core;
using System.Collections.Generic;

namespace SharpGeoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollectionsController : ControllerBase
    {
        private readonly ILogger<CollectionsController> _logger;

        public CollectionsController(ILogger<CollectionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Collections> Get()
        {
            var collections = new Collections();
            // todo: get the datasets 
            return new List<Collections>() { collections };
        }
    }
}
