using System.Collections.Generic;
using System.Linq;

namespace SharpGeoApi.Core
{
    public class Root
    {
        public Metadata Metadata { get; set; }

        public List<Link> Links { get; set; }
        public string GetUrl(string rel)
        {
            var link = (from links in Links where links.Rel == rel select links.Href).FirstOrDefault();
            return link + "?f=html";
        }
    }
}
