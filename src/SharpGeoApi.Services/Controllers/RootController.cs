using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SharpGeoApi.Core;
using System.Collections.Generic;
using System.Net.Mime;

namespace SharpGeoApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class RootController:Controller
    {
        private readonly string externalUri;
        private readonly ILogger<RootController> _logger;
        private readonly Metadata metadata;

        public RootController(IConfiguration configuration, IOptions<Metadata> metadata, ILogger<RootController> logger)
        {
            _logger = logger;
            this.metadata = metadata.Value;
            externalUri = configuration["externalUri"];
        }

        [HttpGet, FormatFilter]
        public Root Get()
        {
            var rootObject = new Root();
            rootObject.Metadata = metadata;

            var links = GetLinks(externalUri);
            rootObject.Links = links;
            return rootObject;
        }

        private List<Link> GetLinks(string ExternalUri)
        {
            var selfLinkAsJson = new Link() { Rel = "self", Type = MediaTypeNames.Application.Json, Title = "This document as JSON", Href = $"{ExternalUri}/" };
            var selfLinkAsHtml = new Link() { Rel = "self", Type = "text/html", Title = "This document as HTML", Href = $"{ExternalUri}/?f=html", HrefLang = "en-US" };
            var serviceDescLinkAsJson = new Link() { Rel = "service-desc", Type = "application/vnd.oai.openapi+json;version=3.0", Title = "The OpenAPI definition as JSON", Href = $"{ExternalUri}/api" };
            var serviceDescLinkAsHtml = new Link() { Rel = "service-doc", Type = "text/html", Title = "The OpenAPI definition as HTML", Href = $"{ExternalUri}/openapi?f=html", HrefLang = "en-US" };
            var conformanceLink = new Link() { Rel = "conformance", Type = MediaTypeNames.Application.Json, Title = "Conformance", Href = $"{ExternalUri}/conformance" };
            var dataLink = new Link() { Rel = "data", Type = MediaTypeNames.Application.Json, Title = "Collections", Href = $"{ExternalUri}/collections" };
            var processesLink = new Link() { Rel = "processes", Type = MediaTypeNames.Application.Json, Title = "Processes", Href = $"{ExternalUri}/processes" };
            var links = new List<Link>() { selfLinkAsJson, selfLinkAsHtml, serviceDescLinkAsJson, serviceDescLinkAsHtml, conformanceLink, dataLink, processesLink };
            return links;
        }
    }
}
