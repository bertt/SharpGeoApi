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
            var selfLink = new Link() { Rel = "self", Title = "This document as JSON", Href = $"{ExternalUri}/" };
            var serviceDescLink = new Link() { Rel = "service-desc", Title = "The OpenAPI definition as JSON", Href = $"{ExternalUri}/api" };
            var conformanceLink = new Link() { Rel = "conformance", Title = "Conformance", Href = $"{ExternalUri}/conformance" };
            var dataLink = new Link() { Rel = "data", Title = "Collections", Href = $"{ExternalUri}/collections" };
            var processesLink = new Link() { Rel = "processes", Title = "Processes", Href = $"{ExternalUri}/processes" };
            var links = new List<Link>() { selfLink, serviceDescLink, conformanceLink, dataLink, processesLink };
            return links;
        }
    }
}
