using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharpGeoApi.Core;
using System.Collections.Generic;
using System.Net.Mime;

namespace SharpGeoApi.Controllers
{
    [ApiController]
    [Route("/")]

    public class RootController:ControllerBase
    {
        private readonly ILogger<RootController> _logger;
        private readonly string externalUri = "https://localhost:44332";
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

            var selfLinkAsJson = new Link() { Rel = "self", Type = MediaTypeNames.Application.Json, Title = "This document as JSON", Href = $"{externalUri}/" };
            var selfLinkAsHtml = new Link() { Rel = "self", Type = "text/html", Title = "This document as HTML", Href = $"{externalUri}/?f=html", HrefLang = "en-US" };
            var serviceDescLinkAsJson = new Link() { Rel = "service-desc", Type = "application/vnd.oai.openapi+json;version=3.0", Title = "The OpenAPI definition as JSON", Href = $"{externalUri}/api" };
            var serviceDescLinkAsHtml = new Link() { Rel = "service-doc", Type = "text/html", Title = "he OpenAPI definition as HTML", Href = $"{externalUri}/api?f=html", HrefLang = "en-US" };
            var conformanceLink = new Link() { Rel = "conformance", Type = MediaTypeNames.Application.Json, Title = "Conformance", Href = $"{externalUri}/conformance" };
            var dataLink = new Link() { Rel = "data", Type = MediaTypeNames.Application.Json, Title = "Collections", Href = $"{externalUri}/collections" };
            rootObject.Links = new List<Link>() { selfLinkAsJson, selfLinkAsHtml, serviceDescLinkAsJson, serviceDescLinkAsHtml, conformanceLink, dataLink };
            return rootObject;
        }
    }
}
