using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharpGeoApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpGeoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConformanceController : ControllerBase
    {
        private readonly ILogger<ConformanceController> _logger;

        public ConformanceController(ILogger<ConformanceController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public Conformance Get()
        //{
        //    var conformance = new Conformance();
        //    conformance.ConformsTo = new List<string>() {
        //        "http://www.opengis.net/spec/ogcapi-features-1/1.0/req/core", 
        //        "http://www.opengis.net/spec/ogcapi-features-1/1.0/req/oas30",
        //        "http://www.opengis.net/spec/ogcapi-features-1/1.0/req/html",
        //        "http://www.opengis.net/spec/ogcapi-features-1/1.0/req/geojson"};
        //    return conformance;
        //}

        [HttpGet]
        public Conformance1 Get()
        {
            var conformance = new Conformance1();
            return conformance;
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }

        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


    }

    public class Conformance1
    {
        public List<string> ConformsTo { get; set; }
    }


}
