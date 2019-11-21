using System.Collections.Generic;

namespace SharpGeoApi.Core
{
    public class Identification
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<string> Keywords { get; set; }

        public string KeyWords_Type { get; set; }

        public string Terms_Of_Service { get; set; }

        public string Url { get; set; }
    }
}
