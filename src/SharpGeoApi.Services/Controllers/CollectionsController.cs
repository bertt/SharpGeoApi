﻿using GeoJSON.Net.Feature;
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
            var featuresAsGeoJsonLink = new Link() { Rel = "item", Type = "application/geo+json", Title = "Features as GeoJSON", Href = $"{externalUri}/collections/{dataset.Id}/items?f=json" };
            var featuresAsHtmlLink = new Link() { Rel = "item", Type = "text/html", Title = "Features as HTML", Href = $"{externalUri}/collections/{dataset.Id}/items?f=html" };
            var selfAsJsonLink = new Link() { Rel = "self", Type = "application/json", Title = "This document as JSON", Href = $"{externalUri}/collections/{dataset.Id}?f=json" };
            var selfAsHtmlLink = new Link() { Rel = "self", Type = "text/html", Title = "This document as HTML", Href = $"{externalUri}/collections/{dataset.Id}?f=html" };
            var links = new List<Link> { featuresAsGeoJsonLink, featuresAsHtmlLink, selfAsJsonLink, selfAsHtmlLink };
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

            var selfLinkAsJson = new Link() { Rel = "self", Type = MediaTypeNames.Application.Json, Title = "This document as JSON", Href = $"{externalUri}/collections?f=json" };
            var selfLinkAsHtml = new Link() { Rel = "self", Type = "text/html", Title = "This document as HTML", Href = $"{externalUri}/collections?f=html", HrefLang = "en-US" };

            featureCollections.Links = new List<Link>() { selfLinkAsJson, selfLinkAsHtml };

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
