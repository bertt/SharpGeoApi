using System.Collections.Generic;

namespace SharpGeoApi.Core
{
    public class RootObject
    {
        public RootObject()
        {
        }
        public IEnumerable<Link> Links { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
