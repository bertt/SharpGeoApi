using System.Collections.Generic;

namespace SharpGeoApi.Core
{
    public class Process
    {
        public string Version { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Keywords { get; set; }
        public List<Link> Links { get; set; }
        public List<Input> Inputs { get; set; }
        public List<Output> Outputs { get; set; }
        public Example Example { get; set; }
        public List<string> ItemType { get; set; }
        public List<string> JobControlOptions { get; set; }
        public List<string> OutputTransmission { get; set; }
    }

}
