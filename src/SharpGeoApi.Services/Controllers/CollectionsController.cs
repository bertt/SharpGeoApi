using GeoJSON.Net.Feature;
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
    public class CollectionsController : ControllerBase
    {
        private readonly ILogger<CollectionsController> _logger;
        private readonly string externalUri;
        private readonly List<Dataset> datasets;

        public CollectionsController(IConfiguration configuration, IOptions<List<Dataset>> datasets, ILogger<CollectionsController> logger)
        {
            _logger = logger;
            this.datasets = datasets.Value;
            externalUri = configuration["externalUri"];
        }

        private List<Link> GetLinks(Dataset dataset)
        {
            var featuresLink = new Link() { Rel = "item", Title = "Features", Href = $"{externalUri}/collections/{dataset.Id}/items" };
            var selfLink = new Link() { Rel = "self", Title = "This document", Href = $"{externalUri}/collections/{dataset.Id}" };
            var links = new List<Link> { featuresLink,  selfLink};
            return links;
        }

        [HttpGet, FormatFilter]
        public Collections Get()
        {
            var featureCollections = new Collections();

            foreach(var dataset in datasets)
            {
                dataset.Links = GetLinks(dataset);
            }

            featureCollections.Datasets = datasets;

            var selfLink = new Link() { Rel = "self", Title = "This document as JSON", Href = $"{externalUri}/collections?f=json" };

            featureCollections.Links = new List<Link>() { selfLink};

            return featureCollections;
        }

        [HttpGet("{collectionId}"), FormatFilter]
        public Dataset Get(string collectionId)
        {
            var dataset = (from s in datasets where s.Id == collectionId select s).FirstOrDefault();
            dataset.Links = GetLinks(dataset);
            return dataset;
        }


        [HttpGet("{collectionId}/items"), FormatFilter]
        public FeatureCollection GetFeatures(string collectionId)
        {
            var dataset = (from s in datasets where s.Id == collectionId select s).FirstOrDefault();
            dataset.Links = GetLinks(dataset);

            return new FeatureCollection();
            // todo: 
            // - open dataset using gdal
            // - get the features of given dataset
            // return the_features;
        }

        [HttpGet("{collectionId}/items/{featureId}"), FormatFilter]
        public Feature GetFeature(string collectionId, string featureId)
        {
            var dataset = (from s in datasets where s.Id == collectionId select s).FirstOrDefault();
            dataset.Links = GetLinks(dataset);
            return null;

            // todo: get the feature with id=featureId of given dataset
            // return the_feature;
        }
    }
}
