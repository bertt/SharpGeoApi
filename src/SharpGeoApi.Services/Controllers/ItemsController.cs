using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SharpGeoApi.Services.Controllers
{
    [ApiController]
    [Route("items")]

    public class ItemsController : ControllerBase
    {

        [HttpGet, FormatFilter]
        public void Get()
        {
            var i = 0;

        }
    }
}