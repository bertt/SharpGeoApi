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

        private List<Link> GetLinks(Dataset dataset)
        {
            var featuresAsGeoJsonLink = new Link() { Rel = "item", Type = "application/geo+json", Title = "Features as GeoJSON", Href = $"{externalUri}/collections/{dataset.Id}/items?f=json" };
            var featuresAsHtmlLink = new Link() { Rel = "item", Type = "text/html", Title = "Features as HTML", Href = $"{externalUri}/collections/{dataset.Id}/items?f=html" };
            var selfAsJsonLink = new Link() { Rel = "self", Type = "application/json", Title = "This document as JSON", Href = $"{externalUri}/collections/{dataset.Id}?f=json" };
            var selfAsHtmlLink = new Link() { Rel = "self", Type = "text/html", Title = "This document as HTML", Href = $"{externalUri}/collections/{dataset.Id}?f=html" };
            var links = new List<Link> { featuresAsGeoJsonLink, featuresAsHtmlLink, selfAsJsonLink, selfAsHtmlLink };
            return links;
        }

        [HttpGet, FormatFilter]
        public FeatureCollections Get()
        {
            var featureCollections = new FeatureCollections();

            foreach(var dataset in datasets)
            {
                dataset.Links = GetLinks(dataset);
            }

            featureCollections.Collections = datasets;

            var selfLinkAsJson = new Link() { Rel = "self", Type = MediaTypeNames.Application.Json, Title = "This document as JSON", Href = $"{externalUri}/collections?f=json" };
            var selfLinkAsHtml = new Link() { Rel = "self", Type = "text/html", Title = "This document as HTML", Href = $"{externalUri}/collections?f=html", HrefLang = "en-US" };

            featureCollections.Links = new List<Link>() { selfLinkAsJson, selfLinkAsHtml };

            return featureCollections;
        }

        [HttpGet("{id}"), FormatFilter]
        public Dataset Get(string id)
        {
            var dataset = (from s in datasets where s.Id == id select s).FirstOrDefault();
            return dataset;
        }

        // todo: 
        // /collections/{collectionId}/items
        // collections/{collectionId}/items/{featureId
    }
}
