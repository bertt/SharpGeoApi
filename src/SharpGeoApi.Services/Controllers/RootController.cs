using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SharpGeoApi.Core;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;

namespace SharpGeoApi.Controllers
{
    [ApiController]
    [Route("/")]

    public class RootController:Controller
    {
        private readonly string externalUri;
        private readonly IConfiguration _configuration;
        private readonly ILogger<RootController> _logger;

        public RootController(IConfiguration configuration, ILogger<RootController> logger)
        {
            _logger = logger;
            _configuration = configuration;
            externalUri = configuration["externalUri"];
        }

        [HttpGet, FormatFilter]
        public Root Get()
        {
            var rootObject = new Root();
            rootObject.Identification.Title = _configuration["metadata:identification:title"];
            rootObject.Identification.Description = _configuration["metadata:identification:description"];
            rootObject.Identification.Keywords = (from items in _configuration.AsEnumerable() where items.Key.StartsWith("metadata:identification:keywords:") select items.Value).ToList();
            rootObject.Identification.KeyWordsType = _configuration["metadata:identification:keywords_type"];
            rootObject.Identification.TermsOfService = _configuration["metadata:identification:terms_of_service"];
            rootObject.Identification.Url = _configuration["metadata:identification:url"];
            rootObject.License.Name = _configuration["metadata:license:name"]; 
            rootObject.License.Url = _configuration["metadata:license:url"];
            rootObject.Provider.Name = _configuration["metadata:provider:name"];
            rootObject.Provider.Url = _configuration["metadata:provider:url"];
            rootObject.Contact.Name = _configuration["metadata:contact:name"];
            rootObject.Contact.Position = _configuration["metadata:contact:position"];
            rootObject.Contact.Address = _configuration["metadata:contact:address"];
            rootObject.Contact.City = _configuration["metadata:contact:city"];
            rootObject.Contact.StateOrProvince = _configuration["metadata:contact:stateorprovince"];
            rootObject.Contact.PostalCode = _configuration["metadata:contact:postalcode"];
            rootObject.Contact.Country = _configuration["metadata:contact:country"];
            rootObject.Contact.Phone = _configuration["metadata:contact:phone"];
            rootObject.Contact.Fax = _configuration["metadata:contact:fax"];
            rootObject.Contact.Email = _configuration["metadata:contact:email"];
            rootObject.Contact.Url = _configuration["metadata:contact:url"];
            rootObject.Contact.Hours = _configuration["metadata:contact:hours"];
            rootObject.Contact.Instructions = _configuration["metadata:contact:instructions"];
            rootObject.Contact.Role = _configuration["metadata:contact:role"];

            var selfLinkAsJson = new Link() { Rel = "self", Type = MediaTypeNames.Application.Json, Title = "This document as JSON", Href = $"{externalUri}/" };
            var selfLinkAsHtml = new Link() { Rel = "self", Type = "text/html", Title = "This document as HTML", Href = $"{externalUri}/?f=html", HrefLang = "en-US" };
            var serviceDescLinkAsJson = new Link() { Rel = "service-desc", Type = "application/vnd.oai.openapi+json;version=3.0", Title = "The OpenAPI definition as JSON", Href = $"{externalUri}/api" };
            var serviceDescLinkAsHtml = new Link() { Rel = "service-doc", Type = "text/html", Title = "The OpenAPI definition as HTML", Href = $"{externalUri}/openapi?f=html", HrefLang = "en-US" };
            var conformanceLink = new Link() { Rel = "conformance", Type = MediaTypeNames.Application.Json, Title = "Conformance", Href = $"{externalUri}/conformance" };
            var dataLink = new Link() { Rel = "data", Type = MediaTypeNames.Application.Json, Title = "Collections", Href = $"{externalUri}/collections" };
            var processesLink = new Link() { Rel = "processes", Type = MediaTypeNames.Application.Json, Title = "Processes", Href = $"{externalUri}/processes" };
            rootObject.Links = new List<Link>() { selfLinkAsJson, selfLinkAsHtml, serviceDescLinkAsJson, serviceDescLinkAsHtml, conformanceLink, dataLink, processesLink };

            var u = (from links in rootObject.Links where links.Rel == "conformance" select links.Href).FirstOrDefault(); 

            return rootObject;
        }



    }
}
