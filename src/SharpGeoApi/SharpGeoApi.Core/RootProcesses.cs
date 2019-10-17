using System.Collections.Generic;

namespace SharpGeoApi.Core
{
    public class RootProcesses
    {
        public List<Process> Processes { get; set; }
    }

    public class Input1
    {
        public string id { get; set; }
        public string title { get; set; }
        public LiteralDataDomain LiteralDataDomain { get; set; }
        public int minOccurs { get; set; }
        public int maxOccurs { get; set; }
    }

    public class Output
    {
        public string id { get; set; }
        public string title { get; set; }

        public List<Format> formats { get; set; }

    }

}
