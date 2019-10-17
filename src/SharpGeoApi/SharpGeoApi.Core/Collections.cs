using System.Collections.Generic;

namespace SharpGeoApi.Core
{

    public class Rootobject
    {
        public List<Collections> Collections { get; set; }
        public List<Link> Links { get; set; }
    }

    public class Collections
    {
        public List<Link> links { get; set; }
        public string id { get; set; }
        public string itemType { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string[] keywords { get; set; }
        public Extent extent { get; set; }
    }
}
