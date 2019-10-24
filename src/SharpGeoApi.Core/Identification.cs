using System.Collections.Generic;

namespace SharpGeoApi.Core
{
    public class Identification
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<string> Keywords { get; set; }

        public string KeyWordsType { get; set; }

        public string TermsOfService { get; set; }

        public string Url { get; set; }
    }
}
