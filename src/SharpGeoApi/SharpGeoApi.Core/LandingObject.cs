using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace SharpGeoApi.Core
{
    public class LandingObject
    {
        [JsonIgnore]
        public List<string> Keywords { get; set; }
        [JsonIgnore]
        public string TermsOfService { get; set; }
        [JsonIgnore]
        public string LicenseName { get; set; }

        [JsonIgnore]
        public string LicenseUrl { get; set; }
        public List<Link> Links { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string GetUrl(string rel)
        {
            var link = (from links in Links where links.Rel == rel select links.Href).FirstOrDefault();
            return link + "?f=html";
        }
    }
}
