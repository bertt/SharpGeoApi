using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SharpGeoApi.Core;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;

namespace SharpGeoApi.Controllers
{
    [ApiController]
    [Route("collections")]
    public class FeatureCollectionsController : ControllerBase
    {
        private readonly ILogger<FeatureCollectionsController> _logger;
        private readonly string externalUri;
        private readonly List<Dataset> datasets;

        public FeatureCollectionsController(IConfiguration configuration, IOptions<List<Dataset>> datasets, ILogger<FeatureCollectionsController> logger)
        {
            _logger = logger;
            this.datasets = datasets.Value;
            externalUri = configuration["externalUri"];
        }

        [HttpGet, FormatFilter]
        public FeatureCollections Get()
        {
            var featureCollections = new FeatureCollections();

            featureCollections.Collections = datasets;

            var selfLinkAsJson = new Link() { Rel = "self", Type = MediaTypeNames.Application.Json, Title = "This document as JSON", Href = $"{externalUri}/collections?f=json" };
            var selfLinkAsHtml = new Link() { Rel = "self", Type = "text/html", Title = "This document as HTML", Href = $"{externalUri}/collections?f=html", HrefLang = "en-US" };

            featureCollections.Links = new List<Link>() { selfLinkAsJson, selfLinkAsHtml };

            return featureCollections;
        }

        [HttpGet("{id}"), FormatFilter]
        public FeatureCollection Get(string id)
        {
            var featureCollection = new FeatureCollection();
            return featureCollection;
        }

        // todo: 
        // /collections/{collectionId}/items
        // collections/{collectionId}/items/{featureId
    }
}
