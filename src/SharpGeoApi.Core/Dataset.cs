using System.Collections.Generic;

namespace SharpGeoApi.Core
{
    public class Dataset
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Keywords { get; set; }
        public List<Link> Links { get; set; }
        public string ItemType { get; set; }

        public Extent Extent { get; set; }

        public DatasetProvider Provider { get; set; }
    }
}
