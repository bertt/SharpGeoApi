using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SharpGeoApi.Core;
using System.Collections.Generic;

namespace SharpGeoApi.Controllers
{
    [ApiController]
    [Route("processes")]
    public class ProcessesController : ControllerBase
    {
        private readonly ILogger<ProcessesController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string externalUri;
        public ProcessesController(IConfiguration configuration, ILogger<ProcessesController> logger)
        {
            _logger = logger;
            _configuration = configuration;
            externalUri = configuration["externalUri"];
        }

        [HttpGet, FormatFilter]
        public List<Process> Get()
        {
            var process = new Process();
            process.Version = "0.1.0";
            process.Title = "Hello World process";
            process.Description = "Hello World process";
            process.Keywords = new List<string>() { "hello world" };
            var link = new Link() { Type = "text/html", Rel = "canonical", Title = "Information", Href = $"{externalUri}/processes", HrefLang = "en-US" };
            process.Links = new List<Link>() { link };
            // todo: add inputs, outputs, example, itemtype, jobControlOptions, outputTransmission
            var processes = new Processes();
            processes.Add(process);
            return processes;
        }

    }
}


