using System.Collections.Generic;

namespace SharpGeoApi.Core
{
    public class FeatureCollections
    {
        public FeatureCollections()
        {
            Collections = new List<FeatureCollection>();
            Links = new List<Link>();
        }
        public List<FeatureCollection> Collections { get; set; }
        public List<Link> Links { get; set; }
    }
}
