using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGeoApi.Core
{
    public class Output
    {
        public string id { get; set; }
        public string title { get; set; }

        public List<Format> formats { get; set; }

    }
}
