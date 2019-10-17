using System.Collections.Generic;

namespace SharpGeoApi.Core
{
    public class Process
    {
        public string Version { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Keywords { get; set; }
        public IEnumerable<Link> Links { get; set; }
        public IEnumerable<Input> Inputs { get; set; }
        public IEnumerable<Output> Outputs { get; set; }
        public Example Example { get; set; }
        public IEnumerable<string> ItemType { get; set; }
        public IEnumerable<string> JobControlOptions { get; set; }
        public IEnumerable<string> OutputTransmission { get; set; }
    }

}
