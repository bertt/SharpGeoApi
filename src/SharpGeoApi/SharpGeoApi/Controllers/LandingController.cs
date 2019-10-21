using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetEscapades.Configuration.Yaml;
using SharpGeoApi.Core;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SharpGeoApi.Controllers
{
    [ApiController]
    [Route("/")]

    public class LandingController:Controller
    {
        private readonly string externalUri;
        private readonly IConfiguration _configuration;
        private readonly ILogger<LandingController> _logger;

        public LandingController(IConfiguration configuration, ILogger<LandingController> logger)
        {
            _logger = logger;
            _configuration = configuration;
            externalUri = configuration["externalUri"];
        }

        [HttpGet, FormatFilter]
        public LandingObject Get()
        {
            var rootObject = new LandingObject();
            rootObject.TermsOfService = _configuration["metadata:identification:terms_of_service"];
            rootObject.LicenseName = _configuration["metadata:license:name"]; 
            rootObject.LicenseUrl = _configuration["metadata:license:url"];
            rootObject.Title = _configuration["metadata:identification:title"];
            rootObject.Description = _configuration["metadata:identification:description"];
            var selfLinkAsJson = new Link() { Rel = "self", Type = MediaTypeNames.Application.Json, Title = "This document as JSON", Href = $"{externalUri}/" };
            var selfLinkAsHtml = new Link() { Rel = "self", Type = "text/html", Title = "This document as HTML", Href = $"{externalUri}/?f=html", HrefLang = "en-US" };
            var serviceDescLinkAsJson = new Link() { Rel = "service-desc", Type = "application/vnd.oai.openapi+json;version=3.0", Title = "The OpenAPI definition as JSON", Href = $"{externalUri}/api" };
            var serviceDescLinkAsHtml = new Link() { Rel = "service-doc", Type = "text/html", Title = "The OpenAPI definition as HTML", Href = $"{externalUri}/api?f=html", HrefLang = "en-US" };
            var conformanceLink = new Link() { Rel = "conformance", Type = MediaTypeNames.Application.Json, Title = "Conformance", Href = $"{externalUri}/conformance" };
            var dataLink = new Link() { Rel = "data", Type = MediaTypeNames.Application.Json, Title = "Collections", Href = $"{externalUri}/collections" };
            var processesLink = new Link() { Rel = "processes", Type = MediaTypeNames.Application.Json, Title = "Processes", Href = $"{externalUri}/processes" };
            rootObject.Links = new List<Link>() { selfLinkAsJson, selfLinkAsHtml, serviceDescLinkAsJson, serviceDescLinkAsHtml, conformanceLink, dataLink, processesLink };

            var u = (from links in rootObject.Links where links.Rel == "conformance" select links.Href).FirstOrDefault(); 

            return rootObject;
        }



    }
}
